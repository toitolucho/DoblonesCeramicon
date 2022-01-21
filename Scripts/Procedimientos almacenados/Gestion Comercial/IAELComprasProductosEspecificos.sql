USE DOBLONES20
GO



DROP PROCEDURE InsertarCompraProductoEspecifico
GO
CREATE PROCEDURE InsertarCompraProductoEspecifico
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoProducto				CHAR(15),
	@CodigoProductoEspecifico	CHAR(30),
	@TiempoGarantiaPE			INT,
	@FechaHoraVencimientoPE		DATETIME,	
	@FechaHoraRecepcion			DATETIME
AS
BEGIN
	INSERT INTO dbo.ComprasProductosEspecificos (NumeroAgencia, NumeroCompraProducto, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPE, FechaHoraVencimientoPE, FechaHoraRecepcion)
	VALUES (@NumeroAgencia,@NumeroCompraProducto, @CodigoProducto, @CodigoProductoEspecifico, @TiempoGarantiaPE, @FechaHoraVencimientoPE, @FechaHoraRecepcion)
END
GO



DROP PROCEDURE ActualizarCompraProductoEspecifico
GO
CREATE PROCEDURE ActualizarCompraProductoEspecifico
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoProducto				CHAR(15),
	@CodigoProductoEspecifico	CHAR(30),
	@TiempoGarantiaPE			INT,
	@FechaHoraVencimientoPE		DATETIME,
	@FechaHoraRecepcion			DATETIME
AS
BEGIN
	UPDATE 	dbo.ComprasProductosEspecificos
	SET						
		TiempoGarantiaPE		= @TiempoGarantiaPE,
		FechaHoraVencimientoPE	= @FechaHoraVencimientoPE,
		FechaHoraRecepcion		= @FechaHoraRecepcion	
	WHERE (NumeroCompraProducto = @NumeroCompraProducto) 
			AND (CodigoProducto = @CodigoProducto)
			AND (CodigoProductoEspecifico = @CodigoProductoEspecifico)
			AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE EliminarCompraProductoEspecifico
GO
CREATE PROCEDURE EliminarCompraProductoEspecifico
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoProducto				CHAR(15),
	@CodigoProductoEspecifico	CHAR(30)
AS
BEGIN
	DELETE 
	FROM dbo.ComprasProductosEspecificos
	WHERE (NumeroCompraProducto = @NumeroCompraProducto) 
			AND (CodigoProducto = @CodigoProducto)
			AND (CodigoProductoEspecifico = @CodigoProductoEspecifico)
			AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE ListarComprasProductosEspecificos
GO
CREATE PROCEDURE ListarComprasProductosEspecificos
	@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia,NumeroCompraProducto,CodigoProducto,CodigoProductoEspecifico,TiempoGarantiaPE,FechaHoraVencimientoPE, FechaHoraRecepcion
	FROM dbo.ComprasProductosEspecificos
	WHERE (NumeroAgencia= @NumeroAgencia)
	ORDER BY NumeroAgencia, NumeroCompraProducto, CodigoProducto, CodigoProductoEspecifico
END
GO



DROP PROCEDURE ObtenerCompraProductoEspecifico
GO
CREATE PROCEDURE ObtenerCompraProductoEspecifico
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoProducto				CHAR(15),
	@CodigoProductoEspecifico	CHAR(30)
AS
BEGIN
	SELECT NumeroAgencia,NumeroCompraProducto,CodigoProducto,CodigoProductoEspecifico,TiempoGarantiaPE,FechaHoraVencimientoPE, FechaHoraRecepcion
	FROM dbo.ComprasProductosEspecificos
	WHERE (NumeroCompraProducto = @NumeroCompraProducto) 
			AND (CodigoProducto = @CodigoProducto)
			AND (CodigoProductoEspecifico = @CodigoProductoEspecifico)
			AND (NumeroAgencia = @NumeroAgencia)
END
GO

DROP PROCEDURE ListarComprasProductosEspecificosParaRecepcion
GO

CREATE PROCEDURE ListarComprasProductosEspecificosParaRecepcion
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT
AS
BEGIN
	SELECT CPE.CodigoProducto, dbo.ObtenerNombreProducto(CodigoProducto) AS NombreProducto, CPE.CodigoProductoEspecifico, CPE.FechaHoraRecepcion, CPE.FechaHoraVencimientoPE, CPE.TiempoGarantiaPE
	FROM ComprasProductosEspecificos CPE
	WHERE (NumeroCompraProducto = @NumeroCompraProducto) 
			AND (NumeroAgencia = @NumeroAgencia)
END
GO

--select * from ComprasProductosEspecificos