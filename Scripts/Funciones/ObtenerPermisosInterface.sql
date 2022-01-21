USE Doblones20

DROP FUNCTION ObtenerPermisosInterface
GO

CREATE FUNCTION ObtenerPermisosInterface (@CodigoUsuario INT, @NumeroAgencia INT, @NombreInterface VARCHAR(250))
RETURNS TABLE
AS
RETURN 
(SELECT UAPI.PermitirInsertar, UAPI.PermitirEditar, UAPI.PermitirEliminar, UAPI.PermitirNavegar, UAPI.PermitirReportes
FROM UsuariosAgenciasPermisosInterfaces UAPI
JOIN SistemaInterfaces SI ON
SI.CodigoInterface = UAPI.CodigoInterface
AND SI.NombreInterface = @NombreInterface
WHERE UAPI.CodigoUsuario = @CodigoUsuario
AND UAPI.NumeroAgencia = @NumeroAgencia
)




