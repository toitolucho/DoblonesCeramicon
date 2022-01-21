use DOBLONES20
GO

DROP PROCEDURE InsertarProductoDescripcion
GO

CREATE PROCEDURE InsertarProductoDescripcion
	@CodigoProducto		CHAR(15),
	@CodigoPropiedad	INT,
	@ValorPropiedad		VARCHAR(200)
AS
BEGIN
	INSERT INTO dbo.ProductosDescripcion (CodigoProducto,CodigoPropiedad,ValorPropiedad)
	VALUES (@CodigoProducto,@CodigoPropiedad,@ValorPropiedad)
END
GO

DROP PROCEDURE ActualizarProductoDescripcion
GO

CREATE PROCEDURE ActualizarProductoDescripcion
	@CodigoProducto		CHAR(15),
	@CodigoPropiedad	INT,
	@ValorPropiedad		VARCHAR(200)
AS
BEGIN
	UPDATE 	dbo.ProductosDescripcion
	SET		
		CodigoProducto	= @CodigoProducto,
		CodigoPropiedad = @CodigoPropiedad,
		ValorPropiedad	= @ValorPropiedad
	WHERE (@CodigoProducto = CodigoProducto) AND (@CodigoPropiedad = CodigoPropiedad)
END
GO

DROP PROCEDURE EliminarProductoDescripcion
GO

CREATE PROCEDURE EliminarProductoDescripcion
	@CodigoProducto		CHAR(15),
	@CodigoPropiedad	INT
AS
BEGIN
	DELETE 
	FROM dbo.ProductosDescripcion
	WHERE (@CodigoProducto = CodigoProducto) AND (@CodigoPropiedad = CodigoPropiedad)
END
GO

DROP PROCEDURE ListarProductosDescripcion
GO

CREATE PROCEDURE ListarProductosDescripcion
AS
BEGIN
	SELECT CodigoProducto,CodigoPropiedad,ValorPropiedad 
	FROM dbo.ProductosDescripcion
	ORDER BY CodigoProducto,CodigoPropiedad
END
GO

DROP PROCEDURE ObtenerProductoDescripcion
GO

CREATE PROCEDURE ObtenerProductoDescripcion
@CodigoProducto		CHAR(15),
@CodigoPropiedad	INT
AS
BEGIN
	SELECT CodigoProducto,CodigoPropiedad,ValorPropiedad 
	FROM dbo.ProductosDescripcion
	WHERE (@CodigoProducto = CodigoProducto) AND (@CodigoPropiedad = CodigoPropiedad)
END
GO

DROP PROCEDURE ListarProductosDescripcionPorCodigoProducto
GO

CREATE PROCEDURE ListarProductosDescripcionPorCodigoProducto
@CodigoProducto		CHAR(15)
AS
BEGIN
	SELECT CodigoProducto, CodigoPropiedad, ValorPropiedad 
	FROM dbo.ProductosDescripcion
	WHERE CodigoProducto = @CodigoProducto
	ORDER BY CodigoProducto,CodigoPropiedad
END
GO

