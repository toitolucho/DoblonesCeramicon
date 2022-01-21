using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;
using CLCAD.DSDoblones20GestionComercial2TableAdapters;


namespace CLCLN.GestionComercial
{
    [System.ComponentModel.DataObject]
    public class VentasProductosCLN
    {
        private VentasProductosTableAdapter _VentasProductosAdapter = null;
        private FuncionesGestionComercial _FuncionesGestionComercial = null;
        private QTAFuncionesGestionComercial _QTAFuncionesGestionComercial = null;

        protected VentasProductosTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosAdapter == null)
                    _VentasProductosAdapter = new VentasProductosTableAdapter();
                return _VentasProductosAdapter;
            }
        }

        protected FuncionesGestionComercial FuncionesGestionComercialAdapter
        {
            get {
                if (_FuncionesGestionComercial == null)
                    _FuncionesGestionComercial = new FuncionesGestionComercial();
                return _FuncionesGestionComercial;
            }
        }

        protected QTAFuncionesGestionComercial FuncionesGestionComercia2lAdapter
        {
            get
            {
                if (_QTAFuncionesGestionComercial == null)
                    _QTAFuncionesGestionComercial = new QTAFuncionesGestionComercial();
                return _QTAFuncionesGestionComercial;
            }
        }
             

        public VentasProductosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaProducto(int NumeroAgencia, int CodigoCliente, int CodigoUsuario, int? NumeroFactura, DateTime FechaHoraVenta, string CodigoTipoVenta, string CodigoEstadoVenta, decimal MontoTotalVenta, int? NumeroCredito, byte CodigoMoneda, string Observaciones, decimal? MontoTotalVentaProductos, decimal? MontoTotalVentaServicios, int? NumeroVentaServicio)
        {
            DSDoblones20GestionComercial.VentasProductosDataTable VentasProductos = new DSDoblones20GestionComercial.VentasProductosDataTable();
            DSDoblones20GestionComercial.VentasProductosRow VentaProducto = VentasProductos.NewVentasProductosRow();

            VentaProducto.NumeroAgencia = NumeroAgencia;
            VentaProducto.CodigoCliente = CodigoCliente;
            VentaProducto.CodigoUsuario = CodigoUsuario;
            if (NumeroFactura == null) VentaProducto.SetNumeroFacturaNull();
            else VentaProducto.NumeroFactura = NumeroFactura.Value;
            VentaProducto.FechaHoraVenta = FechaHoraVenta;            
            VentaProducto.CodigoEstadoVenta = CodigoEstadoVenta;
            if (NumeroCredito == null) VentaProducto.SetNumeroCreditoNull();
            else VentaProducto.NumeroCredito = NumeroCredito.Value;
            VentaProducto.Observaciones = Observaciones;
            VentaProducto.MontoTotalVenta = MontoTotalVenta;
            VentaProducto.CodigoMoneda = CodigoMoneda;
            VentaProducto.CodigoTipoVenta = CodigoTipoVenta;
            if (MontoTotalVentaProductos == null) VentaProducto.SetMontoTotalVentaProductosNull();
            else VentaProducto.MontoTotalVentaProductos = MontoTotalVentaProductos.Value;

            if (MontoTotalVentaServicios == null) VentaProducto.SetMontoTotalVentaServiciosNull();
            else VentaProducto.MontoTotalVentaServicios = MontoTotalVentaServicios.Value;

            if (NumeroVentaServicio == null) VentaProducto.SetNumeroVentaServicioNull();
            else VentaProducto.NumeroVentaServicio = NumeroVentaServicio.Value;

            VentasProductos.AddVentasProductosRow(VentaProducto);

            int rowsAffected = Adapter.Update(VentasProductos);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaProducto(int NumeroAgencia, int NumeroVentaProducto, int CodigoCliente, int CodigoUsuario, int? NumeroFactura, DateTime FechaHoraVenta, string CodigoTipoVenta, decimal MontoTotalVenta, string CodigoEstadoVenta, int? NumeroCredito, byte CodigoMoneda,string Observaciones)
        {
            DSDoblones20GestionComercial.VentasProductosDataTable VentasProductos = Adapter.GetDataBy11(NumeroAgencia, NumeroVentaProducto);
            if (VentasProductos.Count == 0)
                return false;

            DSDoblones20GestionComercial.VentasProductosRow VentaProducto = VentasProductos[0];

            //VentaProducto.NumeroAgencia = NumeroAgencia;
            //VentaProducto.NumeroCompraProducto = NumeroCompraProducto;
            VentaProducto.CodigoCliente = CodigoCliente;
            VentaProducto.CodigoUsuario = CodigoUsuario;
            if (NumeroFactura == null) VentaProducto.SetNumeroFacturaNull();
            else VentaProducto.NumeroFactura = NumeroFactura.Value;
            VentaProducto.FechaHoraVenta = FechaHoraVenta;            
            VentaProducto.CodigoEstadoVenta = CodigoEstadoVenta;            
            if (NumeroCredito == null) VentaProducto.SetNumeroCreditoNull();
            else VentaProducto.NumeroCredito = NumeroCredito.Value;
            VentaProducto.Observaciones = Observaciones;
            VentaProducto.MontoTotalVenta = MontoTotalVenta;
            VentaProducto.CodigoMoneda = CodigoMoneda;
            VentaProducto.CodigoTipoVenta = CodigoTipoVenta;


            int rowsAffected = Adapter.Update(VentaProducto);
            return rowsAffected == 1;
        }

        public bool ActualizarVentaProducto(int NumeroAgencia, int NumeroVentaProducto, string Observaciones)
        {
            DSDoblones20GestionComercial.VentasProductosDataTable VentasProductos = Adapter.GetDataBy11(NumeroAgencia, NumeroVentaProducto);
            if (VentasProductos.Count == 0)
                return false;

            DSDoblones20GestionComercial.VentasProductosRow VentaProducto = VentasProductos[0];

            if (Observaciones != null)
                VentaProducto.Observaciones = Observaciones;
            else
                VentaProducto.SetObservacionesNull();

            int rowsAffected = Adapter.Update(VentaProducto);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaProducto(int NumeroAgencia, int NumeroVentaProducto)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroVentaProducto);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductos(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerVentaProducto(int NumeroAgencia, int NumeroVentaProducto)
            {
            return Adapter.GetDataBy11(NumeroAgencia, NumeroVentaProducto);
        }


        /// <summary>
        /// REPORTE de Ventas Datos Generales
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroCompraProducto"></param>
        /// <returns></returns>
        public DataTable ListarVentaProductoReporte(int NumeroAgencia, int NumeroVentaProducto)
        {
            return new VentaProductoReporteTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto);
        }


        public string ListarTuplaDatosVentaProductoReporte(int NumeroAgencia, int NumeroVentaProducto)
        {
            string listadoAtributosVentas = null;
            new QTAFuncionesSistema().ListarTuplaDatosVentaProductoReporte(NumeroAgencia, NumeroVentaProducto,ref listadoAtributosVentas);
            return listadoAtributosVentas;
        }


        public DataTable ListarVentasProductosPorUsuariosReporte(int NumeroAgencia, int? CodigoUsuario)
        {
            return new ReporteVentasProductosPorUsuariosTableAdapter().GetData(CodigoUsuario, NumeroAgencia);
        }


        public DataTable ListarVentasProductosPorRangoFechasReporte(DateTime FechaInicio, DateTime FechaFin, int NumeroAgencia)
        {
            return new ReporteVentasProductosPorRangoFechasTableAdapter().GetData(FechaInicio, FechaFin, NumeroAgencia);
        }

        public DataTable ListarVentasProductosPorProductosReporte(string CodigoProducto, int NumeroAgencia)
        {
            return new ReporteVentasProductosPorProductosTableAdapter().GetData(CodigoProducto, NumeroAgencia);
        }

        public DataTable ListarKARDEXProductosPorProductosReporte(string CodigoProducto, int NumeroAgencia)
        {
            return new ReporteKARDEXProductosPorProductosTableAdapter().GetData(CodigoProducto, NumeroAgencia);
        }

        public DataTable ListarVentasProductosPorClientesReporte(int? CodigoCliente, int NumeroAgencia)
        {
            return new ReporteVentasProductosPorClientesTableAdapter().GetData(CodigoCliente, NumeroAgencia);
        }

        public DataTable ListarVentasProductosCreditosReporte(int NumeroAgencia)
        {
            return new ReporteVentasProductosCreditosTableAdapter().GetData(NumeroAgencia);
        }

        public DataTable ListarProductosMasVendidosReporte(int NumeroAgencia, int? top)
        {
            return new ListarProductosMasVendidosReporteTableAdapter().GetData(NumeroAgencia, top);
        }

        public DataTable ListarProductosMenosVendidosReporte(int NumeroAgencia, int? top)
        {
            return new ListarProductosMenosVendidosReporteTableAdapter().GetData(NumeroAgencia, top);
        }

        public DataTable BuscarVentaProducto(string CodigoAmbitoBusqueda, string TextoABuscar, int NumeroAgencia, int? NumeroVentaProducto, string CodigoEstadoVenta, DateTime FechaInicio, DateTime FechaFin, bool ExactamenteIgual)
        {
            int? numVentaProducto = null;
            if (NumeroVentaProducto != -1)
            {
                numVentaProducto = NumeroVentaProducto;
            }
            return new BuscarVentaProductoTableAdapter().GetData(CodigoAmbitoBusqueda, TextoABuscar, NumeroAgencia, numVentaProducto, CodigoEstadoVenta, FechaInicio, FechaFin, ExactamenteIgual);
        }


        public DataTable ListarVentaProductosDetalleParaAlmacenes(int NumeroAgencia, int NumeroVentaProducto)
        {
            return new ListarVentaProductosDetalleParaAlmacenesTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto);
        }
        /// <summary>
        /// Obtiene el estado Actual de una Venta que ya ha sido finalizada y pagada
        /// para su entrega de productos desde almacenes
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroVentaProducto"></param>
        /// --    'P':Pendiente (Cuando no se han entregado Todos los Productos)
		/// --	  'E':Especificos (Es necesario Seleccionar los Productos Especificos)
		/// --    'T':Entregar (Cuando se encuentra concluida y no hay entrega de productos pendientes, se entrega todo y se genera reporte de conformidad)
        /// --    'C':Combinado (Cuando hay productos Pendientes y hay que llenar especificos)		
        /// <returns></returns>
        public string obtenerEstadoVentaFinalizadaParaAlmacenes(int NumeroAgencia, int NumeroVentaProducto)
        {
            string estado = "";
            FuncionesGestionComercialAdapter.EstadoVentaFinalizadaParaAlmacenes(NumeroAgencia, NumeroVentaProducto, ref estado);            
            return estado;
        }


        /// <summary>
        /// Realiza la consulta a la base de datos, buscando la información necesario de existencia
        /// de la Venta para poder concluirla COMPLETAMENTE o PARCIALMENTE Y cambiar su estado
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="NumeroVentaProducto"> Número de Venta </param>
        /// <param name="TipoConfirmacion">Tipo de Confirmación
        /// 'A' -> Antes de la Entrega de Productos Cuando la Transaccion va a pasar a estado 'P'(Pagado) o 'D'(Pendiente), en este caso se debe revisar lo que se entrega
		///	'D' -> Despues de la Primera Entrega Parcial de Productos, en este caso se debe revisar la diferencia de lo vendido con lo entregado anteriormente</param>
        /// <returns></returns>
        public bool EsPosibleConcluirEntregaDeProductos(int NumeroAgencia, int NumeroVentaProducto, string TipoConfirmacion)
        {
            bool? esPosible = false;
            FuncionesGestionComercialAdapter.EsPosibleConcluirEntregaDeProductos(NumeroAgencia, NumeroVentaProducto, TipoConfirmacion, ref esPosible);
            return esPosible.Value;
        }

        /// <summary>
        /// Se encarga de actualizar la cantidad entregada de productos en una venta por partes
        /// y a si mismo actualiza inventarios, existencia, requeridos y Productos Especificos
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="NumeroVentaProducto">Numero de Venta Producto</param>
        /// <param name="CodigoProducto">Código del Producto</param>
        /// <param name="CantidadNuevaEntregados"> Cantidad Nueva ingresada(Incluya la anterior; por ejemplos 5->Anterior, Actual 10 , implica que se ingresa 5 nuevos)</param>
        public void ActualizarVentaProductosDetalleCantidadRequerida(int NumeroAgencia, int NumeroVentaProducto, string CodigoProducto, int CantidadNuevaEntregados, DateTime FechaHoraEntrega)
        {
            FuncionesGestionComercialAdapter.ActualizarVentaProductosDetalleCantidadRequerida(NumeroAgencia, NumeroVentaProducto, CodigoProducto, @CantidadNuevaEntregados, FechaHoraEntrega);
        }

        /// <summary>
        /// Realiza el listado de los Productos que se entregan en conjunto con sus PE
        /// solamente los productos que se entregan para el reporte de Conformidad de Entrega
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroVentaProducto"></param>
        /// <returns></returns>
        public DataTable ListarVentaProductosDetalleConEspecificosPorPartesParaAlmacenes(int NumeroAgencia, int NumeroVentaProducto)
        {
            return new ListarVentaProductosDetalleConEspecificosPorPartesParaAlmacenesTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto);
        }


        /// <summary>
        /// Realiza el listado general de todos los productos especificos entregados en una venta
        /// una vez que la misma ha sido concluida en su entrega
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroVentaProducto"></param>
        /// <returns></returns>
        public DataTable ListarVentaProductosDetalleConEspecificosCompletaParaAlmacenes(int NumeroAgencia, int NumeroVentaProducto)
        {
            return new ListarVentaProductosDetalleConEspecificosCompletaParaAlmacenesTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto);
        }

        public void ActualizarCodigoEstadoVenta(int NumeroAgencia, int NumeroVentaProducto, string CodigoEstadoVenta)
        {
            FuncionesGestionComercialAdapter.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, CodigoEstadoVenta, null);                
        }
        public void ActualizarCodigoEstadoVenta(int NumeroAgencia, int NumeroVentaProducto, string CodigoEstadoVenta, int? NumeroFactura)
        {
            FuncionesGestionComercialAdapter.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, CodigoEstadoVenta, NumeroFactura);
        }


        /// <summary>
        /// Se encarga de Dar por Entregado un Producto Especifico
        /// cuando se realiza su entrega, su uso es en reportes, para mostrar solo los productos
        /// entregados que recientemente van a salir de invnetario para su entrega al cliente
        /// para luego pasar los a un estado de entregado
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroVentaProducto"></param>
        public void ActualizarProductoEspecificoEntregadoEnVentas(int NumeroAgencia, int NumeroVentaProducto)
        {
            FuncionesGestionComercialAdapter.ActualizarProductoEspecificoEntregadoEnVentas(NumeroAgencia, NumeroVentaProducto);
        }

        public void ActualizarCantidadProductosEntregadosVentasInalcanzables(int NumeroAgencia, int NumeroVentaProducto)
        {
            FuncionesGestionComercialAdapter.ActualizarCantidadProductosEntregadosVentasInalcanzables(NumeroAgencia, NumeroVentaProducto);
        }



        /// <summary>
        /// Inserta Toda la Venta como una sola Transacción
        /// es Decir inserta los datos de la Venta, incluidos  el detalle de productos
        /// que se representa en una cadena que contiene el Detalle como XML,
        /// que dentro de la Base de Datos se manjea con OPENXML
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoCliente"></param>
        /// <param name="CodigoUsuario"></param>
        /// <param name="NumeroFactura"></param>
        /// <param name="FechaHoraVenta"></param>
        /// <param name="CodigoTipoVenta"></param>
        /// <param name="CodigoEstadoVenta"></param>
        /// <param name="MontoTotalVenta"></param>
        /// <param name="NumeroCredito"></param>
        /// <param name="CodigoMoneda"></param>
        /// <param name="Observaciones"></param>
        /// <param name="ProductoDetalle">XML que ocntiene el detalle de Productos para la Venta,
        /// Obtener mediante la llamada del DataSet.GetXML()  [Quitar espacios, medinte replace, de x_2000_x]</param>
        public void InsertarVentaProductoXMLDetalle(int NumeroAgencia, int CodigoCliente, int CodigoUsuario, int? NumeroFactura, DateTime FechaHoraVenta, string CodigoTipoVenta, string CodigoEstadoVenta, decimal MontoTotalVenta, int? NumeroCredito, byte CodigoMoneda, string Observaciones, string ProductoDetalle, decimal? MontoTotalVentaProductos, decimal? MontoTotalVentaServicios, int? NumeroVentaServicio)
        {
            Adapter.InsertarVentaProductoXMLDetalle(NumeroAgencia, CodigoCliente, CodigoUsuario, NumeroFactura, FechaHoraVenta, CodigoEstadoVenta, MontoTotalVenta, NumeroCredito, CodigoMoneda, CodigoTipoVenta, Observaciones, MontoTotalVentaProductos, MontoTotalVentaServicios, NumeroVentaServicio, ProductoDetalle);
        }

        public void ActualizarVentaProductoXMLDetalle(int NumeroAgencia, int NumeroVentaProducto, int CodigoCliente, int CodigoUsuario, int? NumeroFactura, DateTime FechaHoraVenta, string CodigoTipoVenta, string CodigoEstadoVenta, decimal MontoTotalVenta, int? NumeroCredito, byte CodigoMoneda, string Observaciones, string ProductoDetalle, decimal? MontoTotalVentaProductos, decimal? MontoTotalVentaServicios, int? NumeroVentaServicio)
        {
            Adapter.ActualizarVentaProductoXMLDetalle(NumeroAgencia, NumeroVentaProducto, CodigoCliente, 
                CodigoUsuario, NumeroFactura, 
                FechaHoraVenta, CodigoEstadoVenta, 
                MontoTotalVenta, NumeroCredito, CodigoMoneda, 
                CodigoTipoVenta, Observaciones, MontoTotalVentaProductos, 
                MontoTotalVentaServicios, NumeroVentaServicio, ProductoDetalle);
        }


        public void InsertarVentaProductoDetalleEntrega(int NumeroAgencia, int NumeroVentaProducto, string CodigoProducto, DateTime FechaHoraEntrega, int CantidadEntregada)
        {
            VentasProductosDetalleEntregasTableAdapter AdapterAux = new VentasProductosDetalleEntregasTableAdapter();
            AdapterAux.Insert(NumeroAgencia, NumeroVentaProducto, CodigoProducto, FechaHoraEntrega, CantidadEntregada);
        }

        public bool EsPosibleModificarVentaProductos(int NumeroAgencia, int NumeroVentaProducto)
        {
            return FuncionesGestionComercia2lAdapter.EsPosibleModificarVentaProductos(NumeroAgencia, NumeroVentaProducto).Value;
        }

        public DSDoblones20GestionComercial2.ListarProductosEntregaFaltantesDataTable ListarProductosEntregaFaltantes(int NumeroAgencia, int NumeroVentaProducto)
        {
            return new ListarProductosEntregaFaltantesTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto);
        }

        public DSDoblones20GestionComercial2.ListarProductosCantidadSuperaStockMinimoXMLDataTable ListarProductosCantidadSuperaStockMinimo(int NumeroAgencia, string ProductosDetalleXML)
        {
            return new ListarProductosCantidadSuperaStockMinimoXMLTableAdapter().GetData(NumeroAgencia, ProductosDetalleXML);
        }

        public DSDoblones20GestionComercial2.ListarProductosExistenciaInsuficienteXMLDataTable ListarProductosExistenciaInsuficiente(int NumeroAgencia, string ProductosDetalleXML)
        {
            return new ListarProductosExistenciaInsuficienteXMLTableAdapter().GetData(NumeroAgencia, ProductosDetalleXML);
        }

        public void ActualizarInventarioVentasProductos(int NumeroAgencia, int NumeroVentaProducto, DateTime FechaHoraRegistro)
        {
            Adapter.ActualizarInventarioVentasProductos(NumeroAgencia, NumeroVentaProducto, FechaHoraRegistro);
        }
    }
}
