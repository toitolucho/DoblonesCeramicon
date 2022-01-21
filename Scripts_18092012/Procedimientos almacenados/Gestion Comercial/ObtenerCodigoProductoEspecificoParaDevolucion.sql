USE Doblones20
GO

DROP PROCEDURE ObtenerCodigoProductoEspecificoParaDevolucion
GO

CREATE PROCEDURE ObtenerCodigoProductoEspecificoParaDevolucion
	@NumeroAgencia		INT,
	@NumeroTransaccion	INT,
	@TipoTransaccion	CHAR(1),
	@CodigoProducto		CHAR(15)
AS
BEGIN
	IF(@TipoTransaccion ='C') --PARA LAS COMPRAS DE PRODUCTO ESPECIFICOS
	BEGIN
		SELECT CPE.CodigoProductoEspecifico, CPD.PrecioUnitarioCompra AS PrecioDevolucion, CAST (0 AS BIT) AS Devolver
		FROM ComprasProductosEspecificos CPE 
		INNER JOIN ComprasProductosDetalle CPD 
		ON CPE.NumeroAgencia = CPD.NumeroAgencia 
		AND CPE.NumeroCompraProducto = CPD.NumeroCompraProducto 
		AND CPE.CodigoProducto = CPD.CodigoProducto
		INNER JOIN InventariosProductosEspecificos IPE
		ON CPE.CodigoProducto = IPE.CodigoProducto
		AND CPE.CodigoProductoEspecifico = IPE.CodigoProductoEspecifico
		AND CPE.NumeroAgencia = IPE.NumeroAgencia
		WHERE CPE.CodigoProductoEspecifico NOT IN(		
													SELECT CPDE2.CodigoProductoEspecifico
													FROM ComprasProductosDevoluciones CPD2 
													INNER JOIN ComprasProductosDevolucionesEspecificos CPDE2 
													ON CPD2.NumeroAgencia = CPDE2.NumeroAgencia 
													AND CPD2.NumeroDevolucion = CPDE2.NumeroDevolucion
													WHERE CPD2.NumeroCompraProducto = @NumeroTransaccion)	
		AND CPE.NumeroCompraProducto = @NumeroTransaccion 
		AND CPE.NumeroAgencia = @NumeroAgencia 
		AND CPE.CodigoProducto = @CodigoProducto
		AND IPE.CodigoEstado IN ('A')
	END	
	
	IF(@TipoTransaccion ='G') --PARA LAS COMPRAS DE PRODUCTO AGREGADOS ESPECIFICOS
	BEGIN
		SELECT CPEA.CodigoProductoEspecifico, CPEA.PrecioUnitario AS PrecioDevolucion, CAST (0 AS BIT) AS Devolver
		FROM ComprasProductosEspecificosAgregados CPEA 		
		WHERE CPEA.CodigoProductoEspecifico NOT IN(
		
		SELECT CPDE2.CodigoProductoEspecifico
		FROM ComprasProductosDevoluciones CPD2 
		INNER JOIN ComprasProductosDevolucionesEspecificos CPDE2 ON CPD2.NumeroAgencia = CPDE2.NumeroAgencia AND CPD2.NumeroDevolucion = CPDE2.NumeroDevolucion
		WHERE CPD2.NumeroCompraProducto = @NumeroTransaccion) AND CPEA.NumeroCompraProducto = @NumeroTransaccion AND CPEA.NumeroAgencia = @NumeroAgencia AND CPEA.CodigoProducto = @CodigoProducto
	END
	
	IF(@TipoTransaccion ='V') --PARA LAS VENTAS DE PRODUCTO ESPECIFICOS
	BEGIN
		SELECT VPE.CodigoProductoEspecifico, VPD.PrecioUnitarioVenta AS PrecioDevolucion, CAST (0 AS BIT) AS Devolver
		FROM VentasProductosEspecificos VPE 
		INNER JOIN VentasProductosDetalle VPD 
		ON VPE.NumeroAgencia = VPD.NumeroAgencia 
		AND VPE.NumeroVentaProducto = VPD.NumeroVentaProducto 
		AND VPE.CodigoProducto = VPD.CodigoProducto
		INNER JOIN InventariosProductosEspecificos IPE
		ON VPE.CodigoProducto = IPE.CodigoProducto
		AND VPE.CodigoProductoEspecifico = IPE.CodigoProductoEspecifico
		AND VPE.NumeroAgencia = IPE.NumeroAgencia
		WHERE VPE.CodigoProductoEspecifico NOT IN(		
										SELECT VPDE2.CodigoProductoEspecifico
										FROM VentasProductosDevoluciones VPD2 
										INNER JOIN VentasProductosDevolucionesEspecificos VPDE2 
										ON VPD2.NumeroAgencia = VPDE2.NumeroAgencia 
										AND VPD2.NumeroDevolucion = VPDE2.NumeroDevolucion
										WHERE VPD2.NumeroVentaProducto = @NumeroTransaccion) 
		AND VPE.NumeroAgencia = @NumeroAgencia 
		AND VPE.NumeroVentaProducto = @NumeroTransaccion 
		AND VPE.CodigoProducto = @CodigoProducto
		AND IPE.CodigoEstado IN ('V')
	END
	
	IF(@TipoTransaccion ='T') --PARA LAS VENTAS DE PRODUCTO ESPECIFICOS AGREGADOS
	BEGIN
		SELECT VPEA.CodigoProductoEspecifico, VPEA.PrecioUnitario AS PrecioDevolucion, CAST (0 AS BIT) AS Devolver
		FROM VentasProductosEspecificosAgregados VPEA 		
		WHERE VPEA.CodigoProductoEspecifico NOT IN(
		
		SELECT VPDE2.CodigoProductoEspecifico
		FROM VentasProductosDevoluciones VPD2 
		INNER JOIN VentasProductosDevolucionesEspecificos VPDE2 ON VPD2.NumeroAgencia = VPDE2.NumeroAgencia AND VPD2.NumeroDevolucion = VPDE2.NumeroDevolucion
		WHERE VPD2.NumeroVentaProducto = @NumeroTransaccion) AND VPEA.NumeroAgencia = @NumeroAgencia AND VPEA.NumeroVentaProducto = @NumeroTransaccion AND VPEA.CodigoProducto = @CodigoProducto
	END
	
	
	IF(@TipoTransaccion ='D') --PARA LAS DEVOLUCIONES DE PRODUCTO ESPECIFICOS
	BEGIN
		SELECT VPRE.CodigoProductoEspecifico, VPRE.PrecioUnitarioReemplazoPE AS PrecioDevolucion, CAST (0 AS BIT) AS Devolver
		FROM VentasProductosReemplazoEspecificos VPRE
		WHERE VPRE.CodigoProductoEspecifico NOT IN(
		
		SELECT VPDE2.CodigoProductoEspecifico
		FROM VentasProductosDevoluciones VPD2 
		INNER JOIN VentasProductosDevolucionesEspecificos VPDE2 ON VPD2.NumeroAgencia = VPDE2.NumeroAgencia AND VPD2.NumeroDevolucion = VPDE2.NumeroDevolucion
		WHERE VPD2.NumeroVentaProducto = @NumeroTransaccion) AND VPRE.NumeroAgencia = @NumeroAgencia AND VPRE.NumeroReemplazo = @NumeroTransaccion AND VPRE.CodigoProducto = @CodigoProducto
	END
	
END


