USE 
Doblones20
GO


DROP VIEW CardinalidadPrecioDevoluciones 
GO


CREATE VIEW CardinalidadPrecioDevoluciones 
AS

SELECT  '1x1' AS CARDINALIDAD, NumeroAgencia,NumeroVentaProductosReemDevo, CodigoProductoDevolucion, dbo.ObtenerNombreProducto(CodigoProductoDevolucion) AS NombreProducto , SUM(MontoTotalDevolucion) AS MontoTotalDevolucion , SUM(MontoTotalReemplazo) AS MontoTotalReemplazo, SUM(MontoTotalReemplazo) - SUM(MontoTotalDevolucion) AS PrecioTotal--1x1
FROM VentasProductosReemplazoDevolucionesDetalle vpdd1
WHERE CodigoProductoDevolucion IN(
		SELECT CodigoProductoDevolucion --1xm
		FROM VentasProductosReemplazoDevolucionesDetalle vpdd2
		where vpdd1.NumeroAgencia = vpdd2.NumeroAgencia and vpdd1.NumeroVentaProductosReemDevo = vpdd2.NumeroVentaProductosReemDevo 
		GROUP BY CodigoProductoDevolucion
		HAVING COUNT(CodigoProductoDevolucion) = 1)
and CodigoProductoReemplazo IN (
		SELECT CodigoProductoReemplazo
		FROM VentasProductosReemplazoDevolucionesDetalle vpdd3
		where vpdd1.NumeroAgencia = vpdd3.NumeroAgencia and vpdd1.NumeroVentaProductosReemDevo = vpdd3.NumeroVentaProductosReemDevo 
		GROUP BY CodigoProductoReemplazo
		HAVING COUNT(CodigoProductoReemplazo) = 1)
GROUP BY NumeroAgencia,NumeroVentaProductosReemDevo,CodigoProductoDevolucion
HAVING COUNT(CodigoProductoDevolucion) = 1

UNION

SELECT '1XM' AS CARDINALIDAD, NumeroAgencia,NumeroVentaProductosReemDevo, CodigoProductoDevolucion, dbo.ObtenerNombreProducto(CodigoProductoDevolucion) AS NombreProducto, AVG(MontoTotalDevolucion) AS MontoTotalDevolucion , SUM(MontoTotalReemplazo) AS MontoTotalReemplazo, SUM(MontoTotalReemplazo) - AVG(MontoTotalDevolucion) AS PrecioTotal  --COUNT(*) 1xm
FROM VentasProductosReemplazoDevolucionesDetalle
GROUP BY NumeroAgencia,NumeroVentaProductosReemDevo, CodigoProductoDevolucion
HAVING COUNT(CodigoProductoDevolucion) > 1

UNION
SELECT 'MX1' AS CARDINALIDAD, NumeroAgencia,NumeroVentaProductosReemDevo, CodigoProductoReemplazo, dbo.ObtenerNombreProducto(CodigoProductoReemplazo) AS NombreProducto, SUM(MontoTotalDevolucion) AS MontoTotalDevolucion , AVG(MontoTotalReemplazo) AS MontoTotalReemplazo, AVG(MontoTotalReemplazo) - SUM(MontoTotalDevolucion) AS PrecioTotal -- mx1 COUNT(*)
FROM VentasProductosReemplazoDevolucionesDetalle
GROUP BY NumeroAgencia,NumeroVentaProductosReemDevo, CodigoProductoReemplazo
HAVING COUNT(CodigoProductoReemplazo) > 1

GO

----select SUM(PrecioTotal) from CardinalidadPrecioDevoluciones 
--select * from CardinalidadPrecioDevoluciones 
--WHERE NumeroVentaProductosReemDevo = 1
--SELECT * FROM VentasProductosReemplazoDevolucionesDetalle





--SELECT  '1x1' AS CARDINALIDAD, NumeroAgencia,NumeroVentaProductosReemDevo, CodigoProductoDevolucion, dbo.ObtenerNombreProducto(CodigoProductoDevolucion) AS NombreProducto , SUM(MontoTotalDevolucion) AS MontoTotalDevolucion , SUM(MontoTotalReemplazo) AS MontoTotalReemplazo, SUM(MontoTotalReemplazo) - SUM(MontoTotalDevolucion) AS PrecioTotal--1x1
--FROM VentasProductosReemplazoDevolucionesDetalle vpdd1
--WHERE CodigoProductoDevolucion IN(
--		SELECT CodigoProductoDevolucion --1xm
--		FROM VentasProductosReemplazoDevolucionesDetalle vpdd2
--		where vpdd1.NumeroAgencia = vpdd2.NumeroAgencia and vpdd1.NumeroVentaProductosReemDevo = vpdd2.NumeroVentaProductosReemDevo 
--		GROUP BY CodigoProductoDevolucion
--		HAVING COUNT(CodigoProductoDevolucion) = 1)
--and CodigoProductoReemplazo IN (
--		SELECT CodigoProductoReemplazo
--		FROM VentasProductosReemplazoDevolucionesDetalle vpdd3
--		where vpdd1.NumeroAgencia = vpdd3.NumeroAgencia and vpdd1.NumeroVentaProductosReemDevo = vpdd3.NumeroVentaProductosReemDevo 
--		GROUP BY CodigoProductoReemplazo
--		HAVING COUNT(CodigoProductoReemplazo) = 1)
--GROUP BY NumeroAgencia,NumeroVentaProductosReemDevo,CodigoProductoDevolucion
--HAVING COUNT(CodigoProductoDevolucion) = 1

--select CodigoProductoDevolucion, CodigoProductoReemplazo
--from VentasProductosReemplazoDevolucionesDetalle
--where NumeroVentaProductosReemDevo = 2