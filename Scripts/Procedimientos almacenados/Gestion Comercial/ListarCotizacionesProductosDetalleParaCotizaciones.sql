
USE DOBLONES20
GO

DROP PROCEDURE ListarCotizacionesProductosDetalleParaCotizaciones
GO

CREATE PROCEDURE ListarCotizacionesProductosDetalleParaCotizaciones
	@NumeroAgencia					INT,  -- Si es -1, para listar sin filtrado
	@NumeroCotizacionVentaProducto	INT
AS
BEGIN
	--Listamos todas las Ventas para una Determinada Agencia
	IF (@NumeroAgencia >0)
	BEGIN
		SELECT CVPD.NumeroAgencia, CVPD.NumeroCotizacionVentaProducto, CVPD.CodigoProducto, P.NombreProducto, CVPD.CantidadCotizacionVenta, CVPD.PrecioUnitarioCotizacionVenta, CVPD.PrecioUnitarioCotizacionOtraMoneda, CVPD.TiempoGarantiaCotizacionVenta, CVPD.PorcentajeDescuento, CVPD.NumeroPrecioSeleccionado
		FROM CotizacionVentasProductosDeta CVPD INNER JOIN Productos P ON P.CodigoProducto = CVPD.CodigoProducto
		WHERE CVPD.NumeroAgencia = @NumeroAgencia AND CVPD.NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
		ORDER BY CVPD.NumeroAgencia,CVPD.NumeroCotizacionVentaProducto, CVPD.NumeroOrdenInsertado
	END
	--Listamos Absolutamente todas las Ventas Realizadas por todas las Agencias
	IF (@NumeroAgencia = -1)
	BEGIN
		SELECT CVPD.NumeroAgencia, CVPD.NumeroCotizacionVentaProducto, CVPD.CodigoProducto, P.NombreProducto, CVPD.CantidadCotizacionVenta, CVPD.PrecioUnitarioCotizacionVenta, CVPD.PrecioUnitarioCotizacionOtraMoneda , CVPD.TiempoGarantiaCotizacionVenta, CVPD.PorcentajeDescuento, CVPD.NumeroPrecioSeleccionado
		FROM CotizacionVentasProductosDeta CVPD INNER JOIN Productos P ON P.CodigoProducto = CVPD.CodigoProducto
		ORDER BY CVPD.NumeroAgencia,CVPD.NumeroCotizacionVentaProducto, cvpd.NumeroOrdenInsertado
	END
END
GO
