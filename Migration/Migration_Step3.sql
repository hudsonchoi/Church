USE [ChoDae_ORG]
GO

/****** Object:  Schema [app_admin]    Script Date: 7/23/2014 12:09:14 AM ******/
CREATE SCHEMA [app_admin]
GO
/****** Object:  Schema [app_cell]    Script Date: 7/23/2014 12:09:14 AM ******/
CREATE SCHEMA [app_cell]
GO
/****** Object:  Schema [app_common]    Script Date: 7/23/2014 12:09:14 AM ******/
CREATE SCHEMA [app_common]
GO
/****** Object:  Schema [app_course]    Script Date: 7/23/2014 12:09:14 AM ******/
CREATE SCHEMA [app_course]
GO
/****** Object:  Schema [app_donate]    Script Date: 7/23/2014 12:09:14 AM ******/
CREATE SCHEMA [app_donate]
GO
/****** Object:  Schema [app_fellowship]    Script Date: 7/23/2014 12:09:14 AM ******/
CREATE SCHEMA [app_fellowship]
GO
/****** Object:  Schema [app_member]    Script Date: 7/23/2014 12:09:14 AM ******/
CREATE SCHEMA [app_member]
GO
/****** Object:  Schema [app_ministry]    Script Date: 7/23/2014 12:09:14 AM ******/
CREATE SCHEMA [app_ministry]
GO
/****** Object:  Schema [app_report]    Script Date: 7/23/2014 12:09:14 AM ******/
CREATE SCHEMA [app_report]
GO
/****** Object:  Schema [app_security]    Script Date: 7/23/2014 12:09:14 AM ******/
CREATE SCHEMA [app_security]
GO
/****** Object:  Schema [donate]    Script Date: 7/23/2014 12:09:14 AM ******/
CREATE SCHEMA [donate]
GO
/****** Object:  Schema [web_cell]    Script Date: 7/23/2014 12:09:14 AM ******/
CREATE SCHEMA [web_cell]
GO
/****** Object:  Schema [web_security]    Script Date: 7/23/2014 12:09:14 AM ******/
CREATE SCHEMA [web_security]
GO
/****** Object:  StoredProcedure [app_admin].[church_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE  PROCEDURE [app_admin].[church_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
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

	Select Top 1 * 
		From dbo.Church 


	
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
/****** Object:  StoredProcedure [app_admin].[church_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE  PROCEDURE [app_admin].[church_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id						int	=	0
,	@name					nvarchar(250)	= null
,	@address				nvarchar(250)	= null
,	@address2				nvarchar(150)	=	null
,	@city					nvarchar(150) = null
,	@state					nchar(2)	=	null
,	@zipcode				nchar(5)	=	null
,	@telephone				nchar(15)	=	null
,	@taxId					nvarchar(25)	=	null
,	@signer					nvarchar(150)	=	null
,	@fax					varchar(15)		=	null
,	@username				nvarchar(150)	=	null
,	@signImage				image			=	null
,	@lastchanged			timestamp		=	null
,	@newlastchanged			timestamp		=	null	OUTPUT
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
		UPDATE [dbo].[church]
			SET 
				[name] = @name
			,	[address1] = @address
			,	[address2] = @address2
			,	[city] =	@city
			,	[state] = @state
			,	[zipcode] = @zipcode
			,	[telephone] = @telephone
			,	[tax_id] = @taxId
			,	[signer] = @signer
			,	[update_date] = GetDate()
			,	[update_by] = @username 
			,	[sign_image] = @signImage
			,	[fax] = @fax
	  Where 
		id = @id
		and lastchanged = @lastchanged

		Select 
			@newlastchanged = lastchanged
		From 
			dbo.church
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
/****** Object:  StoredProcedure [app_admin].[role_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_admin].[role_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
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
	

	Select *
		From
			 dbo.role_master 
			 
		Order BY
			rolesName ASC




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
/****** Object:  StoredProcedure [app_admin].[sub_division_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_admin].[sub_division_delete]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id						int
,	@userName				nvarchar(150)	=	null
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

	Update  [dbo].[sub_division] 
		Set

		update_by	=	@userName
	,	row_status	=	'D'
	Where
		id	=	@id


	If (@@error !=0 )
	Begin

		set @frk_n4ErrorCode = -1;
		set @frk_strErrorText = 'An error occurred while updateting the data into the table "[dbo].[sub_division] "';
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
/****** Object:  StoredProcedure [app_admin].[sub_division_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_admin].[sub_division_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
	
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

		Select
			*
			From 
			dbo.sub_division
			Where
				row_status <> 'D'
			Order by
				name Desc


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
/****** Object:  StoredProcedure [app_admin].[sub_division_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[sub_division_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@name					nvarchar(150)	=	null
,	@parentId				int				=	0	
,	@userName				nvarchar(150)	=	null
,	@newid					int		OUTPUT
,	@newlastchanged			timestamp OUTPUT
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

 Insert  Into  [dbo].[sub_division] 
	(
		parent_id
	,	name
	,	create_date
	,	create_by
	,	update_date
	,	update_by
	,	row_status
)
 Values 
(	
		@parentId
	,	@name
	,	@now
	,	@userName
	,	@now
	,	@userName
	,	'C'
)


	If (@@error !=0 )
	Begin

		set @frk_n4ErrorCode = -1;
		set @frk_strErrorText = 'An error occurred while inserting the data into the table "[dbo].[sub_division]"';
		Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

	END

Select 
		@newlastchanged = lastchanged
	,	@newid = id 
From [dbo].[sub_division] 
Where id = @@identity





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
/****** Object:  StoredProcedure [app_admin].[sub_division_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_admin].[sub_division_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id						int
,	@name					nvarchar(150)	=	null
,	@parentId				int				=	0	
,	@userName				nvarchar(150)	=	null
,	@lastchanged			timestamp		=	null
,	@newlastchanged			timestamp OUTPUT
	
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

	Update  [dbo].[sub_division] 
		Set
		parent_id	=	@parentId
	,	name		=	@name
	,	update_date	=	@now
	,	update_by	=	@userName
	,	row_status	=	'U'
	Where
		id	=	@id
	And	lastchanged	=	@lastchanged


	If (@@error !=0 )
	Begin

		set @frk_n4ErrorCode = -1;
		set @frk_strErrorText = 'An error occurred while inserting the data into the table "[dbo].[sub_division] "';
		Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

	END

		Select 
			@newlastchanged = lastchanged
		From 
			[dbo].[sub_division] 
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
/****** Object:  StoredProcedure [app_admin].[type_baptism_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[type_baptism_delete]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id						int			
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


	Update dbo.type_baptism
		Set
			row_status = 'D' 
		,	update_by = @username
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
/****** Object:  StoredProcedure [app_admin].[type_baptism_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE  PROCEDURE [app_admin].[type_baptism_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
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

	Select *
	  From 
			dbo.type_baptism
		Where
			row_status <> 'D'
		
			Order by name ASC


	
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
/****** Object:  StoredProcedure [app_admin].[type_baptism_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[type_baptism_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@name					nvarchar(150)	=	null
,	@username			nvarchar(150)	=	null
,	@newid					int				OUTPUT
,	@newlastchanged			timestamp		OUTPUT
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


	Insert Into  dbo.type_baptism
	(
			row_status 
		 ,	[name] 
		 ,	update_by
		 ,	update_date 
	)
	Values 
	(
			'C'
		,	@name
		,	@username
		,	GETDATE()
	)

	Select 
			@newid = id 
		,	@newlastchanged = lastchanged
		From
			dbo.type_baptism
		 Where  id = @@IDENTITY

	
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
/****** Object:  StoredProcedure [app_admin].[type_baptism_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[type_baptism_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@name					nvarchar(150)	=	null
,	@username				nvarchar(150)	=	null
,	@lastchanged			timestamp	
,	@id						int			
,	@newlastchanged			timestamp		OUTPUT
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


	Update dbo.type_baptism
		Set
			row_status = 'U'
		 ,	[name]=@name 
		 ,	update_by = @username
		 ,	update_date = GETDATE()
		Where 
				id = @id
			And	lastchanged = @lastchanged

	Select 
		@newlastchanged = lastchanged
		From
			dbo.type_baptism
		 Where  id = @id

	
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
/****** Object:  StoredProcedure [app_admin].[type_entry_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[type_entry_delete]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id						int			

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


	Update dbo.type_entry
		Set
			row_status = 'D'
		,	update_by = @username
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
/****** Object:  StoredProcedure [app_admin].[type_entry_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[type_entry_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0		
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

	Select *
	  From 
			dbo.type_entry
		Where
			row_status <> 'D'
		Order by name ASC
		


	
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
/****** Object:  StoredProcedure [app_admin].[type_entry_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[type_entry_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@name					nvarchar(150)	=	null
,	@username				nvarchar(150)	=	null
,	@newid					int				OUTPUT
,	@newlastchanged			timestamp		OUTPUT
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


	Insert Into  dbo.type_entry
	(
			row_status 
		,	update_by
		,	[name] 
		,	update_date
	)
	Values 
	(
			'C'
		,	@username
		,	@name
		,	GetDate() 
	)

	Select 
			@newid = id
		,	@newlastchanged = lastchanged
		From
			dbo.type_entry
		 Where  id = @@IDENTITY

	
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
/****** Object:  StoredProcedure [app_admin].[type_entry_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[type_entry_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@name					nvarchar(150)	=	null
,	@lastchanged			timestamp	
,	@id						int			

,	@username				nvarchar(150)	=	null
,	@newlastchanged			timestamp		OUTPUT
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


	Update dbo.type_entry
		Set
			row_status = 'U'
		 ,	[name]=@name 
		 ,	update_by = @username
		 ,	update_date = GetDate()
		Where 
				id = @id
			And	lastchanged = @lastchanged

	Select 
		@newlastchanged = lastchanged
		From
			dbo.type_entry
		 Where  id = @id

	
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
/****** Object:  StoredProcedure [app_admin].[type_job_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[type_job_delete]
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


	Update dbo.type_job
		Set
			row_status = 'D'
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
/****** Object:  StoredProcedure [app_admin].[type_job_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_admin].[type_job_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0		
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

	Select *
	  From 
			dbo.type_job
		Where
			row_status <> 'D'
		Order by name ASC
		


	
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
/****** Object:  StoredProcedure [app_admin].[type_job_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[type_job_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@name					nvarchar(150)	=	null
,	@username				nvarchar(150)	=	null
,	@newid					int				OUTPUT
,	@newlastchanged			timestamp		OUTPUT
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


	Insert Into  dbo.type_job
	(
			row_status 
		 ,	[name] 
		 ,	update_by
	)
	Values 
	(
			'C'
		,	@name
		,	@username
	)

	Select 
			@newid = id 
		,	@newlastchanged = lastchanged
		From
			dbo.type_job
		 Where  id = @@IDENTITY

	
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
/****** Object:  StoredProcedure [app_admin].[type_job_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_admin].[type_job_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@name					nvarchar(150)	=	null
,	@lastchanged			timestamp	
,	@id						int			
,	@newlastchanged			timestamp		OUTPUT
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


	Update dbo.type_job
		Set
			row_status = 'U'
		 ,	[name]=@name 
		Where 
				id = @id
			And	lastchanged = @lastchanged

	Select 
		@newlastchanged = lastchanged
		From
			dbo.type_job
		 Where  id = @id

	
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
/****** Object:  StoredProcedure [app_admin].[type_relationship_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_admin].[type_relationship_delete]
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


	Update dbo.type_relationship
		Set
			row_status = 'D'
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
/****** Object:  StoredProcedure [app_admin].[type_relationship_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE  PROCEDURE [app_admin].[type_relationship_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
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

	Select *
	  From 
			dbo.type_relationship
		Where
			row_status <> 'D'
		Order by id ASC


	
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
/****** Object:  StoredProcedure [app_admin].[type_relationship_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[type_relationship_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@name					nvarchar(150)	=	null
,	@username				nvarchar(150)	=	null
,	@newid					int				OUTPUT
,	@newlastchanged			timestamp		OUTPUT
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


	Insert Into  dbo.type_relationship
	(
			row_status 
		 ,	[name] 
		 ,	update_by
		 ,	update_date
	)
	Values 
	(
			'C'
		,	@name
		,	@username 
		,	GetDate()
	)

	Select 
			@newid = id 
		,	@newlastchanged = lastchanged
		From
			dbo.type_relationship
		 Where  id = @@IDENTITY

	
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
/****** Object:  StoredProcedure [app_admin].[type_relationship_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_admin].[type_relationship_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@name					nvarchar(150)	=	null
,	@lastchanged			timestamp	
,	@id						int			
,	@newlastchanged			timestamp		OUTPUT
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


	Update dbo.type_relationship
		Set
			row_status = 'U'
		 ,	[name]=@name 
		Where 
				id = @id
			And	lastchanged = @lastchanged

	Select 
		@newlastchanged = lastchanged
		From
			dbo.type_relationship
		 Where  id = @id

	
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
/****** Object:  StoredProcedure [app_admin].[type_status_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_admin].[type_status_delete]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0	
,	@id				int			=	0
,	@username		nvarchar(150)	=	null
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

	Update  
			dbo.type_status
		set
					update_by	= @username
			,	update_date	= GETDATE()
			,	row_status =	'D'
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
/****** Object:  StoredProcedure [app_admin].[type_status_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_admin].[type_status_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0		
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

	Select *
	  From 
			dbo.type_status
		Where
			row_status <> 'D'
		Order by name ASC
		


	
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
/****** Object:  StoredProcedure [app_admin].[type_status_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_admin].[type_status_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0	
,	@name			nvarchar(150)	=	null
,	@isActive		bit		=	1
,	@username		nvarchar(150)	=	null
,	@newid					int				OUTPUT
,	@newlastchanged			timestamp		OUTPUT
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

	Insert Into 
			dbo.type_status
		(
			name 
			, is_active
			,	update_by
			,	update_date
			,	row_status 
		)
		Values 
		(	
			@name
			,	@isActive
			,	@username
			,	GetDate()
			,	'C'
		)
		
			Select 
			@newid = id
		,	@newlastchanged = lastchanged
		From
			dbo.type_status
		 Where  id = @@IDENTITY

	
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
/****** Object:  StoredProcedure [app_admin].[type_status_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[type_status_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0	
,	@id				int			=	0
,	@name			nvarchar(150)	=	null
,	@isActive		bit		=	1
,	@username		nvarchar(150)	=	null
,	@lastchanged	timestamp		=	null
,	@newlastchanged			timestamp		OUTPUT
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

	Update  
			dbo.type_status
		set
				name = @name 
			,	is_Active = @isActive
			,	update_by	= @username
			,	update_date	= GETDATE()
			,	row_status =	'U'
		Where
		id = @id
		And lastchanged	= @lastchanged 
		
			Select 
			@newlastchanged = lastchanged
		From
			dbo.type_status
		 Where  id = @id

	
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
/****** Object:  StoredProcedure [app_admin].[type_visit_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_admin].[type_visit_delete]
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


	Update dbo.type_visit
		Set
			row_status = 'D'
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
/****** Object:  StoredProcedure [app_admin].[type_visit_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE  PROCEDURE [app_admin].[type_visit_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
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

	Select *
	  From 
			dbo.type_visit
		Where
			row_status <> 'D'
		Order by name Asc


	
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
/****** Object:  StoredProcedure [app_admin].[type_visit_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[type_visit_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@name					nvarchar(150)	=	null
,	@username				nvarchar(150)	=	null
,	@newid					int				OUTPUT
,	@newlastchanged			timestamp		OUTPUT
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


	Insert Into  dbo.type_visit
	(
			row_status 
		 ,	[name] 
		 ,	update_by
	)
	Values 
	(
			'C'
		,	@name
		,	@username
	)

	Select 
			@newid = id 
		,	@newlastchanged = lastchanged
		From
			dbo.type_visit
		 Where  id = @@IDENTITY

	
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
/****** Object:  StoredProcedure [app_admin].[type_visit_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[type_visit_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@name					nvarchar(150)	=	null
,	@lastchanged			timestamp	
,	@username				nvarchar(150)	=	null
,	@id						int			
,	@newlastchanged			timestamp		OUTPUT
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


	Update dbo.type_visit
		Set
			row_status = 'U'
		 ,	[name]	=	@name 
		 ,	[update_by] = @username 
		Where 
				id = @id
			And	lastchanged = @lastchanged

	Select 
		@newlastchanged = lastchanged
		From
			dbo.type_visit
		 Where  id = @id

	
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
/****** Object:  StoredProcedure [app_admin].[user_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[user_delete]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id						int		
,	@updateby				nvarchar(150)	= null	
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


 
	Update dbo.users_master 
		set 
			isActive = 0 
		,	update_date = GETDATE()
		,   update_by = @updateby
		Where id = @id


	
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
/****** Object:  StoredProcedure [app_admin].[user_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[user_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0	
,	@id							int	=	0	
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
		 * 
		From 
			dbo.users_master 
		Where 
			id =@id 
	
	
 



	
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
/****** Object:  StoredProcedure [app_admin].[user_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[user_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0	
,	@username				varchar(150)	=	null
,	@password				nvarchar(20)	=	null
,	@roles					nvarchar(max)	=	null
,	@name					nvarchar(150)	=	null
,	@email					nvarchar(150)	=	null
,	@regdate				datetime		=	null
,	@updateby				nvarchar(150)	=	null
,	@newid					int		=	0 OUTPUT
,	@newlastchanged			timestamp  = null OUTPUT
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

If not Exists( Select * from users_master where username =@username)
 Begin 
	Insert Into
		 dbo.users_master 
			(	
				username 
			,	[Password]
			,	roles
			,	regdate
			,	email
			,   update_date
			,	[name]
			,   update_by
			,	isActive
			)
		Values 
			(
				@username 
			,	@password
			,	@roles
			,	@regdate
			,	@email
			,	GetDate()
			,	@name 
			,	@updateby
			,	1
			)
 
	Select 
			@newid = id 
		,	@newlastchanged = lastchanged 
	From dbo.users_master 
	Where id = @@identity

 End
 ELSE 
 BEGIN
	
    	RAISERROR ('Username aleady exist',16, 1) 
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
/****** Object:  StoredProcedure [app_admin].[user_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[user_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0	
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
		 * 
		From 
			dbo.users_master 
			Order by Username ASC

		
	
	
 



	
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
/****** Object:  StoredProcedure [app_admin].[user_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_admin].[user_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0	
,	@id						int				=	0
,	@username				varchar(150)	=	null
,	@password				nvarchar(20)	=	null
,	@roles					nvarchar(max)	=	null
,	@name					nvarchar(150)	=	null
,	@email					nvarchar(150)	=	null
,	@regdate				datetime		=	null
,	@updateby				nvarchar(150)	=	null
,	@lastchanged			timestamp		=	null
,	@newlastchanged			timestamp  = null OUTPUT
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

 
	update
		 dbo.users_master 
		Set	
				username	=	@username	 
			,	[Password]	=	@password
			,	roles		=	@roles
			,	email		=	@email
			,   update_date	=	GetDate()
			,	update_by = @updateby
			,	[name]		=	@name
		Where
			id = @id 
		ANd	lastchanged = @lastchanged

	Select 
			@newlastchanged = lastchanged 
	From dbo.users_master 
	Where id = @id

 



	
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
/****** Object:  StoredProcedure [app_cell].[cell_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_cell].[cell_delete]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0

,	@code					int				=	0
,	@username				varchar(150)	=	null
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

	Update dbo.cell
		Set
				update_by	=	@username
			,	update_date	=	GetDate()	
			,	row_status	=	'D'
		Where
			code = @code


  
			


	
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
/****** Object:  StoredProcedure [app_cell].[cell_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



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
			,	 assigned = (select count(*) from member_cell a where cell_code = v.code and a.enddate is NULL)
			,	 (
					Select top 1 [name]= m.last_name+m.first_name 
						from dbo.members m 
							Inner Join member_cell c
						On	m.id = c.memberid
						Where 
							c.cell_code = v.code  and c.role_code = @role
				) as leader
			
			From
				dbo.cell v
				
				


	
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
/****** Object:  StoredProcedure [app_cell].[cell_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_cell].[cell_insert]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@parentCode				int				=	0	
,	@name					nvarchar(150)	=	null
,	@username				varchar(150)	=	null
,	@lastchanged			timestamp	OUTPUT
,	@code					int			OUTPUT
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

	Insert Into dbo.cell
		(
				parent_code
			,	name
			,	create_by
			,	create_date
			,	row_status
		)
		Values
		(
				@parentcode
			,	@name
			,	@username
			,	GETDATE()
			,	'C'
		)


  
		Select
				@code = code
			,	@lastchanged = lastchanged
		From
			dbo.cell
		where
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
/****** Object:  StoredProcedure [app_cell].[cell_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_cell].[cell_list]
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

		Select 
				c.code
			,	c.cell as name
			From
				dbo.ufcell_get(0) c
				Order By sort asc
				
				


	
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
/****** Object:  StoredProcedure [app_cell].[cell_member_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_cell].[cell_member_delete]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@id						int				=	0
,	@username				nvarchar(150)	=	null
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
	Set @now = GetDate()
	
	Update
		 dbo.member_cell
		Set
				[enddate] = @now 
           ,	[update_by]	= @username
           ,	[update_date]	= @now 
		   ,	[row_status]	=	'D'
		Where 
				id = @id 

	If (@@error !=0 )
		Begin

			set @frk_n4ErrorCode = -1;
			set @frk_strErrorText = 'An error occurred while inserting the data into the table "[dbo].[member_cell]"';
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
/****** Object:  StoredProcedure [app_cell].[cell_member_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



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
	 From	dbo.ufcell_get(@code) c 
		Inner Join  member_cell f
		On f.cell_code = c.code
		Inner Join memberview m
		On f.memberid = m.id   
	 Where  
			f.enddate is null   
		And f.role_code = Case When @role<> 0 Then @role Else f.role_code End 
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
	 From	dbo.ufcell_get(@code) c 
		Inner Join  member_cell f
		On f.cell_code = c.code
		Inner Join memberview m
		On f.memberid = m.id   
	 Where  
			isnull (f.enddate, @now) >= Case When @from is not null Then  @from Else '1900-1-1' End
		And	isnull (f.enddate, DATEADD(m,-1, @now) )<= Case When @to is not null Then  @to Else  @now End
		And f.role_code = Case When @role <> 0 Then @role Else f.role_code End
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
/****** Object:  StoredProcedure [app_cell].[cell_member_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_cell].[cell_member_insert]
(
	@frk_n4ErrorCode		int				=	null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	=	null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@reassign				bit				=	0
,	@memberId				int				=	0
,	@code					int				=	0
,	@startDate				datetime		=	null
,	@roleCode				int				=	0
,	@username				nvarchar(150)	=	null
,	@newid					int				=	null	OUTPUT
,	@newlastchanged			timestamp		=	null	OUTPUT
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
	Set @now = GetDate()
	
	If(@reassign = 1)
	Begin
		Update  dbo.member_cell 
			Set
					enddate		=	@startDate
			,		update_by	=	@username
			,		update_date	=	@now
			,		row_status	=	'U'	
		Where
				memberid = @memberId
	End

	Insert into dbo.member_cell
		(
				[cell_code]
           ,	[memberid]
           ,	[startdate]
           ,	[role_code]
           ,	[update_by]
           ,	[update_date]
		   ,	[row_status]
		)
		Values
		(
				@code		
           ,	@memberId	
           ,	@startDate		
           ,	case when @roleCode <> 0 then @roleCode 
				else 
					(
					Select top 1 code from dbo.cell_roles Where default_level = 1
					) end	
           ,	@username	
           ,	@now
		   ,	'C'
		)		

	If (@@error !=0 )
		Begin

			set @frk_n4ErrorCode = -1;
			set @frk_strErrorText = 'An error occurred while inserting the data into the table "[dbo].[member_cell]"';
			Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

		END
	
	
	Select
		@newid = id
	,	@newlastchanged	= lastchanged
	From
		dbo.member_cell
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
/****** Object:  StoredProcedure [app_cell].[cell_member_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_cell].[cell_member_update]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@id						int				=	0
,	@roleCode				int				=	0
,	@startDate				datetime		=	null
,	@endDate				datetime		=	null
,	@username				varchar(150)	=	null
,	@lastchanged			timestamp		=	null
,	@newlastchanged			timestamp	OUTPUT
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
	Set @now = GetDate()


	Update 
		 dbo.member_cell
		set
				[startdate]		=	@startDate
		   ,	[enddate]		=	@endDate
           ,	[role_code]		=	@roleCode
           ,	[update_by]		=	@username
           ,	[update_date]	=	@now
		   ,	[row_status]	=	'U'
		Where
			id = @id
		and	lastchanged	=	@lastchanged

	If (@@error !=0 )
		Begin

			set @frk_n4ErrorCode = -1;
			set @frk_strErrorText = 'An error occurred while inserting the data into the table "[dbo].[member_cell]"';
			Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

		END
	
	
	Select
		@newlastchanged	= lastchanged
	From
		dbo.member_cell
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
/****** Object:  StoredProcedure [app_cell].[cell_role_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_cell].[cell_role_delete]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id					int			=	0
,	@username			nvarchar(150) = null	
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
	  [dbo].[cell_roles] 
	Set
			update_by	=	@username
		,	update_date	=	@now
		,	row_status	=	'D'
	Where
		code = @id
	



	If (@@error !=0 )
	Begin

		set @frk_n4ErrorCode = -1;
		set @frk_strErrorText = 'An error occurred while updating the data into the table "[dbo].[cell_roles]"';
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
/****** Object:  StoredProcedure [app_cell].[cell_role_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_cell].[cell_role_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
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
	

	Select *
		From
			 [dbo].[cell_roles] 
		Where 
			row_status <> 'D'
		Order BY
			levels ASC




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
/****** Object:  StoredProcedure [app_cell].[cell_role_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_cell].[cell_role_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@name				nvarchar(20)	= null
,	@level				int		=	0
,	@default		bit		=	0	
,	@multipleAssign		bit		=	0
,	@username			nvarchar(150) = null	
,	@newid					int		OUTPUT
,	@newlastchanged			timestamp OUTPUT
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

	Insert  Into  [dbo].[cell_roles] 
	(
			name
		,	levels
		,	default_level
		,	multiple_assign
		,	create_by
		,	create_date
		,	update_by
		,	update_date
		,	row_status
	)
	Values 
	(	
			@name
		,	@level
		,	@default
		,	@multipleAssign
		,	@username
		,	@now
		,	@username
		,	@now
		,	'C'

	)



	If (@@error !=0 )
	Begin

		set @frk_n4ErrorCode = -1;
		set @frk_strErrorText = 'An error occurred while inserting the data into the table "[dbo].[cell_roles]"';
		Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

	END

	Select 
			@newlastchanged = lastchanged
		,	@newid= code 
		From 
			[dbo].[cell_roles] 
		Where 
			code = @@identity

	if(@default = 1)
	Begin

		Update dbo.cell_roles
		 set
		 default_level = 0 
		 Where 
		 code <> @newid 

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
/****** Object:  StoredProcedure [app_cell].[cell_role_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_cell].[cell_role_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
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
	

	Select 
			code
		,	name
		From
			 [dbo].[cell_roles] 
		Where 
			row_status <> 'D'
		Order BY
			default_level DESC
			,levels ASC




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
/****** Object:  StoredProcedure [app_cell].[cell_role_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_cell].[cell_role_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id					int			=	0
,	@name				nvarchar(20)	= null
,	@level				int		=	0
,	@default			bit		=	0	
,	@multipleAssign		bit		=	0
,	@username			nvarchar(150) = null	
,	@lastchanged		timestamp = null
,	@newlastchanged			timestamp OUTPUT
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
	  [dbo].[cell_roles] 
	Set
			name	=	@name
		,	levels	=	@level
		,	default_level	=	@default
		,	multiple_assign	=	@multipleAssign
		,	update_by	=	@username
		,	update_date	=	@now
		,	row_status	=	'U'
	Where
		code = @id
		And 
			lastchanged = @lastchanged



	If (@@error !=0 )
	Begin

		set @frk_n4ErrorCode = -1;
		set @frk_strErrorText = 'An error occurred while updating the data into the table "[dbo].[cell_roles]"';
		Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

	END
	
	if(@default = 1)
	Begin

		Update dbo.cell_roles
		 set
		 default_level = 0 
		 Where 
		 code <> @id

	End
	
	Select 
			@newlastchanged = lastchanged
		From 
			[dbo].[cell_roles] 
		Where 
			code = @id





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
/****** Object:  StoredProcedure [app_cell].[cell_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_cell].[cell_update]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0

,	@code					int				=	0
,	@parentCode				int				=	0	
,	@name					nvarchar(150)	=	null
,	@username				varchar(150)	=	null
,	@lastchanged			timestamp	
,	@newlastchanged		    timestamp			OUTPUT
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

	Update dbo.cell
		Set
				parent_code =	@parentCode
			,	name		=	@name
			,	update_by	=	@username
			,	update_date	=	GetDate()	
			,	row_status	=	'U'
		Where
			code = @code
			And lastchanged = @lastchanged


  
		Select
				@newlastchanged = lastchanged
		From
			dbo.cell
		where
			code = @code
			


	
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
/****** Object:  StoredProcedure [app_cell].[login]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_cell].[login]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@user					nvarchar(250)	=	null
,	@pw						nvarchar(250)	=	null
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

	   Select 
			* 
		From 
			dbo.cell_user 
		Where 
				ltrim(rtrim(email))= @user  
			and ltrim(rtrim([password])) =@pw 
 
			


	
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
/****** Object:  StoredProcedure [app_cell].[member_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_cell].[member_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@memberid			int =	0
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
			c.id
		,	a.name as cellname
		,	b.name as rolename
		,	c.startdate
		,	c.enddate
		From
			dbo.cell a
		Inner Join 
			dbo.member_cell c
		On	
			c.cell_code = a.code
		Inner Join
			dbo.cell_roles b
		On	
			b.code = c.role_code
		Where 
			c.memberid = @memberid

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
/****** Object:  StoredProcedure [app_cell].[report_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE  PROCEDURE [app_cell].[report_delete]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id						int				=	0
,	@username				nvarchar(150)	=	null
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




	Update [dbo].[rpt_cell]
        Set
			
				[update_date]	=	@now
			,	[update_by]	=	@username
			,	[row_status] = 'D'
		Where 
			id = @id

	Update dbo.rpt_cell_detail
		Set
			row_status = 'D'
		Where
			parent_id = @id
			 

	If (@@error !=0 )
	Begin

		set @frk_n4ErrorCode = -1;
		set @frk_strErrorText = 'An error occurred while updating the data into the table "[dbo].[rpt_cell]"';
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
/****** Object:  StoredProcedure [app_cell].[report_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_cell].[report_get]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@id				int					=	0

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

			Select 
					r.*
				,	c.name as  CellName
				,	(select count(id) From dbo.rpt_cell_detail a where a.parent_id = r.id and a.attendance =1) as atten_count
			From dbo.rpt_cell r
				Inner Join 
				dbo.cell	c
				On
					c.code = r.cell_code 
			Where 
				r.id = @id 

				
				
				


	
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
/****** Object:  StoredProcedure [app_cell].[report_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE  PROCEDURE [app_cell].[report_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@cellCode				int = 0
,	@regDate				datetime = null
,	@cellDate				datetime	=	null
,	@cellPlace				nvarchar(150)	=	null
,	@newMember				nvarchar(250)	=	null
,	@leader					nvarchar(150)	=	null
,	@prayer					nvarchar(150)	=	null
,	@memo					ntext			=	null
,	@request				nvarchar(250)	=	null
,	@attenCount				int				=	0	
,	@cell_leader			nvarchar(150)	=	null
,	@cell_leader2			nvarchar(150)	=	null
,	@username				nvarchar(150)	=	null
,	@newid					int = 0 OUTPUT
,	@newlastchanged			timestamp = null OUTPUT	
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
	Declare @total int

	
	Select  @total = count(*)
	From
	(
		select m.family_code from member_cell c inner  join  dbo.members m on c.memberid = m.id 
			where c.enddate is null
			and		c.cell_code = @cellCode
			Group by m.family_code
	) as t

	INSERT INTO [dbo].[rpt_cell]
        (
				[cell_code]
			,	[reg_date]
			,	[cell_date]
			,	[cell_place]
			,	[new_member]
			,	[leader]
			,	[prayer]
			,	[memo]
			,	[request]
			,	[atten_family_count]
			,	[cell_leader]
			,	[cell_leader2]
			,	[total_family_count]
			,	[create_by]
			,	[update_date]
			,	[update_by]
			,	row_status
		)
		Values
		(	
				@cellCode
			,	@regDate
			,	@cellDate
			,	@cellPlace
			,	@newMember
			,	@leader
			,	@prayer
			,	@memo
			,	@request
			,	@attenCount
			,	@cell_leader
			,	@cell_leader2
			,	@total
			,	@username
			,	@now
			,	@username
			,	'C'
		)



	If (@@error !=0 )
	Begin

		set @frk_n4ErrorCode = -1;
		set @frk_strErrorText = 'An error occurred while updating the data into the table "[dbo].[rpt_cell]"';
		Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

	END


	Select 
			@newid  = id
		,	@newlastchanged = lastchanged

		From	dbo.rpt_cell
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
/****** Object:  StoredProcedure [app_cell].[report_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_cell].[report_list]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@code				int					=	0
,	@from			datetime				=	null
,	@to				datetime				=	null
,	@createby		nvarchar(150)			=	null
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

		Select 
				r.Id
			,	r.reg_date
			,	r.request
			,	r.leader
			,	r.cell_date
			,	r.cell_place
			,	attendance= isnull( ( Select Count(*) From rpt_cell_detail m where m.parent_id= r.Id and m.Attendance = 1),0)
			,	r.new_member
			,	r.atten_family_count
			,	memberno= isnull( ( Select Count(*) From rpt_cell_detail m where m.parent_id= r.Id ),0)
			,	c.cell 
			
			From dbo.ufcell_get(@code) c
			Inner Join dbo.rpt_cell r
			on r.cell_code = c.code
		Where
			r.reg_date >= Case When @from is not null Then @from Else '1900-1-1' End
		AND	r.reg_date <= Case When @to	is not null Then @to Else GetDate() END
		And isnull(r.create_by,'')	= Case When @createby is not null Then @createby Else isnull(r.create_by,'')	End	
		ANd r.row_status <> 'D'
				
				


	
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
/****** Object:  StoredProcedure [app_cell].[report_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE  PROCEDURE [app_cell].[report_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id						int				=	0
,	@cellDate				datetime		=	null
,	@cellPlace				nvarchar(150)	=	null
,	@newMember				nvarchar(250)	=	null
,	@leader					nvarchar(150)	=	null
,	@prayer					nvarchar(150)	=	null
,	@memo					ntext			=	null
,	@request				nvarchar(250)	=	null
,	@attenCount				int				=	0	
,	@username				nvarchar(150)	=	null
,	@lastchanged			timestamp		=	null
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

	Update [dbo].[rpt_cell]
        Set
				[cell_date]		=	@cellDate
			,	[cell_place]	=	@cellPlace	
			,	[new_member]	=	@newMember
			,	[leader]		=	@leader
			,	[prayer]		=	@prayer
			,	[memo]			=	@memo
			,	[request]		=	@request
			,	[atten_family_count]	=	@attenCount
			,	[update_date]	=	@now
			,	[update_by]	=	@username
			,	[row_status] = 'U'
		Where 
			id = @id
			And lastchanged = @lastchanged
		



	If (@@error !=0 )
	Begin

		set @frk_n4ErrorCode = -1;
		set @frk_strErrorText = 'An error occurred while updating the data into the table "[dbo].[rpt_cell]"';
		Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

	END


	Select 
			@newlastchanged = lastchanged
		From	dbo.rpt_cell
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
/****** Object:  StoredProcedure [app_cell].[reportdetail_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



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
			Inner Join dbo.cell_roles r
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
/****** Object:  StoredProcedure [app_cell].[reportdetail_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


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
/****** Object:  StoredProcedure [app_cell].[reportdetail_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [app_cell].[reportdetail_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id								int		=	0	
,	@attendance						bit		=	0
,	@reason							nvarchar(255)	=	null
,	@memo							nvarchar(255)	=	null
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
/****** Object:  StoredProcedure [app_cell].[transfer_member]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_cell].[transfer_member]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@enddate				datetime		=	null
,	@cellcode				int				=	0
,	@list					nvarchar(max)	=	null
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

	Declare @role  int 
	Select 
		@role = code From dbo.cell_roles 
		Where default_level = 1 AND  row_status <> 'D'
		
		Update c
			Set 
					c.enddate	= @enddate
				,	c.update_by = @username
				,	c.update_date = GETDATE()
				,	c.row_status = 'U'
			From 
				dbo.member_cell c
			Inner Join
				dbo.CommaListToTable(@list) a
			ON
				a.IntKey = c.memberid
			Where 
				c.enddate is Null
				And
				c.row_status <>'D'


	Insert Into 
		dbo.member_cell 
		(
				cell_code
			,	memberid
			,	role_code
			,	startdate
		) 
	Select	
			@cellcode
		,	IntKey
		,	@role
		,	@enddate
		From 
			dbo.CommaListToTable(@list) 
				
				


	
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
/****** Object:  StoredProcedure [app_cell].[user_password_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_cell].[user_password_get]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@email					nvarchar(100)	=	null
,	@birthdate				Datetime		=	null
,	@password				varchar(25)		= null OUTPUT
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

	Select @password = password 
		From dbo.view_cellusers 
		Where 
			email = @email 
		And birthday =@birthdate

  
			


	
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
/****** Object:  StoredProcedure [app_cell].[user_password_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_cell].[user_password_update]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@username				nvarchar(150)	=	null
,	@password				varchar(25)		=	null
,	@oldpassword			varchar(25)		=	null
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


		Update 
			dbo.cell_user 
			Set 
			[password] =	@password 
		Where 
			email=@username 
		And [password] = @oldpassword
  
			


	
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
/****** Object:  StoredProcedure [app_common].[address_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_common].[address_get]
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
		*
		From dbo.address
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
/****** Object:  StoredProcedure [app_common].[address_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_common].[address_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@address				varchar(100)	=	null
,	@city					varchar(50)		=	null
,	@statecode				char(2)			=	null
,	@zipcode				char(5)			=	null
,	@home					varchar(15)		=	null
,	@username				nvarchar(150)	=	null
,	@newid					int OUTPUT
,	@newlastchanged			timestamp	=	null OUTPUT
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


	Insert Into dbo.address
	( 
			address 
		,	city
		,	statecode
		,	zipcode
		,	home
		,	update_by
		,	update_date
	)
	Values
	(
			ltrim(rtrim(@address)) 
		,	ltrim(rtrim(@city))
		,	ltrim(rtrim(upper(@statecode)))
		,	ltrim(rtrim(@zipcode))
		,	ltrim(rtrim(@home))
		,	@username
		,	GetDate()
	)

	Select 
		@newid = id
	,	@newlastchanged = lastchanged 
		From dbo.address
		Where id = @@IDENTITY

	
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
/****** Object:  StoredProcedure [app_common].[address_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_common].[address_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@address				varchar(100)	=	null
,	@city					varchar(50)		=	null
,	@statecode				char(2)			=	null
,	@zipcode				char(5)			=	null
,	@username				nvarchar(150)	=	null
,	@home					varchar(15)		=	null
,	@lastchanged			timestamp		=	null
,	@newlastchanged			timestamp		=	null	OUTPUT
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


	Update  dbo.address 
		Set
			[address]	=	@address
		,	city		=	@city
		,	statecode	=	@statecode
		,	zipcode		=	@zipcode
		,	home		=	@home
		,	update_by	=	@username
		,	update_date	=	GETDATE()
		Where 
			id	=	@id 
			And lastchanged = @lastchanged

	Select 
		@newlastchanged = lastchanged
	From 
		[dbo].[address]
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
/****** Object:  StoredProcedure [app_common].[city_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_common].[city_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0		
,	@state				nvarchar(150)	=	null	
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
			city 
			From dbo.zipcode_data 
			Where 
				[state]	=	@state 
			Group by city 
			Order by city ASC
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
/****** Object:  StoredProcedure [app_common].[login]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [app_common].[login]
(
	@frk_n4ErrorCode		int				=	null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	=	null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0		
,	@user					nvarchar(150)	=	null
,	@password				nvarchar(150)	=	null	
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
			Declare @rolelist nvarchar(max)
			Declare @storelist nvarchar(max)
			If	Exists 
				(	
					SELECT id 
						From users_master 
						Where username=@user and [Password] =@password and isActive = 1)
			Begin 

				Update users_master 
					Set lastlogin = getdate() 
					Where username=@user and [password] =@password	 
				
				SELECT * 
					From users_master 
					Where 
						username	=	@user 
					And [password]	=	@password	 
					And IsActive	=	1
				
				SELECT  
					@rolelist=roles  
					From
						users_master 
					Where 
						username=@user 
					And [Password] =@password	
	
				SELECT R.roles
					FROM role_master AS R 
					INNER JOIN 
						dbo.CommaListToTable(@rolelist) AS U 
					ON
						R.id = U.IntKey 
      
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
/****** Object:  StoredProcedure [app_common].[state_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [app_common].[state_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0			
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
			statecode as code
		,	statecode  as name
		From 
		dbo.address
		Where
			statecode is not null
		 And Len(statecode) > 0 
		Group by statecode 
		Order by statecode Asc
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
/****** Object:  StoredProcedure [app_common].[status_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_common].[status_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0	
,	@active					int			=	-1		
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

		Select * 
			From type_status 
			Where  
				 is_active = Case When @active <> -1 then @active Else is_active End
			Order by 
				is_active DESC 
				, name Asc 
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
/****** Object:  StoredProcedure [app_common].[subdivision_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_common].[subdivision_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0			
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
		    * From 
			dbo.ufsubDivision_get(0)
		
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
/****** Object:  StoredProcedure [app_common].[type_baptism_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [app_common].[type_baptism_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0			
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
			id 
		,   name
		From 
		dbo.type_baptism
		Where
			row_status <> 'D'
			Order by name Asc
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
/****** Object:  StoredProcedure [app_common].[type_entry_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [app_common].[type_entry_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0			
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
			id 
		,   name
		From 
		dbo.type_entry
		Where
			row_status <> 'D'
	Order by name Asc
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
/****** Object:  StoredProcedure [app_common].[type_job_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [app_common].[type_job_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0			
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
			id 
		,   name
		From 
		dbo.type_job
		Where
			row_status <> 'D'
	Order by name Asc
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
/****** Object:  StoredProcedure [app_common].[type_relationship_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_common].[type_relationship_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0			
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
			id 
		,   name
		From 
		dbo.type_relationship
		Where
			row_status <> 'D'
	
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
/****** Object:  StoredProcedure [app_common].[type_status_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_common].[type_status_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0			
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
			id
		,	name
		From 
		dbo.type_status
		Where
			row_status <> 'D'
	Order by name Asc
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
/****** Object:  StoredProcedure [app_common].[type_visit_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [app_common].[type_visit_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0			
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
			id 
		,   name
		From 
		dbo.type_visit
		Where
			row_status <> 'D'
	Order by name Asc
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
/****** Object:  StoredProcedure [app_common].[zipcode_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_common].[zipcode_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0		
,	@zipcode				varchar(10)		=	null
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
		*
		From dbo.zipcode_data 
		Where 
			zipcode	=	@zipcode
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
/****** Object:  StoredProcedure [app_course].[course_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_course].[course_delete]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@code					int		 = 0	
,	@username				nvarchar(150)	=	null
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
		Update  dbo.courses
			Set
				update_date	=	GETDATE()
			,	update_by	=	@username
			,	row_status	=	'D'
			Where
				code = @code
			

	
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
/****** Object:  StoredProcedure [app_course].[course_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_course].[course_get]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@active					bit		=	0
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

		Select 
				* 
			,  total = isnull((select count(*) from dbo.member_course where member_course.course_code = courses.code),0) 
			From
			dbo.courses
			Where
				row_status <> Case When @active = 1 Then 'D' Else '' End 
			Order by parent_code ASC 
				

		 
				


	
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
/****** Object:  StoredProcedure [app_course].[course_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
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
		)
		Values
		(
				@parent_code
			,	@name
			,	@regdate
			,	GETDATE()
			,	@username
			,	'C'
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
/****** Object:  StoredProcedure [app_course].[course_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_course].[course_list]
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
		Select *
		From 
			dbo.ufcourse_get(0)
			Order by sort ASC
			

	
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
/****** Object:  StoredProcedure [app_course].[course_member_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
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
/****** Object:  StoredProcedure [app_course].[course_member_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [app_course].[course_member_get]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@codelist				nvarchar(MAX) = null
,	@fellowship				int		=   0
,	@cellrole				int		=	0
,	@from					datetime	=	null
,	@to						datetime	=	null
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

		Select c.*
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
			Inner join dbo.member_course c
			On 
				c.memberid = m.id
			Inner join dbo.CommaListToTable(@codelist) a 
			On
				a.IntKey = c.course_code
			Inner join dbo.uffellowship_get(@fellowship) f
			ON
				isnull(f.code,0) = isnull(m.fellowship_code,0)
			Where 
				c.graduated >= Isnull(@from , '1900-1-1')
				And c.graduated <= ISNULL(@to, GetDate())
				And isnull(m.CellRoleCode,0) = Case When @cellrole <> 0 Then @cellrole Else isnull(m.CellRoleCode,0) End
				And c.row_status <> 'D'
		




	
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
/****** Object:  StoredProcedure [app_course].[course_member_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_course].[course_member_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@memberid				int		=	0	
,	@courseId				int		=	0
,	@graduate				datetime	=	null
,	@username				nvarchar(150)	=	null
,	@newId			int		=	0	OUTPUT
,	@newlastchanged	timestamp =	null	OUTPUT
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
	if(@courseId != 0)
	begin
		Insert into
			[dbo].[member_course]
			(
					course_code
				,	memberid
				,	graduated
				,	update_by
				,	update_date
				,	row_status
			)
			Values
			(
					@courseId
				,	@memberid
				,	@graduate
				,	@username
				,	@now
				,	'C'
			)
	End	

		If (@@error !=0 )
		Begin

			set @frk_n4ErrorCode = -1;
			set @frk_strErrorText = 'An error occurred while inserting the data into the table "[dbo].[member_course]"';
			Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

		END

		Select 
				@newlastchanged = lastchanged
			,	@newid	= id
		From [dbo].[member_course]
		Where id = @@identity

		


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
/****** Object:  StoredProcedure [app_course].[course_member_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_course].[course_member_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id						int		=	0
,	@courseId				int		=	0
,	@graduate				datetime	=	null
,	@username				nvarchar(150)	=	null
,	@lastchanged			timestamp	=	null
,	@newlastchanged			timestamp =	null	OUTPUT
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
					course_code	=	@courseId
				,	graduated	=	@graduate
				,	update_by	=	@username
				,	update_date	=	@now
				,	row_status	=	'U'
			Where
				id =@id 
			And lastchanged		=	@lastchanged
		

		If (@@error !=0 )
		Begin

			set @frk_n4ErrorCode = -1;
			set @frk_strErrorText = 'An error occurred while inserting the data into the table "[dbo].[member_course]"';
			Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

		END

		Select 
				@newlastchanged = lastchanged
		From [dbo].[member_course]
		Where id = @id

		


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
/****** Object:  StoredProcedure [app_course].[course_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_course].[course_update]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@code					int		 = 0	
,	@parent_code			int		 = 0 
,	@regdate				datetime = null
,	@name					nvarchar(150)	=	null
,	@username				nvarchar(150)	=	null
,	@lastchanged		    timestamp		=	null
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
		Update  dbo.courses
			Set
				parent_code = @parent_code
			,	name	=	@name
			,	regdate	=	@regdate
			,	update_date	=	GETDATE()
			,	update_by	=	@username
			,	row_status	=	'U'
			Where
				code = @code
			And	lastchanged = @lastchanged
			

		Select 
				@newlastchanged = lastchanged
			From dbo.courses
			Where 
				code = @code
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
/****** Object:  StoredProcedure [app_course].[member_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_course].[member_get]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@memberid				int		=	0
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

		Select c.*
			
			From
			 dbo.member_course c
			Where  
				c.memberid = @memberid
			Order by
				c.graduated Desc




	
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
/****** Object:  StoredProcedure [app_donate].[donate_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_donate].[donate_delete]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@userid					int
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
	Declare @now Datetime
	Set @now = GetDate()

 Update  dbo.donates 
	Set
		update_date	=	@now
	,	update_by	=	@userid
	,	row_status	=	'U'
	Where
		[no] = @id






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
/****** Object:  StoredProcedure [app_donate].[donate_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_donate].[donate_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@donateid				int		=	0
,	@amount					money	=	0
,	@donatecode				int		=	0
,	@paycode				tinyint			=	0
,	@memo					nvarchar(250)	=	null
,	@book_id				int				=	0
,	@regdate				datetime		=	null
,	@username				nvarchar(150)		= null
,	@newid					int		OUTPUT
,	@newlastchanged			timestamp OUTPUT
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

 Insert  Into  dbo.donates 
	(
		donate_date
	,	donate_id
	,	amount
	,	donate_code
	,	pay_code
	,	memo
	,	book_id
	,	create_date
	,	create_by
	,	update_date
	,	update_by
	,	row_status
	,	donate_year
)
 Values 
(	
		@regdate
	,	@donateid
	,	@amount
	,	@donatecode
	,	@paycode
	,	@memo
	,	@book_id
	,	@now
	,	@username
	,	@now
	,	@username
	,	'C'
	,	year(@regdate)
)


	If (@@error !=0 )
	Begin

		set @frk_n4ErrorCode = -1;
		set @frk_strErrorText = 'An error occurred while inserting the data into the table "[dbo].[Donate]"';
		Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

	END

Select 
		@newlastchanged = lastchanged
	,	@newid=[no] 
From donates 
Where [no] = @@identity





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
/****** Object:  StoredProcedure [app_donate].[donate_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_donate].[donate_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@amount					money	=	0
,	@donatecode				int		=	0
,	@paycode				tinyint			=	0
,	@memo					nvarchar(250)	=	null
,	@username				nvarchar(150)	=	null
,	@id						int		
,	@lastchanged			timestamp 
,	@newlastchanged			timestamp	OUTPUT
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

			 Update  dbo.donates 
				Set
					amount		=	@amount
				,	donate_code	=	@donatecode
				,	pay_code	=	@paycode
				,	memo		=	@memo	
				,	update_date	=	@now
				,	update_by	=	@username
				,	row_status	=	'U'
				Where
					[no] = @id
				ANd lastchanged = @lastchanged

			Select 
					@newlastchanged = lastchanged 
			From donates 
			Where [no] = @id





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
/****** Object:  StoredProcedure [app_donate].[donatebook_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_donate].[donatebook_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id					int			
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
			b.*
		,	(	Select [name] From donate_types Where code=b.donate_code) as typename 
	From donate_books as b  
	Where id =@id 
	
	Select 
			d.[no]
		,	d.donate_date
		,	d.amount
		,	d.pay_code
		,	d.memo
		,	d.lastchanged
		,	d.donate_id
		,	d.donate_code
		,	c.[name]
		,	c.member_id as memberid
	From donates as d  
		Inner Join donate_members as c 
		On c.id = d.donate_id  
	Where book_id =@id

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
/****** Object:  StoredProcedure [app_donate].[donatebook_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_donate].[donatebook_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@userid			int					=	0
,	@username	    nvarchar(150)		=	null
,	@total			money	=	0
,	@detail			nvarchar(250)	= null
,	@regdate		datetime	=	null
,	@donate_code	int		=	0
,	@hundred		int		=	0
,	@fifty			int		=	0
,	@twenty			int		=	0
,	@ten			int		=	0
,	@five			int		=	0
,	@one			int		=	0
,	@coins			money	=	0
,	@checkCnt		int		=	0
,	@checks			money	=	0
,	@newid			int OUTPUT
,	@newlastchanged	timestamp OUTPUT
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


Insert INTO 
	dbo.donate_books
	(
			userid	 
		,	total
		,	detail
		,	regdate
		,	donate_code
		,	hundred
		,	fifty
		,	twenty 
		,	ten
		,	five 
		,	one 
		,	coins
		,	checks
		,	check_count
		,   create_by 
		,   create_date
		,	update_by
		,	update_date 
	)
	Values
	(
			@userid
		,	@total
		,	@detail
		,	@regdate
		,	@donate_code
		,	@hundred
		,	@fifty
		,	@twenty
		,	@ten
		,	@five
		,	@one
		,	@coins
		,	@checks
		,	@checkCnt
		,	@username
		,	@now
		,	@username
		,	@now	
	)

	If (@@error <> 0 )
	Begin

		set @frk_n4ErrorCode = -1;
		set @frk_strErrorText = 'An error occurred while inserting the data into the table "[dbo].[Donatebook]"';
		Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

	END
	Select 
			@newid = id 
		,	@newlastchanged =lastchanged 
		From 
			donate_books 
		Where 
			id	=	@@identity



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
/****** Object:  StoredProcedure [app_donate].[donatebook_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_donate].[donatebook_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@userid					int		= 0
,	@startdate				datetime = null
,	@enddate				datetime = null
,	@donatetype				int = 0
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
	SELECT 
			id
		,	username = (Select username From users_master Where id =d.userid)
		,	d.total
		,	c.typename as donatename
		,	d.regdate 
	From donate_books as d 
		Inner Join  dbo.ufdonatetype_get(@donatetype) c
		ON c.code=d.donate_code  
	Where
		d.userid = Case When @userid <> 0 Then @userid Else d.userid End
	And	d.regdate >= Case When @startdate is not null Then @startdate Else '1900-1-1' End
	And d.regdate <= Case When @enddate is not null Then @enddate Else GetDate() End



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
/****** Object:  StoredProcedure [app_donate].[donatebook_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_donate].[donatebook_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id				int
,	@total			money	=	0
,	@detail			nvarchar(250)	= null
,	@regdate		datetime	=	null
,	@donate_code	int		=	0
,	@hundred		int		=	0
,	@fifty			int		=	0
,	@twenty			int		=	0
,	@ten			int		=	0
,	@five			int		=	0
,	@one			int		=	0
,	@checkCnt		int		=	0
,	@coins			money	=	0
,	@checks			money	=	0
,	@username		nvarchar(150)	=	null
,	@lastchanged	timestamp 
,	@newlastchanged	timestamp OUTPUT
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
	
   UPdate 
	dbo.donate_books
	Set 
			total	=	@total
		,	detail	=	@detail
		,	regdate	=	@regdate
		,	donate_code	=	@donate_code
		,	hundred	=	@hundred
		,	fifty	=	@fifty
		,	twenty	=	@twenty
		,	ten		=	@ten
		,	five	=	@five
		,	one		=	@one
		,	coins	=	@coins
		,	checks	=	@checks
		,	check_count	= @checkCnt
		,	update_by	=	@username
		,	update_date		=	@now
	Where 
		id = @id 
		and lastchanged = @lastchanged
		

	Select 
			@newlastchanged =lastchanged 
		From 
			donate_books 
		Where 
			id	=	@id



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
/****** Object:  StoredProcedure [app_donate].[donatemember_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_donate].[donatemember_delete] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@id						int				=	0
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
	Declare @memberid int 
	Select 
		@memberid = isnull(member_id , 0) 
		From
			dbo.donate_members
		Where 
			id = @id
	If (@memberid >10000)
		Begin
		Set @frk_n4ErrorCode = -1
		Set @frk_strErrorText ='Not authorized to delete member'
		Raiserror(@frk_strErrorText,11,1)
		End

	if	Exists ( Select [no] from dbo.donates where donate_id = @id)
		Begin
		Set @frk_n4ErrorCode = -1
		Set @frk_strErrorText ='Not authorized to delete member'
		Raiserror(@frk_strErrorText,11,1)
		End
			
			Update	dbo.donate_members 
			set	
					row_status  = 'D'
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
/****** Object:  StoredProcedure [app_donate].[donatemember_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_donate].[donatemember_get] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@id				int			=		0

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
			d.* 
			From dbo.viewDonateMember  d
			Where 
				d.id = @id
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
/****** Object:  StoredProcedure [app_donate].[donatemember_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_donate].[donatemember_insert] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@name					nvarchar(150)	=	null
,	@enFirstName			nvarchar(150)	=	null
,	@enLastName				nvarchar(150)	=	null	
,	@addressid				int				=	0
,	@memo					nvarchar(255)	=	null
,	@regdate				datetime		=	null
,	@newlastchanged			timestamp	OUTPUT
,	@newid					int			OUTPUT
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

	Insert into dbo.donate_members 
	(	
			[name]
		,	en_first
		,	en_last
		,	address_id
		,	memo
		,	regdate
		,	row_status
	)
	Values 
	(	
			@name
		,	@enFirstName 
		,	@enLastName
		,	@addressid
		,	@memo
		,	@regdate
		,	'C'
	)

	Select 
		@newid = id 
	,	@newlastchanged = lastchanged 
	From 
		dbo.donate_members 
	Where id =@@identity

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
/****** Object:  StoredProcedure [app_donate].[donatemember_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_donate].[donatemember_list] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@donateid				int			=	0
,	@memberid				int			=		0
,	@name					nvarchar(250)	=	null
,	@enName					nvarchar(250)	=	null
,	@enFirstName			nvarchar(250)	=	null
,	@enLastName				nvarchar(250)	=	null
,	@address				nvarchar(250)	=	null
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
			d.* 
			From dbo.viewDonateMember  d
			
			Where 
					d.id = Case When @donateid <> 0 Then @donateid else d.id End
			 And	isnull(d.member_id,0) = Case When @memberid <> 0 Then @memberid else isnull(d.member_id,0) End
			 And	d.name	like Case When @name is not null Then @name + '%' Else d.name End
			 And	d.en_name like Case When @enName is not Null Then @enName + '%'	Else d.en_name End
			 And	d.en_first like Case When @enFirstName is not null Then @enFirstName +'%' Else d.en_first End
		     And	d.en_last like Case When @enLastName is not null Then @enLastName + '%' Else d.en_last End
			 And	d.address like Case When @address is not null Then @address + '%' Else d.address End

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
/****** Object:  StoredProcedure [app_donate].[donatemember_merge]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE  PROCEDURE [app_donate].[donatemember_merge]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@list				nvarchar(Max)	=	null
,	@donateid						int		= 0
,	@username			nvarchar(150)	=	null
,	@roweffect			int			OUTPUT

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
			Select  b.IntKey  from dbo.CommaListToTable(@list) as b   



		Update a
			Set
				a.donate_id = @donateid
			,	a.oldid = b.IntKey
			,	a.update_by = @username
			,	a.update_date = GETDATE()
		From
			dbo.donates a
		Inner Join 
			dbo.CommaListToTable(@list) as b   
		On
			a.donate_id = b.IntKey

		Set @roweffect = @@ROWCOUNT



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
/****** Object:  StoredProcedure [app_donate].[donatemember_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_donate].[donatemember_update] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@id						int				=	0
,	@name					nvarchar(150)	=	null
,	@enFirstName				nvarchar(150)	=	null
,	@enLastName				nvarchar(150)	=	null	
,	@addressid				int				=	0
,	@memberid				int				=	0
,	@memo					nvarchar(255)	=	null
,	@regdate				datetime		=	null
,	@lastchanged			timestamp		=	null
,	@newlastchanged			timestamp			OUTPUT
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

			Update	dbo.donate_members 
			set	
					[name]	= @name
				,	en_first	=	@enFirstName 
				,	en_last		=	@enLastName
				,	address_id	=	@addressid
				,	memo		=	@memo
				,	row_status  = 'U'
			Where
					id = @id
				And	lastchanged = @lastchanged
    
			if (@memberid <>0)
			Begin 
				Update  dbo.members
				Set
						en_first_name	= @enFirstName
					,	en_last_name	= @enLastName
				Where 
					  id = @memberid
			End


			Select  
				@newlastchanged = lastchanged 
			From 
				dbo.donate_members 
			Where id =@id

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
/****** Object:  StoredProcedure [app_donate].[donatetype_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_donate].[donatetype_delete]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@code					int			
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


	Update donate_types
		Set
			[status] = 0
		Where 
			code = @code
			
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
/****** Object:  StoredProcedure [app_donate].[donatetype_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_donate].[donatetype_get] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0

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

	Select *
		From dbo.donate_types
		
		

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
/****** Object:  StoredProcedure [app_donate].[donatetype_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_donate].[donatetype_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@parentcode				int				=	0	
,	@name					nvarchar(150)	=	null
,	@status					bit				=	1
,	@newlastchanged			timestamp	OUTPUT
,	@newid					int			OUTPUT
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

If not Exists 
	(
		Select code 
			From donate_types 
			Where [name]=@name 
				And parent_code = @parentcode)
Begin 
	
	Insert Into donate_types
		(
				parent_code
			,	name
			,	[status]
		)
		Values
		(
				@parentcode
			,	@name
			,	@status
		)

  
		Select
				@newid = code
			,	@newlastchanged = lastchanged
		From
			donate_types
		where
			code = @@IDENTITY
End
Else
Begin
	Update donate_types
		Set
		 [status] = @status
		 Where [name]=@name 
				And parent_code = @parentcode

	Select 
				@newid = code
			,	@newlastchanged = lastchanged
		From
			donate_types
		 Where [name]=@name 
				And parent_code = @parentcode
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
		Insert  dbo.db_error_log
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
/****** Object:  StoredProcedure [app_donate].[donatetype_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_donate].[donatetype_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@root					int		= 0
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

	Select *
		From
        dbo.ufdonatetype_get(@root)
		Order By parentcode ASC, typename ASC
	
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
/****** Object:  StoredProcedure [app_donate].[donatetype_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_donate].[donatetype_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@parentcode				int				=	0	
,	@name					nvarchar(150)	=	null
,	@status					bit				=	1
,	@lastchanged			timestamp	
,	@code					int			
,	@newlastchanged			timestamp		OUTPUT
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


	Update donate_types
		Set
			[status] = @status
		 ,	[name]=@name 
		 ,	parent_code = @parentcode
		Where 
				code = @code
			And	lastchanged = @lastchanged

	Select 
		@newlastchanged = lastchanged
		From
			donate_types
		 Where  code = @code

	
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
/****** Object:  StoredProcedure [app_donate].[memberdonate_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_donate].[memberdonate_list] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@fellowship				int = 0 
,	@memberid				int = 0
,	@membertype				int = 0 
,	@year					int = 0
,	@from					datetime	=	null
,	@to						datetime	=	null
,	@name					nvarchar(150)	=	null
,	@enLastName				nvarchar(150)	=	null
,	@enFirstName			nvarchar(150)	=	null
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
				f.donate_id
			,	d.member_id
			,	d.address
			,	d.city
			,	d.statecode
			,	d.zipcode
			,	d.spousename
			,	d.spouse
			,	d.name
			,	d.en_first
			,	d.en_last
			,	u.parentcode
			,	a.fellowship
			,	f.Total
			From dbo.viewDonateMember  d
			inner join
			(	
				Select 
						Sum(Amount) as Total
					,	donate_id 
					,	donate_code 
					From	
						donates  
						Where 
							donate_date >= case when @from is not null Then @from Else '1900-01-01' END  
						AND donate_date <= Case When @to is not null Then @to Else GetDate() END
						AND donate_year = Case When @year = 0 Then donate_year else @year END
						Group By
						 donate_id , donate_code
			) f
			ON f.donate_id = d.id
			Inner join uffellowship_get(@fellowship) a
			On a.code = isnull(d.fellowship_code,0) 
			Inner join ufdonatetype_get(0) u
			ON u.code = f.donate_code
		Where 
			isnull(d.member_id,0) = Case When @memberid <> 0 Then @memberid Else isnull(d.member_id,0) End
		And	d.membertype = Case @membertype When 1  Then 'I' When 2 Then 'M' Else  d.membertype End
		AND	isnull(d.name,'') Like Case When @name is not null Then @name + '%' Else isnull(d.name,'') End
		AND	isnull(d.en_first,'') Like Case When @enFirstName is not null Then @enFirstName + '%' Else isnull(d.en_first,'') End
		AND	isnull(d.en_last,'') Like Case When @enLastName is not null Then @enLastName + '%' Else isnull(d.en_last,'') End
	
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
/****** Object:  StoredProcedure [app_donate].[recode_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_donate].[recode_get] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@donateid				int =	0
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
				d.donate_date
			,	d.amount
			,	d.pay_code
			,	d.memo
			,	d.donate_year
		From
			dbo.donates d
		Inner Join 
			dbo.donate_types a
		On
			d.donate_id = a.code
		Where
			donate_id = @donateid

			
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
/****** Object:  StoredProcedure [app_donate].[recorder_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_donate].[recorder_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
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
				c.[username]
			,	c.[id] 
			From 
				users_master as c 
			inner join 
			(
				Select 
					userid 
				From 
					donate_books 
				group by userid
			) as d  
			ON 
				d.userid = c.id
		

	
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
/****** Object:  StoredProcedure [app_donate].[yearlist_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_donate].[yearlist_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
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


	 Select	distinct ( Year(donate_date)) as donate_year
		From dbo.donates 
		Order by donate_year ASC
	
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
/****** Object:  StoredProcedure [app_fellowship].[fellowship_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_fellowship].[fellowship_delete]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@id						int				=	0
,	@username				nvarchar(150)	=	null
)WITH EXECUTE AS Self
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

	Update
		dbo.fellowship
		Set	
			update_by	=  @username
		,	update_date	=  GetDate()
		,	row_status	=	'D'
		Where
				code = @id
	
	
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
/****** Object:  StoredProcedure [app_fellowship].[fellowship_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_fellowship].[fellowship_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
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

	Select *
		From
		dbo.fellowship
		Where
		row_status  <> 'D'
	
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
/****** Object:  StoredProcedure [app_fellowship].[fellowship_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_fellowship].[fellowship_insert]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@parentid				int				=	0	
,	@name					nvarchar(150)	=	null
,	@username		        nvarchar(150)	=	null
,	@newlastchanged			timestamp	OUTPUT
,	@newid						int			OUTPUT
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

	Insert Into dbo.fellowship
		(
				parent_code
			,	name
			,	create_by
			,	create_date
			,	update_by
			,	update_date
			,	row_status
		)
		Values
		(
				@parentid
			,	@name
			,	@username
			,	GETDATE()
			,	@username
			,	GETDATE()
			,	'C'
		)


  
		Select
				@newid = code
			,	@newlastchanged = lastchanged
		From
			dbo.fellowship
		where
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
/****** Object:  StoredProcedure [app_fellowship].[fellowship_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_fellowship].[fellowship_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
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

	Select *
		From
        dbo.uffellowship_get(0)
		Order By sort ASC
	
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
/****** Object:  StoredProcedure [app_fellowship].[fellowship_member_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_fellowship].[fellowship_member_delete]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id						int				= 0
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

	    Update dbo.member_fellowship 
			Set 
					enddate = GetDate()
				,	update_by = @username
				,	update_date = GetDate()
			Where
				id = @id 


       Update
				d
			Set
					d.FellowshipCode = 0
				,	d.FellowshipName = ''
				,	d.FellowshipStartdate = GetDate()
			From
				dbo.member_details d
				inner join dbo.member_fellowship m
				On d.MemberId = m.memberid
			Where 
				m.id =@id 

			


	
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
/****** Object:  StoredProcedure [app_fellowship].[fellowship_member_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_fellowship].[fellowship_member_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@code		int = 0
,	@withHistory	bit	=	0
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
		f.id
	,	f.fellowship_code
	,	f.enddate
	,	f.startdate
	,	f.memberid
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
	,	f.update_by
	,	f.lastchanged
	 From	dbo.uffellowship_get(@code) c 
		Inner Join  member_fellowship f
		On f.fellowship_code = c.code
		Inner Join memberview m
		On f.memberid = m.id   
	 Where  
		 f.enddate is null    
	 And
		f.row_status <> 'D'
	 Order by c.fellowship asc
	End
	Else
	Begin
	Select 
		f.id
	,	f.fellowship_code
	,	f.enddate
	,	f.startdate
	,	f.memberid
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
	,	f.lastchanged
	 From	dbo.uffellowship_get(@code) c 
		Inner Join  member_fellowship f
		On f.fellowship_code = c.code
		Inner Join memberview m
		On f.memberid = m.id   
	 Where  
				isnull (f.enddate, @now) >= Case When @from is not null Then  @from Else '1900-1-1' End
		And		isnull (f.enddate, @now) <= Case When @to is not null Then  @to Else  @now End
		And 	f.row_status <> 'D'
	 Order by c.fellowship asc
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
/****** Object:  StoredProcedure [app_fellowship].[fellowship_member_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_fellowship].[fellowship_member_insert]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@fellowshipCode			int				= 0
,	@memberId				int				= 0
,	@startDate				Datetime		=	null
,	@username				nvarchar(150)	=	null
,	@newlastchanged			timestamp	OUTPUT
,	@newid					int			OUTPUT
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

	    Update dbo.member_fellowship 
			Set 
					enddate = @startDate
				,	update_by = @username
				,	update_date = GetDate()
				,	row_status = 'U'
			Where
				memberid = @memberId
			and enddate is null 

		Insert Into dbo.member_fellowship
		(
				fellowship_code
			,	memberid
			,	startdate
			,	update_by
			,	update_date
			,	row_status
		)
		Values
		(
				@fellowshipCode
			,	@memberId
			,	@startDate
			,	@username
			,	GetDate()
			,	'C'
		)
  
		

       Update
				dbo.member_details
			Set
					FellowshipCode = @fellowshipCode
				,	FellowshipName = Isnull((Select name from dbo.fellowship Where code = @fellowshipCode), '')
				,	FellowshipStartdate = @startDate
			Where
				MemberId = @memberId 
	    
		Select
				@newid = id
			,	@newlastchanged = lastchanged
		From
			dbo.member_fellowship
		where
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
/****** Object:  StoredProcedure [app_fellowship].[fellowship_member_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_fellowship].[fellowship_member_update]
(
	@frk_n4ErrorCode		int				= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id						int				=	0
,	@startDate				datetime		=	null
,	@endDate				datetime		=	null
,	@username				nvarchar(150)	=	null
,	@lastchanged			timestamp		=	null
,	@newlastchanged			timestamp		=	null	OUTPUT
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

	    Update dbo.member_fellowship 
			Set 
					startdate	=	@startDate
				,	enddate		=	@endDate
				,	update_by	=	@username
				,	update_date =	GetDate()
				,	row_status	=	'U'
			Where
				id =	@id
			And	lastchanged	= @lastchanged
				
		

		Select
				@newlastchanged = lastchanged
		From
			dbo.member_fellowship
		where
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
/****** Object:  StoredProcedure [app_fellowship].[fellowship_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_fellowship].[fellowship_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id						int				=0
,	@parentid				int				=	0	
,	@name					nvarchar(150)	=	null
,	@username				nvarchar(150)	=	null
,	@lastchanged			timestamp	
,	@newlastchanged			timestamp	OUTPUT
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

	Update
		dbo.fellowship
		Set
				parent_code = @parentid 
			,	name	=	@name
			,	update_by	= @username
			,	update_date = GetDate()
			,	row_status = 'U'
		Where
				code = @id
			And	lastchanged = @lastchanged
  
		Select
				@newlastchanged = lastchanged
		From
			dbo.fellowship
		where
			code = @id
			


	
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
/****** Object:  StoredProcedure [app_fellowship].[member_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [app_fellowship].[member_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@memberid				int		=	0
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
			b.id
		,	a.name as fellowship
		,	b.startdate
		,	b.enddate
		From
		dbo.fellowship a
		Inner Join
			dbo.member_fellowship b
		On
			a.code = b.fellowship_code
		Where
			b.row_status <>'D'
			And 
			b.memberid = @memberid
	
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
/****** Object:  StoredProcedure [app_member].[cell_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_member].[cell_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@memberid			int		=	0
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
			c.*
			From 
			[dbo].[member_cell] c
			Where
				c.memberid = @memberid
			And
				c.row_status <>'D'
			Order By
				c.enddate Desc	

	
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
/****** Object:  StoredProcedure [app_member].[comment_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_member].[comment_delete] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@id						int
,	@username				varchar(150)

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
	Declare @now	datetime
	Set @now = GetDate()
		
		
	Update
		 [dbo].[comments]
        Set
			update_by	=	@username
        ,	update_date	=	@now
        ,	row_status	=	'D'
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
/****** Object:  StoredProcedure [app_member].[comment_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_member].[comment_insert] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@comment				ntext		=	null
,	@memberid				int
,	@username				varchar(150)
,	@newlastchanged			timestamp	OUTPUT
,	@newid					int			OUTPUT
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
	Declare @now	datetime
	Set @now = GetDate()
		

INSERT INTO [dbo].[comments]
           (
			[comment]
           ,[regdate]
           ,[memberid]
           ,[create_by]
           ,[create_date]
           ,[update_by]
           ,[update_date]
           ,[row_status]
	)
	Select
			@comment			[comment]
           ,@now				[regdate]
           ,@memberid			[memberid]
           ,@now				[create_date]
           ,@username			[create_by]
           ,@now				[update_date]
           ,@username			[update_by]
		   ,'C'					[row_status]
	

	Select 
		@newid = id 
	,	@newlastchanged = lastchanged 
	From 
		[dbo].[comments]
	Where id =@@identity

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
/****** Object:  StoredProcedure [app_member].[comment_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_member].[comment_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0		
,	@memberid						int	
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
			c.*
		From 
			dbo.comments c
		Where 
			c.memberid = @memberid 
		Order By
			update_date DESC
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
/****** Object:  StoredProcedure [app_member].[comment_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_member].[comment_update] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@id						int
,	@comment				ntext		=	null
,	@username				varchar(150)
,	@lastchanged			timestamp	
,	@newlastchanged			timestamp	OUTPUT
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
	Declare @now	datetime
	Set @now = GetDate()
		
		
	Update
		 [dbo].[comments]
        Set
			comment		=	@comment
		,	update_by	=	@username
        ,	update_date	=	@now
        ,	row_status	=	'U'
		Where 
				id = @id	
		And		lastchanged = @lastchanged
	
	Select 	
		@newlastchanged = lastchanged 
	From 
		[dbo].[comments]
	Where id =@id

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
/****** Object:  StoredProcedure [app_member].[family_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [app_member].[family_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0		
,	@memberid						int	
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
		Declare @family_code int
		
		Select @now =GetDate() 
		Select @family_code = family_code  From dbo.members Where id = @memberid

		Select 
					m.id
				,	m.last_name
				,	m.first_name
				,	m.en_first_name
				,	m.en_last_name
				,	m.email
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
				,	m.family_relationship
				,	m.family_code
				,	m.family_name
				,	m.status_date
				,	m.Relationship
				,	m.StatusCode
				,	(Select a.name From dbo.type_status a where a.id = m.StatusCode) as StatusName
				,	s.name as SubDivisionName
				,	spousename
				,	spouse
				,	m.active
			From 
				memberview m 
			inner join dbo.ufsubDivision_get(0) s
			on s.id = ISNULL(m.subdiv_id,0)
	
			Where 
				m.family_code =  @family_code
			Order by 
				m.family_relationship ASC
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
/****** Object:  StoredProcedure [app_member].[member_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [app_member].[member_delete]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0		
,	@memberlist					ntext = null	
,	@username					nvarchar(150) = null
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
		Delete a 
			From 
				dbo.member_details a
			Inner Join
				dbo.CommaListToTable(@memberlist) b
			On
				b.IntKey = a.MemberId
		
		Update  a 
		Set
			row_status = 'D'
		,	update_by = @username
		,	update_date = GETDATE()
			From 
				dbo.comments a
			Inner Join
				dbo.CommaListToTable(@memberlist) b
			On
				b.IntKey = a.MemberId
			
		Delete a 
			From 
				dbo.member_cell a
			Inner Join
				dbo.CommaListToTable(@memberlist) b
			On
				b.IntKey = a.MemberId

		Update  a 
		Set
			row_status = 'D'
		,	update_by = @username
		,	update_date = GETDATE()
			From 
				dbo.member_fellowship a
			Inner Join
				dbo.CommaListToTable(@memberlist) b
			On
				b.IntKey = a.MemberId

		Delete a 
			From 
				dbo.member_ministry a
			Inner Join
				dbo.CommaListToTable(@memberlist) b
			On
				b.IntKey = a.MemberId
		
		Delete a 
			From 
				dbo.member_status a
			Inner Join
				dbo.CommaListToTable(@memberlist) b
			On
				b.IntKey = a.member_id
		Delete a 
			From 
				dbo.status_log a
			Inner Join
				dbo.CommaListToTable(@memberlist) b
			On
				b.IntKey = a.memberid

		Update a 
		Set
				a.update_by = @username
			,	a.update_date = GetDate()
			,	a.active = 0
			,	a.row_status = 'D'
			From 
				dbo.members a
			Inner Join
				dbo.CommaListToTable(@memberlist) b
			On
				b.IntKey = a.id



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
/****** Object:  StoredProcedure [app_member].[member_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


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
		*
		From dbo.members a
		Inner join
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
/****** Object:  StoredProcedure [app_member].[member_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_member].[member_insert] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@first_name				nvarchar(30)	=	null
,	@last_name				nvarchar(20)	=	null
,	@en_first_name			nvarchar(150)	=	null
,	@en_last_name			nvarchar(150)	=	null
,	@email					nvarchar(150)	=	null
,	@cell					nvarchar(15)	=	null
,	@work_phone				nvarchar(25)	=	null
,	@sex					bit				=	0
,	@married				bit				=	0
,	@family_code			int				=	0
,	@family_relationship	int				=	0
,	@birthday				datetime		=	null
,	@regdate				datetime		=	null
,	@address_id				int				=	0
,	@subdiv_id				int				=	0
,	@baptism_id				int				=	0
,	@baptism_year			datetime		=	null
,	@job					nvarchar(150)	=	null
,	@entrytype				int				=	0
,	@jobtype				int				=	0
,	@active					bit				=	0
,	@status					int				=	0
,	@username				varchar(150)	=	null
,	@newlastchanged			timestamp	OUTPUT
,	@newid					int			OUTPUT
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
	Declare @now	datetime
	Set @now = GetDate()
		
INSERT INTO [dbo].[members]
           (
			[first_name]
           ,[last_name]
           ,[en_first_name]
           ,[en_last_name]
           ,[email]
           ,[cell]
           ,[work_phone]
           ,[sex]
           ,[married]
           ,[family_code]
           ,[family_relationship]
           ,[birthday]
           ,[regdate]
           ,[address_id]
           ,[subdiv_id]
           ,[baptism_id]
           ,[baptism_year]
           ,[job]
           ,[entrytype]
           ,[jobtype]
           ,[active]
           ,[create_date]
           ,[create_by]
           ,[update_date]
           ,[update_by]
	)
	Select
			@first_name					[first_name]
           ,@last_name					[last_name]
           ,@en_first_name				[en_first_name]
           ,@en_last_name				[en_last_name]
           ,@email						[email]
           ,@cell						[cell]
           ,@work_phone					[work_phone]
           ,@sex						[sex]
           ,@married					[married]
           ,@family_code				[family_code]
           ,@family_relationship		[family_relationship]
           ,@birthday					[birthday]
           ,@regdate					[regdate]
           ,@address_id					[address_id]
           ,@subdiv_id					[subdiv_id]
           ,@baptism_id					[baptism_id]
           ,@baptism_year				[baptism_year]
           ,@job						[job]
           ,@entrytype					[entrytype]
           ,@jobtype					[jobtype]
           ,@active						[active]
           ,@now						[create_date]
           ,@username					[create_by]
           ,@now						[update_date]
           ,@username					[update_by]
	
	
	Insert into dbo.member_status
		(
			member_id
		,	status_code
		,	update_by
		,	update_date
		)
	Values
	(
			@@identity
		 ,	@status
		 ,	@username
		 ,	@now
	) 

	If(@family_code = 0 )
	Begin
		Update dbo.members
		Set
			family_code = @@identity
		,	family_relationship = 0
		Where
			id  = @@identity
	END

	Select 
			@newid = id
		,	@newlastchanged	= lastchanged
		From
			dbo.members
		Where
			id = @@identity
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
/****** Object:  StoredProcedure [app_member].[member_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [app_member].[member_list]
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
		,	m.status_date
		,	m.Relationship
		,	m.StatusCode
		,	(Select a.name From dbo.type_status a where a.id = m.StatusCode) as StatusName
		,	s.name as SubDivisionName
		,	spousename
		,	spouse
		,	m.active
	From 
		memberview m Inner join  dbo.uffellowship_get(@fellowship) f
	on f.code = ISNULL( m.fellowship_code,0)
	inner join dbo.ufsubDivision_get(@subDivision) s
	on s.id = ISNULL(m.subdiv_id,0)

	Where	
			m.id = Case When @memberid <> 0 Then @memberid Else m.id End
		And (ltrim(rtrim(m.last_name))+ltrim(rtrim(m.first_name))) like Case When LEN(ltrim(rtrim(@fullname))) > 0 Then @fullname + '%' Else  (ltrim(rtrim(m.last_name))+ltrim(rtrim(m.first_name)))  End
	--	And	m.first_name like Case When @firstName is not null Then @firstName +'%' Else m.first_name End
		And m.last_name like Case When @lastName is not null Then ltrim(rtrim(@lastName)) + '%' Else m.last_name End
		And isnull(m.en_first_name,'') like Case When @enFirstName is not null Then @enFirstName +'%' Else isnull(m.en_first_name,'')End
		And isnull(m.en_last_name,'') like Case When @enLastName is not null Then @enLastName + '%' Else isnull(m.en_last_name,'') End
		And isnull(m.cell,'') like Case When @cellPhone is not null Then @cellPhone +'%' Else isnull(m.cell,'') End
		And isnull(m.home,'') like Case When @home is not null Then @home + '%' Else isnull(m.home,'') End
		And m.family_relationship = Case When @relationship <> 0 then @relationship Else m.family_relationship End
		And	m.married = Case When @married <> -1 Then @married Else m.married End
		And m.sex	=	Case When @sex <> -1 Then @sex	Else m.sex End
		ANd	isnull(m.jobtype,0)	=	Case When @jobtype <> 0 Then @jobtype Else isnull(m.jobtype,0) End
		And isnull(m.city,'')	like	 Case When @city is not null Then @city+'%' Else isnull(m.city,'') End
	  	And isnull(m.statecode,'') like  Case When @state is not null Then @state+'%' Else isnull(m.statecode,'') End
		And m.regdate >= isnull(@regfrom , '1900-01-01')
		And m.regdate <= isnull(@regto, @now)
		And m.birthday >= isnull(@birthfrom, '1900-01-01')
		And m.birthday <= isnull(@birthto, @now)
		And m.StatusCode = Case When @status <> 0 then @status Else m.StatusCode End
		And dbo.GetAge(m.birthday , @now) >= @agefrom
		And dbo.GetAge(m.birthday , @now) <= Case When @ageto <> 0 Then @ageto else 200 End	
		And m.active = Case When @active <> -1 then @active Else m.active End 
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
		memberview m Inner join  dbo.uffellowship_get(@fellowship) f
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
		And m.family_relationship = Case When @relationship <> 0 then @relationship Else m.family_relationship End
		And	m.married = Case When @married <> -1 Then @married Else m.married End
		And m.sex	=	Case When @sex <> -1 Then @sex	Else m.sex End
		ANd	isnull(m.jobtype,0)	=	Case When @jobtype <> 0 Then @jobtype Else isnull(m.jobtype,0) End
		And isnull(m.city,'')	like	 Case When @city is not null Then @city+'%' Else isnull(m.city,'') End
	  	And isnull(m.statecode,'') like  Case When @state is not null Then @state+'%' Else isnull(m.statecode,'') End
		And m.regdate >= isnull(@regfrom , '1900-01-01')
		And m.regdate <= isnull(@regto, @now)
		And m.birthday >= isnull(@birthfrom, '1900-01-01')
		And m.birthday <= isnull(@birthto, @now)
		And Isnull( m.baptism_year ,@baptismNull) >= isnull (@baptismFrom,'1900-01-01') 
		And Isnull( m.baptism_year ,@baptismNull) <= isnull (@baptismTo,@now) 
		And dbo.GetAge(m.birthday , @now) >= @agefrom
		And dbo.GetAge(m.birthday , @now) <= Case When @ageto <> 0 Then @ageto else 200 End	
		And m.StatusCode = Case When @status <> 0 then @status Else m.StatusCode End
		And m.active = Case When @active <> -1 then @active Else m.active End 

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
/****** Object:  StoredProcedure [app_member].[member_list_by_memberid_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [app_member].[member_list_by_memberid_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0	
,	@memberlist					nvarchar(max)	=	null	

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
		,	m.status_date
		,	m.Relationship
		,	m.StatusCode
		,	(Select a.name From dbo.type_status a where a.id = m.StatusCode) as StatusName
		,	s.name as SubDivisionName
		,	m.spousename
		,	m.spouse
		,	m.active
	From 
		memberview m 
		Inner Join dbo.ufsubDivision_get(0) s
		On s.id = m.subdiv_id 
		Inner Join 
		[dbo].[CommaListToTable](@memberlist)  as b 
		On b.IntKey = m.id 
	Order by b.counter 
		
			
		

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
/****** Object:  StoredProcedure [app_member].[member_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_member].[member_update] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0

,	@id						int
,	@first_name				nvarchar(30)	=	null
,	@last_name				nvarchar(20)	=	null
,	@en_first_name			nvarchar(150)	=	null
,	@en_last_name			nvarchar(150)	=	null
,	@email					nvarchar(150)	=	null
,	@cell					nvarchar(15)	=	null
,	@work_phone				nvarchar(25)	=	null
,	@sex					bit				
,	@married				bit
,	@family_code			int
,	@family_relationship	int
,	@birthday				datetime		=	null
,	@regdate				datetime		=	null
,	@address_id				int
,	@subdiv_id				int
,	@baptism_id				int
,	@baptism_year			datetime
,	@job					nvarchar(150)	=	null
,	@entrytype				int
,	@jobtype				int
,	@active					bit
,	@username				varchar(150)	=	null
,	@lastchanged			timestamp	
,	@newlastchanged			timestamp	OUTPUT
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
	Declare @now	datetime
	Set @now = GetDate()
		
	Update [dbo].[members]
         Set
			[first_name]	=	@first_name
           ,[last_name]		=	@last_name
           ,[en_first_name]	=	@en_first_name
           ,[en_last_name]	=	@en_last_name
           ,[email]			=	@email
           ,[cell]			=	@cell
           ,[work_phone]	=	@work_phone
           ,[sex]			=	@sex
           ,[married]		=	@married
           ,[family_code]	=	@family_code
           ,[family_relationship]	=	@family_relationship
           ,[birthday]		=	@birthday
           ,[regdate]		=	@regdate
           ,[address_id]	=	@address_id
           ,[subdiv_id]		=	@subdiv_id
           ,[baptism_id]	=	@baptism_id
           ,[baptism_year]	=	@baptism_year
           ,[job]			=	@job
           ,[entrytype]		=	@entrytype
           ,[jobtype]		=	@jobtype
           ,[active]		=	@active
           ,[update_date]	=	@now
           ,[update_by]		=	@username
		Where
				id = @id 
		And		lastchanged	= @lastchanged

	Select
		@newlastchanged = lastchanged 
	From 
		dbo.members 
	Where id =@id

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
/****** Object:  StoredProcedure [app_member].[status_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_member].[status_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@from			datetime	= null
,	@to				datetime	= null
,	@statuslist     nvarchar(max)	= null
,	@onlyfamily		bit			=	0		
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

	If( @statuslist is null  )
		Begin
		Select 
				a.id
			,	a.memberid
			,	a.memo
			,	a.regdate
			,	c.first_name
			,	c.last_name
			,	c.address
			,	c.city
			,	c.zipcode
			,	c.statecode
			,	c.FellowshipName
			,	c.CellName
			,	c.SubDivisionName
			,	c.home
			,	b.name
			,	c.regdate as entrydate	
			From 
				dbo.memberview c
			inner Join 
				dbo.status_log a
			On
				a.memberid = c.id
			Inner Join
				dbo.type_status b
			On
				b.id = a.statusid
			Where
				a.regdate >= isnull(@from , '1900-01-01') 
				And
				a.regdate <= isnull( @to,GetDate() )
				And
			    c.family_relationship = Case When @onlyfamily = 1 Then 0 Else c.family_relationship End
		End
	Else
		Begin

		Select 
				a.id
			,	a.memberid
			,	a.memo
			,	a.regdate
			,	c.first_name
			,	c.last_name
			,	c.address
			,	c.city
			,	c.zipcode
			,	c.statecode
			,	c.FellowshipName
			,	c.CellName
			,	c.SubDivisionName
			,	c.home
			,	b.name
			,	c.regdate as entrydate	
			From 
				dbo.memberview c
			inner Join 
				dbo.status_log a
			On
				a.memberid = c.id
			Inner Join
				dbo.type_status b
			On
				b.id = a.statusid
			Inner Join 
				dbo.CommaListToTable(@statuslist) f
			On
				f.IntKey = a.statusid
			Where
				a.regdate >= isnull(@from , '1900-01-01') 
				And
				a.regdate <= isnull( @to,GetDate() )
				And
			    c.family_relationship = Case When @onlyfamily = 1 Then 0 Else c.family_relationship End


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
/****** Object:  StoredProcedure [app_member].[status_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [app_member].[status_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0		
,	@memberList					nvarchar(max)	=	null
,	@eventLog					nvarchar(255)	=	null
,	@memo						nvarchar(255)	=	null	
,	@statusId					int
,	@username					varchar(150)	= null
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
	Declare @active bit

	Select @active = is_active
		From
			dbo.type_status
		Where 
			id = @statusId

	Set @now = GetDate()

	Update m	
		Set
			m.active = @active
		From
			members m
			Inner join 
				dbo.CommaListToTable(@memberList) c
			on m.id = c.IntKey


	If(@active = 0)
	Begin
		Update m 
			Set
				m.enddate = @now
			From
				dbo.member_fellowship m
			inner join 
				dbo.CommaListToTable(@memberList) c
			on m.memberid = c.IntKey
			
        Update m 
			Set
				m.enddate = @now
			From
				dbo.member_ministry m
			inner join 
				dbo.CommaListToTable(@memberList) c
			on m.memberid = c.IntKey

		Update m 
			Set
					m.enddate = @now
				,	m.update_date = @now
				,	m.update_by = @username
			From
				dbo.member_cell m
			inner join 
				dbo.CommaListToTable(@memberList) c
			on m.memberid = c.IntKey
		
	End


	 Insert into dbo.status_log
		(	
				memberid
			,	eventlog
			,	memo
			,	regdate
			,	statusid
			,	username
		)
		Select
				IntKey
			,	@eventLog
			,	@memo
			,	@now
			,	@statusId
			,	@username
			From 
				dbo.CommaListToTable(@memberList)		   

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
/****** Object:  StoredProcedure [app_member].[statuslog_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_member].[statuslog_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0		
,	@memberid						int	
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
		* 
		From status_log 
		Where 
			memberid = @memberid 
		Order by regdate desc

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
/****** Object:  StoredProcedure [app_member].[subdivision_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_member].[subdivision_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0		
,	@subDivision					int
,	@memberList						nvarchar(max)	
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

	Update dbo.members
		Set
				subdiv_id	=	@subdivision
		Where 
			id in ( Select intKey From dbo.CommaListToTable(@memberList)) 
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
/****** Object:  StoredProcedure [app_member].[to_get_memberid]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_member].[to_get_memberid]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0		
,   @name					nvarchar(250)
,	@birthday				datetime		= null
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
	Select id
		From dbo.members
	Where 
			Year(birthday) = Year(@birthday)      
		AND Month(birthday) = Month(@birthday)      
		AND Day(birthday) = Day(@birthday)
		and (last_name + first_name) like @name+'%'


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
/****** Object:  StoredProcedure [app_member].[to_splite_member]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_member].[to_splite_member]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0		
,	@memberid				int	=	0
,	@address				int	=	0 
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
					Declare @log nvarchar(max)
					Declare @oldfamilycode int 
					Declare @familyname int


			Select @oldfamilycode = family_code 
				From memberview 
				Where id =@memberid
			
			Select @log =' < ---세대주 분가 이전 세대주 관계 --->    '
			
			select @log = @log + dbo.GetFamilyList(@oldfamilycode)

			Insert into dbo.Comments 
			(
					comment
				,	regdate
				,	memberid
				,	update_by
				,	update_date
			) 
			values 
			( 
					@log
				,	getdate()
				,	@memberid 
				,	@username
				,	GETDATE()	
			)
			
			Update dbo.members 
			 Set 
					family_code			=	@memberid 
				,	family_relationship =	0 
				,	address_id			=	@address 
			Where 
				id = @memberid 



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
/****** Object:  StoredProcedure [app_member].[unassigned_cell_member_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_member].[unassigned_cell_member_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0	
,	@subDivision				int				=	0

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
				,	m.StatusName
				,	m.status_date
				,	m.Relationship
				,	m.StatusCode
				,	m.StatusName
				,	s.name as SubDivisionName
				,	spousename
				,	spouse
				,	m.active
			From 
				memberview m 
			inner join dbo.ufsubDivision_get(@subDivision) s
			on s.id = ISNULL(m.subdiv_id,0)

			Where	
					m.active = 1
			And		isnull(m.cell_code,0) = 0
		


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
/****** Object:  StoredProcedure [app_member].[visit_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_member].[visit_delete]
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
	Declare @now Datetime
	Set @now = GetDate()
	
	Update 
		[dbo].[member_visit]
		Set
				[update_date]	=	@now 
			,	[update_by]		=	@username
			,	[row_status]	=	'D'
		Where
				id	=	@id
			
		If (@@error !=0 )
		Begin

			set @frk_n4ErrorCode = -1;
			set @frk_strErrorText = 'An error occurred while updating the data into the table "[dbo].[member_visit]"';
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
/****** Object:  StoredProcedure [app_member].[visit_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_member].[visit_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id				int		=	0
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
				v.* 
			,	m.first_name
			,	m.last_name
			,	m.family_code
			,	m.address
			,	m.city
			,	m.statecode
			,	m.zipcode
			,	m.cell as cellphone
			,	m.home
			,	m.cell_code
			,	m.CellName
			From
				dbo.member_visit v
			Inner Join dbo.memberview m 
			On v.memberid = m.id
			
			Where
				v.id = @id 
		
	

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
/****** Object:  StoredProcedure [app_member].[visit_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_member].[visit_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@memberId				int		=	0	
,	@visitType				int		=	0
,	@visitDate				datetime	=	null
,	@pastor					nvarchar(150)	=	null
,	@content				nvarchar(max)	=	null
,	@attendent				nvarchar(250)	=	null
,	@bible					nvarchar(50)	=	null
,	@song					nvarchar(50)	=	null
,	@username				nvarchar(150)	=	null
,	@newid			int OUTPUT
,	@newlastchanged	timestamp OUTPUT
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
	
	Insert INTO 
		[dbo].[member_visit]
		(
				[memberid]
			,	[visittype]
			,	[visitdate]
			,	[pastor]
			,	[contents]
			,	[attendent]
			,	[bible]
			,	[song]
			,	[create_date]
			,	[create_by]
			,	[update_date]
			,	[update_by]
			,	[row_status]
	 
		)
		Values
		(
				@memberId
			,	@visitType
			,	@visitDate
			,	@pastor
			,	@content
			,	@attendent
			,	@bible
			,	@song
			,	@now
			,	@username
			,	@now
			,	@username
			,	'C'
		)
			
		If (@@error !=0 )
		Begin

			set @frk_n4ErrorCode = -1;
			set @frk_strErrorText = 'An error occurred while inserting the data into the table "[dbo].[member_visit]"';
			Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

		END

	Select 
			@newid =id 
		,	@newlastchanged		=	lastchanged 
		From 
		
			[dbo].[member_visit]
		Where 
			id	=	@@identity



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
/****** Object:  StoredProcedure [app_member].[visit_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_member].[visit_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@memberid				int		= 0
,	@cellCode				int		=	0
,	@visitType				int		=	0
,	@from					datetime	= null
,	@to						datetime	=	null 
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
	
		Select 
				f.id
			,	f.bible
			,	f.contents
			,	f.pastor
			,	f.memberid
			,	f.song
			,	f.pastor
			,	m.first_name
			,	m.last_name
			,	m.CellName
			,	f.visitdate	
			,	f.visittype
			,	f.attendent
			,	(Select t.name from dbo.type_visit t where t.id = f.visittype) as VisitTypeName
			From (	
			Select *
				From 
					dbo.member_visit v
				Where		
						v.visittype = Case When @visitType != 0 Then @visitType else v.visittype End
					AND	v.create_by = Case When  1 > Len(@username) Then  v.create_by else @username End
					ANd	v.memberid = Case When @memberid != 0 Then @memberid else v.memberid End
					AND v.visitdate >= isnull(@from , '1900-01-01')
					AND v.visitdate <= isnull(@to , GETDATE())
				) f 
				Inner Join dbo.memberview m
				ON m.id = f.memberid
				Inner Join dbo.ufcell_get(@cellCode) c
				On isnull(c.code,0) = isnull(m.cell_code,0)
			Order by visitdate Desc , f.pastor ASC
				
		 
		
	

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
/****** Object:  StoredProcedure [app_member].[visit_list_by_stringlist]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [app_member].[visit_list_by_stringlist]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@list					nvarchar(max)	=	null
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
				f.id
			,	f.bible
			,	f.contents
			,	f.pastor
			,	f.memberid
			,	f.song
			,	f.pastor
			,	m.first_name
			,	m.last_name
			,	m.CellName
			,	f.visitdate	
			,	f.visittype
			,	(Select t.name from dbo.type_visit t where t.id = f.visittype) as VisitTypeName
			From 
			(	
				Select *
					From 
						dbo.member_visit v 
				Inner join
						dbo.CommaListToTable(@list) a
					On 
						v.id = a.IntKey 		
				) f 
				Inner Join dbo.memberview m
				ON m.id = f.memberid
			Order by visitdate Desc , f.pastor ASC
				
		 
		
	

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
/****** Object:  StoredProcedure [app_member].[visit_recoder_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [app_member].[visit_recoder_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0


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
	
		Select distinct create_by 
			From dbo.member_visit 


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
/****** Object:  StoredProcedure [app_member].[visit_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_member].[visit_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id						int		=	0
,	@visitType				int		=	0
,	@visitDate				datetime	=	null
,	@pastor					nvarchar(150)	=	null
,	@content				nvarchar(max)	=	null
,	@attendent				nvarchar(250)	=	null
,	@bible					nvarchar(50)	=	null
,	@song					nvarchar(50)	=	null
,	@username				nvarchar(150)	=	null
,	@lastchanged			timestamp	=	null
,	@newlastchanged			timestamp	=	null OUTPUT
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
	
	Update 
		[dbo].[member_visit]
		Set
				[visittype]		=	@visitType
			,	[visitdate]		=	@visitDate
			,	[pastor]		=	@pastor
			,	[contents]		=	@content
			,	[attendent]		=	@attendent
			,	[bible]			=	@bible
			,	[song]			=	@song
			,	[update_date]	=	@now 
			,	[update_by]		=	@username
			,	[row_status]	=	'U'
		Where
				id	=	@id
			And	lastchanged	=	@lastchanged
			
		If (@@error !=0 )
		Begin

			set @frk_n4ErrorCode = -1;
			set @frk_strErrorText = 'An error occurred while updating the data into the table "[dbo].[member_visit]"';
			Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

		END

	Select 
			@newlastchanged		=	lastchanged 
		From 
		
			[dbo].[member_visit]
		Where 
			id	=	@id



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
/****** Object:  StoredProcedure [app_ministry].[member_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_ministry].[member_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@memberid			int =	0
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

	
	Select 
		f.*

	 From	
		member_ministry f
	 Where  
			f.row_status <> 'D'
		And		f.memberid  = @memberid   

	 Order by f.enddate asc
	

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
/****** Object:  StoredProcedure [app_ministry].[ministry_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_ministry].[ministry_delete]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id					int =	0
,	@username			nvarchar(150)	=	null

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
	
	if Exists ( Select id from dbo.member_ministry where ministry_code =@id)
	Begin 

	Update
		[dbo].[ministry] 
		Set
			update_by	=	@username
		,	update_date	=	@now		
		,	row_status	=	'D'
		Where 
			code = @id 

	End
	Else
	Begin

	Delete From dbo.ministry
	Where code = @id 

	End

	If (@@error !=0 )
	Begin

		set @frk_n4ErrorCode = -1;
		set @frk_strErrorText = 'An error occurred while deleting the data into the table "[dbo].[ministry]"';
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
/****** Object:  StoredProcedure [app_ministry].[ministry_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_ministry].[ministry_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0

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
			code 
		,	parent_code 
		,	name
		,	update_by
		,	row_status
		,	lastchanged
		,	total_assign = (select count(m.id) From dbo.member_ministry m Where m.ministry_code = code and m.enddate is null ) 
		From [dbo].[ministry]
		Order By name ASC
	




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
/****** Object:  StoredProcedure [app_ministry].[ministry_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_ministry].[ministry_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@parentId			int = 0
,	@name				nvarchar(150)	=	null
,	@username			nvarchar(150)	=	null
,	@newId				int = 0 OUTPUT
,	@newLastchanged	timestamp OUTPUT
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
	
	Insert INTO
		[dbo].[ministry] 
		(
			parent_code
		,	name
		,   create_by 
		,   create_date
		,	update_by
		,	update_date 
		,	row_status
		)
	Values
	(
			@parentId
		,	@name
		,	@username
		,	@now
		,	@username
		,	@now	
		,	'C'
	)

	If (@@error !=0 )
	Begin

		set @frk_n4ErrorCode = -1;
		set @frk_strErrorText = 'An error occurred while inserting the data into the table "[dbo].[ministry]"';
		Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

	END
	Select 
			@newid = code
		,	@newlastchanged =lastchanged 
		From 
			[dbo].[ministry]
		Where 
			code	=	@@identity



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
/****** Object:  StoredProcedure [app_ministry].[ministry_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_ministry].[ministry_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0

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
	
	Select * 
		From dbo.ufministry_get(0)
		Order By name ASC
	




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
/****** Object:  StoredProcedure [app_ministry].[ministry_member_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_ministry].[ministry_member_delete]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id					int = 0
,	@username		nvarchar(150)	=	null
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
			[dbo].[member_ministry]
			Set
					update_by		=	@username
				,	update_date		=	@now
				,	row_status		=	'D'
			Where
				id = @id
		
		If (@@error !=0 )
		Begin

			set @frk_n4ErrorCode = -1;
			set @frk_strErrorText = 'An error occurred while updateing the data into the table "[dbo].[member_ministry]"';
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
/****** Object:  StoredProcedure [app_ministry].[ministry_member_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_ministry].[ministry_member_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@code			int =	0
,	@withHistory	bit	=	0
,	@role		int	=	0	
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
	,	m.CellName 
	,	m.relationship
	,	m.married
	,	m.BaptismName
	,	m.SubDivisionName
	,	m.StatusCode
	,	m.family_name
	,	m.spouse
	,	m.spousename
	,	m.active 
	 From	dbo.ufministry_get(@code) c 
		Inner Join  member_ministry f
		On f.ministry_code = c.code
		Inner Join memberview m
		On f.memberid = m.id   
	 Where  
			f.row_status <> 'D'
		And		f.enddate is null   
		And f.role_code = Case When @role <> 0 Then @role Else f.role_code End 
	 Order by c.name asc
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
	,	m.CellName
	,	m.relationship
	,	m.married
	,	m.BaptismName
	,	m.SubDivisionName
	,	m.StatusCode
	,	m.family_name
	,	m.spouse
	,	m.spousename
	,	m.active 
	 From	dbo.ufministry_get(@code) c 
		Inner Join  member_ministry f
		On f.ministry_code = c.code
		Inner Join memberview m
		On f.memberid = m.id   
	 Where  
			f.row_status <> 'D'
		And	isnull (f.enddate, @now) >= Case When @from is not null Then  @from Else '1900-1-1' End
		And	isnull (f.enddate, @now) <= Case When @to is not null Then  @to Else  @now End
		And f.role_code = Case When @role <> 0 Then @role Else f.role_code End
	 Order by c.name asc
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
/****** Object:  StoredProcedure [app_ministry].[ministry_member_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_ministry].[ministry_member_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@ministryCode		int	=	0
,	@roleCode			int	=	0
,	@memberId			int	=	0
,	@startDate			datetime	=	null	
,	@username		nvarchar(150)	=	null
,	@newId			int		=	0	OUTPUT
,	@newlastchanged	timestamp =	null	OUTPUT
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

		Insert into
			[dbo].[member_ministry]
			(
					ministry_code
				,	role_code
				,	memberid
				,	startdate
				,	update_by
				,	update_date
				,	row_status
			)
			Values
			(
					@ministryCode
				,	@roleCode
				,	@memberId
				,	@startDate
				,	@username
				,	@now
				,	'C'
			)
		
		If (@@error !=0 )
		Begin

			set @frk_n4ErrorCode = -1;
			set @frk_strErrorText = 'An error occurred while inserting the data into the table "[dbo].[member_ministry]"';
			Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

		END

		Select 
				@newlastchanged = lastchanged
			,	@newid	= id
		From [dbo].[member_ministry]
		Where 
			id	=	@@IDENTITY

		


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
/****** Object:  StoredProcedure [app_ministry].[ministry_member_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_ministry].[ministry_member_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id					int = 0
,	@ministryCode		int	=	0
,	@roleCode			int	=	0
,	@startDate			datetime	=	null
,	@endDate			datetime	=	null	
,	@username		nvarchar(150)	=	null
,	@lastchanged		timestamp	=	null
,	@newlastchanged	timestamp =	null	OUTPUT
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
			[dbo].[member_ministry]
			Set
					ministry_code	=	@ministryCode
				,	role_code		=	@roleCode
				,	startdate		=	@startDate
				,	enddate			=	@endDate
				,	update_by		=	@username
				,	update_date		=	@now
				,	row_status		=	'C'
			Where
				id = @id
				And lastchanged = @lastchanged
		
		If (@@error !=0 )
		Begin

			set @frk_n4ErrorCode = -1;
			set @frk_strErrorText = 'An error occurred while updateing the data into the table "[dbo].[member_ministry]"';
			Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

		END

		Select 
				@newlastchanged = lastchanged
		From [dbo].[member_ministry]
		Where 
			id	=	@id

		


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
/****** Object:  StoredProcedure [app_ministry].[ministry_role_delete]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_ministry].[ministry_role_delete]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id				int		=	0	
,	@username		nvarchar(150)	=	null
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
			[dbo].[ministry_roles]
			Set
					update_by		=	@username
				,	update_date		=	@now
				,	row_status		=	'D'
			Where
				code = @id
	
		If (@@error !=0 )
		Begin

			set @frk_n4ErrorCode = -1;
			set @frk_strErrorText = 'An error occurred while deleting the data into the table "[dbo].[ministry_roles]"';
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
/****** Object:  StoredProcedure [app_ministry].[ministry_role_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_ministry].[ministry_role_get]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
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
			*
			From 
			[dbo].[ministry_roles]
			Order By isdefault Desc , Name ASC

		

		


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
/****** Object:  StoredProcedure [app_ministry].[ministry_role_insert]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_ministry].[ministry_role_insert]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@name			nvarchar(20)	=	null
,	@isDefault		bit		=	0	
,	@username		nvarchar(150)	=	null
,	@newId			int		=	0	OUTPUT
,	@newlastchanged	timestamp =	null	OUTPUT
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

		Insert into
			[dbo].[ministry_roles]
			(
					name
				,	isdefault
				,	create_by
				,	create_date
				,	update_by
				,	update_date
				,	row_status
			)
			Values
			(
					@name
				,	@isDefault
				,	@username
				,	@now
				,	@username
				,	@now
				,	'C'
			)
		
		If(@isDefault = 1)
		Begin
			update 
			    [dbo].[ministry_roles]
				Set
				isdefault	=	0
				Where 
					code <> @@identity
		End

		If (@@error !=0 )
		Begin

			set @frk_n4ErrorCode = -1;
			set @frk_strErrorText = 'An error occurred while inserting the data into the table "[dbo].[ministry_roles]"';
			Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

		END

		Select 
				@newlastchanged = lastchanged
			,	@newid	=code
		From [dbo].[ministry_roles]
		Where code = @@identity

		


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
/****** Object:  StoredProcedure [app_ministry].[ministry_role_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_ministry].[ministry_role_list]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
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
			code 
			, name 
			From 
			[dbo].[ministry_roles]
			Where
				row_status <> 'D' 
			Order by isdefault Desc 
					,	Name Asc

		

		


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
/****** Object:  StoredProcedure [app_ministry].[ministry_role_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [app_ministry].[ministry_role_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id				int		=	0	
,	@name			nvarchar(20)	=	null
,	@isDefault		bit		=	0	
,	@username		nvarchar(150)	=	null
,	@lastchanged	timestamp = null
,	@newlastchanged	timestamp =	null	OUTPUT
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
			[dbo].[ministry_roles]
			Set
					name			=	@name
				,	isdefault	=	@isDefault
				,	update_by		=	@username
				,	update_date		=	@now
				,	row_status		=	'U'
			Where
				code = @id
				And	lastchanged	= @lastchanged
	
		If (@@error !=0 )
		Begin

			set @frk_n4ErrorCode = -1;
			set @frk_strErrorText = 'An error occurred while inserting the data into the table "[dbo].[ministry_roles]"';
			Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

		END
		If(@isDefault = 1)
		Begin
			update 
			    [dbo].[ministry_roles]
				Set
				isdefault	=	0
				Where 
					code <> @id
		End

		Select 
				@newlastchanged = lastchanged
		From [dbo].[ministry_roles]
		Where code = @id

		


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
/****** Object:  StoredProcedure [app_ministry].[ministry_update]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [app_ministry].[ministry_update]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		= 0
,	@id					int =	0
,	@parentId			int = 0
,	@name				nvarchar(150)	=	null
,	@username			nvarchar(150)	=	null
,	@lastchanged		timestamp = null
,	@newLastchanged	timestamp OUTPUT
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
	
	Update
		[dbo].[ministry] 
		Set
			parent_code =	@parentId
		,	name		=	@name
		,	update_by	=	@username
		,	update_date	=	@now		
		,	row_status	=	'U'
		Where 
			code = @id 
			And 
			lastchanged = @lastchanged

	If (@@error !=0 )
	Begin

		set @frk_n4ErrorCode = -1;
		set @frk_strErrorText = 'An error occurred while updating the data into the table "[dbo].[ministry]"';
		Raiserror(N'%d:%s,', 11,1, @frk_n4ErrorCode ,@frk_strErrorText);

	END

	Select 
			@newlastchanged =lastchanged 
		From 
			[dbo].[ministry]
		Where 
			code	=	@id



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
/****** Object:  StoredProcedure [app_report].[addressbook_family]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_report].[addressbook_family] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@memberlist				ntext	=	null
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
				fullname = (c.last_name + c.first_name)
			,	(	Case c.sex	
						When 1  Then '남'
						When 0  Then '여'
					End
				)	as sex
			,	c.FellowshipName
			,	isnull(c.address+',  '+c.city+' '+c.statecode+' '+c.zipcode,'') as address
			,	c.email
			,	c.cell as CellPhone
			,	c.home
			From memberview as c
				Inner Join [dbo].[CommaFamilyToTable](@memberlist) as b 
				On b.IntKey = c.id	
			Order by b.counter desc

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
/****** Object:  StoredProcedure [app_report].[addressbook_member]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_report].[addressbook_member] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@memberlist				ntext	=	null
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
				fullname = (c.last_name + c.first_name)
			,	(	Case c.sex	
						When 1  Then '남'
						When 0  Then '여'
					End
				)	as sex
			,	c.FellowshipName
			,	isnull(c.address+',  '+c.city+' '+c.statecode+' '+c.zipcode,'') as address
			,	c.email
			,	c.cell as CellPhone
			,	c.home
			From memberview as c
				Inner Join [dbo].CommaListToTable(@memberlist) as b 
				On b.IntKey = c.id	
			Order by b.counter desc

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
/****** Object:  StoredProcedure [app_report].[addresslabel_family]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_report].[addresslabel_family] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@memberlist				ntext	=	null
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
				fullname = (c.en_last_name + ' ' + c.en_first_name)
			,	c.address
			,	c.city
			,	c.statecode
			,	c.zipcode
		From 
			dbo.memberview as c 
			INNER Join  dbo.CommaFamilyToTable(@memberlist)  as b 
		 On b.IntKey = c.id order by b.counter desc

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
/****** Object:  StoredProcedure [app_report].[addresslabel_member]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_report].[addresslabel_member] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@memberlist				ntext	=	null
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
				fullname = (c.en_last_name + ' ' + c.en_first_name + ' (' +c.last_name+c.first_name+')')
			,	c.address
			,	c.city
			,	c.statecode
			,	c.zipcode
		From 
			dbo.memberview as c 
			INNER Join  dbo.CommaListToTable(@memberlist)  as b 
		 On b.IntKey = c.id order by b.counter desc

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
/****** Object:  StoredProcedure [app_report].[cell_family]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_report].[cell_family]
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@list				ntext	=	null
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
			Declare @level1 nvarchar(150)
			Declare @level2	nvarchar(150)
			Declare @role1 int 
			Declare @role2 int


			Select @role1 = code, @level1 = name From dbo.cell_roles where  levels = 1	
			Select @role2 = code, @level2 = name From dbo.cell_roles where  levels = 2
							
			
			Select 
						a.code as ID
					,	a.name As CellName
					,	@level1 AS CellLevel1
					,	@level2 AS CellLevel2
					,	ISNULL	(
						(SELECT  top 1   
							last_name + first_name AS membername        
							FROM       
								 dbo.viewCellMember
							WHERE      
									cell_code = a.code
								AND enddate IS NULL 
								AND  role_code = @role1 
						), '') AS Level1Name
					,	ISNULL ((
							SELECT  top 1   
								last_name + first_name AS membername
							FROM         
								dbo.viewCellMember 
							WHERE     
								cell_code = a.code 
							AND 
								enddate IS NULL 
							AND 
								role_code = @role2)
						, '') AS Level2Name
					
				
				From	
					dbo.cell a
				Inner join
					dbo.CommaListToTable(@list) b
				On
					a.code = b.IntKey	
				
				Order by b.Counter ASC

				Select 
						d.cell_code as CellCode
					,	c.home as Home
					,	d.family_code as FamilyCode					
					,	(isnull(c.[address],'')+' ' + isnull(city,'')+' '+ isnull(statecode ,'')+ ' '+ isnull(zipcode,'')) as [Address]
					,	c.regdate as RegDate
					,	(isnull(c.last_name,'') + isnull(c.first_name,'')) as MemberName 
				From 
					dbo.memberview as c
					inner Join
					(
						SELECT   
								a.cell_code
							,	a.family_code
								From dbo.viewCellMember a
								Inner join
									dbo.CommaListToTable(@list) b
								On
									a.cell_code = b.IntKey	
								Where 
									a.enddate IS Null
								Group By 
								 a.cell_code,	a.family_code 
					) d
					On 
						d.family_code = c.id
						
				Order by  d.cell_code ASC, d.family_code  ASC
 
				 select 
				  		(isnull(c.last_name,'')+isnull(c.first_name,'')) as MemberName  
					,	d.family_code as FamilyCode
					,	c.id as MemberID
					,	(Case sex  When 0 Then '여' Else '남' End )	as Sex
					,	c.birthday as Birthday
					,	c.email as Email
					,	c.cell as CellPhone
					,	c.SubDivisionName as Subdivision
					,	(isnull(c.Relationship,'')) as Relationship
					,	c.BaptismName as Baptism
					,	isnull(c.FellowshipName,'') as Fellowship
					,	job as Job
				From 
					dbo.memberview as c
					inner Join
					(
						SELECT   
								a.cell_code
							,	a.family_code
								From dbo.viewCellMember a
								Inner join
									dbo.CommaListToTable(@list) b
								On
									a.cell_code = b.IntKey	
								Where 
									a.enddate IS Null
								Group By 
								 a.cell_code,	a.family_code 
					) d
					On 
						d.family_code = c.family_code
		
		
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
/****** Object:  StoredProcedure [app_report].[cell_report_print]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_report].[cell_report_print] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@list				ntext	=	null
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

	Declare @level1 nvarchar(150)
	Declare @level2	nvarchar(150)
	Declare @role1 int 
	Declare @role2 int


	Select @role1 = code, @level1 = name From dbo.cell_roles where  levels = 1	
	Select @role2 = code, @level2 = name From dbo.cell_roles where  levels = 2


	SELECT
				r.Id 
			,	r.leader
			,	r.cell_date as celldate
			,	r.cell_place as place
			,	r.atten_family_count as attenfamily
			,	r.total_family_count as totalfamily
			,	r.new_member as newmember
			,	r.request
			,	r.memo
			,	isnull((select f.name From dbo.cell f Where f.code = r.cell_code),'') as cellname
			,   @level1 as celllevel1
			,	r.cell_leader as cellelvel1name
			,	@level2 as celllevel2
			,	r.cell_leader2 as cellelvel1name
			,	(Select count(e.id) From rpt_cell_detail e where e.parent_id = r.id and e.attendance = 1) as attendance
		From dbo.rpt_cell	r
			Inner join dbo.CommaListToTable(@list) b
			On r.id = b.IntKey
	

	Select 
				r.id as Id
			,	r.parent_id as rpt_id
			,	(m.last_name + m.first_name) as membername
			,	r.attendance
			,	r.reason
			,	r.memo

			From dbo.rpt_cell_detail r
			Inner join	dbo.members m 
			On r.member_id = m.id
			Inner join dbo.CommaListToTable(@list) b
			On r.parent_id = b.IntKey
			
		
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
/****** Object:  StoredProcedure [app_report].[donate_sheet]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_report].[donate_sheet] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@list				ntext	=	null
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
					c.id
				,	c.regdate
				,	c.checks
				,	DonateType = isnull((select [name] from donate_types where code = c.donate_code),'')
				,   c.total
				,	PaidType = c.detail 
				,	c.hundred
				,	c.fifty
				,	c.twenty
				,	c.ten
				,	c.five
				,	c.one
				,	c.coins
				,	c.create_by	as recorder   
			 From  
					dbo.donate_books  as c 
				Inner Join
					[dbo].[CommaListToTable](@list) as b 
				On 
					b.IntKey = c.id

			Select 
					d.book_id as BookId 
				,	isnull(m.[name],(m.en_last+' ' +m.en_first)) as Donator
				,	isnull(m.[member_id] , '') as MemberID
				,	d.amount 
				,	(	Case 
							d.pay_code  When 0 Then 'check' Else 'cash' End ) as MoneyType
				From 
						dbo.donates as d 
					Inner Join
						[dbo].[CommaListToTable](@list) as b 
					ON
						b.IntKey = d.book_id 
					Inner Join
						dbo.donate_members m 
					On
						m.id = d.donate_id
				order by d.[no] asc
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
/****** Object:  StoredProcedure [app_report].[donate_weekly]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_report].[donate_weekly] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@startdate					datetime	=	null
,	@enddate					datetime	=	null
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
					f.*
				,	g.code as code
				,	g.typename as RootName
			From
			(
				Select
						Sum(total) as Amount
					,	Sum(isnull(hundred,0)) as Hundred  
					,	Sum(isnull(fifty,0)) as Fifty 
					,	Sum(isnull(twenty,0)) as Twenty 
					,	Sum(isnull(ten,0)) as Ten 
					,	Sum(isnull(five,0)) as Five 
					,	Sum(isnull(one,0)) as One
					,	Sum(isnull(coins,0)) as Coins
					,	Sum(isnull(checks,0)) as Checks
					,b.parentcode 
				From 
					dbo.donate_books a
				Inner Join 
					dbo.ufdonatetype_get(0) b
				On
					a.donate_code = b.code
				Where
						a.regdate >= isnull(@startdate , '1900-01-01') 
					and a.regdate <= isnull(@enddate , GetDate())
					
				Group By
					b.parentcode 
			) f
			Right Outer Join
				( 
					Select 
							c.code
						,	c.typename 
					From 
						dbo.ufdonatetype_get(0) c
					Where 
						c.type_level = 1
				) g
			On 
				f.parentcode  = g.code

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
/****** Object:  StoredProcedure [app_report].[donate_weekly_summary]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [app_report].[donate_weekly_summary] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@startdate				datetime	=	null
,	@enddate					datetime	=	null
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

			WITH donateCTE
AS
(
        SELECT t.*
               ,s.amount
        FROM      donate_types      AS t
        LEFT JOIN (select sum(total)as Amount,donate_code  from donate_books where regdate >=@startdate and regdate <= @enddate group by donate_code)  AS s
        ON        s.donate_code = t.code and t.status = 1
)
,
recCTE
AS
(
        SELECT t.code
               ,CAST(t.name AS VARCHAR(MAX)) AS name
               ,t.parent_code 
               ,ISNULL(t.amount,0) AS Amount
               ,0 AS LEVEL
               ,CAST(t.code AS VARCHAR(100)) AS ord
        FROM donateCTE   AS t
        WHERE t.parent_code IS NULL  

        UNION ALL

        SELECT t.code
               ,CAST(REPLICATE(' ',r.LEVEL) + t.name AS VARCHAR(MAX)) AS name
               ,t.parent_code
               ,ISNULL(t.amount,0) AS Amount
               ,r.LEVEL + 1
               ,CAST(r.ord + '|' + CAST(t.code AS VARCHAR(11)) AS VARCHAR(100)) AS ord
        FROM      donateCTE    AS t        
        JOIN      recCTE        AS r
        ON        r.code = t.parent_code
)



SELECT f.*, RootName = (Select [name] from donate_types where code = f.rootcode) 
from
(
Select r.* ,Case charindex('|',r.ord)
When 0 then r.ord 
Else ltrim(rtrim(substring(r.ord,0,charindex('|',r.ord))))End as rootcode from recCTE as r
where (amount<>0 or level =0)  
) as f 

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
/****** Object:  StoredProcedure [app_report].[family_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_report].[family_list] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@memberlist				ntext	=	null
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
	Select @now = GETDATE()

				Select  
						(isnull(c.last_name,'') + isnull(c.first_name,'')) as [FamilyName]
					,	isnull(c.[address],'') As [Address]
					,	isnull(c.city,'') as City
					,	isnull(c.statecode ,'') as State
					,	isnull(c.zipcode,'') as [Zipcode]
					,	c.id as Id
					,	c.home as Home
					,	CONVERT(varchar,c.regdate,101) as RegDate
					,	isnull(c.CellName,'') as CellName
				From 
					[dbo].[CommaFamilyToTable](@memberlist)  as b 
				inner join 
					memberview as c 
				On  b.IntKey = c.id 
				Order by b.counter ASC



				Select 
					c.id as MemberId
				,	c.family_code as FamilyId
				,	(isnull(c.last_name,'') + isnull(c.first_name,'')) as KoName
				,	c.email as Email  
				,	CONVERT(varchar,c.birthday,101) as Birthday
				,	job as Job
				,	c.BaptismName as Baptism
				,	(Case c.sex  When 0 Then '여' Else '남' End )as Sex
				,	c.SubDivisionName as SubDivision
				,	(isnull(c.Relationship,'')) as Relationship
				,	c.cell as Cellphone
				,	isnull(C.FellowshipName,'') as Fellowship
				From 
					dbo.memberview as c
				Inner Join
					[dbo].[CommaFamilyToTable](@memberlist)  as b  
				ON 
					b.IntKey = c.family_code 
				Order by 
					b.Counter asc, 
					family_relationship asc

 
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
/****** Object:  StoredProcedure [app_report].[member_card]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_report].[member_card] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@memberlist				ntext	=	null
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
	Select @now = GETDATE()

			Select  
					(isnull(c.last_name,'') + isnull(c.first_name,'')) as [Name]
				,	isnull(c.[address],'') As [Address]
				,	isnull(c.city,'') as City
				,	isnull(c.statecode ,'') as State
				,	isnull(c.zipcode,'') as [Zipcode]
				,	c.id as MemberId
				,	c.family_code as FamilyId
				,	(isnull(c.Relationship,'')) as Relationship
				,	isnull(c.FellowshipName,'') as Fellowship
				,	c.home as Home
				,	c.cell as Cellphone
				,	c.work_phone as Office
				,	c.job as Job
				,	c.baptismName as Baptism
				,	c.email as Email
				,	isnull(dbo.CsvMinistryList(c.id),'') as MinistryList
				,	CONVERT(varchar,c.regdate,101) as RegDate
				,	c.SubDivisionName as Subdiv
				,	(Case c.sex  When 0 Then '여' Else '남' End )as Sex
				,	CONVERT(varchar,c.birthday,101) as Birthday
				,	c.baptism_year as BaptismDate
				,	[dbo].[GetAge](c.birthday,@now) as Age
				,	isnull((select entrytype from dbo.type_entry where id = c.entrytype),'') as EntryType
				,	isnull(c.CellName,'') as CellName
			From 
				memberview as c
			Inner join [dbo].[CommaListToTable](@memberlist)  as b  
			On 
				b.IntKey = c.id Order by b.counter desc


				Select 
					c.id as MemberId
				,	c.family_code as FamilyId
				,	(isnull(c.last_name,'') + isnull(c.first_name,'')) as [Name]
				,	CONVERT(varchar,c.birthday,101) as Birthday
				,	job as Job
				,	c.baptismName as Baptism
				,	c.SubDivisionName as Subdiv
				,	(isnull(c.Relationship,'')) as Relationship
				,	c.work_phone as Office
				,	c.cell as Cellphone
				,	isnull(c.FellowshipName,'') as Fellowship
				From 
					memberview as c 
				Inner Join 
					[dbo].[CommaFamilyToTable](@memberlist)  as b 
				On b.IntKey = c.family_code  
				Order by b.counter desc

				Select 
						c.comment as Context
					,	c.create_by as Writer
					,	CONVERT(varchar,c.regdate,101) as RegDate
					,	c.memberid as MemberId
				From 
					[dbo].[comments] as c
				Inner Join 
					[dbo].[CommaListToTable](@memberlist)  as b  
				ON 
					b.IntKey = c.memberid  Order by b.counter 
 
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
/****** Object:  StoredProcedure [app_report].[member_details]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_report].[member_details] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@memberlist				ntext	=	null
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
	Select @now = GETDATE()
	
				Select  
					(isnull(c.last_name,'') + isnull(c.first_name,'')) as [Name]
				,	(isnull(c.en_first_name,'') +' '+ isnull(c.en_last_name,'')) as [En_Name]
				,	isnull(c.[address],'') As [Address]
				,	isnull(c.city,'') as City
				,	isnull(c.statecode ,'') as State
				,	isnull(c.zipcode,'') as [Zipcode]
				,	c.id as MemberId
				,	c.family_code as FamilyId
				,	(isnull(c.Relationship,'')) as Relationship
				,	isnull(c.FellowshipName,'') as Fellowship
				,	isnull((select name from dbo.type_job where id =c.jobtype),'') as JobType
				,	c.fellowship_date as FellowshipDate
				,	c.home as Home
				,	c.cell as Cellphone
				,	c.work_phone as Office
				,	c.job as Job
				,	c.spousename as SpouseName
				,	c.baptismName as Baptism
				,	c.email as Email
				,	isnull(c.CellName,'') as CellName
				,	isnull(dbo.CsvMinistryList(c.id),'') as MinistryList
				,	CONVERT(varchar,c.regdate,101) as EntryDate
				,	c.SubDivisionName as SubDivision
				,	(Case c.sex  When 0 Then '여' Else '남' End )as Sex
				,	CONVERT(varchar,c.birthday,101) as Birthday
				,	c.baptism_year as BaptismDate
				,	[dbo].[GetAge](c.birthday,@now) as Age
				,	isnull((select name from dbo.type_entry where id = c.entrytype),'') as EntryType

				From 
					memberview as c
				Inner Join 
					[dbo].[CommaListToTable](@memberlist)  as b  
				ON b.IntKey = c.id



				Select 
					c.id as MemberId
				,	c.family_code as FamilyId
				,	(isnull(c.last_name,'') + isnull(c.first_name,'')) as [Name]
				,	CONVERT(varchar,c.birthday,101) as Birthdate
				,	job as Job
				,	(Case c.sex  When 0 Then '여' Else '남' End )as Sex
				,	c.baptismName as Baptism
				,	c.SubDivisionName as SubDivision
				,	(isnull(c.Relationship,'')) as Relationship
				,	c.cell as Cellphone
				,	isnull(c.FellowshipName,'') as Fellowship
				From 
					memberview as c
				Inner Join
					[dbo].[CommaFamilyToTable](@memberlist)  as b
				On 
					b.IntKey = c.family_code

				Select 
						c.id as [No]
					,	c.memberid  as MemberId
					,	c.cell_name as CellName
					,	c.startdate as Startdate 
					,	c.enddate as Enddate
					,   c.role_name as CellRole
				From 
					dbo.viewCellMember as c
				Inner Join 
					[dbo].[CommaListToTable](@memberlist)  as b  
				On 
					b.IntKey = c.memberid
				ORDER BY 
						(CASE WHEN c.enddate IS NULL THEN 1 ELSE 0 END) DESC
					,	c.enddate DESC 


				Select 
						m.id as [No]
					,	m.memberid  as MemberId
					,	c.[name] as Fellowship
					,	m.startdate as Startdate 
					,	m.enddate as Enddate
				From 
					dbo.fellowship  c
				Inner Join 
					dbo.member_fellowship m
				ON
					c.code = m.fellowship_code
				Inner Join
					[dbo].[CommaListToTable](@memberlist)  as b  
				ON 
					b.IntKey = m.memberid
				ORDER BY (CASE WHEN m.enddate IS NULL THEN 1 ELSE 0 END) DESC,m.enddate DESC 

				Select 
						c.id as [No]
					,	c.memberid  as MemberId
					,	a.name	as [MinistryName] 
					,	r.name as [Roles]
					,	c.startdate as Startdate 
					,	c.enddate as Enddate
				From 
					dbo.member_ministry as c
				Inner Join 
					dbo.ministry as a
				On 
					a.code = c.ministry_code
				Inner Join
					dbo.ministry_roles r
				On
					c.role_code = r.code
				Inner Join
					[dbo].[CommaListToTable](@memberlist)  as b  
				On 
					b.IntKey = c.memberid
				ORDER BY (CASE WHEN c.enddate IS NULL THEN 1 ELSE 0 END) DESC,c.enddate DESC 
				
				
				Select 
						c.id as [No]
					,	a.name as CourseName
					,	CONVERT(varchar,c.graduated,101) as CompleteDate 
				From 
					[dbo].[Member_course] as c
				Inner join 
					dbo.courses a 
				ON 
					c.course_code = a.code
				Inner join 
				    [dbo].[CommaListToTable](@memberlist)  as b  
				On 
					b.IntKey = c.memberid  
				Order by b.counter 

				Select 
						c.id as [No]
					,	c.comment as Context
					,	c.create_by as Writer
					,	CONVERT(varchar,c.regdate,101) as Regdate
					,	c.memberid as MemberId
				From 
					[dbo].[comments] as c
				Inner Join
					 [dbo].[CommaListToTable](@memberlist)  as b 
				On 
					b.IntKey = c.memberid  
				Order by b.counter 
 
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
/****** Object:  StoredProcedure [app_report].[member_donate]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_report].[member_donate] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@donateid				int			=	0
,	@year					int			=	0
,	@family					bit			=	0
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
---	Exec app_report.member_donate @year = 2012, @donateid = 443 , @family = 1

-- }

-- BEGIN BODY
-- {
	-- initialize local variable statements here
	-- {
		Declare @spouseid int 

			If(@family = 1)
			Begin
				Select 
					@spouseid = c.id 
				 From 
					dbo.donate_members c
				Inner Join 
				(

				select b.spouse 
					From dbo.donate_members a
					Inner join  
						dbo.members b
					on 
					 a.member_id = b.id
				Where a.id = @donateid 

				) f
				ON
				 c.member_id  = f.spouse
			END
			
			Select  
					1 as MemberId
				, 	(c.en_first +'  '+c.en_last) as [Name]
				,	Isnull((Select a.en_first +'  '+c.en_last From dbo.donate_members a Where a.id = @spouseid) , '' ) as Spouse
				,	c.Address
				,	c.Statecode as State
				,	c.Zipcode
				,	c.city as City
				,	'01/01/'+cast(@year as varchar(4)) as Startdate
				,   '12/31/'+cast(@year as varchar(4)) as Enddate 
				,	Getdate() as Issuedate
				,	1 as ChurchId 
			From 
					dbo.viewDonateMember as c
			Where
				 c.id = @donateid

			Select 
					c.donate_date as DonateDate 
				,	1 as MemberId 
				,	c.Amount 
				,	c.[no] as Id  
			From 
					dbo.donates as c
			Where
				c.donate_year = @year
			And
				c.donate_id in ( @donateid,@spouseid) 


			Select	
					1 as ChurchId
				 ,	(c.address1 + '  '  + c.address2) as Address
				 ,	c.city as City
				 ,	c.state as [State]
				 ,	c.zipcode as Zipcode
				 ,	c.tax_id as Tax_Id
				 ,	c.signer as Signer
				 ,	c.name as ChurchName
				From dbo.church c



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
/****** Object:  StoredProcedure [app_report].[member_family]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_report].[member_family] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@memberlist				ntext	=	null
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
						c.id as Id
					,	(isnull(c.last_name,'') + isnull(c.first_name,'')) as [Name]
					,	isnull(c.[address],'') As [Address]
					,	isnull(c.city,'') as City
					,	isnull(c.statecode ,'') as Statecode
					,	isnull(c.zipcode,'') as [Zipcode]
					,	c.home as Home
					,	CONVERT(varchar,c.regdate,101) as EntryDate
					,	isnull(c.CellName,'') as CellName
				From 
					[dbo].[CommaFamilyToTable](@memberlist)  as b 
				Inner join 
					dbo.memberview as c 
				On  
					b.IntKey = c.id 
				Order by b.counter desc



				Select 
					c.id as MemberId
				,	c.family_code as FamilyId
				,	(isnull(c.last_name,'') + isnull(c.first_name,'')) as [Ko_name]
				,	(isnull(c.en_last_name,'') +' '+isnull(c.en_first_name,'')) as En_name
				,	c.email as Email  
				,	CONVERT(varchar,c.birthday,101) as Birthdate
				,	isnull((Select (isnull(d.last_name,'') + isnull(d.first_name,'')) as [Name] from members as d where d.id = c.spouse),'') as Spouse
				,	CONVERT(varchar,c.regdate,101) as Entrydate
				,	(Case c.active  When 0 Then '제적' Else 'Active' End ) as [Status]
				,	job as Job
				,	c.BaptismName as Baptism
				,	CONVERT(varchar,c.baptism_year,101) as Baptismdate
				,	CONVERT(varchar,c.fellowship_date,101) as Fellowshipdate
				,	(Case c.sex  When 0 Then '여' Else '남' End )as Sex
				,	c.SubDivisionName as Subdiv
				,	(Case c.married  When 0 Then '미혼' Else '기혼' End )as Married
				,	(isnull(c.Relationship,'')) as Relationship
				,	c.work_phone as Office
				,	c.cell as Cellphone
				,	isnull(C.FellowshipName,'') as Fellowship
				,	isnull((select name from type_job  where id  = c.jobtype),'') as Jobtype
				,	isnull((select name from type_entry  where id = c.entrytype),'') as Entrytype
				,	isnull(c.CellName,'') as CellName
				From 
					dbo.memberview as c 
				Inner Join 
					[dbo].[CommaFamilyToTable](@memberlist)  as b  
				On 
					b.IntKey = c.family_code 
				Order by b.Counter desc 
				, family_relationship asc
				
				Select 
						c.comment
					,	c.memberid
					,	m.family_code
					,	c.update_date as lastupdate
					,	c.id 
				From 
					dbo.members m
				Inner Join
					dbo.comments c
				On
					c.memberid = m.id
				Inner Join
					dbo.[CommaFamilyToTable](@memberlist)  as b  
				On	b.IntKey = m.family_code 
				Order by b.Counter 
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
/****** Object:  StoredProcedure [app_report].[member_visit]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_report].[member_visit] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@list				ntext	=	null
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
	Select @now = GETDATE()

			Select  
				(isnull(c.last_name,'') + isnull(c.first_name,'')) as [Name]
			,	isnull(c.[address],'') As [Address]
			,	isnull(c.city,'') as City
			,	isnull(c.statecode ,'') as State
			,	isnull(c.zipcode,'') as [Zipcode]
			,	c.id as MemberId
			,	c.family_code as FamilyId
			,	c.Relationship 
			,	c.FellowshipName as Fellowship
			,	c.home as Home
			,	c.cell as Cellphone
			,	c.work_phone  as Office
			,	c.job as Job
			,	c.BaptismName as Baptism
			,	c.email as Email
			,	c.CellName
			,	isnull(dbo.CsvMinistryList(c.id),'') as MinistryList
			,	CONVERT(varchar,c.regdate,101) as RegDate
			,	c.SubDivisionName as Subdiv
			,	(Case c.sex  When 0 Then '여' Else '남' End )as Sex
			,	CONVERT(varchar,c.birthday,101) as Birthday
			,	c.baptism_year as BaptismDate
			,	[dbo].[GetAge](c.birthday,@now) as Age
			,	isnull((select entrytype from dbo.type_entry where id = c.entrytype),'') as EntryType
			From 
				memberview as c
			Inner Join
				[dbo].[CommaListToTable](@list)  as b 
			On 
				b.IntKey = c.id

			select * from 
			(
				Select 
						c.id as MemberId
					,	c.family_code as FamilyId
					,	(isnull(c.last_name,'') + isnull(c.first_name,'')) as [Name]
					,	CONVERT(varchar,c.birthday,101) as Birthday
					,	job as Jobs
					,	(Case c.sex  When 0 Then '여' Else '남' End )as Sex
					,	c.BaptismName as Baptism
					,	c.SubDivisionName as SubDivision
					,	c.Relationship 
					,	c.work_phone as Office
					,	c.cell as Cellphone
					,	c.FellowshipName as Fellowship
				From 
					dbo.memberview as c
				Inner Join
					[dbo].[CommaFamilyToTable](@list)  as b 
				On b.IntKey = c.family_code 
				)	as f 
				Left Outer Join 
				[dbo].[CommaListToTable](@list) as  d 
				On d.IntKey = f.MemberId 
				where d.IntKey is Null



				Select 
						c.id as [No]  
					,	CONVERT(varchar,c.visitdate,101) as VisitDate
					,	c.contents as Context
					,	c.song as Song
					,	c.bible  as Bible
					,	c.pastor as Leader
					,   isnull((select name from dbo.type_visit where id = c.visittype),'') as VisitType
					,	m.family_code as FamilyId
					From 
						dbo.viewVisitReport as c
					Inner Join
						dbo.memberview  m
					On 
						m.id  = c.memberid	
					Inner Join
						[dbo].[CommaFamilyToTable](@list)  as b
					On 
						b.IntKey = m.family_code
				 Order by c.visitdate Desc

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
/****** Object:  StoredProcedure [app_report].[member_wPicture]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_report].[member_wPicture] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@memberlist				ntext	=	null
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
	Select @now = GETDATE()
	
				Select  
					(isnull(c.last_name,'') + isnull(c.first_name,'')) as [Name]
				,   (isnull(c.[address],'')+' ' + isnull(city,'')+' '+ isnull(statecode ,'')+ ' '+ isnull(zipcode,'')) as [Address]
				,	isnull(c.FellowshipName,'') as Fellowship
				,	birthday	as Birthday
				,	id			as MemberId
				,	email		as Email
				,	cell		as CellPhone
				,	SubDivisionName as SubDiv
				,	baptismName as Baptism
				,	home as Home
				,	cell as CellPhone
				,	regdate as RegDate
				,	isnull(c.CellName,'') as CellName
				From 
					dbo.memberview as c
				Inner Join 
					[dbo].[CommaListToTable](@memberlist)  as b  
				On 
					b.IntKey = c.id  
				Order by b.Counter ASC
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
/****** Object:  StoredProcedure [app_report].[status]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_report].[status] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@list				ntext	=	null
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
					c.[id] as [No]
				,	c.regdate as Regdate
				,	(m.last_name+m.first_name) as MemberName
				,	m.statecode as State
				,	m.city as City
				,	m.address as Address 
				,	m.zipcode as Zipcode
				,	a.name as StatusName
				,	m.regdate as EntryDate
				,	m.home as Home
				,	c.memo as Reasons
				,	m.FellowshipName as Fellowship
				,   m.CellName
			From 
				dbo.memberview  m 
			Inner join 
				dbo.status_log c
			On
				m.id = c.memberid
			Inner Join
				dbo.type_status a
			On
				c.statusid = a.id	
			Inner Join
				 [dbo].[CommaListToTable](@list) as b 
			On 
				b.IntKey = c.id
	
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
/****** Object:  StoredProcedure [app_report].[status_family]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [app_report].[status_family] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@list				ntext	=	null
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
					c.[id] as [No]
				,	c.regdate as StatusDate
				,	(m.last_name+m.first_name) as [Name]
				,	m.family_code  as FamilyId
				,	m.statecode as State
				,	m.city as City
				,	m.address as Address 
				,	m.zipcode as Zipcode
				,	a.name as StatusName
				,	m.regdate as EntryDate
				,	m.home as Home
				,	c.memo as Reasons
				,	m.FellowshipName as Fellowship
				,   m.CellName
			From 
				dbo.memberview  m 
			Inner join 
				dbo.status_log c
			On
				m.id = c.memberid
			Inner Join
				dbo.type_status a
			On
				c.statusid = a.id	
			Inner Join
				 [dbo].[CommaListToTable](@list) as b 
			On 
				b.IntKey = c.id

			Select 
					(isnull(c.last_name,'')+isnull(c.first_name,'')) as Name
				,   c.family_code as FamilyId
				,	c.id as MemberID
				,	(Case c.sex  When 0 Then '여'	Else '남' End )	as Sex
				,	c.birthday as BirthDate
				,	c.email as Email
				,	c.cell as Cellphone
				,	c.SubDivisionName as Subdiv
				,	c.Relationship
				,	c.BaptismName	as Baptism
				,	c.fellowshipName
				,	c.job as Job
			From 
				memberview as c
			Inner Join
				( Select 
					distinct m.family_code 
					From 
						dbo.members m 
					Inner Join 
						dbo.status_log s
					On
						m.id = s.memberid
					Inner Join
						[dbo].[CommaListToTable](@list) as b 
					On 
						b.IntKey = s.id
				) f
			On 
				f.family_code = c.family_code
								
	
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
/****** Object:  StoredProcedure [app_report].[visit_list]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [app_report].[visit_list] 
(
	@frk_n4ErrorCode		int		= null	OUTPUT
,	@frk_strErrorText		nvarchar(100)	= null	OUTPUT
,	@frk_isRequiresNewTransaction	bit		=	0
,	@list				ntext	=	null
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
				c.id as ID
			,  (isnull(c.last_name,'') + isnull(c.first_name,'')) as [MemberName] 
			,	CONVERT(varchar,c.visitdate,101) as VisitDate
			,	c.contents as Contents
			,	c.home as Home
			,	c.[address] as [Address]
			,	c.city as City
			,	c.statecode as Statecode
			,	c.zipcode as Zipcode
			,	c.song as Song
			,	c.bible as Bible
			,	c.pastor as Pastor
			,	c.CellName 
			,   isnull((select name from dbo.type_visit where id = c.visittype),'') as VisitType
			From 
					dbo.viewVisitReport as c 
					
			Inner Join
				 [dbo].[CommaListToTable](@list) as b  
			ON 
				b.IntKey = c.id
  
			Order by c.visitdate Desc

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
/****** Object:  UserDefinedFunction [dbo].[CommaFamilyToTable]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[CommaFamilyToTable] ( @cList VarChar(MAX)) 
RETURNS @IntKeyTable TABLE
	(IntKey INT  , Counter int  PRIMARY KEY CLUSTERED ([IntKey])     ) AS
BEGIN

	DECLARE @nPosition INT
	DECLARE @cTempValue VARCHAR(max) 
	DECLARE @nIntKey int
	DECLARE @nCounter int
DECLARE @familycode int
	SET @nCounter = 0
		
	SET @cList = RTRIM(@cList) + ','
	-- So right now we might have  '1111,2222,'
	-- (Careful if the CSV already ended with a comma,
	-- you’ll wind up with an extra 0 in the key table)
	
	-- see if comma exists in list
	-- (use PATINDEX to return pattern position within a string
	WHILE PATINDEX('%,%' , @cList) <> 0     
	BEGIN
		SET @nCounter = @nCounter + 1
		-- get the position of the comma
		SELECT @nPosition =  PATINDEX('%,%' , @cList)    
		-- get the key, from beginning of string to the comma
		SELECT @cTempValue = LEFT(@cList, @nPosition - 1)   

		SET @nIntKey = CAST(@cTempValue AS INT)
		-- Write out to the Keys table (convert to integer)
			
		Select @familycode =family_code from members where id =@nIntKey
		If NOT EXISTS(Select * from @IntKeyTable  where IntKey = @familycode)
		begin 
		INSERT INTO @IntKeyTable 
			VALUES (isnull(@familycode,0),@nCounter)	
		end
		-- wipe out the value we just inserted  
		SELECT @cList = STUFF(@cList, 1, @nPosition, '')     
	END
	RETURN
END



GO
/****** Object:  UserDefinedFunction [dbo].[CommaListToTable]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================


CREATE FUNCTION  [dbo].[CommaListToTable] ( @cList VarChar(MAX)) 
RETURNS @IntKeyTable TABLE
	(IntKey INT   , Counter int   PRIMARY KEY CLUSTERED ([IntKey])     ) AS
BEGIN

	DECLARE @nPosition INT
	DECLARE @cTempValue VARCHAR(max) 
	DECLARE @nIntKey int
	DECLARE @nCounter int
	SET @nCounter = 0
		
	SET @cList = RTRIM(@cList) + ','
	-- So right now we might have  '1111,2222,'
	-- (Careful if the CSV already ended with a comma,
	-- you’ll wind up with an extra 0 in the key table)
	
	-- see if comma exists in list
	-- (use PATINDEX to return pattern position within a string
	WHILE PATINDEX('%,%' , @cList) <> 0     
	BEGIN
		SET @nCounter = @nCounter + 1
		-- get the position of the comma
		SELECT @nPosition =  PATINDEX('%,%' , @cList)    
		-- get the key, from beginning of string to the comma
		SELECT @cTempValue = LEFT(@cList, @nPosition - 1)   

		SET @nIntKey = CAST(@cTempValue AS INT)
		-- Write out to the Keys table (convert to integer)
		if Not Exists ( select intKey from @IntKeyTable where IntKey = @nIntKey)
		Begin
		INSERT INTO @IntKeyTable 
			VALUES (@nIntKey, @nCounter)		
		End
		-- wipe out the value we just inserted  
		SELECT @cList = STUFF(@cList, 1, @nPosition, '')     
	END
	RETURN
END

GO
/****** Object:  UserDefinedFunction [dbo].[CsvMinistryList]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[CsvMinistryList]
(
  @memberid int
)
RETURNS nvarchar(max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE  @sql_output nvarchar(max)
	set @sql_output =''
	Select
		 @sql_output = coalesce(@sql_output + a.name+'('+c.name+')'+' | ','') 
		From
		 dbo.ministry a 
		 Inner Join 
		 dbo.member_ministry b
		 On
			a.code = b.ministry_code
		Inner join
		dbo.ministry_roles c
		On
			c.code = b.role_code 
	Where 
			b.memberid = @memberid
		And
			b.enddate is null

	-- Return the result of the function
	RETURN @sql_output

END

GO
/****** Object:  UserDefinedFunction [dbo].[DonateSumary]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[DonateSumary] ( 
@startdate datetime, @enddate datetime
) 
RETURNS @donatesumary TABLE
	(ID INT, Type1 money ,     Type2 money ,  
 Type3 money ,   Type4 money ,   Type5 money ,   Type6 money ,     
 Total money      ) 
AS
BEGIN

WITH donateCTE
AS
(
        SELECT t.*
               ,s.amount,s.donate_id
        FROM      donate_types      AS t
        LEFT JOIN (select donate_id, sum(amount)as Amount, donate_code  from donates where donate_date >= @startdate and donate_date <= @enddate  group by donate_id, donate_code)  AS s
        ON        s.donate_code = t.code 
)
,
recCTE
AS
(
        SELECT t.code
               ,CAST(t.name AS VARCHAR(MAX)) AS name
               ,t.parent_code 
			   ,t.donate_id
               ,ISNULL(t.amount,0) AS Amount
               ,0 AS LEVEL
               ,CAST(t.code AS VARCHAR(100)) AS ord
        FROM donateCTE   AS t
        WHERE t.parent_code IS NULL  

        UNION ALL

        SELECT t.code
               ,CAST(REPLICATE(' ',r.LEVEL) + t.name AS VARCHAR(MAX)) AS name
               ,t.parent_code
				,t.donate_id
               ,ISNULL(t.amount,0) AS Amount
               ,r.LEVEL + 1
               ,CAST(r.ord + '|' + CAST(t.code AS VARCHAR(11)) AS VARCHAR(100)) AS ord
        FROM      donateCTE    AS t        
        JOIN      recCTE        AS r
        ON        r.code = t.parent_code
)
Insert @donatesumary
select a.donate_id as donateid , Sum(Case a.rootcode When 1 then a.Amount else 0 end) as type1
,Sum(Case a.rootcode When 2 then a.Amount else 0 end) as type2
,Sum(Case a.rootcode When 3 then a.Amount else 0 end) as type3
,Sum(Case a.rootcode When 4 then a.Amount else 0 end) as type4
,Sum(Case a.rootcode When 5 then a.Amount else 0 end) as type5
,Sum(Case a.rootcode When 7 then a.Amount else 0 end) as type6
,Sum(Amount) as Total 
from
(
select r.* ,
Case charindex('|',r.ord)
When 0 then r.ord 
Else ltrim(rtrim(substring(r.ord,0,charindex('|',r.ord))))End as rootcode from recCTE as r
where donate_id is not null  ) as a group by a.donate_id	
	RETURN
END


GO
/****** Object:  UserDefinedFunction [dbo].[GetAge]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create function [dbo].[GetAge]
(@in_DOB AS datetime,@now as datetime)

returns int

as

begin

DECLARE @age int

IF cast(datepart(m,@now) as int) > cast(datepart(m,@in_DOB) as int)

SET @age = cast(datediff(yyyy,@in_DOB,@now) as int)

else

IF cast(datepart(m,@now) as int) = cast(datepart(m,@in_DOB) as int)

IF datepart(d,@now) >= datepart(d,@in_DOB)

SET @age = cast(datediff(yyyy,@in_DOB,@now) as int)

ELSE

SET @age = cast(datediff(yyyy,@in_DOB,@now) as int) -1

ELSE

SET @age = cast(datediff(yyyy,@in_DOB,@now) as int) - 1

RETURN @age

end



GO

/****** Object:  UserDefinedFunction [dbo].[GetFamilyList]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetFamilyList] 
(
	@familycode int 
)
RETURNS nvarchar(max)
AS
BEGIN

DECLARE @list nvarchar(max), @ID int

SET @list = ''
select  @list = COALESCE(@list + '|', '')+' ('+ c.relationship+') ' +  c.last_name +c.first_name +' '
From  dbo.memberview as c where c.family_code =@familycode

RETURN @list

END


GO





/****** Object:  UserDefinedFunction [dbo].[GetPeriod]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create function [dbo].[GetPeriod]    (@fromdt datetime, @todt datetime)
returns  varchar(42) as
begin
declare @d datetime, @sgn char(1), @i int
if @fromdt>@todt
 select @d=@fromdt, @fromdt=@todt, @todt=@d, @sgn='-' --swap dates
else
 set @sgn=''
select @todt=case when @fromdt>dateadd(dd,-datediff(dd,@fromdt,@todt),@todt)
                 then dateadd(dd,-1,@todt) else @todt end
,@i=case when datepart(dd,@todt)<datepart(dd,@fromdt) then 1 else 0 end
return ( select @sgn
 +convert(varchar(4),(datediff(mm,@fromdt,@todt)-@i)/12)+' Years '
 +convert(varchar(2),(datediff(mm,@fromdt,@todt)-@i)%12)+' Months '
 +convert(varchar(2),datediff(dd,dateadd(mm,
        (datediff(mm,@fromdt,@todt)-@i),@fromdt),@todt))+' Days '
 +right(convert(char(23)
    ,dateadd(ms,datediff(ms,@fromdt,dateadd(dd,-datediff(dd,@fromdt,@todt),@todt)),0)
    ,21),12)
)
end

GO
/****** Object:  UserDefinedFunction [dbo].[ufcell_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[ufcell_get] 
(
 @root int
)
RETURNS  @list Table 
(
	code int,
	cell nvarchar(150),
	parentid int,
	sort nvarchar(max),
	depth int 
)
AS
Begin
	WITH cts AS 
		(
			SELECT 
					code 
				,	[name]
				,	parent_code = isnull(parent_code,0)
				,	L=1
				,	sort=cast([name] as nvarchar(1024))
				,	[row_status]
			FROM cell  
			Where  
					code   = case when @root = 0 then code  else @root end
			ANd		isnull(parent_code,0) = case When @root <> 0 then isnull(parent_code,0) else 0 End	
		UNION ALL
			SELECT
				c.code
			,	c.name
			,	c.parent_code
			,	p.L+1
			,	sort = cast(sort+' | '+c.[name] as nvarchar(1024))
			,	c.row_status
			FROM 
				cell c 
			Inner JOIN cts p ON p.code = c.parent_code 
) 
	Insert into @list
			Select  
				code
			,	REPLICATE('--', L)+' '+[name] as name
			,	parent_code
			,	sort
			,	L
		From cts
		Where row_status <> 'D'
		Order by sort asc;

		    if(@root = 0 )
	  Begin
	  Insert into @list 
		Values
		(
			0,'',0,'',0
		)
	 End
RETURN 
END

GO
/****** Object:  UserDefinedFunction [dbo].[ufcourse_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[ufcourse_get] 
(
 @root int
)
RETURNS  @list Table 
(
	code int,
	name nvarchar(150),
	parentid int,
	sort nvarchar(max)
)
AS
Begin
	WITH cts AS 
		(
			SELECT 
					code 
				,	[name]
				,	 parent_code
				,	L=1
				,	sort=cast([name] as nvarchar(1024))
				,	[row_status]
			FROM dbo.courses 
			Where  
					code   = case when @root = 0 then code  else @root end
			ANd		isnull(parent_code,0) = case When @root <> 0 then isnull(parent_code,0) else 0 End	
		UNION ALL
			SELECT
				c.code
			,	c.name
			,	c.parent_code
			,	p.L+1
			,	sort = cast(sort+' | '+c.[name] as nvarchar(1024))
			,	c.row_status
			FROM 
				dbo.courses  c 
			Inner JOIN cts p ON p.code = c.parent_code 
) 
	Insert into @list
		Select  
				code
			,	REPLICATE('--', L-1)+' '+[name] as name
			,	parent_code
			,	sort
		From cts
		Where row_status <> 'D'
		Order by sort asc;
   
    if(@root = 0 )
	  Begin
	  Insert into @list 
		Values
		(
			0,'',0,''
		)
	 End
RETURN 
END

GO
/****** Object:  UserDefinedFunction [dbo].[ufdonatetype_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[ufdonatetype_get]
(
 @root int
)
RETURNS  @donatetypes Table 
(
	code int,
	typename nvarchar(45),
	parentcode int,
	type_level int
)
AS
Begin
WITH cts AS 
	(
		SELECT 
			code 
		,	[name]
		,  parent_code = isnull(parent_code,0)
		,	L=1
		,	sort=cast([name] as nvarchar(1024))
		,	Level1 = Case When parent_code is null Then code Else parent_code End
		FROM donate_types 
		Where  code   = case when @root = 0 then code  else @root end
	    ANd  isnull(parent_code,0) = case When @root <> 0 then isnull(parent_code,0) else 0 End	
	UNION ALL
		SELECT
			c.code
		,	c.[name]
		,	c.parent_code 
		,	p.L+1
		,	sort = cast(sort+' | '+c.[name] as nvarchar(1024))
		,    Level1 = Case When L <> 1 Then p.parent_code else c.parent_code End
		FROM donate_types c 
			Inner JOIN cts p 
			ON p.code = c.parent_code 
	)

	Insert @donatetypes 
		Select  
					code 
				,	REPLICATE('--', L-1)+' '+[name] as name
				,	Level1 
				,	L 
			From cts

RETURN 
END


GO
/****** Object:  UserDefinedFunction [dbo].[uffellowship_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[uffellowship_get] 
(
 @root int
)
RETURNS  @list Table 
(
	code int,
	fellowship nvarchar(150),
	parentid int,
	sort nvarchar(max)
)
AS
Begin
	WITH cts AS 
		(
			SELECT 
					code 
				,	[name]
				,	parent_code = isnull(parent_code,0)
				,	L=1
				,	sort=cast([name] as nvarchar(1024))
				,	row_status
			FROM fellowship  
			Where  
					code   = case when @root = 0 then code  else @root end
			ANd		isnull(parent_code,0) = case When @root <> 0 then isnull(parent_code,0) else 0 End	
		UNION ALL
			SELECT
				c.code
			,	c.name
			,	c.parent_code
			,	p.L+1
			,	sort = cast(sort+' | '+c.[name] as nvarchar(1024))
			,	c.row_status
			FROM 
				fellowship c 
			Inner JOIN cts p ON p.code = c.parent_code 
) 
	Insert into @list
		Select  
				code
			,	REPLICATE('-', L-1)+' '+[name] as name
			,	parent_code
			,	sort
		From cts
		Where row_status <> 'D'
		Order by sort asc;

     if(@root = 0 )
	  Begin
	  Insert into @list 
		Values
		(
			0,'',0,''
		)
	 End
RETURN 
END

GO
/****** Object:  UserDefinedFunction [dbo].[ufministry_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[ufministry_get] 
(
 @root int
)
RETURNS  @list Table 
(
	code int,
	name nvarchar(150),
	parentid int
)
AS
Begin
	WITH cts AS 
		(
			SELECT 
					code 
				,	[name]
				,	parent_code = isnull(parent_code,0)
				,	L=1
				,	sort=cast([name] as nvarchar(1024))
				,	[row_status]
			FROM dbo.ministry  
			Where  
					code   = case when @root = 0 then code  else @root end
			ANd		isnull(parent_code,0) = case When @root <> 0 then isnull(parent_code,0) else 0 End	
		UNION ALL
			SELECT
				c.code
			,	c.name
			,	p.parent_code
			,	p.L+1
			,	sort = cast(sort+' | '+c.[name] as nvarchar(1024))
			,	c.row_status
			FROM 
				dbo.ministry c 
			Inner JOIN cts p ON p.code = c.parent_code 
) 
	Insert into @list
		Select  
				code
			,	REPLICATE('-', L-1)+' '+[name] as name
			,	parent_code
		From cts
		Where row_status <> 'D'
		Order by sort asc;

RETURN 
END

GO
/****** Object:  UserDefinedFunction [dbo].[ufsubDivision_get]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[ufsubDivision_get] 
(
 @root int
)
RETURNS  @list Table 
(
	id int,
	name nvarchar(150),
	parentid int
)
AS
Begin


		  Insert into @list 
		Values
		(
			0,'',0
		)
	;WITH cts AS 
		(
			SELECT 
					id 
				,	[name]
				,	parent_id = isnull(parent_id,0)
				,	L=1
				,	sort=cast([name] as nvarchar(1024))
				,	[row_status]
			FROM dbo.sub_division
			Where  
					id   = case when @root = 0 then id  else @root end
			ANd		isnull(parent_id,0) = case When @root <> 0 then isnull(parent_id,0) else 0 End	
		UNION ALL
			SELECT
				c.id
			,	c.name
			,	p.parent_id
			,	p.L+1
			,	sort = cast(sort+' | '+c.[name] as nvarchar(1024))
			,	c.row_status
			FROM 
				dbo.sub_division c
			Inner JOIN cts p ON p.id = c.parent_id 
) 
	Insert into @list
		Select  
				id
			,	sort
			,	parent_id
		From cts
		Where row_status <> 'D'
		Order by sort asc;
		 
		
RETURN 
END

GO
/****** Object:  View [dbo].[memberview]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[memberview]
AS
SELECT        dbo.members.first_name, dbo.members.last_name, dbo.members.en_first_name, dbo.members.en_last_name, dbo.members.email, dbo.members.cell, 
                         dbo.members.sex, dbo.members.married, dbo.members.family_code, dbo.members.birthday, dbo.members.regdate, dbo.members.baptism_year, dbo.members.job,
                             (SELECT        last_name + first_name AS Expr1
                               FROM            dbo.members AS f
                               WHERE        (id = dbo.members.spouse)) AS spousename, dbo.address.address, dbo.address.city, dbo.address.zipcode, dbo.address.statecode, 
                         dbo.address.home, dbo.members.address_id, dbo.members.id, dbo.members.entrytype, dbo.members.jobtype, dbo.members.spouse, dbo.members.active, 
                         dbo.member_details.FamilyName AS family_name, dbo.member_details.CellCode AS cell_code, dbo.member_details.FellowshipStartdate AS fellowship_date, 
                         dbo.member_details.FellowshipCode AS fellowship_code, dbo.member_details.StatusCode, dbo.member_details.StatusChanged AS status_date, 
                         dbo.member_details.StatusName, dbo.member_details.FellowshipName, dbo.member_details.Relationship, dbo.members.subdiv_id, dbo.members.baptism_id, 
                         dbo.members.family_relationship, dbo.type_baptism.name AS BaptismName, dbo.sub_division.name AS SubDivisionName, dbo.member_details.CellName, 
                         dbo.member_details.CellRoleCode, dbo.members.work_phone
FROM            dbo.member_details INNER JOIN
                         dbo.members ON dbo.member_details.MemberId = dbo.members.id LEFT OUTER JOIN
                         dbo.sub_division ON dbo.members.subdiv_id = dbo.sub_division.id LEFT OUTER JOIN
                         dbo.type_baptism ON dbo.members.baptism_id = dbo.type_baptism.id LEFT OUTER JOIN
                         dbo.address ON dbo.members.address_id = dbo.address.id

GO
/****** Object:  View [dbo].[viewVisitReport]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewVisitReport]
AS
SELECT        dbo.memberview.first_name, dbo.memberview.last_name, dbo.member_visit.visitdate, dbo.member_visit.song, dbo.member_visit.bible, 
                         dbo.member_visit.attendent, dbo.member_visit.contents, dbo.member_visit.pastor, dbo.member_visit.id, dbo.member_visit.memberid, dbo.memberview.CellName, 
                         dbo.memberview.sex, dbo.memberview.cell, dbo.memberview.married, dbo.memberview.regdate, dbo.memberview.email, dbo.memberview.address, 
                         dbo.memberview.city, dbo.memberview.zipcode, dbo.memberview.statecode, dbo.memberview.spousename, dbo.memberview.home, dbo.memberview.StatusName, 
                         dbo.memberview.FellowshipName, dbo.memberview.Relationship, dbo.memberview.cell_code, dbo.member_visit.visittype, dbo.member_visit.create_by
FROM            dbo.memberview INNER JOIN
                         dbo.member_visit ON dbo.memberview.id = dbo.member_visit.memberid

GO
/****** Object:  View [dbo].[viewDonateMember]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewDonateMember]
AS
SELECT        dbo.address.address, dbo.address.city, dbo.address.statecode, dbo.address.zipcode, dbo.address.home, dbo.donate_members.oldno, 
                         dbo.donate_members.regdate, dbo.donate_members.memo, dbo.donate_members.address_id, dbo.donate_members.en_last, dbo.donate_members.en_first, 
                         dbo.donate_members.name, dbo.donate_members.member_id, dbo.donate_members.en_last + dbo.donate_members.en_first AS en_name, 
                         dbo.memberview.spouse, dbo.memberview.spousename, dbo.donate_members.id, dbo.memberview.active, dbo.memberview.cell, 
                         dbo.donate_members.lastchanged, dbo.memberview.fellowship_code, (CASE WHEN isnull(dbo.donate_members.member_id, 0) > 10000 THEN 'M' ELSE 'I' END) 
                         AS membertype
FROM            dbo.donate_members INNER JOIN
                         dbo.address ON dbo.donate_members.address_id = dbo.address.id LEFT OUTER JOIN
                         dbo.memberview ON dbo.donate_members.member_id = dbo.memberview.id

GO
/****** Object:  View [dbo].[viewCellMember]    Script Date: 7/23/2014 12:09:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewCellMember]
AS
SELECT        dbo.member_cell.*, dbo.cell_roles.name AS role_name, dbo.cell.name AS cell_name, dbo.cell.parent_code, dbo.cell_roles.levels, dbo.memberview.first_name, 
                         dbo.memberview.last_name, dbo.memberview.en_first_name, dbo.memberview.en_last_name, dbo.memberview.email, dbo.memberview.sex, dbo.memberview.cell, 
                         dbo.memberview.married, dbo.memberview.family_code, dbo.memberview.birthday, dbo.memberview.regdate, dbo.memberview.baptism_year, 
                         dbo.memberview.spousename, dbo.memberview.job, dbo.memberview.address, dbo.memberview.city, dbo.memberview.zipcode, dbo.memberview.statecode, 
                         dbo.memberview.home, dbo.memberview.entrytype, dbo.memberview.jobtype, dbo.memberview.active, dbo.memberview.spouse, dbo.memberview.family_name, 
                         dbo.memberview.fellowship_date, dbo.memberview.fellowship_code, dbo.memberview.StatusCode, dbo.memberview.status_date, dbo.memberview.StatusName, 
                         dbo.memberview.FellowshipName, dbo.memberview.Relationship, dbo.memberview.subdiv_id, dbo.memberview.baptism_id, dbo.memberview.family_relationship, 
                         dbo.memberview.BaptismName, dbo.memberview.SubDivisionName
FROM            dbo.cell INNER JOIN
                         dbo.member_cell ON dbo.cell.code = dbo.member_cell.cell_code INNER JOIN
                         dbo.cell_roles ON dbo.member_cell.role_code = dbo.cell_roles.code INNER JOIN
                         dbo.memberview ON dbo.member_cell.memberid = dbo.memberview.id

GO
