USE DOBLONES20
GO

DROP PROCEDURE InsertarVentasProductosReemplazoDevolucionesDetalle
GO

CREATE PROCEDURE InsertarVentasProductosReemplazoDevolucionesDetalle
@NumeroAgencia					INT,
@NumeroVentaProductosReemDevo	INT,
@NumeroAgenciaDevolucion		INT,
@NumeroDevolucion				INT,
@CodigoProductoDevolucion		CHAR(15),
@MontoTotalDevolucion			DECIMAL(10,2),
@NumeroAgenciaReemplazo			INT,
@NumeroReemplazo				INT,
@CodigoProductoReemplazo		CHAR(15),
@MontoTotalReemplazo			DECIMAL(10,2)
AS
BEGIN
	INSERT INTO dbo.VentasProductosReemplazoDevolucionesDetalle (NumeroAgencia, NumeroVentaProductosReemDevo, NumeroAgenciaDevolucion, NumeroDevolucion, CodigoProductoDevolucion, MontoTotalDevolucion, NumeroAgenciaReemplazo, NumeroReemplazo, CodigoProductoReemplazo, MontoTotalReemplazo)
	VALUES (@NumeroAgencia, @NumeroVentaProductosReemDevo, @NumeroAgenciaDevolucion, @NumeroDevolucion, @CodigoProductoDevolucion, @MontoTotalDevolucion, @NumeroAgenciaReemplazo, @NumeroReemplazo, @CodigoProductoReemplazo, @MontoTotalReemplazo)
END
GO

DROP PROCEDURE ActualizarVentasProductosReemplazoDevolucionesDetalle
GO

CREATE PROCEDURE ActualizarVentasProductosReemplazoDevolucionesDetalle
@NumeroAgencia					INT,
@NumeroVentaProductosReemDevo	INT,
@NumeroAgenciaDevolucion		INT,
@NumeroDevolucion				INT,
@CodigoProductoDevolucion		CHAR(15),
@MontoTotalDevolucion			DECIMAL(10,2),
@NumeroAgenciaReemplazo			INT,
@NumeroReemplazo				INT,
@CodigoProductoReemplazo		CHAR(15),
@MontoTotalReemplazo			DECIMAL(10,2)
AS
BEGIN
	UPDATE 	dbo.VentasProductosReemplazoDevolucionesDetalle
	SET		
		MontoTotalDevolucion = @MontoTotalDevolucion,
		MontoTotalReemplazo  = @MontoTotalReemplazo
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProductosReemDevo =@NumeroVentaProductosReemDevo
	AND NumeroAgenciaDevolucion = @NumeroAgenciaDevolucion
	AND NumeroDevolucion = @NumeroDevolucion
	AND CodigoProductoDevolucion = @CodigoProductoDevolucion
	AND NumeroAgenciaReemplazo = @NumeroAgenciaReemplazo
	AND NumeroReemplazo = @NumeroReemplazo
	AND CodigoProductoReemplazo = @CodigoProductoReemplazo	
END
GO

DROP PROCEDURE EliminarVentasProductosReemplazoDevolucionesDetalle
GO

CREATE PROCEDURE EliminarVentasProductosReemplazoDevolucionesDetalle
@NumeroAgencia					INT,
@NumeroVentaProductosReemDevo	INT,
@NumeroAgenciaDevolucion		INT,
@NumeroDevolucion				INT,
@CodigoProductoDevolucion		CHAR(15),
@NumeroAgenciaReemplazo			INT,
@NumeroReemplazo				INT,
@CodigoProductoReemplazo		CHAR(15)
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductosReemplazoDevolucionesDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProductosReemDevo =@NumeroVentaProductosReemDevo
	AND NumeroAgenciaDevolucion = @NumeroAgenciaDevolucion
	AND NumeroDevolucion = @NumeroDevolucion
	AND CodigoProductoDevolucion = @CodigoProductoDevolucion
	AND NumeroAgenciaReemplazo = @NumeroAgenciaReemplazo
	AND NumeroReemplazo = @NumeroReemplazo
	AND CodigoProductoReemplazo = @CodigoProductoReemplazo	
END
GO

DROP PROCEDURE ListarVentasProductosReemplazoDevolucionesDetalle
GO

CREATE PROCEDURE ListarVentasProductosReemplazoDevolucionesDetalle
@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProductosReemDevo, NumeroAgenciaDevolucion, NumeroDevolucion, CodigoProductoDevolucion, MontoTotalDevolucion, NumeroAgenciaReemplazo, NumeroReemplazo, CodigoProductoReemplazo, MontoTotalReemplazo
	FROM dbo.VentasProductosReemplazoDevolucionesDetalle
	WHERE NumeroAgencia = @NumeroAgencia
END
GO


DROP PROCEDURE ObtenerVentaProductoReemplazoDevolucionDetalle
GO

CREATE PROCEDURE ObtenerVentaProductoReemplazoDevolucionDetalle
@NumeroAgencia					INT,
@NumeroVentaProductosReemDevo	INT,
@NumeroAgenciaDevolucion		INT,
@NumeroDevolucion				INT,
@CodigoProductoDevolucion		CHAR(15),
@NumeroAgenciaReemplazo			INT,
@NumeroReemplazo				INT,
@CodigoProductoReemplazo		CHAR(15)
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProductosReemDevo, NumeroAgenciaDevolucion, NumeroDevolucion, CodigoProductoDevolucion, MontoTotalDevolucion, NumeroAgenciaReemplazo, NumeroReemplazo, CodigoProductoReemplazo, MontoTotalReemplazo
	FROM dbo.VentasProductosReemplazoDevolucionesDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProductosReemDevo =@NumeroVentaProductosReemDevo
	AND NumeroAgenciaDevolucion = @NumeroAgenciaDevolucion
	AND NumeroDevolucion = @NumeroDevolucion
	AND CodigoProductoDevolucion = @CodigoProductoDevolucion
	AND NumeroAgenciaReemplazo = @NumeroAgenciaReemplazo
	AND NumeroReemplazo = @NumeroReemplazo
	AND CodigoProductoReemplazo = @CodigoProductoReemplazo
END
GO


DROP PROCEDURE ListarVentasProductosReemplazoDevolucionesDetalleParaReemplazoDevoluciones
GO

CREATE PROCEDURE ListarVentasProductosReemplazoDevolucionesDetalleParaReemplazoDevoluciones
@NumeroAgencia		INT,
@NumeroVentaProductosReemDevo	INT
AS
BEGIN
	SELECT CodigoProductoDevolucion, dbo.ObtenerNombreProducto(CodigoProductoDevolucion) as NombreProductoDevolucion, MontoTotalDevolucion, CodigoProductoReemplazo, dbo.ObtenerNombreProducto(CodigoProductoReemplazo) AS NombreProductoReemplazo, MontoTotalReemplazo
	FROM dbo.VentasProductosReemplazoDevolucionesDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProductosReemDevo = @NumeroVentaProductosReemDevo	
END
GO

--exec ListarVentasProductosReemplazoDevolucionesDetalleParaReemplazoDevoluciones 1,2