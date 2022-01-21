using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FBuscarCreditos : Form
    {
        private CreditosCLN Creditos = new CreditosCLN();
        private DataTable RBCreditos = new DataTable();
        public int NumeroCredito = 0;

        public DataTable ResultadoBusquedaCreditos
        {
            get
            {
                return RBCreditos;
            }
            set
            {
                RBCreditos = value;
            }
        }

        public FBuscarCreditos()
        {
            InitializeComponent();
        }
  

        private void bBuscar_Click(object sender, EventArgs e)
        {
            if (tBTextoBusqueda.Text.Trim() != "")
            {
                RBCreditos = Creditos.BuscarCreditos(cBBuscarPor.SelectedIndex.ToString(), tBTextoBusqueda.Text, cBBusquedaExacta.Checked);
                bSCreditos.DataSource = RBCreditos;
                dGVResultadoBusquedaCreditos.AutoGenerateColumns = false;

                sSBuscarCreditos.Items[0].Text = "Numero de registros encontrados: " + bSCreditos.Count.ToString();
            }
            else
            {
                string Mensaje = "No se pueden realizar ninguna busqueda mientras no defina un cadena de texto valida";
                string Titulo = "Error en la cadena de busqueda";
                MessageBoxButtons Botones = MessageBoxButtons.OK;

                MessageBox.Show(Mensaje, Titulo, Botones);
            }
        }

        private void dGVResultadoBusquedaClientes_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FBuscarClientes_Load(object sender, EventArgs e)
        {
            cBBuscarPor.SelectedIndex = 0;
            tBTextoBusqueda.Focus();
        }

        private void dGVResultadoBusquedaClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            NumeroCredito = int.Parse(dGVResultadoBusquedaCreditos.CurrentRow.Cells[0].Value.ToString());
            this.Close();
        }

        private void dGVResultadoBusquedaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bSCreditos_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
