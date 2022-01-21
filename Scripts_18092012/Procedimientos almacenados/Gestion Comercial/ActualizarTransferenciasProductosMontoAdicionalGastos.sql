USE Doblones20
GO


IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ActualizarTransferenciasProductosMontoAdicionalGastos') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ActualizarTransferenciasProductosMontoAdicionalGastos
	END
GO	
CREATE PROCEDURE ActualizarTransferenciasProductosMontoAdicionalGastos
	@NumeroAgencia					INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoProducto					CHAR(15),
	@CodigoTipoEnvioRecepcion		CHAR(1),
	@MontoAdicional					DECIMAL(5,2)
AS
BEGIN
	IF (@CodigoTipoEnvioRecepcion = 'R')
	BEGIN
		SET @NumeroAgencia = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)
		UPDATE TransferenciasProductosDetalle
			SET MontoAdicionalPorGastosRecepcion += @MontoAdicional
		WHERE NumeroAgenciaEmisora = @NumeroAgencia AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
		AND CodigoProducto = @CodigoProducto
	END
	ELSE IF (@CodigoTipoEnvioRecepcion = 'E')
	BEGIN		
		UPDATE TransferenciasProductosDetalle
			SET MontoAdicionalPorGastos += @MontoAdicional
		WHERE NumeroAgenciaEmisora = @NumeroAgencia AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
		AND CodigoProducto = @CodigoProducto
	END
END
	