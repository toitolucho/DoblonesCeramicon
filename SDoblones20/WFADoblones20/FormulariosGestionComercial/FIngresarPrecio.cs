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
    public partial class FIngresarPrecio : Form
    {
        decimal _PrecioTotal = 0;
        bool correcto = false;
        public decimal PrecioTotal
        {
            get
            {
                return _PrecioTotal;
            }
        }
        public FIngresarPrecio()
        {
            InitializeComponent();
        }

        public TextBox TxtBoxPrecioTotal
        {
            get
            {
                return txtBoxPrecioTotal;
            }
            set
            {
                txtBoxPrecioTotal = value;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Decimal.TryParse(txtBoxPrecioTotal.Text.Trim(), out _PrecioTotal))
            {
                correcto = true;
                this.Close();
            }
        }

        private void txtBoxPrecioTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(sender, e as EventArgs);
            }
        }

        private void FIngresarPrecio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!correcto)
            {
                MessageBox.Show("Aun no ha ingresado un Precio Total adecuado");
                e.Cancel = true;
            }
        }
    }
}
