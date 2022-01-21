USE Doblones20
GO


DROP TRIGGER SistemaGruposUsuariosAIUD
GO

CREATE TRIGGER SistemaGruposUsuariosAIUD
ON SistemaGruposUsuarios
INSTEAD OF INSERT, UPDATE, DELETE
AS 

DELETE 
FROM UsuariosAgenciasMenuPrincipal
FROM UsuariosAgenciasMenuPrincipal UAMP
JOIN deleted d ON
d.CodigoUsuario = UAMP.CodigoUsuario
AND d.NumeroAgencia = UAMP.NumeroAgencia
AND d.CodigoGrupoSistema = UAMP.CodigoGrupoSistema

DELETE 
FROM UsuariosAgenciasPermisosInterfaces
FROM UsuariosAgenciasPermisosInterfaces UAPI 
JOIN deleted d ON
d.CodigoUsuario = UAPI.CodigoUsuario
AND d.NumeroAgencia = UAPI.NumeroAgencia
AND d.CodigoGrupoSistema = UAPI.CodigoGrupoSistema

DELETE
FROM SistemaGruposUsuarios
FROM SistemaGruposUsuarios SGU
JOIN deleted d ON
d.CodigoUsuario = SGU.CodigoUsuario
AND d.NumeroAgencia = SGU.NumeroAgencia
AND d.CodigoGrupoSistema = SGU.CodigoGrupoSistema

INSERT INTO SistemaGruposUsuarios(CodigoUsuario, NumeroAgencia, CodigoGrupoSistema)
SELECT i.CodigoUsuario, i.NumeroAgencia, i.CodigoGrupoSistema
FROM inserted i

INSERT INTO UsuariosAgenciasPermisosInterfaces(CodigoUsuario, NumeroAgencia, CodigoGrupoSistema, CodigoInterface, PermitirInsertar, PermitirEditar, PermitirEliminar, PermitirNavegar, PermitirReportes)
SELECT i.CodigoUsuario, i.NumeroAgencia, i.COdigoGrupoSistema, SGPI.CodigoInterface, SGPI.PermitirInsertar, SGPI.PermitirEditar, SGPI.PermitirEliminar, SGPI.PermitirNavegar, SGPI.PermitirReportes
FROM inserted i
JOIN SistemaGruposPermisosInterfaces SGPI ON
SGPI.CodigoGrupoSistema = i.CodigoGrupoSistema

INSERT INTO UsuariosAgenciasMenuPrincipal(CodigoUsuario, NumeroAgencia, CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra)
SELECT i.CodigoUsuario, i.NumeroAgencia, i.CodigoGrupoSistema, SGMP.CodigoElementoMenu, SGMP.Visible, SGMP.Activo, SGMP.IncluirBotonBarra
FROM inserted i
JOIN SistemaGruposMenuPrincipal SGMP ON
SGMP.CodigoGrupoSistema = i.CodigoGrupoSistema

GO