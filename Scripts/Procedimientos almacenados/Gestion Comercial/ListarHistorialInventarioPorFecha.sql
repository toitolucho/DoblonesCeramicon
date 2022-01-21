USE Doblones20
GO
DROP PROCEDURE ListarHistorialInventarioPorFecha
GO

CREATE PROCEDURE ListarHistorialInventarioPorFecha
	@FechaInicio DATETIME, @FechaFin DATETIME, @NumeroAgencia INT
AS
BEGIN
	--SELECT IP.CodigoProducto, dbo.ObtenerNombreProducto(IP.CodigoProducto) AS NombreProducto, ISNULL(IP.CantidadExistencia + dbo.ObtenerCantidadVendidaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) - dbo.ObtenerCantidadCompradaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) , IP.CantidadExistencia ) AS CantidadExistenciaAnterior, ISNULL(dbo.ObtenerCantidadVendidaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin),0) AS CantidadEgresada, ISNULL(dbo.ObtenerCantidadCompradaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin),0) AS CantidadIngresada, IP.CantidadExistencia AS CantidadExistenciaActual, IP.CantidadRequerida, IP.StockMinimo, IP.PrecioUnitarioCompra
	SELECT	IP.CodigoProducto,
			dbo.ObtenerNombreProducto(IP.CodigoProducto) AS NombreProducto, 
			ISNULL(
				IP.CantidadExistencia + 
				dbo.obtenerCantidadVendidaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) + 
				dbo.obtenerCantidadDevueltaCompradaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) + 
				dbo.obtenerCantidadVendidarReemplazadaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) - 
				dbo.obtenerCantidadCompradaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) - 
				dbo.obtenerCantidadVendidaDevueltaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin), 
			IP.CantidadExistencia ) AS CantidadExistenciaAnterior, 
			ISNULL(
				dbo.obtenerCantidadVendidaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) + 
				dbo.obtenerCantidadDevueltaCompradaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) + 
				dbo.obtenerCantidadVendidarReemplazadaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin),
			0) AS CantidadEgresada, 
			ISNULL(
				dbo.obtenerCantidadCompradaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) + 
				dbo.obtenerCantidadVendidaDevueltaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin),
			0) AS CantidadIngresada, 
			IP.CantidadExistencia AS CantidadExistenciaActual, 
			IP.CantidadRequerida, 
			IP.StockMinimo, 
			IP.PrecioUnitarioCompra
	
	FROM InventariosProductos IP
	WHERE IP.NumeroAgencia = @NumeroAgencia
	ORDER BY dbo.ObtenerNombreProducto(IP.CodigoProducto)
END
GO


--DECLARE @FechaFinish DATETIME = GETDATE()
--EXEC ListarHistorialInventarioPorFecha  '2009-12-09 19:01:52.160' , @FechaFinish, 1

--dbo.ObtenerCantidadVendidaEnRangoFecha('368','2009-12-09 19:01:52.160',GETDATE())

--select GETDATE()
--from InventariosProductos


--select * from VentasProductos
--select * from VentasProductosDetalle

--select * from ComprasProductos
--select * from ComprasProductosDetalle


--EGRESOS DE INVENTARIO
--ObtenerCantidadVendidaEnRangoFechaPorProducto
--ObtenerCantidadDevueltaCompradaEnRangoFechaPorProducto
--ObtenerCantidadVendidarReemplazadaEnRangoFechaPorProducto

--INGRESO EN INVENTARIO
--ObtenerCantidadCompradaEnRangoFechaPorProducto
--ObtenerCantidadVendidaDevueltaEnRangoFechaPorProducto



--EXISTENCIA ANTERIOR
--IP.CantidadExistencia + ObtenerCantidadVendidaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) + ObtenerCantidadDevueltaCompradaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) + ObtenerCantidadVendidarReemplazadaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) - ObtenerCantidadCompradaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) - ObtenerCantidadVendidaDevueltaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin)


--EGRESOS
--ObtenerCantidadVendidaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) + ObtenerCantidadDevueltaCompradaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) + ObtenerCantidadVendidarReemplazadaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin)

--INGRESOS
--ObtenerCantidadCompradaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) + ObtenerCantidadVendidaDevueltaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin)



--SELECT IP.CodigoProducto, dbo.ObtenerNombreProducto(IP.CodigoProducto) AS NombreProducto, ISNULL(IP.CantidadExistencia + dbo.obtenerCantidadVendidaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) + dbo.obtenerCantidadDevueltaCompradaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) + dbo.obtenerCantidadVendidarReemplazadaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) - dbo.obtenerCantidadCompradaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) - dbo.obtenerCantidadVendidaDevueltaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin), IP.CantidadExistencia ) AS CantidadExistenciaAnterior, ISNULL(dbo.obtenerCantidadVendidaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) + dbo.obtenerCantidadDevueltaCompradaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) + dbo.obtenerCantidadVendidarReemplazadaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin),0) AS CantidadEgresada, ISNULL(dbo.obtenerCantidadCompradaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin) + dbo.obtenerCantidadVendidaDevueltaEnRangoFechaPorProducto(IP.CodigoProducto,@FechaInicio,@FechaFin),0) AS CantidadIngresada, IP.CantidadExistencia AS CantidadExistenciaActual, IP.CantidadRequerida, IP.StockMinimo, IP.PrecioUnitarioCompra
--FROM InventariosProductos IP
--ORDER BY dbo.ObtenerNombreProducto(IP.CodigoProducto)



--select * from VentasProductosDevolucionesDetalle
--select * from ComprasProductosDetalle


--select * from VentasProductosDetalle
--select * from ComprasProductosDevolucionesDetalle
--select * from VentasProductosReemplazoDetalle