using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD;
using CLCAD.DSDoblones20ContabilidadTableAdapters;
using CLCAD.DSDoblones20SistemaTableAdapters;
using System.Data;
using System.Data.SqlClient;
using CLCAD.DSDoblones20GestionComercialTableAdapters;

namespace CLCLN.Contabilidad
{
    public class CuentasPorPagarCLN
    {
        private CuentasPorPagarTableAdapter _CuentasPorPagarAdapter = null;
        protected CuentasPorPagarTableAdapter Adapter
        {
            get
            {
                if (_CuentasPorPagarAdapter == null)
                    _CuentasPorPagarAdapter = new CuentasPorPagarTableAdapter();
                return _CuentasPorPagarAdapter;
            }
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCuentaPorPagar(int NumeroAgencia, int NumeroConcepto, int CodigoProveedor, byte CodigoMoneda, decimal Monto, DateTime FechaLimite, string CodigoEstado, string Observaciones, int CodigoUsuario, int NumeroAsiento)
        {
            DSDoblones20Contabilidad.CuentasPorPagarDataTable cuentas = new DSDoblones20Contabilidad.CuentasPorPagarDataTable();
            DSDoblones20Contabilidad.CuentasPorPagarRow cuenta = cuentas.NewCuentasPorPagarRow();

            cuenta.NumeroAgencia = NumeroAgencia;
            if (NumeroConcepto > 0)
                cuenta.NumeroConcepto = NumeroConcepto;
            else
                cuenta.SetNumeroConceptoNull();
            /*if (CodigoProveedor > 0)*/
                cuenta.CodigoProveedor = CodigoProveedor;
            /*else
                cuenta.SetCodigoProveedorNull();*/
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

            cuentas.AddCuentasPorPagarRow(cuenta);
            return Adapter.Update(cuentas) == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarCuentaPorPagar(int NumeroCuentaPorPagar, int NumeroConcepto, int NumeroAgencia, int CodigoProveedor, byte CodigoMoneda, decimal Monto, DateTime FechaLimite, string CodigoEstado, string Observaciones, int CodigoUsuario, int NumeroAsiento)
        {
            DSDoblones20Contabilidad.CuentasPorPagarRow cuenta = Adapter.GetDataByNumeroCuenta((int?)NumeroCuentaPorPagar)[0];

            cuenta.NumeroAgencia = NumeroAgencia;
            if (NumeroConcepto > 0)
                cuenta.NumeroConcepto = NumeroConcepto;
            else
                cuenta.SetNumeroConceptoNull();
            //if (CodigoProveedor > 0)
                cuenta.CodigoProveedor = CodigoProveedor;
            /*else
                cuenta.SetCodigoProveedorNull();*/
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
        public bool EliminarCuentaPorPagar(int NumeroCuentaPorPagar)
        {
            new CuentasPorPagarPagosCLN().EliminarCuentaPorPagarPago(NumeroCuentaPorPagar);
            return Adapter.Delete((int?)NumeroCuentaPorPagar) == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCuentasPorPagar()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCuentasPorPagar(int NumeroCuentaPorPagar)
        {
            return Adapter.GetDataByNumeroCuenta((int?)NumeroCuentaPorPagar);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarBusquedaCuentasPorPagar(string Palabra, DateTime Fecha1, DateTime Fecha2, string Estado1, string Estado2)
        {
            ListarCuentasPorPagarBusquedaTableAdapter consulta = new ListarCuentasPorPagarBusquedaTableAdapter();
            return consulta.GetData(Palabra, (DateTime?)Fecha1, (DateTime?)Fecha2, Estado1, Estado2);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarBusquedaCuentasPorPagar(int NumCtaXPagar)
        {
            ListarCuentasPorPagarBusquedaTableAdapter consulta = new ListarCuentasPorPagarBusquedaTableAdapter();
            return consulta.GetDataByNumCtaXPagar((int?)NumCtaXPagar);
        }

        public decimal ObtenerCuentaPorPagarDeuda(int NumeroAgencia, int NumeroCuentaPorPagar)
        {
            decimal? monto = 0;
            new FuncionesGestionComercial().ObtenerCuentaPorPagarDeuda(NumeroAgencia, NumeroCuentaPorPagar, ref monto);
            return (decimal)monto;
        }

        public DataTable Reporte()
        {
            ReporteCuentasPorPagarTableAdapter miadapter = new ReporteCuentasPorPagarTableAdapter();
            return miadapter.GetData();
        }

        public DataTable Reporte(int Numero)
        {
            ReporteCuentasPorPagarTableAdapter miadapter = new ReporteCuentasPorPagarTableAdapter();
            return miadapter.GetDataByNumero((int?)Numero);
        }


        public bool EsDeCompraProductos(int NumeroCuentaPorPagar)
        {
            QTAFuncionesContabilidad qta = new QTAFuncionesContabilidad();
            if (qta.CtaXPagarEsDeComprasProductos((int?)NumeroCuentaPorPagar) != null)
                return true;
            else
                return false;
            /*int? n = qta.CtaXPagarEsDeComprasProductos((int?)NumeroCuentaPorPagar);
            if (n == 1)
                return true;
            else
                return false;*/
        }

    }
}

