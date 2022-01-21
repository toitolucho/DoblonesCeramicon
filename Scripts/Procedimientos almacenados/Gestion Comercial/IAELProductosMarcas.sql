USE DOBLONES20
GO

DROP PROCEDURE InsertarProductoMarca
GO

CREATE PROCEDURE InsertarProductoMarca
	@NombreMarcaProducto	VARCHAR(250)
AS
BEGIN
	INSERT INTO ProductosMarcas (NombreMarcaProducto)
	VALUES(@NombreMarcaProducto)
END
GO

DROP PROCEDURE ActualizarProductoMarca
GO

CREATE PROCEDURE ActualizarProductoMarca
	@CodigoMarcaProducto	INT,
	@NombreMarcaProducto	VARCHAR(250)
AS
BEGIN
	UPDATE ProductosMarcas
	SET
		  NombreMarcaProducto = @NombreMarcaProducto
	WHERE CodigoMarcaProducto = @CodigoMarcaProducto	
END
GO

DROP PROCEDURE EliminarProductoMarca
GO

CREATE PROCEDURE EliminarProductoMarca
	@CodigoMarcaProducto	INT
AS
BEGIN
	DELETE FROM ProductosMarcas
	WHERE CodigoMarcaProducto = @CodigoMarcaProducto
END
GO

DROP PROCEDURE ListarProductosMarcas
GO

CREATE PROCEDURE ListarProductosMarcas
AS
BEGIN
	SELECT CodigoMarcaProducto, NombreMarcaProducto 
	FROM ProductosMarcas
	ORDER BY NombreMarcaProducto
END
GO

DROP PROCEDURE ObtenerProductoMarca
GO

CREATE PROCEDURE ObtenerProductoMarca
	@CodigoMarcaProducto	INT
AS
BEGIN
	SELECT CodigoMarcaProducto, NombreMarcaProducto
	FROM ProductosMarcas	
	WHERE CodigoMarcaProducto = @CodigoMarcaProducto
END
GO
