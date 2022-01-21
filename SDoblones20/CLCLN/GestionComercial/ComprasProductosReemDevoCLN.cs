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
    public class ComprasProductosReemDevoCLN
    {
        #region Atributos de la Clase
        private ComprasProductosReemDevoTableAdapter _ComprasProductosReemDevoAdapter = null;
        protected ComprasProductosReemDevoTableAdapter Adapter
        {
            get
            {
                if (_ComprasProductosReemDevoAdapter == null)
                    _ComprasProductosReemDevoAdapter = new ComprasProductosReemDevoTableAdapter();
                return _ComprasProductosReemDevoAdapter;
            }
        }
        #endregion

        #region Constructor
        public ComprasProductosReemDevoCLN()
        {
            //constructor
        }

        #endregion

        #region Insertar,Actualizar,Eliminar y Obtener  Listado de una CompraProductoReemDevo
        /// <summary>
        /// Insertar una Compra Producto Devolucion
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroReemDevo"></param>
        /// <param name="NumeroCompraProducto"></param>
        /// <param name="FechaHoraSolicitudReemDevo"></param>
        /// <param name="ObservacionesSolicitudReemDevo"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCompraProductoReemDevo(int NumeroAgencia,int NumeroReemDevo,int NumeroCompraProducto, int CodigoUsuario, DateTime FechaHoraSolicitudReemDevo, string ObservacionesSolicitudReemDevo)
        {
            DSDoblones20GestionComercial.ComprasProductosReemDevoDataTable ComprasProductosReemDevo = new DSDoblones20GestionComercial.ComprasProductosReemDevoDataTable();
            DSDoblones20GestionComercial.ComprasProductosReemDevoRow compraProductoReemDevo = ComprasProductosReemDevo.NewComprasProductosReemDevoRow();

            compraProductoReemDevo.NumeroAgencia = NumeroAgencia;
            compraProductoReemDevo.NumeroReemDevo = NumeroReemDevo;
            compraProductoReemDevo.NumeroCompraProducto = NumeroCompraProducto;
            compraProductoReemDevo.CodigoUsuario = CodigoUsuario;
            compraProductoReemDevo.FechaHoraSolicitudReemDevo = FechaHoraSolicitudReemDevo;
            if (ObservacionesSolicitudReemDevo == null)
                compraProductoReemDevo.SetObservacionesSolicitudReemDevoNull();
            else
                compraProductoReemDevo.ObservacionesSolicitudReemDevo = ObservacionesSolicitudReemDevo;
           


            ComprasProductosReemDevo.AddComprasProductosReemDevoRow(compraProductoReemDevo);

            int rowsAffected = Adapter.Update(ComprasProductosReemDevo);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarCompraProductoReemDevo(int NumeroAgencia, int NumeroReemDevo, int NumeroCompraProducto, int CodigoUsuario, DateTime FechaHoraSolicitudReemDevo, string ObservacionesSolicitudReemDevo)
        {
            DSDoblones20GestionComercial.ComprasProductosReemDevoDataTable ComprasProductosReemDevo = Adapter.GetDataBy(NumeroAgencia, NumeroReemDevo);
            if (ComprasProductosReemDevo.Count == 0)
                return false;
            DSDoblones20GestionComercial.ComprasProductosReemDevoRow compraProductoReemDevo = ComprasProductosReemDevo[0];
                        
            compraProductoReemDevo.NumeroCompraProducto = NumeroCompraProducto;
            compraProductoReemDevo.CodigoUsuario = CodigoUsuario;
            compraProductoReemDevo.FechaHoraSolicitudReemDevo = FechaHoraSolicitudReemDevo;
            if (ObservacionesSolicitudReemDevo == null)
                compraProductoReemDevo.SetObservacionesSolicitudReemDevoNull();
            else
                compraProductoReemDevo.ObservacionesSolicitudReemDevo = ObservacionesSolicitudReemDevo;
            
            int rowsAffected = Adapter.Update(compraProductoReemDevo);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCompraProductoReemDevo(int NumeroAgencia, int NumeroReemDevo, int NumeroCompraProducto)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgencia, NumeroReemDevo);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarComprasProductosReemDevo(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia); 
        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerCompraProductoReemDevo(int NumeroAgencia, int NumeroReemDevo, int NumeroCompraProducto)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroReemDevo);
        }
#endregion

    }
}
