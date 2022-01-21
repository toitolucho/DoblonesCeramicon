USE Doblones20
GO

DROP FUNCTION ObtenerCodigoEstadoActualTransacciones
GO

CREATE FUNCTION ObtenerCodigoEstadoActualTransacciones (@NumeroAgencia INT, @NumeroTransaccion INT, @TipoTransaccion CHAR(1))
RETURNS CHAR(1)
AS
BEGIN
	DECLARE @CodigoEstadoTransaccion CHAR(1)
	IF(@TipoTransaccion = 'V')
		SELECT @CodigoEstadoTransaccion = CodigoEstadoVenta
		FROM dbo.VentasProductos
		WHERE NumeroAgencia =  @NumeroAgencia AND NumeroVentaProducto = @NumeroTransaccion	
	IF(@TipoTransaccion = 'C')
		SELECT @CodigoEstadoTransaccion = CodigoEstadoCompra
		FROM dbo.ComprasProductos
		WHERE NumeroAgencia =  @NumeroAgencia AND NumeroCompraProducto = @NumeroTransaccion	
	IF(@TipoTransaccion = 'T') --Cotizaciones
		SELECT @CodigoEstadoTransaccion = CodigoEstadoCotizacion
		FROM dbo.CotizacionVentasProductos	
		WHERE NumeroAgencia =  @NumeroAgencia AND NumeroCotizacionVentaProducto = @NumeroTransaccion	
	IF(@TipoTransaccion = 'E') --Transferencias
		SELECT @CodigoEstadoTransaccion = CodigoEstadoTransferencia
		FROM dbo.TransferenciasProductos
		WHERE NumeroAgenciaEmisora =  @NumeroAgencia AND NumeroTransferenciaProducto = @NumeroTransaccion	
	IF(@TipoTransaccion = 'R') --Transferencias
		SELECT @CodigoEstadoTransaccion = CodigoEstadoTransferencia
		FROM dbo.TransferenciasProductos
		WHERE NumeroAgenciaRecepctora =  @NumeroAgencia AND NumeroTransferenciaProducto = @NumeroTransaccion	
	IF(@TipoTransaccion = 'S') --Servicios Por Ventas e Individuales
		SELECT @CodigoEstadoTransaccion = CodigoEstadoServicio
		FROM VentasServicios
		WHERE NumeroAgencia = @NumeroAgencia AND NumeroVentaServicio = @NumeroTransaccion	
   	RETURN(@CodigoEstadoTransaccion)
END
GO
