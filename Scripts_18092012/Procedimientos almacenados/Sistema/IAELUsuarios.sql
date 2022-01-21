use DOBLONES20
GO

DROP PROCEDURE InsertarUsuario
GO

CREATE PROCEDURE InsertarUsuario
@NombreUsuario				CHAR(32),
@Contrasena					CHAR(32),
@DIUsuario					CHAR(15),
@Paterno					VARCHAR(40),
@Materno					VARCHAR(40),
@Nombres					VARCHAR(80),
@FechaNacimiento			DATETIME,
@Sexo						CHAR(1),
@Celular					VARCHAR(50),
@Email						TEXT,
@Direccion					VARCHAR(250),
@Telefono					VARCHAR(50),
@RutaArchivoHuellaDactilar	TEXT,
@RutaArchivoFotografia		TEXT,
@RutaArchivoFirma			TEXT,
@Observaciones				TEXT
AS
BEGIN

	BEGIN TRANSACTION	
	IF(EXISTS((SELECT * FROM Usuarios WHERE 
			UPPER(RTRIM(LTRIM(Nombres))) = UPPER(RTRIM(LTRIM(@Nombres))) 
			AND UPPER(RTRIM(LTRIM(Paterno))) = UPPER(RTRIM(LTRIM(@Paterno)))
			AND UPPER(RTRIM(LTRIM(Materno))) = UPPER(RTRIM(LTRIM(@Materno)))
			)))
	BEGIN
		RAISERROR ('LOS DATOS GENERALES(NOMBRE, APPELIDOS) DEL USUARIO YA SE ENCUENTRAN REGISTRADOS',16,2)
	END
	ELSE
	BEGIN
		IF(EXISTS(SELECT * FROM Usuarios 
			WHERE UPPER(RTRIM(LTRIM(NombreUsuario))) = UPPER(RTRIM(LTRIM(@NombreUsuario)))))
		BEGIN
			RAISERROR ('LA CUENTA DE USUARIO YA SE ENCUENTRA REGISTRADA',16,2)
		END
		ELSE
		BEGIN
			DECLARE @NombreUsuarioLogin	VARCHAR(32),
					@ContraseniaLogin	VARCHAR(32)
			
			SET @NombreUsuarioLogin = LTRIM(RTRIM(@NombreUsuario))
			SET @ContraseniaLogin = LTRIM(RTRIM(@Contrasena))
			
			EXEC ('USE master; CREATE LOGIN ' + @NombreUsuarioLogin + ' WITH PASSWORD =N''' + @ContraseniaLogin + ''', DEFAULT_LANGUAGE=Español, CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF; USE DOBLONES20')
			EXEC ('USE DOBLONES20; CREATE USER ' + @NombreUsuarioLogin + ' FOR LOGIN ' + @NombreUsuarioLogin)
			EXEC ('USE DOBLONES20; EXEC sp_addrolemember N''db_owner'', N''' + @NombreUsuarioLogin + '''')
			
			INSERT INTO dbo.Usuarios (NombreUsuario, Contrasena, DIUsuario, Paterno, Materno, Nombres, FechaNacimiento, Sexo, Celular, Email, Direccion, Telefono, RutaArchivoHuellaDactilar, RutaArchivoFotografia, RutaArchivoFirma, Observaciones)								
			VALUES (@NombreUsuario, @Contrasena, @DIUsuario, @Paterno, @Materno, @Nombres, @FechaNacimiento, @Sexo, @Celular, @Email, @Direccion, @Telefono, @RutaArchivoHuellaDactilar, @RutaArchivoFotografia, @RutaArchivoFirma, @Observaciones)
			
			
		END
	END
			
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUEDE INGRESAR LOS DATOS DEL USUARIO, LOS MISMOS SE ENCUENTRAN YA REGISTRADOS',16,2)
	END
	ELSE
		COMMIT TRANSACTION


	
END	
GO

DROP PROCEDURE ActualizarUsuario
GO

CREATE PROCEDURE ActualizarUsuario
@CodigoUsuario				INT,
@NombreUsuario				CHAR(32),
@Contrasena					CHAR(32),
@DIUsuario					CHAR(15),
@Paterno					VARCHAR(40),
@Materno					VARCHAR(40),
@Nombres					VARCHAR(80),
@FechaNacimiento			DATETIME,
@Sexo						CHAR(1),
@Celular					VARCHAR(50),
@Email						TEXT,
@Direccion					VARCHAR(250),
@Telefono					VARCHAR(50),
@RutaArchivoHuellaDactilar	TEXT,
@RutaArchivoFotografia		TEXT,
@RutaArchivoFirma			TEXT,
@Observaciones				TEXT
AS
BEGIN
	UPDATE 	dbo.Usuarios
	SET		
		NombreUsuario				= @NombreUsuario,
		Contrasena					= @Contrasena,
		DIUsuario					= @DIUsuario,
		Paterno						= @Paterno,
		Materno						= @Materno,
		Nombres						= @Nombres,
		FechaNacimiento				= @FechaNacimiento,
		Sexo						= @Sexo,
		Celular						= @Celular,
		Email						= @Email,
		Direccion					= @Direccion,
		Telefono					= @Telefono,
		RutaArchivoHuellaDactilar	= @RutaArchivoHuellaDactilar,
		RutaArchivoFotografia		= @RutaArchivoFotografia,
		RutaArchivoFirma			= @RutaArchivoFirma,
		Observaciones				= @Observaciones
	WHERE (CodigoUsuario = @CodigoUsuario)
END
GO

DROP PROCEDURE EliminarUsuario
GO

CREATE PROCEDURE EliminarUsuario
@CodigoUsuario				INT
AS
BEGIN

	DECLARE @NombreUsuario	CHAR(32)
	SELECT @NombreUsuario = NombreUsuario FROM Usuarios WHERE CodigoUsuario = @CodigoUsuario
	BEGIN TRANSACTION
	
	
	EXEC ('USE DOBLONES20; EXEC sp_droprolemember N''db_owner'', N''' + @NombreUsuario + '''')
	EXEC ('USE DOBLONES20; DROP USER ' + @NombreUsuario)
	EXEC ('USE master; DROP LOGIN ' + @NombreUsuario)	
	
	DELETE FROM Usuarios
	WHERE CodigoUsuario = @CodigoUsuario
	
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO ELIMINAR EL REGISTRO, PROBABLEMENTE EL USUARIO YA REALIZÓN TRANSACCIONES EN EL SISTEMA, PROCEDA A DARLO DE BAJA',16,2)
	END
	ELSE
		COMMIT TRANSACTION
	
END
GO

DROP PROCEDURE ListarUsuarios
GO

CREATE PROCEDURE ListarUsuarios
AS
BEGIN
	SELECT CodigoUsuario, NombreUsuario, Contrasena, DIUsuario, Paterno, Materno, Nombres, FechaNacimiento, Sexo, Celular, Email, Direccion, Telefono, RutaArchivoHuellaDactilar, RutaArchivoFotografia, RutaArchivoFirma, Observaciones
	FROM dbo.Usuarios
	ORDER BY CodigoUsuario
END
GO

DROP PROCEDURE ObtenerUsuario
GO

CREATE PROCEDURE ObtenerUsuario
	@CodigoUsuario	INT
AS
BEGIN
	SELECT CodigoUsuario, NombreUsuario, Contrasena, DIUsuario, Paterno, Materno, Nombres, FechaNacimiento, Sexo, Celular, Email, Direccion, Telefono, RutaArchivoHuellaDactilar, RutaArchivoFotografia, RutaArchivoFirma, Observaciones
	FROM dbo.Usuarios
	WHERE (CodigoUsuario = @CodigoUsuario)
END
GO

DROP PROCEDURE AsignarContrasena
GO

CREATE PROCEDURE AsignarContrasena
@CodigoUsuario		INT,
@Contrasena			VARCHAR(32)
AS

	BEGIN TRANSACTION
	
	DECLARE @NombreUsuario		CHAR(32),
			@ContrasenaAntigua	VARCHAR(32)
	SELECT @NombreUsuario = NombreUsuario, @ContrasenaAntigua = Contrasena FROM Usuarios WHERE CodigoUsuario = @CodigoUsuario
	set @NombreUsuario = LTRIM(RTRIM(@NombreUsuario))
	set @Contrasena = LTRIM(rtrim(@Contrasena))
	IF(@NombreUsuario IS NOT NULL)
	BEGIN
		DECLARE @EventInfo VARCHAR(400) = 'Contrasenia Anterior : ' +
		 @ContrasenaAntigua + ',   Nueva Contrasenia: ' + @Contrasena
		INSERT INTO Bitacora (EventType, Status, EventInfo)
		VALUES('Actualizando Contrasenia', 0, @EventInfo )
	
		UPDATE Usuarios
		SET
			Contrasena = @Contrasena
		WHERE CodigoUsuario = @CodigoUsuario
		
		--EXEC ('USE master; ALTER LOGIN ' + @NombreUsuario + ' WITH PASSWORD = '''+ @Contrasena+ '''' + ' OLD_PASSWORD = '''+ @ContrasenaAntigua+ '''')	
		EXEC ('USE master; ALTER LOGIN ' + @NombreUsuario + ' WITH PASSWORD = '''+ @Contrasena+ '''')	
		
		INSERT INTO Bitacora (EventType, Status, EventInfo)
		VALUES('Actualizando Contrasenia', 1, @EventInfo )
				
	END
	ELSE
		RAISERROR ('NO EXISTE EL USUARIO DENTRO DE LOS ROLES DEL GESTOR DE BASE DE DATOS',17,2)
	
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO ACTUALIZAR LA CONTRASEÑA DEL USUARIO ACTUAL',16,2)
	END
	ELSE
		COMMIT TRANSACTION

GO

--exec AsignarContrasena 1, 'holamundo'

DROP PROCEDURE VerificarContrasena
GO

CREATE PROCEDURE VerificarContrasena
@CodigoUsuario		INT,
@Contrasena			CHAR(32),
@Existe				BIT OUTPUT
AS

SELECT CodigoUsuario, NombreUsuario, Contrasena, DIUsuario, Paterno, Materno, Nombres, FechaNacimiento, Sexo, Celular, Email, Direccion, Telefono, RutaArchivoHuellaDactilar, RutaArchivoFotografia, RutaArchivoFirma, Observaciones
FROM Usuarios
WHERE CodigoUsuario = @CodigoUsuario AND Contrasena = @Contrasena

IF @@ROWCOUNT > 0
SET @Existe = 1
ELSE
SET @Existe = 0

GO