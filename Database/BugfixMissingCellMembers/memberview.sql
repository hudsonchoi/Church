
/****** Object:  View [dbo].[memberview]    Script Date: 2/1/2019 1:58:35 AM ******/
DROP VIEW [dbo].[memberview]
GO

/****** Object:  View [dbo].[memberview]    Script Date: 2/1/2019 1:58:35 AM ******/
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
FROM            dbo.members LEFT OUTER JOIN --Fixed to include everyone 02012019
                         dbo.member_details ON dbo.member_details.MemberId = dbo.members.id LEFT OUTER JOIN
                         dbo.sub_division ON dbo.members.subdiv_id = dbo.sub_division.id LEFT OUTER JOIN
                         dbo.type_baptism ON dbo.members.baptism_id = dbo.type_baptism.id LEFT OUTER JOIN
                         dbo.address ON dbo.members.address_id = dbo.address.id


GO


