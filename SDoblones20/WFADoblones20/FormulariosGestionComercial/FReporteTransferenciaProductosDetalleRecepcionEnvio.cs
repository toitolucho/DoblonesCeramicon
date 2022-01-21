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
    public partial class FReporteTransferenciaProductosDetalleRecepcionEnvio : Form
    {
        DataTable DTListarTransferenciaProductosDetalleRecepcionEnvioReporte = null;
        DataTable DTListarTransferenciaProductosReporte = null;
        DataTable DTListarTransferenciaProductosEspecificosReporte = null;
        DataSet DSTransferencias;
        Button btnCerrarReporte;
        public FReporteTransferenciaProductosDetalleRecepcionEnvio(DataTable DTListarTransferenciaProductosDetalleRecepcionEnvioReporte,
        DataTable DTListarTransferenciaProductosReporte, DataTable DTListarTransferenciaProductosEspecificosReporte)
        {
            InitializeComponent();
            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);

            this.DTListarTransferenciaProductosDetalleRecepcionEnvioReporte = DTListarTransferenciaProductosDetalleRecepcionEnvioReporte;
            this.DTListarTransferenciaProductosReporte = DTListarTransferenciaProductosReporte;
            this.DTListarTransferenciaProductosEspecificosReporte = DTListarTransferenciaProductosEspecificosReporte;


            DSTransferencias = new DataSet();
            DSTransferencias.Tables.Add(DTListarTransferenciaProductosDetalleRecepcionEnvioReporte);
            DSTransferencias.Tables.Add(DTListarTransferenciaProductosReporte);
            DSTransferencias.Tables.Add(DTListarTransferenciaProductosEspecificosReporte);            
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteTransferenciaProductosDetalleRecepcionEnvio_Load(object sender, EventArgs e)
        {
            CRTransferenciasProductosRecepcionEnvioFechas reporte = new CRTransferenciasProductosRecepcionEnvioFechas();
            reporte.SetDataSource(DSTransferencias);
            CRVTransferenciaProductosDetalleRecepcionEnvio.ReportSource = reporte;

            this.CancelButton = btnCerrarReporte;
        }
    }
}
