USE Doblones20
GO



DROP PROCEDURE ListarEstadoResultadosIngresos
GO
CREATE PROCEDURE ListarEstadoResultadosIngresos
@FechaInicio	DATETIME,
@FechaFin		DATETIME
AS
BEGIN
	SELECT AD.NumeroCuenta, SUM(Debe) - SUM(Haber) AS 'Saldo'
	FROM dbo.AsientosDetalle AD INNER JOIN dbo.Asientos A
	ON AD.NumeroAsiento = A.NumeroAsiento
	WHERE (AD.NumeroCuenta LIKE '4%') AND
			(A.Fecha >= @FechaInicio) AND
			(A.Fecha <= @FechaFin)
	GROUP BY AD.NumeroCuenta
END
GO



DROP PROCEDURE ListarEstadoResultadosEgresos
GO
CREATE PROCEDURE ListarEstadoResultadosEgresos
@FechaInicio	DATETIME,
@FechaFin		DATETIME
AS
BEGIN
	SELECT AD.NumeroCuenta, SUM(Haber) - SUM(Debe) AS 'Saldo'
	FROM dbo.AsientosDetalle AD INNER JOIN dbo.Asientos A
	ON AD.NumeroAsiento = A.NumeroAsiento
	WHERE (AD.NumeroCuenta LIKE '5%') AND
			(A.Fecha >= @FechaInicio) AND
			(A.Fecha <= @FechaFin)
	GROUP BY AD.NumeroCuenta
END
GO



DROP VIEW VistaEstadoResultadosDiferencialReporte
GO
CREATE VIEW VistaEstadoResultadosDiferencialReporte
AS
	SELECT SUM(DA.Debe) AS 'Deudor', SUM(DA.Haber) AS 'Acreedor'
	FROM dbo.PlanCuentas PC INNER JOIN dbo.AsientosDetalle DA
	ON PC.NumeroCuenta = DA.NumeroCuenta
GO