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


DROP PROCEDURE ListarKardexValorado
GO

CREATE PROCEDURE ListarKardexValorado
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
			ip.CantidadExistencia AS CantidadExistenciaActual,
			
			--
			
			ISNULL(TCC.MontoTotalAdquirido,0) AS MontoTotalComprada, 
			ISNULL(TVP.MontoTotalVendido, 0) AS MontoTotalVendido,
			ISNULL(TTPE.MontoTotalTransferidaEnvio,0) AS MontoTotalTransferenciaEnvio,
			ISNULL(TTPR.MontoTotalTransferidaRecepcion,0) AS MontoTotalTransferidaRecepcion,
			ISNULL(CPD.MontoTotalComprasDevolucion,0) AS MontoTotalComprasDevolucion,
			ISNULL(VPD.MontoTotalVentaDevolucion,0) AS MontoTotalVentaDevolucion,
			ISNULL(VPR.MontoTotalVentaReemplazo,0) AS MontoTotalVentaReemplazo,
			
			ISNULL(TCC.MontoTotalAdquirido,0) +
			ISNULL(VPD.MontoTotalVentaDevolucion,0) +
			ISNULL(TTPR.MontoTotalTransferidaRecepcion,0) AS MontoTotalIngresado,
			
			ISNULL(TVP.MontoTotalVendido, 0) +
			ISNULL(TTPE.MontoTotalTransferidaEnvio,0)	+		
			ISNULL(CPD.MontoTotalComprasDevolucion,0)+
			ISNULL(VPR.MontoTotalVentaReemplazo,0) AS MontoTotalEgresado,
						
			(IP.CantidadExistencia * IP.PrecioUnitarioCompra ) -
			(ISNULL(TCC.MontoTotalAdquirido,0) +
			ISNULL(VPD.MontoTotalVentaDevolucion,0) +
			ISNULL(TTPR.MontoTotalTransferidaRecepcion,0))+
			(ISNULL(TVP.MontoTotalVendido, 0) +
			ISNULL(TTPE.MontoTotalTransferidaEnvio,0)	+		
			ISNULL(CPD.MontoTotalComprasDevolucion,0)+
			ISNULL(VPR.MontoTotalVentaReemplazo,0)) AS MontoTotalAnterior,
			IP.CantidadExistencia * IP.PrecioUnitarioCompra AS MontoTotalActual
			
			
		FROM InventariosProductos IP
		LEFT JOIN
		(
			SELECT CPDE.CodigoProducto, ISNULL(SUM(CPDE.CantidadEntregada),0) AS CantidadAdquirida, 
					ISNULL(SUM(CPDE.CantidadEntregada * CPD.PrecioUnitarioCompra),0) AS MontoTotalAdquirido
			FROM ComprasProductos CP
			INNER JOIN ComprasProductosDetalle CPD
			ON CP.NumeroAgencia = CPD.NumeroAgencia
			AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
			INNER JOIN ComprasProductosDetalleEntrega CPDE
			ON CPD.NumeroAgencia = CPDE.NumeroAgencia
			AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto
			AND CPD.CodigoProducto = CPDE.CodigoProducto
			WHERE CP.NumeroAgencia = @NumeroAgencia
			AND CP.CodigoEstadoCompra IN ('F','X')
			GROUP BY CPDE.CodigoProducto
		) TCC
		ON TCC.CodigoProducto = IP.CodigoProducto
		LEFT JOIN
		(
			SELECT	VPDE.CodigoProducto, ISNULL(SUM(VPDE.CantidadEntregada),0) AS CantidadVendida,
					ISNULL(SUM(VPDE.CantidadEntregada * VPD.PrecioUnitarioVenta),0) AS MontoTotalVendido
			FROM VentasProductos VP
			INNER JOIN VentasProductosDetalle VPD
			ON VP.NumeroAgencia = VPD.NumeroAgencia
			AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
			INNER JOIN VentasProductosDetalleEntrega VPDE
			ON VPD.NumeroAgencia = VPDE.NumeroAgencia
			AND VPD.NumeroVentaProducto = VPDE.NumeroVentaProducto
			AND VPD.CodigoProducto = VPDE.CodigoProducto
			WHERE VP.NumeroAgencia = @NumeroAgencia
			AND VP.CodigoEstadoVenta IN ('F','X')
			GROUP BY VPDE.CodigoProducto
		) TVP
		ON TVP.CodigoProducto = IP.CodigoProducto
		LEFT JOIN(
			SELECT	TPDR.CodigoProducto, ISNULL(SUM(TPDR.CantidadEnvioRecepcion),0) AS CantidadTransferidaEnvio,
					ISNULL(SUM(TPDR.CantidadEnvioRecepcion * TPD.PrecioUnitarioTransferencia),0) AS MontoTotalTransferidaEnvio
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalle TPD
			ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			AND TPD.CodigoProducto = TPDR.CodigoProducto
			WHERE TP.NumeroAgenciaEmisora = @NumeroAgencia
			AND TPDR.CodigoTipoEnvioRecepcion = 'E'
			AND TP.CodigoEstadoTransferencia IN('F','X')
			GROUP BY TPDR.CodigoProducto
		) TTPE
		ON TTPE.CodigoProducto = IP.CodigoProducto
		LEFT JOIN
		(
			SELECT	TPDR.CodigoProducto, ISNULL(SUM(TPDR.CantidadEnvioRecepcion),0) AS CantidadTransferidaRecepcion,
					ISNULL(SUM(TPDR.CantidadEnvioRecepcion * TPD.PrecioUnitarioTransferencia),0) AS MontoTotalTransferidaRecepcion
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalle TPD
			ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			AND TPD.CodigoProducto = TPDR.CodigoProducto
			--WHERE TP.NumeroAgenciaRecepctora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(TP.NumeroTransferenciaProducto, IP.NumeroAgencia)
			WHERE TP.NumeroAgenciaRecepctora = @NumeroAgencia
			AND TPDR.CodigoTipoEnvioRecepcion ='R'
			AND TP.CodigoEstadoTransferencia  IN('F','X')
			GROUP BY TPDR.CodigoProducto
		) TTPR
		ON TTPR.CodigoProducto = IP.CodigoProducto
		LEFT JOIN 
		(
			SELECT	CPDD.CodigoProducto, ISNULL(SUM(CPDD.CantidadDevuelta), 0) AS CantidadComprasDevolucion,
					ISNULL(SUM(CPDD.CantidadDevuelta * CPDD.PrecioUnitarioDevolucion),0) AS MontoTotalComprasDevolucion
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
			SELECT VPDD.CodigoProducto, ISNULL(SUM(VPDD.CantidadDevuelta), 0) AS CantidadVentaDevolucion,
					ISNULL(SUM(VPDD.CantidadDevuelta * VPDD.PrecioUnitarioDevolucion),0) AS MontoTotalVentaDevolucion
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
			SELECT	VPRD.CodigoProducto, ISNULL(SUM(VPRD.CantidadDevuelta),0) AS CantidadVentaReemplazo,
					ISNULL(SUM(VPRD.CantidadDevuelta * VPRD.PrecioUnitarioReemplazo),0) AS MontoTotalVentaReemplazo
			FROM VentasProductosReemplazo VPR
			INNER JOIN VentasProductosReemplazoDetalle VPRD
			ON VPR.NumeroAgencia = VPRD.NumeroAgencia
			AND VPR.NumeroReemplazo = VPRD.NumeroReemplazo
			WHERE VPR.NumeroAgencia = @NumeroAgencia
			AND VPR.CodigoEstadoReemplazo = 'F'
			GROUP BY VPRD.CodigoProducto
		)VPR
		ON VPR.CodigoProducto = IP.CodigoProducto
		--where ip.CodigoProducto = '003-ACE-000001 '
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
			IP.CantidadExistencia AS CantidadExistenciaActual,
			
			--
			
			ISNULL(TCC.MontoTotalAdquirido,0) AS MontoTotalComprada, 
			ISNULL(TVP.MontoTotalVendido, 0) AS MontoTotalVendido,
			ISNULL(TTPE.MontoTotalTransferidaEnvio,0) AS MontoTotalTransferenciaEnvio,
			ISNULL(TTPR.MontoTotalTransferidaRecepcion,0) AS MontoTotalTransferidaRecepcion,
			ISNULL(CPD.MontoTotalComprasDevolucion,0) AS MontoTotalComprasDevolucion,
			ISNULL(VPD.MontoTotalVentaDevolucion,0) AS MontoTotalVentaDevolucion,
			ISNULL(VPR.MontoTotalVentaReemplazo,0) AS MontoTotalVentaReemplazo,
			
			ISNULL(TCC.MontoTotalAdquirido,0) +
			ISNULL(VPD.MontoTotalVentaDevolucion,0) +
			ISNULL(TTPR.MontoTotalTransferidaRecepcion,0) AS MontoTotalIngresado,
			
			ISNULL(TVP.MontoTotalVendido, 0) +
			ISNULL(TTPE.MontoTotalTransferidaEnvio,0)	+		
			ISNULL(CPD.MontoTotalComprasDevolucion,0)+
			ISNULL(VPR.MontoTotalVentaReemplazo,0) AS MontoTotalEgresado,
						
			(IP.CantidadExistencia * IP.PrecioUnitarioCompra ) -
			(ISNULL(TCC.MontoTotalAdquirido,0) +
			ISNULL(VPD.MontoTotalVentaDevolucion,0) +
			ISNULL(TTPR.MontoTotalTransferidaRecepcion,0))+
			(ISNULL(TVP.MontoTotalVendido, 0) +
			ISNULL(TTPE.MontoTotalTransferidaEnvio,0)	+		
			ISNULL(CPD.MontoTotalComprasDevolucion,0)+
			ISNULL(VPR.MontoTotalVentaReemplazo,0)) AS MontoTotalAnterior,
			IP.CantidadExistencia * IP.PrecioUnitarioCompra AS MontoTotalActual
			
		FROM InventariosProductos IP
		LEFT JOIN
		(
			SELECT CPDE.CodigoProducto, ISNULL(SUM(CPDE.CantidadEntregada),0) AS CantidadAdquirida, 
					ISNULL(SUM(CPDE.CantidadEntregada * CPD.PrecioUnitarioCompra),0) AS MontoTotalAdquirido
			FROM ComprasProductos CP
			INNER JOIN ComprasProductosDetalle CPD
			ON CP.NumeroAgencia = CPD.NumeroAgencia
			AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
			INNER JOIN ComprasProductosDetalleEntrega CPDE
			ON CPD.NumeroAgencia = CPDE.NumeroAgencia
			AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto
			AND CPD.CodigoProducto = CPDE.CodigoProducto
			WHERE CP.NumeroAgencia = @NumeroAgencia
			AND CP.CodigoEstadoCompra IN ('F','X')
			AND CPDE.FechaHoraEntrega BETWEEN @FechaInicio AND @FechaFin
			GROUP BY CPDE.CodigoProducto
		) TCC
		ON TCC.CodigoProducto = IP.CodigoProducto
		LEFT JOIN
		(
			SELECT	VPDE.CodigoProducto, ISNULL(SUM(VPDE.CantidadEntregada),0) AS CantidadVendida,
					ISNULL(SUM(VPDE.CantidadEntregada * VPD.PrecioUnitarioVenta),0) AS MontoTotalVendido
			FROM VentasProductos VP
			INNER JOIN VentasProductosDetalle VPD
			ON VP.NumeroAgencia = VPD.NumeroAgencia
			AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
			INNER JOIN VentasProductosDetalleEntrega VPDE
			ON VPD.NumeroAgencia = VPDE.NumeroAgencia
			AND VPD.NumeroVentaProducto = VPDE.NumeroVentaProducto
			AND VPD.CodigoProducto = VPDE.CodigoProducto
			WHERE VP.NumeroAgencia = @NumeroAgencia
			AND VP.CodigoEstadoVenta IN ('F','X')
			AND VPDE.FechaHoraEntrega BETWEEN @FechaInicio AND @FechaFin
			GROUP BY VPDE.CodigoProducto
		) TVP
		ON TVP.CodigoProducto = IP.CodigoProducto
		LEFT JOIN(
			SELECT	TPDR.CodigoProducto, ISNULL(SUM(TPDR.CantidadEnvioRecepcion),0) AS CantidadTransferidaEnvio,
					ISNULL(SUM(TPDR.CantidadEnvioRecepcion * TPD.PrecioUnitarioTransferencia),0) AS MontoTotalTransferidaEnvio
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalle TPD
			ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			AND TPD.CodigoProducto = TPDR.CodigoProducto
			WHERE TP.NumeroAgenciaEmisora = @NumeroAgencia
			AND TPDR.CodigoTipoEnvioRecepcion = 'E'
			AND TP.CodigoEstadoTransferencia IN('F','X')
			AND TPDR.FechaHoraEnvioRecepcion  BETWEEN @FechaInicio AND @FechaFin
			GROUP BY TPDR.CodigoProducto
		) TTPE
		ON TTPE.CodigoProducto = IP.CodigoProducto
		LEFT JOIN
		(
			SELECT	TPDR.CodigoProducto, ISNULL(SUM(TPDR.CantidadEnvioRecepcion),0) AS CantidadTransferidaRecepcion,
					ISNULL(SUM(TPDR.CantidadEnvioRecepcion * TPD.PrecioUnitarioTransferencia),0) AS MontoTotalTransferidaRecepcion
			FROM TransferenciasProductos TP
			INNER JOIN TransferenciasProductosDetalle TPD
			ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora
			AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
			INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
			ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto
			AND TPD.CodigoProducto = TPDR.CodigoProducto
			--WHERE TP.NumeroAgenciaRecepctora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(TP.NumeroTransferenciaProducto, IP.NumeroAgencia)
			WHERE TP.NumeroAgenciaRecepctora = @NumeroAgencia
			AND TPDR.CodigoTipoEnvioRecepcion ='R'
			AND TP.CodigoEstadoTransferencia  IN('F','X')
			AND TPDR.FechaHoraEnvioRecepcion  BETWEEN @FechaInicio AND @FechaFin
			GROUP BY TPDR.CodigoProducto
		) TTPR
		ON TTPR.CodigoProducto = IP.CodigoProducto
		LEFT JOIN 
		(
			SELECT	CPDD.CodigoProducto, ISNULL(SUM(CPDD.CantidadDevuelta), 0) AS CantidadComprasDevolucion,
					ISNULL(SUM(CPDD.CantidadDevuelta * CPDD.PrecioUnitarioDevolucion),0) AS MontoTotalComprasDevolucion
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
			AND CPD.FechaHoraSolicitudDevolucion  BETWEEN @FechaInicio AND @FechaFin
			GROUP BY CPDD.CodigoProducto
		) CPD
		ON CPD.CodigoProducto = IP.CodigoProducto
		LEFT JOIN
		(
			SELECT VPDD.CodigoProducto, ISNULL(SUM(VPDD.CantidadDevuelta), 0) AS CantidadVentaDevolucion,
					ISNULL(SUM(VPDD.CantidadDevuelta * VPDD.PrecioUnitarioDevolucion),0) AS MontoTotalVentaDevolucion
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
			AND VPD.FechaHoraSolicitudReemDevo  BETWEEN @FechaInicio AND @FechaFin
			GROUP BY VPDD.CodigoProducto
		) VPD
		ON VPD.CodigoProducto = IP.CodigoProducto
		LEFT JOIN
		(
			SELECT	VPRD.CodigoProducto, ISNULL(SUM(VPRD.CantidadDevuelta),0) AS CantidadVentaReemplazo,
					ISNULL(SUM(VPRD.CantidadDevuelta * VPRD.PrecioUnitarioReemplazo),0) AS MontoTotalVentaReemplazo
			FROM VentasProductosReemplazo VPR
			INNER JOIN VentasProductosReemplazoDetalle VPRD
			ON VPR.NumeroAgencia = VPRD.NumeroAgencia
			AND VPR.NumeroReemplazo = VPRD.NumeroReemplazo
			WHERE VPR.NumeroAgencia = @NumeroAgencia
			AND VPR.CodigoEstadoReemplazo = 'F'
			AND VPR.FechaHoraSolicitudReemplazo  BETWEEN @FechaInicio AND @FechaFin
			GROUP BY VPRD.CodigoProducto
		)VPR
		ON VPR.CodigoProducto = IP.CodigoProducto
		print 'fecha NO nulas'
	END
END
GO

--EXEC ListarKardexValorado '01/01/2011', '31/12/2011', 1
--EXEC ListarKardexValorado NULL, NULL, 1