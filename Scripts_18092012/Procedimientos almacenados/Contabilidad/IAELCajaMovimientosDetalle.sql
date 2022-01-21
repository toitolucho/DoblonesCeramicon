USE Doblones20
GO


DROP PROCEDURE InsertarCajaMovimientosDetalle
GO
CREATE PROCEDURE InsertarCajaMovimientosDetalle
@NumeroMovimiento		INT,
@NumeroCuenta			VARCHAR(30),
@Cantidad				INT,
@NumeroSerie			TEXT
AS
BEGIN
	INSERT INTO dbo.CajaMovimientosDetalle(NumeroMovimiento, NumeroCuentaDeposito, Cantidad, NumeroSerie)
	VALUES (@NumeroMovimiento, @NumeroCuenta, @Cantidad, @NumeroSerie)
END
GO



DROP PROCEDURE ActualizarCajaMovimientosDetalle
GO
CREATE PROCEDURE ActualizarCajaMovimientosDetalle
@NumeroMovimiento		INT,
@NumeroCuenta			VARCHAR(30),
@Cantidad				INT,
@NumeroSerie			TEXT
AS
BEGIN
	UPDATE dbo.CajaMovimientosDetalle
	SET
		NumeroCuentaDeposito = @NumeroCuenta,
		Cantidad = @Cantidad,
		NumeroSerie = @NumeroSerie
	WHERE NumeroMovimiento = @NumeroMovimiento
END
GO



DROP PROCEDURE EliminarCajaMovimientosDetalle
GO
CREATE PROCEDURE EliminarCajaMovimientosDetalle
@NumeroMovimiento	INT
AS
BEGIN
	DELETE FROM dbo.CajaMovimientosDetalle
	WHERE NumeroMovimiento = @NumeroMovimiento
END
GO



DROP PROCEDURE ListarCajaMovimientosDetalle
GO
CREATE PROCEDURE ListarCajaMovimientosDetalle
AS
BEGIN
	SELECT NumeroMovimiento, NumeroCuentaDeposito, Cantidad, NumeroSerie
	FROM dbo.CajaMovimientosDetalle
	ORDER BY NumeroMovimiento
END
GO



DROP PROCEDURE ListarCajaMovimientosDetalleNumero
GO
CREATE PROCEDURE ListarCajaMovimientosDetalleNumero
@NumeroMovimiento		INT
AS
BEGIN
	SELECT NumeroMovimiento, NumeroCuentaDeposito, Cantidad, NumeroSerie
	FROM dbo.CajaMovimientosDetalle
	WHERE NumeroMovimiento = @NumeroMovimiento
END
GO




DROP PROCEDURE ListarCajaMovimientosDetalleDebe
GO
CREATE PROCEDURE ListarCajaMovimientosDetalleDebe
@Fecha		DATETIME
AS
BEGIN
	SELECT MF.CodigoMonedaFraccion, MF.Valor, SUM(CMD.Cantidad)
	FROM dbo.CajaMovimientos CM INNER JOIN dbo.CajaMovimientosDetalle CMD
	ON CM.NumeroMovimiento = CMD.NumeroMovimiento INNER JOIN dbo.MonedasFracciones MF
	ON CAST(CMD.NumeroCuentaDeposito AS INT) = MF.CodigoMonedaFraccion
	INNER JOIN dbo.Monedas M ON M.CodigoMoneda = MF.CodigoMoneda
	WHERE (CM.CodigoMedioPago = 'E') AND (CAST(CM.FechaHora AS DATE) = CAST(@Fecha AS DATE))
		AND (CM.Debe > 0)
	GROUP BY MF.CodigoMonedaFraccion, MF.Valor
END
GO



DROP PROCEDURE ListarCajaMovimientosDetalleHaber
GO
CREATE PROCEDURE ListarCajaMovimientosDetalleHaber
@Fecha		DATETIME
AS
BEGIN
	SELECT MF.CodigoMonedaFraccion, MF.Valor, SUM(CMD.Cantidad)
	FROM dbo.CajaMovimientos CM INNER JOIN dbo.CajaMovimientosDetalle CMD
	ON CM.NumeroMovimiento = CMD.NumeroMovimiento INNER JOIN dbo.MonedasFracciones MF
	ON CAST(CMD.NumeroCuentaDeposito AS INT) = MF.CodigoMonedaFraccion
	INNER JOIN dbo.Monedas M ON M.CodigoMoneda = MF.CodigoMoneda
	WHERE (CM.CodigoMedioPago = 'E') AND (CAST(CM.FechaHora AS DATE) = CAST(@Fecha AS DATE))
			AND (CM.Haber > 0)
	GROUP BY MF.CodigoMonedaFraccion, MF.Valor
END
GO



DROP PROCEDURE ListarCajaMovimientosDetalleChequeDeposito
GO
CREATE PROCEDURE ListarCajaMovimientosDetalleChequeDeposito
@Fecha		DATETIME
AS
BEGIN
	SELECT CMD.NumeroMovimiento, CMD.NumeroCuentaDeposito, M.NombreMoneda, M.MascaraMoneda, CM.Debe, CM.Haber
	FROM dbo.CajaMovimientos CM INNER JOIN dbo.CajaMovimientosDetalle CMD
	ON CM.NumeroMovimiento = CMD.NumeroMovimiento INNER JOIN dbo.Monedas M
	ON M.CodigoMoneda = CM.CodigoMoneda
	WHERE (CAST(CM.FechaHora AS DATE) = CAST(@Fecha AS DATE)) AND (CM.CodigoMedioPago <> 'E')
END
GO