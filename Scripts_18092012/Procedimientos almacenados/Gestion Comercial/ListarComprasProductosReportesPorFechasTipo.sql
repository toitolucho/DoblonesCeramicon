USE Doblones20
GO

DROP PROCEDURE ListarComprasProductosReportesPorFechasTipo
GO

CREATE PROCEDURE ListarComprasProductosReportesPorFechasTipo
	@NumeroAgencia		INT,
	@FechaHoraInicio	DATETIME,
	@FechaHoraFin		DATETIME,
	@OrdenacionPorFact	BIT
AS
BEGIN
	
	SELECT TAPrincipal.NumeroAgencia, TAPrincipal.TipoFacturacion, TAPrincipal.CodigoProducto, 
			PT.NombreTipoProducto, P.NombreProducto,
			TAPrincipal.CantidadRecepcionadaContado, TAPrincipal.ImporteTotalContado,
			TAPrincipal.CantidadRecepcionadaCredito, TAPrincipal.ImporteTotalCredito,
			TAPrincipal.CantidadRecepcionadaContado + TAPrincipal.CantidadRecepcionadaCredito AS CantidadTotal,
			TAPrincipal.ImporteTotalContado + TAPrincipal.ImporteTotalCredito AS ImporteTotal
	FROM
	(	
		SELECT	TA1.NumeroAgencia, CASE WHEN TA1.CodigoEstadoFactura = 'F' THEN 'CON FACTURA' ELSE 'SIN FACTURA' END AS TipoFacturacion,
				TA1.CodigoProducto, TA1.CantidadRecepcionada AS CantidadRecepcionadaContado,
				TA1.PrecioTotal AS ImporteTotalContado, 
				CASE WHEN TA2.CantidadRecepcionada IS NULL THEN 0 ELSE TA2.CantidadRecepcionada END AS CantidadRecepcionadaCredito,
				CASE WHEN TA2.PrecioTotal IS NULL THEN 0 ELSE TA2.PrecioTotal END AS ImporteTotalCredito
		FROM	
		(
			SELECT CP.NumeroAgencia, CP.CodigoEstadoFactura, CPDE.CodigoProducto, CPD.PrecioUnitarioCompra * SUM(CPDE.CantidadEntregada) AS PrecioTotal, SUM(CPDE.CantidadEntregada) AS CantidadRecepcionada
			FROM ComprasProductos CP
			INNER JOIN ComprasProductosDetalle CPD
			ON CP.NumeroAgencia = CPD.NumeroAgencia
			AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
			INNER JOIN ComprasProductosDetalleEntrega CPDE
			ON CPD.NumeroAgencia = CPDE.NumeroAgencia
			AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto
			AND CPD.CodigoProducto = CPDE.CodigoProducto
			WHERE CP.CodigoTipoCompra = 'E'
			AND CP.NumeroAgencia = @NumeroAgencia
			AND CP.Fecha
			BETWEEN DBO.FormatearFechaInicioFin(@FechaHoraInicio,1) AND DBO.FormatearFechaInicioFin(@FechaHoraFin,0)
			GROUP BY CP.NumeroAgencia, CP.CodigoEstadoFactura, CPDE.CodigoProducto, CPD.PrecioUnitarioCompra
		) TA1
		LEFT JOIN
		(
			SELECT CP.NumeroAgencia, CP.CodigoEstadoFactura, CPDE.CodigoProducto, CPD.PrecioUnitarioCompra * SUM(CPDE.CantidadEntregada) AS PrecioTotal, SUM(CPDE.CantidadEntregada) AS CantidadRecepcionada
			FROM ComprasProductos CP
			INNER JOIN ComprasProductosDetalle CPD
			ON CP.NumeroAgencia = CPD.NumeroAgencia
			AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
			INNER JOIN ComprasProductosDetalleEntrega CPDE
			ON CPD.NumeroAgencia = CPDE.NumeroAgencia
			AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto
			AND CPD.CodigoProducto = CPDE.CodigoProducto
			WHERE CP.CodigoTipoCompra = 'R'
			AND CP.NumeroAgencia = @NumeroAgencia
			AND CP.Fecha
			BETWEEN DBO.FormatearFechaInicioFin(@FechaHoraInicio,1) AND DBO.FormatearFechaInicioFin(@FechaHoraFin,0)
			GROUP BY CP.NumeroAgencia, CP.CodigoEstadoFactura, CPDE.CodigoProducto, CPD.PrecioUnitarioCompra
		) TA2
		ON TA1.NumeroAgencia = TA2.NumeroAgencia
		AND TA1.CodigoEstadoFactura = TA2.CodigoEstadoFactura
		AND TA1.CodigoProducto = TA2.CodigoProducto
	)TAPrincipal
	INNER JOIN Productos P
	ON TAPrincipal.CodigoProducto = P.CodigoProducto
	INNER JOIN ProductosTipos PT
	ON PT.CodigoTipoProducto = P.CodigoTipoProducto
	ORDER BY CASE WHEN @OrdenacionPorFact = 1 THEN TipoFacturacion ELSE NombreTipoProducto END ASC,
	CASE WHEN @OrdenacionPorFact = 1 THEN NombreTipoProducto ELSE TipoFacturacion END ASC, 5	
END
GO


EXEC ListarComprasProductosReportesPorFechasTipo 1, '01/01/2000','31/12/2012', 0