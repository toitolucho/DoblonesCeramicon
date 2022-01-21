USE Doblones20
GO

DROP PROCEDURE ListarVentasProductosReportesPorFechasTipo
GO

CREATE PROCEDURE ListarVentasProductosReportesPorFechasTipo
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
			SELECT CP.NumeroAgencia, CP.CodigoCliente, 'F' AS CodigoEstadoFactura, CPDE.CodigoProducto, CPDE.PrecioUnitarioVenta * CPDE.CantidadEntregada AS PrecioTotal, 
			CPDE.CantidadEntregada AS CantidadRecepcionada
			FROM VentasProductos CP			
			INNER JOIN VListarVentasProductosDetalleEntrega CPDE
			ON CP.NumeroAgencia = CPDE.NumeroAgencia
			AND CP.NumeroVentaProducto = CPDE.NumeroVentaProducto			
			WHERE CP.NumeroFactura IS NOT NULL
			AND CP.NumeroAgencia = @NumeroAgencia
			AND CP.FechaHoraVenta
			BETWEEN DBO.FormatearFechaInicioFin(@FechaHoraInicio,1) AND DBO.FormatearFechaInicioFin(@FechaHoraFin,0)
			AND CP.FechaHoraVenta
			BETWEEN DBO.FormatearFechaInicioFin(@FechaHoraInicio,1) AND DBO.FormatearFechaInicioFin(@FechaHoraFin,0)
			
		) TA1
		LEFT JOIN
		(
			SELECT CP.NumeroAgencia, CP.CodigoCliente, 'R' AS CodigoEstadoFactura, CPDE.CodigoProducto, CPDE.PrecioUnitarioVenta * CPDE.CantidadEntregada AS PrecioTotal, 
			CPDE.CantidadEntregada AS CantidadRecepcionada
			FROM VentasProductos CP			
			INNER JOIN VListarVentasProductosDetalleEntrega CPDE
			ON CP.NumeroAgencia = CPDE.NumeroAgencia
			AND CP.NumeroVentaProducto = CPDE.NumeroVentaProducto			
			WHERE CP.NumeroFactura IS NULL
			AND CP.NumeroAgencia = @NumeroAgencia
			AND CP.FechaHoraVenta
			BETWEEN DBO.FormatearFechaInicioFin(@FechaHoraInicio,1) AND DBO.FormatearFechaInicioFin(@FechaHoraFin,0)
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


--EXEC ListarVentasProductosReportesPorFechasTipo 1, '01/01/2000','31/12/2012', 0


--select * from VentasProductos