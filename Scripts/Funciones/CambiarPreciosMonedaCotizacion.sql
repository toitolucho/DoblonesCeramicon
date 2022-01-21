USE DOBLONES20
GO

DROP FUNCTION dbo.Split
GO

CREATE FUNCTION dbo.Split
(
	@RowData NVARCHAR(4000),
	@SplitOn NVARCHAR(5)
)  
RETURNS @RtnValue TABLE 
(
	Id INT IDENTITY(1,1),
	Data NVARCHAR(100)
) 
AS  
BEGIN 
	DECLARE @Cnt INT
	SET @Cnt = 1

	WHILE (CHARINDEX(@SplitOn,@RowData)>0)
	BEGIN
		Insert INTO @RtnValue (data)
		SELECT 
			Data = LTRIM(RTRIM(Substring(@RowData,1,CHARINDEX(@SplitOn,@RowData)-1)))

		SET @RowData = Substring(@RowData,CHARINDEX(@SplitOn,@RowData)+1,len(@RowData))
		SET @Cnt = @Cnt + 1
	END
	
	INSERT INTo @RtnValue (data)
	SELECT Data = LTRIM(RTRIM(@RowData))

	RETURN
END
GO

DROP FUNCTION ObtenerTablaTemporalCotizacionPreciosOtraMoneda
GO 

CREATE FUNCTION ObtenerTablaTemporalCotizacionPreciosOtraMoneda (@ListadoPrecios NVARCHAR(4000), @CaracterSeparador CHAR(1), @NumeroAgencia INT, @IncluirIVA BIT, @FactorCambio DECIMAL(10,2))
RETURNS @PreciosCotizados TABLE
(	
	Precio		DECIMAL(10,2),
	PrecioTotal	DECIMAL(10,2)	
)
WITH EXECUTE AS CALLER
AS
BEGIN

	DECLARE @PorcentajeIVA	DECIMAL(10,2)	
	
	SELECT TOP(1) @PorcentajeIVA = PorcentajeImpuesto FROM PCsConfiguraciones WHERE NumeroAgencia = @NumeroAgencia
	
	IF(@IncluirIVA = 1)
	BEGIN
		INSERT INTO @PreciosCotizados (Precio, PrecioTotal)
		--SELECT CAST(REPLACE(SUBSTRING(Data,0, CHARINDEX('-',DATA)), ',', '.') AS DECIMAL(10,2)) , CAST(REPLACE(SUBSTRING(Data,CHARINDEX('-', DATA) + 1, LEN(DATA)), ',', '.') AS DECIMAL(10,2))
		SELECT CAST(REPLACE(SUBSTRING(Data,0, CHARINDEX('-',DATA)), ',', '.') AS DECIMAL(10,2)) , CAST(REPLACE(SUBSTRING(Data,CHARINDEX('-', DATA) + 1, LEN(DATA)), ',', '.') AS INT)
		FROM dbo.split(@ListadoPrecios, @CaracterSeparador)
		
		UPDATE @PreciosCotizados
			SET Precio = CAST((Precio + Precio * @PorcentajeIVA / 100) AS DECIMAL(10,2)) * @FactorCambio,
				--PrecioTotal = (PrecioTotal + PrecioTotal * @PorcentajeIVA / 100) * @FactorCambio
				PrecioTotal = CAST(CAST((Precio + Precio * @PorcentajeIVA / 100) AS DECIMAL(10,2)) * @FactorCambio AS DECIMAL(10,2)) * PrecioTotal
	END
	ELSE
	BEGIN
		INSERT INTO @PreciosCotizados (Precio, PrecioTotal)
		--SELECT CAST(REPLACE(SUBSTRING(Data,0, CHARINDEX('-',DATA)), ',', '.') AS DECIMAL(10,2)) * @FactorCambio , CAST(REPLACE(SUBSTRING(Data,CHARINDEX('-', DATA) + 1, LEN(DATA)), ',', '.') AS DECIMAL(10,2)) * @FactorCambio
		SELECT CAST(REPLACE(SUBSTRING(Data,0, CHARINDEX('-',DATA)), ',', '.') AS DECIMAL(10,2)) * @FactorCambio , CAST(CAST(REPLACE(SUBSTRING(Data,0, CHARINDEX('-',DATA)), ',', '.') AS DECIMAL(10,2)) * @FactorCambio AS DECIMAL(10,2)) *  CAST(REPLACE(SUBSTRING(Data,CHARINDEX('-', DATA) + 1, LEN(DATA)), ',', '.') AS INT)
		FROM dbo.split(@ListadoPrecios, @CaracterSeparador)
	END	
	RETURN
END
GO


----SELECT * FROM ObtenerTablaTemporalCotizacionPreciosOtraMoneda ('35,85-582 ;  525,50-5258,6 ; 365,20- 3548,25 ',';', 1 , 1 , 7.09)
--SELECT * FROM ObtenerTablaTemporalCotizacionPreciosOtraMoneda ('35,85-2 ;  525,50-2 ; 365,20- 2 ',';', 1 , 1 , 7.09)

----SELECT  @ListadoCodigosEspecificos = COALESCE(@ListadoCodigosEspecificos + ', ', '') + T.CodigoProductoEspecifico
----		FROM #mytemp T

----SELECT COALESCE( )


--DECLARE @ListadoCodigosEspecificos VARCHAR(8000)
--SELECT @ListadoCodigosEspecificos = COALESCE(@ListadoCodigosEspecificos + '; ', '') + LTRIM(RTRIM(CAST(PrecioUnitarioVenta AS VARCHAR(20)))) + '-'+ LTRIM(RTRIM(CAST(CantidadVenta AS VARCHAR(20))))
--FROM VentasProductosDetalle
--WHERE NumeroVentaProducto = 23
--PRINT @ListadoCodigosEspecificos
--SELECT * FROM ObtenerTablaTemporalCotizacionPreciosOtraMoneda (@ListadoCodigosEspecificos,';', 1 , 0 , 7.9)

--SELECT * FROM ObtenerTablaTemporalCotizacionPreciosOtraMoneda ('44,87-3;46,20-3;30,00-3',';', 1 , 0 , 7.9)

--exec ListarPreciosMonedaCotizacion 1, 23, 1, '25/01/2010 8:13:58', 0, 'V'

----GO

----SELECT * FROM dbo.Split('00000000000000000001, 00000000000000000002, 00000000000000000003, 00000000000000000004, 00000000000000000005, 00000000000000000006, 00000000000000000007, 00000000000000000008, 00000000000000000009, 00000000000000000010' ,',')

----create table #temptable (id INT IDENTITY(1,1),Precio decimal(10,2) , PrecioTotal decimal(10,2))

----insert INTO #temptable (Precio, PrecioTotal)
----SELECT CAST(REPLACE(SUBSTRING(Data,0, CHARINDEX('-',DATA)), ',', '.') AS DECIMAL(10,2)), CAST(REPLACE(SUBSTRING(Data,CHARINDEX('-', DATA) + 1, LEN(DATA)), ',', '.') AS DECIMAL(10,2))from dbo.split('35,85-582 ;  525,50-5258,6 ; 365,20- 3548,25 ',';')

----replace
----substring(
----SELECT charindex(' - ', '3546 - 3546' )

----SELECT * from #temptable
----DROP TABLE #temptable


----SELECT PorcentajeImpuesto FROM SistemaConfiguracion