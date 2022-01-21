USE DOBLONES20
GO



DROP PROCEDURE InsertarCompraProductoDetalleEntrega
GO
CREATE PROCEDURE InsertarCompraProductoDetalleEntrega
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoProducto				CHAR(15),
	@CantidadEntregada			INT,
	@FechaHoraEntrega			DATETIME
AS
BEGIN
	INSERT INTO dbo.ComprasProductosDetalleEntrega(NumeroAgencia,NumeroCompraProducto, CodigoProducto, CantidadEntregada, FechaHoraEntrega)
	VALUES (@NumeroAgencia,@NumeroCompraProducto,@CodigoProducto, @CantidadEntregada, @FechaHoraEntrega)
END
GO



DROP PROCEDURE ActualizarCompraProductoDetalleEntrega
GO
CREATE PROCEDURE ActualizarCompraProductoDetalleEntrega
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoProducto				CHAR(15),
	@CantidadEntregada			INT,
	@FechaHoraEntrega			DATETIME
AS
BEGIN
	UPDATE 	dbo.ComprasProductosDetalleEntrega
	SET						
		CantidadEntregada	= @CantidadEntregada,
		FechaHoraEntrega	= @FechaHoraEntrega
	WHERE (NumeroCompraProducto = @NumeroCompraProducto) 
			AND (CodigoProducto = @CodigoProducto)			
			AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE EliminarCompraProductoDetalleEntrega
GO
CREATE PROCEDURE EliminarCompraProductoDetalleEntrega
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoProducto				CHAR(15),
	@FechaHoraEntrega			DATETIME
AS
BEGIN
	DELETE 
	FROM dbo.ComprasProductosDetalleEntrega
	WHERE (NumeroCompraProducto = @NumeroCompraProducto) 
			AND (CodigoProducto = @CodigoProducto)			
			AND (NumeroAgencia = @NumeroAgencia)
			AND FechaHoraEntrega = @FechaHoraEntrega
END
GO



DROP PROCEDURE ListarComprasProductosDetalleEntrega
GO
CREATE PROCEDURE ListarComprasProductosDetalleEntrega
	@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia,NumeroCompraProducto,CodigoProducto, CantidadEntregada, FechaHoraEntrega
	FROM dbo.ComprasProductosDetalleEntrega
	WHERE (NumeroAgencia= @NumeroAgencia)
	ORDER BY NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraEntrega
END
GO



DROP PROCEDURE ObtenerCompraProductoDetalleEntrega
GO
CREATE PROCEDURE ObtenerCompraProductoDetalleEntrega
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoProducto				CHAR(15),
	@FechaHoraEntrega			DATETIME
AS
BEGIN
	SELECT NumeroAgencia,NumeroCompraProducto,CodigoProducto, CantidadEntregada, FechaHoraEntrega
	FROM dbo.ComprasProductosDetalleEntrega
	WHERE (NumeroCompraProducto = @NumeroCompraProducto) 
			AND (CodigoProducto = @CodigoProducto)			
			AND (NumeroAgencia = @NumeroAgencia)
			AND FechaHoraEntrega = @FechaHoraEntrega
END
GO



DROP PROCEDURE ListarComprasProductosDetalleEntregaParaRecepcion
GO

CREATE PROCEDURE ListarComprasProductosDetalleEntregaParaRecepcion
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT
AS
BEGIN
	SELECT CodigoProducto, dbo.ObtenerNombreProducto(CodigoProducto) AS NombreProducto, CantidadEntregada, FechaHoraEntrega
	FROM ComprasProductosDetalleEntrega CPDE
	WHERE (NumeroCompraProducto = @NumeroCompraProducto) 			
			AND (NumeroAgencia = @NumeroAgencia)
END
GO