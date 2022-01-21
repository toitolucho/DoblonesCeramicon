USE DOBLONES20
GO

DROP PROCEDURE ListarComprasProductosEspecificosParaCompra
GO

CREATE PROCEDURE ListarComprasProductosEspecificosParaCompra
	@NumeroAgencia	INT,  -- Si es -1, para listar sin filtrado
	@NumeroCompra	INT
AS
BEGIN
	--Listamos todas las Ventas de Productos Especificos para una Determinada Agencia
	IF (@NumeroAgencia >0)
	BEGIN
		SELECT P.NombreProducto AS [Nombre Producto], CPE.CodigoProducto AS [Código], CPE.CodigoProductoEspecifico AS [Código Específico], CPE.TiempoGarantiaPE AS [Tiempo Garantía]
		FROM ComprasProductosEspecificos CPE INNER JOIN Productos P ON P.CodigoProducto = CPE.CodigoProducto		
		WHERE CPE.NumeroAgencia = @NumeroAgencia
			AND CPE.NumeroCompraProducto = @NumeroCompra
		ORDER BY CPE.NumeroAgencia,CPE.NumeroCompraProducto
	END
	--Listamos Absolutamente todas las Ventas de Productos Especificos Realizadas por todas las Agencias
	IF (@NumeroAgencia = -1)
	BEGIN
		SELECT P.NombreProducto AS [Nombre Producto], CPE.CodigoProducto AS [Código], CPE.CodigoProductoEspecifico AS [Código Específico], CPE.TiempoGarantiaPE AS [Tiempo Garantía]
		FROM ComprasProductosEspecificos CPE INNER JOIN Productos P ON P.CodigoProducto = CPE.CodigoProducto		
		ORDER BY CPE.NumeroAgencia,CPE.NumeroCompraProducto
	END
END
