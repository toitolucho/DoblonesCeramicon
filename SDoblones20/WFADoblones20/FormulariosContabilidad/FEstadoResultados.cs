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
    public partial class FEstadoResultados : Form
    {
        public FEstadoResultados()
        {
            InitializeComponent();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            MostrarEstadoResultados();
        }

        private void MostrarEstadoResultados()
        {
            FReporteEstadoResultados frer;


            if (dtpFechaDel.Value <= dtpFechaAl.Value)
            {
                frer = new FReporteEstadoResultados(dtpFechaDel.Value.ToShortDateString(), dtpFechaAl.Value.ToShortDateString());
                        frer.ShowDialog();                    
            }
            else
            {
                MessageBox.Show("Datos inválidos. La primera fecha no puede ser mayor a la segunda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaDel.Focus();
            }
        }

        private void FEstadoResultados_Load(object sender, EventArgs e)
        {
            dtpFechaDel.Value = DateTime.Parse("01/01/" + DateTime.Today.Year.ToString());
            dtpFechaAl.Value = DateTime.Parse("31/12/" + DateTime.Today.Year.ToString());
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
