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
    public class ComprasProductosEspecificosReemDevoCLN
    {
        #region Atributos de la Clase
        private ComprasProductosEspecificosReemDevoTableAdapter _ComprasProductosEspecificosReemDevoAdapter = null;
        protected ComprasProductosEspecificosReemDevoTableAdapter Adapter
        {
            get
            {
                if (_ComprasProductosEspecificosReemDevoAdapter == null)
                    _ComprasProductosEspecificosReemDevoAdapter = new ComprasProductosEspecificosReemDevoTableAdapter();
                return _ComprasProductosEspecificosReemDevoAdapter;
            }
        }
        #endregion

        #region Constructor
        public ComprasProductosEspecificosReemDevoCLN()
        {
            //constructor
        }

        #endregion

        #region Metodos para Insertar,Actualizar,Eliminar y Obtener una CompraProductoEspeficioReemDevo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroReemDevo"></param>
        /// <param name="CodigoMotivoReemDevo"></param>
        /// <param name="CodigoProducto"></param>
        /// <param name="CodigoProductoEspeDevo"></param>
        /// <param name="CodigoProductoEspeCambio"></param>
        /// <param name="TiempoGarantiaPE"></param>
        /// <param name="FechaHoraVencimientoPE"></param>
        /// <param name="PrecioUnitarioPECambio"></param>
        /// <param name="MontoDevolucion"></param>
        /// <param name="CodigoTipoReemDevo"></param>
        /// <param name="FechaHoraReemDevoCambio"></param>
        /// <param name="ObservacionesReemDevoCambio"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        //NumeroAgencia,NumeroReemDevo,CodigoMotivoReemDevo,CodigoProducto,CodigoProductoEspeDevo,CodigoProductoEspeCambio,TiempoGarantiaPE,FechaHoraVencimientoPE,PrecioUnitarioPECambio,MontoDevolucion,CodigoTipoReemDevo,FechaHoraReemDevoCambio,ObservacionesReemDevoCambio
        public bool InsertarCompraProductoEspecificoReemDevo(int NumeroAgencia, int NumeroReemDevo,int CodigoMotivoReemDevo,string CodigoProducto,string CodigoProductoEspeDevo,string CodigoProductoEspeCambio,int? TiempoGarantiaPE, DateTime? FechaHoraVencimientoPE,decimal? PrecioUnitarioPECambio, decimal MontoDevolucion, string CodigoTipoReemDevo, DateTime FechaHoraReemDevoCambio, string ObservacionesReemDevoCambio)
        {
            DSDoblones20GestionComercial.ComprasProductosEspecificosReemDevoDataTable ComprasProductosEspecificosReemDevo = new DSDoblones20GestionComercial.ComprasProductosEspecificosReemDevoDataTable();
            DSDoblones20GestionComercial.ComprasProductosEspecificosReemDevoRow compraProductoEspecificoReemDevo = ComprasProductosEspecificosReemDevo.NewComprasProductosEspecificosReemDevoRow();

            compraProductoEspecificoReemDevo.NumeroAgencia = NumeroAgencia;
            compraProductoEspecificoReemDevo.NumeroReemDevo = NumeroReemDevo;
            compraProductoEspecificoReemDevo.CodigoMotivoReemDevo = CodigoMotivoReemDevo;
            compraProductoEspecificoReemDevo.CodigoProducto = CodigoProducto;
            compraProductoEspecificoReemDevo.CodigoProductoEspeDevo = CodigoProductoEspeDevo;
            compraProductoEspecificoReemDevo.CodigoProductoEspeCambio = CodigoProductoEspeCambio;
            if (TiempoGarantiaPE == null)
                compraProductoEspecificoReemDevo.SetTiempoGarantiaPENull();
            else
                compraProductoEspecificoReemDevo.TiempoGarantiaPE = TiempoGarantiaPE.Value;
            if (FechaHoraVencimientoPE == null)
                compraProductoEspecificoReemDevo.SetFechaHoraVencimientoPENull();
            else
                compraProductoEspecificoReemDevo.FechaHoraVencimientoPE = FechaHoraVencimientoPE.Value;
            if (PrecioUnitarioPECambio == null)
                compraProductoEspecificoReemDevo.SetPrecioUnitarioPECambioNull();
            else
                compraProductoEspecificoReemDevo.PrecioUnitarioPECambio = PrecioUnitarioPECambio.Value;
            compraProductoEspecificoReemDevo.MontoDevolucion = MontoDevolucion;
            compraProductoEspecificoReemDevo.CodigoTipoReemDevo = CodigoTipoReemDevo;
            compraProductoEspecificoReemDevo.FechaHoraReemDevoCambio = FechaHoraReemDevoCambio;
            if (ObservacionesReemDevoCambio == null)
                compraProductoEspecificoReemDevo.SetObservacionesReemDevoCambioNull();
            else
                compraProductoEspecificoReemDevo.ObservacionesReemDevoCambio = ObservacionesReemDevoCambio;
           


            ComprasProductosEspecificosReemDevo.AddComprasProductosEspecificosReemDevoRow(compraProductoEspecificoReemDevo);

            int rowsAffected = Adapter.Update(ComprasProductosEspecificosReemDevo);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarCompraProductoEspecificoReemDevo(int NumeroAgencia, int NumeroReemDevo, int CodigoMotivoReemDevo, string CodigoProducto, string CodigoProductoEspeDevo, string CodigoProductoEspeCambio, int? TiempoGarantiaPE, DateTime? FechaHoraVencimientoPE, decimal? PrecioUnitarioPECambio, decimal MontoDevolucion, string CodigoTipoReemDevo, DateTime FechaHoraReemDevoCambio, string ObservacionesReemDevoCambio)
        {
            DSDoblones20GestionComercial.ComprasProductosEspecificosReemDevoDataTable ComprasProductosEspecificosReemDevo = Adapter.GetDataBy(NumeroAgencia, NumeroReemDevo, CodigoMotivoReemDevo, CodigoProducto, CodigoProductoEspeDevo);
            if (ComprasProductosEspecificosReemDevo.Count == 0)
                return false;
            DSDoblones20GestionComercial.ComprasProductosEspecificosReemDevoRow compraProductoEspecificoReemDevo = ComprasProductosEspecificosReemDevo[0];

            compraProductoEspecificoReemDevo.NumeroAgencia = NumeroAgencia;
            compraProductoEspecificoReemDevo.NumeroReemDevo = NumeroReemDevo;
            compraProductoEspecificoReemDevo.CodigoMotivoReemDevo = CodigoMotivoReemDevo;
            compraProductoEspecificoReemDevo.CodigoProducto = CodigoProducto;
            compraProductoEspecificoReemDevo.CodigoProductoEspeDevo = CodigoProductoEspeDevo;
            compraProductoEspecificoReemDevo.CodigoProductoEspeCambio = CodigoProductoEspeCambio;
            if (TiempoGarantiaPE == null)
                compraProductoEspecificoReemDevo.SetTiempoGarantiaPENull();
            else
                compraProductoEspecificoReemDevo.TiempoGarantiaPE = TiempoGarantiaPE.Value;
            if (FechaHoraVencimientoPE == null)
                compraProductoEspecificoReemDevo.SetFechaHoraVencimientoPENull();
            else
                compraProductoEspecificoReemDevo.FechaHoraVencimientoPE = FechaHoraVencimientoPE.Value;
            if (PrecioUnitarioPECambio == null)
                compraProductoEspecificoReemDevo.SetPrecioUnitarioPECambioNull();
            else
                compraProductoEspecificoReemDevo.PrecioUnitarioPECambio = PrecioUnitarioPECambio.Value;
            compraProductoEspecificoReemDevo.MontoDevolucion = MontoDevolucion;
            compraProductoEspecificoReemDevo.CodigoTipoReemDevo = CodigoTipoReemDevo;
            compraProductoEspecificoReemDevo.FechaHoraReemDevoCambio = FechaHoraReemDevoCambio;
            if (ObservacionesReemDevoCambio == null)
                compraProductoEspecificoReemDevo.SetObservacionesReemDevoCambioNull();
            else
                compraProductoEspecificoReemDevo.ObservacionesReemDevoCambio = ObservacionesReemDevoCambio;
          
            int rowsAffected = Adapter.Update(compraProductoEspecificoReemDevo);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCompraProductoEspecificoReemDevo(int NumeroAgencia, int NumeroReemDevo, int CodigoMotivoReemDevo, string CodigoProducto, string CodigoProductoEspeDevo)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgencia, NumeroReemDevo, CodigoMotivoReemDevo, CodigoProducto, CodigoProductoEspeDevo);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarComprasProductosEspecificosReemDevo(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia); 
        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerCompraProductoEspecificoReemDevo(int NumeroAgencia, int NumeroReemDevo, int CodigoMotivoReemDevo, string CodigoProducto, string CodigoProductoEspeDevo)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroReemDevo, CodigoMotivoReemDevo, CodigoProducto, CodigoProductoEspeDevo);
        }
        #endregion
    }
}
