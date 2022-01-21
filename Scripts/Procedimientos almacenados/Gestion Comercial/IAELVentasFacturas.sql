USE DOBLONES20
GO

DROP PROCEDURE InsertarVentaFactura
GO

CREATE PROCEDURE InsertarVentaFactura
@NumeroAgencia			INT,
@NumeroFactura			INT,
@NombreFactura			VARCHAR(160),
@NITFactura				VARCHAR(30),
@FechaHoraFactura		DATETIME
AS
BEGIN
	INSERT INTO dbo.VentasFacturas(NumeroAgencia, NumeroFactura, NombreFactura, NITFactura, FechaHoraFactura)
	VALUES (@NumeroAgencia, @NumeroFactura, @NombreFactura,@NITFactura, @FechaHoraFactura)
END
GO

DROP PROCEDURE ActualizarVentaFactura
GO

CREATE PROCEDURE ActualizarVentaFactura
@NumeroAgencia			INT,
@NumeroFactura			INT,
@NombreFactura			VARCHAR(160),
@NITFactura				VARCHAR(30),
@FechaHoraFactura		DATETIME
AS
BEGIN
	UPDATE 	dbo.VentasFacturas
	SET		
		NumeroAgencia		= @NumeroAgencia,
		NumeroFactura		= @NumeroFactura,
		NombreFactura		= @NombreFactura,
		NITFactura			= @NITFactura,
		FechaHoraFactura	= @FechaHoraFactura
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroFactura = @NumeroFactura
END
GO

DROP PROCEDURE EliminarVentaFactura
GO

CREATE PROCEDURE EliminarVentaFactura
@NumeroAgencia			INT,
@NumeroFactura			INT
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroFactura = @NumeroFactura
END
GO

DROP PROCEDURE ListarVentasFacturas
GO

CREATE PROCEDURE ListarVentasFacturas
AS
BEGIN
	SELECT NumeroAgencia, NumeroFactura, NombreFactura, NITFactura, FechaHoraFactura
	FROM dbo.VentasFacturas
	ORDER BY NumeroFactura
END
GO

DROP PROCEDURE ObtenerVentaFactura
GO

CREATE PROCEDURE ObtenerVentaFactura
@NumeroAgencia			INT,
@NumeroFactura			INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroFactura, NombreFactura, NITFactura, FechaHoraFactura
	FROM dbo.VentasFacturas
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroFactura = @NumeroFactura
END