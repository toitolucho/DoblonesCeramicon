USE Doblones20
GO


IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ActualizarTransferenciasProductosGastosAdicionalesProrrateados') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ActualizarTransferenciasProductosGastosAdicionalesProrrateados
	END
GO	
CREATE PROCEDURE ActualizarTransferenciasProductosGastosAdicionalesProrrateados
	@NumeroAgencia					INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoTipoEnvioRecepcion		CHAR(1),
	@FechaHoraEnvioRecepcion		DATETIME	
AS
BEGIN
	
	DECLARE	@CodigoProducto			CHAR(15),
			@CantidadEntregada		INT,
			@PrecioUnitarioCompra	DECIMAL(10,2),
			@PrecioTotalGastos		DECIMAL(10,2),
			@CantidadRecepcionada	INT,
			@MontoIncrementoPrecio	DECIMAL(10,2)
	
	DECLARE @ProductosRecepcionados	TABLE
	(
		CodigoProducto				CHAR(15),
		CantidadEnvioRecepcion		INT,
		PrecioUnitarioTransferencia DECIMAL(10,2)
	)		
	
	SET ROWCOUNT 0
	
	IF(@CodigoTipoEnvioRecepcion = 'R')
		SET @NumeroAgencia = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)
	
	INSERT INTO @ProductosRecepcionados (CodigoProducto, CantidadEnvioRecepcion, PrecioUnitarioTransferencia)
	SELECT TPDR.CodigoProducto, TPDR.CantidadEnvioRecepcion, TPD.PrecioUnitarioTransferencia
	FROM TransferenciasProductosDetalle TPD LEFT JOIN TransferenciasProductosDetalleRecepcion TPDR
	ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora AND TPD.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
	AND TPD.CodigoProducto = TPDR.CodigoProducto
	WHERE TPD.NumeroAgenciaEmisora = @NumeroAgencia AND TPD.NumeroTransferenciaProducto = @NumeroTransferenciaProducto
	AND TPDR.FechaHoraEnvioRecepcion = @FechaHoraEnvioRecepcion 
	AND TPDR.CodigoTipoEnvioRecepcion LIKE (CASE @CodigoTipoEnvioRecepcion WHEN 'E' THEN 'E' ELSE '[RX]' END)

	SELECT @PrecioTotalGastos = SUM( MontoPagoGasto )
	FROM TransferenciasProductosGastosDetalle
	WHERE NumeroAgenciaEmisora = @NumeroAgencia AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
	AND CodigoEstadoGastoAplicado = 0
	
	SELECT @CantidadRecepcionada = COUNT(CantidadEnvioRecepcion)
	FROM TransferenciasProductosDetalleRecepcion
	WHERE NumeroAgenciaEmisora = @NumeroAgencia AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
	AND FechaHoraEnvioRecepcion = @FechaHoraEnvioRecepcion 
	AND CodigoTipoEnvioRecepcion LIKE (CASE @CodigoTipoEnvioRecepcion WHEN 'E' THEN 'E' ELSE '[RX]' END)
	
	IF( @CantidadRecepcionada <> 0)	
		SET @MontoIncrementoPrecio = @PrecioTotalGastos / @CantidadRecepcionada
	ELSE
		SET @MontoIncrementoPrecio = 0
	
	SET ROWCOUNT 1
	
	SELECT @CodigoProducto = CodigoProducto, @CantidadEntregada = CantidadEnvioRecepcion, @PrecioUnitarioCompra = PrecioUnitarioTransferencia 
	FROM @ProductosRecepcionados
		
	WHILE @@rowcount <> 0
	BEGIN
		
		IF (@CodigoTipoEnvioRecepcion = 'R')
		BEGIN
			UPDATE TransferenciasProductosDetalle
				SET MontoAdicionalPorGastosRecepcion += @MontoIncrementoPrecio
			WHERE NumeroAgenciaEmisora = @NumeroAgencia AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
			AND CodigoProducto = @CodigoProducto
			
			INSERT INTO dbo.InventarioProductosCantidadesComprasHistorial (NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraIngreso, CantidadExistente, PrecioUnitario)
			--VALUES (@NumeroAgencia, @NumeroCompraProducto, @CodigoProducto, @FechaHoraEntrega, @CantidadEntregada, (@PrecioUnitarioCompra + @CantidadEntregada * @MontoIncrementoPrecio))
			VALUES (@NumeroAgencia, @NumeroTransferenciaProducto, @CodigoProducto, @FechaHoraEnvioRecepcion, @CantidadEntregada, (@PrecioUnitarioCompra + @MontoIncrementoPrecio/@CantidadEntregada))
		END
		ELSE IF (@CodigoTipoEnvioRecepcion = 'E')
		BEGIN
			UPDATE TransferenciasProductosDetalle
				SET MontoAdicionalPorGastos += @MontoIncrementoPrecio
			WHERE NumeroAgenciaEmisora = @NumeroAgencia AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
			AND CodigoProducto = @CodigoProducto
		END
		DELETE @ProductosRecepcionados WHERE CodigoProducto = @CodigoProducto
		SET ROWCOUNT 1
		SELECT @CodigoProducto = CodigoProducto, @CantidadEntregada = CantidadEnvioRecepcion, @PrecioUnitarioCompra = PrecioUnitarioTransferencia 
		FROM @ProductosRecepcionados
	END
	SET ROWCOUNT 0
	
END
GO

--exec ActualizarTransferenciasProductosGastosAdicionalesProrrateados 1,5, 'E','20100227 10:56:07.750'


--SELECT TPDR.CodigoProducto, TPDR.CantidadEnvioRecepcion, TPD.PrecioUnitarioTransferencia, FechaHoraEnvioRecepcion
--	FROM TransferenciasProductosDetalle TPD LEFT JOIN TransferenciasProductosDetalleRecepcion TPDR
--	ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora AND TPD.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
--	AND TPD.CodigoProducto = TPDR.CodigoProducto
--	WHERE TPD.NumeroAgenciaEmisora = 1 AND TPD.NumeroTransferenciaProducto = 5
--	AND TPDR.FechaHoraEnvioRecepcion = '27/02/2010 10:56:07' AND TPDR.CodigoTipoEnvioRecepcion = 'E'
	
--SELECT SUM( MontoPagoGasto )
--	FROM TransferenciasProductosGastosDetalle
--	WHERE NumeroAgenciaEmisora = 1 AND NumeroTransferenciaProducto = 5
--	AND CodigoEstadoGastoAplicado = 0	
--SELECT SUM(CantidadEnvioRecepcion)
--	FROM TransferenciasProductosDetalleRecepcion
--	WHERE NumeroAgenciaEmisora = 1 AND NumeroTransferenciaProducto = 5
--	and FechaHoraEnvioRecepcion ='27/02/2010 10:56:07' AND CodigoTipoEnvioRecepcion = 'E'
	
	
	