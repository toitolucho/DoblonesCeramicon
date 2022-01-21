USE Doblones20
GO

DROP PROCEDURE ListarCodigosEspecificosFaltantesRecepcion
GO

CREATE PROCEDURE ListarCodigosEspecificosFaltantesRecepcion
	@NumeroAgencia				INT,
	@NumeroTransferencia		INT,
	@CodigoProducto				CHAR(15),	
	@FechaHoraEnvio				DATETIME
AS
BEGIN	
	DECLARE @NumeroAgenciaEmisora	INT
	SET @NumeroAgenciaEmisora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferencia, @NumeroAgencia)
	
	IF(@FechaHoraEnvio IS NULL)
	BEGIN
		SELECT CodigoProductoEspecifico, Entregado
		FROM TransferenciasProductosEspecificos TPE
		WHERE TPE.CodigoProducto = @CodigoProducto
		AND NumeroTransferenciaProducto = @NumeroTransferencia
		AND NumeroAgenciaEmisora = @NumeroAgenciaEmisora
		AND Entregado = 0
	END
	ELSE
	BEGIN
		SELECT CodigoProductoEspecifico, Entregado
		FROM TransferenciasProductosEspecificos TPE
		WHERE TPE.CodigoProducto = @CodigoProducto
		AND NumeroTransferenciaProducto = @NumeroTransferencia
		AND NumeroAgenciaEmisora = @NumeroAgenciaEmisora
		AND Entregado = 0
		AND FechaHoraEnvio = @FechaHoraEnvio
	END
END
