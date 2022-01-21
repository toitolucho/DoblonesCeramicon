USE DOBLONES20
GO



--IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'InsertarTransferenciasProductoDetalleRecepcion') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
--	BEGIN
--		DROP PROCEDURE InsertarTransferenciasProductoDetalleRecepcion
--	END
--GO
--CREATE PROCEDURE InsertarTransferenciasProductoDetalleRecepcion
--	@NumeroAgenciaEmisora			INT,
--	@NumeroTransferenciaProducto	INT,
--	@CodigoProducto					CHAR(15),
--	@FechaHoraEnvioRecepcion		DATETIME,
--	@CantidadEnvioRecepcion			INT,
--	@CodigoTipoEnvioRecepcion		CHAR(1)
--AS
--BEGIN
--	INSERT INTO dbo.TransferenciasProductosDetalleRecepcion(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, FechaHoraEnvioRecepcion, CantidadEnvioRecepcion, CodigoTipoEnvioRecepcion)
--	VALUES (@NumeroAgenciaEmisora, @NumeroTransferenciaProducto, @CodigoProducto, @FechaHoraEnvioRecepcion, @CantidadEnvioRecepcion, @CodigoTipoEnvioRecepcion)
--END
--GO


IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'InsertarTransferenciasProductoDetalleRecepcion') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE InsertarTransferenciasProductoDetalleRecepcion
	END
GO
CREATE PROCEDURE InsertarTransferenciasProductoDetalleRecepcion
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoProducto					CHAR(15),
	@FechaHoraEnvioRecepcion		DATETIME,
	@CantidadEnvioRecepcion			INT,
	@CodigoTipoEnvioRecepcion		CHAR(1),
	@FechaHoraEnvioPadre			DATETIME
AS
BEGIN
	INSERT INTO dbo.TransferenciasProductosDetalleRecepcion(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, FechaHoraEnvioRecepcion, CantidadEnvioRecepcion, CodigoTipoEnvioRecepcion, FechaHoraEnvioPadre)
	VALUES (@NumeroAgenciaEmisora, @NumeroTransferenciaProducto, @CodigoProducto, @FechaHoraEnvioRecepcion, @CantidadEnvioRecepcion, @CodigoTipoEnvioRecepcion, @FechaHoraEnvioPadre)
END
GO


IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ActualizarTransferenciasProductoDetalleRecepcion') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ActualizarTransferenciasProductoDetalleRecepcion
	END
GO	
CREATE PROCEDURE ActualizarTransferenciasProductoDetalleRecepcion
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoProducto					CHAR(15),
	@FechaHoraEnvioRecepcion		DATETIME,
	@CantidadEnvioRecepcion			INT,
	@CodigoTipoEnvioRecepcion		CHAR(1),
	@FechaHoraEnvioPadre			DATETIME
AS
BEGIN
	UPDATE 	dbo.TransferenciasProductosDetalleRecepcion
	SET
		FechaHoraEnvioRecepcion		= @FechaHoraEnvioRecepcion,
		CantidadEnvioRecepcion		= @CantidadEnvioRecepcion,
		CodigoTipoEnvioRecepcion	= @CodigoTipoEnvioRecepcion,
		FechaHoraEnvioPadre			= @FechaHoraEnvioPadre
		WHERE NumeroAgenciaEmisora = @NumeroAgenciaEmisora
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)			
			AND (CodigoProducto = @CodigoProducto)
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'EliminarTransferenciasProductoDetalleRecepcion') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE EliminarTransferenciasProductoDetalleRecepcion
	END
GO	
CREATE PROCEDURE EliminarTransferenciasProductoDetalleRecepcion
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoProducto					CHAR(15),
	@FechaHoraEnvioRecepcion		DATETIME
AS
BEGIN
	DELETE 
	FROM dbo.TransferenciasProductosDetalleRecepcion
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)			
			AND (CodigoProducto = @CodigoProducto)  
			AND FechaHoraEnvioRecepcion = @FechaHoraEnvioRecepcion
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciasProductosDetalleRecepcion') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciasProductosDetalleRecepcion
	END
GO	
CREATE PROCEDURE ListarTransferenciasProductosDetalleRecepcion
	@NumeroAgenciaEmisora INT
AS
BEGIN
	SELECT NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, FechaHoraEnvioRecepcion, CantidadEnvioRecepcion, CodigoTipoEnvioRecepcion, FechaHoraEnvioPadre
	FROM dbo.TransferenciasProductosDetalleRecepcion
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora)
	ORDER BY NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, FechaHoraEnvioRecepcion
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ObtenerTransferenciasProductoDetalleRecepcion') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ObtenerTransferenciasProductoDetalleRecepcion
	END
GO	
CREATE PROCEDURE ObtenerTransferenciasProductoDetalleRecepcion
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoProducto					CHAR(15),
	@FechaHoraEnvioRecepcion		DATETIME
AS
BEGIN
	SELECT NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, FechaHoraEnvioRecepcion, CantidadEnvioRecepcion, CodigoTipoEnvioRecepcion, FechaHoraEnvioPadre
	FROM dbo.TransferenciasProductosDetalleRecepcion
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)			
			AND (CodigoProducto = @CodigoProducto)  
			AND FechaHoraEnvioRecepcion = @FechaHoraEnvioRecepcion
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciasProductosDetalleRecepcionParaMostrar') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciasProductosDetalleRecepcionParaMostrar
	END
GO	
CREATE PROCEDURE ListarTransferenciasProductosDetalleRecepcionParaMostrar
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoTipoINOUT				CHAR(1)
AS
BEGIN

	--IF(@CodigoTipoINOUT = 'E')--Envio de Mercaderia de Depositos de Almacen Emisor
	--ELSE IF(@CodigoTipoINOUT = 'R')--Recepcion de Mercaderia A DEPOSITOS DE Almacen Receptor
	
	SELECT CodigoProducto, dbo.ObtenerNombreProducto(CodigoProducto) AS NombreProducto, CantidadEnvioRecepcion as CantidadEnviadaRecepcionada, FechaHoraEnvioRecepcion
	FROM TransferenciasProductosDetalleRecepcion 
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 
	AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
	AND CodigoTipoEnvioRecepcion LIKE CASE @CodigoTipoINOUT WHEN 'E' THEN 'E' ELSE '[XR]' END
	
END
GO
--exec ListarTransferenciasProductosDetalleRecepcionParaMostrar 1,1, 'E'
--exec ListarTransferenciasProductosDetalleRecepcionParaMostrar 1,1, 'R'
