USE Doblones20
GO

DROP VIEW InventarioRealProductosCompuestos
GO

CREATE VIEW InventarioRealProductosCompuestos
AS
	--SELECT * FROM InventariosProductos WHERE CodigoProducto = '001-16--000001 '
	
	SELECT IA.NumeroAgencia, IA.CodigoProducto, TA.CantidadExistencia, IA.CantidadRequerida, IA.PrecioUnitarioCompra,
			IA.EsProductoEspecifico, TA.CantidadExistencia * IA.PrecioUnitarioCompra AS PrecioValoradoTotal
	FROM InventariosProductos IA
	INNER JOIN
	(
		SELECT IA.NumeroAgencia, PC.CodigoProducto AS CodigoProducto, MIN(IA.CantidadExistencia / PC.Cantidad) AS CantidadExistencia  --PC.CodigoProductoComponente, IA.CantidadExistencia , PC.Cantidad, IA.CantidadExistencia / PC.Cantidad AS CantidadExistencia
		FROM InventariosProductos IA
		INNER JOIN Productos P
		ON IA.CodigoProducto = P.CodigoProducto
		INNER JOIN ProductosCompuestos PC
		ON P.CodigoProducto = PC.CodigoProductoComponente
		GROUP BY IA.NumeroAgencia, PC.CodigoProducto
	)TA
	ON IA.NumeroAgencia = TA.NumeroAgencia
	AND IA.CodigoProducto = TA.CodigoProducto
GO


DROP VIEW InventarioRealProductosComponentesSueltos
GO

CREATE VIEW InventarioRealProductosComponentesSueltos
AS
	SELECT	IA.NumeroAgencia, PC.CodigoProducto, PC.CodigoProductoComponente, IRPC.CantidadExistencia AS CantidadExistenciaCompuesta, 
			IA.CantidadExistencia - (PC.Cantidad * IRPC.CantidadExistencia) AS CantidadSobrante,
			PC.Cantidad as CantidadNecesaria, IA.CantidadExistencia as CantidadExistenciaIndividual
	FROM InventarioRealProductosCompuestos IRPC
	INNER JOIN ProductosCompuestos PC
	ON PC.CodigoProducto = IRPC.CodigoProducto
	INNER JOIN InventariosProductos IA
	ON PC.CodigoProductoComponente = IA.CodigoProducto	
GO
