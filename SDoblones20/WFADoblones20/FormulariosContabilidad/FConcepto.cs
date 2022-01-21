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

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FConcepto : Form
    {
        private int NumConcepto;

        public FConcepto()
        {
            InitializeComponent();
        }

        public FConcepto(int NumeroConcepto, string NombreConcepto)
        {
            InitializeComponent();

            this.NumConcepto = NumeroConcepto;
            tbConcepto.Text = NombreConcepto;

            btAceptar.Text = "Modificar";
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (tbConcepto.Text != string.Empty)
            {
                ConceptosCLN concepto = new ConceptosCLN();

                if (tbConcepto.Text == "Modificar")
                {
                    concepto.ActualizarConcepto(NumConcepto, tbConcepto.Text);
                }
                else
                {
                    concepto.InsertarConcepto(tbConcepto.Text);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe introducir un Concepto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbConcepto.Focus();
            }
        }

        private void FConcepto_Load(object sender, EventArgs e)
        {

        }
    }
}
