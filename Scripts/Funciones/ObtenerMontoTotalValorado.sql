USE Doblones20
GO

DROP FUNCTION ObtenerMontoTotalValorado
GO


CREATE FUNCTION ObtenerMontoTotalValorado(
	@NumeroAgencia	INT, 
	@CodigoProducto CHAR(15),
	@FechaInicio	DATETIME, 
	@FechaFin		DATETIME
)
RETURNS INT
WITH ENCRYPTION
AS
BEGIN
	DECLARE @MontoTotalValorado		DECIMAL(10,2)
	
	IF(@FechaInicio IS NULL AND @FechaFin IS NULL)
	BEGIN
		
		SELECT @MontoTotalValorado = ISNULL(SUM(TMT.PrecioTotal),0)
		FROM
		(
			--INGRESOS
			SELECT SUM(CPDE.CantidadEntregada * CPD.PrecioUnitarioCompra)AS PrecioTotal
			FROM ComprasProductos CP
			INNER JOIN ComprasProductosDetalle CPD
			ON CP.NumeroAgencia = CPD.NumeroAgencia
			AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto			
			INNER JOIN ComprasProductosDetalleEntrega CPDE
			ON CPD.NumeroAgencia = CPDE.NumeroAgencia
			AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto
			AND CPD.CodigoProducto = CPDE.CodigoProducto
			WHERE CP.NumeroAgencia = @NumeroAgencia
			AND CPDE.CodigoProducto = @CodigoProducto
			AND CP.CodigoEstadoCompra IN ('F','X')
			GROUP BY CPDE.NumeroAgencia, CPDE.NumeroCompraProducto, CPDE.CodigoProducto
			UNION ALL
			SELECT SUM(TPDR.CantidadEnvioRecepcion * TPD.PrecioUnitarioTransferencia)
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalle TPD
			ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			AND TPD.CodigoProducto = TPDR.CodigoProducto
			WHERE TP.CodigoEstadoTransferencia IN ('F','X')
			AND TP.NumeroAgenciaRecepctora = @NumeroAgencia
			AND TPDR.CodigoProducto = @CodigoProducto
			AND TPDR.CodigoTipoEnvioRecepcion ='R'
			GROUP BY TPDR.NumeroAgenciaEmisora, TPDR.NumeroTransferenciaProducto, TPDR.CodigoProducto
			UNION ALL
			SELECT VPDD.CantidadDevuelta * VPDD.PrecioUnitarioDevolucion
			FROM VentasProductosDevoluciones VPD
			INNER JOIN VentasProductosDevolucionesDetalle VPDD
			ON VPD.NumeroAgencia = VPDD.NumeroAgencia
			AND VPD.NumeroDevolucion = VPDD.NumeroDevolucion
			INNER JOIN MotivosReemDevo MRD
			ON VPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
			WHERE MRD.TipoTransaccion = 'V'
			AND VPDD.CodigoProducto = @CodigoProducto
			AND MRD.EstadoRetornoInventario IN ('A')
			AND VPD.NumeroAgencia = @NumeroAgencia
			AND VPD.CodigoEstadoDevolucion = 'F'
			--EGRESOS			
			UNION ALL
			SELECT -SUM(VPDE.CantidadEntregada * VPD.PrecioUnitarioVenta)AS PrecioTotal
			FROM VentasProductos VP
			INNER JOIN VentasProductosDetalle VPD
			ON VP.NumeroAgencia = VPD.NumeroAgencia
			AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
			INNER JOIN VentasProductosDetalleEntrega VPDE
			ON VPD.NumeroAgencia = VPDE.NumeroAgencia
			AND VPD.NumeroVentaProducto = VPDE.NumeroVentaProducto
			AND VPD.CodigoProducto = VPDE.CodigoProducto
			WHERE VP.NumeroAgencia = @NumeroAgencia
			AND VPDE.CodigoProducto = @CodigoProducto
			AND VP.CodigoEstadoVenta IN ('F','X')
			GROUP BY VPDE.NumeroAgencia, VPDE.NumeroVentaProducto, VPDE.CodigoProducto
			UNION ALL
			SELECT -SUM(TPDR.CantidadEnvioRecepcion * TPD.PrecioUnitarioTransferencia)
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalle TPD
			ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			AND TPD.CodigoProducto = TPDR.CodigoProducto
			WHERE TP.NumeroAgenciaEmisora = @NumeroAgencia
			AND TPDR.CodigoProducto = @CodigoProducto
			AND TPDR.CodigoTipoEnvioRecepcion = 'E'
			AND TP.CodigoEstadoTransferencia IN('F','X')
			GROUP BY TPDR.NumeroAgenciaEmisora, TPDR.NumeroTransferenciaProducto, TPDR.CodigoProducto
			UNION ALL
			SELECT -CPDD.CantidadDevuelta * CPDD.PrecioUnitarioDevolucion
			FROM ComprasProductosDevoluciones CPD
			INNER JOIN ComprasProductosDevolucionesDetalle CPDD
			ON CPD.NumeroAgencia = CPDD.NumeroAgencia
			AND CPD.NumeroDevolucion = CPDD.NumeroDevolucion
			INNER JOIN MotivosReemDevo MRD
			ON CPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
			WHERE MRD.TipoTransaccion = 'C'
			AND CPDD.CodigoProducto = @CodigoProducto
			AND MRD.EstadoRetornoInventario IN ('B','R')
			AND CPD.NumeroAgencia = @NumeroAgencia
			AND CPD.CodigoEstadoDevolucion = 'F'
		) TMT

	END
	ELSE
	BEGIN		
		SELECT @MontoTotalValorado = ISNULL(SUM(TMT.PrecioTotal),0)
		FROM
		(
			SELECT SUM(CPDE.CantidadEntregada * CPD.PrecioUnitarioCompra)AS PrecioTotal
			FROM ComprasProductos CP
			INNER JOIN ComprasProductosDetalle CPD
			ON CP.NumeroAgencia = CPD.NumeroAgencia
			AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
			INNER JOIN ComprasProductosDetalleEntrega CPDE
			ON CPD.NumeroAgencia = CPDE.NumeroAgencia
			AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto
			AND CPD.CodigoProducto = CPDE.CodigoProducto
			WHERE CP.NumeroAgencia = @NumeroAgencia
			AND CPDE.CodigoProducto = @CodigoProducto
			AND CP.CodigoEstadoCompra IN ('F','X')
			AND CP.Fecha BETWEEN @FechaInicio AND @FechaFin
			GROUP BY CPDE.NumeroAgencia, CPDE.NumeroCompraProducto, CPDE.CodigoProducto
			UNION ALL
			SELECT SUM(TPDR.CantidadEnvioRecepcion * TPD.PrecioUnitarioTransferencia)
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalle TPD
			ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			AND TPD.CodigoProducto = TPDR.CodigoProducto
			WHERE TP.CodigoEstadoTransferencia IN ('F','X')
			AND TP.NumeroAgenciaRecepctora = @NumeroAgencia
			AND TPDR.CodigoProducto = @CodigoProducto
			AND TPDR.CodigoTipoEnvioRecepcion ='R'
			AND TP.FechaHoraTransferencia BETWEEN @FechaInicio AND @FechaFin
			GROUP BY TPDR.NumeroAgenciaEmisora, TPDR.NumeroTransferenciaProducto, TPDR.CodigoProducto
			UNION ALL
			SELECT VPDD.CantidadDevuelta * VPDD.PrecioUnitarioDevolucion
			FROM VentasProductosDevoluciones VPD
			INNER JOIN VentasProductosDevolucionesDetalle VPDD
			ON VPD.NumeroAgencia = VPDD.NumeroAgencia
			AND VPD.NumeroDevolucion = VPDD.NumeroDevolucion
			INNER JOIN MotivosReemDevo MRD
			ON VPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
			WHERE MRD.TipoTransaccion = 'V'
			AND VPDD.CodigoProducto = @CodigoProducto
			AND MRD.EstadoRetornoInventario IN ('A')
			AND VPD.NumeroAgencia = @NumeroAgencia
			AND VPD.CodigoEstadoDevolucion = 'F'
			AND VPD.FechaHoraSolicitudReemDevo BETWEEN @FechaInicio AND @FechaFin
			--EGRESOS			
			UNION ALL
			SELECT -SUM(VPDE.CantidadEntregada * VPD.PrecioUnitarioVenta)AS PrecioTotal
			FROM VentasProductos VP
			INNER JOIN VentasProductosDetalle VPD
			ON VP.NumeroAgencia = VPD.NumeroAgencia
			AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
			INNER JOIN VentasProductosDetalleEntrega VPDE
			ON VPD.NumeroAgencia = VPDE.NumeroAgencia
			AND VPD.NumeroVentaProducto = VPDE.NumeroVentaProducto
			AND VPD.CodigoProducto = VPDE.CodigoProducto
			WHERE VP.NumeroAgencia = @NumeroAgencia
			AND VPDE.CodigoProducto = @CodigoProducto
			AND VP.CodigoEstadoVenta IN ('F','X')
			AND VP.FechaHoraVenta BETWEEN @FechaInicio AND @FechaFin
			GROUP BY VPDE.NumeroAgencia, VPDE.NumeroVentaProducto, VPDE.CodigoProducto
			UNION ALL
			SELECT -SUM(TPDR.CantidadEnvioRecepcion * TPD.PrecioUnitarioTransferencia)
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalle TPD
			ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			AND TPD.CodigoProducto = TPDR.CodigoProducto
			WHERE TP.NumeroAgenciaEmisora = @NumeroAgencia
			AND TPDR.CodigoProducto = @CodigoProducto
			AND TPDR.CodigoTipoEnvioRecepcion = 'E'
			AND TP.CodigoEstadoTransferencia IN('F','X')
			AND TP.FechaHoraTransferencia BETWEEN @FechaInicio AND @FechaFin
			GROUP BY TPDR.NumeroAgenciaEmisora, TPDR.NumeroTransferenciaProducto, TPDR.CodigoProducto
			UNION ALL
			SELECT -CPDD.CantidadDevuelta * CPDD.PrecioUnitarioDevolucion
			FROM ComprasProductosDevoluciones CPD
			INNER JOIN ComprasProductosDevolucionesDetalle CPDD
			ON CPD.NumeroAgencia = CPDD.NumeroAgencia
			AND CPD.NumeroDevolucion = CPDD.NumeroDevolucion
			INNER JOIN MotivosReemDevo MRD
			ON CPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
			WHERE MRD.TipoTransaccion = 'C'
			AND CPDD.CodigoProducto = @CodigoProducto
			AND MRD.EstadoRetornoInventario IN ('B','R')
			AND CPD.NumeroAgencia = @NumeroAgencia
			AND CPD.CodigoEstadoDevolucion = 'F'
			AND CPD.FechaHoraSolicitudDevolucion BETWEEN @FechaInicio AND @FechaFin
		) TMT
	END
	RETURN @MontoTotalValorado
END
GO
