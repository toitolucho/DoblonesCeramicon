USE Doblones20
GO


DROP PROCEDURE InsertarPlanCuentas
GO
CREATE PROCEDURE InsertarPlanCuentas
@NumeroCuenta		CHAR(13),
@NombreCuenta		VARCHAR(250),
@NumeroCuentaPadre	CHAR(13),
@NivelCuenta		TINYINT,
@DescripcionCuenta	VARCHAR(250)
AS
BEGIN
	INSERT INTO dbo.PlanCuentas(NumeroCuenta, NombreCuenta, NumeroCuentaPadre, NivelCuenta, DescripcionCuenta)
	VALUES (@NumeroCuenta, @NombreCuenta, @NumeroCuentaPadre, @NivelCuenta, @DescripcionCuenta)
END
GO



DROP PROCEDURE ActualizarPlanCuentas
GO
CREATE PROCEDURE ActualizarPlanCuentas
@NumeroCuenta		CHAR(13),
@NombreCuenta		VARCHAR(250),
@NumeroCuentaPadre	CHAR(13),
@NivelCuenta		TINYINT,
@DescripcionCuenta	VARCHAR(250)
AS
BEGIN
	UPDATE dbo.PlanCuentas
	SET
		NombreCuenta = @NombreCuenta,
		NumeroCuentaPadre = @NumeroCuentaPadre,
		NivelCuenta = @NivelCuenta,
		DescripcionCuenta = @DescripcionCuenta
	WHERE NumeroCuenta = @NumeroCuenta
END
GO


DROP PROCEDURE EliminarPlanCuentas
GO
CREATE PROCEDURE EliminarPlanCuentas
@NumeroCuenta  CHAR(13)
AS
BEGIN
	DELETE FROM dbo.PlanCuentas
	WHERE NumeroCuenta = @NumeroCuenta
END
GO



--Lista todas las cuentas de activo
DROP PROCEDURE ListarPlanCuentas
GO
CREATE PROCEDURE ListarPlanCuentas
AS
BEGIN
	SELECT NumeroCuentaPadre, NumeroCuenta, NombreCuenta, NivelCuenta, DescripcionCuenta
	FROM dbo.PlanCuentas
END
GO



--Lista una cuenta por su numero
DROP PROCEDURE ListarPlanCuentasNumeroCuenta
GO
CREATE PROCEDURE ListarPlanCuentasNumeroCuenta
@NumeroCuenta	CHAR(13)
AS
BEGIN
	SELECT NumeroCuentaPadre, NumeroCuenta, NombreCuenta, NivelCuenta, DescripcionCuenta
	FROM dbo.PlanCuentas
	WHERE NumeroCuenta = @NumeroCuenta
END
GO



--Lista todas las cuentas de activo
DROP PROCEDURE ListarPlanCuentasActivo
GO
CREATE PROCEDURE ListarPlanCuentasActivo
AS
BEGIN
	SELECT NumeroCuentaPadre, NumeroCuenta, NombreCuenta, NivelCuenta
	FROM dbo.PlanCuentas
	WHERE NumeroCuenta LIKE '1%'
END
GO



--Lista todas las cuentas de pasivo y capital
DROP PROCEDURE ListarPlanCuentasPasivoCapital
GO
CREATE PROCEDURE ListarPlanCuentasPasivoCapital
AS
BEGIN
	SELECT NumeroCuentaPadre, NumeroCuenta, NombreCuenta, NivelCuenta
	FROM dbo.PlanCuentas
	WHERE NumeroCuenta LIKE '[2-3]%'
END
GO



--Lista todas las cuentas de ingreso
DROP PROCEDURE ListarPlanCuentasIngreso
GO
CREATE PROCEDURE ListarPlanCuentasIngreso
AS
BEGIN
	SELECT NumeroCuentaPadre, NumeroCuenta, NombreCuenta, NivelCuenta
	FROM dbo.PlanCuentas
	WHERE NumeroCuenta LIKE '4%'
END
GO



--Lista todas las cuentas de egreso
DROP PROCEDURE ListarPlanCuentasEgreso
GO
CREATE PROCEDURE ListarPlanCuentasEgreso
AS
BEGIN
	SELECT NumeroCuentaPadre, NumeroCuenta, NombreCuenta, NivelCuenta
	FROM dbo.PlanCuentas
	WHERE NumeroCuenta LIKE '5%'
END
GO





--Lista todas las cuentas de nivel 5
DROP PROCEDURE ListarPlanCuentasSimple
GO
CREATE PROCEDURE ListarPlanCuentasSimple
AS
BEGIN
	SELECT NumeroCuenta, NombreCuenta
	FROM dbo.PlanCuentas
	WHERE NivelCuenta = 5
END
GO



--Lista todas las cuentas de activo, pasivo y capital de nivel 5
DROP PROCEDURE ListarPlanCuentasSimpleAPC
GO
CREATE PROCEDURE ListarPlanCuentasSimpleAPC
AS
BEGIN
	SELECT NumeroCuenta, NombreCuenta
	FROM dbo.PlanCuentas
	WHERE (NivelCuenta = 5) AND (NumeroCuenta LIKE '[1-3]%')
END
GO



--Lista todas las cuentas de ingresos y egresos de nivel 5
DROP PROCEDURE ListarPlanCuentasSimpleIE
GO
CREATE PROCEDURE ListarPlanCuentasSimpleIE
AS
BEGIN
	SELECT NumeroCuenta, NombreCuenta
	FROM dbo.PlanCuentas
	WHERE (NivelCuenta = 5) AND (NumeroCuenta LIKE '[4-5]%')
END
GO



--Lista todas las cuentas de un nivel dado
DROP PROCEDURE ListarPlanCuentasNivel
GO
CREATE PROCEDURE ListarPlanCuentasNivel
@Nivel TINYINT
AS
BEGIN
	SELECT NumeroCuenta, NombreCuenta
	FROM dbo.PlanCuentas
	WHERE NivelCuenta = @Nivel
END
GO



--Lista todas las cuentas padres
DROP PROCEDURE ListarPlanCuentasPadre
GO
CREATE PROCEDURE ListarPlanCuentasPadre
AS
BEGIN
	SELECT NumeroCuenta, NombreCuenta
	FROM dbo.PlanCuentas
	WHERE NivelCuenta <= 4
END
GO