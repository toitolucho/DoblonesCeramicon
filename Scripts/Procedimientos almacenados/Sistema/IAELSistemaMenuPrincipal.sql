USE DOBLONES20
GO

DROP PROCEDURE InsertarSistemaMenuPrincipal
GO
CREATE PROCEDURE InsertarSistemaMenuPrincipal
	@CodigoElementoMenu			INT,
	@CodigoElementoMenuPadre	INT,
	@NombreElementoMenu			VARCHAR(250),
	@TextoElementoMenu			VARCHAR(250),
	@CodigoTipoElementoMenu		CHAR(1),
	@URLImagenElementoMenu		TEXT,
	@NombreBotonBarra			VARCHAR(250),
	@TextoBotonBarra			VARCHAR(250),
	@URLImagenBotonBarra		TEXT,
	@FuncionEnlace				TEXT
AS
BEGIN
	INSERT INTO dbo.SistemaMenuPrincipal (CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace)
	VALUES (@CodigoElementoMenu, @CodigoElementoMenuPadre, @NombreElementoMenu, @TextoElementoMenu, @CodigoTipoElementoMenu, @URLImagenElementoMenu, @NombreBotonBarra, @TextoBotonBarra, @URLImagenBotonBarra, @FuncionEnlace)
END
GO

DROP PROCEDURE ActualizarSistemaMenuPrincipal
GO

CREATE PROCEDURE ActualizarSistemaMenuPrincipal
	@CodigoElementoMenu			INT,
	@CodigoElementoMenuPadre	INT,
	@NombreElementoMenu			VARCHAR(250),
	@TextoElementoMenu			VARCHAR(250),
	@CodigoTipoElementoMenu		CHAR(1),
	@URLImagenElementoMenu		TEXT,
	@NombreBotonBarra			VARCHAR(250),
	@TextoBotonBarra			VARCHAR(250),
	@URLImagenBotonBarra		TEXT,
	@FuncionEnlace				TEXT
AS
BEGIN
	UPDATE 	dbo.SistemaMenuPrincipal
	SET			
		CodigoElementoMenuPadre	= @CodigoElementoMenuPadre,
		NombreElementoMenu		= @NombreElementoMenu,
		TextoElementoMenu		= @TextoElementoMenu,
		CodigoTipoElementoMenu	= @CodigoTipoElementoMenu,
		URLImagenElementoMenu	= @URLImagenElementoMenu,
		NombreBotonBarra		= @NombreBotonBarra,
		TextoBotonBarra			= @TextoBotonBarra,
		URLImagenBotonBarra		= @URLImagenBotonBarra,
		FuncionEnlace			= @FuncionEnlace
	WHERE (CodigoElementoMenu = @CodigoElementoMenu)
END
GO

DROP PROCEDURE EliminarSistemaMenuPrincipal
GO
CREATE PROCEDURE EliminarSistemaMenuPrincipal
	@CodigoElementoMenu			INT
AS
BEGIN
	DELETE 
	FROM dbo.SistemaMenuPrincipal
	WHERE (CodigoElementoMenu = @CodigoElementoMenu)
END
GO

DROP PROCEDURE ListarSistemaMenuPrincipal
GO
CREATE PROCEDURE ListarSistemaMenuPrincipal
AS
BEGIN
	SELECT CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace
	FROM dbo.SistemaMenuPrincipal
	ORDER BY CodigoElementoMenu, CodigoElementoMenuPadre
END
GO

DROP PROCEDURE ObtenerSistemaMenuPrincipal
GO
CREATE PROCEDURE ObtenerSistemaMenuPrincipal
	@CodigoElementoMenu			INT
AS
BEGIN
	SELECT CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace
	FROM dbo.SistemaMenuPrincipal	
	WHERE (CodigoElementoMenu = @CodigoElementoMenu)
	ORDER BY CodigoElementoMenu, CodigoElementoMenuPadre
END
GO