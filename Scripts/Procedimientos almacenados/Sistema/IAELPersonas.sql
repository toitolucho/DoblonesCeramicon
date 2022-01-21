use DOBLONES20
GO

DROP PROCEDURE InsertarPersona
GO

CREATE PROCEDURE InsertarPersona
@DIPersona					CHAR(15),
@Paterno					VARCHAR(40),
@Materno					VARCHAR(40),
@Nombres					VARCHAR(80),
@FechaNacimiento			DATETIME,
@Sexo						CHAR(1),
@Celular					VARCHAR(50),
@Email						TEXT,
@CodigoPaisD				CHAR(2),
@CodigoDepartamentoD		CHAR(2),
@CodigoProvinciaD			CHAR(2),
@CodigoLugarD				CHAR(3),
@DireccionD					VARCHAR(250),
@TelefonoD					VARCHAR(50),
@RutaArchivoHuellaDactilar	TEXT,
@RutaArchivoFotografia		TEXT,
@RutaArchivoFirma			TEXT,
@Observaciones				TEXT
AS
BEGIN
	INSERT INTO dbo.Personas (DIPersona, Paterno, Materno, Nombres, FechaNacimiento, Sexo, Celular, Email, CodigoPaisD, CodigoDepartamentoD, CodigoProvinciaD, CodigoLugarD, DireccionD, TelefonoD, RutaArchivoHuellaDactilar, RutaArchivoFotografia, RutaArchivoFirma, Observaciones)								
	VALUES (@DIPersona, @Paterno, @Materno, @Nombres, @FechaNacimiento, @Sexo, @Celular, @Email, @CodigoPaisD, @CodigoDepartamentoD, @CodigoProvinciaD, @CodigoLugarD, @DireccionD, @TelefonoD, @RutaArchivoHuellaDactilar, @RutaArchivoFotografia, @RutaArchivoFirma, @Observaciones)
END	
GO

DROP PROCEDURE ActualizarPersona
GO

CREATE PROCEDURE ActualizarPersona
@DIPersona					CHAR(15),
@Paterno					VARCHAR(40),
@Materno					VARCHAR(40),
@Nombres					VARCHAR(80),
@FechaNacimiento			DATETIME,
@Sexo						CHAR(1),
@Celular					VARCHAR(50),
@Email						TEXT,
@CodigoPaisD				CHAR(2),
@CodigoDepartamentoD		CHAR(2),
@CodigoProvinciaD			CHAR(2),
@CodigoLugarD				CHAR(3),
@DireccionD					VARCHAR(250),
@TelefonoD					VARCHAR(50),
@RutaArchivoHuellaDactilar	TEXT,
@RutaArchivoFotografia		TEXT,
@RutaArchivoFirma			TEXT,
@Observaciones				TEXT
AS
BEGIN
	UPDATE 	dbo.Personas
	SET		
		Paterno						= @Paterno,
		Materno						= @Materno,
		Nombres						= @Nombres,
		FechaNacimiento				= @FechaNacimiento,
		Sexo						= @Sexo,
		Celular						= @Celular,
		Email						= @Email,
		CodigoPaisD					= @CodigoPaisD,
		CodigoDepartamentoD			= @CodigoDepartamentoD,
		CodigoProvinciaD			= @CodigoProvinciaD,
		CodigoLugarD				= @CodigoLugarD,
		DireccionD					= @DireccionD,
		TelefonoD					= @TelefonoD,
		RutaArchivoHuellaDactilar	= @RutaArchivoHuellaDactilar,
		RutaArchivoFotografia		= @RutaArchivoFotografia,
		RutaArchivoFirma			= @RutaArchivoFirma,
		Observaciones				= @Observaciones
	WHERE (DIPersona = @DIPersona)
END
GO

DROP PROCEDURE EliminarPersona
GO

CREATE PROCEDURE EliminarPersona
@DIPersona	CHAR(15)
AS
BEGIN
	DELETE 
	FROM dbo.Personas
	WHERE (DIPersona = @DIPersona)
END
GO

DROP PROCEDURE ListarPersonas
GO

CREATE PROCEDURE ListarPersonas
AS
BEGIN
	SELECT DIPersona, Paterno, Materno, Nombres, FechaNacimiento, Sexo, Celular, Email, CodigoPaisD, CodigoDepartamentoD, CodigoProvinciaD, CodigoLugarD, DireccionD, TelefonoD, RutaArchivoHuellaDactilar, RutaArchivoFotografia, RutaArchivoFirma, Observaciones 
	FROM dbo.Personas
	ORDER BY DIPersona
END
GO

DROP PROCEDURE ObtenerPersona
GO

CREATE PROCEDURE ObtenerPersona
	@DIPersona	CHAR(15)
AS
BEGIN
	SELECT DIPersona, Paterno, Materno, Nombres, FechaNacimiento, Sexo, Celular, Email, CodigoPaisD, CodigoDepartamentoD, CodigoProvinciaD, CodigoLugarD, DireccionD, TelefonoD, RutaArchivoHuellaDactilar, RutaArchivoFotografia, RutaArchivoFirma, Observaciones 
	FROM dbo.Personas
	WHERE (DIPersona = @DIPersona)
END
GO
