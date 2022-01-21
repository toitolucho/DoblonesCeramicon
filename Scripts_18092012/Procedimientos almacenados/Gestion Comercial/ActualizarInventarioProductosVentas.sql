USE DOBLONES20
GO

DROP PROCEDURE ActualizarInventarioProductosVentas
GO

CREATE PROCEDURE ActualizarInventarioProductosVentas
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT
AS
BEGIN
DECLARE 
	@CodigoProducto				CHAR(15),
	@CantidadVenta				INT,
	@CantidadEntregada			INT,
	@CodigoProductoEspecifico	CHAR(30),
	@PrimerIndice				INT,
	@CantidadExistencia			INT,
	@CantRequeridosAnteriores	INT,
	@CodigoEstadoVenta			CHAR(1),
	@FechaHoraEntrega			DATETIME = GETDATE()
	
	SET ROWCOUNT 0
	IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'#mytemp') AND OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		DROP TABLE #mytemp
	END
	
	SELECT @CodigoEstadoVenta  = CodigoEstadoVenta FROM VentasProductos
	WHERE (NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroVentaProducto)
	
	SELECT * INTO #mytemp FROM VentasProductosDetalle
	WHERE (NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroVentaProducto)

	SET ROWCOUNT 1
	SELECT @CodigoProducto = CodigoProducto, @CantidadVenta = CantidadVenta, @CantidadEntregada = CantidadEntregada FROM #mytemp
	
	
	
	--BEGIN TRAN
	
	WHILE @@rowcount <> 0
	BEGIN		
		--BEGIN -- Solo actualizamos inventarios de los productos q NO SON ESPECIFICOS,
			-- Debido que mas abajo, existe un un segmento de codigo que se encarga especificamente de realizar la actualizaciçon de los productos ESPECIFICOS
			
		SELECT @CantidadExistencia = CantidadExistencia FROM InventariosProductos WHERE CodigoProducto = @CodigoProducto
		
		IF( @CantidadVenta = @CantidadEntregada AND (@CantidadExistencia - @CantidadEntregada) > 0)
		BEGIN
			UPDATE dbo.InventariosProductos			
			SET CantidadExistencia = CantidadExistencia - @CantidadVenta
			WHERE NumeroAgencia = @NumeroAgencia and CodigoProducto = @CodigoProducto
			
			exec ActualizarEliminarInventarioProductosCantidadesComprasHistorial @NumeroAgencia, @CodigoProducto, @CantidadVenta		
		END
		ELSE
		BEGIN	
			
			IF(@CantidadExistencia > @CantidadVenta)
			BEGIN
				UPDATE dbo.InventariosProductos			
				SET CantidadExistencia = CantidadExistencia - @CantidadEntregada
				WHERE NumeroAgencia = @NumeroAgencia and CodigoProducto = @CodigoProducto
				
				exec ActualizarEliminarInventarioProductosCantidadesComprasHistorial @NumeroAgencia, @CodigoProducto, @CantidadEntregada
			END
			ELSE
			BEGIN
				SELECT  @CantRequeridosAnteriores =  SUM(VPD.CantidadVenta - VPD.CantidadEntregada)
				FROM VentasProductosDetalle VPD 
				INNER JOIN VentasProductos VP 
				ON VP.NumeroAgencia = VPD.NumeroAgencia 
				AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
				WHERE CantidadVenta <> CantidadEntregada 
				AND (VP.CodigoEstadoVenta = 'P' OR VP.CodigoEstadoVenta = 'C' OR VP.CodigoEstadoVenta = 'F' OR VP.CodigoEstadoVenta = 'D') 
				AND VPD.NumeroVentaProducto <> @NumeroVentaProducto 
				AND VPD.NumeroAgencia = @NumeroAgencia
				AND VPD.CodigoProducto = @CodigoProducto
				GROUP BY  VPD.CodigoProducto
				
				IF(@CantRequeridosAnteriores IS NULL)
					SET @CantRequeridosAnteriores = 0
				UPDATE dbo.InventariosProductos			
				SET CantidadExistencia = CantidadExistencia - @CantidadEntregada,
					--CantidadRequerida += @CantidadVenta - @CantidadEntregada - (CantidadExistencia - @CantidadEntregada)
					CantidadRequerida = @CantRequeridosAnteriores + @CantidadVenta - @CantidadExistencia
				WHERE NumeroAgencia = @NumeroAgencia and CodigoProducto = @CodigoProducto				
			END
		END
		
		IF(@CantidadEntregada > 0)
			EXEC InsertarVentaProductoDetalleEntrega @NumeroAgencia, @NumeroVentaProducto, @CodigoProducto, @FechaHoraEntrega, @CantidadEntregada
		
		DELETE #mytemp WHERE @CodigoProducto = CodigoProducto
		SET ROWCOUNT 1
		SELECT @CodigoProducto = CodigoProducto, @CantidadVenta = CantidadVenta, @CantidadEntregada = CantidadEntregada FROM #mytemp
	END
	SET ROWCOUNT 0
	IF EXISTS( SELECT * FROM dbo.sysobjects where id = object_id(N'#mytemp') AND OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		DROP TABLE #mytemp
	END
	
	--------------------Productos Agregados
	
	SELECT CodigoProducto, CodigoProductoEspecifico INTO #mytemp2
	FROM VentasProductosEspecificosAgregados
	WHERE (NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroVentaProducto)
	GROUP BY CodigoProducto, CodigoProductoEspecifico
	
	SET @PrimerIndice = 0;
	SET @CantidadVenta = 1;
	SET ROWCOUNT 1
	SELECT @CodigoProducto = CodigoProducto, @CodigoProductoEspecifico = CodigoProductoEspecifico FROM #mytemp2

	WHILE @@rowcount <> 0
	BEGIN
		UPDATE InventariosProductosEspecificos
			SET CodigoEstado = 'V'
		WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto AND CodigoProductoEspecifico = @CodigoProductoEspecifico
				
		DELETE #mytemp2 WHERE @CodigoProductoEspecifico = CodigoProductoEspecifico
		SET ROWCOUNT 1
		IF(EXISTS (SELECT * FROM #mytemp2 WHERE @CodigoProducto = CodigoProducto))
		BEGIN
			SET @PrimerIndice = @PrimerIndice + 1;
			SET @CantidadVenta = @CantidadVenta +1
		END
		ELSE
		BEGIN		
			UPDATE dbo.InventariosProductos
			SET CantidadExistencia = CantidadExistencia - @CantidadVenta
			WHERE NumeroAgencia = @NumeroAgencia and CodigoProducto = @CodigoProducto	
			SET @PrimerIndice = 0;
			SET @CantidadVenta = 1;
		END
		SELECT @CodigoProducto = CodigoProducto, @CodigoProductoEspecifico = CodigoProductoEspecifico FROM #mytemp2
	END
	SET ROWCOUNT 0
	IF EXISTS( SELECT * FROM dbo.sysobjects where id = object_id(N'#mytemp2') AND OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		DROP TABLE #mytemp2
	END
	
	
	--Begin Venta Productos Especificos
	SELECT CodigoProductoEspecifico, CodigoProducto INTO #mytemp3
	FROM VentasProductosEspecificos
	WHERE (NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroVentaProducto)
	ORDER BY CodigoProducto
	

	SET ROWCOUNT 1
	SELECT @CodigoProductoEspecifico = CodigoProductoEspecifico, @CodigoProducto = CodigoProducto FROM #mytemp3

	WHILE @@rowcount <> 0
	BEGIN
		UPDATE dbo.InventariosProductosEspecificos
			SET CodigoEstado = 'V'
		WHERE NumeroAgencia = @NumeroAgencia and CodigoProducto = @CodigoProducto AND (CodigoProductoEspecifico = @CodigoProductoEspecifico)
		
		UPDATE dbo.VentasProductosEspecificos
			SET FechaHoraEntrega = @FechaHoraEntrega
		WHERE NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = NumeroVentaProducto AND CodigoProducto = @CodigoProducto
				AND Entregado = 0
		
		DELETE #mytemp3 WHERE @CodigoProductoEspecifico = CodigoProductoEspecifico
		SET ROWCOUNT 1
		SELECT @CodigoProductoEspecifico = CodigoProductoEspecifico, @CodigoProducto = CodigoProducto FROM #mytemp3
	END	
	
	SET ROWCOUNT 0
	IF EXISTS( SELECT * FROM dbo.sysobjects where id = object_id(N'#mytemp3') AND OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		DROP TABLE #mytemp3
	END	
	--End
	
	--IF (@@error<> 0) 
	--	BEGIN
	--	  ROLLBACK TRAN
	--	  RAISERROR ('No se puedo realizar la transaccion, Ocurrio un error al momento de Actualizar Inventarios',16,2)
	--	END
	--COMMIT TRAN	
	
END
GO



--EXEC ActualizarInventarioProductosVentas 1, 5