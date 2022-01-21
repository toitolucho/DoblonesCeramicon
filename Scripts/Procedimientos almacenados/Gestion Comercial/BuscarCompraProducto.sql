USE DOBLONES20

DROP PROCEDURE BuscarCompraProducto
GO

CREATE PROCEDURE BuscarCompraProducto
@CodigoAmbitoBusqueda	CHAR(1),
@TextoABuscar			VARCHAR(160),
@NumeroAgencia			INT,
@NumeroTransaccion		INT,
@CodigoEstadoCompra		CHAR(1),
@FechaInicio			DATETIME,
@FechaFin				DATETIME,
@ExactamenteIgual		BIT

AS
DECLARE @S NVARCHAR(4000)
DECLARE @F VARCHAR(8000)
DECLARE @Condicion NVARCHAR(2000)
DECLARE @W NVARCHAR(4000)
DECLARE @AUX NVARCHAR(2000)
DECLARE @ScriptSQL VARCHAR(8000)
DECLARE @PosicionInicial TINYINT
DECLARE @PosicionActual TINYINT
DECLARE @PosicionFinal TINYINT
DECLARE @OperadorComparacion VARCHAR(4)
DECLARE @TextoABuscarOptimizado VARCHAR(170)
DECLARE @NombreCampo VARCHAR(250)

SET @W = ''

	SET @S = '	SELECT DISTINCT CP.NumeroAgencia, CP.NumeroCompraProducto, 
				CP.Fecha, PR.NombreRazonSocial, CASE(CodigoTipoCompra) 
				WHEN ''E'' THEN ''EFECTIVO'' ELSE ''CREDITO'' END AS TipoCompra, 
				CASE
				WHEN CodigoEstadoCompra = ''I'' THEN ''INICIADA'' 
				WHEN CodigoEstadoCompra = ''A'' THEN ''ANULADA'' 
				WHEN CodigoTipoCompra = ''E'' AND CodigoEstadoCompra = ''P'' THEN ''PAGADA EN TRANSITO'' 
				WHEN CodigoTipoCompra = ''R'' AND CodigoEstadoCompra = ''P'' THEN ''A CREDITO EN TRANSITO'' 
				WHEN CodigoEstadoCompra = ''D'' THEN ''PENDIENTE''  
				WHEN CodigoEstadoCompra = ''F'' THEN ''FINALIZADO Y RECIBIDO''  
				WHEN CodigoEstadoCompra = ''X'' THEN ''FINALIZADO INCOMPLETO'' END AS EstadoCompra , 
				CAST(CP.Observaciones as nvarchar(4000)) as Observaciones, 
				CP.CodigoEstadoCompra, CP.CodigoTipoCompra,
				MontoTotalCompra,  
				CASE WHEN CP.MontoDescuento IS NULL THEN 0 ELSE CP.MontoDescuento END AS MontoDescuento,
				CASE WHEN CodigoTipoCompra =''E'' THEN DBO.ObtenerMontoTotalCuentasCobrosPagos(CP.NumeroAgencia, CP.NumeroCompraProducto, ''E'') 
				ELSE DBO.ObtenerMontoTotalCuentasCobrosPagos(CP.NumeroAgencia, CP.NumeroCompraProducto, ''E'') 
				+ DBO.ObtenerMontoTotalCuentasCobrosPagos(CP.NumeroAgencia, CP.NumeroCuentaPorPagar, ''P'')  END AS MontoCancelado,
				CASE WHEN CodigoTipoCompra =''E'' THEN cp.MontoTotalCompra - DBO.ObtenerMontoTotalCuentasCobrosPagos(CP.NumeroAgencia, CP.NumeroCompraProducto, ''E'') 
				ELSE cp.MontoTotalCompra -(DBO.ObtenerMontoTotalCuentasCobrosPagos(CP.NumeroAgencia, CP.NumeroCompraProducto,''E'') 
				+ DBO.ObtenerMontoTotalCuentasCobrosPagos(CP.NumeroAgencia, CP.NumeroCuentaPorPagar, ''P''))  END AS MontoSaldo, CP.NumeroCuentaPorPagar '
	SET @F = 'FROM ComprasProductos CP INNER JOIN ComprasProductosDetalle CPD ON CP.NumeroAgencia = CPD.NumeroAgencia AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
			  INNER JOIN Productos P ON CPD.CodigoProducto = P.CodigoProducto
			  INNER JOIN Proveedores PR ON PR.CodigoProveedor = CP.CodigoProveedor'
	SET @W = 'WHERE CP.NumeroAgencia = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' 
			  AND CP.NumeroCompraProducto LIKE '+ ISNULL(RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))),'''%''')+' 
			  AND (Cast(Floor(Cast(CP.Fecha As Float)) As DateTime) BETWEEN  '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''') '
	IF(@CodigoEstadoCompra IS NOT NULL)
	BEGIN
		SET @W = @W + ' AND ( CP.CodigoEstadoCompra = ''' + @CodigoEstadoCompra + ''')'
	END
SET @AUX = ' '
SET @NombreCampo = ''

--'0' -> NombrePersonaRealizaTransacción
--'1' -> NITPersonaRealizaTransacción
--'2' -> Nombre producto
--'3' -> Observaciones de Venta

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
	SET @Condicion = 'PR.NombreRazonSocial ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '1' 
	SET @Condicion = 'PR.NITProveedor ' + @OperadorComparacion + @TextoABuscarOptimizado


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


IF (@CodigoAmbitoBusqueda = '3')
BEGIN
	SET @PosicionInicial = 0
	SET @PosicionActual = 0
	SET @PosicionFinal = 0
	SET @NombreCampo = ' CP.Observaciones '
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

SET @ScriptSQL  = LTRIM(RTRIM(LTRIM(RTRIM(@S)) + ' ' + LTRIM(RTRIM(@F)) + ' ' +  LTRIM(RTRIM(@W))))
PRINT @ScriptSQL
EXEC(@ScriptSQL)
--SELECT DISTINCT CP.NumeroAgencia, CP.NumeroCompraProducto, CP.Fecha, PR.NombreRazonSocial, CASE(CodigoTipoCompra) WHEN 'E' THEN 'EFECTIVO' ELSE 'CREDITO' END AS TipoCompra, CASE(CodigoEstadoCompra) WHEN 'I' THEN 'INICIADA' WHEN 'A' THEN 'ANULADA' WHEN 'P' THEN 'PAGADA' WHEN 'D' THEN 'PENDIENTE'  WHEN 'F' THEN 'FINALIZADO Y RECIBIDO' END AS EstadoCompra , MontoTotalCompra,  CAST(CP.Observaciones as nvarchar(4000)) as Observaciones, CP.CodigoEstadoCompra, CP.CodigoTipoCompra FROM ComprasProductos CP INNER JOIN ComprasProductosDetalle CPD ON CP.NumeroAgencia = CPD.NumeroAgencia AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
--INNER JOIN Productos P ON CPD.CodigoProducto = P.CodigoProducto
--INNER JOIN Proveedores PR ON PR.CodigoProveedor = CP.CodigoProveedor 

GO



--DECLARE @FECHA DATETIME =GETDATE()
--SELECT CONVERT(VARCHAR(100), @FECHA, 101)
--EXEC BuscarCompraProducto '1', ' ', 1, NULL, NULL, @FECHA, @FECHA,0
--EXEC BuscarCompraProducto '0', ' ', 1, NULL, NULL, @FECHA, @FECHA,0
--"0", " ", NumeroAgencia,null, null, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0,0,0), DateTime.Now, false


--CodigoAmbitoBusqueda, TextoABuscar, NumeroAgencia, NumeroTransaccion, CodigoEstadoCompra, FechaInicio, FechaFin, ExactamenteIgual