using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercial2TableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.GestionComercial
{
    [System.ComponentModel.DataObject]
    public class MedioTransporteCLN
    {
        private MediosTransportesTableAdapter _MedioTransportesAdapter = null;
        protected MediosTransportesTableAdapter Adapter
        {
            get
            {
                if (_MedioTransportesAdapter == null)
                    _MedioTransportesAdapter = new MediosTransportesTableAdapter();

                return _MedioTransportesAdapter;
            }
        }

        public MedioTransporteCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarMedioTransporte(string NombreMedioTransporte, string Descripcion)
        {
            DSDoblones20GestionComercial2.MediosTransportesDataTable MedioTransportes = new DSDoblones20GestionComercial2.MediosTransportesDataTable();
            DSDoblones20GestionComercial2.MediosTransportesRow MedioTransporte = MedioTransportes.NewMediosTransportesRow();

            MedioTransporte.CodigoMedioTransporte = 0;
            MedioTransporte.NombreMedioTransporte = NombreMedioTransporte;
            MedioTransporte.Descripcion = Descripcion;

            MedioTransportes.AddMediosTransportesRow(MedioTransporte);

            int rowsAffected = Adapter.Update(MedioTransportes);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarMedioTransporte(byte CodigoMedioTransporte, string NombreMedioTransporte, string Descripcion)
        {
            DSDoblones20GestionComercial2.MediosTransportesDataTable MedioTransportes = Adapter.GetDataBy(CodigoMedioTransporte);
            if (MedioTransportes.Count == 0)
                return false;
            DSDoblones20GestionComercial2.MediosTransportesRow MedioTransporte = MedioTransportes[0];

            MedioTransporte.NombreMedioTransporte = NombreMedioTransporte;
            MedioTransporte.Descripcion = Descripcion;

            int rowsAffected = Adapter.Update(MedioTransporte);
            return rowsAffected == 1;

        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarMedioTransporte(int CodigoMedioTransporte)
        {
            int rowsAffedted = Adapter.Delete(CodigoMedioTransporte);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.MediosTransportesDataTable ListarMedioTransportes()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.MediosTransportesDataTable ObtenerMedioTransporte(int CodigoMedioTransporte)
        {
            return Adapter.GetDataBy(CodigoMedioTransporte);
        }

    }
}
