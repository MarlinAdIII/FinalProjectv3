/****** Object:  Table [dbo].[STYLE]    Script Date: 11/21/2018 11:35:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[STYLE](
	[IDStyle] [tinyint] IDENTITY(1,1) NOT NULL,
	[DesigStyle] [varchar](70) NOT NULL,
	[DescriptStyle] [varchar](150) NOT NULL,
	[HairProvStyle] [bit] NULL,
	[PriceStyle] [money] NULL,
	[PriceExtrat] [money] NULL,
	[PictureStyle] [varchar](2000) NULL,
 CONSTRAINT [PK_STYLE] PRIMARY KEY CLUSTERED 
(
	[IDStyle] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

