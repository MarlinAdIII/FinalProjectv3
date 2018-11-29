/****** Object:  Table [dbo].[ORDERPRODUCT]    Script Date: 11/21/2018 11:35:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ORDERPRODUCT](
	[IDOrderProd] [int] IDENTITY(1,1) NOT NULL,
	[IDOrder] [int] NOT NULL,
	[IDProd] [int] NOT NULL,
	[QttyOrder] [tinyint] NULL,
 CONSTRAINT [PK_ORDERPRODUCT] PRIMARY KEY CLUSTERED 
(
	[IDOrderProd] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ORDERPRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_ORDERPRODUCT_ORDER] FOREIGN KEY([IDProd])
REFERENCES [dbo].[ORDER] ([IDOrder])
GO

ALTER TABLE [dbo].[ORDERPRODUCT] CHECK CONSTRAINT [FK_ORDERPRODUCT_ORDER]
GO

ALTER TABLE [dbo].[ORDERPRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_ORDERPRODUCT_PRODUCT] FOREIGN KEY([IDProd])
REFERENCES [dbo].[PRODUCT] ([IDProd])
GO

ALTER TABLE [dbo].[ORDERPRODUCT] CHECK CONSTRAINT [FK_ORDERPRODUCT_PRODUCT]
GO

