USE [ManagerSystem]
GO
/****** Object:  Table [dbo].[student]    Script Date: 2023/03/21 23:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[stname] [varchar](50) NULL,
	[course] [varchar](50) NULL,
	[fee] [int] NULL
) ON [PRIMARY]
GO
