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
    public partial class FAdministradorDeProductosConfiguracionReporte : Form
    {
        public string TipoSeleccionPrecios = "T"; //T:Todos los Precios, "F":Con Factura, "S":Sin factura
        public FAdministradorDeProductosConfiguracionReporte()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            TipoSeleccionPrecios = rBtntodosLosPrecios.Checked ? "T" : rBtnPreciosConFactura.Checked ? "F" : "S";
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
