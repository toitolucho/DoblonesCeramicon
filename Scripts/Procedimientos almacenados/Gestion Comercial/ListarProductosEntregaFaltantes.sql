USE Doblones20
GO


DROP PROCEDURE ListarProductosEntregaFaltantes
GO

CREATE PROCEDURE ListarProductosEntregaFaltantes
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT
AS
BEGIN
	SELECT	IAD.CodigoProducto, dbo.ObtenerNombreProducto(IAD.CodigoProducto) AS NombreProducto,
			IAD.CantidadVenta, ISNULL(IACR.CantidadEntregada,0) AS CantidadEntregada, 
			(IAD.CantidadVenta - ISNULL(IACR.CantidadEntregada,0)) AS CantidadFaltante,
			dbo.EsProductoEspecifico(IAD.NumeroAgencia, IAD.CodigoProducto) as EsProductoEspecifico,
			IAD.PrecioUnitarioVenta
	FROM VentasProductosDetalle IAD
	LEFT JOIN
	(
	SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, SUM(CantidadEntregada) AS CantidadEntregada
	FROM VentasProductosDetalleEntrega
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
	GROUP BY NumeroAgencia, NumeroVentaProducto, CodigoProducto
	) IACR
	ON IAD.NumeroAgencia = IACR.NumeroAgencia
	AND IAD.NumeroVentaProducto = IACR.NumeroVentaProducto
	AND IAD.CodigoProducto = IACR.CodigoProducto
	WHERE IAD.CantidadVenta <> ISNULL(IACR.CantidadEntregada,0)
	AND IAD.NumeroAgencia = @NumeroAgencia
	AND IAD.NumeroVentaProducto = @NumeroVentaProducto
END
exec dbo.ObtenerExistenciaProductoInventario 