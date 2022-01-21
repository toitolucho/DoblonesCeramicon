using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using System.Data;

namespace CLCLN.GestionComercial
{
    public class VentasProductosReemplazoCLN
    {
        private VentasProductosReemplazoTableAdapter _VentasProductosReemplazo = null;
        protected VentasProductosReemplazoTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosReemplazo == null)
                    _VentasProductosReemplazo = new VentasProductosReemplazoTableAdapter();
                return _VentasProductosReemplazo;
            }
        }

        public VentasProductosReemplazoCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaProductoReemplazo(int NumeroAgencia, int NumeroDevolucion, string CodigoEstadoReemplazo, int CodigoUsuario, DateTime FechaHoraSolicitudReemplazo, string ObservacionesReemplazo)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDataTable VentasProductosReemplazo = new CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDataTable();
            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoRow VentaProductoReemplazo = VentasProductosReemplazo.NewVentasProductosReemplazoRow();
                        
            VentaProductoReemplazo.NumeroAgencia = NumeroAgencia;
            VentaProductoReemplazo.NumeroDevolucion = NumeroDevolucion;
            VentaProductoReemplazo.CodigoEstadoReemplazo = CodigoEstadoReemplazo;
            VentaProductoReemplazo.CodigoUsuario = CodigoUsuario;
            VentaProductoReemplazo.FechaHoraSolicitudReemplazo = FechaHoraSolicitudReemplazo;
            if (ObservacionesReemplazo == null) VentaProductoReemplazo.SetObservacionesReemplazoNull();
            else VentaProductoReemplazo.ObservacionesReemplazo = ObservacionesReemplazo;


            VentasProductosReemplazo.AddVentasProductosReemplazoRow(VentaProductoReemplazo);

            int rowsAffected = Adapter.Update(VentasProductosReemplazo);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaProductoReemplazo(int NumeroAgencia, int NumeroReemplazo, int NumeroDevolucion, string CodigoEstadoReemplazo, int CodigoUsuario, DateTime FechaHoraSolicitudReemplazo, string ObservacionesReemplazo)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDataTable VentasProductosReemplazo = Adapter.GetDataBy(NumeroAgencia, NumeroReemplazo);
            if (VentasProductosReemplazo.Count == 0)
                return false;

            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoRow VentaProductoReemplazo = VentasProductosReemplazo[0];
            
            VentaProductoReemplazo.CodigoEstadoReemplazo = CodigoEstadoReemplazo;
            VentaProductoReemplazo.CodigoUsuario = CodigoUsuario;
            VentaProductoReemplazo.FechaHoraSolicitudReemplazo = FechaHoraSolicitudReemplazo;
            if (ObservacionesReemplazo == null) VentaProductoReemplazo.SetObservacionesReemplazoNull();
            else VentaProductoReemplazo.ObservacionesReemplazo = ObservacionesReemplazo;
            VentaProductoReemplazo.NumeroDevolucion = NumeroDevolucion;

            int rowsAffected = Adapter.Update(VentaProductoReemplazo);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaProductoReemplazo(int NumeroAgencia, int NumeroReemplazo)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroReemplazo);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosReemplazos(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public DSCapataz.VentasProductosDevolucionesDataTable ObtenerVentaProductoReemDevo(int CodigoVentaProductoReemDevo)
        public DataTable ObtenerVentaProductoReemplazo(int NumeroAgencia, int NumeroReemplazo)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroReemplazo);
        }

        public DataTable ObtenerVentaProductoReemplazo(int NumeroAgencia, int NumeroReemplazo, int NumeroDevolucion)
        {
            return Adapter.GetDataBy1(NumeroAgencia, NumeroReemplazo, NumeroDevolucion);
        }

        public void FinalizarAnularVentasProductoReemplazo(int NumeroAgencia, int NumeroReemplazo, string CodigoEstadoReemplazo, DateTime FechaReemplazo)
        {
            new FuncionesGestionComercial().FinalizarAnularVentasProductoReemplazo(NumeroAgencia, NumeroReemplazo, CodigoEstadoReemplazo, FechaReemplazo);
        }

        public DataTable ListarVentaProductoReemplazoReporte(int NumeroAgencia, int NumeroReemplazo)
        {
            return new ReporteVentasProductosReemplazoTableAdapter().GetData(NumeroAgencia, NumeroReemplazo);
        }

    }
}
