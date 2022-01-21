USE DOBLONES20
GO



DROP PROCEDURE InsertarCompraProductoEspecificoAgregado
GO
CREATE PROCEDURE InsertarCompraProductoEspecificoAgregado
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoProducto				CHAR(15),
	@CodigoProductoEspecifico	CHAR(30),
	@CodigoTipoAgregado			CHAR(1),
	@TiempoGarantiaPE			INT,
	@FechaHoraVencimientoPE		DATETIME,
	@CargarAInventario			BIT,
	@PrecioUnitario				DECIMAL(10,2)
AS
BEGIN
	INSERT INTO dbo.ComprasProductosEspecificosAgregados (NumeroAgencia,NumeroCompraProducto,CodigoProducto,CodigoProductoEspecifico,CodigoTipoAgregado,TiempoGarantiaPE,FechaHoraVencimientoPE,CargarAInventario,PrecioUnitario)
	VALUES ( @NumeroAgencia,@NumeroCompraProducto,@CodigoProducto,@CodigoProductoEspecifico,@CodigoTipoAgregado,@TiempoGarantiaPE,@FechaHoraVencimientoPE,@CargarAInventario,@PrecioUnitario)
END
GO



DROP PROCEDURE ActualizarCompraProductoEspecificoAgregado
GO
CREATE PROCEDURE ActualizarCompraProductoEspecificoAgregado
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoProducto				CHAR(15),
	@CodigoProductoEspecifico	CHAR(30),
	@CodigoTipoAgregado			CHAR(1),
	@TiempoGarantiaPE			INT,
	@FechaHoraVencimientoPE		DATETIME,
	@CargarAInventario			BIT,
	@PrecioUnitario				DECIMAL(10,2)	
AS
BEGIN
	UPDATE 	dbo.ComprasProductosEspecificosAgregados
	SET		
		CodigoProductoEspecifico	= @CodigoProductoEspecifico,
		CodigoTipoAgregado			= @CodigoTipoAgregado,
		TiempoGarantiaPE			= @TiempoGarantiaPE,
		FechaHoraVencimientoPE		= @FechaHoraVencimientoPE,
		CargarAInventario			= @CargarAInventario,
		PrecioUnitario				= @PrecioUnitario
	WHERE (NumeroCompraProducto = @NumeroCompraProducto) 
		AND (CodigoProducto = @CodigoProducto)
		AND (CodigoTipoAgregado = @CodigoTipoAgregado)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE EliminarCompraProductoEspecificoAgregado
GO
CREATE PROCEDURE EliminarCompraProductoEspecificoAgregado
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoProducto				CHAR(15),
	@CodigoTipoAgregado			CHAR(1)
AS
BEGIN
	DELETE 
	FROM dbo.ComprasProductosEspecificosAgregados
	WHERE (NumeroCompraProducto = @NumeroCompraProducto) 
			AND (CodigoProducto = @CodigoProducto)
			AND (CodigoTipoAgregado = @CodigoTipoAgregado)
			AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE ListarComprasProductosEspecificosAgregados
GO
CREATE PROCEDURE ListarComprasProductosEspecificosAgregados
	@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia,NumeroCompraProducto,CodigoProducto,CodigoProductoEspecifico,CodigoTipoAgregado,TiempoGarantiaPE,FechaHoraVencimientoPE,CargarAInventario,PrecioUnitario
	FROM dbo.ComprasProductosEspecificosAgregados
	WHERE (NumeroAgencia= @NumeroAgencia)
	ORDER BY NumeroAgencia, NumeroCompraProducto, CodigoProducto, CodigoProductoEspecifico	
END
GO



DROP PROCEDURE ObtenerCompraProductoEspecificoAgregado
GO
CREATE PROCEDURE ObtenerCompraProductoEspecificoAgregado
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoProducto				CHAR(15),
	@CodigoTipoAgregado			CHAR(1)
AS
BEGIN
	SELECT NumeroAgencia,NumeroCompraProducto,CodigoProducto,CodigoProductoEspecifico,TiempoGarantiaPE,FechaHoraVencimientoPE,CargarAInventario,PrecioUnitario
	FROM dbo.ComprasProductosEspecificosAgregados
	WHERE (NumeroCompraProducto = @NumeroCompraProducto) 
			AND (CodigoProducto = @CodigoProducto)
			AND (CodigoTipoAgregado = @CodigoTipoAgregado)
			AND (NumeroAgencia = @NumeroAgencia)
END
GO

DROP PROCEDURE ListarCompraProductoEspecificoAgregadoReporte
GO

CREATE PROCEDURE ListarCompraProductoEspecificoAgregadoReporte
@NumeroAgencia				INT,
@NumeroCompraProducto		INT
AS
BEGIN
	SELECT P.NombreProducto, VPA.CodigoProducto, VPA.CodigoProductoEspecifico, CASE (VPA.CodigoTipoAgregado) WHEN 'O' THEN 'OBSEQUIO' WHEN 'B' THEN 'BONIFICACION' WHEN 'P' THEN 'PROMOCION' WHEN 'C' THEN 'COMPENSACION' END AS CodigoTipoAgregado, VPA.TiempoGarantiaPE, VPA.FechaHoraVencimientoPE, VPA.PrecioUnitario
	FROM ComprasProductosEspecificosAgregados VPA INNER JOIN Productos P ON VPA.CodigoProducto = P.CodigoProducto
	WHERE (VPA.NumeroAgencia = @NumeroAgencia) 
	AND	(VPA.NumeroCompraProducto = @NumeroCompraProducto) 
END


--DROP PROCEDURE ObtenerComprasProductosEspecificosAgregados
--GO
--CREATE PROCEDURE ObtenerComprasProductosEspecificosAgregados	
--AS
--BEGIN
--	SELECT NumeroAgencia,NumeroCompraProducto,CodigoProducto,CodigoProductoEspecifico,TiempoGarantiaPE,FechaHoraVencimientoPE,CargarAInventario,PrecioUnitario
--	FROM dbo.ComprasProductosEspecificosAgregados	
--END
--GO

