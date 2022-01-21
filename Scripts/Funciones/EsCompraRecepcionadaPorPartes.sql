
USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.EsCompraRecepcionadaPorPartes', N'FN') IS NOT NULL
    DROP FUNCTION dbo.EsCompraRecepcionadaPorPartes; 
GO

CREATE FUNCTION dbo.EsCompraRecepcionadaPorPartes (@NumeroAgencia INT, @NumeroCompraProducto INT)
RETURNS BIT
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @EsPorPartes		BIT
	
	IF(EXISTS(
				SELECT * FROM ComprasProductosDetalle CPD
				LEFT JOIN ComprasProductosDetalleEntrega CPDE
				ON CPDE.NumeroAgencia = CPD.NumeroAgencia AND CPDE.NumeroCompraProducto = CPD.NumeroCompraProducto
				AND CPD.CantidadCompra <> CPDE.CantidadEntregada
				WHERE CPD.NumeroAgencia = @NumeroAgencia AND CPD.NumeroCompraProducto = @NumeroCompraProducto
			))
		SET @EsPorPartes = 1
	ELSE
		SET @EsPorPartes = 0

   	RETURN(@EsPorPartes)
END
GO

