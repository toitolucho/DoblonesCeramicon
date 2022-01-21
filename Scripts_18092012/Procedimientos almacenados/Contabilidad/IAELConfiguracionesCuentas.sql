USE Doblones20
GO



DROP PROC InsertarConfiguracionesCuentas
GO
CREATE PROC InsertarConfiguracionesCuentas
@NombreConfiguracion		VARCHAR(250),
@CodigoTipoTransaccion		CHAR(1),
@CodigoTipoMovimiento		CHAR(1),
@DescripcionConfiguracion	TEXT
AS
BEGIN
	INSERT INTO dbo.ConfiguracionesCuentas (NombreConfiguracion, CodigoTipoTransaccion, CodigoTipoMovimiento, DescripcionConfiguracion)
	VALUES (@NombreConfiguracion, @CodigoTipoTransaccion, @CodigoTipoMovimiento, @DescripcionConfiguracion)
END
GO



DROP PROC ActualizarConfiguracionesCuentas
GO
CREATE PROC ActualizarConfiguracionesCuentas
@NumeroConfiguracion		INT,
@NombreConfiguracion		VARCHAR(250),
@CodigoTipoTransaccion		CHAR(1),
@CodigoTipoMovimiento		CHAR(1),
@DescripcionConfiguracion	TEXT
AS
BEGIN
	UPDATE dbo.ConfiguracionesCuentas
	SET 
		NombreConfiguracion			= @NombreConfiguracion,
		CodigoTipoTransaccion		= @CodigoTipoTransaccion,	
		CodigoTipoMovimiento		= @CodigoTipoMovimiento,	
		DescripcionConfiguracion	= @DescripcionConfiguracion
				
	WHERE NumeroConfiguracion = @NumeroConfiguracion
END
GO



DROP PROC EliminarConfiguracionesCuentas
GO
CREATE PROC EliminarConfiguracionesCuentas
@NumeroConfiguracion		INT
AS
BEGIN
	DELETE FROM dbo.ConfiguracionesCuentas
	WHERE NumeroConfiguracion = @NumeroConfiguracion
END
GO



DROP PROC ListarConfiguracionesCuentas
GO
CREATE PROC ListarConfiguracionesCuentas
AS
BEGIN
	SELECT NumeroConfiguracion, NombreConfiguracion, CodigoTipoTransaccion, CodigoTipoMovimiento, DescripcionConfiguracion
 	FROM dbo.ConfiguracionesCuentas
END
GO






DROP PROC InsertarConfiguracionesCuentasDetalle
GO
CREATE PROC InsertarConfiguracionesCuentasDetalle
@NumeroConfiguracion	INT,
@NumeroCuentaConfiguracion CHAR(13),
@TipoCuentaDebeHaber	CHAR(1),
@PorcentajeMontoTotalDH	DECIMAL(10,2)
AS
BEGIN
	INSERT INTO dbo.ConfiguracionesCuentasDetalle(NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber, PorcentajeMontoTotalDH)
	VALUES(@NumeroConfiguracion, @NumeroCuentaConfiguracion, @TipoCuentaDebeHaber, @PorcentajeMontoTotalDH)
END
GO


/*DROP PROC ActualizarConfiguracionesCuentasDetalle
GO
CREATE PROC ActualizarConfiguracionesCuentasDetalle
AS
BEGIN
END
GO*/

DROP PROC EliminarConfiguracionesCuentasDetalle
GO
CREATE PROC EliminarConfiguracionesCuentasDetalle
@NumeroConfiguracion	INT
AS
BEGIN
	DELETE FROM dbo.ConfiguracionesCuentasDetalle
	WHERE NumeroConfiguracion = @NumeroConfiguracion
END
GO


DROP PROC ListarConfiguracionesCuentasDetalle
GO
CREATE PROC ListarConfiguracionesCuentasDetalle
AS
BEGIN
	SELECT	NumeroConfiguracion, NumeroCuentaConfiguracion, TipoCuentaDebeHaber, PorcentajeMontoTotalDH
	FROM dbo.ConfiguracionesCuentasDetalle
END
GO


DROP PROC ListarConfiguracionesCuentasDetallePorNumeroConfiguracion
GO
CREATE PROC ListarConfiguracionesCuentasDetallePorNumeroConfiguracion
@Numero		INT
AS
BEGIN
	SELECT	NumeroConfiguracion, NumeroCuentaConfiguracion, NombreCuenta, TipoCuentaDebeHaber, PorcentajeMontoTotalDH
	FROM dbo.ConfiguracionesCuentasDetalle 
	INNER JOIN dbo.PlanCuentas 
	ON NumeroCuentaConfiguracion = NumeroCuenta
	WHERE NumeroConfiguracion  = @Numero
END
GO


DROP PROC ListarConfiguracionesCuentasDetallePorNumeroConfiguracionDH
GO
CREATE PROC ListarConfiguracionesCuentasDetallePorNumeroConfiguracionDH
@NumeroConfiguracion		INT,
@CodigoTipoDebeHaber		CHAR(1)
AS
BEGIN
	
	SELECT	NumeroConfiguracion, NumeroCuentaConfiguracion, NombreCuenta, TipoCuentaDebeHaber, PorcentajeMontoTotalDH
	FROM dbo.ConfiguracionesCuentasDetalle 
	INNER JOIN dbo.PlanCuentas 
	ON NumeroCuentaConfiguracion = NumeroCuenta
	WHERE NumeroConfiguracion  = @NumeroConfiguracion
	AND TipoCuentaDebeHaber LIKE CASE WHEN @CodigoTipoDebeHaber IS NOT NULL THEN @CodigoTipoDebeHaber
	ELSE '%%' END 
END
GO