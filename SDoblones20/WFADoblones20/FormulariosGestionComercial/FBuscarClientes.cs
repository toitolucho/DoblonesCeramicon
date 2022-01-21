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
    public partial class FBuscarClientes : Form
    {
        private ClientesCLN Clientes = new ClientesCLN();
        private DataTable RBClientes = new DataTable();
        public int CodigoCliente = 0;

        public DataTable ResultadoBusquedaClientes
        {
            get
            {
                return RBClientes;
            }
            set
            {
                RBClientes = value;
            }
        }

        public FBuscarClientes()
        {
            InitializeComponent();
        }
  

        private void bBuscar_Click(object sender, EventArgs e)
        {
            /*if (tBTextoBusqueda.Text.Trim() != "")
            {*/
                RBClientes = Clientes.BuscarClientes(cBBuscarPor.SelectedIndex.ToString(), tBTextoBusqueda.Text, cBBusquedaExacta.Checked);
                bSClientes.DataSource = RBClientes;
                dGVResultadoBusquedaClientes.AutoGenerateColumns = false;

                sSBuscarClientes.Items[0].Text = "Numero de registros encontrados: " + bSClientes.Count.ToString();
            /*}
            else
            {
                string Mensaje = "No se pueden realizar ninguna busqueda mientras no defina un cadena de texto valida";
                string Titulo = "Error en la cadena de busqueda";
                MessageBoxButtons Botones = MessageBoxButtons.OK;

                MessageBox.Show(Mensaje, Titulo, Botones);
            }*/
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
            cBBuscarPor.SelectedIndex = 5;
            tBTextoBusqueda.Focus();
        }

        private void dGVResultadoBusquedaClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CodigoCliente = int.Parse(dGVResultadoBusquedaClientes.CurrentRow.Cells[0].Value.ToString());
            this.Close();
        }

        private void dGVResultadoBusquedaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
