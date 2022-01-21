USE Doblones20
GO

DROP PROCEDURE ObtenerConfiguracionSistemaParaTransaccionesGC
GO

CREATE PROCEDURE ObtenerConfiguracionSistemaParaTransaccionesGC
@NumeroPC		INT
AS
BEGIN
	SELECT	PC.NumeroPC, PC.IDPC, PC.NumeroAgencia, PC.CodigoMonedaSistema, M1.NombreMoneda AS NombreMonedaSistema, 
			M1.MascaraMoneda AS MascaraMonedaSistema, PC.CodigoMonedaRegion, M2.NombreMoneda AS NombreMonedaRegion, 
			M2.MascaraMoneda AS MascaraMonedaRegion, PC.PorcentajeImpuesto AS PorcentajeImpuestoSistema, PC.ContabilidadIntegrada,
			PorcentajeImpuestoCompraConFactura, PorcentajeImpuestoCompraSinFactura 
	FROM dbo.PCsConfiguraciones PC
	JOIN Monedas M1 ON
	M1.CodigoMoneda = PC.CodigoMonedaSistema
	JOIN Monedas M2 ON
	M2.CodigoMoneda = PC.CodigoMonedaRegion
	WHERE PC.NumeroPC = @NumeroPC	
	
END
GO
