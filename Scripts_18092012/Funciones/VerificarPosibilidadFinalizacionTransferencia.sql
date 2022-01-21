
USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.VerificarPosibilidadFinalizacionTransferencia', N'FN') IS NOT NULL
    DROP FUNCTION dbo.VerificarPosibilidadFinalizacionTransferencia; 
GO

CREATE FUNCTION dbo.VerificarPosibilidadFinalizacionTransferencia (@NumeroAgencia INT, @NumeroTransferenciaProducto INT)
RETURNS BIT
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @EsPosible		BIT
	
	SELECT @NumeroAgencia = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)
	
	IF(
		(	SELECT SUM(CantidadTransferencia)
			FROM TransferenciasProductosDetalle
			WHERE NumeroAgenciaEmisora = @NumeroAgencia
			AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto) 
		=		
		(	SELECT SUM(CantidadEnvioRecepcion)
			FROM TransferenciasProductosDetalleRecepcion
			WHERE NumeroAgenciaEmisora = @NumeroAgencia 
			AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
			AND CodigoTipoEnvioRecepcion IN('R','X'))
	)
		SET @EsPosible = 1
	ELSE
		SET @EsPosible = 0

   	RETURN(@EsPosible)
END
GO


