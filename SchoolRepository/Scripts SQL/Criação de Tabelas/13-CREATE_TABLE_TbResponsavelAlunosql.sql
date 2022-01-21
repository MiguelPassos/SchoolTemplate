IF NOT EXISTS(SELECT OBJECT_ID(N'TbResponsavelAluno'))
BEGIN
	/****** Object:  Table [dbo].[TbFuncionarioContato]    Script Date: 18/01/2022 13:07:44 ******/
	SET ANSI_NULLS ON
	SET QUOTED_IDENTIFIER ON	
	SET ANSI_PADDING ON
	
	CREATE TABLE [dbo].[TbResponsavelAluno](
		[IdResponsavelAluno] [int] IDENTITY(1,1) NOT NULL,
		[Responsavel] [int] NOT NULL,
		[Aluno] [int] NOT NULL,
		[Status] [int] NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdResponsavelAluno] PRIMARY KEY CLUSTERED 
	(
		[IdResponsavelAluno] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [dbo].[TbResponsavelAluno] ADD CONSTRAINT [DF_TbResponsavelAluno_Sysdate] DEFAULT (getdate()) FOR [Sysdate]
	ALTER TABLE [dbo].[TbResponsavelAluno] ADD CONSTRAINT [DF_TbResponsavelAluno_Systime] DEFAULT (getdate()) FOR [Systime]

	ALTER TABLE [dbo].[TbResponsavelAluno] WITH CHECK ADD CONSTRAINT [FK_TbResponsavelAluno_TbResponsavel] FOREIGN KEY([Responsavel])
	REFERENCES [dbo].[TbResponsavel] ([IdResponsavel])
	ALTER TABLE [dbo].[TbResponsavelAluno] CHECK CONSTRAINT [FK_TbResponsavelAluno_TbResponsavel]

	ALTER TABLE [dbo].[TbResponsavelAluno] WITH CHECK ADD CONSTRAINT [FK_TbResponsavelAluno_TbAluno] FOREIGN KEY([Aluno])
	REFERENCES [dbo].[TbAluno] ([IdAluno])
	ALTER TABLE [dbo].[TbResponsavelAluno] CHECK CONSTRAINT [FK_TbResponsavelAluno_TbAluno]
END