USE Doblones20
GO

DROP TABLE ProductosEmpresasListaDetalle
GO

DROP TABLE ProductosEmpresasLista
GO


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