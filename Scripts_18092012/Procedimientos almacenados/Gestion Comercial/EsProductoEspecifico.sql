USE DOBLONES20
GO


DROP PROCEDURE EsProductoEspecificoSP
GO


CREATE PROCEDURE EsProductoEspecificoSP
	@CodigoProducto CHAR(15),
	@EsProdEspe		BIT OUTPUT
AS
BEGIN
	SELECT @EsProdEspe = IP.EsProductoEspecifico
	FROM InventariosProductos IP 
	WHERE IP.CodigoProducto = @CodigoProducto	
	IF(@EsProdEspe is null)
		SET @EsProdEspe = 0;
END


--USE DOBLONES20
--GO

--IF OBJECT_ID (N'dbo.EsProductoEspecifico', N'FN') IS NOT NULL
--    DROP FUNCTION dbo.EsProductoEspecifico; 
--GO

--CREATE FUNCTION dbo.EsProductoEspecifico (@CodigoProducto CHAR(15))
--RETURNS BIT
--WITH EXECUTE AS CALLER
--AS
--BEGIN
--	DECLARE @EsProdEspe		BIT
	
--	SELECT @EsProdEspe = IP.EsProductoEspecifico
--	FROM InventariosProductos IP 
--	WHERE IP.CodigoProducto = @CodigoProducto
	
--	IF(@EsProdEspe is null)
--		SET @EsProdEspe = 0;

--   	RETURN(@EsProdEspe)
--END
--GO


--DECLARE @ESP BIT
--EXEC EsProductoEspecifico '505',@ESP OUTPUT	
--SELECT 	@ESP
--SELECT DBO.EsProductoEspecifico ('1ÇDF')

