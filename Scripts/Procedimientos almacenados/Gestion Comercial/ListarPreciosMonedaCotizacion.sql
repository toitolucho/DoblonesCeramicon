USE Doblones20
GO

DROP PROCEDURE ListarPreciosMonedaCotizacion
GO


CREATE PROCEDURE ListarPreciosMonedaCotizacion 
	@NumeroAgencia					INT,
	@NumeroTransaccion				INT,
	@CodigoMonedaCambio				INT,
	@FechaCambioMonedaCotizacion	DATETIME,
	@incluirIVA						BIT,
	@tipoTransaccion				CHAR(1)
AS
BEGIN
	DECLARE @PorcentajeImpuestoIVA  DECIMAL(10,2),
			@FactorCambioCotizacion	DECIMAL(10,2),
			@CodigoMonedaSistema	INT
			
	SELECT TOP(1) @CodigoMonedaSistema = CodigoMonedaSistema, @PorcentajeImpuestoIVA = PorcentajeImpuesto FROM PCsConfiguraciones WHERE NumeroAgencia = @NumeroAgencia			
	EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaCambioMonedaCotizacion, @CodigoMonedaCambio, @FactorCambioCotizacion OUTPUT 
	
	IF(@FactorCambioCotizacion = -1)
		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaCambio, @FactorCambioCotizacion OUTPUT 
	 			
	IF(@tipoTransaccion = 'V') -- PARA VENTAS
	BEGIN
		IF(@incluirIVA = 1)
			SELECT CAST((PrecioUnitarioVenta + PrecioUnitarioVenta * @PorcentajeImpuestoIVA / 100) * @FactorCambioCotizacion AS DECIMAL(10,2)) AS PrecioUnitarioVenta, CAST(CAST((PrecioUnitarioVenta + PrecioUnitarioVenta * @PorcentajeImpuestoIVA / 100) * @FactorCambioCotizacion AS DECIMAL(10,2)) * CantidadVenta AS DECIMAL(10,2)) AS PrecioTotal
			FROM VentasProductosDetalle
			WHERE NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroTransaccion
		ELSE		
			SELECT CAST(PrecioUnitarioVenta * @FactorCambioCotizacion AS DECIMAL(10,2)) AS PrecioUnitarioVenta, CAST(CAST(PrecioUnitarioVenta * @FactorCambioCotizacion AS DECIMAL(10,2)) * CantidadVenta AS DECIMAL(10,2)) AS PrecioTotal
			FROM VentasProductosDetalle
			WHERE NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroTransaccion
	END
	
	IF(@tipoTransaccion = 'C') -- PARA COMRPAS
	BEGIN
		IF(@incluirIVA = 1)
			SELECT CAST((PrecioUnitarioCompra + PrecioUnitarioCompra * @PorcentajeImpuestoIVA / 100 ) * @FactorCambioCotizacion AS DECIMAL(10,2)) AS PrecioUnitarioCompra , CAST(CAST((PrecioUnitarioCompra + PrecioUnitarioCompra * @PorcentajeImpuestoIVA / 100 ) * @FactorCambioCotizacion AS DECIMAL(10,2)) * CantidadCompra AS DECIMAL(10,2)) AS PrecioTotal
			FROM ComprasProductosDetalle
			WHERE NumeroAgencia = @NumeroAgencia and NumeroCompraProducto = @NumeroTransaccion
		ELSE
			SELECT CAST(PrecioUnitarioCompra * @FactorCambioCotizacion AS DECIMAL(10,2)) AS PrecioUnitario , CAST(CAST(PrecioUnitarioCompra * @FactorCambioCotizacion AS DECIMAL(10,2)) * CantidadCompra AS DECIMAL(10,2)) AS PrecioTotal
			FROM ComprasProductosDetalle
			WHERE NumeroAgencia = @NumeroAgencia and NumeroCompraProducto = @NumeroTransaccion
	END
	
	
	IF(@tipoTransaccion = 'T') -- PARA COTIZACIONES DE VENTAS
	BEGIN
		IF(@incluirIVA = 1)
			SELECT CAST((PrecioUnitarioCotizacionVenta + PrecioUnitarioCotizacionVenta * @PorcentajeImpuestoIVA / 100) * @FactorCambioCotizacion AS DECIMAL(10,2)) AS PrecioUnitarioCotizacionVenta, CAST(CAST((PrecioUnitarioCotizacionVenta + PrecioUnitarioCotizacionVenta * @PorcentajeImpuestoIVA / 100) * @FactorCambioCotizacion AS DECIMAL(10,2)) * CantidadCotizacionVenta AS DECIMAL(10,2)) AS PrecioTotal
			FROM CotizacionVentasProductosDeta
			WHERE NumeroAgencia = @NumeroAgencia and NumeroCotizacionVentaProducto = @NumeroTransaccion
		ELSE		
			SELECT CAST(PrecioUnitarioCotizacionVenta * @FactorCambioCotizacion AS DECIMAL(10,2)) AS PrecioUnitarioCotizacionVenta, CAST(CAST(PrecioUnitarioCotizacionVenta * @FactorCambioCotizacion AS DECIMAL(10,2)) * CantidadCotizacionVenta AS DECIMAL(10,2)) AS PrecioTotal
			FROM CotizacionVentasProductosDeta
			WHERE NumeroAgencia = @NumeroAgencia and NumeroCotizacionVentaProducto = @NumeroTransaccion
	END
	
	IF(@tipoTransaccion = 'S') -- PARA SERVICIOS
	BEGIN
		IF(@incluirIVA = 1)
			SELECT CAST((PrecioUnitario + PrecioUnitario * @PorcentajeImpuestoIVA / 100) * @FactorCambioCotizacion AS DECIMAL(10,2)) AS PrecioUnitario, CAST(CAST((PrecioUnitario + PrecioUnitario * @PorcentajeImpuestoIVA / 100) * @FactorCambioCotizacion AS DECIMAL(10,2)) * CantidadVentaServicio AS DECIMAL(10,2)) AS PrecioTotal
			FROM VentasServiciosDetalle
			WHERE NumeroAgencia = @NumeroAgencia and NumeroVentaServicio = @NumeroTransaccion
		ELSE		
			SELECT CAST(PrecioUnitario * @FactorCambioCotizacion AS DECIMAL(10,2)) AS PrecioUnitario, CAST(CAST(PrecioUnitario * @FactorCambioCotizacion AS DECIMAL(10,2)) * PrecioUnitario AS DECIMAL(10,2)) AS PrecioTotal
			FROM VentasServiciosDetalle
			WHERE NumeroAgencia = @NumeroAgencia and NumeroVentaServicio = @NumeroTransaccion
	END
END
GO


--exec ListarPreciosMonedaCotizacion 1, 23, 1, '25/01/2010 8:13:58', 0, 'C'
--exec ListarPreciosMonedaCotizacion 1, 5, 2, '25/01/2010 8:13:58', 0, 'S'

--SELECT PorcentajeImpuesto FROM SistemaConfiguracion


--472,83	0,00	472,83
--486,88	0,00	486,88
--316,16	0,00	316,16

--1275,87 Bs

--SELECT PrecioUnitarioVenta 
--FROM VentasProductosDetalle
--WHERE NumeroVentaProducto = 19