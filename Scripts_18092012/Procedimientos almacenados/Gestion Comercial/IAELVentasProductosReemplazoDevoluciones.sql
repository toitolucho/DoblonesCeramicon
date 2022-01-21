USE DOBLONES20
GO

DROP PROCEDURE InsertarVentasProductosReemplazoDevoluciones
GO

CREATE PROCEDURE InsertarVentasProductosReemplazoDevoluciones
@NumeroAgencia					INT,
@CodigoEstadoReemplazoDevo		CHAR(1),
@CodigoUsuario					INT,
@FechaHoraSolicitudReemDevo		DATE,
@ObservacionesReemDevo			TEXT,
@NumeroReemplazo				INT
AS
BEGIN
	INSERT INTO dbo.VentasProductosReemplazoDevoluciones (NumeroAgencia, CodigoEstadoReemplazoDevo, CodigoUsuario, FechaHoraSolicitudReemDevo, ObservacionesReemDevo, NumeroReemplazo)
	VALUES (@NumeroAgencia, @CodigoEstadoReemplazoDevo, @CodigoUsuario, @FechaHoraSolicitudReemDevo, @ObservacionesReemDevo, @NumeroReemplazo)
END
GO

DROP PROCEDURE ActualizarVentasProductosReemplazoDevoluciones
GO

CREATE PROCEDURE ActualizarVentasProductosReemplazoDevoluciones
@NumeroAgencia					INT,
@NumeroVentaProductosReemDevo	INT,
@CodigoEstadoReemplazoDevo		CHAR(1),
@CodigoUsuario					INT,
@FechaHoraSolicitudReemDevo		DATE,
@ObservacionesReemDevo			TEXT
AS
BEGIN
	UPDATE 	dbo.VentasProductosReemplazoDevoluciones
	SET
		CodigoEstadoReemplazoDevo	= @CodigoEstadoReemplazoDevo,		
		CodigoUsuario				= @CodigoUsuario,
		FechaHoraSolicitudReemDevo	= @FechaHoraSolicitudReemDevo,
		ObservacionesReemDevo		= @ObservacionesReemDevo
	WHERE NumeroAgencia = @NumeroAgencia
		 AND NumeroVentaProductosReemDevo = @NumeroVentaProductosReemDevo
END
GO

DROP PROCEDURE EliminarVentasProductosReemplazoDevoluciones
GO

CREATE PROCEDURE EliminarVentasProductosReemplazoDevoluciones
@NumeroAgencia					INT,
@NumeroVentaProductosReemDevo	INT
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductosReemplazoDevoluciones
	WHERE NumeroAgencia = @NumeroAgencia
		 AND NumeroVentaProductosReemDevo = @NumeroVentaProductosReemDevo
END
GO

DROP PROCEDURE ListarVentasProductosReemplazoDevoluciones
GO

CREATE PROCEDURE ListarVentasProductosReemplazoDevoluciones
@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProductosReemDevo, CodigoEstadoReemplazoDevo, CodigoUsuario, FechaHoraSolicitudReemDevo, ObservacionesReemDevo, NumeroReemplazo
	FROM dbo.VentasProductosReemplazoDevoluciones
	WHERE NumeroAgencia = @NumeroAgencia
	ORDER BY NumeroAgencia, NumeroVentaProductosReemDevo
END
GO


DROP PROCEDURE ObtenerVentasProductosReemplazoDevolucion
GO

CREATE PROCEDURE ObtenerVentasProductosReemplazoDevolucion
@NumeroAgencia					INT,
@NumeroVentaProductosReemDevo	INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProductosReemDevo, CodigoEstadoReemplazoDevo, CodigoUsuario, FechaHoraSolicitudReemDevo, ObservacionesReemDevo, NumeroReemplazo
	FROM dbo.VentasProductosReemplazoDevoluciones
	WHERE NumeroAgencia = @NumeroAgencia
		 AND NumeroVentaProductosReemDevo = @NumeroVentaProductosReemDevo
END
GO


DROP PROCEDURE FinalizarAnularVentasProductosReemplazoDevolucion
GO

CREATE PROCEDURE FinalizarAnularVentasProductosReemplazoDevolucion
@NumeroAgencia					INT,
@NumeroVentaProductosReemDevo	INT,
@CodigoEstadoReemplazoDevo		CHAR(1),
@FechaHoraSolicitudReemDevo		DATE

AS
BEGIN
	IF(@FechaHoraSolicitudReemDevo IS NULL)
	BEGIN
		SELECT @FechaHoraSolicitudReemDevo = FechaHoraSolicitudReemDevo
		FROM VentasProductosReemplazoDevoluciones
		WHERE NumeroAgencia = @NumeroAgencia AND NumeroVentaProductosReemDevo = @NumeroVentaProductosReemDevo
	END
	
	UPDATE 	dbo.VentasProductosReemplazoDevoluciones
	SET
		CodigoEstadoReemplazoDevo	= @CodigoEstadoReemplazoDevo,
		FechaHoraSolicitudReemDevo	= @FechaHoraSolicitudReemDevo		
	WHERE NumeroAgencia = @NumeroAgencia
		 AND NumeroVentaProductosReemDevo = @NumeroVentaProductosReemDevo
END
GO


DROP PROCEDURE ObtenerVentasProductosReemplazoDevolucion_paraReemplazo
GO

CREATE PROCEDURE ObtenerVentasProductosReemplazoDevolucion_paraReemplazo
@NumeroAgencia					INT,
@NumeroVentaProductosReemDevo	INT,
@NumeroReemplazo				INT	
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProductosReemDevo, CodigoEstadoReemplazoDevo, CodigoUsuario, FechaHoraSolicitudReemDevo, ObservacionesReemDevo, NumeroReemplazo
	FROM dbo.VentasProductosReemplazoDevoluciones
	WHERE NumeroAgencia = @NumeroAgencia
		 AND NumeroVentaProductosReemDevo = @NumeroVentaProductosReemDevo
		 AND NumeroReemplazo = @NumeroReemplazo
END
GO


DROP PROCEDURE ObtenerProductosDevolucionesReemplazoDisponbiles
GO

CREATE PROCEDURE ObtenerProductosDevolucionesReemplazoDisponbiles
	@NumeroAgencia		INT,
	@NumeroDevolucion	INT,
	@NumeroReemplazo	INT
AS
BEGIN
	SELECT VPDD.CodigoProducto, dbo.ObtenerNombreProducto(VPDD.CodigoProducto) AS NombreProducto, VPDD.PrecioUnitarioDevolucion * VPDD.CantidadDevuelta AS PrecioTotal, 'D' as TipoTransaccion
	FROM VentasProductosDevolucionesDetalle VPDD
	WHERE VPDD.CodigoProducto NOT IN( SELECT VPRDD.CodigoProductoDevolucion FROM VentasProductosReemplazoDevolucionesDetalle VPRDD 
									  WHERE VPRDD.NumeroDevolucion = @NumeroDevolucion AND VPRDD.NumeroAgenciaDevolucion = @NumeroAgencia)
	AND VPDD.NumeroAgencia = @NumeroAgencia AND VPDD.NumeroDevolucion = @NumeroDevolucion
	UNION
	SELECT VPRD.CodigoProducto, dbo.ObtenerNombreProducto(VPRD.CodigoProducto) AS NombreProducto, VPRD.PrecioUnitarioReemplazo * VPRD.CantidadDevuelta AS PrecioTotal, 'R' as TipoTransaccion
	FROM VentasProductosReemplazoDetalle VPRD
	WHERE VPRD.CodigoProducto NOT IN (SELECT VPRDD2.CodigoProductoReemplazo FROM VentasProductosReemplazoDevolucionesDetalle VPRDD2
									  WHERE VPRDD2.NumeroAgenciaReemplazo = @NumeroAgencia AND VPRDD2.NumeroReemplazo = @NumeroReemplazo)
	AND VPRD.NumeroAgencia = @NumeroAgencia AND VPRD.NumeroReemplazo = @NumeroReemplazo
END


--EXEC ObtenerProductosDevolucionesReemplazoDisponbiles 1,5,2

DROP PROCEDURE ReporteVentasProductosReemplazoDevolucion
GO

CREATE PROCEDURE ReporteVentasProductosReemplazoDevolucion
@NumeroAgencia					INT,
@NumeroVentaProductosReemDevo	INT
AS
BEGIN
	SELECT VPD.NumeroAgencia, VPD.NumeroVentaProductosReemDevo, ISNULL(U.Nombres,' ') + ' ' + ISNULL(U.Paterno,' ') + ' ' + ISNULL(U.Materno,' ') as UsuarioResponsable, VPD.FechaHoraSolicitudReemDevo, VPD.ObservacionesReemDevo, (select SUM(PrecioTotal) from CardinalidadPrecioDevoluciones cd where cd.NumeroAgencia = @NumeroAgencia and cd.NumeroVentaProductosReemDevo =@NumeroVentaProductosReemDevo) as TotalPago
	FROM VentasProductosReemplazoDevoluciones VPD INNER JOIN Usuarios U ON VPD.CodigoUsuario = U.CodigoUsuario
	WHERE VPD.NumeroAgencia = @NumeroAgencia AND VPD.NumeroVentaProductosReemDevo = @NumeroVentaProductosReemDevo	
END


--exec ReporteVentasProductosReemplazoDevolucion 1, 1

--select SUM(PrecioTotal) from CardinalidadPrecioDevoluciones cd where cd.NumeroAgencia = 1 and cd.NumeroVentaProductosReemDevo =1
--select * from CardinalidadPrecioDevoluciones cd where cd.NumeroAgencia = 1 and cd.NumeroVentaProductosReemDevo =1