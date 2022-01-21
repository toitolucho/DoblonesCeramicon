USE DOBLONES20
GO

DROP PROCEDURE InsertarVentaProductoDetalleEntrega
GO

CREATE PROCEDURE InsertarVentaProductoDetalleEntrega
@NumeroAgencia			INT,
@NumeroVentaProducto	INT,
@CodigoProducto			CHAR(15),
@FechaHoraEntrega		DATETIME,
@CantidadEntregada		INT
AS
BEGIN	
	INSERT INTO dbo.VentasProductosDetalleEntrega(NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada)
	VALUES (@NumeroAgencia, @NumeroVentaProducto, @CodigoProducto, @FechaHoraEntrega, @CantidadEntregada)	
END
GO

DROP PROCEDURE ActualizarVentaProductoDetalleEntrega
GO

CREATE PROCEDURE ActualizarVentaProductoDetalleEntrega
@NumeroAgencia			INT,
@NumeroVentaProducto	INT,
@CodigoProducto			CHAR(15),
@FechaHoraEntrega		DATETIME,
@CantidadEntregada		INT
AS
BEGIN
	UPDATE 	dbo.VentasProductosDetalleEntrega
	SET			
		CantidadEntregada	= @CantidadEntregada,		
		FechaHoraEntrega	= @FechaHoraEntrega
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
	AND CodigoProducto = @CodigoProducto
END
GO

DROP PROCEDURE EliminarVentaProductoDetalleEntrega
GO

CREATE PROCEDURE EliminarVentaProductoDetalleEntrega
@NumeroAgencia			INT,
@NumeroVentaProducto	INT,
@CodigoProducto			CHAR(15),
@FechaHoraEntrega		DATETIME
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductosDetalleEntrega
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
	AND CodigoProducto = @CodigoProducto AND FechaHoraEntrega = @FechaHoraEntrega
END
GO

DROP PROCEDURE ListarVentasProductosDetalleEntrega
GO

CREATE PROCEDURE ListarVentasProductosDetalleEntrega
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada
	FROM dbo.VentasProductosDetalleEntrega
	ORDER BY NumeroVentaProducto,CodigoProducto
END
GO


DROP PROCEDURE ObtenerVentaProductoDetalleEntrega
GO

CREATE PROCEDURE ObtenerVentaProductoDetalleEntrega
@NumeroAgencia			INT,
@NumeroVentaProducto	INT,
@CodigoProducto			CHAR(15),
@FechaHoraEntrega		DATETIME
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada
	FROM dbo.VentasProductosDetalleEntrega
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
	AND CodigoProducto = @CodigoProducto AND FechaHoraEntrega = @FechaHoraEntrega
END
GO



DROP PROCEDURE ListarVentasProductosDetalleEspecificoEntrega
GO

CREATE PROCEDURE ListarVentasProductosDetalleEspecificoEntrega
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada
	FROM dbo.VentasProductosDetalleEntrega VPD	
	WHERE VPD.NumeroAgencia = @NumeroAgencia
	AND VPD.NumeroVentaProducto = @NumeroVentaProducto
	ORDER BY NumeroVentaProducto,CodigoProducto
END
GO


DROP PROCEDURE ListarVentaProductosDetalleEntregaParaVisualizarAlmacenes
GO

CREATE PROCEDURE ListarVentaProductosDetalleEntregaParaVisualizarAlmacenes
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT
AS
BEGIN
	SELECT CodigoProducto, dbo.ObtenerNombreProducto(CodigoProducto) AS NombreProducto, FechaHoraEntrega, CantidadEntregada
	FROM dbo.VentasProductosDetalleEntrega
	WHERE NumeroAgencia = @NumeroAgencia and NumeroVentaProducto = @NumeroVentaProducto	
	ORDER BY CodigoProducto, FechaHoraEntrega
END
GO