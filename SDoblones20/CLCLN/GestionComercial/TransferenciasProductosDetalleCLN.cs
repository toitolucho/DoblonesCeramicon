using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercial2TableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.GestionComercial
{
    public class TransferenciasProductosDetalleCLN
    {
        #region Atributos de la Clase
        private TransferenciasProductosDetalleTableAdapter _TransferenciasProductosDetalleAdapter = null;
        protected TransferenciasProductosDetalleTableAdapter Adapter
        {
            get
            {
                if (_TransferenciasProductosDetalleAdapter == null)
                    _TransferenciasProductosDetalleAdapter = new TransferenciasProductosDetalleTableAdapter();
                return _TransferenciasProductosDetalleAdapter;
            }
        }
        #endregion

        #region Constructor
        public TransferenciasProductosDetalleCLN()
        {
            //constructor
        }

        #endregion


        /// <summary>
        /// Insertar un TransferenciaProductoDetalle en la Base de Datos
        /// </summary>
        /// <param name="CodigoTransferenciaProductoDetalleDetalle"> Codigo del TransferenciaProductoDetalleDetalle</param>
        /// <param name="DIRepresentante">Representante</param>
        /// <param name="CodigoEmpresa"> Codigo de la Empresa a la  que pertenece </param>
        /// <param name="NombreTransferenciaProductoDetalleDetalle"> Nombre del TransferenciaProductoDetalleDetalle</param>
        /// <param name="NumeroAgencia"> Numero de Agencia</param>
        /// <param name="Observaciones"> Observaciones y descripciones</param>
        /// <returns></returns>
        
        public bool InsertarTransferenciaProductoDetalle(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, string CodigoProducto, int CantidadTransferencia, decimal PrecioUnitarioTransferencia, decimal? MontoAdicionalPorGastos)
        {
            DSDoblones20GestionComercial2.TransferenciasProductosDetalleDataTable TransferenciasProductosDetalle = new DSDoblones20GestionComercial2.TransferenciasProductosDetalleDataTable();
            DSDoblones20GestionComercial2.TransferenciasProductosDetalleRow TransferenciaProductoDetalle = TransferenciasProductosDetalle.NewTransferenciasProductosDetalleRow();

            TransferenciaProductoDetalle.NumeroAgenciaEmisora = NumeroAgenciaEmisora;
            TransferenciaProductoDetalle.NumeroTransferenciaProducto = NumeroTransferenciaProducto;
            TransferenciaProductoDetalle.CodigoProducto = CodigoProducto;
            TransferenciaProductoDetalle.CantidadTransferencia = CantidadTransferencia;
            TransferenciaProductoDetalle.PrecioUnitarioTransferencia = PrecioUnitarioTransferencia;
            if (MontoAdicionalPorGastos == null) TransferenciaProductoDetalle.SetMontoAdicionalPorGastosNull();
            else TransferenciaProductoDetalle.MontoAdicionalPorGastos = MontoAdicionalPorGastos.Value;
            
         
            TransferenciasProductosDetalle.AddTransferenciasProductosDetalleRow(TransferenciaProductoDetalle);

            int rowsAffected = Adapter.Update(TransferenciasProductosDetalle);
            return rowsAffected == 1;
        }

        
        public bool ActualizarTransferenciaProductoDetalle(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, string CodigoProducto, int CantidadTransferencia, decimal PrecioUnitarioTransferencia, decimal? MontoAdicionalPorGastos)
        {
            DSDoblones20GestionComercial2.TransferenciasProductosDetalleDataTable TransferenciasProductosDetalle = Adapter.GetDataBy(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto);
            if (TransferenciasProductosDetalle.Count == 0)
                return false;
            DSDoblones20GestionComercial2.TransferenciasProductosDetalleRow TransferenciaProductoDetalle = TransferenciasProductosDetalle[0];
                      
            TransferenciaProductoDetalle.CantidadTransferencia = CantidadTransferencia;
            TransferenciaProductoDetalle.PrecioUnitarioTransferencia = PrecioUnitarioTransferencia;
            if (MontoAdicionalPorGastos == null) TransferenciaProductoDetalle.SetMontoAdicionalPorGastosNull();
            else TransferenciaProductoDetalle.MontoAdicionalPorGastos = MontoAdicionalPorGastos.Value;

            int rowsAffected = Adapter.Update(TransferenciaProductoDetalle);
            return rowsAffected == 1;
        }


        
        public bool EliminarTransferenciaProductoDetalle(int NumeroAgenciaEmisora, int NumeroTransferenciaProductoDetalle, string CodigoProducto)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgenciaEmisora, NumeroTransferenciaProductoDetalle, CodigoProducto);
            return rowsAffedted == 1;
        }


        
        public DSDoblones20GestionComercial2.TransferenciasProductosDetalleDataTable ListarTransferenciasProductosDetalle(int NumeroAgenciaEmisora)
        {            
            return Adapter.GetData(NumeroAgenciaEmisora); 
        }

        
        
        public DSDoblones20GestionComercial2.TransferenciasProductosDetalleDataTable ObtenerTransferenciaProductoDetalle(int NumeroAgenciaEmisora, int NumeroTransferenciaProductoDetalle, string CodigoProducto)
        {
            return Adapter.GetDataBy(NumeroAgenciaEmisora, NumeroTransferenciaProductoDetalle, CodigoProducto);
        }

        public DSDoblones20GestionComercial2.ListarTransferenciasProductosDetalleParaMostrarDataTable ListarTransferenciasProductosDetalleParaMostrar(int NumeroAgenciaEmisora, int NumeroTransferenciaProductoDetalle)
        {
            return new ListarTransferenciasProductosDetalleParaMostrarTableAdapter().GetData(NumeroAgenciaEmisora, NumeroTransferenciaProductoDetalle);
        }

        public DSDoblones20GestionComercial2.ListarTransferenciaProductosEnviadosRecepcionadosDataTable ListarTransferenciaProductosEnviadosRecepcionados(int NumeroAgencia, int NumeroTransferenciaProducto, string TipoVisualizacion, bool MostrarSoloFaltantes)
        {
            return new ListarTransferenciaProductosEnviadosRecepcionadosTableAdapter().GetData(NumeroAgencia, NumeroTransferenciaProducto, TipoVisualizacion, MostrarSoloFaltantes);
        }

        public DSDoblones20GestionComercial2.ListarTransferenciasProductosDetalleGastosDataTable ListarTransferenciasProductosDetalleGastos(int NumeroAgenciaEmisora, int NumeroTransferenciaProductoDetalle, string ListadoProductos, string CodigoTipoEnvioRecepcion)
        {
            return new ListarTransferenciasProductosDetalleGastosTableAdapter().GetData(NumeroAgenciaEmisora, NumeroTransferenciaProductoDetalle, CodigoTipoEnvioRecepcion, ListadoProductos);        
        }

        public DataTable ListarTransferenciaProductosDetalleReporte(int NumeroAgenciaEmisora, int NumeroTransferenciaProductoDetalle, string CodigoTipoEnvioRecepcion)
        {
            return new ListarTransferenciaProductosDetalleReporteTableAdapter().GetData(NumeroAgenciaEmisora, NumeroTransferenciaProductoDetalle, CodigoTipoEnvioRecepcion);        

        }

    }
}
