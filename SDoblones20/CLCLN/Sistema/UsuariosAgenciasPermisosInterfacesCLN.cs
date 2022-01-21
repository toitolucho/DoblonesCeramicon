using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.GestionComercial
{
    [System.ComponentModel.DataObject]
    public class UsuariosAgenciasPermisosInterfacesCLN
    {
        private UsuariosAgenciasPermisosInterfacesTableAdapter _UsuariosAgenciasPermisosInterfacesAdapter = null;
        protected UsuariosAgenciasPermisosInterfacesTableAdapter Adapter
        {
            get
            {
                if (_UsuariosAgenciasPermisosInterfacesAdapter == null)
                    _UsuariosAgenciasPermisosInterfacesAdapter = new UsuariosAgenciasPermisosInterfacesTableAdapter();

                return _UsuariosAgenciasPermisosInterfacesAdapter;
            }
        }

        public UsuariosAgenciasPermisosInterfacesCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarUsuarioAgenciaPermisoInterface(int CodigoUsuario, int NumeroAgencia, byte CodigoInterface, bool PermitirInsertar, bool PermitirEditar, bool PermitirEliminar, bool PermitirNavegar, bool PermitirReportes)
        {
            DSDoblones20Sistema.UsuariosAgenciasPermisosInterfacesDataTable UsuariosAgenciasPermisosInterfaces = new DSDoblones20Sistema.UsuariosAgenciasPermisosInterfacesDataTable();
            DSDoblones20Sistema.UsuariosAgenciasPermisosInterfacesRow UsuarioAgenciaPermisoInterface = UsuariosAgenciasPermisosInterfaces.NewUsuariosAgenciasPermisosInterfacesRow();

            UsuarioAgenciaPermisoInterface.CodigoUsuario = CodigoUsuario;
            UsuarioAgenciaPermisoInterface.NumeroAgencia = NumeroAgencia;
            UsuarioAgenciaPermisoInterface.CodigoInterface = CodigoInterface;
            UsuarioAgenciaPermisoInterface.PermitirInsertar = PermitirInsertar;
            UsuarioAgenciaPermisoInterface.PermitirEditar = PermitirEditar;
            UsuarioAgenciaPermisoInterface.PermitirEliminar = PermitirEliminar;
            UsuarioAgenciaPermisoInterface.PermitirNavegar = PermitirNavegar;
            UsuarioAgenciaPermisoInterface.PermitirReportes = PermitirReportes;

            UsuariosAgenciasPermisosInterfaces.AddUsuariosAgenciasPermisosInterfacesRow(UsuarioAgenciaPermisoInterface);

            int rowsAffected = Adapter.Update(UsuariosAgenciasPermisosInterfaces);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarUsuarioAgenciaPermisoInterface(int CodigoUsuario, int NumeroAgencia, byte CodigoInterface, bool PermitirInsertar, bool PermitirEditar, bool PermitirEliminar, bool PermitirNavegar, bool PermitirReportes)
        {
            DSDoblones20Sistema.UsuariosAgenciasPermisosInterfacesDataTable UsuariosAgenciasPermisosInterfaces = Adapter.GetDataBy(CodigoUsuario, NumeroAgencia, CodigoInterface);
            if (UsuariosAgenciasPermisosInterfaces.Count == 0)
                return false;
            DSDoblones20Sistema.UsuariosAgenciasPermisosInterfacesRow UsuarioAgenciaPermisoInterface = UsuariosAgenciasPermisosInterfaces[0];

            UsuarioAgenciaPermisoInterface.CodigoUsuario = CodigoUsuario;
            UsuarioAgenciaPermisoInterface.NumeroAgencia = NumeroAgencia;
            UsuarioAgenciaPermisoInterface.CodigoInterface = CodigoInterface;
            UsuarioAgenciaPermisoInterface.PermitirInsertar = PermitirInsertar;
            UsuarioAgenciaPermisoInterface.PermitirEditar = PermitirEditar;
            UsuarioAgenciaPermisoInterface.PermitirEliminar = PermitirEliminar;
            UsuarioAgenciaPermisoInterface.PermitirNavegar = PermitirNavegar;
            UsuarioAgenciaPermisoInterface.PermitirReportes = PermitirReportes;

            int rowsAffected = Adapter.Update(UsuarioAgenciaPermisoInterface);
            return rowsAffected == 1;

        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarUsuarioAgenciaPermisoInterface(int CodigoUsuario, int NumeroAgencia, int CodigoInterface)
        {
            int rowsAffedted = Adapter.Delete(CodigoUsuario, NumeroAgencia, CodigoInterface);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarUsuariosAgenciasPermisosInterfaces()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerUsuarioAgenciaPermisoInterface(int CodigoUsuario, int NumeroAgencia, int CodigoInterface)
        {
            return Adapter.GetDataBy(CodigoUsuario, NumeroAgencia, CodigoInterface);
        }


        public DataTable ListarPermisosPorUsuario(int CodigoUsuario, int NumeroAgencia)
        {
            ListarUsuariosAgenciasPermisosInterfacesXUsuarioTableAdapter AdapterAux = new ListarUsuariosAgenciasPermisosInterfacesXUsuarioTableAdapter();
            return AdapterAux.GetData(CodigoUsuario, NumeroAgencia);
        }

        public DataTable ListarPermisosPorUsuarioNuevo()
        {
            ListarUsuariosAgenciasPermisosInterfacesXUsuarioTableAdapter AdapterAux = new ListarUsuariosAgenciasPermisosInterfacesXUsuarioTableAdapter();
            return AdapterAux.GetDataByUsuario();
        }

    }
}


