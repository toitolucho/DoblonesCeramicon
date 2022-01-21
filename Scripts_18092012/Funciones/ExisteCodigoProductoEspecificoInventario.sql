

USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.ExisteCodigoProductoEspecificoInventario', N'FN') IS NOT NULL
    DROP FUNCTION dbo.ExisteCodigoProductoEspecificoInventario; 
GO

CREATE FUNCTION dbo.ExisteCodigoProductoEspecificoInventario (@CodigoProducto CHAR(15), @CodigoProductoEspecifico CHAR(30))
RETURNS BIT
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @Existe		BIT
	
	IF EXISTS(SELECT * FROM dbo.InventariosProductosEspecificos
			  WHERE CodigoProducto = @CodigoProducto AND CodigoProductoEspecifico = @CodigoProductoEspecifico)
		SET @Existe = 1
	else
		SET @Existe = 0

   	RETURN(@Existe)
END
GO
