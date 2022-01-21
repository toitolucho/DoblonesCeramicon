USE DOBLONES20
GO

DROP PROCEDURE InsertarPCConfiguracion
GO

CREATE PROCEDURE InsertarPCConfiguracion
	@IDPC					CHAR(50),
	@IPPC					CHAR(15),
	@NumeroAgencia			INT,
	@CodigoMonedaSistema	TINYINT,
	@CodigoMonedaRegion		TINYINT,
	@PorcentajeImpuesto		DECIMAL(10,2),
	@ContabilidadIntegrada	BIT,
	@RutaDirectorioImagenes	TEXT
AS
BEGIN
	INSERT INTO dbo.PCsConfiguraciones(IDPC, IPPC, NumeroAgencia, CodigoMonedaSistema, CodigoMonedaRegion, PorcentajeImpuesto, ContabilidadIntegrada, RutaDirectorioImagenes)
	VALUES (@IDPC, @IPPC, @NumeroAgencia, @CodigoMonedaSistema, @CodigoMonedaRegion, @PorcentajeImpuesto, @ContabilidadIntegrada, @RutaDirectorioImagenes)
END
GO

DROP PROCEDURE ActualizarPCConfiguracion
GO

CREATE PROCEDURE ActualizarPCConfiguracion
	@NumeroPC				INT,
	@IDPC					CHAR(50),
	@IPPC					CHAR(15),
	@NumeroAgencia			INT,
	@CodigoMonedaSistema	TINYINT,
	@CodigoMonedaRegion		TINYINT,
	@PorcentajeImpuesto		DECIMAL(10,2),
	@ContabilidadIntegrada	BIT,
	@RutaDirectorioImagenes	TEXT
AS
BEGIN
	UPDATE 	dbo.PCsConfiguraciones
	SET	
		IDPC					= @IDPC,					
		IPPC					= @IPPC,					
		NumeroAgencia			= @NumeroAgencia,
		CodigoMonedaSistema		= @CodigoMonedaSistema,	
		CodigoMonedaRegion		= @CodigoMonedaRegion,
		PorcentajeImpuesto		= @PorcentajeImpuesto,		
		ContabilidadIntegrada	= @ContabilidadIntegrada,
		RutaDirectorioImagenes  = @RutaDirectorioImagenes
	WHERE NumeroPC = @NumeroPC
END
GO

DROP PROCEDURE EliminarPCConfiguracion
GO

CREATE PROCEDURE EliminarPCConfiguracion
	@NumeroPC	INT
AS
BEGIN
	DELETE 
	FROM dbo.PCsConfiguraciones
	WHERE NumeroPC = @NumeroPC
END
GO

DROP PROCEDURE ListarPCsConfiguraciones
GO

CREATE PROCEDURE ListarPCsConfiguraciones
AS
BEGIN
	SELECT NumeroPC, IDPC, IPPC, NumeroAgencia, CodigoMonedaSistema, CodigoMonedaRegion, PorcentajeImpuesto, ContabilidadIntegrada, RutaDirectorioImagenes
	FROM dbo.PCsConfiguraciones
	ORDER BY NumeroPC
END
GO

DROP PROCEDURE ObtenerPCConfiguracion
GO

CREATE PROCEDURE ObtenerPCConfiguracion
	@NumeroPC	INT
AS
BEGIN
	SELECT NumeroPC, IDPC, IPPC, NumeroAgencia, CodigoMonedaSistema, CodigoMonedaRegion, PorcentajeImpuesto, ContabilidadIntegrada, RutaDirectorioImagenes
	FROM dbo.PCsConfiguraciones
	WHERE NumeroPC = @NumeroPC
END
GO

DROP PROCEDURE ObtenerPCConfiguracionIDPC
GO

CREATE PROCEDURE ObtenerPCConfiguracionIDPC
	@IDPC	CHAR(50)
AS
BEGIN
	SELECT NumeroPC, IDPC, IPPC, NumeroAgencia, CodigoMonedaSistema, CodigoMonedaRegion, PorcentajeImpuesto, ContabilidadIntegrada, RutaDirectorioImagenes
	FROM dbo.PCsConfiguraciones
	WHERE IDPC = @IDPC
END
GO

DROP PROCEDURE ObtenerConfiguracionSistemaParaTransaccionesGC
GO

CREATE PROCEDURE ObtenerConfiguracionSistemaParaTransaccionesGC
@NumeroPC		INT
AS
BEGIN
	SELECT	PC.NumeroPC, PC.IDPC, PC.NumeroAgencia, PC.CodigoMonedaSistema, M1.NombreMoneda AS NombreMonedaSistema, 
			M1.MascaraMoneda AS MascaraMonedaSistema, PC.CodigoMonedaRegion, M2.NombreMoneda AS NombreMonedaRegion, 
			M2.MascaraMoneda AS MascaraMonedaRegion, PC.PorcentajeImpuesto AS PorcentajeImpuestoSistema, 
			PC.ContabilidadIntegrada, PorcentajeImpuestoCompraConFactura, PorcentajeImpuestoCompraSinFactura, PC.RutaDirectorioImagenes
	FROM dbo.PCsConfiguraciones PC
	JOIN Monedas M1 ON
	M1.CodigoMoneda = PC.CodigoMonedaSistema
	JOIN Monedas M2 ON
	M2.CodigoMoneda = PC.CodigoMonedaRegion
	WHERE PC.NumeroPC = @NumeroPC	
END
GO