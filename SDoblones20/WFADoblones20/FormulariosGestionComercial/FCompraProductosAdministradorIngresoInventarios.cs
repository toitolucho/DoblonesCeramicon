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
    public partial class FCompraProductosAdministradorIngresoInventarios : Form
    {
        ComprasProductosCLN _ComprasProductosCLN;
        ComprasProductosDetalleCLN _ComprasProductosDetalleCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        ComprasProductosDetalleEntregaCLN _ComprasProductosDetalleEntregaCLN;
        ComprasProductosEspecificosCLN _ComprasProductosEspecificosCLN;

        DataTable DTComprasProductoDetalle = new DataTable();
        CLCAD.DSDoblones20GestionComercial.ComprasProductosDataTable  DTCompraProducto;
        CLCAD.DSDoblones20GestionComercial.ListarComprasProductosDetalleEntregaParaRecepcionDataTable DTCompraProductoDetalleEntrega;
        CLCAD.DSDoblones20GestionComercial.ListarComprasProductosEspecificosParaRecepcionDataTable DTCompraProductosEspecificos;

        DataSet DSProductosEspecificos;
        public Button btnCerrarFormulario;

        public int NumeroAgencia { get; set; }
        private int NumeroPC = 0;
        private int CodigoUsuario;
        public int NumeroCompraProducto { get; set; }


        public FCompraProductosAdministradorIngresoInventarios(int NumeroAgencia, int NumeroPC, int NumeroCompraProducto, int CodigoUsuario)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            this.NumeroCompraProducto = NumeroCompraProducto;
            this.CodigoUsuario = CodigoUsuario;
            this.btnCerrarFormulario = new Button();
            this.btnCerrarFormulario.Click += new EventHandler(btnCerrarFormulario_Click);
            this.CancelButton = btnCerrarFormulario;
            _ComprasProductosCLN = new ComprasProductosCLN();
            _ComprasProductosDetalleCLN = new ComprasProductosDetalleCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _ComprasProductosEspecificosCLN = new ComprasProductosEspecificosCLN();
            _ComprasProductosDetalleEntregaCLN = new ComprasProductosDetalleEntregaCLN();

            DSProductosEspecificos = new DataSet();

            dtGVDetalleProductos.AutoGenerateColumns = false;
            dtGVProductosDetalleHistorial.AutoGenerateColumns = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        void btnCerrarFormulario_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FCompraProductosAdministradorIngresoInventarios_Load(object sender, EventArgs e)
        {
            DGCCodigoProducto.Width = 85;
            DGCNombreProducto.Width = 300;

            DGCCodigoProductoH.Width = 85;
            DGCNombreProductoH.Width = 350;

            formatearGrillaProductosEspecificos();
            CargarDatosCompra();
            
        }

        public void CargarDatosCompra()
        {
            DTCompraProducto = (CLCAD.DSDoblones20GestionComercial.ComprasProductosDataTable) _ComprasProductosCLN.ObtenerCompraProducto(NumeroAgencia, NumeroCompraProducto);
            DTComprasProductoDetalle = _ComprasProductosDetalleCLN.ListarCompraProductosDetalleEntregados(NumeroAgencia, NumeroCompraProducto, false);
            DTCompraProductoDetalleEntrega = _ComprasProductosDetalleEntregaCLN.ListarComprasProductosDetalleEntregaParaRecepcion(NumeroAgencia, NumeroCompraProducto);
            DTCompraProductosEspecificos = _ComprasProductosEspecificosCLN.ListarComprasProductosEspecificosParaRecepcion(NumeroAgencia, NumeroCompraProducto);

            dtGVDetalleProductos.DataSource = DTComprasProductoDetalle;
            //dtGVProductosDetalleEspecificosHistorial.DataSource = DTCompraProductoDetalleEntrega;
            dtGVProductosDetalleHistorial.DataSource = DTCompraProductoDetalleEntrega;

            cargarDatosProductosEspecificos();

            lblNumeroCompra.Text = NumeroCompraProducto.ToString();
            lblFechaCompra.Text = String.Format("{0:G}", DateTime.Parse(DTCompraProducto.Rows[0]["Fecha"].ToString()));

            if (String.IsNullOrEmpty(DTCompraProducto.Rows[0]["NumeroCuentaPorPagar"].ToString()))
            {
                checkCredito.Checked = false;
            }
            else
            {
                checkCredito.Checked = true;
            }

            switch (DTCompraProducto.Rows[0]["CodigoEstadoCompra"].ToString())
            {
                case "I":
                    lblCodigoEstadoCompra.Text = "INICIADA";
                    habilitarBotones(checkCredito.Checked, false, false);
                    break;
                case "A":
                    lblCodigoEstadoCompra.Text = "ANULADA";
                    habilitarBotones(false, false, false);
                    break;
                case "P":
                    lblCodigoEstadoCompra.Text = "PAGADA";
                    habilitarBotones(true, false, false);
                    break;
                case "D":
                    lblCodigoEstadoCompra.Text = "PENDIENTE";
                    habilitarBotones(false, true, true);
                    break;
                case "F":
                    lblCodigoEstadoCompra.Text = "FINALIZADA";
                    habilitarBotones(false, false, true);
                    break;
                case "X":
                    lblCodigoEstadoCompra.Text = "FINALIZADA INCOMPLETA";
                    habilitarBotones(false, false, true);
                    break;
            }


            
        }

        public void habilitarBotones(bool confirmarRecepcion, bool completarRecepcion, bool reportes)
        {
            this.btnConfirmarEntrega.Enabled = confirmarRecepcion;
            this.btnCompletarEntrega.Enabled = completarRecepcion;
            this.btnReportes.Enabled = reportes;
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

            if (DTCompraProductosEspecificos != null && DTCompraProductosEspecificos.Rows.Count > 0)
            {
                DSProductosEspecificos.Tables.Clear();
                DSProductosEspecificos.Tables.Add(DTCompraProductosEspecificos);
                dtGVProductosDetalleEspecificosHistorial.BindData(DSProductosEspecificos, DTCompraProductosEspecificos.TableName);
                dtGVProductosDetalleEspecificosHistorial.GroupTemplate.Column = dtGVProductosDetalleEspecificosHistorial.Columns[1];
                ListSortDirection direction = ListSortDirection.Ascending;
                dtGVProductosDetalleEspecificosHistorial.Sort(new DataRowComparer(0, direction));
            }
        }

        private void btnConfirmarEntrega_Click(object sender, EventArgs e)
        {
            FCompraProductosRecepcionInventarios _FCompraProductosRecepcionInventarios = new FCompraProductosRecepcionInventarios(NumeroAgencia, NumeroPC, NumeroCompraProducto, CodigoUsuario);
            _FCompraProductosRecepcionInventarios.ShowDialog();
            if (_FCompraProductosRecepcionInventarios.OperacionConfirmada)
            {
                CargarDatosCompra();
            }
            _FCompraProductosRecepcionInventarios.Dispose();

            
        }



        private void btnReportes_Click(object sender, EventArgs e)
        {
            DataTable DTCompraProductos = _ComprasProductosCLN.ListarCompraProductoReporte(NumeroAgencia, NumeroCompraProducto);
            DataTable DTCompraProductosGastos = _ComprasProductosCLN.ListarCompraProductosGastosRecepcionPartesReportes(NumeroAgencia, NumeroCompraProducto, true);
            DataTable DTCompraProductosRecepcion = _ComprasProductosCLN.ListarProductosRecepcionadosPorFechaReporte(NumeroAgencia, NumeroCompraProducto, null);


            //Para los Productos que tienen registrados sus Codigos Especificos
            DataRow[] DRProductosEspecificos = DTCompraProductosRecepcion.Select(" CodigoProductoEspecifico IS NOT NULL");
            foreach (DataRow DRProductoPE in DRProductosEspecificos)
            {
                DRProductoPE["CantidadEntregada"] = 1;
            }
            DTCompraProductosRecepcion.AcceptChanges();

            FReporteCompraProductosRecepcion _FReporteCompraProductosRecepcion = new FReporteCompraProductosRecepcion(DTCompraProductos, DTCompraProductosRecepcion, DTCompraProductosGastos, true);
            _FReporteCompraProductosRecepcion.ShowDialog(this);
            _FReporteCompraProductosRecepcion.Dispose();
        }

    }
}
