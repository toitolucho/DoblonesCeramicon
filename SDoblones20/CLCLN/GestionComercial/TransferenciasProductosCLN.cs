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
    public class TransferenciasProductosCLN
    {
        #region Atributos de la Clase
        private TransferenciasProductosTableAdapter _TransferenciasProductosAdapter = null;
        protected TransferenciasProductosTableAdapter Adapter
        {
            get
            {
                if (_TransferenciasProductosAdapter == null)
                    _TransferenciasProductosAdapter = new TransferenciasProductosTableAdapter();
                return _TransferenciasProductosAdapter;
            }
        }
        #endregion

        #region Constructor
        public TransferenciasProductosCLN()
        {
            //constructor
        }

        #endregion


        /// <summary>
        /// Insertar un TransferenciaProducto en la Base de Datos
        /// </summary>
        /// <param name="CodigoCliente"> Codigo del Cliente</param>
        /// <param name="DIRepresentante">Representante</param>
        /// <param name="CodigoEmpresa"> Codigo de la Empresa a la  que pertenece </param>
        /// <param name="NombreCliente"> Nombre del Cliente</param>
        /// <param name="NumeroAgencia"> Numero de Agencia</param>
        /// <param name="Observaciones"> Observaciones y descripciones</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarTransferenciaProducto(int NumeroAgenciaEmisora, int NumeroAgenciaRecepctora, int CodigoUsuario, DateTime FechaHoraTransferencia, string CodigoEstadoTransferencia, decimal MontoTotalTransferencia, byte? CodigoMoneda, string Observaciones)
        {
            DSDoblones20GestionComercial2.TransferenciasProductosDataTable TransferenciasProductos = new DSDoblones20GestionComercial2.TransferenciasProductosDataTable();
            DSDoblones20GestionComercial2.TransferenciasProductosRow TransferenciaProducto = TransferenciasProductos.NewTransferenciasProductosRow();

            TransferenciaProducto.NumeroAgenciaEmisora = NumeroAgenciaEmisora;
            TransferenciaProducto.NumeroAgenciaRecepctora = NumeroAgenciaRecepctora;
            TransferenciaProducto.CodigoUsuario = CodigoUsuario;
            TransferenciaProducto.FechaHoraTransferencia = FechaHoraTransferencia;
            TransferenciaProducto.CodigoEstadoTransferencia = CodigoEstadoTransferencia;
            TransferenciaProducto.MontoTotalTransferencia = MontoTotalTransferencia;
            if (CodigoMoneda == null) TransferenciaProducto.SetCodigoMonedaNull();
            else TransferenciaProducto.CodigoMoneda = CodigoMoneda.Value;
            if (Observaciones == null) TransferenciaProducto.SetObservacionesNull();
            else TransferenciaProducto.Observaciones = Observaciones;
         
            TransferenciasProductos.AddTransferenciasProductosRow(TransferenciaProducto);

            int rowsAffected = Adapter.Update(TransferenciasProductos);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarTransferenciaProducto(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, int NumeroAgenciaRecepctora, int CodigoUsuario, DateTime FechaHoraTransferencia, string CodigoEstadoTransferencia, decimal MontoTotalTransferencia, byte? CodigoMoneda, string Observaciones)
        {
            DSDoblones20GestionComercial2.TransferenciasProductosDataTable TransferenciasProductos = Adapter.GetDataBy(NumeroAgenciaEmisora, NumeroTransferenciaProducto);
            if (TransferenciasProductos.Count == 0)
                return false;
            DSDoblones20GestionComercial2.TransferenciasProductosRow TransferenciaProducto = TransferenciasProductos[0];

            TransferenciaProducto.CodigoUsuario = CodigoUsuario;
            TransferenciaProducto.FechaHoraTransferencia = FechaHoraTransferencia;
            TransferenciaProducto.CodigoEstadoTransferencia = CodigoEstadoTransferencia;
            TransferenciaProducto.MontoTotalTransferencia = MontoTotalTransferencia;
            if (CodigoMoneda == null) TransferenciaProducto.SetCodigoMonedaNull();
            else TransferenciaProducto.CodigoMoneda = CodigoMoneda.Value;
            if (Observaciones == null) TransferenciaProducto.SetObservacionesNull();
            else TransferenciaProducto.Observaciones = Observaciones;

            int rowsAffected = Adapter.Update(TransferenciaProducto);
            return rowsAffected == 1;
        }

        public bool ActualizarTransferenciaProducto(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, string Observaciones)
        {
            DSDoblones20GestionComercial2.TransferenciasProductosDataTable TransferenciasProductos = Adapter.GetDataBy(NumeroAgenciaEmisora, NumeroTransferenciaProducto);
            if (TransferenciasProductos.Count == 0)
                return false;
            DSDoblones20GestionComercial2.TransferenciasProductosRow TransferenciaProducto = TransferenciasProductos[0];
                        
            if (Observaciones == null) TransferenciaProducto.SetObservacionesNull();
            else TransferenciaProducto.Observaciones = Observaciones;

            int rowsAffected = Adapter.Update(TransferenciaProducto);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarTransferenciaProducto(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgenciaEmisora, NumeroTransferenciaProducto);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.TransferenciasProductosDataTable ListarTransferenciasProductos(int NumeroAgenciaEmisora)
        {            
            return Adapter.GetData(NumeroAgenciaEmisora); 
        }

        
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.TransferenciasProductosDataTable ObtenerTransferenciaProducto(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto)
        {
            return Adapter.GetDataBy(NumeroAgenciaEmisora, NumeroTransferenciaProducto);
        }

        public void ActualizarCodigoEstadoTransferencia(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, string CodigoEstadoTransferencia, decimal? MontoTotalTransferencia, string CodigoTipoEnvioRecepcion)
        {
            new QTAFuncionesGestionComercial().ActualizarCodigoEstadoTransferencia(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoEstadoTransferencia, MontoTotalTransferencia, CodigoTipoEnvioRecepcion);
        }

        public DSDoblones20GestionComercial2.BuscarTransferenciaProductoDataTable BuscarTransferenciaProducto(string CodigoAmbitoBusqueda, string TextoABuscar, int? NumeroAgencia, int? NumeroTransaccion, string CodigoEstadoTransferencia, DateTime FechaInicio, DateTime FechaFin, bool ExactamenteIgual, string CodigoTipoEnvioRecepcion)
        {
            int? numCompraProducto = null;
            if (NumeroTransaccion != -1)
            {
                numCompraProducto = NumeroTransaccion;
            }
            return new BuscarTransferenciaProductoTableAdapter().GetData(CodigoAmbitoBusqueda, TextoABuscar, NumeroAgencia, numCompraProducto, CodigoEstadoTransferencia, FechaInicio, FechaFin, ExactamenteIgual, CodigoTipoEnvioRecepcion);
        }

        public DataTable ListarTransferenciaProductosReporte(int NumeroAgencia,	int NumeroTransferenciaProducto, string CodigoTipoEnvioRecepción )
        {
            return new ListarTransferenciaProductosReporteTableAdapter().GetData(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepción);
        }

        /// <summary>
        /// Transaccion que inserta toda la Transferencia, incluyendo el Detalle de Productos de la Transferencia
        /// tomar en cuenta que el detalle de transferencia es
        /// representado mediante una cadena que es un XML necesario para
        /// transformar el mismo en una tabla dentro de SQLSERVER y realizar la inserción
        /// </summary>
        /// <param name="NumeroAgenciaEmisora"></param>
        /// <param name="NumeroAgenciaRecepctora"></param>
        /// <param name="CodigoUsuario"></param>
        /// <param name="FechaHoraTransferencia"></param>
        /// <param name="CodigoEstadoTransferencia"></param>
        /// <param name="MontoTotalTransferencia"></param>
        /// <param name="CodigoMoneda"></param>
        /// <param name="Observaciones"></param>
        /// <param name="ProductoDetalle">XML que representa el Detalle de Productos</param>
        public void InsertarTransferenciaProductoXMLDetalle(int NumeroAgenciaEmisora, int NumeroAgenciaRecepctora, int CodigoUsuario, DateTime FechaHoraTransferencia, string CodigoEstadoTransferencia, decimal MontoTotalTransferencia, byte? CodigoMoneda, string Observaciones, string ProductoDetalle)
        {
            Adapter.InsertarTransferenciaProductoXMLDetalle(NumeroAgenciaEmisora, NumeroAgenciaRecepctora, CodigoUsuario, FechaHoraTransferencia, CodigoEstadoTransferencia, MontoTotalTransferencia, CodigoMoneda, Observaciones, ProductoDetalle);
        }

        public bool VerificarPosibilidadFinalizacionTransferencia(int NumeroAgencia, int NumeroTransferenciaProducto)
        {
            return new QTAFuncionesGestionComercial().VerificarPosibilidadFinalizacionTransferencia(NumeroAgencia, NumeroTransferenciaProducto).Value;
        }
       
    }
}
