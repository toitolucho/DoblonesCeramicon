USE DOBLONES20
GO

IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'EsPosibleEnviarTransferencia') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE EsPosibleEnviarTransferencia
	END
GO

--Retorna los Nombres de los Productos que no pueden ser enviados, debido a la inexistencia insuficiente en inventarios
CREATE PROCEDURE dbo.EsPosibleEnviarTransferencia 
	@NumeroAgencia			INT, 
	@ProductoDetalleXML		TEXT,
	@DetalleProductosTexto	VARCHAR(4000) OUTPUT
AS
BEGIN
	DECLARE @punteroXMLProductosDetalle	INT
			
	EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @ProductoDetalleXML
		
		
	IF(EXISTS(
		SELECT PDT.CodigoProducto
		FROM OPENXML (@punteroXMLProductosDetalle, '/TransferenciaProductos/ListarTransferenciaProductosEnviadosRecepcionados',2)
		WITH(	CodigoProducto				VARCHAR(15),
				CantidadTransferencia		INT,
				CantidadRecepcionadaEnviada	INT,
				NuevaCantidad				INT,
				CantidadFaltante			INT			
				) PDT
		INNER JOIN InventariosProductos IP
		ON IP.CodigoProducto = PDT.CodigoProducto
		WHERE PDT.NuevaCantidad > IP.CantidadExistencia --Tomar en cuenta cuando se aplica cantidadMinima(StockMinimo)		
		AND IP.NumeroAgencia = @NumeroAgencia
		)		
	)
	BEGIN
		/*SELECT  @ListadoCodigosEspecificos = COALESCE(@ListadoCodigosEspecificos + ', ', '') + T.CodigoProductoEspecifico
		FROM #mytemp T*/
		
		SELECT @DetalleProductosTexto = COALESCE(@DetalleProductosTexto + ', \r\n', '') + DBO.ObtenerNombreProducto(IP.CodigoProducto)
		FROM OPENXML (@punteroXMLProductosDetalle, '/TransferenciaProductos/ListarTransferenciaProductosEnviadosRecepcionados',2)
		WITH(	CodigoProducto	VARCHAR(15),
				NuevaCantidad	INT				
				) TPD
		INNER JOIN InventariosProductos IP
		ON IP.CodigoProducto = TPD.CodigoProducto
		WHERE TPD.NuevaCantidad > IP.CantidadExistencia --Tomar en cuenta cuando se aplica cantidadMinima(StockMinimo)		
		AND IP.NumeroAgencia = @NumeroAgencia
			
	END
	ELSE
		SET @DetalleProductosTexto = NULL		
	EXEC sp_xml_removedocument @punteroXMLProductosDetalle
		
   	--RETURN(@DetalleProductosTexto)
END
GO



--DECLARE @Texto VARCHAR(4000)
--EXEC dbo.EsPosibleEnviarTransferencia 1,'<TransferenciaProductos>
--  <ListarTransferenciaProductosEnviadosRecepcionados>
--    <CodigoProducto>1              </CodigoProducto>
--    <NombreProducto>PROCESADOR DUAL CORE</NombreProducto>
--    <CantidadTransferencia>4</CantidadTransferencia>
--    <PrecioUnitarioTransferencia>12.16</PrecioUnitarioTransferencia>
--    <CantidadRecepcionadaEnviada>0</CantidadRecepcionadaEnviada>
--    <EsProductoEspecifico>false</EsProductoEspecifico>
--    <NuevaCantidad>4</NuevaCantidad>
--    <CantidadFaltante>4</CantidadFaltante>
--    <Seleccionado>false</Seleccionado>
--  </ListarTransferenciaProductosEnviadosRecepcionados>
--  <ListarTransferenciaProductosEnviadosRecepcionados>
--    <CodigoProducto>10             </CodigoProducto>
--    <NombreProducto>BOTE DE TINTA INK-MATE CIM-41C ROJO (1 LITRO)</NombreProducto>
--    <CantidadTransferencia>4</CantidadTransferencia>
--    <PrecioUnitarioTransferencia>0.18</PrecioUnitarioTransferencia>
--    <CantidadRecepcionadaEnviada>0</CantidadRecepcionadaEnviada>
--    <EsProductoEspecifico>false</EsProductoEspecifico>
--    <NuevaCantidad>4</NuevaCantidad>
--    <CantidadFaltante>4</CantidadFaltante>
--    <Seleccionado>false</Seleccionado>
--  </ListarTransferenciaProductosEnviadosRecepcionados>
--  <ListarTransferenciaProductosEnviadosRecepcionados>
--    <CodigoProducto>100            </CodigoProducto>
--    <NombreProducto>MOUSE TARGUS MINI RETRACTIL MOD-AMU1802US</NombreProducto>
--    <CantidadTransferencia>4</CantidadTransferencia>
--    <PrecioUnitarioTransferencia>17.91</PrecioUnitarioTransferencia>
--    <CantidadRecepcionadaEnviada>0</CantidadRecepcionadaEnviada>
--    <EsProductoEspecifico>false</EsProductoEspecifico>
--    <NuevaCantidad>4</NuevaCantidad>
--    <CantidadFaltante>4</CantidadFaltante>
--    <Seleccionado>false</Seleccionado>
--  </ListarTransferenciaProductosEnviadosRecepcionados>
--</TransferenciaProductos>',@Texto OUTPUT

--PRINT @Texto