USE DOBLONES20
GO


IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'InsertarTransferenciaProductoGastosDetalle') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE InsertarTransferenciaProductoGastosDetalle
	END
GO
CREATE PROCEDURE InsertarTransferenciaProductoGastosDetalle
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoGastosTipos				INT,
	@FechaHoraGasto					DATETIME,
	@MontoPagoGasto					DECIMAL(10,2),
	@CodigoMonedaPago				TINYINT,
	@Observaciones					TEXT,
	@CodigoEstadoGastoAplicado		BIT,
	@CodigoTipoGastoRecepcion		CHAR(1)
	
AS
BEGIN
	INSERT INTO dbo.TransferenciasProductosGastosDetalle(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoGastosTipos, FechaHoraGasto, MontoPagoGasto, CodigoMonedaPago, Observaciones, CodigoEstadoGastoAplicado, CodigoTipoGastoRecepcion)
	VALUES (@NumeroAgenciaEmisora, @NumeroTransferenciaProducto, @CodigoGastosTipos, @FechaHoraGasto, @MontoPagoGasto, @CodigoMonedaPago, @Observaciones, @CodigoEstadoGastoAplicado, @CodigoTipoGastoRecepcion)
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ActualizarTransferenciaProductoGastosDetalle') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ActualizarTransferenciaProductoGastosDetalle
	END
GO	
CREATE PROCEDURE ActualizarTransferenciaProductoGastosDetalle
	@NumeroAgenciaEmisora				INT,
	@NumeroTransferenciaProducto		INT,
	@NumeroTransaferenciaProductoGasto	INT,
	@CodigoGastosTipos					INT,
	@FechaHoraGasto						DATETIME,
	@MontoPagoGasto						DECIMAL(10,2),
	@CodigoMonedaPago					TINYINT,
	@Observaciones						TEXT,
	@CodigoEstadoGastoAplicado			BIT,
	@CodigoTipoGastoRecepcion			CHAR(1)
AS
BEGIN
	UPDATE 	dbo.TransferenciasProductosGastosDetalle
	SET						
		CodigoGastosTipos			= @CodigoGastosTipos,
		FechaHoraGasto				= @FechaHoraGasto,
		MontoPagoGasto				= @MontoPagoGasto,
		CodigoMonedaPago			= @CodigoMonedaPago,		
		Observaciones				= @Observaciones,
		CodigoEstadoGastoAplicado	= @CodigoEstadoGastoAplicado,
		CodigoTipoGastoRecepcion	= @CodigoTipoGastoRecepcion
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 			
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
			AND (NumeroTransaferenciaProductoGasto = @NumeroTransaferenciaProductoGasto)
END
GO


IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ActualizarTransferenciaProductoGastosDetalleObservaciones') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ActualizarTransferenciaProductoGastosDetalleObservaciones
	END
GO	
CREATE PROCEDURE ActualizarTransferenciaProductoGastosDetalleObservaciones
	@NumeroAgenciaEmisora				INT,
	@NumeroTransferenciaProducto		INT,
	@NumeroTransaferenciaProductoGasto	INT,	
	@MontoPagoGasto						DECIMAL(10,2),	
	@Observaciones						TEXT	
AS
BEGIN
	IF(@MontoPagoGasto IS NOT NULL)
		UPDATE 	dbo.TransferenciasProductosGastosDetalle
		SET	
			MontoPagoGasto				= @MontoPagoGasto,	
			Observaciones				= @Observaciones		
		WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 			
				AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
				AND (NumeroTransaferenciaProductoGasto = @NumeroTransaferenciaProductoGasto)
	ELSE
		UPDATE 	dbo.TransferenciasProductosGastosDetalle
		SET				
			Observaciones				= @Observaciones		
		WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 			
				AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
				AND (NumeroTransaferenciaProductoGasto = @NumeroTransaferenciaProductoGasto)
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'EliminarTransferenciaProductoGastosDetalle') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE EliminarTransferenciaProductoGastosDetalle
	END
GO	
CREATE PROCEDURE EliminarTransferenciaProductoGastosDetalle
	@NumeroAgenciaEmisora				INT,
	@NumeroTransferenciaProducto		INT,
	@NumeroTransaferenciaProductoGasto	INT
AS
BEGIN
	DELETE 
	FROM dbo.TransferenciasProductosGastosDetalle
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)			
			AND (NumeroTransaferenciaProductoGasto = @NumeroTransaferenciaProductoGasto) 			
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciasProductosGastosDetalle') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciasProductosGastosDetalle
	END
GO	
CREATE PROCEDURE ListarTransferenciasProductosGastosDetalle
	@NumeroAgenciaEmisora INT
AS
BEGIN
	SELECT NumeroAgenciaEmisora, NumeroTransferenciaProducto, NumeroTransaferenciaProductoGasto, CodigoGastosTipos, FechaHoraGasto, MontoPagoGasto, CodigoMonedaPago, Observaciones, CodigoEstadoGastoAplicado, CodigoTipoGastoRecepcion
	FROM dbo.TransferenciasProductosGastosDetalle
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora)
	ORDER BY NumeroAgenciaEmisora, NumeroTransferenciaProducto, NumeroTransaferenciaProductoGasto
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ObtenerTransferenciaProductoGastosDetalle') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ObtenerTransferenciaProductoGastosDetalle
	END
GO	
CREATE PROCEDURE ObtenerTransferenciaProductoGastosDetalle
	@NumeroAgenciaEmisora				INT,
	@NumeroTransferenciaProducto		INT,
	@NumeroTransaferenciaProductoGasto	INT
AS
BEGIN
	SELECT NumeroAgenciaEmisora, NumeroTransferenciaProducto, NumeroTransaferenciaProductoGasto, CodigoGastosTipos, FechaHoraGasto, MontoPagoGasto, CodigoMonedaPago, Observaciones, CodigoEstadoGastoAplicado, CodigoTipoGastoRecepcion
	FROM dbo.TransferenciasProductosGastosDetalle
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)			
			AND (NumeroTransaferenciaProductoGasto = @NumeroTransaferenciaProductoGasto)  			
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciaProductoGastosDetalleParaMostrar') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciaProductoGastosDetalleParaMostrar
	END
GO	
CREATE PROCEDURE ListarTransferenciaProductoGastosDetalleParaMostrar
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoTipoEnvioRecepcion		CHAR(1)
AS
BEGIN
	IF(@CodigoTipoEnvioRecepcion IS NULL)
		SELECT TPGD.NumeroTransaferenciaProductoGasto, GTT.NombreGasto, FechaHoraGasto, MontoPagoGasto, Observaciones, CodigoTipoGastoRecepcion
		--NumeroAgenciaEmisora, NumeroTransferenciaProducto, NumeroTransaferenciaProductoGasto, CodigoGastosTipos, FechaHoraGasto, MontoPagoGasto, CodigoMonedaPago, Observaciones, CodigoEstadoGastoAplicado, CodigoTipoGastoRecepcion
		FROM TransferenciasProductosGastosDetalle TPGD 
		INNER JOIN GastosTiposTransacciones GTT ON TPGD.CodigoGastosTipos = GTT.CodigoGastosTipos
		WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 
				AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
	ELSE
	BEGIN
		IF(@CodigoTipoEnvioRecepcion = 'R')
			SET @NumeroAgenciaEmisora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgenciaEmisora)
		SELECT TPGD.NumeroTransaferenciaProductoGasto, GTT.NombreGasto, FechaHoraGasto, MontoPagoGasto, Observaciones, CodigoTipoGastoRecepcion
		FROM TransferenciasProductosGastosDetalle TPGD 
		INNER JOIN GastosTiposTransacciones GTT ON TPGD.CodigoGastosTipos = GTT.CodigoGastosTipos
		WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 
				AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto) AND TPGD.CodigoTipoGastoRecepcion = @CodigoTipoEnvioRecepcion
	END
	
END
GO

--ListarTransferenciaProductoGastosDetalleParaMostrar 1,1, 'E'

IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarGastosPorTransferencias') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarGastosPorTransferencias
	END
GO	
CREATE PROCEDURE ListarGastosPorTransferencias
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoTipoEnvioRecepcion		CHAR(1)	
AS
BEGIN
	IF(@CodigoTipoEnvioRecepcion = 'R')
		SET	@NumeroAgenciaEmisora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgenciaEmisora)
	SELECT GTT.NombreGasto, MontoPagoGasto
	FROM TransferenciasProductosGastosDetalle TPGD 
	INNER JOIN GastosTiposTransacciones GTT ON TPGD.CodigoGastosTipos = GTT.CodigoGastosTipos
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
	AND TPGD.CodigoTipoGastoRecepcion = @CodigoTipoEnvioRecepcion AND TPGD.CodigoEstadoGastoAplicado = 0
END
GO

--exec ListarGastosPorTransferencias 1,7, 'E'


IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ActualizarTransferenciaProductosGastosDetalleGeneral') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ActualizarTransferenciaProductosGastosDetalleGeneral
	END
GO	
CREATE PROCEDURE ActualizarTransferenciaProductosGastosDetalleGeneral
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoTipoEnvioRecepcion		CHAR(1)	
AS
BEGIN
	IF(@CodigoTipoEnvioRecepcion = 'R')
		SET	@NumeroAgenciaEmisora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgenciaEmisora)
	UPDATE TransferenciasProductosGastosDetalle
		SET CodigoEstadoGastoAplicado = 1
	WHERE NumeroAgenciaEmisora = @NumeroAgenciaEmisora
	AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
	AND CodigoTipoGastoRecepcion = @CodigoTipoEnvioRecepcion
END
GO

--exec ActualizarTransferenciaProductosGastosDetalleGeneral 1, 1, 'E'

