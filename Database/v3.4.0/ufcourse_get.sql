/****** Object:  UserDefinedFunction [dbo].[ufcourse_get]    Script Date: 12/1/2018 4:16:50 PM ******/
DROP FUNCTION [dbo].[ufcourse_get]
GO

/****** Object:  UserDefinedFunction [dbo].[ufcourse_get]    Script Date: 12/1/2018 4:16:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[ufcourse_get] 
(
 @root int
)
RETURNS  @list Table 
(
	code int,
	name nvarchar(150),
	parentid int,
	sort nvarchar(max),
	start_date datetime,
	end_date datetime,
	teacher_name nvarchar(150),
	lecture_period_week int
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
				,   [start_date] -- Add the academy schema Landwin3.4.0
				,	[end_date]
				,	[teacher_name]
				,	[lecture_period_week]
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
			,   c.[start_date] -- Add the academy schema Landwin3.4.0
			,	c.[end_date]
			,	c.[teacher_name]
			,	c.[lecture_period_week]
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
			,   [start_date] -- Add the academy schema Landwin3.4.0
			,	[end_date]
			,	[teacher_name]
			,	[lecture_period_week]
		From cts
		Order by sort asc;
   
    if(@root = 0 )
	  Begin
	  Insert into @list 
		Values
		(
			0,'',0,'','','','',''
		)
	 End
RETURN 
END

GO


