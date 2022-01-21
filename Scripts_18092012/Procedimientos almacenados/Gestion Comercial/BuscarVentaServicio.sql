USE DOBLONES20

DROP PROCEDURE BuscarVentaServicio
GO

CREATE PROCEDURE BuscarVentaServicio
@CodigoAmbitoBusqueda			CHAR(1),
@TextoABuscar					VARCHAR(160),
@NumeroAgencia					INT,
@NumeroTransaccion				INT,
@CodigoEstadoVentaServicio		CHAR(1),
@FechaInicio					DATETIME,
@FechaFin						DATETIME,
@ExactamenteIgual				BIT

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

	SET @S = 'SELECT DISTINCT VS.NumeroAgencia, VS.NumeroVentaServicio, VS.FechaHoraVentaServicio, C.NombreCliente, CASE(vs.CodigoTipoServicio) WHEN ''E'' THEN ''EFECTIVO'' ELSE ''CREDITO'' END AS TipoVenta, CASE(VS.CodigoEstadoServicio) WHEN ''I'' THEN ''INICIADO'' WHEN ''P'' THEN ''PAGADO'' WHEN ''A'' THEN ''ANULADO'' WHEN ''F'' THEN ''FINALIZADO'' WHEN ''C'' THEN ''SERVICIO PARA COTIZACION'' WHEN ''V'' THEN ''SERVICIO PARA VENTAS'' WHEN ''X'' THEN ''FINALIZADO INCOMPLETO'' END AS EstadoVentaServicio, MontoTotal, CAST(VS.Observaciones as nvarchar(4000)) as Observaciones, VS.CodigoEstadoServicio, VS.CodigoTipoServicio '
	SET @F = 'FROM VentasServicios VS
				INNER JOIN VentasServiciosDetalle VSD
				ON VS.NumeroAgencia = VSD.NumeroAgencia
				AND VS.NumeroVentaServicio = VSD.NumeroVentaServicio
				INNER JOIN Servicios S
				ON VSD.CodigoServicio = S.CodigoServicio
				INNER JOIN Clientes C
				ON VS.CodigoCliente = C.CodigoCliente'
	SET @W = 'WHERE VS.NumeroAgencia = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' AND VS.NumeroVentaServicio LIKE '+ ISNULL(RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))),'''%''')+' AND (Cast(Floor(Cast(VS.FechaHoraVentaServicio As Float)) As DateTime) BETWEEN  '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''') '
	IF(@CodigoEstadoVentaServicio IS NOT NULL)
	BEGIN
		SET @W = @W + ' AND ( VS.CodigoEstadoServicio = ''' + @CodigoEstadoVentaServicio + ''')'
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
	SET @NombreCampo = ' S.NombreServicio '
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
	SET @NombreCampo = ' VS.Observaciones '
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


--SELECT DISTINCT VS.NumeroAgencia, VS.NumeroVentaServicio, VS.FechaHoraVentaServicio, C.NombreCliente, CASE(vs.CodigoTipoServicio) WHEN 'E' THEN 'EFECTIVO' ELSE 'CREDITO' END AS TipoVenta, CASE(VS.CodigoEstadoServicio) WHEN 'I' THEN 'INICIADO' WHEN 'P' THEN 'PAGADO' WHEN 'A' THEN 'ANULADO' WHEN 'F' THEN 'FINALIZADO' WHEN 'C' THEN 'SERVICIO PARA COTIZACION' WHEN 'V' THEN 'SERVICIO PARA VENTAS' WHEN 'X' THEN 'FINALIZADO INCOMPLETO' END AS EstadoVentaServicio, MontoTotal, CAST(VS.Observaciones as nvarchar(4000)) as Observaciones, VS.CodigoEstadoServicio, VS.CodigoTipoServicio
--FROM VentasServicios VS
--INNER JOIN VentasServiciosDetalle VSD
--ON VS.NumeroAgencia = VSD.NumeroAgencia
--AND VS.NumeroVentaServicio = VSD.NumeroVentaServicio
--INNER JOIN Servicios S
--ON VSD.CodigoServicio = S.CodigoServicio
--INNER JOIN Clientes C
--ON VS.CodigoCliente = C.CodigoCliente


GO




--EXEC BuscarVentaServicio '0', ' ', 1, NULL, NULL, '01/01/2009', '31/12/2010',0
