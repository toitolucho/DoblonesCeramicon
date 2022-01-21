USE Doblones20
GO

DROP VIEW KardexArticuloDetalladoTotal
GO

CREATE VIEW KardexArticuloDetalladoTotal
AS
SELECT	TAPrincipal.NumeroAgencia,
		TAPrincipal.NumeroTransaccion, 
		TAPrincipal.NumeroTransaccionReal,
		TAPrincipal.CodigoTransaccionReal, TAPrincipal.FechaHoraEntrega,
		TAPrincipal.CodigoProducto, 
		TAPrincipal.TipoTransaccion, 
		TAPrincipal.CodigoTipoTransaccion,
		TAPrincipal.CantidadEntregada,		
		TAPrincipal.PrecioUnitarioCompra,
		SUM(TASecundaria.CantidadEntregada) AS CantidadAcumulada,
		SUM(TASecundaria.PrecioTotal) AS PrecioTotalAcumulado
FROM
(
	SELECT ROW_NUMBER() OVER(ORDER BY FechaHoraEntrega) AS NumeroTransaccion, *
	FROM
	(			
		
		--INVENTARIO INICIAL	
		SELECT	IP.NumeroAgencia, -1 AS NumeroTransaccionReal, 
				'-1' AS CodigoTransaccionReal, DATEADD(YEAR, -10, GETDATE()) AS FechaHoraEntrega, 
				'IP' AS CodigoTipoTransaccion, 
				IP.CodigoProducto, 'I'  AS TipoTransaccion, 
				IP.CantidadExistencia - DBO.ObtenerCantidadTotalValoradoInventario(IP.NumeroAgencia, IP.CodigoProducto, NULL, NULL) AS CantidadEntregada, 
				--IP.PrecioUnitarioCompra  - DBO.ObtenerMontoTotalValorado(IP.NumeroAgencia, IP.CodigoProducto, NULL, NULL) AS PrecioUnitarioCompra,
				--(IP.CantidadExistencia - DBO.ObtenerCantidadTotalValoradoInventario(IP.NumeroAgencia, IP.CodigoProducto, NULL, NULL)) *
				--(IP.PrecioUnitarioCompra  - DBO.ObtenerMontoTotalValorado(IP.NumeroAgencia, IP.CodigoProducto, NULL, NULL)) AS PrecioTotal
				IP.PrecioUnitarioCompra  AS PrecioUnitarioCompra,
				(IP.CantidadExistencia - DBO.ObtenerCantidadTotalValoradoInventario(IP.NumeroAgencia, IP.CodigoProducto, NULL, NULL)) *
				(IP.PrecioUnitarioCompra) AS PrecioTotal
		FROM InventariosProductos IP
		
		UNION ALL		
		--INGRESOS	
		SELECT	CP.NumeroAgencia, CP.NumeroCompraProducto AS NumeroTransaccionReal, CP.CodigoCompraProducto AS CodigoTransaccionReal, 
				CPDE.FechaHoraEntrega, 'CP' AS CodigoTipoTransaccion,
				CPDE.CodigoProducto, 'I' AS TipoTransaccion, CPDE.CantidadEntregada, CPD.PrecioUnitarioCompra,
				CPDE.CantidadEntregada * CPD.PrecioUnitarioCompra AS PrecioTotal
		FROM ComprasProductos CP
		INNER JOIN ComprasProductosDetalle CPD
		ON CP.NumeroAgencia = CPD.NumeroAgencia
		AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
		INNER JOIN ComprasProductosDetalleEntrega CPDE
		ON CPD.NumeroAgencia = CPDE.NumeroAgencia
		AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto
		AND CPD.CodigoProducto = CPDE.CodigoProducto
		AND CP.CodigoEstadoCompra IN ('F','X')
		
		UNION ALL		

		SELECT	TP.NumeroAgenciaRecepctora, TP.NumeroTransferenciaProducto,  '01-012-125', 
				TPDR.FechaHoraEnvioRecepcion, 'TPR',
				TPDR.CodigoProducto, 'I', TPDR.CantidadEnvioRecepcion, TPD.PrecioUnitarioTransferencia,
				TPD.PrecioUnitarioTransferencia * TPDR.CantidadEnvioRecepcion
		FROM TransferenciasProductos TP
		INNER JOIN TransferenciasProductosDetalle TPD
		ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora
		AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
		INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
		ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
		AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
		AND TPD.CodigoProducto = TPDR.CodigoProducto
		WHERE TPDR.CodigoTipoEnvioRecepcion = 'R'
		AND TP.CodigoEstadoTransferencia  IN('F','X')
		
		UNION ALL

		SELECT	VPD.NumeroAgencia, VPD.NumeroDevolucion, '01-012-125', 
				VPD.FechaHoraSolicitudReemDevo, 'VPD',
				VPDD.CodigoProducto, 'I', VPDD.CantidadDevuelta, VPDD.PrecioUnitarioDevolucion,
				VPDD.CantidadDevuelta * VPDD.PrecioUnitarioDevolucion
		FROM VentasProductosDevoluciones VPD
		INNER JOIN VentasProductosDevolucionesDetalle VPDD
		ON VPD.NumeroAgencia = VPDD.NumeroAgencia
		AND VPD.NumeroDevolucion = VPDD.NumeroDevolucion
		INNER JOIN MotivosReemDevo MRD
		ON VPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
		WHERE MRD.TipoTransaccion = 'V'
		AND MRD.EstadoRetornoInventario IN ('A')		
		AND VPD.CodigoEstadoDevolucion = 'F'
		UNION ALL

		--EGRESOS
		SELECT	VP.NumeroAgencia, VP.NumeroVentaProducto, '0121-123-1', 
				VPDE.FechaHoraEntrega, 'VP',
				VPDE.CodigoProducto, 'E', -VPDE.CantidadEntregada, -VPD.PrecioUnitarioVenta,
				-VPD.PrecioUnitarioVenta * VPDE.CantidadEntregada
		FROM VentasProductos VP
		INNER JOIN VentasProductosDetalle VPD
		ON VP.NumeroAgencia = VPD.NumeroAgencia
		AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
		INNER JOIN VentasProductosDetalleEntrega VPDE
		ON VPD.NumeroAgencia = VPDE.NumeroAgencia
		AND VPD.NumeroVentaProducto = VPDE.NumeroVentaProducto
		AND VPD.CodigoProducto = VPDE.CodigoProducto
		AND VP.CodigoEstadoVenta IN ('F','X')
				
		UNION ALL

		SELECT	TP.NumeroAgenciaEmisora, TP.NumeroTransferenciaProducto, '01-012-125', 
				TPDR.FechaHoraEnvioRecepcion, 'TPE',
				TPDR.CodigoProducto, 'E', -TPDR.CantidadEnvioRecepcion, -TPD.PrecioUnitarioTransferencia,
				-TPDR.CantidadEnvioRecepcion * TPD.PrecioUnitarioTransferencia
		FROM TransferenciasProductos TP
		INNER JOIN TransferenciasProductosDetalle TPD
		ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora
		AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
		INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
		ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
		AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
		AND TPD.CodigoProducto = TPDR.CodigoProducto
		WHERE TPDR.CodigoTipoEnvioRecepcion = 'E'
		AND TP.CodigoEstadoTransferencia IN('F','X')
		
		UNION ALL

		SELECT	CPD.NumeroAgencia, CPD.NumeroDevolucion, '01-021-126', 
				CPD.FechaHoraSolicitudDevolucion, 'CPD',
				CPDD.CodigoProducto, 'E', -CPDD.CantidadDevuelta, -CPDD.PrecioUnitarioDevolucion,
				-CPDD.CantidadDevuelta * CPDD.PrecioUnitarioDevolucion
		FROM ComprasProductosDevoluciones CPD
		INNER JOIN ComprasProductosDevolucionesDetalle CPDD
		ON CPD.NumeroAgencia = CPDD.NumeroAgencia
		AND CPD.NumeroDevolucion = CPDD.NumeroDevolucion
		INNER JOIN MotivosReemDevo MRD
		ON CPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
		WHERE MRD.TipoTransaccion = 'C'
		AND MRD.EstadoRetornoInventario IN ('B','R')		
		AND CPD.CodigoEstadoDevolucion = 'F'
	) TAForanea1
)TAPrincipal
JOIN
(
	SELECT ROW_NUMBER() OVER(ORDER BY FechaHoraEntrega) AS NumeroTransaccion, *
	FROM
	(
		--INVENTARIO INICIAL
		SELECT	IP.NumeroAgencia, -1 AS NumeroTransaccionReal, 
				'-1' AS CodigoTransaccionReal, DATEADD(YEAR, -10, GETDATE()) AS FechaHoraEntrega, 
				'IP' AS CodigoTipoTransaccion, 
				IP.CodigoProducto, 'I'  AS TipoTransaccion, 
				IP.CantidadExistencia - DBO.ObtenerCantidadTotalValoradoInventario(IP.NumeroAgencia, IP.CodigoProducto, NULL, NULL) AS CantidadEntregada, 
				--IP.PrecioUnitarioCompra  - DBO.ObtenerMontoTotalValorado(IP.NumeroAgencia, IP.CodigoProducto, NULL, NULL) AS PrecioUnitarioCompra,
				--(IP.CantidadExistencia - DBO.ObtenerCantidadTotalValoradoInventario(IP.NumeroAgencia, IP.CodigoProducto, NULL, NULL)) *
				--(IP.PrecioUnitarioCompra  - DBO.ObtenerMontoTotalValorado(IP.NumeroAgencia, IP.CodigoProducto, NULL, NULL)) AS PrecioTotal
				IP.PrecioUnitarioCompra  AS PrecioUnitarioCompra,
				(IP.CantidadExistencia - DBO.ObtenerCantidadTotalValoradoInventario(IP.NumeroAgencia, IP.CodigoProducto, NULL, NULL)) *
				(IP.PrecioUnitarioCompra) AS PrecioTotal
		FROM InventariosProductos IP
		
		UNION ALL		
		--INGRESOS
		SELECT	CP.NumeroAgencia, CP.NumeroCompraProducto AS NumeroTransaccionReal, CP.CodigoCompraProducto AS CodigoTransaccionReal, 
				CPDE.FechaHoraEntrega, 'CP' AS CodigoTipoTransaccion,
				CPDE.CodigoProducto, 'I' AS TipoTransaccion, CPDE.CantidadEntregada, CPD.PrecioUnitarioCompra,
				CPDE.CantidadEntregada * CPD.PrecioUnitarioCompra AS PrecioTotal
		FROM ComprasProductos CP
		INNER JOIN ComprasProductosDetalle CPD
		ON CP.NumeroAgencia = CPD.NumeroAgencia
		AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
		INNER JOIN ComprasProductosDetalleEntrega CPDE
		ON CPD.NumeroAgencia = CPDE.NumeroAgencia
		AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto
		AND CPD.CodigoProducto = CPDE.CodigoProducto
		AND CP.CodigoEstadoCompra IN ('F','X')
		
		UNION ALL		

		SELECT	TP.NumeroAgenciaRecepctora, TP.NumeroTransferenciaProducto,  '01-012-125', 
				TPDR.FechaHoraEnvioRecepcion, 'TPR',
				TPDR.CodigoProducto, 'I', TPDR.CantidadEnvioRecepcion, TPD.PrecioUnitarioTransferencia,
				TPD.PrecioUnitarioTransferencia * TPDR.CantidadEnvioRecepcion
		FROM TransferenciasProductos TP
		INNER JOIN TransferenciasProductosDetalle TPD
		ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora
		AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
		INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
		ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
		AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
		AND TPD.CodigoProducto = TPDR.CodigoProducto
		WHERE TPDR.CodigoTipoEnvioRecepcion = 'R'
		AND TP.CodigoEstadoTransferencia  IN('F','X')
		
		UNION ALL

		SELECT	VPD.NumeroAgencia, VPD.NumeroDevolucion, '01-012-125', 
				VPD.FechaHoraSolicitudReemDevo, 'VPD',
				VPDD.CodigoProducto, 'I', VPDD.CantidadDevuelta, VPDD.PrecioUnitarioDevolucion,
				VPDD.CantidadDevuelta * VPDD.PrecioUnitarioDevolucion
		FROM VentasProductosDevoluciones VPD
		INNER JOIN VentasProductosDevolucionesDetalle VPDD
		ON VPD.NumeroAgencia = VPDD.NumeroAgencia
		AND VPD.NumeroDevolucion = VPDD.NumeroDevolucion
		INNER JOIN MotivosReemDevo MRD
		ON VPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
		WHERE MRD.TipoTransaccion = 'V'
		AND MRD.EstadoRetornoInventario IN ('A')		
		AND VPD.CodigoEstadoDevolucion = 'F'
		UNION ALL

		--EGRESOS
		SELECT	VP.NumeroAgencia, VP.NumeroVentaProducto, '0121-123-1', 
				VPDE.FechaHoraEntrega, 'VP',
				VPDE.CodigoProducto, 'E', -VPDE.CantidadEntregada, -VPD.PrecioUnitarioVenta,
				-VPD.PrecioUnitarioVenta * VPDE.CantidadEntregada
		FROM VentasProductos VP
		INNER JOIN VentasProductosDetalle VPD
		ON VP.NumeroAgencia = VPD.NumeroAgencia
		AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
		INNER JOIN VentasProductosDetalleEntrega VPDE
		ON VPD.NumeroAgencia = VPDE.NumeroAgencia
		AND VPD.NumeroVentaProducto = VPDE.NumeroVentaProducto
		AND VPD.CodigoProducto = VPDE.CodigoProducto
		AND VP.CodigoEstadoVenta IN ('F','X')
				
		UNION ALL

		SELECT	TP.NumeroAgenciaEmisora, TP.NumeroTransferenciaProducto, '01-012-125', 
				TPDR.FechaHoraEnvioRecepcion, 'TPE',
				TPDR.CodigoProducto, 'E', -TPDR.CantidadEnvioRecepcion, -TPD.PrecioUnitarioTransferencia,
				-TPDR.CantidadEnvioRecepcion * TPD.PrecioUnitarioTransferencia
		FROM TransferenciasProductos TP
		INNER JOIN TransferenciasProductosDetalle TPD
		ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora
		AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
		INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
		ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
		AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
		AND TPD.CodigoProducto = TPDR.CodigoProducto
		WHERE TPDR.CodigoTipoEnvioRecepcion = 'E'
		AND TP.CodigoEstadoTransferencia IN('F','X')
		
		UNION ALL

		SELECT	CPD.NumeroAgencia, CPD.NumeroDevolucion, '01-021-126', 
				CPD.FechaHoraSolicitudDevolucion, 'CPD',
				CPDD.CodigoProducto, 'E', -CPDD.CantidadDevuelta, -CPDD.PrecioUnitarioDevolucion,
				-CPDD.CantidadDevuelta * CPDD.PrecioUnitarioDevolucion
		FROM ComprasProductosDevoluciones CPD
		INNER JOIN ComprasProductosDevolucionesDetalle CPDD
		ON CPD.NumeroAgencia = CPDD.NumeroAgencia
		AND CPD.NumeroDevolucion = CPDD.NumeroDevolucion
		INNER JOIN MotivosReemDevo MRD
		ON CPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
		WHERE MRD.TipoTransaccion = 'C'
		AND MRD.EstadoRetornoInventario IN ('B','R')		
		AND CPD.CodigoEstadoDevolucion = 'F'
		
	) TAForanea2
)TASecundaria
ON TAPrincipal.NumeroAgencia = TASecundaria.NumeroAgencia
AND TAPrincipal.NumeroTransaccion >= TASecundaria.NumeroTransaccion
AND TAPrincipal.CodigoProducto = TASecundaria.CodigoProducto
GROUP BY TAPrincipal.NumeroAgencia, TAPrincipal.NumeroTransaccion, TAPrincipal.CodigoProducto, 
TAPrincipal.CantidadEntregada, TAPrincipal.TipoTransaccion, TAPrincipal.CodigoTipoTransaccion, TAPrincipal.NumeroTransaccionReal, 
TAPrincipal.CodigoTransaccionReal, TAPrincipal.FechaHoraEntrega,
TAPrincipal.PrecioUnitarioCompra
GO

SELECT * 
FROM KardexArticuloDetalladoTotal
WHERE CodigoProducto = '003-ACE-000001'

SELECT DBO.ObtenerMontoTotalValorado(1, '003-ACE-000001', NULL, NULL) 