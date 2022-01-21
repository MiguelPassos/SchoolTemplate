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

    SELECT
		 USU.IdUsuario
		,CASE WHEN (FUN.IdFuncionario IS NOT NULL) THEN FUN.Nome + ' ' + FUN.Sobrenome
			  WHEN (RES.IdResponsavel IS NOT NULL) THEN RES.Nome + ' ' + RES.Sobrenome
			  WHEN (ALU.IdAluno IS NOT NULL) THEN ALU.Nome + ' ' + ALU.Sobrenome 
			  ELSE USU.Login END Nome
		,USU.NivelAcesso
		,NA.Sigla
		,NA.Descricao 
	FROM TbUsuario USU WITH(NOLOCK)
		INNER JOIN TbNivelAcesso NA WITH(NOLOCK) ON NA.IdNivel = USU.NivelAcesso
		LEFT JOIN TbFuncionario FUN WITH(NOLOCK) ON FUN.Usuario = USU.IdUsuario
		LEFT JOIN TbResponsavel RES WITH(NOLOCK) ON RES.Usuario = USU.IdUsuario
		LEFT JOIN TbAluno ALU WITH(NOLOCK) ON ALU.Usuario = USU.IdUsuario
	WHERE USU.Login = @LOGIN AND USU.Senha = @SENHA
END

GO