USE [SchoolDB]
GO

IF (OBJECT_ID('SP_GET_USER_DATA_BY_DOC','P') IS NOT NULL) DROP PROCEDURE SP_GET_USER_DATA_BY_DOC
GO

/****** Object:  StoredProcedure [dbo].[SP_GET_USER_DATA_ACCESS]    Script Date: 29/01/2022 00:12:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Miguel Passos
-- Create date: 29/01/2022
-- Description:	Stored Procedure para obter os dados do Usuário por CPF.
-- =============================================
CREATE PROCEDURE [dbo].[SP_GET_USER_DATA_BY_DOC]
	@CPF varchar(11)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CASE WHEN (FUN.IdFuncionario IS NOT NULL) THEN FUN.IdFuncionario
				WHEN (RES.IdResponsavel IS NOT NULL) THEN RES.IdResponsavel
				ELSE ALU.IdAluno END ID,
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
	WHERE (FUN.CPF = @CPF) OR (RES.CPF = @CPF) OR (ALU.CPF = @CPF)
END
GO