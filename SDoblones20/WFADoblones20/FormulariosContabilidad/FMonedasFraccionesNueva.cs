using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Contabilidad;
using CLCLN.Sistema;
using WFADoblones20.FormulariosContabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FMonedasFraccionesNueva : Form
    {
        string CodigoMoneda, CodigoMonedaFracc, Valor;

        public FMonedasFraccionesNueva(string CodMon, string CodMonFracc, string Val)
        {
            InitializeComponent();

            CodigoMoneda = CodMon;
            CodigoMonedaFracc = CodMonFracc;
            Valor = Val;

            tbValor.Text = Valor;
            btAceptar.Text = "Modificar";
        }

        public FMonedasFraccionesNueva(string CodMon)
        {
            InitializeComponent();

            CodigoMoneda = CodMon;
        }

        private void tbValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & e.KeyChar != ',' & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
            else if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (tbValor.Text.Contains(e.KeyChar))
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                }
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (tbValor.Text != string.Empty)
            {
                decimal d;
                if (decimal.TryParse(tbValor.Text, out d))
                {
                    if (MessageBox.Show("¿Desea continuar con el registro?", "Registrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MonedasFraccionesCLN mf = new MonedasFraccionesCLN();

                        if (!mf.Existe(CodigoMoneda, tbValor.Text))
                        {
                            if (btAceptar.Text == "Aceptar")
                            {
                                mf.Insertar(CodigoMoneda, tbValor.Text);
                                MessageBox.Show("Registro completado exitosamente", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                mf.Actualizar(CodigoMonedaFracc, tbValor.Text);
                                MessageBox.Show("Actualización completada exitosamente", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("El valor introducido ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tbValor.Focus();
                            tbValor.SelectAll();
                        }
                    }
                    else
                    {                        
                        tbValor.Focus();
                        tbValor.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show("Debe introducir un valor válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbValor.Focus();
                    tbValor.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Debe introducir un valor válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbValor.Focus();
                tbValor.SelectAll();
            }
        }

        private void tbValor_Leave(object sender, EventArgs e)
        {
            decimal valor;
            if (decimal.TryParse(tbValor.Text, out valor))
            {
                tbValor.Text = valor.ToString("F2");
            }
            else
            {
                MessageBox.Show("Valor inválido", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbValor.Focus();
                tbValor.SelectAll();
            }
        }


    }
}
