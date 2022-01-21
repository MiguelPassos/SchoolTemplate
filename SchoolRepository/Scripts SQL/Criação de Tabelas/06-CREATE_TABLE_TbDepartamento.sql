IF NOT EXISTS(SELECT OBJECT_ID(N'TbDepartamento'))
BEGIN
	/****** Object:  Table [dbo].[TbDepartamento]    Script Date: 18/01/2022 13:07:44 ******/
	SET ANSI_NULLS ON	
	SET QUOTED_IDENTIFIER ON	
	SET ANSI_PADDING ON
	
	CREATE TABLE [dbo].[TbDepartamento](
		[IdDepartamento] [int] IDENTITY(1,1) NOT NULL,
		[Nome] [varchar](20) NOT NULL,
		[Unidade] [int] NOT NULL,
		[Coordenador] [int] NOT NULL,
		[Ativo] [bit] NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdDepartamento] PRIMARY KEY CLUSTERED 
	(
		[IdDepartamento] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [dbo].[TbDepartamento] ADD CONSTRAINT [DF_TbDepartamento_Sysdate] DEFAULT (getdate()) FOR [Sysdate]
	ALTER TABLE [dbo].[TbDepartamento] ADD CONSTRAINT [DF_TbDepartamento_Systime] DEFAULT (getdate()) FOR [Systime]	
	ALTER TABLE [dbo].[TbDepartamento] WITH CHECK ADD CONSTRAINT [FK_TbDepartamento_TbUnidade] FOREIGN KEY([Unidade])
	REFERENCES [dbo].[TbUnidade] ([IdUnidade])	
	ALTER TABLE [dbo].[TbDepartamento] CHECK CONSTRAINT [FK_TbDepartamento_TbUnidade]
END