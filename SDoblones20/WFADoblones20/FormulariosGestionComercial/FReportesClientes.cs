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
    public partial class FReportesGestionComercialClientes : Form
    {
        private DataTable OrigenReporteClientes = new DataTable();
        Button btnCerrarReporte;

        public FReportesGestionComercialClientes(DataTable Clientes)
        {
            InitializeComponent();
            this.OrigenReporteClientes = Clientes;
            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cRVClientes_Load(object sender, EventArgs e)
        {
            CRClientes ReporteClientes = new CRClientes();

            ReporteClientes.SetDataSource(OrigenReporteClientes);
            cRVClientes.ReportSource = ReporteClientes;


            this.CancelButton = btnCerrarReporte;
        }
    }
}
