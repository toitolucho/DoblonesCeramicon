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
    public class CuentasConfiguracionCLN
    {
        private ConfiguracionesCuentasDetalleTableAdapter _CuentasConfiguracionesTableAdapter = null;
        protected ConfiguracionesCuentasDetalleTableAdapter Adapter
        {
            get
            {
                if (_CuentasConfiguracionesTableAdapter == null)
                    _CuentasConfiguracionesTableAdapter = new ConfiguracionesCuentasDetalleTableAdapter();
                return _CuentasConfiguracionesTableAdapter;
            }
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCuentasConfiguracion(int Numero, string NumeroCuenta, char Tipo, decimal PorcentajeMontoTotalDH)
        {
            DSDoblones20Contabilidad.ConfiguracionesCuentasDetalleDataTable cuentas = new DSDoblones20Contabilidad.ConfiguracionesCuentasDetalleDataTable();
            DSDoblones20Contabilidad.ConfiguracionesCuentasDetalleRow cuenta = cuentas.NewConfiguracionesCuentasDetalleRow();

            cuenta.NumeroConfiguracion = Numero;
            cuenta.NumeroCuentaConfiguracion = NumeroCuenta;
            cuenta.TipoCuentaDebeHaber = Tipo.ToString();
            cuenta.PorcentajeMontoTotalDH = PorcentajeMontoTotalDH;

            cuentas.AddConfiguracionesCuentasDetalleRow(cuenta);
            return Adapter.Update(cuentas) == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCuentasConfiguracion(int Numero)
        {
            return Adapter.Delete((int?)Numero) == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarPorNumero(int Numero)
        {
            return new ListarConfiguracionesCuentasDetallePorNumeroConfiguracionDHTableAdapter().GetData((int?)Numero,null);
        }

        public DSDoblones20Contabilidad.ListarConfiguracionesCuentasDetallePorNumeroConfiguracionDHDataTable
            ListarConfiguracionesCuentasDetallePorNumeroConfiguracionDH(int NumeroConfiguracion, string CodigoTipoDebeHaber)
        {
            return new ListarConfiguracionesCuentasDetallePorNumeroConfiguracionDHTableAdapter().GetData((int?)NumeroConfiguracion, CodigoTipoDebeHaber);
        }

    }
}
