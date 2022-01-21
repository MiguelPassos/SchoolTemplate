IF NOT EXISTS(SELECT OBJECT_ID(N'TbFuncionario'))
BEGIN
	/****** Object:  Table [dbo].[TbFuncionario]    Script Date: 18/01/2022 13:07:44 ******/
	SET ANSI_NULLS ON	
	SET QUOTED_IDENTIFIER ON	
	SET ANSI_PADDING ON
	
	CREATE TABLE [dbo].[TbFuncionario](
		[IdFuncionario] [int] IDENTITY(1,1) NOT NULL,
		[Nome] [varchar](20) NOT NULL,
		[Sobrenome] [varchar](50) NOT NULL,
		[Nascimento] [date] NOT NULL,
		[Naturalidade] [varchar](100) NOT NULL,
		[NaturalidadeUF] [varchar](2) NOT NULL,
		[Nacionalidade] [varchar](50) NOT NULL,
		[Endereco] [varchar](100) NOT NULL,
		[Bairro] [varchar](50) NOT NULL,
		[Cidade] [varchar](50) NOT NULL,
		[UF] [varchar](2) NOT NULL,
		[CEP] [varchar](10) NOT NULL,
		[RG] [bigint] NOT NULL,
		[CPF] [bigint] NOT NULL,
		[CTPS] [int] NULL,
		[SerieCTPS] [int] NULL,
		[Cargo] [int] NOT NULL,
		[Departamento] [int] NOT NULL,
		[Status] [int] NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdFuncionario] PRIMARY KEY CLUSTERED 
	(
		[IdFuncionario] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [dbo].[TbFuncionario] ADD CONSTRAINT [DF_TbFuncionario_Sysdate] DEFAULT (getdate()) FOR [Sysdate]
	ALTER TABLE [dbo].[TbFuncionario] ADD CONSTRAINT [DF_TbFuncionario_Systime] DEFAULT (getdate()) FOR [Systime]	
	ALTER TABLE [dbo].[TbFuncionario] WITH CHECK ADD CONSTRAINT [FK_TbFuncionario_TbCargo] FOREIGN KEY([Cargo])
	REFERENCES [dbo].[TbCargo] ([IdCargo])
	ALTER TABLE [dbo].[TbFuncionario] WITH CHECK ADD CONSTRAINT [FK_TbFuncionario_TbDepartamento] FOREIGN KEY([Departamento])
	REFERENCES [dbo].[TbDepartamento] ([IdDepartamento])
	ALTER TABLE [dbo].[TbFuncionario] CHECK CONSTRAINT [FK_TbFuncionario_TbDepartamento]
END