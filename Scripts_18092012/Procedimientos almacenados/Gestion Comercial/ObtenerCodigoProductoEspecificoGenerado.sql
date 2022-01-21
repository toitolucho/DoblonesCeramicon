USE DOBLONES20
DROP PROCEDURE ObtenerCodigoProductoEspecificoGenerado;
GO

CREATE PROCEDURE ObtenerCodigoProductoEspecificoGenerado 
	@CodigoProducto				CHAR (15),
	@Cantidad_A_Generar			INT,
	@ComodinSeparacion			CHAR(3),
	@TipoGeneracion				CHAR(1), -- I: Inventarios, C: compras Agregados (para el caso q no se registra en inventario
	@ListadoCodigosEspecificos	VARCHAR(8000) OUTPUT
--Maximo de Codigos a Generar 663 OJO OJO OJO!!!
AS
DECLARE 
	@Existe						INTEGER,
	@ExisteTemporalmente		INTEGER,
	@i							INTEGER,
	@ContadorCantidad			INTEGER,
	@CodigoCadena				CHAR(20),
	@CodigoProductoEspecifico	CHAR(20),
	@CodigoAntiguo				CHAR(20)	
BEGIN
	IF EXISTS( SELECT * FROM dbo.sysobjects WHERE id = object_id(N'#mytemp') AND OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		DROP TABLE #mytemp
	END
	ELSE
	BEGIN
		CREATE TABLE #mytemp(CodigoProductoEspecifico CHAR(20))
	END	
	SET @i = 1;
 	SET @ContadorCantidad = 0;
 	
 	PRINT 'CODIGO PRODUCTO: '+@CodigoProducto;
 	WHILE @ContadorCantidad < @Cantidad_A_Generar
 	BEGIN
 		WHILE (@i < 100000000000000000000)
		BEGIN
			SET @CodigoCadena = '';
			IF (@i < 10) 
				SET	@CodigoCadena = '0000000000000000000' + CAST(@i AS CHAR(1));
			ELSE IF ((@i >= 10) AND (@i < 100))
				SET  @CodigoCadena = '000000000000000000' + CAST(@i AS CHAR(2));
			ELSE IF ((@i >= 100) AND (@i < 1000))
				SET   @CodigoCadena = '00000000000000000' + CAST(@i AS CHAR(3));
			ELSE IF ((@i >= 1000) AND (@i < 10000))	 
				SET	   @CodigoCadena = '0000000000000000' + CAST(@i AS CHAR(4));
			ELSE IF ((@i >= 10000) AND (@i < 100000))
				SET     @CodigoCadena = '000000000000000' + CAST(@i AS CHAR(5));
			ELSE IF ((@i >= 100000) AND (@i < 1000000))
				SET      @CodigoCadena = '00000000000000' + CAST(@i AS CHAR(6));
			ELSE IF ((@i >= 1000000) AND (@i < 10000000))
				SET       @CodigoCadena = '0000000000000' + CAST(@i AS CHAR(7));
			ELSE IF ((@i >= 10000000) AND (@i < 100000000))	
				SET        @CodigoCadena = '000000000000' + CAST(@i AS CHAR(8));
			ELSE IF ((@i >= 100000000) AND (@i < 1000000000))
				SET	        @CodigoCadena = '00000000000' + CAST(@i AS CHAR(9));
			ELSE IF ((@i >= 1000000000) AND (@i < 10000000000))
				SET	         @CodigoCadena = '0000000000' + CAST(@i AS CHAR(10));
			ELSE IF ((@i >= 10000000000) AND (@i < 100000000000))
				SET	          @CodigoCadena = '000000000' + CAST(@i AS CHAR(11));
			ELSE IF ((@i >= 100000000000) AND (@i < 1000000000000))
				SET	           @CodigoCadena = '00000000' + CAST(@i AS CHAR(12));
			ELSE IF ((@i >= 1000000000000) AND (@i < 10000000000000))
				SET	            @CodigoCadena = '0000000' + CAST(@i AS CHAR(13));
			ELSE IF ((@i >= 10000000000000) AND (@i < 100000000000000))	
				SET	             @CodigoCadena = '000000' + CAST(@i AS CHAR(14));
			ELSE IF ((@i >= 100000000000000) AND (@i < 1000000000000000))	
				SET	              @CodigoCadena = '00000' + CAST(@i AS CHAR(15));
			ELSE IF ((@i >= 1000000000000000) AND (@i < 10000000000000000))	
				SET	               @CodigoCadena = '0000' + CAST(@i AS CHAR(16));
			ELSE IF ((@i >= 10000000000000000) AND (@i < 100000000000000000))	
				SET	                @CodigoCadena = '000' + CAST(@i AS CHAR(17));
			ELSE IF ((@i >= 100000000000000000) AND (@i < 1000000000000000000))	
				SET	                 @CodigoCadena = '00' + CAST(@i AS CHAR(18));
			ELSE IF ((@i >= 1000000000000000000) AND (@i < 10000000000000000000))	
				SET	                  @CodigoCadena = '0' + CAST(@i AS CHAR(19));
			ELSE 
				SET @CodigoCadena = CAST(@i AS CHAR(20));
			
			SET @CodigoAntiguo = LTRIM(RTRIM(@CodigoProducto))+LTRIM(RTRIM(@ComodinSeparacion))+SUBSTRING(@CodigoCadena,(LEN(LTRIM(RTRIM(@CodigoProducto)))+LEN(LTRIM(RTRIM(@ComodinSeparacion))))+1,20);
			--SELECT @Existe = COUNT(*) 
			--FROM dbo.InventariosProductosEspecificos 
			--WHERE CodigoProducto = @CodigoProducto
			--		AND CodigoProductoEspecifico = @CodigoAntiguo
						
			IF (@TipoGeneracion ='I')
			BEGIN
				SELECT @Existe = COUNT(*) 
				FROM dbo.InventariosProductosEspecificos 
				WHERE CodigoProducto = @CodigoProducto
						AND CodigoProductoEspecifico = @CodigoAntiguo
			END			
			ELSE IF(@TipoGeneracion ='C')
			BEGIN
				SELECT @Existe = COUNT(*) 
				FROM dbo.ComprasProductosEspecificosAgregados
				WHERE CodigoProducto = @CodigoProducto
						AND CodigoProductoEspecifico = @CodigoAntiguo
			END
			
			SELECT @ExisteTemporalmente = COUNT(*)
			FROM #mytemp
			WHERE @CodigoCadena = CodigoProductoEspecifico
			
			print 'EXISTE 2-> : '+cast(@ExisteTemporalmente as char(1))+', EXISTE 1->:'+ cast(@Existe as char(1))+',  i: '+ CAST(@i AS CHAR(2))+ ',  CadenaGenerada '+@CodigoCadena + ',  Codigo Antiguo: '+@CodigoAntiguo;
			
			IF (@Existe <= 0 AND @ExisteTemporalmente<=0) 
			BEGIN
				IF (@i < 10) SET															@CodigoProductoEspecifico = '0000000000000000000' + CAST(@i AS CHAR(1));
				ELSE IF ((@i >= 10) AND (@i < 100)) SET										@CodigoProductoEspecifico = '000000000000000000' + CAST(@i AS CHAR(2));
				ELSE IF ((@i >= 100) AND (@i < 1000)) SET									@CodigoProductoEspecifico = '00000000000000000' + CAST(@i AS CHAR(3));
				ELSE IF ((@i >= 1000) AND (@i < 10000)) SET									@CodigoProductoEspecifico = '0000000000000000' + CAST(@i AS CHAR(4));
				ELSE IF ((@i >= 10000) AND (@i < 100000)) SET								@CodigoProductoEspecifico = '000000000000000' + CAST(@i AS CHAR(5));
				ELSE IF ((@i >= 100000) AND (@i < 1000000)) SET								@CodigoProductoEspecifico = '00000000000000' + CAST(@i AS CHAR(6));
				ELSE IF ((@i >= 1000000) AND (@i < 10000000)) SET							@CodigoProductoEspecifico = '0000000000000' + CAST(@i AS CHAR(7));
				ELSE IF ((@i >= 10000000) AND (@i < 100000000)) SET							@CodigoProductoEspecifico = '000000000000' + CAST(@i AS CHAR(8));
				ELSE IF ((@i >= 100000000) AND (@i < 1000000000)) SET						@CodigoProductoEspecifico = '00000000000' + CAST(@i AS CHAR(9));
				ELSE IF ((@i >= 1000000000) AND (@i < 10000000000)) SET						@CodigoProductoEspecifico = '0000000000' + CAST(@i AS CHAR(10));
				ELSE IF ((@i >= 10000000000) AND (@i < 100000000000)) SET					@CodigoProductoEspecifico = '000000000' + CAST(@i AS CHAR(11));
				ELSE IF ((@i >= 100000000000) AND (@i < 1000000000000)) SET					@CodigoProductoEspecifico = '00000000' + CAST(@i AS CHAR(12));
				ELSE IF ((@i >= 1000000000000) AND (@i < 10000000000000)) SET				@CodigoProductoEspecifico = '0000000' + CAST(@i AS CHAR(13));
				ELSE IF ((@i >= 10000000000000) AND (@i < 100000000000000)) SET				@CodigoProductoEspecifico = '000000' + CAST(@i AS CHAR(14));
				ELSE IF ((@i >= 100000000000000) AND (@i < 1000000000000000)) SET			@CodigoProductoEspecifico = '00000' + CAST(@i AS CHAR(15));
				ELSE IF ((@i >= 1000000000000000) AND (@i < 10000000000000000)) SET			@CodigoProductoEspecifico = '0000' + CAST(@i AS CHAR(16));
				ELSE IF ((@i >= 10000000000000000) AND (@i < 100000000000000000)) SET		@CodigoProductoEspecifico = '000' + CAST(@i AS CHAR(17));
				ELSE IF ((@i >= 100000000000000000) AND (@i < 1000000000000000000)) SET		@CodigoProductoEspecifico = '00' + CAST(@i AS CHAR(18));
				ELSE IF ((@i >= 1000000000000000000) AND (@i < 10000000000000000000)) SET	@CodigoProductoEspecifico = '0' + CAST(@i AS CHAR(19));
				ELSE SET @CodigoProductoEspecifico = CAST(@i AS CHAR(20));
				INSERT INTO #mytemp (CodigoProductoEspecifico) VALUES (@CodigoProductoEspecifico)
				print 'Valor Insertado :'+@CodigoProductoEspecifico
				BREAK;
			END
			SET @i = @i + 1;
		END
		SET @ContadorCantidad = @ContadorCantidad + 1		
 	END
 	SELECT  @ListadoCodigosEspecificos = COALESCE(@ListadoCodigosEspecificos + ', ', '') + T.CodigoProductoEspecifico
		FROM #mytemp T
 	DROP TABLE #mytemp
END 


DECLARE @CODIGO VARCHAR(8000)
EXEC ObtenerCodigoProductoEspecificoGenerado '103',10,'-','I' ,@CODIGO OUTPUT
PRINT @CODIGO
SELECT LEN(@CODIGO), @CODIGO

SELECT LEN('103-0000000000000000')

SELECT LEN('LUIS'), SUBSTRING('LUIS LIZET',6,20), LEN(SUBSTRING('LUIS LIZET',6,20))