IF NOT EXISTS(SELECT OBJECT_ID(N'TbEvento'))
BEGIN
	/****** Object:  Table [dbo].[TbEvento]    Script Date: 22/02/2022 13:07:44 ******/
	SET ANSI_NULLS ON
	SET QUOTED_IDENTIFIER ON	
	SET ANSI_PADDING ON
	
	CREATE TABLE [dbo].[TbEvento](
		[IdEvento] [int] IDENTITY(1,1) NOT NULL,
		[Titulo] [varchar](100) NOT NULL,
		[Descricao] [varchar](300) NOT NULL,
		[DataInicio] [date] NOT NULL,
		[DataTermino] [date] NOT NULL,
		[UrlImagem] [varchar](50) NOT NULL,
		[Ativo] [bit] NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdEvento] PRIMARY KEY CLUSTERED 
	(
		[IdEvento] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [dbo].[TbEvento] ADD CONSTRAINT [DF_TbEvento_Sysdate] DEFAULT (getdate()) FOR [Sysdate]
	ALTER TABLE [dbo].[TbEvento] ADD CONSTRAINT [DF_TbEvento_Systime] DEFAULT (getdate()) FOR [Systime]
END