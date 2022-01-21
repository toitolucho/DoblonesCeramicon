USE Doblones20
GO

DROP TABLE CuentasDeConfiguraciones
GO
DROP TABLE ConfiguracionesCuentas
GO

CREATE TABLE ConfiguracionesCuentas
(
	NumeroConfiguracion			INT				NOT NULL IDENTITY (1,1) PRIMARY KEY,
	NombreConfiguracion			VARCHAR(250)	NOT NULL,
	DescripcionConfiguracion	TEXT			NULL	
)
GO
CREATE TABLE CuentasDeConfiguraciones
(
	NumeroConfiguracion			INT				NOT NULL,
	NumeroCuentaConfiguracion	CHAR(13)		NOT NULL,
	TipoCuentaDebeHaber			CHAR(1)			NOT NULL CHECK (TipoCuentaDebeHaber IN ('D', 'H')),
	
	PRIMARY KEY (NumeroConfiguracion, NumeroCuentaConfiguracion),
	FOREIGN KEY (NumeroConfiguracion) REFERENCES ConfiguracionesCuentas (NumeroConfiguracion),
	FOREIGN KEY (NumeroCuentaConfiguracion) REFERENCES PlanCuentas (NumeroCuenta)
)
GO





INSERT INTO dbo.ConfiguracionesCuentas(NombreConfiguracion, DescripcionConfiguracion) VALUES ('Venta (sin factura)', 'Venta sin factura')--NumeroConfiguracion=1
INSERT INTO dbo.CuentasDeConfiguraciones(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber) VALUES (1, '1-1-01-02-001', 'D')--Caja
INSERT INTO dbo.CuentasDeConfiguraciones(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber) VALUES (1, '4-1-01-01-001', 'H')--Ventas

INSERT INTO dbo.ConfiguracionesCuentas(NombreConfiguracion, DescripcionConfiguracion) VALUES ('Venta (con factura)', 'Venta con factura')--NumeroConfiguracion=2
INSERT INTO dbo.CuentasDeConfiguraciones(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber) VALUES (2, '1-1-01-02-001', 'D')--Caja 87%
INSERT INTO dbo.CuentasDeConfiguraciones(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber) VALUES (2, '2-1-03-01-001', 'D')--IVA 13%
INSERT INTO dbo.CuentasDeConfiguraciones(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber) VALUES (2, '4-1-01-01-001', 'H')--Ventas



INSERT INTO dbo.ConfiguracionesCuentas(NombreConfiguracion, DescripcionConfiguracion) VALUES ('Compra (sin factura)', 'Venta sin factura')--NumeroConfiguracion=3
INSERT INTO dbo.CuentasDeConfiguraciones(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber) VALUES (3, '1-1-01-02-001', 'H')--Caja
INSERT INTO dbo.CuentasDeConfiguraciones(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber) VALUES (3, '5-1-02-01-001', 'D')--Compras
