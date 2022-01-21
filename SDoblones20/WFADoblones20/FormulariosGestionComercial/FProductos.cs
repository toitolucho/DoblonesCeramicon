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
    public partial class FProductos : Form
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
        private string CodigoProducto = "";
        private string CodigoProductoFabricante = "";
        private string NombreProducto = "";
        private string NombreProducto1 = "";
        private string NombreProducto2 = "";
        private int CodigoMarcaProducto = 0;
        private int CodigoTipoProducto = 0;
        private int CodigoUnidadProducto = 0;
        private string CodigoTipoCalculoInventario = "P";
        private bool LlenarCodigoPE = false;
        private bool ProductoTangible = false;
        private bool ProductoSimple = false;
        private bool CalcularPrecioVenta = false;
        private string Descripcion = "";
        private string Observaciones = "";

        /// </summary>

        public FProductos(string CodigoProducto, string CodigoProductoFabricante, string NombreProducto, string NombreProducto1, string NombreProducto2,
        int CodigoMarcaProducto, int CodigoTipoProducto, int CodigoUnidadProducto, string CodigoTipoCalculoInventario, bool LlenarCodigoPE,
        bool ProductoTangible, bool ProductoSimple, bool CalcularPrecioVenta, string Descripcion, string Observaciones)
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
            this.Descripcion = Descripcion;
            this.Observaciones = Observaciones;

            InicializarControles();
        }

        public FProductos()
        {
            InitializeComponent();

            this.CodigoProducto = "";
            this.CodigoProductoFabricante = "";
            this.NombreProducto = "";
            this.NombreProducto1 = "";
            this.NombreProducto2 = "";
            this.CodigoMarcaProducto = -1;
            this.CodigoTipoProducto = -1;
            this.CodigoUnidadProducto = -1;
            this.CodigoTipoCalculoInventario = "P";
            this.LlenarCodigoPE = false;
            this.ProductoTangible = false;
            this.ProductoSimple = false;
            this.CalcularPrecioVenta = false;
            this.Descripcion = "";
            this.Observaciones = "";

            InicializarControles();
        }

        public FProductos(bool PermitirInsertar, bool PermitirEditar, bool PermitirEliminar, bool PermitirNavegar)
        {
            InitializeComponent();

            this.bNuevo.Visible = PermitirInsertar;
            this.bEditar.Visible = PermitirEditar;
            this.bEliminar.Visible = PermitirEliminar;
            this.bCancelar.Visible = (PermitirInsertar || PermitirEditar) ? true : false;
            this.bAceptar.Visible = (PermitirInsertar || PermitirEditar) ? true : false;
            this.bBuscar.Visible = PermitirNavegar;
            this.RutaAplicacion = Application.StartupPath;            
            DGVProductosDescripcion.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            NombreEquipoServidor = _TransaccionesUtilidadesCLN.ObtenerNombrePCServidor();            
            toolStrip2.Visible = true;
            toolStrip1.Visible = true;
			
			txtIncremento.KeyPress += new KeyPressEventHandler(txtIncremento_KeyPress);
        }

		void txtIncremento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && (((Keys)e.KeyChar)) != Keys.Back
                && (((Keys)e.KeyChar)) != (Keys)',')
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }
        private void CargarProductosMarcas()
        {
            DataTable DTProductosMarcas = new DataTable();
            DTProductosMarcas = ProductosMarcas.ListarProductosMarcas();
            cBMarca.DataSource = DTProductosMarcas.DefaultView;
            cBMarca.DisplayMember = "NombreMarcaProducto";
            cBMarca.ValueMember = "CodigoMarcaProducto";
        }

        private void CargarProductosTipos()
        {
            DataTable DTProductosTipos = new DataTable();
            DTProductosTipos = ProductosTipos.ListarProductosTipos();
            cBTipoProducto.DataSource = DTProductosTipos.DefaultView;
            cBTipoProducto.DisplayMember = "NombreTipoProducto";
            cBTipoProducto.ValueMember = "CodigoTipoProducto";
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

        private void InhabilitarControles(bool Estado)
        {
			
            tBCodigoProducto.ReadOnly = Estado;
            tBCodigoProductoFabricante.ReadOnly = Estado;
			txtIncremento.ReadOnly = Estado;
            txtIncremento.Visible = !Estado;
            tBNombreProducto.ReadOnly = Estado;
            tBNombreProducto1.ReadOnly = Estado;
            tBNombreProducto2.ReadOnly = Estado;
            cBMarca.Enabled = !Estado;
            cBTipoProducto.Enabled = !Estado;
            cBUnidad.Enabled = !Estado;
            cBTipoCalculoInventario.Enabled = !Estado;
            cBLlenarCodigoPE.Enabled = !Estado;
            cBProductoTangible.Enabled = !Estado;
            cBProductoSimple.Enabled = !Estado;
			cBActualizarPreciosVenta.Enabled = !Estado;
            cBCalcularPrecioVenta.Enabled = !Estado;
            tBDescripcion.ReadOnly = Estado;
            tBObservaciones.ReadOnly = Estado;
            btnMarcas.Enabled = !Estado;
            btnTipoProducto.Enabled = !Estado;
            btnUnidades.Enabled = !Estado;
        }

        private void InicializarControles()
        {
            tBCodigoProducto.Text = this.CodigoProducto;
            tBCodigoProductoFabricante.Text = this.CodigoProductoFabricante;
			//txtIncremento.Text = ;
            tBNombreProducto.Text = this.NombreProducto;
            tBNombreProducto1.Text = this.NombreProducto1;
            tBNombreProducto2.Text = this.NombreProducto2;
            cBMarca.SelectedIndex = this.CodigoMarcaProducto;
            cBTipoProducto.SelectedIndex = this.CodigoTipoProducto;
            cBUnidad.SelectedIndex = this.CodigoUnidadProducto;
            cBTipoCalculoInventario.SelectedValue = this.CodigoTipoCalculoInventario;
            cBLlenarCodigoPE.Checked = this.LlenarCodigoPE;
            cBProductoTangible.Checked = this.ProductoTangible;
            cBProductoSimple.Checked = this.ProductoSimple;
			cBActualizarPreciosVenta.Checked = false;
            cBCalcularPrecioVenta.Checked = this.CalcularPrecioVenta;
            tBDescripcion.Text = this.Descripcion;
            tBObservaciones.Text = this.Observaciones;
        }
    
        private void bNuevo_Click(object sender, EventArgs e)
        {            
            TipoOperacion = "I";
            errorProvider1.Clear();
            InhabilitarControles(false);
            InicializarControles();
            bNuevo.Enabled = false;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = true;
            bCancelar.Enabled = true;

            tCProductos.SelectedIndex = 0;
            if (cBGenerarAutomaticamenteCodigoProducto.Checked)
            {
                tBCodigoProducto.ReadOnly = true;
                if (!cBCopiarCodigo.Checked)
                {
                    tBCodigoProductoFabricante.ReadOnly = false;
                    tBCodigoProductoFabricante.Focus();
                }
                else
                {
                    tBCodigoProductoFabricante.ReadOnly = true;
                    tBNombreProducto.Focus();
                }
                
            }
            else
            {
                tBCodigoProductoFabricante.ReadOnly = cBCopiarCodigo.Checked;
                tBCodigoProducto.ReadOnly = false;
                tBCodigoProducto.Focus();
            }
			txtIncremento.Text = (15.5M).ToString();
            
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            InhabilitarControles(false);
            bNuevo.Enabled = false;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = true;
            bCancelar.Enabled = true;
            tBCodigoProducto.Focus();
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            string Mensaje = "Esta seguro que desea eliminar el registro actual, recuerde que una vez aceptada la operacion es irreversible.";
            string Titulo = "Confimarción eliminación registro";
            MessageBoxButtons Botones = MessageBoxButtons.YesNo;
            MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
            DialogResult result;

            result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

            if (result == DialogResult.Yes)
            {
                Productos.EliminarProducto(tBCodigoProducto.Text);
                InhabilitarControles(true);
                InicializarControles();
                bNuevo.Enabled = true;
                bEditar.Enabled = false;
                bEliminar.Enabled = false;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
            }
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
                errorProvider1.SetError(cBTipoProducto, "No ha seleccionado la marca del Producto");
                cBMarca.Focus();
                cBMarca.SelectAll();
                return false;
            }
            if (cBTipoProducto.SelectedIndex == -1)
            {
                errorProvider1.SetError(cBTipoProducto, "No ha seleccionado el tipo de producto del Producto");
                cBTipoProducto.Focus();
                cBTipoProducto.SelectAll();
                return false;
            }
            if (cBUnidad.SelectedIndex == -1)
            {
                errorProvider1.SetError(cBTipoProducto, "No ha seleccionado la unidad del Producto");
                cBUnidad.Focus();
                cBUnidad.SelectAll();
                return false;
            }
            if (cBTipoCalculoInventario.SelectedIndex == -1)
            {
                errorProvider1.SetError(cBTipoProducto, "No ha seleccionado el tipo de calculo de inventario del Producto");
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
                MessageBox.Show(this, "No se ha completado toda la informacion necesaris para completar el registro, complete lo requerido para completar esta operación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.CodigoProducto = tBCodigoProducto.Text;
            this.CodigoProductoFabricante = tBCodigoProductoFabricante.Text;
            this.NombreProducto = tBNombreProducto.Text;
            this.NombreProducto1 = tBNombreProducto1.Text;
            this.NombreProducto2 = tBNombreProducto2.Text;
            this.CodigoMarcaProducto = int.Parse(cBMarca.SelectedValue.ToString());
            this.CodigoTipoProducto = int.Parse(cBTipoProducto.SelectedValue.ToString());
            this.CodigoUnidadProducto = int.Parse(cBUnidad.SelectedValue.ToString());
            this.CodigoTipoCalculoInventario = cBTipoCalculoInventario.SelectedValue.ToString();
            this.LlenarCodigoPE = cBLlenarCodigoPE.Checked;
            this.ProductoTangible = cBProductoTangible.Checked;
            this.ProductoSimple = cBProductoSimple.Checked;
            this.CalcularPrecioVenta = cBCalcularPrecioVenta.Checked;
            this.Descripcion = tBDescripcion.Text;
            this.Observaciones = tBObservaciones.Text;
        }

		public void actualizarPreciosVenta()
        {

            String ProductosDetalleXML = String.Format("<Productos><ProductosHistorial> <CodigoProducto>{0}</CodigoProducto> <CantidadRecepcion>1</CantidadRecepcion> <PrecioUnitarioCompra>1</PrecioUnitarioCompra> <MontoGastoIncremento>0</MontoGastoIncremento></ProductosHistorial></Productos>", tBCodigoProducto.Text);

            FComprasProductosActualizarPreciosVentas formPrecios = new FComprasProductosActualizarPreciosVentas(decimal.Parse(txtIncremento.Text),
                ProductosDetalleXML, 1, 1);
            formPrecios.ShowDialog();
            formPrecios.Dispose();
        }
		
        private void bCancelar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (TipoOperacion == "I")
                InicializarControles();
            InhabilitarControles(true);
            bNuevo.Enabled = true;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            FBuscarProductos fBuscarProductos = new FBuscarProductos();
            fBuscarProductos.ShowDialog();
            RBProductos = fBuscarProductos.ResultadoBusquedaProductos;
            
            string CodigoProducto = fBuscarProductos.CodigoProducto;
            
            RBProductos = Productos.ObtenerProducto(CodigoProducto);

            if (RBProductos.Rows.Count > 0)
            {
                if (pBImagenProducto.Image != null)
                    pBImagenProducto.Image.Dispose();
                pBImagenProducto.Image = null;
                tCProductos.SelectedTab = tabPage1;


                tBCodigoProducto.Text = RBProductos.Rows[0][0].ToString();
                tBCodigoProductoFabricante.Text = RBProductos.Rows[0][1].ToString();
                tBNombreProducto.Text = RBProductos.Rows[0][2].ToString();
                tBNombreProducto1.Text = RBProductos.Rows[0][3].ToString();
                tBNombreProducto2.Text = RBProductos.Rows[0][4].ToString();
                if ((RBProductos.Rows[0][5].ToString() != null) && (RBProductos.Rows[0][5].ToString() != ""))
                    cBMarca.SelectedValue = RBProductos.Rows[0][5].ToString();
                else
                    cBMarca.SelectedIndex = -1;
                if ((RBProductos.Rows[0][6].ToString() != null) && (RBProductos.Rows[0][6].ToString() != ""))
                    cBTipoProducto.SelectedValue = RBProductos.Rows[0][6].ToString();
                else
                    cBTipoProducto.SelectedIndex = -1;
                if ((RBProductos.Rows[0][7].ToString() != null) && (RBProductos.Rows[0][7].ToString() != ""))
                    cBUnidad.SelectedValue = RBProductos.Rows[0][7].ToString();
                else
                    cBUnidad.SelectedIndex = -1;
                if ((RBProductos.Rows[0][8].ToString() != null) && (RBProductos.Rows[0][8].ToString() != ""))
                    cBTipoCalculoInventario.SelectedValue = RBProductos.Rows[0][8].ToString();
                else
                    cBTipoCalculoInventario.SelectedIndex = -1;
                cBLlenarCodigoPE.Checked = bool.Parse(RBProductos.Rows[0][9].ToString());
                cBProductoTangible.Checked = bool.Parse(RBProductos.Rows[0][10].ToString());
                cBProductoSimple.Checked = bool.Parse(RBProductos.Rows[0][11].ToString());
                cBCalcularPrecioVenta.Checked = bool.Parse(RBProductos.Rows[0][12].ToString());
                tBDescripcion.Text = RBProductos.Rows[0][13].ToString();
                tBObservaciones.Text = RBProductos.Rows[0][14].ToString();

                bNuevo.Enabled = true;
                bEditar.Enabled = true;
                bEliminar.Enabled = true;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;

                
                //RBProductosDescripcion = ProductosDescripcion.ListarProductosDescripcionPorCodigoProducto(RBProductos.Rows[0][0].ToString());
                /*
                productosDescripcionCLNBindingSource.DataSource = ProductosDescripcion.ListarProductosDescripcionPorCodigoProducto(RBProductos.Rows[0][0].ToString());
                DGVProductosDescripcion.AutoGenerateColumns = true;

                productosDescripcionCLNBindingNavigator.Enabled = true;
                DGVProductosDescripcion.Enabled = true;
                */
            }
            else
            {
                InhabilitarControles(true);
                InicializarControles();
                bNuevo.Enabled = true;
                bEditar.Enabled = false;
                bEliminar.Enabled = false;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;

                DGVProductosDescripcion.Enabled = false;
            }
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FProductos_Load(object sender, EventArgs e)
        {
            CargarProductosMarcas();
            CargarProductosTipos();
            CargarProductosUnidades();
            CargarTipoInventarios();

            InhabilitarControles(true);
            InicializarControles();

            bNuevo.Enabled = true;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;

            DGVProductosDescripcion.ReadOnly = true;
            dGVProductosImagenes.ReadOnly = true;
        }

        private void bReporte_Click(object sender, EventArgs e)
        {
            FReportesGestionComercialProductos fReportesGestionComercialproductos = new FReportesGestionComercialProductos(Productos.ListarProductosReporte());
            fReportesGestionComercialproductos.ShowDialog();
        }


        private void FProductos_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn bBuscarImagen = new DataGridViewButtonColumn();
            {
                bBuscarImagen.HeaderText = "";
                bBuscarImagen.Text = "...";
                bBuscarImagen.UseColumnTextForButtonValue = true;
                bBuscarImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                bBuscarImagen.FlatStyle = FlatStyle.Standard;
                bBuscarImagen.CellTemplate.Style.BackColor = Color.Honeydew;
                bBuscarImagen.DisplayIndex = 2;
            }

            dGVProductosImagenes.Columns.Add(bBuscarImagen);
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

        private void btnTipoProducto_Click(object sender, EventArgs e)
        {
            //FAdministradorProductos formProductosTipos = new FAdministradorProductos();
            //formProductosTipos.ShowDialog(this);
            //CargarProductosTipos();
            //cBTipoProducto.SelectedValue = formProductosTipos.CodigoTipoProductoSeleccionado;
            //formProductosTipos.Dispose();
        }

        private void tBNombreProducto_Leave(object sender, EventArgs e)
        {
            if ((tBNombreProducto.Text.Length >= 3) && (cBTipoProducto.SelectedIndex >= 0) && (cBGenerarAutomaticamenteCodigoProducto.Checked) && (!tBNombreProducto.ReadOnly) &&(cBGenerarAutomaticamenteCodigoProducto.Enabled) && TipoOperacion == "I")
            {
                Regex reg = new Regex("[^a-zA-Z0-9 ]");
                string CodigoProductoAux = Productos.GenerarCodigoProducto(int.Parse(cBTipoProducto.SelectedValue.ToString()), reg.Replace(tBNombreProducto.Text.Normalize(NormalizationForm.FormD), ""));
                tBCodigoProducto.Text = CodigoProductoAux;
            }
        }

        private void tCProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoOperacion = "";
            if (tCProductos.SelectedIndex == 1)
            {
                if (tBCodigoProducto.Text.Length > 0)
                {
                    tBCodigoProductoPD.Text = tBCodigoProducto.Text;
                    tBNombreProductoPD.Text = tBNombreProducto.Text;
                    
                    DataTable DTpd = new DataTable();
                    DTpd = ProductosDescripcion.ListarProductosDescripcionPorCodigoProducto(tBCodigoProductoPD.Text.TrimEnd());
                    DTProductosDescripcion = DTpd;

                    DataTable DTpp = new DataTable();
                    DTpp = ProductosPropiedades.ListarProductosPropiedades();
                    DTProductosPropiedades = DTpp;

                    DGVProductosDescripcion.AutoGenerateColumns = false;
                    CPropiedad.DataPropertyName = "CodigoPropiedad";
                    CPropiedad.DataSource = DTProductosPropiedades;
                    CPropiedad.DisplayMember = "NombrePropiedad";
                    CPropiedad.ValueMember = "CodigoPropiedad";
                    DGVProductosDescripcion.ReadOnly = true;
                    DGVProductosDescripcion.DataSource = DTProductosDescripcion;
                    //dGVPlanPagos.DataSource = CreditosCuotas.ListarCreditoCuotasNumeroCredito(int.Parse(tBNumeroCredito.Text));
                    //Se carga la informacion de productos descripcion

                    tSBNuevaPropiedadProducto.Enabled = true;
                    tSBEditarPropiedadProducto.Enabled = true;
                    if (DGVProductosDescripcion.Rows.Count > 0)
                        tSBEliminarPropiedadProducto.Enabled = true;
                    else
                        tSBEliminarPropiedadProducto.Enabled = false;
                    tSBAceptarPropiedadProducto.Enabled = false;
                    tSBCancelarPropiedadProducto.Enabled = false;

                }
                else
                {
                    MessageBox.Show("No se ha seleccionado un producto del que se desea visualizar sus propiedades.");
                    tCProductos.SelectedIndex = 0;
                }
            }
            if (tCProductos.SelectedIndex == 2)
            {
                if (tBCodigoProducto.Text.Length > 0)
                {
                    tBCodigoProductoPI.Text = tBCodigoProducto.Text;
                    tBNombreProductoPI.Text = tBNombreProducto.Text;

                    DataTable DTpi = new DataTable();
                    DTpi = ProductosImagenes.ListarProductosImagenesPorProducto(tBCodigoProductoPI.Text.TrimEnd());
                    DTProductosImagenes = DTpi;

                    /*
                    DataTable DTpp = new DataTable();
                    DTpp = ProductosPropiedades.ListarProductosPropiedades();
                    DTProductosPropiedades = DTpp;
                    */

                    dGVProductosImagenes.AutoGenerateColumns = false;
                    CNumeroImagen.DataPropertyName = "NumeroImagen";
                    CRuta.DataPropertyName = "RutaImagenProducto";
                    

                    dGVProductosImagenes.ReadOnly = true;
                    dGVProductosImagenes.DataSource = DTProductosImagenes;

                    tSBNuevoProductoImagen.Enabled = true;
                    tSBEditarProductoImagen.Enabled = true;
                    if (dGVProductosImagenes.Rows.Count > 0)
                        tSBEliminarProductoImagen.Enabled = true;
                    else
                        tSBEliminarProductoImagen.Enabled = false;
                    tSBAceptarProductoImagen.Enabled = false;
                    tSBCancelarProductoImagen.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado un producto del que se desee visualizar sus imagenes.");
                    tCProductos.SelectedIndex = 0;
                }
            }
        }

        private void tSBNuevoPropidadProducto_Click(object sender, EventArgs e)
        {
            DGVProductosDescripcion.ReadOnly = false;
            DataRow NuevaFila;

            DataTable DTppd = new DataTable();

            DTppd = ProductosPropiedades.ListarPropiedadesDisponiblesPorCodigoProducto(tBCodigoProductoPD.Text);

            NuevaFila = DTProductosDescripcion.NewRow();
            NuevaFila["CodigoProducto"] = tBCodigoProducto.Text;
            NuevaFila["CodigoPropiedad"] = int.Parse(DTppd.Rows[0]["CodigoPropiedad"].ToString());
            NuevaFila["ValorPropiedad"] = "";

            DTProductosDescripcion.Rows.Add(NuevaFila);

            DGVProductosDescripcion.CurrentCell = DGVProductosDescripcion.Rows[DGVProductosDescripcion.Rows.Count - 1].Cells[0];
                        
            DataGridViewRow FilaSeleccionada = DGVProductosDescripcion.CurrentRow;
            FilaSeleccionada.Selected = true;
            FilaSeleccionada.Cells[1].Selected = true;
            DGVProductosDescripcion.CurrentCell = FilaSeleccionada.Cells[1];
            DGVProductosDescripcion.BeginEdit(true);

            TipoOperacion = "I";

            tSBNuevaPropiedadProducto.Enabled = false;
            tSBEditarPropiedadProducto.Enabled = false;
            tSBEliminarPropiedadProducto.Enabled = false;
            tSBAceptarPropiedadProducto.Enabled = true;
            tSBCancelarPropiedadProducto.Enabled = true;
        }

        private void tSBEditarPropiedadProducto_Click(object sender, EventArgs e)
        {
            DGVProductosDescripcion.ReadOnly = false;
            DataGridViewRow FilaSeleccionada = DGVProductosDescripcion.CurrentRow;
            FilaSeleccionada.Selected = true;
            FilaSeleccionada.Cells[1].Selected = true;
            DGVProductosDescripcion.CurrentCell = FilaSeleccionada.Cells[1];
            DGVProductosDescripcion.BeginEdit(true);
            
            
            TipoOperacion = "E";

            tSBNuevaPropiedadProducto.Enabled = false;
            tSBEditarPropiedadProducto.Enabled = false;
            tSBEliminarPropiedadProducto.Enabled = false;
            tSBAceptarPropiedadProducto.Enabled = true;
            tSBCancelarPropiedadProducto.Enabled = true;
        }

        private void tSBAceptarPropiedadProducto_Click(object sender, EventArgs e)
        {
            DGVProductosDescripcion.EndEdit();

            if (TipoOperacion == "I")
            { 
                ProductosDescripcion.InsertarProductoDescripcion(tBCodigoProducto.Text, int.Parse(DGVProductosDescripcion.Rows[DGVProductosDescripcion.CurrentRow.Index].Cells[0].Value.ToString()), DGVProductosDescripcion.Rows[DGVProductosDescripcion.CurrentRow.Index].Cells[1].Value.ToString());
            }

            if (TipoOperacion == "E")
            {
                ProductosDescripcion.ActualizarProductoDescripcion(tBCodigoProducto.Text, int.Parse(DGVProductosDescripcion.Rows[DGVProductosDescripcion.CurrentRow.Index].Cells[0].Value.ToString()), DGVProductosDescripcion.Rows[DGVProductosDescripcion.CurrentRow.Index].Cells[1].Value.ToString());
            }
            DGVProductosDescripcion.ReadOnly = true;
            tSBNuevaPropiedadProducto.Enabled = true;
            tSBEditarPropiedadProducto.Enabled = true;
            tSBEliminarPropiedadProducto.Enabled = true;
            tSBAceptarPropiedadProducto.Enabled = false;
            tSBCancelarPropiedadProducto.Enabled = false;
            TipoOperacion = "";
        }

        private void tSBEliminarPropiedadProducto_Click(object sender, EventArgs e)
        {
            string Mensaje = "¿Esta seguro que desea eliminar la caracteristica seleccionada?, recuerde que una vez aceptada la operacion es irreversible.";
            string Titulo = "Confirmación eliminación propiedad";
            MessageBoxButtons Botones = MessageBoxButtons.YesNo;
            MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
            DialogResult result;

            result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ProductosDescripcion.EliminarProductoDescripcion(tBCodigoProducto.Text, int.Parse(DGVProductosDescripcion.Rows[DGVProductosDescripcion.CurrentRow.Index].Cells[0].Value.ToString()));
                    DGVProductosDescripcion.Rows.RemoveAt(DGVProductosDescripcion.CurrentRow.Index);
                    if (DGVProductosDescripcion.Rows.Count > 0)
                        tSBEliminarPropiedadProducto.Enabled = true;
                    else
                        tSBEliminarPropiedadProducto.Enabled = false;
                }
                catch
                {

                }
                tSBNuevaPropiedadProducto.Enabled = true;
                tSBEditarPropiedadProducto.Enabled = true;
                tSBAceptarPropiedadProducto.Enabled = false;
                tSBCancelarPropiedadProducto.Enabled = false;
            }
        }

        private void dGVProductosImagenes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dGVProductosImagenes.Rows.Count > 0)
            {
                if (System.IO.File.Exists(dGVProductosImagenes.Rows[e.RowIndex].Cells[1].Value.ToString()))
                {
                    pBImagenProducto.Image = Image.FromFile(dGVProductosImagenes.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
            }
        }

        private void tSBAceptarProductoImagen_Click(object sender, EventArgs e)
        {
            dGVProductosImagenes.EndEdit();

            bool existe = Directory.Exists(RutaImagenDestino);

            if (!existe)
            {
                MessageBox.Show("El directorio {0} NO existe", RutaImagenDestino);
                MessageBox.Show(RutaAplicacion);
                string RutaNueva = System.IO.Path.Combine(RutaAplicacion, "Imagenes");
                System.IO.Directory.CreateDirectory(RutaNueva);
                RutaNueva = System.IO.Path.Combine(RutaNueva, "Productos");
                System.IO.Directory.CreateDirectory(RutaNueva);
            }

            try
            {
                if (TipoOperacion == "I")
                {
                    //ProductosImagenes.InsertarProductoImagen(tBCodigoProductoPI.Text, byte.Parse(dGVProductosImagenes.Rows[dGVProductosImagenes.CurrentRow.Index].Cells[0].Value.ToString()), dGVProductosImagenes.Rows[dGVProductosImagenes.CurrentRow.Index].Cells[1].Value.ToString());
                    //ProductosImagenes.InsertarProductoImagen(tBCodigoProductoPI.Text, byte.Parse(dGVProductosImagenes.Rows[dGVProductosImagenes.CurrentRow.Index].Cells[0].Value.ToString()), "\\\\" + NombreEquipoServidor + "\\Imagenes\\Productos\\" + NombreImagenDestino);
                    pBImagenProducto.Image.Save("\\\\" + NombreEquipoServidor + "\\Imagenes\\Productos\\" + NombreImagenDestino, ImageFormat.Jpeg);
                }

                if (TipoOperacion == "E")
                {
                   // ProductosImagenes.ActualizarProductoImagen(tBCodigoProductoPI.Text, byte.Parse(dGVProductosImagenes.Rows[dGVProductosImagenes.CurrentRow.Index].Cells[0].Value.ToString()), "\\\\" + NombreEquipoServidor + "\\Imagenes\\Productos\\" + NombreImagenDestino);
                    //pBImagenProducto.Image.Save(RutaImagenDestino + NombreImagenDestino, ImageFormat.Jpeg);
                    pBImagenProducto.Image.Save("\\\\" + NombreEquipoServidor + "\\Imagenes\\Productos\\" + NombreImagenDestino, ImageFormat.Jpeg);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio la siguiente Excepción " + ex.Message + "\r\n \\\\" + NombreEquipoServidor + "\\Imagenes\\Productos\\" + NombreImagenDestino);                
            }
            dGVProductosImagenes.ReadOnly = true;
            tSBNuevoProductoImagen.Enabled = true;
            tSBEditarProductoImagen.Enabled = true;
            tSBEliminarProductoImagen.Enabled = true;
            tSBAceptarProductoImagen.Enabled = false;
            tSBCancelarProductoImagen.Enabled = false;
            TipoOperacion = ""; 
        }

        private void tSBNuevoProductoImagen_Click(object sender, EventArgs e)
        {
            dGVProductosImagenes.ReadOnly = false;
            DataRow NuevaFila;

            NuevaFila = DTProductosImagenes.NewRow();
            NuevaFila["CodigoProducto"] = tBCodigoProducto.Text;
            NuevaFila["NumeroImagen"] = ProductosImagenes.ObtenerSiguienteNumeroProductoImagen(tBCodigoProductoPI.Text);
            NuevaFila["RutaImagenProducto"] = "";

            DTProductosImagenes.Rows.Add(NuevaFila);

            TipoOperacion = "I";

            tSBNuevoProductoImagen.Enabled = false;
            tSBEditarProductoImagen.Enabled = false;
            tSBEliminarProductoImagen.Enabled = false;
            tSBAceptarProductoImagen.Enabled = true;
            tSBCancelarProductoImagen.Enabled = true;
        }

        private void tSBEditarProductoImagen_Click(object sender, EventArgs e)
        {
            dGVProductosImagenes.ReadOnly = false;
            DataGridViewRow FilaSeleccionada = dGVProductosImagenes.CurrentRow;
            FilaSeleccionada.Selected = true;
            FilaSeleccionada.Cells[1].Selected = true;
            dGVProductosImagenes.CurrentCell = FilaSeleccionada.Cells[1];
            dGVProductosImagenes.BeginEdit(true);

            TipoOperacion = "E";

            tSBNuevoProductoImagen.Enabled = false;
            tSBEditarProductoImagen.Enabled = false;
            tSBEliminarProductoImagen.Enabled = false;
            tSBAceptarProductoImagen.Enabled = true;
            tSBCancelarProductoImagen.Enabled = true;
        }

        private void tSBCancelarPropiedadProducto_Click(object sender, EventArgs e)
        {
            DGVProductosDescripcion.CancelEdit();

            if (TipoOperacion == "I")
            {
                TipoOperacion = "";
                DTProductosDescripcion.Rows.RemoveAt(DTProductosDescripcion.Rows.Count - 1);
            }

            DGVProductosDescripcion.ReadOnly = true;
            tSBNuevaPropiedadProducto.Enabled = true;
            tSBEditarPropiedadProducto.Enabled = true;
            tSBEliminarPropiedadProducto.Enabled = true;
            tSBAceptarPropiedadProducto.Enabled = false;
            tSBCancelarPropiedadProducto.Enabled = false;
        }

        private void tSBCancelarProductoImagen_Click(object sender, EventArgs e)
        {
            dGVProductosImagenes.CancelEdit();

            if (TipoOperacion == "I")
            {
                TipoOperacion = "";
                dGVProductosImagenes.Rows.RemoveAt(dGVProductosImagenes.Rows.Count - 1);
            }

            dGVProductosImagenes.ReadOnly = true;
            tSBNuevoProductoImagen.Enabled = true;
            tSBEditarProductoImagen.Enabled = true;
            tSBEliminarProductoImagen.Enabled = true;
            tSBAceptarProductoImagen.Enabled = false;
            tSBCancelarProductoImagen.Enabled = false;
        }

        private void cBGenerarAutomaticamenteCodigoProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (TipoOperacion == "I" || TipoOperacion == "E")
                tBCodigoProducto.ReadOnly = cBGenerarAutomaticamenteCodigoProducto.Checked;
        }

        private void cBCopiarCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (TipoOperacion == "I" || TipoOperacion == "E")
                tBCodigoProductoFabricante.ReadOnly = cBCopiarCodigo.Checked;
        }

        private void tBCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            if(cBCopiarCodigo.Checked)
            {
                tBCodigoProductoFabricante.Text = tBCodigoProducto.Text;
            }
        }

        private void DGVProductosDescripcion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if((e.RowIndex != DGVProductosDescripcion.Rows.Count - 1) && (TipoOperacion == "I"))
            {
                DGVProductosDescripcion.Rows.RemoveAt(DGVProductosDescripcion.Rows.Count - 1);
                DGVProductosDescripcion.ReadOnly = true;
                tSBNuevaPropiedadProducto.Enabled = true;
                tSBEditarPropiedadProducto.Enabled = true;
                if (DGVProductosDescripcion.Rows.Count > 0)
                    tSBEliminarPropiedadProducto.Enabled = true;
                else
                    tSBEliminarPropiedadProducto.Enabled = false;
                tSBAceptarPropiedadProducto.Enabled = false;
                tSBCancelarPropiedadProducto.Enabled = false;
                TipoOperacion = "";
            }
        }

        private void dGVProductosImagenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex != dGVProductosImagenes.Rows.Count - 1) && (TipoOperacion == "I"))
            {
                dGVProductosImagenes.Rows.RemoveAt(dGVProductosImagenes.Rows.Count - 1);
                dGVProductosImagenes.ReadOnly = true;
                tSBNuevoProductoImagen.Enabled = true;
                tSBEditarProductoImagen.Enabled = true;
                if(dGVProductosImagenes.Rows.Count > 0)
                    tSBEliminarProductoImagen.Enabled = true;
                else
                    tSBEliminarProductoImagen.Enabled = false;
                tSBAceptarProductoImagen.Enabled = false;
                tSBCancelarProductoImagen.Enabled = false;
                TipoOperacion = "";
            }
            if ((e.ColumnIndex == 2) && (TipoOperacion == "I") || (TipoOperacion == "E"))
            {
                //Definimos los filtros de archivos a permitir, en este caso imagenes
                oFDImagenProducto.Filter = "Archivos BMP (*.bmp)|*.bmp|Archivos GIF (*.gif)|*.gif|Archivos JGP (*.jpg)|*.jpg|Archivo PNG (*.png)|*.png|All (*.*)|*.* ";
                ///Establece que filtro se mostrará por defecto en este caso, 3=jpg
                oFDImagenProducto.FilterIndex = 3;
                ///Esto aparece en el Nombre del archivo a seleccionar, se puede quitar no es fundamental
                oFDImagenProducto.FileName = "Seleccione una imagen";
                //El titulo de la Ventana....
                oFDImagenProducto.Title = "Imagen de produtos";
                //El directorio que por defecto al abrir, para cada contrapleca del Path colocar \\ C:\\Fotitos\\Wizard y así sucesivamente
                oFDImagenProducto.InitialDirectory = RutaAplicacion;

                if (oFDImagenProducto.ShowDialog() == DialogResult.OK)
                {
                    /// Si esto se cumple, capturamos la propiedad File Name y la guardamos en la variable Garrobito
                    RutaImagenOrigen = oFDImagenProducto.FileName;
                    RutaImagenDestino = RutaAplicacion + @"\Imagenes\Productos\";
                    NombreImagenDestino = tBCodigoProductoPI.Text.TrimEnd() + "-" + dGVProductosImagenes.Rows[e.RowIndex].Cells[0].Value.ToString() + ".jpg";
                    tSSLRuta.Text = "Ruta origen: " + RutaImagenOrigen + NombreImagenDestino;

                    //dGVProductosImagenes.Rows[e.RowIndex].Cells[1].Value = RutaAplicacion + @"\Imagenes\Productos\" + NombreImagenDestino;
                    dGVProductosImagenes.Rows[e.RowIndex].Cells[1].Value = RutaImagenDestino + NombreImagenDestino;
                    //Por ultimo se la asignamos al PictureBox
                    pBImagenProducto.Image = Image.FromFile(RutaImagenOrigen);
                }   
            }
        }

        private void tSBEliminarProductoImagen_Click(object sender, EventArgs e)
        {
            string Mensaje = "¿Esta seguro que desea eliminar la imagen seleccionada?, recuerde que una vez aceptada la operacion es irreversible.";
            string Titulo = "Confirmación eliminación imagen";
            MessageBoxButtons Botones = MessageBoxButtons.YesNo;
            MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
            DialogResult result;

            result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ProductosImagenes.EliminarProductoImagen(tBCodigoProductoPI.Text, int.Parse(dGVProductosImagenes.Rows[dGVProductosImagenes.CurrentRow.Index].Cells[0].Value.ToString()));
                    dGVProductosImagenes.Rows.RemoveAt(dGVProductosImagenes.CurrentRow.Index);
                    if (DGVProductosDescripcion.Rows.Count > 0)
                        tSBEliminarProductoImagen.Enabled = true;
                    else
                        tSBEliminarProductoImagen.Enabled = false;
                }
                catch
                {

                }
                tSBNuevoProductoImagen.Enabled = true;
                tSBEditarProductoImagen.Enabled = true;
                tSBAceptarProductoImagen.Enabled = false;
                tSBCancelarProductoImagen.Enabled = false;
            }
        }

        private void FProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pBImagenProducto.Image != null)
                pBImagenProducto.Image.Dispose();
            pBImagenProducto.Image = null;
        }
		private void cBActualizarPreciosVenta_CheckedChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TipoOperacion))
            {
                txtIncremento.Visible = cBActualizarPreciosVenta.Checked;
            }
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
