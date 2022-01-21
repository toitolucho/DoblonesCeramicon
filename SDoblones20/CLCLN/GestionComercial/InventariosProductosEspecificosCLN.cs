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
    [System.ComponentModel.DataObject]
    public class InventariosProductosEspecificosCLN
    {
        private InventariosProductosEspecificosTableAdapter _InventariosProductosEspecificosAdapter = null;
        protected InventariosProductosEspecificosTableAdapter Adapter
        {
            get
            {
                if (_InventariosProductosEspecificosAdapter == null)
                    _InventariosProductosEspecificosAdapter = new InventariosProductosEspecificosTableAdapter();
                return _InventariosProductosEspecificosAdapter;
            }
        }

        public InventariosProductosEspecificosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarInventarioProductoEspecifico(int NumeroAgencia,string CodigoProducto, string CodigoProductoEspecifico, int TiempoGarantiaPECompra, DateTime FechaHoraVencimientoPE, string CodigoFormaAdquisicion, string CodigoEstado)		
        {
            DSDoblones20GestionComercial.InventariosProductosEspecificosDataTable InventariosProductosEspecificos = new DSDoblones20GestionComercial.InventariosProductosEspecificosDataTable();
            DSDoblones20GestionComercial.InventariosProductosEspecificosRow InventarioProductoEspecifico = InventariosProductosEspecificos.NewInventariosProductosEspecificosRow();

            InventarioProductoEspecifico.NumeroAgencia = NumeroAgencia;
            InventarioProductoEspecifico.CodigoProducto = CodigoProducto;
            InventarioProductoEspecifico.CodigoProductoEspecifico = CodigoProductoEspecifico;
            InventarioProductoEspecifico.TiempoGarantiaPECompra = TiempoGarantiaPECompra;
            InventarioProductoEspecifico.FechaHoraVencimientoPE = FechaHoraVencimientoPE;
            InventarioProductoEspecifico.CodigoFormaAdquisicion = CodigoFormaAdquisicion;
            InventarioProductoEspecifico.CodigoEstado = CodigoEstado;

                   
            InventariosProductosEspecificos.AddInventariosProductosEspecificosRow(InventarioProductoEspecifico);

            int rowsAffected = Adapter.Update(InventariosProductosEspecificos);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarInventarioProductoEspecifico(int NumeroAgemcia, string CodigoProducto, string CodigoProductoEspecifico, int TiempoGarantiaPECompra, DateTime FechaHoraVencimientoPE, string CodigoFormaAdquisicion, string CodigoEstado)		
        {
            DSDoblones20GestionComercial.InventariosProductosEspecificosDataTable InventariosProductosEspecificos = Adapter.GetDataBy(NumeroAgemcia ,CodigoProducto, CodigoProductoEspecifico);
            if (InventariosProductosEspecificos.Count == 0)
                return false;

            DSDoblones20GestionComercial.InventariosProductosEspecificosRow InventarioProductoEspecifico = InventariosProductosEspecificos[0];

            InventarioProductoEspecifico.TiempoGarantiaPECompra = TiempoGarantiaPECompra;
            InventarioProductoEspecifico.FechaHoraVencimientoPE = FechaHoraVencimientoPE;
            InventarioProductoEspecifico.CodigoFormaAdquisicion = CodigoFormaAdquisicion;
            InventarioProductoEspecifico.CodigoEstado = CodigoEstado;
            

            int rowsAffected = Adapter.Update(InventarioProductoEspecifico);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarInventarioProductoEspecifico(int NumeroAgencia,string CodigoProducto, string CodigoProductoEspecifico)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, CodigoProducto, CodigoProductoEspecifico);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarInventariosProductosEspecificos()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarInventariosProductosEspecificosPorProducto(int NumeroAgencia, string CodigoProducto)
        {
            return new ListarInventarioProductosEspecificosPorProductoTableAdapter().GetData(NumeroAgencia, CodigoProducto);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerInventarioProductoEspecifico(int NumeroAgencia, string CodigoProducto, string CodigoProductoEspecifico)
        {
            return Adapter.GetDataBy(NumeroAgencia,CodigoProducto, CodigoProductoEspecifico);
        }

        /// <summary>
        /// Realiza el Cambio de la Disponibilidad de los Productos Especificos en Inventarios
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoProducto"></param>
        /// <param name="CantidadVendida">La Cantidad que se ha Vendido y la Cual se Debe Actualizar en Inventarios</param>
        /// <returns></returns>
        public string CambiarEstadoDisponbilidadProductoEspecifico(int NumeroAgencia, string CodigoProducto, int CantidadVendida)
        {            
            string listadoProductosEspecificos = " ";
            new QTAFuncionesSistema().CambiarEstadoDisponbilidadProductoEspecifico(CantidadVendida, NumeroAgencia, CodigoProducto.Trim(), ref listadoProductosEspecificos);
            return listadoProductosEspecificos.Trim();
        }

        /// <summary>
        /// Realiza la Generación de CodigosEspecificos Para los Productos y retorna los mismos
        /// como una cadena con todos los Codigos generados separados por una coma (,)
        /// </summary>
        /// <param name="CodigoProducto">Codigo de Producto para el cual generar los codigosEspecificos</param>
        /// <param name="Cantidad_A_Generar">Numero de CodigosEspecificos a Generar</param>
        /// <returns></returns>
        public string ObtenerListadoCodigoProductoEspecificoGenerado(string CodigoProducto, int Cantidad_A_Generar, string comodiSeparador, string tipoGeneracion)
        {
            string ListadoProductosGenerados = " ";
            new QTAFuncionesSistema().ObtenerCodigoProductoEspecificoGenerado(CodigoProducto, Cantidad_A_Generar, comodiSeparador,tipoGeneracion, ref ListadoProductosGenerados);
            return ListadoProductosGenerados;
        }


        /// <summary>
        /// Realiza la Generación de todos los CodigosEspecificos de un productos como una lista
        /// de los mismos, pero se retorna como una Cadena que contiene los Codigos Existentes
        /// Actualmente separados por una coma(,)
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoProducto"></param>
        /// <returns>Cadena con Productos Especificos separados por una coma</returns>
        public string ListarCodigosProductosEspecificosExistentes(int NumeroAgencia, string CodigoProducto, int cantidad_a_Generar)
        {
            string ListadoCodigosExistentes = "";
            new QTAFuncionesSistema().ListarCodigosProductosEspecificosComoArrayList(CodigoProducto, NumeroAgencia, cantidad_a_Generar, ref ListadoCodigosExistentes);
            return ListadoCodigosExistentes;
        }

        /// <summary>
        /// Selecciona las primeros Codigos Especificos de un producto
        /// que esten disponibles para su Venta o Transferencia
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoProducto">Codigo Producto</param>
        /// <param name="Cantidad">cantidad a seleccionar</param>
        /// <returns></returns>
        public DSDoblones20GestionComercial2.ListarCodigosProductosEspecificosParaTransferenciaEnvioDataTable
            ListarCodigosProductosEspecificosParaTransferenciaEnvio(int NumeroAgencia, string CodigoProducto, int Cantidad)
        {
            return new CLCAD.DSDoblones20GestionComercial2TableAdapters.ListarCodigosProductosEspecificosParaTransferenciaEnvioTableAdapter().GetData(CodigoProducto, NumeroAgencia, Cantidad);
        }
    }
}
