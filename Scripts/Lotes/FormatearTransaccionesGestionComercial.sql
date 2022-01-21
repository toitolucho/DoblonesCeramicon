USE DOBLONES20

DELETE FROM VentasProductosReemplazoDevolucionesDetalle
DELETE FROM VentasProductosReemplazoDevoluciones
DBCC checkident ('DOBLONES20.dbo.VentasProductosReemplazoDevoluciones', reseed, 0)

DELETE FROM VentasProductosReemplazoEspecificos
DELETE FROM VentasProductosReemplazoDetalle
DELETE FROM VentasProductosReemplazo
DBCC checkident ('DOBLONES20.dbo.VentasProductosReemplazo', reseed, 0)

DELETE FROM VentasProductosDevolucionesEspecificos
DELETE FROM VentasProductosDevolucionesDetalle
DELETE FROM VentasProductosDevoluciones
DBCC checkident ('DOBLONES20.dbo.VentasProductosDevoluciones', reseed, 0)

DELETE FROM VentasProductosEspecificosAgregados
DELETE FROM VentasProductosEspecificos
DELETE FROM VentasProductosDetalle
DELETE FROM VentasProductos
DBCC checkident ('DOBLONES20.dbo.VentasProductos', reseed, 0)


DELETE FROM ComprasProductosDevolucionesEspecificos
DELETE FROM ComprasProductosDevolucionesDetalle
DELETE FROM ComprasProductosDevoluciones

DELETE FROM ComprasProductosEspecificosAgregados
DELETE FROM ComprasProductosEspecificos
DELETE FROM ComprasProductosDetalle
DELETE FROM ComprasProductos
DBCC checkident ('DOBLONES20.dbo.ComprasProductos', reseed, 0)

DELETE FROM CuentasPorPagar
DBCC checkident ('DOBLONES20.dbo.CuentasPorPagar', reseed, 0)

DELETE FROM CotizacionVentasProductosDeta
DELETE FROM CotizacionVentasProductos
DBCC checkident ('DOBLONES20.dbo.CotizacionVentasProductos', reseed, 0)


insert into CotizacionVentasProductos (NumeroAgencia, CodigoCliente, CodigoUsuario, FechaHoraCotizacion,	ValidezOferta, TiempoEntrega, CodigoEstadoCotizacion, CotizacionVendida, CodigoMonedaCotizacionVenta, Observaciones)
values (1,5,1,getdate(),10,10,'I',0,1,'ninguna')
insert into ComprasProductos( NumeroAgencia, CodigoProveedor,CodigoUsuario,Fecha,CodigoTipoCompra,CodigoEstadoCompra,MontoTotalCompra,Observaciones)
values (1,19,1,GETDATE(),'R','F',	432.00,'ninguna'	)
INSERt INTO VentasProductos (NumeroAgencia, CodigoCliente,CodigoUsuario, NumeroFactura, FechaHoraVenta, CodigoEstadoVenta, NumeroCredito,Observaciones)
values (1,1,1,null,getdate(),'F',NULL,'ninguna')


DELETE FROM VentasProductosEspecificosAgregados
DELETE FROM VentasProductosEspecificos
DELETE FROM VentasProductosDetalle
DELETE FROM VentasProductos
DBCC checkident ('DOBLONES20.dbo.VentasProductos', reseed, 0)

DELETE FROM ComprasProductosEspecificosAgregados
DELETE FROM ComprasProductosEspecificos
DELETE FROM ComprasProductosDetalle
DELETE FROM ComprasProductos
DBCC checkident ('DOBLONES20.dbo.ComprasProductos', reseed, 0)

DELETE FROM CotizacionVentasProductosDeta
DELETE FROM CotizacionVentasProductos
DBCC checkident ('DOBLONES20.dbo.CotizacionVentasProductos', reseed, 0)

DELETE FROM VentasFacturas

DELETE FROM InventariosProductosEspecificos

UPDATE InventariosProductos SET EsProductoEspecifico = 0, ProductoEspecificoInventariado = 0

UPDATE Agencias SET NumeroSiguienteFactura = 1


delete from SistemaGruposUsuarios where CodigoUsuario <> 1
delete from UsuariosAgenciasPermisosInterfaces where CodigoUsuario <> 1
delete from UsuariosAgenciasMenuPrincipal where CodigoUsuario <> 1
delete from Usuarios where CodigoUsuario <> 1

INSERT INTO dbo.ProductosTiposGarantias(NombreTipoGarantia, Descripcion)
VALUES ('GARANTIA 1','DESCRIPCION')
SELECT * FROM ProductosTiposGarantias

INSERT INTO InventariosProductos (NumeroAgencia, CodigoProducto, CantidadExistencia, CantidadRequerida, PrecioUnitarioCompra, PrecioUnitarioCompraSinGastos, 
	TiempoGarantiaProducto, CotigoTipoGarantia, PorcentajeUtilidad1, PrecioUnitarioVenta1, PorcentajeUtilidad2, PrecioUnitarioVenta2, PorcentajeUtilidad3, PrecioUnitarioVenta3, PorcentajeUtilidad4, PrecioUnitarioVenta4, PorcentajeUtilidad5, PrecioUnitarioVenta5, PorcentajeUtilidad6, PrecioUnitarioVenta6, 
	PorcentajeComision1, PorcentajeComision2, PorcentajeComision3, 
	StockMinimo, MostrarParaVenta, ClaseProducto, EsProductoEspecifico, ProductoEspecificoInventariado, PrecioValoradoTotal)
SELECT 1, CodigoProducto, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0,0, 0,0, 0,0, 0,0, 0, 0, 0, 0, 0, 1, 'S', 0, 0, 0
FROM Productos