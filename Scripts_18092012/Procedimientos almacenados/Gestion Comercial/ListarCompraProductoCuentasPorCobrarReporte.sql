USE Doblones20
GO
DROP PROCEDURE ListarCompraProductoCuentasPorCobrarReporte
GO

CREATE PROCEDURE ListarCompraProductoCuentasPorCobrarReporte
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
	
	IF(@FechaInicio IS NOT NULL AND @FechaFin IS NOT NULL)
	BEGIN
		SELECT  LTRIM(RTRIM(U.Nombres))+' '+LTRIM(RTRIM(U.Paterno))+' '+LTRIM(RTRIM(U.Materno)) as DatosUsuario, 
				CP.NumeroAgencia AS NumeroAgencia,CP.NumeroCompraProducto, CP.CodigoProveedor, P.NombreRazonSocial, CP.Fecha,
				CASE (CP.NumeroCuentaPorCobrar) WHEN null THEN -1 ELSE CP.NumeroCuentaPorCobrar END AS NumeroCuentaPorCobrar,
				CP.Observaciones,
				P.NITProveedor, CASE (P.CodigoTipoProveedor) WHEN 'P' THEN 'PERSONA' WHEN 'E' THEN 'EMPRESA' END AS TipoCliente, 
				P.NombreRepresentante,
				@MascaraMonedaRegion AS MascaraMoneda,
				@NombreMonedaRegion AS NombreMoneda,
				CPP.Monto AS MontoCuentaPorCobrar,
				CPP.NumeroCuentaPorCobrar, 
				CASE WHEN CPP.CodigoEstado = 'C' THEN 'CANCELADO' ELSE 'PENDIENTE' END AS EstadoCuenta,
				CPP.CodigoEstado, 
				dbo.ObtenerMontoAmortiguadoCuentasPorPagarCobrar(CP.NumeroAgencia, CP.NumeroCuentaPorCobrar, 'P') AS MontoPagado,
				CP.MontoTotalCompra, CPP.FechaLimite
		FROM ComprasProductos CP 
		INNER JOIN Proveedores P 
		ON P.CodigoProveedor = CP.CodigoProveedor
		INNER JOIN Usuarios U 	
		ON U.CodigoUsuario = CP.CodigoUsuario
		INNER JOIN CuentasPorCobrar CPP
		ON CP.NumeroAgencia = CPP.NumeroAgencia
		AND CP.NumeroCuentaPorCobrar = CPP.NumeroCuentaPorCobrar
		WHERE CP.NumeroAgencia = @NumeroAgencia
		AND CAST(CP.NumeroCompraProducto AS VARCHAR(100))  like 
		CASE WHEN @NumeroCompraProducto IS NULL THEN '%%' 
		ELSE CAST(@NumeroCompraProducto AS VARCHAR(100))END
		AND CPP.CodigoEstado LIKE 
		CASE WHEN @EstadoCuenta IS NULL THEN '%%'
		ELSE @EstadoCuenta END
		AND CPP.FechaHoraRegistro BETWEEN @FechaInicio AND @FechaFin
	END
	ELSE	
	BEGIN
		
		SELECT  LTRIM(RTRIM(U.Nombres))+' '+LTRIM(RTRIM(U.Paterno))+' '+LTRIM(RTRIM(U.Materno)) as DatosUsuario, 
				CP.NumeroAgencia AS NumeroAgencia,CP.NumeroCompraProducto, CP.CodigoProveedor, P.NombreRazonSocial, CP.Fecha,
				CASE (CP.NumeroCuentaPorCobrar) WHEN null THEN -1 ELSE CP.NumeroCuentaPorCobrar END AS NumeroCuentaPorCobrar,
				CP.Observaciones,
				P.NITProveedor, CASE (P.CodigoTipoProveedor) WHEN 'P' THEN 'PERSONA' WHEN 'E' THEN 'EMPRESA' END AS TipoCliente, 
				P.NombreRepresentante,
				@MascaraMonedaRegion AS MascaraMoneda,
				@NombreMonedaRegion AS NombreMoneda,
				CPP.Monto AS MontoCuentaPorCobrar,
				CPP.NumeroCuentaPorCobrar, 
				CASE WHEN CPP.CodigoEstado = 'C' THEN 'CANCELADO' ELSE 'PENDIENTE' END AS EstadoCuenta,
				CPP.CodigoEstado, 
				dbo.ObtenerMontoAmortiguadoCuentasPorPagarCobrar(CP.NumeroAgencia, CP.NumeroCuentaPorCobrar, 'P') AS MontoPagado,
				CP.MontoTotalCompra, CPP.FechaLimite
		FROM ComprasProductos CP 
		INNER JOIN Proveedores P 
		ON P.CodigoProveedor = CP.CodigoProveedor
		INNER JOIN Usuarios U 	
		ON U.CodigoUsuario = CP.CodigoUsuario
		INNER JOIN CuentasPorCobrar CPP
		ON CP.NumeroAgencia = CPP.NumeroAgencia
		AND CP.NumeroCuentaPorCobrar = CPP.NumeroCuentaPorCobrar
		WHERE CP.NumeroAgencia = @NumeroAgencia
		AND CAST(CP.NumeroCompraProducto AS VARCHAR(100))  like 
		CASE WHEN @NumeroCompraProducto IS NULL THEN '%%' 
		ELSE CAST(@NumeroCompraProducto AS VARCHAR(100))END
		AND CPP.CodigoEstado LIKE 
		CASE WHEN @EstadoCuenta IS NULL THEN '%%'
		ELSE @EstadoCuenta END
		
	END
END
GO

--EXEC ListarCompraProductoCuentasPorCobrarReporte 1, NULL, null, null, null
--select * from CuentasPorCobrar
--select * from ComprasProductos
--where NumeroCompraProducto = 257
--update ComprasProductos
--set CodigoEstadoCompra = 'X'
--where NumeroCompraProducto = 257