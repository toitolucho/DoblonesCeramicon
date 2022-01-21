using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCAD;
using CLCLN.GestionComercial;
using CLCLN.Sistema;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FTRansferenciasProductosRecepcionEnvio : Form
    {

        TransferenciasProductosCLN _TransferenciasProductosCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        TransferenciasProductosDetalleRecepcionRecepcionCLN _TransferenciasProductosDetalleRecepcionRecepcionCLN;
        TransferenciasProductosEspecificosCLN _TransferenciasProductosEspecificosCLN;
        TransferenciasProductosDetalleCLN _TransferenciasProductosDetalleCLN;
        AgenciasCLN _AgenciasCLN;

        DSDoblones20GestionComercial2.ListarTransferenciaProductosEnviadosRecepcionadosDataTable DTProductosEnviadosRecepcionados;
        DSDoblones20GestionComercial2.ListarTransferenciasProductosDetalleRecepcionParaMostrarDataTable DTProductosEnviadosRecepcionadoHistorial;
        DSDoblones20GestionComercial2.TransferenciasProductosDataTable DTTransferenciasProductos;
        DSDoblones20GestionComercial2.ListarTransferenciasProductosEspecificosParaMostrarDataTable DTProductosEspecificosHistorial;
        DataTable DTAgencias;
        public Button btnCerrarFormulario;
        public int NumeroAgencia { get; set; }
        public int NumeroTransferenciaProducto { get; set; }
        private int CodigoUsuario;
        string TipoVisualizacion = "E"; // 'E'-> Envio de Mercaderia,  'R'->Recepción de Mercadería
        DataSet DSProductosEspecificos;

        public FTRansferenciasProductosRecepcionEnvio(int NumeroAgencia, int NumeroTransferencia, string TipoVisualizacion, int CodigoUsuario)
        {
            InitializeComponent();

            this.NumeroAgencia = NumeroAgencia;
            this.NumeroTransferenciaProducto = NumeroTransferencia;
            this.TipoVisualizacion = TipoVisualizacion;
            this.CodigoUsuario = CodigoUsuario;
            btnCerrarFormulario = new Button();
            this.btnCerrarFormulario.Click += new EventHandler(btnCerrarFormulario_Click);
            this.CancelButton = btnCerrarFormulario;
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _TransferenciasProductosCLN = new TransferenciasProductosCLN();
            _TransferenciasProductosDetalleCLN = new TransferenciasProductosDetalleCLN();
            _TransferenciasProductosDetalleRecepcionRecepcionCLN = new TransferenciasProductosDetalleRecepcionRecepcionCLN();
            _TransferenciasProductosEspecificosCLN = new TransferenciasProductosEspecificosCLN();
            _AgenciasCLN = new AgenciasCLN();

            DSProductosEspecificos = new DataSet();
            dtGVDetalleProductos.AutoGenerateColumns = false;

        }

        void btnCerrarFormulario_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FTRansferenciasProductosRecepcionEnvio_Load(object sender, EventArgs e)
        {
            cargarTransferencias(NumeroTransferenciaProducto, TipoVisualizacion);
        }


        /// <summary>
        /// Carga las Grillas, los Datos del Numero de Transferencia 
        /// de Acuerdo al Tipo de Visualización que se desea hacer
        /// en el Caso de que sea para mostrar una Recepción o Envio de Mercadería
        /// </summary>
        /// <param name="NumeroTransferencia"></param>
        /// <param name="CodigoTipoVisualizacion"></param>
        public void cargarTransferencias(int NumeroTransferencia, string CodigoTipoVisualizacion)
        {
            
            if (CodigoTipoVisualizacion == "R")
            {
                btnConfirmarRecepcion.Visible = true;
                btnCompletarRecepcion.Visible = true;
                btnConfirmarEntrega.Visible = false;
                btnCompletarEntrega.Visible = false;

                int NumeroAgenciaEmisora = _TransaccionesUtilidadesCLN.ObtenerNumeroAgenciaEmisoraDeTransferencias(NumeroTransferencia, NumeroAgencia);
                DTTransferenciasProductos = _TransferenciasProductosCLN.ObtenerTransferenciaProducto(NumeroAgenciaEmisora, NumeroTransferencia);

                DTAgencias = _AgenciasCLN.ObtenerAgencia(NumeroAgenciaEmisora);

                DGCCantidadFaltante.ToolTipText = "Cantidad Faltante por Recepcionar";
                DGCCantidadRecepcionadaEnviada.ToolTipText = "Cantidad Recepcionada";

                DTProductosEnviadosRecepcionadoHistorial = _TransferenciasProductosDetalleRecepcionRecepcionCLN.ListarTransferenciasProductosDetalleRecepcionParaMostrar(NumeroAgenciaEmisora, NumeroTransferencia, TipoVisualizacion);
                DTProductosEspecificosHistorial = _TransferenciasProductosEspecificosCLN.ListarTransferenciasProductosEspecificosParaMostrar(NumeroAgenciaEmisora, NumeroTransferencia, TipoVisualizacion);


                
            }
            else if (CodigoTipoVisualizacion == "E")
            {
                btnConfirmarRecepcion.Visible = false;
                btnCompletarRecepcion.Visible = false;
                btnConfirmarEntrega.Visible = true;
                btnCompletarEntrega.Visible = true;

                DTTransferenciasProductos = _TransferenciasProductosCLN.ObtenerTransferenciaProducto(NumeroAgencia, NumeroTransferencia);
                DTAgencias = _AgenciasCLN.ObtenerAgencia(NumeroAgencia);

                DGCCantidadFaltante.ToolTipText = "Cantidad Faltante por Enviar";
                DGCCantidadRecepcionadaEnviada.ToolTipText = "Cantidad Enviada";

                DTProductosEnviadosRecepcionadoHistorial = _TransferenciasProductosDetalleRecepcionRecepcionCLN.ListarTransferenciasProductosDetalleRecepcionParaMostrar(NumeroAgencia, NumeroTransferencia, TipoVisualizacion);
                DTProductosEspecificosHistorial = _TransferenciasProductosEspecificosCLN.ListarTransferenciasProductosEspecificosParaMostrar(NumeroAgencia, NumeroTransferencia, TipoVisualizacion);
            }
            else
            {
                MessageBox.Show("No se pudo lograr cargar Satisfactoriamente la Transferencia de Productos que desea Visualizar");
                return;
            }

            if (DTTransferenciasProductos.Count > 0)
            {
                lblNumeroTransferencia.Text = NumeroTransferencia.ToString();
                lblFechaHoraTransferencia.Text = String.Format("{0:G}", DTTransferenciasProductos[0].FechaHoraTransferencia);


                switch (DTTransferenciasProductos[0].CodigoEstadoTransferencia)
                {
                    // I'->Iniciada,'E' Enviada y Emitida,  'P'->Pagada y Confirmada Recepción, 'A'->Anulada, 'D'->Pendiente (Recepción por partes), 'F'->Finalizada,  
                    case "I":
                        lblCodigoEstadoTransferencia.Text = "INICIADA";
                        habilitarBotones(false, false, false, false, false);
                        break;
                    case "P":
                        lblCodigoEstadoTransferencia.Text = "PAGADA Y ENVIO EN ESPERA";
                        habilitarBotones(true, true, false, false, true);
                        break;
                    case "A":
                        lblCodigoEstadoTransferencia.Text = "ANULADA";
                        habilitarBotones(false, false, false, false, true);
                        break;

                    case "E":
                        lblCodigoEstadoTransferencia.Text = "ENVIADA Y EMITIDA";
                        habilitarBotones(false, false, true, false, true);
                        break;
                    
                    case "D":
                        lblCodigoEstadoTransferencia.Text = "PENDIENTE";
                        habilitarBotones(false, true, false, true, true);
                        break;
                    case "F":
                        lblCodigoEstadoTransferencia.Text = "FINALIZADA Y RECEPCION COMPLETADA";
                        habilitarBotones(false, false, false, false, true);
                        break;

                    case "X":
                        lblCodigoEstadoTransferencia.Text = "FINALIZADA SIN RECEPCION Y ENVIO COMPLETO";
                        habilitarBotones(false, false, false, false, true);
                        break;

                    default:
                        break;
                }
                cargarDatosProductosEspecificos();
                DTProductosEnviadosRecepcionados = _TransferenciasProductosDetalleCLN.ListarTransferenciaProductosEnviadosRecepcionados(NumeroAgencia, NumeroTransferencia, CodigoTipoVisualizacion, false);
                dtGVDetalleProductos.DataSource = DTProductosEnviadosRecepcionados;
                dtGVProductosDetalleHistorial.DataSource = DTProductosEnviadosRecepcionadoHistorial;               

                txtBoxProveedor.Text = DTAgencias.Rows[0]["NombreAgencia"].ToString();
                txtBoxObservaciones.Text = DTTransferenciasProductos[0].Observaciones;
            }
            else
            {
                MessageBox.Show(this, "No se pudo lograr cargar Satisfactoriamente la Transferencia de Productos que desea Visualizar" , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void habilitarBotones(bool confirmarEnvio, bool completarEnvio, bool confirmarRecepcion, bool completarRecepcion, bool reporte)
        {
            this.btnConfirmarEntrega.Enabled = confirmarEnvio;
            this.btnCompletarEntrega.Enabled = completarEnvio;
            this.btnConfirmarRecepcion.Enabled = confirmarRecepcion;
            this.btnCompletarRecepcion.Enabled = completarRecepcion;
            this.btnReportes.Enabled = reporte;
        }


        public void formatearGrillaProductosEspecificos()
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dtGVProductosDetalleEspecificosHistorial.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVProductosDetalleEspecificosHistorial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;

            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dtGVProductosDetalleEspecificosHistorial.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;

            this.dtGVProductosDetalleEspecificosHistorial.GridColor = System.Drawing.SystemColors.Control;
            this.dtGVProductosDetalleEspecificosHistorial.RowTemplate.Height = 19;
            this.dtGVProductosDetalleEspecificosHistorial.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtGVProductosDetalleEspecificosHistorial.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtGVProductosDetalleEspecificosHistorial.RowHeadersVisible = false;
            this.dtGVProductosDetalleEspecificosHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtGVProductosDetalleEspecificosHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtGVProductosDetalleEspecificosHistorial.AllowUserToAddRows = false;
            this.dtGVProductosDetalleEspecificosHistorial.AllowUserToDeleteRows = false;
            this.dtGVProductosDetalleEspecificosHistorial.AllowUserToResizeRows = true;
            //this.dtGVVentaProductosEspecificos.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dtGVProductosDetalleEspecificosHistorial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dtGVProductosDetalleEspecificosHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVProductosDetalleEspecificosHistorial.ClearGroups();


        }

        public void cargarDatosProductosEspecificos()
        {

            if (DTProductosEspecificosHistorial != null && DTProductosEspecificosHistorial.Rows.Count > 0)
            {
                DSProductosEspecificos.Tables.Clear();
                DSProductosEspecificos.Tables.Add(DTProductosEspecificosHistorial);
                dtGVProductosDetalleEspecificosHistorial.BindData(DSProductosEspecificos, DTProductosEspecificosHistorial.TableName);
                dtGVProductosDetalleEspecificosHistorial.GroupTemplate.Column = dtGVProductosDetalleEspecificosHistorial.Columns[1];
                ListSortDirection direction = ListSortDirection.Ascending;
                dtGVProductosDetalleEspecificosHistorial.Sort(new DataRowComparer(0, direction));
            }
        }

        private void btnConfirmarEntrega_Click(object sender, EventArgs e)
        {
            //FTransferenciasEnvioRecepcion _FTransferenciasEnvioRecepcion = new FTransferenciasEnvioRecepcion(NumeroAgencia, NumeroTransferenciaProducto, TipoVisualizacion);
            //_FTransferenciasEnvioRecepcion.ShowDialog(this);
            //if (_FTransferenciasEnvioRecepcion.OperacionConfirmada)
            //{
            //    cargarTransferencias(NumeroTransferenciaProducto, TipoVisualizacion);
            //}
            //_FTransferenciasEnvioRecepcion.Dispose();

            FTransferenciaProductosEnvio _FTransferenciaProductosEnvio = new FTransferenciaProductosEnvio(NumeroAgencia, NumeroTransferenciaProducto, CodigoUsuario);
            _FTransferenciaProductosEnvio.CodigoTipoEnvioRecepcion = "E";
            _FTransferenciaProductosEnvio.ShowDialog();
            if (_FTransferenciaProductosEnvio.OperacionConfirmada)
            {
                DateTime FechaHoraEnvio = _FTransferenciaProductosEnvio.FechaHoraRecepcion;
                DataTable DTTransferenciasProductosReporte = _TransferenciasProductosCLN.ListarTransferenciaProductosReporte(NumeroAgencia, NumeroTransferenciaProducto, "E");
                DataTable DTListarTransferenciaProductosDetalleRecepcionEnvioReporte = _TransferenciasProductosDetalleRecepcionRecepcionCLN.ListarTransferenciaProductosDetalleRecepcionEnvioReporte(NumeroAgencia, NumeroTransferenciaProducto, "E", FechaHoraEnvio);
                DataTable DTListarTransferenciaProductosEspecificosReporte = _TransferenciasProductosEspecificosCLN.ListarTransferenciaProductosEspecificosReporte(NumeroAgencia, NumeroTransferenciaProducto, "E", FechaHoraEnvio);
                FReporteTransferenciaProductosDetalleRecepcionEnvio _FReporteTransferenciaProductos = new FReporteTransferenciaProductosDetalleRecepcionEnvio(DTListarTransferenciaProductosDetalleRecepcionEnvioReporte, DTTransferenciasProductosReporte, DTListarTransferenciaProductosEspecificosReporte);
                _FReporteTransferenciaProductos.Show();
                cargarTransferencias(NumeroTransferenciaProducto, TipoVisualizacion);
            }
            _FTransferenciaProductosEnvio.Dispose();
        }

        private void btnConfirmarRecepcion_Click(object sender, EventArgs e)
        {
            FTransferenciasProductosRecepcion _FTransferenciasProductosRecepcion = new FTransferenciasProductosRecepcion(NumeroAgencia, NumeroTransferenciaProducto, CodigoUsuario);
            _FTransferenciasProductosRecepcion.ShowDialog();
            if (_FTransferenciasProductosRecepcion.OperacionConfirmada)
            {
                DateTime? FechaHoraEnvio = _FTransferenciasProductosRecepcion.FechaEnvio;
                DataTable DTTransferenciasProductosReporte = _TransferenciasProductosCLN.ListarTransferenciaProductosReporte(NumeroAgencia, NumeroTransferenciaProducto, "R");                
                DataTable DTListarTransferenciaProductosDetalleRecepcionEnvioReporte = _TransferenciasProductosDetalleRecepcionRecepcionCLN.ListarTransferenciaProductosDetalleRecepcionEnvioReporte(NumeroAgencia, NumeroTransferenciaProducto, "R", FechaHoraEnvio.Value);
                DataTable DTListarTransferenciaProductosEspecificosReporte = _TransferenciasProductosEspecificosCLN.ListarTransferenciaProductosEspecificosReporte(NumeroAgencia, NumeroTransferenciaProducto, "R", FechaHoraEnvio);
                FReporteTransferenciaProductosDetalleRecepcionEnvio _FReporteTransferenciaProductos = new FReporteTransferenciaProductosDetalleRecepcionEnvio(DTListarTransferenciaProductosDetalleRecepcionEnvioReporte, DTTransferenciasProductosReporte, DTListarTransferenciaProductosEspecificosReporte);
                _FReporteTransferenciaProductos.Show();

                cargarTransferencias(NumeroTransferenciaProducto, TipoVisualizacion);
            }
            _FTransferenciasProductosRecepcion.Dispose();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(this, "Desea ver solo un resumen de " + TipoVisualizacion == "E" ? "Envio " : "Recepcion "
                + "de los productos de esta Transferencia (Si), o un Resumen Completo de Envios y Transferencias(No)",
                "Reportes Transferencias de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string tipoVistaEnvioRecepcion = respuesta == DialogResult.Yes ? null : TipoVisualizacion;
            DataTable DTTransferenciasProductosReporte = _TransferenciasProductosCLN.ListarTransferenciaProductosReporte(NumeroAgencia, NumeroTransferenciaProducto, TipoVisualizacion);
            DataTable DTListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte = _TransferenciasProductosDetalleRecepcionRecepcionCLN.ListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte(NumeroAgencia, NumeroTransferenciaProducto, tipoVistaEnvioRecepcion);
            FReporteTransferenciaProductosDetalleRecepcionEnvioGeneral _FReporteTransferenciaProductosDetalleRecepcionEnvioGeneral
                = new FReporteTransferenciaProductosDetalleRecepcionEnvioGeneral(DTTransferenciasProductosReporte, DTListarTransferenciaProductosDetalleRecepcionEnvioGeneralReporte);
            _FReporteTransferenciaProductosDetalleRecepcionEnvioGeneral.Show();            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DateTime FechaHoraEnvio = DateTime.Parse("2010-09-10 17:14:29.077");
            DataTable DTTransferenciasProductosReporte = _TransferenciasProductosCLN.ListarTransferenciaProductosReporte(NumeroAgencia, NumeroTransferenciaProducto, "E");
            DataTable DTListarTransferenciaProductosDetalleRecepcionEnvioReporte = _TransferenciasProductosDetalleRecepcionRecepcionCLN.ListarTransferenciaProductosDetalleRecepcionEnvioReporte(NumeroAgencia, NumeroTransferenciaProducto, "E", FechaHoraEnvio);
            DataTable DTListarTransferenciaProductosEspecificosReporte = _TransferenciasProductosEspecificosCLN.ListarTransferenciaProductosEspecificosReporte(NumeroAgencia, NumeroTransferenciaProducto, "E", FechaHoraEnvio);
            FReporteTransferenciaProductosDetalleRecepcionEnvio _FReporteTransferenciaProductos = new FReporteTransferenciaProductosDetalleRecepcionEnvio(DTListarTransferenciaProductosDetalleRecepcionEnvioReporte, DTTransferenciasProductosReporte, DTListarTransferenciaProductosEspecificosReporte);
            _FReporteTransferenciaProductos.Show();
        }

        

    }
}
