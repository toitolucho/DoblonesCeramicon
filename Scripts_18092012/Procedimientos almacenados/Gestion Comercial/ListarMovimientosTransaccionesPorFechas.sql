USE Doblones20
GO

DROP PROCEDURE ListarMovimientosTransaccionesPorFechas
GO

CREATE PROCEDURE ListarMovimientosTransaccionesPorFechas
	@NumeroAgencia	INT,
	@FechaInicio	DATETIME,
	@FechaFin		DATETIME
AS
BEGIN


SELECT VP.NumeroVentaProducto, VP.MontoTotalVenta, C.NombreCliente, CASE WHEN VP.NumeroCredito IS NULL THEN 'EFECTIVO' ELSE 'A CREDITO' END AS TipoCobroTransaccion, 'VENTA' AS TipoTransaccion, 'V' CodigoTipoTransaccion, VP.FechaHoraVenta AS FechaHoraTransaccion
FROM VentasProductos VP
INNER JOIN Clientes C
ON VP.CodigoCliente = C.CodigoCliente
WHERE VP.NumeroAgencia = @NumeroAgencia
AND VP.FechaHoraVenta 
BETWEEN CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaInicio,120),120)
AND DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaFin,120),120)))
UNION
SELECT CP.NumeroCompraProducto, CP.MontoTotalCompra, P.NombreRazonSocial, CASE WHEN CodigoTipoCompra = 'E' THEN 'EFECTIVO' ELSE 'A CREDITO' END, 'COMPRAS','C', CP.Fecha
FROM ComprasProductos CP
INNER JOIN Proveedores P
ON CP.CodigoProveedor = P.CodigoProveedor
WHERE CP.NumeroAgencia = @NumeroAgencia
AND CP.Fecha
BETWEEN CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaInicio,120),120)
AND DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaFin,120),120)))
UNION
SELECT CP.NumeroCompraProducto, CPGD.MontoPagoGasto, P.NombreRazonSocial,  GTT.NombreGasto, 'GASTOS POR COMPRAS','C', CPGD.FechaHoraGasto
FROM ComprasProductos CP
INNER JOIN Proveedores P
ON CP.CodigoProveedor = P.CodigoProveedor
INNER JOIN CompraProductosGastosDetalle CPGD
ON CP.NumeroAgencia = CPGD.NumeroAgencia
AND CP.NumeroCompraProducto = CPGD.NumeroCompraProducto
INNER JOIN GastosTiposTransacciones GTT
ON CPGD.CodigoGastosTipos = GTT.CodigoGastosTipos
WHERE CP.NumeroAgencia = @NumeroAgencia
--AND CPGD.FechaHoraGasto
--BETWEEN CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaInicio,120),120)
--AND DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaFin,120),120)))
UNION
SELECT TP.NumeroTransferenciaProducto, TP.MontoTotalTransferencia, A.NombreAgencia, 'EFECTIVO', 'ENVIO TRANSFERENCIA', 'T', TP.FechaHoraTransferencia
FROM TransferenciasProductos TP
INNER JOIN Agencias A
ON TP.NumeroAgenciaRecepctora = A.NumeroAgencia
WHERE TP.NumeroAgenciaEmisora = @NumeroAgencia
AND TP.FechaHoraTransferencia
BETWEEN CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaInicio,120),120)
AND DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaFin,120),120)))
UNION
SELECT TP.NumeroTransferenciaProducto, TPGD.MontoPagoGasto, A.NombreAgencia, GTT.NombreGasto, 'GASTOS POR ENVIO TRANSFERENCIA', 'T', TPGD.FechaHoraGasto
FROM TransferenciasProductos TP
INNER JOIN Agencias A
ON TP.NumeroAgenciaRecepctora = A.NumeroAgencia
INNER JOIN TransferenciasProductosGastosDetalle TPGD
ON TP.NumeroAgenciaEmisora = TPGD.NumeroAgenciaEmisora
AND TP.NumeroTransferenciaProducto = TPGD.NumeroTransferenciaProducto
AND TPGD.CodigoTipoGastoRecepcion = 'E'
INNER JOIN GastosTiposTransacciones GTT
ON TPGD.CodigoGastosTipos = GTT.CodigoGastosTipos
WHERE TP.NumeroAgenciaEmisora = @NumeroAgencia
--AND TPGD.FechaHoraGasto
--BETWEEN CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaInicio,120),120)
--AND DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaFin,120),120)))
UNION 
SELECT VPD.NumeroDevolucion, SUM(VPDD.PrecioUnitarioDevolucion), '', 'EFECTIVO', 'DEVOLUCION POR VENTAS', 'D', VPD.FechaHoraSolicitudReemDevo
FROM VentasProductosDevoluciones VPD
INNER JOIN VentasProductosDevolucionesDetalle VPDD
ON VPD.NumeroAgencia = VPDD.NumeroAgencia
AND VPD.NumeroDevolucion = VPDD.NumeroDevolucion
WHERE VPD.CodigoEstadoDevolucion = 'F'
AND VPD.NumeroAgencia = @NumeroAgencia
AND VPD.FechaHoraSolicitudReemDevo
BETWEEN CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaInicio,120),120)
AND DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaFin,120),120)))
GROUP BY VPD.NumeroDevolucion, VPD.FechaHoraSolicitudReemDevo

UNION
SELECT CPD.NumeroDevolucion, SUM(CPDD.PrecioUnitarioDevolucion),'', 'EFECTIVO', 'DEVOLUCION POR COMPRAS', 'P', CPD.FechaHoraSolicitudDevolucion
FROM ComprasProductosDevoluciones CPD
INNER JOIN ComprasProductosDevolucionesDetalle CPDD
ON CPD.NumeroAgencia = CPDD.NumeroAgencia
AND CPD.NumeroDevolucion = CPDD.NumeroDevolucion
WHERE CPD.CodigoEstadoDevolucion = 'F'
AND CPD.NumeroAgencia = @NumeroAgencia
AND CPD.FechaHoraSolicitudDevolucion
BETWEEN CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaInicio,120),120)
AND DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaFin,120),120)))
GROUP BY CPD.NumeroDevolucion, CPD.FechaHoraSolicitudDevolucion

ORDER BY 7, 6, 1 
END
GO

--exec ListarMovimientosTransaccionesPorFechas 1, '01/01/2009' , '31/12/2010'