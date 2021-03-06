USE [Doblones20]

DROP FUNCTION ObtenerVariablesConfiguracionSistemaPC
GO

CREATE FUNCTION dbo.ObtenerVariablesConfiguracionSistemaPC(@IDPC CHAR(50))
RETURNS TABLE
AS
RETURN 
(
SELECT SC.NumeroPC, SC.IDPC, SC.IPPC, SC.NumeroAgencia, Ag.NombreAgencia, SC.CodigoMonedaSistema, Mo1.NombreMoneda AS NombreMonedaSistema, 
SC.CodigoMonedaRegion, Mo2.NombreMoneda AS NombreMonedaRegion, SC.PorcentajeImpuesto 
FROM PCsConfiguraciones SC
JOIN Monedas Mo1 ON
Mo1.CodigoMoneda = SC.CodigoMonedaSistema
JOIN Monedas Mo2 ON
Mo2.CodigoMoneda = SC.CodigoMonedaRegion
JOIN Agencias Ag ON
Ag.NumeroAgencia = SC.NumeroAgencia
WHERE SC.IDPC = @IDPC
)
GO