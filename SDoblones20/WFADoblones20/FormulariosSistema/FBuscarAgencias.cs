using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Sistema;

namespace WFADoblones20.FormulariosSistema
{
    public partial class FBuscarAgencias : Form
    {
        private AgenciasCLN Agencias = new AgenciasCLN();
        private DataTable RBAgencias = new DataTable();
        public int NumeroAgencia= 0;

        public DataTable ResultadoBusquedaAgencias
        {
            get
            {
                return RBAgencias;
            }
            set
            {
                RBAgencias = value;
            }
        }

        
        public FBuscarAgencias()
        {
            InitializeComponent();
        }

        private void FBuscarProveedores_Load(object sender, EventArgs e)
        {
            cBBuscarPor.SelectedIndex = 1;
            tBTextoBusqueda.Focus();
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            /*if (tBTextoBusqueda.Text.Trim() != "")
            {*/
                RBAgencias = Agencias.BuscarAgencias(cBBuscarPor.SelectedIndex.ToString(), tBTextoBusqueda.Text, cBBusquedaExacta.Checked);
                bSAgencias.DataSource = RBAgencias;
                dGVResultadoBusquedaAgencias.AutoGenerateColumns = false;

                sSBuscarAgencias.Items[0].Text = "Numero de registros encontrados: " + bSAgencias.Count.ToString();
            /*}
            else
            {
                string Mensaje = "No se pueden realizar ninguna busqueda mientras no defina un cadena de texto valida";
                string Titulo = "Error en la cadena de busqueda";
                MessageBoxButtons Botones = MessageBoxButtons.OK;

                MessageBox.Show(Mensaje, Titulo, Botones);
            }*/
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dGVResultadoBusquedaProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dGVResultadoBusquedaProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            NumeroAgencia = int.Parse(dGVResultadoBusquedaAgencias.CurrentRow.Cells[0].Value.ToString());
            this.Close();
        }

        private void dGVResultadoBusquedaProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
