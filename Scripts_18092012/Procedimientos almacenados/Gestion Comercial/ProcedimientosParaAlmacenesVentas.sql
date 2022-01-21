USE Doblones20
GO


DROP PROCEDURE ListarVentaProductosDetalleParaAlmacenes 
GO

CREATE PROCEDURE ListarVentaProductosDetalleParaAlmacenes
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT
AS
BEGIN
	--SELECT	VPD.CodigoProducto, dbo.ObtenerNombreProducto(VPD.CodigoProducto) AS NombreProducto, 
	--		VPD.CantidadVenta, VPD.CantidadEntregada, 
	--		VPD.CantidadVenta - VPD.CantidadEntregada  AS CantidadFaltante, 
	--		VPD.PrecioUnitarioVenta, 
	--		dbo.EsProductoEspecifico(@NumeroAgencia, VPD.CodigoProducto) as EsProductoEspecifico, 
	--		IP.CantidadExistencia, CAST( 0 AS BIT) AS VendidoComoAgregado
	--FROM VentasProductos VP 
	--INNER JOIN VentasProductosDetalle VPD 
	--ON VP.NumeroAgencia = VPD.NumeroAgencia AND VPD.NumeroVentaProducto = VP.NumeroVentaProducto
	--INNER JOIN InventariosProductos IP 
	--ON IP.CodigoProducto = VPD.CodigoProducto
	--AND VPD.NumeroAgencia = IP.NumeroAgencia
	----WHERE (VP.CodigoEstadoVenta = 'P' OR VP.CodigoEstadoVenta = 'D' OR VP.CodigoEstadoVenta = 'T' OR VP.CodigoEstadoVenta = 'I') AND VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto
	--WHERE VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto
	--UNION 
	--SELECT VPEA.CodigoProducto, dbo.ObtenerNombreProducto(VPEA.CodigoProducto) AS NombreProducto, COUNT(VPEA.CodigoProducto) AS CantidadVenta, COUNT(VPEA.CodigoProducto) AS CantidadEntregada, COUNT(VPEA.CodigoProducto) AS CantidadFaltante, CAST(AVG(VPEA.PrecioUnitario) AS DECIMAL(10,2)) as PrecioUnitarioVenta,  dbo.EsProductoEspecifico(@NumeroAgencia, VPEA.CodigoProducto) as EsProductoEspecifico, AVG(IP.CantidadExistencia) AS CantidadExistencia, CAST(1 AS BIT) AS VendidoComoAgregado
	--FROM VentasProductos VP INNER JOIN VentasProductosEspecificosAgregados VPEA ON VP.NumeroAgencia = VPEA.NumeroAgencia AND VPEA.NumeroVentaProducto = VP.NumeroVentaProducto
	--INNER JOIN InventariosProductos IP ON IP.CodigoProducto = VPEA.CodigoProducto
	--AND VPEA.NumeroAgencia = IP.NumeroAgencia
	----WHERE (VP.CodigoEstadoVenta = 'P' OR VP.CodigoEstadoVenta = 'D' OR VP.CodigoEstadoVenta = 'T' OR VP.CodigoEstadoVenta = 'I') AND VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto
	--WHERE VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto
	--GROUP BY VPEA.CodigoProducto
	
	
	
	SELECT	VPD.CodigoProducto, 
		dbo.ObtenerNombreProducto(VPD.CodigoProducto) AS NombreProducto,
		VPD.CantidadVenta,
		VPD.CantidadEntregada,
		VPD.CantidadVenta - ISNULL(VPDE.CantidadEntregada,0) AS CantidadFaltante,
		VPD.PrecioUnitarioVenta, 
		IP.EsProductoEspecifico,
		IP.CantidadExistencia, 
		ISNULL(VPDE.CantidadEntregada,0) AS CantidadRealEntregada,
		VPD.TiempoGarantiaVenta
	FROM VentasProductosDetalle VPD
	INNER JOIN InventariosProductos IP
	ON VPD.CodigoProducto = IP.CodigoProducto
	AND VPD.NumeroAgencia = IP.NumeroAgencia
	LEFT JOIN
	(
		SELECT VPE.NumeroAgencia, VPE.NumeroVentaProducto, VPE.CodigoProducto, SUM(VPE.CantidadEntregada) AS CantidadEntregada
		FROM VentasProductosDetalleEntrega VPE	
		WHERE VPE.NumeroAgencia = @NumeroAgencia
		AND VPE.NumeroVentaProducto = @NumeroVentaProducto
		GROUP BY VPE.NumeroAgencia, VPE.NumeroVentaProducto, VPE.CodigoProducto
	) VPDE
	ON VPD.CodigoProducto = VPDE.CodigoProducto
	AND VPD.NumeroAgencia = VPDE.NumeroAgencia
	AND VPD.NumeroVentaProducto = VPDE.NumeroVentaProducto	
	WHERE VPD.NumeroAgencia = @NumeroAgencia
	AND VPD.NumeroVentaProducto = @NumeroVentaProducto
	
	AND ISNULL(VPDE.CantidadEntregada,0) <> VPD.CantidadVenta
END
GO

--EXEC ListarVentaProductosDetalleParaAlmacenes 1,27

--select *
--from VentasProductos

DROP PROCEDURE EstadoVentaFinalizadaParaAlmacenes
GO	


CREATE PROCEDURE EstadoVentaFinalizadaParaAlmacenes
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT,
	@Estado					CHAR(1) OUTPUT  --    'P':Pendiente (Cuando no se han entregado Todos los Productos)
											--	  'E':Especificos (Es necesario Seleccionar los Productos Especificos)
											--    'T':Entregar (Cuando se encuentra concluida y no hay entrega de productos pendientes, se entrega todo y se genera reporte de conformidad)
											--    'C':Combinado (Cuando hay productos Pendientes y hay que llenar especificos)		
AS
BEGIN
	DECLARE @CantidadVendida	INT,
			@CantidadEntregada	INT,
			@CantidadVendidaPE	INT,			
			@ExistenEspecificos	BIT,
			@ExistePendientes	BIT,
			@SoloEntrega		BIT,
			@CantidadPE			INT
			
			SELECT @CantidadVendida = SUM(VPD.CantidadVenta), @CantidadEntregada = SUM(VPD.CantidadEntregada)
			FROM VentasProductos VP 
			INNER JOIN VentasProductosDetalle VPD 
			ON VP.NumeroAgencia = VPD.NumeroAgencia 
			AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
			--WHERE (VP.CodigoEstadoVenta = 'E' OR VP.CodigoEstadoVenta = 'D' OR VP.CodigoEstadoVenta = 'C') AND VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto
			WHERE VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto	
			GROUP BY VPD.NumeroAgencia, VPD.NumeroVentaProducto
			
			--si Existe algun Producto Especifico en la Venta
			IF(EXISTS(  SELECT * 
						FROM VentasProductos VP 
						INNER JOIN VentasProductosDetalle VPD 
						ON VP.NumeroAgencia = VPD.NumeroAgencia AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
						WHERE (VP.CodigoEstadoVenta = 'E' OR VP.CodigoEstadoVenta = 'D' OR VP.CodigoEstadoVenta = 'C') 
						AND VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto 
						AND dbo.EsProductoEspecifico(@NumeroAgencia, VPD.CodigoProducto)=1))
			BEGIN
				SELECT @CantidadPE = COUNT(*)
				FROM VentasProductosEspecificos
				WHERE NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroVentaProducto
				
				SELECT @CantidadVendidaPE = SUM(VPD.CantidadVenta)
				FROM VentasProductos VP 
				INNER JOIN VentasProductosDetalle VPD 
				ON VP.NumeroAgencia = VPD.NumeroAgencia 
				AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
				--WHERE (VP.CodigoEstadoVenta = 'P' OR VP.CodigoEstadoVenta = 'D') AND VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto AND dbo.EsProductoEspecifico(@NumeroAgencia, VPD.CodigoProducto)=1
				WHERE VP.NumeroAgencia = @NumeroAgencia 
				AND VP.NumeroVentaProducto = @NumeroVentaProducto 
				AND dbo.EsProductoEspecifico(@NumeroAgencia, VPD.CodigoProducto)=1
				
				IF(@CantidadPE = @CantidadVendidaPE  AND @CantidadEntregada = @CantidadVendida)
				--Se Entrego los productos y sus registro de PE esta completo
					SET @Estado = 'T'
				IF(@CantidadPE = @CantidadVendidaPE  AND @CantidadEntregada <> @CantidadVendida)
				--Se registro completamente los PE pero su entrega y completación está pendiente, ES UNA ENTREGA POR PARTES, en este caso el usuario aunmenta la cantidad que quiere antregar ahora
					SET @Estado = 'P'
				IF(@CantidadPE <> @CantidadVendidaPE  AND @CantidadEntregada = @CantidadVendida)
				--en este caso se debe proceder a llenar los PE para su entrega inmediata e imprimir recibo de conformidad
					SET @Estado = 'E'
				IF(@CantidadPE <> @CantidadVendidaPE  AND @CantidadEntregada <> @CantidadVendida)
				-- Combinacion de casos, ni se ha registrado en totalidad sus PE y ni su entrega esta completa, ES UNA ENTREGA POR PARTES, la 2da o nsima parte de entrega
					SET @Estado = 'C'
			END
			ELSE
			BEGIN
				IF(@CantidadEntregada <> @CantidadVendida)
					SET @Estado = 'P'
				ELSE
					SET @Estado = 'T'
			END			
END
GO

--DECLARE @estado CHAR(1)
--EXEC EstadoVentaFinalizadaParaAlmacenes 1,63, @estado OUTPUT
--SELECT @estado


DROP PROCEDURE EsPosibleConcluirEntregaDeProductos
GO

CREATE PROCEDURE EsPosibleConcluirEntregaDeProductos
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT,
	@TipoConfirmacion		CHAR(1), -- 'A' -> Antes de la Entrega de Productos Cuando la Transaccion va a pasar a estado 'P'(Pagado) o 'D'(Pendiente), en este caso se debe revisar lo que se entrega
									 -- 'D' -> Despues de la Primera Entrega Parcial de Productos, en este caso se debe revisar la diferencia de lo vendido con lo entregado anteriormente
	@esPosible				BIT OUTPUT
AS
BEGIN
	DECLARE @CantidadVendida	INT,
			@CantidadEntregada	INT,	
			@CantidadPendiente	INT,
			@CantidadExistencia	INT

			
	--SELECT @CantidadVendida = SUM(VPD.CantidadVenta), @CantidadEntregada = SUM(VPD.CantidadEntregada) 
	--FROM VentasProductos VP INNER JOIN VentasProductosDetalle VPD ON VP.NumeroAgencia = VPD.NumeroAgencia AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
	--WHERE (VP.CodigoEstadoVenta = 'P' OR VP.CodigoEstadoVenta = 'D' OR VP.CodigoEstadoVenta = 'T' OR VP.CodigoEstadoVenta = 'I') AND VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto
	--GROUP BY VPD.NumeroAgencia, VPD.NumeroVentaProducto
	
	----SELECT @CodigoEstadoVenta = CodigoEstadoVenta FROM VentasProductos VP WHERE VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto
	
	--SELECT @CantidadExistencia = SUM(CantidadExistencia)
	--FROM InventariosProductos
	--WHERE CodigoProducto in (SELECT CodigoProducto FROM VentasProductosDetalle WHERE NumeroAgencia = @NumeroAgencia and NumeroVentaProducto  = @NumeroVentaProducto)
	
	--SET @CantidadPendiente = @CantidadVendida - @CantidadEntregada	
	--IF(@CantidadPendiente = 0)
	--BEGIN
	--	 IF @CantidadExistencia >= @CantidadEntregada
	--		SET @esPosible = 1
	--	ELSE
	--		SET @esPosible = 0
	--END
	--ELSE
	--BEGIN	
	--	IF(EXISTS( SELECT *
	--			FROM VentasProductos VP INNER JOIN VentasProductosDetalle VPD ON VP.NumeroAgencia = VPD.NumeroAgencia AND VP.NumeroVentaProducto = VPD.NumeroVentaProducto
	--			INNER JOIN InventariosProductos IP ON VPD.CodigoProducto = IP.CodigoProducto
	--			WHERE VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto
	--			AND IP.CantidadExistencia < (VPD.CantidadVenta - VPD.CantidadEntregada) 
	--			--AND VPD.CantidadEntregada <> 0) OR (@CantidadExistencia <@CantidadEntregada))
	--			AND VPD.CantidadEntregada <> 0) OR (@CantidadExistencia <=@CantidadEntregada  and @CantidadVendida > @CantidadExistencia))
	--		SET @esPosible = 0
	--	ELSE		
	--		SET @esPosible = 1	
	--END
	
	IF(@TipoConfirmacion = 'A')
	BEGIN
		IF( EXISTS( SELECT *  
					FROM VentasProductosDetalle VPD 
					INNER JOIN InventariosProductos IP ON 
					VPD.CodigoProducto = IP.CodigoProducto
					AND VPD.NumeroAgencia = IP.NumeroAgencia
					WHERE VPD.NumeroAgencia = @NumeroAgencia AND VPD.NumeroVentaProducto = @NumeroVentaProducto
					AND VPD.NumeroAgencia = IP.NumeroAgencia
					AND VPD.CantidadEntregada > IP.CantidadExistencia
				  )
		 )
			SET @esPosible = 0
		 ELSE
		 	SET @esPosible = 1
	END
	ELSE IF(@TipoConfirmacion = 'D')
	BEGIN
		IF( EXISTS ( SELECT *
					 FROM VentasProductosDetalle VPD 
					 INNER JOIN InventariosProductos IP 
					 ON VPD.CodigoProducto = IP.CodigoProducto
					 AND VPD.NumeroAgencia = IP.NumeroAgencia
					 WHERE VPD.NumeroAgencia = @NumeroAgencia AND VPD.NumeroVentaProducto = @NumeroVentaProducto
					 AND VPD.NumeroAgencia = IP.NumeroAgencia
					 AND (VPD.CantidadVenta - VPD.CantidadEntregada) > IP.CantidadExistencia  
				   )
		  )
			SET @esPosible = 0
		ELSE		
			SET @esPosible = 1	
	END
	
END
GO

--declare @esposible BIT
--exec EsPosibleConcluirEntregaDeProductos 1, 11,'A',@esposible out
--select @esposible



DROP PROCEDURE ActualizarVentaProductosDetalleCantidadRequerida
GO

CREATE PROCEDURE ActualizarVentaProductosDetalleCantidadRequerida
	@NumeroAgencia				INT,
	@NumeroVentaProducto		INT,
	@CodigoProducto				CHAR(15),
	@CantidadNuevaEntregados	INT,
	@FechaHoraEntrega			DATETIME
AS
BEGIN
	DECLARE @CantidadVendida			INT,
			@CantidadEntregada			INT,	
			@CantidadPendiente			INT,	
			@ExistenciaActual			INT,
			@CodigoProductoEspecifico	CHAR(30)
				
			
	BEGIN TRAN
		SELECT @CantidadVendida = VPD.CantidadVenta, @CantidadEntregada = VPD.CantidadEntregada
		FROM VentasProductosDetalle VPD
		WHERE VPD.NumeroAgencia =  @NumeroAgencia AND VPD.NumeroVentaProducto = @NumeroVentaProducto AND VPD.CodigoProducto = @CodigoProducto
		SET @CantidadPendiente = @CantidadVendida - @CantidadEntregada
		
		SELECT @ExistenciaActual = IP.CantidadExistencia
		FROM InventariosProductos IP
		WHERE IP.CodigoProducto = @CodigoProducto
		AND IP.NumeroAgencia = @NumeroAgencia
		
		IF(@CantidadPendiente > 0 AND @CantidadNuevaEntregados > @CantidadEntregada  AND @CantidadNuevaEntregados <= @CantidadVendida  AND(@CantidadNuevaEntregados - @CantidadEntregada) <= @ExistenciaActual)
		BEGIN
			
			--IF(@ExistenciaActual - @CantidadNuevaEntregados - @CantidadEntregada < 0)
			--	ROLLBACK		
			UPDATE VentasProductosDetalle 
			SET CantidadEntregada = @CantidadNuevaEntregados
			WHERE NumeroAgencia =  @NumeroAgencia AND NumeroVentaProducto = @NumeroVentaProducto AND CodigoProducto = @CodigoProducto
			
			UPDATE InventariosProductos
			SET	CantidadExistencia -= @CantidadNuevaEntregados - @CantidadEntregada,
				CantidadRequerida  -= @CantidadNuevaEntregados - @CantidadEntregada
			WHERE CodigoProducto = @CodigoProducto
			AND NumeroAgencia = @NumeroAgencia
			
						
			--Utilizamos esta variable como axuliar ya que ya no la necesitamos
			SET @CantidadPendiente = @CantidadNuevaEntregados - @CantidadEntregada
			
			--eliminamos o actualizamos los las filas	necesarios del historial de entrada y precios de compra
			exec ActualizarEliminarInventarioProductosCantidadesComprasHistorial @NumeroAgencia, @CodigoProducto, @CantidadPendiente 
			
			IF(@CantidadPendiente > 0)
				EXEC InsertarVentaProductoDetalleEntrega @NumeroAgencia, @NumeroVentaProducto, @CodigoProducto, @FechaHoraEntrega, @CantidadPendiente
		END
		
		IF( EXISTS(SELECT * FROM VentasProductosDetalle VP WHERE VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto AND dbo.EsProductoEspecifico(@NumeroAgencia, VP.CodigoProducto) =1))
		BEGIN
			
			--Begin Venta Productos Especificos
			SELECT CodigoProductoEspecifico, CodigoProducto INTO #mytemp3
			FROM VentasProductosEspecificos
			WHERE (NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroVentaProducto and CodigoProducto = @CodigoProducto)
			ORDER BY CodigoProducto
			

			SET ROWCOUNT 1
			SELECT @CodigoProductoEspecifico = CodigoProductoEspecifico, @CodigoProducto = CodigoProducto FROM #mytemp3

			WHILE @@rowcount <> 0
			BEGIN
				UPDATE dbo.InventariosProductosEspecificos
					SET CodigoEstado = 'V'
				WHERE NumeroAgencia = @NumeroAgencia and CodigoProducto = @CodigoProducto AND (CodigoProductoEspecifico = @CodigoProductoEspecifico)
				DELETE #mytemp3 WHERE @CodigoProductoEspecifico = CodigoProductoEspecifico
				SET ROWCOUNT 1
				SELECT @CodigoProductoEspecifico = CodigoProductoEspecifico, @CodigoProducto = CodigoProducto FROM #mytemp3
			END
			SET ROWCOUNT 0
			
			UPDATE dbo.VentasProductosEspecificos
				SET FechaHoraEntrega = @FechaHoraEntrega
			WHERE NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = NumeroVentaProducto AND CodigoProducto = @CodigoProducto AND Entregado = 0
			
			IF EXISTS( SELECT * FROM dbo.sysobjects where id = object_id(N'#mytemp3') AND OBJECTPROPERTY(id, N'IsTable') = 1)
			BEGIN
				DROP TABLE #mytemp3
			END	
			
		END
		
		IF (@@error<> 0) 
		BEGIN
		  ROLLBACK TRAN
		  RAISERROR ('No se puedo realizar la transaccion, Ocurrio un error al momento de Actualizar Inventarios',16,2)
		END
		ELSE
			COMMIT TRAN	
END
GO

--EXEC ActualizarVentaProductosDetalleCantidadRequerida 1, 21, '100', 5 


DROP FUNCTION esNecesarioLlenarProductosEspecificos
GO

CREATE FUNCTION esNecesarioLlenarProductosEspecificos (@NumeroAgencia INT, @NumeroVentaProducto INT)
RETURNS BIT
AS
BEGIN	
	DECLARE @esNecesario			BIT = 0,
			@CantidadTotalEntregada INT = 0,
			@CantidadRegistraPE		INT
	
	SELECT @CantidadTotalEntregada = SUM(VPD.CantidadEntregada)
	FROM VentasProductosDetalle VPD
	WHERE VPD.NumeroAgencia = @NumeroAgencia AND VPD.NumeroVentaProducto = @NumeroVentaProducto AND dbo.EsProductoEspecifico(@NumeroAgencia, VPD.CodigoProducto) = 1
	IF @CantidadTotalEntregada IS NULL SET @CantidadTotalEntregada = 0
	
	SELECT @CantidadRegistraPE = COUNT(*)
	FROM VentasProductosEspecificos VPE
	WHERE VPE.NumeroAgencia = @NumeroAgencia AND VPE.NumeroVentaProducto = @NumeroVentaProducto
	IF @CantidadRegistraPE IS NULL SET @CantidadRegistraPE = 0
	
	IF(@CantidadRegistraPE = 0 AND @CantidadTotalEntregada = 0)
		SET @esNecesario = 0
	ELSE IF(@CantidadRegistraPE < @CantidadTotalEntregada)
		SET @esNecesario = 1
	ELSE
		SET @esNecesario = 0
	
	return @esNecesario
END
GO



DROP PROCEDURE ListarVentaProductosDetalleConEspecificosCompletaParaAlmacenes
GO

CREATE PROCEDURE ListarVentaProductosDetalleConEspecificosCompletaParaAlmacenes
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT
AS
BEGIN
	SELECT VPD.CodigoProducto, dbo.ObtenerNombreProducto(VPD.CodigoProducto) AS NombreProducto, VPD.CantidadVenta, VPD.CantidadEntregada, VPD.CantidadVenta - VPD.CantidadEntregada AS CantidadFaltante, VPE.CodigoProductoEspecifico
	FROM VentasProductos VP INNER JOIN VentasProductosDetalle VPD ON VP.NumeroAgencia = VPD.NumeroAgencia AND VPD.NumeroVentaProducto = VP.NumeroVentaProducto
	LEFT JOIN VentasProductosEspecificos VPE ON VPE.NumeroAgencia = VPD.NumeroAgencia AND VPE.NumeroVentaProducto = VPD.NumeroVentaProducto AND VPE.CodigoProducto = VPD.CodigoProducto
	INNER JOIN InventariosProductos IP ON IP.CodigoProducto = VPD.CodigoProducto
	AND IP.NumeroAgencia = VPD.NumeroAgencia
	--WHERE (VP.CodigoEstadoVenta = 'E' OR VP.CodigoEstadoVenta = 'D') AND VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto	
	WHERE VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto	
	UNION 
	SELECT VPEA.CodigoProducto, dbo.ObtenerNombreProducto(VPEA.CodigoProducto) AS NombreProducto, COUNT(VPEA.CodigoProducto) AS CantidadVenta, COUNT(VPEA.CodigoProducto) AS CantidadEntregada, COUNT(VPEA.CodigoProducto) AS CantidadFaltante, VPEA.CodigoProductoEspecifico
	FROM VentasProductos VP INNER JOIN VentasProductosEspecificosAgregados VPEA ON VP.NumeroAgencia = VPEA.NumeroAgencia AND VPEA.NumeroVentaProducto = VP.NumeroVentaProducto
	INNER JOIN InventariosProductos IP ON IP.CodigoProducto = VPEA.CodigoProducto
	AND IP.NumeroAgencia = VPEA.NumeroAgencia
	--WHERE (VP.CodigoEstadoVenta = 'E' OR VP.CodigoEstadoVenta = 'D') AND VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto
	WHERE VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto	
	GROUP BY VPEA.CodigoProducto, VPEA.CodigoProductoEspecifico
END
GO
--ListarVentaProductosDetalleConEspecificosCompletaParaAlmacenes 1, 24

DROP PROCEDURE ListarVentaProductosDetalleConEspecificosPorPartesParaAlmacenes
GO

CREATE PROCEDURE ListarVentaProductosDetalleConEspecificosPorPartesParaAlmacenes
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT
AS
BEGIN
	SELECT VPD.CodigoProducto, dbo.ObtenerNombreProducto(VPD.CodigoProducto) AS NombreProducto, VPD.CantidadVenta, dbo.ObtenerCantidadEntregadaEnAlmacenesPE(@NumeroAgencia, @NumeroVentaProducto, VPD.CodigoProducto) AS CantidadEntregada,  VPD.CantidadEntregada - dbo.ObtenerCantidadEntregadaEnAlmacenesPE(@NumeroAgencia, @NumeroVentaProducto, VPD.CodigoProducto) AS CantidadEntregadaAnterior, VPD.CantidadVenta - VPD.CantidadEntregada AS CantidadFaltante, VPE.CodigoProductoEspecifico
	FROM VentasProductos VP INNER JOIN VentasProductosDetalle VPD ON VP.NumeroAgencia = VPD.NumeroAgencia AND VPD.NumeroVentaProducto = VP.NumeroVentaProducto
	INNER JOIN VentasProductosEspecificos VPE ON VPE.NumeroAgencia = VPD.NumeroAgencia AND VPE.NumeroVentaProducto = VPD.NumeroVentaProducto AND VPE.CodigoProducto = VPD.CodigoProducto
	INNER JOIN InventariosProductos IP ON IP.CodigoProducto = VPD.CodigoProducto
	AND IP.NumeroAgencia = VPD.NumeroAgencia
	--WHERE (VP.CodigoEstadoVenta = 'P' OR VP.CodigoEstadoVenta = 'D') AND VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto
	WHERE VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto	
	AND VPE.Entregado = 0
	UNION 
	SELECT VPD.CodigoProducto, dbo.ObtenerNombreProducto(VPD.CodigoProducto) AS NombreProducto, VPD.CantidadVenta, VPD.CantidadEntregada ,  VPD.CantidadEntregada AS CantidadEntregadaAnterior, VPD.CantidadVenta - VPD.CantidadEntregada AS CantidadFaltante, null as CodigoProductoEspecifico
	FROM VentasProductos VP INNER JOIN VentasProductosDetalle VPD ON VP.NumeroAgencia = VPD.NumeroAgencia AND VPD.NumeroVentaProducto = VP.NumeroVentaProducto	
	INNER JOIN InventariosProductos IP ON IP.CodigoProducto = VPD.CodigoProducto
	AND IP.NumeroAgencia = VPD.NumeroAgencia
	--WHERE (VP.CodigoEstadoVenta = 'P' OR VP.CodigoEstadoVenta = 'D') AND VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto
	WHERE VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto	
	UNION
	SELECT VPEA.CodigoProducto, dbo.ObtenerNombreProducto(VPEA.CodigoProducto) AS NombreProducto, COUNT(VPEA.CodigoProducto) AS CantidadVenta, COUNT(VPEA.CodigoProducto) AS CantidadEntregada, COUNT(VPEA.CodigoProducto) AS CantidadFaltante, COUNT(VPEA.CodigoProducto) AS CantidadEntregadaAnterior, VPEA.CodigoProductoEspecifico
	FROM VentasProductos VP INNER JOIN VentasProductosEspecificosAgregados VPEA ON VP.NumeroAgencia = VPEA.NumeroAgencia AND VPEA.NumeroVentaProducto = VP.NumeroVentaProducto
	INNER JOIN InventariosProductos IP ON IP.CodigoProducto = VPEA.CodigoProducto
	AND IP.NumeroAgencia = VPEA.NumeroAgencia
	--WHERE (VP.CodigoEstadoVenta = 'P' OR VP.CodigoEstadoVenta = 'D') AND VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto
	WHERE VP.NumeroAgencia = @NumeroAgencia AND VP.NumeroVentaProducto = @NumeroVentaProducto	
	GROUP BY VPEA.CodigoProducto, VPEA.CodigoProductoEspecifico
END
GO

--exec ListarVentaProductosDetalleConEspecificosPorPartesParaAlmacenes  1, 47

DROP PROCEDURE ActualizarCodigoEstadoProductosEspecificos
GO

CREATE PROCEDURE ActualizarCodigoEstadoProductosEspecificos
	@NumeroAgencia				INT,
	@CodigoProducto				CHAR(15),
	@CodigoProductoEspecifico	CHAR(30),
	@EstadoCodigoEspecifico		CHAR(1)
AS
BEGIN
	UPDATE InventariosProductosEspecificos 
	SET CodigoEstado = @EstadoCodigoEspecifico
	WHERE NumeroAgencia = @NumeroAgencia 
	AND CodigoProducto = @CodigoProducto 
	AND CodigoProductoEspecifico = @CodigoProductoEspecifico
END
GO


DROP PROCEDURE ActualizarInventarioProductosEspecficosVendidos
GO

CREATE PROCEDURE ActualizarInventarioProductosEspecficosVendidos
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT
AS
BEGIN
	DECLARE @ListadoCodigosEspecificos	VARCHAR(8000),
			@ConsultaSQL				VARCHAR(100)
	SELECT  @ListadoCodigosEspecificos = COALESCE(@ListadoCodigosEspecificos + ''',''', '') + T.CodigoProductoEspecifico
	FROM VentasProductosEspecificos T
	WHERE T.NumeroAgencia = @NumeroAgencia AND T.NumeroVentaProducto = @NumeroVentaProducto	
	
	print @ListadoCodigosEspecificos		
	
	SET @ConsultaSQL = RTRIM(LTRIM(CAST(@NumeroAgencia AS CHAR(100))))
	--PRINT ('UPDATE InventariosProductosEspecificos	SET CodigoEstado = ''V'' 	WHERE CodigoProductoEspecifico IN (''' + @ListadoCodigosEspecificos + ''')	AND NumeroAgencia = ' + @ConsultaSQL )
	EXEC ('UPDATE InventariosProductosEspecificos	SET CodigoEstado = ''V'' 	WHERE CodigoProductoEspecifico IN (''' + @ListadoCodigosEspecificos + ''')	AND NumeroAgencia = ' + @ConsultaSQL )
END
GO



DROP PROCEDURE ActualizarProductoEspecificoEntregadoEnVentas
GO


CREATE PROCEDURE ActualizarProductoEspecificoEntregadoEnVentas
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT
AS
BEGIN
	UPDATE VentasProductosEspecificos
	SET Entregado = 1
	WHERE NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroVentaProducto
END
GO



DROP PROCEDURE ActualizarCantidadProductosEntregadosVentasInalcanzables
GO

CREATE PROCEDURE ActualizarCantidadProductosEntregadosVentasInalcanzables
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT
AS
BEGIN
	
	UPDATE VentasProductosDetalle 
	SET CantidadEntregada = dbo.ObtenerExistenciaProductoInventario(@NumeroAgencia, CodigoProducto)
	WHERE NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroVentaProducto
	AND CantidadEntregada > dbo.ObtenerExistenciaProductoInventario(@NumeroAgencia, CodigoProducto)
END
GO

--exec ActualizarInventarioProductosEspecficosVendidos 1, 5
select * from inventariosproductos