USE Doblones20
GO

DROP FUNCTION ObtenerPrecioMinimoDeProducto
GO

CREATE FUNCTION ObtenerPrecioMinimoDeProducto(@NumeroAgencia INT, @CodigoProducto CHAR(15))
RETURNS DECIMAL(10,2)
AS
BEGIN
	DECLARE @PrecioMinimo	DECIMAL(10,2) = 0
	
    SELECT @PrecioMinimo = MIN(ListadoPrecios.Precio)
	from
	(
		SELECT Precio = PrecioUnitarioVenta1 FROM InventariosProductos  WHERE  CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia union all
		SELECT Precio = PrecioUnitarioVenta2 FROM InventariosProductos  WHERE  CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia union all
		SELECT Precio = PrecioUnitarioVenta3 FROM InventariosProductos  WHERE  CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia union all
		SELECT Precio = PrecioUnitarioVenta4 FROM InventariosProductos  WHERE  CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia union all
		SELECT Precio = PrecioUnitarioVenta5 FROM InventariosProductos  WHERE  CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia union all
		SELECT Precio = PrecioUnitarioVenta6 FROM InventariosProductos  WHERE  CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia
	) ListadoPrecios
	
	RETURN ISNULL(@PrecioMinimo,0)
END 
GO


USE Doblones20
GO

DROP FUNCTION ObtenerPrecioMaximoDeProducto
GO

CREATE FUNCTION ObtenerPrecioMaximoDeProducto(@NumeroAgencia INT, @CodigoProducto CHAR(15))
RETURNS DECIMAL(10,2)
AS
BEGIN
	DECLARE @PrecioMaximo	DECIMAL(10,2) = 0
	
    SELECT @PrecioMaximo = MAX(ListadoPrecios.Precio)
	from
	(
		SELECT Precio = PrecioUnitarioVenta1 FROM InventariosProductos  WHERE  CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia union all
		SELECT Precio = PrecioUnitarioVenta2 FROM InventariosProductos  WHERE  CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia union all
		SELECT Precio = PrecioUnitarioVenta3 FROM InventariosProductos  WHERE  CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia union all
		SELECT Precio = PrecioUnitarioVenta4 FROM InventariosProductos  WHERE  CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia union all
		SELECT Precio = PrecioUnitarioVenta5 FROM InventariosProductos  WHERE  CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia union all
		SELECT Precio = PrecioUnitarioVenta6 FROM InventariosProductos  WHERE  CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia
	) ListadoPrecios
	
	RETURN ISNULL(@PrecioMaximo,0)
END 
GO
--
--select CodigoProducto, PrecioUnitarioVenta1, PrecioUnitarioVenta2, PrecioUnitarioVenta3, PrecioUnitarioVenta4, PrecioUnitarioVenta5, PrecioUnitarioVenta6, dbo.ObtenerPrecioMinimoDeProducto(1,CodigoProducto) as PrecioMinimo, dbo.ObtenerPrecioMaximoDeProducto(1,CodigoProducto) as PrecioMaximo
--from InventariosProductos