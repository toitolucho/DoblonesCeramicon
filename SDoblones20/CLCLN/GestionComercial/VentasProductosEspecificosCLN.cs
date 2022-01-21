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
    [System.ComponentModel.DataObject]
    public class VentasProductosEspecificosCLN
    {
        private VentasProductosEspecificosTableAdapter _VentasProductosEspecificosAdapter = null;
        protected VentasProductosEspecificosTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosEspecificosAdapter == null)
                    _VentasProductosEspecificosAdapter = new VentasProductosEspecificosTableAdapter();
                return _VentasProductosEspecificosAdapter;
            }
        }

        public VentasProductosEspecificosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaProductoEspecifico(int NumeroAgencia, int NumeroVentaProducto, string CodigoProducto, string CodigoProductoEspecifico, int TiempoGarantiaPE, bool? Entregado, DateTime? FechaHoraEntrega)
        {
            DSDoblones20GestionComercial.VentasProductosEspecificosDataTable VentasProductosEspecificos = new DSDoblones20GestionComercial.VentasProductosEspecificosDataTable();
            DSDoblones20GestionComercial.VentasProductosEspecificosRow VentaProductoEspecifico = VentasProductosEspecificos.NewVentasProductosEspecificosRow();

            VentaProductoEspecifico.NumeroAgencia = NumeroAgencia;
            VentaProductoEspecifico.NumeroVentaProducto = NumeroVentaProducto;
            VentaProductoEspecifico.CodigoProducto = CodigoProducto;
            VentaProductoEspecifico.CodigoProductoEspecifico = CodigoProductoEspecifico;
            VentaProductoEspecifico.TiempoGarantiaPE = TiempoGarantiaPE;
            //Modificar OJO
            VentaProductoEspecifico.FechaHoraEntrega = DateTime.Now;
            if (Entregado == null)
                VentaProductoEspecifico.SetEntregadoNull();
            else
                VentaProductoEspecifico.Entregado = Entregado.Value;
            if (FechaHoraEntrega == null)
                VentaProductoEspecifico.SetFechaHoraEntregaNull();
            else
                VentaProductoEspecifico.FechaHoraEntrega = FechaHoraEntrega.Value;

            VentasProductosEspecificos.AddVentasProductosEspecificosRow(VentaProductoEspecifico);
            int rowsAffected = Adapter.Update(VentasProductosEspecificos);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaProductoEspecifico(int NumeroAgencia, int NumeroVentaProducto, string CodigoProducto, string CodigoProductoEspecifico, int TiempoGarantiaPE, bool? Entregado)
        {
            DSDoblones20GestionComercial.VentasProductosEspecificosDataTable VentasProductosEspecificos = Adapter.GetDataBy(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoProductoEspecifico);
            if (VentasProductosEspecificos.Count == 0)
                return false;

            DSDoblones20GestionComercial.VentasProductosEspecificosRow VentaProductoEspecifico = VentasProductosEspecificos[0];

            VentaProductoEspecifico.NumeroAgencia = NumeroAgencia;
            VentaProductoEspecifico.NumeroVentaProducto = NumeroVentaProducto;
            VentaProductoEspecifico.CodigoProducto = CodigoProducto;
            VentaProductoEspecifico.CodigoProductoEspecifico = CodigoProductoEspecifico;
            VentaProductoEspecifico.TiempoGarantiaPE = TiempoGarantiaPE;
            if (Entregado == null)
                VentaProductoEspecifico.SetEntregadoNull();
            else
                VentaProductoEspecifico.Entregado = Entregado.Value;


            VentasProductosEspecificos.AddVentasProductosEspecificosRow(VentaProductoEspecifico);

            int rowsAffected = Adapter.Update(VentaProductoEspecifico);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaProductoEspecifico(int NumeroAgencia, int NumeroVentaProducto, string CodigoProducto, string CodigoProductoEspecifico)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoProductoEspecifico);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosEspecificos()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerVentaProductoEspecifico(int NumeroAgencia, int NumeroVentaProducto, string CodigoProducto, string CodigoProductoEspecifico)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoProductoEspecifico);
        }

        /// <summary>
        /// Realiza el Listado de los Productos Especificos Vendidos para mostrar sus detalles de una venta
        /// Nombre Producto, Codigo Producto, Codigo Producto Especificos, y demás Atributos
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="NumeroCompraProducto">Numero de Venta Producto</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosEspecificosParaVenta(int NumeroAgencia, int NumeroVentaProducto)
        {
            return new ListarVentasProductosEspecificosParaVentaTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto);
        }

        public DataTable ListarVentasProductosEspecificosParaVisualizarAlmacenes(int NumeroAgencia, int NumeroVentaProducto)
        {
            return new ListarVentasProductosEspecificosParaVisualizarAlmacenesTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto);
        }

        public DSDoblones20GestionComercial2.ListarCodigosProductosEspecificosDataTable ListarCodigosProductosEspecificos(int NumeroAgencia,
            int NumeroVentaProducto, string CodigoProducto, string CodigoTipoEnvioRecepcion)
        {
            return new CLCAD.DSDoblones20GestionComercial2TableAdapters.ListarCodigosProductosEspecificosTableAdapter().GetData(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoTipoEnvioRecepcion);
        }

    }
}
