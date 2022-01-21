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
    public partial class FAgregarEditarProductoComponente : Form
    {
        ProductosCLN Productos = new ProductosCLN();
        public string CodigoProducto = "";
        public string CodigoProductoComponente = "";
        public int Cantidad = 0;

        public FAgregarEditarProductoComponente(string CodigoProducto)
        {
            InitializeComponent();
            this.CodigoProducto = CodigoProducto;
            this.CodigoProductoComponente = "";
            this.Cantidad = 1;
            InicializarControles();
        }

        public FAgregarEditarProductoComponente(string CodigoProducto, string CodigoProductoComponente, int Cantidad)
        {
            InitializeComponent();
            this.CodigoProducto = CodigoProducto;
            this.CodigoProductoComponente = CodigoProductoComponente;
            this.Cantidad = Cantidad;
            InicializarControles();
        }

        private void InicializarControles()
        {
            CargarProductosSimples();
            cBProductoComponente.SelectedValue = this.CodigoProductoComponente;
            tBCantidad.Text = this.Cantidad.ToString();
        }

        private void CargarProductosSimples()
        {
            DataTable DTProductosSimplesLibres = new DataTable();
            DTProductosSimplesLibres = Productos.ListarProductosSimplesLibresPorCodigoProducto(this.CodigoProducto, this.CodigoProductoComponente);
                
            cBProductoComponente.DataSource = DTProductosSimplesLibres.DefaultView;
            cBProductoComponente.DisplayMember = "NombreProducto";
            cBProductoComponente.ValueMember = "CodigoProducto";
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (cBProductoComponente.SelectedIndex < 0)
             {
                MessageBox.Show("Debe seleccionar el producto que componente para completar esta operacion");
                 return;
             } 
            if (String.IsNullOrEmpty(tBCantidad.Text.Trim()))
             {
                MessageBox.Show("Debe llenar el campo correspondiente de la cantidad de productos de este tipo que componenen el respectivo producto compuesto");
                 return;
             }
             else
             {
                this.CodigoProductoComponente = cBProductoComponente.SelectedValue.ToString();
                this.Cantidad = int.Parse(tBCantidad.Text);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
             }
        }
    }
}
