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
    //[System.ComponentModel.DataObject]
    public class UsuariosCLN
    {
        private UsuariosTableAdapter _UsuariosAdapter = null;
        private QTAFuncionesSistema _QTAFuncionesSistemaAdapter = null;
        protected UsuariosTableAdapter Adapter
        {
            get
            {
                if (_UsuariosAdapter == null)
                    _UsuariosAdapter = new UsuariosTableAdapter();
                return _UsuariosAdapter;
            }
        }

        protected QTAFuncionesSistema FuncionesSistemaAdater
        {
            get
            {
                if (_QTAFuncionesSistemaAdapter == null)
                    _QTAFuncionesSistemaAdapter = new QTAFuncionesSistema();
                return _QTAFuncionesSistemaAdapter;
            }
        }

        public UsuariosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public bool AutenticaPrivilegiosAdministrador()
        {
            try
            {
                Adapter.Connection = CLCAD.ConfiguracionConeccion.ConeccionPorDefecto;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarUsuario(string NombreUsuario, string Contrasena, string DIUsuario, string Paterno, string Materno, string Nombres, DateTime FechaNacimiento, string Sexo, string Celular, string Email, string Direccion, string Telefono, string RutaArchivoHuellaDactilar, string RutaArchivoFotografia, string RutaArchivoFirma, string Observaciones)		
        {
            DSDoblones20Sistema.UsuariosDataTable Usuarios = new DSDoblones20Sistema.UsuariosDataTable();
            DSDoblones20Sistema.UsuariosRow Usuario = Usuarios.NewUsuariosRow();

            Usuario.NombreUsuario = NombreUsuario;
            Usuario.Contrasena = Contrasena;
            Usuario.DIUsuario = DIUsuario;
            if (Paterno == null) Usuario.SetPaternoNull();
            else Usuario.Paterno = Paterno;
            if (Materno == null) Usuario.SetMaternoNull();
            else Usuario.Materno = Materno;
            Usuario.Nombres = Nombres;
            if (FechaNacimiento == null) Usuario.SetFechaNacimientoNull();
            else Usuario.FechaNacimiento = FechaNacimiento;
            Usuario.Sexo = Sexo;
            if (Celular == null) Usuario.SetCelularNull();
            else Usuario.Celular = Celular;
            if (Email == null) Usuario.SetEmailNull();
            else Usuario.Email = Email;
            if (Direccion == null) Usuario.SetDireccionNull();
            else Usuario.Direccion = Direccion;
            if (Telefono == null) Usuario.SetTelefonoNull();
            else Usuario.Telefono = Telefono;
            if (RutaArchivoHuellaDactilar == null) Usuario.SetRutaArchivoHuellaDactilarNull();
            else Usuario.RutaArchivoHuellaDactilar = RutaArchivoHuellaDactilar;
            if (RutaArchivoFotografia == null) Usuario.SetRutaArchivoFotografiaNull();
            else Usuario.RutaArchivoFotografia = RutaArchivoFotografia;
            if (RutaArchivoFirma == null) Usuario.SetRutaArchivoFirmaNull();
            else Usuario.RutaArchivoFirma = RutaArchivoFirma;
            if (Observaciones == null) Usuario.SetObservacionesNull();
            else Usuario.Observaciones = Observaciones;
                                          
            Usuarios.AddUsuariosRow(Usuario);

            int rowsAffected = Adapter.Update(Usuarios);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarUsuario(int CodigoUsuario, string NombreUsuario, string Contrasena, string DIUsuario, string Paterno, string Materno, string Nombres, DateTime FechaNacimiento, string Sexo, string Celular, string Email, string Direccion, string Telefono, string RutaArchivoHuellaDactilar, string RutaArchivoFotografia, string RutaArchivoFirma, string Observaciones)		
        {
            DSDoblones20Sistema.UsuariosDataTable Usuarios = Adapter.GetDataBy1(CodigoUsuario);
            if (Usuarios.Count == 0)
                return false;

            DSDoblones20Sistema.UsuariosRow Usuario = Usuarios[0];

//            Usuario.CodigoUsuario = CodigoUsuario;
            Usuario.NombreUsuario = NombreUsuario;
            Usuario.Contrasena = Contrasena;
            Usuario.DIUsuario = DIUsuario;
            if (Paterno == null) Usuario.SetPaternoNull();
            else Usuario.Paterno = Paterno;
            if (Materno == null) Usuario.SetMaternoNull();
            else Usuario.Materno = Materno;
            Usuario.Nombres = Nombres;
            if (FechaNacimiento == null) Usuario.SetFechaNacimientoNull();
            else Usuario.FechaNacimiento = FechaNacimiento;
            Usuario.Sexo = Sexo;
            if (Celular == null) Usuario.SetCelularNull();
            else Usuario.Celular = Celular;
            if (Email == null) Usuario.SetEmailNull();
            else Usuario.Email = Email;
            if (Direccion == null) Usuario.SetDireccionNull();
            else Usuario.Direccion = Direccion;
            if (Telefono == null) Usuario.SetTelefonoNull();
            else Usuario.Telefono = Telefono;
            if (RutaArchivoHuellaDactilar == null) Usuario.SetRutaArchivoHuellaDactilarNull();
            else Usuario.RutaArchivoHuellaDactilar = RutaArchivoHuellaDactilar;
            if (RutaArchivoFotografia == null) Usuario.SetRutaArchivoFotografiaNull();
            else Usuario.RutaArchivoFotografia = RutaArchivoFotografia;
            if (RutaArchivoFirma == null) Usuario.SetRutaArchivoFirmaNull();
            else Usuario.RutaArchivoFirma = RutaArchivoFirma;
            if (Observaciones == null) Usuario.SetObservacionesNull();
            else Usuario.Observaciones = Observaciones;

            int rowsAffected = Adapter.Update(Usuario);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarUsuario(int CodigoUsuario)                           	                   	     
        {
            int rowsAffected = Adapter.Delete(CodigoUsuario);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarUsuarios()
        {
            return Adapter.GetData();
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerUsuario(int CodigoUsuario)
        {
            return Adapter.GetDataBy1(CodigoUsuario);
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarDatosUsuarioTransacciones()
        {
            return new ListarDatosUsuarioTransaccionesTableAdapter().GetData();
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable BuscarUsuarios(string CodigoAmbitoBusqueda, string TextoABuscar, bool ExactamenteIgual)
        {
            return Adapter.GetDataByBuscarUsuarios(CodigoAmbitoBusqueda, TextoABuscar, ExactamenteIgual);
        }

        public void CambiarContrasena(int CodigoUsuario, string Contrasena)
        {
            Adapter.AsignarContrasena(CodigoUsuario, Contrasena);

            //System.Windows.Forms.MessageBox.Show(CLCAD.Properties.Settings.Default.Properties["Doblones20ConnectionString"].DefaultValue.ToString() +
                //Adapter.);
            //System.Windows.Forms.MessageBox.Show(Adapter.Connection.ConnectionString.ToString());
        }

        /// <summary>
        /// Confirma si el Usuario tiene permiso al menos de una Interface para ingresar al Sistema
        /// </summary>
        /// <param name="CodigoUsuario"> Codigo del Usuario</param>
        /// <returns>True si puede ingresar, false caso contrario</returns>
        public bool TienePermisoInterfaces(int NumeroAgencia, int CodigoUsuario)
        {
            bool? tienePermisos = false;
            FuncionesSistemaAdater.TieneUsuarioPermisosInterfaces(NumeroAgencia, CodigoUsuario, ref tienePermisos);
            return tienePermisos.Value;
        }

        /// <summary>
        /// Confirma si el Usuario Pertene a un Deteminado grupo  del Sistema para su ingreso al miso
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoUsuario"></param>
        /// <returns></returns>
        public bool PerteneUsuarioSistemaGrupos(int NumeroAgencia, int CodigoUsuario)
        {
            bool? PerteneceGrupo = false;
            FuncionesSistemaAdater.PerteneUsuarioSistemaGrupos(NumeroAgencia, CodigoUsuario, ref PerteneceGrupo);
            return PerteneceGrupo.Value;
        }


        /// <summary>
        /// Realiza el listado de grupos al que el Usuario Pertenece
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="CodigoUsuario"></param>
        /// <returns></returns>
        public DataTable ListarSitemaGruposPorUsuario(int NumeroAgencia, int CodigoUsuario)
        {
            return new ListarSitemaGruposPorUsuarioTableAdapter().GetData(NumeroAgencia, CodigoUsuario);
        }

        public bool VerificarContrasena(int CodigoUsuario, string Contrasena)
        {
            bool? Existe = false;
            Adapter.VerificarContrasena(CodigoUsuario, Contrasena, ref Existe);
            return Existe.Value;
        }
        
        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public int VerificarUsuario(string NombreUsuario, string Contrasena)
        {
            QTAFuncionesSistema Adapter = new QTAFuncionesSistema();

            return int.Parse(Adapter.VerificarUsuario(NombreUsuario, Contrasena).ToString());
        }
    }
}
