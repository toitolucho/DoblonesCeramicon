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
    public partial class FReporteVentaProductosDevolucioneReemplazo : Form
    {
        DataTable DTVentasProductosReemDevo = null;
        DataTable DTVentasProductosReemDevoDetalle = null;
        DataSet DSVentasProductosReemDevo = null;
        Button btnCerrarReporte;

        public FReporteVentaProductosDevolucioneReemplazo(DataTable DTVentasReemDevo, DataTable DTVentasReemDevoDetalle)
        {
            InitializeComponent();
            this.DTVentasProductosReemDevo = DTVentasReemDevo;
            this.DTVentasProductosReemDevoDetalle = DTVentasReemDevoDetalle;

            this.DTVentasProductosReemDevo.TableName = "VentasProductosReemplazoDevolucionReporte";
            this.DTVentasProductosReemDevoDetalle.TableName = "VentasProductosDevolucionesReemplazoReporte";

            this.DSVentasProductosReemDevo = new DataSet();

            this.DSVentasProductosReemDevo.Tables.AddRange(new DataTable[]{this.DTVentasProductosReemDevo, this.DTVentasProductosReemDevoDetalle});

            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteVentaProductosDevolucioneReemplazo_Load(object sender, EventArgs e)
        {
            ReportesGestionComercial.CRVentasDevolucionesReemplazo2 reporteReemDevo = new WFADoblones20.ReportesGestionComercial.CRVentasDevolucionesReemplazo2();
            reporteReemDevo.SetDataSource(DSVentasProductosReemDevo);

            CRVVentasProductosReemDevo.ReportSource = reporteReemDevo;
        }
    }
}
