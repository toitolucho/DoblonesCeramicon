USE Doblones20
GO

DROP FUNCTION EsPosibleAsignarCreditoAVentaProductos
GO

CREATE FUNCTION EsPosibleAsignarCreditoAVentaProductos(
		@NumeroVentaProducto	INT, 
		@NumeroCredito			INT, 
		@NumeroAgencia			INT, 
		@ProductosDetalleXML	TEXT, 
		@MontoTotalVenta		DECIMAL(10,2))
RETURNS VARCHAR(4000)
WITH ENCRYPTION
AS
BEGIN
	DECLARE @RespuestaAfimativa	VARCHAR(4000),
			@CodigoTipoCredito	CHAR(1),
			@NumeroCotizacion	INT,
			@MontoTotalCredito	DECIMAL(10,2)
	DECLARE	@TProductosDetalle TABLE
	(
		CodigoProducto		CHAR(15),
		Cantidad			INT,
		PrecioUnitario		DECIMAL(10,2)
	)
			
	SET @RespuestaAfimativa = NULL
	IF(EXISTS (SELECT * FROM CREDITOS WHERE NumeroCredito = @NumeroCredito))			
	BEGIN
	
		DECLARE @punteroXMLProductosDetalle INT			
					
		EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @ProductosDetalleXML
		
		INSERT INTO @TProductosDetalle (CodigoProducto, Cantidad, PrecioUnitario)
		SELECT  CodigoProducto,				
				Cantidad,				
				Precio				
		FROM  OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)
		WITH (CodigoProducto	VARCHAR(15),
			  Cantidad			INT,				  
			  Precio			DECIMAL(10,2)
		) 
		EXEC sp_xml_removedocument @punteroXMLProductosDetalle
		
		SELECT @CodigoTipoCredito = CodigoTipoCredito, @NumeroCotizacion = NumeroCotizacion, @MontoTotalCredito = MontoDisponible
		FROM CREDITOS
		WHERE NumeroCredito = @NumeroCredito
		
		IF(@NumeroVentaProducto IS NULL) -- CUANDO SE QUIERE ASIGNAR DIRECTAMENTE UN CREDITO A UNA VENTA QUE RECIEN SE VA HA CREAR
		BEGIN
			IF(@CodigoTipoCredito IN ('T','P'))--total, o por el Parcial de la Venta
			BEGIN
				--SI EXISTE UN PRODUCTO QUE NO ESTE DENTRO DE LA COTIZACION
				IF(EXISTS ( SELECT CodigoProducto 
							FROM @TProductosDetalle
							WHERE CodigoProducto NOT IN (SELECT CodigoProducto FROM dbo.CotizacionVentasProductosDeta
													 WHERE NumeroCotizacionVentaProducto = @NumeroCotizacion
													 and NumeroAgencia = @NumeroAgencia))													 
				OR EXISTS ( -- EXISTE UN ARTICULO CUYA CANTIDAD SEA DISTINTA A LA DE LA COTIZACION, O EL PRECIO SEA DISTINTO
					SELECT *
					FROM @TProductosDetalle PD
					INNER JOIN CotizacionVentasProductosDeta CVPD
					ON PD.CodigoProducto = CVPD.CodigoProducto
					AND CVPD.NumeroCotizacionVentaProducto = @NumeroCotizacion
					WHERE PD.Cantidad <> CVPD.CantidadCotizacionVenta
					OR PD.PrecioUnitario <> CVPD.PrecioUnitarioCotizacionVenta )
					)
				BEGIN
					SET @RespuestaAfimativa = 'El credito que quiere asignar a la venta Actual, corresponde a la Cotización Nro ' + RTRIM(CAST(@NumeroCotizacion AS CHAR(100)))+ ', la misma no concuerda en Cantidad o Precios con la Venta Actual'	
				END
				ELSE	
					IF(@CodigoTipoCredito = 'T')		
						SET @RespuestaAfimativa  = CASE WHEN @MontoTotalVenta =  @MontoTotalCredito THEN NULL ELSE 'El Monto Total de la Venta no coicide con el Monto Disponible del Credito Seleccionado' END
					ELSE
						SET @RespuestaAfimativa = NULL
			END		
			
			
			IF(@CodigoTipoCredito = 'L')
			BEGIN
				SET @RespuestaAfimativa  = CASE WHEN @MontoTotalVenta >  @MontoTotalCredito THEN NULL ELSE 'El Monto Total de la Venta supera el Monto Disponible del Credito Seleccionado' END
			END
			
		END
		ELSE-- CUANDO SE VA A MODIFICAR UNA VENTA Y LA CONVERTIREMOS A CREDITO
		BEGIN
			IF(@CodigoTipoCredito IN ('T','P'))--total, o por el Parcial de la Venta
			BEGIN
				--SI EXISTE UN PRODUCTO QUE NO ESTE DENTRO DE LA COTIZACION
				IF(EXISTS ( SELECT CodigoProducto 
							FROM @TProductosDetalle
							WHERE CodigoProducto NOT IN (SELECT CodigoProducto FROM dbo.CotizacionVentasProductosDeta
													 WHERE NumeroCotizacionVentaProducto = @NumeroCotizacion
													 and NumeroAgencia = @NumeroAgencia))													 
				OR EXISTS ( -- EXISTE UN ARTICULO CUYA CANTIDAD SEA DISTINTA A LA DE LA COTIZACION, O EL PRECIO SEA DISTINTO
					SELECT *
					FROM @TProductosDetalle PD
					INNER JOIN CotizacionVentasProductosDeta CVPD
					ON PD.CodigoProducto = CVPD.CodigoProducto
					AND CVPD.NumeroCotizacionVentaProducto = @NumeroCotizacion
					WHERE PD.Cantidad <> CVPD.CantidadCotizacionVenta
					OR PD.PrecioUnitario <> CVPD.PrecioUnitarioCotizacionVenta )
					)
				BEGIN
					SET @RespuestaAfimativa = 'El credito que quiere asignar a la venta Actual, corresponde a la Cotización Nro ' + RTRIM(CAST(@NumeroCotizacion AS CHAR(100)))+ ', la misma no concuerda en Cantidad o Precios con la Venta Actual'	
				END
				ELSE	
					IF(@CodigoTipoCredito = 'T')		
						SET @RespuestaAfimativa  = CASE WHEN @MontoTotalVenta =  @MontoTotalCredito THEN NULL ELSE 'El Monto Total de la Venta no coicide con el Monto Disponible del Credito Seleccionado' END
					ELSE
						SET @RespuestaAfimativa = NULL
			END		
			
			
			IF(@CodigoTipoCredito = 'L')
			BEGIN
				SET @RespuestaAfimativa  = CASE WHEN @MontoTotalVenta >  @MontoTotalCredito THEN NULL ELSE 'El Monto Total de la Venta supera el Monto Disponible del Credito Seleccionado' END
			END
		END
	END
	ELSE
		SET @RespuestaAfimativa = 'El Codigo de Autorización no existe dentro de la Base de Datos'
	
	
	RETURN @RespuestaAfimativa
END
GO