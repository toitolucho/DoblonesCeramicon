USE DOBLONES20

DROP TABLE TransferenciasProductosGastosDetalle
GO
DROP TABLE TransferenciasProductosEspecificos
GO
DROP TABLE TransferenciasProductosDetalleRecepcion
GO
DROP TABLE TransferenciasProductosDetalle
GO
DROP TABLE TransferenciasProductos
GO
DROP TABLE VentasProductosReemplazoDevolucionesDetalle
GO
DROP TABLE VentasProductosReemplazoDevoluciones
GO
DROP TABLE VentasProductosReemplazoEspecificos
GO
DROP TABLE VentasProductosReemplazoDetalle
GO
DROP TABLE VentasProductosReemplazo
GO
DROP TABLE VentasProductosDevolucionesEspecificos
GO
DROP TABLE VentasProductosDevolucionesDetalle
GO
DROP TABLE VentasProductosDevoluciones
GO
DROP TABLE VentasProductosEspecificosAgregados
GO
DROP TABLE VentasProductosEspecificos 
GO
DROP TABLE VentasProductosDetalleEntrega
GO
DROP TABLE VentasProductosDetalle
GO
DROP TABLE VentasProductos
GO
DROP TABLE VentasFacturas
GO
DROP TABLE CotizacionVentasProductosDeta
GO
DROP TABLE CotizacionVentasProductos
GO
DROP TABLE ComprasProductosDevolucionesEspecificos
GO
DROP TABLE ComprasProductosDevolucionesDetalle
GO
DROP TABLE ComprasProductosDevoluciones
GO
DROP TABLE ComprasProductosDocuImag
GO
DROP TABLE ComprasProductosEspecificosAgregados
GO
DROP TABLE ComprasProductosEspecificos
GO
DROP TABLE ComprasProductosDetalleEntrega
GO
DROP TABLE ComprasProductosDetalle
GO
DROP TABLE CompraProductosGastosDetalle
GO
DROP TABLE GastosTiposTransacciones 
GO
DROP TABLE ComprasProductos
GO

DROP TABLE CuentasPorPagarAmortizaciones
GO
DROP TABLE CuentasPorPagarCuotas
GO
DROP TABLE CuentasPorPagar
GO


--DROP TABLE CreditosAmortizaciones
--GO
DROP TABLE CreditosCuotasPagos
GO
DROP TABLE CreditosCuotas
GO
DROP TABLE Creditos
GO




DROP TABLE DepositosBancarios
GO
DROP TABLE FrecuenciasPagos
GO
DROP TABLE Clientes
GO
DROP TABLE InventarioProductosCantidadesComprasHistorial
GO
DROP TABLE InventariosProductosEspecificos
GO
DROP TABLE InventariosProductos
GO
DROP TABLE ProductosImagenes
GO
DROP TABLE ProductosDescripcion
GO
DROP TABLE ProductosPropiedades
GO
DROP TABLE Productos
GO
DROP TABLE ProductosTipos
GO
DROP TABLE ProductosUnidades
GO
DROP TABLE ProductosMarcas
GO
DROP TABLE MotivosReemDevo
GO

--PABLO
DROP TABLE ProductosEmpresasListaDetalle
GO
DROP TABLE ProductosEmpresasLista
GO
--PABLO

DROP TABLE Proveedores
GO
DROP TABLE DocumentosTipos
GO
--DROP TABLE UsuariosMenuPrincipal
--GO
--DROP TABLE UsuariosAgenciasPermisosInterfaces
--GO
--DROP TABLE SistemaGruposUsuarios
--GO
--DROP TABLE SistemaGruposPermisosInterfaces
--GO
--DROP TABLE SistemaGrupos
--GO
--DROP TABLE Usuarios				
--GO
--DROP TABLE SistemaInterfaces
--GO
--DROP TABLE SistemaConfiguracion
--GO
--DROP TABLE Agencias
--GO
--DROP TABLE Personas
--GO
--DROP TABLE Lugares
--GO
--DROP TABLE Provincias
--GO
--DROP TABLE Departamentos
--GO
--DROP TABLE Paises
--GO
--DROP TABLE Bancos
--GO
--DROP TABLE MonedasCotizaciones
--GO
--DROP TABLE Monedas
--GO

/*
CREATE TABLE Monedas
(
CodigoMoneda			TINYINT				NOT NULL IDENTITY (1,1) PRIMARY KEY,
NombreMoneda			VARCHAR(250)		NOT NULL,
MascaraMoneda			VARCHAR(20)			NOT NULL
)
GO

CREATE TABLE MonedasCotizaciones
(
CodigoMoneda			TINYINT				NOT NULL REFERENCES Monedas(CodigoMoneda),
FechaHoraCotizacion		DATETIME			NOT NULL,
CodigoMonedaCotizacion	TINYINT				NOT NULL REFERENCES Monedas(CodigoMoneda),
CambioOficial			DECIMAL(10,2)		NOT NULL,
CambioParalelo			DECIMAL(10,2)		NOT NULL,
PRIMARY KEY (CodigoMoneda, FechaHoraCotizacion, CodigoMonedaCotizacion)
)
GO

CREATE TABLE Bancos
(
CodigoBanco				TINYINT				NOT NULL IDENTITY (1,1) PRIMARY KEY,
NombreBanco				VARCHAR(250)		NOT NULL UNIQUE
)
GO 

CREATE TABLE Paises
(
CodigoPais				CHAR(2)				NOT NULL PRIMARY KEY,
NombrePais				VARCHAR(250)		NOT NULL UNIQUE,
Nacionalidad			VARCHAR(250)		NULL
)
GO

CREATE TABLE Departamentos
(
CodigoPais				CHAR(2)				NOT NULL,
CodigoDepartamento		CHAR(2)				NOT NULL,
NombreDepartamento		VARCHAR(250)		NOT NULL,
PRIMARY KEY (CodigoPais, CodigoDepartamento),
FOREIGN KEY (CodigoPais) 
REFERENCES Paises(CodigoPais)

)
GO

CREATE TABLE Provincias
(
CodigoPais				CHAR(2)				NOT NULL,
CodigoDepartamento		CHAR(2)				NOT NULL,
CodigoProvincia			CHAR(2)				NOT NULL,
NombreProvincia			VARCHAR(250)		NOT NULL,
PRIMARY KEY (CodigoPais, CodigoDepartamento, CodigoProvincia),
FOREIGN KEY (CodigoPais, CodigoDepartamento) 
REFERENCES Departamentos(CodigoPais, CodigoDepartamento)
)

GO
CREATE TABLE Lugares
(
CodigoPais				CHAR(2)				NOT NULL,
CodigoDepartamento		CHAR(2)				NOT NULL,
CodigoProvincia			CHAR(2)				NOT NULL,
CodigoLugar				CHAR(3)				NOT NULL,
NombreLugar				VARCHAR(250)		NOT NULL,
PRIMARY KEY(CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar),
FOREIGN KEY (CodigoPais, CodigoDepartamento, CodigoProvincia) 
REFERENCES Provincias(CodigoPais, CodigoDepartamento, CodigoProvincia)
)
GO

CREATE TABLE Personas
(
DIPersona					CHAR(15)			NOT NULL PRIMARY KEY,
Paterno						VARCHAR(40)			NULL,
Materno						VARCHAR(40)			NULL,
Nombres						VARCHAR(80)			NOT NULL,
FechaNacimiento				DATETIME			NULL,
Sexo						CHAR(1)				NOT NULL CHECK(Sexo IN ('F', 'M')),
Celular						VARCHAR(50)			NULL,
Email						TEXT				NULL,
CodigoPaisD					CHAR(2)				NULL,
CodigoDepartamentoD			CHAR(2)				NULL,
CodigoProvinciaD			CHAR(2)				NULL,
CodigoLugarD				CHAR(3)				NULL,
DireccionD					VARCHAR(250)		NULL,
TelefonoD					VARCHAR(50)			NULL,
RutaArchivoHuellaDactilar	TEXT				NULL,
RutaArchivoFotografia		TEXT				NULL,
RutaArchivoFirma			TEXT				NULL,
Observaciones				TEXT				NULL,
FOREIGN KEY (CodigoPaisD, CodigoDepartamentoD, CodigoProvinciaD, CodigoLugarD) 
REFERENCES Lugares(CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar)
)
GO

CREATE TABLE Agencias
(
NumeroAgencia			INT					NOT NULL IDENTITY(1,1) PRIMARY KEY,
NombreAgencia			VARCHAR(250)		NOT NULL,
CodigoPais				CHAR(2)				NOT NULL,
CodigoDepartamento		CHAR(2)				NOT NULL,
CodigoProvincia			CHAR(2)				NOT NULL,
CodigoLugar				CHAR(3)				NOT NULL,
DireccionAgencia		VARCHAR(250)		NOT NULL,
NITAgencia				CHAR(30)			NOT NULL,
NumeroSiguienteFactura	INT					NOT NULL,
NumeroAutorizacion		CHAR(30)			NOT NULL,
DIResponsable			CHAR(15)			NOT NULL REFERENCES Personas(DIPersona),
FOREIGN KEY (CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar) 
REFERENCES Lugares(CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar)
)
GO



--CREATE TABLE SistemaConfiguracion
--(
--CodigoMonedaSistema		TINYINT				NOT NULL REFERENCES Monedas(CodigoMoneda),
--PorcentajeImpuesto		DECIMAL(10,2)		NOT NULL DEFAULT 0,
--NumeroAgencia			INT					NOT NULL REFERENCES Agencias(NumeroAgencia),
--NumeroAgenciaPrincipal	INT					NOT NULL REFERENCES Agencias(NumeroAgencia)
--)
--GO

CREATE TABLE SistemaInterfaces
(
CodigoInterface			TINYINT				NOT NULL IDENTITY(1, 1) PRIMARY KEY,
NombreInterface			VARCHAR(250)		NOT NULL UNIQUE,
TextoInterface			VARCHAR(250)		NOT NULL,
CodigoTipoInterface		CHAR(1)				NOT NULL DEFAULT 'P' --'G'->Uso general, 'P'->Uso personalizado
)
GO

CREATE TABLE Usuarios					
(
CodigoUsuario						INT					NOT NULL IDENTITY (1, 1) PRIMARY KEY,
NombreUsuario						CHAR(32)			NOT NULL UNIQUE,
Contrasena							CHAR(32)			NOT NULL,
DIUsuario							CHAR(15)			NOT NULL UNIQUE,
Paterno								VARCHAR(40)			NULL,
Materno								VARCHAR(40)			NULL,
Nombres								VARCHAR(80)			NOT NULL,
FechaNacimiento						DATETIME			NULL,
Sexo								CHAR(1)				NOT NULL CHECK(Sexo IN ('F', 'M')) DEFAULT 'M',
Celular								VARCHAR(50)			NULL,
Email								TEXT				NULL,
Direccion							VARCHAR(250)		NULL,
Telefono							VARCHAR(50)			NULL,
RutaArchivoHuellaDactilar			TEXT				NULL,
RutaArchivoFotografia				TEXT				NULL,
RutaArchivoFirma					TEXT				NULL,
Observaciones						TEXT				NULL,
)
GO

CREATE TABLE SistemaGrupos 
(
CodigoGrupoSistema					TINYINT			NOT NULL IDENTITY (1, 1) PRIMARY KEY,
NombreGrupoSistema					VARCHAR(250)	NOT NULL UNIQUE,
)
GO

CREATE TABLE SistemaGruposPermisosInterfaces
(
CodigoGrupoSistema					TINYINT			NOT NULL REFERENCES SistemaGrupos(CodigoGrupoSistema), 
CodigoInterface						TINYINT			NOT NULL REFERENCES SistemaInterfaces(CodigoInterface),
PermitirInsertar					BIT				NOT NULL DEFAULT 0,
PermitirEditar						BIT				NOT NULL DEFAULT 0,
PermitirEliminar					BIT				NOT NULL DEFAULT 0,
PermitirNavegar						BIT				NOT NULL DEFAULT 0,
PermitirReportes					BIT				NOT NULL DEFAULT 0,
PRIMARY KEY (CodigoGrupoSistema, CodigoInterface)
)
GO

CREATE TABLE SistemaGruposUsuarios
(
CodigoUsuario						INT				NOT NULL REFERENCES Usuarios(CodigoUsuario),
NumeroAgencia						INT				NOT NULL REFERENCES Agencias(NumeroAgencia),
CodigoGrupoSistema					TINYINT			NOT NULL REFERENCES SistemaGrupos(CodigoGrupoSistema), 
PRIMARY KEY (CodigoUsuario,NumeroAgencia,CodigoGrupoSistema)
)
GO

CREATE TABLE UsuariosAgenciasPermisosInterfaces
(
CodigoUsuario						INT				NOT NULL REFERENCES Usuarios(CodigoUsuario),
NumeroAgencia						INT				NOT NULL REFERENCES Agencias(NumeroAgencia),
CodigoInterface						TINYINT			NOT NULL REFERENCES SistemaInterfaces(CodigoInterface),
PermitirInsertar					BIT				NOT NULL DEFAULT 0,
PermitirEditar						BIT				NOT NULL DEFAULT 0,
PermitirEliminar					BIT				NOT NULL DEFAULT 0,
PermitirNavegar						BIT				NOT NULL DEFAULT 0,
PermitirReportes					BIT				NOT NULL DEFAULT 0,
PRIMARY KEY (CodigoUsuario, NumeroAgencia, CodigoInterface)
)
GO

CREATE TABLE UsuariosMenuPrincipal
(
CodigoUsuario						INT					NOT NULL REFERENCES Usuarios(CodigoUsuario),
NumeroAgencia						INT					NOT NULL REFERENCES Agencias(NumeroAgencia),
NombreMenuItem						VARCHAR(250)			NOT NULL UNIQUE,
Visible								BIT					NOT NULL DEFAULT 0,
Activo								BIT					NOT NULL DEFAULT 0,
PRIMARY KEY (CodigoUsuario, NumeroAgencia, NombreMenuItem)
)
GO */

CREATE TABLE DocumentosTipos
(
CodigoTipoDocumento		TINYINT				NOT NULL IDENTITY (1,1) PRIMARY KEY,
NombreTipoDocumento		VARCHAR(250)		NOT NULL
)
GO

CREATE TABLE Proveedores
(
CodigoProveedor			INT					NOT NULL IDENTITY (1,1) PRIMARY KEY,
NombreRazonSocial		VARCHAR(250)		NOT NULL,
NombreRepresentante		VARCHAR(250)		NOT NULL,
CodigoTipoProveedor		CHAR(1)				NOT NULL DEFAULT 'P' CHECK(CodigoTipoProveedor IN ('P','E')), --'P'->Persona; 'E'->Empresa
NITProveedor			VARCHAR(30)			NULL,
CodigoBanco				TINYINT				NULL REFERENCES Bancos(CodigoBanco),
NumeroCuentaBanco		CHAR(30)			NULL,
CodigoMoneda			TINYINT				NULL REFERENCES Monedas(CodigoMoneda),
NombreOrdenCheque		VARCHAR(250)		NULL,
CodigoPais				CHAR(2)				NULL,
CodigoDepartamento		CHAR(2)				NULL,
CodigoProvincia			CHAR(2)				NULL,
CodigoLugar				CHAR(3)				NULL,
Direccion				VARCHAR(250)		NULL,
Telefono				VARCHAR(50)			NULL,
Fax						VARCHAR(50)			NULL,
Casilla					CHAR(15)			NULL,
Email					TEXT				NULL,
Observaciones			TEXT				NULL,
ProveedorActivo			BIT					NOT NULL DEFAULT 1,
NumeroAgencia			INT				NOT NULL REFERENCES Agencias(NumeroAgencia),
UNIQUE (NombreRazonSocial, NombreRepresentante),
FOREIGN KEY (CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar) 
REFERENCES Lugares(CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar)
)
GO


-- **************************** PABLO BEGIN ********************************
CREATE TABLE ProductosEmpresasLista
(
	NumeroLista			INT				NOT NULL IDENTITY (1,1) PRIMARY KEY,
	CodigoEmpresa		INT				NOT NULL REFERENCES Proveedores(CodigoProveedor),
	Descripcion			VARCHAR(250)	NULL,
	Fecha				DATETIME		NOT NULL
)
GO

CREATE TABLE ProductosEmpresasListaDetalle
(
	NumeroLista			INT				NOT NULL REFERENCES ProductosEmpresasLista(NumeroLista),
	CodigoProducto		CHAR(15)		NOT NULL,	
	NombreProducto		VARCHAR(250)	NOT NULL UNIQUE,
	DescripcionProducto	TEXT			NULL,
	PrecioProducto		DECIMAL(10,2)	NOT NULL
	PRIMARY KEY(NumeroLista, CodigoProducto)
)
GO
-- **************************** PABLO END ********************************

CREATE TABLE MotivosReemDevo
(
CodigoMotivoReemDevo	INT					NOT NULL IDENTITY(1,1) PRIMARY KEY,
NombreMotivoReemDevo	VARCHAR(250)		NOT NULL,
EstadoRetornoInventario	CHAR(1)				NOT NULL CHECK(EstadoRetornoInventario IN ('A','B','R','V','N')),-- 'A' -> Alta, 'B'->Baja, 'R'-> Reparación ,'V'-> Vendido, 'N'->Ninguna
TipoTransaccion			CHAR(1)				NOT NULL CHECK(TipoTransaccion  IN ('V','C','D')) -- 'V' ->Ventas, 'C'->Compras, 'D'->Devolucion
)
GO

CREATE TABLE ProductosMarcas
(
CodigoMarcaProducto		INT					NOT NULL IDENTITY (1,1) PRIMARY KEY,
NombreMarcaProducto		VARCHAR(250)		NOT NULL
)
GO

CREATE TABLE ProductosUnidades
(
CodigoUnidad            INT					NOT NULL IDENTITY (1,1) PRIMARY KEY,
NombreUnidad            VARCHAR(250)		NOT NULL UNIQUE
)
GO

CREATE TABLE ProductosTipos
(
CodigoTipoProducto		INT					NOT NULL IDENTITY (1,1) PRIMARY KEY,
CodigoTipoProductoPadre	INT					NOT NULL,
NombreTipoProducto 		VARCHAR(250)		NOT NULL UNIQUE,
NombreCortoTipoProducto VARCHAR(20)			NOT NULL UNIQUE,
Nivel					TINYINT				NOT NULL
)
GO 

CREATE TABLE Productos
(
CodigoProducto				CHAR(15)		NOT NULL PRIMARY KEY,
CodigoProductoFabricante	CHAR(30)		NOT NULL UNIQUE,
NombreProducto				VARCHAR(250)	NOT NULL UNIQUE,
NombreProducto1				VARCHAR(250)	NULL,
NombreProducto2				VARCHAR(250)	NULL,
CodigoMarcaProducto			INT				NULL REFERENCES ProductosMarcas(CodigoMarcaProducto),
CodigoTipoProducto			INT				NOT NULL REFERENCES ProductosTipos(CodigoTipoProducto),
CodigoUnidad				INT				NOT NULL REFERENCES ProductosUnidades(CodigoUnidad),
CodigoTipoCalculoInventario	CHAR(1)			NOT NULL DEFAULT 'O', --U'->UEPS, 'P'->PEPS, 'O'->Ponderado, 'B'-> Precio mas Bajo, 'A'->Precio mas alto, 'T'-> Ultimo Precio
LlenarCodigoPE				BIT				NOT NULL DEFAULT 1,
ProductoTangible			BIT				NOT NULL DEFAULT 1,
ProductoSimple				BIT				NOT NULL DEFAULT 1,
CalcularPrecioVenta			BIT				NOT NULL DEFAULT 1,
Descripcion					TEXT			NULL,
Observaciones				TEXT			NULL
)
GO

CREATE TABLE ProductosPropiedades
(
CodigoPropiedad			INT 				NOT NULL IDENTITY (1,1) PRIMARY KEY,
NombrePropiedad			VARCHAR(250)		NOT NULL,
Mascara					VARCHAR(250)		NOT NULL,
)
GO

CREATE TABLE ProductosDescripcion
(
CodigoProducto			CHAR(15)			NOT NULL REFERENCES Productos(CodigoProducto),
CodigoPropiedad			INT					NOT NULL REFERENCES ProductosPropiedades(CodigoPropiedad),
ValorPropiedad			VARCHAR(200)		NOT NULL,
PRIMARY KEY (CodigoProducto,CodigoPropiedad)
)
GO

CREATE TABLE ProductosImagenes
(
CodigoProducto				CHAR(15)		NOT NULL REFERENCES Productos (CodigoProducto),
NumeroImagen				TINYINT			NOT NULL,
RutaImagenProducto			TEXT			NOT NULL,
PRIMARY KEY (CodigoProducto,NumeroImagen)
)
GO

CREATE TABLE InventariosProductos
(
NumeroAgencia					INT				NOT NULL,
CodigoProducto					CHAR(15)		NOT NULL REFERENCES Productos (CodigoProducto),
CantidadExistencia				INT				NOT NULL DEFAULT 0 CHECK (CantidadExistencia >= 0),
CantidadRequerida				INT				NOT NULL DEFAULT 0,
PrecioUnitarioCompra			DECIMAL(10, 2)	NOT NULL DEFAULT 0,
PrecioUnitarioCompraSinGastos	DECIMAL(10, 2)	NOT NULL DEFAULT 0,
TiempoGarantiaProducto			INT				NOT NULL DEFAULT 0,
PorcentajeUtilidad1				DECIMAL(5,2)	NOT NULL DEFAULT 0,
PrecioUnitarioVenta1			DECIMAL(10, 2)	NOT NULL DEFAULT 0,
PorcentajeUtilidad2				DECIMAL(5,2)	NOT NULL DEFAULT 0,
PrecioUnitarioVenta2			DECIMAL(10, 2)	NOT NULL DEFAULT 0,
PorcentajeUtilidad3				DECIMAL(5,2)	NOT NULL DEFAULT 0,
PrecioUnitarioVenta3			DECIMAL(10, 2)	NOT NULL DEFAULT 0,
PorcentajeUtilidad4				DECIMAL(5,2)	NOT NULL DEFAULT 0,
PrecioUnitarioVenta4			DECIMAL(10, 2)	NOT NULL DEFAULT 0,
PorcentajeUtilidad5				DECIMAL(5,2)	NOT NULL DEFAULT 0,
PrecioUnitarioVenta5			DECIMAL(10, 2)	NOT NULL DEFAULT 0,
PorcentajeUtilidad6				DECIMAL(5,2)	NOT NULL DEFAULT 0,
PrecioUnitarioVenta6			DECIMAL(10, 2)	NOT NULL DEFAULT 0,
StockMinimo						INT				NOT NULL DEFAULT 1,
MostrarParaVenta				BIT				NOT NULL DEFAULT 1,
ClaseProducto					CHAR(1)			NOT NULL DEFAULT 'S' CHECK(ClaseProducto IN ('S', 'C')), --S = Simple; C = Compuesto
EsProductoEspecifico			BIT				NOT NULL DEFAULT 0,
ProductoEspecificoInventariado	BIT				NOT NULL DEFAULT 0,
PRIMARY KEY (NumeroAgencia, CodigoProducto)
)
GO

CREATE TABLE InventariosProductosEspecificos
(
NumeroAgencia				INT				NOT NULL,
CodigoProducto				CHAR(15)		NOT NULL,
CodigoProductoEspecifico	CHAR(20)		NOT NULL,
TiempoGarantiaPECompra		INT				NOT NULL,
FechaHoraVencimientoPE		DATETIME		NOT NULL,
CodigoFormaAdquisicion		CHAR(1)			NOT NULL CHECK(CodigoFormaAdquisicion IN ('C','A','D','P','T')),--C'->Compra, 'A'->Agregado,'D'->Donacion, 'P'->Prestamo, 'Transferido'
CodigoEstado				CHAR(1)			NOT NULL CHECK(CodigoEstado IN ('A','B','R','V','T')),-- 'A' -> Alta, 'B'->Baja, 'R'-> Reparación ,'V'-> Vendido, 'T'-> Transferencia
PRIMARY KEY (NumeroAgencia, CodigoProducto, CodigoProductoEspecifico),
FOREIGN KEY (NumeroAgencia, CodigoProducto) 
REFERENCES InventariosProductos(NumeroAgencia, CodigoProducto)
)
GO

CREATE TABLE InventarioProductosCantidadesComprasHistorial
(
	NumeroAgencia				INT				NOT NULL,
	NumeroCompraProducto		INT				NOT NULL, --Esta columna hace referencia a cualquier transacción que sea un ingreso a inventarios (NumeroIngresoProducto)
	CodigoProducto				CHAR(15)		NOT NULL,
	FechaHoraIngreso			DATETIME		NOT NULL,
	CantidadExistente			INT				NOT NULL CHECK(CantidadExistente >= 0),	
	PrecioUnitario				DECIMAL(10,2)	NOT NULL CHECK(PrecioUnitario >= 0)
	PRIMARY KEY (NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraIngreso)	
)
GO

CREATE TABLE Clientes
(
CodigoCliente				INT				NOT NULL IDENTITY(1, 1) PRIMARY KEY,
NombreCliente				VARCHAR(250)	NOT NULL,
NombreRepresentante			VARCHAR(250)	NOT NULL,
CodigoTipoCliente			CHAR(1)			NOT NULL DEFAULT 'P' CHECK(CodigoTipoCliente IN ('P','E')), --'P'->Persona; 'E'->Empresa
NITCliente					VARCHAR(30)		NULL,
CodigoPais					CHAR(2)			NULL,
CodigoDepartamento			CHAR(2)			NULL,
CodigoProvincia				CHAR(2)			NULL,
CodigoLugar					CHAR(3)			NULL,
Direccion					VARCHAR(250)	NULL,
Telefono					VARCHAR(50)		NULL,
Email						TEXT			NULL,
Observaciones				TEXT			NULL,
CodigoEstadoCliente			CHAR(1)			NOT NULL DEFAULT 'A' CHECK(CodigoEstadoCliente IN ('H', 'I', 'S')), --'H'->Habilitado, 'I'->Inhabilitado, 'S'->Supendido
NumeroAgencia				INT				NOT NULL REFERENCES Agencias(NumeroAgencia),
UNIQUE (NombreCliente, NombreRepresentante),
FOREIGN KEY (CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar) 
REFERENCES Lugares(CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar)
)
GO


CREATE TABLE FrecuenciasPagos
(
CodigoFrecuenciaPago			INT			NOT NULL IDENTITY (1,1) PRIMARY KEY,
NombreFrecuenciaPago			VARCHAR(50) NOT NULL,
NumeroDias						INT			NOT NULL
)
GO 

CREATE TABLE DepositosBancarios
(
NumeroAgencia					INT				NOT NULL REFERENCES Agencias(NumeroAgencia),
NumeroDepositoBancario			INT				NOT NULL IDENTITY (1,1),
CodigoBanco						TINYINT			NULL REFERENCES Bancos(CodigoBanco),
NumeroCuentaBanco				CHAR(30)		NULL,
Depositante						VARCHAR(200)	NOT NULL,
Monto							DECIMAL(10,2)	NOT NULL,
FechaHora						DATETIME		NOT NULL,
CodigoMoneda					TINYINT			NOT NULL REFERENCES Monedas(CodigoMoneda),
Observaciones					TEXT			NULL,
PRIMARY KEY (NumeroAgencia, NumeroDepositoBancario)
)
GO


CREATE TABLE Creditos
(
NumeroCredito				INT				NOT NULL IDENTITY (1,1) PRIMARY KEY,

DIDeudor					CHAR(15)		NOT NULL REFERENCES Personas(DIPersona),
DIGarante1					CHAR(15)		NOT NULL REFERENCES Personas(DIPersona),
DIGarante2					CHAR(15)		NULL REFERENCES Personas(DIPersona),
DIGarante3					CHAR(15)		NULL REFERENCES Personas(DIPersona),
DIGarante4					CHAR(15)		NULL REFERENCES Personas(DIPersona),
DIGarante5					CHAR(15)		NULL REFERENCES Personas(DIPersona),
MontoTotalCredito			DECIMAL(10,2)	NOT NULL,
NumeroPeriodos				INT				NOT NULL,
CodigoFrecuenciaPago		INT				NOT NULL REFERENCES FrecuenciasPagos(CodigoFrecuenciaPago),
TazaInteres					DECIMAL(10,2)	NOT NULL,
TazaInteresVencimiento		DECIMAL(10,2)	NULL,
TazaInteresMora				DECIMAL(10,2)	NULL,
FechaHoraSolicitud			DATETIME		NOT NULL,
FechaHoraInicioCredito		DATETIME		NOT NULL,
FechaHoraFinCredito			DATETIME		NOT NULL,
CodigoAutorizacion			CHAR(10)		NOT NULL,
Observaciones				TEXT			NULL,
CodigoEstadoCredito			CHAR(1)			NOT NULL CHECK(CodigoEstadoCredito IN ('S','O','N', 'U', 'P', 'V')), --'S'->Solicitado, 'O'->Otorgado, 'N'->Negado, 'U'->Suspendido, 'P'->Pagado, 'V'->Vigente
RegistrarContabilidad		BIT				NOT NULL DEFAULT 1,
NumeroAgencia				INT				NOT NULL REFERENCES Agencias(NumeroAgencia),
CodigoUsuarioAutorizacion	INT				NOT NULL REFERENCES Usuarios(CodigoUsuario),
FechaHoraAutorizacion		DATETIME		NULL
)
GO

CREATE TABLE CreditosCuotas
(
NumeroCredito				INT				NOT NULL REFERENCES Creditos(NumeroCredito),
NumeroCuota					INT				NOT NULL,
FechaHoraCuota				DATETIME		NOT NULL,
NumeroDias					INT				NOT NULL,
Cuota						DECIMAL(10,2)	NOT NULL,
CuotaInteres				DECIMAL(10,2)	NOT NULL,
CuotaCapital				DECIMAL(10,2)	NOT NULL,
SaldoCapital				DECIMAL(10,2)	NOT NULL,
PRIMARY KEY (NumeroCredito, NumeroCuota)
)
GO


CREATE TABLE CreditosCuotasPagos
(
NumeroCredito				INT				NOT NULL,
NumeroCuota					INT				NOT NULL,
FechaHoraPago				DATETIME		NOT NULL,
MontoPago					DECIMAL(10, 2)	NOT NULL,
CodigoMedioPago				CHAR(1)			NOT NULL CHECK (CodigoMedioPago IN ('D','C','E')),
NumeroCuentaBanco			CHAR(30)		NULL,
DIPersonaPago				VARCHAR(15)		NOT NULL,
NombreCompletoPersonaPago	VARCHAR(250)	NOT NULL,
NumeroAgencia				INT				NOT NULL	REFERENCES Agencias(NumeroAgencia),
CodigoUsuario				INT				NOT NULL	REFERENCES Usuarios (CodigoUsuario),
PRIMARY KEY (NumeroCredito, NumeroCuota),
FOREIGN KEY (NumeroCredito, NumeroCuota) 
REFERENCES CreditosCuotas (NumeroCredito, NumeroCuota)
)

/*
CREATE TABLE CreditosAmortizaciones
(
NumeroCredito				INT				NOT NULL REFERENCES Creditos(NumeroCredito),
FechaHoraAmortizacion		DATETIME		NOT NULL,
Amortizacion				DECIMAL(10,2)	NOT NULL,
AmortizacionInteres			DECIMAL(10,2)	NOT NULL,
AmortizacionCapital			DECIMAL(10,2)	NOT NULL,
SaldoCapital				DECIMAL(10,2)	NOT NULL,
InteresVencimiento			DECIMAL(10,2)	NULL,
InteresMora					DECIMAL(10,2)	NULL,
CodigoMedioPago				CHAR(1)			NOT NULL CHECK(CodigoMedioPago IN ('E','C', 'D')), -- 'E'->Efectivo, 'C'->Cheque, 'D'-> DEPOSITO
NumeroCuentaBanco			CHAR(30)		NULL,
NumeroAgencia				INT				NOT NULL REFERENCES Agencias(NumeroAgencia),
CodigoUsuarioAmortizacion	INT				NOT NULL REFERENCES Usuarios(CodigoUsuario)
PRIMARY KEY (NumeroCredito, FechaHoraAmortizacion)
)
GO*/


CREATE TABLE CuentasPorPagar
(
NumeroAgencia					INT				NOT NULL REFERENCES Agencias(NumeroAgencia),
NumeroCuentaPorPagar			INT				NOT NULL IDENTITY (1,1),
CodigoProveedor					INT				NOT NULL REFERENCES Proveedores(CodigoProveedor),
MontoTotalCuentaPorPagar		DECIMAL(10,2)	NOT NULL,
NumeroPeriodos					INT				NOT NULL,
FechaHoraRegistro				DATETIME		NOT NULL,
CodigoFrecuenciaPago			INT				NOT NULL REFERENCES FrecuenciasPagos(CodigoFrecuenciaPago), 
TazaInteres						DECIMAL(10,2)	NOT NULL,
TazaInteresVencimiento			DECIMAL(10,2)	NULL,
TazaInteresMora					DECIMAL(10,2)	NULL,
Observaciones					TEXT			NULL,
CodigoEstadoCuentaPorPagar		CHAR(1)			NOT NULL CHECK(CodigoEstadoCuentaPorPagar IN ('I','F','S')), -- 'I'->Iniciado, 'F'->Finalizado, 'S'-> Suspendido
PRIMARY KEY(NumeroAgencia, NumeroCuentaPorPagar)
)
GO

CREATE TABLE CuentasPorPagarCuotas
(
NumeroAgencia					INT				NOT NULL,
NumeroCuentaPorPagar			INT				NOT NULL,
NumeroCuota						INT				NOT NULL,
FechaHoraCuota					DATETIME		NOT NULL,
NumeroDias						INT				NOT NULL,
Cuota							DECIMAL(10,2)	NOT NULL,
CuotaInteres					DECIMAL(10,2)	NOT NULL,
CuotaCapital					DECIMAL(10,2)	NOT NULL,
SaldoCapital					DECIMAL(10,2)	NOT NULL,
PRIMARY KEY (NumeroAgencia, NumeroCuentaPorPagar, NumeroCuota),
FOREIGN KEY (NumeroAgencia, NumeroCuentaPorPagar) 
REFERENCES CuentasPorPagar(NumeroAgencia, NumeroCuentaPorPagar)
)
GO 

CREATE TABLE CuentasPorPagarAmortizaciones
(
NumeroAgencia					INT				NOT NULL,
NumeroCuentaPorPagar			INT				NOT NULL,
FechaHoraAmortizacion			DATETIME		NOT NULL,
Amortizacion					DECIMAL(10,2)	NOT NULL,
AmortizacionInteres				DECIMAL(10,2)	NOT NULL,
AmortizacionCapital				DECIMAL(10,2)	NOT NULL,
SaldoCapital					DECIMAL(10,2)	NOT NULL,
InteresVencimiento				DECIMAL(10,2)	NULL,
InteresMora						DECIMAL(10,2)	NULL,
TotalAmortizacion				DECIMAL(10,2)	NOT NULL,
CodigoMedioPago					CHAR(1)			NOT NULL,
NumeroCuentaBanco				CHAR(30)		NULL,
PRIMARY KEY (NumeroAgencia, NumeroCuentaPorPagar,FechaHoraAmortizacion),
FOREIGN KEY (NumeroAgencia, NumeroCuentaPorPagar)
REFERENCES CuentasPorPagar(NumeroAgencia, NumeroCuentaPorPagar)
)
GO


CREATE TABLE GastosTiposTransacciones
(
CodigoGastosTipos	INT				NOT NULL IDENTITY (1,1) PRIMARY KEY,
NombreGasto			VARCHAR(250)	NOT NULL,
DescripcionGasto	TEXT			NULL	
)
GO

CREATE TABLE ComprasProductos
(
NumeroAgencia				INT				NOT NULL REFERENCES Agencias(NumeroAgencia),
NumeroCompraProducto		INT				NOT NULL IDENTITY (1,1),
CodigoProveedor				INT				NOT NULL REFERENCES Proveedores(CodigoProveedor),
CodigoUsuario				INT				NOT NULL REFERENCES Usuarios(CodigoUsuario),
Fecha						DATETIME		NOT NULL,
CodigoTipoCompra			CHAR(1)			NOT NULL CHECK(CodigoTipoCompra IN ('E','R')), --E'-> Efectivo, 'R'->Credito
CodigoEstadoCompra			CHAR(1)			NOT NULL CHECK(CodigoEstadoCompra IN ('I', 'A', 'P', 'D', 'F','X' )), --I'->Iniciada, 'A'->Anulada, 'P'-> Pagada, 'D'->Pendiente, 'F'->Finalizada,'X' -> Finalizada pero Recepción incompleta 
CodigoEstadoFactura			CHAR(1)			NULL	 CHECK(CodigoEstadoFactura IN ('F','S')) DEFAULT 'S', -- 'F'->COMPRA FACTURADA REALIZADA CON FACTURA, 'S'-> Sin Factura
MontoTotalCompra			DECIMAL(10,2)	NOT NULL,
NumeroCuentaPorPagar		INT				NULL,	 
Observaciones				TEXT			NULL,
PRIMARY KEY (NumeroAgencia, NumeroCompraProducto),
FOREIGN KEY (NumeroAgencia,NumeroCuentaPorPagar) REFERENCES CuentasPorPagar(NumeroAgencia, NumeroCuentaPorPagar)
)
GO


CREATE TABLE CompraProductosGastosDetalle
(
NumeroAgencia				INT				NOT NULL,
NumeroCompraProducto		INT				NOT NULL,
NumeroCompraProductoGasto	INT				NOT NULL IDENTITY (1,1),
CodigoGastosTipos			INT				NOT NULL REFERENCES GastosTiposTransacciones(CodigoGastosTipos),
FechaHoraGasto				DATETIME		NOT NULL,
MontoPagoGasto				DECIMAL(10,2)	NOT NULL,
CodigoMonedaPago			TINYINT			NULL	 REFERENCES	Monedas(CodigoMoneda),
Observaciones				TEXT			NULL,
CodigoEstadoGasto			BIT				NULL DEFAULT 0,	--'1'-> Aplicado para el calculo de Precio de Compra a Inventario, '0' -> en Espera de SEr Calculado
PRIMARY KEY (NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoGasto),
FOREIGN KEY (NumeroAgencia, NumeroCompraProducto) 
REFERENCES ComprasProductos(NumeroAgencia, NumeroCompraProducto)
)
GO

CREATE TABLE ComprasProductosDetalle
(
NumeroAgencia				INT				NOT NULL,
NumeroCompraProducto		INT				NOT NULL,
CodigoProducto				CHAR(15)		NOT NULL REFERENCES Productos(CodigoProducto),
CantidadCompra				INT				NOT NULL,
PrecioUnitarioCompra		DECIMAL(10, 2)	NOT NULL,
TiempoGarantiaCompra		INT				NULL,
PRIMARY KEY (NumeroAgencia, NumeroCompraProducto,CodigoProducto),
FOREIGN KEY (NumeroAgencia, NumeroCompraProducto) 
REFERENCES ComprasProductos(NumeroAgencia, NumeroCompraProducto)
)
GO


CREATE TABLE ComprasProductosDetalleEntrega
(
NumeroAgencia				INT				NOT NULL,
NumeroCompraProducto		INT				NOT NULL,
CodigoProducto				CHAR(15)		NOT NULL,
CantidadEntregada			INT				NOT NULL CHECK(CantidadEntregada > 0),
FechaHoraEntrega			DATETIME		NOT NULL
PRIMARY KEY (NumeroAgencia, NumeroCompraProducto,CodigoProducto, FechaHoraEntrega),	
FOREIGN KEY (NumeroAgencia, NumeroCompraProducto, CodigoProducto) 
REFERENCES ComprasProductosDetalle(NumeroAgencia, NumeroCompraProducto, CodigoProducto)
)
GO

CREATE TABLE ComprasProductosEspecificos
(
NumeroAgencia				INT				NOT NULL,
NumeroCompraProducto		INT				NOT NULL,
CodigoProducto				CHAR(15)		NOT NULL,
CodigoProductoEspecifico	CHAR(20)		NOT NULL,
TiempoGarantiaPE			INT				NULL,
FechaHoraVencimientoPE		DATETIME		NULL,
FechaHoraRecepcion			DATETIME		NOT NULL,
PRIMARY KEY (NumeroAgencia, NumeroCompraProducto, CodigoProducto, CodigoProductoEspecifico),
FOREIGN KEY (NumeroAgencia, NumeroCompraProducto, CodigoProducto) 
REFERENCES ComprasProductosDetalle(NumeroAgencia, NumeroCompraProducto, CodigoProducto)
)
GO

CREATE TABLE ComprasProductosEspecificosAgregados
(
NumeroAgencia				INT				NOT NULL,
NumeroCompraProducto		INT				NOT NULL,
CodigoProducto				CHAR(15)		NOT NULL,
CodigoProductoEspecifico	CHAR(20)		NOT NULL,
CodigoTipoAgregado			CHAR(1)			NOT NULL CHECK (CodigoTipoAgregado IN ('P','B','C','O')),-- 'P'->Promoción ,'B'->Bonificación,'C'->Compensación,'O'->Obsequio
TiempoGarantiaPE			INT				NULL,
FechaHoraVencimientoPE		DATETIME		NULL,
CargarAInventario			BIT				NOT NULL DEFAULT 1,
PrecioUnitario				DECIMAL(10, 2)	NOT NULL,
PRIMARY KEY (NumeroAgencia, NumeroCompraProducto,CodigoProducto,CodigoProductoEspecifico),
FOREIGN KEY (NumeroAgencia, NumeroCompraProducto)  
REFERENCES ComprasProductos(NumeroAgencia, NumeroCompraProducto)
)
GO

CREATE TABLE ComprasProductosDocuImag
(
NumeroAgencia				INT				NOT NULL,
NumeroCompraProducto		INT				NOT NULL,
CodigoTipoDocumento			TINYINT			NOT NULL REFERENCES DocumentosTipos(CodigoTipoDocumento),
NumeroTipoDocumento			TINYINT			NOT NULL, 
RutaArchivoImagenDocumento	TEXT			NULL,
Descripcion					TEXT			NULL,
PRIMARY KEY (NumeroAgencia, NumeroCompraProducto,CodigoTipoDocumento),
FOREIGN KEY (NumeroAgencia, NumeroCompraProducto) 
REFERENCES ComprasProductos(NumeroAgencia, NumeroCompraProducto)
)
GO

CREATE TABLE ComprasProductosDevoluciones
(
NumeroAgencia					INT			NOT NULL REFERENCES Agencias(NumeroAgencia),
NumeroDevolucion				INT			NOT NULL IDENTITY(1,1),
NumeroCompraProducto			INT			NOT NULL,
CodigoEstadoDevolucion			CHAR(1)		NOT NULL CHECK (CodigoEstadoDevolucion IN ('I', 'C', 'F', 'A')), --I'->Iniciada, 'C'->Cancelada, 'F'->Finalizada, 'A'->Anulada
CodigoUsuario					INT			NOT NULL REFERENCES Usuarios(CodigoUsuario),
FechaHoraSolicitudDevolucion	DATETIME	NOT NULL,
ObservacionesSolicitudDevo		TEXT		NULL,
NumeroDevolucionDevolucion		INT			NULL,
PRIMARY KEY (NumeroAgencia, NumeroDevolucion),
FOREIGN KEY (NumeroAgencia, NumeroCompraProducto) REFERENCES ComprasProductos(NumeroAgencia, NumeroCompraProducto),
FOREIGN KEY (NumeroAgencia, NumeroDevolucionDevolucion) REFERENCES ComprasProductosDevoluciones(NumeroAgencia, NumeroDevolucion)
)
GO 

CREATE TABLE ComprasProductosDevolucionesDetalle
(
NumeroAgencia					INT				NOT NULL,
NumeroDevolucion				INT				NOT NULL,
CodigoMotivoReemDevo			INT				NOT NULL REFERENCES MotivosReemDevo(CodigoMotivoReemDevo),
CodigoProducto					CHAR(15)		NOT NULL,
CantidadDevuelta				INT				NOT NULL DEFAULT 1,
PrecioUnitarioDevolucion		DECIMAL(10,2)	NOT NULL DEFAULT 0,
PRIMARY KEY (NumeroAgencia, NumeroDevolucion, CodigoProducto),
FOREIGN KEY (NumeroAgencia, NumeroDevolucion)
REFERENCES ComprasProductosDevoluciones(NumeroAgencia, NumeroDevolucion)
)
GO

CREATE TABLE ComprasProductosDevolucionesEspecificos
(
NumeroAgencia					INT				NOT NULL,
NumeroDevolucion				INT				NOT NULL,
CodigoProducto					CHAR(15)		NOT NULL,
CodigoProductoEspecifico		CHAR(20)		NOT NULL,
PrecioUnitarioDevolucionPE		DECIMAL(10,2)	NOT NULL DEFAULT 0,
PRIMARY KEY (NumeroAgencia, NumeroDevolucion, CodigoProducto,CodigoProductoEspecifico),
FOREIGN KEY (NumeroAgencia, NumeroDevolucion, CodigoProducto)
REFERENCES ComprasProductosDevolucionesDetalle(NumeroAgencia, NumeroDevolucion, CodigoProducto)
)
GO


CREATE TABLE CotizacionVentasProductos
(
NumeroAgencia					INT				NOT NULL REFERENCES Agencias(NumeroAgencia),
NumeroCotizacionVentaProducto	INT				NOT NULL IDENTITY(1, 1),
CodigoCliente					INT				NOT NULL REFERENCES Clientes(CodigoCliente),
CodigoUsuario					INT				NOT NULL REFERENCES Usuarios(CodigoUsuario),
FechaHoraCotizacion				DATETIME		NOT NULL,
ValidezOferta					INT				NULL,
TiempoEntrega					INT				NULL,--DIAS
CodigoEstadoCotizacion			CHAR(1)			NOT NULL, --'I'->INICIADA, 'C'->CANCELADA, 'E'->EJECUTADA
CotizacionVendida				BIT				NOT NULL DEFAULT 0,
CodigoMonedaCotizacionVenta		TINYINT			NOT NULL REFERENCES Monedas(CodigoMoneda),
CodigoTipoCotizacion			CHAR(1)			NOT NULL CHECK(CodigoTipoCotizacion IN ('N','T')), --' N:Cotizacion Normal, T:Cotización para Instituciones'
MontoTotalCotizacion			DECIMAL(10,2)	NOT NULL, --incluye los agregados en caso de que tengan precio
MontoTotalCotizacionProductos	DECIMAL(10,2)	NULL	 DEFAULT 0, --Monto Exclusivo de los Productos que se Venden
MontoTotalCotizacionServicios	DECIMAL(10,2)	NULL	 DEFAULT 0, --Monto que se Cancela por algun servicio extra que incluye la Venta
NumeroVentaServicio				INT				NULL,
ConFactura						BIT				NOT NULL DEFAULT 0,
Observaciones					TEXT			NULL,
PRIMARY KEY (NumeroAgencia, NumeroCotizacionVentaProducto),
CONSTRAINT FK_CotizacionVentasProductosServicios	FOREIGN KEY(NumeroAgencia, NumeroFactura) REFERENCES VentasServicios(NumeroAgencia, NumeroVentaServicio)
)
GO

CREATE TABLE CotizacionVentasProductosDeta
(
NumeroAgencia					INT				NOT NULL, 
NumeroCotizacionVentaProducto	INT				NOT NULL,
CodigoProducto					CHAR(15)		NOT NULL REFERENCES Productos(CodigoProducto),
CantidadCotizacionVenta			INT				NOT NULL,
PrecioUnitarioCotizacionVenta	DECIMAL(10,2)	NOT NULL,
TiempoGarantiaCotizacionVenta	INT				NOT NULL,
PorcentajeDescuento				DECIMAL(10,2)	NULL DEFAULT 0,
NumeroPrecioSeleccionado		CHAR(1)			NULL DEFAULT '1' CHECK (NumeroPrecioSeleccionado IN ('1','2','3','4','5','6','P')), --Precio1, Precio2, Precio3, Precio4, Precio5, Precio6, Personalizado
PRIMARY KEY(NumeroAgencia, NumeroCotizacionVentaProducto, CodigoProducto),
FOREIGN KEY (NumeroAgencia, NumeroCotizacionVentaProducto) 
REFERENCES CotizacionVentasProductos(NumeroAgencia, NumeroCotizacionVentaProducto)
)
GO

CREATE TABLE VentasFacturas
(
NumeroAgencia					INT				NOT NULL,
NumeroFactura					INT				NOT NULL,
NombreFactura					VARCHAR(160)	NOT NULL,
NITFactura						VARCHAR(30)		NOT NULL,
FechaHoraFactura				DATETIME		NOT NULL,
PRIMARY KEY(NumeroAgencia, NumeroFactura)
)
GO

CREATE TABLE VentasProductos
(
NumeroAgencia					INT				NOT NULL REFERENCES Agencias(NumeroAgencia),
NumeroVentaProducto				INT				NOT NULL IDENTITY (1,1),
CodigoCliente					INT				NOT NULL REFERENCES Clientes(CodigoCliente),
CodigoUsuario					INT				NOT NULL REFERENCES Usuarios(CodigoUsuario),
NumeroFactura					INT				NULL, 
FechaHoraVenta					DATETIME		NOT NULL DEFAULT GETDATE(),
CodigoEstadoVenta				CHAR(1)			NOT NULL CHECK(CodigoEstadoVenta IN ('I','P', 'F', 'A','T', 'C','E','D')), --I'->Iniciada, 'P'->Pagada, 'F'->Finalizada, 'A'->Anulada, 'T'->Venta a Insituticiones, 'C'->Entrega de Productos en Confianza, 'D'->Pendiente (Venta Institucional), 'E'->En Espera(Venta Normal)
MontoTotalVenta					DECIMAL(10,2)	NOT NULL, --incluye los agregados en caso de que tengan precio
MontoTotalVentaProductos		DECIMAL(10,2)	NULL	 DEFAULT 0, --Monto Exclusivo de los Productos que se Venden
MontoTotalVentaServicios		DECIMAL(10,2)	NULL	 DEFAULT 0, --Monto que se Cancela por algun servicio extra que incluye la Venta
NumeroVentaServicio				INT				NULL,
NumeroCredito					INT				NULL	 REFERENCES Creditos(NumeroCredito),
CodigoMoneda					TINYINT			NOT NULL REFERENCES Monedas(CodigoMoneda),
CodigoTipoVenta					CHAR(1)			NOT NULL DEFAULT 'N' CHECK(CodigoTipoVenta in ('N','T')), --'N'->Venta Normal y Corriente, 'T'->Venta Institucional
Observaciones					TEXT			NULL,
CONSTRAINT PK_VentasProductos			PRIMARY KEY (NumeroAgencia, NumeroVentaProducto),
CONSTRAINT FK_VentasProductosFacturas	FOREIGN KEY(NumeroAgencia, NumeroFactura) REFERENCES VentasFacturas(NumeroAgencia, NumeroFactura),
CONSTRAINT FK_VentasProductosServicios	FOREIGN KEY(NumeroAgencia, NumeroFactura) REFERENCES VentasServicios(NumeroAgencia, NumeroVentaServicio)
)
GO

CREATE TABLE VentasProductosDetalle
(
NumeroAgencia					INT				NOT NULL,
NumeroVentaProducto				INT				NOT NULL,
CodigoProducto					CHAR(15)		NOT NULL REFERENCES Productos(CodigoProducto),
CantidadVenta					INT				NOT NULL DEFAULT 0,
CantidadEntregada				INT				NOT NULL DEFAULT 0,
PrecioUnitarioVenta				DECIMAL(10,2)	NOT NULL,
TiempoGarantiaVenta				INT				NOT NULL,
PorcentajeDescuento				DECIMAL(10,2)	NULL DEFAULT 0,
NumeroPrecioSeleccionado		CHAR(1)			NULL DEFAULT '1' CHECK (NumeroPrecioSeleccionado IN ('1','2','3','4','5','6','P')), --Precio1, Precio2, Precio3, Precio4, Precio5, Precio6, Personalizado

PRIMARY KEY(NumeroAgencia, NumeroVentaProducto, CodigoProducto),
FOREIGN KEY (NumeroAgencia, NumeroVentaProducto)
REFERENCES VentasProductos(NumeroAgencia, NumeroVentaProducto)
)
GO


CREATE TABLE VentasProductosDetalleEntrega
(
NumeroAgencia					INT				NOT NULL,
NumeroVentaProducto				INT				NOT NULL,
CodigoProducto					CHAR(15)		NOT NULL REFERENCES Productos(CodigoProducto),
FechaHoraEntrega				DATETIME		NOT NULL DEFAULT GETDATE(),
CantidadEntregada				INT				NOT NULL DEFAULT 0,
PRIMARY KEY(NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega),
FOREIGN KEY (NumeroAgencia, NumeroVentaProducto, CodigoProducto)
REFERENCES VentasProductosDetalle(NumeroAgencia, NumeroVentaProducto, CodigoProducto)
)
GO


CREATE TABLE VentasProductosEspecificos
(
NumeroAgencia					INT				NOT NULL,
NumeroVentaProducto				INT				NOT NULL,
CodigoProducto					CHAR(15)		NOT NULL,
CodigoProductoEspecifico		CHAR(20)		NOT NULL,
TiempoGarantiaPE				INT				NOT NULL,
Entregado						BIT				NULL DEFAULT 1,
FechaHoraEntrega				DATETIME		NULL,
PRIMARY KEY(NumeroAgencia, NumeroVentaProducto,CodigoProducto,CodigoProductoEspecifico),
FOREIGN KEY (NumeroAgencia, NumeroVentaProducto, CodigoProducto) 
REFERENCES VentasProductosDetalle(NumeroAgencia, NumeroVentaProducto, CodigoProducto),
FOREIGN KEY (NumeroAgencia, CodigoProducto,CodigoProductoEspecifico) 
REFERENCES InventariosProductosEspecificos(NumeroAgencia, CodigoProducto,CodigoProductoEspecifico)
)
GO

CREATE TABLE VentasProductosEspecificosAgregados
(
NumeroAgencia					INT				NOT NULL,
NumeroVentaProducto				INT				NOT NULL,
CodigoProducto					CHAR(15)		NOT NULL,
CodigoProductoEspecifico		CHAR(20)		NOT NULL,
CodigoTipoAgregado				CHAR(1)			NOT NULL CHECK (CodigoTipoAgregado IN ('P','B','C','O')),-- 'P'->Promoción ,'B'->Bonificación,'C'->Compensación,'O'->Obsequio
TiempoGarantiaPE				INT				NULL,
FechaHoraVencimientoPE			DATETIME		NULL,
PrecioUnitario					DECIMAL(10, 2)	NOT NULL,
PRIMARY KEY (NumeroAgencia, NumeroVentaProducto,CodigoProducto,CodigoProductoEspecifico),
FOREIGN KEY (NumeroAgencia, NumeroVentaProducto) 
REFERENCES VentasProductos(NumeroAgencia, NumeroVentaProducto)
)
GO

CREATE TABLE VentasProductosDevoluciones
(
NumeroAgencia					INT			NOT NULL REFERENCES Agencias(NumeroAgencia),
NumeroDevolucion				INT			NOT NULL IDENTITY(1,1),
NumeroVentaProducto				INT			NOT NULL,
CodigoEstadoDevolucion			CHAR(1)		NOT NULL CHECK (CodigoEstadoDevolucion IN ('I', 'C', 'F', 'A')), --I'->Iniciada, 'C'->Cancelada, 'F'->Finalizada, 'A'->Anulada
CodigoUsuario					INT			NOT NULL REFERENCES Usuarios(CodigoUsuario),
FechaHoraSolicitudReemDevo		DATETIME	NOT NULL DEFAULT GETDATE(),
ObservacionesSolicitudReemDevo	TEXT		NULL,
NumeroDevolucionDevolucion		INT			NULL,
PRIMARY KEY (NumeroAgencia, NumeroDevolucion),
FOREIGN KEY (NumeroAgencia, NumeroVentaProducto) 
REFERENCES VentasProductos(NumeroAgencia, NumeroVentaProducto),
FOREIGN KEY (NumeroAgencia, NumeroDevolucionDevolucion)
REFERENCES VentasProductosDevoluciones(NumeroAgencia, NumeroDevolucion)
)
GO 

CREATE TABLE VentasProductosDevolucionesDetalle
(
NumeroAgencia					INT				NOT NULL,
NumeroDevolucion				INT				NOT NULL,
CodigoMotivoReemDevo			INT				NOT NULL  REFERENCES MotivosReemDevo(CodigoMotivoReemDevo),
CodigoProducto					CHAR(15)		NOT NULL  REFERENCES Productos(CodigoProducto),
CantidadDevuelta				INT				NOT NULL  DEFAULT 1,
PrecioUnitarioDevolucion		DECIMAL(10,2)	NOT NULL, --Monto que devolvemos en caso de que sea una simple devolucion
PRIMARY KEY (NumeroAgencia, NumeroDevolucion, CodigoProducto),
FOREIGN KEY (NumeroAgencia, NumeroDevolucion) 
REFERENCES VentasProductosDevoluciones(NumeroAgencia, NumeroDevolucion)
)
GO

CREATE TABLE VentasProductosDevolucionesEspecificos
(
NumeroAgencia					INT				NOT NULL,
NumeroDevolucion				INT				NOT NULL,
CodigoProducto					CHAR(15)		NOT NULL,
CodigoProductoEspecifico		CHAR(20)		NOT NULL,
PrecioUnitarioDevolucionPE		DECIMAL(10,2)	NOT NULL DEFAULT 0,--Monto que devolvemos en caso de que sea una simple devolucion
PRIMARY KEY(NumeroAgencia, NumeroDevolucion, CodigoProducto, CodigoProductoEspecifico),
FOREIGN KEY(NumeroAgencia, NumeroDevolucion, CodigoProducto) 
REFERENCES VentasProductosDevolucionesDetalle (NumeroAgencia, NumeroDevolucion, CodigoProducto) 
)
GO


CREATE TABLE VentasProductosReemplazo
(
NumeroAgencia				INT			NOT NULL REFERENCES Agencias(NumeroAgencia),
NumeroReemplazo				INT			NOT NULL IDENTITY(1,1),	
NumeroDevolucion			INT			NOT NULL,
CodigoEstadoReemplazo		CHAR(1)		NOT NULL CHECK (CodigoEstadoReemplazo IN ('I', 'C', 'F', 'A')), --I'->Iniciada, 'C'->Cancelada, 'F'->Finalizada, 'A'->Anulada
CodigoUsuario				INT			NOT NULL REFERENCES Usuarios(CodigoUsuario),
FechaHoraSolicitudReemplazo	DATETIME	NOT NULL DEFAULT GETDATE(),
ObservacionesReemplazo		TEXT		NULL,
PRIMARY KEY (NumeroAgencia, NumeroReemplazo),
FOREIGN KEY (NumeroAgencia, NumeroDevolucion) 
REFERENCES VentasProductosDevoluciones(NumeroAgencia, NumeroDevolucion)
)
GO


CREATE TABLE VentasProductosReemplazoDetalle
(
NumeroAgencia					INT				NOT NULL,
NumeroReemplazo					INT				NOT NULL,
CodigoProducto					CHAR(15)		NOT NULL  REFERENCES Productos(CodigoProducto),
CantidadDevuelta				INT				NOT NULL  DEFAULT 1,
PrecioUnitarioReemplazo			DECIMAL(10,2)	NOT NULL  DEFAULT 0, --precio al cual vamos a intercambiar, es como si fuera el precio con el que vamos vender
TiempoGarantia					INT				NULL,
FechaHoraVencimiento			DATETIME		NULL,
PRIMARY KEY (NumeroAgencia, NumeroReemplazo, CodigoProducto),
FOREIGN KEY (NumeroAgencia, NumeroReemplazo) 
REFERENCES VentasProductosReemplazo(NumeroAgencia, NumeroReemplazo)
)
GO

CREATE TABLE VentasProductosReemplazoEspecificos
(
NumeroAgencia					INT				NOT NULL,
NumeroReemplazo					INT				NOT NULL,
CodigoProducto					CHAR(15)		NOT NULL,
CodigoProductoEspecifico		CHAR(20)		NOT NULL,
PrecioUnitarioReemplazoPE		DECIMAL(10,2)	NOT NULL DEFAULT 0, --precio al cual vamos a intercambiar, es como si fuera el precio con el que vamos vender
TiempoGarantiaPE				INT				NULL,
FechaHoraVencimientoPE			DATETIME		NULL,
PRIMARY KEY(NumeroAgencia, NumeroReemplazo, CodigoProducto, CodigoProductoEspecifico),
FOREIGN KEY(NumeroAgencia, NumeroReemplazo, CodigoProducto) 
REFERENCES VentasProductosReemplazoDetalle (NumeroAgencia, NumeroReemplazo, CodigoProducto) 
)
GO

CREATE TABLE VentasProductosReemplazoDevoluciones
(
NumeroAgencia					INT			NOT NULL REFERENCES Agencias(NumeroAgencia),
NumeroVentaProductosReemDevo	INT			NOT NULL IDENTITY(1,1),
CodigoEstadoReemplazoDevo		CHAR(1)		NOT NULL CHECK (CodigoEstadoReemplazoDevo IN ('I', 'C', 'F', 'A')), --I'->Iniciada, 'C'->Cancelada, 'F'->Finalizada, 'A'->Anulada
CodigoUsuario					INT			NOT NULL REFERENCES Usuarios(CodigoUsuario),
FechaHoraSolicitudReemDevo		DATETIME	NOT NULL DEFAULT GETDATE(),
ObservacionesReemDevo			TEXT		NULL,
NumeroReemplazo					INT			NOT NULL,
PRIMARY KEY (NumeroAgencia, NumeroVentaProductosReemDevo),
FOREIGN KEY (NumeroAgencia,NumeroReemplazo)
REFERENCES VentasProductosReemplazo (NumeroAgencia,NumeroReemplazo)
)
GO


CREATE TABLE VentasProductosReemplazoDevolucionesDetalle
(
NumeroAgencia					INT		NOT NULL,
NumeroVentaProductosReemDevo	INT		NOT NULL,
NumeroAgenciaDevolucion			INT		NOT NULL,
NumeroDevolucion				INT		NOT NULL,
CodigoProductoDevolucion		CHAR(15)NOT NULL,
MontoTotalDevolucion			DECIMAL (10,2) NOT NULL DEFAULT 0,
NumeroAgenciaReemplazo			INT		NOT NULL,
NumeroReemplazo					INT		NOT NULL,
CodigoProductoReemplazo			CHAR(15)NOT NULL,
MontoTotalReemplazo				DECIMAL (10,2)	NOT NULL	

PRIMARY KEY(NumeroAgencia ,NumeroVentaProductosReemDevo, NumeroAgenciaDevolucion, NumeroDevolucion, CodigoProductoDevolucion, NumeroAgenciaReemplazo, NumeroReemplazo, CodigoProductoReemplazo),
FOREIGN KEY(NumeroAgencia, NumeroVentaProductosReemDevo)
REFERENCES VentasProductosReemplazoDevoluciones(NumeroAgencia, NumeroVentaProductosReemDevo),
FOREIGN KEY(NumeroAgenciaDevolucion, NumeroDevolucion, CodigoProductoDevolucion)
REFERENCES VentasProductosDevolucionesDetalle(NumeroAgencia, NumeroDevolucion, CodigoProducto),
FOREIGN KEY(NumeroAgenciaReemplazo, NumeroReemplazo, CodigoProductoReemplazo)
REFERENCES VentasProductosReemplazoDetalle(NumeroAgencia, NumeroReemplazo, CodigoProducto)
)
GO


CREATE TABLE TransferenciasProductos
(
NumeroAgenciaEmisora			INT				NOT NULL REFERENCES Agencias(NumeroAgencia),
NumeroTransferenciaProducto		INT				NOT NULL IDENTITY (1,1),
NumeroAgenciaRecepctora			INT				NOT NULL REFERENCES Agencias(NumeroAgencia),
CodigoUsuario					INT				NOT NULL REFERENCES Usuarios(CodigoUsuario),
FechaHoraTransferencia			DATETIME		NOT NULL DEFAULT GETDATE(),
CodigoEstadoTransferencia		CHAR(1)			NOT NULL CHECK(CodigoEstadoTransferencia IN ('I','E', 'P','A', 'D', 'F', 'X')), --I'->Iniciada,'E' Enviada y Emitida,  'P'->Pagada y Confirmada su Envio, 'A'->Anulada, 'D'->Pendiente (Recepción por partes), 'F'->Finalizada, 'X'->Envio o Receipcion Incompleta 
MontoTotalTransferencia			DECIMAL(10,2)	NOT NULL, --incluye los Gastos de transferencia
CodigoMoneda					TINYINT			NULL REFERENCES Monedas(CodigoMoneda),
Observaciones					TEXT			NULL,
PRIMARY KEY (NumeroAgenciaEmisora, NumeroTransferenciaProducto)
)
GO

CREATE TABLE TransferenciasProductosDetalle
(
NumeroAgenciaEmisora				INT				NOT NULL,
NumeroTransferenciaProducto			INT				NOT NULL,
CodigoProducto						CHAR(15)		NOT NULL REFERENCES Productos(CodigoProducto),
CantidadTransferencia				INT				NOT NULL DEFAULT 0,
PrecioUnitarioTransferencia			DECIMAL(10,2)	NOT NULL,
MontoAdicionalPorGastos				DECIMAL(5,2)	NULL     DEFAULT 0,
MontoAdicionalPorGastosRecepcion	DECIMAL(5,2)	NULL     DEFAULT 0,
PRIMARY KEY(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto),
FOREIGN KEY (NumeroAgenciaEmisora, NumeroTransferenciaProducto)
REFERENCES TransferenciasProductos(NumeroAgenciaEmisora, NumeroTransferenciaProducto)
)
GO


CREATE TABLE TransferenciasProductosDetalleRecepcion
(
NumeroAgenciaEmisora			INT				NOT NULL,
NumeroTransferenciaProducto		INT				NOT NULL,
CodigoProducto					CHAR(15)		NOT NULL REFERENCES Productos(CodigoProducto),
FechaHoraEnvioRecepcion			DATETIME		NOT NULL DEFAULT GETDATE(),
CantidadEnvioRecepcion			INT				NOT NULL DEFAULT 0,
CodigoTipoEnvioRecepcion		CHAR(1)			NULL DEFAULT 'E' CHECK(CodigoTipoEnvioRecepcion IN ('E','R','X')),-- 'E'->Envio, 'R'->Recepción, 'X'->Recepcion Incompleta
FechaHoraEnvioPadre				DATETIME		NULL-- Cuando se Recepciona, esta fecha hace referencia a la fecha en la que se envió los productos de una transf. si es null, se recepcionó todo a la ultimo envió o en su totalidad 
PRIMARY KEY(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, FechaHoraEnvioRecepcion),
FOREIGN KEY (NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto)
REFERENCES TransferenciasProductosDetalle(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto),
FOREIGN KEY (NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, FechaHoraEnvioPadre)
REFERENCES TransferenciasProductosDetalleRecepcion(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, FechaHoraEnvioRecepcion)
)
GO


CREATE TABLE TransferenciasProductosEspecificos
(
NumeroAgenciaEmisora			INT				NOT NULL,
NumeroTransferenciaProducto		INT				NOT NULL,
CodigoProducto					CHAR(15)		NOT NULL,
CodigoProductoEspecifico		CHAR(20)		NOT NULL,
Entregado						BIT				NULL DEFAULT 0,
CodigoEstadoRecepcion			CHAR(1)			NULL DEFAULT 'A' CHECK(CodigoEstadoRecepcion IN ('A','R','B')),-- 'A' -> Alta, 'B'->Baja, 'R'-> Reparación ,'V'-> Vendido, 'T'-> Transferencia
FechaHoraEnvio					DATETIME		NULL,
FechaHoraRecepcion				DATETIME		NULL,
PRIMARY KEY(NumeroAgenciaEmisora, NumeroTransferenciaProducto,CodigoProducto,CodigoProductoEspecifico),
FOREIGN KEY (NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto) 
REFERENCES TransferenciasProductosDetalle(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto),
FOREIGN KEY (NumeroAgenciaEmisora, CodigoProducto,CodigoProductoEspecifico) 
REFERENCES InventariosProductosEspecificos(NumeroAgencia, CodigoProducto,CodigoProductoEspecifico)
)
GO

CREATE TABLE TransferenciasProductosGastosDetalle
(
NumeroAgenciaEmisora				INT				NOT NULL,
NumeroTransferenciaProducto			INT				NOT NULL,
NumeroTransaferenciaProductoGasto	INT				NOT NULL IDENTITY (1,1),
CodigoGastosTipos					INT				NOT NULL REFERENCES GastosTiposTransacciones(CodigoGastosTipos),
FechaHoraGasto						DATETIME		NOT NULL,
MontoPagoGasto						DECIMAL(10,2)	NOT NULL,
CodigoMonedaPago					TINYINT			NULL	 REFERENCES	Monedas(CodigoMoneda),
Observaciones						TEXT			NULL,
CodigoEstadoGastoAplicado			BIT				NULL DEFAULT 0,	--'1'-> Aplicado para el calculo de Precio de Compra a Inventario, '0' -> en Espera de SEr Calculado
CodigoTipoGastoRecepcion			CHAR(1)			NULL DEFAULT 'E' CHECK(CodigoTipoGastoRecepcion IN ('E','R'))-- 'E'->Envio, 'R'->Recepción
PRIMARY KEY (NumeroAgenciaEmisora, NumeroTransferenciaProducto, NumeroTransaferenciaProductoGasto),
FOREIGN KEY (NumeroAgenciaEmisora, NumeroTransferenciaProducto) 
REFERENCES TransferenciasProductos(NumeroAgenciaEmisora, NumeroTransferenciaProducto)
)
GO


