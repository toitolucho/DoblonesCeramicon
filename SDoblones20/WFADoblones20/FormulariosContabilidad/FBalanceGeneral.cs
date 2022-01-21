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
    public partial class FBalanceGeneral : Form
    {
        public FBalanceGeneral()
        {
            InitializeComponent();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            MostrarBalanceGeneral();
        }

        private void MostrarBalanceGeneral()
        {
            if (dtpFechaInicio.Value<dtpFechaFin.Value)
            {
                BalanceGeneralCLN balance = new BalanceGeneralCLN(dtpFechaInicio.Value.ToString(),dtpFechaFin.Value.ToString());

                if (balance.ListarActivo().Rows.Count > 0 && balance.ListarPasivoCapital().Rows.Count > 0)
                {
                    FReporteBalanceGeneral frbg = new FReporteBalanceGeneral(dtpFechaInicio.Value.ToShortDateString(), dtpFechaFin.Value.ToShortDateString());
                    frbg.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existen transacciones para realizar el Balance General.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fehca final.", "Error en las fechas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaInicio.Focus();
            }
        }


        private void FBalanceGeneral_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Parse("01/01/" + DateTime.Today.Year.ToString());
            dtpFechaFin.Value = DateTime.Parse("31/12/" + DateTime.Today.Year.ToString());
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
