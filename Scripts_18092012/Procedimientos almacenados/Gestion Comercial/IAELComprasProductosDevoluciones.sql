USE DOBLONES20
GO

DROP PROCEDURE InsertarComprasProductosDevoluciones
GO

CREATE PROCEDURE InsertarComprasProductosDevoluciones
@NumeroAgencia					INT,
@NumeroCompraProducto			INT,
@CodigoEstadoDevolucion			CHAR(1),
@CodigoUsuario					INT,
@FechaHoraSolicitudDevolucion	DATE,
@ObservacionesSolicitudDevo		TEXT,
@NumeroDevolucionDevolucion		INT
AS
BEGIN
	INSERT INTO dbo.ComprasProductosDevoluciones (NumeroAgencia, NumeroCompraProducto, CodigoEstadoDevolucion, CodigoUsuario, FechaHoraSolicitudDevolucion, ObservacionesSolicitudDevo, NumeroDevolucionDevolucion)
	VALUES (@NumeroAgencia, @NumeroCompraProducto, @CodigoEstadoDevolucion, @CodigoUsuario, @FechaHoraSolicitudDevolucion, @ObservacionesSolicitudDevo, @NumeroDevolucionDevolucion)
END
GO

DROP PROCEDURE ActualizarComprasProductosDevoluciones
GO

CREATE PROCEDURE ActualizarComprasProductosDevoluciones
@NumeroAgencia					INT,
@NumeroDevolucion				INT,
@NumeroCompraProducto			INT,
@CodigoEstadoDevolucion			CHAR(1),
@CodigoUsuario					INT,
@FechaHoraSolicitudDevolucion	DATE,
@ObservacionesSolicitudDevo		TEXT,
@NumeroDevolucionDevolucion		INT
AS
BEGIN
	UPDATE 	dbo.ComprasProductosDevoluciones
	SET
		CodigoEstadoDevolucion			= @CodigoEstadoDevolucion,		
		FechaHoraSolicitudDevolucion	= @FechaHoraSolicitudDevolucion,
		ObservacionesSolicitudDevo		= @ObservacionesSolicitudDevo,
		NumeroDevolucionDevolucion		= @NumeroDevolucionDevolucion
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion	
END
GO

DROP PROCEDURE EliminarComprasProductosDevoluciones
GO

CREATE PROCEDURE EliminarComprasProductosDevoluciones
@NumeroAgencia					INT,
@NumeroDevolucion				INT
AS
BEGIN
	DELETE 
	FROM dbo.ComprasProductosDevoluciones
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
END
GO

DROP PROCEDURE ListarComprasProductosDevoluciones
GO

CREATE PROCEDURE ListarComprasProductosDevoluciones
@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroDevolucion, NumeroCompraProducto, CodigoEstadoDevolucion, CodigoUsuario, FechaHoraSolicitudDevolucion, ObservacionesSolicitudDevo, NumeroDevolucionDevolucion
	FROM dbo.ComprasProductosDevoluciones
	WHERE NumeroAgencia = @NumeroAgencia
	ORDER BY NumeroAgencia, NumeroDevolucion
END
GO


DROP PROCEDURE ObtenerCompraProductoDevolucion
GO

CREATE PROCEDURE ObtenerCompraProductoDevolucion
@NumeroAgencia					INT,
@NumeroDevolucion				INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroDevolucion, NumeroCompraProducto, CodigoEstadoDevolucion, CodigoUsuario, FechaHoraSolicitudDevolucion, ObservacionesSolicitudDevo, NumeroDevolucionDevolucion
	FROM dbo.ComprasProductosDevoluciones
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
END
GO


DROP PROCEDURE FinalizarAnularCompraProductoDevolucion
GO

CREATE PROCEDURE FinalizarAnularCompraProductoDevolucion
@NumeroAgencia					INT,
@NumeroDevolucion				INT,
@CodigoEstadoDevolucion			CHAR(1),
@FechaHoraSolicitudReemDevo		DATETIME
AS
BEGIN
	BEGIN TRANSACTION
	
	
	UPDATE 	dbo.ComprasProductosDevoluciones
	SET	
		CodigoEstadoDevolucion			= @CodigoEstadoDevolucion		
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
	
	
	IF(@FechaHoraSolicitudReemDevo IS NOT NULL)
	BEGIN
		UPDATE 	dbo.ComprasProductosDevoluciones
		SET				
			FechaHoraSolicitudDevolucion = @FechaHoraSolicitudReemDevo
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

DROP PROCEDURE ReporteComprasProductosDevoluciones
GO

CREATE PROCEDURE ReporteComprasProductosDevoluciones
@NumeroAgencia		INT,
@NumeroDevolucion	INT
AS
BEGIN
	SELECT	CPD.NumeroAgencia, CPD.NumeroDevolucion, 
			ISNULL(U.Nombres,' ') + ' ' + ISNULL(U.Paterno,' ') + ' ' + ISNULL(U.Materno,' ') as UsuarioResponsable, 
			CPD.FechaHoraSolicitudDevolucion, CPD.ObservacionesSolicitudDevo ,
			DBO.ObtenerProductosEntregados(@NumeroAgencia, CPD.NumeroCompraProducto, 'C') AS ListaProductos
	FROM ComprasProductosDevoluciones CPD INNER JOIN Usuarios U ON CPD.CodigoUsuario = U.CodigoUsuario
	WHERE CPD.NumeroAgencia = @NumeroAgencia AND CPD.NumeroDevolucion = @NumeroDevolucion	
END
GO
