IF NOT EXISTS(SELECT OBJECT_ID(N'TbResponsavel'))
BEGIN
	/****** Object:  Table [dbo].[TbFuncionarioContato]    Script Date: 18/01/2022 13:07:44 ******/
	SET ANSI_NULLS ON
	SET QUOTED_IDENTIFIER ON	
	SET ANSI_PADDING ON
	
	CREATE TABLE [dbo].[TbResponsavel](
		[IdResponsavel] [int] IDENTITY(1,1) NOT NULL,
		[Nome] [varchar](20) NOT NULL,
		[Sobrenome] [varchar](50) NOT NULL,
		[Nascimento] [date] NOT NULL,
		[Naturalidade] [varchar](100) NOT NULL,
		[NaturalidadeUF] [varchar](2) NOT NULL,
		[Nacionalidade] [varchar](50) NOT NULL,
		[RG] [varchar](20) NOT NULL,
		[CPF] [varchar](11) NOT NULL,
		[Profissao] [varchar](50) NULL,
		[Status] [int] NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdResponsavel] PRIMARY KEY CLUSTERED 
	(
		[IdResponsavel] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [dbo].[TbResponsavel] ADD CONSTRAINT [DF_TbResponsavel_Sysdate] DEFAULT (getdate()) FOR [Sysdate]
	ALTER TABLE [dbo].[TbResponsavel] ADD CONSTRAINT [DF_TbResponsavel_Systime] DEFAULT (getdate()) FOR [Systime]
END