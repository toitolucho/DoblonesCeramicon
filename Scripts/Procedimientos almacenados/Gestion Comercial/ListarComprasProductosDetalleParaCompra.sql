
USE DOBLONES20
GO

DROP PROCEDURE ListarComprasProductosDetalleParaCompra
GO
--ListarVentasProductosDetalleParaCompra
CREATE PROCEDURE ListarComprasProductosDetalleParaCompra
	@NumeroAgencia			INT,  -- Si es -1, para listar sin filtrado
	@NumeroCompraProducto	INT
AS
BEGIN
	--Listamos todas las Ventas para una Determinada Agencia
	IF (@NumeroAgencia >0)
	BEGIN
		SELECT CPD.NumeroAgencia, CPD.NumeroCompraProducto, CPD.CodigoProducto, P.NombreProducto,CPD.CantidadCompra, CPD.PrecioUnitarioCompra, CPD.TiempoGarantiaCompra 
		FROM dbo.ComprasProductosDetalle CPD INNER JOIN Productos P ON P.CodigoProducto = CPD.CodigoProducto
		WHERE CPD.NumeroAgencia = @NumeroAgencia AND CPD.NumeroCompraProducto = @NumeroCompraProducto
		ORDER BY CPD.NumeroAgencia,CPD.NumeroCompraProducto
	END
	--Listamos Absolutamente todas las Ventas Realizadas por todas las Agencias
	IF (@NumeroAgencia = -1)
	BEGIN
		SELECT CPD.NumeroAgencia, CPD.NumeroCompraProducto, CPD.CodigoProducto, P.NombreProducto,CPD.CantidadCompra, CPD.PrecioUnitarioCompra, CPD.TiempoGarantiaCompra
		FROM dbo.ComprasProductosDetalle CPD INNER JOIN Productos P ON P.CodigoProducto = CPD.CodigoProducto		
		ORDER BY CPD.NumeroAgencia,CPD.NumeroCompraProducto
	END
END

