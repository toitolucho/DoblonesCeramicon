USE Doblones20
GO


/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
--BEGIN TRANSACTION
--SET QUOTED_IDENTIFIER ON
--SET ARITHABORT ON
--SET NUMERIC_ROUNDABORT OFF
--SET CONCAT_NULL_YIELDS_NULL ON
--SET ANSI_NULLS ON
--SET ANSI_PADDING ON
--SET ANSI_WARNINGS ON
--COMMIT
--BEGIN TRANSACTION
--GO
--ALTER TABLE dbo.VentasProductosDetalleEntrega ADD
--	PrecioUnitarioCompraInventario decimal(10, 2) NULL,
--	FechaHoraCompraInventario datetime NULL
--GO
--ALTER TABLE dbo.VentasProductosDetalleEntrega SET (LOCK_ESCALATION = TABLE)
--GO
--COMMIT


DROP PROCEDURE InsertarVentaProductoDetalleEntrega
GO
CREATE PROCEDURE InsertarVentaProductoDetalleEntrega
	@NumeroAgencia						INT,
	@NumeroVentaProducto				INT,
	@CodigoProducto						CHAR(15),
	@FechaHoraEntrega					DATETIME,
	@CantidadEntregada					INT
AS
BEGIN
	INSERT INTO dbo.VentasProductosDetalleEntrega(NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, FechaHoraCompraInventario, CantidadEntregada)
	VALUES (@NumeroAgencia, @NumeroVentaProducto, @CodigoProducto, @FechaHoraEntrega, GETDATE(), @CantidadEntregada)
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
		CantidadEntregada = @CantidadEntregada
	WHERE NumeroAgencia	 = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
	AND CodigoProducto = @CodigoProducto
	AND FechaHoraEntrega = @FechaHoraEntrega
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
	WHERE NumeroAgencia	 = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
	AND CodigoProducto = @CodigoProducto
	AND FechaHoraEntrega = @FechaHoraEntrega
END
GO



DROP PROCEDURE ListarVentasProductosDetalleEntregas
GO
CREATE PROCEDURE ListarVentasProductosDetalleEntregas
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada, PrecioUnitarioCompraInventario, FechaHoraCompraInventario
	FROM dbo.VentasProductosDetalleEntrega
	ORDER BY NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega
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
	SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada, PrecioUnitarioCompraInventario, FechaHoraCompraInventario
	FROM dbo.VentasProductosDetalleEntrega
	WHERE NumeroAgencia	 = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
	AND CodigoProducto = @CodigoProducto
	AND FechaHoraEntrega = @FechaHoraEntrega
END
GO
