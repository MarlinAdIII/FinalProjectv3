/****** Object:  Table [dbo].[VENDOR]    Script Date: 11/21/2018 11:36:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VENDOR](
	[IDVendor] [int] IDENTITY(1,1) NOT NULL,
	[TitleVendor] [varchar](70) NOT NULL,
	[PhoneOffice] [varchar](14) NULL,
	[PhoneCell] [varchar](14) NULL,
	[StreetVendor] [varchar](50) NULL,
	[CountyVendor] [varchar](30) NULL,
	[ZipCodeVendor] [smallint] NULL,
	[StateVendor] [char](2) NULL,
	[EmailVendor] [varchar](50) NULL,
	[WebSiteVendor] [varchar](50) NULL,
 CONSTRAINT [PK_VENDOR] PRIMARY KEY CLUSTERED 
(
	[IDVendor] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

