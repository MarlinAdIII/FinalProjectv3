/****** Object:  Table [dbo].[BRAIDER]    Script Date: 11/21/2018 11:31:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BRAIDER](
	[IDBraider] [int] IDENTITY(1,1) NOT NULL,
	[FnameBraider] [varchar](50) NOT NULL,
	[MnameBraider] [varchar](50) NULL,
	[LnameBraider] [varchar](50) NOT NULL,
	[PhoneBraider] [varchar](14) NULL,
	[CelBraider] [varchar](14) NULL,
	[StreetBraider] [varchar](50) NULL,
	[CountyBraider] [varchar](30) NULL,
	[ZipCodeBraider] [smallint] NULL,
	[EmailBraider] [varchar](50) NULL,
	[IDUserBraider] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_BRAIDER] PRIMARY KEY CLUSTERED 
(
	[IDBraider] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

