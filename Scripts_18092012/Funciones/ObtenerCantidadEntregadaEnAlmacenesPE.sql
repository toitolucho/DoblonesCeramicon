DROP FUNCTION ObtenerCantidadEntregadaEnAlmacenesPE
GO

--retorna la cantidad de productos especificos que se estan entregando 
--en caso  de que la entrega de la venta se realize por partes
CREATE FUNCTION ObtenerCantidadEntregadaEnAlmacenesPE (@NumeroAgencia INT, @NumeroVentaProducto INT, @CodigoProducto CHAR(15))
RETURNS INT
AS
BEGIN	
	DECLARE @Cantidad INT = 0
	SELECT @Cantidad = COUNT(*)
	FROM VentasProductosEspecificos VPE	
	WHERE VPE.NumeroAgencia = @NumeroAgencia AND VPE.NumeroVentaProducto = @NumeroVentaProducto AND VPE.CodigoProducto = @CodigoProducto
	AND VPE.Entregado = 0
	IF(@cantidad IS NULL)
		SET @Cantidad = 0
	return @Cantidad
END
GO