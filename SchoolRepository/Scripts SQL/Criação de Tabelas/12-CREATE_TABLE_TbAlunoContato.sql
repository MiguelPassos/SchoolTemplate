USE [SchoolDB]
GO

IF NOT EXISTS(SELECT OBJECT_ID(N'TbAlunoContato'))
BEGIN
	/****** Object:  Table [dbo].[TbAlunoContato]    Script Date: 06/02/2022 14:47:29 ******/
	SET ANSI_NULLS ON	
	SET QUOTED_IDENTIFIER ON	
	SET ANSI_PADDING ON
	
	CREATE TABLE [dbo].[TbAlunoContato](
		[IdAlunoContato] [int] IDENTITY(1,1) NOT NULL,
		[Aluno] [int] NOT NULL,
		[Tipo] [int] NOT NULL,
		[Valor] [varchar](100) NOT NULL,
		[Ativo] [bit] NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdAlunoContato] PRIMARY KEY CLUSTERED 
	(
		[IdAlunoContato] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [dbo].[TbAlunoContato] ADD  CONSTRAINT [DF_TbAlunoContato_Sysdate]  DEFAULT (getdate()) FOR [Sysdate]	
	ALTER TABLE [dbo].[TbAlunoContato] ADD  CONSTRAINT [DF_TbAlunoContato_Systime]  DEFAULT (getdate()) FOR [Systime]	
	
	ALTER TABLE [dbo].[TbAlunoContato]  WITH CHECK ADD  CONSTRAINT [FK_TbAlunoContato_TbAluno] FOREIGN KEY([Aluno])
	REFERENCES [dbo].[TbAluno] ([IdAluno])
	
	ALTER TABLE [dbo].[TbAlunoContato] CHECK CONSTRAINT [FK_TbAlunoContato_TbAluno]
	
	ALTER TABLE [dbo].[TbAlunoContato]  WITH CHECK ADD  CONSTRAINT [FK_TbAlunoContato_TbTipoContato] FOREIGN KEY([Tipo])
	REFERENCES [dbo].[TbTipoContato] ([IdTipoContato])
	
	ALTER TABLE [dbo].[TbAlunoContato] CHECK CONSTRAINT [FK_TbAlunoContato_TbTipoContato]
END