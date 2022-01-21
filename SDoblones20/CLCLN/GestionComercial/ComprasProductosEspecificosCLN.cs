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
    public class ComprasProductosEspecificosCLN
    {
        #region Atributos de la Clase
        private ComprasProductosEspecificosTableAdapter _ComprasProductosEspecificosAdapter = null;
        protected ComprasProductosEspecificosTableAdapter Adapter
        {
            get
            {
                if (_ComprasProductosEspecificosAdapter == null)
                    _ComprasProductosEspecificosAdapter = new ComprasProductosEspecificosTableAdapter();
                return _ComprasProductosEspecificosAdapter;
            }
        }
        #endregion

        #region Constructor
        public ComprasProductosEspecificosCLN()
        {
            //constructor
        }

        #endregion


       /// <summary>
       /// Comnpra de Productos Especificos, por ejemplos la compra de Tarjetas Madres, tarjetas de Video, cada una tieme
       /// un Codigo que la diferencia de la otra, por mas que sean el mismo producto
       /// </summary>
       /// <param name="NumeroAgencia"></param>
       /// <param name="NumeroCompraProducto"></param>
       /// <param name="CodigoProducto"></param>
       /// <param name="CodigoTipoAgregado"></param>
       /// <param name="TiempoGarantiaPE"></param>
       /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCompraProductoEspecifico(int NumeroAgencia, int NumeroCompraProducto, string CodigoProducto, string CodigoProductoEspecifico, int? TiempoGarantiaPE, DateTime? FechaHoraVencimientoPE, DateTime FechaHoraRecepcion)
        {
            DSDoblones20GestionComercial.ComprasProductosEspecificosDataTable ComprasProductosEspecificos = new DSDoblones20GestionComercial.ComprasProductosEspecificosDataTable();
            DSDoblones20GestionComercial.ComprasProductosEspecificosRow compraProductoEspecifico = ComprasProductosEspecificos.NewComprasProductosEspecificosRow();

            compraProductoEspecifico.NumeroAgencia = NumeroAgencia;
            compraProductoEspecifico.NumeroCompraProducto = NumeroCompraProducto;
            compraProductoEspecifico.CodigoProducto = CodigoProducto;
            compraProductoEspecifico.CodigoProductoEspecifico = CodigoProductoEspecifico;
            compraProductoEspecifico.FechaHoraRecepcion = FechaHoraRecepcion;

            if (TiempoGarantiaPE == null)
                compraProductoEspecifico.SetTiempoGarantiaPENull();
            else
                compraProductoEspecifico.TiempoGarantiaPE = TiempoGarantiaPE.Value;
            if (FechaHoraVencimientoPE == null)
                compraProductoEspecifico.SetFechaHoraVencimientoPENull();
            else
                compraProductoEspecifico.FechaHoraVencimientoPE = FechaHoraVencimientoPE.Value;


            ComprasProductosEspecificos.AddComprasProductosEspecificosRow(compraProductoEspecifico);

            int rowsAffected = Adapter.Update(ComprasProductosEspecificos);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarCompraProductoEspecifico(int NumeroAgencia, int NumeroCompraProducto, string CodigoProducto, string CodigoProductoEspecifico, int? TiempoGarantiaPE, DateTime? FechaHoraVencimientoPE, DateTime FechaHoraRecepcion)
        {
            DSDoblones20GestionComercial.ComprasProductosEspecificosDataTable ComprasProductosEspecificos = Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto, CodigoProducto, CodigoProductoEspecifico);
            if (ComprasProductosEspecificos.Count == 0)
                return false;
            DSDoblones20GestionComercial.ComprasProductosEspecificosRow compraProductoEspecifico = ComprasProductosEspecificos[0];
            compraProductoEspecifico.NumeroAgencia = NumeroAgencia;
            compraProductoEspecifico.NumeroCompraProducto = NumeroCompraProducto;
            compraProductoEspecifico.CodigoProducto = CodigoProducto;
            compraProductoEspecifico.CodigoProductoEspecifico = CodigoProductoEspecifico;
            compraProductoEspecifico.FechaHoraRecepcion = FechaHoraRecepcion;
            if (TiempoGarantiaPE == null)
                compraProductoEspecifico.SetTiempoGarantiaPENull();
            else
                compraProductoEspecifico.TiempoGarantiaPE = TiempoGarantiaPE.Value;
            if (FechaHoraVencimientoPE == null)
                compraProductoEspecifico.SetFechaHoraVencimientoPENull();
            else
                compraProductoEspecifico.FechaHoraVencimientoPE = FechaHoraVencimientoPE.Value;
            
            ComprasProductosEspecificos.AddComprasProductosEspecificosRow(compraProductoEspecifico);

            int rowsAffected = Adapter.Update(ComprasProductosEspecificos);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCompraProductoEspecifico(int NumeroAgencia, int NumeroCompraProducto, string CodigoProducto, string CodigoProductoEspecifico)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgencia,NumeroCompraProducto,CodigoProducto,CodigoProductoEspecifico);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial.ComprasProductosEspecificosDataTable ListarComprasProductosEspecificos(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia); 
        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial.ComprasProductosEspecificosDataTable ObtenerCompraProductoEspecifico(int NumeroAgencia, int NumeroCompraProducto, string CodigoProducto, string CodigoProductoEspecifico)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto, CodigoProducto, CodigoProductoEspecifico);
        }


        /// <summary>
        /// Realiza un listado de Presentación de todos los Productos Especificos que se realizaron
        /// en una compra, para formatear las tuplas en el DataGridView
        /// </summary>
        /// <param name="NumeroAgencia">Numero de Agencia</param>
        /// <param name="NumeroCompraProducto">Numero de Transacción para una Compra</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarComprasProductosEspecificosParaCompra(int NumeroAgencia, int NumeroCompraProducto)
        {
            return new ListarComprasProductosEspecificosParaCompraTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto);
        }

        public DSDoblones20GestionComercial.ListarComprasProductosEspecificosParaRecepcionDataTable ListarComprasProductosEspecificosParaRecepcion(int NumeroAgencia, int NumeroCompraProducto)
        {
            return new ListarComprasProductosEspecificosParaRecepcionTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto);
        }

    }
}
