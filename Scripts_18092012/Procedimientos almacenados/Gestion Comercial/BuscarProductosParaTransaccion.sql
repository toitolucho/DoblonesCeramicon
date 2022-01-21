USE DOBLONES20

DROP PROCEDURE BuscarProductosParaTransaccion
GO

CREATE PROCEDURE BuscarProductosParaTransaccion
@CodigoAmbitoBusqueda CHAR(1),
@TextoABuscar VARCHAR(160),
@ExactamenteIgual BIT

AS
DECLARE @Campos CHAR(5)
DECLARE @S NVARCHAR(2000)
DECLARE @F NVARCHAR(100)
DECLARE @W NVARCHAR(2000)
DECLARE @AUX NVARCHAR(2000)
DECLARE @ScriptSQL VARCHAR(8000)
DECLARE @PosicionInicial TINYINT
DECLARE @PosicionActual TINYINT
DECLARE @PosicionFinal TINYINT
DECLARE @OperadorComparacion VARCHAR(4)
DECLARE @TextoABuscarOptimizado VARCHAR(170)
DECLARE @NombreCampo VARCHAR(250)

SET @S = 'SELECT P.CodigoProducto,P.NombreProducto,IP.PrecioUnitarioVenta1,IP.PrecioUnitarioVenta2,IP.PrecioUnitarioVenta3,IP.PrecioUnitarioVenta4,IP.PrecioUnitarioVenta5, IP.CantidadExistencia, IP.TiempoGarantiaProducto, CASE	WHEN (exists(select * from dbo.InventariosProductosEspecificos IPE where (IP.CodigoProducto = IPE.CodigoProducto))) THEN 1 ELSE 0 END AS EsProductoEspecifico ';
SET @F = 'FROM Productos P INNER JOIN InventariosProductos IP ON P.CodigoProducto = IP.CodigoProducto'
SET @W = ''
SET @AUX = ' '
SET @NombreCampo = ''

--'0' -> Codigo producto
--'1' -> Codigo fabrica
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
	SET @W = 'WHERE P.CodigoProducto ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '1' 
	SET @W = 'WHERE P.CodigoProductoFabricante ' + @OperadorComparacion + @TextoABuscarOptimizado
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

	SET @W = 'WHERE ' + LTRIM(RTRIM(@AUX))
END
ELSE
	SET @W = ' '

SET @ScriptSQL  = LTRIM(RTRIM(LTRIM(RTRIM(@S)) + ' ' + LTRIM(RTRIM(@F)) + ' ' +  LTRIM(RTRIM(@W))))
PRINT @ScriptSQL

EXEC(@ScriptSQL)


GO

--exec BuscarProductosParaTransaccion '2','  delux',0