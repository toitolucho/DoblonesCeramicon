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
    public partial class FReporteInventarioGeneral : Form
    {
        DataTable DTInventarioProductos = null;
        Button btnCerrarReporte;
        public FReporteInventarioGeneral(DataTable _DTInventarioProductos)
        {            
            InitializeComponent();
            this.DTInventarioProductos = _DTInventarioProductos;
            this.DTInventarioProductos.TableName = "InventarioGeneral";

            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteInventarioGeneral_Load(object sender, EventArgs e)
        {
            ReportesGestionComercial.CRInventarioGeneral crInventarioGeneral = new WFADoblones20.ReportesGestionComercial.CRInventarioGeneral();
            crInventarioGeneral.SetDataSource(DTInventarioProductos);
            CRVInventarioGeneral.ReportSource = crInventarioGeneral;

            this.CancelButton = btnCerrarReporte;
        }
    }
}
