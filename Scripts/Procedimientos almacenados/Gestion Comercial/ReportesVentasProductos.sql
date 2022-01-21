USE Doblones20
GO

DROP PROCEDURE ListarVentasProductosPorUsuariosReporte
GO

CREATE PROCEDURE ListarVentasProductosPorUsuariosReporte
	@CodigoUsuario	INT,
	@NumeroAgencia	INT
AS
BEGIN

IF (@CodigoUsuario > 0)
BEGIN
	SELECT U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, C.NombreCliente AS NombreCompletoCliente,VP.FechaHoraVenta, VP.MontoTotalVenta, VP.NumeroFactura, VP.Observaciones
	FROM VentasProductos VP INNER JOIN Usuarios U ON VP.CodigoUsuario = U.CodigoUsuario
	INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente
	WHERE U.CodigoUsuario = @CodigoUsuario AND VP.NumeroAgencia = @NumeroAgencia
	ORDER BY VP.NumeroVentaProducto
END
ELSE
	SELECT U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, C.NombreCliente AS NombreCompletoCliente,VP.FechaHoraVenta, VP.MontoTotalVenta, VP.NumeroFactura, VP.Observaciones
	FROM VentasProductos VP INNER JOIN Usuarios U ON VP.CodigoUsuario = U.CodigoUsuario
	INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente
	WHERE VP.NumeroAgencia = @NumeroAgencia
	ORDER BY U.Paterno, U.Materno, U.Nombres, VP.NumeroVentaProducto
END
GO

DROP PROCEDURE ListarVentasProductosPorRangoFechasReporte
GO

CREATE PROCEDURE ListarVentasProductosPorRangoFechasReporte
	@FechaInicio DATETIME,
	@FechaFin	 DATETIME,
	@NumeroAgencia	INT
AS
BEGIN
	SELECT U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, C.NombreCliente AS NombreCompletoCliente,Cast(Floor(Cast(VP.FechaHoraVenta As Float)) As DateTime) as FechaHoraVenta, VP.MontoTotalVenta, VP.NumeroFactura, VP.Observaciones
	FROM VentasProductos VP INNER JOIN Usuarios U ON VP.CodigoUsuario = U.CodigoUsuario
	INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente
	WHERE Cast(Floor(Cast(VP.FechaHoraVenta As Float)) As DateTime) BETWEEN CAST(@FechaInicio AS CHAR(12)) AND CAST(@FechaFin as CHAR(12)) AND VP.NumeroAgencia = @NumeroAgencia
	ORDER BY VP.FechaHoraVenta
END
GO

DROP PROCEDURE ListarVentasProductosPorRangoFechasUsuarioReporte
GO

CREATE PROCEDURE ListarVentasProductosPorRangoFechasUsuarioReporte
	@FechaInicio DATETIME,
	@FechaFin	 DATETIME,
	@CodigoUsuario	INT,
	@NumeroAgencia	INT
AS
BEGIN
	SELECT U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, C.NombreCliente AS NombreCompletoCliente,Cast(Floor(Cast(VP.FechaHoraVenta As Float)) As DateTime) as FechaHoraVenta, VP.MontoTotalVenta, VP.NumeroFactura, VP.Observaciones
	FROM VentasProductos VP INNER JOIN Usuarios U ON VP.CodigoUsuario = U.CodigoUsuario
	INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente
	WHERE Cast(Floor(Cast(VP.FechaHoraVenta As Float)) As DateTime) BETWEEN CAST(@FechaInicio AS CHAR(12)) AND CAST(@FechaFin as CHAR(12)) AND VP.NumeroAgencia = @NumeroAgencia
	AND U.CodigoUsuario = @CodigoUsuario
	ORDER BY VP.FechaHoraVenta
END
GO


DROP PROCEDURE ListarVentasProductosPorProductosReporte
GO

CREATE PROCEDURE ListarVentasProductosPorProductosReporte
	@CodigoProducto CHAR(15),
	@NumeroAgencia	INT
AS
BEGIN
	IF(@CodigoProducto IS NOT NULL)
	BEGIN
		SELECT dbo.ObtenerNombreProducto(VPD.CodigoProducto) AS NombreProducto, U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, C.NombreCliente AS NombreCompletoCliente,VP.FechaHoraVenta, VP.MontoTotalVenta, VP.NumeroFactura, VP.Observaciones
		FROM VentasProductos VP INNER JOIN VentasProductosDetalle VPD ON VP.NumeroVentaProducto = VPD.NumeroVentaProducto
		INNER JOIN Usuarios U ON VP.CodigoUsuario = U.CodigoUsuario
		INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente
		WHERE VPD.CodigoProducto = @CodigoProducto AND VP.NumeroAgencia = @NumeroAgencia
		ORDER BY U.Paterno, U.Materno, U.Nombres
	END
	ELSE
	BEGIN
		SELECT dbo.ObtenerNombreProducto(VPD.CodigoProducto) AS NombreProducto, U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, C.NombreCliente AS NombreCompletoCliente,VP.FechaHoraVenta, VP.MontoTotalVenta, VP.NumeroFactura, VP.Observaciones
		FROM VentasProductos VP INNER JOIN VentasProductosDetalle VPD ON VP.NumeroVentaProducto = VPD.NumeroVentaProducto
		INNER JOIN Usuarios U ON VP.CodigoUsuario = U.CodigoUsuario
		INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente
		WHERE VP.NumeroAgencia = @NumeroAgencia
		ORDER BY dbo.ObtenerNombreProducto(VPD.CodigoProducto)
	END
END
GO



DROP PROCEDURE ListarKARDEXProductosPorProductosReporte
GO

CREATE PROCEDURE ListarKARDEXProductosPorProductosReporte
	@CodigoProducto CHAR(15),
	@NumeroAgencia	INT
AS
BEGIN
	IF(@CodigoProducto IS NOT NULL)
	BEGIN
		SELECT dbo.ObtenerNombreProducto(VPD.CodigoProducto) AS NombreProducto, U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, C.NombreCliente AS NombreCompletoCliente,VP.FechaHoraVenta, VPD.CantidadVenta , VPD.PrecioUnitarioVenta
		FROM VentasProductos VP INNER JOIN VentasProductosDetalle VPD ON VP.NumeroVentaProducto = VPD.NumeroVentaProducto
		INNER JOIN Usuarios U ON VP.CodigoUsuario = U.CodigoUsuario
		INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente
		WHERE VPD.CodigoProducto = @CodigoProducto AND VP.NumeroAgencia = @NumeroAgencia
		ORDER BY U.Paterno, U.Materno, U.Nombres
	END
	ELSE
	BEGIN
		SELECT dbo.ObtenerNombreProducto(VPD.CodigoProducto) AS NombreProducto, U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, C.NombreCliente AS NombreCompletoCliente,VP.FechaHoraVenta, VPD.CantidadVenta , VPD.PrecioUnitarioVenta
		FROM VentasProductos VP INNER JOIN VentasProductosDetalle VPD ON VP.NumeroVentaProducto = VPD.NumeroVentaProducto
		INNER JOIN Usuarios U ON VP.CodigoUsuario = U.CodigoUsuario
		INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente
		WHERE VP.NumeroAgencia = @NumeroAgencia
		ORDER BY dbo.ObtenerNombreProducto(VPD.CodigoProducto), VP.NumeroVentaProducto
	END
END
GO


DROP PROCEDURE ListarVentasProductosPorClientesReporte
GO

CREATE PROCEDURE ListarVentasProductosPorClientesReporte
	@CodigoCliente INT,
	@NumeroAgencia	INT
AS
BEGIN

IF (@CodigoCliente > 0)
BEGIN
	SELECT U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, C.NombreCliente AS NombreCompletoCliente,VP.FechaHoraVenta, VP.MontoTotalVenta, VP.NumeroFactura, VP.Observaciones
	FROM VentasProductos VP INNER JOIN Usuarios U ON VP.CodigoUsuario = U.CodigoUsuario
	INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente
	WHERE C.CodigoCliente = @CodigoCliente AND VP.NumeroAgencia = @NumeroAgencia
	ORDER BY VP.NumeroVentaProducto
END
ELSE
	SELECT U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, C.NombreCliente AS NombreCompletoCliente,VP.FechaHoraVenta, VP.MontoTotalVenta, VP.NumeroFactura, VP.Observaciones
	FROM VentasProductos VP INNER JOIN Usuarios U ON VP.CodigoUsuario = U.CodigoUsuario
	INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente
	WHERE VP.NumeroAgencia = @NumeroAgencia
	ORDER BY U.Paterno, U.Materno, U.Nombres, VP.NumeroVentaProducto
END
GO


DROP PROCEDURE ListarVentasProductosCreditosReporte
GO

CREATE PROCEDURE ListarVentasProductosCreditosReporte
	@NumeroAgencia	INT	
AS
BEGIN
	SELECT U.Paterno + ' ' +U.Materno + ' ' +U.Nombres AS NombreCompletoUsuario, C.NombreCliente AS NombreCompletoCliente,VP.FechaHoraVenta, VP.MontoTotalVenta, VP.NumeroFactura, VP.NumeroCredito, VP.Observaciones
	FROM VentasProductos VP INNER JOIN Usuarios U ON VP.CodigoUsuario = U.CodigoUsuario
	INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente
	WHERE VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroCredito IS NOT NULL
	ORDER BY VP.NumeroCredito, U.Paterno, U.Materno, U.Nombres, VP.NumeroVentaProducto
END
GO


DROP VIEW ProductosMasVendidos
GO

CREATE VIEW ProductosMasVendidos
AS
	SELECT vp.NumeroAgencia, dbo.ObtenerNombreProducto(VPD.CodigoProducto) AS NombreProducto, VPD.CodigoProducto, COUNT(VPD.CodigoProducto) AS NroVecesVendido, SUM(VPD.CantidadVenta) AS TotalCantidadVendida
	FROM VentasProductos VP INNER JOIN VentasProductosDetalle VPD ON VP.NumeroAgencia = VPD.NumeroAgencia AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
	GROUP BY vp.NumeroAgencia, VPD.CodigoProducto
GO


DROP PROCEDURE ListarProductosMasVendidosReporte
GO

CREATE PROCEDURE ListarProductosMasVendidosReporte
	@NumeroAgencia	INT,
	@Top			INT
AS
BEGIN
	IF (@Top is null)
		SET @Top = 10
	SET ROWCOUNT @Top
	SELECT * 
	FROM ProductosMasVendidos
	WHERE NumeroAgencia = @NumeroAgencia	
	ORDER BY NroVecesVendido DESC	
	SET ROWCOUNT 0
END
GO


DROP PROCEDURE ListarProductosMenosVendidosReporte
GO

CREATE PROCEDURE ListarProductosMenosVendidosReporte
	@NumeroAgencia	INT,
	@Top			INT
AS
BEGIN
	IF (@Top is null)
		SET @Top = 10
	SET ROWCOUNT @top 
	SELECT * 
	FROM ProductosMasVendidos
	WHERE NumeroAgencia = @NumeroAgencia	
	ORDER BY NroVecesVendido
	SET ROWCOUNT 0 
END
GO

DROP VIEW ProductosMasComprados
GO

CREATE VIEW ProductosMasComprados
AS
	SELECT cp.NumeroAgencia, dbo.ObtenerNombreProducto(CPD.CodigoProducto) AS NombreProducto, CPD.CodigoProducto, COUNT(CPD.CodigoProducto) AS NroVecesComprado, SUM(CPD.CantidadCompra) AS TotalCantidadComprada
	FROM ComprasProductos CP INNER JOIN ComprasProductosDetalle CPD ON CP.NumeroAgencia = CPD.NumeroAgencia AND CP.NumeroCompraProducto = CPD.NumeroCompraProducto
	GROUP BY cp.NumeroAgencia, CPD.CodigoProducto
GO


DROP PROCEDURE ListarProductosMasCompradosReporte
GO

CREATE PROCEDURE ListarProductosMasCompradosReporte
	@NumeroAgencia	INT,
	@Top			INT
AS
BEGIN
	IF (@Top is null)
		SET @Top = 10
	SELECT TOP (@Top) * 
	FROM ProductosMasComprados
	WHERE NumeroAgencia = @NumeroAgencia	
	ORDER BY NroVecesComprado DESC
	
END
GO

DROP PROCEDURE ListarProductosMenosCompradosReporte
GO

CREATE PROCEDURE ListarProductosMenosCompradosReporte
	@NumeroAgencia	INT,
	@Top			INT
AS
BEGIN
	IF (@Top is null)
		SET @Top = 10
	SELECT TOP (@Top) * 
	FROM ProductosMasComprados
	WHERE NumeroAgencia = @NumeroAgencia	
	ORDER BY NroVecesComprado	
END
GO

--SELECT * FROM SistemaInterfaces

--SELECT * FROM Usuarios

--select * from SistemaMenuPrincipal
--where CodigoElementoMenuPadre = 40


--select * from SistemaGrupos
--select * from SistemaInterfaces
--select * from SistemaMenuPrincipal
--select * from UsuariosAgenciasMenuPrincipal
--select * from UsuariosAgenciasPermisosInterfaces

