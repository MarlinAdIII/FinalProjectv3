/****** Object:  Table [dbo].[ORDER]    Script Date: 11/21/2018 11:35:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ORDER](
	[IDOrder] [int] IDENTITY(1,1) NOT NULL,
	[IDVendor] [int] NOT NULL,
	[DateOrder] [datetime] NULL,
	[DescripOrder] [varchar](70) NULL,
 CONSTRAINT [PK_ORDER] PRIMARY KEY CLUSTERED 
(
	[IDOrder] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ORDER]  WITH CHECK ADD  CONSTRAINT [FK_ORDER_VENDOR] FOREIGN KEY([IDVendor])
REFERENCES [dbo].[VENDOR] ([IDVendor])
GO

ALTER TABLE [dbo].[ORDER] CHECK CONSTRAINT [FK_ORDER_VENDOR]
GO

