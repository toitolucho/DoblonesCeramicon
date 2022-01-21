USE Doblones20
GO

DROP PROCEDURE ListarVentasProductosReportesPorCreditosFechasCliente
GO

CREATE PROCEDURE ListarVentasProductosReportesPorCreditosFechasCliente
	@NumeroAgencia		INT,
	@FechaHoraInicio	DATETIME,
	@FechaHoraFin		DATETIME,
	@OrdenacionPorPersona	BIT
AS
BEGIN
	SELECT  CASE WHEN VP.NumeroVentaProducto IS NULL THEN 'SIN FACTURA' ELSE 'CON FACTURA' END AS TipoFacturacion, DBO.ObtenerNombreCompleto(P.DIPersona) AS NombreCompletoPersona ,
			VP.FechaHoraVenta,  VPDE.CantidadEntregada, DBO.ObtenerNombreProducto(VPDE.CodigoProducto) AS NombreProducto,
			VPDE.PrecioUnitarioVenta, (VPDE.CantidadEntregada * VPDE.PrecioUnitarioVenta) AS PrecioTotal, DBO.ObtenerMontoDeudaPagadaCredito(NULL, 
			@NumeroAgencia, @FechaHoraInicio, @FechaHoraFin, C.DIDeudor) as MontoTotalPagado
	FROM VentasProductos VP
	INNER JOIN VListarVentasProductosDetalleEntrega VPDE
	ON VP.NumeroAgencia = VPDE.NumeroAgencia
	AND VP.NumeroVentaProducto = VPDE.NumeroVentaProducto
	INNER JOIN Creditos C
	ON VP.NumeroCredito  = C.NumeroCredito
	INNER JOIN Personas P
	ON C.DIDeudor = P.DIPersona
	WHERE VP.NumeroAgencia = @NumeroAgencia
	AND VP.NumeroCredito IS NOT NULL
	AND VP.FechaHoraVenta
	BETWEEN DBO.FormatearFechaInicioFin(@FechaHoraInicio,1) AND DBO.FormatearFechaInicioFin(@FechaHoraFin,0)
	ORDER BY 1
END
GO



--EXEC ListarVentasProductosReportesPorCreditosFechasCliente 1, '01/01/2000', '31/12/2012', 1