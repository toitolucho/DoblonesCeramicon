USE Doblones20
GO

IF OBJECT_ID ('TActualizarPrecioCompraRealInventariosCompras','TR') IS NOT NULL
   DROP TRIGGER TActualizarPrecioCompraRealInventariosCompras;
GO

CREATE TRIGGER TActualizarPrecioCompraRealInventariosCompras ON ComprasProductos
AFTER UPDATE
AS
	DECLARE @CodigoEstadoCompra		CHAR(1),
			@NumeroAgencia			INT,
			@NumeroCompraProducto	INT		
	
			
	SELECT @CodigoEstadoCompra = CodigoEstadoCompra, @NumeroAgencia = NumeroAgencia, @NumeroCompraProducto = NumeroCompraProducto
	FROM INSERTED
	
	IF(@CodigoEstadoCompra IN ('F','X'))
	BEGIN
		UPDATE InventariosProductos
			SET PrecioUnitarioCompraSinGastos = CPD.PrecioUnitarioCompra
		FROM ComprasProductos CP
		INNER JOIN ComprasProductosDetalle CPD
		ON CP.NumeroAgencia = CPD.NumeroAgencia
		AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
		WHERE CP.NumeroAgencia = @NumeroAgencia
		AND CP.NumeroCompraProducto = @NumeroCompraProducto
		AND InventariosProductos.CodigoProducto = CPD.CodigoProducto
		AND InventariosProductos.NumeroAgencia = CPD.NumeroAgencia
		AND CPD.CodigoProducto IN (
			SELECT DISTINCT CPDE.CodigoProducto
			FROM ComprasProductosDetalleEntrega CPDE
			WHERE CPDE.NumeroAgencia = @NumeroAgencia
			AND CPDE.NumeroCompraProducto = @NumeroCompraProducto
		)
		
		IF(@CodigoEstadoCompra = 'X')
		BEGIN
			DECLARE @NumeroCuentaPorCobrar	INT,
					@MontoCobroCompra		DECIMAL(10,2),
					@MontoCuentaPorCobrar	DECIMAL(10,2)
					
			EXEC dbo.ObtenerUltimoIndiceTabla 'CuentasPorCobrar', @NumeroCuentaPorCobrar OUTPUT
			
			
			IF(@NumeroCuentaPorCobrar IS NOT NULL)
			BEGIN
				SELECT @MontoCuentaPorCobrar = Monto
				FROM dbo.CuentasPorCobrar
				WHERE NumeroAgencia = @NumeroAgencia
				AND NumeroCuentaPorCobrar = @NumeroCuentaPorCobrar
				
				SELECT @MontoCobroCompra = (
				SELECT CP.MontoTotalCompra
				FROM ComprasProductos CP
				WHERE CP.NumeroAgencia = @NumeroAgencia
				AND CP.NumeroCompraProducto = @NumeroCompraProducto)
				-
				(
				SELECT SUM(CPDCR.CantidadRealRecepcionada * PrecioUnitarioCompra)
				FROM ComprasProductosDetalle CPD
				INNER JOIN
				(
					SELECT CPDE.NumeroAgencia, NumeroCompraProducto, CodigoProducto, SUM(CPDE.CantidadEntregada) AS CantidadRealRecepcionada
					FROM ComprasProductosDetalleEntrega CPDE
					GROUP BY CPDE.NumeroAgencia, NumeroCompraProducto, CodigoProducto
				) CPDCR
				ON CPD.NumeroAgencia = CPDCR.NumeroAgencia
				AND CPD.NumeroCompraProducto = CPDCR.NumeroCompraProducto
				AND CPD.CodigoProducto = CPDCR.CodigoProducto
				--WHERE CPD.CantidadCompra <> CPDCR.CantidadRealRecepcionada
				WHERE CPD.NumeroAgencia = @NumeroAgencia
				AND CPD.NumeroCompraProducto = @NumeroCompraProducto
				)
				
				IF(@MontoCobroCompra = @MontoCuentaPorCobrar)
					UPDATE ComprasProductos 
						SET NumeroCuentaPorCobrar = @NumeroCuentaPorCobrar
					WHERE NumeroAgencia = @NumeroAgencia
					AND NumeroCompraProducto = @NumeroCompraProducto
			END
			
			
		END
	END
GO
