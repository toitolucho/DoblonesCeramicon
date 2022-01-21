USE DOBLONES20
GO

DROP PROCEDURE InsertarVentasProductosDevolucionesEspecificos
GO

CREATE PROCEDURE InsertarVentasProductosDevolucionesEspecificos
@NumeroAgencia				INT,
@NumeroDevolucion			INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30),
@PrecioUnitarioDevolucionPE	DECIMAL(10,2)
AS
BEGIN
	INSERT INTO dbo.VentasProductosDevolucionesEspecificos (NumeroAgencia, NumeroDevolucion, CodigoProducto, CodigoProductoEspecifico, PrecioUnitarioDevolucionPE)
	VALUES (@NumeroAgencia, @NumeroDevolucion, @CodigoProducto, @CodigoProductoEspecifico, @PrecioUnitarioDevolucionPE)
END
GO

DROP PROCEDURE ActualizarVentasProductosDevolucionesEspecificos
GO

CREATE PROCEDURE ActualizarVentasProductosDevolucionesEspecificos
@NumeroAgencia				INT,
@NumeroDevolucion			INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30),
@PrecioUnitarioDevolucionPE	DECIMAL(10,2)
AS
BEGIN
	UPDATE 	dbo.VentasProductosDevolucionesEspecificos
	SET		
		PrecioUnitarioDevolucionPE = @PrecioUnitarioDevolucionPE
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
	AND CodigoProducto = @CodigoProducto
	AND CodigoProductoEspecifico = @CodigoProductoEspecifico
END
GO

DROP PROCEDURE EliminarVentasProductosDevolucionesEspecificos
GO

CREATE PROCEDURE EliminarVentasProductosDevolucionesEspecificos
@NumeroAgencia				INT,
@NumeroDevolucion			INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30)
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductosDevolucionesEspecificos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
	AND CodigoProducto = @CodigoProducto
	AND CodigoProductoEspecifico = @CodigoProductoEspecifico
END
GO

DROP PROCEDURE ListarVentasProductosDevolucionesEspecificos
GO

CREATE PROCEDURE ListarVentasProductosDevolucionesEspecificos
@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroDevolucion, CodigoProducto, CodigoProductoEspecifico, PrecioUnitarioDevolucionPE
	FROM dbo.VentasProductosDevolucionesEspecificos
	WHERE NumeroAgencia = @NumeroAgencia
	ORDER BY NumeroAgencia, NumeroDevolucion
END
GO


DROP PROCEDURE ObtenerVentaProductoDevolucionEspecifico
GO

CREATE PROCEDURE ObtenerVentaProductoDevolucionEspecifico
@NumeroAgencia				INT,
@NumeroDevolucion			INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30)
AS
BEGIN
	SELECT NumeroAgencia, NumeroDevolucion, CodigoProducto, CodigoProductoEspecifico, PrecioUnitarioDevolucionPE
	FROM dbo.VentasProductosDevolucionesEspecificos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
	AND CodigoProducto = @CodigoProducto
	AND CodigoProductoEspecifico = @CodigoProductoEspecifico
END
GO


DROP PROCEDURE ListarVentasProductosDevolucionesEspecificosParaDevolucionesEspecificos
GO

CREATE PROCEDURE ListarVentasProductosDevolucionesEspecificosParaDevolucionesEspecificos
@NumeroAgencia		INT,
@NumeroDevolucion	INT
AS
BEGIN
	SELECT CodigoProducto, CodigoProductoEspecifico, dbo.ObtenerNombreProducto(CodigoProducto) AS NombreProducto, PrecioUnitarioDevolucionPE
	FROM dbo.VentasProductosDevolucionesEspecificos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion	
END
GO