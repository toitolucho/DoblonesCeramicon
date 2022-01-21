using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
using CLCAD;
using System.Collections;
using CLCLN.Sistema;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FCompraProductosBuscador : Form
    {
        DSDoblones20GestionComercial.BuscarCompraProductoDataTable DTBusquedaCompraProducto;
        DataTable VariablesConfiguracionSistemaGC;
        ComprasProductosCLN _ComprasProductosCLN;
        ComprasProductosDetalleCLN _ComprasProductosDetalleCLN;
        
        PCsConfiguracionesCLN PCConfiguracion;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        ArrayList ListaCodigosEstadoCompra = new ArrayList();

        public int NumeroAgencia { get; set; }
        private int NumeroPC = 0;
        public int CodigoUsuario { get; set; }
        public int NumeroTransaccion { get; set; }
        private string TipoOperacion = "";
        
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

        public FCompraProductosBuscador(int NumeroAgencia, int NumeroPC, int CodigoUsuario)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            this.CodigoUsuario = CodigoUsuario;


            this.dateFechaInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dateFechaFin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(1).AddMilliseconds(-1);
            txtBoxNumeroTransaccion.Clear();
            txtBoxTextoBusqueda.Clear();
            this.lblNroTransaccion.Text = "Numero de Compra";
            this.cBoxBuscarPor.Items.Clear();
            this.cBoxBuscarPor.Items.Add("Nombre Proveedor");
            this.cBoxBuscarPor.Items.Add("NIT Proveedor");
            this.cBoxBuscarPor.Items.Add("Nombre Producto");
            this.cBoxBuscarPor.Items.Add("Observaciones");
            this.cBoxBuscarPor.SelectedIndex = 0;  

            _ComprasProductosCLN = new ComprasProductosCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _ComprasProductosDetalleCLN = new ComprasProductosDetalleCLN();

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

            DGCNumeroAgencia.Width = 75;
            DGCNumeroCompraProducto.Width = 100;
            DGCFecha.Width = 165;
            DGCObservaciones.Width = 250;
            dtGVTransacciones.CellDoubleClick += new DataGridViewCellEventHandler(dtGVTransacciones_CellDoubleClick);
            dtGVTransacciones.CellFormatting += new DataGridViewCellFormattingEventHandler(dtGVTransacciones_CellFormatting);
            //dtGVTransacciones.DoubleClick += new EventHandler(dtGVTransacciones_DoubleClick);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        void dtGVTransacciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) )
            {
                if ((e.ColumnIndex == DGCTipoCompra.Index))
                {
                    if(dtGVTransacciones["DGCTipoCompra", e.RowIndex].Value.ToString().CompareTo("EFECTIVO") == 0)
                        dtGVTransacciones.Rows[e.RowIndex].Cells["DGCTipoCompra"].Style.BackColor = Color.LightCoral;
                    else
                        dtGVTransacciones.Rows[e.RowIndex].Cells["DGCTipoCompra"].Style.BackColor = Color.Cyan;
                }

                if ((e.ColumnIndex == DGCEstadoCompra.Index))
                {
                    switch (dtGVTransacciones["DGCEstadoCompra", e.RowIndex].Value.ToString())
                    {
                        case "INICIADA":
                            dtGVTransacciones.Rows[e.RowIndex].Cells["DGCEstadoCompra"].Style.BackColor = Color.Tomato;
                            break;
                        case "ANULADA":
                            dtGVTransacciones.Rows[e.RowIndex].Cells["DGCEstadoCompra"].Style.BackColor = Color.Firebrick;
                            break;
                        case "PAGADA EN TRANSITO":
                            dtGVTransacciones.Rows[e.RowIndex].Cells["DGCEstadoCompra"].Style.BackColor = Color.SteelBlue;
                            break;
                        case "A CREDITO EN TRANSITO":
                            dtGVTransacciones.Rows[e.RowIndex].Cells["DGCEstadoCompra"].Style.BackColor = Color.Gold;
                            break;
                        case "PENDIENTE":
                            dtGVTransacciones.Rows[e.RowIndex].Cells["DGCEstadoCompra"].Style.BackColor = Color.LawnGreen;
                            break;
                        case "FINALIZADO Y RECIBIDO":
                            dtGVTransacciones.Rows[e.RowIndex].Cells["DGCEstadoCompra"].Style.BackColor = Color.WhiteSmoke;
                            break;
                        case "FINALIZADO INCOMPLETO":
                            dtGVTransacciones.Rows[e.RowIndex].Cells["DGCEstadoCompra"].Style.BackColor = Color.Moccasin;
                            break;
                    }

                    //if (dtGVTransacciones["DGCEstadoCompra", e.RowIndex].Value.ToString().CompareTo("EFECTIVO") == 0)
                    //    dtGVTransacciones.Rows[e.RowIndex].Cells["DGCTipoCompra"].Style.BackColor = Color.LightCoral;
                    //else
                    //    dtGVTransacciones.Rows[e.RowIndex].Cells["DGCTipoCompra"].Style.BackColor = Color.Cyan;
                }
                
                
            }
        }

        void dtGVTransacciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                if (dtGVTransacciones.RowCount > 0 && dtGVTransacciones.CurrentRow != null)
                {

                    this.NumeroTransaccion = int.Parse(DTBusquedaCompraProducto.DefaultView[e.RowIndex][DTBusquedaCompraProducto.NumeroCompraProductoColumn.ColumnName].ToString());
                    //this.NumeroTransaccion = DTBusquedaCompraProducto[e.RowIndex].NumeroCompraProducto;
                    //string CodigoEstadoCompra = DTBusquedaCompraProducto[e.RowIndex].CodigoEstadoCompra;
                    string CodigoEstadoCompra = DTBusquedaCompraProducto.DefaultView[e.RowIndex][DTBusquedaCompraProducto.CodigoEstadoCompraColumn.ColumnName].ToString();

                    switch (TipoOperacion)
                    {
                        case "A": //Recepción en Almacenes
                            //if (CodigoEstadoCompra == "P" || CodigoEstadoCompra == "D")
                            //{
                                FCompraProductosAdministradorIngresoInventarios _FCompraProductosAdministradorIngresoInventarios = new FCompraProductosAdministradorIngresoInventarios(NumeroAgencia, NumeroPC, NumeroTransaccion, CodigoUsuario);
                                //_FCompraProductosAdministradorIngresoInventarios.
                                _FCompraProductosAdministradorIngresoInventarios.ShowDialog();
                                _FCompraProductosAdministradorIngresoInventarios.Dispose();
                                DTBusquedaCompraProducto[e.RowIndex].CodigoEstadoCompra = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroTransaccion, "C");
                            //}
                            //else
                            //{
                            //    MessageBox.Show(this, "Usted no tiene los privilegios para observar esta compra en este Estado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //}
                            break;
                        case "C": //Cancelacion y pago para el Contador
                            //if (CodigoEstadoCompra == "P" || CodigoEstadoCompra == "I" || CodigoEstadoCompra == "D")
                            //{
                                FCompraProductosAdministradorPagos _FCompraProductosAdministradorPagos = new FCompraProductosAdministradorPagos(NumeroAgencia, NumeroTransaccion, CodigoUsuario, (byte)CodigoMonedaSistema);
                                _FCompraProductosAdministradorPagos.MascaraMoneda = MascaraMonedaSistema;
                                _FCompraProductosAdministradorPagos.ShowDialog();
                                _FCompraProductosAdministradorPagos.Dispose();
                            //}
                            //else
                            //{
                            //    MessageBox.Show(this, "Usted no tiene los privilegios para observar esta compra en este Estado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //}

                            break;
                        case "N": //Navegación
                            FComprasProductos _FComprasProductos = new FComprasProductos(NumeroAgencia, NumeroPC, CodigoUsuario);
                            //_FComprasProductos.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
                            _FComprasProductos.emitirPermisos(false, true, false, true, false, false);
                            _FComprasProductos.cargarDatosCompras(NumeroTransaccion);
                            _FComprasProductos.ShowDialog(this);
                            _FComprasProductos.Dispose();
                            break;
                        default:
                            break;
                    }

                    CodigoEstadoCompra = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroTransaccion, "C");
                    DTBusquedaCompraProducto[e.RowIndex].CodigoEstadoCompra = CodigoEstadoCompra;
                    DTBusquedaCompraProducto[e.RowIndex].EstadoCompra = obtenerSignificadoEstadoCompra(CodigoEstadoCompra);
                    
                    
                }              

            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha Seleccionado aún una Compra " + ex.Message);
            }
            
        }

        private void FCompraProductosBuscador_Load(object sender, EventArgs e)
        {
            //dateTimePicker1
            //DTBusquedaCompraProducto = _ComprasProductosCLN.BuscarCompraProducto("0", " ", NumeroAgencia,
            //    null, null, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0,0,0), DateTime.Now, false);

            DTBusquedaCompraProducto = _ComprasProductosCLN.BuscarCompraProducto("0", " ", NumeroAgencia,
                null, null, dateFechaInicio.Value, DateTime.Now, false);

            bdSourceTransacciones.DataSource = DTBusquedaCompraProducto;
            dtGVTransacciones.DataSource = bdSourceTransacciones;
            statusStrip1.Items[0].Text = "Numero de registros encontrados: " + bdSourceTransacciones.Count.ToString();
            DGCNumeroAgencia.Width = 85;
            DGCNombreRazonSocial.Width = 200;
                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBoxNumeroTransaccion.Text.Trim()) && String.IsNullOrEmpty(txtBoxTextoBusqueda.Text))
            {
                MessageBox.Show(this, "Aun no ha ingresado un Texto a Buscar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DTBusquedaCompraProducto.Clear();
                int NumeroTransaccion = -1;
                if (txtBoxNumeroTransaccion.Text.Trim().Length > 0 && txtBoxNumeroTransaccion.Text != null)
                {
                    NumeroTransaccion = Int32.Parse(txtBoxNumeroTransaccion.Text);
                }

                DTBusquedaCompraProducto = _ComprasProductosCLN.BuscarCompraProducto(cBoxBuscarPor.SelectedIndex.ToString(),
                        txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, NumeroTransaccion, 
                        cBoxCodigoEstadoVenta.SelectedValue.Equals("T") ? null : cBoxCodigoEstadoVenta.SelectedValue.ToString(), 
                        dateFechaInicio.Value, dateFechaFin.Value, checkTextoIdentico.Checked);
                bdSourceTransacciones.DataSource = DTBusquedaCompraProducto;
                dtGVTransacciones.DataSource = bdSourceTransacciones;

                if (DTBusquedaCompraProducto.Rows.Count == 0)
                    DTBusquedaCompraProducto.Rows.Clear();
                statusStrip1.Items[0].Text = "Numero de registros encontrados: " + bdSourceTransacciones.Count.ToString();
                if (txtBoxNumeroTransaccion.Focused)
                    txtBoxNumeroTransaccion.SelectAll();
                else if (txtBoxTextoBusqueda.Focused)
                    txtBoxTextoBusqueda.SelectAll();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBoxNumeroTransaccion.Clear();
            txtBoxTextoBusqueda.Clear();
            this.DTBusquedaCompraProducto.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoxTextoBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e as EventArgs);
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (dtGVTransacciones.RowCount > 0)
                {
                    dtGVTransacciones.Focus();
                    dtGVTransacciones.Columns[3].Selected = true;
                    dtGVTransacciones.CurrentCell = dtGVTransacciones.Rows[0].Cells[3];
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.txtBoxTextoBusqueda.Clear();
                this.txtBoxNumeroTransaccion.Clear();
                this.txtBoxTextoBusqueda.Focus();
            }      
        }





        public void formatearParaBusquedaRecepcion()
        {
            ListaCodigosEstadoCompra.Add(new EstadoVenta("P", "Pagadas En Transito"));            
            ListaCodigosEstadoCompra.Add(new EstadoVenta("D", "En Espera de Recepción(Pendientes)"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("T", "Todas"));

            this.cBoxCodigoEstadoVenta.DataSource = ListaCodigosEstadoCompra;
            this.cBoxCodigoEstadoVenta.ValueMember = "CodigoEstadoVenta";
            this.cBoxCodigoEstadoVenta.DisplayMember = "Descripcion";
            this.cBoxCodigoEstadoVenta.SelectedValue = "P";

            TipoOperacion = "A";

            this.Text = "Administrador de Compras para Recepción de Mercadería";
        }

        public void formatearParaPagosCancelacionMonetaria()
        {
            ListaCodigosEstadoCompra.Add(new EstadoVenta("I", "Iniciadas"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("P", "Pagadas"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("D", "Pendientes"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("T", "Todas"));

            this.cBoxCodigoEstadoVenta.DataSource = ListaCodigosEstadoCompra;
            this.cBoxCodigoEstadoVenta.ValueMember = "CodigoEstadoVenta";
            this.cBoxCodigoEstadoVenta.DisplayMember = "Descripcion";
            this.cBoxCodigoEstadoVenta.SelectedValue = "I";

            TipoOperacion = "C";

            this.Text = "Administrador de Compras para cancelación, pago y gastos";
        }


        public void formatearParaBusquedasGeneral()
        {
            ListaCodigosEstadoCompra.Add(new EstadoVenta("F", "Finalizadas"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("I", "Iniciadas"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("A", "Anuladas"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("P", "Pagadas en Transito"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("D", "Pendientes"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("X", "Finalizadas Incompletas"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("T", "Todas"));


            this.cBoxCodigoEstadoVenta.DataSource = ListaCodigosEstadoCompra;
            this.cBoxCodigoEstadoVenta.ValueMember = "CodigoEstadoVenta";
            this.cBoxCodigoEstadoVenta.DisplayMember = "Descripcion";
            this.cBoxCodigoEstadoVenta.SelectedValue = "T";

            TipoOperacion = "N";


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

        private void txtBoxNumeroTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter)
            {
                e.Handled = true;
                txtBoxNumeroTransaccion.SelectionStart = 0;
                txtBoxNumeroTransaccion.SelectionLength = txtBoxNumeroTransaccion.Text.Length;
                System.Media.SystemSounds.Beep.Play();
                return;
            }
        }

        public string obtenerSignificadoEstadoCompra(string estadoCompra)
        {
            //CASE(CodigoEstadoCompra) WHEN ''I'' THEN ''INICIADA'' WHEN ''A'' THEN ''ANULADA'' WHEN ''P'' THEN ''PAGADA'' WHEN ''D'' THEN ''PENDIENTE''  WHEN ''F'' THEN ''FINALIZADO Y RECIBIDO''
            switch (estadoCompra)
            {
                case "I":
                    return "INICIADA";
                case "A":
                    return "ANULADA";
                case "P":
                    return "EN TRANSITO";
                case "D":
                    return "PENDIENTE";
                case "F":
                    return "FINALIZADO Y RECIBIDO";
                case "X":
                    return "FINALIZADO INCOMPLETO";
                default:
                    return "INDETERMINADO";
            }
        }

        private void ordenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int NumeroCompraProducto = -1;
            if (dtGVTransacciones.RowCount > 0 && dtGVTransacciones.CurrentCell != null
                && int.TryParse(dtGVTransacciones.CurrentRow.Cells[DGCNumeroCompraProducto.Index].Value.ToString(), out NumeroCompraProducto))
            {

                DataTable DTCompraProductosReporte = _ComprasProductosCLN.ListarCompraProductoReporte(NumeroAgencia, NumeroCompraProducto);
                DataTable DTCompraProductosDetalleReporte = _ComprasProductosDetalleCLN.ListarCompraProductoDetalleReporteIncluidoAgregados(NumeroAgencia, NumeroCompraProducto, "S", true);
                FReporteCompraProductosGeneral ReporteCompraproductosForm = new FReporteCompraProductosGeneral();
                ReporteCompraproductosForm.ListarReporteComprasProductosCopiaSistemaCEATEC(DTCompraProductosReporte, DTCompraProductosDetalleReporte);
                ReporteCompraproductosForm.Show();
            }
        }

        private void informeGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int NumeroCompraProducto = -1;
            if (dtGVTransacciones.RowCount > 0 && dtGVTransacciones.CurrentCell != null
                && int.TryParse(dtGVTransacciones.CurrentRow.Cells[DGCNumeroCompraProducto.Index].Value.ToString(), out NumeroCompraProducto))
            {
                DataTable DTCompraProductosReporte = _ComprasProductosCLN.ListarCompraProductoReporte(NumeroAgencia, NumeroCompraProducto);
                DataTable DTCompraProductosDetalleReporte = _ComprasProductosDetalleCLN.ListarCompraProductoDetalleReporte(NumeroAgencia, NumeroCompraProducto);
                ComprasProductosEspecificosAgregadosCLN _ComprasProductosEspecificosAgregadosCLN = new ComprasProductosEspecificosAgregadosCLN();
                DataTable DTCompraProductosAgregadosReporte = _ComprasProductosEspecificosAgregadosCLN.ListarCompraProductoEspecificoAgregadoReporte(NumeroAgencia, NumeroCompraProducto);                
                FReporteCompraProductosGeneral ReporteCompraproductosForm = new FReporteCompraProductosGeneral(DTCompraProductosReporte, DTCompraProductosDetalleReporte, DTCompraProductosAgregadosReporte);
                ReporteCompraproductosForm.Show();
            }
        }

        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int NumeroCompraProducto = -1;
            if (dtGVTransacciones.RowCount > 0 && dtGVTransacciones.CurrentCell != null
                && int.TryParse(dtGVTransacciones.CurrentRow.Cells[DGCNumeroCompraProducto.Index].Value.ToString(), out NumeroCompraProducto))
            {
                FComprasProductos _FComprasProductos = new FComprasProductos(NumeroAgencia, NumeroPC, CodigoUsuario);                
                _FComprasProductos.emitirPermisos(false, true, false, true, false, false);
                _FComprasProductos.cargarDatosCompras(NumeroCompraProducto);
                _FComprasProductos.ShowDialog(this);
                _FComprasProductos.Dispose();
            }
        }

        private void detalleDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //columna NumeroCuentaPorPagar
        }

        private void importaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int NumeroCompraProducto = -1;
            if (dtGVTransacciones.RowCount > 0 && dtGVTransacciones.CurrentCell != null
                && int.TryParse(dtGVTransacciones.CurrentRow.Cells[DGCNumeroCompraProducto.Index].Value.ToString(), out NumeroCompraProducto))
            {

                DataTable DTCompraProductosReporte = _ComprasProductosCLN.ListarCompraProductoReporte(NumeroAgencia, NumeroCompraProducto);
                DataTable DTCompraProductosDetalleReporte = _ComprasProductosDetalleCLN.ListarCompraProductoDetalleReporte(NumeroAgencia, NumeroCompraProducto);
                FReporteCompraProductosGeneral ReporteCompraproductosForm = new FReporteCompraProductosGeneral();
                ReporteCompraproductosForm.ListarReporteComprasProductosImportacion(DTCompraProductosReporte, DTCompraProductosDetalleReporte);
                ReporteCompraproductosForm.Show();
            }
        }

    }

    public class EstadoCompra
    {
        private string _codigoEstadoCompra;
        private string _descripcion;

        public string CodigoEstadoCompra
        {
            get { return _codigoEstadoCompra; }
            set { _codigoEstadoCompra = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public EstadoCompra()
        {

        }
        public EstadoCompra(string codigoEstadoVenta, string descripcion)
        {
            this._codigoEstadoCompra = codigoEstadoVenta;
            this._descripcion = descripcion;
        }
    }
}
