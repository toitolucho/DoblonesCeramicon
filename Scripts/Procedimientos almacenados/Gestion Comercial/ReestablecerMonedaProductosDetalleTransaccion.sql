USE Doblones20
GO


DROP PROCEDURE ReestablecerMonedaProductosDetalleTransaccion
GO


CREATE PROCEDURE ReestablecerMonedaProductosDetalleTransaccion
	@NumeroAgencia			INT,	
	@DetalleProductosXML	TEXT	
AS
BEGIN
	DECLARE @punteroXMLProductosDetalle INT
			

	EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @DetalleProductosXML	

	--SET @S = 'SELECT DISTINCT P.CodigoProducto, P.NombreProducto, PM.NombreMarcaProducto, PU.NombreUnidad , IP.PrecioUnitarioVenta1, IP.PrecioUnitarioVenta2, IP.PrecioUnitarioVenta3 , CAST(IP.PrecioUnitarioVenta1 + IP.PrecioUnitarioVenta1 * 13 /100  AS DECIMAL(10,2)) AS PrecioUnitarioVenta4, CAST(IP.PrecioUnitarioVenta2 + IP.PrecioUnitarioVenta2 * 13 /100 AS DECIMAL(10,2)) AS PrecioUnitarioVenta5 , CAST(IP.PrecioUnitarioVenta3 + IP.PrecioUnitarioVenta3 * 13 /100 as DECIMAL(10,2)) AS PrecioUnitarioVenta6 ,  IP.CantidadExistencia'
	
	SELECT  TXML.CodigoProducto, 
			TXML.Cantidad *
			CASE 
			WHEN NumeroPrecioSeleccionado = '1' THEN IP.PrecioUnitarioVenta1
			WHEN NumeroPrecioSeleccionado = '2' THEN IP.PrecioUnitarioVenta2
			WHEN NumeroPrecioSeleccionado = '3' THEN IP.PrecioUnitarioVenta3
			END AS PrecioTotal,
			CASE 
			WHEN NumeroPrecioSeleccionado = '1' THEN IP.PrecioUnitarioVenta1
			WHEN NumeroPrecioSeleccionado = '2' THEN IP.PrecioUnitarioVenta2
			WHEN NumeroPrecioSeleccionado = '3' THEN IP.PrecioUnitarioVenta3
			END AS Precio				
	FROM OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)
	WITH(
			CodigoProducto				CHAR(15),
			Cantidad					INT,
			NumeroPrecioSeleccionado	CHAR(1)			
		)TXML
	INNER JOIN InventariosProductos IP
	ON TXML.CodigoProducto = IP.CodigoProducto
	AND IP.NumeroAgencia = @NumeroAgencia
	
	EXEC sp_xml_removedocument @punteroXMLProductosDetalle

END
GO


exec ReestablecerMonedaProductosDetalleTransaccion 1, '<Productos>
  <ProductosDetalle>
    <CodigoProducto>001-MOU-000028</CodigoProducto>
    <Cantidad>1</Cantidad>
    <NumeroPrecioSeleccionado>1</NumeroPrecioSeleccionado>
  </ProductosDetalle>
  <ProductosDetalle>
    <CodigoProducto>001-MOU-000027</CodigoProducto>
    <Cantidad>1</Cantidad>
    <NumeroPrecioSeleccionado>1</NumeroPrecioSeleccionado>
  </ProductosDetalle>
  <ProductosDetalle>
    <CodigoProducto>003-SET-000001</CodigoProducto>
    <Cantidad>1</Cantidad>
    <NumeroPrecioSeleccionado>1</NumeroPrecioSeleccionado>
  </ProductosDetalle>
</Productos>'