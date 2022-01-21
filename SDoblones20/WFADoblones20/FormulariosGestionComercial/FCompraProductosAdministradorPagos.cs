using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CLCAD;
using CLCLN.GestionComercial;
using WFADoblones20.FormulariosContabilidad;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FCompraProductosAdministradorPagos : Form
    {
        DSDoblones20GestionComercial.ListarCompraProductoGastoDetalleParaPagosDataTable DTGastosDetalle;
        DSDoblones20GestionComercial.GastosTiposTransaccionesDataTable DTGastosTipos;
        DSDoblones20GestionComercial2.ListarCompraProductoPagoDetalleParaMostrarDataTable DTPagosDetalle;
        DataTable DTGastosTiposTemporal;
        DataTable DTComprasProductoDetalle = new DataTable();
        DataTable DTCompraProducto;

        GastosTiposTransaccionesCLN _GastosTiposTransaccionesCLN;
        CompraProductosGastosDetalleCLN _CompraProductosGastosDetalleCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;        
        ComprasProductosCLN _ComprasProductosCLN;
        ComprasProductosPagosDetalleCLN _ComprasProductosPagosDetalleCLN;
        
        private const int NumeroConfiguracionCuenta = 1;
        public int NumeroAgencia { get; set; }
        public int NumeroCompraProducto { get; set; }
        public int CodigoUsuario { get; set; }
        public string MascaraMoneda { get; set; }
        public byte CodigoMonedaSistema { get; set; }

        public FCompraProductosAdministradorPagos(int NumeroAgencia, int NumeroCompraProducto, int CodigoUsuario, byte codigoMonedaSistema)
        {
            InitializeComponent();
            //this.CodigoMonedaSistema = 2;//dolares
            this.CodigoMonedaSistema = codigoMonedaSistema;

            this.NumeroAgencia = NumeroAgencia;
            this.NumeroCompraProducto = NumeroCompraProducto;
            this.CodigoUsuario = CodigoUsuario;

            _CompraProductosGastosDetalleCLN = new CompraProductosGastosDetalleCLN();
            _GastosTiposTransaccionesCLN = new GastosTiposTransaccionesCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _CompraProductosGastosDetalleCLN = new CompraProductosGastosDetalleCLN();
            _ComprasProductosCLN = new ComprasProductosCLN();
            _ComprasProductosPagosDetalleCLN = new ComprasProductosPagosDetalleCLN();

            DTGastosTipos = _GastosTiposTransaccionesCLN.ListarGastosTiposTransacciones();
            
            
            DTGastosTiposTemporal = new DataTable();
            DTGastosTiposTemporal.Columns.Add("CodigoGastosTipos", Type.GetType("System.Int32"));
            DTGastosTiposTemporal.Columns.Add("MontoPagoNuevo", Type.GetType("System.Decimal"));
            DTGastosTiposTemporal.Columns["MontoPagoNuevo"].DefaultValue = 0;
            DTGastosTiposTemporal.Columns.Add("ObservacionesNuevo", Type.GetType("System.String"));


            DGCNombreGastoNuevo.DataSource = DTGastosTipos;
            DGCNombreGastoNuevo.ValueMember = DTGastosTipos.CodigoGastosTiposColumn.ColumnName;
            DGCNombreGastoNuevo.DisplayMember = DTGastosTipos.NombreGastoColumn.ColumnName;

            this.dtGVGastosNuevos.DataSource = DTGastosTiposTemporal;

            dtGVProductosDetalle.AutoGenerateColumns = false;
            dtGVGastosHistorial.AutoGenerateColumns = false;
            dtGVGastosNuevos.AutoGenerateColumns = false;

            this.dtGVGastosNuevos.CellValidating += new DataGridViewCellValidatingEventHandler(dtGVGastosNuevos_CellValidating);            
            DTGastosTiposTemporal.RowChanged += new DataRowChangeEventHandler(DTGastosTiposTemporal_RowChanged);
            DTComprasProductoDetalle.RowChanged += new DataRowChangeEventHandler(DTComprasProductoDetalle_RowChanged);

            MascaraMoneda = "$us";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        void DTComprasProductoDetalle_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            //decimal MontoNuevo = decimal.Parse(DTGastosTiposTemporal.Compute("sum(MontoPagoNuevo)", "").ToString());
            //txtBoxMontoTotalGastosNuevos.Text = MontoNuevo.ToString();
            txtMontoTotalPago.Text = DTComprasProductoDetalle.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMoneda;
        }

        void DTGastosTiposTemporal_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            cargarPieDetalleGastos();
        }


        public void cargarPieDetalleGastos()
        {
            decimal MontoNuevo = (decimal)0.00;
            decimal.TryParse(DTGastosTiposTemporal.Compute("sum(MontoPagoNuevo)", "").ToString(), out MontoNuevo);
            txtBoxMontoTotalGastosNuevos.Text = MontoNuevo.ToString() + " " + MascaraMoneda;

            decimal MontoHisotorial = (decimal)0.00;
            decimal.TryParse(DTGastosDetalle.Compute("sum(MontoPagoGasto)", "").ToString(), out MontoHisotorial);

            txtMontoTotalHistorialGastos.Text = MontoHisotorial.ToString() + " " + MascaraMoneda;

            txtBoxMontoTotalHistorialNuevosGastos.Text = (MontoHisotorial + MontoNuevo).ToString() + " " + MascaraMoneda;

            
        }
        void dtGVGastosNuevos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal PrecioGasto;
            this.dtGVGastosNuevos.Rows[e.RowIndex].ErrorText = "";

            // No cell validation for new rows. New rows are validated on Row Validation.
            if (this.dtGVGastosNuevos.Rows[e.RowIndex].IsNewRow) { return; }

            if (this.dtGVGastosNuevos.IsCurrentCellDirty)
            {
                switch (this.dtGVGastosNuevos.Columns[e.ColumnIndex].Name)
                {

                    case "DGCMontoPagoNuevo":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGVGastosNuevos.Rows[e.RowIndex].ErrorText = "   Precio intruducido no es Coherente y no puede ser Nulo.";
                            this.dtGVGastosNuevos.BeginEdit(true);
                            e.Cancel = true;
                        }
                        else if (!decimal.TryParse(e.FormattedValue.ToString(), out PrecioGasto))
                        {                            
                            //this.dtGVGastosNuevos.Rows[e.RowIndex].ErrorText = "   No puede ingresar Valores negativos.";                            
                            this.dtGVGastosNuevos.CurrentCell.ErrorText = "   No puede ingresar Texto en vez de valores numerales.";
                            this.dtGVGastosNuevos.BeginEdit(true);
                            e.Cancel = true;
                        }
                        else if (PrecioGasto < 0)
                        {
                            this.dtGVGastosNuevos.CurrentCell.ErrorText = "No Puede ingresar Valores Negativos";
                            e.Cancel = true;
                        }

                        break;
                }

            }
        }

        private void FCompraProductosAdministradorPagos_Load(object sender, EventArgs e)
        {
            DGCNombreGasto.Width = 350;
            DGCMontoPagoGasto.Width = 85;

            DGCMontoPagoNuevo.Width = 85;
            DGCNombreGastoNuevo.Width = 350;

            DGCCodigoProducto.Width = 85;
            DGCNombreProducto.Width = 300;

            pnlGastos.Panel2Collapsed = true;
            btnGuardarNuevosGastos.Visible = false;
            this.dtGVGastosNuevos.SelectionMode = DataGridViewSelectionMode.CellSelect;


            CargarDatosCompra();
            
            
        }

        public void CargarDatosCompra()
        {
            try
            {
                DTGastosTiposTemporal.Clear();

                DTComprasProductoDetalle = _TransaccionesUtilidadesCLN.ListarDetalleDeCompra(NumeroAgencia, NumeroCompraProducto);
                dtGVProductosDetalle.DataSource = DTComprasProductoDetalle;
                DTComprasProductoDetalle.Columns.Add("PrecioTotal", Type.GetType("System.Decimal"), "CantidadCompra * PrecioUnitarioCompra");
                txtMontoTotalPago.Text = DTComprasProductoDetalle.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMoneda;

                DTCompraProducto = _ComprasProductosCLN.ListarCompraProductoReporte(NumeroAgencia, NumeroCompraProducto);


                lblFechaHoraCompraProducto.Text = String.Format("{0:g}", DateTime.Parse(DTCompraProducto.Rows[0]["Fecha"].ToString()));
                txtBoxProveedor.Text = DTCompraProducto.Rows[0]["NombreRazonSocial"].ToString();
                txtBoxNombreRepresentante.Text = DTCompraProducto.Rows[0]["NombreRepresentante"].ToString();                
                if (DTCompraProducto.Rows[0]["Tipo Compra"].ToString().Equals("A CREDITO"))
                {
                    checkCodigoTipoCompra.Checked = false;
                    btnCuentasPorPagar.Visible = true;
                }
                else
                {
                    checkCodigoTipoCompra.Checked = true;
                    btnCuentasPorPagar.Visible = false;
                }

                lblNumeroCompraProducto.Text = NumeroCompraProducto.ToString();

                DTCompraProducto = _ComprasProductosCLN.ObtenerCompraProducto(NumeroAgencia, NumeroCompraProducto);
                switch (DTCompraProducto.Rows[0]["CodigoEstadoCompra"].ToString())
                {
                    case "I":
                        lblCodigoEstadoCompra.Text = "INICIADA";
                        habilitarBotones(true, false, true, false);
                        
                        break;
                    case "A":
                        lblCodigoEstadoCompra.Text = "ANULADA";
                        btnGuardarNuevosGastos.Visible = false;
                        habilitarBotones(false, false, false, true);
                        break;
                    case "P":
                        lblCodigoEstadoCompra.Text = "PAGADA";
                        btnPagar.Visible = false;
                        habilitarBotones(false, true, true, true);
                        break;
                    case "D":
                        lblCodigoEstadoCompra.Text = "PENDIENTE EN TRANSITO";
                        btnPagar.Visible = false;
                        habilitarBotones(false, true, true, true);
                        break;
                    case "F":
                        lblCodigoEstadoCompra.Text = "FINALIZADA";
                        habilitarBotones(false, false, false, true);
                        break;
                    case "X":
                        lblCodigoEstadoCompra.Text = "FINALIZADA INCOMPLETA";
                        habilitarBotones(false, false, false, true);
                        break;
                }
                txtBoxObservaciones.Text = DTCompraProducto.Rows[0]["Observaciones"].ToString();
                txtBoxResponsablePagoCompra.Text = String.IsNullOrEmpty(DTCompraProducto.Rows[0]["CodigoUsuarioResponsablePago"].ToString()) ? "" :
                    _TransaccionesUtilidadesCLN.ObtenerNombreCompletoUsuario(int.Parse(DTCompraProducto.Rows[0]["CodigoUsuarioResponsablePago"].ToString()));
                lblResponsablePagoCompra.Text = String.IsNullOrEmpty(DTCompraProducto.Rows[0]["CodigoUsuarioResponsablePago"].ToString()) ? "" :
                    _TransaccionesUtilidadesCLN.ObtenerNombreCompletoUsuario(int.Parse(DTCompraProducto.Rows[0]["CodigoUsuarioResponsablePago"].ToString()));

                DTGastosDetalle = _CompraProductosGastosDetalleCLN.ListarCompraProductoGastoDetalleParaPagos(NumeroAgencia, NumeroCompraProducto);
                dtGVGastosHistorial.DataSource = DTGastosDetalle;
                txtMontoTotalHistorialGastos.Text = DTGastosDetalle.Compute(" sum(MontoPagoGasto)", "").ToString() + " " + MascaraMoneda;
                cargarPieDetalleGastos();

                //Cargamos el Detalle de Pagos realizados en la Compra 
                dtGVPagosDetalle.AutoGenerateColumns = false;
                DTPagosDetalle = _ComprasProductosPagosDetalleCLN.ListarCompraProductoPagoDetalleParaMostrar(NumeroAgencia, NumeroCompraProducto);
                dtGVPagosDetalle.DataSource = DTPagosDetalle;

                decimal MontoTotalCompra = decimal.Parse(DTComprasProductoDetalle.Compute("sum(PrecioTotal)", "").ToString());
                decimal MontoTotalPagado = String.IsNullOrEmpty(DTPagosDetalle.Compute("sum(MontoTotalPago)", "").ToString()) ? 0 : decimal.Parse(DTPagosDetalle.Compute("sum(MontoTotalPago)", "").ToString());
                decimal MontoDeferencia = decimal.Round(MontoTotalCompra - MontoTotalPagado, 2);
                txtBoxMontoTotalCompra.Text = MontoTotalCompra + " " + MascaraMoneda;
                txtBoxMontoPagado.Text = MontoTotalPagado.ToString() + " " + MascaraMoneda;
                txtBoxDiferenciaFaltante.Text = MontoDeferencia.ToString() + " " + MascaraMoneda;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ocurrió la siguiente Excepción " + ex.Message);
                
            }
            
            
        }

        public void habilitarBotones(bool pagar, bool guardarNuevosGastos, bool anadirNuevosGastos, bool reportes)
        {
            this.btnPagar.Enabled = pagar;
            this.btnGuardarNuevosGastos.Enabled = guardarNuevosGastos;
            this.btnAgregarGastos.Enabled = anadirNuevosGastos;
            this.btnReportes.Enabled = reportes;
        }

        private void btnAgregarGastos_Click(object sender, EventArgs e)
        {
            btnAgregarGastos.Enabled = false;
            pnlGastos.Panel2Collapsed = false;
            btnGuardarNuevosGastos.Visible = true;
            tControlPrincipal.SelectedTab = tPageDetalleGastos;
        }

        private void btnGuardarNuevosGastos_Click(object sender, EventArgs e)
        {
            DTGastosTiposTemporal.AcceptChanges();
            if (DTGastosTiposTemporal.Rows.Count <= 0)
            {
                MessageBox.Show("Aún no ha ingresado nuevos gastos");
                return;
            }

            if (DTGastosTiposTemporal.Select(" MontoPagoNuevo <= 0").Length >  0)
            {
                MessageBox.Show("No puede ingresar Valores núlos en el Precio de Pago");
                return;
            }

            //no ha ocurrido ningun error


            try
            {
                DateTime FechaHoraActual = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
                int CodigoGastoTipo = 0;
                decimal MontoPagoNuevo = 0;
                string ObservacionesNuevo = "";
                string NombreTipoGasto = "";
                foreach (DataRow FilaGastoNuevo in DTGastosTiposTemporal.Rows)
                {
                    CodigoGastoTipo = int.Parse(FilaGastoNuevo["CodigoGastosTipos"].ToString());
                    MontoPagoNuevo = decimal.Parse(FilaGastoNuevo["MontoPagoNuevo"].ToString());
                    ObservacionesNuevo = FilaGastoNuevo["ObservacionesNuevo"].ToString();
                    _CompraProductosGastosDetalleCLN.InsertarCompraProductoGastoDetalle(NumeroAgencia, NumeroCompraProducto, CodigoGastoTipo , FechaHoraActual, MontoPagoNuevo, null, ObservacionesNuevo);

                    NombreTipoGasto = DTGastosTipos.FindByCodigoGastosTipos(CodigoGastoTipo).NombreGasto;
                    DTGastosDetalle.AddListarCompraProductoGastoDetalleParaPagosRow(NombreTipoGasto, FechaHoraActual, MontoPagoNuevo, 0, ObservacionesNuevo, false);
                }

                DTGastosTiposTemporal.Clear();
                txtMontoTotalHistorialGastos.Text = DTGastosDetalle.Compute("sum (MontoPagoGasto)", "").ToString() + " " + MascaraMoneda;
                cargarPieDetalleGastos();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio la siguiente excepción " + ex.Message);
            }
                
        }

        private void dtGVGastosNuevos_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.ColumnIndex == dtGVGastosNuevos.Columns["DGCMontoPagoNuevo"].Index)
                e.Value = 0.00;
        }

        private void dtGVGastosNuevos_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo;
            agregarNuevoGastoToolStripMenuItem.Visible = false;
            toolStripMenuItem2.Visible = false;
            if (e.Button == MouseButtons.Right)
            {
                hitTestInfo = dtGVGastosNuevos.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell || e.RowIndex >= 0) 
                {
                    // If column is first column
                    if (e.ColumnIndex == 0)
                    {
                        if (!agregarNuevoGastoToolStripMenuItem.Visible)
                        {
                            agregarNuevoGastoToolStripMenuItem.Visible = true;
                            toolStripMenuItem2.Visible = true;
                        }
                    }
                    contextMenuStrip1.Show(dtGVGastosNuevos, new Point(e.X, e.Y));
                }
            }
        }

        private void eliminarFilaActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtGVGastosNuevos.Rows.Count > 0 && !dtGVGastosNuevos.CurrentRow.IsNewRow)
            {
                if (MessageBox.Show(this, "Se eliminar la fila actual Seleccionada. \r\n ¿Esta Seguro de Eliminar este Gasto?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DTGastosTiposTemporal.Rows[dtGVGastosNuevos.CurrentRow.Index].Delete();
                    cargarPieDetalleGastos();
                }
            }
        }

        private void limpiarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DTGastosTiposTemporal.Clear();
        }

        private void agregarNuevoGastoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FGastosTiposTransacciones _FGastosTiposTransacciones = new FGastosTiposTransacciones();
            _FGastosTiposTransacciones.habilitarOpcionesParaInsercion(e);
            _FGastosTiposTransacciones.ShowDialog();
            _FGastosTiposTransacciones.Dispose();

            int CodigoNuevo = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("GastosTiposTransacciones");

            DSDoblones20GestionComercial.GastosTiposTransaccionesRow Fila = DTGastosTipos.FindByCodigoGastosTipos(CodigoNuevo);
            if (Fila == null)
            {
                DSDoblones20GestionComercial.GastosTiposTransaccionesDataTable DTGastosTemporal = _GastosTiposTransaccionesCLN.ObtenerGastoTipoTransaccion(CodigoNuevo);
                if (DTGastosTemporal.Count > 0)
                {
                    Fila = DTGastosTipos.NewGastosTiposTransaccionesRow();
                    Fila.CodigoGastosTipos = CodigoNuevo;
                    Fila.NombreGasto = DTGastosTemporal[0].NombreGasto;
                    Fila.DescripcionGasto = DTGastosTemporal[0].DescripcionGasto;
                    this.DTGastosTipos.AddGastosTiposTransaccionesRow(Fila);
                    Fila.AcceptChanges();
                }

            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            DTGastosTiposTemporal.AcceptChanges();
            try
            {
            DateTime FechaHoraActual = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();

            if (DTCompraProducto.Rows[0]["CodigoTipoCompra"].ToString().Equals("R"))
            {
                decimal MontoTotalPago = _TransaccionesUtilidadesCLN.EsCompraCreditoEfectivo(NumeroAgencia, NumeroCompraProducto) ;
                if (MontoTotalPago > 0)
                {
                    FCompraProductosPagosIE formPagos = new FCompraProductosPagosIE(NumeroAgencia, CodigoUsuario, NumeroCompraProducto, NumeroConfiguracionCuenta, CodigoMonedaSistema);
                    formPagos.MontoTotalPagoCompra = MontoTotalPago;
                    if (formPagos.ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show(this, "No puede Continuar con la Operación actual, ya que no confirmó ningún Pago", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _ComprasProductosCLN.ActualizarCodigoEstadoCompra(NumeroAgencia, NumeroCompraProducto, "P", null);
                    _ComprasProductosCLN.ActualizarCompraProductoResponsablePago(NumeroAgencia, NumeroCompraProducto, CodigoUsuario, _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor());
                }
                else if (MessageBox.Show(this, "La Orden de Compra Actual es a Credito. ¿Desea Visualizar el Administrador de Cuentas por Pagar para gestionar su pago?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FCuentasPorPagar formCuentasPorPagar = new FCuentasPorPagar(CodigoUsuario, NumeroAgencia,
                        int.Parse(DTCompraProducto.Rows[0]["Numero Cuenta por Pagar"].ToString()),
                        false, false, false, false, false);
                    formCuentasPorPagar.ShowDialog(this);
                    formCuentasPorPagar.Dispose();
                }
            }
            else
            {
                FCompraProductosPagosIE formPagos = new FCompraProductosPagosIE(NumeroAgencia, CodigoUsuario, NumeroCompraProducto, NumeroConfiguracionCuenta, CodigoMonedaSistema);
                if (formPagos.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show(this, "No puede Continuar con la Operación actual, ya que no confirmó ningún Pago", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _ComprasProductosCLN.ActualizarCodigoEstadoCompra(NumeroAgencia, NumeroCompraProducto, "P", null);
                _ComprasProductosCLN.ActualizarCompraProductoResponsablePago(NumeroAgencia, NumeroCompraProducto, CodigoUsuario, _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor());
            }

            if (DTGastosTiposTemporal.Rows.Count > 0)
            {
                if (DTGastosTiposTemporal.Select(" MontoPagoNuevo <= 0").Length > 0)
                {
                    MessageBox.Show("No puede ingresar Valores núlos en el Precio de Pago");
                    return;
                }                
               
                    foreach (DataRow FilaGastoNuevo in DTGastosTiposTemporal.Rows)
                    {
                        _CompraProductosGastosDetalleCLN.InsertarCompraProductoGastoDetalle(NumeroAgencia, NumeroCompraProducto, 
                            int.Parse(FilaGastoNuevo["CodigoGastosTipos"].ToString()), FechaHoraActual, 
                            decimal.Parse(FilaGastoNuevo["MontoPagoNuevo"].ToString()), null, FilaGastoNuevo["ObservacionesNuevo"].ToString());
                    }
            }
            CargarDatosCompra();    
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se Pudo llevar Satisfactoriamente la Transacción debido a la siguiente razón : \r\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
        }

        private void dtGVGastosNuevos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtGVGastosNuevos.BeginEdit(true);
        }

        private void dtGVGastosNuevos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtGVGastosNuevos.Columns["DGCObservacionesNuevo"].Index)
            {
                if (dtGVGastosNuevos.CurrentCell.Value != null && !string.IsNullOrEmpty(dtGVGastosNuevos.CurrentCell.Value.ToString()))
                {
                    string TextoMayuscula = dtGVGastosNuevos.CurrentCell.Value.ToString();
                    dtGVGastosNuevos.CurrentCell.Value = TextoMayuscula.ToUpper();
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            DataTable DTCompraProdutosGastosDetalle = _ComprasProductosCLN.ListarCompraProductosGastosRecepcionPartesReportes(NumeroAgencia, NumeroCompraProducto, true);
            DataTable DTCompraProductosMonedaLiteral = _TransaccionesUtilidadesCLN.ListarTransaccionProductosGastosRecepcionMoneda(NumeroAgencia, NumeroCompraProducto, "C", null);
            FReporteCompraProductosGastosDetalle _FReporteCompraProductosGastosDetalle = new FReporteCompraProductosGastosDetalle(DTCompraProdutosGastosDetalle, DTCompraProductosMonedaLiteral);
            _FReporteCompraProductosGastosDetalle.ShowDialog(this);
        }

        private void modificarGastoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtGVGastosHistorial.Rows.Count != 0 && dtGVGastosHistorial.CurrentRow != null)
            {
                string CodigoEstadoCompraProducto = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroAgencia, "C");

                if (CodigoEstadoCompraProducto != "F" || CodigoEstadoCompraProducto != "X")
                {
                    DGCObservaciones.ReadOnly = false;
                    dtGVGastosHistorial.CurrentCell = dtGVGastosHistorial[DGCObservaciones.Index, dtGVGastosHistorial.CurrentRow.Index];
                    dtGVGastosHistorial.BeginEdit(true);
                    DGCMontoPagoGasto.ReadOnly = CodigoEstadoCompraProducto != "P";
                    modificarGastoToolStripMenuItem.Enabled = false;
                    btnGuardarGastosHistorial.Enabled = true;
                    guardarGastoToolStripMenuItem.Enabled = true;
                }
                else
                    MessageBox.Show(this, "Ya no puede modificar un gasto cuando ya ha pasado el Estado de Pagado", "Gastos por Transferencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(this, "No existen aun gastos", "Gastos por Transferencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuardarGastosHistorial_Click(object sender, EventArgs e)
        {
            if (DTGastosDetalle.GetChanges(DataRowState.Modified) != null && DTGastosDetalle.GetChanges(DataRowState.Modified).Rows.Count > 0)
            {                
                try
                {
                    foreach (CLCAD.DSDoblones20GestionComercial.ListarCompraProductoGastoDetalleParaPagosRow DRCompraGastoHistorial in DTGastosDetalle.GetChanges(DataRowState.Modified).Rows)
                    {
                        //_TransferenciasProductosGastosDetalleCLN.ActualizarTransferenciaProductoGastosDetalleObservaciones(NumeroAgencia, NumeroCompraProducto,
                        //    int.Parse(DRTransferenciaGastoHistorial["NumeroTransaferenciaProductoGasto"].ToString()),
                        //    !DGCMontoPagoGasto.ReadOnly ? (decimal?)decimal.Parse(DRTransferenciaGastoHistorial["MontoPagoGasto"].ToString()) : null,
                        //    DRTransferenciaGastoHistorial["Observaciones"].ToString());


                        _CompraProductosGastosDetalleCLN.ActualizarCompraProductoGastoDetalle(
                            NumeroAgencia, NumeroCompraProducto,
                            int.Parse(DRCompraGastoHistorial["NumeroCompraProductoGasto"].ToString()),
                            int.Parse(DRCompraGastoHistorial["CodigoGastosTipos"].ToString()),
                            DRCompraGastoHistorial.FechaHoraGasto, 
                            DRCompraGastoHistorial.MontoPagoGasto,
                            DRCompraGastoHistorial.IsCodigoMonedaPagoNull() ? (byte?)null : DRCompraGastoHistorial.CodigoMonedaPago, 
                            DRCompraGastoHistorial.Observaciones
                            );


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se pudo Actualizar el Registro debido a que ocurrio la siguiente Excepción " + ex.Message,
                                                "Gastos Por Compras de Productos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            DGCObservaciones.ReadOnly = true;
            DGCMontoPagoGasto.ReadOnly = true;
            modificarGastoToolStripMenuItem.Enabled = true;
            guardarGastoToolStripMenuItem.Enabled = false;
            btnGuardarGastosHistorial.Enabled = false;
            DTGastosDetalle.AcceptChanges();
            cargarPieDetalleGastos();
            txtMontoTotalHistorialGastos.Text = DTGastosDetalle.Compute("sum (MontoPagoGasto)", "").ToString() + " " + MascaraMoneda;
        }

        private void eliminarGastoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtGVGastosHistorial.Rows.Count != 0 && dtGVGastosHistorial.CurrentRow != null)
            {
                string CodigoEstadoTransferencia = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroCompraProducto, "C");

                if (CodigoEstadoTransferencia == "P")
                {
                    if (MessageBox.Show(this, "¿Se encuentra seguro de eliminar el registro seleccionado?", "Gastos por Compra de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;                   
                    try
                    {                        
                        _CompraProductosGastosDetalleCLN.EliminarCompraProductoGastoDetalle(NumeroAgencia, NumeroCompraProducto, int.Parse(DTGastosDetalle[dtGVGastosHistorial.CurrentRow.Index]["NumeroCompraProductoGasto"].ToString()));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "No se pudo eliminar el Registro debido a que ocurrio la siguiente Excepción " + ex.Message,
                            "Gastos por Compra de Productos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;                        
                    }

                    DTGastosDetalle.Rows.RemoveAt(dtGVGastosHistorial.CurrentRow.Index);
                    DTGastosDetalle.AcceptChanges();
                    cargarPieDetalleGastos();
                    txtMontoTotalHistorialGastos.Text = DTGastosDetalle.Compute("sum (MontoPagoGasto)", "").ToString() + " " + MascaraMoneda;
                }
                else
                    MessageBox.Show(this, "Ya no puede eliminar  un gasto cuando ya ha pasado el Estado de Pagado", "Gastos por Transferencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(this, "No existen aun gastos", "Gastos por Transferencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
        

        }

        private void btnCuentasPorPagar_Click(object sender, EventArgs e)
        {
            //int NumeroCuentaPorPagar = int.Parse(DTCompraProducto.Rows[0]["NumeroCuentaPorPagar"].ToString());            
            //FPagarCuentasPorPagar fpagar = new FPagarCuentasPorPagar(NumeroCuentaPorPagar, CodigoUsuario, MascaraMoneda);
            //if (fpagar.ShowDialog() == DialogResult.OK)
            //{
            //    CargarDatosCompra();
            //}

            FCuentasPorPagar formCuentasPorPagar = new FCuentasPorPagar(CodigoUsuario, NumeroAgencia,
                        int.Parse(DTCompraProducto.Rows[0]["NumeroCuentaPorPagar"].ToString()),
                        false, false, false, false, false);
            if (formCuentasPorPagar.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                CargarDatosCompra();
            formCuentasPorPagar.Dispose();
        }

        private void tControlPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
