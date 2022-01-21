USE Doblones20
GO

DROP FUNCTION ObtenerMontoDeudaPagadaCredito
GO

CREATE FUNCTION ObtenerMontoDeudaPagadaCredito
(
	@NumeroCredito	INT,
	@NumeroAgencia		INT,
	@FechaHoraInicio	DATETIME,
	@FechaHoraFin		DATETIME,
	@DIPersona			CHAR(15)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
	--TIPOS CREDITOS
	--CodigoTipoCredito : 'L'->LibreDisponibilidad, 'T'->'Por monto total venta productos, 'P'->Por monto parcial venta productos;
	DECLARE @MontoTotal	DECIMAL(10,2)
	IF(@FechaHoraInicio IS NOT NULL AND  @FechaHoraFin IS NOT NULL)-- SUMAMOS TOTAL PAGADO DE VARIOS CREDITOS DE UNA MISMA PERSONA(CLIENTE)
	BEGIN
		SELECT @MontoTotal = sum(MontoPago)
		FROM CreditosCuotasPagos CDP
		INNER JOIN Creditos C
		ON CDP.NumeroCredito = C.NumeroCredito
		WHERE C.FechaHoraSolicitud 
		BETWEEN DBO.FormatearFechaInicioFin(@FechaHoraInicio,1) AND DBO.FormatearFechaInicioFin(@FechaHoraFin,0)
		AND C.DIDeudor = @DIPersona
		AND C.CodigoTipoCredito IN ('P','T')
	END
	ELSE
	BEGIN
		SELECT @MontoTotal = sum(MontoPago)
		FROM CreditosCuotasPagos CDP
		WHERE CDP.NumeroCredito = @NumeroCredito
	END
	
	RETURN ISNULL(@MontoTotal,0)
	
	
END
GO



--SELECT VP.NumeroVentaProducto, VP.MontoTotalVenta, VP.FechaHoraVenta, C.DIDeudor, C.MontoDeuda, C.FechaHoraSolicitud
--FROM VentasProductos  VP
--INNER JOIN Creditos C
--ON VP.NumeroCredito = C.NumeroCredito
--WHERE VP.NumeroCredito IS NOT NULL
--SELECT * FROM Creditos