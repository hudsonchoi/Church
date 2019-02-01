/****** Object:  StoredProcedure [app_cell].[cell_get]    Script Date: 2/1/2019 2:19:31 AM ******/
DROP PROCEDURE [app_cell].[cell_get]
GO

/****** Object:  StoredProcedure [app_cell].[cell_get]    Script Date: 2/1/2019 2:19:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/************************************************/
-- 2/19/2017 Show the most recent leader
-- 2/1/2019	 Exclude memberid = 0
/************************************************/

CREATE PROCEDURE [app_cell].[cell_get]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
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
	Declare @role  int 

	Select top 1 
		@role = code  
		From	dbo.cell_roles
		Order by levels Asc

		Select 
				v.*
			,	 assigned = 
				(
					select count(*) 
						from member_cell a 
						inner join 
					    dbo.ufcell_get(v.code) b
						on
						 b.code = a.cell_code
						where  a.enddate is NULL AND a.memberid > 0)--020119
			,	 Isnull((
					Select top 1 [name]= m.last_name+m.first_name 
						from dbo.members m 
							Inner Join member_cell c
						On	m.id = c.memberid
						Where 
							c.cell_code = v.code  and c.role_code = @role
							and  c.enddate is null 
							and c.row_status != 'D'
						Order by -- to show the most recent leader 2/19/2017
							c.update_date desc
				),'') as leader
			
			From
				dbo.cell v
			inner join 
				dbo.ufcell_get(0) b
			on 
				v.code = b.code

	

	
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


