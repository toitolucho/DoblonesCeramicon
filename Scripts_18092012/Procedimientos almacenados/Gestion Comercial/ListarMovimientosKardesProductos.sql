USE Doblones20
GO

DROP PROCEDURE ListarMovimientosKardexProductos
GO

CREATE PROCEDURE ListarMovimientosKardexProductos
	@NumeroAgencia		INT,
	@CodigoProducto		CHAR(15),
	@FechaInicio		DATETIME,
	@FechaFin			DATETIME
AS
BEGIN
	DECLARE @consulta			VARCHAR(4000),
			@FiltroProducto		VARCHAR(300),
			@FiltroFecha		VARCHAR(300)
IF @CodigoProducto IS NOT NULL
	SET @FiltroProducto = 'CodigoProducto = ''' + LTRIM(RTRIM(@CodigoProducto)) +''''
IF @FechaInicio IS NOT NULL AND @FechaFin IS NOT NULL
	SET @FiltroFecha=  ' FechaHoraTranssacion BETWEEN  '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''' '	
--AND (Cast(Floor(Cast(VP.FechaHoraVenta As Float)) As DateTime) BETWEEN  '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''') '	

SET @consulta = ' SELECT * FROM (
SELECT IP.NumeroAgencia, IP.CodigoProducto, dbo.ObtenerNombreProducto(IP.CodigoProducto) AS NombreProducto, IP.CantidadExistencia, IP.CantidadRequerida, VPDE.CantidadEntregada AS CantidadMovimiento, VPDE.FechaHoraEntrega as FechaHoraTranssacion, ''VENTA'' AS Transaccion, VPDE.NumeroVentaProducto as NumeroTranssacion
from InventariosProductos IP
INNER JOIN VentasProductosDetalleEntrega VPDE
ON IP.CodigoProducto = VPDE.CodigoProducto
AND IP.NumeroAgencia = VPDE.NumeroAgencia
UNION
SELECT IP.NumeroAgencia, IP.CodigoProducto, dbo.ObtenerNombreProducto(IP.CodigoProducto) AS NombreProducto, IP.CantidadExistencia, IP.CantidadRequerida,  CPDE.CantidadEntregada, CPDE.FechaHoraEntrega, ''COMPRA'', CPDE.NumeroCompraProducto
FROM InventariosProductos IP
INNER JOIN ComprasProductosDetalleEntrega CPDE
ON IP.NumeroAgencia = CPDE.NumeroAgencia
AND IP.CodigoProducto = CPDE.CodigoProducto
UNION
SELECT IP.NumeroAgencia, IP.CodigoProducto, dbo.ObtenerNombreProducto(IP.CodigoProducto) AS NombreProducto, IP.CantidadExistencia, IP.CantidadRequerida, TPDR.CantidadEnvioRecepcion, TPDR.FechaHoraEnvioRecepcion, ''TRANSFERENCIA ENVIO'', TPDR.NumeroTransferenciaProducto
FROM InventariosProductos IP
INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
ON IP.NumeroAgencia = TPDR.NumeroAgenciaEmisora
AND IP.CodigoProducto = TPDR.CodigoProducto
AND TPDR.CodigoTipoEnvioRecepcion = ''E''
UNION
SELECT IP.NumeroAgencia, IP.CodigoProducto, dbo.ObtenerNombreProducto(IP.CodigoProducto) AS NombreProducto, IP.CantidadExistencia, IP.CantidadRequerida, TPDR.CantidadEnvioRecepcion, TPDR.FechaHoraEnvioRecepcion, ''TRANSFERENCIA RECEPCION'', TPDR.NumeroTransferenciaProducto
FROM InventariosProductos IP
INNER JOIN TransferenciasProductosDetalleRecepcion TPDR
ON IP.CodigoProducto = TPDR.CodigoProducto
AND TPDR.CodigoTipoEnvioRecepcion = ''R''
INNER JOIN TransferenciasProductos TP
ON TP.NumeroAgenciaRecepctora = TPDR.NumeroAgenciaEmisora
UNION
SELECT IP.NumeroAgencia, IP.CodigoProducto, dbo.ObtenerNombreProducto(IP.CodigoProducto) AS NombreProducto, IP.CantidadExistencia, IP.CantidadRequerida, VPDD.CantidadDevuelta, VPD.FechaHoraSolicitudReemDevo, ''DEVOLUCION VENTA'', VPD.NumeroDevolucion
FROM InventariosProductos IP
INNER JOIN VentasProductosDevolucionesDetalle VPDD
ON IP.CodigoProducto = VPDD.CodigoProducto
AND IP.NumeroAgencia = VPDD.NumeroAgencia
INNER JOIN VentasProductosDevoluciones VPD
ON VPDD.NumeroAgencia = VPD.NumeroAgencia
AND VPDD.NumeroDevolucion = VPD.NumeroDevolucion
WHERE VPD.CodigoEstadoDevolucion = ''F''
UNION
SELECT IP.NumeroAgencia, IP.CodigoProducto, dbo.ObtenerNombreProducto(IP.CodigoProducto) AS NombreProducto, IP.CantidadExistencia, IP.CantidadRequerida, VPRD.CantidadDevuelta, VPR.FechaHoraSolicitudReemplazo, ''REEMPLAZO VENTA'', VPR.NumeroReemplazo
FROM InventariosProductos IP
INNER JOIN VentasProductosReemplazoDetalle VPRD
ON IP.NumeroAgencia = VPRD.NumeroAgencia
AND IP.CodigoProducto = VPRD.CodigoProducto
INNER JOIN VentasProductosReemplazo VPR
ON VPRD.NumeroAgencia = VPR.NumeroAgencia
AND VPRD.NumeroReemplazo = VPR.NumeroReemplazo
WHERE VPR.CodigoEstadoReemplazo = ''F''
UNION
SELECT IP.NumeroAgencia, IP.CodigoProducto, dbo.ObtenerNombreProducto(IP.CodigoProducto) AS NombreProducto, IP.CantidadExistencia, IP.CantidadRequerida, CPDD.CantidadDevuelta, CPD.FechaHoraSolicitudDevolucion, ''DEVOLUCION COMPRA'', CPD.NumeroDevolucion
FROM InventariosProductos IP
INNER JOIN ComprasProductosDevolucionesDetalle CPDD
ON IP.NumeroAgencia = CPDD.NumeroAgencia
AND IP.CodigoProducto = CPDD.CodigoProducto
INNER JOIN ComprasProductosDevoluciones CPD
ON CPDD.NumeroAgencia = CPD.NumeroAgencia
AND CPDD.NumeroDevolucion = CPD.NumeroDevolucion
WHERE CPD.CodigoEstadoDevolucion = ''F''
) KARDEX'

IF(@NumeroAgencia < 1)
BEGIN
	IF(@FiltroProducto IS NOT NULL  AND @FiltroFecha IS NOT NULL)
		SET @consulta = @consulta + ' WHERE ' + @FiltroProducto + ' AND ' + @FiltroFecha
	IF(@FiltroProducto IS NULL  AND @FiltroFecha IS NOT NULL)
		SET @consulta = @consulta + ' WHERE '  + @FiltroFecha
	IF(@FiltroProducto IS NOT NULL  AND @FiltroFecha IS NULL)
		SET @consulta = @consulta + ' WHERE ' + @FiltroProducto
END
ELSE
BEGIN
	IF(@FiltroProducto IS NOT NULL  AND @FiltroFecha IS NOT NULL)
		SET @consulta = @consulta + ' WHERE  NumeroAgencia = ' +  RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100)))) +' AND '  + @FiltroProducto + ' AND ' + @FiltroFecha
	IF(@FiltroProducto IS NULL  AND @FiltroFecha IS NOT NULL)
		SET @consulta = @consulta + ' WHERE NumeroAgencia = ' +  RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100)))) +' AND '  +  @FiltroFecha
	IF(@FiltroProducto IS NOT NULL  AND @FiltroFecha IS NULL)
		SET @consulta = @consulta + ' WHERE NumeroAgencia = ' +  RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100)))) +' AND '  +  @FiltroProducto
END
SET @consulta = @consulta + ' ORDER BY 3,7'

print @consulta
--select LEN(@consulta)
EXEC (@consulta)

END
GO


--SELECT GETDATE()
--exec ListarMovimientosKardexProductos -1,'001-AUD-000007 ','20091003 16:51:10.387','20101003 16:51:10.387'
--exec ListarMovimientosKardexProductos 1,NULL,'20091003 16:51:10.387','20101003 16:51:10.387'