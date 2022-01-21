----	@TipoTransaccion
--'V' -> Venta de Productos
--'C' -> Compra de Productos
--'D' -> Devolucion de una Devolucion de Ventas
--@NumeroTransaccion -> De acuerdo al tipo de Transaccion

USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.ObtenerCantidadTotalRealCompradaVendida', N'FN') IS NOT NULL
    DROP FUNCTION dbo.ObtenerCantidadTotalRealCompradaVendida
GO

CREATE FUNCTION dbo.ObtenerCantidadTotalRealCompradaVendida (
		@NumeroAgencia				INT, 
		@NumeroTransaccionProducto	INT, 
		@CodigoProducto				CHAR(15),
		@TipoTransaccion			CHAR(1)
)
	RETURNS INTEGER
	WITH EXECUTE AS CALLER
AS
BEGIN
DECLARE @Cantidad	INT
	SET @Cantidad = 0
	IF(@TipoTransaccion = 'V')
	BEGIN
		SELECT @Cantidad = ISNULL(SUM(VPDE.CantidadEntregada),0)
		FROM VentasProductos VP
		INNER JOIN VentasProductosDetalleEntrega VPDE
		ON VP.NumeroAgencia = VPDE.NumeroAgencia
		AND VP.NumeroVentaProducto = VPDE.NumeroVentaProducto
		WHERE VP.NumeroAgencia = @NumeroAgencia 
		AND VP.NumeroVentaProducto = @NumeroTransaccionProducto
		AND VPDE.CodigoProducto = @CodigoProducto
		AND VP.CodigoEstadoVenta in ('F','C')
		GROUP BY VPDE.NumeroAgencia, VPDE.NumeroVentaProducto, VPDE.CodigoProducto		
	END
	
	IF(@TipoTransaccion = 'C')
	BEGIN		
		SELECT @Cantidad = ISNULL(SUM(CPDE.CantidadEntregada),0)
		FROM ComprasProductos CP
		INNER JOIN ComprasProductosDetalleEntrega CPDE
		ON CP.NumeroAgencia = CPDE.NumeroAgencia
		AND CP.NumeroCompraProducto = CPDE.NumeroCompraProducto			
		WHERE CPDE.NumeroCompraProducto = @NumeroTransaccionProducto
		AND CPDE.NumeroAgencia = @NumeroAgencia
		AND CPDE.CodigoProducto = @CodigoProducto
		and CP.CodigoEstadoCompra in ('F','X')
		GROUP BY CPDE.NumeroAgencia, CPDE.NumeroCompraProducto, CPDE.CodigoProducto

	END
		
	IF(@Cantidad is NULL)
		SET @Cantidad = 0
	RETURN @Cantidad
END
GO

--SELECT dbo.ObtenerCantidadTotalRealCompradaVendida (1,6,'001-TAR-000009','V')
-- 
