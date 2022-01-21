USE DOBLONES20
GO

DROP PROCEDURE ActualizarInventarioProductosReemplazo
GO

CREATE PROCEDURE ActualizarInventarioProductosReemplazo
	@NumeroAgencia			INT,
	@NumeroVentaReemplazo	INT
AS
BEGIN
DECLARE 
	@CodigoProducto				CHAR(15),
	@CantidadReemplazo				INT,
	@CodigoProductoEspecifico	CHAR(30)
	
	-- Detalle de reemplazo Productos
	SET ROWCOUNT 0
	IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'#mytemp') AND OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		DROP TABLE #mytemp
	END

	SELECT CantidadDevuelta, CodigoProducto INTO #mytemp FROM VentasProductosReemplazoDetalle
	WHERE (NumeroAgencia = @NumeroAgencia AND NumeroReemplazo = @NumeroVentaReemplazo)

	SET ROWCOUNT 1
	SELECT @CodigoProducto = CodigoProducto, @CantidadReemplazo = CantidadDevuelta FROM #mytemp

	WHILE @@rowcount <> 0
	BEGIN
		--IF(NOT EXISTS(SELECT * FROM VentasProductosEspecificos WHERE NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroVentaProducto AND CodigoProducto = @CodigoProducto))
		--BEGIN -- Solo actualizamos inventarios de los productos q NO SON ESPECIFICOS,
			-- Debido que mas abajo, existe un un segmento de codigo que se encarga especificamente de realizar la actualizaciçon de los productos ESPECIFICOS
			UPDATE dbo.InventariosProductos
			SET CantidadExistencia = CantidadExistencia - @CantidadReemplazo
			WHERE NumeroAgencia = @NumeroAgencia and CodigoProducto = @CodigoProducto
		--END;
		
		DELETE #mytemp WHERE @CodigoProducto = CodigoProducto
		SET ROWCOUNT 1
		SELECT @CodigoProducto = CodigoProducto, @CantidadReemplazo = CantidadDevuelta FROM #mytemp
	END
	SET ROWCOUNT 0
	IF EXISTS( SELECT * FROM dbo.sysobjects where id = object_id(N'#mytemp') AND OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		DROP TABLE #mytemp
	END
	
		
	
	--Reemplazo Productos Especificos
	SELECT CodigoProductoEspecifico, CodigoProducto INTO #mytemp3
	FROM VentasProductosReemplazoEspecificos
	WHERE (NumeroAgencia = @NumeroAgencia AND NumeroReemplazo = @NumeroVentaReemplazo)
	ORDER BY CodigoProducto
	

	SET ROWCOUNT 1
	SELECT @CodigoProductoEspecifico = CodigoProductoEspecifico, @CodigoProducto = CodigoProducto FROM #mytemp3

	WHILE @@rowcount <> 0
	BEGIN
		UPDATE dbo.InventariosProductosEspecificos
			SET CodigoEstado = 'V'
		WHERE NumeroAgencia = @NumeroAgencia 
		AND CodigoProducto = @CodigoProducto AND (CodigoProductoEspecifico = @CodigoProductoEspecifico)
		DELETE #mytemp3 WHERE @CodigoProductoEspecifico = CodigoProductoEspecifico
		SET ROWCOUNT 1
		SELECT @CodigoProductoEspecifico = CodigoProductoEspecifico, @CodigoProducto = CodigoProducto FROM #mytemp3
	END
	SET ROWCOUNT 0
	IF EXISTS( SELECT * FROM dbo.sysobjects where id = object_id(N'#mytemp3') AND OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		DROP TABLE #mytemp3
	END	
	
	
END

