USE Doblones20
GO

DROP FUNCTION ObtenerUltimaFechaMovimientoCierre
GO

CREATE FUNCTION ObtenerUltimaFechaMovimientoCierre()
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @UltimaFecha	DATETIME,
			@FechaActual	DATETIME,
			@Descripcion	VARCHAR(4000),
			@MontoSaldo		DECIMAL(10,2),
			@MascaraMoneda	VARCHAR(20)
	
	SET @FechaActual = GETDATE()
		
	SELECT @UltimaFecha = FechaHora, @MontoSaldo = Debe
	FROM CajaMovimientos CJ
	WHERE CJ.Estado = 'C'
	ORDER BY FechaHora DESC	
	
	SELECT TOP(1) @MascaraMoneda = MascaraMoneda
	FROM PCsConfiguraciones PC
	INNER JOIN Monedas M
	ON PC.CodigoMonedaSistema = M.CodigoMoneda
	
	SET @Descripcion = 'Existe un registro de cierre de caja de hace ' + CAST(DATEDIFF(DAY, @UltimaFecha, @FechaActual) AS VARCHAR(10)) +' dias correspondiente al dia ' + DATENAME(WEEKDAY, @UltimaFecha) + ', ' 
				+ RIGHT('00' + RTRIM(CAST(DAY(@UltimaFecha) AS CHAR(2))), 2) +' de ' + DATENAME(MONTH, @UltimaFecha) + ' de ' 
				+ CAST(YEAR(@UltimaFecha) AS CHAR(4)) +' con un saldo de ' + CAST(@MontoSaldo AS VARCHAR(100))
				--+ ' ' + @MascaraMoneda
	
	RETURN @Descripcion
END
GO
