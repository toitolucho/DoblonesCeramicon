use DOBLONES20
GO

DROP PROCEDURE InsertarProductoCompuesto
GO

CREATE PROCEDURE InsertarProductoCompuesto
	@CodigoProducto				CHAR(15),
	@CodigoProductoComponente	CHAR(15),
	@NumeroComponente			INT,
	@Cantidad					INT
AS
BEGIN
	INSERT INTO dbo.ProductosCompuestos (CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
	VALUES (@CodigoProducto, @CodigoProductoComponente, @NumeroComponente, @Cantidad)
END
GO

DROP PROCEDURE ActualizarProductoCompuesto
GO

CREATE PROCEDURE ActualizarProductoCompuesto
	@CodigoProducto						CHAR(15),
	@CodigoProductoComponente			CHAR(15),
	@NumeroComponente				INT,
	@Cantidad						INT
AS
BEGIN
	UPDATE 	dbo.ProductosCompuestos
	SET		
		NumeroComponente = @NumeroComponente,
		Cantidad = @Cantidad
	WHERE (@CodigoProducto = CodigoProducto) AND (@CodigoProductoComponente = CodigoProductoComponente)
END
GO


DROP PROCEDURE ActualizarComponenteProductoCompuesto
GO

CREATE PROCEDURE ActualizarComponenteProductoCompuesto
	@CodigoProducto						CHAR(15),
	@CodigoProductoComponenteAnterior	CHAR(15),
	@CodigoProductoComponenteNuevo		CHAR(15),
	@NumeroComponente				INT,
	@Cantidad						INT
AS
BEGIN
	UPDATE 	dbo.ProductosCompuestos
	SET		
		NumeroComponente = @NumeroComponente,
		CodigoProductoComponente = @CodigoProductoComponenteNuevo,
		Cantidad = @Cantidad
	WHERE (@CodigoProducto = CodigoProducto) AND (@CodigoProductoComponenteAnterior = CodigoProductoComponente)
END
GO

DROP PROCEDURE EliminarProductoCompuesto
GO

CREATE PROCEDURE EliminarProductoCompuesto
	@CodigoProducto				CHAR(15),
	@CodigoProductoComponente	CHAR(15)
AS
BEGIN
	DELETE 
	FROM dbo.ProductosCompuestos
	WHERE (@CodigoProducto = CodigoProducto) AND (@CodigoProductoComponente = CodigoProductoComponente)
END
GO

DROP PROCEDURE ListarProductosCompuestos
GO

CREATE PROCEDURE ListarProductosCompuestos
AS
BEGIN
	SELECT CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad
	FROM dbo.ProductosCompuestos
	ORDER BY CodigoProducto, NumeroComponente
END
GO

DROP PROCEDURE ObtenerProductoCompuesto
GO

CREATE PROCEDURE ObtenerProductoCompuesto
	@CodigoProducto				CHAR(15),
	@CodigoProductoComponente	CHAR(15)
AS
BEGIN
	SELECT CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad
	FROM dbo.ProductosCompuestos
	WHERE (@CodigoProducto = CodigoProducto) AND (@CodigoProductoComponente = CodigoProductoComponente)
END
GO

DROP PROCEDURE ListarProductosCompuestosPorProducto
GO

CREATE PROCEDURE ListarProductosCompuestosPorProducto
@CodigoProducto			CHAR(15)
AS
BEGIN
	SELECT CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad
	FROM dbo.ProductosCompuestos
	WHERE @CodigoProducto = CodigoProducto
	ORDER BY CodigoProducto, NumeroComponente
END
GO
