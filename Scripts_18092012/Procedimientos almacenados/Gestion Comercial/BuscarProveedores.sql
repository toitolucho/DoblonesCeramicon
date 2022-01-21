USE Doblones20

DROP PROCEDURE BuscarProveedores
GO

CREATE PROCEDURE BuscarProveedores
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

SET @S = 'SELECT Pr.CodigoProveedor, Pr.NombreRazonSocial, Pr.NombreRepresentante, Pr.CodigoTipoProveedor, Pr.NITProveedor, Pr.CodigoBanco, Pr.NumeroCuentaBanco, Pr.CodigoMoneda, Pr.NombreOrdenCheque, Pr.CodigoPais, Pr.CodigoDepartamento, Pr.CodigoProvincia, Pr.CodigoLugar, Pr.Direccion, Pr.Telefono, Pr.Fax, Pr.Casilla, Pr.Email, Pr.Observaciones, Pr.ProveedorActivo, Pr.NumeroAgencia'
SET @F = 'FROM Proveedores Pr'
SET @W = ''
SET @AUX = ' '

--'0' -> Codigo proveedor
--'1' -> Nombre razón social
--'2' -> Nombre representante
--'3' -> NIT proveedor
--'4' -> Nº cuenta banco
--'5' -> Nombre orden cheque
--'6' -> Teléfono


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
	SET @W = 'WHERE Pr.CodigoCliente ' + @OperadorComparacion + @TextoABuscar
ELSE IF @CodigoAmbitoBusqueda = '1'
	SET @W = 'WHERE Pr.NombreRazonSocial ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '2'
	SET @W = 'WHERE Pr.NombreRepresentante ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '3'
	SET @W = 'WHERE Pr.NITProveedor ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '4'
	SET @W = 'WHERE Pr.NumeroCuentaBanco' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '5'
	SET @W = 'WHERE Pr.NombreOrdenCheque ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '6'
	SET @W = 'WHERE Pr.telefono ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '7'
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
			SET @AUX = @AUX + ' NombreRazonSocial LIKE' + '''%' + SUBSTRING(@TextoABuscar, @PosicionInicial, (@PosicionActual - @PosicionInicial)) + '%'''			
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
