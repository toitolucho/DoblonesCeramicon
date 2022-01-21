USE DOBLONES20
GO



DROP PROCEDURE InsertarVentaServicio
GO
CREATE PROCEDURE InsertarVentaServicio
	@NumeroAgencia				INT,	
	@CodigoUsuario				INT,
	@DIPersonaResponsable1		CHAR(15),
	@DIPersonaResponsable2		CHAR(15),
	@DIPersonaResponsable3		CHAR(15),
	@CodigoCliente				INT,
	@FechaHoraVentaServicio		DATETIME,
	@FechaHoraEntregaServicio	DATETIME,
	@CodigoEstadoServicio		CHAR(1),
	@CodigoTipoServicio			CHAR(1),
	@MontoTotal					DECIMAL(10,2),
	@NumeroFactura				INT,
	@NumeroCredito				INT,		
	@CodigoMoneda				TINYINT,
	@Observaciones				TEXT	
AS
BEGIN
	INSERT INTO dbo.VentasServicios(NumeroAgencia, CodigoUsuario, DIPersonaResponsable1, DIPersonaResponsable2, DIPersonaResponsable3, CodigoCliente,  FechaHoraEntregaServicio, CodigoEstadoServicio, CodigoTipoServicio, MontoTotal, NumeroFactura, NumeroCredito, CodigoMoneda, Observaciones)
	VALUES (@NumeroAgencia, @CodigoUsuario, @DIPersonaResponsable1, @DIPersonaResponsable2, @DIPersonaResponsable3, @CodigoCliente, @FechaHoraVentaServicio, @CodigoEstadoServicio, @CodigoTipoServicio, @MontoTotal, @NumeroFactura, @NumeroCredito, @CodigoMoneda, @Observaciones)
END
GO



DROP PROCEDURE ActualizarVentaServicio
GO
CREATE PROCEDURE ActualizarVentaServicio
	@NumeroAgencia				INT,
	@NumeroVentaServicio		INT,
	@CodigoUsuario				INT,
	@DIPersonaResponsable1		CHAR(15),
	@DIPersonaResponsable2		CHAR(15),
	@DIPersonaResponsable3		CHAR(15),
	@CodigoCliente				INT,
	@FechaHoraVentaServicio		DATETIME,
	@FechaHoraEntregaServicio	DATETIME,
	@CodigoEstadoServicio		CHAR(1),
	@CodigoTipoServicio			CHAR(1),
	@MontoTotal					DECIMAL(10,2),
	@NumeroFactura				INT,
	@NumeroCredito				INT,		
	@CodigoMoneda				TINYINT,
	@Observaciones				TEXT
AS
BEGIN
	UPDATE 	dbo.VentasServicios
	SET				
		CodigoUsuario			= @CodigoUsuario,
		DIPersonaResponsable1	= @DIPersonaResponsable1,
		DIPersonaResponsable2	= @DIPersonaResponsable2,
		DIPersonaResponsable3	= @DIPersonaResponsable3,
		CodigoCliente			= @CodigoCliente,
		FechaHoraVentaServicio	= @FechaHoraVentaServicio,
		FechaHoraEntregaServicio= @FechaHoraEntregaServicio,
		CodigoEstadoServicio	= @CodigoEstadoServicio,
		CodigoTipoServicio		= @CodigoTipoServicio,
		MontoTotal				= @MontoTotal,
		NumeroFactura			= @NumeroFactura,
		NumeroCredito			= @NumeroCredito,
		CodigoMoneda			= @CodigoMoneda,
		Observaciones			= @Observaciones
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaServicio = @NumeroVentaServicio
END
GO



DROP PROCEDURE EliminarVentaServicio
GO
CREATE PROCEDURE EliminarVentaServicio
	@NumeroAgencia				INT,
	@NumeroVentaServicio		INT
AS
BEGIN
	DELETE 
	FROM dbo.VentasServicios
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaServicio = @NumeroVentaServicio
END
GO



DROP PROCEDURE ListarVentasServicios
GO
CREATE PROCEDURE ListarVentasServicios
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaServicio, CodigoUsuario, DIPersonaResponsable1, DIPersonaResponsable2, DIPersonaResponsable3, CodigoCliente, FechaHoraVentaServicio, FechaHoraEntregaServicio, CodigoEstadoServicio, CodigoTipoServicio, MontoTotal, NumeroFactura, NumeroCredito, CodigoMoneda, Observaciones
	FROM dbo.VentasServicios
	ORDER BY NumeroVentaServicio
END
GO



DROP PROCEDURE ObtenerVentaServicio
GO
CREATE PROCEDURE ObtenerVentaServicio
	@NumeroAgencia				INT,
	@NumeroVentaServicio		INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaServicio, CodigoUsuario, DIPersonaResponsable1, DIPersonaResponsable2, DIPersonaResponsable3, CodigoCliente, FechaHoraVentaServicio, FechaHoraEntregaServicio, CodigoEstadoServicio, CodigoTipoServicio, MontoTotal, NumeroFactura, NumeroCredito, CodigoMoneda, Observaciones
	FROM dbo.VentasServicios
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaServicio = @NumeroVentaServicio
END
GO



DROP PROCEDURE ActualizarCodigoEstadoServicio
GO
CREATE PROCEDURE ActualizarCodigoEstadoServicio
	@NumeroAgencia				INT,
	@NumeroVentaServicio		INT,
	@CodigoEstadoServicio		CHAR(1)
AS
BEGIN
	UPDATE VentasServicios
	SET CodigoEstadoServicio = @CodigoEstadoServicio
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaServicio = @NumeroVentaServicio
END
GO

DROP PROCEDURE InsertarVentaServicioXMLDetalle
GO
CREATE PROCEDURE InsertarVentaServicioXMLDetalle
	@NumeroAgencia				INT,	
	@CodigoUsuario				INT,
		@DIPersonaResponsable1		CHAR(15),
	@DIPersonaResponsable2		CHAR(15),
	@DIPersonaResponsable3		CHAR(15),
	@CodigoCliente				INT,
	@FechaHoraVentaServicio		DATETIME,
	@FechaHoraEntregaServicio	DATETIME,
	@CodigoEstadoServicio		CHAR(1),
	@CodigoTipoServicio			CHAR(1),
	@MontoTotal					DECIMAL(10,2),
	@NumeroFactura				INT,
	@NumeroCredito				INT,		
	@CodigoMoneda				TINYINT,
	@Observaciones				TEXT,
	@ServiciosDetalle			TEXT
AS
BEGIN
	BEGIN TRANSACTION 
		INSERT INTO dbo.VentasServicios(NumeroAgencia, CodigoUsuario, DIPersonaResponsable1, DIPersonaResponsable2, DIPersonaResponsable3, CodigoCliente,  FechaHoraEntregaServicio, CodigoEstadoServicio, CodigoTipoServicio, MontoTotal, NumeroFactura, NumeroCredito, CodigoMoneda, Observaciones)
		VALUES (@NumeroAgencia, @CodigoUsuario, @DIPersonaResponsable1, @DIPersonaResponsable2, @DIPersonaResponsable3, @CodigoCliente, @FechaHoraVentaServicio, @CodigoEstadoServicio, @CodigoTipoServicio, @MontoTotal, @NumeroFactura, @NumeroCredito, @CodigoMoneda, @Observaciones)
		
		DECLARE @punteroXMLProductosDetalle INT,
				@NumeroVentaServicio		INT
		
		--SET @NumeroVentaProducto = @@IDENTITY
		SET @NumeroVentaServicio = SCOPE_IDENTITY()--Devuelve el ultimo id Ingresado en una Tabla con una columna Identidad dentro del Ambito,
		--es Decir en este caso, devolverá el ultimo IDENTITY generado dentro de la Tabla VentasProductos para esta transacción
					
		EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @ServiciosDetalle
		
		INSERT INTO dbo.VentasProductosDetalle(
				NumeroAgencia,
				NumeroVentaServicio,
				CodigoServicio,
				CantidadVentaServicio,
				PrecioUnitario,
				TiempoGarantiaDias
				)
		SELECT  @NumeroAgencia, 
				@NumeroVentaServicio, 
				CodigoServicio, 				
				--CASE WHEN (Cantidad > CantidadExistencia) THEN CantidadEntregada ELSE Cantidad END AS CantidadEntregada, 
				CantidadVentaServicio,
				PrecioUnitario, 
				TiempoGarantiaDias
		FROM OPENXML (@punteroXMLProductosDetalle, '/VentaServicios/CotizacionVentasProductosDeta',2)
		WITH(	
				NumeroAgencia			INT,
				NumeroVentaServicio		INT,
				CodigoServicio			INT,
				CantidadVentaServicio	INT,
				PrecioUnitario			DECIMAL(10,2),
				TiempoGarantiaDias		INT			
				
				)
		EXEC sp_xml_removedocument @punteroXMLProductosDetalle
		IF(@@ERROR <> 0)
		BEGIN
			RAISERROR('No se Pudo ingresar la Venta de Servicios',1,16)	
			ROLLBACK TRAN
		END
	COMMIT TRANSACTION
END
GO



DROP PROCEDURE ActualizarVentaServicioXMLDetalle
GO
CREATE PROCEDURE ActualizarVentaServicioXMLDetalle
	@NumeroAgencia				INT,	
	@NumeroVentaServicio		INT,
	@CodigoUsuario				INT,
	@DIPersonaResponsable1		CHAR(15),
	@DIPersonaResponsable2		CHAR(15),
	@DIPersonaResponsable3		CHAR(15),
	@CodigoCliente				INT,
	@FechaHoraVentaServicio		DATETIME,
	@FechaHoraEntregaServicio	DATETIME,
	@CodigoEstadoServicio		CHAR(1),
	@CodigoTipoServicio			CHAR(1),
	@MontoTotal					DECIMAL(10,2),
	@NumeroFactura				INT,
	@NumeroCredito				INT,		
	@CodigoMoneda				TINYINT,
	@Observaciones				TEXT,
	@ServiciosDetalle			TEXT
AS
BEGIN
	BEGIN TRANSACTION 
		--INSERT INTO dbo.VentasServicios(NumeroAgencia, CodigoUsuario, DIPersonaResponsable1, DIPersonaResponsable2, DIPersonaResponsable3, CodigoCliente,  FechaHoraEntregaServicio, CodigoEstadoServicio, CodigoTipoServicio, MontoTotal, NumeroFactura, NumeroCredito, CodigoMoneda, Observaciones)
		--VALUES (@NumeroAgencia, @CodigoUsuario, @DIPersonaResponsable1, @DIPersonaResponsable2, @DIPersonaResponsable3, @CodigoCliente, @FechaHoraVentaServicio, @CodigoEstadoServicio, @CodigoTipoServicio, @MontoTotal, @NumeroFactura, @NumeroCredito, @CodigoMoneda, @Observaciones)
		
		EXEC ActualizarVentaServicio @NumeroAgencia, @NumeroVentaServicio, @CodigoUsuario, @DIPersonaResponsable1, @DIPersonaResponsable2, @DIPersonaResponsable3, @CodigoCliente, @FechaHoraVentaServicio, null, @CodigoEstadoServicio, @CodigoTipoServicio, @MontoTotal, @NumeroFactura, @NumeroCredito, @CodigoMoneda, @Observaciones
		DECLARE @punteroXMLProductosDetalle INT
				
		
		--SET @NumeroVentaProducto = @@IDENTITY
		--SET @NumeroVentaServicio = SCOPE_IDENTITY()--Devuelve el ultimo id Ingresado en una Tabla con una columna Identidad dentro del Ambito,
		--es Decir en este caso, devolverá el ultimo IDENTITY generado dentro de la Tabla VentasProductos para esta transacción
					
		EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @ServiciosDetalle
		--PARA INSERTAR LOS NUEVOS REGISTROS EN LA EDICIÓN 
		------------------------------------------------------------------------------------
		
		INSERT INTO dbo.VentasProductosDetalle(
				NumeroAgencia,
				NumeroVentaServicio,
				CodigoServicio,
				CantidadVentaServicio,
				PrecioUnitario,
				TiempoGarantiaDias
				)
		SELECT  @NumeroAgencia, 
				@NumeroVentaServicio, 
				CodigoServicio,				
				CantidadVentaServicio,
				PrecioUnitario, 
				TiempoGarantiaDias
		FROM OPENXML (@punteroXMLProductosDetalle, '/VentaServicios/CotizacionVentasProductosDeta',2)		
		WITH(	
				NumeroAgencia			INT,
				NumeroVentaServicio		INT,
				CodigoServicio			INT,
				CantidadVentaServicio	INT,
				PrecioUnitario			DECIMAL(10,2),
				TiempoGarantiaDias		INT			
				
				)
		WHERE CodigoServicio NOT IN(
			SELECT VSD.CodigoServicio 
			FROM CotizacionVentasProductosDeta VSD
			WHERE VSD.NumeroAgencia = @NumeroAgencia
			AND VSD.NumeroVentaServicio = @NumeroVentaServicio
		)
		
		--ACTUALIZAR LOS REGISTROS
		------------------------------------------------------------------------------------
		UPDATE CotizacionVentasProductosDeta
			SET CotizacionVentasProductosDeta.PrecioUnitario = VSDXML.PrecioUnitario,
				CotizacionVentasProductosDeta.CantidadVentaServicio = VSDXML.CantidadVentaServicio,
				CotizacionVentasProductosDeta.TiempoGarantiaDias = VSDXML.TiempoGarantiaDias
		FROM OPENXML (@punteroXMLProductosDetalle, '/VentaServicios/CotizacionVentasProductosDeta',2) 
		WITH(	
				NumeroAgencia			INT,
				NumeroVentaServicio		INT,
				CodigoServicio			INT,
				CantidadVentaServicio	INT,
				PrecioUnitario			DECIMAL(10,2),
				TiempoGarantiaDias		INT			
				
				) VSDXML
		WHERE CotizacionVentasProductosDeta.NumeroAgencia = @NumeroAgencia
		AND CotizacionVentasProductosDeta.NumeroVentaServicio = @NumeroVentaServicio
		AND CotizacionVentasProductosDeta.CodigoServicio = VSDXML.CodigoServicio
		
		--QUITAR LOS REGISTROS QUE FUERON ELIMINADOS
		--------------------------------------------------------------------------
		DELETE
		FROM CotizacionVentasProductosDeta
		WHERE CodigoServicio NOT IN
		(
			SELECT  CodigoServicio				
			FROM OPENXML (@punteroXMLProductosDetalle, '/VentaServicios/CotizacionVentasProductosDeta',2)		
			WITH(
					CodigoServicio			INT
				)
		)
		AND CotizacionVentasProductosDeta.NumeroAgencia = @NumeroAgencia
		AND CotizacionVentasProductosDeta.NumeroVentaServicio = @NumeroVentaServicio
		
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