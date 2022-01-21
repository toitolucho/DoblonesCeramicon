USE DOBLONES20
GO



DROP PROCEDURE InsertarGastoTipoTransaccion
GO
CREATE PROCEDURE InsertarGastoTipoTransaccion	
	@NombreGasto		VARCHAR(250),
	@DescripcionGasto	TEXT
AS
BEGIN
	INSERT INTO dbo.GastosTiposTransacciones (NombreGasto, DescripcionGasto)
	VALUES (@NombreGasto, @DescripcionGasto)
END
GO



DROP PROCEDURE ActualizarGastoTipoTransaccion
GO
CREATE PROCEDURE ActualizarGastoTipoTransaccion
	@CodigoGastosTipos	INT,
	@NombreGasto		VARCHAR(250),
	@DescripcionGasto	TEXT
AS
BEGIN
	UPDATE 	dbo.GastosTiposTransacciones
	SET			
		NombreGasto			= @NombreGasto,
		DescripcionGasto	= @DescripcionGasto
	WHERE (CodigoGastosTipos = @CodigoGastosTipos)
END
GO



DROP PROCEDURE EliminarGastoTipoTransaccion
GO
CREATE PROCEDURE EliminarGastoTipoTransaccion
	@CodigoGastosTipos	INT
AS
BEGIN
	DELETE 
	FROM dbo.GastosTiposTransacciones
	WHERE (CodigoGastosTipos = @CodigoGastosTipos)
END
GO



DROP PROCEDURE ListarGastosTiposTransacciones
GO
CREATE PROCEDURE ListarGastosTiposTransacciones
AS
BEGIN
	SELECT CodigoGastosTipos, NombreGasto, DescripcionGasto
	FROM dbo.GastosTiposTransacciones
	ORDER BY CodigoGastosTipos
END
GO



DROP PROCEDURE ObtenerGastoTipoTransaccion
GO
CREATE PROCEDURE ObtenerGastoTipoTransaccion
	@CodigoGastosTipos		INT
AS
BEGIN
	SELECT CodigoGastosTipos, NombreGasto, DescripcionGasto
	FROM dbo.GastosTiposTransacciones
	WHERE (CodigoGastosTipos = @CodigoGastosTipos)
END
GO

declare @salida INT
exec dbo.ObtenerUltimoIndiceTabla 'GastosTiposTransacciones', @salida output
SELECT @salida

SELECT IDENT_CURRENT('GastosTiposTransacciones')