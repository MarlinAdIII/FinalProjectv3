/****** Object:  Table [dbo].[DESIGNWITH]    Script Date: 11/21/2018 11:32:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DESIGNWITH](
	[IDDesignWith] [int] IDENTITY(1,1) NOT NULL,
	[IDStyle] [tinyint] NOT NULL,
	[IDHair] [int] NOT NULL,
 CONSTRAINT [PK_DESIGNWITH] PRIMARY KEY CLUSTERED 
(
	[IDDesignWith] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DESIGNWITH]  WITH CHECK ADD  CONSTRAINT [FK_DESIGNWITH_HAIR] FOREIGN KEY([IDHair])
REFERENCES [dbo].[HAIR] ([IDHair])
GO

ALTER TABLE [dbo].[DESIGNWITH] CHECK CONSTRAINT [FK_DESIGNWITH_HAIR]
GO

ALTER TABLE [dbo].[DESIGNWITH]  WITH CHECK ADD  CONSTRAINT [FK_DESIGNWITH_STYLE] FOREIGN KEY([IDStyle])
REFERENCES [dbo].[STYLE] ([IDStyle])
GO

ALTER TABLE [dbo].[DESIGNWITH] CHECK CONSTRAINT [FK_DESIGNWITH_STYLE]
GO

