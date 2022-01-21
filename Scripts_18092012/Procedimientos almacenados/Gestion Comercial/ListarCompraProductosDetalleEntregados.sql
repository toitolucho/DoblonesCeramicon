USE Doblones20
GO

DROP PROCEDURE ListarCompraProductosDetalleEntregados
GO

CREATE PROCEDURE ListarCompraProductosDetalleEntregados
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@MostrarSoloFaltantes	BIT
AS
BEGIN
	--SELECT CPD.CodigoProducto, dbo.ObtenerNombreProducto(CPD.CodigoProducto) as NombreProducto, CPD.CantidadCompra
	--FROM ComprasProductosDetalle CPD 
	--LEFT JOIN ComprasProductosDetalleEntrega CPDE ON CPD.NumeroAgencia = CPDE.NumeroAgencia AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto
	IF(@MostrarSoloFaltantes = 1)
	BEGIN
		SELECT CPD.CodigoProducto, dbo.ObtenerNombreProducto(CPD.CodigoProducto) AS NombreProducto, CPD.CantidadCompra, ISNULL(CPDE.CantidadRecepcionada,0) AS CantidadRecepcionada, CPD.CantidadCompra - ISNULL(CPDE.CantidadRecepcionada,0) AS CantidadFaltante, dbo.EsProductoEspecifico(@NumeroAgencia, CPD.CodigoProducto) AS EsProductoEspecifico
		FROM 
		(
			SELECT NumeroAgencia, NumeroCompraProducto, CodigoProducto, SUM(CantidadEntregada) AS CantidadRecepcionada
			FROM ComprasProductosDetalleEntrega
			WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
			GROUP BY NumeroAgencia, NumeroCompraProducto, CodigoProducto
		) CPDE RIGHT JOIN ComprasProductosDetalle CPD
		ON CPD.NumeroAgencia = CPDE.NumeroAgencia AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto	
		AND CPD.CodigoProducto = CPDE.CodigoProducto
		WHERE CPD.NumeroAgencia = @NumeroAgencia AND CPD.NumeroCompraProducto = @NumeroCompraProducto
		AND ISNULL(CPDE.CantidadRecepcionada,0) <> CPD.CantidadCompra
	END
	ELSE
	BEGIN
		SELECT CPD.CodigoProducto, dbo.ObtenerNombreProducto(CPD.CodigoProducto) AS NombreProducto, CPD.CantidadCompra, ISNULL(CPDE.CantidadRecepcionada,0) AS CantidadRecepcionada, CPD.CantidadCompra - ISNULL(CPDE.CantidadRecepcionada,0) AS CantidadFaltante, dbo.EsProductoEspecifico(@NumeroAgencia,CPD.CodigoProducto) AS EsProductoEspecifico
		FROM 
		(
			SELECT NumeroAgencia, NumeroCompraProducto, CodigoProducto,  SUM(CantidadEntregada) AS CantidadRecepcionada
			FROM ComprasProductosDetalleEntrega
			WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
			GROUP BY NumeroAgencia, NumeroCompraProducto, CodigoProducto
		) CPDE RIGHT JOIN ComprasProductosDetalle CPD
		ON CPD.NumeroAgencia = CPDE.NumeroAgencia AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto	
		AND CPD.CodigoProducto = CPDE.CodigoProducto
		WHERE CPD.NumeroAgencia = @NumeroAgencia AND CPD.NumeroCompraProducto = @NumeroCompraProducto		
	END
END


--EXEC ListarCompraProductosDetalleEntregados 1,4,1



