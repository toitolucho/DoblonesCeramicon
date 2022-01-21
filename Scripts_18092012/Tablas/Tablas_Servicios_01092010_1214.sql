USE Doblones20
GO
DROP TABLE VentasServiciosDetalle
GO
DROP TABLE VentasServicios
GO
DROP TABLE Servicios
GO


CREATE TABLE Servicios
(
	CodigoServicio		INT				NOT NULL	IDENTITY(1,1) PRIMARY KEY,	
	NombreServicio		VARCHAR(250)	NOT NULL	UNIQUE,
	CodigoTipoServicio	CHAR(1)			NOT NULL	CHECK (CodigoTipoServicio IN ('L','D')) DEFAULT 'L', -- 'L':Local en la misma empresa, 'D': Domiciliaria, cuando se va a la Institución u Hogar del Cliente
	PrecioUnitario		DECIMAL(10,2)	NOT NULL	DEFAULT 0,
	Descripcion			TEXT			NULL	
)
GO


CREATE TABLE VentasServicios
(
	NumeroAgencia				INT		NOT NULL,
	NumeroVentaServicio			INT		NOT NULL	IDENTITY(1,1),
	CodigoUsuario				INT		NOT NULL,
	DIPersonaResponsable1		CHAR(15)NOT NULL,
	DIPersonaResponsable2		CHAR(15)	NULL,
	DIPersonaResponsable3		CHAR(15)	NULL,
	CodigoCliente				INT		NOT NULL,
	FechaHoraVentaServicio		DATETIME			DEFAULT GETDATE(),
	FechaHoraEntregaServicio	DATETIME	NULL,
	CodigoEstadoServicio		CHAR(1)	NOT NULL	DEFAULT 'I' CHECK (CodigoEstadoServicio IN('I','P','A','F','V','C')),--'I':Registrado o Iniciado, 'P':Pagado, 'A':Anulado, 'F':Finalizado, 'V':Servicio Inicio de Venta, 'C':Servicio Inicio de una Cotización
	CodigoTipoServicio			CHAR(1)	NOT NULL	DEFAULT 'E' CHECK (CodigoTipoServicio IN ('E','C')), -- 'E':Pago en Efectivo, 'C': Credito
	MontoTotal					DECIMAL(10,2)		DEFAULT 0,
	NumeroFactura				INT			NULL, 
	NumeroCredito				INT			NULL,
	CodigoMoneda				TINYINT	NOT NULL	DEFAULT 2,
	Observaciones				TEXT		NULL,		
	CONSTRAINT PK_VentasServicios			PRIMARY KEY (NumeroAgencia, NumeroVentaServicio),
	CONSTRAINT FK_VentasServiciosFactura	FOREIGN KEY(NumeroAgencia, NumeroFactura)	REFERENCES VentasFacturas(NumeroAgencia, NumeroFactura),	
	CONSTRAINT FK_VentasServiciosMonedas	FOREIGN KEY(CodigoMoneda)					REFERENCES Monedas(CodigoMoneda),
	CONSTRAINT FK_VentasServiciosUsuarios	FOREIGN KEY(CodigoUsuario)					REFERENCES Usuarios(CodigoUsuario),
	CONSTRAINT FK_VentasServiciosPersonas1	FOREIGN KEY(DIPersonaResponsable1)			REFERENCES Personas(DIPersona),
	CONSTRAINT FK_VentasServiciosPersonas2	FOREIGN KEY(DIPersonaResponsable2)			REFERENCES Personas(DIPersona),
	CONSTRAINT FK_VentasServiciosPersonas3	FOREIGN KEY(DIPersonaResponsable3)			REFERENCES Personas(DIPersona),
	CONSTRAINT FK_VentasServiciosClientes	FOREIGN KEY(CodigoCliente)					REFERENCES Clientes(CodigoCliente)
)
GO


CREATE TABLE VentasServiciosDetalle
(
	NumeroAgencia			INT				NOT NULL,
	NumeroVentaServicio		INT				NOT NULL,
	CodigoServicio			INT				NOT NULL,
	CantidadVentaServicio	INT				NOT NULL DEFAULT 1,
	PrecioUnitario			DECIMAL(10,2)	NOT NULL DEFAULT 1,
	TiempoGarantiaDias		INT				NULL	 DEFAULT 0,
	CONSTRAINT PK_VentasServiciosDetalle	PRIMARY KEY (NumeroAgencia, NumeroVentaServicio, CodigoServicio),
	CONSTRAINT FK_VentasServiciosDetalle	FOREIGN KEY (NumeroAgencia, NumeroVentaServicio)	REFERENCES VentasServicios(NumeroAgencia, NumeroVentaServicio),
	CONSTRAINT FK_VentasServiciosDetalleSer FOREIGN KEY (CodigoServicio)						REFERENCES Servicios(CodigoServicio)
)
GO


