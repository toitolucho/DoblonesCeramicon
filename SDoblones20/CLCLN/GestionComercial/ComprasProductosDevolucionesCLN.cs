using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using System.Data;

namespace CLCLN.GestionComercial
{
    public class ComprasProductosDevolucionesCLN
    {
        private ComprasProductosDevolucionesTableAdapter _VentasProductosDevoluciones = null;
        protected ComprasProductosDevolucionesTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosDevoluciones == null)
                    _VentasProductosDevoluciones = new ComprasProductosDevolucionesTableAdapter();
                return _VentasProductosDevoluciones;
            }
        }

        public ComprasProductosDevolucionesCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCompraProductoDevolucion(int NumeroAgencia, int NumeroCompraProducto, string CodigoEstadoDevolucion, int CodigoUsuario, DateTime FechaHoraSolicitudDevolucion, string ObservacionesSolicitudDevo, int? NumeroDevolucionDevolucion)
        {
            CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesDataTable ComprasProductosDevoluciones = new CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesDataTable();
            CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesRow CompraProductoDevolucion = ComprasProductosDevoluciones.NewComprasProductosDevolucionesRow();

            CompraProductoDevolucion.NumeroAgencia = NumeroAgencia;
            CompraProductoDevolucion.NumeroCompraProducto = NumeroCompraProducto;
            CompraProductoDevolucion.CodigoEstadoDevolucion = CodigoEstadoDevolucion;
            CompraProductoDevolucion.CodigoUsuario = CodigoUsuario;
            CompraProductoDevolucion.FechaHoraSolicitudDevolucion = FechaHoraSolicitudDevolucion;
            if (ObservacionesSolicitudDevo != null) CompraProductoDevolucion.ObservacionesSolicitudDevo = ObservacionesSolicitudDevo;
            else CompraProductoDevolucion.SetObservacionesSolicitudDevoNull();

            if (NumeroDevolucionDevolucion == null) CompraProductoDevolucion.SetNumeroDevolucionDevolucionNull();
            else CompraProductoDevolucion.NumeroDevolucionDevolucion = NumeroDevolucionDevolucion.Value;

            ComprasProductosDevoluciones.AddComprasProductosDevolucionesRow(CompraProductoDevolucion);

            int rowsAffected = Adapter.Update(ComprasProductosDevoluciones);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarCompraProductoDevolucion(int NumeroAgencia, int NumeroDevolucion, int NumeroCompraProducto, string CodigoEstadoDevolucion, int CodigoUsuario, DateTime FechaHoraSolicitudDevolucion, string ObservacionesSolicitudDevo, int NumeroDevolucionDevolucion)
        {
            CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesDataTable ComprasProductosDevoluciones = Adapter.GetDataBy(NumeroAgencia, NumeroDevolucion);
            if (ComprasProductosDevoluciones.Count == 0)
                return false;

            CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesRow CompraProductoDevolucion = ComprasProductosDevoluciones[0];

            CompraProductoDevolucion.CodigoEstadoDevolucion = CodigoEstadoDevolucion;
            CompraProductoDevolucion.FechaHoraSolicitudDevolucion = FechaHoraSolicitudDevolucion;
            if (ObservacionesSolicitudDevo != null) CompraProductoDevolucion.ObservacionesSolicitudDevo = ObservacionesSolicitudDevo;
            else CompraProductoDevolucion.SetObservacionesSolicitudDevoNull();

            if (NumeroDevolucionDevolucion == null) CompraProductoDevolucion.SetNumeroDevolucionDevolucionNull();
            else CompraProductoDevolucion.NumeroDevolucionDevolucion = NumeroDevolucionDevolucion;

            int rowsAffected = Adapter.Update(CompraProductoDevolucion);
            return rowsAffected == 1;
        }

        public bool ActualizarCompraProductoDevolucion(int NumeroAgencia, int NumeroDevolucion, string ObservacionesSolicitudDevo)
        {
            CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesDataTable ComprasProductosDevoluciones = Adapter.GetDataBy(NumeroAgencia, NumeroDevolucion);
            if (ComprasProductosDevoluciones.Count == 0)
                return false;

            CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesRow CompraProductoDevolucion = ComprasProductosDevoluciones[0];

            if (ObservacionesSolicitudDevo != null) CompraProductoDevolucion.ObservacionesSolicitudDevo = ObservacionesSolicitudDevo;
            else CompraProductoDevolucion.SetObservacionesSolicitudDevoNull();

            int rowsAffected = Adapter.Update(CompraProductoDevolucion);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCompraProductoDevolucion(int NumeroAgencia, int NumeroDevolucion)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroDevolucion);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarComprasProductosDevoluciones(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public DSCapataz.VentasProductosDevolucionesDataTable ObtenerVentaProductoReemDevo(int CodigoVentaProductoReemDevo)
        public DataTable ObtenerCompraProductoDevolucion(int NumeroAgencia, int NumeroDevolucion)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroDevolucion);
        }

        public void FinalizarAnularCompraProductoDevolucion(int NumeroAgencia, int NumeroDevolucion, string CodigoEstadoDevolucion, DateTime FechaDevolucion)
        {
            new FuncionesGestionComercial().FinalizarAnularCompraProductoDevolucion(NumeroAgencia, NumeroDevolucion, CodigoEstadoDevolucion, FechaDevolucion);
        }


        public DataTable ListarCompraProductoDevolucionReporte(int NumeroAgencia, int NumeroDevolucion)
        {
            return new ReporteComprasProductosDevolucionesTableAdapter().GetData(NumeroAgencia, NumeroDevolucion);
        }
    }
}
