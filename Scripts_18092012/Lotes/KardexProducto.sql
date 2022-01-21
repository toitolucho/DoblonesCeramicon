USE Doblones20
GO

--DECLARE @CodigoProducto CHAR(15), @FechaInicio DATETIME, @FechaFin DATETIME

----('I','P', 'F', 'A','T', 'C','E','D')), 
---- 'I'->Iniciada, 'P'->Pagada, 'F'->Finalizada, 'A'->Anulada, 
---- 'T'->Venta a Insituticiones, 'C'->Entrega de Productos en Confianza, 
---- 'D'->Pendiente (Venta Institucional), 'E'->En Espera(Venta Normal)
--SELECT *
--FROM VentasProductos VP
--INNER JOIN VentasProductosDetalleEntrega VPDE
--ON VP.NumeroAgencia = VPDE.NumeroAgencia
--AND VP.NumeroVentaProducto = VPDE.NumeroVentaProducto


DROP PROCEDURE ListarHistorialInventarioPorFecha
GO

CREATE PROCEDURE ListarHistorialInventarioPorFecha
	@FechaInicio	DATETIME, 
	@FechaFin		DATETIME, 
	@NumeroAgencia	INT
AS
BEGIN
	IF(@FechaFin IS NULL AND @FechaInicio IS NULL)
	BEGIN
		print 'fecha nulas'
		SELECT IP.CodigoProducto,
			dbo.ObtenerNombreProducto(IP.CodigoProducto) as NombreProducto,			
			IP.CantidadRequerida, 
			IP.StockMinimo, 
			IP.PrecioUnitarioCompra,
			ISNULL(TCC.CantidadAdquirida,0) AS CantidadComprada, 
			ISNULL(TVP.CantidadVendida, 0) AS CantidadVendida,
			ISNULL(TTPE.CantidadTransferidaEnvio,0) AS CantidadTransferenciaEnvio,
			ISNULL(TTPR.CantidadTransferidaRecepcion,0) AS CantidadTransferidaRecepcion,
			ISNULL(CPD.CantidadComprasDevolucion,0) AS CantidadComprasDevolucion,
			ISNULL(VPD.CantidadVentaDevolucion,0) AS CantidadVentaDevolucion,
			ISNULL(VPR.CantidadVentaReemplazo,0) AS CantidadVentaReemplazo,
			
			ISNULL(TCC.CantidadAdquirida,0) +
			ISNULL(VPD.CantidadVentaDevolucion,0) +
			ISNULL(TTPR.CantidadTransferidaRecepcion,0) AS CantidadIngresada,
			
			ISNULL(TVP.CantidadVendida, 0) +
			ISNULL(TTPE.CantidadTransferidaEnvio,0)	+		
			ISNULL(CPD.CantidadComprasDevolucion,0)+
			ISNULL(VPR.CantidadVentaReemplazo,0) AS CantidadEgresada,
						
			IP.CantidadExistencia-
			(ISNULL(TCC.CantidadAdquirida,0) +
			ISNULL(VPD.CantidadVentaDevolucion,0) +
			ISNULL(TTPR.CantidadTransferidaRecepcion,0))+
			(ISNULL(TVP.CantidadVendida, 0) +
			ISNULL(TTPE.CantidadTransferidaEnvio,0)	+		
			ISNULL(CPD.CantidadComprasDevolucion,0)+
			ISNULL(VPR.CantidadVentaReemplazo,0)) AS CantidadExistenciaAnterior,
			ip.CantidadExistencia AS CantidadExistenciaActual		
		FROM InventariosProductos IP
		LEFT JOIN
		(
			SELECT CPDE.CodigoProducto, ISNULL(SUM(CPDE.CantidadEntregada),0) AS CantidadAdquirida
			FROM ComprasProductos CP
			INNER JOIN ComprasProductosDetalleEntrega CPDE
			ON CP.NumeroAgencia = CPDE.NumeroAgencia
			AND CP.NumeroCompraProducto = CPDE.NumeroCompraProducto
			WHERE CP.NumeroAgencia = @NumeroAgencia
			AND CP.CodigoEstadoCompra IN ('F','X')
			GROUP BY CPDE.CodigoProducto
		) TCC
		ON TCC.CodigoProducto = IP.CodigoProducto
		LEFT JOIN
		(
			SELECT VPDE.CodigoProducto, ISNULL(SUM(VPDE.CantidadEntregada),0) AS CantidadVendida
			FROM VentasProductos VP
			INNER JOIN VentasProductosDetalleEntrega VPDE
			ON VP.NumeroAgencia = VPDE.NumeroAgencia
			AND VP.NumeroVentaProducto = VPDE.NumeroVentaProducto
			WHERE VP.NumeroAgencia = @NumeroAgencia
			AND VP.CodigoEstadoVenta IN ('F','X')
			GROUP BY VPDE.CodigoProducto
		) TVP
		ON TVP.CodigoProducto = IP.CodigoProducto
		LEFT JOIN(
			SELECT CodigoProducto, ISNULL(SUM(TPDR.CantidadEnvioRecepcion),0) AS CantidadTransferidaEnvio
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TP.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			WHERE TP.NumeroAgenciaEmisora = @NumeroAgencia
			AND TPDR.CodigoTipoEnvioRecepcion = 'E'
			AND TP.CodigoEstadoTransferencia IN('F','X')
			GROUP BY CodigoProducto
		) TTPE
		ON TTPE.CodigoProducto = IP.CodigoProducto
		LEFT JOIN
		(
			SELECT CodigoProducto, ISNULL(SUM(TPDR.CantidadEnvioRecepcion),0) AS CantidadTransferidaRecepcion
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TP.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			--WHERE TP.NumeroAgenciaRecepctora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(TP.NumeroTransferenciaProducto, IP.NumeroAgencia)
			WHERE TP.NumeroAgenciaRecepctora = @NumeroAgencia
			AND TPDR.CodigoTipoEnvioRecepcion ='R'
			AND TP.CodigoEstadoTransferencia  IN('F','X')
			GROUP BY CodigoProducto
		) TTPR
		ON TTPR.CodigoProducto = IP.CodigoProducto
		LEFT JOIN 
		(
			SELECT CPDD.CodigoProducto, ISNULL(SUM(CPDD.CantidadDevuelta), 0) AS CantidadComprasDevolucion
			FROM ComprasProductosDevoluciones CPD
			INNER JOIN ComprasProductosDevolucionesDetalle CPDD
			ON CPD.NumeroAgencia = CPDD.NumeroAgencia
			AND CPD.NumeroDevolucion = CPDD.NumeroDevolucion
			INNER JOIN MotivosReemDevo MRD
			ON CPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
			WHERE MRD.TipoTransaccion = 'C'
			AND MRD.EstadoRetornoInventario IN ('B','R')
			AND CPD.NumeroAgencia = @NumeroAgencia
			AND CPD.CodigoEstadoDevolucion = 'F'
			GROUP BY CPDD.CodigoProducto
		) CPD
		ON CPD.CodigoProducto = IP.CodigoProducto
		LEFT JOIN
		(
			SELECT VPDD.CodigoProducto, ISNULL(SUM(VPDD.CantidadDevuelta), 0) AS CantidadVentaDevolucion
			FROM VentasProductosDevoluciones VPD
			INNER JOIN VentasProductosDevolucionesDetalle VPDD
			ON VPD.NumeroAgencia = VPDD.NumeroAgencia
			AND VPD.NumeroDevolucion = VPDD.NumeroDevolucion
			INNER JOIN MotivosReemDevo MRD
			ON VPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
			WHERE MRD.TipoTransaccion = 'V'
			AND MRD.EstadoRetornoInventario IN ('A')
			AND VPD.NumeroAgencia = @NumeroAgencia
			AND VPD.CodigoEstadoDevolucion = 'F'
			GROUP BY VPDD.CodigoProducto
		) VPD
		ON VPD.CodigoProducto = IP.CodigoProducto
		LEFT JOIN
		(
			SELECT VPRD.CodigoProducto, ISNULL(SUM(VPRD.CantidadDevuelta),0) AS CantidadVentaReemplazo
			FROM VentasProductosReemplazo VPR
			INNER JOIN VentasProductosReemplazoDetalle VPRD
			ON VPR.NumeroAgencia = VPRD.NumeroAgencia
			AND VPR.NumeroReemplazo = VPRD.NumeroReemplazo
			WHERE VPR.NumeroAgencia = @NumeroAgencia
			AND VPR.CodigoEstadoReemplazo = 'F'
			GROUP BY VPRD.CodigoProducto
		)VPR
		ON VPR.CodigoProducto = IP.CodigoProducto
	END
	ELSE
	BEGIN
		SELECT IP.CodigoProducto,
			dbo.ObtenerNombreProducto(IP.CodigoProducto) as NombreProducto,			
			IP.CantidadRequerida, 
			IP.StockMinimo, 
			IP.PrecioUnitarioCompra, 
			ISNULL(TCC.CantidadAdquirida,0) AS CantidadComprada, 
			ISNULL(TVP.CantidadVendida, 0) AS CantidadVendida,
			ISNULL(TTPE.CantidadTransferidaEnvio,0) AS CantidadTransferenciaEnvio,
			ISNULL(TTPR.CantidadTransferidaRecepcion,0) AS CantidadTransferidaRecepcion,
			ISNULL(CPD.CantidadComprasDevolucion,0) AS CantidadComprasDevolucion,
			ISNULL(VPD.CantidadVentaDevolucion,0) AS CantidadVentaDevolucion,
			ISNULL(VPR.CantidadVentaReemplazo,0) AS CantidadVentaReemplazo,
			
			ISNULL(TCC.CantidadAdquirida,0) +
			ISNULL(VPD.CantidadVentaDevolucion,0) +
			ISNULL(TTPR.CantidadTransferidaRecepcion,0) AS CantidadIngresada,
			
			ISNULL(TVP.CantidadVendida, 0) +
			ISNULL(TTPE.CantidadTransferidaEnvio,0)	+		
			ISNULL(CPD.CantidadComprasDevolucion,0)+
			ISNULL(VPR.CantidadVentaReemplazo,0) AS CantidadEgresada,
						
			IP.CantidadExistencia-
			(ISNULL(TCC.CantidadAdquirida,0) +
			ISNULL(VPD.CantidadVentaDevolucion,0) +
			ISNULL(TTPR.CantidadTransferidaRecepcion,0))+
			(ISNULL(TVP.CantidadVendida, 0) +
			ISNULL(TTPE.CantidadTransferidaEnvio,0)	+		
			ISNULL(CPD.CantidadComprasDevolucion,0)+
			ISNULL(VPR.CantidadVentaReemplazo,0)) AS CantidadExistenciaAnterior,
			IP.CantidadExistencia AS CantidadExistenciaActual
		FROM InventariosProductos IP
		LEFT JOIN
		(
			SELECT CPDE.CodigoProducto, ISNULL(SUM(CPDE.CantidadEntregada),0) AS CantidadAdquirida
			FROM ComprasProductos CP
			INNER JOIN ComprasProductosDetalleEntrega CPDE
			ON CP.NumeroAgencia = CPDE.NumeroAgencia
			AND CP.NumeroCompraProducto = CPDE.NumeroCompraProducto
			WHERE CP.NumeroAgencia = @NumeroAgencia
			AND CPDE.FechaHoraEntrega BETWEEN @FechaInicio AND @FechaFin
			AND CP.CodigoEstadoCompra IN('F','X')			 
			GROUP BY CPDE.CodigoProducto
		) TCC
		ON TCC.CodigoProducto = IP.CodigoProducto
		LEFT JOIN
		(
			SELECT VPDE.CodigoProducto, ISNULL(SUM(VPDE.CantidadEntregada),0) AS CantidadVendida
			FROM VentasProductos VP
			INNER JOIN VentasProductosDetalleEntrega VPDE
			ON VP.NumeroAgencia = VPDE.NumeroAgencia
			AND VP.NumeroVentaProducto = VPDE.NumeroVentaProducto
			WHERE VP.NumeroAgencia = @NumeroAgencia
			AND VPDE.FechaHoraEntrega  BETWEEN @FechaInicio AND @FechaFin
			AND VP.CodigoEstadoVenta IN('F','X')
			GROUP BY VPDE.CodigoProducto
		) TVP
		ON TVP.CodigoProducto = IP.CodigoProducto
		LEFT JOIN(
			SELECT CodigoProducto, ISNULL(SUM(TPDR.CantidadEnvioRecepcion),0) AS CantidadTransferidaEnvio
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TP.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			WHERE TP.NumeroAgenciaEmisora = @NumeroAgencia
			AND TPDR.FechaHoraEnvioRecepcion BETWEEN @FechaInicio AND @FechaFin
			AND TPDR.CodigoTipoEnvioRecepcion = 'E'
			AND TP.CodigoEstadoTransferencia IN('F','X')
			GROUP BY CodigoProducto
		) TTPE
		ON TTPE.CodigoProducto = IP.CodigoProducto
		LEFT JOIN
		(
			SELECT CodigoProducto, ISNULL(SUM(TPDR.CantidadEnvioRecepcion),0) AS CantidadTransferidaRecepcion
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TP.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			--WHERE TP.NumeroAgenciaRecepctora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(TP.NumeroTransferenciaProducto, IP.NumeroAgencia)
			WHERE TP.NumeroAgenciaRecepctora = @NumeroAgencia
			AND TPDR.FechaHoraEnvioRecepcion BETWEEN @FechaInicio AND @FechaFin
			AND TPDR.CodigoTipoEnvioRecepcion = 'R'
			AND TP.CodigoEstadoTransferencia IN('F','X')
			GROUP BY CodigoProducto
		) TTPR
		ON TTPR.CodigoProducto = IP.CodigoProducto
		LEFT JOIN 
		(
			SELECT CPDD.CodigoProducto, ISNULL(SUM(CPDD.CantidadDevuelta), 0) AS CantidadComprasDevolucion
			FROM ComprasProductosDevoluciones CPD
			INNER JOIN ComprasProductosDevolucionesDetalle CPDD
			ON CPD.NumeroAgencia = CPDD.NumeroAgencia
			AND CPD.NumeroDevolucion = CPDD.NumeroDevolucion
			INNER JOIN MotivosReemDevo MRD
			ON CPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
			WHERE MRD.TipoTransaccion = 'C'
			AND MRD.EstadoRetornoInventario IN ('B','R')
			AND CPD.NumeroAgencia = 1
			AND CPD.CodigoEstadoDevolucion = 'F'
			AND CPD.FechaHoraSolicitudDevolucion BETWEEN @FechaInicio AND @FechaFin
			GROUP BY CPDD.CodigoProducto
		) CPD
		ON CPD.CodigoProducto = IP.CodigoProducto
		LEFT JOIN
		(
			SELECT VPDD.CodigoProducto, ISNULL(SUM(VPDD.CantidadDevuelta), 0) AS CantidadVentaDevolucion
			FROM VentasProductosDevoluciones VPD
			INNER JOIN VentasProductosDevolucionesDetalle VPDD
			ON VPD.NumeroAgencia = VPDD.NumeroAgencia
			AND VPD.NumeroDevolucion = VPDD.NumeroDevolucion
			INNER JOIN MotivosReemDevo MRD
			ON VPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
			WHERE MRD.TipoTransaccion = 'V'
			AND MRD.EstadoRetornoInventario IN ('A')
			AND VPD.NumeroAgencia = 1
			AND VPD.CodigoEstadoDevolucion = 'F'
			AND VPD.FechaHoraSolicitudReemDevo BETWEEN @FechaInicio AND @FechaFin
			GROUP BY VPDD.CodigoProducto
		) VPD
		ON VPD.CodigoProducto = IP.CodigoProducto
		LEFT JOIN
		(
			SELECT VPRD.CodigoProducto, ISNULL(SUM(VPRD.CantidadDevuelta),0) AS CantidadVentaReemplazo
			FROM VentasProductosReemplazo VPR
			INNER JOIN VentasProductosReemplazoDetalle VPRD
			ON VPR.NumeroAgencia = VPRD.NumeroAgencia
			AND VPR.NumeroReemplazo = VPRD.NumeroReemplazo
			WHERE VPR.NumeroAgencia = @NumeroAgencia
			AND VPR.CodigoEstadoReemplazo = 'F'
			AND VPR.FechaHoraSolicitudReemplazo BETWEEN @FechaInicio AND @FechaFin
			GROUP BY VPRD.CodigoProducto
		)VPR
		ON VPR.CodigoProducto = IP.CodigoProducto
		print 'fecha NO nulas'
	END
END
GO

--EXEC ListarHistorialInventarioPorFecha '01/01/2011', '31/12/2011', 1
--EXEC ListarHistorialInventarioPorFecha NULL, NULL, 1