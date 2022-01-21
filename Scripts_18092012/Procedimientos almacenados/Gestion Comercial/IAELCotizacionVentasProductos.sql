USE DOBLONES20
GO



DROP PROCEDURE InsertarCotizacionVentaProducto
GO
CREATE PROCEDURE InsertarCotizacionVentaProducto
	@NumeroAgencia					INT,
	@CodigoCliente					INT,
	@CodigoUsuario					INT,
	@FechaHoraCotizacion			DATETIME,
	@ValidezOferta					INT,
	@TiempoEntrega					INT,
	@CodigoEstadoCotizacion			CHAR(1),
	@CotizacionVendida				BIT,
	@CodigoMonedaCotizacionVenta	CHAR(2),
	@CodigoTipoCotizacion			CHAR(1),
	@ConFactura						BIT,
	@Observaciones					TEXT,
	@MontoTotalCotizacion			DECIMAL(10,2),
	@MontoTotalCotizacionProductos	DECIMAL(10,2),
	@MontoTotalCotizacionServicios	DECIMAL(10,2),
	@NumeroVentaServicio			INT
AS
BEGIN
	INSERT INTO dbo.CotizacionVentasProductos(NumeroAgencia,CodigoCliente, CodigoUsuario, FechaHoraCotizacion,ValidezOferta,TiempoEntrega,CodigoEstadoCotizacion,CotizacionVendida,CodigoMonedaCotizacionVenta, CodigoTipoCotizacion, ConFactura, Observaciones, MontoTotalCotizacion, MontoTotalCotizacionProductos, MontoTotalCotizacionServicios, NumeroVentaServicio)
	VALUES (@NumeroAgencia, @CodigoCliente, @CodigoUsuario, @FechaHoraCotizacion,@ValidezOferta,@TiempoEntrega,@CodigoEstadoCotizacion,@CotizacionVendida,@CodigoMonedaCotizacionVenta, @CodigoTipoCotizacion, @ConFactura, @Observaciones, @MontoTotalCotizacion, @MontoTotalCotizacionProductos, @MontoTotalCotizacionServicios, @NumeroVentaServicio)
END
GO



DROP PROCEDURE ActualizarCotizacionVentaProducto
GO
CREATE PROCEDURE ActualizarCotizacionVentaProducto
	@NumeroAgencia					INT,
	@NumeroCotizacionVentaProducto	INT,
	@CodigoCliente					INT,
	@CodigoUsuario					INT,
	@FechaHoraCotizacion			DATETIME,
	@ValidezOferta					INT,
	@TiempoEntrega					INT,
	@CodigoEstadoCotizacion			CHAR(1),
	@CotizacionVendida				BIT,
	@CodigoMonedaCotizacionVenta	CHAR(2),
	@CodigoTipoCotizacion			CHAR(1),
	@ConFactura						BIT,
	@Observaciones					TEXT,
	@MontoTotalCotizacion			DECIMAL(10,2),
	@MontoTotalCotizacionProductos	DECIMAL(10,2),
	@MontoTotalCotizacionServicios	DECIMAL(10,2),
	@NumeroVentaServicio			INT
AS
BEGIN
	UPDATE 	dbo.CotizacionVentasProductos
	SET						
		CodigoCliente						= @CodigoCliente,
		CodigoUsuario						= @CodigoUsuario,
		FechaHoraCotizacion					= @FechaHoraCotizacion,
		ValidezOferta						= @ValidezOferta,
		TiempoEntrega						= @TiempoEntrega,
		CodigoEstadoCotizacion				= @CodigoEstadoCotizacion,
		CotizacionVendida					= @CotizacionVendida,
		CodigoMonedaCotizacionVenta			= @CodigoMonedaCotizacionVenta,
		CodigoTipoCotizacion				= @CodigoTipoCotizacion,
		ConFactura							= @ConFactura,
		Observaciones						= @Observaciones,
		MontoTotalCotizacion				= @MontoTotalCotizacion,
		MontoTotalCotizacionProductos		= @MontoTotalCotizacionProductos,
		MontoTotalCotizacionServicios		= @MontoTotalCotizacionServicios,
		NumeroVentaServicio					= @NumeroVentaServicio
	WHERE	(NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto) 
		AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE EliminarCotizacionVentaProducto
GO
CREATE PROCEDURE EliminarCotizacionVentaProducto
	@NumeroAgencia					INT,
	@NumeroCotizacionVentaProducto	INT
AS
BEGIN
	DELETE 
	FROM dbo.CotizacionVentasProductos
	WHERE	(NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto) 
		AND (NumeroAgencia = @NumeroAgencia)
			
END
GO



DROP PROCEDURE ListarCotizacionVentasProductos
GO
CREATE PROCEDURE ListarCotizacionVentasProductos
	@NumeroAgencia	INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroCotizacionVentaProducto, CodigoCliente, CodigoUsuario, FechaHoraCotizacion, ValidezOferta, TiempoEntrega, CodigoEstadoCotizacion, CotizacionVendida, CodigoMonedaCotizacionVenta, CodigoTipoCotizacion, ConFactura, Observaciones, MontoTotalCotizacion, MontoTotalCotizacionProductos, MontoTotalCotizacionServicios, NumeroVentaServicio
	FROM dbo.CotizacionVentasProductos
	WHERE (NumeroAgencia = @NumeroAgencia)
	ORDER BY NumeroAgencia, NumeroCotizacionVentaProducto
END
GO



DROP PROCEDURE ObtenerCotizacionVentaProducto
GO
CREATE PROCEDURE ObtenerCotizacionVentaProducto
	@NumeroAgencia					INT,
	@NumeroCotizacionVentaProducto	INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroCotizacionVentaProducto, CodigoCliente, CodigoUsuario, FechaHoraCotizacion, ValidezOferta, TiempoEntrega, CodigoEstadoCotizacion, CotizacionVendida, CodigoMonedaCotizacionVenta, CodigoTipoCotizacion, ConFactura, Observaciones, MontoTotalCotizacion, MontoTotalCotizacionProductos, MontoTotalCotizacionServicios, NumeroVentaServicio
	FROM dbo.CotizacionVentasProductos
	WHERE	(NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto) 
		AND (NumeroAgencia = @NumeroAgencia)
END
GO



--DROP PROCEDURE ObtenerCotizacionVentasProductos
--GO
--CREATE PROCEDURE ObtenerCotizacionVentasProductos	
--AS
--BEGIN
--	SELECT NumeroAgencia,NumeroCotizacionVentaProducto,CodigoCliente,FechaHoraCotizacion,ValidezOferta,TiempoEntrega,CodigoEstadoCotizacion,CotizacionVendida,CodigoMonedaCotizacionVenta,Observaciones
--	FROM dbo.CotizacionVentasProductos	
--END
--GO



DROP PROCEDURE InsertarCotizacionVentaProductoXMLDetalle
GO
CREATE PROCEDURE InsertarCotizacionVentaProductoXMLDetalle
	@NumeroAgencia					INT,
	@CodigoCliente					INT,
	@CodigoUsuario					INT,
	@FechaHoraCotizacion			DATETIME,
	@ValidezOferta					INT,
	@TiempoEntrega					INT,
	@CodigoEstadoCotizacion			CHAR(1),
	@CotizacionVendida				BIT,
	@CodigoMonedaCotizacionVenta	TINYINT,
	@CodigoTipoCotizacion			CHAR(1),
	@ConFactura						BIT,
	@Observaciones					TEXT,
	@MontoTotalCotizacion			DECIMAL(10,2),
	@MontoTotalCotizacionProductos	DECIMAL(10,2),
	@MontoTotalCotizacionServicios	DECIMAL(10,2),
	@NumeroVentaServicio			INT,
	@ProductosDetalle				TEXT
AS
BEGIN
	BEGIN TRANSACTION
	
	DECLARE @PorcentajeImpuestoIVA	DECIMAL(10,2)
				
	SET @FechaHoraCotizacion = GETDATE()
	
	SELECT TOP(1) @PorcentajeImpuestoIVA = PorcentajeImpuesto
	FROM PCsConfiguraciones 
	WHERE NumeroAgencia = @NumeroAgencia
	
	INSERT INTO dbo.CotizacionVentasProductos(NumeroAgencia,CodigoCliente, CodigoUsuario, FechaHoraCotizacion,ValidezOferta,TiempoEntrega,CodigoEstadoCotizacion,CotizacionVendida,CodigoMonedaCotizacionVenta, CodigoTipoCotizacion, ConFactura, Observaciones, MontoTotalCotizacion, MontoTotalCotizacionProductos, MontoTotalCotizacionServicios, NumeroVentaServicio)
	VALUES (@NumeroAgencia, @CodigoCliente, @CodigoUsuario, @FechaHoraCotizacion,
		@ValidezOferta,@TiempoEntrega,@CodigoEstadoCotizacion,@CotizacionVendida,
		@CodigoMonedaCotizacionVenta, @CodigoTipoCotizacion, @ConFactura, @Observaciones, 
		CASE WHEN @ConFactura = 0 THEN @MontoTotalCotizacion ELSE @MontoTotalCotizacion + (@MontoTotalCotizacion * @PorcentajeImpuestoIVA /100) END, 
		@MontoTotalCotizacionProductos, @MontoTotalCotizacionServicios, @NumeroVentaServicio)
	
	DECLARE @punteroXMLProductosDetalle INT,
			@NumeroCotizacionProducto		INT
		
	
		
		SET @NumeroCotizacionProducto = @@IDENTITY
					
		EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @ProductosDetalle
--CASE WHEN @NumeroFactura IS NULL THEN Precio ELSE Precio + (Precio * (@PorcentajeImpuestoIVA / 100)) END, 

		INSERT INTO dbo.CotizacionVentasProductosDeta(
			NumeroAgencia,
			NumeroCotizacionVentaProducto,
			CodigoProducto,
			CantidadCotizacionVenta,
			PrecioUnitarioCotizacionVenta,
			PrecioUnitarioCotizacionOtraMoneda,
			TiempoGarantiaCotizacionVenta, 
			PorcentajeDescuento, 
			NumeroPrecioSeleccionado,
			NumeroOrdenInsertado)
		SELECT  @NumeroAgencia, 
				@NumeroCotizacionProducto, 
				CodigoProducto, 
				Cantidad, 				
				CASE WHEN @ConFactura = 0 THEN Precio ELSE Precio + (Precio * (@PorcentajeImpuestoIVA / 100)) END, 
				PrecioUnitarioOtraMoneda,
				Garantia, 
				PorcentajeDescuento, 
				NumeroPrecioSeleccionado,
				NumeroOrdenInsertado
		FROM       OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)
					WITH (CodigoProducto			VARCHAR(15),
						  Cantidad					INT,						  
						  Precio					DECIMAL(10,2),	
						  PrecioUnitarioOtraMoneda  DECIMAL(10,2),	
						  Garantia					INT,
						  PorcentajeDescuento		DECIMAL(10,2),
						  NumeroPrecioSeleccionado	CHAR(1),
						  NumeroOrdenInsertado		INT
					)
		EXEC sp_xml_removedocument @punteroXMLProductosDetalle
		IF(@@ERROR <> 0)
		BEGIN
			RAISERROR('No se Pudo ingresar la Cotizacion de Productos',1,16)	
			ROLLBACK TRAN
		END
	COMMIT TRANSACTION
END
GO


DROP PROCEDURE ActualizarCoditoEstadoCotizacion
GO
CREATE PROCEDURE ActualizarCoditoEstadoCotizacion
	@NumeroAgencia					INT,
	@NumeroCotizacionVentaProducto	INT,	
	@CodigoEstadoCotizacion			CHAR(1)
AS
BEGIN
	UPDATE 	dbo.CotizacionVentasProductos
	SET		
		CodigoEstadoCotizacion				= @CodigoEstadoCotizacion		
	WHERE	(NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto) 
		AND (NumeroAgencia = @NumeroAgencia)
END
GO





DROP PROCEDURE ActualizarCotizacionVentaProductoXMLDetalle
GO
CREATE PROCEDURE ActualizarCotizacionVentaProductoXMLDetalle
	@NumeroAgencia					INT,
	@NumeroCotizacionProducto		INT,
	@CodigoCliente					INT,
	@CodigoUsuario					INT,
	@FechaHoraCotizacion			DATETIME,
	@ValidezOferta					INT,
	@TiempoEntrega					INT,
	@CodigoEstadoCotizacion			CHAR(1),
	@CotizacionVendida				BIT,
	@CodigoMonedaCotizacionVenta	TINYINT,
	@CodigoTipoCotizacion			CHAR(1),
	@ConFactura						BIT,
	@Observaciones					TEXT,
	@MontoTotalCotizacion			DECIMAL(10,2),
	@MontoTotalCotizacionProductos	DECIMAL(10,2),
	@MontoTotalCotizacionServicios	DECIMAL(10,2),
	@NumeroVentaServicio			INT,
	@ProductosDetalle				TEXT
AS
BEGIN
	BEGIN TRANSACTION 
		DECLARE @PorcentajeImpuestoIVA	DECIMAL(10,2)		
		SELECT TOP(1) @PorcentajeImpuestoIVA = PorcentajeImpuesto
		FROM PCsConfiguraciones 
		WHERE NumeroAgencia = @NumeroAgencia
		
		SET @MontoTotalCotizacion = CASE WHEN @ConFactura = 0 THEN @MontoTotalCotizacion ELSE @MontoTotalCotizacion + (@MontoTotalCotizacion * @PorcentajeImpuestoIVA /100) END
		
		EXEC ActualizarCotizacionVentaProducto @NumeroAgencia, @NumeroCotizacionProducto, @CodigoCliente, @CodigoUsuario, @FechaHoraCotizacion, @ValidezOferta, @TiempoEntrega, @CodigoEstadoCotizacion,
			@CotizacionVendida, @CodigoMonedaCotizacionVenta, @CodigoTipoCotizacion, @ConFactura, @Observaciones, 
			@MontoTotalCotizacion,
			@MontoTotalCotizacionProductos, @MontoTotalCotizacionServicios, @NumeroVentaServicio
			
		DECLARE @punteroXMLProductosDetalle INT		
		
					
		EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @ProductosDetalle
		--PARA INSERTAR LOS NUEVOS REGISTROS EN LA EDICIÓN 
		------------------------------------------------------------------------------------
		
		INSERT INTO dbo.CotizacionVentasProductosDeta(
				NumeroAgencia,
				NumeroCotizacionVentaProducto,
				CodigoProducto,
				CantidadCotizacionVenta,
				PrecioUnitarioCotizacionVenta,
				PrecioUnitarioCotizacionOtraMoneda,
				TiempoGarantiaCotizacionVenta,
				PorcentajeDescuento,
				NumeroPrecioSeleccionado,
				NumeroOrdenInsertado
				)
		SELECT  @NumeroAgencia, 
				@NumeroCotizacionProducto, 
				CodigoProducto,				
				Cantidad,
				CASE WHEN @ConFactura = 0 THEN Precio ELSE Precio + (Precio * (@PorcentajeImpuestoIVA / 100)) END, 
				PrecioUnitarioOtraMoneda,
				Garantia,
				PorcentajeDescuento,
				NumeroPrecioSeleccionado,
				NumeroOrdenInsertado			
		FROM  OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)
		WITH (CodigoProducto			VARCHAR(15),
			  Cantidad					INT,						  
			  Precio					DECIMAL(10,2),
			  PrecioUnitarioOtraMoneda	DECIMAL(10,2),
			  Garantia					INT,
			  PorcentajeDescuento		DECIMAL(10,2),
			  NumeroPrecioSeleccionado	CHAR(1),
			  NumeroOrdenInsertado		INT
		)
		WHERE CodigoProducto NOT IN(
			SELECT VSD.CodigoProducto
			FROM dbo.CotizacionVentasProductosDeta VSD
			WHERE VSD.NumeroAgencia = @NumeroAgencia
			AND VSD.NumeroCotizacionVentaProducto = @NumeroCotizacionProducto
		)
		
		--ACTUALIZAR LOS REGISTROS
		------------------------------------------------------------------------------------
		UPDATE CotizacionVentasProductosDeta
			SET CotizacionVentasProductosDeta.PrecioUnitarioCotizacionVenta = CASE WHEN @ConFactura = 0 THEN VSDXML.Precio ELSE VSDXML.Precio + (VSDXML.Precio * (@PorcentajeImpuestoIVA / 100)) END,
				CotizacionVentasProductosDeta.PrecioUnitarioCotizacionOtraMoneda = 	VSDXML.PrecioUnitarioOtraMoneda,		
				CotizacionVentasProductosDeta.CantidadCotizacionVenta = VSDXML.Cantidad,
				CotizacionVentasProductosDeta.TiempoGarantiaCotizacionVenta = VSDXML.Garantia,
				CotizacionVentasProductosDeta.PorcentajeDescuento = VSDXML.PorcentajeDescuento,
				CotizacionVentasProductosDeta.NumeroPrecioSeleccionado = VSDXML.NumeroPrecioSeleccionado
								
		FROM OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2) 
		WITH(	
			CodigoProducto			VARCHAR(15),
			Cantidad				INT,			
			Precio					DECIMAL(10,2),
			PrecioUnitarioOtraMoneda DECIMAL(10,2),
			Garantia				INT,
			PorcentajeDescuento		DECIMAL(10,2),
			NumeroPrecioSeleccionado	CHAR(1)			
		) VSDXML
		WHERE CotizacionVentasProductosDeta.NumeroAgencia = @NumeroAgencia
		AND CotizacionVentasProductosDeta.NumeroCotizacionVentaProducto = @NumeroCotizacionProducto
		AND CotizacionVentasProductosDeta.CodigoProducto = VSDXML.CodigoProducto
		
		--QUITAR LOS REGISTROS QUE FUERON ELIMINADOS
		--------------------------------------------------------------------------
		DELETE
		FROM dbo.CotizacionVentasProductosDeta
		WHERE CodigoProducto NOT IN
		(
			SELECT  CodigoProducto				
			FROM OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)		
			WITH(
					CodigoProducto			CHAR(15)
				)
		)
		AND CotizacionVentasProductosDeta.NumeroAgencia = @NumeroAgencia
		AND CotizacionVentasProductosDeta.NumeroCotizacionVentaProducto = @NumeroCotizacionProducto
		
		EXEC sp_xml_removedocument @punteroXMLProductosDetalle
		IF(@@ERROR <> 0)
		BEGIN
			RAISERROR('No se Pudo Actualizar la Venta de Servicios',1,16)	
			ROLLBACK TRAN
		END
		ELSE
			COMMIT TRANSACTION
END
GO


DROP PROCEDURE ListarCotizacionVentaProductoCompuestosDetalleReporte
GO

CREATE PROCEDURE ListarCotizacionVentaProductoCompuestosDetalleReporte
	@NumeroAgencia			INT,
	@NumeroCotizacionVentaProducto	INT
AS
BEGIN	
	SELECT	VPD.NumeroCotizacionVentaProducto, dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto, 
			DBO.ObtenerNombreProducto(PC.CodigoProductoComponente ) AS NombreProductoComponente, 			
			VPD.CodigoProducto, PC.CodigoProductoComponente, 
			VPD.CantidadCotizacionVenta,
			VPD.CantidadCotizacionVenta * PC.Cantidad AS CantidadVentaCompuesta,
			PrecioUnitarioCotizacionVenta, 
			(VPD.CantidadCotizacionVenta * VPD.PrecioUnitarioCotizacionVenta) as PrecioTotalVenta, 
			VPD.TiempoGarantiaCotizacionVenta
	FROM CotizacionVentasProductosDeta VPD 
	LEFT JOIN ProductosCompuestos PC
	ON VPD.CodigoProducto = PC.CodigoProducto
	WHERE VPD.NumeroAgencia = @NumeroAgencia
	AND VPD.NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
	ORDER BY 2
	
END
GO


--DROP PROCEDURE ListarCotizacionVentaProductoSimplesDetalleReporte
--GO

--CREATE PROCEDURE ListarCotizacionVentaProductoSimplesDetalleReporte
--	@NumeroAgencia			INT,
--	@NumeroCotizacionVentaProducto	INT
--AS
--BEGIN
--	SELECT	VPD.NumeroCotizacionVentaProducto, P.CodigoProducto, 
--			P.NombreProducto, VPD.CantidadCotizacionVenta
--	FROM CotizacionVentasProductosDeta VPD
--	INNER JOIN Productos P 
--	ON P.CodigoProducto = VPD.CodigoProducto
--	WHERE VPD.NumeroAgencia = @NumeroAgencia
--	AND VPD.NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
--	AND P.ProductoSimple = 1
--	UNION ALL
		
--	SELECT	VPD.NumeroCotizacionVentaProducto, PC.CodigoProductoComponente, 
--			DBO.ObtenerNombreProducto(PC.CodigoProductoComponente ) AS NombreProductoComponente, 						
--			SUM(VPD.CantidadCotizacionVenta) AS CantidadCotizacionVenta
--	FROM CotizacionVentasProductosDeta VPD 
--	LEFT JOIN ProductosCompuestos PC
--	ON VPD.CodigoProducto = PC.CodigoProducto
--	WHERE VPD.NumeroAgencia = @NumeroAgencia
--	AND VPD.NumeroCotizacionVentaProducto = @NumeroCotizacionVentaProducto
--	GROUP BY VPD.NumeroCotizacionVentaProducto, PC.CodigoProductoComponente			
--	ORDER BY 2
	
--END
--GO
