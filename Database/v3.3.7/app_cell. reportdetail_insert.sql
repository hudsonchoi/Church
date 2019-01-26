
/****** Object:  StoredProcedure [app_cell].[reportdetail_insert]    Script Date: 1/26/2019 2:27:30 PM ******/
DROP PROCEDURE [app_cell].[reportdetail_insert]
GO

/****** Object:  StoredProcedure [app_cell].[reportdetail_insert]    Script Date: 1/26/2019 2:27:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****************************************/
/* 012619 Add ServiceTimePlaceID		*/
/****************************************/
CREATE  PROCEDURE [app_cell].[reportdetail_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@parentid						int		=	0	
,	@memberid						int		=	0			
,	@attendance						bit		=	0
,	@reason							nvarchar(255)	=	null
,	@memo							nvarchar(255)	=	null
,	@roleCode						int		=	0
,	@roleLevel						int		=	0
,	@serviceTimePlaceID				int		=   0
,	@newid					int				=	null	OUTPUT
,	@newlastchanged			timestamp		=	null	OUTPUT 	
) 
WITH EXECUTE AS Self
AS

-- BEGIN HEADER
-- {

	if ( @frk_isRequiresNewTransaction = 1 )
	begin
		if ( @@tranCount > 0 )
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

			Insert Into dbo.rpt_cell_detail
			(		[member_id]
				   ,[attendance]
				   ,[reason]
				   ,[parent_id]
				   ,[memo]
				   ,[regdate]
				   ,[role_level]
				   ,[role_code]
				   ,[row_status]
				   ,[service_time_place_id] --012619
			)
			values
			(
						@memberid
					,	@attendance
					,	@reason
					,	@parentid
					,	@memo
					,	@now
					,	@roleLevel
					,	@roleCode
					,	'C'
					,	case when @serviceTimePlaceID > 0 then @serviceTimePlaceID else null end --012619
			)



	If (@@error !=0 )
	Begin

		set @frk_n4ErrorCode = -1;
		set @frk_strErrorText = 'An error occurred while updating the data into the table "[dbo].[rpt_cell]"';
		Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

	END


	Select 
			@newid  =id
		,	@newlastchanged = lastchanged
		From	dbo.rpt_cell_detail
		Where
			id = @@IDENTITY




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


