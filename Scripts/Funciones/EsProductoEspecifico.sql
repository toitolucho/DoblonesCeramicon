--USE DOBLONES20
--GO


--DROP PROCEDURE EsProductoEspecifico
--GO


--CREATE PROCEDURE EsProductoEspecifico
--	@CodigoProducto CHAR(15),
--	@EsProdEspe		BIT OUTPUT
--AS
--BEGIN
--	SELECT @EsProdEspe = IP.EsProductoEspecifico
--	FROM InventariosProductos IP 
--	WHERE IP.CodigoProducto = @CodigoProducto	
--END


USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.EsProductoEspecifico', N'FN') IS NOT NULL
    DROP FUNCTION dbo.EsProductoEspecifico; 
GO

CREATE FUNCTION dbo.EsProductoEspecifico (@NumeroAgencia INT, @CodigoProducto CHAR(15))
RETURNS BIT
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @EsProdEspe		BIT
	
	SELECT TOP(1) @EsProdEspe = IP.EsProductoEspecifico
	FROM InventariosProductos IP 
	WHERE IP.CodigoProducto = @CodigoProducto
	AND NumeroAgencia = @NumeroAgencia
   	RETURN(@EsProdEspe)
END
GO


--DECLARE @ESP BIT
--EXEC EsProductoEspecifico '505',@ESP OUTPUT	
--SELECT 	@ESP
--SELECT DBO.EsProductoEspecifico (1,'1')




--SELECT IP.EsProductoEspecifico
--FROM InventariosProductos IP 
--WHERE IP.CodigoProducto = '1'