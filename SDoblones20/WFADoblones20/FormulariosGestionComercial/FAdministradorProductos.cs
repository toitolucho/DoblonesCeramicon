using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using CLCLN.GestionComercial;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FAdministradorProductos : Form
    {
        private ProductosTiposCLN ProductosTipos = new ProductosTiposCLN();
        private ProductosCLN Productos = new ProductosCLN();
        private ProductosMarcasCLN ProductosMarcas = new ProductosMarcasCLN();
        private ProductosUnidadesCLN ProductosUnidades = new ProductosUnidadesCLN();
        private ProductosPropiedadesCLN ProductosPropiedades = new ProductosPropiedadesCLN();
        private ProductosDescripcionCLN ProductosDescripcion = new ProductosDescripcionCLN();
        private ProductosImagenesCLN ProductosImagenes = new ProductosImagenesCLN();
        private ProductosCompuestosCLN ProductosCompuestos = new ProductosCompuestosCLN();

        private DataTable DTAuxiliar = new DataTable();
        private int CodigoTipoProductoSeleccionado = 0;
        private int? CodigoTipoProductoPadreSeleccionado = 0;
        private int? CodigoTipoProductoPadreDestino = 0;
        private string NombreTipoProductoSeleccionado = "";
        private string NombreCortoTipoProductoSeleccionado = "";
        private string DescripcionTipoProductoSeleccionado = "";
        private int NivelSeleccionado = 0;

        private string CodigoProductoSeleccionado = "";
        private int CodigoProductoPropiedadSeleccionada = 0;
        private byte NumeroImagenSeleccionada = 0;
        private string CodigoProductoComponenteSeleccionado = "";
        private DataTable DTResultadoBusquedaProductos = new DataTable();

        ImageList ILProductosTipos = new ImageList();

        int NumeroSede = 0;
        int NumeroPC = 0;
        int CodigoUsuario = 0;
        string RutaDirectorioImagenes = "";


        public FAdministradorProductos(int NumeroSede, int NumeroPC, int CodigoUsuario, bool PermitirInsertar, bool PermitirEditar, bool PermitirEliminar, bool PermitirNavegar, bool PermitirReportes, string RutaDireImag)
        {
            InitializeComponent();
            this.NumeroSede = NumeroSede;
            this.NumeroPC = NumeroPC;
            this.CodigoUsuario = CodigoUsuario;
            this.RutaDirectorioImagenes = RutaDireImag;

            CargarColumnaslVProductos();
            CargarColumnaslVProductosPropiedades();
            CargarColumnaslVProductosImagenes();
            CargarColumnaslVProductosCompuestos();
            CargarImagenes();
            //tCComponentes.TabPages.Remove(tPComponentes);
          }

        private void CargarImagenes()
        {

            ILProductosTipos.TransparentColor = Color.Blue;
            ILProductosTipos.ColorDepth = ColorDepth.Depth32Bit;
            ILProductosTipos.ImageSize = new Size(16, 16);

            ILProductosTipos.Images.Add(Image.FromFile(@".\Iconos\16\tipo_producto_vacio.png"));
            ILProductosTipos.Images.Add(Image.FromFile(@".\Iconos\16\tipo_producto.png"));
            ILProductosTipos.Images.Add(Image.FromFile(@".\Iconos\16\producto.png"));

            tVProductostipos.ImageList = ILProductosTipos;

            tVProductostipos.Nodes.Clear();
            CargarNodosHijos((TreeNode)null, null);

            //if (tVProductostipos.Nodes.Count <= 0)
            //{
                //Botones barra de menus
                tSMINuevoTipoProducto.Enabled = true;
                tSMINuevoTipoProductoPadre.Enabled = true;
                tSMINuevoTipoProductoHijo.Enabled = false;
                tSMIEditarTipoProducto.Enabled = false;
                tSMIEliminarTipoProducto.Enabled = false;
                TSMIConvertirEnTipoProductoRaiz.Enabled = false;

                tSBAgregarProducto.Enabled = false;
                tSBEditarProducto.Enabled = false;
                tSBEliminarProducto.Enabled = false;

                //Opciones menus contextuales
                tSMIAgregarProductoTipoPadre.Enabled = true;
                tSMIAgregarProductoTipo.Enabled = false;
                tSMIEditarElementoActual.Enabled = false;
                tSMIEliminarElementoActual.Enabled = false;
                TSMIAgregarProducto1.Enabled = false;

                TSMIAgregarProducto2.Enabled = false;
                TSMIEditarProducto.Enabled = false;
                TSMIEliminarProducto.Enabled = false;
                TSMICopiarProducto.Enabled = false;
                TSMIAgregarPropiedad1.Enabled = false;
                TSMIAgregarImagen1.Enabled = false;
                TSMIAgregarComponente1.Enabled = false;

                TSMIAgregarPropiedad2.Enabled = false;
                TSMIEditarPropiedad.Enabled = false;
                TSMIEliminarPropiedad.Enabled = false;

                TSMIAgregarImagen2.Enabled = false;
                TSMIEditarImagen.Enabled = false;
                TSMIEliminarImagen.Enabled = false;
            //}
        }

        private void FProductosTipos_Load(object sender, EventArgs e)
        {
            
            
        }

        void CargarNodosHijos(TreeNode NodoPadre, int? CodigoTipoProductoPadre)
        {
            DataTable DTTiposProductos = new DataTable();
            DTTiposProductos = ProductosTipos.ListarProductosTiposProductoTipoPadre(CodigoTipoProductoPadre);
            foreach(DataRow FilaTipoProducto in DTTiposProductos.Rows)
            {
                int? CotigoTipoProductoPadreAux = null;
                if (FilaTipoProducto["CodigoTipoProductoPadre"].ToString() != "")
                    CotigoTipoProductoPadreAux = int.Parse(FilaTipoProducto["CodigoTipoProductoPadre"].ToString());

                ProductoTipo pt = new ProductoTipo(
                int.Parse(FilaTipoProducto["CodigoTipoProducto"].ToString()),
                CotigoTipoProductoPadreAux,
                FilaTipoProducto["NombreTipoProducto"].ToString(),
                FilaTipoProducto["NombreCortoTipoProducto"].ToString(),
                FilaTipoProducto["DescripcionTipoProducto"].ToString(),
                byte.Parse(FilaTipoProducto["Nivel"].ToString()));

                if(NodoPadre == null)
                {
                    TreeNode NodoNuevo = tVProductostipos.Nodes.Add(FilaTipoProducto["NombreTipoProducto"].ToString());
                    NodoNuevo.Tag = pt;
                    NodoNuevo.ImageIndex = 0;
                    NodoNuevo.SelectedImageIndex = 0;
                    CargarNodosHijos(NodoNuevo, int.Parse(FilaTipoProducto["CodigoTipoProducto"].ToString()));
                }
                else
                {
                    TreeNode NodoNuevo = NodoPadre.Nodes.Add(FilaTipoProducto["NombreTipoProducto"].ToString());
                    NodoNuevo.Tag = pt;
                    
                    /*
                    if (NodoPadre.Level > 0)
                    {
                        NodoPadre.ImageIndex = 1;
                        NodoPadre.SelectedImageIndex = 1;
                    }
                    else
                    {
                        NodoPadre.ImageIndex = 0;
                        NodoPadre.SelectedImageIndex = 0;
                    }
                    */
                        NodoNuevo.ImageIndex = 0;
                        NodoNuevo.SelectedImageIndex = 0;

                    CargarNodosHijos(NodoNuevo, int.Parse(FilaTipoProducto["CodigoTipoProducto"].ToString()));
                }
                
            }
		}

        void EliminarNodosHijos(TreeNode NodoPadre)
        {
            if (NodoPadre.Nodes.Count > 0)
            {
                foreach (TreeNode NodoActual in NodoPadre.Nodes)
                {
                    EliminarNodosHijos(NodoActual);
                }
            }
            
            ProductosTipos.EliminarProductoTipo(((ProductoTipo)NodoPadre.Tag).Codigo);
            NodoPadre.Remove();
        }	
        
        private void CargarInformacionNodo(TreeNode NodoSeleccionado)
        {
            //DataTable DTAux = new DataTable();
            //int CodiTipoProd = 0;
            //int? CodiTipoProdPadr = 0;
            //string NombTipoProd = "";
            //string NombCortTipoProd = "";
            //string DescTipoProd = "";
            //byte Nive;

            
            //if (NodoSeleccionado != null)
            //{
            //    CodiTipoProd = ((ProductoTipo)tVProductostipos.SelectedNode.Tag).Codigo;
            //    CodiTipoProdPadr = ((ProductoTipo)tVProductostipos.SelectedNode.Tag).CodigoPadre;
            //    NombTipoProd = ((ProductoTipo)tVProductostipos.SelectedNode.Tag).Nombre;
            //    NombCortTipoProd = ((ProductoTipo)tVProductostipos.SelectedNode.Tag).NombreCorto;
            //    DescTipoProd = ((ProductoTipo)tVProductostipos.SelectedNode.Tag).Descripcion;
            //    Nive = ((ProductoTipo)tVProductostipos.SelectedNode.Tag).Niv;
            //    tBCodigoTipoProducto.Text = CodiTipoProd.ToString();
            //    tBNombreTipoProducto.Text = NombTipoProd;
            //    tBNombreCortoTipoProducto.Text = NombCortTipoProd;
            //    tBDescripcionTipoProducto.Text = DescTipoProd;
            //    tBNivel.Text = Nive.ToString();
            //}
            //else
            //{
            //    InicializarControles();
            //}
        }
        
        private void CargarColumnaslVProductos()
        {
            lVProductos.BeginUpdate();
            if (lVProductos.Columns.Count == 0)
            {
                lVProductos.Columns.Add("Codigo producto", 100, HorizontalAlignment.Left);
                lVProductos.Columns.Add("Codigo fabricante", 100, HorizontalAlignment.Left);
                lVProductos.Columns.Add("Nombre 1", 150, HorizontalAlignment.Left);
                lVProductos.Columns.Add("Nombre 2", 150, HorizontalAlignment.Left);
                lVProductos.Columns.Add("Nombre 3", 150, HorizontalAlignment.Left);
                lVProductos.Columns.Add("Marca", 150, HorizontalAlignment.Left);
                lVProductos.Columns.Add("Unidad", 100, HorizontalAlignment.Left);
                lVProductos.Columns.Add("Calculo inventario", 100, HorizontalAlignment.Left);
                lVProductos.Columns.Add("Llenar PE", 50, HorizontalAlignment.Left);
                lVProductos.Columns.Add("Tangible", 50, HorizontalAlignment.Left);
                lVProductos.Columns.Add("Simple", 50, HorizontalAlignment.Left);
                lVProductos.Columns.Add("Calcular precio venta", 50, HorizontalAlignment.Left);
                lVProductos.Columns.Add("Descripción", 150, HorizontalAlignment.Left);
                lVProductos.Columns.Add("Observaciones", 150, HorizontalAlignment.Left);
            }
            lVProductos.EndUpdate();

        }

        private void CargarColumnaslVProductosPropiedades()
        {
            lVProductosPropiedades.BeginUpdate();
            if (lVProductosPropiedades.Columns.Count == 0)
            {
                lVProductosPropiedades.Columns.Add("Propiedad", 200, HorizontalAlignment.Left);
                lVProductosPropiedades.Columns.Add("Valor", 350, HorizontalAlignment.Left);
            }
            lVProductosPropiedades.EndUpdate();

        }

        private void CargarColumnaslVProductosImagenes()
        {
            lVProductosImagenes.BeginUpdate();
            if (lVProductosImagenes.Columns.Count == 0)
            {
                lVProductosImagenes.Columns.Add("Nº", 50, HorizontalAlignment.Left);
                lVProductosImagenes.Columns.Add("Nombre", 200, HorizontalAlignment.Left);
                lVProductosImagenes.Columns.Add("Archivo", 250, HorizontalAlignment.Left);
            }
            lVProductosImagenes.EndUpdate();
        }

        private void CargarColumnaslVProductosCompuestos()
        {
            lVProductosCompuestos.BeginUpdate();
            if (lVProductosCompuestos.Columns.Count == 0)
            {
                lVProductosCompuestos.Columns.Add("Nº", 50, HorizontalAlignment.Left);
                lVProductosCompuestos.Columns.Add("Codigo", 70, HorizontalAlignment.Left);
                lVProductosCompuestos.Columns.Add("Nombre", 250, HorizontalAlignment.Left);
                lVProductosCompuestos.Columns.Add("Cantidad", 250, HorizontalAlignment.Left);
            }
            lVProductosImagenes.EndUpdate();
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void tVProductostipos_MouseDown(object sender, MouseEventArgs e)
        {
            //Botones barra de menus
            tSMINuevoTipoProducto.Enabled = true;
            tSMINuevoTipoProductoPadre.Enabled = true;
            tSMINuevoTipoProductoHijo.Enabled = false;
            tSMIEditarTipoProducto.Enabled = false;
            tSMIEliminarTipoProducto.Enabled = false;
            TSMIConvertirEnTipoProductoRaiz.Enabled = false;

            tSBAgregarProducto.Enabled = false;
            tSBEditarProducto.Enabled = false;
            tSBEliminarProducto.Enabled = false;

            //Opciones menus contextuales
            tSMIAgregarProductoTipoPadre.Enabled = true;
            tSMIAgregarProductoTipo.Enabled = false;
            tSMIEditarElementoActual.Enabled = false;
            tSMIEliminarElementoActual.Enabled = false;
            TSMIAgregarProducto1.Enabled = false;

            TSMIAgregarProducto2.Enabled = false;
            TSMIEditarProducto.Enabled = false;
            TSMIEliminarProducto.Enabled = false;
            TSMICopiarProducto.Enabled = false;
            TSMIAgregarPropiedad1.Enabled = false;
            TSMIAgregarImagen1.Enabled = false;
            TSMIAgregarComponente1.Enabled = false;

            TSMIAgregarPropiedad2.Enabled = false;
            TSMIEditarPropiedad.Enabled = false;
            TSMIEliminarPropiedad.Enabled = false;

            TSMIAgregarImagen2.Enabled = false;
            TSMIEditarImagen.Enabled = false;
            TSMIEliminarImagen.Enabled = false;

            TreeNode NodoActual = tVProductostipos.GetNodeAt(new Point(e.X, e.Y));
            if (NodoActual != null)
            {
                tVProductostipos.SelectedNode = NodoActual;

                CodigoTipoProductoSeleccionado = ((ProductoTipo)NodoActual.Tag).Codigo;
                CodigoTipoProductoPadreSeleccionado = ((ProductoTipo)NodoActual.Tag).CodigoPadre;
                NombreTipoProductoSeleccionado = ((ProductoTipo)NodoActual.Tag).Nombre;
                NombreCortoTipoProductoSeleccionado = ((ProductoTipo)NodoActual.Tag).NombreCorto;
                DescripcionTipoProductoSeleccionado = ((ProductoTipo)NodoActual.Tag).Descripcion;
                NivelSeleccionado = ((ProductoTipo)NodoActual.Tag).Niv;

                //Botones barra de menus
                tSMINuevoTipoProductoHijo.Enabled = true;
                tSMIEditarTipoProducto.Enabled = true;
                tSMIEliminarTipoProducto.Enabled = true;
                if(CodigoTipoProductoPadreSeleccionado != null)
                    TSMIConvertirEnTipoProductoRaiz.Enabled = true;

                tSBAgregarProducto.Enabled = true;
                
                //Opciones menus contextuales
                tSMIAgregarProductoTipo.Enabled = true;
                tSMIEditarElementoActual.Enabled = true;
                tSMIEliminarElementoActual.Enabled = true;
                TSMIAgregarProducto1.Enabled = true;
                TSMIAgregarProducto2.Enabled = true;

            
                if (e.Button == MouseButtons.Right)
                {
                    
                }
                if (e.Button == MouseButtons.Left)
                {
                    //MostrarTarifasPersonalizadas();
                   
                    DTResultadoBusquedaProductos = Productos.ListarProductosPorTipoProducto(CodigoTipoProductoSeleccionado);
                    CargarlVProductos(DTResultadoBusquedaProductos);
                    if (DTResultadoBusquedaProductos.Rows.Count > 0)
                    {
                        statusStrip1.Items[0].Text = "Productos: " + DTResultadoBusquedaProductos.Rows.Count.ToString();
                    }
                    else
                    {
                        statusStrip1.Items[0].Text = "No existen productos para tipo de producto.";
                    }
                }

                //tSBAgregarCuota.Enabled = true;
                //tSBEditarCuota.Enabled = true;
                //tSBEliminarCuota.Enabled = true;
            }
        }

        private void CargarlVProductos(DataTable DTOrigenDatos)
        {

            lVProductos.Items.Clear();

            foreach (DataRow FilaActual in DTOrigenDatos.Rows)
            {
                ListViewItem ElementoLVI = new ListViewItem(FilaActual["CodigoProducto"].ToString().Trim());
                ElementoLVI.ImageIndex = 0;
                ElementoLVI.SubItems.Add(FilaActual["CodigoProductoFabricante"].ToString().Trim());
                ElementoLVI.SubItems.Add(FilaActual["NombreProducto"].ToString());
                ElementoLVI.SubItems.Add(FilaActual["NombreProducto1"].ToString());
                ElementoLVI.SubItems.Add(FilaActual["NombreProducto2"].ToString());

                string NombreMarcaProducto = ProductosMarcas.ObtenerProductoMarca(int.Parse(FilaActual["CodigoMarcaProducto"].ToString())).Rows[0]["NombreMarcaProducto"].ToString();
                ElementoLVI.SubItems.Add(NombreMarcaProducto.Trim());
                
                string NombreUnidadProdcuto = ProductosUnidades.ObtenerProductoUnidad(int.Parse(FilaActual["CodigoUnidad"].ToString())).Rows[0]["NombreUnidad"].ToString();
                ElementoLVI.SubItems.Add(NombreUnidadProdcuto.Trim());

                string NombreTipoCalculoInventario = "";
                if (FilaActual["CodigoTipoCalculoInventario"].ToString() == "P")
                    NombreTipoCalculoInventario = "PEPS";
                else if (FilaActual["CodigoTipoCalculoInventario"].ToString() == "U")
                    NombreTipoCalculoInventario = "UEPS";
                else if (FilaActual["CodigoTipoCalculoInventario"].ToString() == "O")
                    NombreTipoCalculoInventario = "PONDERADO";
                else if (FilaActual["CodigoTipoCalculoInventario"].ToString() == "B")
                    NombreTipoCalculoInventario = "PRECIO MAS BAJO";
                else if (FilaActual["CodigoTipoCalculoInventario"].ToString() == "A")
                    NombreTipoCalculoInventario = "PRECIO MAS ALTO";
                else if (FilaActual["CodigoTipoCalculoInventario"].ToString() == "U")
                    NombreTipoCalculoInventario = "UEPS";
                else if (FilaActual["CodigoTipoCalculoInventario"].ToString() == "T")
                    NombreTipoCalculoInventario = "ULTIMO PRECIO";

                ElementoLVI.SubItems.Add(NombreTipoCalculoInventario);
                ElementoLVI.SubItems.Add(FilaActual["LlenarCodigoPE"].ToString());
                ElementoLVI.SubItems.Add(FilaActual["ProductoTangible"].ToString());
                ElementoLVI.SubItems.Add(FilaActual["ProductoSimple"].ToString());
                ElementoLVI.SubItems.Add(FilaActual["CalcularPrecioVenta"].ToString());
                ElementoLVI.SubItems.Add(FilaActual["Descripcion"].ToString());
                ElementoLVI.SubItems.Add(FilaActual["Observaciones"].ToString());

                lVProductos.Items.Add(ElementoLVI);
            }
        }

        private void CargarlVProductosPropiedades(DataTable DTOrigenDatos)
        {
            lVProductosPropiedades.Items.Clear();

            foreach (DataRow FilaActual in DTOrigenDatos.Rows)
            {
                string NombrePropiedadProducto = ProductosPropiedades.ObtenerProductoPropiedad(int.Parse(FilaActual["CodigoPropiedad"].ToString())).Rows[0]["NombrePropiedad"].ToString();
                ListViewItem ElementoLVI = new ListViewItem(NombrePropiedadProducto.Trim());
                ElementoLVI.Tag = FilaActual["CodigoPropiedad"].ToString();
                ElementoLVI.ImageIndex = 0;
                ElementoLVI.SubItems.Add(FilaActual["ValorPropiedad"].ToString());
                lVProductosPropiedades.Items.Add(ElementoLVI);
            }
        }

        private void CargarlVProductosImagenes(DataTable DTOrigenDatos)
        {
            lVProductosImagenes.Items.Clear();

            foreach (DataRow FilaActual in DTOrigenDatos.Rows)
            {
                ListViewItem ElementoLVI = new ListViewItem(FilaActual["NumeroImagen"].ToString());
                ElementoLVI.ImageIndex = 0;
                ElementoLVI.SubItems.Add(FilaActual["NombreImagen"].ToString());
                ElementoLVI.SubItems.Add(FilaActual["RutaArchivoImagen"].ToString());
                
                lVProductosImagenes.Items.Add(ElementoLVI);
            }
        }

        private void CargarlVProductosCompuestos(DataTable DTOrigenDatos)
        {
            lVProductosCompuestos.Items.Clear();

            foreach (DataRow FilaActual in DTOrigenDatos.Rows)
            {
                ListViewItem ElementoLVI = new ListViewItem(FilaActual["NumeroComponente"].ToString());
                ElementoLVI.ImageIndex = 0;
                ElementoLVI.SubItems.Add(FilaActual["CodigoProductoComponente"].ToString());
                string NombreProductoComponente = Productos.ObtenerProducto(FilaActual["CodigoProductoComponente"].ToString()).Rows[0]["NombreProducto"].ToString();
                ElementoLVI.SubItems.Add(NombreProductoComponente);
                ElementoLVI.SubItems.Add(FilaActual["Cantidad"].ToString());

                lVProductosCompuestos.Items.Add(ElementoLVI);
            }
        }

        private void tSMIAgregarProductoTipo_Click(object sender, EventArgs e)
        {
            FAgregarEditarProductoTipo fAETP = new FAgregarEditarProductoTipo();
            fAETP.Text = "Agregar tipo de producto";
            fAETP.ShowDialog();

            if (fAETP.DialogResult == DialogResult.OK)
            {
                int? CodigoTipoProducto = 0;
                NivelSeleccionado++;
                ProductosTipos.InsertarProductoTipo(CodigoTipoProductoSeleccionado, fAETP.NombreTipoProducto, fAETP.NombreCortoTipoProducto, fAETP.DescripcionTipoProducto, NivelSeleccionado, ref CodigoTipoProducto);
                DataTable DTAuxiliarPT = new DataTable();
                DTAuxiliarPT = ProductosTipos.ObtenerProductoTipo(CodigoTipoProducto.Value);
                ProductoTipo PTP = new ProductoTipo(int.Parse(DTAuxiliarPT.Rows[0][0].ToString()), int.Parse(DTAuxiliarPT.Rows[0][1].ToString()), DTAuxiliarPT.Rows[0][2].ToString(), DTAuxiliarPT.Rows[0][3].ToString(), DTAuxiliarPT.Rows[0][4].ToString(), int.Parse(DTAuxiliarPT.Rows[0][5].ToString()));
                TreeNode NodoProductoTipoPadre = new TreeNode(fAETP.NombreTipoProducto);
                NodoProductoTipoPadre.Tag = PTP;
                NodoProductoTipoPadre.ImageIndex = 0;
                NodoProductoTipoPadre.SelectedImageIndex = 0;
                tVProductostipos.SelectedNode.Nodes.Add(NodoProductoTipoPadre);
                tVProductostipos.SelectedNode.Expand();
            }
            fAETP.Dispose();
        }

        private void tSMIAgregarProductoTipoPadre_Click(object sender, EventArgs e)
        {
            NombreTipoProductoSeleccionado = "";
            NombreCortoTipoProductoSeleccionado = "";
            DescripcionTipoProductoSeleccionado = "";

            FAgregarEditarProductoTipo fAETP = new FAgregarEditarProductoTipo(NombreTipoProductoSeleccionado, NombreCortoTipoProductoSeleccionado, DescripcionTipoProductoSeleccionado);
            fAETP.Text = "Nuevo tipo de producto base";
            fAETP.ShowDialog();

            if (fAETP.DialogResult == DialogResult.OK)
            {
                int? CodigoTipoProducto = 0;
                ProductosTipos.InsertarProductoTipo(fAETP.CodigoTipoProductoPadre, fAETP.NombreTipoProducto, fAETP.NombreCortoTipoProducto, fAETP.DescripcionTipoProducto, 0, ref CodigoTipoProducto);
                DataTable DTAuxiliarPT = new DataTable();
                DTAuxiliarPT = ProductosTipos.ObtenerProductoTipo(CodigoTipoProducto.Value);
                ProductoTipo PTP = new ProductoTipo(int.Parse(DTAuxiliarPT.Rows[0][0].ToString()), null, DTAuxiliarPT.Rows[0][2].ToString(), DTAuxiliarPT.Rows[0][3].ToString(), DTAuxiliarPT.Rows[0][4].ToString(), byte.Parse(DTAuxiliarPT.Rows[0][5].ToString()));
                
                TreeNode NodoProductoTipoPadre = new TreeNode(fAETP.NombreTipoProducto);
                NodoProductoTipoPadre.Tag = PTP;
                NodoProductoTipoPadre.ImageIndex = 0;
                NodoProductoTipoPadre.SelectedImageIndex = 0;
                tVProductostipos.Nodes.Add(NodoProductoTipoPadre);
                tVProductostipos.SelectedNode = NodoProductoTipoPadre;
                //tVProductostipos.SelectedNode.Expand();
            }
            fAETP.Dispose();

            tSMINuevoTipoProducto.Enabled = true;
            tSMIEditarTipoProducto.Enabled = true;
            tSMIEliminarTipoProducto.Enabled = true;

            tSBAgregarProducto.Enabled = true;
            tSBEditarProducto.Enabled = false;
            tSBEliminarProducto.Enabled = false;
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            //if (TipoOperacion == "IP")
            //{
            //    ProductosTipos.InsertarProductoTipo(null, tBNombreTipoProducto.Text, tBNombreCortoTipoProducto.Text, tBDescripcionTipoProducto.Text, 0);
            //    DataTable DTAuxiliarPT = new DataTable();
            //    DTAuxiliarPT = ProductosTipos.ObtenerProductoTipoNombre(tBNombreTipoProducto.Text);
            //    ProductoTipo PTP = new ProductoTipo(int.Parse(DTAuxiliarPT.Rows[0][0].ToString()), null, DTAuxiliarPT.Rows[0][2].ToString(), DTAuxiliarPT.Rows[0][3].ToString(), DTAuxiliarPT.Rows[0][4].ToString(), byte.Parse(DTAuxiliarPT.Rows[0][5].ToString()));
            //    TreeNode NodoProductoTipoPadre = new TreeNode(tBNombreTipoProducto.Text);
            //    NodoProductoTipoPadre.Tag = PTP;
            //    NodoProductoTipoPadre.ImageIndex = 2;
            //    NodoProductoTipoPadre.SelectedImageIndex = 2;
            //    tVProductostipos.Nodes.Add(NodoProductoTipoPadre);
            //    tVProductostipos.SelectedNode.Expand();
            //}

            //if (TipoOperacion == "IH")
            //{
            //    ProductosTipos.InsertarProductoTipo(((ProductoTipo)tVProductostipos.SelectedNode.Tag).Codigo, tBNombreTipoProducto.Text, tBNombreCortoTipoProducto.Text, tBDescripcionTipoProducto.Text, byte.Parse(tBNivel.Text));
            //    DataTable DTAuxiliarPT = new DataTable();
            //    DTAuxiliarPT = ProductosTipos.ObtenerProductoTipoNombre(tBNombreTipoProducto.Text);
            //    ProductoTipo PTP = new ProductoTipo(int.Parse(DTAuxiliarPT.Rows[0][0].ToString()), int.Parse(DTAuxiliarPT.Rows[0][1].ToString()), DTAuxiliarPT.Rows[0][2].ToString(), DTAuxiliarPT.Rows[0][3].ToString(), DTAuxiliarPT.Rows[0][4].ToString(), byte.Parse(DTAuxiliarPT.Rows[0][5].ToString()));

            //    TreeNode NodoProductoTipo = new TreeNode(tBNombreTipoProducto.Text);
            //    NodoProductoTipo.Tag = PTP;
            //    NodoProductoTipo.ImageIndex = 2;
            //    NodoProductoTipo.SelectedImageIndex = 2;
            //    if (tVProductostipos.SelectedNode.Level > 0)
            //    {
            //        tVProductostipos.SelectedNode.ImageIndex = 1;
            //        tVProductostipos.SelectedNode.SelectedImageIndex = 1;
            //    }
            //    else
            //    {
            //        tVProductostipos.SelectedNode.ImageIndex = 0;
            //        tVProductostipos.SelectedNode.SelectedImageIndex = 0;
            //    }

            //    tVProductostipos.SelectedNode.Nodes.Add(NodoProductoTipo);
            //    tVProductostipos.SelectedNode.Expand();
            //}

            //if (TipoOperacion == "E")
            //{
            //    ProductosTipos.ActualizarProductoTipo(((ProductoTipo)tVProductostipos.SelectedNode.Tag).Codigo, ((ProductoTipo)tVProductostipos.SelectedNode.Tag).CodigoPadre, tBNombreTipoProducto.Text, tBNombreCortoTipoProducto.Text, tBDescripcionTipoProducto.Text, ((ProductoTipo)tVProductostipos.SelectedNode.Tag).Niv);
            //    DataTable DTAuxiliarPT = new DataTable();
                
            //    DTAuxiliarPT = ProductosTipos.ObtenerProductoTipoNombre(tBNombreTipoProducto.Text);
            //    int? CotigoTipoProductoPadreAux = null;
            //    if (DTAuxiliarPT.Rows[0]["CodigoTipoProductoPadre"].ToString() != "")
            //        CotigoTipoProductoPadreAux = int.Parse(DTAuxiliarPT.Rows[0]["CodigoTipoProductoPadre"].ToString());

            //    ProductoTipo PTP = new ProductoTipo(int.Parse(DTAuxiliarPT.Rows[0][0].ToString()), CotigoTipoProductoPadreAux, DTAuxiliarPT.Rows[0][2].ToString(), DTAuxiliarPT.Rows[0][3].ToString(), DTAuxiliarPT.Rows[0][4].ToString(), byte.Parse(DTAuxiliarPT.Rows[0][5].ToString()));

            //    tVProductostipos.SelectedNode.Text = tBNombreTipoProducto.Text;
            //    TreeNode NodoProductoTipo = tVProductostipos.SelectedNode;
            //    NodoProductoTipo.Tag = PTP;
            //}

            //InhabilitarControles(true);
            //bAceptar.Enabled = false;
            //bCancelar.Enabled = false;

        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            //InicializarControles();
            //InhabilitarControles(true);
            //bAceptar.Enabled = false;
            //bCancelar.Enabled = false;
        }
 
        private void bCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tSMIEditarElementoActual_Click(object sender, EventArgs e)
        {
            if (tVProductostipos.SelectedNode != null)
            {
                FAgregarEditarProductoTipo fAETP = new FAgregarEditarProductoTipo(NombreTipoProductoSeleccionado, NombreCortoTipoProductoSeleccionado, DescripcionTipoProductoSeleccionado);
                fAETP.ShowDialog();

                if (fAETP.DialogResult == DialogResult.OK)
                {
                    ProductosTipos.ActualizarProductoTipo(CodigoTipoProductoSeleccionado, CodigoTipoProductoPadreSeleccionado, fAETP.NombreTipoProducto, fAETP.NombreCortoTipoProducto, fAETP.DescripcionTipoProducto, NivelSeleccionado);
                    ProductoTipo PT = new ProductoTipo(CodigoTipoProductoSeleccionado, CodigoTipoProductoPadreSeleccionado, fAETP.NombreTipoProducto, fAETP.NombreCortoTipoProducto, fAETP.DescripcionTipoProducto, NivelSeleccionado);
                    tVProductostipos.SelectedNode.Text = fAETP.NombreTipoProducto.Trim();

                    TreeNode NodoCuotaSeleccionado = tVProductostipos.SelectedNode;
                    NodoCuotaSeleccionado.Tag = PT;
                }
                fAETP.Dispose();
            }
            else
            {
                MessageBox.Show("No existe ninguna cuota seleccionada para proceder con la operacion solicitada.");

            }
            
            
            
            //TipoOperacion = "E";
            //CargarInformacionNodo(tVProductostipos.SelectedNode);
            //InhabilitarControles(false);

            //bAceptar.Enabled = true;
            //bCancelar.Enabled = true;
            //tBNombreTipoProducto.Focus();
        }

        private void tSMIEliminarElementoActual_Click(object sender, EventArgs e)
        {
            if (tVProductostipos.SelectedNode != null)
            {
                string Mensaje = "Está seguro que desea eliminar el tipo de producto seleccionado?, recuerde que una vez aceptada la operación es irreversible. Además para poder eliminar satisfactoriamente este elemento, el mismo no debe estar siendo utilizado en ninguna transacción o registro.";
                string Titulo = "Confirmación eliminación tipo producto";
                MessageBoxButtons Botones = MessageBoxButtons.YesNo;
                MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
                DialogResult result;

                result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        ProductosTipos.EliminarProductoTipo(CodigoTipoProductoSeleccionado);
                        MessageBox.Show("Se ha eliminado satisfactoriamente el tipo de producto seleccionado.");
                        tVProductostipos.SelectedNode.Remove();
                    }
                    catch
                    {
                        Mensaje = "No se pudo eliminar este tipo de producto, debido a que el mismo forma parte de alguna transacción.";
                        Titulo = "Información eliminación tipo producto";
                        Botones = MessageBoxButtons.OK;
                        Icono = MessageBoxIcon.Information;
                        MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                    }
                }
            }
            else
            {
                MessageBox.Show("No existe ningun tipo de producto seleccionado para proceder con la operacion solicitada.");
            }
        }

        private void lVProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
             //Botones barra de menus
            tSBAgregarProducto.Enabled = false;
            tSBEditarProducto.Enabled = false;
            tSBEliminarProducto.Enabled = false;

            //Opciones menus contextuales
            TSMIEditarProducto.Enabled = false;
            TSMIEliminarProducto.Enabled = false;
            TSMICopiarProducto.Enabled = false;
            TSMIAgregarPropiedad1.Enabled = false;
            TSMIAgregarImagen1.Enabled = false;
            TSMIAgregarComponente1.Enabled = false;

            TSMIAgregarPropiedad2.Enabled = false;
            TSMIEditarPropiedad.Enabled = false;
            TSMIEliminarPropiedad.Enabled = false;

            TSMIAgregarImagen2.Enabled = false;
            TSMIEditarImagen.Enabled = false;
            TSMIEliminarImagen.Enabled = false;

            if(lVProductos.SelectedItems.Count > 0)
            {
                //Botones barra de menus
                tSBEditarProducto.Enabled = true;
                tSBEliminarProducto.Enabled = true;

                //Opciones menus contextuales
                TSMIEditarProducto.Enabled = true;
                TSMIEliminarProducto.Enabled = true;
                TSMICopiarProducto.Enabled = true;
                TSMIAgregarPropiedad1.Enabled = true;
                TSMIAgregarImagen1.Enabled = true;
                

                TSMIAgregarPropiedad2.Enabled = true;

                TSMIAgregarImagen2.Enabled = true;

                for (int i = 0; i < lVProductos.SelectedItems.Count; i++)
                {
                    if (lVProductos.SelectedItems[i].Text.Length > 0)
                    {
                        CodigoProductoSeleccionado = lVProductos.SelectedItems[i].Text;

                        //tPComponentes.Visible = !bool.Parse(lVProductos.SelectedItems[i].SubItems[10].Text);

                        if (!bool.Parse(lVProductos.SelectedItems[i].SubItems[10].Text))
                        {
                            TSMIAgregarComponente1.Enabled = true;
                            //tPComponentes.Parent = tCComponentes;
                            //if (tCComponentes.TabPages.Count <= 2)
                            //    tCComponentes.TabPages.Add(tPComponentes);
                        }
                        else
                        {
                            //tPComponentes.Parent = null; 
                            //tCComponentes.TabPages.Remove(tPComponentes);

                        }

                        CargarlVProductosPropiedades(ProductosDescripcion.ListarProductosDescripcionPorCodigoProducto(CodigoProductoSeleccionado));
                        CargarlVProductosImagenes(ProductosImagenes.ListarProductosImagenesPorProducto(CodigoProductoSeleccionado));
                        CargarlVProductosCompuestos(ProductosCompuestos.ListarProductosCompuestosPorProducto(CodigoProductoSeleccionado));
                    }
                }
            }

        }

        private void TSMIEditarProducto_Click(object sender, EventArgs e)
        {
            DataTable DTAuxiliarP = new DataTable();
            DTAuxiliarP = Productos.ObtenerProducto(CodigoProductoSeleccionado);
            
            FAgregarEditarProducto fAEP = new FAgregarEditarProducto(CodigoProductoSeleccionado, DTAuxiliarP.Rows[0][1].ToString(), DTAuxiliarP.Rows[0][2].ToString(), DTAuxiliarP.Rows[0][3].ToString(), DTAuxiliarP.Rows[0][4].ToString(),
                int.Parse(DTAuxiliarP.Rows[0][5].ToString()), int.Parse(DTAuxiliarP.Rows[0][6].ToString()), int.Parse(DTAuxiliarP.Rows[0][7].ToString()), DTAuxiliarP.Rows[0][8].ToString(), 
                bool.Parse(DTAuxiliarP.Rows[0][9].ToString()), bool.Parse(DTAuxiliarP.Rows[0][10].ToString()), bool.Parse(DTAuxiliarP.Rows[0][11].ToString()), bool.Parse(DTAuxiliarP.Rows[0][12].ToString()),
                decimal.Parse(DTAuxiliarP.Rows[0][13].ToString()), decimal.Parse(DTAuxiliarP.Rows[0][14].ToString()), decimal.Parse(DTAuxiliarP.Rows[0][15].ToString()),
                DTAuxiliarP.Rows[0][16].ToString(), DTAuxiliarP.Rows[0][17].ToString());
            fAEP.Text = "Editar producto";
            fAEP.ShowDialog();

            if (fAEP.DialogResult == DialogResult.OK)
            {
                //int? CodigoTipoProducto = 0;
                //NivelSeleccionado++;

                Productos.ActualizarProducto(CodigoProductoSeleccionado, fAEP.CodigoProductoFabricante, fAEP.NombreProducto, fAEP.NombreProducto1, fAEP.NombreProducto2,
                fAEP.CodigoMarcaProducto, CodigoTipoProductoSeleccionado, fAEP.CodigoUnidadProducto, fAEP.CodigoTipoCalculoInventario,
                fAEP.LlenarCodigoPE, fAEP.ProductoTangible, fAEP.ProductoSimple, fAEP.CalcularPrecioVenta, fAEP.RendimientoDeseado1, fAEP.RendimientoDeseado2, fAEP.RendimientoDeseado3, fAEP.Descripcion, fAEP.Observaciones);

                lVProductos.SelectedItems[0].SubItems[0].Text = fAEP.CodigoProducto;
                lVProductos.SelectedItems[0].SubItems[1].Text = fAEP.CodigoProductoFabricante;
                lVProductos.SelectedItems[0].SubItems[2].Text = fAEP.NombreProducto;
                lVProductos.SelectedItems[0].SubItems[3].Text = fAEP.NombreProducto1;
                lVProductos.SelectedItems[0].SubItems[4].Text = fAEP.NombreProducto2;
                string NombreMarcaProducto = ProductosMarcas.ObtenerProductoMarca(fAEP.CodigoMarcaProducto).Rows[0]["NombreMarcaProducto"].ToString(); ;
                lVProductos.SelectedItems[0].SubItems[5].Text = NombreMarcaProducto;
                string NombreUnidadProdcuto = ProductosUnidades.ObtenerProductoUnidad(fAEP.CodigoUnidadProducto).Rows[0]["NombreUnidad"].ToString();
                lVProductos.SelectedItems[0].SubItems[6].Text = NombreUnidadProdcuto;
                string NombreTipoCalculoInventario = "";
                if (fAEP.CodigoTipoCalculoInventario == "P")
                    NombreTipoCalculoInventario = "PEPS";
                else if (fAEP.CodigoTipoCalculoInventario == "U")
                    NombreTipoCalculoInventario = "UEPS";
                else if (fAEP.CodigoTipoCalculoInventario == "O")
                    NombreTipoCalculoInventario = "PONDERADO";
                else if (fAEP.CodigoTipoCalculoInventario == "B")
                    NombreTipoCalculoInventario = "PRECIO MAS BAJO";
                else if (fAEP.CodigoTipoCalculoInventario == "A")
                    NombreTipoCalculoInventario = "PRECIO MAS ALTO";
                else if (fAEP.CodigoTipoCalculoInventario == "T")
                    NombreTipoCalculoInventario = "ULTIMO PRECIO";
                lVProductos.SelectedItems[0].SubItems[7].Text = NombreTipoCalculoInventario;
                lVProductos.SelectedItems[0].SubItems[8].Text = fAEP.LlenarCodigoPE.ToString();
                lVProductos.SelectedItems[0].SubItems[9].Text = fAEP.ProductoTangible.ToString();
                lVProductos.SelectedItems[0].SubItems[10].Text = fAEP.ProductoSimple.ToString();
                lVProductos.SelectedItems[0].SubItems[11].Text = fAEP.CalcularPrecioVenta.ToString();
                lVProductos.SelectedItems[0].SubItems[12].Text = fAEP.Descripcion;
                lVProductos.SelectedItems[0].SubItems[12].Text = fAEP.Observaciones;
            }
            fAEP.Dispose();
        
        }
             
        private void TSMIAgregarProducto1_Click(object sender, EventArgs e)
        {
            FAgregarEditarProducto fAEP = new FAgregarEditarProducto(CodigoTipoProductoSeleccionado);
            fAEP.Text = "Agregar producto";
            fAEP.ShowDialog();

            if (fAEP.DialogResult == DialogResult.OK)
            {
                //int? CodigoTipoProducto = 0;
                //NivelSeleccionado++;

                Productos.InsertarProducto(fAEP.CodigoProducto, fAEP.CodigoProductoFabricante, fAEP.NombreProducto, fAEP.NombreProducto1, fAEP.NombreProducto2,
                fAEP.CodigoMarcaProducto, CodigoTipoProductoSeleccionado, fAEP.CodigoUnidadProducto, fAEP.CodigoTipoCalculoInventario,
                fAEP.LlenarCodigoPE, fAEP.ProductoTangible, fAEP.ProductoSimple, fAEP.CalcularPrecioVenta, fAEP.RendimientoDeseado1, fAEP.RendimientoDeseado2, fAEP.RendimientoDeseado3, fAEP.Descripcion, fAEP.Observaciones);

                ListViewItem ElementoLVI = new ListViewItem(fAEP.CodigoProducto);
                ElementoLVI.ImageIndex = 0;
                ElementoLVI.SubItems.Add(fAEP.CodigoProductoFabricante);
                ElementoLVI.SubItems.Add(fAEP.NombreProducto);
                ElementoLVI.SubItems.Add(fAEP.NombreProducto1);
                ElementoLVI.SubItems.Add(fAEP.NombreProducto2);

                string NombreMarcaProducto = ProductosMarcas.ObtenerProductoMarca(fAEP.CodigoMarcaProducto).Rows[0]["NombreMarcaProducto"].ToString(); ;
                ElementoLVI.SubItems.Add(NombreMarcaProducto.Trim());

                string NombreUnidadProdcuto = ProductosUnidades.ObtenerProductoUnidad(fAEP.CodigoUnidadProducto).Rows[0]["NombreUnidad"].ToString();
                ElementoLVI.SubItems.Add(NombreUnidadProdcuto.Trim());

                string NombreTipoCalculoInventario = "";
                if (fAEP.CodigoTipoCalculoInventario == "P")
                    NombreTipoCalculoInventario = "PEPS";
                else if (fAEP.CodigoTipoCalculoInventario == "U")
                    NombreTipoCalculoInventario = "UEPS";
                else if (fAEP.CodigoTipoCalculoInventario == "O")
                    NombreTipoCalculoInventario = "PONDERADO";
                else if (fAEP.CodigoTipoCalculoInventario == "B")
                    NombreTipoCalculoInventario = "PRECIO MAS BAJO";
                else if (fAEP.CodigoTipoCalculoInventario == "A")
                    NombreTipoCalculoInventario = "PRECIO MAS ALTO";
                else if (fAEP.CodigoTipoCalculoInventario == "T")
                    NombreTipoCalculoInventario = "ULTIMO PRECIO";

                ElementoLVI.SubItems.Add(NombreTipoCalculoInventario);
                ElementoLVI.SubItems.Add(fAEP.LlenarCodigoPE.ToString());
                ElementoLVI.SubItems.Add(fAEP.ProductoTangible.ToString());
                ElementoLVI.SubItems.Add(fAEP.ProductoSimple.ToString());
                ElementoLVI.SubItems.Add(fAEP.CalcularPrecioVenta.ToString());
                ElementoLVI.SubItems.Add(fAEP.Descripcion);
                ElementoLVI.SubItems.Add(fAEP.Observaciones);

                lVProductos.Items.Add(ElementoLVI);
            }
            fAEP.Dispose();
        }

        private void TSMIEditarPropiedad_Click(object sender, EventArgs e)
        {
            DataTable DTAuxiliarP = new DataTable();
            DTAuxiliarP = ProductosDescripcion.ObtenerProductoDescripcion(CodigoProductoSeleccionado, CodigoProductoPropiedadSeleccionada);

            FAgregarEditarProductoPropiedad fAEPP = new FAgregarEditarProductoPropiedad(int.Parse(DTAuxiliarP.Rows[0][1].ToString()), DTAuxiliarP.Rows[0][2].ToString());
            fAEPP.Text = "Editar propiedad producto";
            fAEPP.ShowDialog();

            if (fAEPP.DialogResult == DialogResult.OK)
            {
                ProductosDescripcion.ActualizarProductoDescripcion(CodigoProductoSeleccionado, fAEPP.CodigoPropiedad, fAEPP.ValorPropiedad);

                //lVProductos.SelectedItems[0].SubItems[0].Text = CodigoProductoSeleccionado;
                lVProductos.SelectedItems[0].SubItems[1].Text = fAEPP.CodigoPropiedad.ToString();
                lVProductos.SelectedItems[0].SubItems[2].Text = fAEPP.ValorPropiedad;
            }
            fAEPP.Dispose();
        }

        private void lVProductosPropiedades_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lVProductosPropiedades.SelectedItems.Count; i++)
            {
                if (lVProductosPropiedades.SelectedItems[i].Text.Length > 0)
                {
                    CodigoProductoPropiedadSeleccionada = int.Parse(lVProductosPropiedades.SelectedItems[i].Tag.ToString());
                }
            }
        }

         private void TSMIAgregarImagen2_Click(object sender, EventArgs e)
        {
            FAgregarEditarProductoImagen fAEPI = new FAgregarEditarProductoImagen();
            fAEPI.Text = "Agregar imagen producto";
            fAEPI.ShowDialog();

            if (fAEPI.DialogResult == DialogResult.OK)
            {
                byte NumeroImagen = 0;

                NumeroImagen = (byte)ProductosImagenes.ListarProductosImagenesPorProducto(CodigoProductoSeleccionado).Rows.Count;
                NumeroImagen++;

                ProductosImagenes.InsertarProductoImagen(CodigoProductoSeleccionado, NumeroImagen, CodigoProductoSeleccionado + "-" + NumeroImagen.ToString() + ".jpg", fAEPI.NombreImagen);
                if (fAEPI.RutaArchivoImagen.Length > 0)
                {
                    //MessageBox.Show(this.RutaDirectorioImagenes + "\\" + CodigoProductoSeleccionado + "-" + NumeroImagen.ToString() + ".png");
                    CopiarImagen(fAEPI.RutaArchivoImagen, this.RutaDirectorioImagenes + "\\" + CodigoProductoSeleccionado + "-" + NumeroImagen.ToString() + ".jpg");
                }

                ListViewItem ElementoLVI = new ListViewItem(NumeroImagen.ToString());
                ElementoLVI.ImageIndex = 0;
                ElementoLVI.SubItems.Add(fAEPI.NombreImagen);
                ElementoLVI.SubItems.Add(CodigoProductoSeleccionado + "-" + NumeroImagen.ToString() + ".jpg");
                lVProductosImagenes.Items.Add(ElementoLVI);
            }
            fAEPI.Dispose();
        }

        private void TSMIEditarImagen_Click(object sender, EventArgs e)
        {
            DataTable DTAuxiliarPI = new DataTable();
            DTAuxiliarPI = ProductosImagenes.ObtenerProductoImagen(CodigoProductoSeleccionado, NumeroImagenSeleccionada);

            FAgregarEditarProductoImagen fAEPI = new FAgregarEditarProductoImagen(this.RutaDirectorioImagenes + "\\" + DTAuxiliarPI.Rows[0][2].ToString(), DTAuxiliarPI.Rows[0][3].ToString());
            fAEPI.Text = "Editar imagen producto";
            fAEPI.ShowDialog();
       
            if (fAEPI.DialogResult == DialogResult.OK)
            {
                ProductosImagenes.ActualizarProductoImagen(CodigoProductoSeleccionado, NumeroImagenSeleccionada, CodigoProductoSeleccionado + "-" + NumeroImagenSeleccionada.ToString() + ".jpg", fAEPI.NombreImagen);
                if (fAEPI.RutaArchivoImagen.Length > 0)
                {
                    CopiarImagen(fAEPI.RutaArchivoImagen, this.RutaDirectorioImagenes + "\\" + CodigoProductoSeleccionado + "-" + NumeroImagenSeleccionada.ToString() + ".jpg");
                }
                //lVProductos.SelectedItems[0].SubItems[0].Text = CodigoProductoSeleccionado;
                lVProductosImagenes.SelectedItems[0].SubItems[1].Text = fAEPI.NombreImagen.ToString();
                lVProductosImagenes.SelectedItems[0].SubItems[2].Text = CodigoProductoSeleccionado + "-" + NumeroImagenSeleccionada.ToString() + ".jpg";
                
            }
            fAEPI.Dispose();
        }

        private void lVProductosImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string RutaArchivoImagen = "";

            for (int i = 0; i < lVProductosImagenes.SelectedItems.Count; i++)
            {
                if (lVProductosImagenes.SelectedItems[i].Text.Length > 0)
                {
                    NumeroImagenSeleccionada = byte.Parse(lVProductosImagenes.SelectedItems[i].Text);
                    RutaArchivoImagen = this.RutaDirectorioImagenes + "\\" + lVProductosImagenes.SelectedItems[i].SubItems[2].Text.Trim();
                }
            }


            if (RutaArchivoImagen.Length > 0 && File.Exists(RutaArchivoImagen))
            {
                Image AuxImage2 = Image.FromFile(RutaArchivoImagen);
                MemoryStream AuxMemoryStream2 = new MemoryStream();

                AuxImage2.Save(AuxMemoryStream2, ImageFormat.Png);

                pBImagenProducto.Image = Image.FromStream(AuxMemoryStream2);
                AuxImage2.Dispose();
            }
            else 
            {
                pBImagenProducto.Image = null;
            }


        }

        private void TSMIEliminarImagen_Click(object sender, EventArgs e)
        {
            if (lVProductosImagenes.Items.Count > 0)
            {
                string Mensaje = "Está seguro que desea eliminar la imagen del producto seleccionado?, recuerde que una vez aceptada la operación es irreversible. Además para poder eliminar satisfactoriamente este elemento, el mismo no debe estar siendo utilizado en ninguna transacción o registro.";
                string Titulo = "Confirmación eliminación imagen producto";
                MessageBoxButtons Botones = MessageBoxButtons.YesNo;
                MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
                DialogResult result;

                result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        ProductosImagenes.EliminarProductoImagen(CodigoProductoSeleccionado, NumeroImagenSeleccionada);
                        MessageBox.Show("Se ha eliminado satisfactoriamente la imagen del producto seleccionado.");

                        for (int i = 0; i < lVProductosImagenes.SelectedItems.Count; i++)
                        {
                            lVProductosImagenes.SelectedItems[i].Remove();
                        }
                    }
                    catch
                    {
                        Mensaje = "No se pudo eliminar esta imagen del producto, debido a que el mismo forma parte de alguna transacción.";
                        Titulo = "Información eliminación imagen de producto";
                        Botones = MessageBoxButtons.OK;
                        Icono = MessageBoxIcon.Information;
                        MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                    }
                }
            }
            else
            {
                MessageBox.Show("No existe ninguna propiedad de producto seleccionado para proceder con la operacion solicitada.");
            }
        }

        public void CopiarImagen(string RutaArchivoImagenOrigen, string RutaArchivoImagenDestino)
        {
            if (RutaArchivoImagenOrigen.Length > 0)
            {
                if (RutaArchivoImagenDestino.Length > 0)
                {
                    if (File.Exists(RutaArchivoImagenDestino))
                    {
                        File.Delete(RutaArchivoImagenDestino);
                    }

                    FileStream fs = new FileStream(RutaArchivoImagenDestino, FileMode.CreateNew);

                    Bitmap res = new Bitmap(RutaArchivoImagenOrigen);
                    MemoryStream ms = new MemoryStream();
                    res.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.WriteTo(fs);
                    res.Dispose();
                    fs.Dispose();
                    ms.Dispose();
                }
                else
                {
                    MessageBox.Show("No se ha especificado o no se puede identificar el nombre o la ruta del archivo destino que se pretende crear, verifique que estos datos sean correctos");
                }
            }
            else
            {
                MessageBox.Show("No se ha especificado o no se puede identificar el archivo origen de imagen, verifique que la ruta y el nombre del archivo sean correctos");
            }
        }



        private void TSMIEditarComponente_Click(object sender, EventArgs e)
        {
            DataTable DTAuxiliarPC = new DataTable();
            DTAuxiliarPC = ProductosCompuestos.ObtenerProductoCompuesto(CodigoProductoSeleccionado, CodigoProductoComponenteSeleccionado);
            FAgregarEditarProductoComponente fAEPC = new FAgregarEditarProductoComponente(CodigoProductoSeleccionado, CodigoProductoComponenteSeleccionado, int.Parse(DTAuxiliarPC.Rows[0][3].ToString()));
            fAEPC.Text = "Editar componente producto";
            fAEPC.ShowDialog();
            
           
            if (fAEPC.DialogResult == DialogResult.OK)
            {
                int NumeroComponente = int.Parse(lVProductosCompuestos.SelectedItems[0].SubItems[0].Text);
                ProductosCompuestos.ActualizarComponenteProductoCompuesto(CodigoProductoSeleccionado, CodigoProductoComponenteSeleccionado, fAEPC.CodigoProductoComponente, NumeroComponente, fAEPC.Cantidad);
                lVProductosCompuestos.SelectedItems[0].SubItems[0].Text = NumeroComponente.ToString();
                lVProductosCompuestos.SelectedItems[0].SubItems[1].Text = CodigoProductoSeleccionado;   
                string NombreProductoComponente = Productos.ObtenerProducto(fAEPC.CodigoProductoComponente).Rows[0]["NombreProducto"].ToString(); ;
                lVProductosCompuestos.SelectedItems[0].SubItems[2].Text = NombreProductoComponente;
                lVProductosCompuestos.SelectedItems[0].SubItems[3].Text = fAEPC.Cantidad.ToString();
            }
            fAEPC.Dispose();
        }

        private void lVProductosCompuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lVProductosCompuestos.SelectedItems.Count; i++)
            {
                if (lVProductosCompuestos.SelectedItems[i].Text.Length > 0)
                {
                    CodigoProductoComponenteSeleccionado = lVProductosCompuestos.SelectedItems[i].SubItems[1].Text;
                }
            }
        }

        private void TSMIEliminarComponente_Click(object sender, EventArgs e)
        {
            if (lVProductosPropiedades.Items.Count > 0)
            {
                string Mensaje = "Está seguro que desea eliminar el componente de producto seleccionado?, recuerde que una vez aceptada la operación es irreversible. Además para poder eliminar satisfactoriamente este elemento, el mismo no debe estar siendo utilizado en ninguna transacción o registro.";
                string Titulo = "Confirmación eliminación componente producto";
                MessageBoxButtons Botones = MessageBoxButtons.YesNo;
                MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
                DialogResult result;

                result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        ProductosCompuestos.EliminarProductoCompuesto(CodigoProductoSeleccionado, CodigoProductoComponenteSeleccionado);
                        MessageBox.Show("Se ha eliminado satisfactoriamente el componente del producto seleccionado.");

                        for (int i = 0; i < lVProductosCompuestos.SelectedItems.Count; i++)
                        {
                            lVProductosCompuestos.SelectedItems[i].Remove();
                        }
                    }
                    catch
                    {
                        Mensaje = "No se pudo eliminar este componente de producto, debido a que el mismo forma parte de alguna transacción.";
                        Titulo = "Información eliminación componente de producto";
                        Botones = MessageBoxButtons.OK;
                        Icono = MessageBoxIcon.Information;
                        MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                    }
                }
            }
        }

        private void tVProductostipos_ItemDrag(object sender, ItemDragEventArgs e)
        {
            tVProductostipos.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tVProductostipos_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

           //if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
           //     e.Effect = DragDropEffects.Move;
        }

        private void tVProductostipos_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode NodoDestino = ((TreeView)sender).GetNodeAt(pt);
                TreeNode NodoActual = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");

                //if ((NodoDestino != null) && (CodigoTipoProductoPadreSeleccionado != ((ProductoTipo)NodoDestino.Tag).Codigo) && (CodigoTipoProductoPadreSeleccionado != ((ProductoTipo)NodoDestino.Tag).CodigoPadre))
                if ((NodoDestino != null) && (NodoActual != NodoDestino) && (!NodoActual.Nodes.Contains(NodoDestino)))
                {
                    if (NodoDestino.TreeView == NodoActual.TreeView)
                    {
                        CodigoTipoProductoPadreDestino = ((ProductoTipo)NodoDestino.Tag).Codigo;
                        ProductosTipos.ActualizarProductoTipo(CodigoTipoProductoSeleccionado, CodigoTipoProductoPadreDestino, NombreTipoProductoSeleccionado, NombreCortoTipoProductoSeleccionado, DescripcionTipoProductoSeleccionado, NivelSeleccionado);

                        TreeNode NuevoNodo = (TreeNode)NodoActual.Clone();
                        NodoDestino.Nodes.Add(NuevoNodo);

                        ProductoTipo PT = new ProductoTipo(CodigoTipoProductoSeleccionado, ((ProductoTipo)NodoDestino.Tag).Codigo, NombreTipoProductoSeleccionado, NombreCortoTipoProductoSeleccionado, DescripcionTipoProductoSeleccionado, NivelSeleccionado);
                        NuevoNodo.Tag = PT;

                        NodoDestino.Expand();
                        NodoActual.Remove();
                    }
                }
            }


            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection).ToString(), false))
            {
                Point loc = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode NodoDestino = ((TreeView)sender).GetNodeAt(loc);
                //TreeNode tnNew;
 
                ListView.SelectedListViewItemCollection lstViewColl =
                (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));
                foreach (ListViewItem lvItem in lstViewColl)
                {
                    DataTable DTAuxiliarP = new DataTable();
                    DTAuxiliarP = Productos.ObtenerProducto(lvItem.SubItems[0].Text);
            
                    Productos.ActualizarProducto(CodigoProductoSeleccionado, DTAuxiliarP.Rows[0][1].ToString(), DTAuxiliarP.Rows[0][2].ToString(), DTAuxiliarP.Rows[0][3].ToString(), DTAuxiliarP.Rows[0][4].ToString(),
                    int.Parse(DTAuxiliarP.Rows[0][5].ToString()), ((ProductoTipo)NodoDestino.Tag).Codigo, int.Parse(DTAuxiliarP.Rows[0][7].ToString()), DTAuxiliarP.Rows[0][8].ToString(), 
                    bool.Parse(DTAuxiliarP.Rows[0][9].ToString()), bool.Parse(DTAuxiliarP.Rows[0][10].ToString()), bool.Parse(DTAuxiliarP.Rows[0][11].ToString()), bool.Parse(DTAuxiliarP.Rows[0][12].ToString()),
                    decimal.Parse(DTAuxiliarP.Rows[0][13].ToString()), decimal.Parse(DTAuxiliarP.Rows[0][14].ToString()), decimal.Parse(DTAuxiliarP.Rows[0][15].ToString()),
                    DTAuxiliarP.Rows[0][16].ToString(), DTAuxiliarP.Rows[0][17].ToString());
                    lvItem.Remove();
                }
            }

        }

        private void TSMIEliminarProducto_Click(object sender, EventArgs e)
        {
            if (lVProductos.Items.Count > 0)
            {
                string Mensaje = "Está seguro que desea eliminar el producto seleccionado?, recuerde que una vez aceptada la operación es irreversible. Además para poder eliminar satisfactoriamente este elemento, el mismo no debe estar siendo utilizado en ninguna transacción o registro.";
                string Titulo = "Confirmación eliminación producto";
                MessageBoxButtons Botones = MessageBoxButtons.YesNo;
                MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
                DialogResult result;

                result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Productos.EliminarProducto(CodigoProductoSeleccionado);
                        MessageBox.Show("Se ha eliminado satisfactoriamente el producto seleccionado.");

                        for (int i = 0; i < lVProductos.SelectedItems.Count; i++)
                        {
                            lVProductos.SelectedItems[i].Remove();
                        }
                    }
                    catch
                    {
                        Mensaje = "No se pudo eliminar este producto, debido a que el mismo forma parte de alguna transacción.";
                        Titulo = "Información eliminación  producto";
                        Botones = MessageBoxButtons.OK;
                        Icono = MessageBoxIcon.Information;
                        MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                    }
                }
            }
            else
            {
                MessageBox.Show("No existe ningun producto seleccionado para proceder con la operacion solicitada.");
            }
        }

        private void TSMIEliminarPropiedad_Click(object sender, EventArgs e)
        {
            if (lVProductosPropiedades.Items.Count > 0)
            {
                string Mensaje = "Está seguro que desea eliminar la propiedad de producto seleccionado?, recuerde que una vez aceptada la operación es irreversible. Además para poder eliminar satisfactoriamente este elemento, el mismo no debe estar siendo utilizado en ninguna transacción o registro.";
                string Titulo = "Confirmación eliminación propiedad producto";
                MessageBoxButtons Botones = MessageBoxButtons.YesNo;
                MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
                DialogResult result;

                result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        ProductosDescripcion.EliminarProductoDescripcion(CodigoProductoSeleccionado, CodigoProductoPropiedadSeleccionada);
                        MessageBox.Show("Se ha eliminado satisfactoriamente la propiedad del producto seleccionado.");

                        for (int i = 0; i < lVProductosPropiedades.SelectedItems.Count; i++)
                        {
                            lVProductosPropiedades.SelectedItems[i].Remove();
                        }
                    }
                    catch
                    {
                        Mensaje = "No se pudo eliminar este propiedad de producto, debido a que el mismo forma parte de alguna transacción.";
                        Titulo = "Información eliminación propiedad de producto";
                        Botones = MessageBoxButtons.OK;
                        Icono = MessageBoxIcon.Information;
                        MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                    }
                }
            }
            else
            {
                MessageBox.Show("No existe ninguna propiedad de producto seleccionado para proceder con la operacion solicitada.");
            }
        }

        private void TSMIAgregarPropiedad2_Click(object sender, EventArgs e)
        {
            FAgregarEditarProductoPropiedad fAEPP = new FAgregarEditarProductoPropiedad();
            fAEPP.Text = "Agregar propiedad producto";
            fAEPP.ShowDialog();

            if (fAEPP.DialogResult == DialogResult.OK)
            {
                ProductosDescripcion.InsertarProductoDescripcion(CodigoProductoSeleccionado, fAEPP.CodigoPropiedad, fAEPP.ValorPropiedad);

                string NombrePropiedad = ProductosPropiedades.ObtenerProductoPropiedad(fAEPP.CodigoPropiedad).Rows[0]["NombrePropiedad"].ToString(); ;

                ListViewItem ElementoLVI = new ListViewItem(NombrePropiedad);
                ElementoLVI.ImageIndex = 0;
                ElementoLVI.Tag = fAEPP.CodigoPropiedad.ToString();
                ElementoLVI.SubItems.Add(fAEPP.ValorPropiedad);
                lVProductosPropiedades.Items.Add(ElementoLVI);
            }
            fAEPP.Dispose();
        }

        private void TSMIAgregarComponente2_Click(object sender, EventArgs e)
        {
            FAgregarEditarProductoComponente fAEPC = new FAgregarEditarProductoComponente(CodigoProductoSeleccionado);
            fAEPC.Text = "Agregar producto componente";
            fAEPC.ShowDialog();

            if (fAEPC.DialogResult == DialogResult.OK)
            {
                int NumeroComponente = lVProductosCompuestos.Items.Count;
                NumeroComponente++;
                ProductosCompuestos.InsertarProductoCompuesto(CodigoProductoSeleccionado, fAEPC.CodigoProductoComponente, NumeroComponente, fAEPC.Cantidad);

                ListViewItem ElementoLVI = new ListViewItem(NumeroComponente.ToString());
                ElementoLVI.ImageIndex = 0;
                ElementoLVI.SubItems.Add(fAEPC.CodigoProductoComponente.ToString());
                string NombreProductoComponente = Productos.ObtenerProducto(fAEPC.CodigoProductoComponente).Rows[0]["NombreProducto"].ToString(); ;
                ElementoLVI.SubItems.Add(NombreProductoComponente);
                ElementoLVI.SubItems.Add(fAEPC.Cantidad.ToString());
                lVProductosCompuestos.Items.Add(ElementoLVI);
            }
            fAEPC.Dispose();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TSMICopiarProducto_Click(object sender, EventArgs e)
        {
            DataTable DTAuxiliarP = new DataTable();
            DTAuxiliarP = Productos.ObtenerProducto(CodigoProductoSeleccionado);
            
            FAgregarEditarProducto fAEP = new FAgregarEditarProducto(DTAuxiliarP.Rows[0][1].ToString(), DTAuxiliarP.Rows[0][2].ToString(), DTAuxiliarP.Rows[0][3].ToString(), DTAuxiliarP.Rows[0][4].ToString(),
                int.Parse(DTAuxiliarP.Rows[0][5].ToString()), int.Parse(DTAuxiliarP.Rows[0][6].ToString()), int.Parse(DTAuxiliarP.Rows[0][7].ToString()), DTAuxiliarP.Rows[0][8].ToString(), 
                bool.Parse(DTAuxiliarP.Rows[0][9].ToString()), bool.Parse(DTAuxiliarP.Rows[0][10].ToString()), bool.Parse(DTAuxiliarP.Rows[0][11].ToString()), bool.Parse(DTAuxiliarP.Rows[0][12].ToString()),
                decimal.Parse(DTAuxiliarP.Rows[0][13].ToString()), decimal.Parse(DTAuxiliarP.Rows[0][14].ToString()), decimal.Parse(DTAuxiliarP.Rows[0][15].ToString()),
                DTAuxiliarP.Rows[0][16].ToString(), DTAuxiliarP.Rows[0][17].ToString());
            fAEP.Text = "Agregar producto";
            fAEP.ShowDialog();

            if (fAEP.DialogResult == DialogResult.OK)
            {
                Productos.InsertarProducto(fAEP.CodigoProducto, fAEP.CodigoProductoFabricante, fAEP.NombreProducto, fAEP.NombreProducto1, fAEP.NombreProducto2,
                 fAEP.CodigoMarcaProducto, CodigoTipoProductoSeleccionado, fAEP.CodigoUnidadProducto, fAEP.CodigoTipoCalculoInventario,
                 fAEP.LlenarCodigoPE, fAEP.ProductoTangible, fAEP.ProductoSimple, fAEP.CalcularPrecioVenta, fAEP.RendimientoDeseado1, fAEP.RendimientoDeseado2, fAEP.RendimientoDeseado3, fAEP.Descripcion, fAEP.Observaciones);

                ListViewItem ElementoLVI = new ListViewItem(fAEP.CodigoProducto);
                ElementoLVI.ImageIndex = 0;
                ElementoLVI.SubItems.Add(fAEP.CodigoProductoFabricante);
                ElementoLVI.SubItems.Add(fAEP.NombreProducto);
                ElementoLVI.SubItems.Add(fAEP.NombreProducto1);
                ElementoLVI.SubItems.Add(fAEP.NombreProducto2);

                string NombreMarcaProducto = ProductosMarcas.ObtenerProductoMarca(fAEP.CodigoMarcaProducto).Rows[0]["NombreMarcaProducto"].ToString(); ;
                ElementoLVI.SubItems.Add(NombreMarcaProducto.Trim());

                string NombreUnidadProdcuto = ProductosUnidades.ObtenerProductoUnidad(fAEP.CodigoUnidadProducto).Rows[0]["NombreUnidad"].ToString();
                ElementoLVI.SubItems.Add(NombreUnidadProdcuto.Trim());

                string NombreTipoCalculoInventario = "";
                if (fAEP.CodigoTipoCalculoInventario == "P")
                    NombreTipoCalculoInventario = "PEPS";
                else if (fAEP.CodigoTipoCalculoInventario == "U")
                    NombreTipoCalculoInventario = "UEPS";
                else if (fAEP.CodigoTipoCalculoInventario == "O")
                    NombreTipoCalculoInventario = "PONDERADO";
                else if (fAEP.CodigoTipoCalculoInventario == "B")
                    NombreTipoCalculoInventario = "PRECIO MAS BAJO";
                else if (fAEP.CodigoTipoCalculoInventario == "A")
                    NombreTipoCalculoInventario = "PRECIO MAS ALTO";
                else if (fAEP.CodigoTipoCalculoInventario == "T")
                    NombreTipoCalculoInventario = "ULTIMO PRECIO";

                ElementoLVI.SubItems.Add(NombreTipoCalculoInventario);
                ElementoLVI.SubItems.Add(fAEP.LlenarCodigoPE.ToString());
                ElementoLVI.SubItems.Add(fAEP.ProductoTangible.ToString());
                ElementoLVI.SubItems.Add(fAEP.ProductoSimple.ToString());
                ElementoLVI.SubItems.Add(fAEP.CalcularPrecioVenta.ToString());
                ElementoLVI.SubItems.Add(fAEP.Descripcion);
                ElementoLVI.SubItems.Add(fAEP.Observaciones);

                lVProductos.Items.Add(ElementoLVI);

                ProductosCompuestos.CopiarProductosComponentes(CodigoProductoSeleccionado, fAEP.CodigoProducto);

                CargarlVProductosCompuestos(ProductosCompuestos.ListarProductosCompuestosPorProducto(fAEP.CodigoProducto));
            }
            fAEP.Dispose();
        }

        private void TSMIConvertirEnTipoProductoRaiz_Click(object sender, EventArgs e)
        {
            if (tVProductostipos.SelectedNode != null)
            {
                ProductosTipos.ActualizarProductoTipo(CodigoTipoProductoSeleccionado, null, NombreTipoProductoSeleccionado, NombreCortoTipoProductoSeleccionado, DescripcionTipoProductoSeleccionado, NivelSeleccionado);

                ProductoTipo pt = new ProductoTipo(CodigoTipoProductoSeleccionado, null, NombreTipoProductoSeleccionado, NombreCortoTipoProductoSeleccionado, DescripcionTipoProductoSeleccionado, NivelSeleccionado);
                
                TreeNode NodoNuevo = (TreeNode)tVProductostipos.SelectedNode.Clone();

                NodoNuevo.Tag = pt;
                NodoNuevo.ImageIndex = 0;
                NodoNuevo.SelectedImageIndex = 0;
                tVProductostipos.Nodes.Add(NodoNuevo);
                
                tVProductostipos.SelectedNode.Remove();
            }
        }

        private void lVProductos_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lVProductos.DoDragDrop(lVProductos.SelectedItems, DragDropEffects.Move);
        }
    }

    public class ProductoTipo
    {
        private int CodigoProductoTipo;
        private int? CodigoProductoTipoPadre;
        private string NombreProductoTipo;
        private string NombreCortoProducto;
        private string DescripcionProductoTipo;
        private int Nivel;

        public ProductoTipo(int Codigo, int? CodigoPadre, string Nombre, string NombreCorto, string Descripcion, int Niv)
        {
            this.CodigoProductoTipo = Codigo;
            this.CodigoProductoTipoPadre = CodigoPadre;
            this.NombreProductoTipo = Nombre;
            this.NombreCortoProducto = NombreCorto;
            this.DescripcionProductoTipo = Descripcion;
            this.Nivel = Niv;
        }

        public int Codigo
        {
            get
            {
                return CodigoProductoTipo;
            }
        }

        public int? CodigoPadre
        {
            get
            {
                return CodigoProductoTipoPadre;
            }
        }

        public string Nombre
        {

            get
            {
                return NombreProductoTipo;
            }
        }

        public string NombreCorto
        {

            get
            {
                return NombreCortoProducto;
            }
        }

        public string Descripcion
        {

            get
            {
                return DescripcionProductoTipo;
            }
        }

        public int Niv
        {

            get
            {
                return Nivel;
            }
        }

        /*
        public override string ToString()
        {
            return this.Codigo.ToString() + " - " + this.Nombre;
        }*/
    }
}
