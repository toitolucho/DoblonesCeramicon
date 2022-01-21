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
    public class VentasProductosEspecificosAgregadosCLN
    {
        private VentasProductosEspecificosAgregadosTableAdapter _VentasProductosEspecificosAgregadosAdapter = null;
        protected VentasProductosEspecificosAgregadosTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosEspecificosAgregadosAdapter == null)
                    _VentasProductosEspecificosAgregadosAdapter = new VentasProductosEspecificosAgregadosTableAdapter();
                return _VentasProductosEspecificosAgregadosAdapter;
            }
        }

        public VentasProductosEspecificosAgregadosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaProductoEspecificoAgregado(int NumeroAgencia, int NumeroVentaProducto, string CodigoProducto, string CodigoProductoEspecifico, string CodigoTipoAgregado,int? TiempoGarantiaPE, DateTime? FechaHoraVencimientoPE, decimal PrecioUnitario)
        {
            DSDoblones20GestionComercial.VentasProductosEspecificosAgregadosDataTable VentasProductosEspecificosAgregados = new DSDoblones20GestionComercial.VentasProductosEspecificosAgregadosDataTable();
            DSDoblones20GestionComercial.VentasProductosEspecificosAgregadosRow VentaProductoEspecificoAgregado = VentasProductosEspecificosAgregados.NewVentasProductosEspecificosAgregadosRow();

            VentaProductoEspecificoAgregado.NumeroAgencia = NumeroAgencia;
            VentaProductoEspecificoAgregado.NumeroVentaProducto = NumeroVentaProducto;
            VentaProductoEspecificoAgregado.CodigoProducto = CodigoProducto;
            if (CodigoProductoEspecifico == null) VentaProductoEspecificoAgregado.SetCodigoProductoEspecificoNull();
            else VentaProductoEspecificoAgregado.CodigoProductoEspecifico = CodigoProductoEspecifico;
            VentaProductoEspecificoAgregado.CodigoTipoAgregado = CodigoTipoAgregado;
            VentaProductoEspecificoAgregado.CodigoProductoEspecifico = CodigoProductoEspecifico;
            if (TiempoGarantiaPE == null) VentaProductoEspecificoAgregado.SetTiempoGarantiaPENull();
            else VentaProductoEspecificoAgregado.TiempoGarantiaPE = TiempoGarantiaPE.Value;
            if (FechaHoraVencimientoPE == null) VentaProductoEspecificoAgregado.SetFechaHoraVencimientoPENull();
            else VentaProductoEspecificoAgregado.FechaHoraVencimientoPE = FechaHoraVencimientoPE.Value;
            VentaProductoEspecificoAgregado.PrecioUnitario = PrecioUnitario;

            VentasProductosEspecificosAgregados.AddVentasProductosEspecificosAgregadosRow(VentaProductoEspecificoAgregado);

            int rowsAffected = Adapter.Update(VentasProductosEspecificosAgregados);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaProductoEspecificoAgregado(int NumeroAgencia, int NumeroVentaProducto, string CodigoProducto, string CodigoProductoEspecifico, string CodigoTipoAgregado,int? TiempoGarantiaPE, DateTime? FechaHoraVencimientoPE, decimal PrecioUnitario)
        {
            DSDoblones20GestionComercial.VentasProductosEspecificosAgregadosDataTable VentasProductosEspecificosAgregados = Adapter.GetDataBy(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoProductoEspecifico);
            if (VentasProductosEspecificosAgregados.Count == 0)
                return false;

            DSDoblones20GestionComercial.VentasProductosEspecificosAgregadosRow VentaProductoEspecificoAgregado = VentasProductosEspecificosAgregados[0];

            if (CodigoProductoEspecifico == null) VentaProductoEspecificoAgregado.SetCodigoProductoEspecificoNull();
            else VentaProductoEspecificoAgregado.CodigoProductoEspecifico = CodigoProductoEspecifico;
            VentaProductoEspecificoAgregado.CodigoTipoAgregado = CodigoTipoAgregado;
            VentaProductoEspecificoAgregado.CodigoProductoEspecifico = CodigoProductoEspecifico;
            if (TiempoGarantiaPE == null) VentaProductoEspecificoAgregado.SetTiempoGarantiaPENull();
            else VentaProductoEspecificoAgregado.TiempoGarantiaPE = TiempoGarantiaPE.Value;
            if (FechaHoraVencimientoPE == null) VentaProductoEspecificoAgregado.SetFechaHoraVencimientoPENull();
            else VentaProductoEspecificoAgregado.FechaHoraVencimientoPE = FechaHoraVencimientoPE.Value;
            VentaProductoEspecificoAgregado.PrecioUnitario = PrecioUnitario;            

            int rowsAffected = Adapter.Update(VentaProductoEspecificoAgregado);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaProductoEspecificoAgregado(int NumeroAgencia, int NumeroVentaProducto, string CodigoProducto, string CodigoTipoAgregado)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoTipoAgregado);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosEspecificosAgregados(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia);
        }

        /// <summary>
        /// Realiza el listado de los Productos que fueron Vendidos como Productos Especificos
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="NumeroVenta"> Número de Venta</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosEspecificosAgregadosParaVenta(int NumeroAgencia, int NumeroVenta)
        {
            return new ListarVentasProductosEspecificosAgregadosParaVentaTableAdapter().GetData(NumeroAgencia, NumeroVenta);
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerVentaProductoEspecificoAgregado(int NumeroAgencia, int NumeroVentaProducto, string CodigoProducto, string CodigoTipoAgregado)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoTipoAgregado);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosEspecificosAgregadosReportes(int NumeroAgencia, int NumeroVentaProducto)
        {
            return new VentaProductoEspecificoAgregadoReporteTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto);
        }
    }
}
