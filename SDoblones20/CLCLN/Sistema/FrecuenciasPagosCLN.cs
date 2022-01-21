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
    public class FrecuenciasPagosCLN
    {
        private FrecuenciasPagosTableAdapter _FrecuenciasPagosAdapter = null;
        protected FrecuenciasPagosTableAdapter Adapter
        {
            get
            {
                if (_FrecuenciasPagosAdapter == null)
                    _FrecuenciasPagosAdapter = new FrecuenciasPagosTableAdapter();
                return _FrecuenciasPagosAdapter;
            }
        }

        public FrecuenciasPagosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarFrecuenciaPago(string NombreFrecuenciaPago, int NumeroDias)		
        {
            DSDoblones20Sistema.FrecuenciasPagosDataTable FrecuenciasPagos = new DSDoblones20Sistema.FrecuenciasPagosDataTable();
            DSDoblones20Sistema.FrecuenciasPagosRow FrecuenciaPago = FrecuenciasPagos.NewFrecuenciasPagosRow();

            FrecuenciaPago.NombreFrecuenciaPago = NombreFrecuenciaPago;
            FrecuenciaPago.NumeroDias = NumeroDias;
                               
            FrecuenciasPagos.AddFrecuenciasPagosRow(FrecuenciaPago);

            int rowsAffected = Adapter.Update(FrecuenciasPagos);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarFrecuenciaPago(int CodigoFrecuenciaPago, string NombreFrecuenciaPago, int NumeroDias)		
        {
            DSDoblones20Sistema.FrecuenciasPagosDataTable FrecuenciasPagos = Adapter.GetDataBy(CodigoFrecuenciaPago);
            if (FrecuenciasPagos.Count == 0)
                return false;

            DSDoblones20Sistema.FrecuenciasPagosRow FrecuenciaPago = FrecuenciasPagos[0];

            FrecuenciaPago.NombreFrecuenciaPago = NombreFrecuenciaPago;
            FrecuenciaPago.NumeroDias = NumeroDias;

            int rowsAffected = Adapter.Update(FrecuenciaPago);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarFrecuenciaPago(int CodigoFrecuenciaPago)
        {
            int rowsAffected = Adapter.Delete(CodigoFrecuenciaPago);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarFrecuenciasPagos()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerFrecuenciaPago(int CodigoFrecuenciaPago)
        {
            return Adapter.GetDataBy(CodigoFrecuenciaPago);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public int ObtenerDiasFrecuenciaPago(int CodigoFrecuenciaPago)
        {
            DSDoblones20Sistema.FrecuenciasPagosDataTable FrecuenciasPagos = Adapter.GetDataBy(CodigoFrecuenciaPago);
            if (FrecuenciasPagos.Count == 0)
                return 0;

            DSDoblones20Sistema.FrecuenciasPagosRow FrecuenciaPago = FrecuenciasPagos[0];

            return FrecuenciaPago.NumeroDias;
        }
    }
}
