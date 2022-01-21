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
    public class CotizacionVentasProductosCLN
    {
        #region Atributos de la Clase
        private CotizacionVentasProductosTableAdapter _CotizacionVentasProductosAdapter = null;
        protected CotizacionVentasProductosTableAdapter Adapter
        {
            get
            {
                if (_CotizacionVentasProductosAdapter == null)
                    _CotizacionVentasProductosAdapter = new CotizacionVentasProductosTableAdapter();
                return _CotizacionVentasProductosAdapter;
            }
        }
        #endregion

        #region Constructor
        public CotizacionVentasProductosCLN()
        {
            //constructor
        }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoCliente"></param>
        /// <param name="FechaHoraCotizacion"></param>
        /// <param name="ValidezOferta"></param>
        /// <param name="TiempoEntrega"></param>
        /// <param name="CodigoEstadoCotizacion"></param>
        /// <param name="CotizacionVendida"></param>
        /// <param name="CodigoMonedaCotizacionVenta"></param>
        /// <param name="Observaciones"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCotizacionVentaProducto(int NumeroAgencia, int CodigoCliente, int CodigoUsuario, DateTime FechaHoraCotizacion, int? ValidezOferta, int? TiempoEntrega, string CodigoEstadoCotizacion, bool CotizacionVendida, byte CodigoMonedaCotizacionVenta, string CodigoTipoCotizacion, bool ConFactura, string Observaciones, decimal? MontoTotalCotizacion, decimal? MontoTotalCotizacionProductos, decimal? MontoTotalCotizacionServicios, int? NumeroVentaServicio)
        {
            DSDoblones20GestionComercial.CotizacionVentasProductosDataTable CotizacionVentasProductos = new DSDoblones20GestionComercial.CotizacionVentasProductosDataTable();
            DSDoblones20GestionComercial.CotizacionVentasProductosRow cotizacionVentaProducto = CotizacionVentasProductos.NewCotizacionVentasProductosRow();

            cotizacionVentaProducto.NumeroAgencia = NumeroAgencia;
            cotizacionVentaProducto.CodigoCliente = CodigoCliente;
            cotizacionVentaProducto.CodigoUsuario = CodigoUsuario;
            cotizacionVentaProducto.FechaHoraCotizacion = FechaHoraCotizacion;
            if (ValidezOferta == null)
                cotizacionVentaProducto.SetValidezOfertaNull();
            else
                cotizacionVentaProducto.ValidezOferta = ValidezOferta.Value;
            if (TiempoEntrega == null)
                cotizacionVentaProducto.SetTiempoEntregaNull();
            else
                cotizacionVentaProducto.TiempoEntrega = TiempoEntrega.Value;
            cotizacionVentaProducto.CodigoEstadoCotizacion = CodigoEstadoCotizacion;
            cotizacionVentaProducto.CotizacionVendida = CotizacionVendida;
            cotizacionVentaProducto.CodigoMonedaCotizacionVenta = CodigoMonedaCotizacionVenta;
            cotizacionVentaProducto.CodigoTipoCotizacion = CodigoTipoCotizacion;
            cotizacionVentaProducto.ConFactura = ConFactura;
            if (Observaciones == null)
                cotizacionVentaProducto.SetObservacionesNull();
            else
                cotizacionVentaProducto.Observaciones = Observaciones;
            //cotizacionVentaProducto.NumeroCotizacionVentaProducto = 1;
            if (MontoTotalCotizacion == null) cotizacionVentaProducto.SetMontoTotalCotizacionNull();
            else cotizacionVentaProducto.MontoTotalCotizacion = MontoTotalCotizacion.Value;

            if (MontoTotalCotizacionProductos == null) cotizacionVentaProducto.SetMontoTotalCotizacionProductosNull();
            else cotizacionVentaProducto.MontoTotalCotizacionProductos = MontoTotalCotizacionProductos.Value;

            if (MontoTotalCotizacionServicios == null) cotizacionVentaProducto.SetMontoTotalCotizacionServiciosNull();
            else cotizacionVentaProducto.MontoTotalCotizacionServicios = MontoTotalCotizacionServicios.Value;

            if (NumeroVentaServicio == null) cotizacionVentaProducto.SetNumeroVentaServicioNull();
            else cotizacionVentaProducto.NumeroVentaServicio = NumeroVentaServicio.Value;

            CotizacionVentasProductos.AddCotizacionVentasProductosRow(cotizacionVentaProducto);

            int rowsAffected = Adapter.Update(CotizacionVentasProductos);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarCotizacionVentaProducto(int NumeroAgencia, int NumeroCotizacionVentaProducto, int CodigoCliente, int CodigoUsuario, DateTime FechaHoraCotizacion, int? ValidezOferta, int? TiempoEntrega, string CodigoEstadoCotizacion, bool CotizacionVendida, byte CodigoMonedaCotizacionVenta, string CodigoTipoCotizacion, bool ConFactura, string Observaciones, decimal? MontoTotalCotizacion, decimal? MontoTotalCotizacionProductos, decimal? MontoTotalCotizacionServicios, int? NumeroVentaServicio)
        {
            DSDoblones20GestionComercial.CotizacionVentasProductosDataTable CotizacionVentasProductos = Adapter.GetDataBy11(NumeroAgencia, NumeroCotizacionVentaProducto);
            if (CotizacionVentasProductos.Count == 0)
                return false;
            DSDoblones20GestionComercial.CotizacionVentasProductosRow cotizacionVentaProducto = CotizacionVentasProductos[0];

            cotizacionVentaProducto.NumeroAgencia = NumeroAgencia;
            cotizacionVentaProducto.CodigoCliente = CodigoCliente;
            cotizacionVentaProducto.CodigoUsuario = CodigoUsuario;
            cotizacionVentaProducto.FechaHoraCotizacion = FechaHoraCotizacion;
            if (ValidezOferta == null)
                cotizacionVentaProducto.SetValidezOfertaNull();
            else
                cotizacionVentaProducto.ValidezOferta = ValidezOferta.Value;
            if (TiempoEntrega == null)
                cotizacionVentaProducto.SetTiempoEntregaNull();
            else
                cotizacionVentaProducto.TiempoEntrega = TiempoEntrega.Value;
            cotizacionVentaProducto.CodigoEstadoCotizacion = CodigoEstadoCotizacion;
            cotizacionVentaProducto.CotizacionVendida = CotizacionVendida;
            cotizacionVentaProducto.CodigoMonedaCotizacionVenta = CodigoMonedaCotizacionVenta;
            cotizacionVentaProducto.CodigoTipoCotizacion = CodigoTipoCotizacion;
            cotizacionVentaProducto.ConFactura = ConFactura;
            if (Observaciones == null)
                cotizacionVentaProducto.SetObservacionesNull();
            else
                cotizacionVentaProducto.Observaciones = Observaciones;

            if (MontoTotalCotizacion == null) cotizacionVentaProducto.SetMontoTotalCotizacionNull();
            else cotizacionVentaProducto.MontoTotalCotizacion = MontoTotalCotizacion.Value;

            if (MontoTotalCotizacionProductos == null) cotizacionVentaProducto.SetMontoTotalCotizacionProductosNull();
            else cotizacionVentaProducto.MontoTotalCotizacionProductos = MontoTotalCotizacionProductos.Value;

            if (MontoTotalCotizacionServicios == null) cotizacionVentaProducto.SetMontoTotalCotizacionServiciosNull();
            else cotizacionVentaProducto.MontoTotalCotizacionServicios = MontoTotalCotizacionServicios.Value;

            if (NumeroVentaServicio == null) cotizacionVentaProducto.SetNumeroVentaServicioNull();
            else cotizacionVentaProducto.NumeroVentaServicio = NumeroVentaServicio.Value;


            int rowsAffected = Adapter.Update(cotizacionVentaProducto);
            return rowsAffected == 1;
        }

        public bool ActualizarCotizacionVentaProducto(int NumeroAgencia, int NumeroCotizacionVentaProducto, string Observaciones)
        {
            DSDoblones20GestionComercial.CotizacionVentasProductosDataTable CotizacionVentasProductos = Adapter.GetDataBy11(NumeroAgencia, NumeroCotizacionVentaProducto);
            if (CotizacionVentasProductos.Count == 0)
                return false;
            DSDoblones20GestionComercial.CotizacionVentasProductosRow cotizacionVentaProducto = CotizacionVentasProductos[0];

           
            if (Observaciones == null)
                cotizacionVentaProducto.SetObservacionesNull();
            else
                cotizacionVentaProducto.Observaciones = Observaciones;
            
            int rowsAffected = Adapter.Update(cotizacionVentaProducto);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCotizacionVentaProducto(int NumeroAgencia, int NumeroCotizacionVentaProducto)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgencia, NumeroCotizacionVentaProducto);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCotizacionVentasProductos(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia); 
        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerCotizacionVentaProducto(int NumeroAgencia, int NumeroCotizacionVentaProducto)
        {
            return Adapter.GetDataBy11(NumeroAgencia, NumeroCotizacionVentaProducto);
        }

        /// <summary>
        /// Obtiene los datos de una determinaza cotización de acuerdo a los parametros
        /// </summary>
        /// <param name="NumeroAgencia"> Número de Agencia</param>
        /// <param name="NumeroCotizacionVentaProducto">Numero Cotización de Venta</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]        
        public DataTable ListarDatosClienteCotizacionesVentaReporte(int NumeroAgencia, int NumeroCotizacionVentaProducto)
        {
            return new ListarDatosClienteCotizacionesVentaReporteTableAdapter().GetData(NumeroAgencia, NumeroCotizacionVentaProducto);
        }

        public bool EsCotizacionConFactura(int NumeroAgencia, int NumeroCotizacionVentaProducto)
        {
            return new FuncionesGestionComercial().EsCotizacionConFactura(NumeroAgencia, NumeroCotizacionVentaProducto).Value;
        }


        public void InsertarCotizacionVentaProductoXMLDetalle(int NumeroAgencia, int CodigoCliente, int CodigoUsuario, DateTime FechaHoraCotizacion, int? ValidezOferta, int? TiempoEntrega, string CodigoEstadoCotizacion, bool CotizacionVendida, byte CodigoMonedaCotizacionVenta, string CodigoTipoCotizacion, bool ConFactura, string Observaciones, string ProductosDetalle, decimal? MontoTotalCotizacion, decimal? MontoTotalCotizacionProductos, decimal? MontoTotalCotizacionServicios, int? NumeroVentaServicio)
        {
            Adapter.InsertarCotizacionVentaProductoXMLDetalle(NumeroAgencia, CodigoCliente, CodigoUsuario, FechaHoraCotizacion, ValidezOferta, TiempoEntrega, CodigoEstadoCotizacion, CotizacionVendida, CodigoMonedaCotizacionVenta, CodigoTipoCotizacion, ConFactura, Observaciones, MontoTotalCotizacion, MontoTotalCotizacionProductos, MontoTotalCotizacionServicios, NumeroVentaServicio, ProductosDetalle);
        }

        public void ActualizarCotizacionVentaProductoXMLDetalle(int NumeroAgencia, int NumeroCotizacionProductos, int CodigoCliente, int CodigoUsuario, DateTime FechaHoraCotizacion, int? ValidezOferta, int? TiempoEntrega, string CodigoEstadoCotizacion, bool CotizacionVendida, byte CodigoMonedaCotizacionVenta, string CodigoTipoCotizacion, bool ConFactura, string Observaciones, string ProductosDetalle, decimal? MontoTotalCotizacion, decimal? MontoTotalCotizacionProductos, decimal? MontoTotalCotizacionServicios, int? NumeroVentaServicio)
        {
            Adapter.ActualizarCotizacionVentaProductoXMLDetalle(NumeroAgencia, NumeroCotizacionProductos, CodigoCliente,
                CodigoUsuario, FechaHoraCotizacion, ValidezOferta, TiempoEntrega, CodigoEstadoCotizacion,
                CotizacionVendida, CodigoMonedaCotizacionVenta, CodigoTipoCotizacion, ConFactura,
                Observaciones, MontoTotalCotizacion, MontoTotalCotizacionProductos,
                MontoTotalCotizacionServicios, NumeroVentaServicio, ProductosDetalle);
        }

        public void ActualizarCoditoEstadoCotizacion(int NumeroAgencia, int NumeroCotizacionVentaProducto, string CodigoEstadoCotizacion)
        {
            Adapter.ActualizarCoditoEstadoCotizacion(NumeroAgencia, NumeroCotizacionVentaProducto, CodigoEstadoCotizacion);
        }

        public DataTable ListarDatosCotizacionesVentaReporteDetallado(int NumeroAgencia, int NumeroCotizacionVentaProducto)
        {
            return new ListarDatosCotizacionesVentaReporteDetalladoTableAdapter().GetData(NumeroAgencia, NumeroCotizacionVentaProducto);
        }

        public DataTable ListarProductosDescripcionCotizacion(int NumeroAgencia, int NumeroCotizacionVentaProducto)
        {
            return new ListarProductosDescripcionCotizacionTableAdapter().GetData(NumeroAgencia, NumeroCotizacionVentaProducto);
        }
    }
}
