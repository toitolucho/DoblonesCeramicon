DROP VIEW VListarVentasProductosDetalleEntrega
GO

CREATE VIEW VListarVentasProductosDetalleEntrega
AS
	SELECT VPDE.NumeroAgencia, VPDE.NumeroVentaProducto, VPDE.CodigoProducto, SUM(VPDE.CantidadEntregada) AS CantidadEntregada, VPD.PrecioUnitarioVenta
	FROM VentasProductosDetalleEntrega VPDE
	INNER JOIN VentasProductosDetalle VPD
	ON VPDE.NumeroAgencia = VPD.NumeroAgencia
	AND VPDE.NumeroVentaProducto = VPD.NumeroVentaProducto
	AND VPDE.CodigoProducto = VPD.CodigoProducto
	GROUP BY VPDE.NumeroAgencia, VPDE.NumeroVentaProducto, VPDE.CodigoProducto, VPD.PrecioUnitarioVenta
GO


	
DROP VIEW VListarComprasProductosDetalleEntrega
GO

CREATE VIEW VListarComprasProductosDetalleEntrega
AS
	SELECT VPDE.NumeroAgencia, VPDE.NumeroCompraProducto, VPDE.CodigoProducto, SUM(VPDE.CantidadEntregada) AS CantidadEntregada, VPD.PrecioUnitarioCompra
	FROM ComprasProductosDetalleEntrega VPDE
	INNER JOIN ComprasProductosDetalle VPD
	ON VPDE.NumeroAgencia = VPD.NumeroAgencia
	AND VPDE.NumeroCompraProducto = VPD.NumeroCompraProducto
	AND VPDE.CodigoProducto = VPD.CodigoProducto
	GROUP BY VPDE.NumeroAgencia, VPDE.NumeroCompraProducto, VPDE.CodigoProducto, VPD.PrecioUnitarioCompra
GO