using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN;
using CLCLN.Contabilidad;
using WFADoblones20.FormulariosContabilidad;
using WFADoblones20.ReportesContabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FReporteBalanceGeneral : Form
    {
        private string FechaInicial, FechaFinal;

        public FReporteBalanceGeneral(string fechaIni, string fechaFin)
        {
            InitializeComponent();
            this.FechaInicial = fechaIni;
            this.FechaFinal = fechaFin;
            CargarReporte();
        }

        public FReporteBalanceGeneral(string PrimeraFechaIni, string PrimeraFechaFin, string SegundaFechaIni, string SegundaFechaFin)
        {
            InitializeComponent();
            this.FechaInicial = PrimeraFechaIni;
            this.FechaFinal = PrimeraFechaFin;
            CargarReporte(SegundaFechaIni, SegundaFechaFin);
            this.Text += " comparativo";
        }

        private void FReporteBalanceGeneral_Load(object sender, EventArgs e)
        {
            
        }

        private void CargarReporte()
        {
            BalanceGeneralCLN BalanceGeneral = new BalanceGeneralCLN(FechaInicial, FechaFinal);
            CRBalanceGeneral crbg = new CRBalanceGeneral();
            DataTable dt = new DataTable();

            dt = BalanceGeneral.ListarActivo();
            crbg.Subreports[0].SetDataSource(dt);

            dt = new DataTable();
            dt = BalanceGeneral.ListarPasivoCapital();
            crbg.Subreports[1].SetDataSource(dt);

            crvBalanceGeneral.ReportSource = crbg;

        }

        private void CargarReporte(string SegundaFechaInicial, string SegundaFechaFinal)
        {
            BalanceGeneralCLN BalanceGeneral = new BalanceGeneralCLN(FechaInicial, FechaFinal);
            CRBalanceGeneralComparativo crbg = new CRBalanceGeneralComparativo();
            DataTable dt = new DataTable();

            dt = BalanceGeneral.ListarActivo(SegundaFechaInicial, SegundaFechaFinal);
            crbg.Subreports[0].SetDataSource(dt);

            dt = new DataTable();
            dt = BalanceGeneral.ListarPasivoCapital(SegundaFechaInicial, SegundaFechaFinal);
            crbg.Subreports[1].SetDataSource(dt);

            crvBalanceGeneral.ReportSource = crbg;

        }

    }
}
