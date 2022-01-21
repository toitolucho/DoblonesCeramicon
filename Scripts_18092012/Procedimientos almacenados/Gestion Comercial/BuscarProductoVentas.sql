USE DOBLONES20

DROP PROCEDURE BuscarProductoVentas
GO

CREATE PROCEDURE BuscarProductoVentas
	@NumeroAgencia				INT,
	@CodigoProducto				CHAR(15),
	@NombreProducto				VARCHAR(250),
	@NombreProducto1			VARCHAR(250),
	@NombreProducto2			VARCHAR(250),
	@CantidadMinimaEnExistencia INT	
AS
DECLARE
	@CodigoProductoTRIM			CHAR(15),
	@NombreProductoTRIM			VARCHAR(250),
	@NombreProducto1TRIM		VARCHAR(250),
	@NombreProducto2TRIM		VARCHAR(250)
BEGIN
	SET @CodigoProductoTRIM		= RTRIM(LTRIM(@CodigoProducto))
	SET @NombreProductoTRIM		= RTRIM(LTRIM(@NombreProducto))
	SET @NombreProducto1TRIM	= RTRIM(LTRIM(@NombreProducto1))
	SET @NombreProducto2TRIM	= RTRIM(LTRIM(@NombreProducto2))

SELECT P.CodigoProducto,P.NombreProducto,IP.PrecioUnitarioVenta1,IP.PrecioUnitarioVenta2,IP.PrecioUnitarioVenta3,IP.PrecioUnitarioVenta4,IP.PrecioUnitarioVenta5,IP.CantidadExistencia, IP.TiempoGarantiaProducto, CASE	WHEN (exists(select * from dbo.InventariosProductosEspecificos IPE where (IP.CodigoProducto = IPE.CodigoProducto and IPE.NumeroAgencia = @NumeroAgencia))) THEN 1
																																																					ELSE 0
																																																					END AS EsProductoEspecifico
	FROM dbo.Productos P INNER JOIN InventariosProductos IP ON P.CodigoProducto = IP.CodigoProducto
	WHERE RTRIM(LTRIM(P.CodigoProducto)) LIKE RTRIM(LTRIM(@CodigoProductoTRIM)) + '%'
	AND RTRIM(LTRIM(P.NombreProducto)) LIKE RTRIM(LTRIM(@NombreProductoTRIM)) + '%'
	AND RTRIM(LTRIM(P.NombreProducto1)) LIKE RTRIM(LTRIM(@NombreProducto1TRIM)) + '%'
	AND RTRIM(LTRIM(P.NombreProducto2)) LIKE RTRIM(LTRIM(@NombreProducto2TRIM)) + '%'
	AND (IP.NumeroAgencia = @NumeroAgencia)
	AND IP.CantidadExistencia>@CantidadMinimaEnExistencia
	ORDER BY P.NombreProducto
END

