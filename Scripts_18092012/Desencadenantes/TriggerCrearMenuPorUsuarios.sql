USE Doblones20
GO

IF OBJECT_ID ('TriggerCrearMenuPorUsuarios','TR') IS NOT NULL
   DROP TRIGGER TriggerCrearMenuPorUsuarios;
GO

CREATE TRIGGER TriggerCrearMenuPorUsuarios ON UsuariosAgenciasPermisosInterfaces
AFTER INSERT, UPDATE
AS
	DECLARE @CodigoUsuario	INT,
			@NumeroAgencia	INT,
			@CodigoInterface TINYINT,
			@SumaPermisos	TINYINT,
			@CodigoElementoMenu	TINYINT
			
	SELECT @CodigoUsuario = CodigoUsuario, @NumeroAgencia = NumeroAgencia, @CodigoInterface = CodigoInterface, @SumaPermisos = CAST(PermitirEditar AS TINYINT)+ CAST(PermitirEliminar AS TINYINT) + CAST(PermitirInsertar AS TINYINT) + CAST(PermitirNavegar AS TINYINT) + CAST(PermitirReportes AS TINYINT)
	FROM INSERTED
	
	SELECT @CodigoElementoMenu = CodigoElementoMenu 
		FROM MenuPrincipalNodosHojas
		WHERE CodigoInterface = @CodigoInterface
		
	IF(@SumaPermisos > 0) -- Por lo menos tiene un permiso para esa interface
	BEGIN		
		IF(@CodigoElementoMenu IS NOT NULL AND NOT EXISTS(SELECT * FROM UsuariosAgenciasMenuPrincipal WHERE CodigoUsuario = @CodigoUsuario AND NumeroAgencia = @NumeroAgencia AND CodigoElementoMenu = @CodigoElementoMenu))
			INSERT INTO UsuariosAgenciasMenuPrincipal (CodigoUsuario, NumeroAgencia, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra)
			VALUES (@CodigoUsuario, @NumeroAgencia, @CodigoElementoMenu, 1, 1, 0)		
	END
	IF(@SumaPermisos = 0)
	BEGIN
		IF(@CodigoElementoMenu IS NOT NULL AND EXISTS(SELECT * FROM UsuariosAgenciasMenuPrincipal WHERE CodigoUsuario = @CodigoUsuario AND NumeroAgencia = @NumeroAgencia AND CodigoElementoMenu = @CodigoElementoMenu))
			DELETE FROM UsuariosAgenciasMenuPrincipal
			WHERE CodigoUsuario = @CodigoUsuario AND NumeroAgencia = @NumeroAgencia AND CodigoElementoMenu = @CodigoElementoMenu
	END
		
	--IF @creditrating = 5
	--BEGIN
	--   RAISERROR ('This vendor''s credit rating is too low to accept new
	--	  purchase orders.', 16, 1)
	--ROLLBACK TRANSACTION

GO


--SELECT * FROM UsuariosAgenciasPermisosInterfaces

--UPDATE UsuariosAgenciasPermisosInterfaces
--SET PermitirNavegar = 0
--WHERE CodigoUsuario = 6 AND NumeroAgencia = 1 AND CodigoInterface = 20

--SELECT * FROM UsuariosAgenciasMenuPrincipal
----189 