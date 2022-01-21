USE Doblones20
GO

DROP PROCEDURE BuscarCreditoParaVenta
GO

CREATE PROCEDURE BuscarCreditoParaVenta
@CodigoAmbitoBusqueda CHAR(1),
@TextoABuscar VARCHAR(160),
@ExactamenteIgual BIT
AS
BEGIN
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
	
	SET @S = 'SELECT Cl.CodigoCliente, Cl.NombreCliente, Cl.NombreRepresentante, Cl.CodigoTipoCliente, Cl.NITCliente, Cl.CodigoPais, Cl.CodigoDepartamento, Cl.CodigoProvincia, Cl.CodigoLugar, Cl.Direccion, Cl.Telefono, Cl.Email, Cl.Observaciones, Cl.CodigoEstadoCliente, Cl.NumeroAgencia'
	SET @F = 'FROM Clientes Cl'
	SET @W = ''
	SET @AUX = ' '

	--'0' -> Codigo cliente
	--'1' ->Nombre cliente
	--'2' ->Nombre representante
	--'3' ->NIT Cliente
	--'4' ->Teléfono
	--'5' ->Parte Nombre cliente
	 
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
		SET @W = 'WHERE Cl.CodigoCliente ' + @OperadorComparacion + @TextoABuscar
	ELSE IF @CodigoAmbitoBusqueda = '1'
		SET @W = 'WHERE Cl.NombreCliente ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '2'
		SET @W = 'WHERE Cl.NombreRepresentante ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '3'
		SET @W = 'WHERE Cl.NITCliente ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '4'
		SET @W = 'WHERE Cl.telefono ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '5'
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
				SET @AUX = @AUX + ' NombreCliente LIKE' + '''%' + SUBSTRING(@TextoABuscar, @PosicionInicial, (@PosicionActual - @PosicionInicial)) + '%'''			
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
	
END