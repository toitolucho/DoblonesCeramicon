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
    [System.ComponentModel.DataObject]
    class InterfacesSistemaCLN
    {
        private InterfacesSistemaTableAdapter _InterfacesSistemaAdapter = null;
        protected InterfacesSistemaTableAdapter Adapter
        {
            get 
            {
                if (_InterfacesSistemaAdapter == null)
                    _InterfacesSistemaAdapter = new InterfacesSistemaTableAdapter();

                return _InterfacesSistemaAdapter;
            }
        }

        public InterfacesSistemaCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarInterfaceSistema(string NombreInterface)
        {
            DSDoblones20Sistema.InterfacesSistemaDataTable InterfacesSistema = new DSDoblones20Sistema.InterfacesSistemaDataTable();
            DSDoblones20Sistema.InterfacesSistemaRow InterfaceSistema = InterfacesSistema.NewInterfacesSistemaRow();

            InterfaceSistema.NombreInterface = NombreInterface;

            InterfacesSistema.AddInterfacesSistemaRow(InterfaceSistema);

            int rowsAffected = Adapter.Update(InterfacesSistema);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarInterfaceSistema(int CodigoInterface, string NombreInterface)
        {
            DSDoblones20Sistema.InterfacesSistemaDataTable InterfacesSistema = Adapter.GetDataBy(CodigoInterface);
            if (InterfacesSistema.Count == 0)
                return false;
            DSDoblones20Sistema.InterfacesSistemaRow InterfaceSistema = InterfacesSistema[0];

            InterfaceSistema.NombreInterface = NombreInterface;
            InterfacesSistema.AddInterfacesSistemaRow(InterfaceSistema);

            int rowsAffected = Adapter.Update(InterfaceSistema);
            return rowsAffected == 1;

        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarInterfaceSistema(int CodigoInterface)
        {
            int rowsAffedted = Adapter.Delete(CodigoInterface);
            return rowsAffedted == 1;
        }

        
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarInterfacesSistema()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerInterfaceSistema(int CodigoInterface)
        {
            return Adapter.GetDataBy(CodigoInterface);
        }
    }
}
