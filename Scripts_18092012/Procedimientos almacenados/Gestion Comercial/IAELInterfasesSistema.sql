USE DOBLONES20
GO

DROP PROCEDURE InsertarInterfaceSistema
GO
CREATE PROCEDURE InsertarInterfaceSistema
@NombreInterface			VARCHAR(250)
AS
BEGIN
	INSERT INTO dbo.InterfacesSistema(NombreInterface)								
	VALUES (@NombreInterface)
END
GO



DROP PROCEDURE ActualizarInterfaceSistema
GO
CREATE PROCEDURE ActualizarInterfaceSistema
@CodigoInterface			INT,
@NombreInterface			VARCHAR(250)
AS
BEGIN
	UPDATE 	dbo.InterfacesSistema
	SET				
		@NombreInterface = @NombreInterface
	WHERE (CodigoInterface = @CodigoInterface)
END
GO



DROP PROCEDURE EliminarInterfaceSistema
GO
CREATE PROCEDURE EliminarInterfaceSistema
@CodigoInterface			INT
AS
BEGIN
	DELETE 
	FROM dbo.InterfacesSistema
	WHERE (CodigoInterface = @CodigoInterface)
END
GO


DROP PROCEDURE ListarInterfacesSistema
GO
CREATE PROCEDURE ListarInterfacesSistema
AS
BEGIN
	SELECT CodigoInterface, NombreInterface
	FROM dbo.InterfacesSistema
	ORDER BY CodigoInterface
END
GO

DROP PROCEDURE ObtenerInterfaceSistema
GO
CREATE PROCEDURE ObtenerInterfaceSistema
@CodigoInterface		INT
AS
BEGIN
	SELECT CodigoInterface, NombreInterface
	FROM dbo.InterfacesSistema
	WHERE (CodigoInterface = @CodigoInterface)
END
GO