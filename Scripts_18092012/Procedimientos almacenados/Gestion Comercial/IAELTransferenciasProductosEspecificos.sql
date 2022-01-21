USE DOBLONES20
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'InsertarTransferenciaProductoEspecifico') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE InsertarTransferenciaProductoEspecifico
	END
GO
CREATE PROCEDURE InsertarTransferenciaProductoEspecifico
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoProducto					CHAR(15),
	@CodigoProductoEspecifico		CHAR(30),
	@Entregado						BIT,
	@CodigoEstadoRecepcion			CHAR(1),
	@FechaHoraEnvio					DATETIME,
	@FechaHoraRecepcion				DATETIME
AS
BEGIN
	INSERT INTO dbo.TransferenciasProductosEspecificos(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, CodigoProductoEspecifico, Entregado, CodigoEstadoRecepcion, FechaHoraEnvio, FechaHoraRecepcion	)
	VALUES (@NumeroAgenciaEmisora, @NumeroTransferenciaProducto, @CodigoProducto, @CodigoProductoEspecifico, @Entregado, @CodigoEstadoRecepcion, @FechaHoraEnvio, @FechaHoraRecepcion)
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ActualizarTransferenciaProductoEspecifico') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ActualizarTransferenciaProductoEspecifico
	END
GO	
CREATE PROCEDURE ActualizarTransferenciaProductoEspecifico
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoProducto					CHAR(15),
	@CodigoProductoEspecifico		CHAR(30),
	@Entregado						BIT,
	@CodigoEstadoRecepcion			CHAR(1),
	@FechaHoraEnvio					DATETIME,
	@FechaHoraRecepcion				DATETIME
AS
BEGIN
	UPDATE 	dbo.TransferenciasProductosEspecificos
	SET						
		Entregado			= @Entregado,
		FechaHoraEnvio		= @FechaHoraEnvio,
		FechaHoraRecepcion	= @FechaHoraRecepcion,
		CodigoEstadoRecepcion = @CodigoEstadoRecepcion
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 			
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
			AND (CodigoProducto = @CodigoProducto)
			AND (CodigoProductoEspecifico = @CodigoProductoEspecifico)
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'EliminarTransferenciaProductoEspecifico') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE EliminarTransferenciaProductoEspecifico
	END
GO	
CREATE PROCEDURE EliminarTransferenciaProductoEspecifico
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoProducto					CHAR(15),
	@CodigoProductoEspecifico		CHAR(30)
AS
BEGIN
	DELETE 
	FROM dbo.TransferenciasProductosEspecificos
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)			
			AND (CodigoProducto = @CodigoProducto) 	
			AND (CodigoProductoEspecifico = @CodigoProductoEspecifico)		
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciasProductosEspecificos') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciasProductosEspecificos
	END
GO	
CREATE PROCEDURE ListarTransferenciasProductosEspecificos
	@NumeroAgenciaEmisora INT
AS
BEGIN
	SELECT NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, CodigoProductoEspecifico, Entregado, CodigoEstadoRecepcion, FechaHoraEnvio, FechaHoraRecepcion
	FROM dbo.TransferenciasProductosEspecificos
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora)
	ORDER BY NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ObtenerTransferenciaProductoEspecifico') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ObtenerTransferenciaProductoEspecifico
	END
GO	
CREATE PROCEDURE ObtenerTransferenciaProductoEspecifico
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoProducto					CHAR(15),
	@CodigoProductoEspecifico		CHAR(30)
AS
BEGIN
	SELECT NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, CodigoProductoEspecifico, Entregado, CodigoEstadoRecepcion, FechaHoraEnvio, FechaHoraRecepcion
	FROM dbo.TransferenciasProductosEspecificos
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)			
			AND (CodigoProducto = @CodigoProducto)
			AND (CodigoProductoEspecifico = @CodigoProductoEspecifico)
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciasProductosEspecificosParaMostrar') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciasProductosEspecificosParaMostrar
	END
GO	
CREATE PROCEDURE ListarTransferenciasProductosEspecificosParaMostrar
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoTipoINOUT				CHAR(1)
AS
BEGIN
	IF(@CodigoTipoINOUT = 'E')--SALIDA DE Depositos de Almacen Emisor
	BEGIN
		SELECT CodigoProducto as [Código Producto], dbo.ObtenerNombreProducto(CodigoProducto) AS [Nombre Producto], CodigoProductoEspecifico AS [Código Específico], FechaHoraEnvio as [Fecha Envio Recepcion]
		FROM TransferenciasProductosEspecificos 
		WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 
				AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
	END
	ELSE IF(@CodigoTipoINOUT = 'R')--ENTRADA A DEPOSITOS DE Almacen Receptor
	BEGIN
		SELECT CodigoProducto as [Código Producto], dbo.ObtenerNombreProducto(CodigoProducto) AS [Nombre Producto], CodigoProductoEspecifico AS [Código Específico], FechaHoraRecepcion  as [Fecha Envio Recepcion]
		FROM TransferenciasProductosEspecificos 
		WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 
				AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
	END
	
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ActualizarTransferenciaProductoEspecificoFechaRecepcion') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ActualizarTransferenciaProductoEspecificoFechaRecepcion
	END
GO	
CREATE PROCEDURE ActualizarTransferenciaProductoEspecificoFechaRecepcion
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoProducto					CHAR(15),
	@CodigoProductoEspecifico		CHAR(30),
	@Entregado						BIT,	
	@FechaHoraRecepcion				DATETIME,
	@CodigoEstadoRecepcion			CHAR(1)
AS
BEGIN	
	UPDATE 	dbo.TransferenciasProductosEspecificos
	SET						
		Entregado				= @Entregado,		
		FechaHoraRecepcion		= @FechaHoraRecepcion,
		CodigoEstadoRecepcion	= @CodigoEstadoRecepcion
	WHERE (NumeroAgenciaEmisora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgenciaEmisora))
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
			AND (CodigoProducto = @CodigoProducto)
			AND (CodigoProductoEspecifico = @CodigoProductoEspecifico)
END
GO
