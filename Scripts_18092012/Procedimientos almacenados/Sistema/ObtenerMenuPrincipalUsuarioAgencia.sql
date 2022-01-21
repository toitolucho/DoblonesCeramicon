USE Doblones20
GO

DROP PROCEDURE ObtenerMenuPrincipalUsuarioAgencia
GO

CREATE PROCEDURE ObtenerMenuPrincipalUsuarioAgencia
@CodigoUsuario INT,
@NumeroAgencia INT
AS

SELECT DISTINCT SMP.CodigoElementoMenu, SMP.CodigoElementoMenuPadre, SMP.NombreElementoMenu, SMP1.NombreElementoMenu AS NombreElmentoMenuPadre, SMP.TextoElementoMenu, SMP.CodigoTipoElementoMenu, SMP.URLImagenElementoMenu,SMP.NombreBotonBarra, SMP.NombreBotonBarraPadre, SMP.TextoBotonBarra, SMP.URLImagenBotonBarra, SMP.FuncionEnlace, UAMP.Activo, UAMP.Visible, UAMP.IncluirBotonBarra
FROM UsuariosAgenciasMenuPrincipal UAMP 
JOIN SistemaMenuPrincipal SMP ON
SMP.CodigoElementoMenu = UAMP.CodigoElementoMenu
LEFT JOIN SistemaMenuPrincipal SMP1 ON
SMP1.CodigoElementoMenu = SMP.CodigoElementoMenuPadre
WHERE UAMP.CodigoUsuario = @CodigoUsuario
AND UAMP.NumeroAgencia = @NumeroAgencia
ORDER BY SMP.CodigoElementoMenu
GO