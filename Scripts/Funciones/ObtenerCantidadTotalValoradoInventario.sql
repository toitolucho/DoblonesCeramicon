USE Doblones20
GO

DROP FUNCTION ObtenerCantidadTotalValoradoInventario
GO


CREATE FUNCTION ObtenerCantidadTotalValoradoInventario(
	@NumeroAgencia	INT, 
	@CodigoProducto CHAR(15),
	@FechaInicio	DATETIME, 
	@FechaFin		DATETIME
)
RETURNS INT
WITH ENCRYPTION
AS
BEGIN
	DECLARE @MontoTotalValorado		INT
	
	IF(@FechaInicio IS NULL AND @FechaFin IS NULL)
	BEGIN
		
		SELECT @MontoTotalValorado = ISNULL(SUM(TMT.CantidadTotal),0)
		FROM
		(
			--INGRESOS
			SELECT CPDE.CantidadEntregada AS CantidadTotal
			FROM ComprasProductos CP
			INNER JOIN ComprasProductosDetalleEntrega CPDE
			ON CP.NumeroAgencia = CPDE.NumeroAgencia
			AND CP.NumeroCompraProducto = CPDE.NumeroAgencia
			WHERE CP.NumeroAgencia = @NumeroAgencia
			AND CPDE.CodigoProducto = @CodigoProducto
			AND CP.CodigoEstadoCompra IN ('F','X')
			UNION ALL
			SELECT TPDR.CantidadEnvioRecepcion
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TP.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			WHERE TP.CodigoEstadoTransferencia IN ('F','X')
			AND TP.NumeroAgenciaRecepctora = @NumeroAgencia
			AND TPDR.CodigoProducto = @CodigoProducto
			AND TPDR.CodigoTipoEnvioRecepcion ='R'
			UNION ALL
			SELECT VPDD.CantidadDevuelta
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
			SELECT -VPDE.CantidadEntregada AS CantidadTotal
			FROM VentasProductos VP
			INNER JOIN VentasProductosDetalleEntrega VPDE
			ON VP.NumeroAgencia = VPDE.NumeroAgencia
			AND VP.NumeroVentaProducto = VPDE.NumeroVentaProducto
			WHERE VP.NumeroAgencia = @NumeroAgencia
			AND VPDE.CodigoProducto = @CodigoProducto
			AND VP.CodigoEstadoVenta IN ('F','X')
			UNION ALL
			SELECT TPDR.CantidadEnvioRecepcion
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TP.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			WHERE TP.NumeroAgenciaEmisora = @NumeroAgencia
			AND TPDR.CodigoProducto = @CodigoProducto
			AND TPDR.CodigoTipoEnvioRecepcion = 'E'
			AND TP.CodigoEstadoTransferencia IN('F','X')
			UNION ALL
			SELECT CPDD.CantidadDevuelta
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
		SELECT @MontoTotalValorado = ISNULL(SUM(TMT.CantidadTotal),0)
		FROM
		(
			SELECT CPDE.CantidadEntregada AS CantidadTotal
			FROM ComprasProductos CP
			INNER JOIN ComprasProductosDetalleEntrega CPDE
			ON CP.NumeroAgencia = CPDE.NumeroAgencia
			AND CP.NumeroCompraProducto = CPDE.NumeroAgencia
			WHERE CP.NumeroAgencia = @NumeroAgencia
			AND CPDE.CodigoProducto = @CodigoProducto
			AND CP.CodigoEstadoCompra IN ('F','X')
			AND CP.Fecha BETWEEN @FechaInicio AND @FechaFin
			UNION ALL
			SELECT TPDR.CantidadEnvioRecepcion
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TP.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			WHERE TP.CodigoEstadoTransferencia IN ('F','X')
			AND TP.NumeroAgenciaRecepctora = @NumeroAgencia
			AND TPDR.CodigoProducto = @CodigoProducto
			AND TPDR.CodigoTipoEnvioRecepcion ='R'
			AND TP.FechaHoraTransferencia BETWEEN @FechaInicio AND @FechaFin
			UNION ALL
			SELECT VPDD.CantidadDevuelta
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
			SELECT -VPDE.CantidadEntregada AS CantidadTotal
			FROM VentasProductos VP
			INNER JOIN VentasProductosDetalleEntrega VPDE
			ON VP.NumeroAgencia = VPDE.NumeroAgencia
			AND VP.NumeroVentaProducto = VPDE.NumeroVentaProducto
			WHERE VP.NumeroAgencia = @NumeroAgencia
			AND VPDE.CodigoProducto = @CodigoProducto
			AND VP.CodigoEstadoVenta IN ('F','X')
			AND VP.FechaHoraVenta BETWEEN @FechaInicio AND @FechaFin
			UNION ALL
			SELECT TPDR.CantidadEnvioRecepcion
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TP.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			WHERE TP.NumeroAgenciaEmisora = @NumeroAgencia
			AND TPDR.CodigoProducto = @CodigoProducto
			AND TPDR.CodigoTipoEnvioRecepcion = 'E'
			AND TP.CodigoEstadoTransferencia IN('F','X')
			AND TP.FechaHoraTransferencia BETWEEN @FechaInicio AND @FechaFin
			UNION ALL
			SELECT CPDD.CantidadDevuelta
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
