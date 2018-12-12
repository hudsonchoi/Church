/****** Object:  StoredProcedure [app_course].[course_insert]    Script Date: 12/1/2018 4:38:01 PM ******/
DROP PROCEDURE [app_course].[course_insert]
GO

/****** Object:  StoredProcedure [app_course].[course_insert]    Script Date: 12/1/2018 4:38:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_course].[course_insert]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@parent_code			int		 = 0 
,	@regdate				datetime = null
,	@name					nvarchar(150)	=	null
,	@username				nvarchar(150)	=	null
,	@start_date				datetime = null
,	@end_date				datetime = null
,	@teacher_name			nvarchar(100) = null
,	@lecture_period_week	int = null
,	@newid					int		=	0	OUTPUT
,	@newlastchanged			timestamp = null OUTPUT		
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

	if ( 0 = Len(ltrim(rtrim(@name))))
		Begin 
		 RAISERROR ('Error raised in name.', -- Message text.
               16, -- Severity.
               1 -- State.
               );
		End


		Insert into dbo.courses
		(
				parent_code
			,	name
			,	regdate
			,	update_date
			,	update_by
			,	row_status
			,	start_date -- Add the Academy schema Landwin 3.4.0
			,	end_date
			,	teacher_name
			,	lecture_period_week
		)
		Values
		(
				@parent_code
			,	@name
			,	@regdate
			,	GETDATE()
			,	@username
			,	'C'
			,	@start_date
			,	@end_date
			,	@teacher_name
			,	@lecture_period_week
		)

		Select @newid = code
			,	@newlastchanged = lastchanged
			From dbo.courses
			Where 
				code = @@IDENTITY
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


