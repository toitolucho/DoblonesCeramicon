USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.ExisteGastosParaTransferencia', N'FN') IS NOT NULL
    DROP FUNCTION dbo.ExisteGastosParaTransferencia; 
GO

CREATE FUNCTION dbo.ExisteGastosParaTransferencia (@NumeroAgencia INT, @NumeroTransferenciaProducto INT, @CodigoTipoEnvioRecepcion CHAR(1))
RETURNS BIT
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @ExisteGastos		BIT
	
	--SELECT @EsProdEspe = IP.EsProductoEspecifico
	--FROM InventariosProductos IP 
	--WHERE IP.CodigoProducto = @CodigoProducto
	IF(@CodigoTipoEnvioRecepcion = 'R')
		SET @NumeroAgencia = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)
	IF( EXISTS (SELECT NumeroTransaferenciaProductoGasto
				FROM TransferenciasProductosGastosDetalle 
				WHERE NumeroAgenciaEmisora = @NumeroAgencia AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
				AND CodigoEstadoGastoAplicado = 0 AND CodigoTipoGastoRecepcion = @CodigoTipoEnvioRecepcion))
		SET @ExisteGastos = 1
	ELSE
		SET @ExisteGastos = 0

   	RETURN(@ExisteGastos)
END
GO



