USE DOBLONES20
GO

DROP PROCEDURE InsertarComprasProductosDevolucionesEspecificos
GO

CREATE PROCEDURE InsertarComprasProductosDevolucionesEspecificos
@NumeroAgencia				INT,
@NumeroDevolucion			INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30),
@PrecioUnitarioDevolucionPE	DECIMAL(10,2)
AS
BEGIN
	INSERT INTO dbo.ComprasProductosDevolucionesEspecificos (NumeroAgencia, NumeroDevolucion, CodigoProducto, CodigoProductoEspecifico, PrecioUnitarioDevolucionPE)
	VALUES (@NumeroAgencia, @NumeroDevolucion, @CodigoProducto, @CodigoProductoEspecifico, @PrecioUnitarioDevolucionPE)
END
GO

DROP PROCEDURE ActualizarComprasProductosDevolucionesEspecificos
GO

CREATE PROCEDURE ActualizarComprasProductosDevolucionesEspecificos
@NumeroAgencia				INT,
@NumeroDevolucion			INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30),
@PrecioUnitarioDevolucionPE	DECIMAL(10,2)
AS
BEGIN
	UPDATE 	dbo.ComprasProductosDevolucionesEspecificos
	SET		
		PrecioUnitarioDevolucionPE = @PrecioUnitarioDevolucionPE		
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
	AND CodigoProducto = @CodigoProducto
	AND CodigoProductoEspecifico = @CodigoProductoEspecifico
END
GO

DROP PROCEDURE EliminarComprasProductosDevolucionesEspecificos
GO

CREATE PROCEDURE EliminarComprasProductosDevolucionesEspecificos
@NumeroAgencia				INT,
@NumeroDevolucion			INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30)
AS
BEGIN
	DELETE 
	FROM dbo.ComprasProductosDevolucionesEspecificos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
	AND CodigoProducto = @CodigoProducto
	AND CodigoProductoEspecifico = @CodigoProductoEspecifico
END
GO

DROP PROCEDURE ListarComprasProductosDevolucionesEspecificos
GO

CREATE PROCEDURE ListarComprasProductosDevolucionesEspecificos
@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroDevolucion, CodigoProducto, CodigoProductoEspecifico, PrecioUnitarioDevolucionPE
	FROM dbo.ComprasProductosDevolucionesEspecificos
	WHERE NumeroAgencia = @NumeroAgencia
	ORDER BY NumeroAgencia, NumeroDevolucion
END
GO


DROP PROCEDURE ObtenerCompraProductoDevolucionEspecifico
GO

CREATE PROCEDURE ObtenerCompraProductoDevolucionEspecifico
@NumeroAgencia				INT,
@NumeroDevolucion			INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30)
AS
BEGIN
	SELECT NumeroAgencia, NumeroDevolucion, CodigoProducto, CodigoProductoEspecifico, PrecioUnitarioDevolucionPE
	FROM dbo.ComprasProductosDevolucionesEspecificos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
	AND CodigoProducto = @CodigoProducto
	AND CodigoProductoEspecifico = @CodigoProductoEspecifico
END
GO


DROP PROCEDURE ListarComprasProductosDevolucionesEspecificosParaDevoluciones
GO

CREATE PROCEDURE ListarComprasProductosDevolucionesEspecificosParaDevoluciones
@NumeroAgencia				INT,
@NumeroDevolucion			INT
AS
BEGIN
	SELECT  CodigoProducto, CodigoProductoEspecifico, dbo.ObtenerNombreProducto(CodigoProducto) AS NombreProducto, PrecioUnitarioDevolucionPE
	FROM dbo.ComprasProductosDevolucionesEspecificos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion	
END
GO