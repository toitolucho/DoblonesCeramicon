using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.GestionComercial
{
    public class ComprasProductosDetalleEntregaCLN
    {
        #region Atributos de la Clase
        private ComprasProductosDetalleEntregaTableAdapter _ComprasProductosDetalleEntregaAdapter = null;
        protected ComprasProductosDetalleEntregaTableAdapter Adapter
        {
            get
            {
                if (_ComprasProductosDetalleEntregaAdapter == null)
                    _ComprasProductosDetalleEntregaAdapter = new ComprasProductosDetalleEntregaTableAdapter();
                return _ComprasProductosDetalleEntregaAdapter;
            }
        }
        #endregion

        #region Constructor
        public ComprasProductosDetalleEntregaCLN()
        {
            //constructor
        }

        #endregion


        /// <summary>
        /// Insertar un CompraProductoDetalleEntrega en la Base de Datos
        /// </summary>
        /// <param name="CodigoCompraProductoDetalleEntrega"> Codigo del CompraProductoDetalleEntrega</param>
        /// <param name="DIRepresentante">Representante</param>
        /// <param name="CodigoEmpresa"> Codigo de la Empresa a la  que pertenece </param>
        /// <param name="NombreCompraProductoDetalleEntrega"> Nombre del CompraProductoDetalleEntrega</param>
        /// <param name="NumeroAgencia"> Numero de Agencia</param>
        /// <param name="Observaciones"> Observaciones y descripciones</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCompraProductoDetalleEntrega(int NumeroAgencia, int NumeroCompraProducto, string CodigoProducto, int CantidadEntregada, DateTime FechaHoraEntrega)
        {
            DSDoblones20GestionComercial.ComprasProductosDetalleEntregaDataTable ComprasProductosDetalleEntrega = new DSDoblones20GestionComercial.ComprasProductosDetalleEntregaDataTable();
            DSDoblones20GestionComercial.ComprasProductosDetalleEntregaRow CompraProductoDetalleEntrega = ComprasProductosDetalleEntrega.NewComprasProductosDetalleEntregaRow();

            CompraProductoDetalleEntrega.NumeroAgencia = NumeroAgencia;
            CompraProductoDetalleEntrega.NumeroCompraProducto = NumeroCompraProducto;
            CompraProductoDetalleEntrega.CodigoProducto = CodigoProducto;
            CompraProductoDetalleEntrega.CantidadEntregada = CantidadEntregada;
            CompraProductoDetalleEntrega.FechaHoraEntrega = FechaHoraEntrega;
         
            ComprasProductosDetalleEntrega.AddComprasProductosDetalleEntregaRow(CompraProductoDetalleEntrega);

            int rowsAffected = Adapter.Update(ComprasProductosDetalleEntrega);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarCompraProductoDetalleEntrega(int NumeroAgencia, int NumeroCompraProducto, string CodigoProducto, int CantidadEntregada, DateTime FechaHoraEntrega)
        {
            DSDoblones20GestionComercial.ComprasProductosDetalleEntregaDataTable ComprasProductosDetalleEntrega = Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraEntrega);
            if (ComprasProductosDetalleEntrega.Count == 0)
                return false;
            DSDoblones20GestionComercial.ComprasProductosDetalleEntregaRow CompraProductoDetalleEntrega = ComprasProductosDetalleEntrega[0];
                        
            
            CompraProductoDetalleEntrega.CantidadEntregada = CantidadEntregada;
            CompraProductoDetalleEntrega.FechaHoraEntrega = FechaHoraEntrega;

            int rowsAffected = Adapter.Update(CompraProductoDetalleEntrega);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCompraProductoDetalleEntrega(int NumeroAgencia, int NumeroCompraProducto, string CodigoProducto,  DateTime FechaHoraEntrega)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraEntrega);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public CLCAD.DSDoblones20GestionComercial.ComprasProductosDetalleEntregaDataTable ListarComprasProductosDetalleEntrega(int NumeroAgencia)
        {            
            return Adapter.GetData(NumeroAgencia); 
        }

        
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public CLCAD.DSDoblones20GestionComercial.ComprasProductosDetalleEntregaDataTable ObtenerCompraProductoDetalleEntrega(int NumeroAgencia, int NumeroCompraProducto, string CodigoProducto, DateTime FechaHoraEntrega)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraEntrega);
        }

        public CLCAD.DSDoblones20GestionComercial.ListarComprasProductosDetalleEntregaParaRecepcionDataTable ListarComprasProductosDetalleEntregaParaRecepcion(int NumeroAgencia, int NumeroCompraProducto)
        {
            return new ListarComprasProductosDetalleEntregaParaRecepcionTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto);
        }
    }
}
