USE DOBLONES20
GO

DROP PROCEDURE InsertarVentasProductosDevoluciones
GO

CREATE PROCEDURE InsertarVentasProductosDevoluciones
@NumeroAgencia					INT,
@NumeroVentaProducto			INT,
@CodigoEstadoDevolucion			CHAR(1),
@CodigoUsuario					INT,
@FechaHoraSolicitudReemDevo		DATE,
@ObservacionesSolicitudReemDevo TEXT,
@NumeroDevolucionDevolucion		INT
AS
BEGIN
	INSERT INTO dbo.VentasProductosDevoluciones (NumeroAgencia, NumeroVentaProducto, CodigoEstadoDevolucion, CodigoUsuario, FechaHoraSolicitudReemDevo, ObservacionesSolicitudReemDevo, NumeroDevolucionDevolucion)
	VALUES (@NumeroAgencia, @NumeroVentaProducto, @CodigoEstadoDevolucion, @CodigoUsuario, @FechaHoraSolicitudReemDevo, @ObservacionesSolicitudReemDevo, @NumeroDevolucionDevolucion)
END
GO

DROP PROCEDURE ActualizarVentasProductosDevoluciones
GO

CREATE PROCEDURE ActualizarVentasProductosDevoluciones
@NumeroAgencia					INT,
@NumeroDevolucion				INT,
@CodigoEstadoDevolucion			CHAR(1),
@FechaHoraSolicitudReemDevo		DATE,
@ObservacionesSolicitudReemDevo TEXT,
@NumeroDevolucionDevolucion		INT
AS
BEGIN
	UPDATE 	dbo.VentasProductosDevoluciones
	SET	
		CodigoEstadoDevolucion			= @CodigoEstadoDevolucion,
		FechaHoraSolicitudReemDevo		= @FechaHoraSolicitudReemDevo,
		ObservacionesSolicitudReemDevo	= @ObservacionesSolicitudReemDevo,
		NumeroDevolucionDevolucion		= @NumeroDevolucionDevolucion
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion	
END
GO

DROP PROCEDURE EliminarVentasProductosDevoluciones
GO

CREATE PROCEDURE EliminarVentasProductosDevoluciones
@NumeroAgencia					INT,
@NumeroDevolucion				INT
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductosDevoluciones
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
END
GO

DROP PROCEDURE ListarVentasProductosDevoluciones
GO

CREATE PROCEDURE ListarVentasProductosDevoluciones
@NumeroAgencia	INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroDevolucion, NumeroVentaProducto, CodigoEstadoDevolucion, CodigoUsuario, FechaHoraSolicitudReemDevo, ObservacionesSolicitudReemDevo, NumeroDevolucionDevolucion
	FROM dbo.VentasProductosDevoluciones
	WHERE NumeroAgencia = @NumeroAgencia
	ORDER BY NumeroVentaProducto,NumeroDevolucion
END
GO


DROP PROCEDURE ObtenerVentaProductoDevolucion
GO

CREATE PROCEDURE ObtenerVentaProductoDevolucion
@NumeroAgencia					INT,
@NumeroDevolucion				INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroDevolucion, NumeroVentaProducto, CodigoEstadoDevolucion, CodigoUsuario, FechaHoraSolicitudReemDevo, ObservacionesSolicitudReemDevo, NumeroDevolucionDevolucion
	FROM dbo.VentasProductosDevoluciones	
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
END
GO


DROP PROCEDURE FinalizarAnularVentaProductoDevolucion
GO

CREATE PROCEDURE FinalizarAnularVentaProductoDevolucion
@NumeroAgencia					INT,
@NumeroDevolucion				INT,
@CodigoEstadoDevolucion			CHAR(1),
@FechaHoraSolicitudReemDevo		DATETIME
AS
BEGIN
	BEGIN TRANSACTION
	
	
	UPDATE 	dbo.VentasProductosDevoluciones
	SET	
		CodigoEstadoDevolucion			= @CodigoEstadoDevolucion		
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
	
	
	IF(@FechaHoraSolicitudReemDevo IS NOT NULL)
	BEGIN
		UPDATE 	dbo.VentasProductosDevoluciones
		SET				
			FechaHoraSolicitudReemDevo		= @FechaHoraSolicitudReemDevo
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroDevolucion = @NumeroDevolucion
	END
	
	IF (@@error<> 0) 
	BEGIN
		ROLLBACK TRAN
	   	RAISERROR ('No se pudo Actualizar Correctamente la Devolución',16,2)
	END
	
	COMMIT TRAN
	
END
GO

DROP PROCEDURE ReporteVentasProductosDevoluciones
GO

CREATE PROCEDURE ReporteVentasProductosDevoluciones
@NumeroAgencia		INT,
@NumeroDevolucion	INT
AS
BEGIN
	SELECT VPD.NumeroAgencia, VPD.NumeroDevolucion, 
	ISNULL(U.Nombres,' ') + ' ' + ISNULL(U.Paterno,' ') + ' ' + ISNULL(U.Materno,' ') as UsuarioResponsable, 
	VPD.FechaHoraSolicitudReemDevo, VPD.ObservacionesSolicitudReemDevo ,
	DBO.ObtenerProductosEntregados(@NumeroAgencia, VPD.NumeroVentaProducto, 'V') AS ListaProductos
	FROM VentasProductosDevoluciones VPD INNER JOIN Usuarios U ON VPD.CodigoUsuario = U.CodigoUsuario
	WHERE VPD.NumeroAgencia = @NumeroAgencia AND VPD.NumeroDevolucion = @NumeroDevolucion	
END
GO