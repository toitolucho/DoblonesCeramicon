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
    [System.ComponentModel.DataObject]
    public class ProveedoresCLN
    {
        private ProveedoresTableAdapter _ProveedoresAdapter = null;
        protected ProveedoresTableAdapter Adapter
        {
            get
            {
                if (_ProveedoresAdapter == null)
                    _ProveedoresAdapter = new ProveedoresTableAdapter();
                return _ProveedoresAdapter;
            }
        }

        public ProveedoresCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarProveedor(string NombreRazonSocial, string NombreRepresentante, string CodigoTipoProveedor, string NITProveedor, byte? CodigoBanco, string NumeroCuentaBanco, byte? CodigoMoneda, string NombreOrdenCheque, string CodigoPais, string CodigoDepartamento, string CodigoProvincia, string CodigoLugar, string Direccion, string Telefono, string Fax, string Casilla, string Email, string Observaciones, bool ProveedorActivo, int NumeroAgencia)
        {
            DSDoblones20GestionComercial.ProveedoresDataTable Proveedores = new DSDoblones20GestionComercial.ProveedoresDataTable();
            DSDoblones20GestionComercial.ProveedoresRow Proveedor = Proveedores.NewProveedoresRow();

            Proveedor.NombreRazonSocial = NombreRazonSocial;
            Proveedor.NombreRepresentante = NombreRepresentante;
            Proveedor.CodigoTipoProveedor = CodigoTipoProveedor;
            if (NITProveedor == null) Proveedor.SetNITProveedorNull();
            else Proveedor.NITProveedor = NITProveedor;
            if (CodigoBanco == null) Proveedor.SetCodigoBancoNull();
            else Proveedor.CodigoBanco = CodigoBanco.Value;
            if (NumeroCuentaBanco == null) Proveedor.SetNumeroCuentaBancoNull();
            Proveedor.NumeroCuentaBanco = NumeroCuentaBanco;
            if (CodigoMoneda == null) Proveedor.SetCodigoMonedaNull();
            else Proveedor.CodigoMoneda= CodigoMoneda.Value;
            if (NombreOrdenCheque == null) Proveedor.SetNombreOrdenChequeNull();
            else Proveedor.NombreOrdenCheque = NombreOrdenCheque;
            if (CodigoPais == null) Proveedor.SetCodigoPaisNull();
            else Proveedor.CodigoPais = CodigoPais;
            if (CodigoDepartamento == null) Proveedor.SetCodigoDepartamentoNull();
            else Proveedor.CodigoDepartamento = CodigoDepartamento;
            if (CodigoProvincia == null) Proveedor.SetCodigoProvinciaNull();
            else Proveedor.CodigoProvincia = CodigoProvincia;
            if (CodigoLugar == null) Proveedor.SetCodigoLugarNull();
            else Proveedor.CodigoLugar = CodigoLugar;
            if (Direccion == null) Proveedor.SetDireccionNull();
            else Proveedor.Direccion = Direccion;
            if (Telefono == null) Proveedor.SetTelefonoNull();
            else Proveedor.Telefono = Telefono;
            if (Fax == null) Proveedor.SetFaxNull();
            else Proveedor.Fax = Fax;
            if (Casilla == null) Proveedor.SetCasillaNull();
            else Proveedor.Casilla = Casilla;
            if (Email == null) Proveedor.SetEmailNull();
            else Proveedor.Email = Email;
            if (Observaciones == null) Proveedor.SetObservacionesNull();
            else Proveedor.Observaciones = Observaciones;
            Proveedor.ProveedorActivo = ProveedorActivo;
            Proveedor.NumeroAgencia = NumeroAgencia;
            
            Proveedores.AddProveedoresRow(Proveedor);

            int rowsAffected = Adapter.Update(Proveedores);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarProveedor(int CodigoProveedor, string NombreRazonSocial, string NombreRepresentante, string CodigoTipoProveedor, string NITProveedor, byte? CodigoBanco, string NumeroCuentaBanco, byte? CodigoMoneda, string NombreOrdenCheque, string CodigoPais, string CodigoDepartamento, string CodigoProvincia, string CodigoLugar, string Direccion, string Telefono, string Fax, string Casilla, string Email, string Observaciones, bool ProveedorActivo, int NumeroAgencia)
        {
            DSDoblones20GestionComercial.ProveedoresDataTable Proveedores = Adapter.GetDataBy(CodigoProveedor);
            if (Proveedores.Count == 0)
                return false;

            DSDoblones20GestionComercial.ProveedoresRow Proveedor = Proveedores[0];

            //Proveedor.CodigoProveedor = CodigoProveedor;
            Proveedor.NombreRazonSocial = NombreRazonSocial;
            Proveedor.NombreRepresentante = NombreRepresentante;
            Proveedor.CodigoTipoProveedor = CodigoTipoProveedor;
            if (NITProveedor == null) Proveedor.SetNITProveedorNull();
            else Proveedor.NITProveedor = NITProveedor;
            if (CodigoBanco == null) Proveedor.SetCodigoBancoNull();
            else Proveedor.CodigoBanco = CodigoBanco.Value;
            if (NumeroCuentaBanco == null) Proveedor.SetNumeroCuentaBancoNull();
            Proveedor.NumeroCuentaBanco = NumeroCuentaBanco;
            if (CodigoMoneda == null) Proveedor.SetCodigoMonedaNull();
            else Proveedor.CodigoMoneda= CodigoMoneda.Value;
            if (NombreOrdenCheque == null) Proveedor.SetNombreOrdenChequeNull();
            else Proveedor.NombreOrdenCheque = NombreOrdenCheque;
            if (CodigoPais == null) Proveedor.SetCodigoPaisNull();
            else Proveedor.CodigoPais = CodigoPais;
            if (CodigoDepartamento == null) Proveedor.SetCodigoDepartamentoNull();
            else Proveedor.CodigoDepartamento = CodigoDepartamento;
            if (CodigoProvincia == null) Proveedor.SetCodigoProvinciaNull();
            else Proveedor.CodigoProvincia = CodigoProvincia;
            if (CodigoLugar == null) Proveedor.SetCodigoLugarNull();
            else Proveedor.CodigoLugar = CodigoLugar;
            if (Direccion == null) Proveedor.SetDireccionNull();
            else Proveedor.Direccion = Direccion;
            if (Telefono == null) Proveedor.SetTelefonoNull();
            else Proveedor.Telefono = Telefono;
            if (Fax == null) Proveedor.SetFaxNull();
            else Proveedor.Fax = Fax;
            if (Casilla == null) Proveedor.SetCasillaNull();
            else Proveedor.Casilla = Casilla;
            if (Email == null) Proveedor.SetEmailNull();
            else Proveedor.Email = Email;
            if (Observaciones == null) Proveedor.SetObservacionesNull();
            else Proveedor.Observaciones = Observaciones;
            Proveedor.ProveedorActivo = ProveedorActivo;
            Proveedor.NumeroAgencia = NumeroAgencia;
        
            int rowsAffected = Adapter.Update(Proveedor);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarProveedor(int CodigoProveedor)
        {
            int rowsAffected = Adapter.Delete(CodigoProveedor);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProveedores()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerProveedor(int CodigoProveedor)
        {
            return Adapter.GetDataBy(CodigoProveedor);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable BuscarProveedores(string CodigoAmbitoBusqueda, string TextoABuscar, bool ExactamenteIgual)
        {
            return Adapter.GetDataByBuscarProveedores(CodigoAmbitoBusqueda, TextoABuscar, ExactamenteIgual);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProveedoresReporte()
        {
            ProveedoresReporteTableAdapter ProveedoresReporte = new ProveedoresReporteTableAdapter();
            return ProveedoresReporte.GetData();
        }

        //ListarProveedoresNombres
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProveedoresCompras()
        {
            ListarProveedoresCodigoNombreTableAdapter proveedoresCompras = new ListarProveedoresCodigoNombreTableAdapter();
            return proveedoresCompras.GetData();
        }

        /// <summary>
        /// Retorna la ultima tupla de la Tabla Proveedores, mediante una cadena que contiene el Codigo, Nombres, NIT del proveedor
        /// separados por la coma (',')
        /// </summary>
        /// <returns>Atributos separados por la ','</returns>
        public string ObtenerUltimoProveedorInsertado()
        {
            string DatosTuplaUltimoProveedor = null;
            new FuncionesGestionComercial().ObtenerUltimoProveedorInsertado(ref DatosTuplaUltimoProveedor);
            return DatosTuplaUltimoProveedor == null ? String.Empty : DatosTuplaUltimoProveedor.Trim();
        }
    }
}
