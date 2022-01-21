using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20SistemaTableAdapters;
namespace CLCAD
{
    public class ConfiguracionConeccion
    {
        private static QTAFuncionesSistema _QTAFuncionesSistema = null;
        private static string NombreServidor = "localhost";
        private static string NombreUsuario = "sa";
        private static string Contrasenia = "kc28ma10cw18";
        private static string BaseDatos = "Doblones20";
        private static System.Data.SqlClient.SqlConnection conectionDefault;

        public static System.Data.SqlClient.SqlConnection ConeccionPorDefecto {
            get {
                if (conectionDefault == null)
                {
                    try
                    {
                        string cadena = "Data Source=" + NombreServidor + ";Initial Catalog=" + BaseDatos + ";Persist Security Info=True; User ID=" + NombreUsuario + ";Password=" + Contrasenia;
                        conectionDefault = new System.Data.SqlClient.SqlConnection(cadena);
                        conectionDefault.Open();
                    }
                    catch (Exception)
                    {
                        
                    }
                }
                return conectionDefault;
            }
        }

        public static void CerrarConeccionPorDefecto()
        {
            if (conectionDefault != null)
            {
                conectionDefault.Close();
                conectionDefault.Dispose();
            }
        }

        protected static QTAFuncionesSistema Adapter
        {
            get
            {
                if (_QTAFuncionesSistema == null)
                    _QTAFuncionesSistema = new QTAFuncionesSistema();
                return _QTAFuncionesSistema;
            }
        }

        public static bool Conectar(string servidor, string baseDatos)
        {
            //string cadenaConexion = CLCAD.Properties.Settings.Default.Properties["BibliotecaDigitalConnectionString"].DefaultValue.ToString();

            string cadena = "Data Source=" + servidor + ";Initial Catalog=" + baseDatos + ";Integrated Security=True";
            CLCAD.Properties.Settings.Default.Properties["Doblones20ConnectionString"].DefaultValue = cadena;
            CLCAD.Properties.Settings.Default.Reload();

            try
            {
                DateTime? FechaHoraServidor = null;
                object auxObject = Adapter.ObtenerFechaHoraServidor(ref FechaHoraServidor);

                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }

        public static bool Conectar(string servidor, string baseDatos, string usuario, string contrasena)
        {
            string cadena = "Data Source=" + servidor + ";Initial Catalog=" + baseDatos + ";Persist Security Info=True; User ID=" + usuario + ";Password=" + contrasena;
            CLCAD.Properties.Settings.Default.Properties["Doblones20ConnectionString"].DefaultValue = cadena;
            CLCAD.Properties.Settings.Default.Reload();

            try
            {
                DateTime? FechaHoraServidor = null;
                object auxObject = Adapter.ObtenerFechaHoraServidor(ref FechaHoraServidor);

                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }

        public static void ReConectar()
        {
            CLCAD.Properties.Settings.Default.Reload();
            try
            {
                DateTime? FechaHoraServidor = null;
                object auxObject = Adapter.ObtenerFechaHoraServidor(ref FechaHoraServidor);

            }
            catch (System.Data.SqlClient.SqlException)
            {
                
            }
        }

        
        
    }
}
