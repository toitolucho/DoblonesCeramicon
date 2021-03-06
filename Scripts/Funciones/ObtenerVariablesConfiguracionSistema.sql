USE [Doblones20]
GO
DROP FUNCTION [dbo].[ObtenerVariablesConfiguracionSistema]
GO

CREATE FUNCTION [dbo].[ObtenerVariablesConfiguracionSistema]()
RETURNS TABLE
AS
RETURN 
(
SELECT SC.NumeroPC, SC.IDPC, SC.IPPC, SC.NumeroAgencia, Ag.NombreAgencia, SC.CodigoMonedaSistema, Mo.NombreMoneda, SC.PorcentajeImpuesto 
FROM PCsConfiguraciones SC
JOIN Monedas Mo ON
Mo.CodigoMoneda = SC.CodigoMonedaSistema
JOIN Agencias Ag ON
Ag.NumeroAgencia = SC.NumeroAgencia
)

