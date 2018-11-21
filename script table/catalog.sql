/****** Object:  Table [dbo].[CATALOG]    Script Date: 11/21/2018 11:31:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CATALOG](
	[IDCatalog] [int] IDENTITY(1,1) NOT NULL,
	[IDVendor] [int] NOT NULL,
	[IDProd] [int] NOT NULL,
	[UnitType] [char](1) NULL,
	[UnitPrice] [money] NULL,
 CONSTRAINT [PK_CATALOG] PRIMARY KEY CLUSTERED 
(
	[IDCatalog] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CATALOG]  WITH CHECK ADD  CONSTRAINT [FK_CATALOG_PRODUCT] FOREIGN KEY([IDProd])
REFERENCES [dbo].[PRODUCT] ([IDProd])
GO

ALTER TABLE [dbo].[CATALOG] CHECK CONSTRAINT [FK_CATALOG_PRODUCT]
GO

ALTER TABLE [dbo].[CATALOG]  WITH CHECK ADD  CONSTRAINT [FK_CATALOG_VENDOR] FOREIGN KEY([IDVendor])
REFERENCES [dbo].[VENDOR] ([IDVendor])
GO

ALTER TABLE [dbo].[CATALOG] CHECK CONSTRAINT [FK_CATALOG_VENDOR]
GO
