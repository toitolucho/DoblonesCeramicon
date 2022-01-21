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
    public partial class FReporteCompraProductosGastosDetalle : Form
    {
        DataTable DTCompraProductoGastosDetalle;
        DataTable DTCompraProductosMonedaLiteral;
        DataSet DSCompraProductosGastos;
        Button btnCerrarReporte;
        public FReporteCompraProductosGastosDetalle(DataTable DTCompraProductoGastosDetalle, DataTable DTCompraProductosMonedaLiteral)
        {
            InitializeComponent();
            this.DTCompraProductoGastosDetalle = DTCompraProductoGastosDetalle;
            this.DTCompraProductosMonedaLiteral = DTCompraProductosMonedaLiteral;
            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);

            DSCompraProductosGastos = new DataSet();
            DSCompraProductosGastos.Tables.Add(DTCompraProductoGastosDetalle);
            DSCompraProductosGastos.Tables.Add(DTCompraProductosMonedaLiteral);
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteCompraProductosGastosDetalle_Load(object sender, EventArgs e)
        {
            CRComprasProductosGastos _CRComprasProductosGastos = new CRComprasProductosGastos();
            _CRComprasProductosGastos.SetDataSource(DSCompraProductosGastos);
            CRVCompraProductosGastosDetalle.ReportSource = _CRComprasProductosGastos;
            this.CancelButton = btnCerrarReporte;
        }
    }
}
