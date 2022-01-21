DELETE FROM dbo.CuentasDeConfiguraciones
GO
DELETE FROM dbo.ConfiguracionesCuentas
GO
DBCC checkident ('DOBLONES20.dbo.ConfiguracionesCuentas', reseed, 0) 
GO


INSERT INTO [Doblones20].[dbo].[ConfiguracionesCuentas]([NombreConfiguracion],[DescripcionConfiguracion])
VALUES ('VENTA NORMAL SIN FACTURA', 'VENTA NORMAL SIN FACTURA')
GO
INSERT INTO [Doblones20].[dbo].[ConfiguracionesCuentas]([NombreConfiguracion],[DescripcionConfiguracion])
VALUES ('VENTA NORMAL CON FACTURA', 'VENTA NORMAL CON FACTURA')
GO
INSERT INTO [Doblones20].[dbo].[ConfiguracionesCuentas]([NombreConfiguracion],[DescripcionConfiguracion])
VALUES ('VENTA A CREDITO SIN FACTURA', 'VENTA A CREDITO SIN FACTURA')
GO
INSERT INTO [Doblones20].[dbo].[ConfiguracionesCuentas]([NombreConfiguracion],[DescripcionConfiguracion])
VALUES ('VENTA A CREDITO CON FACTURA', 'VENTA A CREDITO CON FACTURA')
GO
INSERT INTO [Doblones20].[dbo].[ConfiguracionesCuentas]([NombreConfiguracion],[DescripcionConfiguracion])
VALUES ('VENTA INSTITUCIONAL CON FACTURA', 'VENTA INSTITUCIONAL CON FACTURA')
GO
INSERT INTO [Doblones20].[dbo].[ConfiguracionesCuentas]([NombreConfiguracion],[DescripcionConfiguracion])
VALUES ('VENTA INSTITUCIONAL SIN FACTURA', 'VENTA INSTITUCIONAL SIN FACTURA')
GO
INSERT INTO [Doblones20].[dbo].[ConfiguracionesCuentas]([NombreConfiguracion],[DescripcionConfiguracion])
VALUES ('COMPRA EN EFECTIVO CON FACTURA', 'COMPRA EN EFECTIVO CON FACTURA')
GO
INSERT INTO [Doblones20].[dbo].[ConfiguracionesCuentas]([NombreConfiguracion],[DescripcionConfiguracion])
VALUES ('COMPRA EN EFECTIVO SIN FACTURA', 'COMPRA EN EFECTIVO SIN FACTURA')
GO
INSERT INTO [Doblones20].[dbo].[ConfiguracionesCuentas]([NombreConfiguracion],[DescripcionConfiguracion])
VALUES ('COMPRA A CREDITO CON FACTURA', 'COMPRA A CREDITO CON FACTURA')
GO
INSERT INTO [Doblones20].[dbo].[ConfiguracionesCuentas]([NombreConfiguracion],[DescripcionConfiguracion])
VALUES ('COMPRA A CREDITO SIN FACTURA', 'COMPRA A CREDITO SIN FACTURA')
GO
INSERT INTO [Doblones20].[dbo].[ConfiguracionesCuentas]([NombreConfiguracion],[DescripcionConfiguracion])
VALUES ('TRANSFERENCIAS ENVIO', 'TRANSFERENCIAS ENVIO')
GO
INSERT INTO [Doblones20].[dbo].[ConfiguracionesCuentas]([NombreConfiguracion],[DescripcionConfiguracion])
VALUES ('TRANSFERENCIAS RECEPCION', 'TRANSFERENCIAS RECEPCION')
GO
INSERT INTO [Doblones20].[dbo].[ConfiguracionesCuentas]([NombreConfiguracion],[DescripcionConfiguracion])
VALUES ('DEVOLUCIONES POR VENTAS', 'DEVOLUCIONES POR VENTAS')
GO
INSERT INTO [Doblones20].[dbo].[ConfiguracionesCuentas]([NombreConfiguracion],[DescripcionConfiguracion])
VALUES ('DEVOLUCIONES POR COMPRAS', 'DEVOLUCIONES POR COMPRAS')
GO


SELECT * FROM ConfiguracionesCuentas