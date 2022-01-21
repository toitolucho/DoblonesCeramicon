
USE DOBLONES20
GO

--IF OBJECT_ID (N'dbo.ObtenerFactorCambioCotizacion', N'FN') IS NOT NULL
--    DROP PROCEDURE dbo.ObtenerFactorCambioCotizacion; 
--GO
DROP PROCEDURE dbo.ObtenerFactorCambioCotizacion 
GO

CREATE PROCEDURE dbo.ObtenerFactorCambioCotizacion 
	@CodigoMoneda TINYINT, @FechaHoraCotizacion DATETIME, @CodigoMonedaCotizacion TINYINT, @CambioOficial DECIMAL(10,2) OUTPUT
AS
BEGIN	
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
		WHERE MC.CodigoMoneda = @CodigoMoneda AND MC.FechaHoraCotizacion = @FechaHoraCotizacion AND CodigoMonedaCotizacion = @CodigoMonedaCotizacion
		IF (@@ROWCOUNT = 0)
		SET @CambioOficial = -1;		
	END	
END
GO

--SELECT *  
--FROM MonedasCotizaciones 
--WHERE CodigoMoneda = 1 AND CodigoMonedaCotizacion = 2
--ORDER BY FechaHoraCotizacion desc
---- SELECT DBO.ObtenerNombreProducto('9')

--DECLARE @DATO DECIMAL(10,2)
--EXEC DBO.ObtenerFactorCambioCotizacion 1,NULL,2, @DATO OUTPUT
--SELECT @DATO 