USE Doblones20
GO

DROP FUNCTION ObtenerMontoTotalCuentasCobrosPagos
GO
--Funcion que retorna el Monto Total Acumulado de un Pago o un Cobro, o en Todo Caos el importe Parcial por una Compra
-- @CodigoTipoCuenta : 'P'->Cuentas Por Pagar , 'C'->Cuentas Por Pagar, 'E'->CompraCreditoEfectivo
-- 'T'->Total Cuenta Por Pagar
CREATE FUNCTION ObtenerMontoTotalCuentasCobrosPagos(
	@NumeroAgencia INT, @NumeroCuenta INT, @CodigoTipoCuenta CHAR(1)
)
RETURNS DECIMAL(10,2)
WITH ENCRYPTION
AS
BEGIN
	DECLARE @MontoTotal	DECIMAL(10,2)
	IF(@CodigoTipoCuenta = 'P')
		SELECT @MontoTotal = SUM(CPPP.Monto)
		FROM CuentasPorPagarPagos CPPP
		INNER JOIN CuentasPorPagar CPP
		ON CPP.NumeroCuentaPorPagar = CPPP.NumeroCuentaPorPagar
		AND CPP.NumeroAgencia = @NumeroAgencia
		WHERE CPPP.NumeroCuentaPorPagar = @NumeroCuenta		
	ELSE IF(@CodigoTipoCuenta = 'C')
		SELECT @MontoTotal = SUM(CPCC.Monto)
		FROM CuentasPorCobrarCobros CPCC
		INNER JOIN CuentasPorCobrar CPC
		ON CPCC.NumeroCuentaPorCobrar = CPC.NumeroCuentaPorCobrar
		AND CPC.NumeroAgencia = @NumeroAgencia
		WHERE CPCC.NumeroCuentaPorCobrar = @NumeroCuenta		
	ELSE IF(@CodigoTipoCuenta = 'E')
		SELECT @MontoTotal = SUM(CPPD.MontoTotalPago)
		FROM ComprasProductosPagosDetalle CPPD
		WHERE CPPD.NumeroAgencia = @NumeroAgencia
		AND CPPD.NumeroCompraProducto = @NumeroCuenta
	ELSE	
		SELECT @MontoTotal = Monto
		FROM CuentasPorPagar 
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroCuentaPorPagar = @NumeroCuenta
	RETURN ISNULL(@MontoTotal,0)
END
GO
