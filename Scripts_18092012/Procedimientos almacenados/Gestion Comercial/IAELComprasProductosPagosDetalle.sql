USE DOBLONES20
GO



DROP PROCEDURE InsertarCompraProductoPagoDetalle
GO
CREATE PROCEDURE InsertarCompraProductoPagoDetalle	
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@FechaHoraPago			DATETIME,
	@MontoTotalPago			DECIMAL(10,2),
	@CodigoMonedaPago		TINYINT,
	@NumeroCuenta			CHAR(13),
	@Observaciones			TEXT
AS
BEGIN
	INSERT INTO dbo.ComprasProductosPagosDetalle (NumeroAgencia, NumeroCompraProducto, FechaHoraPago, MontoTotalPago, CodigoMonedaPago, NumeroCuenta, Observaciones)
	VALUES (@NumeroAgencia, @NumeroCompraProducto,  GETDATE(), @MontoTotalPago, @CodigoMonedaPago, @NumeroCuenta, @Observaciones)
END
GO
--declare @fecha datetime = getdate()
--exec InsertarCompraProductoPagoDetalle 1,1,1,  @fecha, 100, null, 'Primera insercion'

DROP PROCEDURE ActualizarCompraProductoPagoDetalle
GO
CREATE PROCEDURE ActualizarCompraProductoPagoDetalle
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@NumeroCompraProductoPago	INT,	
	@FechaHoraPago				DATETIME,
	@MontoTotalPago				DECIMAL(10,2),
	@CodigoMonedaPago			TINYINT,
	@NumeroCuenta			CHAR(13),
	@Observaciones				TEXT
AS
BEGIN
	UPDATE 	dbo.ComprasProductosPagosDetalle
	SET			
		FechaHoraPago				= @FechaHoraPago,
		MontoTotalPago				= @MontoTotalPago,
		CodigoMonedaPago			= @CodigoMonedaPago,
		NumeroCuenta				= @NumeroCuenta,
		Observaciones				= @Observaciones
		
	WHERE (NumeroAgencia = @NumeroAgencia 
	AND NumeroCompraProducto = @NumeroCompraProducto 
	AND NumeroCompraProductoPago = @NumeroCompraProductoPago)
END
GO



DROP PROCEDURE EliminarCompraProductoPagoDetalle
GO
CREATE PROCEDURE EliminarCompraProductoPagoDetalle
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@NumeroCompraProductoPago	INT
AS
BEGIN
	DELETE 
	FROM dbo.ComprasProductosPagosDetalle
	WHERE (NumeroAgencia = @NumeroAgencia 
	AND NumeroCompraProducto = @NumeroCompraProducto 
	AND NumeroCompraProductoPago = @NumeroCompraProductoPago)
END
GO



DROP PROCEDURE ListarComprasProductosPagosDetalle
GO
CREATE PROCEDURE ListarComprasProductosPagosDetalle
AS
BEGIN
	SELECT NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoPago, FechaHoraPago, MontoTotalPago, CodigoMonedaPago, NumeroCuenta, Observaciones
	FROM dbo.ComprasProductosPagosDetalle
	ORDER BY NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoPago
END
GO



DROP PROCEDURE ObtenerCompraProductoPagoDetalle
GO
CREATE PROCEDURE ObtenerCompraProductoPagoDetalle
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@NumeroCompraProductoPago	INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoPago, FechaHoraPago, MontoTotalPago, CodigoMonedaPago, NumeroCuenta, Observaciones
	FROM dbo.ComprasProductosPagosDetalle
	WHERE (NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto AND NumeroCompraProductoPago = @NumeroCompraProductoPago)
END
GO



DROP PROCEDURE ListarCompraProductoPagoDetalleParaMostrar
GO

CREATE PROCEDURE ListarCompraProductoPagoDetalleParaMostrar
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT
AS
BEGIN
	DECLARE @CodigoTipoComrpa CHAR(1)
	
	SELECT @CodigoTipoComrpa = CodigoTipoCompra
	FROM ComprasProductos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroCompraProducto = @NumeroCompraProducto
	
	IF(@CodigoTipoComrpa = 'E')
	BEGIN
		SELECT  COGD.NumeroCompraProducto, FechaHoraPago, MontoTotalPago, CodigoMonedaPago, 
				NombreMoneda, Observaciones, NumeroCompraProductoPago as NumeroPago, PC.NumeroCuenta, PC.NombreCuenta
		FROM dbo.ComprasProductosPagosDetalle COGD 
		INNER JOIN PlanCuentas PC
		ON PC.NumeroCuenta = COGD.NumeroCuenta
		INNER JOIN Monedas M
		ON COGD.CodigoMonedaPago = M.CodigoMoneda
		WHERE (NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto)
		ORDER BY NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoPago, FechaHoraPago
	END
	ELSE
	BEGIN
		SELECT	CP.NumeroCompraProducto, CPPP.FechaHoraPago, AD.Debe AS MontoTotalPago, 2 AS CodigoMonedaPago,
				'Dolares' as NombreMoneda, 'Sin Observacion' as Observaciones, CPPP.NumeroPago,
				AD.NumeroCuenta, PC.NombreCuenta
		FROM ComprasProductos CP
		INNER JOIN CuentasPorPagarPagos CPPP
		ON CP.NumeroCuentaPorPagar = CPPP.NumeroCuentaPorPagar
		INNER JOIN AsientosDetalle AD
		ON AD.NumeroAsiento = CPPP.NumeroAsiento
		INNER JOIN PlanCuentas PC
		ON PC.NumeroCuenta = AD.NumeroCuenta
		WHERE CP.NumeroAgencia = @NumeroAgencia
		AND CP.NumeroCompraProducto = @NumeroCompraProducto
		AND AD.Debe <> 0 AND AD.Haber = 0
	END
END
GO
