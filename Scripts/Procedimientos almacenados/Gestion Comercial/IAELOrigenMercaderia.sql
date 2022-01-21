USE DOBLONES20
GO



DROP PROCEDURE InsertarOrigenMercaderia
GO
CREATE PROCEDURE InsertarOrigenMercaderia
	@CodigoOrigenMercaderia	TINYINT,
	@NombreOrigenMercaderia	VARCHAR(250),
	@Descripcion			TEXT
AS
BEGIN

	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM dbo.OrigenMercaderia WHERE NombreOrigenMercaderia = @NombreOrigenMercaderia))
		INSERT INTO dbo.OrigenMercaderia (NombreOrigenMercaderia, Descripcion)								
		VALUES (@NombreOrigenMercaderia, @Descripcion)
	ELSE
		RAISERROR ('EL NOMBRE DE ORIGEN DE IMPORTACION DE MERCADERIA YA SE ENCUENTRA REGISTRADO',16, 2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16, 2)
	END
	ELSE
		COMMIT TRANSACTION


END
GO



DROP PROCEDURE ActualizarOrigenMercaderia
GO
CREATE PROCEDURE ActualizarOrigenMercaderia
	@CodigoOrigenMercaderia	TINYINT,
	@NombreOrigenMercaderia	VARCHAR(250),
	@Descripcion			TEXT
AS
BEGIN
	
	
	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM dbo.OrigenMercaderia WHERE NombreOrigenMercaderia = @NombreOrigenMercaderia AND CodigoOrigenMercaderia <> @CodigoOrigenMercaderia))
		UPDATE 	dbo.OrigenMercaderia
		SET				
			NombreOrigenMercaderia = @NombreOrigenMercaderia,
			Descripcion			   = @Descripcion
		WHERE (CodigoOrigenMercaderia = @CodigoOrigenMercaderia)
		ELSE
		RAISERROR ('EL NOMBRE DE ORIGEN DE IMPORTACION DE MERCADERIA YA SE ENCUENTRA REGISTRADO',16, 2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION

END
GO



DROP PROCEDURE EliminarOrigenMercaderia
GO
CREATE PROCEDURE EliminarOrigenMercaderia
	@CodigoOrigenMercaderia	INT
AS
BEGIN
	DELETE 
	FROM dbo.OrigenMercaderia
	WHERE (CodigoOrigenMercaderia = @CodigoOrigenMercaderia)
END
GO



DROP PROCEDURE ListarOrigenMercaderias
GO
CREATE PROCEDURE ListarOrigenMercaderias
AS
BEGIN
	SELECT CodigoOrigenMercaderia, NombreOrigenMercaderia, Descripcion
	FROM dbo.OrigenMercaderia
	ORDER BY CodigoOrigenMercaderia
END
GO



DROP PROCEDURE ObtenerOrigenMercaderia
GO
CREATE PROCEDURE ObtenerOrigenMercaderia
	@CodigoOrigenMercaderia	INT
AS
BEGIN
	SELECT CodigoOrigenMercaderia, NombreOrigenMercaderia, Descripcion
	FROM dbo.OrigenMercaderia
	WHERE (CodigoOrigenMercaderia = @CodigoOrigenMercaderia)
END
GO



--DROP PROCEDURE ObtenerOrigenMercaderias
--GO
--CREATE PROCEDURE ObtenerOrigenMercaderias
--AS
--BEGIN
--	SELECT CodigoOrigenMercaderia, NombreOrigenMercaderia
--	FROM dbo.OrigenMercaderia
--END
--GO

