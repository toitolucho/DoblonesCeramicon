USE Doblones20
GO

IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciasProductosFechasEnvio') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciasProductosFechasEnvio
	END
GO	
CREATE PROCEDURE ListarTransferenciasProductosFechasEnvio
	@NumeroAgencia			INT,
	@NumeroTransferencia	INT
AS
BEGIN
	
	DECLARE @NumeroAgenciaEmisora	INT 
	
	SET @NumeroAgenciaEmisora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferencia, @NumeroAgencia)	
	
	SELECT DISTINCT TPDRE.FechaHoraEnvioRecepcion AS FechaEnvio
	FROM TransferenciasProductosDetalleRecepcion TPDRE
	INNER JOIN
	(
		SELECT TPDE.NumeroAgenciaEmisora, TPDE.NumeroTransferenciaProducto, TPDE.FechaHoraEnvioRecepcion, SUM(TPDE.CantidadEnvioRecepcion) AS CantidadEnviada
		FROM TransferenciasProductosDetalleRecepcion TPDE	
		WHERE CodigoTipoEnvioRecepcion = 'E'
		AND NumeroAgenciaEmisora = @NumeroAgenciaEmisora
		AND NumeroTransferenciaProducto = @NumeroTransferencia
		GROUP BY TPDE.NumeroAgenciaEmisora, TPDE.NumeroTransferenciaProducto, TPDE.FechaHoraEnvioRecepcion
	) TPDE
	ON TPDRE.NumeroAgenciaEmisora = TPDE.NumeroAgenciaEmisora
	AND TPDRE.NumeroTransferenciaProducto = TPDE.NumeroTransferenciaProducto	
	AND TPDRE.FechaHoraEnvioRecepcion = TPDE.FechaHoraEnvioRecepcion			
	LEFT JOIN
	(
		SELECT NumeroAgenciaEmisora, NumeroTransferenciaProducto, FechaHoraEnvioPadre, ISNULL(SUM(CantidadEnvioRecepcion),0) AS CantidadRecepcionada
		FROM TransferenciasProductosDetalleRecepcion
		WHERE CodigoTipoEnvioRecepcion IN ('R','X')
		AND NumeroAgenciaEmisora = @NumeroAgenciaEmisora
		AND NumeroTransferenciaProducto = @NumeroTransferencia
		GROUP BY NumeroAgenciaEmisora, NumeroTransferenciaProducto, FechaHoraEnvioPadre
	) TPDR
	ON TPDE.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
	AND TPDE.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto			
	AND TPDE.FechaHoraEnvioRecepcion = TPDR.FechaHoraEnvioPadre
	WHERE TPDE.CantidadEnviada <> ISNULL(TPDR.CantidadRecepcionada,0)
	AND TPDRE.NumeroAgenciaEmisora = @NumeroAgenciaEmisora
	AND TPDRE.NumeroTransferenciaProducto = @NumeroTransferencia
	ORDER BY 1 ASC
END
GO

--exec ListarTransferenciasProductosFechasEnvio 3,1
