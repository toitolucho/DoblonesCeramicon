namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FVentaProductosAdministradorEntregas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FVentaProductosAdministradorEntregas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStripEntregaProductos = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNumeroVenta = new WFADoblones20.Utilitarios.BindableToolStripLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCodigoEstadoVenta = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFechaHoraVenta = new WFADoblones20.Utilitarios.BindableToolStripLabel();
            this.lblTotalEntregados = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalPendientes = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripEntregaProductos = new System.Windows.Forms.ToolStrip();
            this.btnConfirmarEntrega = new System.Windows.Forms.ToolStripButton();
            this.btnCompletarEntrega = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReporteGeneral = new System.Windows.Forms.ToolStripButton();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.gBEntregaProductosDatos = new System.Windows.Forms.GroupBox();
            this.lblEstadoEntrega = new System.Windows.Forms.Label();
            this.txtBoxObservaciones = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkCredito = new System.Windows.Forms.CheckBox();
            this.txtBoxCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.gbEntregaProductosDetalle = new System.Windows.Forms.GroupBox();
            this.dtGVProductosEntregados = new System.Windows.Forms.DataGridView();
            this.DGCCodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadEntregada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageDatosPrincipales = new System.Windows.Forms.TabPage();
            this.pageHistorialEntrega = new System.Windows.Forms.TabPage();
            this.dtGVHistorialProductosEntregados = new System.Windows.Forms.DataGridView();
            this.DGCCodigoProductoH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreProductoH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCFechaHoraEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadEntregadaH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReporteHistorial = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtGVHistorialProductosEntregadosPE = new OutlookStyleControls.OutlookGrid();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnVerHistorialEspecificos = new System.Windows.Forms.Button();
            this.bdsVentasProductos = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStripEntregaProductos.SuspendLayout();
            this.toolStripEntregaProductos.SuspendLayout();
            this.gBEntregaProductosDatos.SuspendLayout();
            this.gbEntregaProductosDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosEntregados)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.pageDatosPrincipales.SuspendLayout();
            this.pageHistorialEntrega.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVHistorialProductosEntregados)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVHistorialProductosEntregadosPE)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVentasProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStripEntregaProductos
            // 
            this.statusStripEntregaProductos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblNumeroVenta,
            this.toolStripStatusLabel2,
            this.lblCodigoEstadoVenta,
            this.toolStripStatusLabel3,
            this.lblFechaHoraVenta,
            this.lblTotalEntregados,
            this.lblTotalPendientes});
            this.statusStripEntregaProductos.Location = new System.Drawing.Point(0, 373);
            this.statusStripEntregaProductos.Name = "statusStripEntregaProductos";
            this.statusStripEntregaProductos.Size = new System.Drawing.Size(827, 22);
            this.statusStripEntregaProductos.TabIndex = 0;
            this.statusStripEntregaProductos.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(66, 17);
            this.toolStripStatusLabel1.Text = "Nro Venta :";
            // 
            // lblNumeroVenta
            // 
            this.lblNumeroVenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroVenta.Name = "lblNumeroVenta";
            this.lblNumeroVenta.Size = new System.Drawing.Size(21, 20);
            this.lblNumeroVenta.Text = "00";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabel2.Text = "Estado Venta :";
            // 
            // lblCodigoEstadoVenta
            // 
            this.lblCodigoEstadoVenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoEstadoVenta.Name = "lblCodigoEstadoVenta";
            this.lblCodigoEstadoVenta.Size = new System.Drawing.Size(13, 17);
            this.lblCodigoEstadoVenta.Text = "  ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(93, 17);
            this.toolStripStatusLabel3.Text = "Fecha de Venta :";
            // 
            // lblFechaHoraVenta
            // 
            this.lblFechaHoraVenta.Name = "lblFechaHoraVenta";
            this.lblFechaHoraVenta.Size = new System.Drawing.Size(22, 20);
            this.lblFechaHoraVenta.Text = "   ..";
            // 
            // lblTotalEntregados
            // 
            this.lblTotalEntregados.Name = "lblTotalEntregados";
            this.lblTotalEntregados.Size = new System.Drawing.Size(110, 17);
            this.lblTotalEntregados.Text = "Total Completos : 0";
            // 
            // lblTotalPendientes
            // 
            this.lblTotalPendientes.Name = "lblTotalPendientes";
            this.lblTotalPendientes.Size = new System.Drawing.Size(110, 17);
            this.lblTotalPendientes.Text = "Total Pendientes : 0";
            // 
            // toolStripEntregaProductos
            // 
            this.toolStripEntregaProductos.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEntregaProductos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConfirmarEntrega,
            this.btnCompletarEntrega,
            this.toolStripSeparator1,
            this.btnReporteGeneral,
            this.btnBuscar});
            this.toolStripEntregaProductos.Location = new System.Drawing.Point(0, 0);
            this.toolStripEntregaProductos.Name = "toolStripEntregaProductos";
            this.toolStripEntregaProductos.Size = new System.Drawing.Size(827, 25);
            this.toolStripEntregaProductos.TabIndex = 1;
            this.toolStripEntregaProductos.Text = "toolStrip1";
            // 
            // btnConfirmarEntrega
            // 
            this.btnConfirmarEntrega.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnConfirmarEntrega.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmarEntrega.Image")));
            this.btnConfirmarEntrega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfirmarEntrega.Name = "btnConfirmarEntrega";
            this.btnConfirmarEntrega.Size = new System.Drawing.Size(108, 22);
            this.btnConfirmarEntrega.Text = "&Confirmar Entrega";
            this.btnConfirmarEntrega.Click += new System.EventHandler(this.btnConfirmarEntrega_Click);
            // 
            // btnCompletarEntrega
            // 
            this.btnCompletarEntrega.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCompletarEntrega.Image = ((System.Drawing.Image)(resources.GetObject("btnCompletarEntrega.Image")));
            this.btnCompletarEntrega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompletarEntrega.Name = "btnCompletarEntrega";
            this.btnCompletarEntrega.Size = new System.Drawing.Size(110, 22);
            this.btnCompletarEntrega.Text = "Comple&tar Entrega";
            this.btnCompletarEntrega.Click += new System.EventHandler(this.btnCompletarEntrega_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnReporteGeneral
            // 
            this.btnReporteGeneral.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReporteGeneral.Image = ((System.Drawing.Image)(resources.GetObject("btnReporteGeneral.Image")));
            this.btnReporteGeneral.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReporteGeneral.Name = "btnReporteGeneral";
            this.btnReporteGeneral.Size = new System.Drawing.Size(52, 22);
            this.btnReporteGeneral.Text = "&Reporte";
            this.btnReporteGeneral.Click += new System.EventHandler(this.btnReporteGeneral_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(46, 22);
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gBEntregaProductosDatos
            // 
            this.gBEntregaProductosDatos.Controls.Add(this.lblEstadoEntrega);
            this.gBEntregaProductosDatos.Controls.Add(this.txtBoxObservaciones);
            this.gBEntregaProductosDatos.Controls.Add(this.label1);
            this.gBEntregaProductosDatos.Controls.Add(this.checkCredito);
            this.gBEntregaProductosDatos.Controls.Add(this.txtBoxCliente);
            this.gBEntregaProductosDatos.Controls.Add(this.lblCliente);
            this.gBEntregaProductosDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBEntregaProductosDatos.Location = new System.Drawing.Point(3, 3);
            this.gBEntregaProductosDatos.Name = "gBEntregaProductosDatos";
            this.gBEntregaProductosDatos.Size = new System.Drawing.Size(813, 100);
            this.gBEntregaProductosDatos.TabIndex = 2;
            this.gBEntregaProductosDatos.TabStop = false;
            this.gBEntregaProductosDatos.Text = "Datos de la Venta";
            // 
            // lblEstadoEntrega
            // 
            this.lblEstadoEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstadoEntrega.AutoSize = true;
            this.lblEstadoEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoEntrega.ForeColor = System.Drawing.Color.Red;
            this.lblEstadoEntrega.Location = new System.Drawing.Point(495, 18);
            this.lblEstadoEntrega.Name = "lblEstadoEntrega";
            this.lblEstadoEntrega.Size = new System.Drawing.Size(149, 13);
            this.lblEstadoEntrega.TabIndex = 5;
            this.lblEstadoEntrega.Text = "ENTREGA INCOMPLETA";
            // 
            // txtBoxObservaciones
            // 
            this.txtBoxObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxObservaciones.Location = new System.Drawing.Point(112, 46);
            this.txtBoxObservaciones.Multiline = true;
            this.txtBoxObservaciones.Name = "txtBoxObservaciones";
            this.txtBoxObservaciones.ReadOnly = true;
            this.txtBoxObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxObservaciones.Size = new System.Drawing.Size(695, 38);
            this.txtBoxObservaciones.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "&Observaciones";
            // 
            // checkCredito
            // 
            this.checkCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkCredito.AutoSize = true;
            this.checkCredito.Enabled = false;
            this.checkCredito.Location = new System.Drawing.Point(411, 16);
            this.checkCredito.Name = "checkCredito";
            this.checkCredito.Size = new System.Drawing.Size(78, 17);
            this.checkCredito.TabIndex = 2;
            this.checkCredito.Text = "A Crédito ?";
            this.checkCredito.UseVisualStyleBackColor = true;
            // 
            // txtBoxCliente
            // 
            this.txtBoxCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxCliente.Location = new System.Drawing.Point(74, 16);
            this.txtBoxCliente.Name = "txtBoxCliente";
            this.txtBoxCliente.ReadOnly = true;
            this.txtBoxCliente.Size = new System.Drawing.Size(331, 20);
            this.txtBoxCliente.TabIndex = 1;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(24, 20);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "&Cliente";
            // 
            // gbEntregaProductosDetalle
            // 
            this.gbEntregaProductosDetalle.Controls.Add(this.dtGVProductosEntregados);
            this.gbEntregaProductosDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEntregaProductosDetalle.Location = new System.Drawing.Point(3, 103);
            this.gbEntregaProductosDetalle.Name = "gbEntregaProductosDetalle";
            this.gbEntregaProductosDetalle.Size = new System.Drawing.Size(813, 216);
            this.gbEntregaProductosDetalle.TabIndex = 3;
            this.gbEntregaProductosDetalle.TabStop = false;
            this.gbEntregaProductosDetalle.Text = "Detalle de Venta de Productos";
            // 
            // dtGVProductosEntregados
            // 
            this.dtGVProductosEntregados.AllowUserToAddRows = false;
            this.dtGVProductosEntregados.AllowUserToResizeRows = false;
            this.dtGVProductosEntregados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVProductosEntregados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVProductosEntregados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVProductosEntregados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVProductosEntregados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoProducto,
            this.DGCNombreProducto,
            this.DGCCantidadVenta,
            this.DGCCantidadEntregada});
            this.dtGVProductosEntregados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVProductosEntregados.Location = new System.Drawing.Point(3, 16);
            this.dtGVProductosEntregados.Name = "dtGVProductosEntregados";
            this.dtGVProductosEntregados.RowHeadersVisible = false;
            this.dtGVProductosEntregados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVProductosEntregados.Size = new System.Drawing.Size(807, 197);
            this.dtGVProductosEntregados.TabIndex = 0;
            // 
            // DGCCodigoProducto
            // 
            this.DGCCodigoProducto.DataPropertyName = "CodigoProducto";
            this.DGCCodigoProducto.HeaderText = "Código";
            this.DGCCodigoProducto.Name = "DGCCodigoProducto";
            this.DGCCodigoProducto.ReadOnly = true;
            this.DGCCodigoProducto.ToolTipText = "Código de Producto";
            // 
            // DGCNombreProducto
            // 
            this.DGCNombreProducto.DataPropertyName = "NombreProducto";
            this.DGCNombreProducto.HeaderText = "Producto";
            this.DGCNombreProducto.Name = "DGCNombreProducto";
            this.DGCNombreProducto.ReadOnly = true;
            this.DGCNombreProducto.ToolTipText = "Nombre o Descripción del Producto";
            // 
            // DGCCantidadVenta
            // 
            this.DGCCantidadVenta.DataPropertyName = "CantidadVenta";
            this.DGCCantidadVenta.HeaderText = "Cant. Vendida";
            this.DGCCantidadVenta.Name = "DGCCantidadVenta";
            this.DGCCantidadVenta.ReadOnly = true;
            this.DGCCantidadVenta.ToolTipText = "Cantidad Vendida al Cliente";
            // 
            // DGCCantidadEntregada
            // 
            this.DGCCantidadEntregada.DataPropertyName = "CantidadEntregada";
            this.DGCCantidadEntregada.HeaderText = "Cant. Entregada";
            this.DGCCantidadEntregada.Name = "DGCCantidadEntregada";
            this.DGCCantidadEntregada.ReadOnly = true;
            this.DGCCantidadEntregada.ToolTipText = "Cantidad que se ha Entregado o que se debe entregar";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageDatosPrincipales);
            this.tabControl1.Controls.Add(this.pageHistorialEntrega);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(827, 348);
            this.tabControl1.TabIndex = 0;
            // 
            // pageDatosPrincipales
            // 
            this.pageDatosPrincipales.Controls.Add(this.gbEntregaProductosDetalle);
            this.pageDatosPrincipales.Controls.Add(this.gBEntregaProductosDatos);
            this.pageDatosPrincipales.Location = new System.Drawing.Point(4, 22);
            this.pageDatosPrincipales.Name = "pageDatosPrincipales";
            this.pageDatosPrincipales.Padding = new System.Windows.Forms.Padding(3);
            this.pageDatosPrincipales.Size = new System.Drawing.Size(819, 322);
            this.pageDatosPrincipales.TabIndex = 0;
            this.pageDatosPrincipales.Text = "Detalle Venta";
            this.pageDatosPrincipales.UseVisualStyleBackColor = true;
            // 
            // pageHistorialEntrega
            // 
            this.pageHistorialEntrega.Controls.Add(this.dtGVHistorialProductosEntregados);
            this.pageHistorialEntrega.Controls.Add(this.flowLayoutPanel1);
            this.pageHistorialEntrega.Location = new System.Drawing.Point(4, 22);
            this.pageHistorialEntrega.Name = "pageHistorialEntrega";
            this.pageHistorialEntrega.Padding = new System.Windows.Forms.Padding(3);
            this.pageHistorialEntrega.Size = new System.Drawing.Size(819, 322);
            this.pageHistorialEntrega.TabIndex = 1;
            this.pageHistorialEntrega.Text = "Historial Entrega";
            this.pageHistorialEntrega.UseVisualStyleBackColor = true;
            // 
            // dtGVHistorialProductosEntregados
            // 
            this.dtGVHistorialProductosEntregados.AllowUserToAddRows = false;
            this.dtGVHistorialProductosEntregados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVHistorialProductosEntregados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVHistorialProductosEntregados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVHistorialProductosEntregados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoProductoH,
            this.DGCNombreProductoH,
            this.DGCFechaHoraEntrega,
            this.DGCCantidadEntregadaH});
            this.dtGVHistorialProductosEntregados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVHistorialProductosEntregados.Location = new System.Drawing.Point(3, 3);
            this.dtGVHistorialProductosEntregados.Name = "dtGVHistorialProductosEntregados";
            this.dtGVHistorialProductosEntregados.RowHeadersVisible = false;
            this.dtGVHistorialProductosEntregados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVHistorialProductosEntregados.Size = new System.Drawing.Size(813, 286);
            this.dtGVHistorialProductosEntregados.TabIndex = 0;
            // 
            // DGCCodigoProductoH
            // 
            this.DGCCodigoProductoH.DataPropertyName = "CodigoProducto";
            this.DGCCodigoProductoH.HeaderText = "Codigo";
            this.DGCCodigoProductoH.Name = "DGCCodigoProductoH";
            this.DGCCodigoProductoH.ReadOnly = true;
            // 
            // DGCNombreProductoH
            // 
            this.DGCNombreProductoH.DataPropertyName = "NombreProducto";
            this.DGCNombreProductoH.HeaderText = "Producto";
            this.DGCNombreProductoH.Name = "DGCNombreProductoH";
            this.DGCNombreProductoH.ReadOnly = true;
            // 
            // DGCFechaHoraEntrega
            // 
            this.DGCFechaHoraEntrega.DataPropertyName = "FechaHoraEntrega";
            this.DGCFechaHoraEntrega.HeaderText = "Fecha Entrega";
            this.DGCFechaHoraEntrega.Name = "DGCFechaHoraEntrega";
            this.DGCFechaHoraEntrega.ReadOnly = true;
            // 
            // DGCCantidadEntregadaH
            // 
            this.DGCCantidadEntregadaH.DataPropertyName = "CantidadEntregada";
            this.DGCCantidadEntregadaH.HeaderText = "Cant Entregada";
            this.DGCCantidadEntregadaH.Name = "DGCCantidadEntregadaH";
            this.DGCCantidadEntregadaH.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnReporteHistorial);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 289);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(813, 30);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnReporteHistorial
            // 
            this.btnReporteHistorial.Location = new System.Drawing.Point(735, 3);
            this.btnReporteHistorial.Name = "btnReporteHistorial";
            this.btnReporteHistorial.Size = new System.Drawing.Size(75, 23);
            this.btnReporteHistorial.TabIndex = 0;
            this.btnReporteHistorial.Text = "&Ver Historial";
            this.btnReporteHistorial.UseVisualStyleBackColor = true;
            this.btnReporteHistorial.Click += new System.EventHandler(this.btnReporteHistorial_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtGVHistorialProductosEntregadosPE);
            this.tabPage1.Controls.Add(this.flowLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(819, 322);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Historial Productos Especificos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtGVHistorialProductosEntregadosPE
            // 
            this.dtGVHistorialProductosEntregadosPE.CollapseIcon = null;
            this.dtGVHistorialProductosEntregadosPE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVHistorialProductosEntregadosPE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVHistorialProductosEntregadosPE.ExpandIcon = null;
            this.dtGVHistorialProductosEntregadosPE.Location = new System.Drawing.Point(3, 3);
            this.dtGVHistorialProductosEntregadosPE.Name = "dtGVHistorialProductosEntregadosPE";
            this.dtGVHistorialProductosEntregadosPE.Size = new System.Drawing.Size(813, 290);
            this.dtGVHistorialProductosEntregadosPE.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnVerHistorialEspecificos);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 293);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(813, 26);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // btnVerHistorialEspecificos
            // 
            this.btnVerHistorialEspecificos.Location = new System.Drawing.Point(648, 3);
            this.btnVerHistorialEspecificos.Name = "btnVerHistorialEspecificos";
            this.btnVerHistorialEspecificos.Size = new System.Drawing.Size(162, 23);
            this.btnVerHistorialEspecificos.TabIndex = 0;
            this.btnVerHistorialEspecificos.Text = "Ver Historial de Prod.  Esp.";
            this.btnVerHistorialEspecificos.UseVisualStyleBackColor = true;
            this.btnVerHistorialEspecificos.Click += new System.EventHandler(this.btnVerHistorialEspecificos_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoProducto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Código de Producto";
            this.dataGridViewTextBoxColumn1.Width = 169;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CodigoProducto";
            this.dataGridViewTextBoxColumn2.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.ToolTipText = "Nombre o Descripción del Producto";
            this.dataGridViewTextBoxColumn2.Width = 170;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CantidadVenta";
            this.dataGridViewTextBoxColumn3.HeaderText = "Cant. Vendida";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.ToolTipText = "Cantidad Vendida al Cliente";
            this.dataGridViewTextBoxColumn3.Width = 169;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CantidadEntregada";
            this.dataGridViewTextBoxColumn4.HeaderText = "Cant. Entregada";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.ToolTipText = "Cantidad que se ha Entregado o que se debe entregar";
            this.dataGridViewTextBoxColumn4.Width = 169;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CodigoProducto";
            this.dataGridViewTextBoxColumn5.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 203;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "NombreProducto";
            this.dataGridViewTextBoxColumn6.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 202;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "FechaHoraEntrega";
            this.dataGridViewTextBoxColumn7.HeaderText = "Fecha Entrega";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 203;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "CantidadEntregada";
            this.dataGridViewTextBoxColumn8.HeaderText = "Cant Entregada";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 202;
            // 
            // FVentaProductosAdministradorEntregas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 395);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStripEntregaProductos);
            this.Controls.Add(this.statusStripEntregaProductos);
            this.Name = "FVentaProductosAdministradorEntregas";
            this.Text = "Administrador de Entrega de Productos";
            this.Load += new System.EventHandler(this.FVentaProductosAdministradorEntregas_Load);
            this.statusStripEntregaProductos.ResumeLayout(false);
            this.statusStripEntregaProductos.PerformLayout();
            this.toolStripEntregaProductos.ResumeLayout(false);
            this.toolStripEntregaProductos.PerformLayout();
            this.gBEntregaProductosDatos.ResumeLayout(false);
            this.gBEntregaProductosDatos.PerformLayout();
            this.gbEntregaProductosDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosEntregados)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.pageDatosPrincipales.ResumeLayout(false);
            this.pageHistorialEntrega.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVHistorialProductosEntregados)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVHistorialProductosEntregadosPE)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsVentasProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripEntregaProductos;
        private System.Windows.Forms.ToolStrip toolStripEntregaProductos;
        private System.Windows.Forms.GroupBox gBEntregaProductosDatos;
        private System.Windows.Forms.GroupBox gbEntregaProductosDetalle;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private Utilitarios.BindableToolStripLabel lblNumeroVenta;
        //private System.Windows.Forms.ToolStripStatusLabel lblNumeroVenta;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblCodigoEstadoVenta;
        private System.Windows.Forms.TextBox txtBoxCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageDatosPrincipales;
        private System.Windows.Forms.TabPage pageHistorialEntrega;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox checkCredito;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        //private System.Windows.Forms.ToolStripStatusLabel lblFechaHoraVenta;
        private Utilitarios.BindableToolStripLabel lblFechaHoraVenta;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalEntregados;
        private System.Windows.Forms.Label lblEstadoEntrega;
        private System.Windows.Forms.TextBox txtBoxObservaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalPendientes;
        private System.Windows.Forms.DataGridView dtGVProductosEntregados;
        private System.Windows.Forms.DataGridView dtGVHistorialProductosEntregados;
        private OutlookStyleControls.OutlookGrid dtGVHistorialProductosEntregadosPE;
        private System.Windows.Forms.ToolStripButton btnConfirmarEntrega;
        private System.Windows.Forms.ToolStripButton btnCompletarEntrega;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnReporteGeneral;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingSource bdsVentasProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadEntregada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProductoH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreProductoH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCFechaHoraEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadEntregadaH;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnReporteHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnVerHistorialEspecificos;
    }
}