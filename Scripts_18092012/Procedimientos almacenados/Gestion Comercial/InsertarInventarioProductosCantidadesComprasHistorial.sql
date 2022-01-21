USE Doblones20
GO


DROP PROCEDURE InsertarInventarioProductosCantidadesComprasHistorialAplicandoGastos
GO

CREATE PROCEDURE InsertarInventarioProductosCantidadesComprasHistorialAplicandoGastos
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@FechaHoraEntrega		DATETIME	
AS
BEGIN
	
	DECLARE	@CodigoProducto			CHAR(15),
			@CantidadEntregada		INT,
			@PrecioUnitarioCompra	DECIMAL(10,2),
			@PrecioTotalGastos		DECIMAL(10,2),
			@CantidadRecepcionada	INT,
			@MontoIncrementoPrecio	DECIMAL(10,2)
			
	
	SET ROWCOUNT 0
	IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'#ProductosRecepcionados') AND OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		DROP TABLE #ProductosRecepcionados
	END
	
	SELECT CPDE.CodigoProducto, CPDE.CantidadEntregada, CPD.PrecioUnitarioCompra INTO #ProductosRecepcionados 
	FROM ComprasProductosDetalle CPD LEFT JOIN ComprasProductosDetalleEntrega CPDE
	ON CPD.NumeroAgencia = CPDE.NumeroAgencia AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto
	AND CPD.CodigoProducto = CPDE.CodigoProducto
	WHERE CPD.NumeroAgencia = @NumeroAgencia AND CPD.NumeroCompraProducto = @NumeroCompraProducto
	AND CPDE.FechaHoraEntrega = @FechaHoraEntrega

	SELECT @PrecioTotalGastos = SUM( MontoPagoGasto )
	FROM CompraProductosGastosDetalle
	WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
	AND CodigoEstadoGasto = 0
	
	SELECT @CantidadRecepcionada = SUM(CantidadEntregada)
	FROM ComprasProductosDetalleEntrega
	WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto
	and FechaHoraEntrega = @FechaHoraEntrega
	
	IF( @CantidadRecepcionada <> 0)	
		SET @MontoIncrementoPrecio = @PrecioTotalGastos / @CantidadRecepcionada
	ELSE
		SET @MontoIncrementoPrecio = 1
	
	SET ROWCOUNT 1
	
	SELECT @CodigoProducto = CodigoProducto, @CantidadEntregada = CantidadEntregada, @PrecioUnitarioCompra = PrecioUnitarioCompra 
	FROM #ProductosRecepcionados
	
	

		
	WHILE @@rowcount <> 0
	BEGIN
		
		INSERT INTO dbo.InventarioProductosCantidadesComprasHistorial (NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraIngreso, CantidadExistente, PrecioUnitario)
		--VALUES (@NumeroAgencia, @NumeroCompraProducto, @CodigoProducto, @FechaHoraEntrega, @CantidadEntregada, (@PrecioUnitarioCompra + @CantidadEntregada * @MontoIncrementoPrecio))
		VALUES (@NumeroAgencia, @NumeroCompraProducto, @CodigoProducto, @FechaHoraEntrega, @CantidadEntregada, (@PrecioUnitarioCompra + @MontoIncrementoPrecio))
		
		DELETE #ProductosRecepcionados WHERE @CodigoProducto = CodigoProducto
		SET ROWCOUNT 1
		SELECT @CodigoProducto = CodigoProducto, @CantidadEntregada = CantidadEntregada, @PrecioUnitarioCompra = PrecioUnitarioCompra 
		FROM #ProductosRecepcionados
	END
	SET ROWCOUNT 0
	IF EXISTS( SELECT * FROM dbo.sysobjects where id = object_id(N'#ProductosRecepcionados') AND OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		DROP TABLE #ProductosRecepcionados
	END
END
GO

--exec InsertarInventarioProductosCantidadesComprasHistorialAplicandoGastos 1, 1, '20100215 10:09:49.590'





DROP PROCEDURE InsertarInventarioProductosCantidadesComprasHistorialAplicandoGastosConMonto
GO

CREATE PROCEDURE InsertarInventarioProductosCantidadesComprasHistorialAplicandoGastosConMonto
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@FechaHoraEntrega		DATETIME,
	@MontoIncrementoPrecio	DECIMAL(10,2)	
AS
BEGIN
	
	DECLARE	@CodigoProducto			CHAR(15),
			@CantidadEntregada		INT,
			@PrecioUnitarioCompra	DECIMAL(10,2)			
			
			
	
	SET ROWCOUNT 0
	IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'#ProductosRecepcionados') AND OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		DROP TABLE #ProductosRecepcionados
	END
	
	SELECT CPDE.CodigoProducto, CPDE.CantidadEntregada, CPD.PrecioUnitarioCompra INTO #ProductosRecepcionados 
	FROM ComprasProductosDetalle CPD LEFT JOIN ComprasProductosDetalleEntrega CPDE
	ON CPD.NumeroAgencia = CPDE.NumeroAgencia AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto
	AND CPD.CodigoProducto = CPDE.CodigoProducto
	WHERE CPD.NumeroAgencia = @NumeroAgencia AND CPD.NumeroCompraProducto = @NumeroCompraProducto
	AND CPDE.FechaHoraEntrega = @FechaHoraEntrega
	
	SET ROWCOUNT 1
	
	SELECT @CodigoProducto = CodigoProducto, @CantidadEntregada = CantidadEntregada, @PrecioUnitarioCompra = PrecioUnitarioCompra 
	FROM #ProductosRecepcionados
	
			
	WHILE @@rowcount <> 0
	BEGIN
		
		INSERT INTO dbo.InventarioProductosCantidadesComprasHistorial (NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraIngreso, CantidadExistente, PrecioUnitario)
		--VALUES (@NumeroAgencia, @NumeroCompraProducto, @CodigoProducto, @FechaHoraEntrega, @CantidadEntregada, (@PrecioUnitarioCompra + @CantidadEntregada * @MontoIncrementoPrecio))
		VALUES (@NumeroAgencia, @NumeroCompraProducto, @CodigoProducto, @FechaHoraEntrega, @CantidadEntregada, (@PrecioUnitarioCompra + @MontoIncrementoPrecio))
		
		DELETE #ProductosRecepcionados WHERE @CodigoProducto = CodigoProducto
		SET ROWCOUNT 1
		SELECT @CodigoProducto = CodigoProducto, @CantidadEntregada = CantidadEntregada, @PrecioUnitarioCompra = PrecioUnitarioCompra 
		FROM #ProductosRecepcionados
	END
	SET ROWCOUNT 0
	IF EXISTS( SELECT * FROM dbo.sysobjects where id = object_id(N'#ProductosRecepcionados') AND OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		DROP TABLE #ProductosRecepcionados
	END
END
GO



DROP PROCEDURE InsertarInventarioProductosCantidadesComprasHistorial
GO

CREATE PROCEDURE InsertarInventarioProductosCantidadesComprasHistorial
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@CodigoProducto			CHAR(15),
	@FechaHoraIngreso		DATETIME,
	@CantidadExistente		INT,
	@PrecioUnitario			DECIMAL(10,2)
AS
BEGIN
	INSERT INTO dbo.InventarioProductosCantidadesComprasHistorial (NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraIngreso, CantidadExistente, PrecioUnitario)
	VALUES (@NumeroAgencia, @NumeroCompraProducto, @CodigoProducto, @FechaHoraIngreso, @CantidadExistente, @PrecioUnitario)
END
GO


DROP PROCEDURE ActualizarEliminarInventarioProductosCantidadesComprasHistorial
GO

CREATE PROCEDURE ActualizarEliminarInventarioProductosCantidadesComprasHistorial
	@NumeroAgencia			INT,	
	@CodigoProducto			CHAR(15),
	@CantidadEgreso			INT	
AS
BEGIN
	DECLARE	@CodigoTipoCalculoInventario	CHAR(1),
			@ContadorCantidades				INT = 0,
			@CantidadExistente				INT,
			@FechaHoraIngreso				DATETIME,
			@PrecioUnitario					DECIMAL(10,2)
	
	SET @CodigoTipoCalculoInventario = dbo.ObtenerCodigoTipoCalculoInventarioProducto(@CodigoProducto)	 
	--U'->UEPS, 'P'->PEPS, 'O'->Ponderado, 'B'-> Precio mas Bajo, 'A'->Precio mas alto, 'T'-> Ultimo Precio
	IF(@CodigoTipoCalculoInventario = 'U')--UEPS	
	BEGIN
		SELECT TOP 1 @CantidadExistente = CantidadExistente, @FechaHoraIngreso = FechaHoraIngreso
		FROM dbo.InventarioProductosCantidadesComprasHistorial
		WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
		ORDER BY FechaHoraIngreso DESC
		
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
				ORDER BY FechaHoraIngreso DESC
				
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
	
	ELSE IF(@CodigoTipoCalculoInventario = 'P')	--PEPS
	BEGIN
		SELECT TOP 1 @CantidadExistente = CantidadExistente, @FechaHoraIngreso = FechaHoraIngreso
		FROM dbo.InventarioProductosCantidadesComprasHistorial
		WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
		ORDER BY FechaHoraIngreso ASC
		
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
				ORDER BY FechaHoraIngreso ASC
				
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
	
	ELSE IF(@CodigoTipoCalculoInventario = 'O')	--Ponderado
	BEGIN
		SELECT TOP 1 @CantidadExistente = CantidadExistente, @FechaHoraIngreso = FechaHoraIngreso
		FROM dbo.InventarioProductosCantidadesComprasHistorial
		WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
		ORDER BY FechaHoraIngreso DESC
		
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
				ORDER BY FechaHoraIngreso DESC
				
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
		ORDER BY PrecioUnitario DESC
		
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
				ORDER BY PrecioUnitario DESC
				
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
		ORDER BY FechaHoraIngreso ASC
		
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
				ORDER BY FechaHoraIngreso ASC
				
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
