USE DOBLONES20
GO

DROP PROCEDURE InsertarComprasProductosDevolucionesDetalle
GO

CREATE PROCEDURE InsertarComprasProductosDevolucionesDetalle
@NumeroAgencia				INT,
@NumeroDevolucion			INT,
@CodigoMotivoReemDevo		INT,
@CodigoProducto				CHAR(15),
@CantidadDevuelta			INT,
@PrecioUnitarioDevolucion	DECIMAL(10,2)
AS
BEGIN
	INSERT INTO dbo.ComprasProductosDevolucionesDetalle (NumeroAgencia, NumeroDevolucion, CodigoMotivoReemDevo, CodigoProducto, CantidadDevuelta, PrecioUnitarioDevolucion)
	VALUES (@NumeroAgencia, @NumeroDevolucion, @CodigoMotivoReemDevo, @CodigoProducto, @CantidadDevuelta, @PrecioUnitarioDevolucion)
END
GO

DROP PROCEDURE ActualizarComprasProductosDevolucionesDetalle
GO

CREATE PROCEDURE ActualizarComprasProductosDevolucionesDetalle
@NumeroAgencia				INT,
@NumeroDevolucion			INT,
@CodigoMotivoReemDevo		INT,
@CodigoProducto				CHAR(15),
@CantidadDevuelta			INT,
@PrecioUnitarioDevolucion	DECIMAL(10,2)
AS
BEGIN
	UPDATE 	dbo.ComprasProductosDevolucionesDetalle
	SET		
		CodigoMotivoReemDevo		= @CodigoMotivoReemDevo,
		CantidadDevuelta			= @CantidadDevuelta,
		PrecioUnitarioDevolucion	= @PrecioUnitarioDevolucion
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
	AND CodigoProducto = @CodigoProducto	
END
GO

DROP PROCEDURE EliminarComprasProductosDevolucionesDetalle
GO

CREATE PROCEDURE EliminarComprasProductosDevolucionesDetalle
@NumeroAgencia				INT,
@NumeroDevolucion			INT,
@CodigoProducto				CHAR(15)
AS
BEGIN
	DELETE 
	FROM dbo.ComprasProductosDevolucionesDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
	AND CodigoProducto = @CodigoProducto
END
GO

DROP PROCEDURE ListarComprasProductosDevolucionesDetalle
GO

CREATE PROCEDURE ListarComprasProductosDevolucionesDetalle
@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroDevolucion, CodigoMotivoReemDevo, CodigoProducto, CantidadDevuelta, PrecioUnitarioDevolucion
	FROM dbo.ComprasProductosDevolucionesDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	ORDER BY NumeroAgencia, NumeroDevolucion
END
GO


DROP PROCEDURE ObtenerCompraProductoDevolucionDetalle
GO

CREATE PROCEDURE ObtenerCompraProductoDevolucionDetalle
@NumeroAgencia				INT,
@NumeroDevolucion			INT,
@CodigoProducto				CHAR(15)
AS
BEGIN
	SELECT NumeroAgencia, NumeroDevolucion, CodigoMotivoReemDevo, CodigoProducto, CantidadDevuelta, PrecioUnitarioDevolucion
	FROM dbo.ComprasProductosDevolucionesDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
	AND CodigoProducto = @CodigoProducto
END
GO


DROP PROCEDURE ListarComprasProductosDevolucionesDetalleParaDevoluciones
GO

CREATE PROCEDURE ListarComprasProductosDevolucionesDetalleParaDevoluciones
@NumeroAgencia				INT,
@NumeroDevolucion			INT
AS
BEGIN
	SELECT MRD.NombreMotivoReemDevo , CodigoProducto, dbo.ObtenerNombreProducto(CodigoProducto) AS NombreProducto, CantidadDevuelta, PrecioUnitarioDevolucion
	FROM dbo.ComprasProductosDevolucionesDetalle VPDD INNER JOIN MotivosReemDevo MRD ON VPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
END
GO