

USE CHODAE_ORG
Go


Drop Table [dbo].[status_reason]

/**---- Migration Sub_division TYPE  **/

ALTER TABLE [dbo].[sub_division]
  ADD 
		[lastchanged] [timestamp] NULL,
		[row_status] [char](1) NULL,
		[create_by] [nvarchar](150) NULL,
		[create_date] [datetime] NULL,
		[update_by] [nvarchar](150) NULL,
		[update_date] [datetime] NULL;
GO

ALTER TABLE [dbo].[sub_division] Alter COLUMN name [nvarchar](150);
GO

EXEC sp_rename 'dbo.sub_division.code', 'id', 'COLUMN';
GO
EXEC sp_rename 'dbo.sub_division.parent_code', 'parent_id', 'COLUMN';
GO

ALTER TABLE [dbo].[sub_division] DROP COLUMN [div_code] ;
GO

Update [dbo].[sub_division]
	Set
		row_status = 'C'
	,	Create_date = GetDate()
	,	Create_by = 'Admin'
/**---- Migration JOB TYPE  **/

ALTER TABLE [dbo].[type_job]
  ADD 
		[lastchanged] [timestamp] NULL,
		[row_status] [char](1) NULL,
		[update_by] [nvarchar](150) NULl,
		[update_date] [datetime] NULL;
GO

ALTER TABLE [dbo].[type_job] Alter COLUMN jobclass [nvarchar](150);
GO

EXEC sp_rename 'dbo.type_job.jobclass', 'name', 'COLUMN';
GO

ALTER TABLE [dbo].[type_job] DROP COLUMN [div] ;
GO

Update dbo.type_job 
	Set
		row_status = 'C'
	,	update_date = GetDate()
	,	update_by = 'Admin'

/**---- Migration baptism TYPE  **/


ALTER TABLE [dbo].[type_baptism]
  ADD 
		[lastchanged] [timestamp] NULL,
		[row_status] [char](1) NULL,
		[update_by] [nvarchar](150) NULl,
		[update_date] [datetime] NULL;
GO

ALTER TABLE [dbo].[type_baptism] Alter COLUMN name [nvarchar](150);
GO

EXEC sp_rename 'dbo.type_baptism.code', 'id', 'COLUMN';
GO

ALTER TABLE [dbo].[type_baptism] DROP COLUMN [div_code] ;
GO

Update [dbo].[type_baptism] 
	Set
		row_status = 'C'
	,	update_date = GetDate()
	,	update_by = 'Admin'



/**---- Migration Relationship TYPE  **/



ALTER TABLE [dbo].[type_relationship]
  ADD 
	[lastchanged] [timestamp] NULL,
		[row_status] [char](1) NULL,
		[update_by] [nvarchar](150) NULl,
		[update_date] [datetime] NULL;
GO

ALTER TABLE [dbo].[type_relationship] Alter COLUMN name [nvarchar](150);
GO

EXEC sp_rename 'dbo.type_relationship.code', 'id', 'COLUMN';
GO



Update [dbo].[type_relationship] 
	Set
		row_status = 'C'
	,	update_date = GetDate()
	,	update_by = 'Admin'


/**---- Migration Status TYPE  **/



ALTER TABLE [dbo].[type_status]
  ADD 
	[lastchanged] [timestamp] NULL,
		[row_status] [char](1) NULL,
		[update_by] [nvarchar](150) NULl,
		[update_date] [datetime] NULL;
GO

ALTER TABLE [dbo].[type_status] Alter COLUMN name [nvarchar](150);
GO

EXEC sp_rename 'dbo.type_status.parent_code', 'is_active', 'COLUMN';
GO
EXEC sp_rename 'dbo.type_status.code', 'id', 'COLUMN';
GO

ALTER TABLE [dbo].[type_status] DROP COLUMN [div] ;
GO

Update [dbo].[type_status] 
	Set
		row_status = 'C'
	,	update_date = GetDate()
	,	update_by = 'Admin'
Go



	/**---- Migration Visit TYPE  **/
	
ALTER TABLE [dbo].[type_entry]
  ADD
		[lastchanged] [timestamp] NULL,
	[row_status] [char](1) NULL,
	[update_by] [nvarchar](150) NULL,
	[update_date] [datetime] NULL;
Go
EXEC sp_rename 'dbo.type_entry.entrytype', 'name', 'COLUMN';
GO
ALTER TABLE [dbo].[type_visit]
  ADD 
	[lastchanged] [timestamp] NULL,
		[row_status] [char](1) NULL,
		[update_by] [nvarchar](150) NULl,
		[update_date] [datetime] NULL;
GO

ALTER TABLE [dbo].[type_visit] Alter COLUMN name [nvarchar](150);
GO




ALTER TABLE [dbo].[type_visit] DROP COLUMN [div] ;
GO

Update [dbo].[type_visit] 
	Set
		row_status = 'C'
	,	update_date = GetDate()
	,	update_by = 'Admin'



		/**---- Migration Address  **/



ALTER TABLE [dbo].[address]
  ADD 
	[lastchanged] [timestamp] NULL,
		[update_by] [nvarchar](150) NULl,
		[update_date] [datetime] NULL;
GO

ALTER TABLE [dbo].[address] Alter COLUMN [address] [nvarchar](250);
ALTER TABLE [dbo].[address] Alter COLUMN city [nvarchar](150);
ALTER TABLE [dbo].[address] Alter COLUMN statecode [varchar](2);
ALTER TABLE [dbo].[address] Alter COLUMN zipcode [varchar](5);
GO



Update [dbo].[address] 
	Set
		update_date = GetDate()
	,	update_by = 'Admin'



		/**---- Migration cell  **/

EXEC sp_rename 'dbo.cell.startdate', 'create_date', 'COLUMN';
GO
EXEC sp_rename 'dbo.cell.enddate', 'update_date', 'COLUMN';
GO

ALTER TABLE [dbo].[cell]
  ADD 
	[row_status] [char](1) NULL,
	[update_by] [nvarchar](150) NULL,
		[create_by] [nvarchar](150) NULL;
GO

ALTER TABLE [dbo].[cell] Alter COLUMN [name] [nvarchar](150);
GO


ALTER TABLE [dbo].[cell] DROP COLUMN [mission] ;
GO
ALTER TABLE [dbo].[cell] DROP COLUMN [div_code] ;
GO

Update [dbo].[cell] 
	Set
		row_status = 'C'
	,	create_by = 'Admin'
	,	update_by = 'Admin'
	Where 
		update_date is null 
GO

Update [dbo].[cell] 
	Set
		row_status = 'D'
	,	create_by = 'Admin'
	,	update_by = 'Admin'
	Where 
		update_date is not null 
Go


	/**---- Migration Cell Roelw TYPE  **/

	


ALTER TABLE [dbo].[cell_roles]
  ADD 
	[lastchanged] [timestamp] NULL,
		[row_status] [char](1) NULL,
		[update_by] [nvarchar](150) NULl,
		[update_date] [datetime] NULL,
		[create_by] [nvarchar](150) NULl,
		[create_date] [datetime] NULL;
GO




ALTER TABLE [dbo].[cell_roles] DROP COLUMN [div_code] ;
GO

Update [dbo].[cell_roles] 
	Set
		row_status = 'C'
	,	create_date = GetDate()
	,	create_by = 'Admin'

Go

ALTER TABLE [dbo].[cell_user]
  ADD 
		[lastchanged] [timestamp] NULL,
		[update_by] [nvarchar](150) NULl,
		[update_date] [datetime] NULL;
GO

Update [dbo].[cell_user] 
	Set
		update_date = GetDate()
	,	update_by = 'Admin'

Go



	/**---- Migration Chuarch  **/



ALTER TABLE [dbo].[church]
  ADD 
		[sign_image] [image] NULL,
		[address2] [nvarchar](50) NULL,
		[lastchanged] [timestamp] NULL,
		[row_status] [char](1) NULL,
		[update_by] [nvarchar](150) NULL,
		[update_date] [datetime] NULL,
		[fax] [varchar](15) NULL;
GO

ALTER TABLE [dbo].[church] Alter COLUMN [telephone] [varchar](50);
GO
ALTER TABLE [dbo].[church] Alter COLUMN [tax_id] [varchar](15);
GO



Update [dbo].[church] 
	Set
		update_date = GetDate()
	,	update_by = 'Admin'
	
GO


/**---- Migration Comment **/




ALTER TABLE [dbo].[comments]
  ADD 
	[row_status] [char](1) NULL,
	[create_date] [datetime] NULL,
	[update_by] [nvarchar](150) NULL;
GO

ALTER TABLE [dbo].[comments] Alter COLUMN [create_by] [nvarchar](150);
GO


Update [dbo].[comments] 
	Set
		row_status = 'C'


	/**---- Migration [dbo].[courses] **/




ALTER TABLE [dbo].[courses]
  ADD 
	[row_status] [char](1) NULL,
	[update_date] [datetime] NULL,
	[update_by] [nvarchar](150) NULL;
GO

/**---- Migration [dbo].[donate_books] **/
ALTER TABLE [dbo].[donate_books]
  ADD 
	[check_count] [int] NULL,
	[row_status] [char](1) NULL,
	[create_by] [nvarchar](150) NULL,
	[update_date] [datetime] NULL,
	[update_by] [nvarchar](150) NULL;
GO
EXEC sp_rename 'dbo.donate_books.createdate', 'create_date', 'COLUMN';
GO

/**---- Migration [dbo].[donate_members] **/
ALTER TABLE [dbo].[donate_members]
  ADD 
	[row_status] [char](1) NULL;
GO

Update  [dbo].[donate_members]
	Set
		row_status = 'C'

GO
/**---- Migration [dbo].[donate_types] **/

ALTER TABLE [dbo].[donate_types]
  ADD 
	[lastchanged] [timestamp] NULL,
	[row_status] [char](1) NULL,
	[update_date] [datetime] NULL,
	[update_by] [nvarchar](150) NULL;
GO


ALTER TABLE [dbo].[donate_types] Drop COLUMN [div_code] ;
GO

Update  [dbo].[donate_types]
	Set
		row_status = 'C'

GO
/**---- Migration [dbo].[donates][ **/

EXEC sp_rename 'dbo.donates.createdate', 'create_date', 'COLUMN';
GO
ALTER TABLE [dbo].[donates]
  ADD 
	[create_by] [nvarchar](150) NULL,
	[row_status] [char](1) NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
	[update_by] [nvarchar](150) NULL,
	[donate_year] [int];
GO

Update  [dbo].[donates]
	Set
			row_status = 'C'
		,	donate_year = Year(donate_date)

GO
/**---- Migration [dbo].[fellowship] **/

ALTER TABLE [dbo].[fellowship]
  ADD 
	[lastchanged] [timestamp] NULL,
	[create_by] [nvarchar](150) NULL,
	[row_status] [char](1) NULL,
	[update_date] [datetime] NULL,
	[update_by] [nvarchar](150) NULL,
	[create_date][datetime] NULL;
GO


ALTER TABLE [dbo].[fellowship] Alter COLUMN [status] bit;
Go
ALTER TABLE [dbo].[fellowship] Alter COLUMN [name] [nvarchar](100);
Go
ALTER TABLE [dbo].[fellowship] Drop COLUMN div_code;
GO
ALTER TABLE [dbo].[fellowship] Drop COLUMN list_order;
Go

/**---- Migration [dbo].[member_cell] **/


ALTER TABLE [dbo].[member_cell]
  ADD 
	[create_by] [nvarchar](150) NULL,
	[row_status] [char](1) NULL,
	[update_date] [datetime] NULL,
	[update_by] [nvarchar](150) NULL,
	[create_date][datetime] NULL;
GO
EXEC sp_rename 'dbo.member_cell.member_id', 'memberid', 'COLUMN';
GO


Update dbo.member_cell
	set
		row_status = 'C'
		,create_date = getdate()
		,create_by = 'Admin'

Go
/**---- Migration [dbo].[member_course] **/


ALTER TABLE [dbo].[member_course]
  ADD 
	[lastchanged] [timestamp] NULL,
	[row_status] [char](1) NULL,
	[update_date] [datetime] NULL,
	[update_by] [nvarchar](150) NULL;

GO

ALTER TABLE [dbo].[member_course] Drop COLUMN course_name;
GO

/**---- Migration [dbo].[member_details] **/

/**---- Migration [dbo].[member_fellowship] **/

ALTER TABLE [dbo].[member_fellowship]
  ADD 
	[lastchanged] [timestamp] NULL,
	[row_status] [char](1) NULL,
	[update_date] [datetime] NULL,
	[update_by] [nvarchar](150) NULL;

GO

EXEC sp_rename 'dbo.member_fellowship.member_id', 'memberid', 'COLUMN';
GO
/**---- Migration [dbo].[member_ministry] **/
ALTER TABLE [dbo].[member_ministry]
  ADD 
	[row_status] [char](1) NULL,
	[update_date] [datetime] NULL,
	[update_by] [nvarchar](150) NULL;

GO
EXEC sp_rename 'dbo.member_ministry.member_id', 'memberid', 'COLUMN';
GO


ALTER TABLE  [dbo].[member_ministry] Drop COLUMN role_name;

ALTER TABLE  [dbo].[member_ministry]  Drop COLUMN ministry_name;
GO
/**---- Migration [dbo].[member_status] **/
ALTER TABLE [dbo].[member_status]
  ADD 
	[update_date] [datetime] NULL,
	[update_by] [nvarchar](150) NULL;

GO
/**---- Migration [dbo].[member_visit] **/

ALTER TABLE [dbo].[member_visit]
  ADD 
	[row_status] [char](1) NULL,
	[lastchanged] [timestamp] NULL,
	[create_date] [datetime] NULL,
	[create_by] [nvarchar](150) NULL,
	[update_date] [datetime] NULL,
	[update_by] [nvarchar](150) NULL;

GO

ALTER TABLE  [dbo].[member_visit] Drop COLUMN div;
GO
/**---- Migration [dbo].[members] **/


EXEC sp_rename 'dbo.members.work', 'work_phone', 'COLUMN';
GO
EXEC sp_rename 'dbo.members.subdiv_code', 'subdiv_id', 'COLUMN';
GO
EXEC sp_rename 'dbo.members.baptism_code', 'baptism_id', 'COLUMN';
GO
ALTER TABLE [dbo].[members]
  ADD 
	[row_status] [char](1) NULL,
	[lastchanged] [timestamp] NULL,
	[create_date] [datetime] NULL,
	[create_by] [nvarchar](150) NULL,
	[update_date] [datetime] NULL,
	[update_by] [nvarchar](150) NULL;

GO

ALTER TABLE  [dbo].[members] Drop COLUMN div_code;
GO
ALTER TABLE [dbo].[members] Drop COLUMN picture;
GO

	UPdate dbo.members
	Set
		row_status = 'C'
		,create_date = GetDate()
		,create_by = 'Admin'
Go
/**---- Migration [dbo].[ministry] **/


ALTER TABLE [dbo].[ministry]
  ADD 
	[row_status] [char](1) NULL,
	[lastchanged] [timestamp] NULL,
	[create_by] [nvarchar](150) NULL,
	[update_by] [nvarchar](150) NULL;

GO


ALTER TABLE  [dbo].[ministry] Drop COLUMN div_code;
GO


/**---- Migration [dbo].[ministry_roles] **/

ALTER TABLE [dbo].[ministry_roles]
  ADD 
	[create_by] [nvarchar](150) NULL,
	[update_by] [nvarchar](150) NULL,
	[update_date] [datetime] NULL,
	[row_status] [char](1) NULL,
	[lastchanged] [timestamp] NULL,
	[create_date] [datetime] NULL;

GO


EXEC sp_rename 'dbo.ministry_roles.default_level', 'isdefault', 'COLUMN';
GO

Update dbo.ministry_roles
	set
		row_status = Case When [status] = 0 Then 'C' Else 'D' End
	,	create_by = 'Admin'
	,	create_date = GetDate()
Go

/**---- Migration [dbo].[rpt_cell] **/
EXEC sp_rename 'dbo.rpt_cell.CellCode', 'cell_code', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell.RegDate', 'reg_date', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell.CellDate', 'cell_date', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell.Cellplace', 'cell_place', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell.NewMember', 'new_member', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell.Leader', 'leader', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell.Prayer', 'prayer', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell.Memo', 'memo', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell.Request', 'request', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell.AttenFamily', 'atten_family_count', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell.Lastchanged', 'lastchanged', 'COLUMN';
GO


ALTER TABLE [dbo].[rpt_cell] 
  ADD 
	[recoder] [int] NULL,
	[update_date] [datetime] NULL,
	[update_by] [nvarchar](150) NULL,
	[row_status] [char](1) NULL,
	[total_family_count] [int] NULL,
	[cell_leader] [nvarchar](150) NULL,
	[cell_leader2] [nvarchar](150) NULL,
	[create_by] [nvarchar](150) NULL;

GO
	UPdate [dbo].[rpt_cell] 
	Set
		row_status = 'C'
Go
/**---- Migration [dbo].[rpt_cell_detail]**/

EXEC sp_rename 'dbo.rpt_cell_detail.MemberId', 'member_id', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell_detail.Attendance', 'attendance', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell_detail.Reason', 'reason', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell_detail.ReportId', 'parent_id', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell_detail.Memo', 'memo', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell_detail.RegDate', 'regdate', 'COLUMN';
GO
EXEC sp_rename 'dbo.rpt_cell_detail.no', 'id', 'COLUMN';
GO

ALTER TABLE [dbo].[rpt_cell_detail]
  ADD 
	[lastchanged] [timestamp] NULL,
	[role_level] [int] NULL,
	[role_code] [int] NULL,
	[row_status] [char](1) NULL;

GO


	UPdate [dbo].[rpt_cell_detail]
	Set
		row_status = 'C'


/**---- Migration [dbo].[status_log] **/


EXEC sp_rename 'dbo.status_log.no', 'id', 'COLUMN';
GO


ALTER TABLE [dbo].[status_log]
  ADD 
	[username] [varchar](150) NULL,
	[lastchanged] [timestamp] NULL;

GO
/**---- Migration [dbo].[users_master] **/


ALTER TABLE  [dbo].[users_master] Drop COLUMN memberid;
GO


ALTER TABLE [dbo].[users_master]
  ADD 
	[update_date] [datetime] NULL,
	[update_by] [nvarchar](150) NULL;

GO



EXEC sp_rename 'dbo.users_master.status', 'isActive', 'COLUMN';
GO






