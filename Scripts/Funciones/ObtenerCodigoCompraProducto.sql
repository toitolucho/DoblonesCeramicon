USE Doblones20
GO

DROP FUNCTION ObtenerCodigoCompraProducto
GO

CREATE FUNCTION ObtenerCodigoCompraProducto()
RETURNS CHAR(12)
WITH ENCRYPTION
AS
BEGIN
	DECLARE @CodigoCompraProducto	CHAR(12)
	DECLARE	@FechaHoraActual		DATE = GETDATE(),
			@CantidadTotalCompras	INT
	
	
	SELECT @CantidadTotalCompras = ISNULL(COUNT(*),0)
	FROM ComprasProductos CP
	WHERE DATEPART(MONTH,CP.Fecha ) = DATEPART(MONTH, GETDATE())
	
	SET @CantidadTotalCompras = @CantidadTotalCompras + 1
	
	SET @CodigoCompraProducto = RIGHT('000'+ RTRIM(CAST(@CantidadTotalCompras AS CHAR(4))),4 )
	+ '-' + RIGHT('0'+ RTRIM(CAST(DATEPART(MONTH,@FechaHoraActual) AS CHAR(2))),2 )
	+ '-' + CAST(DATEPART(YEAR, @FechaHoraActual) AS CHAR(4))
	
	RETURN @CodigoCompraProducto
END
GO

--SELECT dbo.ObtenerCodigoCompraProducto()

