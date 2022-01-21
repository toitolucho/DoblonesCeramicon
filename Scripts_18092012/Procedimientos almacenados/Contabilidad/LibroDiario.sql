USE Doblones20
GO


DROP VIEW VistaLibroDiarioReporte
GO
CREATE VIEW VistaLibroDiarioReporte
AS
	SELECT A.NumeroAsiento, A.Fecha, A.Hora, A.Glosa,
			PC.NumeroCuenta, PC.NombreCuenta, AD.Debe, AD.Haber
	FROM dbo.Asientos A INNER JOIN dbo.AsientosDetalle AD
	ON A.NumeroAsiento = AD.NumeroAsiento INNER JOIN dbo.PlanCuentas PC
	ON AD.NumeroCuenta = PC.NumeroCuenta
GO



DROP PROCEDURE ListarLibroDiarioFechaEstado
GO
CREATE PROCEDURE ListarLibroDiarioFechaEstado
@Fecha	DATETIME,
@Estado VARCHAR(10)
AS
BEGIN
	SELECT A.NumeroAsiento, A.Fecha, A.Hora, A.Glosa,
			PC.NumeroCuenta, PC.NombreCuenta, AD.Debe, AD.Haber
	FROM dbo.Asientos A INNER JOIN dbo.AsientosDetalle AD
	ON A.NumeroAsiento = AD.NumeroAsiento INNER JOIN dbo.PlanCuentas PC
	ON AD.NumeroCuenta = PC.NumeroCuenta
	WHERE (Fecha = @Fecha) AND (Estado = @Estado)
END
GO



DROP PROCEDURE ListarLibroDiarioFecha
GO
CREATE PROCEDURE ListarLibroDiarioFecha
@Fecha	DATETIME
AS
BEGIN
	SELECT A.NumeroAsiento, A.Fecha, A.Hora, A.Glosa,
			PC.NumeroCuenta, PC.NombreCuenta, AD.Debe, AD.Haber
	FROM dbo.Asientos A INNER JOIN dbo.AsientosDetalle AD
	ON A.NumeroAsiento = AD.NumeroAsiento INNER JOIN dbo.PlanCuentas PC
	ON AD.NumeroCuenta = PC.NumeroCuenta
	WHERE Fecha = @Fecha
END
GO



DROP PROCEDURE ListarLibroDiarioNumeroAsiento
GO
CREATE PROCEDURE ListarLibroDiarioNumeroAsiento
@NumeroAsiento	INT
AS
BEGIN
	SELECT A.NumeroAsiento, A.Fecha, A.Hora, A.Glosa,
			PC.NumeroCuenta, PC.NombreCuenta, AD.Debe, AD.Haber
	FROM dbo.Asientos A INNER JOIN dbo.AsientosDetalle AD
	ON A.NumeroAsiento = AD.NumeroAsiento INNER JOIN dbo.PlanCuentas PC
	ON AD.NumeroCuenta = PC.NumeroCuenta
	WHERE A.NumeroAsiento = @NumeroAsiento
END
GO



DROP PROCEDURE ListarLibroDiarioFechaDelAl
GO
CREATE PROCEDURE ListarLibroDiarioFechaDelAl
@FechaDel	DATETIME,
@FechaAl	DATETIME
AS
BEGIN
	SELECT A.NumeroAsiento, A.CodigoUsuario, A.Fecha, A.Hora, A.Glosa,
			PC.NumeroCuenta, PC.NombreCuenta, AD.Debe, AD.Haber
	FROM dbo.Asientos A INNER JOIN dbo.AsientosDetalle AD
	ON A.NumeroAsiento = AD.NumeroAsiento INNER JOIN dbo.PlanCuentas PC
	ON AD.NumeroCuenta = PC.NumeroCuenta
	WHERE (@FechaDel >= Fecha) AND (@FechaAl <= Fecha)
END
GO