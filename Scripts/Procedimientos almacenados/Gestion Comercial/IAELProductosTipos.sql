use DOBLONES20
GO

DROP PROCEDURE InsertarProductoTipo
GO

CREATE PROCEDURE InsertarProductoTipo
	
	@CodigoTipoProductoPadre	INT,
	@NombreTipoProducto			VARCHAR(250),
	@NombreCortoTipoProducto	VARCHAR(20),
	@DescripcionTipoProducto	TEXT,
	@Nivel						INT
AS
BEGIN
	INSERT INTO ProductosTipos(CodigoTipoProductoPadre, NombreTipoProducto, NombreCortoTipoProducto, DescripcionTipoProducto, Nivel)
	VALUES (@CodigoTipoProductoPadre, @NombreTipoProducto, @NombreCortoTipoProducto, @DescripcionTipoProducto, @Nivel)
END
GO

DROP PROCEDURE ActualizarProductoTipo
GO

CREATE PROCEDURE ActualizarProductoTipo
	@CodigoTipoProducto INT,
	@CodigoTipoProductoPadre INT,
	@NombreTipoProducto VARCHAR(250),
	@NombreCortoTipoProducto VARCHAR(20),
	@DescripcionTipoProducto TEXT,
	@Nivel INT
AS
BEGIN
	UPDATE 	ProductosTipos
	SET
		CodigoTipoProductoPadre = @CodigoTipoProductoPadre,
		NombreTipoProducto = @NombreTipoProducto,
		NombreCortoTipoProducto	= @NombreCortoTipoProducto,
		DescripcionTipoProducto = @DescripcionTipoProducto,
		Nivel = @Nivel
	WHERE @CodigoTipoProducto = CodigoTipoProducto
END
GO

DROP PROCEDURE EliminarProductoTipo
GO

CREATE PROCEDURE EliminarProductoTipo
	@CodigoTipoProducto INT
AS
BEGIN
	DELETE 
	FROM dbo.ProductosTipos
	WHERE @CodigoTipoProducto = CodigoTipoProducto
END
GO


DROP PROCEDURE ListarProductosTipos
GO

CREATE PROCEDURE ListarProductosTipos
AS
BEGIN
	SELECT CodigoTipoProducto,CodigoTipoProductoPadre, NombreTipoProducto, NombreCortoTipoProducto, DescripcionTipoProducto, Nivel
	FROM dbo.ProductosTipos
	ORDER BY CodigoTipoProducto
END
GO

DROP PROCEDURE ObtenerProductoTipo
GO

CREATE PROCEDURE ObtenerProductoTipo
	@CodigoTipoProducto INT
AS
BEGIN
	SELECT CodigoTipoProducto,CodigoTipoProductoPadre, NombreTipoProducto, NombreCortoTipoProducto, DescripcionTipoProducto, Nivel
	FROM dbo.ProductosTipos
	WHERE CodigoTipoProducto= @CodigoTipoProducto
END
GO


DROP PROCEDURE ListarProductosTiposPadres
GO

CREATE PROCEDURE ListarProductosTiposPadres
AS
SELECT PT.CodigoTipoProducto, PT.CodigoTipoProductoPadre, PT.NombreTipoProducto, PT.NombreCortoTipoProducto, PT.DescripcionTipoProducto, PT.Nivel
FROM dbo.ProductosTipos PT
WHERE PT.CodigoTipoProductoPadre IS NULL
GO


DROP PROCEDURE ListarProductosTiposProductoTipoPadre
GO

CREATE PROCEDURE ListarProductosTiposProductoTipoPadre
@CodigoTipoProductoPadre		INT
AS
SELECT PT.CodigoTipoProducto, PT.CodigoTipoProductoPadre, PT.NombreTipoProducto, PT.NombreCortoTipoProducto, PT.DescripcionTipoProducto, PT.Nivel
FROM dbo.ProductosTipos PT
WHERE PT.CodigoTipoProductoPadre = @CodigoTipoProductoPadre or 
@CodigoTipoProductoPadre IS NULL AND CodigoTipoProductoPadre IS NULL
GO

DROP PROCEDURE ObtenerProductoTipoNombre
GO
	
CREATE PROCEDURE ObtenerProductoTipoNombre
	@NombreTipoProducto VARCHAR(250)
AS
BEGIN
	SELECT CodigoTipoProducto,CodigoTipoProductoPadre, NombreTipoProducto, NombreCortoTipoProducto, DescripcionTipoProducto, Nivel
	FROM dbo.ProductosTipos
	WHERE NombreTipoProducto = @NombreTipoProducto
END
GO
