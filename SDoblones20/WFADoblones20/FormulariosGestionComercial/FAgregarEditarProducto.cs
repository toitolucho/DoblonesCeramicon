using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using CLCLN.GestionComercial;
using System.Collections;
using WFADoblones20.ReportesGestionComercial;
using System.Text.RegularExpressions;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FAgregarEditarProducto : Form
    {
        private ProductosCLN Productos = new ProductosCLN();
        private ProductosMarcasCLN ProductosMarcas = new ProductosMarcasCLN();
        private ProductosTiposCLN ProductosTipos = new ProductosTiposCLN();
        private ProductosUnidadesCLN ProductosUnidades = new ProductosUnidadesCLN();
        private ProductosPropiedadesCLN ProductosPropiedades = new ProductosPropiedadesCLN();
        private ProductosDescripcionCLN ProductosDescripcion = new ProductosDescripcionCLN();
        private ProductosImagenesCLN ProductosImagenes = new ProductosImagenesCLN();

        private TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();

        private DataTable RBProductos = new DataTable();
        private DataTable DTProductosDescripcion = new DataTable();
        private DataTable DTProductosPropiedades = new DataTable();
        private DataTable DTProductosPropiedadesDisponibles = new DataTable();
        private DataTable DTProductosImagenes = new DataTable();

        private string TipoOperacion = "";

        private string RutaAplicacion = "";
        private string RutaImagenOrigen = "";
        private string RutaImagenDestino = "";
        private string NombreImagenDestino = "";
        private string NombreEquipoServidor = "";

        /// <summary>
        public string CodigoProducto = "";
        public string CodigoProductoFabricante = "";
        public string NombreProducto = "";
        public string NombreProducto1 = "";
        public string NombreProducto2 = "";
        public int CodigoMarcaProducto = 0;
        public int CodigoTipoProducto = 0;
        public int CodigoUnidadProducto = 0;
        public string CodigoTipoCalculoInventario = "P";
        public bool LlenarCodigoPE = false;
        public bool ProductoTangible = false;
        public bool ProductoSimple = false;
        public bool CalcularPrecioVenta = false;
        public decimal RendimientoDeseado1 = 0.00m;
        public decimal RendimientoDeseado2 = 0.00m;
        public decimal RendimientoDeseado3 = 0.00m;
        public string Descripcion = "";
        public string Observaciones = "";

        /// </summary>

        public FAgregarEditarProducto(string CodigoProducto, string CodigoProductoFabricante, string NombreProducto, string NombreProducto1, string NombreProducto2,
        int CodigoMarcaProducto, int CodigoTipoProducto, int CodigoUnidadProducto, string CodigoTipoCalculoInventario, bool LlenarCodigoPE,
        bool ProductoTangible, bool ProductoSimple, bool CalcularPrecioVenta, decimal RendimientoDeseado1, decimal RendimientoDeseado2, decimal RendimientoDeseado3, string Descripcion, string Observaciones)
        {
            InitializeComponent();

            this.CodigoProducto = CodigoProducto;
            this.CodigoProductoFabricante = CodigoProductoFabricante;
            this.NombreProducto = NombreProducto;
            this.NombreProducto1 = NombreProducto1;
            this.NombreProducto2 = NombreProducto2;
            this.CodigoMarcaProducto = CodigoMarcaProducto;
            this.CodigoTipoProducto = CodigoTipoProducto;
            this.CodigoUnidadProducto = CodigoUnidadProducto;
            this.CodigoTipoCalculoInventario = CodigoTipoCalculoInventario;
            this.LlenarCodigoPE = LlenarCodigoPE;
            this.ProductoTangible = ProductoTangible;
            this.ProductoSimple = ProductoSimple;
            this.CalcularPrecioVenta = CalcularPrecioVenta;
            this.RendimientoDeseado1 = RendimientoDeseado1;
            this.RendimientoDeseado2 = RendimientoDeseado2;
            this.RendimientoDeseado3 = RendimientoDeseado3;
            this.Descripcion = Descripcion;
            this.Observaciones = Observaciones;

            InicializarControles();
        }

        public FAgregarEditarProducto(string CodigoProductoFabricante, string NombreProducto, string NombreProducto1, string NombreProducto2,
        int CodigoMarcaProducto, int CodigoTipoProducto, int CodigoUnidadProducto, string CodigoTipoCalculoInventario, bool LlenarCodigoPE,
        bool ProductoTangible, bool ProductoSimple, bool CalcularPrecioVenta, decimal RendimientoDeseado1, decimal RendimientoDeseado2, decimal RendimientoDeseado3, string Descripcion, string Observaciones)
        {
            InitializeComponent();

            this.CodigoProducto = "";
            this.CodigoProductoFabricante = CodigoProductoFabricante;
            this.NombreProducto = NombreProducto;
            this.NombreProducto1 = NombreProducto1;
            this.NombreProducto2 = NombreProducto2;
            this.CodigoMarcaProducto = CodigoMarcaProducto;
            this.CodigoTipoProducto = CodigoTipoProducto;
            this.CodigoUnidadProducto = CodigoUnidadProducto;
            this.CodigoTipoCalculoInventario = CodigoTipoCalculoInventario;
            this.LlenarCodigoPE = LlenarCodigoPE;
            this.ProductoTangible = ProductoTangible;
            this.ProductoSimple = ProductoSimple;
            this.CalcularPrecioVenta = CalcularPrecioVenta;
            this.RendimientoDeseado1 = RendimientoDeseado1;
            this.RendimientoDeseado2 = RendimientoDeseado2;
            this.RendimientoDeseado3 = RendimientoDeseado3;
            this.Descripcion = Descripcion;
            this.Observaciones = Observaciones;

            InicializarControles();
        }

        public FAgregarEditarProducto(int CodigoTipoProducto)
        {
            InitializeComponent();

            this.CodigoProducto = "";
            this.CodigoProductoFabricante = "";
            this.NombreProducto = "";
            this.NombreProducto1 = "";
            this.NombreProducto2 = "";
            this.CodigoMarcaProducto = -1;
            this.CodigoTipoProducto = CodigoTipoProducto;
            this.CodigoUnidadProducto = -1;
            this.CodigoTipoCalculoInventario = "O";
            this.LlenarCodigoPE = false;
            this.ProductoTangible = true;
            this.ProductoSimple = true;
            this.CalcularPrecioVenta = false;
            this.RendimientoDeseado1 = 0.00m;
            this.RendimientoDeseado2 = 0.00m;
            this.RendimientoDeseado3 = 0.00m;
            this.Descripcion = "";
            this.Observaciones = "";

            InicializarControles();
        }

       
        //void txtIncremento_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!Char.IsNumber(e.KeyChar) && (((Keys)e.KeyChar)) != Keys.Back
        //        && (((Keys)e.KeyChar)) != (Keys)',')
        //    {
        //        e.Handled = true;
        //        System.Media.SystemSounds.Beep.Play();
        //    }
        //}

        private void CargarProductosMarcas()
        {
            DataTable DTProductosMarcas = new DataTable();
            DTProductosMarcas = ProductosMarcas.ListarProductosMarcas();
            cBMarca.DataSource = DTProductosMarcas.DefaultView;
            cBMarca.DisplayMember = "NombreMarcaProducto";
            cBMarca.ValueMember = "CodigoMarcaProducto";
        }

   
        private void CargarProductosUnidades()
        {
            DataTable DTProductosUnidades = new DataTable();
            DTProductosUnidades = ProductosUnidades.ListarProductosUnidades();
            cBUnidad.DataSource = DTProductosUnidades.DefaultView;
            cBUnidad.DisplayMember = "NombreUnidad";
            cBUnidad.ValueMember = "CodigoUnidad";
        }
        
        private void CargarTipoInventarios()
        {
            ArrayList TiposCalculoInventario = new ArrayList();
            TiposCalculoInventario.Add(new TipoCalculoInventario("P", "PEPS"));
            TiposCalculoInventario.Add(new TipoCalculoInventario("O", "PONDERADO"));
            TiposCalculoInventario.Add(new TipoCalculoInventario("B", "PRECIO MAS BAJO"));
            TiposCalculoInventario.Add(new TipoCalculoInventario("A", "PRECIO MAS ALTO"));
            TiposCalculoInventario.Add(new TipoCalculoInventario("U", "UEPS"));
            TiposCalculoInventario.Add(new TipoCalculoInventario("T", "ULTIMO PRECIO"));
            
            cBTipoCalculoInventario.DataSource = TiposCalculoInventario;
            cBTipoCalculoInventario.DisplayMember = "NombreTipoCalculoInventario";
            cBTipoCalculoInventario.ValueMember = "CodigoTipoCalculoInventario";
            cBTipoCalculoInventario.SelectedIndex = 0;
        }

        //private void InhabilitarControles(bool Estado)
        //{
			
        //    tBCodigoProducto.ReadOnly = Estado;
        //    tBCodigoProductoFabricante.ReadOnly = Estado;
        //    tBRendimientoDeseado1.ReadOnly = Estado;
        //    tBRendimientoDeseado1.Visible = !Estado;
        //    tBNombreProducto.ReadOnly = Estado;
        //    tBNombreProducto1.ReadOnly = Estado;
        //    tBNombreProducto2.ReadOnly = Estado;
        //    cBMarca.Enabled = !Estado;
        //    cBUnidad.Enabled = !Estado;
        //    cBTipoCalculoInventario.Enabled = !Estado;
        //    cBLlenarCodigoPE.Enabled = !Estado;
        //    cBProductoTangible.Enabled = !Estado;
        //    cBProductoSimple.Enabled = !Estado;
        //    cBActualizarPreciosVenta.Enabled = !Estado;
        //    cBCalcularPrecioVenta.Enabled = !Estado;
        //    tBDescripcion.ReadOnly = Estado;
        //    tBObservaciones.ReadOnly = Estado;
        //    btnMarcas.Enabled = !Estado;
        //    btnUnidades.Enabled = !Estado;
        //}

        private void InicializarControles()
        {
            CargarProductosMarcas();
            CargarProductosUnidades();
            CargarTipoInventarios();
            tBCodigoProducto.ReadOnly = true;
            cBGenerarAutomaticamenteCodigoProducto.Enabled = true;
            cBCopiarCodigo.Enabled = true;

            tBCodigoProducto.Text = this.CodigoProducto;
            tBCodigoProductoFabricante.Text = this.CodigoProductoFabricante;
			//txtIncremento.Text = ;
            tBNombreProducto.Text = this.NombreProducto;
            tBNombreProducto1.Text = this.NombreProducto1;
            tBNombreProducto2.Text = this.NombreProducto2;
            cBMarca.SelectedValue = this.CodigoMarcaProducto;
            cBUnidad.SelectedValue = this.CodigoUnidadProducto;
            cBTipoCalculoInventario.SelectedValue = this.CodigoTipoCalculoInventario;
            cBTipoCalculoInventario.Enabled = false;
            cBLlenarCodigoPE.Checked = this.LlenarCodigoPE;
            cBProductoTangible.Checked = this.ProductoTangible;
            cBProductoSimple.Checked = this.ProductoSimple;
			//cBActualizarPreciosVenta.Checked = false;
            cBCalcularPrecioVenta.Checked = this.CalcularPrecioVenta;
            tBRendimientoDeseado1.Text = this.RendimientoDeseado1.ToString();
            tBRendimientoDeseado2.Text = this.RendimientoDeseado2.ToString();
            tBRendimientoDeseado3.Text = this.RendimientoDeseado3.ToString();
            tBDescripcion.Text = this.Descripcion;
            tBObservaciones.Text = this.Observaciones;
            
        }
    
        public bool validarDatos()
        {
            if (String.IsNullOrEmpty(tBCodigoProducto.Text.Trim()))
            {
                errorProvider1.SetError(tBCodigoProducto, "Aún no ha ingresado el Código del Producto");
                tBCodigoProducto.Focus();
                tBCodigoProducto.SelectAll();
                return false;
            }
            if (String.IsNullOrEmpty(tBCodigoProductoFabricante.Text.Trim()))
            {
                errorProvider1.SetError(tBCodigoProductoFabricante, "Aún no ha ingresado el Código del Fabricante del Producto");
                tBCodigoProductoFabricante.Focus();
                tBCodigoProductoFabricante.SelectAll();
                return false;
            }
            if (String.IsNullOrEmpty(tBNombreProducto.Text.Trim()))
            {
                errorProvider1.SetError(tBNombreProducto, "Aún no ha ingresado el Nombre del Producto");
                tBNombreProducto.Focus();
                tBNombreProducto.SelectAll();
                return false;
            }
            if (String.IsNullOrEmpty(tBNombreProducto1.Text.Trim()) &&
                MessageBox.Show(this, "¿Se encuentra seguro de dejar en Blanco el Segundo Nombre Alternativo del Producto?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                errorProvider1.SetError(tBNombreProducto1, "Aún no ha ingresado el Segundo Nombre Alternativo del Producto");
                tBNombreProducto1.Focus();
                tBNombreProducto1.SelectAll();
                return false;
            }
            if (String.IsNullOrEmpty(tBNombreProducto2.Text.Trim()) &&
                MessageBox.Show(this, "¿Se encuentra seguro de dejar en Blanco el Tercer Nombre Alternativo del Producto?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                errorProvider1.SetError(tBNombreProducto2, "Aún no ha ingresado el Tercer Nombre Alternativo del Producto");
                tBNombreProducto2.Focus();
                tBNombreProducto2.SelectAll();
                return false;
            }
            if (cBMarca.SelectedIndex == -1)
            {
                errorProvider1.SetError(cBMarca, "No ha seleccionado la marca del Producto");
                cBMarca.Focus();
                cBMarca.SelectAll();
                return false;
            }
            if (cBUnidad.SelectedIndex == -1)
            {
                errorProvider1.SetError(cBUnidad, "No ha seleccionado la unidad del Producto");
                cBUnidad.Focus();
                cBUnidad.SelectAll();
                return false;
            }
            if (cBTipoCalculoInventario.SelectedIndex == -1)
            {
                errorProvider1.SetError(cBTipoCalculoInventario, "No ha seleccionado el tipo de calculo de inventario del Producto");
                cBTipoCalculoInventario.Focus();
                cBTipoCalculoInventario.SelectAll();
                return false;
            }
            return true;
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (!validarDatos())
            {
                MessageBox.Show(this, "No se ha completado toda la informacion necesaria para completar el registro, complete lo requerido para completar esta operación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                this.CodigoProducto = tBCodigoProducto.Text;
                this.CodigoProductoFabricante = tBCodigoProductoFabricante.Text;
                this.NombreProducto = tBNombreProducto.Text;
                this.NombreProducto1 = tBNombreProducto1.Text;
                this.NombreProducto2 = tBNombreProducto2.Text;
                this.CodigoMarcaProducto = int.Parse(cBMarca.SelectedValue.ToString());
                this.CodigoUnidadProducto = int.Parse(cBUnidad.SelectedValue.ToString());
                this.CodigoTipoCalculoInventario = cBTipoCalculoInventario.SelectedValue.ToString();
                this.LlenarCodigoPE = cBLlenarCodigoPE.Checked;
                this.ProductoTangible = cBProductoTangible.Checked;
                this.ProductoSimple = cBProductoSimple.Checked;
                this.CalcularPrecioVenta = cBCalcularPrecioVenta.Checked;
                this.RendimientoDeseado1 = decimal.Parse(tBRendimientoDeseado1.Text);
                this.RendimientoDeseado2 = decimal.Parse(tBRendimientoDeseado2.Text);
                this.RendimientoDeseado3 = decimal.Parse(tBRendimientoDeseado3.Text);
                this.Descripcion = tBDescripcion.Text;
                this.Observaciones = tBObservaciones.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        //public void actualizarPreciosVenta()
        //{

        //    String ProductosDetalleXML = String.Format("<Productos><ProductosHistorial> <CodigoProducto>{0}</CodigoProducto> <CantidadRecepcion>1</CantidadRecepcion> <PrecioUnitarioCompra>1</PrecioUnitarioCompra> <MontoGastoIncremento>0</MontoGastoIncremento></ProductosHistorial></Productos>", tBCodigoProducto.Text);

        //    FComprasProductosActualizarPreciosVentas formPrecios = new FComprasProductosActualizarPreciosVentas(decimal.Parse(tBRendimientoDeseado1.Text),
        //        ProductosDetalleXML, 1, 1);
        //    formPrecios.ShowDialog();
        //    formPrecios.Dispose();
        //}
		
        private void bBuscar_Click(object sender, EventArgs e)
        {
            //FBuscarProductos fBuscarProductos = new FBuscarProductos();
            //fBuscarProductos.ShowDialog();
            //RBProductos = fBuscarProductos.ResultadoBusquedaProductos;
            
            //string CodigoProducto = fBuscarProductos.CodigoProducto;
            
            //RBProductos = Productos.ObtenerProducto(CodigoProducto);

            //if (RBProductos.Rows.Count > 0)
            //{
            //    if (pBImagenProducto.Image != null)
            //        pBImagenProducto.Image.Dispose();
            //    pBImagenProducto.Image = null;
            //    tCProductos.SelectedTab = tabPage1;


            //    tBCodigoProducto.Text = RBProductos.Rows[0][0].ToString();
            //    tBCodigoProductoFabricante.Text = RBProductos.Rows[0][1].ToString();
            //    tBNombreProducto.Text = RBProductos.Rows[0][2].ToString();
            //    tBNombreProducto1.Text = RBProductos.Rows[0][3].ToString();
            //    tBNombreProducto2.Text = RBProductos.Rows[0][4].ToString();
            //    if ((RBProductos.Rows[0][5].ToString() != null) && (RBProductos.Rows[0][5].ToString() != ""))
            //        cBMarca.SelectedValue = RBProductos.Rows[0][5].ToString();
            //    else
            //        cBMarca.SelectedIndex = -1;
            //    //if ((RBProductos.Rows[0][6].ToString() != null) && (RBProductos.Rows[0][6].ToString() != ""))
            //    //    cBTipoProducto.SelectedValue = RBProductos.Rows[0][6].ToString();
            //    //else
            //    //    cBTipoProducto.SelectedIndex = -1;
            //    //if ((RBProductos.Rows[0][7].ToString() != null) && (RBProductos.Rows[0][7].ToString() != ""))
            //    //    cBUnidad.SelectedValue = RBProductos.Rows[0][7].ToString();
            //    //else
            //    //    cBUnidad.SelectedIndex = -1;
            //    //if ((RBProductos.Rows[0][8].ToString() != null) && (RBProductos.Rows[0][8].ToString() != ""))
            //    //    cBTipoCalculoInventario.SelectedValue = RBProductos.Rows[0][8].ToString();
            //    //else
            //    //    cBTipoCalculoInventario.SelectedIndex = -1;
            //    cBLlenarCodigoPE.Checked = bool.Parse(RBProductos.Rows[0][9].ToString());
            //    cBProductoTangible.Checked = bool.Parse(RBProductos.Rows[0][10].ToString());
            //    cBProductoSimple.Checked = bool.Parse(RBProductos.Rows[0][11].ToString());
            //    cBCalcularPrecioVenta.Checked = bool.Parse(RBProductos.Rows[0][12].ToString());
            //    tBDescripcion.Text = RBProductos.Rows[0][13].ToString();
            //    tBObservaciones.Text = RBProductos.Rows[0][14].ToString();

           
                
            //    //RBProductosDescripcion = ProductosDescripcion.ListarProductosDescripcionPorCodigoProducto(RBProductos.Rows[0][0].ToString());
            //    /*
            //    productosDescripcionCLNBindingSource.DataSource = ProductosDescripcion.ListarProductosDescripcionPorCodigoProducto(RBProductos.Rows[0][0].ToString());
            //    DGVProductosDescripcion.AutoGenerateColumns = true;

            //    productosDescripcionCLNBindingNavigator.Enabled = true;
            //    DGVProductosDescripcion.Enabled = true;
            //    */
            //}
            //else
            //{
            //    InhabilitarControles(true);
            //    InicializarControles();

            //    DGVProductosDescripcion.Enabled = false;
            //}
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bReporte_Click(object sender, EventArgs e)
        {
            FReportesGestionComercialProductos fReportesGestionComercialproductos = new FReportesGestionComercialProductos(Productos.ListarProductosReporte());
            fReportesGestionComercialproductos.ShowDialog();
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            FProductosMarcas formProductosMarcas = new FProductosMarcas();
            formProductosMarcas.ShowDialog(this);
            formProductosMarcas.Dispose();

            int CodigoProductoMarca = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("ProductosMarcas");
            DataTable DTProductosMarcas = (cBMarca.DataSource as DataView).Table, DTProductosMarcasNuevaFila;
            if (DTProductosMarcas.Rows.Find(CodigoProductoMarca) == null)
            {
                DTProductosMarcasNuevaFila = ProductosMarcas.ObtenerProductoMarca(CodigoProductoMarca);
                DTProductosMarcas.Rows.Add(DTProductosMarcasNuevaFila.Rows[0].ItemArray);
                DTProductosMarcas.AcceptChanges();

                DTProductosMarcas.DefaultView.Sort = "NombreMarcaProducto ASC";

                cBMarca.SelectedValue = CodigoProductoMarca;
            }

        }

        private void btnUnidades_Click(object sender, EventArgs e)
        {
            FProductosUnidades formProductosUnidades = new FProductosUnidades();
            formProductosUnidades.ShowDialog(this);
            formProductosUnidades.Dispose();

            int CodigoProductoUnidad = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("ProductosUnidades");
            DataTable DTProductosUnidades = (cBUnidad.DataSource as DataView).Table, DTProductosUnidadesNuevaFila;
            if(DTProductosUnidades.Rows.Find(CodigoProductoUnidad) == null)
            {
                DTProductosUnidadesNuevaFila = ProductosUnidades.ObtenerProductoUnidad(CodigoProductoUnidad);
                DTProductosUnidades.Rows.Add(DTProductosUnidadesNuevaFila.Rows[0].ItemArray);
                DTProductosUnidades.AcceptChanges();

                DTProductosUnidades.DefaultView.Sort = "NombreUnidad ASC";

                cBUnidad.SelectedValue = CodigoProductoUnidad;
            }
        }

        private void tBNombreProducto_Leave(object sender, EventArgs e)
        {
            if ((tBNombreProducto.Text.Length >= 3) && (cBGenerarAutomaticamenteCodigoProducto.Checked))
            {
                Regex reg = new Regex("[^a-zA-Z0-9 ]");
                string CodigoProductoAux = Productos.GenerarCodigoProducto(CodigoTipoProducto, reg.Replace(tBNombreProducto.Text.Normalize(NormalizationForm.FormD), ""));
                tBCodigoProducto.Text = CodigoProductoAux;
            }
        }
        
        private void cBGenerarAutomaticamenteCodigoProducto_CheckedChanged(object sender, EventArgs e)
        {
            tBCodigoProducto.ReadOnly = cBGenerarAutomaticamenteCodigoProducto.Checked;
        }

        private void cBCopiarCodigo_CheckedChanged(object sender, EventArgs e)
        {
            tBCodigoProductoFabricante.ReadOnly = cBCopiarCodigo.Checked;
        }

        private void tBCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            if(cBCopiarCodigo.Checked)
            {
                tBCodigoProductoFabricante.Text = tBCodigoProducto.Text;
            }
        }

       //private void cBActualizarPreciosVenta_CheckedChanged(object sender, EventArgs e)
       // {
       //     if (!String.IsNullOrEmpty(TipoOperacion))
       //     {
       //         tBRendimientoDeseado1.Visible = cBActualizarPreciosVenta.Checked;
       //     }
       // }

        private void btnUnidades_Click_1(object sender, EventArgs e)
        {
            FProductosUnidades fam = new FProductosUnidades();
            fam.ShowDialog();

            cBUnidad.DataSource = null;

            CargarProductosUnidades();
            cBUnidad.SelectedValue = fam.CodigoUnidadActual;
            fam.Dispose();
        }

        private void btnMarcas_Click_1(object sender, EventArgs e)
        {
            FProductosMarcas fam = new FProductosMarcas();
            fam.ShowDialog();

            cBMarca.DataSource = null;

            CargarProductosMarcas();
            cBMarca.SelectedValue = fam.CodigoMarcaActual;
            fam.Dispose();
        }

        private void FAgregarEditarProducto_Load(object sender, EventArgs e)
        {
            
        }

        private void FAgregarEditarProducto_Shown(object sender, EventArgs e)
        {
            tBCodigoProductoFabricante.Focus();
        }

    }

    public class TipoCalculoInventario
    {
        private string CodTipCalInv;
        private string NomTipCalInv;

        public TipoCalculoInventario(string CodigoTipoCalculoInventario, string NombreTipoCalculoInventario)
        {
            this.CodTipCalInv = CodigoTipoCalculoInventario;
            this.NomTipCalInv = NombreTipoCalculoInventario;
        }

        public string CodigoTipoCalculoInventario
        {
            get
            {
                return CodTipCalInv;
            }
        }

        public string NombreTipoCalculoInventario
        {

            get
            {
                return NomTipCalInv;
            }
        }
    }
}
