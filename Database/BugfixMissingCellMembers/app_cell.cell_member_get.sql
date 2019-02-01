/****** Object:  StoredProcedure [app_cell].[cell_member_get]    Script Date: 2/1/2019 12:53:44 AM ******/
DROP PROCEDURE [app_cell].[cell_member_get]
GO

/****** Object:  StoredProcedure [app_cell].[cell_member_get]    Script Date: 2/1/2019 12:53:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/***************************************************************************/
/* 020118 Bugfix - Apply ISNULL(f.role_code,0) to include missing members */
/***************************************************************************/

CREATE PROCEDURE [app_cell].[cell_member_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@code			int =	0
,	@withHistory	bit	=	0
,	@role			int	=	0	
,	@from			Datetime	= null
,	@to				Datetime	= null
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
	Declare @now datetime 

	Select @now = GetDate()

	If (@withHistory = 0)
	Begin
	Select 
		f.*
	,   m.last_name
	,	m.first_name
	,   m.en_first_name
	,	m.en_last_name
	,	m.email
	,	m.[address]
	,	m.city
	,	m.statecode
	,	m.zipcode
	,	m.sex
	,	m.cell
	,	m.regdate
	,	m.baptism_year
	,	dbo.GetAge(birthday,@now) as age
	,	m.home
	,	m.birthday 
	,	m.job
	,	m.family_code
	,	m.cellname 
	,	m.relationship
	,	m.married
	,	m.BaptismName
	,	m.SubDivisionName
	,	m.StatusCode
	,	m.family_name
	,	m.spouse
	,	m.spousename
	,	m.active
	,   dbo.GetRolesByMemberID(f.memberid) as roles -- Added to support more than one role 5/17/2015 (Hudson Choi) 
	 From	dbo.ufcell_get(@code) c 
		Inner Join  member_cell f
		On f.cell_code = c.code
		Inner Join memberview m
		On f.memberid = m.id   
	 Where  
			(f.enddate is null   
		And  ISNULL(f.role_code,0) = Case When @role<> 0 Then @role Else ISNULL(f.role_code,0) End) OR 
		(f.enddate is null AND m.id in (SELECT DISTINCT mr.member_id FROM member_role mr WHERE mr.role_id = Case When @role<> 0 Then @role Else mr.role_id End)) -- Added for 직책별 multi role search 6/9/2015 (Hudson Choi) 
	 Order by c.cell asc
	End
	Else
	Begin
	Select 
		f.*
	,   m.last_name
	,	m.first_name
	,   m.en_first_name
	,	m.en_last_name
	,	m.email
	,	m.[address]
	,	m.city
	,	m.statecode
	,	m.zipcode
	,	m.sex
	,	m.cell
	,	m.regdate
	,	m.baptism_year
	,	dbo.GetAge(birthday,@now) as age
	,	m.home
	,	m.birthday 
	,	m.job
	,	m.family_code
	,	m.cellname 
	,	m.relationship
	,	m.married
	,	m.BaptismName
	,	m.SubDivisionName
	,	m.StatusCode
	,	m.family_name
	,	m.spouse
	,	m.spousename
	,	m.active
	,   dbo.GetRolesByMemberID(f.memberid) as roles  -- Added to support more than one role 5/17/2015 (Hudson Choi) 
	 From	dbo.ufcell_get(@code) c 
		Inner Join  member_cell f
		On f.cell_code = c.code
		Inner Join memberview m
		On f.memberid = m.id   
	 Where  
			(isnull (f.enddate, @now) >= Case When @from is not null Then  @from Else '1900-1-1' End
		And	isnull (f.enddate, DATEADD(m,-1, @now) )<= Case When @to is not null Then  @to Else  @now End
		And f.role_code = Case When @role <> 0 Then @role Else f.role_code End) OR
		(isnull (f.enddate, @now) >= Case When @from is not null Then  @from Else '1900-1-1' End
		And	isnull (f.enddate, DATEADD(m,-1, @now) )<= Case When @to is not null Then  @to Else  @now End
		AND m.id in (SELECT DISTINCT mr.member_id FROM member_role mr WHERE mr.role_id = Case When @role<> 0 Then @role Else mr.role_id End)) -- Added for 직책별 multi role search 6/9/2015
	 Order by c.cell asc
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


