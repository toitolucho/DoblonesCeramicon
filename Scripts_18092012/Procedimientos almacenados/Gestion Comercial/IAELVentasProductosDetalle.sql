USE DOBLONES20
GO

DROP PROCEDURE InsertarVentaProductoDetalle
GO

CREATE PROCEDURE InsertarVentaProductoDetalle
@NumeroAgencia				INT,
@NumeroVentaProducto		INT,
@CodigoProducto				CHAR(15),
@CantidadVenta				INT,
@CantidadEntregada			INT,
@PrecioUnitarioVenta		DECIMAL(10,2),
@TiempoGarantiaVenta		INT,
@PorcentajeDescuento		DECIMAL(10,2),
@NumeroPrecioSeleccionado	CHAR(1)
AS
BEGIN
	IF( NOT EXISTS (SELECT * from VentasProductosDetalle where NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroVentaProducto AND CodigoProducto = @CodigoProducto) )
	BEGIN
		INSERT INTO dbo.VentasProductosDetalle(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CantidadVenta, CantidadEntregada, PrecioUnitarioVenta, TiempoGarantiaVenta, PorcentajeDescuento, NumeroPrecioSeleccionado)
		VALUES (@NumeroAgencia, @NumeroVentaProducto, @CodigoProducto, @CantidadVenta, @CantidadEntregada ,@PrecioUnitarioVenta, @TiempoGarantiaVenta, @PorcentajeDescuento, @NumeroPrecioSeleccionado)
	END
	ELSE
	BEGIN
		EXEC ActualizarVentaProductoDetalle @NumeroAgencia, @NumeroVentaProducto, @CodigoProducto, @CantidadVenta, @CantidadEntregada, @PrecioUnitarioVenta, @TiempoGarantiaVenta, @PorcentajeDescuento, @NumeroPrecioSeleccionado
	END
END
GO

DROP PROCEDURE ActualizarVentaProductoDetalle
GO

CREATE PROCEDURE ActualizarVentaProductoDetalle
@NumeroAgencia				INT,
@NumeroVentaProducto		INT,
@CodigoProducto				CHAR(15),
@CantidadVenta				INT,
@CantidadEntregada			INT,
@PrecioUnitarioVenta		DECIMAL(10,2),
@TiempoGarantiaVenta		INT,
@PorcentajeDescuento		DECIMAL(10,2),
@NumeroPrecioSeleccionado	CHAR(1)
AS
BEGIN
	UPDATE 	dbo.VentasProductosDetalle
	SET			
		CantidadVenta				= @CantidadVenta,
		CantidadEntregada			= @CantidadEntregada,
		PrecioUnitarioVenta			= @PrecioUnitarioVenta,
		TiempoGarantiaVenta			= @TiempoGarantiaVenta,
		PorcentajeDescuento			= @PorcentajeDescuento,
		NumeroPrecioSeleccionado	= @NumeroPrecioSeleccionado		
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
	AND CodigoProducto = @CodigoProducto
END
GO

DROP PROCEDURE EliminarVentaProductoDetalle
GO

CREATE PROCEDURE EliminarVentaProductoDetalle
@NumeroAgencia			INT,
@NumeroVentaProducto	INT,
@CodigoProducto			CHAR(15)
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductosDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
	AND CodigoProducto = @CodigoProducto
END
GO

DROP PROCEDURE ListarVentasProductosDetalle
GO

CREATE PROCEDURE ListarVentasProductosDetalle
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, CantidadVenta, CantidadEntregada, PrecioUnitarioVenta, TiempoGarantiaVenta, PorcentajeDescuento, NumeroPrecioSeleccionado
	FROM dbo.VentasProductosDetalle
	ORDER BY NumeroVentaProducto,CodigoProducto
END
GO


DROP PROCEDURE ObtenerVentaProductoDetalle
GO

CREATE PROCEDURE ObtenerVentaProductoDetalle
@NumeroAgencia			INT,
@NumeroVentaProducto	INT,
@CodigoProducto			CHAR(15)
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, CantidadVenta, CantidadEntregada, PrecioUnitarioVenta, TiempoGarantiaVenta, PorcentajeDescuento, NumeroPrecioSeleccionado
	FROM dbo.VentasProductosDetalle
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
	AND CodigoProducto = @CodigoProducto
END
GO



DROP PROCEDURE ListarVentasProductosDetalleEspecifico
GO

CREATE PROCEDURE ListarVentasProductosDetalleEspecifico
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, CantidadVenta, PrecioUnitarioVenta, TiempoGarantiaVenta
	FROM dbo.VentasProductosDetalle VPD	
	WHERE VPD.NumeroAgencia = @NumeroAgencia
	AND VPD.NumeroVentaProducto = @NumeroVentaProducto
	ORDER BY NumeroVentaProducto,CodigoProducto
END
GO


DROP PROCEDURE ListarVentaProductoDetalleReporte
GO

CREATE PROCEDURE ListarVentaProductoDetalleReporte
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT
AS
BEGIN

	DECLARE @FactorCambioCotizacion	DECIMAL(10,2),
			@CodigoMonedaSistema	INT,
			@CodigoMonedaCotizacion	INT,
			@CodigoMonedaRegion		INT,
			@FechaHoraVenta			DATETIME
			
	
	SELECT @FechaHoraVenta = FechaHoraVenta, @CodigoMonedaCotizacion = CodigoMoneda 
	FROM VentasProductos 
	WHERE NumeroAgencia = @NumeroAgencia 
	AND NumeroVentaProducto = @NumeroVentaProducto
	
	SELECT TOP(1) @CodigoMonedaRegion = CodigoMonedaRegion, 
				@CodigoMonedaSistema = CodigoMonedaSistema 
	FROM PCsConfiguraciones 
	WHERE NumeroAgencia = @NumeroAgencia
	

	EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraVenta, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT	
	IF(@FactorCambioCotizacion = -1)
		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT
	
	IF EXISTS(SELECT * FROM VentasProductos
				WHERE NumeroAgencia = @NumeroAgencia 
				AND NumeroVentaProducto = @NumeroVentaProducto
				AND CodigoMoneda = @CodigoMonedaSistema)
	BEGIN
		SELECT P.NombreProducto , VPD.CodigoProducto, VPE.CodigoProductoEspecifico, VPD.CantidadVenta, 
				--VPD.PrecioUnitarioVenta, 
				--(VPD.CantidadVenta*VPD.PrecioUnitarioVenta) as 
				--PrecioTotalVenta, 
				VPD.PrecioUnitarioVentaOtraMoneda as PrecioUnitarioVenta, 
				VPD.CantidadVenta * VPD.PrecioUnitarioVentaOtraMoneda AS PrecioTotalVenta,
				VPD.TiempoGarantiaVenta, 
				VPE.TiempoGarantiaPE
		FROM VentasProductosDetalle VPD 
		INNER JOIN Productos P 
		ON P.CodigoProducto = VPD.CodigoProducto
		LEFT JOIN VentasProductosEspecificos VPE 
		ON VPD.NumeroAgencia = VPE.NumeroAgencia 
		AND VPD.NumeroVentaProducto = VPE.NumeroVentaProducto
		AND VPD.CodigoProducto = VPE.CodigoProducto
		WHERE VPD.NumeroAgencia = @NumeroAgencia
		AND VPD.NumeroVentaProducto = @NumeroVentaProducto
		ORDER BY NumeroOrdenInsertado
	END		
	ELSE
	BEGIN
		SELECT P.NombreProducto , VPD.CodigoProducto, VPE.CodigoProductoEspecifico, VPD.CantidadVenta, 
			--CAST((VPD.PrecioUnitarioVenta)* @FactorCambioCotizacion AS DECIMAL(10,2)) AS PrecioUnitarioVenta, 
			--CAST((CAST(@FactorCambioCotizacion * VPD.PrecioUnitarioVenta AS DECIMAL(10,2))) * VPD.CantidadVenta AS DECIMAL(10,2)) AS 
			--PrecioTotalVenta, 
			VPD.PrecioUnitarioVentaOtraMoneda as PrecioUnitarioVenta, 
			VPD.CantidadVenta * VPD.PrecioUnitarioVentaOtraMoneda AS PrecioTotalVenta,
			VPD.TiempoGarantiaVenta, 
			VPE.TiempoGarantiaPE
		FROM VentasProductosDetalle VPD 
		INNER JOIN Productos P 
		ON P.CodigoProducto = VPD.CodigoProducto
		LEFT JOIN VentasProductosEspecificos VPE 
		ON VPD.NumeroAgencia = VPE.NumeroAgencia 
		AND VPD.NumeroVentaProducto = VPE.NumeroVentaProducto
		AND VPD.CodigoProducto = VPE.CodigoProducto
		WHERE VPD.NumeroAgencia = @NumeroAgencia
		AND VPD.NumeroVentaProducto = @NumeroVentaProducto
		ORDER BY NumeroOrdenInsertado
	END
END
GO

--exec dbo.ListarVentaProductoDetalleReporte 1, 450

DROP PROCEDURE ListarVentaProductoDetalleReporteIncluidoAgregados
GO

CREATE PROCEDURE ListarVentaProductoDetalleReporteIncluidoAgregados
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT,	
	@TipoCalculoAgregado	CHAR(1), -- 'P'->Promedio, 'S'->Sumatoria
	@IncluirAgregados		BIT,
	@EsFactura				BIT
AS
BEGIN
	DECLARE @FactorCambioCotizacion	DECIMAL(10,2),
			@CodigoMonedaSistema	INT,
			@CodigoMonedaCotizacion	INT,
			@CodigoMonedaRegion		INT,
			@FechaHoraVenta			DATETIME
			
	
	SELECT @FechaHoraVenta = FechaHoraVenta, @CodigoMonedaCotizacion = CodigoMoneda FROM VentasProductos WHERE NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroVentaProducto
	SELECT TOP(1) @CodigoMonedaRegion = CodigoMonedaRegion, @CodigoMonedaSistema = CodigoMonedaSistema FROM PCsConfiguraciones WHERE NumeroAgencia = @NumeroAgencia
	
	IF(@EsFactura = 1)
	BEGIN
		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraVenta, @CodigoMonedaRegion, @FactorCambioCotizacion OUTPUT	
		IF(@FactorCambioCotizacion = -1)
			EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaRegion, @FactorCambioCotizacion OUTPUT
		
		IF(@FactorCambioCotizacion = -1 AND @CodigoMonedaSistema = @CodigoMonedaRegion)
			SET @FactorCambioCotizacion = 1
	END
	ELSE
	BEGIN
		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraVenta, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT	
		IF(@FactorCambioCotizacion = -1)
			EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT
		
		IF(@FactorCambioCotizacion = -1 AND @CodigoMonedaSistema = @CodigoMonedaCotizacion)
			SET @FactorCambioCotizacion = 1
	END
	
		
	IF(@IncluirAgregados = 1)	
	BEGIN
		--SELECT dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto , VPD.CodigoProducto, VPD.CantidadVenta, CAST(VPD.PrecioUnitarioVenta AS DECIMAL(10,2)) AS PrecioUnitarioVenta, (VPD.CantidadVenta*VPD.PrecioUnitarioVenta) as PrecioTotalVenta, VPD.TiempoGarantiaVenta, CASE(@CodigoMonedaCotizacion) WHEN (@CodigoMonedaSistema) THEN (VPD.PrecioUnitarioVenta) ELSE CAST((VPD.PrecioUnitarioVenta)* @FactorCambioCotizacion AS DECIMAL(10,2)) END AS PrecioUnitarioMonedaCotizacion, CASE(@CodigoMonedaCotizacion) WHEN (@CodigoMonedaSistema) THEN (VPD.CantidadVenta*VPD.PrecioUnitarioVenta) ELSE CAST((CAST(@FactorCambioCotizacion * VPD.PrecioUnitarioVenta AS DECIMAL(10,2))) * VPD.CantidadVenta AS DECIMAL(10,2)) END AS PrecioTotalMonedaCotizacion
		--FROM VentasProductosDetalle VPD 
		--WHERE VPD.NumeroAgencia = @NumeroAgencia
		--AND VPD.NumeroVentaProducto = @NumeroVentaProducto
		--UNION 
		--SELECT dbo.ObtenerNombreProducto(VPEA.CodigoProducto) as NombreProducto , VPEA.CodigoProducto, COUNT(VPEA.CodigoProducto) AS CantidadVenta, CAST(AVG(VPEA.PrecioUnitario) AS DECIMAL(10,2)) AS PrecioUnitarioVenta, CASE (@TipoCalculoAgregado) WHEN 'P' THEN CAST((COUNT(VPEA.CodigoProducto)*AVG(VPEA.PrecioUnitario)) AS DECIMAL(10,2)) WHEN 'S' THEN CAST(SUM(VPEA.PrecioUnitario)AS DECIMAL(10,2)) END as PrecioTotalVenta, VPEA.TiempoGarantiaPE, CASE(@CodigoMonedaCotizacion) WHEN (@CodigoMonedaSistema) THEN CAST(SUM(VPEA.PrecioUnitario)AS DECIMAL(10,2)) ELSE CAST(SUM(VPEA.PrecioUnitario) * @FactorCambioCotizacion AS DECIMAL(10,2)) END AS PrecioUnitarioMonedaCotizacion, CASE(@CodigoMonedaCotizacion) WHEN (@CodigoMonedaSistema) THEN CAST(SUM(VPEA.PrecioUnitario)AS DECIMAL(10,2)) ELSE CAST(SUM(VPEA.PrecioUnitario) * @FactorCambioCotizacion AS DECIMAL(10,2)) END AS PrecioTotalMonedaCotizacion
		--FROM VentasProductosEspecificosAgregados VPEA 
		--WHERE VPEA.NumeroAgencia = @NumeroAgencia
		--AND VPEA.NumeroVentaProducto = @NumeroVentaProducto
		--GROUP BY VPEA.CodigoProducto ,VPEA.TiempoGarantiaPE
		--ORDER BY CodigoProducto
		
		SELECT	TA.NombreProducto, TA.CodigoProducto, TA.CantidadVenta, TA.PrecioUnitarioVenta, 
				TA.PrecioTotalVenta, TA.TiempoGarantiaVenta, TA.PrecioTotalMonedaCotizacion, 
				TA.PrecioUnitarioMonedaCotizacion, TA.NumeroOrdenInsertado
		FROM
		(
			SELECT	dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto , 
					VPD.CodigoProducto, VPD.CantidadVenta, 
					CAST(VPD.PrecioUnitarioVenta AS DECIMAL(10,2)) AS PrecioUnitarioVenta, 
					(VPD.CantidadVenta*VPD.PrecioUnitarioVenta) as PrecioTotalVenta, 
					VPD.TiempoGarantiaVenta, 
					CAST((VPD.PrecioUnitarioVenta)* @FactorCambioCotizacion AS DECIMAL(10,2)) AS PrecioUnitarioMonedaCotizacion,
					CAST((CAST(@FactorCambioCotizacion * VPD.PrecioUnitarioVenta AS DECIMAL(10,2))) * VPD.CantidadVenta AS DECIMAL(10,2)) AS PrecioTotalMonedaCotizacion, 
					NumeroOrdenInsertado
			FROM VentasProductosDetalle VPD 		
			WHERE VPD.NumeroAgencia = @NumeroAgencia
			AND VPD.NumeroVentaProducto = @NumeroVentaProducto		
			UNION ALL
			SELECT	dbo.ObtenerNombreProducto(VPEA.CodigoProducto) as NombreProducto, 
					VPEA.CodigoProducto, 
					COUNT(VPEA.CodigoProducto) AS CantidadVenta, 
					CAST(AVG(VPEA.PrecioUnitario) AS DECIMAL(10,2)) AS PrecioUnitarioVenta, 
					CASE (@TipoCalculoAgregado) WHEN 'P' THEN CAST((COUNT(VPEA.CodigoProducto)*AVG(VPEA.PrecioUnitario)) AS DECIMAL(10,2)) WHEN 'S' THEN CAST(SUM(VPEA.PrecioUnitario)AS DECIMAL(10,2)) END as PrecioTotalVenta, 
					VPEA.TiempoGarantiaPE, CAST(SUM(VPEA.PrecioUnitario) * @FactorCambioCotizacion AS DECIMAL(10,2)) AS PrecioUnitarioMonedaCotizacion, 
					CAST(SUM(VPEA.PrecioUnitario) * @FactorCambioCotizacion AS DECIMAL(10,2)) AS PrecioTotalMonedaCotizacion, -1 AS NumeroOrdenInsertado
			FROM VentasProductosEspecificosAgregados VPEA 
			WHERE VPEA.NumeroAgencia = @NumeroAgencia
			AND VPEA.NumeroVentaProducto = @NumeroVentaProducto
			GROUP BY VPEA.CodigoProducto ,VPEA.TiempoGarantiaPE			
		) TA
		ORDER BY TA.NumeroOrdenInsertado
	END
	ELSE
	BEGIN
		--SELECT dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto , VPD.CodigoProducto, VPD.CantidadVenta, CAST(VPD.PrecioUnitarioVenta AS DECIMAL(10,2)) AS PrecioUnitarioVenta, (VPD.CantidadVenta*VPD.PrecioUnitarioVenta) as PrecioTotalVenta, VPD.TiempoGarantiaVenta, CASE(@CodigoMonedaCotizacion) WHEN (@CodigoMonedaSistema) THEN (VPD.PrecioUnitarioVenta) ELSE CAST((VPD.PrecioUnitarioVenta)* @FactorCambioCotizacion AS DECIMAL(10,2)) END AS PrecioUnitarioMonedaCotizacion, CASE(@CodigoMonedaCotizacion) WHEN (@CodigoMonedaSistema) THEN (VPD.CantidadVenta*VPD.PrecioUnitarioVenta) ELSE CAST((CAST( @FactorCambioCotizacion*VPD.PrecioUnitarioVenta AS DECIMAL(10,2))) * VPD.CantidadVenta AS DECIMAL(10,2)) END AS PrecioTotalMonedaCotizacion
		--FROM VentasProductosDetalle VPD 
		--WHERE VPD.NumeroAgencia = @NumeroAgencia
		--AND VPD.NumeroVentaProducto = @NumeroVentaProducto
		--ORDER BY CodigoProducto
		
		SELECT	dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto , 
				VPD.CodigoProducto, VPD.CantidadVenta, 
				CAST(VPD.PrecioUnitarioVenta AS DECIMAL(10,2)) AS PrecioUnitarioVenta, 
				(VPD.CantidadVenta*VPD.PrecioUnitarioVenta) as PrecioTotalVenta, 
				VPD.TiempoGarantiaVenta, 
				CAST((VPD.PrecioUnitarioVenta)* @FactorCambioCotizacion AS DECIMAL(10,2))AS PrecioUnitarioMonedaCotizacion,
				CAST((CAST( @FactorCambioCotizacion*VPD.PrecioUnitarioVenta AS DECIMAL(10,2))) * VPD.CantidadVenta AS DECIMAL(10,2)) AS PrecioTotalMonedaCotizacion
		FROM VentasProductosDetalle VPD 
		WHERE VPD.NumeroAgencia = @NumeroAgencia
		AND VPD.NumeroVentaProducto = @NumeroVentaProducto
		ORDER BY NumeroOrdenInsertado
	END	
END
GO
--EXEC ListarVentaProductoDetalleReporteIncluidoAgregados 1,23,'S',1, 0

DROP PROCEDURE ListarVentaProductoDetalleReporteIncluidoEspecificos
GO

CREATE PROCEDURE ListarVentaProductoDetalleReporteIncluidoEspecificos
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT,	
	@TipoCalculoAgregado	CHAR(1), -- 'P'->Promedio, 'S'->Sumatoria
	@IncluirAgregados		BIT,
	@EsFactura				BIT
AS
BEGIN
	DECLARE @FactorCambioCotizacion	DECIMAL(10,2),
			@CodigoMonedaSistema	INT,
			@CodigoMonedaCotizacion	INT,
			@CodigoMonedaRegion		INT,
			@FechaHoraVenta			DATETIME
			
	
	SELECT @FechaHoraVenta = FechaHoraVenta, @CodigoMonedaCotizacion = CodigoMoneda FROM VentasProductos WHERE NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroVentaProducto
	SELECT TOP(1) @CodigoMonedaRegion = CodigoMonedaRegion, @CodigoMonedaSistema = CodigoMonedaSistema FROM PCsConfiguraciones WHERE NumeroAgencia = @NumeroAgencia
	
	IF(@EsFactura = 1)
	BEGIN
		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraVenta, @CodigoMonedaRegion, @FactorCambioCotizacion OUTPUT	
		IF(@FactorCambioCotizacion = -1)
			EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaRegion, @FactorCambioCotizacion OUTPUT
		
		IF(@FactorCambioCotizacion = -1 AND @CodigoMonedaSistema = @CodigoMonedaRegion)
			SET @FactorCambioCotizacion = 1
	END
	ELSE
	BEGIN
		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraVenta, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT	
		IF(@FactorCambioCotizacion = -1)
			EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT
		
		IF(@FactorCambioCotizacion = -1 AND @CodigoMonedaSistema = @CodigoMonedaCotizacion)
			SET @FactorCambioCotizacion = 1
	END
	
		
	IF(@IncluirAgregados = 1)	
	BEGIN
		--SELECT dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto , VPD.CodigoProducto, VPD.CantidadVenta, CAST(VPD.PrecioUnitarioVenta AS DECIMAL(10,2)) AS PrecioUnitarioVenta, (VPD.CantidadVenta*VPD.PrecioUnitarioVenta) as PrecioTotalVenta, VPD.TiempoGarantiaVenta, CASE(@CodigoMonedaCotizacion) WHEN (@CodigoMonedaSistema) THEN (VPD.PrecioUnitarioVenta) ELSE CAST((VPD.PrecioUnitarioVenta)* @FactorCambioCotizacion AS DECIMAL(10,2)) END AS PrecioUnitarioMonedaCotizacion, CASE(@CodigoMonedaCotizacion) WHEN (@CodigoMonedaSistema) THEN (VPD.CantidadVenta*VPD.PrecioUnitarioVenta) ELSE CAST((CAST(@FactorCambioCotizacion * VPD.PrecioUnitarioVenta AS DECIMAL(10,2))) * VPD.CantidadVenta AS DECIMAL(10,2)) END AS PrecioTotalMonedaCotizacion
		--FROM VentasProductosDetalle VPD 
		--WHERE VPD.NumeroAgencia = @NumeroAgencia
		--AND VPD.NumeroVentaProducto = @NumeroVentaProducto
		--UNION 
		--SELECT dbo.ObtenerNombreProducto(VPEA.CodigoProducto) as NombreProducto , VPEA.CodigoProducto, COUNT(VPEA.CodigoProducto) AS CantidadVenta, CAST(AVG(VPEA.PrecioUnitario) AS DECIMAL(10,2)) AS PrecioUnitarioVenta, CASE (@TipoCalculoAgregado) WHEN 'P' THEN CAST((COUNT(VPEA.CodigoProducto)*AVG(VPEA.PrecioUnitario)) AS DECIMAL(10,2)) WHEN 'S' THEN CAST(SUM(VPEA.PrecioUnitario)AS DECIMAL(10,2)) END as PrecioTotalVenta, VPEA.TiempoGarantiaPE, CASE(@CodigoMonedaCotizacion) WHEN (@CodigoMonedaSistema) THEN CAST(SUM(VPEA.PrecioUnitario)AS DECIMAL(10,2)) ELSE CAST(SUM(VPEA.PrecioUnitario) * @FactorCambioCotizacion AS DECIMAL(10,2)) END AS PrecioUnitarioMonedaCotizacion, CASE(@CodigoMonedaCotizacion) WHEN (@CodigoMonedaSistema) THEN CAST(SUM(VPEA.PrecioUnitario)AS DECIMAL(10,2)) ELSE CAST(SUM(VPEA.PrecioUnitario) * @FactorCambioCotizacion AS DECIMAL(10,2)) END AS PrecioTotalMonedaCotizacion
		--FROM VentasProductosEspecificosAgregados VPEA 
		--WHERE VPEA.NumeroAgencia = @NumeroAgencia
		--AND VPEA.NumeroVentaProducto = @NumeroVentaProducto
		--GROUP BY VPEA.CodigoProducto ,VPEA.TiempoGarantiaPE
		--ORDER BY CodigoProducto
		
		
		SELECT	dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto , 
				VPD.CodigoProducto, VPD.CantidadVenta, 
				CAST(VPD.PrecioUnitarioVenta AS DECIMAL(10,2)) AS PrecioUnitarioVenta, 
				(VPD.CantidadVenta*VPD.PrecioUnitarioVenta) as PrecioTotalVenta, VPD.TiempoGarantiaVenta, 
				CAST((VPD.PrecioUnitarioVenta)* @FactorCambioCotizacion AS DECIMAL(10,2)) AS PrecioUnitarioMonedaCotizacion, 
				CAST((CAST(@FactorCambioCotizacion * VPD.PrecioUnitarioVenta AS DECIMAL(10,2))) * VPD.CantidadVenta AS DECIMAL(10,2)) AS PrecioTotalMonedaCotizacion, 
				VPE.CodigoProductoEspecifico, VPD.NumeroOrdenInsertado
		FROM VentasProductosDetalle VPD 
		INNER JOIN VentasProductosEspecificos VPE
		ON VPD.NumeroAgencia = VPE.NumeroAgencia
		AND VPE.NumeroVentaProducto = VPD.NumeroVentaProducto
		AND VPD.CodigoProducto = VPE.CodigoProducto
		WHERE VPD.NumeroAgencia = @NumeroAgencia
		AND VPD.NumeroVentaProducto = @NumeroVentaProducto
		UNION 
		
		SELECT	dbo.ObtenerNombreProducto(VPEA.CodigoProducto) as NombreProducto , 
				VPEA.CodigoProducto,  CantidadVenta, PrecioUnitarioVenta, 
				PrecioTotalVenta, VPEA.TiempoGarantiaPE, 
				CAST(PrecioUnitarioVenta * @FactorCambioCotizacion AS DECIMAL(10,2)) AS PrecioUnitarioMonedaCotizacion, 
				CAST(PrecioTotalVenta * @FactorCambioCotizacion AS DECIMAL(10,2)) AS PrecioTotalMonedaCotizacion, 
				CodigoProductoEspecifico, -1 AS NumeroOrdenInsertado
		FROM VentasProductosEspecificosAgregados VPEA 		
		INNER JOIN
		(
			SELECT CodigoProducto, CAST(AVG(VPEA.PrecioUnitario) AS DECIMAL(10,2)) AS PrecioUnitarioVenta, COUNT(VPEA.CodigoProducto) AS CantidadVenta, CASE (@TipoCalculoAgregado) WHEN 'P' THEN CAST((COUNT(VPEA.CodigoProducto)*AVG(VPEA.PrecioUnitario)) AS DECIMAL(10,2)) WHEN 'S' THEN CAST(SUM(VPEA.PrecioUnitario)AS DECIMAL(10,2)) END as PrecioTotalVenta
			FROM VentasProductosEspecificosAgregados VPEA
			WHERE VPEA.NumeroAgencia = @NumeroAgencia
			AND VPEA.NumeroVentaProducto = @NumeroVentaProducto
			GROUP BY CodigoProducto
		
		) AGRUPACION
		ON VPEA.CodigoProducto = AGRUPACION.CodigoProducto		
		WHERE VPEA.NumeroAgencia = @NumeroAgencia
		AND VPEA.NumeroVentaProducto = @NumeroVentaProducto		
		ORDER BY NumeroOrdenInsertado
	END
	ELSE
	BEGIN
		--SELECT dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto , VPD.CodigoProducto, VPD.CantidadVenta, CAST(VPD.PrecioUnitarioVenta AS DECIMAL(10,2)) AS PrecioUnitarioVenta, (VPD.CantidadVenta*VPD.PrecioUnitarioVenta) as PrecioTotalVenta, VPD.TiempoGarantiaVenta, CASE(@CodigoMonedaCotizacion) WHEN (@CodigoMonedaSistema) THEN (VPD.PrecioUnitarioVenta) ELSE CAST((VPD.PrecioUnitarioVenta)* @FactorCambioCotizacion AS DECIMAL(10,2)) END AS PrecioUnitarioMonedaCotizacion, CASE(@CodigoMonedaCotizacion) WHEN (@CodigoMonedaSistema) THEN (VPD.CantidadVenta*VPD.PrecioUnitarioVenta) ELSE CAST((CAST( @FactorCambioCotizacion*VPD.PrecioUnitarioVenta AS DECIMAL(10,2))) * VPD.CantidadVenta AS DECIMAL(10,2)) END AS PrecioTotalMonedaCotizacion
		--FROM VentasProductosDetalle VPD 
		--WHERE VPD.NumeroAgencia = @NumeroAgencia
		--AND VPD.NumeroVentaProducto = @NumeroVentaProducto
		--ORDER BY CodigoProducto
		
		SELECT dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto , VPD.CodigoProducto, VPD.CantidadVenta, CAST(VPD.PrecioUnitarioVenta AS DECIMAL(10,2)) AS PrecioUnitarioVenta, (VPD.CantidadVenta*VPD.PrecioUnitarioVenta) as PrecioTotalVenta, VPD.TiempoGarantiaVenta, CAST((VPD.PrecioUnitarioVenta)* @FactorCambioCotizacion AS DECIMAL(10,2))AS PrecioUnitarioMonedaCotizacion, CAST((CAST( @FactorCambioCotizacion*VPD.PrecioUnitarioVenta AS DECIMAL(10,2))) * VPD.CantidadVenta AS DECIMAL(10,2)) AS PrecioTotalMonedaCotizacion, CodigoProductoEspecifico
		FROM VentasProductosDetalle VPD 
		INNER JOIN VentasProductosEspecificos VPE
		ON VPD.NumeroAgencia = VPE.NumeroAgencia
		AND VPE.NumeroVentaProducto = VPD.NumeroVentaProducto
		AND VPD.CodigoProducto = VPE.CodigoProducto
		WHERE VPD.NumeroAgencia = @NumeroAgencia
		AND VPD.NumeroVentaProducto = @NumeroVentaProducto
		ORDER BY NumeroOrdenInsertado
	END	
END
GO


DROP PROCEDURE ListarVentaProductoDetalleReporteParaRecogerDeAlmacenes
GO

CREATE PROCEDURE ListarVentaProductoDetalleReporteParaRecogerDeAlmacenes
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT,	
	@TipoCalculoAgregado	CHAR(1), -- 'P'->Promedio, 'S'->Sumatoria
	@IncluirAgregados		BIT
AS
BEGIN
	IF(@IncluirAgregados = 1)	
	BEGIN
		SELECT dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto , VPD.CodigoProducto, VPD.CantidadVenta, VPD.CantidadEntregada, CAST(VPD.PrecioUnitarioVenta AS DECIMAL(10,2)) AS PrecioUnitarioVenta, (VPD.CantidadVenta*VPD.PrecioUnitarioVenta) as PrecioTotalVenta, VPD.TiempoGarantiaVenta
		FROM VentasProductosDetalle VPD 
		WHERE VPD.NumeroAgencia = @NumeroAgencia
		AND VPD.NumeroVentaProducto = @NumeroVentaProducto
		UNION 
		SELECT dbo.ObtenerNombreProducto(VPEA.CodigoProducto) as NombreProducto , VPEA.CodigoProducto, COUNT(VPEA.CodigoProducto) AS CantidadVenta, COUNT(VPEA.CodigoProducto) AS CantidadEntregada, CAST(AVG(VPEA.PrecioUnitario) AS DECIMAL(10,2)) AS PrecioUnitarioVenta, CASE (@TipoCalculoAgregado) WHEN 'P' THEN CAST((COUNT(VPEA.CodigoProducto)*AVG(VPEA.PrecioUnitario)) AS DECIMAL(10,2)) WHEN 'S' THEN CAST(SUM(VPEA.PrecioUnitario)AS DECIMAL(10,2)) END as PrecioTotalVenta, VPEA.TiempoGarantiaPE    
		FROM VentasProductosEspecificosAgregados VPEA 
		WHERE VPEA.NumeroAgencia = @NumeroAgencia
		AND VPEA.NumeroVentaProducto = @NumeroVentaProducto
		GROUP BY VPEA.CodigoProducto ,VPEA.TiempoGarantiaPE
		ORDER BY CodigoProducto
	END
	ELSE
	BEGIN
		SELECT dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto , VPD.CodigoProducto, VPD.CantidadVenta, VPD.CantidadEntregada, CAST(VPD.PrecioUnitarioVenta AS DECIMAL(10,2)) AS PrecioUnitarioVenta, (VPD.CantidadVenta*VPD.PrecioUnitarioVenta) as PrecioTotalVenta, VPD.TiempoGarantiaVenta
		FROM VentasProductosDetalle VPD 
		WHERE VPD.NumeroAgencia = @NumeroAgencia
		AND VPD.NumeroVentaProducto = @NumeroVentaProducto
		ORDER BY NumeroOrdenInsertado
	END	
END
GO


DROP PROCEDURE ListarVentaProductoCompuestosDetalleReporte
GO

CREATE PROCEDURE ListarVentaProductoCompuestosDetalleReporte
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT
AS
BEGIN
	
	--SELECT	VPD.NumeroVentaProducto, dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto , 
	--		' ' AS NombreProductoComponente, VPD.CodigoProducto, ' ' AS CodigoProductoComponente,
	--		VPD.CantidadVenta, VPD.CantidadEntregada, 0 AS CantidadVentaCompuesta, 0 as CantidadEntregadaCompuesta,
	--		CAST(VPD.PrecioUnitarioVenta AS DECIMAL(10,2)) AS PrecioUnitarioVenta, 
	--		(VPD.CantidadVenta*VPD.PrecioUnitarioVenta) as PrecioTotalVenta, VPD.TiempoGarantiaVenta
	--FROM VentasProductosDetalle VPD 
	--WHERE VPD.NumeroAgencia = @NumeroAgencia
	--AND VPD.NumeroVentaProducto = @NumeroVentaProducto
		
	--UNION ALL
	
	--SELECT	VPD.NumeroVentaProducto, dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto, 
	--		DBO.ObtenerNombreProducto(PC.CodigoProductoComponente ) AS NombreProductoComponente, 			
	--		VPD.CodigoProducto, PC.CodigoProductoComponente, 
	--		VPD.CantidadVenta, VPD.CantidadEntregada,
	--		VPD.CantidadVenta * PC.Cantidad, VPD.CantidadEntregada * PC.Cantidad, 
	--		CAST(VPD.PrecioUnitarioVenta AS DECIMAL(10,2)) AS PrecioUnitarioVenta, 
	--		(VPD.CantidadVenta*VPD.PrecioUnitarioVenta) as PrecioTotalVenta, VPD.TiempoGarantiaVenta
	--FROM VentasProductosDetalle VPD 
	--INNER JOIN ProductosCompuestos PC
	--ON VPD.CodigoProducto = PC.CodigoProducto
	--WHERE VPD.NumeroAgencia = @NumeroAgencia
	--AND VPD.NumeroVentaProducto = @NumeroVentaProducto
	--ORDER BY 2
	

	SELECT	VPD.NumeroVentaProducto, dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto, 
			DBO.ObtenerNombreProducto(PC.CodigoProductoComponente ) AS NombreProductoComponente, 			
			VPD.CodigoProducto, PC.CodigoProductoComponente, 
			VPD.CantidadVenta, VPD.CantidadEntregada,
			VPD.CantidadVenta * PC.Cantidad AS CantidadVentaCompuesta, 
			VPD.CantidadEntregada * PC.Cantidad as CantidadEntregadaCompuesta, 
			CAST(VPD.PrecioUnitarioVenta AS DECIMAL(10,2)) AS PrecioUnitarioVenta, 
			(VPD.CantidadVenta*VPD.PrecioUnitarioVenta) as PrecioTotalVenta, VPD.TiempoGarantiaVenta
	FROM VentasProductosDetalle VPD 
	LEFT JOIN ProductosCompuestos PC
	ON VPD.CodigoProducto = PC.CodigoProducto
	WHERE VPD.NumeroAgencia = @NumeroAgencia
	AND VPD.NumeroVentaProducto = @NumeroVentaProducto
	ORDER BY 2
	
END
GO



DROP PROCEDURE ListarVentaProductoSimplesDetalleReporte
GO

CREATE PROCEDURE ListarVentaProductoSimplesDetalleReporte
	@NumeroAgencia			INT,
	@NumeroSalidaProducto	INT,
	@EsVenta				BIT
AS
BEGIN
	IF(@EsVenta = 1)
	BEGIN
		SELECT	VPD.NumeroVentaProducto AS NumeroSalida, P.CodigoProducto, P.NombreProducto, VPD.CantidadVenta as CantidadSalida
		FROM VentasProductosDetalle VPD
		INNER JOIN Productos P 
		ON P.CodigoProducto = VPD.CodigoProducto
		WHERE VPD.NumeroAgencia = @NumeroAgencia
		AND VPD.NumeroVentaProducto = @NumeroSalidaProducto
		AND P.ProductoSimple = 1
		UNION ALL
		SELECT	VPD.NumeroVentaProducto, PC.CodigoProductoComponente, 
				DBO.ObtenerNombreProducto(PC.CodigoProductoComponente ) AS NombreProductoComponente, 						
				SUM(VPD.CantidadVenta * PC.Cantidad ) AS CantidadVenta
		FROM VentasProductosDetalle VPD 
		INNER JOIN ProductosCompuestos PC
		ON VPD.CodigoProducto = PC.CodigoProducto
		WHERE VPD.NumeroAgencia = @NumeroAgencia
		AND VPD.NumeroVentaProducto = @NumeroSalidaProducto
		GROUP BY VPD.NumeroVentaProducto, PC.CodigoProductoComponente			
		ORDER BY 2
	END
	ELSE
	BEGIN
		SELECT	VPD.NumeroCotizacionVentaProducto AS NumeroSalida, P.CodigoProducto, 
				P.NombreProducto, VPD.CantidadCotizacionVenta AS CantidadSalida
		FROM CotizacionVentasProductosDeta VPD
		INNER JOIN Productos P 
		ON P.CodigoProducto = VPD.CodigoProducto
		WHERE VPD.NumeroAgencia = @NumeroAgencia
		AND VPD.NumeroCotizacionVentaProducto = @NumeroSalidaProducto
		AND P.ProductoSimple = 1
		UNION ALL
			
		SELECT	VPD.NumeroCotizacionVentaProducto, PC.CodigoProductoComponente, 
				DBO.ObtenerNombreProducto(PC.CodigoProductoComponente ) AS NombreProductoComponente, 						
				SUM(VPD.CantidadCotizacionVenta * PC.Cantidad ) AS CantidadCotizacionVenta
		FROM CotizacionVentasProductosDeta VPD 
		INNER JOIN ProductosCompuestos PC
		ON VPD.CodigoProducto = PC.CodigoProducto
		WHERE VPD.NumeroAgencia = @NumeroAgencia
		AND VPD.NumeroCotizacionVentaProducto = @NumeroSalidaProducto
		GROUP BY VPD.NumeroCotizacionVentaProducto, PC.CodigoProductoComponente			
		ORDER BY 2		
	END
	
		
END
GO
