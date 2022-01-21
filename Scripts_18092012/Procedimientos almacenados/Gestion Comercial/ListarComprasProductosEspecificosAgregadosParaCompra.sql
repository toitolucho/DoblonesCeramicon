USE DOBLONES20
GO

DROP PROCEDURE ListarComprasProductosEspecificosAgregadosParaCompra
GO

CREATE PROCEDURE ListarComprasProductosEspecificosAgregadosParaCompra
	@NumeroAgencia	INT,  -- Si es -1, para listar sin filtrado
	@NumeroCompra	INT
AS
BEGIN
	--Listamos todas las Ventas de Productos Especificos para una Determinada Agencia
	IF (@NumeroAgencia >0)
	BEGIN --'P'->Promoción ,'B'->Bonificación,'C'->Compensación,'O'->Obsequio
		SELECT P.NombreProducto AS [Nombre Producto], CPEA.CodigoProducto AS Codigo, CPEA.CodigoProductoEspecifico AS [Codigo Específico], CASE (CPEA.CodigoTipoAgregado) WHEN ('O')THEN 'OBSEQUIO' WHEN ('B') THEN 'BONIFICACION' WHEN ('P') THEN 'PROMOCION' WHEN ('C') THEN 'COMPENSACION' END AS [Tipo Agregado], CPEA.TiempoGarantiaPE AS [Tiempo Garantia], CPEA.FechaHoraVencimientoPE AS [Fecha Vencimiento],CPEA.PrecioUnitario AS [Precio Unitario], CASE (CPEA.CargarAInventario) WHEN 1 THEN 'Sí' ELSE 'No' END AS [Inventariado?]
		FROM ComprasProductosEspecificosAgregados CPEA INNER JOIN Productos P ON P.CodigoProducto = CPEA.CodigoProducto		
		WHERE CPEA.NumeroAgencia = @NumeroAgencia
			AND CPEA.NumeroCompraProducto = @NumeroCompra
		ORDER BY CPEA.NumeroAgencia,CPEA.NumeroCompraProducto
	END
	--Listamos Absolutamente todas las Ventas de Productos Especificos Realizadas por todas las Agencias
	IF (@NumeroAgencia = -1)
	BEGIN
		SELECT P.NombreProducto AS [Nombre Producto], CPEA.CodigoProducto AS Codigo, CPEA.CodigoProductoEspecifico AS [Codigo Específico], CASE (CPEA.CodigoTipoAgregado) WHEN ('O')THEN 'OBSEQUIO' WHEN ('B') THEN 'BONIFICACION' WHEN ('P') THEN 'PROMOCION' WHEN ('C') THEN 'COMPENSACION' END AS [Tipo Agregado], CPEA.TiempoGarantiaPE AS [Tiempo Garantia], CPEA.FechaHoraVencimientoPE AS [Fecha Vencimiento],CPEA.PrecioUnitario AS [Precio Unitario], CASE (CPEA.CargarAInventario) WHEN 1 THEN 'True' ELSE 'False' END AS [Inventariado?]
		FROM ComprasProductosEspecificosAgregados CPEA INNER JOIN Productos P ON P.CodigoProducto = CPEA.CodigoProducto		
		ORDER BY CPEA.NumeroAgencia,CPEA.NumeroCompraProducto
	END
END

