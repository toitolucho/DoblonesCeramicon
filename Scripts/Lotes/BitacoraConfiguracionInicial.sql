USE Doblones20
GO

DROP TABLE Bitacora
GO

CREATE TABLE Bitacora
(
BitacoraID	INT				NOT NULL IDENTITY (1, 1) PRIMARY KEY ,
EventType	NVARCHAR(30)	NOT NULL,
Status		INT				NOT NULL,
EventInfo	NVARCHAR(4000)	NOT NULL,
Usuario		VARCHAR(200)	NULL DEFAULT (suser_sname()),
Fecha		DATETIME	NULL DEFAULT (getdate())
) 
GO


USE Doblones20
GO

DROP PROCEDURE InsertarBitacora
GO

CREATE PROCEDURE InsertarBitacora
	@EventType	NVARCHAR(30),
	@Status		INT,	
	@EventInfo	NVARCHAR(4000)
AS
BEGIN
INSERT INTO Bitacora (EventType, Status, EventInfo)
VALUES(@EventType, @Status, @EventInfo)
END
GO

select * from Bitacora

--select * from AlvecoComercial10.dbo.Bitacora

INSERT INTO Usuarios(NombreUsuario, Contrasena, DIUsuario, Paterno, Materno, Nombres, Sexo, Celular, Email) 
VALUES('administrador', 'administrador', '000000000000000', 'Molina', 'Yampa', 'Luis Antonio', 'M', '72854863', 'antoniomolina.yampa@gmail.com') 
	
SELECT * FROM usuarios
select * from Bitacora
--delete from Bitacora
--declare @NombreUsuario VARCHAR(160) = 'postgres',
--		@Contrasena	   VARCHAR(160) = 'postgres'


Contrasenia Anterior : administrador                   ,   Nueva Contrasenia: holamundo                       
Contrasenia Anterior : administrador                   ,   Nueva Contrasenia: holamundo                       
Contrasenia Anterior : administrador                   ,   Nueva Contrasenia: holamundo
--primera tarea

EXEC ('USE Doblones20; EXEC sp_droprolemember N''db_owner'', ''administrador''')
EXEC ('USE Doblones20; DROP USER administrador')
EXEC ('USE master; DROP LOGIN  administrador')	


--segunda tarea
EXEC ('USE master; CREATE LOGIN administrador WITH PASSWORD =N''' + 'administrador' + ''', DEFAULT_LANGUAGE=Español, CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF; USE ' + 'Doblones20')
EXEC ('USE Doblones20; CREATE USER administrador FOR LOGIN administrador' )
EXEC ('USE Doblones20; EXEC sp_addrolemember N''db_owner'', N''' + 'administrador' + '''')
USE DOBLONES20
--GRANT CONTROL SERVER TO postgres;
EXEC sp_addsrvrolemember 'administrador', 'sysadmin';



EXEC ('USE master; ALTER LOGIN administrador WITH PASSWORD = ''administrador ''')		
ALTER LOGIN administrador with password = 'administrador'

use Doblones20
update Usuarios set NombreUsuario = 'administrador', Contrasena = 'administrador' where CodigoUsuario = 1


USE master; ALTER LOGIN administrador                    WITH PASSWORD = 'administrador'
SELECT suser_sname()