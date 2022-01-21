using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.GestionComercial
{
    public class ComprasProductosCLN
    {
        #region Atributos de la Clase
        private ComprasProductosTableAdapter _ComprasProductosAdapter = null;
        protected ComprasProductosTableAdapter Adapter
        {
            get
            {
                if (_ComprasProductosAdapter == null)
                    _ComprasProductosAdapter = new ComprasProductosTableAdapter();
                return _ComprasProductosAdapter;
            }
        }
        #endregion

        #region Constructor
        public ComprasProductosCLN()
        {
            //constructor
        }

        #endregion


        /// <summary>
        /// Insertar una Compra de Productos
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoProveedor"></param>
        /// <param name="Fecha"></param>
        /// <param name="CodigoTipoCompra"></param>
        /// <param name="CodigoEstadoCompra"></param>
        /// <param name="MontoTotalCompra"></param>
        /// <param name="Observaciones"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCompraProducto(int NumeroAgencia, int CodigoProveedor, int CodigoUsuario, 
            int? CodigoUsuarioResponsablePago, int? CodigoUsuarioResponsableRecepcion, 
            DateTime? FechaHoraPlazoDeRecepcion, DateTime? FechaHoraPago, DateTime? FechaHoraRecepcion,
            DateTime Fecha, string CodigoTipoCompra, string CodigoEstadoCompra, string CodigoEstadoFactura, decimal MontoTotalCompra, int? NumeroCuentaPorPagar, 
            string CodigoCompraProducto,
            string DIPersonaDestinatario,
            DateTime? FechaHoraEnvioMercaderia,
            decimal? ImpuestoIVA,
            string NumeroFactura,
            string NumeroAutorizacionFactura,
            string CodigoControlFactura,
            bool EsImportacion,
            bool RegistroDirectoAlmacen,
            byte? CodigoMedioTransporte,
            decimal? MontoDescuento,
            decimal? MontoNetoCompra,
            byte? CodigoOrigenMercaderia,
            string NumeroGuiaTranposrte,
            byte? CodigoMoneda,            
            string Observaciones)
        {
            DSDoblones20GestionComercial.ComprasProductosDataTable ComprasProductos = new DSDoblones20GestionComercial.ComprasProductosDataTable();
            DSDoblones20GestionComercial.ComprasProductosRow compraProducto = ComprasProductos.NewComprasProductosRow();

            compraProducto.NumeroAgencia = NumeroAgencia;
            compraProducto.CodigoProveedor = CodigoProveedor;
            compraProducto.CodigoUsuario = CodigoUsuario;
            compraProducto.Fecha = Fecha;
            compraProducto.CodigoTipoCompra = CodigoTipoCompra;
            compraProducto.CodigoEstadoCompra = CodigoEstadoCompra;
            compraProducto.MontoTotalCompra = MontoTotalCompra; 
            
            if (NumeroCuentaPorPagar == null)
                compraProducto.SetNumeroCuentaPorPagarNull();
            else
                compraProducto.NumeroCuentaPorPagar = NumeroCuentaPorPagar.Value;
            if (Observaciones == null)
                compraProducto.SetObservacionesNull();
            else
                compraProducto.Observaciones = Observaciones;

            if (CodigoEstadoFactura == null)
                compraProducto.SetCodigoEstadoFacturaNull();
            else
                compraProducto.CodigoEstadoFactura = CodigoEstadoFactura;

            if (CodigoUsuarioResponsablePago == null)
                compraProducto.SetCodigoUsuarioResponsablePagoNull();
            else
                compraProducto.CodigoUsuarioResponsablePago = CodigoUsuarioResponsablePago.Value;

            if (CodigoUsuarioResponsableRecepcion == null)
                compraProducto.SetCodigoUsuarioResponsableRecepcionNull();
            else
                compraProducto.CodigoUsuarioResponsableRecepcion = CodigoUsuarioResponsableRecepcion.Value;


            if (FechaHoraPlazoDeRecepcion == null)
                compraProducto.SetFechaHoraPlazoDeRecepcionNull();
            else
                compraProducto.FechaHoraPlazoDeRecepcion = FechaHoraPlazoDeRecepcion.Value;

            if (FechaHoraPago == null)
                compraProducto.SetFechaHoraPagoNull();
            else
                compraProducto.FechaHoraPago = FechaHoraPago.Value;

            if (FechaHoraRecepcion == null)
                compraProducto.SetFechaHoraRecepcionNull();
            else
                compraProducto.FechaHoraRecepcion = FechaHoraRecepcion.Value;

            if (CodigoCompraProducto == null)
                compraProducto.SetCodigoCompraProductoNull();
            else
                compraProducto.CodigoCompraProducto = CodigoCompraProducto;
                

            if(DIPersonaDestinatario == null)                
                compraProducto.SetCodigoCompraProductoNull();            
            else
                compraProducto.CodigoCompraProducto = CodigoCompraProducto;

            if(FechaHoraEnvioMercaderia == null)
                compraProducto.SetFechaHoraEnvioMercaderiaNull();
            else
                compraProducto.FechaHoraEnvioMercaderia = FechaHoraEnvioMercaderia.Value;

            if(ImpuestoIVA == null)
                compraProducto.SetImpuestoIVANull();
            else
                compraProducto.ImpuestoIVA = ImpuestoIVA.Value;
            
            if(NumeroFactura == null)
                compraProducto.SetNumeroFacturaNull();
            else
                compraProducto.NumeroFactura = NumeroFactura;

            if(NumeroAutorizacionFactura == null)
                compraProducto.SetNumeroAutorizacionFacturaNull();
            else
                compraProducto.NumeroAutorizacionFactura = NumeroAutorizacionFactura;
            
            if(CodigoControlFactura == null)
                compraProducto.SetCodigoControlFacturaNull();
            else
                compraProducto.CodigoControlFactura = CodigoControlFactura;
            
            if(EsImportacion == null)
                compraProducto.SetEsImportacionNull();
            else
                compraProducto.EsImportacion = EsImportacion;

            if(RegistroDirectoAlmacen == null)
                compraProducto.SetRegistroDirectoAlmacenNull();
            else
                compraProducto.RegistroDirectoAlmacen = RegistroDirectoAlmacen;
            if(CodigoMedioTransporte == null)
                compraProducto.SetCodigoMedioTransporteNull();
            else
                compraProducto.CodigoMedioTransporte = CodigoMedioTransporte.Value;

            if(MontoDescuento == null)
                compraProducto.SetMontoDescuentoNull();
            else
                compraProducto.MontoDescuento = MontoDescuento.Value;

            if(MontoNetoCompra == null)
                compraProducto.SetMontoNetoCompraNull();
            else
                compraProducto.MontoNetoCompra = MontoNetoCompra.Value;

            if(CodigoOrigenMercaderia == null)
                compraProducto.SetCodigoOrigenMercaderiaNull();
            else
                compraProducto.CodigoOrigenMercaderia = CodigoOrigenMercaderia.Value;

            if(NumeroGuiaTranposrte == null)
                compraProducto.SetNumeroGuiaTranposrteNull();
            else
                compraProducto.NumeroGuiaTranposrte = NumeroGuiaTranposrte;

            if (CodigoMoneda == null)
                compraProducto.SetNumeroGuiaTranposrteNull();
            else
                compraProducto.CodigoMoneda = CodigoMoneda.Value;

                       
            ComprasProductos.AddComprasProductosRow(compraProducto);

            int rowsAffected = Adapter.Update(ComprasProductos);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarCompraProducto(int NumeroAgencia, int NumeroCompraProducto, int CodigoProveedor, int CodigoUsuario,
                    int? CodigoUsuarioResponsablePago, int? CodigoUsuarioResponsableRecepcion,
                    DateTime? FechaHoraPlazoDeRecepcion, DateTime? FechaHoraPago, DateTime? FechaHoraRecepcion,
                    DateTime Fecha, string CodigoTipoCompra, string CodigoEstadoCompra, string CodigoEstadoFactura, decimal MontoTotalCompra, int? NumeroCuentaPorPagar,
                    string CodigoCompraProducto,
                    string DIPersonaDestinatario,
                    DateTime? FechaHoraEnvioMercaderia,
                    decimal? ImpuestoIVA,
                    string NumeroFactura,
                    string NumeroAutorizacionFactura,
                    string CodigoControlFactura,
                    bool EsImportacion,
                    bool RegistroDirectoAlmacen,
                    byte? CodigoMedioTransporte,
                    decimal? MontoDescuento,
                    decimal? MontoNetoCompra,
                    byte? CodigoOrigenMercaderia,
                    string NumeroGuiaTranposrte,
                    byte? CodigoMoneda,  
                    string Observaciones)
        {
            DSDoblones20GestionComercial.ComprasProductosDataTable ComprasProductos = Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto);
            if (ComprasProductos.Count == 0)
                return false;
            DSDoblones20GestionComercial.ComprasProductosRow compraProducto = ComprasProductos[0];

            compraProducto.CodigoProveedor = CodigoProveedor;
            compraProducto.CodigoUsuario = CodigoUsuario;
            compraProducto.Fecha = Fecha;
            compraProducto.CodigoTipoCompra = CodigoTipoCompra;
            compraProducto.CodigoEstadoCompra = CodigoEstadoCompra;
            compraProducto.MontoTotalCompra = MontoTotalCompra;

            if (NumeroCuentaPorPagar == null)
                compraProducto.SetNumeroCuentaPorPagarNull();
            else
                compraProducto.NumeroCuentaPorPagar = NumeroCuentaPorPagar.Value;
            if (Observaciones == null)
                compraProducto.SetObservacionesNull();
            else
                compraProducto.Observaciones = Observaciones;

            if (CodigoEstadoFactura == null)
                compraProducto.SetCodigoEstadoFacturaNull();
            else
                compraProducto.CodigoEstadoFactura = CodigoEstadoFactura;

            if (CodigoUsuarioResponsablePago == null)
                compraProducto.SetCodigoUsuarioResponsablePagoNull();
            else
                compraProducto.CodigoUsuarioResponsablePago = CodigoUsuarioResponsablePago.Value;

            if (CodigoUsuarioResponsableRecepcion == null)
                compraProducto.SetCodigoUsuarioResponsableRecepcionNull();
            else
                compraProducto.CodigoUsuarioResponsableRecepcion = CodigoUsuarioResponsableRecepcion.Value;


            if (FechaHoraPlazoDeRecepcion == null)
                compraProducto.SetFechaHoraPlazoDeRecepcionNull();
            else
                compraProducto.FechaHoraPlazoDeRecepcion = FechaHoraPlazoDeRecepcion.Value;

            if (FechaHoraPago == null)
                compraProducto.SetFechaHoraPagoNull();
            else
                compraProducto.FechaHoraPago = FechaHoraPago.Value;

            if (FechaHoraRecepcion == null)
                compraProducto.SetFechaHoraRecepcionNull();
            else
                compraProducto.FechaHoraRecepcion = FechaHoraRecepcion.Value;

            if (CodigoCompraProducto == null)
                compraProducto.SetCodigoCompraProductoNull();
            else
                compraProducto.CodigoCompraProducto = CodigoCompraProducto;


            if (DIPersonaDestinatario == null)
                compraProducto.SetCodigoCompraProductoNull();
            else
                compraProducto.DIPersonaDestinatario = DIPersonaDestinatario;

            if (FechaHoraEnvioMercaderia == null)
                compraProducto.SetFechaHoraEnvioMercaderiaNull();
            else
                compraProducto.FechaHoraEnvioMercaderia = FechaHoraEnvioMercaderia.Value;

            if (ImpuestoIVA == null)
                compraProducto.SetImpuestoIVANull();
            else
                compraProducto.ImpuestoIVA = ImpuestoIVA.Value;

            if (NumeroFactura == null)
                compraProducto.SetNumeroFacturaNull();
            else
                compraProducto.NumeroFactura = NumeroFactura;

            if (NumeroAutorizacionFactura == null)
                compraProducto.SetNumeroAutorizacionFacturaNull();
            else
                compraProducto.NumeroAutorizacionFactura = NumeroAutorizacionFactura;

            if (CodigoControlFactura == null)
                compraProducto.SetCodigoControlFacturaNull();
            else
                compraProducto.CodigoControlFactura = CodigoControlFactura;

            if (EsImportacion == null)
                compraProducto.SetEsImportacionNull();
            else
                compraProducto.EsImportacion = EsImportacion;

            if (RegistroDirectoAlmacen == null)
                compraProducto.SetRegistroDirectoAlmacenNull();
            else
                compraProducto.RegistroDirectoAlmacen = RegistroDirectoAlmacen;
            if (CodigoMedioTransporte == null)
                compraProducto.SetCodigoMedioTransporteNull();
            else
                compraProducto.CodigoMedioTransporte = CodigoMedioTransporte.Value;

            if (MontoDescuento == null)
                compraProducto.SetMontoDescuentoNull();
            else
                compraProducto.MontoDescuento = MontoDescuento.Value;

            if (MontoNetoCompra == null)
                compraProducto.SetMontoNetoCompraNull();
            else
                compraProducto.MontoNetoCompra = MontoNetoCompra.Value;

            if (CodigoOrigenMercaderia == null)
                compraProducto.SetCodigoOrigenMercaderiaNull();
            else
                compraProducto.CodigoOrigenMercaderia = CodigoOrigenMercaderia.Value;

            if (NumeroGuiaTranposrte == null)
                compraProducto.SetNumeroGuiaTranposrteNull();
            else
                compraProducto.NumeroGuiaTranposrte = NumeroGuiaTranposrte;

            if (CodigoMoneda == null)
                compraProducto.SetNumeroGuiaTranposrteNull();
            else
                compraProducto.CodigoMoneda = CodigoMoneda.Value;
            
            int rowsAffected = Adapter.Update(compraProducto);
            return rowsAffected == 1;
        }


        public bool ActualizarCompraProductoResponsableRecepcion(int NumeroAgencia, int NumeroCompraProducto, int? CodigoUsuarioResponsableRecepcion, DateTime? FechaHoraRecepcion)
        {
            DSDoblones20GestionComercial.ComprasProductosDataTable ComprasProductos = Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto);
            if (ComprasProductos.Count == 0)
                return false;
            DSDoblones20GestionComercial.ComprasProductosRow compraProducto = ComprasProductos[0];

            if (CodigoUsuarioResponsableRecepcion == null)
                compraProducto.SetCodigoUsuarioResponsableRecepcionNull();
            else
                compraProducto.CodigoUsuarioResponsableRecepcion = CodigoUsuarioResponsableRecepcion.Value;
            if (FechaHoraRecepcion == null)
                compraProducto.SetFechaHoraRecepcionNull();
            else
                compraProducto.FechaHoraRecepcion = FechaHoraRecepcion.Value;

            int rowsAffected = Adapter.Update(compraProducto);
            return rowsAffected == 1;
        }

        public bool ActualizarCompraProductoResponsablePago(int NumeroAgencia, int NumeroCompraProducto, int? CodigoUsuarioResponsablePago, DateTime? FechaHoraPago)
        {
            DSDoblones20GestionComercial.ComprasProductosDataTable ComprasProductos = Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto);
            if (ComprasProductos.Count == 0)
                return false;
            DSDoblones20GestionComercial.ComprasProductosRow compraProducto = ComprasProductos[0];

            if (CodigoUsuarioResponsablePago == null)
                compraProducto.SetCodigoUsuarioResponsablePagoNull();
            else
                compraProducto.CodigoUsuarioResponsableRecepcion = CodigoUsuarioResponsablePago.Value;
            if (FechaHoraPago == null)
                compraProducto.SetFechaHoraPagoNull();
            else
                compraProducto.FechaHoraPago = FechaHoraPago.Value;

            int rowsAffected = Adapter.Update(compraProducto);
            return rowsAffected == 1;
        }


        public bool ActualizarCompraProducto(int NumeroAgencia, int NumeroCompraProducto, string Observaciones)
        {
            DSDoblones20GestionComercial.ComprasProductosDataTable ComprasProductos = Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto);
            if (ComprasProductos.Count == 0)
                return false;
            DSDoblones20GestionComercial.ComprasProductosRow compraProducto = ComprasProductos[0];

            
            if (Observaciones == null)
                compraProducto.SetObservacionesNull();
            else
                compraProducto.Observaciones = Observaciones;            

            int rowsAffected = Adapter.Update(compraProducto);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCompraProducto(int NumeroAgencia, int NumeroCompraProducto)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgencia, NumeroCompraProducto);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial.ComprasProductosDataTable ListarComprasProductos(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia); 
        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial.ComprasProductosDataTable ObtenerCompraProducto(int NumeroAgencia, int NumeroCompraProducto)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto);
        }

        public string ListarTuplaDatosCompraProductoReporte(int NumeroAgencia, int NumeroCompraProducto)
        {
            string listadoAtributosCompras = null;
            new QTAFuncionesSistema().ListarTuplaDatosCompraProductoReporte(NumeroAgencia, NumeroCompraProducto, ref listadoAtributosCompras);
            return listadoAtributosCompras;
        } 


        /// <summary>
        /// Datos Principales de una Compra para realizar un reporte
        /// </summary>
        /// <param name="NumeroAgencia">Número de Agencia</param>
        /// <param name="NumeroCompraProducto">Número Compra Producto</param>
        /// <returns>DataTable con los Datos de la Compra</returns>
        public DataTable ListarCompraProductoReporte(int NumeroAgencia, int NumeroCompraProducto)
        {
            return new CompraProductoReporteTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto);
            
        }

        public DataTable ListarComprasProductosPorUsuariosReporte(int NumeroAgencia, int? CodigoUsuario)
        {
            return new ReporteComprasProductosPorUsuariosTableAdapter().GetData(CodigoUsuario, NumeroAgencia);
        }

        public DataTable ListarComprasProductosPorRangoFechasReporte(int NumeroAgencia, DateTime FechaInicio, DateTime FechaFin)
        {
            return new ReporteComprasProductosPorRangoFechasTableAdapter().GetData(FechaInicio, FechaFin, NumeroAgencia);
        }

        public DataTable ListarComprasProductosPorRangoFechasUsuarioReporte(DateTime FechaInicio, DateTime FechaFin, int CodigoUsuario, int NumeroAgencia)
        {
            return new ReporteComprasProductosPorRangoFechasUsuarioTableAdapter().GetData(FechaInicio, FechaFin, CodigoUsuario,NumeroAgencia);
        }

        public DataTable ListarComprasProductosPorProductosReporte(int NumeroAgencia, string CodigoProducto)
        {
            return new ReporteComprasProductosPorProductosTableAdapter().GetData(CodigoProducto, NumeroAgencia);
        }

        public DataTable ListarComprasProductosPorProveedorReporte(int NumeroAgencia, int? CodigoProveedor)
        {
            return new ReporteComprasProductosPorProveedorTableAdapter().GetData(CodigoProveedor, NumeroAgencia);
        }

        public void ActualizarCodigoEstadoCompra(int NumeroAgencia, int NumeroCompraProducto, string CodigoEstadoCompra, int? NumeroFactura)
        {
            new FuncionesGestionComercial().ActualizarCodigoEstadoCompra(NumeroAgencia, NumeroCompraProducto, CodigoEstadoCompra, NumeroFactura);
        }

        public void EliminarCompraProductoDetalleDesdeListado(int NumeroAgencia, int NumeroCompraProducto, string ListadoCodigoProducto)
        {
            new FuncionesGestionComercial().EliminarCompraProductoDetalleDesdeListado(NumeroAgencia, NumeroCompraProducto, ListadoCodigoProducto);
        }

        public DSDoblones20GestionComercial.BuscarCompraProductoDataTable BuscarCompraProducto(string CodigoAmbitoBusqueda, string TextoABuscar, int? NumeroAgencia, int? NumeroTransaccion, string CodigoEstadoCompra, DateTime FechaInicio, DateTime FechaFin, bool ExactamenteIgual)
        {
            int? numCompraProducto = null;
            if (NumeroTransaccion != -1)
            {
                numCompraProducto = NumeroTransaccion;
            }
            return new BuscarCompraProductoTableAdapter().GetData(CodigoAmbitoBusqueda, TextoABuscar, NumeroAgencia, numCompraProducto, CodigoEstadoCompra, FechaInicio, FechaFin, ExactamenteIgual);
        }


        public DataTable ListarCompraProductosGastosRecepcionPartesReportes(int NumeroAgencia, int NumeroCompraProducto, bool? IncluirTodosGastos)
        {
            return new CLCAD.DSDoblones20GestionComercial2TableAdapters.ListarCompraProductosGastosRecepcionPartesReportesTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto, IncluirTodosGastos);
        }

        public DataTable ListarProductosRecepcionadosPorFechaReporte(int NumeroAgencia, int NumeroCompraProducto, DateTime? FechaRecepcion)
        {
            return new CLCAD.DSDoblones20GestionComercial2TableAdapters.ListarProductosRecepcionadosPorFechaReporteTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto, FechaRecepcion);
        }


        public void InsertarCompraProductoXMLDetalle(int NumeroAgencia, int CodigoProveedor, int CodigoUsuario,
                    int? CodigoUsuarioResponsablePago, int? CodigoUsuarioResponsableRecepcion,
                    DateTime? FechaHoraPlazoDeRecepcion, DateTime? FechaHoraPago, DateTime? FechaHoraRecepcion,
                    DateTime Fecha, string CodigoTipoCompra, string CodigoEstadoCompra, 
                    string CodigoEstadoFactura, decimal MontoTotalCompra, 
                    string CodigoCompraProducto,
                    string DIPersonaDestinatario,
                    DateTime? FechaHoraEnvioMercaderia,
                    decimal? ImpuestoIVA,
                    string NumeroFactura,
                    string NumeroAutorizacionFactura,
                    string CodigoControlFactura,
                    bool EsImportacion,
                    bool RegistroDirectoAlmacen,
                    byte? CodigoMedioTransporte,
                    decimal? MontoDescuento,
                    decimal? MontoNetoCompra,
                    byte? CodigoOrigenMercaderia,
                    string NumeroGuiaTranposrte,
                    byte? CodigoMoneda, 
                    int? NumeroCuentaPorPagar, string Observaciones, string ProductosDetalle)
        {
            ComprasProductosTableAdapter AdapterC = new ComprasProductosTableAdapter();
            AdapterC.InsertarCompraProductoXMLDetalle(NumeroAgencia, CodigoProveedor, CodigoUsuario, 
                CodigoUsuarioResponsablePago, CodigoUsuarioResponsableRecepcion, FechaHoraPlazoDeRecepcion, FechaHoraPago, FechaHoraRecepcion,
                Fecha, CodigoTipoCompra, CodigoEstadoCompra, CodigoEstadoFactura, MontoTotalCompra, NumeroCuentaPorPagar, 
                CodigoCompraProducto,
                DIPersonaDestinatario,
                FechaHoraEnvioMercaderia,
                ImpuestoIVA,
                NumeroFactura,
                NumeroAutorizacionFactura,
                CodigoControlFactura,
                EsImportacion,
                RegistroDirectoAlmacen,
                CodigoMedioTransporte,
                MontoDescuento,
                MontoNetoCompra,
                CodigoOrigenMercaderia,
                NumeroGuiaTranposrte,
                CodigoMoneda, 
                Observaciones, ProductosDetalle);           
        }

        public DSDoblones20GestionComercial2.ListarCompraProductoCuentasPorCobrarReporteDataTable 
            ListarCompraProductoCuentasPorCobrarReporte(int NumeroAgencia, int? NumeroCompraProducto, 
            DateTime? FechaInicio, DateTime? FechaFin,  string CodigoEstado)
        {
            return new CLCAD.DSDoblones20GestionComercial2TableAdapters.ListarCompraProductoCuentasPorCobrarReporteTableAdapter().GetData(
                NumeroAgencia, NumeroCompraProducto, FechaInicio, FechaFin, CodigoEstado);
        }

        public DSDoblones20GestionComercial2.ListarCompraProductoCuentasPorPagarReporteDataTable 
            ListarCompraProductoCuentasPorPagarReporte
            (int NumeroAgencia, int? NumeroCompraProducto, 
            DateTime? FechaInicio, DateTime? FechaFin, string CodigoEstado)
        {
            return new CLCAD.DSDoblones20GestionComercial2TableAdapters.ListarCompraProductoCuentasPorPagarReporteTableAdapter().GetData(
                NumeroAgencia, NumeroCompraProducto, FechaInicio, FechaFin, CodigoEstado);
        }
    }
}

