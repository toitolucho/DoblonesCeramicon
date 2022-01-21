USE DOBLONES20
GO



DROP PROCEDURE InsertarAgencia
GO
CREATE PROCEDURE InsertarAgencia
	@NombreAgencia			VARCHAR(250),
	@CodigoPais				CHAR(2),
	@CodigoDepartamento		CHAR(2),
	@CodigoProvincia		CHAR(2),
	@CodigoLugar			CHAR(3),
	@DireccionAgencia		VARCHAR(250),
	@NITAgencia				CHAR(30),
	@NumeroSiguienteFactura	INT,
	@NumeroAutorizacion		CHAR(30),
	@DIResponsable			CHAR(15),
	@NumeroAgenciaSuperior	INT
AS
BEGIN
	INSERT INTO dbo.Agencias (NombreAgencia,CodigoPais,CodigoDepartamento,CodigoProvincia,CodigoLugar,DireccionAgencia,NITAgencia, NumeroSiguienteFactura, NumeroAutorizacion, DIResponsable, NumeroAgenciaSuperior)
	VALUES (@NombreAgencia,@CodigoPais,@CodigoDepartamento,@CodigoProvincia,@CodigoLugar,@DireccionAgencia, @NITAgencia, @NumeroSiguienteFactura, @NumeroAutorizacion,@DIResponsable, @NumeroAgenciaSuperior)
END
GO



DROP PROCEDURE ActualizarAgencia
GO
CREATE PROCEDURE ActualizarAgencia
	@NumeroAgencia			INT,
	@NombreAgencia			VARCHAR(250),
	@CodigoPais				CHAR(2),
	@CodigoDepartamento		CHAR(2),
	@CodigoProvincia		CHAR(2),
	@CodigoLugar			CHAR(3),
	@DireccionAgencia		VARCHAR(250),
	@NITAgencia				CHAR(30),
	@NumeroSiguienteFactura	INT,
	@NumeroAutorizacion		CHAR(30),
	@DIResponsable			CHAR(15),
	@NumeroAgenciaSuperior	INT
AS
BEGIN
	UPDATE 	dbo.Agencias
	SET			
		NombreAgencia			= @NombreAgencia,
		CodigoPais				= @CodigoPais,
		CodigoDepartamento		= @CodigoDepartamento,
		CodigoProvincia			= @CodigoProvincia,
		CodigoLugar				= @CodigoLugar,
		DireccionAgencia		= @DireccionAgencia,
		NITAgencia				= @NITAgencia,
		NumeroSiguienteFactura	= @NumeroSiguienteFactura,
		NumeroAutorizacion		= @NumeroAutorizacion,			
		DIResponsable			= @DIResponsable,
		NumeroAgenciaSuperior	= @NumeroAgenciaSuperior
	WHERE (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE EliminarAgencia
GO
CREATE PROCEDURE EliminarAgencia
	@NumeroAgencia	INT
AS
BEGIN
	DELETE 
	FROM dbo.Agencias
	WHERE (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE ListarAgencias
GO
CREATE PROCEDURE ListarAgencias
AS
BEGIN
	SELECT NumeroAgencia,NombreAgencia,CodigoPais,CodigoDepartamento,CodigoProvincia,CodigoLugar,DireccionAgencia,NITAgencia, NumeroSiguienteFactura, NumeroAutorizacion, DIResponsable, NumeroAgenciaSuperior
	FROM dbo.Agencias
	ORDER BY NumeroAgencia
END
GO

DROP PROCEDURE ObtenerAgencia
GO
CREATE PROCEDURE ObtenerAgencia
	@NumeroAgencia		INT
AS
BEGIN
	SELECT NumeroAgencia,NombreAgencia,CodigoPais,CodigoDepartamento,CodigoProvincia,CodigoLugar,DireccionAgencia,NITAgencia, NumeroSiguienteFactura, NumeroAutorizacion, DIResponsable, NumeroAgenciaSuperior
	FROM dbo.Agencias
	WHERE (NumeroAgencia = @NumeroAgencia)
END
GO
