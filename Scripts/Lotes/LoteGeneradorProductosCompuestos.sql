USE Doblones20
GO

--CREATE FUNCTION [dbo].[SepararTextoEnPalabrasPorCaracter] (@Texto VARCHAR(5000), @Caracter char(1))
--RETURNS @PalabrasSeparadas TABLE
--   (
--	IdPalabraSeparada	INT IDENTITY(1,1),
--    Palabra	VARCHAR(100)
--   )
--AS
--BEGIN

--	DECLARE @IdElemento INT
--	DECLARE @PosicionInicio INT
--	DECLARE @PosicionFinal INT
--	DECLARE @Palabra CHAR(100)
	
--	SET @PosicionInicio = 1
--	SET @PosicionFinal = 1

--	WHILE (@PosicionFinal > 0)
--	BEGIN
--		SET @PosicionFinal = CHARINDEX(@Caracter, @Texto, @PosicionInicio)
--		IF (@PosicionFinal > 0)
--		BEGIN
--			SET @Palabra = SUBSTRING(@Texto, @PosicionInicio, @PosicionFinal - @PosicionInicio)
--			SET @PosicionInicio = @PosicionFinal + 1
--		END
--		ELSE
--		BEGIN
--			SET @Palabra = SUBSTRING(@Texto, @PosicionInicio, LEN(@Texto))
--		END
--		IF( LTRIM(RTRIM(@Palabra)) <> '' ) 
--			INSERT INTO @PalabrasSeparadas VALUES (RTRIM(LTRIM(@Palabra))) 	
--	END
--	RETURN
--END
--GO

--INSERT INTO ProductosTipos (CodigoTipoProductoPadre, NombreTipoProducto, NombreCortoTipoProducto, DescripcionTipoProducto, Nivel)
--VALUES (68, 'OTROS TRIPLES','OTROS TRIPLES','OTROS TRIPLES')
--INSERT INTO ProductosTipos (CodigoTipoProductoPadre, NombreTipoProducto, NombreCortoTipoProducto, DescripcionTipoProducto, Nivel)
--VALUES (67, 'OTROS DOBLES','OTROS DOBLES','OTROS DOBLES')
--INSERT INTO ProductosTipos (CodigoTipoProductoPadre, NombreTipoProducto, NombreCortoTipoProducto, DescripcionTipoProducto, Nivel)
--VALUES (66, 'OTROS SIMPLES','OTROS SIMPLES','OTROS SIMPLES')


DECLARE @TProductos TABLE 
(
CodigoProducto				CHAR(15) unique,
CodigoProductoFabricante	CHAR(30),
NombreProducto				VARCHAR(250),
NombreProducto1				VARCHAR(250),	
NombreProducto2				VARCHAR(250),	
CodigoMarcaProducto			INT,
CodigoTipoProducto			INT,
CodigoUnidad				INT,
CodigoTipoCalculoInventario	CHAR(1), --U'->UEPS, 'P'->PEPS, 'O'->Ponderado, 'B'-> Precio mas Bajo, 'A'->Precio mas alto, 'T'-> Ultimo Precio
LlenarCodigoPE				BIT,
ProductoTangible			BIT,
ProductoSimple				BIT,
CalcularPrecioVenta			BIT,
RendimientoDeseado1			DECIMAL(10, 2),
RendimientoDeseado2			DECIMAL(10, 2),
RendimientoDeseado3			DECIMAL(10, 2),
Codigo1						CHAR(15),
Codigo2						CHAR(15)
)

DECLARE @TProductosCompuestos TABLE 
(
CodigoProducto					CHAR(15),
CodigoProductoComponente		CHAR(15),
NumeroComponente				INT,
Cantidad						INT
)




DECLARE @CodigoProducto					CHAR(15),
		@CodigoProductoFabricante		CHAR(30),
		@NombreProducto					VARCHAR(250),
		@NombreProductoAux				VARCHAR(250),
		@NombreProducto1				VARCHAR(250),
		@NombreProducto2				VARCHAR(250),
		@CodigoMarcaProducto			INT = 2,
		@CodigoTipoProducto				INT = 69,
		@CodigoUnidad					INT = 2,
		@CodigoTipoCalculoInventario	CHAR(1) = 'O',
		@LlenarCodigoPE					BIT = 0,
		@ProductoTangible				BIT = 1,
		@ProductoSimple					BIT = 0,
		@CalcularPrecioVenta			BIT = 0,
		@RendimientoDeseado1			DECIMAL(10, 2) = 0,
		@RendimientoDeseado2			DECIMAL(10, 2) = 0,
		@RendimientoDeseado3			DECIMAL(10, 2) = 0,
		@Contador1						INT,
		@Contador2						INT,
		@CantidadEspacios				DECIMAL(4,2),
		@Color							VARCHAR(50),
		@NombreModuloArregaldo			VARCHAR(50),
		@TapaBastidorDonnaBlanco		CHAR(15),
		@TapaBastidorDonnaMarfil		CHAR(15),
		@TapaBastidorDonnaAux			CHAR(15),
		@TornillosEnsamblado			CHAR(15),
		@TapaCiegaBlanco				CHAR(15),
		@TapaCiegaMarfil				CHAR(15),
		@TapaCiegaNegro					CHAR(15),
		@Bastidor						CHAR(15),
		@MarcoJonicaBlanco				CHAR(15),
		@MarcoJonicaGrafito				CHAR(15),--negro
		@MarcoJonicaMarfil				CHAR(15),
		@CodigoProductoModulo			CHAR(15),
		@CodigoProductoTapa				CHAR(15),
		@LineaTapa						VARCHAR(50),
		@ColorTapa						VARCHAR(50),
		@ColorAux						VARCHAR(50),
		@CodigoTapaCiegaAux				CHAR(15),
		@CodigoTipoProductoSimple		INT,
		@CodigoTipoProductoDoble		INT,
		@CodigoTipoProductoTriple		INT

SET @TapaBastidorDonnaBlanco = '010-TAP-000001'
SET @TapaBastidorDonnaMarfil = '010-TAP-000002'
SET @TornillosEnsamblado = '010-TOR-000001'
SET @TapaCiegaBlanco	= '010-MOD-000048'
SET @TapaCiegaMarfil	= '010-MOD-000049'
SET @TapaCiegaNegro		= '010-MOD-000052'
SET @Bastidor			= '012-BAS-000001' 
SET @MarcoJonicaBlanco	= '010-MAR-000001'
SET @MarcoJonicaGrafito	= '010-MAR-000002'
SET @MarcoJonicaMarfil	= '010-MAR-000003'
 
 
SET @Contador1 = 0
SET @Contador2 = 0
--DECLARE CursorModulos CURSOR FAST_FORWARD
DECLARE CursorModulos CURSOR
FOR
-- Realizamos la consulta que queremos guardar en la variable
--SELECT P.CodigoProducto, LTRIM(REPLACE(REPLACE(P.NombreProducto,'MODULO',''),'-','')) AS NombreProducto, 		
SELECT P.CodigoProducto, P.NombreProducto, 
		--P.CodigoProductoFabricante, 
		 CASE WHEN P.NombreProducto like '%1/2 TECLON%' THEN 1.5
			  WHEN P.NombreProducto like '%[^1/2] TECLON%' THEN 3 
			  WHEN P.NombreProducto like '%SCHUCO%' THEN 2 ELSE 1 END AS CantidadEspacios,
		 CASE WHEN P.NombreProducto like '%BLANCO%' THEN 'BLANCO'
			  WHEN P.NombreProducto like '%MARFIL%' THEN 'MARFIL'
			  WHEN P.NombreProducto like '%NEGRO%' THEN 'NEGRO'
			  ELSE 'BLANCO' END AS Color,
			  LTRIM(RTRIM(REPLACE(REPLACE(REPLACE(REPLACE( REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(P.NombreProducto,'BLANCO',''),'MARFIL', '') ,'NEGRO', ''), 'MODULO',''),'-',''),'TECLON',''),'1/2',''),'SENCILLO',''),'INTERRUP.','INTERRUPTOR') )) AS NombreModuloArregaldo,
			  CASE 			  
				  WHEN P.CodigoProducto like '010-MOD-00000[123]' THEN 69 
				  WHEN P.CodigoProducto IN ('010-MOD-000016', '010-MOD-000022', '010-MOD-000019') THEN 70
				  WHEN P.CodigoProducto like '010-MOD-00000[789]' THEN 71
				  WHEN P.CodigoProducto like '010-MOD-00002[468]' THEN 72				   				  
				  WHEN P.CodigoProducto IN ('010-MOD-000037', '010-MOD-000015', '010-MOD-000038') THEN 73
				  WHEN P.CodigoProducto IN ('010-MOD-000039', '010-MOD-000040', '010-MOD-000041') THEN 74
				  WHEN P.CodigoProducto like '010-MOD-00003[56]' THEN 75				   				  
				  WHEN P.CodigoProducto like '010-VAR-00000[345]' THEN 76
				  WHEN P.CodigoProducto like '010-VAR-00004[234]' THEN 77
				  WHEN P.CodigoProducto like '010-VAR-00004[567]' THEN 78
				  WHEN P.CodigoProducto IN ('010-MOD-000034 ') THEN 79
				  WHEN P.CodigoProducto IN ('010-SEN-000002 ') THEN 96
				  ELSE 105 
			  END AS CodigoTipoProductoSimple,
			  CASE  
				WHEN P.CodigoProducto like '010-MOD-00000[123]' THEN 80
				WHEN P.CodigoProducto IN ('010-MOD-000014', '010-MOD-000021', '010-MOD-000018') THEN 81
				WHEN P.CodigoProducto like '010-MOD-00000[789]' THEN 82
				WHEN P.CodigoProducto IN ('010-MOD-000023', '010-MOD-000025', '010-MOD-000027') THEN 83
				WHEN P.CodigoProducto IN ('010-MOD-000037', '010-MOD-000015', '010-MOD-000038') THEN 84
				  WHEN P.CodigoProducto IN ('010-MOD-000039', '010-MOD-000040', '010-MOD-000041') THEN 85
				ELSE 104 
			  END AS CodigoTipoProductoDoble,
			  CASE  
				WHEN P.CodigoProducto like '010-MOD-00000[123]' THEN 86 
				WHEN P.CodigoProducto IN ('010-MOD-000037', '010-MOD-000015', '010-MOD-000038') THEN 87				
				ELSE 100 
			  END AS CodigoTipoProductoTriple
		 
		--LEFT(P.NombreProducto, LEN(P.NombreProducto) - CHARINDEX(' ', REVERSE(P.NombreProducto))) as otro,
		--PT.NombreTipoProducto			
FROM Productos P
--INNER JOIN dbo.ProductosTipos PT
--ON PT.CodigoTipoProducto = P.CodigoTipoProducto
WHERE P.CodigoProducto NOT IN ('010-MAR-000001', '010-MAR-000002', '010-MAR-000003', '010-TOR-000001 ','010-MOD-000048', '010-MOD-000049', '010-MOD-000052',
'010-TAP-000001', '010-TAP-000002', '011-TAP-000001', '011-TAP-000002', '011-TAP-000003', '011-TAP-000004', '011-TAP-000005', '011-TAP-000006', '011-TAP-000007', '011-TAP-000008', '011-TAP-000009', '011-TAP-000010', '011-TAP-000011', '011-TAP-000012', '011-TAP-000013', '011-TAP-000014', '011-TAP-000015', '011-TAP-000016', '011-TAP-000017', '011-TAP-000018', '011-TAP-000019', '011-TAP-000020', '011-TAP-000021', '011-TAP-000022', '011-TAP-000023', '011-TAP-000024', '011-TAP-000025', '011-TAP-000026', '011-TAP-000027', '011-TAP-000028', '011-TAP-000029', '011-TAP-000030', '011-TAP-000031', '011-TAP-000032', '011-TAP-000033', '011-TAP-000034', '011-TAP-000035', '011-TAP-000036', '011-TAP-000037', '011-TAP-000038', '011-TAP-000039', '011-TAP-000040', '011-TAP-000041', '011-TAP-000042', '011-TAP-000043', '011-TAP-000044', '011-TAP-000045', '011-TAP-000046',
'012-BAS-000001 ','012-CUB-000001 ' )
and P.ProductoSimple = 1
and P.CodigoTipoProducto = 10
ORDER BY  CantidadEspacios,  NombreModuloArregaldo, Color
--With(NoLock)


-- Abrimos el cursor
OPEN CursorModulos

FETCH NEXT FROM CursorModulos INTO 
@CodigoProductoModulo, @NombreProducto, @CantidadEspacios, @Color, @NombreModuloArregaldo, @CodigoTipoProductoSimple, @CodigoTipoProductoDoble, @CodigoTipoProductoTriple

WHILE @@FETCH_STATUS = 0
BEGIN

-- Hacemos un print para ver que la variable es correcta (Solo es a nivel de comentario, para probar que funciona, cuando funcione quitamos esta linea del print @Variable

	SET @Contador1 = @Contador1 + 1
	
	SET @CodigoTapaCiegaAux = CASE @Color WHEN 'BLANCO' THEN @TapaCiegaBlanco 
		WHEN 'MARFIL' THEN @TapaCiegaMarfil ELSE @TapaCiegaNegro END
	
	SET @NombreProducto  = ''
	
	SELECT @NombreProducto = COALESCE(@NombreProducto, '') + CASE WHEN LEN(Palabra)>2 THEN LEFT(Palabra,3) ELSE '' END
	FROM dbo.SepararTextoEnPalabrasPorCaracter(@NombreModuloArregaldo,' ')
	
	--PRINT('NOMBRE CORTADO ' + @NombreProducto)
	
	--creamos un cursor para recorrer las tapas plcas en su gama de colores en las diferentes lineas
	--DECLARE CursorTapasLineasColores CURSOR FAST_FORWARD
	DECLARE CursorTapasLineasColores CURSOR
	FOR
	SELECT CodigoProducto, 
			CASE WHEN NombreProducto LIKE '%CIVIL%' THEN 'CIVIL'
			WHEN NombreProducto LIKE '%JONICA%' THEN 'JONICA'		
			ELSE 'ZEN' END AS Linea,
			rtrim(ltrim(REPLACE(REPLACE(REPLACE(REPLACE(NombreProducto,'TAPA-3 MODULOS ',''), 'ZEN',''),'JONICA',''),'CIVIL',''))) AS NombreColor
	FROM Productos
	WHERE CodigoProducto in ('011-TAP-000001', '011-TAP-000002', '011-TAP-000003', '011-TAP-000004', '011-TAP-000005', '011-TAP-000006', '011-TAP-000007', '011-TAP-000008', '011-TAP-000009', '011-TAP-000010', '011-TAP-000011', '011-TAP-000012', '011-TAP-000013', '011-TAP-000014', '011-TAP-000015', '011-TAP-000016', '011-TAP-000017', '011-TAP-000018', '011-TAP-000019', '011-TAP-000020', '011-TAP-000021', '011-TAP-000022', '011-TAP-000023', '011-TAP-000024', '011-TAP-000025', '011-TAP-000026', '011-TAP-000027', '011-TAP-000028', '011-TAP-000029', '011-TAP-000030', '011-TAP-000031', '011-TAP-000032', '011-TAP-000033', '011-TAP-000034', '011-TAP-000035', '011-TAP-000036', '011-TAP-000037', '011-TAP-000038', '011-TAP-000039', '011-TAP-000040', '011-TAP-000041', '011-TAP-000042', '011-TAP-000043', '011-TAP-000044', '011-TAP-000045', '011-TAP-000046')
	ORDER BY 2, 3
	--WITH(NOLOCK)
	
	OPEN CursorTapasLineasColores
	FETCH NEXT FROM CursorTapasLineasColores INTO 
	@CodigoProductoTapa, @LineaTapa, @ColorTapa
	
	--CodigosTipos Productos
	--65 -> Compuestos
	--66 -> Simples
	--67 -> Dobles
	--68 -> Triples
	SET @Contador2 = 0
	
	WHILE @@FETCH_STATUS = 0
	BEGIN	

		SET @Contador2 = @Contador2 + 1

		
		--PRINT ('Cursor 1 : ' + @CodigoProductoModulo + ', ' + @NombreProducto + ', ' + cast(@CantidadEspacios as char(2)) + ', ' + @Color + ', ' + @NombreModuloArregaldo)
		--PRINT ('Cursor 2 : ' + @CodigoProductoTapa + ', ' + @LineaTapa + ', ' + @ColorTapa)
		SET @ColorAux = ''
		
		SELECT @ColorAux = COALESCE(@ColorAux, '') + CASE WHEN LEN(Palabra)>2 THEN SUBSTRING(Palabra,1,3) ELSE '' END
		FROM dbo.SepararTextoEnPalabrasPorCaracter(@ColorTapa,' ')
		
		
		
		
		
		
		--MODULOS SIMPLES [pueden haber combinaciones, de 1, 2 y 3]
		IF (@CantidadEspacios = 1)
		BEGIN
		
			--PARA LOS SIMPLES
			--GENERAMOS LOS CODIGOS PARA PRODUCTOS SIMPLES
			IF (@LineaTapa = 'JONICA') 
			BEGIN
				--MARCO BLANCO
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'SIM' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				--SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' ' + @Color + ' SIMPLE TAPA ' + @ColorTapa + ' MARCO BLANCO ' + @LineaTapa
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' SIMPLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO BLANCO'
				--PLACA INTERRUPTOR SIMPLE BLANCO JONICA(INTERRUPTOR BLANCO)
				--PLACA INTERRUPTOR SIMPLE BLANCO JONICA(INTERRUPTOR MARFIL)
				--PLACA INTERRUPTOR SIMPLE BLANCO JONICA(INTERRUPTOR NEGRO)
				SET @NombreProducto1 = 'MODULO ' + @Color
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoSimple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoTapaCiegaAux, 3, 2 UNION ALL
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaBlanco, 6, 1
				
				
				--MARCO NEGRO
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
					
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'SIM' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				--SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' ' + @Color + ' SIMPLE TAPA ' + @ColorTapa + ' MARCO BLANCO ' + @LineaTapa
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' SIMPLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO NEGRO'
				--PLACA INTERRUPTOR SIMPLE BLANCO JONICA(INTERRUPTOR BLANCO)
				--PLACA INTERRUPTOR SIMPLE BLANCO JONICA(INTERRUPTOR MARFIL)
				--PLACA INTERRUPTOR SIMPLE BLANCO JONICA(INTERRUPTOR NEGRO)
				SET @NombreProducto1 = 'MODULO ' + @Color
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoSimple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoTapaCiegaAux, 3, 2 UNION ALL
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaGrafito, 6, 1
				
				
				--MARCO MARFIL
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
					
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'SIM' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				--SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' ' + @Color + ' SIMPLE TAPA ' + @ColorTapa + ' MARCO BLANCO ' + @LineaTapa
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' SIMPLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO MARFIL'
				--PLACA INTERRUPTOR SIMPLE BLANCO JONICA(INTERRUPTOR BLANCO)
				--PLACA INTERRUPTOR SIMPLE BLANCO JONICA(INTERRUPTOR MARFIL)
				--PLACA INTERRUPTOR SIMPLE BLANCO JONICA(INTERRUPTOR NEGRO)
				SET @NombreProducto1 = 'MODULO ' + @Color
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoSimple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoTapaCiegaAux, 3, 2 UNION ALL
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaMarfil, 6, 1
			END
			ELSE
			BEGIN
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'SIM' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' SIMPLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color
				--PLACA INTERRUPTOR SIMPLE BLANCO JONICA(INTERRUPTOR BLANCO)
				--PLACA INTERRUPTOR SIMPLE BLANCO JONICA(INTERRUPTOR MARFIL)
				--PLACA INTERRUPTOR SIMPLE BLANCO JONICA(INTERRUPTOR NEGRO)
				SET @NombreProducto1 = 'MODULO ' + @Color
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoSimple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoTapaCiegaAux, 3, 2 UNION ALL
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1
			END
			
			
			
			
			
			--PARA LOS DOBLES
			--GENERAMOS LOS CODIGOS PARA PRODUCTOS SIMPLES
			IF(@LineaTapa = 'JONICA')
			BEGIN
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'DOB' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' DOBLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO BLANCO '
							
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoDoble, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 2 UNION ALL
				SELECT @CodigoProducto, @CodigoTapaCiegaAux, 3, 1 UNION ALL
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaBlanco, 6, 1
				
				--@MarcoJonicaGrafito
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'DOB' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' DOBLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO NEGRO'
							
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoDoble, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 2 UNION ALL
				SELECT @CodigoProducto, @CodigoTapaCiegaAux, 3, 1 UNION ALL
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaGrafito, 6, 1
				
				
				--@MarcoJonicaMarfil
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'DOB' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' DOBLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO MARFIL'
							
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoDoble, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 2 UNION ALL
				SELECT @CodigoProducto, @CodigoTapaCiegaAux, 3, 1 UNION ALL
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaMarfil, 6, 1
			END
			ELSE
			BEGIN
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'DOB' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' DOBLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color
				
				
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoDoble, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 2 UNION ALL
				SELECT @CodigoProducto, @CodigoTapaCiegaAux, 3, 1 UNION ALL
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1
			END
			
			
			--PARA LOS TRIPLES
			--GENERAMOS LOS CODIGOS PARA PRODUCTOS SIMPLES
			IF(@LineaTapa = 'JONICA')
			BEGIN
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'TRI' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)			
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' TRIPLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO BLANCO'
				
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoTriple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 3 UNION ALL			
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaBlanco, 6, 1
				
				
				--MARCO NEGRO
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'TRI' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)			
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' TRIPLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO NEGRO'
				
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoTriple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 3 UNION ALL			
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaGrafito, 6, 1
				
				
				--MARCO MARFIL
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'TRI' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)			
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' TRIPLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO MARFIL'
				
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoTriple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 3 UNION ALL			
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaMarfil, 6, 1
			
			END
			ELSE
			BEGIN
				
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'TRI' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)			
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' TRIPLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color
				
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoTriple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 3 UNION ALL			
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1
				
			END
			
		END
		
		--se debe crear un productos compuesto por 2 modulos 1/2Teclón si o sí
		--MODULOS TECLÓN 1/2 -> DOBLES
		IF (@CantidadEspacios = 1.5)
		BEGIN
			IF (@LineaTapa = 'JONICA') 
			BEGIN
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'DOB 1/2 TEC ' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				--SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' ' + @Color + ' DOBLE 1/2 TECLON TAPA ' + @ColorTapa + ' MARCO BLANCO' + @LineaTapa
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' DOBLE 1/2 TECLON ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO BLANCO'
						
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoDoble, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 2 UNION ALL
				--SELECT @CodigoProducto, @TapaCiegaBlanco, 3, 2 UNION ALL
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaBlanco, 6, 1
				
				--marco Blanco
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'DOB 1/2 TEC ' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' DOBLE 1/2 TECLON ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO NEGRO'
						
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoDoble, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 2 UNION ALL
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaGrafito, 6, 1
				
				--marco marfil
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'DOB 1/2 TEC ' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' DOBLE 1/2 TECLON ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO MARFIL'
						
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoDoble, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 2 UNION ALL
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaMarfil, 6, 1
			END
			ELSE
			BEGIN
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'DOB 1/2 TEC ' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				--SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' ' + @Color + ' DOBLE 1/2 TECLON TAPA ' + @ColorTapa + ' ' + @LineaTapa
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' DOBLE 1/2 TECLON ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color
						
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoDoble, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 2 UNION ALL
				--SELECT @CodigoProducto, @TapaCiegaBlanco, 3, 2 UNION ALL
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1
			END
			
			
		END
		
		----pueden ser simples
		----MODULOS SCHUCCO
		IF (@CantidadEspacios = 2)
		BEGIN
			IF (@LineaTapa = 'JONICA') 
			BEGIN
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'SIM' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				--SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' ' + @Color + ' SIMPLE TAPA ' + @ColorTapa + ' MARCO BLANCO ' + @LineaTapa
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' SIMPLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO BLANCO'
				
						
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoSimple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 2 UNION ALL			
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaBlanco, 6, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoTapaCiegaAux, 7, 1
				
				
				--MARCO NEGRO
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'SIM' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				--SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' ' + @Color + ' SIMPLE TAPA ' + @ColorTapa + ' MARCO BLANCO ' + @LineaTapa
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' SIMPLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO NEGRO'
				
						
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoSimple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 2 UNION ALL			
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaGrafito, 6, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoTapaCiegaAux, 7, 1
				
				
				--MARCO MARFIL
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'SIM' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				--SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' ' + @Color + ' SIMPLE TAPA ' + @ColorTapa + ' MARCO BLANCO ' + @LineaTapa
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' SIMPLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO MARFIL'
				
						
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoSimple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 2 UNION ALL			
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaMarfil, 6, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoTapaCiegaAux, 7, 1
			END
			ELSE
			BEGIN
				--@CodigoTapaCiegaAux
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'SIM' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				--SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' ' + @Color + ' SIMPLE TAPA ' + @ColorTapa + ' ' + @LineaTapa
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' SIMPLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color
						
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoSimple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 2 UNION ALL			
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoTapaCiegaAux, 6, 1
				
			END
		END
		
		----MODULOS TECLÓN (SOLO SIMPLES)
		IF (@CantidadEspacios = 3)
		BEGIN
			IF(@LineaTapa = 'JONICA')
			BEGIN
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'SIM TEC ' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				--SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' ' + @Color + ' SIMPLE TECLON TAPA ' + @ColorTapa + ' MARCO BLANCO ' + @LineaTapa
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' SIMPLE TECLON ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO BLANCO'
						
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoSimple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 1 UNION ALL			
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaBlanco, 6, 1
				
				--MARCO NEGRO
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'SIM TEC ' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' SIMPLE TECLON ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO NEGRO'
						
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoSimple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 1 UNION ALL			
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaGrafito, 6, 1
				
				--MARCO MARFIL
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'SIM TEC ' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' SIMPLE TECLON ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color + ' MARCO MARFIL'
						
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoSimple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 1 UNION ALL			
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1 UNION ALL
				SELECT @CodigoProducto, @MarcoJonicaMarfil, 6, 1
				
			END
			ELSE
			BEGIN
				SET @CodigoProducto = '066-PLA-'+
					LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
						
				SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'SIM TEC ' + '-' + @ColorAux + '-' + LEFT(@LineaTapa,1)
				--SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' ' + @Color + ' SIMPLE TECLON TAPA ' + @ColorTapa + ' ' + @LineaTapa
				SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' SIMPLE TECLON ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color
				INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
				VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoSimple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
				
				INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
				SELECT @CodigoProducto, @CodigoProductoTapa, 1, 1 UNION ALL
				SELECT @CodigoProducto, @CodigoProductoModulo, 2, 1 UNION ALL			
				SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2 UNION ALL
				SELECT @CodigoProducto, @Bastidor, 5, 1
			END
		END
		
		
		
		FETCH NEXT FROM CursorTapasLineasColores INTO 
		@CodigoProductoTapa, @LineaTapa, @ColorTapa
	END

	--Cerramos el cursor
	CLOSE CursorTapasLineasColores

	-- lo sacamos de la memoria
	DEALLOCATE CursorTapasLineasColores

	--PRINT ('Contador 2 ;' + cast(@contador2 as varchar(100)))
	
	----INDIVIDUALMENTE TRABAJAMOS PARA LA LINEA DONNA
	----MODULOS SIMPLES, pueden ser Simple, doble, triple
	SET @LineaTapa = 'DONNA'
	IF (@CantidadEspacios = 1)
	BEGIN
		SET @TapaBastidorDonnaAux = CASE WHEN @Color = 'BLANCO' THEN @TapaBastidorDonnaBlanco 
			WHEN @Color = 'MARFIL' then @TapaBastidorDonnaMarfil else null end
		IF(@TapaBastidorDonnaAux is not null)
		BEGIN			
			--SIMPLES
			SET @CodigoProducto = '066-PLA-'+
				LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
					
			SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'SIM' + '-' + @ColorAux + '-DONNA'
			--SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' ' + @Color + ' SIMPLE TAPA ' + @ColorTapa + ' DONNA'
			SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' SIMPLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color				
			INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
			VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoSimple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
			
			INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
			SELECT @CodigoProducto, @TapaBastidorDonnaAux, 1, 1 UNION ALL
			SELECT @CodigoProducto, @CodigoProductoModulo, 2, 1 UNION ALL
			SELECT @CodigoProducto, @CodigoTapaCiegaAux, 3, 2 UNION ALL
			SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2
			
			--DOBLES
			SET @CodigoProducto = '066-PLA-'+
				LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
					
			SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'SIM' + '-' + @ColorAux + '-DONNA'
			SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' DOBLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color				
					
			INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
			VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoDoble, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
			
			INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
			SELECT @CodigoProducto, @TapaBastidorDonnaAux, 1, 1 UNION ALL
			SELECT @CodigoProducto, @CodigoProductoModulo, 2, 2 UNION ALL
			SELECT @CodigoProducto, @CodigoTapaCiegaAux, 3, 1 UNION ALL
			SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2
			
			--TRIPLES
			SET @CodigoProducto = '066-PLA-'+
				LTRIM(RTRIM(RIGHT('00000' +CAST(ISNULL((SELECT TOP(1) CAST( RIGHT(RTRIM(CodigoProducto),6) AS INT  )FROM @TProductos order by CodigoProducto DESC),0) + 1 AS VARCHAR(6)),6)))
					
			SET @CodigoProductoFabricante = 'PL' +  LTRIM(RTRIM(@NombreProducto)) + '-' +'SIM' + '-' + @ColorAux + '-DONNA'
			SET @NombreProductoAux = 'PLACA ' + @NombreModuloArregaldo + ' DOBLE ' + @ColorTapa + ' ' + @LineaTapa + ' MODULO ' + @Color				
					
			INSERT INTO @TProductos(CodigoProducto, CodigoProductoFabricante, NombreProducto, NombreProducto1, NombreProducto2, CodigoMarcaProducto, CodigoTipoProducto, CodigoUnidad, CodigoTipoCalculoInventario, LlenarCodigoPE, ProductoTangible, ProductoSimple, CalcularPrecioVenta, RendimientoDeseado1, RendimientoDeseado2, RendimientoDeseado3, Codigo1, Codigo2)
			VALUES (@CodigoProducto, @CodigoProductoFabricante, @NombreProductoAux, @NombreProducto1, @NombreProducto2, @CodigoMarcaProducto, @CodigoTipoProductoTriple, @CodigoUnidad, @CodigoTipoCalculoInventario, @LlenarCodigoPE, @ProductoTangible, @ProductoSimple, @CalcularPrecioVenta, @RendimientoDeseado1, @RendimientoDeseado2, @RendimientoDeseado3, @CodigoProductoModulo, @CodigoProductoTapa)
			
			INSERT INTO @TProductosCompuestos(CodigoProducto, CodigoProductoComponente, NumeroComponente, Cantidad)
			SELECT @CodigoProducto, @TapaBastidorDonnaAux, 1, 1 UNION ALL
			SELECT @CodigoProducto, @CodigoProductoModulo, 2, 3 UNION ALL		
			SELECT @CodigoProducto, @TornillosEnsamblado, 4, 2
			
		
		END
		
		
				
	END
	
	----MODULOS TECLÓN 1/2 si o si doble
	--IF (@CantidadEspacios = 1.5)
	--BEGIN
	--	PRINT( @NombreProducto + ' 1.5 TECLON  DONNA')
	--END
	
	----MODULOS SCHUCCO simple
	--IF (@CantidadEspacios = 2)
	--BEGIN
	--	PRINT( @NombreProducto + ' SIMPLE SCHUCO  DONNA')
	--END
	
	----MODULOS TECLÓN simple
	--IF (@CantidadEspacios = 3)
	--BEGIN
	--	PRINT( @NombreProducto + ' TRIPLE  DONNA')
	--END
	
	
--Accedemos al siguiente registro del cursor
FETCH NEXT FROM CursorModulos INTO 
@CodigoProductoModulo, @NombreProducto, @CantidadEspacios, @Color, @NombreModuloArregaldo, @CodigoTipoProductoSimple, @CodigoTipoProductoDoble, @CodigoTipoProductoTriple

END

SELECT	P.CodigoProducto,P.CodigoProductoFabricante, P.NombreProducto, 
		p2.NombreProducto as NombreProductoComponente,PC.CodigoProductoComponente, PC.Cantidad
FROM @TProductos P
INNER JOIN @TProductosCompuestos PC
ON P.CodigoProducto = PC.CodigoProducto
INNER JOIN Productos P2
ON P2.CodigoProducto = PC.CodigoProductoComponente


--SELECT P.Codigo1, P.Codigo2, TA.CantidadTapas, P.CodigoProducto,P.CodigoProductoFabricante, P.NombreProducto
--FROM @TProductos P
--INNER JOIN
--(
	--SELECT Codigo1, COUNT(Codigo1) as CantidadTapas
	--FROM @TProductos
	--GROUP BY Codigo1
--)TA
--ON TA.Codigo1 = P.Codigo1



--SELECT P.CodigoProducto, P.NombreProducto, 
--		CASE WHEN P.NombreProducto like '%1/2 TECLON%' THEN 1.5
--			  WHEN P.NombreProducto like '%[^1/2] TECLON%' THEN 3 
--			  WHEN P.NombreProducto like '%SCHUCO%' THEN 2 ELSE 1 END AS CantidadEspacios,
--			 TA.Codigo1, TA.CantidadTapas
--FROM Productos P
--LEFT JOIN
--(
--	SELECT Codigo1, COUNT(Codigo1) as CantidadTapas
--	FROM @TProductos
--	GROUP BY Codigo1
--)TA
--ON P.CodigoProducto = TA.Codigo1
--WHERE P.CodigoProducto NOT IN ('010-MAR-000001', '010-MAR-000002', '010-MAR-000003', '010-TOR-000001 ','010-MOD-000048', '010-MOD-000049', '010-MOD-000052',
--'010-TAP-000001', '010-TAP-000002', '011-TAP-000001', '011-TAP-000002', '011-TAP-000003', '011-TAP-000004', '011-TAP-000005', '011-TAP-000006', '011-TAP-000007', '011-TAP-000008', '011-TAP-000009', '011-TAP-000010', '011-TAP-000011', '011-TAP-000012', '011-TAP-000013', '011-TAP-000014', '011-TAP-000015', '011-TAP-000016', '011-TAP-000017', '011-TAP-000018', '011-TAP-000019', '011-TAP-000020', '011-TAP-000021', '011-TAP-000022', '011-TAP-000023', '011-TAP-000024', '011-TAP-000025', '011-TAP-000026', '011-TAP-000027', '011-TAP-000028', '011-TAP-000029', '011-TAP-000030', '011-TAP-000031', '011-TAP-000032', '011-TAP-000033', '011-TAP-000034', '011-TAP-000035', '011-TAP-000036', '011-TAP-000037', '011-TAP-000038', '011-TAP-000039', '011-TAP-000040', '011-TAP-000041', '011-TAP-000042', '011-TAP-000043', '011-TAP-000044', '011-TAP-000045', '011-TAP-000046',
--'012-BAS-000001 ','012-CUB-000001 ' )
--and P.ProductoSimple = 1
--and P.CodigoTipoProducto = 10
--ORDER BY CantidadEspacios


--Cerramos el cursor
CLOSE CursorModulos

-- lo sacamos de la memoria
DEALLOCATE CursorModulos


SELECT P.Codigo1, P.Codigo2, P.CodigoProducto,P.CodigoProductoFabricante, P.NombreProducto
INTO #TPrueba
FROM @TProductos P


select DBO.ObtenerNombreProducto(Codigo1), DBO.ObtenerNombreProducto(Codigo2), * 
from #TPrueba
where nombreproducto like '%DONNA%'
ORDER BY NombreProducto

--DROP TABLE #TPrueba
--DROP FUNCTION SepararTextoEnPalabrasPorCaracter
--GO

