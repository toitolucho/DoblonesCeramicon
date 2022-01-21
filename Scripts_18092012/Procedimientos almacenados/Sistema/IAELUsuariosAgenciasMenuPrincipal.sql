USE DOBLONES20
GO

DROP PROCEDURE InsertarUsuarioAgenciaMenuPrincipal
GO
CREATE PROCEDURE InsertarUsuarioAgenciaMenuPrincipal
@CodigoUsuario			INT,
@NumeroAgencia			INT, 
@CodigoGrupoSistema		TINYINT,
@CodigoElementoMenu		INT,
@Visible				BIT,
@Activo					BIT,
@IncluirBotonBarra		BIT
AS
BEGIN
	INSERT INTO dbo.UsuariosAgenciasMenuPrincipal(CodigoUsuario, NumeroAgencia, CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra)								
	VALUES (@CodigoUsuario, @NumeroAgencia, @CodigoGrupoSistema, @CodigoElementoMenu, @Visible, @Activo, @IncluirBotonBarra)
END
GO

DROP PROCEDURE ActualizarUsuarioAgenciaMenuPrincipal
GO

CREATE PROCEDURE ActualizarUsuarioAgenciaMenuPrincipal
@CodigoUsuario			INT,
@NumeroAgencia			INT, 
@CodigoGrupoSistema		TINYINT,
@CodigoElementoMenu		INT,
@Visible				BIT,
@Activo					BIT,
@IncluirBotonBarra		BIT
AS
BEGIN
	UPDATE 	dbo.UsuariosAgenciasMenuPrincipal
	SET			
		Visible					= @Visible,
		Activo					= @Activo,
		IncluirBotonBarra		= @IncluirBotonBarra		
	WHERE (CodigoUsuario = @CodigoUsuario) AND (NumeroAgencia = @NumeroAgencia) AND (CodigoGrupoSistema = @CodigoGrupoSistema) 
	AND	(CodigoElementoMenu = @CodigoElementoMenu)
END
GO

DROP PROCEDURE EliminarUsuarioAgenciaMenuPrincipal
GO
CREATE PROCEDURE EliminarUsuarioAgenciaMenuPrincipal
@CodigoUsuario			INT,
@NumeroAgencia			INT, 
@CodigoGrupoSistema		TINYINT,
@CodigoElementoMenu		INT
AS
BEGIN
	DELETE 
	FROM dbo.UsuariosAgenciasMenuPrincipal
	WHERE (CodigoUsuario = @CodigoUsuario) AND (NumeroAgencia = @NumeroAgencia) AND (CodigoGrupoSistema = @CodigoGrupoSistema) 
	AND	(CodigoElementoMenu = @CodigoElementoMenu)
END
GO

DROP PROCEDURE ListarUsuariosAgenciasMenuPrincipal
GO
CREATE PROCEDURE ListarUsuariosAgenciasMenuPrincipal
AS
BEGIN
	SELECT CodigoUsuario, NumeroAgencia, CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra
	FROM dbo.UsuariosAgenciasMenuPrincipal
	ORDER BY CodigoUsuario, NumeroAgencia, CodigoGrupoSistema, CodigoElementoMenu
END
GO

DROP PROCEDURE ObtenerUsuarioAgenciaMenuPrincipal
GO
CREATE PROCEDURE ObtenerUsuarioAgenciaMenuPrincipal
@CodigoUsuario			INT,
@NumeroAgencia			INT, 
@CodigoGrupoSistema		TINYINT,
@CodigoElementoMenu		INT
AS
BEGIN
	SELECT CodigoUsuario, NumeroAgencia, CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra
	FROM dbo.UsuariosAgenciasMenuPrincipal
	WHERE (CodigoUsuario = @CodigoUsuario) AND (NumeroAgencia = @NumeroAgencia) AND (CodigoGrupoSistema = @CodigoGrupoSistema) 
	AND	(CodigoElementoMenu = @CodigoElementoMenu)
END
GO
