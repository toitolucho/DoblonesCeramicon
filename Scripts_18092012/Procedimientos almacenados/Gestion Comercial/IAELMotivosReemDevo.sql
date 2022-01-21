USE DOBLONES20
GO

DROP PROCEDURE InsertarMotivoReemDevo
GO

CREATE PROCEDURE InsertarMotivoReemDevo

	@NombreMotivoReemDevo		VARCHAR(250),
	@EstadoRetornoInventario	CHAR(1),
	@TipoTransaccion			CHAR(1)
AS
BEGIN
	INSERT INTO dbo.MotivosReemDevo ( NombreMotivoReemDevo, EstadoRetornoInventario, TipoTransaccion)
	VALUES ( @NombreMotivoReemDevo, @EstadoRetornoInventario, @TipoTransaccion)
END	
GO

DROP PROCEDURE ActualizarMotivoReemDevo
GO

CREATE PROCEDURE ActualizarMotivoReemDevo
	@CodigoMotivoReemDevo		INT,
	@NombreMotivoReemDevo		VARCHAR(250),
	@EstadoRetornoInventario	CHAR(1), 
	@TipoTransaccion			CHAR(1)
AS
BEGIN
	UPDATE 	dbo.MotivosReemDevo
	SET			
		NombreMotivoReemDevo	= @NombreMotivoReemDevo,
		EstadoRetornoInventario	= @EstadoRetornoInventario,
		TipoTransaccion		= @TipoTransaccion
	WHERE (CodigoMotivoReemDevo = @CodigoMotivoReemDevo)
END
GO

DROP PROCEDURE EliminarMotivoReemDevo
GO

CREATE PROCEDURE EliminarMotivoReemDevo
	@CodigoMotivoReemDevo	INT
AS
BEGIN
	DELETE 
	FROM dbo.MotivosReemDevo
	WHERE (CodigoMotivoReemDevo = @CodigoMotivoReemDevo)
END
GO

DROP PROCEDURE ListarMotivosReemDevo
GO

CREATE PROCEDURE ListarMotivosReemDevo
AS
BEGIN
	SELECT CodigoMotivoReemDevo, NombreMotivoReemDevo , EstadoRetornoInventario, TipoTransaccion
	FROM dbo.MotivosReemDevo
	ORDER BY CodigoMotivoReemDevo
END
GO

DROP PROCEDURE ObtenerMotivoReemDevo
GO

CREATE PROCEDURE ObtenerMotivoReemDevo
	@CodigoMotivoReemDevo	INT
AS
BEGIN
	SELECT CodigoMotivoReemDevo, NombreMotivoReemDevo , EstadoRetornoInventario, TipoTransaccion
	FROM dbo.MotivosReemDevo
	WHERE (CodigoMotivoReemDevo = @CodigoMotivoReemDevo)
END
GO


DROP PROCEDURE ListarMotivosReemDevoParaTransacciones
GO

CREATE PROCEDURE ListarMotivosReemDevoParaTransacciones
@TipoTransaccion CHAR(1)
AS
BEGIN
	SELECT CodigoMotivoReemDevo, NombreMotivoReemDevo , EstadoRetornoInventario, TipoTransaccion
	FROM dbo.MotivosReemDevo
	WHERE TipoTransaccion = @TipoTransaccion 
	ORDER BY CodigoMotivoReemDevo
END
GO