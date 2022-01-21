
USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.ObtenerCodigoTipoCalculoInventarioProducto', N'FN') IS NOT NULL
    DROP FUNCTION dbo.ObtenerCodigoTipoCalculoInventarioProducto; 
GO

CREATE FUNCTION dbo.ObtenerCodigoTipoCalculoInventarioProducto (@CodigoProducto CHAR(15))
RETURNS CHAR(1)
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @CodigoTipoCalculoInventario	CHAR(1)
	
	
	SELECT @CodigoTipoCalculoInventario = CodigoTipoCalculoInventario FROM Productos WHERE CodigoProducto = @CodigoProducto

   	RETURN(@CodigoTipoCalculoInventario)
END
GO

--SELECT dbo.ObtenerCodigoTipoCalculoInventarioProducto('100')
