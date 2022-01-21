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
    public partial class FListarProductosRequeridosVentasNoCompletadas : Form
    {
        DataTable DTProductosRequeridos;
        public FListarProductosRequeridosVentasNoCompletadas(DataTable DTProductosRequeridos)
        {
            InitializeComponent();
            this.DTProductosRequeridos = DTProductosRequeridos;
        }

        private void FListarProductosRequeridosVentasNoCompletadas_Load(object sender, EventArgs e)
        {
            CRListarProductosRequeridosVentasNoCompletadas _CRListarProductosRequeridosVentasNoCompletadas = new CRListarProductosRequeridosVentasNoCompletadas();
            _CRListarProductosRequeridosVentasNoCompletadas.SetDataSource(DTProductosRequeridos);
            CRVProductosRequeridos.ReportSource = _CRListarProductosRequeridosVentasNoCompletadas;
        }
    }
}
