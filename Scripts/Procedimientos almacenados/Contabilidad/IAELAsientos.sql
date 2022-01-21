USE Doblones20
GO


DROP PROCEDURE InsertarAsientos
GO
CREATE PROCEDURE InsertarAsientos
@CodigoUsuario	INT,
@Fecha			DATETIME,
@Hora			DATETIME,
@Glosa			TEXT,
@Estado			VARCHAR(10)
AS
BEGIN
	INSERT INTO dbo.Asientos(CodigoUsuario, Fecha, Hora, Glosa, Estado)
	VALUES (@CodigoUsuario, @Fecha, @Hora, @Glosa, @Estado)
END
GO



DROP PROCEDURE ActualizarAsientos
GO
CREATE PROCEDURE ActualizarAsientos
@NumeroAsiento  INT,
@CodigoUsuario	INT,
@Fecha			DATETIME,
@Hora			DATETIME,
@Glosa			TEXT,
@Estado			VARCHAR(10)
AS
BEGIN
	UPDATE dbo.Asientos
	SET
		CodigoUsuario = @CodigoUsuario,
		Fecha = @Fecha,
		Hora = @Hora,
		Glosa = @Glosa,
		Estado = @Estado
	WHERE NumeroAsiento = @NumeroAsiento
END
GO



DROP PROCEDURE EliminarAsientos
GO
CREATE PROCEDURE EliminarAsientos
@NumeroAsiento	INT
AS
BEGIN
	DELETE FROM dbo.Asientos
	WHERE NumeroAsiento = @NumeroAsiento
END
GO



DROP PROCEDURE ListarAsientos
GO
CREATE PROCEDURE ListarAsientos
AS
BEGIN
	SELECT NumeroAsiento, CodigoUsuario, Fecha, Hora, Glosa, Estado
	FROM dbo.Asientos
END
GO




DROP PROCEDURE ObtenerAsientos
GO
CREATE PROCEDURE ObtenerAsientos
@NumeroAsiento INT
AS
BEGIN
	SELECT NumeroAsiento, CodigoUsuario, Fecha, Hora, Glosa, Estado
	FROM dbo.Asientos
	WHERE NumeroAsiento = @NumeroAsiento
END
GO



DROP PROCEDURE ListarAsientosNumero
GO
CREATE PROCEDURE ListarAsientosNumero
@NumeroAsiento INT
AS
BEGIN
	SELECT NumeroAsiento, CodigoUsuario, Fecha, Hora, Glosa, Estado
	FROM dbo.Asientos
	WHERE NumeroAsiento = @NumeroAsiento
END
GO




DROP PROCEDURE ListarAsientosFechaEstado
GO
CREATE PROCEDURE ListarAsientosFechaEstado
@Fecha	DATETIME,
@Estado	VARCHAR(10)
AS
BEGIN
	SELECT NumeroAsiento, CodigoUsuario, Fecha, Hora, Glosa, Estado
	FROM dbo.Asientos
	WHERE (Fecha = @Fecha) AND (Estado = @Estado)
END
GO



DROP PROCEDURE ListarAsientosFecha
GO
CREATE PROCEDURE ListarAsientosFecha
@Fecha	DATETIME
AS
BEGIN
	SELECT NumeroAsiento, CodigoUsuario, Fecha, Hora, Glosa, Estado
	FROM dbo.Asientos
	WHERE Fecha = @Fecha
END
GO



DROP PROCEDURE ListarAsientosUsuario
GO
CREATE PROCEDURE ListarAsientosUsuario
@CodigoUsuario	INT
AS
BEGIN
	SELECT NumeroAsiento, CodigoUsuario, Fecha, Hora, Glosa, Estado
	FROM dbo.Asientos
	WHERE CodigoUsuario = @CodigoUsuario
END
GO



DROP PROCEDURE ObtenerUltimoNumeroAsiento
GO
CREATE PROCEDURE ObtenerUltimoNumeroAsiento
@UltimoNumeroAsiento	INT	OUTPUT
AS
BEGIN
	SET @UltimoNumeroAsiento = (SELECT MAX(NumeroAsiento)
								FROM dbo.Asientos)	
END
GO



DROP PROCEDURE ObtenerFecha
GO
CREATE PROCEDURE ObtenerFecha
@Fecha			DATETIME,
@NumeroAsiento	INT OUTPUT
AS
BEGIN
	SET @NumeroAsiento = (SELECT MAX(NumeroAsiento)
							FROM dbo.Asientos
							WHERE Fecha = @Fecha)
END
GO



DROP PROCEDURE ObtenerFechaEstado
GO
CREATE PROCEDURE ObtenerFechaEstado
@Fecha			DATETIME,
@Estado			VARCHAR(10),
@NumeroAsiento	INT OUTPUT
AS
BEGIN
	SET @NumeroAsiento = (SELECT MAX(NumeroAsiento)
							FROM dbo.Asientos
							WHERE (Fecha = @Fecha)
							AND (Estado = @Estado))
END
GO



DROP PROC ListarAsientoBusqueda
GO

CREATE PROC ListarAsientoBusqueda
@Criterio		VARCHAR(32),
@Fecha1			DATE,
@Fecha2			DATE,
@Estado			VARCHAR(10)
AS
BEGIN
	SELECT NumeroAsiento, CodigoUsuario, Fecha, Hora, Glosa, Estado
	FROM dbo.Asientos
	WHERE ((CONVERT(VARCHAR(10), NumeroAsiento) = @Criterio) OR (Glosa LIKE '%'+@Criterio+'%')) AND (CONVERT(DATETIME, CONVERT(VARCHAR(10), Fecha, 21), 21) BETWEEN CONVERT(DATETIME, @Fecha1, 21) AND CONVERT(DATETIME, @Fecha2, 21)) AND (Estado = @Estado)
	ORDER BY Fecha
END
GO


DROP PROC ListarAsientoBusquedaTodos
GO

CREATE PROC ListarAsientoBusquedaTodos
@Criterio		VARCHAR(32),
@Fecha1			DATE,
@Fecha2			DATE
AS
BEGIN
	SELECT NumeroAsiento, CodigoUsuario, Fecha, Hora, Glosa, Estado
	FROM dbo.Asientos
	WHERE ((CONVERT(VARCHAR(32), NumeroAsiento) LIKE '%'+@Criterio+'%') OR (Glosa LIKE '%'+@Criterio+'%')) AND (CONVERT(DATETIME, CONVERT(VARCHAR(10), Fecha, 21), 21) BETWEEN CONVERT(DATETIME, @Fecha1, 21) AND CONVERT(DATETIME, @Fecha2, 21))
	ORDER BY Fecha
END
GO