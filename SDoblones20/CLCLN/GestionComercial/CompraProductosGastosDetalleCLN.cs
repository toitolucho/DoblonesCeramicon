using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;
using CLCAD.DSDoblones20GestionComercial2TableAdapters;

namespace CLCLN.GestionComercial
{
    public class CompraProductosGastosDetalleCLN
    {
         #region Atributos de la Clase
        private CompraProductosGastosDetalleTableAdapter _CompraProductosGastosDetalleAdapter = null;
        protected CompraProductosGastosDetalleTableAdapter Adapter
        {
            get
            {
                if (_CompraProductosGastosDetalleAdapter == null)
                    _CompraProductosGastosDetalleAdapter = new CompraProductosGastosDetalleTableAdapter();
                return _CompraProductosGastosDetalleAdapter;
            }
        }
        #endregion

        #region Constructor
        public CompraProductosGastosDetalleCLN()
        {
            //constructor
        }

        #endregion


        /// <summary>
        /// Insertar un detalle de compra de Gasto
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroCompraProducto"></param>
        /// <param name="CodigoGastosTipos"></param>
        /// <param name="FechaHoraGasto"></param>
        /// <param name="MontoPagoGasto"></param>
        /// <param name="CodigoMonedaPago"></param>
        /// <param name="Observaciones"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCompraProductoGastoDetalle(int NumeroAgencia, int NumeroCompraProducto, int CodigoGastosTipos, DateTime FechaHoraGasto, decimal MontoPagoGasto, byte? CodigoMonedaPago, string Observaciones)
        {
            DSDoblones20GestionComercial.CompraProductosGastosDetalleDataTable CompraProductosGastosDetalle = new DSDoblones20GestionComercial.CompraProductosGastosDetalleDataTable();
            DSDoblones20GestionComercial.CompraProductosGastosDetalleRow CompraProductoGastoDetalle = CompraProductosGastosDetalle.NewCompraProductosGastosDetalleRow();

            CompraProductoGastoDetalle.NumeroAgencia = NumeroAgencia;
            CompraProductoGastoDetalle.NumeroCompraProducto = NumeroCompraProducto;
            CompraProductoGastoDetalle.CodigoGastosTipos = CodigoGastosTipos;
            CompraProductoGastoDetalle.FechaHoraGasto = FechaHoraGasto;
            CompraProductoGastoDetalle.MontoPagoGasto = MontoPagoGasto;
            if (CodigoMonedaPago == null) CompraProductoGastoDetalle.SetCodigoMonedaPagoNull();
            else CompraProductoGastoDetalle.CodigoMonedaPago = CodigoMonedaPago.Value;
            if (Observaciones == null) CompraProductoGastoDetalle.SetObservacionesNull();
            else CompraProductoGastoDetalle.Observaciones = Observaciones;

                   
            CompraProductosGastosDetalle.AddCompraProductosGastosDetalleRow(CompraProductoGastoDetalle);

            int rowsAffected = Adapter.Update(CompraProductosGastosDetalle);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarCompraProductoGastoDetalle(int NumeroAgencia, int NumeroCompraProducto, int  NumeroCompraProductoGasto, int CodigoGastosTipos, DateTime FechaHoraGasto, decimal MontoPagoGasto, byte? CodigoMonedaPago, string Observaciones)
        {
            DSDoblones20GestionComercial.CompraProductosGastosDetalleDataTable CompraProductosGastosDetalle = Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoGasto);
            if (CompraProductosGastosDetalle.Count == 0)
                return false;
            DSDoblones20GestionComercial.CompraProductosGastosDetalleRow CompraProductoGastoDetalle = CompraProductosGastosDetalle[0];

            CompraProductoGastoDetalle.NumeroAgencia = NumeroAgencia;
            CompraProductoGastoDetalle.NumeroCompraProducto = NumeroCompraProducto;
            //CompraProductoGastoDetalle.NumeroCompraProductoGasto = NumeroCompraProductoGasto;
            CompraProductoGastoDetalle.CodigoGastosTipos = CodigoGastosTipos;
            CompraProductoGastoDetalle.FechaHoraGasto = FechaHoraGasto;
            CompraProductoGastoDetalle.MontoPagoGasto = MontoPagoGasto;
            if (CodigoMonedaPago == null) CompraProductoGastoDetalle.SetCodigoMonedaPagoNull();
            else CompraProductoGastoDetalle.CodigoMonedaPago = CodigoMonedaPago.Value;
            if (Observaciones == null) CompraProductoGastoDetalle.SetObservacionesNull();
            else CompraProductoGastoDetalle.Observaciones = Observaciones;

            int rowsAffected = Adapter.Update(CompraProductoGastoDetalle);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCompraProductoGastoDetalle(int NumeroAgencia, int NumeroCompraProducto, int NumeroCompraProductoGasto)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoGasto);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial.CompraProductosGastosDetalleDataTable ListarCompraProductosGastosDetalle()
        {
            /*for (int i = 0; i < dataTable.Columns.Count; i++)
                dataTable.Columns[i].AllowDBNull = true;*/
            return Adapter.GetData(); 
        }

        
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial.CompraProductosGastosDetalleDataTable ObtenerCompraProductoGastoDetalle(int NumeroAgencia, int NumeroCompraProducto, int NumeroCompraProductoGasto)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoGasto);
        }

        public DSDoblones20GestionComercial.ListarCompraProductoGastoDetalleParaPagosDataTable ListarCompraProductoGastoDetalleParaPagos(int NumeroAgencia, int NumeroCompraProducto)
        {
            return new ListarCompraProductoGastoDetalleParaPagosTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto); 
        }

        public bool ExisteGastosParaCompra(int NumeroAgencia, int NumeroCompraProducto)
        {
            return new FuncionesGestionComercial().ExisteGastosParaCompra(NumeroAgencia, NumeroCompraProducto).Value;
        }

        public DSDoblones20GestionComercial.ListarProductoGastosComprasDataTable ListarProductoGastosCompras(int NumeroAgencia, int NumeroCompraProducto)
        {
            return new ListarProductoGastosComprasTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto);
        }

        public void ActualizarCompraProductosGastosDetalleGeneral(int NumeroAgencia, int NumeroCompraProducto)
        {
            new QTAFuncionesGestionComercial().ActualizarCompraProductosGastosDetalleGeneral(NumeroAgencia, NumeroCompraProducto);
        }
    }
}

