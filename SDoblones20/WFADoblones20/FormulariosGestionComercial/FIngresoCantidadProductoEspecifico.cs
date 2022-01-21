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
    public partial class FIngresoCantidadProductoEspecifico : Form
    {
        int cantidad = -1;
        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
        }
        public FIngresoCantidadProductoEspecifico()
        {
            InitializeComponent();
            txtBoxCantidad.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(txtBoxCantidad.Text.Trim(), out cantidad))
            {
                if (cantidad <= 363)
                    this.Close();
                else
                {
                    MessageBox.Show(this, "Por Favor Ingrese un Valur númerico menor a 363", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtBoxCantidad.Focus();
                    this.txtBoxCantidad.SelectAll();
                }
            }
            else
            {
                MessageBox.Show(this, "Por Favor Ingrese un Valur númerico y Corrija sus datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtBoxCantidad.Focus();
                this.txtBoxCantidad.SelectAll();
            }
        }

        private void txtBoxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e as EventArgs);
            }
            if(!Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void FIngresoCantidadProductoEspecifico_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cantidad == -1 || cantidad >= 363)
            {
                MessageBox.Show(this, "Por Favor ingrese una cantidad Valida", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtBoxCantidad.Focus();
                this.txtBoxCantidad.SelectAll();
                e.Cancel = true;
            }
        }
    }
}
