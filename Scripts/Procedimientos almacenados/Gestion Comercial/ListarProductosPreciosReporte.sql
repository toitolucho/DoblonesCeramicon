USE Doblones20
GO

DROP PROCEDURE ListarProductosPreciosReporte
GO


CREATE PROCEDURE ListarProductosPreciosReporte
	@ListadoCodigosProductos	VARCHAR(8000),
	@ConExistencia				BIT,
	@CodigoMonedaCotizacion		INT,
	@NumeroAgencia				INT
AS
BEGIN	
	DECLARE @FactorCambioCotizacion DECIMAL(10,2),
			@CodigoMonedaSistema	INT,
			@FechaHoraCotizacion	DATETIME,
			@FactorCambioCotCadena	CHAR(10)

	SELECT TOP(1) @CodigoMonedaSistema = CodigoMonedaSistema
	FROM PCsConfiguraciones 
	WHERE NumeroAgencia = @NumeroAgencia
	
	SET @FechaHoraCotizacion = GETDATE()
	
	EXEC dbo.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraCotizacion, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT
	
	IF(@FactorCambioCotizacion = -1 OR @FactorCambioCotizacion IS NULL)
		EXEC dbo.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT	
	SET @FactorCambioCotizacion = CASE WHEN @FactorCambioCotizacion = -1 THEN 1 ELSE @FactorCambioCotizacion END
	SET @FactorCambioCotCadena = RTRIM(LTRIM(CAST(@FactorCambioCotizacion AS CHAR(10))))
	
	IF (@ListadoCodigosProductos IS NULL)
	BEGIN
		IF(@ConExistencia = 1)
			SELECT	CodigoProducto, NombreProducto, NombreProducto1, NombreProducto2, 
					NombreMarcaProducto, NombreTipoProducto,  NombreUnidad,  PrecioUnitarioCompra, 
					CAST(PrecioUnitarioVenta1 * @FactorCambioCotizacion AS  DECIMAL(10,2)) AS PrecioUnitarioVenta1, 
					CAST(PrecioUnitarioVenta2 * @FactorCambioCotizacion AS  DECIMAL(10,2)) AS PrecioUnitarioVenta2,  
					CAST(PrecioUnitarioVenta3 * @FactorCambioCotizacion AS  DECIMAL(10,2)) AS PrecioUnitarioVenta3,  
					CAST(PrecioUnitarioVenta4 * @FactorCambioCotizacion AS  DECIMAL(10,2)) AS PrecioUnitarioVenta4,  
					CAST(PrecioUnitarioVenta5 * @FactorCambioCotizacion AS  DECIMAL(10,2)) AS PrecioUnitarioVenta5,  
					CAST(PrecioUnitarioVenta6 * @FactorCambioCotizacion AS  DECIMAL(10,2)) AS PrecioUnitarioVenta6,  
					EsProductoEspecifico, Descripcion,  CantidadExistencia
			FROM ProductosMarcasUnidadesTiposInventario	
			WHERE ProductosMarcasUnidadesTiposInventario.CantidadExistencia > 0
		ELSE
			SELECT	CodigoProducto, NombreProducto, NombreProducto1, NombreProducto2, 
					NombreMarcaProducto, NombreTipoProducto,  NombreUnidad,  PrecioUnitarioCompra, 
					CAST(PrecioUnitarioVenta1 * @FactorCambioCotizacion AS  DECIMAL(10,2)) AS PrecioUnitarioVenta1, 
					CAST(PrecioUnitarioVenta2 * @FactorCambioCotizacion AS  DECIMAL(10,2)) AS PrecioUnitarioVenta2,  
					CAST(PrecioUnitarioVenta3 * @FactorCambioCotizacion AS  DECIMAL(10,2)) AS PrecioUnitarioVenta3,  
					CAST(PrecioUnitarioVenta4 * @FactorCambioCotizacion AS  DECIMAL(10,2)) AS PrecioUnitarioVenta4,  
					CAST(PrecioUnitarioVenta5 * @FactorCambioCotizacion AS  DECIMAL(10,2)) AS PrecioUnitarioVenta5,  
					CAST(PrecioUnitarioVenta6 * @FactorCambioCotizacion AS  DECIMAL(10,2)) AS PrecioUnitarioVenta6,  
					EsProductoEspecifico, Descripcion,  CantidadExistencia
			FROM ProductosMarcasUnidadesTiposInventario	
	END
	ELSE
	BEGIN		
		IF(@ConExistencia = 1)
			EXEC('SELECT	CodigoProducto, NombreProducto, NombreProducto1, NombreProducto2, 
					NombreMarcaProducto, NombreTipoProducto,  NombreUnidad,  PrecioUnitarioCompra, 
					CAST(PrecioUnitarioVenta1 * ' + @FactorCambioCotCadena + ' AS  DECIMAL(10,2)) AS PrecioUnitarioVenta1, 
					CAST(PrecioUnitarioVenta2 * ' + @FactorCambioCotCadena + ' AS  DECIMAL(10,2)) AS PrecioUnitarioVenta2,  
					CAST(PrecioUnitarioVenta3 * ' + @FactorCambioCotCadena + ' AS  DECIMAL(10,2)) AS PrecioUnitarioVenta3,  
					CAST(PrecioUnitarioVenta4 * ' + @FactorCambioCotCadena + ' AS  DECIMAL(10,2)) AS PrecioUnitarioVenta4,  
					CAST(PrecioUnitarioVenta5 * ' + @FactorCambioCotCadena + ' AS  DECIMAL(10,2)) AS PrecioUnitarioVenta5,  
					CAST(PrecioUnitarioVenta6 * ' + @FactorCambioCotCadena + ' AS  DECIMAL(10,2)) AS PrecioUnitarioVenta6,  
					EsProductoEspecifico, Descripcion,  CantidadExistencia
			FROM ProductosMarcasUnidadesTiposInventario
			WHERE CodigoProducto IN (' + @ListadoCodigosProductos+ ')
			AND ProductosMarcasUnidadesTiposInventario.CantidadExistencia > 0')
		ELSE
			EXEC('SELECT	CodigoProducto, NombreProducto, NombreProducto1, NombreProducto2, 
					NombreMarcaProducto, NombreTipoProducto,  NombreUnidad,  PrecioUnitarioCompra, 
					CAST(PrecioUnitarioVenta1 * ' + @FactorCambioCotCadena + ' AS  DECIMAL(10,2)) AS PrecioUnitarioVenta1, 
					CAST(PrecioUnitarioVenta2 * ' + @FactorCambioCotCadena + ' AS  DECIMAL(10,2)) AS PrecioUnitarioVenta2,  
					CAST(PrecioUnitarioVenta3 * ' + @FactorCambioCotCadena + ' AS  DECIMAL(10,2)) AS PrecioUnitarioVenta3,  
					CAST(PrecioUnitarioVenta4 * ' + @FactorCambioCotCadena + ' AS  DECIMAL(10,2)) AS PrecioUnitarioVenta4,  
					CAST(PrecioUnitarioVenta5 * ' + @FactorCambioCotCadena + ' AS  DECIMAL(10,2)) AS PrecioUnitarioVenta5,  
					CAST(PrecioUnitarioVenta6 * ' + @FactorCambioCotCadena + ' AS  DECIMAL(10,2)) AS PrecioUnitarioVenta6,  
					EsProductoEspecifico, Descripcion,  CantidadExistencia
			FROM ProductosMarcasUnidadesTiposInventario
			WHERE CodigoProducto IN (' + @ListadoCodigosProductos+ ')')
	END
END
GO





--exec ListarProductosPreciosReporte  '''001-16--000001 '',''001-ACC-000001 '',''001-ADA-000001 ''',1,1,1
--exec ListarProductosPreciosReporte  NULL, 1, 1, 1

