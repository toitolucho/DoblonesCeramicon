USE Doblones20
GO

DROP FUNCTION ObtenerNumeroOrdenProducto

GO

CREATE FUNCTION ObtenerNumeroOrdenProducto(@TipoTransaccion CHAR(1))
RETURNS INT
WITH ENCRYPTION
AS
BEGIN
	DECLARE @CodigoGenerado	INT,
			@NumeroAgencia	INT,
			@NumeroTransaccion	INT,
			@CodigoProducto	CHAR(15)	
	IF(@TipoTransaccion = 'V')--VENTAS
	BEGIN
		
		SELECT  TOP(1) @NumeroTransaccion = NumeroVentaProducto
		FROM VentasProductos
		ORDER BY NumeroVentaProducto DESC
		--SET @NumeroTransaccion = IDENT_CURRENT('VentasProductos')
		
		
		
		SELECT @CodigoGenerado = ISNULL(COUNT(*),0) + 1
		FROM VentasProductosDetalle
		WHERE NumeroVentaProducto = @NumeroTransaccion
		
		INSERT INTO TEMPORAL (NumeroAgencia, NumeroTransaccion, CodigoProducto, NumeroGenerado, TipoTransaccion)
		VALUES(1, @NumeroTransaccion, 'A', @CodigoGenerado, 'V')
		
	END
	
	IF(@TipoTransaccion = 'T')--COTIZACIONES
	BEGIN		
		--SET @NumeroTransaccion = IDENT_CURRENT('CotizacionVentasProductos')
		
		SELECT  TOP(1) @NumeroTransaccion = NumeroCotizacionVentaProducto
		FROM CotizacionVentasProductos
		ORDER BY NumeroCotizacionVentaProducto DESC
		
		SELECT @CodigoGenerado = ISNULL(COUNT(*),0) + 1
		FROM CotizacionVentasProductosDeta
		WHERE NumeroCotizacionVentaProducto = @NumeroTransaccion
	END
	
	RETURN ISNULL(@CodigoGenerado,1)
END

GO
