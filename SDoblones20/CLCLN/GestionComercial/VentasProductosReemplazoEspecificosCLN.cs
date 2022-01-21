using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using System.Data;

namespace CLCLN.GestionComercial
{
    public class VentasProductosReemplazoEspecificosCLN
    {
        private VentasProductosReemplazoEspecificosTableAdapter _VentasProductosDevoluciones = null;
        protected VentasProductosReemplazoEspecificosTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosDevoluciones == null)
                    _VentasProductosDevoluciones = new VentasProductosReemplazoEspecificosTableAdapter();
                return _VentasProductosDevoluciones;
            }
        }

        public VentasProductosReemplazoEspecificosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaProductoReemplazoEspecifico(int NumeroAgencia, int NumeroReemplazo, string CodigoProducto, string CodigoProductoEspecifico, decimal PrecioUnitarioReemplazoPE, int TiempoGarantiaPE, DateTime FechaHoraVencimientoPE)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoEspecificosDataTable VentasProductosReemplazoEspecificos = new CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoEspecificosDataTable();
            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoEspecificosRow VentaProductoReemplazoEspecifico = VentasProductosReemplazoEspecificos.NewVentasProductosReemplazoEspecificosRow();

            VentaProductoReemplazoEspecifico.NumeroAgencia = NumeroAgencia;
            VentaProductoReemplazoEspecifico.NumeroReemplazo = NumeroReemplazo;
            VentaProductoReemplazoEspecifico.CodigoProducto = CodigoProducto;
            VentaProductoReemplazoEspecifico.CodigoProductoEspecifico = CodigoProductoEspecifico;
            VentaProductoReemplazoEspecifico.PrecioUnitarioReemplazoPE = PrecioUnitarioReemplazoPE;

            if (TiempoGarantiaPE == null) VentaProductoReemplazoEspecifico.SetTiempoGarantiaPENull();
            else VentaProductoReemplazoEspecifico.TiempoGarantiaPE = TiempoGarantiaPE;

            if (FechaHoraVencimientoPE == null) VentaProductoReemplazoEspecifico.SetFechaHoraVencimientoPENull();
            else VentaProductoReemplazoEspecifico.FechaHoraVencimientoPE = FechaHoraVencimientoPE;


            VentasProductosReemplazoEspecificos.AddVentasProductosReemplazoEspecificosRow(VentaProductoReemplazoEspecifico);

            int rowsAffected = Adapter.Update(VentasProductosReemplazoEspecificos);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaProductoReemplazoEspecifico(int NumeroAgencia, int NumeroReemplazo, string CodigoProducto, string CodigoProductoEspecifico, decimal PrecioUnitarioReemplazoPE, int TiempoGarantiaPE, DateTime FechaHoraVencimientoPE)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoEspecificosDataTable VentasProductosReemplazoEspecificos = Adapter.GetDataBy(NumeroAgencia, NumeroReemplazo, CodigoProducto, CodigoProductoEspecifico);
            if (VentasProductosReemplazoEspecificos.Count == 0)
                return false;

            CLCAD.DSDoblones20GestionComercial.VentasProductosReemplazoEspecificosRow VentaProductoReemplazoEspecifico = VentasProductosReemplazoEspecificos[0];


            VentaProductoReemplazoEspecifico.PrecioUnitarioReemplazoPE = PrecioUnitarioReemplazoPE;

            if (TiempoGarantiaPE == null) VentaProductoReemplazoEspecifico.SetTiempoGarantiaPENull();
            else VentaProductoReemplazoEspecifico.TiempoGarantiaPE = TiempoGarantiaPE;

            if (FechaHoraVencimientoPE == null) VentaProductoReemplazoEspecifico.SetFechaHoraVencimientoPENull();
            else VentaProductoReemplazoEspecifico.FechaHoraVencimientoPE = FechaHoraVencimientoPE;

            int rowsAffected = Adapter.Update(VentaProductoReemplazoEspecifico);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaProductoReemplazoEspecifico(int NumeroAgencia, int NumeroReemplazo, string CodigoProducto, string CodigoProductoEspecifico)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroReemplazo, CodigoProducto, CodigoProductoEspecifico);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosReemplazoEspecificos(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public DSCapataz.VentasProductosDevolucionesDataTable ObtenerVentaProductoReemDevo(int CodigoVentaProductoReemDevo)
        public DataTable ObtenerVentaProductoReemplazoEspecifico(int NumeroAgencia, int NumeroReemplazo, string CodigoProducto, string CodigoProductoEspecifico)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroReemplazo, CodigoProducto, CodigoProductoEspecifico);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public DSCapataz.VentasProductosDevolucionesDataTable ObtenerVentaProductoReemDevo(int CodigoVentaProductoReemDevo)
        public DataTable ListarVentasProductosReemplazoEspecificosParaReemplazo(int NumeroAgencia, int NumeroReemplazo)
        {
            ListarVentasProductosReemplazoEspecificosParaReemplazoTableAdapter AdapterAux = new ListarVentasProductosReemplazoEspecificosParaReemplazoTableAdapter();
            return AdapterAux.GetData(NumeroAgencia, NumeroReemplazo);
        }

    }
}
