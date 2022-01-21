using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD;
using CLCAD.DSDoblones20ContabilidadTableAdapters;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.Contabilidad
{
    public class AsientosDetalleCLN
    {
        private AsientosDetalleTableAdapter _AsientosDetalleTableAdapter = null;
        protected AsientosDetalleTableAdapter Adapter
        {
            get
            {
                if (_AsientosDetalleTableAdapter == null)
                    _AsientosDetalleTableAdapter = new AsientosDetalleTableAdapter();
                return _AsientosDetalleTableAdapter;
            }
        }

        public AsientosDetalleCLN()
        { }

        /// <summary>
        /// Inserta detalle de asiento
        /// </summary>
        /// <param name="CodigoUsuario"></param>
        /// <param name="Fecha"></param>
        /// <param name="Glosa"></param>
        /// <param name="Estado"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarDetalleAsiento(int NumeroAsiento, string NumeroCuenta, decimal Debe, decimal Haber)
        {
            DSDoblones20Contabilidad.AsientosDetalleDataTable detalleasientos = new DSDoblones20Contabilidad.AsientosDetalleDataTable();
            DSDoblones20Contabilidad.AsientosDetalleRow detalleasiento = detalleasientos.NewAsientosDetalleRow();

            detalleasiento.NumeroAsiento = NumeroAsiento;
            detalleasiento.NumeroCuenta = NumeroCuenta;
            detalleasiento.Debe = Debe;
            detalleasiento.Haber = Haber;

            detalleasientos.AddAsientosDetalleRow(detalleasiento);
                            
            int rowsAffected = Adapter.Update(detalleasiento);
            return rowsAffected == 1;
        }

        /// <summary>
        /// Eliminia todo el detalle de un asiento
        /// </summary>
        /// <param name="NumeroAsiento"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarDetalleAsiento(int NumeroAsiento)
        {
            int rowsAffected = Adapter.Delete(NumeroAsiento);
            return rowsAffected == 1;
        }

        /// <summary>
        /// Obtiene el detalle del asiento por el numero de asiento
        /// </summary>
        /// <param name="NumeroAsiento"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerAsientosDetalle(int NumeroAsiento)
        {
            ObtenerAsientosDetalleTableAdapter miadapter = new ObtenerAsientosDetalleTableAdapter();
            return miadapter.GetData(NumeroAsiento);
        }

    }
}
