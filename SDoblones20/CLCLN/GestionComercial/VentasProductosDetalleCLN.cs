using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;
using CLCAD.DSDoblones20GestionComercial2TableAdapters;

namespace CLCLN.GestionComercial
{
    [System.ComponentModel.DataObject]
    public class VentasProductosDetalleCLN
    {
        private VentasProductosDetalleTableAdapter _VentasProductosDetalleAdapter = null;
        protected VentasProductosDetalleTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosDetalleAdapter == null)
                    _VentasProductosDetalleAdapter = new VentasProductosDetalleTableAdapter();
                return _VentasProductosDetalleAdapter;
            }
        }

        public VentasProductosDetalleCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaProductoDetalle(int NumeroAgencia, int NumeroVentaProducto, string CodigoProducto, int CantidadVenta, int CantidadEntregada, decimal PrecioUnitarioVenta, int TiempoGarantiaVenta, decimal PorcentajeDescuento, string NumeroPrecioSeleccionado)
        {
            DSDoblones20GestionComercial.VentasProductosDetalleDataTable VentasProductosDetalle = new DSDoblones20GestionComercial.VentasProductosDetalleDataTable();
            DSDoblones20GestionComercial.VentasProductosDetalleRow VentaProductoDetalle = VentasProductosDetalle.NewVentasProductosDetalleRow();

            VentaProductoDetalle.NumeroAgencia = NumeroAgencia;
            VentaProductoDetalle.NumeroVentaProducto = NumeroVentaProducto;
            VentaProductoDetalle.CodigoProducto = CodigoProducto;
            VentaProductoDetalle.CantidadVenta = CantidadVenta;
            VentaProductoDetalle.CantidadEntregada = CantidadEntregada;
            VentaProductoDetalle.PrecioUnitarioVenta = PrecioUnitarioVenta;
            VentaProductoDetalle.TiempoGarantiaVenta = TiempoGarantiaVenta;
            if (PorcentajeDescuento == null) VentaProductoDetalle.SetPorcentajeDescuentoNull();
            else VentaProductoDetalle.PorcentajeDescuento = PorcentajeDescuento;
            if (NumeroPrecioSeleccionado == null) VentaProductoDetalle.SetNumeroPrecioSeleccionadoNull();
            else VentaProductoDetalle.NumeroPrecioSeleccionado = NumeroPrecioSeleccionado;

            VentasProductosDetalle.AddVentasProductosDetalleRow(VentaProductoDetalle);
            

            int rowsAffected = Adapter.Update(VentasProductosDetalle);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaProductoDetalle(int NumeroAgencia, int NumeroVentaProducto, string CodigoProducto, int CantidadVenta, int CantidadEntregada, decimal PrecioUnitarioVenta, int TiempoGarantiaVenta, decimal PorcentajeDescuento, string NumeroPrecioSeleccionado)
        {
            DSDoblones20GestionComercial.VentasProductosDetalleDataTable VentasProductosDetalle = Adapter.GetDataBy(NumeroAgencia, NumeroVentaProducto, CodigoProducto);
            if (VentasProductosDetalle.Count == 0)
                return false;

            DSDoblones20GestionComercial.VentasProductosDetalleRow VentaProductoDetalle = VentasProductosDetalle[0];

            VentaProductoDetalle.NumeroAgencia = NumeroAgencia;
            VentaProductoDetalle.NumeroVentaProducto = NumeroVentaProducto;
            VentaProductoDetalle.CodigoProducto = CodigoProducto;
            VentaProductoDetalle.CantidadVenta = CantidadVenta;
            VentaProductoDetalle.CantidadEntregada = CantidadEntregada;
            VentaProductoDetalle.PrecioUnitarioVenta = PrecioUnitarioVenta;
            VentaProductoDetalle.TiempoGarantiaVenta = TiempoGarantiaVenta;
            if (PorcentajeDescuento == null) VentaProductoDetalle.SetPorcentajeDescuentoNull();
            else VentaProductoDetalle.PorcentajeDescuento = PorcentajeDescuento;
            if (NumeroPrecioSeleccionado == null) VentaProductoDetalle.SetNumeroPrecioSeleccionadoNull();
            else VentaProductoDetalle.NumeroPrecioSeleccionado = NumeroPrecioSeleccionado;

            VentasProductosDetalle.AddVentasProductosDetalleRow(VentaProductoDetalle);

            int rowsAffected = Adapter.Update(VentaProductoDetalle);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaProductoDetalle(int NumeroAgencia, int NumeroVentaProducto, string CodigoProducto)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroVentaProducto, CodigoProducto);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosDetalle()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerVentaProductoDetalle(int NumeroAgencia, int NumeroVentaProducto, string CodigoProducto)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroVentaProducto, CodigoProducto);
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerVentaProductoDetalle(int NumeroAgencia, int NumeroVentaProducto)
        {
            return Adapter.GetDataByEspecificamente(NumeroAgencia, NumeroVentaProducto);
        }

        /// <summary>
        /// Realiza el listado Detallado de los Productos que fueron Vendidos en la Correspondiente
        /// Venta de Productos para generar REPORTES
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="NumeroVentaProducto">Número de Venta Producto</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentaProductoDetalleReporte(int NumeroAgencia, int NumeroVentaProducto)
        {
            return new VentaProductoDetalleReporteTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto);
        }



        /// <summary>
        /// Realiza el Listado de los Productos Vendidos de forma detallada, incluido
        /// el Detalle de los Productos Agregados en la correspondiente Venta para generar REPORTES
        /// </summary>
        /// <param name="NumeroAgencia">Numero Agencia</param>
        /// <param name="NumeroVentaProducto">Número de Venta Producto</param>
        /// <param name="TipoCalculoAgregado">Tipo de Calculo para el precio de Cada Producto : " 'P'->Promedio, 'S'->Sumatoria "</param>
        /// <param name="IncluirAgregados"> Incluir en el Detalle los Productos Agregados</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentaProductoDetalleReporteIncluidoAgregados(int NumeroAgencia, int NumeroVentaProducto, string TipoCalculoAgregado, bool IncluirAgregados, bool EsFactura)
        {
            return new VentaProductoDetalleReporteIncluidoAgregadosTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto, TipoCalculoAgregado, IncluirAgregados, EsFactura);
        }

        public DataTable ListarVentaProductoDetalleReporteIncluidoEspecificos(int NumeroAgencia, int NumeroVentaProducto, string TipoCalculoAgregado, bool IncluirAgregados, bool EsFactura)
        {
            if (new ListarVentasProductosEspecificosParaVentaTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto).Count == 0)
                return ListarVentaProductoDetalleReporteIncluidoAgregados(NumeroAgencia, NumeroVentaProducto, TipoCalculoAgregado, IncluirAgregados, EsFactura);
            else
                return new ListarVentaProductoDetalleReporteIncluidoEspecificosTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto, TipoCalculoAgregado, IncluirAgregados, EsFactura);
        }


        /// <summary>
        /// Realiza el Listado de los Productos Vendidos de forma detallada, incluido
        /// el Detalle de los Productos Agregados en la correspondiente Venta para generar REPORTES
        /// para su recojo de almacenes y su pago en Pago de Ventas para el Contador
        /// </summary>
        /// <param name="NumeroAgencia">Numero Agencia</param>
        /// <param name="NumeroVentaProducto">Número de Venta Producto</param>
        /// <param name="TipoCalculoAgregado">Tipo de Calculo para el precio de Cada Producto : " 'P'->Promedio, 'S'->Sumatoria "</param>
        /// <param name="IncluirAgregados"> Incluir en el Detalle los Productos Agregados</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentaProductoDetalleReporteParaRecogerDeAlmacenes(int NumeroAgencia, int NumeroVentaProducto, string TipoCalculoAgregado, bool IncluirAgregados)
        {
            return new ListarVentaProductoDetalleReporteParaRecogerDeAlmacenesTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto, TipoCalculoAgregado, IncluirAgregados);
        }


        public DataTable ListarVentaProductosDetalleEntregaParaVisualizarAlmacenes(int NumeroAgencia, int NumeroVentaProducto)
        {
            return new ListarVentaProductosDetalleEntregaParaVisualizarAlmacenesTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto);
        }

        public DataTable ListarVentaProductoCompuestosDetalleReporte(int NumeroAgencia, int NumeroVentaProducto)
        {
            return new ListarVentaProductoCompuestosDetalleReporteTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto);
        }

        public DataTable ListarVentaProductoSimplesDetalleReporte(int NumeroAgencia, int NumeroSalidaProducto, bool esVenta)
        {
            return new CLCAD.DSDoblones20GestionComercialTableAdapters.ListarVentaProductoSimplesDetalleReporteTableAdapter().GetData(NumeroAgencia, NumeroSalidaProducto, esVenta);
        }
    }
}
