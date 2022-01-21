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
    public partial class FReporteVentaProductoReemplazo : Form
    {
        private DataTable DTReemplazo = null;
        private DataTable DTProductosReemplazo = null;
        private DataTable DTProductosEspecificosReemplazo = null;
        private DataSet DSReemplazos = null;
        Button btnCerrarReporte;

        public FReporteVentaProductoReemplazo(DataTable DTReemplazo, DataTable DTProductosReemplazo, DataTable DTProductosEspecificosReemplazo)
        {
            InitializeComponent();
            this.DTReemplazo = DTReemplazo;
            this.DTProductosReemplazo = DTProductosReemplazo;
            this.DTProductosEspecificosReemplazo = DTProductosEspecificosReemplazo;


            this.DTReemplazo.TableName = "VentasProductosReemplazoReporte";
            this.DTProductosReemplazo.TableName = "VentasProductosReemplazoDetalleReporte";
            this.DTProductosEspecificosReemplazo.TableName = "VentasProductosReemplazoEspecificosReporte";

            DSReemplazos = new DataSet();
            DSReemplazos.Tables.AddRange(new DataTable[] { DTReemplazo, DTProductosReemplazo, DTProductosEspecificosReemplazo });

            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteVentaProductoReemplazo_Load(object sender, EventArgs e)
        {
            ReportesGestionComercial.CRVentasReemplazo reporteReemplazo = new WFADoblones20.ReportesGestionComercial.CRVentasReemplazo();
            reporteReemplazo.SetDataSource(DSReemplazos);

            CRVVentasProductosReemplazo.ReportSource = reporteReemplazo;
        }
    }
}
