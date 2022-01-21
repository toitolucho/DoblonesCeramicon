using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;

namespace CLCLN.Sistema
{
    public class SistemasInterfacesCLN
    {
        private ListarSistemasInterfacesTableAdapter _SistemasInterfacesAdapter = null;
        protected ListarSistemasInterfacesTableAdapter Adapter
        {
            get
            {
                if (_SistemasInterfacesAdapter == null)
                    _SistemasInterfacesAdapter = new ListarSistemasInterfacesTableAdapter();
                return _SistemasInterfacesAdapter;
            }
        }

        public SistemasInterfacesCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarSistemaInteraz(string NombreInterface, string TextoInterface, string CodigoTipoInterface)
        {

            DSDoblones20Sistema.ListarSistemasInterfacesDataTable SistemasInterfaces = new DSDoblones20Sistema.ListarSistemasInterfacesDataTable();
            DSDoblones20Sistema.ListarSistemasInterfacesRow SistemaInteraz = SistemasInterfaces.NewListarSistemasInterfacesRow();

            SistemaInteraz.NombreInterface = NombreInterface;
            SistemaInteraz.TextoInterface = TextoInterface;
            SistemaInteraz.CodigoTipoInterface = CodigoTipoInterface;
                                          
            SistemasInterfaces.AddListarSistemasInterfacesRow(SistemaInteraz);

            int rowsAffected = Adapter.Update(SistemasInterfaces);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarSistemaInteraz(byte CodigoInterface, string NombreInterface, string TextoInterface, string CodigoTipoInterface)		
        {
            DSDoblones20Sistema.ListarSistemasInterfacesDataTable SistemasInterfaces = Adapter.GetDataBy(CodigoInterface);
            if (SistemasInterfaces.Count == 0)
                return false;

            DSDoblones20Sistema.ListarSistemasInterfacesRow SistemaInteraz = SistemasInterfaces[0];

            SistemaInteraz.NombreInterface = NombreInterface;
            SistemaInteraz.TextoInterface = TextoInterface;
            SistemaInteraz.CodigoTipoInterface = CodigoTipoInterface;
            
            int rowsAffected = Adapter.Update(SistemaInteraz);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarSistemaInteraz(byte CodigoInterface)
        {
            int rowsAffected = Adapter.Delete(CodigoInterface);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarSistemasInterfaces()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerSistemaInteraz(byte CodigoInterface)
        {
            return Adapter.GetDataBy(CodigoInterface);
        }

        public DataTable BuscarSistemasInterfaz(string CodigoAmbitoBusqueda, string TextoABuscar, bool ExactamenteIgual)
        {
            return Adapter.GetDataByBusqueda(CodigoAmbitoBusqueda, TextoABuscar, ExactamenteIgual);
        }

    }
}
