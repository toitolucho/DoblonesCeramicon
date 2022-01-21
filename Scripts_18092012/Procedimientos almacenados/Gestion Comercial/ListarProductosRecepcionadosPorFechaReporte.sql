USE Doblones20
GO

IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarProductosRecepcionadosPorFechaReporte') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarProductosRecepcionadosPorFechaReporte
	END
GO	

CREATE PROCEDURE ListarProductosRecepcionadosPorFechaReporte
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@FechaRecepcion			DATETIME
AS
BEGIN
	IF(@FechaRecepcion IS NOT NULL)	
	BEGIN
	
		
	
		SELECT CPD.NumeroCompraProducto, CPD.CodigoProducto, dbo.ObtenerNombreProducto(CPD.CodigoProducto) AS NombreProducto, CPDE.FechaHoraEntrega, CPD.CantidadCompra, CPDE.CantidadEntregada, CPD.CantidadCompra - CantidadTotalEntregada AS CantidadFaltante, CPE.CodigoProductoEspecifico 
		FROM 
		(
			SELECT NumeroAgencia, NumeroCompraProducto, CodigoProducto, ISNULL(SUM(CantidadEntregada),0) AS CantidadTotalEntregada
			FROM ComprasProductosDetalleEntrega	
			GROUP BY NumeroAgencia, NumeroCompraProducto, CodigoProducto
		) CPCET
		RIGHT JOIN ComprasProductosDetalle CPD ON CPCET.NumeroAgencia = CPD.NumeroAgencia AND CPD.NumeroCompraProducto = CPCET.NumeroCompraProducto AND CPD.CodigoProducto = CPCET.CodigoProducto
		INNER JOIN ComprasProductosDetalleEntrega CPDE ON CPD.NumeroAgencia = CPDE.NumeroAgencia AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto
		AND CPD.CodigoProducto = CPDE.CodigoProducto
		LEFT JOIN ComprasProductosEspecificos CPE ON CPD.NumeroAgencia = CPE.NumeroAgencia AND CPD.NumeroCompraProducto = CPE.NumeroCompraProducto
		AND CPD.CodigoProducto = CPE.CodigoProducto
		AND CPDE.CodigoProducto = CPE.CodigoProducto AND CPDE.FechaHoraEntrega = CPE.FechaHoraRecepcion
		WHERE CPD.NumeroAgencia = @NumeroAgencia AND CPD.NumeroCompraProducto = @NumeroCompraProducto	
		AND CPDE.FechaHoraEntrega = @FechaRecepcion
	END
	ELSE
	BEGIN
		SELECT CPDE.CodigoProducto, dbo.ObtenerNombreProducto(CPDE.CodigoProducto) AS NombreProducto, CPDE.FechaHoraEntrega, CPD.CantidadCompra, CPDE.CantidadEntregada, CPD.CantidadCompra - CPDE.CantidadEntregada AS CantidadFaltante, CPE.CodigoProductoEspecifico 
		FROM ComprasProductosDetalle CPD
		INNER JOIN ComprasProductosDetalleEntrega CPDE ON CPD.NumeroAgencia = CPDE.NumeroAgencia AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto		
		AND CPD.CodigoProducto = CPDE.CodigoProducto
		LEFT JOIN ComprasProductosEspecificos CPE ON CPDE.NumeroAgencia = CPE.NumeroAgencia AND CPDE.NumeroCompraProducto = CPE.NumeroCompraProducto
		AND CPDE.CodigoProducto = CPE.CodigoProducto AND CPDE.FechaHoraEntrega = CPE.FechaHoraRecepcion
		WHERE CPD.NumeroAgencia = @NumeroAgencia AND CPD.NumeroCompraProducto = @NumeroCompraProducto	
	END
	
END
GO

--exec ListarProductosRecepcionadosPorFechaReporte 1, 10, '20100220 10:08:19.450' --20/02/2010 10:08:19  2010-02-20 10:08:19.450
--exec ListarProductosRecepcionadosPorFechaReporte 1, 7, null

select * from ComprasProductosDetalleEntrega

--select * from ComprasProductosDetalleEntrega
--where NumeroCompraProducto = 7
--order by FechaHoraEntrega
--select * from ComprasProductosEspecificos
--where NumeroCompraProducto = 7
--order by FechaHoraRecepcion, CodigoProductoEspecifico


--SELECT * FROM ComprasProductosDetalleEntrega