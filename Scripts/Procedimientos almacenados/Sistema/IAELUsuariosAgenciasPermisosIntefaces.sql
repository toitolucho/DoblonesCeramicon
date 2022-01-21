USE DOBLONES20
GO

DROP PROCEDURE InsertarUsuarioAgenciaPermisoInterface
GO
CREATE PROCEDURE InsertarUsuarioAgenciaPermisoInterface
@CodigoUsuario			INT,
@NumeroAgencia			INT, 
@CodigoInterface		INT,
@PermitirInsertar		BIT,
@PermitirEditar			BIT,
@PermitirEliminar		BIT,
@PermitirNavegar		BIT,
@PermitirReportes		BIT
AS
BEGIN
	INSERT INTO dbo.UsuariosAgenciasPermisosInterfaces (CodigoUsuario, NumeroAgencia, CodigoInterface, PermitirInsertar, PermitirEditar, PermitirEliminar, PermitirNavegar, PermitirReportes)								
	VALUES (@CodigoUsuario, @NumeroAgencia, @CodigoInterface, @PermitirInsertar, @PermitirEditar, @PermitirEliminar, @PermitirNavegar, @PermitirReportes)
END
GO

DROP PROCEDURE ActualizarUsuarioAgenciaPermisoInterface
GO

CREATE PROCEDURE ActualizarUsuarioAgenciaPermisoInterface
@CodigoUsuario			INT,
@NumeroAgencia			INT, 
@CodigoInterface		INT,
@PermitirInsertar		BIT,
@PermitirEditar			BIT,
@PermitirEliminar		BIT,
@PermitirNavegar		BIT,
@PermitirReportes		BIT
AS
BEGIN
	UPDATE 	dbo.UsuariosAgenciasPermisosInterfaces
	SET			
		PermitirInsertar	= @PermitirInsertar,
		PermitirEditar		= @PermitirEditar,
		PermitirEliminar	= @PermitirEliminar,
		PermitirNavegar		= @PermitirNavegar,
		PermitirReportes	= @PermitirReportes
	WHERE (CodigoUsuario = @CodigoUsuario) AND (NumeroAgencia = @NumeroAgencia) AND (CodigoInterface = @CodigoInterface)
END
GO

DROP PROCEDURE EliminarUsuarioAgenciaPermisoInterface
GO
CREATE PROCEDURE EliminarUsuarioAgenciaPermisoInterface
@CodigoUsuario			INT,
@NumeroAgencia			INT, 
@CodigoInterface		INT
AS
BEGIN
	DELETE 
	FROM dbo.UsuariosAgenciasPermisosInterfaces
	WHERE (CodigoUsuario = @CodigoUsuario) AND (NumeroAgencia = @NumeroAgencia) AND (CodigoInterface = @CodigoInterface)
END
GO

DROP PROCEDURE ListarUsuariosAgenciasPermisosInterfaces
GO
CREATE PROCEDURE ListarUsuariosAgenciasPermisosInterfaces
AS
BEGIN
	SELECT CodigoUsuario, NumeroAgencia, CodigoInterface, PermitirInsertar, PermitirEditar, PermitirEliminar, PermitirNavegar, PermitirReportes
	FROM dbo.UsuariosAgenciasPermisosInterfaces
	ORDER BY CodigoUsuario, NumeroAgencia, CodigoInterface
END
GO

DROP PROCEDURE ObtenerUsuarioAgenciaPermisoInterface
GO
CREATE PROCEDURE ObtenerUsuarioAgenciaPermisoInterface
@CodigoUsuario			INT,
@NumeroAgencia			INT, 
@CodigoInterface		INT
AS
BEGIN
	SELECT CodigoUsuario, NumeroAgencia, CodigoInterface, PermitirInsertar, PermitirEditar, PermitirEliminar, PermitirNavegar, PermitirReportes
	FROM dbo.UsuariosAgenciasPermisosInterfaces
	WHERE (CodigoUsuario = @CodigoUsuario) AND (NumeroAgencia = @NumeroAgencia) AND (CodigoInterface = @CodigoInterface)
END
GO


DROP PROCEDURE ObtenerListadoUsuarioAgenciaPermisoInterfaceNuevo
GO

CREATE PROCEDURE ObtenerListadoUsuarioAgenciaPermisoInterfaceNuevo
AS
BEGIN	
	SELECT CodigoInterface, NombreInterface, TextoInterface, CAST (0 as BIT) AS PermitirInsertar, CAST (0 as BIT) AS PermitirEditar, CAST (0 as BIT) AS PermitirEliminar, CAST (0 as BIT) AS PermitirNavegar, CAST (0 as BIT) AS PermitirReportes
	FROM SistemaInterfaces
END
GO


DROP PROCEDURE ListarUsuariosAgenciasPermisosInterfacesXUsuario
GO

CREATE PROCEDURE ListarUsuariosAgenciasPermisosInterfacesXUsuario
	@CodigoUsuario			INT,
	@NumeroAgencia			INT
AS
BEGIN	
	SELECT UAPI.CodigoInterface, NombreInterface, TextoInterface, PermitirInsertar, PermitirEditar, PermitirEliminar, PermitirNavegar, PermitirReportes
	FROM dbo.UsuariosAgenciasPermisosInterfaces  UAPI INNER JOIN SistemaInterfaces SI ON SI.CodigoInterface = UAPI.CodigoInterface
	WHERE UAPI.CodigoUsuario = @CodigoUsuario AND UAPI.NumeroAgencia = @NumeroAgencia
	ORDER BY CodigoUsuario, NumeroAgencia, UAPI.CodigoInterface
	
END
GO


--DROP PROCEDURE ObtenerUsuarioAgencias
--GO
--CREATE PROCEDURE ObtenerUsuarioAgencias
--AS
--BEGIN
--	SELECT CodigoUsuarioAgencia, NombreUsuarioAgencia
--	FROM dbo.UsuarioAgencias
--END
--GO

