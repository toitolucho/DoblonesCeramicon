DROP VIEW ListadoProductosVendidosSinStock
GO

CREATE VIEW ListadoProductosVendidosSinStock
AS
	SELECT VPD.CodigoProducto, dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto, SUM(VPD.CantidadEntregada) AS CantidadEntregada, SUM(VPD.CantidadVenta) AS CantidadVenta, AVG(IP.CantidadExistencia) AS CantidadExistencia, AVG(IP.CantidadRequerida) AS CantidadRequerida
	FROM InventariosProductos IP INNER JOIN VentasProductosDetalle VPD ON IP.CodigoProducto = VPD.CodigoProducto
	INNER JOIN VentasProductos VP ON VP.NumeroAgencia = VPD.NumeroAgencia AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
	WHERE CantidadExistencia <= 0 AND VP.CodigoEstadoVenta = 'F'
	AND VPD.CantidadVenta != VPD.CantidadEntregada	
	GROUP BY VPD.CodigoProducto
GO


