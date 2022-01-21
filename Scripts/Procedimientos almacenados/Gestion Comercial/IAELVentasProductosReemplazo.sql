USE DOBLONES20
GO

DROP PROCEDURE InsertarVentasProductosReemplazo
GO

CREATE PROCEDURE InsertarVentasProductosReemplazo
@NumeroAgencia					INT,
@NumeroDevolucion				INT,
@CodigoEstadoReemplazo			CHAR(1),
@CodigoUsuario					INT,
@FechaHoraSolicitudReemplazo	DATE,
@ObservacionesReemplazo			TEXT
AS
BEGIN
	INSERT INTO dbo.VentasProductosReemplazo (NumeroAgencia, NumeroDevolucion, CodigoEstadoReemplazo, CodigoUsuario, FechaHoraSolicitudReemplazo, ObservacionesReemplazo)
	VALUES (@NumeroAgencia, @NumeroDevolucion, @CodigoEstadoReemplazo, @CodigoUsuario, @FechaHoraSolicitudReemplazo, @ObservacionesReemplazo)
END
GO

DROP PROCEDURE ActualizarVentasProductosReemplazo
GO

CREATE PROCEDURE ActualizarVentasProductosReemplazo
@NumeroAgencia					INT,
@NumeroReemplazo				INT,
@NumeroDevolucion				INT,
@CodigoEstadoReemplazo			CHAR(1),
@CodigoUsuario					INT,
@FechaHoraSolicitudReemplazo	DATE,
@ObservacionesReemplazo			TEXT
AS
BEGIN
	UPDATE 	dbo.VentasProductosReemplazo
	SET			
		NumeroDevolucion			= @NumeroDevolucion,
		CodigoEstadoReemplazo		= @CodigoEstadoReemplazo,
		CodigoUsuario				= @CodigoUsuario,
		FechaHoraSolicitudReemplazo	= @FechaHoraSolicitudReemplazo,
		ObservacionesReemplazo		= @ObservacionesReemplazo
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroReemplazo = @NumeroReemplazo	
END
GO

DROP PROCEDURE EliminarVentasProductosReemplazo
GO

CREATE PROCEDURE EliminarVentasProductosReemplazo
@NumeroAgencia		INT,
@NumeroReemplazo	INT
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductosReemplazo
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroReemplazo = @NumeroReemplazo
END
GO

DROP PROCEDURE ListarVentasProductosReemplazo
GO

CREATE PROCEDURE ListarVentasProductosReemplazo
@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroReemplazo, NumeroDevolucion, CodigoEstadoReemplazo, CodigoUsuario, FechaHoraSolicitudReemplazo, ObservacionesReemplazo
	FROM dbo.VentasProductosReemplazo
	WHERE NumeroAgencia = @NumeroAgencia
	ORDER BY NumeroAgencia, NumeroDevolucion
END
GO


DROP PROCEDURE ObtenerVentasProductoReemplazo
GO

CREATE PROCEDURE ObtenerVentasProductoReemplazo
@NumeroAgencia		INT,
@NumeroReemplazo	INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroReemplazo, NumeroDevolucion, CodigoEstadoReemplazo, CodigoUsuario, FechaHoraSolicitudReemplazo, ObservacionesReemplazo
	FROM dbo.VentasProductosReemplazo
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroReemplazo = @NumeroReemplazo
END
GO



DROP PROCEDURE FinalizarAnularVentasProductoReemplazo
GO

CREATE PROCEDURE FinalizarAnularVentasProductoReemplazo
@NumeroAgencia					INT,
@NumeroReemplazo				INT,
@CodigoEstadoReemplazo			CHAR(1),
@FechaHoraSolicitudReemplazo	DATE
AS
BEGIN
	IF(@FechaHoraSolicitudReemplazo IS NULL)
	BEGIN
		SELECT @FechaHoraSolicitudReemplazo = FechaHoraSolicitudReemplazo
		FROM VentasProductosReemplazo
		WHERE NumeroAgencia = @NumeroAgencia AND NumeroReemplazo = @NumeroReemplazo
	END
	
	UPDATE 	dbo.VentasProductosReemplazo
	SET
		CodigoEstadoReemplazo	= @CodigoEstadoReemplazo,
		FechaHoraSolicitudReemplazo	= @FechaHoraSolicitudReemplazo		
	WHERE NumeroAgencia = @NumeroAgencia
		 AND NumeroReemplazo = @NumeroReemplazo
END
GO


DROP PROCEDURE ObtenerVentasProductoReemplazo_paraDevolucion
GO

CREATE PROCEDURE ObtenerVentasProductoReemplazo_paraDevolucion
@NumeroAgencia		INT,
@NumeroReemplazo	INT,
@NumeroDevolucion	INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroReemplazo, NumeroDevolucion, CodigoEstadoReemplazo, CodigoUsuario, FechaHoraSolicitudReemplazo, ObservacionesReemplazo
	FROM dbo.VentasProductosReemplazo
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroReemplazo = @NumeroReemplazo
	AND NumeroDevolucion = @NumeroDevolucion
END
GO



DROP PROCEDURE ListarVentasProductosReemplazoReporte
GO

CREATE PROCEDURE ListarVentasProductosReemplazoReporte
@NumeroAgencia		INT,
@NumeroReemplazo	INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroReemplazo, NumeroDevolucion,  ISNULL(U.Nombres,' ') + ' ' + ISNULL(U.Paterno,' ') + ' ' + ISNULL(U.Materno,' ') as UsuarioResponsable, FechaHoraSolicitudReemplazo, ObservacionesReemplazo
	FROM dbo.VentasProductosReemplazo VPR INNER JOIN Usuarios U ON VPR.CodigoUsuario = U.CodigoUsuario
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroReemplazo = @NumeroReemplazo	
END
GO