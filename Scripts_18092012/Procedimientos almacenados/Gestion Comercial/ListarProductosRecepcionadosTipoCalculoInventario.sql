USE Doblones20
GO


DROP PROCEDURE ListarProductosRecepcionadosTipoCalculoInventario
GO


CREATE PROCEDURE ListarProductosRecepcionadosTipoCalculoInventario
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@ListadoProductos		VARCHAR(4000)	
AS 
BEGIN
	DECLARE @NumeroAgenciaTexto			VARCHAR(10) = CAST(@NumeroAgencia AS VARCHAR(10)),
			@NumeroCompraProductoTexto	VARCHAR(2000) = CAST(@NumeroCompraProducto AS VARCHAR(2000))
	IF(@ListadoProductos IS NULL OR @ListadoProductos = '' OR LEN(@ListadoProductos) = 0)
	BEGIN --U'->UEPS, 'P'->PEPS, 'O'->Ponderado, 'B'-> Precio mas Bajo, 'A'->Precio mas alto	
		SELECT P.CodigoProducto, P.NombreProducto, CPD.PrecioUnitarioCompra , 
				CASE(P.CodigoTipoCalculoInventario) 
					WHEN 'U' THEN 'UEPS' 
					WHEN 'P' THEN 'PEPS' 
					WHEN 'O' THEN 'PONDERADO' 
					WHEN 'B' THEN 'PRECIO MAS BAJO' 
					WHEN 'A' THEN 'PRECIO MAS ALTO' 
					WHEN 'T' THEN 'ULTIMO PRECIO' END 
				AS CodigoTipoCalculoInventario
		--, CAST(0 as bit) as ActualizarPrecioVenta, CAST(0 as bit) as Promedio, CAST(0 as bit) as UltimaRecepcion, CAST(0 as decimal(10,2)) as MontoGastoProducto
		FROM PRODUCTOS P 
		INNER JOIN ComprasProductosDetalle CPD
		ON P.CodigoProducto = CPD.CodigoProducto
		WHERE CPD.NumeroAgencia = @NumeroAgencia AND 
		CPD.NumeroCompraProducto = @NumeroCompraProducto
	END
	ELSE
	BEGIN		
		EXEC('SELECT P.CodigoProducto, P.NombreProducto, CPD.PrecioUnitarioCompra, CASE(P.CodigoTipoCalculoInventario) WHEN ''U'' THEN ''UEPS'' WHEN ''P'' THEN ''PEPS'' WHEN ''O'' THEN ''PONDERADO'' WHEN ''B'' THEN ''PRECIO MAS BAJO'' WHEN ''A'' THEN ''PRECIO MAS ALTO'' WHEN ''T'' THEN ''ULTIMO PRECIO'' END AS CodigoTipoCalculoInventario
		FROM PRODUCTOS P INNER JOIN ComprasProductosDetalle CPD
		ON P.CodigoProducto = CPD.CodigoProducto
		WHERE CPD.NumeroAgencia = '+ @NumeroAgenciaTexto +' AND CPD.NumeroCompraProducto = '+ @NumeroCompraProductoTexto +'
		AND CPD.CodigoProducto IN (' + @ListadoProductos +')')		
	END
	
END
GO

--select * from prueba

--exec ListarProductosRecepcionadosTipoCalculoInventario 1,1, ' ' ''263'',''463'' ' '
--exec ListarProductosRecepcionadosTipoCalculoInventario 1,1, ' ''263'', ''463'', ''482'' '
--exec ListarProductosRecepcionadosTipoCalculoInventddario 1,1,null


--select * from InventarioProductosCantidadesComprasHistorial
--select * from ComprasProductosDetalleEntrega
--delete from ComprasProductosDetalleEntrega
--where NumeroCompraProducto = 4




DROP PROCEDURE ListarProductosActualizacionNuevosPrecios
GO


CREATE PROCEDURE ListarProductosActualizacionNuevosPrecios
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@ListadoProductos		TEXT,
	@TipoIncrementoPrecio	CHAR(1)--'P'->PERSONALIZADO,'T'->TABLA,'R'->REPARTIDOS(PRORRATEO), 'NULL'->Cuando no hay Gastos
AS 
BEGIN
	DECLARE @TProductosPrecios TABLE
	(
		CodigoProducto			CHAR(15),
		CantidadRecepcion		INT,
		MontoGastoIncremento	DECIMAL(10,2),
		PrecioUnitarioCompra	DECIMAL(10,2)
	)
	
	
	DECLARE @punteroXMLProductosDetalle INT					
	EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @ListadoProductos
	
	INSERT INTO @TProductosPrecios (CodigoProducto,  CantidadRecepcion, MontoGastoIncremento, PrecioUnitarioCompra)
	SELECT	TXML.CodigoProducto,  TXML.CantidadRecepcion, ISNULL(TXML.MontoGastoIncremento,0), TXML.PrecioUnitarioCompra
	FROM OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosHistorial',2)
	WITH (CodigoProducto		VARCHAR(15),
		  CantidadRecepcion		INT,
		  MontoGastoIncremento	DECIMAL(10,2),
		  PrecioUnitarioCompra	DECIMAL(10,2)
	) TXML
	--INNER JOIN ComprasProductosDetalle CPD
	--ON TXML.CodigoProducto = CPD.CodigoProducto
	--AND CPD.NumeroCompraProducto = @NumeroCompraProducto
	--AND CPD.NumeroAgencia = @NumeroAgencia
	
	
	EXEC sp_xml_removedocument @punteroXMLProductosDetalle
	
	declare @filas int
	select @filas =  COUNT(*) from @TProductosPrecios
	print('Filas' + cast(@filas as varchar(10)))
	

	
	SELECT IP.CodigoProducto, P.NombreProducto,
		PPV.PrecioUnitarioCompra, IP.PrecioUnitarioCompraSinGastos,	
		CAST( 
		ISNULL(CASE 
		--PERSONALIZADO
		WHEN ((P.CodigoTipoCalculoInventario = 'U' OR P.CodigoTipoCalculoInventario = 'T')  AND @TipoIncrementoPrecio = 'P') THEN
		(--UEPS Y ULTIMO PRECIO
			PPV.PrecioUnitarioCompra + (PPV.MontoGastoIncremento / PPV.CantidadRecepcion)
		)
		WHEN (P.CodigoTipoCalculoInventario = 'P' AND @TipoIncrementoPrecio = 'P') THEN
		(--PEPS
			SELECT TOP 1 ISNULL(PrecioUnitario,-1)
			FROM InventarioProductosCantidadesComprasHistorial
			WHERE NumeroAgencia = @NumeroAgencia
			AND CodigoProducto = P.CodigoProducto
			ORDER BY FechaHoraIngreso ASC
		)
		WHEN (P.CodigoTipoCalculoInventario = 'O' AND @TipoIncrementoPrecio = 'P') THEN
		(--PONDERADO			
			SELECT ISNULL(AVG(TPAux.PrecioUnitario),-1)
			FROM
			(
				SELECT PrecioUnitario
				FROM InventarioProductosCantidadesComprasHistorial
				WHERE NumeroAgencia = @NumeroAgencia
				AND CodigoProducto = P.CodigoProducto
				UNION ALL
				SELECT PPV.PrecioUnitarioCompra + (PPV.MontoGastoIncremento / PPV.CantidadRecepcion)
				WHERE PPV.CodigoProducto = P.CodigoProducto
				
			)TPAux
			 
		) 
		WHEN (P.CodigoTipoCalculoInventario = 'B' AND @TipoIncrementoPrecio = 'P') THEN
		(--PRECIO MAS BAJO			
			SELECT TOP 1 ISNULL(PrecioUnitario,-1)
			FROM
			(
				SELECT PrecioUnitario
				FROM InventarioProductosCantidadesComprasHistorial
				WHERE NumeroAgencia = @NumeroAgencia
				AND CodigoProducto = P.CodigoProducto
				UNION ALL
				SELECT PPV.PrecioUnitarioCompra + (PPV.MontoGastoIncremento / PPV.CantidadRecepcion)				
				WHERE PPV.CodigoProducto = P.CodigoProducto
			)TPAux
			ORDER BY PrecioUnitario ASC
		) 
		WHEN (P.CodigoTipoCalculoInventario = 'A' AND @TipoIncrementoPrecio = 'P') THEN
		(--PRECIO MAS ALTO			
			SELECT TOP 1 ISNULL(PrecioUnitario,-1)
			FROM
			(
				SELECT PrecioUnitario
				FROM InventarioProductosCantidadesComprasHistorial
				WHERE NumeroAgencia = @NumeroAgencia
				AND CodigoProducto = P.CodigoProducto
				UNION ALL
				SELECT PPV.PrecioUnitarioCompra + (PPV.MontoGastoIncremento / PPV.CantidadRecepcion)				
				WHERE PPV.CodigoProducto = P.CodigoProducto
			)TPAux
			ORDER BY PrecioUnitario DESC
		)
		
		--PRORRATEADO
		WHEN ((P.CodigoTipoCalculoInventario = 'U' OR P.CodigoTipoCalculoInventario = 'T') AND @TipoIncrementoPrecio = 'R') THEN
		(--UEPS Y ULTIMO PRECIO			
			PPV.PrecioUnitarioCompra + PPV.MontoGastoIncremento
		)
		WHEN (P.CodigoTipoCalculoInventario = 'P' AND @TipoIncrementoPrecio = 'R') THEN
		(--PEPS
			SELECT TOP 1 ISNULL(PrecioUnitario,-1)
			FROM InventarioProductosCantidadesComprasHistorial
			WHERE NumeroAgencia = 1
			AND CodigoProducto = P.CodigoProducto
			ORDER BY FechaHoraIngreso ASC
		)
		WHEN (P.CodigoTipoCalculoInventario = 'O' AND @TipoIncrementoPrecio = 'R') THEN
		(--PONDERADO
			SELECT ISNULL(AVG(TPAux.PrecioUnitario),-1)
			FROM
			(
				SELECT PrecioUnitario
				FROM InventarioProductosCantidadesComprasHistorial
				WHERE NumeroAgencia = @NumeroAgencia
				AND CodigoProducto = P.CodigoProducto
				UNION ALL
				SELECT PPV.PrecioUnitarioCompra + PPV.MontoGastoIncremento
				WHERE PPV.CodigoProducto = P.CodigoProducto
			)TPAux
		) 
		WHEN (P.CodigoTipoCalculoInventario = 'B' AND @TipoIncrementoPrecio = 'R') THEN
		(--PRECIO MAS BAJO
			SELECT TOP 1 ISNULL(PrecioUnitario,-1)
			FROM
			(
				SELECT PrecioUnitario
				FROM InventarioProductosCantidadesComprasHistorial
				WHERE NumeroAgencia = @NumeroAgencia
				AND CodigoProducto = P.CodigoProducto
				UNION ALL
				SELECT PPV.PrecioUnitarioCompra + PPV.MontoGastoIncremento 			
				WHERE PPV.CodigoProducto = P.CodigoProducto
			)TPAux
			ORDER BY PrecioUnitario ASC
		) 
		WHEN (P.CodigoTipoCalculoInventario = 'A' AND @TipoIncrementoPrecio = 'R') THEN
		(--PRECIO MAS ALTO
			SELECT TOP 1 ISNULL(PrecioUnitario,-1)
			FROM
			(
				SELECT PrecioUnitario
				FROM InventarioProductosCantidadesComprasHistorial
				WHERE NumeroAgencia = @NumeroAgencia
				AND CodigoProducto = P.CodigoProducto
				UNION ALL
				SELECT PPV.PrecioUnitarioCompra + PPV.MontoGastoIncremento
				WHERE PPV.CodigoProducto = P.CodigoProducto
			)TPAux
			ORDER BY PrecioUnitario DESC
		)
		
		--TABLAS
		WHEN ((P.CodigoTipoCalculoInventario = 'U' OR P.CodigoTipoCalculoInventario = 'T') AND @TipoIncrementoPrecio = 'T') THEN
		(--UEPS Y ULTIMO PRECIO			
			-IP.PrecioUnitarioCompra
		)
		WHEN (P.CodigoTipoCalculoInventario = 'P' AND @TipoIncrementoPrecio = 'T') THEN
		(--PEPS
			SELECT TOP 1 ISNULL(PrecioUnitario,-1)
			FROM InventarioProductosCantidadesComprasHistorial
			WHERE NumeroAgencia = 1
			AND CodigoProducto = P.CodigoProducto
			ORDER BY FechaHoraIngreso ASC
		)
		WHEN (P.CodigoTipoCalculoInventario = 'O' AND @TipoIncrementoPrecio = 'T') THEN
		(--PONDERADO			
			-1
		) 
		WHEN (P.CodigoTipoCalculoInventario = 'B' AND @TipoIncrementoPrecio = 'T') THEN
		(--PRECIO MAS BAJO			
			-1
		) 
		WHEN (P.CodigoTipoCalculoInventario = 'A' AND @TipoIncrementoPrecio = 'T') THEN
		(--PRECIO MAS ALTO			
			-1
		)
			
		ELSE IP.PrecioUnitarioCompra  END, PPV.PrecioUnitarioCompra) AS DECIMAL(10,2)) AS PrecioCompraCalculado,
		IP.PorcentajeUtilidad1, IP.PrecioUnitarioVenta1,
		IP.PorcentajeUtilidad2, IP.PrecioUnitarioVenta2,
		IP.PorcentajeUtilidad3, IP.PrecioUnitarioVenta3,
		IP.PorcentajeUtilidad4, IP.PrecioUnitarioVenta4,
		IP.PorcentajeUtilidad5, IP.PrecioUnitarioVenta5,
		IP.PorcentajeUtilidad6, IP.PrecioUnitarioVenta6,
		CASE(P.CodigoTipoCalculoInventario) 
			WHEN 'U' THEN 'UEPS' 
			WHEN 'P' THEN 'PEPS' 
			WHEN 'O' THEN 'PONDERADO' 
			WHEN 'B' THEN 'PRECIO MAS BAJO' 
			WHEN 'A' THEN 'PRECIO MAS ALTO' 
			WHEN 'T' THEN 'ULTIMO PRECIO' END 
		AS TipoCalculoInventario,
		P.CodigoTipoCalculoInventario	
		
	from InventariosProductos IP 
	INNER JOIN Productos P
	ON IP.CodigoProducto = P.CodigoProducto
	INNER JOIN @TProductosPrecios PPV
	ON IP.CodigoProducto = PPV.CodigoProducto
	WHERE IP.NumeroAgencia = @NumeroAgencia


END
GO
--exec ListarProductosActualizacionNuevosPrecios 1,160, 
--'<Productos>
--  <ProductosHistorial>
--    <CodigoProducto>001-IMP-000002 </CodigoProducto>
--    <CantidadRecepcion>5</CantidadRecepcion>
--    <MontoGastoIncremento>2.00</MontoGastoIncremento>
--    <PrecioUnitarioCompra>38.14</PrecioUnitarioCompra>
--  </ProductosHistorial>
--  <ProductosHistorial>
--    <CodigoProducto>001-PRO-000012 </CodigoProducto>
--    <CantidadRecepcion>5</CantidadRecepcion>
--    <MontoGastoIncremento>2.00</MontoGastoIncremento>
--    <PrecioUnitarioCompra>1017.00</PrecioUnitarioCompra>
--  </ProductosHistorial>
--</Productos>' , 'R'
exec ListarProductosActualizacionNuevosPrecios 1,160, '<Productos>
  <ProductosHistorial>
    <CodigoProducto>053-COO-000001</CodigoProducto>
    <CantidadRecepcion>2</CantidadRecepcion>
    <PrecioUnitarioCompra>8.50</PrecioUnitarioCompra>
    <PrecioTotal>17.00</PrecioTotal>
    <Garantia>0</Garantia>
    <EsProductoEspecifico>true</EsProductoEspecifico>
    <VendidoComoAgregado>false</VendidoComoAgregado>
    <CantidadExistencia>13</CantidadExistencia>
    <CantidadEntregada>2</CantidadEntregada>
    <PorcentajeDescuento>0</PorcentajeDescuento>
    <NumeroPrecioSeleccionado>1</NumeroPrecioSeleccionado>
    <NumeroOrdenInsertado>0</NumeroOrdenInsertado>
  </ProductosHistorial>
  <ProductosHistorial>
    <CodigoProducto>001-FUE-000013</CodigoProducto>
    <CantidadRecepcion>3</CantidadRecepcion>
    <PrecioUnitarioCompra>15</PrecioUnitarioCompra>
    <PrecioTotal>45</PrecioTotal>
    <Garantia>0</Garantia>
    <EsProductoEspecifico>true</EsProductoEspecifico>
    <VendidoComoAgregado>false</VendidoComoAgregado>
    <CantidadExistencia>2</CantidadExistencia>
    <CantidadEntregada>3</CantidadEntregada>
    <PorcentajeDescuento>25</PorcentajeDescuento>
    <NumeroPrecioSeleccionado>P</NumeroPrecioSeleccionado>
    <NumeroOrdenInsertado>1</NumeroOrdenInsertado>
  </ProductosHistorial>
</Productos>' , 'P'



DROP PROCEDURE ActualizarPreciosVentaUtilidadXML
GO

CREATE PROCEDURE ActualizarPreciosVentaUtilidadXML
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@ListadoProductosXML	TEXT

AS
BEGIN
	DECLARE @punteroXMLProductosDetalle INT					
	EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @ListadoProductosXML
	
	
	UPDATE dbo.InventariosProductos
		SET	
			PorcentajeUtilidad1				= TXML.PorcentajeUtilidad1,
			PrecioUnitarioVenta1			= TXML.PrecioUnitarioVenta1,
			PorcentajeUtilidad2				= TXML.PorcentajeUtilidad2,
			PrecioUnitarioVenta2			= TXML.PrecioUnitarioVenta2,
			PorcentajeUtilidad3				= TXML.PorcentajeUtilidad3,
			PrecioUnitarioVenta3			= TXML.PrecioUnitarioVenta3,
			PorcentajeUtilidad4				= TXML.PorcentajeUtilidad4,
			PrecioUnitarioVenta4			= TXML.PrecioUnitarioVenta4,
			PorcentajeUtilidad5				= TXML.PorcentajeUtilidad5,
			PrecioUnitarioVenta5			= TXML.PrecioUnitarioVenta5,
			PorcentajeUtilidad6				= TXML.PorcentajeUtilidad6,
			PrecioUnitarioVenta6			= TXML.PrecioUnitarioVenta6	
	FROM OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosHistorial',2)
	WITH (	CodigoProducto			VARCHAR(15),
			PorcentajeUtilidad1		DECIMAL(5,2),
			PrecioUnitarioVenta1	DECIMAL(10,2),
			PorcentajeUtilidad2		DECIMAL(5,2),
			PrecioUnitarioVenta2	DECIMAL(10,2),
			PorcentajeUtilidad3		DECIMAL(5,2),
			PrecioUnitarioVenta3	DECIMAL(10,2),
			PorcentajeUtilidad4		DECIMAL(5,2),
			PrecioUnitarioVenta4	DECIMAL(10,2),
			PorcentajeUtilidad5		DECIMAL(5,2),
			PrecioUnitarioVenta5	DECIMAL(10,2),
			PorcentajeUtilidad6		DECIMAL(5,2),
			PrecioUnitarioVenta6	DECIMAL(10,2)	
	) TXML
	WHERE InventariosProductos.NumeroAgencia = @NumeroAgencia
	AND InventariosProductos.CodigoProducto = TXML.CodigoProducto
END
GO
