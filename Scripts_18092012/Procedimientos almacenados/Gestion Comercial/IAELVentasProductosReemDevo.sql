USE DOBLONES20
GO

DROP PROCEDURE InsertarVentaProductoReemDevo
GO
CREATE PROCEDURE InsertarVentaProductoReemDevo
	@NumeroAgencia					INT,
	@NumeroVentaProducto			INT,
	@CodigoUsuario					INT,
	@FechaHoraSolicitudReemDevo		DATETIME,
	@ObservacionesSolicitudReemDevo	TEXT
AS	
BEGIN
	INSERT INTO dbo.VentasProductosReemDevo(NumeroAgencia, NumeroVentaProducto, CodigoUsuario, FechaHoraSolicitudReemDevo, ObservacionesSolicitudReemDevo)
	VALUES (@NumeroAgencia, @NumeroVentaProducto, @CodigoUsuario, @FechaHoraSolicitudReemDevo, @ObservacionesSolicitudReemDevo)
END
GO

DROP PROCEDURE ActualizarVentaProductoReemDevo
GO

CREATE PROCEDURE ActualizarVentaProductoReemDevo
	@NumeroAgencia					INT,
	@NumeroReemDevo					INT,
	@NumeroVentaProducto			INT,
	@CodigoUsuario					INT,
	@FechaHoraSolicitudReemDevo		DATETIME,
	@ObservacionesSolicitudReemDevo	TEXT
AS
BEGIN
	UPDATE 	dbo.VentasProductosReemDevo
	SET		
		NumeroVentaProducto				= @NumeroVentaProducto,
		CodigoUsuario					= @CodigoUsuario,
		FechaHoraSolicitudReemDevo		= @FechaHoraSolicitudReemDevo,
		ObservacionesSolicitudReemDevo	= @ObservacionesSolicitudReemDevo
	WHERE NumeroAgencia = @NumeroAgencia AND NumeroReemDevo = @NumeroReemDevo
END
GO


DROP PROCEDURE EliminarVentaProductoReemDevo
GO

CREATE PROCEDURE EliminarVentaProductoReemDevo
@NumeroAgencia			INT,
@NumeroReemDevo			INT
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductosReemDevo
	WHERE NumeroAgencia = @NumeroAgencia AND NumeroReemDevo = @NumeroReemDevo
END
GO

DROP PROCEDURE ListarVentasProductosReemDevo
GO

CREATE PROCEDURE ListarVentasProductosReemDevo
	@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroReemDevo, NumeroVentaProducto, CodigoUsuario, FechaHoraSolicitudReemDevo, ObservacionesSolicitudReemDevo
	FROM dbo.VentasProductosReemDevo
	WHERE NumeroAgencia = @NumeroAgencia
	ORDER BY NumeroReemDevo
END
GO

DROP PROCEDURE ObtenerVentaProductoReemDevo
GO
CREATE PROCEDURE ObtenerVentaProductoReemDevo
@NumeroAgencia			INT,
@NumeroReemDevo			INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroReemDevo, NumeroVentaProducto, CodigoUsuario, FechaHoraSolicitudReemDevo, ObservacionesSolicitudReemDevo
	FROM dbo.VentasProductosReemDevo
	WHERE NumeroAgencia = @NumeroAgencia AND NumeroReemDevo = @NumeroReemDevo
END
GO
