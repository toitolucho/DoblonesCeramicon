USE DOBLONES20
GO


DROP PROCEDURE ListarDatosClienteCotizacionesVentaReporte
GO


CREATE PROCEDURE ListarDatosClienteCotizacionesVentaReporte
	@NumeroAgencia					INT,
	@NumeroCotizacionVentaProducto	INT
AS
BEGIN
	SELECT	CVP.NumeroAgencia, C.NombreCliente, C.NITCliente, RTRIM(LTRIM(CAST( C.Direccion AS VARCHAR(250)))) AS Direccion, 
			RTRIM(LTRIM(CAST( C.Telefono AS VARCHAR(50)))) AS Telefono, 
			RTRIM(LTRIM(CAST(ISNULL(U.NombreUsuario,'') AS CHAR(32)))) +' '+ RTRIM(LTRIM(CAST(ISNULL(U.Paterno,'') AS VARCHAR(40))))+' '+ RTRIM(LTRIM(CAST(ISNULL(U.Materno,'') AS VARCHAR(40)))) AS DatosUsuario, 
			CVP.FechaHoraCotizacion, CVP.ValidezOferta, CVP.TiempoEntrega, 
			M.MascaraMoneda, M.NombreMoneda, CVP.Observaciones
	FROM CotizacionVentasProductos CVP INNER JOIN Clientes C ON C.CodigoCliente = CVP.CodigoCliente 
		INNER JOIN Usuarios U ON U.CodigoUsuario =  CVP.CodigoUsuario		
		INNER JOIN Monedas M ON M.CodigoMoneda = CVP.CodigoMonedaCotizacionVenta
	WHERE CVP.NumeroAgencia = @NumeroAgencia AND CVP.NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
END
GO



DROP PROCEDURE ListarCotizacionVentasProductosDetalleReporte
GO

CREATE PROCEDURE ListarCotizacionVentasProductosDetalleReporte
	@NumeroAgencia					INT,
	@NumeroCotizacionVentaProducto	INT
AS
BEGIN

	DECLARE @FactorCambioCotizacion	DECIMAL(10,2),
			@CodigoMonedaSistema	INT,
			@CodigoMonedaCotizacion	INT,
			@CodigoMonedaRegion		INT,
			@FechaHoraCotizacion	DATETIME
	
	SELECT @FechaHoraCotizacion = FechaHoraCotizacion, @CodigoMonedaCotizacion = CodigoMonedaCotizacionVenta FROM dbo.CotizacionVentasProductos WHERE NumeroAgencia = @NumeroAgencia AND NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
	SELECT TOP(1) @CodigoMonedaRegion = CodigoMonedaRegion, @CodigoMonedaSistema = CodigoMonedaSistema FROM PCsConfiguraciones WHERE NumeroAgencia = @NumeroAgencia
	
	EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT

	SELECT	P.NombreProducto, 
			PM.NombreMarcaProducto, 
			P.Descripcion, 
			CVPD.CantidadCotizacionVenta, 
			CVPD.TiempoGarantiaCotizacionVenta,
			--CASE WHEN (@CodigoMonedaCotizacion = @CodigoMonedaSistema) THEN 
			--	CVPD.PrecioUnitarioCotizacionVenta 
			--ELSE 
			--	CAST((CVPD.PrecioUnitarioCotizacionVenta)* @FactorCambioCotizacion AS DECIMAL(10,2)) END AS PrecioUnitarioCotizacionVenta, 
			--CASE WHEN (@CodigoMonedaCotizacion = @CodigoMonedaSistema)  THEN 
			--	CVPD.CantidadCotizacionVenta * CVPD.PrecioUnitarioCotizacionVenta 
			--ELSE 
			--	CAST((CAST(@FactorCambioCotizacion * CVPD.PrecioUnitarioCotizacionVenta AS DECIMAL(10,2))) * CVPD.CantidadCotizacionVenta AS DECIMAL(10,2)) END AS PrecioTotal
			CASE WHEN (@CodigoMonedaCotizacion = @CodigoMonedaSistema) THEN 
				CVPD.PrecioUnitarioCotizacionVenta 
			ELSE 
				CAST((CVPD.PrecioUnitarioCotizacionVenta)* @FactorCambioCotizacion AS DECIMAL(10,2)) END AS PrecioUnitarioCotizacionVenta2, 
			CASE WHEN (@CodigoMonedaCotizacion = @CodigoMonedaSistema)  THEN 
				CVPD.CantidadCotizacionVenta * CVPD.PrecioUnitarioCotizacionVenta 
			ELSE 
				CAST((CAST(@FactorCambioCotizacion * CVPD.PrecioUnitarioCotizacionVenta AS DECIMAL(10,2))) * CVPD.CantidadCotizacionVenta AS DECIMAL(10,2)) END AS PrecioTotal2,
			CVPD.PrecioUnitarioCotizacionOtraMoneda AS PrecioUnitarioCotizacionVenta, 
			CVPD.CantidadCotizacionVenta * CVPD.PrecioUnitarioCotizacionOtraMoneda AS PrecioTotal
				
	FROM dbo.CotizacionVentasProductosDeta CVPD 
	INNER JOIN Productos 
	P ON P.CodigoProducto = CVPD.CodigoProducto
	INNER JOIN ProductosMarcas PM 
	ON PM.CodigoMarcaProducto = P.CodigoMarcaProducto
	WHERE CVPD.NumeroAgencia = @NumeroAgencia AND CVPD.NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
	ORDER BY cvpd.NumeroOrdenInsertado
END
GO
--exec dbo.ListarCotizacionVentasProductosDetalleReporte 1,270

DROP PROCEDURE ListarDatosCotizacionesVentaReporteDetallado
GO


CREATE PROCEDURE ListarDatosCotizacionesVentaReporteDetallado
	@NumeroAgencia					INT,
	@NumeroCotizacionVentaProducto	INT
AS
BEGIN

	DECLARE @FactorCambioCotizacion		DECIMAL(10,2),
			@CodigoMonedaSistema		INT,
			@CodigoMonedaCotizacion		INT,
			@CodigoMonedaRegion			INT,
			@FechaHoraVenta				DATETIME,
			@MontoTotalVentaConFactura	DECIMAL(10,2),
			@MontoTotalVentaSinFactura	DECIMAL(10,2),
			@CadenaMontoTotalConFactura	VARCHAR(255),
			@CadenaMontoTotalSinFactura	VARCHAR(255),
			@NombreMonedaRegion			VARCHAR(250),
			@MascaraMonedaRegion		VARCHAR(20),
			@EsConFactura				BIT,
			@PorcentajeImpuesto			DECIMAL(10,2)
			
	
	SELECT	@FechaHoraVenta = FechaHoraCotizacion, 
			@CodigoMonedaCotizacion = CodigoMonedaCotizacionVenta
	FROM CotizacionVentasProductos 
	WHERE NumeroAgencia = @NumeroAgencia 
	AND NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
	
	
	SELECT TOP(1) @CodigoMonedaRegion = CodigoMonedaRegion, @CodigoMonedaSistema = CodigoMonedaSistema , @PorcentajeImpuesto = PorcentajeImpuesto
	FROM PCsConfiguraciones 
	WHERE NumeroAgencia = @NumeroAgencia
	
	SELECT @EsConFactura = ConFactura
	FROM CotizacionVentasProductos 
	WHERE NumeroAgencia = @NumeroAgencia 
	AND NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
	
	SELECT @NombreMonedaRegion = NombreMoneda, @MascaraMonedaRegion = MascaraMoneda 
	FROM Monedas 
	WHERE CodigoMoneda = @CodigoMonedaRegion
	
	

	EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraVenta, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT
		
	IF(@FactorCambioCotizacion = -1)
		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT		
	
	IF(@EsConFactura = 1)
	BEGIN
		--CALCULAMOS EL MONTO TOTAL CON FACTURA
		IF(@CodigoMonedaSistema <> @CodigoMonedaCotizacion)
		BEGIN
			--SELECT @MontoTotalVentaConFactura = MontoTotalCotizacion * @FactorCambioCotizacion
			--FROM CotizacionVentasProductos
			--WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto 
			--AND NumeroAgencia = @NumeroAgencia	
			
			SELECT @MontoTotalVentaConFactura = SUM(PrecioUnitarioCotizacionOtraMoneda * CantidadCotizacionVenta)
			FROM CotizacionVentasProductosDeta
			WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto 
			AND NumeroAgencia = @NumeroAgencia	
		END
		ELSE
		BEGIN
			--SELECT @MontoTotalVentaConFactura = MontoTotalCotizacion
			--FROM CotizacionVentasProductos
			--WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
			--AND NumeroAgencia = @NumeroAgencia
			
			SELECT @MontoTotalVentaConFactura = SUM(PrecioUnitarioCotizacionOtraMoneda * CantidadCotizacionVenta)
			FROM CotizacionVentasProductosDeta
			WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto 
			AND NumeroAgencia = @NumeroAgencia		
		END
		--CALCULAMOS EL MONTO TOTAL SIN FACTURA
		IF(@CodigoMonedaCotizacion <> @CodigoMonedaSistema)
		BEGIN
			--SELECT @MontoTotalVentaSinFactura = (MontoTotalCotizacion /(1 + @PorcentajeImpuesto / 100)) * @FactorCambioCotizacion
			--FROM CotizacionVentasProductos
			--WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto 
			--AND NumeroAgencia = @NumeroAgencia	
			
			SELECT @MontoTotalVentaSinFactura = SUM(PrecioUnitarioCotizacionOtraMoneda * CantidadCotizacionVenta)
			FROM CotizacionVentasProductosDeta
			WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto 
			AND NumeroAgencia = @NumeroAgencia
			
			
			SET @MontoTotalVentaSinFactura = (@MontoTotalVentaSinFactura /(1 + @PorcentajeImpuesto / 100))
						
		END
		ELSE
		BEGIN
			--SELECT @MontoTotalVentaSinFactura = MontoTotalCotizacion /( 1 + @PorcentajeImpuesto / 100)
			--FROM CotizacionVentasProductos
			--WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
			--AND NumeroAgencia = @NumeroAgencia
			
			SELECT @MontoTotalVentaSinFactura = SUM(PrecioUnitarioCotizacionOtraMoneda * CantidadCotizacionVenta)
			FROM CotizacionVentasProductosDeta
			WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto 
			AND NumeroAgencia = @NumeroAgencia
			
			SET @MontoTotalVentaSinFactura = @MontoTotalVentaSinFactura /( 1 + @PorcentajeImpuesto / 100)
			
		END
	END
	ELSE
	BEGIN -- NO ES CON FACTURA
		--CALCULAMOS EL MONTO TOTAL CON FACTURA
		IF(@CodigoMonedaSistema <> @CodigoMonedaCotizacion)
		BEGIN
			--SELECT @MontoTotalVentaConFactura = (MontoTotalCotizacion + (MontoTotalCotizacion * @PorcentajeImpuesto / 100)) * @FactorCambioCotizacion 
			--FROM CotizacionVentasProductos
			--WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto 
			--AND NumeroAgencia = @NumeroAgencia	
			
			SELECT @MontoTotalVentaConFactura = SUM(PrecioUnitarioCotizacionOtraMoneda * CantidadCotizacionVenta)
			FROM CotizacionVentasProductosDeta
			WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto 
			AND NumeroAgencia = @NumeroAgencia
			
			SELECT @MontoTotalVentaConFactura = (@MontoTotalVentaConFactura + (@MontoTotalVentaConFactura * @PorcentajeImpuesto / 100)) 
		END
		ELSE
		BEGIN
			--SELECT @MontoTotalVentaConFactura = MontoTotalCotizacion + (MontoTotalCotizacion * @PorcentajeImpuesto / 100)
			--FROM CotizacionVentasProductos
			--WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
			--AND NumeroAgencia = @NumeroAgencia	
			
			SELECT @MontoTotalVentaConFactura = SUM(PrecioUnitarioCotizacionOtraMoneda * CantidadCotizacionVenta)
			FROM CotizacionVentasProductosDeta
			WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto 
			AND NumeroAgencia = @NumeroAgencia
			
			SET @MontoTotalVentaConFactura = @MontoTotalVentaConFactura + (@MontoTotalVentaConFactura * @PorcentajeImpuesto / 100)
		END
			
		--CALCULAMOS EL MONTO TOTAL SIN FACTURA
		
		IF(@CodigoMonedaCotizacion <> @CodigoMonedaSistema)
		BEGIN
			--SELECT @MontoTotalVentaSinFactura = (MontoTotalCotizacion * @FactorCambioCotizacion)
			--FROM CotizacionVentasProductos
			--WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto 
			--AND NumeroAgencia = @NumeroAgencia	
			
			
			SELECT @MontoTotalVentaSinFactura = SUM(PrecioUnitarioCotizacionOtraMoneda * CantidadCotizacionVenta)
			FROM CotizacionVentasProductosDeta
			WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto 
			AND NumeroAgencia = @NumeroAgencia
			
			--SET @MontoTotalVentaSinFactura = (@MontoTotalVentaSinFactura * @FactorCambioCotizacion)			
		END
		ELSE
		BEGIN
			--SELECT @MontoTotalVentaSinFactura = MontoTotalCotizacion 
			--FROM CotizacionVentasProductos
			--WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
			--AND NumeroAgencia = @NumeroAgencia		
			
			SELECT @MontoTotalVentaSinFactura = SUM(PrecioUnitarioCotizacionOtraMoneda * CantidadCotizacionVenta)
			FROM CotizacionVentasProductosDeta
			WHERE NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto 
			AND NumeroAgencia = @NumeroAgencia			
		END
	END
	
	
		
	EXEC ConvertirMontoNumerico_a_Texto @MontoTotalVentaConFactura, @NombreMonedaRegion, @CadenaMontoTotalConFactura output
	EXEC ConvertirMontoNumerico_a_Texto @MontoTotalVentaSinFactura, @NombreMonedaRegion, @CadenaMontoTotalSinFactura output

	SELECT	CVP.NumeroAgencia, C.NombreCliente, C.NombreRepresentante, 
			C.NITCliente, RTRIM(LTRIM(CAST( C.Direccion AS VARCHAR(250)))) AS Direccion, 
			RTRIM(LTRIM(CAST( C.Telefono AS VARCHAR(50)))) AS Telefono, 
			RTRIM(LTRIM(CAST(ISNULL(U.NombreUsuario,'') AS CHAR(32)))) +' '+ RTRIM(LTRIM(CAST(ISNULL(U.Paterno,'') AS VARCHAR(40))))+' '+ RTRIM(LTRIM(CAST(ISNULL(U.Materno,'') AS VARCHAR(40)))) AS DatosUsuario, 
			CVP.FechaHoraCotizacion, CVP.ValidezOferta, 
			--CAST(CASE CVP.TiempoEntrega WHEN 0 THEN 'INMEDIATA' ELSE CVP.TiempoEntrega END AS VARCHAR(100)) AS TiempoEntrega , 
			CVP.TiempoEntrega, 
			M.MascaraMoneda, M.NombreMoneda,
			@FactorCambioCotizacion as FactorCambioCotizacion,
			@PorcentajeImpuesto AS PorcentajeImpuesto,
			@MontoTotalVentaConFactura AS MontoTotalVentaConFactura,
			@MontoTotalVentaSinFactura AS MontoTotalVentaSinFactura,
			@CadenaMontoTotalConFactura AS CadenaMontoTotalConFactura,
			@CadenaMontoTotalSinFactura AS CadenaMontoTotalSinFactura
			
	FROM CotizacionVentasProductos CVP 
	INNER JOIN Clientes C 
	ON C.CodigoCliente = CVP.CodigoCliente 
	INNER JOIN Usuarios U 
	ON U.CodigoUsuario =  CVP.CodigoUsuario		
	INNER JOIN Monedas M 
	ON M.CodigoMoneda = CVP.CodigoMonedaCotizacionVenta
	WHERE CVP.NumeroAgencia = @NumeroAgencia 
	AND CVP.NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto	
END
GO

--select SUM(PrecioUnitarioCotizacionVenta) 
--from CotizacionVentasProductosDeta
--where NumeroCotizacionVentaProducto = 80

--select * from CotizacionVentasProductos
--where NumeroCotizacionVentaProducto = 80

--exec ListarDatosCotizacionesVentaReporteDetallado 1, 272

DROP PROCEDURE ListarCotizacionVentasProductosDetalleReporteDetallado
GO

CREATE PROCEDURE ListarCotizacionVentasProductosDetalleReporteDetallado
	@NumeroAgencia					INT,
	@NumeroCotizacionVentaProducto	INT
AS
BEGIN

	DECLARE @FactorCambioCotizacion	DECIMAL(10,2),
			@CodigoMonedaSistema	INT,
			@CodigoMonedaCotizacion	INT,
			@CodigoMonedaRegion		INT,
			@FechaHoraCotizacion	DATETIME
	
	SELECT @FechaHoraCotizacion = FechaHoraCotizacion, @CodigoMonedaCotizacion = CodigoMonedaCotizacionVenta FROM dbo.CotizacionVentasProductos WHERE NumeroAgencia = @NumeroAgencia AND NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
	SELECT TOP(1) @CodigoMonedaRegion = CodigoMonedaRegion, @CodigoMonedaSistema = CodigoMonedaSistema FROM PCsConfiguraciones WHERE NumeroAgencia = @NumeroAgencia
	
	EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraCotizacion, @CodigoMonedaRegion, @FactorCambioCotizacion OUTPUT
		
	IF(@FactorCambioCotizacion = -1)
		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaRegion, @FactorCambioCotizacion OUTPUT	

	SELECT	P.NombreProducto, 
			PM.NombreMarcaProducto, 
			PT.NombreTipoProducto,
			CVPD.TiempoGarantiaCotizacionVenta,
			CVPD.CantidadCotizacionVenta, 
			--CASE WHEN (@CodigoMonedaCotizacion = @CodigoMonedaSistema) THEN 
			--	CVPD.PrecioUnitarioCotizacionVenta 
			--ELSE 
			--	CAST((CVPD.PrecioUnitarioCotizacionVenta)* @FactorCambioCotizacion AS DECIMAL(10,2)) END AS PrecioUnitarioCotizacionVenta, 
			--CASE WHEN (@CodigoMonedaCotizacion = @CodigoMonedaSistema)  THEN 
			--	CVPD.CantidadCotizacionVenta * CVPD.PrecioUnitarioCotizacionVenta 
			--ELSE 
			--	CAST((CAST(@FactorCambioCotizacion * CVPD.PrecioUnitarioCotizacionVenta AS DECIMAL(10,2))) * CVPD.CantidadCotizacionVenta AS DECIMAL(10,2)) END AS PrecioTotal
			CASE WHEN (@CodigoMonedaCotizacion = @CodigoMonedaSistema) THEN 
				CVPD.PrecioUnitarioCotizacionVenta 
			ELSE 
				CAST((CVPD.PrecioUnitarioCotizacionVenta)* @FactorCambioCotizacion AS DECIMAL(10,2)) END AS PrecioUnitarioCotizacionVenta2, 
			CASE WHEN (@CodigoMonedaCotizacion = @CodigoMonedaSistema)  THEN 
				CVPD.CantidadCotizacionVenta * CVPD.PrecioUnitarioCotizacionVenta 
			ELSE 
				CAST((CAST(@FactorCambioCotizacion * CVPD.PrecioUnitarioCotizacionVenta AS DECIMAL(10,2))) * CVPD.CantidadCotizacionVenta AS DECIMAL(10,2)) END AS PrecioTotal2,
			CVPD.PrecioUnitarioCotizacionOtraMoneda AS PrecioUnitarioCotizacionVenta, 
			CVPD.CantidadCotizacionVenta * CVPD.PrecioUnitarioCotizacionOtraMoneda AS PrecioTotal
	FROM dbo.CotizacionVentasProductosDeta CVPD 
	INNER JOIN Productos P 
	ON P.CodigoProducto = CVPD.CodigoProducto
	INNER JOIN ProductosMarcas PM 
	ON PM.CodigoMarcaProducto = P.CodigoMarcaProducto
	INNER JOIN ProductosTipos PT
	ON P.CodigoTipoProducto = PT.CodigoTipoProducto
	WHERE CVPD.NumeroAgencia = @NumeroAgencia 
	AND CVPD.NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
	ORDER BY CVPD.NumeroOrdenInsertado
END
GO
--exec ListarCotizacionVentasProductosDetalleReporteDetallado 1,80
