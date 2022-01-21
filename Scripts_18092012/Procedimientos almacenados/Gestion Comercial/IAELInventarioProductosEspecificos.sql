USE DOBLONES20
GO

DROP PROCEDURE InsertarInventarioProductoEspecifico
GO

CREATE PROCEDURE InsertarInventarioProductoEspecifico
	@NumeroAgencia				INT,
	@CodigoProducto				CHAR(15),
	@CodigoProductoEspecifico	CHAR(30),
	@TiempoGarantiaPECompra		INT,
	@FechaHoraVencimientoPE		DATETIME,
	@CodigoFormaAdquisicion		CHAR(1),
	@CodigoEstado				CHAR(1)
AS
BEGIN
	INSERT INTO dbo.InventariosProductosEspecificos (NumeroAgencia, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPECompra, FechaHoraVencimientoPE, CodigoFormaAdquisicion, CodigoEstado)
	VALUES (@NumeroAgencia,@CodigoProducto, @CodigoProductoEspecifico, @TiempoGarantiaPECompra, @FechaHoraVencimientoPE, @CodigoFormaAdquisicion, @CodigoEstado)
END
GO

DROP PROCEDURE ActualizarInventarioProductoEspecifico
GO

CREATE PROCEDURE ActualizarInventarioProductoEspecifico
	@NumeroAgencia				INT,
	@CodigoProducto				CHAR(15),
	@CodigoProductoEspecifico	CHAR(30),
	@TiempoGarantiaPECompra		INT,
	@FechaHoraVencimientoPE		DATETIME,
	@CodigoFormaAdquisicion		CHAR(1),
	@CodigoEstado				CHAR(1)
AS
BEGIN
	UPDATE 	dbo.InventariosProductosEspecificos
	SET		
		TiempoGarantiaPECompra	= @TiempoGarantiaPECompra,
		FechaHoraVencimientoPE	= @FechaHoraVencimientoPE,
		CodigoFormaAdquisicion	= @CodigoFormaAdquisicion,
		CodigoEstado			= @CodigoEstado
	WHERE (CodigoProducto = @CodigoProducto) AND (CodigoProductoEspecifico = @CodigoProductoEspecifico) AND (NumeroAgencia = @NumeroAgencia)
END
GO

DROP PROCEDURE EliminarInventarioProductoEspecifico
GO

CREATE PROCEDURE EliminarInventarioProductoEspecifico
	@NumeroAgencia				INT,
	@CodigoProducto				CHAR(15),
	@CodigoProductoEspecifico	CHAR(30)
AS
BEGIN
	DELETE 
	FROM dbo.InventariosProductosEspecificos
	WHERE (CodigoProducto = @CodigoProducto) AND (CodigoProductoEspecifico = @CodigoProductoEspecifico) AND (NumeroAgencia = @NumeroAgencia)
END
GO

DROP PROCEDURE ListarInventarioProductosEspecificos
GO

CREATE PROCEDURE ListarInventarioProductosEspecificos
AS
BEGIN
	SELECT NumeroAgencia, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPECompra, FechaHoraVencimientoPE, CodigoFormaAdquisicion, CodigoEstado 
	FROM dbo.InventariosProductosEspecificos
	ORDER BY CodigoProducto, CodigoProductoEspecifico
END
GO

DROP PROCEDURE ObtenerInventarioProductoEspecifico
GO

CREATE PROCEDURE ObtenerInventarioProductoEspecifico
	@NumeroAgencia				INT,
	@CodigoProducto				CHAR(15),
	@CodigoProductoEspecifico	CHAR(30)
AS
BEGIN
	SELECT NumeroAgencia, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPECompra, FechaHoraVencimientoPE, CodigoFormaAdquisicion, CodigoEstado 
	FROM dbo.InventariosProductosEspecificos
	WHERE (CodigoProducto = @CodigoProducto) AND (CodigoProductoEspecifico = @CodigoProductoEspecifico) AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE ListarInventarioProductosEspecificosPorProducto
GO

CREATE PROCEDURE ListarInventarioProductosEspecificosPorProducto
	@NumeroAgencia				INT,
	@CodigoProducto				CHAR(15)
AS
BEGIN
	SELECT CodigoProductoEspecifico AS [Código Específico], TiempoGarantiaPECompra AS [Tiempo de Garantía] , FechaHoraVencimientoPE [Fecha de Vencimiento], case (CodigoFormaAdquisicion) when 'C' then 'COMPRADO'  WHEN 'P'  THEN 'PRESTADO' WHEN 'A' THEN 'AGREGADO' WHEN 'D' THEN 'DONADO' WHEN 'T' THEN 'TRANSFERIDO' END AS [Forma de Adquisición], CASE(CodigoEstado ) WHEN 'A' THEN 'DISPONIBLE' WHEN 'B' THEN 'DE BAJA' WHEN 'R' THEN 'EN MANTIMIENTO' WHEN 'V' THEN 'VENDIDO' WHEN 'T' THEN 'TRANSFERIDO' END AS [Estado Actual]
	FROM dbo.InventariosProductosEspecificos
	WHERE (CodigoProducto = @CodigoProducto) AND (NumeroAgencia = @NumeroAgencia)
	ORDER BY CodigoProducto, CodigoProductoEspecifico
END
GO