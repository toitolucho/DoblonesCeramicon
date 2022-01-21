--BEGIN TRANSACTION
--SET QUOTED_IDENTIFIER ON
--SET ARITHABORT ON
--SET NUMERIC_ROUNDABORT OFF
--SET CONCAT_NULL_YIELDS_NULL ON
--SET ANSI_NULLS ON
--SET ANSI_PADDING ON
--SET ANSI_WARNINGS ON
--COMMIT
--BEGIN TRANSACTION
--GO
--ALTER TABLE dbo.InventariosProductos ADD
--	PrecioValoradoTotal decimal(10, 2) NULL
--GO
--ALTER TABLE dbo.InventariosProductos ADD CONSTRAINT
--	DF_InventariosProductos_PrecioValoradoTotal DEFAULT 0 FOR PrecioValoradoTotal
--GO
--ALTER TABLE dbo.InventariosProductos SET (LOCK_ESCALATION = TABLE)
--GO
--COMMIT


DROP PROCEDURE ActualizarInventarioVentasProductos
GO

CREATE PROCEDURE ActualizarInventarioVentasProductos
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT,
	@FechaHoraVenta		DATETIME
AS
BEGIN
	BEGIN TRANSACTION 

	--INSERT INTO dbo.VentasProductosDetalleEntrega(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CantidadEntregada, FechaHoraEntrega)
	--SELECT IAD.NumeroAgencia, IAD.NumeroVentaProducto, IAD.CodigoProducto, IAD.CantidadVenta, @FechaHoraVenta
	--FROM dbo.VentasProductosDetalle IAD
	--WHERE IAD.NumeroAgencia = @NumeroAgencia
	--AND IAD.NumeroVentaProducto = @NumeroVentaProducto
	
	IF(NOT EXISTS(
		SELECT *
		FROM VentasProductosDetalleEntrega SADE
		INNER JOIN InventariosProductos IA
		ON SADE.NumeroAgencia = IA.NumeroAgencia
		AND SADE.CodigoProducto = IA.CodigoProducto
		WHERE SADE.NumeroAgencia = @NumeroAgencia
		AND SADE.NumeroVentaProducto = @NumeroVentaProducto
		AND SADE.FechaHoraEntrega = @FechaHoraVenta
		AND SADE.CantidadEntregada > IA.CantidadExistencia
	))
	BEGIN
		
	    --SE DEBE DISMINUIR E INCLUSO ELIMINAR EL HISTORIAL DE INVENTARIOS
		--DE ACUERDO AL TIPO DE CALCULO CORRESPONDIENTES, 'UEPS','PEUS', ETC				
		DECLARE @TVentaProductosAux	TABLE
		(
			NumeroAgencia		INT,
			CodigoProducto		CHAR(15),
			CantidadVenta		INT,
			FechaHoraEntrega	DATETIME
		)	
		
		INSERT INTO @TVentaProductosAux (NumeroAgencia, CodigoProducto, CantidadVenta, FechaHoraEntrega)
		SELECT NumeroAgencia, CodigoProducto, CantidadEntregada, FechaHoraEntrega
		FROM dbo.VentasProductosDetalleEntrega  SADE
		WHERE SADE.NumeroAgencia = @NumeroAgencia
		AND SADE.NumeroVentaProducto = @NumeroVentaProducto
		AND SADE.FechaHoraEntrega = @FechaHoraVenta
		
		
		DECLARE @CodigoProducto				CHAR(15),
				@NumeroAgenciaCP			INT,
				@CantidadVenta				INT
				
		
		SET ROWCOUNT 1
		SELECT @CodigoProducto = CodigoProducto, @CantidadVenta = CantidadVenta, @NumeroAgenciaCP = NumeroAgencia 
		FROM @TVentaProductosAux				
		WHILE @@rowcount <> 0
		BEGIN
			
			
			EXEC ActualizarEliminarInventarioProductosCantidadesTransaccionesHistorial @NumeroAgenciaCP, @CodigoProducto, @CantidadVenta, @NumeroVentaProducto, @FechaHoraVenta
			
			DELETE @TVentaProductosAux WHERE CodigoProducto = @CodigoProducto
			SET ROWCOUNT 1
			SELECT @CodigoProducto = CodigoProducto, @CantidadVenta = CantidadVenta, @NumeroAgenciaCP = NumeroAgencia 
			FROM @TVentaProductosAux	
		END
		SET ROWCOUNT 0	
		
		
		UPDATE InventariosProductos
			SET CantidadExistencia = CantidadExistencia - SADE.CantidadEntregada,
				PrecioValoradoTotal = PrecioValoradoTotal - SADE.PrecioUnitarioIngresoInventario
		FROM 
		(
			SELECT SADE.NumeroAgencia, SADE.NumeroVentaProducto, SADE.CodigoProducto, 
				   SUM(SADE.CantidadEntregada) AS CantidadEntregada,
				   SUM(SADE.CantidadEntregada * SADE.PrecioUnitarioCompraInventario) AS PrecioUnitarioIngresoInventario
			FROM dbo.VentasProductosDetalleEntrega SADE
			WHERE SADE.NumeroAgencia = @NumeroAgencia
			AND SADE.NumeroVentaProducto = @NumeroVentaProducto
			AND SADE.FechaHoraEntrega = @FechaHoraVenta	
			GROUP BY SADE.NumeroAgencia, SADE.NumeroVentaProducto, SADE.CodigoProducto		
		)SADE
		WHERE InventariosProductos.NumeroAgencia = @NumeroAgencia
		AND InventariosProductos.CodigoProducto = SADE.CodigoProducto
		
		UPDATE dbo.VentasProductos
			SET FechaHoraEntrega = @FechaHoraVenta
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroVentaProducto = @NumeroVentaProducto
		
		
		
		IF(EXISTS (SELECT * FROM VentasProductosDetalle 
				   WHERE dbo.ObtenerCodigoTipoCalculoInventarioProducto(VentasProductosDetalle.CodigoProducto) IN ('P','U')
					AND VentasProductosDetalle.NumeroAgencia = @NumeroAgencia
					AND VentasProductosDetalle.NumeroVentaProducto = @NumeroVentaProducto))
		BEGIN
		
			UPDATE VentasProductosDetalle
				SET PrecioUnitarioVenta = ISNULL((SELECT SUM(SADE.CantidadEntregada * SADE.PrecioUnitarioCompraInventario)/ ISNULL(SUM(SADE.CantidadEntregada), 1)
											FROM VentasProductosDetalleEntrega SADE
											WHERE SADE.NumeroAgencia = @NumeroAgencia
											AND SADE.NumeroVentaProducto = @NumeroVentaProducto
											AND SADE.CodigoProducto = VentasProductosDetalle.CodigoProducto), PrecioUnitarioVenta)
			WHERE dbo.ObtenerCodigoTipoCalculoInventarioProducto(VentasProductosDetalle.CodigoProducto) IN ('P','U')
			AND VentasProductosDetalle.NumeroAgencia = @NumeroAgencia
			AND VentasProductosDetalle.NumeroVentaProducto = @NumeroVentaProducto
			
			--UPDATE VentasProductosDetalle
			--	SET PrecioUnitarioVenta = ISNULL((SELECT SUM(SADE.CantidadEntregada * SADE.PrecioUnitarioIngresoInventario)/ ISNULL(SUM(SADE.CantidadEntregada), 1)
			--								), PrecioUnitarioVenta)
			--FROM VentasProductosDetalleEntrega SADE
			
			--WHERE SADE.NumeroAgencia = @NumeroAgencia
			--AND SADE.NumeroVentaProducto = @NumeroVentaProducto
			--AND SADE.CodigoProducto = VentasProductosDetalle.CodigoProducto
			--AND dbo.ObtenerCodigoTipoCalculoInventarioProducto(SADE.CodigoProducto) IN ('P','U')
			--AND VentasProductosDetalle.NumeroAgencia = SADE.NumeroAgencia
			--AND VentasProductosDetalle.NumeroVentaProducto = SADE.NumeroVentaProducto
			--AND VentasProductosDetalle.NumeroAgencia = @NumeroAgencia
			--AND VentasProductosDetalle.NumeroVentaProducto = @NumeroVentaProducto
			--GROUP BY SADE.NumeroAgencia, SADE.NumeroVentaProducto, SADE.CodigoProducto
			
			--UPDATE VentasProductosDetalleEntrega
			--	SET PrecioUnitarioIngresoInventario = TAUX.PrecioPromedio
			--FROM
			--(
			--	SELECT	SADE.NumeroAgencia, SADE.NumeroVentaProducto, SADE.CodigoProducto, 
			--			ISNULL((SELECT SUM(SADE.CantidadEntregada * SADE.PrecioUnitarioIngresoInventario)/ ISNULL(SUM(SADE.CantidadEntregada), 1)), -1) AS PrecioPromedio
			--	FROM VentasProductosDetalleEntrega SADE
			--	WHERE SADE.NumeroAgencia = @NumeroAgencia
			--	AND SADE.NumeroVentaProducto = @NumeroVentaProducto				
			--	AND dbo.ObtenerCodigoTipoCalculoInventarioProducto(SADE.CodigoProducto) IN ('P','U')
			--	GROUP BY SADE.NumeroAgencia, SADE.NumeroVentaProducto, SADE.CodigoProducto
			--)TAUX
			--WHERE TAUX.NumeroAgencia = VentasProductosDetalleEntrega.NumeroAgencia
			--AND TAUX.NumeroVentaProducto = VentasProductosDetalleEntrega.NumeroVentaProducto
			--AND TAUX.CodigoProducto = VentasProductosDetalleEntrega.CodigoProducto
			--AND VentasProductosDetalleEntrega.NumeroAgencia = @NumeroAgencia
			--AND VentasProductosDetalleEntrega.NumeroVentaProducto = @NumeroVentaProducto
		
			UPDATE VentasProductos
				SET MontoTotalVenta = ISNULL(( SELECT SUM(SAD.PrecioUnitarioCompraInventario * SAD.CantidadEntregada)
										 FROM VentasProductosDetalleEntrega SAD
										 WHERE NumeroAgencia = @NumeroAgencia
										 AND NumeroVentaProducto = @NumeroVentaProducto),0)
			WHERE VentasProductos.NumeroAgencia = @NumeroAgencia
			AND VentasProductos.NumeroVentaProducto = @NumeroVentaProducto
		END
		
		IF(EXISTS(
			SELECT *	
			FROM VentasProductosDetalle SAD
			INNER JOIN InventariosProductos IA
			ON SAD.CodigoProducto = IA.CodigoProducto
			AND SAD.NumeroAgencia = IA.NumeroAgencia
			WHERE (IA.CantidadExistencia)< IA.StockMinimo
			AND SAD.NumeroAgencia = @NumeroAgencia
			AND SAD.NumeroVentaProducto = @NumeroVentaProducto
		))
		BEGIN
			UPDATE InventariosProductos
				SET CantidadRequerida = CantidadRequerida + (StockMinimo - CantidadExistencia)
			FROM dbo.VentasProductosDetalleEntrega SADE
			WHERE SADE.NumeroAgencia = @NumeroAgencia
			AND SADE.NumeroVentaProducto = @NumeroVentaProducto
			AND SADE.FechaHoraEntrega = @FechaHoraVenta
			AND InventariosProductos.NumeroAgencia = @NumeroAgencia
			AND InventariosProductos.CodigoProducto = SADE.CodigoProducto
			AND InventariosProductos.CantidadExistencia < InventariosProductos.StockMinimo
		END
		
		UPDATE InventariosProductosEspecificos
			SET CodigoEstado = 'V'				
		FROM VentasProductosEspecificos SAE
		WHERE SAE.NumeroAgencia = @NumeroAgencia
		AND SAE.NumeroVentaProducto = @NumeroVentaProducto
		AND SAE.FechaHoraEntrega = @FechaHoraVenta
		AND InventariosProductosEspecificos.NumeroAgencia = @NumeroAgencia
		AND InventariosProductosEspecificos.CodigoProducto = SAE.CodigoProducto
		AND InventariosProductosEspecificos.CodigoProductoEspecifico = SAE.CodigoProductoEspecifico
		
		UPDATE VentasProductosEspecificos
			SET Entregado = 1
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroVentaProducto = @NumeroVentaProducto
		AND FechaHoraEntrega = @FechaHoraVenta
	END
	ELSE
	BEGIN
		RAISERROR('No se Pudo Actualizar la Venta de Productos, debido a la Insuficiente existencia de Productos',1,16)	
	END
	
		IF(@@ERROR <> 0)
	BEGIN
		RAISERROR('No se Pudo Actualizar el Venta de Productos',1,16)	
		ROLLBACK TRAN
	END
	ELSE
		COMMIT TRANSACTION

END
GO