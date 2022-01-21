/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
--BEGIN TRANSACTION
--SET QUOTED_IDENTIFIER ON
--SET ARITHABORT ON
--SET NUMERIC_ROUNDABORT OFF
--SET CONCAT_NULL_YIELDS_NULL ON
--SET ANSI_NULLS ON
--SET ANSI_PADDING ON
--SET ANSI_WARNINGS ON
--COMMIT
--BEGIN TRANSACTION
--GO
--ALTER TABLE DBO.COMPRASPRODUCTOS ADD
--	CodigoUsuarioResponsablePago		INT NULL,
--	CodigousuarioResponsableRecepcion	INT NULL,
--	FechaHoraplazoDeRecepcion			DATETIME NULL,
--	FechaHoraPago						DATETIME NULL,
--	FechaHoraRecepcion					DATETIME NULL,
--	CONSTRAINT FK_COMPRASPRODUCTOS_RESPONSABLEPAGO FOREIGN KEY(CodigoUsuarioResponsablePago) REFERENCES USUARIOS(codigousuario),
--  CONSTRAINT FK_COMPRASPRODUCTOS_RESPONSABLERECEPCION FOREIGN KEY(CODIGOUSUARIORESPONSABLERECEPCION) REFERENCES USUARIOS(CODIGOUSUARIO)
--GO
--ALTER TABLE DBO.COMPRASPRODUCTOS SET (LOCK_ESCALATION = TABLE)
--GO
--COMMIT
--GO

--02/05/2011 8:57
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ComprasProductos ADD
	CodigoCompraProducto		CHAR(12)		NULL DEFAULT dbo.ObtenerCodigoCompraProducto(),
	DIPersonaDestinatario		CHAR(15)		NULL REFERENCES Personas(DIPersona),
	FechaHoraEnvioMercaderia	DATETIME		NULL,
	ImpuestoIVA					DECIMAL(5,2)	NULL DEFAULT 0,
	NumeroFactura				CHAR(10)		NULL,
	NumeroAutorizacionFactura	CHAR(10)		NULL,
	CodigoControlFactura		CHAR(10)		NULL,
	EsImportacion				BIT				NULL DEFAULT 1,
	RegistroDirectoAlmacen		BIT				NULL DEFAULT 0,
	CodigoMedioTransporte		TINYINT			NULL,
	MontoDescuento				DECIMAL(10,2)	NULL DEFAULT 0,--Descuento que realiza el Proveedor
	MontoNetoCompra				DECIMAL(10,2)	NULL DEFAULT 0,-- Monto Real de la Compra
	CodigoOrigenMercaderia		TINYINT		NULL,
	NumeroGuiaTranposrte		CHAR(10)	NULL,
	CodigoUsuarioResponsablePago		INT NULL,
	CodigousuarioResponsableRecepcion	INT NULL,
	FechaHoraplazoDeRecepcion			DATETIME NULL,
	FechaHoraPago						DATETIME NULL,
	FechaHoraRecepcion					DATETIME NULL,
	CodigoMoneda	TINYINT NULL,
	CONSTRAINT FK_ComprasMonedas FOREIGN KEY (CodigoMoneda) REFERENCES dbo.Monedas (CodigoMoneda),
	CONSTRAINT FK_COMPRASPRODUCTOS_RESPONSABLEPAGO FOREIGN KEY(CodigoUsuarioResponsablePago) REFERENCES USUARIOS(codigousuario),
	CONSTRAINT FK_COMPRASPRODUCTOS_RESPONSABLERECEPCION FOREIGN KEY(CODIGOUSUARIORESPONSABLERECEPCION) REFERENCES USUARIOS(CODIGOUSUARIO),	
	CONSTRAINT FK_ComprasMediosTransporte FOREIGN KEY (CodigoMedioTransporte) REFERENCES MedioTransporte (CodigoMedioTransporte)

GO
ALTER TABLE dbo.ComprasProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GO



BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ComprasProductos ADD
	CodigoMoneda	TINYINT NULL,
	CONSTRAINT FK_ComprasMonedas FOREIGN KEY (CodigoMoneda) REFERENCES dbo.Monedas (CodigoMoneda)
GO
ALTER TABLE dbo.ComprasProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GO



BEGIN TRANSACTION
GO
ALTER TABLE dbo.VentasProductosDetalle ADD
	--NumeroOrdenInsertado	INT NULL,
	PrecioUnitarioVentaOtraMoneda	DECIMAL(10,2)	NULL
GO
ALTER TABLE dbo.ComprasProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GO


BEGIN TRANSACTION
GO
ALTER TABLE  dbo.CotizacionVentasProductosDeta ADD
	--NumeroOrdenInsertado	INT NULL
	PrecioUnitarioCotizacionOtraMoneda	DECIMAL(10,2)	NULL
GO
ALTER TABLE dbo.ComprasProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GO



BEGIN TRANSACTION
GO
ALTER TABLE dbo.ComprasProductosDetalle ADD
	PorcentajeDescuento				DECIMAL(5,2)	DEFAULT 0,
	PrecioUnitarioCompraOtraMoneda	DECIMAL(10,2)	NULL
GO
ALTER TABLE dbo.ComprasProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GO



--31/03/2012
ALTER TABLE dbo.VentasProductos ADD
	CodigoVentaProducto		CHAR(12)		NULL DEFAULT dbo.ObtenerCodigoVentaProducto()
	

ALTER TABLE dbo.PCsConfiguraciones ADD
	PorcentajeImpuestoCompraConFactura		DECIMAL(10,2)		NULL DEFAULT 15.5,
	PorcentajeImpuestoCompraSinFactura		DECIMAL(10,2)		NULL DEFAULT 8

UPDATE PCsConfiguraciones
	SET PorcentajeImpuestoCompraConFactura = 15.5,
		PorcentajeImpuestoCompraSinFactura = 8