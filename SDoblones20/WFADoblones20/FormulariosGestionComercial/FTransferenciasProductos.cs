using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
using CLCLN.Sistema;
using CLCAD;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FTransferenciasProductos : Form
    {
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        TransferenciasProductosCLN _TransferenciasProductosCLN;
        TransferenciasProductosDetalleCLN _TransferenciasProductosDetalleCLN;
        TransferenciasProductosEspecificosCLN _TransferenciasProductosEspecificosCLN;
        TransferenciasProductosGastosDetalleCLN _TransferenciasProductosGastosDetalleCLN;
        AgenciasCLN _AgenciasCLN;
        UsuariosCLN _UsuariosCLN;
        private PCsConfiguracionesCLN PCConfiguracion;

        DSDoblones20GestionComercial2.TransferenciasProductosDataTable DTTRansferenciasProductos;
        DSDoblones20GestionComercial2.ListarTransferenciasProductosDetalleParaMostrarDataTable DTTRansferenciasProductosDetalle;
        DSDoblones20GestionComercial2.ListarTransferenciasProductosEspecificosParaMostrarDataTable DTTransferenciasProductosEspecficos;
        DataTable DTTRansferenciasProductosDetalleTemporal;
        DataTable DTAgencias;
        DataTable DTUsuarios;
        private DataTable VariablesConfiguracionSistemaGC;
        

        FProductosBusqueda formProductosBusqueda;
        DataSet DSProductosEspecificos;
        int NumeroAgencia { get; set; }
        private int NumeroPC = 0;
        public bool ContabilidadIntegrada{get; set;}
        int CodigoUsuario { get; set; }
        int NumeroTransferenciaProducto { get; set; }
        string TipoOperacion = "";

        #region Propiedades de Configuración de Arranque del Sistema
        public decimal PorcentajeImpuestoSistema { get; set; }
        public int CodigoMonedaSistema { get; set; }
        public int CodigoMonedaRegion { get; set; }
        public string MascaraMonedaSistema { get; set; }
        public string MascaraMonedaRegion { get; set; }
        public string NombreMonedaSistema { get; set; }
        public string NombreMonedaRegion { get; set; }
        #endregion

        public FTransferenciasProductos(int NumeroAgencia, int NumeroPC, int CodigoUsuario)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            this.CodigoUsuario = CodigoUsuario;

            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _TransferenciasProductosCLN = new TransferenciasProductosCLN();
            _TransferenciasProductosDetalleCLN = new TransferenciasProductosDetalleCLN();
            _TransferenciasProductosEspecificosCLN = new TransferenciasProductosEspecificosCLN();
            _UsuariosCLN = new UsuariosCLN();
            _AgenciasCLN = new AgenciasCLN();
            _TransferenciasProductosGastosDetalleCLN = new TransferenciasProductosGastosDetalleCLN();


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

            formProductosBusqueda = new FProductosBusqueda(NumeroAgencia, NumeroPC, 'C', CodigoMonedaSistema);
            DSProductosEspecificos = new DataSet();
            dtGVProductos.AutoGenerateColumns = false;

           
            DTAgencias = _AgenciasCLN.ListarAgencias();
            cBoxAgencia.DataSource = DTAgencias;
            cBoxAgencia.ValueMember = "NumeroAgencia";
            cBoxAgencia.DisplayMember = "NombreAgencia";

            NumeroTransferenciaProducto = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("TransferenciasProductos");
            cargarTransferencias(NumeroTransferenciaProducto);
        }

        private void btnNuevaTransferencia_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            NumeroTransferenciaProducto = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("TransferenciasProductos");
            lblNumeroTransferencia.Text = NumeroTransferenciaProducto.ToString();
            lblFechaTransferencia.Text = String.Format("{0:G}", _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor());

            formatearTablaParaNuevaTransferencia(true);
            DTTRansferenciasProductosDetalleTemporal = formProductosBusqueda.DTProductosSeleccionados;
            dtGVProductos.DataSource = DTTRansferenciasProductosDetalleTemporal;


            formProductosBusqueda.LabelNombrePersonaTransaccion.Text = this.cBoxAgencia.Text;
            formProductosBusqueda.LabelNumeroTransaccion.Text = this.NumeroTransferenciaProducto.ToString();
            formProductosBusqueda.LabelNombreTransaccion.Text = "Nro Transferencia";
            formProductosBusqueda.limpiarControles();
            formProductosBusqueda.DTProductosBusqueda.Clear();
            formProductosBusqueda.DTProductosSeleccionados.Clear();
            formProductosBusqueda.ShowDialog(this);

            if (formProductosBusqueda.TransaccionConfirmada)
            {
                if (DTTRansferenciasProductosDetalleTemporal.Rows.Count > 0)
                {
                    object detallePrecioTotal = DTTRansferenciasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "");
                    if (detallePrecioTotal.ToString().Length > 0)
                        txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " " + MascaraMonedaSistema;
                    else
                        txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
                }
                else
                {
                    this.txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
                }                                
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningún Producto para su Transferencia, se procederá a cancelar la operación Actual");
                this.txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
                lblNumeroTransferencia.Text = "..";
                toolStripPBEstado.Value = 0;
                btnCancelar_Click(sender, e);
                return;
            }            
            habilitarCampos(true);
            TipoOperacion = "N";
            cBoxAgencia.Focus();
            DTUsuarios = _UsuariosCLN.ObtenerUsuario(CodigoUsuario);
            txtBoxEncargadoTransferencia.Text = getNombreCompletoUsuario();
            habilitarBotones(false, true, true, true, false, false, false, false);

        }

        public void habilitarCampos(bool habilitar)
        {
            txtBoxObservaciones.ReadOnly = !habilitar;
            cBoxAgencia.Enabled = habilitar;
            cMenuObservaciones.Enabled = !habilitar;
        }

        private void FTransferenciasProductos_Load(object sender, EventArgs e)
        {            
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

        }

        public void cargarTransferencias(int NumeroTransferencia)
        {
            this.NumeroTransferenciaProducto = NumeroTransferencia;
            DTTRansferenciasProductos = _TransferenciasProductosCLN.ObtenerTransferenciaProducto(NumeroAgencia, NumeroTransferencia);
            if (DTTRansferenciasProductos.Count > 0)
            {
                DTTRansferenciasProductosDetalle = _TransferenciasProductosDetalleCLN.ListarTransferenciasProductosDetalleParaMostrar(NumeroAgencia, NumeroTransferencia);
                DTTransferenciasProductosEspecficos = _TransferenciasProductosEspecificosCLN.ListarTransferenciasProductosEspecificosParaMostrar(NumeroAgencia, NumeroTransferencia, "S");

                if (!DTTRansferenciasProductosDetalle.Columns.Contains("PrecioTotal"))
                    //DTTRansferenciasProductosDetalle.Columns.Add("PrecioTotal", Type.GetType("System.Decimal"), "(PrecioUnitarioTransferencia * CantidadTransferencia) + MontoAdicionalPorGastos");
                    DTTRansferenciasProductosDetalle.Columns.Add("PrecioTotal", Type.GetType("System.Decimal"), "(PrecioUnitarioTransferencia + MontoAdicionalPorGastos ) * CantidadTransferencia");

                lblFechaTransferencia.Text = String.Format("{0:G}", DTTRansferenciasProductos[0].FechaHoraTransferencia);
                lblNumeroTransferencia.Text = NumeroTransferencia.ToString();
                txtBoxObservaciones.Text = DTTRansferenciasProductos[0].Observaciones;                
                cBoxAgencia.SelectedValue = DTTRansferenciasProductos[0].NumeroAgenciaRecepctora;
                DTUsuarios = _UsuariosCLN.ObtenerUsuario(CodigoUsuario);
                txtBoxEncargadoTransferencia.Text = getNombreCompletoUsuario();

                txtBoxPrecioTotal.Text = DTTRansferenciasProductosDetalle.Compute("sum(PrecioTotal)", "").ToString();
                switch (DTTRansferenciasProductos[0].CodigoEstadoTransferencia)
                {
                    case "I":
                        lblEstado.Text = "INICIADA";
                        toolStripPBEstado.Value = 33;
                        habilitarBotones(true, true, false, false, true, true, true, true);
                        break;
                    case "E":
                        lblEstado.Text = "EMITIDA Y ENVIADA";
                        toolStripPBEstado.Value = 60;
                        habilitarBotones(true, false, false, false, false, false, true, true);
                        break;
                    case "A":
                        lblEstado.Text = "ANULADA";
                        toolStripPBEstado.Value = 33;
                        habilitarBotones(true, false, false, false, false, false, true, true);
                        break;
                    case "D":
                        lblEstado.Text = "PENDIENTE";
                        toolStripPBEstado.Value = 85;
                        habilitarBotones(true, false, false, false, false, false, true, true);
                        break;
                    case "F":
                        lblEstado.Text = "FINALIZADA";
                        toolStripPBEstado.Value = 100;
                        habilitarBotones(true, false, false, false, false, false, true, true);
                        break;
                    case "P":
                        lblEstado.Text = "CON GASTOS";
                        toolStripPBEstado.Value = 100;
                        habilitarBotones(true, false, false, false, false, false, true, true);
                        break;
                    default:
                        lblEstado.Text = "NINGUNA";
                        toolStripPBEstado.Value = 0;
                        habilitarBotones(true, false, false, false, false, false, true, false);
                        break;
                }
                formatearTablaParaNuevaTransferencia(false);
                dtGVProductos.DataSource = DTTRansferenciasProductosDetalle;
                cargarDatosProductosEspecificos();
                habilitarCampos(false);
            }
            else
            {
                limpiarCampos();
                habilitarBotones(true, false, false, false, false, false, true, false);
                habilitarCampos(false);
            }

        }

        public string getNombreCompletoUsuario()
        {
            if (DTUsuarios.Rows.Count > 0)
                return DTUsuarios.Rows[0]["Paterno"].ToString().Trim() + " " + DTUsuarios.Rows[0]["Materno"].ToString().Trim() + " " +DTUsuarios.Rows[0]["Nombres"].ToString().Trim();
            else
                return "";
        }

        public void limpiarCampos()
        {
            cBoxAgencia.SelectedIndex = -1;
            txtBoxEncargadoTransferencia.Text = "";
            txtBoxObservaciones.Text = "";
            lblNumeroTransferencia.Text = "..";            
            lblEstado.Text = "Ninguno";
            toolStripPBEstado.Value = 0;
            lblFechaTransferencia.Text = String.Format("{0:G}", DateTime.Now);
        }

        /// <summary>
        /// Formatear las propiedades de las columnas
        /// para que referencien a su correspondiente campo
        /// de acuerdo a que si se carga un transferencia
        /// o se inicia una nueva
        /// </summary>
        /// <param name="esNuevaTransferencia"></param>
        public void formatearTablaParaNuevaTransferencia(bool esNuevaTransferencia)
        {
            if (esNuevaTransferencia)
            {
                DGCCodigoProductoDetalle.DataPropertyName = "Código Producto";
                DGCNombreProductoDetalle.DataPropertyName = "Nombre Producto";
                DGCCantidadDetalle.DataPropertyName = "Cantidad";
                DGCPrecioUnitarioCompra.DataPropertyName = "Precio";
                DGCPrecioTotalDetalle.DataPropertyName = "PrecioTotal";
                DGCMontoAdicionalPorGastos.DataPropertyName = "Garantia";
                DGCMontoAdicionalPorGastos.Visible = false;
                
            }
            else
            {
                DGCCodigoProductoDetalle.DataPropertyName = "CodigoProducto";
                DGCNombreProductoDetalle.DataPropertyName = "NombreProducto";
                DGCCantidadDetalle.DataPropertyName = "CantidadTransferencia";
                DGCPrecioUnitarioCompra.DataPropertyName = "PrecioUnitarioTransferencia";
                DGCPrecioTotalDetalle.DataPropertyName = "PrecioTotal";
                DGCMontoAdicionalPorGastos.Visible = true;
                DGCMontoAdicionalPorGastos.DataPropertyName = "MontoAdicionalPorGastos";
            }
        }


        /// <summary>
        /// Habilitar los botones y acciones
        /// de acuerdo al Estado de la Transferencia
        /// </summary>
        /// <param name="nuevaTransferencia"></param>
        /// <param name="modificar"></param>
        /// <param name="cancelar"></param>
        /// <param name="aceptar"></param>
        /// <param name="anular"></param>
        /// <param name="finalizar"></param>
        /// <param name="buscar"></param>
        /// <param name="reportes"></param>
        public void habilitarBotones(bool nuevaTransferencia, bool modificar, bool cancelar, bool aceptar, bool anular, bool finalizar, bool buscar, bool reportes)
        {
            this.btnNuevaTransferencia.Enabled = nuevaTransferencia;
            this.btnModificar.Enabled = modificar;
            this.btnCancelar.Enabled = cancelar;
            this.btnAceptar.Enabled = aceptar;
            this.btnAnular.Enabled = anular;
            this.btnFinalizar.Enabled = finalizar;
            this.btnBuscar.Enabled = buscar;
            this.btnReporte.Enabled = reportes;

        }


        public void formatearGrillaProductosEspecificos()
        {            

            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dtGVProductosEspecificos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVProductosEspecificos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;

            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dtGVProductosEspecificos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;

            this.dtGVProductosEspecificos.GridColor = System.Drawing.SystemColors.Control;
            this.dtGVProductosEspecificos.RowTemplate.Height = 19;
            this.dtGVProductosEspecificos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtGVProductosEspecificos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtGVProductosEspecificos.RowHeadersVisible = false;
            this.dtGVProductosEspecificos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtGVProductosEspecificos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtGVProductosEspecificos.AllowUserToAddRows = false;
            this.dtGVProductosEspecificos.AllowUserToDeleteRows = false;
            this.dtGVProductosEspecificos.AllowUserToResizeRows = true;            
            this.dtGVProductosEspecificos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dtGVProductosEspecificos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVProductosEspecificos.ClearGroups();


        }

        public void cargarDatosProductosEspecificos()
        {

            if (DTTransferenciasProductosEspecficos != null && DTTransferenciasProductosEspecficos.Rows.Count > 0)
            {
                DSProductosEspecificos.Tables.Clear();
                DSProductosEspecificos.Tables.Add(DTTransferenciasProductosEspecficos);
                dtGVProductosEspecificos.BindData(DSProductosEspecificos, DTTransferenciasProductosEspecficos.TableName);
                dtGVProductosEspecificos.GroupTemplate.Column = dtGVProductosEspecificos.Columns[1];
                ListSortDirection direction = ListSortDirection.Ascending;
                dtGVProductosEspecificos.Sort(new DataRowComparer(0, direction));
            }
        }

        public void emitirPermisos(bool permitirNuevaTransferencia, bool permitirAnular, bool permitirModificar, bool permitirReportes, bool permitirNavegar, bool permitirPagar)
        {
            btnNuevaTransferencia.Visible = permitirNuevaTransferencia;
            btnAnular.Visible = permitirAnular;
            btnModificar.Visible = permitirModificar;
            btnReporte.Visible = permitirReportes;
            btnBuscar.Visible = permitirNavegar;
            btnFinalizar.Visible = permitirPagar;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DTTRansferenciasProductosDetalleTemporal.Clear();
            NumeroTransferenciaProducto = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("TransferenciasProductos");
            cargarTransferencias(NumeroTransferenciaProducto);            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (btnNuevaTransferencia.Enabled)
            {                
                habilitarCampos(true);                
                TipoOperacion = "E";
                this.DTTRansferenciasProductosDetalleTemporal = formProductosBusqueda.DTProductosSeleccionados.Clone();
                DTTRansferenciasProductosDetalleTemporal.Clear();
                
                foreach (DSDoblones20GestionComercial2.ListarTransferenciasProductosDetalleParaMostrarRow FilaNueva in DTTRansferenciasProductosDetalle.Rows)
                {
                    DataRow FilaProducto = DTTRansferenciasProductosDetalleTemporal.NewRow();
                    FilaProducto["Código Producto"] = FilaNueva.CodigoProducto;
                    FilaProducto["Nombre Producto"] = FilaNueva.NombreProducto;
                    FilaProducto["Cantidad"] = FilaNueva.CantidadTransferencia;
                    FilaProducto["Precio"] = FilaNueva.PrecioUnitarioTransferencia;
                    FilaProducto["PrecioTotal"] = FilaNueva.CantidadTransferencia * FilaNueva.PrecioUnitarioTransferencia;
                    FilaProducto["Garantia"] = 0;
                    FilaProducto["EsProductoEspecifico"] = _TransaccionesUtilidadesCLN.esProductoEspecifico(NumeroAgencia, FilaNueva.CodigoProducto);
                    FilaProducto["VendidoComoAgregado"] = false;
                    FilaProducto["CantidadExistencia"] = _TransaccionesUtilidadesCLN.ObtenerExistenciaProductoInventario(NumeroAgencia, FilaNueva.CodigoProducto);                    
                    FilaProducto["CantidadEntregada"] = 0;                    
                    FilaProducto["PorcentajeDescuento"] = 0;                    
                    FilaProducto["NumeroPrecioSeleccionado"] = "1";
                    DTTRansferenciasProductosDetalleTemporal.Rows.Add(FilaProducto);
                    FilaProducto.AcceptChanges();                    
                }
                DTTRansferenciasProductosDetalleTemporal.AcceptChanges();
                formProductosBusqueda.DTProductosSeleccionados = this.DTTRansferenciasProductosDetalleTemporal;
                formProductosBusqueda.BDSourceProductosSeleccionados.DataSource = formProductosBusqueda.DTProductosSeleccionados;
                formProductosBusqueda.DTGridViewProductosSeleccionados.DataSource = formProductosBusqueda.BDSourceProductosSeleccionados;
                formProductosBusqueda.nuevaVenta = false;
                formProductosBusqueda.ListaCodigosProductosEliminados.Clear();
                bdSourceComprasProductos.DataSource = DTTRansferenciasProductosDetalleTemporal;
                dtGVProductos.DataSource = bdSourceComprasProductos;
                formatearTablaParaNuevaTransferencia(true);

            }



            formProductosBusqueda.ShowDialog(this);
            object detallePrecioTotal = DTTRansferenciasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "");
            if (detallePrecioTotal.ToString().Length > 0)
                txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " " + MascaraMonedaSistema;
            else
                txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
            habilitarBotones(false, false, true, true, false, false, false, false);            
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            
            _TransferenciasProductosCLN.ActualizarCodigoEstadoTransferencia(NumeroAgencia, NumeroTransferenciaProducto, "A", null,"E");
            //NumeroTransferenciaProducto = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("ComprasProductos");
            cargarTransferencias(NumeroTransferenciaProducto);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {            
            if (cBoxAgencia.SelectedValue != null)
            {
                if (DTTRansferenciasProductosDetalleTemporal.Rows.Count > 0)
                {
                    if (cBoxAgencia.SelectedValue.Equals(NumeroAgencia))
                    {
                        MessageBox.Show("No puede Realizar una Transferencia a una Misma Agencia" + Environment.NewLine + "Seleccione otra Agencia");
                        return;
                    }
                    try
                    {
                        if (TipoOperacion == "N")
                        {
                            //si no existió ningun error, se Procede a registrar la Transferencia
                            decimal precioTotal = Decimal.Parse(txtBoxPrecioTotal.Text.Replace(MascaraMonedaSistema, ""));
                            precioTotal = decimal.Parse(DTTRansferenciasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString());
                            DateTime FechaHoraTransferencia = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
                            _TransferenciasProductosCLN.InsertarTransferenciaProducto(NumeroAgencia, int.Parse(cBoxAgencia.SelectedValue.ToString()), CodigoUsuario,
                                FechaHoraTransferencia, "I", precioTotal, (byte)CodigoMonedaSistema, txtBoxObservaciones.Text.Trim());
                            NumeroTransferenciaProducto = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("TransferenciasProductos");
                            foreach (DataRow fila in this.DTTRansferenciasProductosDetalleTemporal.Rows)
                            {
                                //si el producto no es Agregado
                                if (!fila[7].Equals(true)) ///MUCHO OJO CON ESTA CONDICIÓN, SI ES NECESARIO VALIDARLA!! OJO OJO
                                    //CompraProductosDetalleCLN.InsertarCompraProductoDetalle(NumeroAgencia, numeroCompra, fila[0].ToString(), Int32.Parse(fila[2].ToString()), Decimal.Parse(fila[3].ToString()), 1);
                                    _TransferenciasProductosDetalleCLN.InsertarTransferenciaProductoDetalle(NumeroAgencia, NumeroTransferenciaProducto, fila["Código Producto"].ToString(), int.Parse(fila["Cantidad"].ToString()), decimal.Parse(fila["Precio"].ToString()), 0);
                            }
                        }

                        else if (TipoOperacion == "E")
                        {
                            decimal precioTotal = decimal.Parse(DTTRansferenciasProductosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString());
                            _TransferenciasProductosCLN.ActualizarTransferenciaProducto(NumeroAgencia, NumeroTransferenciaProducto, int.Parse(cBoxAgencia.SelectedValue.ToString()), CodigoUsuario, _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor(), "I", precioTotal, (byte)CodigoMonedaSistema, txtBoxObservaciones.Text.Trim());                            
                            foreach (DataRow fila in this.DTTRansferenciasProductosDetalleTemporal.Rows)
                            {
                                //si el producto no es Agregado
                                if (!fila[7].Equals(true)) ///MUCHO OJO CON ESTA CONDICIÓN, SI ES NECESARIO VALIDARLA!! OJO OJO
                                    _TransferenciasProductosDetalleCLN.InsertarTransferenciaProductoDetalle(NumeroAgencia, NumeroTransferenciaProducto, fila["Código Producto"].ToString(), int.Parse(fila["Cantidad"].ToString()), decimal.Parse(fila["Precio"].ToString()), 0);
                                
                            }                            

                            string CodigoProducto = "";
                            foreach (DataRow FilaAntigua in DTTRansferenciasProductosDetalle.Rows)
                            {
                                CodigoProducto = FilaAntigua["CodigoProducto"].ToString().Trim();
                                if (DTTRansferenciasProductosDetalleTemporal.Rows.Find(CodigoProducto) == null)
                                {                                    
                                    _TransferenciasProductosDetalleCLN.EliminarTransferenciaProductoDetalle(NumeroAgencia, NumeroTransferenciaProducto, FilaAntigua["CodigoProducto"].ToString());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio el Siguiente Error" + ex.Message + ". " + Environment.NewLine + "Consulte con su Administrador");
                    }

                    NumeroTransferenciaProducto = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("TransferenciasProductos");
                    cargarTransferencias(NumeroTransferenciaProducto);
                    TipoOperacion = "";

                    MessageBox.Show(this, "Se realizó correctamente el pedido de Transferencia de Productos", "Transferencia de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                else
                {
                    if (MessageBox.Show(this, "No Puede Realizar Esta Transacción sin Haber por lo Menos Seleccionado una Producto para Compralo. " + Environment.NewLine + " ¿Desea Agregar Productos a la Transferencia Actual?", "Verifique la Venta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        formProductosBusqueda.ShowDialog(this);
                    }
                    else
                    {
                        NumeroTransferenciaProducto = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("TransferenciasProductos");
                        cargarTransferencias(NumeroTransferenciaProducto);
                    }
                }
            }
            else
            {
                cBoxAgencia_Leave(sender, e);
            }
        }

        private void cBoxAgencia_Leave(object sender, EventArgs e)
        {
            if (cBoxAgencia.SelectedValue == null)
            {
                MessageBox.Show(this, "No puede Continuar la Transferencia actual, sin antes haber seleccionado" + Environment.NewLine + "una Agencia de Recepción. Porfavor Proceda a seleccionarla", "Transferencia de Productos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cBoxAgencia.Focus();
                if (cBoxAgencia.Items.Count > 0)
                    cBoxAgencia.SelectedIndex = 0;
            }
        }

        private void informeGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTTransferenciasProductosReporte = _TransferenciasProductosCLN.ListarTransferenciaProductosReporte(NumeroAgencia, NumeroTransferenciaProducto, "E");
            DataTable DTTransferenciasProductosDetalleReporte = _TransferenciasProductosDetalleCLN.ListarTransferenciaProductosDetalleReporte(NumeroAgencia, NumeroTransferenciaProducto, "E");
            DataTable DTTransferenciasProductosGastosDetalleReporte = _TransferenciasProductosGastosDetalleCLN.ListarTransferenciaProductoGastosDetalleParaMostrar(NumeroAgencia, NumeroTransferenciaProducto, null);
            FReporteTransferenciaProductos _FReporteTransferenciaProductos = new FReporteTransferenciaProductos();
            _FReporteTransferenciaProductos.enviarTablasParaGastosGeneral(DTTransferenciasProductosReporte, DTTransferenciasProductosDetalleReporte, DTTransferenciasProductosGastosDetalleReporte);
            _FReporteTransferenciaProductos.ShowDialog();
            _FReporteTransferenciaProductos.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FBuscarTransaccion formBuscarTransaccion = new FBuscarTransaccion(NumeroAgencia);
            formBuscarTransaccion.formatearEstiloParaTransferencias();
            formBuscarTransaccion.ShowDialog(this);
            NumeroTransferenciaProducto = formBuscarTransaccion.NumeroTransaccion;
            cargarTransferencias(NumeroTransferenciaProducto);            
            formBuscarTransaccion.Dispose();
        }

        private void informeGralEspecificosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTTransferenciasProductosReporte = _TransferenciasProductosCLN.ListarTransferenciaProductosReporte(NumeroAgencia, NumeroTransferenciaProducto, "E");
            DataTable DTTransferenciasProductosDetalleReporte = _TransferenciasProductosDetalleCLN.ListarTransferenciaProductosDetalleReporte(NumeroAgencia, NumeroTransferenciaProducto, "E");
            DataTable DTTransferenciasProductosGastosDetalleReporte = _TransferenciasProductosGastosDetalleCLN.ListarTransferenciaProductoGastosDetalleParaMostrar(NumeroAgencia, NumeroTransferenciaProducto, null);
            DataTable DTTransferenciasProductosEspecificosReporte = _TransferenciasProductosEspecificosCLN.ListarTransferenciaProductosEspecificosGeneralReporte(NumeroAgencia, NumeroTransferenciaProducto, "E");
            FReporteTransferenciaProductos _FReporteTransferenciaProductos = new FReporteTransferenciaProductos();
            _FReporteTransferenciaProductos.enviarTablasParaEspecificos(DTTransferenciasProductosReporte, DTTransferenciasProductosDetalleReporte, DTTransferenciasProductosGastosDetalleReporte, DTTransferenciasProductosEspecificosReporte);
            _FReporteTransferenciaProductos.ShowDialog();
            _FReporteTransferenciaProductos.Dispose();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FObservacionesTransaccionesModificacion _FObservacionesTransaccionesModificacion = new FObservacionesTransaccionesModificacion("F", CodigoUsuario, NumeroAgencia, NumeroTransferenciaProducto);
            _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text = txtBoxObservaciones.Text;
            if (_FObservacionesTransaccionesModificacion.ShowDialog() == DialogResult.OK)
                txtBoxObservaciones.Text = _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text;
        }
    }
}
