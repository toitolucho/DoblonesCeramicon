USE Doblones20
GO

DROP PROCEDURE	PerteneUsuarioSistemaGrupos
GO

CREATE PROCEDURE PerteneUsuarioSistemaGrupos
	@NumeroAgencia			INT,
	@CodigoUsuario			INT,
	@PerteneceSistemaGrupo	BIT	OUTPUT
AS
BEGIN
	IF(EXISTS ( SELECT Codigousuario FROM SistemaGruposUsuarios WHERE CodigoUsuario = @CodigoUsuario AND NumeroAgencia = @NumeroAgencia))
		SET @PerteneceSistemaGrupo = 1
	ELSE
		SET @PerteneceSistemaGrupo = 0
END
GO




DROP PROCEDURE ListarSitemaGruposPorUsuario
GO

CREATE PROCEDURE ListarSitemaGruposPorUsuario
	@NumeroAgencia	INT,
	@CodigoUsuario	INT	
AS
BEGIN
	SELECT SGU.CodigoGrupoSistema, SG.NombreGrupoSistema
	FROM SistemaGruposUsuarios SGU INNER JOIN SistemaGrupos SG ON SGU.CodigoGrupoSistema = SG.CodigoGrupoSistema
	WHERE SGU.NumeroAgencia = @NumeroAgencia AND SGU.CodigoUsuario = @CodigoUsuario	
END


