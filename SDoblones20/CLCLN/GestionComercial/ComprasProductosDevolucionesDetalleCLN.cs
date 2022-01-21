using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using System.Data;

namespace CLCLN.GestionComercial
{
    public class ComprasProductosDevolucionesDetalleCLN
    {
        private ComprasProductosDevolucionesDetalleTableAdapter _VentasProductosDevoluciones = null;
        protected ComprasProductosDevolucionesDetalleTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosDevoluciones == null)
                    _VentasProductosDevoluciones = new ComprasProductosDevolucionesDetalleTableAdapter();
                return _VentasProductosDevoluciones;
            }
        }

        public ComprasProductosDevolucionesDetalleCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCompraProductoDevolucionDetalle(int NumeroAgencia, int NumeroDevolucion, int CodigoMotivoReemDevo, string CodigoProducto, int CantidadDevuelta, decimal PrecioUnitarioDevolucion)
        {
            CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesDetalleDataTable ComprasProductosDevolucionesDetalle = new CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesDetalleDataTable();
            CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesDetalleRow CompraProductoDevolucionDetalle = ComprasProductosDevolucionesDetalle.NewComprasProductosDevolucionesDetalleRow();

            CompraProductoDevolucionDetalle.NumeroAgencia = NumeroAgencia;
            CompraProductoDevolucionDetalle.NumeroDevolucion = NumeroDevolucion;
            CompraProductoDevolucionDetalle.CodigoMotivoReemDevo = CodigoMotivoReemDevo;
            CompraProductoDevolucionDetalle.CodigoProducto = CodigoProducto;
            CompraProductoDevolucionDetalle.CantidadDevuelta = CantidadDevuelta;
            CompraProductoDevolucionDetalle.PrecioUnitarioDevolucion = PrecioUnitarioDevolucion;

            ComprasProductosDevolucionesDetalle.AddComprasProductosDevolucionesDetalleRow(CompraProductoDevolucionDetalle);

            int rowsAffected = Adapter.Update(ComprasProductosDevolucionesDetalle);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarCompraProductoDevolucionDetalle(int NumeroAgencia, int NumeroDevolucion, int CodigoMotivoReemDevo, string CodigoProducto, int CantidadDevuelta, decimal PrecioUnitarioDevolucion)
        {
            CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesDetalleDataTable ComprasProductosDevolucionesDetalle = Adapter.GetDataBy(NumeroAgencia, NumeroDevolucion, CodigoProducto);
            if (ComprasProductosDevolucionesDetalle.Count == 0)
                return false;

            CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesDetalleRow CompraProductoDevolucionDetalle = ComprasProductosDevolucionesDetalle[0];


            CompraProductoDevolucionDetalle.CodigoMotivoReemDevo = CodigoMotivoReemDevo;            
            CompraProductoDevolucionDetalle.CantidadDevuelta = CantidadDevuelta;
            CompraProductoDevolucionDetalle.PrecioUnitarioDevolucion = PrecioUnitarioDevolucion;

            int rowsAffected = Adapter.Update(CompraProductoDevolucionDetalle);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCompraProductoDevolucionDetalle(int NumeroAgencia, int NumeroDevolucion, string CodigoProducto)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroDevolucion, CodigoProducto);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarComprasProductosDevolucionesDetalle(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]        
        public DataTable ObtenerCompraProductoDevolucionDetalle(int NumeroAgencia, int NumeroDevolucion, string CodigoProducto)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroDevolucion, CodigoProducto);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarComprasProductosDevolucionesDetalleParaDevoluciones(int NumeroAgencia, int NumeroDevolucion)
        {
            ListarComprasProductosDevolucionesDetalleParaDevolucionesTableAdapter AdapterAux = new ListarComprasProductosDevolucionesDetalleParaDevolucionesTableAdapter();
            return AdapterAux.GetData(NumeroAgencia, NumeroDevolucion);
        }

    }
}
