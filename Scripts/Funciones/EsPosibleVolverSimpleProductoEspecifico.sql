USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.EsPosibleVolverSimpleProductoEspecifico', N'FN') IS NOT NULL
    DROP FUNCTION dbo.EsPosibleVolverSimpleProductoEspecifico; 
GO

CREATE FUNCTION dbo.EsPosibleVolverSimpleProductoEspecifico ( @NumeroAgencia INT, @CodigoProducto CHAR(15))
RETURNS BIT
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @EsPosible		BIT
	
	IF(EXISTS(	SELECT * 
				FROM InventariosProductos
				WHERE NumeroAgencia = @NumeroAgencia
				AND CodigoProducto = @CodigoProducto
				AND ProductoEspecificoInventariado = 1))
	BEGIN-- Si Existe su Kardex de codigos Especifos, no es posible cambiar su estado del PE
		SET @EsPosible = 0
	END
	ELSE -- No se Encuentra Inventariado, pero existe la posibilidaD de que ya existiesen Codigos Especificos,
		 -- Registrados, se Debe serciorar es paso mas
	BEGIN
		IF(EXISTS(	SELECT * 
					FROM dbo.InventariosProductosEspecificos
					WHERE CodigoEstado <> 'B'
					AND NumeroAgencia = @NumeroAgencia
					AND CodigoProducto = @CodigoProducto))
			SET @EsPosible = 0
		ELSE
			SET @EsPosible = 1
	END

   	RETURN(@EsPosible)
END
GO

--select dbo.EsPosibleVolverSimpleProductoEspecifico(1,'001-PRO-000012') AS DATO
--select * from InventariosProductos
--where CodigoProducto IN ('1','10','100')


--select * from InventariosProductosEspecificos
--where CodigoProducto = '1'


--update InventariosProductosEspecificos set CodigoEstado = 'A'

--update InventariosProductos
--set CantidadExistencia = 2
--where CodigoProducto = '1'
