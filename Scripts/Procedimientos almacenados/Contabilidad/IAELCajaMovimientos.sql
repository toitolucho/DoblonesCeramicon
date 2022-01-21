USE Doblones20
GO


DROP PROCEDURE InsertarCajaMovimientos
GO
CREATE PROCEDURE InsertarCajaMovimientos
@CodigoMoneda			TINYINT,
@Debe					DECIMAL(10,2),
@Haber					DECIMAL(10,2),
@CodigoMedioPago		CHAR(1),
@CodigoUsuario			INT,
@FechaHora				DATETIME,
@Descripcion			TEXT,
@Estado					CHAR(1)
AS
BEGIN
	INSERT INTO dbo.CajaMovimientos(CodigoMoneda, Debe, Haber, CodigoMedioPago, CodigoUsuario, FechaHora, Descripcion, Estado)
	VALUES (@CodigoMoneda, @Debe, @Haber, @CodigoMedioPago, @CodigoUsuario, @FechaHora, @Descripcion, @Estado)
END
GO



DROP PROCEDURE ActualizarCajaMovimientos
GO
CREATE PROCEDURE ActualizarCajaMovimientos
@NumeroMovimiento		INT,
@CodigoMoneda			TINYINT,
@Debe					DECIMAL(10,2),
@Haber					DECIMAL(10,2),
@CodigoMedioPago		CHAR(1),
@CodigoUsuario			INT,
@FechaHora				DATETIME,
@Descripcion			TEXT,
@Estado					CHAR(1)
AS
BEGIN
	UPDATE dbo.CajaMovimientos
	SET
		CodigoMoneda = @CodigoMoneda,
		Debe = @Debe,
		Haber = @Haber,
		CodigoMedioPago = @CodigoMedioPago,
		CodigoUsuario = @CodigoUsuario,
		FechaHora = @FechaHora,
		Descripcion = @Descripcion,
		Estado = @Estado
	WHERE NumeroMovimiento = @NumeroMovimiento
END
GO



/*DROP PROCEDURE ActualizarCajaMovimientosEstado
GO
CREATE PROCEDURE ActualizarCajaMovimientosEstado
@NumeroMovimiento		INT,
@Estado					CHAR(1)
AS
BEGIN
	UPDATE dbo.CajaMovimientos
	SET
		Estado = @Estado
	WHERE NumeroMovimiento = @NumeroMovimiento
END
GO*/


/*DROP PROCEDURE ActualizarCajaMovimientosRestantes
GO
CREATE PROCEDURE ActualizarCajaMovimientosRestantes
AS
BEGIN
	UPDATE dbo.MonedasFracciones
	SET
		Restante = '0'
END
GO*/




DROP PROCEDURE EliminarCajaMovimientos
GO
CREATE PROCEDURE EliminarCajaMovimientos
@NumeroMovimiento	INT
AS
BEGIN
	DELETE FROM dbo.CajaMovimientos
	WHERE NumeroMovimiento = @NumeroMovimiento
END
GO



DROP PROCEDURE ListarCajaMovimientos
GO
CREATE PROCEDURE ListarCajaMovimientos
AS
BEGIN
	SELECT NumeroMovimiento, CodigoMoneda, Debe, Haber, CASE CodigoMedioPago WHEN 'E' THEN 'Efectivo' WHEN 'C' THEN 'Cheque'
			WHEN 'D' THEN 'Depósito' END AS 'CodigoMedioPago', CodigoUsuario, FechaHora, Descripcion, Estado
	FROM dbo.CajaMovimientos
	ORDER BY NumeroMovimiento
END
GO


DROP PROCEDURE ListarCajaMovimientosNumero
GO
CREATE PROCEDURE ListarCajaMovimientosNumero
@NumeroMovimiento	INT
AS
BEGIN
	SELECT NumeroMovimiento, CodigoMoneda, Debe, Haber, CASE CodigoMedioPago WHEN 'E' THEN 'Efectivo' WHEN 'C' THEN 'Cheque'
			WHEN 'D' THEN 'Depósito' END AS 'CodigoMedioPago', CodigoUsuario, FechaHora, Descripcion, Estado
	FROM dbo.CajaMovimientos
	WHERE NumeroMovimiento = @NumeroMovimiento
END
GO




DROP PROCEDURE ListarCajaMovimientosFecha
GO
CREATE PROCEDURE ListarCajaMovimientosFecha
@Fecha	DATETIME
AS
BEGIN
	SELECT NumeroMovimiento, CodigoMoneda, Debe, Haber, CASE CodigoMedioPago WHEN 'E' THEN 'Efectivo' WHEN 'C' THEN 'Cheque'
			WHEN 'D' THEN 'Depósito' END AS 'CodigoMedioPago', CodigoUsuario, FechaHora, Descripcion, Estado
	FROM dbo.CajaMovimientos
	WHERE (CAST(FechaHora AS DATE) = CAST(@Fecha AS DATE))
END
GO



DROP PROCEDURE ListarCajaMovimientosMedioPago
GO
CREATE PROCEDURE ListarCajaMovimientosMedioPago
@CodigoMedioPago	CHAR(1),
@Fecha DATETIME
AS
BEGIN
	SELECT NumeroMovimiento, CodigoMoneda, Debe, Haber, CASE CodigoMedioPago WHEN 'E' THEN 'Efectivo' WHEN 'C' THEN 'Cheque'
			WHEN 'D' THEN 'Depósito' END AS 'CodigoMedioPago', CodigoUsuario, FechaHora, Descripcion, Estado
	FROM dbo.CajaMovimientos
	WHERE (CodigoMedioPago = @CodigoMedioPago) AND (CAST(FechaHora AS DATE) = CAST(@Fecha AS DATE))
END
GO



DROP PROCEDURE ListarCajaMovimientosEstado
GO
CREATE PROCEDURE ListarCajaMovimientosEstado
@Estado	CHAR(1),
@Fecha DATETIME
AS
BEGIN
	SELECT NumeroMovimiento, CodigoMoneda, Debe, Haber, CASE CodigoMedioPago WHEN 'E' THEN 'Efectivo' WHEN 'C' THEN 'Cheque'
			WHEN 'D' THEN 'Depósito' END AS 'CodigoMedioPago', CodigoUsuario, FechaHora, Descripcion, Estado
	FROM dbo.CajaMovimientos
	WHERE (Estado = @Estado) AND (CAST(FechaHora AS DATE) = CAST(@Fecha AS DATE))
END
GO




DROP PROCEDURE ObtenerUltimoNumeroCajaMovimiento
GO
CREATE PROCEDURE ObtenerUltimoNumeroCajaMovimiento
@UltimoNumeroCajaMovimiento		INT		OUTPUT
AS
BEGIN
	SET @UltimoNumeroCajaMovimiento = (SELECT MAX(NumeroMovimiento)
										FROM dbo.CajaMovimientos)	
END
GO


DROP PROCEDURE ListarCajaMovimientosReporteNumero
GO
CREATE PROCEDURE ListarCajaMovimientosReporteNumero
@NumeroMovimiento	INT
AS
BEGIN
	SELECT CM.NumeroMovimiento, CASE CM.CodigoMedioPago WHEN 'E' THEN 'Efectivo' WHEN 'C' THEN 'Cheque'
			WHEN 'D' THEN 'Depósito' END AS 'CodigoMedioPago', CMD.NumeroCuentaDeposito, CM.FechaHora,
			CM.Descripcion, M.NombreMoneda, M.MascaraMoneda, CM.Debe, CM.Haber, CMD.Cantidad, MF.Valor
	FROM dbo.CajaMovimientos CM 
	INNER JOIN dbo.CajaMovimientosDetalle CMD
	ON CM.NumeroMovimiento = CMD.NumeroMovimiento 
	INNER JOIN dbo.Monedas M	
	ON M.CodigoMoneda = CM.CodigoMoneda
	INNER JOIN DBO.MonedasFracciones MF
	ON M.CodigoMoneda = MF.CodigoMoneda
	AND MF.CodigoMonedaFraccion = CMD.NumeroCuentaDeposito
	WHERE CM.NumeroMovimiento = @NumeroMovimiento
END
GO



DROP PROCEDURE ListarCajaMovimientosReporteFecha
GO
CREATE PROCEDURE ListarCajaMovimientosReporteFecha
@Fecha	DATETIME
AS
BEGIN
	SELECT CM.NumeroMovimiento, CASE CM.CodigoMedioPago WHEN 'E' THEN 'Efectivo' WHEN 'C' THEN 'Cheque'
			WHEN 'D' THEN 'Depósito' END AS 'CodigoMedioPago', CMD.NumeroCuentaDeposito, CM.FechaHora,
			CM.Descripcion, M.NombreMoneda, M.MascaraMoneda, CM.Debe, CM.Haber, CMD.Cantidad, MF.Valor
	FROM dbo.CajaMovimientos CM INNER JOIN dbo.CajaMovimientosDetalle CMD
	ON CM.NumeroMovimiento = CMD.NumeroMovimiento INNER JOIN dbo.Monedas M
	ON M.CodigoMoneda = CM.CodigoMoneda
	INNER JOIN DBO.MonedasFracciones MF
	ON M.CodigoMoneda = MF.CodigoMoneda
	AND MF.CodigoMonedaFraccion = CMD.NumeroCuentaDeposito
	WHERE (CAST(FechaHora AS DATE) = CAST(@Fecha AS DATE))
END
GO


DROP PROCEDURE ListarCajaMovimientosSaldo
GO
CREATE PROCEDURE ListarCajaMovimientosSaldo
@Fecha		DATETIME
AS
BEGIN
	SELECT M.CodigoMoneda, M.NombreMoneda, M.MascaraMoneda, SUM(CM.Debe), SUM(CM.Haber)
	FROM dbo.CajaMovimientos CM INNER JOIN dbo.Monedas M
	ON CM.CodigoMoneda = M.CodigoMoneda
	WHERE (CAST(CM.FechaHora AS DATE) = CAST(@Fecha AS DATE))
	GROUP BY M.CodigoMoneda, M.NombreMoneda, M.MascaraMoneda
END
GO


DROP PROCEDURE ActualizarMontoTotalDesdeDetalleFraccionado
GO

CREATE PROCEDURE ActualizarMontoTotalDesdeDetalleFraccionado
	@NumeroMovimiento	INT,
	@NumeroAgencia		INT
AS
BEGIN
	DECLARE @SumaTotal				DECIMAL(10,2),
			@SumaTotalAcumulada		DECIMAL(10,2),
			@CodigoMoneda			TINYINT,
			@CodigoMonedaSistema	TINYINT,
			@FechaHoraActual		DATETIME,
			@FactorCambioCotizacion	DECIMAL(10,2)
	
	DECLARE @TMonedas	TABLE
	(
		CodigoMoneda	TINYINT
	)
	SET @FechaHoraActual = GETDATE()
	
	INSERT INTO @TMonedas (CodigoMoneda)
	SELECT DISTINCT MF.CodigoMoneda
	FROM CajaMovimientosDetalle CMD
	INNER JOIN MonedasFracciones MF
	ON CMD.NumeroCuentaDeposito = MF.CodigoMonedaFraccion
	WHERE CMD.NumeroMovimiento = @NumeroMovimiento
	
	SET @SumaTotal = 0
	SET @SumaTotalAcumulada = 0
	
	SELECT TOP(1) @CodigoMonedaSistema = CodigoMonedaSistema 
	FROM PCsConfiguraciones 
	WHERE NumeroAgencia = @NumeroAgencia
	
	IF((SELECT COUNT(*) FROM @TMonedas) > 1)-- SI EL MOVIMIENTO IMPLICA MAS DE UNA MONEDA
	BEGIN
	
		SET ROWCOUNT 1
		SELECT @CodigoMoneda = CodigoMoneda
		FROM @TMonedas
		WHILE @@ROWCOUNT <> 0
		BEGIN
			--Colocar aqui las Operaciones
			IF(@CodigoMoneda <> @CodigoMonedaSistema)
			BEGIN
				EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraActual, @CodigoMoneda, @FactorCambioCotizacion OUTPUT
				
				IF(@FactorCambioCotizacion = -1)
					EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMoneda, @FactorCambioCotizacion OUTPUT
			END
			ELSE
			BEGIN
				SET @FactorCambioCotizacion = 1
			END
			
			SELECT @SumaTotal = (SUM(CMD.Cantidad * MF.Valor) * @FactorCambioCotizacion)
			FROM CajaMovimientosDetalle CMD
			INNER JOIN MonedasFracciones MF
			ON CMD.NumeroCuentaDeposito = MF.CodigoMonedaFraccion
			WHERE CMD.NumeroMovimiento = @NumeroMovimiento
			AND MF.CodigoMoneda = @CodigoMoneda
			
			SET @SumaTotalAcumulada = @SumaTotalAcumulada + ISNULL(@SumaTotal,0)
			
			DELETE @TMonedas WHERE CodigoMoneda = @CodigoMoneda
			SET ROWCOUNT 1
				
			SELECT @CodigoMoneda = CodigoMoneda
			FROM @TMonedas
		END
		SET ROWCOUNT 0	
		
		UPDATE CajaMovimientos
			SET Debe = @SumaTotalAcumulada,
				CodigoMoneda = @CodigoMonedaSistema
		WHERE NumeroMovimiento = @NumeroMovimiento
	
	END
END
GO

--exec dbo.ActualizarMontoTotalDesdeDetalleFraccionado 13,1
