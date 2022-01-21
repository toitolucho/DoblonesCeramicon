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
    public partial class FReporteCreditosPagosRealizados : Form
    {
        private DataTable OrigenReporteCreditoPagosRealizados = new DataTable();
        int NumeroCredito = 0;
        string NombreCompleto = "";
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


        public FReporteCreditosPagosRealizados(DataTable CreditoPagosRealizados, int NumeCred, string NombComp, string Gar1, string Gar2, string Gar3, 
            string Gar4, string Gar5, string SistAmor, decimal Mont, string TipoFrecPago, int NumePago, decimal InteAnua)
        {
            InitializeComponent();
            this.OrigenReporteCreditoPagosRealizados = CreditoPagosRealizados;
            NumeroCredito = NumeCred;
            NombreCompleto = NombComp;
            Garante1 = Gar1;
            Garante2 = Gar2;
            Garante3 = Gar3;
            Garante4 = Gar4;
            Garante5 = Gar5;
            SistemaAmortizacion = SistAmor;
            Monto = Mont;
            TipoFrecuenciaPagos = TipoFrecPago;
            NumeroPagos = NumePago;
            InteresAnual = InteAnua;
        }


        private void cRVClientes_Load(object sender, EventArgs e)
        {
            CRCreditosPagosRealizados ReporteCreditosPagosRealizados = new CRCreditosPagosRealizados();

            ReporteCreditosPagosRealizados.SetDataSource(OrigenReporteCreditoPagosRealizados);

            ReporteCreditosPagosRealizados.SetParameterValue(0, NumeroCredito);
            ReporteCreditosPagosRealizados.SetParameterValue(1, NombreCompleto);
            ReporteCreditosPagosRealizados.SetParameterValue(2, Garante1);
            ReporteCreditosPagosRealizados.SetParameterValue(3, Garante2);
            ReporteCreditosPagosRealizados.SetParameterValue(4, Garante3);
            ReporteCreditosPagosRealizados.SetParameterValue(5, Garante4);
            ReporteCreditosPagosRealizados.SetParameterValue(6, Garante5);
            ReporteCreditosPagosRealizados.SetParameterValue(7, SistemaAmortizacion);
            ReporteCreditosPagosRealizados.SetParameterValue(8, Monto);
            ReporteCreditosPagosRealizados.SetParameterValue(9, TipoFrecuenciaPagos);
            ReporteCreditosPagosRealizados.SetParameterValue(10, NumeroPagos);
            ReporteCreditosPagosRealizados.SetParameterValue(11, InteresAnual);

            cRVCreditosPagosRealizados.ReportSource = ReporteCreditosPagosRealizados;
        }
    }
}
