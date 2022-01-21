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
    public partial class FReporteTransferenciaProductosDetalleRecepcionEnvioGeneral : Form
    {
        DataTable DTTransferenciasProductos;
        DataTable DTListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte;
        DataSet DSTransferenciasResumenGeneral;
        Button btnCerrarReporte;
        public FReporteTransferenciaProductosDetalleRecepcionEnvioGeneral(DataTable DTTransferenciasProductos, DataTable DTListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte)
        {
            InitializeComponent();

            this.DTTransferenciasProductos = DTTransferenciasProductos;
            this.DTListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte = DTListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte;

            DTListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte.Columns["CodigoTipoEnvioRecepcion"].ReadOnly = false;
            DTListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte.Columns["CodigoTipoEnvioRecepcion"].MaxLength = 300;
            foreach (DataRow DRProducto in DTListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte.Rows)
            {
                DRProducto["CodigoTipoEnvioRecepcion"] = DRProducto["CodigoTipoEnvioRecepcion"].Equals("R") ? "RECEPCION MERCADERIA" : "ENVIO DE MERCADERIA";
            }

            DSTransferenciasResumenGeneral = new DataSet();
            DSTransferenciasResumenGeneral.Tables.AddRange(new DataTable[]{this.DTTransferenciasProductos, this.DTListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte});

            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteTransferenciaProductosDetalleRecepcionEnvioGeneral_Load(object sender, EventArgs e)
        {
            CRTransferenciasProductosRecepcionEnvioGeneral _CRTransferenciasProductosRecepcionEnvioGeneral = new CRTransferenciasProductosRecepcionEnvioGeneral();
            _CRTransferenciasProductosRecepcionEnvioGeneral.SetDataSource(DSTransferenciasResumenGeneral);
            CRVTransferenciaProductosDetalleRecepcionEnvioGeneral.ReportSource = _CRTransferenciasProductosRecepcionEnvioGeneral;
        }
    }
}
