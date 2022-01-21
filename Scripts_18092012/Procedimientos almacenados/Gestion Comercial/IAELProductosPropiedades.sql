use DOBLONES20
GO

DROP PROCEDURE InsertarProductoPropiedad
GO

CREATE PROCEDURE InsertarProductoPropiedad
 	@NombrePropiedad	VARCHAR(250),
	@Mascara			VARCHAR(250)
AS
BEGIN
	INSERT INTO ProductosPropiedades(NombrePropiedad, Mascara)
	VALUES(@NombrePropiedad, @Mascara)
END
GO

DROP PROCEDURE ActualizarProductoPropiedad
GO

CREATE PROCEDURE ActualizarProductoPropiedad
	@CodigoPropiedad INT,
	@NombrePropiedad VARCHAR(250),
	@Mascara VARCHAR(250)
AS
BEGIN
	UPDATE 	ProductosPropiedades 
	SET		
		NombrePropiedad = @NombrePropiedad,
		Mascara			= @Mascara
	WHERE @CodigoPropiedad = CodigoPropiedad
END
GO

DROP PROCEDURE EliminarProductoPropiedad
GO

CREATE PROCEDURE EliminarProductoPropiedad
	@CodigoPropiedad INT
AS
BEGIN
	DELETE 
	FROM dbo.ProductosPropiedades
	WHERE @CodigoPropiedad = CodigoPropiedad
END
GO

DROP PROCEDURE ListarProductosPropiedades
GO

CREATE PROCEDURE ListarProductosPropiedades
AS
BEGIN
	SELECT CodigoPropiedad, NombrePropiedad, Mascara
	FROM dbo.ProductosPropiedades
	ORDER BY CodigoPropiedad
END
GO

DROP PROCEDURE ObtenerProductoPropiedad
GO

CREATE PROCEDURE ObtenerProductoPropiedad
	@CodigoPropiedad INT
AS
BEGIN
	SELECT CodigoPropiedad, NombrePropiedad, Mascara 
	FROM dbo.ProductosPropiedades
	WHERE CodigoPropiedad = @CodigoPropiedad
END

GO

DROP PROCEDURE ListarPropiedadesDisponiblesPorCodigoProducto
GO

CREATE PROCEDURE ListarPropiedadesDisponiblesPorCodigoProducto
@CodigoProducto		CHAR(15)
AS
BEGIN
	SELECT PP.CodigoPropiedad, PP.NombrePropiedad, PP.Mascara 
	FROM ProductosPropiedades PP
	WHERE PP.CodigoPropiedad NOT IN (
		SELECT PD.CodigoPropiedad 
		FROM ProductosDescripcion PD 
		WHERE PD.CodigoProducto = @CodigoProducto)
END
