DROP FUNCTION ObtenerCantidadTotalDevuelta_deProducto
GO

----	@TipoTransaccion
--'V' -> Venta de Productos
--'C' -> Compra de Productos
--'D' -> Devolucion de una Devolucion de Ventas
--@NumeroTransaccion -> De acuerdo al tipo de Transaccion
CREATE FUNCTION ObtenerCantidadTotalDevuelta_deProducto (@CodigoProducto CHAR(15), @NumeroTransaccion INT, @TipoTransaccion CHAR(1))
RETURNS INT
AS
BEGIN
	DECLARE @Cantidad	INT
	SET @Cantidad = 0
	IF(@TipoTransaccion = 'V')
	BEGIN
		SELECT @Cantidad = SUM(VPDD.CantidadDevuelta)
		FROM dbo.VentasProductosDevoluciones VPD INNER JOIN dbo.VentasProductosDevolucionesDetalle VPDD
		ON VPD.NumeroDevolucion = VPDD.NumeroDevolucion
		WHERE VPD.NumeroVentaProducto = @NumeroTransaccion
		AND VPDD.CodigoProducto = @CodigoProducto AND VPD.CodigoEstadoDevolucion = 'F'
	END
	
	IF(@TipoTransaccion = 'C')
	BEGIN
		SELECT @Cantidad = SUM(CPDD.CantidadDevuelta)
		FROM  dbo.ComprasProductosDevoluciones CPD INNER JOIN dbo.ComprasProductosDevolucionesDetalle CPDD
		ON CPD.NumeroDevolucion = CPDD.NumeroDevolucion
		WHERE CPD.NumeroCompraProducto = @NumeroTransaccion
		AND CPDD.CodigoProducto = @CodigoProducto AND CPD.CodigoEstadoDevolucion = 'F'
	END
	
	IF(@TipoTransaccion = 'D')
	BEGIN
		SELECT @Cantidad = SUM(VPDD.CantidadDevuelta)
		FROM dbo.VentasProductosDevoluciones VPD INNER JOIN dbo.VentasProductosDevolucionesDetalle VPDD
		ON VPD.NumeroDevolucion = VPDD.NumeroDevolucion
		WHERE VPD.NumeroDevolucionDevolucion = @NumeroTransaccion
		AND VPDD.CodigoProducto = @CodigoProducto AND VPD.CodigoEstadoDevolucion = 'F'
	END	

	IF(@Cantidad is NULL)
		SET @Cantidad = 0
	RETURN @Cantidad
END

--SELECT Dbo.ObtenerCantidadTotalDevuelta_deProducto('001-TAR-000009',6,'V')
