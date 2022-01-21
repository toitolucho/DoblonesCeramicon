USE DOBLONES20
GO


DROP PROCEDURE ObtenerCodigoProductoPorCodigoProductoEspecifico
GO

CREATE PROCEDURE ObtenerCodigoProductoPorCodigoProductoEspecifico
	@NumeroAgencia				INT,
	@CodigoProductoEspecifico	CHAR(30),
	@CodigoProducto				CHAR(15) OUTPUT
AS
BEGIN
	SELECT @CodigoProducto = RTRIM(LTRIM(IPE.CodigoProducto))
	FROM InventariosProductosEspecificos IPE
	WHERE IPE.CodigoProductoEspecifico = @CodigoProductoEspecifico
	AND IPE.NumeroAgencia = @NumeroAgencia	
END


--DECLARE @Nombre	CHAR(15)
--EXEC ObtenerCodigoProductoPorCodigoProductoEspecifico 1,'001-TAR-000007-00006', @Nombre output
--SELECT @Nombre

