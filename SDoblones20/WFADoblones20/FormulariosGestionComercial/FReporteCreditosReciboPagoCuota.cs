using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WFADoblones20.ReportesGestionComercial;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FReporteCreditosReciboPagoCuota : Form
    {
        int NumeroCredito = 0;
        string NombreDeudor = "";
        string Garante1 = "";
        string Garante2 = "";
        string Garante3 = "";
        string Garante4 = "";
        string Garante5 = "";
        string SistemaAmortizacion = "";
        decimal Monto = 0.0m;
        string TipoFrecuenciaPagos = "";
        int NumeroPagos = 0;
        decimal InteresAnual = 0.0m;
        int NumeroCuota = 0;
        DateTime FechaCuota = DateTime.Now;
        string DIDepositante = "";
        string NombreDepositante = "";
        decimal Cuota = 0.0m;
        string NombreMedioPago = "";
        string Moneda = "";
        string Deposito = "";
        int NumeroAgenciaPago = 0;
        int CodigoUsuarioPago = 0;

        public FReporteCreditosReciboPagoCuota(int NumeCred,  int NumeCuot, string DI, string NombComp, decimal Cuot, string Mone, string Depo)
        {
            InitializeComponent();
            this.NumeroCredito = NumeCred;
            this.NumeroCuota = NumeCuot;
            this.DIDepositante = DI;
            this.NombreDepositante = NombComp;
            this.Cuota = Cuot;
            this.Moneda = Mone;
            this.Deposito = Depo;
        }

        public FReporteCreditosReciboPagoCuota(int NumeCred, string NombDeud, string Gar1, string Gar2, string Gar3, string Gar4, string Gar5,
                string SistAmor, decimal Mont, string TipoFrecPago, int NumePago, decimal InteAnua, int NumeCuot, DateTime FechCuot,
                string DIDepo, string NombDepo, decimal Cuot, string NombMediPago, string Mone, string Depo, int NumeAgenPago, int CodiUsuaPago)
        {
            InitializeComponent();
            this.NumeroCredito = NumeCred;
            this.NombreDeudor = NombDeud;
            this.Garante1 = Gar1;
            this.Garante2 = Gar2;
            this.Garante3 = Gar3;
            this.Garante4 = Gar4;
            this.Garante5 = Gar5;
            this.SistemaAmortizacion = SistAmor;
            this.Monto = Mont;
            this.TipoFrecuenciaPagos = TipoFrecPago;
            this.NumeroPagos = NumePago;
            this.InteresAnual = InteAnua;
            this.NumeroCuota = NumeCuot;
            this.FechaCuota = FechCuot;
            this.DIDepositante = DIDepo;
            this.NombreDepositante = NombDepo;
            this.Cuota = Cuot;
            this.NombreMedioPago = NombMediPago;
            this.Moneda = Mone;
            this.Deposito = Depo;
            this.NumeroAgenciaPago = NumeAgenPago;
            this.CodigoUsuarioPago = CodiUsuaPago;
        }

        private void cRVClientes_Load(object sender, EventArgs e)
        {
            CRCreditosReciboPagoCuota ReporteCreditosReciboPagoCuota = new CRCreditosReciboPagoCuota();

            ReporteCreditosReciboPagoCuota.SetParameterValue(0, NumeroCredito);
            ReporteCreditosReciboPagoCuota.SetParameterValue(1, NombreDeudor);
            ReporteCreditosReciboPagoCuota.SetParameterValue(2, Garante1);
            ReporteCreditosReciboPagoCuota.SetParameterValue(3, Garante2);
            ReporteCreditosReciboPagoCuota.SetParameterValue(4, Garante3);
            ReporteCreditosReciboPagoCuota.SetParameterValue(5, Garante4);
            ReporteCreditosReciboPagoCuota.SetParameterValue(6, Garante5);
            ReporteCreditosReciboPagoCuota.SetParameterValue(7, SistemaAmortizacion);
            ReporteCreditosReciboPagoCuota.SetParameterValue(8, Monto);
            ReporteCreditosReciboPagoCuota.SetParameterValue(9, TipoFrecuenciaPagos);
            ReporteCreditosReciboPagoCuota.SetParameterValue(10, NumeroPagos);
            ReporteCreditosReciboPagoCuota.SetParameterValue(11, InteresAnual);
            ReporteCreditosReciboPagoCuota.SetParameterValue(12, NumeroCuota);
            ReporteCreditosReciboPagoCuota.SetParameterValue(13, FechaCuota);
            ReporteCreditosReciboPagoCuota.SetParameterValue(14, DIDepositante);
            ReporteCreditosReciboPagoCuota.SetParameterValue(15, NombreDepositante);
            ReporteCreditosReciboPagoCuota.SetParameterValue(16, Cuota);
            ReporteCreditosReciboPagoCuota.SetParameterValue(17, NombreMedioPago);
            ReporteCreditosReciboPagoCuota.SetParameterValue(18, Moneda);
            ReporteCreditosReciboPagoCuota.SetParameterValue(19, Deposito);
            ReporteCreditosReciboPagoCuota.SetParameterValue(20, NumeroAgenciaPago);
            ReporteCreditosReciboPagoCuota.SetParameterValue(21, CodigoUsuarioPago);

            cRVCreditosReciboPagoCuota.ReportSource = ReporteCreditosReciboPagoCuota;
        }
    }
}

