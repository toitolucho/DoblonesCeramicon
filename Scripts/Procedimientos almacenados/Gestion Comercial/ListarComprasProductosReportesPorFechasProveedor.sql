USE Doblones20
GO

DROP PROCEDURE ListarComprasProductosReportesPorFechasProveedor
GO

CREATE PROCEDURE ListarComprasProductosReportesPorFechasProveedor
	@NumeroAgencia		INT,
	@FechaHoraInicio	DATETIME,
	@FechaHoraFin		DATETIME,
	@OrdenacionPorProve	BIT
AS
BEGIN
	
	SELECT TAPrincipal.NumeroAgencia, TAPrincipal.NombreRazonSocial, TAPrincipal.TipoFacturacion, PT.NombreTipoProducto, 
			TAPrincipal.CodigoProducto, P.NombreProducto,
			TAPrincipal.CantidadRecepcionadaContado, TAPrincipal.ImporteTotalContado,
			TAPrincipal.CantidadRecepcionadaCredito, TAPrincipal.ImporteTotalCredito,
			TAPrincipal.CantidadRecepcionadaContado + TAPrincipal.CantidadRecepcionadaCredito AS CantidadTotal,
			TAPrincipal.ImporteTotalContado + TAPrincipal.ImporteTotalCredito AS ImporteTotal
	FROM
	(	
		SELECT	TA1.NumeroAgencia, P.NombreRazonSocial, CASE WHEN TA1.CodigoEstadoFactura = 'F' THEN 'CON FACTURA' ELSE 'SIN FACTURA' END AS TipoFacturacion,
				TA1.CodigoProducto, TA1.CantidadRecepcionada AS CantidadRecepcionadaContado,
				TA1.PrecioTotal AS ImporteTotalContado, 
				CASE WHEN TA2.CantidadRecepcionada IS NULL THEN 0 ELSE TA2.CantidadRecepcionada END AS CantidadRecepcionadaCredito,
				CASE WHEN TA2.PrecioTotal IS NULL THEN 0 ELSE TA2.PrecioTotal END AS ImporteTotalCredito
		FROM	
		(
			SELECT CP.NumeroAgencia, CP.CodigoProveedor, CP.CodigoEstadoFactura, CPDE.CodigoProducto, CPD.PrecioUnitarioCompra * SUM(CPDE.CantidadEntregada) AS PrecioTotal, SUM(CPDE.CantidadEntregada) AS CantidadRecepcionada
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
			GROUP BY CP.NumeroAgencia, CP.CodigoProveedor, CP.CodigoEstadoFactura, CPDE.CodigoProducto, CPD.PrecioUnitarioCompra
		) TA1
		LEFT JOIN
		(
			SELECT CP.NumeroAgencia, CP.CodigoProveedor, CP.CodigoEstadoFactura, CPDE.CodigoProducto, CPD.PrecioUnitarioCompra * SUM(CPDE.CantidadEntregada) AS PrecioTotal, SUM(CPDE.CantidadEntregada) AS CantidadRecepcionada
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
			GROUP BY CP.NumeroAgencia, CP.CodigoProveedor, CP.CodigoEstadoFactura, CPDE.CodigoProducto, CPD.PrecioUnitarioCompra
		) TA2
		ON TA1.NumeroAgencia = TA2.NumeroAgencia
		AND TA1.CodigoEstadoFactura = TA2.CodigoEstadoFactura
		AND TA1.CodigoProducto = TA2.CodigoProducto
		AND TA1.CodigoProveedor = TA2.CodigoProveedor 
		INNER JOIN Proveedores P
		ON TA1.CodigoProveedor = P.CodigoProveedor
	)TAPrincipal
	INNER JOIN Productos P
	ON TAPrincipal.CodigoProducto = P.CodigoProducto
	INNER JOIN ProductosTipos PT
	ON PT.CodigoTipoProducto = P.CodigoTipoProducto
	ORDER BY CASE WHEN @OrdenacionPorProve = 1 THEN NombreRazonSocial ELSE NombreTipoProducto END ASC,
	CASE WHEN @OrdenacionPorProve = 1 THEN NombreTipoProducto ELSE NombreRazonSocial END ASC, 5	
END
GO


--EXEC ListarComprasProductosReportesPorFechasProveedor 1, '01/01/2000','31/12/2012', 1