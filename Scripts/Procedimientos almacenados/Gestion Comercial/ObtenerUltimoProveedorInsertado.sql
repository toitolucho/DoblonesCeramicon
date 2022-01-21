USE DOBLONES20
GO


DROP PROCEDURE ObtenerUltimoProveedorInsertado
GO


CREATE PROCEDURE ObtenerUltimoProveedorInsertado
@ListadoAtributosProveedor VARCHAR(8000) OUTPUT
AS
BEGIN
	SELECT  TOP 1 @ListadoAtributosProveedor = RTRIM(LTRIM(CAST(CodigoProveedor AS CHAR (1000)))) +','+ RTRIM(LTRIM(NombreRazonSocial)) +','+LTRIM(RTRIM(NITProveedor))
	FROM Proveedores
	ORDER BY CodigoProveedor DESC
END

--DECLARE @ListadoAtributosCliente VARCHAR(8000)
--EXEC ObtenerUltimoProveedorInsertado @ListadoAtributosCliente OUTPUT 
--PRINT @ListadoAtributosCliente