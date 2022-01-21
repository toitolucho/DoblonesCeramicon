USE Doblones20
GO


DROP PROCEDURE ListarDatosCodigosProductosEspecificosReporte
GO


CREATE PROCEDURE ListarDatosCodigosProductosEspecificosReporte
	@NumeroAgencia				INT,
	@NumeroCompraProducto		INT,
	@CodigoProducto				CHAR(15),
	@CodigoProductoEspecifico	CHAR(30)
		
AS
BEGIN
	IF(@CodigoProducto IS NULL OR @CodigoProducto ='') 
	BEGIN
		SELECT CPE.CodigoProductoEspecifico, CPE.CodigoProducto, dbo.ObtenerNombreProducto(CPE.CodigoProducto) AS NombreProducto
		FROM ComprasProductosEspecificos CPE
		WHERE CPE.NumeroAgencia = @NumeroAgencia AND CPE.NumeroCompraProducto = @NumeroCompraProducto
	END
	ELSE
	BEGIN
		SELECT IPE.CodigoProductoEspecifico, IPE.CodigoProducto, dbo.ObtenerNombreProducto(IPE.CodigoProducto) AS NombreProducto
		FROM InventariosProductosEspecificos IPE
		WHERE IPE.NumeroAgencia = @NumeroAgencia AND IPE.CodigoProducto = @CodigoProducto AND IPE.CodigoProductoEspecifico = @CodigoProductoEspecifico
	END	
END