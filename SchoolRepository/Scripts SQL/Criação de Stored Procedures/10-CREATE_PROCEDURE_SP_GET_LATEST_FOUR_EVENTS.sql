USE [SchoolDB]
GO

IF (OBJECT_ID('SP_GET_LATEST_FOUR_EVENTS','P') IS NOT NULL) DROP PROCEDURE SP_GET_LATEST_FOUR_EVENTS
GO

/****** Object:  StoredProcedure [dbo].[SP_GET_LATEST_FOUR_EVENTS]    Script Date: 22/02/2022 17:44:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Miguel Passos
-- Create date: 22/02/2022
-- Description:	Stored Procedure para obter os 4 ultimos eventos agendados.
-- =============================================
CREATE PROCEDURE [dbo].[SP_GET_LATEST_FOUR_EVENTS]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 4 
		EVE.IdEvento, EVE.Titulo, EVE.Descricao, EVE.DataInicio, EVE.DataTermino, EVE.UrlImagem, 
		CONVERT(DATETIME, CONVERT(CHAR(8), EVE.Sysdate, 112) + ' ' + CONVERT(CHAR(8), EVE.Systime, 108)) AS DataCriacao, (FUN.Nome + ' ' + FUN.Sobrenome) AS Autor
	FROM TbEvento EVE WITH(NOLOCK)
		INNER JOIN TbFuncionario FUN WITH(NOLOCK) ON FUN.IdFuncionario = EVE.Operador
	WHERE EVE.Ativo = 1
	ORDER BY DataInicio DESC
END
GO