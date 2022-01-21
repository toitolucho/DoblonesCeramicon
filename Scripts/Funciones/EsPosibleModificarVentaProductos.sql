USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.EsPosibleModificarVentaProductos', N'FN') IS NOT NULL
    DROP FUNCTION dbo.EsPosibleModificarVentaProductos; 
GO

CREATE FUNCTION dbo.EsPosibleModificarVentaProductos (@NumeroAgencia INT, @NumeroVentaProducto INT)
RETURNS BIT
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @EsPosible			BIT,
			@CodigoTipoCredito	CHAR(1)
	SELECT @CodigoTipoCredito = C.CodigoTipoCredito
	FROM VentasProductos VP
	INNER JOIN Creditos C
	ON VP.NumeroCredito = C.NumeroCredito
	WHERE VP.NumeroAgencia = @NumeroAgencia
	AND VP.NumeroVentaProducto = @NumeroVentaProducto
	AND VP.CodigoEstadoVenta IN ('I','P')
	IF(@CodigoTipoCredito IS NULL)
		SET @EsPosible = 1
	ELSE
		SELECT @EsPosible = CASE WHEN @CodigoTipoCredito = 'L' THEN 1 ELSE 0 END
   	RETURN(@EsPosible)
END
GO

