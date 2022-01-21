USE DOBLONES20
GO



DROP PROCEDURE InsertarProductoTipoGarantia
GO
CREATE PROCEDURE InsertarProductoTipoGarantia
	@NombreTipoGarantia	VARCHAR(250),
	@Descripcion			VARCHAR(250)
AS
BEGIN
	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM ProductosTiposGarantias WHERE NombreTipoGarantia = @NombreTipoGarantia))
		INSERT INTO dbo.ProductosTiposGarantias (NombreTipoGarantia, Descripcion)
		VALUES (@NombreTipoGarantia, @Descripcion)
	ELSE
		RAISERROR ('EL NOMBRE DEL TIPO DE GARANTIA YA SE ENCUENTRA REGISTRADO',16, 2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16, 2)
	END
	ELSE
		COMMIT TRANSACTION
	
END
GO

EXEC InsertarProductoTipoGarantia 'GARANTAI 1',' GARANTIA 2 '


DROP PROCEDURE ActualizarProductoTipoGarantia
GO
CREATE PROCEDURE ActualizarProductoTipoGarantia
	@CodigoTipoGarantia	TINYINT,
	@NombreTipoGarantia	VARCHAR(250),
	@Descripcion		VARCHAR(250)
AS
BEGIN
	
	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM ProductosTiposGarantias WHERE NombreTipoGarantia = @NombreTipoGarantia AND CodigoTipoGarantia <> @CodigoTipoGarantia))
		UPDATE 	dbo.ProductosTiposGarantias
		SET				
			NombreTipoGarantia = @NombreTipoGarantia,
			Descripcion			= @Descripcion
		WHERE (CodigoTipoGarantia = @CodigoTipoGarantia)
	ELSE
		RAISERROR ('YA EXISTE UN REGISTRO CON EL NOMBRE QUE USTED DESEA GUARDAR',16,2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO ACTUALIZAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION
END
GO



DROP PROCEDURE EliminarProductoTipoGarantia
GO
CREATE PROCEDURE EliminarProductoTipoGarantia
	@CodigoTipoGarantia	INT
AS
BEGIN
	DELETE 
	FROM dbo.ProductosTiposGarantias
	WHERE (CodigoTipoGarantia = @CodigoTipoGarantia)
END
GO



DROP PROCEDURE ListarProductosTiposGarantias
GO
CREATE PROCEDURE ListarProductosTiposGarantias
AS
BEGIN
	SELECT CodigoTipoGarantia, NombreTipoGarantia, Descripcion
	FROM dbo.ProductosTiposGarantias
	ORDER BY CodigoTipoGarantia
END
GO



DROP PROCEDURE ObtenerProductoTipoGarantia
GO
CREATE PROCEDURE ObtenerProductoTipoGarantia
	@CodigoTipoGarantia	INT
AS
BEGIN
	SELECT CodigoTipoGarantia, NombreTipoGarantia, Descripcion
	FROM dbo.ProductosTiposGarantias
	WHERE (CodigoTipoGarantia = @CodigoTipoGarantia)
END
GO
