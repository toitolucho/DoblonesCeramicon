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
    
    public class AgenciasCLN
    {  
        #region Atributos de la Clase
        private AgenciasTableAdapter _AgenciasAdapter = null;
        protected AgenciasTableAdapter Adapter
        {
            get
            {
                if (_AgenciasAdapter == null)
                    _AgenciasAdapter = new AgenciasTableAdapter();
                return _AgenciasAdapter;
            }
        }
        #endregion

        #region Constructor
        public AgenciasCLN()
        {
            //constructor
        }

        #endregion


        /// <summary>
        /// Insertar una Agencia dentro del Sistema
        /// </summary>
        /// <param name="NombreAgencia"> Nombre de la Agencia</param>
        /// <param name="CodigoPais">Codigo del Pais donde se encuentra</param>
        /// <param name="CodigoDepartamento"> Codigo del Departamento donde se encuentra</param>
        /// <param name="CodigoProvincia">Codigo de Provincia</param>
        /// <param name="CodigoLugar">Código del SistemaInteraz</param>
        /// <param name="DIResponsable">Persona Responsable de la Agencia</param>
        /// <returns>Retorna True si se realizo correctamente la transacción de Insertado</returns>
        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarAgencia(string NombreAgencia, string CodigoPais, string CodigoDepartamento, string CodigoProvincia, string CodigoLugar, string DireccionAgencia, string NITAgencia, int NumeroSiguienteFactura, string NumeroAutorizacion, string DIResponsable, int NumeroAgenciaSuperior)
        {
            DSDoblones20Sistema.AgenciasDataTable Agencias = new DSDoblones20Sistema.AgenciasDataTable();
            DSDoblones20Sistema.AgenciasRow agencia = Agencias.NewAgenciasRow();

            agencia.NombreAgencia = NombreAgencia;
            agencia.CodigoPais = CodigoPais;
            agencia.CodigoDepartamento = CodigoDepartamento;
            agencia.CodigoProvincia = CodigoProvincia;
            agencia.CodigoLugar = CodigoLugar;
            agencia.DireccionAgencia = DireccionAgencia;
            agencia.DIResponsable = DIResponsable;
            agencia.NITAgencia = NITAgencia;
            agencia.NumeroSiguienteFactura = NumeroSiguienteFactura;
            agencia.NumeroAutorizacion = NumeroAutorizacion;
            agencia.NumeroAgenciaSuperior = NumeroAgenciaSuperior;

            Agencias.AddAgenciasRow(agencia);

            int rowsAffected = Adapter.Update(Agencias);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarAgencia(int NumeroAgencia, string NombreAgencia, string CodigoPais, string CodigoDepartamento, string CodigoProvincia, string CodigoLugar, string DireccionAgencia, string NITAgencia, int NumeroSiguienteFactura, string NumeroAutorizacion, string DIResponsable, int? NumeroAgenciaSuperior)
        {
            DSDoblones20Sistema.AgenciasDataTable Agencias = Adapter.GetDataBy(NumeroAgencia);
            if (Agencias.Count == 0)
                return false;
            DSDoblones20Sistema.AgenciasRow agencia = Agencias[0];

            agencia.NombreAgencia = NombreAgencia;
            agencia.CodigoPais = CodigoPais;
            agencia.CodigoDepartamento = CodigoDepartamento;
            agencia.CodigoProvincia = CodigoProvincia;
            agencia.CodigoLugar = CodigoLugar;
            agencia.DireccionAgencia = DireccionAgencia;
            agencia.DIResponsable = DIResponsable;
            agencia.NITAgencia = NITAgencia;
            agencia.NumeroSiguienteFactura = NumeroSiguienteFactura;
            agencia.NumeroAutorizacion = NumeroAutorizacion;
            if (NumeroAgenciaSuperior == null)
                agencia.SetNumeroAgenciaSuperiorNull();
            else
                agencia.NumeroAgenciaSuperior = NumeroAgenciaSuperior.Value;

            int rowsAffected = Adapter.Update(agencia);
            return rowsAffected == 1;
        }


        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarAgencia(int NumeroAgencia)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgencia);
            return rowsAffedted == 1;
        }


        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarAgencias()
        {
            return Adapter.GetData(); 
        }



        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerAgencia(int NumeroAgencia)
        {
            return Adapter.GetDataBy(NumeroAgencia);
        }

        /// <summary>
        /// Lista los datos de una Agencia para realizar los resportes de Ventas, Compras y Cotizaciones
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <returns></returns>
        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarDatosAgenciasParaTransaccionesReportes(int NumeroAgencia)
        {
            return new CLCAD.DSDoblones20GestionComercialTableAdapters.ListarDatosAgenciasParaTransaccionesReportesTableAdapter().GetData(NumeroAgencia);
        }

        public DataTable BuscarAgencias(string CodigoAmbitoBusqueda, string TextoABuscar, bool ExactamenteIgual)
        {
            return Adapter.GetDataByBuscarAgencia(CodigoAmbitoBusqueda, TextoABuscar, ExactamenteIgual);
        }
    }
}
