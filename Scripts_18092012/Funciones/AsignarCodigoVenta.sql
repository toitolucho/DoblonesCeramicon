USE Doblones20
GO

DROP FUNCTION AsignarCodigoVenta
GO

CREATE FUNCTION AsignarCodigoVenta(@NumeroAgencia INT, @NumeroVentaProducto INT)
RETURNS CHAR(12)
WITH ENCRYPTION
AS
BEGIN
	DECLARE @CodigoVentaProducto	CHAR(12),
			@FechaHoraVenta		DATETIME	
	
	SELECT @FechaHoraVenta = FechaHoraVenta
	FROM VentasProductos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
	
	SELECT TOP(1) @CodigoVentaProducto = RIGHT('0000' + RTRIM(CAST(ROW_NUMBER() OVER(ORDER BY FechaHoraVenta DESC) AS CHAR(8))), 4) 
				 + '-'+ RIGHT('0' + RTRIM(CAST( DATEPART(MONTH, FechaHoraVenta) AS CHAR(2))), 2)
				 + '-' + CAST( DATEPART(YEAR, FechaHoraVenta) AS CHAR(4))
	FROM VentasProductos
	WHERE FechaHoraVenta BETWEEN DBO.ObtenerPrimerDiaMes(@FechaHoraVenta) AND @FechaHoraVenta
	ORDER BY FechaHoraVenta, NumeroVentaProducto
	
	RETURN ISNULL(@CodigoVentaProducto,'0001-' +  RIGHT('0' + RTRIM(CAST(DATEPART(MONTH, @FechaHoraVenta) AS CHAR(2))),2) 
			+ '-' + RTRIM(CAST(DATEPART(MONTH, @FechaHoraVenta) AS CHAR(2))))
END
GO


--SELECT ROW_NUMBER() OVER(ORDER BY Fecha asc) AS NumeroTransaccion, Fecha, NumeroVentaProducto, DBO.AsignarCodigoVenta	(NumeroAgencia, NumeroVentaProducto) AS CodigoAsignado 
--	FROM VentasProductos
--	WHERE Fecha BETWEEN DBO.ObtenerPrimerDiaMes(GETDATE()) AND '20110513 13:10:25.640'
--	ORDER BY Fecha, NumeroVentaProducto
	

--DESHABILITAR EL TRIGGER DE VentaS TEMPORALMENTE

UPDATE VentasProductos
	SET CodigoVentaProducto = DBO.AsignarCodigoVenta	(NumeroAgencia, NumeroVentaProducto)


SELECT * FROM VentasProductos
ORDER BY FechaHoraVenta, NumeroVentaProducto