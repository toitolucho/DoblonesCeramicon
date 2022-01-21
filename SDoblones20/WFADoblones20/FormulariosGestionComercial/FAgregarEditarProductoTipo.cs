using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FAgregarEditarProductoTipo : Form
    {
        public int CodigoTipoProducto = 0;
        public int? CodigoTipoProductoPadre = null;
        public string NombreTipoProducto = "";
        public string NombreCortoTipoProducto = "";
        public string NombreTipoProductoPadre = "";
        public string DescripcionTipoProducto = "";
        public byte Nivel = 0;

        public FAgregarEditarProductoTipo()
        {
            InitializeComponent();
            this.NombreTipoProducto = "";
            this.NombreCortoTipoProducto = "";
            this.DescripcionTipoProducto = "";
            InicializarControles();
        }

        public FAgregarEditarProductoTipo(string NombreTipoProducto, string NombreCortoTipoProducto, string DescripcionTipoProducto)
        {
            InitializeComponent();
            this.NombreTipoProducto = NombreTipoProducto;
            this.NombreCortoTipoProducto = NombreCortoTipoProducto;
            this.DescripcionTipoProducto = DescripcionTipoProducto;
            InicializarControles();
        }

        public void InicializarControles()
        {
            //tBCodigoTipoProductoPadre.Text = "";
            tBNombreTipoProducto.Text = this.NombreTipoProducto;
            tBNombreCortoTipoProducto.Text = this.NombreCortoTipoProducto;
            //tBNombreTipoProductoPadre.Text = "";
            tBDescripcionTipoProducto.Text = this.DescripcionTipoProducto;
            //tBNivel.Text = "";
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            //CodigoTipoProducto = int.Parse(tBCodigoTipoProducto.Text);
            //CodigoTipoProductoPadre = int.Parse(tBCodigoTipoProducto.Text);
            NombreTipoProducto = tBNombreTipoProducto.Text;
            NombreCortoTipoProducto = tBNombreCortoTipoProducto.Text;
            DescripcionTipoProducto = tBDescripcionTipoProducto.Text;
            //Nivel = byte.Parse(tBNivel.Text);
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
