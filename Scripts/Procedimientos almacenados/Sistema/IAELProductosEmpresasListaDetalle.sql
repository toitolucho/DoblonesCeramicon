USE Doblones20
GO


DROP PROCEDURE InsertarProductosEmpresasListaDetalle
GO
CREATE PROCEDURE InsertarProductosEmpresasListaDetalle
@NumeroLista		INT,
@Codigo				CHAR(15),
@Nombre				VARCHAR(250),
@Descripcion		TEXT,
@Precio				DECIMAL(10,2)
AS
BEGIN
	INSERT INTO dbo.ProductosEmpresasListaDetalle (NumeroLista, CodigoProducto, NombreProducto, DescripcionProducto, PrecioProducto)
	VALUES (@NumeroLista, @Codigo, @Nombre, @Descripcion, @Precio)
END
GO


/*DROP PROCEDURE ActualizarProductosEmpresasListaDetalle
GO
CREATE PROCEDURE ActualizarProductosEmpresasListaDetalle
@NumeroLista	INT,
@CodigoProducto	
AS
BEGIN
END
GO*/


DROP PROCEDURE	EliminarProductosEmpresasListaDetalle
GO
CREATE PROCEDURE EliminarProductosEmpresasListaDetalle
@NumeroLista	INT
AS
BEGIN
	DELETE FROM dbo.ProductosEmpresasListaDetalle
	WHERE NumeroLista = @NumeroLista
END
GO



DROP PROCEDURE ListarProductosEmpresasListaDetalle
GO
CREATE PROCEDURE ListarProductosEmpresasListaDetalle
AS
BEGIN
	SELECT NumeroLista, CodigoProducto, NombreProducto, DescripcionProducto, PrecioProducto
	FROM dbo.ProductosEmpresasListaDetalle
END
GO



DROP PROCEDURE ObtenerProductosEmpresasListaDetalle
GO
CREATE PROCEDURE ObtenerProductosEmpresasListaDetalle
@NumeroLista	INT
AS
BEGIN
	SELECT NumeroLista, CodigoProducto, NombreProducto, DescripcionProducto, PrecioProducto
	FROM dbo.ProductosEmpresasListaDetalle
	WHERE NumeroLista = @NumeroLista
END
GO



DROP PROCEDURE ListarProductosEmpresasListaDetalleReporte
GO
CREATE PROCEDURE ListarProductosEmpresasListaDetalleReporte
@NumeroLista	INT
AS
BEGIN
	SELECT P.NombreRazonSocial, PL.Descripcion, PL.Fecha, PLD.CodigoProducto, PLD.NombreProducto, PLD.DescripcionProducto, PLD.PrecioProducto
	FROM dbo.ProductosEmpresasLista PL INNER JOIN dbo.ProductosEmpresasListaDetalle PLD
	ON PL.NumeroLista = PLD.NumeroLista INNER JOIN dbo.Proveedores P
	ON PL.CodigoEmpresa = P.CodigoProveedor
	WHERE PL.NumeroLista = @NumeroLista
	ORDER BY PLD.CodigoProducto
END
GO