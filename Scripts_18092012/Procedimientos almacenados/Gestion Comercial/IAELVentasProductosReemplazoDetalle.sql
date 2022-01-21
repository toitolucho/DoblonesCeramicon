USE DOBLONES20
GO

DROP PROCEDURE InsertarVentasProductosReemplazoDetalle
GO

CREATE PROCEDURE InsertarVentasProductosReemplazoDetalle
@NumeroAgencia				INT,
@NumeroReemplazo			INT,
@CodigoProducto				CHAR(15),
@CantidadDevuelta			INT,
@PrecioUnitarioReemplazo	DECIMAL(10,2),
@TiempoGarantia				INT,
@FechaHoraVencimiento		DATE
AS
BEGIN
	INSERT INTO dbo.VentasProductosReemplazoDetalle (NumeroAgencia, NumeroReemplazo, CodigoProducto, CantidadDevuelta, PrecioUnitarioReemplazo, TiempoGarantia, FechaHoraVencimiento)
	VALUES (@NumeroAgencia, @NumeroReemplazo, @CodigoProducto, @CantidadDevuelta, @PrecioUnitarioReemplazo, @TiempoGarantia, @FechaHoraVencimiento)
END
GO

DROP PROCEDURE ActualizarVentasProductosReemplazoDetalle
GO

CREATE PROCEDURE ActualizarVentasProductosReemplazoDetalle
@NumeroAgencia				INT,
@NumeroReemplazo			INT,
@CodigoProducto				CHAR(15),
@CantidadDevuelta			INT,
@PrecioUnitarioReemplazo	DECIMAL(10,2),
@TiempoGarantia				INT,
@FechaHoraVencimiento		DATE
AS
BEGIN
	UPDATE 	dbo.VentasProductosReemplazoDetalle
	SET		
		CantidadDevuelta		= @CantidadDevuelta,
		PrecioUnitarioReemplazo = @PrecioUnitarioReemplazo,
		TiempoGarantia			= @TiempoGarantia,
		FechaHoraVencimiento	= @FechaHoraVencimiento

	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroReemplazo = @NumeroReemplazo
	AND CodigoProducto = @CodigoProducto	
END
GO

DROP PROCEDURE EliminarVentasProductosReemplazoDetalle
GO

CREATE PROCEDURE EliminarVentasProductosReemplazoDetalle
@NumeroAgencia				INT,
@NumeroReemplazo			INT,
@CodigoProducto				CHAR(15)
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductosReemplazoDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroReemplazo = @NumeroReemplazo
	AND CodigoProducto = @CodigoProducto
END
GO

DROP PROCEDURE ListarVentasProductosReemplazoDetalle
GO

CREATE PROCEDURE ListarVentasProductosReemplazoDetalle
@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroReemplazo, CodigoProducto, CantidadDevuelta, PrecioUnitarioReemplazo, TiempoGarantia, FechaHoraVencimiento
	FROM dbo.VentasProductosReemplazoDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	ORDER BY NumeroAgencia, NumeroReemplazo
END
GO


DROP PROCEDURE ObtenerVentaProductoReemplazoDetalle
GO

CREATE PROCEDURE ObtenerVentaProductoReemplazoDetalle
@NumeroAgencia				INT,
@NumeroReemplazo			INT,
@CodigoProducto				CHAR(15)
AS
BEGIN
	SELECT NumeroAgencia, NumeroReemplazo, CodigoProducto, CantidadDevuelta, PrecioUnitarioReemplazo, TiempoGarantia, FechaHoraVencimiento
	FROM dbo.VentasProductosReemplazoDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroReemplazo = @NumeroReemplazo
	AND CodigoProducto = @CodigoProducto
END
GO


DROP PROCEDURE ListarVentasProductosReemplazoDetalleParaReemplazo
GO

CREATE PROCEDURE ListarVentasProductosReemplazoDetalleParaReemplazo
@NumeroAgencia				INT,
@NumeroReemplazo			INT
AS
BEGIN
	SELECT CodigoProducto, dbo.ObtenerNombreProducto(CodigoProducto) AS NombreProducto, CantidadDevuelta, PrecioUnitarioReemplazo, TiempoGarantia, FechaHoraVencimiento
	FROM dbo.VentasProductosReemplazoDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroReemplazo = @NumeroReemplazo	
END
GO