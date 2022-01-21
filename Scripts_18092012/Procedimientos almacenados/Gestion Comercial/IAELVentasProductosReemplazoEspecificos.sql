USE DOBLONES20
GO

DROP PROCEDURE InsertarVentasProductosReemplazoEspecificos
GO

CREATE PROCEDURE InsertarVentasProductosReemplazoEspecificos
@NumeroAgencia				INT,
@NumeroReemplazo			INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30),
@PrecioUnitarioReemplazoPE	DECIMAL(10,2),
@TiempoGarantiaPE			INT,
@FechaHoraVencimientoPE		DATETIME
AS
BEGIN
	INSERT INTO dbo.VentasProductosReemplazoEspecificos (NumeroAgencia, NumeroReemplazo, CodigoProducto, CodigoProductoEspecifico, PrecioUnitarioReemplazoPE, TiempoGarantiaPE, FechaHoraVencimientoPE)
	VALUES (@NumeroAgencia, @NumeroReemplazo, @CodigoProducto, @CodigoProductoEspecifico, @PrecioUnitarioReemplazoPE, @TiempoGarantiaPE, @FechaHoraVencimientoPE)
END
GO

DROP PROCEDURE ActualizarVentasProductosReemplazoEspecificos
GO

CREATE PROCEDURE ActualizarVentasProductosReemplazoEspecificos
@NumeroAgencia				INT,
@NumeroReemplazo			INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30),
@PrecioUnitarioReemplazoPE	DECIMAL(10,2),
@TiempoGarantiaPE			INT,
@FechaHoraVencimientoPE		DATETIME
AS
BEGIN
	UPDATE 	dbo.VentasProductosReemplazoEspecificos
	SET		
		PrecioUnitarioReemplazoPE = @PrecioUnitarioReemplazoPE,
		TiempoGarantiaPE		  = @TiempoGarantiaPE,
		FechaHoraVencimientoPE	  = @FechaHoraVencimientoPE
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroReemplazo = @NumeroReemplazo
	AND CodigoProducto = @CodigoProducto
	AND CodigoProductoEspecifico = @CodigoProductoEspecifico
END
GO

DROP PROCEDURE EliminarVentasProductosReemplazoEspecificos
GO

CREATE PROCEDURE EliminarVentasProductosReemplazoEspecificos
@NumeroAgencia				INT,
@NumeroReemplazo			INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30)
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductosReemplazoEspecificos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroReemplazo = @NumeroReemplazo
	AND CodigoProducto = @CodigoProducto
	AND CodigoProductoEspecifico = @CodigoProductoEspecifico
END
GO

DROP PROCEDURE ListarVentasProductosReemplazoEspecificos
GO

CREATE PROCEDURE ListarVentasProductosReemplazoEspecificos
@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroReemplazo, CodigoProducto, CodigoProductoEspecifico, PrecioUnitarioReemplazoPE, TiempoGarantiaPE, FechaHoraVencimientoPE
	FROM dbo.VentasProductosReemplazoEspecificos
	WHERE NumeroAgencia = @NumeroAgencia
	ORDER BY NumeroAgencia, NumeroReemplazo
END
GO


DROP PROCEDURE ObtenerVentaProductoReemplazoEspecifico
GO

CREATE PROCEDURE ObtenerVentaProductoReemplazoEspecifico
@NumeroAgencia				INT,
@NumeroReemplazo			INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30)
AS
BEGIN
	SELECT NumeroAgencia, NumeroReemplazo, CodigoProducto, CodigoProductoEspecifico, PrecioUnitarioReemplazoPE, TiempoGarantiaPE, FechaHoraVencimientoPE
	FROM dbo.VentasProductosReemplazoEspecificos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroReemplazo = @NumeroReemplazo
	AND CodigoProducto = @CodigoProducto
	AND CodigoProductoEspecifico = @CodigoProductoEspecifico
END
GO


DROP PROCEDURE ListarVentasProductosReemplazoEspecificosParaReemplazo
GO

CREATE PROCEDURE ListarVentasProductosReemplazoEspecificosParaReemplazo
@NumeroAgencia				INT,
@NumeroReemplazo			INT
AS
BEGIN
	SELECT  CodigoProducto, CodigoProductoEspecifico, dbo.ObtenerNombreProducto(CodigoProducto) AS NombreProducto, PrecioUnitarioReemplazoPE, TiempoGarantiaPE, FechaHoraVencimientoPE
	FROM dbo.VentasProductosReemplazoEspecificos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroReemplazo = @NumeroReemplazo	
END
GO