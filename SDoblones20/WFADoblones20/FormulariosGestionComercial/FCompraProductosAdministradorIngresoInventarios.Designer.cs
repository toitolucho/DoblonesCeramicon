namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FCompraProductosAdministradorIngresoInventarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCompraProductosAdministradorIngresoInventarios));
            this.STIngresoProductos = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNumeroCompra = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCodigoEstadoCompra = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFechaHoraCompra = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFechaCompra = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.checkCredito = new System.Windows.Forms.CheckBox();
            this.txtBoxObservaciones = new System.Windows.Forms.TextBox();
            this.txtBoxProveedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gBoxProductosDetalle = new System.Windows.Forms.GroupBox();
            this.dtGVDetalleProductos = new System.Windows.Forms.DataGridView();
            this.DGCCodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadRecepcionada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadFaltante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProductosDetalle = new System.Windows.Forms.TabPage();
            this.tabProductosDetalleHistorial = new System.Windows.Forms.TabPage();
            this.dtGVProductosDetalleHistorial = new System.Windows.Forms.DataGridView();
            this.DGCCodigoProductoH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreProductoH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCFechaHoraRecepciion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadRecepcionadaH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabProductosDetalleEspecificosHistorial = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConfirmarEntrega = new System.Windows.Forms.ToolStripButton();
            this.btnCompletarEntrega = new System.Windows.Forms.ToolStripButton();
            this.btnReportes = new System.Windows.Forms.ToolStripButton();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.dtGVProductosDetalleEspecificosHistorial = new OutlookStyleControls.OutlookGrid();
            this.STIngresoProductos.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.gBoxProductosDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVDetalleProductos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabProductosDetalle.SuspendLayout();
            this.tabProductosDetalleHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosDetalleHistorial)).BeginInit();
            this.tabProductosDetalleEspecificosHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosDetalleEspecificosHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // STIngresoProductos
            // 
            this.STIngresoProductos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblNumeroCompra,
            this.toolStripStatusLabel2,
            this.lblCodigoEstadoCompra,
            this.lblFechaHoraCompra,
            this.lblFechaCompra});
            this.STIngresoProductos.Location = new System.Drawing.Point(0, 517);
            this.STIngresoProductos.Name = "STIngresoProductos";
            this.STIngresoProductos.Size = new System.Drawing.Size(780, 22);
            this.STIngresoProductos.TabIndex = 0;
            this.STIngresoProductos.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(104, 17);
            this.toolStripStatusLabel1.Text = "Nro Orden Compra :";
            // 
            // lblNumeroCompra
            // 
            this.lblNumeroCompra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroCompra.Name = "lblNumeroCompra";
            this.lblNumeroCompra.Size = new System.Drawing.Size(21, 17);
            this.lblNumeroCompra.Text = "00";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(120, 17);
            this.toolStripStatusLabel2.Text = "Estado Orden Compra :";
            // 
            // lblCodigoEstadoCompra
            // 
            this.lblCodigoEstadoCompra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoEstadoCompra.Name = "lblCodigoEstadoCompra";
            this.lblCodigoEstadoCompra.Size = new System.Drawing.Size(19, 17);
            this.lblCodigoEstadoCompra.Text = "....";
            // 
            // lblFechaHoraCompra
            // 
            this.lblFechaHoraCompra.Name = "lblFechaHoraCompra";
            this.lblFechaHoraCompra.Size = new System.Drawing.Size(99, 17);
            this.lblFechaHoraCompra.Text = "Fecha De Compra :";
            // 
            // lblFechaCompra
            // 
            this.lblFechaCompra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCompra.Name = "lblFechaCompra";
            this.lblFechaCompra.Size = new System.Drawing.Size(13, 17);
            this.lblFechaCompra.Text = "..";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConfirmarEntrega,
            this.btnCompletarEntrega,
            this.toolStripSeparator1,
            this.btnReportes,
            this.btnBuscar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(780, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.checkCredito);
            this.pnlSuperior.Controls.Add(this.txtBoxObservaciones);
            this.pnlSuperior.Controls.Add(this.txtBoxProveedor);
            this.pnlSuperior.Controls.Add(this.label2);
            this.pnlSuperior.Controls.Add(this.label1);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(3, 3);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(766, 87);
            this.pnlSuperior.TabIndex = 2;
            // 
            // checkCredito
            // 
            this.checkCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkCredito.AutoSize = true;
            this.checkCredito.Enabled = false;
            this.checkCredito.Location = new System.Drawing.Point(659, 8);
            this.checkCredito.Name = "checkCredito";
            this.checkCredito.Size = new System.Drawing.Size(90, 17);
            this.checkCredito.TabIndex = 4;
            this.checkCredito.Text = "En Efectivo ?";
            this.checkCredito.UseVisualStyleBackColor = true;
            // 
            // txtBoxObservaciones
            // 
            this.txtBoxObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxObservaciones.Location = new System.Drawing.Point(104, 32);
            this.txtBoxObservaciones.Multiline = true;
            this.txtBoxObservaciones.Name = "txtBoxObservaciones";
            this.txtBoxObservaciones.ReadOnly = true;
            this.txtBoxObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxObservaciones.Size = new System.Drawing.Size(645, 46);
            this.txtBoxObservaciones.TabIndex = 3;
            // 
            // txtBoxProveedor
            // 
            this.txtBoxProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxProveedor.Location = new System.Drawing.Point(104, 6);
            this.txtBoxProveedor.Name = "txtBoxProveedor";
            this.txtBoxProveedor.ReadOnly = true;
            this.txtBoxProveedor.Size = new System.Drawing.Size(549, 20);
            this.txtBoxProveedor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Observaciones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor";
            // 
            // gBoxProductosDetalle
            // 
            this.gBoxProductosDetalle.Controls.Add(this.dtGVDetalleProductos);
            this.gBoxProductosDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxProductosDetalle.Location = new System.Drawing.Point(3, 90);
            this.gBoxProductosDetalle.Name = "gBoxProductosDetalle";
            this.gBoxProductosDetalle.Size = new System.Drawing.Size(766, 373);
            this.gBoxProductosDetalle.TabIndex = 3;
            this.gBoxProductosDetalle.TabStop = false;
            this.gBoxProductosDetalle.Text = "Listado de Productos";
            // 
            // dtGVDetalleProductos
            // 
            this.dtGVDetalleProductos.AllowUserToAddRows = false;
            this.dtGVDetalleProductos.AllowUserToResizeRows = false;
            this.dtGVDetalleProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVDetalleProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVDetalleProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoProducto,
            this.DGCNombreProducto,
            this.DGCCantidadCompra,
            this.DGCCantidadRecepcionada,
            this.DGCCantidadFaltante});
            this.dtGVDetalleProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVDetalleProductos.Location = new System.Drawing.Point(3, 16);
            this.dtGVDetalleProductos.Name = "dtGVDetalleProductos";
            this.dtGVDetalleProductos.RowHeadersVisible = false;
            this.dtGVDetalleProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVDetalleProductos.Size = new System.Drawing.Size(760, 354);
            this.dtGVDetalleProductos.TabIndex = 0;
            // 
            // DGCCodigoProducto
            // 
            this.DGCCodigoProducto.DataPropertyName = "CodigoProducto";
            this.DGCCodigoProducto.HeaderText = "Código";
            this.DGCCodigoProducto.Name = "DGCCodigoProducto";
            this.DGCCodigoProducto.ToolTipText = "Identificador del Producto";
            // 
            // DGCNombreProducto
            // 
            this.DGCNombreProducto.DataPropertyName = "NombreProducto";
            this.DGCNombreProducto.HeaderText = "Producto";
            this.DGCNombreProducto.Name = "DGCNombreProducto";
            this.DGCNombreProducto.ToolTipText = "Nombre o Descripción del Producto";
            // 
            // DGCCantidadCompra
            // 
            this.DGCCantidadCompra.DataPropertyName = "CantidadCompra";
            this.DGCCantidadCompra.HeaderText = "Cant. Comprada";
            this.DGCCantidadCompra.Name = "DGCCantidadCompra";
            this.DGCCantidadCompra.ToolTipText = "Cantidad Solicitada al Proveedor";
            // 
            // DGCCantidadRecepcionada
            // 
            this.DGCCantidadRecepcionada.DataPropertyName = "CantidadRecepcionada";
            this.DGCCantidadRecepcionada.HeaderText = "Cant. Recepcionada";
            this.DGCCantidadRecepcionada.Name = "DGCCantidadRecepcionada";
            this.DGCCantidadRecepcionada.ToolTipText = "Cantidad Recepcionada Actualmente en Inventarios";
            // 
            // DGCCantidadFaltante
            // 
            this.DGCCantidadFaltante.DataPropertyName = "CantidadFaltante";
            this.DGCCantidadFaltante.HeaderText = "Cant. Faltante";
            this.DGCCantidadFaltante.Name = "DGCCantidadFaltante";
            this.DGCCantidadFaltante.ToolTipText = "Cantidad Restante para completar la Cantidad Comprada";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabProductosDetalle);
            this.tabControl1.Controls.Add(this.tabProductosDetalleHistorial);
            this.tabControl1.Controls.Add(this.tabProductosDetalleEspecificosHistorial);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 492);
            this.tabControl1.TabIndex = 4;
            // 
            // tabProductosDetalle
            // 
            this.tabProductosDetalle.Controls.Add(this.gBoxProductosDetalle);
            this.tabProductosDetalle.Controls.Add(this.pnlSuperior);
            this.tabProductosDetalle.Location = new System.Drawing.Point(4, 22);
            this.tabProductosDetalle.Name = "tabProductosDetalle";
            this.tabProductosDetalle.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductosDetalle.Size = new System.Drawing.Size(772, 466);
            this.tabProductosDetalle.TabIndex = 0;
            this.tabProductosDetalle.Text = "Detalle de la Compra";
            this.tabProductosDetalle.UseVisualStyleBackColor = true;
            // 
            // tabProductosDetalleHistorial
            // 
            this.tabProductosDetalleHistorial.Controls.Add(this.dtGVProductosDetalleHistorial);
            this.tabProductosDetalleHistorial.Controls.Add(this.flowLayoutPanel1);
            this.tabProductosDetalleHistorial.Location = new System.Drawing.Point(4, 22);
            this.tabProductosDetalleHistorial.Name = "tabProductosDetalleHistorial";
            this.tabProductosDetalleHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductosDetalleHistorial.Size = new System.Drawing.Size(772, 466);
            this.tabProductosDetalleHistorial.TabIndex = 1;
            this.tabProductosDetalleHistorial.Text = "Historial de Recepción de Productos";
            this.tabProductosDetalleHistorial.UseVisualStyleBackColor = true;
            // 
            // dtGVProductosDetalleHistorial
            // 
            this.dtGVProductosDetalleHistorial.AllowUserToAddRows = false;
            this.dtGVProductosDetalleHistorial.AllowUserToResizeRows = false;
            this.dtGVProductosDetalleHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVProductosDetalleHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVProductosDetalleHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVProductosDetalleHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoProductoH,
            this.DGCNombreProductoH,
            this.DGCFechaHoraRecepciion,
            this.DGCCantidadRecepcionadaH});
            this.dtGVProductosDetalleHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVProductosDetalleHistorial.Location = new System.Drawing.Point(3, 3);
            this.dtGVProductosDetalleHistorial.Name = "dtGVProductosDetalleHistorial";
            this.dtGVProductosDetalleHistorial.ReadOnly = true;
            this.dtGVProductosDetalleHistorial.RowHeadersVisible = false;
            this.dtGVProductosDetalleHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVProductosDetalleHistorial.Size = new System.Drawing.Size(766, 415);
            this.dtGVProductosDetalleHistorial.TabIndex = 1;
            // 
            // DGCCodigoProductoH
            // 
            this.DGCCodigoProductoH.DataPropertyName = "CodigoProducto";
            this.DGCCodigoProductoH.HeaderText = "CodigoProducto";
            this.DGCCodigoProductoH.Name = "DGCCodigoProductoH";
            this.DGCCodigoProductoH.ReadOnly = true;
            this.DGCCodigoProductoH.ToolTipText = "Código Identificador del Producto";
            // 
            // DGCNombreProductoH
            // 
            this.DGCNombreProductoH.DataPropertyName = "NombreProducto";
            this.DGCNombreProductoH.HeaderText = "Producto";
            this.DGCNombreProductoH.Name = "DGCNombreProductoH";
            this.DGCNombreProductoH.ReadOnly = true;
            this.DGCNombreProductoH.ToolTipText = "Nombre o Descripción del Producto";
            // 
            // DGCFechaHoraRecepciion
            // 
            this.DGCFechaHoraRecepciion.DataPropertyName = "FechaHoraEntrega";
            this.DGCFechaHoraRecepciion.HeaderText = "Fecha Recepcion";
            this.DGCFechaHoraRecepciion.Name = "DGCFechaHoraRecepciion";
            this.DGCFechaHoraRecepciion.ReadOnly = true;
            this.DGCFechaHoraRecepciion.ToolTipText = "Fecha hora de Recepción";
            // 
            // DGCCantidadRecepcionadaH
            // 
            this.DGCCantidadRecepcionadaH.DataPropertyName = "CantidadEntregada";
            this.DGCCantidadRecepcionadaH.HeaderText = "Cant. Recepcionada";
            this.DGCCantidadRecepcionadaH.Name = "DGCCantidadRecepcionadaH";
            this.DGCCantidadRecepcionadaH.ReadOnly = true;
            this.DGCCantidadRecepcionadaH.ToolTipText = "Cantidad Recepcionada e ingresada a Almacenes";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 418);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(766, 45);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tabProductosDetalleEspecificosHistorial
            // 
            this.tabProductosDetalleEspecificosHistorial.Controls.Add(this.flowLayoutPanel2);
            this.tabProductosDetalleEspecificosHistorial.Controls.Add(this.dtGVProductosDetalleEspecificosHistorial);
            this.tabProductosDetalleEspecificosHistorial.Location = new System.Drawing.Point(4, 22);
            this.tabProductosDetalleEspecificosHistorial.Name = "tabProductosDetalleEspecificosHistorial";
            this.tabProductosDetalleEspecificosHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductosDetalleEspecificosHistorial.Size = new System.Drawing.Size(772, 466);
            this.tabProductosDetalleEspecificosHistorial.TabIndex = 2;
            this.tabProductosDetalleEspecificosHistorial.Text = "Historial de Recepción de Productos Especificos";
            this.tabProductosDetalleEspecificosHistorial.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 427);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(766, 36);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoProducto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ToolTipText = "Identificador del Producto";
            this.dataGridViewTextBoxColumn1.Width = 151;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreProducto";
            this.dataGridViewTextBoxColumn2.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ToolTipText = "Nombre o Descripción del Producto";
            this.dataGridViewTextBoxColumn2.Width = 152;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CantidadCompra";
            this.dataGridViewTextBoxColumn3.HeaderText = "Cant. Comprada";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ToolTipText = "Cantidad Solicitada al Proveedor";
            this.dataGridViewTextBoxColumn3.Width = 151;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CantidadRecepcionada";
            this.dataGridViewTextBoxColumn4.HeaderText = "Cant. Recepcionada";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ToolTipText = "Cantidad Recepcionada Actualmente en Inventarios";
            this.dataGridViewTextBoxColumn4.Width = 152;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CantidadFaltante";
            this.dataGridViewTextBoxColumn5.HeaderText = "Cant. Faltante";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ToolTipText = "Cantidad Restante para completar la Cantidad Comprada";
            this.dataGridViewTextBoxColumn5.Width = 151;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "CodigoProducto";
            this.dataGridViewTextBoxColumn6.HeaderText = "CodigoProducto";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.ToolTipText = "Código Identificador del Producto";
            this.dataGridViewTextBoxColumn6.Width = 191;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "NombreProducto";
            this.dataGridViewTextBoxColumn7.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.ToolTipText = "Nombre o Descripción del Producto";
            this.dataGridViewTextBoxColumn7.Width = 191;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "FechaHoraEntrega";
            this.dataGridViewTextBoxColumn8.HeaderText = "Fecha Recepcion";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.ToolTipText = "Fecha hora de Recepción";
            this.dataGridViewTextBoxColumn8.Width = 190;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "CantidadEntregada";
            this.dataGridViewTextBoxColumn9.HeaderText = "Cant. Recepcionada";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.ToolTipText = "Cantidad Recepcionada e ingresada a Almacenes";
            this.dataGridViewTextBoxColumn9.Width = 191;
            // 
            // btnConfirmarEntrega
            // 
            this.btnConfirmarEntrega.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnConfirmarEntrega.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmarEntrega.Image")));
            this.btnConfirmarEntrega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfirmarEntrega.Name = "btnConfirmarEntrega";
            this.btnConfirmarEntrega.Size = new System.Drawing.Size(110, 22);
            this.btnConfirmarEntrega.Text = "&Confirmar Recepción";
            this.btnConfirmarEntrega.Click += new System.EventHandler(this.btnConfirmarEntrega_Click);
            // 
            // btnCompletarEntrega
            // 
            this.btnCompletarEntrega.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCompletarEntrega.Image = ((System.Drawing.Image)(resources.GetObject("btnCompletarEntrega.Image")));
            this.btnCompletarEntrega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompletarEntrega.Name = "btnCompletarEntrega";
            this.btnCompletarEntrega.Size = new System.Drawing.Size(112, 22);
            this.btnCompletarEntrega.Text = "Comple&tar Recepción";
            this.btnCompletarEntrega.Click += new System.EventHandler(this.btnConfirmarEntrega_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReportes.Image = ((System.Drawing.Image)(resources.GetObject("btnReportes.Image")));
            this.btnReportes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(55, 22);
            this.btnReportes.Text = "&Reportes";
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(43, 22);
            this.btnBuscar.Text = "&Buscar";
            // 
            // dtGVProductosDetalleEspecificosHistorial
            // 
            this.dtGVProductosDetalleEspecificosHistorial.CollapseIcon = null;
            this.dtGVProductosDetalleEspecificosHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVProductosDetalleEspecificosHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVProductosDetalleEspecificosHistorial.ExpandIcon = null;
            this.dtGVProductosDetalleEspecificosHistorial.Location = new System.Drawing.Point(3, 3);
            this.dtGVProductosDetalleEspecificosHistorial.Name = "dtGVProductosDetalleEspecificosHistorial";
            this.dtGVProductosDetalleEspecificosHistorial.Size = new System.Drawing.Size(766, 460);
            this.dtGVProductosDetalleEspecificosHistorial.TabIndex = 0;
            // 
            // FCompraProductosAdministradorIngresoInventarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 539);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.STIngresoProductos);
            this.Name = "FCompraProductosAdministradorIngresoInventarios";
            this.Text = "Ingreso de Productos a Inventario Por Compras";
            this.Load += new System.EventHandler(this.FCompraProductosAdministradorIngresoInventarios_Load);
            this.STIngresoProductos.ResumeLayout(false);
            this.STIngresoProductos.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.gBoxProductosDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVDetalleProductos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabProductosDetalle.ResumeLayout(false);
            this.tabProductosDetalleHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosDetalleHistorial)).EndInit();
            this.tabProductosDetalleEspecificosHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosDetalleEspecificosHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip STIngresoProductos;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.GroupBox gBoxProductosDetalle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProductosDetalle;
        private System.Windows.Forms.TabPage tabProductosDetalleHistorial;
        private System.Windows.Forms.TabPage tabProductosDetalleEspecificosHistorial;
        private System.Windows.Forms.CheckBox checkCredito;
        private System.Windows.Forms.TextBox txtBoxObservaciones;
        private System.Windows.Forms.TextBox txtBoxProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtGVDetalleProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadRecepcionada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadFaltante;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblNumeroCompra;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblCodigoEstadoCompra;
        private System.Windows.Forms.ToolStripStatusLabel lblFechaHoraCompra;
        private System.Windows.Forms.ToolStripButton btnConfirmarEntrega;
        private System.Windows.Forms.ToolStripButton btnCompletarEntrega;
        private System.Windows.Forms.ToolStripButton btnReportes;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.DataGridView dtGVProductosDetalleHistorial;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel lblFechaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProductoH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreProductoH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCFechaHoraRecepciion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadRecepcionadaH;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private OutlookStyleControls.OutlookGrid dtGVProductosDetalleEspecificosHistorial;
    }
}