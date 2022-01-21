USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.EsPosibleDevolucionProductoGarantia', N'FN') IS NOT NULL
    DROP FUNCTION dbo.EsPosibleDevolucionProductoGarantia; 
GO

CREATE FUNCTION dbo.EsPosibleDevolucionProductoGarantia (@NumeroAgencia INT,  @NumeroTransaccion INT, @CodigoProducto CHAR(15), @TipoTransaccion CHAR(1))
RETURNS BIT
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @EsPosible					BIT,
			@TiempoGarantiaTransaccion	INT,
			@FechaEntregaRecepcion		DATETIME,
			@FechaHoraServidor			DATETIME
	
	SET @FechaHoraServidor = GETDATE()
	
	IF(@TipoTransaccion = 'V')
	BEGIN
		SELECT @TiempoGarantiaTransaccion = TiempoGarantiaVenta
		FROM VentasProductosDetalle
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroVentaProducto = @NumeroTransaccion
		AND CodigoProducto = @CodigoProducto

		SELECT TOP(1) @FechaEntregaRecepcion = FechaHoraEntrega
		FROM VentasProductosDetalleEntrega
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroVentaProducto = @NumeroTransaccion
		AND CodigoProducto = @CodigoProducto
		ORDER BY 1 DESC
		
		
	END
	
	IF(@TipoTransaccion = 'C')
	BEGIN
		
		SELECT @TiempoGarantiaTransaccion = TiempoGarantiaCompra
		FROM ComprasProductosDetalle
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroCompraProducto = @NumeroTransaccion
		AND CodigoProducto = @CodigoProducto

		SELECT TOP(1) @FechaEntregaRecepcion = FechaHoraEntrega
		FROM ComprasProductosDetalleEntrega
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroCompraProducto = @NumeroTransaccion
		AND CodigoProducto = @CodigoProducto
		ORDER BY 1 DESC 
	END
	
	
	IF ISNULL(@TiempoGarantiaTransaccion,0) = 0
			SET @EsPosible = 0
		ELSE IF(DATEADD(DAY,@TiempoGarantiaTransaccion,@FechaEntregaRecepcion) > @FechaHoraServidor )
			SET @EsPosible = 1
		ELSE			
			SET @EsPosible = 0
	
   	RETURN ISNULL(@EsPosible, 0)
END
GO


