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
    public partial class FReporteVentaProductosEntregaHistorial : Form
    {
        DataTable DTDatosVenta;
        DataTable DTVentaProductosEntregadosHistorial;
        DataSet DSEntregaProductosHistorial;
        bool ConEspecificos = false;
        Button btnCerrarReporte;
        public FReporteVentaProductosEntregaHistorial(DataTable DTDatosVenta, DataTable DTVentaProductosEntregadosHistorial, bool ConEspecificos)
        {
            InitializeComponent();
            this.DTDatosVenta = DTDatosVenta;
            this.DTVentaProductosEntregadosHistorial = DTVentaProductosEntregadosHistorial;
            this.ConEspecificos = ConEspecificos;

            DSEntregaProductosHistorial = new DataSet();
            DSEntregaProductosHistorial.Tables.Add(DTDatosVenta);
            DSEntregaProductosHistorial.Tables.Add(DTVentaProductosEntregadosHistorial);

            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteVentaProductosEntregaHistorial_Load(object sender, EventArgs e)
        {
            if (ConEspecificos)
            {
                CRVentaProductosEspeciificosEntregaAlmacenesHistorial ReporteHistorialProductosEspecificos = new CRVentaProductosEspeciificosEntregaAlmacenesHistorial();
                ReporteHistorialProductosEspecificos.SetDataSource(DSEntregaProductosHistorial);
                this.CRVHistorialProductosEntregados.ReportSource = ReporteHistorialProductosEspecificos;
            }
            else
            {
                CRVentaProductosEntregaAlmacenesHistorial ReporteHistorialProductos = new CRVentaProductosEntregaAlmacenesHistorial();
                ReporteHistorialProductos.SetDataSource(DSEntregaProductosHistorial);
                this.CRVHistorialProductosEntregados.ReportSource = ReporteHistorialProductos;
            }
        }
    }
}
