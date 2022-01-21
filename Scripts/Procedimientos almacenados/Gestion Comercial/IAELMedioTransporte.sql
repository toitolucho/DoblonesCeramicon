USE DOBLONES20
GO



DROP PROCEDURE InsertarMedioTransporte
GO
CREATE PROCEDURE InsertarMedioTransporte
	@CodigoMedioTransporte	TINYINT,
	@NombreMedioTransporte	VARCHAR(250),
	@Descripcion			TEXT
AS
BEGIN

	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM dbo.MedioTransporte WHERE NombreMedioTransporte = @NombreMedioTransporte))
		INSERT INTO dbo.MedioTransporte (NombreMedioTransporte, Descripcion)								
		VALUES (@NombreMedioTransporte, @Descripcion)
	ELSE
		RAISERROR ('EL NOMBRE DEL MEDIO DE TRANSPORTE YA SE ENCUENTRA REGISTRADO',16, 2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16, 2)
	END
	ELSE
		COMMIT TRANSACTION


END
GO



DROP PROCEDURE ActualizarMedioTransporte
GO
CREATE PROCEDURE ActualizarMedioTransporte
	@CodigoMedioTransporte	TINYINT,
	@NombreMedioTransporte	VARCHAR(250),
	@Descripcion			TEXT
AS
BEGIN
	
	
	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM dbo.MedioTransporte WHERE NombreMedioTransporte = @NombreMedioTransporte AND CodigoMedioTransporte <> @CodigoMedioTransporte))
		UPDATE 	dbo.MedioTransporte
		SET				
			NombreMedioTransporte = @NombreMedioTransporte,
			Descripcion			  = @Descripcion
		WHERE (CodigoMedioTransporte = @CodigoMedioTransporte)
		ELSE
		RAISERROR ('EL NOMBRE DEL MedioTransporte YA SE ENCUENTRA REGISTRADO',16,2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION

END
GO



DROP PROCEDURE EliminarMedioTransporte
GO
CREATE PROCEDURE EliminarMedioTransporte
	@CodigoMedioTransporte	INT
AS
BEGIN
	DELETE 
	FROM dbo.MedioTransporte
	WHERE (CodigoMedioTransporte = @CodigoMedioTransporte)
END
GO



DROP PROCEDURE ListarMedioTransportes
GO
CREATE PROCEDURE ListarMedioTransportes
AS
BEGIN
	SELECT CodigoMedioTransporte, NombreMedioTransporte, Descripcion
	FROM dbo.MedioTransporte
	ORDER BY CodigoMedioTransporte
END
GO



DROP PROCEDURE ObtenerMedioTransporte
GO
CREATE PROCEDURE ObtenerMedioTransporte
	@CodigoMedioTransporte	INT
AS
BEGIN
	SELECT CodigoMedioTransporte, NombreMedioTransporte, Descripcion
	FROM dbo.MedioTransporte
	WHERE (CodigoMedioTransporte = @CodigoMedioTransporte)
END
GO



--DROP PROCEDURE ObtenerMedioTransportes
--GO
--CREATE PROCEDURE ObtenerMedioTransportes
--AS
--BEGIN
--	SELECT CodigoMedioTransporte, NombreMedioTransporte
--	FROM dbo.MedioTransporte
--END
--GO

