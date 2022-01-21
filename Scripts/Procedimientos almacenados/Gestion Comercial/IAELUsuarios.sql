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
	INSERT INTO dbo.Usuarios (NombreUsuario, Contrasena, DIUsuario, Paterno, Materno, Nombres, FechaNacimiento, Sexo, Celular, Email, Direccion, Telefono, RutaArchivoHuellaDactilar, RutaArchivoFotografia, RutaArchivoFirma, Observaciones)								
	VALUES (@NombreUsuario, @Contrasena, @DIUsuario, @Paterno, @Materno, @Nombres, @FechaNacimiento, @Sexo, @Celular, @Email, @Direccion, @Telefono, @RutaArchivoHuellaDactilar, @RutaArchivoFotografia, @RutaArchivoFirma, @Observaciones)
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
	DELETE 
	FROM dbo.Usuarios
	WHERE (CodigoUsuario = @CodigoUsuario)
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
