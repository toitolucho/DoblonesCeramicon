USE DOBLONES20

DROP PROCEDURE BuscarTransaccionGC
GO

CREATE PROCEDURE BuscarTransaccionGC
@CodigoAmbitoBusqueda		CHAR(1),
@TextoABuscar				VARCHAR(160),
@NumeroAgencia				INT,
@NumeroTransaccion			INT,
@TipoTransaccion			CHAR(1),
@FechaInicio				DATETIME,
@FechaFin					DATETIME,
@ExactamenteIgual			BIT,
@CodigoEstadoTranssacion	CHAR(1)

AS
DECLARE @S NVARCHAR(2000)
DECLARE @F VARCHAR(8000)
DECLARE @Condicion NVARCHAR(2000)
DECLARE @W NVARCHAR(4000)
DECLARE @AUX NVARCHAR(2000)
DECLARE @ScriptSQL VARCHAR(8000)
DECLARE @PosicionInicial TINYINT
DECLARE @PosicionActual TINYINT
DECLARE @PosicionFinal TINYINT
DECLARE @OperadorComparacion VARCHAR(4)
DECLARE @TextoABuscarOptimizado VARCHAR(170)
DECLARE @NombreCampo VARCHAR(250)

SET @W = ''

IF (@TipoTransaccion = 'V') --SI ES PARA VENTAS
BEGIN
	SET @S = 'SELECT DISTINCT VP.NumeroAgencia, VP.NumeroVentaProducto, VP.FechaHoraVenta , C.NombreCliente '
	SET @F = 'FROM VentasProductos VP INNER JOIN VentasProductosDetalle VPD ON VP.NumeroAgencia = VPD.NumeroAgencia AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto	
					INNER JOIN Productos P ON VPD.CodigoProducto = P.CodigoProducto
					INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente'
	SET @W = 'WHERE VP.NumeroAgencia = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' AND VP.NumeroVentaProducto LIKE '+ ISNULL(RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))),'''%''')+' AND (Cast(Floor(Cast(VP.FechaHoraVenta As Float)) As DateTime) BETWEEN  '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''') '
	SET @NombreCampo = ' VP.Observaciones '
	IF(@CodigoEstadoTranssacion IS NOT NULL)
	BEGIN		
		SET @W = @W + ' AND ( VP.CodigoEstadoVenta = ''' + @CodigoEstadoTranssacion + ''')'
	END
END
ELSE IF (@TipoTransaccion = 'C') -- SI ES PARA COMPRAS
BEGIN
	SET @S = 'SELECT DISTINCT CP.NumeroAgencia, CP.NumeroCompraProducto, CP.Fecha, PR.NombreRazonSocial '
	SET @F = 'FROM ComprasProductos CP INNER JOIN ComprasProductosDetalle CPD ON CP.NumeroAgencia = CPD.NumeroAgencia AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
					INNER JOIN Productos P ON CPD.CodigoProducto = P.CodigoProducto
					INNER JOIN Proveedores PR ON PR.CodigoProveedor = CP.CodigoProveedor'
	SET @W = 'WHERE CP.NumeroAgencia = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' AND CP.NumeroCompraProducto LIKE '+ ISNULL(RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))),'''%''')+' AND (Cast(Floor(Cast(CP.Fecha As Float)) As DateTime) BETWEEN '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''') '
	SET @NombreCampo = ' CP.Observaciones '
	IF(@CodigoEstadoTranssacion IS NOT NULL)
	BEGIN
		SET @W = @W + ' AND ( CP.CodigoEstadoCompra = ''' + @CodigoEstadoTranssacion + ''')'
	END
END
ELSE IF (@TipoTransaccion = 'S') -- SI ES PARA VentasServicios
BEGIN
	SET @S = 'SELECT DISTINCT VS.NumeroAgencia, VS.NumeroVentaServicio, VS.FechaHoraVentaServicio, C.NombreCliente '
	SET @F = 'FROM VentasServicios VS
				INNER JOIN VentasServiciosDetalle VSD
				ON VS.NumeroAgencia = VSD.NumeroAgencia
				AND VS.NumeroVentaServicio = VSD.NumeroVentaServicio
				INNER JOIN Servicios S
				ON VSD.CodigoServicio = S.CodigoServicio
				INNER JOIN Clientes C
				ON VS.CodigoCliente = C.CodigoCliente'
	SET @W = 'WHERE VS.NumeroAgencia = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' AND VS.NumeroVentaServicio LIKE '+ ISNULL(RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))),'''%''')+' AND (Cast(Floor(Cast(VS.FechaHoraVentaServicio As Float)) As DateTime) BETWEEN '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''') '
	SET @NombreCampo = ' VS.Observaciones '
	IF(@CodigoEstadoTranssacion IS NOT NULL)
	BEGIN
		SET @W = @W + ' AND ( VS.CodigoEstadoServicio = ''' + @CodigoEstadoTranssacion + ''')'
	END
END
ELSE IF (@TipoTransaccion = 'T') -- SI ES PARA COTIZACIONES
BEGIN
	SET @S = 'SELECT DISTINCT CVP.NumeroAgencia, CVP.NumeroCotizacionVentaProducto, CVP.FechaHoraCotizacion, C.NombreCliente '
	SET @F = 'FROM CotizacionVentasProductos CVP INNER JOIN CotizacionVentasProductosDeta CVPD ON CVP.NumeroAgencia = CVPD.NumeroAgencia AND CVP.NumeroCotizacionVentaProducto = CVPD.NumeroCotizacionVentaProducto
					INNER JOIN Productos P ON CVPD.CodigoProducto = P.CodigoProducto
					INNER JOIN Clientes C ON C.CodigoCliente = CVP.CodigoCliente'
	SET @W = 'WHERE CVP.NumeroAgencia = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' AND CVP.NumeroCotizacionVentaProducto LIKE '+ ISNULL(RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))),'''%''')+' AND (Cast(Floor(Cast(CVP.FechaHoraCotizacion As Float)) As DateTime) BETWEEN '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''') '
	SET @NombreCampo = ' CVP.Observaciones '
	IF(@CodigoEstadoTranssacion IS NOT NULL)
	BEGIN
		SET @W = @W + ' AND ( CVP.CodigoEstadoCotizacion = ''' + @CodigoEstadoTranssacion + ''')'
	END
END

ELSE IF(@TipoTransaccion = 'D') --SI ES PARA DEVOLUCIONES DE VENTAS
BEGIN
	SET @S = 'SELECT DISTINCT VPD.NumeroAgencia, VPD.NumeroDevolucion, VPD.FechaHoraSolicitudReemDevo, C.NombreCliente '
	SET @F = 'FROM VentasProductosDevoluciones VPD INNER JOIN VentasProductosDevolucionesDetalle VPDD ON VPD.NumeroAgencia = VPDD.NumeroAgencia AND VPD.NumeroDevolucion = VPDD.NumeroDevolucion
					INNER JOIN Productos P ON VPDD.CodigoProducto = P.CodigoProducto
					INNER  JOIN VentasProductos VP ON VP.NumeroVentaProducto = VPD.NumeroVentaProducto  INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente '
	SET @W = 'WHERE VPD.NumeroAgencia = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' AND VPD.NumeroDevolucion LIKE '+ ISNULL(RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))),'''%''')+' AND (Cast(Floor(Cast(VPD.FechaHoraSolicitudReemDevo As Float)) As DateTime) BETWEEN  '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''') '
	SET @NombreCampo = ' VPD.Observaciones '
	IF(@CodigoEstadoTranssacion IS NOT NULL)
	BEGIN
		SET @W = @W + ' AND ( VPD.CodigoEstadoDevolucion = ''' + @CodigoEstadoTranssacion + ''')'
	END
END

ELSE IF(@TipoTransaccion = 'P') --SI ES PARA DEVOLUCIONES DE ComPras
BEGIN
	SET @S = 'SELECT DISTINCT CPD.NumeroAgencia, CPD.NumeroDevolucion, CPD.FechaHoraSolicitudDevolucion, PR.NombreRazonSocial '
	SET @F = 'FROM ComprasProductosDevoluciones CPD INNER JOIN ComprasProductos CP ON CPD.NumeroCompraProducto = CP.NumeroCompraProducto
					INNER JOIN ComprasProductosDevolucionesDetalle CPDD ON CPD.NumeroAgencia = CPDD.NumeroAgencia AND CPD.NumeroDevolucion = CPDD.NumeroDevolucion
					INNER JOIN Productos P ON CPDD.CodigoProducto = P.CodigoProducto
					INNER JOIN Proveedores PR ON CP.CodigoProveedor = PR.CodigoProveedor '
	SET @W = 'WHERE CPD.NumeroAgencia = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' AND CPD.NumeroDevolucion LIKE '+ ISNULL(RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))),'''%''')+' AND (Cast(Floor(Cast(CPD.FechaHoraSolicitudDevolucion As Float)) As DateTime) BETWEEN  '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''') '
	SET @NombreCampo = ' CPD.Observaciones '
	IF(@CodigoEstadoTranssacion IS NOT NULL)
	BEGIN
		SET @W = @W + ' AND ( CPD.CodigoEstadoDevolucion = ''' + @CodigoEstadoTranssacion + ''')'
	END
END

ELSE IF (@TipoTransaccion = 'F') -- SI ES PARA TRANSFERENCIAS
BEGIN
	SET @S = 'SELECT DISTINCT TP.NumeroAgenciaEmisora, TP.NumeroTransferenciaProducto, TP.FechaHoraTransferencia, A.NombreAgencia '
	SET @F = 'FROM TransferenciasProductos TP INNER JOIN TransferenciasProductosDetalle TPD ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto
				INNER JOIN Productos P ON TPD.CodigoProducto = P.CodigoProducto
				INNER JOIN Agencias A ON TP.NumeroAgenciaRecepctora = A.NumeroAgencia'
	SET @W = 'WHERE (TP.NumeroAgenciaEmisora = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+' OR TP.NumeroAgenciaRecepctora = '+ RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))+')
	AND TP.NumeroTransferenciaProducto LIKE '+ ISNULL(RTRIM(CAST(@NumeroTransaccion AS VARCHAR(8000))),'''%''')+' AND (Cast(Floor(Cast(FechaHoraTransferencia As Float)) As DateTime) BETWEEN '''+ CAST(@FechaInicio as CHAR(12))+''' AND '''+CAST(@FechaFin as CHAR(12)) +''') '
	SET @NombreCampo = ' TP.Observaciones '
	IF(@CodigoEstadoTranssacion IS NOT NULL)
	BEGIN
		SET @W = @W + ' AND ( TP.CodigoEstadoTransferencia = ''' + @CodigoEstadoTranssacion + ''')'
	END
END

SET @AUX = ' '
--SET @NombreCampo = ''

--'0' -> NombrePersonaRealizaTransacción
--'1' -> NITPersonaRealizaTransacción
--'2' -> Nombre producto

IF @ExactamenteIgual = 1
BEGIN
	SET @OperadorComparacion = '='
	SET @TextoABuscarOptimizado = '''' + @TextoABuscar + ''''
END
ELSE
BEGIN
	SET @OperadorComparacion = 'LIKE'
	SET @TextoABuscarOptimizado = '''%' + @TextoABuscar + '%'''
END

IF (@TipoTransaccion = 'V') OR (@TipoTransaccion ='T') OR (@TipoTransaccion ='D') OR (@TipoTransaccion ='S')
BEGIN
	IF @CodigoAmbitoBusqueda = '0' 
		SET @Condicion = 'C.NombreCliente ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '1' 
		SET @Condicion = 'C.NITCliente ' + @OperadorComparacion + @TextoABuscarOptimizado
END
ELSE
BEGIN
	IF(@TipoTransaccion = 'F')
	BEGIN
		IF @CodigoAmbitoBusqueda = '0' 
		SET @Condicion = 'A.NombreAgencia ' + @OperadorComparacion + @TextoABuscarOptimizado
	ELSE IF @CodigoAmbitoBusqueda = '1' 
		SET @Condicion = 'A.NITAgencia ' + @OperadorComparacion + @TextoABuscarOptimizado
	END
	ELSE
	BEGIN
		IF @CodigoAmbitoBusqueda = '0' 
			SET @Condicion = 'PR.NombreRazonSocial ' + @OperadorComparacion + @TextoABuscarOptimizado
		ELSE IF @CodigoAmbitoBusqueda = '1' 
			SET @Condicion = 'PR.NITProveedor ' + @OperadorComparacion + @TextoABuscarOptimizado
	END
	
END
IF (@CodigoAmbitoBusqueda = '2')
BEGIN
	SET @PosicionInicial = 0
	SET @PosicionActual = 0
	SET @PosicionFinal = 0
	SET @NombreCampo = ' P.NombreProducto '
	WHILE LEN(@TextoABuscar) >= @PosicionActual
	BEGIN
		SET @PosicionActual = @PosicionActual + 1
		IF (SUBSTRING(@TextoABuscar, @PosicionActual, 1) = ' ')
		BEGIN
			IF LEN(@AUX) > 1
				SET @AUX = @AUX + ' AND '			
			SET @AUX = @AUX + @NombreCampo + ' LIKE ' + '''%' + SUBSTRING(@TextoABuscar, @PosicionInicial, (@PosicionActual - @PosicionInicial)) + '%'''			
			SET @PosicionInicial = @PosicionActual + 1
		END
	END

	SET @Condicion =  LTRIM(RTRIM(@AUX))
END

IF (@CodigoAmbitoBusqueda = '3')
BEGIN
	SET @PosicionInicial = 0
	SET @PosicionActual = 0
	SET @PosicionFinal = 0	
	WHILE LEN(@TextoABuscar) >= @PosicionActual
	BEGIN
		SET @PosicionActual = @PosicionActual + 1
		IF (SUBSTRING(@TextoABuscar, @PosicionActual, 1) = ' ')
		BEGIN
			IF LEN(@AUX) > 1
				SET @AUX = @AUX + ' AND '			
			SET @AUX = @AUX + @NombreCampo + ' LIKE ' + '''%' + SUBSTRING(@TextoABuscar, @PosicionInicial, (@PosicionActual - @PosicionInicial)) + '%'''			
			SET @PosicionInicial = @PosicionActual + 1
		END
	END

	SET @Condicion =  LTRIM(RTRIM(@AUX))
END


SET @W = @W +' AND ('+RTRIM(@Condicion)+')';

SET @ScriptSQL  = LTRIM(RTRIM(LTRIM(RTRIM(@S)) + ' ' + LTRIM(RTRIM(@F)) + ' ' +  LTRIM(RTRIM(@W))))
PRINT @ScriptSQL

EXEC(@ScriptSQL)


GO

--exec BuscarTransaccionGC 3, ' ',3,null, 'S', '10/10/09','31/10/10',0, 'F'
--exec BuscarTransaccionGC 3,'',1,1,'F','10/10/09','31/10/10',0
--exec BuscarTransaccionGC 0,'',1,null,'S','10/10/09','30/11/09',0

--select isnull(CAST(null as varchar(30)),'''%''')
--select isnull(CAST(342 as varchar(30)),'%')

--select * from VentasProductos
--where NumeroVentaProducto like %
