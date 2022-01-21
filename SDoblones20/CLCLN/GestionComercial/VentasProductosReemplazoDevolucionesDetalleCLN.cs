using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using System.Data;

namespace CLCLN.GestionComercial
{
    public class VentasProductosReemplazoDevolucionesDetalleCLN
    {
        private VentasProductosReemplazoDevolucionesDetalleTableAdapter _VentasProductosReemplazoDevolucionesDetalle = null;
        protected VentasProductosReemplazoDevolucionesDetalleTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosReemplazoDevolucionesDetalle == null)
                    _VentasProductosReemplazoDevolucionesDetalle = new VentasProductosReemplazoDevolucionesDetalleTableAdapter();
                return _VentasProductosReemplazoDevolucionesDetalle;
            }
        }

        public VentasProductosReemplazoDevolucionesDetalleCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaProductoReemplazoDevolucionDetalle(int NumeroAgencia, int NumeroVentaProductosReemDevo, int NumeroAgenciaDevolucion, int NumeroDevolucion, string CodigoProductoDevolucion, decimal MontoTotalDevolucion, int NumeroAgenciaReemplazo, int NumeroReemplazo, string CodigoProductoReemplazo, decimal MontoTotalReemplazo)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDevolucionesDetalleDataTable VentasProductosReemplazoDevolucionesDetalle = new CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDevolucionesDetalleDataTable();
            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDevolucionesDetalleRow VentaProductoReemplazoDevolucionDetalle = VentasProductosReemplazoDevolucionesDetalle.NewVentasProductosReemplazoDevolucionesDetalleRow();

            VentaProductoReemplazoDevolucionDetalle.NumeroAgencia = NumeroAgencia;
            VentaProductoReemplazoDevolucionDetalle.NumeroVentaProductosReemDevo = NumeroVentaProductosReemDevo;
            VentaProductoReemplazoDevolucionDetalle.NumeroAgenciaDevolucion = NumeroAgenciaDevolucion;
            VentaProductoReemplazoDevolucionDetalle.NumeroDevolucion = NumeroDevolucion;
            VentaProductoReemplazoDevolucionDetalle.CodigoProductoDevolucion = CodigoProductoDevolucion;
            VentaProductoReemplazoDevolucionDetalle.MontoTotalDevolucion = MontoTotalDevolucion;
            VentaProductoReemplazoDevolucionDetalle.NumeroAgenciaReemplazo = NumeroAgenciaReemplazo;
            VentaProductoReemplazoDevolucionDetalle.NumeroReemplazo = NumeroReemplazo;
            VentaProductoReemplazoDevolucionDetalle.CodigoProductoReemplazo = CodigoProductoReemplazo;
            VentaProductoReemplazoDevolucionDetalle.MontoTotalReemplazo = MontoTotalReemplazo;

            VentasProductosReemplazoDevolucionesDetalle.AddVentasProductosReemplazoDevolucionesDetalleRow(VentaProductoReemplazoDevolucionDetalle);

            int rowsAffected = Adapter.Update(VentasProductosReemplazoDevolucionesDetalle);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaProductoReemplazoDevolucionDetalle(int NumeroAgencia, int NumeroVentaProductosReemDevo, int NumeroAgenciaDevolucion, int NumeroDevolucion, string CodigoProductoDevolucion, decimal MontoTotalDevolucion, int NumeroAgenciaReemplazo, int NumeroReemplazo, string CodigoProductoReemplazo, decimal MontoTotalReemplazo)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDevolucionesDetalleDataTable VentasProductosReemplazoDevolucionesDetalle = Adapter.GetDataBy(NumeroAgencia, NumeroVentaProductosReemDevo,NumeroAgenciaDevolucion,NumeroDevolucion,CodigoProductoDevolucion,NumeroAgenciaReemplazo,NumeroReemplazo,CodigoProductoReemplazo);
            if (VentasProductosReemplazoDevolucionesDetalle.Count == 0)
                return false;

            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDevolucionesDetalleRow VentaProductoReemplazoDevolucionDetalle = VentasProductosReemplazoDevolucionesDetalle[0];


            VentaProductoReemplazoDevolucionDetalle.MontoTotalDevolucion = MontoTotalDevolucion;            
            VentaProductoReemplazoDevolucionDetalle.MontoTotalReemplazo = MontoTotalReemplazo;

            int rowsAffected = Adapter.Update(VentaProductoReemplazoDevolucionDetalle);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaProductoReemplazoDevolucionDetalle(int NumeroAgencia, int NumeroVentaProductosReemDevo, int NumeroAgenciaDevolucion, int NumeroDevolucion, string CodigoProductoDevolucion,  int NumeroAgenciaReemplazo, int NumeroReemplazo, string CodigoProductoReemplazo)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroVentaProductosReemDevo, NumeroAgenciaDevolucion, NumeroDevolucion, CodigoProductoDevolucion, NumeroAgenciaReemplazo, NumeroReemplazo, CodigoProductoReemplazo);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosReemplazoDevolucionesDetalle(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]        
        public DataTable ObtenerVentaProductoReemplazoDevolucionDetalle(int NumeroAgencia, int NumeroVentaProductosReemDevo, int NumeroAgenciaDevolucion, int NumeroDevolucion, string CodigoProductoDevolucion, int NumeroAgenciaReemplazo, int NumeroReemplazo, string CodigoProductoReemplazo)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroVentaProductosReemDevo, NumeroAgenciaDevolucion, NumeroDevolucion, CodigoProductoDevolucion, NumeroAgenciaReemplazo, NumeroReemplazo, CodigoProductoReemplazo);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosReemplazoDevolucionesDetalleParaReemplazoDevoluciones(int NumeroAgencia, int NumeroVentaProductosReemDevo)
        {
            ListarVentasProductosReemplazoDevolucionesDetalleParaReemplazoDevolucionesTableAdapter AdapterAux = new ListarVentasProductosReemplazoDevolucionesDetalleParaReemplazoDevolucionesTableAdapter();
            return AdapterAux.GetData(NumeroAgencia, NumeroVentaProductosReemDevo);
        }

        public DataTable ListarVentasProductosDevolucionesReemplazoDetalleReporte(int NumeroAgencia, int NumeroVentaProductosReemDevo)
        {
            return new ReporteVentasProductosDevolucionesReemplazoTableAdapter().GetData(NumeroAgencia, NumeroVentaProductosReemDevo);
        }

    }
}
