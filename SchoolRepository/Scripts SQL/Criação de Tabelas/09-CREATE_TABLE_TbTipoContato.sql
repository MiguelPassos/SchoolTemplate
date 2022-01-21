IF NOT EXISTS(SELECT OBJECT_ID(N'TbTipoContato'))
BEGIN
	/****** Object:  Table [dbo].[TbTipoContato]    Script Date: 18/01/2022 13:07:44 ******/
	SET ANSI_NULLS ON
	SET QUOTED_IDENTIFIER ON	
	SET ANSI_PADDING ON
	
	CREATE TABLE [dbo].[TbTipoContato](
		[IdTipoContato] [int] IDENTITY(1,1) NOT NULL,
		[Tipo] [varchar](20) NOT NULL,
		[Ativo] [bit] NOT NULL,
		[Operador] [int] NOT NULL,
		[Sysdate] [date] NOT NULL,
		[Systime] [time](7) NOT NULL,
	 CONSTRAINT [PK_IdTipoContato] PRIMARY KEY CLUSTERED 
	(
		[IdTipoContato] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [dbo].[TbTipoContato] ADD CONSTRAINT [DF_TbTipoContato_Sysdate] DEFAULT (getdate()) FOR [Sysdate]
	ALTER TABLE [dbo].[TbTipoContato] ADD CONSTRAINT [DF_TbTipoContato_Systime] DEFAULT (getdate()) FOR [Systime]
END