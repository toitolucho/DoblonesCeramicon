USE DOBLONES20
GO


DROP PROCEDURE InsertarDocumentTipo
GO
CREATE PROCEDURE InsertarDocumentTipo
	@NombreTipoDocumento	VARCHAR(250)
AS
BEGIN
	INSERT INTO dbo.DocumentosTipos(NombreTipoDocumento)								
	VALUES (@NombreTipoDocumento)
END
GO


DROP PROCEDURE ActualizarDocumentTipo
GO
CREATE PROCEDURE ActualizarDocumentTipo
	@CodigoTipoDocumento	INT,
	@NombreTipoDocumento	VARCHAR(250)
AS
BEGIN
	UPDATE 	dbo.DocumentosTipos
	SET		
		NombreTipoDocumento = @NombreTipoDocumento
	WHERE	(CodigoTipoDocumento = @CodigoTipoDocumento)
END
GO



DROP PROCEDURE EliminarDocumentTipo
GO
CREATE PROCEDURE EliminarDocumentTipo
	@CodigoTipoDocumento INT
AS
BEGIN
	DELETE 
	FROM dbo.DocumentosTipos
	WHERE	(CodigoTipoDocumento = @CodigoTipoDocumento)		
END
GO



DROP PROCEDURE ListarDocumentosTipos
GO
CREATE PROCEDURE ListarDocumentosTipos
AS
BEGIN
	SELECT CodigoTipoDocumento,NombreTipoDocumento
	FROM dbo.DocumentosTipos
	ORDER BY CodigoTipoDocumento
END
GO



DROP PROCEDURE ObtenerDocumentoTipo
GO
CREATE PROCEDURE ObtenerDocumentoTipo
	@CodigoTipoDocumento	INT
AS
BEGIN
	SELECT CodigoTipoDocumento,NombreTipoDocumento
	FROM dbo.DocumentosTipos
	WHERE	(CodigoTipoDocumento = @CodigoTipoDocumento)
END
GO



--DROP PROCEDURE ObtenerDocumentosTipos
--GO
--CREATE PROCEDURE ObtenerDocumentosTipos
--AS
--BEGIN
--	SELECT CodigoTipoDocumento,NombreTipoDocumento
--	FROM dbo.DocumentosTipos
--END
--GO