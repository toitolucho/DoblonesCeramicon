USE Doblones20
GO


DROP VIEW VistaBalanceGeneralReporte
GO
CREATE VIEW VistaBalanceGeneralReporte
AS
	SELECT PC.NumeroCuentaPadre, PC.NumeroCuenta, PC.NombreCuenta, PC.NivelCuenta, SUM(DA.Debe) - SUM(DA.Haber) AS 'Saldo'
	FROM dbo.PlanCuentas PC INNER JOIN dbo.AsientosDetalle DA
	ON PC.NumeroCuenta = DA.NumeroCuenta
	GROUP BY PC.NumeroCuentaPadre, PC.NumeroCuenta, PC.NombreCuenta, PC.NivelCuenta
GO



DROP PROCEDURE ListarBalanceGeneralActivo
GO
CREATE PROCEDURE ListarBalanceGeneralActivo
@FechaInicio	DATETIME,
@FechaFin		DATETIME
AS
BEGIN
	SELECT AD.NumeroCuenta, SUM(Debe) - SUM(Haber) AS 'Saldo'
	FROM dbo.AsientosDetalle AD INNER JOIN dbo.Asientos A
	ON AD.NumeroAsiento = A.NumeroAsiento
	WHERE (AD.NumeroCuenta LIKE '1%') AND
			(A.Fecha >= @FechaInicio) AND
			(A.Fecha <= @FechaFin)
	GROUP BY AD.NumeroCuenta
END
GO



DROP PROCEDURE ListarBalanceGeneralPasivoCapital
GO
CREATE PROCEDURE ListarBalanceGeneralPasivoCapital
@FechaInicio	DATETIME,
@FechaFin		DATETIME
AS
BEGIN
	SELECT AD.NumeroCuenta, SUM(Haber) - SUM(Debe) AS 'Saldo'
	FROM dbo.AsientosDetalle AD INNER JOIN dbo.Asientos A
	ON AD.NumeroAsiento = A.NumeroAsiento
	WHERE (AD.NumeroCuenta LIKE '[2-3]%') AND
			(A.Fecha >= @FechaInicio) AND
			(A.Fecha <= @FechaFin)	
	GROUP BY AD.NumeroCuenta	
END
GO



--Balance general comparativo
DROP VIEW VistaBalanceGeneralComparativoReporte
GO
CREATE VIEW VistaBalanceGeneralComparativoReporte
AS
	SELECT PC.NumeroCuentaPadre, PC.NumeroCuenta, PC.NombreCuenta, PC.NivelCuenta, SUM(DA.Debe) - SUM(DA.Haber) AS 'SaldoPrimero', SUM(DA.Debe) - SUM(DA.Haber) AS 'SaldoSegundo'
	FROM dbo.PlanCuentas PC INNER JOIN dbo.AsientosDetalle DA
	ON PC.NumeroCuenta = DA.NumeroCuenta
	GROUP BY PC.NumeroCuentaPadre, PC.NumeroCuenta, PC.NombreCuenta, PC.NivelCuenta
GO