    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;

namespace CLCLN.Sistema
{
    public class SistemaGruposUsuariosCLN
    {
        private SistemaGruposUsuariosTableAdapter _SistemaGruposUsuariosAdapter = null;
        protected SistemaGruposUsuariosTableAdapter Adapter
        {
            get
            {
                if (_SistemaGruposUsuariosAdapter == null)
                    _SistemaGruposUsuariosAdapter = new SistemaGruposUsuariosTableAdapter();
                return _SistemaGruposUsuariosAdapter;
            }
        }

        public SistemaGruposUsuariosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarSistemaGrupoUsuario(int CodigoUsuario, int NumeroAgencia, byte CodigoGrupoSistema)
        {

            DSDoblones20Sistema.SistemaGruposUsuariosDataTable SistemaGruposUsuarios = new DSDoblones20Sistema.SistemaGruposUsuariosDataTable();
            DSDoblones20Sistema.SistemaGruposUsuariosRow SistemaGrupoUsuario = SistemaGruposUsuarios.NewSistemaGruposUsuariosRow();

            SistemaGrupoUsuario.CodigoUsuario = CodigoUsuario;
            SistemaGrupoUsuario.NumeroAgencia = NumeroAgencia;
            SistemaGrupoUsuario.CodigoGrupoSistema = CodigoGrupoSistema;

            SistemaGruposUsuarios.AddSistemaGruposUsuariosRow(SistemaGrupoUsuario);

            int rowsAffected = Adapter.Update(SistemaGruposUsuarios);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarSistemaGrupoUsuario(int CodigoUsuario, int NumeroAgencia, byte CodigoGrupoSistema)
        {
            DSDoblones20Sistema.SistemaGruposUsuariosDataTable SistemaGruposUsuarios = Adapter.GetDataByObtenerSistemaGruposUsuario(CodigoUsuario);
            if (SistemaGruposUsuarios.Count == 0)
                return false;

            DSDoblones20Sistema.SistemaGruposUsuariosRow SistemaGrupoUsuario = SistemaGruposUsuarios[0];
            
            SistemaGrupoUsuario.NumeroAgencia = NumeroAgencia;
            SistemaGrupoUsuario.CodigoGrupoSistema = CodigoGrupoSistema;

            int rowsAffected = Adapter.Update(SistemaGrupoUsuario);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarSistemaGrupoUsuario(int CodigoUsuario, int NumeroAgencia, byte CodigoGrupoSistema)
        {
            int rowsAffected = Adapter.Delete(CodigoUsuario, NumeroAgencia, CodigoGrupoSistema);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarSistemaGruposUsuarios()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerSistemaGruposUsuario(int CodigoUsuario)
        {
            return Adapter.GetDataByObtenerSistemaGruposUsuario(CodigoUsuario);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerSistemaGruposUsuarioAgencia(int CodigoUsuario, int NumeroAgencia)
        {
            return Adapter.GetDataByObtenerSistemaGruposUsuarioAgencia(CodigoUsuario, NumeroAgencia);
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerSistemaGrupoUsuarioAgencia(int CodigoUsuario, int NumeroAgencia, byte CodigoGrupoSistema)
        {
            return Adapter.GetDataBy(CodigoUsuario, NumeroAgencia, CodigoGrupoSistema);
        }

        public void RealizarOperacionesSistemaGruposUsuarios(int CodigoUsuario, int NumeroAgencia, byte CodigoGrupoSistema, bool Seleccionado)
        {
            new QTAFuncionesSistema().RealizarOperacionesSistemaGruposUsuarios(CodigoUsuario, NumeroAgencia, CodigoGrupoSistema, Seleccionado);
        }
    }
}
