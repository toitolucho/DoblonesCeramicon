USE DOBLONES20
GO

DROP PROCEDURE InsertarCredito
GO
CREATE PROCEDURE InsertarCredito
--@NumeroCredito				INT				
@DIDeudor					CHAR(15),		
@DIGarante1					CHAR(15),		
@DIGarante2					CHAR(15),		
@DIGarante3					CHAR(15),		
@DIGarante4					CHAR(15),		
@DIGarante5					CHAR(15),		
@CodigoTipoCredito			CHAR(1),
@NumeroAgenciaCotizacion	INT,
@NumeroCotizacion			INT,
@CodigoSistemaAmortizacion	CHAR(1),			
@MontoDeuda					DECIMAL(10,2),	
@CodigoMoneda				TINYINT,			
@CodigoFrecuenciaPago		INT,				
@NumeroPeriodos				INT,			
@InteresAnual				DECIMAL(10,2),	
@InteresAnualMora			DECIMAL(10,2),	
@FechaPrimerPago			DATETIME,		
@FechaUltimoPago			DATETIME,		
@MontoDisponible			DECIMAL(10, 2),
@Observaciones				TEXT,			
@RegistrarContabilidad		BIT,				
@NumeroAgenciaSolicitud		INT,				
@CodigoUsuarioSolicitud		INT,				
@FechaHoraSolicitud			DATETIME,		
@NumeroAgenciaAutorizacion	INT,				
@CodigoUsuarioAutorizacion	INT,				
@FechaHoraAutorizacion		DATETIME,		
@CodigoAutorizacion			CHAR(10),		
@CodigoEstadoCredito		CHAR(1)		
AS
BEGIN
	INSERT INTO dbo.Creditos(DIDeudor, DIGarante1, DIGarante2, DIGarante3, DIGarante4, DIGarante5, CodigoTipoCredito, NumeroAgenciaCotizacion, NumeroCotizacion, CodigoSistemaAmortizacion, MontoDeuda, CodigoMoneda, CodigoFrecuenciaPago, NumeroPeriodos, InteresAnual, InteresAnualMora, FechaPrimerPago, FechaUltimoPago, MontoDisponible, Observaciones, RegistrarContabilidad, NumeroAgenciaSolicitud, CodigoUsuarioSolicitud, FechaHoraSolicitud, NumeroAgenciaAutorizacion, CodigoUsuarioAutorizacion, FechaHoraAutorizacion, CodigoAutorizacion, CodigoEstadoCredito)
	VALUES (@DIDeudor, @DIGarante1, @DIGarante2, @DIGarante3, @DIGarante4, @DIGarante5, @CodigoTipoCredito, @NumeroAgenciaCotizacion, @NumeroCotizacion, @CodigoSistemaAmortizacion, @MontoDeuda, @CodigoMoneda, @CodigoFrecuenciaPago, @NumeroPeriodos, @InteresAnual, @InteresAnualMora, @FechaPrimerPago, @FechaUltimoPago, @MontoDisponible, @Observaciones, @RegistrarContabilidad, @NumeroAgenciaSolicitud, @CodigoUsuarioSolicitud, @FechaHoraSolicitud, @NumeroAgenciaAutorizacion, @CodigoUsuarioAutorizacion, @FechaHoraAutorizacion, @CodigoAutorizacion, @CodigoEstadoCredito)
END
GO

DROP PROCEDURE ActualizarCredito
GO
CREATE PROCEDURE ActualizarCredito
@NumeroCredito				INT,
@DIDeudor					CHAR(15),		
@DIGarante1					CHAR(15),		
@DIGarante2					CHAR(15),		
@DIGarante3					CHAR(15),		
@DIGarante4					CHAR(15),		
@DIGarante5					CHAR(15),	
@CodigoTipoCredito			CHAR(1),
@NumeroAgenciaCotizacion	INT,
@NumeroCotizacion			INT,
@CodigoSistemaAmortizacion	CHAR(1),			
@MontoDeuda					DECIMAL(10,2),	
@CodigoMoneda				TINYINT,			
@CodigoFrecuenciaPago		INT,				
@NumeroPeriodos				INT,			
@InteresAnual				DECIMAL(10,2),	
@InteresAnualMora			DECIMAL(10,2),	
@FechaPrimerPago			DATETIME,		
@FechaUltimoPago			DATETIME,		
@MontoDisponible			DECIMAL(10, 2),
@Observaciones				TEXT,			
@RegistrarContabilidad		BIT,				
@NumeroAgenciaSolicitud		INT,				
@CodigoUsuarioSolicitud		INT,				
@FechaHoraSolicitud			DATETIME,		
@NumeroAgenciaAutorizacion	INT,				
@CodigoUsuarioAutorizacion	INT,				
@FechaHoraAutorizacion		DATETIME,		
@CodigoAutorizacion			CHAR(10),		
@CodigoEstadoCredito		CHAR(1)		
AS
BEGIN
	UPDATE 	dbo.Creditos
	SET				
		DIDeudor					= @DIDeudor,					
		DIGarante1					= @DIGarante1,					
		DIGarante2					= @DIGarante2,					
		DIGarante3					= @DIGarante3,					
		DIGarante4					= @DIGarante4,					
		DIGarante5					= @DIGarante5,		
		CodigoTipoCredito			= @CodigoTipoCredito,
		NumeroAgenciaCotizacion		= @NumeroAgenciaCotizacion,
		NumeroCotizacion			= @NumeroCotizacion,
		CodigoSistemaAmortizacion	= @CodigoSistemaAmortizacion,
		MontoDeuda					= @MontoDeuda,					
		CodigoMoneda				= @CodigoMoneda,				
		CodigoFrecuenciaPago		= @CodigoFrecuenciaPago,
		NumeroPeriodos				= @NumeroPeriodos,				
		InteresAnual				= @InteresAnual,				
		InteresAnualMora			= @InteresAnualMora,
		FechaPrimerPago				= @FechaPrimerPago,			
		FechaUltimoPago			    = @FechaUltimoPago,
		Observaciones				= @Observaciones,				
		RegistrarContabilidad		= @RegistrarContabilidad,
		NumeroAgenciaSolicitud		= @NumeroAgenciaSolicitud,		
		CodigoUsuarioSolicitud		= @CodigoUsuarioSolicitud,		
		FechaHoraSolicitud			= @FechaHoraSolicitud,			
		NumeroAgenciaAutorizacion	= @NumeroAgenciaAutorizacion,
		CodigoUsuarioAutorizacion	= @CodigoUsuarioAutorizacion,	
		FechaHoraAutorizacion		= @FechaHoraAutorizacion,		
		CodigoAutorizacion			= @CodigoAutorizacion,			
		CodigoEstadoCredito			= @CodigoEstadoCredito		
	WHERE (NumeroCredito = @NumeroCredito)
END
GO

DROP PROCEDURE EliminarCredito
GO
CREATE PROCEDURE EliminarCredito
	@NumeroCredito	INT
AS
BEGIN
	DELETE 
	FROM dbo.Creditos
	WHERE	(NumeroCredito = @NumeroCredito)
END
GO

DROP PROCEDURE ListarCreditos
GO
CREATE PROCEDURE ListarCreditos
AS
BEGIN
	SELECT NumeroCredito, DIDeudor, DIGarante1, DIGarante2, DIGarante3, DIGarante4, DIGarante5, CodigoTipoCredito, NumeroAgenciaCotizacion, NumeroCotizacion, CodigoSistemaAmortizacion, MontoDeuda, CodigoMoneda, CodigoFrecuenciaPago, NumeroPeriodos, InteresAnual, InteresAnualMora, FechaPrimerPago, FechaUltimoPago, MontoDisponible, Observaciones, RegistrarContabilidad, NumeroAgenciaSolicitud, CodigoUsuarioSolicitud, FechaHoraSolicitud, NumeroAgenciaAutorizacion, CodigoUsuarioAutorizacion, FechaHoraAutorizacion, CodigoAutorizacion, CodigoEstadoCredito
	FROM dbo.Creditos
	ORDER BY NumeroCredito
END
GO

DROP PROCEDURE ObtenerCredito
GO
CREATE PROCEDURE ObtenerCredito
	@NumeroCredito			INT
AS
BEGIN
	SELECT NumeroCredito, DIDeudor, DIGarante1, DIGarante2, DIGarante3, DIGarante4, DIGarante5, CodigoTipoCredito, NumeroAgenciaCotizacion, NumeroCotizacion, CodigoSistemaAmortizacion, MontoDeuda, CodigoMoneda, CodigoFrecuenciaPago, NumeroPeriodos, InteresAnual, InteresAnualMora, FechaPrimerPago, FechaUltimoPago, MontoDisponible, Observaciones, RegistrarContabilidad, NumeroAgenciaSolicitud, CodigoUsuarioSolicitud, FechaHoraSolicitud, NumeroAgenciaAutorizacion, CodigoUsuarioAutorizacion, FechaHoraAutorizacion, CodigoAutorizacion, CodigoEstadoCredito
	FROM dbo.Creditos
	WHERE	(NumeroCredito = @NumeroCredito)
END
GO


DROP PROCEDURE ObtenerCreditoAgencia
GO
CREATE PROCEDURE ObtenerCreditoAgencia
	@NumeroAgencia					INT,	
	@NumeroCredito			INT
AS
BEGIN
	SELECT NumeroCredito, DIDeudor, DIGarante1, DIGarante2, DIGarante3, DIGarante4, DIGarante5, CodigoSistemaAmortizacion, CodigoTipoCredito, NumeroAgenciaCotizacion, NumeroCotizacion, MontoDeuda, CodigoMoneda, CodigoFrecuenciaPago, NumeroPeriodos, InteresAnual, InteresAnualMora, FechaPrimerPago, FechaUltimoPago, MontoDisponible, Observaciones, RegistrarContabilidad, NumeroAgenciaSolicitud, CodigoUsuarioSolicitud, FechaHoraSolicitud, NumeroAgenciaAutorizacion, CodigoUsuarioAutorizacion, FechaHoraAutorizacion, CodigoAutorizacion, CodigoEstadoCredito
	FROM dbo.Creditos
	WHERE	(NumeroCredito = @NumeroCredito)
END
GO