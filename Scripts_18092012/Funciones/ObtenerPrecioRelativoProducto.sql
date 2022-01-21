USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.ObtenerPrecioRelativoProducto', N'FN') IS NOT NULL
    DROP FUNCTION dbo.ObtenerPrecioRelativoProducto; 
GO

CREATE FUNCTION dbo.ObtenerPrecioRelativoProducto(@NumeroAgencia INT, @CodigoProducto CHAR(15), @TipoPrecioSeleccionado CHAR(1), @PrecioConFactura BIT )
RETURNS DECIMAL(10,2)
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @PrecioUnitarioVenta DECIMAL(10,2) = 0
	IF(@TipoPrecioSeleccionado = '1')
	BEGIN
		IF(@PrecioConFactura = 1)
			SELECT @PrecioUnitarioVenta = PrecioUnitarioVenta4 FROM InventariosProductos
			WHERE CodigoProducto = @CodigoProducto AND NumeroAgencia =@NumeroAgencia
		ELSE
			SELECT @PrecioUnitarioVenta = PrecioUnitarioVenta1 FROM InventariosProductos
			WHERE CodigoProducto = @CodigoProducto AND NumeroAgencia =@NumeroAgencia
	END
	ELSE IF(@TipoPrecioSeleccionado = '2')
	BEGIN
		IF(@PrecioConFactura = 1)
			SELECT @PrecioUnitarioVenta = PrecioUnitarioVenta5 FROM InventariosProductos
			WHERE CodigoProducto = @CodigoProducto AND NumeroAgencia =@NumeroAgencia
		ELSE
			SELECT @PrecioUnitarioVenta = PrecioUnitarioVenta2 FROM InventariosProductos
			WHERE CodigoProducto = @CodigoProducto AND NumeroAgencia =@NumeroAgencia
	END
	ELSE IF(@TipoPrecioSeleccionado = '3')
	BEGIN
		IF(@PrecioConFactura = 1)
			SELECT @PrecioUnitarioVenta = PrecioUnitarioVenta6 FROM InventariosProductos
			WHERE CodigoProducto = @CodigoProducto AND NumeroAgencia =@NumeroAgencia
		ELSE
			SELECT @PrecioUnitarioVenta = PrecioUnitarioVenta3 FROM InventariosProductos
			WHERE CodigoProducto = @CodigoProducto AND NumeroAgencia =@NumeroAgencia
	END
	ELSE		
	BEGIN
		IF(@PrecioConFactura = 1)
			SELECT @PrecioUnitarioVenta = PrecioUnitarioVenta4 FROM InventariosProductos
			WHERE CodigoProducto = @CodigoProducto AND NumeroAgencia =@NumeroAgencia
		ELSE
			SELECT @PrecioUnitarioVenta = PrecioUnitarioVenta1 FROM InventariosProductos
			WHERE CodigoProducto = @CodigoProducto AND NumeroAgencia =@NumeroAgencia
	END
	
	RETURN ISNULL(@PrecioUnitarioVenta, 0)
END
GO

