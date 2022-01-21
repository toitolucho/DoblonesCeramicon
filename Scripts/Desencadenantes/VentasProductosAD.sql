USE Doblones20
GO

IF OBJECT_ID ('TActualizarCamposDetalleVentaProductos','TR') IS NOT NULL
   DROP TRIGGER TActualizarCamposDetalleVentaProductos;
GO

CREATE TRIGGER TActualizarCamposDetalleVentaProductos ON dbo.VentasProductos
AFTER UPDATE, INSERT
AS
	DECLARE @CodigoEstadoVenta		CHAR(1),
			@NumeroAgencia			INT,
			@NumeroVentaProducto	INT,
			@CodigoTipoVenta		CHAR(1),
			@NumeroCredito			INT	
	
			
	SELECT	@CodigoEstadoVenta = CodigoEstadoVenta, @NumeroAgencia = NumeroAgencia,
			@NumeroVentaProducto = NumeroVentaProducto,
			@CodigoTipoVenta = CodigoTipoVenta,
			@NumeroCredito = NumeroCredito
	FROM INSERTED
	
	
	
	IF(@CodigoEstadoVenta IN ('E','D','C'))
	BEGIN
		IF(NOT EXISTS
			(
				SELECT *	
				FROM VentasProductosDetalle VPD
				LEFT JOIN
				(
					SELECT VPE.NumeroAgencia, VPE.NumeroVentaProducto, VPE.CodigoProducto, SUM(VPE.CantidadEntregada) AS CantidadEntregada
					FROM VentasProductosDetalleEntrega VPE	
					WHERE VPE.NumeroAgencia = @NumeroAgencia
					AND VPE.NumeroVentaProducto = @NumeroVentaProducto
					GROUP BY VPE.NumeroAgencia, VPE.NumeroVentaProducto, VPE.CodigoProducto					
				) VPDE
				ON VPD.CodigoProducto = VPDE.CodigoProducto
				AND VPD.NumeroAgencia = VPDE.NumeroAgencia
				AND VPD.NumeroVentaProducto = VPDE.NumeroVentaProducto
				WHERE VPD.CantidadVenta <> ISNULL(VPDE.CantidadEntregada,0)
				AND VPD.NumeroAgencia = @NumeroAgencia
				AND VPD.NumeroVentaProducto = @NumeroVentaProducto
			)
		)
			IF(@CodigoTipoVenta = 'N')
				UPDATE VentasProductos
					SET CodigoEstadoVenta = 'F'
				WHERE NumeroAgencia = @NumeroAgencia
				AND NumeroVentaProducto = @NumeroVentaProducto
			ELSE IF(@CodigoTipoVenta = 'T')
				UPDATE VentasProductos
					SET CodigoEstadoVenta = 'C'
				WHERE NumeroAgencia = @NumeroAgencia
				AND NumeroVentaProducto = @NumeroVentaProducto
	END 
	
	DECLARE @FactorCambioCotizacion		DECIMAL(10,2),
				@CodigoMonedaSistema		INT,
				@CodigoMonedaCotizacion		INT,
				@FechaHoraVenta				DATETIME,
				@MontoTotalVenta			DECIMAL(10,2),
				@MontoTotalVentaAntiguo		DECIMAL(10,2),
				@CodigoTipoCredito			CHAR(1),
				@EsConFactura				BIT,
				@CodigoEstadoAntiguo		CHAR(1)			
	
	--PARA LOS CREDITOS	DE ACTUALIZACIÓN
	SELECT @CodigoEstadoAntiguo = CodigoEstadoVenta
	FROM DELETED (NOLOCK) 	
	--CUANDO LA VENTA SE INICIA POR PRIMERA VEZ
	IF(@NumeroCredito IS NOT NULL AND @CodigoEstadoVenta IN ('I') and @CodigoEstadoAntiguo IS NULL)
	BEGIN		
		
		SELECT @FechaHoraVenta = FechaHoraVenta, @CodigoMonedaCotizacion = CodigoMoneda, @MontoTotalVenta = MontoTotalVenta 
		FROM INSERTED
		SELECT TOP(1) @CodigoMonedaSistema = CodigoMonedaSistema 
		FROM PCsConfiguraciones 
		WHERE NumeroAgencia = @NumeroAgencia
		
		SELECT @EsConFactura = CASE WHEN NumeroFactura IS NULL THEN 0 ELSE 1 END 
		FROM VentasProductos WHERE NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroVentaProducto
	
								
		SELECT @CodigoTipoCredito = C.CodigoTipoCredito
		FROM Creditos C
		WHERE C.NumeroCredito = @NumeroCredito		
		
		IF(@CodigoMonedaSistema = @CodigoMonedaCotizacion )
		BEGIN
			IF(@CodigoTipoCredito = 'L' or @CodigoTipoCredito = 'T') --LibreDisposicion
				UPDATE Creditos
					SET MontoDisponible = MontoDisponible - @MontoTotalVenta
				WHERE NumeroCredito = @NumeroCredito
			ELSE -- @CodigoTipoCredito = 'P'
				UPDATE Creditos
					SET MontoDisponible = 0
				WHERE NumeroCredito = @NumeroCredito
		END
		ELSE --para cuando el credito se hace en otra moneda
		BEGIN
			
			EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraVenta, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT		
			IF(@FactorCambioCotizacion = -1)
				EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT		
			
			IF(@CodigoTipoCredito = 'L' or @CodigoTipoCredito = 'T') --LibreDisposicion, Total
				UPDATE Creditos
					SET MontoDisponible = MontoDisponible - (@MontoTotalVenta * @FactorCambioCotizacion)
				WHERE NumeroCredito = @NumeroCredito
			ELSE -- @CodigoTipoCredito = 'P'
				UPDATE Creditos
					SET MontoDisponible = 0
				WHERE NumeroCredito = @NumeroCredito
		END
	END	
	
	IF(@NumeroCredito IS NOT NULL AND @CodigoEstadoVenta IN ('P') and @CodigoEstadoAntiguo IN ('P'))
	BEGIN		
		
		SELECT @FechaHoraVenta = FechaHoraVenta, @CodigoMonedaCotizacion = CodigoMoneda, @MontoTotalVenta = MontoTotalVenta 
		FROM INSERTED
		
		SELECT @MontoTotalVentaAntiguo = MontoTotalVenta 
		FROM DELETED (NOLOCK)
		
		
		IF(@MontoTotalVentaAntiguo <> @MontoTotalVenta)
		BEGIN
					
			SELECT TOP(1) @CodigoMonedaSistema = CodigoMonedaSistema 
			FROM PCsConfiguraciones 
			WHERE NumeroAgencia = @NumeroAgencia
			
			SELECT @EsConFactura = CASE WHEN NumeroFactura IS NULL THEN 0 ELSE 1 END 
			FROM INSERTED
		
									
			SELECT @CodigoTipoCredito = C.CodigoTipoCredito
			FROM Creditos C
			WHERE C.NumeroCredito = @NumeroCredito		
			
			IF(@CodigoMonedaSistema = @CodigoMonedaCotizacion )
			BEGIN
				IF(@CodigoTipoCredito = 'L' or @CodigoTipoCredito = 'T') --LibreDisposicion
					UPDATE Creditos
						SET MontoDisponible = MontoDisponible + @MontoTotalVentaAntiguo - @MontoTotalVenta
					WHERE NumeroCredito = @NumeroCredito
				ELSE -- @CodigoTipoCredito = 'P'
					UPDATE Creditos
						SET MontoDisponible = 0
					WHERE NumeroCredito = @NumeroCredito
			END
			ELSE --para cuando el credito se hace en otra moneda
			BEGIN
				
				EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraVenta, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT		
				IF(@FactorCambioCotizacion = -1)
					EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT		
				
				IF(@CodigoTipoCredito = 'L' or @CodigoTipoCredito = 'T') --LibreDisposicion, Total
					UPDATE Creditos
						SET MontoDisponible = MontoDisponible - (@MontoTotalVentaAntiguo * @FactorCambioCotizacion) - (@MontoTotalVenta * @FactorCambioCotizacion)
					WHERE NumeroCredito = @NumeroCredito
				ELSE -- @CodigoTipoCredito = 'P'
					UPDATE Creditos
						SET MontoDisponible = 0
					WHERE NumeroCredito = @NumeroCredito
			END
		END	
		
END
		IF(@NumeroCredito IS NOT NULL AND @CodigoEstadoVenta IN ('A'))
		BEGIN
			SELECT @FechaHoraVenta = FechaHoraVenta, @CodigoMonedaCotizacion = CodigoMoneda, @MontoTotalVenta = MontoTotalVenta 
			FROM INSERTED
			
			SELECT TOP(1) @CodigoMonedaSistema = CodigoMonedaSistema 
			FROM PCsConfiguraciones 
			WHERE NumeroAgencia = @NumeroAgencia
			
			SELECT @EsConFactura = CASE WHEN NumeroFactura IS NULL THEN 0 ELSE 1 END 
			FROM INSERTED
		
									
			SELECT @CodigoTipoCredito = C.CodigoTipoCredito
			FROM Creditos C
			WHERE C.NumeroCredito = @NumeroCredito		
			
			IF(@CodigoMonedaSistema = @CodigoMonedaCotizacion )
			BEGIN
				IF(@CodigoTipoCredito = 'L' or @CodigoTipoCredito = 'T') --LibreDisposicion
					UPDATE Creditos
						SET MontoDisponible = MontoDisponible + @MontoTotalVenta					
					WHERE NumeroCredito = @NumeroCredito
				ELSE -- @CodigoTipoCredito = 'P'
					UPDATE Creditos
						SET MontoDisponible = @MontoTotalVenta
					WHERE NumeroCredito = @NumeroCredito
			END
			ELSE --para cuando el credito se hace en otra moneda
			BEGIN
				
				EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraVenta, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT		
				IF(@FactorCambioCotizacion = -1)
					EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT		
				
				IF(@CodigoTipoCredito = 'L' or @CodigoTipoCredito = 'T') --LibreDisposicion, Total
					UPDATE Creditos
						SET MontoDisponible = MontoDisponible + (@MontoTotalVenta * @FactorCambioCotizacion)
					WHERE NumeroCredito = @NumeroCredito
				ELSE -- @CodigoTipoCredito = 'P'
					UPDATE Creditos
						SET MontoDisponible = (@MontoTotalVenta * @FactorCambioCotizacion)
					WHERE NumeroCredito = @NumeroCredito
			END
		END	
		
	
GO
