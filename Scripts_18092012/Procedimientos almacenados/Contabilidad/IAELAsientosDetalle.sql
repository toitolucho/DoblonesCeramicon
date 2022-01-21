USE Doblones20
GO


DROP PROCEDURE InsertarAsientosDetalle
GO
CREATE PROCEDURE InsertarAsientosDetalle
@NumeroAsiento	INT,
@NumeroCuenta	CHAR(13),
@Debe			DECIMAL(10,2),
@Haber			DECIMAL(10,2)
AS
BEGIN
	INSERT INTO dbo.AsientosDetalle(NumeroAsiento, NumeroCuenta, Debe, Haber)
	VALUES (@NumeroAsiento, @NumeroCuenta, @Debe, @Haber)
END
GO



DROP PROCEDURE EliminarAsientosDetalle
GO
CREATE PROCEDURE EliminarAsientosDetalle
@NumeroAsiento  INT
AS
BEGIN
	DELETE FROM dbo.AsientosDetalle
	WHERE NumeroAsiento = @NumeroAsiento
END
GO


DROP PROCEDURE ListarAsientosDetalle
GO
CREATE PROCEDURE ListarAsientosDetalle
AS
BEGIN
	SELECT NumeroAsiento, NumeroCuenta, Debe, Haber
	FROM dbo.AsientosDetalle
END
GO



DROP PROCEDURE ObtenerAsientosDetalle
GO
CREATE PROCEDURE ObtenerAsientosDetalle
@NumeroAsiento INT
AS
BEGIN
	SELECT PC.NumeroCuenta, PC.NombreCuenta, AD.Debe, AD.Haber
	FROM dbo.AsientosDetalle AD INNER JOIN dbo.PlanCuentas PC
	ON AD.NumeroCuenta = PC.NumeroCuenta
	WHERE NumeroAsiento = @NumeroAsiento
END
GO


--DROP PROCEDURE ListarAsientosDetalleReporte