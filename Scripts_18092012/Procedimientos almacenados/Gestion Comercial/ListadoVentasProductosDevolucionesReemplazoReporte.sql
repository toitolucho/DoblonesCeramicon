USE Doblones20
GO

DROP PROCEDURE ReporteVentasProductosDevolucionesReemplazo
GO


CREATE PROCEDURE ReporteVentasProductosDevolucionesReemplazo
@NumeroAgencia					INT,
@NumeroReemplazoDevoluciones	INT
AS
BEGIN
	SELECT DISTINCT CASE cd.Cardinalidad WHEN '1x1' THEN 'UN PRODUCTO DEVUELTO POR OTRO PRODUCTO REEMPLAZO' WHEN '1xM' THEN 'UN PRODUCTO DEVUELTO POR MUCHOS PRODUCTOS REEMPLAZO' WHEN 'Mx1' THEN ' MUCHOS PRODUCTOS DEVUELTOS POR UN PRODUCTO DE REEMPLAZO' END AS Cardinalidad, cd.CodigoProductoDevolucion AS CodigoAgrupacion, cd.NombreProducto, cd.MontoTotalDevolucion, cd.MontoTotalReemplazo,  cd.PrecioTotal, vprd.CodigoProductoReemplazo ,  dbo.ObtenerNombreProducto(vprd.CodigoProductoReemplazo) AS NombreProductoReemplazo, vprd.MontoTotalReemplazo AS MontoReemplazo
	FROM VentasProductosReemplazoDevolucionesDetalle vprd INNER JOIN
	dbo.CardinalidadPrecioDevoluciones cd on vprd.NumeroAgencia = cd.NumeroAgencia
	AND cd.NumeroVentaProductosReemDevo = vprd.NumeroVentaProductosReemDevo and vprd.CodigoProductoDevolucion  = cd.CodigoProductoDevolucion AND CD.NumeroVentaProductosReemDevo = @NumeroReemplazoDevoluciones
	WHERE cd.Cardinalidad = '1x1' or cd.Cardinalidad = '1xM' AND vprd.NumeroAgencia = @NumeroAgencia AND vprd.NumeroVentaProductosReemDevo = @NumeroReemplazoDevoluciones
	UNION
	SELECT DISTINCT CASE cd.Cardinalidad WHEN '1x1' THEN 'UN PRODUCTO DEVUELTO POR OTRO PRODUCTO REEMPLAZO' WHEN '1xM' THEN 'UN PRODUCTO DEVUELTO POR MUCHOS PRODUCTOS REEMPLAZO' WHEN 'Mx1' THEN ' MUCHOS PRODUCTOS DEVUELTOS POR UN PRODUCTO DE REEMPLAZO' END AS Cardinalidad, cd.CodigoProductoDevolucion AS CodigoAgrupacion, cd.NombreProducto, cd.MontoTotalDevolucion, cd.MontoTotalReemplazo, cd.PrecioTotal, vprd.CodigoProductoDevolucion, dbo.ObtenerNombreProducto(vprd.CodigoProductoDevolucion) AS NombreProductoDevolucion, vprd.MontoTotalDevolucion AS MontoReemplazo
	FROM VentasProductosReemplazoDevolucionesDetalle vprd INNER JOIN
	dbo.CardinalidadPrecioDevoluciones cd on vprd.NumeroAgencia = cd.NumeroAgencia
	AND cd.NumeroVentaProductosReemDevo = vprd.NumeroVentaProductosReemDevo and vprd.CodigoProductoReemplazo  = cd.CodigoProductoDevolucion AND CD.NumeroVentaProductosReemDevo = @NumeroReemplazoDevoluciones
	WHERE cd.Cardinalidad = 'Mx1' AND vprd.NumeroAgencia = @NumeroAgencia AND vprd.NumeroVentaProductosReemDevo = @NumeroReemplazoDevoluciones
END

EXEC ReporteVentasProductosDevolucionesReemplazo 1,1

