DROP FUNCTION GenerarCodigoProducto
GO

CREATE FUNCTION GenerarCodigoProducto (@CodigoTipoProducto INT, @NombreProducto VARCHAR(250))
RETURNS CHAR(15)
AS
BEGIN	
	DECLARE @NumeroSiguienteProductoCodigo INT
	DECLARE @ParteCodigoProducto VARCHAR(15)
	DECLARE @CodigoProducto VARCHAR(15)

	SET @ParteCodigoProducto = RIGHT(RTRIM(LTRIM('00' + CAST(@CodigoTipoProducto AS CHAR(3)))), 3) + '-' + LEFT(@NombreProducto, 3) + '-' 
	
	
	SELECT TOP 1 @NumeroSiguienteProductoCodigo = CAST(RIGHT(CodigoProducto, 6) AS INT)
	FROM Doblones2.dbo.Productos
	WHERE LEFT(CodigoProducto, 8) LIKE @ParteCodigoProducto
	ORDER BY 1 DESC
		
	SET @NumeroSiguienteProductoCodigo = ISNULL(@NumeroSiguienteProductoCodigo, 0) +  1
		
		
	SET @CodigoProducto = @ParteCodigoProducto + RIGHT(RTRIM(LTRIM('000000' + CAST(ISNULL(@NumeroSiguienteProductoCodigo,2) AS CHAR(6)))), 6)
	
	RETURN UPPER(@CodigoProducto)
END
GO
