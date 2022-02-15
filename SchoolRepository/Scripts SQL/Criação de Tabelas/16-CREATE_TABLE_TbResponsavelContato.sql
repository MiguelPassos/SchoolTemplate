IF NOT EXISTS(SELECT OBJECT_ID(N'TbResponsavelContato'))
BEGIN
	/****** Object:  Table [dbo].[TbResponsavelContato]    Script Date: 18/01/2022 13:07:44 ******/
	SET ANSI_NULLS ON
	SET QUOTED_IDENTIFIER ON	
	SET ANSI_PADDING ON
	
	CREATE TABLE [dbo].[TbResponsavelContato](
		[IdResponsavelContato] [int] IDENTITY(1,1) NOT NULL,
		[Responsavel] [int] NOT NULL,
		[Tipo] [int] NOT NULL,
		[Valor] [varchar] (100) NOT NULL,
		[Ativo] [bit] NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdResponsavelContato] PRIMARY KEY CLUSTERED 
	(
		[IdResponsavelContato] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [dbo].[TbResponsavelContato] ADD CONSTRAINT [DF_TbResponsavelContato_Sysdate] DEFAULT (getdate()) FOR [Sysdate]
	ALTER TABLE [dbo].[TbResponsavelContato] ADD CONSTRAINT [DF_TbResponsavelContato_Systime] DEFAULT (getdate()) FOR [Systime]

	ALTER TABLE [dbo].[TbResponsavelContato] WITH CHECK ADD CONSTRAINT [FK_TbResponsavelContato_TbResponsavel] FOREIGN KEY([Responsavel])
	REFERENCES [dbo].[TbResponsavel] ([IdResponsavel])
	ALTER TABLE [dbo].[TbResponsavelContato] CHECK CONSTRAINT [FK_TbResponsavelContato_TbResponsavel]

	ALTER TABLE [dbo].[TbResponsavelContato] WITH CHECK ADD CONSTRAINT [FK_TbResponsavelContato_TbTipoContato] FOREIGN KEY([Tipo])
	REFERENCES [dbo].[TbTipoContato] ([IdTipoContato])
	ALTER TABLE [dbo].[TbResponsavelContato] CHECK CONSTRAINT [FK_TbResponsavelContato_TbTipoContato]
END