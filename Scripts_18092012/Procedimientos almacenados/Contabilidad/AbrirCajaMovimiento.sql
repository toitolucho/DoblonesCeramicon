USE Doblones20
GO

DROP PROCEDURE AbrirCajaMovimiento
GO

CREATE PROCEDURE AbrirCajaMovimiento
AS
BEGIN
	DECLARE	@FechaActual	DATETIME
	SET @FechaActual = GETDATE()
	
	IF(DAY(@FechaActual) <> 1)--si no es domingo
	BEGIN
		IF(EXISTS(SELECT TOP(1) * FROM CajaMovimientos WHERE Estado = 'C' ORDER BY FechaHora DESC))
		BEGIN
			--Inicio de caja de fecha de miércoles, 04 de enero de 2012
			DECLARE @Descripcion	VARCHAR(4000)
			SET @Descripcion = 'Inicio de Caja en Fecha de ' + DATENAME(WEEKDAY, @FechaActual) + ', ' 
				+ RIGHT('00' + RTRIM(CAST(DAY(@FechaActual) AS CHAR(2))), 2) +' de ' + DATENAME(MONTH, @FechaActual) + ' de ' 
				+ CAST(YEAR(@FechaActual) AS CHAR(4)) 
			
			INSERT INTO dbo.CajaMovimientos(CodigoMoneda, Debe, Haber, CodigoMedioPago, CodigoUsuario, FechaHora, Descripcion, Estado)
			SELECT TOP(1) CodigoMoneda, Debe, Haber, CodigoMedioPago, CodigoUsuario, @FechaActual, @Descripcion, 'A'
			FROM CajaMovimientos 
			WHERE Estado = 'C' 
			ORDER BY FechaHora DESC
			
			DECLARE @NumeroMovimiento	INT					
			
			SET @NumeroMovimiento = SCOPE_IDENTITY()--Devuelve el ultimo id Ingresado en una Tabla con una columna Identidad dentro del Ambito,
			
			INSERT INTO dbo.CajaMovimientosDetalle(NumeroMovimiento, NumeroCuentaDeposito, Cantidad, NumeroSerie)
			SELECT @NumeroMovimiento, CJM.NumeroCuentaDeposito, CJM.Cantidad, CJM.NumeroSerie
			FROM CajaMovimientosDetalle CJM
			INNER JOIN CajaMovimientos CM
			ON CJM.NumeroMovimiento = CM.NumeroMovimiento
			WHERE Estado = 'C'
			ORDER BY FechaHora DESC
		END
	END
END
GO
