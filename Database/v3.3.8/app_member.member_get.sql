/****** Object:  StoredProcedure [app_member].[member_get]    Script Date: 2/8/2019 10:03:58 PM ******/
DROP PROCEDURE [app_member].[member_get]
GO

/****** Object:  StoredProcedure [app_member].[member_get]    Script Date: 2/8/2019 10:03:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- 020819 Use GetCellName function
-- =============================================


CREATE PROCEDURE [app_member].[member_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0		
,	@id						int	
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

		Select 
		[id], [first_name], [last_name], [en_first_name], [en_last_name], [email], [cell], [work_phone], [sex], [married], [family_code], [family_relationship], [birthday], [regdate], [address_id], [subdiv_id], [baptism_id], [baptism_year], [job], [entrytype], [jobtype], [spouse], [active], [row_status], [create_date], [create_by], [update_date], [update_by], [lastchanged]
		,[MemberId], [FellowshipCode], [CellCode], [FamilyName], [FellowshipStartdate], [StatusCode], [StatusChanged], [StatusName], ISNULL(dbo.GetCellName(MemberID),'') CellName, [FellowshipName], [Relationship], [CellRoleCode]
		,ministry = dbo.CsvMinistryList(a.id)
		From dbo.members a
		LEFT OUTER JOIN
			dbo.member_details  b
		On
			a.id = b.MemberId
		Where 
			id = @id
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


