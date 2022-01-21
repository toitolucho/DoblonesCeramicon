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
    public partial class FLibroDiario : Form
    {
        public FLibroDiario()
        {
            InitializeComponent();
        }

        public void MostrarLibroDiario()
        {
            if (rbFecha.Checked)
            {
                AsientosCLN asientos = new AsientosCLN();

                if (asientos.ExisteFecha(dtpFecha.Value.ToShortDateString()))
                {
                    FReporteLibroDiario frld = new FReporteLibroDiario(dtpFecha.Value.ToShortDateString(), 'C');
                    frld.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existe ningún asiento registrado en esa fecha.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpFecha.Focus();
                }
            }
            else
            {
                if (dtpDel.Value < dtpAl.Value)
                {
                    FReporteLibroDiario frld = new FReporteLibroDiario(dtpDel.Value.ToShortDateString(), dtpAl.Value.ToShortDateString());
                    frld.ShowDialog();

                }
                else
                {
                    MessageBox.Show("La fecha inicial no puede ser mayor a la fehca final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpDel.Focus();
                }
            }
        }

        private void FLibroDiario_Load(object sender, EventArgs e)
        {            
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            MostrarLibroDiario();
        }

        private void rbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFecha.Checked)
            {
                dtpFecha.Enabled = true;
                dtpAl.Enabled = false;
                dtpDel.Enabled = false;
            }
            else
            {
                dtpAl.Enabled = true;
                dtpDel.Enabled = true;
                dtpFecha.Enabled = false;
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
