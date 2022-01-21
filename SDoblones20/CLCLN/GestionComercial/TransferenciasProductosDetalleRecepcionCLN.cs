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
    public class TransferenciasProductosDetalleRecepcionRecepcionCLN
    {
        #region Atributos de la Clase
        private TransferenciasProductosDetalleRecepcionTableAdapter _TransferenciasProductosDetalleRecepcionAdapter = null;
        protected TransferenciasProductosDetalleRecepcionTableAdapter Adapter
        {
            get
            {
                if (_TransferenciasProductosDetalleRecepcionAdapter == null)
                    _TransferenciasProductosDetalleRecepcionAdapter = new TransferenciasProductosDetalleRecepcionTableAdapter();
                return _TransferenciasProductosDetalleRecepcionAdapter;
            }
        }
        #endregion

        #region Constructor
        public TransferenciasProductosDetalleRecepcionRecepcionCLN()
        {
            //constructor
        }

        #endregion


        /// <summary>
        /// Insertar un TransferenciaProductoDetalleRecepcion en la Base de Datos
        /// </summary>
        /// <param name="CodigoTransferenciaProductoDetalleRecepcionDetalle"> Codigo del TransferenciaProductoDetalleRecepcionDetalle</param>
        /// <param name="DIRepresentante">Representante</param>
        /// <param name="CodigoEmpresa"> Codigo de la Empresa a la  que pertenece </param>
        /// <param name="NombreTransferenciaProductoDetalleRecepcionRecepcionDetalle"> Nombre del TransferenciaProductoDetalleRecepcionDetalle</param>
        /// <param name="NumeroAgencia"> Numero de Agencia</param>
        /// <param name="Observaciones"> Observaciones y descripciones</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarTransferenciaProductoDetalleRecepcion(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, string CodigoProducto, DateTime FechaHoraEnvioRecepcion, int CantidadEnvioRecepcion, string CodigoTipoEnvioRecepcion)
        {
            DSDoblones20GestionComercial2.TransferenciasProductosDetalleRecepcionDataTable TransferenciasProductosDetalleRecepcion = new DSDoblones20GestionComercial2.TransferenciasProductosDetalleRecepcionDataTable();
            DSDoblones20GestionComercial2.TransferenciasProductosDetalleRecepcionRow TransferenciaProductoDetalleRecepcion = TransferenciasProductosDetalleRecepcion.NewTransferenciasProductosDetalleRecepcionRow();

            TransferenciaProductoDetalleRecepcion.NumeroAgenciaEmisora = NumeroAgenciaEmisora;
            TransferenciaProductoDetalleRecepcion.NumeroTransferenciaProducto = NumeroTransferenciaProducto;
            TransferenciaProductoDetalleRecepcion.CodigoProducto = CodigoProducto;
            TransferenciaProductoDetalleRecepcion.FechaHoraEnvioRecepcion = FechaHoraEnvioRecepcion;
            TransferenciaProductoDetalleRecepcion.CantidadEnvioRecepcion = CantidadEnvioRecepcion;
            TransferenciaProductoDetalleRecepcion.CodigoTipoEnvioRecepcion = CodigoTipoEnvioRecepcion;
            TransferenciaProductoDetalleRecepcion.SetFechaHoraEnvioPadreNull();
            TransferenciasProductosDetalleRecepcion.AddTransferenciasProductosDetalleRecepcionRow(TransferenciaProductoDetalleRecepcion);

            int rowsAffected = Adapter.Update(TransferenciasProductosDetalleRecepcion);
            return rowsAffected == 1;
        }

        public bool InsertarTransferenciaProductoDetalleRecepcion(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, string CodigoProducto, DateTime FechaHoraEnvioRecepcion, int CantidadEnvioRecepcion, string CodigoTipoEnvioRecepcion, DateTime? FechaHoraEnvioPadre)
        {
            DSDoblones20GestionComercial2.TransferenciasProductosDetalleRecepcionDataTable TransferenciasProductosDetalleRecepcion = new DSDoblones20GestionComercial2.TransferenciasProductosDetalleRecepcionDataTable();
            DSDoblones20GestionComercial2.TransferenciasProductosDetalleRecepcionRow TransferenciaProductoDetalleRecepcion = TransferenciasProductosDetalleRecepcion.NewTransferenciasProductosDetalleRecepcionRow();

            TransferenciaProductoDetalleRecepcion.NumeroAgenciaEmisora = NumeroAgenciaEmisora;
            TransferenciaProductoDetalleRecepcion.NumeroTransferenciaProducto = NumeroTransferenciaProducto;
            TransferenciaProductoDetalleRecepcion.CodigoProducto = CodigoProducto;
            TransferenciaProductoDetalleRecepcion.FechaHoraEnvioRecepcion = FechaHoraEnvioRecepcion;
            TransferenciaProductoDetalleRecepcion.CantidadEnvioRecepcion = CantidadEnvioRecepcion;
            TransferenciaProductoDetalleRecepcion.CodigoTipoEnvioRecepcion = CodigoTipoEnvioRecepcion;
            if (FechaHoraEnvioPadre == null) TransferenciaProductoDetalleRecepcion.SetFechaHoraEnvioPadreNull();
            else TransferenciaProductoDetalleRecepcion.FechaHoraEnvioPadre = FechaHoraEnvioPadre.Value;

            TransferenciasProductosDetalleRecepcion.AddTransferenciasProductosDetalleRecepcionRow(TransferenciaProductoDetalleRecepcion);

            int rowsAffected = Adapter.Update(TransferenciasProductosDetalleRecepcion);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarTransferenciaProductoDetalleRecepcion(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, string CodigoProducto, DateTime FechaHoraEnvioRecepcion, int CantidadEnvioRecepcion, string CodigoTipoEnvioRecepcion)
        {
            DSDoblones20GestionComercial2.TransferenciasProductosDetalleRecepcionDataTable TransferenciasProductosDetalleRecepcion = Adapter.GetDataBy(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, FechaHoraEnvioRecepcion);
            if (TransferenciasProductosDetalleRecepcion.Count == 0)
                return false;
            DSDoblones20GestionComercial2.TransferenciasProductosDetalleRecepcionRow TransferenciaProductoDetalleRecepcion = TransferenciasProductosDetalleRecepcion[0];

            TransferenciaProductoDetalleRecepcion.FechaHoraEnvioRecepcion = FechaHoraEnvioRecepcion;
            TransferenciaProductoDetalleRecepcion.CantidadEnvioRecepcion = CantidadEnvioRecepcion;
            TransferenciaProductoDetalleRecepcion.CodigoTipoEnvioRecepcion = CodigoTipoEnvioRecepcion;

            int rowsAffected = Adapter.Update(TransferenciaProductoDetalleRecepcion);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarTransferenciaProductoDetalleRecepcion(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, string CodigoProducto, DateTime FechaHoraEnvioRecepcion)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, FechaHoraEnvioRecepcion);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.TransferenciasProductosDetalleRecepcionDataTable ListarTransferenciasProductosDetalleRecepcion(int NumeroAgenciaEmisora)
        {            
            return Adapter.GetData(NumeroAgenciaEmisora); 
        }

        
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.TransferenciasProductosDetalleRecepcionDataTable ObtenerTransferenciaProductoDetalle(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, string CodigoProducto, DateTime FechaHoraEnvioRecepcion)
        {
            return Adapter.GetDataBy(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoProducto, FechaHoraEnvioRecepcion);
        }

        public DSDoblones20GestionComercial2.ListarTransferenciasProductosDetalleRecepcionParaMostrarDataTable ListarTransferenciasProductosDetalleRecepcionParaMostrar(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, string CodigoTipoINOUT)
        {
            return new ListarTransferenciasProductosDetalleRecepcionParaMostrarTableAdapter().GetData(NumeroAgenciaEmisora, NumeroTransferenciaProducto, CodigoTipoINOUT);
        }

        public DSDoblones20GestionComercial2.ListarTransferenciasProductosFechasEnvioDataTable ListarTransferenciasProductosFechasEnvio(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto)
        {
            return new ListarTransferenciasProductosFechasEnvioTableAdapter().GetData(NumeroAgenciaEmisora, NumeroTransferenciaProducto);
        }


        /// <summary>
        /// Listar los Productos Que han sido enviados
        /// en una Transferencias
        /// </summary>
        /// <param name="NumeroAgenciaEmisora">NumeroAgencia </param>
        /// <param name="NumeroTransferenciaProducto">Numero Transferencias Producto</param>
        /// <param name="FechaEnvio">Fecha en la que se envia , si es NULL, se selecciona en uno todos los envios
        /// para recepcionar todos los productos</param>
        /// <returns></returns>
        public DSDoblones20GestionComercial2.ListarTransferenciaProductosEnviadosPorFechaDataTable
            ListarTransferenciaProductosEnviadosPorFecha(int NumeroAgenciaEmisora, int NumeroTransferenciaProducto, DateTime? FechaEnvio)
        {
            return new ListarTransferenciaProductosEnviadosPorFechaTableAdapter().GetData(NumeroAgenciaEmisora, NumeroTransferenciaProducto, FechaEnvio);
        }

        public DataTable ListarTransferenciaProductosDetalleRecepcionEnvioReporte(int NumeroAgencia, int NumeroTransferenciaProducto, string CodigoTipoEnvioRecepcion, DateTime FechaHoraRecepcionEnvio)
        {
            return new ListarTransferenciaProductosDetalleRecepcionEnvioReporteTableAdapter().GetData(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion, FechaHoraRecepcionEnvio);
        }

        public DataTable ListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte(int NumeroAgencia, int NumeroTransferenciaProducto, string CodigoTipoEnvioRecepcion)
        {
            return new ListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporteTableAdapter().GetData(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion);
        }
    }
}
