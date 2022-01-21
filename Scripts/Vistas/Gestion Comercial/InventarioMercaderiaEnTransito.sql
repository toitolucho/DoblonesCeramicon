USE Doblones20
GO

DROP VIEW InventarioMercaderiaEnTransito
GO

CREATE VIEW InventarioMercaderiaEnTransito
WITH ENCRYPTION
AS
	
	SELECT	TASolicitud.NumeroAgencia, TASolicitud.NumeroCompraProducto, TASolicitud.CodigoProducto, 
			dbo.ObtenerNombreProducto(TASolicitud.CodigoProducto) as NombreProducto,
			TASolicitud.PrecioUnitarioCompra, TASolicitud.CantidadCompra, 
			CASE WHEN TAPendiente.CantidadEntregada IS NULL THEN 0 ELSE TAPendiente.CantidadEntregada END AS CantidadRecepcionada,
			TASolicitud.CantidadCompra - CASE WHEN TAPendiente.CantidadEntregada IS NULL THEN 0 ELSE TAPendiente.CantidadEntregada END AS CantidadTransito,
			TASolicitud.NombreRazonSocial
	FROM
	(
		SELECT cp.NumeroAgencia, cp.NumeroCompraProducto, CPD.CodigoProducto, CPD.CantidadCompra, CPD.PrecioUnitarioCompra, P.NombreRazonSocial
		FROM ComprasProductos CP
		INNER JOIN ComprasProductosDetalle CPD
		ON CPD.NumeroAgencia=CP.NumeroAgencia
		AND CPD.NumeroCompraProducto = CP.NumeroCompraProducto
		INNER JOIN Proveedores P
		ON CP.CodigoProveedor = P.CodigoProveedor
		WHERE CP.CodigoEstadoCompra IN ('P','D')
	)TASolicitud
	LEFT JOIN
	(
		SELECT CPDE.NumeroAgencia, CPDE.NumeroCompraProducto, CPDE.CodigoProducto, CPDE.CantidadEntregada
		FROM ComprasProductos CP
		INNER JOIN ComprasProductosDetalleEntrega CPDE
		ON CP.NumeroAgencia = CPDE.NumeroAgencia
		AND CP.NumeroCompraProducto = CPDE.NumeroCompraProducto
		WHERE CP.CodigoEstadoCompra IN ('D')
	)TAPendiente
	on TASolicitud.NumeroAgencia = TAPendiente.NumeroAgencia
	and TASolicitud.NumeroCompraProducto = TAPendiente.NumeroCompraProducto
	and TASolicitud.CodigoProducto = TAPendiente.CodigoProducto
GO	



