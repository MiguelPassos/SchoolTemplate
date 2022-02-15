IF NOT EXISTS(SELECT OBJECT_ID(N'TbPerfilFuncionario'))
BEGIN
	/****** Object:  Table [dbo].[TbPerfilFuncionario]    Script Date: 31/01/2022 15:45:44 ******/
	SET ANSI_NULLS ON
	SET QUOTED_IDENTIFIER ON	
	SET ANSI_PADDING ON
	
	CREATE TABLE [dbo].[TbPerfilFuncionario](
		[IdPerfilFuncionario] [int] IDENTITY(1,1) NOT NULL,
		[Funcionario] [int] NOT NULL,
		[Imagem] [varchar](50) NOT NULL,
		[Titulo] [varchar](50) NOT NULL,
		[Informacoes] [varchar](500) NOT NULL,
		[Ativo] [bit] NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdPerfilFuncionario] PRIMARY KEY CLUSTERED 
	(
		[IdPerfilFuncionario] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [dbo].[TbPerfilFuncionario] ADD CONSTRAINT [DF_TbPerfilFuncionario_Sysdate] DEFAULT (getdate()) FOR [Sysdate]
	ALTER TABLE [dbo].[TbPerfilFuncionario] ADD CONSTRAINT [DF_TbPerfilFuncionario_Systime] DEFAULT (getdate()) FOR [Systime]

	ALTER TABLE [dbo].[TbPerfilFuncionario] WITH CHECK ADD CONSTRAINT [FK_TbPerfilFuncionario_TbFuncionario] FOREIGN KEY([Funcionario])
	REFERENCES [dbo].[TbFuncionario] ([IdFuncionario])
	ALTER TABLE [dbo].[TbPerfilFuncionario] CHECK CONSTRAINT [FK_TbPerfilFuncionario_TbFuncionario]
END