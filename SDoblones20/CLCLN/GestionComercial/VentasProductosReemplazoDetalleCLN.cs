using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using System.Data;

namespace CLCLN.GestionComercial
{
    public class VentasProductosReemplazoDetalleCLN
    {
        private VentasProductosReemplazoDetalleTableAdapter _VentasProductosReemplazoDetalle = null;
        protected VentasProductosReemplazoDetalleTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosReemplazoDetalle == null)
                    _VentasProductosReemplazoDetalle = new VentasProductosReemplazoDetalleTableAdapter();
                return _VentasProductosReemplazoDetalle;
            }
        }

        public VentasProductosReemplazoDetalleCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaProductoReemplazoDetalle(int NumeroAgencia, int NumeroReemplazo, string CodigoProducto, int CantidadDevuelta, decimal PrecioUnitarioReemplazo, int TiempoGarantia, DateTime FechaHoraVencimiento)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDetalleDataTable VentasProductosReemplazoDetalle = new CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDetalleDataTable();
            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDetalleRow VentaProductoReemplazoDetalle = VentasProductosReemplazoDetalle.NewVentasProductosReemplazoDetalleRow();

            VentaProductoReemplazoDetalle.NumeroAgencia = NumeroAgencia;
            VentaProductoReemplazoDetalle.NumeroReemplazo = NumeroReemplazo;
            VentaProductoReemplazoDetalle.CodigoProducto = CodigoProducto;
            VentaProductoReemplazoDetalle.CantidadDevuelta = CantidadDevuelta;
            VentaProductoReemplazoDetalle.PrecioUnitarioReemplazo = PrecioUnitarioReemplazo;
            if (TiempoGarantia == null) VentaProductoReemplazoDetalle.SetTiempoGarantiaNull();
            else VentaProductoReemplazoDetalle.TiempoGarantia = TiempoGarantia;
            if (FechaHoraVencimiento == null) VentaProductoReemplazoDetalle.SetFechaHoraVencimientoNull();
            else VentaProductoReemplazoDetalle.FechaHoraVencimiento = FechaHoraVencimiento;

            VentasProductosReemplazoDetalle.AddVentasProductosReemplazoDetalleRow(VentaProductoReemplazoDetalle);

            int rowsAffected = Adapter.Update(VentasProductosReemplazoDetalle);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaProductoReemplazoDetalle(int NumeroAgencia, int NumeroReemplazo, string CodigoProducto, int CantidadDevuelta, decimal PrecioUnitarioReemplazo, int TiempoGarantia, DateTime FechaHoraVencimiento)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDetalleDataTable VentasProductosReemplazoDetalle = Adapter.GetDataBy(NumeroAgencia, NumeroReemplazo,CodigoProducto);
            if (VentasProductosReemplazoDetalle.Count == 0)
                return false;

            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoDetalleRow VentaProductoReemplazoDetalle = VentasProductosReemplazoDetalle[0];
            
            VentaProductoReemplazoDetalle.CantidadDevuelta = CantidadDevuelta;
            VentaProductoReemplazoDetalle.PrecioUnitarioReemplazo = PrecioUnitarioReemplazo;
            if (TiempoGarantia == null) VentaProductoReemplazoDetalle.SetTiempoGarantiaNull();
            else VentaProductoReemplazoDetalle.TiempoGarantia = TiempoGarantia;
            if (FechaHoraVencimiento == null) VentaProductoReemplazoDetalle.SetFechaHoraVencimientoNull();
            else VentaProductoReemplazoDetalle.FechaHoraVencimiento = FechaHoraVencimiento;

            int rowsAffected = Adapter.Update(VentaProductoReemplazoDetalle);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaProductoReemplazoDetalle(int NumeroAgencia, int NumeroReemplazo, string CodigoProducto)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroReemplazo, CodigoProducto);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosReemplazoDetalle(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public DSCapataz.VentasProductosDevolucionesDataTable ObtenerVentaProductoReemDevo(int CodigoVentaProductoReemDevo)
        public DataTable ObtenerVentaProductoReemplazoDetalle(int NumeroAgencia, int NumeroReemplazo, string CodigoProducto)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroReemplazo, CodigoProducto);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public DSCapataz.VentasProductosDevolucionesDataTable ObtenerVentaProductoReemDevo(int CodigoVentaProductoReemDevo)
        public DataTable ListarVentasProductosReemplazoDetalleParaReemplazo(int NumeroAgencia, int NumeroReemplazo)
        {
            ListarVentasProductosReemplazoDetalleParaReemplazoTableAdapter AdapterAux = new ListarVentasProductosReemplazoDetalleParaReemplazoTableAdapter();
            return AdapterAux.GetData(NumeroAgencia, NumeroReemplazo);
        }

    }
}
