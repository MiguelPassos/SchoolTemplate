USE [SchoolDB]
GO

IF (OBJECT_ID('SP_INSERT_NEW_USER_ACCESS','P') IS NOT NULL) DROP PROCEDURE SP_INSERT_NEW_USER_ACCESS
GO

/****** Object:  StoredProcedure [dbo].[SP_GET_USER_DATA_ACCESS]    Script Date: 29/01/2022 00:12:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Miguel Passos
-- Create date: 29/01/2022
-- Description:	Stored Procedure para cadastrar um novo usuário do sistema.
-- =============================================
CREATE PROCEDURE [dbo].[SP_INSERT_NEW_USER_ACCESS]
	@CPF varchar(11), @LOGIN varchar(50), @SENHA varchar(15), @TOKEN varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @IDUSUARIO INT;

	IF(EXISTS(SELECT IdFuncionario FROM TbFuncionario WITH(NOLOCK) WHERE CPF = @CPF))
	BEGIN
		INSERT INTO TbUsuario (Login, Senha, NivelAcesso, Token, Validado, Operador, Sysdate, Systime) 
		VALUES (@LOGIN, @SENHA, 4, @TOKEN, 0, 1, GETDATE(), GETDATE())

		SET @IDUSUARIO = (SELECT SCOPE_IDENTITY())
		
		UPDATE TbFuncionario SET Usuario = @IDUSUARIO WHERE CPF = @CPF
	END
	ELSE IF(EXISTS(SELECT IdResponsavel FROM TbResponsavel WITH(NOLOCK) WHERE CPF = @CPF))
	BEGIN
		INSERT INTO TbUsuario (Login, Senha, NivelAcesso, Token, Validado, Operador, Sysdate, Systime) 
		VALUES (@LOGIN, @SENHA, 5, @TOKEN, 0, 1, GETDATE(), GETDATE())

		SET @IDUSUARIO = (SELECT SCOPE_IDENTITY())
		UPDATE TbResponsavel SET Usuario = @IDUSUARIO WHERE CPF = @CPF
	END
	ELSE IF(EXISTS(SELECT IdAluno FROM TbAluno WITH(NOLOCK) WHERE CPF = @CPF))
	BEGIN
		INSERT INTO TbUsuario (Login, Senha, NivelAcesso, Token, Validado, Operador, Sysdate, Systime)
		VALUES (@LOGIN, @SENHA, 5, @TOKEN, 0, 1, GETDATE(), GETDATE())

		SET @IDUSUARIO = (SELECT SCOPE_IDENTITY())
		UPDATE TbAluno SET Usuario = @IDUSUARIO WHERE CPF = @CPF
	END
END
GO