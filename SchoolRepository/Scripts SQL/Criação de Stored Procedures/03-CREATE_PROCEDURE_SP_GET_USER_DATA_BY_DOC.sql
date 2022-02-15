USE [SchoolDB]
GO

IF (OBJECT_ID('SP_GET_USER_DATA_BY_DOC','P') IS NOT NULL) DROP PROCEDURE SP_GET_USER_DATA_BY_DOC
GO

/****** Object:  StoredProcedure [dbo].[SP_GET_USER_DATA_BY_DOC]    Script Date: 06/02/2022 03:07:54 ******/
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

	DECLARE @ID INT;

	DECLARE @TABLE TABLE(
		ID INT,
		Nome VARCHAR(20),
		Sobrenome VARCHAR(50),
		Login VARCHAR(50),
		Email VARCHAR(100),
		Documento VARCHAR(11),
		Token VARCHAR(100),
		IdNivel INT,
		Descricao VARCHAR(100),
		Sigla VARCHAR(3))

	SET @ID = (SELECT IdFuncionario FROM TbFuncionario WITH(NOLOCK) WHERE CPF = @CPF AND Status = 1)

	IF (@ID IS NOT NULL)
	BEGIN
		INSERT INTO @TABLE (ID, Nome, Sobrenome, Login, Email, Documento, Token, IdNivel, Descricao, Sigla) 
		SELECT USU.IdUsuario AS ID, FUN.Nome, FUN.Sobrenome, USU.Login, 
		FIRST_VALUE(FUNC.Valor) OVER (PARTITION BY FUN.IdFuncionario ORDER BY FUNC.IdFuncionarioContato) AS Email, 
		FUN.CPF AS Documento, USU.Token, NIV.IdNivel, NIV.Descricao, NIV.Sigla
		FROM TbFuncionario FUN WITH(NOLOCK)
			LEFT JOIN TbFuncionarioContato FUNC WITH(NOLOCK) ON FUNC.Funcionario = FUN.IdFuncionario AND FUNC.Tipo = 1
			LEFT JOIN TbUsuario USU WITH(NOLOCK) ON USU.IdUsuario = FUN.Usuario AND USU.Status = 1
			LEFT JOIN TbNivelAcesso NIV WITH(NOLOCK) ON NIV.IdNivel = USU.NivelAcesso
		WHERE FUN.IdFuncionario = @ID
	END
	ELSE
	BEGIN
		SET @ID = (SELECT IdResponsavel FROM TbResponsavel WITH(NOLOCK) WHERE CPF = @CPF AND Status = 1)

		IF (@ID IS NOT NULL)
		BEGIN
			INSERT INTO @TABLE (ID, Nome, Sobrenome, Login, Email, Documento, Token, IdNivel, Descricao, Sigla)
			SELECT USU.IdUsuario AS ID, RES.Nome, RES.Sobrenome, 
			USU.Login, FIRST_VALUE(RESC.Valor) OVER (PARTITION BY RES.IdResponsavel ORDER BY RESC.IdResponsavelContato) AS Email, 
			RES.CPF AS Documento, USU.Token, NIV.IdNivel, NIV.Descricao, NIV.Sigla
			FROM TbResponsavel RES WITH(NOLOCK)
				LEFT JOIN TbResponsavelContato RESC WITH(NOLOCK) ON RESC.Responsavel = RES.IdResponsavel AND RESC.Tipo = 1
				LEFT JOIN TbUsuario USU WITH(NOLOCK) ON USU.IdUsuario = RES.Usuario AND USU.Status = 1
				LEFT JOIN TbNivelAcesso NIV WITH(NOLOCK) ON NIV.IdNivel = USU.NivelAcesso
			WHERE RES.IdResponsavel = @ID
		END
		ELSE
		BEGIN
			SET @ID = (SELECT IdAluno FROM TbAluno WITH(NOLOCK) WHERE CPF = @CPF AND Status = 1)

			IF (@ID IS NOT NULL)
			BEGIN
				INSERT INTO @TABLE (ID, Nome, Sobrenome, Login, Email, Documento, Token, IdNivel, Descricao, Sigla)
				SELECT USU.IdUsuario AS ID, ALU.Nome, ALU.Sobrenome, USU.Login, 
				FIRST_VALUE(ALUC.Valor) OVER (PARTITION BY ALU.IdAluno ORDER BY ALUC.IdAlunoContato) AS Email, 
				ALU.CPF AS Documento, USU.Token, NIV.IdNivel, NIV.Descricao, NIV.Sigla 
				FROM TbAluno ALU WITH(NOLOCK)
					LEFT JOIN TbAlunoContato ALUC WITH(NOLOCK) ON ALUC.Aluno = ALU.IdAluno AND ALUC.Tipo = 1
					LEFT JOIN TbUsuario USU WITH(NOLOCK) ON USU.IdUsuario = ALU.Usuario AND USU.Status = 1
					LEFT JOIN TbNivelAcesso NIV WITH(NOLOCK) ON NIV.IdNivel = USU.NivelAcesso
				WHERE ALU.IdAluno = @ID
			END
		END
	END

	SELECT DISTINCT ID, Nome, Sobrenome, Login, Email, Documento, Token, IdNivel, Descricao, Sigla FROM @TABLE
END

GO