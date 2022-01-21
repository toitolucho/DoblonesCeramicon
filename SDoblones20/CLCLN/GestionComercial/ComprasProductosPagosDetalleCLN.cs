using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercial2TableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;



namespace CLCLN.GestionComercial
{
    public class ComprasProductosPagosDetalleCLN
    {
        #region Atributos de la Clase
        private ComprasProductosPagosDetalleTableAdapter _ComprasProductosPagosDetalleAdapter = null;
        
        protected ComprasProductosPagosDetalleTableAdapter Adapter
        {
            get
            {
                if (this._ComprasProductosPagosDetalleAdapter == null)
                    _ComprasProductosPagosDetalleAdapter = new ComprasProductosPagosDetalleTableAdapter();
                return _ComprasProductosPagosDetalleAdapter;
            }
        }
        #endregion

        #region Constructor
        public ComprasProductosPagosDetalleCLN()
        {
            //constructor
        }

        #endregion


        /// <summary>
        /// Insertar un CompraProductoPagoDetalle en la Base de Datos
        /// </summary>
        /// <param name="CodigoCompraProductoPagoDetalle"> Codigo del CompraProductoPagoDetalle</param>
        /// <param name="DIRepresentante">Representante</param>
        /// <param name="CodigoEmpresa"> Codigo de la Empresa a la  que pertenece </param>
        /// <param name="NombreCompraProductoPagoDetalle"> Nombre del CompraProductoPagoDetalle</param>
        /// <param name="NumeroAgencia"> Numero de Agencia</param>
        /// <param name="Observaciones"> Observaciones y descripciones</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCompraProductoPagoDetalle(
                int NumeroAgencia,
                int NumeroCompraProducto,
                int? NumeroCompraProductoPago,
                DateTime? FechaHoraPago,
                decimal MontoTotalPago,
                byte CodigoMonedaPago,
                string NumeroCuenta,
                string Observaciones
            )
        {
            DSDoblones20GestionComercial2.ComprasProductosPagosDetalleDataTable ComprasProductosPagosDetalle = new DSDoblones20GestionComercial2.ComprasProductosPagosDetalleDataTable();
            DSDoblones20GestionComercial2.ComprasProductosPagosDetalleRow CompraProductoPagoDetalle = ComprasProductosPagosDetalle.NewComprasProductosPagosDetalleRow();
            

            CompraProductoPagoDetalle.NumeroAgencia = NumeroAgencia;
            CompraProductoPagoDetalle.NumeroCompraProducto = NumeroCompraProducto;
            CompraProductoPagoDetalle.NumeroCompraProductoPago = NumeroCompraProductoPago.Value;
            CompraProductoPagoDetalle.MontoTotalPago = MontoTotalPago;
            CompraProductoPagoDetalle.CodigoMonedaPago = CodigoMonedaPago;
            CompraProductoPagoDetalle.NumeroCuenta = NumeroCuenta;
            
            if (Observaciones == null) CompraProductoPagoDetalle.SetObservacionesNull();
            else CompraProductoPagoDetalle.Observaciones = Observaciones;
            

            ComprasProductosPagosDetalle.AddComprasProductosPagosDetalleRow(CompraProductoPagoDetalle);

            int rowsAffected = Adapter.Update(ComprasProductosPagosDetalle);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarCompraProductoPagoDetalle(
            int NumeroAgencia,
                int NumeroCompraProducto,
                int NumeroCompraProductoPago,
                DateTime? FechaHoraPago,
                decimal MontoTotalPago,
                byte CodigoMonedaPago,
                string NumeroCuenta,
                string Observaciones)
        {
            DSDoblones20GestionComercial2.ComprasProductosPagosDetalleDataTable ComprasProductosPagosDetalle = Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoPago);
            if (ComprasProductosPagosDetalle.Count == 0)
                return false;
            DSDoblones20GestionComercial2.ComprasProductosPagosDetalleRow CompraProductoPagoDetalle = ComprasProductosPagosDetalle[0];

            CompraProductoPagoDetalle.NumeroAgencia = NumeroAgencia;
            CompraProductoPagoDetalle.NumeroCompraProducto = NumeroCompraProducto;
            CompraProductoPagoDetalle.NumeroCompraProductoPago = NumeroCompraProductoPago;
            CompraProductoPagoDetalle.MontoTotalPago = MontoTotalPago;
            CompraProductoPagoDetalle.CodigoMonedaPago = CodigoMonedaPago;
            CompraProductoPagoDetalle.NumeroCuenta = NumeroCuenta;

            if (Observaciones == null) CompraProductoPagoDetalle.SetObservacionesNull();
            else CompraProductoPagoDetalle.Observaciones = Observaciones;

            int rowsAffected = Adapter.Update(CompraProductoPagoDetalle);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCompraProductoPagoDetalle(int NumeroAgencia,
                int NumeroCompraProducto,
                int NumeroCompraProductoPago)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoPago);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.ComprasProductosPagosDetalleDataTable ListarComprasProductosPagosDetalle()
        {
            /*for (int i = 0; i < dataTable.Columns.Count; i++)
                dataTable.Columns[i].AllowDBNull = true;*/
            return Adapter.GetData();
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.ComprasProductosPagosDetalleDataTable ObtenerCompraProductoPagoDetalle(int NumeroAgencia,
                int NumeroCompraProducto,
                int NumeroCompraProductoPago)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto, NumeroCompraProductoPago);
        }

        public DSDoblones20GestionComercial2.ListarCompraProductoPagoDetalleParaMostrarDataTable ListarCompraProductoPagoDetalleParaMostrar(int NumeroAgencia, int NumeroCompraProducto)
        {
            return new ListarCompraProductoPagoDetalleParaMostrarTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto);

        }
    }
}

