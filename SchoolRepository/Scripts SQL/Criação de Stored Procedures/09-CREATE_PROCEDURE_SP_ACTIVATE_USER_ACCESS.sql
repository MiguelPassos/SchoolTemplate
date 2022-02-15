USE [SchoolDB]
GO

IF (OBJECT_ID('SP_ACTIVATE_USER_ACCESS','P') IS NOT NULL) DROP PROCEDURE SP_ACTIVATE_USER_ACCESS
GO

/****** Object:  StoredProcedure [dbo].[SP_UPDATE_USER_ACCESS]    Script Date: 14/02/2022 09:04:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Miguel Passos
-- Create date: 14/02/2022
-- Description:	Stored Procedure para ativar o acesso do Usuário após validação.
-- =============================================
CREATE PROCEDURE [dbo].[SP_ACTIVATE_USER_ACCESS]
	@ID int
AS
BEGIN
	SET NOCOUNT ON;

	MERGE TbUsuario AS DESTINO  
    USING (SELECT @ID, 1) as ORIGEM (IdUsuario, Validado)  
    ON (DESTINO.IdUsuario = ORIGEM.IdUsuario)
    WHEN MATCHED THEN
        UPDATE SET DESTINO.Validado = ORIGEM.Validado;
END
GO