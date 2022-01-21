USE Doblones20;
GO
SET NOCOUNT ON;

DECLARE @NumeroAgencia					INT, 
		@NumeroCotizacionVentaProducto	INT,
		@FechaHoraCotizacion			DATETIME,
		@ConFactura						BIT,
		@CodigoMonedaCotizacionVenta	TINYINT,
		@FactorCambioCotizacion			DECIMAL(10,2)


DECLARE Cursor_Actualizador_PreciosProductos CURSOR FOR 
SELECT NumeroAgencia, NumeroCotizacionVentaProducto, FechaHoraCotizacion, ConFactura, CodigoMonedaCotizacionVenta
FROM dbo.CotizacionVentasProductos


	
OPEN Cursor_Actualizador_PreciosProductos;

FETCH NEXT FROM Cursor_Actualizador_PreciosProductos 
INTO @NumeroAgencia, @NumeroCotizacionVentaProducto, @FechaHoraCotizacion, @ConFactura, @CodigoMonedaCotizacionVenta

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT ' ';
    
    --SELECT * FROM CotizacionVentasProductos
    
    --SELECT DBO.ObtenerFactorCambioCotizacion2(2, NULL, 1)
    
    IF(@CodigoMonedaCotizacionVenta <> 2) --SI NO ES DOLARES
    BEGIN	
		EXEC DBO.ObtenerFactorCambioCotizacion 2, @FechaHoraCotizacion, @CodigoMonedaCotizacionVenta, @FactorCambioCotizacion OUTPUT
		IF(@FactorCambioCotizacion = -1)
			EXEC DBO.ObtenerFactorCambioCotizacion 2, NULL, @CodigoMonedaCotizacionVenta, @FactorCambioCotizacion OUTPUT		
		
	    UPDATE CotizacionVentasProductosDeta
			SET PrecioUnitarioCotizacionOtraMoneda = PrecioUnitarioCotizacionVenta * @FactorCambioCotizacion
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
    END
    ELSE
    BEGIN
		UPDATE CotizacionVentasProductosDeta
			SET PrecioUnitarioCotizacionOtraMoneda = PrecioUnitarioCotizacionVenta
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
    END
        
    
        -- Get the next vendor.
    FETCH NEXT FROM Cursor_Actualizador_PreciosProductos 
    INTO @NumeroAgencia, @NumeroCotizacionVentaProducto, @FechaHoraCotizacion, @ConFactura, @CodigoMonedaCotizacionVenta
END
CLOSE Cursor_Actualizador_PreciosProductos;
DEALLOCATE Cursor_Actualizador_PreciosProductos;


