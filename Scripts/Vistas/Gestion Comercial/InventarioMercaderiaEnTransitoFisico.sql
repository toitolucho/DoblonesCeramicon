USE Doblones20
GO

DROP VIEW InventarioMercaderiaEnTransitoFisico
GO

CREATE VIEW InventarioMercaderiaEnTransitoFisico
WITH ENCRYPTION
AS
	SELECT	TSolicitud.NumeroAgencia, TSolicitud.CodigoProducto, dbo.ObtenerNombreProducto(TSolicitud.CodigoProducto) AS NombreProducto,
			TSolicitud.CantidadPendienteRecepcion AS CantidadSolicitada,
			ISNULL(TRecepcionado.CantidadRecepcionada, 0) AS CantidadRecepcionada,
			TSolicitud.CantidadPendienteRecepcion - ISNULL(TRecepcionado.CantidadRecepcionada, 0) AS CantidadEnTransito
	FROM
	(
		SELECT CPD.NumeroAgencia, CPD.CodigoProducto, SUM(CPD.CantidadCompra) AS CantidadPendienteRecepcion
		FROM ComprasProductosDetalle AS CPD
		INNER JOIN ComprasProductos CP
		ON CP.NumeroAgencia = CPD.NumeroAgencia
		AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
		WHERE CP.CodigoEstadoCompra IN ('P','D')
		GROUP BY CPD.NumeroAgencia, CPD.CodigoProducto
	)TSolicitud
	LEFT JOIN
	(
		SELECT CPDE.NumeroAgencia, CPDE.CodigoProducto , SUM(CPDE.CantidadEntregada) AS CantidadRecepcionada
		FROM ComprasProductosDetalleEntrega CPDE
		INNER JOIN ComprasProductos CP
		ON CP.NumeroAgencia = CPDE.NumeroAgencia
		AND CP.NumeroCompraProducto = CPDE.NumeroCompraProducto
		WHERE CP.CodigoEstadoCompra = 'D'
		GROUP BY CPDE.NumeroAgencia, CPDE.CodigoProducto
	) TRecepcionado
	ON TSolicitud.NumeroAgencia = TRecepcionado.NumeroAgencia
	AND TSolicitud.CodigoProducto = TRecepcionado.CodigoProducto
GO	
		
	
