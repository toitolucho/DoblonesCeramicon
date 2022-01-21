USE Doblones20
GO

DROP PROCEDURE ListarInventarioMercaderiaEnTransito
GO

CREATE PROCEDURE ListarInventarioMercaderiaEnTransito
	@NumeroAgencia		INT,
	@ParaProveedores	BIT
WITH ENCRYPTION
AS 
BEGIN
	SELECT NumeroAgencia, NombreRazonSocial, NumeroCompraProducto, CodigoProducto, NombreProducto, PrecioUnitarioCompra, CantidadCompra, CantidadRecepcionada, CantidadTransito
	FROM InventarioMercaderiaEnTransito
	WHERE CantidadTransito > 0
	AND NumeroAgencia = @NumeroAgencia
	ORDER BY 1, CASE WHEN @ParaProveedores = 1 THEN NombreRazonSocial ELSE NombreProducto END, 
			CASE WHEN @ParaProveedores = 0 THEN NombreRazonSocial ELSE NombreProducto END

END
GO


DROP PROCEDURE ListarInventarioMercaderiaEnTransitoFisico
GO

CREATE PROCEDURE ListarInventarioMercaderiaEnTransitoFisico
	@NumeroAgencia	INT
WITH ENCRYPTION
AS
BEGIN
	SELECT IMETF.* , PU.NombreUnidad, IP.CantidadExistencia
	FROM InventarioMercaderiaEnTransitoFisico IMETF
	INNER JOIN Productos P
	ON IMETF.CodigoProducto = P.CodigoProducto
	INNER JOIN ProductosUnidades PU
	ON P.CodigoUnidad = PU.CodigoUnidad
	INNER JOIN InventariosProductos IP
	ON IMETF.CodigoProducto = IP.CodigoProducto
	WHERE IMETF.CantidadEnTransito > 0
	AND IMETF.NumeroAgencia = @NumeroAgencia
END
GO

