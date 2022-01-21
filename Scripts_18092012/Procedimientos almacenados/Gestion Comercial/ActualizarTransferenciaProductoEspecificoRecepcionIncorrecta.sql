USE Doblones20

IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ActualizarTransferenciaProductoEspecificoRecepcionIncorrecta') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ActualizarTransferenciaProductoEspecificoRecepcionIncorrecta
	END
GO	
CREATE PROCEDURE ActualizarTransferenciaProductoEspecificoRecepcionIncorrecta
	@NumeroAgencia					INT,
	@NumeroTransferenciaProducto	INT,	
	@FechaHoraRecepcion				DATETIME	
AS
BEGIN
	--UPDATE 	dbo.TransferenciasProductosEspecificos
	--SET						
	--	Entregado			= @Entregado,
	--	FechaHoraEnvio		= @FechaHoraEnvio,
	--	FechaHoraRecepcion	= @FechaHoraRecepcion
	--WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 			
	--		AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
	--		AND (CodigoProducto = @CodigoProducto)
	--		AND (CodigoProductoEspecifico = @CodigoProductoEspecifico)
	
	BEGIN TRANSACTION	
		SET @NumeroAgencia = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)
		UPDATE InventariosProductosEspecificos
			SET CodigoEstado = TPE.CodigoEstadoRecepcion
		FROM TransferenciasProductosEspecificos TPE
		WHERE TPE.NumeroAgenciaEmisora = @NumeroAgencia
		AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
		AND TPE.CodigoProducto = InventariosProductosEspecificos.CodigoProducto 
		AND TPE.CodigoProductoEspecifico = InventariosProductosEspecificos.CodigoProductoEspecifico
		AND TPE.FechaHoraRecepcion = @FechaHoraRecepcion
		
		UPDATE InventariosProductos
			SET CantidadExistencia -= CantidadErronea
		FROM 
		(
			SELECT TPE.CodigoProducto, COUNT(TPE.CodigoProducto) AS CantidadErronea
			FROM TransferenciasProductosEspecificos TPE
			WHERE TPE.NumeroAgenciaEmisora = @NumeroAgencia
			AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto			
			AND TPE.FechaHoraRecepcion = @FechaHoraRecepcion
			AND TPE.CodigoEstadoRecepcion IN ('R','B')
			GROUP BY TPE.NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto
		) TPDE
		WHERE TPDE.CodigoProducto = InventariosProductos.CodigoProducto
				
		IF(@@ERROR <> 0)
		BEGIN
			RAISERROR('No se Puedo Actualizar la Recepción de Productos Especificos',1,16)
			ROLLBACK TRANSACTION
		END
		
	COMMIT TRANSACTION
END
GO
---([CodigoEstadoRecepcion]='A' OR [CodigoEstadoRecepcion]='R' OR [CodigoEstadoRecepcion]='B' )
--SELECT * FROM TransferenciasProductosEspecificos

--SELECT * FROM InventariosProductosEspecificos
--WHERE CodigoFormaAdquisicion = 'T'