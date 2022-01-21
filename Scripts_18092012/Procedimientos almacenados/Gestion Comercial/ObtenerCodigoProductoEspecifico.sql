USE DOBLONES20
DROP PROCEDURE ObtenerCodigoProductoEspecifico;
GO

CREATE PROCEDURE ObtenerCodigoProductoEspecifico 
	@CodigoProducto				CHAR (15),
	@CodigoProductoEspecifico	CHAR(20) OUTPUT
AS
DECLARE 
	@Existe			INTEGER,
	@i				INTEGER,
	@CodigoCadena	CHAR(20)
BEGIN
	SET @i = 1;
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

		SELECT @Existe = COUNT(*) 
		FROM dbo.InventariosProductosEspecificos
		WHERE @CodigoProducto = @CodigoProducto
                AND @CodigoProductoEspecifico = @CodigoCadena


		IF (@Existe <= 0) 
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
			BREAK;
		END
		SET @i = @i + 1;
	END
END 


DECLARE @CODIGO CHAR(20)
EXEC ObtenerCodigoProductoEspecifico '1', @CODIGO OUTPUT
SELECT LEN(@CODIGO), @CODIGO

SELECT LEN('00000000000000')