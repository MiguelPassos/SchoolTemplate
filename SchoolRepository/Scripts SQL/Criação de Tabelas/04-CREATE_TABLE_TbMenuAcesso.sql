USE [SchoolDB]
GO

IF NOT EXISTS(SELECT OBJECT_ID(N'TbMenuAcesso'))
BEGIN
	/****** Object:  Table [dbo].[TbMenuAcesso]    Script Date: 11/01/2022 15:13:06 ******/
	SET ANSI_NULLS ON
	SET QUOTED_IDENTIFIER ON
	
	CREATE TABLE [dbo].[TbMenuAcesso](
		[IdMenuAcesso] [int] IDENTITY(1,1) NOT NULL,
		[IdMenu] [int] NOT NULL,
		[IdNivelAcesso] [int] NOT NULL,
		[Editar] [bit] NOT NULL,
		[Visualizar] [bit] NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdMenuAcesso] PRIMARY KEY CLUSTERED 
	(
		[IdMenuAcesso] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	ALTER TABLE [dbo].[TbMenuAcesso] ADD CONSTRAINT [DF_TbMenuAcesso_Sysdate] DEFAULT (getdate()) FOR [Sysdate]
	ALTER TABLE [dbo].[TbMenuAcesso] ADD CONSTRAINT [DF_TbMenuAcesso_Sysdate] DEFAULT (getdate()) FOR [Systime]
	
	ALTER TABLE [dbo].[TbMenuAcesso]  WITH CHECK ADD  CONSTRAINT [FK_TbMenuAcesso_TbMenu] FOREIGN KEY([IdMenu])
	REFERENCES [dbo].[TbMenu] ([IdMenu])
	
	ALTER TABLE [dbo].[TbMenuAcesso] CHECK CONSTRAINT [FK_TbMenuAcesso_TbMenu]
	
	ALTER TABLE [dbo].[TbMenuAcesso]  WITH CHECK ADD  CONSTRAINT [FK_TbMenuAcesso_TbNivelAcesso] FOREIGN KEY([IdNivelAcesso])
	REFERENCES [dbo].[TbNivelAcesso] ([IdNivel])
	
	ALTER TABLE [dbo].[TbMenuAcesso] CHECK CONSTRAINT [FK_TbMenuAcesso_TbNivelAcesso]
END