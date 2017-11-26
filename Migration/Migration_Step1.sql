/* Drop all non-system stored procs */
DECLARE @name VARCHAR(128)
DECLARE @SQL VARCHAR(254)

SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'P' AND category = 0 ORDER BY [name])

WHILE @name is not null
BEGIN
    SELECT @SQL = 'DROP PROCEDURE [dbo].[' + RTRIM(@name) +']'
    EXEC (@SQL)
    PRINT 'Dropped Procedure: ' + @name
    SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'P' AND category = 0 AND [name] > @name ORDER BY [name])
END
GO

/* Drop all views */
DECLARE @name VARCHAR(128)
DECLARE @SQL VARCHAR(254)

SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'V' AND category = 0 ORDER BY [name])

WHILE @name IS NOT NULL
BEGIN
    SELECT @SQL = 'DROP VIEW [dbo].[' + RTRIM(@name) +']'
    EXEC (@SQL)
    PRINT 'Dropped View: ' + @name
    SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'V' AND category = 0 AND [name] > @name ORDER BY [name])
END
GO

/* Drop all functions */
DECLARE @name VARCHAR(128)
DECLARE @SQL VARCHAR(254)

SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] IN (N'FN', N'IF', N'TF', N'FS', N'FT') AND category = 0 ORDER BY [name])

WHILE @name IS NOT NULL
BEGIN
    SELECT @SQL = 'DROP FUNCTION [dbo].[' + RTRIM(@name) +']'
    EXEC (@SQL)
    PRINT 'Dropped Function: ' + @name
    SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] IN (N'FN', N'IF', N'TF', N'FS', N'FT') AND category = 0 AND [name] > @name ORDER BY [name])
END
GO

/* Drop all Foreign Key constraints */
DECLARE @name VARCHAR(128)
DECLARE @constraint VARCHAR(254)
DECLARE @SQL VARCHAR(254)

SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' ORDER BY TABLE_NAME)

WHILE @name is not null
BEGIN
    SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
    WHILE @constraint IS NOT NULL
    BEGIN
        SELECT @SQL = 'ALTER TABLE [dbo].[' + RTRIM(@name) +'] DROP CONSTRAINT [' + RTRIM(@constraint) +']'
        EXEC (@SQL)
        PRINT 'Dropped FK Constraint: ' + @constraint + ' on ' + @name
        SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' AND CONSTRAINT_NAME <> @constraint AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
    END
SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' ORDER BY TABLE_NAME)
END
GO




Drop Trigger dbo.[member_details_cell_insert]
Go
DROP Trigger dbo.[member_details_cell_update]
GO





--- change table name   ----- 

EXEC sp_rename 'dbo.comments.username', 'create_by', 'COLUMN';
GO
EXEC sp_rename 'dbo.comments.lastupdate', 'update_date', 'COLUMN';
GO
EXEC sp_rename 'job_types', 'type_job' ;
Go
EXEC sp_rename 'relationShips', 'type_relationship';
GO
EXEC sp_rename 'status_codes', 'type_status';
GO
EXEC sp_rename 'visittype', 'type_visit';
GO
EXEC sp_rename 'baptism_codes', 'type_baptism';
GO
EXEC sp_rename 'entrytype', 'type_entry';
GO
EXEC sp_rename 'rpt_cellmember', 'rpt_cell_detail';
GO

EXEC sp_rename 'dbo.ministry.startdate', 'create_date', 'COLUMN';
GO
EXEC sp_rename 'dbo.ministry.enddate', 'update_date', 'COLUMN';
GO
EXEC sp_rename 'dbo.church.ChurchId', 'id', 'COLUMN';
GO
EXEC sp_rename 'dbo.church.ChurchName', 'name', 'COLUMN';
GO
EXEC sp_rename 'dbo.church.Address', 'address1', 'COLUMN';
GO
EXEC sp_rename 'dbo.church.City', 'city', 'COLUMN';
GO
EXEC sp_rename 'dbo.church.State', 'state', 'COLUMN';
GO
EXEC sp_rename 'dbo.church.Zipcode', 'zipcode', 'COLUMN';
GO
EXEC sp_rename 'dbo.church.Telephone', 'telephone', 'COLUMN';
GO
EXEC sp_rename 'dbo.church.Tax_Id', 'tax_id', 'COLUMN';
GO
EXEC sp_rename 'dbo.church.Signer', 'signer', 'COLUMN';
GO

EXEC sp_rename 'dbo.cell_roles.duplicated', 'multiple_assign', 'COLUMN';
GO
