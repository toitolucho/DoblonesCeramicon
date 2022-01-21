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
    public class PaisesCLN
    {
        private PaisesTableAdapter _PaisesAdapter = null;
        protected PaisesTableAdapter Adapter
        {
            get
            {
                if (_PaisesAdapter == null)
                    _PaisesAdapter = new PaisesTableAdapter();
                return _PaisesAdapter;
            }
        }

        public PaisesCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarPais(string CodigoPais, string NombrePais, string Nacionalidad)		
        {
            DSDoblones20Sistema.PaisesDataTable Paises = new DSDoblones20Sistema.PaisesDataTable();
            DSDoblones20Sistema.PaisesRow Pais = Paises.NewPaisesRow();

            Pais.CodigoPais = CodigoPais;
            Pais.NombrePais = NombrePais;
            if (Nacionalidad == null) Pais.SetNacionalidadNull();
            else Pais.Nacionalidad = Nacionalidad;
                                                      
            Paises.AddPaisesRow(Pais);

            int rowsAffected = Adapter.Update(Paises);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarPais(string CodigoPais, string NombrePais, string Nacionalidad)		
        {
            DSDoblones20Sistema.PaisesDataTable Paises = Adapter.GetDataBy(CodigoPais);
            if (Paises.Count == 0)
                return false;

            DSDoblones20Sistema.PaisesRow Pais = Paises[0];

            Pais.CodigoPais = CodigoPais;
            Pais.NombrePais = NombrePais;
            if (Nacionalidad == null) Pais.SetNacionalidadNull();
            else Pais.Nacionalidad = Nacionalidad;

            Paises.AddPaisesRow(Pais);

            int rowsAffected = Adapter.Update(Pais);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarPais(string CodigoPais)                           	                   	     
        {
            int rowsAffected = Adapter.Delete(CodigoPais);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarPaises()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerPais(string CodigoPais)
        {
            return Adapter.GetDataBy(CodigoPais);
        }
    }
}
