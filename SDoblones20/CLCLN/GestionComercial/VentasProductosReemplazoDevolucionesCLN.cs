using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using System.Data;

namespace CLCLN.GestionComercial
{
    public class VentasProductosReemplazoDevolucionesCLN
    {
        private VentasProductosReemplazoDevolucionesTableAdapter _VentasProductosReemplazoDevoluciones = null;
        private ObtenerProductosDevolucionesReemplazoDisponbilesTableAdapter _ProductosDevolucionesDisponiblesAdapter;

        DataTable ProductosDevoReemDisponibles = null;
        protected ObtenerProductosDevolucionesReemplazoDisponbilesTableAdapter ProductosDevolucionesDisponiblesAdapter
        {
            get
            {
                if (_ProductosDevolucionesDisponiblesAdapter == null)
                    _ProductosDevolucionesDisponiblesAdapter = new ObtenerProductosDevolucionesReemplazoDisponbilesTableAdapter();
                return _ProductosDevolucionesDisponiblesAdapter;
            }
        }

        protected VentasProductosReemplazoDevolucionesTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosReemplazoDevoluciones == null)
                    _VentasProductosReemplazoDevoluciones = new VentasProductosReemplazoDevolucionesTableAdapter();
                return _VentasProductosReemplazoDevoluciones;
            }
        }

        public VentasProductosReemplazoDevolucionesCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaProductoReemplazoDevolucion(int NumeroAgencia, string CodigoEstadoReemplazoDevo, int CodigoUsuario, DateTime FechaHoraSolicitudReemDevo, string ObservacionesReemDevo, int NumeroReemplazo)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDevolucionesDataTable VentasProductosReemplazoDevoluciones = new CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDevolucionesDataTable();
            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDevolucionesRow VentaProductoReemplazoDevolucion = VentasProductosReemplazoDevoluciones.NewVentasProductosReemplazoDevolucionesRow();

            VentaProductoReemplazoDevolucion.NumeroAgencia = NumeroAgencia;
            VentaProductoReemplazoDevolucion.CodigoEstadoReemplazoDevo = CodigoEstadoReemplazoDevo;
            VentaProductoReemplazoDevolucion.CodigoUsuario = CodigoUsuario;
            VentaProductoReemplazoDevolucion.FechaHoraSolicitudReemDevo = FechaHoraSolicitudReemDevo;
            if (ObservacionesReemDevo == null) VentaProductoReemplazoDevolucion.SetObservacionesReemDevoNull();
            else VentaProductoReemplazoDevolucion.ObservacionesReemDevo = ObservacionesReemDevo;
            VentaProductoReemplazoDevolucion.NumeroReemplazo = NumeroReemplazo;

            VentasProductosReemplazoDevoluciones.AddVentasProductosReemplazoDevolucionesRow(VentaProductoReemplazoDevolucion);

            int rowsAffected = Adapter.Update(VentasProductosReemplazoDevoluciones);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaProductoReemplazoDevolucion(int NumeroAgencia, int NumeroVentaProductosReemDevo, string CodigoEstadoReemplazoDevo, int CodigoUsuario, DateTime FechaHoraSolicitudReemDevo, string ObservacionesReemDevo)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDevolucionesDataTable VentasProductosReemplazoDevoluciones = Adapter.GetDataBy(NumeroAgencia, NumeroVentaProductosReemDevo);
            if (VentasProductosReemplazoDevoluciones.Count == 0)
                return false;

            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDevolucionesRow VentaProductoReemplazoDevolucion = VentasProductosReemplazoDevoluciones[0];

            VentaProductoReemplazoDevolucion.CodigoEstadoReemplazoDevo = CodigoEstadoReemplazoDevo;                        
            VentaProductoReemplazoDevolucion.CodigoUsuario = CodigoUsuario;
            VentaProductoReemplazoDevolucion.FechaHoraSolicitudReemDevo = FechaHoraSolicitudReemDevo;
            if (ObservacionesReemDevo == null) VentaProductoReemplazoDevolucion.SetObservacionesReemDevoNull();
            else VentaProductoReemplazoDevolucion.ObservacionesReemDevo = ObservacionesReemDevo;

            int rowsAffected = Adapter.Update(VentaProductoReemplazoDevolucion);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaProductoReemplazoDevolucion(int NumeroAgencia, int NumeroVentaProductosReemDevo)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroVentaProductosReemDevo);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosReemplazoDevoluciones(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public DSCapataz.VentasProductosDevolucionesDataTable ObtenerVentaProductoReemDevo(int CodigoVentaProductoReemDevo)
        public DataTable ObtenerVentaProductoReemplazoDevolucion(int NumeroAgencia, int NumeroVentaProductosReemDevo)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroVentaProductosReemDevo);
        }

        public DataTable ObtenerVentaProductoReemplazoDevolucion(int NumeroAgencia, int NumeroVentaProductosReemDevo, int NumeroReemplazo)
        {
            return Adapter.GetDataBy1(NumeroAgencia, NumeroVentaProductosReemDevo, NumeroReemplazo);
        }
        
        public void FinalizarAnularVentasProductosReemplazoDevolucion(int NumeroAgencia, int NumeroVentaproductoReemDevo, string CodigoEstadoReemDevo, DateTime FechaHoraReemDevo)
        {
            new FuncionesGestionComercial().FinalizarAnularVentasProductosReemplazoDevolucion(NumeroAgencia, NumeroVentaproductoReemDevo, CodigoEstadoReemDevo, FechaHoraReemDevo);
        }


        /// <summary>
        /// Realiza un Listado de todos los productos Devueltos que pueden ser seleccionados
        /// para ser reemplazod por el listado incluido de productos Reemplazo que
        /// pertenecen a un reemplazo, su uso general es para los ListBox para que el usuario
        /// seleccione cada producto devuelto y reemplazo y cree su correspondiente
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroDevolucion"></param>
        /// <param name="NumeroReemplazo"></param>
        /// <returns></returns>
        public DataTable ObtenerProductosDevolucionesDisponbiles(int NumeroAgencia, int NumeroDevolucion, int NumeroReemplazo)
        {
            if(ProductosDevoReemDisponibles == null)
                ProductosDevoReemDisponibles = ProductosDevolucionesDisponiblesAdapter.GetData(NumeroAgencia, NumeroDevolucion, NumeroReemplazo);

            DataTable TemporalDevolucion = ProductosDevoReemDisponibles.Clone();
            foreach (DataRow productoDevolucion in ProductosDevoReemDisponibles.Rows)
            {
                if (productoDevolucion["TipoTransaccion"].Equals("D"))
                {
                    DataRow filaNueva = TemporalDevolucion.NewRow();
                    filaNueva[0] = productoDevolucion[0];
                    filaNueva[1] = productoDevolucion[1];
                    filaNueva[2] = productoDevolucion[2];
                    filaNueva[3] = productoDevolucion[3];
                    TemporalDevolucion.Rows.Add(filaNueva);
                    filaNueva.AcceptChanges();
                }
            }

            TemporalDevolucion.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = TemporalDevolucion.Columns["CodigoProducto"];
            TemporalDevolucion.PrimaryKey = PrimaryKeyColumns;
            return TemporalDevolucion;
        }

        public DataTable ObtenerProductosReemplazosDisponbiles(int NumeroAgencia, int NumeroDevolucion, int NumeroReemplazo)
        {
            if(ProductosDevoReemDisponibles == null)
                ProductosDevoReemDisponibles = ProductosDevolucionesDisponiblesAdapter.GetData(NumeroAgencia, NumeroDevolucion, NumeroReemplazo);
            DataTable TemporalReemplazo = ProductosDevoReemDisponibles.Clone();
            foreach (DataRow productoReemplazo in ProductosDevoReemDisponibles.Rows)
            {
                if (productoReemplazo["TipoTransaccion"].Equals("R"))
                {
                    DataRow filaNueva = TemporalReemplazo.NewRow();
                    filaNueva[0] = productoReemplazo[0];
                    filaNueva[1] = productoReemplazo[1];
                    filaNueva[2] = productoReemplazo[2];
                    filaNueva[3] = productoReemplazo[3];
                    TemporalReemplazo.Rows.Add(filaNueva);
                    filaNueva.AcceptChanges();
                }
            }
            TemporalReemplazo.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = TemporalReemplazo.Columns["CodigoProducto"];
            TemporalReemplazo.PrimaryKey = PrimaryKeyColumns;
            return TemporalReemplazo;
        }

        public DataTable ListadoVentasProductosDevolucionesReemplazoReporte(int NumeroAgencia, int NumeroVentaReemDevo)
        {
            return new ReporteVentasProductosReemplazoDevolucionTableAdapter().GetData(NumeroAgencia, NumeroVentaReemDevo);
        }
    }
}
