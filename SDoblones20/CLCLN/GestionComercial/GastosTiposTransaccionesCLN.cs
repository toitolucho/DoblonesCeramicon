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
    public class GastosTiposTransaccionesCLN
    {
        #region Atributos de la Clase
        private GastosTiposTransaccionesTableAdapter _GastosTiposTransaccionesAdapter = null;
        protected GastosTiposTransaccionesTableAdapter Adapter
        {
            get
            {
                if (_GastosTiposTransaccionesAdapter == null)
                    _GastosTiposTransaccionesAdapter = new GastosTiposTransaccionesTableAdapter();
                return _GastosTiposTransaccionesAdapter;
            }
        }
        #endregion

        #region Constructor
        public GastosTiposTransaccionesCLN()
        {
            //constructor
        }

        #endregion


        /// <summary>
        /// Insertar un Tipo de Gasto
        /// </summary>
        /// <param name="NombreGasto"></param>
        /// <param name="DescripcionGasto"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarGastoTipoTransaccion(string NombreGasto, string DescripcionGasto)
        {
            DSDoblones20GestionComercial.GastosTiposTransaccionesDataTable GastosTiposTransacciones = new DSDoblones20GestionComercial.GastosTiposTransaccionesDataTable();
            DSDoblones20GestionComercial.GastosTiposTransaccionesRow GastoTipoTransaccion = GastosTiposTransacciones.NewGastosTiposTransaccionesRow();
                        
            GastoTipoTransaccion.NombreGasto = NombreGasto;
            if (DescripcionGasto == null) GastoTipoTransaccion.SetDescripcionGastoNull();
            else GastoTipoTransaccion.DescripcionGasto = DescripcionGasto;
            
                     
            GastosTiposTransacciones.AddGastosTiposTransaccionesRow(GastoTipoTransaccion);

            int rowsAffected = Adapter.Update(GastosTiposTransacciones);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarGastoTipoTransaccion(int CodigoGastosTipos, string NombreGasto, string DescripcionGasto)
        {
            DSDoblones20GestionComercial.GastosTiposTransaccionesDataTable GastosTiposTransacciones = Adapter.GetDataBy(CodigoGastosTipos);
            if (GastosTiposTransacciones.Count == 0)
                return false;
            DSDoblones20GestionComercial.GastosTiposTransaccionesRow GastoTipoTransaccion = GastosTiposTransacciones[0];

            
            GastoTipoTransaccion.NombreGasto = NombreGasto;
            if (DescripcionGasto == null) GastoTipoTransaccion.SetDescripcionGastoNull();
            else GastoTipoTransaccion.DescripcionGasto = DescripcionGasto;

            int rowsAffected = Adapter.Update(GastoTipoTransaccion);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarGastoTipoTransaccion(int CodigoGastosTipos)
        {
            int rowsAffedted = Adapter.Delete(CodigoGastosTipos);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial.GastosTiposTransaccionesDataTable ListarGastosTiposTransacciones()
        {
            /*for (int i = 0; i < dataTable.Columns.Count; i++)
                dataTable.Columns[i].AllowDBNull = true;*/
            return Adapter.GetData(); 
        }

        
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial.GastosTiposTransaccionesDataTable ObtenerGastoTipoTransaccion(int CodigoGastosTipos)
        {
            return Adapter.GetDataBy(CodigoGastosTipos);
        }
    }
}
