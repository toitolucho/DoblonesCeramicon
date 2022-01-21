USE DOBLONES20
GO



DROP PROCEDURE InsertarCompraProductoGastoDetalle
GO
CREATE PROCEDURE InsertarCompraProductoGastoDetalle	
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@CodigoGastosTipos		INT,
	@FechaHoraGasto			DATETIME,
	@MontoPagoGasto			DECIMAL(10,2),
	@CodigoMonedaPago		TINYINT,
	@Observaciones			TEXT
AS
BEGIN
	INSERT INTO dbo.CompraProductosGastosDetalle (NumeroAgencia, NumeroCompraProducto, CodigoGastosTipos, FechaHoraGasto, MontoPagoGasto, CodigoMonedaPago, Observaciones)
	VALUES (@NumeroAgencia, @NumeroCompraProducto, @CodigoGastosTipos, @FechaHoraGasto, @MontoPagoGasto, @CodigoMonedaPago, @Observaciones)
END
GO
--declare @fecha datetime = getdate()
--exec InsertarCompraProductoGastoDetalle 1,1,1,  @fecha, 100, null, 'Primera insercion'

DROP PROCEDURE ActualizarCompraProductoGastoDetalle
GO
CREATE PROCEDURE ActualizarCompraProductoGastoDetalle
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@NumeroCompraProductoGasto	INT,
	@CodigoGastosTipos			INT,
	@FechaHoraGasto				DATETIME,
	@MontoPagoGasto				DECIMAL(10,2),
	@CodigoMonedaPago			TINYINT,
	@Observaciones				TEXT
AS
BEGIN
	UPDATE 	dbo.CompraProductosGastosDetalle
	SET			
		CodigoGastosTipos			= @CodigoGastosTipos,
		FechaHoraGasto				= @FechaHoraGasto,
		MontoPagoGasto				= @MontoPagoGasto,
		CodigoMonedaPago			= @CodigoMonedaPago,
		Observaciones				= @Observaciones
		
	WHERE (NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto AND NumeroCompraProductoGasto = @NumeroCompraProductoGasto)
END
GO



DROP PROCEDURE EliminarCompraProductoGastoDetalle
GO
CREATE PROCEDURE EliminarCompraProductoGastoDetalle
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@NumeroCompraProductoGasto	INT
AS
BEGIN
	DELETE 
	FROM dbo.CompraProductosGastosDetalle
	WHERE (NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto AND NumeroCompraProductoGasto = @NumeroCompraProductoGasto)
END
GO



DROP PROCEDURE ListarCompraProductosGastosDetalle
GO
CREATE PROCEDURE ListarCompraProductosGastosDetalle
AS
BEGIN
	SELECT NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoGasto, CodigoGastosTipos, FechaHoraGasto, MontoPagoGasto, CodigoMonedaPago, Observaciones, CodigoEstadoGasto
	FROM dbo.CompraProductosGastosDetalle
	ORDER BY NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoGasto
END
GO



DROP PROCEDURE ObtenerCompraProductoGastoDetalle
GO
CREATE PROCEDURE ObtenerCompraProductoGastoDetalle
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@NumeroCompraProductoGasto	INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoGasto, CodigoGastosTipos, FechaHoraGasto, MontoPagoGasto, CodigoMonedaPago, Observaciones, CodigoEstadoGasto
	FROM dbo.CompraProductosGastosDetalle
	WHERE (NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto AND NumeroCompraProductoGasto = @NumeroCompraProductoGasto)
END
GO


DROP PROCEDURE ListarCompraProductoGastoDetalleParaPagos
GO

CREATE PROCEDURE ListarCompraProductoGastoDetalleParaPagos
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT
AS
BEGIN
	SELECT GTT.NombreGasto, FechaHoraGasto, MontoPagoGasto, CodigoMonedaPago, Observaciones, CodigoEstadoGasto, NumeroCompraProductoGasto, GTT.CodigoGastosTipos
	FROM dbo.CompraProductosGastosDetalle COGD INNER JOIN dbo.GastosTiposTransacciones GTT
	ON COGD.CodigoGastosTipos = GTT.CodigoGastosTipos
	WHERE (NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto)
	ORDER BY NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoGasto, FechaHoraGasto
END


--exec dbo.ListarCompraProductoReporte 1, 1