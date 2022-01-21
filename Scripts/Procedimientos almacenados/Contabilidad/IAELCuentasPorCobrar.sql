USE Doblones20


DROP PROC InsertarCuentaPorCobrar
GO

CREATE PROC InsertarCuentaPorCobrar
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
	INSERT INTO dbo.CuentasPorCobrar (NumeroAgencia, FechaHoraRegistro, NumeroConcepto, CodigoProveedor, CodigoMoneda, Monto, FechaLimite, CodigoEstado, Observaciones, CodigoUsuario, NumeroAsiento)
	VALUES (@NumeroAgencia, @FechaHoraRegistro, @NumeroConcepto, @CodigoProveedor, @CodigoMoneda, @Monto, @FechaLimite, @CodigoEstado, @Observaciones, @CodigoUsuario, @NumeroAsiento)
END
GO


DROP PROC ActualizarCuentaPorCobrar
GO

CREATE PROC ActualizarCuentaPorCobrar
@NumeroCuentaPorCobrar	INT,
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
	UPDATE dbo.CuentasPorCobrar
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
	WHERE NumeroCuentaPorCobrar = @NumeroCuentaPorCobrar
END
GO



DROP PROC EliminarCuentaPorCobrar
GO

CREATE PROC EliminarCuentaPorCobrar
@NumeroCuentaPorCobrar		INT
AS
BEGIN
	DELETE FROM dbo.CuentasPorCobrar WHERE NumeroCuentaPorCobrar = @NumeroCuentaPorCobrar
END
GO



DROP PROC ListarCuentasPorCobrar
GO

CREATE PROC ListarCuentasPorCobrar
AS
BEGIN
	SELECT NumeroCuentaPorCobrar, NumeroAgencia, FechaHoraRegistro, NumeroConcepto, CodigoProveedor, CodigoMoneda, Monto, FechaLimite, CodigoEstado, Observaciones, CodigoUsuario, NumeroAsiento
	FROM dbo.CuentasPorCobrar
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


DROP PROC ListarCuentasPorCobrarNumeroCuenta
GO

CREATE PROC ListarCuentasPorCobrarNumeroCuenta
@NumeroCuentaPorCobrar	INT
AS
BEGIN
	SELECT NumeroCuentaPorCobrar, NumeroAgencia, FechaHoraRegistro, NumeroConcepto, CodigoProveedor, CodigoMoneda, Monto, FechaLimite, CodigoEstado, Observaciones, CodigoUsuario, NumeroAsiento
	FROM dbo.CuentasPorCobrar
	WHERE NumeroCuentaPorCobrar = @NumeroCuentaPorCobrar
END
GO


DROP PROC ListarCuentasPorCobrarBusqueda
GO

CREATE PROC ListarCuentasPorCobrarBusqueda
@Palabra	VARCHAR(128),
@Fecha1		DATETIME,
@Fecha2		DATETIME, 
@Estado1	CHAR(1),
@Estado2	CHAR(1)
AS
BEGIN
	SELECT CPC.NumeroCuentaPorCobrar , A.NumeroAgencia, A.NombreAgencia AS 'Nombre Agencia', CPC.FechaHoraRegistro AS 'Fecha/Hora de Registro', C.NumeroConcepto, C.Concepto, P.CodigoProveedor, P.NombreRazonSocial AS 'Proveedor', M.CodigoMoneda, M.NombreMoneda AS 'Moneda', CPC.Monto, CPC.FechaLimite AS 'Fecha Límite', CASE CPC.CodigoEstado WHEN 'P' THEN 'Pendiente' WHEN 'C' THEN 'Cancelado' END AS 'Estado', CPC.Observaciones, CPC.CodigoUsuario, CPC.NumeroAsiento
	FROM dbo.CuentasPorCobrar CPC INNER JOIN Proveedores P ON CPC.CodigoProveedor = P.CodigoProveedor
	INNER JOIN Monedas M ON CPC.CodigoMoneda = M.CodigoMoneda
	INNER JOIN Agencias A ON CPC.NumeroAgencia = A.NumeroAgencia
	INNER JOIN Conceptos C ON CPC.NumeroConcepto = C.NumeroConcepto
	WHERE ((CONVERT(VARCHAR(128), CPC.NumeroCuentaPorCobrar) LIKE '%'+@Palabra+'%') OR (CONVERT(VARCHAR(128), A.NombreAgencia) LIKE '%'+@Palabra+'%') OR (P.NombreRazonSocial LIKE '%'+@Palabra+'%') OR
			(CONVERT(VARCHAR(128), CPC.Observaciones) LIKE '%'+@Palabra+'%') OR (C.Concepto LIKE '%'+@Palabra+'%') OR (CONVERT(VARCHAR(128), CPC.Monto) LIKE '%'+@Palabra+'%')) AND 
			((CONVERT(DATETIME, CONVERT(VARCHAR(10), CPC.FechaHoraRegistro, 21), 21) BETWEEN CONVERT(DATETIME, @Fecha1, 21) AND CONVERT(DATETIME, @Fecha2, 21))) AND ((CPC.CodigoEstado = @Estado1) OR (CPC.CodigoEstado = @Estado2)) OR
			(CPC.NumeroCuentaPorCobrar = (SELECT MAX(CPD.NumeroCuentaPorCobrar) FROM dbo.CuentasPorCobrarCobros CPD WHERE (CONVERT(DATETIME, CONVERT(VARCHAR(10), CPD.FechaHoraCobro, 21), 21) BETWEEN CONVERT(DATETIME, @Fecha1, 21) AND (CONVERT(DATETIME, @Fecha2, 21))) AND (CONVERT(VARCHAR(128),CPD.Monto) LIKE '%'+@Palabra+'%')))			
			
END
GO

DROP PROC ReporteCuentasPorCobrar
GO
CREATE PROC ReporteCuentasPorCobrar
AS
BEGIN
	SELECT CPC.NumeroCuentaPorCobrar , A.NumeroAgencia, A.NombreAgencia, CPC.FechaHoraRegistro, C.NumeroConcepto, C.Concepto, P.CodigoProveedor, P.NombreRazonSocial, M.CodigoMoneda, M.NombreMoneda, CPC.Monto, CPC.FechaLimite, CASE CPC.CodigoEstado WHEN 'P' THEN 'Pendiente' WHEN 'C' THEN 'Cancelado' END AS 'Estado', 
			CC.FechaHoraCobro, CC.Monto AS 'Monto Cobro',
			CPC.Observaciones, CC.CodigoUsuario, U.Nombres, U.Paterno, U.Materno
	FROM dbo.CuentasPorCobrar CPC INNER JOIN Proveedores P ON CPC.CodigoProveedor = P.CodigoProveedor
	INNER JOIN Monedas M ON CPC.CodigoMoneda = M.CodigoMoneda
	INNER JOIN Agencias A ON CPC.NumeroAgencia = A.NumeroAgencia
	INNER JOIN Conceptos C ON CPC.NumeroConcepto = C.NumeroConcepto
	INNER JOIN CuentasPorCobrarCobros CC ON CPC.NumeroCuentaPorCobrar = CC.NumeroCuentaPorCobrar
	INNER JOIN Usuarios U ON CC.CodigoUsuario = U.CodigoUsuario
	--GROUP BY CPC.NumeroCuentaPorCobrar , A.NumeroAgencia, A.NombreAgencia, CPC.FechaHoraRegistro, C.NumeroConcepto, C.Concepto, P.CodigoProveedor, P.NombreRazonSocial, M.CodigoMoneda, M.NombreMoneda, CPC.Monto, CPC.FechaLimite, CPC.CodigoEstado, CPC.Observaciones, CC.CodigoUsuario, U.Nombres, U.Paterno, U.Materno
END
GO

DROP PROC ReporteCuentasPorCobrarNumero
GO
CREATE PROC ReporteCuentasPorCobrarNumero
@NumeroCuentaPorCobrar	INT
AS
BEGIN
	SELECT CPC.NumeroCuentaPorCobrar , A.NumeroAgencia, A.NombreAgencia, CPC.FechaHoraRegistro, C.NumeroConcepto, C.Concepto, P.CodigoProveedor, P.NombreRazonSocial, M.CodigoMoneda, M.NombreMoneda, CPC.Monto, CPC.FechaLimite, CASE CPC.CodigoEstado WHEN 'P' THEN 'Pendiente' WHEN 'C' THEN 'Cancelado' END AS 'Estado', 
			CC.FechaHoraCobro, CC.Monto AS 'Monto Cobro',
			CPC.Observaciones, CC.CodigoUsuario, U.Nombres, U.Paterno, U.Materno
	FROM dbo.CuentasPorCobrar CPC INNER JOIN Proveedores P ON CPC.CodigoProveedor = P.CodigoProveedor
	INNER JOIN Monedas M ON CPC.CodigoMoneda = M.CodigoMoneda
	INNER JOIN Agencias A ON CPC.NumeroAgencia = A.NumeroAgencia
	INNER JOIN Conceptos C ON CPC.NumeroConcepto = C.NumeroConcepto
	INNER JOIN CuentasPorCobrarCobros CC ON CPC.NumeroCuentaPorCobrar = CC.NumeroCuentaPorCobrar
	INNER JOIN Usuarios U ON CC.CodigoUsuario = U.CodigoUsuario
	WHERE CPC.NumeroCuentaPorCobrar = @NumeroCuentaPorCobrar
	--GROUP BY CPC.NumeroCuentaPorCobrar , A.NumeroAgencia, A.NombreAgencia, CPC.FechaHoraRegistro, C.NumeroConcepto, C.Concepto, P.CodigoProveedor, P.NombreRazonSocial, M.CodigoMoneda, M.NombreMoneda, CPC.Monto, CPC.FechaLimite, CPC.CodigoEstado, CPC.Observaciones, CC.CodigoUsuario, U.Nombres, U.Paterno, U.Materno
END
GO

















DROP PROC InsertarCuentasPorCobrarCobros
GO
CREATE PROC InsertarCuentasPorCobrarCobros
@NumeroCuentaPorCobrar	INT,
@FechaHoraCobro			DATETIME,
@Monto					DECIMAL(10,2),
@CodigoUsuario			INT
AS
BEGIN
	INSERT INTO dbo.CuentasPorCobrarCobros(NumeroCuentaPorCobrar, FechaHoraCobro, Monto, CodigoUsuario)
	VALUES (@NumeroCuentaPorCobrar, @FechaHoraCobro, @Monto, @CodigoUsuario)
END
GO


DROP PROC ActualizarCuentasPorCobrarCobros
GO
CREATE PROC ActualizarCuentasPorCobrarCobros
@NumeroCobro			INT,
@FechaHoraCobro			DATETIME,
@Monto					DECIMAL(10,2),
@CodigoUsuario			INT
AS
BEGIN
	UPDATE dbo.CuentasPorCobrarCobros
	SET	FechaHoraCobro = @FechaHoraCobro,
		Monto = @Monto,
		CodigoUsuario = @CodigoUsuario
	WHERE NumeroCobro = @NumeroCobro
END
GO


DROP PROC EliminarCuentasPorCobrarCobros
GO
CREATE PROC EliminarCuentasPorCobrarCobros
@NumeroCobro		INT
AS
BEGIN
	DELETE FROM dbo.CuentasPorCobrarCobros WHERE NumeroCobro = @NumeroCobro
END
GO


DROP PROC EliminarCuentasPorCobrarCobrosNumeroCuenta
GO
CREATE PROC EliminarCuentasPorCobrarCobrosNumeroCuenta
@NumeroCuentaPorCobrar		INT
AS
BEGIN
	DELETE FROM dbo.CuentasPorCobrarCobros WHERE NumeroCuentaPorCobrar = @NumeroCuentaPorCobrar
END
GO


DROP PROC ListarCuentasPorCobrarCobros
GO
CREATE PROC ListarCuentasPorCobrarCobros
@NumeroCuentaPorCobrar		INT
AS
BEGIN
	SELECT 	NumeroCuentaPorCobrar, NumeroCobro, FechaHoraCobro, Monto, CodigoUsuario
	FROM dbo.CuentasPorCobrarCobros
	WHERE NumeroCuentaPorCobrar = @NumeroCuentaPorCobrar
END
GO

DROP PROC ListarCuentaPorCobrarCobro
GO
CREATE PROC ListarCuentaPorCobrarCobro
@NumeroCobro		INT
AS
BEGIN
	SELECT 	NumeroCuentaPorCobrar, NumeroCobro, FechaHoraCobro, Monto, CodigoUsuario
	FROM dbo.CuentasPorCobrarCobros
	WHERE NumeroCobro = @NumeroCobro
END
GO


DROP PROC ListarCuentasPorCobrarCobrosDetallado
GO
CREATE PROC ListarCuentasPorCobrarCobrosDetallado
@NumeroCuentaPorCobrar		INT
AS
BEGIN
	SELECT 	C.NumeroCuentaPorCobrar, C.NumeroCobro, C.FechaHoraCobro, C.Monto, U.CodigoUsuario, U.Nombres, U.Paterno, U.Materno
	FROM dbo.CuentasPorCobrarCobros C INNER JOIN dbo.Usuarios U ON C.CodigoUsuario = U.CodigoUsuario
	WHERE C.NumeroCuentaPorCobrar = @NumeroCuentaPorCobrar
END
GO