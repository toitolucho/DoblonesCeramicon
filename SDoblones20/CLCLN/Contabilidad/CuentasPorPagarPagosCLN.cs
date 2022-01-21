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
    public class CuentasPorPagarPagosCLN
    {
        private CuentasPorPagarPagosTableAdapter _CuentasPorPagarDetalleAdapter = null;
        protected CuentasPorPagarPagosTableAdapter Adapter
        {
            get
            {
                if (_CuentasPorPagarDetalleAdapter == null)
                    _CuentasPorPagarDetalleAdapter = new CuentasPorPagarPagosTableAdapter();
                return _CuentasPorPagarDetalleAdapter;
            }
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCuentaPorPagarPago(int NumeroCuentaPorPagar, decimal Monto, int CodigoUsuario, int NumeroAsiento)
        {
            DSDoblones20Contabilidad.CuentasPorPagarPagosDataTable pagos = new DSDoblones20Contabilidad.CuentasPorPagarPagosDataTable();
            DSDoblones20Contabilidad.CuentasPorPagarPagosRow pago = pagos.NewCuentasPorPagarPagosRow();

            pago.NumeroCuentaPorPagar = NumeroCuentaPorPagar;
            pago.Monto = Monto;
            pago.CodigoUsuario = CodigoUsuario;
            if (NumeroAsiento > 0)
                pago.NumeroAsiento = NumeroAsiento;
            else
                pago.SetNumeroAsientoNull();

            QTAFuncionesContabilidad consulta = new QTAFuncionesContabilidad();
            string dt = null;
            dt = consulta.FechaHora();

            pago.FechaHoraPago = DateTime.Parse(dt);

            pagos.AddCuentasPorPagarPagosRow(pago);
            return Adapter.Update(pagos) == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarCuentaPorPagarPago(int NumeroPago, decimal Monto, int CodigoUsuario)
        {
            DSDoblones20Contabilidad.CuentasPorPagarPagosRow pago = Adapter.GetDataByNumeroPago((int?)NumeroPago)[0];

            pago.Monto = Monto;
            pago.CodigoUsuario = CodigoUsuario;

            return Adapter.Update(pago) == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCuentaPorPagarPago(int NumeroPago)
        {
            return Adapter.Delete((int?)NumeroPago) == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCuentaPorPagarPagoNumeroCuenta(int NumeroCuentaPorPagar)
        {
            return Adapter.EliminarCuentasPorPagarPagosNumeroCuenta(NumeroCuentaPorPagar) == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCuentasPorPagarPagos(int NumeroCuentaPorPagar)
        {
            return Adapter.GetData((int?)NumeroCuentaPorPagar);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCuentaPorPagarPago(int NumeroPago)
        {
            return Adapter.GetDataByNumeroPago((int?)NumeroPago);
        }

        public DataTable ListarCuentasPorPagarPagosDetalle(int NumeroCuentaPorPagar)
        {
            ListarCuentasPorPagarPagosDetalladoTableAdapter miadapter = new ListarCuentasPorPagarPagosDetalladoTableAdapter();
            return miadapter.GetData((int?)NumeroCuentaPorPagar);
        }
    }
}
