USE DOBLONES20
GO

DROP PROCEDURE InsertarMonedaCotizacion
GO

CREATE PROCEDURE InsertarMonedaCotizacion
	@CodigoMoneda			TINYINT,
	@FechaHoraCotizacion	DATETIME,
	@CodigoMonedaCotizacion	TINYINT,
	@CambioOficial			DECIMAL(10,2),
	@CambioParalelo			DECIMAL(10,2)
AS
BEGIN
	BEGIN TRANSACTION
	IF( dbo.ExisteCotizacionMonedaSistema(@CodigoMonedaCotizacion, @CodigoMoneda) = 0  )
		INSERT INTO dbo.MonedasCotizaciones (CodigoMoneda, FechaHoraCotizacion, CodigoMonedaCotizacion, CambioOficial, CambioParalelo)								
		VALUES (@CodigoMoneda, dbo.SoloFecha(@FechaHoraCotizacion), @CodigoMonedaCotizacion, @CambioOficial, @CambioParalelo)
	ELSE
		RAISERROR ('YA SE ENCUENTRA REGISTRADA UNA COTIZACIÓN PARA ESA MONEDA',16,2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE 
		COMMIT TRANSACTION
END	
GO

--declare @fecha datetime = getdate()
--exec InsertarMonedaCotizacion 2,@fecha, 1, 7.03,7.03

DROP PROCEDURE ActualizarMonedaCotizacion
GO

CREATE PROCEDURE ActualizarMonedaCotizacion
	@CodigoMoneda			TINYINT,
	@FechaHoraCotizacion	DATETIME,
	@CodigoMonedaCotizacion	TINYINT,
	@CambioOficial			DECIMAL(10,2),
	@CambioParalelo			DECIMAL(10,2)
AS
BEGIN
	UPDATE 	dbo.MonedasCotizaciones
	SET					
		CodigoMonedaCotizacion	= @CodigoMonedaCotizacion,
		CambioOficial			= @CambioOficial,
		CambioParalelo			= @CambioParalelo
	WHERE	(CodigoMoneda			= @CodigoMoneda)
		AND (dbo.SoloFecha(FechaHoraCotizacion)	= dbo.SoloFecha(@FechaHoraCotizacion))
		AND (CodigoMonedaCotizacion = @CodigoMonedaCotizacion)
END
GO

DROP PROCEDURE EliminarMonedaCotizacion
GO

CREATE PROCEDURE EliminarMonedaCotizacion
	@CodigoMoneda			TINYINT,
	@FechaHoraCotizacion	DATETIME,
	@CodigoMonedaCotizacion	TINYINT
AS
BEGIN
	DELETE 
	FROM dbo.MonedasCotizaciones
	WHERE	(CodigoMoneda = @CodigoMoneda)AND (FechaHoraCotizacion = @FechaHoraCotizacion) AND (CodigoMonedaCotizacion = @CodigoMonedaCotizacion)
END
GO

DROP PROCEDURE ListarMonedasCotizaciones
GO

CREATE PROCEDURE ListarMonedasCotizaciones
AS
BEGIN
	SELECT CodigoMoneda, FechaHoraCotizacion, CodigoMonedaCotizacion, CambioOficial, CambioParalelo
	FROM dbo.MonedasCotizaciones
	ORDER BY CodigoMoneda, FechaHoraCotizacion, CodigoMonedaCotizacion
END
GO

DROP PROCEDURE ObtenerMonedaCotizacion
GO

CREATE PROCEDURE ObtenerMonedaCotizacion
	@CodigoMoneda			TINYINT,
	@FechaHoraCotizacion	DATETIME,
	@CodigoMonedaCotizacion	TINYINT
AS
BEGIN
	SELECT CodigoMoneda, FechaHoraCotizacion, CodigoMonedaCotizacion, CambioOficial, CambioParalelo 
	FROM dbo.MonedasCotizaciones
	WHERE	(CodigoMoneda = @CodigoMoneda) AND (FechaHoraCotizacion	= @FechaHoraCotizacion) AND (CodigoMonedaCotizacion = @CodigoMonedaCotizacion)
END
GO

DROP PROCEDURE ListarMonedasCotizacionesPorMoneda
GO

CREATE PROCEDURE ListarMonedasCotizacionesPorMoneda
@CodigoMoneda				TINYINT,
@CodigoMonedaCotizacion		TINYINT,
@FechaHoraCotizacionInicio	DATETIME,
@FechaHoraCotizacionFin		DATETIME
AS
BEGIN
	SELECT MC.CodigoMoneda, MC.FechaHoraCotizacion, MC.CodigoMonedaCotizacion, Mo.NombreMoneda, MC.CambioOficial, MC.CambioParalelo
	FROM dbo.MonedasCotizaciones MC
	JOIN dbo.Monedas Mo ON
	Mo.CodigoMoneda = MC.CodigoMonedaCotizacion
	WHERE MC.CodigoMoneda = @CodigoMoneda AND MC.FechaHoraCotizacion BETWEEN @FechaHoraCotizacionInicio AND @FechaHoraCotizacionFin
	AND MC.CodigoMonedaCotizacion = @CodigoMonedaCotizacion
	ORDER BY MC.CodigoMoneda, MC.FechaHoraCotizacion, MC.CodigoMonedaCotizacion
END
GO


DROP PROCEDURE ObtenerUltimaMonedaCotizacionFecha
GO

CREATE PROCEDURE ObtenerUltimaMonedaCotizacionFecha
@CodigoMoneda				TINYINT,
@CodigoMonedaCotizacion		TINYINT
AS
BEGIN	
	SELECT TOP(1) CodigoMoneda, FechaHoraCotizacion, CodigoMonedaCotizacion, CambioOficial, CambioParalelo
	FROM MonedasCotizaciones
	WHERE CodigoMoneda = @CodigoMoneda
	AND CodigoMonedaCotizacion = @CodigoMonedaCotizacion
	ORDER BY FechaHoraCotizacion DESC	
END
GO
