USE Doblones20
GO

DROP PROCEDURE GenerarTablaAmortizaciones
GO

CREATE PROCEDURE GenerarTablaAmortizaciones
@NumeroCredito				INT,
@CodigoSistema				CHAR(1),
@V							DECIMAL(20, 9),		--Monto deuda
@n							INT,				--Numero periodos
@CodigoFrecuenciaPago		INT,				--Codigo frecuencia pago
@ia							DECIMAL(20, 9),		--Interes anual
@FechaPrimeraAmortizacion	DATETIME			
AS

DECLARE @npa				INT					--Numero periodos por año
DECLARE @i					DECIMAL(20, 9)		--Interes por periodo
DECLARE @C					DECIMAL(20, 9)		--Cuota total (amortizacion + interes)
DECLARE @CAux				DECIMAL(20, 9)		--Auxiliar Valor total 
DECLARE @r					DECIMAL(20, 9)		--Cuota amortizacion
DECLARE @IC					DECIMAL(20, 9)		--Interes por cuota
DECLARE @T					DECIMAL(20, 9)		--Valor total amortizado
DECLARE @S					DECIMAL(20, 9)		--Valor saldo del prestamo
DECLARE @TA					DECIMAL(20, 9)		--Valor total abonado total amortizacion + intereses	
DECLARE @ContadorPeriodos	INT
DECLARE @FechaAmortizacion	DATE

SELECT @npa = 360 / NumeroDias
FROM FrecuenciasPagos
WHERE CodigoFrecuenciaPago = @CodigoFrecuenciaPago

SET @i = @ia / 100 / @npa
SET @FechaAmortizacion = @FechaPrimeraAmortizacion

SET @TA = 0
SET @CAux = 0

DELETE 
FROM CreditosCuotas
WHERE NumeroCredito = @NumeroCredito

IF (@CodigoSistema = 'A')
BEGIN
	--SISTEMA ALEMAN
	SET @r = @V / @n
	SET @S = @V
	
	--SELECT @r
	
	SET @ContadorPeriodos = 1
	WHILE (@ContadorPeriodos <= @n)
	BEGIN
		SET @IC = @i * @S
		SET @C = @r + @IC
		SET @S = @V - @ContadorPeriodos * @r
		SET @T = @r * @ContadorPeriodos 
		SET @TA = @CAux + @C  
		INSERT INTO CreditosCuotas(NumeroCredito, NumeroCuota, FechaCuota, Cuota, CuotaAmortizacion, CuotaInteres, TotalAmortizado, SaldoAdeudado, TotalPagado)
		VALUES (@NumeroCredito, @ContadorPeriodos, @FechaAmortizacion, @C, @r, @IC, @T, @S, @TA)
		
		SET @FechaAmortizacion = DATEADD("m", 1, @FechaAmortizacion)

		SET @ContadorPeriodos = @ContadorPeriodos + 1
	    
	    SET @CAux = @TA
	END
END

IF (@CodigoSistema = 'F')
BEGIN
	--SISTEMA FRANCES
	
	IF (@i > 0)
	BEGIN
		SET @C = @V / 
		((POWER( 1 + @i, @n) - 1) / 
		(@i * POWER( 1 + @i, @n)))
	END
	ELSE
	BEGIN
		SET @C = @V / @n
	END
	
	SET @ContadorPeriodos = 1
	WHILE (@ContadorPeriodos <= @n)
	BEGIN
		SET @r = @C * (1 / POWER( 1 + @i, @n - @ContadorPeriodos + 1))
		SET @IC = @C - @r
		IF (@i > 0)
		BEGIN
			SET @T = @C * (1 / POWER(1 + @i, @n - @ContadorPeriodos)) * ((POWER(1 + @i, @ContadorPeriodos) - 1)/(@i * POWER(1 + @i, @ContadorPeriodos)))
		END
		ELSE
		BEGIN
			SET @T = @C * @ContadorPeriodos
		END
		
		SET @S = @V - @T
		SET @TA = @TA + @C
		
		INSERT INTO CreditosCuotas(NumeroCredito, NumeroCuota, FechaCuota, Cuota, CuotaAmortizacion, CuotaInteres, TotalAmortizado, SaldoAdeudado, TotalPagado)
		VALUES (@NumeroCredito, @ContadorPeriodos, @FechaAmortizacion, @C, @r, @IC, @T, @S, @TA)
		
		SET @FechaAmortizacion = DATEADD("m", 1, @FechaAmortizacion)
		SET @ContadorPeriodos = @ContadorPeriodos + 1
	END
END
GO