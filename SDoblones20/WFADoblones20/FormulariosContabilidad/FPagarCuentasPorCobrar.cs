using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN;
using CLCLN.Contabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FPagarCuentasPorCobrar : Form
    {
        private int NumCobro;
        private int NumeroCtaPorCobrar;
        private int CodUsuario;

        public FPagarCuentasPorCobrar(int NumeroCuentaPorCobrar, int CodigoUsuario, string Moneda)
        {
            InitializeComponent();

            this.NumeroCtaPorCobrar = NumeroCuentaPorCobrar;
            this.CodUsuario = CodigoUsuario;
            this.lbMoneda.Text = Moneda;
        }

        public FPagarCuentasPorCobrar(int NumeroCobro, int CodigoUsuario, string Moneda, string Monto)
        {
            InitializeComponent();

            this.NumCobro = NumeroCobro;
            this.CodUsuario = CodigoUsuario;
            this.lbMoneda.Text = Moneda;
            this.tbMonto.Text = Monto;
            this.btAceptar.Text = "Modificar";
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter)
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void FPagarCuentasPorCobrar_Load(object sender, EventArgs e)
        {

        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (tbMonto.Text != string.Empty)
            {
                decimal Monto;
                if (decimal.TryParse(tbMonto.Text, out Monto))
                {
                    CuentasPorCobrarCobrosCLN detalle = new CuentasPorCobrarCobrosCLN();
                    if (btAceptar.Text == "Modificar")
                    {
                        detalle.ActualizarCuentaPorCobrarCobros(NumCobro, Monto, CodUsuario);
                    }
                    else
                    {
                        detalle.InsertarCuentaPorCobrarCobro(NumeroCtaPorCobrar, Monto, CodUsuario);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El Monto tiene un formato erróneo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbMonto.Focus();
                    tbMonto.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Debe introducir un valor para el Monto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbMonto.Focus();
            }
        }
    }
}
