USE DOBLONES20
GO



DROP PROCEDURE InsertarCotizacionVentaProductoDeta
GO
CREATE PROCEDURE InsertarCotizacionVentaProductoDeta
	@NumeroAgencia					INT,
	@NumeroCotizacionVentaProducto	INT,
	@CodigoProducto					CHAR(15),
	@CantidadCotizacionVenta		INT,	
	@PrecioUnitarioCotizacionVenta	DECIMAL(10,2),
	@TiempoGarantiaCotizacionVenta	INT,
	@PorcentajeDescuento			DECIMAL(10,2),
	@NumeroPrecioSeleccionado		CHAR(1)
AS
BEGIN
	INSERT INTO dbo.CotizacionVentasProductosDeta(NumeroAgencia,NumeroCotizacionVentaProducto,CodigoProducto,CantidadCotizacionVenta,PrecioUnitarioCotizacionVenta,TiempoGarantiaCotizacionVenta, PorcentajeDescuento, NumeroPrecioSeleccionado)
	VALUES (@NumeroAgencia,@NumeroCotizacionVentaProducto,@CodigoProducto,@CantidadCotizacionVenta,@PrecioUnitarioCotizacionVenta,@TiempoGarantiaCotizacionVenta, @PorcentajeDescuento, @NumeroPrecioSeleccionado)
END
GO



DROP PROCEDURE ActualizarCotizacionVentaProductoDeta
GO
CREATE PROCEDURE ActualizarCotizacionVentaProductoDeta
	@NumeroAgencia					INT,
	@NumeroCotizacionVentaProducto	INT,
	@CodigoProducto					CHAR(15),
	@CantidadCotizacionVenta		INT,	
	@PrecioUnitarioCotizacionVenta	DECIMAL(10,2),
	@TiempoGarantiaCotizacionVenta	INT,
	@PorcentajeDescuento			DECIMAL(10,2),
	@NumeroPrecioSeleccionado		CHAR(1)
AS
BEGIN
	UPDATE 	dbo.CotizacionVentasProductosDeta
	SET						
		CantidadCotizacionVenta			= @CantidadCotizacionVenta,
		PrecioUnitarioCotizacionVenta	= @PrecioUnitarioCotizacionVenta,
		TiempoGarantiaCotizacionVenta	= @TiempoGarantiaCotizacionVenta,
		PorcentajeDescuento				= @PorcentajeDescuento,
		NumeroPrecioSeleccionado		= @NumeroPrecioSeleccionado	
	WHERE ( NumeroCotizacionVentaProducto= @NumeroCotizacionVentaProducto) 
		AND	  ( CodigoProducto = @CodigoProducto)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE EliminarCotizacionVentaProductoDeta
GO
CREATE PROCEDURE EliminarCotizacionVentaProductoDeta
	@NumeroAgencia					INT,
	@NumeroCotizacionVentaPtoducto	INT,
	@CodigoProducto					CHAR(15)
AS
BEGIN
	DELETE 
	FROM dbo.CotizacionVentasProductosDeta
	WHERE ( NumeroCotizacionVentaProducto= @NumeroCotizacionVentaPtoducto) 
		AND	  ( CodigoProducto = @CodigoProducto)
		AND (NumeroAgencia = @NumeroAgencia)
			
END
GO



DROP PROCEDURE ListarCotizacionVentasProductosDeta
GO
CREATE PROCEDURE ListarCotizacionVentasProductosDeta
	@NumeroAgencia					INT,
	@NumeroCotizacionVentaProducto	INT
AS
BEGIN
	IF(@NumeroCotizacionVentaProducto > 0)  -- PARA Obtener el Detalle de una Cotizacion de Venta
	BEGIN
		SELECT NumeroAgencia,NumeroCotizacionVentaProducto,CodigoProducto,CantidadCotizacionVenta,PrecioUnitarioCotizacionVenta,TiempoGarantiaCotizacionVenta, PorcentajeDescuento, NumeroPrecioSeleccionado
		FROM dbo.CotizacionVentasProductosDeta
		WHERE ( NumeroCotizacionVentaProducto= @NumeroCotizacionVentaProducto) 
			AND (NumeroAgencia = @NumeroAgencia)
		ORDER BY NumeroAgencia, NumeroCotizacionVentaProducto, NumeroOrdenInsertado
	END
	ELSE
	BEGIN
		SELECT NumeroAgencia,NumeroCotizacionVentaProducto,CodigoProducto,CantidadCotizacionVenta,PrecioUnitarioCotizacionVenta,TiempoGarantiaCotizacionVenta, PorcentajeDescuento, NumeroPrecioSeleccionado
		FROM dbo.CotizacionVentasProductosDeta
		WHERE (NumeroAgencia = @NumeroAgencia)
		ORDER BY NumeroAgencia, NumeroCotizacionVentaProducto, 	NumeroOrdenInsertado
	END
	
END
GO



DROP PROCEDURE ObtenerCotizacionVentaProductoDeta
GO
CREATE PROCEDURE ObtenerCotizacionVentaProductoDeta
	@NumeroAgencia					INT,
	@NumeroCotizacionVentaProducto	INT,
	@CodigoProducto					CHAR(15)
AS
BEGIN
	SELECT NumeroAgencia,NumeroCotizacionVentaProducto,CodigoProducto,CantidadCotizacionVenta,PrecioUnitarioCotizacionVenta,TiempoGarantiaCotizacionVenta, PorcentajeDescuento, NumeroPrecioSeleccionado
	FROM dbo.CotizacionVentasProductosDeta
	WHERE ( NumeroCotizacionVentaProducto= @NumeroCotizacionVentaProducto) 
		AND	  ( CodigoProducto = @CodigoProducto)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO





--DROP PROCEDURE ObtenerCotizacionVentasProductosDeta
--GO
--CREATE PROCEDURE ObtenerCotizacionVentasProductosDeta	
--AS
--BEGIN
--	SELECT NumeroAgencia,NumeroCotizacionVentaProducto,CodigoProducto,CantidadCotizacionVenta,PrecioUnitarioCotizacionVenta,TiempoGarantiaCotizacionVenta
--	FROM dbo.CotizacionVentasProductosDeta	
--END
--GO

