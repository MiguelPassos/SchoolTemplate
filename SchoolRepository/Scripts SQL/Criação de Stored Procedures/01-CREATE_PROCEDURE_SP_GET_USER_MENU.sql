USE [SchoolDB]
GO

IF (OBJECT_ID('SP_GET_USER_MENU','P') IS NOT NULL) DROP PROCEDURE SP_GET_USER_MENU
GO

/****** Object:  StoredProcedure [dbo].[SP_GET_USER_MENU]    Script Date: 18/01/2022 19:34:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Miguel Passos
-- Create date: 26/09/2021
-- Description:	Stored Procedure para obter os dados de Acesso do Usuário
-- =============================================
ALTER PROCEDURE [dbo].[SP_GET_USER_MENU]
	@IDUSUARIO int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @NIVELACESSO int
	SET @NIVELACESSO = (SELECT NivelAcesso FROM TbUsuario WITH(NOLOCK) WHERE IdUsuario = @IDUSUARIO)
	
	IF(@NIVELACESSO = 0 OR @NIVELACESSO IS NULL) --Default
	BEGIN
		SELECT IdMenu, IdMenuPai, Texto, Descricao, ControllerName, ActionName, NULL AS OptionalId, Icone, Ordem
		FROM TbMenu MN WITH(NOLOCK)
		WHERE IdMenu IN (1,2,3,4,5,6,7,8) OR IdMenuPai IN (1,2,3,4,5,6,7,8)
		ORDER BY IdMenu, Ordem
	END
	ELSE
	BEGIN
		IF(@NIVELACESSO <> 5)
		BEGIN
			SELECT MN.IdMenu, MN.IdMenuPai, MN.Texto, MN.Descricao, MN.ControllerName, MN.ActionName, NULL AS OptionalId, MN.Icone, MN.Ordem
			FROM TbMenu MN WITH(NOLOCK)
				INNER JOIN TbMenuAcesso MNA WITH(NOLOCK) ON MNA.IdMenu = MN.IdMenu
			WHERE MNA.IdNivelAcesso = @NIVELACESSO
			ORDER BY IdMenu, Ordem
		END
		ELSE
		BEGIN
			IF(EXISTS(SELECT IdResponsavel FROM TbResponsavel WITH(NOLOCK) WHERE Usuario = @IDUSUARIO))
			BEGIN
				SELECT A.IdAluno*(-1) AS IdMenu, 0 AS IdMenuPai, A.Nome AS Texto, NULL AS Descricao, NULL AS ControllerName, NULL AS ActionName, NULL AS OptionalId, '' AS Icone, A.IdAluno AS Ordem
				FROM TbAluno A WITH(NOLOCK)
					INNER JOIN TbResponsavelAluno B WITH(NOLOCK) ON A.IdAluno = B.Aluno
					INNER JOIN TbResponsavel C WITH(NOLOCK) ON C.IdResponsavel = B.Responsavel
				WHERE C.Usuario = @IDUSUARIO
				UNION
				SELECT 
					IdMenu, 
					CASE WHEN (MN.IdMenuPai IN (998,999)) THEN FLH.IdAluno*(-1) ELSE MN.IdMenuPai END IdMenuPai, Texto, Descricao, ControllerName, ActionName, CASE WHEN (MN.IdMenuPai IN (998,999)) THEN FLH.IdAluno ELSE NULL END OptionalId, Icone, Ordem
				FROM TbMenu MN WITH(NOLOCK)
					INNER JOIN TbResponsavel RES WITH(NOLOCK) ON RES.Usuario = @IDUSUARIO
					INNER JOIN TbResponsavelAluno RESA WITH(NOLOCK) ON RESA.Responsavel = RES.IdResponsavel
					LEFT JOIN TbAluno FLH WITH(NOLOCK) ON FLH.IdAluno = RESA.Aluno AND MN.IdMenuPai IN (998,999)
				WHERE MN.IdMenu IN (1) OR MN.IdMenuPai IN (1,998,999)
				ORDER BY IdMenu,Ordem
			END
			ELSE
			BEGIN
				SELECT IdAluno*(-1) AS IdMenu, 0 AS IdMenuPai, Nome AS Texto, NULL AS Descricao, NULL AS ControllerName, NULL AS ActionName, NULL AS OptionalId, '' AS Icone, IdAluno AS Ordem
				FROM TbAluno WITH(NOLOCK)
				WHERE Usuario = @IDUSUARIO
				UNION
				SELECT 
					IdMenu, 
					CASE WHEN (MN.IdMenuPai IN (998,999)) THEN FLH.IdAluno*(-1) ELSE MN.IdMenuPai END IdMenuPai, Texto, Descricao, ControllerName, ActionName, CASE WHEN (MN.IdMenuPai IN (998,999)) THEN FLH.IdAluno ELSE NULL END OptionalId, Icone, Ordem
				FROM TbMenu MN WITH(NOLOCK)
					INNER JOIN TbAluno FLH WITH(NOLOCK) ON FLH.Usuario = @IDUSUARIO AND MN.IdMenuPai IN (998,999)
				WHERE MN.IdMenu IN (1) OR MN.IdMenuPai IN (1,998,999)
				ORDER BY IdMenu,Ordem
			END
		END
	END
END
GO