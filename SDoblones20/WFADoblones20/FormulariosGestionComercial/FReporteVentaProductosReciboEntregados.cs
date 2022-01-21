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
    public partial class FReporteVentaProductosReciboEntregados : Form
    {
        DataTable DTProductosEntregados;
        string TipoReporte;
        Button btnCerrarReporte;
        public FReporteVentaProductosReciboEntregados(DataTable DTProductosEntregados, string TipoReporte)
        {
            this.DTProductosEntregados = DTProductosEntregados;
            this.TipoReporte = TipoReporte;
            InitializeComponent();

            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteVentaProductosReciboEntregados_Load(object sender, EventArgs e)
        {
            switch (TipoReporte)
            {
                case "CSPE": //Completa sin ProductosEspecicos
                    ReportesGestionComercial.CRVentasProductosAlmacenesConformidad reporteEntregados = new WFADoblones20.ReportesGestionComercial.CRVentasProductosAlmacenesConformidad();
                    reporteEntregados.SetDataSource(DTProductosEntregados);
                    CRVProductosEntregados.ReportSource = reporteEntregados;
                    break;
                case "ISPE":// Incompleta Por Partes Sin Productos Especificos
                    ReportesGestionComercial.CREntregaProductosPorPartes reportePorPartes = new WFADoblones20.ReportesGestionComercial.CREntregaProductosPorPartes();
                    reportePorPartes.SetDataSource(DTProductosEntregados);
                    CRVProductosEntregados.ReportSource = reportePorPartes;
                    break;
                case "CCPE":// Completa incluyendo Productos Especificos
                    ReportesGestionComercial.CREntregaProductosConEspecificosCompleta reporteCompletoConEspecificos = new WFADoblones20.ReportesGestionComercial.CREntregaProductosConEspecificosCompleta();
                    reporteCompletoConEspecificos.SetDataSource(DTProductosEntregados);
                    CRVProductosEntregados.ReportSource = reporteCompletoConEspecificos;
                    break;
                case "ICPE": //Incompleta Por Partes con Productos Especificos
                    ReportesGestionComercial.CREntregaProductosConEspecificosPorPartes reportePorPartesConEspecificos = new WFADoblones20.ReportesGestionComercial.CREntregaProductosConEspecificosPorPartes();
                    reportePorPartesConEspecificos.SetDataSource(DTProductosEntregados);
                    CRVProductosEntregados.ReportSource = reportePorPartesConEspecificos;
                    break;
                default:
                    break;
            }            
        }
    }
}
