USE Doblones20
GO
--Nos permite realizar busquedas dentro de una Transaccion ya
--culminada para seleccionar los productos entregados a ser devueltos

DROP PROCEDURE BuscarProductoTransaccionCompraDevolucion
GO

CREATE PROCEDURE BuscarProductoTransaccionCompraDevolucion
	@NumeroAgencia			INT,
    @NumeroTransaccion		INT,
    @CodigoAmbitoBusqueda	CHAR(1),  --en que Campos se Buscará : '0' -> CodigoProducto, '1' Codigo Producto Especifico, '2' NombreProducto</param>
    @TextoABuscar			VARCHAR(160),  --Texto a buscar
    @TipoTransaccion		CHAR(1),-- De donde se realizará la Devolución : 'V' Venta, 'D' Devolucion, 'A' Agregado
    @ExactamenteIgual		BIT
AS
DECLARE @S NVARCHAR(2000)
DECLARE @F VARCHAR(8000)
DECLARE @Condicion NVARCHAR(2000)
DECLARE @W NVARCHAR(4000)
DECLARE @GB NVARCHAR(2000)
DECLARE @AUX NVARCHAR(2000)
DECLARE @ScriptSQL VARCHAR(8000)
DECLARE @PosicionInicial TINYINT
DECLARE @PosicionActual TINYINT
DECLARE @PosicionFinal TINYINT
DECLARE @OperadorComparacion VARCHAR(4)
DECLARE @TextoABuscarOptimizado VARCHAR(170)
DECLARE @NombreCampo VARCHAR(250)

SET @AUX = ' '
SET @NombreCampo = ''
SET @GB = ' '

--'0' -> Codigo de Producto
--'1' -> Codigo Producto Especifico
--'2' -> Nombre producto

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

SET @W = ''

IF (@TipoTransaccion = 'C') --SI ES PARA COMPRAS
BEGIN
	SET @S = 'SELECT DISTINCT CPD.CodigoProducto , P.NombreProducto , CPD.CantidadCompra as Cantidad, CPD.PrecioUnitarioCompra AS PrecioUnitario, CPD.TiempoGarantiaCompra AS TiempoGarantia, dbo.EsProductoEspecifico('+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+',CPD.CodigoProducto) AS EsProductoEspecifico, dbo.ObtenerCantidadTotalRealCompradaVendida('+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+','+RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000)))+',CPD.CodigoProducto,''C'') - dbo.ObtenerCantidadTotalDevuelta_deProducto(CPD.CodigoProducto,'+ RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))) + ',''C'' ) AS LimiteCantidadPosibleDevolucion '
	SET @F = 'FROM ComprasProductos CP INNER JOIN ComprasProductosDetalle CPD ON CP.NumeroAgencia = CPD.NumeroAgencia AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
			  INNER JOIN Productos P on P.CodigoProducto = CPD.CodigoProducto '
	SET @W = 'WHERE CPD.CantidadCompra > dbo.ObtenerCantidadTotalDevuelta_deProducto(CPD.CodigoProducto,'+ RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))) +',''C'' ) AND CP.NumeroAgencia = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' AND CP.NumeroCompraProducto = '+ RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000)))
	IF @CodigoAmbitoBusqueda = '0' 
		SET @Condicion = 'CPD.CodigoProducto ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '1' 
	BEGIN
		SET @F = @F + 'LEFT JOIN dbo.ComprasProductosEspecificos CPE  ON CPE.NumeroAgencia = CPD.NumeroAgencia AND CPE.NumeroCompraProducto = CPD.NumeroCompraProducto AND CPE.CodigoProducto = CPD.CodigoProducto'
		SET @Condicion = 'CPE.CodigoProductoEspecifico ' + @OperadorComparacion + @TextoABuscarOptimizado
	END
	
END
ELSE IF (@TipoTransaccion = 'G') -- SI ES PARA COMPRAS DE PRODUCTOS AGREGADOS, REVISAR!!
BEGIN
	SET @S = 'SELECT CPA.CodigoProducto, P.NombreProducto, COUNT(CPA.CodigoProducto) AS Cantidad, CAST( AVG(CPA.PrecioUnitario)AS DECIMAL(10,2)) AS PrecioUnitario , AVG(CPA.TiempoGarantiaPE) TiempoGarantia, 1 as EsProductoEspecifico, COUNT(CPA.CodigoProducto) - dbo.ObtenerCantidadTotalDevuelta_deProducto(CPA.CodigoProducto,'+ RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))) +',''C'' ) AS LimiteCantidadPosibleDevolucion '
	SET @F = 'FROM ComprasProductos CP INNER JOIN ComprasProductosEspecificosAgregados CPA ON CP.NumeroAgencia = CPA.NumeroAgencia AND CP.NumeroCompraProducto = CPA.NumeroCompraProducto
			  INNER JOIN Productos P ON P.CodigoProducto = CPA.CodigoProducto '
	SET @W = 'WHERE CP.NumeroAgencia = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' AND CP.NumeroCompraProducto = '+ RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000)))
	SET @GB = 'GROUP BY CPA.CodigoProducto, P.NombreProducto
			   HAVING COUNT(CPA.CodigoProducto) > dbo.ObtenerCantidadTotalDevuelta_deProducto(CPA.CodigoProducto,'+ RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))) +',''C'')'
	IF @CodigoAmbitoBusqueda = '0' 
		SET @Condicion = 'CPA.CodigoProducto ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '1' 
		SET @Condicion = 'CPA.CodigoProductoEspecifico ' + @OperadorComparacion + @TextoABuscarOptimizado
END

IF (@CodigoAmbitoBusqueda = '2')
BEGIN
	SET @PosicionInicial = 0
	SET @PosicionActual = 0
	SET @PosicionFinal = 0
	SET @NombreCampo = ' P.NombreProducto '
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

	SET @Condicion =  LTRIM(RTRIM(@AUX))
END

SET @W = @W +' AND ('+RTRIM(@Condicion)+')';

SET @ScriptSQL  = LTRIM(RTRIM(LTRIM(RTRIM(@S)) + ' ' + LTRIM(RTRIM(@F)) + ' ' +  LTRIM(RTRIM(@W)) + LTRIM(RTRIM(@GB))))
PRINT @ScriptSQL

EXEC(@ScriptSQL)


GO

--EXEC BuscarProductoTransaccionCompraDevolucion 1,141,'2','','C',0
--EXEC BuscarProductoTransaccionCompraDevolucion 1,2,'2','','G',1