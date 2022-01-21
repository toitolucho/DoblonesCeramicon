
USE DOBLONES20
GO

DROP PROCEDURE ListarVentasProductosDetalleParaVenta
GO

CREATE PROCEDURE ListarVentasProductosDetalleParaVenta
	@NumeroAgencia	INT,  -- Si es -1, para listar sin filtrado
	@NumeroVenta	INT
AS
BEGIN
	--Listamos todas las Ventas para una Determinada Agencia
	IF (@NumeroAgencia >0)
	BEGIN
		SELECT VPD.NumeroAgencia, VPD.NumeroVentaProducto, VPD.CodigoProducto, P.NombreProducto,VPD.CantidadVenta, VPD.PrecioUnitarioVenta, VPD.TiempoGarantiaVenta, VPD.CantidadEntregada, PorcentajeDescuento, NumeroPrecioSeleccionado, PrecioUnitarioVentaOtraMoneda
		FROM ventasproductosdetalle VPD 
		INNER JOIN Productos P 
		ON P.CodigoProducto = VPD.CodigoProducto
		WHERE VPD.NumeroAgencia = @NumeroAgencia
		AND VPD.NumeroVentaProducto = @NumeroVenta
		ORDER BY VPD.NumeroAgencia,VPD.NumeroVentaProducto, VPD.NumeroOrdenInsertado
	END
	--Listamos Absolutamente todas las Ventas Realizadas por todas las Agencias
	IF (@NumeroAgencia = -1)
	BEGIN
		SELECT VPD.NumeroAgencia, VPD.NumeroVentaProducto, VPD.CodigoProducto, P.NombreProducto,VPD.CantidadVenta, VPD.PrecioUnitarioVenta, VPD.TiempoGarantiaVenta, VPD.CantidadEntregada, PorcentajeDescuento, NumeroPrecioSeleccionado, PrecioUnitarioVentaOtraMoneda
		FROM ventasproductosdetalle VPD 
		INNER JOIN Productos P 
		ON P.CodigoProducto = VPD.CodigoProducto		
		ORDER BY VPD.NumeroAgencia,VPD.NumeroVentaProducto, VPD.NumeroOrdenInsertado
	END
END

