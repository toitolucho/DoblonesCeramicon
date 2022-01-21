USE Doblones20
GO

DROP PROCEDURE InsertarAsientosTransacciones
GO

CREATE PROCEDURE InsertarAsientosTransacciones
	@CodigoUsuario			INT,	
	@Glosa					TEXT,			
	@Estado					VARCHAR(10),
	@NumeroTransacción		INT,
	@TipoTransaccion		CHAR(1),
	@NumeroAgencia			INT
AS
BEGIN
	DECLARE	@MontoTotal					DECIMAL(10,2),
			@CodigoTipoTransaccion		CHAR(1),
			@NumeroCreditoTransaccion	INT,
			@NumeroFacturaTransaccion	INT,
			@FechaHoraTransaccion		DATETIME = GETDATE(),
			@NumeroAsiento				INT
			
	----BEGIN TRAN
		
	----	INSERT INTO dbo.Asientos(CodigoUsuario, Fecha, Hora, Glosa, Estado)
	----	VALUES (@CodigoUsuario, @FechaHoraTransaccion, @FechaHoraTransaccion, @Glosa, @Estado)
		
	----	SET @NumeroAsiento = SCOPE_IDENTITY()--Devuelve el ultimo id Ingresado en una Tabla con una columna Identidad dentro del Ambito,			
		
	
	----	IF(@TipoTransaccion = 'V')--VENTAS
	----	BEGIN
			
	----		SELECT	@CodigoTipoTransaccion = CodigoTipoVenta, 
	----				@NumeroCreditoTransaccion = NumeroCredito, 
	----				@NumeroFacturaTransaccion = NumeroFactura,
	----				@MontoTotal = MontoTotalVenta
	----		FROM VentasProductos
	----		WHERE NumeroAgencia = @NumeroAgencia
	----		AND NumeroVentaProducto = @NumeroTransacción
				
			
	----		INSERT INTO dbo.AsientosDetalle(NumeroAsiento, NumeroCuenta, Debe, Haber)
	----		SELECT	@NumeroAsiento, NumeroCuentaConfiguracion, 
	----				CASE WHEN CDC.TipoCuentaDebeHaber = 'D' THEN CDC.PorcentajeMontoTotalDH * @MontoTotal / 100
	----				ELSE 0 END,
	----				CASE WHEN CDC.TipoCuentaDebeHaber = 'D' THEN 0
	----				ELSE CDC.PorcentajeMontoTotalDH * @MontoTotal / 100 END
	----		FROM CuentasDeConfiguraciones CDC
	----		WHERE CDC.NumeroConfiguracion = 
	----		CASE 
	----			WHEN (	@CodigoTipoTransaccion = 'N' 
	----					AND @NumeroCreditoTransaccion IS NULL 
	----					AND @NumeroFacturaTransaccion IS NULL)
	----			THEN 1 --VENTA NORMAL SIN FACTURA
				
	----			WHEN (	@CodigoTipoTransaccion = 'N' 
	----					AND @NumeroCreditoTransaccion IS NULL 
	----					AND @NumeroFacturaTransaccion IS NOT NULL)
	----			THEN 2 --VENTA NORMAL CON FACTURA
				
	----			WHEN (	@CodigoTipoTransaccion = 'N' 
	----					AND @NumeroCreditoTransaccion IS NOT NULL 
	----					AND @NumeroFacturaTransaccion IS NULL)
	----			THEN 3 --VENTA A CREDITO SIN FACTURA
				
	----			WHEN (	@CodigoTipoTransaccion = 'N' 
	----					AND @NumeroCreditoTransaccion IS NOT NULL 
	----					AND @NumeroFacturaTransaccion IS NOT NULL)
	----			THEN 4 -- VENTA A CREDITO CON FACTURA
				
	----			WHEN (	@CodigoTipoTransaccion = 'T' 
	----					AND @NumeroCreditoTransaccion IS NULL 
	----					AND @NumeroFacturaTransaccion IS NOT NULL)
	----			THEN 5 --VENTA INSTITUCIONAL CON FACTURA
				
	----			WHEN (	@CodigoTipoTransaccion = 'T' 
	----					AND @NumeroCreditoTransaccion IS NULL 
	----					AND @NumeroFacturaTransaccion IS NULL)
	----			THEN 6 --VENTA INSTITUCIONAL SIN FACTURA
	----		END
			
	----	END
	----	IF(@TipoTransaccion = 'C')--COMPRAS
	----	BEGIN
	----		SELECT	@CodigoTipoTransaccion = CP.CodigoTipoCompra, 
	----				@NumeroFacturaTransaccion = CASE WHEN CP.CodigoEstadoFactura = 'F' THEN 1 ELSE 0 END, 
	----				@MontoTotal = CP.MontoTotalCompra
	----		FROM ComprasProductos CP
	----		WHERE NumeroAgencia = @NumeroAgencia
	----		AND NumeroCompraProducto = @NumeroTransacción
			
	----		INSERT INTO dbo.AsientosDetalle(NumeroAsiento, NumeroCuenta, Debe, Haber)
	----		SELECT	@NumeroAsiento, NumeroCuentaConfiguracion, 
	----				CASE WHEN CDC.TipoCuentaDebeHaber = 'D' THEN CDC.PorcentajeMontoTotalDH * @MontoTotal / 100
	----				ELSE 0 END,
	----				CASE WHEN CDC.TipoCuentaDebeHaber = 'D' THEN 0
	----				ELSE CDC.PorcentajeMontoTotalDH * @MontoTotal / 100 END
	----		FROM CuentasDeConfiguraciones CDC
	----		WHERE CDC.NumeroConfiguracion = 
	----		CASE 
	----			WHEN (@CodigoTipoTransaccion = 'E' AND @NumeroFacturaTransaccion = 1)
	----			THEN 7 --COMPRA EN EFECTIVO CON FACTURA
	----			WHEN (@CodigoTipoTransaccion = 'E' AND @NumeroFacturaTransaccion = 0)
	----			THEN 8 --COMPRA EN EFECTIVO SIN FACTURA
	----			WHEN (@CodigoTipoTransaccion = 'R' AND @NumeroFacturaTransaccion = 1)
	----			THEN 9 --COMPRA A CREDITO CON FACTURA
	----			WHEN (@CodigoTipoTransaccion = 'R' AND @NumeroFacturaTransaccion = 0)
	----			THEN 10 --COMPRA A CREDITO SIN FACTURA
	----		END		
	----	END
	----	IF(@TipoTransaccion = 'T')--TRANSFERENCIAS ENVIO
	----	BEGIN
	----		SELECT @MontoTotal = MontoTotalTransferencia
	----		FROM TransferenciasProductos
	----		WHERE NumeroAgenciaEmisora = @NumeroAgencia
	----		AND NumeroTransferenciaProducto = @NumeroTransacción
			
	----		INSERT INTO dbo.AsientosDetalle(NumeroAsiento, NumeroCuenta, Debe, Haber)
	----		SELECT	@NumeroAsiento, NumeroCuentaConfiguracion, 
	----				CASE WHEN CDC.TipoCuentaDebeHaber = 'D' THEN CDC.PorcentajeMontoTotalDH * @MontoTotal / 100
	----				ELSE 0 END,
	----				CASE WHEN CDC.TipoCuentaDebeHaber = 'D' THEN 0
	----				ELSE CDC.PorcentajeMontoTotalDH * @MontoTotal / 100 END
	----		FROM CuentasDeConfiguraciones CDC
	----		WHERE CDC.NumeroConfiguracion = 11			
			
	----	END
	----	IF(@TipoTransaccion = 'R')--TRANSFERENCIAS RECEPCION
	----	BEGIN
	----		SELECT @MontoTotal = MontoTotalTransferencia
	----		FROM TransferenciasProductos
	----		WHERE NumeroAgenciaEmisora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransacción, @NumeroAgencia)
	----		AND NumeroTransferenciaProducto = @NumeroTransacción
			
	----		INSERT INTO dbo.AsientosDetalle(NumeroAsiento, NumeroCuenta, Debe, Haber)
	----		SELECT	@NumeroAsiento, NumeroCuentaConfiguracion, 
	----				CASE WHEN CDC.TipoCuentaDebeHaber = 'D' THEN CDC.PorcentajeMontoTotalDH * @MontoTotal / 100
	----				ELSE 0 END,
	----				CASE WHEN CDC.TipoCuentaDebeHaber = 'D' THEN 0
	----				ELSE CDC.PorcentajeMontoTotalDH * @MontoTotal / 100 END
	----		FROM CuentasDeConfiguraciones CDC
	----		WHERE CDC.NumeroConfiguracion = 12
	----	END
	----	IF(@TipoTransaccion = 'D')--DEVOLUCIONES POR VENTAS
	----	BEGIN
	----		SELECT @MontoTotal = SUM(CantidadDevuelta * PrecioUnitarioDevolucion)
	----		FROM VentasProductosDevolucionesDetalle
	----		WHERE NumeroAgencia =  @NumeroAgencia
	----		AND NumeroDevolucion =  @NumeroTransacción
			
	----		INSERT INTO dbo.AsientosDetalle(NumeroAsiento, NumeroCuenta, Debe, Haber)
	----		SELECT	@NumeroAsiento, NumeroCuentaConfiguracion, 
	----				CASE WHEN CDC.TipoCuentaDebeHaber = 'D' THEN CDC.PorcentajeMontoTotalDH * @MontoTotal / 100
	----				ELSE 0 END,
	----				CASE WHEN CDC.TipoCuentaDebeHaber = 'D' THEN 0
	----				ELSE CDC.PorcentajeMontoTotalDH * @MontoTotal / 100 END
	----		FROM CuentasDeConfiguraciones CDC
	----		WHERE CDC.NumeroConfiguracion = 13
	----	END
	----	IF(@TipoTransaccion = 'P')--DEVOLUCIONES POR COMPRAS
	----	BEGIN
	----		SELECT SUM(CantidadDevuelta * PrecioUnitarioDevolucion)
	----		FROM ComprasProductosDevolucionesDetalle
	----		WHERE NumeroAgencia = @NumeroAgencia
	----		AND NumeroDevolucion = @NumeroTransacción
			
	----		INSERT INTO dbo.AsientosDetalle(NumeroAsiento, NumeroCuenta, Debe, Haber)
	----		SELECT	@NumeroAsiento, NumeroCuentaConfiguracion, 
	----				CASE WHEN CDC.TipoCuentaDebeHaber = 'D' THEN CDC.PorcentajeMontoTotalDH * @MontoTotal / 100
	----				ELSE 0 END,
	----				CASE WHEN CDC.TipoCuentaDebeHaber = 'D' THEN 0
	----				ELSE CDC.PorcentajeMontoTotalDH * @MontoTotal / 100 END
	----		FROM CuentasDeConfiguraciones CDC
	----		WHERE CDC.NumeroConfiguracion = 14
	----	END
	----IF(@@ERROR <> 0)
	----BEGIN
	----	RAISERROR('No se pudo Completrar la Transacción',12,16)
	----	ROLLBACK
	----END
	----ELSE
	----	COMMIT TRAN
	
END
GO

