USE Doblones20
GO

DROP VIEW ProductosMarcasUnidadesTiposInventario
GO


CREATE VIEW ProductosMarcasUnidadesTiposInventario
AS
	SELECT P.CodigoProducto, P.NombreProducto, P.NombreProducto1, P.NombreProducto2, 
	PM.NombreMarcaProducto, PT.NombreTipoProducto, PU.NombreUnidad, 
	IP.PrecioUnitarioCompra, 
	IP.PrecioUnitarioVenta1, IP.PrecioUnitarioVenta2, IP.PrecioUnitarioVenta3, 
	IP.PrecioUnitarioVenta4, IP.PrecioUnitarioVenta5, IP.PrecioUnitarioVenta6, 
	IP.EsProductoEspecifico, P.Descripcion, IP.CantidadExistencia
	FROM Productos P	
	INNER JOIN InventariosProductos IP ON P.CodigoProducto = IP.CodigoProducto
	INNER JOIN ProductosMarcas PM ON P.CodigoMarcaProducto = PM.CodigoMarcaProducto
	INNER JOIN ProductosTipos PT ON P.CodigoTipoProducto = PT.CodigoTipoProducto
	INNER JOIN ProductosUnidades PU ON P.CodigoUnidad = PU.CodigoUnidad

GO


--SELECT * FROM ProductosMarcasUnidadesTiposInventario