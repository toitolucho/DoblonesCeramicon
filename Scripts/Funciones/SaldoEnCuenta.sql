USE Doblones20
GO


DROP PROC SaldoEnCuenta
GO

CREATE PROC SaldoEnCuenta
@NumeroCuenta	CHAR(13),
@Saldo			DECIMAL(10,2) OUTPUT
AS
BEGIN
	SET @Saldo = (SELECT ABS(SUM(Debe) - SUM (Haber)) FROM dbo.AsientosDetalle WHERE NumeroCuenta = @NumeroCuenta)
END
GO



DROP FUNCTION FuncionSaldoEnCuenta
GO

CREATE FUNCTION FuncionSaldoEnCuenta(@NumeroCuenta	CHAR(13))
	RETURNS DECIMAL(10,2)
WITH ENCRYPTION
AS
BEGIN
	DECLARE @Saldo	DECIMAL(10,2)
	SET @Saldo = (SELECT ABS(SUM(Debe) - SUM (Haber)) FROM dbo.AsientosDetalle WHERE NumeroCuenta = @NumeroCuenta)
	RETURN ISNULL(@Saldo,0)
END
