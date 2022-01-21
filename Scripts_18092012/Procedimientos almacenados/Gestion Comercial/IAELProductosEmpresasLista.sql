USE Doblones20
GO


DROP PROCEDURE InsertarProductosEmpresasLista
GO
CREATE PROCEDURE InsertarProductosEmpresasLista
@CodigoProveedor	INT,
@Descripcion		VARCHAR(250),
@Fecha				DATETIME
AS
BEGIN
	INSERT INTO dbo.ProductosEmpresasLista (CodigoEmpresa, Descripcion, Fecha)
	VALUES (@CodigoProveedor, @Descripcion, @Fecha)
END
GO



DROP PROCEDURE ActualizarProductosEmpresasLista
GO
CREATE PROCEDURE ActualizarProductosEmpresasLista
@NumeroLista		INT,
@CodigoProveedor	INT,
@Descripcion		VARCHAR(250),
@Fecha				DATETIME
AS
BEGIN
	UPDATE dbo.ProductosEmpresasLista
	SET		
		CodigoEmpresa = @CodigoProveedor,
		Descripcion = @Descripcion,
		Fecha = @Fecha
	WHERE NumeroLista = @NumeroLista
END
GO



DROP PROCEDURE EliminarProductosEmpresasLista
GO
CREATE PROCEDURE EliminarProductosEmpresasLista
@NumeroLista	INT
AS
BEGIN
	DELETE FROM dbo.ProductosEmpresasLista
	WHERE NumeroLista = @NumeroLista
END
GO



DROP PROCEDURE ListarProductosEmpresasLista
GO
CREATE PROCEDURE ListarProductosEmpresasLista
AS
BEGIN
	SELECT NumeroLista, CodigoEmpresa, Descripcion, Fecha
	FROM dbo.ProductosEmpresasLista
END
GO



DROP PROCEDURE ListarProductosEmpresasListaProveedor
GO
CREATE PROCEDURE ListarProductosEmpresasListaProveedor
@CodigoEmpresa	INT
AS
BEGIN
	SELECT NumeroLista, CodigoEmpresa, Descripcion, Fecha
	FROM dbo.ProductosEmpresasLista
	WHERE CodigoEmpresa = @CodigoEmpresa
	ORDER BY Fecha ASC
END
GO



DROP PROCEDURE ListarProveedoresProductosEmpresasLista
GO
CREATE PROCEDURE ListarProveedoresProductosEmpresasLista
AS
BEGIN
	SELECT P.CodigoProveedor, P.NombreRazonSocial
	FROM dbo.ProductosEmpresasLista PEL INNER JOIN dbo.Proveedores P
	ON PEL.CodigoEmpresa = P.CodigoProveedor
	ORDER BY P.NombreRazonSocial
END
GO



DROP PROCEDURE ObtenerUlitmoIndiceLista
GO
CREATE PROCEDURE ObtenerUlitmoIndiceLista
@UlitmoNumeroLista	INT OUTPUT
AS
BEGIN
	SET @UlitmoNumeroLista  = (SELECT MAX(NumeroLista)
								FROM dbo.ProductosEmpresasLista)
END
GO