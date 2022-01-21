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
    public class MonedasCLN
    {
        private MonedasTableAdapter _MonedasAdapter = null;
        protected MonedasTableAdapter Adapter
        {
            get
            {
                if (_MonedasAdapter == null)
                    _MonedasAdapter = new MonedasTableAdapter();
                return _MonedasAdapter;
            }
        }

        public MonedasCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarMoneda(string NombreMoneda, string MascaraMoneda)		
        {
            DSDoblones20Sistema.MonedasDataTable Monedas = new DSDoblones20Sistema.MonedasDataTable();
            DSDoblones20Sistema.MonedasRow Moneda = Monedas.NewMonedasRow();

            Moneda.CodigoMoneda = 0;
            Moneda.NombreMoneda = NombreMoneda;
            Moneda.MascaraMoneda = MascaraMoneda;
                                          
            Monedas.AddMonedasRow(Moneda);

            int rowsAffected = Adapter.Update(Monedas);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarMoneda(byte CodigoMoneda, string NombreMoneda, string MascaraMoneda)		
        {
            DSDoblones20Sistema.MonedasDataTable Monedas = Adapter.GetDataBy(CodigoMoneda);
            if (Monedas.Count == 0)
                return false;

            DSDoblones20Sistema.MonedasRow Moneda = Monedas[0];

            Moneda.CodigoMoneda = CodigoMoneda;
            Moneda.NombreMoneda = NombreMoneda;
            Moneda.MascaraMoneda = MascaraMoneda;

        

            int rowsAffected = Adapter.Update(Moneda);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarMoneda(byte CodigoMoneda)                           	                   	     
        {
            int rowsAffected = Adapter.Delete(CodigoMoneda);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarMonedas()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerMoneda(byte CodigoMoneda)
        {
            return Adapter.GetDataBy(CodigoMoneda);
        }
    }
}
