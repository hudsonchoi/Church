/****** Object:  Table [dbo].[service_time_places]    Script Date: 1/26/2019 2:03:15 PM ******/
DROP TABLE [dbo].[service_time_places]
GO

/****** Object:  Table [dbo].[service_time_places]    Script Date: 1/26/2019 2:03:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[service_time_places](
	[id] [int] NOT NULL,
	[time] [varchar](10) NULL,
	[place] [varchar](50) NULL
) ON [PRIMARY]
GO


