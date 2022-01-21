USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.EsPosibleIniciarDevolucionDeUnaCompra', N'FN') IS NOT NULL
    DROP FUNCTION dbo.EsPosibleIniciarDevolucionDeUnaCompra; 
GO

CREATE FUNCTION dbo.EsPosibleIniciarDevolucionDeUnaCompra (@NumeroAgencia INT, @NumeroCompraProducto INT)
RETURNS BIT
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @EsPosible		BIT = 0
	
	IF( EXISTS (
				SELECT * FROM ComprasProductos
				WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
				AND CodigoEstadoCompra IN('F','X')
				))
	BEGIN
		IF((SELECT DISTINCT ISNULL(SUM(CPDE.CantidadEntregada),0)
			FROM ComprasProductosDetalle CPD
			INNER JOIN ComprasProductosDetalleEntrega CPDE
			ON CPD.NumeroAgencia = CPDE.NumeroAgencia
			AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto
			AND CPD.CodigoProducto = CPDE.CodigoProducto
			WHERE CPD.NumeroCompraProducto = @NumeroCompraProducto
			AND CPD.NumeroAgencia = @NumeroAgencia
			GROUP BY CPDE.NumeroAgencia, CPDE.NumeroCompraProducto
												) > (SELECT ISNULL(SUM(CantidadDevuelta),0)
													FROM ComprasProductosDevolucionesDetalle CPDD 
													INNER JOIN ComprasProductosDevoluciones CPD 
													ON CPD.NumeroAgencia  = CPDD.NumeroAgencia 
													AND CPD.NumeroDevolucion = CPDD.NumeroDevolucion
													WHERE CPD.NumeroAgencia = @NumeroAgencia 
													AND CPD.NumeroCompraProducto = @NumeroCompraProducto 
													AND CPD.CodigoEstadoDevolucion = 'F'))
			SET @EsPosible = 1
		ELSE
			SET @EsPosible = 0
	END
	ELSE
		SET @EsPosible = 0
	
   	RETURN(@EsPosible)
END
GO

--SELECT dbo.EsPosibleIniciarDevolucionDeUnaCompra(1,140)

