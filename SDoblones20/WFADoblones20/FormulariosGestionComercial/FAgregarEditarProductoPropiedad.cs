using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;

namespace WFADoblones20
{
    public partial class FAgregarEditarProductoPropiedad : Form
    {
        ProductosPropiedadesCLN ProductosPropiedades = new ProductosPropiedadesCLN();
        public int CodigoPropiedad = 0;
        public string ValorPropiedad = "";

        public FAgregarEditarProductoPropiedad()
        {
            InitializeComponent();
            this.CodigoPropiedad = 0;
            this.ValorPropiedad = "";
            InicializarControles();
        }

        public FAgregarEditarProductoPropiedad(int CodigoPropiedad, string ValorPropiedad)
        {
            InitializeComponent();
            this.CodigoPropiedad = CodigoPropiedad;
            this.ValorPropiedad = ValorPropiedad;
            InicializarControles();
        }

        private void FAgregarEditarProductoPropiedad_Load(object sender, EventArgs e)
        {

        }

        private void InicializarControles()
        {
            CargarPropiedadesProductos();
            cBPropiedadProducto.SelectedValue = this.CodigoPropiedad;
            tBValorPropiedad.Text = this.ValorPropiedad;
        }

        private void CargarPropiedadesProductos()
        {
            DataTable DTProductosPropiedades = new DataTable();
            DTProductosPropiedades = ProductosPropiedades.ListarProductosPropiedades();
            cBPropiedadProducto.DataSource = DTProductosPropiedades.DefaultView;
            cBPropiedadProducto.DisplayMember = "NombrePropiedad";
            cBPropiedadProducto.ValueMember = "CodigoPropiedad";
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
             if (String.IsNullOrEmpty(tBValorPropiedad.Text.Trim()))
             {
                MessageBox.Show("No puede dejar sin llevar el campo correspondiente al valor de la propiedad");
                 return;
             }
             else
             {
                this.CodigoPropiedad = int.Parse(cBPropiedadProducto.SelectedValue.ToString());
                this.ValorPropiedad = tBValorPropiedad.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
             }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {

        }

    }
}
