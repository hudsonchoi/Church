
/****** Object:  UserDefinedFunction [dbo].[GetCellName]    Script Date: 2/8/2019 10:31:39 PM ******/
DROP FUNCTION [dbo].[GetCellName]
GO

/****** Object:  UserDefinedFunction [dbo].[GetCellName]    Script Date: 2/8/2019 10:31:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Hudson H Choi
-- Create date: 020819
-- Description:	Returns cell name per MemberID
-- =============================================
create function [dbo].[GetCellName]
(@memberID AS int)

returns varchar(10)

as

begin

DECLARE @cellName varchar(10)

select top 1 @cellName = c.name from cell c
inner join member_cell mc on c.code = mc.cell_code
where mc.memberid = @memberID and mc.enddate is null
order by startdate desc

RETURN @cellName

end




GO


