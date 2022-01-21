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
    public class BancosCLN
    {
        private BancosTableAdapter _bancosAdapter = null;
        protected BancosTableAdapter Adapter
        {
            get 
            {
                if (_bancosAdapter == null)
                    _bancosAdapter = new BancosTableAdapter();

                return _bancosAdapter;
            }
        }

        public BancosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarBanco(string NombreBanco)
        {
            DSDoblones20Sistema.BancosDataTable Bancos = new DSDoblones20Sistema.BancosDataTable();
            DSDoblones20Sistema.BancosRow banco = Bancos.NewBancosRow();

            banco.CodigoBanco = 0;
            banco.NombreBanco = NombreBanco;

            Bancos.AddBancosRow(banco);

            int rowsAffected = Adapter.Update(Bancos);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarBanco(int CodigoBanco, string NombreBanco)
        {
            DSDoblones20Sistema.BancosDataTable Bancos = Adapter.GetDataBy(CodigoBanco);
            if (Bancos.Count == 0)
                return false;
            DSDoblones20Sistema.BancosRow banco = Bancos[0];

            banco.NombreBanco = NombreBanco;
          

            int rowsAffected = Adapter.Update(banco);
            return rowsAffected == 1;

        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarBanco(int CodigoBanco)
        {
            int rowsAffedted = Adapter.Delete(CodigoBanco);
            return rowsAffedted == 1;
        }

        
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarBancos()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerBanco(int CodigoBanco)
        {
            return Adapter.GetDataBy(CodigoBanco);
        }
        
    }
}
