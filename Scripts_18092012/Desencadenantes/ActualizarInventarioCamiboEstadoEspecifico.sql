USE DOBLONES20
GO
DROP TRIGGER ActualizarInventarioCamiboEstadoEspecifico
GO

CREATE TRIGGER ActualizarInventarioCamiboEstadoEspecifico ON dbo.InventariosProductosEspecificos AFTER UPDATE
  AS
  BEGIN
	DECLARE @CodigoEstadoAnterior	CHAR(1),
			@CodigoProducto			CHAR(15),
			@NumeroAgencia			INT,
			@CodigoEstadoActual		CHAR(1),
			@CantidadCambiada		INT,
			@MENSAJE VARCHAR (8000)
	IF UPDATE (CodigoEstado)	BEGIN			
			
			--SELECT @CodigoEstadoActual FROM INSERTED		
			SELECT @CodigoEstadoAnterior = CodigoEstado, @CodigoProducto = CodigoProducto, @NumeroAgencia = NumeroAgencia
			FROM DELETED
			SELECT @CantidadCambiada = count(*) FROM DELETED
			--SET @MENSAJE = 'Codigo Anterior '+ @CodigoEstadoAnterior + 'NUMERO FILAS '+CAST(@CantidadCambiada AS CHAR(10))
			--RAISERROR (@MENSAJE , 16, 10);
			
			IF(@CodigoEstadoAnterior = 'R' )
			BEGIN								
				UPDATE dbo.InventariosProductos
					SET CantidadExistencia = CantidadExistencia + @CantidadCambiada
				WHERE CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia
			END
			IF(@CodigoEstadoAnterior = 'A' )
			BEGIN				
				UPDATE dbo.InventariosProductos
					SET CantidadExistencia = CantidadExistencia - @CantidadCambiada
				WHERE CodigoProducto = @CodigoProducto AND NumeroAgencia = @NumeroAgencia
			END

	END			
  END

	
