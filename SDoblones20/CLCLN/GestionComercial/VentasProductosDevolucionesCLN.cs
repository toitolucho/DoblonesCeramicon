using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using System.Data;

namespace CLCLN.GestionComercial
{
    public class VentasProductosDevolucionesCLN
    {
        private VentasProductosDevolucionesTableAdapter _VentasProductosDevoluciones = null;
        protected VentasProductosDevolucionesTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosDevoluciones == null)
                    _VentasProductosDevoluciones = new VentasProductosDevolucionesTableAdapter();
                return _VentasProductosDevoluciones;
            }
        }

        public VentasProductosDevolucionesCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaProductoDevolucion(int NumeroAgencia, int NumeroVentaProducto, string CodigoEstadoDevolucion, int CodigoUsuario, DateTime FechaHoraSolicitudReemDevo, string ObservacionesSolicitudReemDevo, int? NumeroDevolucionDevolucion)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesDataTable VentasProductosDevoluciones = new CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesDataTable();
            CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesRow VentaProductoDevolucion = VentasProductosDevoluciones.NewVentasProductosDevolucionesRow();

            VentaProductoDevolucion.NumeroAgencia = NumeroAgencia;
            VentaProductoDevolucion.NumeroVentaProducto = NumeroVentaProducto;
            VentaProductoDevolucion.CodigoEstadoDevolucion = CodigoEstadoDevolucion;
            VentaProductoDevolucion.CodigoUsuario = CodigoUsuario;
            VentaProductoDevolucion.FechaHoraSolicitudReemDevo = FechaHoraSolicitudReemDevo;
            VentaProductoDevolucion.ObservacionesSolicitudReemDevo = ObservacionesSolicitudReemDevo;

            if (NumeroDevolucionDevolucion == null) VentaProductoDevolucion.SetNumeroDevolucionDevolucionNull();
            else VentaProductoDevolucion.NumeroDevolucionDevolucion = NumeroDevolucionDevolucion.Value;
            
            if (ObservacionesSolicitudReemDevo == null) VentaProductoDevolucion.SetObservacionesSolicitudReemDevoNull();
            else VentaProductoDevolucion.ObservacionesSolicitudReemDevo = ObservacionesSolicitudReemDevo;

                                               
            VentasProductosDevoluciones.AddVentasProductosDevolucionesRow(VentaProductoDevolucion);

            int rowsAffected = Adapter.Update(VentasProductosDevoluciones);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaProductoReemDevo(int NumeroAgencia, int NumeroDevolucion, string CodigoEstadoDevolucion, DateTime FechaHoraSolicitudReemDevo, string ObservacionesSolicitudReemDevo, int NumeroDevolucionDevolucion)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesDataTable VentasProductosDevoluciones = Adapter.GetDataBy(NumeroAgencia, NumeroDevolucion);
            if (VentasProductosDevoluciones.Count == 0)
                return false;

            CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesRow VentaProductoDevolucion = VentasProductosDevoluciones[0];

            VentaProductoDevolucion.CodigoEstadoDevolucion = CodigoEstadoDevolucion;            
            VentaProductoDevolucion.FechaHoraSolicitudReemDevo = FechaHoraSolicitudReemDevo;
            if (ObservacionesSolicitudReemDevo == null) VentaProductoDevolucion.SetObservacionesSolicitudReemDevoNull();
            else VentaProductoDevolucion.ObservacionesSolicitudReemDevo = ObservacionesSolicitudReemDevo;

            if (NumeroDevolucionDevolucion == null) VentaProductoDevolucion.SetNumeroDevolucionDevolucionNull();
            else VentaProductoDevolucion.NumeroDevolucionDevolucion = NumeroDevolucionDevolucion;

            int rowsAffected = Adapter.Update(VentaProductoDevolucion);
            return rowsAffected == 1;
        }


        public bool ActualizarVentaProductoReemDevo(int NumeroAgencia, int NumeroDevolucion, string ObservacionesSolicitudReemDevo)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesDataTable VentasProductosDevoluciones = Adapter.GetDataBy(NumeroAgencia, NumeroDevolucion);
            if (VentasProductosDevoluciones.Count == 0)
                return false;

            CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesRow VentaProductoDevolucion = VentasProductosDevoluciones[0];

            
            if (ObservacionesSolicitudReemDevo == null) VentaProductoDevolucion.SetObservacionesSolicitudReemDevoNull();
            else VentaProductoDevolucion.ObservacionesSolicitudReemDevo = ObservacionesSolicitudReemDevo;
            
            int rowsAffected = Adapter.Update(VentaProductoDevolucion);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaProductoReemDevo(int NumeroAgencia, int NumeroDevolucion)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroDevolucion);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosDevoluciones(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public DSCapataz.VentasProductosDevolucionesDataTable ObtenerVentaProductoReemDevo(int CodigoVentaProductoReemDevo)
        public DataTable ObtenerVentaProductoDevolucion(int NumeroAgencia, int NumeroDevolucion)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroDevolucion);
        }

        /// <summary>
        /// Metodo que se encarga de finalizar o anular una devolución de productos
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroDevolucion"></param>
        /// <param name="CodigoEstadoDevolucion"></param>
        /// <param name="FechaDevolucion"></param>
        public void FinalizarAnularVentaProductoDevolucion(int NumeroAgencia, int NumeroDevolucion, string CodigoEstadoDevolucion, DateTime? FechaDevolucion)
        {
            new FuncionesGestionComercial().FinalizarAnularVentaProductoDevolucion(NumeroAgencia, NumeroDevolucion, CodigoEstadoDevolucion, FechaDevolucion);
        }

        public DataTable ListarVentaDevolucionReporte(int NumeroAgencia, int NumeroDevolucion)
        {
            return new ReporteVentasProductosDevolucionesTableAdapter().GetData(NumeroAgencia, NumeroDevolucion);
        }

    }
}
