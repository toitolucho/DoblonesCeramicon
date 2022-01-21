using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD;
using CLCAD.DSDoblones20ContabilidadTableAdapters;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.Contabilidad
{
    public class ConceptosCLN
    {
        private ConceptosTableAdapter _ConceptosTableAdapter = null;
        protected ConceptosTableAdapter Adapter
        {
            get
            {
                if (_ConceptosTableAdapter == null)
                    _ConceptosTableAdapter = new ConceptosTableAdapter();
                return _ConceptosTableAdapter;
            }
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarConcepto(string Concepto)
        {
            DSDoblones20Contabilidad.ConceptosDataTable conceptos = new DSDoblones20Contabilidad.ConceptosDataTable();
            DSDoblones20Contabilidad.ConceptosRow concepto = conceptos.NewConceptosRow();

            concepto.Concepto = Concepto;

            conceptos.AddConceptosRow(concepto);
            return Adapter.Update(conceptos) == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarConcepto(int NumeroConcepto)
        {
            return Adapter.Delete((int?)NumeroConcepto) == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarConcepto(int NumeroConcepto, string Concepto)
        {
            DSDoblones20Contabilidad.ConceptosRow concepto = Adapter.GetDataByNumeroConcepto((int?)NumeroConcepto)[0];

            concepto.Concepto = Concepto;

            return Adapter.Update(concepto) == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarConceptos()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarConceptosPorNumeroConcepto(int NumeroConcepto)
        {
            return Adapter.GetDataByNumeroConcepto((int?)NumeroConcepto);
        }


    }
}
