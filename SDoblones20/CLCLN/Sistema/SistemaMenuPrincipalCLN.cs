using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;

namespace CLCLN.Sistema
{
    public class SistemaMenuPrincipalCLN
    {
        private SistemaMenuPrincipalTableAdapter _SistemaMenuPrincipalAdapter = null;
        protected SistemaMenuPrincipalTableAdapter Adapter
        {
            get
            {
                if (_SistemaMenuPrincipalAdapter == null)
                    _SistemaMenuPrincipalAdapter = new SistemaMenuPrincipalTableAdapter();

                return _SistemaMenuPrincipalAdapter;
            }
        }

        public SistemaMenuPrincipalCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarSistemaMenuPrincipal(byte CodigoElementoMenuPadre, string NombreElementoMenu, string TextoElementoMenu, string CodigoTipoElementoMenu, string URLImagenElementoMenu, string NombreBotonBarra, string TextoBotonBarra, string URLImagenBotonBarra, string FuncionEnlace)
        {
            DSDoblones20Sistema.SistemaMenuPrincipalDataTable SistemaMenusPrincipal = new DSDoblones20Sistema.SistemaMenuPrincipalDataTable();
            DSDoblones20Sistema.SistemaMenuPrincipalRow SistemaMenuPrincipal = SistemaMenusPrincipal.NewSistemaMenuPrincipalRow();

            SistemaMenuPrincipal.CodigoElementoMenuPadre = CodigoElementoMenuPadre;            
            SistemaMenuPrincipal.NombreElementoMenu = NombreElementoMenu;
            SistemaMenuPrincipal.TextoElementoMenu = TextoElementoMenu;
            SistemaMenuPrincipal.CodigoTipoElementoMenu = CodigoTipoElementoMenu;
            SistemaMenuPrincipal.URLImagenElementoMenu = URLImagenElementoMenu;
            SistemaMenuPrincipal.NombreBotonBarra = NombreBotonBarra;
            SistemaMenuPrincipal.TextoBotonBarra = TextoBotonBarra;
            SistemaMenuPrincipal.URLImagenBotonBarra = URLImagenBotonBarra;
            SistemaMenuPrincipal.FuncionEnlace = FuncionEnlace;

            SistemaMenusPrincipal.AddSistemaMenuPrincipalRow(SistemaMenuPrincipal);

            int rowsAffected = Adapter.Update(SistemaMenusPrincipal);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarSistemaMenuPrincipal(byte CodigoElementoMenu, byte CodigoElementoMenuPadre, string NombreElementoMenu, string TextoElementoMenu, string CodigoTipoElementoMenu, string URLImagenElementoMenu, string NombreBotonBarra, string TextoBotonBarra, string URLImagenBotonBarra, string FuncionEnlace)
        {
            DSDoblones20Sistema.SistemaMenuPrincipalDataTable SistemaMenusPrincipal = Adapter.GetDataBy(CodigoElementoMenu);
            if (SistemaMenusPrincipal.Count == 0)
                return false;
            DSDoblones20Sistema.SistemaMenuPrincipalRow SistemaMenuPrincipal = SistemaMenusPrincipal[0];


            SistemaMenuPrincipal.CodigoElementoMenuPadre = CodigoElementoMenuPadre;
            SistemaMenuPrincipal.NombreElementoMenu = NombreElementoMenu;
            SistemaMenuPrincipal.TextoElementoMenu = TextoElementoMenu;
            SistemaMenuPrincipal.CodigoTipoElementoMenu = CodigoTipoElementoMenu;
            SistemaMenuPrincipal.URLImagenElementoMenu = URLImagenElementoMenu;
            SistemaMenuPrincipal.NombreBotonBarra = NombreBotonBarra;
            SistemaMenuPrincipal.TextoBotonBarra = TextoBotonBarra;
            SistemaMenuPrincipal.URLImagenBotonBarra = URLImagenBotonBarra;
            SistemaMenuPrincipal.FuncionEnlace = FuncionEnlace;

            int rowsAffected = Adapter.Update(SistemaMenuPrincipal);
            return rowsAffected == 1;

        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarSistemaMenuPrincipal(byte CodigoElementoMenu)
        {
            int rowsAffedted = Adapter.Delete(CodigoElementoMenu);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarSistemaGruposPermisosInterfaces()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerSistemaMenuPrincipal(byte CodigoElementoMenu)
        {
            return Adapter.GetDataBy(CodigoElementoMenu);
        }
    }
}
