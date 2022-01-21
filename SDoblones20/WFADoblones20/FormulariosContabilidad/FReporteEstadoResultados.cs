using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Contabilidad;
using WFADoblones20.ReportesContabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FReporteEstadoResultados : Form
    {
        private string FechaDel, FechaAl;

        public FReporteEstadoResultados(string fechaDel, string fechaAl)
        {
            InitializeComponent();
            FechaDel = fechaDel;
            FechaAl = fechaAl;
            CargarReporte();
        }

        public FReporteEstadoResultados(string PrimeraFechaDel, string PrimeraFechaAl, string SegundaFechaDel, string SegundaFechaAl)
        {
            InitializeComponent();
            FechaDel = PrimeraFechaDel;
            FechaAl = PrimeraFechaAl;
            CargarReporte(SegundaFechaDel, SegundaFechaAl);
            this.Text += " comparativo";
        }

        private void FReporteEstadoResultados_Load(object sender, EventArgs e)
        {

        }

        private void CargarReporte()
        {
            EstadoResultadosCLN BalanceGeneral = new EstadoResultadosCLN(FechaDel, FechaAl);

            CREstadoResultados crer = new CREstadoResultados();
            crer.Subreports[0].SetDataSource(BalanceGeneral.ListarIngresos());
            crer.Subreports[1].SetDataSource(BalanceGeneral.ListarEgresos());
            crer.Subreports[2].SetDataSource(BalanceGeneral.ListarEstadoResultadosDiferencias());

            crvEstadoResultados.ReportSource = crer;
        }

        private void CargarReporte(string SegundaFechaIni, string SegundaFechaFin)
        {
            EstadoResultadosCLN BalanceGeneral = new EstadoResultadosCLN(FechaDel, FechaAl);

            CREstadoResultadosComparativo crer = new CREstadoResultadosComparativo();
            crer.Subreports[0].SetDataSource(BalanceGeneral.ListarIngresos(FechaDel, FechaAl));
            crer.Subreports[1].SetDataSource(BalanceGeneral.ListarEgresos(FechaDel,FechaAl));
            crer.Subreports[2].SetDataSource(BalanceGeneral.ListarEstadoResultadosComparativoDiferencias());

            crvEstadoResultados.ReportSource = crer;
        }

    }
}
