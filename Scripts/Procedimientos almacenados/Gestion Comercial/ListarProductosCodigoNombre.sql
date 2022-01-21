USE DOBLONES20 
GO

DROP PROCEDURE ListarProductosCodigoNombre
GO


CREATE PROCEDURE ListarProductosCodigoNombre
	@esParaVenta BIT
AS
BEGIN
	IF(@esParaVenta = 1)
	BEGIN
		SELECT P.CodigoProducto, P.NombreProducto, IP.PrecioUnitarioVenta3 as Precio
		FROM Productos P INNER JOIN InventariosProductos IP ON P.CodigoProducto = IP.CodigoProducto
		WHERE IP.CantidadExistencia >= 0 	
	END
	ELSE
	BEGIN
		SELECT P.CodigoProducto, P.NombreProducto, IP.PrecioUnitarioCompra as Precio
		FROM Productos P INNER JOIN InventariosProductos IP ON P.CodigoProducto = IP.CodigoProducto
	END
	
END