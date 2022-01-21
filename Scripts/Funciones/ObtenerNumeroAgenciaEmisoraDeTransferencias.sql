
USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias', N'FN') IS NOT NULL
    DROP FUNCTION dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias; 
GO

CREATE FUNCTION dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias (@NumeroTransferenciaProducto INT, @NumeroAgenciaReceptora INT)
RETURNS INT
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @NumeroAgenciaEmisora		INT = -1
	
	SELECT @NumeroAgenciaEmisora = NumeroAgenciaEmisora
	FROM dbo.TransferenciasProductos
	WHERE NumeroTransferenciaProducto = @NumeroTransferenciaProducto and NumeroAgenciaRecepctora = @NumeroAgenciaReceptora
   	RETURN (ISNULL(@NumeroAgenciaEmisora,-1))
END
GO
