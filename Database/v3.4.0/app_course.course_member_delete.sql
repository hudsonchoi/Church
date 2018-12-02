/****** Object:  StoredProcedure [app_course].[course_member_delete]    Script Date: 12/2/2018 1:55:27 AM ******/
DROP PROCEDURE [app_course].[course_member_delete]
GO

/****** Object:  StoredProcedure [app_course].[course_member_delete]    Script Date: 12/2/2018 1:55:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




Create PROCEDURE [app_course].[course_member_delete]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id						int		=	0
,	@username				nvarchar(150)	=	null
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
		Declare @now  Datetime
		set @now = GetDate()

		 Update
			[dbo].[member_course]
			set
					update_by	=	@username
				,	update_date	=	@now
				,	row_status	=	'D'
				,   delete_date =   @now --Add Academy schema Landwin 3.4.0
			Where
				id =@id 
		

		If (@@error !=0 )
		Begin

			set @frk_n4ErrorCode = -1;
			set @frk_strErrorText = 'An error occurred while deleting the data into the table "[dbo].[member_course]"';
			Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

		END


		


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


