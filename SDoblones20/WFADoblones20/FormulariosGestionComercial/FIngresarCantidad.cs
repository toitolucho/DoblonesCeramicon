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
    public partial class FIngresarCantidad : Form
    {
        public int Cantidad { get; set; }
        public bool OperacionConfirmada { get; set; }
        public FIngresarCantidad()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int CantidadIngreso = -1;
            if (int.TryParse(txtCantidad.Text.Trim(), out CantidadIngreso))
            {
                if (CantidadIngreso <= 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtCantidad, "No puede confirmar la operación debido a que el número no es valido");
                    txtCantidad.Focus();
                    txtCantidad.SelectAll();
                    return;

                }
                Cantidad = CantidadIngreso;
                OperacionConfirmada = true;
            }
            else
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCantidad, "No puede confirmar la operación debido a que el número no es valido");
                txtCantidad.Focus();
                txtCantidad.SelectAll();
                OperacionConfirmada = false;
                return;
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OperacionConfirmada = false;
            this.Close();
        }

        private void FIngresarCantidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OperacionConfirmada && MessageBox.Show(this, "¿Se encuentra seguro de Cancelar la operación?", "Cantidad No ingresada", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void txtBoxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAceptar_Click(sender, e as EventArgs);
            }
            if (!Char.IsNumber(e.KeyChar) && (((Keys)e.KeyChar)) != Keys.Back )
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void FIngresarCantidad_Shown(object sender, EventArgs e)
        {
            OperacionConfirmada = false;
            txtCantidad.Text = Cantidad.ToString();
            txtCantidad.SelectAll();
        }


    }
}
