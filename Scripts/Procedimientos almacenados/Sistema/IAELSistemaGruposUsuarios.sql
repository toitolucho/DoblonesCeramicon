USE DOBLONES20
GO

DROP PROCEDURE InsertarSistemaGruposUsuarios
GO

CREATE PROCEDURE InsertarSistemaGruposUsuarios
	@CodigoUsuario		INT,
	@NumeroAgencia		INT,
	@CodigoGrupoSistema	TINYINT
AS
BEGIN
	INSERT INTO dbo.SistemaGruposUsuarios (CodigoUsuario, NumeroAgencia, CodigoGrupoSistema)
	VALUES (@CodigoUsuario, @NumeroAgencia, @CodigoGrupoSistema)
END
GO

DROP PROCEDURE ActualizarSistemaGruposUsuarios
GO

CREATE PROCEDURE ActualizarSistemaGruposUsuarios
	@CodigoUsuario		INT,
	@NumeroAgencia		INT,
	@CodigoGrupoSistema	TINYINT
AS
BEGIN
	UPDATE 	dbo.SistemaGruposUsuarios
	SET				
		NumeroAgencia		= @NumeroAgencia,
		CodigoGrupoSistema = @CodigoGrupoSistema		
END
GO

DROP PROCEDURE EliminarSistemaGruposUsuarios
GO

CREATE PROCEDURE EliminarSistemaGruposUsuarios
	@CodigoUsuario		INT,
	@NumeroAgencia		INT,
	@CodigoGrupoSistema	TINYINT
AS
BEGIN
	DELETE 
	FROM dbo.SistemaGruposUsuarios
	WHERE CodigoGrupoSistema = @CodigoGrupoSistema AND CodigoUsuario = @CodigoUsuario AND NumeroAgencia = @NumeroAgencia
END
GO

DROP PROCEDURE ListarSistemaGruposUsuarios
GO

CREATE PROCEDURE ListarSistemaGruposUsuarios
AS
BEGIN
	SELECT CodigoUsuario, NumeroAgencia, CodigoGrupoSistema
	FROM dbo.SistemaGruposUsuarios
	ORDER BY CodigoGrupoSistema
END
GO

DROP PROCEDURE ObtenerSistemaGruposUsuario
GO

CREATE PROCEDURE ObtenerSistemaGruposUsuario
	@CodigoUsuario	INT
AS
BEGIN
	SELECT CodigoUsuario, NumeroAgencia, CodigoGrupoSistema
	FROM dbo.SistemaGruposUsuarios
	WHERE CodigoUsuario = @CodigoUsuario
END
GO

DROP PROCEDURE ObtenerSistemaGruposUsuarioAgencia
GO

CREATE PROCEDURE ObtenerSistemaGruposUsuarioAgencia
	@CodigoUsuario	INT,
	@NumeroAgencia	INT
	
AS
BEGIN
	SELECT CodigoUsuario, NumeroAgencia, CodigoGrupoSistema
	FROM dbo.SistemaGruposUsuarios
	WHERE CodigoUsuario = @CodigoUsuario
	AND NumeroAgencia = @NumeroAgencia
END
GO

DROP PROCEDURE ObtenerSistemaGrupoUsuarioAgencia
GO

CREATE PROCEDURE ObtenerSistemaGrupoUsuarioAgencia
	@CodigoUsuario			INT,
	@NumeroAgencia			INT,
	@CodigoGrupoSistema		TINYINT
	
AS
BEGIN
	SELECT CodigoUsuario, NumeroAgencia, CodigoGrupoSistema
	FROM dbo.SistemaGruposUsuarios
	WHERE CodigoUsuario = @CodigoUsuario
	AND NumeroAgencia = @NumeroAgencia
	AND CodigoGrupoSistema = @CodigoGrupoSistema
END
GO





USE [Doblones20]
GO
/****** Object:  StoredProcedure [dbo].[RealizarOperacionesSistemaGruposUsuarios]    Script Date: 11/16/2009 11:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[RealizarOperacionesSistemaGruposUsuarios]
	@CodigoUsuario		INT,
	@NumeroAgencia		INT,
	@CodigoGrupoSistema	TINYINT,
	@Seleccionado		BIT
AS
BEGIN
	IF(@Seleccionado = 0) --Eliminar el Registro
	BEGIN
		IF( EXISTS(SELECT * FROM SistemaGruposUsuarios WHERE CodigoGrupoSistema = @CodigoGrupoSistema AND CodigoUsuario = @CodigoUsuario AND NumeroAgencia = @NumeroAgencia))
			EXEC EliminarSistemaGruposUsuarios @CodigoUsuario, @NumeroAgencia, @CodigoGrupoSistema
	END
	IF(@Seleccionado = 1) --InsertarRegistro
	BEGIN
		IF( NOT EXISTS(SELECT * FROM SistemaGruposUsuarios WHERE CodigoGrupoSistema = @CodigoGrupoSistema AND CodigoUsuario = @CodigoUsuario AND NumeroAgencia = @NumeroAgencia))
			EXEC InsertarSistemaGruposUsuarios @CodigoUsuario, @NumeroAgencia, @CodigoGrupoSistema
	END
	
END
