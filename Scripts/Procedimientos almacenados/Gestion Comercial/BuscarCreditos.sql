USE Doblones20

DROP PROCEDURE BuscarCreditos
GO

CREATE PROCEDURE BuscarCreditos
@CodigoAmbitoBusqueda CHAR(1),
@TextoABuscar VARCHAR(160),
@ExactamenteIgual BIT

AS
DECLARE @S NVARCHAR(2000)
DECLARE @F NVARCHAR(100)
DECLARE @J NVARCHAR(2000)
DECLARE @W NVARCHAR(2000)
DECLARE @AUX NVARCHAR(2000)
DECLARE @ScriptSQL VARCHAR(8000)
DECLARE @PosicionInicial TINYINT
DECLARE @PosicionActual TINYINT
DECLARE @PosicionFinal TINYINT
DECLARE @OperadorComparacion VARCHAR(6)
DECLARE @TextoABuscarOptimizado VARCHAR(170)

/*
NumeroCredito, DIDeudor, DIGarante1, DIGarante2, DIGarante3, DIGarante4, DIGarante5, 
CodigoSistemaAmortizacion, MontoDeuda, CodigoMoneda, CodigoFrecuenciaPago, NumeroPeriodos, InteresAnual, 
InteresAnualMora, FechaPrimerPago, FechaUltimoPago, Observaciones, RegistrarContabilidad, 
NumeroAgenciaSolicitud, CodigoUsuarioSolicitud, FechaHoraSolicitud, 
NumeroAgenciaAutorizacion, CodigoUsuarioAutorizacion, FechaHoraAutorizacion, CodigoAutorizacion, CodigoEstadoCredito
*/
SET @S = 'SELECT C.NumeroCredito, C.DIDeudor, dbo.ObtenerNombreCompleto(C.DIDeudor) AS NombreCompletoDeudor, C.DIGarante1, dbo.ObtenerNombreCompleto(C.DIGarante1) AS NombreCompletoGarante1, C.DIGarante2, dbo.ObtenerNombreCompleto(C.DIGarante2) AS NombreCompletoGarante2, C.DIGarante3, dbo.ObtenerNombreCompleto(C.DIGarante3) AS NombreCompletoGarante3, C.DIGarante4, dbo.ObtenerNombreCompleto(C.DIGarante4) AS NombreCompletoGarante4, C.DIGarante5, dbo.ObtenerNombreCompleto(C.DIGarante5) AS NombreCompletoGarante5, 
C.CodigoSistemaAmortizacion, C.MontoDeuda, M.NombreMoneda, C.CodigoFrecuenciaPago, fp.NombreFrecuenciaPago, C.NumeroPeriodos, C.InteresAnual, C.FechaPrimerPago, C.RegistrarContabilidad, 
C.NumeroAgenciaSolicitud, C.CodigoUsuarioSolicitud, C.FechaHoraSolicitud, 
C.NumeroAgenciaAutorizacion, C.CodigoUsuarioAutorizacion, C.FechaHoraAutorizacion, 
C.CodigoAutorizacion, C.CodigoEstadoCredito, 
 CASE C.CodigoEstadoCredito WHEN ''S'' THEN ''SOLICITADO'' WHEN ''A'' THEN ''AUTORIZADO'' WHEN ''R'' THEN ''RECHAZADO'' WHEN ''P'' THEN ''PAGADO'' WHEN ''V'' THEN ''VIGENTE'' END AS NombreEstadoCredito '
SET @J = 'JOIN Monedas m ON m.CodigoMoneda = c.CodigoMoneda '
SET @J = @J + 'JOIN FrecuenciasPagos fp ON fp.CodigoFrecuenciaPago = c.CodigoFrecuenciaPago '
SET @F = 'FROM Creditos C '
SET @W = ''
SET @AUX = ' '

--'0' ->Numero crédito
--'1' ->Documento Identificatico o Nombre Deudor
--'2' ->Documento Identificatico(s) o Nombre(s) Garante(s)
--'3' ->Fecha hora solicitud
--'4' ->Fecha hora inicio crédito
--'5' ->Fecha hora fin crédito
--'6' ->Estado crédito
 
IF @ExactamenteIgual = 1
BEGIN
	SET @OperadorComparacion = ' = '
	SET @TextoABuscarOptimizado = ' ''' + @TextoABuscar + ''''
END
ELSE
BEGIN
	SET @OperadorComparacion = ' LIKE '
	SET @TextoABuscarOptimizado = ' ''%' + @TextoABuscar + '%'''
END

IF @CodigoAmbitoBusqueda = '0' 
	SET @W = 'WHERE C.NumeroCredito ' + @OperadorComparacion + @TextoABuscar
ELSE IF @CodigoAmbitoBusqueda = '1'
	SET @W = 'WHERE C.DIDeudor ' + @OperadorComparacion + @TextoABuscarOptimizado + ' OR dbo.ObtenerNombreCompleto(C.DIDeudor) ' + @OperadorComparacion + @TextoABuscarOptimizado 
ELSE IF @CodigoAmbitoBusqueda = '2'
	SET @W = 'WHERE C.DIGarante1 ' + @OperadorComparacion + @TextoABuscarOptimizado + ' OR dbo.ObtenerNombreCompleto(C.DIGarante1) ' + @OperadorComparacion + @TextoABuscarOptimizado 
ELSE IF @CodigoAmbitoBusqueda = '3'
	SET @W = 'WHERE dbo.SoloFecha(C.FechaHoraSolicitud) ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '4'
	SET @W = 'WHERE dbo.SoloFecha(C.FechaPrimerPago) ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '5'
	SET @W = 'WHERE WHERE dbo.SoloFecha(C.FechaUltimoPago) ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '6'
BEGIN
	SET @W = 'WHERE C.CodigoEstadoCredito ' + @OperadorComparacion + @TextoABuscarOptimizado
END
ELSE
	SET @W = ' '

SET @ScriptSQL  = LTRIM(RTRIM(LTRIM(RTRIM(@S)) + ' ' + LTRIM(RTRIM(@F)) + ' ' + LTRIM(RTRIM(@J)) + ' ' +  LTRIM(RTRIM(@W))))
PRINT @ScriptSQL

EXEC(@ScriptSQL)


GO
