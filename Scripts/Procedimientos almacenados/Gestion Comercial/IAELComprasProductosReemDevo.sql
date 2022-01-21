USE DOBLONES20
GO

DROP PROCEDURE InsertarCompraProductoReemDevo
GO

CREATE PROCEDURE InsertarCompraProductoReemDevo
	@NumeroAgencia					INT,	
	@NumeroCompraProducto			INT,
	@CodigoUsuario					INT,
	@FechaHoraSolicitudReemDevo		DATETIME,
	@ObservacionesSolicitudReemDevo	TEXT
AS
BEGIN
	INSERT INTO dbo.ComprasProductosReemDevo(NumeroAgencia, NumeroCompraProducto, CodigoUsuario, FechaHoraSolicitudReemDevo, ObservacionesSolicitudReemDevo)
	VALUES (@NumeroAgencia, @NumeroCompraProducto, @CodigoUsuario, @FechaHoraSolicitudReemDevo, @ObservacionesSolicitudReemDevo)
END
GO

DROP PROCEDURE ActualizarCompraProductoReemDevo
GO

CREATE PROCEDURE ActualizarCompraProductoReemDevo
	@NumeroAgencia					INT,	
	@NumeroReemDevo					INT,
	@NumeroCompraProducto			INT,
	@CodigoUsuario					INT,
	@FechaHoraSolicitudReemDevo		DATETIME,
	@ObservacionesSolicitudReemDevo	TEXT
AS
BEGIN
	UPDATE 	dbo.ComprasProductosReemDevo
	SET	
		CodigoUsuario					= @CodigoUsuario,						
		FechaHoraSolicitudReemDevo		= @FechaHoraSolicitudReemDevo,
		ObservacionesSolicitudReemDevo	= @ObservacionesSolicitudReemDevo,
		NumeroCompraProducto			= @NumeroCompraProducto
	WHERE		(NumeroReemDevo				= @NumeroReemDevo)
			AND (NumeroAgencia				= @NumeroAgencia)	
END
GO

DROP PROCEDURE EliminarCompraProductoReemDevo
GO

CREATE PROCEDURE EliminarCompraProductoReemDevo
	@NumeroAgencia			INT,
	@NumeroReemDevo			INT
AS
BEGIN
	DELETE 
	FROM dbo.ComprasProductosReemDevo
	WHERE		(NumeroReemDevo				= @NumeroReemDevo) 			
			AND (NumeroAgencia				= @NumeroAgencia)			
END
GO

DROP PROCEDURE ListarComprasProductosReemDevo
GO

CREATE PROCEDURE ListarComprasProductosReemDevo 
	@NumeroAgencia	INT
AS
BEGIN
	SELECT NumeroAgencia,NumeroReemDevo,NumeroCompraProducto, CodigoUsuario, FechaHoraSolicitudReemDevo, ObservacionesSolicitudReemDevo
	FROM dbo.ComprasProductosReemDevo
	WHERE (NumeroAgencia= @NumeroAgencia)
	ORDER BY NumeroAgencia, NumeroReemDevo

END
GO

DROP PROCEDURE ObtenerCompraProductoReemDevo
GO

CREATE PROCEDURE ObtenerCompraProductoReemDevo
	@NumeroAgencia			INT,	
	@NumeroReemDevo			INT	
AS
BEGIN
	SELECT NumeroAgencia,NumeroReemDevo,NumeroCompraProducto, CodigoUsuario, FechaHoraSolicitudReemDevo, ObservacionesSolicitudReemDevo
	FROM dbo.ComprasProductosReemDevo
	WHERE		(NumeroReemDevo				= @NumeroReemDevo) 			
			AND (NumeroAgencia				= @NumeroAgencia)	
END
GO



--DROP PROCEDURE ObtenerComprasProductosReemDevo
--GO
--CREATE PROCEDURE ObtenerComprasProductosReemDevo	
--AS
--BEGIN
--	SELECT NumeroAgencia,NumeroReemDevo,NumeroCompraProducto,FechaHoraSolicitudReemDevo,ObservacionesSolicitudReemDevo
--	FROM dbo.ComprasProductosReemDevo	
--END
--GO
