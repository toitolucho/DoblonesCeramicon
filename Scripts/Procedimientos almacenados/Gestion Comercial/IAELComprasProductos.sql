USE DOBLONES20
GO



DROP PROCEDURE InsertarCompraProducto
GO
CREATE PROCEDURE InsertarCompraProducto
	@NumeroAgencia						INT,
	@CodigoProveedor					INT,
	@CodigoUsuario						INT,
	@CodigoUsuarioResponsablePago		INT,
	@CodigoUsuarioResponsableRecepcion	INT,
	@FechaHoraPlazoDeRecepcion			DATETIME,
	@FechaHoraPago						DATETIME,
	@FechaHoraRecepcion					DATETIME,
	@Fecha								DATETIME,
	@CodigoTipoCompra					CHAR(1),
	@CodigoEstadoCompra					CHAR(1),
	@CodigoEstadoFactura				CHAR(1),
	@MontoTotalCompra					DECIMAL(10,2),
	@NumeroCuentaPorPagar				INT,
	@CodigoCompraProducto				CHAR(12),
	@DIPersonaDestinatario				CHAR(15),
	@FechaHoraEnvioMercaderia			DATETIME,
	@ImpuestoIVA						DECIMAL(5,2),
	@NumeroFactura						CHAR(10),
	@NumeroAutorizacionFactura			CHAR(10),
	@CodigoControlFactura				CHAR(10),
	@EsImportacion						BIT,
	@RegistroDirectoAlmacen				BIT,
	@CodigoMedioTransporte				TINYINT,
	@MontoDescuento						DECIMAL(10,2),
	@MontoNetoCompra					DECIMAL(10,2),
	@CodigoOrigenMercaderia				TINYINT,
	@NumeroGuiaTranposrte				CHAR(10),
	@CodigoMoneda						TINYINT,
	@Observaciones						TEXT
AS
BEGIN
	set @MontoNetoCompra = ISNULL(@MontoNetoCompra, @MontoTotalCompra)

	INSERT INTO dbo.ComprasProductos (NumeroAgencia,CodigoProveedor, CodigoUsuario, 
		CodigoUsuarioResponsablePago, CodigoUsuarioResponsableRecepcion, FechaHoraPlazoDeRecepcion, FechaHoraPago, FechaHoraRecepcion,
		Fecha, CodigoTipoCompra, CodigoEstadoCompra, CodigoEstadoFactura, MontoTotalCompra, NumeroCuentaPorPagar, 
		CodigoCompraProducto, DIPersonaDestinatario, FechaHoraEnvioMercaderia, ImpuestoIVA,
		NumeroFactura, NumeroAutorizacionFactura, CodigoControlFactura, EsImportacion, RegistroDirectoAlmacen, 
		CodigoMedioTransporte, MontoDescuento, MontoNetoCompra,
		CodigoOrigenMercaderia, NumeroGuiaTranposrte, CodigoMoneda, Observaciones)
	VALUES (@NumeroAgencia, @CodigoProveedor, @CodigoUsuario, 
		@CodigoUsuarioResponsablePago, @CodigoUsuarioResponsableRecepcion, @FechaHoraPlazoDeRecepcion, @FechaHoraPago, @FechaHoraRecepcion,
		@Fecha, @CodigoTipoCompra, @CodigoEstadoCompra, @CodigoEstadoFactura, @MontoTotalCompra, @NumeroCuentaPorPagar, 
		@CodigoCompraProducto, @DIPersonaDestinatario, @FechaHoraEnvioMercaderia, @ImpuestoIVA,
		@NumeroFactura, @NumeroAutorizacionFactura, @CodigoControlFactura, @EsImportacion, @RegistroDirectoAlmacen, 
		@CodigoMedioTransporte, @MontoDescuento, @MontoNetoCompra,
		@CodigoOrigenMercaderia, @NumeroGuiaTranposrte, @CodigoMoneda, @Observaciones)
END
GO



DROP PROCEDURE ActualizarCompraProducto
GO
CREATE PROCEDURE ActualizarCompraProducto
	@NumeroAgencia						INT,
	@NumeroCompraProducto				INT,
	@CodigoProveedor					INT,
	@CodigoUsuario						INT,
	@CodigoUsuarioResponsablePago		INT,
	@CodigoUsuarioResponsableRecepcion	INT,
	@FechaHoraPlazoDeRecepcion			DATETIME,
	@FechaHoraPago						DATETIME,
	@FechaHoraRecepcion					DATETIME,
	@Fecha								DATETIME,
	@CodigoTipoCompra					CHAR(1),
	@CodigoEstadoCompra					CHAR(1),
	@CodigoEstadoFactura				CHAR(1),
	@MontoTotalCompra					DECIMAL(10,2),
	@NumeroCuentaPorPagar				INT,
	@CodigoCompraProducto				CHAR(12),
	@DIPersonaDestinatario				CHAR(15),
	@FechaHoraEnvioMercaderia			DATETIME,
	@ImpuestoIVA						DECIMAL(5,2),
	@NumeroFactura						CHAR(10),
	@NumeroAutorizacionFactura			CHAR(10),
	@CodigoControlFactura				CHAR(10),
	@EsImportacion						BIT,
	@RegistroDirectoAlmacen				BIT,
	@CodigoMedioTransporte				TINYINT,
	@MontoDescuento						DECIMAL(10,2),
	@MontoNetoCompra					DECIMAL(10,2),
	@CodigoOrigenMercaderia				TINYINT,
	@NumeroGuiaTranposrte				CHAR(10),
	@CodigoMoneda						TINYINT,
	@Observaciones						TEXT
AS
BEGIN
	UPDATE 	dbo.ComprasProductos
	SET				
		CodigoProveedor						= @CodigoProveedor,
		CodigoUsuario						= @CodigoUsuario,		
		CodigoUsuarioResponsablePago		= @CodigoUsuarioResponsablePago,
		CodigoUsuarioResponsableRecepcion	= @CodigoUsuarioResponsableRecepcion,
		FechaHoraPlazoDeRecepcion			= @FechaHoraPlazoDeRecepcion,
		FechaHoraPago						= @FechaHoraPago,
		FechaHoraRecepcion					= @FechaHoraRecepcion,		
		--Fecha								= @Fecha,
		CodigoTipoCompra					= @CodigoTipoCompra,
		CodigoEstadoCompra					= @CodigoEstadoCompra,
		CodigoEstadoFactura 				= @CodigoEstadoFactura,
		MontoTotalCompra					= @MontoTotalCompra,
		NumeroCuentaPorPagar				= @NumeroCuentaPorPagar,
		--CodigoCompraProducto				= @CodigoCompraProducto,	
		DIPersonaDestinatario				= @DIPersonaDestinatario,
		FechaHoraEnvioMercaderia			= @FechaHoraEnvioMercaderia,
		ImpuestoIVA							= @ImpuestoIVA,
		NumeroFactura						= @NumeroFactura,
		NumeroAutorizacionFactura			= @NumeroAutorizacionFactura,
		CodigoControlFactura				= @CodigoControlFactura,
		EsImportacion						= @EsImportacion,
		RegistroDirectoAlmacen				= @RegistroDirectoAlmacen,
		CodigoMedioTransporte				= @CodigoMedioTransporte,
		MontoDescuento						= @MontoDescuento,
		MontoNetoCompra						= @MontoNetoCompra,	
		CodigoOrigenMercaderia				= @CodigoOrigenMercaderia,
		NumeroGuiaTranposrte				= @NumeroGuiaTranposrte,
		CodigoMoneda						= @CodigoMoneda,			
		Observaciones						= @Observaciones
	WHERE	(NumeroCompraProducto = @NumeroCompraProducto)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE EliminarCompraProducto
GO
CREATE PROCEDURE EliminarCompraProducto
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT
AS
BEGIN
	DELETE 
	FROM dbo.ComprasProductos
	WHERE	(NumeroCompraProducto = @NumeroCompraProducto)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE ListarComprasProductos
GO
CREATE PROCEDURE ListarComprasProductos
	@NumeroAgencia	INT
AS
BEGIN
	SELECT	NumeroAgencia,NumeroCompraProducto,CodigoProveedor, CodigoUsuario, 
			CodigoUsuarioResponsablePago, CodigoUsuarioResponsableRecepcion, FechaHoraPlazoDeRecepcion, FechaHoraPago, FechaHoraRecepcion,
			Fecha,CodigoTipoCompra,CodigoEstadoCompra, CodigoEstadoFactura, MontoTotalCompra, NumeroCuentaPorPagar, 
			CodigoCompraProducto, DIPersonaDestinatario, FechaHoraEnvioMercaderia, ImpuestoIVA,
			NumeroFactura, NumeroAutorizacionFactura, CodigoControlFactura, EsImportacion, RegistroDirectoAlmacen, 
			CodigoMedioTransporte, MontoDescuento, MontoNetoCompra,
			CodigoOrigenMercaderia, NumeroGuiaTranposrte, CodigoMoneda, Observaciones
	FROM dbo.ComprasProductos
	WHERE (NumeroAgencia= @NumeroAgencia)
	ORDER BY NumeroCompraProducto
END
GO



DROP PROCEDURE ObtenerCompraProducto
GO
CREATE PROCEDURE ObtenerCompraProducto
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT
AS
BEGIN
	SELECT	NumeroAgencia,NumeroCompraProducto,CodigoProveedor, CodigoUsuario, 
			CodigoUsuarioResponsablePago, CodigoUsuarioResponsableRecepcion, FechaHoraPlazoDeRecepcion, FechaHoraPago, FechaHoraRecepcion,
			Fecha,CodigoTipoCompra,CodigoEstadoCompra, CodigoEstadoFactura, MontoTotalCompra, NumeroCuentaPorPagar, 
			CodigoCompraProducto, DIPersonaDestinatario, FechaHoraEnvioMercaderia, ImpuestoIVA,
			NumeroFactura, NumeroAutorizacionFactura, CodigoControlFactura, EsImportacion, RegistroDirectoAlmacen, 
			CodigoMedioTransporte, MontoDescuento, MontoNetoCompra,
			CodigoOrigenMercaderia, NumeroGuiaTranposrte, CodigoMoneda, Observaciones
	FROM dbo.ComprasProductos
	WHERE	(NumeroCompraProducto = @NumeroCompraProducto)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE ListarTuplaDatosCompraProductoReporte
GO


CREATE PROCEDURE ListarTuplaDatosCompraProductoReporte
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@ListadoAtributosCompra VARCHAR(8000) OUTPUT
AS
BEGIN
	SELECT TOP(1) @ListadoAtributosCompra = RTRIM(LTRIM(CAST(CP.NumeroAgencia AS CHAR(100)))) +', '+ RTRIM(LTRIM(CAST(CP.NumeroCompraProducto AS VARCHAR(8000)))) +', '+ P.NombreRazonSocial +', '+ CONVERT(varchar, CP.Fecha, 113) +', '+ 
				 CASE (CP.CodigoTipoCompra) WHEN 'E' THEN 'EFECTIVO' WHEN 'R' THEN 'A CREDITO' END +', '+CASE WHEN CP.NumeroCuentaPorPagar IS NULL THEN ' Cancelado ' ELSE RTRIM(LTRIM(CAST(CP.NumeroCuentaPorPagar AS VARCHAR(8000)))) END +', ' + CASE WHEN CP.Observaciones IS NULL OR LEN(RTRIM(LTRIM(CAST(CP.Observaciones AS VARCHAR(8000)))))<=1 THEN 'Ninguna' ELSE RTRIM(LTRIM(CAST(CP.Observaciones AS VARCHAR(8000)))) END +', '+
				 CASE WHEN P.NITProveedor IS NULL THEN 'Ninguno'ELSE RTRIM(LTRIM(P.NITProveedor)) END +', '+ CASE WHEN P.NombreRepresentante IS NULL THEN P.NombreRazonSocial ELSE P.NombreRepresentante END +', ' + CASE WHEN P.Telefono IS NULL OR LEN(RTRIM(LTRIM(P.Telefono))) < 1 THEN  ' Sin Número' ELSE LTRIM(RTRIM(P.Telefono)) END +', '+ CASE WHEN P.Direccion IS NULL OR LEN(RTRIM(LTRIM(P.Direccion))) < 1 THEN ' Sin Dirección' ELSE LTRIM(RTRIM(P.Direccion)) END +', '+ U.Nombres+' '+U.Paterno+' '+U.Materno
	FROM ComprasProductos CP			
			INNER JOIN Proveedores P ON P.CodigoProveedor = CP.CodigoProveedor
			INNER JOIN Usuarios U ON U.CodigoUsuario = CP.CodigoUsuario
	WHERE CP.NumeroAgencia = @NumeroAgencia
	AND CP.NumeroCompraProducto = @NumeroCompraProducto	
END
GO


DROP PROCEDURE ListarCompraProductoReporte
GO

CREATE PROCEDURE ListarCompraProductoReporte
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT
AS
BEGIN
	DECLARE @MontoTotalCompra			DECIMAL(10,2),
			@MontoTotalCompraNeto		DECIMAL(10,2),
			@MontoTotalCompraNetoMonAux	DECIMAL(10,2),
			@CadenaMontoTotalSistema	VARCHAR(255),
			@CadenaMontoTotalRegion		VARCHAR(255),
			@NombreMonedaRegion			VARCHAR(250),
			@MascaraMonedaRegion		VARCHAR(20),
			@NombreMonedaSistema		VARCHAR(250),
			@MascaraMonedaSistema		VARCHAR(20),
			@MontoTotalGastos			DECIMAL(10,2),
			@FactorCotizacion			DECIMAL(10,2),
			@FechaHoraCompra			DATETIME,
			@CodigoMonedaSistema		INT,
			@CodigoMonedaRegion			INT
	
	SELECT TOP 1 @MascaraMonedaSistema = MascaraMoneda, @NombreMonedaSistema = NombreMoneda, 
				@CodigoMonedaSistema = CodigoMonedaSistema, @CodigoMonedaRegion = CodigoMonedaRegion				
	FROM PCsConfiguraciones
	INNER JOIN Monedas
	ON CodigoMonedaSistema = CodigoMoneda
	WHERE NumeroAgencia = @NumeroAgencia
	
	
	SELECT TOP 1 @MascaraMonedaRegion = MascaraMoneda, @NombreMonedaRegion = NombreMoneda, 
				@CodigoMonedaRegion = CodigoMonedaRegion, @CodigoMonedaRegion = CodigoMonedaRegion				
	FROM PCsConfiguraciones
	INNER JOIN Monedas
	ON CodigoMonedaRegion = CodigoMoneda
	WHERE NumeroAgencia = @NumeroAgencia
	
	SELECT @MontoTotalCompra = MontoTotalCompra, @FechaHoraCompra = Fecha
	FROM ComprasProductos CP
	WHERE CP.NumeroAgencia = @NumeroAgencia
	AND CP.NumeroCompraProducto = @NumeroCompraProducto
	
	SELECT @MontoTotalGastos = SUM(MontoPagoGasto)
	FROM CompraProductosGastosDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroCompraProducto = @NumeroCompraProducto
	
	EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraCompra, @CodigoMonedaRegion, @FactorCotizacion OUTPUT
	
	IF(@FactorCotizacion = -1)
		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaRegion, @FactorCotizacion OUTPUT	
		
	SET @MontoTotalGastos = ISNULL(@MontoTotalGastos,0)
	SET @MontoTotalCompraNeto = @MontoTotalGastos + @MontoTotalCompra
	SET @MontoTotalCompraNetoMonAux = @MontoTotalCompraNeto * @FactorCotizacion
	
	EXEC ConvertirMontoNumerico_a_Texto @MontoTotalCompraNeto, @NombreMonedaSistema, @CadenaMontoTotalSistema OUTPUT
	EXEC ConvertirMontoNumerico_a_Texto @MontoTotalCompraNetoMonAux, @NombreMonedaRegion, @CadenaMontoTotalRegion OUTPUT
	
	SELECT  LTRIM(RTRIM(U.Nombres))+' '+LTRIM(RTRIM(U.Paterno))+' '+LTRIM(RTRIM(U.Materno)) as [Datos Comprador], 
			CP.NumeroAgencia AS [Numero de Agencia],CP.NumeroCompraProducto, P.NombreRazonSocial, CP.Fecha,
			CASE (CP.CodigoTipoCompra) WHEN 'E' THEN 'CONTADO' WHEN 'R' THEN 'A CREDITO' END AS[Tipo Compra], 
			CASE (CP.NumeroCuentaPorPagar) WHEN null THEN '-1' ELSE CP.NumeroCuentaPorPagar END AS [Numero Cuenta por Pagar],
			CP.Observaciones, P.NITProveedor, 
			CASE (P.CodigoTipoProveedor) WHEN 'P' THEN 'PERSONA' WHEN 'E' THEN 'EMPRESA' END AS [Tipo Cliente], 
			P.NombreRepresentante,P.Telefono,P.Direccion,
			@MascaraMonedaSistema AS MascaraMoneda,
			@NombreMonedaSistema AS NombreMoneda, @CadenaMontoTotalSistema AS CadenaMontoTotal,
			CASE
			WHEN CodigoEstadoCompra = 'I' THEN 'INICIADA' 			
			WHEN CodigoEstadoCompra = 'I' and CodigoTipoCompra ='R' THEN 'EFECTIVO Y CREDITO' 
			WHEN CodigoEstadoCompra = 'P' and CodigoTipoCompra ='E' THEN 'PAGADA EN TRANSITO' 
			WHEN CodigoEstadoCompra = 'P' and CodigoTipoCompra ='R' THEN 'A CREDITO EN TRANSITO' 
			WHEN CodigoEstadoCompra = 'A' THEN 'ANULADA' 
			WHEN CodigoEstadoCompra = 'D' THEN 'PENDIENTE EN TRANSITO'  
			WHEN CodigoEstadoCompra = 'F' THEN 'FINALIZADA Y RECIBIDA'  
			WHEN CodigoEstadoCompra = 'X' THEN 'FINALIZADA INCOMPLETA' END AS EstadoCompra,	
			@MontoTotalCompraNeto AS MontoTotalNeto,
			CP.MontoTotalCompra,		
			@MontoTotalGastos AS MontoTotalGastos,
			@FactorCotizacion AS FactorCambioCotizacion,
			@MascaraMonedaRegion AS MascaraMonedaRegion,
			@NombreMonedaRegion AS NombreMonedaRegion, 
			@MontoTotalCompraNetoMonAux AS MontoTotalNetoRegion,
			@CadenaMontoTotalRegion AS CadenaMontoTotalRegion,
			LTRIM(RTRIM(U2.Nombres))+' '+LTRIM(RTRIM(U2.Paterno))+' '+LTRIM(RTRIM(U2.Materno)) as UsuarioResponsablePabo, 
			LTRIM(RTRIM(U3.Nombres))+' '+LTRIM(RTRIM(U3.Paterno))+' '+LTRIM(RTRIM(U3.Materno)) as UsuarioResponsableRecepcion, 
			FechaHoraPlazoDeRecepcion, FechaHoraPago, FechaHoraRecepcion,
			CASE WHEN CodigoEstadoFactura = 'F' THEN 'CON FACTURA' ELSE 'SIN FACTURA' END AS CompraFacturada,
			CodigoCompraProducto, 
			CASE WHEN DIPersonaDestinatario IS NULL THEN 'Sin persona Destinataria' ELSE DBO.ObtenerNombreCompleto(DIPersonaDestinatario) END AS  PersonaDestinatario,  			
			FechaHoraEnvioMercaderia, 
			ImpuestoIVA,
			NumeroFactura, 
			NumeroAutorizacionFactura, 
			CodigoControlFactura, 
			CASE WHEN EsImportacion = 0 THEN 'MERCADERIA PROVEEDOR LOCAL' ELSE 'MERCADERIA IMPORTADA' END AS TipoImportacion, 
			CASE WHEN RegistroDirectoAlmacen = 0 THEN 'INGRESO DE MERCADERIA POR ETAPAS' ELSE 'INGRESO DE MERCADERIA DIRECTO' END AS RegistroDirectoAlmacen, 
			CP.CodigoMedioTransporte, MD.NombreMedioTransporte,
			CASE WHEN MontoDescuento IS NULL THEN 0 ELSE MontoDescuento END AS MontoDescuento, 
			MontoNetoCompra,
			OM.CodigoOrigenMercaderia, OM.NombreOrigenMercaderia,
			NumeroGuiaTranposrte,
			CASE WHEN CodigoUsuarioResponsablePago IS NULL THEN 'En espera de Asignacion' 
			ELSE dbo.ObtenerNombreCompletoUsuario(CodigoUsuarioResponsablePago) END AS NombrePersonaResponsablePago,
			CASE WHEN CodigousuarioResponsableRecepcion IS NULL THEN 'En espera de Asignacion' 
			ELSE dbo.ObtenerNombreCompletoUsuario(CodigousuarioResponsableRecepcion) END AS NombrePersonaResponsableRecepcion
	FROM ComprasProductos CP 
	INNER JOIN Proveedores P 
	ON P.CodigoProveedor = CP.CodigoProveedor
	INNER JOIN Usuarios U 
	ON U.CodigoUsuario = CP.CodigoUsuario
	LEFT JOIN Usuarios U2 
	ON U2.CodigoUsuario = CP.CodigoUsuarioResponsablePago
	LEFT JOIN Usuarios U3 
	ON U3.CodigoUsuario = CP.CodigoUsuarioResponsableRecepcion
	LEFT JOIN dbo.MedioTransporte MD
	ON MD.CodigoMedioTransporte = CP.CodigoMedioTransporte
	LEFT JOIN OrigenMercaderia OM
	ON OM.CodigoOrigenMercaderia = CP.CodigoOrigenMercaderia
	WHERE CP.NumeroAgencia = @NumeroAgencia
	AND CP.NumeroCompraProducto = @NumeroCompraProducto	
	
END
GO

--exec ListarCompraProductoReporte 1, 330
--select * from CompraProductosGastosDetalle


--EXEC ListarCompraProductoReporte 1,50
--declare @datos varchar(8000)
--exec ListarTuplaDatosCompraProductoReporte 1,2,@datos OUTPUT
--PRINT @DATOS

--DROP PROCEDURE ObtenerComprasProductos
--GO
--CREATE PROCEDURE ObtenerComprasProductos
--AS
--BEGIN
--	SELECT NumeroAgencia,NumeroCompraProducto,CodigoProveedor,Fecha,CodigoTipoCompra,CodigoEstadoCompra,MontoTotalCompra, Observaciones
--	FROM dbo.ComprasProductos
--END
--GO



DROP PROCEDURE ActualizarCodigoEstadoCompra
GO


CREATE PROCEDURE ActualizarCodigoEstadoCompra
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@CodigoEstadoCompra		CHAR(1),	
	@NumeroFactura			INT
AS
BEGIN
	IF(@NumeroFactura IS NULL)
	BEGIN
		UPDATE dbo.ComprasProductos
			SET CodigoEstadoCompra = @CodigoEstadoCompra,
				Fecha = GETDATE()
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroCompraProducto = @NumeroCompraProducto	
	END
	ELSE
	BEGIN
		UPDATE dbo.ComprasProductos
			SET CodigoEstadoCompra = @CodigoEstadoCompra,
				Fecha = GETDATE()
				--NumeroFactura = @NumeroFactura
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroCompraProducto = @NumeroCompraProducto	
	END
END
GO



DROP PROCEDURE InsertarCompraProductoXMLDetalle
GO
CREATE PROCEDURE InsertarCompraProductoXMLDetalle
	@NumeroAgencia						INT,
	@CodigoProveedor					INT,
	@CodigoUsuario						INT,
	@CodigoUsuarioResponsablePago		INT,
	@CodigoUsuarioResponsableRecepcion	INT,
	@FechaHoraPlazoDeRecepcion			DATETIME,
	@FechaHoraPago						DATETIME,
	@FechaHoraRecepcion					DATETIME,
	@Fecha								DATETIME,
	@CodigoTipoCompra					CHAR(1),
	@CodigoEstadoCompra					CHAR(1),
	@CodigoEstadoFactura				CHAR(1),
	@MontoTotalCompra					DECIMAL(10,2),
	@NumeroCuentaPorPagar				INT,
	@CodigoCompraProducto				CHAR(12),
	@DIPersonaDestinatario				CHAR(15),
	@FechaHoraEnvioMercaderia			DATETIME,
	@ImpuestoIVA						DECIMAL(5,2),
	@NumeroFactura						CHAR(10),
	@NumeroAutorizacionFactura			CHAR(10),
	@CodigoControlFactura				CHAR(10),
	@EsImportacion						BIT,
	@RegistroDirectoAlmacen				BIT,
	@CodigoMedioTransporte				TINYINT,
	@MontoDescuento						DECIMAL(10,2),
	@MontoNetoCompra					DECIMAL(10,2),
	@CodigoOrigenMercaderia				TINYINT,
	@NumeroGuiaTranposrte				CHAR(10),
	@CodigoMoneda						TINYINT,
	@Observaciones						TEXT,
	@ProductosDetalle					TEXT
AS
BEGIN

	BEGIN TRANSACTION
		set @MontoNetoCompra = ISNULL(@MontoNetoCompra, @MontoTotalCompra)
		
		INSERT INTO dbo.ComprasProductos (NumeroAgencia,CodigoProveedor, CodigoUsuario, 
			CodigoUsuarioResponsablePago, CodigoUsuarioResponsableRecepcion, FechaHoraPlazoDeRecepcion, FechaHoraPago, FechaHoraRecepcion,
			Fecha, CodigoTipoCompra, CodigoEstadoCompra, CodigoEstadoFactura, MontoTotalCompra, NumeroCuentaPorPagar, 
			--CodigoCompraProducto, 
			DIPersonaDestinatario, FechaHoraEnvioMercaderia, ImpuestoIVA,
			NumeroFactura, NumeroAutorizacionFactura, CodigoControlFactura, EsImportacion, RegistroDirectoAlmacen, 
			CodigoMedioTransporte, MontoDescuento, MontoNetoCompra,
			CodigoOrigenMercaderia, NumeroGuiaTranposrte, CodigoMoneda, Observaciones)
		VALUES (@NumeroAgencia, @CodigoProveedor, @CodigoUsuario, 
			@CodigoUsuarioResponsablePago, @CodigoUsuarioResponsableRecepcion, @FechaHoraPlazoDeRecepcion, @FechaHoraPago, @FechaHoraRecepcion,
			@Fecha, @CodigoTipoCompra, @CodigoEstadoCompra, @CodigoEstadoFactura, @MontoTotalCompra, @NumeroCuentaPorPagar, 
			--@CodigoCompraProducto, 
			@DIPersonaDestinatario, @FechaHoraEnvioMercaderia, @ImpuestoIVA,
			@NumeroFactura, @NumeroAutorizacionFactura, @CodigoControlFactura, @EsImportacion, @RegistroDirectoAlmacen, 
			@CodigoMedioTransporte, @MontoDescuento, @MontoNetoCompra,
			@CodigoOrigenMercaderia, @NumeroGuiaTranposrte, @CodigoMoneda, @Observaciones)
		
		DECLARE @punteroXMLProductosDetalle INT,
				@NumeroCompraProducto		INT
		
		--SET @NumeroCompraProducto = @@IDENTITY 
		SET @NumeroCompraProducto = SCOPE_IDENTITY()
					
		EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @ProductosDetalle
		
		INSERT INTO dbo.ComprasProductosDetalle (NumeroAgencia,NumeroCompraProducto,CodigoProducto,CantidadCompra,PrecioUnitarioCompra,TiempoGarantiaCompra)
		SELECT    @NumeroAgencia, @NumeroCompraProducto, CodigoProducto, Cantidad, Precio, Garantia
		FROM       OPENXML (@punteroXMLProductosDetalle, '/ComprasProductos/ComprasProductosDetalle',2)
					WITH (CodigoProducto		VARCHAR(15),
						  Cantidad				INT,
						  Precio				DECIMAL(10,2),
						  Garantia				INT
					)
		EXEC sp_xml_removedocument @punteroXMLProductosDetalle
	IF(@@ERROR <> 0)
	BEGIN
		RAISERROR('No se Pudo ingresar la Orden de Compra',1,16)	
		ROLLBACK TRAN
	END
	ELSE
		COMMIT TRANSACTION
END
GO



--select * from ComprasProductosDetalle
--GO

--EXEC InsertarCompraProducto2 1,1, 1, '21/2/2010','E','I','S',1202,NULL, 'SIN OBSERVACION', '<Productos>
--  <ProductosDetalle>
--    <CodigoProducto>1</CodigoProducto>
--    <NombreProducto>PROCESADOR DUAL CORE</NombreProducto>
--    <Cantidad>1</Cantidad>
--    <Precio>12.00</Precio>
--    <PrecioTotal>12.00</PrecioTotal>
--    <Garantia>0</Garantia>
--    <EsProductoEspecifico>false</EsProductoEspecifico>
--    <VendidoComoAgregado>false</VendidoComoAgregado>
--    <CantidadExistencia>1</CantidadExistencia>
--    <CantidadEntregada>1</CantidadEntregada>
--    <PorcentajeDescuento>0</PorcentajeDescuento>
--    <NumeroPrecioSeleccionado>1</NumeroPrecioSeleccionado>
--  </ProductosDetalle>  
--</Productos>'