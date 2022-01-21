USE DOBLONES20
GO


DROP PROCEDURE InsertarCuentaPorPagarCuota
GO
CREATE PROCEDURE InsertarCuentaPorPagarCuota
	@NumeroAgencia			INT,
	@NumeroCuentaPorPagar	INT,
	@NumeroCuota			INT,
	@FechaHoraCuota			DATETIME,
	@NumeroDias				INT,
	@Cuota					DECIMAL(10,2),
	@CuotaInteres			DECIMAL(10,2),
	@CuotaCapital			DECIMAL(10,2),
	@SaldoCapital			DECIMAL(10,2)
AS
BEGIN
	INSERT INTO dbo.CuentasPorPagarCuotas (NumeroAgencia,NumeroCuentaPorPagar,NumeroCuota,FechaHoraCuota,NumeroDias,Cuota,CuotaInteres,CuotaCapital,SaldoCapital)
	VALUES (@NumeroAgencia,@NumeroCuentaPorPagar,@NumeroCuota,@FechaHoraCuota,@NumeroDias,@Cuota,@CuotaInteres,@CuotaCapital,@SaldoCapital)
END
GO



DROP PROCEDURE ActualizarCuentaPorPagarCuota
GO
CREATE PROCEDURE ActualizarCuentaPorPagarCuota
	@NumeroAgencia			INT,
	@NumeroCuentaPorPagar	INT,
	@NumeroCuota			INT,
	@FechaHoraCuota			DATETIME,
	@NumeroDias				INT,
	@Cuota					DECIMAL(10,2),
	@CuotaInteres			DECIMAL(10,2),
	@CuotaCapital			DECIMAL(10,2),
	@SaldoCapital			DECIMAL(10,2)
AS
BEGIN
	UPDATE 	dbo.CuentasPorPagarCuotas
	SET				
		NumeroCuentaPorPagar	= @NumeroCuentaPorPagar,
		NumeroCuota				= @NumeroCuota,
		FechaHoraCuota			= @FechaHoraCuota,
		NumeroDias				= @NumeroDias,
		Cuota					= @Cuota,
		CuotaInteres			= @CuotaInteres,
		CuotaCapital			= @CuotaCapital,
		SaldoCapital			= @SaldoCapital
	WHERE	(NumeroCuentaPorPagar	 = @NumeroCuentaPorPagar)
		AND (NumeroCuota			 = @NumeroCuota)
		AND (NumeroAgencia			 = @NumeroAgencia)
END
GO



DROP PROCEDURE EliminarCuentaPorPagarCuota
GO
CREATE PROCEDURE EliminarCuentaPorPagarCuota
	@NumeroAgencia			INT,
	@NumeroCuentaPorPagar	INT,
	@NumeroCuota			INT
AS
BEGIN
	DELETE 
	FROM dbo.CuentasPorPagarCuotas
	WHERE	(NumeroCuentaPorPagar	 = @NumeroCuentaPorPagar)
		AND (NumeroCuota			 = @NumeroCuota)
		AND (NumeroAgencia			 = @NumeroAgencia)
END
GO



DROP PROCEDURE ListarCuentasPorPagarCuotas
GO
CREATE PROCEDURE ListarCuentasPorPagarCuotas
AS
BEGIN
	SELECT NumeroAgencia,NumeroCuentaPorPagar,NumeroCuota,FechaHoraCuota,NumeroDias,Cuota,CuotaInteres,CuotaCapital,SaldoCapital
	FROM dbo.CuentasPorPagarCuotas
	ORDER BY NumeroAgencia, NumeroCuentaPorPagar, NumeroCuota
END
GO



DROP PROCEDURE ObtenerCuentaPorPagarCuota
GO
CREATE PROCEDURE ObtenerCuentaPorPagarCuota
	@NumeroAgencia			INT,
	@NumeroCuentaPorPagar	INT,
	@NumeroCuota			INT
AS
BEGIN
	SELECT NumeroAgencia,NumeroCuentaPorPagar,NumeroCuota,FechaHoraCuota,NumeroDias,Cuota,CuotaInteres,CuotaCapital,SaldoCapital
	FROM dbo.CuentasPorPagarCuotas
	WHERE	(NumeroCuentaPorPagar	 = @NumeroCuentaPorPagar)
		AND (NumeroCuota			 = @NumeroCuota)
		AND (NumeroAgencia			 = @NumeroAgencia)
END
GO



--DROP PROCEDURE ObtenerCuentasPorPagarCuotas
--GO
--CREATE PROCEDURE ObtenerCuentasPorPagarCuotas
--AS
--BEGIN
--	SELECT NumeroAgencia,NumeroCuentaPorPagar,NumeroCuota,FechaHoraCuota,NumeroDias,Cuota,CuotaInteres,CuotaCapital,SaldoCapital
--	FROM dbo.CuentasPorPagarCuotas
--END
--GO