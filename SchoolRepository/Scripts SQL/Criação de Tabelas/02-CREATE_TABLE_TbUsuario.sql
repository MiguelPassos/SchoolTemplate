USE [SchoolDB]
GO

IF NOT EXISTS(SELECT OBJECT_ID(N'TbUsuario'))
BEGIN

	/****** Object:  Table [dbo].[TbUsuario]    Script Date: 11/01/2022 14:07:44 ******/
	SET ANSI_NULLS ON	
	SET QUOTED_IDENTIFIER ON	
	SET ANSI_PADDING ON
	
	CREATE TABLE [dbo].[TbUsuario](
		[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
		[Login] [varchar](50) NOT NULL,
		[Senha] [varchar](15) NOT NULL,
		[NivelAcesso] [int] NOT NULL,
		[Status] [int] NOT NULL,
		[Token] [varchar](100) NOT NULL,
		[Validado] [bit] NOT NULL,
		[UltimoAcesso] [datetime] NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdUsuario] PRIMARY KEY CLUSTERED 
	(
		[IdUsuario] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [dbo].[TbUsuario] ADD CONSTRAINT [DF_TbUsuario_Sysdate] DEFAULT (getdate()) FOR [Sysdate]
	ALTER TABLE [dbo].[TbUsuario] ADD CONSTRAINT [DF_TbUsuario_Systime] DEFAULT (getdate()) FOR [Systime]
	ALTER TABLE [dbo].[TbUsuario] WITH CHECK ADD CONSTRAINT [FK_TbUsuario_TbNivelAcesso] FOREIGN KEY([NivelAcesso])
	REFERENCES [dbo].[TbNivelAcesso] ([IdNivel])
	ALTER TABLE [dbo].[TbUsuario] CHECK CONSTRAINT [FK_TbUsuario_TbNivelAcesso]
END