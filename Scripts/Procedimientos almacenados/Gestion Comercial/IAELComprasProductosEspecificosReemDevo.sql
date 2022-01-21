USE DOBLONES20
GO



DROP PROCEDURE InsertarCompraProductoEspecificoReemDevo
GO
CREATE PROCEDURE InsertarCompraProductoEspecificoReemDevo
	@NumeroAgencia					INT,
	@NumeroReemDevo					INT,
	@CodigoMotivoReemDevo			INT,	
	@CodigoProducto					CHAR(15),
	@CodigoProductoEspeDevo			CHAR(30),
	@CodigoProductoEspeCambio		CHAR(30),
	@TiempoGarantiaPE				INT,
	@FechaHoraVencimientoPE			DATETIME,
	@PrecioUnitarioPECambio			DECIMAL(10,2),
	@MontoDevolucion				DECIMAL(10,2),
	@CodigoTipoReemDevo				CHAR(1),
	@FechaHoraReemDevoCambio		DATETIME,
	@ObservacionesReemDevoCambio	TEXT
AS
BEGIN
	INSERT INTO dbo.ComprasProductosEspecificosReemDevo (NumeroAgencia,NumeroReemDevo,CodigoMotivoReemDevo,CodigoProducto,CodigoProductoEspeDevo,CodigoProductoEspeCambio,TiempoGarantiaPE,FechaHoraVencimientoPE,PrecioUnitarioPECambio,MontoDevolucion,CodigoTipoReemDevo,FechaHoraReemDevoCambio,ObservacionesReemDevoCambio)
	VALUES ( @NumeroAgencia,@NumeroReemDevo,@CodigoMotivoReemDevo,@CodigoProducto,@CodigoProductoEspeDevo,@CodigoProductoEspeCambio,@TiempoGarantiaPE,@FechaHoraVencimientoPE,@PrecioUnitarioPECambio,@MontoDevolucion,@CodigoTipoReemDevo,@FechaHoraReemDevoCambio,@ObservacionesReemDevoCambio)
END
GO



DROP PROCEDURE EliminarCompraProductoEspecificoReemDevo
GO
CREATE PROCEDURE EliminarCompraProductoEspecificoReemDevo
	@NumeroAgencia					INT,
	@NumeroReemDevo					INT,
	@CodigoMotivoReemDevo			INT,		
	@CodigoProductoEspeDevo			CHAR(30),
	@CodigoProductoEspeCambio		CHAR(30)
AS
BEGIN
	DELETE 
	FROM dbo.ComprasProductosEspecificosReemDevo
	WHERE		( NumeroAgencia				= @NumeroAgencia) 
			AND ( NumeroReemDevo			= @NumeroReemDevo)
			AND ( CodigoMotivoReemDevo		= @CodigoMotivoReemDevo)
			AND ( CodigoProductoEspeDevo	= @CodigoProductoEspeDevo)
			AND ( CodigoProductoEspeCambio	= @CodigoProductoEspeCambio)
END
GO



DROP PROCEDURE ActualizarCompraProductoEspecificoReemDevo
GO
CREATE PROCEDURE ActualizarCompraProductoEspecificoReemDevo
	@NumeroAgencia					INT,
	@NumeroReemDevo					INT,
	@CodigoMotivoReemDevo			INT,	
	@CodigoProducto					CHAR(15),
	@CodigoProductoEspeDevo			CHAR(30),
	@CodigoProductoEspeCambio		CHAR(30),
	@TiempoGarantiaPE				INT,
	@FechaHoraVencimientoPE			DATETIME,
	@PrecioUnitarioPECambio			DECIMAL(10,2),
	@MontoDevolucion				DECIMAL(10,2),
	@CodigoTipoReemDevo				CHAR(1),
	@FechaHoraReemDevoCambio		DATETIME,
	@ObservacionesReemDevoCambio	TEXT
AS
BEGIN
	UPDATE 	dbo.ComprasProductosEspecificosReemDevo
	SET		
		CodigoProducto				= @CodigoProducto,		
		TiempoGarantiaPE			= @TiempoGarantiaPE,
		FechaHoraVencimientoPE		= @FechaHoraVencimientoPE,
		PrecioUnitarioPECambio		= @PrecioUnitarioPECambio,
		MontoDevolucion				= @MontoDevolucion,
		CodigoTipoReemDevo			= @CodigoTipoReemDevo,
		FechaHoraReemDevoCambio		= @FechaHoraReemDevoCambio,
		ObservacionesReemDevoCambio	= @ObservacionesReemDevoCambio
	WHERE		( NumeroAgencia				= @NumeroAgencia) 
			AND ( NumeroReemDevo			= @NumeroReemDevo)
			AND ( CodigoMotivoReemDevo		= @CodigoMotivoReemDevo)
			AND ( CodigoProductoEspeDevo	= @CodigoProductoEspeDevo)
			AND ( CodigoProductoEspeCambio	= @CodigoProductoEspeCambio)
END
GO



DROP PROCEDURE ListarComprasProductosEspecificosReemDevo
GO
CREATE PROCEDURE ListarComprasProductosEspecificosReemDevo
	@NumeroAgencia	INT
AS
BEGIN
	SELECT NumeroAgencia,NumeroReemDevo,CodigoMotivoReemDevo,CodigoProducto,CodigoProductoEspeDevo, CodigoProductoEspeCambio, TiempoGarantiaPE, FechaHoraVencimientoPE,PrecioUnitarioPECambio, MontoDevolucion, CodigoTipoReemDevo, FechaHoraReemDevoCambio, ObservacionesReemDevoCambio
	FROM dbo.ComprasProductosEspecificosReemDevo
	WHERE (NumeroAgencia= @NumeroAgencia)
	ORDER BY NumeroReemDevo, CodigoMotivoReemDevo, CodigoProducto, CodigoProductoEspeDevo
END
GO






GO
DROP PROCEDURE ObtenerCompraProductoEspecificoReemDevo
GO
CREATE PROCEDURE ObtenerCompraProductoEspecificoReemDevo
	@NumeroAgencia				INT,
	@NumeroReemDevo				INT,
	@CodigoMotivoReemDevo		INT,
	@CodigoProducto				CHAR(15),
	@CodigoProductoEspeDevo		CHAR(30)
AS
BEGIN
	SELECT NumeroAgencia,NumeroReemDevo,CodigoMotivoReemDevo,CodigoProducto,CodigoProductoEspeDevo, CodigoProductoEspeCambio, TiempoGarantiaPE, FechaHoraVencimientoPE,PrecioUnitarioPECambio, MontoDevolucion, CodigoTipoReemDevo, FechaHoraReemDevoCambio, ObservacionesReemDevoCambio
	FROM dbo.ComprasProductosEspecificosReemDevo
	WHERE		( NumeroReemDevo			= @NumeroReemDevo) 
			AND ( CodigoMotivoReemDevo		= @CodigoMotivoReemDevo)
			AND ( CodigoProducto			= @CodigoProducto)
			AND ( CodigoProductoEspeDevo	= @CodigoProductoEspeDevo)
			AND ( NumeroAgencia				= @NumeroAgencia)
END

--GO
--DROP PROCEDURE ObtenerComprasProductosEspecificosReemDevo
--GO
--CREATE PROCEDURE ObtenerComprasProductosEspecificosReemDevo	

--AS
--BEGIN
--	SELECT NumeroAgencia,NumeroReemDevo,CodigoMotivoReemDevo,CodigoProducto,CodigoProductoEspeDevo
--	FROM dbo.ComprasProductosEspecificosReemDevo	

--END

