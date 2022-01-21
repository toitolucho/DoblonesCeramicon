USE Doblones20
GO

--Nos Permite realizar la busqueda de Productos para Reemplazarlos por los
--productos devueltos de una Transacción, ya sea venta o devolucion de una devolucion
DROP PROCEDURE BuscarProductosParaTransaccionDevolucionReem
GO


CREATE PROCEDURE BuscarProductosParaTransaccionDevolucionReem
@NumeroAgencia INT,
@TextoABuscar VARCHAR(160),
@CantidadExistencia INT,
@ExactamenteIgual BIT,
@CamposBusqueda CHAR(6) -- POR EJEMPLO: 100001 -> Implica buscar por codigoProducto en una determinada agencia
						--              101001 -> Implica buscar por CodigoProducto y NombreProducto en una determinada agencia
						--				001000 -> Implica buscar NombreProducto en todas las Agencias

AS
DECLARE @Campos CHAR(5)
DECLARE @S NVARCHAR(2000)
DECLARE @F NVARCHAR(400)
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

SET @S = 'SELECT P.CodigoProducto, IPE.CodigoProductoEspecifico, P.NombreProducto, IP.PrecioUnitarioCompra, IP.PrecioUnitarioVenta1, IP.CantidadExistencia, IP.TiempoGarantiaProducto ';
SET @F = 'FROM Productos P INNER JOIN InventariosProductos IP ON IP.CodigoProducto = P.CodigoProducto
				 INNER JOIN InventariosProductosEspecificos IPE ON IP.CodigoProducto = IPE.CodigoProducto'
SET @W = ''
SET @W1 = ''
SET @W2 = ''
SET @W3 = ''
SET @AUX = ' '
SET @NombreCampo = ''
SET @TextoABuscar  = LTRIM(RTRIM(@TextoABuscar))
--'[0]' -> Codigo producto
--'[1]' -> Codigo Producto Especifico
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
	SET @W2 = '(IPE.CodigoProductoEspecifico ' + @OperadorComparacion + @TextoABuscarOptimizado+')'
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
		SET @NombreCampo = ' NombreProducto2 '
	
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
	SET @W = ' WHERE ' + @W2	
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
		SET @W = @W +' AND (IP.NumeroAgencia = '+RTRIM(CAST(@NumeroAgencia AS CHAR(100)))+')'
	END
	ELSE
		SET @W = 'WHERE IP.NumeroAgencia = '+RTRIM(CAST(@NumeroAgencia AS CHAR(100)))
END
IF (@W != '' AND LEN(@W)>1)
	SET @W = @W + ' AND (CantidadExistencia >= '+ RTRIM(CAST(@CantidadExistencia AS CHAR(100)))+')'+ 'AND (IPE.CodigoEstado = ''A'' )'
ELSE
	SET @W = @W + ' WHERE (CantidadExistencia >= '+ RTRIM(CAST(@CantidadExistencia AS CHAR(100)))+')'+ 'AND (IPE.CodigoEstado = ''A'' )'
SET @ScriptSQL  = LTRIM(RTRIM(LTRIM(RTRIM(@S)) + ' ' + LTRIM(RTRIM(@F)) + ' ' +  LTRIM(RTRIM(@W))))
PRINT @ScriptSQL

EXEC(@ScriptSQL)


GO

--exec BuscarProductosParaTransaccionDevolucionReem 1,'10',0,0,'100001'
--exec BuscarProductosParaTransaccionDevolucionReem 1,'100',0,0,'010001'
--exec BuscarProductosParaTransaccion 1,'222',0,'01000'
--exec BuscarProductosParaTransaccion 1,'222',0,'01100'
--exec BuscarProductosParaTransaccion 1,'222',0,'10000'
--exec BuscarProductosParaTransaccion 1,'222',0,'10100'
--exec BuscarProductosParaTransaccion 1,'222',0,'11000'
--exec BuscarProductosParaTransaccion 1,'222',0,'11100'