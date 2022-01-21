USE DOBLONES20
GO

DROP PROCEDURE InsertarSistemaConfiguracion
GO

CREATE PROCEDURE InsertarSistemaConfiguracion
	@CodigoMonedaSistema	TINYINT,
	@PorcentajeImpuesto		DECIMAL(10,2),
	@NumeroAgencia			INT,
	@NumeroAgenciaPrincipal	INT
AS
BEGIN
	INSERT INTO dbo.SistemaConfiguracion (CodigoMonedaSistema,PorcentajeImpuesto,NumeroAgencia,NumeroAgenciaPrincipal)
	VALUES (@CodigoMonedaSistema,@PorcentajeImpuesto,@NumeroAgencia,@NumeroAgenciaPrincipal)
END
GO

DROP PROCEDURE ActualizarSistemaConfiguracion
GO

CREATE PROCEDURE ActualizarSistemaConfiguracion
	@CodigoMonedaSistema	TINYINT,
	@PorcentajeImpuesto		DECIMAL(10,2),
	@NumeroAgencia			INT,
	@NumeroAgenciaPrincipal	INT
AS
BEGIN
	UPDATE 	dbo.SistemaConfiguracion
	SET				
		CodigoMonedaSistema		= @CodigoMonedaSistema,
		PorcentajeImpuesto		= @PorcentajeImpuesto,
		NumeroAgencia			= @NumeroAgencia,
		NumeroAgenciaPrincipal	= @NumeroAgenciaPrincipal	
END
GO

DROP PROCEDURE EliminarSistemaConfiguracion
GO

CREATE PROCEDURE EliminarSistemaConfiguracion
	@CodigoMonedaSistema	TINYINT
AS
BEGIN
	DELETE 
	FROM dbo.SistemaConfiguracion
	WHERE CodigoMonedaSistema = @CodigoMonedaSistema
END
GO

DROP PROCEDURE ListarSistemaConfiguracion
GO

CREATE PROCEDURE ListarSistemaConfiguracion
AS
BEGIN
	SELECT CodigoMonedaSistema,PorcentajeImpuesto,NumeroAgencia,NumeroAgenciaPrincipal
	FROM dbo.SistemaConfiguracion
	ORDER BY CodigoMonedaSistema
END
GO

DROP PROCEDURE ObtenerSistemaConfiguracion
GO

CREATE PROCEDURE ObtenerSistemaConfiguracion
	@CodigoMonedaSistema	TINYINT
AS
BEGIN
	SELECT CodigoMonedaSistema,PorcentajeImpuesto,NumeroAgencia,NumeroAgenciaPrincipal
	FROM dbo.SistemaConfiguracion
	WHERE CodigoMonedaSistema = @CodigoMonedaSistema
END
GO



DROP PROCEDURE ObtenerSistemaConfiguracionAgencia
GO

CREATE PROCEDURE ObtenerSistemaConfiguracionAgencia
	@NumeroAgencia	INT
AS
BEGIN
	SELECT CodigoMonedaSistema,PorcentajeImpuesto,NumeroAgencia,NumeroAgenciaPrincipal
	FROM dbo.SistemaConfiguracion
	WHERE  NumeroAgencia= @NumeroAgencia
END
GO
--DROP PROCEDURE ObtenerConfiguracionesSistema
--GO
--CREATE PROCEDURE ObtenerConfiguracionesSistema
--AS
--BEGIN
--	SELECT CodigoMonedaSistema,PorcentajeImpuesto,NumeroAgencia,NumeroAgenciaPrincipal
--	FROM dbo.SistemaConfiguracion
--END
--GO

