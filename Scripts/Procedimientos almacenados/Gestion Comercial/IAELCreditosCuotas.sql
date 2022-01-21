USE DOBLONES20
GO

DROP PROCEDURE InsertarCreditoCuota
GO
CREATE PROCEDURE InsertarCreditoCuota
@NumeroCredito				INT,
@NumeroCuota				INT,
@FechaCuota					DATETIME,
@Cuota						DECIMAL(10, 2),
@CuotaAmortizacion			DECIMAL(10, 2),
@CuotaInteres				DECIMAL(10, 2),
@TotalAmortizado			DECIMAL(10, 2),
@SaldoAdeudado				DECIMAL(10, 2),
@TotalPagado				DECIMAL(10, 2)
AS
BEGIN
	INSERT INTO dbo.CreditosCuotas(NumeroCredito, NumeroCuota, FechaCuota, Cuota, CuotaAmortizacion, CuotaInteres, TotalAmortizado, SaldoAdeudado, TotalPagado)
	VALUES (@NumeroCredito, @NumeroCuota, @FechaCuota, @Cuota, @CuotaAmortizacion, @CuotaInteres, @TotalAmortizado, @SaldoAdeudado, @TotalPagado)
END
GO

DROP PROCEDURE ActualizarCreditoCuota
GO
CREATE PROCEDURE ActualizarCreditoCuota
@NumeroCredito				INT,
@NumeroCuota				INT,
@FechaCuota					DATETIME,
@Cuota						DECIMAL(10, 2),
@CuotaAmortizacion			DECIMAL(10, 2),
@CuotaInteres				DECIMAL(10, 2),
@TotalAmortizado			DECIMAL(10, 2),
@SaldoAdeudado				DECIMAL(10, 2),
@TotalPagado				DECIMAL(10, 2)
AS
BEGIN
	UPDATE 	dbo.CreditosCuotas
	SET				
		FechaCuota			= @FechaCuota,
		Cuota				= @Cuota,				
		CuotaAmortizacion	= @CuotaAmortizacion,	
		CuotaInteres		= @CuotaInteres,		
		TotalAmortizado		= @TotalAmortizado,	
		SaldoAdeudado		= @SaldoAdeudado,		
		TotalPagado			= @TotalPagado
	WHERE (NumeroCredito = @NumeroCredito AND NumeroCuota = @NumeroCuota)
END
GO

DROP PROCEDURE EliminarCreditoCuota
GO
CREATE PROCEDURE EliminarCreditoCuota
@NumeroCredito				INT,
@NumeroCuota				INT	
AS
BEGIN
	DELETE 
	FROM dbo.CreditosCuotas
	WHERE (NumeroCredito = @NumeroCredito AND NumeroCuota = @NumeroCuota)
END
GO

DROP PROCEDURE ListarCreditosCuotas
GO
CREATE PROCEDURE ListarCreditosCuotas
AS
BEGIN
	SELECT NumeroCredito, NumeroCuota, FechaCuota, Cuota, CuotaAmortizacion, CuotaInteres, TotalAmortizado, SaldoAdeudado, TotalPagado
	FROM dbo.CreditosCuotas
	ORDER BY NumeroCredito, NumeroCuota
END
GO

DROP PROCEDURE ListarCreditoCuotasNumeroCredito
GO
CREATE PROCEDURE ListarCreditoCuotasNumeroCredito
@NumeroCredito				INT
AS
BEGIN
	SELECT NumeroCredito, NumeroCuota, FechaCuota, Cuota, CuotaAmortizacion, CuotaInteres, TotalAmortizado, SaldoAdeudado, TotalPagado
	FROM dbo.CreditosCuotas
	WHERE NumeroCredito = @NumeroCredito
	ORDER BY NumeroCredito, NumeroCuota
END
GO

DROP PROCEDURE ObtenerCreditoCuota
GO
CREATE PROCEDURE ObtenerCreditoCuota
@NumeroCredito				INT,
@NumeroCuota				INT	
AS
BEGIN
	SELECT NumeroCredito, NumeroCuota, FechaCuota, Cuota, CuotaAmortizacion, CuotaInteres, TotalAmortizado, SaldoAdeudado, TotalPagado
	FROM dbo.CreditosCuotas
	WHERE (NumeroCredito = @NumeroCredito AND NumeroCuota = @NumeroCuota)
END
GO

DROP PROCEDURE ObtenerSiguienteCuotaPago
GO

CREATE PROCEDURE ObtenerSiguienteCuotaPago
@NumeroCredito	INT
AS

SELECT TOP 1 CC.NumeroCredito, CC.NumeroCuota, CC.FechaCuota, CC.Cuota, CC.CuotaAmortizacion, CC.CuotaInteres, CC.TotalAmortizado, CC.SaldoAdeudado, CC.TotalPagado
FROM CreditosCuotas CC
LEFT JOIN CreditosCuotasPagos CCP ON
CCP.NumeroCredito = CC.NumeroCredito
AND CCP.NumeroCuota = CC.NumeroCuota
WHERE CCP.NumeroCredito IS NULL
GO

