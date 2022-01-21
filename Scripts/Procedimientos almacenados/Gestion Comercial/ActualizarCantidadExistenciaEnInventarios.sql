USE DOBLONES20
GO

DROP PROCEDURE ActualizarCantidadExistenciaEnInventarios
GO


CREATE PROCEDURE ActualizarCantidadExistenciaEnInventarios
	@NumeroAgencia	INT,
	@CodigoProducto	CHAR(15),
	@Cantidad		INT,
	@Incrementar	BIT
AS
BEGIN
	IF (@Incrementar = 1)
	UPDATE dbo.InventariosProductos
		SET CantidadExistencia = CantidadExistencia + @Cantidad
	WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
	ELSE
	UPDATE dbo.InventariosProductos
		SET CantidadExistencia = CantidadExistencia - @Cantidad
	WHERE NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto
END
