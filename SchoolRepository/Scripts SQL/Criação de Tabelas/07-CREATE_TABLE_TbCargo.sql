IF NOT EXISTS(SELECT OBJECT_ID(N'TbCargo'))
BEGIN
	/****** Object:  Table [dbo].[TbFuncionario]    Script Date: 18/01/2022 13:07:44 ******/
	SET ANSI_NULLS ON	
	SET QUOTED_IDENTIFIER ON	
	SET ANSI_PADDING ON
	
	CREATE TABLE [dbo].[TbCargo](
		[IdCargo] [int] IDENTITY(1,1) NOT NULL,
		[Nome] [varchar](20) NOT NULL,
		[Descricao] [varchar](MAX) NULL,
		[Ativo] [bit] NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdCargo] PRIMARY KEY CLUSTERED 
	(
		[IdCargo] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [dbo].[TbCargo] ADD CONSTRAINT [DF_TbCargo_Sysdate] DEFAULT (getdate()) FOR [Sysdate]
	ALTER TABLE [dbo].[TbCargo] ADD CONSTRAINT [DF_TbCargo_Systime] DEFAULT (getdate()) FOR [Systime]
END