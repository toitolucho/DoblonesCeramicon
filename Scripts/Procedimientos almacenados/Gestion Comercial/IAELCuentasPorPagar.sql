USE DOBLONES20
GO



DROP PROCEDURE InsertarCuentaPorPagar
GO
CREATE PROCEDURE InsertarCuentaPorPagar
	@NumeroAgencia				INT,
	@CodigoProveedor			INT,
	@MontoTotalCuentaPorPagar	DECIMAL(10,2),
	@NumeroPeriodos				INT,
	@FechaHoraRegistro			DATETIME,
	@CodigoFrecuenciaPago		INT,
	@TazaInteres				DECIMAL(10,2),
	@TazaInteresVencimiento		DECIMAL(10,2),
	@TazaInteresMora			DECIMAL(10,2),
	@Observaciones				TEXT,
	@CodigoEstadoCuentaPorPagar	CHAR(1)
AS
BEGIN
	INSERT INTO dbo.CuentasPorPagar (NumeroAgencia,CodigoProveedor,MontoTotalCuentaPorPagar,NumeroPeriodos,FechaHoraRegistro,CodigoFrecuenciaPago,TazaInteres,TazaInteresVencimiento,TazaInteresMora,Observaciones,CodigoEstadoCuentaPorPagar)
	VALUES (@NumeroAgencia,@CodigoProveedor,@MontoTotalCuentaPorPagar,@NumeroPeriodos,@FechaHoraRegistro,@CodigoFrecuenciaPago,@TazaInteres,@TazaInteresVencimiento,@TazaInteresMora,@Observaciones,@CodigoEstadoCuentaPorPagar)
END
GO



DROP PROCEDURE ActualizarCuentaPorPagar
GO
CREATE PROCEDURE ActualizarCuentaPorPagar
	@NumeroAgencia				INT,
	@NumeroCuentaPorPagar		INT,
	@CodigoProveedor			INT,
	@MontoTotalCuentaPorPagar	DECIMAL(10,2),
	@NumeroPeriodos				INT,
	@FechaHoraRegistro			DATETIME,
	@CodigoFrecuenciaPago		INT,
	@TazaInteres				DECIMAL(10,2),
	@TazaInteresVencimiento		DECIMAL(10,2),
	@TazaInteresMora			DECIMAL(10,2),
	@Observaciones				TEXT,
	@CodigoEstadoCuentaPorPagar	CHAR(1)
AS
BEGIN
	UPDATE 	dbo.CuentasPorPagar
	SET				
		CodigoProveedor				= @CodigoProveedor,
		MontoTotalCuentaPorPagar	= @MontoTotalCuentaPorPagar,
		NumeroPeriodos				= @NumeroPeriodos,
		FechaHoraRegistro			= @FechaHoraRegistro,
		CodigoFrecuenciaPago		= @CodigoFrecuenciaPago,
		TazaInteres					= @TazaInteres,
		TazaInteresVencimiento		= @TazaInteresVencimiento,
		TazaInteresMora				= @TazaInteresMora,
		Observaciones				= @Observaciones,
		CodigoEstadoCuentaPorPagar	= @CodigoEstadoCuentaPorPagar
	WHERE	(NumeroCuentaPorPagar = @NumeroCuentaPorPagar)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE EliminarCuentaPorPagar
GO
CREATE PROCEDURE EliminarCuentaPorPagar
	@NumeroAgencia				INT,
	@NumeroCuentaPorPagar		INT	
AS
BEGIN
	DELETE 
	FROM dbo.CuentasPorPagar
	WHERE	(NumeroCuentaPorPagar = @NumeroCuentaPorPagar)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE ListarCuentasPorPagar
GO
CREATE PROCEDURE ListarCuentasPorPagar
AS
BEGIN
	SELECT NumeroAgencia,NumeroCuentaPorPagar,CodigoProveedor,MontoTotalCuentaPorPagar,NumeroPeriodos,FechaHoraRegistro,CodigoFrecuenciaPago,TazaInteres,TazaInteresVencimiento,TazaInteresMora,Observaciones,CodigoEstadoCuentaPorPagar
	FROM dbo.CuentasPorPagar
	ORDER BY NumeroAgencia, NumeroCuentaPorPagar
END
GO



DROP PROCEDURE ObtenerCuentaPorPagar
GO
CREATE PROCEDURE ObtenerCuentaPorPagar
	@NumeroAgencia				INT,
	@NumeroCuentaPorPagar		INT
AS
BEGIN
	SELECT NumeroAgencia,NumeroCuentaPorPagar,CodigoProveedor,MontoTotalCuentaPorPagar,NumeroPeriodos,FechaHoraRegistro,CodigoFrecuenciaPago,TazaInteres,TazaInteresVencimiento,TazaInteresMora,Observaciones,CodigoEstadoCuentaPorPagar
	FROM dbo.CuentasPorPagar
	WHERE	(NumeroCuentaPorPagar = @NumeroCuentaPorPagar)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO

DROP PROCEDURE ObtenerCuentaPorPagarDeuda
GO

CREATE PROCEDURE ObtenerCuentaPorPagarDeuda
	@NumeroAgencia				INT,
	@NumeroCuentaPorPagar		INT,
	@MontoTotalCuentaPorPagar	DECIMAL(10,2) OUTPUT
AS
BEGIN
	SELECT @MontoTotalCuentaPorPagar = Monto
	FROM dbo.CuentasPorPagar
	WHERE	(NumeroCuentaPorPagar = @NumeroCuentaPorPagar)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO

--DROP PROCEDURE ObtenerCuentasPorPagar
--GO
--CREATE PROCEDURE ObtenerCuentasPorPagar
--AS
--BEGIN
--	SELECT NumeroAgencia,NumeroCuentaPorPagar,CodigoProveedor,MontoTotalCuentaPorPagar,NumeroPeriodos,FechaHoraRegistro,CodigoFrecuenciaPago,TazaInteres,TazaInteresVencimiento,TazaInteresMora,Observaciones,CodigoEstadoCuentaPorPagar
--	FROM dbo.CuentasPorPagar
--END
--GO
	
