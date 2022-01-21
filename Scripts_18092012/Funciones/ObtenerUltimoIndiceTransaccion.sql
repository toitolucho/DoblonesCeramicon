USE Doblones20
GO


DROP FUNCTION ObtenerUltimoIndiceTransaccionFuncion 
GO

CREATE FUNCTION ObtenerUltimoIndiceTransaccionFuncion (@CodigoTipoTransaccion CHAR(1), @CodigoEstadoTransaccion CHAR(1))
RETURNS INT
AS
BEGIN	
	DECLARE @UltimoIndice INT = 0
	
	IF(@CodigoTipoTransaccion = 'V')
	BEGIN
		IF(@CodigoEstadoTransaccion IS NULL)
			EXEC dbo.ObtenerUltimoIndiceTabla 'VentasProductos', @UltimoIndice OUTPUT
		ELSE		
			SELECT TOP 1 @UltimoIndice = NumeroVentaProducto
			FROM VentasProductos
			WHERE CodigoEstadoVenta = @CodigoEstadoTransaccion
			ORDER BY NumeroVentaProducto DESC
	END
	ELSE IF(@CodigoTipoTransaccion = 'C')
	BEGIN
		IF(@CodigoEstadoTransaccion IS NULL)
			EXEC dbo.ObtenerUltimoIndiceTabla 'ComprasProductos', @UltimoIndice OUTPUT
		ELSE		
			SELECT TOP 1 @UltimoIndice = NumeroCompraProducto
			FROM ComprasProductos
			WHERE CodigoEstadoCompra = @CodigoEstadoTransaccion
			ORDER BY NumeroCompraProducto DESC
	END
	
	IF(@CodigoTipoTransaccion IS NULL)
		SET @UltimoIndice = -1
	RETURN @UltimoIndice
END
GO

--select dbo.ObtenerUltimoIndiceTransaccionFuncion('V','P')