USE DOBLONES20
GO

DROP PROCEDURE ListarVentasProductosEspecificosAgregadosParaVenta
GO

CREATE PROCEDURE ListarVentasProductosEspecificosAgregadosParaVenta
	@NumeroAgencia	INT,  -- Si es -1, para listar sin filtrado
	@NumeroVenta	INT
AS
BEGIN
	--Listamos todas las Ventas de Productos Especificos para una Determinada Agencia
	IF (@NumeroAgencia >0)
	BEGIN --'P'->Promoción ,'B'->Bonificación,'C'->Compensación,'O'->Obsequio
		SELECT P.NombreProducto AS [Nombre Producto], VPEA.CodigoProducto AS Codigo, VPEA.CodigoProductoEspecifico AS [Codigo Específico], CASE (VPEA.CodigoTipoAgregado) WHEN ('O')THEN 'OBSEQUIO' WHEN ('B') THEN 'BONIFICACION' WHEN ('P') THEN 'PROMOCION' WHEN ('C') THEN 'COMPENSACION' END AS [Tipo Agregado], VPEA.TiempoGarantiaPE AS [Tiempo Garantia], VPEA.FechaHoraVencimientoPE AS [Fecha Vencimiento],VPEA.PrecioUnitario AS [Precio Unitario]
		FROM VentasProductosEspecificosAgregados VPEA INNER JOIN Productos P ON P.CodigoProducto = VPEA.CodigoProducto		
		WHERE VPEA.NumeroAgencia = @NumeroAgencia
			AND VPEA.NumeroVentaProducto = @NumeroVenta
		ORDER BY VPEA.NumeroAgencia,VPEA.NumeroVentaProducto
	END
	--Listamos Absolutamente todas las Ventas de Productos Especificos Realizadas por todas las Agencias
	IF (@NumeroAgencia = -1)
	BEGIN
		SELECT P.NombreProducto AS [Nombre Producto], VPEA.CodigoProducto AS Codigo, VPEA.CodigoProductoEspecifico AS [Codigo Específico], CASE (VPEA.CodigoTipoAgregado) WHEN ('O')THEN 'OBSEQUIO' WHEN ('B') THEN 'BONIFICACION' WHEN ('P') THEN 'PROMOCION' WHEN ('C') THEN 'COMPENSACION' END AS [Tipo Agregado], VPEA.TiempoGarantiaPE AS [Tiempo Garantia], VPEA.FechaHoraVencimientoPE AS [Fecha Vencimiento],VPEA.PrecioUnitario AS [Precio Unitario]
		FROM VentasProductosEspecificosAgregados VPEA INNER JOIN Productos P ON P.CodigoProducto = VPEA.CodigoProducto
		ORDER BY VPEA.NumeroAgencia,VPEA.NumeroVentaProducto
	END
END

