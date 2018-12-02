/****** Object:  StoredProcedure [app_course].[course_member_get]    Script Date: 12/2/2018 1:33:29 AM ******/
DROP PROCEDURE [app_course].[course_member_get]
GO

/****** Object:  StoredProcedure [app_course].[course_member_get]    Script Date: 12/2/2018 1:33:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_course].[course_member_get]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@code				int = null

) WITH EXECUTE AS Self
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
	Select @now =GetDate();

		Select v.*
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
			From dbo.memberview m 
		    inner join 
				dbo.member_course v
			on
				v.memberid = m.id
			Inner join dbo.ufcourse_get(@code) f
			On 
			  v.course_code = f.code
			WHERE ISNULL(v.row_status,'D') <> 'D' -- Show not deleted only Landwin 3.4.0 
			order by 
				f.sort ASC
		




	
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


