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
    public class ComprasProductosEspecificosAgregadosCLN
    {
        #region Atributos de la Clase
        private ComprasProductosEspecificosAgregadosTableAdapter _ComprasProductosEspecificosAgregadosAdapter = null;
        protected ComprasProductosEspecificosAgregadosTableAdapter Adapter
        {
            get
            {
                if (_ComprasProductosEspecificosAgregadosAdapter == null)
                    _ComprasProductosEspecificosAgregadosAdapter = new ComprasProductosEspecificosAgregadosTableAdapter();
                return _ComprasProductosEspecificosAgregadosAdapter;
            }
        }
        #endregion

        #region Constructor
        public ComprasProductosEspecificosAgregadosCLN()
        {
            //constructor
        }

        #endregion


        /// <summary>
        /// Compra de productos Especificos Agregados, ya sean los mismos por promocion, regalo, adjutamiento, etc
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroCompraProducto"></param>
        /// <param name="CodigoProducto"></param>
        /// <param name="CodigoTipoAgregado"></param>
        /// <param name="TiempoGarantiaPE"></param>
        /// <param name="FechaHoraVencimientoPE"></param>
        /// <param name="CargarAInventario"></param>
        /// <param name="PrecioUnitario"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCompraProductoEspecificoAgregado(int NumeroAgencia,int NumeroCompraProducto,string CodigoProducto,string CodigoProductoEspecifico, string CodigoTipoAgregado, int? TiempoGarantiaPE, DateTime? FechaHoraVencimientoPE, bool CargarAInventario, decimal PrecioUnitario)
        {
            DSDoblones20GestionComercial.ComprasProductosEspecificosAgregadosDataTable ComprasProductosEspecificosAgregados = new DSDoblones20GestionComercial.ComprasProductosEspecificosAgregadosDataTable();
            DSDoblones20GestionComercial.ComprasProductosEspecificosAgregadosRow compraProductoEspecificoAgregado = ComprasProductosEspecificosAgregados.NewComprasProductosEspecificosAgregadosRow();

            compraProductoEspecificoAgregado.NumeroAgencia = NumeroAgencia;
            compraProductoEspecificoAgregado.NumeroCompraProducto = NumeroCompraProducto;
            compraProductoEspecificoAgregado.CodigoProducto = CodigoProducto;
            if(CodigoProductoEspecifico == null) compraProductoEspecificoAgregado.SetCodigoProductoEspecificoNull();
            else compraProductoEspecificoAgregado.CodigoTipoAgregado = CodigoTipoAgregado;    
            compraProductoEspecificoAgregado.CodigoProductoEspecifico = CodigoProductoEspecifico;
            if (TiempoGarantiaPE == null)
                compraProductoEspecificoAgregado.SetTiempoGarantiaPENull();
            else
                compraProductoEspecificoAgregado.TiempoGarantiaPE = TiempoGarantiaPE.Value;
            if (FechaHoraVencimientoPE == null)
                compraProductoEspecificoAgregado.SetFechaHoraVencimientoPENull();
            else
                compraProductoEspecificoAgregado.FechaHoraVencimientoPE = FechaHoraVencimientoPE.Value;
            compraProductoEspecificoAgregado.CargarAInventario = CargarAInventario;
            compraProductoEspecificoAgregado.PrecioUnitario = PrecioUnitario;
           


            ComprasProductosEspecificosAgregados.AddComprasProductosEspecificosAgregadosRow(compraProductoEspecificoAgregado);

            int rowsAffected = Adapter.Update(ComprasProductosEspecificosAgregados);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarCompraProductoEspecificoAgregado(int NumeroAgencia, int NumeroCompraProducto, string CodigoProducto, string CodigoProductoEspecifico, string CodigoTipoAgregado, int? TiempoGarantiaPE, DateTime? FechaHoraVencimientoPE, bool CargarAInventario, decimal PrecioUnitario)
        {
            DSDoblones20GestionComercial.ComprasProductosEspecificosAgregadosDataTable ComprasProductosEspecificosAgregados = Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto, CodigoProducto, CodigoProductoEspecifico);
            if (ComprasProductosEspecificosAgregados.Count == 0)
                return false;
            DSDoblones20GestionComercial.ComprasProductosEspecificosAgregadosRow compraProductoEspecificoAgregado = ComprasProductosEspecificosAgregados[0];


            if (CodigoProductoEspecifico == null) compraProductoEspecificoAgregado.SetCodigoProductoEspecificoNull();
            else compraProductoEspecificoAgregado.CodigoTipoAgregado = CodigoTipoAgregado;
            compraProductoEspecificoAgregado.CodigoProductoEspecifico = CodigoProducto;
            if (TiempoGarantiaPE == null)
                compraProductoEspecificoAgregado.SetTiempoGarantiaPENull();
            else
                compraProductoEspecificoAgregado.TiempoGarantiaPE = TiempoGarantiaPE.Value;
            if (FechaHoraVencimientoPE == null)
                compraProductoEspecificoAgregado.SetFechaHoraVencimientoPENull();
            else
                compraProductoEspecificoAgregado.FechaHoraVencimientoPE = FechaHoraVencimientoPE.Value;
            compraProductoEspecificoAgregado.CargarAInventario = CargarAInventario;
            compraProductoEspecificoAgregado.PrecioUnitario = PrecioUnitario;          


            ComprasProductosEspecificosAgregados.AddComprasProductosEspecificosAgregadosRow(compraProductoEspecificoAgregado);

            int rowsAffected = Adapter.Update(compraProductoEspecificoAgregado);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCompraProductoEspecificoAgregado(int NumeroAgencia, int NumeroCompraProducto, string CodigoProducto, string CodigoTipoAgregado)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgencia,NumeroCompraProducto,CodigoProducto,CodigoTipoAgregado);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarComprasProductosEspecificosAgregados(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia); 
        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerCompraProductoEspecificoAgregado(int NumeroAgencia, int NumeroCompraProducto, string CodigoProducto, string CodigoTipoAgregado)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto, CodigoProducto, CodigoTipoAgregado);
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarComprasProductosEspecificosAgregadosParaCompra(int NumeroAgencia, int NumeroCompraProducto)
        {
            return new ListarComprasProductosEspecificosAgregadosParaCompraTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto);
        }


        /// <summary>
        /// Realiza el Listado de Todos los Productos Agregados a la Compra
        /// para los REPORTES
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroVentaProducto"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCompraProductoEspecificoAgregadoReporte(int NumeroAgencia, int NumeroVentaProducto)
        {
            return new CompraProductoEspecificoAgregadoReporteTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto);
        }
 
    }
}
