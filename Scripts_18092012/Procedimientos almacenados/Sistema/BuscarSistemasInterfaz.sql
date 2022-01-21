USE Doblones20

DROP PROCEDURE BuscarSistemasInterfaz
GO

CREATE PROCEDURE BuscarSistemasInterfaz
@CodigoAmbitoBusqueda CHAR(1),
@TextoABuscar VARCHAR(160),
@ExactamenteIgual BIT

AS
DECLARE @S NVARCHAR(2000)
DECLARE @F NVARCHAR(100)
DECLARE @W NVARCHAR(3000)
DECLARE @AUX NVARCHAR(2000)
DECLARE @ScriptSQL VARCHAR(8000)
DECLARE @PosicionInicial TINYINT
DECLARE @PosicionActual TINYINT
DECLARE @PosicionFinal TINYINT
DECLARE @OperadorComparacion VARCHAR(4)
DECLARE @TextoABuscarOptimizado VARCHAR(170)

SET @S = 'SELECT CodigoInterface, NombreInterface, TextoInterface, CodigoTipoInterface'
SET @F = 'FROM dbo.SistemaInterfaces '
SET @W = ''
SET @AUX = ' '

--'0' -> CodigoInterface
--'1' ->NombreInterface
--'2' ->TextoInterface
--'3' ->CodigoTipoInterface

IF @ExactamenteIgual = 1
BEGIN
	SET @OperadorComparacion = '= '
	SET @TextoABuscarOptimizado = '''' + @TextoABuscar + ''''
END
ELSE
BEGIN
	SET @OperadorComparacion = 'LIKE '
	SET @TextoABuscarOptimizado = '''%' + @TextoABuscar + '%'''
END

IF @CodigoAmbitoBusqueda = '0' 
	SET @W = 'WHERE CodigoInterface ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '3'
	SET @W = 'WHERE CodigoTipoInterface ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '1'
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
			SET @AUX = @AUX + ' NombreInterface LIKE' + '''%' + SUBSTRING(@TextoABuscar, @PosicionInicial, (@PosicionActual - @PosicionInicial)) + '%'''			
			SET @PosicionInicial = @PosicionActual + 1
		END
	END

	SET @W = 'WHERE ' + LTRIM(RTRIM(@AUX))
END
ELSE IF @CodigoAmbitoBusqueda = '2'
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
			SET @AUX = @AUX + ' TextoInterface LIKE' + '''%' + SUBSTRING(@TextoABuscar, @PosicionInicial, (@PosicionActual - @PosicionInicial)) + '%'''			
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


exec BuscarSistemasInterfaz '3','',0
