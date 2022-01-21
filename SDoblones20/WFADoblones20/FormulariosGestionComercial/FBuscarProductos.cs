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
    public partial class FBuscarProductos : Form
    {
        private ProductosCLN Productos = new ProductosCLN();
        private DataTable RBProductos = new DataTable();
        public string CodigoProducto = "";

        public DataTable ResultadoBusquedaProductos
        {
            get
            {
                return RBProductos;
            }
            set
            {
                RBProductos = value;
            }
        }

        public FBuscarProductos()
        {
            InitializeComponent();
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            bool ProcederBusqueda = true;
            if (tBTextoBusqueda.Text.Trim() == "")
            {
                string Mensaje = "Usted a decidido realizar una busqueda sin condiciones, lo cual le mostrara todos los registros existentes. Este tipo de busquedas pueden sobrecargar el sistema, ¿Realmente desea continuar?";
                string Titulo = "Advertencia";
                MessageBoxButtons MensajeBotones = MessageBoxButtons.OKCancel;
                MessageBoxIcon MensajeIcono = MessageBoxIcon.Exclamation;

                if (MessageBox.Show(Mensaje, Titulo, MensajeBotones, MensajeIcono) == DialogResult.Cancel)
                {
                    ProcederBusqueda = false;
                }
            }

            if (ProcederBusqueda)
            {
                RBProductos = Productos.BuscarProductos(cBBuscarPor.SelectedIndex.ToString(), tBTextoBusqueda.Text, cBBusquedaExacta.Checked);
                bSProductos.DataSource = RBProductos;
                dGVResultadoBusquedaProductos.AutoGenerateColumns = false;

                sSBuscarProductos.Items[0].Text = "Numero de registros encontrados: " + bSProductos.Count.ToString();

                tBTextoBusqueda.Focus();
                tBTextoBusqueda.SelectAll();
            }
        }

        private void dGVResultadoBusquedaProductos_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FBuscarProductos_Load(object sender, EventArgs e)
        {
            cBBuscarPor.SelectedIndex = 2;
            tBTextoBusqueda.Focus();
        }

        private void dGVResultadoBusquedaProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //CodigoProducto = dGVResultadoBusquedaProductos.CurrentRow.Cells[0].Value.ToString();
            //this.Close();
        }

        private void FBuscarProductos_Shown(object sender, EventArgs e)
        {
            tBTextoBusqueda.Focus();
        }

        private void FBuscarProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dGVResultadoBusquedaProductos.Rows.Count > 0)
            {
                CodigoProducto = dGVResultadoBusquedaProductos.CurrentRow.Cells[0].Value.ToString();
            }
        }
    }
}
