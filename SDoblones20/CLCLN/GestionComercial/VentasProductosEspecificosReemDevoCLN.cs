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
    public class VentasProductosEspecificosReemDevoCLN
    {
        private VentasProductosEspecificosReemDevoTableAdapter _VentasProductosEspecificosReemDevoAdapter = null;
        protected VentasProductosEspecificosReemDevoTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosEspecificosReemDevoAdapter == null)
                    _VentasProductosEspecificosReemDevoAdapter = new VentasProductosEspecificosReemDevoTableAdapter();
                return _VentasProductosEspecificosReemDevoAdapter;
            }
        }

        public VentasProductosEspecificosReemDevoCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaProductoEspecificoReemDevoCambio(int NumeroAgencia, int NumeroReemDevo, int CodigoMotivoReemDevo, string CodigoProducto, string CodigoProductoEspeDevo, string CodigoProductoEspeCambio, int? TiempoGarantiaPE, DateTime FechaHoraVencimientoPE, decimal? PrecioUnitarioPECambio, decimal? MontoDevolucion, string CodigoTipoReemDevo, DateTime FechaHoraReemDevoCambio, string ObservacionesReemDevoCambio)
        {
            DSDoblones20GestionComercial.VentasProductosEspecificosReemDevoDataTable VentasProductosEspecificosReemDevo = new DSDoblones20GestionComercial.VentasProductosEspecificosReemDevoDataTable();
            DSDoblones20GestionComercial.VentasProductosEspecificosReemDevoRow VentaProductoEspecificoReemDevoCambio = VentasProductosEspecificosReemDevo.NewVentasProductosEspecificosReemDevoRow();

            VentaProductoEspecificoReemDevoCambio.NumeroAgencia = NumeroAgencia;
            VentaProductoEspecificoReemDevoCambio.NumeroReemDevo = NumeroReemDevo;
            VentaProductoEspecificoReemDevoCambio.CodigoMotivoReemDevo = CodigoMotivoReemDevo;
            VentaProductoEspecificoReemDevoCambio.CodigoProducto = CodigoProducto;
            VentaProductoEspecificoReemDevoCambio.CodigoProductoEspeDevo = CodigoProductoEspeDevo;
            VentaProductoEspecificoReemDevoCambio.CodigoProductoEspeCambio = CodigoProductoEspeCambio;
            if (TiempoGarantiaPE == null) VentaProductoEspecificoReemDevoCambio.SetTiempoGarantiaPENull();
            else VentaProductoEspecificoReemDevoCambio.TiempoGarantiaPE = TiempoGarantiaPE.Value;
            if (FechaHoraVencimientoPE == null) VentaProductoEspecificoReemDevoCambio.SetFechaHoraVencimientoPENull();
            else VentaProductoEspecificoReemDevoCambio.FechaHoraVencimientoPE = FechaHoraVencimientoPE;
            if (PrecioUnitarioPECambio == null) VentaProductoEspecificoReemDevoCambio.SetPrecioUnitarioPECambioNull();
            else VentaProductoEspecificoReemDevoCambio.PrecioUnitarioPECambio = PrecioUnitarioPECambio.Value;
            if (MontoDevolucion == null) VentaProductoEspecificoReemDevoCambio.SetMontoDevolucionNull();
            else VentaProductoEspecificoReemDevoCambio.MontoDevolucion = MontoDevolucion.Value;
            VentaProductoEspecificoReemDevoCambio.CodigoTipoReemDevo = CodigoTipoReemDevo;
            VentaProductoEspecificoReemDevoCambio.FechaHoraReemDevoCambio = FechaHoraReemDevoCambio;
            if (ObservacionesReemDevoCambio == null) VentaProductoEspecificoReemDevoCambio.SetObservacionesReemDevoCambioNull();
            else VentaProductoEspecificoReemDevoCambio.ObservacionesReemDevoCambio = ObservacionesReemDevoCambio;

                                               
            VentasProductosEspecificosReemDevo.AddVentasProductosEspecificosReemDevoRow(VentaProductoEspecificoReemDevoCambio);

            int rowsAffected = Adapter.Update(VentasProductosEspecificosReemDevo);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarVentaProductoEspecificoReemDevoCambio(int NumeroAgencia, int NumeroReemDevo, int CodigoMotivoReemDevo, string CodigoProducto, string CodigoProductoEspeDevo, string CodigoProductoEspeCambio, int? TiempoGarantiaPE, DateTime FechaHoraVencimientoPE, decimal? PrecioUnitarioPECambio, decimal? MontoDevolucion, string CodigoTipoReemDevo, DateTime FechaHoraReemDevoCambio, string ObservacionesReemDevoCambio)
        {
            DSDoblones20GestionComercial.VentasProductosEspecificosReemDevoDataTable VentasProductosEspecificosReemDevo = Adapter.GetDataBy(NumeroAgencia, NumeroReemDevo, CodigoMotivoReemDevo, CodigoProducto, CodigoProductoEspeDevo, CodigoProductoEspeCambio);
            if (VentasProductosEspecificosReemDevo.Count == 0)
                return false;

            DSDoblones20GestionComercial.VentasProductosEspecificosReemDevoRow VentaProductoEspecificoReemDevoCambio = VentasProductosEspecificosReemDevo[0];

            if (TiempoGarantiaPE == null) VentaProductoEspecificoReemDevoCambio.SetTiempoGarantiaPENull();
            else VentaProductoEspecificoReemDevoCambio.TiempoGarantiaPE = TiempoGarantiaPE.Value;
            if (FechaHoraVencimientoPE == null) VentaProductoEspecificoReemDevoCambio.SetFechaHoraVencimientoPENull();
            else VentaProductoEspecificoReemDevoCambio.FechaHoraVencimientoPE = FechaHoraVencimientoPE;
            if (PrecioUnitarioPECambio== null) VentaProductoEspecificoReemDevoCambio.SetPrecioUnitarioPECambioNull();
            else VentaProductoEspecificoReemDevoCambio.PrecioUnitarioPECambio = PrecioUnitarioPECambio.Value;
            if (MontoDevolucion == null) VentaProductoEspecificoReemDevoCambio.SetMontoDevolucionNull();
            else VentaProductoEspecificoReemDevoCambio.MontoDevolucion = MontoDevolucion.Value;
            VentaProductoEspecificoReemDevoCambio.CodigoTipoReemDevo = CodigoTipoReemDevo;
            VentaProductoEspecificoReemDevoCambio.FechaHoraReemDevoCambio = FechaHoraReemDevoCambio;
            if (ObservacionesReemDevoCambio == null) VentaProductoEspecificoReemDevoCambio.SetObservacionesReemDevoCambioNull();
            else VentaProductoEspecificoReemDevoCambio.ObservacionesReemDevoCambio = ObservacionesReemDevoCambio;

            VentasProductosEspecificosReemDevo.AddVentasProductosEspecificosReemDevoRow(VentaProductoEspecificoReemDevoCambio);

            int rowsAffected = Adapter.Update(VentaProductoEspecificoReemDevoCambio);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaProductoEspecificoReemDevoCambio(int NumeroAgencia, int NumeroReemDevo, int CodigoMotivoReemDevo, string CodigoProducto, string CodigoProductoEspeDevo, string CodigoProductoEspeCambio)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroReemDevo, CodigoMotivoReemDevo, CodigoProducto, CodigoProductoEspeDevo, CodigoProductoEspeCambio);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosEspecificosReemDevo()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerVentaProductoEspecificoReemDevoCambio(int NumeroAgencia, int NumeroReemDevo, int CodigoMotivoReemDevo, string CodigoProducto, string CodigoProductoEspeDevo, string CodigoProductoEspeCambio)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroReemDevo, CodigoMotivoReemDevo, CodigoProducto, CodigoProductoEspeDevo, CodigoProductoEspeCambio);
        }
    }
}
