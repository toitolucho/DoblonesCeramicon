USE Doblones20
GO

DROP PROC InsertarConcepto
GO
CREATE PROC InsertarConcepto
@Concepto		VARCHAR(256)
AS
BEGIN
	INSERT INTO dbo.Conceptos (Concepto)
	VALUES (@Concepto)
END
GO


DROP PROC EliminarConcepto
GO
CREATE PROC EliminarConcepto
@NumeroConcepto		INT
AS
BEGIN
	DELETE FROM dbo.Conceptos
	WHERE NumeroConcepto= @NumeroConcepto
END
GO

DROP PROC ActualizarConcepto
GO
CREATE PROC ActualizarConcepto
@NumeroConcepto	INT,
@Concepto		VARCHAR(256)
AS
BEGIN
	UPDATE dbo.Conceptos
	SET Concepto = @Concepto
	WHERE NumeroConcepto = @NumeroConcepto
END
GO

DROP PROC ListarConceptos
GO
CREATE PROC ListarConceptos
AS
BEGIN
	SELECT NumeroConcepto, Concepto
	FROM dbo.Conceptos
END
GO

DROP PROC ListarConceptosNumeroConcepto
GO
CREATE PROC ListarConceptosNumeroConcepto
@NumeroConcepto	INT
AS
BEGIN
	SELECT NumeroConcepto, Concepto
	FROM dbo.Conceptos
	WHERE NumeroConcepto = @NumeroConcepto
END
GO