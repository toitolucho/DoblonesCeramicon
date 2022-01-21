
USE DOBLONES20
GO

DROP PROCEDURE CambiarEstadoDisponbilidadProductoEspecifico
GO


CREATE PROCEDURE CambiarEstadoDisponbilidadProductoEspecifico
	@CantidadVendida			INT,
	@NumeroAgencia				INT,
	@CodigoProducto				CHAR(15),
	@ListadoCodigosEspecificos	NVARCHAR(4000) OUTPUT --Contiene Una Cadena con los codigosProductos Especificos separadas por comas siempre 
												-- y cuando se haya realizado correctamente la transacción, caso contrario retorna
												-- una cadena vacia!!
AS
BEGIN
	DECLARE
	@CantidadExistente	INT	

	SELECT @CantidadExistente = COUNT(*) 
	FROM dbo.InventariosProductosEspecificos IPE
	WHERE (IPE.NumeroAgencia = @NumeroAgencia AND IPE.CodigoProducto = @CodigoProducto)
			AND (IPE.CodigoEstado = 'A')
	IF(@CantidadExistente > =  @CantidadVendida) 
	BEGIN
		SELECT TOP(@CantidadVendida) @ListadoCodigosEspecificos = COALESCE(@ListadoCodigosEspecificos + ', ', '') + CodigoProductoEspecifico
		FROM dbo.InventariosProductosEspecificos
		WHERE (NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto)
			AND (CodigoEstado = 'A')

		UPDATE TOP(@CantidadVendida) dbo.InventariosProductosEspecificos 
		SET CodigoEstado = 'V'
		WHERE (NumeroAgencia = @NumeroAgencia AND CodigoProducto = @CodigoProducto)
			AND (CodigoEstado = 'A')
		
	END
	ELSE
		SET @ListadoCodigosEspecificos = ' '
END

--declare @listado varchar(8000)
--exec CambiarEstadoDisponbilidadProductoEspecifico  1,1,'100',@listado output
--print @listado

