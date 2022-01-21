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
    public class TransferenciasProductosGastosDetalleCLN
    {
        #region Atributos de la Clase
        private TransferenciasProductosGastosDetalleTableAdapter _TransferenciasProductosGastosDetalleAdapter = null;
        protected TransferenciasProductosGastosDetalleTableAdapter Adapter
        {
            get
            {
                if (_TransferenciasProductosGastosDetalleAdapter == null)
                    _TransferenciasProductosGastosDetalleAdapter = new TransferenciasProductosGastosDetalleTableAdapter();
                return _TransferenciasProductosGastosDetalleAdapter;
            }
        }

        private QTAFuncionesGestionComercial _QTAFuncionesGestionComercial = null;
        protected QTAFuncionesGestionComercial AdapterFuncionesGestionComercial
        {
            get
            {
                if (_QTAFuncionesGestionComercial == null)
                    _QTAFuncionesGestionComercial = new QTAFuncionesGestionComercial();
                return _QTAFuncionesGestionComercial;
            }
        }
        #endregion

        #region Constructor
        public TransferenciasProductosGastosDetalleCLN()
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
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarTransferenciaProductoGastoDetalle(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, int CodigoGastosTipos, DateTime FechaHoraGasto, decimal MontoPagoGasto, byte? CodigoMonedaPago, string Observaciones, bool? CodigoEstadoGastoAplicado, string CodigoTipoGastoRecepcion)
        {
            DSDoblones20GestionComercial2.TransferenciasProductosGastosDetalleDataTable TransferenciasProductosGastosDetalle = new DSDoblones20GestionComercial2.TransferenciasProductosGastosDetalleDataTable();
            DSDoblones20GestionComercial2.TransferenciasProductosGastosDetalleRow TransferenciaProductoGastoDetalle = TransferenciasProductosGastosDetalle.NewTransferenciasProductosGastosDetalleRow();

            TransferenciaProductoGastoDetalle.NumeroAgenciaEmisora = NumeroAgenciaEmisora;
            TransferenciaProductoGastoDetalle.NumeroTransferenciaProducto = NumeroTransferenciaProducto;
            TransferenciaProductoGastoDetalle.CodigoGastosTipos = CodigoGastosTipos;
            TransferenciaProductoGastoDetalle.FechaHoraGasto = FechaHoraGasto;
            TransferenciaProductoGastoDetalle.MontoPagoGasto = MontoPagoGasto;
            if (CodigoMonedaPago == null) TransferenciaProductoGastoDetalle.SetCodigoMonedaPagoNull();
            else TransferenciaProductoGastoDetalle.CodigoMonedaPago = CodigoMonedaPago.Value;
            if (Observaciones == null) TransferenciaProductoGastoDetalle.SetObservacionesNull();
            else TransferenciaProductoGastoDetalle.Observaciones = Observaciones;
            if (CodigoEstadoGastoAplicado == null) TransferenciaProductoGastoDetalle.SetCodigoEstadoGastoAplicadoNull();
            else TransferenciaProductoGastoDetalle.CodigoEstadoGastoAplicado = CodigoEstadoGastoAplicado.Value;
            if (CodigoTipoGastoRecepcion == null) TransferenciaProductoGastoDetalle.SetCodigoTipoGastoRecepcionNull();
            else TransferenciaProductoGastoDetalle.CodigoTipoGastoRecepcion = CodigoTipoGastoRecepcion;
            
         
            TransferenciasProductosGastosDetalle.AddTransferenciasProductosGastosDetalleRow(TransferenciaProductoGastoDetalle);

            int rowsAffected = Adapter.Update(TransferenciasProductosGastosDetalle);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarTransferenciaProductoGastoDetalle(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, int NumeroTransaferenciaProductoGasto, int CodigoGastosTipos, DateTime FechaHoraGasto, decimal MontoPagoGasto, byte? CodigoMonedaPago, string Observaciones, bool? CodigoEstadoGastoAplicado, string CodigoTipoGastoRecepcion)
        {
            DSDoblones20GestionComercial2.TransferenciasProductosGastosDetalleDataTable TransferenciasProductosGastosDetalle = Adapter.GetDataBy1(NumeroAgenciaEmisora, NumeroTransferenciaProducto, NumeroTransaferenciaProductoGasto);
            if (TransferenciasProductosGastosDetalle.Count == 0)
                return false;
            DSDoblones20GestionComercial2.TransferenciasProductosGastosDetalleRow TransferenciaProductoGastoDetalle = TransferenciasProductosGastosDetalle[0];

            TransferenciaProductoGastoDetalle.FechaHoraGasto = FechaHoraGasto;
            TransferenciaProductoGastoDetalle.MontoPagoGasto = MontoPagoGasto;
            if (CodigoMonedaPago == null) TransferenciaProductoGastoDetalle.SetCodigoMonedaPagoNull();
            else TransferenciaProductoGastoDetalle.CodigoMonedaPago = CodigoMonedaPago.Value;
            if (Observaciones == null) TransferenciaProductoGastoDetalle.SetObservacionesNull();
            else TransferenciaProductoGastoDetalle.Observaciones = Observaciones;
            if (CodigoEstadoGastoAplicado == null) TransferenciaProductoGastoDetalle.SetCodigoEstadoGastoAplicadoNull();
            else TransferenciaProductoGastoDetalle.CodigoEstadoGastoAplicado = CodigoEstadoGastoAplicado.Value;
            if (CodigoTipoGastoRecepcion == null) TransferenciaProductoGastoDetalle.SetCodigoTipoGastoRecepcionNull();
            else TransferenciaProductoGastoDetalle.CodigoTipoGastoRecepcion = CodigoTipoGastoRecepcion;

            int rowsAffected = Adapter.Update(TransferenciaProductoGastoDetalle);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarTransferenciaProductoGastoDetalle(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, int NumeroTransaferenciaProductoGasto)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgenciaEmisora, NumeroTransferenciaProducto, NumeroTransaferenciaProductoGasto);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.TransferenciasProductosGastosDetalleDataTable ListarTransferenciasProductosGastosDetalle(int NumeroAgenciaEmisora)
        {            
            return Adapter.GetData(NumeroAgenciaEmisora); 
        }

        
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.TransferenciasProductosGastosDetalleDataTable ObtenerTransferenciaProductoGastoDetalle(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, int NumeroTransaferenciaProductoGasto)
        {
            return Adapter.GetDataBy1(NumeroAgenciaEmisora, NumeroTransferenciaProducto, NumeroTransaferenciaProductoGasto);
        }

        public DSDoblones20GestionComercial2.ListarTransferenciaProductoGastosDetalleParaMostrarDataTable ListarTransferenciaProductoGastosDetalleParaMostrar(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, string CodigoTipoEnvioRecepcion)
        {
            return new ListarTransferenciaProductoGastosDetalleParaMostrarTableAdapter().GetData(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion);
        }

        public DSDoblones20GestionComercial2.ListarGastosPorTransferenciasDataTable ListarGastosPorTransferencias(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, string CodigoTipoEnvioRecepcion)
        {
            return new ListarGastosPorTransferenciasTableAdapter().GetData(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion);
        }

        public bool ExisteGastosParaTransferencia(int NumeroAgencia , int NumeroTransferenciaProducto , string CodigoTipoEnvioRecepcion )
        {
            return AdapterFuncionesGestionComercial.ExisteGastosParaTransferencia(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion).Value;
        }

        public void ActualizarTransferenciaProductosGastosDetalleGeneral(int NumeroAgencia , int NumeroTransferenciaProducto , string CodigoTipoEnvioRecepcion)
        {
            AdapterFuncionesGestionComercial.ActualizarTransferenciaProductosGastosDetalleGeneral(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion);
        }

        public void ActualizarTransferenciasProductosGastosAdicionalesProrrateados(int NumeroAgencia, int NumeroTransferenciaProducto, string CodigoTipoEnvioRecepcion, DateTime FechaHoraEnvioRecepcion)
        {
            AdapterFuncionesGestionComercial.ActualizarTransferenciasProductosGastosAdicionalesProrrateados(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion, FechaHoraEnvioRecepcion);
        }

        public void ActualizarTransferenciasProductosMontoAdicionalGastos(int NumeroAgencia, int NumeroTransferenciaProducto, string CodigoProducto, string CodigoTipoEnvioRecepcion, decimal MontoAdicional)
        {
            AdapterFuncionesGestionComercial.ActualizarTransferenciasProductosMontoAdicionalGastos(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, CodigoTipoEnvioRecepcion, MontoAdicional);
        }

        public void ActualizarTransferenciaProductoGastosDetalleObservaciones(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, int NumeroTransaferenciaProductoGasto, decimal? MontoPagoGasto, string Observaciones)
        {
            Adapter.ActualizarTransferenciaProductoGastosDetalleObservaciones(NumeroAgenciaEmisora, NumeroTransferenciaProducto, NumeroTransaferenciaProductoGasto, MontoPagoGasto, Observaciones);
        }
    }
}
