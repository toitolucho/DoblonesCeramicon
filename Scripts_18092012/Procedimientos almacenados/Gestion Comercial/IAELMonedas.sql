USE Doblones20
GO

DROP PROCEDURE InsertarMoneda
GO

CREATE PROCEDURE InsertarMoneda
@NombreMoneda	VARCHAR(50),
@MascaraMoneda	VARCHAR(20)
AS
BEGIN
	
	
	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM Monedas WHERE NombreMoneda = @NombreMoneda))
		INSERT INTO dbo.Monedas (NombreMoneda, MascaraMoneda)								
		VALUES (@NombreMoneda, @MascaraMoneda)
	ELSE
		RAISERROR ('EL NOMBRE DEL SERVICIO YA SE ENCUENTRA REGISTRADO',16, 2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16, 2)
	END
	ELSE
		COMMIT TRANSACTION
END	
GO

DROP PROCEDURE ActualizarMoneda
GO

CREATE PROCEDURE ActualizarMoneda
	@CodigoMoneda	TINYINT,
	@NombreMoneda	VARCHAR(50),
	@MascaraMoneda	VARCHAR(20)
AS
BEGIN
	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM Monedas WHERE NombreMoneda = @NombreMoneda AND CodigoMoneda <> @CodigoMoneda))
		UPDATE 	dbo.Monedas
		SET			
			NombreMoneda	= @NombreMoneda,
			MascaraMoneda	= @MascaraMoneda
		WHERE (CodigoMoneda = @CodigoMoneda)
	ELSE
		RAISERROR ('EL NOMBRE DE LA MONEDA YA SE ENCUENTRA REGISTRADO',16,2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION
END
GO

DROP PROCEDURE EliminarMoneda
GO

CREATE PROCEDURE EliminarMoneda
	@CodigoMoneda	TINYINT
AS
BEGIN
	DELETE 
	FROM dbo.Monedas
	WHERE (CodigoMoneda = @CodigoMoneda)
END
GO

DROP PROCEDURE ListarMonedas
GO

CREATE PROCEDURE ListarMonedas
AS
BEGIN
	SELECT CodigoMoneda, NombreMoneda, MascaraMoneda
	FROM dbo.Monedas
	ORDER BY CodigoMoneda
END
GO

DROP PROCEDURE ObtenerMoneda
GO

CREATE PROCEDURE ObtenerMoneda
	@CodigoMoneda	TINYINT
AS
BEGIN
	SELECT CodigoMoneda, NombreMoneda, MascaraMoneda 
	FROM dbo.Monedas
	WHERE (CodigoMoneda = @CodigoMoneda)
END
GO

