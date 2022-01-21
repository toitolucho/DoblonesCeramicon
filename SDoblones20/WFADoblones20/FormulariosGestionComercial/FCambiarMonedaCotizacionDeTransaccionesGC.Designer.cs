namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FCambiarMonedaCotizacionDeTransaccionesGC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCambiarMonedaCotizacionDeTransaccionesGC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gBoxDetalleConversion = new System.Windows.Forms.GroupBox();
            this.txtBoxIVA = new System.Windows.Forms.TextBox();
            this.lblIVA = new System.Windows.Forms.Label();
            this.checkUltimaCotizacionMoneda = new System.Windows.Forms.CheckBox();
            this.checkIncluirIva = new System.Windows.Forms.CheckBox();
            this.btnConvertir = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cBoxMonedas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMonedaSistema = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlDetalleTransaccion = new System.Windows.Forms.Panel();
            this.txtBoxImporteTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtGVTransaccion = new System.Windows.Forms.DataGridView();
            this.DGCCodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPrecioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flPnlBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnNuevaMoneda = new System.Windows.Forms.Button();
            this.btnNuevaCotizacion = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBoxDetalleConversion.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlDetalleTransaccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVTransaccion)).BeginInit();
            this.flPnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxDetalleConversion
            // 
            this.gBoxDetalleConversion.Controls.Add(this.txtBoxIVA);
            this.gBoxDetalleConversion.Controls.Add(this.lblIVA);
            this.gBoxDetalleConversion.Controls.Add(this.checkUltimaCotizacionMoneda);
            this.gBoxDetalleConversion.Controls.Add(this.checkIncluirIva);
            this.gBoxDetalleConversion.Controls.Add(this.btnConvertir);
            this.gBoxDetalleConversion.Controls.Add(this.dateTimePicker1);
            this.gBoxDetalleConversion.Controls.Add(this.label3);
            this.gBoxDetalleConversion.Controls.Add(this.cBoxMonedas);
            this.gBoxDetalleConversion.Controls.Add(this.label2);
            this.gBoxDetalleConversion.Controls.Add(this.txtMonedaSistema);
            this.gBoxDetalleConversion.Controls.Add(this.label1);
            this.gBoxDetalleConversion.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxDetalleConversion.Location = new System.Drawing.Point(0, 0);
            this.gBoxDetalleConversion.Name = "gBoxDetalleConversion";
            this.gBoxDetalleConversion.Size = new System.Drawing.Size(700, 64);
            this.gBoxDetalleConversion.TabIndex = 0;
            this.gBoxDetalleConversion.TabStop = false;
            this.gBoxDetalleConversion.Text = "Detalle de Conversión de Moneda";
            // 
            // txtBoxIVA
            // 
            this.txtBoxIVA.Enabled = false;
            this.txtBoxIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxIVA.Location = new System.Drawing.Point(289, 13);
            this.txtBoxIVA.Name = "txtBoxIVA";
            this.txtBoxIVA.Size = new System.Drawing.Size(63, 20);
            this.txtBoxIVA.TabIndex = 10;
            // 
            // lblIVA
            // 
            this.lblIVA.AutoSize = true;
            this.lblIVA.Location = new System.Drawing.Point(249, 16);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(30, 13);
            this.lblIVA.TabIndex = 9;
            this.lblIVA.Text = "IVA :";
            // 
            // checkUltimaCotizacionMoneda
            // 
            this.checkUltimaCotizacionMoneda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkUltimaCotizacionMoneda.AutoSize = true;
            this.checkUltimaCotizacionMoneda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkUltimaCotizacionMoneda.Location = new System.Drawing.Point(475, 16);
            this.checkUltimaCotizacionMoneda.Name = "checkUltimaCotizacionMoneda";
            this.checkUltimaCotizacionMoneda.Size = new System.Drawing.Size(202, 17);
            this.checkUltimaCotizacionMoneda.TabIndex = 8;
            this.checkUltimaCotizacionMoneda.Text = "Ultimo Cambio de Cotizacion Moneda";
            this.checkUltimaCotizacionMoneda.UseVisualStyleBackColor = true;
            // 
            // checkIncluirIva
            // 
            this.checkIncluirIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkIncluirIva.AutoSize = true;
            this.checkIncluirIva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkIncluirIva.Location = new System.Drawing.Point(388, 16);
            this.checkIncluirIva.Name = "checkIncluirIva";
            this.checkIncluirIva.Size = new System.Drawing.Size(74, 17);
            this.checkIncluirIva.TabIndex = 7;
            this.checkIncluirIva.Text = "Incluir IVA";
            this.checkIncluirIva.UseVisualStyleBackColor = true;
            // 
            // btnConvertir
            // 
            this.btnConvertir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConvertir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvertir.ImageKey = "Refresh.ico";
            this.btnConvertir.ImageList = this.imageList1;
            this.btnConvertir.Location = new System.Drawing.Point(619, 33);
            this.btnConvertir.Name = "btnConvertir";
            this.btnConvertir.Size = new System.Drawing.Size(75, 28);
            this.btnConvertir.TabIndex = 6;
            this.btnConvertir.Text = "&Convertir";
            this.btnConvertir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConvertir.UseVisualStyleBackColor = true;
            this.btnConvertir.Click += new System.EventHandler(this.btnConvertir_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Undo.ico");
            this.imageList1.Images.SetKeyName(1, "Config.ico");
            this.imageList1.Images.SetKeyName(2, "Config-Tools.ico");
            this.imageList1.Images.SetKeyName(3, "Refresh.ico");
            this.imageList1.Images.SetKeyName(4, "Symbol-Check.ico");
            this.imageList1.Images.SetKeyName(5, "bundle.ico");
            this.imageList1.Images.SetKeyName(6, "argent_8.ico");
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Location = new System.Drawing.Point(402, 37);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(211, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha de Moneda Cotización";
            // 
            // cBoxMonedas
            // 
            this.cBoxMonedas.FormattingEnabled = true;
            this.cBoxMonedas.Location = new System.Drawing.Point(122, 37);
            this.cBoxMonedas.Name = "cBoxMonedas";
            this.cBoxMonedas.Size = new System.Drawing.Size(121, 21);
            this.cBoxMonedas.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Monedas Disponibles";
            // 
            // txtMonedaSistema
            // 
            this.txtMonedaSistema.Enabled = false;
            this.txtMonedaSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonedaSistema.Location = new System.Drawing.Point(122, 13);
            this.txtMonedaSistema.Name = "txtMonedaSistema";
            this.txtMonedaSistema.Size = new System.Drawing.Size(100, 20);
            this.txtMonedaSistema.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Moneda del Sistema";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlDetalleTransaccion);
            this.groupBox2.Controls.Add(this.dtGVTransaccion);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(700, 257);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle de Transacción";
            // 
            // pnlDetalleTransaccion
            // 
            this.pnlDetalleTransaccion.Controls.Add(this.txtBoxImporteTotal);
            this.pnlDetalleTransaccion.Controls.Add(this.label4);
            this.pnlDetalleTransaccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetalleTransaccion.Location = new System.Drawing.Point(3, 220);
            this.pnlDetalleTransaccion.Name = "pnlDetalleTransaccion";
            this.pnlDetalleTransaccion.Size = new System.Drawing.Size(694, 34);
            this.pnlDetalleTransaccion.TabIndex = 1;
            // 
            // txtBoxImporteTotal
            // 
            this.txtBoxImporteTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxImporteTotal.Enabled = false;
            this.txtBoxImporteTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxImporteTotal.Location = new System.Drawing.Point(580, 7);
            this.txtBoxImporteTotal.Name = "txtBoxImporteTotal";
            this.txtBoxImporteTotal.Size = new System.Drawing.Size(105, 20);
            this.txtBoxImporteTotal.TabIndex = 1;
            this.txtBoxImporteTotal.Text = "0.00 Bs";
            this.txtBoxImporteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(484, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Importe Total :";
            // 
            // dtGVTransaccion
            // 
            this.dtGVTransaccion.AllowUserToAddRows = false;
            this.dtGVTransaccion.AllowUserToResizeRows = false;
            this.dtGVTransaccion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGVTransaccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVTransaccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtGVTransaccion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVTransaccion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVTransaccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVTransaccion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoProducto,
            this.DGCNombreProducto,
            this.DGCCantidad,
            this.DGCPrecioUnitario,
            this.DGCPrecioTotal});
            this.dtGVTransaccion.Location = new System.Drawing.Point(3, 16);
            this.dtGVTransaccion.Name = "dtGVTransaccion";
            this.dtGVTransaccion.RowHeadersVisible = false;
            this.dtGVTransaccion.Size = new System.Drawing.Size(694, 232);
            this.dtGVTransaccion.TabIndex = 0;
            // 
            // DGCCodigoProducto
            // 
            this.DGCCodigoProducto.FillWeight = 118.7995F;
            this.DGCCodigoProducto.HeaderText = "Código";
            this.DGCCodigoProducto.Name = "DGCCodigoProducto";
            this.DGCCodigoProducto.ReadOnly = true;
            // 
            // DGCNombreProducto
            // 
            this.DGCNombreProducto.FillWeight = 89.08872F;
            this.DGCNombreProducto.HeaderText = "Producto";
            this.DGCNombreProducto.Name = "DGCNombreProducto";
            this.DGCNombreProducto.ReadOnly = true;
            // 
            // DGCCantidad
            // 
            this.DGCCantidad.FillWeight = 95.56429F;
            this.DGCCantidad.HeaderText = "Cantidad";
            this.DGCCantidad.Name = "DGCCantidad";
            this.DGCCantidad.ReadOnly = true;
            // 
            // DGCPrecioUnitario
            // 
            this.DGCPrecioUnitario.FillWeight = 96.69221F;
            this.DGCPrecioUnitario.HeaderText = "Precio Unitario";
            this.DGCPrecioUnitario.Name = "DGCPrecioUnitario";
            this.DGCPrecioUnitario.ReadOnly = true;
            // 
            // DGCPrecioTotal
            // 
            this.DGCPrecioTotal.FillWeight = 99.85529F;
            this.DGCPrecioTotal.HeaderText = "Precio Total";
            this.DGCPrecioTotal.Name = "DGCPrecioTotal";
            this.DGCPrecioTotal.ReadOnly = true;
            // 
            // flPnlBotones
            // 
            this.flPnlBotones.Controls.Add(this.btnAceptar);
            this.flPnlBotones.Controls.Add(this.btnNuevaMoneda);
            this.flPnlBotones.Controls.Add(this.btnNuevaCotizacion);
            this.flPnlBotones.Controls.Add(this.button1);
            this.flPnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flPnlBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flPnlBotones.Location = new System.Drawing.Point(0, 321);
            this.flPnlBotones.Name = "flPnlBotones";
            this.flPnlBotones.Padding = new System.Windows.Forms.Padding(2);
            this.flPnlBotones.Size = new System.Drawing.Size(700, 39);
            this.flPnlBotones.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.ImageIndex = 4;
            this.btnAceptar.ImageList = this.imageList1;
            this.btnAceptar.Location = new System.Drawing.Point(618, 5);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 30);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnNuevaMoneda
            // 
            this.btnNuevaMoneda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaMoneda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaMoneda.ImageIndex = 5;
            this.btnNuevaMoneda.ImageList = this.imageList1;
            this.btnNuevaMoneda.Location = new System.Drawing.Point(504, 5);
            this.btnNuevaMoneda.Name = "btnNuevaMoneda";
            this.btnNuevaMoneda.Size = new System.Drawing.Size(108, 30);
            this.btnNuevaMoneda.TabIndex = 1;
            this.btnNuevaMoneda.Text = "Nueva &Moneda";
            this.btnNuevaMoneda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaMoneda.UseVisualStyleBackColor = true;
            this.btnNuevaMoneda.Click += new System.EventHandler(this.btnNuevaMoneda_Click);
            // 
            // btnNuevaCotizacion
            // 
            this.btnNuevaCotizacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaCotizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaCotizacion.ImageIndex = 1;
            this.btnNuevaCotizacion.ImageList = this.imageList1;
            this.btnNuevaCotizacion.Location = new System.Drawing.Point(324, 5);
            this.btnNuevaCotizacion.Name = "btnNuevaCotizacion";
            this.btnNuevaCotizacion.Size = new System.Drawing.Size(174, 30);
            this.btnNuevaCotizacion.TabIndex = 2;
            this.btnNuevaCotizacion.Text = "Nueva Cotizacion de Moneda";
            this.btnNuevaCotizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaCotizacion.UseVisualStyleBackColor = true;
            this.btnNuevaCotizacion.Click += new System.EventHandler(this.btnNuevaCotizacion_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(175, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "&Volver a Estado Inicial";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 280;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Precio Unitario";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Precio Total";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 110;
            // 
            // FCambiarMonedaCotizacionDeTransaccionesGC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 360);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.flPnlBotones);
            this.Controls.Add(this.gBoxDetalleConversion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FCambiarMonedaCotizacionDeTransaccionesGC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conversión de Transacciones a Diferentes Monedas";
            this.Load += new System.EventHandler(this.FCambiarMonedaCotizacionDeTransaccionesGC_Load_1);
            this.gBoxDetalleConversion.ResumeLayout(false);
            this.gBoxDetalleConversion.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.pnlDetalleTransaccion.ResumeLayout(false);
            this.pnlDetalleTransaccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVTransaccion)).EndInit();
            this.flPnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxDetalleConversion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flPnlBotones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMonedaSistema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.CheckBox checkUltimaCotizacionMoneda;
        private System.Windows.Forms.CheckBox checkIncluirIva;
        private System.Windows.Forms.Button btnConvertir;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBoxMonedas;
        private System.Windows.Forms.Button btnNuevaMoneda;
        private System.Windows.Forms.Panel pnlDetalleTransaccion;
        private System.Windows.Forms.DataGridView dtGVTransaccion;
        private System.Windows.Forms.Button btnNuevaCotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPrecioTotal;
        private System.Windows.Forms.TextBox txtBoxImporteTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxIVA;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
    }
}