USE Doblones20
GO

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
DROP TABLE CotizacionVentasProductosDeta
GO
DROP TABLE CotizacionVentasProductos
GO
DROP TABLE VentasServiciosDetalle
GO
DROP TABLE VentasServicios
GO
DROP TABLE Servicios
GO
DROP TABLE VentasFacturas
GO
DROP TABLE ComprasProductosPagosDetalle
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
DROP TABLE InventarioProductosCantidadesComprasHistorial
GO
DROP TABLE InventariosProductosEspecificos
GO
DROP TABLE InventariosProductos
GO
DROP TABLE ProductosTiposGarantias
GO
DROP TABLE MedioTransporte
GO
DROP TABLE OrigenMercaderia
GO

CREATE TABLE OrigenMercaderia
(
CodigoOrigenMercaderia	TINYINT			NOT NULL IDENTITY (1,1) PRIMARY KEY,
NombreOrigenMercaderia	VARCHAR(250)	NOT NULL,
Descripcion				TEXT			NULL
)

CREATE TABLE MedioTransporte
(
CodigoMedioTransporte	TINYINT			NOT NULL IDENTITY (1,1) PRIMARY KEY,
NombreMedioTransporte	VARCHAR(250)	NOT NULL,
Descripcion				TEXT			NULL		
)
GO

CREATE TABLE ProductosTiposGarantias
(
CodigoTipoGarantia		TINYINT IDENTITY(1,1) ,
NombreTipoGarantia		VARCHAR(250)	NOT NULL,
Descripcion				VARCHAR(200)		NULL,
CONSTRAINT PK_ProductosTiposGarantias PRIMARY KEY (CodigoTipoGarantia)
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
CotigoTipoGarantia				TINYINT			NOT NULL DEFAULT 1,
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
PorcentajeComision1				DECIMAL(5,2)	NOT NULL DEFAULT 0,
PorcentajeComision2				DECIMAL(5,2)	NOT NULL DEFAULT 0,
PorcentajeComision3				DECIMAL(5,2)	NOT NULL DEFAULT 0,
StockMinimo						INT				NOT NULL DEFAULT 1,
MostrarParaVenta				BIT				NOT NULL DEFAULT 1,
ClaseProducto					CHAR(1)			NOT NULL DEFAULT 'S' CHECK(ClaseProducto IN ('S', 'C')), --S = Simple; C = Compuesto
EsProductoEspecifico			BIT				NOT NULL DEFAULT 0,
ProductoEspecificoInventariado	BIT				NOT NULL DEFAULT 0,
PrecioValoradoTotal				DECIMAL(10,2)	NULL	 DEFAULT 0,
PRIMARY KEY (NumeroAgencia, CodigoProducto),
CONSTRAINT FK_ProductosTiposGarantias FOREIGN KEY (CotigoTipoGarantia) REFERENCES ProductosTiposGarantias(CodigoTipoGarantia)
)
GO

CREATE TABLE InventariosProductosEspecificos
(
NumeroAgencia				INT				NOT NULL,
CodigoProducto				CHAR(15)		NOT NULL,
CodigoProductoEspecifico	CHAR(30)		NOT NULL,
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
CodigoCompraProducto		CHAR(12)		NULL DEFAULT dbo.ObtenerCodigoCompraProducto(),
CodigoProveedor				INT				NOT NULL REFERENCES Proveedores(CodigoProveedor),
CodigoUsuario				INT				NOT NULL REFERENCES Usuarios(CodigoUsuario),
CodigoUsuarioResponsablePago	INT			NULL REFERENCES Usuarios(CodigoUsuario),
CodigoUsuarioResponsableRecepcion	INT		NULL REFERENCES Usuarios(CodigoUsuario),
DIPersonaDestinatario		CHAR(15)		NULL REFERENCES Personas(DIPersona),
Fecha						DATETIME		NOT NULL,
FechaHoraPlazoDeRecepcion	DATETIME		NULL,
FechaHoraPago				DATETIME		NULL,
FechaHoraRecepcion			DATETIME		NULL,
FechaHoraEnvioMercaderia	DATETIME		NULL,
CodigoTipoCompra			CHAR(1)			NOT NULL CHECK(CodigoTipoCompra IN ('E','R')), --E'-> Efectivo, 'R'->Credito
CodigoEstadoCompra			CHAR(1)			NOT NULL CHECK(CodigoEstadoCompra IN ('I', 'A', 'P', 'D', 'F','X' )), --I'->Iniciada, 'A'->Anulada, 'P'-> Pagada, 'D'->Pendiente Y en Transito, 'F'->Finalizada,'X' -> Finalizada pero Recepción incompleta 
CodigoEstadoFactura			CHAR(1)			NULL	 CHECK(CodigoEstadoFactura IN ('F','S')) DEFAULT 'S', -- 'F'->COMPRA FACTURADA REALIZADA CON FACTURA, 'S'-> Sin Factura
ImpuestoIVA					DECIMAL(5,2)	NULL DEFAULT 0,
NumeroFactura				CHAR(10)		NULL,
NumeroAutorizacionFactura	CHAR(10)		NULL,
CodigoControlFactura		CHAR(10)		NULL,
EsImportacion				BIT				NULL DEFAULT 1,
RegistroDirectoAlmacen		BIT				NULL DEFAULT 0,
CodigoMedioTransporte		TINYINT			NULL,
MontoTotalCompra			DECIMAL(10,2)	NOT NULL, --Monto que se ha cancelado al proveedor
MontoNetoCompra				DECIMAL(10,2)	NOT NULL,-- Monto Real de la Compra
MontoTotalPagoEfectivo		DECIMAL(10,2)	NULL	 DEFAULT 0,
MontoDescuento				DECIMAL(10,2)	NULL DEFAULT 0,--Descuento que realiza el Proveedor
NumeroCuentaPorPagar		INT				NULL,
CodigoOrigenMercaderia		TINYINT,
NumeroGuiaTranposrte		CHAR(10),
CodigoMoneda				TINYINT			NULL,	 
Observaciones				TEXT			NULL,
PRIMARY KEY (NumeroAgencia, NumeroCompraProducto),
CONSTRAINT FK_ComprasMediosTransporte FOREIGN KEY (CodigoMedioTransporte) REFERENCES MedioTransporte (CodigoMedioTransporte)
--FOREIGN KEY (NumeroAgencia,NumeroCuentaPorPagar) REFERENCES CuentasPorPagar(NumeroAgencia, NumeroCuentaPorPagar)
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

CREATE TABLE ComprasProductosPagosDetalle
(
NumeroAgencia				INT				NOT NULL,
NumeroCompraProducto		INT				NOT NULL,
NumeroCompraProductoPago	INT				NOT NULL IDENTITY (1,1),
FechaHoraPago				DATETIME		NULL	 DEFAULT GETDATE(),
MontoTotalPago				DECIMAL(10,2)	NOT NULL,
CodigoMonedaPago			TINYINT			NULL,
NumeroCuenta				CHAR(13)		NOT NULL,
Observaciones				TEXT			NULL,
CONSTRAINT PK_ComprasProductosPagosDetalle PRIMARY KEY (NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoPago),
CONSTRAINT FK_ComprasProductosPagosDetalleMonedas FOREIGN KEY(CodigoMonedaPago) REFERENCES	Monedas(CodigoMoneda),
CONSTRAINT FK_ComprasProductosPagosDetallePlanCuentas FOREIGN KEY(NumeroCuenta) REFERENCES	PlanCuentas(NumeroCuenta)
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
PorcentajeDescuento			DECIMAL(5,2)	DEFAULT 0,
PrecioUnitarioCompraOtraMoneda	DECIMAL(10,2)NULL,
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
CodigoProductoEspecifico	CHAR(30)		NOT NULL,
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
CodigoProductoEspecifico	CHAR(30)		NOT NULL,
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
CodigoProductoEspecifico		CHAR(30)		NOT NULL,
PrecioUnitarioDevolucionPE		DECIMAL(10,2)	NOT NULL DEFAULT 0,
PRIMARY KEY (NumeroAgencia, NumeroDevolucion, CodigoProducto,CodigoProductoEspecifico),
FOREIGN KEY (NumeroAgencia, NumeroDevolucion, CodigoProducto)
REFERENCES ComprasProductosDevolucionesDetalle(NumeroAgencia, NumeroDevolucion, CodigoProducto)
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
	TiempoGarantiaDias		INT				NULL	 DEFAULT 0	
	CONSTRAINT PK_VentasServiciosDetalle	PRIMARY KEY (NumeroAgencia, NumeroVentaServicio, CodigoServicio),
	CONSTRAINT FK_VentasServiciosDetalle	FOREIGN KEY (NumeroAgencia, NumeroVentaServicio)	REFERENCES VentasServicios(NumeroAgencia, NumeroVentaServicio),
	CONSTRAINT FK_VentasServiciosDetalleSer FOREIGN KEY (CodigoServicio)						REFERENCES Servicios(CodigoServicio)
)
GO


CREATE TABLE VentasProductos
(
NumeroAgencia					INT				NOT NULL REFERENCES Agencias(NumeroAgencia),
NumeroVentaProducto				INT				NOT NULL IDENTITY (1,1),
CodigoVentaProducto				CHAR(12)		NULL DEFAULT dbo.ObtenerCodigoVentaProducto(),
CodigoCliente					INT				NOT NULL REFERENCES Clientes(CodigoCliente),
CodigoUsuario					INT				NOT NULL REFERENCES Usuarios(CodigoUsuario),
NumeroFactura					INT				NULL, 
FechaHoraVenta					DATETIME		NOT NULL DEFAULT GETDATE(),
FechaHoraEntrega				DATETIME		NULL,
CodigoEstadoVenta				CHAR(1)			NOT NULL CHECK(CodigoEstadoVenta IN ('I','P', 'F', 'A','T', 'C','E','D')), --I'->Iniciada, 'P'->Pagada, 'F'->Finalizada, 'A'->Anulada, 'T'->Venta a Insituticiones, 'C'->Entrega de Productos en Confianza, 'D'->Pendiente (Venta Institucional), 'E'->En Espera(Venta Normal)
MontoTotalVenta					DECIMAL(10,2)	NOT NULL, --incluye los agregados en caso de que tengan precio
MontoTotalPagoEfectivo			DECIMAL(10,2)	NULL	 DEFAULT 0,
MontoTotalVentaMonedaExtranjera	DECIMAL(10,2)	NULL	 DEFAULT 0,
MontoTotalVentaProductos		DECIMAL(10,2)	NULL	 DEFAULT 0, --Monto Exclusivo de los Productos que se Venden
MontoTotalVentaServicios		DECIMAL(10,2)	NULL	 DEFAULT 0, --Monto que se Cancela por algun servicio extra que incluye la Venta
NumeroVentaServicio				INT				NULL,
NumeroCredito					INT				NULL	 REFERENCES Creditos(NumeroCredito),
CodigoMoneda					TINYINT			NOT NULL REFERENCES Monedas(CodigoMoneda),
CodigoTipoVenta					CHAR(1)			NOT NULL DEFAULT 'N' CHECK(CodigoTipoVenta in ('N','T')), --'N'->Venta Normal y Corriente, 'T'->Venta Institucional
Observaciones					TEXT			NULL,
CONSTRAINT PK_VentasProductos			PRIMARY KEY (NumeroAgencia, NumeroVentaProducto),
CONSTRAINT FK_VentasProductosFacturas	FOREIGN KEY(NumeroAgencia, NumeroFactura) REFERENCES VentasFacturas(NumeroAgencia, NumeroFactura),
CONSTRAINT FK_VentasProductosServicios	FOREIGN KEY(NumeroAgencia, NumeroVentaServicio) REFERENCES VentasServicios(NumeroAgencia, NumeroVentaServicio)
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
PrecioUnitarioVentaOtraMoneda	DECIMAL(10,2)	NULL,
TiempoGarantiaVenta				INT				NOT NULL,
PorcentajeDescuento				DECIMAL(10,2)	NULL DEFAULT 0,
NumeroPrecioSeleccionado		CHAR(1)			NULL DEFAULT '1' CHECK (NumeroPrecioSeleccionado IN ('1','2','3','4','5','6','P')), --Precio1, Precio2, Precio3, Precio4, Precio5, Precio6, Personalizado,
NumeroOrdenInsertado			INT				NULL,
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
FechaHoraCompraInventario		DATETIME		NULL,
CantidadEntregada				INT				NOT NULL DEFAULT 0,
PrecioUnitarioCompraInventario	DECIMAL(10,2)	NULL,
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
CodigoProductoEspecifico		CHAR(30)		NOT NULL,
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
CodigoProductoEspecifico		CHAR(30)		NOT NULL,
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
CodigoProductoEspecifico		CHAR(30)		NOT NULL,
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
CodigoProductoEspecifico		CHAR(30)		NOT NULL,
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
CodigoProductoEspecifico		CHAR(30)		NOT NULL,
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
CONSTRAINT FK_CotizacionVentasProductosServicios	FOREIGN KEY(NumeroAgencia, NumeroVentaServicio) REFERENCES VentasServicios(NumeroAgencia, NumeroVentaServicio)
)
GO

CREATE TABLE CotizacionVentasProductosDeta
(
NumeroAgencia					INT				NOT NULL, 
NumeroCotizacionVentaProducto	INT				NOT NULL,
CodigoProducto					CHAR(15)		NOT NULL REFERENCES Productos(CodigoProducto),
CantidadCotizacionVenta			INT				NOT NULL,
PrecioUnitarioCotizacionVenta	DECIMAL(10,2)	NOT NULL,
PrecioUnitarioCotizacionOtraMoneda	DECIMAL(10,2)	NULL,
TiempoGarantiaCotizacionVenta	INT				NOT NULL,
PorcentajeDescuento				DECIMAL(10,2)	NULL DEFAULT 0,
NumeroPrecioSeleccionado		CHAR(1)			NULL DEFAULT '1' CHECK (NumeroPrecioSeleccionado IN ('1','2','3','4','5','6','P')), --Precio1, Precio2, Precio3, Precio4, Precio5, Precio6, Personalizado
NumeroOrdenInsertado			INT				NULL,
PRIMARY KEY(NumeroAgencia, NumeroCotizacionVentaProducto, CodigoProducto),
FOREIGN KEY (NumeroAgencia, NumeroCotizacionVentaProducto) 
REFERENCES CotizacionVentasProductos(NumeroAgencia, NumeroCotizacionVentaProducto)
)
GO
