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
    public class ClientesCLN
    {
        #region Atributos de la Clase
        private ClientesTableAdapter _ClientesAdapter = null;
        protected ClientesTableAdapter Adapter
        {
            get
            {
                if (_ClientesAdapter == null)
                    _ClientesAdapter = new ClientesTableAdapter();
                return _ClientesAdapter;
            }
        }
        #endregion

        #region Constructor
        public ClientesCLN()
        {
            //constructor
        }

        #endregion


        /// <summary>
        /// Insertar un Cliente en la Base de Datos
        /// </summary>
        /// <param name="CodigoCliente"> Codigo del Cliente</param>
        /// <param name="DIRepresentante">Representante</param>
        /// <param name="CodigoEmpresa"> Codigo de la Empresa a la  que pertenece </param>
        /// <param name="NombreCliente"> Nombre del Cliente</param>
        /// <param name="NumeroAgencia"> Numero de Agencia</param>
        /// <param name="Observaciones"> Observaciones y descripciones</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCliente(string NombreCliente, string NombreRepresentante, string CodigoTipoCliente, string NITCliente, string CodigoPais, string CodigoDepartamento, string CodigoProvincia, string CodigoLugar, string Direccion, string Telefono, string Email, string Observaciones, string CodigoEstadoCliente, int NumeroAgencia)
        {
            DSDoblones20GestionComercial.ClientesDataTable Clientes = new DSDoblones20GestionComercial.ClientesDataTable();
            DSDoblones20GestionComercial.ClientesRow Cliente = Clientes.NewClientesRow();

            Cliente.NombreCliente = NombreCliente;
            Cliente.NombreRepresentante = NombreRepresentante;
            Cliente.CodigoTipoCliente = CodigoTipoCliente;
            if (NITCliente == null) Cliente.SetNITClienteNull();
            else Cliente.NITCliente = NITCliente;
            if (CodigoPais == null) Cliente.SetCodigoPaisNull();
            else Cliente.CodigoPais = CodigoPais;
            if (CodigoDepartamento == null) Cliente.SetCodigoDepartamentoNull();
            else Cliente.CodigoDepartamento = CodigoDepartamento;
            if (CodigoProvincia == null) Cliente.SetCodigoProvinciaNull();
            else Cliente.CodigoProvincia = CodigoProvincia;
            if (CodigoLugar == null) Cliente.SetCodigoLugarNull();
            else Cliente.CodigoLugar = CodigoLugar;
            if (Direccion == null) Cliente.SetDireccionNull();
            else Cliente.Direccion = Direccion;
            if (Telefono == null) Cliente.SetTelefonoNull();
            else Cliente.Telefono = Telefono;
            if (Email == null) Cliente.SetEmailNull();
            else Cliente.Email = Email;
            if (Observaciones == null) Cliente.SetObservacionesNull();
            else Cliente.Observaciones = Observaciones;
            Cliente.CodigoEstadoCliente = CodigoEstadoCliente;
            Cliente.NumeroAgencia = NumeroAgencia;
         
            Clientes.AddClientesRow(Cliente);

            int rowsAffected = Adapter.Update(Clientes);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarCliente(int CodigoCliente, string NombreCliente, string NombreRepresentante, string CodigoTipoCliente, string NITCliente, string CodigoPais, string CodigoDepartamento, string CodigoProvincia, string CodigoLugar, string Direccion, string Telefono, string Email, string Observaciones, string CodigoEstadoCliente, int NumeroAgencia)
        {
            DSDoblones20GestionComercial.ClientesDataTable Clientes = Adapter.GetDataBy(CodigoCliente);
            if (Clientes.Count == 0)
                return false;
            DSDoblones20GestionComercial.ClientesRow Cliente = Clientes[0];

            //Cliente.CodigoCliente = CodigoCliente;
            Cliente.NombreCliente = NombreCliente;
            Cliente.NombreRepresentante = NombreRepresentante;
            Cliente.CodigoTipoCliente = CodigoTipoCliente;
            if (NITCliente == null) Cliente.SetNITClienteNull();
            else Cliente.NITCliente = NITCliente;
            if (CodigoPais == null) Cliente.SetCodigoPaisNull();
            else Cliente.CodigoPais = CodigoPais;
            if (CodigoDepartamento == null) Cliente.SetCodigoDepartamentoNull();
            else Cliente.CodigoDepartamento = CodigoDepartamento;
            if (CodigoProvincia == null) Cliente.SetCodigoProvinciaNull();
            else Cliente.CodigoProvincia = CodigoProvincia;
            if (CodigoLugar == null) Cliente.SetCodigoLugarNull();
            else Cliente.CodigoLugar = CodigoLugar;
            if (Direccion == null) Cliente.SetDireccionNull();
            else Cliente.Direccion = Direccion;
            if (Telefono == null) Cliente.SetTelefonoNull();
            else Cliente.Telefono = Telefono;
            if (Email == null) Cliente.SetEmailNull();
            else Cliente.Email = Email;
            if (Observaciones == null) Cliente.SetObservacionesNull();
            else Cliente.Observaciones = Observaciones;
            Cliente.CodigoEstadoCliente = CodigoEstadoCliente;
            Cliente.NumeroAgencia = NumeroAgencia;

            int rowsAffected = Adapter.Update(Cliente);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCliente(int CodigoCliente)
        {
            int rowsAffedted = Adapter.Delete(CodigoCliente);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarClientes()
        {
            /*for (int i = 0; i < dataTable.Columns.Count; i++)
                dataTable.Columns[i].AllowDBNull = true;*/
            return Adapter.GetData(); 
        }

        
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerCliente(int CodigoCliente)
        {
            return Adapter.GetDataBy(CodigoCliente);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable BuscarClientes(string CodigoAmbitoBusqueda, string TextoABuscar, bool ExactamenteIgual)
        {
            return Adapter.GetDataByBuscarClientes(CodigoAmbitoBusqueda, TextoABuscar, ExactamenteIgual);
        }
        
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarClientesReporte()
        {
            ClientesReporteTableAdapter ClientesReporte = new ClientesReporteTableAdapter();
            return ClientesReporte.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarClientesVentas()
        {
            ListarClientesCodigoNombreTableAdapter clientesVenta = new ListarClientesCodigoNombreTableAdapter();
            return clientesVenta.GetData();
        }

        /// <summary>
        /// Retorna la Ultima tupla (Codigo, Nombre, NIT) insertada en la Tabla de Clientes como una Cadena 
        /// separando cada atributo mediante la coma(',')
        /// </summary>
        /// <returns>Cadena con los Atributos separados por una ','</returns>
        public string ObtenerUltimoClienteInsertado()
        {
            string DatosUltimaTuplaClientes = null;
            new FuncionesGestionComercial().ObtenerUltimoClienteInsertado(ref DatosUltimaTuplaClientes);
            return DatosUltimaTuplaClientes.Trim();
        }
    }
}
