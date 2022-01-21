USE DOBLONES20
GO

DROP PROCEDURE ListarVentasProductosEspecificosParaVenta
GO

CREATE PROCEDURE ListarVentasProductosEspecificosParaVenta
	@NumeroAgencia	INT,  -- Si es -1, para listar sin filtrado
	@NumeroVenta	INT
AS
BEGIN
	--Listamos todas las Ventas de Productos Especificos para una Determinada Agencia
	IF (@NumeroAgencia >0)
	BEGIN
		SELECT P.NombreProducto AS [Nombre Producto], VPE.CodigoProducto AS [Código], VPE.CodigoProductoEspecifico AS [Código Específico], VPE.TiempoGarantiaPE AS [Tiempo Garantía]
		FROM VentasProductosEspecificos VPE INNER JOIN Productos P ON P.CodigoProducto = VPE.CodigoProducto		
		WHERE VPE.NumeroAgencia = @NumeroAgencia
			AND VPE.NumeroVentaProducto = @NumeroVenta
		ORDER BY VPE.NumeroAgencia,VPE.NumeroVentaProducto
	END
	--Listamos Absolutamente todas las Ventas de Productos Especificos Realizadas por todas las Agencias
	IF (@NumeroAgencia = -1)
	BEGIN
		SELECT P.NombreProducto AS [Nombre Producto], VPE.CodigoProducto AS [Código], VPE.CodigoProductoEspecifico AS [Código Específico], VPE.TiempoGarantiaPE AS [Tiempo Garantía]
		FROM VentasProductosEspecificos VPE INNER JOIN Productos P ON P.CodigoProducto = VPE.CodigoProducto
		ORDER BY VPE.NumeroAgencia,VPE.NumeroVentaProducto
	END
END


 --        .----.
 --      _.'__    `.
 --  .--(#)(##)---/#
 --.' @          /###
 --:         ,   #####
 -- `-..__.-' _.-###/
 --       `;_:    `"'
 --     .'"""""`.
 --    /,Luis  
 --   //  Antonio       
 --   `-._______.-'
 --   ___`. | .'___ 
 --  (______|______)
