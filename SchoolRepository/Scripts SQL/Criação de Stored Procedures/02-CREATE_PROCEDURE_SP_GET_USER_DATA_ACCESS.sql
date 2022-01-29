USE [SchoolDB]
GO

IF (OBJECT_ID('SP_GET_USER_DATA_ACCESS','P') IS NOT NULL) DROP PROCEDURE SP_GET_USER_DATA_ACCESS
GO

/****** Object:  StoredProcedure [dbo].[SP_GET_USER_DATA_ACCESS]    Script Date: 19/01/2022 17:03:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Miguel Passos
-- Create date: 26/09/2021
-- Description:	Stored Procedure para obter os dados de Acesso do Usuário
-- =============================================
CREATE PROCEDURE [dbo].[SP_GET_USER_DATA_ACCESS]
	@LOGIN varchar(50), @SENHA varchar(15)
AS
BEGIN
	SET NOCOUNT ON;

	MERGE TbUsuario AS DESTINO  
    USING (SELECT @LOGIN, @SENHA) as ORIGEM (Login, Senha)  
    ON (DESTINO.Login = ORIGEM.LOGIN AND DESTINO.Senha = ORIGEM.Senha)  
    WHEN MATCHED THEN	
        UPDATE SET UltimoAcesso = GETDATE();

	SELECT
		USU.IdUsuario,
		CASE WHEN (FUN.IdFuncionario IS NOT NULL) THEN FUN.Nome
			 WHEN (RES.IdResponsavel IS NOT NULL) THEN RES.Nome
			 ELSE ALU.Nome END Nome,
		CASE WHEN (FUN.IdFuncionario IS NOT NULL) THEN FUN.Sobrenome
			 WHEN (RES.IdResponsavel IS NOT NULL) THEN RES.Sobrenome
			 ELSE ALU.Sobrenome END Sobrenome,
		USU.Login,
		NIV.IdNivel,
		NIV.Descricao,
		NIV.Sigla
	FROM TbUsuario USU WITH(NOLOCK)
		LEFT JOIN TbFuncionario FUN WITH(NOLOCK) ON FUN.Usuario = USU.IdUsuario
		LEFT JOIN TbResponsavel RES WITH(NOLOCK) ON RES.Usuario = USU.IdUsuario
		LEFT JOIN TbAluno ALU WITH(NOLOCK) ON ALU.Usuario = USU.IdUsuario
		INNER JOIN TbNivelAcesso NIV WITH(NOLOCK) ON NIV.IdNivel = USU.NivelAcesso
	WHERE USU.Login = @LOGIN AND USU.Senha = @SENHA
END

GO