USE Doblones20
GO

IF OBJECT_ID ('ActualizarInventarioPreciosVenta','TR') IS NOT NULL
   DROP TRIGGER ActualizarInventarioPreciosVenta;
GO

CREATE TRIGGER ActualizarInventarioPreciosVenta ON InventariosProductos
AFTER UPDATE, INSERT
AS
	DECLARE @CodigoProducto				CHAR(15),
			@NumeroAgencia				INT,
			@PrecioUnitarioCompra		DECIMAL(10,2),
			@PrecioUnitarioCompra2		DECIMAL(10,2),
			@PorcentajeImpuestoIVA		DECIMAL(10,2),
			@PorcentajeUtilidad1		DECIMAL(5,2),
			@PorcentajeUtilidad2		DECIMAL(5,2),
			@PorcentajeUtilidad3		DECIMAL(5,2),
			@CantidadExistencia			INT,
			@CantidadExistencia2		INT,
			@CantidadHabilitadosPE		INT,
			@EsProductoEspecifico		BIT,
			@TiempoGarantiaProducto1	INT,
			@TiempoGarantiaProducto2	INT
			
			
	SELECT @CodigoProducto = CodigoProducto, @NumeroAgencia = NumeroAgencia, @PrecioUnitarioCompra = PrecioUnitarioCompra,
		   @PorcentajeUtilidad1 = PorcentajeUtilidad1, @PorcentajeUtilidad2 = PorcentajeUtilidad2, @PorcentajeUtilidad3 = PorcentajeUtilidad3,
		   @CantidadExistencia = CantidadExistencia, @EsProductoEspecifico = EsProductoEspecifico,
		   @TiempoGarantiaProducto1 = TiempoGarantiaProducto
	FROM INSERTED	
	
	SELECT @PrecioUnitarioCompra2	= PrecioUnitarioCompra,
		   @CantidadExistencia2		= CantidadExistencia,
		   @TiempoGarantiaProducto2 = TiempoGarantiaProducto
	FROM DELETED (NOLOCK) 
	WHERE NumeroAgencia = @NumeroAgencia and CodigoProducto = @CodigoProducto
	
	IF(@TiempoGarantiaProducto2 <> @TiempoGarantiaProducto1
		AND dbo.EsProductoEspecifico(@NumeroAgencia,@CodigoProducto) = 1)
	BEGIN
		UPDATE InventariosProductosEspecificos
			SET TiempoGarantiaPECompra = @TiempoGarantiaProducto1
		WHERE NumeroAgencia = @NumeroAgencia
		AND CodigoProducto = @CodigoProducto
		AND CodigoEstado = 'A'	
	END
	
	--IF(@PrecioUnitarioCompra2 <> @PrecioUnitarioCompra)	
	--BEGIN
	
		--SELECT TOP(1) @PorcentajeImpuestoIVA = PorcentajeImpuesto FROM PCsConfiguraciones
		--WHERE NumeroAgencia = @NumeroAgencia	
		
		--UPDATE InventariosProductos
		--SET PrecioUnitarioVenta1 = ROUND(@PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad1 /100 , 2),
		--	PrecioUnitarioVenta2 = ROUND(@PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad2 /100 , 2),
		--	PrecioUnitarioVenta3 = ROUND(@PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad3 /100 , 2),
		--	PrecioUnitarioVenta4 = ROUND(@PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad1 /100  + (@PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad1 /100) * @PorcentajeImpuestoIVA /100 , 2),
		--	PrecioUnitarioVenta5 = ROUND(@PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad2 /100  + (@PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad2 /100) * @PorcentajeImpuestoIVA /100 , 2),
		--	PrecioUnitarioVenta6 = ROUND(@PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad3 /100  + (@PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad3 /100) * @PorcentajeImpuestoIVA /100 , 2)			
		----SET PrecioUnitarioVenta1 = @PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad1 /100,
		----	PrecioUnitarioVenta2 = @PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad2 /100,
		----	PrecioUnitarioVenta3 = @PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad3 /100,
		----	PrecioUnitarioVenta4 = @PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad1 /100  + (@PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad1 /100) * @PorcentajeImpuestoIVA /100,
		----	PrecioUnitarioVenta5 = @PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad2 /100  + (@PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad2 /100) * @PorcentajeImpuestoIVA /100,
		----	PrecioUnitarioVenta6 = @PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad3 /100  + (@PrecioUnitarioCompra + @PrecioUnitarioCompra * @PorcentajeUtilidad3 /100) * @PorcentajeImpuestoIVA /100 
		--WHERE NumeroAgencia = @NumeroAgencia and CodigoProducto = @CodigoProducto
	--END
	
	IF(@EsProductoEspecifico = 1 AND @CantidadExistencia2 <> @CantidadExistencia)
	BEGIN
		SELECT @CantidadHabilitadosPE = COUNT(*)
		FROM InventariosProductosEspecificos 
		WHERE NumeroAgencia = @NumeroAgencia
		AND CodigoProducto = @CodigoProducto
		AND CodigoEstado = 'A'
		
		IF((@CantidadExistencia <> @CantidadHabilitadosPE) or (@CantidadExistencia = 0 AND @CantidadHabilitadosPE = 0))
			UPDATE InventariosProductos
			SET	ProductoEspecificoInventariado = 0
			WHERE NumeroAgencia = @NumeroAgencia and CodigoProducto = @CodigoProducto
		ELSE
			UPDATE InventariosProductos
			SET	ProductoEspecificoInventariado = 1
			WHERE NumeroAgencia = @NumeroAgencia and CodigoProducto = @CodigoProducto
					
	END
	
GO

--SELECT ROUND(43.4354,2) 


--select CodigoProducto, PrecioUnitarioCompra, PrecioUnitarioVenta1,PrecioUnitarioVenta2, PrecioUnitarioVenta3, PrecioUnitarioVenta4 ,PrecioUnitarioVenta5 ,PrecioUnitarioVenta6
--from InventariosProductos
--where CodigoProducto = 'CA-100         '

--update InventariosProductos
--set PrecioUnitarioCompra = 15
--where CodigoProducto = 'CA-100         '

