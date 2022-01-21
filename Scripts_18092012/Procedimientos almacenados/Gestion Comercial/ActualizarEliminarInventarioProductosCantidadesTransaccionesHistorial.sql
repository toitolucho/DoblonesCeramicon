USE Doblones20
GO

DROP PROCEDURE ActualizarEliminarInventarioProductosCantidadesTransaccionesHistorial
GO

CREATE PROCEDURE ActualizarEliminarInventarioProductosCantidadesTransaccionesHistorial
	@NumeroAgencia			INT,	
	@CodigoProducto			CHAR(15),
	@CantidadEgreso			INT,
	@NumeroTransaccion		INT,
	@FechaHoraEntrega		DATETIME
AS
BEGIN
	DECLARE	@CodigoTipoCalculoInventario	CHAR(1),
			@ContadorCantidades				INT = 0,
			@CantidadExistente				INT,
			@FechaHoraIngreso				DATETIME,
			@PrecioUnitario					DECIMAL(10,3)
	
	SET @CodigoTipoCalculoInventario = dbo.ObtenerCodigoTipoCalculoInventarioProducto(@CodigoProducto)	 
	--U'->UEPS, 'P'->PEPS, 'O'->Ponderado, 'B'-> Precio mas Bajo, 'A'->Precio mas alto, 'T'-> Ultimo Precio
	IF(@CodigoTipoCalculoInventario = 'U')--UEPS	
	BEGIN
		SELECT TOP 1 @CantidadExistente = CantidadExistente, @FechaHoraIngreso = FechaHoraIngreso, @PrecioUnitario =PrecioUnitario
		FROM dbo.InventarioProductosCantidadesComprasHistorial
		WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
		ORDER BY FechaHoraIngreso DESC, NumeroCompraProducto DESC
		
		IF(@CantidadExistente > @CantidadEgreso)
		BEGIN
			UPDATE TOP(1) InventarioProductosCantidadesComprasHistorial 
				SET CantidadExistente -= @CantidadEgreso
			WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
			AND FechaHoraIngreso = @FechaHoraIngreso
			
			UPDATE TOP(1) VentasProductosDetalleEntrega
				SET PrecioUnitarioCompraInventario = @PrecioUnitario,
					FechaHoraCompraInventario = @FechaHoraIngreso
			WHERE NumeroAgencia = @NumeroAgencia
			AND NumeroVentaProducto = @NumeroTransaccion
			AND CodigoProducto = @CodigoProducto
			AND FechaHoraEntrega = @FechaHoraEntrega
			
		END
		ELSE IF(@CantidadExistente IS NOT NULL)
		BEGIN
		
			DELETE FROM VentasProductosDetalleEntrega
			WHERE NumeroAgencia  = @NumeroAgencia
			AND NumeroVentaProducto = @NumeroTransaccion
			AND CodigoProducto = @CodigoProducto
			AND FechaHoraEntrega = @FechaHoraEntrega
			
			WHILE( @CantidadEgreso >= @CantidadExistente )
			BEGIN
			
				IF(NOT EXISTS(SELECT * FROM VentasProductosDetalleEntrega
						WHERE NumeroAgencia  = @NumeroAgencia
					AND NumeroVentaProducto = @NumeroTransaccion
					AND CodigoProducto = @CodigoProducto
					AND FechaHoraEntrega = @FechaHoraEntrega 
					AND FechaHoraCompraInventario = @FechaHoraIngreso))
				BEGIN
					INSERT INTO dbo.VentasProductosDetalleEntrega (NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada, PrecioUnitarioCompraInventario, FechaHoraCompraInventario)
					VALUES (@NumeroAgencia, @NumeroTransaccion, @CodigoProducto, @FechaHoraEntrega, @CantidadExistente, @PrecioUnitario, @FechaHoraIngreso)
				END
				ELSE
				BEGIN
					INSERT INTO dbo.VentasProductosDetalleEntrega (NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada, PrecioUnitarioCompraInventario, FechaHoraCompraInventario)
					VALUES (@NumeroAgencia, @NumeroTransaccion, @CodigoProducto, @FechaHoraEntrega, @CantidadExistente, @PrecioUnitario, DATEADD(MILLISECOND, 1, @FechaHoraIngreso))
				END
				DELETE TOP (1)
				FROM InventarioProductosCantidadesComprasHistorial				
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				AND FechaHoraIngreso = @FechaHoraIngreso
				
				SET @CantidadEgreso -=  @CantidadExistente
				
				SELECT TOP 1 @CantidadExistente = CantidadExistente, @FechaHoraIngreso = FechaHoraIngreso, @PrecioUnitario = PrecioUnitario
				FROM dbo.InventarioProductosCantidadesComprasHistorial
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				ORDER BY FechaHoraIngreso DESC, NumeroCompraProducto DESC
				
				IF(@CantidadExistente IS NULL)
					BREAK
				
			END
			
			IF(@CantidadEgreso > 0)
			BEGIN
				IF(NOT EXISTS(SELECT * FROM VentasProductosDetalleEntrega
						WHERE NumeroAgencia  = @NumeroAgencia
					AND NumeroVentaProducto = @NumeroTransaccion
					AND CodigoProducto = @CodigoProducto
					AND FechaHoraEntrega = @FechaHoraEntrega 
					AND FechaHoraCompraInventario = @FechaHoraIngreso))
				BEGIN
					INSERT INTO dbo.VentasProductosDetalleEntrega (NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada, PrecioUnitarioCompraInventario, FechaHoraCompraInventario)
					VALUES (@NumeroAgencia, @NumeroTransaccion, @CodigoProducto, @FechaHoraEntrega, @CantidadEgreso, @PrecioUnitario, @FechaHoraIngreso)
				END
				ELSE
				BEGIN
					INSERT INTO dbo.VentasProductosDetalleEntrega (NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada, PrecioUnitarioCompraInventario, FechaHoraCompraInventario)
					VALUES (@NumeroAgencia, @NumeroTransaccion, @CodigoProducto, @FechaHoraEntrega, @CantidadEgreso, @PrecioUnitario, DATEADD(MILLISECOND, 1, @FechaHoraIngreso))
				END
				
			
				--INSERT INTO dbo.VentasProductosDetalleEntrega (NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada, PrecioUnitarioCompraInventario, FechaHoraCompraInventario)
				--VALUES (@NumeroAgencia, @NumeroTransaccion, @CodigoProducto, @FechaHoraEntrega, @CantidadEgreso, @PrecioUnitario, @FechaHoraIngreso)
			
				UPDATE TOP(1) InventarioProductosCantidadesComprasHistorial 
				SET CantidadExistente -= @CantidadEgreso
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				AND FechaHoraIngreso = @FechaHoraIngreso	
			END
		END
		ELSE 
		BEGIN
			UPDATE VentasProductosDetalleEntrega
				SET VentasProductosDetalleEntrega.PrecioUnitarioCompraInventario = SAD.PrecioUnitarioVenta
			FROM VentasProductosDetalle SAD
			WHERE SAD.NumeroAgencia = @NumeroAgencia
			AND SAD.NumeroVentaProducto = @NumeroTransaccion
			AND SAD.CodigoProducto = @CodigoProducto
			AND VentasProductosDetalleEntrega.CodigoProducto = @CodigoProducto
			AND VentasProductosDetalleEntrega.FechaHoraEntrega = @FechaHoraEntrega
		END
	END
	
	ELSE IF(@CodigoTipoCalculoInventario = 'P')	--PEPS
	BEGIN
		SELECT TOP 1 @CantidadExistente = CantidadExistente, @FechaHoraIngreso = FechaHoraIngreso, @PrecioUnitario = PrecioUnitario
		FROM dbo.InventarioProductosCantidadesComprasHistorial
		WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
		ORDER BY FechaHoraIngreso ASC, NumeroCompraProducto ASC
		
		IF(@CantidadExistente > @CantidadEgreso)
		BEGIN
			UPDATE TOP(1) InventarioProductosCantidadesComprasHistorial 
				SET CantidadExistente -= @CantidadEgreso
			WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
			AND FechaHoraIngreso = @FechaHoraIngreso
			
			UPDATE TOP(1) VentasProductosDetalleEntrega
				SET PrecioUnitarioCompraInventario = @PrecioUnitario,
					FechaHoraCompraInventario = @FechaHoraIngreso
			WHERE NumeroAgencia = @NumeroAgencia
			AND NumeroVentaProducto = @NumeroTransaccion
			AND CodigoProducto = @CodigoProducto
			AND FechaHoraEntrega = @FechaHoraEntrega
		END
		ELSE IF(@CantidadExistente IS NOT NULL)
		BEGIN
			
			DELETE FROM VentasProductosDetalleEntrega
			WHERE NumeroAgencia  = @NumeroAgencia
			AND NumeroVentaProducto = @NumeroTransaccion
			AND CodigoProducto = @CodigoProducto
			AND FechaHoraEntrega = @FechaHoraEntrega
			
			WHILE( @CantidadEgreso >= @CantidadExistente )
			BEGIN
				IF(NOT EXISTS(SELECT * FROM VentasProductosDetalleEntrega
						WHERE NumeroAgencia  = @NumeroAgencia
					AND NumeroVentaProducto = @NumeroTransaccion
					AND CodigoProducto = @CodigoProducto
					AND FechaHoraEntrega = @FechaHoraEntrega 
					AND FechaHoraCompraInventario = @FechaHoraIngreso))
				BEGIN
					INSERT INTO dbo.VentasProductosDetalleEntrega (NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada, PrecioUnitarioCompraInventario, FechaHoraCompraInventario)
					VALUES (@NumeroAgencia, @NumeroTransaccion, @CodigoProducto, @FechaHoraEntrega, @CantidadExistente, @PrecioUnitario, @FechaHoraIngreso)
				END
				ELSE
				BEGIN
					INSERT INTO dbo.VentasProductosDetalleEntrega (NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada, PrecioUnitarioCompraInventario, FechaHoraCompraInventario)
					VALUES (@NumeroAgencia, @NumeroTransaccion, @CodigoProducto, @FechaHoraEntrega, @CantidadExistente, @PrecioUnitario, DATEADD(MILLISECOND, 1, @FechaHoraIngreso))
				END
				
				DELETE TOP (1)
				FROM InventarioProductosCantidadesComprasHistorial				
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				AND FechaHoraIngreso = @FechaHoraIngreso
				
				SET @CantidadEgreso -=  @CantidadExistente
				
				SELECT TOP 1 @CantidadExistente = CantidadExistente, @FechaHoraIngreso = FechaHoraIngreso, @PrecioUnitario = PrecioUnitario
				FROM dbo.InventarioProductosCantidadesComprasHistorial
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				ORDER BY FechaHoraIngreso ASC, NumeroCompraProducto ASC
				
				IF(@CantidadExistente IS NULL)
					BREAK
				
			END
			
			IF(@CantidadEgreso > 0)
			BEGIN
				
				IF(NOT EXISTS(SELECT * FROM VentasProductosDetalleEntrega
						WHERE NumeroAgencia  = @NumeroAgencia
					AND NumeroVentaProducto = @NumeroTransaccion
					AND CodigoProducto = @CodigoProducto
					AND FechaHoraEntrega = @FechaHoraEntrega 
					AND FechaHoraCompraInventario = @FechaHoraIngreso))
				BEGIN
					INSERT INTO dbo.VentasProductosDetalleEntrega (NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada, PrecioUnitarioCompraInventario, FechaHoraCompraInventario)
					VALUES (@NumeroAgencia, @NumeroTransaccion, @CodigoProducto, @FechaHoraEntrega, @CantidadEgreso, @PrecioUnitario, @FechaHoraIngreso)
				END
				ELSE
				BEGIN
					INSERT INTO dbo.VentasProductosDetalleEntrega (NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada, PrecioUnitarioCompraInventario, FechaHoraCompraInventario)
					VALUES (@NumeroAgencia, @NumeroTransaccion, @CodigoProducto, @FechaHoraEntrega, @CantidadEgreso, @PrecioUnitario, DATEADD(MILLISECOND, 1, @FechaHoraIngreso))
				END
				
			
				UPDATE TOP(1) InventarioProductosCantidadesComprasHistorial 
				SET CantidadExistente -= @CantidadEgreso
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				AND FechaHoraIngreso = @FechaHoraIngreso	
			END
		END
		ELSE 
		BEGIN
			UPDATE VentasProductosDetalleEntrega
				SET VentasProductosDetalleEntrega.PrecioUnitarioCompraInventario = SAD.PrecioUnitarioVenta
			FROM VentasProductosDetalle SAD
			WHERE SAD.NumeroAgencia = @NumeroAgencia
			AND SAD.NumeroVentaProducto = @NumeroTransaccion
			AND SAD.CodigoProducto = @CodigoProducto
			AND VentasProductosDetalleEntrega.CodigoProducto = @CodigoProducto
			AND VentasProductosDetalleEntrega.FechaHoraEntrega = @FechaHoraEntrega
		END
	END
	
	ELSE IF(@CodigoTipoCalculoInventario = 'O')	--Ponderado
	BEGIN
	
		SELECT TOP 1 @CantidadExistente = CantidadExistente, @FechaHoraIngreso = FechaHoraIngreso, @PrecioUnitario = PrecioUnitario
		FROM dbo.InventarioProductosCantidadesComprasHistorial
		WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
		ORDER BY FechaHoraIngreso DESC, NumeroCompraProducto ASC
		
		UPDATE VentasProductosDetalleEntrega
			SET PrecioUnitarioCompraInventario = @PrecioUnitario,
				FechaHoraCompraInventario = @FechaHoraIngreso
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroVentaProducto = @NumeroTransaccion
		AND CodigoProducto = @CodigoProducto
		AND FechaHoraEntrega = @FechaHoraEntrega			
		
		IF(@CantidadExistente > @CantidadEgreso)
		BEGIN
			UPDATE TOP(1) InventarioProductosCantidadesComprasHistorial 
				SET CantidadExistente -= @CantidadEgreso
			WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
			AND FechaHoraIngreso = @FechaHoraIngreso
			
		END
		ELSE
		BEGIN
			
			WHILE( @CantidadEgreso >= @CantidadExistente )
			BEGIN
				DELETE TOP (1)
				FROM InventarioProductosCantidadesComprasHistorial				
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				AND FechaHoraIngreso = @FechaHoraIngreso
				
				SET @CantidadEgreso -=  @CantidadExistente
				
				SELECT TOP 1 @CantidadExistente = CantidadExistente, @FechaHoraIngreso = FechaHoraIngreso
				FROM dbo.InventarioProductosCantidadesComprasHistorial
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				ORDER BY FechaHoraIngreso DESC, NumeroCompraProducto DESC
				
				IF(@CantidadExistente IS NULL)
					BREAK
				
			END
			
			IF(@CantidadEgreso > 0)
				UPDATE TOP(1) InventarioProductosCantidadesComprasHistorial 
				SET CantidadExistente -= @CantidadEgreso
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				AND FechaHoraIngreso = @FechaHoraIngreso	
			
		END
	END
	
	ELSE IF(@CodigoTipoCalculoInventario = 'B')	--Precio mas Bajo, DISEMINUYE EL DE PRECIO MAS ALTO
	BEGIN
		SELECT TOP 1 @CantidadExistente = CantidadExistente, @FechaHoraIngreso = FechaHoraIngreso
		FROM dbo.InventarioProductosCantidadesComprasHistorial
		WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
		ORDER BY PrecioUnitario DESC, NumeroCompraProducto ASC
		
		IF(@CantidadExistente > @CantidadEgreso)
		BEGIN
			UPDATE TOP(1) InventarioProductosCantidadesComprasHistorial 
				SET CantidadExistente -= @CantidadEgreso
			WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
			AND FechaHoraIngreso = @FechaHoraIngreso
		END
		ELSE
		BEGIN
			
			WHILE( @CantidadEgreso >= @CantidadExistente )
			BEGIN
				DELETE TOP (1)
				FROM InventarioProductosCantidadesComprasHistorial				
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				AND FechaHoraIngreso = @FechaHoraIngreso
				
				SET @CantidadEgreso -=  @CantidadExistente
				
				SELECT TOP 1 @CantidadExistente = CantidadExistente, @FechaHoraIngreso = FechaHoraIngreso
				FROM dbo.InventarioProductosCantidadesComprasHistorial
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				ORDER BY PrecioUnitario DESC, NumeroCompraProducto ASC
				
				IF(@CantidadExistente IS NULL)
					BREAK				
			END
			
			IF(@CantidadEgreso > 0)
				UPDATE TOP(1) InventarioProductosCantidadesComprasHistorial 
				SET CantidadExistente -= @CantidadEgreso
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				AND FechaHoraIngreso = @FechaHoraIngreso	
			
		END
	END
	
	ELSE IF(@CodigoTipoCalculoInventario = 'A')	--Precio mas Alto, DISMINUYE EL DE PRECIO MAS BAJO
	BEGIN
		SELECT TOP 1 @CantidadExistente = CantidadExistente, @FechaHoraIngreso = FechaHoraIngreso
		FROM dbo.InventarioProductosCantidadesComprasHistorial
		WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
		ORDER BY PrecioUnitario ASC
		
		IF(@CantidadExistente > @CantidadEgreso)
		BEGIN
			UPDATE TOP(1) InventarioProductosCantidadesComprasHistorial 
				SET CantidadExistente -= @CantidadEgreso
			WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
			AND FechaHoraIngreso = @FechaHoraIngreso
		END
		ELSE
		BEGIN
			
			WHILE( @CantidadEgreso >= @CantidadExistente )
			BEGIN
				DELETE TOP (1)
				FROM InventarioProductosCantidadesComprasHistorial				
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				AND FechaHoraIngreso = @FechaHoraIngreso
				
				SET @CantidadEgreso -=  @CantidadExistente
				
				SELECT TOP 1 @CantidadExistente = CantidadExistente, @FechaHoraIngreso = FechaHoraIngreso
				FROM dbo.InventarioProductosCantidadesComprasHistorial
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				ORDER BY PrecioUnitario ASC
				
				IF(@CantidadExistente IS NULL)
					BREAK
			END
			
			IF(@CantidadEgreso > 0)
				UPDATE TOP(1) InventarioProductosCantidadesComprasHistorial 
				SET CantidadExistente -= @CantidadEgreso
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				AND FechaHoraIngreso = @FechaHoraIngreso	
			
		END
	END
	
	ELSE IF(@CodigoTipoCalculoInventario = 'T')	--Precio Ultimo de Compra, DISMINUYE EL DE PRECIO MAS BAJO
	BEGIN
		SELECT TOP 1 @CantidadExistente = CantidadExistente, @FechaHoraIngreso = FechaHoraIngreso
		FROM dbo.InventarioProductosCantidadesComprasHistorial
		WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
		ORDER BY FechaHoraIngreso ASC, NumeroCompraProducto ASC
		
		IF(@CantidadExistente > @CantidadEgreso)
		BEGIN
			UPDATE TOP(1) InventarioProductosCantidadesComprasHistorial 
				SET CantidadExistente -= @CantidadEgreso
			WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
			AND FechaHoraIngreso = @FechaHoraIngreso
		END
		ELSE
		BEGIN
			
			WHILE( @CantidadEgreso >= @CantidadExistente )
			BEGIN
				DELETE TOP (1)
				FROM InventarioProductosCantidadesComprasHistorial				
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				AND FechaHoraIngreso = @FechaHoraIngreso
				
				SET @CantidadEgreso -=  @CantidadExistente
				
				SELECT TOP 1 @CantidadExistente = CantidadExistente, @FechaHoraIngreso = FechaHoraIngreso
				FROM dbo.InventarioProductosCantidadesComprasHistorial
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				ORDER BY FechaHoraIngreso ASC, NumeroCompraProducto ASC
				
				IF(@CantidadExistente IS NULL)
					BREAK
				
			END
			
			IF(@CantidadEgreso > 0)
				UPDATE TOP(1) InventarioProductosCantidadesComprasHistorial 
				SET CantidadExistente -= @CantidadEgreso
				WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
				AND FechaHoraIngreso = @FechaHoraIngreso	
			
		END
	END
	
END
GO
