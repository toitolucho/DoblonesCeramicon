USE DOBLONES20
GO

DROP PROCEDURE InsertarVentasProductosDevolucionesDetalle
GO

CREATE PROCEDURE InsertarVentasProductosDevolucionesDetalle
@NumeroAgencia					INT,
@NumeroDevolucion				INT,
@CodigoMotivoReemDevo			INT,
@CodigoProducto					CHAR(15),
@CantidadDevuelta				INT,
@PrecioUnitarioDevolucion		DECIMAL(10,2)
AS
BEGIN
	INSERT INTO dbo.VentasProductosDevolucionesDetalle (NumeroAgencia, NumeroDevolucion, CodigoMotivoReemDevo, CodigoProducto, CantidadDevuelta, PrecioUnitarioDevolucion)
	VALUES (@NumeroAgencia, @NumeroDevolucion, @CodigoMotivoReemDevo, @CodigoProducto, @CantidadDevuelta, @PrecioUnitarioDevolucion)
END
GO

DROP PROCEDURE ActualizarVentasProductosDevolucionesDetalle
GO

CREATE PROCEDURE ActualizarVentasProductosDevolucionesDetalle
@NumeroAgencia					INT,
@NumeroDevolucion				INT,
@CodigoMotivoReemDevo			INT,
@CodigoProducto					CHAR(15),
@CantidadDevuelta				INT,
@PrecioUnitarioDevolucion		DECIMAL(10,2)
AS
BEGIN
	UPDATE 	dbo.VentasProductosDevolucionesDetalle
	SET		
		CodigoMotivoReemDevo		= @CodigoMotivoReemDevo,		
		CantidadDevuelta			= @CantidadDevuelta,
		PrecioUnitarioDevolucion	= @PrecioUnitarioDevolucion
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
	AND CodigoProducto = @CodigoProducto
END
GO

DROP PROCEDURE EliminarVentasProductosDevolucionesDetalle
GO

CREATE PROCEDURE EliminarVentasProductosDevolucionesDetalle
@NumeroAgencia		INT,
@NumeroDevolucion	INT,
@CodigoProducto		CHAR(15)
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductosDevolucionesDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
	AND CodigoProducto = @CodigoProducto
END
GO

DROP PROCEDURE ListarVentasProductosDevolucionesDetalle
GO

CREATE PROCEDURE ListarVentasProductosDevolucionesDetalle
@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroDevolucion, CodigoMotivoReemDevo, CodigoProducto, CantidadDevuelta, PrecioUnitarioDevolucion
	FROM dbo.VentasProductosDevolucionesDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	ORDER BY NumeroAgencia, NumeroDevolucion
END
GO


DROP PROCEDURE ObtenerVentaProductoDevolucionDetalle
GO

CREATE PROCEDURE ObtenerVentaProductoDevolucionDetalle
@NumeroAgencia		INT,
@NumeroDevolucion	INT,
@CodigoProducto		CHAR(15)
AS
BEGIN
	SELECT NumeroAgencia, NumeroDevolucion, CodigoMotivoReemDevo, CodigoProducto, CantidadDevuelta, PrecioUnitarioDevolucion
	FROM dbo.VentasProductosDevolucionesDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion
	AND CodigoProducto = @CodigoProducto
END
GO


DROP PROCEDURE ListarVentasProductosDevolucionesParaDevolucion
GO

CREATE PROCEDURE ListarVentasProductosDevolucionesParaDevolucion
@NumeroAgencia		INT,
@NumeroDevolucion	INT
AS
BEGIN
	SELECT CodigoProducto, dbo.ObtenerNombreProducto(CodigoProducto) AS NombreProducto, MRD.NombreMotivoReemDevo , CantidadDevuelta , PrecioUnitarioDevolucion
	FROM dbo.VentasProductosDevolucionesDetalle VPDD INNER JOIN MotivosReemDevo MRD ON VPDD.CodigoMotivoReemDevo = MRD.CodigoMotivoReemDevo
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroDevolucion = @NumeroDevolucion	
END
GO