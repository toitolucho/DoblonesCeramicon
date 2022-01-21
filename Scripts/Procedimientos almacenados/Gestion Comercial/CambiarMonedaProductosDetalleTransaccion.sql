USE Doblones20
GO


DROP PROCEDURE CambiarMonedaProductosDetalleTransaccion
GO


CREATE PROCEDURE CambiarMonedaProductosDetalleTransaccion
	@NumeroAgencia			INT,
	@CodigoMonedaCotizacion	INT,
	@DetalleProductosXML	TEXT,
	@EsConFactura			BIT
	
AS
BEGIN
	DECLARE @CodigoMonedaSistema	INT,
			@CodigoMonedaRegion		INT,
			@FechaCotizacion		DATETIME = GETDATE(),
			@FactorCambioCotizacion	DECIMAL(10,2),
			@PorcentajeImpuesto		DECIMAL(10,2),
			@punteroXMLProductosDetalle INT
			
	DECLARE @TablaProductos		TABLE
	(
		Precio		DECIMAL(10,2),
		PrecioTotal	DECIMAL(10,2)
	)
			
	SELECT TOP(1) 
			@CodigoMonedaSistema = CodigoMonedaSistema, 
			@CodigoMonedaRegion = CodigoMonedaRegion, 
			@PorcentajeImpuesto = PorcentajeImpuesto
	FROM PCsConfiguraciones 
	WHERE NumeroAgencia = @NumeroAgencia
	
	
	EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @DetalleProductosXML	

	--SET @S = 'SELECT DISTINCT P.CodigoProducto, P.NombreProducto, PM.NombreMarcaProducto, PU.NombreUnidad , IP.PrecioUnitarioVenta1, IP.PrecioUnitarioVenta2, IP.PrecioUnitarioVenta3 , CAST(IP.PrecioUnitarioVenta1 + IP.PrecioUnitarioVenta1 * 13 /100  AS DECIMAL(10,2)) AS PrecioUnitarioVenta4, CAST(IP.PrecioUnitarioVenta2 + IP.PrecioUnitarioVenta2 * 13 /100 AS DECIMAL(10,2)) AS PrecioUnitarioVenta5 , CAST(IP.PrecioUnitarioVenta3 + IP.PrecioUnitarioVenta3 * 13 /100 as DECIMAL(10,2)) AS PrecioUnitarioVenta6 ,  IP.CantidadExistencia'
	IF (@CodigoMonedaCotizacion = @CodigoMonedaSistema AND @EsConFactura = 1)
		INSERT INTO @TablaProductos (Precio, PrecioTotal)
		SELECT  CASE TXML.NumeroPrecioSeleccionado 				
				WHEN '1' THEN IP.PrecioUnitarioVenta4 
				WHEN '2' THEN IP.PrecioUnitarioVenta5
				WHEN '3' THEN IP.PrecioUnitarioVenta6 
				ELSE Precio + Precio * @PorcentajeImpuesto / 100 
				END AS Precio,
				CASE TXML.NumeroPrecioSeleccionado				
				WHEN '1' THEN IP.PrecioUnitarioVenta4 * Cantidad
				WHEN '2' THEN IP.PrecioUnitarioVenta5 * Cantidad
				WHEN '3' THEN IP.PrecioUnitarioVenta6 * Cantidad
				ELSE PrecioTotal + PrecioTotal * @PorcentajeImpuesto / 100
				END  AS PrecioTotal
		FROM OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)
		WITH(	Precio						DECIMAL(10,2),
				PrecioTotal 				DECIMAL(10,2),
				NumeroPrecioSeleccionado	CHAR(1),
				CodigoProducto				CHAR(15),
				Cantidad					INT
			) TXML
		INNER JOIN 	dbo.InventariosProductos IP
		ON IP.CodigoProducto = TXML.CodigoProducto
		WHERE IP.NumeroAgencia = @NumeroAgencia
	ELSE
	BEGIN
		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaCotizacion, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT	
		IF(@FactorCambioCotizacion = -1)
			EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT
		
		IF(@EsConFactura = 0)
			INSERT INTO @TablaProductos (Precio, PrecioTotal)
			SELECT  Precio * @FactorCambioCotizacion as Precio, 
					PrecioTotal * @FactorCambioCotizacion as PrecioTotal
			FROM OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)
			WITH(	Precio						DECIMAL(10,2),
					PrecioTotal 				DECIMAL(10,2),
					NumeroPrecioSeleccionado	CHAR(1),
					CodigoProducto				CHAR(15)
				)		
				
		ELSE
			--INSERT INTO @TablaProductos (Precio, PrecioTotal)
			--SELECT  (Precio + Precio * @PorcentajeImpuesto / 100) * @FactorCambioCotizacion AS Precio, 
			--		(PrecioTotal + PrecioTotal * @PorcentajeImpuesto / 100) * @FactorCambioCotizacion AS PrecioTotal
			--FROM OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)
			--WITH(	Precio						DECIMAL(10,2),
			--		PrecioTotal 				DECIMAL(10,2),
			--		NumeroPrecioSeleccionado	CHAR(1),
			--		CodigoProducto				CHAR(15)
			--	)
			INSERT INTO @TablaProductos (Precio, PrecioTotal)
			SELECT  CASE TXML.NumeroPrecioSeleccionado 				
					WHEN '1' THEN IP.PrecioUnitarioVenta4 * @FactorCambioCotizacion
					WHEN '2' THEN IP.PrecioUnitarioVenta5 * @FactorCambioCotizacion
					WHEN '3' THEN IP.PrecioUnitarioVenta6 * @FactorCambioCotizacion
					ELSE Precio + Precio * @PorcentajeImpuesto / 100 
					END AS Precio,
					CASE TXML.NumeroPrecioSeleccionado				
					WHEN '1' THEN IP.PrecioUnitarioVenta4 * Cantidad * @FactorCambioCotizacion
					WHEN '2' THEN IP.PrecioUnitarioVenta5 * Cantidad * @FactorCambioCotizacion
					WHEN '3' THEN IP.PrecioUnitarioVenta6 * Cantidad * @FactorCambioCotizacion
					ELSE PrecioTotal + PrecioTotal * @PorcentajeImpuesto / 100
					END  AS PrecioTotal
			FROM OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)
			WITH(	Precio						DECIMAL(10,2),
					PrecioTotal 				DECIMAL(10,2),
					NumeroPrecioSeleccionado	CHAR(1),
					CodigoProducto				CHAR(15),
					Cantidad					INT
				) TXML
			INNER JOIN 	dbo.InventariosProductos IP
			ON IP.CodigoProducto = TXML.CodigoProducto
			WHERE IP.NumeroAgencia = @NumeroAgencia			
	END
	
	EXEC sp_xml_removedocument @punteroXMLProductosDetalle
	SELECT *
	FROM @TablaProductos
END
GO
