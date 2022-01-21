USE DOBLONES20
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ActualizarInventariosTransferenciaProductos') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ActualizarInventariosTransferenciaProductos
	END
GO	
CREATE PROCEDURE ActualizarInventariosTransferenciaProductos
	@NumeroAgencia					INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoTipoEnvioRecepcion		CHAR(1),
	@ListadoCodigos					VARCHAR(8000)
AS
BEGIN
	
	IF(EXISTS(
			SELECT NumeroTransferenciaProducto 
			FROM TransferenciasProductos 
			WHERE NumeroTransferenciaProducto = @NumeroTransferenciaProducto
			))
	BEGIN
		DECLARE @CodigoProducto							CHAR(15),
				@NumeroAgenciaEmisora					INT,
				@NumeroAgenciaRecepctora				INT,
				@FechaHoraEnvioRecepcion				DATETIME,
				@CantidadActualizar						INT,
				@OpcionesActualizacion					CHAR(3),
				@CantidadExistencia						INT,
				@CodigoTipoCalculoInventarioProducto	CHAR(1),
				@PrecioUnitarioIngreso					DECIMAL(10,2),
				@PrecioUnitarioIngresoAux				DECIMAL(10,2),
				@FechaHoraIngreso						DATETIME
		DECLARE @TProductosActualizar TABLE
		(
			CodigoProducto			CHAR(15),
			CantidadActualizacion	INT,
			Opciones				CHAR(3)
		)
		DECLARE @TProductosOpciones TABLE
		(
			CodigoProducto			CHAR(15),
			Opciones				CHAR(3)
		)
		IF (@ListadoCodigos IS NOT NULL)		
			INSERT INTO @TProductosOpciones (CodigoProducto, Opciones)
			SELECT SUBSTRING(Data,0, CHARINDEX(';',DATA)) AS CodigoProducto, CAST(SUBSTRING(Data,CHARINDEX(';', DATA) + 1, LEN(DATA)) AS CHAR(3))AS Opciones		
			FROM dbo.split(@ListadoCodigos, '|') 
		
		IF (@CodigoTipoEnvioRecepcion = 'E')
		BEGIN
			SELECT TOP 1 @FechaHoraEnvioRecepcion = FechaHoraEnvioRecepcion
			FROM TransferenciasProductosDetalleRecepcion
			WHERE @NumeroTransferenciaProducto = @NumeroTransferenciaProducto AND NumeroAgenciaEmisora = @NumeroAgencia
			AND CodigoTipoEnvioRecepcion = @CodigoTipoEnvioRecepcion
			ORDER BY FechaHoraEnvioRecepcion DESC
			
			--SELECT * FROM TransferenciasProductosDetalleRecepcion WHERE FechaHoraEnvio = @FechaHora
			--INTO @TProductosActualizar
			INSERT INTO @TProductosActualizar (CodigoProducto, CantidadActualizacion, Opciones)
			SELECT TPDR.CodigoProducto, TPDR.CantidadEnvioRecepcion, ISNULL(TPO.Opciones,'000')
			FROM TransferenciasProductosDetalleRecepcion  TPDR LEFT JOIN @TProductosOpciones TPO ON  TPDR.CodigoProducto = TPO.CodigoProducto
			WHERE FechaHoraEnvioRecepcion = @FechaHoraEnvioRecepcion and CodigoTipoEnvioRecepcion = @CodigoTipoEnvioRecepcion
			AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
		END
		ELSE IF(@CodigoTipoEnvioRecepcion = 'R')
		BEGIN
			SELECT TOP 1 @FechaHoraEnvioRecepcion = FechaHoraEnvioRecepcion
			FROM TransferenciasProductosDetalleRecepcion
			WHERE @NumeroTransferenciaProducto = @NumeroTransferenciaProducto AND NumeroAgenciaEmisora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)
			AND CodigoTipoEnvioRecepcion IN ('R','X')
			ORDER BY FechaHoraEnvioRecepcion DESC
			
			--SELECT * FROM TransferenciasProductosDetalleRecepcion WHERE FechaHoraEnvio = @FechaHora
			--INTO @TProductosActualizar
			INSERT INTO @TProductosActualizar (CodigoProducto, CantidadActualizacion, Opciones)
			SELECT TPDR.CodigoProducto, TPDR.CantidadEnvioRecepcion, ISNULL(TPO.Opciones,'000')
			FROM TransferenciasProductosDetalleRecepcion  TPDR LEFT JOIN @TProductosOpciones TPO ON  TPDR.CodigoProducto = TPO.CodigoProducto
			WHERE FechaHoraEnvioRecepcion = @FechaHoraEnvioRecepcion and CodigoTipoEnvioRecepcion IN ('R','X')
			AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
		END
		
		IF(@CodigoTipoEnvioRecepcion = 'E' AND EXISTS(
			SELECT * 
			FROM @TProductosActualizar  TPA
			INNER JOIN InventariosProductos IP
			ON IP.CodigoProducto = TPA.CodigoProducto
			WHERE TPA.CantidadActualizacion > IP.CantidadExistencia
			AND IP.NumeroAgencia = @NumeroAgenciaEmisora
		))
		BEGIN
			RAISERROR('No se Puede Completar la Transferencia debido a la insuficiencia en cantidad de los Productos en Inventarios para ser Transferidos, Reabaztezca su Inventario',1,16)
		END
		
		SET ROWCOUNT 1
		SELECT @CodigoProducto = CodigoProducto, @CantidadActualizar = CantidadActualizacion, @OpcionesActualizacion = Opciones  FROM @TProductosActualizar
		
		
		WHILE @@rowcount <> 0
		BEGIN		
			--BEGIN -- Solo actualizamos inventarios de los productos q NO SON ESPECIFICOS,
				-- Debido que mas abajo, existe un un segmento de codigo que se encarga especificamente de realizar la actualizaciçon de los productos ESPECIFICOS
				
			IF(@CodigoTipoEnvioRecepcion = 'E')
			BEGIN				
				SELECT @CantidadExistencia = CantidadExistencia FROM InventariosProductos WHERE CodigoProducto = @CodigoProducto
			
				IF( @CantidadActualizar <= @CantidadExistencia)
				BEGIN
					UPDATE dbo.InventariosProductos			
					SET CantidadExistencia = CantidadExistencia - @CantidadActualizar
					WHERE NumeroAgencia = @NumeroAgencia and CodigoProducto = @CodigoProducto
					
					exec ActualizarEliminarInventarioProductosCantidadesComprasHistorial @NumeroAgencia, @CodigoProducto, @CantidadActualizar		
					SELECT @NumeroAgenciaRecepctora = NumeroAgenciaRecepctora FROM TransferenciasProductos WHERE NumeroAgenciaEmisora = @NumeroAgencia AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
					
					--ACTUALIZAMOS ESPECIFICOS
					--PARA EL CASO DE SOLO CAMBIAR EL NUMERO DE AGENCIA
					--UPDATE InventariosProductosEspecificos
					--	SET NumeroAgencia = @NumeroAgenciaRecepctora,
					--		CodigoEstado = 'T'
					--WHERE CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia AND CodigoProductoEspecifico IN
					--	(
					--		SELECT CodigoProductoEspecifico FROM TransferenciasProductosEspecificos
					--		WHERE Entregado = 0 AND FechaHoraEnvio = @FechaHoraEnvioRecepcion
					--	)				
					
					
					--UPDATE TransferenciasProductosEspecificos
					--	SET Entregado = 1
					--WHERE Entregado = 0 AND FechaHoraEnvio = @FechaHoraEnvioRecepcion					
					
					--SI ES PARA EL CASO DE INSERTAR EN LA OTRA AGENCIA Y CAMBIAR EL ESTADO DEL PRODUCTO ESPECIFICO					
					IF(dbo.EsProductoEspecifico(@NumeroAgencia, @CodigoProducto) = 1)
					SET ROWCOUNT 0
					BEGIN
						UPDATE InventariosProductosEspecificos
							SET CodigoEstado = 'T'
						WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto AND CodigoProductoEspecifico IN
							(
								SELECT CodigoProductoEspecifico FROM TransferenciasProductosEspecificos
								WHERE Entregado = 0 AND FechaHoraEnvio = @FechaHoraEnvioRecepcion
								AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
							)
					END
					SET ROWCOUNT 1
				END				
			END
			ELSE IF(@CodigoTipoEnvioRecepcion = 'R')
			BEGIN
				
				SET @NumeroAgenciaEmisora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)				
				
				--Actualizamos Productos Especificos
				--PARA EL CASO EN QUE SOLO SE CAMBIA EL NUMERO DE AGENCIA EN LA TRANSFERENCIA DE PRODUCTOS ESPECIFICOS
				IF(EXISTS(SELECT CodigoProducto FROM InventariosProductos WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto))				
				BEGIN				
					UPDATE dbo.InventariosProductos			
					SET CantidadExistencia = CantidadExistencia + @CantidadActualizar,
						EsProductoEspecifico = dbo.EsProductoEspecifico(@NumeroAgenciaEmisora,@CodigoProducto)
						--Esta OPCION ES PARA CUANDO RECIEN LO CONSIDERA PE y ahora tambien debe ser 
						--CONSIDE PE en la otra Agencia donde se Transfiere!
					WHERE NumeroAgencia = @NumeroAgencia and CodigoProducto = @CodigoProducto
					
					IF(dbo.EsProductoEspecifico(@NumeroAgencia,@CodigoProducto) = 1)
					BEGIN
						--UPDATE InventariosProductosEspecificos
						--SET		CodigoEstado = 'A'
						--WHERE CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia AND CodigoProductoEspecifico IN
						--	(
						--		SELECT CodigoProductoEspecifico FROM TransferenciasProductosEspecificos
						--		WHERE Entregado = 0 AND FechaHoraEnvio = @FechaHoraEnvioRecepcion
						--		AND NumeroAgenciaEmisora = @NumeroAgenciaEmisora AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
						--	)
						SET ROWCOUNT 0	
						--PARA EL CASO EN QUE SE TENGA QUE INSERTAR EL CODIGO PRODUCTOS ESPECIFICO DENTRO DE LA OTRA AGENCIA
						INSERT INTO InventariosProductosEspecificos (NumeroAgencia, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPECompra, FechaHoraVencimientoPE, CodigoFormaAdquisicion, CodigoEstado)
						SELECT @NumeroAgencia, @CodigoProducto, TPE.CodigoProductoEspecifico, IPE.TiempoGarantiaPECompra, IPE.FechaHoraVencimientoPE, 'T', 'A'
						FROM TransferenciasProductosEspecificos TPE
						INNER JOIN InventariosProductosEspecificos IPE ON TPE.NumeroAgenciaEmisora = IPE.NumeroAgencia AND TPE.CodigoProducto = IPE.CodigoProducto
						AND TPE.CodigoProductoEspecifico = IPE.CodigoProductoEspecifico 
						WHERE TPE.NumeroTransferenciaProducto = @NumeroTransferenciaProducto AND TPE.NumeroAgenciaEmisora = @NumeroAgenciaEmisora
						AND TPE.CodigoProducto = @CodigoProducto AND TPE.Entregado = 0 and TPE.FechaHoraRecepcion = @FechaHoraEnvioRecepcion
						SET ROWCOUNT 1
					END
				END
				ELSE				
				BEGIN
					INSERT INTO InventariosProductos (NumeroAgencia, CodigoProducto, CantidadExistencia, CantidadRequerida, PrecioUnitarioCompra, TiempoGarantiaProducto, PorcentajeUtilidad1, PrecioUnitarioVenta1, PorcentajeUtilidad2, PrecioUnitarioVenta2, PorcentajeUtilidad3, PrecioUnitarioVenta3, PorcentajeUtilidad4, PrecioUnitarioVenta4, PorcentajeUtilidad5, PrecioUnitarioVenta5, PorcentajeUtilidad6, PrecioUnitarioVenta6, StockMinimo, MostrarParaVenta, ClaseProducto, EsProductoEspecifico, ProductoEspecificoInventariado)
					SELECT @NumeroAgencia , CodigoProducto, @CantidadActualizar, 0, PrecioUnitarioCompra, TiempoGarantiaProducto, PorcentajeUtilidad1, PrecioUnitarioVenta1, PorcentajeUtilidad2, PrecioUnitarioVenta2, PorcentajeUtilidad3, PrecioUnitarioVenta3, PorcentajeUtilidad4, PrecioUnitarioVenta4, PorcentajeUtilidad5, PrecioUnitarioVenta5, PorcentajeUtilidad6, PrecioUnitarioVenta6, StockMinimo, MostrarParaVenta, ClaseProducto, EsProductoEspecifico, 0
					FROM InventariosProductos 
					WHERE NumeroAgencia = @NumeroAgenciaEmisora AND CodigoProducto = @CodigoProducto
					
					IF(dbo.EsProductoEspecifico(@NumeroAgencia,@CodigoProducto) = 1)
					BEGIN
						INSERT INTO dbo.InventariosProductosEspecificos (NumeroAgencia, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPECompra, FechaHoraVencimientoPE, CodigoFormaAdquisicion, CodigoEstado)
						SELECT @NumeroAgencia, @CodigoProducto, TPE.CodigoProductoEspecifico, IPE.TiempoGarantiaPECompra, IPE.FechaHoraVencimientoPE, 'T', 'A'
						--FROM InventariosProductosEspecificos
						--WHERE NumeroAgencia = @NumeroAgenciaEmisora AND CodigoProducto = @CodigoProducto
						--AND CodigoProductoEspecifico IN(
						--								SELECT  CodigoProductoEspecifico FROM TransferenciasProductosEspecificos
						--								WHERE Entregado = 0 AND FechaHoraEnvio = @FechaHoraEnvioRecepcion
						--								AND NumeroAgenciaEmisora = @NumeroAgenciaEmisora AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
						--								)
						FROM TransferenciasProductosEspecificos TPE
						INNER JOIN InventariosProductosEspecificos IPE ON TPE.NumeroAgenciaEmisora = IPE.NumeroAgencia AND TPE.CodigoProducto = IPE.CodigoProducto
						AND TPE.CodigoProductoEspecifico = IPE.CodigoProductoEspecifico 
						WHERE TPE.NumeroTransferenciaProducto = @NumeroTransferenciaProducto AND TPE.NumeroAgenciaEmisora = @NumeroAgenciaEmisora
						AND TPE.CodigoProducto = @CodigoProducto AND TPE.Entregado = 0 and TPE.FechaHoraRecepcion = @FechaHoraEnvioRecepcion
					END
				END
				
				SET ROWCOUNT 0
				UPDATE TransferenciasProductosEspecificos
					SET Entregado = 1
				WHERE CodigoProducto = @CodigoProducto AND FechaHoraRecepcion = @FechaHoraEnvioRecepcion
				AND NumeroAgenciaEmisora = @NumeroAgenciaEmisora AND NumeroTransferenciaProducto = NumeroTransferenciaProducto
				SET ROWCOUNT 1
				
								
				--U'->UEPS, 'P'->PEPS, 'O'->Ponderado, 'B'-> Precio mas Bajo, 'A'->Precio mas alto	
				IF(SUBSTRING(@OpcionesActualizacion,1,1) ='1') --Actualizamos los Precios de Venta de Este Producto
				BEGIN
					SET @CodigoTipoCalculoInventarioProducto = dbo.ObtenerCodigoTipoCalculoInventarioProducto(@CodigoProducto)
					IF(@CodigoTipoCalculoInventarioProducto = 'U')--UEPS
					BEGIN
						IF(SUBSTRING(@OpcionesActualizacion,2,1) ='1' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0') -- SACAR PROMEDIO DE LAS TUPLAS DE ESTA COMPRA
						BEGIN
							SELECT @PrecioUnitarioIngreso = AVG(PrecioUnitario)
							FROM InventarioProductosCantidadesComprasHistorial						
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroTransferenciaProducto
							AND CodigoProducto = @CodigoProducto
							GROUP BY NumeroAgencia,  NumeroCompraProducto, CodigoProducto
						END					
						ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='1')	-- TRABAJAR CON LA ULTIMA TUPLA INGRESADA Y PROMEDIAR EN LA MISMA Y ELIMINAR LAS ANTIGUAS PAR ESTA COMPRA				
						BEGIN
							SELECT TOP 1 @PrecioUnitarioIngreso = PrecioUnitario
							FROM InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroTransferenciaProducto
							AND CodigoProducto = @CodigoProducto
							ORDER BY FechaHoraIngreso DESC
						END					
						ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0')-- TRABAJAR CON CADA UNA DE LAS TUPLAS DE ESTA COMPRA
						BEGIN
							SELECT TOP 1 @PrecioUnitarioIngreso = PrecioUnitario
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
							SELECT  @PrecioUnitarioIngresoAux = AVG(PrecioUnitario)
							FROM InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroTransferenciaProducto
							AND CodigoProducto = @CodigoProducto
							
							SELECT TOP 1 @FechaHoraIngreso = FechaHoraIngreso
							FROM InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroTransferenciaProducto
							AND CodigoProducto = @CodigoProducto
							ORDER BY FechaHoraIngreso ASC
							
							
							SELECT TOP 1 @PrecioUnitarioIngreso = PrecioUnitario
							FROM
							(	SELECT PrecioUnitario, FechaHoraIngreso
								FROM InventarioProductosCantidadesComprasHistorial
								WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
								AND NumeroCompraProducto <> @NumeroTransferenciaProducto
								UNION
								SELECT @PrecioUnitarioIngresoAux AS PrecioUnitario, @FechaHoraIngreso AS FechaHoraIngreso							
							) tabla
							ORDER BY FechaHoraIngreso ASC
							
							
						END					
						ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='1')	-- TRABAJAR CON LA ULTIMA TUPLA INGRESADA Y PROMEDIAR EN LA MISMA Y ELIMINAR LAS ANTIGUAS PAR ESTA COMPRA				
						BEGIN
							SELECT TOP 1 @PrecioUnitarioIngresoAux = PrecioUnitario, @FechaHoraIngreso = FechaHoraIngreso
							FROM InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroTransferenciaProducto
							AND CodigoProducto = @CodigoProducto
							ORDER BY FechaHoraIngreso ASC
							
							SELECT TOP 1 @PrecioUnitarioIngreso = PrecioUnitario
							FROM
							(
								SELECT PrecioUnitario, FechaHoraIngreso
								FROM InventarioProductosCantidadesComprasHistorial						
								WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
								AND NumeroCompraProducto <> @NumeroTransferenciaProducto
								UNION
								SELECT @PrecioUnitarioIngresoAux AS PrecioUnitario, @FechaHoraIngreso AS FechaHoraIngreso	
							) TABLA
							ORDER BY FechaHoraIngreso ASC
						
							
						END					
						ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0')-- TRABAJAR CON CADA UNA DE LAS TUPLAS DE ESTA COMPRA
						BEGIN
							SELECT TOP 1 @PrecioUnitarioIngreso = PrecioUnitario
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
							SELECT @PrecioUnitarioIngresoAux = AVG(PrecioUnitario)
							FROM InventarioProductosCantidadesComprasHistorial						
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroTransferenciaProducto
							AND CodigoProducto = @CodigoProducto
							GROUP BY NumeroAgencia,  NumeroCompraProducto, CodigoProducto
							
							SELECT @PrecioUnitarioIngreso = AVG(PrecioUnitario)
							FROM 
							(
								SELECT PrecioUnitario
								from InventarioProductosCantidadesComprasHistorial
								WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto <> @NumeroTransferenciaProducto
								AND CodigoProducto = @CodigoProducto
								UNION
								SELECT @PrecioUnitarioIngresoAux AS PrecioUnitario
							)TABLA
							
						END					
						ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='1')	-- TRABAJAR CON LA ULTIMA TUPLA INGRESADA Y PROMEDIAR EN LA MISMA Y ELIMINAR LAS ANTIGUAS PAR ESTA COMPRA				
						BEGIN
							SELECT TOP 1 @PrecioUnitarioIngresoAux = PrecioUnitario
							FROM InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroTransferenciaProducto
							AND CodigoProducto = @CodigoProducto
							ORDER BY FechaHoraIngreso DESC
							
							SELECT @PrecioUnitarioIngreso = AVG(PrecioUnitario)
							FROM 
							(
								SELECT PrecioUnitario
								from InventarioProductosCantidadesComprasHistorial
								WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto <> @NumeroTransferenciaProducto
								AND CodigoProducto = @CodigoProducto
								UNION
								SELECT @PrecioUnitarioIngresoAux AS PrecioUnitario
							)TABLA
						END					
						ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0')-- TRABAJAR CON CADA UNA DE LAS TUPLAS DE ESTA COMPRA
						BEGIN
							SELECT @PrecioUnitarioIngreso = AVG(PrecioUnitario)
							FROM InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia 
							AND CodigoProducto = @CodigoProducto
							
						END
					END
					
					ELSE IF(@CodigoTipoCalculoInventarioProducto = 'B')--Precio Mas Bajo
					BEGIN
						IF(SUBSTRING(@OpcionesActualizacion,2,1) ='1' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0') -- SACAR PROMEDIO DE LAS TUPLAS DE ESTA COMPRA
						BEGIN
							SELECT @PrecioUnitarioIngresoAux = AVG(PrecioUnitario)
							FROM InventarioProductosCantidadesComprasHistorial						
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroTransferenciaProducto
							AND CodigoProducto = @CodigoProducto
							GROUP BY NumeroAgencia,  NumeroCompraProducto, CodigoProducto
							
							SELECT TOP 1 @PrecioUnitarioIngreso = PrecioUnitario
							FROM 
							(
								SELECT PrecioUnitario
								from InventarioProductosCantidadesComprasHistorial
								WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto <> @NumeroTransferenciaProducto
								AND CodigoProducto = @CodigoProducto
								UNION
								SELECT @PrecioUnitarioIngresoAux AS PrecioUnitario
							)TABLA ORDER BY PrecioUnitario ASC
							
						END					
						ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='1')	-- TRABAJAR CON LA ULTIMA TUPLA INGRESADA Y PROMEDIAR EN LA MISMA Y ELIMINAR LAS ANTIGUAS PAR ESTA COMPRA				
						BEGIN
							SELECT TOP 1 @PrecioUnitarioIngresoAux = PrecioUnitario
							FROM InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroTransferenciaProducto
							AND CodigoProducto = @CodigoProducto
							ORDER BY FechaHoraIngreso DESC
							
							SELECT TOP 1 @PrecioUnitarioIngreso = PrecioUnitario
							FROM 
							(
								SELECT PrecioUnitario
								FROM InventarioProductosCantidadesComprasHistorial
								WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto <> @NumeroTransferenciaProducto
								AND CodigoProducto = @CodigoProducto
								UNION
								SELECT @PrecioUnitarioIngresoAux AS PrecioUnitario
							)TABLA ORDER BY PrecioUnitario ASC
						END					
						ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0')-- TRABAJAR CON CADA UNA DE LAS TUPLAS DE ESTA COMPRA
						BEGIN
							SELECT TOP 1 @PrecioUnitarioIngreso = PrecioUnitario
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
							SELECT @PrecioUnitarioIngresoAux = AVG(PrecioUnitario)
							FROM InventarioProductosCantidadesComprasHistorial						
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroTransferenciaProducto
							AND CodigoProducto = @CodigoProducto
							GROUP BY NumeroAgencia,  NumeroCompraProducto, CodigoProducto
							
							SELECT TOP 1 @PrecioUnitarioIngreso = PrecioUnitario
							FROM 
							(
								SELECT PrecioUnitario
								from InventarioProductosCantidadesComprasHistorial
								WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto <> @NumeroTransferenciaProducto
								AND CodigoProducto = @CodigoProducto
								UNION
								SELECT @PrecioUnitarioIngresoAux AS PrecioUnitario
							)TABLA ORDER BY PrecioUnitario DESC
							
						END					
						ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='1')	-- TRABAJAR CON LA ULTIMA TUPLA INGRESADA Y PROMEDIAR EN LA MISMA Y ELIMINAR LAS ANTIGUAS PAR ESTA COMPRA				
						BEGIN
							SELECT TOP 1 @PrecioUnitarioIngresoAux = PrecioUnitario
							FROM InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroTransferenciaProducto
							AND CodigoProducto = @CodigoProducto
							ORDER BY FechaHoraIngreso DESC
							
							SELECT TOP 1 @PrecioUnitarioIngreso = PrecioUnitario
							FROM 
							(
								SELECT PrecioUnitario
								from InventarioProductosCantidadesComprasHistorial
								WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto <> @NumeroTransferenciaProducto
								AND CodigoProducto = @CodigoProducto
								UNION
								SELECT @PrecioUnitarioIngresoAux AS PrecioUnitario
							)TABLA ORDER BY PrecioUnitario DESC
						END					
						ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0')-- TRABAJAR CON CADA UNA DE LAS TUPLAS DE ESTA COMPRA
						BEGIN
							SELECT TOP 1 @PrecioUnitarioIngreso = PrecioUnitario
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
							SELECT @PrecioUnitarioIngreso = AVG(PrecioUnitario)
							FROM InventarioProductosCantidadesComprasHistorial						
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroTransferenciaProducto
							AND CodigoProducto = @CodigoProducto
							GROUP BY NumeroAgencia,  NumeroCompraProducto, CodigoProducto						
							
						END					
						ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='1')	-- TRABAJAR CON LA ULTIMA TUPLA INGRESADA Y PROMEDIAR EN LA MISMA Y ELIMINAR LAS ANTIGUAS PAR ESTA COMPRA				
						BEGIN
							SELECT TOP 1 @PrecioUnitarioIngresoAux = PrecioUnitario
							FROM InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroTransferenciaProducto
							AND CodigoProducto = @CodigoProducto
							ORDER BY FechaHoraIngreso DESC						
							
						END					
						ELSE IF( SUBSTRING(@OpcionesActualizacion,2,1) ='0' AND SUBSTRING(@OpcionesActualizacion,3,1) ='0')-- TRABAJAR CON CADA UNA DE LAS TUPLAS DE ESTA COMPRA
						BEGIN
							SELECT TOP 1 @PrecioUnitarioIngreso = PrecioUnitario
							FROM InventarioProductosCantidadesComprasHistorial
							WHERE NumeroAgencia = @NumeroAgencia
							AND CodigoProducto = @CodigoProducto
							ORDER BY FechaHoraIngreso DESC
						END	
					END
					
					UPDATE InventariosProductos
						SET PrecioUnitarioCompra = @PrecioUnitarioIngreso
					WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto		
				END
				
			END
						
			
			DELETE @TProductosActualizar WHERE CodigoProducto = @CodigoProducto
			SET ROWCOUNT 1
			SELECT @CodigoProducto = CodigoProducto, @CantidadActualizar = CantidadActualizacion, @OpcionesActualizacion = Opciones  FROM @TProductosActualizar
		END
		SET ROWCOUNT 0
		
		
	END
END
GO