USE Doblones20
GO
DROP PROCEDURE ListarCompraProductoCuentasPorPagarReporte
GO

CREATE PROCEDURE ListarCompraProductoCuentasPorPagarReporte
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@FechaInicio			DATETIME,
	@FechaFin				DATETIME,
	@EstadoCuenta			CHAR(1)
AS
BEGIN
	DECLARE @MontoTotalCompra			DECIMAL(10,2),
			@CadenaMontoTotal			VARCHAR(255),
			@NombreMonedaRegion			VARCHAR(250),
			@MascaraMonedaRegion		VARCHAR(20)
	
	SELECT TOP 1 @MascaraMonedaRegion = MascaraMoneda, @NombreMonedaRegion = NombreMoneda
	FROM PCsConfiguraciones
	INNER JOIN Monedas
	ON CodigoMonedaSistema = CodigoMoneda
	WHERE NumeroAgencia = @NumeroAgencia
	
	IF(@FechaFin IS NULL AND @FechaInicio IS NULL)
	BEGIN
	
		SELECT  LTRIM(RTRIM(U.Nombres))+' '+LTRIM(RTRIM(U.Paterno))+' '+LTRIM(RTRIM(U.Materno)) as DatosUsuario, 
				CP.NumeroAgencia AS NumeroAgencia,CP.NumeroCompraProducto, CP.CodigoProveedor, P.NombreRazonSocial, CP.Fecha,
				CASE (CP.NumeroCuentaPorPagar) WHEN null THEN -1 ELSE CP.NumeroCuentaPorPagar END AS NumeroCuentaPorPagar,
				CP.Observaciones,
				P.NITProveedor, CASE (P.CodigoTipoProveedor) WHEN 'P' THEN 'PERSONA' WHEN 'E' THEN 'EMPRESA' END AS TipoCliente, 
				P.NombreRepresentante,
				@MascaraMonedaRegion AS MascaraMoneda,
				@NombreMonedaRegion AS NombreMoneda,				
				CPP.Monto AS MontoCuentaPorPagar, 
				CPP.NumeroCuentaPorPagar, 
				CASE WHEN CPP.CodigoEstado = 'C' THEN 'CANCELADO' ELSE 'PENDIENTE' END AS EstadoCuenta,
				CPP.CodigoEstado, 
				dbo.ObtenerMontoAmortiguadoCuentasPorPagarCobrar(CP.NumeroAgencia, CP.NumeroCuentaPorPagar, 'P') AS MontoPagado,
				CP.MontoTotalCompra, CPP.FechaLimite
				
		FROM ComprasProductos CP 
		INNER JOIN Proveedores P 
		ON P.CodigoProveedor = CP.CodigoProveedor
		INNER JOIN Usuarios U 	
		ON U.CodigoUsuario = CP.CodigoUsuario
		LEFT JOIN CuentasPorPagar CPP
		ON CP.NumeroAgencia = CPP.NumeroAgencia
		AND CP.NumeroCuentaPorPagar = CPP.NumeroCuentaPorPagar
		WHERE CP.NumeroAgencia = @NumeroAgencia
		AND CP.CodigoTipoCompra = 'R'
		AND CAST(CP.NumeroCompraProducto AS VARCHAR(100))  LIKE 
		CASE WHEN @NumeroCompraProducto IS NULL THEN '%%' 
		ELSE CAST(@NumeroCompraProducto AS VARCHAR(100))END
		AND CPP.CodigoEstado LIKE 
		CASE WHEN @EstadoCuenta IS NULL THEN '%%'
		ELSE @EstadoCuenta END
	
	END
	ELSE
	BEGIN
		SELECT  LTRIM(RTRIM(U.Nombres))+' '+LTRIM(RTRIM(U.Paterno))+' '+LTRIM(RTRIM(U.Materno)) as DatosUsuario, 
				CP.NumeroAgencia AS NumeroAgencia,CP.NumeroCompraProducto, CP.CodigoProveedor, P.NombreRazonSocial, CP.Fecha,
				CASE (CP.NumeroCuentaPorPagar) WHEN null THEN -1 ELSE CP.NumeroCuentaPorPagar END AS NumeroCuentaPorPagar,
				CP.Observaciones,
				P.NITProveedor, CASE (P.CodigoTipoProveedor) WHEN 'P' THEN 'PERSONA' WHEN 'E' THEN 'EMPRESA' END AS TipoCliente, 
				P.NombreRepresentante,
				@MascaraMonedaRegion AS MascaraMoneda,
				@NombreMonedaRegion AS NombreMoneda,				
				CPP.Monto AS MontoCuentaPorPagar, 
				CPP.NumeroCuentaPorPagar, 
				CASE WHEN CPP.CodigoEstado = 'C' THEN 'CANCELADO' ELSE 'PENDIENTE' END AS EstadoCuenta,
				CPP.CodigoEstado, 
				dbo.ObtenerMontoAmortiguadoCuentasPorPagarCobrar(CP.NumeroAgencia, CP.NumeroCuentaPorPagar, 'P') AS MontoPagado,
				CP.MontoTotalCompra, CPP.FechaLimite		
		FROM ComprasProductos CP 
		INNER JOIN Proveedores P 
		ON P.CodigoProveedor = CP.CodigoProveedor
		INNER JOIN Usuarios U 	
		ON U.CodigoUsuario = CP.CodigoUsuario
		LEFT JOIN CuentasPorPagar CPP
		ON CP.NumeroAgencia = CPP.NumeroAgencia
		AND CP.NumeroCuentaPorPagar = CPP.NumeroCuentaPorPagar
		WHERE CP.NumeroAgencia = @NumeroAgencia
		AND CP.CodigoTipoCompra = 'R'
		AND CAST(CP.NumeroCompraProducto AS VARCHAR(100))  LIKE 
		CASE WHEN @NumeroCompraProducto IS NULL THEN '%%' 
		ELSE CAST(@NumeroCompraProducto AS VARCHAR(100))END
		AND CPP.CodigoEstado LIKE 
		CASE WHEN @EstadoCuenta IS NULL THEN '%%'
		ELSE @EstadoCuenta END
		AND CPP.FechaHoraRegistro BETWEEN @FechaInicio AND @FechaFin
	END
END
GO




--SELECT * FROM DATE_SAMPLE WHERE 
--CAST(FLOOR(CAST(SAMPLE_DATE AS FLOAT))AS DATETIME) = 
--'2003-04-09'
----EXEC ListarCompraProductoCuentasPorPagarReporte 1, NULL, null, null, null

--select * from CuentasPorPagar
--select * from ComprasProductos
--where CodigoTipoCompra = 'R'