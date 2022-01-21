USE Doblones20

DROP PROCEDURE BuscarUsuarios
GO

CREATE PROCEDURE BuscarUsuarios
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

SET @S = 'SELECT U.CodigoUsuario, U.NombreUsuario, U.Contrasena, U.DIUsuario, U.Paterno, U.Materno, U.Nombres, U.FechaNacimiento, U.Sexo, U.Celular, U.Email, U.Direccion, U.Telefono, U.RutaArchivoHuellaDactilar, U.RutaArchivoFotografia, U.RutaArchivoFirma, U.Observaciones'	
SET @F = 'FROM Usuarios U'
SET @W = ''
SET @AUX = ' '
-- 0-> Codigo usuario
-- 1-> Nombre de usuario (login)
-- 2-> Cédula de identidad
-- 3-> Nombre (A.Paterno, A. Materno, Nombre(s)

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
	SET @W = 'WHERE U.CodigoUsuario ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '1'
	SET @W = 'WHERE U.NombreUsuario ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '2'
	SET @W = 'WHERE U.DIUsuario ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE IF @CodigoAmbitoBusqueda = '3'
	SET @W = 'WHERE U.Paterno ' + @OperadorComparacion + @TextoABuscarOptimizado + ' OR U.Materno ' + @OperadorComparacion + @TextoABuscarOptimizado + ' OR U.Nombres ' + @OperadorComparacion + @TextoABuscarOptimizado
ELSE
	SET @W = ' '

SET @ScriptSQL  = LTRIM(RTRIM(LTRIM(RTRIM(@S)) + ' ' + LTRIM(RTRIM(@F)) + ' ' +  LTRIM(RTRIM(@W))))

PRINT @ScriptSQL

EXEC(@ScriptSQL)



GO
