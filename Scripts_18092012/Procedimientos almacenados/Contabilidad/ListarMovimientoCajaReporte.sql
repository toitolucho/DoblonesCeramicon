USE Doblones20
GO

DROP PROCEDURE ListarMovimientoCajaReporte
GO

CREATE PROCEDURE ListarMovimientoCajaReporte
	@NumeroAgencia	INT,
	@FechaInicio	DATETIME,
	@FechaFin		DATETIME
AS
BEGIN
	DECLARE @SumaTotal				DECIMAL(10,2),
			@SumaTotalAcumulada		DECIMAL(10,2),
			@CodigoMoneda			TINYINT,
			@CodigoMonedaSistema	TINYINT,
			@FechaHoraActual		DATETIME,
			@FactorCambioCotizacion	DECIMAL(10,2)
			
	IF(@FechaInicio IS NOT NULL AND @FechaFin IS NOT NULL)
	BEGIN
		SET @FechaInicio = CONVERT(DATETIME, CONVERT(CHAR(10), @FechaInicio ,120),120)
		SET @FechaFin = DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaFin,120),120)))
	END
	ELSE
	BEGIN
		SET @FechaInicio = CONVERT(DATETIME, '01/01/1900',120)
		SET @FechaFin = DATEADD(YEAR, 1, GETDATE())
	END
	
	SELECT TOP(1) @CodigoMonedaSistema = CodigoMonedaSistema 
	FROM PCsConfiguraciones 
	WHERE NumeroAgencia = @NumeroAgencia
	SELECT TA.*, 
	CASE WHEN TA.DebeMonedaSistema <> 0 AND TA.Estado <> 'CIERRE' THEN TA.DebeMonedaSistema 
		 WHEN TA.HaberMonedaSistema <> 0  AND TA.Estado <> 'CIERRE' THEN - TA.HaberMonedaSistema 
		 WHEN TA.Estado = 'CIERRE' THEN 0
	END As Suma
	FROM 
	(
		SELECT CM.NumeroMovimiento, CASE CM.CodigoMedioPago WHEN 'E' THEN 'EFECTIVO' WHEN 'C' THEN 'CHEQUE'
				WHEN 'D' THEN 'DEPÓSITO' END AS CodigoMedioPago, CM.Descripcion,
				CASE CM.Estado WHEN 'A' THEN 'APERTURA' WHEN 'C' THEN 'CIERRE' ELSE 'MOVIMIENTO' END AS Estado, 
				M.NombreMoneda, M.MascaraMoneda, CM.Debe, CM.Haber,
				CASE WHEN (M.CodigoMoneda <> @CodigoMonedaSistema AND CM.Debe <> 0) 
				THEN CAST(CM.Debe / DBO.ObtenerFactorCambioCotizacion2(@CodigoMonedaSistema, CM.FechaHora, M.CodigoMoneda) AS DECIMAL(10,2))
				ELSE CM.Debe END AS DebeMonedaSistema,
				CASE WHEN (M.CodigoMoneda <> @CodigoMonedaSistema AND CM.Haber <> 0) 
				THEN CAST(CM.Haber / DBO.ObtenerFactorCambioCotizacion2(@CodigoMonedaSistema, CM.FechaHora, M.CodigoMoneda) AS DECIMAL(10,2))
				ELSE CM.Haber END AS HaberMonedaSistema
				--, DBO.ObtenerFactorCambioCotizacion2(@CodigoMonedaSistema, CM.FechaHora, M.CodigoMoneda) as factor
				
		FROM CajaMovimientos CM
		INNER JOIN Monedas M
		ON CM.CodigoMoneda = M.CodigoMoneda
		WHERE CM.FechaHora 
		BETWEEN @FechaInicio AND @FechaFin
	)TA
END
GO
--exec dbo.ListarMovimientoCajaReporte 1, '04/01/2012', '04/01/2012'


DROP PROCEDURE ListarMovimientoCajaFraccionesReporte
GO

CREATE PROCEDURE ListarMovimientoCajaFraccionesReporte
	@FechaInicio	DATETIME,
	@FechaFin		DATETIME,
	@TipoEstado		CHAR(1)--'A'->FRACCIONES DE APERTURA, 'C'->FRACCIONES DE CIERRE
AS
BEGIN
	
	IF(@FechaInicio IS NOT NULL AND @FechaFin IS NOT NULL)
	BEGIN
		SET @FechaInicio = CONVERT(DATETIME, CONVERT(CHAR(10), @FechaInicio ,120),120)
		SET @FechaFin = DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaFin,120),120)))
	END
	ELSE
	BEGIN
		SET @FechaInicio = CONVERT(DATETIME, '01/01/1900',120)
		SET @FechaFin = DATEADD(YEAR, 1, GETDATE())
	END
	

	SELECT	CMD.NumeroSerie, CMD.Cantidad, MF.Valor, 
			CMD.Cantidad * MF.Valor AS Total,
			M.NombreMoneda, M.MascaraMoneda
	FROM CajaMovimientos CM
	INNER JOIN CajaMovimientosDetalle CMD
	ON CM.NumeroMovimiento = CMD.NumeroMovimiento
	INNER JOIN MonedasFracciones MF
	ON MF.CodigoMonedaFraccion = CMD.NumeroCuentaDeposito
	INNER JOIN Monedas M
	ON MF.CodigoMoneda = M.CodigoMoneda
	WHERE CM.FechaHora 
	BETWEEN @FechaInicio AND @FechaFin
	AND CM.Estado = @TipoEstado
	ORDER BY NombreMoneda ASC, Valor DESC
END
GO
--EXEC ListarMovimientoCajaFraccionesReporte '04/01/2012','04/01/2012', 'A'

DROP PROCEDURE ListarResumenCajaMovimientoReporte
GO

CREATE PROCEDURE ListarResumenCajaMovimientoReporte
	@NumeroAgencia	INT,
	@FechaInicio	DATETIME,
	@FechaFin		DATETIME
AS
BEGIN
	DECLARE @TMovimientosCaja TABLE
	(
		NumeroMovimiento	INT,
		CodigoMedioPago		VARCHAR(20),
		Descripcion			TEXT,
		Estado				VARCHAR(20),
		NombreMoneda		VARCHAR(250),
		MascaraMoneda		VARCHAR(20),
		Debe				DECIMAL(10,2),
		Haber				DECIMAL(10,2),
		DebeMonedaSistema	DECIMAL(10,2),
		HaberMonedaSistema	DECIMAL(10,2),
		Suma				DECIMAL(10,2)
	)
	
	IF(@FechaInicio IS NOT NULL AND @FechaFin IS NOT NULL)
	BEGIN
		SET @FechaInicio = CONVERT(DATETIME, CONVERT(CHAR(10), @FechaInicio ,120),120)
		SET @FechaFin = DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaFin,120),120)))
	END
	ELSE
	BEGIN
		SET @FechaInicio = CONVERT(DATETIME, '01/01/1900',120)
		SET @FechaFin = DATEADD(YEAR, 1, GETDATE())
	END
	
	INSERT INTO @TMovimientosCaja
	EXEC DBO.ListarMovimientoCajaReporte @NumeroAgencia, @FechaInicio, @FechaFin
	
	DECLARE @MontoInicial	DECIMAL(10,2),
			@MontoFinal		DECIMAL(10,2),
			@Sobrante		DECIMAL(10,2),
			@Faltante		DECIMAL(10,2),
			@Sumatoria		DECIMAL(10,2),
			@UsuarioResponsable	VARCHAR(160),
			@NombreMoneda	VARCHAR(250)
			
	SELECT TOP(1) @MontoInicial = DebeMonedaSistema 
	FROM @TMovimientosCaja
	WHERE Estado = 'APERTURA'
	
	SELECT TOP(1) @MontoFinal = DebeMonedaSistema 
	FROM @TMovimientosCaja
	WHERE Estado = 'CIERRE'
	
	SELECT @Sumatoria = ISNULL(SUM(Suma),0)
	FROM @TMovimientosCaja
	
	IF(@Sumatoria > @MontoFinal)
	BEGIN
		SET @Faltante = @Sumatoria - @MontoFinal
		SET @Sobrante = 0
	END
	ELSE
	BEGIN
		
		SET @Faltante = 0
		SET @Sobrante = @MontoFinal - @Sumatoria 
	END
	
	SELECT @UsuarioResponsable = DBO.ObtenerNombreCompletoUsuario(CM.CodigoUsuario)
	FROM CajaMovimientos CM
	WHERE  CM.Estado = 'C'
	AND CM.FechaHora 
	BETWEEN @FechaInicio AND @FechaFin
	
	SELECT TOP(1) @NombreMoneda = NombreMoneda 
	FROM PCsConfiguraciones PC
	INNER JOIN dbo.Monedas M
	ON PC.CodigoMonedaSistema = M.CodigoMoneda
	WHERE NumeroAgencia = @NumeroAgencia
	
	SELECT	@MontoInicial AS SaldoInicial, 
			@MontoFinal	  AS SaldoFinal,
			@Sobrante	  AS SaldoSobrante,
			@Faltante	  AS SaldoFaltante,	
			@Sumatoria	  AS SumaMovimientos,	   
		    @UsuarioResponsable AS UsuarioResponsable,
		    @FechaInicio	AS FechaInicio,
		    @FechaFin		as FechaFin,
		    @NombreMoneda	AS MonedaSistema
	
END
GO
--exec ListarMovimientoCajaReporte 1,'04/01/2012', '04/01/2012'
--EXEC DBO.ListarResumenCajaMovimientoReporte 1, '04/01/2012', '04/01/2012'
