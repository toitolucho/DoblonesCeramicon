USE Doblones20
GO

DROP PROCEDURE ListarKardexProductoDetalladoReporte
GO

CREATE PROCEDURE ListarKardexProductoDetalladoReporte
	@NumeroAgencia		INT,
	@FechaHoraInicio	DATETIME,
	@FechaHoraFin		DATETIME,
	@ListadoProductos	VARCHAR(4000)
AS
BEGIN

IF(@ListadoProductos IS NULL)
	BEGIN
		SELECT	KADT.CodigoProducto AS CodigoArticulo, DBO.ObtenerNombreProducto(KADT.CodigoProducto) AS NombreArticulo, 
				dbo.ObtenerCantidadTotalValoradoInventario(@NumeroAgencia,KADT.CodigoProducto, DATEADD(YEAR, -10,GETDATE()) , CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaHoraInicio,120),120)) 
				- dbo.ObtenerCantidadTotalValoradoInventario(@NumeroAgencia,KADT.CodigoProducto, '01/01/1989', GETDATE()) + IP.CantidadExistencia AS CantidadExistenciaInicial,
				DBO.ObtenerMontoTotalValorado(1,KADT.CodigoProducto,  DATEADD(YEAR, -10,GETDATE()), CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaHoraInicio,120),120))  as PrecioTotalValoradoInicial,
				IP.CantidadExistencia AS CantidadExistenciaActual,
				--dbo.ObtenerCantidadTotalValoradoInventario(1,KADT.CodigoProducto, DATEADD(YEAR, -10,GETDATE()) , DATEADD(MILLISECOND, -1,@FechaHoraInicio)) AS CantidadExistenciaInicial,
				--DBO.ObtenerMontoTotalValorado(1,KADT.CodigoProducto,  DATEADD(YEAR, -10,GETDATE()), DATEADD(MILLISECOND, -1,@FechaHoraInicio))  as PrecioTotalValoradoInicial,
				KADT.FechaHoraEntrega as FechaHoraEntrega,
				KADT.NumeroTransaccion as NumeroIngresoArticulo,
				PRO.NombreRazonSocial,
				UPPER(LTRIM(RTRIM(U.Nombres)) + ' ' + LTRIM(RTRIM(U.Paterno)) + ' ' + LTRIM(RTRIM(U.Materno))) AS FuncionarioRecepcion,
				CASE KADT.TipoTransaccion WHEN 'I' THEN ABS(KADT.CantidadEntregada) ELSE NULL END as CantidadIngreso,
				CASE KADT.TipoTransaccion WHEN 'I' THEN ABS(KADT.PrecioUnitarioCompra) ELSE NULL END as PrecioUnitarioIngreso,
				CASE KADT.TipoTransaccion WHEN 'I' THEN ABS(KADT.PrecioUnitarioCompra * KADT.CantidadEntregada) ELSE NULL END as PrecioValoradoIngreso,
				CASE KADT.TipoTransaccion WHEN 'E' THEN ABS(KADT.CantidadEntregada) ELSE NULL END as CantidadSalida,
				CASE KADT.TipoTransaccion WHEN 'E' THEN ABS(KADT.PrecioUnitarioCompra) ELSE NULL END as PrecioUnitarioSalida,
				CASE KADT.TipoTransaccion WHEN 'E' THEN ABS(KADT.PrecioUnitarioCompra * KADT.CantidadEntregada) ELSE NULL END as PrecioValoradoSalida,
				KADT.CantidadAcumulada AS CantidadExistenciaSaldo, 
				KADT.PrecioTotalAcumulado AS PrecioTotalValoradoSaldo,
				KADT.CodigoTipoTransaccion
		FROM 
		KardexArticuloDetalladoTotal KADT
		INNER JOIN InventariosProductos IP
		ON KADT.CodigoProducto = IP.CodigoProducto
		LEFT JOIN ComprasProductos CP
		ON KADT.NumeroTransaccionReal = CP.NumeroCompraProducto
		AND KADT.TipoTransaccion = 'I'
		AND KADT.CodigoTipoTransaccion = 'CP'
		LEFT JOIN VentasProductosDevoluciones VPD
		ON KADT.NumeroTransaccionReal = VPD.NumeroDevolucion
		AND KADT.TipoTransaccion = 'I'
		AND KADT.CodigoTipoTransaccion = 'VPD'
		LEFT JOIN TransferenciasProductos TPR
		ON KADT.NumeroTransaccionReal = TPR.NumeroTransferenciaProducto
		AND TPR.NumeroAgenciaRecepctora = @NumeroAgencia
		AND KADT.TipoTransaccion = 'I'
		AND KADT.CodigoTipoTransaccion = 'TPR'
		LEFT JOIN VentasProductos VP
		ON KADT.NumeroTransaccionReal = VP.NumeroVentaProducto
		AND KADT.TipoTransaccion = 'E'
		AND KADT.CodigoTipoTransaccion = 'VP'
		LEFT JOIN ComprasProductosDevoluciones CPD
		ON KADT.NumeroTransaccionReal = CPD.NumeroDevolucion
		AND KADT.TipoTransaccion = 'E'
		AND KADT.CodigoTipoTransaccion = 'CPD'
		LEFT JOIN TransferenciasProductos TPE
		ON KADT.NumeroTransaccionReal = TPE.NumeroTransferenciaProducto
		AND TPE.NumeroAgenciaEmisora = @NumeroAgencia
		AND KADT.TipoTransaccion = 'E'
		AND KADT.CodigoTipoTransaccion = 'TPE'
		LEFT JOIN Proveedores PRO
		ON CP.CodigoProveedor = PRO.CodigoProveedor
		LEFT JOIN Usuarios U
		ON VP.CodigoUsuario = U.CodigoUsuario				
		WHERE KADT.FechaHoraEntrega
		BETWEEN CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaHoraInicio,120),120)
		AND DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, CONVERT(VARCHAR(10),@FechaHoraFin,120),120)))
		AND KADT.NumeroAgencia = @NumeroAgencia		
		AND KADT.CodigoTipoTransaccion  <> 'IP'
		ORDER BY 2, KADT.FechaHoraEntrega
	END	
ELSE
	BEGIN
	DECLARE @FechaInicioLiteral VARCHAR(10) = CONVERT(VARCHAR(20),@FechaHoraInicio,120),
			@FechaFinLiteral VARCHAR(10) = CONVERT(VARCHAR(20),@FechaHoraFin,120),
			@NumeroAgenciaLiteral	VARCHAR(10) = RTRIM(CAST(@NumeroAgencia AS VARCHAR(10)))
	EXEC ('SELECT	KADT.CodigoProducto AS CodigoArticulo, DBO.ObtenerNombreProducto(KADT.CodigoProducto) AS NombreArticulo, 
					dbo.ObtenerCantidadTotalValoradoInventario('+@NumeroAgenciaLiteral+', KADT.CodigoProducto, DATEADD(YEAR, -10,GETDATE()) , 
					CONVERT(DATETIME,''' + @FechaInicioLiteral + ''',120)) 
					- dbo.ObtenerCantidadTotalValoradoInventario('+@NumeroAgenciaLiteral+',KADT.CodigoProducto, ''01/01/1989'', GETDATE()) + IP.CantidadExistencia AS CantidadExistenciaInicial,	
					DBO.ObtenerMontoTotalValorado('+@NumeroAgenciaLiteral+',KADT.CodigoProducto,  DATEADD(YEAR, -10,GETDATE()),
					 CONVERT(DATETIME, ''' + @FechaInicioLiteral + ''',120))  as PrecioTotalValoradoInicial,		
					KADT.FechaHoraEntrega as FechaHoraEntrega,
					KADT.NumeroTransaccion as NumeroIngresoArticulo,
					PRO.NombreRazonSocial,
					UPPER(LTRIM(RTRIM(U.Nombres)) + '' '' + LTRIM(RTRIM(U.Paterno)) + '' '' + LTRIM(RTRIM(U.Materno))) AS FuncionarioRecepcion,
					CASE KADT.TipoTransaccion WHEN ''I'' THEN ABS(KADT.CantidadEntregada) ELSE NULL END as CantidadIngreso,
					CASE KADT.TipoTransaccion WHEN ''I'' THEN ABS(KADT.PrecioUnitarioCompra) ELSE NULL END as PrecioUnitarioIngreso,
					CASE KADT.TipoTransaccion WHEN ''I'' THEN ABS(KADT.PrecioUnitarioCompra * KADT.CantidadEntregada) ELSE NULL END as PrecioValoradoIngreso,
					CASE KADT.TipoTransaccion WHEN ''E'' THEN ABS(KADT.CantidadEntregada) ELSE NULL END as CantidadSalida,
					CASE KADT.TipoTransaccion WHEN ''E'' THEN ABS(KADT.PrecioUnitarioCompra) ELSE NULL END as PrecioUnitarioSalida,
					CASE KADT.TipoTransaccion WHEN ''E'' THEN ABS(KADT.PrecioUnitarioCompra * KADT.CantidadEntregada) ELSE NULL END as PrecioValoradoSalida,
					KADT.CantidadAcumulada AS CantidadExistenciaSaldo, 
					KADT.PrecioTotalAcumulado AS PrecioTotalValoradoSaldo, KADT.CodigoTipoTransaccion
			FROM 
			KardexArticuloDetalladoTotal KADT
			INNER JOIN InventariosProductos IP
			ON KADT.CodigoProducto = IP.CodigoProducto
			LEFT JOIN ComprasProductos CP
			ON KADT.NumeroTransaccionReal = CP.NumeroCompraProducto
			AND KADT.TipoTransaccion = ''I''
			AND KADT.CodigoTipoTransaccion = ''CP''
			LEFT JOIN VentasProductosDevoluciones VPD
			ON KADT.NumeroTransaccionReal = VPD.NumeroDevolucion
			AND KADT.TipoTransaccion = ''I''
			AND KADT.CodigoTipoTransaccion = ''VPD''
			LEFT JOIN TransferenciasProductos TPR
			ON KADT.NumeroTransaccionReal = TPR.NumeroTransferenciaProducto
			AND TPR.NumeroAgenciaRecepctora = '+ @FechaInicioLiteral +'
			AND KADT.TipoTransaccion = ''I''
			AND KADT.CodigoTipoTransaccion = ''TPR''
			LEFT JOIN VentasProductos VP
			ON KADT.NumeroTransaccionReal = VP.NumeroVentaProducto
			AND KADT.TipoTransaccion = ''E''
			AND KADT.CodigoTipoTransaccion = ''VP''
			LEFT JOIN ComprasProductosDevoluciones CPD
			ON KADT.NumeroTransaccionReal = CPD.NumeroDevolucion
			AND KADT.TipoTransaccion = ''E''
			AND KADT.CodigoTipoTransaccion = ''CPD''
			LEFT JOIN TransferenciasProductos TPE
			ON KADT.NumeroTransaccionReal = TPE.NumeroTransferenciaProducto
			AND TPE.NumeroAgenciaEmisora = '+ @FechaInicioLiteral +'
			AND KADT.TipoTransaccion = ''E''
			AND KADT.CodigoTipoTransaccion = ''TPE''
			LEFT JOIN Proveedores PRO
			ON CP.CodigoProveedor = PRO.CodigoProveedor
			LEFT JOIN Usuarios U
			ON VP.CodigoUsuario = U.CodigoUsuario				
			WHERE KADT.FechaHoraEntrega
			BETWEEN CONVERT(DATETIME,''' + @FechaInicioLiteral + ''' ,120)
			AND DATEADD(SECOND,-1, DATEADD(DAY,1, CONVERT(DATETIME, ''' + @FechaFinLiteral + ''',120)))
			AND KADT.CodigoProducto IN (' + @ListadoProductos + ') 
			AND KADT.CodigoTipoTransaccion  <> ''IP''
			ORDER BY 2, KADT.FechaHoraEntrega')
	END
END
GO

--EXEC ListarKardexProductoDetalladoReporte 1, '01/01/2000', '31/12/2012','''003-ACE-000001'''
--EXEC ListarKardexProductoDetalladoReporte 1, '01/01/2000', '31/12/2012',NULL

----Doblones20

--SELECT * FROM InventariosProductos WHERE CodigoProducto = '003-ACE-000001'
