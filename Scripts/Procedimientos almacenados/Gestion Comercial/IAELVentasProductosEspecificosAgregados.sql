USE DOBLONES20
GO

DROP PROCEDURE InsertarVentaProductoEspecificoAgregado
GO

CREATE PROCEDURE InsertarVentaProductoEspecificoAgregado
@NumeroAgencia				INT,
@NumeroVentaProducto		INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30),
@CodigoTipoAgregado		CHAR(1),
@TiempoGarantiaPE			INT,
@FechaHoraVencimientoPE		DATETIME,
@PrecioUnitario				DECIMAL(10,2)
AS	
BEGIN
	INSERT INTO dbo.VentasProductosEspecificosAgregados(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoProductoEspecifico, CodigoTipoAgregado, TiempoGarantiaPE, FechaHoraVencimientoPE, PrecioUnitario)
	VALUES (@NumeroAgencia, @NumeroVentaProducto, @CodigoProducto, @CodigoProductoEspecifico, @CodigoTipoAgregado, @TiempoGarantiaPE, @FechaHoraVencimientoPE, @PrecioUnitario)
END
GO

DROP PROCEDURE ActualizarVentaProductoEspecificoAgregado
GO

CREATE PROCEDURE ActualizarVentaProductoEspecificoAgregado
@NumeroAgencia				INT,
@NumeroVentaProducto		INT,
@CodigoProducto				CHAR(15),
@CodigoProductoEspecifico	CHAR(30),
@CodigoTipoAgregado			CHAR(1),
@TiempoGarantiaPE			INT,
@FechaHoraVencimientoPE		DATETIME,
@PrecioUnitario				DECIMAL(10,2)
AS
BEGIN
	UPDATE 	dbo.VentasProductosEspecificosAgregados
	SET		
		CodigoProductoEspecifico	= @CodigoProductoEspecifico,
		CodigoTipoAgregado			= @CodigoTipoAgregado,
		TiempoGarantiaPE			= @TiempoGarantiaPE,
		FechaHoraVencimientoPE		= @FechaHoraVencimientoPE,
		PrecioUnitario				= @PrecioUnitario
	WHERE (NumeroAgencia = @NumeroAgencia) 
	AND (NumeroVentaProducto = @NumeroVentaProducto) 
	AND (CodigoProducto = @CodigoProducto)
	AND (CodigoTipoAgregado = @CodigoTipoAgregado)
END
GO

DROP PROCEDURE EliminarVentaProductoEspecificoAgregado
GO

CREATE PROCEDURE EliminarVentaProductoEspecificoAgregado
@NumeroAgencia				INT,
@NumeroVentaProducto		INT,
@CodigoProducto				CHAR(15),
@CodigoTipoAgregado			CHAR(1)
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductosEspecificosAgregados
	WHERE (NumeroAgencia = @NumeroAgencia) 
	AND	(NumeroVentaProducto = @NumeroVentaProducto) 
	AND (CodigoProducto = @CodigoProducto)
	AND (CodigoTipoAgregado = @CodigoTipoAgregado)
END
GO


DROP PROCEDURE ListarVentasProductosEspecificosAgregados
GO

CREATE PROCEDURE ListarVentasProductosEspecificosAgregados
	@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoProductoEspecifico, CodigoTipoAgregado, TiempoGarantiaPE, FechaHoraVencimientoPE, PrecioUnitario	
	FROM dbo.VentasProductosEspecificosAgregados
	WHERE NumeroAgencia = @NumeroAgencia
	ORDER BY NumeroVentaProducto, CodigoProducto, CodigoProductoEspecifico
END
GO

DROP PROCEDURE ObtenerVentaProductoEspecificoAgregado
GO

CREATE PROCEDURE ObtenerVentaProductoEspecificoAgregado
@NumeroAgencia				INT,
@NumeroVentaProducto		INT,
@CodigoProducto				CHAR(15),
@CodigoTipoAgregado			CHAR(1)
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoProductoEspecifico, CodigoTipoAgregado, TiempoGarantiaPE, FechaHoraVencimientoPE, PrecioUnitario
	FROM dbo.VentasProductosEspecificosAgregados
	WHERE (NumeroAgencia = @NumeroAgencia) 
	AND	(NumeroVentaProducto = @NumeroVentaProducto) 
	AND (CodigoProducto = @CodigoProducto)
	AND (CodigoTipoAgregado = @CodigoTipoAgregado)
END
GO


DROP PROCEDURE ListarVentaProductoEspecificoAgregadoReporte
GO

CREATE PROCEDURE ListarVentaProductoEspecificoAgregadoReporte
@NumeroAgencia				INT,
@NumeroVentaProducto		INT
AS
BEGIN
	SELECT P.NombreProducto, VPA.CodigoProducto, VPA.CodigoProductoEspecifico, CASE (VPA.CodigoTipoAgregado) WHEN 'O' THEN 'OBSEQUIO' WHEN 'B' THEN 'BONIFICACION' WHEN 'P' THEN 'PROMOCION' WHEN 'C' THEN 'COMPENSACION' END AS CodigoTipoAgregado, VPA.TiempoGarantiaPE, VPA.FechaHoraVencimientoPE, VPA.PrecioUnitario
	FROM VentasProductosEspecificosAgregados VPA INNER JOIN Productos P ON P.CodigoProducto = VPA.CodigoProducto
	WHERE (VPA.NumeroAgencia = @NumeroAgencia) 
	AND	(VPA.NumeroVentaProducto = @NumeroVentaProducto) 
END



