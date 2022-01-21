USE Doblones20
GO

DROP PROCEDURE ListarProductosDescripcionCotizacion
GO

--exec ListarProductosDescripcionCotizacion 1, 2

CREATE PROCEDURE ListarProductosDescripcionCotizacion
	@NumeroAgencia					INT,
	@NumeroCotizacionVentaProducto	INT
AS
BEGIN
	

	SELECT	P.CodigoProducto, 
			P.NombreProducto, 
			P.Descripcion, 
			PM.NombreMarcaProducto, 
			PT.NombreTipoProducto, 
			RTRIM(PD.ValorPropiedad) +' '+RTRIM(PP.Mascara) AS ValorPropiedad, 
			UPPER(PP.NombrePropiedad) AS NombrePropiedad, 
			PIM1.NumeroImagen, 
			CAST(PIM1.RutaArchivoImagen AS VARCHAR(4000)) AS RutaImagenProducto1, 
			CAST(PIM2.RutaArchivoImagen AS VARCHAR(4000)) AS RutaImagenProducto2, 
			CAST(PIM3.RutaArchivoImagen AS VARCHAR(4000)) AS RutaImagenProducto3
	FROM Productos P
	INNER JOIN ProductosMarcas PM
	ON P.CodigoMarcaProducto = PM.CodigoMarcaProducto
	INNER JOIN ProductosTipos PT
	ON P.CodigoTipoProducto = PT.CodigoTipoProducto
	LEFT JOIN ProductosDescripcion PD
	ON P.CodigoProducto = PD.CodigoProducto
	LEFT JOIN ProductosPropiedades PP
	ON PD.CodigoPropiedad = PP.CodigoPropiedad	
	LEFT JOIN ProductosImagenes PIM1
	ON P.CodigoProducto = PIM1.CodigoProducto
	AND PIM1.NumeroImagen = 1
	LEFT JOIN ProductosImagenes PIM2
	ON P.CodigoProducto = PIM2.CodigoProducto
	AND PIM2.NumeroImagen = 2
	LEFT JOIN ProductosImagenes PIM3
	ON P.CodigoProducto = PIM3.CodigoProducto
	AND PIM3.NumeroImagen = 3
	
	WHERE P.CodigoProducto IN (
		SELECT CodigoProducto 
		FROM CotizacionVentasProductosDeta 
		WHERE NumeroAgencia = @NumeroAgencia 
		AND NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto 
	)	
	
END
GO