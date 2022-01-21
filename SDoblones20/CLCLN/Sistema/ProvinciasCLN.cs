using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.Sistema
{
    [System.ComponentModel.DataObject]
    public class ProvinciasCLN
    {
        private ProvinciasTableAdapter _ProvinciasAdapter = null;
        protected ProvinciasTableAdapter Adapter
        {
            get
            {
                if (_ProvinciasAdapter == null)
                    _ProvinciasAdapter = new ProvinciasTableAdapter();
                return _ProvinciasAdapter;
            }
        }

        public ProvinciasCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarProvincia(string CodigoPais, string CodigoDepartamento, string CodigoProvincia, string NombreProvincia)
        {
            DSDoblones20Sistema.ProvinciasDataTable Provincias = new DSDoblones20Sistema.ProvinciasDataTable();
            DSDoblones20Sistema.ProvinciasRow Provincia = Provincias.NewProvinciasRow();

            Provincia.CodigoPais = CodigoPais;
            Provincia.CodigoDepartamento = CodigoDepartamento;
            Provincia.CodigoProvincia = CodigoProvincia;
            Provincia.NombreProvincia = NombreProvincia;    
            
            Provincias.AddProvinciasRow(Provincia);

            int rowsAffected = Adapter.Update(Provincias);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarProvincia(string CodigoPais, string CodigoDepartamento, string CodigoProvincia, string NombreProvincia)
        {
            DSDoblones20Sistema.ProvinciasDataTable Provincias = Adapter.GetDataBy(CodigoPais, CodigoDepartamento, CodigoProvincia);
            if (Provincias.Count == 0)
                return false;

            DSDoblones20Sistema.ProvinciasRow Provincia = Provincias[0];

            Provincia.CodigoPais = CodigoPais;
            Provincia.CodigoDepartamento = CodigoDepartamento;
            Provincia.CodigoProvincia = CodigoProvincia;
            Provincia.NombreProvincia = NombreProvincia;    
        
            Provincias.AddProvinciasRow(Provincia);

            int rowsAffected = Adapter.Update(Provincia);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarProvincia(string CodigoPais, string CodigoDepartamento, string CodigoProvincia)
        {
            int rowsAffected = Adapter.Delete(CodigoPais, CodigoDepartamento, CodigoProvincia);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProvincias()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerProvincia(string CodigoPais, string CodigoDepartamento, string CodigoProvincia)
        {
            return Adapter.GetDataBy(CodigoPais, CodigoDepartamento, CodigoProvincia);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerProvinciasPorDepartamento(string CodigoPais, string CodigoDepartamento)
        {
            return Adapter.GetDataByDepartamento(CodigoPais, CodigoDepartamento);
        }
    }
}
