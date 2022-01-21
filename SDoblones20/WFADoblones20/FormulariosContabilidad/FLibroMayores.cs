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
using WFADoblones20.FormulariosContabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FLibroMayores : Form
    {
        public FLibroMayores()
        {
            InitializeComponent();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            MostrarLibroMayores();
        }

        private void MostrarLibroMayores()
        {
            /*if (cbNumeroCuenta.Items.Contains(cbNumeroCuenta.SelectedItem.ToString()))
            {*/
                FReporteLibroMayores frlm = new FReporteLibroMayores(cbNumeroCuenta.SelectedValue.ToString());
                frlm.ShowDialog();
            /*}
            else
            {
                MessageBox.Show("Cuenta inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbNumeroCuenta.Focus();
                cbNumeroCuenta.SelectAll();
            }*/
        }

        private void FReporteLibroMayores_Load(object sender, EventArgs e)
        {
            PlanCuentasCLN PlanCuentas = new PlanCuentasCLN();
            DataTable DTPlanCuentas = new DataTable();

            DTPlanCuentas = PlanCuentas.ListarPlanCuentasSimple();

            cbNumeroCuenta.DataSource = DTPlanCuentas.DefaultView;
            cbNumeroCuenta.DisplayMember = "NumeroCuenta";
            cbNumeroCuenta.ValueMember = "NumeroCuenta";

            cbNombreCuenta.DataSource = DTPlanCuentas.DefaultView;
            cbNombreCuenta.DisplayMember = "NombreCuenta";
            cbNombreCuenta.ValueMember = "NumeroCuenta";           
        }

        private void cbNumeroCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & e.KeyChar != '-' & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter)
            {
                e.Handled = true;
                cbNumeroCuenta.SelectAll();
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void cbNumeroCuenta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back)
            {
                    int n = cbNumeroCuenta.Text.Length;

                    switch (n)
                    {
                        case 1:
                        case 3:
                        case 6:
                        case 9:
                            cbNumeroCuenta.Text += "-";
                            break;
                    }

                    cbNumeroCuenta.SelectionStart = n + 1;
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
