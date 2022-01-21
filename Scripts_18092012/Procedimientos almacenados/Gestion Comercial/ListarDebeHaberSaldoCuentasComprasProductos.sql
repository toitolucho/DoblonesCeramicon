USE Doblones20
GO

DROP PROCEDURE ListarDebeHaberSaldoCuentasComprasProductos
GO

CREATE PROCEDURE ListarDebeHaberSaldoCuentasComprasProductos
	@NumeroAgencia		INT,
	@NumeroProveedor	INT
AS
BEGIN
	SELECT TAPrincipal.NumeroTransaccion, 
	TAPrincipal.FechaHoraRegistroTransaccion, TAPrincipal.Concepto,
	TAPrincipal.NumeroFactura, TAPrincipal.NombreDestinatario,
	TAPrincipal.Debe, TAPrincipal.Haber, TAPrincipal.NumeroCompraProducto,
	SUM(TASecundaria.Debe) AS DebeAcumulado,
	SUM(TASecundaria.Haber) AS HaberAcumulado
	FROM(
		SELECT ROW_NUMBER() OVER(ORDER BY FechaHoraRegistroTransaccion) AS NumeroTransaccion, *
		FROM
		(
			SELECT	CPP.FechaHoraRegistro AS FechaHoraRegistroTransaccion, CT.Concepto, CP.NumeroFactura, 
					DBO.ObtenerNombreCompleto(CP.DIPersonaDestinatario) AS NombreDestinatario,
					CPP.Monto AS Debe, 0 AS Haber, 'D' as TipoDebeHaber, CP.NumeroCompraProducto
			FROM ComprasProductos CP
			INNER JOIN CuentasPorPagar CPP
			ON CP.NumeroAgencia  =CPP.NumeroAgencia
			AND CP.NumeroCuentaPorPagar = CPP.NumeroCuentaPorPagar
			INNER JOIN Conceptos CT
			ON CPP.NumeroConcepto = CT.NumeroConcepto
			UNION ALL
			SELECT CPPD.FechaHoraPago, 'Deposito', '', A.NombreAgencia,
					0, CPPD.MontoTotalPago, 'H', CP.NumeroCompraProducto
			FROM ComprasProductosPagosDetalle CPPD
			INNER JOIN ComprasProductos CP
			ON CP.NumeroAgencia = CPPD.NumeroAgencia
			AND CP.NumeroCompraProducto = CPPD.NumeroCompraProducto
			INNER JOIN Agencias A
			ON CP.NumeroAgencia = A.NumeroAgencia	
		) TA1
	) TAPrincipal
	JOIN
	(
		SELECT ROW_NUMBER() OVER(ORDER BY FechaHoraRegistroTransaccion) AS NumeroTransaccion, *
		FROM
		(
			SELECT	CPP.FechaHoraRegistro AS FechaHoraRegistroTransaccion, CT.Concepto, CP.NumeroFactura, 
					DBO.ObtenerNombreCompleto(CP.DIPersonaDestinatario) AS NombreDestinatario,
					CPP.Monto AS Debe, 0 AS Haber, 'D' as TipoDebeHaber, CP.NumeroCompraProducto
			FROM ComprasProductos CP
			INNER JOIN CuentasPorPagar CPP
			ON CP.NumeroAgencia  =CPP.NumeroAgencia
			AND CP.NumeroCuentaPorPagar = CPP.NumeroCuentaPorPagar
			INNER JOIN Conceptos CT
			ON CPP.NumeroConcepto = CT.NumeroConcepto
			UNION ALL
			SELECT CPPD.FechaHoraPago, 'Deposito', '', A.NombreAgencia,
					0, CPPD.MontoTotalPago, 'H', CP.NumeroCompraProducto
			FROM ComprasProductosPagosDetalle CPPD
			INNER JOIN ComprasProductos CP
			ON CP.NumeroAgencia = CPPD.NumeroAgencia
			AND CP.NumeroCompraProducto = CPPD.NumeroCompraProducto
			INNER JOIN Agencias A
			ON CP.NumeroAgencia = A.NumeroAgencia	
		) TA1
	) TASecundaria
	on TAPrincipal.NumeroTransaccion >= TASecundaria.NumeroTransaccion
	GROUP BY TAPrincipal.NumeroTransaccion, 
	TAPrincipal.FechaHoraRegistroTransaccion, TAPrincipal.Concepto,
	TAPrincipal.NumeroFactura, TAPrincipal.NombreDestinatario,
	TAPrincipal.Debe, TAPrincipal.Haber, TAPrincipal.NumeroCompraProducto
END
