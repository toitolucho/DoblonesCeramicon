USE Doblones20


DROP PROC InsertarCuentaPorPagar
GO

CREATE PROC InsertarCuentaPorPagar
@NumeroAgencia			INT,
@FechaHoraRegistro		DATETIME,
@CodigoProveedor		INT,
@NumeroConcepto			INT,
@CodigoMoneda			TINYINT,
@Monto					DECIMAL(10,2),
@FechaLimite			DATETIME,
@CodigoEstado			CHAR(1),
@Observaciones			TEXT,
@CodigoUsuario			INT,
@NumeroAsiento			INT
AS
BEGIN
	INSERT INTO dbo.CuentasPorPagar (NumeroAgencia, FechaHoraRegistro, NumeroConcepto, CodigoProveedor, CodigoMoneda, Monto, FechaLimite, CodigoEstado, Observaciones, CodigoUsuario, NumeroAsiento)
	VALUES (@NumeroAgencia, @FechaHoraRegistro, @NumeroConcepto, @CodigoProveedor, @CodigoMoneda, @Monto, @FechaLimite, @CodigoEstado, @Observaciones, @CodigoUsuario, @NumeroAsiento)
END
GO


DROP PROC ActualizarCuentaPorPagar
GO

CREATE PROC ActualizarCuentaPorPagar
@NumeroCuentaPorPagar	INT,
@NumeroAgencia			INT,
@FechaHoraRegistro		DATETIME,
@NumeroConcepto			INT,
@CodigoProveedor		INT,
@CodigoMoneda			TINYINT,
@Monto					DECIMAL(10,2),
@FechaLimite			DATETIME,
@CodigoEstado			CHAR(1),
@Observaciones			TEXT,
@CodigoUsuario			INT,
@NumeroAsiento			INT
AS
BEGIN
	UPDATE dbo.CuentasPorPagar
	SET	NumeroAgencia = @NumeroAgencia,
		FechaHoraRegistro = @FechaHoraRegistro,
		NumeroConcepto = @NumeroConcepto,
		CodigoProveedor = @CodigoProveedor,
		CodigoMoneda = @CodigoMoneda,
		Monto = @Monto,		
		FechaLimite = @FechaLimite,
		CodigoEstado = @CodigoEstado,
		Observaciones = @Observaciones,
		CodigoUsuario = @CodigoUsuario,
		NumeroAsiento = @NumeroAsiento
	WHERE NumeroCuentaPorPagar = @NumeroCuentaPorPagar
END
GO



DROP PROC EliminarCuentaPorPagar
GO

CREATE PROC EliminarCuentaPorPagar
@NumeroCuentaPorPagar		INT
AS
BEGIN
	DELETE FROM dbo.CuentasPorPagar WHERE NumeroCuentaPorPagar = @NumeroCuentaPorPagar
END
GO



DROP PROC ListarCuentasPorPagar
GO

CREATE PROC ListarCuentasPorPagar
AS
BEGIN
	SELECT NumeroCuentaPorPagar, NumeroAgencia, FechaHoraRegistro, NumeroConcepto, CodigoProveedor, CodigoMoneda, Monto, FechaLimite, CodigoEstado, Observaciones, CodigoUsuario, NumeroAsiento
	FROM dbo.CuentasPorPagar
END
GO


/*
DROP PROC ListarCuentasPorPagarEstado
GO

CREATE PROC ListarCuentasPorPagarEstado
@Estado		VARCHAR(9)
AS
BEGIN
	SELECT NumeroCuentaPorPagar, NumeroAgencia, FechaHoraRegistro, CodigoProveedor, CodigoMoneda, Monto, FechaLimite, CodigoEstado, Observaciones, CodigoUsuario, NumeroAsiento
	FROM dbo.CuentasPorPagar
	WHERE CodigoEstado = @Estado
END
GO
*/


DROP PROC ListarCuentasPorPagarNumeroCuenta
GO

CREATE PROC ListarCuentasPorPagarNumeroCuenta
@NumeroCuentaPorPagar	INT
AS
BEGIN
	SELECT NumeroCuentaPorPagar, NumeroAgencia, FechaHoraRegistro, NumeroConcepto, CodigoProveedor, CodigoMoneda, Monto, FechaLimite, CodigoEstado, Observaciones, CodigoUsuario, NumeroAsiento
	FROM dbo.CuentasPorPagar
	WHERE NumeroCuentaPorPagar = @NumeroCuentaPorPagar
END
GO


DROP PROC ListarCuentasPorPagarBusqueda
GO

CREATE PROC ListarCuentasPorPagarBusqueda
@Palabra	VARCHAR(128),
@Fecha1		DATETIME,
@Fecha2		DATETIME, 
@Estado1	CHAR(1),
@Estado2	CHAR(1)
AS
BEGIN
	SELECT CPP.NumeroCuentaPorPagar , A.NumeroAgencia, A.NombreAgencia AS 'Nombre Agencia', CPP.FechaHoraRegistro AS 'Fecha/Hora de Registro', C.NumeroConcepto, C.Concepto, P.CodigoProveedor, P.NombreRazonSocial AS 'Proveedor', M.CodigoMoneda, M.NombreMoneda AS 'Moneda', CPP.Monto, CASE WHEN CPP.FechaLimite IS NULL THEN GETDATE() ELSE CPP.FechaLimite END AS 'Fecha Límite', CASE CPP.CodigoEstado WHEN 'P' THEN 'Pendiente' WHEN 'C' THEN 'Cancelado' END AS 'Estado', CPP.Observaciones, CPP.CodigoUsuario, CPP.NumeroAsiento, P.NombreRazonSocial
	FROM dbo.CuentasPorPagar CPP INNER JOIN Proveedores P ON CPP.CodigoProveedor = P.CodigoProveedor
	INNER JOIN Monedas M ON CPP.CodigoMoneda = M.CodigoMoneda
	INNER JOIN Agencias A ON CPP.NumeroAgencia = A.NumeroAgencia
	INNER JOIN Conceptos C ON CPP.NumeroConcepto = C.NumeroConcepto
	WHERE ((CONVERT(VARCHAR(128), CPP.NumeroCuentaPorPagar) LIKE '%'+@Palabra+'%') OR (CONVERT(VARCHAR(128), A.NombreAgencia) LIKE '%'+@Palabra+'%') OR (P.NombreRazonSocial LIKE '%'+@Palabra+'%') OR
			(CONVERT(VARCHAR(128), CPP.Observaciones) LIKE '%'+@Palabra+'%') OR (C.Concepto LIKE '%'+@Palabra+'%') OR (CONVERT(VARCHAR(128), CPP.Monto) LIKE '%'+@Palabra+'%')) AND 
			((CONVERT(DATETIME, CONVERT(VARCHAR(10), CPP.FechaHoraRegistro, 21), 21) BETWEEN CONVERT(DATETIME, @Fecha1, 21) AND CONVERT(DATETIME, @Fecha2, 21))) AND ((CPP.CodigoEstado = @Estado1) OR (CPP.CodigoEstado = @Estado2)) OR
			(CPP.NumeroCuentaPorPagar = (SELECT MAX(CPD.NumeroCuentaPorPagar) FROM dbo.CuentasPorPagarPagos CPD WHERE (CONVERT(DATETIME, CONVERT(VARCHAR(10), CPD.FechaHoraPago, 21), 21) BETWEEN CONVERT(DATETIME, @Fecha1, 21) AND (CONVERT(DATETIME, @Fecha2, 21))) AND (CONVERT(VARCHAR(128),CPD.Monto) LIKE '%'+@Palabra+'%')))			
END
GO

DROP PROC ListarCuentasPorPagarBusquedaNumCtaXPagar
GO
CREATE PROC ListarCuentasPorPagarBusquedaNumCtaXPagar
@NumCtaXPagar	INT
AS
BEGIN
	SELECT CPP.NumeroCuentaPorPagar , A.NumeroAgencia, A.NombreAgencia AS 'Nombre Agencia', CPP.FechaHoraRegistro AS 'Fecha/Hora de Registro', C.NumeroConcepto, C.Concepto, P.CodigoProveedor, P.NombreRazonSocial AS 'Proveedor', M.CodigoMoneda, M.NombreMoneda AS 'Moneda', CPP.Monto, CASE WHEN CPP.FechaLimite IS NULL THEN GETDATE() ELSE CPP.FechaLimite END AS 'Fecha Límite', CASE CPP.CodigoEstado WHEN 'P' THEN 'Pendiente' WHEN 'C' THEN 'Cancelado' END AS 'Estado', CPP.Observaciones, CPP.CodigoUsuario, CPP.NumeroAsiento, P.NombreRazonSocial
	FROM dbo.CuentasPorPagar CPP INNER JOIN Proveedores P ON CPP.CodigoProveedor = P.CodigoProveedor
	INNER JOIN Monedas M ON CPP.CodigoMoneda = M.CodigoMoneda
	INNER JOIN Agencias A ON CPP.NumeroAgencia = A.NumeroAgencia
	INNER JOIN Conceptos C ON CPP.NumeroConcepto = C.NumeroConcepto
	WHERE CPP.NumeroCuentaPorPagar = @NumCtaXPagar		
END
GO



DROP PROC ReporteCuentasPorPagar
GO
CREATE PROC ReporteCuentasPorPagar
AS
BEGIN
	SELECT CPC.NumeroCuentaPorPagar , A.NumeroAgencia, A.NombreAgencia, CPC.FechaHoraRegistro, C.NumeroConcepto, C.Concepto, P.CodigoProveedor, P.NombreRazonSocial, M.CodigoMoneda, M.NombreMoneda, CPC.Monto, CPC.FechaLimite, CASE CPC.CodigoEstado WHEN 'P' THEN 'Pendiente' WHEN 'C' THEN 'Cancelado' END AS 'Estado', 
			CC.FechaHoraPago, CC.Monto AS 'Monto Pago',
			CPC.Observaciones, CC.CodigoUsuario, U.Nombres, U.Paterno, U.Materno
	FROM dbo.CuentasPorPagar CPC INNER JOIN Proveedores P ON CPC.CodigoProveedor = P.CodigoProveedor
	INNER JOIN Monedas M ON CPC.CodigoMoneda = M.CodigoMoneda
	INNER JOIN Agencias A ON CPC.NumeroAgencia = A.NumeroAgencia
	INNER JOIN Conceptos C ON CPC.NumeroConcepto = C.NumeroConcepto
	INNER JOIN CuentasPorPagarPagos CC ON CPC.NumeroCuentaPorPagar = CC.NumeroCuentaPorPagar
	INNER JOIN Usuarios U ON CC.CodigoUsuario = U.CodigoUsuario
	--GROUP BY CPC.NumeroCuentaPorCobrar , A.NumeroAgencia, A.NombreAgencia, CPC.FechaHoraRegistro, C.NumeroConcepto, C.Concepto, P.CodigoProveedor, P.NombreRazonSocial, M.CodigoMoneda, M.NombreMoneda, CPC.Monto, CPC.FechaLimite, CPC.CodigoEstado, CPC.Observaciones, CC.CodigoUsuario, U.Nombres, U.Paterno, U.Materno
END
GO

DROP PROC ReporteCuentasPorPagarNumero
GO
CREATE PROC ReporteCuentasPorPagarNumero
@NumeroCuentaPorPagar	INT
AS
BEGIN
	SELECT CPC.NumeroCuentaPorPagar , A.NumeroAgencia, A.NombreAgencia, CPC.FechaHoraRegistro, C.NumeroConcepto, C.Concepto, P.CodigoProveedor, P.NombreRazonSocial, M.CodigoMoneda, M.NombreMoneda, CPC.Monto, CPC.FechaLimite, CASE CPC.CodigoEstado WHEN 'P' THEN 'Pendiente' WHEN 'C' THEN 'Cancelado' END AS 'Estado', 
			CC.FechaHoraPago, CC.Monto AS 'Monto Pago',
			CPC.Observaciones, CC.CodigoUsuario, U.Nombres, U.Paterno, U.Materno
	FROM dbo.CuentasPorPagar CPC INNER JOIN Proveedores P ON CPC.CodigoProveedor = P.CodigoProveedor
	INNER JOIN Monedas M ON CPC.CodigoMoneda = M.CodigoMoneda
	INNER JOIN Agencias A ON CPC.NumeroAgencia = A.NumeroAgencia
	INNER JOIN Conceptos C ON CPC.NumeroConcepto = C.NumeroConcepto
	INNER JOIN CuentasPorPagarPagos CC ON CPC.NumeroCuentaPorPagar = CC.NumeroCuentaPorPagar
	INNER JOIN Usuarios U ON CC.CodigoUsuario = U.CodigoUsuario
	WHERE CPC.NumeroCuentaPorPagar = @NumeroCuentaPorPagar
	--GROUP BY CPC.NumeroCuentaPorCobrar , A.NumeroAgencia, A.NombreAgencia, CPC.FechaHoraRegistro, C.NumeroConcepto, C.Concepto, P.CodigoProveedor, P.NombreRazonSocial, M.CodigoMoneda, M.NombreMoneda, CPC.Monto, CPC.FechaLimite, CPC.CodigoEstado, CPC.Observaciones, CC.CodigoUsuario, U.Nombres, U.Paterno, U.Materno
END
GO















DROP PROC InsertarCuentasPorPagarPagos
GO
CREATE PROC InsertarCuentasPorPagarPagos
@NumeroCuentaPorPagar	INT,
@FechaHoraPago			DATETIME,
@Monto					DECIMAL(10,2),
@CodigoUsuario			INT,
@NumeroAsiento			INT
AS
BEGIN
	INSERT INTO dbo.CuentasPorPagarPagos(NumeroCuentaPorPagar, FechaHoraPago, Monto, CodigoUsuario, NumeroAsiento)
	VALUES (@NumeroCuentaPorPagar, @FechaHoraPago, @Monto, @CodigoUsuario, @NumeroAsiento)
END
GO


DROP PROC ActualizarCuentasPorPagarPagos
GO
CREATE PROC ActualizarCuentasPorPagarPagos
@NumeroPago				INT,
@FechaHoraPago			DATETIME,
@Monto					DECIMAL(10,2),
@CodigoUsuario			INT
AS
BEGIN
	UPDATE dbo.CuentasPorPagarPagos
	SET	FechaHoraPago = @FechaHoraPago,
		Monto = @Monto,
		CodigoUsuario = CodigoUsuario
	WHERE NumeroPago = @NumeroPago
END
GO


DROP PROC EliminarCuentasPorPagarPagos
GO
CREATE PROC EliminarCuentasPorPagarPagos
@NumeroPago		INT
AS
BEGIN
	DELETE FROM dbo.CuentasPorPagarPagos WHERE NumeroPago = @NumeroPago
END
GO


DROP PROC EliminarCuentasPorPagarPagosNumeroCuenta
GO
CREATE PROC EliminarCuentasPorPagarPagosNumeroCuenta
@NumeroCuentaPorPagar		INT
AS
BEGIN
	DELETE FROM dbo.CuentasPorPagarPagos WHERE NumeroCuentaPorPagar = @NumeroCuentaPorPagar
END
GO


DROP PROC ListarCuentasPorPagarPagos
GO
CREATE PROC ListarCuentasPorPagarPagos
@NumeroCuentaPorPagar		INT
AS
BEGIN
	SELECT 	NumeroCuentaPorPagar, NumeroPago, FechaHoraPago, Monto, CodigoUsuario, NumeroAsiento
	FROM dbo.CuentasPorPagarPagos
	WHERE NumeroCuentaPorPagar = @NumeroCuentaPorPagar
END
GO

DROP PROC ListarCuentaPorPagarPago
GO
CREATE PROC ListarCuentaPorPagarPago
@NumeroPago		INT
AS
BEGIN
	SELECT 	NumeroCuentaPorPagar, NumeroPago, FechaHoraPago, Monto, CodigoUsuario, NumeroAsiento
	FROM dbo.CuentasPorPagarPagos
	WHERE NumeroPago = @NumeroPago
END
GO

DROP PROC ListarCuentasPorPagarPagosDetallado
GO
CREATE PROC ListarCuentasPorPagarPagosDetallado
@NumeroCuentaPorPagar		INT
AS
BEGIN
	SELECT 	C.NumeroCuentaPorPagar, C.NumeroPago, C.FechaHoraPago, C.Monto, U.CodigoUsuario, U.Nombres, U.Paterno, U.Materno
	FROM dbo.CuentasPorPagarPagos C INNER JOIN dbo.Usuarios U ON C.CodigoUsuario = U.CodigoUsuario
	WHERE C.NumeroCuentaPorPagar = @NumeroCuentaPorPagar
END
GO








