IF NOT EXISTS(SELECT OBJECT_ID(N'TbUnidade'))
BEGIN
	/****** Object:  Table [dbo].[TbUnidade]    Script Date: 18/01/2022 13:07:44 ******/
		SET ANSI_NULLS ON	
		SET QUOTED_IDENTIFIER ON
		SET ANSI_PADDING ON
	
		CREATE TABLE [dbo].[TbUnidade](
		[IdUnidade] [int] IDENTITY(1,1) NOT NULL,
		[Telefone] [varchar](13) NOT NULL,
		[Endereco] [varchar](200) NOT NULL,
		[Bairro] [varchar](100) NOT NULL,
		[Cidade] [varchar](50) NOT NULL,
		[UF] [varchar](2) NOT NULL,
		[CEP] [int] NOT NULL,
		[Coordenador] [int] NOT NULL,
		[Matriz] [bit] NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdUnidade] PRIMARY KEY CLUSTERED 
	(
		[IdUnidade] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
		SET ANSI_PADDING OFF
	
		ALTER TABLE [dbo].[TbUnidade] ADD CONSTRAINT [DF_TbUnidade_Sysdate] DEFAULT (getdate()) FOR [Sysdate]
		ALTER TABLE [dbo].[TbUnidade] ADD CONSTRAINT [DF_TbUnidade_Systime] DEFAULT (getdate()) FOR [Systime]
END