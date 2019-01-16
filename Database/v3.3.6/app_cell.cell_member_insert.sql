/****** Object:  StoredProcedure [app_cell].[cell_member_insert]    Script Date: 1/16/2019 5:37:25 AM ******/
DROP PROCEDURE [app_cell].[cell_member_insert]
GO

/****** Object:  StoredProcedure [app_cell].[cell_member_insert]    Script Date: 1/16/2019 5:37:25 AM ******/
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
,	@cellcode					int				=	0
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
				@cellcode		
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


	Update 
		dbo.Member_details 
	Set 
		CellCode = @cellcode 
	,	CellName = (Select name From dbo.cell Where code = @cellcode) 
	,	CellRoleCode = @rolecode 
	Where 
		memberid = @memberid

	-- Not needed as per all insert is 'member' by default 1/16/19
	--If(@roleCode <= 2)
	--Begin
	--	Delete From 
	--		 dbo.cell_user
	--		Where 
	--			cellcode = @cellcode
	--			And
	--			rolecode = @roleCode
		
	--		Insert Into dbo.cell_user
	--		(
	--				email
	--			,	password
	--			,	cellcode
	--			,	regdate
	--			,	memberid
	--			,	rolecode
	--		) 
	--		Select 
	--				isnull(ltrim(rtrim(m.email)),'')
	--			,	Replace((CONVERT(VARCHAR(20),m.birthday,101)),'/','')
	--			,	@cellcode
	--			,	GetDate()
	--			,	m.id 
	--			,	@rolecode
	--			From 
	--			memberview m 
	--			Where 
	--				m.id = @memberid 
	--END


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


