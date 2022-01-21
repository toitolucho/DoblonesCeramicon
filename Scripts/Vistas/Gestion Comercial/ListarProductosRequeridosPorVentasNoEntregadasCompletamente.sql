USE Doblones20
GO

DROP VIEW ListarProductosRequeridosPorVentasNoEntregadasCompletamente
GO

CREATE VIEW ListarProductosRequeridosPorVentasNoEntregadasCompletamente
AS
	SELECT IP.NumeroAgencia, VPD.CodigoProducto, dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto, SUM(VPD.CantidadEntregada) AS TotalEntregado, SUM(VPD.CantidadVenta) as TotalVendido, AVG(IP.CantidadExistencia) AS ExistenciaActual, AVG(IP.CantidadRequerida) as CantidadRequerida, CAST(AVG(IP.PrecioUnitarioCompra) AS DECIMAL(10,2)) as PrecioUnitarioCompra
	FROM VentasProductos VP INNER JOIN VentasProductosDetalle VPD ON VP.NumeroAgencia = VPD.NumeroAgencia AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
	INNER JOIN InventariosProductos IP ON VPD.CodigoProducto = IP.CodigoProducto
	WHERE (VP.CodigoEstadoVenta <> 'I') AND VPD.CantidadVenta <> VPD.CantidadEntregada
	AND IP.CantidadRequerida > IP.CantidadExistencia
	GROUP BY IP.NumeroAgencia, VPD.CodigoProducto

GO	

--SELECT * FROM ListarProductosRequeridosPorVentasNoEntregadasCompletamente
--ORDER BY NombreProducto
