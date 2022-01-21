using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms; 
namespace CLCLN.GestionComercial
{
    [System.ComponentModel.DataObject]
    public class CreditosCuotasCLN
    {
        private CreditosCuotasTableAdapter _CreditosCuotasAdapter = null;
        protected CreditosCuotasTableAdapter Adapter
        {
            get
            {
                if (_CreditosCuotasAdapter == null)
                    _CreditosCuotasAdapter = new CreditosCuotasTableAdapter();
                return _CreditosCuotasAdapter;
            }
        }

        public CreditosCuotasCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCreditoCuota(int NumeroCredito, int NumeroCuota, DateTime FechaCuota, decimal Cuota, decimal CuotaAmortizacion, decimal CuotaInteres,
                                    decimal TotalAmortizado, decimal SaldoAdeudado, decimal TotalPagado)
        {
            DSDoblones20GestionComercial.CreditosCuotasDataTable CreditosCuotas = new DSDoblones20GestionComercial.CreditosCuotasDataTable();
            DSDoblones20GestionComercial.CreditosCuotasRow CreditoCuota = CreditosCuotas.NewCreditosCuotasRow();

            CreditoCuota.NumeroCredito = NumeroCredito;
            CreditoCuota.NumeroCuota = NumeroCuota;
            CreditoCuota.FechaCuota = FechaCuota;
            CreditoCuota.Cuota = Cuota;
            CreditoCuota.CuotaAmortizacion = CuotaAmortizacion;
            CreditoCuota.CuotaInteres = CuotaInteres;
            CreditoCuota.TotalAmortizado = TotalAmortizado;
            CreditoCuota.SaldoAdeudado = SaldoAdeudado;
            CreditoCuota.TotalPagado = TotalPagado;

            CreditosCuotas.AddCreditosCuotasRow(CreditoCuota);

            int rowsAffected = Adapter.Update(CreditosCuotas);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarCreditoCuota(int NumeroCredito, int NumeroCuota, DateTime FechaCuota, decimal Cuota, decimal CuotaAmortizacion, decimal CuotaInteres,
                                    decimal TotalAmortizado, decimal SaldoAdeudado, decimal TotalPagado)
        {
            DSDoblones20GestionComercial.CreditosCuotasDataTable CreditosCuotas = Adapter.GetDataBy(NumeroCredito, NumeroCuota);
            if (CreditosCuotas.Count == 0)
                return false;

            DSDoblones20GestionComercial.CreditosCuotasRow CreditoCuota = CreditosCuotas[0];

            CreditoCuota.NumeroCredito = NumeroCredito;
            CreditoCuota.NumeroCuota = NumeroCuota;
            CreditoCuota.FechaCuota = FechaCuota;
            CreditoCuota.Cuota = Cuota;
            CreditoCuota.CuotaAmortizacion = CuotaAmortizacion;
            CreditoCuota.CuotaInteres = CuotaInteres;
            CreditoCuota.TotalAmortizado = TotalAmortizado;
            CreditoCuota.SaldoAdeudado = SaldoAdeudado;
            CreditoCuota.TotalPagado = TotalPagado;

            CreditosCuotas.AddCreditosCuotasRow(CreditoCuota);

            int rowsAffected = Adapter.Update(CreditoCuota);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCreditoCuota(int NumeroCredito, int NumeroCuota)                           	                   	     
        {
            int rowsAffected = Adapter.Delete(NumeroCredito, NumeroCuota);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCreditosCuotas()
        {
            return Adapter.GetData();
        }


        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCreditoCuotasNumeroCredito(int NumeroCredito)
        {
            return Adapter.GetDataByCreditoCuotasNumeroCredito(NumeroCredito);
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerCreditoCuota(int NumeroCredito, int NumeroCuota)
        {
            return Adapter.GetDataBy(NumeroCredito, NumeroCuota);
        }

        public DataTable ObtenerSiguienteCuotaPago(int NumeroCredito)
        {
            return Adapter.GetDataByObtenerSiguienteCuotaPago(NumeroCredito);
        }

        /*
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable BuscarCreditosCuotas(string CodigoAmbitoBusqueda, string TextoABuscar, bool ExactamenteIgual)
        {
            return Adapter.GetDataByBuscarCreditosCuotas(CodigoAmbitoBusqueda, TextoABuscar, ExactamenteIgual);
        }
        */

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public void GenerarTablaAmortizaciones(int NumeroCredito, string CodigoSistema, decimal V, int n, int CodigoFrecuencia, decimal ia, DateTime FechaPrimeraAmortizacion)
        {
            Adapter.GetDataByGenerarTablaAmortizacion(NumeroCredito, CodigoSistema, V, n, CodigoFrecuencia, ia, FechaPrimeraAmortizacion);
            return;
        }
    }
}
