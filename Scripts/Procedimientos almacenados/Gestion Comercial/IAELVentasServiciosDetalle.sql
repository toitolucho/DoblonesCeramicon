USE DOBLONES20
GO



DROP PROCEDURE InsertarVentaServicioDetalle
GO
CREATE PROCEDURE InsertarVentaServicioDetalle
	@NumeroAgencia			INT,
	@NumeroVentaServicio	INT,
	@CodigoServicio			INT,
	@CantidadVentaServicio	INT,
	@PrecioUnitario			DECIMAL(10,2),
	@TiempoGarantiaDias		INT	
AS
BEGIN
	INSERT INTO dbo.VentasServiciosDetalle(NumeroAgencia, NumeroVentaServicio, CodigoServicio, CantidadVentaServicio, PrecioUnitario, TiempoGarantiaDias)
	VALUES (@NumeroAgencia, @NumeroVentaServicio, @CodigoServicio, @CantidadVentaServicio, @PrecioUnitario, @TiempoGarantiaDias)
END
GO



DROP PROCEDURE ActualizarVentaServicioDetalle
GO
CREATE PROCEDURE ActualizarVentaServicioDetalle
	@NumeroAgencia			INT,
	@NumeroVentaServicio	INT,
	@CodigoServicio			INT,
	@CantidadVentaServicio	INT,
	@PrecioUnitario			DECIMAL(10,2),
	@TiempoGarantiaDias		INT
AS
BEGIN
	UPDATE 	dbo.VentasServiciosDetalle
	SET				
		CantidadVentaServicio	= @CantidadVentaServicio,
		PrecioUnitario			= @PrecioUnitario,
		TiempoGarantiaDias		= @TiempoGarantiaDias
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaServicio = @NumeroVentaServicio
	AND CodigoServicio = @CodigoServicio
END
GO



DROP PROCEDURE EliminarVentaServicioDetalle
GO
CREATE PROCEDURE EliminarVentaServicioDetalle
	@NumeroAgencia			INT,
	@NumeroVentaServicio	INT,
	@CodigoServicio			INT
AS
BEGIN
	DELETE 
	FROM dbo.VentasServiciosDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaServicio = @NumeroVentaServicio
	AND CodigoServicio = @CodigoServicio
END
GO



DROP PROCEDURE ListarVentaServicioDetalles
GO
CREATE PROCEDURE ListarVentaServicioDetalles
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaServicio, CodigoServicio, CantidadVentaServicio, PrecioUnitario, TiempoGarantiaDias
	FROM dbo.VentasServiciosDetalle
	ORDER BY NumeroAgencia, NumeroVentaServicio, CodigoServicio
END
GO



DROP PROCEDURE ObtenerVentaServicioDetalle
GO
CREATE PROCEDURE ObtenerVentaServicioDetalle
	@NumeroAgencia			INT,
	@NumeroVentaServicio	INT,
	@CodigoServicio			INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaServicio, CodigoServicio, CantidadVentaServicio, PrecioUnitario, TiempoGarantiaDias
	FROM dbo.VentasServiciosDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaServicio = @NumeroVentaServicio
	AND CodigoServicio = @CodigoServicio
END
GO

DROP PROCEDURE ListarVentaServicioDetalleParaMostrar
GO
CREATE PROCEDURE ListarVentaServicioDetalleParaMostrar
	@NumeroAgencia			INT,
	@NumeroVentaServicio	INT	
AS
BEGIN
	SELECT VSD.NumeroAgencia, VSD.NumeroVentaServicio, VSD.CodigoServicio, VSD.CantidadVentaServicio, VSD.PrecioUnitario, VSD.TiempoGarantiaDias, S.NombreServicio
	FROM dbo.VentasServiciosDetalle VSD
	INNER JOIN Servicios S
	ON VSD.CodigoServicio = S.CodigoServicio
	WHERE VSD.NumeroAgencia = @NumeroAgencia
	AND VSD.NumeroVentaServicio = @NumeroVentaServicio
	
END
GO



