USE DOBLONES20
GO


DROP PROCEDURE ListarProductosEspecificosPorProducto
GO

CREATE PROCEDURE ListarProductosEspecificosPorProducto
	@NumeroAgencia	INT,
	@CodigoProducto	CHAR(15)
AS
BEGIN
	SELECT IPE.CodigoProducto,IPE.CodigoProductoEspecifico,IPE.TiempoGarantiaPECompra,IPE.FechaHoraVencimientoPE, IPE.CodigoEstado
	FROM dbo.InventariosProductosEspecificos IPE
	WHERE IPE.NumeroAgencia = @NumeroAgencia AND IPE.CodigoProducto=@CodigoProducto
			AND (IPE.CodigoEstado = 'A') --OR IPE.CodigoEstado = 'T')
	ORDER BY IPE.NumeroAgencia,IPE.CodigoProducto,IPE.CodigoProductoEspecifico
END
GO


--exec ListarProductosEspecificosPorProducto 1,'6'