USE DOBLONES20
GO

DROP PROCEDURE InsertarVentaProductoEspecificoReemDevo
GO

CREATE PROCEDURE InsertarVentaProductoEspecificoReemDevo
@NumeroAgencia					INT,
@NumeroReemDevo					INT,
@CodigoMotivoReemDevo			INT,
@CodigoProducto					CHAR(15),
@CodigoProductoEspeDevo			CHAR(20),
@CodigoProductoEspeCambio		CHAR(20),
@TiempoGarantiaPE				INT,
@FechaHoraVencimientoPE			DATETIME,
@PrecioUnitarioPECambio			DECIMAL(10,2),
@MontoDevolucion				DECIMAL(10,2),
@CodigoTipoReemDevo				CHAR(1),
@FechaHoraReemDevoCambio		DATETIME,
@ObservacionesReemDevoCambio	TEXT
AS	
BEGIN
	INSERT INTO dbo.VentasProductosEspecificosReemDevo(NumeroAgencia, NumeroReemDevo, CodigoMotivoReemDevo, CodigoProducto, CodigoProductoEspeDevo, CodigoProductoEspeCambio, TiempoGarantiaPE, FechaHoraVencimientoPE, PrecioUnitarioPECambio, MontoDevolucion, CodigoTipoReemDevo, FechaHoraReemDevoCambio, ObservacionesReemDevoCambio)
	VALUES (@NumeroAgencia, @NumeroReemDevo, @CodigoMotivoReemDevo, @CodigoProducto, @CodigoProductoEspeDevo, @CodigoProductoEspeCambio, @TiempoGarantiaPE, @FechaHoraVencimientoPE, @PrecioUnitarioPECambio, @MontoDevolucion, @CodigoTipoReemDevo, @FechaHoraReemDevoCambio, @ObservacionesReemDevoCambio)
END
GO

DROP PROCEDURE ActualizarVentaProductoEspecificoReemDevo
GO
CREATE PROCEDURE ActualizarVentaProductoEspecificoReemDevo
@NumeroAgencia					INT,
@NumeroReemDevo					INT,
@CodigoMotivoReemDevo			INT,
@CodigoProducto					CHAR(15),
@CodigoProductoEspeDevo			CHAR(20),
@CodigoProductoEspeCambio		CHAR(20),
@TiempoGarantiaPE				INT,
@FechaHoraVencimientoPE			DATETIME,
@PrecioUnitarioPECambio			DECIMAL(10,2),
@MontoDevolucion				DECIMAL(10,2),
@CodigoTipoReemDevo				CHAR(1),
@FechaHoraReemDevoCambio		DATETIME,
@ObservacionesReemDevoCambio	TEXT
AS
BEGIN
	UPDATE 	dbo.VentasProductosEspecificosReemDevo
	SET	
		CodigoProductoEspeCambio	= @CodigoProductoEspeCambio,
		TiempoGarantiaPE			= @TiempoGarantiaPE,
		FechaHoraVencimientoPE		= @FechaHoraVencimientoPE,
		PrecioUnitarioPECambio		= @PrecioUnitarioPECambio,
		MontoDevolucion				= @MontoDevolucion,
		CodigoTipoReemDevo			= @CodigoTipoReemDevo,
		FechaHoraReemDevoCambio		= @FechaHoraReemDevoCambio,
		ObservacionesReemDevoCambio	= @ObservacionesReemDevoCambio
	WHERE (NumeroAgencia = @NumeroAgencia)
	AND (NumeroReemDevo				= @NumeroReemDevo)
	AND (CodigoMotivoReemDevo		= @CodigoMotivoReemDevo)
	AND (CodigoProducto				= @CodigoProducto)
	AND (CodigoProductoEspeDevo		= @CodigoProductoEspeDevo)
	AND (CodigoProductoEspeCambio	= @CodigoProductoEspeCambio)
END
GO

DROP PROCEDURE EliminarVentaProductoEspecificoReemDevo
GO

CREATE PROCEDURE EliminarVentaProductoEspecificoReemDevo
	@NumeroAgencia				INT,
	@NumeroReemDevo				INT,
	@CodigoMotivoReemDevo		INT,
	@CodigoProducto				CHAR(15),
	@CodigoProductoEspeDevo		CHAR(20),
	@CodigoProductoEspeCambio	CHAR(20)
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductosEspecificosReemDevo
	WHERE	(NumeroAgencia = @NumeroAgencia)
	AND (NumeroReemDevo				= @NumeroReemDevo)
	AND (CodigoMotivoReemDevo		= @CodigoMotivoReemDevo)
	AND (CodigoProducto				= @CodigoProducto)
	AND (CodigoProductoEspeDevo		= @CodigoProductoEspeDevo)
	AND (CodigoProductoEspeCambio	= @CodigoProductoEspeCambio)	
END
GO

DROP PROCEDURE ListarVentasProductosEspecificosReemDevo
GO

CREATE PROCEDURE ListarVentasProductosEspecificosReemDevo
AS
BEGIN
	SELECT NumeroAgencia, NumeroReemDevo, CodigoMotivoReemDevo, CodigoProducto, CodigoProductoEspeDevo, CodigoProductoEspeCambio, TiempoGarantiaPE, FechaHoraVencimientoPE, PrecioUnitarioPECambio, MontoDevolucion, CodigoTipoReemDevo, FechaHoraReemDevoCambio, ObservacionesReemDevoCambio
	FROM dbo.VentasProductosEspecificosReemDevo
	ORDER BY NumeroReemDevo, CodigoMotivoReemDevo, CodigoProducto, CodigoProductoEspeDevo, CodigoProductoEspeCambio
END
GO

DROP PROCEDURE ObtenerVentaProductoEspecificoReemDevo
GO

CREATE PROCEDURE ObtenerVentaProductoEspecificoReemDevo
	@NumeroAgencia				INT,
	@NumeroReemDevo				INT,
	@CodigoMotivoReemDevo		INT,
	@CodigoProducto				CHAR(15),
	@CodigoProductoEspeDevo		CHAR(20),
	@CodigoProductoEspeCambio	CHAR(20)
AS
BEGIN
	SELECT NumeroAgencia, NumeroReemDevo, CodigoMotivoReemDevo, CodigoProducto, CodigoProductoEspeDevo, CodigoProductoEspeCambio, TiempoGarantiaPE, FechaHoraVencimientoPE, PrecioUnitarioPECambio, MontoDevolucion, CodigoTipoReemDevo, FechaHoraReemDevoCambio, ObservacionesReemDevoCambio
	FROM dbo.VentasProductosEspecificosReemDevo
	WHERE	(NumeroReemDevo				= @NumeroReemDevo)
		AND (CodigoMotivoReemDevo		= @CodigoMotivoReemDevo)
		AND (CodigoProducto				= @CodigoProducto)
		AND (CodigoProductoEspeDevo		= @CodigoProductoEspeDevo)
		AND (CodigoProductoEspeCambio	= @CodigoProductoEspeCambio)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO