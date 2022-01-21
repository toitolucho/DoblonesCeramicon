using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD.DSDoblones20ContabilidadTableAdapters;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.Contabilidad
{
    public class MonedasFraccionesCLN
    {
        private MonedasFraccionesTableAdapter _MonedasFraccionesTableAdapter = null;
        protected MonedasFraccionesTableAdapter Adapter
        {
            get
            {
                if (_MonedasFraccionesTableAdapter == null)
                    _MonedasFraccionesTableAdapter = new MonedasFraccionesTableAdapter();
                return _MonedasFraccionesTableAdapter;
            }
        }


        public MonedasFraccionesCLN()
        { }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool Insertar(string CodigoMoneda, string Valor)
        {
            DSDoblones20Contabilidad.MonedasFraccionesDataTable monedas = new DSDoblones20Contabilidad.MonedasFraccionesDataTable();
            DSDoblones20Contabilidad.MonedasFraccionesRow moneda = monedas.NewMonedasFraccionesRow();

            moneda.CodigoMoneda = byte.Parse(CodigoMoneda);            
            moneda.Valor = decimal.Parse(Valor);

            monedas.AddMonedasFraccionesRow(moneda);

            int rowsAffected = Adapter.Update(moneda);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool Actualizar(string CodigoMonedaFraccion, string Valor)
        {
            int CodMonFracc = int.Parse(CodigoMonedaFraccion);

            DSDoblones20Contabilidad.MonedasFraccionesDataTable monedas = Adapter.GetDataByCodigoMonedaFraccion(CodMonFracc);
            DSDoblones20Contabilidad.MonedasFraccionesRow moneda = monedas[0];
                        
            moneda.Valor = decimal.Parse(Valor);

            int rowsAffected = Adapter.Update(moneda);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool Eliminar(string CodigoMonedaFraccion)
        {
            int CodMonFracc = int.Parse(CodigoMonedaFraccion);
            int rowsAffected = Adapter.Delete(CodMonFracc);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarMonedasFracciones()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarMonedasFracciones(string CodigoMoneda)
        {
            int n = int.Parse(CodigoMoneda);
            return Adapter.GetDataByCodigoMoneda(n);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public bool Existe(string CodigoMoneda, string Valor)
        {
            int CodMon = int.Parse(CodigoMoneda);
            decimal Val = decimal.Parse(Valor);

            if (Adapter.GetDataByCodigoMonedaValor(CodMon, Val).Rows.Count == 0)
                return false;
            else
                return true;
        }
    
    }
}
