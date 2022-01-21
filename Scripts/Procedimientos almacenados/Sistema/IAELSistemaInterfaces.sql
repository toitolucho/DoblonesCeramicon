USE DOBLONES20
GO



DROP PROCEDURE InsertarSistemaInterfaz
GO
CREATE PROCEDURE InsertarSistemaInterfaz
	@NombreInterface	VARCHAR(250),
	@TextoInterface		VARCHAR(250),
	@CodigoTipoInterface CHAR(1)
AS
BEGIN
	INSERT INTO dbo.SistemaInterfaces (NombreInterface, TextoInterface, CodigoTipoInterface)
	VALUES (@NombreInterface, @TextoInterface, @CodigoTipoInterface)
END
GO



DROP PROCEDURE ActualizarSistemaInterfaz
GO
CREATE PROCEDURE ActualizarSistemaInterfaz
	@CodigoInterface	TINYINT,
	@NombreInterface	VARCHAR(250),
	@TextoInterface		VARCHAR(250),
	@CodigoTipoInterface CHAR(1)
AS
BEGIN
	UPDATE 	dbo.SistemaInterfaces
	SET				
		NombreInterface		= @NombreInterface,
		TextoInterface		= @TextoInterface,
		CodigoTipoInterface = @CodigoTipoInterface
	WHERE (CodigoInterface = @CodigoInterface)
END
GO



DROP PROCEDURE EliminarSistemaInterfaz
GO
CREATE PROCEDURE EliminarSistemaInterfaz
	@CodigoInterface	TINYINT
AS
BEGIN
	DELETE 
	FROM dbo.SistemaInterfaces
	WHERE (CodigoInterface = @CodigoInterface)
END
GO



DROP PROCEDURE ListarSistemasInterfaces
GO
CREATE PROCEDURE ListarSistemasInterfaces
AS
BEGIN
	SELECT CodigoInterface, NombreInterface, TextoInterface, CodigoTipoInterface
	FROM dbo.SistemaInterfaces
	ORDER BY CodigoInterface
END
GO



DROP PROCEDURE ObtenerSistemaInterfaz
GO
CREATE PROCEDURE ObtenerSistemaInterfaz
	@CodigoInterface	TINYINT
AS
BEGIN
	SELECT CodigoInterface, NombreInterface, TextoInterface, CodigoTipoInterface
	FROM dbo.SistemaInterfaces
	WHERE (CodigoInterface = @CodigoInterface)
END
GO



--DROP PROCEDURE ObtenerSistemaInterfazs
--GO
--CREATE PROCEDURE ObtenerSistemaInterfazs
--AS
--BEGIN
--	SELECT CodigoSistemaInterfaz, NombreSistemaInterfaz
--	FROM dbo.SistemaInterfazs
--END
--GO