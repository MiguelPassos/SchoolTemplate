IF NOT EXISTS(SELECT OBJECT_ID(N'TbFuncionarioContato'))
BEGIN
	/****** Object:  Table [dbo].[TbFuncionarioContato]    Script Date: 18/01/2022 13:07:44 ******/
	SET ANSI_NULLS ON
	SET QUOTED_IDENTIFIER ON	
	SET ANSI_PADDING ON
	
	CREATE TABLE [dbo].[TbFuncionarioContato](
		[IdFuncionarioContato] [int] IDENTITY(1,1) NOT NULL,
		[Funcionario] [int] NOT NULL,
		[Tipo] [int] NOT NULL,
		[Valor] [varchar](100) NOT NULL,
		[Ativo] [bit] NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdFuncionarioContato] PRIMARY KEY CLUSTERED 
	(
		[IdFuncionarioContato] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [dbo].[TbFuncionarioContato] ADD CONSTRAINT [DF_TbFuncionarioContato_Sysdate] DEFAULT (getdate()) FOR [Sysdate]
	ALTER TABLE [dbo].[TbFuncionarioContato] ADD CONSTRAINT [DF_TbFuncionarioContato_Systime] DEFAULT (getdate()) FOR [Systime]

	ALTER TABLE [dbo].[TbFuncionarioContato] WITH CHECK ADD CONSTRAINT [FK_TbFuncionarioContato_TbFuncionario] FOREIGN KEY([Funcionario])
	REFERENCES [dbo].[TbFuncionario] ([IdFuncionario])
	ALTER TABLE [dbo].[TbFuncionarioContato] CHECK CONSTRAINT [FK_TbFuncionarioContato_TbFuncionario]

	ALTER TABLE [dbo].[TbFuncionarioContato] WITH CHECK ADD CONSTRAINT [FK_TbFuncionarioContato_TbTipoContato] FOREIGN KEY([Tipo])
	REFERENCES [dbo].[TbTipoContato] ([IdTipoContato])
	ALTER TABLE [dbo].[TbFuncionarioContato] CHECK CONSTRAINT [FK_TbFuncionarioContato_TbTipoContato]
END