USE DOBLONES20
GO


IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciaProductosReporte') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciaProductosReporte
	END
GO	
CREATE PROCEDURE ListarTransferenciaProductosReporte
	@NumeroAgencia					INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoTipoEnvioRecepción		CHAR(1)
AS
BEGIN		
	IF(@CodigoTipoEnvioRecepción = 'R')
		SET @NumeroAgencia = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)
		
	DECLARE @FactorCambioCotizacion		DECIMAL(10,2),
			@CodigoMonedaSistema		INT,
			@CodigoMonedaCotizacion		INT,
			@CodigoMonedaRegion			INT,
			@FechaHoraTransferencia		DATETIME,
			@MontoTotalTransferencia	DECIMAL(10,2),
			@CadenaMontoTotalRegion		VARCHAR(255),
			@CadenaMontoTotalTransfe	VARCHAR(255),
			@NombreMonedaRegion			VARCHAR(250),
			@MascaraMonedaRegion		VARCHAR(20),
			@NombreMonedaTransferencia	VARCHAR(250)			
			
	
	SELECT @FechaHoraTransferencia = FechaHoraTransferencia, @CodigoMonedaCotizacion = CodigoMoneda FROM TransferenciasProductos WHERE NumeroAgenciaEmisora = @NumeroAgencia AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
	SELECT TOP(1) @CodigoMonedaRegion = CodigoMonedaRegion, @CodigoMonedaSistema = CodigoMonedaSistema FROM PCsConfiguraciones WHERE NumeroAgencia = @NumeroAgencia	
	SELECT @NombreMonedaRegion = NombreMoneda, @MascaraMonedaRegion = MascaraMoneda FROM Monedas WHERE CodigoMoneda = @CodigoMonedaRegion	
	SELECT @NombreMonedaTransferencia = NombreMoneda FROM Monedas WHERE CodigoMoneda = @CodigoMonedaCotizacion	
	
	
	EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraTransferencia, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT	
		
	IF(@FactorCambioCotizacion = -1)
		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaRegion, @FactorCambioCotizacion OUTPUT
		
	IF(@CodigoMonedaCotizacion <> @CodigoMonedaSistema)
	BEGIN
		IF(@CodigoTipoEnvioRecepción = 'E')
			SELECT @MontoTotalTransferencia = SUM (CAST(@FactorCambioCotizacion * (PrecioUnitarioTransferencia + MontoAdicionalPorGastos) AS DECIMAL(10,2)) * CantidadTransferencia) FROM TransferenciasProductosDetalle
			WHERE NumeroTransferenciaProducto = @NumeroTransferenciaProducto AND NumeroAgenciaEmisora = @NumeroAgencia
		ELSE -- 'R'
			SELECT @MontoTotalTransferencia = SUM (CAST(@FactorCambioCotizacion * (PrecioUnitarioTransferencia + MontoAdicionalPorGastos + MontoAdicionalPorGastosRecepcion) AS DECIMAL(10,2)) * CantidadTransferencia) FROM TransferenciasProductosDetalle
			WHERE NumeroTransferenciaProducto = @NumeroTransferenciaProducto AND NumeroAgenciaEmisora = @NumeroAgencia
	END
	ELSE
	BEGIN
		IF(@CodigoTipoEnvioRecepción = 'E')
			--SELECT @MontoTotalTransferencia = SUM (CAST((PrecioUnitarioTransferencia + MontoAdicionalPorGastos) AS DECIMAL(10,2)) * CantidadTransferencia) FROM TransferenciasProductosDetalle
			SELECT @MontoTotalTransferencia = CAST(SUM (PrecioUnitarioTransferencia * CantidadTransferencia + MontoAdicionalPorGastos) AS DECIMAL(10,2)) FROM TransferenciasProductosDetalle
			WHERE NumeroTransferenciaProducto = @NumeroTransferenciaProducto AND NumeroAgenciaEmisora = @NumeroAgencia
		ELSE -- 'R'
			SELECT @MontoTotalTransferencia = SUM (CAST((PrecioUnitarioTransferencia + MontoAdicionalPorGastos + MontoAdicionalPorGastosRecepcion) AS DECIMAL(10,2)) * CantidadTransferencia) FROM TransferenciasProductosDetalle
			WHERE NumeroTransferenciaProducto = @NumeroTransferenciaProducto AND NumeroAgenciaEmisora = @NumeroAgencia
	END	
		
	EXEC ConvertirMontoNumerico_a_Texto @MontoTotalTransferencia, @NombreMonedaRegion, @CadenaMontoTotalRegion output
	EXEC ConvertirMontoNumerico_a_Texto @MontoTotalTransferencia, @NombreMonedaTransferencia, @CadenaMontoTotalTransfe output
		
		
	SELECT NumeroAgenciaEmisora, AE.NombreAgencia AS NombreAgenciaEmisora, dbo.ObtenerNombreCompleto(AE.DIResponsable) AS ResponsableAgenciaEmisora, PE.NombrePais AS NombrePaisEmisor, DE.NombreDepartamento AS NombreDepartamentoEmisor,
		   NumeroAgenciaRecepctora, AR.NombreAgencia AS NombreAgenciaReceptora, dbo.ObtenerNombreCompleto(AR.DIResponsable) AS ResponsableAgenciaReceptora, PR.NombrePais as NombrePaisReceptor, DR.NombreDepartamento as NombreDepartamentoReceptor,
		   TP.NumeroTransferenciaProducto, U.Nombres + ' ' + U.Paterno + ' ' + U.Materno AS NombreUsuario, FechaHoraTransferencia, 
		   CASE TP.CodigoEstadoTransferencia WHEN 'I' THEN 'INICIADA' WHEN 'A' THEN 'ANULADA' WHEN 'P' THEN 'CON GASTOS PAGADOS' WHEN 'E' THEN 'EMISION Y ENVIO COMPLETO' WHEN 'D' THEN 'PENDIENTE' WHEN 'F' THEN 'FINALIZADA' WHEN 'X' THEN 'FINALIZADA INCOMPLETA' END AS EstadoTransferencia,
		   M.MascaraMoneda, M.NombreMoneda, TP.Observaciones, 
		   @MontoTotalTransferencia AS MontoTotalTransferencia, @NombreMonedaRegion AS NombreMonedaRegion, @MascaraMonedaRegion AS MascaraMonedaRegion, 
		   @CadenaMontoTotalRegion AS CadenaMontoTotalRegion, @CadenaMontoTotalTransfe as CadenaMontoTotalTransferencia,
		   ISNULL(@FactorCambioCotizacion,1) AS FactorCambioCotizacion, TP.MontoTotalTransferencia AS MontoTotalTransferenciaReal
	FROM TransferenciasProductos TP
	INNER JOIN Agencias AE ON TP.NumeroAgenciaEmisora = AE.NumeroAgencia
	INNER JOIN Agencias AR ON TP.NumeroAgenciaRecepctora = AR.NumeroAgencia
	INNER JOIN Usuarios U ON TP.CodigoUsuario = U.CodigoUsuario
	LEFT JOIN Monedas M ON TP.CodigoMoneda = M.CodigoMoneda
	LEFT JOIN Paises PE ON AE.CodigoPais = PE.CodigoPais
	LEFT JOIN Departamentos DE ON AE.CodigoDepartamento = DE.CodigoDepartamento
	LEFT JOIN Paises PR ON AR.CodigoPais = PR.CodigoPais
	LEFT JOIN Departamentos DR ON AR.CodigoDepartamento = DR.CodigoDepartamento
	WHERE TP.NumeroAgenciaEmisora = @NumeroAgencia AND TP.NumeroTransferenciaProducto = @NumeroTransferenciaProducto
	
END
GO


--EXEC ListarTransferenciaProductosReporte 1,1,'E'

--SELECT * FROM TransferenciasProductos WHERE NumeroTransferenciaProducto = 1
--SELECT *, CantidadTransferencia * PrecioUnitarioTransferencia AS MontoTotal FROM TransferenciasProductosDetalle WHERE NumeroTransferenciaProducto = 1

--select * from TransferenciasProductosGastosDetalle
--select * from TransferenciasProductosDetalle WHERE NumeroTransferenciaProducto = 7



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciaProductosDetalleReporte') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciaProductosDetalleReporte
	END
GO	
CREATE PROCEDURE ListarTransferenciaProductosDetalleReporte
	@NumeroAgencia					INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoTipoEnvioRecepción		CHAR(1)
AS
BEGIN		
	IF(@CodigoTipoEnvioRecepción = 'R')
		SET @NumeroAgencia = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)
		
	SELECT TPD.CodigoProducto, dbo.ObtenerNombreProducto(TPD.CodigoProducto) AS NombreProducto, TPD.CantidadTransferencia, TPD.PrecioUnitarioTransferencia, TPD.MontoAdicionalPorGastos, TPD.MontoAdicionalPorGastosRecepcion, 
	TPD.CantidadTransferencia * TPD.PrecioUnitarioTransferencia AS PrecioTotalParcial, CASE WHEN @CodigoTipoEnvioRecepción = 'E' THEN (TPD.CantidadTransferencia * TPD.PrecioUnitarioTransferencia + TPD.MontoAdicionalPorGastos) ELSE (TPD.CantidadTransferencia * TPD.PrecioUnitarioTransferencia) + TPD.MontoAdicionalPorGastos + TPD.MontoAdicionalPorGastosRecepcion END AS PrecioTotal
	FROM TransferenciasProductos TP 
	INNER JOIN TransferenciasProductosDetalle TPD ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
	WHERE TP.NumeroAgenciaEmisora = @NumeroAgencia AND TP.NumeroTransferenciaProducto = @NumeroTransferenciaProducto
END
GO
--exec ListarTransferenciaProductosDetalleReporte 1,1, 'E'




IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciaProductosDetalleRecepcionEnvioReporte') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciaProductosDetalleRecepcionEnvioReporte
	END
GO	
CREATE PROCEDURE ListarTransferenciaProductosDetalleRecepcionEnvioReporte
	@NumeroAgencia					INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoTipoEnvioRecepción		CHAR(1),
	@FechaHoraRecepcionEnvio		DATETIME
AS
BEGIN		
	IF(@CodigoTipoEnvioRecepción = 'R')
	BEGIN
		SET @NumeroAgencia = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)
		
		SELECT TPD.CodigoProducto, dbo.ObtenerNombreProducto(TPD.CodigoProducto) AS NombreProducto, TPD.CantidadTransferencia, TPD.PrecioUnitarioTransferencia, TPD.MontoAdicionalPorGastosRecepcion AS MontoAdicionalGastos,  
				ISNULL(TPDRA.CantidadTotalRecepcionadaEnviada,0) AS CantidadEnviadoRecepcionado, TPDRE.CantidadEnvioRecepcion, TPD.CantidadTransferencia - (ISNULL(TPDRA.CantidadTotalRecepcionadaEnviada,0)+TPDRE.CantidadEnvioRecepcion) AS CantidadFaltante
		FROM TransferenciasProductos TP 
		INNER JOIN TransferenciasProductosDetalle TPD ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
		INNER JOIN TransferenciasProductosDetalleRecepcion TPDRE ON TPD.NumeroAgenciaEmisora = TPDRE.NumeroAgenciaEmisora
		AND TPD.NumeroTransferenciaProducto = TPDRE.NumeroTransferenciaProducto AND TPD.CodigoProducto = TPDRE.CodigoProducto	
		LEFT JOIN 	
		(
			SELECT TPDR1.NumeroAgenciaEmisora, TPDR1.NumeroTransferenciaProducto, TPDR1.CodigoProducto, ISNULL(SUM(TPDR1.CantidadEnvioRecepcion),0) AS CantidadTotalRecepcionadaEnviada
			FROM TransferenciasProductosDetalleRecepcion TPDR1
			WHERE NumeroAgenciaEmisora =@NumeroAgencia AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
			AND FechaHoraEnvioPadre <> @FechaHoraRecepcionEnvio AND CodigoTipoEnvioRecepcion IN ('R','X')
			GROUP BY TPDR1.NumeroAgenciaEmisora, TPDR1.NumeroTransferenciaProducto, TPDR1.CodigoProducto
		) TPDRA
		ON TPDRE.NumeroAgenciaEmisora = TPDRA.NumeroAgenciaEmisora	
		AND TPDRE.NumeroTransferenciaProducto = TPDRA.NumeroTransferenciaProducto
		AND TPDRE.CodigoProducto = TPDRA.CodigoProducto
		WHERE TP.NumeroAgenciaEmisora = @NumeroAgencia AND TP.NumeroTransferenciaProducto = @NumeroTransferenciaProducto
		AND TPDRE.FechaHoraEnvioRecepcion = @FechaHoraRecepcionEnvio
	END
	ELSE		
	BEGIN	
		SELECT TPD.CodigoProducto, dbo.ObtenerNombreProducto(TPD.CodigoProducto) AS NombreProducto, TPD.CantidadTransferencia, TPD.PrecioUnitarioTransferencia, TPD.MontoAdicionalPorGastos AS MontoAdicionalGastos,  
			ISNULL(TPDRA.CantidadTotalRecepcionadaEnviada,0) AS CantidadEnviadoRecepcionado, TPDRE.CantidadEnvioRecepcion, TPD.CantidadTransferencia - (ISNULL(TPDRA.CantidadTotalRecepcionadaEnviada,0)+TPDRE.CantidadEnvioRecepcion) AS CantidadFaltante
		FROM TransferenciasProductos TP 
		INNER JOIN TransferenciasProductosDetalle TPD ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
		INNER JOIN TransferenciasProductosDetalleRecepcion TPDRE ON TPD.NumeroAgenciaEmisora = TPDRE.NumeroAgenciaEmisora
		AND TPD.NumeroTransferenciaProducto = TPDRE.NumeroTransferenciaProducto AND TPD.CodigoProducto = TPDRE.CodigoProducto	
		LEFT JOIN 	
		(
			SELECT TPDR1.NumeroAgenciaEmisora, TPDR1.NumeroTransferenciaProducto, TPDR1.CodigoProducto, ISNULL(SUM(TPDR1.CantidadEnvioRecepcion),0) AS CantidadTotalRecepcionadaEnviada
			FROM TransferenciasProductosDetalleRecepcion TPDR1
			WHERE NumeroAgenciaEmisora =@NumeroAgencia AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
			AND FechaHoraEnvioRecepcion <> @FechaHoraRecepcionEnvio AND CodigoTipoEnvioRecepcion IN ('E')
			GROUP BY TPDR1.NumeroAgenciaEmisora, TPDR1.NumeroTransferenciaProducto, TPDR1.CodigoProducto
		) TPDRA
		ON TPDRE.NumeroAgenciaEmisora = TPDRA.NumeroAgenciaEmisora	
		AND TPDRE.NumeroTransferenciaProducto = TPDRA.NumeroTransferenciaProducto
		AND TPDRE.CodigoProducto = TPDRA.CodigoProducto
		WHERE TP.NumeroAgenciaEmisora = @NumeroAgencia AND TP.NumeroTransferenciaProducto = @NumeroTransferenciaProducto
		AND TPDRE.FechaHoraEnvioRecepcion = @FechaHoraRecepcionEnvio
	END
END
GO
--EXEC ListarTransferenciaProductosDetalleRecepcionEnvioReporte 3,2,'R','20100721 16:14:02.193'
--EXEC ListarTransferenciaProductosDetalleRecepcionEnvioReporte 1,1,'E','20100721 07:45:25.727'
--EXEC ListarTransferenciaProductosDetalleRecepcionEnvioReporte 3,2,'E',null

IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte
	END
GO	
CREATE PROCEDURE ListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte
	@NumeroAgencia					INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoTipoEnvioRecepción		CHAR(1)
AS
BEGIN		
	IF(@CodigoTipoEnvioRecepción = 'R')
		SET @NumeroAgencia = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)
	
	IF(@CodigoTipoEnvioRecepción IS NULL)	
	BEGIN
		IF NOT EXISTS(SELECT * FROM TransferenciasProductos WHERE NumeroTransferenciaProducto = @NumeroTransferenciaProducto AND NumeroAgenciaEmisora = @NumeroAgencia)
			SET @NumeroAgencia = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)
	END
	SELECT CodigoProducto, dbo.ObtenerNombreProducto(CodigoProducto) AS NombreProducto, FechaHoraEnvioRecepcion, CantidadEnvioRecepcion, CASE WHEN (@CodigoTipoEnvioRecepción IS NULL OR @CodigoTipoEnvioRecepción = '') THEN (CASE CodigoTipoEnvioRecepcion WHEN 'E' THEN 'E' ELSE 'R' END) ELSE @CodigoTipoEnvioRecepción END AS CodigoTipoEnvioRecepcion,
	CASE CodigoTipoEnvioRecepcion WHEN 'E' THEN 'ENVIO' WHEN 'X' THEN 'RECEPCION PARCIAL' ELSE 'RECEPCION COMPLETA' END AS TipoEnvioRecepcion
	FROM TransferenciasProductosDetalleRecepcion
	WHERE NumeroAgenciaEmisora = @NumeroAgencia AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
	AND CodigoTipoEnvioRecepcion LIKE (CASE WHEN @CodigoTipoEnvioRecepción IS NULL THEN '%[REX]%' WHEN @CodigoTipoEnvioRecepción = 'E' THEN 'E' ELSE '[RX]' END )
	ORDER BY 5, 3, 1
END
GO

--EXEC ListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte 1,2,NULL
--EXEC ListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte 3,2,NULL


IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciaProductosEspecificosReporte') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciaProductosEspecificosReporte
	END
GO	
CREATE PROCEDURE ListarTransferenciaProductosEspecificosReporte
	@NumeroAgencia					INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoTipoEnvioRecepción		CHAR(1),
	@FechaHoraEnvioRecepcion		DATETIME	
AS
BEGIN		
	IF(@CodigoTipoEnvioRecepción = 'R')
		SET @NumeroAgencia = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)	
	
	IF(@FechaHoraEnvioRecepcion IS NULL)
	BEGIN
		SELECT TPE.CodigoProducto, dbo.ObtenerNombreProducto(TPE.CodigoProducto) AS NombreProducto, TPE.CodigoProductoEspecifico, CASE TPE.CodigoEstadoRecepcion WHEN 'A' THEN 'BUEN ESTADO' WHEN 'R' THEN 'REPARACION O DAÑADO' WHEN 'B' THEN 'DE BAJA' WHEN NULL THEN 'ENVIADO' ELSE 'ENVIADO' END AS EstadoRecepcion
		FROM TransferenciasProductosEspecificos TPE
		WHERE TPE.NumeroAgenciaEmisora = @NumeroAgencia
		AND TPE.NumeroTransferenciaProducto = @NumeroTransferenciaProducto
	END
	ELSE
	BEGIN
		IF(@CodigoTipoEnvioRecepción = 'R')
		BEGIN		
			SELECT TPE.CodigoProducto, dbo.ObtenerNombreProducto(TPE.CodigoProducto) AS NombreProducto, TPE.CodigoProductoEspecifico, CASE TPE.CodigoEstadoRecepcion WHEN 'A' THEN 'BUEN ESTADO' WHEN 'R' THEN 'REPARACION O DAÑADO' WHEN 'B' THEN 'DE BAJA'  WHEN NULL THEN 'ENVIADO' ELSE 'ENVIADO' END AS EstadoRecepcion
			FROM TransferenciasProductosEspecificos TPE
			WHERE TPE.NumeroAgenciaEmisora = @NumeroAgencia
			AND TPE.NumeroTransferenciaProducto = @NumeroTransferenciaProducto
			AND FechaHoraRecepcion = @FechaHoraEnvioRecepcion
		END
		ELSE			
		BEGIN
			SELECT TPE.CodigoProducto, dbo.ObtenerNombreProducto(TPE.CodigoProducto) AS NombreProducto, TPE.CodigoProductoEspecifico, CASE TPE.CodigoEstadoRecepcion WHEN 'A' THEN 'BUEN ESTADO' WHEN 'R' THEN 'REPARACION O DAÑADO' WHEN 'B' THEN 'DE BAJA'  WHEN NULL THEN 'ENVIADO' ELSE 'ENVIADO' END AS EstadoRecepcion
			FROM TransferenciasProductosEspecificos TPE
			WHERE TPE.NumeroAgenciaEmisora = @NumeroAgencia
			AND TPE.NumeroTransferenciaProducto = @NumeroTransferenciaProducto
			AND FechaHoraEnvio = @FechaHoraEnvioRecepcion
		END
	END	
END
GO




IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciaProductosEspecificosGeneralReporte') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciaProductosEspecificosGeneralReporte
	END
GO	
CREATE PROCEDURE ListarTransferenciaProductosEspecificosGeneralReporte
	@NumeroAgencia					INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoTipoEnvioRecepción		CHAR(1)	
AS
BEGIN		
	IF(@CodigoTipoEnvioRecepción = 'R')
		SET @NumeroAgencia = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)

	SELECT TPE.CodigoProducto, dbo.ObtenerNombreProducto(TPE.CodigoProducto) AS NombreProducto, TPE.CodigoProductoEspecifico, 
	---- 'A' -> Alta, 'B'->Baja, 'R'-> Reparación ,'V'-> Vendido, 'T'-> Transferencia
	CASE TPE.Entregado WHEN 0 THEN 'Enviado' ELSE 'Recepcionado' END AS Entregado,
	CASE TPE.CodigoEstadoRecepcion WHEN 'A' THEN 'Recepcion Correcta' WHEN 'B' THEN 'Recepcion InCorrecta' WHEN 'R' THEN 'Recepcion en Reparacion' ELSE 'Pendiente' END AS EstadoRecepcion,
	FechaHoraEnvio, FechaHoraRecepcion
	FROM TransferenciasProductosEspecificos TPE
	WHERE NumeroAgenciaEmisora = @NumeroAgencia 
	AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
END
GO