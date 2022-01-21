USE DOBLONES20
GO



DROP PROCEDURE InsertarCompraProductoEspecificoReemDevoCambio
GO
CREATE PROCEDURE InsertarCompraProductoEspecificoReemDevoCambio
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
	INSERT INTO dbo.ComprasProductosEspecificosReemDevoCambios(NumeroAgencia,NumeroReemDevo,CodigoMotivoReemDevo,CodigoProducto,CodigoProductoEspeDevo,CodigoProductoEspeCambio,TiempoGarantiaPE,FechaHoraVencimientoPE,PrecioUnitarioPECambio,MontoDevolucion,CodigoTipoReemDevo,FechaHoraReemDevoCambio,ObservacionesReemDevoCambio)
	VALUES (@NumeroAgencia,@NumeroReemDevo,@CodigoMotivoReemDevo,@CodigoProducto,@CodigoProductoEspeDevo,@CodigoProductoEspeCambio,@TiempoGarantiaPE,@FechaHoraVencimientoPE,@PrecioUnitarioPECambio,@MontoDevolucion,@CodigoTipoReemDevo,@FechaHoraReemDevoCambio,@ObservacionesReemDevoCambio)
END
GO



DROP PROCEDURE ActualizarCompraProductoEspecificoReemDevoCambio
GO
CREATE PROCEDURE ActualizarCompraProductoEspecificoReemDevoCambio
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
	UPDATE 	dbo.ComprasProductosEspecificosReemDevoCambios
	SET		
		CodigoProducto				= @CodigoProducto,
		TiempoGarantiaPE			= @TiempoGarantiaPE,
		FechaHoraVencimientoPE		= @FechaHoraVencimientoPE,
		PrecioUnitarioPECambio		= @PrecioUnitarioPECambio,
		MontoDevolucion				= @MontoDevolucion,
		CodigoTipoReemDevo			= @CodigoTipoReemDevo,
		FechaHoraReemDevoCambio		= @FechaHoraReemDevoCambio,
		ObservacionesReemDevoCambio	=@ObservacionesReemDevoCambio
	WHERE		(NumeroReemDevo				= @NumeroReemDevo) 
			AND (CodigoMotivoReemDevo		= @CodigoMotivoReemDevo)			
			AND (CodigoProductoEspeDevo		= @CodigoProductoEspeDevo)
			AND (CodigoProductoEspeCambio	= @CodigoProductoEspeCambio)
			AND (NumeroAgencia				= @NumeroAgencia)
END
GO



DROP PROCEDURE EliminarCompraProductoEspecificoReemDevoCambio
GO
CREATE PROCEDURE EliminarCompraProductoEspecificoReemDevoCambio
	@NumeroAgencia					INT,
	@NumeroReemDevo					INT,
	@CodigoMotivoReemDevo			INT,
	@CodigoProducto					CHAR(15),
	@CodigoProductoEspeDevo			CHAR(20),
	@CodigoProductoEspeCambio		CHAR(20)
AS
BEGIN
	DELETE 
	FROM dbo.ComprasProductosEspecificosReemDevoCambios
	WHERE		(NumeroReemDevo				= @NumeroReemDevo) 
			AND (CodigoMotivoReemDevo		= @CodigoMotivoReemDevo)			
			AND (CodigoProductoEspeDevo		= @CodigoProductoEspeDevo)
			AND (CodigoProductoEspeCambio	= @CodigoProductoEspeCambio)
			AND (NumeroAgencia				= @NumeroAgencia)
END
GO



DROP PROCEDURE ListarComprasProductosEspecificosReemDevoCambios
GO
CREATE PROCEDURE ListarComprasProductosEspecificosReemDevoCambios
	@NumeroAgencia	INT
AS
BEGIN
	SELECT NumeroAgencia,NumeroReemDevo,CodigoMotivoReemDevo,CodigoProducto,CodigoProductoEspeDevo,CodigoProductoEspeCambio,TiempoGarantiaPE,FechaHoraVencimientoPE,PrecioUnitarioPECambio,MontoDevolucion,CodigoTipoReemDevo,FechaHoraReemDevoCambio,ObservacionesReemDevoCambio
	FROM dbo.ComprasProductosEspecificosReemDevoCambios
	WHERE (NumeroAgencia= @NumeroAgencia)
	ORDER BY NumeroReemDevo, CodigoMotivoReemDevo, CodigoProducto, CodigoProductoEspeDevo, CodigoProductoEspeCambio
END
GO



DROP PROCEDURE ObtenerCompraProductoEspecificoReemDevoCambio
GO
CREATE PROCEDURE ObtenerCompraProductoEspecificoReemDevoCambio
	@NumeroAgencia					INT,
	@NumeroReemDevo					INT,
	@CodigoMotivoReemDevo			INT,
	@CodigoProducto					CHAR(15),
	@CodigoProductoEspeDevo			CHAR(20),
	@CodigoProductoEspeCambio		CHAR(20)
AS
BEGIN
	SELECT NumeroAgencia,NumeroReemDevo,CodigoMotivoReemDevo,CodigoProducto,CodigoProductoEspeDevo,CodigoProductoEspeCambio,TiempoGarantiaPE,FechaHoraVencimientoPE,PrecioUnitarioPECambio,MontoDevolucion,CodigoTipoReemDevo,FechaHoraReemDevoCambio,ObservacionesReemDevoCambio
	FROM dbo.ComprasProductosEspecificosReemDevoCambios
	WHERE		(NumeroReemDevo				= @NumeroReemDevo) 
			AND (CodigoMotivoReemDevo		= @CodigoMotivoReemDevo)			
			AND (CodigoProductoEspeDevo		= @CodigoProductoEspeDevo)
			AND (CodigoProductoEspeCambio	= @CodigoProductoEspeCambio)
			AND (NumeroAgencia				= @NumeroAgencia)
END
GO



--DROP PROCEDURE ObtenerComprasProductosEspecificosReemDevoCambios
--GO
--CREATE PROCEDURE ObtenerComprasProductosEspecificosReemDevoCambios	
--AS
--BEGIN
--	SELECT NumeroAgencia,NumeroReemDevo,CodigoMotivoReemDevo,CodigoProducto,CodigoProductoEspeDevo,CodigoProductoEspeCambio,TiempoGarantiaPE,FechaHoraVencimientoPE,PrecioUnitarioPECambio,MontoDevolucion,CodigoTipoReemDevo,FechaHoraReemDevoCambio,ObservacionesReemDevoCambio
--	FROM dbo.ComprasProductosEspecificosReemDevoCambios	
--END
--GO

