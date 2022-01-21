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
    [System.ComponentModel.DataObject]
    public class VentasProductosReemDevoCLN
    {
        private VentasProductosReemDevoTableAdapter _VentasProductosReemDevoAdapter = null;
        protected VentasProductosReemDevoTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosReemDevoAdapter == null)
                    _VentasProductosReemDevoAdapter = new VentasProductosReemDevoTableAdapter();
                return _VentasProductosReemDevoAdapter;
            }
        }

        public VentasProductosReemDevoCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaProductoReemDevo(int NumeroAgencia, int NumeroVentaProducto, int CodigoUsuario, DateTime FechaHoraSolicitudReemDevo, string ObservacionesSolicitudReemDevo)
        {
            DSDoblones20GestionComercial.VentasProductosReemDevoDataTable VentasProductosReemDevo = new DSDoblones20GestionComercial.VentasProductosReemDevoDataTable();
            DSDoblones20GestionComercial.VentasProductosReemDevoRow VentaProductoReemDevo = VentasProductosReemDevo.NewVentasProductosReemDevoRow();

            VentaProductoReemDevo.NumeroAgencia = NumeroAgencia;
            VentaProductoReemDevo.NumeroVentaProducto = NumeroVentaProducto;
            VentaProductoReemDevo.CodigoUsuario = CodigoUsuario;
            VentaProductoReemDevo.FechaHoraSolicitudReemDevo = FechaHoraSolicitudReemDevo;
            VentaProductoReemDevo.ObservacionesSolicitudReemDevo = ObservacionesSolicitudReemDevo;
            
            if (ObservacionesSolicitudReemDevo == null) VentaProductoReemDevo.SetObservacionesSolicitudReemDevoNull();
            else VentaProductoReemDevo.ObservacionesSolicitudReemDevo = ObservacionesSolicitudReemDevo;

                                               
            VentasProductosReemDevo.AddVentasProductosReemDevoRow(VentaProductoReemDevo);

            int rowsAffected = Adapter.Update(VentasProductosReemDevo);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaProductoReemDevo(int NumeroAgencia, int NumeroReemDevo, int NumeroVentaProducto, int CodigoUsuario, DateTime FechaHoraSolicitudReemDevo, string ObservacionesSolicitudReemDevo)
        {
            DSDoblones20GestionComercial.VentasProductosReemDevoDataTable VentasProductosReemDevo = Adapter.GetDataBy(NumeroAgencia, NumeroReemDevo);
            if (VentasProductosReemDevo.Count == 0)
                return false;

            DSDoblones20GestionComercial.VentasProductosReemDevoRow VentaProductoReemDevo = VentasProductosReemDevo[0];

            
            VentaProductoReemDevo.CodigoUsuario = CodigoUsuario;
            VentaProductoReemDevo.FechaHoraSolicitudReemDevo = FechaHoraSolicitudReemDevo;
            VentaProductoReemDevo.ObservacionesSolicitudReemDevo = ObservacionesSolicitudReemDevo;

            if (ObservacionesSolicitudReemDevo == null) VentaProductoReemDevo.SetObservacionesSolicitudReemDevoNull();
            else VentaProductoReemDevo.ObservacionesSolicitudReemDevo = ObservacionesSolicitudReemDevo;

            int rowsAffected = Adapter.Update(VentaProductoReemDevo);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaProductoReemDevo(int NumeroAgencia, int NumeroReemDevo)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroReemDevo);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosReemDevo(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public DSCapataz.VentasProductosReemDevoDataTable ObtenerVentaProductoReemDevo(int CodigoVentaProductoReemDevo)
        public DataTable ObtenerVentaProductoReemDevo(int NumeroAgencia, int NumeroReemDevo)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroReemDevo);
        }
    }
}
