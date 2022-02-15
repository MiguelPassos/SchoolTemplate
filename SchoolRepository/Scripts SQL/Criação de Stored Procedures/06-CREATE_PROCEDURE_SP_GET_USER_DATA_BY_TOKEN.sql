USE [SchoolDB]
GO

IF (OBJECT_ID('SP_GET_USER_DATA_BY_TOKEN','P') IS NOT NULL) DROP PROCEDURE SP_GET_USER_DATA_BY_TOKEN
GO

/****** Object:  StoredProcedure [dbo].[SP_GET_USER_DATA_ACCESS]    Script Date: 06/02/2022 16:22:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Miguel Passos
-- Create date: 06/02/2022
-- Description:	Stored Procedure para obter os dados do Usuário pelo Token
-- =============================================
CREATE PROCEDURE [dbo].[SP_GET_USER_DATA_BY_TOKEN]
	@TOKEN varchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		USU.IdUsuario,
		CASE WHEN (FUN.IdFuncionario IS NOT NULL) THEN FUN.Nome
			 WHEN (RES.IdResponsavel IS NOT NULL) THEN RES.Nome
			 ELSE ALU.Nome END Nome,
		CASE WHEN (FUN.IdFuncionario IS NOT NULL) THEN FUN.Sobrenome
			 WHEN (RES.IdResponsavel IS NOT NULL) THEN RES.Sobrenome
			 ELSE ALU.Sobrenome END Sobrenome,
		USU.Login,
		NULL AS Email,
		NIV.IdNivel,
		NIV.Descricao,
		NIV.Sigla
	FROM TbUsuario USU WITH(NOLOCK)
		LEFT JOIN TbFuncionario FUN WITH(NOLOCK) ON FUN.Usuario = USU.IdUsuario
		LEFT JOIN TbResponsavel RES WITH(NOLOCK) ON RES.Usuario = USU.IdUsuario
		LEFT JOIN TbAluno ALU WITH(NOLOCK) ON ALU.Usuario = USU.IdUsuario
		INNER JOIN TbNivelAcesso NIV WITH(NOLOCK) ON NIV.IdNivel = USU.NivelAcesso
	WHERE USU.Token = @TOKEN
END
GO