USE DOBLONES20
GO

DROP PROCEDURE InsertarVentaProductoEspecifico
GO
CREATE PROCEDURE InsertarVentaProductoEspecifico
@NumeroAgencia				INT,
@NumeroVentaProducto		INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30),
@TiempoGarantiaPE			INT,
@Entregado					BIT,
@FechaHoraEntrega			DATETIME
AS
BEGIN
	INSERT INTO dbo.VentasProductosEspecificos(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPE, Entregado, FechaHoraEntrega)
	VALUES (@NumeroAgencia, @NumeroVentaProducto, @CodigoProducto, @CodigoProductoEspecifico, @TiempoGarantiaPE, @Entregado, @FechaHoraEntrega)
END
GO

DROP PROCEDURE ActualizarVentaProductoEspecifico
GO

CREATE PROCEDURE ActualizarVentaProductoEspecifico
@NumeroAgencia				INT,
@NumeroVentaProducto		INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30),
@TiempoGarantiaPE			INT,
@Entregado					BIT,
@FechaHoraEntrega			DATETIME
AS
BEGIN
	UPDATE 	dbo.VentasProductosEspecificos
	SET		
		TiempoGarantiaPE	= @TiempoGarantiaPE,
		Entregado			= @Entregado,
		FechaHoraEntrega	= @FechaHoraEntrega
	WHERE NumeroAgencia=@NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
	AND CodigoProducto = @CodigoProducto
	AND CodigoProductoEspecifico = @CodigoProductoEspecifico
END
GO

DROP PROCEDURE EliminarVentaProductoEspecifico
GO

CREATE PROCEDURE EliminarVentaProductoEspecifico
@NumeroAgencia				INT,
@NumeroVentaProducto		INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30)
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductosEspecificos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
	AND CodigoProducto = @CodigoProducto
	AND CodigoProductoEspecifico = @CodigoProductoEspecifico
END
GO

DROP PROCEDURE ListarVentasProductosEspecificos
GO

CREATE PROCEDURE ListarVentasProductosEspecificos
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPE, Entregado, FechaHoraEntrega
	FROM dbo.VentasProductosEspecificos
	ORDER BY NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoProductoEspecifico
END
GO

DROP PROCEDURE ObtenerVentaProductoEspecifico
GO

CREATE PROCEDURE ObtenerVentaProductoEspecifico
@NumeroAgencia				INT,
@NumeroVentaProducto		INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30)
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPE, Entregado, FechaHoraEntrega
	FROM dbo.VentasProductosEspecificos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
	AND CodigoProducto = @CodigoProducto
	AND CodigoProductoEspecifico = @CodigoProductoEspecifico
END
GO



DROP PROCEDURE ListarVentasProductosEspecificosParaVisualizarAlmacenes
GO

CREATE PROCEDURE ListarVentasProductosEspecificosParaVisualizarAlmacenes
	@NumeroAgencia				INT,
	@NumeroVentaProducto		INT
AS
BEGIN
	SELECT CodigoProducto, dbo.ObtenerNombreProducto(CodigoProducto) as NombreProducto, CodigoProductoEspecifico, FechaHoraEntrega
	FROM VentasProductosEspecificos
	WHERE NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroVentaProducto
	ORDER BY CodigoProducto, FechaHoraEntrega
END
GO

