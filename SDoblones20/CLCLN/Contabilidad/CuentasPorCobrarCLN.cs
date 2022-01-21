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
    public class CuentasPorCobrarCLN
    {
        private CuentasPorCobrarTableAdapter _CuentasPorCobrarAdapter = null;
        protected CuentasPorCobrarTableAdapter Adapter
        {
            get
            {
                if (_CuentasPorCobrarAdapter == null)
                    _CuentasPorCobrarAdapter = new CuentasPorCobrarTableAdapter();
                return _CuentasPorCobrarAdapter;
            }
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCuentaPorCobrar(int NumeroAgencia, int NumeroConcepto, int CodigoProveedor, byte CodigoMoneda, decimal Monto, DateTime FechaLimite, string CodigoEstado, string Observaciones, int CodigoUsuario, int NumeroAsiento)
        {
            DSDoblones20Contabilidad.CuentasPorCobrarDataTable cuentas = new DSDoblones20Contabilidad.CuentasPorCobrarDataTable();
            DSDoblones20Contabilidad.CuentasPorCobrarRow cuenta = cuentas.NewCuentasPorCobrarRow();

            cuenta.NumeroAgencia = NumeroAgencia;
            cuenta.NumeroConcepto = NumeroConcepto;
            if (NumeroConcepto > 0)
                cuenta.NumeroConcepto = NumeroConcepto;
            else
                cuenta.SetNumeroConceptoNull();
            if (CodigoProveedor > 0)
                cuenta.CodigoProveedor = CodigoProveedor;
            else
                cuenta.SetCodigoProveedorNull();
            cuenta.CodigoMoneda = CodigoMoneda;
            cuenta.Monto = Monto;
            cuenta.FechaLimite = FechaLimite;
            cuenta.CodigoEstado = CodigoEstado;
            cuenta.Observaciones = Observaciones;
            cuenta.CodigoUsuario = CodigoUsuario;

            if (NumeroAsiento == -1)
                cuenta.SetNumeroAsientoNull();
            else
                cuenta.NumeroAsiento = NumeroAsiento;

            QTAFuncionesContabilidad consulta = new QTAFuncionesContabilidad();
            string dt = null;
            dt = consulta.FechaHora();

            cuenta.FechaHoraRegistro = DateTime.Parse(dt);

            if (FechaLimite.Year != 0001)
                cuenta.FechaLimite = FechaLimite;
            else
                cuenta.SetFechaLimiteNull();

            cuentas.AddCuentasPorCobrarRow(cuenta);
            return Adapter.Update(cuentas) == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarCuentaPorCobrar(int NumeroCuentaPorCobrar, int NumeroConcepto, int NumeroAgencia, int CodigoProveedor, byte CodigoMoneda, decimal Monto, DateTime FechaLimite, string CodigoEstado, string Observaciones, int CodigoUsuario, int NumeroAsiento)
        {
            DSDoblones20Contabilidad.CuentasPorCobrarRow cuenta = Adapter.GetDataByNumeroCuenta((int?)NumeroCuentaPorCobrar)[0];

            cuenta.NumeroAgencia = NumeroAgencia;
            if (NumeroConcepto > 0)
                cuenta.NumeroConcepto = NumeroConcepto;
            else
                cuenta.SetNumeroConceptoNull();
            if (CodigoProveedor > 0)
                cuenta.CodigoProveedor = CodigoProveedor;
            else
                cuenta.SetCodigoProveedorNull();
            cuenta.CodigoMoneda = CodigoMoneda;
            cuenta.Monto = Monto;
            cuenta.FechaLimite = FechaLimite;
            cuenta.CodigoEstado = CodigoEstado;
            cuenta.Observaciones = Observaciones;
            cuenta.CodigoUsuario = CodigoUsuario;

            if (NumeroAsiento == -1)
                cuenta.SetNumeroAsientoNull();
            else
                cuenta.NumeroAsiento = NumeroAsiento;

            if (FechaLimite.Year != 0001)
                cuenta.FechaLimite = FechaLimite;
            else
                cuenta.SetFechaLimiteNull();

            QTAFuncionesContabilidad consulta = new QTAFuncionesContabilidad();
            string dt = null;
            dt = consulta.FechaHora();

            cuenta.FechaHoraRegistro = DateTime.Parse(dt);

            return Adapter.Update(cuenta) == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCuentaPorCobrar(int NumeroCuentaPorCobrar)
        {
            new CuentasPorCobrarCobrosCLN().EliminarCuentaPorCobrarCobro(NumeroCuentaPorCobrar);
            return Adapter.Delete((int?)NumeroCuentaPorCobrar) == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCuentasPorCobrar()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCuentasPorCobrarPorNumeroCuenta(int NumeroCuentaPorCobrar)
        {
            return Adapter.GetDataByNumeroCuenta((int?)NumeroCuentaPorCobrar);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCuentasPorCobrarBusqueda(string Palabra, DateTime Fecha1, DateTime Fecha2, string Estado1, string Estado2)
        {
            ListarCuentasPorCobrarBusquedaTableAdapter consulta = new ListarCuentasPorCobrarBusquedaTableAdapter();
            return consulta.GetData(Palabra, (DateTime?)Fecha1, (DateTime?)Fecha2, Estado1, Estado2);
        }

        public DataTable Reporte()
        {
            ReporteCuentasPorCobrarTableAdapter miadapter = new ReporteCuentasPorCobrarTableAdapter();
            return miadapter.GetData();
        }

        public DataTable Reporte(int Numero)
        {
            ReporteCuentasPorCobrarTableAdapter miadapter = new ReporteCuentasPorCobrarTableAdapter();
            return miadapter.GetDataByNumero((int?)Numero);
        }
    }
}
