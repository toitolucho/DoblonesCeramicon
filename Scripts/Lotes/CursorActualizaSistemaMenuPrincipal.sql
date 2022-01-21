USE Doblones20
GO

DECLARE cursorActualizarSistemaMenuPrincipal CURSOR FOR
	select a.CodigoElementoMenu, SI.CodigoInterface from SistemaMenuPrincipal a left join  SistemaMenuPrincipal b
	on a.CodigoElementoMenu = b.CodigoElementoMenuPadre left JOIN SistemaInterfaces SI ON SUBSTRING(a.NombreElementoMenu,5,200) LIKE  '%'+RTRIM(SUBSTRING(SI.nombreInterface,2,200))+'%'
	where b.CodigoElementoMenu is null
	and a.CodigoTipoElementoMenu = 'M'	
	DECLARE @CodigoElementoMenu TINYINT,
			@CodigoInterface TINYINT
	OPEN cursorActualizarSistemaMenuPrincipal;
			FETCH NEXT FROM cursorActualizarSistemaMenuPrincipal
			INTO @CodigoElementoMenu,@CodigoInterface		
			WHILE @@FETCH_STATUS = 0
			BEGIN 				  
				print 'CodigoElementoMenu ' + cast(@CodigoElementoMenu as char(10)) + '   CodigoInterface '+ cast(@CodigoInterface as char(10))
				--IF(@CodigoInterface IS NOT NULL)
				--BEGIN
					UPDATE SistemaMenuPrincipal SET CodigoInterface = @CodigoInterface
					WHERE CodigoElementoMenu = @CodigoElementoMenu				
				--END				
				FETCH NEXT FROM cursorActualizarSistemaMenuPrincipal
				INTO @CodigoElementoMenu,@CodigoInterface	
			END;	
			
	 
	CLOSE cursorActualizarSistemaMenuPrincipal;
	DEALLOCATE cursorActualizarSistemaMenuPrincipal;
	
GO