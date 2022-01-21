USE Doblones20
GO

DROP PROCEDURE ObtenerMontoTotalRealCobroCompraProductosIncompleta
GO

CREATE PROCEDURE ObtenerMontoTotalRealCobroCompraProductosIncompleta
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@TextoCompraXML			TEXT,
	@MontoTotalDeuda		DECIMAL(10,2) OUTPUT
AS
BEGIN
	
	DECLARE @punteroXMLProductosDetalle INT	
			
	EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @TextoCompraXML
	
	
	--SELECT CPD.CantidadCompra * CPD.PrecioUnitarioCompra AS PrecioReal, (ISNULL(PDE.CantidadRecepcionada, CPD.CantidadCompra) + ISNULL(PDE.NuevaCantidad, 0)) *CPD.PrecioUnitarioCompra as PrecioPagar, (CPD.CantidadCompra * CPD.PrecioUnitarioCompra) - ((ISNULL(PDE.CantidadRecepcionada, CPD.CantidadCompra) + ISNULL(PDE.NuevaCantidad, 0)) *CPD.PrecioUnitarioCompra) as PrecioDiferencia
	--FROM ComprasProductosDetalle CPD
	--LEFT JOIN
	--(
	--	SELECT  CodigoProducto, CantidadCompra, CantidadRecepcionada, NuevaCantidad
	--	FROM    OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalleEntrega',2)
	--			WITH (CodigoProducto		CHAR(15),
	--				  CantidadCompra		INT,
	--				  CantidadRecepcionada	INT,
	--				  NuevaCantidad			INT
	--			)
	--) PDE	
	--ON CPD.CodigoProducto = PDE.CodigoProducto
	--WHERE CPD.NumeroAgencia = @NumeroAgencia
	--AND CPD.NumeroCompraProducto = @NumeroCompraProducto			
	
	
	SELECT @MontoTotalDeuda = SUM((CPD.CantidadCompra * CPD.PrecioUnitarioCompra) - ((ISNULL(PDE.CantidadRecepcionada, CPD.CantidadCompra) + ISNULL(PDE.NuevaCantidad, 0)) *CPD.PrecioUnitarioCompra)) 
	FROM ComprasProductosDetalle CPD
	LEFT JOIN
	(
		SELECT  CodigoProducto, CantidadCompra, CantidadRecepcionada, NuevaCantidad
		FROM    OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalleEntrega',2)
				WITH (CodigoProducto		CHAR(15),
					  CantidadCompra		INT,
					  CantidadRecepcionada	INT,
					  NuevaCantidad			INT
				)
	) PDE	
	ON CPD.CodigoProducto = PDE.CodigoProducto
	WHERE CPD.NumeroAgencia = @NumeroAgencia
	AND CPD.NumeroCompraProducto = @NumeroCompraProducto
				
	EXEC sp_xml_removedocument @punteroXMLProductosDetalle
	
	SET @MontoTotalDeuda = ISNULL(@MontoTotalDeuda,0)
END
GO


DECLARE @MONTO DECIMAL(10,2)

EXEC ObtenerMontoTotalRealCobroCompraProductosIncompleta 1, 165,'
<Productos>
  <ProductosDetalleEntrega>
    <CodigoProducto>001-MOU-000011 </CodigoProducto>
    <CantidadCompra>5</CantidadCompra>
    <CantidadRecepcionada>1</CantidadRecepcionada>
    <CantidadFaltante>2</CantidadFaltante>
    <EsProductoEspecifico>false</EsProductoEspecifico>
    <NuevaCantidad>2</NuevaCantidad>
  </ProductosDetalleEntrega>
</Productos>', @MONTO OUTPUT
SELECT @MONTO

