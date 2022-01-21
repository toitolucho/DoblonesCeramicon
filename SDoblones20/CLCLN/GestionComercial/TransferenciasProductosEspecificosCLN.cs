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
    public class TransferenciasProductosEspecificosCLN
    {
        #region Atributos de la Clase
        private TransferenciasProductosEspecificosTableAdapter _TransferenciasProductosEspecificosAdapter = null;
        private QTAFuncionesGestionComercial _QTAFuncionesGestionComercial = null;
        protected QTAFuncionesGestionComercial AdapterQTAFuncionesGestionComercial
        {
            get
            {
                if (_QTAFuncionesGestionComercial == null)
                    _QTAFuncionesGestionComercial = new QTAFuncionesGestionComercial();
                return _QTAFuncionesGestionComercial;
            }
        }
        protected TransferenciasProductosEspecificosTableAdapter Adapter
        {
            get
            {
                if (_TransferenciasProductosEspecificosAdapter == null)
                    _TransferenciasProductosEspecificosAdapter = new TransferenciasProductosEspecificosTableAdapter();
                return _TransferenciasProductosEspecificosAdapter;
            }
        }
        #endregion

        #region Constructor
        public TransferenciasProductosEspecificosCLN()
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
        /// <param name="NombreTransferenciaProductoDetalleDetalle"> Nombre del TransferenciaProductoEspecificoDetalle</param>
        /// <param name="NumeroAgencia"> Numero de Agencia</param>
        /// <param name="Observaciones"> Observaciones y descripciones</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarTransferenciaProductoEspecifico(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, string CodigoProducto, string CodigoProductoEspecifico, bool? Entregado, string CodigoEstadoRecepcion, DateTime? FechaHoraEnvio, DateTime? FechaHoraRecepcion)
        {
            DSDoblones20GestionComercial2.TransferenciasProductosEspecificosDataTable TransferenciasProductosEspecificos = new DSDoblones20GestionComercial2.TransferenciasProductosEspecificosDataTable();
            DSDoblones20GestionComercial2.TransferenciasProductosEspecificosRow TransferenciaProductoEspecifico = TransferenciasProductosEspecificos.NewTransferenciasProductosEspecificosRow();

            TransferenciaProductoEspecifico.NumeroAgenciaEmisora = NumeroAgenciaEmisora;
            TransferenciaProductoEspecifico.NumeroTransferenciaProducto = NumeroTransferenciaProducto;
            TransferenciaProductoEspecifico.CodigoProducto = CodigoProducto;
            TransferenciaProductoEspecifico.CodigoProductoEspecifico = CodigoProductoEspecifico;
            if (Entregado == null) TransferenciaProductoEspecifico.SetEntregadoNull();
            else TransferenciaProductoEspecifico.Entregado = Entregado.Value;
            if (FechaHoraEnvio == null) TransferenciaProductoEspecifico.SetFechaHoraEnvioNull();
            else TransferenciaProductoEspecifico.FechaHoraEnvio = FechaHoraEnvio.Value;
            if (FechaHoraRecepcion == null) TransferenciaProductoEspecifico.SetFechaHoraRecepcionNull();
            else TransferenciaProductoEspecifico.FechaHoraRecepcion = FechaHoraRecepcion.Value;
            if (CodigoEstadoRecepcion == null) TransferenciaProductoEspecifico.SetCodigoEstadoRecepcionNull();
            else TransferenciaProductoEspecifico.CodigoEstadoRecepcion = CodigoEstadoRecepcion;
         
            TransferenciasProductosEspecificos.AddTransferenciasProductosEspecificosRow(TransferenciaProductoEspecifico);

            int rowsAffected = Adapter.Update(TransferenciasProductosEspecificos);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarTransferenciaProductoEspecifico(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, string CodigoProducto, string CodigoProductoEspecifico, bool? Entregado, string CodigoEstadoRecepcion, DateTime? FechaHoraEnvio, DateTime? FechaHoraRecepcion)
        {
            DSDoblones20GestionComercial2.TransferenciasProductosEspecificosDataTable TransferenciasProductosEspecificos = Adapter.GetDataBy(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, CodigoProductoEspecifico);
            if (TransferenciasProductosEspecificos.Count == 0)
                return false;
            DSDoblones20GestionComercial2.TransferenciasProductosEspecificosRow TransferenciaProductoEspecifico = TransferenciasProductosEspecificos[0];

            if (Entregado == null) TransferenciaProductoEspecifico.SetEntregadoNull();
            else TransferenciaProductoEspecifico.Entregado = Entregado.Value;
            if (FechaHoraEnvio == null) TransferenciaProductoEspecifico.SetFechaHoraEnvioNull();
            else TransferenciaProductoEspecifico.FechaHoraEnvio = FechaHoraEnvio.Value;
            if (FechaHoraRecepcion == null) TransferenciaProductoEspecifico.SetFechaHoraRecepcionNull();
            else TransferenciaProductoEspecifico.FechaHoraRecepcion = FechaHoraRecepcion.Value;
            if (CodigoEstadoRecepcion == null) TransferenciaProductoEspecifico.SetCodigoEstadoRecepcionNull();
            else TransferenciaProductoEspecifico.CodigoEstadoRecepcion = CodigoEstadoRecepcion;

            int rowsAffected = Adapter.Update(TransferenciaProductoEspecifico);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarTransferenciaProductoEspecifico(int NumeroAgenciaEmisora, int NumeroTransferenciaProductoEspecifico, string CodigoProducto, string CodigoProductoEspecifico)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgenciaEmisora, NumeroTransferenciaProductoEspecifico, CodigoProducto, CodigoProductoEspecifico);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.TransferenciasProductosEspecificosDataTable ListarTransferenciasProductosEspecificos(int NumeroAgenciaEmisora)
        {            
            return Adapter.GetData(NumeroAgenciaEmisora); 
        }

        
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.TransferenciasProductosEspecificosDataTable ObtenerTransferenciaProductoEspecifico(int NumeroAgenciaEmisora, int NumeroTransferenciaProductoEspecifico, string CodigoProducto, string CodigoProductoEspecifico)
        {
            return Adapter.GetDataBy(NumeroAgenciaEmisora, NumeroTransferenciaProductoEspecifico, CodigoProducto, CodigoProductoEspecifico);
        }

        public DSDoblones20GestionComercial2.ListarTransferenciasProductosEspecificosParaMostrarDataTable ListarTransferenciasProductosEspecificosParaMostrar(int NumeroAgenciaEmisora, int NumeroTransferenciaProductoEspecifico, string CodigoTipoINOUT)
        {
            return new ListarTransferenciasProductosEspecificosParaMostrarTableAdapter().GetData(NumeroAgenciaEmisora, NumeroTransferenciaProductoEspecifico, CodigoTipoINOUT);
        }

        public DSDoblones20GestionComercial2.ListarCodigosProductosEspecificosTransferenciasDataTable ListarCodigosProductosEspecificosTransferencias(int NumeroAgencia, int NumeroTransferenciaProducto, string CodigoProducto, string CodigoTipoEnvioRecepcion)
        {
            return new ListarCodigosProductosEspecificosTransferenciasTableAdapter().GetData(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, CodigoTipoEnvioRecepcion);
        }

        public void ActualizarTransferenciaProductoEspecificoFechaRecepcion(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, string CodigoProducto, string CodigoProductoEspecifico, bool? Entregado, DateTime? FechaHoraRecepcion, string CodigoEstadoRecepcion)
        {
            AdapterQTAFuncionesGestionComercial.ActualizarTransferenciaProductoEspecificoFechaRecepcion(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, CodigoProductoEspecifico, Entregado, FechaHoraRecepcion, CodigoEstadoRecepcion);
        }

        public DSDoblones20GestionComercial2.ListarCodigosEspecificosFaltantesRecepcionDataTable ListarCodigosEspecificosFaltantesRecepcion(int NumeroAgencia ,	int NumeroTransferencia, string CodigoProducto, DateTime? FechaHoraEnvio)
        {
            return new ListarCodigosEspecificosFaltantesRecepcionTableAdapter().GetData(NumeroAgencia, NumeroTransferencia, CodigoProducto, FechaHoraEnvio);
        }

        public void ActualizarTransferenciaProductoEspecificoRecepcionIncorrecta(int NumeroAgencia, int NumeroTransferenciaProducto, DateTime? FechaHoraRecepcion)
        {
            AdapterQTAFuncionesGestionComercial.ActualizarTransferenciaProductoEspecificoRecepcionIncorrecta(NumeroAgencia, NumeroTransferenciaProducto, FechaHoraRecepcion);
        }

        public DataTable ListarTransferenciaProductosEspecificosReporte(int NumeroAgencia, int NumeroTransferenciaProducto, string CodigoTipoEnvioRecepción, DateTime? FechaHoraEnvioRecepcion)
        {
            return new ListarTransferenciaProductosEspecificosReporteTableAdapter().GetData(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepción, FechaHoraEnvioRecepcion);
        }

        public DataTable ListarTransferenciaProductosEspecificosGeneralReporte(int NumeroAgencia, int NumeroTransferenciaProducto, string CodigoTipoEnvioRecepción)
        {
            return new ListarTransferenciaProductosEspecificosGeneralReporteTableAdapter().GetData(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepción);
        }
        
    }
}
