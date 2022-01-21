USE DOBLONES20
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'InsertarTransferenciasProductoDetalle') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE InsertarTransferenciasProductoDetalle
	END
GO
CREATE PROCEDURE InsertarTransferenciasProductoDetalle
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoProducto					CHAR(15),
	@CantidadTransferencia			INT,
	@PrecioUnitarioTransferencia	DECIMAL(10,2),
	@MontoAdicionalPorGastos		DECIMAL(5,2)
	
AS
BEGIN
	IF( NOT EXISTS (
			SELECT * FROM TransferenciasProductosDetalle WHERE NumeroAgenciaEmisora = @NumeroAgenciaEmisora AND NumeroTransferenciaProducto = @NumeroTransferenciaProducto
			AND CodigoProducto = @CodigoProducto
		))
	BEGIN
		INSERT INTO dbo.TransferenciasProductosDetalle(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, CantidadTransferencia, PrecioUnitarioTransferencia, MontoAdicionalPorGastos)
		VALUES (@NumeroAgenciaEmisora, @NumeroTransferenciaProducto, @CodigoProducto, @CantidadTransferencia, @PrecioUnitarioTransferencia, @MontoAdicionalPorGastos)
	END
	ELSE
		EXEC ActualizarTransferenciasProductoDetalle @NumeroAgenciaEmisora, @NumeroTransferenciaProducto, @CodigoProducto, @CantidadTransferencia, @PrecioUnitarioTransferencia, @MontoAdicionalPorGastos
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ActualizarTransferenciasProductoDetalle') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ActualizarTransferenciasProductoDetalle
	END
GO	
CREATE PROCEDURE ActualizarTransferenciasProductoDetalle
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoProducto					CHAR(15),
	@CantidadTransferencia			INT,
	@PrecioUnitarioTransferencia	DECIMAL(10,2),
	@MontoAdicionalPorGastos		DECIMAL(5,2)
AS
BEGIN
	UPDATE 	dbo.TransferenciasProductosDetalle
	SET						
		CantidadTransferencia		= @CantidadTransferencia,
		PrecioUnitarioTransferencia	= @PrecioUnitarioTransferencia,
		MontoAdicionalPorGastos		= @MontoAdicionalPorGastos
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 			
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
			AND (CodigoProducto = @CodigoProducto)
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'EliminarTransferenciasProductoDetalle') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE EliminarTransferenciasProductoDetalle
	END
GO	
CREATE PROCEDURE EliminarTransferenciasProductoDetalle
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoProducto					CHAR(15)
AS
BEGIN
	DELETE 
	FROM dbo.TransferenciasProductosDetalle
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)			
			AND (CodigoProducto = @CodigoProducto) 			
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciasProductosDetalle') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciasProductosDetalle
	END
GO	
CREATE PROCEDURE ListarTransferenciasProductosDetalle
	@NumeroAgenciaEmisora INT
AS
BEGIN
	SELECT NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, CantidadTransferencia, PrecioUnitarioTransferencia, MontoAdicionalPorGastos
	FROM dbo.TransferenciasProductosDetalle
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora)
	ORDER BY NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ObtenerTransferenciasProductoDetalle') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ObtenerTransferenciasProductoDetalle
	END
GO	
CREATE PROCEDURE ObtenerTransferenciasProductoDetalle
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoProducto					CHAR(15)	
AS
BEGIN
	SELECT NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, CantidadTransferencia, PrecioUnitarioTransferencia, MontoAdicionalPorGastos
	FROM dbo.TransferenciasProductosDetalle
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)			
			AND (CodigoProducto = @CodigoProducto)  			
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciasProductosDetalleParaMostrar') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciasProductosDetalleParaMostrar
	END
GO	
CREATE PROCEDURE ListarTransferenciasProductosDetalleParaMostrar
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT
AS
BEGIN
	SELECT CodigoProducto, dbo.ObtenerNombreProducto(CodigoProducto) AS NombreProducto, CantidadTransferencia, PrecioUnitarioTransferencia, MontoAdicionalPorGastos
	FROM TransferenciasProductosDetalle 
	WHERE (NumeroAgenciaEmisora = @NumeroAgenciaEmisora) 
			AND (NumeroTransferenciaProducto = @NumeroTransferenciaProducto)
END
GO



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciaProductosEnviadosRecepcionados') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciaProductosEnviadosRecepcionados
	END
GO	
CREATE PROCEDURE ListarTransferenciaProductosEnviadosRecepcionados
	@NumeroAgencia					INT,
	@NumeroTransferenciaProducto	INT,
	@TipoRecepcionEnvio				CHAR(1),-- 'R'->Recepcion ;  'E'->Envio
	@MostrarSoloFaltantes			BIT	
AS
BEGIN
	IF(EXISTS( SELECT NumeroTransferenciaProducto FROM TransferenciasProductos WHERE NumeroTransferenciaProducto = @NumeroTransferenciaProducto))
	BEGIN
		IF(@TipoRecepcionEnvio = 'R' AND @MostrarSoloFaltantes = 1 )
		BEGIN	
			SET @NumeroAgencia = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)
			SELECT TPD.CodigoProducto, dbo.ObtenerNombreProducto(TPD.CodigoProducto) AS NombreProducto, TPD.CantidadTransferencia, TPD.PrecioUnitarioTransferencia + TPD.MontoAdicionalPorGastos + TPD.MontoAdicionalPorGastosRecepcion AS PrecioUnitarioTransferencia, ISNULL(TPDR.CantidadRecepcionadaEnviada,0) AS CantidadRecepcionadaEnviada, dbo.EsProductoEspecifico(@NumeroAgencia, TPD.CodigoProducto) AS EsProductoEspecifico
			FROM
			(				
				SELECT  NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, ISNULL(SUM(CantidadEnvioRecepcion),0) AS CantidadRecepcionadaEnviada
				FROM TransferenciasProductosDetalleRecepcion
				WHERE NumeroAgenciaEmisora = @NumeroAgencia and NumeroTransferenciaProducto = @NumeroTransferenciaProducto
				AND CodigoTipoEnvioRecepcion IN('R','X')
				GROUP BY NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto
			) TPDR			
			RIGHT JOIN TransferenciasProductosDetalle TPD
			ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto AND TPD.CodigoProducto = TPDR.CodigoProducto
			WHERE TPD.NumeroAgenciaEmisora = @NumeroAgencia AND TPD.NumeroTransferenciaProducto = @NumeroTransferenciaProducto
			AND ISNULL(TPDR.CantidadRecepcionadaEnviada,0) <> TPD.CantidadTransferencia
		END
		ELSE IF(@TipoRecepcionEnvio = 'R' AND @MostrarSoloFaltantes = 0 )
		BEGIN	
			SET @NumeroAgencia = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)
			print 'recepcion'
			SELECT TPD.CodigoProducto, dbo.ObtenerNombreProducto(TPD.CodigoProducto) AS NombreProducto, TPD.CantidadTransferencia, TPD.PrecioUnitarioTransferencia + TPD.MontoAdicionalPorGastos AS PrecioUnitarioTransferencia,  ISNULL(TPDR.CantidadRecepcionadaEnviada,0) AS CantidadRecepcionadaEnviada, dbo.EsProductoEspecifico(@NumeroAgencia,TPD.CodigoProducto) AS EsProductoEspecifico
			FROM
			(
				SELECT  NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, ISNULL(SUM(CantidadEnvioRecepcion),0) AS CantidadRecepcionadaEnviada
				FROM TransferenciasProductosDetalleRecepcion
				WHERE NumeroAgenciaEmisora = @NumeroAgencia and NumeroTransferenciaProducto = @NumeroTransferenciaProducto
				AND CodigoTipoEnvioRecepcion IN('R','X')
				GROUP BY NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto
			) TPDR
			RIGHT JOIN TransferenciasProductosDetalle TPD
			ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto AND TPD.CodigoProducto = TPDR.CodigoProducto
			WHERE TPD.NumeroAgenciaEmisora = @NumeroAgencia AND TPD.NumeroTransferenciaProducto = @NumeroTransferenciaProducto				
		END
		ELSE IF (@TipoRecepcionEnvio = 'E' AND @MostrarSoloFaltantes = 1)
		BEGIN
			print 'envio'
			SELECT TPD.CodigoProducto, dbo.ObtenerNombreProducto(TPD.CodigoProducto) AS NombreProducto, TPD.CantidadTransferencia, TPD.PrecioUnitarioTransferencia + TPD.MontoAdicionalPorGastos AS PrecioUnitarioTransferencia,  ISNULL(TPDR.CantidadRecepcionadaEnviada,0) AS CantidadRecepcionadaEnviada, dbo.EsProductoEspecifico(@NumeroAgencia,TPD.CodigoProducto) AS EsProductoEspecifico
			FROM
			(
				SELECT  NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, CodigoTipoEnvioRecepcion, ISNULL(SUM(CantidadEnvioRecepcion),0) AS CantidadRecepcionadaEnviada
				FROM TransferenciasProductosDetalleRecepcion
				WHERE NumeroAgenciaEmisora = @NumeroAgencia and NumeroTransferenciaProducto = @NumeroTransferenciaProducto
				AND CodigoTipoEnvioRecepcion = 'E'
				GROUP BY NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, CodigoTipoEnvioRecepcion				
			) TPDR
			RIGHT JOIN TransferenciasProductosDetalle TPD
			ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto AND TPD.CodigoProducto = TPDR.CodigoProducto
			WHERE TPD.NumeroAgenciaEmisora = @NumeroAgencia AND TPD.NumeroTransferenciaProducto = @NumeroTransferenciaProducto
			AND ISNULL(TPDR.CantidadRecepcionadaEnviada,0) <> TPD.CantidadTransferencia
		END		
		ELSE IF (@TipoRecepcionEnvio = 'E' AND @MostrarSoloFaltantes = 0)
		BEGIN
			print 'envio'
			SELECT TPD.CodigoProducto, dbo.ObtenerNombreProducto(TPD.CodigoProducto) AS NombreProducto, TPD.CantidadTransferencia, TPD.PrecioUnitarioTransferencia + TPD.MontoAdicionalPorGastos AS PrecioUnitarioTransferencia,  ISNULL(TPDR.CantidadRecepcionadaEnviada,0) AS CantidadRecepcionadaEnviada, dbo.EsProductoEspecifico(@NumeroAgencia,TPD.CodigoProducto) AS EsProductoEspecifico
			FROM
			(
				SELECT  NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, CodigoTipoEnvioRecepcion, ISNULL(SUM(CantidadEnvioRecepcion),0) AS CantidadRecepcionadaEnviada
				FROM TransferenciasProductosDetalleRecepcion
				WHERE NumeroAgenciaEmisora = @NumeroAgencia and NumeroTransferenciaProducto = @NumeroTransferenciaProducto
				AND CodigoTipoEnvioRecepcion = 'E'
				GROUP BY NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, CodigoTipoEnvioRecepcion
			) TPDR
			RIGHT JOIN TransferenciasProductosDetalle TPD
			ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto AND TPD.CodigoProducto = TPDR.CodigoProducto
			WHERE TPD.NumeroAgenciaEmisora = @NumeroAgencia AND TPD.NumeroTransferenciaProducto = @NumeroTransferenciaProducto			
		END	
	END	
END
GO

--exec ListarTransferenciaProductosEnviadosRecepcionados 3,7, 'R',1
exec ListarTransferenciaProductosEnviadosRecepcionados 3,1, 'R',0
--select * from TransferenciasProductos


SELECT TPD.CodigoProducto, dbo.ObtenerNombreProducto(TPD.CodigoProducto) AS NombreProducto, TPD.CantidadTransferencia, TPD.PrecioUnitarioTransferencia + TPD.MontoAdicionalPorGastos AS PrecioUnitarioTransferencia,  ISNULL(TPDR.CantidadRecepcionadaEnviada,0) AS CantidadRecepcionadaEnviada, dbo.EsProductoEspecifico(@NumeroAgencia,TPD.CodigoProducto) AS EsProductoEspecifico
FROM
(
	SELECT  NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, ISNULL(SUM(CantidadEnvioRecepcion),0) AS CantidadRecepcionadaEnviada
	FROM TransferenciasProductosDetalleRecepcion
	WHERE NumeroAgenciaEmisora = 1 and NumeroTransferenciaProducto = 1
	AND CodigoTipoEnvioRecepcion IN('R','X')
	GROUP BY NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto
) TPDR
RIGHT JOIN TransferenciasProductosDetalle TPD
ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora AND TPD.NumeroTransferenciaProducto = TPDR.NumeroTransferenciaProducto AND TPD.CodigoProducto = TPDR.CodigoProducto
WHERE TPD.NumeroAgenciaEmisora = @NumeroAgencia AND TPD.NumeroTransferenciaProducto = @NumeroTransferenciaProducto



IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciaProductosEnviadosPorFecha') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciaProductosEnviadosPorFecha
	END
GO	
CREATE PROCEDURE ListarTransferenciaProductosEnviadosPorFecha
	@NumeroAgencia					INT,
	@NumeroTransferenciaProducto	INT,	
	@FechaEnvio						DATETIME
AS
BEGIN
	IF(EXISTS( SELECT NumeroTransferenciaProducto FROM TransferenciasProductos WHERE NumeroTransferenciaProducto = @NumeroTransferenciaProducto))
	BEGIN
		SET @NumeroAgencia = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgencia)
		IF(@FechaEnvio IS NULL)--LISTAR TODOS LOS PRODUCTOS ENVIADOS
		BEGIN			
			SELECT DISTINCT TPD.CodigoProducto, dbo.ObtenerNombreProducto(TPD.CodigoProducto) as NombreProducto, TPD.CantidadTransferencia, CAST((TPD.PrecioUnitarioTransferencia + TPD.MontoAdicionalPorGastos/TPDE.CantidadEnvio) AS DECIMAL(10,2)) AS PrecioUnitarioTransferencia, TPDE.CantidadEnvio, ISNULL(TPDR.CantidadRecepcionada,0) AS CantidadRecepcionada, dbo.EsProductoEspecifico(TPD.NumeroAgenciaEmisora, TPD.CodigoProducto) as EsProductoEspecifico,  CASE(P.CodigoTipoCalculoInventario) WHEN 'U' THEN 'UEPS' WHEN 'P' THEN 'PEPS' WHEN 'O' THEN 'PONDERADO' WHEN 'B' THEN 'PRECIO MAS BAJO' WHEN 'A' THEN 'PRECIO MAS ALTO' WHEN 'T' THEN 'ULTIMO PRECIO' END AS TipoCalculoInventario, CodigoTipoCalculoInventario
			FROM TransferenciasProductosDetalle TPD
			INNER JOIN 
			(
				SELECT NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto,   SUM(CantidadEnvioRecepcion) AS CantidadEnvio
				FROM TransferenciasProductosDetalleRecepcion
				WHERE CodigoTipoEnvioRecepcion = 'E'
				GROUP BY NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto
			) TPDE
			ON TPD.NumeroAgenciaEmisora = TPDE.NumeroAgenciaEmisora
			AND TPD.NumeroTransferenciaProducto = TPDE.NumeroTransferenciaProducto
			AND TPD.CodigoProducto = TPDE.CodigoProducto
			LEFT JOIN
			(
				SELECT NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto,   SUM(CantidadEnvioRecepcion) AS CantidadRecepcionada
				FROM TransferenciasProductosDetalleRecepcion
				WHERE CodigoTipoEnvioRecepcion IN ('R','X')
				GROUP BY NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto
			) TPDR
			ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TPD.NumeroTransferenciaProducto = TPDR.NumeroAgenciaEmisora
			AND TPD.CodigoProducto = TPDR.CodigoProducto
			INNER JOIN Productos P
			ON TPD.CodigoProducto = P.CodigoProducto						
			WHERE TPD.NumeroAgenciaEmisora = @NumeroAgencia
			AND TPD.NumeroTransferenciaProducto = @NumeroTransferenciaProducto		
			AND TPDE.CantidadEnvio > ISNULL(TPDR.CantidadRecepcionada,0)
		END
		ELSE -- LISTAR LOS PRODUCTOS ENVIADOS EN UNA DETERMINADA FECHA
		BEGIN				
			SELECT DISTINCT TPD.CodigoProducto, dbo.ObtenerNombreProducto(TPD.CodigoProducto) as NombreProducto, TPD.CantidadTransferencia, CAST((TPD.PrecioUnitarioTransferencia + TPD.MontoAdicionalPorGastos/TPDE.CantidadEnvio) AS DECIMAL(10,2)) AS PrecioUnitarioTransferencia, TPDE.CantidadEnvio, ISNULL(TPDR.CantidadRecepcionada,0) AS CantidadRecepcionada, dbo.EsProductoEspecifico(TPD.NumeroAgenciaEmisora, TPD.CodigoProducto) as EsProductoEspecifico,  CASE(P.CodigoTipoCalculoInventario) WHEN 'U' THEN 'UEPS' WHEN 'P' THEN 'PEPS' WHEN 'O' THEN 'PONDERADO' WHEN 'B' THEN 'PRECIO MAS BAJO' WHEN 'A' THEN 'PRECIO MAS ALTO' WHEN 'T' THEN 'ULTIMO PRECIO' END AS TipoCalculoInventario, CodigoTipoCalculoInventario
			FROM TransferenciasProductosDetalle TPD
			INNER JOIN 
			(
				SELECT NumeroAgenciaEmisora, NumeroTransferenciaProducto, FechaHoraEnvioRecepcion, CodigoProducto, SUM(CantidadEnvioRecepcion) AS CantidadEnvio
				FROM TransferenciasProductosDetalleRecepcion
				WHERE CodigoTipoEnvioRecepcion = 'E' AND FechaHoraEnvioRecepcion = @FechaEnvio
				AND NumeroAgenciaEmisora = @NumeroAgencia and NumeroTransferenciaProducto = @NumeroTransferenciaProducto
				GROUP BY NumeroAgenciaEmisora, NumeroTransferenciaProducto, FechaHoraEnvioRecepcion, CodigoProducto 
			) TPDE
			ON TPD.NumeroAgenciaEmisora = TPDE.NumeroAgenciaEmisora
			AND TPD.NumeroTransferenciaProducto = TPDE.NumeroTransferenciaProducto
			AND TPD.CodigoProducto = TPDE.CodigoProducto
			LEFT JOIN
			(
				SELECT NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto,   SUM(CantidadEnvioRecepcion) AS CantidadRecepcionada
				FROM TransferenciasProductosDetalleRecepcion
				WHERE CodigoTipoEnvioRecepcion IN ('R','X')
				AND FechaHoraEnvioPadre = @FechaEnvio
				AND NumeroAgenciaEmisora = @NumeroAgencia and NumeroTransferenciaProducto = @NumeroTransferenciaProducto
				GROUP BY NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto
			) TPDR
			ON TPD.NumeroAgenciaEmisora = TPDR.NumeroAgenciaEmisora
			AND TPD.NumeroTransferenciaProducto = TPDR.NumeroAgenciaEmisora
			AND TPD.CodigoProducto = TPDR.CodigoProducto
			INNER JOIN Productos P
			ON TPD.CodigoProducto = P.CodigoProducto
			WHERE TPD.NumeroAgenciaEmisora = @NumeroAgencia
			AND TPD.NumeroTransferenciaProducto = @NumeroTransferenciaProducto
			AND FechaHoraEnvioRecepcion = @FechaEnvio
			AND TPDE.CantidadEnvio > ISNULL(TPDR.CantidadRecepcionada,0)
		END		
	END	
END
GO				

--SELECT * FROM TransferenciasProductosDetalleRecepcion
--where CodigoTipoEnvioRecepcion = 'E'

--EXEC ListarTransferenciaProductosEnviadosPorFecha 3,1,'20100721 07:45:25.727'
--EXEC ListarTransferenciaProductosEnviadosPorFecha 3,1,null

IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'ListarTransferenciasProductosDetalleGastos') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DROP PROCEDURE ListarTransferenciasProductosDetalleGastos 
	END
GO	
CREATE PROCEDURE ListarTransferenciasProductosDetalleGastos
	@NumeroAgenciaEmisora			INT,
	@NumeroTransferenciaProducto	INT,
	@CodigoTipoEnvioRecepcion		CHAR(1),
	@ListadoProductos				VARCHAR(4000)	
AS
BEGIN
	DECLARE @NumeroAgenciaTexto			VARCHAR(10) = CAST(@NumeroAgenciaEmisora AS VARCHAR(10)),
			@NumeroCompraProductoTexto	VARCHAR(2000) = CAST(@NumeroTransferenciaProducto AS VARCHAR(2000))
			
	IF (@CodigoTipoEnvioRecepcion = 'R')			
	BEGIN
		SET @NumeroAgenciaEmisora = dbo.ObtenerNumeroAgenciaEmisoraDeTransferencias(@NumeroTransferenciaProducto, @NumeroAgenciaEmisora)
		IF(@ListadoProductos IS NULL OR @ListadoProductos = '' OR LEN(@ListadoProductos) = 0)
		BEGIN --U'->UEPS, 'P'->PEPS, 'O'->Ponderado, 'B'-> Precio mas Bajo, 'A'->Precio mas alto	
			SELECT P.CodigoProducto, P.NombreProducto, TPD.PrecioUnitarioTransferencia + TPD.MontoAdicionalPorGastos AS PrecioUnitarioTransferencia, TPD.CantidadTransferencia , CASE(P.CodigoTipoCalculoInventario) WHEN 'U' THEN 'UEPS' WHEN 'P' THEN 'PEPS' WHEN 'O' THEN 'PONDERADO' WHEN 'B' THEN 'PRECIO MAS BAJO' WHEN 'A' THEN 'PRECIO MAS ALTO' WHEN 'T' THEN 'ULTIMO PRECIO' END AS TipoCalculoInventario, CodigoTipoCalculoInventario
			FROM PRODUCTOS P INNER JOIN TransferenciasProductosDetalle TPD
			ON P.CodigoProducto = TPD.CodigoProducto
			WHERE TPD.NumeroAgenciaEmisora = @NumeroAgenciaEmisora AND TPD.NumeroTransferenciaProducto = @NumeroTransferenciaProducto
		END
		ELSE
		BEGIN		
			EXEC('SELECT P.CodigoProducto, P.NombreProducto, TPD.PrecioUnitarioTransferencia + TPD.MontoAdicionalPorGastos AS PrecioUnitarioTransferencia, TPD.CantidadTransferencia, CASE(P.CodigoTipoCalculoInventario) WHEN ''U'' THEN ''UEPS'' WHEN ''P'' THEN ''PEPS'' WHEN ''O'' THEN ''PONDERADO'' WHEN ''B'' THEN ''PRECIO MAS BAJO'' WHEN ''A'' THEN ''PRECIO MAS ALTO'' WHEN ''T'' THEN ''ULTIMO PRECIO'' END AS TipoCalculoInventario, CodigoTipoCalculoInventario
			FROM PRODUCTOS P INNER JOIN TransferenciasProductosDetalle TPD
			ON P.CodigoProducto = TPD.CodigoProducto
			WHERE TPD.NumeroAgenciaEmisora = '+ @NumeroAgenciaTexto +' AND TPD.NumeroTransferenciaProducto = '+ @NumeroCompraProductoTexto +'
			AND TPD.CodigoProducto IN (' + @ListadoProductos +')')		
		END
	END
	ELSE
	BEGIN
		IF(@ListadoProductos IS NULL OR @ListadoProductos = '' OR LEN(@ListadoProductos) = 0)
		BEGIN --U'->UEPS, 'P'->PEPS, 'O'->Ponderado, 'B'-> Precio mas Bajo, 'A'->Precio mas alto	
			SELECT P.CodigoProducto, P.NombreProducto, TPD.PrecioUnitarioTransferencia, TPD.CantidadTransferencia , CASE(P.CodigoTipoCalculoInventario) WHEN 'U' THEN 'UEPS' WHEN 'P' THEN 'PEPS' WHEN 'O' THEN 'PONDERADO' WHEN 'B' THEN 'PRECIO MAS BAJO' WHEN 'A' THEN 'PRECIO MAS ALTO' WHEN 'T' THEN 'ULTIMO PRECIO' END AS TipoCalculoInventario, CodigoTipoCalculoInventario
			FROM PRODUCTOS P INNER JOIN TransferenciasProductosDetalle TPD
			ON P.CodigoProducto = TPD.CodigoProducto
			WHERE TPD.NumeroAgenciaEmisora = @NumeroAgenciaEmisora AND TPD.NumeroTransferenciaProducto = @NumeroTransferenciaProducto
		END
		ELSE
		BEGIN		
			EXEC('SELECT P.CodigoProducto, P.NombreProducto, TPD.PrecioUnitarioTransferencia, TPD.CantidadTransferencia, CASE(P.CodigoTipoCalculoInventario) WHEN ''U'' THEN ''UEPS'' WHEN ''P'' THEN ''PEPS'' WHEN ''O'' THEN ''PONDERADO'' WHEN ''B'' THEN ''PRECIO MAS BAJO'' WHEN ''A'' THEN ''PRECIO MAS ALTO'' WHEN ''T'' THEN ''ULTIMO PRECIO'' END AS TipoCalculoInventario, CodigoTipoCalculoInventario
			FROM PRODUCTOS P INNER JOIN TransferenciasProductosDetalle TPD
			ON P.CodigoProducto = TPD.CodigoProducto
			WHERE TPD.NumeroAgenciaEmisora = '+ @NumeroAgenciaTexto +' AND TPD.NumeroTransferenciaProducto = '+ @NumeroCompraProductoTexto +'
			AND TPD.CodigoProducto IN (' + @ListadoProductos +')')		
		END
	END
		
	
END
GO

--exec ListarTransferenciasProductosDetalleGastos 1,5,'E',null
