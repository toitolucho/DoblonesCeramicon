select * from ventasproductos where NumeroVentaProducto = 495
select * from dbo.VentasProductosDetalle where NumeroVentaProducto = 495
select * from dbo.VentasProductosDetalleEntrega where NumeroVentaProducto = 495

select * from plancuentas
select * from ConfiguracionesCuentas
select * from ConfiguracionesCuentasDetalle
select * from Asientos
select * from AsientosDetalle


select * from dbo.ComprasProductosPagosDetalle
select name as [Nombre de Procedimiento],* from doblones20.dbo.sysobjects where xtype = 'P'


SELECT name, modify_date , create_date FROM sys.objects
WHERE type = 'P' AND name NOT LIKE 'sp_%'
ORDER BY modify_date DESC

update dbo.InventariosProductos
	set EsProductoEspecifico = 0
where CodigoProducto in ('032-TON-000001  ', '032-TON-000002 ')

select * from dbo.InventariosProductosEspecificos
where CodigoProducto in ('013-TON-000007 ', '013-TON-000008 ', '032-TON-000001  ', '032-TON-000002 ')

select * from dbo.ComprasProductosDetalle
where codigoProducto in ('013-TON-000007 ', '013-TON-000008 ', '032-TON-000001  ', '032-TON-000002 ')


select * from dbo.ComprasProductosDetalleEntrega
where codigoProducto in ('013-TON-000007 ', '013-TON-000008 ', '032-TON-000001  ', '032-TON-000002 ')

select * from dbo.ComprasProductosEspecificos
where codigoProducto in ('013-TON-000007 ', '013-TON-000008 ', '032-TON-000001  ', '032-TON-000002 ')

--CUENTAS BANCARIAS
--1-1-01-03-008 +
--1-1-01-03-005 -
--1-1-01-03-009 +
--1-1-01-03-010 +
--1-1-01-03-006 -
--1-1-01-03-007 -
--1-1-01-03-011 +

--CAJAS
--1-1-01-01-001
--1-1-01-01-002
UPDATE dbo.ComprasProductosPagosDetalle
SET NumeroCuenta = '1-1-01-01-001'
WHERE NumeroCuenta = '1-1-01-02-002'


UPDATE dbo.ComprasProductosPagosDetalle
SET NumeroCuenta = '1-1-01-01-001'
WHERE NumeroCuenta = '1-1-04-01-001'

UPDATE dbo.ComprasProductosPagosDetalle
SET NumeroCuenta = '1-1-01-01-002'
WHERE NumeroCuenta = '1-1-01-04-002'


INSERT INTO dbo.ConfiguracionesCuentasDetalle(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber, PorcentajeMontoTotalDH )
VALUES(1,'1-1-01-03-008','D',1 )
INSERT INTO dbo.ConfiguracionesCuentasDetalle(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber, PorcentajeMontoTotalDH )
VALUES(1,'1-1-01-03-005','D',1 )
INSERT INTO dbo.ConfiguracionesCuentasDetalle(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber, PorcentajeMontoTotalDH )
VALUES(1,'1-1-01-03-009','D',1 )
INSERT INTO dbo.ConfiguracionesCuentasDetalle(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber, PorcentajeMontoTotalDH )
VALUES(1,'1-1-01-03-010','D',1 )
INSERT INTO dbo.ConfiguracionesCuentasDetalle(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber, PorcentajeMontoTotalDH )
VALUES(1,'1-1-01-03-006','D',1 )
INSERT INTO dbo.ConfiguracionesCuentasDetalle(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber, PorcentajeMontoTotalDH )
VALUES(1,'1-1-01-03-007','D',1 )
INSERT INTO dbo.ConfiguracionesCuentasDetalle(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber, PorcentajeMontoTotalDH )
VALUES(1,'1-1-01-03-011','D',1 )
INSERT INTO dbo.ConfiguracionesCuentasDetalle(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber, PorcentajeMontoTotalDH )
VALUES(1,'1-1-01-01-001','D',1 )
INSERT INTO dbo.ConfiguracionesCuentasDetalle(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber, PorcentajeMontoTotalDH )
VALUES(1,'1-1-01-01-002','D',1 )




DELETE FROM dbo.ConfiguracionesCuentasDetalle WHERE NumeroConfiguracion = 1



SELECT * FROM PLANCUENTAS
WHERE NUMEROCUENTA IN ('1-1-01-01-001',
'1-1-01-01-001',
'1-1-01-01-002')

SELECT * FROM dbo.ComprasProductosPagosDetalle
WHERE NUMEROCUENTA IN ('1-1-01-02-001',
'1-1-01-04-001',
'1-1-01-04-002')


INSERT INTO dbo.PlanCuentas(NumeroCuenta, NombreCuenta, NumeroCuentaPadre, NivelCuenta, DescripcionCuenta)
VALUES ('1-1-01-03-008', 'B.C.P. GEOVANA CONDORI CTA. 101-50398903-3-81 ', '1-1-01-03-000', 5, 'Cuenta Registrada el 19/03/2012 para hacer seguimiento a las transacciones ventas compras')
INSERT INTO dbo.PlanCuentas(NumeroCuenta, NombreCuenta, NumeroCuentaPadre, NivelCuenta, DescripcionCuenta)
VALUES ('1-1-01-03-009', 'BISA CEATEC COMERCIALIZADORES CTA. 221784-401-3 SRL (BS)', '1-1-01-03-000', 5, 'Cuenta Registrada el 19/03/2012 para hacer seguimiento a las transacciones ventas compras')
INSERT INTO dbo.PlanCuentas(NumeroCuenta, NombreCuenta, NumeroCuentaPadre, NivelCuenta, DescripcionCuenta)
VALUES ('1-1-01-03-010', 'BISA CEATEC COMERCIALIZADORES CTA. 221784-402-1 SRL (BS)', '1-1-01-03-000', 5, 'Cuenta Registrada el 19/03/2012 para hacer seguimiento a las transacciones ventas compras')
INSERT INTO dbo.PlanCuentas(NumeroCuenta, NombreCuenta, NumeroCuentaPadre, NivelCuenta, DescripcionCuenta)
VALUES ('1-1-01-03-011', 'BCP EMILIANA NINA CTA. 101-50464406-3-46 (BS)', '1-1-01-03-000', 5, 'Cuenta Registrada el 19/03/2012 para hacer seguimiento a las transacciones ventas compras')
