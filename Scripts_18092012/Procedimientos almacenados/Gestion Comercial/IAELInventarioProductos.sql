USE DOBLONES20
GO

DROP PROCEDURE InsertarInventarioProducto
GO

CREATE PROCEDURE InsertarInventarioProducto
	@NumeroAgencia					INT,
	@CodigoProducto					CHAR(15),
	@CantidadExistencia				INT,
	@CantidadRequerida				INT,
	@PrecioUnitarioCompra			DECIMAL(10,2),
	@TiempoGarantiaProducto			INT,
	@PorcentajeUtilidad1			DECIMAL(5,2),
	@PrecioUnitarioVenta1			DECIMAL(10,2),
	@PorcentajeUtilidad2			DECIMAL(5,2),
	@PrecioUnitarioVenta2			DECIMAL(10,2),
	@PorcentajeUtilidad3			DECIMAL(5,2),
	@PrecioUnitarioVenta3			DECIMAL(10,2),
	@PorcentajeUtilidad4			DECIMAL(5,2),
	@PrecioUnitarioVenta4			DECIMAL(10,2),
	@PorcentajeUtilidad5			DECIMAL(5,2),
	@PrecioUnitarioVenta5			DECIMAL(10,2),
	@PorcentajeUtilidad6			DECIMAL(5,2),
	@PrecioUnitarioVenta6			DECIMAL(10,2),
	@StockMinimo					INT,
	@MostrarParaVenta				BIT,
	@ClaseProducto					CHAR(1),
	@EsProductoEspecifico			BIT,
	@ProductoEspecificoInventariado	BIT
AS
BEGIN
	INSERT INTO dbo.InventariosProductos(NumeroAgencia, CodigoProducto, CantidadExistencia, CantidadRequerida, PrecioUnitarioCompra, TiempoGarantiaProducto, PorcentajeUtilidad1, PrecioUnitarioVenta1, PorcentajeUtilidad2, PrecioUnitarioVenta2, PorcentajeUtilidad3, PrecioUnitarioVenta3, PorcentajeUtilidad4, PrecioUnitarioVenta4, PorcentajeUtilidad5, PrecioUnitarioVenta5, PorcentajeUtilidad6, PrecioUnitarioVenta6, StockMinimo, MostrarParaVenta, ClaseProducto, EsProductoEspecifico, ProductoEspecificoInventariado)
	VALUES (@NumeroAgencia, @CodigoProducto, @CantidadExistencia, @CantidadRequerida, @PrecioUnitarioCompra, @TiempoGarantiaProducto, @PorcentajeUtilidad1, @PrecioUnitarioVenta1, @PorcentajeUtilidad2, @PrecioUnitarioVenta2, @PorcentajeUtilidad3, @PrecioUnitarioVenta3, @PorcentajeUtilidad4, @PrecioUnitarioVenta4, @PorcentajeUtilidad5, @PrecioUnitarioVenta5, @PorcentajeUtilidad6, @PrecioUnitarioVenta6, @StockMinimo, @MostrarParaVenta, @ClaseProducto, @EsProductoEspecifico, @ProductoEspecificoInventariado)
END
GO

DROP PROCEDURE ActualizarInventarioProducto
GO

CREATE PROCEDURE ActualizarInventarioProducto
	@NumeroAgencia					INT,
	@CodigoProducto					CHAR(15),
	@CantidadExistencia				INT,
	@CantidadRequerida				INT,
	@PrecioUnitarioCompra			DECIMAL(10,2),
	@TiempoGarantiaProducto			INT,
	@PorcentajeUtilidad1			DECIMAL(5,2),
	@PrecioUnitarioVenta1			DECIMAL(10,2),
	@PorcentajeUtilidad2			DECIMAL(5,2),
	@PrecioUnitarioVenta2			DECIMAL(10,2),
	@PorcentajeUtilidad3			DECIMAL(5,2),
	@PrecioUnitarioVenta3			DECIMAL(10,2),
	@PorcentajeUtilidad4			DECIMAL(5,2),
	@PrecioUnitarioVenta4			DECIMAL(10,2),
	@PorcentajeUtilidad5			DECIMAL(5,2),
	@PrecioUnitarioVenta5			DECIMAL(10,2),
	@PorcentajeUtilidad6			DECIMAL(5,2),
	@PrecioUnitarioVenta6			DECIMAL(10,2),	
	@StockMinimo					INT,
	@MostrarParaVenta				BIT,
	@ClaseProducto					CHAR(1),
	@EsProductoEspecifico			BIT,
	@ProductoEspecificoInventariado	BIT
AS
BEGIN
	UPDATE 	dbo.InventariosProductos
	SET
		CantidadExistencia				= @CantidadExistencia,
		CantidadRequerida				= @CantidadRequerida,
		PrecioUnitarioCompra			= @PrecioUnitarioCompra,
		TiempoGarantiaProducto			= @TiempoGarantiaProducto,
		PorcentajeUtilidad1				= @PorcentajeUtilidad1,
		PrecioUnitarioVenta1			= @PrecioUnitarioVenta1,
		PorcentajeUtilidad2				= @PorcentajeUtilidad2,
		PrecioUnitarioVenta2			= @PrecioUnitarioVenta2,
		PorcentajeUtilidad3				= @PorcentajeUtilidad3,
		PrecioUnitarioVenta3			= @PrecioUnitarioVenta3,
		PorcentajeUtilidad4				= @PorcentajeUtilidad4,
		PrecioUnitarioVenta4			= @PrecioUnitarioVenta4,
		PorcentajeUtilidad5				= @PorcentajeUtilidad5,
		PrecioUnitarioVenta5			= @PrecioUnitarioVenta5,
		PorcentajeUtilidad6				= @PorcentajeUtilidad6,
		PrecioUnitarioVenta6			= @PrecioUnitarioVenta6,
		StockMinimo						= @StockMinimo,
		MostrarParaVenta				= @MostrarParaVenta,
		ClaseProducto					= @ClaseProducto,
		EsProductoEspecifico			= @EsProductoEspecifico,
		ProductoEspecificoInventariado	= @ProductoEspecificoInventariado
	WHERE	(CodigoProducto = @CodigoProducto)
		AND (NumeroAgencia	= @NumeroAgencia)
END
GO

DROP PROCEDURE EliminarInventarioProducto
GO

CREATE PROCEDURE EliminarInventarioProducto
	@NumeroAgencia	INT,
	@CodigoProducto	CHAR(15)
AS
BEGIN
	DELETE 
	FROM dbo.InventariosProductos
	WHERE	(CodigoProducto = @CodigoProducto)
		AND (NumeroAgencia	= @NumeroAgencia)
END
GO

DROP PROCEDURE ListarInventarioProductos
GO

CREATE PROCEDURE ListarInventarioProductos
AS
BEGIN
	SELECT NumeroAgencia, CodigoProducto, CantidadExistencia, CantidadRequerida, PrecioUnitarioCompra, TiempoGarantiaProducto, PorcentajeUtilidad1, PrecioUnitarioVenta1, PorcentajeUtilidad2, PrecioUnitarioVenta2, PorcentajeUtilidad3, PrecioUnitarioVenta3, PorcentajeUtilidad4, PrecioUnitarioVenta4, PorcentajeUtilidad5, PrecioUnitarioVenta5, PorcentajeUtilidad6, PrecioUnitarioVenta6, StockMinimo, MostrarParaVenta, ClaseProducto, EsProductoEspecifico, ProductoEspecificoInventariado
	FROM dbo.InventariosProductos
	ORDER BY CodigoProducto
END
GO

DROP PROCEDURE ObtenerInventarioProducto
GO

CREATE PROCEDURE ObtenerInventarioProducto
	@NumeroAgencia			INT,
	@CodigoProducto			CHAR(15)
AS
BEGIN
	SELECT NumeroAgencia, CodigoProducto, CantidadExistencia, CantidadRequerida, PrecioUnitarioCompra, TiempoGarantiaProducto, PorcentajeUtilidad1, PrecioUnitarioVenta1, PorcentajeUtilidad2, PrecioUnitarioVenta2, PorcentajeUtilidad3, PrecioUnitarioVenta3, PorcentajeUtilidad4, PrecioUnitarioVenta4, PorcentajeUtilidad5, PrecioUnitarioVenta5, PorcentajeUtilidad6, PrecioUnitarioVenta6, StockMinimo, MostrarParaVenta, ClaseProducto, EsProductoEspecifico, ProductoEspecificoInventariado
	FROM dbo.InventariosProductos
	WHERE	(CodigoProducto = @CodigoProducto)
		AND (NumeroAgencia	= @NumeroAgencia)
END
GO


DROP PROCEDURE ActualizarPEInventariadoInventarioProducto
GO

CREATE PROCEDURE ActualizarPEInventariadoInventarioProducto
	@NumeroAgencia					INT,
	@CodigoProducto					CHAR(15),	
	@EsProductoEspecifico			BIT,
	@ProductoEspecificoInventariado	BIT
AS
BEGIN
	UPDATE 	dbo.InventariosProductos
	SET		
		EsProductoEspecifico			= @EsProductoEspecifico,
		ProductoEspecificoInventariado	= @ProductoEspecificoInventariado
	WHERE	(CodigoProducto = @CodigoProducto)
		AND (NumeroAgencia	= @NumeroAgencia)
END
GO




DROP PROCEDURE ActualizarPEInventariadoInventarioProducto
GO

CREATE PROCEDURE ActualizarPEInventariadoInventarioProducto
	@NumeroAgencia					INT,
	@CodigoProducto					CHAR(15),	
	@EsProductoEspecifico			BIT,
	@ProductoEspecificoInventariado	BIT
AS
BEGIN
	UPDATE 	dbo.InventariosProductos
	SET		
		EsProductoEspecifico			= @EsProductoEspecifico,
		ProductoEspecificoInventariado	= @ProductoEspecificoInventariado
	WHERE	(CodigoProducto = @CodigoProducto)
		AND (NumeroAgencia	= @NumeroAgencia)
END
GO





DROP PROCEDURE ActualizarCambioEstadoProductosEspecificos_A_Normal
GO

CREATE PROCEDURE ActualizarCambioEstadoProductosEspecificos_A_Normal
	@NumeroAgencia		INT,
	@ProductosDetalle	TEXT,
	@NombreProducto		VARCHAR(4000) OUTPUT	
	
AS
BEGIN
	DECLARE @punteroXMLProductosDetalle	INT
	BEGIN TRANSACTION
	
	
		EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @ProductosDetalle
		
		IF(EXISTS(
			SELECT  PE.CodigoProducto, PE.EsProductoEspecifico 				
			FROM OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)
			WITH(	CodigoProducto				CHAR(15),						
					EsProductoEspecifico		BIT) PE
			WHERE dbo.EsPosibleVolverSimpleProductoEspecifico(@NumeroAgencia, CodigoProducto) = 0
			AND PE.EsProductoEspecifico = 0
			)
		)
		BEGIN
			--SELECT @DetalleProductosTexto = COALESCE(@DetalleProductosTexto + ', ', '') + TPD.NombreProducto
			SELECT  @NombreProducto = COALESCE(@NombreProducto + ', ', '') + TPD.NombreProducto
			FROM OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)
			WITH(	NombreProducto				VARCHAR(250),
					CodigoProducto				CHAR(15),
					EsProductoEspecifico		BIT) TPD
			WHERE dbo.EsPosibleVolverSimpleProductoEspecifico(@NumeroAgencia, TPD.CodigoProducto) = 0
			AND TPD.EsProductoEspecifico = 0
			
			
		END
		ELSE
		BEGIN
			UPDATE 	dbo.InventariosProductos
			SET		
				EsProductoEspecifico			= TPD.EsProductoEspecifico				
			FROM 
			(
				SELECT  CodigoProducto, EsProductoEspecifico			
				FROM OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)
				WITH(	CodigoProducto				CHAR(15),						
						EsProductoEspecifico		BIT)
			) TPD
			
			WHERE InventariosProductos.CodigoProducto = TPD.CodigoProducto 
			and InventariosProductos.NumeroAgencia = @NumeroAgencia
			
			SET @NombreProducto = NULL	
		END
		EXEC sp_xml_removedocument @punteroXMLProductosDetalle
	
	IF(@@ERROR <> 0)
	BEGIN
		RAISERROR('No se pudo Actualizar el Estado de los Productos Especificos que ha solicitado en esta Orden de Compra, 
				   Seguramente existen referencias a los mismos, o ya existe un historial o kardex con Códigos Especificos
				   de los Productos Seleccionados',1,16)	
		ROLLBACK TRAN
	END
	ELSE
		COMMIT TRANSACTION	
	
END
GO
