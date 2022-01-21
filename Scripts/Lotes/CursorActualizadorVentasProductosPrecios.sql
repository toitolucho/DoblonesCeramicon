USE Doblones20;
GO
SET NOCOUNT ON;

DECLARE @NumeroAgencia			INT, 
		@NumeroVentaProducto	INT,
		@FechaHoraVenta			DATETIME,
		@NumeroFactura			INT,
		@CodigoMoneda			TINYINT,
		@FactorCambioCotizacion	DECIMAL(10,2)


DECLARE Cursor_Actualizador_VentasProductosPrecios CURSOR FOR 
SELECT NumeroAgencia, NumeroVentaProducto, FechaHoraVenta, NumeroFactura, CodigoMoneda
FROM dbo.VentasProductos


	
OPEN Cursor_Actualizador_VentasProductosPrecios;

FETCH NEXT FROM Cursor_Actualizador_VentasProductosPrecios 
INTO @NumeroAgencia, @NumeroVentaProducto, @FechaHoraVenta, @NumeroFactura, @CodigoMoneda

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT ' ';
    
    --SELECT * FROM VentasProductos
    
    --SELECT DBO.ObtenerFactorCambioCotizacion2(2, NULL, 1)
    
    IF(@CodigoMoneda <> 2) --SI NO ES DOLARES
    BEGIN	
		EXEC DBO.ObtenerFactorCambioCotizacion 2, @FechaHoraVenta, @CodigoMoneda, @FactorCambioCotizacion OUTPUT
		IF(@FactorCambioCotizacion = -1)
			EXEC DBO.ObtenerFactorCambioCotizacion 2, NULL, @CodigoMoneda, @FactorCambioCotizacion OUTPUT		
		
	    UPDATE VentasProductosDetalle
			SET PrecioUnitarioVentaOtraMoneda = PrecioUnitarioVenta * @FactorCambioCotizacion
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroVentaProducto = @NumeroVentaProducto
    END
    ELSE
    BEGIN
		UPDATE VentasProductosDetalle
			SET PrecioUnitarioVentaOtraMoneda = PrecioUnitarioVenta
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroVentaProducto = @NumeroVentaProducto
    END
        
    
        -- Get the next vendor.
    FETCH NEXT FROM Cursor_Actualizador_VentasProductosPrecios 
    INTO @NumeroAgencia, @NumeroVentaProducto, @FechaHoraVenta, @NumeroFactura, @CodigoMoneda
END
CLOSE Cursor_Actualizador_VentasProductosPrecios;
DEALLOCATE Cursor_Actualizador_VentasProductosPrecios;


