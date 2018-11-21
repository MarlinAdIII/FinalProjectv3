/****** Object:  Table [dbo].[CLIENT]    Script Date: 11/21/2018 11:32:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CLIENT](
	[IDClient] [int] IDENTITY(1,1) NOT NULL,
	[FnameClient] [varchar](50) NOT NULL,
	[MnameClient] [varchar](50) NULL,
	[LnameClient] [varchar](50) NOT NULL,
	[PhoneClient] [varchar](14) NULL,
	[CelClient] [varchar](14) NULL,
	[StreetClient] [varchar](50) NOT NULL,
	[CountyClient] [varchar](30) NOT NULL,
	[ZipCodeClient] [smallint] NOT NULL,
	[EmailClient] [varchar](50) NULL,
	[IDUserClient] [nvarchar](128) NOT NULL,
	[StateClient] [char](2) NOT NULL,
 CONSTRAINT [PK_CLIENT] PRIMARY KEY CLUSTERED 
(
	[IDClient] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

