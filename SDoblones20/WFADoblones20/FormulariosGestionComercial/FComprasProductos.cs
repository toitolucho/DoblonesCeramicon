using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCAD;
using CLCLN;
using System.Collections;
using CLCLN.GestionComercial;
using CLCLN.Contabilidad;
using CLCLN.Sistema;
using WFADoblones20.FormulariosContabilidad;
using WFADoblones20.FormulariosSistema;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FComprasProductos : Form
    {
        private DataTable VariablesConfiguracionSistemaGC;
        private PCsConfiguracionesCLN PCConfiguracion;
        
        private byte CodigoMonedaSistema = 0;
        private string NombreMonedaSistema = "";
        private string MascaraMonedaSistema = "";
        private int CodigoMonedaRegion = 0;
        private string NombreMonedaRegion = "";
        private string MascaraMonedaRegion = "";
        private decimal PorcentajeImpuestoSistema = 15.5M; 
        private bool ContabilidadIntegrada = false;
        
        
        FProductosBusqueda fProductosBusqueda = null;
        DataTable _DTProductosSeleccionados = null;
        DataTable _DTProveedores = null;
        DSDoblones20GestionComercial.ComprasProductosDataTable _DTComprasProductos = null;
        DataTable _DTComprasProductosDetalle = null;
        DataTable _DTComprasProductosTemporal = null;
        DataTable _DTComprasProductosDetalleTemporal = null;
        DataTable _DTProductosEspecificos = null;
        DataTable _DTProductosEspecificosTemporal = null;
        DataTable _DTProductosEspecificosAgregados = null;
        DataTable _DTProductosEspecificosAgregadosTemporal = null;
        DSDoblones20GestionComercial2.OrigenMercaderiasDataTable _DTOrigenMercaderia = null;
        DSDoblones20GestionComercial2.MediosTransportesDataTable _DTMedioTransporte = null;
        DataTable _DTUsuarios = null;

        DataSet DSMaestroDetalle = null;
        

        private ComprasProductosCLN _comprasProductosCLN = null;
        private ComprasProductosDetalleCLN _comprasProductosDetalleCLN = null;
        private ProveedoresCLN _proveedoresCLN = null;
        private ComprasProductosEspecificosCLN _comprasProductosEspecificosCLN = null;
        private ComprasProductosEspecificosAgregadosCLN _comprasProductosEspecificosAgregadosCLN = null;
        private InventariosProductosEspecificosCLN _inventarioProductosEspecificosCLN = null;
        private TransaccionesUtilidadesCLN _comprasUtilidadesCLN = null;
        private InventariosProductosCLN _inventarioProductosCLN = null;
        private CuentasPorPagarCLN _cuentasPorPagar = null;
        private UsuariosCLN _UsuariosCLN = null;
        private MedioTransporteCLN _MedioTransporteCLN = null;
        private OrigenMercaderiaCLN _OrigenMercaderiaCLN = null;
        private int NumeroPC = 0;
        private int CodigoUsuario;        
        private int CantidadAgregados = 0;
        private string MascaraMoneda = "Bs";
        private Color ColorResaltado = Color.YellowGreen;
        private int NumeroCredito = -1;
        private string TipoOperacion = "";
        private string CodigoTipoCompra = "";

        /// <summary>
        /// Posibles Estados de los Productos especificos al momento de la Compra para inventariarlos
        /// y ponerlos a disposición de acuerdo al valor que toman
        /// </summary>
        ArrayList listadoEstados = new ArrayList();

        ArrayList listadoCodigosFormaAdquisicion = new ArrayList();

        /// <summary>
        /// si los Codigos Específicos de los Productos Comprados han Sido Generados
        /// </summary>
        bool CodigosGenerados = true;

        /// <summary>
        /// si los Codigos de productos Agregados han sido generados para la Compra de los mismos
        /// </summary>
        bool CodigosAgregadosGenerados = true;

        int NumeroCompraProducto = 0;
        /// <summary>
        /// Agencia para la cual se realizará las transacciones
        /// </summary>
        private int NumeroAgencia = 1;
        /// <summary>
        /// tipo de Venta que realizara -> R:Credito E:Efectivo
        /// </summary>
        char tipoCompra = 'E'; // 
        private decimal PorcentajeImpuestoCompraConFactura;
        private decimal PorcentajeImpuestoCompraSinFactura;

        object detallePrecioTotal;
        /// <summary>
        /// Cuando No Existe errores en la Venta que se Realiza, para culminar la misma
        /// y almacenarla en la Base de Datos
        /// </summary>
        //bool DatosVentaCorrectos = true;

        /// <summary>
        /// Constantes de las Columnas de las Tablas
        /// </summary>        
        const int columnaCodigo = 0;
        const int columnaNombreProducto = 1;
        const int columnaCantidad = 2;
        const int columnaPrecio = 3;
        const int columnaPrecioTotal = 4;
        const int columnaGarantia = 5;


        const int AlturaDGVProductosEspecificos = 251;
        const int AlturaDGVProductosEspecificosAgregados = 251;
        Font fuenteDefecto;

        #region Propiedades de la Capa de Negocio
        public CuentasPorPagarCLN _CuentasPorPagarCLN
        {
            get
            {
                if (_cuentasPorPagar == null)
                    _cuentasPorPagar = new CuentasPorPagarCLN();
                return _cuentasPorPagar;
            }
        }

        public ComprasProductosEspecificosAgregadosCLN CompraProductoEspecificoAgregadoCLN
        {
            get
            {
                if (_comprasProductosEspecificosAgregadosCLN == null)
                    _comprasProductosEspecificosAgregadosCLN = new ComprasProductosEspecificosAgregadosCLN();
                return _comprasProductosEspecificosAgregadosCLN;
            }
        }

        public InventariosProductosCLN InventarioProductoCLN
        {
            get
            {
                if (_inventarioProductosCLN == null)
                    _inventarioProductosCLN = new InventariosProductosCLN();
                return _inventarioProductosCLN;
            }
        }

        public TransaccionesUtilidadesCLN CompraUtilidadesCLN
        {
            get
            {
                if (_comprasUtilidadesCLN == null)
                    _comprasUtilidadesCLN = new TransaccionesUtilidadesCLN();
                return _comprasUtilidadesCLN;
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

        public ComprasProductosEspecificosCLN CompraProductosEspecificosCLN
        {
            get
            {
                if (this._comprasProductosEspecificosCLN == null)
                    this._comprasProductosEspecificosCLN = new ComprasProductosEspecificosCLN();
                return this._comprasProductosEspecificosCLN;
            }
        }


        public ProveedoresCLN ProveedorCLN
        {
            get
            {
                if (_proveedoresCLN == null)
                    _proveedoresCLN = new ProveedoresCLN();
                return _proveedoresCLN;
            }
        }

        public ComprasProductosCLN CompraProductosCLN
        {
            get
            {
                if (_comprasProductosCLN == null)
                    _comprasProductosCLN = new ComprasProductosCLN();
                return _comprasProductosCLN;
            }
        }

        public ComprasProductosDetalleCLN CompraProductosDetalleCLN
        {
            get
            {
                if (_comprasProductosDetalleCLN == null)
                    _comprasProductosDetalleCLN = new ComprasProductosDetalleCLN();
                return _comprasProductosDetalleCLN;
            }
        }

        public OrigenMercaderiaCLN OrigMercaderiaCLN
        {
            get
            {
                if (_OrigenMercaderiaCLN == null)
                    _OrigenMercaderiaCLN = new OrigenMercaderiaCLN();
                return _OrigenMercaderiaCLN;
            }
        }

        public MedioTransporteCLN MedioTransCLN
        {
            get
            {
                if (_MedioTransporteCLN == null)
                    _MedioTransporteCLN = new MedioTransporteCLN();
                return _MedioTransporteCLN;
            }
        }

        #endregion
        
        

        public FComprasProductos(int NumeroAgencia, int NumeroPC, int CodigoUsuario)
        {

            InitializeComponent();
            MascaraMonedaSistema = "$us";
    
            //Inicio codigo agregado
            VariablesConfiguracionSistemaGC = new DataTable();
            PCConfiguracion = new PCsConfiguracionesCLN();
            VariablesConfiguracionSistemaGC = PCConfiguracion.ObtenerConfiguracionSistemaParaTransaccionesGC(NumeroPC);

            this.CodigoMonedaSistema = byte.Parse(VariablesConfiguracionSistemaGC.Rows[0][3].ToString());
            this.NombreMonedaSistema = VariablesConfiguracionSistemaGC.Rows[0][4].ToString();
            this.MascaraMonedaSistema = VariablesConfiguracionSistemaGC.Rows[0][5].ToString();
            this.CodigoMonedaRegion = int.Parse(VariablesConfiguracionSistemaGC.Rows[0][6].ToString());
            this.NombreMonedaRegion = VariablesConfiguracionSistemaGC.Rows[0][7].ToString();
            this.MascaraMonedaRegion = VariablesConfiguracionSistemaGC.Rows[0][8].ToString();
            this.PorcentajeImpuestoSistema = decimal.Parse(VariablesConfiguracionSistemaGC.Rows[0][9].ToString());
            this.ContabilidadIntegrada = bool.Parse(VariablesConfiguracionSistemaGC.Rows[0][10].ToString());
            this.PorcentajeImpuestoCompraConFactura = decimal.Parse(VariablesConfiguracionSistemaGC.Rows[0][11].ToString());
            this.PorcentajeImpuestoCompraSinFactura = decimal.Parse(VariablesConfiguracionSistemaGC.Rows[0][12].ToString());
            //Fin codigo agregado
             
            _UsuariosCLN = new UsuariosCLN();
            
            cargarDatosComboBox();

            toolStripFechaCompra.Text = DateTime.Now.ToString();
            bdNavProductosEspecificos.Visible = true;
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            this.CodigoUsuario = CodigoUsuario;
            dGVProductosSeleccionados.DataSource = bdSourceComprasProductosDetalle;
            dGVProductosSeleccionados.AutoGenerateColumns = false;

            _DTProductosSeleccionados = new DataTable();
            _DTProveedores = new DataTable();
            _DTComprasProductos = new DSDoblones20GestionComercial.ComprasProductosDataTable();
            _DTComprasProductosDetalle = new DataTable();
            _DTOrigenMercaderia = new DSDoblones20GestionComercial2.OrigenMercaderiasDataTable();
            _DTMedioTransporte = new DSDoblones20GestionComercial2.MediosTransportesDataTable();
            _DTComprasProductosTemporal = new DataTable();
            _DTComprasProductosDetalleTemporal = new DataTable();

            _DTProductosEspecificos = new DataTable();
            _DTProductosEspecificosTemporal = new DataTable();

            _DTProductosEspecificosAgregados = new DataTable();
            _DTProductosEspecificosAgregadosTemporal = new DataTable();


            NumeroCompraProducto = CompraUtilidadesCLN.ObtenerUltimoIndiceTabla("ComprasProductos");

            _DTProveedores = ProveedorCLN.ListarProveedoresCompras();
            _DTProveedores.DefaultView.Sort = "NombreRazonSocial ASC";
            cBoxProveedor.DataSource = _DTProveedores;
            cBoxProveedor.DisplayMember = "NombreRazonSocial";
            cBoxProveedor.ValueMember = "CodigoProveedor";

            //_DTComprasProductos = CompraProductosCLN.ObtenerCompraProducto(NumeroAgencia, NumeroCompraProducto);
            //bdSourceComprasProductos.DataSource = _DTComprasProductos;

            //_DTComprasProductosDetalle = CompraUtilidadesCLN.ListarDetalleDeCompra(NumeroAgencia, NumeroCompraProducto);
            //_DTComprasProductosDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadCompra*PrecioUnitarioCompra");
            //bdSourceComprasProductosDetalle.DataSource = _DTComprasProductosDetalle;



            fProductosBusqueda = new FProductosBusqueda(NumeroAgencia, NumeroPC, 'C', CodigoMonedaSistema);


            _DTComprasProductosTemporal = _DTComprasProductos.Clone();
            _DTComprasProductosDetalleTemporal = _DTComprasProductosDetalle.Clone();


            //Creación de la ralación maestro detalle!
            DSMaestroDetalle = new DataSet();
            cargarDatosCompras(NumeroCompraProducto);

            

            dGVProductosSeleccionados.DataSource = bdSourceComprasProductosDetalle;
            bdSourceComprasProductos.MoveLast();

            listadoCodigosFormaAdquisicion.Add(new TiposAgregados("O","Obsequio"));
            listadoCodigosFormaAdquisicion.Add(new TiposAgregados("P","Promoción"));
            listadoCodigosFormaAdquisicion.Add(new TiposAgregados("B","Bonificación"));
            listadoCodigosFormaAdquisicion.Add(new TiposAgregados("C","Compensación"));

            listadoEstados.Add(new EstadoProductoEspecifico("A", "DISPONIBLE"));
            //listadoEstados.Add(new EstadoProductoEspecifico("B", "DE BAJA"));
            listadoEstados.Add(new EstadoProductoEspecifico("R", "EN MANTIMIENTO"));
            //listadoEstados.Add(new EstadoProductoEspecifico("V", "VENDIDO"));

            this.DGCCodigoEstado.DataSource = listadoEstados;
            this.DGCCodigoEstado.ValueMember = "CodigoEstado";
            this.DGCCodigoEstado.DisplayMember = "NombreEstado";


            this.DGCCodigoTipoAgregadoAgregado.DataSource = listadoCodigosFormaAdquisicion;
            this.DGCCodigoTipoAgregadoAgregado.ValueMember = "CodigoTipoAgregado";
            this.DGCCodigoTipoAgregadoAgregado.DisplayMember = "NombreAgregado";

            crearColumnasDTProductosEspecificos();
            crearColumnasDTProductosEspecificosAgregados();            

            fuenteDefecto = dGVProductosEspecificos.DefaultCellStyle.Font;

            dtGVCompraProductosAgregados.CurrentCellDirtyStateChanged += new EventHandler(dtGVCompraProductosAgregados_CurrentCellDirtyStateChanged);            
            visualizarDatosPagosPorCompra();
            crearCheckBoxHeader();
            tabControl1.TabPages.RemoveAt(2);
            
        }

        public void cargarDatosComboBox()
        {
            _DTUsuarios = _UsuariosCLN.ListarDatosUsuarioTransacciones();
            cBoxComprador.DataSource = _DTUsuarios;
            cBoxComprador.DisplayMember = "NombreUsuario";
            cBoxComprador.ValueMember = "CodigoUsuario";

            _DTMedioTransporte = MedioTransCLN.ListarMedioTransportes();
            cBoxMediosTransporte.DataSource = _DTMedioTransporte;
            cBoxMediosTransporte.DisplayMember = "NombreMedioTransporte";
            cBoxMediosTransporte.ValueMember = "CodigoMedioTransporte";

            _DTOrigenMercaderia = OrigMercaderiaCLN.ListarOrigenMercaderias();
            cBoxOrigenMercaderia.DataSource = _DTOrigenMercaderia;
            cBoxOrigenMercaderia.DisplayMember = "NombreOrigenMercaderia";
            cBoxOrigenMercaderia.ValueMember = "CodigoOrigenMercaderia";
            
        }

        public void crearCheckBoxHeader()
        {
            //Para los Productos Especificos Agregados
            System.Drawing.Rectangle rect = dtGVCompraProductosAgregados.GetCellDisplayRectangle(7, -1, true);
            rect.X = dtGVCompraProductosAgregados.Width - 15;
            rect.Y += 2;
            CheckBox checkboxHeaderAgregados = new CheckBox();
            checkboxHeaderAgregados.BackColor = dtGVCompraProductosAgregados.Columns[7].HeaderCell.Style.BackColor;            
            checkboxHeaderAgregados.Name = "checkboxHeaderAgregados";
            checkboxHeaderAgregados.Size = new Size(16, 16);
            checkboxHeaderAgregados.Location = rect.Location;
            checkboxHeaderAgregados.CheckedChanged += new EventHandler(checkboxHeaderAgregados_CheckedChanged);

            dtGVCompraProductosAgregados.Controls.Add(checkboxHeaderAgregados);
        }

        void checkboxHeaderAgregados_CheckedChanged(object sender, EventArgs e)
        {
            bool EstadoCheckEspecificos = ((CheckBox)dtGVCompraProductosAgregados.Controls.Find("checkboxHeaderAgregados", true)[0]).Checked;
            for (int i = 0; i < dtGVCompraProductosAgregados.RowCount; i++)
            {
                dtGVCompraProductosAgregados[7, i].Value = EstadoCheckEspecificos;
            }
            dtGVCompraProductosAgregados.EndEdit();
        }
        void dtGVCompraProductosAgregados_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtGVCompraProductosAgregados.CurrentCell is DataGridViewCheckBoxCell)
            {
                dtGVCompraProductosAgregados.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }


        public void crearMaestroDetalle()
        {
            //DSMaestroDetalle.Locale = System.Globalization.CultureInfo.InvariantCulture;

            //DataColumn ColumnPrimaryAgencia = new DataColumn();
            //DataColumn ColumnPrimaryNumeroCompra = new DataColumn();

            //DataColumn ColumnForeignAgenciaDetalle = new DataColumn();
            //DataColumn ColumnForeignNumeroCompraDetalle = new DataColumn();

            //ColumnPrimaryAgencia = _DTComprasProductos.Columns[0];
            //ColumnPrimaryNumeroCompra = _DTComprasProductos.Columns[1];

            //ColumnForeignAgenciaDetalle = _DTComprasProductosDetalle.Columns[0];
            //ColumnForeignNumeroCompraDetalle = _DTComprasProductosDetalle.Columns[1];

            //if (DSMaestroDetalle.Relations.Count > 0)
            //    DSMaestroDetalle.Relations.Clear();
            //if (DSMaestroDetalle.Tables.Count > 0)
            //{
            //    bdSourceComprasProductosDetalle.DataMember = "";
            //    bdSourceComprasProductos.DataMember = "";
            //    DSMaestroDetalle.Tables[1].Constraints.Remove("ComprasProductosMaestroDetalle");
            //    DSMaestroDetalle.Tables[0].Constraints.Clear();
            //    DSMaestroDetalle.Tables[1].Constraints.Clear();
            //    DSMaestroDetalle.Tables.RemoveAt(1);
            //    DSMaestroDetalle.Tables.Clear();
            //}

            //DSMaestroDetalle.Tables.Add(_DTComprasProductos);
            //DSMaestroDetalle.Tables.Add(_DTComprasProductosDetalle);
            //DataRelation relacionMaestroDetalle = new DataRelation("ComprasProductosMaestroDetalle", new DataColumn[] { ColumnPrimaryAgencia, ColumnPrimaryNumeroCompra }, new DataColumn[] { ColumnForeignAgenciaDetalle, ColumnForeignNumeroCompraDetalle }, true);
            //DSMaestroDetalle.Relations.Add(relacionMaestroDetalle);

            //bdSourceComprasProductos.DataSource = DSMaestroDetalle;
            //bdSourceComprasProductos.DataMember = "ComprasProductos";

            //bdSourceComprasProductosDetalle.DataSource = bdSourceComprasProductos;
            //bdSourceComprasProductosDetalle.DataMember = "ComprasProductosMaestroDetalle";

            //ListSortDirection direction = ListSortDirection.Ascending;


            ////Cargamos los Productos Especificos
            //_DTProductosEspecificos = CompraProductosEspecificosCLN.ListarComprasProductosEspecificosParaCompra(NumeroAgencia, NumeroCompraProducto);
            //if (_DTProductosEspecificos.Rows.Count > 0)
            //{
            //    if (!DSMaestroDetalle.Tables.Contains(_DTProductosEspecificos.TableName))
            //        DSMaestroDetalle.Tables.Add(_DTProductosEspecificos);

            //    dtGVCompraProductosEspecificos.BindData(DSMaestroDetalle, _DTProductosEspecificos.TableName);
            //    dtGVCompraProductosEspecificos.Visible = true;
            //    dtGVCompraProductosEspecificos.Height = AlturaDGVProductosEspecificos;
            //    dtGVCompraProductosEspecificos.GroupTemplate.Column = dtGVCompraProductosEspecificos.Columns[0];
            //    dtGVCompraProductosEspecificos.Sort(new DataRowComparer(0, direction));
            //    dtGVCompraProductosEspecificos.Dock = DockStyle.Fill;

            //    dGVProductosEspecificos.Visible = false;
            //    dGVProductosEspecificos.Height = 0;
            //    dGVProductosEspecificos.Dock = DockStyle.None;
            //}
            //else
            //{
            //    dGVProductosEspecificos.Visible = true;
            //    dGVProductosEspecificos.Height = AlturaDGVProductosEspecificos;
            //    dGVProductosEspecificos.Dock = DockStyle.Fill;

            //    dtGVCompraProductosEspecificos.Visible = false;
            //    dtGVCompraProductosEspecificos.Dock = DockStyle.None;
            //    dtGVCompraProductosEspecificos.Height = 0;
            //}



            ////Cargamos los Productos Agregados            
            //_DTProductosEspecificosAgregados = CompraProductoEspecificoAgregadoCLN.ListarComprasProductosEspecificosAgregadosParaCompra(NumeroAgencia, NumeroCompraProducto);
            //if (_DTProductosEspecificosAgregados.Rows.Count > 0)
            //{
            //    if (!DSMaestroDetalle.Tables.Contains(_DTProductosEspecificosAgregados.TableName))
            //        DSMaestroDetalle.Tables.Add(_DTProductosEspecificosAgregados);
            //    dtGVCompraProductosEspecificosAgregados.BindData(DSMaestroDetalle, _DTProductosEspecificosAgregados.TableName);
            //    dtGVCompraProductosEspecificosAgregados.Height = AlturaDGVProductosEspecificosAgregados;
            //    dtGVCompraProductosEspecificosAgregados.Dock = DockStyle.Fill;
            //    dtGVCompraProductosEspecificosAgregados.GroupTemplate.Column = dtGVCompraProductosEspecificosAgregados.Columns[0];
            //    dtGVCompraProductosEspecificosAgregados.Sort(new DataRowComparer(0, direction));
            //    dtGVCompraProductosEspecificosAgregados.Visible = true;


            //    dtGVCompraProductosAgregados.Visible = false;
            //    dtGVCompraProductosAgregados.Height = 0;
            //    dtGVCompraProductosAgregados.Dock = DockStyle.None;
            //}
            //else
            //{
            //    dtGVCompraProductosAgregados.Visible = true;
            //    dtGVCompraProductosAgregados.Height = AlturaDGVProductosEspecificosAgregados;
            //    dtGVCompraProductosAgregados.Dock = DockStyle.Fill;

            //    dtGVCompraProductosEspecificosAgregados.Visible = false;
            //    dtGVCompraProductosEspecificosAgregados.Dock = DockStyle.None;
            //    dtGVCompraProductosEspecificosAgregados.Height = 0;
            //}
        }


        /// <summary>
        /// Se encarga de Formatear las Columnas del DataGridView ProductosSeleccionados
        /// de Acuerdo a la Operación que se desea mostrar
        /// en caso de que se desea mostrar el detalle de una Compra ya Realizada, pasar como parametro false,
        /// caso contrario True, para mostrar el Detalle Actual de una Venta en Curso
        /// </summary>
        /// <param name="esParaVender"> si La Venta se lleva en Curso</param>
        public void formatearEstiloTabla(bool esParaComprar)
        {
            if (esParaComprar)
            { 
                DGCCodigoProductoDetalle.DataPropertyName = "Código Producto";
                DGCNombreProductoDetalle.DataPropertyName = "Nombre Producto";
                DGCCantidadDetalle.DataPropertyName = "Cantidad";
                DGCPrecioUnitarioCompra.DataPropertyName = "Precio";
                DGCPrecioTotalDetalle.DataPropertyName = "PrecioTotal";
                DGCTiempoGarantia.DataPropertyName = "Garantia";                
            }
            else
            {

                DGCCodigoProductoDetalle.DataPropertyName = "CodigoProducto";
                DGCNombreProductoDetalle.DataPropertyName = "NombreProducto";
                DGCCantidadDetalle.DataPropertyName = "CantidadCompra";
                DGCPrecioUnitarioCompra.DataPropertyName = "PrecioUnitarioCompra";
                DGCPrecioTotalDetalle.DataPropertyName = "PrecioTotal";
                DGCTiempoGarantia.DataPropertyName = "TiempoGarantiaCompra";
            }
        }


        /// <summary>
        /// Se encarga de habilitar o deshabilitar los campos del formulario de Compras
        /// </summary>
        /// <param name="EstadoHabilitacion"></param>
        public void habilitarCampos(bool EstadoHabilitacion)
        {
            cBoxProveedor.Enabled = EstadoHabilitacion;
            //cBoxComprador.Enabled = EstadoHabilitacion;
            rBtnCredito.Enabled = EstadoHabilitacion;
            rBtnEfectivo.Enabled = EstadoHabilitacion;
            txtBoxObservaciones.ReadOnly = !EstadoHabilitacion;
            txtBoxNroGuia.ReadOnly = !EstadoHabilitacion;
            txtBoxMontoDeuda.ReadOnly = !EstadoHabilitacion;
            txtBoxMontoEfectivo.ReadOnly = !EstadoHabilitacion;
            btnBuscarProveedor.Enabled = EstadoHabilitacion;
            btnRegistrarProveedor.Enabled = EstadoHabilitacion;
            checkConFactura.Enabled = EstadoHabilitacion;

            checkVerCodEspecificos.Visible = checkActualizarPrecios.Visible = EstadoHabilitacion;
            checkVerCodEspecificos.Enabled = checkActualizarPrecios.Enabled = EstadoHabilitacion;

            DGCEsProductoEspecifico.Visible = false;
            this.cMenuObservaciones.Enabled = !EstadoHabilitacion;
            dtPickerFechaHoraPlazoDeRecepcion.Enabled = EstadoHabilitacion;

            checkImportacion.Enabled = EstadoHabilitacion;
            checkIngresoDirecto.Enabled = EstadoHabilitacion;

            if(tabControlDatos.TabPages.Contains(tabPageDatosFactura))
                tabControlDatos.Controls[tabPageDatosFactura.Name].Enabled = EstadoHabilitacion;
            if (tabControlDatos.TabPages.Contains(tabPageDatosImportacion))
                tabControlDatos.Controls[tabPageDatosImportacion.Name].Enabled = EstadoHabilitacion;
            habilitarControlesFactura(EstadoHabilitacion);
            habilitarControlesImportacion(EstadoHabilitacion);
            
        }

        public void habilitarControlesImportacion(bool EstadoHabilitacion)
        {
            foreach (Control componente in tabPageDatosImportacion.Controls)
            {
                if (componente.Name.CompareTo(txtBoxDIPersonaRecojo.Name) != 0)
                {
                    componente.Enabled = EstadoHabilitacion;
                }
            }
        }

        public void habilitarControlesFactura(bool EstadoHabilitacion)
        {
            foreach (Control componente in tabPageDatosFactura.Controls)
            {
                componente.Enabled = EstadoHabilitacion;                
            }
        }


        /// <summary>
        /// Método que se encarga de la correspondiente habilitacion de los botones que controlan
        /// la transacción de la compra, de acuerdo al Estado en que se encuentra la misma
        /// Pasar valores booleanoes en caso de desear habilitar TRUE, caso contrario FALSE
        /// </summary>
        /// <param name="nuevaVenta">Habilitar una Nueva Compra</param>
        /// <param name="modificar">Modificar la Compra que se Cursa Actualmente</param>
        /// <param name="cancelar">Cancelar la Compra</param>
        /// <param name="anular">Anular la Compra</param>
        /// <param name="aceptar">Confirmar la Compra para recibir el Monto de Pago</param>
        /// <param name="finalizar">Finalizar completamente la Compra una vez terminada toda la Transacción</param>
        /// <param name="buscarProveedor">Abrir el formulario avanzado de busqueda de proveedores</param>
        /// <param name="nuevoProveedor">Agregar un Nuevo Proveedor</param>
        /// <param name="reportes">Permitir mostrar Reportes</param>
        /// <param name="buscar">Buscar otras Ventas</param>
        /// <param name="buscar">Pagar la Compra de los Productos</param>
        private void habilitarBotonesCompras(bool nuevaVenta, bool modificar, bool cancelar, bool anular, bool aceptar, bool finalizar, bool reportes, bool buscarCompras, bool pagar)
        {
            btnNuevaCompra.Enabled = nuevaVenta;
            btnModificar.Enabled = modificar;
            btnCancelar.Enabled = cancelar;
            btnAnular.Enabled = anular;
            btnAceptar.Enabled = aceptar;
            btnFinalizar.Enabled = finalizar;            
            btnReporte.Enabled = reportes;
            btnBuscar.Enabled = buscarCompras;
            btnPagar.Enabled = pagar;
        }

        /// <summary>
        /// Se encarga de Cargar nuevamente los datos de la Base de datos
        /// para Actualizar el Formulario
        /// </summary>
        public void cargarDatosCompras(int NumCompraProducto)
        {
            this._DTProductosSeleccionados.Rows.Clear();
            this.fProductosBusqueda.nuevaVenta = true;  
            _DTComprasProductos = CompraProductosCLN.ObtenerCompraProducto(NumeroAgencia, NumCompraProducto);
            if (_DTComprasProductos != null && _DTComprasProductos.Count > 0)
            {
                _DTComprasProductosDetalle = CompraUtilidadesCLN.ListarDetalleDeCompra(NumeroAgencia, NumCompraProducto);
                _DTComprasProductosDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadCompra*PrecioUnitarioCompra");
                formatearEstiloTabla(false);
                bdSourceComprasProductosDetalle.DataSource = _DTComprasProductosDetalle;

                txtBoxObservaciones.Text = _DTComprasProductos[0].IsObservacionesNull() ? "" : _DTComprasProductos[0].Observaciones;
                cBoxComprador.SelectedValue = _DTComprasProductos[0].CodigoUsuario;
                cBoxProveedor.SelectedValue = _DTComprasProductos[0].CodigoProveedor;
                if (_DTComprasProductos[0].CodigoTipoCompra.CompareTo("R") == 0)
                {
                    rBtnCredito.Checked = true;
                }
                else
                    rBtnEfectivo.Checked = true;

                lblNumeroCompra.Text = NumeroCompraProducto.ToString();
                toolStripFechaCompra.Text = _DTComprasProductos[0].Fecha.ToString("dd/MM/yyyy");
                checkConFactura.Checked = _DTComprasProductos[0].CodigoEstadoFactura.CompareTo("F") == 0;                
                txtBoxMontoIVAFactura.Text = _DTComprasProductos[0].IsImpuestoIVANull() ? "0.00" : _DTComprasProductos[0].ImpuestoIVA.ToString().Trim();
                txtBoxNumeroFactura.Text = _DTComprasProductos[0].IsNumeroFacturaNull() ? "" : _DTComprasProductos[0].NumeroFactura.Trim();
                txtBoxNroAutorizacionFactura.Text = _DTComprasProductos[0].IsNumeroAutorizacionFacturaNull() ? "" : _DTComprasProductos[0].NumeroAutorizacionFactura.Trim();
                txtBoxCodigoControlFactura.Text = _DTComprasProductos[0].IsCodigoControlFacturaNull() ? "" : _DTComprasProductos[0].CodigoControlFactura.Trim();
                checkImportacion.Checked = _DTComprasProductos[0].IsEsImportacionNull() ? false : _DTComprasProductos[0].EsImportacion;                
                checkIngresoDirecto.Checked = _DTComprasProductos[0].IsRegistroDirectoAlmacenNull() ? false : _DTComprasProductos[0].RegistroDirectoAlmacen;
                if (checkImportacion.Checked)
                {
                    if (!tabControlDatos.Controls.Contains(tabPageDatosImportacion))
                        tabControlDatos.TabPages.Add(tabPageDatosImportacion);
                }
                else
                {
                    if (tabControlDatos.Controls.Contains(tabPageDatosImportacion))
                        tabControlDatos.TabPages.Remove(tabPageDatosImportacion);
                }

                if (checkConFactura.Checked)
                {
                    if (!tabControlDatos.Controls.Contains(tabPageDatosFactura))
                        tabControlDatos.TabPages.Add(tabPageDatosFactura);
                }
                else
                {
                    if (tabControlDatos.Controls.Contains(tabPageDatosFactura))
                        tabControlDatos.TabPages.Remove(tabPageDatosFactura);
                }
                tabControlDatos.SelectedTab = tabPageDatosGenerales;

                if (_DTComprasProductos[0].IsFechaHoraEnvioMercaderiaNull())
                {
                    dtPickerFechaEnvioMercaderia.Format = DateTimePickerFormat.Custom;
                    dtPickerFechaEnvioMercaderia.CustomFormat = "  :  ";
                }
                else
                    dtPickerFechaEnvioMercaderia.Value = _DTComprasProductos[0].FechaHoraEnvioMercaderia;

                if (_DTComprasProductos[0].IsFechaHoraPlazoDeRecepcionNull())
                {
                    dtPickerFechaHoraPlazoDeRecepcion.Format = DateTimePickerFormat.Custom;
                    dtPickerFechaHoraPlazoDeRecepcion.CustomFormat = "  :  ";
                }
                else
                    dtPickerFechaHoraPlazoDeRecepcion.Value = _DTComprasProductos[0].FechaHoraPlazoDeRecepcion;
                if (_DTComprasProductos[0].IsCodigoMedioTransporteNull())
                    cBoxMediosTransporte.SelectedIndex = -1;
                else
                    cBoxMediosTransporte.SelectedValue = _DTComprasProductos[0].CodigoMedioTransporte;
                if (_DTComprasProductos[0].IsCodigoOrigenMercaderiaNull())
                    cBoxOrigenMercaderia.SelectedIndex = -1;
                else
                    cBoxOrigenMercaderia.SelectedValue = _DTComprasProductos[0].CodigoOrigenMercaderia;
                txtBoxDIPersonaRecojo.Text = _DTComprasProductos[0].IsDIPersonaDestinatarioNull() ? "" : _DTComprasProductos[0].DIPersonaDestinatario;

                txtBoxNombreCompletoPersonaRecojo.Text = _DTComprasProductos[0].IsDIPersonaDestinatarioNull() ? "" :
                    _comprasUtilidadesCLN.ObtenerNombreCompleto(_DTComprasProductos[0].DIPersonaDestinatario);

                txtBoxNroGuia.Text = _DTComprasProductos[0].IsNumeroGuiaTranposrteNull() ? "" : _DTComprasProductos[0].NumeroGuiaTranposrte.Trim();

                switch (_DTComprasProductos[0].CodigoEstadoCompra)
                {
                    case "F":
                        lblEstado.Text = "Finalizada";
                        toolStripPBEstado.Value = toolStripPBEstado.Maximum;
                        habilitarBotonesCompras(true, false, false, false, false, false, true, true, false);
                        break;
                    case "X":
                        lblEstado.Text = "Finalizada Incompleta";
                        toolStripPBEstado.Value = toolStripPBEstado.Maximum;
                        habilitarBotonesCompras(true, false, false, false, false, false, true, true, false);
                        break;
                    case "C":
                        lblEstado.Text = "Cancelada";
                        toolStripPBEstado.Value = toolStripPBEstado.Maximum;
                        habilitarBotonesCompras(true, false, false, false, false, false, true, true, false);
                        break;
                    case "I":
                        lblEstado.Text = "Iniciada";
                        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3;
                        //Tomar en cuenta que ahora la finalización se hace desde otra interfaz
                        //en caso de que todo se tenga que hacer desde una misma interfaz, habilitar 
                        //el botón de finalización
                        habilitarBotonesCompras(true, true, false, true, false, false, true, true, true);
                        break;
                    case "A":
                        lblEstado.Text = "Anulada";
                        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 2;
                        habilitarBotonesCompras(true, false, false, false, false, false, true, true, false);
                        break;
                    case "D":
                        lblEstado.Text = "Pendiente de Recepción (En Transito)";
                        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3 + toolStripPBEstado.Maximum / 3;
                        habilitarBotonesCompras(true, false, false, false, false, false, true, true, true);
                        break;
                    case "P":
                        bool estadoEdicionCredito = false;
                        lblEstado.Text = !string.IsNullOrEmpty(_DTComprasProductos.Rows[0]["NumeroCuentaPorPagar"].ToString()) ? "Pagada a CREDITO" : "Pagada";
                        if (_DTComprasProductos.Rows[0]["NumeroCuentaPorPagar"] != null)
                        {
                            estadoEdicionCredito = new ComprasProductosDetalleEntregaCLN().ListarComprasProductosDetalleEntregaParaRecepcion(NumeroAgencia, NumeroCompraProducto).Rows.Count == 0;
                        }
                        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 2;
                        habilitarBotonesCompras(true, estadoEdicionCredito, false, false, false, false, true, true, true);
                        break;

                }
                habilitarCampos(false);
                detallePrecioTotal = _DTComprasProductosDetalle.Compute("sum(PrecioTotal)", "");
                if (detallePrecioTotal.ToString().Length > 0)
                    txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " " + MascaraMonedaSistema;
                else
                    txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;

                errorProvider1.Clear();
                
                if (_DTComprasProductos.Rows.Count > 0)
                {
                    if (!_DTComprasProductos[0].IsNumeroCuentaPorPagarNull())
                    {
                        decimal deuda = _comprasUtilidadesCLN.ObtenerCuentaPorPagarDeuda(NumeroAgencia, _DTComprasProductos[0].NumeroCuentaPorPagar);
                        decimal MontoTotalCompra = decimal.Parse(_DTComprasProductos.Rows[0]["MontoTotalCompra"].ToString());
                        tipoCompra = 'R';
                        lblMontoDeuda.Visible = lblMontoEfectivo.Visible = txtBoxMontoDeuda.Visible = txtBoxMontoEfectivo.Visible = true;
                        txtBoxMontoDeuda.Text = deuda.ToString() + " " + MascaraMonedaSistema;
                        txtBoxMontoEfectivo.Text = (MontoTotalCompra - deuda).ToString() + " " + MascaraMonedaSistema;
                    }
                    else
                    {
                        tipoCompra = 'E';
                        visualizarDatosPagosPorCompra();
                    }
                    this.NumeroCompraProducto = NumCompraProducto;
                }
                DSMaestroDetalle = new DataSet();
                //Cargamos los Productos Especificos
                ListSortDirection direction = ListSortDirection.Ascending;
                _DTProductosEspecificos = CompraProductosEspecificosCLN.ListarComprasProductosEspecificosParaCompra(NumeroAgencia, NumCompraProducto);
                if (_DTProductosEspecificos.Rows.Count > 0)
                {
                    
                    DSMaestroDetalle.Tables.Add(_DTProductosEspecificos);
                    dtGVCompraProductosEspecificos.BindData(DSMaestroDetalle, _DTProductosEspecificos.TableName);

                    dtGVCompraProductosEspecificos.Visible = true;
                    dtGVCompraProductosEspecificos.Height = AlturaDGVProductosEspecificos;
                    dtGVCompraProductosEspecificos.GroupTemplate.Column = dtGVCompraProductosEspecificos.Columns[0];
                    dtGVCompraProductosEspecificos.Sort(new DataRowComparer(0, direction));
                    dtGVCompraProductosEspecificos.Dock = DockStyle.Fill;

                    dGVProductosEspecificos.Visible = false;
                    dGVProductosEspecificos.Height = 0;
                    dGVProductosEspecificos.Dock = DockStyle.None;
                }
                else
                {
                    dGVProductosEspecificos.Visible = true;
                    dGVProductosEspecificos.Height = AlturaDGVProductosEspecificos;
                    dGVProductosEspecificos.Dock = DockStyle.Fill;

                    dtGVCompraProductosEspecificos.Visible = false;
                    dtGVCompraProductosEspecificos.Dock = DockStyle.None;
                    dtGVCompraProductosEspecificos.Height = 0;
                }


                //Cargamos los Productos Agregados            
                _DTProductosEspecificosAgregados = CompraProductoEspecificoAgregadoCLN.ListarComprasProductosEspecificosAgregadosParaCompra(NumeroAgencia, NumCompraProducto);
                if (_DTProductosEspecificosAgregados.Rows.Count > 0)
                {
                    DSMaestroDetalle.Tables.Add(_DTProductosEspecificosAgregados);
                    dtGVCompraProductosEspecificosAgregados.BindData(DSMaestroDetalle, _DTProductosEspecificosAgregados.TableName);
                    dtGVCompraProductosEspecificosAgregados.Height = AlturaDGVProductosEspecificosAgregados;
                    dtGVCompraProductosEspecificosAgregados.Dock = DockStyle.Fill;
                    dtGVCompraProductosEspecificosAgregados.GroupTemplate.Column = dtGVCompraProductosEspecificosAgregados.Columns[0];
                    dtGVCompraProductosEspecificosAgregados.Sort(new DataRowComparer(0, direction));
                    dtGVCompraProductosEspecificosAgregados.Visible = true;


                    dtGVCompraProductosAgregados.Visible = false;
                    dtGVCompraProductosAgregados.Height = 0;
                    dtGVCompraProductosAgregados.Dock = DockStyle.None;
                }
                else
                {
                    dtGVCompraProductosAgregados.Visible = true;
                    dtGVCompraProductosAgregados.Height = AlturaDGVProductosEspecificosAgregados;
                    dtGVCompraProductosAgregados.Dock = DockStyle.Fill;

                    dtGVCompraProductosEspecificosAgregados.Visible = false;
                    dtGVCompraProductosEspecificosAgregados.Dock = DockStyle.None;
                    dtGVCompraProductosEspecificosAgregados.Height = 0;
                }
            }
            else
            {
                habilitarCampos(false);
                habilitarBotonesCompras(true, false, false, false, false, false, false, true, false);
                limpiarControles();
            }
                      
        }

        public void limpiarControles()
        {
            errorProvider1.Clear();
            this.lblEstado.Text = "INDETERMINADO";
            this.toolStripFechaCompra.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.lblNumeroCompra.Text = "0";
            cBoxComprador.SelectedIndex = -1;
            cBoxMediosTransporte.SelectedIndex = -1;
            cBoxOrigenMercaderia.SelectedIndex = -1;
            cBoxProveedor.SelectedIndex = -1;
            rBtnCredito.Checked = rBtnEfectivo.Checked = false;
            checkConFactura.Checked = checkImportacion.Checked = checkIngresoDirecto.Checked = false;
            //pnlDatosFactura.Visible = false;
            //pnlDatosImportacion.Visible = false;
            txtBoxMontoIVAFactura.Text = txtBoxNumeroFactura.Text = txtBoxNroAutorizacionFactura.Text = txtBoxCodigoControlFactura.Text = String.Empty;
            dtPickerFechaEnvioMercaderia.Format = dtPickerFechaHoraPlazoDeRecepcion.Format = DateTimePickerFormat.Custom;
            dtPickerFechaEnvioMercaderia.CustomFormat = "  :  ";
            dtPickerFechaHoraPlazoDeRecepcion.CustomFormat = "  :  ";
            txtBoxNroGuia.Text = txtBoxDIPersonaRecojo.Text = txtBoxNombreCompletoPersonaRecojo.Text = txtBoxObservaciones.Text = String.Empty;

            
        }
        

        private void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            tabControlDatos.TabPages.Remove(tabPageDatosFactura);
            tabControlDatos.TabPages.Remove(tabPageDatosImportacion);

            cBoxComprador.SelectedValue = CodigoUsuario;
            _DTProductosEspecificosTemporal.Clear();
            _DTProductosEspecificosAgregadosTemporal.Clear();
            txtBoxObservaciones.Clear();
            NumeroCredito = -1;
            CodigosGenerados = false;
            CodigosAgregadosGenerados = false;
            tabControl1.SelectedIndex = 0;
            dtPickerFechaHoraPlazoDeRecepcion.Value = DateTime.Now.AddDays(10);
            

            bdSourceComprasProductos.DataSource = _DTComprasProductosTemporal;
            _DTComprasProductosDetalleTemporal = fProductosBusqueda.DTProductosSeleccionados.Clone();
            _DTComprasProductosDetalleTemporal = fProductosBusqueda.DTProductosSeleccionados;
            bdSourceComprasProductosDetalle.DataSource = _DTComprasProductosDetalleTemporal;

            limpiarControles();         
            formatearEstiloTabla(true);
            NumeroCompraProducto = CompraUtilidadesCLN.ObtenerUltimoIndiceTabla("ComprasProductos");
            if (NumeroCompraProducto == 0) NumeroCompraProducto = 1;
            if (NumeroCompraProducto > 1)
                NumeroCompraProducto++;
            if (NumeroCompraProducto == 1 && _DTComprasProductos.Rows.Count == 1)
                NumeroCompraProducto = 2;

            lblNumeroCompra.Text = NumeroCompraProducto.ToString();
            lblEstado.Text = "Iniciada";
            toolStripPBEstado.Value = (int)(toolStripPBEstado.Maximum) / 2;
            habilitarBotonesCompras(false, true, true, false, true, false, false, false, false);
            fProductosBusqueda.LabelNombrePersonaTransaccion.Text = this.cBoxProveedor.Text;
            fProductosBusqueda.LabelNumeroTransaccion.Text = this.NumeroCompraProducto.ToString();
            fProductosBusqueda.LabelNombreTransaccion.Text = "Numero Compra";

            if (rBtnCredito.Checked)
                fProductosBusqueda.LabelTipoTransaccion.Text = "Crédito";
            if (rBtnEfectivo.Checked)
                fProductosBusqueda.LabelTipoTransaccion.Text = "Efectivo";
            fProductosBusqueda.ShowDialog(this);

            if (fProductosBusqueda.TransaccionConfirmada)
            {
                //this.txtBoxPrecioTotal.Text = fProductosBusqueda.LabelPrecioTotal.Text + "  Bs";
                //string filtro = "_NumeroAgencia = " + _NumeroAgencia.ToString() + " and  NumeroCompraProducto = " + _DTComprasProductos.Rows[bdSourceComprasProductos.Position][1].ToString();
                if (_DTComprasProductosDetalleTemporal.Rows.Count > 1)
                {
                    detallePrecioTotal = _DTComprasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "");
                    if (detallePrecioTotal.ToString().Length > 0)
                        txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " "+ MascaraMonedaSistema;
                    else
                        txtBoxPrecioTotal.Text = " 0.00 "+ MascaraMonedaSistema;
                }
                else
                {
                    this.txtBoxPrecioTotal.Text = fProductosBusqueda.LabelPrecioTotal.Text + "  "+MascaraMonedaSistema;
                    //string filtro = "_NumeroAgencia = " + NumeroAgencia.ToString() + " and  NumeroCompraProducto = " + _DTComprasProductos.Rows[bdSourceComprasProductos.Position][1].ToString();
                }
                crearItemsCodigo();
                //this.dGVProductosSeleccionados.Sort(this.dGVProductosSeleccionados.Columns[7], ListSortDirection.Ascending);
                object NumeroAgregados = _DTComprasProductosDetalleTemporal.Compute("count(VendidoComoAgregado)", "VendidoComoAgregado = true");
                if (!NumeroAgregados.Equals(0))
                {
                    if (MessageBox.Show(this, "Ha Decidido añadir a esta Compra alguns Productos Como Agregados." + Environment.NewLine + "Si Desea continuar el Proceso con Los Productos Seleccionados Presiona 'Si', Caso Contrario Todos los Productos que sean Considerados como Agregados, serán cambiado de Estado" + Environment.NewLine + "¿Desea continuar con la Compra en esta Situación?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        CantidadAgregados = Int16.Parse(NumeroAgregados.ToString());
                        foreach (DataGridViewRow fila in dGVProductosSeleccionados.Rows)
                        {
                            if (fila.Cells[7].Value.Equals(true))
                            {
                                resaltarFilaProductoSeleccionado(fila, true);
                            }
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow fila in dGVProductosSeleccionados.Rows)
                        {
                            if (fila.Cells[7].Value.Equals(true))
                            {
                                _DTComprasProductosDetalleTemporal.Rows[fila.Index].BeginEdit();
                                _DTComprasProductosDetalleTemporal.Rows[fila.Index][7] = false;
                                _DTComprasProductosDetalleTemporal.Rows[fila.Index].AcceptChanges();
                                fila.Cells[7].Value = false;
                                resaltarFilaProductoSeleccionado(fila, false);
                            }
                        }
                        CantidadAgregados = 0;
                    }
                }                
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningún Producto para su Compra, se procederá a cancelar la operación Actual");                
                this.txtBoxPrecioTotal.Text = " 0.00 "+MascaraMonedaSistema;
                lblNumeroCompra.Text = "";
                toolStripPBEstado.Value = 0;
                btnCancelar_Click(sender, e);
                return;
            }
            tipoCompra = 'E';
            rBtnEfectivo.Checked = true;
            habilitarCampos(true);
            TipoOperacion = "N";            
            cBoxProveedor.Focus();
            cBoxComprador.SelectedValue = CodigoUsuario;
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

        public void crearItemsCodigo()
        {
            ProductosCLN _ProductosCLN = new ProductosCLN();
            if (toolStripbtnOpciones.DropDownItems.Count > 4)
            {
                while (toolStripbtnOpciones.DropDownItems.Count != 4)
                {
                    toolStripbtnOpciones.DropDownItems.RemoveAt(toolStripbtnOpciones.DropDownItems.Count - 1);
                }
            }
            foreach (DataGridViewRow fila in dGVProductosSeleccionados.Rows)
            {
                if ( (fila.Cells[0].Value != null) && !String.IsNullOrEmpty(fila.Cells[0].Value.ToString()))
                {
                    DataTable ProductoEncontrado = _ProductosCLN.ObtenerProducto(fila.Cells[0].Value.ToString());
                    //bool valor = (bool) ProductoEncontrado.Rows[0][9];
                    //bool generarCodigoProductoEspecifico = _ProductosCLN.ObtenerProducto(fila.Cells[0].Value.ToString()).Rows[0][9].ToString().Equals("1") ? true: false;

                    bool generarCodigoProductoEspecifico = (bool)ProductoEncontrado.Rows[0]["LlenarCodigoPE"] && InventarioProductoCLN.EsProductoEspecifico(NumeroAgencia, ProductoEncontrado.Rows[0]["CodigoProducto"].ToString());
                    ToolStripMenuItem menuProducto = new ToolStripMenuItem(fila.Cells["DGCNombreProductoDetalle"].Value.ToString().Trim());
                    menuProducto.Checked = generarCodigoProductoEspecifico;
                    menuProducto.CheckOnClick = true;
                    toolStripbtnOpciones.DropDownItems.Add(menuProducto);
                }
            }
        }

        public bool validarDatos()
        {
            errorProvider1.Clear();
            if (_DTComprasProductosDetalleTemporal.Rows.Count == 0)
            {
                errorProvider1.SetError(tabControl1, "No ha Seleccionado ningún producto");
                return false;
            }
            if (cBoxProveedor.SelectedIndex < 0)
            {
                errorProvider1.SetError(cBoxProveedor, "Aún no ha seleccionado ningún proveedor");
                tabControlDatos.SelectedTab = tabPageDatosGenerales;
                return false;
            }
            if(checkConFactura.Checked)
            {
                if (String.IsNullOrEmpty(txtBoxNumeroFactura.Text.Trim()) && MessageBox.Show(this,"¿Se encuentra Seguro de dejar en Blanco el Nro de Factura?", "Validación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    errorProvider1.SetError(txtBoxNumeroFactura, "Aún no ha ingresado el Número de Factura");
                    txtBoxNumeroFactura.Focus();
                    txtBoxNumeroFactura.SelectAll();
                    tabControlDatos.SelectedTab = tabPageDatosFactura;
                    return false;
                }
                decimal Numero = 0;
                if( !decimal.TryParse(txtBoxMontoIVAFactura.Text,out Numero)  || String.IsNullOrEmpty(txtBoxMontoIVAFactura.Text.Trim()))
                {
                    errorProvider1.SetError(txtBoxMontoIVAFactura, "Aún no ha ingresado correctamente el porcentaje del IVA");
                    txtBoxMontoIVAFactura.Focus();
                    txtBoxMontoIVAFactura.SelectAll();
                    txtBoxMontoIVAFactura.Text = "13.00";
                    tabControlDatos.SelectedTab = tabPageDatosFactura;
                    return false;
                }
            }
            if (checkImportacion.Checked)
            {
                if (dtPickerFechaEnvioMercaderia.Value == null)
                {
                    errorProvider1.SetError(dtPickerFechaEnvioMercaderia, "Aún no ha ingresado la Fecha de Envio de Mercaderia por parte de su Proveedor");
                    dtPickerFechaEnvioMercaderia.Focus();
                    tabControlDatos.SelectedTab = tabPageDatosImportacion;
                    return false;
                }
                if (dtPickerFechaHoraPlazoDeRecepcion.Value == null)
                {
                    errorProvider1.SetError(dtPickerFechaHoraPlazoDeRecepcion, "Aún no ha ingresado la Fecha de Plazo de Entrega de su Mercaderia de su Proveedor");
                    dtPickerFechaHoraPlazoDeRecepcion.Focus();
                    tabControlDatos.SelectedTab = tabPageDatosImportacion;
                    return false;
                }
                if (cBoxMediosTransporte.SelectedIndex < 0)
                {
                    errorProvider1.SetError(cBoxMediosTransporte, "Aún no ha seleccionado el Tipo de Medio de Transporte por el cual llegará su Mercaderia");
                    cBoxMediosTransporte.Focus();
                    tabControlDatos.SelectedTab = tabPageDatosImportacion;
                    return false;
                }
                if (cBoxOrigenMercaderia.SelectedIndex < 0)
                {
                    errorProvider1.SetError(cBoxOrigenMercaderia, "Aún no ha seleccionado el Origen por Donde llegará su Mercaderia");
                    cBoxOrigenMercaderia.Focus();
                    tabControlDatos.SelectedTab = tabPageDatosImportacion;
                    return false;
                }
                if (string.IsNullOrEmpty(txtBoxDIPersonaRecojo.Text.Trim()) && MessageBox.Show(this,
                    "¿Se encuentra seguro de dejar en blanco el Documento Identificador de la Persona intermediaria en la recepción de su Mercaderia?",
                    "Validación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    errorProvider1.SetError(txtBoxDIPersonaRecojo, "Aún no ha Ingresado el Documento Identificador de la Persona responsable de la Recepción Intermedia de su Mercaderia");
                    txtBoxDIPersonaRecojo.Focus();
                    txtBoxDIPersonaRecojo.SelectAll();
                    tabControlDatos.SelectedTab = tabPageDatosImportacion;
                    return false;
                }
            }
            return true;
        }


        public void actualizarPreciosVenta()
        {
            String ProductosDetalleXML;
            DataSet DSComprasTemporal2 = new DataSet("Productos");
            DataTable DTComprasProductosDetalleTempXML2 = _DTComprasProductosDetalleTemporal.Copy();
            DTComprasProductosDetalleTempXML2.TableName = "ProductosHistorial";
            DTComprasProductosDetalleTempXML2.Constraints.Clear();
            DTComprasProductosDetalleTempXML2.PrimaryKey = null;
            DTComprasProductosDetalleTempXML2.Columns.Remove(DTComprasProductosDetalleTempXML2.Columns["Nombre Producto"]);
            DTComprasProductosDetalleTempXML2.Columns["Código Producto"].ColumnName = "CodigoProducto";
            DTComprasProductosDetalleTempXML2.Columns["Cantidad"].ColumnName = "CantidadRecepcion";
            DTComprasProductosDetalleTempXML2.Columns["Precio"].ColumnName = "PrecioUnitarioCompra";
            DTComprasProductosDetalleTempXML2.AcceptChanges();
            DSComprasTemporal2.Tables.Add(DTComprasProductosDetalleTempXML2);
            ProductosDetalleXML = DTComprasProductosDetalleTempXML2.DataSet.GetXml();


            FComprasProductosActualizarPreciosVentas formPrecios = new FComprasProductosActualizarPreciosVentas(checkConFactura.Checked ? PorcentajeImpuestoCompraConFactura : PorcentajeImpuestoCompraSinFactura,
                ProductosDetalleXML, NumeroAgencia, NumeroCompraProducto);
            formPrecios.ShowDialog();
            formPrecios.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int NumeroCuentaPorPagar = -1;
            String ProductosDetalleXML = "";
            if (cBoxProveedor.SelectedValue != null)
            {
                if (_DTComprasProductosDetalleTemporal.Rows.Count > 0)
                {
                    
                    _DTComprasProductosDetalleTemporal.AcceptChanges();                   
                    
                    DataSet DSComprasTemporal = new DataSet("ComprasProductos");
                    DataTable DTComprasProductosDetalleTempXML = _DTComprasProductosDetalleTemporal.Copy();
                    DTComprasProductosDetalleTempXML.TableName = "ComprasProductosDetalle";
                    DTComprasProductosDetalleTempXML.Constraints.Clear();
                    DTComprasProductosDetalleTempXML.PrimaryKey = null;
                    DTComprasProductosDetalleTempXML.Columns.Remove(DTComprasProductosDetalleTempXML.Columns["Nombre Producto"]);
                    DTComprasProductosDetalleTempXML.Columns["Código Producto"].ColumnName = "CodigoProducto";
                    DTComprasProductosDetalleTempXML.AcceptChanges();
                    DSComprasTemporal.Tables.Add(DTComprasProductosDetalleTempXML);
                    ProductosDetalleXML = DTComprasProductosDetalleTempXML.DataSet.GetXml();

                    /*
                    if (!CodigosGenerados && _DTProductosEspecificosTemporal.Rows.Count == 0)
                    {
                        MessageBox.Show(this, "Existen Productos Seleccionados que son Considerados Específicos, Probablemente, aun no ha llenado" + Environment.NewLine + "La Información necesaria de los mismos para aceptar la Transacción", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabControl1.SelectedIndex = 1;
                        return;
                    }
                    if (!CodigosAgregadosGenerados && _DTProductosEspecificosAgregadosTemporal.Rows.Count == 0)
                    {
                        MessageBox.Show(this, "Existen Productos Seleccionados que son Considerados Específicos y se los adquirirá como Agregados, Probablemente, aun no ha llenado" + Environment.NewLine + "La Información necesaria de los mismos para aceptar la Transacción", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabControl1.SelectedIndex = 2;
                        return;
                    }
                     * Habilitar para cuando se necesita que se maneje todo en esta ventana
                     * 
                     */

                    if (fProductosBusqueda.seleccionarProductosEspecificos)
                    {
                        int indiceFila = 0;
                        bdSourceComprasProductosDetalle.MoveFirst();
                        foreach (DataRow fila in this._DTComprasProductosDetalleTemporal.Rows)
                        {
                            if (Int16.Parse(fila[6].ToString()) == 1)
                            {
                                int cantidadVendida = Int16.Parse(fila[2].ToString());
                                int productosSeleccionados = 0;
                                //dGVProductosEspecificos.CurrentRow = 0;
                                dGVProductosEspecificos.Focus();
                                //dGVProductosEspecificos.Columns[columnaNombreProducto].Selected = true;
                                dGVProductosEspecificos.Rows[0].Selected = true;
                                dGVProductosEspecificos.CurrentCell = dGVProductosEspecificos.Rows[0].Cells[0];
                                foreach (DataGridViewRow filaProductoEspecifico in dGVProductosEspecificos.Rows)
                                {
                                    if (filaProductoEspecifico.Cells[5].Value != null)
                                    {
                                        if (Boolean.Parse(filaProductoEspecifico.Cells[5].Value.ToString()) == true)
                                            productosSeleccionados++;
                                    }
                                }
                                if (productosSeleccionados != cantidadVendida)
                                {
                                    if (MessageBox.Show(this, "Los Productos Especificos Seleccionados para el Producto: " + fila[1].ToString() + ", No Coinciden con la Cantidad que desea Vender" + Environment.NewLine + " ¿Desea Cambiar La Cantidad Introducida a la cantidad de Productos Seleccionados Actualmente?", "No se Puede Completar la Compra", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                                    {
                                        fila.BeginEdit();
                                        fila[2] = productosSeleccionados;
                                        fila.AcceptChanges();
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "Proceda a Completar la Seleccion de los Productos Específicos, y Finalize la Transacción", "Compra de Productos Específicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        bdSourceComprasProductosDetalle.Position = indiceFila;
                                        tabControl1.SelectedTab = tabPage3;
                                        return;
                                    }
                                }
                            }
                            indiceFila++;
                            bdSourceComprasProductosDetalle.MoveNext();
                        }
                    }


                    errorProvider1.Clear();
                    if (!validarDatos())
                    {
                        MessageBox.Show(this, "Existen algunos datos Erroneos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                        return;
                    }

                    //Para que al momento de registrar por primera vez un producto en una orden de Compra
                    //puedan considerarlo como Producto Especifico, de acuerdo a la seleccion del usuario
                    //en la columna 'EsProductoEspecifico'
                    if (checkVerCodEspecificos.Checked)
                    {
                        try
                        {
                            string TextoProductosError = _comprasUtilidadesCLN.ActualizarCambioEstadoProductosEspecificos_A_Normal(NumeroAgencia, ProductosDetalleXML);
                            if (!String.IsNullOrEmpty(TextoProductosError))
                            {
                                if (MessageBox.Show(this, "Los siguientes Productos no pueden dejar de ser Considerados éspecificos\r\nDebido a que "
                                + "existen referencias a los mismos\r\n" + TextoProductosError
                                + "\r\n ¿Desea dejarlos en su estado Anterior ?", "Error de Edición en Productos Especificos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    _DTComprasProductosDetalleTemporal.RejectChanges();
                                }

                                MessageBox.Show("Revise sus Datos y modifiquelos");
                                return;

                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio la siguiente Excepción " + ex.Message);
                            return;
                        }
                    }


                    decimal montoEfectivo = -1, montoDeuda = -1;
                    //si la compra se la realiza a crédito, es necesario generar la cuenta por cobrar
                    if (rBtnCredito.Checked)
                    {
                        
                        if (Decimal.TryParse(txtBoxMontoEfectivo.Text.Replace(MascaraMonedaSistema, "").Trim(), out montoEfectivo) && Decimal.TryParse(txtBoxMontoDeuda.Text.Replace(MascaraMonedaSistema, "").Trim(), out montoDeuda))
                        {
                            int CodigoProveedor = Int32.Parse(cBoxProveedor.SelectedValue.ToString().Trim());                            
                            DateTime FechaHoraRegistro = CompraUtilidadesCLN.ObtenerFechaHoraServidor();                            
                            string Observaciones = "La Correspondiente Cuenta por Pagar hace referencia al Numero de Orden de Compra " + NumeroCompraProducto.ToString();
                            FCuentasPorPagarNuevo _FCuentasPorPagarNuevo = new FCuentasPorPagarNuevo(this.CodigoUsuario, NumeroAgencia, true, true, true, true, true);
                            _FCuentasPorPagarNuevo.cargarDatosParaCompraACredito("COMPRA A CREDITO", CodigoProveedor, CodigoMonedaSistema, montoEfectivo, montoDeuda, Observaciones);


                            //if (montoEfectivo == 0 &&
                            //    MessageBox.Show(this, "Se iniciará una cuenta por Cobrar con un saldo de pago nulo" + Environment.NewLine + "¿Esta de seguro de continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            //    return;
                            //else 
                            if (montoDeuda <= 0)
                            {
                                if (MessageBox.Show(this, "No puede Iniciar una Compra a Credito, por la cual el monto efectivo de pago superá al total de Pago" + Environment.NewLine + "Esta Compra debería ser en Efectivo" + Environment.NewLine + "Desea convertir la compra en una en Efectivo", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    rBtnEfectivo.Checked = true;
                                }
                                else
                                {
                                    MessageBox.Show("No puede continuar la Compra en este estado");                                    
                                }
                                return;
                            }

                            try
                            {
                                
                                if (TipoOperacion == "N")
                                {
                                    if (_FCuentasPorPagarNuevo.ShowDialog() == DialogResult.OK)
                                    {
                                        NumeroCuentaPorPagar = CompraUtilidadesCLN.ObtenerUltimoIndiceTabla("CuentasPorPagar");
                                        MessageBox.Show(this, "Se registro satisfactoriamente una nueva Cuenta por Cobrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se puedo ingresar satisfactoriamente la cuenta por Pagar");
                                        return;
                                    }
                                }
                                else if (TipoOperacion == "E")
                                {
                                    if (int.TryParse(_DTComprasProductos.Rows[0]["NumeroCuentaPorPagar"].ToString(), out NumeroCuentaPorPagar))
                                    {
                                        if (!_comprasUtilidadesCLN.ActualizarMontoDeudaCuentaPorPagar(NumeroAgencia, NumeroCuentaPorPagar, montoDeuda))
                                        {
                                            MessageBox.Show("No se puedo Actualizar satisfactoriamente la cuenta por Pagar");                                            
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (_FCuentasPorPagarNuevo.ShowDialog() == DialogResult.OK)
                                        {
                                            NumeroCuentaPorPagar = CompraUtilidadesCLN.ObtenerUltimoIndiceTabla("CuentasPorPagar");
                                            MessageBox.Show(this, "Se registro satisfactoriamente una nueva Cuenta por Cobrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se puedo ingresar satisfactoriamente la cuenta por Pagar");
                                            return;
                                        }
                                    }                                    
                                }                                                              
                                
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("No se puedo ingresar satisfactoriamente la cuenta por Pagar, Se cancelará la Transacción");
                                return;
                            }
                        }
                    }
                    else if (rBtnEfectivo.Checked && TipoOperacion =="E"
                        && _DTComprasProductos.Rows.Count > 0 && _DTComprasProductos.Rows[0]["NumeroCuentaPorPagar"] != null
                        && int.TryParse(_DTComprasProductos.Rows[0]["NumeroCuentaPorPagar"].ToString(), out NumeroCuentaPorPagar))
                    {
                        //eliminar la cuenta por pagar
                        try
                        {
                            _CuentasPorPagarCLN.EliminarCuentaPorPagar(NumeroCuentaPorPagar);
                            NumeroCuentaPorPagar = -1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, "No se puede eliminar la cuenta por Pagar " + NumeroCuentaPorPagar.ToString() + ", probablemente"
                                + "ya se realizarón operaciones sobre la misma u ocurrio la siguiente excepcion "+  ex.Message +".\r\nSe Cancelará la Modificación de la Orden de Compra", "Cuentas Por Pagar",
                                MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;    
                        }
                    }

                    try
                    {
                        

                        if (TipoOperacion == "N")
                        {
                            //si no existió ningun error, se Procede a registrar la Compra
                            //HABILITAR TODO ESTE SECTOR DE CODIGO EN CASO DE QUE YA NO SE UTILIZE LA INSERCION DEL DETALLE MEDIANTE EL USO DE XML
                            //decimal precioTotal = decimal.Parse(_DTComprasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString());
                            //precioTotal = decimal.Parse(_DTComprasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString());
                            //if (NumeroCuentaPorPagar == -1)
                            //    CompraProductosCLN.InsertarCompraProducto(NumeroAgencia, Int32.Parse(cBoxProveedor.SelectedValue.ToString().Trim()), CodigoUsuario, CompraUtilidadesCLN.ObtenerFechaHoraServidor(), tipoCompra.ToString(), "I", checkConFactura.Checked ? "F" : "S", precioTotal, null, txtBoxObservaciones.Text);
                            //else
                            //    CompraProductosCLN.InsertarCompraProducto(NumeroAgencia, Int32.Parse(cBoxProveedor.SelectedValue.ToString().Trim()), CodigoUsuario, CompraUtilidadesCLN.ObtenerFechaHoraServidor(), tipoCompra.ToString(), "P", checkConFactura.Checked ? "F" : "S", precioTotal, NumeroCuentaPorPagar, txtBoxObservaciones.Text);
                            //bdSourceComprasProductosDetalle.MoveFirst();
                            //foreach (DataRow fila in this._DTComprasProductosDetalleTemporal.Rows)
                            //{
                            //    //si el producto no es Agregado
                            //    if (!fila[7].Equals(true)) ///MUCHO OJO CON ESTA CONDICIÓN, SI ES NECESARIO VALIDARLA!! OJO OJO
                            //        CompraProductosDetalleCLN.InsertarCompraProductoDetalle(NumeroAgencia, numeroCompra, fila[0].ToString(), Int32.Parse(fila[2].ToString()), Decimal.Parse(fila[3].ToString()), 1);
                            //    bdSourceComprasProductosDetalle.MoveNext();

                            //}

                            

                            decimal precioTotal = decimal.Parse(_DTComprasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString());
                            precioTotal = decimal.Parse(_DTComprasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString());
                            if (NumeroCuentaPorPagar == -1)
                                CompraProductosCLN.InsertarCompraProductoXMLDetalle(NumeroAgencia, Int32.Parse(cBoxProveedor.SelectedValue.ToString().Trim()), CodigoUsuario, 
                                    null, null, checkImportacion.Checked ? (DateTime?)dtPickerFechaHoraPlazoDeRecepcion.Value : null , null, null, 
                                    CompraUtilidadesCLN.ObtenerFechaHoraServidor(), tipoCompra.ToString(), "I", checkConFactura.Checked ? "F" : "S", precioTotal, 
                                    null, String.IsNullOrEmpty(txtBoxNombreCompletoPersonaRecojo.Text.Trim()) ? null : txtBoxDIPersonaRecojo.Text,
                                    checkImportacion.Checked ? (DateTime?)dtPickerFechaEnvioMercaderia.Value : null, 
                                    string.IsNullOrEmpty(txtBoxMontoIVAFactura.Text.Trim()) ? null : (decimal?)decimal.Parse(txtBoxMontoIVAFactura.Text),
                                    txtBoxNumeroFactura.Text, txtBoxNroAutorizacionFactura.Text, txtBoxCodigoControlFactura.Text,
                                    checkImportacion.Checked, checkIngresoDirecto.Checked,
                                    cBoxMediosTransporte.SelectedValue != null ? byte.Parse(cBoxMediosTransporte.SelectedValue.ToString()) : (byte?)null, null, null,
                                    cBoxOrigenMercaderia.SelectedValue != null ? byte.Parse(cBoxOrigenMercaderia.SelectedValue.ToString()) : (byte?)null, 
                                    String.IsNullOrEmpty(txtBoxNroGuia.Text.Trim()) ? null : txtBoxNroGuia.Text, 2, 
                                    null, txtBoxObservaciones.Text, ProductosDetalleXML);
                            else
                                CompraProductosCLN.InsertarCompraProductoXMLDetalle(NumeroAgencia, Int32.Parse(cBoxProveedor.SelectedValue.ToString().Trim()), CodigoUsuario,
                                    null, null, checkImportacion.Checked ? (DateTime?)dtPickerFechaHoraPlazoDeRecepcion.Value : null, null, null, 
                                    CompraUtilidadesCLN.ObtenerFechaHoraServidor(), tipoCompra.ToString(), 
                                    montoEfectivo > 0 ? "I" : "P", checkConFactura.Checked ? "F" : "S", precioTotal,
                                    null, String.IsNullOrEmpty(txtBoxNombreCompletoPersonaRecojo.Text.Trim()) ? null : txtBoxDIPersonaRecojo.Text,
                                    checkImportacion.Checked ? (DateTime?)dtPickerFechaEnvioMercaderia.Value : null, 
                                    string.IsNullOrEmpty(txtBoxMontoIVAFactura.Text.Trim()) ? null : (decimal?)decimal.Parse(txtBoxMontoIVAFactura.Text),
                                    txtBoxNumeroFactura.Text, txtBoxNroAutorizacionFactura.Text, txtBoxCodigoControlFactura.Text,
                                    checkImportacion.Checked, checkIngresoDirecto.Checked,
                                    cBoxMediosTransporte.SelectedValue != null ? byte.Parse(cBoxMediosTransporte.SelectedValue.ToString()) : (byte?)null, null, null,
                                    cBoxOrigenMercaderia.SelectedValue != null ? byte.Parse(cBoxOrigenMercaderia.SelectedValue.ToString()) : (byte?)null,
                                    String.IsNullOrEmpty(txtBoxNroGuia.Text.Trim()) ? null : txtBoxNroGuia.Text, 2, 
                                    NumeroCuentaPorPagar, txtBoxObservaciones.Text, ProductosDetalleXML);                            
                        }

                        else if (TipoOperacion == "E")
                        {
                            decimal precioTotal = decimal.Parse(_DTComprasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString());
                            if (NumeroCuentaPorPagar == -1 || NumeroCuentaPorPagar == 0)
                                CompraProductosCLN.ActualizarCompraProducto(NumeroAgencia, NumeroCompraProducto, int.Parse(cBoxProveedor.SelectedValue.ToString().Trim()), CodigoUsuario,
                                     null, null, checkImportacion.Checked ? (DateTime?)dtPickerFechaHoraPlazoDeRecepcion.Value : null, null, null, 
                                    CompraUtilidadesCLN.ObtenerFechaHoraServidor(), tipoCompra.ToString(), "I", checkConFactura.Checked ? "F" : "S", precioTotal, null,
                                    null, String.IsNullOrEmpty(txtBoxNombreCompletoPersonaRecojo.Text.Trim()) ? null : txtBoxDIPersonaRecojo.Text,
                                    checkImportacion.Checked ? (DateTime?)dtPickerFechaEnvioMercaderia.Value : null, 
                                    string.IsNullOrEmpty(txtBoxMontoIVAFactura.Text.Trim()) ? null : (decimal?)decimal.Parse(txtBoxMontoIVAFactura.Text),
                                    txtBoxNumeroFactura.Text, txtBoxNroAutorizacionFactura.Text, txtBoxCodigoControlFactura.Text,
                                    checkImportacion.Checked, checkIngresoDirecto.Checked,
                                    cBoxMediosTransporte.SelectedValue != null ? byte.Parse(cBoxMediosTransporte.SelectedValue.ToString()) : (byte?)null, null, null,
                                    cBoxOrigenMercaderia.SelectedValue != null ? byte.Parse(cBoxOrigenMercaderia.SelectedValue.ToString()) : (byte?)null,
                                    String.IsNullOrEmpty(txtBoxNroGuia.Text.Trim()) ? null : txtBoxNroGuia.Text, 2, 
                                    txtBoxObservaciones.Text);
                            else
                                CompraProductosCLN.ActualizarCompraProducto(NumeroAgencia, NumeroCompraProducto, int.Parse(cBoxProveedor.SelectedValue.ToString().Trim()), CodigoUsuario,
                                     null, null, checkImportacion.Checked ? (DateTime?)dtPickerFechaHoraPlazoDeRecepcion.Value : null, null, null, 
                                    CompraUtilidadesCLN.ObtenerFechaHoraServidor(), tipoCompra.ToString(),
                                    montoEfectivo > 0 ? "I" : "P", checkConFactura.Checked ? "F" : "S", precioTotal, NumeroCuentaPorPagar,
                                    null, String.IsNullOrEmpty(txtBoxNombreCompletoPersonaRecojo.Text.Trim()) ? null : txtBoxDIPersonaRecojo.Text,
                                    checkImportacion.Checked ? (DateTime?)dtPickerFechaEnvioMercaderia.Value : null, 
                                    string.IsNullOrEmpty(txtBoxMontoIVAFactura.Text.Trim()) ? null : (decimal?)decimal.Parse(txtBoxMontoIVAFactura.Text),
                                    txtBoxNumeroFactura.Text, txtBoxNroAutorizacionFactura.Text, txtBoxCodigoControlFactura.Text,
                                    checkImportacion.Checked, checkIngresoDirecto.Checked,
                                    cBoxMediosTransporte.SelectedValue != null ? byte.Parse(cBoxMediosTransporte.SelectedValue.ToString()) : (byte?)null, null, null,
                                    cBoxOrigenMercaderia.SelectedValue != null ? byte.Parse(cBoxOrigenMercaderia.SelectedValue.ToString()) : (byte?)null,
                                    String.IsNullOrEmpty(txtBoxNroGuia.Text.Trim()) ? null : txtBoxNroGuia.Text, 2,  
                                    txtBoxObservaciones.Text);

                            //string ListadoCodigoProducto = "";
                            foreach (DataRow fila in this._DTComprasProductosDetalleTemporal.Rows)
                            {
                                //si el producto no es Agregado
                                if (!fila[7].Equals(true)) ///MUCHO OJO CON ESTA CONDICIÓN, SI ES NECESARIO VALIDARLA!! OJO OJO
                                    CompraProductosDetalleCLN.InsertarCompraProductoDetalle(NumeroAgencia, NumeroCompraProducto, fila[0].ToString(), Int32.Parse(fila[2].ToString()), Decimal.Parse(fila[3].ToString()), 1);

                                //ListadoCodigoProducto += "''" + fila["Código Producto"].ToString().Trim() + " '' ,";
                            }

                            //ListadoCodigoProducto = "'" +ListadoCodigoProducto.Substring(0, ListadoCodigoProducto.Length - 2) + "'";

                            //CompraProductosCLN.EliminarCompraProductoDetalleDesdeListado(NumeroAgencia, numeroCompra, ListadoCodigoProducto);

                            string CodigoProducto = "";
                            foreach (DataRow FilaAntigua in _DTComprasProductosDetalle.Rows)  
                            {
                                CodigoProducto = FilaAntigua["CodigoProducto"].ToString().Trim();
                                if (_DTComprasProductosDetalleTemporal.Rows.Find(CodigoProducto) == null) 
                                {
                                    CompraProductosDetalleCLN.EliminarCompraProductoDetalle(NumeroAgencia, NumeroCompraProducto, FilaAntigua["CodigoProducto"].ToString());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio el Siguiente Error" + ex.Message +". "+Environment.NewLine + "Consulte con su Administrador");                        
                    }


                    //aumentamos opciones para actualizar los precios de Venta, Porcentaje _DTComprasProductosDetalleTemporal
                    if(checkActualizarPrecios.Checked) actualizarPreciosVenta();

                    MessageBox.Show(this, "Se realizó correctamente el pedido de Orden de Compra", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reciboToolStripMenuItem_Click(sender, e);
                    NumeroCompraProducto = CompraUtilidadesCLN.ObtenerUltimoIndiceTabla("ComprasProductos");
                    cargarDatosCompras(NumeroCompraProducto);
                    cBoxProveedor.Focus();                    
                    dGVProductosEspecificos.EndEdit();
                    TipoOperacion = "";
                    this.checkVerCodEspecificos.Checked = false;
                    //Esta Opción se quita porque el formulario ha sido Divido en tres partes, habilitar en caso de que solo el formulario se encargue
                    //de todas la operacion
                    //btnFinalizar_Click(sender, e);
                    
                    
                    

                    
                }
                else
                {
                    if (MessageBox.Show(this, "No Puede Realizar Esta Transacción sin Haber por lo Menos Seleccionado una Producto para Compralo. "+Environment.NewLine+" ¿Desea Agregar Productos a la Venta Actual?", "Verifique la Venta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        fProductosBusqueda.ShowDialog(this);
                    }
                    else
                    {
                        NumeroCompraProducto = CompraUtilidadesCLN.ObtenerUltimoIndiceTabla("ComprasProductos");
                        cargarDatosCompras(NumeroCompraProducto);
                    }
                }
            }
            else
            {
                if (_DTProveedores.Rows.Count == 0)
                {
                    MessageBox.Show("Aun no tiene registrado ningún Proveedor");
                }
                cBoxProveedor_Leave(sender, e);
            }
        }

        /// <summary>
        /// Ocurre cuando se Va navegando Las Compras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdSourceComprasProductos_CurrentChanged(object sender, EventArgs e)
        { 
            //if (_DTComprasProductosDetalle.Rows.Count > 0 && _DTComprasProductosDetalle.Columns.Count > 7 && bdSourceComprasProductos.Position != -1)
            //{
            //    string filtro = "NumeroAgencia = " + NumeroAgencia.ToString() + " and  NumeroCompraProducto = " + _DTComprasProductos.Rows[bdSourceComprasProductos.Position][1].ToString();
            //    detallePrecioTotal = _DTComprasProductosDetalle.Compute("sum(PrecioTotal)", filtro);
            //    if (detallePrecioTotal.ToString().Length > 0)
            //        txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " "+MascaraMonedaSistema;
            //    else
            //        txtBoxPrecioTotal.Text = " 0.00 "+MascaraMonedaSistema;

            //    lblNumeroCompra.Text = _DTComprasProductos.Rows[bdSourceComprasProductos.Position][1].ToString();
            //    if (_DTComprasProductos.Rows[bdSourceComprasProductos.Position]["CodigoEstadoCompra"].ToString().CompareTo("F") == 0)
            //    {
            //        lblEstado.Text = "Finalizada";
            //        toolStripPBEstado.Value = toolStripPBEstado.Maximum;
            //        //habilitarBotonesCompras(true, false, false, false, false, false,false,false, true, true);
            //        habilitarBotonesCompras(true, false, false, false, false, false, true, true);
            //        habilitarCampos(false);
            //    }
            //    if (_DTComprasProductos.Rows[bdSourceComprasProductos.Position]["CodigoEstadoCompra"].ToString().CompareTo("X") == 0)
            //    {
            //        lblEstado.Text = "Finalizada Incompleta";
            //        toolStripPBEstado.Value = toolStripPBEstado.Maximum;
            //        //habilitarBotonesCompras(true, false, false, false, false, false,false,false, true, true);
            //        habilitarBotonesCompras(true, false, false, false, false, false, true, true);
            //        habilitarCampos(false);
            //    }

            //    if (_DTComprasProductos.Rows[bdSourceComprasProductos.Position]["CodigoEstadoCompra"].ToString().CompareTo("C") == 0)
            //    {
            //        lblEstado.Text = "Cancelada";
            //        toolStripPBEstado.Value = toolStripPBEstado.Maximum;
            //        //habilitarBotonesCompras(true, false, false, false, false, false, true, true);
            //        habilitarBotonesCompras(true, false, false, false, false, false, true, true);
            //        habilitarCampos(false);
            //    }
            //    if (_DTComprasProductos.Rows[bdSourceComprasProductos.Position]["CodigoEstadoCompra"].ToString().CompareTo("I") == 0)
            //    {
            //        lblEstado.Text = "Iniciada";
            //        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3;
                    
            //        //Tomar en cuenta que ahora la finalización se hace desde otra interfaz
            //        //en caso de que todo se tenga que hacer desde una misma interfaz, habilitar 
            //        //el botón de finalización
            //        habilitarBotonesCompras(true, true, false, true, false, false, true, true);
            //        habilitarCampos(false);
            //    }
            //    if (_DTComprasProductos.Rows[bdSourceComprasProductos.Position]["CodigoEstadoCompra"].ToString().CompareTo("A") == 0)
            //    {
            //        lblEstado.Text = "Anulada";
            //        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 2;
            //        habilitarBotonesCompras(true, false, false, false, false, false, true, true);
            //        habilitarCampos(false);
            //    }
            //    if (_DTComprasProductos.Rows[bdSourceComprasProductos.Position]["CodigoEstadoCompra"].ToString().CompareTo("D") == 0)
            //    {
            //        lblEstado.Text = "Pendiente de Recepción (En Transito)";
            //        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3 + toolStripPBEstado.Maximum / 3;
            //        habilitarBotonesCompras(true, false, false, false, false, false, true, true);
            //        habilitarCampos(false);
            //    }
            //    if (_DTComprasProductos.Rows[bdSourceComprasProductos.Position]["CodigoEstadoCompra"].ToString().CompareTo("P") == 0)
            //    {
            //        bool estadoEdicionCredito = false;
            //        lblEstado.Text = !string.IsNullOrEmpty(_DTComprasProductos.Rows[0]["NumeroCuentaPorPagar"].ToString()) ? "Pagada a CREDITO" :"Pagada";
            //        if (_DTComprasProductos.Rows[0]["NumeroCuentaPorPagar"] != null)
            //        {
            //            estadoEdicionCredito = new ComprasProductosDetalleEntregaCLN().ListarComprasProductosDetalleEntregaParaRecepcion(NumeroAgencia, numeroCompra).Rows.Count == 0;
            //        }

            //        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 2;
            //        habilitarBotonesCompras(true, estadoEdicionCredito, false, false, false, false, true, true);
            //        habilitarCampos(false);
            //    }
            //}
            //else
            //{
            //    txtBoxPrecioTotal.Text = " 0.00 "+MascaraMonedaSistema;
            //}
            //if (bdSourceComprasProductos.Position != -1 && _DTComprasProductos.Rows.Count > 0 && string.IsNullOrEmpty(TipoOperacion))
            //{
            //    cBoxProveedor.SelectedValue = _DTComprasProductos.Rows[bdSourceComprasProductos.Position]["CodigoProveedor"].ToString();
            //    if (_DTComprasProductos.Rows[bdSourceComprasProductos.Position]["CodigoTipoCompra"].ToString().CompareTo("E") == 0)
            //        rBtnEfectivo.Checked = true;
            //    else
            //        rBtnCredito.Checked = true;

                

            //    toolStripFechaCompra.Text = _DTComprasProductos.Rows[bdSourceComprasProductos.Position]["Fecha"].ToString();
            //    txtBoxObservaciones.Text = _DTComprasProductos.Rows[bdSourceComprasProductos.Position]["Observaciones"].ToString();
            //    cBoxComprador.SelectedValue = _DTComprasProductos.Rows[bdSourceComprasProductos.Position]["CodigoUsuario"].ToString();
            //    checkConFactura.Checked = _DTComprasProductos.Rows[bdSourceComprasProductos.Position]["CodigoEstadoFactura"].ToString().Equals("F");
            //    cBoxProveedor.SelectedValue = _DTComprasProductos.Rows[bdSourceComprasProductos.Position]["CodigoProveedor"];
            //    dtPickerPlazoEntrega.Value = !String.IsNullOrEmpty(_DTComprasProductos.Rows[bdSourceComprasProductos.Position]["FechaHoraPlazoDeRecepcion"].ToString()) ? DateTime.Parse(_DTComprasProductos.Rows[bdSourceComprasProductos.Position]["FechaHoraPlazoDeRecepcion"].ToString()) : DateTime.Now;

            //    toolStripFechaCompra.Text = _DTComprasProductos[0].Fecha.ToString("dd/MM/yyyy");
            //    txtBoxObservaciones.Text = _DTComprasProductos[0].IsObservacionesNull() ? "" : _DTComprasProductos[0].Observaciones;
            //    cBoxComprador.SelectedValue = _DTComprasProductos[0].CodigoUsuario;
            //    checkConFactura.Checked = _DTComprasProductos[0].CodigoEstadoFactura.CompareTo("F") == 0;
            //    cBoxProveedor.SelectedValue = dt
            //}
            //else
            //{
            //    habilitarCampos(false);
            //    habilitarBotonesCompras(true, false, false, false, false, false, true, true);
            //}
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(this, "La finalización de una tranzacción de compra implica la recepción física" + Environment.NewLine + "definitiva de los productos por el correspondiente responsable. " + Environment.NewLine + "Así mismo al finalizar una compra ya no se podrá alterar ningun aspecto de la misma" + Environment.NewLine + Environment.NewLine + "¿Desea Finalizar la Compra de Productos?", "Compra de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                int NumeroCompraProducto = Int16.Parse(_DTComprasProductos.Rows[bdSourceComprasProductos.Position][1].ToString());
                //CompraProductosCLN.ActualizarCompraProducto(NumeroAgencia, NumeroCompraProducto, Int16.Parse(cBoxProveedor.SelectedValue.ToString()), CodigoUsuario, CompraUtilidadesCLN.ObtenerFechaHoraServidor(), tipoCompra.ToString(), "F", Decimal.Parse(this.txtBoxPrecioTotal.Text.Replace('B', ' ').Replace('s', ' ').Trim()), txtBoxObservaciones.Text);
                CompraProductosCLN.ActualizarCodigoEstadoCompra(NumeroAgencia, NumeroCompraProducto, "F", null);
                CompraUtilidadesCLN.ActualizarInventarioProductosCompras(NumeroAgencia, NumeroCompraProducto, null);
                //Ingresamos los Productos Especificos
                if (_DTProductosEspecificosTemporal.Rows.Count > 0)
                {
                    dGVProductosEspecificos.EndEdit();                    
                    int[] cantidadesCompradas = new int[_DTComprasProductosDetalleTemporal.Rows.Count];
                    for (int i = 0; i < cantidadesCompradas.Length; i++)
                        cantidadesCompradas[i] = Int32.Parse(_DTComprasProductosDetalleTemporal.Rows[i][2].ToString());
                    //Variables de Control
                    int contador = 0;
                    int contadorEnReparacion = 0;
                    int indiceProductos = 0;
                    int cantidadComprada = 0;
                    bool esOtroProducto = false;

                    string CodigoProducto = "";


                    string NombreProducto = "";
                    string CodigoProductoTemporal = "";
                    string CodigoProductoEspecifico = "";
                    int TiempoGarantiaPE = 0;
                    DateTime FechaHoraVencimientoPE = DateTime.Now;
                    string CodigoEstado = "A";

                    DateTime FechaHoraRececion = CompraUtilidadesCLN.ObtenerFechaHoraServidor();
                    for (int i = 0; i < _DTProductosEspecificosTemporal.Rows.Count; i++)
                    {
                        DataRow fila = _DTProductosEspecificosTemporal.Rows[i];

                        NombreProducto = fila[0].ToString();
                        CodigoProductoTemporal = fila[1].ToString();
                        CodigoProductoEspecifico = fila[2].ToString();
                        TiempoGarantiaPE = Int32.Parse(fila[3].ToString());
                        FechaHoraVencimientoPE = DateTime.Parse(fila[4].ToString());
                        CodigoEstado = fila[5].ToString();
                        if (CodigoProductoTemporal != "")
                        {
                            if (cantidadComprada == contador && contadorEnReparacion != 0 && esOtroProducto) // existe algun producto Especifico que se compro pero no esta disponible porque se pondra en reparación
                            {
                                InventarioProductoCLN.ActualizarCantidadExistenciaEnInventarios(NumeroAgencia, CodigoProducto, contadorEnReparacion, false);
                            }
                            CodigoProducto = CodigoProductoTemporal;
                            contador = 0;
                            contadorEnReparacion = 0;
                            cantidadComprada = cantidadesCompradas[indiceProductos];
                            indiceProductos++;
                            esOtroProducto = true;
                        }
                        if (CodigoEstado.CompareTo("R") == 0) //si se pondra en Reparación
                            contadorEnReparacion++;
                        CompraProductosEspecificosCLN.InsertarCompraProductoEspecifico(NumeroAgencia, NumeroCompraProducto, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPE, FechaHoraVencimientoPE, FechaHoraRececion);
                        InventarioProductoEspecificoCLN.InsertarInventarioProductoEspecifico(NumeroAgencia, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPE, FechaHoraVencimientoPE, "C", CodigoEstado);
                        contador++;
                    }
                    if (cantidadComprada == contador && contadorEnReparacion != 0 && esOtroProducto) // existe algun producto Especifico que se compro pero no esta disponible porque se pondra en reparación
                    {
                        InventarioProductoCLN.ActualizarCantidadExistenciaEnInventarios(NumeroAgencia, CodigoProducto, contadorEnReparacion, false);
                    }
                }
                
                if (_DTProductosEspecificosAgregadosTemporal.Rows.Count > 0)
                {
                    dtGVCompraProductosAgregados.EndEdit();
                    string CodigoProducto = "";


                    string NombreProducto = "";
                    string CodigoProductoTemporal = "";
                    string CodigoProductoEspecifico = "";
                    string CodigoTipoAgregado = "O";
                    int TiempoGarantiaPE = 0;
                    DateTime FechaHoraVencimientoPE = DateTime.Now;
                    bool CargarAInventario = false;
                    decimal PrecioUnitario = 0;

                    foreach (DataGridViewRow fila in dtGVCompraProductosAgregados.Rows)
                    {
                        NombreProducto = fila.Cells[0].Value.ToString();
                        CodigoProductoTemporal = fila.Cells[1].Value.ToString();
                        CodigoProductoEspecifico = fila.Cells[2].Value.ToString();
                        CodigoTipoAgregado = fila.Cells[3].Value.ToString();
                        TiempoGarantiaPE = Int32.Parse(fila.Cells[4].Value.ToString());
                        FechaHoraVencimientoPE = DateTime.Parse(fila.Cells[5].Value.ToString());
                        PrecioUnitario = Decimal.Parse(fila.Cells[6].Value.ToString());
                        CargarAInventario = fila.Cells[7].Value.Equals(true) ? true : false;

                        if (CodigoProductoTemporal != "")
                        {
                            CodigoProducto = CodigoProductoTemporal;
                        }
                        CompraProductoEspecificoAgregadoCLN.InsertarCompraProductoEspecificoAgregado(NumeroAgencia, NumeroCompraProducto, CodigoProducto, CodigoProductoEspecifico, CodigoTipoAgregado, TiempoGarantiaPE, FechaHoraVencimientoPE, CargarAInventario, PrecioUnitario);
                        if (CargarAInventario)
                        {
                            InventarioProductoCLN.ActualizarCantidadExistenciaEnInventarios(NumeroAgencia, CodigoProducto, 1, true);
                            InventarioProductoEspecificoCLN.InsertarInventarioProductoEspecifico(NumeroAgencia, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPE, FechaHoraVencimientoPE, "C", "A");
                        }
                            
                    }

                }

                int indiceActual = bdSourceComprasProductos.Position;
                NumeroCompraProducto = CompraUtilidadesCLN.ObtenerUltimoIndiceTabla("ComprasProductos");
                cargarDatosCompras(NumeroCompraProducto);
                bdSourceComprasProductos.Position = indiceActual;
                //habilitarBotonesCompras(true, false, false, false, false, false, false, false, true, true);
            }
        }

        private void rBtnCredito_CheckedChanged(object sender, EventArgs e)
        {
            tipoCompra = 'R';
            if (NumeroCredito == -1)
            {
                //Formulario de Busqueda para los Creditos
            }
            visualizarDatosPagosPorCompra();
            txtBoxMontoEfectivo.Focus();
        }

        private void rBtnEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            tipoCompra = 'E';
            visualizarDatosPagosPorCompra();
        }


        public void visualizarDatosPagosPorCompra()
        {
            lblMontoDeuda.Visible =
            lblMontoEfectivo.Visible =
            txtBoxMontoDeuda.Visible =
            txtBoxMontoEfectivo.Visible =
                tipoCompra.ToString().CompareTo("R") == 0;
            

            if (TipoOperacion == "N")
            {
                txtBoxMontoDeuda.Text = "0,00";
                txtBoxMontoEfectivo.Text = txtBoxPrecioTotal.Text;
            }            
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se encuentra seguro de Anular la Orden de Compra Actual?", "Anulación de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            int indiceActual = bdSourceComprasProductos.Position;
            //CompraProductosCLN.ActualizarVentaProducto(_NumeroAgencia, Int16.Parse(_DTComprasProductos.Rows[indiceActual][1].ToString()), cBoxCliente.SelectedValue.ToString().Trim(), null, VentaUtilidadesCLN.ObtenerFechaHoraServidor(), tipoVenta.ToString(), "A", null, txtBoxObservaciones.Text);
            //CompraProductosCLN.ActualizarCompraProducto(NumeroAgencia, Int16.Parse(_DTComprasProductos.Rows[indiceActual][1].ToString()), Int16.Parse(cBoxProveedor.SelectedValue.ToString()), CodigoUsuario, CompraUtilidadesCLN.ObtenerFechaHoraServidor(), tipoCompra.ToString(), "A", 10, txtBoxObservaciones.Text);
            CompraProductosCLN.ActualizarCodigoEstadoCompra(NumeroAgencia, NumeroCompraProducto, "A", null);
            NumeroCompraProducto = CompraUtilidadesCLN.ObtenerUltimoIndiceTabla("ComprasProductos");
            cargarDatosCompras(NumeroCompraProducto);
            bdSourceComprasProductos.Position = indiceActual;
        }

        private void dGVProductosSeleccionados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btnNuevaCompra.Enabled)
                    btnNuevaCompra_Click(sender, e as EventArgs);
                else
                    MessageBox.Show(this, "No Puede Iniciar una Compra, sin haber concluido la que se lleva en curso", "Compra de Productos no Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (btnAceptar.Enabled)
                    btnAceptar_Click(sender, e as EventArgs);
                else
                    MessageBox.Show(this, "No Puede Aceptar una nueva Compra, sin haberla inciado", "Compra de Productos no Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Control && e.KeyCode == Keys.F)
            {
                if (btnFinalizar.Enabled)
                    btnFinalizar_Click(sender, e as EventArgs);
                else
                    MessageBox.Show(this, "No Puede Aceptar una nueva Compra, sin haberla inciado", "Compra de Productos no Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {


            if (btnNuevaCompra.Enabled)
            {
                //txtBoxObservaciones.Enabled = true;
                habilitarCampos(true);
                //btnBuscarProveedor.Enabled = true;
                //btnRegistrarProveedor.Enabled = true;
                TipoOperacion = "E";
                int indice = 0;

                this._DTComprasProductosDetalleTemporal = fProductosBusqueda.DTProductosSeleccionados;

                CodigoTipoCompra = _DTComprasProductos.Rows[0]["CodigoTipoCompra"].ToString();
                _DTComprasProductosDetalleTemporal.Clear();
                foreach (DataRow FilaNueva in _DTComprasProductosDetalle.Rows)
                {
                    DataRow FilaProducto = _DTComprasProductosDetalleTemporal.NewRow();
                    FilaProducto["Código Producto"] = FilaNueva["CodigoProducto"];
                    FilaProducto["Nombre Producto"] = FilaNueva["NombreProducto"];
                    FilaProducto["Cantidad"] = FilaNueva["CantidadCompra"];
                    FilaProducto["Precio"] = FilaNueva["PrecioUnitarioCompra"];
                    FilaProducto["PrecioTotal"] = Decimal.Round(int.Parse(FilaNueva["CantidadCompra"].ToString()) * decimal.Parse(FilaNueva["PrecioUnitarioCompra"].ToString()), 2);
                    FilaProducto["Garantia"] = FilaNueva["TiempoGarantiaCompra"];
                    FilaProducto["EsProductoEspecifico"] = CompraUtilidadesCLN.esProductoEspecifico(NumeroAgencia, FilaNueva["CodigoProducto"].ToString());
                    FilaProducto["VendidoComoAgregado"] = false;
                    FilaProducto["CantidadExistencia"] = CompraUtilidadesCLN.ObtenerExistenciaProductoInventario(NumeroAgencia, FilaNueva["CodigoProducto"].ToString());
                    //FilaProducto["CantidadEntregada"] = FilaNueva["CantidadEntregada"];
                    FilaProducto["CantidadEntregada"] = 0;
                    //FilaProducto["PorcentajeDescuento"] = FilaNueva["PorcentajeDescuento"];
                    FilaProducto["PorcentajeDescuento"] = 0;
                    //FilaProducto["NumeroPrecioSeleccionado"] = FilaNueva["NumeroPrecioSeleccionado"];
                    FilaProducto["NumeroPrecioSeleccionado"] = "1";
                    _DTComprasProductosDetalleTemporal.Rows.Add(FilaProducto);
                    indice++;
                }
                _DTComprasProductosDetalleTemporal.AcceptChanges(); 
                fProductosBusqueda.DTProductosSeleccionados = this._DTComprasProductosDetalleTemporal;
                fProductosBusqueda.BDSourceProductosSeleccionados.DataSource = fProductosBusqueda.DTProductosSeleccionados;                
                //fProductosBusqueda.DTGridViewProductosSeleccionados.DataSource = fProductosBusqueda.BDSourceProductosSeleccionados;
                fProductosBusqueda.nuevaVenta = false;
                fProductosBusqueda.ListaCodigosProductosEliminados.Clear();
                fProductosBusqueda.DTProductosBusqueda.Clear();
                // fProductosBusqueda.cargarPieDetalleResultado(); 
                formatearEstiloTabla(true);                
                bdSourceComprasProductos.DataSource = _DTComprasProductosDetalleTemporal;
                

                //if (checkBIncluirFactura.Checked)
                //{
                //    QuitarPrecioFactura(true);
                //    ventaConFactura = true;
                //}
                //else
                //    ventaConFactura = false;
                //checkBIncluirFactura.Enabled = true;                
            }

            _DTComprasProductosDetalleTemporal = fProductosBusqueda.DTProductosSeleccionados;
            bdSourceComprasProductosDetalle.DataSource = _DTComprasProductosDetalleTemporal;
            bdSourceComprasProductos.DataSource = fProductosBusqueda.DTProductosSeleccionados;
            formatearEstiloTabla(true);     

            fProductosBusqueda.ShowDialog(this);
            bdSourceComprasProductos.DataSource = fProductosBusqueda.DTProductosSeleccionados;
            CodigosGenerados = false;
            CodigosAgregadosGenerados = false;
            detallePrecioTotal = _DTComprasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "");
            if (detallePrecioTotal.ToString().Length > 0)
                txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " "+MascaraMonedaSistema;
            else
                txtBoxPrecioTotal.Text = " 0.00 "+MascaraMonedaSistema;
            crearItemsCodigo();
            habilitarBotonesCompras(false, true, true, false, true, false, false, false, false);
            habilitarCampos(true);
            DGCEsProductoEspecifico.Visible = checkVerCodEspecificos.Checked;
            if (rBtnCredito.Checked)
            {
                rBtnCredito.Checked = false;
                rBtnCredito.Checked = true;
            }
        }

        private void FComprasProductos_Shown(object sender, EventArgs e)
        {
            formatearEstiloTabla(false);            
        }

        private void bdSourceComprasProductos_CurrentChanged_1(object sender, EventArgs e)
        {
            //if (_DTComprasProductosDetalle.Rows.Count > 0 && _DTComprasProductosDetalle.Columns.Count > 6 && bdSourceComprasProductos.Position != -1)
            //{
            //    string filtro = "NumeroAgencia = " + NumeroAgencia.ToString() + " and  NumeroCompraProducto = " + _DTComprasProductos.Rows[bdSourceComprasProductos.Position][1].ToString();
            //    detallePrecioTotal = _DTComprasProductosDetalle.Compute("sum(PrecioTotal)", filtro);
            //    if (detallePrecioTotal.ToString().Length > 0)
            //        txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " "+MascaraMonedaSistema;
            //    else
            //        txtBoxPrecioTotal.Text = " 0.00 "+MascaraMonedaSistema;

            //    lblNumeroCompra.Text = _DTComprasProductos.Rows[bdSourceComprasProductos.Position][1].ToString();
            //    if (_DTComprasProductos.Rows[bdSourceComprasProductos.Position][6].ToString().CompareTo("F") == 0)
            //    {
            //        lblEstado.Text = "Finalizada";
            //        toolStripPBEstado.Value = toolStripPBEstado.Maximum;
            //        habilitarBotonesCompras(true, false, false, false, false, false,false,false);
            //        habilitarCampos(false);
            //    }
            //    if (_DTComprasProductos.Rows[bdSourceComprasProductos.Position][6].ToString().CompareTo("C") == 0)
            //    {
            //        lblEstado.Text = "Cancelada";
            //        toolStripPBEstado.Value = toolStripPBEstado.Maximum;
            //        habilitarBotonesCompras(true, false, false, false, false, false,false,false);
            //        habilitarCampos(false);
            //    }
            //    if (_DTComprasProductos.Rows[bdSourceComprasProductos.Position][6].ToString().CompareTo("I") == 0)
            //    {
            //        lblEstado.Text = "Iniciada";
            //        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 2;
            //        habilitarBotonesCompras(true, true, false, true, false, true,true,true);
            //        habilitarCampos(false);
            //    }
            //    if (_DTComprasProductos.Rows[bdSourceComprasProductos.Position][6].ToString().CompareTo("A") == 0)
            //    {
            //        lblEstado.Text = "Anulada";
            //        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 2;
            //        habilitarBotonesCompras(true, false, false, false, false, false,false,false);
            //        habilitarCampos(false);
            //    }
            //}
            //else
            //{
            //    txtBoxPrecioTotal.Text = " 0.00 "+MascaraMonedaSistema;
            //}
            //if (bdSourceComprasProductos.Position != -1 && _DTComprasProductos.Rows.Count > 0)
            //{
            //    cBoxProveedor.SelectedValue = _DTComprasProductos.Rows[bdSourceComprasProductos.Position][2].ToString();
            //    if (_DTComprasProductos.Rows[bdSourceComprasProductos.Position][4].ToString().CompareTo("E") == 0)
            //        rBtnEfectivo.Checked = true;
            //    else
            //        rBtnCredito.Checked = true;

            //    toolStripFechaCompra.Text = _DTComprasProductos.Rows[bdSourceComprasProductos.Position][3].ToString();
            //}
            //else
            //{
            //    habilitarCampos(false);
            //    habilitarBotonesCompras(true, false, false, false, false, false, false, false);
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _DTComprasProductosDetalleTemporal.Clear();
            _DTProductosEspecificosAgregadosTemporal.Clear();
            _DTProductosEspecificosTemporal.Clear();
            NumeroCompraProducto = CompraUtilidadesCLN.ObtenerUltimoIndiceTabla("ComprasProductos");
            cargarDatosCompras(NumeroCompraProducto);
            //habilitarBotonesCompras(true, false, false, false, false, false, false, false, true, true);
            
        }

        private void cBoxProveedor_Leave(object sender, EventArgs e)
        {
            if (cBoxProveedor.SelectedValue == null && _DTProveedores.Rows.Count != 0)
            {
                MessageBox.Show(this, "No puede Continuar la Compra actual, sin antes haber seleccionado" + Environment.NewLine + "un Proveedor. Porfavor Proceda a seleccionarlo", "Compras Productos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cBoxProveedor.Focus();
                if (cBoxProveedor.Items.Count > 0)
                    cBoxProveedor.SelectedIndex = 0;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FBuscarTransaccion formBuscarTransaccion = new FBuscarTransaccion(NumeroAgencia);
            formBuscarTransaccion.formatearEstiloParaCompras();
            formBuscarTransaccion.ShowDialog(this);
            NumeroCompraProducto = formBuscarTransaccion.NumeroTransaccion;
            cargarDatosCompras(NumeroCompraProducto);
            formBuscarTransaccion.Dispose();
        }

        private void toolStripbtnGenerarCodigos_Click(object sender, EventArgs e)
        {
            dGVProductosEspecificos.Visible = true;
            dGVProductosEspecificos.Dock = DockStyle.Fill;
            dGVProductosEspecificos.Height = AlturaDGVProductosEspecificos;

            dtGVCompraProductosEspecificos.Visible = false;
            dtGVCompraProductosEspecificos.Dock = DockStyle.None;
            dtGVCompraProductosEspecificos.Height = 0;

            _DTProductosEspecificosTemporal.Clear();
            InventariosProductosEspecificosCLN _InventarioProductosEspecificos = new InventariosProductosEspecificosCLN();
            bdSourceProductosEspecificos.DataSource = _DTProductosEspecificosTemporal;
            /*
            for (int indice = 4; indice < toolStripbtnOpciones.DropDownItems.Count; indice++)
            {
                DataGridViewRow fila = dGVProductosSeleccionados.Rows[indice - 4];
                if (((ToolStripMenuItem)toolStripbtnOpciones.DropDownItems[indice]).Checked && fila.Cells["VendidoComoAgregado"].Value.Equals(false))
                {
                    string codigoProducto = fila.Cells[0].Value.ToString().Trim();
                    string NombreProducto = fila.Cells["DGCNombreProductoDetalle"].Value.ToString().Trim(); 
                    int cantidadCompra = Int32.Parse(fila.Cells["DGCCantidadDetalle"].Value.ToString());
                    string codigosGenerados = _InventarioProductosEspecificos.ObtenerListadoCodigoProductoEspecificoGenerado(codigoProducto, cantidadCompra, tsTxtBoxComodin.Text.Trim(), "I");
                    string[] Listado_de_Codigos = codigosGenerados.Split(new char[] { ',' });//, StringSplitOptions.RemoveEmptyEntries);

                    string codigoExpecifico;
                    int tamanioComodin = tsTxtBoxComodin.Text.Trim().Length;
                    int tamanioCodigoProducto = codigoProducto.Trim().Length;
                    for (int i = 0; i < cantidadCompra; i++)
                    {
                        DataRow filaNueva = _DTProductosEspecificosTemporal.NewRow();
                        codigoExpecifico = Listado_de_Codigos[i + 1].Trim().Substring(tamanioCodigoProducto + tamanioComodin, 20 - (tamanioCodigoProducto + tamanioComodin));
                        //filaNueva[0] = codigoProducto.Trim() + tsTxtBoxComodin.Text.Trim() + codigoExpecifico.Trim();
                        if (i == 0)
                        {
                            filaNueva["NombreProducto"] = NombreProducto;
                            filaNueva["CodigoProducto"] = codigoProducto;
                        }
                        else
                        {
                            filaNueva["NombreProducto"] = "";
                            filaNueva["CodigoProducto"] = "";
                        }
                        filaNueva["CodigoProductoEspecifico"] = codigoProducto.Trim() + tsTxtBoxComodin.Text.Trim() + codigoExpecifico.Trim();
                        filaNueva["TiempoGarantiaPECompra"] = 0;
                        filaNueva["FechaHoraVencimientoPE"] = DateTime.Now.AddMonths(2);
                        filaNueva["CodigoEstado"] = "A";
                        _DTProductosEspecificosTemporal.Rows.Add(filaNueva);
                        filaNueva.AcceptChanges();
                    }
                }
            }
            CodigosGenerados = true;
            dGVProductosEspecificos.EndEdit();
            bdSourceProductosEspecificos.EndEdit();
             * 
             *  Volver Habilitar para generar los Productos Especificos 
             * 
             */
        }


        public void crearColumnasDTProductosEspecificos()
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

            DataColumn DCTiempoGarantia = new DataColumn();
            DCTiempoGarantia.DataType = Type.GetType("System.Int16");
            DCTiempoGarantia.DefaultValue = 0;
            DCTiempoGarantia.ColumnName = "TiempoGarantiaPECompra";

            DataColumn DCFechaValidez = new DataColumn();
            DCFechaValidez.DataType = Type.GetType("System.DateTime");
            DCFechaValidez.ColumnName = "FechaHoraVencimientoPE";
            DCFechaValidez.DefaultValue = DateTime.Now;


            DataColumn DCEstado = new DataColumn();
            DCEstado.DataType = Type.GetType("System.String");
            DCEstado.ColumnName = "CodigoEstado";
            DCEstado.DefaultValue = "A";

            _DTProductosEspecificosTemporal = new DataTable();

            _DTProductosEspecificosTemporal.Columns.Add(DCNombreProducto);
            _DTProductosEspecificosTemporal.Columns.Add(DCCodigoProducto);
            _DTProductosEspecificosTemporal.Columns.Add(DCCodigoProductoEspecifico);
            _DTProductosEspecificosTemporal.Columns.Add(DCTiempoGarantia);
            _DTProductosEspecificosTemporal.Columns.Add(DCFechaValidez);
            _DTProductosEspecificosTemporal.Columns.Add(DCEstado);

            _DTProductosEspecificosTemporal.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = _DTProductosEspecificosTemporal.Columns["CodigoProductoEspecifico"];
            _DTProductosEspecificosTemporal.PrimaryKey = PrimaryKeyColumns;

            DGCCodigoProductoEspecifico.DefaultCellStyle.NullValue = "00000000000000";

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
            DCTiempoGarantia.ColumnName = "TiempoGarantiaPECompra";

            DataColumn DCFechaValidez = new DataColumn();
            DCFechaValidez.DataType = Type.GetType("System.DateTime");
            DCFechaValidez.ColumnName = "FechaHoraVencimientoPE";
            DCFechaValidez.DefaultValue = DateTime.Now;


            DataColumn DCCargarAInventario = new DataColumn();
            DCCargarAInventario.DataType = Type.GetType("System.Boolean");
            DCCargarAInventario.ColumnName = "CargarAInventario";
            DCCargarAInventario.DefaultValue = false;

            DataColumn DCPrecioUnitario = new DataColumn();
            DCPrecioUnitario.DataType = Type.GetType("System.Decimal");
            DCPrecioUnitario.ColumnName = "PrecioUnitario";
            DCPrecioUnitario.DefaultValue = 0.00;


            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCNombreProducto);
            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCCodigoProducto);
            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCCodigoProductoEspecifico);
            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCCodigoTipoAgregado);
            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCTiempoGarantia);
            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCFechaValidez);
            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCPrecioUnitario);
            _DTProductosEspecificosAgregadosTemporal.Columns.Add(DCCargarAInventario);
            

            _DTProductosEspecificosAgregadosTemporal.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = _DTProductosEspecificosAgregadosTemporal.Columns["CodigoProductoEspecifico"];
            _DTProductosEspecificosAgregadosTemporal.PrimaryKey = PrimaryKeyColumns;

            DGCCodigoProductoEspecificoAgregado.DefaultCellStyle.NullValue = "00000000000000";

        }


        private void dGVProductosEspecificos_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = "";
            e.Row.Cells[1].Value = "";
            e.Row.Cells[2].Value = "";
            e.Row.Cells[3].Value = 0;
            e.Row.Cells[4].Value = DateTime.Now;
            e.Row.Cells[4].Value = "A";
        }


        private void dtGVCompraProductosAgregados_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = "";//CodigoProducto
            e.Row.Cells[1].Value = "";//CodigoProducto
            e.Row.Cells[2].Value = "";//CodigoProductoEspecifico            
            e.Row.Cells[3].Value = "O";//CodigoTipoAgregado
            e.Row.Cells[4].Value = 0; //TiempoGarantiaPECompra
            e.Row.Cells[5].Value = DateTime.Now; //DGCFechaHoraVencimientoPE            
            e.Row.Cells[6].Value = 0.00; //PrecioUnitario                
            e.Row.Cells[7].Value = false; //CargarAInventario
        }


        private void dGVProductosEspecificos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (_DTProductosEspecificosTemporal.Rows.Count > 0)
            {
                if (dGVProductosEspecificos.Rows[e.RowIndex].Cells[0].Value != null && !dGVProductosEspecificos.Rows[e.RowIndex].Cells[0].Value.Equals(""))
                {
                    dGVProductosEspecificos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                    dGVProductosEspecificos.Rows[e.RowIndex].Cells[0].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
                    //dtGVProductosAgregados.Rows[indiceActual].Cells[1].Style.Font = new Font(dtGVProductosAgregados.Rows[indiceActual].Cells[0].Style.Font.Name, dtGVProductosAgregados.Rows[indiceActual].Cells[0].Style.Font.Size, FontStyle.Bold);
                    dGVProductosEspecificos.Rows[e.RowIndex].Cells[1].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
                }
            }
        }

        private void dtGVCompraProductosAgregados_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (_DTProductosEspecificosAgregadosTemporal.Rows.Count > 0)
            {                

                if (dtGVCompraProductosAgregados.Rows[e.RowIndex].Cells[0].Value != null && !dtGVCompraProductosAgregados.Rows[e.RowIndex].Cells[0].Value.Equals(""))
                {
                    dtGVCompraProductosAgregados.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                    dtGVCompraProductosAgregados.Rows[e.RowIndex].Cells[0].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
                    //dtGVProductosAgregados.Rows[indiceActual].Cells[1].Style.Font = new Font(dtGVProductosAgregados.Rows[indiceActual].Cells[0].Style.Font.Name, dtGVProductosAgregados.Rows[indiceActual].Cells[0].Style.Font.Size, FontStyle.Bold);
                    dtGVCompraProductosAgregados.Rows[e.RowIndex].Cells[1].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
                }
            }
        }


        private void AgregarValoresDTProductosEspecificosTemporal(DataGridViewCellEventArgs e)
        {
            if (dGVProductosEspecificos.RowCount > 0 && !dGVProductosEspecificos.IsCurrentRowDirty && dGVProductosEspecificos[2, e.RowIndex].Value != null)
            {
                if (_DTProductosEspecificosTemporal.Rows.Find(dGVProductosEspecificos[2, e.RowIndex].Value) == null)
                {
                    DataRow fila_x_Defecto = _DTProductosEspecificosTemporal.Rows.Find("______-1");
                    if (fila_x_Defecto != null)
                    {
                        fila_x_Defecto.BeginEdit();
                        fila_x_Defecto[0] = dGVProductosEspecificos[0, e.RowIndex].Value;
                        fila_x_Defecto[1] = dGVProductosEspecificos[1, e.RowIndex].Value;
                        fila_x_Defecto[2] = dGVProductosEspecificos[2, e.RowIndex].Value;
                        fila_x_Defecto[3] = dGVProductosEspecificos[3, e.RowIndex].Value;
                        fila_x_Defecto[4] = dGVProductosEspecificos[4, e.RowIndex].Value;
                        fila_x_Defecto[5] = dGVProductosEspecificos[5, e.RowIndex].Value;
                        fila_x_Defecto.AcceptChanges();
                    }
                }
                else
                {

                    _DTProductosEspecificosTemporal.Rows[e.RowIndex][2] = dGVProductosEspecificos[2, e.RowIndex].Value;
                    _DTProductosEspecificosTemporal.Rows[e.RowIndex][3] = dGVProductosEspecificos[3, e.RowIndex].Value;
                    _DTProductosEspecificosTemporal.Rows[e.RowIndex][4] = dGVProductosEspecificos[4, e.RowIndex].Value;
                    _DTProductosEspecificosTemporal.Rows[e.RowIndex][5] = dGVProductosEspecificos[5, e.RowIndex].Value;
                }
            }
        }


        private void AgregarValoresDTProductosEspecificosAgregadosTemporal(DataGridViewCellEventArgs e)
        {
            if (dtGVCompraProductosAgregados.RowCount > 0 && !dtGVCompraProductosAgregados.IsCurrentRowDirty && dtGVCompraProductosAgregados[2, e.RowIndex].Value != null)
            {
                if (_DTProductosEspecificosAgregadosTemporal.Rows.Find(dtGVCompraProductosAgregados[2, e.RowIndex].Value) == null)
                {
                    DataRow fila_x_Defecto = _DTProductosEspecificosAgregadosTemporal.Rows.Find("______-1");
                    if (fila_x_Defecto != null)
                    {
                        fila_x_Defecto.BeginEdit();
                        fila_x_Defecto[0] = dtGVCompraProductosAgregados[0, e.RowIndex].Value;
                        fila_x_Defecto[1] = dtGVCompraProductosAgregados[1, e.RowIndex].Value;
                        fila_x_Defecto[2] = dtGVCompraProductosAgregados[2, e.RowIndex].Value;
                        fila_x_Defecto[3] = dtGVCompraProductosAgregados[3, e.RowIndex].Value;
                        fila_x_Defecto[4] = dtGVCompraProductosAgregados[4, e.RowIndex].Value;
                        fila_x_Defecto[5] = dtGVCompraProductosAgregados[5, e.RowIndex].Value;
                        fila_x_Defecto[6] = dtGVCompraProductosAgregados[6, e.RowIndex].Value;
                        fila_x_Defecto[7] = dtGVCompraProductosAgregados[7, e.RowIndex].Value;
                        fila_x_Defecto.AcceptChanges();
                    }
                }
                else
                {

                    _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][2] = dtGVCompraProductosAgregados[2, e.RowIndex].Value;
                    _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][3] = dtGVCompraProductosAgregados[3, e.RowIndex].Value;
                    _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][4] = dtGVCompraProductosAgregados[4, e.RowIndex].Value;
                    _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][5] = dtGVCompraProductosAgregados[5, e.RowIndex].Value;
                    _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][6] = dtGVCompraProductosAgregados[6, e.RowIndex].Value;
                    _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][7] = dtGVCompraProductosAgregados[7, e.RowIndex].Value;
                }
            }
        }

        private void dtGVCompraProductosAgregados_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            dtGVCompraProductosAgregados.EndEdit();
            AgregarValoresDTProductosEspecificosAgregadosTemporal(e);
        }

        private void dGVProductosEspecificos_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            dGVProductosEspecificos.EndEdit();
            AgregarValoresDTProductosEspecificosTemporal(e);
        }

        private void dtGVCompraProductosAgregados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2) // si han terminado de editar la columna del codigo Especifico
            {
                string CodigoProducto = "00A";

                if (dtGVCompraProductosAgregados.CurrentRow.Cells[0].Value.Equals(""))
                {
                    int contador = dtGVCompraProductosAgregados.CurrentRow.Index;
                    while (dtGVCompraProductosAgregados.Rows[contador].Cells[0].Value.Equals(""))
                    {
                        contador--;
                        if (contador == -1)
                        {
                            contador = 0;
                            break;
                        }
                    }
                    CodigoProducto = dtGVCompraProductosAgregados.Rows[contador].Cells[1].Value.ToString().Trim();
                }
                else
                {
                    CodigoProducto = dtGVCompraProductosAgregados.CurrentRow.Cells[1].Value.ToString().Trim();
                }
                string codigoEspecificoActual = dtGVCompraProductosAgregados.CurrentRow.Cells[2].Value.ToString().Trim();
                if (!codigoEspecificoActual.Contains(CodigoProducto))
                {
                    int tamanioCodigoActual = codigoEspecificoActual.Length;
                    int tamanioCodigoProducto = CodigoProducto.Trim().Length;
                    int tamanioComodin = "-".Trim().Length;
                    if ((tamanioCodigoActual + tamanioCodigoProducto + tamanioComodin) > 20)
                    {
                        dtGVCompraProductosAgregados.CurrentRow.Cells[2].Value = CodigoProducto.Trim() + "-" + codigoEspecificoActual.Substring(0, codigoEspecificoActual.Length - ((tamanioComodin + tamanioCodigoProducto + tamanioCodigoActual) - 20));
                    }
                    else
                    {
                        dtGVCompraProductosAgregados.CurrentRow.Cells[2].Value = CodigoProducto.Trim() + "-" + codigoEspecificoActual;
                    }
                }
            }
        }

        private void dGVProductosEspecificos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 2) // si han terminado de editar la columna del codigo Especifico
            {
                string CodigoProducto = "00A";

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
                    int tamanioComodin = tsTxtBoxComodin.Text.Trim().Length;
                    if ((tamanioCodigoActual + tamanioCodigoProducto + tamanioComodin) > 20)
                    {
                        dGVProductosEspecificos.CurrentRow.Cells[2].Value = CodigoProducto.Trim() + tsTxtBoxComodin.Text.Trim() + codigoEspecificoActual.Substring(0, codigoEspecificoActual.Length - ((tamanioComodin + tamanioCodigoProducto + tamanioCodigoActual) - 20));
                    }
                    else
                    {
                        dGVProductosEspecificos.CurrentRow.Cells[2].Value = CodigoProducto.Trim() + tsTxtBoxComodin.Text.Trim() + codigoEspecificoActual;
                    }
                }
            }
        }


        private void dGVProductosEspecificos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (CodigosGenerados)
            {
            //    if (dGVProductosEspecificos[e.ColumnIndex, e.RowIndex].Value != null && dGVProductosEspecificos.CurrentRow != null && dGVProductosEspecificos.CurrentCell != null && dGVProductosEspecificos.Rows.Count > 0 && _DTProductosEspecificosTemporal.Rows.Count > 0)
            //    {
            //        switch (e.ColumnIndex)
            //        {
            //            case 2:// Código Producto Específico
            //                {
            //                    string CodigoEspecificoProductoActual = dGVProductosEspecificos.Rows[dGVProductosEspecificos.CurrentRow.Index].Cells["DGCCodigoProductoEspecifico"].Value.ToString();
            //                    DataRow Fila = _DTProductosEspecificosTemporal.Rows.Find(CodigoEspecificoProductoActual);
            //                    if (Fila != null) //si el codigo especifico existe no se debe hacer ningun cambio y mostramos error
            //                    {
            //                        //
            //                        dGVProductosEspecificos.Rows[dGVProductosEspecificos.CurrentRow.Index].Cells["DGCCodigoProductoEspecifico"].Value = _DTProductosEspecificosTemporal.Rows[e.RowIndex][2];
            //                        //MessageBox.Show(this, "No puede Ingresar Códigos Específicos Repetidos, Revise su Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                        return;
            //                    }
            //                    else
            //                    {
            //                        _DTProductosEspecificosTemporal.Rows[e.RowIndex][2] = dGVProductosEspecificos.Rows[dGVProductosEspecificos.CurrentRow.Index].Cells["DGCCodigoProductoEspecifico"].Value;
            //                    }
            //                    break;
            //                }
            //            case 3: // Tiempo de garantia
            //                {
            //                    _DTProductosEspecificosTemporal.Rows[e.RowIndex][3] = dGVProductosEspecificos.Rows[dGVProductosEspecificos.CurrentRow.Index].Cells["DGCTiempoGarantiaPECompra"].Value;
            //                    break;
            //                }
            //            case 4: // Fecha de Expiración
            //                {
            //                    _DTProductosEspecificosTemporal.Rows[e.RowIndex][4] = dGVProductosEspecificos.Rows[dGVProductosEspecificos.CurrentRow.Index].Cells["DGCFechaHoraVencimientoPE"].Value;
            //                    break;
            //                }
            //            case 5: //Codigo Estado Actual
            //                {
            //                    _DTProductosEspecificosTemporal.Rows[e.RowIndex][5] = dGVProductosEspecificos.Rows[dGVProductosEspecificos.CurrentRow.Index].Cells["DGCCodigoEstado"].Value;
            //                    break;
            //                }
            //            default:
            //                break;
            //        }
            //    }
            }
            //bdSourceProductosEspecificos.EndEdit();
        }

        private void dtGVCompraProductosAgregados_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (CodigosAgregadosGenerados)
            {
            //    if (e.RowIndex >= 0 && dtGVCompraProductosAgregados[e.ColumnIndex, e.RowIndex].Value != null && dtGVCompraProductosAgregados.CurrentRow != null && dtGVCompraProductosAgregados.CurrentCell != null && dtGVCompraProductosAgregados.Rows.Count > 0 && _DTProductosEspecificosAgregadosTemporal.Rows.Count > 0)
            //    {
            //        switch (e.ColumnIndex)
            //        {
            //            case 2:// Código Producto Específico
            //                {
            //                    string CodigoEspecificoProductoActual = dtGVCompraProductosAgregados.Rows[dtGVCompraProductosAgregados.CurrentRow.Index].Cells["DGCCodigoProductoEspecificoAgregado"].Value.ToString();
            //                    DataRow Fila = _DTProductosEspecificosAgregadosTemporal.Rows.Find(CodigoEspecificoProductoActual);
            //                    if (Fila != null) //si el codigo especifico existe no se debe hacer ningun cambio y mostramos error
            //                    {
            //                        //
            //                        dtGVCompraProductosAgregados.Rows[dtGVCompraProductosAgregados.CurrentRow.Index].Cells["DGCCodigoProductoEspecificoAgregado"].Value = _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][2];
            //                        //MessageBox.Show(this, "No puede Ingresar Códigos Específicos Repetidos, Revise su Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                        return;
            //                    }
            //                    else
            //                    {
            //                        _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][2] = dtGVCompraProductosAgregados.Rows[dtGVCompraProductosAgregados.CurrentRow.Index].Cells["DGCCodigoProductoEspecificoAgregado"].Value;
            //                    }
            //                    break;
            //                }
            //            case 3: // Codigo Tipo Agregado
            //                {
            //                    _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][3] = dtGVCompraProductosAgregados.Rows[dtGVCompraProductosAgregados.CurrentRow.Index].Cells["DGCCodigoTipoAgregadoAgregado"].Value; 
            //                    break;
            //                }
            //            case 4: // Tiempo de garantia
            //                {
            //                    _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][4] = dtGVCompraProductosAgregados.Rows[dtGVCompraProductosAgregados.CurrentRow.Index].Cells["DGCTiempoGarantiaPEAgregado"].Value; 
            //                    break;
            //                }
            //            case 5: // Fecha de Expiración
            //                {
            //                    _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][5] = dtGVCompraProductosAgregados.Rows[dtGVCompraProductosAgregados.CurrentRow.Index].Cells["DGCFechaHoraVencimientoPEAgregado"].Value;
            //                    break;
            //                }
            //            case 6: // Precio Unitario
            //                {
            //                    _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][6] = dtGVCompraProductosAgregados.Rows[dtGVCompraProductosAgregados.CurrentRow.Index].Cells["DGCPrecioUnitarioAgregado"].Value; 
            //                    break;
            //                }
            //            case 7: //Es Agregado
            //                {
            //                    _DTProductosEspecificosAgregadosTemporal.Rows[e.RowIndex][7] = dtGVCompraProductosAgregados.Rows[dtGVCompraProductosAgregados.CurrentRow.Index].Cells["DGCCargarAInventarioAgregado"].Value;
            //                    if (dtGVCompraProductosAgregados.Rows[dtGVCompraProductosAgregados.CurrentRow.Index].Cells["DGCCargarAInventarioAgregado"].Value.Equals(true))
            //                    {
            //                        string codigoProducto = dtGVCompraProductosAgregados.Rows[dtGVCompraProductosAgregados.CurrentRow.Index].Cells["DGCCodigoProductoAgregado"].Value.ToString();
            //                        int cantidadAgregada = 0;
            //                        int indice = dtGVCompraProductosAgregados.CurrentRow.Index;
            //                        if (string.IsNullOrEmpty(codigoProducto))
            //                        {
            //                            while (dtGVCompraProductosAgregados.Rows[indice].Cells["DGCCodigoProductoAgregado"].Value.ToString().Length <= 0)
            //                            {
            //                                indice--;
            //                            }
            //                            codigoProducto = dtGVCompraProductosAgregados.Rows[indice].Cells["DGCCodigoProductoAgregado"].Value.ToString();
            //                        }
            //                        int indiceInicio = indice;
            //                        while (indice != dtGVCompraProductosAgregados.Rows.Count - 1 && dtGVCompraProductosAgregados.Rows[indice].Cells["DGCCodigoProductoEspecificoAgregado"].Value.ToString().Contains(codigoProducto))  
            //                        {
            //                            cantidadAgregada++;
            //                            indice++;
            //                        }
            //                        if (indice == dtGVCompraProductosAgregados.Rows.Count - 1)
            //                            cantidadAgregada++;

            //                        //cantidadAgregada++; //aumentamos el producto faltante que no se conto porque la celda si tiene registrada el codigo del producto y no es vacia
            //                        string codigos = InventarioProductoEspecificoCLN.ObtenerListadoCodigoProductoEspecificoGenerado(codigoProducto, cantidadAgregada, "-", "I");
            //                        string[] listadoCodigosEspecifico = codigos.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries);
            //                        indice = indiceInicio;
            //                        int indiceCodigoEspecifico = 0;
            //                        string CodigoProductoEspecifico = codigoProducto + "-" + listadoCodigosEspecifico[indiceCodigoEspecifico + 1].Substring(codigoProducto.Trim().Length + 2).Trim();
            //                        DataRow fila = _DTProductosEspecificosAgregadosTemporal.Rows.Find(CodigoProductoEspecifico);
            //                        while (fila !=null)
            //                        {
            //                            indice++;
            //                            indiceCodigoEspecifico++;
            //                            if (indiceCodigoEspecifico != listadoCodigosEspecifico.Length-1)
            //                            {
            //                                CodigoProductoEspecifico = codigoProducto + "-" + listadoCodigosEspecifico[indiceCodigoEspecifico + 1].Substring(codigoProducto.Trim().Length + 2).Trim();
            //                                fila = _DTProductosEspecificosAgregadosTemporal.Rows.Find(CodigoProductoEspecifico);                                            
            //                            }
            //                            else
            //                                break;
            //                        }
            //                        //dtGVCompraProductosAgregados.Rows[e.RowIndex].Cells[2].Value = codigoProducto + "-" + listadoCodigosEspecifico[indiceCodigoEspecifico + 1].Substring(codigoProducto.Trim().Length+2);
            //                        dtGVCompraProductosAgregados.Rows[e.RowIndex].Cells[2].Value = CodigoProductoEspecifico;
            //                        dtGVCompraProductosAgregados.EndEdit();                                    
            //                        //dGVProductosEspecificos_CellEndEdit(sender, e as DataGridViewCellEventArgs);
            //                    }
            //                    break;
            //                }
            //            default:
            //                break;
            //        }
            //    }
            }
            //bdSourceCompraProductosAgregados.EndEdit();
        }

        private void dGVProductosEspecificos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dGVProductosEspecificos.BeginEdit(true);
        }

        private void dtGVCompraProductosAgregados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtGVCompraProductosAgregados.BeginEdit(true);
        }


        private void dGVProductosEspecificos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dGVProductosEspecificos.Columns[e.ColumnIndex].Name == "DGCCodigoProductoEspecifico")
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dGVProductosEspecificos.Rows[e.RowIndex].Cells[2].ErrorText = "El Código de Producto Especifico no Puede ser Vacio";
                    e.Cancel = true;
                    return;
                }
                //string CodigoEspecificoAnterior = _DTProductosEspecificosTemporal.Rows[e.RowIndex][2].ToString();
                string CodigoEspecificoNuevo = dGVProductosEspecificos.CurrentCell.Value.ToString();
                string CodigoEspecificoAnterior = e.FormattedValue.ToString();
                DataRow Fila = _DTProductosEspecificosTemporal.Rows.Find(CodigoEspecificoAnterior);
                if (Fila != null && CodigoEspecificoAnterior != CodigoEspecificoNuevo) //si el codigo especifico existe no se debe hacer ningun cambio y mostramos error
                {
                    //dGVProductosEspecificos.Rows[e.RowIndex].ErrorText = "El Código de Producto Especifico no Puede ser Repetido";
                    dGVProductosEspecificos.Rows[e.RowIndex].Cells[2].ErrorText = "El Código de Producto Especifico no Puede ser Repetido";
                    e.Cancel = true;
                }
            }
        }

        private void dtGVCompraProductosAgregados_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtGVCompraProductosAgregados.Columns[e.ColumnIndex].Name == "DGCCodigoProductoEspecificoAgregado")
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dtGVCompraProductosAgregados.Rows[e.RowIndex].Cells[2].ErrorText = "El Código de Producto Especifico no Puede ser Vacio";
                    e.Cancel = true;
                    return;
                }
                //string CodigoEspecificoAnterior = _DTProductosEspecificosTemporal.Rows[e.RowIndex][2].ToString();
                string CodigoEspecificoNuevo = dtGVCompraProductosAgregados.CurrentCell.Value.ToString();
                string CodigoEspecificoAnterior = e.FormattedValue.ToString();
                DataRow Fila = _DTProductosEspecificosAgregadosTemporal.Rows.Find(CodigoEspecificoAnterior);
                if (Fila != null && CodigoEspecificoAnterior != CodigoEspecificoNuevo) //si el codigo especifico existe no se debe hacer ningun cambio y mostramos error
                {
                    //dGVProductosEspecificos.Rows[e.RowIndex].ErrorText = "El Código de Producto Especifico no Puede ser Repetido";
                    dtGVCompraProductosAgregados.Rows[e.RowIndex].Cells[2].ErrorText = "El Código de Producto Especifico no Puede ser Repetido";
                    e.Cancel = true;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl1.SelectedTab == this.tabPage3 && btnAceptar.Enabled && _DTProductosEspecificosTemporal.Rows.Count == 0 || !CodigosGenerados)
            if (tabControl1.SelectedTab == this.tabPage3 && btnAceptar.Enabled && !CodigosGenerados)
            {
                toolStripbtnGenerarCodigos_Click(sender, e);
                return;
            }
            if (tabControl1.SelectedTab == this.tabPage2 && btnAceptar.Enabled && !CodigosAgregadosGenerados)
            {
                generarDetalleCompraProductosEspecificosAgregados();
            }
             //* habilitar para volver a manejar el formulario en todo
             //*/
        }


        public void generarDetalleCompraProductosEspecificosAgregados()
        {

            
            dtGVCompraProductosAgregados.Visible = true;
            dtGVCompraProductosAgregados.Dock = DockStyle.Fill;
            dtGVCompraProductosAgregados.Height = AlturaDGVProductosEspecificosAgregados; 

            dtGVCompraProductosEspecificosAgregados.Visible = false;
            dtGVCompraProductosEspecificosAgregados.Dock = DockStyle.None;
            dtGVCompraProductosEspecificosAgregados.Height = 0;

            _DTProductosEspecificosAgregadosTemporal.Clear(); 
            InventariosProductosEspecificosCLN _InventarioProductosEspecificos = new InventariosProductosEspecificosCLN();
            bdSourceCompraProductosAgregados.DataSource = _DTProductosEspecificosAgregadosTemporal;
            /*
            foreach( DataGridViewRow fila in dGVProductosSeleccionados.Rows)
            {
                if (fila.Cells["VendidoComoAgregado"].Value.Equals(true))
                {
                    string codigoProducto = fila.Cells[0].Value.ToString().Trim();
                    string NombreProducto = fila.Cells[1].Value.ToString().Trim();
                    int cantidadCompra = Int32.Parse(fila.Cells[2].Value.ToString());
                    decimal PrecioCompra = Decimal.Parse(fila.Cells[3].Value.ToString());
                    string codigosGenerados = _InventarioProductosEspecificos.ObtenerListadoCodigoProductoEspecificoGenerado(codigoProducto, cantidadCompra, "-", "I");
                    string[] Listado_de_Codigos = codigosGenerados.Split(new char[] { ',' });//, StringSplitOptions.RemoveEmptyEntries);

                    string codigoExpecifico;
                    int tamanioComodin = "-".Trim().Length;
                    int tamanioCodigoProducto = codigoProducto.Trim().Length;
                    for (int i = 0; i < cantidadCompra; i++)
                    {
                        DataRow filaNueva = _DTProductosEspecificosAgregadosTemporal.NewRow();
                        codigoExpecifico = Listado_de_Codigos[i + 1].Trim().Substring(tamanioCodigoProducto + tamanioComodin, 20 - (tamanioCodigoProducto + tamanioComodin));
                        //filaNueva[0] = codigoProducto.Trim() + tsTxtBoxComodin.Text.Trim() + codigoExpecifico.Trim();
                        if (i == 0)
                        {
                            filaNueva["NombreProducto"] = NombreProducto;
                            filaNueva["CodigoProducto"] = codigoProducto;
                        }
                        else
                        {
                            filaNueva["NombreProducto"] = "";
                            filaNueva["CodigoProducto"] = "";
                        }
                        filaNueva["CodigoProductoEspecifico"] = codigoProducto.Trim() + tsTxtBoxComodin.Text.Trim() + codigoExpecifico.Trim();
                        filaNueva["CodigoTipoAgregado"] = "O";
                        filaNueva["TiempoGarantiaPECompra"] = 0;
                        filaNueva["FechaHoraVencimientoPE"] = DateTime.Now.AddMonths(2);
                        filaNueva["CargarAInventario"] = false;
                        filaNueva["PrecioUnitario"] = PrecioCompra;
                        _DTProductosEspecificosAgregadosTemporal.Rows.Add(filaNueva);
                        filaNueva.AcceptChanges();
                    }
                }                

            }
            CodigosAgregadosGenerados = true;
            dtGVCompraProductosAgregados.EndEdit();
            bdSourceCompraProductosAgregados.EndEdit();

            //habilitar que el formulario se encargue absolutamente de todo en esta ventana
             
            */
        }


        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            FBuscarProveedores formProveedor = new FBuscarProveedores();
            formProveedor.ShowDialog(this);
            int CodigoProveedor = formProveedor.CodigoProveedor;
            if (CodigoProveedor >= 0)
            {
                cBoxProveedor.SelectedValue = CodigoProveedor.ToString();
            }
        }

        private void txtBoxMontoEfectivo_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxMontoEfectivo.Text.Contains('.'))
                txtBoxMontoEfectivo.Text.Replace('.', ',');
            decimal precioEfectivo = (decimal)0.0f, precioDeuda = (decimal)0.0f, precioTotal = (decimal)0.0f;            
            if (Decimal.TryParse(txtBoxPrecioTotal.Text.Trim().Substring(0, txtBoxPrecioTotal.Text.Length - MascaraMonedaSistema.Length), out precioTotal))
            {
                if (txtBoxMontoEfectivo.Text.Trim().Contains(MascaraMonedaSistema))
                {
                    if (Decimal.TryParse(txtBoxMontoEfectivo.Text.Trim().Substring(0, txtBoxMontoEfectivo.Text.Trim().Length - MascaraMonedaSistema.Length), out precioEfectivo))
                    {
                        precioDeuda = precioTotal - precioEfectivo;
                        txtBoxMontoDeuda.Text = precioDeuda.ToString() + " " + MascaraMonedaSistema;                        
                    }
                }
                else
                {
                    
                    precioDeuda = precioTotal - precioEfectivo;
                    txtBoxMontoEfectivo.Text = precioEfectivo.ToString() + ",00 " + MascaraMonedaSistema;
                    txtBoxMontoEfectivo.Select(0, 4);
                    txtBoxMontoDeuda.Text = precioDeuda.ToString() + " " + MascaraMonedaSistema;
                }
            }
            
        }

        private void txtBoxMontoEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtBoxMontoEfectivo_Enter(sender, e as EventArgs);
            }
        }

        private void txtBoxMontoEfectivo_Enter(object sender, EventArgs e)
        {
            if (txtBoxMontoEfectivo.Text.Trim().Contains(MascaraMonedaSistema))
            {
                txtBoxMontoEfectivo.Select(0, txtBoxMontoEfectivo.Text.Trim().Length - MascaraMonedaSistema.Length);
            }
            else
            {
                txtBoxMontoEfectivo.SelectAll();
            }
        }

        private void txtBoxMontoEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter & e.KeyChar != ',')
            {
                txtBoxMontoEfectivo_Enter(sender, e as EventArgs);         
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
                return;
            }
        }

        private void btnRegistrarProveedor_Click(object sender, EventArgs e)
        {
            FProveedores formProveedores = new FProveedores(true, false, false, true);
            formProveedores.ShowDialog(this);
            string ultimoProveedor = ProveedorCLN.ObtenerUltimoProveedorInsertado();
            string[] datosUltimoProveedor = ultimoProveedor.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            DataRow fila = _DTProveedores.Rows.Find(datosUltimoProveedor[0]);
            if (fila == null) //si la fila no existe dentro de la tabla temporal de proveedores, lo insertamos
            {
                fila = _DTProveedores.NewRow();
                fila["CodigoProveedor"] = datosUltimoProveedor[0];
                fila["NombreRazonSocial"] = datosUltimoProveedor[1];
                fila["NITProveedor"] = datosUltimoProveedor[2];
                _DTProveedores.Rows.Add(fila);
                fila.AcceptChanges();

                _DTProveedores.DefaultView.Sort = "NombreRazonSocial ASC";
                cBoxProveedor.SelectedValue = datosUltimoProveedor[0].ToString();
            }
            formProveedores.Dispose();
        }

        private void informeGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object detallePrecioTotal = _DTComprasProductosDetalle.Compute("sum(PrecioTotal)", "");
            DataTable DTCompraProductosReporte = CompraProductosCLN.ListarCompraProductoReporte(NumeroAgencia, NumeroCompraProducto);
            DataTable DTCompraProductosDetalleReporte = CompraProductosDetalleCLN.ListarCompraProductoDetalleReporte(NumeroAgencia, NumeroCompraProducto);
            DataTable DTCompraProductosAgregadosReporte = CompraProductoEspecificoAgregadoCLN.ListarCompraProductoEspecificoAgregadoReporte(NumeroAgencia, NumeroCompraProducto);
            //FReporteCompraProductos ReporteCompraproductosForm = new FReporteCompraProductos(DTCodigoProductoEspecifico, CompraProductosCLN.ListarTuplaDatosCompraProductoReporte(NumeroAgencia, Int32.Parse(lblNumeroCompra.Text)) + ", " + detallePrecioTotal.ToString(), DTCompraProductosAgregadosReporte);
            FReporteCompraProductosGeneral ReporteCompraproductosForm = new FReporteCompraProductosGeneral(DTCompraProductosReporte, DTCompraProductosDetalleReporte, DTCompraProductosAgregadosReporte);
            ReporteCompraproductosForm.Show();
        }

        private void reciboToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            DataTable DTCompraProductosReporte = CompraProductosCLN.ListarCompraProductoReporte(NumeroAgencia, NumeroCompraProducto);
            DataTable DTCompraProductosDetalleReporte = CompraProductosDetalleCLN.ListarCompraProductoDetalleReporteIncluidoAgregados(NumeroAgencia, NumeroCompraProducto, "S", true);                        
            FReporteCompraProductosGeneral ReporteCompraproductosForm = new FReporteCompraProductosGeneral(DTCompraProductosReporte, DTCompraProductosDetalleReporte);
            ReporteCompraproductosForm.Show();
        }

        private void codiEspecificosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);
            DataTable DTCodigoProductoEspecifico = this.CompraUtilidadesCLN.ListarDatosCodigosProductosEspecificosReporte(NumeroAgencia, NumeroCompraProducto, "", "");
            FReporteCompraProductosGeneral ReporteCompraproductosForm = new FReporteCompraProductosGeneral(DTDatosAgencia, DTCodigoProductoEspecifico, true);
            ReporteCompraproductosForm.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FCambiarMonedaCotizacionDeTransaccionesGC formCambioMoneda;
            if (btnAceptar.Enabled)
            {
                formCambioMoneda = new FCambiarMonedaCotizacionDeTransaccionesGC(_DTComprasProductosDetalleTemporal, NumeroPC, NumeroAgencia, NumeroCompraProducto, CompraUtilidadesCLN, 'I');
            }
            else
            {
                formCambioMoneda = new FCambiarMonedaCotizacionDeTransaccionesGC(_DTComprasProductosDetalle, NumeroPC, NumeroAgencia, NumeroCompraProducto, CompraUtilidadesCLN, 'F');
            }
            formCambioMoneda.DarEstiloParaCompras();
            formCambioMoneda.ShowDialog(this);
        }


        private void botonesToolStrip_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void botonesToolStrip_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FComprasProductos_Load(object sender, EventArgs e)
        {

            DGCCodigoProductoDetalle.Width = 80;
            DGCNombreProductoDetalle.Width = 350;
            DGCCantidadDetalle.Width = 80;
            DGCEsProductoEspecifico.Width = 70;
            DGCEsProductoEspecifico.Visible = false;
            //cargarDatosCompras(numeroCompra);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        public void emitirPermisos(bool permitirComprar, bool permitirAnular, bool permitirModificar, bool permitirReportes, bool permitirNavegar, bool permitirPagar)
        {
            btnNuevaCompra.Visible = permitirComprar;            
            btnAnular.Visible = permitirAnular;
            btnModificar.Visible = permitirModificar;
            btnReporte.Visible = permitirReportes;
            btnBuscar.Visible = permitirNavegar;
            btnFinalizar.Visible = permitirPagar;            
        }
               

        private void checkVerCodEspecificos_CheckedChanged(object sender, EventArgs e)
        {
            DGCEsProductoEspecifico.Visible = checkVerCodEspecificos.Checked;
            DGCEsProductoEspecifico.ReadOnly = !checkVerCodEspecificos.Checked;
        }

        private void dGVProductosSeleccionados_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dGVProductosSeleccionados.IsCurrentCellDirty && dGVProductosSeleccionados.CurrentCell.ColumnIndex != DGCEsProductoEspecifico.Index)
            {
                dGVProductosSeleccionados.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FObservacionesTransaccionesModificacion _FObservacionesTransaccionesModificacion = new FObservacionesTransaccionesModificacion("C", CodigoUsuario, NumeroAgencia, NumeroCompraProducto);
            _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text = txtBoxObservaciones.Text;
            if (_FObservacionesTransaccionesModificacion.ShowDialog() == DialogResult.OK)
                txtBoxObservaciones.Text = _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text;
        }

        private void checkConFactura_CheckedChanged(object sender, EventArgs e)
        {
            if (TipoOperacion != "")
            {
                if (checkConFactura.Checked)
                {
                    if (!tabControlDatos.TabPages.Contains(tabPageDatosFactura))
                        tabControlDatos.TabPages.Add(tabPageDatosFactura);
                    tabControlDatos.SelectedTab = tabPageDatosFactura;
                    habilitarControlesFactura(true);
                    tabControlDatos.Controls[tabPageDatosFactura.Name].Enabled = true;
                    txtBoxMontoIVAFactura.Focus();
                    txtBoxMontoIVAFactura.SelectAll();
                }
                else
                {
                    if (tabControlDatos.TabPages.Contains(tabPageDatosFactura))
                        tabControlDatos.TabPages.Remove(tabPageDatosFactura);
                    tabControlDatos.SelectedTab = tabPageDatosGenerales;                    
                    habilitarControlesFactura(false);
                    txtBoxNroAutorizacionFactura.Text = txtBoxMontoIVAFactura.Text =
                        txtBoxNumeroFactura.Text = txtBoxCodigoControlFactura.Text = String.Empty;
                }
            }
            
            
        }

        private void checkImportacion_CheckedChanged(object sender, EventArgs e)
        {
            if (TipoOperacion != "")
            {
                if (checkImportacion.Checked)
                {
                    if (!tabControlDatos.TabPages.Contains(tabPageDatosImportacion))
                        tabControlDatos.TabPages.Add(tabPageDatosImportacion);
                    tabControlDatos.SelectedTab = tabPageDatosImportacion;
                    habilitarControlesImportacion(true);
                    tabControlDatos.Controls[tabPageDatosImportacion.Name].Enabled = true;
                    dtPickerFechaEnvioMercaderia.Format = DateTimePickerFormat.Short;
                    dtPickerFechaHoraPlazoDeRecepcion.Format = DateTimePickerFormat.Short;
                    dtPickerFechaHoraPlazoDeRecepcion.Focus();
                }
                else
                {
                    if (tabControlDatos.TabPages.Contains(tabPageDatosImportacion))
                        tabControlDatos.TabPages.Remove(tabPageDatosImportacion);
                    tabControlDatos.SelectedTab = tabPageDatosGenerales;
                    habilitarControlesImportacion(false);
                    txtBoxDIPersonaRecojo.Text = txtBoxNombreCompletoPersonaRecojo.Text = String.Empty;
                    cBoxMediosTransporte.SelectedIndex = -1;
                    cBoxOrigenMercaderia.SelectedIndex = -1;
                    dtPickerFechaEnvioMercaderia.Format = DateTimePickerFormat.Custom;
                    dtPickerFechaEnvioMercaderia.CustomFormat = "  :  ";
                    dtPickerFechaHoraPlazoDeRecepcion.Format = DateTimePickerFormat.Custom;
                    dtPickerFechaHoraPlazoDeRecepcion.CustomFormat = "  :  ";

                }
            }
        }
        
        private void btnMediosTransporte_Click(object sender, EventArgs e)
        {
            FMediosTransporte formMediosTransporte = new FMediosTransporte();
            formMediosTransporte.esParaAgregar = true;
            if (formMediosTransporte.ShowDialog(this) == DialogResult.OK)
            {
                byte CodigoMedioTransporteNuevo = formMediosTransporte.CodigoMedioTransporte;
                _DTMedioTransporte = (DSDoblones20GestionComercial2.MediosTransportesDataTable)cBoxMediosTransporte.DataSource;
                if (_DTMedioTransporte.FindByCodigoMedioTransporte(CodigoMedioTransporteNuevo) == null)
                {
                    _DTMedioTransporte.Rows.Add(MedioTransCLN.ObtenerMedioTransporte(CodigoMedioTransporteNuevo)[0].ItemArray);
                    _DTMedioTransporte.DefaultView.Sort = "NombreMedioTransporte ASC";
                    cBoxMediosTransporte.SelectedValue = CodigoMedioTransporteNuevo;
                }                
            }
            formMediosTransporte.Dispose();
        }

        private void btnOrigenMercaderia_Click(object sender, EventArgs e)
        {
            FOrigenMercaderia formOrigenMercaderia = new FOrigenMercaderia();
            formOrigenMercaderia.esParaAgregar = true;
            if (formOrigenMercaderia.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                byte CodigoOrigenMercaderiaNuevo = formOrigenMercaderia.CodigoOrigenMercaderia;
                _DTOrigenMercaderia = (DSDoblones20GestionComercial2.OrigenMercaderiasDataTable) cBoxOrigenMercaderia.DataSource;
                if (_DTOrigenMercaderia.FindByCodigoOrigenMercaderia(CodigoOrigenMercaderiaNuevo) == null)
                {
                    _DTOrigenMercaderia.ImportRow(OrigMercaderiaCLN.ObtenerOrigenMercaderia(CodigoOrigenMercaderiaNuevo)[0]);
                    _DTOrigenMercaderia.DefaultView.Sort = "NombreOrigenMercaderia ASC";
                    cBoxOrigenMercaderia.SelectedValue = CodigoOrigenMercaderiaNuevo;
                }
            }
            formOrigenMercaderia.Dispose();
        }

        private void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            FBuscarPersonas formBuscadorPersonas = new FBuscarPersonas();
            formBuscadorPersonas.ShowDialog(this);
            string DIPersonasBuscada = formBuscadorPersonas.DISeleccionado;
            txtBoxNombreCompletoPersonaRecojo.Text = _comprasUtilidadesCLN.ObtenerNombreCompleto(DIPersonasBuscada);
            txtBoxDIPersonaRecojo.Text = formBuscadorPersonas.DISeleccionado;
            if (string.IsNullOrEmpty(txtBoxNombreCompletoPersonaRecojo.Text))
            {
                errorProvider1.SetError(txtBoxDIPersonaRecojo, "No ha Seleccionado ninguna Persona Responsable Intermediria");
                txtBoxDIPersonaRecojo.Focus();
            }
            formBuscadorPersonas.Dispose();
        }

        private void btnAgregarPersona_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            FPersonas formPersonas = new FPersonas();
            formPersonas.ShowDialog(this);
            if (formPersonas.DialogResult == DialogResult.OK)
            {
                txtBoxNombreCompletoPersonaRecojo.Text = _comprasUtilidadesCLN.ObtenerNombreCompleto(formPersonas.DIPersonaNueva);
                txtBoxDIPersonaRecojo.Text = formPersonas.DIPersonaNueva;
            }
            else
            {
                errorProvider1.SetError(txtBoxDIPersonaRecojo, "No ha ingresado ninguna Persona Responsable Intermediria");
                txtBoxDIPersonaRecojo.Focus();
            }
            formPersonas.Dispose();
            
        }

        private void txtBoxDIPersonaRecojo_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBoxDIPersonaRecojo.Text) && TipoOperacion != "")
                txtBoxNombreCompletoPersonaRecojo.Text = _comprasUtilidadesCLN.ObtenerNombreCompleto(txtBoxDIPersonaRecojo.Text.Trim());
            else
                txtBoxNombreCompletoPersonaRecojo.Text = String.Empty;

        }

        private void txtBoxDIPersonaRecojo_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }

        private void ordenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ListarReporteComprasProductosCopiaSistemaCEATEC
            DataTable DTCompraProductosReporte = CompraProductosCLN.ListarCompraProductoReporte(NumeroAgencia, NumeroCompraProducto);
            DataTable DTCompraProductosDetalleReporte = CompraProductosDetalleCLN.ListarCompraProductoDetalleReporteIncluidoAgregados(NumeroAgencia, NumeroCompraProducto, "S", true);
            FReporteCompraProductosGeneral ReporteCompraproductosForm = new FReporteCompraProductosGeneral();
            ReporteCompraproductosForm.ListarReporteComprasProductosCopiaSistemaCEATEC(DTCompraProductosReporte, DTCompraProductosDetalleReporte);
            ReporteCompraproductosForm.Show();
        }

        private void txtBoxDIPersonaRecojo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxDIPersonaRecojo_Leave(sender, e as EventArgs);
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            string CodigoEstadoCompra = _DTComprasProductos[0].CodigoEstadoCompra;
            FCompraProductosAdministradorPagos _FCompraProductosAdministradorPagos = new FCompraProductosAdministradorPagos(NumeroAgencia, NumeroCompraProducto, CodigoUsuario, CodigoMonedaSistema);
            _FCompraProductosAdministradorPagos.MascaraMoneda = MascaraMonedaSistema;
            _FCompraProductosAdministradorPagos.ShowDialog();
            _FCompraProductosAdministradorPagos.Dispose();
            
            if (CompraUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroCompraProducto, "C").CompareTo(CodigoEstadoCompra) != 0)
            {
                cargarDatosCompras(NumeroCompraProducto);
                btnPagar.Enabled = false;
            }            
        }


    }
}

