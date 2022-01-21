USE DOBLONES20
GO



DROP PROCEDURE InsertarDepositoBancario
GO
CREATE PROCEDURE InsertarDepositoBancario
	@NumeroAgencia		INT,
	@NumeroCuentaBanco	CHAR(30),
	@CodigoBanco		TINYINT,
	@Depositante		VARCHAR(200),
	@Monto				DECIMAL(10,2),
	@FechaHora			DATETIME,
	@CodigoMoneda		CHAR(2),
	@Observaciones		TEXT
AS
BEGIN
	INSERT INTO dbo.DepositosBancarios (NumeroAgencia,NumeroCuentaBanco,CodigoBanco,Depositante,Monto,FechaHora,CodigoMoneda,Observaciones)
	VALUES (@NumeroAgencia,@NumeroCuentaBanco,@CodigoBanco,@Depositante,@Monto,@FechaHora,@CodigoMoneda,@Observaciones)
END
GO


DROP PROCEDURE ActualizarDepositoBancario
GO
CREATE PROCEDURE ActualizarDepositoBancario
	@NumeroAgencia			INT,
	@NumeroDepositoBancario INT,
	@NumeroCuentaBanco		CHAR(30),
	@CodigoBanco			TINYINT,
	@Depositante			VARCHAR(200),
	@Monto					DECIMAL(10,2),
	@FechaHora				DATETIME,
	@CodigoMoneda			CHAR(2),
	@Observaciones			TEXT
AS
BEGIN
	UPDATE 	dbo.DepositosBancarios
	SET	
		CodigoBanco		= @CodigoBanco,
		Depositante		= @Depositante,
		Monto			= @Monto,
		FechaHora		= @FechaHora,
		CodigoMoneda	= @CodigoMoneda,
		Observaciones	= @Observaciones
	WHERE	(NumeroDepositoBancario	= @NumeroDepositoBancario)	
		AND (NumeroAgencia			= @NumeroAgencia)	
END
GO



DROP PROCEDURE EliminarDepositoBancario
GO
CREATE PROCEDURE EliminarDepositoBancario
	@NumeroAgencia			INT,
	@NumeroDepositoBancario INT
AS
BEGIN
	DELETE 
	FROM dbo.DepositosBancarios
	WHERE	(NumeroDepositoBancario	= @NumeroDepositoBancario)	
		AND (NumeroAgencia			= @NumeroAgencia)
END
GO



DROP PROCEDURE ListarDepositosBancarios
GO
CREATE PROCEDURE ListarDepositosBancarios
AS
BEGIN
	SELECT NumeroAgencia,NumeroDepositoBancario,CodigoBanco,NumeroCuentaBanco,Depositante,Monto,FechaHora,CodigoMoneda,Observaciones
	FROM dbo.DepositosBancarios
	ORDER BY NumeroDepositoBancario
END
GO



DROP PROCEDURE ObtenerDepositoBancario
GO
CREATE PROCEDURE ObtenerDepositoBancario
	@NumeroAgencia			INT,
	@NumeroDepositoBancario INT
AS
BEGIN
	SELECT NumeroAgencia,NumeroDepositoBancario,CodigoBanco,NumeroCuentaBanco,Depositante,Monto,FechaHora,CodigoMoneda,Observaciones
	FROM dbo.DepositosBancarios
	WHERE	(NumeroDepositoBancario	= @NumeroDepositoBancario)	
		AND (NumeroAgencia			= @NumeroAgencia)
END
GO



--DROP PROCEDURE ObtenerDepositosBancarios
--GO
--CREATE PROCEDURE ObtenerDepositosBancarios
--AS
--BEGIN
--	SELECT NumeroAgencia,NumeroDepositoBancario,NumeroCuentaBanco,Depositante,Monto,Fecha,CodigoMoneda,Observaciones
--	FROM dbo.DepositosBancarios
--END
--GO
	
