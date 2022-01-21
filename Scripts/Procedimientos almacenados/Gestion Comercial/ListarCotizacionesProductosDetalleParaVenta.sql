
USE DOBLONES20
GO

DROP PROCEDURE ListarCotizacionesProductosDetalleParaVenta
GO

CREATE PROCEDURE ListarCotizacionesProductosDetalleParaVenta
	@NumeroAgencia					INT,
	@NumeroCotizacionVentaProducto	INT
AS
BEGIN
	SELECT CVPD.NumeroAgencia, CVPD.NumeroCotizacionVentaProducto, CVPD.CodigoProducto, P.NombreProducto, CVPD.CantidadCotizacionVenta, CVPD.PrecioUnitarioCotizacionVenta, CVPD.TiempoGarantiaCotizacionVenta, CVPD.PorcentajeDescuento, CVPD.NumeroPrecioSeleccionado	
	FROM CotizacionVentasProductosDeta CVPD INNER JOIN Productos P ON P.CodigoProducto = CVPD.CodigoProducto
	WHERE CVPD.NumeroAgencia = @NumeroAgencia
		AND CVPD.NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
	ORDER BY CVPD.NumeroAgencia,CVPD.NumeroCotizacionVentaProducto, CVPD.NumeroOrdenInsertado
END
