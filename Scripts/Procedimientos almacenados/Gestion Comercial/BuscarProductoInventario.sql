USE DOBLONES20
DROP PROCEDURE BuscarProductoInventario
GO

CREATE PROCEDURE BuscarProductoInventario
	@CodigoProducto			CHAR(15),
	@NombreProducto			VARCHAR(250),
	@CantidadExistencia		INT	
AS


IF (@CantidadExistencia >0 )
BEGIN
	SELECT IP.NumeroAgencia, IP.CodigoProducto, IP.CantidadExistencia, IP.CantidadRequerida, IP.PrecioUnitarioCompra, IP.TiempoGarantiaProducto, IP.PorcentajeUtilidad1, IP.PrecioUnitarioVenta1, IP.PorcentajeUtilidad2, IP.PrecioUnitarioVenta2, IP.PorcentajeUtilidad3, IP.PrecioUnitarioVenta3, IP.PorcentajeUtilidad4, IP.PrecioUnitarioVenta4, IP.PorcentajeUtilidad5, IP.PrecioUnitarioVenta5, IP.PorcentajeUtilidad6, IP.PrecioUnitarioVenta6, IP.StockMinimo, IP.MostrarParaVenta, CASE (IP.ClaseProducto) WHEN 'C' THEN 'COMPUESTO' WHEN 'S' THEN 'SIMPLE' END AS ClaseProducto , P.NombreProducto, RTRIM(LTRIM(CAST (ISNULL(P.Descripcion,'Ninguna') AS VARCHAR(8000)))) AS Descripcion,  CASE WHEN (P.CodigoProducto IN (SELECT IPES.CodigoProducto FROM InventariosProductosEspecificos IPES INNER JOIN InventariosProductos IP1 ON IP1.CodigoProducto = IPES.CodigoProducto 	
			WHERE IP1.CantidadExistencia = (SELECT COUNT(*) FROM InventariosProductosEspecificos IPE1 WHERE IPE1.CodigoProducto = IP1.CodigoProducto AND IPE1.CodigoEstado = 'A')	
			GROUP BY IPES.CodigoProducto))THEN 1 ELSE 0 END AS ProductoEspecificoInventariado
	FROM dbo.Productos P INNER JOIN dbo.InventariosProductos IP on IP.CodigoProducto = P.CodigoProducto	
	WHERE RTRIM(LTRIM(P.CodigoProducto)) LIKE '%' +RTRIM(LTRIM(@CodigoProducto)) + '%'
	AND RTRIM(LTRIM(P.NombreProducto)) LIKE '%'+ RTRIM(LTRIM(@NombreProducto)) + '%'
	AND IP.CantidadExistencia >= @CantidadExistencia
	ORDER BY P.NombreProducto, P.CodigoProducto
END
ELSE
BEGIN
	SELECT IP.NumeroAgencia, IP.CodigoProducto, IP.CantidadExistencia, IP.CantidadRequerida, IP.PrecioUnitarioCompra, IP.TiempoGarantiaProducto, IP.PorcentajeUtilidad1, IP.PrecioUnitarioVenta1, IP.PorcentajeUtilidad2, IP.PrecioUnitarioVenta2, IP.PorcentajeUtilidad3, IP.PrecioUnitarioVenta3, IP.PorcentajeUtilidad4, IP.PrecioUnitarioVenta4, IP.PorcentajeUtilidad5, IP.PrecioUnitarioVenta5, IP.PorcentajeUtilidad6, IP.PrecioUnitarioVenta6, IP.StockMinimo, IP.MostrarParaVenta, CASE (IP.ClaseProducto) WHEN 'C' THEN 'COMPUESTO' WHEN 'S' THEN 'SIMPLE' END AS ClaseProducto , P.NombreProducto, RTRIM(LTRIM(CAST (ISNULL(P.Descripcion,'Ninguna') AS VARCHAR(8000)))) AS Descripcion,  CASE WHEN (P.CodigoProducto IN (SELECT IPES.CodigoProducto FROM InventariosProductosEspecificos IPES INNER JOIN InventariosProductos IP1 ON IP1.CodigoProducto = IPES.CodigoProducto
			WHERE IP1.CantidadExistencia = (SELECT COUNT(*) FROM InventariosProductosEspecificos IPE1 WHERE IPE1.CodigoProducto = IP1.CodigoProducto AND IPE1.CodigoEstado = 'A')	
			GROUP BY IPES.CodigoProducto))THEN 1 ELSE 0 END AS ProductoEspecificoInventariado
	FROM dbo.Productos P INNER JOIN dbo.InventariosProductos IP on IP.CodigoProducto = P.CodigoProducto	
	WHERE RTRIM(LTRIM(P.CodigoProducto)) LIKE '%' +RTRIM(LTRIM(@CodigoProducto)) + '%'
	AND RTRIM(LTRIM(P.NombreProducto)) LIKE '%'+ RTRIM(LTRIM(@NombreProducto)) + '%'
	AND IP.CantidadExistencia < 1
	ORDER BY P.NombreProducto, P.CodigoProducto
END


--exec BuscarProductoInventario '-----','---',-100000000



--SELECT CodigoProducto,COUNT(CodigoProducto)  FROM InventariosProductosEspecificos ipe
--group by CodigoProducto
--having COUNT(CodigoProducto) = (select ip.CantidadExistencia from InventariosProductos ip where ip.CodigoProducto = ipe.CodigoProducto)



--SELECT IP.* , P.NombreProducto, RTRIM(LTRIM(CAST (ISNULL(P.Descripcion,'Ninguna') AS VARCHAR(8000)))) AS Descripcion,  CASE WHEN (P.CodigoProducto IN (SELECT IPES.CodigoProducto FROM InventariosProductosEspecificos IPES INNER JOIN InventariosProductos IP1 ON IP1.CodigoProducto = IPES.CodigoProducto 	
--			WHERE IP1.CantidadExistencia = (SELECT COUNT(*) FROM InventariosProductosEspecificos IPE1 WHERE IPE1.CodigoProducto = IP1.CodigoProducto AND IPE1.CodigoEstado = 'A')	
--			GROUP BY IPES.CodigoProducto))THEN 1 ELSE 0 END AS ProductoEspecificoInventariado
--	FROM dbo.Productos P INNER JOIN dbo.InventariosProductos IP on IP.CodigoProducto = P.CodigoProducto	
--	ORDER BY ProductoEspecificoInventariado desc
	
--select * from InventariosProductosEspecificos
--where CodigoProducto = '200'

--select * from InventariosProductos
--where CodigoProducto = '200'