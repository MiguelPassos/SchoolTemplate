USE [SchoolDB]
GO

IF (OBJECT_ID('SP_GET_RANDOM_EMPLOYEES_PROFILES','P') IS NOT NULL) DROP PROCEDURE SP_GET_RANDOM_EMPLOYEES_PROFILES
GO

/****** Object:  StoredProcedure [dbo].[SP_GET_RANDOM_USERS_PROFILES]    Script Date: 31/01/2022 18:54:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Miguel Passos
-- Create date: 31/01/2022
-- Description:	Stored Procedure para obter randomicamente os dados dos membros acadêmicos.
-- =============================================
CREATE PROCEDURE [dbo].[SP_GET_RANDOM_EMPLOYEES_PROFILES]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 8 PER.IdPerfilFuncionario AS IdPerfil, FUN.Nome, FUN.Sobrenome, PER.Titulo, PER.Imagem 
	FROM TbPerfilFuncionario PER WITH(NOLOCK)
		INNER JOIN TbFuncionario FUN WITH(NOLOCK) ON FUN.IdFuncionario = PER.Funcionario
	WHERE PER.Ativo = 1
	ORDER BY NEWID()
END
GO