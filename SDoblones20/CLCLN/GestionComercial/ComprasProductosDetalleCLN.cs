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
    public class ComprasProductosDetalleCLN
    {
        #region Atributos de la Clase
        private ComprasProductosDetalleTableAdapter _ComprasProductosDetalleAdapter = null;
        protected ComprasProductosDetalleTableAdapter Adapter
        {
            get
            {
                if (_ComprasProductosDetalleAdapter == null)
                    _ComprasProductosDetalleAdapter = new ComprasProductosDetalleTableAdapter();
                return _ComprasProductosDetalleAdapter;
            }
        }
        #endregion

        #region Constructor
        public ComprasProductosDetalleCLN()
        {
            //constructor
        }

        #endregion

        /// <summary>
        /// Detalle de la Compra de Productos
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroCompraProducto"></param>
        /// <param name="CodigoProducto"></param>
        /// <param name="CantidadCompra"></param>
        /// <param name="PrecioUnitarioCompra"></param>
        /// <param name="TiempoGarantiaCompra"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCompraProductoDetalle(int NumeroAgencia,int NumeroCompraProducto,string CodigoProducto, int CantidadCompra, decimal PrecioUnitarioCompra, int? TiempoGarantiaCompra)
        {
            DSDoblones20GestionComercial.ComprasProductosDetalleDataTable ComprasProductosDetalle = new DSDoblones20GestionComercial.ComprasProductosDetalleDataTable();
            DSDoblones20GestionComercial.ComprasProductosDetalleRow compraProductoDetalle = ComprasProductosDetalle.NewComprasProductosDetalleRow();

            compraProductoDetalle.NumeroAgencia = NumeroAgencia;
            compraProductoDetalle.NumeroCompraProducto = NumeroCompraProducto;
            compraProductoDetalle.CodigoProducto = CodigoProducto;
            compraProductoDetalle.CantidadCompra = CantidadCompra;
            compraProductoDetalle.PrecioUnitarioCompra = PrecioUnitarioCompra;
            if (TiempoGarantiaCompra == null)
                compraProductoDetalle.SetTiempoGarantiaCompraNull();
            else
                compraProductoDetalle.TiempoGarantiaCompra = TiempoGarantiaCompra.Value;
           


            ComprasProductosDetalle.AddComprasProductosDetalleRow(compraProductoDetalle);

            int rowsAffected = Adapter.Update(ComprasProductosDetalle);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarCompraProductoDetalle(int NumeroAgencia, int NumeroCompraProducto, string CodigoProducto, int CantidadCompra, decimal PrecioUnitarioCompra, int? TiempoGarantiaCompra)
        {
            DSDoblones20GestionComercial.ComprasProductosDetalleDataTable ComprasProductosDetalle = Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto, CodigoProducto);
            if (ComprasProductosDetalle.Count == 0)
                return false;
            DSDoblones20GestionComercial.ComprasProductosDetalleRow compraProductoDetalle = ComprasProductosDetalle[0];

            compraProductoDetalle.NumeroAgencia = NumeroAgencia;
            compraProductoDetalle.NumeroCompraProducto = NumeroCompraProducto;
            compraProductoDetalle.CodigoProducto = CodigoProducto;
            compraProductoDetalle.CantidadCompra = CantidadCompra;
            compraProductoDetalle.PrecioUnitarioCompra = PrecioUnitarioCompra;
            if (TiempoGarantiaCompra == null)
                compraProductoDetalle.SetTiempoGarantiaCompraNull();
            else
                compraProductoDetalle.TiempoGarantiaCompra = TiempoGarantiaCompra.Value;
            


            ComprasProductosDetalle.AddComprasProductosDetalleRow(compraProductoDetalle);

            int rowsAffected = Adapter.Update(compraProductoDetalle);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCompraProductoDetalle(int NumeroAgencia, int NumeroCompraProducto, string CodigoProducto)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgencia,NumeroCompraProducto,CodigoProducto);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarComprasProductosDetalle(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia); 
        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerCompraProductoDetalle(int NumeroAgencia, int NumeroCompraProducto, string CodigoProducto)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto, CodigoProducto);
        }


        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public DataTable ObtenerComprasProductosDetalle()
        //{
        //    return Adapter.GetObtenerComprasProductosDetalle();
        //}

        /// <summary>
        /// Realizar el Listado de Todos los Productos que se Realizaron el compra Correspondiente
        /// para la Generación de Reportes
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="NumeroCompraProducto">Número de Compra Producto</param>
        /// <returns>DataTable: con todos los Productos Comprados</returns>
        /// [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCompraProductoDetalleReporte(int NumeroAgencia, int NumeroCompraProducto)
        {
            return new CompraProductoDetalleReporteTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto);
        }

        /// <summary>
        /// Realiza el Listado de todos los Productos Comprados de una determinada Compra
        /// incluyendo en caso de ser necesario los Productos Agregados para REPORTES
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="NumeroCompraProducto">Número de Compra Producto</param>
        /// <param name="TipoCalculoAgregado">tipo de Calculo para el Precio del Producto Agregado : " 'P'->Promedio, 'S'->Sumatoria "</param>
        /// <param name="IncluirAgregados">Incluir en el reporte los Productos Agregados</param>
        /// <returns>DataTable con los Datos de la Compra</returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCompraProductoDetalleReporteIncluidoAgregados(int NumeroAgencia, int NumeroCompraProducto, string TipoCalculoAgregado, bool IncluirAgregados)
        {
            return new CompraProductoDetalleReporteIncluidoAgregadosTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto, TipoCalculoAgregado,IncluirAgregados);
        }


        public DSDoblones20GestionComercial.ListarCompraProductosDetalleEntregadosDataTable ListarCompraProductosDetalleEntregados(int NumeroAgencia, int NumeroCompraProducto, bool MostrarSoloFaltantes)
        {
            return new ListarCompraProductosDetalleEntregadosTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto, MostrarSoloFaltantes);
        }


    
    }
}
