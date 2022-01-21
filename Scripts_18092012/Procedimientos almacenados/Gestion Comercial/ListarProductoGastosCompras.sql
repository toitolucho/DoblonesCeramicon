USE Doblones20
GO

DROP PROCEDURE ListarProductoGastosCompras
GO

CREATE PROCEDURE ListarProductoGastosCompras
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT
AS
BEGIN
	SELECT CPGD.CodigoGastosTipos, GTT.NombreGasto, CPGD.MontoPagoGasto
	FROM CompraProductosGastosDetalle CPGD
	INNER JOIN GastosTiposTransacciones GTT ON GTT.CodigoGastosTipos = CPGD.CodigoGastosTipos
	WHERE CPGD.NumeroAgencia = @NumeroAgencia
	AND CPGD.NumeroCompraProducto = @NumeroCompraProducto
	AND CPGD.CodigoEstadoGasto = 0
	ORDER BY CPGD.FechaHoraGasto
END

--exec ListarProductoGastosCompras 1,1

