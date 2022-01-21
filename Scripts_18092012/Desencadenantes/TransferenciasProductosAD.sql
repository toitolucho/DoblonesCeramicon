USE Doblones20
GO

IF OBJECT_ID ('TActualizarPrecioCompraRealInventariosTransferencias','TR') IS NOT NULL
   DROP TRIGGER TActualizarPrecioCompraRealInventariosTransferencias;
GO

CREATE TRIGGER TActualizarPrecioCompraRealInventariosTransferencias ON TransferenciasProductos
AFTER UPDATE
AS
	IF(EXISTS (SELECT * FROM INSERTED WHERE CodigoEstadoTransferencia IN ('F','X')))
	BEGIN
		UPDATE InventariosProductos
			SET PrecioUnitarioCompraSinGastos = TPD.PrecioUnitarioTransferencia
		FROM transferenciasproductos TP
		INNER JOIN TransferenciasProductosDetalle TPD
		ON TP.NumeroAgenciaEmisora = TPD.NumeroAgenciaEmisora
		AND TP.NumeroTransferenciaProducto = TPD.NumeroTransferenciaProducto		
		WHERE InventariosProductos.NumeroAgencia = TP.NumeroAgenciaRecepctora
		AND InventariosProductos.CodigoProducto = TPD.CodigoProducto
		AND TPD.CodigoProducto IN(
			SELECT DISTINCT TPDR.CodigoProducto
			FROM TransferenciasProductosDetalleRecepcion TPDR
			WHERE TPDR.NumeroTransferenciaProducto = TP.NumeroTransferenciaProducto
			AND TPDR.NumeroAgenciaEmisora = TP.NumeroAgenciaEmisora
		)		
	END
GO