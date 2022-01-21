USE Doblones20
GO

--Lote para actualizar inventario productos con factura de acuerdo a los 3 primeros precios

DECLARE @PorcentajeImpustoIVA DECIMAL(10,2)
SELECT TOP(1) @PorcentajeImpustoIVA = PorcentajeImpuesto FROM PCsConfiguraciones
UPDATE InventariosProductos
SET	
	PrecioUnitarioVenta4 = PrecioUnitarioVenta1 + PrecioUnitarioVenta1 * @PorcentajeImpustoIVA / 100,
	PrecioUnitarioVenta5 = PrecioUnitarioVenta2 + PrecioUnitarioVenta2 * @PorcentajeImpustoIVA / 100,
	PrecioUnitarioVenta6 = PrecioUnitarioVenta2 + PrecioUnitarioVenta3 * @PorcentajeImpustoIVA / 100


SELECT PrecioUnitarioVenta1, PrecioUnitarioVenta2, PrecioUnitarioVenta3, PrecioUnitarioVenta4, PrecioUnitarioVenta5, PrecioUnitarioVenta6
FROM InventariosProductos
WHERE CodigoProducto IN ('63','67','830')