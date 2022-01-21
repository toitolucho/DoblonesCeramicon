USE DOBLONES20
GO


DROP PROCEDURE ObtenerUltimoClienteInsertado
GO


CREATE PROCEDURE ObtenerUltimoClienteInsertado
	@ListadoAtributosCliente VARCHAR(8000) OUTPUT
AS
BEGIN	
	SELECT  TOP 1 @ListadoAtributosCliente = RTRIM(LTRIM(CAST( CodigoCliente AS CHAR(1000)))) +','+ RTRIM(LTRIM(isnull(NombreCliente,''))) +','+ RTRIM(LTRIM(isnull(NITCliente,''))) 
	FROM Clientes
	ORDER BY CodigoCliente DESC
END


--DECLARE @ListadoAtributosCliente VARCHAR(8000)
--EXEC ObtenerUltimoClienteInsertado @ListadoAtributosCliente OUTPUT 
--PRINT @ListadoAtributosCliente