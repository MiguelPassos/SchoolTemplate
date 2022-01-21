USE [SchoolDB]
GO

IF NOT EXISTS(SELECT OBJECT_ID(N'TbNivelAcesso'))
BEGIN

	/****** Object:  Table [dbo].[TbNivelAcesso]    Script Date: 11/01/2022 14:21:37 ******/
	SET ANSI_NULLS ON	
	SET QUOTED_IDENTIFIER ON
	SET ANSI_PADDING ON
	
	CREATE TABLE [dbo].[TbNivelAcesso](
		[IdNivel] [int] IDENTITY(1,1) NOT NULL,
		[Descricao] [varchar](100) NOT NULL,
		[Sigla] [varchar](3) NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdNivel] PRIMARY KEY CLUSTERED 
	(
		[IdNivel] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [dbo].[TbNivelAcesso] ADD CONSTRAINT [DF_TbNivelAcesso_Sysdate] DEFAULT (getdate()) FOR [Sysdate]	
	ALTER TABLE [dbo].[TbNivelAcesso] ADD CONSTRAINT [DF_TbNivelAcesso_Systime] DEFAULT (getdate()) FOR [Systime]

	INSERT INTO TbNivelAcesso VALUES ('Desenvolvedor', 'DEV',	1, GETDATE(), GETDATE())
	INSERT INTO TbNivelAcesso VALUES ('Administrador', 'ADM',	1, GETDATE(), GETDATE())
	INSERT INTO TbNivelAcesso VALUES ('Pedagógico',	   'PED',	1, GETDATE(), GETDATE())
	INSERT INTO TbNivelAcesso VALUES ('Professor',	   'PRO',	1, GETDATE(), GETDATE())
	INSERT INTO TbNivelAcesso VALUES ('Familiar',	   'FAM',	1, GETDATE(), GETDATE())
END