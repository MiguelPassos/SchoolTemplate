USE [SchoolDB]
GO

IF (OBJECT_ID('SP_UPDATE_USER_ACCESS','P') IS NOT NULL) DROP PROCEDURE SP_UPDATE_USER_ACCESS
GO

/****** Object:  StoredProcedure [dbo].[SP_UPDATE_USER_ACCESS]    Script Date: 14/02/2022 09:04:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Miguel Passos
-- Create date: 14/02/2022
-- Description:	Stored Procedure para informações de acesso do Usuário e Token de validação.
-- =============================================
CREATE PROCEDURE [dbo].[SP_UPDATE_USER_ACCESS]
	@ID int, @LOGIN varchar(50), @SENHA varchar(15), @TOKEN varchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	MERGE TbUsuario AS DESTINO  
    USING (SELECT @ID, @LOGIN, @SENHA, @TOKEN) as ORIGEM (IdUsuario, Login, Senha, Token)  
    ON (DESTINO.IdUsuario = ORIGEM.IdUsuario)
    WHEN MATCHED THEN
        UPDATE SET DESTINO.Login = ORIGEM.Login, DESTINO.Senha = ORIGEM.Senha, DESTINO.Token = ORIGEM.Token;
END
GO