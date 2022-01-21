USE Doblones20
GO

DROP VIEW MenuPrincipalNodosPadre_Separator
GO

CREATE VIEW MenuPrincipalNodosPadre_Separator
AS
	SELECT CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, NombreBotonBarra, TextoBotonBarra, CodigoInterface 
	FROM SistemaMenuPrincipal SMP 
	WHERE CodigoElementoMenu not in(
						SELECT a.CodigoElementoMenu FROM SistemaMenuPrincipal a left join  SistemaMenuPrincipal b
													ON a.CodigoElementoMenu = b.CodigoElementoMenuPadre
						WHERE b.CodigoElementoMenu is null)
	and SMP.CodigoTipoElementoMenu = 'M'
	UNION
	SELECT a.CodigoElementoMenu, a.CodigoElementoMenuPadre, a.NombreElementoMenu, a.TextoElementoMenu, a.CodigoTipoElementoMenu, a.NombreBotonBarra, a.TextoBotonBarra, a.CodigoInterface
	FROM SistemaMenuPrincipal a
	WHERE a.CodigoTipoElementoMenu = 'S'
	
GO


DROP VIEW MenuPrincipalNodosHojas
GO

CREATE VIEW MenuPrincipalNodosHojas
AS
	SELECT a.CodigoElementoMenu, a.CodigoElementoMenuPadre, a.NombreElementoMenu, a.TextoElementoMenu, a.CodigoTipoElementoMenu, a.NombreBotonBarra, a.TextoBotonBarra, a.CodigoInterface
	FROM SistemaMenuPrincipal a LEFT JOIN  SistemaMenuPrincipal b
		ON a.CodigoElementoMenu = b.CodigoElementoMenuPadre
	WHERE b.CodigoElementoMenu is null
		AND a.CodigoTipoElementoMenu = 'M'
GO
