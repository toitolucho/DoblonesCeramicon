USE DOBLONES20

IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'BuscarTransferenciaProducto') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE BuscarTransferenciaProducto
	END
GO

CREATE PROCEDURE BuscarTransferenciaProducto
@CodigoAmbitoBusqueda			CHAR(1),
@TextoABuscar					VARCHAR(160),
@NumeroAgencia					INT,
@NumeroTransaccion				INT,
@CodigoEstadoTransferencia		CHAR(1),
@FechaInicio					DATETIME,
@FechaFin						DATETIME,
@ExactamenteIgual				BIT,
@CodigoTipoEnvioRecepcion		CHAR(1)

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
	
	
	SET @S = 'SELECT DISTINCT TP.NumeroAgenciaEmisora, TP.NumeroTransferenciaProducto, TP.FechaHoraTransferencia, A.NombreAgencia, CASE(TP.CodigoEstadoTransferencia) WHEN ''I'' THEN ''INICIADA'' WHEN ''A'' THEN ''ANULADA'' WHEN ''E'' THEN ''ENVIADA Y EMITIDA'' WHEN ''D'' THEN ''PENDIENTE''  WHEN ''F'' THEN ''FINALIZADO Y RECIBIDO'' WHEN ''P'' THEN ''CON GASTOS PAGADOS'' WHEN ''X'' THEN ''FINALIZADA RECEPCION INCOMPLETA'' END AS EstadoTransferencia,  TP.MontoTotalTransferencia, CAST(TP.Observaciones as nvarchar(4000)) as Observaciones, TP.CodigoEstadoTransferencia '
	SET @F = 'FROM TransferenciasProductos TP INNER JOIN TransferenciasProductosDetalle TPD ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
			  INNER JOIN Productos P ON TPD.CodigoProducto = P.CodigoProducto
			  INNER JOIN Agencias A ON A.NumeroAgencia = TP.NumeroAgenciaRecepctora'
	
	IF(@CodigoTipoEnvioRecepcion = 'R')
	BEGIN				--TP.NumeroAgenciaEmisora = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' 
		SET @W = 'WHERE TP.NumeroTransferenciaProducto LIKE '+ ISNULL(RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))),'''%''')+' AND (Cast(Floor(Cast(TP.FechaHoraTransferencia As Float)) As DateTime) BETWEEN  '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''') '
		SET @W += 'AND TP.NumeroAgenciaEmisora IN (SELECT NumeroAgenciaEmisora FROM TransferenciasProductos TP2 WHERE TP2.NumeroAgenciaRecepctora = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' )'		
	END
	ELSE IF(@CodigoTipoEnvioRecepcion = 'E')
		SET @W = 'WHERE TP.NumeroAgenciaEmisora = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' AND TP.NumeroTransferenciaProducto LIKE '+ ISNULL(RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))),'''%''')+' AND (Cast(Floor(Cast(TP.FechaHoraTransferencia As Float)) As DateTime) BETWEEN  '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''') '
	ELSE IF (@CodigoTipoEnvioRecepcion IS NULL OR @CodigoTipoEnvioRecepcion = '')	
		SET @W = 'WHERE (TP.NumeroAgenciaEmisora IN (SELECT NumeroAgenciaEmisora FROM TransferenciasProductos TP2 WHERE TP2.NumeroAgenciaRecepctora = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+') OR TP.NumeroAgenciaEmisora = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100)))) + ' ) AND (TP.NumeroTransferenciaProducto LIKE '+ ISNULL(RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))),'''%''')+' AND (Cast(Floor(Cast(TP.FechaHoraTransferencia As Float)) As DateTime) BETWEEN  '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +'''))  '
	--OR (TP.NumeroAgenciaEmisora =' + RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100)))) + ') '
	IF(@CodigoEstadoTransferencia IS NOT NULL)
	BEGIN
		SET @W = @W + ' AND ( TP.CodigoEstadoTransferencia = ''' + @CodigoEstadoTransferencia + ''')'
	END
SET @AUX = ' '
SET @NombreCampo = ''

--'0' -> Nombre Agencia RealizaTransacción
--'1' -> NIT Agencia RealizaTransacción
--'2' -> Nombre producto
--'3' -> Observaciones de Transferencia

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
	SET @Condicion = 'A.NombreAgencia ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '1' 
	SET @Condicion = 'A.NITAgencia ' + @OperadorComparacion + @TextoABuscarOptimizado


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
	SET @NombreCampo = ' TP.Observaciones '
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
--SELECT DISTINCT TP.NumeroAgenciaEmisora, TP.NumeroTransferenciaProducto, TP.FechaHoraTransferencia, A.NombreAgencia, CASE(TP.CodigoEstadoTransferencia) WHEN 'I' THEN 'INICIADA' WHEN 'A' THEN 'ANULADA' WHEN 'E' THEN 'ENVIADA Y EMITIDA' WHEN 'D' THEN 'PENDIENTE'  WHEN 'F' THEN 'FINALIZADO Y RECIBIDO' WHEN 'P' THEN 'CON GASTOS PAGADOS' WHEN 'X' THEN 'FINALIZADA RECEPCION INCOMPLETA' END AS EstadoTransferencia,  TP.MontoTotalTransferencia, CAST(TP.Observaciones as nvarchar(4000)) as Observaciones, TP.CodigoEstadoTransferencia FROM TransferenciasProductos TP INNER JOIN TransferenciasProductosDetalle TPD ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
--INNER JOIN Productos P ON TPD.CodigoProducto = P.CodigoProducto
--INNER JOIN Agencias A ON A.NumeroAgencia = TP.NumeroAgenciaRecepctora WHERE (TP.NumeroAgenciaEmisora IN (SELECT NumeroAgenciaEmisora FROM TransferenciasProductos TP2 WHERE TP2.NumeroAgenciaRecepctora = 3) OR TP.NumeroAgenciaEmisora = 3 ) AND (TP.NumeroTransferenciaProducto LIKE '%' AND (Cast(Floor(Cast(TP.FechaHoraTransferencia As Float)) As DateTime) BETWEEN  'Ene  1 2010 ' AND 'Oct 26 2010 '))   AND (A.NombreAgencia LIKE'%%')

GO



--DECLARE @FECHA DATETIME =GETDATE()
--SELECT CONVERT(VARCHAR(100), @FECHA, 101), @FECHA --2010-02-26 13:09:23.920
--EXEC BuscarTransferenciaProducto '0', '', 3, NULL, NULL, '20100101 13:09:23.920', '20101026 13:09:23.920',0, null


--CodigoAmbitoBusqueda, TextoABuscar, NumeroAgencia, NumeroTransaccion, CodigoEstadoTransferencia, FechaInicio, FechaFin, ExactamenteIgual

