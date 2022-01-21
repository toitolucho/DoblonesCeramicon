USE Doblones20
GO

DROP PROCEDURE ObtenerCantidadCodigosEspcificosInventariados
GO

CREATE PROCEDURE ObtenerCantidadCodigosEspcificosInventariados
	@NumeroAgencia	INT,
	@CodigoProducto	CHAR(15),
	@Cantidad		INT	OUTPUT
AS

BEGIN
	SELECT @Cantidad = COUNT(@CodigoProducto)
	FROM InventariosProductosEspecificos
	WHERE CodigoProducto = @CodigoProducto
	AND CodigoEstado = 'A'
END	
GO


DECLARE @CANT INT
EXEC ObtenerCantidadCodigosEspcificosInventariados 1,'204', @CANT OUTPUT
SELECT @CANT
SELECT CantidadExistencia FROM InventariosProductos WHERE CodigoProducto = '204'

SELECT * FROM InventariosProductosEspecificos