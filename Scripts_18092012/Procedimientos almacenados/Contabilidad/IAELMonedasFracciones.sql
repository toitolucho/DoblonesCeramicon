USE Doblones20
GO


DROP PROCEDURE InsertarMonedasFracciones
GO
CREATE PROCEDURE InsertarMonedasFracciones
@CodigoMoneda			TINYINT,
@Valor					DECIMAL(10,2)
AS
BEGIN
	INSERT INTO dbo.MonedasFracciones(CodigoMoneda, Valor)
	VALUES (@CodigoMoneda, @Valor)
END
GO



DROP PROCEDURE ActualizarMonedasFracciones
GO
CREATE PROCEDURE ActualizarMonedasFracciones
@CodigoMonedaFraccion	INT,
@Valor					DECIMAL(10,2)
AS
BEGIN
	UPDATE dbo.MonedasFracciones
	SET
		Valor = @Valor
	WHERE CodigoMonedaFraccion = @CodigoMonedaFraccion
END
GO



DROP PROCEDURE EliminarMonedasFracciones
GO
CREATE PROCEDURE EliminarMonedasFracciones
@CodigoMonedaFraccion	INT
AS
BEGIN
	DELETE FROM dbo.MonedasFracciones
	WHERE CodigoMonedaFraccion = @CodigoMonedaFraccion
END
GO



DROP PROCEDURE ListarMonedasFracciones
GO
CREATE PROCEDURE ListarMonedasFracciones
AS
BEGIN
	SELECT CodigoMoneda, CodigoMonedaFraccion, Valor
	FROM dbo.MonedasFracciones
	ORDER BY CodigoMoneda, CodigoMonedaFraccion
END
GO



DROP PROCEDURE ListarMonedasFraccionesCodigoMoneda
GO
CREATE PROCEDURE ListarMonedasFraccionesCodigoMoneda
@CodigoMoneda	INT
AS
BEGIN
	SELECT CodigoMoneda, CodigoMonedaFraccion, Valor
	FROM dbo.MonedasFracciones
	WHERE CodigoMoneda = @CodigoMoneda
END
GO



DROP PROCEDURE ListarMonedasFraccionesCodigoMonedaValor
GO
CREATE PROCEDURE ListarMonedasFraccionesCodigoMonedaValor
@CodigoMoneda	INT,
@Valor			DECIMAL(10,2)
AS
BEGIN
	SELECT CodigoMoneda, CodigoMonedaFraccion, Valor
	FROM dbo.MonedasFracciones
	WHERE (CodigoMoneda = @CodigoMoneda) AND (Valor = @Valor)
END
GO



DROP PROCEDURE ListarMonedasFraccionesCodigoMonedaFraccion
GO
CREATE PROCEDURE ListarMonedasFraccionesCodigoMonedaFraccion
@CodigoMonedaFraccion	INT
AS
BEGIN
	SELECT CodigoMoneda, CodigoMonedaFraccion, Valor
	FROM dbo.MonedasFracciones
	WHERE CodigoMonedaFraccion = @CodigoMonedaFraccion
END
GO



/*DROP PROCEDURE ListarMonedasFraccionesCodigoMonedaReporte
GO
CREATE PROCEDURE ListarMonedasFraccionesCodigoMonedaReporte
@CodigoMoneda	INT
AS
BEGIN
	SELECT M.CodigoMoneda, M.NombreMoneda, M.MascaraMoneda, MF.CodigoMonedaFraccion, MF.Valor
	FROM dbo.MonedasFracciones MF INNER JOIN dbo.Monedas M
	ON MF.CodigoMoneda = M.CodigoMoneda
	WHERE M.CodigoMoneda = @CodigoMoneda
END
GO*/