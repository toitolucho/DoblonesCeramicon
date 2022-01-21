USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.ExisteGastosParaCompra', N'FN') IS NOT NULL
    DROP FUNCTION dbo.ExisteGastosParaCompra; 
GO

CREATE FUNCTION dbo.ExisteGastosParaCompra (@NumeroAgencia INT, @NumeroCompraProducto INT)
RETURNS BIT
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @ExisteGastos		BIT
	
	--SELECT @EsProdEspe = IP.EsProductoEspecifico
	--FROM InventariosProductos IP 
	--WHERE IP.CodigoProducto = @CodigoProducto
	IF( EXISTS ( SELECT * FROM dbo.CompraProductosGastosDetalle
				WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto AND  CodigoEstadoGasto = 0))
		SET @ExisteGastos = 1
	ELSE
		SET @ExisteGastos = 0

   	RETURN(@ExisteGastos)
END
GO



