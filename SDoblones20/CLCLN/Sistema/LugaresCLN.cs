using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.Sistema
{
    [System.ComponentModel.DataObject]
    public class LugaresCLN
    {
        
        private LugaresTableAdapter _LugaresAdapter = null;
        protected LugaresTableAdapter Adapter
        {
            get
            {
                if (_LugaresAdapter == null)
                    _LugaresAdapter = new LugaresTableAdapter();
                return _LugaresAdapter;
            }
        }

        public LugaresCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarLugar(string CodigoPais, string CodigoDepartamento, string CodigoProvincia, string CodigoLugar, string NombreLugar)		
        {
            
            DSDoblones20Sistema.LugaresDataTable Lugares = new DSDoblones20Sistema.LugaresDataTable();
            DSDoblones20Sistema.LugaresRow Lugar = Lugares.NewLugaresRow();

            Lugar.CodigoPais = CodigoPais;
            Lugar.CodigoDepartamento = CodigoDepartamento;
            Lugar.CodigoProvincia = CodigoProvincia;
            Lugar.CodigoLugar = CodigoLugar;
            Lugar.NombreLugar = NombreLugar;
                                          
            Lugares.AddLugaresRow(Lugar);

            int rowsAffected = Adapter.Update(Lugares);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarLugar(string CodigoPais, string CodigoDepartamento, string CodigoProvincia, string CodigoLugar, string NombreLugar)		
        {
            DSDoblones20Sistema.LugaresDataTable Lugares = Adapter.GetDataBy(CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar);
            if (Lugares.Count == 0)
                return false;

            DSDoblones20Sistema.LugaresRow Lugar = Lugares[0];

            Lugar.CodigoPais = CodigoPais;
            Lugar.CodigoDepartamento = CodigoDepartamento;
            Lugar.CodigoProvincia = CodigoProvincia;
            Lugar.CodigoLugar = CodigoLugar;
            Lugar.NombreLugar = NombreLugar;

            Lugares.AddLugaresRow(Lugar);

            int rowsAffected = Adapter.Update(Lugar);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarLugar(string CodigoPais, string	CodigoDepartamento, string CodigoProvincia, string CodigoLugar)                           	                   	     
        {
            int rowsAffected = Adapter.Delete(CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarLugares()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerLugar(string CodigoPais, string CodigoDepartamento, string CodigoProvincia, string CodigoLugar)
        {
            return Adapter.GetDataBy(CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerLugaresPorProvincia(string CodigoPais, string CodigoDepartamento, string CodigoProvincia)
        {
            return Adapter.GetDataByProvincia(CodigoPais, CodigoDepartamento, CodigoProvincia);
        }
    }
}
