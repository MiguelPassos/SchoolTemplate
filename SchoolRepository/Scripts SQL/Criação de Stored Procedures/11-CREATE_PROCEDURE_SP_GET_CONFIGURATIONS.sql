USE [SchoolDB]
GO

IF (OBJECT_ID('SP_GET_CONFIGURATIONS','P') IS NOT NULL) DROP PROCEDURE SP_GET_CONFIGURATIONS
GO

/****** Object:  StoredProcedure [dbo].[SP_GET_CONFIGURATIONS]    Script Date: 05/03/2022 17:44:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Miguel Passos
-- Create date: 05/03/2022
-- Description:	Stored Procedure para obter as configurações disponíveis para a aplicação.
-- =============================================
CREATE PROCEDURE [dbo].[SP_GET_CONFIGURATIONS]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT IdConfiguracao, Chave, Valor 
	FROM TbConfiguracao
	WHERE Ativo = 1
END
GO