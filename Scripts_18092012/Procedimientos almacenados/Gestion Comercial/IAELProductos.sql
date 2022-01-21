use DOBLONES20
GO

DROP PROCEDURE InsertarProducto
GO

CREATE PROCEDURE InsertarProducto
	@CodigoProducto					CHAR(15),
	@CodigoProductoFabricante		CHAR(30),
	@NombreProducto					VARCHAR(250),
	@NombreProducto1				VARCHAR(250),
	@NombreProducto2				VARCHAR(250),
	@CodigoMarcaProducto			INT,
	@CodigoTipoProducto				INT,
	@CodigoUnidad					INT,
	@CodigoTipoCalculoInventario	CHAR(1),
	@LlenarCodigoPE					BIT,
	@ProductoTangible				BIT,
	@ProductoSimple					BIT,
	@CalcularPrecioVenta			BIT,
	@Descripcion					TEXT,
	@Observaciones					TEXT
AS
BEGIN
	
	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM Productos WHERE NombreProducto = @NombreProducto))
	BEGIN
		INSERT INTO dbo.Productos (CodigoProducto,CodigoProductoFabricante, NombreProducto,NombreProducto1, NombreProducto2,CodigoMarcaProducto, CodigoTipoProducto,CodigoUnidad, CodigoTipoCalculoInventario,LlenarCodigoPE, ProductoTangible,ProductoSimple, CalcularPrecioVenta,Descripcion, Observaciones)					
		VALUES (@CodigoProducto,@CodigoProductoFabricante, @NombreProducto,@NombreProducto1, @NombreProducto2,@CodigoMarcaProducto, @CodigoTipoProducto,@CodigoUnidad, @CodigoTipoCalculoInventario,@LlenarCodigoPE, @ProductoTangible,@ProductoSimple, @CalcularPrecioVenta,@Descripcion, @Observaciones)
		
		INSERT INTO dbo.InventariosProductos(NumeroAgencia, CodigoProducto, CantidadExistencia, CantidadRequerida, PrecioUnitarioCompra, TiempoGarantiaProducto, PorcentajeUtilidad1, PrecioUnitarioVenta1, PorcentajeUtilidad2, PrecioUnitarioVenta2, PorcentajeUtilidad3, PrecioUnitarioVenta3, PorcentajeUtilidad4, PrecioUnitarioVenta4, PorcentajeUtilidad5, PrecioUnitarioVenta5, PorcentajeUtilidad6, PrecioUnitarioVenta6, StockMinimo, MostrarParaVenta, ClaseProducto, EsProductoEspecifico)
		VALUES (1, @CodigoProducto, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 'S', @LlenarCodigoPE)
	END
	ELSE
		RAISERROR ('EL NOMBRE DEL PRODUCTO YA SE ENCUENTRA REGISTRADO',16, 2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16, 2)
	END
	ELSE
		COMMIT TRANSACTION


END
GO

DROP PROCEDURE ActualizarProducto
GO

CREATE PROCEDURE ActualizarProducto
	@CodigoProducto					CHAR(15),
	@CodigoProductoFabricante		CHAR(30),
	@NombreProducto					VARCHAR(250),
	@NombreProducto1				VARCHAR(250),
	@NombreProducto2				VARCHAR(250),
	@CodigoMarcaProducto			INT,
	@CodigoTipoProducto				INT,
	@CodigoUnidad					INT,
	@CodigoTipoCalculoInventario	CHAR(1),
	@LlenarCodigoPE					BIT,
	@ProductoTangible				BIT,
	@ProductoSimple					BIT,
	@CalcularPrecioVenta			BIT,
	@Descripcion					TEXT,
	@Observaciones					TEXT
AS
BEGIN
	
	
	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM Productos WHERE NombreProducto = @NombreProducto AND CodigoProducto <> @CodigoProducto))
		UPDATE 	dbo.Productos
		SET		
			CodigoProductoFabricante	= @CodigoProductoFabricante,
			NombreProducto				= @NombreProducto,
			NombreProducto1				= @NombreProducto1,
			NombreProducto2				= @NombreProducto2,
			CodigoMarcaProducto			= @CodigoMarcaProducto,
			CodigoTipoProducto			= @CodigoTipoProducto,
			CodigoUnidad				= @CodigoUnidad,
			CodigoTipoCalculoInventario	= @CodigoTipoCalculoInventario,
			LlenarCodigoPE				= @LlenarCodigoPE,
			ProductoTangible			= @ProductoTangible,
			ProductoSimple				= @ProductoSimple,
			CalcularPrecioVenta			= @CalcularPrecioVenta,
			Descripcion					= @Descripcion,
			Observaciones				= @Observaciones
		WHERE @CodigoProducto = CodigoProducto
	ELSE
		RAISERROR ('EL NOMBRE DEL PRODUCTO YA SE ENCUENTRA REGISTRADO',16,2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION



	
END
GO

DROP PROCEDURE EliminarProducto
GO

CREATE PROCEDURE EliminarProducto
	@CodigoProducto CHAR(15)
AS
BEGIN
	BEGIN TRANSACTION
		DELETE 
		FROM dbo.InventariosProductos
		WHERE CantidadExistencia = 0
		
		DELETE 
		FROM dbo.Productos
		WHERE (CodigoProducto = @CodigoProducto)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO ELIMINAR CORRECTAMENTE EL REGISTRO, PROBABLEMENTE EL SERVICIO YA SE ENCUENTRA EN USO EN ALGUNA TRANSACCIÓN',2,16)
	END
	ELSE
		COMMIT TRANSACTION
END
GO

DROP PROCEDURE ListarProductos
GO

CREATE PROCEDURE ListarProductos
AS
BEGIN
	SELECT CodigoProducto,CodigoProductoFabricante, NombreProducto,NombreProducto1, NombreProducto2,CodigoMarcaProducto, CodigoTipoProducto,CodigoUnidad, CodigoTipoCalculoInventario,LlenarCodigoPE, ProductoTangible,ProductoSimple, CalcularPrecioVenta,Descripcion, Observaciones
	FROM dbo.Productos
	ORDER BY CodigoProducto
END
GO

DROP PROCEDURE ObtenerProducto
GO

CREATE PROCEDURE ObtenerProducto
	@CodigoProducto CHAR(15)
AS
BEGIN
	SELECT CodigoProducto, CodigoProductoFabricante, NombreProducto,NombreProducto1, NombreProducto2,CodigoMarcaProducto, CodigoTipoProducto,CodigoUnidad, CodigoTipoCalculoInventario,LlenarCodigoPE, ProductoTangible,ProductoSimple, CalcularPrecioVenta,Descripcion, Observaciones
	FROM dbo.Productos
	WHERE CodigoProducto = @CodigoProducto
END
GO

DROP PROCEDURE ListarProductosPorTipoProducto
GO

CREATE PROCEDURE ListarProductosPorTipoProducto
	@CodigoTipoProducto	INT
AS
BEGIN
	SELECT CodigoProducto,CodigoProductoFabricante, NombreProducto,NombreProducto1, NombreProducto2,CodigoMarcaProducto, CodigoTipoProducto,CodigoUnidad, CodigoTipoCalculoInventario,LlenarCodigoPE, ProductoTangible,ProductoSimple, CalcularPrecioVenta,Descripcion, Observaciones
	FROM dbo.Productos
	WHERE CodigoTipoProducto = @CodigoTipoProducto
	ORDER BY CodigoProducto
END
GO



DROP PROCEDURE ListarProductosReporte
GO

CREATE PROCEDURE ListarProductosReporte
AS
BEGIN
	SELECT Pr.CodigoProducto, Pr.CodigoProductoFabricante, Pr.NombreProducto, Pr.NombreProducto1,
	Pr.NombreProducto2, PM.NombreMarcaProducto, PT.NombreTipoProducto, PU.NombreUnidad,
	TipoCalculoInventario = CASE Pr.CodigoTipoCalculoInventario WHEN 'U' THEN 'UEPS' WHEN 'P' THEN 'PEPS' 
	WHEN 'O' THEN 'PONDERADO' WHEN 'B' THEN 'PRECIO MAS BAJO' WHEN 'A' THEN 'PRECIO MAS ALTO' END,
	Pr.ProductoTangible, Pr.ProductoSimple, Pr.CalcularPrecioVenta, Pr.Descripcion, Pr.Observaciones
	FROM Productos Pr
	JOIN ProductosMarcas PM ON
	PM.CodigoMarcaProducto = Pr.CodigoMarcaProducto
	JOIN ProductosTipos PT ON
	PT.CodigoTipoProducto = Pr.CodigoTipoProducto
	JOIN ProductosUnidades PU ON
	PU.CodigoUnidad = Pr.CodigoUnidad
END
GO

DROP PROCEDURE ListarProductosSimplesLibresPorCodigoProducto
GO

CREATE PROCEDURE ListarProductosSimplesLibresPorCodigoProducto
@CodigoProducto				CHAR(15),
@CodigoProductoComponente	CHAR(15)
AS
BEGIN
	
	SELECT P.CodigoProducto, P.CodigoProductoFabricante, P.NombreProducto, P.NombreProducto1, P.NombreProducto2, P.CodigoMarcaProducto, P.CodigoTipoProducto, P.CodigoUnidad, P.CodigoTipoCalculoInventario, P.LlenarCodigoPE, P.ProductoTangible, P.ProductoSimple, P.CalcularPrecioVenta, P.Descripcion, P.Observaciones
	FROM dbo.Productos P
	WHERE P.ProductoSimple = 1
	AND P.CodigoProducto NOT IN (
	SELECT PC.CodigoProductoComponente
	FROM ProductosCompuestos PC
	WHERE PC.CodigoProducto = @CodigoProducto)
	OR P.CodigoProducto = @CodigoProductoComponente
	ORDER BY CodigoProducto
END
