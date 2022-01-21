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
    public partial class FEstadoAsiento : Form
    {        
        public FEstadoAsiento()
        {
            InitializeComponent();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public bool EstadoConfirmado()
        {
            if (rbConfirmado.Checked)
                return true;
            else
                return false;
        }

        private void brCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
