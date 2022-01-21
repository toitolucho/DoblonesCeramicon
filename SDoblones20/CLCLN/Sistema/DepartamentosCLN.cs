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
    public class DepartamentosCLN
    {
        #region Atributos de la Clase
        private DepartamentosTableAdapter _DepartamentosAdapter = null;
        protected DepartamentosTableAdapter Adapter
        {
            get
            {
                if (_DepartamentosAdapter == null)
                    _DepartamentosAdapter = new DepartamentosTableAdapter();
                return _DepartamentosAdapter;
            }
        }
        #endregion

        #region Constructor
        public DepartamentosCLN()
        {
            //constructor
        }

        #endregion

        #region Insertar,Actualizar,Eliminar,Listar y Obtener un Departamento
        /// <summary>
        /// Insertar un Departamento
        /// </summary>
        /// <param name="CodigoPais">Codigo del Pais al que Pertenece</param>
        /// <param name="CodigoDepartamento">Codigo para el Departamento</param>
        /// <param name="NombreDepartamento">Nombre o Descripción del Departamento</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarDepartamento(string CodigoPais, string CodigoDepartamento, string NombreDepartamento)
        {
            DSDoblones20Sistema.DepartamentosDataTable Departamentos = new DSDoblones20Sistema.DepartamentosDataTable();
            DSDoblones20Sistema.DepartamentosRow departamento = Departamentos.NewDepartamentosRow();

            departamento.CodigoPais = CodigoPais;
            departamento.CodigoDepartamento = CodigoDepartamento;
            departamento.NombreDepartamento = NombreDepartamento;

            Departamentos.AddDepartamentosRow(departamento);

            int rowsAffected = Adapter.Update(Departamentos);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarDepartamento(string CodigoPais, string CodigoDepartamento, string NombreDepartamento)
        {
            DSDoblones20Sistema.DepartamentosDataTable Departamentos = Adapter.GetDataBy(CodigoPais, CodigoDepartamento);
            if (Departamentos.Count == 0)
                return false;
            DSDoblones20Sistema.DepartamentosRow departamento = Departamentos[0];

            departamento.CodigoPais = CodigoPais;
            departamento.CodigoDepartamento = CodigoDepartamento;
            departamento.NombreDepartamento = NombreDepartamento;

            int rowsAffected = Adapter.Update(departamento);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarDepartamento(string CodigoPais, string CodigoDepartamento)
        {
            int rowsAffedted = Adapter.Delete(CodigoPais, CodigoDepartamento);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarDepartamentos()
        {
            return Adapter.GetData(); 
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerDepartamento(string CodigoPais, string CodigoDepartamento)
        {
            return Adapter.GetDataBy(CodigoPais, CodigoDepartamento);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerDepartamentosPorPais(string CodigoPais)
        {
            return Adapter.GetDataByPais(CodigoPais);
        }
        #endregion
    }
}
