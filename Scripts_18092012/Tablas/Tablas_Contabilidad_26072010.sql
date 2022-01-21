USE Doblones20
GO

DROP TABLE CuentasPorPagarPagos
GO

DROP TABLE CuentasPorPagar
GO

DROP TABLE CuentasPorCobrarCobros
GO

DROP TABLE CuentasPorCobrar
GO

DROP TABLE AsientosDetalle
GO

DROP TABLE Asientos
GO

DROP TABLE PlanCuentas
GO

DROP TABLE MonedasFracciones
GO

DROP TABLE CajaMovimientosDetalle
GO

DROP TABLE CajaMovimientos
GO












CREATE TABLE PlanCuentas
(
	NumeroCuenta			CHAR(13)		NOT NULL PRIMARY KEY,
	NombreCuenta			VARCHAR(250)	NOT NULL,
	NumeroCuentaPadre		CHAR(13)		NULL,
	NivelCuenta				TINYINT			NOT NULL,
	DescripcionCuenta		VARCHAR(250)	NOT NULL
)
GO

CREATE TABLE Asientos
(
	NumeroAsiento			INT				NOT NULL IDENTITY (1,1) PRIMARY KEY,
	CodigoUsuario			INT				NOT NULL,
	Fecha					DATETIME		NOT NULL,
	Hora					DATETIME		NOT NULL,
	Glosa					TEXT			NOT NULL,
	Estado					VARCHAR(10)		NOT NULL	
)
GO



CREATE TABLE AsientosDetalle
(
	NumeroAsiento			INT				NOT NULL REFERENCES Asientos(NumeroAsiento),
	NumeroCuenta			CHAR(13)		NOT NULL REFERENCES PlanCuentas(NumeroCuenta),
	Debe					DECIMAL(10,2)	NULL,
	Haber					DECIMAL(10,2)	NULL,
	PRIMARY KEY(NumeroAsiento, NumeroCuenta)
)
GO


CREATE TABLE MonedasFracciones
(
	CodigoMonedaFraccion	TINYINT			NOT NULL IDENTITY (1,1),
	CodigoMoneda			TINYINT			NOT NULL REFERENCES Monedas(CodigoMoneda),	
	Valor					DECIMAL(10,2)	NOT NULL,
	Restante				INT				NOT NULL DEFAULT 0,
	PRIMARY KEY(CodigoMoneda, CodigoMonedaFraccion)
)
GO

CREATE TABLE CajaMovimientos
(
	NumeroMovimiento		INT				NOT NULL IDENTITY (1,1) PRIMARY KEY,
	CodigoMoneda			TINYINT			NOT NULL REFERENCES Monedas(CodigoMoneda),
	Debe					DECIMAL(10,2)	NULL,
	Haber					DECIMAL(10,2)	NULL,
	CodigoMedioPago			CHAR(1)			NOT NULL CHECK(CodigoMedioPago IN ('E', 'C', 'D')) DEFAULT 'E',--E: Efectivo, C: Cheque, D: Deposito
	CodigoUsuario			INT				NOT NULL,
	FechaHora				DATETIME		NOT NULL,
	Descripcion				TEXT			NOT NULL,
	Estado					CHAR(1)			NULL
)
GO

CREATE TABLE CajaMovimientosDetalle
(
	NumeroMovimiento		INT				NOT NULL REFERENCES CajaMovimientos(NumeroMovimiento),
	NumeroCuentaDeposito	VARCHAR(30)		NOT NULL,
	Cantidad				INT				NULL,
	NumeroSerie				TEXT			NULL,	
	PRIMARY KEY(NumeroMovimiento, NumeroCuentaDeposito)	
)
GO


CREATE TABLE CuentasPorPagar
(
	NumeroCuentaPorPagar	INT				IDENTITY(1,1) PRIMARY KEY,
	NumeroAgencia			INT				NOT NULL,
	FechaHoraRegistro		DATETIME		NOT NULL,
	CodigoProveedor			INT				NOT NULL,
	CodigoMoneda			TINYINT			NOT NULL,
	Monto					DECIMAL(10,2)	NOT NULL,
	FechaLimite				DATETIME		NULL,
	CodigoEstado			CHAR(1)			NOT NULL,
	Observaciones			TEXT			NULL,
	CodigoUsuario			INT				NULL,
	NumeroAsiento			INT				NULL
	
	FOREIGN KEY(NumeroAgencia) REFERENCES Agencias(NumeroAgencia),
	FOREIGN KEY(CodigoProveedor) REFERENCES Proveedores(CodigoProveedor),
	FOREIGN KEY(NumeroAsiento) REFERENCES Asientos(NumeroAsiento),
	FOREIGN KEY(CodigoMoneda) REFERENCES Monedas(CodigoMoneda)
)
GO


CREATE TABLE CuentasPorPagarPagos
(	
	NumeroCuentaPorPagar	INT				NOT NULL,
	NumeroPago				INT				NOT NULL IDENTITY(1,1),
	FechaHoraPago			DATETIME		NOT NULL,
	Monto					DECIMAL(10,2)	NOT NULL,
	CodigoUsuario			INT				NULL
	
	PRIMARY KEY(NumeroCuentaPorPagar, NumeroPago),
	FOREIGN KEY(NumeroCuentaPorPagar) REFERENCES CuentasPorPagar(NumeroCuentaPorPagar)
)
GO


CREATE TABLE CuentasPorCobrar
(
	NumeroCuentaPorCobrar	INT				IDENTITY(1,1) PRIMARY KEY,
	NumeroAgencia			INT				NOT NULL,
	FechaHoraRegistro		DATETIME		NOT NULL,
	CodigoProveedor			INT				NOT NULL,
	CodigoMoneda			TINYINT			NOT NULL,
	Monto					DECIMAL(10,2)	NOT NULL,
	FechaLimite				DATETIME		NULL,
	CodigoEstado			CHAR(1)			NOT NULL,
	Observaciones			TEXT			NULL,
	CodigoUsuario			INT				NULL,
	NumeroAsiento			INT				NULL
	
	FOREIGN KEY(NumeroAgencia) REFERENCES Agencias(NumeroAgencia),
	FOREIGN KEY(CodigoProveedor) REFERENCES Proveedores(CodigoProveedor),
	FOREIGN KEY(NumeroAsiento) REFERENCES Asientos(NumeroAsiento),
	FOREIGN KEY(CodigoMoneda) REFERENCES Monedas(CodigoMoneda)
)
GO


CREATE TABLE CuentasPorCobrarCobros
(	
	NumeroCuentaPorCobrar	INT				NOT NULL,
	NumeroCobro				INT				NOT NULL IDENTITY(1,1),
	FechaHoraCobro			DATETIME		NOT NULL,
	Monto					DECIMAL(10,2)	NOT NULL,
	CodigoUsuario			INT				NULL
	
	PRIMARY KEY(NumeroCuentaPorCobrar, NumeroCobro),
	FOREIGN KEY(NumeroCuentaPorCobrar) REFERENCES CuentasPorCobrar(NumeroCuentaPorCobrar)
)
GO