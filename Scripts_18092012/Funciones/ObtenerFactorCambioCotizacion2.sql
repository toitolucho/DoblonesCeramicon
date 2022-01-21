
USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.ObtenerFactorCambioCotizacion2', N'FN') IS NOT NULL
    DROP FUNCTION dbo.ObtenerFactorCambioCotizacion2; 
GO
--DROP FUNCTION dbo.ObtenerFactorCambioCotizacion2
--GO

CREATE FUNCTION dbo.ObtenerFactorCambioCotizacion2 
(
	@CodigoMoneda TINYINT, 
	@FechaHoraCotizacion DATETIME, 
	@CodigoMonedaCotizacion TINYINT
)
RETURNS  DECIMAL(10,2)
AS
BEGIN	
	DECLARE @CambioOficial DECIMAL(10,2)
	
	SET @CambioOficial = -1;
	
	IF(@FechaHoraCotizacion IS NULL)
	BEGIN
		SELECT top(1) @CambioOficial = MC.CambioOficial  
		FROM dbo.MonedasCotizaciones MC
		WHERE MC.CodigoMoneda = @CodigoMoneda  AND CodigoMonedaCotizacion = @CodigoMonedaCotizacion
		ORDER BY MC.FechaHoraCotizacion DESC		
	END
	ELSE
	BEGIN
		SELECT @CambioOficial = MC.CambioOficial
		FROM dbo.MonedasCotizaciones MC
		WHERE MC.CodigoMoneda = @CodigoMoneda 
		AND Cast(Floor(Cast( MC.FechaHoraCotizacion As Float)) As DateTime)  = Cast(Floor(Cast( @FechaHoraCotizacion As Float)) As DateTime) 
		AND CodigoMonedaCotizacion = @CodigoMonedaCotizacion
		IF (@@ROWCOUNT = 0)
		SET @CambioOficial = -1;		
	END	
	
	RETURN @CambioOficial
END
GO

--SELECT * FROM MonedasCotizaciones
--select * from CajaMovimientos
--select * from CajaMovimientosDetalle