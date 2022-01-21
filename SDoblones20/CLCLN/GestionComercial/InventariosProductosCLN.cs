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
    public class InventariosProductosCLN
    {
        private InventarioProductosTableAdapter _InventariosProductosAdapter = null;
        private QTAFuncionesSistema _FuncionesSistemaAdapter = null;
        private FuncionesGestionComercial _FuncionesGestionComercialAdapter = null;
        protected InventarioProductosTableAdapter Adapter
        {
            get
            {
                if (_InventariosProductosAdapter == null)
                    _InventariosProductosAdapter = new InventarioProductosTableAdapter();
                return _InventariosProductosAdapter;
            }
        }

        protected QTAFuncionesSistema FuncionesSistemaAdapter
        {
            get
            {
                if (_FuncionesSistemaAdapter == null)
                    _FuncionesSistemaAdapter = new QTAFuncionesSistema();
                return _FuncionesSistemaAdapter;
            }
        }

        protected FuncionesGestionComercial FuncionesGestionComercialAdapter
        {
            get
            {
                if (_FuncionesGestionComercialAdapter == null)
                    _FuncionesGestionComercialAdapter = new FuncionesGestionComercial();
                return _FuncionesGestionComercialAdapter;

            }
        }

        public InventariosProductosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarInventarioProducto(int NumeroAgencia, string CodigoProducto, int CantidadExistencia, int CantidadRequerida, decimal PrecioUnitarioCompra, int TiempoGarantiaProducto, decimal PorcentajeUtilidad1, decimal PrecioUnitarioVenta1, decimal PorcentajeUtilidad2, decimal PrecioUnitarioVenta2, decimal PorcentajeUtilidad3, decimal PrecioUnitarioVenta3, decimal PorcentajeUtilidad4, decimal PrecioUnitarioVenta4, decimal PorcentajeUtilidad5, decimal PrecioUnitarioVenta5, decimal PorcentajeUtilidad6, decimal PrecioUnitarioVenta6, int StockMinimo, bool MostrarParaVenta, string ClaseProducto, bool EsProductoEspecifico, bool ProductoEspecificoGenerado)		
        {
            DSDoblones20GestionComercial.InventarioProductosDataTable InventariosProductos = new DSDoblones20GestionComercial.InventarioProductosDataTable();
            DSDoblones20GestionComercial.InventarioProductosRow InventarioProducto = InventariosProductos.NewInventarioProductosRow();

            InventarioProducto.NumeroAgencia = NumeroAgencia;
            InventarioProducto.CodigoProducto = CodigoProducto;
            InventarioProducto.CantidadExistencia = CantidadExistencia;
            InventarioProducto.CantidadRequerida = CantidadRequerida;
            InventarioProducto.PrecioUnitarioCompra = PrecioUnitarioCompra;
            InventarioProducto.TiempoGarantiaProducto = TiempoGarantiaProducto;
            InventarioProducto.PorcentajeUtilidad1 = PorcentajeUtilidad1;
            InventarioProducto.PrecioUnitarioVenta1 = PrecioUnitarioVenta1;
            InventarioProducto.PorcentajeUtilidad2 = PorcentajeUtilidad2;
            InventarioProducto.PrecioUnitarioVenta2 = PrecioUnitarioVenta2;
            InventarioProducto.PorcentajeUtilidad3 = PorcentajeUtilidad3;
            InventarioProducto.PrecioUnitarioVenta3 = PrecioUnitarioVenta3;
            InventarioProducto.PorcentajeUtilidad4 = PorcentajeUtilidad4;
            InventarioProducto.PrecioUnitarioVenta4 = PrecioUnitarioVenta4;
            InventarioProducto.PorcentajeUtilidad5 = PorcentajeUtilidad5;
            InventarioProducto.PrecioUnitarioVenta5 = PrecioUnitarioVenta5;
            InventarioProducto.PorcentajeUtilidad6 = PorcentajeUtilidad6;
            InventarioProducto.PrecioUnitarioVenta6 = PrecioUnitarioVenta6;
            InventarioProducto.StockMinimo = StockMinimo;
            InventarioProducto.MostrarParaVenta = MostrarParaVenta;
            InventarioProducto.ClaseProducto = ClaseProducto;
            InventarioProducto.EsProductoEspecifico = EsProductoEspecifico;
            InventarioProducto.ProductoEspecificoInventariado = ProductoEspecificoGenerado;
                   
            InventariosProductos.AddInventarioProductosRow(InventarioProducto);

            int rowsAffected = Adapter.Update(InventariosProductos);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarInventarioProducto(int NumeroAgencia, string CodigoProducto, int CantidadExistencia, int CantidadRequerida, decimal PrecioUnitarioCompra, int TiempoGarantiaProducto, decimal PorcentajeUtilidad1, decimal PrecioUnitarioVenta1, decimal PorcentajeUtilidad2, decimal PrecioUnitarioVenta2, decimal PorcentajeUtilidad3, decimal PrecioUnitarioVenta3, decimal PorcentajeUtilidad4, decimal PrecioUnitarioVenta4, decimal PorcentajeUtilidad5, decimal PrecioUnitarioVenta5, decimal PorcentajeUtilidad6, decimal PrecioUnitarioVenta6, int StockMinimo, bool MostrarParaVenta, string ClaseProducto, bool EsProductoEspecifico, bool ProductoEspecificoGenerado)		
        {
            DSDoblones20GestionComercial.InventarioProductosDataTable InventariosProductos = Adapter.GetDataBy11(NumeroAgencia, CodigoProducto);
            if (InventariosProductos.Count == 0)
                return false;

            DSDoblones20GestionComercial.InventarioProductosRow InventarioProducto = InventariosProductos[0];

            InventarioProducto.NumeroAgencia = NumeroAgencia;
            InventarioProducto.CodigoProducto = CodigoProducto;
            InventarioProducto.CantidadExistencia = CantidadExistencia;
            InventarioProducto.CantidadRequerida = CantidadRequerida;
            InventarioProducto.PrecioUnitarioCompra = PrecioUnitarioCompra;
            InventarioProducto.TiempoGarantiaProducto = TiempoGarantiaProducto;
            InventarioProducto.PorcentajeUtilidad1 = PorcentajeUtilidad1;
            InventarioProducto.PrecioUnitarioVenta1 = PrecioUnitarioVenta1;            
            InventarioProducto.PorcentajeUtilidad2 = PorcentajeUtilidad2;
            InventarioProducto.PrecioUnitarioVenta2 = PrecioUnitarioVenta2;
            InventarioProducto.PorcentajeUtilidad3 = PorcentajeUtilidad3;
            InventarioProducto.PrecioUnitarioVenta3 = PrecioUnitarioVenta3;
            InventarioProducto.PorcentajeUtilidad4 = PorcentajeUtilidad4;
            InventarioProducto.PrecioUnitarioVenta4 = PrecioUnitarioVenta4;
            InventarioProducto.PorcentajeUtilidad5 = PorcentajeUtilidad5;
            InventarioProducto.PrecioUnitarioVenta5 = PrecioUnitarioVenta5;
            InventarioProducto.PorcentajeUtilidad6 = PorcentajeUtilidad6;
            InventarioProducto.PrecioUnitarioVenta6 = PrecioUnitarioVenta6;
            InventarioProducto.StockMinimo = StockMinimo;
            InventarioProducto.MostrarParaVenta = MostrarParaVenta;
            InventarioProducto.ClaseProducto = ClaseProducto;
            InventarioProducto.EsProductoEspecifico = EsProductoEspecifico;
            InventarioProducto.ProductoEspecificoInventariado = ProductoEspecificoGenerado;
            

            int rowsAffected = Adapter.Update(InventarioProducto);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarInventarioProducto(int NumeroAgencia, string CodigoProducto)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, CodigoProducto);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarInventariosProductos()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerInventarioProducto(int NumeroAgencia, string CodigoProducto)
        {
            return Adapter.GetDataBy11(NumeroAgencia, CodigoProducto);
        }

        //BuscarProductoInventario
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable BuscarProductoInventario(string CodigoAmbitoBusqueda, string TextoABuscar,bool ExactamenteIgual, int CantidadExistencia, int NumeroAgencia)
        {
            if(TextoABuscar.Contains('\''))
            {
                return null;
            }
            else
                return new BuscarProductoInventarioTableAdapter().GetData(CodigoAmbitoBusqueda, TextoABuscar, ExactamenteIgual, CantidadExistencia, NumeroAgencia); 
        }

        public bool EsProductoEspecifico(int NumeroAgencia, string CodigoProducto)
        {
            bool? esPE = false;
            esPE = FuncionesSistemaAdapter.EsProductoEspecifico(NumeroAgencia, CodigoProducto.Trim());
            
            if (esPE == null)
                return false;
            else
                return Boolean.Parse(esPE.ToString());
        }

        /// <summary>
        /// Incrementa o Disminuye la Cantidad de Existencia en Inventarios, de Acuerdo al Tipo de Parametro
        /// Generalmente su uso se realiza cuando se Cambia el estado de ProductoEspecifico, De Reparacion a
        /// Disponible o Viceversa
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoProducto"></param>
        /// <param name="CantidadIncrDecre"> Cantidad de Incremento o Decremento</param>
        /// <param name="incrementar"> True si se desea incrementar, False si se desea decrementar</param>
        public void ActualizarCantidadExistenciaEnInventarios(int NumeroAgencia, string CodigoProducto, int CantidadIncrDecre, bool incrementar)
        {
            //new QTAFuncionesSistema().ActualizarCantidadExistenciaEnInventarios(NumeroAgencia, CodigoProducto, CantidadIncrDecre, incrementar);
            FuncionesSistemaAdapter.ActualizarCantidadExistenciaEnInventarios(NumeroAgencia, CodigoProducto, CantidadIncrDecre, incrementar);
        }


        /// <summary>
        /// Realiza el Listado de todos los Productos en Inventario
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <returns>Tabla con los Datos</returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarInventarioGeneral(int NumeroAgencia)
        {
            return new ListarInventarioGeneralTableAdapter().GetData(NumeroAgencia);
        }


        /// <summary>
        /// Realiza el Listado de todos los Productos en Inventario que Estan agotados
        /// </summary>
        /// <param name="NumeroAgencia">Numero Agencia</param>
        /// <returns>Tabla con los Productos Agotados</returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarInvetarioProductosAgotadosGeneral(int NumeroAgencia)
        {
            return new ListarInvetarioProductosAgotadosGeneralTableAdapter().GetData(NumeroAgencia);
        }


        /// <summary>
        /// Obtiene la cantidad de Codigos Especificos que han sido generado en Inventario de productos Especificos
        /// y estan en disponibilidad, se utiliza mas que todo para serciorarse de que la cantidad en existencia
        /// coincida con la cantidad de productos especificos 
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoProducto"></param>
        /// <returns>Cantidad de codigos Especificos Registrados como habiles para venta</returns>
        public int ObtenerCantidadCodigosEspcificosInventariados(int NumeroAgencia, string CodigoProducto)
        {
            int? Cantidad = 0;
            FuncionesGestionComercialAdapter.ObtenerCantidadCodigosEspcificosInventariados(NumeroAgencia, CodigoProducto, ref Cantidad);
            return Cantidad.Value;
        }


        public void ActualizarPEInventariadoInventarioProducto(int NumeroAgencia, string CodigoProducto, bool EsProductoEspecifico, bool ProductoEspecificoInventariado)
        {
            FuncionesGestionComercialAdapter.ActualizarPEInventariadoInventarioProducto(NumeroAgencia, CodigoProducto, EsProductoEspecifico, ProductoEspecificoInventariado);
        }

        public DataTable ListarHistorialInventarioPorFecha(int NumeroAgencia, DateTime FechaInicio, DateTime FechaFin)
        {
            return new ListarHistorialInventarioPorFechaTableAdapter().GetData(FechaInicio, FechaFin, NumeroAgencia);
        }

        public DataTable ListarProductosRequeridosPorVentasNoEntregadasCompletamente()
        {
            return new CLCAD.DSDoblones20GestionComercialTableAdapters.ListarProductosRequeridosPorVentasNoEntregadasCompletamenteTableAdapter().GetData();
        }

        public int ObtenerExistenciaProductoInventario(int NumeroAgencia, string CodigoProducto)
        {
            return FuncionesGestionComercialAdapter.ObtenerExistenciaProductoInventario(NumeroAgencia, CodigoProducto).Value;
        }

        /// <summary>
        /// Se encarga de Insertar la cantidad de ingreso en la tabla que de historial de recepciones
        /// para calcular el precio ideal de Compra
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroCompraProducto"></param>
        /// <param name="FechaHoraEntrega">Fecha en la que se registro la recepcion de productos (de la tabla CompraProductosDetalleEntrega)</param>
        public void InsertarInventarioProductosCantidadesComprasHistorialAplicandoGastos(int NumeroAgencia,	int NumeroCompraProducto,DateTime FechaHoraEntrega)
        {
            FuncionesGestionComercialAdapter.InsertarInventarioProductosCantidadesComprasHistorialAplicandoGastos(NumeroAgencia, NumeroCompraProducto, FechaHoraEntrega);
        }

        /// <summary>
        /// Insertar en la Tabla de Historial de Recepciones
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroCompraProducto"></param>
        /// <param name="CodigoProducto"></param>
        /// <param name="FechaHoraIngreso"></param>
        /// <param name="CantidadExistente"></param>
        /// <param name="PrecioUnitario"></param>
        public void InsertarInventarioProductosCantidadesComprasHistorial(int NumeroAgencia, int NumeroCompraProducto, string CodigoProducto, DateTime FechaHoraIngreso, int CantidadExistente, decimal PrecioUnitario)
        {
            FuncionesGestionComercialAdapter.InsertarInventarioProductosCantidadesComprasHistorial(NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraIngreso, CantidadExistente, PrecioUnitario);
        }

        /// <summary>
        /// Actualizar Historial de Inventario 
        /// cuando se realizan egresos de productos (Ventas)
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoProducto"></param>
        /// <param name="CantidadEgreso"></param>
        public void ActualizarEliminarInventarioProductosCantidadesComprasHistorial(int NumeroAgencia, string CodigoProducto, int CantidadEgreso)
        {
            FuncionesGestionComercialAdapter.ActualizarEliminarInventarioProductosCantidadesComprasHistorial(NumeroAgencia, CodigoProducto, CantidadEgreso);
        }

        public void InsertarInventarioProductosCantidadesComprasHistorialAplicandoGastosConMonto(int NumeroAgencia, int NumeroCompraProducto, DateTime FechaHoraEntrega, decimal MontoIncrementoPrecio)
        {
            CLCAD.DSDoblones20GestionComercial2TableAdapters.QTAFuncionesGestionComercial AdapterFuncionesGestionComercial2 = new CLCAD.DSDoblones20GestionComercial2TableAdapters.QTAFuncionesGestionComercial();
            AdapterFuncionesGestionComercial2.InsertarInventarioProductosCantidadesComprasHistorialAplicandoGastosConMonto(NumeroAgencia, NumeroCompraProducto, FechaHoraEntrega, MontoIncrementoPrecio);
        }

        public DSDoblones20GestionComercial2.ListarProductosActualizacionNuevosPreciosDataTable ListarProductosActualizacionNuevosPrecios(int NumeroAgencia, int NumeroCompraProducto, string ListadoProductos, string TipoIncrementoPrecio)
        {
            return new CLCAD.DSDoblones20GestionComercial2TableAdapters.ListarProductosActualizacionNuevosPreciosTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto, ListadoProductos, TipoIncrementoPrecio);
        }

        public DataTable ListarMovimientosKardexProductos(int NumeroAgencia, DateTime? FechaInicio, DateTime? FechaFin, string CodigoProducto)
        {
            return new CLCAD.DSDoblones20GestionComercial2TableAdapters.ListarMovimientosKardexProductosTableAdapter().GetData(NumeroAgencia, CodigoProducto, FechaInicio, FechaFin);
        }


        /// <summary>
        /// Realiza el Listado de la Mercaderia en Transito a Nivel general , con sumas y promedios, incluyendo la Cantidad en Inventarios
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <returns></returns>
        public DSDoblones20GestionComercial2.ListarInventarioMercaderiaEnTransitoFisicoDataTable
            ListarInventarioMercaderiaEnTransitoFisico(int NumeroAgencia)
        {
            return new ListarInventarioMercaderiaEnTransitoFisicoTableAdapter().GetData(NumeroAgencia); 
        }


        /// <summary>
        /// Listado de Mercaderia en Transito detallado, para agrupar por Proveedor o Producto
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="ParaProveedores">1 si se desea que la Ordenacion sea Por Proveedor para su posterior agrupacion
        ///  -  0 Para Ordernar por Producto</param>
        /// <returns></returns>
        public DSDoblones20GestionComercial2.ListarInventarioMercaderiaEnTransitoDataTable
            ListarInventarioMercaderiaEnTransito(int NumeroAgencia, bool ParaProveedores)
        {
            return new ListarInventarioMercaderiaEnTransitoTableAdapter().GetData(NumeroAgencia, ParaProveedores);
        }

        public DataTable ListarProductosEnTransitoPorPedido(int NumeroAgencia)
        {
            return new ListarProductosEnTransitoPorPedidoTableAdapter().GetData(NumeroAgencia);
        }


        public DataTable ListarComprasProductosReportesPorFechasTipo(int NumeroAgencia, DateTime FechaHoraInicio, DateTime FechaHoraFin, bool OrdenarPorFactura)
        {
            return new ListarComprasProductosReportesPorFechasTipoTableAdapter().GetData(NumeroAgencia, FechaHoraInicio, FechaHoraFin, OrdenarPorFactura);
        }

        public DataTable ListarComprasProductosReportesPorFechasProveedor(int NumeroAgencia, DateTime FechaHoraInicio, DateTime FechaHoraFin, bool OrdernarPorProveedor)
        {
            return new ListarComprasProductosReportesPorFechasProveedorTableAdapter().GetData(NumeroAgencia, FechaHoraInicio, FechaHoraFin, OrdernarPorProveedor);
        }

        public DataTable ListarKardexProductoDetalladoReporte(int NumeroAgencia, DateTime FechaHoraInicio, DateTime FechaHoraFin, string ListadoProductos)
        {
            return new ListarKardexProductoDetalladoReporteTableAdapter().GetData(NumeroAgencia, FechaHoraInicio, FechaHoraFin, ListadoProductos);
        }

        public DataTable ListarKardexValorado(int NumeroAgencia, DateTime? FechaHoraInicio, DateTime? FechaHoraFin)
        {
            return new ListarKardexValoradoTableAdapter().GetData(FechaHoraInicio, FechaHoraFin, NumeroAgencia);
        }


        public DataTable ListarVentasProductosReportesPorFechasTipo(int NumeroAgencia, DateTime FechaHoraInicio, DateTime FechaHoraFin, bool OrdenarPorFactura)
        {
            return new ListarVentasProductosReportesPorFechasTipoTableAdapter().GetData(NumeroAgencia, FechaHoraInicio, FechaHoraFin, OrdenarPorFactura);
        }

        public DataTable ListarVentasProductosReportesPorFechasCliente(int NumeroAgencia, DateTime FechaHoraInicio, DateTime FechaHoraFin, bool OrdernarPorProveedor)
        {
            return new ListarVentasProductosReportesPorFechasClienteTableAdapter().GetData(NumeroAgencia, FechaHoraInicio, FechaHoraFin, OrdernarPorProveedor);
        }

        public DataTable ListarVentasProductosReportesPorCreditosFechasCliente(int NumeroAgencia, DateTime FechaHoraInicio, DateTime FechaHoraFin, bool OrdernarPorProveedor)
        {
            return new ListarVentasProductosReportesPorCreditosFechasClienteTableAdapter().GetData(NumeroAgencia, FechaHoraInicio, FechaHoraFin, OrdernarPorProveedor);
        }

        public void ActualizarPreciosVentaUtilidadXML(int NumeroAgencia, int NumeroCompraProducto, string ProductosDetalleXML)
        {
            this.Adapter.ActualizarPreciosVentaUtilidadXML(NumeroAgencia, NumeroCompraProducto, ProductosDetalleXML);
        }

    }
}
