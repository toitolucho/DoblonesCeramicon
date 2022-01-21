USE DOBLONES20
GO


DROP PROCEDURE InsertarCompraProductoDetalle
GO
CREATE PROCEDURE InsertarCompraProductoDetalle
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@CodigoProducto			CHAR(15),
	@CantidadCompra			INT,
	@PrecioUnitarioCompra	DECIMAL(10,2),
	@TiempoGarantiaCompra	INT
AS
BEGIN

	IF(NOT EXISTS( SELECT * FROM ComprasProductosDetalle WHERE NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroCompraProducto AND CodigoProducto = @CodigoProducto ))
	BEGIN	
		INSERT INTO dbo.ComprasProductosDetalle (NumeroAgencia,NumeroCompraProducto,CodigoProducto,CantidadCompra,PrecioUnitarioCompra,TiempoGarantiaCompra)
		VALUES (@NumeroAgencia,@NumeroCompraProducto,@CodigoProducto,@CantidadCompra,@PrecioUnitarioCompra,@TiempoGarantiaCompra)
	END
	ELSE
		EXEC ActualizarCompraProductoDetalle @NumeroAgencia, @NumeroCompraProducto, @CodigoProducto, @CantidadCompra, @PrecioUnitarioCompra, @TiempoGarantiaCompra
		
END
GO



DROP PROCEDURE ActualizarCompraProductoDetalle
GO
CREATE PROCEDURE ActualizarCompraProductoDetalle	
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@CodigoProducto			CHAR(15),
	@CantidadCompra			INT,
	@PrecioUnitarioCompra	DECIMAL(10,2),
	@TiempoGarantiaCompra	INT
AS
BEGIN
	UPDATE 	dbo.ComprasProductosDetalle
	SET						
		CodigoProducto			= @CodigoProducto,
		CantidadCompra			= @CantidadCompra,
		PrecioUnitarioCompra	= @PrecioUnitarioCompra,
		TiempoGarantiaCompra	= @TiempoGarantiaCompra
	WHERE (NumeroCompraProducto = @NumeroCompraProducto) AND (CodigoProducto = @CodigoProducto)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE EliminarCompraProductoDetalle
GO
CREATE PROCEDURE EliminarCompraProductoDetalle
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@CodigoProducto			CHAR(15)
AS
BEGIN
	DELETE 
	FROM dbo.ComprasProductosDetalle
	WHERE (NumeroCompraProducto = @NumeroCompraProducto) AND (CodigoProducto = @CodigoProducto)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE ListarComprasProductosDetalle
GO
CREATE PROCEDURE ListarComprasProductosDetalle
	@NumeroAgencia	INT
AS
BEGIN
	SELECT NumeroAgencia,NumeroCompraProducto,CodigoProducto,CantidadCompra,PrecioUnitarioCompra,TiempoGarantiaCompra
	FROM dbo.ComprasProductosDetalle
	WHERE (NumeroAgencia= @NumeroAgencia)
	ORDER BY NumeroAgencia, NumeroCompraProducto, CodigoProducto
END
GO



DROP PROCEDURE ObtenerCompraProductoDetalle
GO
CREATE PROCEDURE ObtenerCompraProductoDetalle
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@CodigoProducto			CHAR(15)
AS
BEGIN
	SELECT NumeroAgencia,NumeroCompraProducto,CodigoProducto,CantidadCompra,PrecioUnitarioCompra,TiempoGarantiaCompra
	FROM dbo.ComprasProductosDetalle
	WHERE (NumeroCompraProducto = @NumeroCompraProducto) AND (CodigoProducto = @CodigoProducto)
		AND (NumeroAgencia = @NumeroAgencia)
END
GO



DROP PROCEDURE ListarCompraProductoDetalleReporte
GO

CREATE PROCEDURE ListarCompraProductoDetalleReporte
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT
AS
BEGIN
	SELECT	P.NombreProducto , CPD.CodigoProducto, CPE.CodigoProductoEspecifico, 
			CPD.CantidadCompra, CPD.PrecioUnitarioCompra, 
			(CPD.CantidadCompra*CPD.PrecioUnitarioCompra) as PrecioTotalVenta, 
			CPD.TiempoGarantiaCompra, CPE.TiempoGarantiaPE, PU.NombreUnidad, PorcentajeDescuento
	FROM ComprasProductosDetalle CPD 
	INNER JOIN Productos P 
	ON P.CodigoProducto = CPD.CodigoProducto
	INNER JOIN ProductosUnidades PU
	ON PU.CodigoUnidad = P.CodigoUnidad
	LEFT JOIN ComprasProductosEspecificos CPE 
	ON CPD.NumeroAgencia = CPE.NumeroAgencia AND CPD.NumeroCompraProducto = CPE.NumeroCompraProducto
	AND CPD.CodigoProducto = CPE.CodigoProducto	
	WHERE CPD.NumeroAgencia = @NumeroAgencia
	AND CPD.NumeroCompraProducto = @NumeroCompraProducto
END
GO


DROP PROCEDURE ListarCompraProductoDetalleReporteIncluidoAgregados
GO

CREATE PROCEDURE ListarCompraProductoDetalleReporteIncluidoAgregados
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,	
	@TipoCalculoAgregado	CHAR(1), -- 'P'->Promedio, 'S'->Sumatoria
	@IncluirAgregados		BIT
AS
BEGIN
	IF(@IncluirAgregados = 1)	
	BEGIN
		SELECT TA.*, PU.NombreUnidad
		FROM
		(
		SELECT dbo.ObtenerNombreProducto(VPD.CodigoProducto) as NombreProducto , 
				VPD.CodigoProducto, VPD.CantidadCompra, CAST(VPD.PrecioUnitarioCompra AS DECIMAL(10,2)) AS PrecioUnitarioCompra, 
				(VPD.CantidadCompra*VPD.PrecioUnitarioCompra) as PrecioTotalCompra, 
				VPD.TiempoGarantiaCompra, VPD.PorcentajeDescuento
		FROM ComprasProductosDetalle VPD 
		WHERE VPD.NumeroAgencia = @NumeroAgencia
		AND VPD.NumeroCompraProducto = @NumeroCompraProducto
		UNION 
		SELECT dbo.ObtenerNombreProducto(VPEA.CodigoProducto) as NombreProducto , 
				VPEA.CodigoProducto, COUNT(VPEA.CodigoProducto) AS CantidadCompra, 
				CAST(AVG(VPEA.PrecioUnitario) AS DECIMAL(10,2)) AS PrecioUnitarioCompra, 
				CASE (@TipoCalculoAgregado) WHEN 'P' THEN CAST((COUNT(VPEA.CodigoProducto)*AVG(VPEA.PrecioUnitario)) AS DECIMAL(10,2)) WHEN 'S' THEN CAST(SUM(VPEA.PrecioUnitario)AS DECIMAL(10,2)) END as PrecioTotalCompra, 
				VPEA.TiempoGarantiaPE , 0   
		FROM ComprasProductosEspecificosAgregados VPEA 
		WHERE VPEA.NumeroAgencia = @NumeroAgencia
		AND VPEA.NumeroCompraProducto = @NumeroCompraProducto
		GROUP BY VPEA.CodigoProducto ,VPEA.TiempoGarantiaPE
		) TA
		INNER JOIN Productos P
		ON TA.CodigoProducto = P.CodigoProducto
		INNER JOIN ProductosUnidades PU
		ON P.CodigoUnidad = PU.CodigoUnidad
		
	END
	ELSE
	BEGIN
		SELECT P.NombreProducto , VPD.CodigoProducto, VPD.CantidadCompra, 
				CAST(VPD.PrecioUnitarioCompra AS DECIMAL(10,2)) AS PrecioUnitarioCompra, 
				(VPD.CantidadCompra*VPD.PrecioUnitarioCompra) as PrecioTotalCompra, 
				VPD.TiempoGarantiaCompra, VPD.PorcentajeDescuento, PU.NombreUnidad
		FROM ComprasProductosDetalle VPD 
		INNER JOIN Productos P
		ON VPD.CodigoProducto = P.CodigoProducto
		INNER JOIN ProductosUnidades PU
		ON PU.CodigoUnidad = P.CodigoUnidad
		WHERE VPD.NumeroAgencia = @NumeroAgencia
		AND VPD.NumeroCompraProducto = @NumeroCompraProducto
		ORDER BY CodigoProducto
	END	
END
GO

--exec ListarCompraProductoDetalleReporteIncluidoAgregados 1,2,'S',0

--DROP PROCEDURE ObtenerComprasProductosDetalle
--GO
--CREATE PROCEDURE ObtenerComprasProductosDetalle
--	@NumeroAgencia			INT,
--	@NumeroCompraProducto	INT,
--	@CodigoProducto			CHAR(15)
--AS
--BEGIN
--	SELECT NumeroAgencia,NumeroCompraProducto,CodigoProducto,CantidadCompra,PrecioUnitarioCompra,TiempoGarantiaCompra
--	FROM dbo.ComprasProductosDetalle
--	WHERE (NumeroCompraProducto = @NumeroCompraProducto) AND (CodigoProducto = @CodigoProducto)
--		AND (NumeroAgencia = @NumeroAgencia)

--END
--GO



DROP PROCEDURE EliminarCompraProductoDetalleDesdeListado
GO


CREATE PROCEDURE EliminarCompraProductoDetalleDesdeListado
	@NumeroAgencia			INT,
	@NumeroCompraProducto	INT,
	@ListadoCodigoProducto	VARCHAR(1000)	
AS
BEGIN
	DECLARE @NumeroAgenciaCadena			VARCHAR(10) = RTRIM(LTRIM(CAST( @NumeroAgencia AS CHAR(10)))),
			@NumeroCompraProductoCadena		VARCHAR(8000) = RTRIM(LTRIM(CAST( @NumeroCompraProducto AS VARCHAR(8000))))	
	
	EXEC('DELETE FROM ComprasProductosDetalle
	WHERE NumeroAgencia ='+ @NumeroAgenciaCadena + 'AND NumeroCompraProducto =  '+@NumeroCompraProductoCadena+
	' AND CodigoProducto NOT IN ( '+@ListadoCodigoProducto +') AND dbo.EsProductoEspecifico('+ @NumeroAgenciaCadena + ',CodigoProducto) = 0')
END
