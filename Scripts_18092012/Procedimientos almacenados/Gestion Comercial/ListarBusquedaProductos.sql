USE DOBLONES20

DROP PROCEDURE ListarBusquedaProductos
GO

CREATE PROCEDURE ListarBusquedaProductos
	@CodigoAmbitoBusqueda	CHAR(1),
	@TextoABuscar			VARCHAR(160),
	@ExactamenteIgual		BIT,
	@NumeroAgencia			INT,
	@CodigoMonedaCotizacion	INT,
	@ConExistencia			BIT
AS
	DECLARE @S NVARCHAR(2000)
	DECLARE @F NVARCHAR(3000)
	DECLARE @W NVARCHAR(2000)
	DECLARE @AUX NVARCHAR(2000)
	DECLARE @ScriptSQL VARCHAR(8000)
	DECLARE @PosicionInicial TINYINT
	DECLARE @PosicionActual TINYINT
	DECLARE @PosicionFinal TINYINT
	DECLARE @OperadorComparacion VARCHAR(4)
	DECLARE @TextoABuscarOptimizado VARCHAR(170)
	DECLARE @NombreCampo VARCHAR(250)	
	DECLARE @CodigoMonedaSistema	INT,
			@CodigoMonedaRegion		INT,
			@FechaCotizacion		DATETIME = GETDATE(),
			@FactorCambioCotizacion	DECIMAL(10,2)
	
BEGIN

	SELECT TOP(1) @CodigoMonedaSistema = CodigoMonedaSistema, @CodigoMonedaRegion = CodigoMonedaRegion FROM PCsConfiguraciones WHERE NumeroAgencia = @NumeroAgencia
	

	--SET @S = 'SELECT DISTINCT P.CodigoProducto, P.NombreProducto, PM.NombreMarcaProducto, PU.NombreUnidad , IP.PrecioUnitarioVenta1, IP.PrecioUnitarioVenta2, IP.PrecioUnitarioVenta3 , CAST(IP.PrecioUnitarioVenta1 + IP.PrecioUnitarioVenta1 * 13 /100  AS DECIMAL(10,2)) AS PrecioUnitarioVenta4, CAST(IP.PrecioUnitarioVenta2 + IP.PrecioUnitarioVenta2 * 13 /100 AS DECIMAL(10,2)) AS PrecioUnitarioVenta5 , CAST(IP.PrecioUnitarioVenta3 + IP.PrecioUnitarioVenta3 * 13 /100 as DECIMAL(10,2)) AS PrecioUnitarioVenta6 ,  IP.CantidadExistencia'
	IF (@CodigoMonedaCotizacion = @CodigoMonedaSistema)
		SET @S = 'SELECT P.CodigoProducto, P.NombreProducto, PM.NombreMarcaProducto, PU.NombreUnidad , IP.PrecioUnitarioCompra, IP.PrecioUnitarioVenta1, IP.PrecioUnitarioVenta2, IP.PrecioUnitarioVenta3 , IP.PrecioUnitarioVenta4, IP.PrecioUnitarioVenta5, IP.PrecioUnitarioVenta6, IP.CantidadExistencia'
	ELSE
	BEGIN
		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaCotizacion, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT	
		IF(@FactorCambioCotizacion = -1)
			EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT
		
		SET @S = 'SELECT P.CodigoProducto, P.NombreProducto, PM.NombreMarcaProducto, PU.NombreUnidad , CAST(IP.PrecioUnitarioCompra * '  + CAST(@FactorCambioCotizacion AS VARCHAR(100))  + ' AS DECIMAL(10,2)) AS PrecioUnitarioCompra, CAST(IP.PrecioUnitarioVenta1 * '  + CAST(@FactorCambioCotizacion AS VARCHAR(100))  + ' AS DECIMAL(10,2)) AS PrecioUnitarioVenta1, CAST(IP.PrecioUnitarioVenta2 *' + CAST(@FactorCambioCotizacion AS VARCHAR(100))  + ' AS DECIMAL(10,2)) AS PrecioUnitarioVenta2, CAST(IP.PrecioUnitarioVenta3 *' + CAST(@FactorCambioCotizacion AS VARCHAR(100))  + ' AS DECIMAL(10,2)) AS PrecioUnitarioVenta3, CAST(IP.PrecioUnitarioVenta4 *' + CAST(@FactorCambioCotizacion AS VARCHAR(100))  + ' AS DECIMAL(10,2) ) AS PrecioUnitarioVenta4, CAST(IP.PrecioUnitarioVenta5 * '+ CAST(@FactorCambioCotizacion AS VARCHAR(100))  + ' AS DECIMAL(10,2) ) AS PrecioUnitarioVenta5, CAST(IP.PrecioUnitarioVenta6 * '+ CAST(@FactorCambioCotizacion AS VARCHAR(100))  + ' AS DECIMAL(10,2) ) AS PrecioUnitarioVenta6, IP.CantidadExistencia'
	END
	SET @F = 'FROM Productos P INNER JOIN InventariosProductos IP ON P.CodigoProducto = IP.CodigoProducto
			  LEFT JOIN ProductosMarcas PM ON P.CodigoMarcaProducto = PM.CodigoMarcaProducto
			  INNER JOIN ProductosUnidades PU ON P.CodigoUnidad = PU.CodigoUnidad'
	SET @W = ''
	SET @AUX = ' '
	SET @NombreCampo = ''

	--'0' -> Codigo producto
	--'1' -> Codigo fabrica
	--'2' -> Codigo Producto Especifico
	--'3' -> Marca Producto
	--'4' -> Unidad Medida
	--'5' -> Descripcion
	--'6' -> Observacion
	--'7' -> Nombre producto
	--'8' -> Nombre producto 1
	--'9' -> Nombre producto 2
	--'10' -> Tipo Producto

	IF @ExactamenteIgual = 1
	BEGIN
		SET @OperadorComparacion = '='
		SET @TextoABuscarOptimizado = '''' + @TextoABuscar + ''''
	END
	ELSE
	BEGIN
		SET @OperadorComparacion = 'LIKE'
		SET @TextoABuscarOptimizado = '''%' + @TextoABuscar + '%'''
	END

	IF @CodigoAmbitoBusqueda = '0' 
		SET @W = 'WHERE P.CodigoProducto ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '1' 
		SET @W = 'WHERE P.CodigoProductoFabricante ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '2' 
	BEGIN
		SET @F += ' LEFT JOIN InventariosProductosEspecificos IPE ON IPE.CodigoProducto = IP.CodigoProducto '
		SET @W = 'WHERE IPE.CodigoProductoEspecifico ' + @OperadorComparacion + @TextoABuscarOptimizado
	END
	ELSE IF @CodigoAmbitoBusqueda = '3' 
		SET @W = 'WHERE PM.NombreMarcaProducto ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '4' 
		SET @W = 'WHERE PU.NombreUnidad ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '5' 
		SET @W = 'WHERE P.Descripcion ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '6' 
		SET @W = 'WHERE P.Observaciones ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF (@CodigoAmbitoBusqueda = '7') OR (@CodigoAmbitoBusqueda = '8') OR (@CodigoAmbitoBusqueda = '9')
	BEGIN
		SET @PosicionInicial = 0
		SET @PosicionActual = 0
		SET @PosicionFinal = 0

		WHILE LEN(@TextoABuscar) >= @PosicionActual
		BEGIN
			SET @PosicionActual = @PosicionActual + 1
			IF (SUBSTRING(@TextoABuscar, @PosicionActual, 1) = ' ')
			BEGIN
				IF LEN(@AUX) > 1
					SET @AUX = @AUX + ' AND '
				IF (@CodigoAmbitoBusqueda = '7')
					SET @NombreCampo = ' NombreProducto '
				ELSE IF (@CodigoAmbitoBusqueda = '8')
					SET @NombreCampo = ' NombreProducto1 '
				ELSE IF (@CodigoAmbitoBusqueda = '9')
					SET @NombreCampo = ' NombreProducto2 '
				SET @AUX = @AUX + @NombreCampo + ' LIKE ' + '''%' + SUBSTRING(@TextoABuscar, @PosicionInicial, (@PosicionActual - @PosicionInicial)) + '%'''			
				SET @PosicionInicial = @PosicionActual + 1
			END
		END

		SET @W = 'WHERE ' + LTRIM(RTRIM(@AUX))
	END
	ELSE
		SET @W = ' '
	IF(@NumeroAgencia IS NOT NULL)
		SET @W += ' AND IP.NumeroAgencia = ' + CAST(@NumeroAgencia AS CHAR(100))
	IF(@ConExistencia = 1)
		SET @W += ' AND IP.CantidadExistencia > 0'
	SET @ScriptSQL  = LTRIM(RTRIM(LTRIM(RTRIM(@S)) + ' ' + LTRIM(RTRIM(@F)) + ' ' +  LTRIM(RTRIM(@W))))
	PRINT @ScriptSQL

	EXEC(@ScriptSQL)

END
GO


--exec ListarBusquedaProductos 0,' ',0,null, 1, 1
