USE DOBLONES20
GO



DROP PROCEDURE InsertarCompraProductoDocuImag
GO
CREATE PROCEDURE InsertarCompraProductoDocuImag
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoTipoDocumento		TINYINT,
	@NumeroTipoDocumento		TINYINT,
	@RutaArchivoImagenDocumento	TEXT,
	@Descripcion				TEXT
AS
BEGIN
	INSERT INTO dbo.ComprasProductosDocuImag (NumeroAgencia,NumeroCompraProducto,CodigoTipoDocumento,NumeroTipoDocumento,RutaArchivoImagenDocumento,Descripcion)
	VALUES (@NumeroAgencia,@NumeroCompraProducto,@CodigoTipoDocumento,@NumeroTipoDocumento,@RutaArchivoImagenDocumento,@Descripcion)
END
GO



DROP PROCEDURE ActualizarCompraProductoDocuImag
GO
CREATE PROCEDURE ActualizarCompraProductoDocuImag
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoTipoDocumento		TINYINT,
	@NumeroTipoDocumento		TINYINT,
	@RutaArchivoImagenDocumento	TEXT,
	@Descripcion				TEXT
AS
BEGIN
	UPDATE 	dbo.ComprasProductosDocuImag
	SET						
		NumeroTipoDocumento			= @NumeroTipoDocumento,
		RutaArchivoImagenDocumento	= @RutaArchivoImagenDocumento,
		Descripcion					= @Descripcion
	WHERE	(NumeroAgencia			= @NumeroAgencia)
		AND (NumeroCompraProducto	= @NumeroCompraProducto)
		AND (CodigoTipoDocumento	= @CodigoTipoDocumento )
END
GO



DROP PROCEDURE EliminarCompraProductoDocuImag
GO
CREATE PROCEDURE EliminarCompraProductoDocuImag
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoTipoDocumento		TINYINT
AS
BEGIN
	DELETE 
	FROM dbo.ComprasProductosDocuImag
	WHERE	(NumeroAgencia			= @NumeroAgencia)
		AND (NumeroCompraProducto	= @NumeroCompraProducto)
		AND (CodigoTipoDocumento	= @CodigoTipoDocumento )
END
GO



DROP PROCEDURE ListarComprasProductosDocuImag
GO
CREATE PROCEDURE ListarComprasProductosDocuImag
	@NumeroAgencia	INT
AS
BEGIN
	SELECT NumeroAgencia,NumeroCompraProducto,CodigoTipoDocumento,NumeroTipoDocumento,RutaArchivoImagenDocumento,Descripcion
	FROM dbo.ComprasProductosDocuImag
	WHERE (NumeroAgencia= @NumeroAgencia)
	ORDER BY NumeroAgencia, NumeroCompraProducto, CodigoTipoDocumento
END
GO



DROP PROCEDURE ObtenerCompraProductoDocuImag
GO
CREATE PROCEDURE ObtenerCompraProductoDocuImag
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoTipoDocumento		TINYINT
AS
BEGIN
	SELECT NumeroAgencia,NumeroCompraProducto,CodigoTipoDocumento,NumeroTipoDocumento,RutaArchivoImagenDocumento,Descripcion
	FROM dbo.ComprasProductosDocuImag
	WHERE	(NumeroAgencia			= @NumeroAgencia)
		AND (NumeroCompraProducto	= @NumeroCompraProducto)
		AND (CodigoTipoDocumento	= @CodigoTipoDocumento )
END
GO



--DROP PROCEDURE ObtenerComprasProductosDocuImag
--GO
--CREATE PROCEDURE ObtenerComprasProductosDocuImag
--AS
--BEGIN
--	SELECT NumeroAgencia,NumeroCompraProducto,CodigoTipoDocumento,NumeroTipoDocumento,RutaArchivoImagenDocumento,Descripcion
--	FROM dbo.ComprasProductosDocuImag
--END
--GO