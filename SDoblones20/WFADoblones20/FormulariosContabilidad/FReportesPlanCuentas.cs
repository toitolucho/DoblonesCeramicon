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
    public partial class FReportesPlanCuentas : Form
    {
        public FReportesPlanCuentas()
        {
            InitializeComponent();
        }

        private void FReportesPlanCuentas_Load(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void CargarReporte()
        {
            PlanCuentasCLN cuentas = new PlanCuentasCLN();
            DataTable dt = new DataTable();
            CRPlanCuentas crcuentas = new CRPlanCuentas();

            dt = cuentas.ListarPlanCuentas();

            crcuentas.SetDataSource(dt);

            crvPlanCuentas.ReportSource = crcuentas;
        }
    }
}
