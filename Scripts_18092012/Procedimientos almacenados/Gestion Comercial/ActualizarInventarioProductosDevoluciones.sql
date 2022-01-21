USE DOBLONES20
GO

DROP PROCEDURE ActualizarInventarioProductosDevoluciones
GO

CREATE PROCEDURE ActualizarInventarioProductosDevoluciones
	@NumeroAgencia			INT,
	@NumeroTransaccion		INT,
	@TipoTransaccion		CHAR(1)
AS
BEGIN
DECLARE 
	@NombreTRAN					VARCHAR(25) = 'ActualizarInventarios',
	@NumeroTransaccionOrigen	INT,
	@MensajeError				VARCHAR(200),
	@CodigoTipoCalculoInventario	CHAR(1)
	
	BEGIN TRAN @NombreTRAN
	
	SET @MensajeError = 'No se pudo Actualizar correctamente la Transaccion'
	IF(@TipoTransaccion = 'V')	
	BEGIN
		--CARGAMOS EL NUMERO DE VENTA QUE ORIGINA ESTA DEVOLUCION
		SELECT @NumeroTransaccionOrigen = NumeroVentaProducto 
		FROM VentasProductosDevoluciones
		WHERE NumeroAgencia = @NumeroAgencia 
		AND NumeroDevolucion = @NumeroTransaccion
		
		--VERIFICAMOS QUE REALMENTE SE PUEDA DEVOLVER ESOS PRODUCTOS, TOMANDO EN CUENTA QUE NO SOBREPASEN LA CANTIDAD
		--MAXIMA DE DEVOLUCION
		IF(NOT EXISTS(
		SELECT *--VPDDU.CantidadDevuelta, dbo.ObtenerCantidadTotalDevuelta_deProducto(VPDDU.CodigoProducto, @NumeroTransaccion, 'V') AS CantidadTotalDevolucion
		FROM VentasProductosDevolucionesDetalle VPDDU
		WHERE VPDDU.NumeroAgencia = @NumeroAgencia
		AND VPDDU.NumeroDevolucion = @NumeroTransaccion
		AND (VPDDU.CantidadDevuelta + dbo.ObtenerCantidadTotalDevuelta_deProducto(VPDDU.CodigoProducto, @NumeroTransaccionOrigen, 'V') > 
			dbo.ObtenerCantidadTotalRealCompradaVendida(@NumeroAgencia, @NumeroTransaccionOrigen, VPDDU.CodigoProducto, 'V')) 
		))
		BEGIN 	
				
			--Devoluciones Productos Detalle
			UPDATE InventariosProductos
				SET CantidadExistencia = CantidadExistencia +VPDD.CantidadDevuelta
			FROM VentasProductosDevolucionesDetalle VPDD
			INNER JOIN MotivosReemDevo MRD 
			ON VPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
			WHERE InventariosProductos.NumeroAgencia = VPDD.NumeroAgencia
			AND InventariosProductos.CodigoProducto = VPDD.CodigoProducto
			AND VPDD.NumeroAgencia = @NumeroAgencia
			AND VPDD.NumeroDevolucion = @NumeroTransaccion
			AND MRD.EstadoRetornoInventario = 'A'
			
			
			--Devoluciones Productos Especificos
			UPDATE InventariosProductosEspecificos
				SET CodigoEstado = MRD.EstadoRetornoInventario
			FROM VentasProductosDevolucionesDetalle VPDD 
			INNER JOIN VentasProductosDevolucionesEspecificos VPDE 
			ON VPDD.NumeroAgencia = VPDE.NumeroAgencia 
			AND VPDD.NumeroDevolucion = VPDE.NumeroDevolucion
			INNER JOIN MotivosReemDevo MRD 
			ON VPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
			WHERE VPDE.NumeroAgencia = @NumeroAgencia 
			AND VPDE.NumeroDevolucion = @NumeroTransaccion
			AND VPDE.CodigoProducto = InventariosProductosEspecificos.CodigoProducto
			AND VPDE.CodigoProductoEspecifico = InventariosProductosEspecificos.CodigoProductoEspecifico
			AND VPDE.NumeroAgencia = InventariosProductosEspecificos.NumeroAgencia
			AND MRD.EstadoRetornoInventario IN ('A','R')
			
			--SET @CodigoTipoCalculoInventario = dbo.ObtenerCodigoTipoCalculoInventarioProducto(@CodigoProducto)	 
			
			
			--HABILITAR PARA LA ACTUALIZACIÓN DE HISTORIAL DE MOVIMIENTOS EN INVENTARIOS (InventarioProductosCantidadesComprasHistorial)
			--PREGUNTAR SI SE DESEA SIMPLEMENTE ACTUALIZAR AL TIPO DE CALCULO
			--O SE DESEA INSERTAR UNA NUEVA TUPLA EN EL HISTORIAL
			--UPDATE InventarioProductosCantidadesComprasHistorial
			--	SET CantidadExistente = CantidadExistente + VPDD.CantidadDevuelta
			--FROM
			--(				
			--	SELECT	NumeroAgencia, CodigoProducto, CantidadDevuelta, 
			--	----U'->UEPS, 'P'->PEPS, 'O'->Ponderado, 'B'-> Precio mas Bajo, 'A'->Precio mas alto, 'T'-> Ultimo Precio
			--	CASE dbo.ObtenerCodigoTipoCalculoInventarioProducto(CodigoProducto) 
			--		WHEN 'U' THEN --UEPS
			--		(	SELECT TOP 1 FechaHoraIngreso
			--			FROM dbo.InventarioProductosCantidadesComprasHistorial IPCCH
			--			WHERE IPCCH.NumeroAgencia = @NumeroAgencia AND IPCCH.CodigoProducto = CodigoProducto
			--			ORDER BY IPCCH.FechaHoraIngreso DESC
			--		)
			--		WHEN 'P' THEN --PEPS
			--		(	SELECT TOP 1 FechaHoraIngreso
			--			FROM dbo.InventarioProductosCantidadesComprasHistorial IPCCH
			--			WHERE IPCCH.NumeroAgencia = @NumeroAgencia AND IPCCH.CodigoProducto = CodigoProducto
			--			ORDER BY IPCCH.FechaHoraIngreso ASC
			--		)
			--		WHEN 'O' THEN --Ponderado
			--		(	SELECT TOP 1 FechaHoraIngreso
			--			FROM dbo.InventarioProductosCantidadesComprasHistorial IPCCH
			--			WHERE IPCCH.NumeroAgencia = @NumeroAgencia AND IPCCH.CodigoProducto = CodigoProducto
			--			ORDER BY IPCCH.FechaHoraIngreso DESC
			--		)
			--		WHEN 'B' THEN --Precio mas Bajo
			--		(	SELECT TOP 1 FechaHoraIngreso
			--			FROM dbo.InventarioProductosCantidadesComprasHistorial IPCCH
			--			WHERE IPCCH.NumeroAgencia = @NumeroAgencia AND IPCCH.CodigoProducto = CodigoProducto
			--			ORDER BY IPCCH.PrecioUnitario DESC
			--		)
			--		WHEN 'A' THEN --Precio mas alto
			--		(	SELECT TOP 1 FechaHoraIngreso
			--			FROM dbo.InventarioProductosCantidadesComprasHistorial IPCCH
			--			WHERE IPCCH.NumeroAgencia = @NumeroAgencia AND IPCCH.CodigoProducto = CodigoProducto
			--			ORDER BY IPCCH.PrecioUnitario ASC
			--		)
			--		WHEN 'T' THEN --Ultimo Precio
			--		(	SELECT TOP 1 FechaHoraIngreso
			--			FROM dbo.InventarioProductosCantidadesComprasHistorial IPCCH
			--			WHERE IPCCH.NumeroAgencia = @NumeroAgencia AND IPCCH.CodigoProducto = CodigoProducto
			--			ORDER BY IPCCH.FechaHoraIngreso ASC
			--		)
			--		ELSE GETDATE() END AS FechaHoraIngreso
			--	FROM VentasProductosDevolucionesDetalle
			--	WHERE NumeroAgencia = @NumeroAgencia
			--	AND NumeroDevolucion = @NumeroTransaccion
			--) VPDD
			--WHERE InventarioProductosCantidadesComprasHistorial.CodigoProducto = VPDD.CodigoProducto
			--AND InventarioProductosCantidadesComprasHistorial.NumeroAgencia = VPDD.NumeroAgencia
			--AND InventarioProductosCantidadesComprasHistorial.FechaHoraIngreso = VPDD.FechaHoraIngreso
			
			
			--DECLARE @FechaHoraDevolucion	DATETIME
			--SET @FechaHoraDevolucion = GETDATE()
			--INSERT INTO InventarioProductosCantidadesComprasHistorial (NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraIngreso, CantidadExistente, PrecioUnitario)
			--SELECT NumeroAgencia, NumeroDevolucion, CodigoProducto, @FechaHoraDevolucion, CantidadDevuelta, PrecioUnitarioDevolucion			
			--FROM VentasProductosDevolucionesDetalle VPDD
			--WHERE VPDD.NumeroAgencia = @NumeroAgencia
			--AND VPDD.NumeroDevolucion = @NumeroTransaccion			
			
		END
		ELSE
		BEGIN
			RAISERROR ('No se pudo Completar satisfactoriamente la actualización de Inventarios, debido a la existencia de algún Producto que sobrepasa la cantidad Posible de Devolucion para Esta Venta' ,16,2)
		END		
		
	END
		
	IF(@TipoTransaccion = 'C')	
	BEGIN
		
		SELECT @NumeroTransaccionOrigen = NumeroCompraProducto 
		FROM ComprasProductosDevoluciones
		WHERE NumeroAgencia = @NumeroAgencia 
		AND NumeroDevolucion = @NumeroTransaccion
		
		IF(NOT EXISTS(
		SELECT *--VPDDU.CantidadDevuelta, dbo.ObtenerCantidadTotalDevuelta_deProducto(VPDDU.CodigoProducto, @NumeroTransaccion, 'V') AS CantidadTotalDevolucion
		FROM ComprasProductosDevolucionesDetalle CPDDU
		WHERE CPDDU.NumeroAgencia = @NumeroAgencia
		AND CPDDU.NumeroDevolucion = @NumeroTransaccion
		AND (CPDDU.CantidadDevuelta + dbo.ObtenerCantidadTotalDevuelta_deProducto(CPDDU.CodigoProducto, @NumeroTransaccionOrigen, 'C') > 
			dbo.ObtenerCantidadTotalRealCompradaVendida(@NumeroAgencia, @NumeroTransaccionOrigen, CPDDU.CodigoProducto, 'C')) 
		))
		BEGIN 	
			
			IF(NOT EXISTS(
				SELECT * 
				FROM InventariosProductos IP
				INNER JOIN ComprasProductosDevolucionesDetalle CPDD
				ON IP.NumeroAgencia = CPDD.NumeroAgencia
				AND IP.CodigoProducto = CPDD.CodigoProducto
				WHERE CPDD.NumeroDevolucion = @NumeroTransaccion
				AND CPDD.CantidadDevuelta > IP.CantidadExistencia
			))
			BEGIN
				UPDATE InventariosProductos
					SET CantidadExistencia = CantidadExistencia - CPDD.CantidadDevuelta
				FROM ComprasProductosDevolucionesDetalle CPDD
				INNER JOIN MotivosReemDevo MRD 
				ON CPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
				AND MRD.EstadoRetornoInventario IN ('B','R')
				WHERE CPDD.NumeroAgencia = @NumeroAgencia 
				AND CPDD.NumeroDevolucion = @NumeroTransaccion
				AND InventariosProductos.CodigoProducto = CPDD.CodigoProducto
				AND InventariosProductos.NumeroAgencia = CPDD.NumeroAgencia
				
			
				
				--Devoluciones de Productos Especificos de una compra
				UPDATE InventariosProductosEspecificos
					SET CodigoEstado =  MRD.EstadoRetornoInventario
				FROM ComprasProductosDevolucionesDetalle CPDD 
				INNER JOIN ComprasProductosDevolucionesEspecificos CPDE 
				ON CPDD.NumeroAgencia = CPDE.NumeroAgencia 
				AND CPDD.NumeroDevolucion = CPDE.NumeroDevolucion
				INNER JOIN MotivosReemDevo MRD 
				ON CPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
				WHERE CPDE.NumeroAgencia = @NumeroAgencia 
				AND CPDE.NumeroDevolucion = @NumeroTransaccion
				AND InventariosProductosEspecificos.NumeroAgencia = CPDE.NumeroAgencia
				AND InventariosProductosEspecificos.CodigoProducto = CPDE.CodigoProducto
				AND InventariosProductosEspecificos.CodigoProductoEspecifico = CPDE.CodigoProductoEspecifico
				AND MRD.EstadoRetornoInventario IN ('B','R')
				
				--SE DEBE DISMINUIR E INCLUSO ELIMINAR EL HISTORIAL DE INVENTARIOS
				--DE ACUERDO AL TIPO DE CALCULO CORRESPONDIENTES, 'UEPS','PEUS', ETC				
				--DECLARE @TDevolucionesCompra	TABLE
				--(
				--	NumeroAgencia	INT,
				--	CodigoProducto	CHAR(15),
				--	CantidadDevo	INT
				--)	
				
				--INSERT INTO @TDevolucionesCompra (NumeroAgencia, CodigoProducto, CantidadDevo)
				--SELECT NumeroAgencia, CodigoProducto, CantidadDevuelta
				--FROM ComprasProductosDevolucionesDetalle  CPDD
				--WHERE CPDD.NumeroAgencia = @NumeroAgencia
				--AND CPDD.NumeroDevolucion = @NumeroTransaccion
				
				
				
				--DECLARE @CodigoProducto		CHAR(15),
				--		@NumeroAgenciaCP	INT,
				--		@CantidadDevo		INT
				
				--SET ROWCOUNT 1
				--SELECT @CodigoProducto = CodigoProducto, @CantidadDevo = CantidadDevo, @NumeroAgenciaCP = NumeroAgencia 
				--FROM @TDevolucionesCompra				
				--WHILE @@rowcount <> 0
				--BEGIN
				--	EXEC ActualizarEliminarInventarioProductosCantidadesComprasHistorial @NumeroAgenciaCP, @CodigoProducto, @CantidadDevo				
					
				--	DELETE @TDevolucionesCompra WHERE CodigoProducto = @CodigoProducto
				--	SET ROWCOUNT 1
				--	SELECT @CodigoProducto = CodigoProducto, @CantidadDevo = CantidadDevo, @NumeroAgenciaCP = NumeroAgencia 
				--	FROM @TDevolucionesCompra	
				--END
				--SET ROWCOUNT 0	
				
			END
			ELSE
			BEGIN
				RAISERROR('No existe la cantidad suficiente para realizar esta devolución en Inventarios',16,2)
			END			
		END
		ELSE
		BEGIN
			RAISERROR ('No se pudo Completar satisfactoriamente la actualización de Inventarios, debido a la existencia de algún Producto que sobrepasa la cantidad Posible de Devolucion para Esta Compra' ,16,2)
		END
	END
	
	IF (@@ERROR <> 0) 
	BEGIN
		ROLLBACK TRAN @NombreTRAN
	   	RAISERROR (@MensajeError ,16,2)
	END
	ELSE	
		COMMIT TRAN 
	
END


exec ActualizarInventarioProductosDevoluciones 1, 1, 'V'