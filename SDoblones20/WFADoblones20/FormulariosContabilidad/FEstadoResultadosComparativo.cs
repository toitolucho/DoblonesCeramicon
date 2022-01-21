using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FEstadoResultadosComparativo : Form
    {
        public FEstadoResultadosComparativo()
        {
            InitializeComponent();
        }

        private void btMostrar_Click(object sender, EventArgs e)
        {
            MostrarEstadoResultados();
        }

        private void MostrarEstadoResultados()
        {
            if (dtpPrimeraFechaInicio.Value >= dtpPrimeraFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor o igual a la fecha de cierre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpPrimeraFechaInicio.Focus();
            }
            else if (dtpSegundaFechaInicio.Value >= dtpSegundaFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor o igual a la fecha de cierre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpSegundaFechaInicio.Focus();
            }
            else
            {
                FReporteEstadoResultados frbg = new FReporteEstadoResultados(dtpPrimeraFechaInicio.Value.ToShortDateString(), dtpPrimeraFechaFin.Value.ToShortDateString(),
                                                                        dtpSegundaFechaInicio.Value.ToShortDateString(), dtpSegundaFechaFin.Value.ToShortDateString());
                frbg.ShowDialog();
            }
        }

        private void FEstadoResultadosComparativo_Load(object sender, EventArgs e)
        {
            dtpPrimeraFechaInicio.Value = DateTime.Parse("01/01/" + DateTime.Today.Year.ToString());
            dtpPrimeraFechaFin.Value = DateTime.Parse("31/12/" + DateTime.Today.Year.ToString());
            dtpSegundaFechaInicio.Value = DateTime.Parse("01/01/" + DateTime.Today.Year.ToString());
            dtpSegundaFechaFin.Value = DateTime.Parse("31/12/" + DateTime.Today.Year.ToString());
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
