USE Doblones20
GO

DROP PROCEDURE ListarInventarioGeneral
GO

CREATE PROCEDURE ListarInventarioGeneral
	@NumeroAgencia	INT
AS
BEGIN
	IF(@NumeroAgencia >0)
	BEGIN
		SELECT IP.CodigoProducto,P.NombreProducto, PM.NombreMarcaProducto,PT.NombreCortoTipoProducto, PU.NombreUnidad, ip.PrecioUnitarioCompra, IP.CantidadExistencia, IP.CantidadRequerida
		FROM InventariosProductos IP INNER JOIN Productos P ON P.CodigoProducto = IP.CodigoProducto
		INNER JOIN  ProductosMarcas PM ON P.CodigoMarcaProducto = PM.CodigoMarcaProducto
		INNER JOIN ProductosTipos PT ON PT.CodigoTipoProducto = P.CodigoTipoProducto
		INNER JOIN ProductosUnidades PU ON PU.CodigoUnidad = P.CodigoUnidad
		WHERE IP.NumeroAgencia = @NumeroAgencia
		ORDER BY P.NombreProducto
	END	
	ELSE
	BEGIN
		SELECT IP.CodigoProducto,P.NombreProducto, PM.NombreMarcaProducto,PT.NombreCortoTipoProducto, PU.NombreUnidad, ip.PrecioUnitarioCompra, IP.CantidadExistencia, IP.CantidadRequerida
		FROM InventariosProductos IP INNER JOIN Productos P ON P.CodigoProducto = IP.CodigoProducto
		INNER JOIN  ProductosMarcas PM ON P.CodigoMarcaProducto = PM.CodigoMarcaProducto
		INNER JOIN ProductosTipos PT ON PT.CodigoTipoProducto = P.CodigoTipoProducto
		INNER JOIN ProductosUnidades PU ON PU.CodigoUnidad = P.CodigoUnidad
		ORDER BY P.NombreProducto
	END
END
GO


DROP PROCEDURE ListarInvetarioProductosAgotadosGeneral
GO

CREATE PROCEDURE ListarInvetarioProductosAgotadosGeneral
	@NumeroAgencia	INT
AS
BEGIN
	IF(@NumeroAgencia >0)
	BEGIN
		SELECT IP.CodigoProducto,P.NombreProducto, PM.NombreMarcaProducto,PT.NombreCortoTipoProducto, PU.NombreUnidad, ip.PrecioUnitarioCompra, IP.CantidadExistencia, IP.CantidadRequerida
		FROM InventariosProductos IP INNER JOIN Productos P ON P.CodigoProducto = IP.CodigoProducto
		INNER JOIN  ProductosMarcas PM ON P.CodigoMarcaProducto = PM.CodigoMarcaProducto
		INNER JOIN ProductosTipos PT ON PT.CodigoTipoProducto = P.CodigoTipoProducto
		INNER JOIN ProductosUnidades PU ON PU.CodigoUnidad = P.CodigoUnidad
		WHERE IP.NumeroAgencia = @NumeroAgencia AND IP.CantidadExistencia <= 0
		ORDER BY P.NombreProducto
	END	
	ELSE
	BEGIN
		SELECT IP.CodigoProducto,P.NombreProducto, PM.NombreMarcaProducto,PT.NombreCortoTipoProducto, PU.NombreUnidad, ip.PrecioUnitarioCompra, IP.CantidadExistencia, IP.CantidadRequerida
		FROM InventariosProductos IP INNER JOIN Productos P ON P.CodigoProducto = IP.CodigoProducto
		INNER JOIN  ProductosMarcas PM ON P.CodigoMarcaProducto = PM.CodigoMarcaProducto
		INNER JOIN ProductosTipos PT ON PT.CodigoTipoProducto = P.CodigoTipoProducto
		INNER JOIN ProductosUnidades PU ON PU.CodigoUnidad = P.CodigoUnidad
		WHERE IP.CantidadExistencia <= 0
		ORDER BY P.NombreProducto
	END
END
GO



--EXEC ListarInventarioGeneral 1

