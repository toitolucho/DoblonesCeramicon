USE [Doblones20]
GO
/****** Object:  StoredProcedure [dbo].[BuscarProductosParaTransaccion]    Script Date: 01/02/2011 18:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[BuscarProductosParaTransaccion]
@NumeroAgencia INT,
@TextoABuscar VARCHAR(160),
@CantidadExistencia INT,
@ExactamenteIgual BIT,
@CamposBusqueda CHAR(6), -- POR EJEMPLO: 100001 -> Implica buscar por codigoProducto en una determinada agencia
						--              101001 -> Implica buscar por CodigoProducto y NombreProducto en una determinada agencia
						--				001000 -> Implica buscar NombreProducto en todas las Agencias
@CodigoMonedaCotizacion	INT

AS
DECLARE @Campos CHAR(5)
DECLARE @S NVARCHAR(2000)
DECLARE @F NVARCHAR(200)
DECLARE @W NVARCHAR(4000)
DECLARE @W1 NVARCHAR(2000)
DECLARE @W2 NVARCHAR(2000)
DECLARE @W3 NVARCHAR(2000)
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

--SET @S = 'SELECT P.CodigoProducto,P.NombreProducto, IP.PrecioUnitarioCompra, IP.PrecioUnitarioVenta1,IP.PrecioUnitarioVenta2,IP.PrecioUnitarioVenta3,IP.PrecioUnitarioVenta4,IP.PrecioUnitarioVenta5, IP.PrecioUnitarioVenta6, IP.CantidadExistencia, IP.TiempoGarantiaProducto, dbo.EsProductoEspecifico(' + RTRIM(CAST(@NumeroAgencia AS CHAR(100))) +', P.CodigoProducto) AS EsProductoEspecifico ';
	SELECT TOP(1) @CodigoMonedaSistema = CodigoMonedaSistema, @CodigoMonedaRegion = CodigoMonedaRegion FROM PCsConfiguraciones WHERE NumeroAgencia = @NumeroAgencia
	

	--SET @S = 'SELECT DISTINCT P.CodigoProducto, P.NombreProducto, PM.NombreMarcaProducto, PU.NombreUnidad , IP.PrecioUnitarioVenta1, IP.PrecioUnitarioVenta2, IP.PrecioUnitarioVenta3 , CAST(IP.PrecioUnitarioVenta1 + IP.PrecioUnitarioVenta1 * 13 /100  AS DECIMAL(10,2)) AS PrecioUnitarioVenta4, CAST(IP.PrecioUnitarioVenta2 + IP.PrecioUnitarioVenta2 * 13 /100 AS DECIMAL(10,2)) AS PrecioUnitarioVenta5 , CAST(IP.PrecioUnitarioVenta3 + IP.PrecioUnitarioVenta3 * 13 /100 as DECIMAL(10,2)) AS PrecioUnitarioVenta6 ,  IP.CantidadExistencia'
	IF (@CodigoMonedaCotizacion = @CodigoMonedaSistema)
		SET @S = 'SELECT	P.CodigoProducto,P.NombreProducto, IP.PrecioUnitarioCompra, 
							IP.PrecioUnitarioVenta1,IP.PrecioUnitarioVenta2,IP.PrecioUnitarioVenta3,
							IP.PrecioUnitarioVenta4,IP.PrecioUnitarioVenta5, IP.PrecioUnitarioVenta6, 
							IP.CantidadExistencia, IP.TiempoGarantiaProducto, 
							dbo.EsProductoEspecifico(' + RTRIM(CAST(@NumeroAgencia AS CHAR(100))) +', P.CodigoProducto) AS EsProductoEspecifico ';
	ELSE
	BEGIN
		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaCotizacion, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT	
		IF(@FactorCambioCotizacion = -1)
			EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT
		
		SET @S = 'SELECT	P.CodigoProducto, P.NombreProducto, IP.PrecioUnitarioCompra, 
							CAST(IP.PrecioUnitarioVenta1 *' + CAST(@FactorCambioCotizacion AS VARCHAR(100)) + ' AS DECIMAL(10,2)) AS PrecioUnitarioVenta1, 
							CAST(IP.PrecioUnitarioVenta2 *' + CAST(@FactorCambioCotizacion AS VARCHAR(100)) + ' AS DECIMAL(10,2)) AS PrecioUnitarioVenta2, 
							CAST(IP.PrecioUnitarioVenta3 *' + CAST(@FactorCambioCotizacion AS VARCHAR(100)) + ' AS DECIMAL(10,2)) AS PrecioUnitarioVenta3, 
							CAST(IP.PrecioUnitarioVenta4 *' + CAST(@FactorCambioCotizacion AS VARCHAR(100)) + ' AS DECIMAL(10,2) ) AS PrecioUnitarioVenta4, 
							CAST(IP.PrecioUnitarioVenta5 *' + CAST(@FactorCambioCotizacion AS VARCHAR(100)) + ' AS DECIMAL(10,2) ) AS PrecioUnitarioVenta5, 
							CAST(IP.PrecioUnitarioVenta6 *' + CAST(@FactorCambioCotizacion AS VARCHAR(100)) + ' AS DECIMAL(10,2) ) AS PrecioUnitarioVenta6, 
							IP.CantidadExistencia, IP.TiempoGarantiaProducto, 
							dbo.EsProductoEspecifico(' + RTRIM(CAST(@NumeroAgencia AS CHAR(100))) +', P.CodigoProducto) AS EsProductoEspecifico ';
	END
SET @F = 'FROM Productos P INNER JOIN InventariosProductos IP ON P.CodigoProducto = IP.CodigoProducto'
SET @W = ''
SET @W1 = ''
SET @W2 = ''
SET @W3 = ''
SET @AUX = ' '
SET @NombreCampo = ''
SET @TextoABuscar  = LTRIM(RTRIM(@TextoABuscar))
--'[0]' -> Codigo producto
--'[1]' -> Codigo fabrica
--'[2]' -> Nombre producto
--'[3]' -> Nombre producto 1
--'[4]' -> Nombre producto 2
--'[4]' -> Buscar o No en todas las Agencias

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

IF (SUBSTRING(@CamposBusqueda,1,1) = '1')
BEGIN
	SET @W1 = '(P.CodigoProducto ' + @OperadorComparacion + @TextoABuscarOptimizado+')'
	PRINT 'CARACTER 0 = 1'+ '  CONDICION'+@W1
END
IF (SUBSTRING(@CamposBusqueda,2,1) = '1')
	SET @W2 = '(P.CodigoProductoFabricante ' + @OperadorComparacion + @TextoABuscarOptimizado+')'
IF (SUBSTRING(@CamposBusqueda,3,1) = '1') OR (SUBSTRING(@CamposBusqueda,4,1) = '1') OR (SUBSTRING(@CamposBusqueda,5,1) = '1')
BEGIN
	SET @PosicionInicial = 0
	SET @PosicionActual = 0
	SET @PosicionFinal = 0
	
	IF (SUBSTRING(@CamposBusqueda,3,1) = '1')
		SET @NombreCampo = ' NombreProducto '
	ELSE IF (SUBSTRING(@CamposBusqueda,4,1) = '1')
		SET @NombreCampo = ' NombreProducto1 '
	ELSE IF (SUBSTRING(@CamposBusqueda,5,1) = '1')
	BEGIN
		SET @F = @F + ' INNER JOIN ProductosMarcas PM ON PM.CodigoMarcaProducto = P.CodigoMarcaProducto'
		SET @NombreCampo = ' PM.NombreMarcaProducto '
	END
	
	WHILE LEN(@TextoABuscar) >= @PosicionActual
	BEGIN
		SET @PosicionActual = @PosicionActual + 1
		IF (SUBSTRING(@TextoABuscar, @PosicionActual, 1) = ' ')
		BEGIN
			IF LEN(@AUX) > 1
				SET @AUX = @AUX + ' AND '			
			SET @AUX = @AUX + @NombreCampo + ' LIKE ' + '''%' + SUBSTRING(@TextoABuscar, @PosicionInicial, (@PosicionActual - @PosicionInicial)) + '%'''			
			SET @PosicionInicial = @PosicionActual + 1
		END
	END

	SET @W3 = '(' + LTRIM(RTRIM(@AUX))+ ')'
END

PRINT @W1+@W2+@W3
IF(SUBSTRING(@CamposBusqueda,1,1)='1')
	SET @W = ' WHERE ' + @W1
IF(CAST(SUBSTRING(@CamposBusqueda,1,1) AS INT) + CAST(SUBSTRING(@CamposBusqueda,2,1) AS INT) > 1)
	SET @W = @W + ' OR ' + @W2
IF(SUBSTRING(@CamposBusqueda,2,1) ='1' AND SUBSTRING(@CamposBusqueda,1,1) ='0')
	PRINT 'BUSCANDO2' + @W2+'   '+@W 	
IF ((CAST(SUBSTRING(@CamposBusqueda,1,1) AS INT) + CAST(SUBSTRING(@CamposBusqueda,2,1) AS INT) + CAST(SUBSTRING(@CamposBusqueda,3,1) AS INT) >= 2) OR (CAST(SUBSTRING(@CamposBusqueda,1,1) AS INT) + CAST(SUBSTRING(@CamposBusqueda,2,1) AS INT) + CAST(SUBSTRING(@CamposBusqueda,4,1) AS INT) >= 2) OR (CAST(SUBSTRING(@CamposBusqueda,1,1) AS INT) + CAST(SUBSTRING(@CamposBusqueda,2,1) AS INT) + CAST(SUBSTRING(@CamposBusqueda,5,1) AS INT) >= 2))
	SET @W = @W + ' OR ' + @W3
IF (SUBSTRING(@CamposBusqueda,3,1) = '1' AND (CAST(SUBSTRING(@CamposBusqueda,1,1) AS INT) + CAST(SUBSTRING(@CamposBusqueda,2,1) AS INT) = 0)) OR (SUBSTRING(@CamposBusqueda,4,1) = '1' AND (CAST(SUBSTRING(@CamposBusqueda,1,1) AS INT) + CAST(SUBSTRING(@CamposBusqueda,2,1) AS INT) = 0)) OR (SUBSTRING(@CamposBusqueda,5,1) = '1' AND (CAST(SUBSTRING(@CamposBusqueda,1,1) AS INT) + CAST(SUBSTRING(@CamposBusqueda,2,1) AS INT) = 0))
	SET @W = ' WHERE ' + @W3
IF(SUBSTRING(@CamposBusqueda,6,1)='1')--BUSCAMOS EN UNA DETERMINADA AGENCIA
BEGIN
	IF (@W != '' AND LEN(@W)>1)
	BEGIN
		IF(SUBSTRING(RTRIM(LTRIM(@W)),LEN(RTRIM(LTRIM(@W)))-1,2)='OR')
			SET @W = SUBSTRING(RTRIM(@W),1,LEN(LTRIM(@W))-2)
		SET @W = @W +' AND (NumeroAgencia = '+RTRIM(CAST(@NumeroAgencia AS CHAR(100)))+') AND MostrarParaVenta  = 1 '
	END
	ELSE
		SET @W = 'WHERE NumeroAgencia = '+RTRIM(CAST(@NumeroAgencia AS CHAR(100))) + 'AND MostrarParaVenta  = 1 '
END
IF (@W != '' AND LEN(@W)>1)
	SET @W = @W + ' AND (CantidadExistencia >= '+ RTRIM(CAST(@CantidadExistencia AS CHAR(100)))+') AND MostrarParaVenta  = 1 '
ELSE
	SET @W = @W + ' WHERE (CantidadExistencia >= '+ RTRIM(CAST(@CantidadExistencia AS CHAR(100)))+') AND MostrarParaVenta  = 1 '
SET @ScriptSQL  = LTRIM(RTRIM(LTRIM(RTRIM(@S)) + ' ' + LTRIM(RTRIM(@F)) + ' ' +  LTRIM(RTRIM(@W)))) + ' ORDER BY NombreProducto'
PRINT @ScriptSQL

EXEC(@ScriptSQL)
GO
