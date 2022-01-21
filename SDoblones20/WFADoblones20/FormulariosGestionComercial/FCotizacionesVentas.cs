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
using CLCLN.GestionComercial;
using CLCLN.Sistema;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FCotizacionesVentas : Form
    {
        FProductosBusqueda fProductosBusqueda = null;

        #region DataTables
        DataTable _DTProductosSeleccionados = null;
        DataTable _DTClientes = null;
        DataTable _DTCotizacionesProductos = null;
        DataTable _DTCotizacionesProductosDetalle = null;
        DataTable _DTCotizacionesProductosTemporal = null;
        DataTable _DTCotizacionesProductosDetalleTemporal = null;
        DataTable _DTMonedas = null;
        DataTable _DTUsuarios = null;
        DataTable _DTCotizacionProductosTemporalCambioMoneda = null;
        DataTable VariablesConfiguracionSistemaGC = null;
        #endregion
        DataSet DSMaestroDetalle = null;
        #region Variables CLN
                private CotizacionVentasProductosCLN _CotizacionesProductosCLN = null;
                private CotizacionVentasProductosDetaCLN _CotizacionesProductosDetalleCLN = null;
                private ClientesCLN _ClientesCLN = null;
                private TransaccionesUtilidadesCLN _CotizacionesUtilidadesCLN = null;
                private MonedasCLN _MonedasCLN = null;
                private UsuariosCLN _UsuariosCLN = null;
                private FVentasProductos formVentasProductos = null;
                private PCsConfiguracionesCLN PCConfiguracion = null;
        #endregion

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


        private int CodigoUsuario;
        private string CodigoTipoCotizacion = "N";
        bool cotizacionConFactura;
        int numeroCotizacion = 0;
        /// <summary>
        /// Agencia para la cual se realizará las transacciones
        /// </summary>
        private int NumeroAgencia = 1;
        private int NumeroPC = 0;

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

        string TipoOperacion = "";
        int CodigoMonedaActual;

        //private Cursor cursorBotones = Cursors.Default;
        
        public FVentasProductos FVentaProductos
        {
            get
            {
                if (formVentasProductos == null)
                    formVentasProductos = new FVentasProductos(NumeroAgencia, NumeroPC, CodigoUsuario);
                return formVentasProductos;
            }
            set
            {
                formVentasProductos = value;
            }
        }

        public UsuariosCLN UsuarioCLN
        {
            get
            {
                if (_UsuariosCLN == null)
                    _UsuariosCLN = new UsuariosCLN();
                return _UsuariosCLN;
            }
        }

        public MonedasCLN MonedasCLN
        {
            get
            {
                if (_MonedasCLN == null)
                    _MonedasCLN = new MonedasCLN();
                return _MonedasCLN;
            }
        }

        public TransaccionesUtilidadesCLN CotizacionUtilidadesCLN
        {
            get
            {
                if (_CotizacionesUtilidadesCLN == null)
                    _CotizacionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
                return _CotizacionesUtilidadesCLN;
            }
        }

        public ClientesCLN ClienteCLN
        {
            get
            {
                if (_ClientesCLN == null)
                    _ClientesCLN = new ClientesCLN();
                return _ClientesCLN;
            }
        }

        public CotizacionVentasProductosCLN CotizacionProductosCLN
        {
            get
            {
                if (_CotizacionesProductosCLN == null)
                    _CotizacionesProductosCLN = new CotizacionVentasProductosCLN();
                return _CotizacionesProductosCLN;
            }
        }

        public CotizacionVentasProductosDetaCLN CotizacionProductosDetalleCLN
        {
            get
            {
                if (_CotizacionesProductosDetalleCLN == null)
                    _CotizacionesProductosDetalleCLN = new CotizacionVentasProductosDetaCLN();
                return _CotizacionesProductosDetalleCLN;
            }
        }

        public FCotizacionesVentas(int NumeroAgencia, int NumeroPC, int CodigoUsuario)
        {
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            this.CodigoUsuario = CodigoUsuario;

            InitializeComponent();


            dGVProductosSeleccionados.DataSource = bdSourceCotizacionesProductosDetalle;
            dGVProductosSeleccionados.AutoGenerateColumns = false;

            _DTProductosSeleccionados = new DataTable();
            _DTClientes = new DataTable();
            _DTCotizacionesProductos = new DataTable();
            _DTCotizacionesProductosDetalle = new DataTable();
            _DTCotizacionesProductosTemporal = new DataTable();
            _DTCotizacionesProductosDetalleTemporal = new DataTable();
            _DTMonedas = new DataTable();
            _DTUsuarios = new DataTable();

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

            numeroCotizacion = CotizacionUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos");

            _DTCotizacionesProductos = CotizacionProductosCLN.ObtenerCotizacionVentaProducto(NumeroAgencia, numeroCotizacion);
            bdSourceCotizacionesProductos.DataSource = _DTCotizacionesProductos;

            _DTCotizacionesProductosDetalle = CotizacionUtilidadesCLN.ListarDetalleDeCotizacion(NumeroAgencia, numeroCotizacion);
            bdSourceCotizacionesProductosDetalle.DataSource = _DTCotizacionesProductosDetalle;
            _DTCotizacionesProductosDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadCotizacionVenta*PrecioUnitarioCotizacionVenta");


            fProductosBusqueda = new FProductosBusqueda(NumeroAgencia, NumeroPC, 'T', CodigoMonedaSistema);


            _DTCotizacionesProductosTemporal = _DTCotizacionesProductos.Clone();
            _DTCotizacionesProductosDetalleTemporal = _DTCotizacionesProductosDetalle.Clone();


            //Creación de la ralación maestro detalle!
            DSMaestroDetalle = new DataSet();



            _DTUsuarios = UsuarioCLN.ListarDatosUsuarioTransacciones();
            cBoxVendedor.DataSource = _DTUsuarios;
            cBoxVendedor.DisplayMember = "NombreUsuario";
            cBoxVendedor.ValueMember = "CodigoUsuario";

            _DTMonedas = MonedasCLN.ListarMonedas();
            cBoxMonedas.DataSource = _DTMonedas;
            cBoxMonedas.DisplayMember = "NombreMoneda";
            cBoxMonedas.ValueMember = "CodigoMoneda";

            

            //txtBoxObservaciones.DataBindings.Add(new Binding("Text", bdSourceCotizacionesProductos, "Observaciones", true));
            //txtBoxTiempoEntrega.DataBindings.Add(new Binding("Text", bdSourceCotizacionesProductos, "TiempoEntrega", true));
            //txtDiazValidez.DataBindings.Add(new Binding("Text", bdSourceCotizacionesProductos, "ValidezOferta", true));
            //cBoxMonedas.DataBindings.Add(new Binding("SelectedValue", bdSourceCotizacionesProductos, "CodigoMonedaCotizacionVenta", true));
            //cBoxCliente.DataBindings.Add(new Binding("SelectedValue", bdSourceCotizacionesProductos, "CodigoCliente", true));
            //cBoxVendedor.DataBindings.Add(new Binding("SelectedValue", bdSourceCotizacionesProductos, "CodigoUsuario", true));            
            //toolStripFechaCotizacion.DataBindings.Add(new Binding("Text", bdSourceCotizacionesProductos, "FechaHoraVentaCotizacion", true));
            crearMaestroDetalle();

            dGVProductosSeleccionados.DataSource = bdSourceCotizacionesProductosDetalle;
            bdSourceCotizacionesProductos.MoveLast();

        }

        public void cargarClientesComboBox()
        {
            _DTClientes = ClienteCLN.ListarClientesVentas();
            cBoxCliente.DataSource = _DTClientes;
            cBoxCliente.DisplayMember = "NombreCliente";
            cBoxCliente.ValueMember = "CodigoCliente";
        }

        public void crearMaestroDetalle()
        {
            DSMaestroDetalle.Locale = System.Globalization.CultureInfo.InvariantCulture;

            DataColumn ColumnPrimaryAgencia = new DataColumn();
            DataColumn ColumnPrimaryNumeroVentaCotizacion = new DataColumn();
            DataColumn ColumnForeignCodigoMoneda = new DataColumn();

            DataColumn ColumnForeignAgenciaDetalle = new DataColumn();
            DataColumn ColumnForeignNumeroVentaCotizacionDetalle = new DataColumn();
            DataColumn ColumnPrimaryCodigoMoneda = new DataColumn();

            ColumnPrimaryAgencia = _DTCotizacionesProductos.Columns[0];
            ColumnPrimaryNumeroVentaCotizacion = _DTCotizacionesProductos.Columns[1];
            //ColumnPrimaryCodigoMoneda = _DTMonedas.Columns[0];

            ColumnForeignAgenciaDetalle = _DTCotizacionesProductosDetalle.Columns[0];
            ColumnForeignNumeroVentaCotizacionDetalle = _DTCotizacionesProductosDetalle.Columns[1];
            // ColumnForeignCodigoMoneda = _DTCotizacionesProductos.Columns["CodigoMonedaCotizacionVenta"];

            if (DSMaestroDetalle.Relations.Count > 0)
                DSMaestroDetalle.Relations.Clear();
            if (DSMaestroDetalle.Tables.Count > 0)
            {
                bdSourceCotizacionesProductosDetalle.DataMember = "";
                bdSourceCotizacionesProductos.DataMember = "";
                DSMaestroDetalle.Tables[1].Constraints.Remove("VentasCotizacionesProductosMaestroDetalle");
                DSMaestroDetalle.Tables[0].Constraints.Clear();
                DSMaestroDetalle.Tables[1].Constraints.Clear();
                DSMaestroDetalle.Tables.RemoveAt(1);
                DSMaestroDetalle.Tables.Clear();
            }

            DSMaestroDetalle.Tables.Add(_DTCotizacionesProductos);
            DSMaestroDetalle.Tables.Add(_DTCotizacionesProductosDetalle);
            //DSDevoluciones.Tables.Add(_DTMonedas);
            DataRelation relacionMaestroDetalle = new DataRelation("VentasCotizacionesProductosMaestroDetalle", new DataColumn[] { ColumnPrimaryAgencia, ColumnPrimaryNumeroVentaCotizacion }, new DataColumn[] { ColumnForeignAgenciaDetalle, ColumnForeignNumeroVentaCotizacionDetalle }, true);
            DSMaestroDetalle.Relations.Add(relacionMaestroDetalle);

            //DataRelation relacionMonedas = new DataRelation("MonedasCotizacion", ColumnPrimaryCodigoMoneda, ColumnForeignCodigoMoneda,true);
            //DSDevoluciones.Relations.Add(relacionMonedas);


            bdSourceCotizacionesProductos.DataSource = DSMaestroDetalle;
            bdSourceCotizacionesProductos.DataMember = "CotizacionVentasProductos";

            bdSourceCotizacionesProductosDetalle.DataSource = bdSourceCotizacionesProductos;
            bdSourceCotizacionesProductosDetalle.DataMember = "VentasCotizacionesProductosMaestroDetalle";

            bdNavDetalleCotizacion.BindingSource = bdSourceCotizacionesProductosDetalle;

        }


        /// <summary>
        /// Se encarga de Formatear las Columnas del DataGridView ProductosSeleccionados
        /// de Acuerdo a la Operación que se desea mostrar
        /// en caso de que se desea mostrar el detalle de una Cotización ya Realizada, pasar como parametro false,
        /// caso contrario True, para mostrar el Detalle Actual de una Venta en Curso
        /// </summary>
        /// <param name="esParaVender"> si La Venta se lleva en Curso</param>
        public void formatearEstiloTabla(bool esParaCotizar)
        {
            if (esParaCotizar)
            {

                DGCCodigoProducto.Width = 80;
                DGCNombreProducto.Width = 350;

                DGCCodigoProducto.DataPropertyName = "Código Producto";                
                DGCNombreProducto.DataPropertyName = "Nombre Producto";
                DGCCantidadVenta.DataPropertyName = "Cantidad";
                DGCPrecioUnitarioCotizacionVenta.DataPropertyName = "Precio";
                DGCPrecioTotal.DataPropertyName = "PrecioTotal";
                DGCTiempoGarantiaCotizacionVenta.DataPropertyName = "Garantia";
                
            }
            else
            {
                DGCCodigoProducto.Width = 80;
                DGCNombreProducto.Width = 350;

                DGCCodigoProducto.DataPropertyName = "CodigoProducto";
                DGCNombreProducto.DataPropertyName = "NombreProducto";
                DGCCantidadVenta.DataPropertyName = "CantidadCotizacionVenta";
                DGCPrecioUnitarioCotizacionVenta.DataPropertyName = "PrecioUnitarioCotizacionVenta";
                DGCPrecioTotal.DataPropertyName = "PrecioTotal";
                DGCTiempoGarantiaCotizacionVenta.DataPropertyName = "TiempoGarantiaCotizacionVenta";
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
            cBoxMonedas.Enabled = EstadoHabilitacion;
            txtBoxTiempoEntrega.Enabled = EstadoHabilitacion;
            txtDiazValidez.Enabled = EstadoHabilitacion;
            txtBoxObservaciones.ReadOnly = !EstadoHabilitacion;
            checkBIncluirFactura.Enabled = EstadoHabilitacion;
            btnBuscarCliente.Enabled = EstadoHabilitacion;
            btnRegistrarCliente.Enabled = EstadoHabilitacion;
            cMenuObservaciones.Enabled = !EstadoHabilitacion;
        }


        ///// <summary>
        ///// Método que se encarga de la correspondiente habilitacion de los botones que controlan
        ///// la transacción de la venta, de acuerdo al Estado en que se encuentra la misma
        ///// Pasar valores booleanoes en caso de desear habilitar TRUE, caso contrario FALSE
        ///// </summary>
        ///// <param name="nuevaVenta">Habilitar una Nueva Cotizacion</param>
        ///// <param name="modificar">Modificar la Cotizacion que se Cursa Actualmente</param>
        ///// <param name="cancelar">Cancelar la Cotizacion</param>
        ///// <param name="anular">Anular la Cotizacion</param>
        ///// <param name="aceptar">Confirmar la Cotizacion para recibir el Monto de Pago</param>
        ///// <param name="finalizar">Finalizar completamente la Cotizacion una vez terminada toda la Transacción</param>
        ///// 


        /// <summary>
        /// Método que se encarga de la correspondiente habilitacion de los botones que controlan
        /// la transacción de la venta, de acuerdo al Estado en que se encuentra la misma
        /// Pasar valores booleanoes en caso de desear habilitar TRUE, caso contrario FALSE
        /// </summary>
        /// <param name="nuevaVenta">Habilitar una Nueva Cotizacion</param>
        /// <param name="nuevaCotInstitucional">Habilitar una Nueva Cotización Institucional</param>
        /// <param name="nuevaDesdeOtra">Nueva Cotización a partir de una Cotización</param>
        /// <param name="modificar">Modificar la Cotizacion que se Cursa Actualmente</param>
        /// <param name="cancelar">Cancelar la Cotizacion</param>
        /// <param name="anular">Anular la Cotizacion</param>
        /// <param name="reporte">Mostrar Reportes</param>
        /// <param name="aceptar">Confirmar la Cotizacion para recibir el Monto de Pago</param>
        /// <param name="finalizar">Finalizar completamente la Cotizacion una vez terminada toda la Transacción</param>
        /// <param name="vender">Vender la Cotización Actual</param>
        /// <param name="buscar">Buscar una Cotización</param>
        private void habilitarBotonesCotizaciones(bool nuevaVenta, bool nuevaCotInstitucional, bool nuevaDesdeOtra, bool modificar, bool cancelar, bool anular, bool reporte, bool aceptar, bool finalizar, bool vender, bool buscar)
        {
            btnNuevaCotizacion.Enabled = nuevaVenta;
            btnCotizacionInstitucional.Enabled = nuevaCotInstitucional;
            btnNuevoDesdeOtraCotizacion.Enabled = nuevaDesdeOtra;
            btnModificar.Enabled = modificar;
            btnCancelar.Enabled = cancelar;
            btnAnular.Enabled = anular;
            btnReporte.Enabled = reporte;
            btnAceptar.Enabled = aceptar;
            btnFinalizar.Enabled = finalizar;

            btnVender.Enabled = vender;
            btnBuscar.Enabled = buscar;
        }

        /// <summary>
        /// Se encarga de Cargar nuevamente los datos de la Base de datos
        /// para Actualizar el Formulario
        /// </summary>
        public void cargarDatosCotizaciones(int NumeroCotizacion)
        {
            this._DTProductosSeleccionados.Rows.Clear();
            this.fProductosBusqueda.nuevaVenta = true;

            DSMaestroDetalle.AcceptChanges();

            _DTCotizacionesProductos = CotizacionProductosCLN.ObtenerCotizacionVentaProducto(NumeroAgencia, NumeroCotizacion);
            _DTCotizacionesProductosDetalle = CotizacionUtilidadesCLN.ListarDetalleDeCotizacion(NumeroAgencia, NumeroCotizacion);
            _DTCotizacionesProductosDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadCotizacionVenta*PrecioUnitarioCotizacionVenta");
            if (_DTCotizacionesProductos.Rows.Count > 0)
            {
                CodigoTipoCotizacion = _DTCotizacionesProductos.Rows[0]["CodigoTipoCotizacion"].ToString();
            }

            crearMaestroDetalle();
            formatearEstiloTabla(false);
            bdSourceCotizacionesProductos.MoveLast();

            CodigoMonedaActual = int.Parse(cBoxMonedas.SelectedValue.ToString());
            if (CodigoMonedaActual != CodigoMonedaSistema)
            {
                DataTable DTDetalleProductosTemporal;
                DateTime FechaHoraVenta = DateTime.Parse(_DTCotizacionesProductos.Rows[0]["FechaHoraCotizacion"].ToString());
                if (_DTCotizacionesProductos.Rows[0]["ConFactura"].Equals(true))
                {
                    QuitarPrecioFacturaCotizacionEstatica();                    
                }
                DTDetalleProductosTemporal = CotizacionUtilidadesCLN.CambiarMonedaCotizacionDetalleDeTransaccion(NumeroAgencia, CodigoMonedaActual, FechaHoraVenta, checkBIncluirFactura.Checked, 'T', numeroCotizacion, true);
                bdSourceCotizacionesProductosDetalle.DataSource = DTDetalleProductosTemporal;
                dGVProductosSeleccionados.DataSource = bdSourceCotizacionesProductosDetalle;
                txtBoxPrecioTotal.Text = DTDetalleProductosTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + _DTMonedas.Rows.Find(CodigoMonedaActual)["MascaraMoneda"].ToString();                
            }
        }

        private void btnNuevaCotizacion_Click(object sender, EventArgs e)
        {
            if ((sender as ToolStripButton).Name.CompareTo("btnNuevaCotizacion") == 0)
            {
                CodigoTipoCotizacion = "N";
                lblTipoCotizacion.Text = "COT. NORMAL";
            }
            else
            {
                CodigoTipoCotizacion = "T";
                lblTipoCotizacion.Text = "COT. INSTITUCIONAL";
            }
            cBoxMonedas.SelectedValue = CodigoMonedaSistema;
            TipoOperacion = "N";
            cBoxVendedor.SelectedValue = CodigoUsuario;
            toolStripFechaCotizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            bdSourceCotizacionesProductos.DataSource = _DTCotizacionesProductosTemporal;
            _DTCotizacionesProductosDetalleTemporal = fProductosBusqueda.DTProductosSeleccionados;
            bdSourceCotizacionesProductosDetalle.DataSource = _DTCotizacionesProductosDetalleTemporal;
            formatearEstiloTabla(true);
            numeroCotizacion = CotizacionUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos");

            if (numeroCotizacion == 0) numeroCotizacion = 1;
            if (numeroCotizacion > 1)
                numeroCotizacion++;
            if (numeroCotizacion == 1 && _DTCotizacionesProductos.Rows.Count == 1)
                numeroCotizacion = 2;

            lblNumeroCotizacion.Text = numeroCotizacion.ToString();
            lblEstado.Text = "Iniciada";
            toolStripPBEstado.Value = (int)(toolStripPBEstado.Maximum) / 2;
            habilitarBotonesCotizaciones(false, false, false, true, true, false, false, true, false, false, false);
            fProductosBusqueda.LabelNombrePersonaTransaccion.Text = this.cBoxCliente.Text;
            fProductosBusqueda.LabelNumeroTransaccion.Text = this.numeroCotizacion.ToString();
            fProductosBusqueda.LabelNombreTransaccion.Text = "Numero Cotización";
            this.txtBoxPrecioTotal.Text = fProductosBusqueda.LabelPrecioTotal.Text;
            fProductosBusqueda.ShowDialog(this);

            if (fProductosBusqueda.DTGridViewProductosSeleccionados.Rows.Count > 0)
            {

                detallePrecioTotal = _DTCotizacionesProductosDetalleTemporal.Compute("sum(PrecioTotal)", "");
                if (detallePrecioTotal.ToString().Length > 0)
                    txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " " + MascaraMonedaSistema;
                else
                    txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
            }
            else
            {
                this.txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
                lblNumeroCotizacion.Text = "";
                toolStripPBEstado.Value = 0;
            }            
            txtBoxObservaciones.Clear();
            habilitarCampos(true);
            limpiarCampos();
            checkBIncluirFactura.Checked = false;
            cBoxCliente.Focus();
        }


        public void limpiarCampos()
        {
            cBoxCliente.SelectedIndex = -1;
            txtBoxObservaciones.Clear();
            txtBoxTiempoEntrega.Clear();
            txtDiazValidez.Clear();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cBoxCliente.SelectedValue != null)
            {
                if (_DTCotizacionesProductosDetalleTemporal.Rows.Count > 0)
                {

                    if (txtDiazValidez.Text.Trim().Length <= 0)
                    {
                        MessageBox.Show("No puede Ingresar Valores Vacios");
                        txtDiazValidez.Focus();
                        return;
                    }
                    if (txtBoxTiempoEntrega.Text.Trim().Length <= 0)
                    {
                        MessageBox.Show("No puede Ingresar Valores Vacios");
                        txtBoxTiempoEntrega.Focus();
                        return;
                    }

                    if (checkBIncluirFactura.Checked)
                    {
                        CodigoMonedaActual = int.Parse(cBoxMonedas.SelectedValue.ToString());
                        if (CodigoMonedaActual != CodigoMonedaSistema)
                            AumentarPrecioFactura(false);
                        if (MessageBox.Show(this, "Ha seleccionado incluir Factura en la Cotización. ¿Desea Continuar La Cotización con Factura?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }

                    //si no existió ningun error, se Procede a registrar la Venta
                    decimal precioTotal = decimal.Parse(_DTCotizacionesProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString());                    
                    //HABILITAR PARA INGRESAR EL DETALLE UNO POR UNO, CASO CONTRARIO PASAR COMO XML
                    //CotizacionProductosCLN.InsertarCotizacionVentaProducto(NumeroAgencia, Int16.Parse(cBoxCliente.SelectedValue.ToString().Trim()), CodigoUsuario, CotizacionUtilidadesCLN.ObtenerFechaHoraServidor(), Int16.Parse(txtDiazValidez.Text), Int16.Parse(txtBoxTiempoEntrega.Text), "I", false, Byte.Parse(cBoxMonedas.SelectedValue.ToString()), CodigoTipoCotizacion, checkBIncluirFactura.Checked, txtBoxObservaciones.Text);
                    //bdSourceCotizacionesProductosDetalle.MoveFirst();
                    //foreach (DataRow fila in this._DTCotizacionesProductosDetalleTemporal.Rows)
                    //{
                    //    CotizacionProductosDetalleCLN.InsertarCotizacionVentaProductoDeta(NumeroAgencia, numeroCotizacion, fila[0].ToString(), Int32.Parse(fila[2].ToString()), Decimal.Parse(fila[3].ToString()), int.Parse(fila["Garantia"].ToString()), Decimal.Parse(fila["PorcentajeDescuento"].ToString()), fila["NumeroPrecioSeleccionado"].ToString());
                    //    bdSourceCotizacionesProductosDetalle.MoveNext();
                    //}
                    if (_DTCotizacionesProductosDetalleTemporal.Select("[Nombre Producto] like '%Ñ%'").Length > 0
                                || _DTCotizacionesProductosDetalleTemporal.Select("[Nombre Producto] like '%ñ%'").Length > 0)
                    {
                        foreach (DataRow DRProducto in _DTCotizacionesProductosDetalleTemporal.Select("[Nombre Producto] like '%Ñ%'"))
                        {
                            DRProducto["Nombre Producto"] = DRProducto["Nombre Producto"].ToString().Replace('Ñ', 'N');
                        }

                        foreach (DataRow DRProducto in _DTCotizacionesProductosDetalleTemporal.Select("[Nombre Producto] like '%ñ%'"))
                        {
                            DRProducto["Nombre Producto"] = DRProducto["Nombre Producto"].ToString().Replace('ñ', 'n');
                        }
                    }

                    try
                    {
                        CotizacionProductosCLN.InsertarCotizacionVentaProductoXMLDetalle(NumeroAgencia, int.Parse(cBoxCliente.SelectedValue.ToString()), CodigoUsuario, CotizacionUtilidadesCLN.ObtenerFechaHoraServidor(), Int16.Parse(txtDiazValidez.Text), Int16.Parse(txtBoxTiempoEntrega.Text), "I", false, Byte.Parse(cBoxMonedas.SelectedValue.ToString()), CodigoTipoCotizacion, checkBIncluirFactura.Checked, txtBoxObservaciones.Text,
                            _DTCotizacionesProductosDetalleTemporal.DataSet.GetXml().Replace("ó", "o").Replace("_x0020_", ""), precioTotal, precioTotal, null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "No se pudo realizar la operación actual debido a que ocurrió la siguiente excepcion " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;                        
                    }
                    numeroCotizacion = CotizacionUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos");
                    cargarDatosCotizaciones(numeroCotizacion);
                    cBoxCliente.Focus();
                    btnFinalizar_Click(sender, e);
                    TipoOperacion = "";
                }
                else
                {
                    if (MessageBox.Show(this, "No Puede Realizar Esta Transacción sin Haber por lo Menos Seleccionado una Producto para su Cotización. \r\n ¿Desea Agregar Productos a la Cotización Actual?", "Verifique la Cotización", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        fProductosBusqueda.ShowDialog(this);
                    }
                    else
                    {
                        numeroCotizacion = CotizacionUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos");
                        cargarDatosCotizaciones(numeroCotizacion);
                    }
                }
            }
            else
            {
                cBoxCliente_Leave(sender, e);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "La finalización de una Cotizacion de Productos implica solamente Un Listado de Productos con su respectivo Precio." + Environment.NewLine + "La Misma no Implica la reserva de los Mismos. " + Environment.NewLine + "Pero Usted Puede finalizar la cotización convertiendola en una Venta" + Environment.NewLine + Environment.NewLine + "¿Desea Finalizar la Cotizacion de Productos?", "Cotizacion de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                int NumeroVentaCotizacionProducto = Int16.Parse(_DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position][1].ToString());
                //CotizacionProductosCLN.ActualizarCotizacionVentaProducto(NumeroAgencia, NumeroVentaCotizacionProducto, Int16.Parse(cBoxCliente.SelectedValue.ToString()), CodigoUsuario, CotizacionUtilidadesCLN.ObtenerFechaHoraServidor(), Int16.Parse(txtDiazValidez.Text), Int16.Parse(txtBoxTiempoEntrega.Text), "F", false, Byte.Parse(cBoxMonedas.SelectedValue.ToString().Trim()), CodigoTipoCotizacion, checkBIncluirFactura.Checked, txtBoxObservaciones.Text, 
                //    decimal.Parse(_DTCotizacionesProductosDetalle.Compute("PrecioTotal","").ToString()) ,
                //    decimal.Parse(_DTCotizacionesProductosDetalle.Compute("PrecioTotal", "").ToString()), 
                //    null, null);

                _CotizacionesProductosCLN.ActualizarCoditoEstadoCotizacion(NumeroAgencia, NumeroVentaCotizacionProducto, "F");
                //CotizacionUtilidadesCLN.ActualizarInventarioProductosCotizaciones(_NumeroAgencia, NumeroVentaCotizacionProducto);
                int indiceActual = bdSourceCotizacionesProductos.Position;
                numeroCotizacion = CotizacionUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos");
                cargarDatosCotizaciones(numeroCotizacion);
                bdSourceCotizacionesProductos.Position = indiceActual;
                habilitarBotonesCotizaciones(true, true, true, false, false, false, true, false, false, true, true);
            }
        }

        private void cBoxCliente_Leave(object sender, EventArgs e)
        {

        }

        private void bdSourceCotizacionesProductos_CurrentChanged(object sender, EventArgs e)
        {
            if (_DTCotizacionesProductosDetalle.Rows.Count > 0 && _DTCotizacionesProductosDetalle.Columns.Count > 7 && bdSourceCotizacionesProductos.Position != -1)
            {
                string filtro = "NumeroAgencia = " + NumeroAgencia.ToString() + " and  NumeroCotizacionVentaProducto = " + _DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position][1].ToString();
                detallePrecioTotal = _DTCotizacionesProductosDetalle.Compute("sum(PrecioTotal)", filtro);
                if (detallePrecioTotal.ToString().Length > 0)
                    txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " " + MascaraMonedaSistema;
                else
                    txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
                //habilitar
                lblNumeroCotizacion.Text = _DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position][1].ToString();
                if (cBoxCliente.DataSource == null || _DTClientes.Rows.Count == 0)
                {
                    string CodigoCliente = _DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["CodigoCliente"].ToString();
                    _DTClientes = ClienteCLN.ObtenerCliente(int.Parse(CodigoCliente));

                    cBoxCliente.Items.Clear();
                    cBoxCliente.Items.Add(_DTClientes.Rows[0]["NombreCliente"].ToString().Trim());
                    cBoxCliente.SelectedIndex = 0;
                }
                else
                {
                    cBoxCliente.SelectedValue = _DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["CodigoCliente"].ToString();
                }
                if (_DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["CodigoEstadoCotizacion"].ToString().CompareTo("F") == 0)
                {
                    lblEstado.Text = "Finalizada";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum;
                    habilitarBotonesCotizaciones(true, true, true, false, false, false, true, false, false, true, true);
                    habilitarCampos(false);
                }
                if (_DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["CodigoEstadoCotizacion"].ToString().CompareTo("C") == 0)
                {
                    lblEstado.Text = "Cancelada";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum;
                    habilitarBotonesCotizaciones(true, true, true, false, false, false, false, false, false, false, true);
                    habilitarCampos(false);
                }
                if (_DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["CodigoEstadoCotizacion"].ToString().CompareTo("I") == 0)
                {
                    lblEstado.Text = "Iniciada";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum / 2;
                    habilitarBotonesCotizaciones(true, true, true, false, false, true, true, false, true, false, true);
                    habilitarCampos(false);
                }
                if (_DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["CodigoEstadoCotizacion"].ToString().CompareTo("A") == 0)
                {
                    lblEstado.Text = "Anulada";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum / 2;
                    habilitarBotonesCotizaciones(true, true, true, false, false, false, false, false, false, false, true);
                    habilitarCampos(false);
                }
            }
            else
            {
                txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
            }
            if (bdSourceCotizacionesProductos.Position != -1 && _DTCotizacionesProductos.Rows.Count > 0)
            {
                //cBoxCliente.SelectedValue = _DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["CodigoCliente"].ToString();
                toolStripFechaCotizacion.Text = _DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["FechaHoraCotizacion"].ToString();
                cBoxVendedor.SelectedValue = _DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["CodigoUsuario"].ToString();
                checkBInmediata.Checked = _DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["TiempoEntrega"].ToString().Equals("0");
                txtBoxTiempoEntrega.Text = _DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["TiempoEntrega"].ToString();
                txtDiazValidez.Text = _DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["ValidezOferta"].ToString();
                checkBIncluirFactura.Checked = _DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["ConFactura"].Equals(true) ? true : false;
                lblTipoCotizacion.Text = _DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["CodigoTipoCotizacion"].ToString().CompareTo("N") == 0 ? "COT. NORMAL" : "COT. INSTITUCIONAL";
                cBoxMonedas.SelectedValue = _DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["CodigoMonedaCotizacionVenta"];
                txtBoxObservaciones.Text = _DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["Observaciones"].ToString();
            }
            else
            {
                habilitarCampos(false);
                habilitarBotonesCotizaciones(true, true, true, false, false, false, false, false, false, false, true);
            }
        }

        private void dGVProductosSeleccionados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btnNuevaCotizacion.Enabled)
                    btnNuevaCotizacion_Click(sender, e as EventArgs);
                else
                    MessageBox.Show(this, "No Puede Iniciar una mueva Cotización, sin haber concluido la que se lleva en curso", "Cotizaciones de Productos no Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (btnAceptar.Enabled)
                    btnAceptar_Click(sender, e as EventArgs);
                else
                    MessageBox.Show(this, "No Puede Aceptar una mueva Cotización, sin haberla inciado", "Cotizaciones de Productos no Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Control && e.KeyCode == Keys.F)
            {
                if (btnFinalizar.Enabled)
                    btnFinalizar_Click(sender, e as EventArgs);
                else
                    MessageBox.Show(this, "No Puede Aceptar una mueva Cotización, sin haberla inciado", "Cotizaciones de Productos no Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            /*if (ventaConFactura && TipoOperacion == "N")
                DTVentasProductosDetalleTemporal.RejectChanges();
            

            fProductosBusqueda.ShowDialog(this);

            if (fProductosBusqueda.DTProductosSeleccionados.Rows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún Producto para su Venta, se procederá a cancelar la operación Actual");
                btnCancelar_Click(sender, e);
                return;
            }

            existenModificacionesEspecificos = true;
            existenModificacionesAgregados = true;
            verificarProductosEspecificosAgregados();
            revisarProductosInalcanzables();

            this.txtBoxPrecioTotal.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false").ToString() + " " + MascaraMoneda;
            this.txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMoneda;
            tabControl1.SelectedIndex = 0;
            if (ventaConFactura)
                AumentarPrecioFactura(TipoOperacion == "N" ? false : true);*/


            if (cotizacionConFactura)
                _DTCotizacionesProductosDetalleTemporal.RejectChanges();
            fProductosBusqueda.ShowDialog(this);
            detallePrecioTotal = _DTCotizacionesProductosDetalleTemporal.Compute("sum(PrecioTotal)", "");
            if (detallePrecioTotal.ToString().Length > 0)
                txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " " + MascaraMonedaSistema;
            else
                txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
            if (cotizacionConFactura)
                AumentarPrecioFactura();
        }

        private void FCotizacionesVentas_Shown(object sender, EventArgs e)
        {
            formatearEstiloTabla(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            numeroCotizacion = CotizacionUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos");
            cBoxMonedas.SelectedValue = CodigoMonedaSistema;
            cargarDatosCotizaciones(numeroCotizacion);
            //habilitarBotonesCotizaciones(true, true, true, false
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            DataTable VentaProductosTemporal = new DataTable();
            DataTable VentasProductosDetalleTemporal = new DataTable();

            //VentaProductosTemporal = CotizacionProductosCLN.ObtenerCotizacionVentaProducto(NumeroAgencia, Int32.Parse(_DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["NumeroCotizacionVentaProducto"].ToString()));
            VentaProductosTemporal = CotizacionProductosCLN.ObtenerCotizacionVentaProducto(NumeroAgencia, numeroCotizacion);
            //VentasProductosDetalleTemporal = CotizacionUtilidadesCLN.ListarDetalleDeCotizacionParaVenta(NumeroAgencia, Int32.Parse(_DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position]["NumeroCotizacionVentaProducto"].ToString()));
            VentasProductosDetalleTemporal = CotizacionUtilidadesCLN.ListarDetalleDeCotizacionParaVenta(NumeroAgencia, this.numeroCotizacion);            
            string TipoCotizacion = VentaProductosTemporal.Rows[0]["CodigoTipoCotizacion"].ToString();
            DateTime FechaCotizacion = DateTime.Parse(VentaProductosTemporal.Rows[0]["FechaHoraCotizacion"].ToString());
            int ValidezOferta = int.Parse(VentaProductosTemporal.Rows[0]["ValidezOferta"].ToString());
            DateTime FechaActual = CotizacionUtilidadesCLN.ObtenerFechaHoraServidor();
            if (FechaActual <= (FechaCotizacion.AddDays(ValidezOferta)))
            {
                FVentasProductos _FVentasProductos = new FVentasProductos(NumeroAgencia, NumeroPC, CodigoUsuario);

                if (TipoCotizacion.Equals("T"))
                {
                    _FVentasProductos.CodigoTipoVenta = TipoCotizacion[0];
                }
                _FVentasProductos.emitirPermisos(true, true, true, true, true, true, false);
                _FVentasProductos.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
                _FVentasProductos.ListarDetalledeCotizacionParaVenta(VentaProductosTemporal, VentasProductosDetalleTemporal, TipoCotizacion, sender, e);
                _FVentasProductos.ShowDialog(this);
                _FVentasProductos.Dispose();
            }
            else
            {
                MessageBox.Show("No puede Culminar esta cotización en una Venta, debido a que los días de Validez ya vencieron");
            }

            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FBuscarTransaccion formBuscarTransaccion = new FBuscarTransaccion(NumeroAgencia);
            formBuscarTransaccion.formatearEstiloParaCotizaciones();
            formBuscarTransaccion.ShowDialog(this);            
            this.numeroCotizacion = formBuscarTransaccion.NumeroTransaccion;
            if (numeroCotizacion > 0)
            {
                cargarDatosCotizaciones(numeroCotizacion);
                formBuscarTransaccion.Dispose();
            }
            else
            {
                MessageBox.Show(this, "No se encontro ninguna Cotización de Venta con los parametros o Descripción que usted Acaba de Ingresar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataTable DTListarDatosClienteCotizacionesVentaReporte;
            DataTable DTListarCotizacionVentasProductosDetalleReporte;

            DTListarCotizacionVentasProductosDetalleReporte = CotizacionProductosDetalleCLN.ListarCotizacionVentasProductosDetalleReporte(NumeroAgencia, numeroCotizacion);
            DTListarDatosClienteCotizacionesVentaReporte = CotizacionProductosCLN.ListarDatosClienteCotizacionesVentaReporte(NumeroAgencia, numeroCotizacion);

            FReporteCotizacionesVentasProductos formReporteCotizacion;
            if (MessageBox.Show(this, "¿Desea que el Reporte incluya los Precios?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                formReporteCotizacion = new FReporteCotizacionesVentasProductos(DTListarCotizacionVentasProductosDetalleReporte, DTListarDatosClienteCotizacionesVentaReporte, true);
            else
                formReporteCotizacion = new FReporteCotizacionesVentasProductos(DTListarCotizacionVentasProductosDetalleReporte, DTListarDatosClienteCotizacionesVentaReporte, false);

            formReporteCotizacion.ShowDialog(this);
            formReporteCotizacion.Dispose();
        }

        private void NuevaCotizacionDesdeOtraCotizacion_Click(object sender, EventArgs e)
        {
            FBuscarTransaccion formBuscarTransaccion = new FBuscarTransaccion(NumeroAgencia);
            formBuscarTransaccion.formatearEstiloParaCotizaciones();
            formBuscarTransaccion.ShowDialog(this);
            int NumeroCotizacionBuscada = formBuscarTransaccion.NumeroTransaccion;
            if (numeroCotizacion > 0)
            {
                _DTCotizacionesProductosDetalleTemporal.Clear();
                //cargarDatosCotizaciones(numeroCotizacion);
                toolStripFechaCotizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                bdSourceCotizacionesProductos.DataSource = _DTCotizacionesProductosTemporal;
                _DTCotizacionesProductosDetalleTemporal = fProductosBusqueda.DTProductosSeleccionados;
                bdSourceCotizacionesProductosDetalle.DataSource = _DTCotizacionesProductosDetalleTemporal;
                formatearEstiloTabla(true);
                numeroCotizacion = CotizacionUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos");

                CodigoTipoCotizacion = "N";

                if (numeroCotizacion == 0) numeroCotizacion = 1;
                if (numeroCotizacion > 1)
                    numeroCotizacion++;
                if (numeroCotizacion == 1 && _DTCotizacionesProductos.Rows.Count == 1)
                    numeroCotizacion = 2;

                lblNumeroCotizacion.Text = numeroCotizacion.ToString();
                lblEstado.Text = "Iniciada";
                toolStripPBEstado.Value = (int)(toolStripPBEstado.Maximum) / 2;

                habilitarBotonesCotizaciones(false, false, false, true, true, false, false, true, false, false, false);
                fProductosBusqueda.LabelNombrePersonaTransaccion.Text = this.cBoxCliente.Text;
                fProductosBusqueda.LabelNumeroTransaccion.Text = this.numeroCotizacion.ToString();
                fProductosBusqueda.LabelNombreTransaccion.Text = "Numero Cotización";
                this.txtBoxPrecioTotal.Text = fProductosBusqueda.LabelPrecioTotal.Text;

                _DTCotizacionesProductosDetalle = CotizacionUtilidadesCLN.ListarDetalleDeCotizacion(NumeroAgencia, NumeroCotizacionBuscada);
                _DTCotizacionesProductosDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadCotizacionVenta*PrecioUnitarioCotizacionVenta");

                foreach (DataRow filaNueva in _DTCotizacionesProductosDetalle.Rows)
                {
                    DataRow filaCopiada = fProductosBusqueda.DTProductosSeleccionados.NewRow();
                    filaCopiada.BeginEdit();
                    filaCopiada["Código Producto"] = filaNueva["CodigoProducto"];
                    filaCopiada["Nombre Producto"] = filaNueva["NombreProducto"];
                    filaCopiada["Cantidad"] = filaNueva["CantidadCotizacionVenta"];
                    filaCopiada["Precio"] = filaNueva["PrecioUnitarioCotizacionVenta"];
                    filaCopiada["PrecioTotal"] = filaNueva["PrecioTotal"];
                    filaCopiada["Garantia"] = filaNueva["TiempoGarantiaCotizacionVenta"];
                    filaCopiada["PorcentajeDescuento"] = filaNueva["PorcentajeDescuento"];
                    filaCopiada["NumeroPrecioSeleccionado"] = filaNueva["NumeroPrecioSeleccionado"];
                    fProductosBusqueda.DTProductosSeleccionados.Rows.Add(filaCopiada);
                    filaCopiada.AcceptChanges();
                }
                
                checkBIncluirFactura.Checked = false;
                habilitarCampos(true);
                cBoxCliente.Focus();
                fProductosBusqueda.nuevaVenta = false;
                TipoOperacion = "";
                if (_CotizacionesProductosCLN.EsCotizacionConFactura(NumeroAgencia, NumeroCotizacionBuscada))
                {
                    cotizacionConFactura = true;

                    btnNuevaCotizacion.Enabled = true;
                    checkBIncluirFactura.Checked = true;
                    btnNuevaCotizacion.Enabled = false;

                    QuitarPrecioFactura(true);
                }
                else
                    cotizacionConFactura = false;

                cBoxMonedas.SelectedValue = CodigoMonedaSistema;
                detallePrecioTotal = _DTCotizacionesProductosDetalleTemporal.Compute("sum(PrecioTotal)", "");
                if (detallePrecioTotal.ToString().Length > 0)
                    txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " " + MascaraMonedaSistema;
                else
                    txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
                

                fProductosBusqueda.ShowDialog(this);
                formBuscarTransaccion.Dispose();

                if (fProductosBusqueda.DTGridViewProductosSeleccionados.Rows.Count > 0)
                {

                    detallePrecioTotal = _DTCotizacionesProductosDetalleTemporal.Compute("sum(PrecioTotal)", "");
                    if (detallePrecioTotal.ToString().Length > 0)
                        txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " " + MascaraMonedaSistema;
                    else
                        txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
                }
                else
                {
                    this.txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
                    lblNumeroCotizacion.Text = "";
                    toolStripPBEstado.Value = 0;
                    MessageBox.Show("No tiene Seleccionado ningún Producto");
                    btnCancelar_Click(sender, e);
                }

                if (cotizacionConFactura)
                    AumentarPrecioFactura(true);

                
                TipoOperacion = "N";
            }
            else
            {
                MessageBox.Show(this, "No se encontro ninguna Cotización de Venta con los parametros o Descripción que usted Acaba de Ingresar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FCambiarMonedaCotizacionDeTransaccionesGC formCambioMoneda;
            if (btnAceptar.Enabled)
            {
                formCambioMoneda = new FCambiarMonedaCotizacionDeTransaccionesGC(_DTCotizacionesProductosDetalleTemporal,NumeroPC, NumeroAgencia, numeroCotizacion, CotizacionUtilidadesCLN, 'I');
            }
            else
            {
                formCambioMoneda = new FCambiarMonedaCotizacionDeTransaccionesGC(_DTCotizacionesProductosDetalle, NumeroPC, NumeroAgencia, numeroCotizacion,CotizacionUtilidadesCLN, 'F');
            }
            formCambioMoneda.DarEstiloParaCotizaciones();
            formCambioMoneda.ShowDialog(this);
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            FBuscarClientes formClientes = new FBuscarClientes();
            formClientes.ShowDialog(this);
            int CodigoCliente = formClientes.CodigoCliente;
            if (CodigoCliente >= 0)
            {
                cBoxCliente.SelectedValue = CodigoCliente.ToString();
            }
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            FClientes formClientes = new FClientes(true, false, false, true);
            formClientes.ShowDialog(this);
            string tuplaCliente = ClienteCLN.ObtenerUltimoClienteInsertado();
            string[] atributosUltimoCliente = tuplaCliente.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            DataRow FilaCliente = _DTClientes.Rows.Find(atributosUltimoCliente[0].Trim());
            if (FilaCliente == null)
            {
                FilaCliente = _DTClientes.NewRow();
                FilaCliente["CodigoCliente"] = atributosUltimoCliente[0];
                FilaCliente["NombreCliente"] = atributosUltimoCliente[1];
                FilaCliente["NITCliente"] = atributosUltimoCliente[2];
                _DTClientes.Rows.Add(FilaCliente);
                cBoxCliente.BeginUpdate();
                FilaCliente.AcceptChanges();
                _DTClientes.AcceptChanges();
                cBoxCliente.DataSource = null;
                cBoxCliente.Items.Clear();

                _DTClientes.DefaultView.Sort = "NombreCliente ASC";
                cBoxCliente.DataSource = _DTClientes;
                cBoxCliente.DisplayMember = "NombreCliente";
                cBoxCliente.ValueMember = "CodigoCliente";

                cBoxCliente.EndUpdate();
                //cBoxCliente.SelectedValue = CodigoCliente.ToString();
                cBoxCliente.SelectedItem = atributosUltimoCliente[2].Trim();
                cBoxCliente.SelectedValue = atributosUltimoCliente[0];

            }
        }

        private void cBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxCliente.DataSource == null)
            {
                cargarClientesComboBox();
                cBoxCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
                cBoxCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        private void btnVender_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVender_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }


        private void checkBIncluirFactura_CheckedChanged(object sender, EventArgs e)
        {
            if (!btnNuevaCotizacion.Enabled && !btnCotizacionInstitucional.Enabled)
            {

                if (checkBIncluirFactura.Checked)
                {
                    AumentarPrecioFactura();
                    cotizacionConFactura = true;
                }
                else
                {
                    QuitarPrecioFactura();
                    cotizacionConFactura = false;
                }
            }
        }

        public void AumentarPrecioFactura(bool esVentaConfirmada)
        {
            if (_DTCotizacionesProductosDetalleTemporal.Rows.Count > 0)
            {
                decimal PrecioNuevo = 0;
                int cantidad = 0;
                _DTCotizacionesProductosDetalleTemporal.Columns["PrecioTotal"].ReadOnly = false;
                if (esVentaConfirmada)
                {
                    foreach (DataRow FilaVentaDetalle in _DTCotizacionesProductosDetalleTemporal.Rows)
                    {
                        DataRow FilaEncontrada = _DTCotizacionesProductosDetalle.Rows.Find(FilaVentaDetalle[0].ToString());
                        if (FilaEncontrada != null) // si existe ese producto en el anterior detalle
                        {
                            FilaVentaDetalle["Precio"] = FilaEncontrada["PrecioUnitarioCotizacionVenta"];
                            FilaVentaDetalle["PrecioTotal"] = decimal.Parse(FilaEncontrada["PrecioUnitarioCotizacionVenta"].ToString()) * int.Parse(FilaVentaDetalle["Cantidad"].ToString());
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
                    foreach (DataRow FilaVentaDetalle in _DTCotizacionesProductosDetalleTemporal.Rows)
                    {
                        PrecioNuevo = decimal.Round(decimal.Parse(FilaVentaDetalle["Precio"].ToString()), 2);
                        cantidad = int.Parse(FilaVentaDetalle["Cantidad"].ToString());
                        PrecioNuevo = decimal.Round(PrecioNuevo * PorcentajeImpuestoSistema / 100, 2) + PrecioNuevo;

                        FilaVentaDetalle["Precio"] = decimal.Round(PrecioNuevo, 2);
                        FilaVentaDetalle["PrecioTotal"] = decimal.Round(PrecioNuevo * cantidad, 2);
                    }
                }
                this.txtBoxPrecioTotal.Text = _DTCotizacionesProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;
                _DTCotizacionesProductosDetalleTemporal.Columns["PrecioTotal"].ReadOnly = true;
            }
        }

        public void AumentarPrecioFactura()
        {
            CodigoMonedaActual = int.Parse(cBoxMonedas.SelectedValue.ToString());
            if (CodigoMonedaActual == CodigoMonedaSistema)
            {
                if (_DTCotizacionesProductosDetalleTemporal.Rows.Count > 0)
                {
                    decimal PrecioNuevo = 0;
                    int cantidad = 0;
                    _DTCotizacionesProductosDetalleTemporal.Columns["PrecioTotal"].ReadOnly = false;
                    foreach (DataRow FilaVentaDetalle in _DTCotizacionesProductosDetalleTemporal.Rows)
                    {
                        PrecioNuevo = decimal.Round(decimal.Parse(FilaVentaDetalle["Precio"].ToString()), 2);
                        cantidad = int.Parse(FilaVentaDetalle["Cantidad"].ToString());
                        PrecioNuevo = decimal.Round(PrecioNuevo * PorcentajeImpuestoSistema / 100, 2) + PrecioNuevo;

                        FilaVentaDetalle["Precio"] = decimal.Round(PrecioNuevo, 2);
                        FilaVentaDetalle["PrecioTotal"] = decimal.Round(PrecioNuevo * cantidad, 2);
                    }                    
                    this.txtBoxPrecioTotal.Text = _DTCotizacionesProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;
                    _DTCotizacionesProductosDetalleTemporal.Columns["PrecioTotal"].ReadOnly = true;
                }
            }
            else
            {
                cambiarCotizacion();
            }

            //_DTCotizacionesProductosDetalleTemporal.AcceptChanges();
        }

        public void QuitarPrecioFactura()
        {

            CodigoMonedaActual = int.Parse(cBoxMonedas.SelectedValue.ToString());
            if (CodigoMonedaActual == CodigoMonedaSistema)
            {
                if (_DTCotizacionesProductosDetalleTemporal.Rows.Count > 0)
                {
                    int CantidadEntregada = 0;
                    foreach (DataRow FilaProducto in _DTCotizacionesProductosDetalleTemporal.Rows)
                    {
                        CantidadEntregada = int.Parse(FilaProducto["CantidadEntregada"].ToString());
                        FilaProducto.RejectChanges();
                        FilaProducto["CantidadEntregada"] = CantidadEntregada;
                    }                    
                    this.txtBoxPrecioTotal.Text = _DTCotizacionesProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;
                }
            }
            else
                cambiarCotizacion();
        }

        public void QuitarPrecioFactura(bool esVentaConfirmada)
        {
            if (_DTCotizacionesProductosDetalleTemporal.Rows.Count > 0)
            {
                if (esVentaConfirmada)
                {
                    decimal PrecioNuevo = 0;
                    string CodigoProducto = "";
                    string NumeroPrecioSeleccionado = "";
                    int cantidad = 0;
                    _DTCotizacionesProductosDetalleTemporal.Columns["PrecioTotal"].ReadOnly = false;
                    foreach (DataRow FilaVentaDetalle in _DTCotizacionesProductosDetalleTemporal.Rows)
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
                            PrecioNuevo = CotizacionUtilidadesCLN.ObtenerPrecioRelativoProducto(NumeroAgencia, CodigoProducto, NumeroPrecioSeleccionado, false);
                        }                        

                        FilaVentaDetalle["Precio"] = PrecioNuevo;
                        FilaVentaDetalle["PrecioTotal"] = PrecioNuevo * cantidad;
                    }
                    _DTCotizacionesProductosDetalleTemporal.Columns["PrecioTotal"].ReadOnly = true;
                }
                else
                {
                    _DTCotizacionesProductosDetalleTemporal.RejectChanges();
                }
                this.txtBoxPrecioTotal.Text = _DTCotizacionesProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;                
            }
        }

        public void QuitarPrecioFacturaCotizacionEstatica()
        {
            if (_DTCotizacionesProductosDetalle.Rows.Count > 0)
            {               
                decimal PrecioNuevo = 0;
                string CodigoProducto = "";
                string NumeroPrecioSeleccionado = "";
                int cantidad = 0;
               //_DTCotizacionesProductosDetalle.Columns["PrecioTotal"].ReadOnly = false;
                foreach (DataRow FilaVentaDetalle in _DTCotizacionesProductosDetalle.Rows)
                {
                    NumeroPrecioSeleccionado = FilaVentaDetalle["NumeroPrecioSeleccionado"].ToString();
                    cantidad = int.Parse(FilaVentaDetalle["CantidadCotizacionVenta"].ToString());
                    if (NumeroPrecioSeleccionado.Equals("P")) // Precio Personalizado
                    {
                        PrecioNuevo = decimal.Parse(FilaVentaDetalle["PrecioUnitarioCotizacionVenta"].ToString());
                        PrecioNuevo = PrecioNuevo - PrecioNuevo * PorcentajeImpuestoSistema / 100;
                        PrecioNuevo = Decimal.Round(PrecioNuevo, 2);
                    }
                    else
                    {
                        CodigoProducto = FilaVentaDetalle["CodigoProducto"].ToString();
                        PrecioNuevo = CotizacionUtilidadesCLN.ObtenerPrecioRelativoProducto(NumeroAgencia, CodigoProducto, NumeroPrecioSeleccionado, false);
                    }

                    FilaVentaDetalle["PrecioUnitarioCotizacionVenta"] = PrecioNuevo;
                    //FilaVentaDetalle["PrecioTotal"] = PrecioNuevo * cantidad;
                }
                //DTCotizacionesProductosDetalle.Columns["PrecioTotal"].ReadOnly = true;

                this.txtBoxPrecioTotal.Text = _DTCotizacionesProductosDetalle.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;
            }
        }


        private void cBoxMonedas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TipoOperacion == "N" || TipoOperacion == "E")
            {
                CodigoMonedaActual = int.Parse(cBoxMonedas.SelectedValue.ToString());
                if (CodigoMonedaActual != CodigoMonedaSistema)
                {
                    cambiarCotizacion();
                }
                else
                {
                    bdSourceCotizacionesProductosDetalle.DataSource = _DTCotizacionesProductosDetalleTemporal;
                    dGVProductosSeleccionados.DataSource = bdSourceCotizacionesProductosDetalle;
                    txtBoxPrecioTotal.Text = _DTCotizacionesProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaSistema;                    
                    if (checkBIncluirFactura.Checked)
                        AumentarPrecioFactura();
                }

            }
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

        public void cambiarCotizacion()
        {
            if (checkBIncluirFactura.Checked)
            {
                if (_DTCotizacionesProductosDetalleTemporal.Rows.Count > 0)
                {
                    int CantidadEntregada = 0;
                    foreach (DataRow FilaProducto in _DTCotizacionesProductosDetalleTemporal.Rows)
                    {
                        CantidadEntregada = int.Parse(FilaProducto["CantidadEntregada"].ToString());
                        FilaProducto.RejectChanges();
                        FilaProducto["CantidadEntregada"] = CantidadEntregada;
                    }
                }
            }
            _DTCotizacionProductosTemporalCambioMoneda = CotizacionUtilidadesCLN.CambiarMonedaCotizacionDetalleDeTransaccionTemporal(_DTCotizacionesProductosDetalleTemporal, NumeroAgencia, int.Parse(cBoxMonedas.SelectedValue.ToString()), CotizacionUtilidadesCLN.ObtenerFechaHoraServidor(), checkBIncluirFactura.Checked, true);
            bdSourceCotizacionesProductosDetalle.DataSource = _DTCotizacionProductosTemporalCambioMoneda;
            dGVProductosSeleccionados.DataSource = bdSourceCotizacionesProductosDetalle;
            txtBoxPrecioTotal.Text = _DTCotizacionProductosTemporalCambioMoneda.Compute("sum(PrecioTotal)", "").ToString() + " " + _DTMonedas.Rows.Find(CodigoMonedaActual)["MascaraMoneda"].ToString();
            
        }

        private void FCotizacionesVentas_Load(object sender, EventArgs e)
        {
            DGCNombreProducto.Width = 300;
            DGCCodigoProducto.Width = 85;

            if (_DTCotizacionesProductos.Rows.Count > 0)
            {                
                CodigoMonedaActual = int.Parse(cBoxMonedas.SelectedValue.ToString());
                if (CodigoMonedaActual != CodigoMonedaSistema && _DTCotizacionesProductos.Rows.Count > 0 && _DTCotizacionesProductosDetalle.Rows.Count > 0)
                {
                    DataTable DTDetalleProductosTemporal;
                    if (_DTCotizacionesProductos.Rows[0]["ConFactura"].Equals(true))
                    {
                        QuitarPrecioFacturaCotizacionEstatica();                        
                    }
                    DateTime FechaHoraVenta = DateTime.Parse(_DTCotizacionesProductos.Rows[0]["FechaHoraCotizacion"].ToString());
                    DTDetalleProductosTemporal = CotizacionUtilidadesCLN.CambiarMonedaCotizacionDetalleDeTransaccion(NumeroAgencia, CodigoMonedaActual, FechaHoraVenta, checkBIncluirFactura.Checked, 'T', numeroCotizacion, true);
                    bdSourceCotizacionesProductosDetalle.DataSource = DTDetalleProductosTemporal;
                    dGVProductosSeleccionados.DataSource = bdSourceCotizacionesProductosDetalle;
                    txtBoxPrecioTotal.Text = DTDetalleProductosTemporal.Compute("sum(PrecioTotal)", "").ToString() + " " + _DTMonedas.Rows.Find(CodigoMonedaActual)["MascaraMoneda"].ToString();

                }
                else
                    cargarPieDetallePrecio();
            }
        }

        public void cargarPieDetallePrecio()
        {
            string filtro = "NumeroAgencia = " + NumeroAgencia.ToString() + " and  NumeroCotizacionVentaProducto = " + _DTCotizacionesProductos.Rows[0][1].ToString();
            object detallePrecioTotal = _DTCotizacionesProductosDetalle.Compute("sum(PrecioTotal)", filtro);            
            if (detallePrecioTotal.ToString().Length > 0)
            {
                txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " " + MascaraMonedaSistema;                
            }
            else
            {
                txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;                
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Desea Anular la Cotizacion de Productos?", "Cotizacion de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                int NumeroVentaCotizacionProducto = Int16.Parse(_DTCotizacionesProductos.Rows[bdSourceCotizacionesProductos.Position][1].ToString());
                
                _CotizacionesProductosCLN.ActualizarCoditoEstadoCotizacion(NumeroAgencia, NumeroVentaCotizacionProducto, "A");                
                int indiceActual = bdSourceCotizacionesProductos.Position;
                numeroCotizacion = CotizacionUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos");
                cargarDatosCotizaciones(numeroCotizacion);
                bdSourceCotizacionesProductos.Position = indiceActual;
                habilitarBotonesCotizaciones(true, true, true, false, false, false, true, false, false, true, true);
            }
        }

        private void txtDiazValidez_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && (((Keys)e.KeyChar)) != Keys.Back)
            {
                e.Handled = true;
                System.Media.SystemSounds.Hand.Play();
            }
        }

        private void detalladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTListarDatosCotizacionesVentaReporteDetallado;
            DataTable DTListarCotizacionVentasProductosDetalleReporteDetallado;
            DataTable DTListarProductosDescripcionCotizacion;

            DTListarCotizacionVentasProductosDetalleReporteDetallado = CotizacionProductosDetalleCLN.ListarCotizacionVentasProductosDetalleReporteDetallado(NumeroAgencia, numeroCotizacion);
            DTListarDatosCotizacionesVentaReporteDetallado = CotizacionProductosCLN.ListarDatosCotizacionesVentaReporteDetallado(NumeroAgencia, numeroCotizacion);
            DTListarProductosDescripcionCotizacion = CotizacionProductosCLN.ListarProductosDescripcionCotizacion(NumeroAgencia, numeroCotizacion);

            FReporteCotizacionesVentasProductos formReporteCotizacion;
            
            formReporteCotizacion = new FReporteCotizacionesVentasProductos();
            formReporteCotizacion.enviarTablasReporteAvanzado(DTListarCotizacionVentasProductosDetalleReporteDetallado, DTListarDatosCotizacionesVentaReporteDetallado, DTListarProductosDescripcionCotizacion);
            formReporteCotizacion.ShowDialog(this);
            formReporteCotizacion.Dispose();

        }

        private void checkBInmediata_CheckedChanged(object sender, EventArgs e)
        {            
            txtBoxTiempoEntrega.Text = !String.IsNullOrEmpty(TipoOperacion) && checkBInmediata.Checked ? "0" : "";
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FObservacionesTransaccionesModificacion _FObservacionesTransaccionesModificacion = new FObservacionesTransaccionesModificacion("T", CodigoUsuario, NumeroAgencia, numeroCotizacion);
            _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text = txtBoxObservaciones.Text;
            if (_FObservacionesTransaccionesModificacion.ShowDialog() == DialogResult.OK)
                txtBoxObservaciones.Text = _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text;
        }
    }
}
