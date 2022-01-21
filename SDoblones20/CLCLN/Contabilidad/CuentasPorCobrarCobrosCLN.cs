using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD;
using CLCAD.DSDoblones20ContabilidadTableAdapters;
using CLCAD.DSDoblones20SistemaTableAdapters;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.Contabilidad
{
    public class CuentasPorCobrarCobrosCLN
    {
        private CuentasPorCobrarCobrosTableAdapter _CuentasPorCobrarCobrosAdapter = null;
        protected CuentasPorCobrarCobrosTableAdapter Adapter
        {
            get
            {
                if (_CuentasPorCobrarCobrosAdapter == null)
                    _CuentasPorCobrarCobrosAdapter = new CuentasPorCobrarCobrosTableAdapter();
                return _CuentasPorCobrarCobrosAdapter;
            }
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCuentaPorCobrarCobro(int NumeroCuentaPorCobrar, decimal Monto, int CodigoUsuario)
        {
            DSDoblones20Contabilidad.CuentasPorCobrarCobrosDataTable cobros = new DSDoblones20Contabilidad.CuentasPorCobrarCobrosDataTable();
            DSDoblones20Contabilidad.CuentasPorCobrarCobrosRow cobro = cobros.NewCuentasPorCobrarCobrosRow();

            cobro.NumeroCuentaPorCobrar = NumeroCuentaPorCobrar;
            cobro.Monto = Monto;
            cobro.CodigoUsuario = CodigoUsuario;

            QTAFuncionesContabilidad consulta = new QTAFuncionesContabilidad();
            string dt = null;
            dt = consulta.FechaHora();

            cobro.FechaHoraCobro = DateTime.Parse(dt);

            cobros.AddCuentasPorCobrarCobrosRow(cobro);
            return Adapter.Update(cobros) == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCuentaPorCobrarCobro(int NumeroCobro)
        {
            return Adapter.Delete((int?)NumeroCobro) == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarCuentaPorCobrarCobros(int NumeroCobro, decimal Monto, int CodigoUsuario)
        {
            DSDoblones20Contabilidad.CuentasPorCobrarCobrosRow cobro = Adapter.GetDataByNumeroCobro((int?)NumeroCobro)[0];

            cobro.Monto = Monto;
            cobro.CodigoUsuario = CodigoUsuario;

            return Adapter.Update(cobro) == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCuentaPorCobrarCobroNumeroCuenta(int NumeroCuentaPorCobrar)
        {
            return Adapter.EliminarCuentasPorCobrarCobrosNumeroCuenta((int?)NumeroCuentaPorCobrar) == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCuentasPorCobrarCobros(int NumeroCuentaPorCobrar)
        {
            return Adapter.GetData((int?)NumeroCuentaPorCobrar);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCuentaPorCobrarCobro(int NumeroCobro)
        {
            return Adapter.GetDataByNumeroCobro((int?)NumeroCobro);
        }

        public DataTable ListarCuentasPorCobrarCobrosDetalle(int NumeroCuentaPorCobrar)
        {
            ListarCuentasPorCobrarCobrosDetalladoTableAdapter miadapter = new ListarCuentasPorCobrarCobrosDetalladoTableAdapter();
            return miadapter.GetData((int?)NumeroCuentaPorCobrar);
        }

    }
}
