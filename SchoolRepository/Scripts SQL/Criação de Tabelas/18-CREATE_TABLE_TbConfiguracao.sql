IF ((SELECT OBJECT_ID(N'TbConfiguracao')) IS NULL)
BEGIN
	/****** Object:  Table [dbo].[TbEvento]    Script Date: 22/02/2022 13:07:44 ******/
	SET ANSI_NULLS ON
	SET QUOTED_IDENTIFIER ON	
	SET ANSI_PADDING ON
	
	CREATE TABLE [dbo].[TbConfiguracao](
		[IdConfiguracao] [int] IDENTITY(1,1) NOT NULL,
		[Chave] [varchar](100) NOT NULL,
		[Valor] [varchar](200) NOT NULL,
		[Ativo] [bit] NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date],
		[Systime] [time](7),
	 CONSTRAINT [PK_IdConfiguracao] PRIMARY KEY CLUSTERED 
	(
		[IdConfiguracao] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [dbo].[TbConfiguracao] ADD CONSTRAINT [DF_TbConfiguracao_Sysdate] DEFAULT (getdate()) FOR [Sysdate]
	ALTER TABLE [dbo].[TbConfiguracao] ADD CONSTRAINT [DF_TbConfiguracao_Systime] DEFAULT (getdate()) FOR [Systime]
END