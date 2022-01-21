USE Doblones20
GO

DROP PROCEDURE ListarComprasProductosPorUsuariosReporte
GO

CREATE PROCEDURE ListarComprasProductosPorUsuariosReporte
	@CodigoUsuario	INT,
	@NumeroAgencia	INT
AS
BEGIN

IF (@CodigoUsuario > 0)
BEGIN
	SELECT U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, P.NombreRazonSocial AS NombreCompletoProveedor,CP.Fecha, CP.MontoTotalCompra, CP.Observaciones
	FROM ComprasProductos CP INNER JOIN Usuarios U ON CP.CodigoUsuario = U.CodigoUsuario
	INNER JOIN Proveedores P ON P.CodigoProveedor = CP.CodigoProveedor
	WHERE U.CodigoUsuario = @CodigoUsuario AND CP.NumeroAgencia = @NumeroAgencia
	ORDER BY CP.NumeroCompraProducto
END
ELSE
	SELECT U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, P.NombreRazonSocial AS NombreCompletoProveedor,CP.Fecha, CP.MontoTotalCompra, CP.Observaciones
	FROM ComprasProductos CP INNER JOIN Usuarios U ON CP.CodigoUsuario = U.CodigoUsuario
	INNER JOIN Proveedores P ON P.CodigoProveedor = CP.CodigoProveedor
	WHERE CP.NumeroAgencia = @NumeroAgencia
	ORDER BY U.Paterno, U.Materno, U.Nombres, CP.NumeroCompraProducto
END
GO

DROP PROCEDURE ListarComprasProductosPorRangoFechasReporte
GO

CREATE PROCEDURE ListarComprasProductosPorRangoFechasReporte
	@FechaInicio DATETIME,
	@FechaFin	 DATETIME,
	@NumeroAgencia	INT
AS
BEGIN
	SELECT U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, P.NombreRazonSocial AS NombreCompletoProveedor,Cast(Floor(Cast(CP.Fecha As Float)) As DateTime) as FechaHoraCompra, CP.MontoTotalCompra, CP.Observaciones
	FROM ComprasProductos CP INNER JOIN Usuarios U ON CP.CodigoUsuario = U.CodigoUsuario
	INNER JOIN Proveedores P ON P.CodigoProveedor = CP.CodigoProveedor
	WHERE Cast(Floor(Cast(CP.Fecha As Float)) As DateTime) BETWEEN CAST(@FechaInicio AS CHAR(12)) AND CAST(@FechaFin as CHAR(12)) AND CP.NumeroAgencia = @NumeroAgencia
	ORDER BY CP.Fecha
END
GO

DROP PROCEDURE ListarComprasProductosPorRangoFechasUsuarioReporte
GO

CREATE PROCEDURE ListarComprasProductosPorRangoFechasUsuarioReporte
	@FechaInicio DATETIME,
	@FechaFin	 DATETIME,
	@CodigoUsuario	INT,
	@NumeroAgencia	INT
AS
BEGIN
	SELECT U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, P.NombreRazonSocial AS NombreCompletoProveedor, Cast(Floor(Cast(CP.Fecha As Float)) As DateTime) as FechaHoraCompra, CP.MontoTotalCompra, CP.Observaciones
	FROM ComprasProductos CP INNER JOIN Usuarios U ON CP.CodigoUsuario = U.CodigoUsuario
	INNER JOIN Proveedores P ON P.CodigoProveedor = CP.CodigoProveedor
	WHERE Cast(Floor(Cast(CP.Fecha As Float)) As DateTime) BETWEEN CAST(@FechaInicio AS CHAR(12)) AND CAST(@FechaFin as CHAR(12)) AND CP.NumeroAgencia = @NumeroAgencia
	AND U.CodigoUsuario = @CodigoUsuario
	ORDER BY CP.Fecha
END
GO


DROP PROCEDURE ListarComprasProductosPorProductosReporte
GO

CREATE PROCEDURE ListarComprasProductosPorProductosReporte
	@CodigoProducto CHAR(15),
	@NumeroAgencia	INT
AS
BEGIN
	IF(@CodigoProducto IS NOT NULL)
	BEGIN
		SELECT dbo.ObtenerNombreProducto(CPD.CodigoProducto) AS NombreProducto, U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, P.NombreRazonSocial AS NombreCompletoProveedor , CP.Fecha, CP.MontoTotalCompra, CP.Observaciones
		FROM ComprasProductos CP INNER JOIN ComprasProductosDetalle CPD ON CP.NumeroCompraProducto = CPD.NumeroCompraProducto
		INNER JOIN Usuarios U ON CP.CodigoUsuario = U.CodigoUsuario
		INNER JOIN Proveedores P ON P.CodigoProveedor = CP.CodigoProveedor
		WHERE CPD.CodigoProducto = @CodigoProducto AND CP.NumeroAgencia = @NumeroAgencia
		ORDER BY U.Paterno, U.Materno, U.Nombres
	END
	ELSE
	BEGIN
		SELECT dbo.ObtenerNombreProducto(CPD.CodigoProducto) AS NombreProducto, U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, P.NombreRazonSocial AS NombreCompletoProveedor , CP.Fecha, CP.MontoTotalCompra, CP.Observaciones
		FROM ComprasProductos CP INNER JOIN ComprasProductosDetalle CPD ON CP.NumeroCompraProducto = CPD.NumeroCompraProducto
		INNER JOIN Usuarios U ON CP.CodigoUsuario = U.CodigoUsuario
		INNER JOIN Proveedores P ON P.CodigoProveedor = CP.CodigoProveedor
		WHERE CP.NumeroAgencia = @NumeroAgencia
		ORDER BY dbo.ObtenerNombreProducto(CPD.CodigoProducto)
	END
END
GO


DROP PROCEDURE ListarComprasProductosPorProveedorReporte
GO

CREATE PROCEDURE ListarComprasProductosPorProveedorReporte
	@CodigoProveedor INT,
	@NumeroAgencia	INT
AS
BEGIN

IF (@CodigoProveedor > 0)
BEGIN
	SELECT U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, P.NombreRazonSocial AS NombreCompletoProveedor, CP.Fecha, CP.MontoTotalCompra, CP.Observaciones
	FROM ComprasProductos CP INNER JOIN Usuarios U ON CP.CodigoUsuario = U.CodigoUsuario
	INNER JOIN Proveedores P ON P.CodigoProveedor = CP.CodigoProveedor
	WHERE p.CodigoProveedor = @CodigoProveedor AND CP.NumeroAgencia = @NumeroAgencia
	ORDER BY CP.NumeroCompraProducto
END
ELSE
	SELECT U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, P.NombreRazonSocial AS NombreCompletoProveedor, CP.Fecha, CP.MontoTotalCompra, CP.Observaciones
	FROM ComprasProductos CP INNER JOIN Usuarios U ON CP.CodigoUsuario = U.CodigoUsuario
	INNER JOIN Proveedores P ON P.CodigoProveedor = CP.CodigoProveedor
	WHERE CP.NumeroAgencia = @NumeroAgencia
	ORDER BY U.Paterno, U.Materno, U.Nombres, CP.NumeroCompraProducto
END
GO

