/****** Object:  StoredProcedure [app_member].[member_list]    Script Date: 2/19/2019 7:30:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- 021319 Use GetCellName function
-- 021919 Fix SubDivision search
-- =============================================


ALTER PROCEDURE [app_member].[member_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0	
,	@memberid				int				=	0
,	@fullname				nvarchar(250)	=	null	
,	@firstName				nvarchar(150)	=	null
,	@lastName				nvarchar(150)	=	null
,	@enFirstName			nvarchar(150)	=	null
,	@enLastName				nvarchar(150)	=	null
,	@agefrom				int = 0
,	@ageto					int = 0
,	@city					nvarchar(150)  = null
,	@state					nvarchar(10)  = null
,	@baptismId				int  = 0
,	@sex					int  = -1
,	@subDivision			int  = 0
,	@baptismFrom			datetime  = null
,	@baptismTo				datetime  = null
,	@regfrom				datetime  = null
,	@regto					datetime  = null
,	@status					int = 0
,	@jobtype				int = 0
,	@birthfrom				datetime	= null
,	@birthto				datetime	= null
,	@married				int =	-1
,	@relationship			int =	0
,	@fellowship				int =	0
,	@active					int =	-1 
,	@home					varchar(14) = null
,	@cellPhone				varchar(14) = null 
) 
WITH EXECUTE AS Self
AS

-- BEGIN HEADER
-- {

	if ( @frk_isRequiresNewTransaction <> 0 )
	begin
		if ( @@tranCount <> 0 )
			rollback tran
		
		set lock_timeout 10000
		begin tran
	end

	begin try

-- }

-- BEGIN BODY
-- {
	-- initialize local variable statements here
	-- {
	Declare @now Datetime
	
	Set @now = GetDate()


	If(@baptismFrom is null and @baptismTo is null)
	Begin

		Select 
			m.id
		,	m.last_name
		,	m.first_name
		,	m.en_first_name
		,	m.en_last_name
		,	m.email
		,	m.address
		,	m.city
		,	m.statecode
		,	m.zipcode
		,	m.sex
		,	m.married
		,	m.cell
		,	ISNULL(dbo.GetCellName(m.id),'') CellName
		,	m.regdate
		,	m.birthday
		,	m.baptism_year
		,	m.baptismName
		,	dbo.GetAge(m.birthday,@now) as age
		,	m.home
		,	m.job
		,	m.FellowshipName
		,	m.fellowship_date
		,	m.family_code
		,	m.family_name
		,	m.status_date
		,	m.Relationship
		,	m.StatusCode
		,	(Select a.name From dbo.type_status a where a.id = m.StatusCode) as StatusName
		,	m.SubDivisionName
		,	spousename
		,	spouse
		,	m.active
	From 
		memberview m Inner join  dbo.uffellowshipforMember_get(@fellowship) f
	on f.code = ISNULL( m.fellowship_code,0)
	inner join dbo.ufsubDivision_get(@subDivision) s
	on s.id = ISNULL(m.subdiv_id,0)

	Where	
			m.id = Case When @memberid <> 0 Then @memberid Else m.id End
		And 
		(
			(ltrim(rtrim(m.last_name))+ltrim(rtrim(m.first_name))) like Case When LEN(ltrim(rtrim(@fullname))) > 0 Then @fullname + '%' Else  (ltrim(rtrim(m.last_name))+ltrim(rtrim(m.first_name)))  End
			OR
			m.en_first_name like Case When LEN(ltrim(rtrim(@fullname))) > 0 Then @fullname + '%' Else  m.en_first_name  End
			OR
			m.en_last_name like Case When LEN(ltrim(rtrim(@fullname))) > 0 Then @fullname + '%' Else  m.en_last_name  End
			OR
			(ltrim(rtrim(m.en_first_name)) + ' ' + ltrim(rtrim(m.en_last_name)))  like Case When LEN(ltrim(rtrim(@fullname))) > 0 Then @fullname + '%' Else (ltrim(rtrim(m.en_first_name)) + ' ' + ltrim(rtrim(m.en_last_name)))  End
		)
		And	m.first_name like Case When @firstName is not null Then @firstName +'%' Else m.first_name End
		And m.last_name like Case When @lastName is not null Then ltrim(rtrim(@lastName)) + '%' Else m.last_name End
		And isnull(m.en_first_name,'') like Case When @enFirstName is not null Then @enFirstName +'%' Else isnull(m.en_first_name,'')End
		And isnull(m.en_last_name,'') like Case When @enLastName is not null Then @enLastName + '%' Else isnull(m.en_last_name,'') End
		And isnull(m.cell,'') like Case When @cellPhone is not null Then @cellPhone +'%' Else isnull(m.cell,'') End
		And isnull(m.home,'') like Case When @home is not null Then @home + '%' Else isnull(m.home,'') End
		--And m.family_relationship = Case When @relationship <> 0 then @relationship Else m.family_relationship End
		And m.family_relationship = Case When @relationship <> 0 then 0 Else m.family_relationship End -- 2/21/2016 debugging to return family only replacing the above
		And	m.married = Case When @married <> -1 Then @married Else m.married End
		And m.sex	=	Case When @sex <> -1 Then @sex	Else m.sex End
		And isnull(m.baptism_id,0) = Case When @baptismId != 0 Then @baptismId Else isnull(m.baptism_id,0) End
		ANd	isnull(m.jobtype,0)	=	Case When @jobtype <> 0 Then @jobtype Else isnull(m.jobtype,0) End
		And isnull(m.city,'')	like	 Case When @city is not null Then @city+'%' Else isnull(m.city,'') End
	  	And isnull(m.statecode,'') like  Case When @state is not null Then @state+'%' Else isnull(m.statecode,'') End
		And m.regdate >= isnull(@regfrom , '1900-01-01')
		And m.regdate <= isnull(@regto, @now)
		And isnull(m.birthday, @now) >= isnull(@birthfrom, '1900-01-01') -- 12/27/2015 isnull(m.birthday, @now) is added to return records whose m.birthday is null
		And isnull(m.birthday, @now) <= isnull(@birthto, @now)  -- 12/27/2015 isnull(m.birthday, @now) is added to return records whose m.birthday is null
		And isnull(m.StatusCode, 0) = Case When @status <> 0 then @status Else isnull(m.StatusCode,0) End -- 7/27/2017 isnull(m.StatusCode, 0) is added to return records whose m.StatusCode is null
		And dbo.GetAge(isnull(m.birthday, @now) , @now) >= @agefrom  -- 12/27/2015 isnull(m.birthday, @now) is added to return records whose m.birthday is null
		And dbo.GetAge(isnull(m.birthday, @now) , @now) <= Case When @ageto <> 0 Then @ageto else 200 End	 -- 12/27/2015 isnull(m.birthday, @now) is added to return records whose m.birthday is null
		And m.active = Case When @active <> -1 then @active Else m.active End 
		AND s.id > CASE WHEN @subDivision > 0 THEN 0 ELSE -1 END --2/19/2019 Return target match on subdivision search
	End
	else
	Begin 
		

		Declare @baptismNull Datetime

	    Select @baptismNull =
			Case 
				When @baptismFrom is not null And @baptismTo is null  Then '1900-01-01'
				When @baptismTo is not null And @baptismFrom is null  Then  DATEADD(d,1 ,@now)
				Else '1900-01-01' End

	Select 
			m.id
		,	m.last_name
		,	m.first_name
		,	m.en_first_name
		,	m.en_last_name
		,	m.email
		,	m.address
		,	m.city
		,	m.statecode
		,	m.zipcode
		,	m.sex
		,	m.married
		,	m.cell
		,	m.CellName
		,	m.regdate
		,	m.birthday
		,	m.baptism_year
		,	m.baptismName
		,	dbo.GetAge(m.birthday,@now) as age
		,	m.home
		,	m.job
		,	m.FellowshipName
		,	m.fellowship_date
		,	m.family_code
		,	m.family_name
		,	(Select a.name From dbo.type_status a where a.id = m.StatusCode) as StatusName
		,	m.status_date
		,	m.Relationship
		,	m.StatusCode
		,	s.name as SubDivisionName
		,	spousename
		,	spouse
		,	m.active
	From 
		memberview m Inner join  dbo.uffellowshipforMember_get(@fellowship) f
	on f.code = ISNULL( m.fellowship_code,0)
	inner join dbo.ufsubDivision_get(@subDivision) s
	on s.id = ISNULL(m.subdiv_id,0)

	Where	
			m.id = Case When @memberid <> 0 Then @memberid Else m.id End
		And (ltrim(rtrim(m.last_name))+ltrim(rtrim(m.first_name))) like Case When @fullname is not null Then @fullname + '%' Else  (ltrim(rtrim(m.last_name))+ltrim(rtrim(m.first_name)))  End
		And	m.first_name like Case When @firstName is not null Then @firstName +'%' Else m.first_name End
		And m.last_name like Case When @lastName is not null Then @lastName + '%' Else m.last_name End
		And isnull(m.en_first_name,'') like Case When @enFirstName is not null Then @firstName +'%' Else isnull(m.en_first_name,'')End
		And isnull(m.en_last_name,'') like Case When @enLastName is not null Then @lastName + '%' Else isnull(m.en_last_name,'') End
		And isnull(m.cell,'') like Case When @cellPhone is not null Then @cellPhone +'%' Else isnull(m.cell,'') End
		And isnull(m.home,'') like Case When @home is not null Then @home + '%' Else isnull(m.home,'') End
		--And m.family_relationship = Case When @relationship <> 0 then @relationship Else m.family_relationship End
		And m.family_relationship = Case When @relationship <> 0 then 0 Else m.family_relationship End -- 5/1/2016 debugging to return family only replacing the above
		And	m.married = Case When @married <> -1 Then @married Else m.married End
		And m.sex	=	Case When @sex <> -1 Then @sex	Else m.sex End
		And isnull(m.baptism_id,0) = Case When @baptismId != 0 Then @baptismId Else isnull(m.baptism_id,0) End-- 5/1/2016 bug fix to return the specific batism type
		ANd	isnull(m.jobtype,0)	=	Case When @jobtype <> 0 Then @jobtype Else isnull(m.jobtype,0) End
		And isnull(m.city,'')	like	 Case When @city is not null Then @city+'%' Else isnull(m.city,'') End
	  	And isnull(m.statecode,'') like  Case When @state is not null Then @state+'%' Else isnull(m.statecode,'') End
		And m.regdate >= isnull(@regfrom , '1900-01-01')
		And m.regdate <= isnull(@regto, @now)
		And isnull(m.birthday, @now) >= isnull(@birthfrom, '1900-01-01') -- 12/27/2015 isnull(m.birthday, @now) is added to return records whose m.birthday is null
		And isnull(m.birthday, @now) <= isnull(@birthto, @now)  -- 12/27/2015 isnull(m.birthday, @now) is added to return records whose m.birthday is null
		And Isnull( m.baptism_year ,@baptismNull) >= isnull (@baptismFrom,'1900-01-01') 
		And Isnull( m.baptism_year ,@baptismNull) <= isnull (@baptismTo,@now) 
		And dbo.GetAge(isnull(m.birthday, @now) , @now) >= @agefrom  -- 12/27/2015 isnull(m.birthday, @now) is added to return records whose m.birthday is null
		And dbo.GetAge(isnull(m.birthday, @now) , @now) <= Case When @ageto <> 0 Then @ageto else 200 End	 -- 12/27/2015 isnull(m.birthday, @now) is added to return records whose m.birthday is null
		And isnull(m.StatusCode, 0) = Case When @status <> 0 then @status Else isnull(m.StatusCode,0) End -- 7/27/2017 isnull(m.StatusCode, 0) is added to return records whose m.StatusCode is null
		And m.active = Case When @active <> -1 then @active Else m.active End 
		AND s.id > CASE WHEN @subDivision > 0 THEN 0 ELSE -1 END --2/19/2019 Return target match on subdivision search
	End

-- }

-- BEGIN FOOTER
-- {

	end try
	begin catch

		if ( @frk_isRequiresNewTransaction = 1 ) 
		begin
			rollback tran
		end
		
		set rowcount 0

		if (ERROR_NUMBER() <> 50000)
		begin
			set @frk_n4ErrorCode = ERROR_NUMBER()
			set @frk_strErrorText = ERROR_MESSAGE()
		end
		else 
		begin
			set @frk_n4ErrorCode = @frk_n4ErrorCode
			set @frk_strErrorText = @frk_strErrorText
		end

		print	@frk_strErrorText + ' on line:' + convert( varchar(100), ERROR_LINE() )
		Insert dbo.db_error_log
		(
				error_code
			,	error_text
		)
		Values 
		(
			@frk_n4ErrorCode
		,	@frk_strErrorText
		)
		return @frk_n4ErrorCode

	end catch

	if (@frk_isRequiresNewTransaction = 1 ) 
	begin
		commit tran
	end

	set rowcount 0
	set @frk_n4ErrorCode = 0
	set @frk_strErrorText = ''

	return @frk_n4ErrorCode

-- }









GO


