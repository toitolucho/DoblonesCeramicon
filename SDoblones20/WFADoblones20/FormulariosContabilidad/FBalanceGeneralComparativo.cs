using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Contabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FBalanceGeneralComparativo : Form
    {
        public FBalanceGeneralComparativo()
        {
            InitializeComponent();
        }

        private void FBalanceGeneralComparativo_Load(object sender, EventArgs e)
        {
            dtpPrimeraFechaInicio.Value = DateTime.Parse("01/01/" + DateTime.Today.Year.ToString());
            dtpPrimeraFechaFin.Value = DateTime.Parse("31/12/" + DateTime.Today.Year.ToString());
            dtpSegundaFechaInicio.Value = DateTime.Parse("01/01/" + DateTime.Today.Year.ToString());
            dtpSegundaFechaFin.Value = DateTime.Parse("31/12/" + DateTime.Today.Year.ToString());
        }

        private void btMostrar_Click(object sender, EventArgs e)
        {
            MostrarBalane();
        }

        private void MostrarBalane()        
        {
            if (dtpPrimeraFechaInicio.Value >= dtpPrimeraFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor o igual a la fecha de cierre.","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                dtpPrimeraFechaInicio.Focus();
            }
            else if (dtpSegundaFechaInicio.Value >= dtpSegundaFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor o igual a la fecha de cierre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpSegundaFechaInicio.Focus();
            }
            else
            {
                BalanceGeneralCLN balance = new BalanceGeneralCLN(dtpPrimeraFechaInicio.Value.ToString(), dtpPrimeraFechaFin.Value.ToString());

                if (balance.ListarActivo(dtpSegundaFechaInicio.Value.ToString(), dtpSegundaFechaFin.Value.ToString()).Rows.Count > 0 && balance.ListarPasivoCapital(dtpSegundaFechaInicio.Value.ToString(), dtpSegundaFechaFin.Value.ToString()).Rows.Count > 0)
                {
                    FReporteBalanceGeneral frbg = new FReporteBalanceGeneral(dtpPrimeraFechaInicio.Value.ToShortDateString(), dtpPrimeraFechaFin.Value.ToShortDateString(),
                                                                            dtpSegundaFechaInicio.Value.ToShortDateString(), dtpSegundaFechaFin.Value.ToShortDateString());
                    frbg.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existen transacciones para realizar el Balance General.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btCancelarç_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
