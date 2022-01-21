USE DOBLONES20
GO

DROP PROCEDURE InsertarCreditoCuotaPago
GO
CREATE PROCEDURE InsertarCreditoCuotaPago
@NumeroCredito				INT,
@NumeroCuota				INT,				
@MontoPago					DECIMAL(10, 2),
@CodigoMedioPago			CHAR(1),
@NumeroCuentaBanco			CHAR(30),	
@DIPersonaPago				VARCHAR(15),
@NombreCompletoPersonaPago	VARCHAR(250),	
@NumeroAgencia				INT,		
@CodigoUsuario				INT			
AS
BEGIN
	INSERT INTO dbo.CreditosCuotasPagos(NumeroCredito, NumeroCuota, FechaHoraPago, MontoPago, CodigoMedioPago, NumeroCuentaBanco, DIPersonaPago, NombreCompletoPersonaPago, NumeroAgencia, CodigoUsuario)
	VALUES (@NumeroCredito, @NumeroCuota, GETDATE(), @MontoPago, @CodigoMedioPago, @NumeroCuentaBanco, @DIPersonaPago, @NombreCompletoPersonaPago, @NumeroAgencia, @CodigoUsuario)
END
GO

DROP PROCEDURE ActualizarCreditoCuotaPago
GO
CREATE PROCEDURE ActualizarCreditoCuotaPago
@NumeroCredito				INT,
@NumeroCuota				INT,				
@MontoPago					DECIMAL(10, 2),
@CodigoMedioPago			CHAR(1),
@NumeroCuentaBanco			CHAR(30),		
@DIPersonaPago				VARCHAR(15),
@NombreCompletoPersonaPago	VARCHAR(250),
@NumeroAgencia				INT,		
@CodigoUsuario				INT			
AS
BEGIN
	UPDATE 	dbo.CreditosCuotasPagos
	SET				
		NumeroCredito		= @NumeroCredito,
		NumeroCuota			= @NumeroCuota,	
		FechaHoraPago		= GETDATE(),		
		MontoPago			= @MontoPago,			
		CodigoMedioPago		= @CodigoMedioPago,
		NumeroCuentaBanco	= @NumeroCuentaBanco,
		DIPersonaPago		= @DIPersonaPago,
		NombreCompletoPersonaPago = @NombreCompletoPersonaPago,
		NumeroAgencia		= @NumeroAgencia,	
		CodigoUsuario		= @CodigoUsuario		
	WHERE (NumeroCredito = @NumeroCredito AND NumeroCuota = @NumeroCuota)
END
GO

DROP PROCEDURE EliminarCreditoCuotaPago
GO
CREATE PROCEDURE EliminarCreditoCuotaPago
@NumeroCredito				INT,
@NumeroCuota				INT	
AS
BEGIN
	DELETE 
	FROM dbo.CreditosCuotasPagos
	WHERE (NumeroCredito = @NumeroCredito AND NumeroCuota = @NumeroCuota)
END
GO

DROP PROCEDURE ListarCreditosCuotasPagos
GO
CREATE PROCEDURE ListarCreditosCuotasPagos
AS
BEGIN
	SELECT NumeroCredito, NumeroCuota, FechaHoraPago, MontoPago, CodigoMedioPago, NumeroCuentaBanco, DIPersonaPago, NombreCompletoPersonaPago, NumeroAgencia, CodigoUsuario
	FROM dbo.CreditosCuotasPagos
	ORDER BY NumeroCredito, NumeroCuota
END
GO

DROP PROCEDURE ListarCreditosCuotasPagosNumeroCredito
GO
CREATE PROCEDURE ListarCreditosCuotasPagosNumeroCredito
@NumeroCredito				INT
AS
BEGIN
	SELECT NumeroCredito, NumeroCuota, FechaHoraPago, MontoPago, CodigoMedioPago, NumeroCuentaBanco, DIPersonaPago, NombreCompletoPersonaPago, NumeroAgencia, CodigoUsuario
	FROM dbo.CreditosCuotasPagos
	WHERE NumeroCredito = @NumeroCredito
	ORDER BY NumeroCredito, NumeroCuota
END
GO



DROP PROCEDURE ObtenerCreditoCuotaPago
GO
CREATE PROCEDURE ObtenerCreditoCuotaPago
@NumeroCredito				INT,
@NumeroCuota				INT	
AS
BEGIN
	SELECT NumeroCredito, NumeroCuota, FechaHoraPago, MontoPago, CodigoMedioPago, NumeroCuentaBanco, DIPersonaPago, NombreCompletoPersonaPago, NumeroAgencia, CodigoUsuario
	FROM dbo.CreditosCuotasPagos
	WHERE (NumeroCredito = @NumeroCredito AND NumeroCuota = @NumeroCuota)
END
GO