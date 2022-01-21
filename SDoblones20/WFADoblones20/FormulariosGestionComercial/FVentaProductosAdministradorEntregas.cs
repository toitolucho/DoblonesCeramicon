using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FVentaProductosAdministradorEntregas : Form
    {
        VentasProductosCLN _VentasProductosCLN;
        VentasProductosDetalleCLN _VentasProductosDetalleCLN;
        VentasProductosEspecificosCLN _VentasProductosEspecificosCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;        
        ClientesCLN _ClientesCLN;

        DataTable DTVentasProductos;
        DataTable DTVentasProductosDetalle;
        DataTable DTClientes;
        DataTable DTVentaProductosEntregadosHistorial;
        DataTable DTVentaProductosEspecificosEntregadosHistorial;

        DataSet DSProductosEspecificos = new DataSet();

        int NumeroVentaProducto = -1;
        int NumeroAgencia = 1;
        int NumeroPC = 0;
        int CodigoUsuario = 1;
        string CodigoEstadoVenta = "";
        public Button btnCerrarFormulario;

        public FVentaProductosAdministradorEntregas(int NumeroAgencia, int NumeroPC, int CodigoUsuario)
        {
            InitializeComponent();

            this.NumeroPC = NumeroPC;
            this.NumeroAgencia = NumeroAgencia;
            this.CodigoUsuario = CodigoUsuario;
            btnCerrarFormulario = new Button();
            btnCerrarFormulario.Click += new EventHandler(btnCerrarFormulario_Click);
            this.CancelButton = btnCerrarFormulario;
            _VentasProductosCLN = new VentasProductosCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _VentasProductosDetalleCLN = new VentasProductosDetalleCLN();
            _ClientesCLN = new ClientesCLN();
            _VentasProductosEspecificosCLN = new VentasProductosEspecificosCLN();

            NumeroVentaProducto = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductos");

            this.StartPosition = FormStartPosition.CenterScreen;

        }

        void btnCerrarFormulario_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FVentaProductosAdministradorEntregas_Load(object sender, EventArgs e)
        {
            DGCCodigoProducto.Width = 90;            
            DGCNombreProducto.Width = 450;

            DGCCodigoProductoH.Width = 80;
            DGCNombreProductoH.Width = 300;

            NumeroVentaProducto = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTransaccionFuncion("V", "P");
            if (NumeroVentaProducto > 0)
            {
                cargarDatosVentas(NumeroVentaProducto);
                txtBoxObservaciones.DataBindings.Add(new Binding("Text", bdsVentasProductos, "Observaciones", true));
                lblNumeroVenta.DataBindings.Add(new Binding("Text", bdsVentasProductos, "NumeroVentaProducto", true));
                lblFechaHoraVenta.DataBindings.Add(new Binding("Text", bdsVentasProductos, "FechaHoraVenta", true));
            }
            else
            {
                lblEstadoEntrega.Text = "";
                lblFechaHoraVenta.Text = "";
                lblCodigoEstadoVenta.Text = "";
                btnCompletarEntrega.Enabled = false;
                btnConfirmarEntrega.Enabled = false;
                btnReporteGeneral.Enabled = false;
            }            
            //txtBoxCliente.DataBindings.Add(new Binding("Text", bdsVentasProductos, "NombreCliente", true));
            

            dtGVProductosEntregados.AutoGenerateColumns = false;
            dtGVProductosEntregados.DataSource = DTVentasProductosDetalle;

            formatearGrillaProductosEspecificos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FVentasProductosBusqueda formBuscarTransaccion = new FVentasProductosBusqueda(NumeroAgencia, NumeroPC, CodigoUsuario);
            formBuscarTransaccion.esParaPagarVenta = false;
            formBuscarTransaccion.soloNavegacion = false;
            formBuscarTransaccion.formatearParaBusquedaEntregas();
            //formBuscarTransaccion.formatearEstiloParaVentas();
            formBuscarTransaccion.ShowDialog(this);
            NumeroVentaProducto = formBuscarTransaccion.NumeroTransaccion;
            if (NumeroVentaProducto > 0)
            {
                cargarDatosVentas(NumeroVentaProducto);
            }
            else
            {
                MessageBox.Show(this, "No ha Seleccionado una Venta de Productos, o posiblemente no se Encontró la venta que usted introdució", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            formBuscarTransaccion.Dispose();
        }

        public void cargarDatosVentas(int NumeroVentaProducto)
        {
            DTVentasProductos = _VentasProductosCLN.ObtenerVentaProducto(NumeroAgencia, NumeroVentaProducto);
            DTVentasProductosDetalle = _TransaccionesUtilidadesCLN.ListarDetalleDeVenta(NumeroAgencia, NumeroVentaProducto);
            if (DTVentasProductos.Rows.Count > 0)
            {
                dtGVProductosEntregados.AutoGenerateColumns = false;
                dtGVProductosEntregados.DataSource = DTVentasProductosDetalle;
                bdsVentasProductos.DataSource = DTVentasProductos;
                int CantidadEntregados = int.Parse(DTVentasProductosDetalle.Compute("count(CantidadVenta)", "CantidadVenta = CantidadEntregada").ToString());
                lblTotalEntregados.Text = "Nro Productos Entregados : " + CantidadEntregados.ToString();
                lblTotalPendientes.Text = "Nro Productos Pendientes : " + (DTVentasProductosDetalle.Rows.Count - CantidadEntregados).ToString();

                DTClientes = _ClientesCLN.ObtenerCliente(int.Parse(DTVentasProductos.Rows[0]["CodigoCliente"].ToString()));
                txtBoxCliente.Text = DTClientes.Rows[0]["NombreCliente"].ToString();
                checkCredito.Checked = !String.IsNullOrEmpty(DTVentasProductos.Rows[0]["NumeroCredito"].ToString());

                CodigoEstadoVenta = DTVentasProductos.Rows[0]["CodigoEstadoVenta"].ToString();

                DTVentaProductosEntregadosHistorial = _VentasProductosDetalleCLN.ListarVentaProductosDetalleEntregaParaVisualizarAlmacenes(NumeroAgencia, NumeroVentaProducto);
                DTVentaProductosEspecificosEntregadosHistorial = _VentasProductosEspecificosCLN.ListarVentasProductosEspecificosParaVisualizarAlmacenes(NumeroAgencia, NumeroVentaProducto);


                dtGVHistorialProductosEntregados.DataSource = DTVentaProductosEntregadosHistorial;


                if (DTVentaProductosEspecificosEntregadosHistorial.Rows.Count > 0)
                {
                    cargarDatosProductosEspecificos();
                }
                else
                {
                    dtGVHistorialProductosEntregadosPE.ClearGroups();
                    dtGVHistorialProductosEntregadosPE.BindData(null, null);
                }

                lblNumeroVenta.Text = NumeroVentaProducto.ToString();
                switch (CodigoEstadoVenta)
                {
                    //'I','P', 'F', 'A','T', 'C','E','D'
                    case "I"://INICIADA
                        habilitarBotones(false, false, false, true);
                        lblCodigoEstadoVenta.Text = "Iniciada";
                        lblEstadoEntrega.Text = "";
                        DGCCantidadEntregada.HeaderText = "Cant. a Entregar";
                        break;
                    case "P"://Pagada o Cancelada Monetariamente
                        habilitarBotones(true, false, false, true);
                        lblCodigoEstadoVenta.Text = "Entrega Venta Pagada";
                        lblEstadoEntrega.Text = "EN ESPERA DE CONFIRMACION DE ENTREGA";
                        DGCCantidadEntregada.HeaderText = "Cant. a Entregar";
                        break;
                    case "F"://Finalizada
                        habilitarBotones(false, false, true, true);
                        lblCodigoEstadoVenta.Text = "Finalizada";
                        lblEstadoEntrega.Text = "";
                        lblTotalEntregados.Visible = false;
                        lblTotalPendientes.Visible = false;
                        DGCCantidadEntregada.HeaderText = "Cant. Entregada";
                        break;
                    case "A"://Anulada
                        habilitarBotones(false, false, false, true);
                        lblCodigoEstadoVenta.Text = "Anulada";
                        lblEstadoEntrega.Text = "";
                        DGCCantidadEntregada.HeaderText = "Cant. Entregada";
                        break;
                    case "T":// Venta Institucional
                        habilitarBotones(true, false, false, true);
                        lblCodigoEstadoVenta.Text = "Entrega Venta Institucional";
                        lblEstadoEntrega.Text = "EN ESPERA DE CONFIRMACION ENTREGA";
                        DGCCantidadEntregada.HeaderText = "Cant. a Entregar";
                        break;
                    case "C":// Venta en Confianza
                        habilitarBotones(false, false, true, true);
                        lblCodigoEstadoVenta.Text = "En Espera de Pago de Institucion";
                        DGCCantidadEntregada.HeaderText = "Cant. Entregada";
                        lblEstadoEntrega.Text = "";
                        break;
                    case "E":// En Espera de Completar todo , de venta Normal
                        habilitarBotones(false, true, true, true);
                        lblCodigoEstadoVenta.Text = "Completar Entrega";
                        lblEstadoEntrega.Text = "EN ESPERA DE COMPLETAR ENTREGA";
                        DGCCantidadEntregada.HeaderText = "Cant. Entregada";
                        break;
                    case "D": // Pendiente de venta Institucional
                        habilitarBotones(false, true, true, true);
                        lblCodigoEstadoVenta.Text = "Completar Entrega";
                        lblEstadoEntrega.Text = "EN ESPERA DE COMPLETAR ENTREGA";
                        DGCCantidadEntregada.HeaderText = "Cant. Entregada";
                        break;

                }
            }
            else
            {
                btnCompletarEntrega.Enabled = false;
                btnConfirmarEntrega.Enabled = false;               
                
            }
                     

        }

        public void cargarDatosProductosEspecificos()
        {
            if (DTVentaProductosEspecificosEntregadosHistorial != null && DTVentaProductosEspecificosEntregadosHistorial.Rows.Count > 0)
            {
                DSProductosEspecificos.Tables.Clear(); 
                DSProductosEspecificos.Tables.Add(DTVentaProductosEspecificosEntregadosHistorial);
                dtGVHistorialProductosEntregadosPE.BindData(DSProductosEspecificos, DTVentaProductosEspecificosEntregadosHistorial.TableName);
                dtGVHistorialProductosEntregadosPE.GroupTemplate.Column = dtGVHistorialProductosEntregadosPE.Columns[3];
                ListSortDirection direction = ListSortDirection.Ascending;
                dtGVHistorialProductosEntregadosPE.Sort(new DataRowComparer(3, direction));
            }
        }


        public void formatearGrillaProductosEspecificos()
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dtGVHistorialProductosEntregadosPE.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVHistorialProductosEntregadosPE.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;

            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dtGVHistorialProductosEntregadosPE.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;

            this.dtGVHistorialProductosEntregadosPE.GridColor = System.Drawing.SystemColors.Control;
            this.dtGVHistorialProductosEntregadosPE.RowTemplate.Height = 19;
            this.dtGVHistorialProductosEntregadosPE.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtGVHistorialProductosEntregadosPE.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtGVHistorialProductosEntregadosPE.RowHeadersVisible = false;
            this.dtGVHistorialProductosEntregadosPE.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtGVHistorialProductosEntregadosPE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtGVHistorialProductosEntregadosPE.AllowUserToAddRows = false;
            this.dtGVHistorialProductosEntregadosPE.AllowUserToDeleteRows = false;
            this.dtGVHistorialProductosEntregadosPE.AllowUserToResizeRows = true;
            //this.dtGVVentaProductosEspecificos.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dtGVHistorialProductosEntregadosPE.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dtGVHistorialProductosEntregadosPE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVHistorialProductosEntregadosPE.ClearGroups();


        }


        public void habilitarBotones(bool confirmar, bool completar, bool reporte, bool buscar)
        {
            btnConfirmarEntrega.Enabled = confirmar;
            btnCompletarEntrega.Enabled = completar;
            btnReporteGeneral.Enabled = reporte;
            btnBuscar.Enabled = buscar;
        }

        private void btnConfirmarEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                bool esPosible = _VentasProductosCLN.EsPosibleConcluirEntregaDeProductos(NumeroAgencia, NumeroVentaProducto, "A");
                if (esPosible)
                {
                    //FVentasProductosEntregar2 _FVentaProductosEntrega = new FVentasProductosEntregar2(NumeroAgencia, NumeroVentaProducto, CodigoUsuario);
                    ////FVentaProductosEntrega _FVentaProductosEntrega = new FVentaProductosEntrega(NumeroAgencia, NumeroVentaProducto);
                    //_FVentaProductosEntrega.ShowDialog();

                    //if (_FVentaProductosEntrega.OperacionConfirmada)
                    //{
                    //    cargarDatosVentas(NumeroVentaProducto);
                    //}
                    //_FVentaProductosEntrega.Dispose();
                    ////_TransaccionesUtilidadesCLN.ActualizarInventarioProductosVentas(NumeroAgencia, NumeroVentaProducto);
                    ////_VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, CodigoEstadoVenta == "P" ? "E" : "D");//la mandamos como YA ENTREGADA Y se encuentra en confianza

                    FVentasProductosEntregaOK formEntrega = new FVentasProductosEntregaOK(NumeroAgencia, 1, CodigoUsuario, NumeroVentaProducto, -1);
                    if (formEntrega.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        cargarDatosVentas(NumeroVentaProducto);
                    }
                    
                }
                else
                {
                    MessageBox.Show(this, "No puede realizar ninguna operación sobre esta venta, debido a que la cantidad de entrega de productos sobrepasa a la cantidad de Existencia en Inventarios"
                        + Environment.NewLine + "Probablemente se realizó la entrega de los correspondientes Productos a esta venta en otra venta"
                        + Environment.NewLine + "Puede proceder a modificar la venta actual o esperar al reabastecimiento de Almacenes para la entrega actual", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);                    
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se Pudo actualizar correctamente la entrega de Productos");
            }
        }

        private void btnReporteGeneral_Click(object sender, EventArgs e)
        {
            DataTable DTProductosEntregados = _VentasProductosCLN.ListarVentaProductosDetalleConEspecificosCompletaParaAlmacenes(NumeroAgencia, NumeroVentaProducto);
            FReporteVentaProductosReciboEntregados ReporteProductosEntregados = new FReporteVentaProductosReciboEntregados(DTProductosEntregados, "CCPE");
            ReporteProductosEntregados.ShowDialog(this);
        }

        private void btnCompletarEntrega_Click(object sender, EventArgs e)
        {
            //FVentaProductosEntrega _FVentaProductosEntrega = new FVentaProductosEntrega(NumeroAgencia, NumeroVentaProducto);
            //FVentasProductosEntregar2 _FVentaProductosEntrega = new FVentasProductosEntregar2(NumeroAgencia, NumeroVentaProducto, CodigoUsuario);
            //_FVentaProductosEntrega.ShowDialog();

            //if (_FVentaProductosEntrega.OperacionConfirmada)
            //{
            //    cargarDatosVentas(NumeroVentaProducto);
            //}
            //_FVentaProductosEntrega.Dispose();

            FVentasProductosEntregaOK formEntrega = new FVentasProductosEntregaOK(NumeroAgencia, 1, CodigoUsuario, NumeroVentaProducto, null);
            if (formEntrega.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cargarDatosVentas(NumeroVentaProducto);
            }
            formEntrega.Dispose();
        }

        private void btnReporteHistorial_Click(object sender, EventArgs e)
        {
            DataTable DTVentaProductos = _VentasProductosCLN.ListarVentaProductoReporte(NumeroAgencia, NumeroVentaProducto);
            DataTable DTVentaProductosHistorial = _VentasProductosDetalleCLN.ListarVentaProductosDetalleEntregaParaVisualizarAlmacenes(NumeroAgencia, NumeroVentaProducto);

            FReporteVentaProductosEntregaHistorial _FReporteVentaProductosEntregaHistorial = new FReporteVentaProductosEntregaHistorial(DTVentaProductos, DTVentaProductosHistorial, false);
            _FReporteVentaProductosEntregaHistorial.ShowDialog(this);
        }

        private void btnVerHistorialEspecificos_Click(object sender, EventArgs e)
        {
            DataTable DTVentaProductos = _VentasProductosCLN.ListarVentaProductoReporte(NumeroAgencia, NumeroVentaProducto);
            DataTable DTVentaProductosHistorial = _VentasProductosEspecificosCLN.ListarVentasProductosEspecificosParaVisualizarAlmacenes(NumeroAgencia, NumeroVentaProducto);           

            FReporteVentaProductosEntregaHistorial _FReporteVentaProductosEntregaHistorial = new FReporteVentaProductosEntregaHistorial(DTVentaProductos, DTVentaProductosHistorial, true);
            _FReporteVentaProductosEntregaHistorial.ShowDialog(this);
        }
    }
}
 