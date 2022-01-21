using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercial2TableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.GestionComercial
{
    public class VentasServiciosDetalleCLN
    {
        private VentasServiciosDetalleTableAdapter _VentasServiciosDetalleAdapter = null;
        protected VentasServiciosDetalleTableAdapter Adapter
        {
            get
            {
                if (_VentasServiciosDetalleAdapter == null)
                    _VentasServiciosDetalleAdapter = new VentasServiciosDetalleTableAdapter();
                return _VentasServiciosDetalleAdapter;
            }
        }

        public VentasServiciosDetalleCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaServicioDetalle(int NumeroAgencia, int NumeroVentaServicio, int CodigoServicio, int CantidadVentaServicio, decimal PrecioUnitario, int TiempoGarantiaDias)
        {
            DSDoblones20GestionComercial2.VentasServiciosDetalleDataTable VentasServiciosDetalle = new DSDoblones20GestionComercial2.VentasServiciosDetalleDataTable();
            DSDoblones20GestionComercial2.VentasServiciosDetalleRow VentaServicioDetalle = VentasServiciosDetalle.NewVentasServiciosDetalleRow();

            VentaServicioDetalle.NumeroAgencia = NumeroAgencia;
            VentaServicioDetalle.NumeroVentaServicio = NumeroVentaServicio;
            VentaServicioDetalle.CodigoServicio = CodigoServicio;
            VentaServicioDetalle.CantidadVentaServicio = CantidadVentaServicio;
            VentaServicioDetalle.PrecioUnitario = PrecioUnitario;
            VentaServicioDetalle.TiempoGarantiaDias = TiempoGarantiaDias;
            
            VentasServiciosDetalle.AddVentasServiciosDetalleRow(VentaServicioDetalle);

            int rowsAffected = Adapter.Update(VentasServiciosDetalle);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaServicioDetalle(int NumeroAgencia, int NumeroVentaServicio, int CodigoServicio, int CantidadVentaServicio, decimal PrecioUnitario, int TiempoGarantiaDias)
        {
            DSDoblones20GestionComercial2.VentasServiciosDetalleDataTable VentasServiciosDetalle = Adapter.GetDataBy(NumeroAgencia, NumeroVentaServicio, CodigoServicio);
            if (VentasServiciosDetalle.Count == 0)
                return false;

            DSDoblones20GestionComercial2.VentasServiciosDetalleRow VentaServicioDetalle = VentasServiciosDetalle[0];

            VentaServicioDetalle.NumeroAgencia = NumeroAgencia;
            VentaServicioDetalle.NumeroVentaServicio = NumeroVentaServicio;
            VentaServicioDetalle.CodigoServicio = CodigoServicio;
            VentaServicioDetalle.CantidadVentaServicio = CantidadVentaServicio;
            VentaServicioDetalle.PrecioUnitario = PrecioUnitario;
            VentaServicioDetalle.TiempoGarantiaDias = TiempoGarantiaDias;
            
        
            int rowsAffected = Adapter.Update(VentaServicioDetalle);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaServicioDetalle(int NumeroAgencia, int NumeroVentaServicio, int CodigoServicio)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroVentaServicio, CodigoServicio);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.VentasServiciosDetalleDataTable ListarVentasServiciosDetalle()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.VentasServiciosDetalleDataTable ObtenerVentaServicioDetalle(int NumeroAgencia, int NumeroVentaServicio, int CodigoServicio)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroVentaServicio, CodigoServicio);
        }

        public DSDoblones20GestionComercial2.VentasServiciosDetalleDataTable ListarVentaServicioDetalleParaMostrar(int NumeroAgencia, int NumeroVentaServicio)
        {
            return Adapter.GetDataByParaMostrar(NumeroAgencia, NumeroVentaServicio);
        }
    }
}
