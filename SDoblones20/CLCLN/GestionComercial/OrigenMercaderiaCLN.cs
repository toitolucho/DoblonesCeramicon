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
    public class OrigenMercaderiaCLN
    {
        private OrigenMercaderiasTableAdapter _OrigenMercaderiasAdapter = null;
        protected OrigenMercaderiasTableAdapter Adapter
        {
            get
            {
                if (_OrigenMercaderiasAdapter == null)
                    _OrigenMercaderiasAdapter = new OrigenMercaderiasTableAdapter();

                return _OrigenMercaderiasAdapter;
            }
        }

        public OrigenMercaderiaCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarOrigenMercaderia(string NombreOrigenMercaderia, string Descripcion)
        {
            DSDoblones20GestionComercial2.OrigenMercaderiasDataTable OrigenMercaderias = new DSDoblones20GestionComercial2.OrigenMercaderiasDataTable();
            DSDoblones20GestionComercial2.OrigenMercaderiasRow origenMercaderia = OrigenMercaderias.NewOrigenMercaderiasRow();

            origenMercaderia.CodigoOrigenMercaderia = 0;
            origenMercaderia.NombreOrigenMercaderia = NombreOrigenMercaderia;
            origenMercaderia.Descripcion = Descripcion;

            OrigenMercaderias.AddOrigenMercaderiasRow(origenMercaderia);

            int rowsAffected = Adapter.Update(OrigenMercaderias);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarOrigenMercaderia(byte CodigoOrigenMercaderia, string NombreOrigenMercaderia, string Descripcion)
        {
            DSDoblones20GestionComercial2.OrigenMercaderiasDataTable OrigenMercaderias = Adapter.GetDataBy(CodigoOrigenMercaderia);
            if (OrigenMercaderias.Count == 0)
                return false;
            DSDoblones20GestionComercial2.OrigenMercaderiasRow origenMercaderia = OrigenMercaderias[0];

            origenMercaderia.NombreOrigenMercaderia = NombreOrigenMercaderia;
            origenMercaderia.Descripcion = Descripcion;

            int rowsAffected = Adapter.Update(origenMercaderia);
            return rowsAffected == 1;

        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarOrigenMercaderia(int CodigoOrigenMercaderia)
        {
            int rowsAffedted = Adapter.Delete(CodigoOrigenMercaderia);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.OrigenMercaderiasDataTable ListarOrigenMercaderias()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.OrigenMercaderiasDataTable ObtenerOrigenMercaderia(int CodigoOrigenMercaderia)
        {
            return Adapter.GetDataBy(CodigoOrigenMercaderia);
        }

    }
}
