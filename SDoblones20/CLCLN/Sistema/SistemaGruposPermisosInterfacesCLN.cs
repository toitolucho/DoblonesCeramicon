using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;

namespace CLCLN.Sistema
{
    public class SistemaGruposPermisosInterfacesCLN
    {
        private SistemaGruposPermisosInterfacesTableAdapter _SistemaGruposPermisosInterfacesAdapter = null;
        protected SistemaGruposPermisosInterfacesTableAdapter Adapter
        {
            get
            {
                if (_SistemaGruposPermisosInterfacesAdapter == null)
                    _SistemaGruposPermisosInterfacesAdapter = new SistemaGruposPermisosInterfacesTableAdapter();

                return _SistemaGruposPermisosInterfacesAdapter;
            }
        }

        public SistemaGruposPermisosInterfacesCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarSistemaGrupoPermisoInterface(byte CodigoGrupoSistema, byte CodigoInterface, bool PermitirInsertar, bool PermitirEditar, bool PermitirEliminar, bool PermitirNavegar, bool PermitirReportes)
        {
            DSDoblones20Sistema.SistemaGruposPermisosInterfacesDataTable SistemaGruposPermisosInterfaces = new DSDoblones20Sistema.SistemaGruposPermisosInterfacesDataTable();
            DSDoblones20Sistema.SistemaGruposPermisosInterfacesRow SistemaGrupoPermisoInterface = SistemaGruposPermisosInterfaces.NewSistemaGruposPermisosInterfacesRow();

            SistemaGrupoPermisoInterface.CodigoGrupoSistema = CodigoGrupoSistema;            
            SistemaGrupoPermisoInterface.CodigoInterface = CodigoInterface;
            SistemaGrupoPermisoInterface.PermitirInsertar = PermitirInsertar;
            SistemaGrupoPermisoInterface.PermitirEditar = PermitirEditar;
            SistemaGrupoPermisoInterface.PermitirEliminar = PermitirEliminar;
            SistemaGrupoPermisoInterface.PermitirNavegar = PermitirNavegar;
            SistemaGrupoPermisoInterface.PermitirReportes = PermitirReportes;

            SistemaGruposPermisosInterfaces.AddSistemaGruposPermisosInterfacesRow(SistemaGrupoPermisoInterface);

            int rowsAffected = Adapter.Update(SistemaGruposPermisosInterfaces);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarSistemaGrupoPermisoInterface(byte CodigoGrupoSistema, byte CodigoInterface, bool PermitirInsertar, bool PermitirEditar, bool PermitirEliminar, bool PermitirNavegar, bool PermitirReportes)
        {
            DSDoblones20Sistema.SistemaGruposPermisosInterfacesDataTable SistemaGruposPermisosInterfaces = Adapter.GetDataBy(CodigoGrupoSistema, CodigoInterface);
            if (SistemaGruposPermisosInterfaces.Count == 0)
                return false;
            DSDoblones20Sistema.SistemaGruposPermisosInterfacesRow SistemaGrupoPermisoInterface = SistemaGruposPermisosInterfaces[0];
                       
            
            SistemaGrupoPermisoInterface.PermitirInsertar = PermitirInsertar;
            SistemaGrupoPermisoInterface.PermitirEditar = PermitirEditar;
            SistemaGrupoPermisoInterface.PermitirEliminar = PermitirEliminar;
            SistemaGrupoPermisoInterface.PermitirNavegar = PermitirNavegar;
            SistemaGrupoPermisoInterface.PermitirReportes = PermitirReportes;

            int rowsAffected = Adapter.Update(SistemaGrupoPermisoInterface);
            return rowsAffected == 1;

        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarSistemaGrupoPermisoInterface(byte CodigoGrupoSistema, byte CodigoInterface)
        {
            int rowsAffedted = Adapter.Delete(CodigoGrupoSistema, CodigoInterface);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarSistemaGruposPermisosInterfaces()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerSistemaGrupoPermisoInterface(byte CodigoGrupoSistema, byte CodigoInterface)
        {
            return Adapter.GetDataBy(CodigoGrupoSistema, CodigoInterface);
        }


        public DataTable ListarPermisosPorGrupo(byte CodigoGrupoSistema)
        {
            ListarUsuariosAgenciasPermisosInterfacesXUsuarioTableAdapter AdapterAux = new ListarUsuariosAgenciasPermisosInterfacesXUsuarioTableAdapter();
            return AdapterAux.GetDataByGrupo(CodigoGrupoSistema);
        }
    }
}
