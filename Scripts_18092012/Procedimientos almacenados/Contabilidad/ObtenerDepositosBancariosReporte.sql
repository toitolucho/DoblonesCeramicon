USE Doblones20
GO

DROP PROCEDURE ObtenerDepositosBancariosReporte
GO
CREATE PROCEDURE ObtenerDepositosBancariosReporte
@NumeroAgencia			INT,
@NumeroDepositoBancario INT
AS
BEGIN
	SELECT DB.NumeroDepositoBancario,A.NombreAgencia,B.NombreBanco,NumeroCuentaBanco,DB.Depositante,DB.Monto,M.NombreMoneda,FechaHora,DB.Observaciones
	FROM dbo.DepositosBancarios DB INNER JOIN dbo.Bancos B
	ON DB.CodigoBanco = B.CodigoBanco INNER JOIN dbo.Agencias A	
	ON A.NumeroAgencia = DB.NumeroAgencia INNER JOIN dbo.Monedas M
	ON DB.CodigoMoneda = M.CodigoMoneda
	WHERE (DB.NumeroDepositoBancario	= @NumeroDepositoBancario) AND (DB.NumeroAgencia = @NumeroAgencia)
	ORDER BY NumeroDepositoBancario
END
GO