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
    public partial class FBuscarProveedores : Form
    {
        private ProveedoresCLN Proveedores = new ProveedoresCLN();
        private DataTable RBProveedores = new DataTable();
        public int CodigoProveedor = 0;

        public DataTable ResultadoBusquedaProveedores
        {
            get
            {
                return RBProveedores;
            }
            set
            {
                RBProveedores = value;
            }
        }

        
        public FBuscarProveedores()
        {
            InitializeComponent();
        }

        private void FBuscarProveedores_Load(object sender, EventArgs e)
        {
            cBBuscarPor.SelectedIndex = 7;
            tBTextoBusqueda.Focus();
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            /*if (tBTextoBusqueda.Text.Trim() != "")
            {*/
                RBProveedores = Proveedores.BuscarProveedores(cBBuscarPor.SelectedIndex.ToString(), tBTextoBusqueda.Text, cBBusquedaExacta.Checked);
                bSProveedores.DataSource = RBProveedores;
                dGVResultadoBusquedaProveedores.AutoGenerateColumns = false;

                sSBuscarProveedores.Items[0].Text = "Numero de registros encontrados: " + bSProveedores.Count.ToString();
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
            CodigoProveedor = int.Parse(dGVResultadoBusquedaProveedores.CurrentRow.Cells[0].Value.ToString());
            this.Close();
        }

        private void dGVResultadoBusquedaProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
