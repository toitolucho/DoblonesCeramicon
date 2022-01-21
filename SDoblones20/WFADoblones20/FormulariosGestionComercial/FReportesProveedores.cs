using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WFADoblones20.ReportesGestionComercial;
using CLCLN.GestionComercial;

namespace WFADoblones20
{
    public partial class FReportesGestionComercialProveedores : Form
    {
        private DataTable OrigenReporteProveedores = new DataTable();
        Button btnCerrarReporte;

        public FReportesGestionComercialProveedores(DataTable Proveedores)
        {
            InitializeComponent();
            this.OrigenReporteProveedores = Proveedores;

            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReportesGestionComercialProveedores_Load(object sender, EventArgs e)
        {
            CRProveedores ReporteProveedores = new CRProveedores();

            ReporteProveedores.SetDataSource(OrigenReporteProveedores);            
            cRVProveedores.ReportSource = ReporteProveedores;
        }
    }
}
