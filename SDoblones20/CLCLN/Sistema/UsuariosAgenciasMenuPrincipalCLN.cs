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
    public class UsuariosAgeciasMenuPrincipalCLN
    {
        private UsuariosAgenciasMenuPrincipalTableAdapter _UsuariosAgenciasMenuPrincipalAdapter = null;
        protected UsuariosAgenciasMenuPrincipalTableAdapter Adapter
        {
            get
            {
                if (_UsuariosAgenciasMenuPrincipalAdapter == null)
                    _UsuariosAgenciasMenuPrincipalAdapter = new UsuariosAgenciasMenuPrincipalTableAdapter();

                return _UsuariosAgenciasMenuPrincipalAdapter;
            }
        }

        public UsuariosAgeciasMenuPrincipalCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarUsuarioMenuPrincipal(int CodigoUsuario, int NumeroAgencia, byte CodigoGrupoSistema, int CodigoElementoMenu, bool Visible, bool Activo, bool IncluirBotonBarra)
        {
            DSDoblones20Sistema.UsuariosAgenciasMenuPrincipalDataTable UsuariosAgenciasMenuPrincipal = new DSDoblones20Sistema.UsuariosAgenciasMenuPrincipalDataTable();
            DSDoblones20Sistema.UsuariosAgenciasMenuPrincipalRow UsuarioAgenciaMenuPrincipal = UsuariosAgenciasMenuPrincipal.NewUsuariosAgenciasMenuPrincipalRow();

            UsuarioAgenciaMenuPrincipal.CodigoUsuario = CodigoUsuario;
            UsuarioAgenciaMenuPrincipal.NumeroAgencia = NumeroAgencia;
            UsuarioAgenciaMenuPrincipal.CodigoGrupoSistema = CodigoGrupoSistema;
            UsuarioAgenciaMenuPrincipal.CodigoElementoMenu = CodigoElementoMenu;
            UsuarioAgenciaMenuPrincipal.Visible = Visible;
            UsuarioAgenciaMenuPrincipal.Activo = Activo;
            UsuarioAgenciaMenuPrincipal.IncluirBotonBarra = IncluirBotonBarra;

            UsuariosAgenciasMenuPrincipal.AddUsuariosAgenciasMenuPrincipalRow(UsuarioAgenciaMenuPrincipal);
            

            int rowsAffected = Adapter.Update(UsuarioAgenciaMenuPrincipal);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarUsuarioAgenciaMenuPrincipal(int CodigoUsuario, int NumeroAgencia, byte CodigoGrupoSistema, int CodigoElementoMenu, bool Visible, bool Activo, bool IncluirBotonBarra)
        {
            DSDoblones20Sistema.UsuariosAgenciasMenuPrincipalDataTable UsuariosAgenciasMenuPrincipal = Adapter.GetDataBy(CodigoUsuario, NumeroAgencia, CodigoGrupoSistema, CodigoElementoMenu);
            if (UsuariosAgenciasMenuPrincipal.Count == 0)
                return false;
            DSDoblones20Sistema.UsuariosAgenciasMenuPrincipalRow UsuarioAgenciaMenuPrincipal = UsuariosAgenciasMenuPrincipal[0];

            UsuarioAgenciaMenuPrincipal.Visible = Visible;
            UsuarioAgenciaMenuPrincipal.Activo = Activo;
            UsuarioAgenciaMenuPrincipal.IncluirBotonBarra = IncluirBotonBarra;

            int rowsAffected = Adapter.Update(UsuarioAgenciaMenuPrincipal);
            return rowsAffected == 1;
        }


        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarUsuarioMenuPrincipal(int CodigoUsuario, int NumeroAgencia, byte CodigoGrupoSistema, int CodigoElementoMenu)
        {
            int rowsAffedted = Adapter.Delete(CodigoUsuario, NumeroAgencia, CodigoGrupoSistema, CodigoElementoMenu); 
            return rowsAffedted == 1;
        }


        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarUsuariosAgenciasMenuPrincipal()
        {
            return Adapter.GetData();
        }

       //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerUsuarioAgenciaMenuPrincipal(int CodigoUsuario, int NumeroAgencia, byte CodigoGrupoSistema, int CodigoElementoMenu)
        {
            return Adapter.GetDataBy(CodigoUsuario, NumeroAgencia, CodigoGrupoSistema, CodigoElementoMenu); 
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerMenuPrincipalUsuarioAgencia(int CodigoUsuario, int NumeroAgencia)
        {
            MenuPrincipalUsuarioAgenciaTableAdapter MPUAAdapter = new MenuPrincipalUsuarioAgenciaTableAdapter();
            return MPUAAdapter.GetDataByObtenerMenuUsuarioAgencia(CodigoUsuario, NumeroAgencia);
        }

    }
}
