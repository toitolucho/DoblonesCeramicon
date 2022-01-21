USE Doblones20
GO


IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarCodigosProductosEspecificosTransferencias') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarCodigosProductosEspecificosTransferencias
	END
GO	
CREATE PROCEDURE ListarCodigosProductosEspecificosTransferencias
	@NumeroAgencia					INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoProducto					CHAR(15),
	@CodigoTipoEnvioRecepcion		CHAR(1)
AS
BEGIN
	IF(@CodigoTipoEnvioRecepcion = 'E')
	BEGIN
		SELECT CodigoProductoEspecifico
		FROM InventariosProductosEspecificos
		WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
		AND CodigoEstado = 'A'
	END
	ELSE IF(@CodigoTipoEnvioRecepcion = 'R')
	BEGIN
		SELECT CodigoProductoEspecifico 
		FROM TransferenciasProductosEspecificos
		WHERE NumeroAgenciaEmisora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)
		AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
		AND CodigoProducto = @CodigoProducto
		AND Entregado = 0
		
	END
END
GO

--exec ListarCodigosProductosEspecificosTransferencias 1,6,'10','E'


