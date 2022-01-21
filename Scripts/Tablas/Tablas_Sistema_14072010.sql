USE DOBLONES20
/*
DROP TABLE FrecuenciasPagos

DROP TABLE MotivosReemDevo
GO
DROP TABLE DocumentosTipos
GO
*/
DROP TABLE UsuariosAgenciasMenuPrincipal
GO
DROP TABLE SistemaGruposMenuPrincipal
GO
DROP TABLE SistemaMenuPrincipal
GO
DROP TABLE UsuariosAgenciasPermisosInterfaces
GO
DROP TABLE SistemaGruposUsuarios
GO
DROP TABLE SistemaGruposPermisosInterfaces
GO
DROP TABLE SistemaGrupos
GO
/*
DROP TABLE Usuarios				
GO
*/
DROP TABLE SistemaInterfaces
GO
DROP TABLE PCsConfiguraciones
GO
/*
DROP TABLE Agencias
GO
DROP TABLE Personas
GO
DROP TABLE Lugares
GO
DROP TABLE Provincias
GO
DROP TABLE Departamentos
GO
DROP TABLE Paises
GO
DROP TABLE Bancos
GO
DROP TABLE MonedasCotizaciones
GO
DROP TABLE Monedas
GO
*/
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
NumeroAgenciaSuperior	INT					NULL,
FOREIGN KEY (CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar) 
REFERENCES Lugares(CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar)
)
GO

*/

CREATE TABLE PCsConfiguraciones
(
NumeroPC				INT					NOT NULL IDENTITY (1, 1) PRIMARY KEY,
IDPC					CHAR(50)			NOT NULL UNIQUE,
IPPC					CHAR(15)			NOT NULL,
NumeroAgencia			INT					NOT NULL REFERENCES Agencias(NumeroAgencia),
CodigoMonedaSistema		TINYINT				NOT NULL REFERENCES Monedas(CodigoMoneda),
CodigoMonedaRegion		TINYINT				NOT NULL REFERENCES Monedas(CodigoMoneda),
PorcentajeImpuesto		DECIMAL(10,2)		NOT NULL DEFAULT 0,
ContabilidadIntegrada	BIT					NOT NULL DEFAULT 0,
)
GO

CREATE TABLE SistemaInterfaces
(
CodigoInterface			TINYINT				NOT NULL IDENTITY(1, 1) PRIMARY KEY,
NombreInterface			VARCHAR(250)		NOT NULL UNIQUE,
TextoInterface			VARCHAR(250)		NOT NULL,
CodigoTipoInterface		CHAR(1)				NOT NULL DEFAULT 'P' --'G'->Uso general, 'P'->Uso personalizado
)
GO

/*
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
*/

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
PRIMARY KEY (CodigoUsuario, NumeroAgencia, CodigoGrupoSistema)
)
GO

CREATE TABLE UsuariosAgenciasPermisosInterfaces
(
CodigoUsuario						INT				NOT NULL,
NumeroAgencia						INT				NOT NULL,
CodigoGrupoSistema					TINYINT			NOT NULL,
CodigoInterface						TINYINT			NOT NULL REFERENCES SistemaInterfaces(CodigoInterface),
PermitirInsertar					BIT				NOT NULL DEFAULT 0,
PermitirEditar						BIT				NOT NULL DEFAULT 0,
PermitirEliminar					BIT				NOT NULL DEFAULT 0,
PermitirNavegar						BIT				NOT NULL DEFAULT 0,
PermitirReportes					BIT				NOT NULL DEFAULT 0,
PRIMARY KEY (CodigoUsuario, NumeroAgencia, CodigoGrupoSistema, CodigoInterface),
FOREIGN KEY (CodigoUsuario, NumeroAgencia, CodigoGrupoSistema) 
REFERENCES SistemaGruposUsuarios(CodigoUsuario, NumeroAgencia, CodigoGrupoSistema)
)
GO


CREATE TABLE SistemaMenuPrincipal
(
CodigoElementoMenu							INT					NOT NULL PRIMARY KEY,
CodigoElementoMenuPadre						INT					NULL,
NombreElementoMenu							VARCHAR(250)		NOT NULL UNIQUE,
TextoElementoMenu							VARCHAR(250)		NULL,
CodigoTipoElementoMenu						CHAR(1)				NOT NULL,--'S'->Separador, 'M'->Elemento menu, 'C'->'ComboBox', 'T'->TextBox
URLImagenElementoMenu						VARCHAR(MAX)		NULL,
NombreBotonBarra							VARCHAR(250)		NULL,
NombreBotonBarraPadre						VARCHAR(250)		NULL,
TextoBotonBarra								VARCHAR(250)		NULL,
URLImagenBotonBarra							VARCHAR(MAX)		NULL,
FuncionEnlace								VARCHAR(MAX)		NULL
)
GO

CREATE TABLE SistemaGruposMenuPrincipal
(
CodigoGrupoSistema					TINYINT			NOT NULL REFERENCES SistemaGrupos(CodigoGrupoSistema), 
CodigoElementoMenu					INT				NOT NULL REFERENCES SistemaMenuPrincipal(CodigoElementoMenu),
Visible								BIT				NOT NULL DEFAULT 0,
Activo								BIT				NOT NULL DEFAULT 0,
IncluirBotonBarra					BIT				NOT NULL DEFAULT 0,
PRIMARY KEY (CodigoGrupoSistema, CodigoElementoMenu)
)
GO

CREATE TABLE UsuariosAgenciasMenuPrincipal
(
CodigoUsuario						INT					NOT NULL,
NumeroAgencia						INT					NOT NULL,
CodigoGrupoSistema					TINYINT				NOT NULL, 
CodigoElementoMenu					INT					NOT NULL REFERENCES SistemaMenuPrincipal(CodigoElementoMenu),
Visible								BIT					NOT NULL DEFAULT 0,
Activo								BIT					NOT NULL DEFAULT 0,
IncluirBotonBarra					BIT					NOT NULL DEFAULT 0,
PRIMARY KEY (CodigoUsuario, NumeroAgencia, CodigoGrupoSistema, CodigoElementoMenu),
FOREIGN KEY (CodigoUsuario, NumeroAgencia, CodigoGrupoSistema) 
REFERENCES SistemaGruposUsuarios(CodigoUsuario, NumeroAgencia, CodigoGrupoSistema)
)
GO

/*
CREATE TABLE DocumentosTipos
(
CodigoTipoDocumento		TINYINT				NOT NULL IDENTITY (1,1) PRIMARY KEY,
NombreTipoDocumento		VARCHAR(250)		NOT NULL
)
GO

CREATE TABLE MotivosReemDevo
(
CodigoMotivoReemDevo	INT					NOT NULL IDENTITY(1,1) PRIMARY KEY,
NombreMotivoReemDevo	VARCHAR(250)		NOT NULL
)
GO

CREATE TABLE FrecuenciasPagos
(
CodigoFrecuenciaPago			INT			NOT NULL IDENTITY (1,1) PRIMARY KEY,
NombreFrecuenciaPago			VARCHAR(50) NOT NULL,
NumeroDias						INT			NOT NULL
)
GO 

*/
