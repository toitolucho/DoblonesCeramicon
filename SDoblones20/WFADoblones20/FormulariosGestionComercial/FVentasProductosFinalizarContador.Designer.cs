namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FVentasProductosFinalizarContador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FVentasProductosFinalizarContador));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNroVenta = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cantidadVendidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.precioUnitarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.códigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtGVFinalizarVenta = new System.Windows.Forms.DataGridView();
            this.DGCNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPrecioUnitarioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPrecioTotalVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPrecioOtraMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBoxMontoTotalVenta = new System.Windows.Forms.TextBox();
            this.lblMontoTotalVenta = new System.Windows.Forms.Label();
            this.txtBoxMontoCredito = new System.Windows.Forms.TextBox();
            this.lblMontoCredito = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxNITCliente = new System.Windows.Forms.TextBox();
            this.txtBoxCliente = new System.Windows.Forms.TextBox();
            this.txtBoxNroFactura = new System.Windows.Forms.TextBox();
            this.checkBFactura = new System.Windows.Forms.CheckBox();
            this.checkBRecibo = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gBoxMonedaPago = new System.Windows.Forms.GroupBox();
            this.rBtnMonedaCotizacion = new System.Windows.Forms.RadioButton();
            this.rBtnMonedaSistema = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxCambio = new System.Windows.Forms.TextBox();
            this.txtMontoCancelado = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtBoxMontoTotal = new System.Windows.Forms.TextBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVFinalizarVenta)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gBoxMonedaPago.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblNroVenta,
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 348);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(786, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(106, 17);
            this.toolStripStatusLabel1.Text = "Numero de Venta :";
            // 
            // lblNroVenta
            // 
            this.lblNroVenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroVenta.Name = "lblNroVenta";
            this.lblNroVenta.Size = new System.Drawing.Size(21, 17);
            this.lblNroVenta.Text = "00";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cantidadVendidaToolStripMenuItem,
            this.precioUnitarioToolStripMenuItem,
            this.códigoToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(116, 20);
            this.toolStripDropDownButton1.Text = "Ocultar Columnas";
            // 
            // cantidadVendidaToolStripMenuItem
            // 
            this.cantidadVendidaToolStripMenuItem.CheckOnClick = true;
            this.cantidadVendidaToolStripMenuItem.Name = "cantidadVendidaToolStripMenuItem";
            this.cantidadVendidaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.cantidadVendidaToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.cantidadVendidaToolStripMenuItem.Text = "Cantidad Vendida";
            this.cantidadVendidaToolStripMenuItem.Click += new System.EventHandler(this.cantidadVendidaToolStripMenuItem_Click);
            // 
            // precioUnitarioToolStripMenuItem
            // 
            this.precioUnitarioToolStripMenuItem.CheckOnClick = true;
            this.precioUnitarioToolStripMenuItem.Name = "precioUnitarioToolStripMenuItem";
            this.precioUnitarioToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.precioUnitarioToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.precioUnitarioToolStripMenuItem.Text = "Precio Unitario";
            this.precioUnitarioToolStripMenuItem.Click += new System.EventHandler(this.precioUnitarioToolStripMenuItem_Click);
            // 
            // códigoToolStripMenuItem
            // 
            this.códigoToolStripMenuItem.Checked = true;
            this.códigoToolStripMenuItem.CheckOnClick = true;
            this.códigoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.códigoToolStripMenuItem.Name = "códigoToolStripMenuItem";
            this.códigoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.códigoToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.códigoToolStripMenuItem.Text = "Código";
            this.códigoToolStripMenuItem.ToolTipText = "Ocultar la Visualización del Código del Producto";
            this.códigoToolStripMenuItem.Click += new System.EventHandler(this.códigoToolStripMenuItem_Click);
            // 
            // dtGVFinalizarVenta
            // 
            this.dtGVFinalizarVenta.AllowUserToAddRows = false;
            this.dtGVFinalizarVenta.AllowUserToResizeRows = false;
            this.dtGVFinalizarVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVFinalizarVenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVFinalizarVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVFinalizarVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVFinalizarVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCNombreProducto,
            this.DGCCodigoProducto,
            this.DGCCantidadVenta,
            this.DGCPrecioUnitarioVenta,
            this.DGCPrecioTotalVenta,
            this.DGCPrecioOtraMoneda});
            this.dtGVFinalizarVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVFinalizarVenta.Location = new System.Drawing.Point(7, 20);
            this.dtGVFinalizarVenta.Name = "dtGVFinalizarVenta";
            this.dtGVFinalizarVenta.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dtGVFinalizarVenta.RowHeadersVisible = false;
            this.dtGVFinalizarVenta.Size = new System.Drawing.Size(772, 138);
            this.dtGVFinalizarVenta.TabIndex = 0;
            // 
            // DGCNombreProducto
            // 
            this.DGCNombreProducto.DataPropertyName = "NombreProducto";
            this.DGCNombreProducto.HeaderText = "Producto";
            this.DGCNombreProducto.Name = "DGCNombreProducto";
            // 
            // DGCCodigoProducto
            // 
            this.DGCCodigoProducto.DataPropertyName = "CodigoProducto";
            this.DGCCodigoProducto.HeaderText = "Código";
            this.DGCCodigoProducto.Name = "DGCCodigoProducto";
            this.DGCCodigoProducto.ReadOnly = true;
            // 
            // DGCCantidadVenta
            // 
            this.DGCCantidadVenta.DataPropertyName = "CantidadVenta";
            this.DGCCantidadVenta.HeaderText = "Cant. Vendida";
            this.DGCCantidadVenta.Name = "DGCCantidadVenta";
            this.DGCCantidadVenta.ReadOnly = true;
            // 
            // DGCPrecioUnitarioVenta
            // 
            this.DGCPrecioUnitarioVenta.DataPropertyName = "PrecioUnitarioVenta";
            this.DGCPrecioUnitarioVenta.HeaderText = "P. Unitario";
            this.DGCPrecioUnitarioVenta.Name = "DGCPrecioUnitarioVenta";
            this.DGCPrecioUnitarioVenta.ReadOnly = true;
            // 
            // DGCPrecioTotalVenta
            // 
            this.DGCPrecioTotalVenta.DataPropertyName = "PrecioTotalVenta";
            this.DGCPrecioTotalVenta.HeaderText = "Precio Total";
            this.DGCPrecioTotalVenta.Name = "DGCPrecioTotalVenta";
            this.DGCPrecioTotalVenta.ReadOnly = true;
            // 
            // DGCPrecioOtraMoneda
            // 
            this.DGCPrecioOtraMoneda.DataPropertyName = "PrecioTotalMonedaCotizacion";
            this.DGCPrecioOtraMoneda.HeaderText = "P. T. en Moneda";
            this.DGCPrecioOtraMoneda.Name = "DGCPrecioOtraMoneda";
            this.DGCPrecioOtraMoneda.ReadOnly = true;
            this.DGCPrecioOtraMoneda.ToolTipText = "Precio Total de Pago en la Moneda de Cotización de Venta";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 168);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(786, 180);
            this.panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBoxMontoTotalVenta);
            this.groupBox2.Controls.Add(this.lblMontoTotalVenta);
            this.groupBox2.Controls.Add(this.txtBoxMontoCredito);
            this.groupBox2.Controls.Add(this.lblMontoCredito);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtBoxNITCliente);
            this.groupBox2.Controls.Add(this.txtBoxCliente);
            this.groupBox2.Controls.Add(this.txtBoxNroFactura);
            this.groupBox2.Controls.Add(this.checkBFactura);
            this.groupBox2.Controls.Add(this.checkBRecibo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 170);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Cliente :";
            // 
            // txtBoxMontoTotalVenta
            // 
            this.txtBoxMontoTotalVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxMontoTotalVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxMontoTotalVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMontoTotalVenta.ForeColor = System.Drawing.Color.Blue;
            this.txtBoxMontoTotalVenta.Location = new System.Drawing.Point(135, 119);
            this.txtBoxMontoTotalVenta.Name = "txtBoxMontoTotalVenta";
            this.txtBoxMontoTotalVenta.ReadOnly = true;
            this.txtBoxMontoTotalVenta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxMontoTotalVenta.Size = new System.Drawing.Size(131, 20);
            this.txtBoxMontoTotalVenta.TabIndex = 25;
            this.txtBoxMontoTotalVenta.Text = "0.00";
            this.txtBoxMontoTotalVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBoxMontoTotalVenta.Visible = false;
            // 
            // lblMontoTotalVenta
            // 
            this.lblMontoTotalVenta.AutoSize = true;
            this.lblMontoTotalVenta.Location = new System.Drawing.Point(6, 121);
            this.lblMontoTotalVenta.Name = "lblMontoTotalVenta";
            this.lblMontoTotalVenta.Size = new System.Drawing.Size(95, 13);
            this.lblMontoTotalVenta.TabIndex = 24;
            this.lblMontoTotalVenta.Text = "Monto Total Venta";
            this.lblMontoTotalVenta.Visible = false;
            // 
            // txtBoxMontoCredito
            // 
            this.txtBoxMontoCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxMontoCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxMontoCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMontoCredito.ForeColor = System.Drawing.Color.Blue;
            this.txtBoxMontoCredito.Location = new System.Drawing.Point(135, 145);
            this.txtBoxMontoCredito.Name = "txtBoxMontoCredito";
            this.txtBoxMontoCredito.ReadOnly = true;
            this.txtBoxMontoCredito.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxMontoCredito.Size = new System.Drawing.Size(131, 20);
            this.txtBoxMontoCredito.TabIndex = 23;
            this.txtBoxMontoCredito.Text = "0.00";
            this.txtBoxMontoCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBoxMontoCredito.Visible = false;
            // 
            // lblMontoCredito
            // 
            this.lblMontoCredito.AutoSize = true;
            this.lblMontoCredito.Location = new System.Drawing.Point(7, 147);
            this.lblMontoCredito.Name = "lblMontoCredito";
            this.lblMontoCredito.Size = new System.Drawing.Size(125, 13);
            this.lblMontoCredito.TabIndex = 22;
            this.lblMontoCredito.Text = "Monto Crédito Disponible";
            this.lblMontoCredito.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Cliente ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "NIT Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Nro Factura ";
            // 
            // txtBoxNITCliente
            // 
            this.txtBoxNITCliente.BackColor = System.Drawing.Color.White;
            this.txtBoxNITCliente.Location = new System.Drawing.Point(74, 41);
            this.txtBoxNITCliente.Name = "txtBoxNITCliente";
            this.txtBoxNITCliente.ReadOnly = true;
            this.txtBoxNITCliente.Size = new System.Drawing.Size(215, 20);
            this.txtBoxNITCliente.TabIndex = 1;
            // 
            // txtBoxCliente
            // 
            this.txtBoxCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxCliente.BackColor = System.Drawing.Color.White;
            this.txtBoxCliente.Location = new System.Drawing.Point(74, 67);
            this.txtBoxCliente.Name = "txtBoxCliente";
            this.txtBoxCliente.ReadOnly = true;
            this.txtBoxCliente.Size = new System.Drawing.Size(415, 20);
            this.txtBoxCliente.TabIndex = 2;
            // 
            // txtBoxNroFactura
            // 
            this.txtBoxNroFactura.BackColor = System.Drawing.Color.White;
            this.txtBoxNroFactura.Location = new System.Drawing.Point(74, 15);
            this.txtBoxNroFactura.Name = "txtBoxNroFactura";
            this.txtBoxNroFactura.ReadOnly = true;
            this.txtBoxNroFactura.Size = new System.Drawing.Size(215, 20);
            this.txtBoxNroFactura.TabIndex = 0;
            // 
            // checkBFactura
            // 
            this.checkBFactura.AutoSize = true;
            this.checkBFactura.Location = new System.Drawing.Point(359, 143);
            this.checkBFactura.Name = "checkBFactura";
            this.checkBFactura.Size = new System.Drawing.Size(62, 17);
            this.checkBFactura.TabIndex = 3;
            this.checkBFactura.Text = "&Factura";
            this.checkBFactura.UseVisualStyleBackColor = true;
            // 
            // checkBRecibo
            // 
            this.checkBRecibo.AutoSize = true;
            this.checkBRecibo.Checked = true;
            this.checkBRecibo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBRecibo.Location = new System.Drawing.Point(427, 143);
            this.checkBRecibo.Name = "checkBRecibo";
            this.checkBRecibo.Size = new System.Drawing.Size(60, 17);
            this.checkBRecibo.TabIndex = 4;
            this.checkBRecibo.Text = "&Recibo";
            this.checkBRecibo.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gBoxMonedaPago);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtBoxCambio);
            this.groupBox3.Controls.Add(this.txtMontoCancelado);
            this.groupBox3.Controls.Add(this.btnCancelar);
            this.groupBox3.Controls.Add(this.txtBoxMontoTotal);
            this.groupBox3.Controls.Add(this.btnFinalizar);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(500, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(281, 170);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Monto de Cancelación";
            // 
            // gBoxMonedaPago
            // 
            this.gBoxMonedaPago.Controls.Add(this.rBtnMonedaCotizacion);
            this.gBoxMonedaPago.Controls.Add(this.rBtnMonedaSistema);
            this.gBoxMonedaPago.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxMonedaPago.Location = new System.Drawing.Point(3, 16);
            this.gBoxMonedaPago.Name = "gBoxMonedaPago";
            this.gBoxMonedaPago.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.gBoxMonedaPago.Size = new System.Drawing.Size(275, 35);
            this.gBoxMonedaPago.TabIndex = 22;
            this.gBoxMonedaPago.TabStop = false;
            this.gBoxMonedaPago.Text = "Pagar en :";
            // 
            // rBtnMonedaCotizacion
            // 
            this.rBtnMonedaCotizacion.AutoSize = true;
            this.rBtnMonedaCotizacion.Dock = System.Windows.Forms.DockStyle.Right;
            this.rBtnMonedaCotizacion.Location = new System.Drawing.Point(182, 16);
            this.rBtnMonedaCotizacion.Name = "rBtnMonedaCotizacion";
            this.rBtnMonedaCotizacion.Size = new System.Drawing.Size(85, 16);
            this.rBtnMonedaCotizacion.TabIndex = 1;
            this.rBtnMonedaCotizacion.Text = "radioButton2";
            this.rBtnMonedaCotizacion.UseVisualStyleBackColor = true;
            this.rBtnMonedaCotizacion.CheckedChanged += new System.EventHandler(this.rBtnMonedaCotizacion_CheckedChanged);
            // 
            // rBtnMonedaSistema
            // 
            this.rBtnMonedaSistema.AutoSize = true;
            this.rBtnMonedaSistema.Checked = true;
            this.rBtnMonedaSistema.Dock = System.Windows.Forms.DockStyle.Left;
            this.rBtnMonedaSistema.Location = new System.Drawing.Point(8, 16);
            this.rBtnMonedaSistema.Name = "rBtnMonedaSistema";
            this.rBtnMonedaSistema.Size = new System.Drawing.Size(85, 16);
            this.rBtnMonedaSistema.TabIndex = 0;
            this.rBtnMonedaSistema.TabStop = true;
            this.rBtnMonedaSistema.Text = "radioButton1";
            this.rBtnMonedaSistema.UseVisualStyleBackColor = true;
            this.rBtnMonedaSistema.CheckedChanged += new System.EventHandler(this.rBtnMonedaSistema_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Monto Devolución";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Monto Pago";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Monto Total :";
            // 
            // txtBoxCambio
            // 
            this.txtBoxCambio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxCambio.BackColor = System.Drawing.Color.Black;
            this.txtBoxCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxCambio.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtBoxCambio.Location = new System.Drawing.Point(119, 107);
            this.txtBoxCambio.Name = "txtBoxCambio";
            this.txtBoxCambio.ReadOnly = true;
            this.txtBoxCambio.Size = new System.Drawing.Size(152, 20);
            this.txtBoxCambio.TabIndex = 2;
            this.txtBoxCambio.Text = "0.00";
            this.txtBoxCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMontoCancelado
            // 
            this.txtMontoCancelado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMontoCancelado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoCancelado.Location = new System.Drawing.Point(119, 81);
            this.txtMontoCancelado.Name = "txtMontoCancelado";
            this.txtMontoCancelado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMontoCancelado.Size = new System.Drawing.Size(152, 20);
            this.txtMontoCancelado.TabIndex = 1;
            this.txtMontoCancelado.Text = "0.00";
            this.txtMontoCancelado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoCancelado.TextChanged += new System.EventHandler(this.txtMontoCancelado_TextChanged);
            this.txtMontoCancelado.Enter += new System.EventHandler(this.txtMontoCancelado_Enter);
            this.txtMontoCancelado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMontoCancelado_KeyDown);
            this.txtMontoCancelado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoCancelado_KeyPress);
            this.txtMontoCancelado.MouseEnter += new System.EventHandler(this.txtMontoCancelado_MouseEnter);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Image = global::WFADoblones20.Properties.Resources.SimboloCerrar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(105, 132);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtBoxMontoTotal
            // 
            this.txtBoxMontoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxMontoTotal.BackColor = System.Drawing.Color.Black;
            this.txtBoxMontoTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxMontoTotal.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtBoxMontoTotal.Location = new System.Drawing.Point(119, 55);
            this.txtBoxMontoTotal.Name = "txtBoxMontoTotal";
            this.txtBoxMontoTotal.ReadOnly = true;
            this.txtBoxMontoTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxMontoTotal.Size = new System.Drawing.Size(152, 20);
            this.txtBoxMontoTotal.TabIndex = 0;
            this.txtBoxMontoTotal.Text = "0.00";
            this.txtBoxMontoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizar.Image = global::WFADoblones20.Properties.Resources.Pagar;
            this.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinalizar.Location = new System.Drawing.Point(185, 132);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(89, 30);
            this.btnFinalizar.TabIndex = 3;
            this.btnFinalizar.Text = "&Finalizar";
            this.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtGVFinalizarVenta);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(7);
            this.groupBox1.Size = new System.Drawing.Size(786, 165);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de Productos Vendidos";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 165);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(786, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NombreProducto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 131;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CodigoProducto";
            this.dataGridViewTextBoxColumn2.HeaderText = "Código";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 132;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CantidadVenta";
            this.dataGridViewTextBoxColumn3.HeaderText = "Cant. Vendida";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 131;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PrecioUnitarioVenta";
            this.dataGridViewTextBoxColumn4.HeaderText = "P. Unitario";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 132;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PrecioTotalVenta";
            this.dataGridViewTextBoxColumn5.HeaderText = "Precio Total";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 131;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PrecioTotalMonedaCotizacion";
            this.dataGridViewTextBoxColumn6.HeaderText = "P. T. en Moneda";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.ToolTipText = "Precio Total de Pago en la Moneda de Cotización de Venta";
            this.dataGridViewTextBoxColumn6.Width = 128;
            // 
            // FVentasProductosFinalizarContador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 370);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FVentasProductosFinalizarContador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago y Finalización de Venta";
            this.Load += new System.EventHandler(this.FVentasProductosFinalizarContador_Load);
            this.Shown += new System.EventHandler(this.FVentasProductosFinalizarContador_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVFinalizarVenta)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gBoxMonedaPago.ResumeLayout(false);
            this.gBoxMonedaPago.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dtGVFinalizarVenta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblNroVenta;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxNITCliente;
        private System.Windows.Forms.TextBox txtBoxCliente;
        private System.Windows.Forms.TextBox txtBoxNroFactura;
        private System.Windows.Forms.CheckBox checkBFactura;
        private System.Windows.Forms.CheckBox checkBRecibo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxCambio;
        private System.Windows.Forms.TextBox txtMontoCancelado;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtBoxMontoTotal;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem cantidadVendidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem precioUnitarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem códigoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPrecioUnitarioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPrecioTotalVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPrecioOtraMoneda;
        private System.Windows.Forms.GroupBox gBoxMonedaPago;
        private System.Windows.Forms.RadioButton rBtnMonedaCotizacion;
        private System.Windows.Forms.RadioButton rBtnMonedaSistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.TextBox txtBoxMontoCredito;
        private System.Windows.Forms.Label lblMontoCredito;
        private System.Windows.Forms.TextBox txtBoxMontoTotalVenta;
        private System.Windows.Forms.Label lblMontoTotalVenta;
    }
}