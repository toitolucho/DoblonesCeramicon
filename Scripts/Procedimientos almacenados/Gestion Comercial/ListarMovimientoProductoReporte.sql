USE Doblones20
GO

DROP PROCEDURE ListarMovimientoProductoReporte
GO

CREATE PROCEDURE ListarMovimientoProductoReporte
	@NumeroAgencia		INT,
	@FechaInicio		DATETIME,
	@FechaFin			DATETIME,
	@ListadoProductos	VARCHAR(4000)
WITH ENCRYPTION
AS
BEGIN
	IF(@ListadoProductos IS NULL OR RTRIM(@ListadoProductos) = '')
	BEGIN
		SELECT	IP.CodigoProducto, dbo.ObtenerNombreProducto(IP.CodigoProducto) AS NombreArticulo, 
				dbo.ObtenerCantidadTotalValoradoInventario(@NumeroAgencia, IP.CodigoProducto, DATEADD(YEAR, -50,GETDATE()), DATEADD(DAY,-1,@FechaInicio)) AS CantidadInicial,
				dbo.ObtenerMontoTotalValorado(@NumeroAgencia, IP.CodigoProducto, DATEADD(YEAR, -50,GETDATE()), DATEADD(DAY,-1,@FechaInicio))  as PrecioTotalInicial,
				ISNULL(TIA.CantidadIngresos,0) AS CantidadIngresos, ISNULL(TIA.PrecioTotalIngresos,0) AS PrecioTotalIngresos, 
				ISNULL(TSA.CantidadSalida,0) AS CantidadSalida, ISNULL(TSA.PrecioTotalSalidas,0) AS PrecioTotalSalidas,
				dbo.ObtenerCantidadTotalValoradoInventario(@NumeroAgencia, IP.CodigoProducto, DATEADD(YEAR, -50,GETDATE()), GETDATE()) AS CantidadSaldo,
				dbo.ObtenerMontoTotalValorado(@NumeroAgencia, IP.CodigoProducto, DATEADD(YEAR, -50,GETDATE()), GETDATE())  as PrecioTotalSaldo
		FROM InventariosProductos IP
		LEFT JOIN
		(
			SELECT CPDE.NumeroAgencia, CPDE.CodigoProducto, ISNULL(SUM(CPDE.CantidadEntregada),0) AS CantidadIngresos, ISNULL( SUM(CPD.PrecioUnitarioCompra * CPDE.CantidadEntregada),0) AS PrecioTotalIngresos
			FROM ComprasProductos CP
			INNER JOIN ComprasProductosDetalle CPD
			ON CP.NumeroAgencia = CPD.NumeroAgencia
			AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
			INNER JOIN ComprasProductosDetalleEntrega CPDE
			ON CPD.NumeroAgencia = CPDE.NumeroAgencia
			AND CPD.NumeroCompraProducto = CPDE.NumeroCompraProducto
			AND CPD.CodigoProducto = CPDE.CodigoProducto
			WHERE CP.CodigoEstadoCompra IN ('F','X')
			AND CPDE.FechaHoraEntrega 
			BETWEEN CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaInicio,120),120)
			AND DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaFin,120),120)))
			GROUP BY CPDE.NumeroAgencia, CPDE.CodigoProducto
		) TIA
		ON IP.CodigoProducto = TIA.CodigoProducto	
		AND IP.NumeroAgencia = TIA.NumeroAgencia
		LEFT JOIN
		(
			SELECT SADE.NumeroAgencia, SADE.CodigoProducto, ISNULL(SUM(SADE.CantidadEntregada),0) AS CantidadSalida, 
					CASE dbo.ObtenerCodigoTipoCalculoInventarioProducto(SADE.CodigoProducto)
					WHEN 'P' THEN ISNULL(SUM(SADE.PrecioUnitarioIngresoInventario * SADE.CantidadEntregada),0)
					WHEN 'U' THEN ISNULL(SUM(SADE.PrecioUnitarioIngresoInventario * SADE.CantidadEntregada),0)
					ELSE ISNULL(SUM(SAD.PrecioUnitarioSalida * SADE.CantidadEntregada),0) END AS PrecioTotalSalidas					
			FROM SalidasArticulosDetalleEntrega SADE
			INNER JOIN SalidasArticulosDetalle SAD
			ON SADE.NumeroAgencia = SAD.NumeroAgencia
			AND SADE.NumeroSalidaArticulo = SAD.NumeroSalidaArticulo
			AND SADE.CodigoProducto = SAD.CodigoProducto
			INNER JOIN SalidasArticulos SA
			ON SADE.NumeroAgencia = SA.NumeroAgencia
			AND SADE.NumeroSalidaArticulo = SA.NumeroSalidaArticulo
			WHERE SA.CodigoEstadoSalida IN ('F','X')
			AND SADE.FechaHoraEntrega 
			BETWEEN CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaInicio,120),120)
			AND DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaFin,120),120)))
			GROUP BY SADE.NumeroAgencia, SADE.CodigoProducto
		) TSA
		ON A.CodigoProducto = TSA.CodigoProducto
		AND A.NumeroAgencia = TSA.NumeroAgencia
		where A.NumeroAgencia = @NumeroAgencia
	
	END
	ELSE
	BEGIN
		DECLARE @ConsultaSQL	VARCHAR(4000)
		SET @ConsultaSQL =
		'
			SELECT	A.CodigoProducto, dbo.ObtenerNombreArticulo(A.CodigoProducto) AS NombreArticulo, 
					dbo.ObtenerCantidadTotalValoradoInventario('+ RTRIM(CAST(@NumeroAgencia AS CHAR(100))) + ', A.CodigoProducto, DATEADD(YEAR, -50,GETDATE()), DATEADD(DAY,-1,'''+CAST(@FechaInicio AS NVARCHAR(20)) +''')) AS CantidadInicial,
					dbo.ObtenerMontoTotalValorado('+ RTRIM(CAST(@NumeroAgencia AS CHAR(100))) + ', A.CodigoProducto, DATEADD(YEAR, -50,GETDATE()), DATEADD(DAY,-1,'''+CAST(@FechaInicio AS NVARCHAR(20)) +'''))  as PrecioTotalInicial,
					ISNULL(TIA.CantidadIngresos,0) AS CantidadIngresos, ISNULL(TIA.PrecioTotalIngresos,0) AS PrecioTotalIngresos, 
					ISNULL(TSA.CantidadSalida,0) AS CantidadSalida, ISNULL(TSA.PrecioTotalSalidas,0) AS PrecioTotalSalidas,
					dbo.ObtenerCantidadTotalValoradoInventario('+ RTRIM(CAST(@NumeroAgencia AS CHAR(100))) + ', A.CodigoProducto, DATEADD(YEAR, -50,GETDATE()), GETDATE()) AS CantidadSaldo,
					dbo.ObtenerMontoTotalValorado('+ RTRIM(CAST(@NumeroAgencia AS CHAR(100))) + ', A.CodigoProducto, DATEADD(YEAR, -50,GETDATE()), GETDATE())  as PrecioTotalSaldo
			FROM InventariosArticulos A
			LEFT JOIN
			(
				SELECT IADE.NumeroAgencia, IADE.CodigoProducto, ISNULL(SUM(IADE.CantidadEntregada),0) AS CantidadIngresos, ISNULL( SUM(IAD.PrecioUnitarioIngreso * IADE.CantidadEntregada),0) AS PrecioTotalIngresos
				FROM IngresosArticulosDetalleEntrega IADE
				INNER JOIN IngresosArticulosDetalle IAD
				ON IADE.CodigoProducto = IAD.CodigoProducto
				AND IADE.NumeroIngresoArticulo = IAD.NumeroIngresoArticulo
				AND IADE.NumeroAgencia = IAD.NumeroAgencia
				INNER JOIN IngresosArticulos IA
				ON IADE.NumeroAgencia = IA.NumeroAgencia
				AND IADE.NumeroIngresoArticulo = IA.NumeroIngresoArticulo
				WHERE IA.CodigoEstadoIngreso IN (''F'',''X'')
				AND (Cast(Floor(Cast(IADE.FechaHoraEntrega As Float)) As DateTime)
				BETWEEN  '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''') 	
				AND IADE.CodigoProducto IN (' + @ListadoProductos + ')		
				GROUP BY IADE.NumeroAgencia, IADE.CodigoProducto
			) TIA
			ON A.CodigoProducto = TIA.CodigoProducto	
			AND A.NumeroAgencia = TIA.NumeroAgencia
			LEFT JOIN
			(
				SELECT SADE.NumeroAgencia, SADE.CodigoProducto, ISNULL(SUM(SADE.CantidadEntregada),0) AS CantidadSalida, 
						CASE dbo.ObtenerCodigoTipoCalculoInventarioProducto(SADE.CodigoProducto)
						WHEN ''P'' THEN ISNULL(SUM(SADE.PrecioUnitarioIngresoInventario * SADE.CantidadEntregada),0)
						WHEN ''U'' THEN ISNULL(SUM(SADE.PrecioUnitarioIngresoInventario * SADE.CantidadEntregada),0)
						ELSE ISNULL(SUM(SAD.PrecioUnitarioSalida * SADE.CantidadEntregada),0) END AS PrecioTotalSalidas
				FROM SalidasArticulosDetalleEntrega SADE
				INNER JOIN SalidasArticulosDetalle SAD
				ON SADE.NumeroAgencia = SAD.NumeroAgencia
				AND SADE.NumeroSalidaArticulo = SAD.NumeroSalidaArticulo
				AND SADE.CodigoProducto = SAD.CodigoProducto
				INNER JOIN SalidasArticulos SA
				ON SADE.NumeroAgencia = SA.NumeroAgencia
				AND SADE.NumeroSalidaArticulo = SA.NumeroSalidaArticulo
				WHERE SA.CodigoEstadoSalida IN (''F'',''X'')
				AND (Cast(Floor(Cast(SADE.FechaHoraEntrega As Float)) As DateTime)
				BETWEEN  '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''') 
				AND SADE.CodigoProducto IN (' + @ListadoProductos + ')
					GROUP BY SADE.NumeroAgencia, SADE.CodigoProducto
			) TSA
			ON A.CodigoProducto = TSA.CodigoProducto
			AND A.NumeroAgencia = TSA.NumeroAgencia
		'
		PRINT @ConsultaSQL + 'WHERE A.CodigoProducto IN  (' + @ListadoProductos + ') ORDER BY 2'	
		EXEC (@ConsultaSQL+ 'WHERE A.CodigoProducto IN  (' + @ListadoProductos + ') ORDER BY 2')
	END
	
END
GO

--DECLARE @Fecha DATETIME = GETDATE()
--EXEC ListarMovimientoArticuloReporte 1,@Fecha,@Fecha ,NULL

--DECLARE @Fecha DATETIME = GETDATE()
--EXEC ListarMovimientoArticuloReporte 1,@Fecha,@Fecha ,'''001-MOU-000009'', ''ASDF'''

--EXEC ListarMovimientoArticuloReporte 1,'01/05/2011','19/05/2011' ,NULL
----Doblones20