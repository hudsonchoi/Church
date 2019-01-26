
/****** Object:  StoredProcedure [app_cell].[reportdetail_update]    Script Date: 1/26/2019 3:15:55 PM ******/
DROP PROCEDURE [app_cell].[reportdetail_update]
GO

/****** Object:  StoredProcedure [app_cell].[reportdetail_update]    Script Date: 1/26/2019 3:15:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****************************************/
/* 012619 Add ServiceTimePlaceID		*/
/****************************************/
CREATE  PROCEDURE [app_cell].[reportdetail_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id								int		=	0	
,	@attendance						bit		=	0
,	@reason							nvarchar(255)	=	null
,	@memo							nvarchar(255)	=	null
,	@serviceTimePlaceID				int		=   0
,	@lastchanged					timestamp	=	null	
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

			Update 
				dbo.rpt_cell_detail
			Set
					[attendance] =	@attendance
				,	[reason]	=	@reason
				,	[memo]		=	@memo
				,	[row_status] = 'U'
				,	[service_time_place_id] = case when @serviceTimePlaceID > 0 then @serviceTimePlaceID else null end --012619
			Where
				id = @id
				And
				lastchanged = @lastchanged



	Select 
			@newlastchanged = lastchanged
		From	dbo.rpt_cell_detail
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


