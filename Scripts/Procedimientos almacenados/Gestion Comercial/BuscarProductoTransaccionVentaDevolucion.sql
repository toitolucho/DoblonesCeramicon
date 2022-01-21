USE Doblones20
GO
--Nos permite realizar busquedas dentro de una Transaccion ya
--culminada para seleccionar los productos entregados a ser devueltos

DROP PROCEDURE BuscarProductoTransaccionVentaDevolucion
GO

CREATE PROCEDURE BuscarProductoTransaccionVentaDevolucion
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

IF (@TipoTransaccion = 'V') --SI ES PARA VENTAS
BEGIN
	SET @S = 'SELECT DISTINCT VPD.CodigoProducto , P.NombreProducto , VPD.CantidadVenta as Cantidad, VPD.PrecioUnitarioVenta AS PrecioUnitario, VPD.TiempoGarantiaVenta AS TiempoGarantia, dbo.EsProductoEspecifico('+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+',VPD.CodigoProducto) AS EsProductoEspecifico, dbo.ObtenerCantidadTotalRealCompradaVendida('+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+','+RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000)))+',VPD.CodigoProducto,''V'') - dbo.ObtenerCantidadTotalDevuelta_deProducto(VPD.CodigoProducto,'+ RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))) + ',''V'' ) AS LimiteCantidadPosibleDevolucion '
	SET @F = 'FROM VentasProductos VP INNER JOIN VentasProductosDetalle VPD ON VP.NumeroAgencia = VPD.NumeroAgencia AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
			  INNER JOIN Productos P on P.CodigoProducto = VPD.CodigoProducto '
	SET @W = 'WHERE VPD.CantidadVenta > dbo.ObtenerCantidadTotalDevuelta_deProducto(VPD.CodigoProducto,'+ RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))) +',''V'' ) AND VP.NumeroAgencia = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' AND VP.NumeroVentaProducto = '+ RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000)))
	IF @CodigoAmbitoBusqueda = '0' 
		SET @Condicion = 'VPD.CodigoProducto ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '1' 
	BEGIN
		SET @F = @F + 'LEFT JOIN VentasProductosEspecificos VPE  ON VPE.NumeroAgencia = VPD.NumeroAgencia AND VPE.NumeroVentaProducto = VPD.NumeroVentaProducto AND VPE.CodigoProducto = VPD.CodigoProducto'
		SET @Condicion = 'VPE.CodigoProductoEspecifico ' + @OperadorComparacion + @TextoABuscarOptimizado
	END
	
END
ELSE IF (@TipoTransaccion = 'A') -- SI ES PARA VENTAS DE PRODUCTOS AGREGADOS
BEGIN
	SET @S = 'SELECT VPA.CodigoProducto, P.NombreProducto, COUNT(VPA.CodigoProducto) AS Cantidad, CAST( AVG(VPA.PrecioUnitario)AS DECIMAL(10,2)) AS PrecioUnitario , AVG(VPA.TiempoGarantiaPE) TiempoGarantia, 1 as EsProductoEspecifico, COUNT(VPA.CodigoProducto) - dbo.ObtenerCantidadTotalDevuelta_deProducto(VPA.CodigoProducto,'+ RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))) +',''V'' ) AS LimiteCantidadPosibleDevolucion '
	SET @F = 'FROM VentasProductos VP INNER JOIN VentasProductosEspecificosAgregados VPA ON VP.NumeroAgencia = VPA.NumeroAgencia AND VP.NumeroVentaProducto = VPA.NumeroVentaProducto
			  INNER JOIN Productos P ON P.CodigoProducto = VPA.CodigoProducto '
	SET @W = 'WHERE VP.NumeroAgencia = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' AND VP.NumeroVentaProducto = '+ RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000)))
	SET @GB = 'GROUP BY VPA.CodigoProducto, P.NombreProducto
			   HAVING COUNT(VPA.CodigoProducto) > dbo.ObtenerCantidadTotalDevuelta_deProducto(VPA.CodigoProducto,'+ RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))) +',''V'')'
	IF @CodigoAmbitoBusqueda = '0' 
		SET @Condicion = 'VPA.CodigoProducto ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '1' 
		SET @Condicion = 'VPA.CodigoProductoEspecifico ' + @OperadorComparacion + @TextoABuscarOptimizado
END
ELSE IF (@TipoTransaccion = 'D') -- SI ES PARA DEVOLUCIONES
BEGIN
	SET @S = 'SELECT VPRD.CodigoProducto, P.CodigoProducto, VPRD.CantidadDevuelta AS Cantidad, VPRD.PrecioUnitarioReemplazo AS PrecioUnitario, VPRD.TiempoGarantia, dbo.EsProductoEspecifico('+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+',VPRD.CodigoProducto) as EsProductoEspecifico, VPRD.CantidadDevuelta - dbo.ObtenerCantidadTotalDevuelta_deProducto(VPRD.CodigoProducto,'+ RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))) +',''D'' ) AS LimiteCantidadPosibleDevolucion '
	SET @F = 'FROM VentasProductosReemplazoDetalle VPRD INNER JOIN Productos P ON VPRD.CodigoProducto = P.CodigoProducto'
	SET @W = 'WHERE VPRD.CantidadDevuelta > dbo.ObtenerCantidadTotalDevuelta_deProducto(VPRD.CodigoProducto, '+ RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))) +',''D'') AND VPRV.NumeroAgencia = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' AND VPRV.NumeroReemDevo = '+ RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000)))
	IF @CodigoAmbitoBusqueda = '0' 
		SET @Condicion = 'VPERD.CodigoProductoDevo ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '1' 
		SET @Condicion = 'VPERD.CodigoProductoEspeDevo ' + @OperadorComparacion + @TextoABuscarOptimizado

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

--EXEC BuscarProductoTransaccionVentaDevolucion 1,6,'0','','V',0
--EXEC BuscarProductoTransaccionVentaDevolucion 1,2,'2','','D',1

