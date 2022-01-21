USE DOBLONES20
DROP PROCEDURE BuscarProductoAvanzadaVentas
GO

CREATE PROCEDURE BuscarProductoAvanzadaVentas
	@NumeroAgencia				INT,
	@CodigoProducto				CHAR(15),
	@NombreProducto				VARCHAR(250),
	@NombreProducto1			VARCHAR(250),
	@NombreProducto2			VARCHAR(250),
	@NombreMarcaProducto		VARCHAR(250),
	@NombreTipoProducto			VARCHAR(250),
	@NombreUnidad				VARCHAR(250),
	@CantidadMinimaEnExistencia INT,
	@TipoBusqueda				CHAR(1) -- G:General, M:Marca, T:Tipos, U:Unidades	
AS
BEGIN
DECLARE 
	@ConsultaSql			NVARCHAR(4000),
	@Filtro					VARCHAR(450),
	@CodigoUnidad			INT,
	@CodigoTipoProducto		INT,
	@CodigoMarcaProducto	INT,
	@ScriptSql				NVARCHAR(4000)
	
	SET @ConsultaSql = 'SELECT P.CodigoProducto,P.NombreProducto,IP.PrecioUnitarioVenta1,IP.PrecioUnitarioVenta2,IP.PrecioUnitarioVenta3,IP.PrecioUnitarioVenta4,IP.PrecioUnitarioVenta5, IP.CantidadExistencia, IP.TiempoGarantiaProducto, CASE	WHEN (exists(select * from dbo.InventariosProductosEspecificos IPE where (IP.CodigoProducto = IPE.CodigoProducto))) THEN 1 ELSE 0 END AS EsProductoEspecifico ';
	SET @ConsultaSql = @ConsultaSql + 'FROM dbo.Productos P INNER JOIN InventariosProductos IP ON P.CodigoProducto = IP.CodigoProducto ';
	SET @Filtro = '';
	SET @Filtro = @Filtro + ' WHERE RTRIM(LTRIM(P.CodigoProducto)) LIKE RTRIM(LTRIM('''+@CodigoProducto+''')) + ''%'' ';
	SET @Filtro = @Filtro + ' AND RTRIM(LTRIM(P.NombreProducto)) LIKE RTRIM(LTRIM('''+@NombreProducto+''')) + ''%'' ';
	SET @Filtro = @Filtro + ' AND RTRIM(LTRIM(P.NombreProducto1)) LIKE RTRIM(LTRIM('''+@NombreProducto1+''')) + ''%'' ';
	SET @Filtro = @Filtro + ' AND RTRIM(LTRIM(P.NombreProducto2)) LIKE RTRIM(LTRIM('''+@NombreProducto2+''')) + ''%'' ';	
	SET @Filtro = @Filtro + ' AND IP.NumeroAgencia =' +RTRIM(CAST(@NumeroAgencia AS CHAR(1000)));	
	SET @Filtro = @Filtro + ' AND IP.CantidadExistencia > '+ RTRIM(CAST(@CantidadMinimaEnExistencia AS CHAR(1000)));			
	IF (@TipoBusqueda = 'G') 
	BEGIN
		SET @Filtro = @Filtro + ' ';
	END
	IF ((@TipoBusqueda = 'M') AND (@NombreMarcaProducto IS NOT NULL))
	BEGIN
		SELECT @CodigoMarcaProducto = ProductosMarcas.CodigoMarcaProducto 
		FROM ProductosMarcas 
		WHERE ProductosMarcas.NombreMarcaProducto = @NombreMarcaProducto
		
		SET @ConsultaSql = @ConsultaSql +' INNER JOIN ProductosMarcas PM ON P.CodigoMarcaProducto = PM.CodigoMarcaProducto';
		IF(@CodigoMarcaProducto IS NOT NULL)
			SET @Filtro = @Filtro + ' AND (P.CodigoMarcaProducto = '+CAST(@CodigoMarcaProducto AS VARCHAR(10)) +')';
	END
	IF ((@TipoBusqueda = 'T') AND (@NombreTipoProducto IS NOT NULL))
	BEGIN
		SELECT @CodigoTipoProducto = ProductosTipos.CodigoTipoProducto
		FROM ProductosTipos
		WHERE ProductosTipos.NombreTipoProducto = @NombreTipoProducto;		
		SET @ConsultaSql = @ConsultaSql +' INNER JOIN ProductosTipos PT ON P.CodigoTipoProducto = PT.CodigoTipoProducto';		
		IF(@CodigoTipoProducto IS NOT NULL)
			SET @Filtro = @Filtro + 'AND (P.CodigoTipoProducto = '+CAST(@CodigoTipoProducto AS VARCHAR(10))+')';
	END
	IF ((@TipoBusqueda = 'U') AND (@NombreUnidad IS NOT NULL))
	BEGIN
		SELECT @CodigoUnidad = ProductosUnidades.CodigoUnidad
		FROM ProductosUnidades
		WHERE ProductosUnidades.NombreUnidad = @NombreUnidad;		
		SET @ConsultaSql = @ConsultaSql +' INNER JOIN ProductosUnidades PU ON P.CodigoUnidad = PU.CodigoUnidad';
		IF(@CodigoUnidad IS NOT NULL)
			SET @Filtro = @Filtro + 'AND (P.CodigoUnidad = '+CAST(@CodigoUnidad AS VARCHAR(10))+')';
	END
	
	SET @ScriptSql = @ConsultaSql+@Filtro
	PRINT @ScriptSQL
	--SET @consulta = @ScriptSql
	EXEC(@ScriptSQL)	
END

