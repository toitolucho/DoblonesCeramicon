using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FReporteProductosRequeridos : Form
    {
        DataTable DTProductosRequeridos;
        Button btnCerrarReporte;
        public FReporteProductosRequeridos(DataTable DTProductosRequeridos)
        {
            InitializeComponent();
            this.DTProductosRequeridos = DTProductosRequeridos;
            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteProductosRequeridos_Load(object sender, EventArgs e)
        {
            ReportesGestionComercial.CRProductosRequeridos reporteProductosRequeridos = new WFADoblones20.ReportesGestionComercial.CRProductosRequeridos();
            reporteProductosRequeridos.SetDataSource(DTProductosRequeridos);
            CRVProductosRequeridos.ReportSource = reporteProductosRequeridos;

            this.CancelButton = btnCerrarReporte;
        }
    }
}
