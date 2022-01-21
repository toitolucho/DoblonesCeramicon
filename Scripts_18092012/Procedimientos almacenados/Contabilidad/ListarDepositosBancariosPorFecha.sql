USE Doblones20
GO

DROP PROCEDURE ListarDepositosBancariosPorFecha
GO
CREATE PROCEDURE ListarDepositosBancariosPorFecha
@Fecha	DATETIME
AS
BEGIN
	SELECT DB.NumeroDepositoBancario,A.NombreAgencia,B.NombreBanco,NumeroCuentaBanco,DB.Depositante,DB.Monto,M.NombreMoneda,FechaHora,DB.Observaciones
	FROM dbo.DepositosBancarios DB INNER JOIN dbo.Bancos B
	ON DB.CodigoBanco = B.CodigoBanco INNER JOIN dbo.Agencias A	
	ON A.NumeroAgencia = DB.NumeroAgencia INNER JOIN dbo.Monedas M
	ON DB.CodigoMoneda = M.CodigoMoneda
	WHERE FechaHora = @Fecha
	ORDER BY NumeroDepositoBancario
END
GO