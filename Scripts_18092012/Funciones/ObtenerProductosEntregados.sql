

USE DOBLONES20
GO

IF OBJECT_ID (N'dbo.ObtenerProductosEntregados', N'FN') IS NOT NULL
    DROP FUNCTION dbo.ObtenerProductosEntregados; 
GO

CREATE FUNCTION dbo.ObtenerProductosEntregados (@NumeroAgencia INT, @NumeroTransaccion INT, @TipoTransaccion CHAR(1))
RETURNS VARCHAR(8000)
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @ListadoProductos VARCHAR(8000)	
	IF(@TipoTransaccion = 'V')
	BEGIN
		SELECT  @ListadoProductos = COALESCE(@ListadoProductos + ', ', '') + dbo.ObtenerNombreProducto(VPD.CodigoProducto )
		FROM dbo.VentasProductosDetalle VPD
		WHERE VPD.NumeroAgencia = @NumeroAgencia AND NumeroVentaProducto = @NumeroTransaccion
	END
	
	IF(@TipoTransaccion = 'C')
	BEGIN
		SELECT  @ListadoProductos = COALESCE(@ListadoProductos + ', ', '') + dbo.ObtenerNombreProducto(CPD.CodigoProducto )
		FROM dbo.ComprasProductosDetalle CPD
		WHERE CPD.NumeroAgencia = @NumeroAgencia AND NumeroCompraProducto = @NumeroTransaccion
	END
	
	IF(@TipoTransaccion = 'D')
	BEGIN
		SELECT  @ListadoProductos = COALESCE(@ListadoProductos + ', ', '') + dbo.ObtenerNombreProducto(CPD.CodigoProducto )
		FROM dbo.VentasProductosReemplazoDetalle CPD
		WHERE CPD.NumeroAgencia = @NumeroAgencia AND NumeroReemplazo = @NumeroTransaccion
	END
	
   	RETURN(LTRIM(RTRIM( @ListadoProductos)))
END
GO


select dbo.ObtenerProductosEntregados(1,176,'C')

exec ReporteComprasProductosDevoluciones 1, 1

MEMORIA RAM DDR1   1GB PC400, 
MEMORIA RAM DDR2 KINGSTON 2 GB PC6400-800, 
MICROPROCESADOR INTEL CORE 2 QUAD  2.6 GHZ 8MB, 
MICROPROCESADOR INTEL C2D 2.93 GHZ 3MB, MICROPROCESADOR INTEL C2D 3.00 GHZ, 
MICROPROCESADOR INTEL C2D 2.80 GHZ 3MB, 
MICROPROCESADOR INTEL DUAL CORE 2,60GHz  2M/800, 
MICROPROCESADOR INTEL CORE 2 QUAD 3.GHZ 12M CACHE FSB 1333 64 BITS,
MICROPROCESADOR INTEL CORE 2 QUAD 9550, 2,83 GHZ 12MB/1333MHZ


MEMORIA RAM DDR1   1GB PC400, 
MEMORIA RAM DDR2 KINGSTON 2 GB PC6400-800,
 MICROPROCESADOR INTEL CORE 2 QUAD  2.6 GHZ 8MB,
  MICROPROCESADOR INTEL C2D 2.93 GHZ 3MB, MICROPROCESADOR INTEL C2D 3.00 GHZ, MICROPROCESADOR INTEL C2D 2.80 GHZ 3MB, MICROPROCESADOR INTEL DUAL CORE 2,60GHz  2M/800, MICROPROCESADOR INTEL CORE 2 QUAD 3.GHZ 12M CACHE FSB 1333 64 BITS, MICROPROCESADOR INTEL CORE 2 QUAD 9550, 2,83 GHZ 12MB/1333MHZ