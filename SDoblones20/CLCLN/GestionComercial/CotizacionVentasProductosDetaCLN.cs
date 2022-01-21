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
    public class CotizacionVentasProductosDetaCLN
    {
        #region Atributos de la Clase
        private CotizacionVentasProductosDetaTableAdapter _CotizacionVentasProductosDetaAdapter = null;
        protected CotizacionVentasProductosDetaTableAdapter Adapter
        {
            get
            {
                if (_CotizacionVentasProductosDetaAdapter == null)
                    _CotizacionVentasProductosDetaAdapter = new CotizacionVentasProductosDetaTableAdapter();
                return _CotizacionVentasProductosDetaAdapter;
            }
        }
        #endregion

        #region Constructor
        public CotizacionVentasProductosDetaCLN()
        {
            //constructor
        }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroCotizacionVentaProducto"></param>
        /// <param name="CodigoProducto"></param>
        /// <param name="CantidadCotizacionVenta"></param>
        /// <param name="PrecioUnitarioCotizacionVenta"></param>
        /// <param name="TiempoGarantiaCotizacionVenta"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCotizacionVentaProductoDeta(int NumeroAgencia, int NumeroCotizacionVentaProducto, string CodigoProducto, int CantidadCotizacionVenta, decimal PrecioUnitarioCotizacionVenta, int TiempoGarantiaCotizacionVenta, decimal? PorcentajeDescuento, string NumeroPrecioSeleccionado)
        {
            DSDoblones20GestionComercial.CotizacionVentasProductosDetaDataTable CotizacionVentasProductosDeta = new DSDoblones20GestionComercial.CotizacionVentasProductosDetaDataTable();
            DSDoblones20GestionComercial.CotizacionVentasProductosDetaRow cotizacionVentaProductoDeta = CotizacionVentasProductosDeta.NewCotizacionVentasProductosDetaRow();

            cotizacionVentaProductoDeta.NumeroAgencia = NumeroAgencia;
            cotizacionVentaProductoDeta.NumeroCotizacionVentaProducto = NumeroCotizacionVentaProducto;
            cotizacionVentaProductoDeta.CodigoProducto = CodigoProducto;
            cotizacionVentaProductoDeta.CantidadCotizacionVenta = CantidadCotizacionVenta;
            cotizacionVentaProductoDeta.PrecioUnitarioCotizacionVenta = PrecioUnitarioCotizacionVenta;
            cotizacionVentaProductoDeta.TiempoGarantiaCotizacionVenta = TiempoGarantiaCotizacionVenta;
            if (NumeroPrecioSeleccionado == null) cotizacionVentaProductoDeta.SetNumeroPrecioSeleccionadoNull();
            else cotizacionVentaProductoDeta.NumeroPrecioSeleccionado = NumeroPrecioSeleccionado;
            if (PorcentajeDescuento == null) cotizacionVentaProductoDeta.SetPorcentajeDescuentoNull();
            else cotizacionVentaProductoDeta.PorcentajeDescuento = PorcentajeDescuento.Value;


            CotizacionVentasProductosDeta.AddCotizacionVentasProductosDetaRow(cotizacionVentaProductoDeta);

            int rowsAffected = Adapter.Update(CotizacionVentasProductosDeta);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarCotizacionVentaProductoDeta(int NumeroAgencia, int NumeroCotizacionVentaProducto, string CodigoProducto, int CantidadCotizacionVenta, decimal PrecioUnitarioCotizacionVenta, int TiempoGarantiaCotizacionVenta, decimal? PorcentajeDescuento, string NumeroPrecioSeleccionado)
        {
            DSDoblones20GestionComercial.CotizacionVentasProductosDetaDataTable CotizacionVentasProductosDeta = Adapter.GetDataBy(NumeroAgencia, NumeroCotizacionVentaProducto, CodigoProducto);
            if (CotizacionVentasProductosDeta.Count == 0)
                return false;
            DSDoblones20GestionComercial.CotizacionVentasProductosDetaRow cotizacionVentaProductoDeta = CotizacionVentasProductosDeta[0];

            cotizacionVentaProductoDeta.NumeroAgencia = NumeroAgencia;
            cotizacionVentaProductoDeta.NumeroCotizacionVentaProducto = NumeroCotizacionVentaProducto;
            cotizacionVentaProductoDeta.CodigoProducto = CodigoProducto;
            cotizacionVentaProductoDeta.CantidadCotizacionVenta = CantidadCotizacionVenta;
            cotizacionVentaProductoDeta.PrecioUnitarioCotizacionVenta = PrecioUnitarioCotizacionVenta;
            cotizacionVentaProductoDeta.TiempoGarantiaCotizacionVenta = TiempoGarantiaCotizacionVenta;
            if (NumeroPrecioSeleccionado == null) cotizacionVentaProductoDeta.SetNumeroPrecioSeleccionadoNull();
            else cotizacionVentaProductoDeta.NumeroPrecioSeleccionado = NumeroPrecioSeleccionado;
            if (PorcentajeDescuento == null) cotizacionVentaProductoDeta.SetPorcentajeDescuentoNull();
            else cotizacionVentaProductoDeta.PorcentajeDescuento = PorcentajeDescuento.Value;

            CotizacionVentasProductosDeta.AddCotizacionVentasProductosDetaRow(cotizacionVentaProductoDeta);

            int rowsAffected = Adapter.Update(cotizacionVentaProductoDeta);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCotizacionVentaProductoDeta(int NumeroAgencia, int NumeroCotizacionVentaProducto, string CodigoProducto)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgencia, NumeroCotizacionVentaProducto, CodigoProducto);
            return rowsAffedted == 1;
        }

        /// <summary>
        /// listado de las Cotizaciones de los Productos
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="NumeroCotizacionVentaProducto">Numero de Cotizacion:  enviar -1 implica que no se hara el filtro
        /// para una determinada cotización, caso contrario, Si!!</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCotizacionVentasProductosDeta(int NumeroAgencia, int NumeroCotizacionVentaProducto)
        {
            return Adapter.GetData(NumeroAgencia,NumeroCotizacionVentaProducto); 
        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerCotizacionVentaProductoDeta(int NumeroAgencia, int NumeroCotizacionVentaProducto, string CodigoProducto)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroCotizacionVentaProducto, CodigoProducto);
        } //ListarCotizacionVentasProductosDetalleReporte

           /// <summary>
           /// Lista el Detalle de la Cotización para una Determinada Cotización
           /// </summary>
           /// <param name="NumeroAgencia"></param>
           /// <param name="NumeroCotizacionVentaProducto"></param>
           /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCotizacionVentasProductosDetalleReporte(int NumeroAgencia, int NumeroCotizacionVentaProducto)
        {
            return new ListarCotizacionVentasProductosDetalleReporteTableAdapter().GetData(NumeroAgencia, NumeroCotizacionVentaProducto);
        }

        public DataTable ListarCotizacionVentasProductosDetalleReporteDetallado(int NumeroAgencia, int NumeroCotizacionVentaProducto)
        {
            return new ListarCotizacionVentasProductosDetalleReporteDetalladoTableAdapter().GetData(NumeroAgencia, NumeroCotizacionVentaProducto);
        }

        public DataTable ListarCotizacionVentaProductoCompuestosDetalleReporte(int NumeroAgencia, int NumeroCotizacionVentaProducto)
        {
            return new ListarCotizacionVentaProductoCompuestosDetalleReporteTableAdapter().GetData(NumeroAgencia, NumeroCotizacionVentaProducto);
        }
    }
}
