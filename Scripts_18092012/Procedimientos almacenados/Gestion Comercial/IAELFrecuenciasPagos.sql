USE DOBLONES20
GO

DROP PROCEDURE InsertarFrecuenciaPago
GO

CREATE PROCEDURE InsertarFrecuenciaPago
	@NombreFrecuenciaPago	VARCHAR(250),
	@NumeroDias				INT
AS
BEGIN
	INSERT INTO dbo.FrecuenciasPagos (NombreFrecuenciaPago, NumeroDias)
	VALUES (@NombreFrecuenciaPago, @NumeroDias)
END
GO

DROP PROCEDURE ActualizarFrecuenciaPago
GO

CREATE PROCEDURE ActualizarFrecuenciaPago
	@CodigoFrecuenciaPago	INT,
	@NombreFrecuenciaPago	VARCHAR(250),
	@NumeroDias				INT
AS
BEGIN
	UPDATE 	dbo.FrecuenciasPagos
	SET		
		NombreFrecuenciaPago	= @NombreFrecuenciaPago,
		NumeroDias				= @NumeroDias
	WHERE	(CodigoFrecuenciaPago = @CodigoFrecuenciaPago)	
END
GO

DROP PROCEDURE EliminarFrecuenciaPago
GO

CREATE PROCEDURE EliminarFrecuenciaPago
	@CodigoFrecuenciaPago	INT
AS
BEGIN
	DELETE 
	FROM dbo.FrecuenciasPagos
	WHERE	(CodigoFrecuenciaPago = @CodigoFrecuenciaPago)		
END
GO

DROP PROCEDURE ListarFrecuenciasPagos
GO

CREATE PROCEDURE ListarFrecuenciasPagos
AS
BEGIN
	SELECT CodigoFrecuenciaPago, NombreFrecuenciaPago, NumeroDias 
	FROM dbo.FrecuenciasPagos
	ORDER BY CodigoFrecuenciaPago
END
GO

DROP PROCEDURE ObtenerFrecuenciaPago
GO

CREATE PROCEDURE ObtenerFrecuenciaPago
	@CodigoFrecuenciaPago	INT
AS
BEGIN
	SELECT CodigoFrecuenciaPago, NombreFrecuenciaPago, NumeroDias
	FROM dbo.FrecuenciasPagos
	WHERE	(CodigoFrecuenciaPago = @CodigoFrecuenciaPago)	
END
GO
