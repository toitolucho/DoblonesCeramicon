using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;

namespace CLCLN.Sistema
{
    [System.ComponentModel.DataObject]
    public class FuncionesSistemaCLN
    {
        //private QTAFuncionesSistema BancosTableAdapter _bancosAdapter = null;
        /*
        private QTAFuncionesSistema _FuncionesSistemaAdapter = null;
        protected QTAFuncionesSistema Adapter
        {
            get
            {
                if (_FuncionesSistemaAdapter == null)
                    _FuncionesSistemaAdapter = new QTAFuncionesSistema();

                return _FuncionesSistemaAdapter;
            }
        }*/

        /*
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public int VerificarUsuario(string NombreUsuario, string Contrasena)
        {
            QTAFuncionesSistema Adapter = new QTAFuncionesSistema();
            
            return int.Parse(Adapter.VerificarUsuario(NombreUsuario, Contrasena).ToString());
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerPermisosInterface(int CodigoUsuario, int NumeroAgencia, string NombreInterface)
        {
            ObtenerPermisosInterfaceTableAdapter Adapter = new ObtenerPermisosInterfaceTableAdapter();
            return Adapter.GetData(CodigoUsuario, NumeroAgencia, NombreInterface);
        }
        */
        /*
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerVariablesConfiguracionSistema()
        {
            ObtenerVariablesConfiguracionSistemaTableAdapter Adapter = new ObtenerVariablesConfiguracionSistemaTableAdapter();
            return Adapter.GetData();
        }
        */

        /*
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerMenuUsuarioAgencia(int CodigoUsuario, int NumeroAgencia)
        {
            MenuPrincipalUsuarioAgenciaTableAdapter MPUAAdapter = new MenuPrincipalUsuarioAgenciaTableAdapter();
            return MPUAAdapter.GetDataByObtenerMenuUsuarioAgencia(CodigoUsuario, NumeroAgencia);
                
        }
        */

        /*
        public DataTable ObtenerVariablesConfiguracionAgencia(int NumeroAgencia)
        {
            ObtenerVariablesConfiguracionSistemaTableAdapter Adapter = new ObtenerVariablesConfiguracionSistemaTableAdapter();
            return Adapter.GetData();
        }
        */ 
    }
}
