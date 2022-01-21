USE DOBLONES20
GO

DROP PROCEDURE ActualizarInventarioProductosCompras
GO

CREATE PROCEDURE ActualizarInventarioProductosCompras
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@ListadoCodigos			VARCHAR(8000)
AS
BEGIN
DECLARE 
	@CodigoProducto							CHAR(15),
	@CantidadRecepcion						INT,
	@OpcionesActualizacion					CHAR(3),
	@CodigoTipoCalculoInventarioProducto	CHAR(1),
	@PrecioUnitarioCompra					DECIMAL(10,2) = 0,
	@FechaHoraIngreso						DATETIME,
	@PrecioUnitarioCompraAux				DECIMAL(10,2) = 0,
	@CantidadActualizar						INT,
	@PorcentajeImpuestoIVA					DECIMAL(10,2)
	
DECLARE	@TablaProductosRecepcionadosActualizar TABLE 
( 
	CodigoProducto CHAR(15), 
	CantidadRecepcionada INT
)	
	
	SET ROWCOUNT 0


	--@ListadoCodigos =  103;111 | 105;101
	--ìmplica que el codigo 103 
	-- 111 ->	[1] = [1 o 0] -> ActualizarPrecioVenta; Actualizar el Precio de Venta en base al precio de Compra
	--			[1] = [1 o 0] -> Promedio;				Sacar un promedio de los precios que costo adquirir el set completo de ese productos y promediar su precio para actualizar los preciso de venta
	--			[1] = [1 o 0] -> UltimaRecepcion;		Actualizar el Precio de Venta en Base a la ultima recepción(cuando recepcionan por partes y no aplican gasto, solo al final)
	IF(@ListadoCodigos IS NOT NULL)
	BEGIN

	
		SELECT SUBSTRING(Data,0, CHARINDEX(';',DATA)) AS CodigoProducto, CAST(SUBSTRING(Data,CHARINDEX(';', DATA) + 1, LEN(DATA)) AS CHAR(3))AS Opciones
		INTO #ProductosActualizar
		FROM dbo.split(@ListadoCodigos, '|') -- 
		
		SELECT @CantidadActualizar = COUNT(*) FROM #ProductosActualizar
		
		DELETE FROM @TablaProductosRecepcionadosActualizar
		
		INSERT INTO @TablaProductosRecepcionadosActualizar
		SELECT TOP (@CantidadActualizar) CPDE.CodigoProducto, CPDE.CantidadEntregada		
		FROM ComprasProductosDetalleEntrega CPDE 
		INNER JOIN #ProductosActualizar PA 
		ON CPDE.CodigoProducto = PA.CodigoProducto
		WHERE CPDE.NumeroAgencia = NumeroAgencia 
		AND CPDE.NumeroCompraProducto = @NumeroCompraProducto		
		ORDER BY CPDE.FechaHoraEntrega DESC
	END
	ELSE
	BEGIN
		DELETE FROM @TablaProductosRecepcionadosActualizar
		
		INSERT INTO @TablaProductosRecepcionadosActualizar
		SELECT CodigoProducto, CantidadCompra 
		FROM ComprasProductosDetalle
		WHERE (NumeroAgencia = @NumeroAgencia 
		AND NumeroCompraProducto = @NumeroCompraProducto)
	END	

	SET ROWCOUNT 1
	SELECT @CodigoProducto = CodigoProducto, @CantidadRecepcion = CantidadRecepcionada 
	FROM @TablaProductosRecepcionadosActualizar

	WHILE @@rowcount <> 0
	BEGIN
				
		--Actualizamos el inventario del producto correspondiente
		UPDATE dbo.InventariosProductos
			SET CantidadExistencia = CantidadExistencia + @CantidadRecepcion				
		WHERE NumeroAgencia = @NumeroAgencia and CodigoProducto = @CodigoProducto	
		
		--EL PRODUCTO ES CONSIDERADO COMPUESTO
		IF(EXISTS (SELECT CodigoProducto FROM Productos WHERE CodigoProducto = @CodigoProducto AND ProductoSimple = 0))
		BEGIN
			UPDATE InventariosProductos
				SET CantidadExistencia = CantidadExistencia + (PC.Cantidad * @CantidadRecepcion),
					PrecioValoradoTotal = PrecioValoradoTotal + (PC.Cantidad * @CantidadRecepcion) * PrecioUnitarioCompra
			FROM ProductosCompuestos PC
			WHERE PC.CodigoProducto = @CodigoProducto
			AND InventariosProductos.NumeroAgencia = @NumeroAgencia
			AND InventariosProductos.CodigoProducto = @CodigoProducto
			AND InventariosProductos.CodigoProducto = PC.CodigoProducto
		END
		
		
		--CODIGO QUE SE ENCARGA DE ENCONTRAR EL PRECIO IDEAL DE COMPRA
		--PARA ACTUALIZAR LOS PRECIOS DE VENTA
		------------------------------------------------------------------------------------------------------------------------
		IF((@ListadoCodigos IS NOT NULL) AND EXISTS (
					SELECT PA.CodigoProducto FROM #ProductosActualizar PA
					WHERE PA.CodigoProducto = @CodigoProducto
				))
		BEGIN
			SELECT @OpcionesActualizacion = Opciones
			FROM #ProductosActualizar PA
			WHERE PA.CodigoProducto = @CodigoProducto
			
			--U'->UEPS, 'P'->PEPS, 'O'->Ponderado, 'B'-> Precio mas Bajo, 'A'->Precio mas alto	
			IF(SUBSTRING(@OpcionesActualizacion,1,1) ='1') --Actualizamos los Precios de Venta de Este Producto
			BEGIN
				SET @CodigoTipoCalculoInventarioProducto = dbo.ObtenerCodigoTipoCalculoInventarioProducto(@CodigoProducto)
				IF(@CodigoTipoCalculoInventarioProducto = 'U')--UEPS
				BEGIN
					IF(SUBSTRING(@OpcionesActualizacion,2,1) ='1' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0') -- SACAR PROMEDIO DE LAS TUPLAS DE ESTA COMPRA
					BEGIN
						SELECT @PrecioUnitarioCompra = AVG(PrecioUnitario)
						FROM InventarioProductosCantidadesComprasHistorial						
						WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
						AND CodigoProducto = @CodigoProducto
						GROUP BY NumeroAgencia,  NumeroCompraProducto, CodigoProducto
					END					
					ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='1')	-- TRABAJAR CON LA ULTIMA TUPLA INGRESADA Y PROMEDIAR EN LA MISMA Y ELIMINAR LAS ANTIGUAS PAR ESTA COMPRA				
					BEGIN
						SELECT TOP 1 @PrecioUnitarioCompra = PrecioUnitario
						FROM InventarioProductosCantidadesComprasHistorial
						WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
						AND CodigoProducto = @CodigoProducto
						ORDER BY FechaHoraIngreso DESC
					END					
					ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0')-- TRABAJAR CON CADA UNA DE LAS TUPLAS DE ESTA COMPRA
					BEGIN
						SELECT TOP 1 @PrecioUnitarioCompra = PrecioUnitario
						FROM InventarioProductosCantidadesComprasHistorial
						WHERE NumeroAgencia = @NumeroAgencia 
						AND CodigoProducto = @CodigoProducto
						ORDER BY FechaHoraIngreso DESC
					END
					
				END
				
				ELSE IF(@CodigoTipoCalculoInventarioProducto = 'P')--PEPS
				BEGIN
					IF(SUBSTRING(@OpcionesActualizacion,2,1) ='1' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0') -- SACAR PROMEDIO DE LAS TUPLAS DE ESTA COMPRA
					BEGIN
						SELECT  @PrecioUnitarioCompraAux = AVG(PrecioUnitario)
						FROM InventarioProductosCantidadesComprasHistorial
						WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
						AND CodigoProducto = @CodigoProducto
						
						SELECT TOP 1 @FechaHoraIngreso = FechaHoraIngreso
						FROM InventarioProductosCantidadesComprasHistorial
						WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
						AND CodigoProducto = @CodigoProducto
						ORDER BY FechaHoraIngreso ASC
						
						
						SELECT TOP 1 @PrecioUnitarioCompra = PrecioUnitario
						FROM
						(	SELECT PrecioUnitario, FechaHoraIngreso
							FROM InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
							AND NumeroCompraProducto <> @NumeroCompraProducto
							UNION
							SELECT @PrecioUnitarioCompraAux AS PrecioUnitario, @FechaHoraIngreso AS FechaHoraIngreso							
						) tabla
						ORDER BY FechaHoraIngreso ASC
						
						
					END					
					ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='1')	-- TRABAJAR CON LA ULTIMA TUPLA INGRESADA Y PROMEDIAR EN LA MISMA Y ELIMINAR LAS ANTIGUAS PAR ESTA COMPRA				
					BEGIN
						SELECT TOP 1 @PrecioUnitarioCompraAux = PrecioUnitario, @FechaHoraIngreso = FechaHoraIngreso
						FROM InventarioProductosCantidadesComprasHistorial
						WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
						AND CodigoProducto = @CodigoProducto
						ORDER BY FechaHoraIngreso ASC
						
						SELECT TOP 1 @PrecioUnitarioCompra = PrecioUnitario
						FROM
						(
							SELECT PrecioUnitario, FechaHoraIngreso
							FROM InventarioProductosCantidadesComprasHistorial						
							WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
							AND NumeroCompraProducto <> @NumeroCompraProducto
							UNION
							SELECT @PrecioUnitarioCompraAux AS PrecioUnitario, @FechaHoraIngreso AS FechaHoraIngreso	
						) TABLA
						ORDER BY FechaHoraIngreso ASC
					
						
					END					
					ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0')-- TRABAJAR CON CADA UNA DE LAS TUPLAS DE ESTA COMPRA
					BEGIN
						SELECT TOP 1 @PrecioUnitarioCompra = PrecioUnitario
						FROM InventarioProductosCantidadesComprasHistorial
						WHERE NumeroAgencia = @NumeroAgencia
						AND CodigoProducto = @CodigoProducto
						ORDER BY FechaHoraIngreso ASC
					END
				END
				
				ELSE IF(@CodigoTipoCalculoInventarioProducto = 'O')--Ponderado
				BEGIN
					IF(SUBSTRING(@OpcionesActualizacion,2,1) ='1' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0') -- SACAR PROMEDIO DE LAS TUPLAS DE ESTA COMPRA
					BEGIN
						SELECT @PrecioUnitarioCompraAux = AVG(PrecioUnitario)
						FROM InventarioProductosCantidadesComprasHistorial						
						WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
						AND CodigoProducto = @CodigoProducto
						GROUP BY NumeroAgencia,  NumeroCompraProducto, CodigoProducto
						
						SELECT @PrecioUnitarioCompra = AVG(PrecioUnitario)
						FROM 
						(
							SELECT PrecioUnitario
							from InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto <> @NumeroCompraProducto
							AND CodigoProducto = @CodigoProducto
							UNION
							SELECT @PrecioUnitarioCompraAux AS PrecioUnitario
						)TABLA
						
					END					
					ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='1')	-- TRABAJAR CON LA ULTIMA TUPLA INGRESADA Y PROMEDIAR EN LA MISMA Y ELIMINAR LAS ANTIGUAS PAR ESTA COMPRA				
					BEGIN
						SELECT TOP 1 @PrecioUnitarioCompraAux = PrecioUnitario
						FROM InventarioProductosCantidadesComprasHistorial
						WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
						AND CodigoProducto = @CodigoProducto
						ORDER BY FechaHoraIngreso DESC
						
						SELECT @PrecioUnitarioCompra = AVG(PrecioUnitario)
						FROM 
						(
							SELECT PrecioUnitario
							from InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto <> @NumeroCompraProducto
							AND CodigoProducto = @CodigoProducto
							UNION
							SELECT @PrecioUnitarioCompraAux AS PrecioUnitario
						)TABLA
					END					
					ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0')-- TRABAJAR CON CADA UNA DE LAS TUPLAS DE ESTA COMPRA
					BEGIN
						SELECT @PrecioUnitarioCompra = AVG(PrecioUnitario)
						FROM InventarioProductosCantidadesComprasHistorial
						WHERE NumeroAgencia = @NumeroAgencia 
						AND CodigoProducto = @CodigoProducto
						
					END
				END
				
				ELSE IF(@CodigoTipoCalculoInventarioProducto = 'B')--Precio Mas Bajo
				BEGIN
					IF(SUBSTRING(@OpcionesActualizacion,2,1) ='1' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0') -- SACAR PROMEDIO DE LAS TUPLAS DE ESTA COMPRA
					BEGIN
						SELECT @PrecioUnitarioCompraAux = AVG(PrecioUnitario)
						FROM InventarioProductosCantidadesComprasHistorial						
						WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
						AND CodigoProducto = @CodigoProducto
						GROUP BY NumeroAgencia,  NumeroCompraProducto, CodigoProducto
						
						SELECT TOP 1 @PrecioUnitarioCompra = PrecioUnitario
						FROM 
						(
							SELECT PrecioUnitario
							from InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto <> @NumeroCompraProducto
							AND CodigoProducto = @CodigoProducto
							UNION
							SELECT @PrecioUnitarioCompraAux AS PrecioUnitario
						)TABLA ORDER BY PrecioUnitario ASC
						
					END					
					ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='1')	-- TRABAJAR CON LA ULTIMA TUPLA INGRESADA Y PROMEDIAR EN LA MISMA Y ELIMINAR LAS ANTIGUAS PAR ESTA COMPRA				
					BEGIN
						SELECT TOP 1 @PrecioUnitarioCompraAux = PrecioUnitario
						FROM InventarioProductosCantidadesComprasHistorial
						WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
						AND CodigoProducto = @CodigoProducto
						ORDER BY FechaHoraIngreso DESC
						
						SELECT TOP 1 @PrecioUnitarioCompra = PrecioUnitario
						FROM 
						(
							SELECT PrecioUnitario
							FROM InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto <> @NumeroCompraProducto
							AND CodigoProducto = @CodigoProducto
							UNION
							SELECT @PrecioUnitarioCompraAux AS PrecioUnitario
						)TABLA ORDER BY PrecioUnitario ASC
					END					
					ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0')-- TRABAJAR CON CADA UNA DE LAS TUPLAS DE ESTA COMPRA
					BEGIN
						SELECT TOP 1 @PrecioUnitarioCompra = PrecioUnitario
						FROM InventarioProductosCantidadesComprasHistorial
						WHERE NumeroAgencia = @NumeroAgencia 
						AND CodigoProducto = @CodigoProducto
						ORDER BY PrecioUnitario ASC
					END				
				END
				
				ELSE IF(@CodigoTipoCalculoInventarioProducto = 'A')--Precio Mas Alto
				BEGIN
					IF(SUBSTRING(@OpcionesActualizacion,2,1) ='1' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0') -- SACAR PROMEDIO DE LAS TUPLAS DE ESTA COMPRA
					BEGIN
						SELECT @PrecioUnitarioCompraAux = AVG(PrecioUnitario)
						FROM InventarioProductosCantidadesComprasHistorial						
						WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
						AND CodigoProducto = @CodigoProducto
						GROUP BY NumeroAgencia,  NumeroCompraProducto, CodigoProducto
						
						SELECT TOP 1 @PrecioUnitarioCompra = PrecioUnitario
						FROM 
						(
							SELECT PrecioUnitario
							from InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto <> @NumeroCompraProducto
							AND CodigoProducto = @CodigoProducto
							UNION
							SELECT @PrecioUnitarioCompraAux AS PrecioUnitario
						)TABLA ORDER BY PrecioUnitario DESC
						
					END					
					ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='1')	-- TRABAJAR CON LA ULTIMA TUPLA INGRESADA Y PROMEDIAR EN LA MISMA Y ELIMINAR LAS ANTIGUAS PAR ESTA COMPRA				
					BEGIN
						SELECT TOP 1 @PrecioUnitarioCompraAux = PrecioUnitario
						FROM InventarioProductosCantidadesComprasHistorial
						WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
						AND CodigoProducto = @CodigoProducto
						ORDER BY FechaHoraIngreso DESC
						
						SELECT TOP 1 @PrecioUnitarioCompra = PrecioUnitario
						FROM 
						(
							SELECT PrecioUnitario
							from InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto <> @NumeroCompraProducto
							AND CodigoProducto = @CodigoProducto
							UNION
							SELECT @PrecioUnitarioCompraAux AS PrecioUnitario
						)TABLA ORDER BY PrecioUnitario DESC
					END					
					ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0')-- TRABAJAR CON CADA UNA DE LAS TUPLAS DE ESTA COMPRA
					BEGIN
						SELECT TOP 1 @PrecioUnitarioCompra = PrecioUnitario
						FROM InventarioProductosCantidadesComprasHistorial
						WHERE NumeroAgencia = @NumeroAgencia 
						AND CodigoProducto = @CodigoProducto
						ORDER BY PrecioUnitario DESC
					END	
				END
				
				ELSE IF(@CodigoTipoCalculoInventarioProducto = 'T')--Al último PRECIO
				BEGIN
					IF(SUBSTRING(@OpcionesActualizacion,2,1) ='1' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0') -- SACAR PROMEDIO DE LAS TUPLAS DE ESTA COMPRA
					BEGIN
						SELECT @PrecioUnitarioCompra = AVG(PrecioUnitario)
						FROM InventarioProductosCantidadesComprasHistorial						
						WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
						AND CodigoProducto = @CodigoProducto
						GROUP BY NumeroAgencia,  NumeroCompraProducto, CodigoProducto						
						
					END					
					ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='1')	-- TRABAJAR CON LA ULTIMA TUPLA INGRESADA Y PROMEDIAR EN LA MISMA Y ELIMINAR LAS ANTIGUAS PAR ESTA COMPRA				
					BEGIN
						SELECT TOP 1 @PrecioUnitarioCompra = PrecioUnitario
						FROM InventarioProductosCantidadesComprasHistorial
						WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
						AND CodigoProducto = @CodigoProducto
						ORDER BY FechaHoraIngreso DESC						
						
					END					
					ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0')-- TRABAJAR CON CADA UNA DE LAS TUPLAS DE ESTA COMPRA
					BEGIN
						SELECT TOP 1 @PrecioUnitarioCompra = PrecioUnitario
						FROM InventarioProductosCantidadesComprasHistorial
						WHERE NumeroAgencia = @NumeroAgencia
						AND CodigoProducto = @CodigoProducto
						ORDER BY FechaHoraIngreso DESC
					END	
				END
				
				
				SELECT TOP(1) @PorcentajeImpuestoIVA = CASE WHEN (SELECT TOP(1) CodigoEstadoFactura FROM  dbo.ComprasProductos CP WHERE
				CP.NumeroAgencia = @NumeroAgencia AND CP.NumeroCompraProducto = @NumeroCompraProducto) = 'F' 
				THEN PorcentajeImpuestoCompraConFactura ELSE PorcentajeImpuestoCompraSinFactura END FROM PCsConfiguraciones
				WHERE NumeroAgencia = @NumeroAgencia	
				
				UPDATE InventariosProductos
				SET PrecioUnitarioVenta1 = ROUND(@PrecioUnitarioCompra + @PrecioUnitarioCompra * PorcentajeUtilidad1 /100 , 2),
					PrecioUnitarioVenta2 = ROUND(@PrecioUnitarioCompra + @PrecioUnitarioCompra * PorcentajeUtilidad2 /100 , 2),
					PrecioUnitarioVenta3 = ROUND(@PrecioUnitarioCompra + @PrecioUnitarioCompra * PorcentajeUtilidad3 /100 , 2),
					PrecioUnitarioVenta4 = ROUND(@PrecioUnitarioCompra + @PrecioUnitarioCompra * PorcentajeUtilidad1 /100  + (@PrecioUnitarioCompra + @PrecioUnitarioCompra * PorcentajeUtilidad1 /100) * @PorcentajeImpuestoIVA /100 , 2),
					PrecioUnitarioVenta5 = ROUND(@PrecioUnitarioCompra + @PrecioUnitarioCompra * PorcentajeUtilidad2 /100  + (@PrecioUnitarioCompra + @PrecioUnitarioCompra * PorcentajeUtilidad2 /100) * @PorcentajeImpuestoIVA /100 , 2),
					PrecioUnitarioVenta6 = ROUND(@PrecioUnitarioCompra + @PrecioUnitarioCompra * PorcentajeUtilidad3 /100  + (@PrecioUnitarioCompra + @PrecioUnitarioCompra * PorcentajeUtilidad3 /100) * @PorcentajeImpuestoIVA /100 , 2),
					PrecioValoradoTotal = ISNULL(PrecioValoradoTotal,0) + (@CantidadRecepcion * @PrecioUnitarioCompra)
				WHERE NumeroAgencia = @NumeroAgencia 
				AND CodigoProducto = @CodigoProducto	
				
				--SI EL PRODUCTO 	
			END			
		END
		
		------------------------------------------------------------------------------------------------------------------------
		
		DELETE @TablaProductosRecepcionadosActualizar WHERE @CodigoProducto = CodigoProducto
		SET ROWCOUNT 1
		SELECT @CodigoProducto = CodigoProducto, @CantidadRecepcion = CantidadRecepcionada FROM @TablaProductosRecepcionadosActualizar
	END
	SET ROWCOUNT 0
	
	
	--DESPUES DE HABER HECHO LA ACTUALIZACION CORRESPONDIENTES
	--EN CASO DE QUE UN ARTICULO SEA PARTE DE UN PRODUCTO PADRE, PUEDE HABER QUE EL CASO DE QUE SE PUEDA
	--AUMENTAR LA EXISTENCIA DEL ARTICULO PADRE	
	IF(EXISTS(SELECT CodigoProducto FROM #ProductosActualizar WHERE CodigoProducto IN 
		(SELECT CodigoProductoComponente FROM ProductosCompuestos) ))
	BEGIN
		UPDATE InventariosProductos
			SET CantidadExistencia = IRPC.CantidadExistencia,
				PrecioValoradoTotal = IRPC.PrecioValoradoTotal
		FROM InventarioRealProductosCompuestos IRPC
		WHERE IRPC.CodigoProducto IN
		(
			SELECT PC.CodigoProducto
			FROM #ProductosActualizar PA
			INNER JOIN ProductosCompuestos PC
			ON PA.CodigoProducto = PC.CodigoProductoComponente
		)
		AND InventariosProductos.CantidadExistencia <> IRPC.CantidadExistencia
		AND InventariosProductos.NumeroAgencia = @NumeroAgencia
		AND InventariosProductos.CodigoProducto = IRPC.CodigoProducto
	END
	
	
END
GO
----'263;100| 463;100|482;100'
--exec ActualizarInventarioProductosCompras 1, 83, '10001035;101|100;101'

--SELECT * FROM InventariosProductos
--WHERE CodigoProducto IN ('300','303')
--SELECT * FROM InventarioProductosCantidadesComprasHistorial
--SELECT * FROM ComprasProductosDetalleEntrega
--SELECT * FROM ComprasProductosEspecificos

----SELECT SUBSTRING('ABC',3,1)



----USE Doblones20
----SELECT * FROM VentasProductos ORDER BY MontoTotalVenta asc
----SELECT * FROM Clientes

--SELECT  * FROM Agencias
--SELECT * FROM VentasFacturas

