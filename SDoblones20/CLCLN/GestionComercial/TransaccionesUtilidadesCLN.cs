using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;
using CLCAD.DSDoblones20GestionComercial2TableAdapters;

namespace CLCLN.GestionComercial
{
    public class TransaccionesUtilidadesCLN
    {        
        private QTAFuncionesSistema _adapterUtilidad = null;
        private ListarVentasProductosDetalleParaVentaTableAdapter _AdapterVentas = null;
        private DataTable DTVentasProductosDetalle = null;
        private ListarComprasProductosDetalleParaCompraTableAdapter _AdapterCompras = null;
        private DataTable DTComprasProductosDetalle = null;
        private ListarCotizacionesProductosDetalleParaCotizacionesTableAdapter _AdapterCotizaciones = null;
        private DataTable DTCotizacionesProductosDetalle = null;
        private VentasServiciosDetalleTableAdapter _AdapterVentasServicios = null;
        public  DataTable DTVentasServiciosDetalle = null;
        private PCsConfiguracionesTableAdapter _AdapterConfiguracionSistema = null; 
        private DataTable DTConfiguracionSistema = null;
        private FuncionesGestionComercial _AdapterFuncionesGestionComercial = null;
        private QTAFuncionesGestionComercial _AdapterFuncionesGestionComercial2 = null;

        private int CodigoMonedaSistema = -1;
        private int CodigoMonedaRegion = -1;
        private decimal PorcentajeImpuestoSistema = 0;


        protected QTAFuncionesGestionComercial AdapterFuncionesGestionComercial2
        {
            get
            {
                if (_AdapterFuncionesGestionComercial2 == null)
                    _AdapterFuncionesGestionComercial2 = new QTAFuncionesGestionComercial();
                return _AdapterFuncionesGestionComercial2;
            }
        }

        protected FuncionesGestionComercial AdapterFuncionesGestionComercial
        {
            get
            {
                if (_AdapterFuncionesGestionComercial == null)
                    _AdapterFuncionesGestionComercial = new FuncionesGestionComercial();
                return _AdapterFuncionesGestionComercial;
            }
        }
        protected QTAFuncionesSistema AdapterTransacciones
        {
            get
            {
                if (_adapterUtilidad == null)
                {
                    _adapterUtilidad = new QTAFuncionesSistema();
                }
                return _adapterUtilidad;
            }
        }
        protected ListarVentasProductosDetalleParaVentaTableAdapter AdapterVentas
        {
            get {
                if (_AdapterVentas == null)
                    _AdapterVentas = new ListarVentasProductosDetalleParaVentaTableAdapter();
                return _AdapterVentas;
            }
        }
        protected ListarComprasProductosDetalleParaCompraTableAdapter AdapterCompras
        {
            get
            {
                if (_AdapterCompras == null)
                    _AdapterCompras = new ListarComprasProductosDetalleParaCompraTableAdapter();
                return _AdapterCompras;
            }
        }
        protected ListarCotizacionesProductosDetalleParaCotizacionesTableAdapter AdapterCotizaciones
        {
            get
            {
                if (_AdapterCotizaciones == null)
                    _AdapterCotizaciones = new ListarCotizacionesProductosDetalleParaCotizacionesTableAdapter();
                return _AdapterCotizaciones;
            }
        }

        protected VentasServiciosDetalleTableAdapter AdapterVentasServicios
        {
            get
            {
                if (_AdapterVentasServicios == null)
                    _AdapterVentasServicios = new VentasServiciosDetalleTableAdapter();
                return _AdapterVentasServicios;
            }
        }

        protected PCsConfiguracionesTableAdapter AdapterConfiguracionSistema
        {
            get
            {
                if (_AdapterConfiguracionSistema == null)
                    _AdapterConfiguracionSistema = new PCsConfiguracionesTableAdapter();
                return _AdapterConfiguracionSistema;
            }
        }

             
        
        public TransaccionesUtilidadesCLN()
        {
            
        }

        
        /// <summary>
        /// Realiza la Busqueda de todos los Productos para una Transacción de acuerdo a los Criterios
        /// La Transacción puede ser : Ventas, Compras y Cotizaciones
        /// </summary>
        /// <param name="NumeroAgencia"> Numero de Agencia de la cual se debe buscar en Inventarios</param>
        /// <param name="TextoA_Buscar"> Texto de Busqueda</param>
        /// <param name="CantidadMinimaEnExistencia">Cantidad Minima que debe existir en Inventario para la Busqueda</param>
        /// <param name="CamposBusqueda">Que Campos seran buscados de acuerdo al parametro de busqueda
        ///     CamposBusqueda[0] = CodigoProducto
        ///     CamposBusqueda[1] = CodigoFrabricante
        ///     CamposBusqueda[2] = NombreProducto1
        ///     CamposBusqueda[3] = NombreProducto2
        ///     CamposBusqueda[4] = NombreProducto3 1:Realizar la Busqueda
        ///     CamposBusqueda[5] = Buscar en una Agencia  : 1:Buscar en la Agencia de dato de entrada, 0 Buscar en Todas las Agencias</param>
        /// <param name="ExactamenteIgual"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public System.Data.DataTable buscarProductoParaTransaccion(int NumeroAgencia, string TextoA_Buscar, int CantidadMinimaEnExistencia, string CamposBusqueda, bool ExactamenteIgual, int CodigoMonedaCotizacion)
        {
            return new BuscarProductosParaTransaccionTableAdapter().GetData(NumeroAgencia, TextoA_Buscar, CantidadMinimaEnExistencia, ExactamenteIgual, CamposBusqueda, CodigoMonedaCotizacion);
        }
               




        /// <summary>
        /// Realiza el Listado del Detalle de todas las Ventas de acuerdo al Numero de Agencia
        /// que se pasa como Parametro, Se Utiliza mas que todo para mostrar los Nombres de los Productos
        /// Vendidods y no así su Código
        /// </summary>
        /// <param name="NumeroAgencia">Número de Agencia para realizar el filtro correspondiente!</param>
        /// <returns> Detalle de Venta  DataTable </returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public System.Data.DataTable ListarDetalleDeVenta(int NumeroAgencia,int NumeroVenta)
        {
            DTVentasProductosDetalle = AdapterVentas.GetData(NumeroAgencia, NumeroVenta);
            return DTVentasProductosDetalle;
        }


        public DSDoblones20GestionComercial2.ReestablecerMonedaProductosDetalleTransaccionDataTable ReestablecerMonedaProductosDetalleTransaccion(
            int NumeroAgencia, string DetalleXML)
        {
            return new ReestablecerMonedaProductosDetalleTransaccionTableAdapter().GetData(
                NumeroAgencia, DetalleXML
                );
        }


        //
        /// <summary>
        /// Realiza el Listado del Detalle de todas las Compras de acuerdo al Numero de Agencia
        /// que se pasa como Parametro, Se Utiliza mas que todo para mostrar los Nombres de los Productos
        /// Comprados y no así su Código
        /// </summary>
        /// <param name="NumeroAgencia">Número de Agencia para realizar el filtro correspondiente!</param>
        /// <returns> Detalle de Venta  DataTable </returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public System.Data.DataTable ListarDetalleDeCompra(int NumeroAgencia, int NumeroCompraProducto)
        {        
            DTComprasProductosDetalle = AdapterCompras.GetData(NumeroAgencia, NumeroCompraProducto);
            return DTComprasProductosDetalle;
        }

        //
        /// <summary>
        /// Realiza el Listado del Detalle de todas las Cotizaciones de acuerdo al Numero de Agencia
        /// que se pasa como Parametro, Se Utiliza mas que todo para mostrar los Nombres de los Productos
        /// cotizados y no así su Código
        /// </summary>
        /// <param name="NumeroAgencia">Número de Agencia para realizar el filtro correspondiente!</param>
        /// <returns> Detalle de Venta  DataTable </returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public System.Data.DataTable ListarDetalleDeCotizacion(int NumeroAgencia, int NumeroCotizacionVentaProducto)
        {
            DTCotizacionesProductosDetalle = AdapterCotizaciones.GetData(NumeroAgencia, NumeroCotizacionVentaProducto);
            return DTCotizacionesProductosDetalle;
        }


        //
        /// <summary>
        /// Realiza el Listado del Detalle de las Cotizaciones de acuerdo al Numero de Agencia
        /// que se pasa como Parametro y el Numero de Cotización, Se Utiliza mas que todo para mostrar 
        /// el listado del Detalle de una Cotización y Transferirla a una Venta
        /// </summary>
        /// <param name="NumeroAgencia">Número de Agencia para realizar el filtro correspondiente!</param>
        /// <returns> Detalle de Venta  DataTable </returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public System.Data.DataTable ListarDetalleDeCotizacionParaVenta(int NumeroAgencia, int NumeroCotizacionVentaProducto)
        {            
            return AdapterCotizaciones.GetDataBy(NumeroAgencia, NumeroCotizacionVentaProducto);
        }

        /// <summary>
        /// Lista los productos Especificos de una Venta
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoProducto"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public System.Data.DataTable ListarProductosEspecificosDeVenta(int NumeroAgencia,string CodigoProducto)
        {
            ListarProductosEspecificosPorProductoTableAdapter Adapter = new ListarProductosEspecificosPorProductoTableAdapter();
            return Adapter.GetData(NumeroAgencia, CodigoProducto);            
        }

        /// <summary>
        /// Realiza la Busqueda de una Determinada Venta, de acuerdo a los patrones de busqueda
        /// </summary>
        /// <param name="CodigoAmbitoBusqueda"> Tipo Columna a Comparar -> 0:NombreProveedor, 1;NitProveedor, 2:CodigoProducto</param>
        /// <param name="TextoABuscar">Texto a Buscar, ya sea nombre, nit, o nombreProducto</param>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="NumeroCompraProducto">Numero de Compra </param>
        /// <param name="FechaInicio">Fecha de Inicio para comparar</param>
        /// <param name="FechaFin">Fecha de Finalizacion para el rango</param>
        /// <param name="ExactamenteIgual">Buscar Exactamente igual </param>
        /// <returns>Listado</returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public System.Data.DataTable BuscarComprasProductos(string CodigoAmbitoBusqueda, string TextoABuscar, int NumeroAgencia, int NumeroCompraProducto, DateTime FechaInicio, DateTime FechaFin, bool ExactamenteIgual, string CodigoEstadoTransaccion)
        {
            int? numero = null;
            if (NumeroCompraProducto != -1)
            {
                numero = NumeroCompraProducto;
            }
            return new BuscarTransaccionGCTableAdapter().GetData(CodigoAmbitoBusqueda, TextoABuscar, NumeroAgencia, numero, "C", FechaInicio, FechaFin, ExactamenteIgual, CodigoEstadoTransaccion);
        }

        /// <summary>
        /// Realiza la Busqueda de una Determinada Cotización, de acuerdo a los patrones de busqueda
        /// </summary>
        /// <param name="CodigoAmbitoBusqueda">Tipo Columna a Comparar -> 0:NombreCliente, 1;NitCliente, 2:CodigoProducto</param>
        /// <param name="TextoABuscar">Texto a Buscar, ya sea nombre, nit, o nombreProducto</param>
        /// <param name="NumeroAgencia"> Número de Agencia </param>
        /// <param name="NumeroCotizacionVentaProducto">Numero de Cotización de la Venta de los productos</param>
        /// <param name="FechaInicio">Fecha de Inicio para comparar</param>
        /// <param name="FechaFin">Fecha de Finalizacion para el rango</param>
        /// <param name="ExactamenteIgual">Buscar Exactamente igual </param>
        /// <returns>Listado</returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public System.Data.DataTable BuscarVentasCotizacionProductos(string CodigoAmbitoBusqueda, string TextoABuscar, int NumeroAgencia, int NumeroCotizacionVentaProducto, DateTime FechaInicio, DateTime FechaFin, bool ExactamenteIgual, string CodigoEstadoTransaccion)
        {
            int? numCotizacion = null;
            if (NumeroCotizacionVentaProducto != -1)
            {
                numCotizacion = NumeroCotizacionVentaProducto;
            }
            return new BuscarTransaccionGCTableAdapter().GetData(CodigoAmbitoBusqueda, TextoABuscar, NumeroAgencia, numCotizacion, "T", FechaInicio, FechaFin, ExactamenteIgual, CodigoEstadoTransaccion);
        }




        /// <summary>
        /// Realiza la Busqueda de una Determinada Venta, de acuerdo a los patrones de busqueda
        /// </summary>
        /// <param name="CodigoAmbitoBusqueda">Tipo Columna a Comparar -> 0:NombreCliente, 1;NitCliente, 2:CodigoProducto</param>
        /// <param name="TextoABuscar">Texto a Buscar, ya sea nombre, nit, o nombreProducto</param>
        /// <param name="NumeroAgencia"> Número de Agencia </param>
        /// <param name="NumeroCotizacionVentaProducto">Numero de Cotización de la Venta de los productos</param>
        /// <param name="FechaInicio">Fecha de Inicio para comparar</param>
        /// <param name="FechaFin">Fecha de Finalizacion para el rango</param>
        /// <param name="ExactamenteIgual">Buscar Exactamente igual </param>  
        /// <returns>Listado de Resultado de Ventas</returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public System.Data.DataTable BuscarVentasProductos(string CodigoAmbitoBusqueda, string TextoABuscar, int NumeroAgencia, int NumeroVentaProducto, DateTime FechaInicio, DateTime FechaFin, bool ExactamenteIgual, string CodigoEstadoTransaccion)
        {
            int? numVentaProducto = null; 
            if (NumeroVentaProducto != -1)
            {
                numVentaProducto = NumeroVentaProducto;
            }
            return new BuscarTransaccionGCTableAdapter().GetData(CodigoAmbitoBusqueda, TextoABuscar, NumeroAgencia, numVentaProducto, "V", FechaInicio, FechaFin, ExactamenteIgual, CodigoEstadoTransaccion);
        }

        /// <summary>
        /// Realiza la Busqueda de una Determinada Venta DE sERVICIOS, de acuerdo a los patrones de busqueda
        /// </summary>
        /// <param name="CodigoAmbitoBusqueda">Tipo Columna a Comparar -> 0:NombreCliente, 1;NitCliente, 2:Nombre Servicios</param>
        /// <param name="TextoABuscar">Texto a Buscar, ya sea nombre, nit, o nombreProducto</param>
        /// <param name="NumeroAgencia"> Número de Agencia </param>
        /// <param name="NumeroVentaServicio">Numero de Venta Servicio</param>
        /// <param name="FechaInicio">Fecha de Inicio para comparar</param>
        /// <param name="FechaFin">Fecha de Finalizacion para el rango</param>
        /// <param name="ExactamenteIgual">Buscar Exactamente igual </param>  
        /// <returns>Listado de Resultado de Ventas</returns>
        public System.Data.DataTable BuscarVentasServicios(string CodigoAmbitoBusqueda, string TextoABuscar, int NumeroAgencia, int NumeroVentaServicio, DateTime FechaInicio, DateTime FechaFin, bool ExactamenteIgual, string CodigoEstadoTransaccion)
        {
            int? numVentaProducto = null;
            if (NumeroVentaServicio != -1)
            {
                numVentaProducto = NumeroVentaServicio;
            }
            return new BuscarTransaccionGCTableAdapter().GetData(CodigoAmbitoBusqueda, TextoABuscar, NumeroAgencia, numVentaProducto, "S", FechaInicio, FechaFin, ExactamenteIgual, CodigoEstadoTransaccion);
        }

        /// <summary>
        /// Realiza la Busqueda de una Determinada Transferencia, de acuerdo a los patrones de busqueda
        /// </summary>
        /// <param name="CodigoAmbitoBusqueda">Tipo Columna a Comparar -> 0:NombreCliente, 1;NitCliente, 2:CodigoProducto</param>
        /// <param name="TextoABuscar">Texto a Buscar, ya sea nombre, nit, o nombreProducto</param>
        /// <param name="NumeroAgencia"> Número de Agencia </param>
        /// <param name="NumeroTransferenciaProducto">Numero de Transferencia de la Transferencia de los productos</param>
        /// <param name="FechaInicio">Fecha de Inicio para Transferencia</param>
        /// <param name="FechaFin">Fecha de Finalizacion para el rango</param>
        /// <param name="ExactamenteIgual">Buscar Exactamente igual </param>  
        /// <returns>Listado de Resultado de Transferencias</returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public System.Data.DataTable BuscarTransferenciasProductos(string CodigoAmbitoBusqueda, string TextoABuscar, int NumeroAgencia, int NumeroTransferenciaProducto, DateTime FechaInicio, DateTime FechaFin, bool ExactamenteIgual, string CodigoEstadoTransaccion)
        {
            int? numTransferenciaProducto = null;
            if (NumeroTransferenciaProducto != -1)
            {
                numTransferenciaProducto = NumeroTransferenciaProducto;
            }
            return new BuscarTransaccionGCTableAdapter().GetData(CodigoAmbitoBusqueda, TextoABuscar, NumeroAgencia, numTransferenciaProducto, "F", FechaInicio, FechaFin, ExactamenteIgual, CodigoEstadoTransaccion);
        }


        /// <summary>
        /// Realiza la Busqueda de una Determinada Devolucion de venta , de acuerdo a los patrones de busqueda
        /// </summary>
        /// <param name="CodigoAmbitoBusqueda">Tipo Columna a Comparar -> 0:NombreCliente, 1;NitCliente, 2:CodigoProducto</param>
        /// <param name="TextoABuscar">Texto a Buscar, ya sea nombre, nit, o nombreProducto</param>
        /// <param name="NumeroAgencia"> Número de Agencia </param>
        /// <param name="NumeroVentaDevolucion">Numero de Devolucion de una Devolucion de Venta de los productos</param>
        /// <param name="FechaInicio">Fecha de Inicio para comparar</param>
        /// <param name="FechaFin">Fecha de Finalizacion para el rango</param>
        /// <param name="ExactamenteIgual">Buscar Exactamente igual </param>  
        /// <returns>Listado de Resultado de Ventas</returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public System.Data.DataTable BuscarVentasDevolucionesProductos(string CodigoAmbitoBusqueda, string TextoABuscar, int NumeroAgencia, int NumeroVentaDevolucion, DateTime FechaInicio, DateTime FechaFin, bool ExactamenteIgual, string CodigoEstadoTransaccion)
        {
            int? numDevolucion = null;
            if (NumeroVentaDevolucion != -1)
            {
                numDevolucion = NumeroVentaDevolucion; 
            }
            return new BuscarTransaccionGCTableAdapter().GetData(CodigoAmbitoBusqueda, TextoABuscar, NumeroAgencia, numDevolucion, "D", FechaInicio, FechaFin, ExactamenteIgual, CodigoEstadoTransaccion);
        }


        /// <summary>
        /// Realiza la Busqueda de una Determinada Venta, de acuerdo a los patrones de busqueda
        /// </summary>
        /// <param name="CodigoAmbitoBusqueda">Tipo Columna a Comparar -> 0:NombreCliente, 1;NitCliente, 2:CodigoProducto</param>
        /// <param name="TextoABuscar">Texto a Buscar, ya sea nombre, nit, o nombreProducto</param>
        /// <param name="NumeroAgencia"> Número de Agencia </param>
        /// <param name="NumeroCompraDevolucion">Numero de Devolucion de una Compra de productos</param>
        /// <param name="FechaInicio">Fecha de Inicio para comparar</param>
        /// <param name="FechaFin">Fecha de Finalizacion para el rango</param>
        /// <param name="ExactamenteIgual">Buscar Exactamente igual </param>  
        /// <returns>Listado de Resultado de Ventas</returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public System.Data.DataTable BuscarComprasDevolucionesProductos(string CodigoAmbitoBusqueda, string TextoABuscar, int NumeroAgencia, int NumeroCompraDevolucion, DateTime FechaInicio, DateTime FechaFin, bool ExactamenteIgual, string CodigoEstadoTransaccion)
        {
            int? numDevolucion = null;
            if (NumeroCompraDevolucion != -1)
            {
                numDevolucion = NumeroCompraDevolucion;
            }
            return new BuscarTransaccionGCTableAdapter().GetData(CodigoAmbitoBusqueda, TextoABuscar, NumeroAgencia, numDevolucion, "P", FechaInicio, FechaFin, ExactamenteIgual, CodigoEstadoTransaccion);
        }


        /// <summary>
        /// Realiza la Obtención del Indice Actual de la Tabla
        /// En caso de que la Tabla este vacia, retorna 1,
        /// Solo para Tablas que poseen Llaves Primarias con la Propiedad Identity
        /// </summary>
        /// <param name="NombreTabla">Nombre de la Tabla</param>
        /// <returns>Indice Actual de la Tabla</returns>
        public int ObtenerUltimoIndiceTabla(string NombreTabla)
        {
            decimal? indice = 0;
            this.AdapterTransacciones.ObtenerUltimoIndiceTabla(NombreTabla, ref indice);            
            return (int)indice;
        }


        /// <summary>
        /// Retorna la Fecha la Hora del Servidor
        /// </summary>
        /// <returns>Fecha del Servidor</returns>
        public DateTime ObtenerFechaHoraServidor()
        {            
            DateTime? fecha = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            AdapterTransacciones.ObtenerFechaHoraServidor(ref fecha);  //OtenerFechaHoraServidor(ref fecha);
            return (DateTime)fecha;
        }


        /// <summary>
        /// Se realiza la Correspondiente Actualización de Inventarios de la Venta Realizada
        /// Disminuyendo la Cantidad de Existencia de los Productos Vendidos
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia de donde se Venden los Productos de Inventarios</param>
        /// <param name="NumeroVenta">Numero de Venta</param>
        public void ActualizarInventarioProductosVentas(int NumeroAgencia, int NumeroVenta)
        {
            AdapterTransacciones.ActualizarInventarioProductosVentas(NumeroAgencia, NumeroVenta);
        }


        /// <summary>
        /// Se realiza la Correspondiente Actualización de Inventarios de la Compra Realizada
        /// Incrementando la Cantidad de Existencia de los Productos en Inventarios
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia hacia donde los Productos de Inventarios serán Actualizados</param>
        /// <param name="NumeroVenta">Numero de Compra</param>
        public void ActualizarInventarioProductosCompras(int NumeroAgencia, int NumeroVenta, string ListadoCodigos)
        {            
            AdapterTransacciones.ActualizarInventarioProductosCompras(NumeroAgencia, NumeroVenta, ListadoCodigos); 
        }


        /// <summary>
        /// Realiza la actualización de Inventario para una Devolucion de Compra o Venta
        /// mediante el incremento o el decremento de existencia del producto
        /// colocando en caso de ser necesario el Estado de un Producto Específico
        /// en un caso de rehabilitación o darlo de baja de acuerdo
        /// al tipo de Transacción
        /// </summary>
        /// <param name="NumeroAgencia"> Numero de Agencia </param>
        /// <param name="NumeroTransaccion">Numero de Devolución de Compra o Venta, o Devolución </param>
        /// <param name="TipoTransaccion">Tipo de Transacción :  'C'-> Compras,  'V'-> Ventas, 'D'-> Devolución</param>
        public void ActualizarInventarioProductosDevoluciones(int NumeroAgencia, int NumeroTransaccion, string TipoTransaccion)
        {
            AdapterFuncionesGestionComercial.ActualizarInventarioProductosDevoluciones(NumeroAgencia, NumeroTransaccion, TipoTransaccion);
        }

        /// <summary>
        /// Realizar la Actualización de Inventarios despues de haber seleccionado
        /// los productos que Reemplazaron a los productos devueltos en una devolución
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroReemplazo"></param>
        public void ActualizarInventarioProductosReemplazo(int NumeroAgencia, int NumeroReemplazo)
        {
            AdapterFuncionesGestionComercial.ActualizarInventarioProductosReemplazo(NumeroAgencia, NumeroReemplazo);
        }


        /// <summary>
        /// Actualizar Inventario por Transferencia de Productos
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia, de acuerdo si es Emisora o Receptora de Mercadería de Productos</param>
        /// <param name="NumeroTransferenciaProducto">Numero de Transferencia</param>
        /// <param name="CodigoTipoEnvioRecepcion">Tipo de Acción que se debe realizar de acuerdo a que Agencia realiza la operación
        /// si la Agencia es "Emisora" -> 'E'  ; o en todo caso, "Receptora" -> 'R'</param>
        /// <param name="ListadoCodigos"> Listado de Codigos que se deben Actualizar y las opciones de Actualización
        /// por ejemplo : '263;100| 463;100|482;100' implica los codigos (263,463,482) y por cada uno su opcion '100' implica
        /// actualizar el precio de Compra</param>
        public void ActualizarInventariosTransferenciaProductos(int NumeroAgencia, int NumeroTransferenciaProducto, string CodigoTipoEnvioRecepcion	, string ListadoCodigos)
        {
            AdapterFuncionesGestionComercial2.ActualizarInventariosTransferenciaProductos(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion, ListadoCodigos);
        }

        /// <summary>
        /// Si el Producto a buscar es Producto Especifico
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoProducto"></param>
        /// <returns></returns>
        public bool esProductoEspecifico(int NumeroAgencia, string CodigoProducto)
        {
            bool? esVerdad = false;
            esVerdad = AdapterTransacciones.EsProductoEspecifico(NumeroAgencia, CodigoProducto);
            if (esVerdad == null)
                return false;
            else
                return (bool)esVerdad;
            
        }

        /// <summary>
        /// Realiza el Listado de todos los Productos disponibles para
        /// Venta o Compras (Cotizaciones)
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable ListarProductosCodigoNombre(bool esParaVenta)
        {
            return new ListarProductosCodigoNombreTableAdapter().GetData(esParaVenta);
        }

        /// <summary>
        /// Realiza la busqueda de un producto que haya sido vendido o comprado para ser devueltos de acuardo al
        /// tipo de transacción
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="NumeroTransaccion">Numero de Venta o Compra</param>
        /// <param name="CodigoAmbitoBusqueda">en que Campos se Buscarana : '0' -> CodigoProducto, '1' Codigo Producto Especifico, '2' CodigoProducto</param>
        /// <param name="TextoABuscar">Texto a buscar</param>
        /// <param name="TipoTransaccion"> De donde se realizará la Devolución : 'V' Venta, 'D' Devolucion, 'A' Agregado, 'C' Venta, 'G' Agregado </param>
        /// <param name="ExactamenteIgual">Busqueda por el campo de manera exacta o similar</param>
        /// <returns>DataTable con los datos Encontrados</returns>
        public System.Data.DataTable BuscarProductoTransaccionDevolucion(int NumeroAgencia, int NumeroTransaccion, String CodigoAmbitoBusqueda, string TextoABuscar, string TipoTransaccion, bool ExactamenteIgual)
        {
            if (TipoTransaccion.CompareTo("V") == 0 || TipoTransaccion.CompareTo("D") == 0 || TipoTransaccion.CompareTo("A") == 0)
                return new BuscarProductoTransaccionVentaDevolucionTableAdapter().GetData(CodigoAmbitoBusqueda, TextoABuscar, NumeroAgencia, NumeroTransaccion, TipoTransaccion, ExactamenteIgual);
            else if (TipoTransaccion.CompareTo("C") == 0 || TipoTransaccion.CompareTo("G") == 0)
                return new BuscarProductoTransaccionCompraDevolucionTableAdapter().GetData(NumeroAgencia, NumeroTransaccion, CodigoAmbitoBusqueda, TextoABuscar, TipoTransaccion, ExactamenteIgual);
            else
                return null;
        }


        /// <summary>
        /// Realiza la busqueda de un producto que haya sido comprado para ser devueltos de acuardo al
        /// tipo de transacción
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="NumeroTransaccion">Numero de Venta o Compra</param>
        /// <param name="CodigoAmbitoBusqueda">en que Campos se Buscarana : '0' -> CodigoProducto, '1' Codigo Producto Especifico, '2' CodigoProducto</param>
        /// <param name="TextoABuscar">Texto a buscar</param>
        /// <param name="TipoTransaccion"> De donde se realizará la Devolución : 'C' Venta, 'G' Agregado </param>
        /// <param name="ExactamenteIgual">Busqueda por el campo de manera exacta o similar</param>
        /// <returns>DataTable con los datos Encontrados</returns>
        public System.Data.DataTable BuscarProductoTransaccionCompraDevolucion(int NumeroAgencia, int NumeroTransaccion, String CodigoAmbitoBusqueda, string TextoABuscar, string TipoTransaccion, bool ExactamenteIgual)
        {
            return new BuscarProductoTransaccionVentaDevolucionTableAdapter().GetData(CodigoAmbitoBusqueda, TextoABuscar, NumeroAgencia, NumeroTransaccion, TipoTransaccion, ExactamenteIgual);
        }


        /// <summary>
        /// Realiza la Busqueda de Productos Especificos que pueden ser reemplazados por uno ya vendido o comprado
        /// dentro de Inventarios
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="TextoABuscar">Texto a Buscar </param>
        /// <param name="CantidadExistencia">que cantidad como minima se debe buscar</param>
        /// <param name="ExactamenteIgual">Busqueda por el campo de manera exacta o similar</param>
        /// <param name="CamposBusqueda">Que Campos seran buscados de acuerdo al parametro de busqueda, '1' significa que se buscara ese campo, '0' se lo ignorará
        ///     CamposBusqueda[0] = CodigoProducto
        ///     CamposBusqueda[1] = CodigoProductoEspecifico
        ///     CamposBusqueda[2] = NombreProducto1
        ///     CamposBusqueda[3] = NombreProducto2
        ///     CamposBusqueda[4] = NombreProducto3 
        ///     CamposBusqueda[5] = Buscar en una Agencia  : 1:Buscar en la Agencia de dato de entrada, 0 Buscar en Todas las Agencias</param>
        /// <returns></returns>
        public System.Data.DataTable BuscarProductosParaTransaccionDevolucionReem(int NumeroAgencia, string TextoABuscar, int CantidadExistencia, bool ExactamenteIgual, string CamposBusqueda)
        {
            return new BuscarProductosParaTransaccionDevolucionReemTableAdapter().GetData(NumeroAgencia, TextoABuscar, CantidadExistencia, ExactamenteIgual, CamposBusqueda);
        }


        /// <summary>
        ///  Realiza el Listado del Detalle de todas las Devoluciones de Ventas de acuerdo al Numero de Agencia
        /// que se pasa como Parametro, Se Utiliza mas que todo para mostrar los Nombres de los Productos
        /// Cambiados y no así su Código
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia </param>
        /// <param name="NumeroReemDevo">Numero de Devolución de Venta</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public System.Data.DataTable ListarDetalleDeVentaProductosReemDevo(int NumeroAgencia, int NumeroReemDevo)
        {
            ListarVentasProductosReemDevoParaVentaDevolucionTableAdapter Adapter = new ListarVentasProductosReemDevoParaVentaDevolucionTableAdapter();
            return Adapter.GetData(NumeroAgencia, NumeroReemDevo);            
        }


        /// <summary>
        /// Realiza la busqueda del codigoEspecifico de un producto
        /// para cerciorar su existencia en Inventario de Productos Especificos
        /// </summary>
        /// <param name="CodigoProductoEspecifico">Codigo Especifico del Producto</param>
        /// <returns>returna si su existencia esta confirmada</returns>
        public bool ExisteCodigoProductoEspecificoEnInventario(int NumeroAgencia, string CodigoProductoEspecifico)
        {
            bool? existe = false;
            AdapterFuncionesGestionComercial.ExisteCodigoProductoEspecificoEnInventario(NumeroAgencia, CodigoProductoEspecifico, ref existe);
            return (bool)existe;
        }

        
        /// <summary>
        /// Obtiene el Nombre del Producto a Partir de su Codigo Especifico
        /// </summary>
        /// <param name="CodigoProductoEspecifico">Codigo Especifico del Producto</param>
        /// <returns>Nombre del Producto</returns>
        public string ObtenerNombreProductoPorCodigoProductoEspecifico(string CodigoProductoEspecifico)
        {
            string NombreProducto = "";
            _AdapterFuncionesGestionComercial.ObtenerNombreProductoPorCodigoProductoEspecifico(CodigoProductoEspecifico, ref NombreProducto);
            return NombreProducto;
        }


        /// <summary>
        /// Obtiene el Código del Producto a Partir de su Codigo Especifico
        /// </summary>
        /// <param name="CodigoProductoEspecifico">Codigo Especifico del Producto</param>
        /// <returns>Codigo del Producto</returns>
        public string ObtenerCodigoProductoPorCodigoProductoEspecifico(int NumeroAgencia, string CodigoProductoEspecifico)
        {
            string CodigoProducto = "";
            AdapterFuncionesGestionComercial.ObtenerCodigoProductoPorCodigoProductoEspecifico(NumeroAgencia, CodigoProductoEspecifico, ref CodigoProducto);
            return CodigoProducto;
        }

        /// <summary>
        /// Realiza el Listado del Código de Productos Especificos para Imprimir su Codigo de Barras en un reporte
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroCompraProducto"></param>
        /// <param name="CodigoProducto"></param>
        /// <param name="CodigoProductoEspecifico"></param>
        /// <returns></returns>
        public System.Data.DataTable ListarDatosCodigosProductosEspecificosReporte(int NumeroAgencia, int? NumeroCompraProducto, string CodigoProducto, string CodigoProductoEspecifico)
        {
            return new ListarDatosCodigosProductosEspecificosReporteTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto, CodigoProducto, CodigoProductoEspecifico);
        }


        /// <summary>
        /// Cambia el Precio de una Transacción para visualizar en distintos tipos de monedas
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoMonedaCambio"></param>
        /// <param name="FechaCambioMonedaCotizacion"></param>
        /// <param name="incluirIVA"></param>
        /// <returns></returns>
        public System.Data.DataTable CambiarMonedaCotizacionDetalleDeTransaccion(int NumeroAgencia, int CodigoMonedaCambio, DateTime? FechaCambioMonedaCotizacion,bool incluirIVA, char tipoTransaccion, int NumeroTransaccion, bool desdeBD)
        {
            string PrecioTransaccion = "";
            DataTable DTCotizacionTemporal = null;

            if (CodigoMonedaSistema == -1)
            {
                ObtenerSistemaConfiguracionParaTransacciones(NumeroAgencia);
            }

            switch (tipoTransaccion)
            {
                case 'V':
                    PrecioTransaccion = "PrecioUnitarioVenta";
                    DTCotizacionTemporal = this.DTVentasProductosDetalle.Copy();
                    break;
                case 'C':
                    PrecioTransaccion = "PrecioUnitarioCompra";
                    DTCotizacionTemporal = this.DTComprasProductosDetalle.Copy();
                    break;
                case 'T':
                    PrecioTransaccion = "PrecioUnitarioCotizacionVenta";
                    DTCotizacionTemporal = this.DTCotizacionesProductosDetalle.Copy();
                    break;
                case 'S':
                    PrecioTransaccion = "PrecioUnitario";
                    DTCotizacionTemporal = this.DTVentasServiciosDetalle.Copy();
                    break;
            }

            if (desdeBD)// si la conversión de los precios  a las monedades se debe hacer en la base de datos
            {
                
                DataTable DTPrecioCotizados = new ListarPreciosMonedaCotizacionTableAdapter().GetData(NumeroAgencia, NumeroTransaccion, CodigoMonedaCambio, FechaCambioMonedaCotizacion, false, tipoTransaccion.ToString());
                for (int i = 0; i < DTPrecioCotizados.Rows.Count; i++)
                {
                    DTCotizacionTemporal.Rows[i][PrecioTransaccion] = DTPrecioCotizados.Rows[i][PrecioTransaccion];
                }
            }
            else // si se debe hacer la conversión
            {
                FechaCambioMonedaCotizacion = FechaCambioMonedaCotizacion == null ? (DateTime?)null : FechaCambioMonedaCotizacion;
                //decimal FactorDeCambio = (decimal)AdapterFuncionesGestionComercial.ObtenerFactorCambioCotizacion((byte)CodigoMonedaSistema, FechaCambioMonedaCotizacion, (byte)CodigoMonedaCambio);
                decimal? Factor = -1;
                AdapterFuncionesGestionComercial.ObtenerFactorCambioCotizacion((byte)CodigoMonedaSistema, FechaCambioMonedaCotizacion, (byte)CodigoMonedaCambio, ref Factor);
                decimal FactorDeCambio = -1;
                if (!Decimal.TryParse(Factor.Value.ToString(), out FactorDeCambio) || FactorDeCambio <= 0)
                {
                    //return null;
                    Factor = -1;
                    AdapterFuncionesGestionComercial.ObtenerFactorCambioCotizacion((byte)CodigoMonedaSistema, null, (byte)CodigoMonedaCambio, ref Factor);
                    FactorDeCambio = Factor.Value;
                }
                decimal PrecioProducto = 0;
                if (incluirIVA)
                {
                    foreach (DataRow fila in DTCotizacionTemporal.Rows)
                    {
                        PrecioProducto = Decimal.Parse(fila[PrecioTransaccion].ToString());
                        //fila[PrecioTransaccion] = Decimal.Round((PrecioProducto * FactorDeCambio + (PrecioProducto * PorcentajeImpuestoSistema / 100)),2) ;
                        fila[PrecioTransaccion] = Decimal.Round((PrecioProducto + (PrecioProducto * PorcentajeImpuestoSistema / 100)) * FactorDeCambio, 2);
                    }
                }
                else
                {
                    foreach (DataRow fila in DTCotizacionTemporal.Rows)
                    {
                        PrecioProducto = Decimal.Parse(fila[PrecioTransaccion].ToString());
                        fila[PrecioTransaccion] = Decimal.Round((PrecioProducto * FactorDeCambio), 2);
                    }
                }

            }
            return DTCotizacionTemporal;
        }


        public System.Data.DataTable CambiarMonedaCotizacionDetalleDeTransaccionTemporal(DataTable DetalleTransaccionTemporal, int NumeroAgencia, int CodigoMonedaCambio, DateTime? FechaCambioMonedaCotizacion, bool incluirIVA, bool desdeBD)
        {
            if (CodigoMonedaSistema == -1)
            {
                ObtenerSistemaConfiguracionParaTransacciones(NumeroAgencia);
            }
            FechaCambioMonedaCotizacion = FechaCambioMonedaCotizacion == null ? (DateTime?)null : FechaCambioMonedaCotizacion;
            //decimal FactorDeCambio = (decimal)AdapterFuncionesGestionComercial.ObtenerFactorCambioCotizacion((byte)CodigoMonedaSistema, FechaCambioMonedaCotizacion, (byte)CodigoMonedaCambio);
            decimal? Factor = -1;
            AdapterFuncionesGestionComercial.ObtenerFactorCambioCotizacion((byte)CodigoMonedaSistema, FechaCambioMonedaCotizacion, (byte)CodigoMonedaCambio, ref Factor);
            decimal FactorDeCambio = -1;
            if (!Decimal.TryParse(Factor.Value.ToString(), out FactorDeCambio) || FactorDeCambio <= 0)
            {
                //return null;
                Factor = -1;
                AdapterFuncionesGestionComercial.ObtenerFactorCambioCotizacion((byte)CodigoMonedaSistema, null, (byte)CodigoMonedaCambio, ref Factor);
                FactorDeCambio = Factor.Value;
            }
            DataTable DTCotizacionTemporal = DetalleTransaccionTemporal.Copy();

            if (desdeBD)
            {
                string ListadoPrecios = "";
                foreach (DataRow FilaPrecios in DTCotizacionTemporal.Rows)
                {
                    //ListadoPrecios += FilaPrecios["Precio"].ToString().Trim() + "-" + FilaPrecios["PrecioTotal"].ToString().Trim() + ";";
                    ListadoPrecios += FilaPrecios["Precio"].ToString().Trim() + "-" + FilaPrecios["Cantidad"].ToString().Trim() + ";";
                }
                
                if(ListadoPrecios.Length >0)
                    ListadoPrecios = ListadoPrecios.Substring(0, ListadoPrecios.Length - 1);
                DataTable DTPreciosCotizacion = new ObtenerTablaTemporalCotizacionPreciosOtraMonedaTableAdapter().GetData(ListadoPrecios, ";", NumeroAgencia, incluirIVA, FactorDeCambio);
                if (String.IsNullOrEmpty(DTCotizacionTemporal.Columns["PrecioTotal"].Expression))
                    DTCotizacionTemporal.Columns["PrecioTotal"].ReadOnly = false;
                for (int i = 0; i < DTPreciosCotizacion.Rows.Count; i++)
                {
                    DTCotizacionTemporal.Rows[i]["Precio"] = DTPreciosCotizacion.Rows[i]["Precio"];
                    DTCotizacionTemporal.Rows[i]["PrecioTotal"] = DTPreciosCotizacion.Rows[i]["PrecioTotal"];
                }
                if (String.IsNullOrEmpty(DTCotizacionTemporal.Columns["PrecioTotal"].Expression))
                    DTCotizacionTemporal.Columns["PrecioTotal"].ReadOnly = true;
            }
            else
            {
                decimal PrecioProducto = 0;
                int cantidad = 0;
                decimal NuevoPrecio = 0;
                if (String.IsNullOrEmpty(DTCotizacionTemporal.Columns["PrecioTotal"].Expression))
                    DTCotizacionTemporal.Columns["PrecioTotal"].ReadOnly = false;
                if (incluirIVA)
                {
                    foreach (DataRow fila in DTCotizacionTemporal.Rows)
                    {
                        PrecioProducto = Decimal.Parse(fila["Precio"].ToString());
                        cantidad = Int32.Parse(fila["Cantidad"].ToString());
                        NuevoPrecio = (PrecioProducto + (PrecioProducto * PorcentajeImpuestoSistema / 100)) * FactorDeCambio;
                        //NuevoPrecio = (PrecioProducto * FactorDeCambio)+ (PrecioProducto * FactorDeCambio * PorcentajeImpuestoSistema / 100) ;
                        fila["Precio"] = Decimal.Round(NuevoPrecio, 2);
                        if (String.IsNullOrEmpty(DTCotizacionTemporal.Columns["PrecioTotal"].Expression))
                            fila["PrecioTotal"] = Decimal.Round((NuevoPrecio * cantidad), 2);
                    }
                }
                else
                {
                    foreach (DataRow fila in DTCotizacionTemporal.Rows)
                    {
                        PrecioProducto = Decimal.Parse(fila["Precio"].ToString());
                        cantidad = Int32.Parse(fila["Cantidad"].ToString());
                        NuevoPrecio = PrecioProducto * FactorDeCambio;
                        fila["Precio"] = Decimal.Round(NuevoPrecio, 2);
                        if (String.IsNullOrEmpty(DTCotizacionTemporal.Columns["PrecioTotal"].Expression))
                            fila["PrecioTotal"] = Decimal.Round((NuevoPrecio * cantidad), 2);
                    }
                }
                if (String.IsNullOrEmpty(DTCotizacionTemporal.Columns["PrecioTotal"].Expression))
                    DTCotizacionTemporal.Columns["PrecioTotal"].ReadOnly = true;
            }
            return DTCotizacionTemporal;
        }

        /// <summary>
        /// Obtiene la Configuración del Sistema.
        /// Los Siguientes Campos son Devueltos en el DataTable : CodigoMonedaSistema, NombreMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema
        /// </summary>
        /// <param name="NumeroAgencia">Numero de agencia de la cual se quiere obtener su configuracion</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerSistemaConfiguracionParaTransacciones(int NumeroPc)
        {
            /*
             * VariablesConfiguracionGCTableAdapter VCGCTA = new VariablesConfiguracionGCTableAdapter();
            return VCGCTA.GetData(NumeroPC);
             */
            VariablesConfiguracionGCTableAdapter VCGCTA = new VariablesConfiguracionGCTableAdapter();
            //DTConfiguracionSistema = AdapterConfiguracionSistema.GetDataByObtenerConfiguracionSistemaParaTransaccionesGC(NumeroPc);
            DTConfiguracionSistema = VCGCTA.GetData(NumeroPc);
            CodigoMonedaSistema = Int32.Parse(DTConfiguracionSistema.Rows[0]["CodigoMonedaSistema"].ToString());
            CodigoMonedaRegion = Int32.Parse(DTConfiguracionSistema.Rows[0]["CodigoMonedaRegion"].ToString());
            this.PorcentajeImpuestoSistema = Decimal.Parse(DTConfiguracionSistema.Rows[0]["PorcentajeImpuestoSistema"].ToString());
            return DTConfiguracionSistema;

        }

        /// <summary>
        /// Se encarga de obtener el factor de cambio para una Cotizacion u otra Transacción
        /// </summary>
        /// <param name="CodigoMoneda">Moneda que maneja el Sistema</param>
        /// <param name="FechaHoraCotizacion">Fecha del Cambio de cotizacion</param>
        /// <param name="CodigoMonedaCotizacion">Moneda a la cual se desea llevar la cotizacion</param>
        /// <returns>Factor de Cambio</returns>
        public decimal ObtenerFactorCambioCotizacion(int CodigoMoneda , DateTime? FechaHoraCotizacion , int CodigoMonedaCotizacion)
        {
            decimal? FactorCambio = -1;
            AdapterFuncionesGestionComercial.ObtenerFactorCambioCotizacion((byte)CodigoMoneda, FechaHoraCotizacion, (byte)CodigoMonedaCotizacion, ref FactorCambio);
            return FactorCambio.Value;
        }


        /// <summary>
        /// Retorna todos los Productos con Codigos Especificos disponibles a ser devueltos
        /// en en una Devolucion de un determinado Producto
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="NumeroTransaccion">Numero de Transaccion : Venta, Compra, Devolucion </param>
        /// <param name="TipoTransaccion"> Tipo de Transacción
        ///     'C' --> PARA LAS COMPRAS DE PRODUCTO ESPECIFICOS
        ///     'G' --> PARA LAS COMPRAS DE PRODUCTO AGREGADOS ESPECIFICOS
        ///     'V' --> PARA LAS VENTAS DE PRODUCTO ESPECIFICOS
        ///     'T' --> PARA LAS VENTAS DE PRODUCTO ESPECIFICOS AGREGADOS
        ///     'D' --> PARA LAS DEVOLUCIONES DE PRODUCTO ESPECIFICOS
        /// </param>
        /// <param name="CodigoProducto">producto del cual se tiene que seleccionar </param>
        /// <returns></returns>
        public DataTable ObtenerCodigoProductoEspecificoParaDevolucion(int NumeroAgencia, int NumeroTransaccion, string TipoTransaccion, string CodigoProducto)
        {
            return new ObtenerCodigoProductoEspecificoParaDevolucionTableAdapter().GetData(NumeroAgencia, NumeroTransaccion, TipoTransaccion, CodigoProducto);
        }


        /// <summary>
        /// Realiza la consulta para verificar que es necesario llenarlos productos especificos
        /// al momento de entregar una venta
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroVentaProducto"></param>
        /// <returns></returns>
        public bool esNecesarioLlenarProductosEspecificos(int NumeroAgencia, int NumeroVentaProducto)
        {
            bool? necesario = AdapterFuncionesGestionComercial.esNecesarioLlenarProductosEspecificos(NumeroAgencia, NumeroVentaProducto);
            return necesario.Value;
        }


        /// <summary>
        /// Obtener el precio Mínimo de Venta de un Producto
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoProducto"></param>
        /// <returns></returns>
        public decimal ObtenerPrecioMinimoDeProducto(int NumeroAgencia, string CodigoProducto)
        {
            return AdapterFuncionesGestionComercial.ObtenerPrecioMinimoDeProducto(NumeroAgencia, CodigoProducto).Value;
        }

        /// <summary>
        /// Obtener el Precio Mayo de Venta de un Producto en Inventarios
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoProducto"></param>
        /// <returns></returns>
        public decimal ObtenerPrecioMaximoDeProducto(int NumeroAgencia, string CodigoProducto)
        {
            return AdapterFuncionesGestionComercial.ObtenerPrecioMaximoDeProducto(NumeroAgencia, CodigoProducto).Value;
        }

        /// <summary>
        /// Retorna la existencia Actual del Producto en Inventario
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoProducto"></param>
        /// <returns></returns>
        public int ObtenerExistenciaProductoInventario(int NumeroAgencia, string CodigoProducto)
        {
            return AdapterFuncionesGestionComercial.ObtenerExistenciaProductoInventario(NumeroAgencia, CodigoProducto).Value;
        }

        /// <summary>
        /// Obtiene el CodigoEstado  de una Venta, Compra, u otra transacción
        /// de acuerdo al parametro introducido
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroTransaccion"></param>
        /// <param name="CodigoTipoTransaccion"> Tipo de Transacción, por ejemplo, "V"->Ventas, "C"->Compras, "T"->cotizaciones, "E"->Transferencias de Envio , "R" ->Transferencias Recepcion etc</param>
        /// <returns></returns>
        public string ObtenerCodigoEstadoActualTransacciones(int NumeroAgencia, int NumeroTransaccion, string CodigoTipoTransaccion)
        {
            return AdapterFuncionesGestionComercial.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroTransaccion, CodigoTipoTransaccion);
        }

        public DataTable ObtenerListaProductosParaCambiarMoneda(int NumeroAgencia, DateTime? FechaCambioMonedaCotizacion, DataTable DTListaProductos)
        {
            if (CodigoMonedaSistema == -1)
            {
                ObtenerSistemaConfiguracionParaTransacciones(NumeroAgencia);
            }

            if (CodigoMonedaRegion == CodigoMonedaSistema)
                return DTListaProductos;
            else
            {
                string PrecioTransaccion = "";
                DataTable DTCotizacionTemporal = null;
                PrecioTransaccion = "PrecioUnitarioVenta";
                DTCotizacionTemporal = DTListaProductos.Copy();                
                FechaCambioMonedaCotizacion = FechaCambioMonedaCotizacion == null ? (DateTime?)null : FechaCambioMonedaCotizacion;
                //decimal FactorDeCambio = (decimal)AdapterFuncionesGestionComercial.ObtenerFactorCambioCotizacion((byte)CodigoMonedaSistema, FechaCambioMonedaCotizacion, (byte)CodigoMonedaCambio);
                decimal? Factor = -1;

                AdapterFuncionesGestionComercial.ObtenerFactorCambioCotizacion((byte)CodigoMonedaRegion, FechaCambioMonedaCotizacion, (byte)CodigoMonedaSistema, ref Factor);
                decimal FactorDeCambio = -1;
                if (!Decimal.TryParse(Factor.Value.ToString(), out FactorDeCambio) || FactorDeCambio <= 0)
                    return null;
                decimal PrecioProducto = 0;
                DTCotizacionTemporal.Columns["PrecioUnitarioVenta"].ReadOnly = false;
                DTCotizacionTemporal.Columns["PrecioTotalVenta"].ReadOnly = false;
                foreach (DataRow fila in DTCotizacionTemporal.Rows)
                {
                    PrecioProducto = Decimal.Parse(fila[PrecioTransaccion].ToString());
                    fila[PrecioTransaccion] = Decimal.Round((PrecioProducto * FactorDeCambio), 2);
                    fila["PrecioTotalVenta"] = Decimal.Round((PrecioProducto * FactorDeCambio), 2) * int.Parse(fila["CantidadVenta"].ToString());
                }

                return DTCotizacionTemporal;
            }            
        }

        public void ActualizarInventarioProductosEspecficosVendidos(int NumeroAgencia, int NumeroVentaProducto)
        {
            AdapterFuncionesGestionComercial.ActualizarInventarioProductosEspecficosVendidos(NumeroAgencia, NumeroVentaProducto);
        }

        public int ObtenerUltimoIndiceTransaccionFuncion(string CodigoTipoTransaccion , string @CodigoEstadoTransaccion)
        {
            return AdapterFuncionesGestionComercial.ObtenerUltimoIndiceTransaccionFuncion(CodigoTipoTransaccion, CodigoEstadoTransaccion).Value;
        }

        public DataTable ListarBusquedaProductos(string CodigoAmbitoBusqueda, string TextoABuscar, bool ExactamenteIgual, int? NumeroAgencia, int? CodigoMonedaCotizacion, bool ConExistencia)
        {
            return new ListarBusquedaProductosTableAdapter().GetData(CodigoAmbitoBusqueda, TextoABuscar, ExactamenteIgual, NumeroAgencia, CodigoMonedaCotizacion, ConExistencia);
        }

        public decimal ObtenerPrecioRelativoProducto(int NumeroAgencia, string @CodigoProducto, string @TipoPrecioSeleccionado, bool PrecioConFactura)
        {
            return AdapterFuncionesGestionComercial.ObtenerPrecioRelativoProducto(NumeroAgencia, CodigoProducto, TipoPrecioSeleccionado, PrecioConFactura).Value;
        }


        /// <summary>
        /// Obtener el Monto Total de Credito que se ha asignado a un cliente
        /// </summary>
        /// <param name="NumeroCredito"></param>
        /// <returns></returns>
        public decimal ObtenerMontoDeudaCredito(int? NumeroCredito)
        {
            return new QTAFuncionesSistema().ObtenerMontoDeudaCredito(NumeroCredito).Value;
        }


        public bool EsPosibleIniciarDevolucionDeUnaCompra(int NumeroAgencia, int NumeroCompraProducto)
        {
            return AdapterFuncionesGestionComercial.EsPosibleIniciarDevolucionDeUnaCompra(NumeroAgencia, NumeroCompraProducto).Value;            
        }

        public DataTable ListarProductosPreciosReporte(string ListadoCodigosProducto, bool ConExistencia, int CodigoMonedaCotizacion, int NumeroAgencia)
        {
            return new ListarProductosPreciosReporteTableAdapter().GetData(ListadoCodigosProducto, ConExistencia, CodigoMonedaCotizacion, NumeroAgencia);
        }

        public bool ExisteCodigoProductoEspecificoInventario(string CodigoProducto, string CodigoProductoEspecifico)
        {
            return AdapterFuncionesGestionComercial.ExisteCodigoProductoEspecificoInventario(CodigoProducto, CodigoProductoEspecifico).Value;
        }

        public string ObtenerNombreCompleto(string DIPersona)
        {
            return AdapterFuncionesGestionComercial2.ObtenerNombreCompleto(DIPersona);
        }

        /// <summary>
        /// Obtiene el Numero de Agencia que ha realizado la 
        /// trasferencia para poder realizar las visualizaciones correspondientes
        /// </summary>
        /// <param name="NumeroTransferenciaProducto"></param>
        /// <param name="NumeroAgenciaReceptora"></param>
        /// <returns></returns>
        public int ObtenerNumeroAgenciaEmisoraDeTransferencias(int NumeroTransferenciaProducto, int NumeroAgenciaReceptora)
        {
            return AdapterFuncionesGestionComercial2.ObtenerNumeroAgenciaEmisoraDeTransferencias(NumeroTransferenciaProducto, NumeroAgenciaReceptora).Value;
        }

        public string EsPosibleEnviarTransferencia(int NumeroAgencia, string ProductoDetalleXML)
        {
            string DetalleProductosTexto = null;

            AdapterFuncionesGestionComercial2.EsPosibleEnviarTransferencia(NumeroAgencia, ProductoDetalleXML, ref DetalleProductosTexto);
            return DetalleProductosTexto;
        }



        public string ActualizarCambioEstadoProductosEspecificos_A_Normal(int NumeroAgencia, string ProductoDetalleXML)
        {
            string DetalleProductosTexto = null;
            AdapterFuncionesGestionComercial.ActualizarCambioEstadoProductosEspecificos_A_Normal(NumeroAgencia, ProductoDetalleXML, ref DetalleProductosTexto);
            return DetalleProductosTexto;
        }

        public DSDoblones20GestionComercial2.ObtenerCreditoDesdeCodigoAutorizacionDataTable ObtenerCreditoDesdeCodigoAutorizacion(string CodigoAutorizacion, int NumeroAgencia, bool EsParaCreditoLibreDisposicion)
        {
            return new ObtenerCreditoDesdeCodigoAutorizacionTableAdapter().GetData(CodigoAutorizacion, NumeroAgencia, EsParaCreditoLibreDisposicion);
        }

        public decimal ObtenerMontoTotalRealCobroCompraProductosIncompleta(int NumeroAgencia, int NumeroCompraProducto, string TextoCompraXML)
        {
            decimal? MontoTotalCobro = 0;
            AdapterFuncionesGestionComercial2.ObtenerMontoTotalRealCobroCompraProductosIncompleta(NumeroAgencia, NumeroCompraProducto, TextoCompraXML, ref MontoTotalCobro);
            return MontoTotalCobro.Value;
        }

        public bool EsPosibleDevolucionProductoGarantia(int NumeroAgencia, int NumeroTransaccion, string CodigoProducto , string TipoTransaccion)
        {
            return AdapterFuncionesGestionComercial2.EsPosibleDevolucionProductoGarantia(NumeroAgencia, NumeroTransaccion, CodigoProducto, TipoTransaccion).Value;
        }

        public decimal ObtenerCuentaPorPagarDeuda(int NumeroAgencia, int NumeroCuentaPorPagar)
        {
            DSDoblones20Contabilidad.CuentasPorPagarDataTable DTCuentasPorPagar = new CLCAD.DSDoblones20ContabilidadTableAdapters.CuentasPorPagarTableAdapter().GetDataByNumeroCuenta(NumeroCuentaPorPagar);
            return DTCuentasPorPagar.Count > 0 ? DTCuentasPorPagar[0].Monto : 0;
        }

        public bool ActualizarMontoDeudaCuentaPorPagar(int NumeroAgencia, int NumeroCuentaPorPagar, decimal NuevoMontoDeuda)
        {
            CLCAD.DSDoblones20ContabilidadTableAdapters.CuentasPorPagarTableAdapter Adapter = new CLCAD.DSDoblones20ContabilidadTableAdapters.CuentasPorPagarTableAdapter();
            DSDoblones20Contabilidad.CuentasPorPagarDataTable DTCuentasPorPagar = Adapter.GetDataByNumeroCuenta(NumeroCuentaPorPagar);
            if (DTCuentasPorPagar.Count > 0)
            {
                DTCuentasPorPagar[0].Monto = NuevoMontoDeuda;
                Adapter.Update(DTCuentasPorPagar[0]);
                return true;
            }
            else
                return false;
        }

        public string ObtenerNombrePCServidor()
        {
            return AdapterFuncionesGestionComercial2.ObtenerNombrePCServidor().ToString();
        }


        public bool ExisteCotizacionMonedaSistema(byte CodigoMonedaCotizacion, byte CodigoMonedaSistema)
        {
            return AdapterFuncionesGestionComercial2.ExisteCotizacionMonedaSistema(CodigoMonedaCotizacion, CodigoMonedaSistema).Value;
        }

        /// <summary>
        /// Obtiene el Monto Total de manera numerica y literal, incluyendo la moneda, de los gastos realizados en una trasaccion de Compra o transferencia
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="NumeroTrasaccion">Numero de Compra o Transferencia</param>
        /// <param name="TipoTransaccion">Tipo de transaccion 'C'->compra, 'T'->Transferencia</param>
        /// <param name="CodigoTipoEnvioRecepcion">'E'-> envio,  'R'->Recepcion </param>
        /// <returns></returns>
        public DataTable ListarTransaccionProductosGastosRecepcionMoneda(int NumeroAgencia, int NumeroTrasaccion, string TipoTransaccion, string CodigoTipoEnvioRecepcion)
        {
            return new ListarTransaccionProductosGastosRecepcionMonedaTableAdapter().GetData(NumeroAgencia, NumeroTrasaccion, TipoTransaccion, CodigoTipoEnvioRecepcion);
        }

        public void InsertarAsientosTransacciones(
            int CodigoUsuario, string Glosa, string Estado, int NumeroTransacción, string TipoTransaccion, int NumeroAgencia )
        {
            AdapterFuncionesGestionComercial2.InsertarAsientosTransacciones(CodigoUsuario, Glosa, Estado, NumeroTransacción,
                TipoTransaccion, NumeroAgencia);
        }

        public DataTable CambiarMonedaProductosDetalleTransaccion(int NumeroAgencia, int CodigoMonedaCotizacion, bool EsConFactura, string DetalleProductosXML)
        {
            return new CambiarMonedaProductosDetalleTransaccionTableAdapter().GetData(NumeroAgencia, CodigoMonedaCotizacion, DetalleProductosXML, EsConFactura);
        }

        public string EsPosibleAsignarCreditoAVentaProductos(int? NumeroVentaProducto, int NumeroCredito, int NumeroAgencia, string ProductosDetalleXML, decimal MontoTotalVenta)
        {
            return AdapterFuncionesGestionComercial2.EsPosibleAsignarCreditoAVentaProductos(NumeroVentaProducto, NumeroCredito, NumeroAgencia, ProductosDetalleXML, MontoTotalVenta);
        }

        /// <summary>
        /// Verifica que una Compra ha Sido realizada en dos Etapas en su forma de Pago
        /// Es decir: Una Parte ha sido cancelada en Efectivo y la otra ha sido a Credito
        /// El Tipo de Retorno es la Diferencia entre el MontoTotalCompra - MontoCuentaPorPagar
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="NumeroCompraProducto">Numero Compra Producto</param>
        /// <returns>-1 Si no Pertenece al Caso de Compra, 
        /// y (MontoTotalCompra - MontoCuentaPorPagar) en caso de Pertenecer a este tipo </returns>
        public decimal EsCompraCreditoEfectivo(int NumeroAgencia, int NumeroCompraProducto)
        {
            return AdapterFuncionesGestionComercial2.EsCompraCreditoEfectivo(NumeroAgencia, NumeroCompraProducto).Value;
        }


        /// <summary>
        /// Obtiene el Nombre Completo del usuario
        /// </summary>
        /// <param name="CodigoUsuario"></param>
        /// <returns>Nombre Completo : </returns>
        public string ObtenerNombreCompletoUsuario(int CodigoUsuario)
        {
            return AdapterFuncionesGestionComercial2.ObtenerNombreCompletoUsuario(CodigoUsuario);
        }

        /// <summary>
        /// Inserta una acción de un usuario dentro del modulo de seguimiento a usuarios[BITACORA]
        /// </summary>
        /// <param name="EventType">Tipo de Evento : 'RPC Event', 'Language Event', 'Ingreso Sistema', 'Salida Sistema'</param>
        /// <param name="Status">Estado</param>
        /// <param name="EventInfo">Accion realizada a nivel sql</param>
        public void InsertarBitacora(string EventType, int Status, string EventInfo)
        {
            AdapterFuncionesGestionComercial2.InsertarBitacora(EventType, Status, EventInfo);
        }
    }
}
