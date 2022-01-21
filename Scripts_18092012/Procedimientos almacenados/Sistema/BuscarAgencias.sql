USE Doblones20

DROP PROCEDURE BuscarAgencias
GO

CREATE PROCEDURE BuscarAgencias
@CodigoAmbitoBusqueda CHAR(1),
@TextoABuscar VARCHAR(160),
@ExactamenteIgual BIT

AS
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

SET @S = 'SELECT A.NumeroAgencia, A.NombreAgencia, A.CodigoPais, A.CodigoDepartamento, A.CodigoProvincia, A.CodigoLugar, A.DireccionAgencia, A.NITAgencia, A.NumeroSiguienteFactura, A.NumeroAutorizacion, A.DIResponsable, A.NumeroAgenciaSuperior'
SET @F = 'FROM Agencias A'
SET @W = ''
SET @AUX = ' '

--'0' -> Numero agencia
--'1' -> Nombre agencia
--'2' -> Dirección
--'3' -> NIT agencia

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
	SET @W = 'WHERE A.NumeroAgencia ' + @OperadorComparacion + @TextoABuscar
ELSE IF @CodigoAmbitoBusqueda = '1'
	SET @W = 'WHERE A.NombreAgencia ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '2'
	SET @W = 'WHERE A.DireccionAgencia ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '3'
	SET @W = 'WHERE A.NITAgencia ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE
	SET @W = ' '

SET @ScriptSQL  = LTRIM(RTRIM(LTRIM(RTRIM(@S)) + ' ' + LTRIM(RTRIM(@F)) + ' ' +  LTRIM(RTRIM(@W))))
PRINT @ScriptSQL

EXEC(@ScriptSQL)


GO
