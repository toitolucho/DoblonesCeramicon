USE Doblones20
GO

IF OBJECT_ID ('TriggerCrearMenuPorDefectoPorUsuarios','TR') IS NOT NULL
   DROP TRIGGER TriggerCrearMenuPorDefectoPorUsuarios;
GO

CREATE TRIGGER TriggerCrearMenuPorDefectoPorUsuarios ON Usuarios
AFTER INSERT
AS
	DECLARE @CodigoUsuario	INT,
			@NumeroAgencia	INT,
			@CodigoInterface TINYINT,			
			@CodigoElementoMenu	TINYINT
			
	SELECT @CodigoUsuario = CodigoUsuario
	FROM INSERTED
	
	SELECT @NumeroAgencia = NumeroAgencia
	FROM SistemaConfiguracion
	
	DECLARE CursorCreadorMenuPorDefecto CURSOR FOR
	SELECT CodigoElementoMenu FROM MenuPrincipalNodosPadre_Separator
	OPEN CursorCreadorMenuPorDefecto;
			FETCH NEXT FROM CursorCreadorMenuPorDefecto
			INTO @CodigoElementoMenu
			WHILE @@FETCH_STATUS = 0
			BEGIN 				  				
				INSERT INTO UsuariosAgenciasMenuPrincipal (CodigoUsuario, NumeroAgencia, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra)
				VALUES (@CodigoUsuario, @NumeroAgencia, @CodigoElementoMenu, 1, 1, 0)
			FETCH NEXT FROM CursorCreadorMenuPorDefecto
			INTO @CodigoElementoMenu
			END;	
			
	 
	CLOSE CursorCreadorMenuPorDefecto
	DEALLOCATE CursorCreadorMenuPorDefecto

GO