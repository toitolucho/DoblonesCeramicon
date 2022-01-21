USE Doblones20
GO

DROP PROCEDURE ListarCodigosProductosEspecificos
GO


CREATE PROCEDURE ListarCodigosProductosEspecificos
	@NumeroAgencia				INT,
	@NumeroVentaProducto		INT,
	@CodigoProducto				CHAR(15),
	@CodigoTipoEnvioRecepcion	CHAR(1)
AS
BEGIN
	IF(@CodigoTipoEnvioRecepcion = 'E')
	BEGIN
		SELECT CodigoProductoEspecifico
		FROM InventariosProductosEspecificos
		WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
		AND CodigoEstado = 'A'
	END
	ELSE IF(@CodigoTipoEnvioRecepcion = 'R')
	BEGIN
		SELECT SAE.CodigoProductoEspecifico 
		FROM VentasProductosEspecificos SAE
		WHERE CodigoProductoEspecifico NOT IN(
			SELECT SADE.CodigoProductoEspecifico
			FROM VentasProductosDevolucionesEspecificos SADE
			INNER JOIN VentasProductosDevoluciones SAD
			ON SADE.NumeroAgencia = SAD.NumeroAgencia
			AND SADE.NumeroDevolucion = SAD.NumeroDevolucion
			WHERE SADE.CodigoProducto = @CodigoProducto
			AND SADE.NumeroAgencia = @NumeroAgencia
			AND SAD.CodigoEstadoDevolucion = 'F'
			AND SAD.NumeroVentaProducto = SAE.NumeroVentaProducto
		)
		AND SAE.NumeroAgencia = @NumeroAgencia
		AND SAE.NumeroVentaProducto = @NumeroVentaProducto
		AND SAE.CodigoProducto = @CodigoProducto
	END
END
GO
