USE Doblones20
GO

DROP FUNCTION ExisteCotizacionMonedaSistema
GO

CREATE FUNCTION ExisteCotizacionMonedaSistema(@CodigoMonedaCotizacion TINYINT, @CodigoMonedaSistema TINYINT)
RETURNS BIT
AS
BEGIN
	DECLARE @Existe BIT
	IF NOT EXISTS(
		SELECT *
		FROM MonedasCotizaciones
		WHERE FechaHoraCotizacion 
		BETWEEN CONVERT(DATETIME, CONVERT(VARCHAR(10),GETDATE(),120),120)
		AND DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),GETDATE(),120),120)))
		AND CodigoMonedaCotizacion = @CodigoMonedaCotizacion
		AND CodigoMoneda = @CodigoMonedaSistema
	)
		SET @Existe = 0
	ELSE
		SET @Existe = 1
	RETURN ISNULL(@Existe,0)
END
GO

--SELECT *
--FROM MonedasCotizaciones
--WHERE FechaHoraCotizacion 
--BETWEEN CONVERT(DATETIME, CONVERT(VARCHAR(10),GETDATE(),120),120)
--AND DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),GETDATE(),120),120)))
--AND CodigoMonedaCotizacion = ''
--AND CodigoMoneda = ''

--SELECT GETDATE()
--SELECT CONVERT(DATETIME, CONVERT(VARCHAR(10),GETDATE(),120),120) AS FechaHoraInicio,  DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),GETDATE(),120),120))) as FechaHoraFin
--SELECT M1.NombreMoneda, FechaHoraCotizacion, M2.NombreMoneda AS MonedaCotizacion, CambioOficial, CambioParalelo
--FROM dbo.MonedasCotizaciones MC
--INNER JOIN Monedas M1
--ON MC.CodigoMoneda = M1.CodigoMoneda
--INNER JOIN Monedas M2
--ON MC.CodigoMonedaCotizacion = M2.CodigoMoneda
--select convert(datetime, convert(varchar(10),getdate(),120),120)