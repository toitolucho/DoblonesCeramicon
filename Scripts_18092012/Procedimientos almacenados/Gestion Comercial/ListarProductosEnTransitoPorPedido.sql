USE Doblones20
GO

DROP PROCEDURE ListarProductosEnTransitoPorPedido
GO

CREATE PROCEDURE ListarProductosEnTransitoPorPedido
	@NumeroAgencia	INT
AS
BEGIN
	SELECT	CP.NumeroAgencia, CP.NumeroCompraProducto, CP.CodigoCompraProducto, CP.Fecha, CP.FechaHoraEnvioMercaderia, CP.FechaHoraplazoDeRecepcion, 
			P.CodigoProducto, P.NombreProducto, PM.NombreMarcaProducto, PU.NombreUnidad,
			CPD.CantidadCompra AS CantidadSolicitada, ISNULL(CPDE.CantidadEntregada,0) AS CantidadRecepcionada, 
			CPD.CantidadCompra - ISNULL(CPDE.CantidadEntregada,0) AS CantidadPendiente
	FROM ComprasProductos CP
	INNER JOIN ComprasProductosDetalle CPD
	ON CP.NumeroAgencia = CPD.NumeroAgencia
	AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
	LEFT JOIN ComprasProductosDetalleEntrega CPDE
	ON CPD.NumeroCompraProducto =  CPDE.NumeroCompraProducto
	AND CPD.NumeroAgencia  = CPDE.NumeroAgencia
	AND CPD.CodigoProducto = CPDE.CodigoProducto
	INNER JOIN Productos P
	ON P.CodigoProducto = CPD.CodigoProducto
	INNER JOIN ProductosMarcas PM
	ON P.CodigoMarcaProducto = PM.CodigoMarcaProducto
	INNER JOIN ProductosUnidades PU
	ON PU.CodigoUnidad = P.CodigoUnidad
	WHERE CP.CodigoEstadoCompra IN ('P','D')
	AND CPD.CantidadCompra <> ISNULL(CPDE.CantidadEntregada,0)
	AND CPD.NumeroAgencia = @NumeroAgencia
END
GO


--SELECT * 
--FROM InventarioMercaderiaEnTransito