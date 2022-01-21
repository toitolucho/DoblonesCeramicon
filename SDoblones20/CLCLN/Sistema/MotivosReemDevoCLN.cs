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
    public class MotivosReemDevoCLN
    {
        private MotivosReemDevoTableAdapter _MotivosReemDevoAdapter = null;
        protected MotivosReemDevoTableAdapter Adapter
        {
            get
            {
                if (_MotivosReemDevoAdapter == null)
                    _MotivosReemDevoAdapter = new MotivosReemDevoTableAdapter();
                return _MotivosReemDevoAdapter;
            }
        }

        public MotivosReemDevoCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarMotivoReemDevo(string NombreMotivoReemDevo, string EstadoRetornoInventario, string TipoTransaccion)		
        {
            DSDoblones20Sistema.MotivosReemDevoDataTable MotivosReemDevo = new DSDoblones20Sistema.MotivosReemDevoDataTable();
            DSDoblones20Sistema.MotivosReemDevoRow MotivoReemDevo = MotivosReemDevo.NewMotivosReemDevoRow();

            MotivoReemDevo.CodigoMotivoReemDevo = 0;
            MotivoReemDevo.NombreMotivoReemDevo = NombreMotivoReemDevo;
            MotivoReemDevo.EstadoRetornoInventario = EstadoRetornoInventario;
            MotivoReemDevo.TipoTransaccion = TipoTransaccion;
                
            MotivosReemDevo.AddMotivosReemDevoRow(MotivoReemDevo);

            int rowsAffected = Adapter.Update(MotivosReemDevo);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarMotivoReemDevo(int CodigoMotivoReemDevo, string NombreMotivoReemDevo, string EstadoRetornoInventario, string TipoTransaccion)		
        {
            DSDoblones20Sistema.MotivosReemDevoDataTable MotivosReemDevo = Adapter.GetDataBy(CodigoMotivoReemDevo);
            if (MotivosReemDevo.Count == 0)
                return false;

            DSDoblones20Sistema.MotivosReemDevoRow MotivoReemDevo = MotivosReemDevo[0];

            MotivoReemDevo.CodigoMotivoReemDevo = CodigoMotivoReemDevo;
            MotivoReemDevo.NombreMotivoReemDevo = NombreMotivoReemDevo;
            MotivoReemDevo.EstadoRetornoInventario = EstadoRetornoInventario;
            MotivoReemDevo.TipoTransaccion = TipoTransaccion;

            int rowsAffected = Adapter.Update(MotivoReemDevo);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarMotivoReemDevo(int CodigoMotivoReemDevo)                           	                   	     
        {
            int rowsAffected = Adapter.Delete(CodigoMotivoReemDevo);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarMotivosReemDevo()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarMotivosReemDevo(string TipoTransaccion)
        {
            return Adapter.GetDataBy1(TipoTransaccion);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerMotivoReemDevo(int CodigoMotivoReemDevo)
        {
            return Adapter.GetDataBy(CodigoMotivoReemDevo);
        }
    }
}
