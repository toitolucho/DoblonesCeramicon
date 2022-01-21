USE DOBLONES20

DROP PROCEDURE BuscarVentaProducto
GO

CREATE PROCEDURE BuscarVentaProducto
@CodigoAmbitoBusqueda	CHAR(1),
@TextoABuscar			VARCHAR(160),
@NumeroAgencia			INT,
@NumeroTransaccion		INT,
@CodigoEstadoVenta		CHAR(1),
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

	SET @S = 'SELECT DISTINCT VP.NumeroAgencia, VP.NumeroVentaProducto, VP.FechaHoraVenta , C.NombreCliente, VP.CodigoEstadoVenta, CAST(VP.Observaciones as nvarchar(4000)) as Observaciones, CAST(ISNULL(NumeroFactura,0)  AS BIT) AS ConFactura, M.NombreMoneda, CASE(VP.CodigoEstadoVenta) WHEN ''I'' THEN ''INICIADA'' WHEN ''P''THEN ''PAGADA'' WHEN ''F'' THEN ''FINALIZADA'' WHEN ''A'' THEN ''ANULADA'' WHEN ''T'' THEN ''ENTREGA DIRECTA INST'' WHEN ''C'' THEN ''EN CONFIANZA'' WHEN ''D'' THEN ''PENDIENTE'' WHEN ''E'' THEN ''EN ESPERA'' END AS EstadoVenta, CASE(VP.CodigoTipoVenta) WHEN ''N'' THEN ''VENTA NORMAL'' WHEN ''T'' THEN ''VENTA INSTITUCIONAL'' END AS TipoVenta,  VP.CodigoTipoVenta, CAST(ISNULL(VP.NumeroCredito, 0) AS BIT) AS NumeroCredito, CASE(CAST(ISNULL(VP.NumeroFactura, -2) AS VARCHAR(4000))) WHEN ''-1'' THEN ''Factura en Espera'' WHEN ''-2'' THEN ''Sin Factura'' ELSE CAST(VP.NumeroFactura AS VARCHAR(4000)) END AS NumeroFactura '
	SET @F = 'FROM VentasProductos VP INNER JOIN VentasProductosDetalle VPD ON VP.NumeroAgencia = VPD.NumeroAgencia AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto	
					INNER JOIN Productos P ON VPD.CodigoProducto = P.CodigoProducto
					INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente
					INNER JOIN Monedas M ON M.CodigoMoneda = VP.CodigoMoneda'
	SET @W = 'WHERE VP.NumeroAgencia = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' AND VP.NumeroVentaProducto LIKE '+ ISNULL(RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))),'''%''')+' AND (Cast(Floor(Cast(VP.FechaHoraVenta As Float)) As DateTime) BETWEEN  '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''') '
	IF(@CodigoEstadoVenta IS NOT NULL)
	BEGIN
		IF(@CodigoEstadoVenta = 'E') -- Ventas Productos Pendientes de entrega o en Espera de Entrega
			SET @W = @W + ' AND ( VP.CodigoEstadoVenta = ''P'' AND VPD.CantidadVenta <> VPD.CantidadEntregada) OR (VP.CodigoEstadoVenta = ''T'' AND VPD.CantidadVenta <> VPD.CantidadEntregada) OR (VP.CodigoEstadoVenta = ''D'') OR (VP.CodigoEstadoVenta = ''E'')'
		ELSE
			SET @W = @W + ' AND ( VP.CodigoEstadoVenta = ''' + @CodigoEstadoVenta + ''')'
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
	SET @Condicion = 'C.NombreCliente ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '1' 
	SET @Condicion = 'C.NITCliente ' + @OperadorComparacion + @TextoABuscarOptimizado


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
	SET @NombreCampo = ' VP.Observaciones '
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


GO

--exec BuscarVentaProducto 0,' ',1,null,'P','10/01/09','31/02/2010',0
--exec BuscarTransaccionGC 0,'',1,null,'P','10/10/09','30/11/09',0

--select isnull(CAST(null as varchar(30)),'''%''')
--select isnull(CAST(342 as varchar(30)),'%')

--select * from VentasProductos
--where NumeroVentaProducto like %

