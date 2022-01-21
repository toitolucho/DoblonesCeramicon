using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN;
using WFADoblones20.Utilitarios;
using System.Data.SqlClient;
using System.Collections;
using CLCLN.GestionComercial;
using CLCLN.Sistema;
using WFADoblones20.ReportesGestionComercial;
using CLCAD;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FVentasProductos : Form
    {
        FProductosBusqueda fProductosBusqueda = null;
        FFinalizarVenta fFinalizarVenta = null;
        SqlDataAdapter adapterMaestroDetalle = new SqlDataAdapter();

        #region Variables de Tipo DataTable
        DataTable _DTProductosSeleccionados = null;
        DataTable _DTClientes = null;
        DataTable _DTVentasProductos = null;
        DataTable _DTVentasProductosDetalle = null;
        DataTable _DTVentasProductosTemporal = null;
        DataTable _DTVentasProductosTemporalCambioMoneda = null;
        DataTable _DTVentasProductosDetalleTemporal = null;
        DataTable _DTProductosEspecificosTemporal = null;
        DataTable _DTProductosEspecificosSeleccionadosPorUsuarioTemporal = null;
        DataTable _DTProductosEspecificos = null;
        DataTable _DTProductosEspecificosAgregadosTemporal = null;
        DataTable _DTProductosEspecificosAgregadosSeleccionadosPorUsuarioTemporal = null;
        DataTable _DTProductosEspecificosAgregados = null;
        DataTable _DTUsuarios = null;
        DataTable _DTMonedas = null;
        DataTable VariablesConfiguracionSistemaGC;
        DSDoblones20GestionComercial2.ObtenerCreditoDesdeCodigoAutorizacionRow DRCredito;
        #endregion

        DataSet DSMaestroDetalle = null;

        #region Variables de tipo Capa Lógica del Negocio
        private VentasProductosCLN _ventasProductosCLN = null;
        private VentasProductosDetalleCLN _ventasProductosDetalleCLN = null;
        private VentasFacturasCLN _ventasFacturasCLN = null;
        private VentasProductosEspecificosCLN _ventasProductosEspecificosCLN = null;
        private VentasProductosEspecificosAgregadosCLN _ventasProductosEspecificosAgregadosCLN = null;
        private TransaccionesUtilidadesCLN _ventasUtilidadesCLN = null;
        private ClientesCLN _clientesCLN = null;
        private InventariosProductosEspecificosCLN _inventarioProductosEspecificosCLN = null;
        private UsuariosCLN _usuariosCLN = null;
        private MonedasCLN _MonedasCLN = null;
        private PCsConfiguracionesCLN PCConfiguracion = null;
        #endregion
        public int numeroVenta = 0;

        public bool esCotizacionVenta = false;
        public bool ventaConFactura = false;
        public bool permitirModificar = true;
        public string TipoOperacion = "";
        private int NumeroAgencia = 1;
        private int NumeroPC = 0;
        private int CodigoMonedaActual;
        private bool EsCodigoTipoCreditoLibreDispocion = true; //  de Libre Disponibilidad
        /// <summary>
        /// tipo de Venta que realizara -> R:Credito E:Efectivo
        /// </summary>
        public char CodigoTipoVenta = 'N'; // 



        #region Propiedades de Configuración de Arranque del Sistema
        public decimal PorcentajeImpuestoSistema { get; set; }
        public int CodigoMonedaSistema { get; set; }
        public int CodigoMonedaRegion { get; set; }
        public string MascaraMonedaSistema { get; set; }
        public string MascaraMonedaRegion { get; set; }
        public string NombreMonedaSistema { get; set; }
        public string NombreMonedaRegion { get; set; }
        public bool ContabilidadIntegrada { get; set; }
        #endregion
        #region Constantes
        /// <summary>
        /// Constantes de las Columnas de las Tablas
        /// </summary>        
        const int columnaCodigo = 0;
        const int columnaNombreProducto = 1;
        const int columnaCantidad = 2;
        const int columnaPrecio = 3;
        const int columnaPrecioTotal = 4;

        /// <summary>
        /// Altura de las Dos grillas 
        /// </summary>
        const int AlturaDGVProductosAgregados = 222;
        const int AlturaDGVProductosEspecificos = 222;
        #endregion

        private Color ColorResaltado = Color.YellowGreen;
        private int CodigoUsuario = 1;
        private int CantidadProductosAgregados = 0;
        private int CantidadProductosEspecificos = 0;
        private int existeProductosEspecificos = 0;
        private ArrayList listaTiposAgregados = new ArrayList();

        private ArrayList listaCodigosProductosEspecificosTemporal = new ArrayList();
        private ArrayList listaCodigosProductosEspecificosAgregadosTemporal = new ArrayList();

        private bool DetalleCodigosEspecificosGenerados = false;
        private bool DetalleCodigosEspecificosAgregadosGenerados = false;
        private bool usuarioSeleccionaEspecifico = false;
        private bool usuarioSeleccionaEspecificoAgregados = false;
        private bool existenModificacionesEspecificos = false;
        private bool existenModificacionesAgregados = false;
        private bool ventaParaInsitituciones = false;
        private Font fuenteDefecto = null;
        private int? NumeroCredito = null;
        decimal MontoPrestamoCredito = 0;


        #region Propiedades del Formulario
        public ComboBox ComboBoxCliente
        {
            get
            {
                return cBoxCliente;
            }
        }

        public ComboBox ComboBoxVendedor
        {
            get
            {
                return cBoxVendedor;
            }
        }

        public DataTable DTProductosEspecificosAgregados
        {
            get
            {
                return _DTProductosEspecificosAgregadosTemporal;
            }
        }
        public DataTable DTVentasProductosTemporal
        {
            get
            {
                return _DTVentasProductosTemporal;
            }
        }

        public DataTable DTVentasProductosDetalleTemporal
        {
            get
            {
                return _DTVentasProductosDetalleTemporal;
            }
            set
            {
                this._DTVentasProductosDetalleTemporal = value;
            }
        }

        public DataGridView DGViewProductosSeleccionados
        {
            get
            {
                return dGVProductosSeleccionados;
            }
        }

        public BindingSource BDSourceVentaProductos
        {
            get
            {
                return bdSourceVentasProductos;
            }
        }

        public BindingSource BDSourceVentaProductosSeleccionados
        {
            get
            {
                return bdSourceVentasProductosDetalle;
            }
        }

        public VentasProductosEspecificosAgregadosCLN VentaproductosAgregados
        {
            get
            {
                if (_ventasProductosEspecificosAgregadosCLN == null)
                    _ventasProductosEspecificosAgregadosCLN = new VentasProductosEspecificosAgregadosCLN();
                return _ventasProductosEspecificosAgregadosCLN;
            }
        }

        public UsuariosCLN Usuarios
        {
            get
            {
                if (_usuariosCLN == null)
                    _usuariosCLN = new UsuariosCLN();
                return _usuariosCLN;
            }
        }

        public InventariosProductosEspecificosCLN InventarioProductoEspecificoCLN
        {
            get
            {
                if (_inventarioProductosEspecificosCLN == null)
                    _inventarioProductosEspecificosCLN = new InventariosProductosEspecificosCLN();
                return _inventarioProductosEspecificosCLN;
            }
        }

        public VentasProductosEspecificosCLN VentaProductosEspecificosCLN
        {
            get
            {
                if (_ventasProductosEspecificosCLN == null)
                    this._ventasProductosEspecificosCLN = new VentasProductosEspecificosCLN();
                return this._ventasProductosEspecificosCLN;
            }
        }

        public VentasFacturasCLN VentaFacturasCLN
        {
            get
            {
                if (_ventasFacturasCLN == null)
                    _ventasFacturasCLN = new VentasFacturasCLN();
                return this._ventasFacturasCLN;
            }
        }

        public ClientesCLN ClienteCLN
        {
            get
            {
                if (_clientesCLN == null)
                    _clientesCLN = new ClientesCLN();
                return _clientesCLN;
            }
        }

        public TransaccionesUtilidadesCLN VentaUtilidadesCLN
        {
            get
            {
                if (_ventasUtilidadesCLN == null)
                {
                    _ventasUtilidadesCLN = new TransaccionesUtilidadesCLN();
                }
                return _ventasUtilidadesCLN;
            }
        }
        public VentasProductosCLN VentaProductosCLN
        {
            get
            {
                if (_ventasProductosCLN == null)
                    _ventasProductosCLN = new VentasProductosCLN();
                return _ventasProductosCLN;
            }
        }

        public VentasProductosDetalleCLN VentaProductosDetalleCLN
        {
            get
            {
                if (_ventasProductosDetalleCLN == null)
                    _ventasProductosDetalleCLN = new VentasProductosDetalleCLN();
                return _ventasProductosDetalleCLN;
            }
        }

        public MonedasCLN MonedaCLN
        {
            get
            {
                if (_MonedasCLN == null)
                    _MonedasCLN = new MonedasCLN();
                return _MonedasCLN;
            }
        }
        #endregion


        public FVentasProductos(int NumeroAgencia, int NumeroPC, int CodigoUsuario)
        {
            InitializeComponent();
            entregaInstitucionalToolStripMenuItem.Visible = false;
            fuenteDefecto = dGVProductosEspecificos.DefaultCellStyle.Font;
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            this.CodigoUsuario = CodigoUsuario;

            //Inicio codigo agregado
            VariablesConfiguracionSistemaGC = new DataTable();
            PCConfiguracion = new PCsConfiguracionesCLN();
            VariablesConfiguracionSistemaGC = PCConfiguracion.ObtenerConfiguracionSistemaParaTransaccionesGC(NumeroPC);

            this.CodigoMonedaSistema = int.Parse(VariablesConfiguracionSistemaGC.Rows[0][3].ToString());
            this.NombreMonedaSistema = VariablesConfiguracionSistemaGC.Rows[0][4].ToString();
            this.MascaraMonedaSistema = VariablesConfiguracionSistemaGC.Rows[0][5].ToString();
            this.CodigoMonedaRegion = int.Parse(VariablesConfiguracionSistemaGC.Rows[0][6].ToString());
            this.NombreMonedaRegion = VariablesConfiguracionSistemaGC.Rows[0][7].ToString();
            this.MascaraMonedaRegion = VariablesConfiguracionSistemaGC.Rows[0][8].ToString();
            this.PorcentajeImpuestoSistema = decimal.Parse(VariablesConfiguracionSistemaGC.Rows[0][9].ToString());
            this.ContabilidadIntegrada = bool.Parse(VariablesConfiguracionSistemaGC.Rows[0][10].ToString());
            //Fin codigo agregado


            dGVProductosSeleccionados.DataSource = bdSourceVentasProductosDetalle;
            dGVProductosSeleccionados.AutoGenerateColumns = false;

            _DTProductosSeleccionados = new DataTable();
            _DTClientes = new DataTable();
            _DTVentasProductos = new DataTable();
            _DTVentasProductosDetalle = new DataTable();
            _DTVentasProductosTemporal = new DataTable();
            _DTVentasProductosDetalleTemporal = new DataTable();
            _DTProductosEspecificosTemporal = new DataTable();
            _DTProductosEspecificosSeleccionadosPorUsuarioTemporal = new DataTable();
            _DTProductosEspecificosAgregadosTemporal = new DataTable();
            _DTProductosEspecificosAgregadosSeleccionadosPorUsuarioTemporal = new DataTable();
            _DTProductosEspecificosAgregados = new DataTable();
            _DTProductosEspecificos = new DataTable();
            _DTUsuarios = new DataTable();

            cargarClientesComboBox();


            cargarUsuariosComboBox();

            numeroVenta = VentaUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductos");
            _DTVentasProductos = VentaProductosCLN.ObtenerVentaProducto(NumeroAgencia, numeroVenta);
            bdSourceVentasProductos.DataSource = _DTVentasProductos;

            _DTVentasProductosDetalle = VentaUtilidadesCLN.ListarDetalleDeVenta(NumeroAgencia, numeroVenta);
            _DTVentasProductosDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadVenta*PrecioUnitarioVenta");
            bdSourceVentasProductosDetalle.DataSource = _DTVentasProductosDetalle;


            fProductosBusqueda = new FProductosBusqueda(NumeroAgencia, NumeroPC, 'V', CodigoMonedaSistema);
            fFinalizarVenta = new FFinalizarVenta(NumeroAgencia, CodigoUsuario);


            _DTVentasProductosTemporal = _DTVentasProductos.Clone();
            _DTVentasProductosDetalleTemporal = fProductosBusqueda.DTProductosSeleccionados.Clone();

            //Creación de la ralación maestro detalle!
            DSMaestroDetalle = new DataSet();
            crearMaestroDetalle();



            dGVProductosSeleccionados.DataSource = bdSourceVentasProductosDetalle;
            dGVProductosSeleccionados.AutoGenerateColumns = false;
            bdSourceVentasProductos.MoveLast();

            listaTiposAgregados.Add(new TiposAgregados("P", "Promoción"));
            listaTiposAgregados.Add(new TiposAgregados("B", "Bonificación"));
            listaTiposAgregados.Add(new TiposAgregados("C", "Compensación"));
            listaTiposAgregados.Add(new TiposAgregados("O", "Obsequio"));

            DGCCodigoTipoAgregado.DataSource = listaTiposAgregados;
            DGCCodigoTipoAgregado.ValueMember = "CodigoTipoAgregado";
            DGCCodigoTipoAgregado.DisplayMember = "NombreAgregado";

            toolStripFechaVenta.Text = DateTime.Now.ToString();

            crearColumnasDTProductosEspecificos();
            crearColumnasDTProductosEspecificosAgregados();

            bdNavDetalleVenta.Visible = true;
            bdNavProductosAgregados.Visible = true;
            bdNavVentaProductosEspecificos.Visible = true;
            crearCheckBoxHeader();

            habilitarCampos(false);
            //habilitarBotonesVentas(true, true, false, false, false, false, false, false, false, true, true);
        }

        public void CargarConfiguracionInicial(string NombreMonedaSistema, int CodigoMonedaSistema, string MascaraMonedaSistema, int CodigoMonedaRegion, string NombreMonedaRegion, string MascaraMonedaRegion, decimal PorcentajeImpuestoSistema)
        {
            this.NombreMonedaSistema = NombreMonedaSistema;
            this.CodigoMonedaSistema = CodigoMonedaSistema;
            this.MascaraMonedaSistema = MascaraMonedaSistema;
            this.CodigoMonedaRegion = CodigoMonedaRegion;
            this.NombreMonedaRegion = NombreMonedaRegion;
            this.MascaraMonedaRegion = MascaraMonedaRegion;
            this.PorcentajeImpuestoSistema = PorcentajeImpuestoSistema;
        }

        public void crearCheckBoxHeader()
        {
            //Para los Productos Especificos
            System.Drawing.Rectangle rect = dGVProductosEspecificos.GetCellDisplayRectangle(4, -1, true);
            // set checkbox header to center of header cell. +1 pixel to position correctly.
            //rect.X = rect.Location.X + (rect.Width / 4);
            rect.X = dGVProductosEspecificos.Width - 43;
            rect.Y += 2;
            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Checked = true;
            checkboxHeader.Name = "checkboxHeader";
            checkboxHeader.Size = new Size(17, 17);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);

            dGVProductosEspecificos.Controls.Add(checkboxHeader);

            //Para los Productos Especificos Agregados
            System.Drawing.Rectangle rect2 = dtGVProductosAgregados.GetCellDisplayRectangle(4, -1, true);
            rect2.X = dtGVProductosAgregados.Width - 15;
            rect2.Y += 2;
            CheckBox checkboxHeaderAgregados = new CheckBox();
            checkboxHeaderAgregados.Checked = true;
            checkboxHeaderAgregados.Name = "checkboxHeaderAgregados";
            checkboxHeaderAgregados.Size = new Size(17, 17);
            checkboxHeaderAgregados.Location = rect2.Location;
            checkboxHeaderAgregados.CheckedChanged += new EventHandler(checkboxHeaderAgregados_CheckedChanged);

            dtGVProductosAgregados.Controls.Add(checkboxHeaderAgregados);
        }

        void checkboxHeaderAgregados_CheckedChanged(object sender, EventArgs e)
        {
            bool EstadoCheckEspecificos = ((CheckBox)dtGVProductosAgregados.Controls.Find("checkboxHeaderAgregados", true)[0]).Checked;
            for (int i = 0; i < dtGVProductosAgregados.RowCount; i++)
            {
                dtGVProductosAgregados[7, i].Value = EstadoCheckEspecificos;
            }
            dtGVProductosAgregados.EndEdit();
        }

        void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            bool estadoCheckAgregados = ((CheckBox)dGVProductosEspecificos.Controls.Find("checkboxHeader", true)[0]).Checked;
            for (int i = 0; i < dGVProductosEspecificos.RowCount; i++)
            {
                dGVProductosEspecificos[4, i].Value = estadoCheckAgregados;
            }
            dGVProductosEspecificos.EndEdit();

        }

        public void crearMaestroDetalle()
        {
            DSMaestroDetalle.Locale = System.Globalization.CultureInfo.InvariantCulture;

            DataColumn ColumnPrimaryAgencia = new DataColumn();
            DataColumn ColumnPrimaryNumeroVenta = new DataColumn();

            DataColumn ColumnForeignAgenciaDetalle = new DataColumn();
            DataColumn ColumnForeignNumeroVentaDetalle = new DataColumn();

            ColumnPrimaryAgencia = _DTVentasProductos.Columns[0];
            ColumnPrimaryNumeroVenta = _DTVentasProductos.Columns[1];

            ColumnForeignAgenciaDetalle = _DTVentasProductosDetalle.Columns[0];
            ColumnForeignNumeroVentaDetalle = _DTVentasProductosDetalle.Columns[1];

            if (DSMaestroDetalle.Relations.Count > 0)
                DSMaestroDetalle.Relations.Clear();
            if (DSMaestroDetalle.Tables.Count > 0)
            {
                bdSourceVentasProductosDetalle.DataMember = "";
                bdSourceVentasProductos.DataMember = "";
                DSMaestroDetalle.Tables[1].Constraints.Remove("VentasProductosMaestroDetalle");
                DSMaestroDetalle.Tables[0].Constraints.Clear();
                DSMaestroDetalle.Tables[1].Constraints.Clear();
                DSMaestroDetalle.Tables.RemoveAt(1);
                DSMaestroDetalle.Tables.Clear();
            }

            DSMaestroDetalle.Tables.Add(_DTVentasProductos);
            DSMaestroDetalle.Tables.Add(_DTVentasProductosDetalle);
            DataRelation relacionMaestroDetalle = new DataRelation("VentasProductosMaestroDetalle", new DataColumn[] { ColumnPrimaryAgencia, ColumnPrimaryNumeroVenta }, new DataColumn[] { ColumnForeignAgenciaDetalle, ColumnForeignNumeroVentaDetalle }, true);
            DSMaestroDetalle.Relations.Add(relacionMaestroDetalle);

            bdSourceVentasProductos.DataSource = DSMaestroDetalle;
            bdSourceVentasProductos.DataMember = "VentasProductos";

            bdSourceVentasProductosDetalle.DataSource = bdSourceVentasProductos;
            bdSourceVentasProductosDetalle.DataMember = "VentasProductosMaestroDetalle";


            bdNavDetalleVenta.BindingSource = bdSourceVentasProductosDetalle;
            ListSortDirection direction = ListSortDirection.Ascending;


            //Cargamos los Productos Especificos
            _DTProductosEspecificos = VentaProductosEspecificosCLN.ListarVentasProductosEspecificosParaVenta(NumeroAgencia, numeroVenta);
            bdSourceVentaProductosEspecificos.DataSource = _DTProductosEspecificos;
            if (_DTProductosEspecificos.Rows.Count > 0)
            {
                if (!DSMaestroDetalle.Tables.Contains(_DTProductosEspecificos.TableName))
                    DSMaestroDetalle.Tables.Add(_DTProductosEspecificos);
                dtGVVentaProductosEspecificos.BindData(DSMaestroDetalle, _DTProductosEspecificos.TableName);
                dtGVVentaProductosEspecificos.GroupTemplate.Column = dtGVVentaProductosEspecificos.Columns[0];
                dtGVVentaProductosEspecificos.Sort(new DataRowComparer(0, direction));

                dtGVVentaProductosEspecificos.Height = AlturaDGVProductosEspecificos;
                dtGVVentaProductosEspecificos.Visible = true;
                dtGVVentaProductosEspecificos.Dock = DockStyle.Bottom;

                dGVProductosEspecificos.Visible = false;
                dGVProductosEspecificos.Height = 0;
                dGVProductosEspecificos.Dock = DockStyle.None;
            }
            else
            {
                dGVProductosEspecificos.Visible = true;
                dGVProductosEspecificos.Height = AlturaDGVProductosEspecificos;
                dGVProductosEspecificos.Dock = DockStyle.Fill;

                dtGVVentaProductosEspecificos.Visible = false;
                dtGVVentaProductosEspecificos.Dock = DockStyle.None;
                dtGVVentaProductosEspecificos.Height = 0;
            }



            //Cargamos los Productos Agregados            
            _DTProductosEspecificosAgregados = VentaproductosAgregados.ListarVentasProductosEspecificosAgregadosParaVenta(NumeroAgencia, numeroVenta);
            bdSourceVentaProductosAgregados.DataSource = _DTProductosEspecificosAgregados;
            if (_DTProductosEspecificosAgregados.Rows.Count > 0)
            {
                if (!DSMaestroDetalle.Tables.Contains(_DTProductosEspecificosAgregados.TableName))
                    DSMaestroDetalle.Tables.Add(_DTProductosEspecificosAgregados);
                dtGVVentaProductosEspecificosAgregados.BindData(DSMaestroDetalle, _DTProductosEspecificosAgregados.TableName);
                dtGVVentaProductosEspecificosAgregados.GroupTemplate.Column = dtGVVentaProductosEspecificosAgregados.Columns[0];
                dtGVVentaProductosEspecificosAgregados.Sort(new DataRowComparer(0, direction));

                dtGVVentaProductosEspecificosAgregados.Visible = true;
                dtGVVentaProductosEspecificosAgregados.Height = AlturaDGVProductosAgregados;
                dtGVVentaProductosEspecificosAgregados.Dock = DockStyle.Bottom;

                dtGVProductosAgregados.Visible = false;
                dtGVProductosAgregados.Height = 0;
                dtGVProductosAgregados.Dock = DockStyle.None;
            }
            else
            {
                dtGVProductosAgregados.Visible = true;
                dtGVProductosAgregados.Height = AlturaDGVProductosAgregados;
                dtGVProductosAgregados.Dock = DockStyle.Fill;

                dtGVVentaProductosEspecificosAgregados.Visible = false;
                dtGVVentaProductosEspecificosAgregados.Dock = DockStyle.None;
                dtGVVentaProductosEspecificosAgregados.Height = 0;
            }
        }

        public void cargarClientesComboBox()
        {
            _DTClientes = ClienteCLN.ListarClientesVentas();
            cBoxCliente.DataSource = _DTClientes;
            cBoxCliente.DisplayMember = "NombreCliente";
            cBoxCliente.ValueMember = "CodigoCliente";
        }

        public void cargarUsuariosComboBox()
        {
            _DTUsuarios = Usuarios.ListarDatosUsuarioTransacciones();
            cBoxVendedor.DataSource = _DTUsuarios;
            cBoxVendedor.DisplayMember = "NombreUsuario";
            cBoxVendedor.ValueMember = "CodigoUsuario";

            _DTMonedas = MonedaCLN.ListarMonedas();
            cBoxMoneda.DataSource = _DTMonedas;
            cBoxMoneda.DisplayMember = "NombreMoneda";
            cBoxMoneda.ValueMember = "CodigoMoneda";
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            fProductosBusqueda.inhabilitarControlesParaCotizacion(false);
            fProductosBusqueda.limpiarControles();
            cBoxMoneda.SelectedValue = CodigoMonedaSistema;
            TipoOperacion = "N";
            NumeroCredito = null;
            rBtnEfectivo.Checked = true;
            EsCodigoTipoCreditoLibreDispocion = true;

            if ((sender as ToolStripButton).Name.CompareTo("btnNuevaVenta") == 0)
            {
                ventaParaInsitituciones = false;
                CodigoTipoVenta = 'N';
            }
            else
            {
                ventaParaInsitituciones = true;
                CodigoTipoVenta = 'T';
                rBtnCredito.Enabled = false;
            }

            checkBIncluirFactura.Checked = false;

            cBoxVendedor.SelectedValue = CodigoUsuario;
            usuarioSeleccionaEspecifico = false;
            usuarioSeleccionaEspecificoAgregados = false;
            txtBoxObservaciones.Clear();
            _DTProductosEspecificosAgregadosTemporal.Clear();
            _DTProductosEspecificosTemporal.Clear();
            CantidadProductosAgregados = 0;
            CantidadProductosEspecificos = 0;
            mostrarGrillasNuevaVenta(true);
            bdSourceVentaProductosAgregados.DataSource = _DTProductosEspecificosAgregadosTemporal;
            bdSourceVentaProductosEspecificos.DataSource = _DTProductosEspecificosTemporal;

            if (cBoxCliente.DataSource == null || _DTClientes.Rows.Count == 0)
            {
                _DTClientes = ClienteCLN.ObtenerCliente(1);
                if (_DTClientes.Rows.Count != 0)
                {
                    cBoxCliente.Items.Clear();
                    cBoxCliente.Items.Add(_DTClientes.Rows[0]["NombreCliente"].ToString().Trim());
                    cBoxCliente.SelectedIndex = 0;
                }
            }
            else
            {
                cBoxCliente.SelectedValue = 1.ToString();
            }

            bdSourceVentasProductos.DataSource = _DTVentasProductosTemporal;
            _DTVentasProductosDetalleTemporal = fProductosBusqueda.DTProductosSeleccionados;
            bdSourceVentasProductosDetalle.DataSource = _DTVentasProductosDetalleTemporal;
            formatearEstiloTabla(true);
            numeroVenta = VentaUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductos");
            if (numeroVenta == 0) numeroVenta = 1;
            if (numeroVenta > 1)
                numeroVenta++;
            if (numeroVenta == 1 && _DTVentasProductos.Rows.Count == 1)
                numeroVenta = 2;

            lblNumeroVenta.Text = numeroVenta.ToString();
            lblEstado.Text = "Iniciada";
            toolStripPBEstado.Value = (int)(toolStripPBEstado.Maximum) / 3;
            habilitarBotonesVentas(false, false, true, true, false, true, false, true, true, false, false);
            fProductosBusqueda.LabelNombrePersonaTransaccion.Text = this.cBoxCliente.Text;
            fProductosBusqueda.LabelNumeroTransaccion.Text = this.numeroVenta.ToString();

            if (rBtnCredito.Checked)
                fProductosBusqueda.LabelTipoTransaccion.Text = "Crédito";
            if (rBtnEfectivo.Checked)
                fProductosBusqueda.LabelTipoTransaccion.Text = "Efectivo";
            this.txtBoxPrecioTotal.Text = fProductosBusqueda.LabelPrecioTotal.Text;
            habilitarCampos(true);
            if (CodigoTipoVenta == 'T')
                rBtnCredito.Enabled = false;
            fProductosBusqueda.ShowDialog(this);


            if (fProductosBusqueda.DTProductosSeleccionados.Rows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún Producto para su Venta, se procederá a cancelar la operación Actual");
                btnCancelar_Click(sender, e);
                return;
            }
            if (fProductosBusqueda.seleccionarProductosEspecificos)
            {
                tabControl1.SelectedTab = tabPage3;
                usuarioSeleccionaEspecifico = true;
            }
            if (fProductosBusqueda.detalleConfirmado)
            {
                this.txtBoxPrecioTotal.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false").ToString() + " " + MascaraMonedaSistema;
                this.txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;
                this.tabControl1.TabIndex = 0;

                dGVProductosEspecificos.Visible = true;
                dGVProductosEspecificos.Dock = DockStyle.Bottom;
                dGVProductosEspecificos.Height = AlturaDGVProductosEspecificos;

                dtGVVentaProductosEspecificos.Visible = false;
                dtGVVentaProductosEspecificos.Dock = DockStyle.None;
                dtGVVentaProductosEspecificos.Height = 0;
            }
            else
            {
                this.txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
                this.txtBoxPrecioTotalCancelar.Text = " 0.00 " + MascaraMonedaSistema;
                lblNumeroVenta.Text = "";
                toolStripPBEstado.Value = 0;
            }
            //this.dataGridView1.Sort(this.dataGridView1.Columns["Name"],ListSortDirection.Ascending);

            //existenModificacionesEspecificos = true;
            //existenModificacionesAgregados = true;

            //------ PARA REVISAR PRODUCTOS ESPECIFICOS
            //verificarProductosEspecificosAgregados();

            tabControl1.SelectedIndex = 0;
            revisarProductosInalcanzables();
            cBoxCliente.Focus();

        }

        public void revisarProductosInalcanzables()
        {
            if (fProductosBusqueda.ExistenProductosInalcanzables)
            {

                dGVProductosSeleccionados.Columns[4].Width = 90;
                dGVProductosSeleccionados.ReadOnly = false;
                foreach (DataGridViewColumn columna in dGVProductosSeleccionados.Columns)
                    columna.ReadOnly = true;

                if (!DGCCantidadEntregada.Visible)
                    DGCCantidadEntregada.Visible = true;
                DGCCantidadEntregada.HeaderText = "Entregados";
                DGCCantidadEntregada.Width = 70;
                DGCCantidadEntregada.ReadOnly = false;
                DGCCantidadEntregada.DisplayIndex = 3;

                int CantidadVendida = 0;
                int CantidadEntregada = 0;
                int CantidadExistencia = 0;
                foreach (DataRow fila in fProductosBusqueda.DTProductosSeleccionados.Rows)
                {
                    CantidadVendida = Int32.Parse(fila["Cantidad"].ToString());
                    CantidadExistencia = Int32.Parse(fila["CantidadExistencia"].ToString());//CantidadEntregada
                    if (CantidadVendida > CantidadExistencia)
                    {
                        CantidadEntregada = CantidadExistencia;
                        fila["CantidadEntregada"] = CantidadEntregada;
                    }
                    else
                    {
                        fila["CantidadEntregada"] = CantidadVendida;
                    }

                }
            }
            else
            {
                //para cuando se debe revisar los otros casos                
                int CantidadExistencia = 0;
                foreach (DataRow fila in fProductosBusqueda.DTProductosSeleccionados.Rows)
                {
                    CantidadExistencia = Int32.Parse(fila["CantidadExistencia"].ToString());//CantidadEntregada
                    if (CantidadExistencia == 0)
                    {
                        fila["CantidadEntregada"] = 0;
                    }
                }
            }

        }
        public void verificarProductosEspecificosAgregados()
        {
            //this.DGViewProductosSeleccionados.Sort(this.DGViewProductosSeleccionados.Columns[7], ListSortDirection.Ascending);
            object NumeroAgregados = _DTVentasProductosDetalleTemporal.Compute("count(VendidoComoAgregado)", "VendidoComoAgregado = true");
            object NumeroEspecficos = _DTVentasProductosDetalleTemporal.Compute("count(EsProductoEspecifico)", "EsProductoEspecifico = true");
            if (!NumeroEspecficos.Equals(0))
            {
                CantidadProductosEspecificos = Int32.Parse(NumeroEspecficos.ToString());
                existenModificacionesEspecificos = true;
            }
            else
            {
                if (_DTProductosEspecificosTemporal.Rows.Count > 0)
                {
                    _DTProductosEspecificosTemporal.Clear();
                    existenModificacionesEspecificos = false;
                }
            }
            if (!NumeroAgregados.Equals(0))
            {
                if (MessageBox.Show(this, "Ha Decidido añadir a esta Venta alguns Productos Como Agregados." + Environment.NewLine + "Si Desea continuar el Proceso con Los Productos Seleccionados Presiona 'Si', Caso Contrario Todos los Productos que sean Considerados como Agregados, serán cambiado de Estado" + Environment.NewLine + "¿Desea continuar con la Venta en esta Situación?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CantidadProductosAgregados = Int16.Parse(NumeroAgregados.ToString());
                    existenModificacionesAgregados = true;
                    foreach (DataGridViewRow fila in DGViewProductosSeleccionados.Rows)
                    {
                        if (fila.Cells[7].Value.Equals(true))
                        {
                            resaltarFilaProductoSeleccionado(fila, true);
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow fila in DGViewProductosSeleccionados.Rows)
                    {
                        if (fila.Cells[7].Value.Equals(true))
                        {
                            _DTVentasProductosDetalleTemporal.Rows[fila.Index].BeginEdit();
                            _DTVentasProductosDetalleTemporal.Rows[fila.Index][7] = false;
                            _DTVentasProductosDetalleTemporal.Rows[fila.Index].AcceptChanges();
                            fila.Cells[7].Value = false;
                            resaltarFilaProductoSeleccionado(fila, false);
                        }
                    }
                    CantidadProductosAgregados = 0;
                }
            }
            else
            {
                if (_DTProductosEspecificosAgregadosTemporal.Rows.Count > 0)
                {
                    _DTProductosEspecificosAgregadosTemporal.Clear();
                    existenModificacionesAgregados = false;
                }
                txtBoxPrecioAgregados.Text = "0.00 " + MascaraMonedaSistema;
            }
        }
        private void resaltarFilaProductoSeleccionado(DataGridViewRow fila, bool resaltar)
        {
            if (resaltar)
            {
                fila.DefaultCellStyle.BackColor = ColorResaltado;
            }
            else
            {
                fila.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dGVProductosSeleccionados[1, 0].Value.ToString());
            FBuscarClientes formClientes = new FBuscarClientes();
            formClientes.ShowDialog(this);
            int CodigoCliente = formClientes.CodigoCliente;
            if (cBoxCliente.DataSource == null)
            {
                cargarClientesComboBox();
                cBoxCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
                cBoxCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            if (CodigoCliente >= 0)
            {
                cBoxCliente.SelectedValue = CodigoCliente.ToString();
            }

        }

        private void btnModificarVenta_Click(object sender, EventArgs e)
        {
            if (btnNuevaVenta.Enabled || btnVentaInstitucional.Enabled)
            {
                //txtBoxObservaciones.Enabled = true;
                habilitarCampos(true);
                btnClientesBuscar.Enabled = true;
                btnAgregarCliente.Enabled = true;
                TipoOperacion = "E";
                int indice = 0;

                CodigoTipoVenta = _DTVentasProductos.Rows[0]["CodigoTipoVenta"].ToString()[0];
                DTVentasProductosDetalleTemporal.Clear();
                foreach (DataRow FilaNueva in _DTVentasProductosDetalle.Rows)
                {
                    DataRow FilaProducto = DTVentasProductosDetalleTemporal.NewRow();
                    FilaProducto["Código Producto"] = FilaNueva["CodigoProducto"];
                    FilaProducto["Nombre Producto"] = FilaNueva["NombreProducto"];
                    FilaProducto["Cantidad"] = FilaNueva["CantidadVenta"];
                    FilaProducto["Precio"] = FilaNueva["PrecioUnitarioVenta"];
                    FilaProducto["PrecioTotal"] = Decimal.Round(int.Parse(FilaNueva["CantidadVenta"].ToString()) * decimal.Parse(FilaNueva["PrecioUnitarioVenta"].ToString()), 2);
                    FilaProducto["Garantia"] = FilaNueva["TiempoGarantiaVenta"];
                    FilaProducto["EsProductoEspecifico"] = VentaUtilidadesCLN.esProductoEspecifico(NumeroAgencia, FilaNueva["CodigoProducto"].ToString());
                    FilaProducto["VendidoComoAgregado"] = false;
                    FilaProducto["CantidadExistencia"] = VentaUtilidadesCLN.ObtenerExistenciaProductoInventario(NumeroAgencia, FilaNueva["CodigoProducto"].ToString());
                    FilaProducto["CantidadEntregada"] = FilaNueva["CantidadEntregada"];
                    FilaProducto["PorcentajeDescuento"] = FilaNueva["PorcentajeDescuento"];
                    FilaProducto["NumeroPrecioSeleccionado"] = FilaNueva["NumeroPrecioSeleccionado"];
                    DTVentasProductosDetalleTemporal.Rows.Add(FilaProducto);
                    indice++;
                }
                DTVentasProductosDetalleTemporal.AcceptChanges();
                fProductosBusqueda.DTProductosSeleccionados = this._DTVentasProductosDetalleTemporal;
                fProductosBusqueda.BDSourceProductosSeleccionados.DataSource = fProductosBusqueda.DTProductosSeleccionados;
                fProductosBusqueda.DTGridViewProductosSeleccionados.DataSource = fProductosBusqueda.BDSourceProductosSeleccionados;
                fProductosBusqueda.nuevaVenta = false;
                fProductosBusqueda.ListaCodigosProductosEliminados.Clear();
                // fProductosBusqueda.cargarPieDetalleResultado();
                bdSourceVentasProductosDetalle.DataSource = _DTVentasProductosDetalleTemporal;
                formatearEstiloTabla(true);
                habilitarBotonesVentas(false, false, true, true, false, true, false, true, true, false, false);

                if (checkBIncluirFactura.Checked)
                {
                    QuitarPrecioFactura(true);
                    ventaConFactura = true;
                }
                else
                    ventaConFactura = false;
                checkBIncluirFactura.Enabled = true;
                EsCodigoTipoCreditoLibreDispocion = true;
            }

            if (esCotizacionVenta)
            {
                fProductosBusqueda.DTProductosSeleccionados = this._DTVentasProductosDetalleTemporal;

            }
            if (ventaParaInsitituciones && esCotizacionVenta)
            {
                TipoOperacion = "N";
                if (checkBIncluirFactura.Checked)
                {
                    ventaConFactura = true;
                }
                else
                    ventaConFactura = false;
                checkBIncluirFactura.Enabled = false;
            }

            if (ventaConFactura && TipoOperacion == "N" && !esCotizacionVenta)
                DTVentasProductosDetalleTemporal.RejectChanges();


            fProductosBusqueda.ShowDialog(this);

            if (fProductosBusqueda.DTProductosSeleccionados.Rows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún Producto para su Venta, se procederá a cancelar la operación Actual");
                btnCancelar_Click(sender, e);
                return;
            }

            //existenModificacionesEspecificos = true;
            //existenModificacionesAgregados = true;
            verificarProductosEspecificosAgregados();
            revisarProductosInalcanzables();

            this.txtBoxPrecioTotal.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false").ToString() + " " + MascaraMonedaSistema;
            this.txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;
            tabControl1.SelectedIndex = 0;
            if (ventaConFactura && !esCotizacionVenta)
                AumentarPrecioFactura(TipoOperacion == "N" ? false : true);

            CodigoMonedaActual = int.Parse(cBoxMoneda.SelectedValue.ToString());
            if (CodigoMonedaActual != CodigoMonedaSistema)
                cambiarCotizacion();
        }

        /// <summary>
        /// Se encarga de Formatear las Columnas del DataGridView ProductosSeleccionados
        /// de Acuerdo a la Operación que se desea mostrar
        /// en caso de que se desea mostrar el detalle de una Venta ya Realizada, pasar como parametro false,
        /// caso contrario True, para mostrar el Detalle Actual de una Venta en Curso
        /// </summary>
        /// <param name="esParaVender"> si La Venta se lleva en Curso</param>
        public void formatearEstiloTabla(bool esParaVender)
        {
            if (esParaVender)
            {
                DGCCodigoProductoD.Width = 80;
                DGCCodigoProductoD.ToolTipText = "Código del Producto Seleccionado";
                DGCCodigoProductoD.HeaderText = "Código";
                DGCCodigoProductoD.DataPropertyName = "Código Producto";

                DGCNombreProductoD.Width = 320;
                DGCNombreProductoD.ToolTipText = "Nombre del Producto Seleccionado";
                DGCNombreProductoD.HeaderText = "Nombre Producto";
                DGCNombreProductoD.DataPropertyName = "Nombre Producto";

                //DGCCantidadVenta.Width = 80;                
                DGCCantidadVenta.ToolTipText = "Catidad Seleccionada a ser vendida";
                DGCCantidadVenta.HeaderText = "Vendidos";
                DGCCantidadVenta.DataPropertyName = "Cantidad";

                //DGCPrecioUnitarioVentaD.Width = 100;                
                DGCPrecioUnitarioVentaD.ToolTipText = "Precio del Producto Seleccionado";
                DGCPrecioUnitarioVentaD.HeaderText = "Precio";
                DGCPrecioUnitarioVentaD.DataPropertyName = "Precio";

                //DGCTiempoGarantiaVentaD.Width = 100;                
                DGCTiempoGarantiaVentaD.DataPropertyName = "Garantia";

                //this.dGVProductosSeleccionados.Columns[6].Width = 80;
                //this.dGVProductosSeleccionados.Columns[6].ToolTipText = "Tiempo de TiempoGarantiaPE del Producto en Meses";
                ////this.dGVProductosSeleccionados.Columns[5].HeaderCell = "Garantía";
                //this.dGVProductosSeleccionados.Columns[6].HeaderText = "Garantía";


                //DGCPrecioTotal.Width = 95;
                DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
                dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                dataGridViewCellStyle2.Format = "C2";
                dataGridViewCellStyle2.NullValue = "0";
                dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
                DGCPrecioTotal.DefaultCellStyle = dataGridViewCellStyle2;
                DGCPrecioTotal.HeaderText = "Precio Total";
                DGCPrecioTotal.ReadOnly = true;
                DGCPrecioTotal.ToolTipText = "Precio Total del la Venta del Producto Seleccionado";
                DGCPrecioTotal.DataPropertyName = "PrecioTotal";

                //DGCCantidadEntregada.Width = 80;
                DGCCantidadEntregada.Resizable = System.Windows.Forms.DataGridViewTriState.False;
                DGCCantidadEntregada.ToolTipText = "Catidad Seleccionada que debe ser entregada";
                DGCCantidadEntregada.HeaderText = "Entregados";
                DGCCantidadEntregada.DataPropertyName = "CantidadEntregada";
            }
            else
            {

                DGCCodigoProductoD.Width = 80;
                DGCCodigoProductoD.ToolTipText = "Código del Producto Seleccionado";
                DGCCodigoProductoD.HeaderText = "Código";
                DGCCodigoProductoD.DataPropertyName = "CodigoProducto";

                DGCNombreProductoD.Width = 320;
                DGCNombreProductoD.ToolTipText = "Nombre del Producto Seleccionado";
                DGCNombreProductoD.HeaderText = "Nombre Producto";
                DGCNombreProductoD.DataPropertyName = "NombreProducto";


                //DGCCantidadVenta.Width = 80;                
                DGCCantidadVenta.ToolTipText = "Catidad Seleccionada";
                DGCCantidadVenta.HeaderText = "Cantidad";
                DGCCantidadVenta.DataPropertyName = "CantidadVenta";

                //DGCPrecioUnitarioVentaD.Width = 100;                
                DGCPrecioUnitarioVentaD.ToolTipText = "Precio del Producto Seleccionado";
                DGCPrecioUnitarioVentaD.HeaderText = "Precio";
                DGCPrecioUnitarioVentaD.DataPropertyName = "PrecioUnitarioVenta";

                //DGCTiempoGarantiaVentaD.Width = 80;
                DGCTiempoGarantiaVentaD.ToolTipText = "Tiempo de Garantia del Producto en Meses";
                DGCTiempoGarantiaVentaD.HeaderText = "Garantía";
                DGCTiempoGarantiaVentaD.DataPropertyName = "TiempoGarantiaVenta";

                //DGCPrecioTotal.Width = 95;
                //DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
                //dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                //dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                //dataGridViewCellStyle2.Format = "C2";
                //dataGridViewCellStyle2.NullValue = "0";
                //dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
                //this.dGVProductosSeleccionados.Columns[8].DefaultCellStyle = dataGridViewCellStyle2;
                DGCPrecioTotal.HeaderText = "Precio Total";
                DGCPrecioTotal.ReadOnly = true;
                DGCPrecioTotal.ToolTipText = "Precio Total del la Venta del Producto Seleccionado";
                DGCPrecioTotal.DataPropertyName = "PrecioTotal";

                DGCCantidadEntregada.DataPropertyName = "CantidadEntregada";
                DGCPorcentajeDescuento.DataPropertyName = "PorcentajeDescuento";
            }
        }

        private void FVentasProductos_Shown(object sender, EventArgs e)
        {
            if (!this.esCotizacionVenta)
                formatearEstiloTabla(false);
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {//cBoxCliente.SelectedValue.ToString().Length>0
            //if (!DetalleCodigosEspecificosGenerados && !DetalleCodigosEspecificosAgregadosGenerados)
            //{
            //    tabControl1.SelectedTab = DetalleCodigosEspecificosAgregadosGenerados ? tabPage2 : tabPage3;                               
            //}

            if (checkBIncluirFactura.Checked)
            {
                CodigoMonedaActual = int.Parse(cBoxMoneda.SelectedValue.ToString());
                if (CodigoMonedaActual != CodigoMonedaSistema)
                    AumentarPrecioFactura(false);
                if (MessageBox.Show(this, "Ha seleccionado incluir Factura en la Venta. ¿Desea Continuar La Venta con Factura?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            //---------------------PARA LA REVISION DE EXISTENCIA DE PRODUCTOS ESPECIFICOS Y AGREGADOS
            //if (!DetalleCodigosEspecificosGenerados && CantidadProductosEspecificos>0)
            //{                
            //    MessageBox.Show("Aun no ha editado los datos de los Productos Específicos para continuar la venta");
            //    tabControl1.SelectedTab = tabPage3;
            //    return;
            //}
            //if (!DetalleCodigosEspecificosAgregadosGenerados && CantidadProductosAgregados > 0)
            //{                
            //    MessageBox.Show("Aun no ha editado los datos de los Productos agregados para continuar la venta");
            //    tabControl1.SelectedTab = tabPage2;
            //    return;
            //}
            //-----------------------------------------------------------------------------------------------------


            if (cBoxCliente.SelectedIndex != -1)
            {
                if (_DTVentasProductosDetalleTemporal.Rows.Count > 0)
                {
                    //if (fProductosBusqueda.seleccionarProductosEspecificos)
                    //{
                    //    int indiceFila = 0;                        
                    //}
                    //revisión de Errores en la Venta de Productos Agregados
                    if (CantidadProductosAgregados > 0)
                    {
                        foreach (DataGridViewRow filaGrilla in dtGVProductosAgregados.Rows)
                        {
                            foreach (DataGridViewCell celdaGrilla in filaGrilla.Cells)
                                if (celdaGrilla.Value == null && celdaGrilla.ColumnIndex > 2 && celdaGrilla.Value.ToString().Trim() == "")
                                {
                                    MessageBox.Show("Revise sus Datos, No puede Ingresar Datos Vacios en Productos Agregados, a Excepción del Codigo de Producto Especifico" + Environment.NewLine + "En caso de que el Producto no sea considerado Producto Especifico");
                                    dtGVProductosAgregados.CurrentCell = dtGVProductosAgregados[celdaGrilla.ColumnIndex, celdaGrilla.RowIndex];
                                    dtGVProductosAgregados.CurrentCell.Selected = true;
                                    return;
                                }
                        }
                    }


                    //Revisamos de que la cantidad de entrega sea coherente
                    //a la cantidad que se vende, tomando en cuenta
                    //que solo se puede entregar lo que hay en almacenes, sin sobrepasar la cantidad de Venta
                    if (fProductosBusqueda.ExistenProductosInalcanzables)
                    {
                        int CantidadVendida = 0;
                        int CantidadEntregada = 0;
                        int CantidadExistencia = 0;
                        foreach (DataRow fila in _DTVentasProductosDetalleTemporal.Rows)
                        {
                            CantidadVendida = Int32.Parse(fila["Cantidad"].ToString());
                            CantidadEntregada = Int32.Parse(fila["CantidadEntregada"].ToString());//CantidadEntregada
                            CantidadExistencia = Int32.Parse(fila["CantidadExistencia"].ToString());

                            if (CantidadEntregada > CantidadVendida)
                            {
                                if (MessageBox.Show(this, "No Puede continuar la operación debido a que existe una cantidad de entrega superior a la que desea vender. ¿Desea que el Sistema arregle la cantidad de entrega a la cantidad existencia en Almacenes?", "Venta de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    fila["CantidadEntregada"] = fila["CantidadExistencia"];
                                    fila.AcceptChanges();
                                }//Mandamos el foco a la Celda del Producto en su cantidad de Entrega
                                dGVProductosSeleccionados.CurrentCell = dGVProductosSeleccionados[DGCCantidadEntregada.Index, _DTVentasProductosDetalleTemporal.Rows.IndexOf(fila)];
                                //dGVProductosSeleccionados.Rows[_DTVentasProductosDetalleTemporal.Rows.IndexOf(fila)].Cells[_DTVentasProductosDetalleTemporal.Columns.Count - 1].Selected = true;                                
                                dGVProductosSeleccionados.BeginEdit(true);
                                MessageBox.Show(this, "Por Favor proceda a Revisar sus Datos y a continuación vuelva a realizar la confirmación de la Operación", "Venta de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //dGVProductosSeleccionados.ReadOnly = false;
                                DGCCantidadEntregada.ReadOnly = false;

                                return;
                            }
                            if (CantidadEntregada > CantidadExistencia)
                            {
                                if (MessageBox.Show(this, "No Puede continuar la operación debido a que existe una cantidad de entrega superior a la que existe en Almacenes. ¿Desea que el Sistema arregle la cantidad de entrega a la cantidad existencia en Almacenes?", "Venta de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    fila["CantidadEntregada"] = Int32.Parse(fila["CantidadExistencia"].ToString());
                                dGVProductosSeleccionados.CurrentCell = dGVProductosSeleccionados[DGCCantidadEntregada.Index, _DTVentasProductosDetalleTemporal.Rows.IndexOf(fila)];
                                //dGVProductosSeleccionados.Rows[_DTVentasProductosDetalleTemporal.Rows.IndexOf(fila)].Cells[_DTVentasProductosDetalleTemporal.Columns.Count - 1].Selected = true;
                                dGVProductosSeleccionados.BeginEdit(true);
                                MessageBox.Show(this, "Por Favor proceda a Revisar sus Datos y a continuación vuelva a realizar la confirmación de la Operación", "Venta de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ///dGVProductosSeleccionados.ReadOnly = false;
                                DGCCantidadEntregada.ReadOnly = false;
                                return;
                            }
                        }

                    }

                    if (NumeroCredito != null)
                    {
                        if (decimal.Parse(DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false").ToString()) > MontoPrestamoCredito)
                        {
                            MessageBox.Show(this, "No puede Realizar una Venta cuyo Precio Total de Pago sea superior al crédito Otorgado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    //si no existió ningun error, se Procede a registrar la Venta
                    object precioParcialDetalle = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false");
                    object precioParcialAgregados = _DTProductosEspecificosAgregadosTemporal.Compute("sum(PrecioUnitario)", "");
                    decimal PrecioAgregados = String.IsNullOrEmpty(precioParcialAgregados.ToString()) ? 0 : Decimal.Parse(precioParcialAgregados.ToString());
                    decimal PrecioTotal = Decimal.Parse(precioParcialDetalle.ToString()) + PrecioAgregados;
                    try
                    {
                        int? NumeroFactura = -1;
                        if (TipoOperacion == "N")
                        {
                            //-----------------------------------------------------------------------------------------------------------                            
                            /* habilitar todo es bloque en caso de que ocurriera error en la cantidad Entregada
                              cuando se maneja aparte el ingreso del Maestro con su Detalle
                             */

                            //if(NumeroCredito == null)
                            //    VentaProductosCLN.InsertarVentaProducto(NumeroAgencia, cBoxCliente.SelectedValue == null ? 1 : int.Parse(cBoxCliente.SelectedValue.ToString().Trim()), CodigoUsuario, checkBIncluirFactura.Checked ? NumeroFactura : null, VentaUtilidadesCLN.ObtenerFechaHoraServidor(), CodigoTipoVenta.ToString(), ventaParaInsitituciones ? "T" : "I", PrecioTotal, NumeroCredito, byte.Parse(cBoxMoneda.SelectedValue.ToString()), txtBoxObservaciones.Text);
                            //else
                            //    VentaProductosCLN.InsertarVentaProducto(NumeroAgencia, cBoxCliente.SelectedValue == null ? 1 : int.Parse(cBoxCliente.SelectedValue.ToString().Trim()), CodigoUsuario, checkBIncluirFactura.Checked ? NumeroFactura : null, VentaUtilidadesCLN.ObtenerFechaHoraServidor(), CodigoTipoVenta.ToString(), "P", PrecioTotal, NumeroCredito, byte.Parse(cBoxMoneda.SelectedValue.ToString()), txtBoxObservaciones.Text);


                            ////PARA LOS DETALLES DE LA VENTA
                            //int cantidadEntregada = 0;
                            //foreach (DataRow fila in this._DTVentasProductosDetalleTemporal.Rows)
                            //{
                            //    //si el producto no es producto Especifico Agregado
                            //    if (!fila[7].Equals(true))
                            //    {
                            //        if (fProductosBusqueda.ExistenProductosInalcanzables)
                            //            cantidadEntregada = Int32.Parse(fila["CantidadEntregada"].ToString());
                            //        else
                            //            cantidadEntregada = Int32.Parse(fila[2].ToString());
                            //        //VentaProductosDetalleCLN.InsertarVentaProductoDetalle(NumeroAgencia, numeroVenta, fila[0].ToString(), Int32.Parse(fila[2].ToString()), Int32.Parse(fila[2].ToString()), Decimal.Parse(fila[3].ToString()), 1);
                            //        VentaProductosDetalleCLN.InsertarVentaProductoDetalle(NumeroAgencia, numeroVenta, fila[0].ToString(), Int32.Parse(fila[2].ToString()), cantidadEntregada, Decimal.Parse(fila[3].ToString()), int.Parse(fila["Garantia"].ToString()), Decimal.Parse(fila["PorcentajeDescuento"].ToString()), fila["NumeroPrecioSeleccionado"].ToString());
                            //    }
                            //-----------------------------------------------------------------------------------------------------------

                            //Insertar toda la Venta en uno, incluyendo DETALLE DE VENTA MEDIANTE UN XML
                            if (_DTVentasProductosDetalleTemporal.Select("[Nombre Producto] like '%Ñ%'").Length > 0
                                || _DTVentasProductosDetalleTemporal.Select("[Nombre Producto] like '%ñ%'").Length > 0)
                            {
                                foreach (DataRow DRProducto in _DTVentasProductosDetalleTemporal.Select("[Nombre Producto] like '%Ñ%'"))
                                {
                                    DRProducto["Nombre Producto"] = DRProducto["Nombre Producto"].ToString().Replace('Ñ', 'N');
                                }

                                foreach (DataRow DRProducto in _DTVentasProductosDetalleTemporal.Select("[Nombre Producto] like '%ñ%'"))
                                {
                                    DRProducto["Nombre Producto"] = DRProducto["Nombre Producto"].ToString().Replace('ñ', 'n');
                                }
                            }
                            string ProductosDetalle = _DTVentasProductosDetalleTemporal.DataSet.GetXml().Replace("ó", "o").Replace("_x0020_", "");
                            Clipboard.SetText(ProductosDetalle);
                            if (TipoOperacion == "N")
                                VentaProductosCLN.InsertarVentaProductoXMLDetalle(NumeroAgencia, cBoxCliente.SelectedValue == null ? 1 : int.Parse(cBoxCliente.SelectedValue.ToString().Trim()), CodigoUsuario, checkBIncluirFactura.Checked ? NumeroFactura : null, VentaUtilidadesCLN.ObtenerFechaHoraServidor(), CodigoTipoVenta.ToString(), ventaParaInsitituciones ? "T" : NumeroCredito == null ? "I" : "P", PrecioTotal, NumeroCredito, byte.Parse(cBoxMoneda.SelectedValue.ToString()), txtBoxObservaciones.Text, ProductosDetalle, null, null, null);
                            else
                                VentaProductosCLN.InsertarVentaProductoXMLDetalle(NumeroAgencia, cBoxCliente.SelectedValue == null ? 1 : int.Parse(cBoxCliente.SelectedValue.ToString().Trim()), CodigoUsuario, checkBIncluirFactura.Checked ? NumeroFactura : null, VentaUtilidadesCLN.ObtenerFechaHoraServidor(), CodigoTipoVenta.ToString(), "P", PrecioTotal, NumeroCredito, byte.Parse(cBoxMoneda.SelectedValue.ToString()), txtBoxObservaciones.Text, ProductosDetalle, null, null, null);

                            //}
                            //si Existen productos agregados en la venta
                            if (CantidadProductosAgregados > 0)
                            {
                                string CodigoProducto = "";

                                foreach (DataGridViewRow filaAgregados in dtGVProductosAgregados.Rows)
                                {
                                    string CodigoProductoTemporal = filaAgregados.Cells[1].Value.ToString().Trim();
                                    string CodigoProductoEspecifico = filaAgregados.Cells[2].Value.ToString().Trim();
                                    string CodigoTipoAgregado = filaAgregados.Cells[3].Value.ToString().Trim();
                                    int TiempoGarantiaPE = Int32.Parse(filaAgregados.Cells[4].Value.ToString());
                                    DateTime FechaHoraVencimientoPE = DateTime.Parse(filaAgregados.Cells[5].Value.ToString());
                                    decimal PrecioUnitario = Decimal.Parse(filaAgregados.Cells[6].Value.ToString());
                                    if (CodigoProductoTemporal != "")
                                    {
                                        CodigoProducto = CodigoProductoTemporal;
                                    }
                                    VentaproductosAgregados.InsertarVentaProductoEspecificoAgregado(NumeroAgencia, numeroVenta, CodigoProducto, CodigoProductoEspecifico, CodigoTipoAgregado, TiempoGarantiaPE, FechaHoraVencimientoPE, PrecioUnitario);

                                }
                            }
                            //si Existen productos Especificos
                            if (_DTProductosEspecificosTemporal.Rows.Count > 0)
                            {
                                string CodigoProducto = "";

                                string NombreProducto = "";
                                string CodigoProductoTemporal = "";
                                string CodigoProductoEspecifico = "";
                                int TiempoGarantiaPE = 0;

                                dGVProductosEspecificos.EndEdit();
                                DateTime FechaHoraEntrega = _ventasUtilidadesCLN.ObtenerFechaHoraServidor();
                                for (int i = 0; i < _DTProductosEspecificosTemporal.Rows.Count; i++)
                                {
                                    DataRow fila = _DTProductosEspecificosTemporal.Rows[i];

                                    NombreProducto = fila[0].ToString();
                                    CodigoProductoTemporal = fila[1].ToString();
                                    CodigoProductoEspecifico = fila[2].ToString();
                                    TiempoGarantiaPE = Int32.Parse(fila[3].ToString());

                                    if (CodigoProductoTemporal != "")
                                    {
                                        CodigoProducto = CodigoProductoTemporal;
                                    }
                                    VentaProductosEspecificosCLN.InsertarVentaProductoEspecifico(NumeroAgencia, numeroVenta, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPE, true, FechaHoraEntrega);
                                }

                            }
                            numeroVenta = VentaUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductos");
                            cargarDatosVentas(numeroVenta);
                            cBoxCliente.Focus();
                            fFinalizarVenta.VentaConfirmar = _DTVentasProductos.Rows[_DTVentasProductos.Rows.Count - 1];

                            fFinalizarVenta.TxtMontoTotal.Text = txtBoxPrecioTotal.Text;//.ToString("C");
                            fFinalizarVenta.TxtNitCliente.Text = _DTClientes.Rows[cBoxCliente.SelectedIndex]["NITCliente"].ToString();
                            fFinalizarVenta.TxtNombreCliente.Text = cBoxCliente.Text;
                            fFinalizarVenta.TxtMontoCambio.Clear();
                            //if (btnFinalizar.Visible)
                            //    btnFinalizar_Click(sender, e);
                        }
                        else // SI SE EDITA LA VENTA
                        {
                            if (NumeroCredito == null)
                                VentaProductosCLN.ActualizarVentaProducto(NumeroAgencia, numeroVenta, cBoxCliente.SelectedValue == null ? 1 : int.Parse(cBoxCliente.SelectedValue.ToString().Trim()), CodigoUsuario, checkBIncluirFactura.Checked ? NumeroFactura : null, VentaUtilidadesCLN.ObtenerFechaHoraServidor(), CodigoTipoVenta.ToString(), PrecioTotal, ventaParaInsitituciones ? "T" : "I", NumeroCredito, byte.Parse(cBoxMoneda.SelectedValue.ToString()), txtBoxObservaciones.Text);
                            else
                                VentaProductosCLN.ActualizarVentaProducto(NumeroAgencia, numeroVenta, cBoxCliente.SelectedValue == null ? 1 : int.Parse(cBoxCliente.SelectedValue.ToString().Trim()), CodigoUsuario, checkBIncluirFactura.Checked ? NumeroFactura : null, VentaUtilidadesCLN.ObtenerFechaHoraServidor(), CodigoTipoVenta.ToString(), PrecioTotal, "P", NumeroCredito, byte.Parse(cBoxMoneda.SelectedValue.ToString()), txtBoxObservaciones.Text);


                            //PARA EL DETALLE
                            foreach (DataRow FilaProductoModificado in DTVentasProductosDetalleTemporal.Rows)
                            {
                                if (FilaProductoModificado.RowState == DataRowState.Deleted)
                                    VentaProductosDetalleCLN.EliminarVentaProductoDetalle(NumeroAgencia, numeroVenta, FilaProductoModificado["Código Producto"].ToString());
                                else
                                {
                                    int cantidadEntregada = 0;
                                    //si el producto no es producto Especifico Agregado
                                    if (!FilaProductoModificado[7].Equals(true))
                                    {
                                        if (fProductosBusqueda.ExistenProductosInalcanzables)
                                            cantidadEntregada = Int32.Parse(FilaProductoModificado["CantidadEntregada"].ToString());
                                        else
                                            cantidadEntregada = Int32.Parse(FilaProductoModificado[2].ToString());
                                        //VentaProductosDetalleCLN.InsertarVentaProductoDetalle(NumeroAgencia, numeroVenta, fila[0].ToString(), Int32.Parse(fila[2].ToString()), Int32.Parse(fila[2].ToString()), Decimal.Parse(fila[3].ToString()), 1);
                                        VentaProductosDetalleCLN.InsertarVentaProductoDetalle(NumeroAgencia, numeroVenta, FilaProductoModificado[0].ToString(), Int32.Parse(FilaProductoModificado[2].ToString()), cantidadEntregada, Decimal.Parse(FilaProductoModificado[3].ToString()), int.Parse(FilaProductoModificado["Garantia"].ToString()), Decimal.Parse(FilaProductoModificado["PorcentajeDescuento"].ToString()), FilaProductoModificado["NumeroPrecioSeleccionado"].ToString());
                                    }
                                }

                            }
                            string CodigoProducto = "";
                            foreach (DataRow FilaAntigua in _DTVentasProductosDetalle.Rows)
                            {
                                CodigoProducto = FilaAntigua["CodigoProducto"].ToString().Trim();
                                if (DTVentasProductosDetalleTemporal.Rows.Find(CodigoProducto) == null)
                                {
                                    VentaProductosDetalleCLN.EliminarVentaProductoDetalle(NumeroAgencia, numeroVenta, FilaAntigua["CodigoProducto"].ToString());
                                }
                            }

                            cargarDatosVentas(numeroVenta);
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se pudo realizar la Venta");
                        return;
                    }

                    mostarReporteParaEntregaProductosAlmacenes();
                    TipoOperacion = "";
                    esCotizacionVenta = false;
                    if (rBtnCredito.Checked)
                    {
                        gBoxDatosCreditos.Visible = false;
                        txtBoxMontoTotalCredito.Text = "0.00";
                        txtBoxMontoPagoCredito.Text = "0.00";
                        txtBoxMontoDisponibleCredito.Text = "0.00";
                    }
                }
                else
                {
                    if (MessageBox.Show(this, "No Puede Realizar Esta Transacción sin Haber por lo Menos Seleccionado una Producto para su Venta. \\n ¿Desea Agregar Productos a la Venta Actual?", "Verifique la Venta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        fProductosBusqueda.ShowDialog(this);
                    }
                    else
                    {
                        numeroVenta = VentaUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductos");
                        cargarDatosVentas(numeroVenta);
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "No Puede Aceptar La Venta Actual, sin haber Seleccionado un Cliente" + Environment.NewLine + "Se desea realizar la Venta sin Ningun Cliente, seleccione el Cliente Anonimo y Proceda a aceptar la Venta", "Ventas de Productos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cBoxCliente.Focus();
            }
            dGVProductosSeleccionados.ReadOnly = true;
        }

        public void cargarPieDetallePrecio()
        {
            //string filtro = "NumeroAgencia = " + NumeroAgencia.ToString() + " and  NumeroVentaProducto = " + _DTVentasProductos.Rows[0][1].ToString();
            //object detallePrecioTotal = _DTVentasProductosDetalle.Compute("sum(PrecioTotal)", filtro);
            if (_DTVentasProductos.Rows.Count > 0)
            {
                object detallePrecioTotal = _DTVentasProductosDetalle.Compute("sum(PrecioTotal)", "");
                object MontoTotalVenta = _DTVentasProductos.Rows[0]["MontoTotalVenta"];
                if (detallePrecioTotal.ToString().Length > 0)
                {
                    txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " " + MascaraMonedaSistema;
                    txtBoxPrecioTotalCancelar.Text = MontoTotalVenta.ToString() + " " + MascaraMonedaSistema;
                    txtBoxPrecioAgregados.Text = (Decimal.Parse(MontoTotalVenta.ToString()) - Decimal.Parse(detallePrecioTotal.ToString())).ToString() + " " + MascaraMonedaSistema;
                }
                else
                {
                    txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
                    txtBoxPrecioTotalCancelar.Text = " 0.00 " + MascaraMonedaSistema;
                    txtBoxPrecioAgregados.Text = " 0.00 " + MascaraMonedaSistema;
                }
            }
            else
            {
                txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
                txtBoxPrecioTotalCancelar.Text = " 0.00 " + MascaraMonedaSistema;
                txtBoxPrecioAgregados.Text = " 0.00 " + MascaraMonedaSistema;
            }
        }

        /// <summary>
        /// Ocurre cuando se Va navegando Las Ventas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdSourceVentasProductos_CurrentChanged(object sender, EventArgs e)
        {//WFADoblones20.FPrincipal._NumeroAgencia
            if (_DTVentasProductosDetalle.Rows.Count > 0 && _DTVentasProductosDetalle.Columns.Count > 7 && bdSourceVentasProductos.Position != -1)
            {
                //string filtro = "_NumeroAgencia =" + _DTVentasProductos.Rows[bdSourceVentasProductos.Position][0].ToString() + " and  NumeroCompraProducto =" + _DTVentasProductos.Rows[bdSourceVentasProductos.Position][1].ToString();
                cargarPieDetallePrecio();

                lblNumeroVenta.Text = _DTVentasProductos.Rows[bdSourceVentasProductos.Position][1].ToString();
                if (_DTVentasProductos.Rows[bdSourceVentasProductos.Position]["CodigoEstadoVenta"].ToString().CompareTo("F") == 0)
                {
                    lblEstado.Text = "Finalizada";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum;
                    habilitarBotonesVentas(true, true, false, false, false, false, false, false, false, true, true);
                    habilitarCampos(false);
                    int NumeroFactura = 0;
                    if (int.TryParse(_DTVentasProductos.Rows[bdSourceVentasProductos.Position]["NumeroFactura"].ToString(), out NumeroFactura))
                        facturasToolStripMenuItem.Enabled = true;
                    else
                        facturasToolStripMenuItem.Enabled = false;
                }
                if (_DTVentasProductos.Rows[bdSourceVentasProductos.Position]["CodigoEstadoVenta"].ToString().CompareTo("C") == 0)
                {
                    lblEstado.Text = "Venta de Confianza";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3 + toolStripPBEstado.Maximum / 3;
                    habilitarBotonesVentas(true, true, false, false, false, false, false, false, false, true, true);
                    habilitarCampos(false);
                }
                if (_DTVentasProductos.Rows[bdSourceVentasProductos.Position]["CodigoEstadoVenta"].ToString().CompareTo("D") == 0)
                {
                    lblEstado.Text = "Venta de Confianza en Espera";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3 + toolStripPBEstado.Maximum / 3;
                    habilitarBotonesVentas(true, true, false, false, false, false, false, false, false, true, true);
                    habilitarCampos(false);
                }
                if (_DTVentasProductos.Rows[bdSourceVentasProductos.Position]["CodigoEstadoVenta"].ToString().CompareTo("I") == 0)
                {
                    lblEstado.Text = "Iniciada";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3;
                    int? NumeroCrediAux = string.IsNullOrEmpty(_DTVentasProductos.Rows[bdSourceVentasProductos.Position]["CodigoEstadoVenta"].ToString()) ? null : (int?)1;
                    if (NumeroCrediAux == null)
                        habilitarBotonesVentas(true, true, permitirModificar, false, true, false, true, false, false, true, true);
                    else
                        habilitarBotonesVentas(true, true, permitirModificar && _ventasProductosCLN.EsPosibleModificarVentaProductos(NumeroAgencia, numeroVenta), false, true, false, true, false, false, true, true);
                    habilitarCampos(false);
                    facturasToolStripMenuItem.Enabled = false;
                }
                if (_DTVentasProductos.Rows[bdSourceVentasProductos.Position]["CodigoEstadoVenta"].ToString().CompareTo("A") == 0)
                {
                    lblEstado.Text = "Anulada";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum;
                    habilitarBotonesVentas(true, true, false, false, false, false, false, false, false, false, true);
                    habilitarCampos(false);
                }
                if (_DTVentasProductos.Rows[bdSourceVentasProductos.Position]["CodigoEstadoVenta"].ToString().CompareTo("T") == 0)
                {
                    lblEstado.Text = "Institucional";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3;
                    habilitarBotonesVentas(true, true, permitirModificar ? true : false, false, true, false, true, false, false, true, true);
                    habilitarCampos(false);
                    int NumeroFactura = 0;
                    if (int.TryParse(_DTVentasProductos.Rows[bdSourceVentasProductos.Position]["NumeroFactura"].ToString(), out NumeroFactura))
                        facturasToolStripMenuItem.Enabled = true;
                    else
                        facturasToolStripMenuItem.Enabled = false;
                }
                if (_DTVentasProductos.Rows[bdSourceVentasProductos.Position]["CodigoEstadoVenta"].ToString().CompareTo("P") == 0)
                {
                    lblEstado.Text = "Cancelada en Efectivo";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3 + toolStripPBEstado.Maximum / 3;
                    habilitarBotonesVentas(true, true, false, false, false, false, false, false, false, true, true);
                    habilitarCampos(false);

                    int NumeroFactura = 0;
                    if (int.TryParse(_DTVentasProductos.Rows[bdSourceVentasProductos.Position]["NumeroFactura"].ToString(), out NumeroFactura))
                        facturasToolStripMenuItem.Enabled = true;
                    else
                        facturasToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
            }
            if (bdSourceVentasProductos.Position != -1 && _DTVentasProductos.Rows.Count > 0)
            {
                //cBoxCliente.SelectedValue = _DTVentasProductos.Rows[bdSourceVentasProductos.Position]["CodigoCliente"].ToString();
                if (cBoxCliente.DataSource == null || _DTClientes.Rows.Count == 0)
                {
                    string CodigoCliente = _DTVentasProductos.Rows[bdSourceVentasProductos.Position]["CodigoCliente"].ToString();
                    _DTClientes = ClienteCLN.ObtenerCliente(int.Parse(CodigoCliente));

                    cBoxCliente.Items.Clear();
                    cBoxCliente.Items.Add(_DTClientes.Rows[0]["NombreCliente"].ToString().Trim());
                    cBoxCliente.SelectedValue = _DTClientes.Rows[0]["CodigoCliente"].ToString().Trim();
                    cBoxCliente.SelectedIndex = 0;
                }
                else
                {
                    cBoxCliente.SelectedValue = _DTVentasProductos.Rows[bdSourceVentasProductos.Position]["CodigoCliente"].ToString();
                }

                entregaInstitucionalToolStripMenuItem.Visible = _DTVentasProductos.Rows[bdSourceVentasProductos.Position]["CodigoTipoVenta"].ToString() == "T";


                cBoxVendedor.SelectedValue = _DTVentasProductos.Rows[bdSourceVentasProductos.Position]["CodigoUsuario"].ToString();
                if (string.IsNullOrEmpty(_DTVentasProductos.Rows[bdSourceVentasProductos.Position]["NumeroCredito"].ToString()))
                    rBtnEfectivo.Checked = true;
                else
                    rBtnCredito.Checked = true;
                txtBoxObservaciones.Text = _DTVentasProductos.Rows[bdSourceVentasProductos.Position]["Observaciones"].ToString();
                int salida = 0;
                if (int.TryParse(_DTVentasProductos.Rows[bdSourceVentasProductos.Position]["NumeroFactura"].ToString(), out salida))
                    checkBIncluirFactura.Checked = true;
                else
                    checkBIncluirFactura.Checked = false;

                toolStripFechaVenta.Text = _DTVentasProductos.Rows[bdSourceVentasProductos.Position]["FechaHoraVenta"].ToString();

                cBoxMoneda.SelectedValue = _DTVentasProductos.Rows[bdSourceVentasProductos.Position]["CodigoMoneda"].ToString();

                //if (string.IsNullOrEmpty(_DTVentasProductos.Rows[bdSourceVentasProductos.Position]["NumeroFactura"].ToString()))
                //{
                //    rBtnEfectivo.Checked = true;
                //}
                //else
                //    rBtnCredito.Checked = true;
            }
            else
            {
                habilitarCampos(false);
                habilitarBotonesVentas(true, true, false, false, false, false, false, false, false, false, false);
            }

        }


        /// <summary>
        /// Se encarga de habilitar o deshabilitar los campos del formulario de Ventas
        /// </summary>
        /// <param name="EstadoHabilitacion"></param>
        public void habilitarCampos(bool EstadoHabilitacion)
        {
            cBoxCliente.Enabled = EstadoHabilitacion;
            //cBoxVendedor.Enabled = EstadoHabilitacion;
            rBtnCredito.Enabled = EstadoHabilitacion;
            rBtnEfectivo.Enabled = EstadoHabilitacion;
            //txtBoxObservaciones.Enabled = EstadoHabilitacion;
            cBoxCliente.BackColor = System.Drawing.SystemColors.Window;
            cBoxVendedor.BackColor = System.Drawing.SystemColors.Window;
            txtBoxObservaciones.BackColor = System.Drawing.SystemColors.Window;
            checkBIncluirFactura.Enabled = EstadoHabilitacion;
            cBoxMoneda.Enabled = EstadoHabilitacion;

            btnClientesBuscar.Enabled = EstadoHabilitacion;
            btnAgregarCliente.Enabled = EstadoHabilitacion;
            cBoxCliente.Enabled = EstadoHabilitacion;
            cMenuObservaciones.Enabled = !EstadoHabilitacion;
            txtBoxObservaciones.ReadOnly = !EstadoHabilitacion;
        }

        /// <summary>
        /// Método que se encarga de la correspondiente habilitacion de los botones que controlan
        /// la transacción de la venta, de acuerdo al Estado en que se encuentra la misma
        /// Pasar valores booleanoes en caso de desear habilitar TRUE, caso contrario FALSE
        /// </summary>
        /// <param name="nuevaVenta">Habilitar una Nueva Venta</param>
        /// <param name="nuevaVentaInstitucional">Habilitar una Nueva Venta para Instituciones</param>
        /// <param name="modificar">Modificar la Venta que se Cursa Actualmente</param>
        /// <param name="cancelar">Cancelar la Venta</param>
        /// <param name="anular">Anular la Venta</param>
        /// <param name="aceptar">Confirmar la Venta para recibir el Monto de Pago</param>
        /// <param name="finalizar">Finalizar completamente la Venta una vez terminada toda la Transacción</param>
        /// <param name="buscarCliente">para el boton de buscar cliente</param>
        /// <param name="nuevoCliente">Agregar un Nuevo cliente</param>
        /// <param name="mostrarReporte">Agregar un Nuevo cliente</param>
        /// <param name="buscarVenta">buscar una Venta</param>
        public void habilitarBotonesVentas(bool nuevaVenta, bool nuevaVentaInstitucional, bool modificar, bool cancelar, bool anular, bool aceptar, bool finalizar, bool buscarCliente, bool nuevoCliente, bool mostrarReporte, bool buscarVenta)
        {
            btnNuevaVenta.Enabled = nuevaVenta;
            btnModificar.Enabled = modificar;
            btnCancelar.Enabled = cancelar;
            btnAnular.Enabled = anular;
            btnAceptar.Enabled = aceptar;
            btnFinalizar.Enabled = finalizar;
            btnClientesBuscar.Enabled = buscarCliente;
            btnAgregarCliente.Enabled = nuevoCliente;
            btnVentaInstitucional.Enabled = nuevaVentaInstitucional;
            btnBuscar.Enabled = buscarVenta;
            btnReportes.Enabled = mostrarReporte;

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            numeroVenta = VentaUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductos");
            cBoxMoneda.SelectedValue = CodigoMonedaSistema;
            cargarDatosVentas(numeroVenta);
            if (_DTVentasProductosDetalle.Rows.Count == 0)
                habilitarBotonesVentas(true, true, false, false, false, false, false, false, false, true, true);
            habilitarCampos(false);
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //--------------------HABILITAR EN CASO DE QUE LA SELECCION DE PRODUCTOS ESPECIFICOS SE REALIZA EN ESTA VENTANA
            //if (tabControl1.SelectedTab == this.tabPage3 && btnAceptar.Enabled && _DTProductosEspecificosTemporal.Rows.Count == 0 && CantidadProductosEspecificos > 0 || existenModificacionesEspecificos)
            //{                
            //    generarDetalleVentaProductosEspecificos();
            //    existenModificacionesEspecificos = false;
            //    return;
            //}
            //else
            //{
            //    if(CantidadProductosEspecificos == 0  && _DTProductosEspecificosTemporal.Rows.Count > 0)
            //        _DTProductosEspecificosTemporal.Clear();
            //}
            //if (tabControl1.SelectedTab == this.tabPage2 && btnAceptar.Enabled && _DTProductosEspecificosAgregadosTemporal.Rows.Count == 0 && CantidadProductosAgregados > 0 || existenModificacionesAgregados)
            //{
            //    generarDetalleVentaProductosEspecificosAgregados();
            //    existenModificacionesAgregados = false;
            //    return;
            //}
            //else
            //{
            //    if (CantidadProductosAgregados == 0 && _DTProductosEspecificosAgregadosTemporal.Rows.Count > 0)
            //        _DTProductosEspecificosAgregadosTemporal.Clear();

            //}
            //----------------------------------------------------
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            fFinalizarVenta.VentaConfirmar = _DTVentasProductos.Rows[bdSourceVentasProductos.Position];
            fFinalizarVenta.TxtMontoTotal.Text = txtBoxPrecioTotalCancelar.Text;//.ToString("C");
            //fFinalizarVenta.TxtNitCliente.Text = _DTClientes.Rows[cBoxCliente.SelectedIndex]["NITCliente"].ToString();
            //fFinalizarVenta.TxtNombreCliente.Text = cBoxCliente.Text;
            DataRow fila = _DTClientes.Rows.Find(cBoxCliente.SelectedValue == null ? 1 : cBoxCliente.SelectedValue);
            if (fila == null)
            {
                fila = ClienteCLN.ObtenerCliente(Int32.Parse(_DTVentasProductos.Rows[0]["CodigoCliente"].ToString())).Rows[0];
            }
            fFinalizarVenta.TxtNitCliente.Text = fila["NITCliente"].ToString();
            fFinalizarVenta.TxtNombreCliente.Text = fila["NombreCliente"].ToString();
            fFinalizarVenta.TxtMontoCancelado.Clear();
            fFinalizarVenta.ShowDialog(this);
            if (fFinalizarVenta.ventaFinalizada)
            {
                //Actualizamos inventario                 
                int NumeroVentaProducto = Int16.Parse(_DTVentasProductos.Rows[bdSourceVentasProductos.Position][1].ToString());
                VentaUtilidadesCLN.ActualizarInventarioProductosVentas(NumeroAgencia, NumeroVentaProducto);
                int indiceActual = bdSourceVentasProductos.Position;
                numeroVenta = VentaUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductos");
                cargarDatosVentas(numeroVenta);
                bdSourceVentasProductos.Position = indiceActual;
                habilitarBotonesVentas(true, true, false, false, false, false, false, false, false, true, true);
            }

        }

        private void rBtnCredito_CheckedChanged(object sender, EventArgs e)
        {
            if ((TipoOperacion == "N" || TipoOperacion == "E") && rBtnCredito.Checked && (!btnNuevaVenta.Enabled || !btnVentaInstitucional.Enabled))
            {
                //FBuscarCreditos _FBuscarCreditos = new FBuscarCreditos();
                //_FBuscarCreditos.ShowDialog();
                //if (_FBuscarCreditos.NumeroCredito > 0)
                //{
                //    NumeroCredito = _FBuscarCreditos.NumeroCredito;
                //    MontoPrestamoCredito = VentaUtilidadesCLN.ObtenerMontoDeudaCredito(NumeroCredito);
                //}
                //else
                //{
                //    MessageBox.Show(this, "No ha ingresado un crédito válido, no puede Realizar una Venta a Credito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //    rBtnEfectivo.Checked = true;
                //    NumeroCredito = null;
                //    return;
                //}


                FVentasProductosBuscarCredito _FVentasProductosBuscarCredito = new FVentasProductosBuscarCredito(NumeroAgencia, NumeroPC);
                _FVentasProductosBuscarCredito.CodigoMonedaVenta = int.Parse(cBoxMoneda.SelectedValue.ToString());
                //if (CodigoMonedaSistema == _FVentasProductosBuscarCredito.CodigoMonedaVenta)
                //    _FVentasProductosBuscarCredito.MontoTotalVenta = (decimal)DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "");
                //else
                //{
                //    _FVentasProductosBuscarCredito.MontoTotalVenta = (decimal)(BDSourceVentaProductosSeleccionados.DataSource as DataTable).Compute("sum(PrecioTotal)", "");
                //}

                _FVentasProductosBuscarCredito.MontoTotalVenta = (decimal)(BDSourceVentaProductosSeleccionados.DataSource as DataTable).Compute("sum(PrecioTotal)", "");
                _FVentasProductosBuscarCredito.EsParaCreditoLibreDisposicion = EsCodigoTipoCreditoLibreDispocion;
                _FVentasProductosBuscarCredito.ShowDialog(this);
                if (_FVentasProductosBuscarCredito.OperacionConfirmada)
                //if(_FVentasProductosBuscarCredito.ShowDialog(this) == DialogResult.OK)
                {
                    NumeroCredito = _FVentasProductosBuscarCredito.DTCreditos[0].NumeroCredito;
                    DRCredito = _FVentasProductosBuscarCredito.DTCreditos[0];
                    MontoPrestamoCredito = DRCredito.MontoDisponible;

                    btnModificar.Enabled = false;
                    cBoxMoneda.Enabled = false;
                    checkBIncluirFactura.Enabled = false;

                    gBoxDatosCreditos.Visible = true;
                    txtBoxMontoDisponibleCredito.Text = DRCredito.MontoDisponible.ToString();
                    txtBoxMontoTotalCredito.Text = DRCredito.MontoDeuda.ToString();
                    if (DRCredito.CodigoTipoCredito == "T" || DRCredito.CodigoTipoCredito == "L")
                        txtBoxMontoPagoCredito.Text = "0.00";
                    else
                        txtBoxMontoPagoCredito.Text = (decimal.Parse(DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString()) - DRCredito.MontoDisponible).ToString();
                }
                else
                {
                    MessageBox.Show(this, "No ha ingresado un crédito válido, no puede Realizar una Venta a Credito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    rBtnEfectivo.Checked = true;
                    NumeroCredito = null;
                    gBoxDatosCreditos.Visible = false;
                    txtBoxMontoPagoCredito.Text = "0.00";
                    txtBoxMontoDisponibleCredito.Text = "0.00";
                    txtBoxMontoTotalCredito.Text = "0.00";
                    return;
                }




            }
        }

        private void rBtnEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            NumeroCredito = null;
            DRCredito = null;
            btnModificar.Enabled = TipoOperacion == "N" || TipoOperacion == "E";
            cBoxMoneda.Enabled = TipoOperacion == "N" || TipoOperacion == "E";
            checkBIncluirFactura.Enabled = TipoOperacion == "N" || TipoOperacion == "E";
        }

        public void cargarDatosVentas(int NumeroVenta)
        {
            this._DTProductosSeleccionados.Rows.Clear();
            this.fProductosBusqueda.nuevaVenta = true;

            DSMaestroDetalle.AcceptChanges();
            _DTVentasProductos = VentaProductosCLN.ObtenerVentaProducto(NumeroAgencia, NumeroVenta);
            _DTVentasProductosDetalle = VentaUtilidadesCLN.ListarDetalleDeVenta(NumeroAgencia, NumeroVenta);
            _DTVentasProductosDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadVenta*PrecioUnitarioVenta");
            crearMaestroDetalle();
            formatearEstiloTabla(false);
            bdSourceVentasProductos.MoveLast();
            CodigoMonedaActual = int.Parse(cBoxMoneda.SelectedValue.ToString());
            numeroVenta = NumeroVenta;
            if (CodigoMonedaActual != CodigoMonedaSistema)
            {
                DataTable DTDetalleProductosTemporal;
                DateTime FechaHoraVenta = DateTime.Parse(_DTVentasProductos.Rows[0]["FechaHoraVenta"].ToString());

                if (!string.IsNullOrEmpty(_DTVentasProductos.Rows[0]["NumeroFactura"].ToString()))
                {
                    QuitarPrecioFacturaVentaFinalizada();
                }

                DTDetalleProductosTemporal = VentaUtilidadesCLN.CambiarMonedaCotizacionDetalleDeTransaccion(NumeroAgencia, CodigoMonedaActual, FechaHoraVenta, checkBIncluirFactura.Checked, 'V', NumeroVenta, true);
                BDSourceVentaProductosSeleccionados.DataSource = DTDetalleProductosTemporal;
                dGVProductosSeleccionados.DataSource = BDSourceVentaProductosSeleccionados;
                txtBoxPrecioTotal.Text = DTDetalleProductosTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + _DTMonedas.Rows.Find(CodigoMonedaActual)["MascaraMoneda"].ToString();
                txtBoxPrecioTotalCancelar.Text = DTDetalleProductosTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + _DTMonedas.Rows.Find(CodigoMonedaActual)["MascaraMoneda"].ToString();

            }
        }

        private void dGVProductosSeleccionados_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se encuentra seguro de Anular la Orden de Venta Actual?", "Anulación de Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            int indiceActual = bdSourceVentasProductos.Position;
            VentaProductosCLN.ActualizarVentaProducto(NumeroAgencia, Int16.Parse(_DTVentasProductos.Rows[indiceActual][1].ToString()), cBoxCliente.SelectedValue == null ? 1 : Int16.Parse(cBoxCliente.SelectedValue.ToString().Trim()), CodigoUsuario, null, VentaUtilidadesCLN.ObtenerFechaHoraServidor(), CodigoTipoVenta.ToString(), decimal.Parse(_DTVentasProductos.Rows[indiceActual]["MontoTotalVenta"].ToString()), "A", null, byte.Parse(cBoxMoneda.SelectedValue.ToString()), txtBoxObservaciones.Text);
            numeroVenta = VentaUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductos");
            cargarDatosVentas(numeroVenta);
            bdSourceVentasProductos.Position = indiceActual;
        }

        private void dGVProductosSeleccionados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btnNuevaVenta.Enabled)
                    btnNuevaVenta_Click(sender, e as EventArgs);
                else
                    MessageBox.Show(this, "No Puede Iniciar una Nueva, sin haber concluido la que se lleva en curso", "Venta de Productos no Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (btnAceptar.Enabled)
                    btnAceptar_Click(sender, e as EventArgs);
                else
                    MessageBox.Show(this, "No Puede Aceptar una nueva, sin haberla inciado", "Venta de Productos no Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Control && e.KeyCode == Keys.F)
            {
                if (btnFinalizar.Enabled && btnFinalizar.Visible)
                    btnFinalizar_Click(sender, e as EventArgs);
                else
                    MessageBox.Show(this, "No Puede Aceptar una nueva, sin haberla inciado", "Venta de Productos no Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cBoxCliente_Leave(object sender, EventArgs e)
        {
            if (cBoxCliente.SelectedIndex == -1 && _DTClientes.Rows.Count != 0)// || cBoxCliente.SelectedText.Length <= 0 || cBoxCliente.SelectedValue.ToString().Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar un Cliente para la Transacción actual");
                cBoxCliente.Focus();
                return;
            }
        }

        public void ListarDetalledeCotizacionParaVenta(DataTable DTCotizacionVentaProducto, DataTable DTCotizacionVentaProductoDetalle, string TipoCotizacion, object sender, EventArgs e)
        {
            _DTVentasProductosDetalleTemporal.Rows.Clear();
            bdSourceVentasProductos.DataSource = _DTVentasProductosTemporal;
            _DTVentasProductosDetalleTemporal = fProductosBusqueda.DTProductosSeleccionados;
            bdSourceVentasProductosDetalle.DataSource = _DTVentasProductosDetalleTemporal;

            NumeroCredito = null;
            if (TipoCotizacion.Equals("T"))
                fProductosBusqueda.inhabilitarControlesParaCotizacion(true);
            else
                fProductosBusqueda.inhabilitarControlesParaCotizacion(false);

            esCotizacionVenta = true;
            if (cBoxCliente.DataSource == null)
            {
                cargarClientesComboBox();
            }
            cBoxCliente.SelectedValue = DTCotizacionVentaProducto.Rows[0]["CodigoCliente"];
            cBoxVendedor.SelectedValue = DTCotizacionVentaProducto.Rows[0]["CodigoUsuario"];
            txtBoxObservaciones.Text = DTCotizacionVentaProducto.Rows[0]["Observaciones"].ToString();

            TipoOperacion = "";
            ventaConFactura = DTCotizacionVentaProducto.Rows[0]["ConFactura"].Equals(true) ? true : false;


            //quitamos los eventos para que no generen ningun cambio en las monedas
            checkBIncluirFactura.CheckedChanged -= new EventHandler(checkBIncluirFactura_CheckedChanged);
            cBoxMoneda.SelectedIndexChanged -= new EventHandler(cBoxMoneda_SelectedIndexChanged);

            checkBIncluirFactura.Checked = DTCotizacionVentaProducto.Rows[0]["ConFactura"].Equals(true) ? true : false;
            ventaParaInsitituciones = DTCotizacionVentaProducto.Rows[0]["CodigoTipoCotizacion"].Equals("T") ? true : false;
            cBoxMoneda.SelectedValue = DTCotizacionVentaProducto.Rows[0]["CodigoMonedaCotizacionVenta"];


            //volvemos agregar los eventos
            checkBIncluirFactura.CheckedChanged += new EventHandler(checkBIncluirFactura_CheckedChanged);
            cBoxMoneda.SelectedIndexChanged += new EventHandler(cBoxMoneda_SelectedIndexChanged);


            foreach (DataRow filaCotizacion in DTCotizacionVentaProductoDetalle.Rows)
            {
                DataRow nuevaFila = _DTVentasProductosDetalleTemporal.NewRow();
                nuevaFila.BeginEdit();
                nuevaFila["Código Producto"] = filaCotizacion["CodigoProducto"];
                nuevaFila["Nombre Producto"] = filaCotizacion["NombreProducto"];
                nuevaFila["Cantidad"] = filaCotizacion["CantidadCotizacionVenta"];
                nuevaFila["Precio"] = filaCotizacion["PrecioUnitarioCotizacionVenta"];
                nuevaFila["PrecioTotal"] = Int32.Parse(filaCotizacion["CantidadCotizacionVenta"].ToString()) * Decimal.Parse(filaCotizacion["PrecioUnitarioCotizacionVenta"].ToString());
                nuevaFila["Garantia"] = filaCotizacion["TiempoGarantiaCotizacionVenta"];
                nuevaFila[6] = VentaUtilidadesCLN.esProductoEspecifico(NumeroAgencia, filaCotizacion["CodigoProducto"].ToString().Trim()) ? 1 : 0;
                nuevaFila["CantidadEntregada"] = filaCotizacion["CantidadCotizacionVenta"];
                nuevaFila["CantidadExistencia"] = VentaUtilidadesCLN.ObtenerExistenciaProductoInventario(NumeroAgencia, filaCotizacion["CodigoProducto"].ToString());
                nuevaFila["PorcentajeDescuento"] = filaCotizacion["PorcentajeDescuento"];
                nuevaFila["NumeroPrecioSeleccionado"] = filaCotizacion["NumeroPrecioSeleccionado"];
                nuevaFila["VendidoComoAgregado"] = false;
                _DTVentasProductosDetalleTemporal.Rows.Add(nuevaFila);
                nuevaFila.AcceptChanges();
                nuevaFila.SetAdded();
            }
            _DTVentasProductosDetalleTemporal.AcceptChanges();

            //if (checkBIncluirFactura.Checked)
            //{
            //    QuitarPrecioFactura(true);
            //    ventaConFactura = true;
            //}

            if (ventaConFactura && TipoCotizacion != "T")
            {
                QuitarPrecioFactura(true);
                _DTVentasProductosDetalleTemporal.AcceptChanges();
                //AumentarPrecioFactura();
            }

            formatearEstiloTabla(true);

            CodigoMonedaActual = int.Parse(cBoxMoneda.SelectedValue.ToString());
            if (CodigoMonedaActual != CodigoMonedaSistema)
            {
                DataTable DTDetalleProductosTemporal;
                DateTime FechaHoraVenta = DateTime.Parse(_DTVentasProductos.Rows[0]["FechaHoraVenta"].ToString());
                DTDetalleProductosTemporal = VentaUtilidadesCLN.CambiarMonedaCotizacionDetalleDeTransaccionTemporal(_DTVentasProductosDetalleTemporal, NumeroAgencia, CodigoMonedaActual, FechaHoraVenta, checkBIncluirFactura.Checked, true);///checkBIncluirFactura.Checked, true);
                //DTDetalleProductosTemporal = VentaUtilidadesCLN.CambiarMonedaCotizacionDetalleDeTransaccion(NumeroAgencia, CodigoMonedaActual, FechaHoraVenta, checkBIncluirFactura.Checked, 'V', NumeroVenta, true);
                BDSourceVentaProductosSeleccionados.DataSource = DTDetalleProductosTemporal;
                dGVProductosSeleccionados.DataSource = BDSourceVentaProductosSeleccionados;
                txtBoxPrecioTotal.Text = DTDetalleProductosTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + _DTMonedas.Rows.Find(CodigoMonedaActual)["MascaraMoneda"].ToString();
                txtBoxPrecioTotalCancelar.Text = DTDetalleProductosTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + _DTMonedas.Rows.Find(CodigoMonedaActual)["MascaraMoneda"].ToString();

            }
            else
            {
                if (ventaConFactura && TipoCotizacion != "T")
                    AumentarPrecioFactura();
                object detallePrecioTotal = _DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "");
                if (detallePrecioTotal.ToString().Length > 0)
                {
                    txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " " + MascaraMonedaSistema;
                    txtBoxPrecioTotalCancelar.Text = detallePrecioTotal.ToString() + " " + MascaraMonedaSistema;
                    txtBoxPrecioAgregados.Text = "0.00 " + MascaraMonedaSistema;
                }
                else
                {
                    txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
                    txtBoxPrecioTotalCancelar.Text = " 0.00 " + MascaraMonedaSistema;
                    txtBoxPrecioAgregados.Text = " 0.00 " + MascaraMonedaSistema;
                }
            }

            numeroVenta = VentaUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductos");
            if (numeroVenta == 0) numeroVenta = 1;
            if (numeroVenta > 1)
                numeroVenta++;
            if (numeroVenta == 1 && _DTVentasProductos.Rows.Count == 1)
                numeroVenta = 2;

            TipoOperacion = "N";
            lblNumeroVenta.Text = numeroVenta.ToString();
            lblEstado.Text = "Iniciada";
            //toolStripPBEstado.Value = (int)(toolStripPBEstado.Maximum) / 3;
            fProductosBusqueda.nuevaVenta = false;
            habilitarCampos(true);
            if (ventaParaInsitituciones)
            {
                checkBIncluirFactura.Enabled = false;
                cBoxMoneda.Enabled = false;
            }

            //if (ventaParaInsitituciones && MessageBox.Show(this, "La Cotización que desea vender es Considerada Institucional, ¿Desea que la opción de Créditos esté habilitada?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            if (ventaParaInsitituciones)
            {
                rBtnCredito.Enabled = false;
            }

            habilitarBotonesVentas(false, false, true, true, false, true, false, true, true, false, false);


            dtGVVentaProductosEspecificos.ClearGroups();
            dtGVVentaProductosEspecificos.Rows.Clear();

            dtGVVentaProductosEspecificosAgregados.ClearGroups();
            dtGVVentaProductosEspecificosAgregados.Rows.Clear();

            _DTProductosEspecificos.Clear();
            _DTProductosEspecificosAgregados.Clear();


            foreach (DataRow fila in _DTVentasProductosDetalleTemporal.Rows)
            {
                if (int.Parse(fila["CantidadEntregada"].ToString()) > int.Parse(fila["CantidadExistencia"].ToString()))
                {
                    fProductosBusqueda.ExistenProductosInalcanzables = true;
                    MessageBox.Show(this, "Debe tomar en Cuenta que existen productos cuya existencia no es suficiente para Abastecer completamente la Venta Iniciada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
            }
            //fProductosBusqueda.ExistenProductosInalcanzables = true;

            revisarProductosInalcanzables();
            rBtnEfectivo.Checked = true;
            EsCodigoTipoCreditoLibreDispocion = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FBuscarTransaccion formBuscarTransaccion = new FBuscarTransaccion(NumeroAgencia);
            formBuscarTransaccion.formatearEstiloParaVentas();
            formBuscarTransaccion.ShowDialog(this);
            numeroVenta = formBuscarTransaccion.NumeroTransaccion;
            cargarDatosVentas(numeroVenta);
            //DataRow Fila = DSDevoluciones.Tables["VentasProductos"].Rows.Find(new object[] { NumeroAgencia, numVenta });
            //if (Fila != null)
            //{
            //    int fila = BDSourceVentaProductos.Find("NumeroCompraProducto", numVenta);
            //    if (fila != -1)
            //        BDSourceVentaProductos.Position = fila;
            //}
            formBuscarTransaccion.Dispose();
        }

        private void tabPage2_Leave(object sender, EventArgs e)
        {
            if (CantidadProductosAgregados > 0)
            {
                dtGVProductosAgregados.EndEdit();
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            if (dtGVProductosAgregados.RowCount > 0)
            {
                dtGVProductosAgregados.CurrentCell = dtGVProductosAgregados[3, 0];
                dtGVProductosAgregados.BeginEdit(true);
            }
        }

        private void dtGVProductosAgregados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 2 && e.RowIndex > 0)
            {
                dtGVProductosAgregados.BeginEdit(true);
                if (e.ColumnIndex == 6)
                {
                    dtGVProductosAgregados.CurrentCell.Selected = true;
                }
            } //aumentar aqui, para los agregados
        }

        public void generarDetalleVentaProductosEspecificosAgregados()
        {
            _DTProductosEspecificosAgregadosTemporal.Clear();
            //MessageBox.Show("Generando Especificos Agregados");
            if (CantidadProductosAgregados > 0)
            {
                //dtGVProductosAgregados.RowsAdded -= dtGVProductosAgregados_RowsAdded;

                usuarioSeleccionaEspecificoAgregados = MessageBox.Show(this, "Existen Productos Agregados, Desea escoger que productos agregará a la Venta mediante su Código Específico (Si) o que el Sistema los Seleccione por Usted (No)", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
                if (usuarioSeleccionaEspecificoAgregados)
                {
                    FIngresarCodigoProductoEspecifico fingresarCodigosProductosespecficos = new FIngresarCodigoProductoEspecifico(NumeroAgencia);
                    fingresarCodigosProductosespecficos.DTDatosTransaccion = _DTVentasProductosDetalleTemporal;
                    fingresarCodigosProductosespecficos.formatearEstiloProductosEspecificosAgregados();
                    fingresarCodigosProductosespecficos.ShowDialog(this);
                    _DTProductosEspecificosAgregadosSeleccionadosPorUsuarioTemporal = fingresarCodigosProductosespecficos.DTProductosEspecificosAgregdosTemporal.Copy();
                    if (!fingresarCodigosProductosespecficos.ProductosAceptados)
                    {
                        usuarioSeleccionaEspecificoAgregados = false;
                    }
                }

                dtGVProductosAgregados.Visible = true;
                dtGVProductosAgregados.Height = AlturaDGVProductosAgregados;
                dtGVProductosAgregados.Dock = DockStyle.Bottom;

                dtGVVentaProductosEspecificosAgregados.Visible = false;
                dtGVVentaProductosEspecificosAgregados.Height = 0;
                dtGVVentaProductosEspecificosAgregados.Dock = DockStyle.None;

                bdSourceVentaProductosAgregados.DataSource = _DTProductosEspecificosAgregadosTemporal;

                BDSourceVentaProductosSeleccionados.MoveFirst();
                existeProductosEspecificos = Int16.Parse(_DTVentasProductosDetalleTemporal.Compute("count(EsProductoEspecifico)", "EsProductoEspecifico = true").ToString());
                int indiceActual = 0;
                Font fuenteDefecto = dtGVProductosAgregados.DefaultCellStyle.Font;
                _DTProductosEspecificosAgregadosTemporal.Clear();
                listaCodigosProductosEspecificosAgregadosTemporal.Clear();
                decimal PrecioTotalXAgregado = 0;
                foreach (DataGridViewRow fila in DGViewProductosSeleccionados.Rows)
                {
                    PrecioTotalXAgregado = 0;
                    if (fila.Cells["VendidoComoAgregado"].Value.Equals(true))
                    {
                        string CodigoProducto;
                        string CodigoProductoEspecifico;
                        string NombreProducto;
                        int cantidad = 0; //Cantidad
                        decimal Precio = 0; //Precio
                        int TiempoGarantiaPE = 0; //TiempoGarantiaPE

                        string[] listadoCodigosProductosEspecificosInventariados = null;
                        CodigoProducto = fila.Cells["Código Producto"].Value.ToString();
                        Precio = decimal.Parse(fila.Cells["Precio"].Value.ToString());
                        NombreProducto = fila.Cells["Nombre Producto"].Value.ToString();
                        cantidad = Int16.Parse(fila.Cells["Cantidad"].Value.ToString());
                        TiempoGarantiaPE = Int16.Parse(fila.Cells["Garantia"].Value.ToString());
                        //dtGVProductosAgregados.Rows.Add(new object[] { CodigoProducto, CodigoProducto, "", "O", TiempoGarantiaPE, DateTime.Now, Precio });


                        if (fila.Cells["EsProductoEspecifico"].Value.Equals(true))
                        {
                            //_DTProductosEspecificosSeleccionados = VentaUtilidadesCLN.ListarProductosEspecificosDeVenta(NumeroAgencia, fila.Cells["Código Producto"].Value.ToString());
                            if (!usuarioSeleccionaEspecificoAgregados)
                                listadoCodigosProductosEspecificosInventariados = InventarioProductoEspecificoCLN.ListarCodigosProductosEspecificosExistentes(NumeroAgencia, CodigoProducto, cantidad).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < cantidad; i++)
                            {
                                if (!usuarioSeleccionaEspecificoAgregados && listadoCodigosProductosEspecificosInventariados.Length < cantidad)
                                {
                                    MessageBox.Show("Aun no ha inventariado el Código de Producto especifico para este producto");
                                    break;
                                }
                                DataRow nuevoAgregado = _DTProductosEspecificosAgregadosTemporal.NewRow();

                                if (usuarioSeleccionaEspecificoAgregados)
                                {

                                    CodigoProductoEspecifico = _DTProductosEspecificosAgregadosSeleccionadosPorUsuarioTemporal.Rows[indiceActual]["CodigoProductoEspecifico"].ToString().Trim();
                                    Precio = decimal.Parse(_DTProductosEspecificosAgregadosSeleccionadosPorUsuarioTemporal.Rows[indiceActual]["PrecioUnitario"].ToString());
                                    TiempoGarantiaPE = Int16.Parse(_DTProductosEspecificosAgregadosSeleccionadosPorUsuarioTemporal.Rows[indiceActual]["TiempoGarantiaPE"].ToString());

                                    nuevoAgregado["CodigoProductoEspecifico"] = CodigoProductoEspecifico;
                                    nuevoAgregado["CodigoTipoAgregado"] = _DTProductosEspecificosAgregadosSeleccionadosPorUsuarioTemporal.Rows[indiceActual]["CodigoTipoAgregado"].ToString().Trim();
                                    nuevoAgregado["TiempoGarantiaPE"] = TiempoGarantiaPE;
                                    nuevoAgregado["FechaHoraVencimientoPE"] = _DTProductosEspecificosAgregadosSeleccionadosPorUsuarioTemporal.Rows[indiceActual]["FechaHoraVencimientoPE"].ToString().Trim();
                                    nuevoAgregado["PrecioUnitario"] = Precio;


                                }
                                else
                                {
                                    CodigoProductoEspecifico = listadoCodigosProductosEspecificosInventariados[i].Trim();

                                    nuevoAgregado["CodigoProductoEspecifico"] = CodigoProductoEspecifico;
                                    nuevoAgregado["CodigoTipoAgregado"] = "O";
                                    nuevoAgregado["TiempoGarantiaPE"] = 0;
                                    nuevoAgregado["FechaHoraVencimientoPE"] = DateTime.Now.AddMonths(2);
                                    nuevoAgregado["PrecioUnitario"] = Precio;

                                }
                                listaCodigosProductosEspecificosAgregadosTemporal.Add(CodigoProducto.Trim() + "," + indiceActual.ToString() + "," + CodigoProductoEspecifico);
                                if (i == 0)
                                {
                                    nuevoAgregado["NombreProducto"] = NombreProducto;
                                    nuevoAgregado["CodigoProducto"] = CodigoProducto;
                                }
                                else
                                {
                                    nuevoAgregado["NombreProducto"] = "";
                                    nuevoAgregado["CodigoProducto"] = "";
                                }
                                nuevoAgregado["EspecificoDespachado"] = true;
                                _DTProductosEspecificosAgregadosTemporal.Rows.Add(nuevoAgregado);
                                nuevoAgregado.AcceptChanges();
                                indiceActual++;
                                PrecioTotalXAgregado += Precio;
                            }
                            DTVentasProductosDetalleTemporal.Rows[fila.Index][3] = PrecioTotalXAgregado;

                        }

                    }

                }
                DetalleCodigosEspecificosAgregadosGenerados = true;
                txtBoxPrecioAgregados.Text = _DTProductosEspecificosAgregadosTemporal.Compute("sum(PrecioUnitario)", "").ToString() + " " + MascaraMonedaSistema;
                txtBoxPrecioTotal.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false").ToString() + " " + MascaraMonedaSistema;
                txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;

            }
            existenModificacionesAgregados = false;

        }

        public void mostrarGrillasNuevaVenta(bool visibilidadParaVenta)
        {
            if (visibilidadParaVenta)
            {
                //Grillas de los Productos especificos
                DGViewProductosSeleccionados.Visible = true;
                DGViewProductosSeleccionados.Dock = DockStyle.Fill;
                DGViewProductosSeleccionados.Height = AlturaDGVProductosEspecificos;

                dtGVVentaProductosEspecificos.Visible = false;
                dtGVVentaProductosEspecificos.Dock = DockStyle.None;
                dtGVVentaProductosEspecificos.Height = 0;



                //Grillas de los Productos Agregados
                dtGVProductosAgregados.Visible = true;
                dtGVProductosAgregados.Height = AlturaDGVProductosAgregados;
                dtGVProductosAgregados.Dock = DockStyle.Bottom;

                dtGVVentaProductosEspecificosAgregados.Visible = false;
                dtGVVentaProductosEspecificosAgregados.Height = 0;
                dtGVVentaProductosEspecificosAgregados.Dock = DockStyle.None;
            }
            else
            {
                //Grillas de los Productos especificos
                DGViewProductosSeleccionados.Visible = false;
                DGViewProductosSeleccionados.Dock = DockStyle.None;
                DGViewProductosSeleccionados.Height = 0;

                dtGVVentaProductosEspecificos.Visible = true;
                dtGVVentaProductosEspecificos.Dock = DockStyle.Bottom;
                dtGVVentaProductosEspecificos.Height = AlturaDGVProductosEspecificos;



                //Grillas de los Productos Agregados
                dtGVProductosAgregados.Visible = false;
                dtGVProductosAgregados.Height = 0;
                dtGVProductosAgregados.Dock = DockStyle.None;

                dtGVVentaProductosEspecificosAgregados.Visible = true;
                dtGVVentaProductosEspecificosAgregados.Height = AlturaDGVProductosAgregados;
                dtGVVentaProductosEspecificosAgregados.Dock = DockStyle.Bottom;
            }

        }

        public void generarDetalleVentaProductosEspecificos()
        {
            //MessageBox.Show("Generando Especificos");            
            _DTProductosEspecificosTemporal.Clear();
            if (usuarioSeleccionaEspecifico)
            {
                FIngresarCodigoProductoEspecifico fingresarCodigosProductosespecficos = new FIngresarCodigoProductoEspecifico(NumeroAgencia);
                fingresarCodigosProductosespecficos.DTDatosTransaccion = _DTVentasProductosDetalleTemporal;
                fingresarCodigosProductosespecficos.formatearEstiloProductosEspecificos();
                fingresarCodigosProductosespecficos.ShowDialog(this);
                _DTProductosEspecificosSeleccionadosPorUsuarioTemporal = fingresarCodigosProductosespecficos.DTProductosEspecificosTemporal.Copy();
                if (!fingresarCodigosProductosespecficos.ProductosAceptados)
                {
                    usuarioSeleccionaEspecifico = false;
                }
            }
            if (CantidadProductosEspecificos > 0)
            {
                //dGVProductosEspecificos.RowsAdded += new DataGridViewRowsAddedEventHandler(dGVProductosEspecificos_RowsAdded);
                //dGVProductosEspecificos.RowsAdded += dGVProductosEspecificos_RowsAdded;

                DGViewProductosSeleccionados.Visible = true;
                DGViewProductosSeleccionados.Dock = DockStyle.Fill;
                DGViewProductosSeleccionados.Height = AlturaDGVProductosEspecificos;

                dtGVVentaProductosEspecificos.Visible = false;
                dtGVVentaProductosEspecificos.Dock = DockStyle.None;
                dtGVVentaProductosEspecificos.Height = 0;

                bdSourceVentaProductosEspecificos.DataSource = _DTProductosEspecificosTemporal;

                listaCodigosProductosEspecificosTemporal.Clear();
                int indiceActual = 0;
                //this.DGViewProductosSeleccionados.Sort(this.DGViewProductosSeleccionados.Columns[0], ListSortDirection.Ascending);
                foreach (DataGridViewRow fila in DGViewProductosSeleccionados.Rows)
                {
                    if (fila.Cells["EsProductoEspecifico"].Value.Equals(true) && fila.Cells["VendidoComoAgregado"].Value.Equals(false))
                    {
                        string CodigoProducto;
                        string CodigoProductoEspecifico;
                        string NombreProducto;
                        int cantidad = 0; //Cantidad                    
                        int TiempoGarantiaPE = 0; //TiempoGarantiaPE
                        string[] listadoCodigosProductosEspecificosInventariados = null;

                        CodigoProducto = fila.Cells["Código Producto"].Value.ToString();
                        NombreProducto = fila.Cells["Nombre Producto"].Value.ToString();
                        TiempoGarantiaPE = Int16.Parse(fila.Cells["Garantia"].Value.ToString());
                        cantidad = Int16.Parse(fila.Cells["Cantidad"].Value.ToString());

                        if (!usuarioSeleccionaEspecifico)
                            listadoCodigosProductosEspecificosInventariados = InventarioProductoEspecificoCLN.ListarCodigosProductosEspecificosExistentes(NumeroAgencia, CodigoProducto, cantidad).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < cantidad; i++)
                        {

                            //CodigoProductoEspecifico = _DTProductosEspecificosSeleccionados.Rows[indice]["CodigoProductoEspecifico"].ToString();
                            if (!usuarioSeleccionaEspecifico && i == listadoCodigosProductosEspecificosInventariados.Length)
                            {
                                if (MessageBox.Show(this, "No existe la cantidad de productos Especificos registrados en Inventario, Se Procedera a Realizar la venta con los existentes Actualmente" + Environment.NewLine + "Si desea vender la cantidad existente, proceda a Cancelar la Venta y registrar los Códigos de los Productos Especificos" + Environment.NewLine + "¿Desea Continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //_DTVentasProductosDetalleTemporal.Rows[fila.Index][2] = indice;                                    
                                    break;
                                }
                                else
                                {
                                    btnCancelar_Click(btnCancelar, new EventArgs());
                                    return;
                                }
                            }

                            DataRow nuevoProductoEspecifico = _DTProductosEspecificosTemporal.NewRow();
                            if (usuarioSeleccionaEspecifico)
                            {
                                CodigoProductoEspecifico = _DTProductosEspecificosSeleccionadosPorUsuarioTemporal.Rows[indiceActual]["CodigoProductoEspecifico"].ToString().Trim();
                                TiempoGarantiaPE = Int32.Parse(_DTProductosEspecificosSeleccionadosPorUsuarioTemporal.Rows[indiceActual]["TiempoGarantiaPE"].ToString().Trim());
                            }
                            else
                            {
                                CodigoProductoEspecifico = listadoCodigosProductosEspecificosInventariados[i].Trim();
                            }

                            listaCodigosProductosEspecificosTemporal.Add(CodigoProducto.Trim() + "," + indiceActual.ToString() + "," + CodigoProductoEspecifico);
                            if (i == 0)
                            {
                                nuevoProductoEspecifico["NombreProducto"] = NombreProducto;
                                nuevoProductoEspecifico["CodigoProducto"] = CodigoProducto;
                            }
                            else
                            {
                                nuevoProductoEspecifico["NombreProducto"] = "";
                                nuevoProductoEspecifico["CodigoProducto"] = "";
                            }
                            nuevoProductoEspecifico["CodigoProductoEspecifico"] = CodigoProductoEspecifico;
                            nuevoProductoEspecifico["TiempoGarantiaPE"] = TiempoGarantiaPE;
                            nuevoProductoEspecifico["EspecificoDespachado"] = true;
                            _DTProductosEspecificosTemporal.Rows.Add(nuevoProductoEspecifico);
                            nuevoProductoEspecifico.AcceptChanges();
                            indiceActual++;
                        }
                    }
                }
                //this.DGViewProductosSeleccionados.Sort(this.DGViewProductosSeleccionados.Columns[7], ListSortDirection.Ascending);
                DetalleCodigosEspecificosGenerados = true;
                existenModificacionesEspecificos = false;
                //dGVProductosEspecificos.RowsAdded -=dGVProductosEspecificos_RowsAdded;
            }
        }

        public void crearColumnasDTProductosEspecificos()
        {

            DataColumn DCNombreProducto = new DataColumn();
            DCNombreProducto.DataType = Type.GetType("System.String");
            DCNombreProducto.ColumnName = "NombreProducto";
            DCNombreProducto.ReadOnly = false;
            DCNombreProducto.DefaultValue = " ";

            DataColumn DCCodigoProducto = new DataColumn();
            DCCodigoProducto.DataType = Type.GetType("System.String");
            DCCodigoProducto.ColumnName = "CodigoProducto";
            DCCodigoProducto.ReadOnly = false;
            DCCodigoProducto.DefaultValue = " ";

            DataColumn DCCodigoProductoEspecifico = new DataColumn();
            DCCodigoProductoEspecifico.DataType = Type.GetType("System.String");
            DCCodigoProductoEspecifico.AllowDBNull = false;
            DCCodigoProductoEspecifico.Unique = true;
            DCCodigoProductoEspecifico.DefaultValue = "______-1";
            DCCodigoProductoEspecifico.ColumnName = "CodigoProductoEspecifico";

            DataColumn DCTiempoGarantia = new DataColumn();
            DCTiempoGarantia.DataType = Type.GetType("System.Int16");
            DCTiempoGarantia.DefaultValue = 0;
            DCTiempoGarantia.ColumnName = "TiempoGarantiaPE";

            DataColumn DCDespachado = new DataColumn();
            DCDespachado.DataType = Type.GetType("System.Boolean");
            DCDespachado.DefaultValue = false;
            DCDespachado.ColumnName = "EspecificoDespachado";


            _DTProductosEspecificosTemporal = new DataTable();

            _DTProductosEspecificosTemporal.Columns.Add(DCNombreProducto);
            _DTProductosEspecificosTemporal.Columns.Add(DCCodigoProducto);
            _DTProductosEspecificosTemporal.Columns.Add(DCCodigoProductoEspecifico);
            _DTProductosEspecificosTemporal.Columns.Add(DCTiempoGarantia);
            _DTProductosEspecificosTemporal.Columns.Add(DCDespachado);

            _DTProductosEspecificosTemporal.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = _DTProductosEspecificosTemporal.Columns["CodigoProductoEspecifico"];
            _DTProductosEspecificosTemporal.PrimaryKey = PrimaryKeyColumns;

            DGCCodigoProductoEspecificoPE.DefaultCellStyle.NullValue = "00000000000000";

        }

        public void crearColumnasDTProductosEspecificosAgregados()
        {

            DataColumn DCNombreProducto = new DataColumn();
            DCNombreProducto.DataType = Type.GetType("System.String");
            DCNombreProducto.ColumnName = "NombreProducto";
            DCNombreProducto.ReadOnly = true;
            DCNombreProducto.DefaultValue = " ";

            DataColumn DCCodigoProducto = new DataColumn();
            DCCodigoProducto.DataType = Type.GetType("System.String");
            DCCodigoProducto.ColumnName = "CodigoProducto";
            DCCodigoProducto.ReadOnly = true;
            DCCodigoProducto.DefaultValue = " ";

            DataColumn DCCodigoProductoEspecifico = new DataColumn();
            DCCodigoProductoEspecifico.DataType = Type.GetType("System.String");
            DCCodigoProductoEspecifico.AllowDBNull = false;
            DCCodigoProductoEspecifico.Unique = true;
            DCCodigoProductoEspecifico.DefaultValue = "______-1";
            DCCodigoProductoEspecifico.ColumnName = "CodigoProductoEspecifico";

            DataColumn DCCodigoTipoAgregado = new DataColumn();
            DCCodigoTipoAgregado.DataType = Type.GetType("System.String");
            DCCodigoTipoAgregado.ColumnName = "CodigoTipoAgregado";
            DCCodigoTipoAgregado.DefaultValue = "O";

            DataColumn DCTiempoGarantia = new DataColumn();
            DCTiempoGarantia.DataType = Type.GetType("System.Int16");
            DCTiempoGarantia.DefaultValue = 0;
            DCTiempoGarantia.ColumnName = "TiempoGarantiaPE";

            DataColumn DCFechaValidez = new DataColumn();
            DCFechaValidez.DataType = Type.GetType("System.DateTime");
            DCFechaValidez.ColumnName = "FechaHoraVencimientoPE";
            DCFechaValidez.DefaultValue = DateTime.Now;


            DataColumn DCPrecioUnitario = new DataColumn();
            DCPrecioUnitario.DataType = Type.GetType("System.Decimal");
            DCPrecioUnitario.ColumnName = "PrecioUnitario";
            DCPrecioUnitario.DefaultValue = 0.00;

            DataColumn DCDespachado = new DataColumn();
            DCDespachado.DataType = Type.GetType("System.Boolean");
            DCDespachado.DefaultValue = false;
            DCDespachado.ColumnName = "EspecificoDespachado";

            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCNombreProducto);
            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCCodigoProducto);
            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCCodigoProductoEspecifico);
            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCCodigoTipoAgregado);
            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCTiempoGarantia);
            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCFechaValidez);
            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCPrecioUnitario);
            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCDespachado);


            _DTProductosEspecificosAgregadosTemporal.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = _DTProductosEspecificosAgregadosTemporal.Columns["CodigoProductoEspecifico"];
            _DTProductosEspecificosAgregadosTemporal.PrimaryKey = PrimaryKeyColumns;

            DGCCodigoProductoEspecifico.DefaultCellStyle.NullValue = "00000000000000";

        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            //object detallePrecioTotal = _DTVentasProductosDetalle.Compute("sum(PrecioTotal)", "");
            //DataTable DTVentaProductosEspecificosAgregadosReporte = VentaproductosAgregados.ListarVentasProductosEspecificosAgregadosReportes(NumeroAgencia, Int32.Parse(lblNumeroCompra.Text));
            //DataTable DTVentaProductosDetalleReporte = VentaProductosDetalleCLN.ListarVentaProductoDetalleReporte(NumeroAgencia, Int32.Parse(lblNumeroCompra.Text));

            //FReportesGestionComercialVentasProductos ReporteVentaproductosForm = new FReportesGestionComercialVentasProductos(DTVentaProductosDetalleReporte, VentaProductosCLN.ListarTuplaDatosVentaProductoReporte(NumeroAgencia, Int32.Parse(lblNumeroCompra.Text)) + ", " + detallePrecioTotal.ToString(), DTVentaProductosEspecificosAgregadosReporte);
            //ReporteVentaproductosForm.Show();

            //DataTable DTVentasProductos = VentaProductosCLN.ListarVentaProductoReporte(NumeroAgencia, numeroVenta);
            //DataTable DTVentasProductosDetalle = VentaProductosDetalleCLN.ListarVentaProductoDetalleReporte(NumeroAgencia, numeroVenta);
            //DataTable DTVentasProductosAgregados = VentaproductosAgregados.ListarVentasProductosEspecificosAgregadosReportes(NumeroAgencia, numeroVenta);
            //FReporteVentasProductosGeneral formReporteVentasProductos = new FReporteVentasProductosGeneral(DTVentasProductos, DTVentasProductosDetalle, DTVentasProductosAgregados);
            //formReporteVentasProductos.ShowDialog(this);

        }

        private void dGVProductosEspecificos_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = ""; //Nombre Producto
            e.Row.Cells[1].Value = ""; //CodigoProducto
            e.Row.Cells[2].Value = ""; //CodigoProductoEspecifico
            e.Row.Cells[3].Value = 0; //TiempoGarantiaPE            
        }

        private void dtGVProductosAgregados_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = "";//CodigoProducto
            e.Row.Cells[1].Value = "";//CodigoProducto
            e.Row.Cells[2].Value = "";//CodigoProductoEspecifico            
            e.Row.Cells[3].Value = "O";//CodigoTipoAgregado
            e.Row.Cells[4].Value = 0; //TiempoGarantiaPE
            e.Row.Cells[5].Value = DateTime.Now; //DGCFechaHoraVencimientoPE            
            e.Row.Cells[6].Value = 0.00; //PrecioUnitario            
        }

        private void dGVProductosEspecificos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (_DTProductosEspecificosTemporal.Rows.Count > 0)
            {
                if (dGVProductosEspecificos.Rows[e.RowIndex].Cells[0].Value != null && !dGVProductosEspecificos.Rows[e.RowIndex].Cells[0].Value.Equals(""))
                {
                    dGVProductosEspecificos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                    dGVProductosEspecificos.Rows[e.RowIndex].Cells[0].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
                    dGVProductosEspecificos.Rows[e.RowIndex].Cells[1].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
                }
            }
        }

        private void dtGVProductosAgregados_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (_DTProductosEspecificosAgregadosTemporal.Rows.Count > 0)
            {
                if (dtGVProductosAgregados.Rows[e.RowIndex].Cells[0].Value != null && !dtGVProductosAgregados.Rows[e.RowIndex].Cells[0].Value.Equals(""))
                {
                    dtGVProductosAgregados.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                    dtGVProductosAgregados.Rows[e.RowIndex].Cells[0].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
                    dtGVProductosAgregados.Rows[e.RowIndex].Cells[1].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
                }
            }
        }





        private void dGVProductosEspecificos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2) // si han terminado de editar la columna del codigo Especifico
            {
                string CodigoProducto = "00A";
                if (dGVProductosEspecificos.RowCount > 0 && dGVProductosEspecificos.CurrentRow.Cells[0] != null)
                {
                    if (dGVProductosEspecificos.CurrentRow.Cells[0].Value.Equals(""))
                    {
                        int contador = dGVProductosEspecificos.CurrentRow.Index;
                        while (dGVProductosEspecificos.Rows[contador].Cells[0].Value.Equals(""))
                        {
                            contador--;
                            if (contador == -1)
                            {
                                contador = 0;
                                break;
                            }
                        }
                        CodigoProducto = dGVProductosEspecificos.Rows[contador].Cells[1].Value.ToString().Trim();
                    }
                    else
                    {
                        CodigoProducto = dGVProductosEspecificos.CurrentRow.Cells[1].Value.ToString().Trim();
                    }
                    string codigoEspecificoActual = dGVProductosEspecificos.CurrentRow.Cells[2].Value.ToString().Trim();
                    if (!codigoEspecificoActual.Contains(CodigoProducto))
                    {
                        int tamanioCodigoActual = codigoEspecificoActual.Length;
                        int tamanioCodigoProducto = CodigoProducto.Trim().Length;
                        int tamanioComodin = "-".Trim().Length;
                        if ((tamanioCodigoActual + tamanioCodigoProducto + tamanioComodin) > 20)
                        {
                            dGVProductosEspecificos.CurrentRow.Cells[2].Value = CodigoProducto.Trim() + "-" + codigoEspecificoActual.Substring(0, codigoEspecificoActual.Length - ((tamanioComodin + tamanioCodigoProducto + tamanioCodigoActual) - 20));
                        }
                        else
                        {
                            dGVProductosEspecificos.CurrentRow.Cells[2].Value = CodigoProducto.Trim() + "-" + codigoEspecificoActual;
                        }
                    }
                }

            }
        }

        private void dtGVProductosAgregados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2) // si han terminado de editar la columna del codigo Especifico
            {
                string CodigoProducto = "00A";

                if (dtGVProductosAgregados.CurrentRow.Cells[0].Value.Equals(""))
                {
                    int contador = dtGVProductosAgregados.CurrentRow.Index;
                    while (dtGVProductosAgregados.Rows[contador].Cells[0].Value.Equals(""))
                    {
                        contador--;
                        if (contador == -1)
                        {
                            contador = 0;
                            break;
                        }
                    }
                    CodigoProducto = dtGVProductosAgregados.Rows[contador].Cells[1].Value.ToString().Trim();
                }
                else
                {
                    CodigoProducto = dtGVProductosAgregados.CurrentRow.Cells[1].Value.ToString().Trim();
                }
                string codigoEspecificoActual = dtGVProductosAgregados.CurrentRow.Cells[2].Value.ToString().Trim();
                if (!codigoEspecificoActual.Contains(CodigoProducto))
                {
                    int tamanioCodigoActual = codigoEspecificoActual.Length;
                    int tamanioCodigoProducto = CodigoProducto.Trim().Length;
                    int tamanioComodin = "-".Trim().Length;
                    if ((tamanioCodigoActual + tamanioCodigoProducto + tamanioComodin) > 20)
                    {
                        dtGVProductosAgregados.CurrentRow.Cells[2].Value = CodigoProducto.Trim() + "-" + codigoEspecificoActual.Substring(0, codigoEspecificoActual.Length - ((tamanioComodin + tamanioCodigoProducto + tamanioCodigoActual) - 20));
                    }
                    else
                    {
                        dtGVProductosAgregados.CurrentRow.Cells[2].Value = CodigoProducto.Trim() + "-" + codigoEspecificoActual;
                    }
                }
            }
        }

        private void dGVProductosEspecificos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DetalleCodigosEspecificosGenerados) //agregar variable de condición finalizacion de introduccion de codigos especificos
            {
                if (dGVProductosEspecificos[e.ColumnIndex, e.RowIndex].Value != null && dGVProductosEspecificos.CurrentRow != null && dGVProductosEspecificos.CurrentCell != null && dGVProductosEspecificos.Rows.Count > 0 && _DTProductosEspecificosTemporal.Rows.Count > 0)
                {
                    switch (e.ColumnIndex)
                    {
                        case 2:// Código Producto Específico
                            {
                                string CodigoEspecificoProductoActual = dGVProductosEspecificos.Rows[dGVProductosEspecificos.CurrentRow.Index].Cells["DGCCodigoProductoEspecificoPE"].Value.ToString();
                                DataRow Fila = _DTProductosEspecificosTemporal.Rows.Find(CodigoEspecificoProductoActual);
                                if (Fila != null) //si el codigo especifico existe no se debe hacer ningun cambio y mostramos error
                                {
                                    //
                                    dGVProductosEspecificos.Rows[dGVProductosEspecificos.CurrentRow.Index].Cells["DGCCodigoProductoEspecificoPE"].Value = _DTProductosEspecificosTemporal.Rows[e.RowIndex][2];
                                    //MessageBox.Show(this, "No puede Ingresar Códigos Específicos Repetidos, Revise su Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    _DTProductosEspecificosTemporal.Rows[e.RowIndex][2] = dGVProductosEspecificos.Rows[dGVProductosEspecificos.CurrentRow.Index].Cells["DGCCodigoProductoEspecificoPE"].Value;
                                }
                                break;
                            }
                        case 3: // Tiempo de garantia
                            {
                                _DTProductosEspecificosTemporal.Rows[e.RowIndex][3] = dGVProductosEspecificos.Rows[dGVProductosEspecificos.CurrentRow.Index].Cells["DGCTiempoGarantiaPE2"].Value;
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }

        private void dtGVProductosAgregados_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DetalleCodigosEspecificosAgregadosGenerados) //CodigosAgregadosGenerados
            {
                if (e.RowIndex >= 0 && dtGVProductosAgregados[e.ColumnIndex, e.RowIndex].Value != null && dtGVProductosAgregados.CurrentRow != null && dtGVProductosAgregados.CurrentCell != null && dtGVProductosAgregados.Rows.Count > 0 && _DTProductosEspecificosAgregadosTemporal.Rows.Count > 0)
                {
                    switch (e.ColumnIndex)
                    {
                        case 2:// Código Producto Específico
                            {
                                string CodigoEspecificoProductoActual = dtGVProductosAgregados.Rows[dtGVProductosAgregados.CurrentRow.Index].Cells["DGCCodigoProductoEspecifico"].Value.ToString();
                                DataRow Fila = _DTProductosEspecificosAgregadosTemporal.Rows.Find(CodigoEspecificoProductoActual);
                                if (Fila != null) //si el codigo especifico existe no se debe hacer ningun cambio y mostramos error
                                {
                                    //
                                    dtGVProductosAgregados.Rows[dtGVProductosAgregados.CurrentRow.Index].Cells["DGCCodigoProductoEspecifico"].Value = _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][2];
                                    //MessageBox.Show(this, "No puede Ingresar Códigos Específicos Repetidos, Revise su Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][2] = dtGVProductosAgregados.Rows[dtGVProductosAgregados.CurrentRow.Index].Cells["DGCCodigoProductoEspecifico"].Value;
                                }
                                break;
                            }
                        case 3: // Codigo Tipo Agregado
                            {
                                _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][3] = dtGVProductosAgregados.Rows[dtGVProductosAgregados.CurrentRow.Index].Cells["DGCCodigoTipoAgregado"].Value;
                                break;
                            }
                        case 4: // Tiempo de garantia
                            {
                                _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][4] = dtGVProductosAgregados.Rows[dtGVProductosAgregados.CurrentRow.Index].Cells["DGCTiempoGarantiaPE"].Value;
                                break;
                            }
                        case 5: // Fecha de Expiración
                            {
                                _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][5] = dtGVProductosAgregados.Rows[dtGVProductosAgregados.CurrentRow.Index].Cells["DGCFechaHoraVencimientoPE"].Value;
                                break;
                            }
                        case 6: // Precio Unitario
                            {
                                _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][6] = dtGVProductosAgregados.Rows[dtGVProductosAgregados.CurrentRow.Index].Cells["DGCPrecioUnitario"].Value;
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }

        private void dGVProductosEspecificos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dGVProductosEspecificos.BeginEdit(true);
        }

        private void dGVProductosEspecificos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dGVProductosEspecificos.Columns[e.ColumnIndex].Name == "DGCCodigoProductoEspecificoPE")
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dGVProductosEspecificos.Rows[e.RowIndex].Cells[2].ErrorText = "El Código de Producto Especifico no Puede ser Vacio";
                    e.Cancel = true;
                    return;
                }
                string CodigoEspecificoNuevo = dGVProductosEspecificos.CurrentCell.Value.ToString();
                string CodigoEspecificoAnterior = e.FormattedValue.ToString();
                DataRow Fila = _DTProductosEspecificosTemporal.Rows.Find(CodigoEspecificoAnterior);
                if (Fila != null && CodigoEspecificoAnterior != CodigoEspecificoNuevo) //si el codigo especifico existe no se debe hacer ningun cambio y mostramos error
                {
                    dGVProductosEspecificos.Rows[e.RowIndex].Cells[2].ErrorText = "El Código de Producto Especifico no Puede ser Repetido";
                    e.Cancel = true;
                }
            }
        }

        private void dtGVProductosAgregados_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtGVProductosAgregados.Columns[e.ColumnIndex].Name == "DGCCodigoProductoEspecifico")
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dtGVProductosAgregados.Rows[e.RowIndex].Cells[2].ErrorText = "El Código de Producto Especifico no Puede ser Vacio";
                    e.Cancel = true;
                    return;
                }
                string CodigoEspecificoNuevo = dtGVProductosAgregados.CurrentCell.Value.ToString();
                string CodigoEspecificoAnterior = e.FormattedValue.ToString();
                DataRow Fila = _DTProductosEspecificosAgregadosTemporal.Rows.Find(CodigoEspecificoAnterior);
                if (Fila != null && CodigoEspecificoAnterior != CodigoEspecificoNuevo) //si el codigo especifico existe no se debe hacer ningun cambio y mostramos error
                {
                    dtGVProductosAgregados.Rows[e.RowIndex].Cells[2].ErrorText = "El Código de Producto Especifico no Puede ser Repetido";
                    e.Cancel = true;
                }
            }
        }

        private void txtBoxCodEspecifico_TextChanged(object sender, EventArgs e)
        {
            //if (txtBoxCodEspecifico.Text.Trim().Length == 30)
            //{
            //    bindingNavigatorAddNewItem_Click(sender, e);
            //}
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            //string CodigoProductoEspecifico = txtBoxCodEspecifico.Text.Trim();
            //string CodigoProducto = "";
            //DataRow filaEncontrada = _DTProductosEspecificosTemporal.Rows.Find(CodigoProductoEspecifico);
            //if (filaEncontrada != null) // si el codigo Especifico ingresado ya esta en la grilla
            //{
            //    int indiceFila = _DTProductosEspecificosTemporal.Rows.IndexOf(filaEncontrada);//EspecificoDespachado
            //    filaEncontrada.BeginEdit();
            //    filaEncontrada["EspecificoDespachado"] = true;
            //    filaEncontrada.AcceptChanges();
            //    CodigoProducto = VentaUtilidadesCLN.ObtenerCodigoProductoPorCodigoProductoEspecifico(CodigoProductoEspecifico);
            //    string CodigoProductoEliminar = CodigoProducto.Trim() + "," + indiceFila.ToString() + "," + CodigoProductoEspecifico;
            //    if(listaCodigosProductosEspecificosTemporal.Contains(CodigoProductoEliminar))
            //    {
            //        listaCodigosProductosEspecificosTemporal.Remove(CodigoProductoEliminar);
            //    }

            //}
            //else // se debe buscar en la Base de datos y cerciorarse de que el Codigo Especifico se encuentre Registrado
            //{
            //    if (this.VentaUtilidadesCLN.ExisteCodigoProductoEspecificoEnInventario(CodigoProductoEspecifico))
            //    {
            //        CodigoProducto = VentaUtilidadesCLN.ObtenerCodigoProductoPorCodigoProductoEspecifico(CodigoProductoEspecifico);
            //        int indiceFila = buscarPosicionActualizarListaProductosEspecificos(CodigoProducto.Trim(), CodigoProductoEspecifico);
            //        if(indiceFila >=0)
            //            dGVProductosEspecificos.Rows[indiceFila].Selected = true;
            //    }
            //    else
            //    {
            //        MessageBox.Show(this, "No puede Realizar la Venta de un Producto específico que no se encuentra Registrado en Inventarios" + Environment.NewLine + " Verifique sus Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        txtBoxCodEspecifico.Focus();
            //        txtBoxCodEspecifico.SelectAll();
            //    }
            //}
        }

        public int buscarPosicionActualizarListaProductosEspecificos(string CodigoProducto, string NuevoCodigoProductoEspecifico)
        {
            int indiceFila = 0;
            int indice = 0;
            char[] separadorComas = new char[] { ',' };
            string[] datosCodigosEspecificos;
            datosCodigosEspecificos = listaCodigosProductosEspecificosTemporal[indice].ToString().Split(separadorComas, StringSplitOptions.RemoveEmptyEntries);
            string codigoComparacion = datosCodigosEspecificos[0].Trim();
            while (codigoComparacion.CompareTo(CodigoProducto) != 0 && indice < listaCodigosProductosEspecificosTemporal.Count)  //&& _DTProductosEspecificosTemporal.Rows[indice]["EspecificoDespachado"].Equals(false)
            {
                //tratamos de encontrar el codigoEspecifico

                indice++;
                datosCodigosEspecificos = listaCodigosProductosEspecificosTemporal[indice].ToString().Split(separadorComas, StringSplitOptions.RemoveEmptyEntries);
                codigoComparacion = datosCodigosEspecificos[0].Trim();
            }
            datosCodigosEspecificos = listaCodigosProductosEspecificosTemporal[indice].ToString().Split(separadorComas, StringSplitOptions.RemoveEmptyEntries);
            if (Int32.TryParse(datosCodigosEspecificos[1], out indiceFila))
            {
                dGVProductosEspecificos.Rows[indiceFila].Cells[2].Value = NuevoCodigoProductoEspecifico;
                _DTProductosEspecificosTemporal.Rows[indiceFila]["EspecificoDespachado"] = true;
                int indiceAuxiliar = indice;
                int indiceGrilla = 0;
                if (indiceFila < listaCodigosProductosEspecificosTemporal.Count)
                {
                    datosCodigosEspecificos = listaCodigosProductosEspecificosTemporal[indiceAuxiliar].ToString().Split(separadorComas, StringSplitOptions.RemoveEmptyEntries);
                    codigoComparacion = datosCodigosEspecificos[0].Trim();
                    indiceGrilla = Int32.Parse(datosCodigosEspecificos[1]);
                    while (codigoComparacion.CompareTo(CodigoProducto) == 0 && (indiceGrilla + 1 < dGVProductosEspecificos.RowCount) && String.IsNullOrEmpty(dGVProductosEspecificos[1, indiceGrilla + 1].Value.ToString()))
                    {
                        if (_DTProductosEspecificosTemporal.Rows[indiceGrilla + 1]["EspecificoDespachado"].Equals(false))
                        {
                            dGVProductosEspecificos.Rows[indiceGrilla + 1].Cells[2].Value = datosCodigosEspecificos[2].Trim();
                            datosCodigosEspecificos = listaCodigosProductosEspecificosTemporal[indiceAuxiliar].ToString().Split(separadorComas, StringSplitOptions.RemoveEmptyEntries);
                            codigoComparacion = datosCodigosEspecificos[0].Trim();
                            indiceGrilla = Int32.Parse(datosCodigosEspecificos[1]);
                        }
                        else
                        {
                            indiceGrilla++;
                        }
                        indiceAuxiliar++;

                    }
                }
                listaCodigosProductosEspecificosTemporal.RemoveAt(2);
                return indiceFila;
            }
            else
            {
                return -1;
            }
        }

        private void dGVProductosEspecificos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string CodigoEspecificoNuevo = dGVProductosEspecificos.CurrentCell.Value.ToString();
            string CodigoEspecificoAnterior = dGVProductosEspecificos.CurrentCell.FormattedValue.ToString();
            DataRow Fila = _DTProductosEspecificosTemporal.Rows.Find(CodigoEspecificoAnterior);
            if (Fila != null) // si ya existe Codigo Especifico
            {
                MessageBox.Show(this, "No Puede Ingresar Codigos Especificos Repetidos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarProductoEspecifico_Click(object sender, EventArgs e)
        {
            DataRow FilaEncontrada;
            int indiceEncontrado = 0;
            string CodigoProductoEspecifico = txtBoxCodEspecifico.Text.Trim();
            if (dGVProductosEspecificos.Visible && dGVProductosEspecificos.RowCount > 0)
            {
                FilaEncontrada = _DTProductosEspecificosTemporal.Rows.Find(CodigoProductoEspecifico);
                if (FilaEncontrada != null)
                {
                    dGVProductosEspecificos.ClearSelection();
                    indiceEncontrado = _DTProductosEspecificosTemporal.Rows.IndexOf(FilaEncontrada);
                    dGVProductosEspecificos.Rows[indiceEncontrado].Selected = true;
                }
                else
                {
                    MessageBox.Show("No se Encuentra el Producto Específico que está buscando");
                    txtBoxCodEspecifico.Focus();
                    txtBoxCodEspecifico.SelectAll();
                }
            }
            if (dtGVVentaProductosEspecificos.Visible && dtGVVentaProductosEspecificos.RowCount > 0)
            {
                string CodigoProducto = VentaUtilidadesCLN.ObtenerCodigoProductoPorCodigoProductoEspecifico(NumeroAgencia, CodigoProductoEspecifico);
                if (String.IsNullOrEmpty(CodigoProducto))
                {
                    MessageBox.Show("No se Encuentra el Producto Específico que está buscando para esta Venta");
                    txtBoxCodEspecifico.Focus();
                    txtBoxCodEspecifico.SelectAll();
                    return;
                }
                FilaEncontrada = _DTProductosEspecificos.Rows.Find(new object[] { CodigoProducto, CodigoProductoEspecifico });
                if (FilaEncontrada != null)
                {

                    dtGVVentaProductosEspecificos.ClearSelection();
                    indiceEncontrado = _DTProductosEspecificos.Rows.IndexOf(FilaEncontrada);
                    dtGVVentaProductosEspecificos.Rows[indiceEncontrado].Selected = true;
                }
                else
                {
                    MessageBox.Show("No se Encuentra el Producto Específico que está buscando para esta Venta");
                    txtBoxCodEspecifico.Focus();
                    txtBoxCodEspecifico.SelectAll();
                }
            }
        }

        private void btnBuscarProductosEspecificoAgregado_Click(object sender, EventArgs e)
        {
            DataRow FilaEncontrada;
            int indiceEncontrado = 0;
            string CodigoProductoEspecifico = txtBoxCodEspecificoAgregado.Text.Trim();
            if (dtGVProductosAgregados.Visible && dtGVProductosAgregados.RowCount > 0)
            {
                FilaEncontrada = _DTProductosEspecificosAgregadosTemporal.Rows.Find(CodigoProductoEspecifico);
                if (FilaEncontrada != null)
                {
                    dtGVProductosAgregados.ClearSelection();
                    indiceEncontrado = _DTProductosEspecificosAgregadosTemporal.Rows.IndexOf(FilaEncontrada);
                    dtGVProductosAgregados.Rows[indiceEncontrado].Selected = true;
                }
                else
                {
                    MessageBox.Show("No se Encuentra el Producto Específico que está buscando");
                    txtBoxCodEspecificoAgregado.Focus();
                    txtBoxCodEspecificoAgregado.SelectAll();
                }
            }

            if (dtGVVentaProductosEspecificosAgregados.Visible && dtGVVentaProductosEspecificosAgregados.RowCount > 0)
            {
                string CodigoProducto = VentaUtilidadesCLN.ObtenerCodigoProductoPorCodigoProductoEspecifico(NumeroAgencia, CodigoProductoEspecifico);
                if (String.IsNullOrEmpty(CodigoProducto))
                {
                    MessageBox.Show("No se Encuentra el Producto Específico que está buscando para esta Venta");
                    txtBoxCodEspecificoAgregado.Focus();
                    txtBoxCodEspecificoAgregado.SelectAll();
                    return;
                }
                FilaEncontrada = _DTProductosEspecificosAgregados.Rows.Find(new object[] { CodigoProducto, CodigoProductoEspecifico });
                if (FilaEncontrada != null)
                {

                    dtGVVentaProductosEspecificosAgregados.ClearSelection();
                    indiceEncontrado = _DTProductosEspecificosAgregados.Rows.IndexOf(FilaEncontrada);
                    dtGVVentaProductosEspecificosAgregados.Rows[indiceEncontrado].Selected = true;
                }
                else
                {
                    MessageBox.Show("No se Encuentra el Producto Específico que está buscando para esta Venta");
                    txtBoxCodEspecificoAgregado.Focus();
                    txtBoxCodEspecificoAgregado.SelectAll();
                }
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FClientes formClientes = new FClientes(true, false, false, true);
            formClientes.ShowDialog(this);
            if (cBoxCliente.DataSource == null)
            {
                cargarClientesComboBox();
                cBoxCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
                cBoxCliente.AutoCompleteSource = AutoCompleteSource.ListItems;


            }

            int CodigoCliente = VentaUtilidadesCLN.ObtenerUltimoIndiceTabla("Clientes");
            DataTable DTClientesAux = cBoxCliente.DataSource as DataTable;
            if (DTClientesAux.Rows.Find(CodigoCliente) == null)
            {
                DataTable DTClienteNuevo = ClienteCLN.ObtenerCliente(CodigoCliente);
                if (DTClienteNuevo.Rows.Count != 0)
                {
                    DTClientesAux.Rows.Add(new object[] { DTClienteNuevo.Rows[0]["CodigoCliente"], DTClienteNuevo.Rows[0]["NombreCliente"], DTClienteNuevo.Rows[0]["NITCliente"] });

                    DTClientesAux.DefaultView.Sort = "NombreCliente ASC";
                }
            }

            cBoxCliente.SelectedValue = CodigoCliente;
        }

        private void informeGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTVentasProductos = VentaProductosCLN.ListarVentaProductoReporte(NumeroAgencia, numeroVenta);
            DataTable DTVentasProductosDetalle = VentaProductosDetalleCLN.ListarVentaProductoDetalleReporte(NumeroAgencia, numeroVenta);
            DataTable DTVentasProductosAgregados = VentaproductosAgregados.ListarVentasProductosEspecificosAgregadosReportes(NumeroAgencia, numeroVenta);
            FReporteVentasProductosGeneral formReporteVentasProductos = new FReporteVentasProductosGeneral(DTVentasProductosAgregados, DTVentasProductos, DTVentasProductosDetalle, 'G');
            formReporteVentasProductos.ShowDialog(this);

            //mostarReporteParaEntregaProductosAlmacenes();
        }

        private void incluirAgregadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTVentasProductos = VentaProductosCLN.ListarVentaProductoReporte(NumeroAgencia, numeroVenta);
            DataTable DTVentasProductosDetalle = VentaProductosDetalleCLN.ListarVentaProductoDetalleReporteIncluidoAgregados(NumeroAgencia, numeroVenta, "S", true, true);
            DataTable DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);
            FReporteVentasProductosGeneral formReporteVentasProductos = new FReporteVentasProductosGeneral(DTDatosAgencia, DTVentasProductos, DTVentasProductosDetalle, 'F');
            formReporteVentasProductos.ShowDialog(this);
        }

        private void sinAgregadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTVentasProductos = VentaProductosCLN.ListarVentaProductoReporte(NumeroAgencia, numeroVenta);
            DataTable DTVentasProductosDetalle = VentaProductosDetalleCLN.ListarVentaProductoDetalleReporteIncluidoAgregados(NumeroAgencia, numeroVenta, "S", false, true);
            DataTable DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);
            FReporteVentasProductosGeneral formReporteVentasProductos = new FReporteVentasProductosGeneral(DTDatosAgencia, DTVentasProductos, DTVentasProductosDetalle, 'F');
            formReporteVentasProductos.ShowDialog(this);
        }

        private void reciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTVentasProductos = VentaProductosCLN.ListarVentaProductoReporte(NumeroAgencia, numeroVenta);
            DataTable DTVentasProductosDetalle = VentaProductosDetalleCLN.ListarVentaProductoDetalleReporteIncluidoAgregados(NumeroAgencia, numeroVenta, "S", true, false);
            DataTable DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);
            //FReporteVentasProductosGeneral formReporteVentasProductos = new FReporteVentasProductosGeneral(DTDatosAgencia, DTVentasProductos, VentaUtilidadesCLN.ObtenerListaProductosParaCambiarMoneda(NumeroAgencia,null, DTVentasProductosDetalle), 'R');
            FReporteVentasProductosGeneral formReporteVentasProductos = new FReporteVentasProductosGeneral(DTDatosAgencia, DTVentasProductos, DTVentasProductosDetalle, 'R');
            formReporteVentasProductos.ShowDialog(this);
        }

        private void mostarReporteParaEntregaProductosAlmacenes()
        {
            DataTable DTVentasProductos = VentaProductosCLN.ListarVentaProductoReporte(NumeroAgencia, numeroVenta);
            DataTable DTVentasProductosDetalle = VentaProductosDetalleCLN.ListarVentaProductoDetalleReporteParaRecogerDeAlmacenes(NumeroAgencia, numeroVenta, "S", true);
            DataTable DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);
            //FReporteVentaEntregaProductosAlmacenes formReporteVentasProductos = new FReporteVentaEntregaProductosAlmacenes(DTDatosAgencia, DTVentasProductos, VentaUtilidadesCLN.ObtenerListaProductosParaCambiarMoneda(NumeroAgencia, null, DTVentasProductosDetalle));
            FReporteVentaEntregaProductosAlmacenes formReporteVentasProductos = new FReporteVentaEntregaProductosAlmacenes(DTDatosAgencia, DTVentasProductos, DTVentasProductosDetalle);
            formReporteVentasProductos.ShowDialog(this);
        }

        private void btnCambiarMoneda_Click(object sender, EventArgs e)
        {
            FCambiarMonedaCotizacionDeTransaccionesGC formCambioMoneda;
            if (btnAceptar.Enabled)
            {
                formCambioMoneda = new FCambiarMonedaCotizacionDeTransaccionesGC(_DTVentasProductosDetalleTemporal, NumeroPC, NumeroAgencia, numeroVenta, VentaUtilidadesCLN, 'I');
            }
            else
            {
                formCambioMoneda = new FCambiarMonedaCotizacionDeTransaccionesGC(_DTVentasProductosDetalle, NumeroPC, NumeroAgencia, numeroVenta, VentaUtilidadesCLN, 'F');
            }
            formCambioMoneda.DarEstiloParaVentas();
            formCambioMoneda.ShowDialog(this);
            formCambioMoneda.Dispose();
        }

        private void cBoxCliente_DropDown(object sender, EventArgs e)
        {
            if (cBoxCliente.DataSource == null)
            {
                cargarClientesComboBox();
                cBoxCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
                cBoxCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        private void botonesToolStrip_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void botonesToolStrip_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void checkBIncluirFactura_CheckedChanged(object sender, EventArgs e)
        {
            if (!btnNuevaVenta.Enabled && !btnVentaInstitucional.Enabled)
            {

                if (checkBIncluirFactura.Checked)
                {
                    AumentarPrecioFactura();
                    ventaConFactura = true;
                }
                else
                {
                    QuitarPrecioFactura();
                    ventaConFactura = false;
                }
            }
        }

        public void AumentarPrecioFactura(bool esVentaConfirmada)
        {
            if (DTVentasProductosDetalleTemporal.Rows.Count > 0)
            {
                decimal PrecioNuevo = 0;
                int cantidad = 0;
                DTVentasProductosDetalleTemporal.Columns["PrecioTotal"].ReadOnly = false;
                if (esVentaConfirmada)
                {
                    foreach (DataRow FilaVentaDetalle in DTVentasProductosDetalleTemporal.Rows)
                    {
                        DataRow FilaEncontrada = _DTVentasProductosDetalle.Rows.Find(FilaVentaDetalle[0].ToString());
                        if (FilaEncontrada != null) // si existe ese producto en el anterior detalle
                        {
                            FilaVentaDetalle["Precio"] = FilaEncontrada["PrecioUnitarioVenta"];
                            FilaVentaDetalle["PrecioTotal"] = decimal.Parse(FilaEncontrada["PrecioUnitarioVenta"].ToString()) * int.Parse(FilaVentaDetalle["Cantidad"].ToString());
                        }
                        else
                        {
                            PrecioNuevo = decimal.Round(decimal.Parse(FilaVentaDetalle["Precio"].ToString()), 2);
                            cantidad = int.Parse(FilaVentaDetalle["Cantidad"].ToString());
                            PrecioNuevo = decimal.Round(PrecioNuevo * PorcentajeImpuestoSistema / 100, 2) + PrecioNuevo;

                            FilaVentaDetalle["Precio"] = decimal.Round(PrecioNuevo, 2);
                            FilaVentaDetalle["PrecioTotal"] = decimal.Round(PrecioNuevo * cantidad, 2);
                        }
                    }
                }
                else
                {
                    foreach (DataRow FilaVentaDetalle in DTVentasProductosDetalleTemporal.Rows)
                    {
                        PrecioNuevo = decimal.Round(decimal.Parse(FilaVentaDetalle["Precio"].ToString()), 2);
                        cantidad = int.Parse(FilaVentaDetalle["Cantidad"].ToString());
                        PrecioNuevo = decimal.Round(PrecioNuevo * PorcentajeImpuestoSistema / 100, 2) + PrecioNuevo;

                        FilaVentaDetalle["Precio"] = decimal.Round(PrecioNuevo, 2);
                        FilaVentaDetalle["PrecioTotal"] = decimal.Round(PrecioNuevo * cantidad, 2);
                    }
                }
                this.txtBoxPrecioTotal.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false").ToString() + " " + MascaraMonedaSistema;
                this.txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;
                DTVentasProductosDetalleTemporal.Columns["PrecioTotal"].ReadOnly = true;
            }
        }

        public void AumentarPrecioFactura()
        {
            CodigoMonedaActual = int.Parse(cBoxMoneda.SelectedValue.ToString());
            if (CodigoMonedaActual == CodigoMonedaSistema)
            {
                if (DTVentasProductosDetalleTemporal.Rows.Count > 0)
                {
                    decimal PrecioNuevo = 0;
                    int cantidad = 0;
                    DTVentasProductosDetalleTemporal.Columns["PrecioTotal"].ReadOnly = false;
                    foreach (DataRow FilaVentaDetalle in DTVentasProductosDetalleTemporal.Rows)
                    {
                        PrecioNuevo = decimal.Round(decimal.Parse(FilaVentaDetalle["Precio"].ToString()), 2);
                        cantidad = int.Parse(FilaVentaDetalle["Cantidad"].ToString());
                        PrecioNuevo = decimal.Round(PrecioNuevo * PorcentajeImpuestoSistema / 100, 2) + PrecioNuevo;

                        FilaVentaDetalle["Precio"] = decimal.Round(PrecioNuevo, 2);
                        FilaVentaDetalle["PrecioTotal"] = decimal.Round(PrecioNuevo * cantidad, 2);
                    }
                    this.txtBoxPrecioTotal.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false").ToString() + " " + MascaraMonedaSistema;
                    this.txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;
                    DTVentasProductosDetalleTemporal.Columns["PrecioTotal"].ReadOnly = true;
                }
            }
            else
            {
                cambiarCotizacion();
            }

            //DTVentasProductosDetalleTemporal.AcceptChanges();
        }

        public void cambiarCotizacion()
        {
            if (checkBIncluirFactura.Checked)
            {
                if (DTVentasProductosDetalleTemporal.Rows.Count > 0)
                {
                    int CantidadEntregada = 0;
                    foreach (DataRow FilaProducto in DTVentasProductosDetalleTemporal.Rows)
                    {
                        CantidadEntregada = int.Parse(FilaProducto["CantidadEntregada"].ToString());
                        FilaProducto.RejectChanges();
                        FilaProducto["CantidadEntregada"] = CantidadEntregada;
                    }
                }
            }
            _DTVentasProductosTemporalCambioMoneda = VentaUtilidadesCLN.CambiarMonedaCotizacionDetalleDeTransaccionTemporal(DTVentasProductosDetalleTemporal, NumeroAgencia, int.Parse(cBoxMoneda.SelectedValue.ToString()), VentaUtilidadesCLN.ObtenerFechaHoraServidor(), checkBIncluirFactura.Checked, true);
            BDSourceVentaProductosSeleccionados.DataSource = _DTVentasProductosTemporalCambioMoneda;
            dGVProductosSeleccionados.DataSource = BDSourceVentaProductosSeleccionados;
            txtBoxPrecioTotal.Text = _DTVentasProductosTemporalCambioMoneda.Compute("sum(PrecioTotal)", "").ToString() + " " + _DTMonedas.Rows.Find(CodigoMonedaActual)["MascaraMoneda"].ToString();
            txtBoxPrecioTotalCancelar.Text = _DTVentasProductosTemporalCambioMoneda.Compute("sum(PrecioTotal)", "").ToString() + " " + _DTMonedas.Rows.Find(CodigoMonedaActual)["MascaraMoneda"].ToString();
        }

        public void QuitarPrecioFactura()
        {
            CodigoMonedaActual = int.Parse(cBoxMoneda.SelectedValue.ToString());
            if (CodigoMonedaActual == CodigoMonedaSistema)
            {
                if (DTVentasProductosDetalleTemporal.Rows.Count > 0)
                {
                    int CantidadEntregada = 0;
                    foreach (DataRow FilaProducto in DTVentasProductosDetalleTemporal.Rows)
                    {
                        CantidadEntregada = int.Parse(FilaProducto["CantidadEntregada"].ToString());
                        FilaProducto.RejectChanges();
                        FilaProducto["CantidadEntregada"] = CantidadEntregada;
                    }

                    //DTVentasProductosDetalleTemporal.RejectChanges();
                    this.txtBoxPrecioTotal.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false").ToString() + " " + MascaraMonedaSistema;
                    this.txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;
                }
            }
            else
                cambiarCotizacion();
        }

        public void QuitarPrecioFactura(bool esVentaConfirmada)
        {
            if (DTVentasProductosDetalleTemporal.Rows.Count > 0)
            {
                if (esVentaConfirmada)
                {
                    decimal PrecioNuevo = 0;
                    string CodigoProducto = "";
                    string NumeroPrecioSeleccionado = "";
                    int cantidad = 0;
                    DTVentasProductosDetalleTemporal.Columns["PrecioTotal"].ReadOnly = false;
                    foreach (DataRow FilaVentaDetalle in DTVentasProductosDetalleTemporal.Rows)
                    {
                        NumeroPrecioSeleccionado = FilaVentaDetalle["NumeroPrecioSeleccionado"].ToString();
                        cantidad = int.Parse(FilaVentaDetalle["Cantidad"].ToString());
                        if (NumeroPrecioSeleccionado.Equals("P")) // Precio Personalizado
                        {
                            PrecioNuevo = decimal.Parse(FilaVentaDetalle["Precio"].ToString());
                            PrecioNuevo = PrecioNuevo - PrecioNuevo * PorcentajeImpuestoSistema / 100;
                            PrecioNuevo = Decimal.Round(PrecioNuevo, 2);
                        }
                        else
                        {
                            CodigoProducto = FilaVentaDetalle["Código Producto"].ToString();
                            PrecioNuevo = VentaUtilidadesCLN.ObtenerPrecioRelativoProducto(NumeroAgencia, CodigoProducto, NumeroPrecioSeleccionado, false);
                        }

                        FilaVentaDetalle["Precio"] = PrecioNuevo;
                        FilaVentaDetalle["PrecioTotal"] = PrecioNuevo * cantidad;
                    }
                    DTVentasProductosDetalleTemporal.Columns["PrecioTotal"].ReadOnly = true;
                }
                else
                {
                    DTVentasProductosDetalleTemporal.RejectChanges();
                }
                this.txtBoxPrecioTotal.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false").ToString() + " " + MascaraMonedaSistema;
                this.txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;
            }
        }


        public void QuitarPrecioFacturaVentaFinalizada()
        {
            if (_DTVentasProductosDetalle.Rows.Count > 0)
            {

                decimal PrecioNuevo = 0;
                string CodigoProducto = "";
                string NumeroPrecioSeleccionado = "";
                int cantidad = 0;
                foreach (DataRow FilaVentaDetalle in _DTVentasProductosDetalle.Rows)
                {
                    NumeroPrecioSeleccionado = FilaVentaDetalle["NumeroPrecioSeleccionado"].ToString();
                    cantidad = int.Parse(FilaVentaDetalle["CantidadVenta"].ToString());
                    if (NumeroPrecioSeleccionado.Equals("P")) // Precio Personalizado
                    {
                        PrecioNuevo = decimal.Parse(FilaVentaDetalle["PrecioUnitarioVenta"].ToString());
                        PrecioNuevo = PrecioNuevo - PrecioNuevo * PorcentajeImpuestoSistema / 100;
                        PrecioNuevo = Decimal.Round(PrecioNuevo, 2);
                    }
                    else
                    {
                        CodigoProducto = FilaVentaDetalle["CodigoProducto"].ToString();
                        PrecioNuevo = VentaUtilidadesCLN.ObtenerPrecioRelativoProducto(NumeroAgencia, CodigoProducto, NumeroPrecioSeleccionado, false);
                    }

                    FilaVentaDetalle["PrecioUnitarioVenta"] = PrecioNuevo;
                }
                this.txtBoxPrecioTotal.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false").ToString() + " " + MascaraMonedaSistema;
                this.txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;
            }
        }



        public void emitirPermisos(bool permitirVender, bool permitirVenderInstituciones, bool permitirAnular, bool permitirModificar, bool permitirReportes, bool permitirNavegar, bool permitirPagar)
        {
            btnNuevaVenta.Visible = permitirVender;
            btnVentaInstitucional.Visible = permitirVenderInstituciones;
            btnAnular.Visible = permitirAnular;
            btnModificar.Visible = permitirModificar;
            btnReportes.Visible = permitirReportes;
            btnBuscar.Visible = permitirNavegar;
            btnFinalizar.Visible = permitirPagar;
            this.permitirModificar = permitirModificar;
        }


        private void cBoxMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TipoOperacion == "N" || TipoOperacion == "E")
            {
                CodigoMonedaActual = int.Parse(cBoxMoneda.SelectedValue.ToString());
                if (CodigoMonedaActual != CodigoMonedaSistema)
                {
                    cambiarCotizacion();
                }
                else
                {
                    BDSourceVentaProductosSeleccionados.DataSource = DTVentasProductosDetalleTemporal;
                    dGVProductosSeleccionados.DataSource = BDSourceVentaProductosSeleccionados;
                    txtBoxPrecioTotal.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;
                    txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;
                    if (checkBIncluirFactura.Checked)
                        AumentarPrecioFactura();
                }

            }
        }

        private void FVentasProductos_Load(object sender, EventArgs e)
        {
            if (!esCotizacionVenta)
            {
                CodigoMonedaActual = int.Parse(cBoxMoneda.SelectedValue.ToString());
                if (CodigoMonedaActual != CodigoMonedaSistema && _DTVentasProductos.Rows.Count > 0 && _DTVentasProductosDetalle.Rows.Count > 0)
                {
                    DataTable DTDetalleProductosTemporal;
                    DateTime FechaHoraVenta = DateTime.Parse(_DTVentasProductos.Rows[0]["FechaHoraVenta"].ToString());
                    if (!string.IsNullOrEmpty(_DTVentasProductos.Rows[0]["NumeroFactura"].ToString()))
                    {
                        QuitarPrecioFacturaVentaFinalizada();
                    }

                    DTDetalleProductosTemporal = VentaUtilidadesCLN.CambiarMonedaCotizacionDetalleDeTransaccion(NumeroAgencia, CodigoMonedaActual, FechaHoraVenta, checkBIncluirFactura.Checked, 'V', numeroVenta, true);
                    BDSourceVentaProductosSeleccionados.DataSource = DTDetalleProductosTemporal;
                    dGVProductosSeleccionados.DataSource = BDSourceVentaProductosSeleccionados;
                    txtBoxPrecioTotal.Text = DTDetalleProductosTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + _DTMonedas.Rows.Find(CodigoMonedaActual)["MascaraMoneda"].ToString();
                    txtBoxPrecioTotalCancelar.Text = DTDetalleProductosTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + _DTMonedas.Rows.Find(CodigoMonedaActual)["MascaraMoneda"].ToString();

                }
                else
                    cargarPieDetallePrecio();
            }
        }

        private void entregaInstitucionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTVentasProductos = VentaProductosCLN.ListarVentaProductoReporte(NumeroAgencia, numeroVenta);
            //DataTable DTVentasProductosDetalle = VentaProductosDetalleCLN.ListarVentaProductoDetalleReporte(NumeroAgencia, numeroVenta);
            DataTable DTVentasProductosDetalle = VentaProductosDetalleCLN.ListarVentaProductoDetalleReporteIncluidoEspecificos(NumeroAgencia, numeroVenta, "S", true, false);
            DataTable DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);
            //FReporteVentasProductosGeneral formReporteVentasProductos = new FReporteVentasProductosGeneral(DTDatosAgencia, DTVentasProductos, VentaUtilidadesCLN.ObtenerListaProductosParaCambiarMoneda(NumeroAgencia,null, DTVentasProductosDetalle), 'R');
            FReporteVentasProductosGeneral formReporteVentasProductos = new FReporteVentasProductosGeneral(DTDatosAgencia, DTVentasProductos, DTVentasProductosDetalle, 'T');
            formReporteVentasProductos.ShowDialog(this);
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FObservacionesTransaccionesModificacion _FObservacionesTransaccionesModificacion = new FObservacionesTransaccionesModificacion("V", CodigoUsuario, NumeroAgencia, numeroVenta);
            _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text = txtBoxObservaciones.Text;
            if (_FObservacionesTransaccionesModificacion.ShowDialog() == DialogResult.OK)
                txtBoxObservaciones.Text = _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text;
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tSBarraVentas_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }



    public class TiposAgregados
    {
        private string _CodigoTipoAgregado;
        public string CodigoTipoAgregado
        {
            get { return _CodigoTipoAgregado; }
            set { this._CodigoTipoAgregado = value; }
        }

        private string _NombreAgregado;
        public string NombreAgregado
        {
            get { return _NombreAgregado; }
            set { this._NombreAgregado = value; }
        }


        public TiposAgregados(string codigo, string nombre)
        {
            this._CodigoTipoAgregado = codigo;
            this._NombreAgregado = nombre;
        }
    }

}


