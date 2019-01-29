/****** Object:  StoredProcedure [app_cell].[reportdetail_get]    Script Date: 1/29/2019 1:54:58 AM ******/
DROP PROCEDURE [app_cell].[reportdetail_get]
GO

/****** Object:  StoredProcedure [app_cell].[reportdetail_get]    Script Date: 1/29/2019 1:54:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/**********************************************************/
/* 012919 Bugfix - include member who has role value null */
/**********************************************************/

CREATE PROCEDURE [app_cell].[reportdetail_get]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@code						int			=	0
,	@isNew						bit			=	0
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
	if(@isNew <> 0)
	Begin 
	Select 
			c.memberid as member_id
		,	m.first_name
		,	m.last_name
		,	m.cell
		,	m.sex
		,	c.role_code
		,	r.levels as role_level
		,	m.family_code
		From	dbo.member_cell c 
			Inner Join dbo.memberview m
			On m.id = c.memberid
			LEFT OUTER Join dbo.cell_roles r --012919
			On r.code = c.role_code
		Where 
				c.cell_code = @code  
			And 
				c.enddate is null
			And	
				c.row_status <> 'D'
		Order by 
			m.family_code ASC
				
	End			
	Else
	Begin 

	Select
				d.*
			,	m.first_name
			,	m.last_name
			,	m.cell
			,	m.sex
			,	m.family_code
		From
		dbo.rpt_cell_detail d
		Inner Join dbo.memberview m
		On
			m.id = d.member_id
		Where 
			parent_id = @code




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


