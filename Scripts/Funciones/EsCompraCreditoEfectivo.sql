USE Doblones20
GO

DROP FUNCTION EsCompraCreditoEfectivo
GO

CREATE FUNCTION EsCompraCreditoEfectivo
(
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT
)
RETURNS DECIMAL(10,2)
WITH ENCRYPTION
AS
BEGIN
	DECLARE @MontoTotalDiferencia	DECIMAL(10,2),
			@CodigoTipoCompra		CHAR(1),
			@NumeroCuentaPorPagar	INT,
			@MontoTotalCompra		DECIMAL(10,2),
			@MontoCuentaPorPagar	DECIMAL(10,2)
			
	SELECT	@CodigoTipoCompra = CP.CodigoTipoCompra, @NumeroCuentaPorPagar =CP.NumeroCuentaPorPagar, 
			@MontoTotalCompra = CP.MontoTotalCompra
	FROM ComprasProductos CP
	WHERE CP.NumeroAgencia = @NumeroAgencia
	AND CP.NumeroCompraProducto = @NumeroCompraProducto
	
	IF(@CodigoTipoCompra = 'E')	
		SET @MontoTotalDiferencia = -1
	ELSE
	BEGIN
		SELECT @MontoCuentaPorPagar = Monto
		FROM CuentasPorPagar
		WHERE NumeroCuentaPorPagar = @NumeroCuentaPorPagar
		AND NumeroAgencia = @NumeroAgencia
		
		IF(@MontoCuentaPorPagar <> @MontoTotalCompra)
			SET @MontoTotalDiferencia = @MontoTotalCompra - @MontoCuentaPorPagar
		ELSE		
			SET @MontoTotalDiferencia = -1
	END
			
	RETURN ISNULL(@MontoTotalDiferencia,-1)
END