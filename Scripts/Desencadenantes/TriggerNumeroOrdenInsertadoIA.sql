---- ================================================
---- Template generated from Template Explorer using:
---- Create Trigger (New Menu).SQL
----
---- Use the Specify Values for Template Parameters 
---- command (Ctrl-Shift-M) to fill in the parameter 
---- values below.
----
---- See additional Create Trigger templates for more
---- examples of different Trigger statements.
----
---- This block of comments will not be included in
---- the definition of the function.
---- ================================================
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
---- =============================================
---- Author:		<Author,Luis Antonio Molina Yampa,>
---- Create date: <Create Date,18/05/2011,>
---- Description:	<Description,Actualiza Directamente el NumeroOrdenInsertado,>
---- =============================================
--DROP TRIGGER TriggerNumeroOrdenInsertadoIA 
--GO

--CREATE TRIGGER TriggerNumeroOrdenInsertadoIA 
--   ON  dbo.VentasProductosDetalle
--   AFTER  INSERT
--AS 
--BEGIN
--	-- SET NOCOUNT ON added to prevent extra result sets from
--	-- interfering with SELECT statements.
--	--SET NOCOUNT ON;
--	--SET INSERTED.NumeroOrdenInsertado = DBO.ObtenerNumeroOrdenProducto('V',INSERTED.NumeroAgencia, INSERTED.NumeroVentaProducto)
	
	
--	DECLARE @NumeroOrdenInsertado	INT,
--			@NumeroAgencia			INT,
--			@NumeroVentaProducto	INT,
--			@CodigoProducto			CHAR(15)			
	
--	SELECT @NumeroAgencia = NumeroAgencia, @NumeroVentaProducto = NumeroVentaProducto, @CodigoProducto = CodigoProducto
--	FROM INSERTED
	
--	SELECT @NumeroOrdenInsertado= COUNT(*)
--	FROM dbo.VentasProductosDetalle
--	WHERE NumeroAgencia = @NumeroAgencia
--	AND NumeroVentaProducto = @NumeroVentaProducto
	
--	INSERT INTO TEMPORAL (NumeroAgencia, NumeroTransaccion, CodigoProducto, NumeroGenerado, TipoTransaccion)
--	VALUES(@NumeroAgencia, @NumeroVentaProducto, @CodigoProducto, @NumeroOrdenInsertado, 'V')
	
--	UPDATE VentasProductosDetalle
--		SET VentasProductosDetalle.NumeroOrdenInsertado = @NumeroOrdenInsertado
--	FROM VentasProductosDetalle	
--	WHERE VentasProductosDetalle.NumeroAgencia = @NumeroAgencia
--	AND VentasProductosDetalle.NumeroVentaProducto = @NumeroVentaProducto 
--	AND VentasProductosDetalle.CodigoProducto = @CodigoProducto
--END
--GO


--select *, dbo.ObtenerNombreProducto(CodigoProducto)
--from VentasProductosDetalle
--where NumeroVentaProducto = 387


--DROP TABLE TEMPORAL
--CREATE TABLE TEMPORAL
--(
--	NumeroAgencia		INT,
--	NumeroTransaccion	INT,
--	CodigoProducto		CHAR(15),
--	NumeroGenerado		INT,
--	TipoTransaccion		CHAR(1)	
--)


--SELECT * , ROW_NUMBER() OVER(ORDER BY NumeroAgencia DESC) AS 'Row Number'
--FROM TEMPORAL