USE DOBLONES20
GO

DROP PROCEDURE InsertarSistemaGrupo
GO

CREATE PROCEDURE InsertarSistemaGrupo
	@NombreGrupoSistema	VARCHAR(250)
AS
BEGIN
	INSERT INTO dbo.SistemaGrupos (NombreGrupoSistema)
	VALUES (@NombreGrupoSistema)
END
GO

DROP PROCEDURE ActualizarSistemaGrupo
GO

CREATE PROCEDURE ActualizarSistemaGrupo
	@CodigoGrupoSistema	TINYINT,
	@NombreGrupoSistema	VARCHAR(250)
AS
BEGIN
	UPDATE 	dbo.SistemaGrupos
	SET				
		NombreGrupoSistema		= @NombreGrupoSistema		
END
GO

DROP PROCEDURE EliminarSistemaGrupo
GO

CREATE PROCEDURE EliminarSistemaGrupo
		@CodigoGrupoSistema	TINYINT
AS
BEGIN
	DELETE 
	FROM dbo.SistemaGrupos
	WHERE CodigoGrupoSistema = @CodigoGrupoSistema
END
GO

DROP PROCEDURE ListarSistemaGrupos
GO

CREATE PROCEDURE ListarSistemaGrupos
AS
BEGIN
	SELECT CodigoGrupoSistema, NombreGrupoSistema
	FROM dbo.SistemaGrupos
	ORDER BY CodigoGrupoSistema
END
GO

DROP PROCEDURE ObtenerSistemaGrupo
GO

CREATE PROCEDURE ObtenerSistemaGrupo
	@CodigoGrupoSistema	TINYINT
AS
BEGIN
	SELECT CodigoGrupoSistema, NombreGrupoSistema
	FROM dbo.SistemaGrupos
	WHERE CodigoGrupoSistema = @CodigoGrupoSistema
END
GO


DROP PROCEDURE ObtenerSistemaGruposUsuariosPorGrupos
GO

CREATE PROCEDURE ObtenerSistemaGruposUsuariosPorGrupos
	@CodigoUsuario	INT,
	@NumeroAgencia	INT
AS
BEGIN
	SELECT SG.CodigoGrupoSistema, NombreGrupoSistema
	FROM dbo.SistemaGrupos SG INNER JOIN SistemaGruposUsuarios SGU ON SG.CodigoGrupoSistema = SGU.CodigoGrupoSistema
	WHERE CodigoUsuario = @CodigoUsuario AND SGU.NumeroAgencia = @NumeroAgencia
END
GO

