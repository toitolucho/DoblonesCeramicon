USE DOBLONES20
GO



DROP PROCEDURE InsertarServicio
GO
CREATE PROCEDURE InsertarServicio	
	@NombreServicio		VARCHAR(250),
	@CodigoTipoServicio	CHAR(1),
	@PrecioUnitario		DECIMAL(10,2),
	@Descripcion		TEXT
AS
BEGIN

	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM Servicios WHERE NombreServicio = @NombreServicio))
		INSERT INTO dbo.Servicios (NombreServicio, CodigoTipoServicio, PrecioUnitario, Descripcion)
		VALUES (@NombreServicio, @CodigoTipoServicio, @PrecioUnitario, @Descripcion)
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



DROP PROCEDURE ActualizarServicio
GO
CREATE PROCEDURE ActualizarServicio
	@CodigoServicio	TINYINT,
	@NombreServicio		VARCHAR(250),
	@CodigoTipoServicio	CHAR(1),
	@PrecioUnitario		DECIMAL(10,2),
	@Descripcion		TEXT
AS
BEGIN	
	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM Servicios WHERE NombreServicio = @NombreServicio AND CodigoServicio <> @CodigoServicio))
		UPDATE 	dbo.Servicios
		SET				
			NombreServicio		= @NombreServicio,
			@CodigoTipoServicio	= @CodigoTipoServicio,
			PrecioUnitario		= @PrecioUnitario,
			Descripcion			= @Descripcion
		WHERE (CodigoServicio = @CodigoServicio)
	ELSE
		RAISERROR ('EL NOMBRE DEL SERVICIO YA SE ENCUENTRA REGISTRADO',16,2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION
END
GO

--exec ActualizarServicio 1, 'MANTENIMIENTO','L',123, 'PRUEBA DE DATOS'

DROP PROCEDURE EliminarServicio
GO
CREATE PROCEDURE EliminarServicio
	@CodigoServicio	INT
AS
BEGIN
	BEGIN TRANSACTION
		DELETE 
		FROM dbo.Servicios
		WHERE (CodigoServicio = @CodigoServicio)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO ELIMINAR CORRECTAMENTE EL REGISTRO, PROBABLEMENTE EL SERVICIO YA SE ENCUENTRA EN USO EN ALGUNA TRANSACCIÓN',2,16)
	END
	ELSE
		COMMIT TRANSACTION
END
GO



DROP PROCEDURE ListarServicios
GO
CREATE PROCEDURE ListarServicios
AS
BEGIN
	SELECT CodigoServicio, NombreServicio, CodigoTipoServicio, PrecioUnitario, Descripcion
	FROM dbo.Servicios
	ORDER BY NombreServicio
END
GO



DROP PROCEDURE ObtenerServicio
GO
CREATE PROCEDURE ObtenerServicio
	@CodigoServicio	INT
AS
BEGIN
	SELECT CodigoServicio, NombreServicio, CodigoTipoServicio, PrecioUnitario, Descripcion
	FROM dbo.Servicios
	WHERE (CodigoServicio = @CodigoServicio)
END
GO


DROP PROCEDURE ListarServiciosReporte
GO
CREATE PROCEDURE ListarServiciosReporte
AS
BEGIN
	SELECT CodigoServicio, NombreServicio, 
	CASE CodigoTipoServicio WHEN 'L' THEN 'DENTRO DE LA EMPRESA'
	WHEN 'D' THEN 'SERVICIO DOMICILIARIO' END AS CodigoTipoServicio, 
	PrecioUnitario, Descripcion
	FROM dbo.Servicios
END
GO