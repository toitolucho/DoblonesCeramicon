using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;

namespace CLCLN.Sistema
{
    public class SistemaGruposCLN
    {
        private SistemaGruposTableAdapter _SistemaGruposAdapter = null;
        protected SistemaGruposTableAdapter Adapter
        {
            get
            {
                if (_SistemaGruposAdapter == null)
                    _SistemaGruposAdapter = new SistemaGruposTableAdapter();
                return _SistemaGruposAdapter;
            }
        }

        public SistemaGruposCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarSistemaGrupos(string NombreGrupoSistema)
        {

            DSDoblones20Sistema.SistemaGruposDataTable SistemasGrupos = new DSDoblones20Sistema.SistemaGruposDataTable();
            DSDoblones20Sistema.SistemaGruposRow SistemaGrupo = SistemasGrupos.NewSistemaGruposRow();

            SistemaGrupo.NombreGrupoSistema = NombreGrupoSistema;

            SistemasGrupos.AddSistemaGruposRow(SistemaGrupo);

            int rowsAffected = Adapter.Update(SistemasGrupos);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarSistemaGrupos(byte CodigoGrupoSistema, string NombreGrupoSistema)		
        {
            DSDoblones20Sistema.SistemaGruposDataTable SistemasGrupos = Adapter.GetDataBy(CodigoGrupoSistema);
            if (SistemasGrupos.Count == 0)
                return false;

            DSDoblones20Sistema.SistemaGruposRow SistemaGrupo = SistemasGrupos[0];

            SistemaGrupo.NombreGrupoSistema = NombreGrupoSistema;


            int rowsAffected = Adapter.Update(SistemaGrupo);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarSistemaGrupos(byte CodigoGrupoSistema)
        {
            int rowsAffected = Adapter.Delete(CodigoGrupoSistema);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarSistemasGrupos()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerSistemaGrupo(byte CodigoGrupoSistema)
        {
            return Adapter.GetDataBy(CodigoGrupoSistema);
        }

        public DataTable ObtenerSistemaGruposUsuariosPorUsuario( int CodigoUsuario , int NumeroAgencia)
        {
            return Adapter.GetDataByUsuario(CodigoUsuario, NumeroAgencia);
        }
    }
}
