/****** Object:  Table [dbo].[COMPANY]    Script Date: 11/21/2018 11:32:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[COMPANY](
	[IDComp] [tinyint] IDENTITY(1,1) NOT NULL,
	[TitleComp] [varchar](50) NULL,
	[PhoneOffice] [varchar](14) NULL,
	[PhoneOwner] [varchar](14) NULL,
	[StreetComp] [varchar](50) NULL,
	[CountyComp] [varchar](30) NULL,
	[ZipcodeComp] [smallint] NULL,
	[EmailComp] [varchar](50) NULL,
	[WebsiteComp] [varchar](50) NULL,
	[PartPayeBraid] [float] NULL,
	[IDOwnerBraider] [int] NULL,
	[CostHairDeduct] [money] NULL,
	[PercentBrader] [tinyint] NULL,
	[PriceTakeOff] [money] NULL,
 CONSTRAINT [PK_COMPANY] PRIMARY KEY CLUSTERED 
(
	[IDComp] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

