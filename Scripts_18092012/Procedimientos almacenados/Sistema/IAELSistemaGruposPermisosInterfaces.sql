USE DOBLONES20
GO

DROP PROCEDURE InsertarSistemaGrupoPermisoInterface
GO
CREATE PROCEDURE InsertarSistemaGrupoPermisoInterface
@CodigoGrupoSistema		TINYINT,
@CodigoInterface		INT,
@PermitirInsertar		BIT,
@PermitirEditar			BIT,
@PermitirEliminar		BIT,
@PermitirNavegar		BIT,
@PermitirReportes		BIT
AS
BEGIN
	INSERT INTO dbo.SistemaGruposPermisosInterfaces (CodigoGrupoSistema, CodigoInterface, PermitirInsertar, PermitirEditar, PermitirEliminar, PermitirNavegar, PermitirReportes)
	VALUES (@CodigoGrupoSistema, @CodigoInterface, @PermitirInsertar, @PermitirEditar, @PermitirEliminar, @PermitirNavegar, @PermitirReportes)
END
GO

DROP PROCEDURE ActualizarSistemaGrupoPermisoInterface
GO

CREATE PROCEDURE ActualizarSistemaGrupoPermisoInterface
@CodigoGrupoSistema		TINYINT,
@CodigoInterface		INT,
@PermitirInsertar		BIT,
@PermitirEditar			BIT,
@PermitirEliminar		BIT,
@PermitirNavegar		BIT,
@PermitirReportes		BIT
AS
BEGIN
	UPDATE 	dbo.SistemaGruposPermisosInterfaces
	SET			
		PermitirInsertar	= @PermitirInsertar,
		PermitirEditar		= @PermitirEditar,
		PermitirEliminar	= @PermitirEliminar,
		PermitirNavegar		= @PermitirNavegar,
		PermitirReportes	= @PermitirReportes
	WHERE (CodigoGrupoSistema = @CodigoGrupoSistema) AND (CodigoInterface = @CodigoInterface)
END
GO

DROP PROCEDURE EliminarSistemaGrupoPermisoInterface
GO
CREATE PROCEDURE EliminarSistemaGrupoPermisoInterface
@CodigoGrupoSistema		TINYINT,
@CodigoInterface		INT
AS
BEGIN
	DELETE 
	FROM dbo.SistemaGruposPermisosInterfaces
	WHERE (CodigoGrupoSistema = @CodigoGrupoSistema) AND (CodigoInterface = @CodigoInterface)
END
GO

DROP PROCEDURE ListarSistemaGruposPermisosInterfaces
GO
CREATE PROCEDURE ListarSistemaGruposPermisosInterfaces
AS
BEGIN
	SELECT CodigoGrupoSistema, CodigoInterface, PermitirInsertar, PermitirEditar, PermitirEliminar, PermitirNavegar, PermitirReportes
	FROM dbo.SistemaGruposPermisosInterfaces
	ORDER BY CodigoGrupoSistema, CodigoInterface
END
GO

DROP PROCEDURE ObtenerSistemaGrupoPermisoInterface
GO
CREATE PROCEDURE ObtenerSistemaGrupoPermisoInterface
@CodigoGrupoSistema		TINYINT,
@CodigoInterface		INT
AS
BEGIN
	SELECT CodigoGrupoSistema, CodigoInterface, PermitirInsertar, PermitirEditar, PermitirEliminar, PermitirNavegar, PermitirReportes
	FROM dbo.SistemaGruposPermisosInterfaces
	WHERE (CodigoGrupoSistema = @CodigoGrupoSistema) AND (CodigoInterface = @CodigoInterface)
END
GO


DROP PROCEDURE ListarUsuariosAgenciasPermisosInterfacesXGrupo
GO

CREATE PROCEDURE ListarUsuariosAgenciasPermisosInterfacesXGrupo
	@CodigoGrupoSistema		TINYINT
AS
BEGIN	
	SELECT UAPI.CodigoInterface, NombreInterface, TextoInterface, PermitirInsertar, PermitirEditar, PermitirEliminar, PermitirNavegar, PermitirReportes
	FROM dbo.SistemaGruposPermisosInterfaces  UAPI INNER JOIN SistemaInterfaces SI ON SI.CodigoInterface = UAPI.CodigoInterface
	WHERE UAPI.CodigoGrupoSistema = @CodigoGrupoSistema 
	ORDER BY TextoInterface, NombreInterface, UAPI.CodigoInterface
	
END
GO