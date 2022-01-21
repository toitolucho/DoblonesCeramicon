USE DOBLONES20

DROP PROCEDURE BuscarProductoInventario
GO

CREATE PROCEDURE BuscarProductoInventario
@CodigoAmbitoBusqueda	CHAR(1),
@TextoABuscar			VARCHAR(160),
@ExactamenteIgual		BIT,
@CantidadExistencia		INT,
@NumeroAgencia			INT

AS
DECLARE @S NVARCHAR(2000)
DECLARE @F NVARCHAR(2000)
DECLARE @W NVARCHAR(2000)
DECLARE @AUX NVARCHAR(2000)
DECLARE @ScriptSQL VARCHAR(8000)
DECLARE @PosicionInicial TINYINT
DECLARE @PosicionActual TINYINT
DECLARE @PosicionFinal TINYINT
DECLARE @OperadorComparacion VARCHAR(4)
DECLARE @TextoABuscarOptimizado VARCHAR(170)
DECLARE @NombreCampo VARCHAR(250)
DECLARE @CondicionExistencia NVARCHAR(400)

IF (@CantidadExistencia > 0 )
	SET @CondicionExistencia = ' AND (IP.CantidadExistencia >= '+ RTRIM(LTRIM(CAST(@CantidadExistencia AS VARCHAR(4000)))) + ')'
ELSE
	SET @CondicionExistencia = ' AND (IP.CantidadExistencia < 1)'

SET @S = 'SELECT DISTINCT IP.NumeroAgencia, P.CodigoProducto, CantidadExistencia, CantidadRequerida, PrecioUnitarioCompraSinGastos, PrecioUnitarioCompra, TiempoGarantiaProducto, PorcentajeUtilidad1, PrecioUnitarioVenta1, PorcentajeUtilidad2, PrecioUnitarioVenta2, PorcentajeUtilidad3, PrecioUnitarioVenta3, PorcentajeUtilidad4, PrecioUnitarioVenta4, PorcentajeUtilidad5, PrecioUnitarioVenta5, PorcentajeUtilidad6, PrecioUnitarioVenta6, StockMinimo, MostrarParaVenta, CASE (IP.ClaseProducto) WHEN ''C'' THEN ''COMPUESTO'' WHEN ''S'' THEN ''SIMPLE'' END AS ClaseProducto , P.NombreProducto, RTRIM(LTRIM(CAST (ISNULL(P.Descripcion,''Ninguna'') AS VARCHAR(8000)))) AS Descripcion, ProductoEspecificoInventariado, EsProductoEspecifico'
SET @F = 'FROM Productos P INNER JOIN InventariosProductos IP ON P.CodigoProducto = IP.CodigoProducto'
				 --LEFT JOIN InventariosProductosEspecificos IPE ON IPE.NumeroAgencia = IP.NumeroAgencia AND IPE.CodigoProducto = IP.CodigoProducto'
IF(@CodigoAmbitoBusqueda = '1')	
BEGIN
	SET @F = @F + ' LEFT JOIN InventariosProductosEspecificos IPE ON IPE.NumeroAgencia = IP.NumeroAgencia AND IPE.CodigoProducto = IP.CodigoProducto '
END				 
SET @W = ''
SET @AUX = ' '
SET @NombreCampo = ''

--'0' -> Codigo producto
--'1' -> Codigo Específico
--'2' -> Nombre producto
--'3' -> Nombre producto 1
--'4' -> Nombre producto 2

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
	SET @W = 'WHERE P.CodigoProducto ' + @OperadorComparacion + @TextoABuscarOptimizado + 'AND IP.NumeroAgencia = ' + RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(10))))
ELSE IF @CodigoAmbitoBusqueda = '1' 
	SET @W = 'WHERE IPE.CodigoProductoEspecifico ' + @OperadorComparacion + @TextoABuscarOptimizado + 'AND IP.NumeroAgencia = ' + RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(10))))
ELSE IF (@CodigoAmbitoBusqueda = '2') OR (@CodigoAmbitoBusqueda = '3') OR (@CodigoAmbitoBusqueda = '4')
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
			IF (@CodigoAmbitoBusqueda = '2')
				SET @NombreCampo = ' NombreProducto '
			ELSE IF (@CodigoAmbitoBusqueda = '3')
				SET @NombreCampo = ' NombreProducto1 '
			ELSE IF (@CodigoAmbitoBusqueda = '4')
				SET @NombreCampo = ' NombreProducto2 '
			SET @AUX = @AUX + @NombreCampo + ' LIKE ' + '''%' + SUBSTRING(@TextoABuscar, @PosicionInicial, (@PosicionActual - @PosicionInicial)) + '%'''			
			SET @PosicionInicial = @PosicionActual + 1
		END
	END

	SET @W = 'WHERE ' + LTRIM(RTRIM(@AUX)) + @CondicionExistencia + 'AND IP.NumeroAgencia = ' + RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(10))))
END
ELSE
	SET @W = ' '

SET @ScriptSQL  = LTRIM(RTRIM(LTRIM(RTRIM(@S)) + ' ' + LTRIM(RTRIM(@F)) + ' ' +  LTRIM(RTRIM(@W))))
PRINT @ScriptSQL

EXEC(@ScriptSQL)


GO


--exec BuscarProductoInventario 3,'teclado',0,1,1
----select * from productos


--SELECT DISTINCT IP.NumeroAgencia, P.CodigoProducto, CantidadExistencia, CantidadRequerida, PrecioUnitarioCompra, TiempoGarantiaProducto, PorcentajeUtilidad1, PrecioUnitarioVenta1, PorcentajeUtilidad2, PrecioUnitarioVenta2, PorcentajeUtilidad3, PrecioUnitarioVenta3, PorcentajeUtilidad4, PrecioUnitarioVenta4, PorcentajeUtilidad5, PrecioUnitarioVenta5, PorcentajeUtilidad6, PrecioUnitarioVenta6, StockMinimo, MostrarParaVenta, CASE (IP.ClaseProducto) WHEN 'C' THEN 'COMPUESTO' WHEN 'S' THEN 'SIMPLE' END AS ClaseProducto , P.NombreProducto, RTRIM(LTRIM(CAST (ISNULL(P.Descripcion,'Ninguna') AS VARCHAR(8000)))) AS Descripcion, ProductoEspecificoInventariado, EsProductoEspecifico FROM Productos P INNER JOIN InventariosProductos IP ON P.CodigoProducto = IP.CodigoProducto 
--WHERE NombreProducto  LIKE '%teclado%' AND (IP.CantidadExistencia >= 1)AND IP.NumeroAgencia = 1
