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
    public class CreditosCuotasPagosCLN
    {
        private CreditosCuotasPagosTableAdapter _CreditosCuotasPagosAdapter = null;
        protected CreditosCuotasPagosTableAdapter Adapter
        {
            get
            {
                if (_CreditosCuotasPagosAdapter == null)
                    _CreditosCuotasPagosAdapter = new CreditosCuotasPagosTableAdapter();
                return _CreditosCuotasPagosAdapter;
            }
        }

        public CreditosCuotasPagosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCreditoCuotaPago(int NumeroCredito, int NumeroCuota, decimal MontoPago, string CodigoMedioPago, string NumeroCuentaBanco,
            string DIPersonaPago, string NombreCompletoPersonaPago, int NumeroAgencia,  int CodigoUsuario)
        {
            DSDoblones20GestionComercial.CreditosCuotasPagosDataTable CreditosCuotasPagos = new DSDoblones20GestionComercial.CreditosCuotasPagosDataTable();
            DSDoblones20GestionComercial.CreditosCuotasPagosRow CreditoCuotaPago = CreditosCuotasPagos.NewCreditosCuotasPagosRow();

            CreditoCuotaPago.NumeroCredito = NumeroCredito;
            CreditoCuotaPago.NumeroCuota = NumeroCuota;
            //CreditoCuotaPago.FechaHoraPago = FechaHoraPago;
            CreditoCuotaPago.MontoPago = MontoPago;
            CreditoCuotaPago.CodigoMedioPago = CodigoMedioPago;
            CreditoCuotaPago.NumeroCuentaBanco = NumeroCuentaBanco;
            CreditoCuotaPago.DIPersonaPago = DIPersonaPago;
            CreditoCuotaPago.NombreCompletoPersonaPago = NombreCompletoPersonaPago;
            CreditoCuotaPago.NumeroAgencia = NumeroAgencia;
            CreditoCuotaPago.CodigoUsuario = CodigoUsuario;
            
            CreditosCuotasPagos.AddCreditosCuotasPagosRow(CreditoCuotaPago);

            int rowsAffected = Adapter.Update(CreditosCuotasPagos);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarCreditoCuotaPago(int NumeroCredito, int NumeroCuota, decimal MontoPago, string CodigoMedioPago, string NumeroCuentaBanco,
            string DIPersonaPago, string NombreCompletoPersonaPago, int NumeroAgencia, int CodigoUsuario)
        {
            DSDoblones20GestionComercial.CreditosCuotasPagosDataTable CreditosCuotasPagos = Adapter.GetDataBy(NumeroCredito, NumeroCuota);
            if (CreditosCuotasPagos.Count == 0)
                return false;

            DSDoblones20GestionComercial.CreditosCuotasPagosRow CreditoCuotaPago = CreditosCuotasPagos[0];

            CreditoCuotaPago.NumeroCredito = NumeroCredito;
            CreditoCuotaPago.NumeroCuota = NumeroCuota;
            //CreditoCuotaPago.FechaHoraPago = FechaHoraPago;
            CreditoCuotaPago.MontoPago = MontoPago;
            CreditoCuotaPago.CodigoMedioPago = CodigoMedioPago;
            CreditoCuotaPago.NumeroCuentaBanco = NumeroCuentaBanco;
            CreditoCuotaPago.DIPersonaPago = DIPersonaPago;
            CreditoCuotaPago.NombreCompletoPersonaPago = NombreCompletoPersonaPago;
            CreditoCuotaPago.NumeroAgencia = NumeroAgencia;
            CreditoCuotaPago.CodigoUsuario = CodigoUsuario;

            int rowsAffected = Adapter.Update(CreditoCuotaPago);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCreditoCuotaPago(int NumeroCredito, int NumeroCuota)                           	                   	     
        {
            int rowsAffected = Adapter.Delete(NumeroCredito, NumeroCuota);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCreditosCuotasPagos()
        {
            return Adapter.GetData();
        }

        public DataTable ListarCreditosCuotasPagosNumeroCredito(int NumeroCredito)
        {
            return Adapter.GetDataByListarCreditosCuotasPagoNumeroCredito(NumeroCredito);
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerCredito(int NumeroCredito, int NumeroCuota)
        {
            return Adapter.GetDataBy(NumeroCredito, NumeroCuota);
        }

    }
}
