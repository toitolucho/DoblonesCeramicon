
USE DOBLONES20
GO

DROP PROCEDURE ListarCodigosProductosEspecificosComoArrayList
GO

CREATE PROCEDURE ListarCodigosProductosEspecificosComoArrayList
	@CodigoProducto					CHAR(15),
	@NumeroAgencia					INT,
	@Cantidad						INT,	
	@ListadoCodigosEspecificos		VARCHAR(8000) OUTPUT
AS
BEGIN	
	IF(@Cantidad >0)
	BEGIN
		SELECT TOP (@Cantidad) @ListadoCodigosEspecificos = COALESCE(@ListadoCodigosEspecificos + ', ', '') + IVE.CodigoProductoEspecifico
		FROM InventariosProductosEspecificos IVE
		WHERE CodigoProducto = @CodigoProducto
			AND NumeroAgencia = @NumeroAgencia
			AND (IVE.CodigoEstado = 'A')
	END
	ELSE
	BEGIN
		SELECT  @ListadoCodigosEspecificos = COALESCE(@ListadoCodigosEspecificos + ', ', '') + IVE.CodigoProductoEspecifico
		FROM InventariosProductosEspecificos IVE
		WHERE CodigoProducto = @CodigoProducto
			AND NumeroAgencia = @NumeroAgencia
			AND (IVE.CodigoEstado = 'A')
	END
END
GO


DECLARE @ListadoCodigosEspecificos		VARCHAR(8000)
EXEC ListarCodigosProductosEspecificosComoArrayList '100',1,5,@ListadoCodigosEspecificos OUTPUT
print @ListadoCodigosEspecificos
GO



DROP PROCEDURE ListarCodigosProductosEspecificosParaTransferenciaEnvio
GO

CREATE PROCEDURE ListarCodigosProductosEspecificosParaTransferenciaEnvio
	@CodigoProducto					CHAR(15),
	@NumeroAgencia					INT,
	@Cantidad						INT
AS
BEGIN	
	IF(@Cantidad >0)
	BEGIN
		SELECT TOP (@Cantidad) IVE.CodigoProductoEspecifico
		FROM InventariosProductosEspecificos IVE
		WHERE CodigoProducto = @CodigoProducto
			AND NumeroAgencia = @NumeroAgencia
			AND (IVE.CodigoEstado = 'A')
	END
	ELSE
	BEGIN
		SELECT IVE.CodigoProductoEspecifico
		FROM InventariosProductosEspecificos IVE
		WHERE CodigoProducto = @CodigoProducto
			AND NumeroAgencia = @NumeroAgencia
			AND (IVE.CodigoEstado = 'A')
	END
END
GO


--DECLARE @ListadoCodigosEspecificos		VARCHAR(8000)
--EXEC ListarCodigosProductosEspecificosComoArrayList '100',1,5,@ListadoCodigosEspecificos OUTPUT
--print @ListadoCodigosEspecificos
--GO
