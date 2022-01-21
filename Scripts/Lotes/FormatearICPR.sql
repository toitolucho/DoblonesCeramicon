USE Doblones20
GO

DELETE FROM dbo.ComprasProductosDocuImag
DELETE FROM dbo.ComprasProductosDevolucionesEspecificos
DELETE FROM dbo.ComprasProductosDevolucionesDetalle
DELETE FROM dbo.ComprasProductosDevoluciones
DELETE FROM dbo.CompraProductosGastosDetalle
DELETE FROM dbo.ComprasProductosEspecificosAgregados
DELETE FROM dbo.ComprasProductosEspecificos
DELETE FROM dbo.ComprasProductosDetalleEntrega
DELETE FROM dbo.ComprasProductosDetalle
DELETE FROM dbo.ComprasProductos
DBCC checkident ('DOBLONES20.dbo.ComprasProductos', reseed, 0) 

DELETE FROM TransferenciasProductosGastosDetalle
DELETE FROM TransferenciasProductosEspecificos
DELETE FROM TransferenciasProductosDetalleRecepcion
DELETE FROM TransferenciasProductosDetalle
DELETE FROM TransferenciasProductos
DBCC checkident ('DOBLONES20.dbo.TransferenciasProductos', reseed, 0) 



DELETE FROM dbo.VentasProductosDevolucionesEspecificos
DELETE FROM dbo.VentasProductosDevolucionesDetalle
DELETE FROM dbo.VentasProductosDevoluciones
DBCC checkident ('DOBLONES20.dbo.VentasProductosDevoluciones', reseed, 0) 

DELETE FROM dbo.VentasProductosEspecificosAgregados
DELETE FROM dbo.VentasProductosEspecificos
DELETE FROM dbo.VentasProductosDetalleEntrega
DELETE FROM dbo.VentasProductosDetalle
DELETE FROM dbo.VentasProductos
DELETE FROM dbo.VentasProductosReemplazoDevolucionesDetalle
DELETE FROM dbo.VentasProductosReemplazoDevoluciones
DELETE FROM dbo.VentasProductosReemplazoEspecificos
DELETE FROM dbo.VentasProductosReemplazoDetalle
DELETE FROM dbo.VentasProductosReemplazo
DBCC checkident ('DOBLONES20.dbo.VentasProductos', reseed, 0) 


DELETE FROM CotizacionVentasProductosDeta
DELETE FROM CotizacionVentasProductos
DBCC checkident ('DOBLONES20.dbo.CotizacionVentasProductos', reseed, 0) 


DELETE FROM Clientes
DBCC checkident ('DOBLONES20.dbo.Clientes', reseed, 0) 

DELETE FROM CuentasPorPagar
DBCC checkident ('DOBLONES20.dbo.CuentasPorPagar', reseed, 0) 

DELETE FROM CuentasPorCobrar
DBCC checkident ('DOBLONES20.dbo.CuentasPorCobrar', reseed, 0) 


DELETE FROM dbo.ProductosEmpresasListaDetalle
DELETE FROM dbo.ProductosEmpresasLista
DBCC checkident ('DOBLONES20.dbo.ProductosEmpresasLista', reseed, 0) 

DELETE FROM Proveedores
DBCC checkident ('DOBLONES20.dbo.Proveedores', reseed, 0) 


--SELECT * FROM Agencias
UPDATE Agencias
SET NumeroSiguienteFactura = 1

DELETE FROM VentasFacturas
INSERT INTO VentasFacturas (NumeroAgencia,NumeroFactura,NombreFactura,NITFactura,FechaHoraFactura) VALUES (1,-1, 'ANONIMO','00000',GETDATE())
--SELECT * FROM VentasFacturas

DELETE FROM dbo.InventarioProductosCantidadesComprasHistorial
DELETE FROM dbo.InventariosProductosEspecificos
DELETE FROM dbo.InventariosProductos
DELETE FROM dbo.ProductosCompuestos
DELETE FROM dbo.ProductosDescripcion
DELETE FROM dbo.ProductosImagenes
DELETE FROM Productos
DELETE FROM dbo.ProductosUnidades
DBCC checkident ('DOBLONES20.dbo.ProductosUnidades', reseed, 0) 
DELETE FROM dbo.ProductosTipos
DBCC checkident ('DOBLONES20.dbo.ProductosTipos', reseed, 0) 
DELETE FROM ProductosPropiedades
DBCC checkident ('DOBLONES20.dbo.ProductosPropiedades', reseed, 0) 
DELETE FROM dbo.ProductosMarcas
DBCC checkident ('DOBLONES20.dbo.ProductosMarcas', reseed, 0) 




--DELETE FROM InventariosProductosEspecificos
--DELETE FROM InventariosProductos

--DELETE FROM ProductosDescripcion
--DELETE FROM Productos

--DELETE FROM ProductosTipos
--DBCC checkident ('DOBLONES20.dbo.ProductosTipos', reseed, 0) 



--INSERT INTO ProductosTipos(CodigoTipoProductoPadre, NombreTipoProducto, NombreCortoTipoProducto, Nivel)
--SELECT CodigoTipoProductoPadre, NombreTipoProducto, NombreCortoTipoProducto, Nivel
--FROM Doblones200.dbo.ProductosTipos
--GO


--DELETE FROM ProductosUnidades
--DBCC checkident ('DOBLONES20.dbo.ProductosUnidades', reseed, 0) 

--INSERT INTO dbo.ProductosUnidades(NombreUnidad)
--SELECT NombreUnidad
--FROM Doblones200.dbo.ProductosUnidades


----11-3 12-4 13-5
----5-1 6-2 1-3
--INSERT INTO dbo.Productos (CodigoProducto,CodigoProductoFabricante, NombreProducto,NombreProducto1, NombreProducto2,CodigoMarcaProducto, CodigoTipoProducto,CodigoUnidad, CodigoTipoCalculoInventario,LlenarCodigoPE, ProductoTangible,ProductoSimple, CalcularPrecioVenta,Descripcion, Observaciones)
--SELECT CodigoProducto,CodigoProductoFabricante, NombreProducto,NombreProducto1, NombreProducto2,CodigoMarcaProducto, 
--CodigoTipoProducto, CodigoUnidad,
----CASE CodigoTipoProducto WHEN 11 THEN 3 WHEN 12 THEN 4 WHEN 13 THEN 5 ELSE CodigoTipoProducto END AS CodigoTipoProducto,
----CASE CodigoUnidad WHEN 5 THEN 1 WHEN 6 THEN 2 WHEN 1 THEN 3 END AS CodigoUnidad, 
--CodigoTipoCalculoInventario,LlenarCodigoPE, ProductoTangible,ProductoSimple, CalcularPrecioVenta,Descripcion, Observaciones
--FROM Doblones200.dbo.Productos
--GO


--INSERT INTO dbo.InventariosProductos(NumeroAgencia, CodigoProducto, CantidadExistencia, CantidadRequerida, PrecioUnitarioCompra, TiempoGarantiaProducto, PorcentajeUtilidad1, PrecioUnitarioVenta1, PorcentajeUtilidad2, PrecioUnitarioVenta2, PorcentajeUtilidad3, PrecioUnitarioVenta3, PorcentajeUtilidad4, PrecioUnitarioVenta4, PorcentajeUtilidad5, PrecioUnitarioVenta5, PorcentajeUtilidad6, PrecioUnitarioVenta6, StockMinimo, MostrarParaVenta, ClaseProducto, EsProductoEspecifico, ProductoEspecificoInventariado)
--SELECT NumeroAgencia, CodigoProducto, CantidadExistencia, CantidadRequerida, PrecioUnitarioCompra, TiempoGarantiaProducto, PorcentajeUtilidad1, PrecioUnitarioVenta1, PorcentajeUtilidad2, PrecioUnitarioVenta2, PorcentajeUtilidad3, PrecioUnitarioVenta3, PorcentajeUtilidad4, PrecioUnitarioVenta4, PorcentajeUtilidad5, PrecioUnitarioVenta5, PorcentajeUtilidad6, PrecioUnitarioVenta6, StockMinimo, MostrarParaVenta, ClaseProducto, EsProductoEspecifico, ProductoEspecificoInventariado
--FROM Doblones200.dbo.InventariosProductos
--GO

--INSERT INTO dbo.InventariosProductosEspecificos (NumeroAgencia, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPECompra, FechaHoraVencimientoPE, CodigoFormaAdquisicion, CodigoEstado)
--SELECT NumeroAgencia, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPECompra, FechaHoraVencimientoPE, CodigoFormaAdquisicion, CodigoEstado
--FROM Doblones200.dbo.InventariosProductosEspecificos


--INSERT INTO dbo.ProductosEmpresasLista(CodigoEmpresa, Descripcion, Fecha)
--SELECT  CodigoEmpresa, Descripcion, Fecha
--FROM Doblones200.dbo.ProductosEmpresasLista
--WHERE Doblones200.dbo.ProductosEmpresasLista.NumeroLista = 2


--INSERT INTO dbo.ProductosEmpresasListaDetalle(NumeroLista, CodigoProducto, NombreProducto, DescripcionProducto, PrecioProducto)
--SELECT 1, CodigoProducto, NombreProducto, DescripcionProducto, PrecioProducto
--FROM Doblones200.dbo.ProductosEmpresasListaDetalle

----INSERT INTO dbo.Clientes (NombreCliente, NombreRepresentante, CodigoTipoCliente, NITCliente, CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar, Direccion, Telefono, Email, Observaciones, CodigoEstadoCliente, NumeroAgencia)
----SELECT NombreCliente, NombreRepresentante, CodigoTipoCliente, NITCliente, CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar, Direccion, Telefono, Email, Observaciones, CodigoEstadoCliente, NumeroAgencia
----FROM Doblones200.dbo.Clientes
----GO


----INSERT INTO dbo.Proveedores (NombreRazonSocial,	NombreRepresentante,CodigoTipoProveedor,NITProveedor,CodigoBanco,NumeroCuentaBanco,	CodigoMoneda,NombreOrdenCheque,	CodigoPais,CodigoDepartamento,CodigoProvincia,CodigoLugar,Direccion,Telefono,Fax,Casilla,Email,Observaciones, ProveedorActivo, NumeroAgencia)
----SELECT NombreRazonSocial,	NombreRepresentante,CodigoTipoProveedor,NITProveedor,CodigoBanco,NumeroCuentaBanco,	CodigoMoneda,NombreOrdenCheque,	CodigoPais,CodigoDepartamento,CodigoProvincia,CodigoLugar,Direccion,Telefono,Fax,Casilla,Email,Observaciones, ProveedorActivo, NumeroAgencia
----FROM Doblones200.dbo.Proveedores
----GO


--INSERT INTO dbo.ComprasProductos (NumeroAgencia,CodigoProveedor, CodigoUsuario, Fecha, CodigoTipoCompra, CodigoEstadoFactura, CodigoEstadoCompra, MontoTotalCompra, NumeroCuentaPorPagar, Observaciones)
--SELECT NumeroAgencia,CodigoProveedor, CodigoUsuario, Fecha, CodigoTipoCompra, CodigoEstadoFactura , CodigoEstadoCompra, MontoTotalCompra, NumeroCuentaPorPagar, Observaciones
--FROM Doblones200.dbo.ComprasProductos cp
--GO



--INSERT INTO dbo.ComprasProductosDetalle (NumeroAgencia,NumeroCompraProducto,CodigoProducto,CantidadCompra,PrecioUnitarioCompra,TiempoGarantiaCompra)
--SELECT NumeroAgencia,NumeroCompraProducto,CodigoProducto,CantidadCompra,PrecioUnitarioCompra,TiempoGarantiaCompra
--FROM Doblones200.dbo.ComprasProductosDetalle
--GO

--INSERT INTO dbo.ComprasProductosDetalleEntrega (NumeroAgencia,NumeroCompraProducto, CodigoProducto, CantidadEntregada, FechaHoraEntrega)
--SELECT NumeroAgencia,NumeroCompraProducto, CodigoProducto, CantidadEntregada, FechaHoraEntrega
--FROM Doblones200.dbo.ComprasProductosDetalleEntrega
--GO

--INSERT INTO dbo.ComprasProductosEspecificos (NumeroAgencia, NumeroCompraProducto, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPE, FechaHoraVencimientoPE, FechaHoraRecepcion)
--SELECT NumeroAgencia, NumeroCompraProducto, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPE, FechaHoraVencimientoPE, FechaHoraRecepcion
--FROM Doblones200.dbo.ComprasProductosEspecificos
--GO

--INSERT INTO dbo.GastosTiposTransacciones (NombreGasto, DescripcionGasto)
--SELECT NombreGasto, DescripcionGasto
--FROM Doblones200.dbo.GastosTiposTransacciones
--GO

--INSERT INTO dbo.CompraProductosGastosDetalle (NumeroAgencia, NumeroCompraProducto, CodigoGastosTipos, FechaHoraGasto, MontoPagoGasto, CodigoMonedaPago, Observaciones)
--SELECT NumeroAgencia, NumeroCompraProducto, CodigoGastosTipos, FechaHoraGasto, MontoPagoGasto, CodigoMonedaPago, Observaciones
--FROM Doblones200.dbo.CompraProductosGastosDetalle
--GO


--INSERT INTO dbo.VentasFacturas (NumeroAgencia, NumeroFactura, NombreFactura, NITFactura, FechaHoraFactura)
--SELECT NumeroAgencia, NumeroFactura, NombreFactura, NITFactura, FechaHoraFactura
--FROM Doblones200.dbo.VentasFacturas
--GO


--INSERT INTO dbo.VentasProductos(NumeroAgencia, CodigoCliente, CodigoUsuario, NumeroFactura, FechaHoraVenta, CodigoEstadoVenta, MontoTotalVenta, NumeroCredito, Observaciones, CodigoMoneda, CodigoTipoVenta, MontoTotalVentaProductos, MontoTotalVentaServicios, NumeroVentaServicio)
--SELECT NumeroAgencia, CodigoCliente, CodigoUsuario, NumeroFactura, FechaHoraVenta, CodigoEstadoVenta, MontoTotalVenta, NumeroCredito, Observaciones, CodigoMoneda, CodigoTipoVenta, MontoTotalVenta, 0, null
--FROM Doblones200.dbo.VentasProductos
--GO


--INSERT INTO dbo.VentasProductosDetalle(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CantidadVenta, CantidadEntregada, PrecioUnitarioVenta, TiempoGarantiaVenta, PorcentajeDescuento, NumeroPrecioSeleccionado)
--SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, CantidadVenta, CantidadEntregada, PrecioUnitarioVenta, TiempoGarantiaVenta, PorcentajeDescuento, NumeroPrecioSeleccionado
--FROM Doblones200.dbo.VentasProductosDetalle
--GO


--INSERT INTO dbo.VentasProductosDetalleEntrega(NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada)
--SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada
--FROM Doblones200.dbo.VentasProductosDetalleEntrega
--GO

--INSERT INTO dbo.VentasProductosEspecificos(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPE, Entregado, FechaHoraEntrega)
--SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPE, Entregado, FechaHoraEntrega
--FROM Doblones200.dbo.VentasProductosEspecificos
--GO



--USE Doblones20
--SELECT * 
--FROM VentasProductosEspecificos






--UPDATE ComprasProductos
--	SET MontoTotalCompra = TA.PrecioTotal
--FROM
--(
--SELECT CPD.NumeroCompraProducto, MontoTotalCompra , CPD.PrecioTotal
--FROM ComprasProductos CP
--INNER JOIN
--(
--select NumeroCompraProducto, SUM(CPD.CantidadCompra * CPD.PrecioUnitarioCompra) as PrecioTotal
--from ComprasProductosDetalle CPD
--group by NumeroCompraProducto
--) CPD
--ON CP.NumeroCompraProducto = CPD.NumeroCompraProducto
--WHERE CP.MontoTotalCompra <> CPD.PrecioTotal
--) TA
--WHERE ComprasProductos.NumeroCompraProducto = TA.NumeroCompraProducto



--UPDATE InventariosProductos
--	SET CantidadExistencia = IP.CantidadExistencia,
--		PrecioUnitarioCompraSinGastos = IP.PrecioUnitarioCompra
--FROM
--Doblones200.dbo.InventariosProductos IP
--WHERE IP.NumeroAgencia = InventariosProductos.NumeroAgencia
--AND IP.CodigoProducto = InventariosProductos.CodigoProducto


--SELECT * FROM InventariosProductos