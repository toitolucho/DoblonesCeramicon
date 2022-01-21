USE Doblones20
GO

IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarCompraProductosGastosRecepcionPartesReportes') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarCompraProductosGastosRecepcionPartesReportes
	END
GO	

CREATE PROCEDURE ListarCompraProductosGastosRecepcionPartesReportes
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@IncluirTodosGastos		BIT
AS
BEGIN
	IF(@IncluirTodosGastos = 0)
	BEGIN
		SELECT GTT.NombreGasto, CPGD.MontoPagoGasto, CPGD.FechaHoraGasto, CPGD.Observaciones
		FROM CompraProductosGastosDetalle CPGD
		INNER JOIN GastosTiposTransacciones GTT ON CPGD.CodigoGastosTipos = GTT.CodigoGastosTipos
		WHERE CPGD.NumeroAgencia = @NumeroAgencia AND CPGD.NumeroCompraProducto = @NumeroCompraProducto
		AND CPGD.CodigoEstadoGasto = 0
	END
	ELSE
	BEGIN	
		SELECT cpgd.NumeroCompraProducto, GTT.NombreGasto, CPGD.MontoPagoGasto, CPGD.FechaHoraGasto, CPGD.Observaciones
		FROM CompraProductosGastosDetalle CPGD
		INNER JOIN GastosTiposTransacciones GTT ON CPGD.CodigoGastosTipos = GTT.CodigoGastosTipos
		WHERE CPGD.NumeroAgencia = @NumeroAgencia AND CPGD.NumeroCompraProducto = @NumeroCompraProducto
	END
END
GO


--exec ListarCompraProductosGastosRecepcionPartesReportes 1,120,0

USE Doblones20
GO

IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransaccionProductosGastosRecepcionMoneda') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransaccionProductosGastosRecepcionMoneda
	END
GO	

CREATE PROCEDURE ListarTransaccionProductosGastosRecepcionMoneda
	@NumeroAgencia			INT,
	@NumeroTrasaccion		INT,
	@TipoTransaccion		CHAR(1), --'C'->COMPRA, 'T'->TRANSFERENCIA
	@CodigoTipoEnvioRecepcion	CHAR(1) --'E'->ENVIO, 'R'->RECEPCION
AS
BEGIN
	
	DECLARE @MontoTotalTrannsaccion		DECIMAL(10,2),
			@CadenaMontoTotal			VARCHAR(255),
			@NombreMonedaSistema		VARCHAR(250),
			@MascaraMonedaSistema		VARCHAR(20)
	
	SELECT TOP 1 @MascaraMonedaSistema = MascaraMoneda, @NombreMonedaSistema = NombreMoneda
	FROM PCsConfiguraciones
	INNER JOIN Monedas
	ON CodigoMonedaSistema = CodigoMoneda
	WHERE NumeroAgencia = @NumeroAgencia
	
	SELECT @MontoTotalTrannsaccion = MontoTotalCompra
	FROM ComprasProductos CP
	WHERE CP.NumeroAgencia = @NumeroAgencia
	AND CP.NumeroCompraProducto = @NumeroTrasaccion
	
	
	
	IF(@TipoTransaccion = 'T')
	BEGIN		
		SELECT @MontoTotalTrannsaccion = SUM( CPGD.MontoPagoGasto)
		FROM TransferenciasProductosGastosDetalle CPGD		
		WHERE CPGD.NumeroAgenciaEmisora = @NumeroAgencia 
		AND CPGD.NumeroTransaferenciaProductoGasto = @NumeroTrasaccion
		AND CodigoTipoGastoRecepcion = @CodigoTipoEnvioRecepcion
	END
	ELSE IF(@TipoTransaccion = 'C')
	BEGIN	
		SELECT @MontoTotalTrannsaccion = SUM( CPGD.MontoPagoGasto)
		FROM CompraProductosGastosDetalle CPGD		
		WHERE CPGD.NumeroAgencia = @NumeroAgencia 
		AND CPGD.NumeroCompraProducto = @NumeroTrasaccion
	END
	
	EXEC ConvertirMontoNumerico_a_Texto @MontoTotalTrannsaccion, @NombreMonedaSistema, @CadenaMontoTotal OUTPUT
	
	SELECT	@MascaraMonedaSistema AS MascaraMonedaSistema , 
			@NombreMonedaSistema AS NombreMonedaSistema, 
			@MontoTotalTrannsaccion AS MontoTotalTrannsaccion, 
			@CadenaMontoTotal AS CadenaMontoTotal
END
GO


--EXEC ListarTransaccionProductosGastosRecepcionMoneda 1,120,'C',NULL