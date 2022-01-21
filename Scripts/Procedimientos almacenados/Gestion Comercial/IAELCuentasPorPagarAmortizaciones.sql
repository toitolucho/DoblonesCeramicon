USE DOBLONES20
GO


DROP PROCEDURE InsertarCuentaPorPagarAmortizacion
GO
CREATE PROCEDURE InsertarCuentaPorPagarAmortizacion
	@NumeroAgencia			INT,
	@NumeroCuentaPorPagar	INT,
	@FechaHoraAmortizacion	DATETIME,
	@Amortizacion			DECIMAL(10,2),
	@AmortizacionInteres	DECIMAL(10,2),
	@AmortizacionCapital	DECIMAL(10,2),
	@SaldoCapital			DECIMAL(10,2),
	@InteresVencimiento		DECIMAL(10,2),
	@InteresMora			DECIMAL(10,2),
	@TotalAmortizacion		DECIMAL(10,2),
	@CodigoMedioPago		CHAR(1),
	@NumeroCuentaBanco		CHAR(30)
AS
BEGIN
	INSERT INTO dbo.CuentasPorPagarAmortizaciones (NumeroAgencia, NumeroCuentaPorPagar,FechaHoraAmortizacion,Amortizacion,AmortizacionInteres,AmortizacionCapital,SaldoCapital,InteresVencimiento,InteresMora,TotalAmortizacion,CodigoMedioPago,NumeroCuentaBanco)
	VALUES (@NumeroAgencia,@NumeroCuentaPorPagar,@FechaHoraAmortizacion,@Amortizacion,@AmortizacionInteres,@AmortizacionCapital,@SaldoCapital,@InteresVencimiento,@InteresMora,@TotalAmortizacion,@CodigoMedioPago,@NumeroCuentaBanco)
END
GO



DROP PROCEDURE ActualizarCuentaPorPagarAmortizacion
GO
CREATE PROCEDURE ActualizarCuentaPorPagarAmortizacion
	@NumeroAgencia			INT,
	@NumeroCuentaPorPagar	INT,
	@FechaHoraAmortizacion	DATETIME,
	@Amortizacion			DECIMAL(10,2),
	@AmortizacionInteres	DECIMAL(10,2),
	@AmortizacionCapital	DECIMAL(10,2),
	@SaldoCapital			DECIMAL(10,2),
	@InteresVencimiento		DECIMAL(10,2),
	@InteresMora			DECIMAL(10,2),
	@TotalAmortizacion		DECIMAL(10,2),
	@CodigoMedioPago		CHAR(1),
	@NumeroCuentaBanco		CHAR(30)
AS
BEGIN
	UPDATE 	dbo.CuentasPorPagarAmortizaciones
	SET				
		NumeroCuentaPorPagar	= @NumeroCuentaPorPagar,
		FechaHoraAmortizacion	= @FechaHoraAmortizacion,
		Amortizacion			= @Amortizacion,
		AmortizacionInteres		= @AmortizacionInteres,
		AmortizacionCapital		= @AmortizacionCapital,
		SaldoCapital			= @SaldoCapital,
		InteresVencimiento		= @InteresVencimiento,
		InteresMora				= @InteresMora,
		TotalAmortizacion		= @TotalAmortizacion,
		CodigoMedioPago			= @CodigoMedioPago,
		NumeroCuentaBanco		= @NumeroCuentaBanco
	WHERE	(NumeroCuentaPorPagar = @NumeroCuentaPorPagar)
		AND (FechaHoraAmortizacion = @FechaHoraAmortizacion)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE EliminarCuentaPorPagarAmortizacion
GO
CREATE PROCEDURE EliminarCuentaPorPagarAmortizacion
	@NumeroAgencia			INT,
	@NumeroCuentaPorPagar	INT,
	@FechaHoraAmortizacion	DATETIME
AS
BEGIN
	DELETE 
	FROM dbo.CuentasPorPagarAmortizaciones
	WHERE	(NumeroCuentaPorPagar = @NumeroCuentaPorPagar)
		AND (FechaHoraAmortizacion = @FechaHoraAmortizacion)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE ListarCuentasPorPagarAmortizaciones
GO
CREATE PROCEDURE ListarCuentasPorPagarAmortizaciones
AS
BEGIN
	SELECT NumeroAgencia,NumeroCuentaPorPagar,FechaHoraAmortizacion,Amortizacion,AmortizacionInteres,AmortizacionCapital,SaldoCapital,InteresVencimiento,InteresMora,TotalAmortizacion,CodigoMedioPago,NumeroCuentaBanco
	FROM dbo.CuentasPorPagarAmortizaciones
	ORDER BY NumeroAgencia, NumeroCuentaPorPagar, FechaHoraAmortizacion
END
GO



DROP PROCEDURE ObtenerCuentaPorPagarAmortizacion
GO
CREATE PROCEDURE ObtenerCuentaPorPagarAmortizacion
	@NumeroAgencia			INT,
	@NumeroCuentaPorPagar	INT,
	@FechaHoraAmortizacion	DATETIME
AS
BEGIN
	SELECT NumeroAgencia,NumeroCuentaPorPagar,FechaHoraAmortizacion,Amortizacion,AmortizacionInteres,AmortizacionCapital,SaldoCapital,InteresVencimiento,InteresMora,TotalAmortizacion,CodigoMedioPago,NumeroCuentaBanco
	FROM dbo.CuentasPorPagarAmortizaciones
	WHERE	(NumeroCuentaPorPagar = @NumeroCuentaPorPagar)
		AND (FechaHoraAmortizacion = @FechaHoraAmortizacion)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO



--DROP PROCEDURE ObtenerCuentasPorPagarAmortizaciones
--GO
--CREATE PROCEDURE ObtenerCuentasPorPagarAmortizaciones
--AS
--BEGIN
--	SELECT NumeroAgencia,NumeroCuentaPorPagar,FechaHoraAmortizacion,Amortizacion,AmortizacionInteres,AmortizacionCapital,SaldoCapital,InteresVencimiento,InteresMora,TotalAmortizacion,CodigoMedioPago,NumeroCuentaBanco
--	FROM dbo.CuentasPorPagarAmortizaciones
--END
--GO
	
