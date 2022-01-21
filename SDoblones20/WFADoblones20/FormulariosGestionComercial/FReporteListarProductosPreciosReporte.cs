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
    public partial class FReporteListarProductosPreciosReporte : Form
    {
        DataTable DTListarProductosPreciosReporte;
        Button btnCerrarReporte;
        string TipoSeleccionPrecion = "T";
        public FReporteListarProductosPreciosReporte(DataTable DTListarProductosPreciosReporte, string TipoSeleccionPrecion)
        {
            InitializeComponent();
            this.DTListarProductosPreciosReporte = DTListarProductosPreciosReporte;
            this.TipoSeleccionPrecion = TipoSeleccionPrecion;
            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FListarProductosPreciosReporte_Load(object sender, EventArgs e)
        {
            switch(TipoSeleccionPrecion)
            {
                case "T":
                    CRListarProductosPreciosReporte CRListarProductosPreciosReporte = new CRListarProductosPreciosReporte();
                    CRListarProductosPreciosReporte.SetDataSource(DTListarProductosPreciosReporte);
                    CRVListadoPreciosProductos.ReportSource = CRListarProductosPreciosReporte;
                    break;
                case "F":
                    CRListarProductosPreciosReporteConFactura CRListarProductosPreciosReporte2 = new CRListarProductosPreciosReporteConFactura();
                    CRListarProductosPreciosReporte2.SetDataSource(DTListarProductosPreciosReporte);
                    CRVListadoPreciosProductos.ReportSource = CRListarProductosPreciosReporte2;
                    break;
                case "S":
                    CRListarProductosPreciosReporteSinFactura CRListarProductosPreciosReporte3 = new CRListarProductosPreciosReporteSinFactura();
                    CRListarProductosPreciosReporte3.SetDataSource(DTListarProductosPreciosReporte);
                    CRVListadoPreciosProductos.ReportSource = CRListarProductosPreciosReporte3;
                    break;
            }
            

            this.CancelButton = btnCerrarReporte;
        }
    }
}
