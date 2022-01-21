USE Doblones20
GO

DROP FUNCTION AsignarCodigoCompra
GO

CREATE FUNCTION AsignarCodigoCompra(@NumeroAgencia INT, @NumeroCompraProducto INT)
RETURNS CHAR(12)
WITH ENCRYPTION
AS
BEGIN
	DECLARE @CodigoCompraProducto	CHAR(12),
			@FechaHoraCompra		DATETIME	
	
	SELECT @FechaHoraCompra = Fecha
	FROM ComprasProductos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroCompraProducto = @NumeroCompraProducto
	
	SELECT TOP(1) @CodigoCompraProducto = RIGHT('0000' + RTRIM(CAST(ROW_NUMBER() OVER(ORDER BY Fecha DESC) AS CHAR(8))), 4) 
				 + '-'+ RIGHT('0' + RTRIM(CAST( DATEPART(MONTH, Fecha) AS CHAR(2))), 2)
				 + '-' + CAST( DATEPART(YEAR, Fecha) AS CHAR(4))
	FROM ComprasProductos
	WHERE Fecha BETWEEN DBO.ObtenerPrimerDiaMes(@FechaHoraCompra) AND @FechaHoraCompra
	ORDER BY Fecha, NumeroCompraProducto
	
	RETURN ISNULL(@CodigoCompraProducto,'0001-' +  RIGHT('0' + RTRIM(CAST(DATEPART(MONTH, @FechaHoraCompra) AS CHAR(2))),2) 
			+ '-' + RTRIM(CAST(DATEPART(MONTH, @FechaHoraCompra) AS CHAR(2))))
END
GO


--SELECT ROW_NUMBER() OVER(ORDER BY Fecha asc) AS NumeroTransaccion, Fecha, NumeroCompraProducto, DBO.AsignarCodigoCompra	(NumeroAgencia, NumeroCompraProducto) AS CodigoAsignado 
--	FROM ComprasProductos
--	WHERE Fecha BETWEEN DBO.ObtenerPrimerDiaMes(GETDATE()) AND '20110513 13:10:25.640'
--	ORDER BY Fecha, NumeroCompraProducto
	

--DESHABILITAR EL TRIGGER DE COMPRAS TEMPORALMENTE

UPDATE ComprasProductos
	SET CodigoCompraProducto = DBO.AsignarCodigoCompra	(NumeroAgencia, NumeroCompraProducto)


--SELECT * FROM ComprasProductos
--ORDER BY Fecha, NumeroCompraProducto