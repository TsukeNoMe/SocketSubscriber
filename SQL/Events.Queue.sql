USE [WebsocketEvents]
GO

/****** Object:  Table [Events].[Queue]    Script Date: 3/24/2018 7:34:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Events].[Queue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](500) NULL,
	[DateAdded] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Events].[Queue] ADD  DEFAULT (getdate()) FOR [DateAdded]
GO


