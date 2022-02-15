USE [SchoolDB]
GO

IF (OBJECT_ID('SP_GET_USER_DATA_BY_LOGIN','P') IS NOT NULL) DROP PROCEDURE SP_GET_USER_DATA_BY_LOGIN
GO

/****** Object:  StoredProcedure [dbo].[SP_GET_USER_DATA_BY_LOGIN]    Script Date: 14/02/2022 09:04:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Miguel Passos
-- Create date: 14/02/2022
-- Description:	Stored Procedure para obter os dados basico de Usuário através do login para validação se o login existe.
-- =============================================
CREATE PROCEDURE [dbo].[SP_GET_USER_DATA_BY_LOGIN]
	@LOGIN varchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	
	SELECT IdUsuario, Login FROM TbUsuario WITH(NOLOCK)
	WHERE Login = @LOGIN AND Status = 1
END
GO