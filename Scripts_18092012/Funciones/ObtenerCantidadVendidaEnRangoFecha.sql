DROP FUNCTION ObtenerCantidadVendidaEnRangoFechaPorProducto 
GO

CREATE FUNCTION ObtenerCantidadVendidaEnRangoFechaPorProducto (@CodigoProducto CHAR(15), @FechaInicio DATETIME, @FechaFin DATETIME)
RETURNS INT
AS
BEGIN	
	DECLARE @Cantidad INT = 0
	SELECT @Cantidad = SUM(CantidadEntregada) 
	FROM VentasProductos VP 
	INNER JOIN VentasProductosDetalle VPD 
	ON VP.NumeroAgencia = VPD.NumeroAgencia
	AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
	WHERE (VP.CodigoEstadoVenta = 'F' OR VP.CodigoEstadoVenta = 'P' OR VP.CodigoEstadoVenta = 'C' OR VP.CodigoEstadoVenta = 'D') AND VPD.CodigoProducto = @CodigoProducto	
	AND CAST(VP.FechaHoraVenta AS DATE)  BETWEEN CAST(@FechaInicio AS DATE) AND CAST(@FechaFin AS DATE)
	IF(@cantidad IS NULL)
		SET @Cantidad = 0
	RETURN @Cantidad
END
GO



DROP FUNCTION ObtenerCantidadCompradaEnRangoFechaPorProducto 
GO

CREATE FUNCTION ObtenerCantidadCompradaEnRangoFechaPorProducto (@CodigoProducto CHAR(15), @FechaInicio DATETIME, @FechaFin DATETIME)
RETURNS INT
AS
BEGIN	
	DECLARE @Cantidad INT = 0
	SELECT @Cantidad = SUM(CantidadCompra) 
	FROM ComprasProductos CP INNER JOIN ComprasProductosDetalle CPD on CP.NumeroAgencia = CPD.NumeroAgencia
	AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
	WHERE CP.CodigoEstadoCompra = 'F' AND CPD.CodigoProducto = @CodigoProducto	
	AND CAST(CP.Fecha AS DATE)  BETWEEN CAST(@FechaInicio AS DATE) AND CAST(@FechaFin AS DATE)
	IF(@cantidad IS NULL)
		SET @Cantidad = 0
	return @Cantidad
END
GO



DROP FUNCTION ObtenerCantidadDevueltaCompradaEnRangoFechaPorProducto 
GO

CREATE FUNCTION ObtenerCantidadDevueltaCompradaEnRangoFechaPorProducto (@CodigoProducto CHAR(15), @FechaInicio DATETIME, @FechaFin DATETIME)
RETURNS INT
AS
BEGIN	
	DECLARE @Cantidad INT = 0
	SELECT @Cantidad = SUM(CantidadDevuelta) 
	FROM ComprasProductosDevoluciones CPD INNER JOIN ComprasProductosDevolucionesDetalle CPDD on CPD.NumeroAgencia = CPDD.NumeroAgencia
	AND CPD.NumeroDevolucion = CPDD.NumeroDevolucion
	WHERE CPD.CodigoEstadoDevolucion = 'F' AND CPDD.CodigoProducto = @CodigoProducto	
	AND CAST(CPD.FechaHoraSolicitudDevolucion AS DATE)  BETWEEN CAST(@FechaInicio AS DATE) AND CAST(@FechaFin AS DATE)
	IF(@cantidad IS NULL)
		SET @Cantidad = 0
	return @Cantidad
END
GO


DROP FUNCTION ObtenerCantidadVendidaDevueltaEnRangoFechaPorProducto 
GO

CREATE FUNCTION ObtenerCantidadVendidaDevueltaEnRangoFechaPorProducto (@CodigoProducto CHAR(15), @FechaInicio DATETIME, @FechaFin DATETIME)
RETURNS INT
AS
BEGIN	
	DECLARE @Cantidad INT = 0
	SELECT @Cantidad = SUM(CantidadDevuelta) 
	FROM dbo.VentasProductosDevoluciones VPD INNER JOIN dbo.VentasProductosDevolucionesDetalle VPDD on VPD.NumeroAgencia = VPDD.NumeroAgencia
	AND VPD.NumeroDevolucion = VPDD.NumeroDevolucion
	WHERE VPD.CodigoEstadoDevolucion = 'F' AND VPDD.CodigoProducto = @CodigoProducto	
	AND CAST(VPD.FechaHoraSolicitudReemDevo AS DATE)  BETWEEN CAST(@FechaInicio AS DATE) AND CAST(@FechaFin AS DATE)
	IF(@cantidad IS NULL)
		SET @Cantidad = 0
	return @Cantidad
END
GO


DROP FUNCTION ObtenerCantidadVendidarReemplazadaEnRangoFechaPorProducto 
GO

CREATE FUNCTION ObtenerCantidadVendidarReemplazadaEnRangoFechaPorProducto (@CodigoProducto CHAR(15), @FechaInicio DATETIME, @FechaFin DATETIME)
RETURNS INT
AS
BEGIN	
	DECLARE @Cantidad INT = 0
	SELECT @Cantidad = SUM(CantidadDevuelta) 
	FROM dbo.VentasProductosReemplazo VPR INNER JOIN dbo.VentasProductosReemplazoDetalle VPRD on VPR.NumeroAgencia = VPRD.NumeroAgencia
	AND VPR.NumeroReemplazo = VPRD.NumeroReemplazo
	WHERE VPR.CodigoEstadoReemplazo = 'F' AND VPRD.CodigoProducto = @CodigoProducto	
	AND CAST(VPR.FechaHoraSolicitudReemplazo AS DATE)  BETWEEN CAST(@FechaInicio AS DATE) AND CAST(@FechaFin AS DATE)
	IF(@cantidad IS NULL)
		SET @Cantidad = 0
	return @Cantidad
END
GO

