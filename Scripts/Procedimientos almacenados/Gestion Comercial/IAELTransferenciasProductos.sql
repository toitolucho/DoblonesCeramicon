USE DOBLONES20
GO



DROP PROCEDURE InsertarTransferenciaProducto
GO
CREATE PROCEDURE InsertarTransferenciaProducto
	@NumeroAgenciaEmisora			INT,	
	@NumeroAgenciaRecepctora		INT,
	@CodigoUsuario					INT,
	@FechaHoraTransferencia			DATETIME,
	@CodigoEstadoTransferencia		CHAR(1),
	@MontoTotalTransferencia		DECIMAL(10,2),
	@CodigoMoneda					TINYINT,
	@Observaciones					TEXT
AS
BEGIN
	INSERT INTO dbo.TransferenciasProductos (NumeroAgenciaEmisora, NumeroAgenciaRecepctora, CodigoUsuario, FechaHoraTransferencia, CodigoEstadoTransferencia, MontoTotalTransferencia, CodigoMoneda, Observaciones)
	VALUES (@NumeroAgenciaEmisora, @NumeroAgenciaRecepctora, @CodigoUsuario, @FechaHoraTransferencia, @CodigoEstadoTransferencia, @MontoTotalTransferencia, @CodigoMoneda, @Observaciones)
END
GO



DROP PROCEDURE ActualizarTransferenciaProducto
GO
CREATE PROCEDURE ActualizarTransferenciaProducto
	@NumeroAgenciaEmisora			INT,	
	@NumeroTransferenciaProducto	INT,
	@NumeroAgenciaRecepctora		INT,
	@CodigoUsuario					INT,
	@FechaHoraTransferencia			DATETIME,
	@CodigoEstadoTransferencia		CHAR(1),
	@MontoTotalTransferencia		DECIMAL(10,2),
	@CodigoMoneda					TINYINT,
	@Observaciones					TEXT
AS
BEGIN
	UPDATE 	dbo.TransferenciasProductos
	SET	
		
		NumeroAgenciaRecepctora			= @NumeroAgenciaRecepctora,
		CodigoUsuario					= @CodigoUsuario,
		FechaHoraTransferencia			= @FechaHoraTransferencia,
		CodigoEstadoTransferencia		= @CodigoEstadoTransferencia,
		MontoTotalTransferencia			= @MontoTotalTransferencia,
		CodigoMoneda					= @CodigoMoneda,
		Observaciones					= @Observaciones
	WHERE	(NumeroAgenciaEmisora = @NumeroAgenciaEmisora)
		AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
END
GO



DROP PROCEDURE EliminarTransferenciaProducto
GO
CREATE PROCEDURE EliminarTransferenciaProducto
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT
AS
BEGIN
	DELETE 
	FROM dbo.TransferenciasProductos
	WHERE	(NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
		AND (NumeroAgenciaEmisora = @NumeroAgenciaEmisora)
END
GO



DROP PROCEDURE ListarTransferenciasProductos
GO
CREATE PROCEDURE ListarTransferenciasProductos
	@NumeroAgenciaEmisora	INT
AS
BEGIN
	SELECT NumeroAgenciaEmisora, NumeroTransferenciaProducto, NumeroAgenciaRecepctora, CodigoUsuario, FechaHoraTransferencia, CodigoEstadoTransferencia, MontoTotalTransferencia, CodigoMoneda, Observaciones
	FROM dbo.TransferenciasProductos
	WHERE (NumeroAgenciaEmisora= @NumeroAgenciaEmisora)
	ORDER BY NumeroTransferenciaProducto
END
GO



DROP PROCEDURE ObtenerTransferenciaProducto
GO
CREATE PROCEDURE ObtenerTransferenciaProducto
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT
AS
BEGIN
	SELECT NumeroAgenciaEmisora, NumeroTransferenciaProducto, NumeroAgenciaRecepctora, CodigoUsuario, FechaHoraTransferencia, CodigoEstadoTransferencia, MontoTotalTransferencia, CodigoMoneda, Observaciones
	FROM dbo.TransferenciasProductos
	WHERE	(NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
		AND (NumeroAgenciaEmisora = @NumeroAgenciaEmisora)
END
GO


IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ActualizarCodigoEstadoTransferencia') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ActualizarCodigoEstadoTransferencia
	END
GO	
CREATE PROCEDURE ActualizarCodigoEstadoTransferencia
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoEstadoTransferencia		CHAR(15),	
	@MontoTotalTransferencia		DECIMAL(10,2),
	@CodigoTipoEnvioRecepcion		CHAR(1)
AS
BEGIN
	IF(@CodigoTipoEnvioRecepcion = 'R')
		SET	@NumeroAgenciaEmisora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgenciaEmisora)
	IF(@MontoTotalTransferencia IS NOT NULL)
		UPDATE 	dbo.TransferenciasProductos
		SET		
			CodigoEstadoTransferencia		= @CodigoEstadoTransferencia,
			MontoTotalTransferencia			= @MontoTotalTransferencia,
			FechaHoraTransferencia			= GETDATE()				
		WHERE	(NumeroAgenciaEmisora = @NumeroAgenciaEmisora)
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
	ELSE
		UPDATE 	dbo.TransferenciasProductos
		SET		
			CodigoEstadoTransferencia		= @CodigoEstadoTransferencia			
		WHERE	(NumeroAgenciaEmisora = @NumeroAgenciaEmisora)
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
END
GO



DROP PROCEDURE InsertarTransferenciaProductoXMLDetalle
GO
CREATE PROCEDURE InsertarTransferenciaProductoXMLDetalle
	@NumeroAgenciaEmisora			INT,	
	@NumeroAgenciaRecepctora		INT,
	@CodigoUsuario					INT,
	@FechaHoraTransferencia			DATETIME,
	@CodigoEstadoTransferencia		CHAR(1),
	@MontoTotalTransferencia		DECIMAL(10,2),
	@CodigoMoneda					TINYINT,
	@Observaciones					TEXT,
	@ProductosDetalle				TEXT
AS
BEGIN
	BEGIN TRANSACTION
		
		INSERT INTO dbo.TransferenciasProductos (NumeroAgenciaEmisora, NumeroAgenciaRecepctora, CodigoUsuario, FechaHoraTransferencia, CodigoEstadoTransferencia, MontoTotalTransferencia, CodigoMoneda, Observaciones)
		VALUES (@NumeroAgenciaEmisora, @NumeroAgenciaRecepctora, @CodigoUsuario, @FechaHoraTransferencia, @CodigoEstadoTransferencia, @MontoTotalTransferencia, @CodigoMoneda, @Observaciones)
		
		DECLARE @punteroXMLProductosDetalle		INT,
				@NumeroTransferenciaProducto	INT
		
		SET @NumeroTransferenciaProducto = @@IDENTITY
					
		EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @ProductosDetalle
		
		INSERT INTO dbo.TransferenciasProductosDetalle(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, CantidadTransferencia, PrecioUnitarioTransferencia, MontoAdicionalPorGastos)
		SELECT    @NumeroAgenciaEmisora, @NumeroTransferenciaProducto, CodigoProducto, Cantidad, Precio, 0
		FROM       OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)
					WITH (CodigoProducto		VARCHAR(15),
						  Cantidad				INT,
						  Precio				DECIMAL(10,2)						  
					)
		EXEC sp_xml_removedocument @punteroXMLProductosDetalle
		IF(@@ERROR <> 0)
		BEGIN
			RAISERROR('No se Pudo ingresar la Transferencia de Productos',1,16)	
			ROLLBACK TRAN
		END
	COMMIT TRANSACTION	
END
GO
