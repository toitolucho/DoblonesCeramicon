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
    public partial class FTransferenciasProductosGastos : Form
    {
        DSDoblones20GestionComercial2.ListarTransferenciaProductoGastosDetalleParaMostrarDataTable DTGastosDetalle;
        DSDoblones20GestionComercial.GastosTiposTransaccionesDataTable DTGastosTipos;        
        DataTable DTGastosTiposTemporal;
        DSDoblones20GestionComercial2.ListarTransferenciasProductosDetalleParaMostrarDataTable DTTransferenciasProductoDetalle = new DSDoblones20GestionComercial2.ListarTransferenciasProductosDetalleParaMostrarDataTable();
        DSDoblones20GestionComercial2.TransferenciasProductosDataTable DTTransferenciaProducto;
        DataTable DTAgencias;

        GastosTiposTransaccionesCLN _GastosTiposTransaccionesCLN;        
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        TransferenciasProductosCLN _TransferenciasProductosCLN;
        TransferenciasProductosDetalleCLN _TransferenciasProductosDetalleCLN;
        TransferenciasProductosGastosDetalleCLN _TransferenciasProductosGastosDetalleCLN;
        AgenciasCLN _AgenciasCLN;

        public int NumeroAgencia { get; set; }
        public int NumeroTransferenciaProducto { get; set; }
        public string MascaraMoneda { get; set; }
        public string CodigoTipoEntradaSalida { get; set; }

        public FTransferenciasProductosGastos(int NumeroAgencia, int NumeroCompraProducto, string CodigoTipoEntradaSalida)
        {
            InitializeComponent();

            this.NumeroAgencia = NumeroAgencia;
            this.NumeroTransferenciaProducto = NumeroCompraProducto;
            this.CodigoTipoEntradaSalida = CodigoTipoEntradaSalida;

            
            _GastosTiposTransaccionesCLN = new GastosTiposTransaccionesCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _TransferenciasProductosCLN = new TransferenciasProductosCLN();
            _TransferenciasProductosDetalleCLN = new TransferenciasProductosDetalleCLN();
            _TransferenciasProductosGastosDetalleCLN = new TransferenciasProductosGastosDetalleCLN();
            _AgenciasCLN = new AgenciasCLN();


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
            DTTransferenciasProductoDetalle.RowChanged += new DataRowChangeEventHandler(DTComprasProductoDetalle_RowChanged);

            MascaraMoneda = "$us";            
            
        }

        void DTComprasProductoDetalle_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            //decimal MontoNuevo = decimal.Parse(DTGastosTiposTemporal.Compute("sum(MontoPagoNuevo)", "").ToString());
            //txtBoxMontoTotalGastosNuevos.Text = MontoNuevo.ToString();
            txtMontoTotalPago.Text = DTTransferenciasProductoDetalle.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMoneda;
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


            CargarDatosTransferencia();
            
            
        }

        public void CargarDatosTransferencia()
        {
            DTGastosTiposTemporal.Clear();
            if (CodigoTipoEntradaSalida == "R")
            {
                DTTransferenciasProductoDetalle = _TransferenciasProductosDetalleCLN.ListarTransferenciasProductosDetalleParaMostrar(_TransaccionesUtilidadesCLN.ObtenerNumeroAgenciaEmisoraDeTransferencias(NumeroTransferenciaProducto, NumeroAgencia), NumeroTransferenciaProducto);
                DTTransferenciaProducto = _TransferenciasProductosCLN.ObtenerTransferenciaProducto(_TransaccionesUtilidadesCLN.ObtenerNumeroAgenciaEmisoraDeTransferencias(NumeroTransferenciaProducto, NumeroAgencia), NumeroTransferenciaProducto);
            }
            else
            {
                DTTransferenciasProductoDetalle = _TransferenciasProductosDetalleCLN.ListarTransferenciasProductosDetalleParaMostrar( NumeroAgencia, NumeroTransferenciaProducto);
                DTTransferenciaProducto = _TransferenciasProductosCLN.ObtenerTransferenciaProducto(NumeroAgencia, NumeroTransferenciaProducto);
            }
            dtGVProductosDetalle.DataSource = DTTransferenciasProductoDetalle;
            DTTransferenciasProductoDetalle.Columns.Add("PrecioTotal", Type.GetType("System.Decimal"), "(CantidadTransferencia * PrecioUnitarioTransferencia) + MontoAdicionalPorGastos");
            txtMontoTotalPago.Text = DTTransferenciasProductoDetalle.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMoneda;


            if (DTTransferenciaProducto.Count > 0)
            {

                lblFechaHoraCompraProducto.Text = String.Format("{0:g}", DTTransferenciaProducto[0].FechaHoraTransferencia);
                DTAgencias = _AgenciasCLN.ObtenerAgencia(DTTransferenciaProducto[0].NumeroAgenciaEmisora);
                txtBoxAgenciaProveedora.Text = DTAgencias.Rows[0]["NombreAgencia"].ToString();
                txtBoxNombreRepresentante.Text = _TransaccionesUtilidadesCLN.ObtenerNombreCompleto(DTAgencias.Rows[0]["DIResponsable"].ToString());

                lblNumeroCompraProducto.Text = NumeroTransferenciaProducto.ToString();


                switch (DTTransferenciaProducto[0].CodigoEstadoTransferencia)
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
                        lblCodigoEstadoCompra.Text = "PENDIENTE";
                        btnPagar.Visible = false;
                        habilitarBotones(false, true, true, true);
                        break;
                    case "F":
                        lblCodigoEstadoCompra.Text = "FINALIZADA";
                        habilitarBotones(false, false, false, true);
                        break;
                    case "E":
                        lblCodigoEstadoCompra.Text = "ENVIADA";
                        habilitarBotones(false, false, false, true);
                        break;
                }
                txtBoxObservaciones.Text = DTTransferenciaProducto.Rows[0]["Observaciones"].ToString();

                DTGastosDetalle = _TransferenciasProductosGastosDetalleCLN.ListarTransferenciaProductoGastosDetalleParaMostrar(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEntradaSalida);
                dtGVGastosHistorial.DataSource = DTGastosDetalle;
                txtMontoTotalHistorialGastos.Text = DTGastosDetalle.Compute(" sum(MontoPagoGasto)", "").ToString() + " " + MascaraMoneda;
                cargarPieDetalleGastos();
            }
            else
            {
                btnAgregarGastos.Enabled = false;
                btnGuardarNuevosGastos.Enabled = false;
                btnPagar.Enabled = false;
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
                    _TransferenciasProductosGastosDetalleCLN.InsertarTransferenciaProductoGastoDetalle(NumeroAgencia, NumeroTransferenciaProducto, CodigoGastoTipo, FechaHoraActual, MontoPagoNuevo, null, ObservacionesNuevo, false, this.CodigoTipoEntradaSalida);

                    NombreTipoGasto = DTGastosTipos.FindByCodigoGastosTipos(CodigoGastoTipo).NombreGasto;                    
                    DSDoblones20GestionComercial2.ListarTransferenciaProductoGastosDetalleParaMostrarRow DRGastoNuevo = DTGastosDetalle.AddListarTransferenciaProductoGastosDetalleParaMostrarRow(NombreTipoGasto, FechaHoraActual, MontoPagoNuevo, ObservacionesNuevo, "E");
                    DTGastosDetalle.NumeroTransaferenciaProductoGastoColumn.ReadOnly = false;
                    DRGastoNuevo["NumeroTransaferenciaProductoGasto"] = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("TransferenciasProductosGastosDetalle");
                    DTGastosDetalle.AcceptChanges();
                    DTGastosDetalle.NumeroTransaferenciaProductoGastoColumn.ReadOnly = true;
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

        }

        private void agregarNuevoGastoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dtGVGastosNuevos.CurrentCellAddress.ToString());

            //if (dtGVGastosNuevos.CurrentRow.IsNewRow)
            //{
            //    MessageBox.Show("Nueva Fila");
            //    return;
            //}



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
                    
                    //dtGVGastosNuevos[dtGVGastosNuevos.CurrentCell.RowIndex, dtGVGastosNuevos.CurrentCell.ColumnIndex].Value = Fila.CodigoGastosTipos;
                }

            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            DTGastosTiposTemporal.AcceptChanges();
            DateTime FechaHoraActual = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
            try
            {
                if (DTGastosTiposTemporal.Rows.Count > 0)
                {
                    if (DTGastosTiposTemporal.Select(" MontoPagoNuevo <= 0").Length > 0)
                    {
                        MessageBox.Show("No puede ingresar Valores núlos en el Precio de Pago");
                        return;
                    }
                    
                    

                        foreach (DataRow FilaGastoNuevo in DTGastosTiposTemporal.Rows)
                        {
                            //_CompraProductosGastosDetalleCLN.InsertarCompraProductoGastoDetalle(NumeroAgencia, NumeroTransferenciaProducto, int.Parse(FilaGastoNuevo["CodigoGastosTipos"].ToString()), FechaHoraActual, decimal.Parse(FilaGastoNuevo["MontoPagoNuevo"].ToString()), null, FilaGastoNuevo["ObservacionesNuevo"].ToString());
                            _TransferenciasProductosGastosDetalleCLN.InsertarTransferenciaProductoGastoDetalle(NumeroAgencia, NumeroTransferenciaProducto, int.Parse(FilaGastoNuevo["CodigoGastosTipos"].ToString()), FechaHoraActual, decimal.Parse(FilaGastoNuevo["MontoPagoNuevo"].ToString()), null, FilaGastoNuevo["ObservacionesNuevo"].ToString(), false, this.CodigoTipoEntradaSalida);
                        }
                        
                    

                    
                }
                if(CodigoTipoEntradaSalida == "E")
                    _TransferenciasProductosCLN.ActualizarCodigoEstadoTransferencia(NumeroAgencia, NumeroTransferenciaProducto, "P", null, CodigoTipoEntradaSalida);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se Pudo llevar Satisfactoriamente la Transacción debido a la siguiente razón : \r\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            CargarDatosTransferencia();
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
            //DataTable DTCompraProdutosGastosDetalle = _ComprasProductosCLN.ListarCompraProductosGastosRecepcionPartesReportes(NumeroAgencia, NumeroTransferenciaProducto, true);
            //FReporteCompraProductosGastosDetalle _FReporteCompraProductosGastosDetalle = new FReporteCompraProductosGastosDetalle(DTCompraProdutosGastosDetalle);
            //_FReporteCompraProductosGastosDetalle.ShowDialog(this);

            DataTable DTTRansferenciasProductosGastosDetalleReporte = _TransferenciasProductosGastosDetalleCLN.ListarTransferenciaProductoGastosDetalleParaMostrar(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEntradaSalida);
            DataTable DTTransferenciasProductosReporte = _TransferenciasProductosCLN.ListarTransferenciaProductosReporte(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEntradaSalida);
            DataTable DTTransferenciasMontoMonedaLiteral = _TransaccionesUtilidadesCLN.ListarTransaccionProductosGastosRecepcionMoneda(NumeroAgencia, NumeroTransferenciaProducto, "T", CodigoTipoEntradaSalida);
            FReporteTransferenciaProductos _FReporteTransferenciaProductos = new FReporteTransferenciaProductos();
            _FReporteTransferenciaProductos.enviarTablasParaGastos(DTTransferenciasProductosReporte, DTTRansferenciasProductosGastosDetalleReporte, DTTransferenciasMontoMonedaLiteral);
            _FReporteTransferenciaProductos.ShowDialog();
            _FReporteTransferenciaProductos.Dispose();

        }

        private void modificarGastoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtGVGastosHistorial.Rows.Count != 0 && dtGVGastosHistorial.CurrentRow != null)
            {                
                string CodigoEstadoTransferencia = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(CodigoTipoEntradaSalida == "E" ? NumeroAgencia
                    : _TransaccionesUtilidadesCLN.ObtenerNumeroAgenciaEmisoraDeTransferencias(NumeroTransferenciaProducto, NumeroAgencia),
                    NumeroTransferenciaProducto,
                    CodigoTipoEntradaSalida
                    );

                if (CodigoEstadoTransferencia != "F" || CodigoEstadoTransferencia != "X")
                {
                    DGCObservaciones.ReadOnly = false;
                    dtGVGastosHistorial.CurrentCell = dtGVGastosHistorial[DGCObservaciones.Index, dtGVGastosHistorial.CurrentRow.Index];
                    dtGVGastosHistorial.BeginEdit(true);
                    DGCMontoPagoGasto.ReadOnly = CodigoEstadoTransferencia != "P";                    
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

        private void guardarGastoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DTGastosDetalle.AcceptChanges();
            if (DTGastosDetalle.GetChanges(DataRowState.Modified) != null && DTGastosDetalle.GetChanges(DataRowState.Modified).Rows.Count > 0)
            {
                int NumeroAgenciaInsertar = CodigoTipoEntradaSalida == "E" ? NumeroAgencia : _TransaccionesUtilidadesCLN.ObtenerNumeroAgenciaEmisoraDeTransferencias(NumeroTransferenciaProducto, NumeroAgencia);
                try
                {
                    foreach (DataRow DRTransferenciaGastoHistorial in DTGastosDetalle.GetChanges(DataRowState.Modified).Rows)
                    {
                        _TransferenciasProductosGastosDetalleCLN.ActualizarTransferenciaProductoGastosDetalleObservaciones(NumeroAgenciaInsertar, NumeroTransferenciaProducto,
                            int.Parse(DRTransferenciaGastoHistorial["NumeroTransaferenciaProductoGasto"].ToString()),
                            !DGCMontoPagoGasto.ReadOnly ? (decimal?)decimal.Parse(DRTransferenciaGastoHistorial["MontoPagoGasto"].ToString()) : null,
                            DRTransferenciaGastoHistorial["Observaciones"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se pudo Actualizar el Registro debido a que ocurrio la siguiente Excepción " + ex.Message,
                                                "Gastos Por Transferencias", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                string CodigoEstadoTransferencia = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(CodigoTipoEntradaSalida == "E" ? NumeroAgencia
                    : _TransaccionesUtilidadesCLN.ObtenerNumeroAgenciaEmisoraDeTransferencias(NumeroTransferenciaProducto, NumeroAgencia),
                    NumeroTransferenciaProducto,
                    CodigoTipoEntradaSalida
                    );

                if (CodigoEstadoTransferencia == "P")
                {
                    if (MessageBox.Show(this, "¿Se encuentra seguro de eliminar el registro seleccionado?", "Gastos por Transferencias", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    int NumeroAgenciaInsertar = CodigoTipoEntradaSalida == "E" ? NumeroAgencia : _TransaccionesUtilidadesCLN.ObtenerNumeroAgenciaEmisoraDeTransferencias(NumeroTransferenciaProducto, NumeroAgencia);                    
                    try
                    {
                        _TransferenciasProductosGastosDetalleCLN.EliminarTransferenciaProductoGastoDetalle(NumeroAgenciaInsertar, NumeroTransferenciaProducto, int.Parse(DTGastosDetalle[dtGVGastosHistorial.CurrentRow.Index]["NumeroTransaferenciaProductoGasto"].ToString()));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "No se pudo eliminar el Registro debido a que ocurrio la siguiente Excepción " + ex.Message,
                            "Gastos Por Transferencias", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

    }
}
