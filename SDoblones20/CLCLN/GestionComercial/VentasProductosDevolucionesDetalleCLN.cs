using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using System.Data;

namespace CLCLN.GestionComercial
{
    public class VentasProductosDevolucionesDetalleCLN
    {
        private VentasProductosDevolucionesDetalleTableAdapter _VentasProductosDevoluciones = null;
        protected VentasProductosDevolucionesDetalleTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosDevoluciones == null)
                    _VentasProductosDevoluciones = new VentasProductosDevolucionesDetalleTableAdapter();
                return _VentasProductosDevoluciones;
            }
        }

        public VentasProductosDevolucionesDetalleCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaProductoDevolucionDetalle(int NumeroAgencia, int NumeroDevolucion, int CodigoMotivoReemDevo, string CodigoProducto, int CantidadDevuelta, decimal PrecioUnitarioDevolucion)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesDetalleDataTable VentasProductosDevolucionesDetalle = new CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesDetalleDataTable();
            CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesDetalleRow VentaProductoDevolucionDetalle = VentasProductosDevolucionesDetalle.NewVentasProductosDevolucionesDetalleRow();

            VentaProductoDevolucionDetalle.NumeroAgencia = NumeroAgencia;
            VentaProductoDevolucionDetalle.NumeroDevolucion = NumeroDevolucion;
            VentaProductoDevolucionDetalle.CodigoMotivoReemDevo = CodigoMotivoReemDevo;
            VentaProductoDevolucionDetalle.CodigoProducto = CodigoProducto;
            VentaProductoDevolucionDetalle.CantidadDevuelta = CantidadDevuelta;
            VentaProductoDevolucionDetalle.PrecioUnitarioDevolucion = PrecioUnitarioDevolucion;

            VentasProductosDevolucionesDetalle.AddVentasProductosDevolucionesDetalleRow(VentaProductoDevolucionDetalle);

            int rowsAffected = Adapter.Update(VentasProductosDevolucionesDetalle);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaProductoDevolucionDetalle(int NumeroAgencia, int NumeroDevolucion, int CodigoMotivoReemDevo, string CodigoProducto, int CantidadDevuelta, decimal PrecioUnitarioDevolucion)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesDetalleDataTable VentasProductosDevolucionesDetalle = Adapter.GetDataBy(NumeroAgencia, NumeroDevolucion, CodigoProducto);
            if (VentasProductosDevolucionesDetalle.Count == 0)
                return false;

            CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesDetalleRow VentaProductoDevolucionDetalle = VentasProductosDevolucionesDetalle[0];


            VentaProductoDevolucionDetalle.CodigoMotivoReemDevo = CodigoMotivoReemDevo;            
            VentaProductoDevolucionDetalle.CantidadDevuelta = CantidadDevuelta;
            VentaProductoDevolucionDetalle.PrecioUnitarioDevolucion = PrecioUnitarioDevolucion;

            int rowsAffected = Adapter.Update(VentaProductoDevolucionDetalle);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaProductoDevolucionDetalle(int NumeroAgencia, int NumeroDevolucion, string CodigoProducto)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroDevolucion, CodigoProducto);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosDevolucionesDetalle(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]        
        public DataTable ObtenerVentaProductoDevolucionDetalle(int NumeroAgencia, int NumeroDevolucion, string CodigoProducto)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroDevolucion, CodigoProducto);
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosDevolucionesParaDevolucion(int NumeroAgencia, int NumeroDevolucion)
        {
            ListarVentasProductosDevolucionesParaDevolucionTableAdapter AdapterAux = new ListarVentasProductosDevolucionesParaDevolucionTableAdapter();
            return AdapterAux.GetData(NumeroAgencia, NumeroDevolucion);
        }
    }
}
