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
    public partial class FReportesVentasProductosPorClientes : Form
    {
        DataTable DTVentasproductosPorClientes;
        Button btnCerrarReporte;
        public FReportesVentasProductosPorClientes(DataTable DTVentasproductosPorClientes)
        {
            InitializeComponent();
            this.DTVentasproductosPorClientes = DTVentasproductosPorClientes;
            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReportesVentasProductosPorClientes_Load(object sender, EventArgs e)
        {
            CRVentasProductosPorClientes rptVentasProductosClientes = new CRVentasProductosPorClientes();
            rptVentasProductosClientes.SetDataSource(DTVentasproductosPorClientes);
            CRVVentasProductosPorCliente.ReportSource = rptVentasProductosClientes;
        }
    }
}
