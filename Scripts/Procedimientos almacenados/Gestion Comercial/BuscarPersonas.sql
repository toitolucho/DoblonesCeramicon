USE Doblones20

DROP PROCEDURE BuscarPersonas
GO

CREATE PROCEDURE BuscarPersonas
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

SET @S = 'SELECT P.DIPersona, dbo.ObtenerNombreCompleto(P.DIPersona) AS NombreCompleto, dbo.ObtenerCargoCompletoParticipante(P.DIPersona) AS CargoCompleto, P.Sexo, P.Celular, P.EMail'
SET @F = 'FROM Personas P'
SET @W = ''
SET @AUX = ' '
-- 0-> Por cedula de identidad
-- 1-> Por apellido paterno
-- 2-> Por apellido materno
-- 3-> Por nombre
-- 4-> Por Parte del nombre completo

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
	SET @W = 'WHERE P.DIPersona ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '1'
	SET @W = 'WHERE P.Paterno ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '2'
	SET @W = 'WHERE P.Materno ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '3'
	SET @W = 'WHERE P.Nombres ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '4'
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
			SET @AUX = @AUX + ' dbo.ObtenerNombreCompleto(P.DIPersona) LIKE' + '''%' + SUBSTRING(@TextoABuscar, @PosicionInicial, (@PosicionActual - @PosicionInicial)) + '%'''			
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
