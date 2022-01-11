USE [SchoolDB]
GO

IF NOT EXISTS(SELECT OBJECT_ID(N'TbMenu'))
BEGIN

	/****** Object:  Table [dbo].[TbMenu]    Script Date: 11/01/2022 15:05:04 ******/
	SET ANSI_NULLS ON
	SET QUOTED_IDENTIFIER ON	
	SET ANSI_PADDING ON
	
	CREATE TABLE [dbo].[TbMenu](
		[IdMenu] [int] IDENTITY(1,1) NOT NULL,
		[IdMenuPai] [int] NOT NULL,
		[Texto] [varchar](100) NOT NULL,
		[Descricao] [varchar](200) NOT NULL,
		[ControllerName] [varchar](100) NULL,
		[ActionName] [varchar](100) NULL,
		[Icone] [varchar](20) NULL,
		[Ordem] [int] NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdMenu] PRIMARY KEY CLUSTERED 
	(
		[IdMenu] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [dbo].[TbMenu] ADD CONSTRAINT [DF_TbMenu_IdMenuPai] DEFAULT ((0)) FOR [IdMenuPai]	
	ALTER TABLE [dbo].[TbMenu] ADD CONSTRAINT [DF_TbMenu_Sysdate] DEFAULT (getdate()) FOR [Sysdate]	
	ALTER TABLE [dbo].[TbMenu] ADD CONSTRAINT [DF_TbMenu_Systime] DEFAULT (getdate()) FOR [Systime]
END