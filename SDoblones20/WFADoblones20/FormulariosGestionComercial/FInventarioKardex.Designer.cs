namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FInventarioKardex
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FInventarioKardex));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtGVListadoProductos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rBtnGeneral = new System.Windows.Forms.RadioButton();
            this.rBtnDetallado = new System.Windows.Forms.RadioButton();
            this.checkAgencias = new System.Windows.Forms.CheckBox();
            this.checkProductos = new System.Windows.Forms.CheckBox();
            this.checkFechas = new System.Windows.Forms.CheckBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadIngresada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadEgresada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadExistenciaAnterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadExistenciaActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadRequerida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCStockMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPrecioUnitarioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoProductos)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtGVListadoProductos);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(953, 318);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de Productos";
            // 
            // dtGVListadoProductos
            // 
            this.dtGVListadoProductos.AllowUserToAddRows = false;
            this.dtGVListadoProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVListadoProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtGVListadoProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dtGVListadoProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVListadoProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVListadoProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVListadoProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoProducto,
            this.DGCNombreProducto,
            this.DGCCantidadIngresada,
            this.DGCCantidadEgresada,
            this.DGCCantidadExistenciaAnterior,
            this.DGCCantidadExistenciaActual,
            this.DGCCantidadRequerida,
            this.DGCStockMinimo,
            this.DGCPrecioUnitarioCompra});
            this.dtGVListadoProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVListadoProductos.Location = new System.Drawing.Point(3, 16);
            this.dtGVListadoProductos.Name = "dtGVListadoProductos";
            this.dtGVListadoProductos.RowHeadersVisible = false;
            this.dtGVListadoProductos.Size = new System.Drawing.Size(947, 299);
            this.dtGVListadoProductos.TabIndex = 0;
            this.dtGVListadoProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVListadoProductos_CellDoubleClick);
            this.dtGVListadoProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtGVListadoProductos_CellFormatting);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkFechas);
            this.panel1.Controls.Add(this.checkProductos);
            this.panel1.Controls.Add(this.checkAgencias);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnReporte);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.dateTimePickerFin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePickerInicio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 318);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 48);
            this.panel1.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(887, 8);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(57, 29);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Salir";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Symbol-Delete.ico");
            this.imageList1.Images.SetKeyName(1, "Symbol-Check.ico");
            this.imageList1.Images.SetKeyName(2, "printer.ico");
            // 
            // btnReporte
            // 
            this.btnReporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporte.ImageIndex = 2;
            this.btnReporte.ImageList = this.imageList1;
            this.btnReporte.Location = new System.Drawing.Point(806, 8);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(75, 29);
            this.btnReporte.TabIndex = 5;
            this.btnReporte.Text = "&Reporte";
            this.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.ImageList = this.imageList1;
            this.btnAceptar.Location = new System.Drawing.Point(212, 11);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 29);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFin.Location = new System.Drawing.Point(116, 19);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(90, 20);
            this.dateTimePickerFin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha &Fin ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha &Inicio";
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(13, 20);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(97, 20);
            this.dateTimePickerInicio.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rBtnDetallado);
            this.groupBox2.Controls.Add(this.rBtnGeneral);
            this.groupBox2.Location = new System.Drawing.Point(293, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 39);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones Reporte ";
            // 
            // rBtnGeneral
            // 
            this.rBtnGeneral.AutoSize = true;
            this.rBtnGeneral.Checked = true;
            this.rBtnGeneral.Location = new System.Drawing.Point(8, 14);
            this.rBtnGeneral.Name = "rBtnGeneral";
            this.rBtnGeneral.Size = new System.Drawing.Size(62, 17);
            this.rBtnGeneral.TabIndex = 0;
            this.rBtnGeneral.TabStop = true;
            this.rBtnGeneral.Text = "General";
            this.rBtnGeneral.UseVisualStyleBackColor = true;
            // 
            // rBtnDetallado
            // 
            this.rBtnDetallado.AutoSize = true;
            this.rBtnDetallado.Location = new System.Drawing.Point(69, 14);
            this.rBtnDetallado.Name = "rBtnDetallado";
            this.rBtnDetallado.Size = new System.Drawing.Size(70, 17);
            this.rBtnDetallado.TabIndex = 1;
            this.rBtnDetallado.Text = "Detallado";
            this.rBtnDetallado.UseVisualStyleBackColor = true;
            this.rBtnDetallado.CheckedChanged += new System.EventHandler(this.rBtnDetallado_CheckedChanged);
            // 
            // checkAgencias
            // 
            this.checkAgencias.AutoSize = true;
            this.checkAgencias.Checked = true;
            this.checkAgencias.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAgencias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkAgencias.Location = new System.Drawing.Point(443, 15);
            this.checkAgencias.Name = "checkAgencias";
            this.checkAgencias.Size = new System.Drawing.Size(119, 17);
            this.checkAgencias.TabIndex = 8;
            this.checkAgencias.Text = "Todas las Agencias";
            this.checkAgencias.UseVisualStyleBackColor = true;
            this.checkAgencias.Visible = false;
            // 
            // checkProductos
            // 
            this.checkProductos.AutoSize = true;
            this.checkProductos.Checked = true;
            this.checkProductos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkProductos.Location = new System.Drawing.Point(563, 15);
            this.checkProductos.Name = "checkProductos";
            this.checkProductos.Size = new System.Drawing.Size(88, 17);
            this.checkProductos.TabIndex = 9;
            this.checkProductos.Text = "Por Producto";
            this.checkProductos.UseVisualStyleBackColor = true;
            this.checkProductos.Visible = false;
            // 
            // checkFechas
            // 
            this.checkFechas.AutoSize = true;
            this.checkFechas.Checked = true;
            this.checkFechas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkFechas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkFechas.Location = new System.Drawing.Point(652, 15);
            this.checkFechas.Name = "checkFechas";
            this.checkFechas.Size = new System.Drawing.Size(106, 17);
            this.checkFechas.TabIndex = 10;
            this.checkFechas.Text = "En Rago Fechas";
            this.checkFechas.UseVisualStyleBackColor = true;
            this.checkFechas.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoProducto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 105;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreProducto";
            this.dataGridViewTextBoxColumn2.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CantidadIngresada";
            this.dataGridViewTextBoxColumn3.HeaderText = "Ingreso";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 105;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CantidadEgresada";
            this.dataGridViewTextBoxColumn4.HeaderText = "Egreso";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 105;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CantidadExistenciaAnterior";
            this.dataGridViewTextBoxColumn5.HeaderText = "Exist Anterior";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 105;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "CantidadExistenciaActual";
            this.dataGridViewTextBoxColumn6.HeaderText = "Exist Actual";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 105;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CantidadRequerida";
            this.dataGridViewTextBoxColumn7.HeaderText = "Requeridos";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 105;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "StockMinimo";
            this.dataGridViewTextBoxColumn8.HeaderText = "Stock Min";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 105;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "PrecioUnitarioCompra";
            this.dataGridViewTextBoxColumn9.HeaderText = "P. Compra";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 105;
            // 
            // DGCCodigoProducto
            // 
            this.DGCCodigoProducto.DataPropertyName = "CodigoProducto";
            this.DGCCodigoProducto.HeaderText = "Código";
            this.DGCCodigoProducto.Name = "DGCCodigoProducto";
            this.DGCCodigoProducto.ReadOnly = true;
            // 
            // DGCNombreProducto
            // 
            this.DGCNombreProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCNombreProducto.DataPropertyName = "NombreProducto";
            this.DGCNombreProducto.HeaderText = "Producto";
            this.DGCNombreProducto.Name = "DGCNombreProducto";
            this.DGCNombreProducto.ReadOnly = true;
            // 
            // DGCCantidadIngresada
            // 
            this.DGCCantidadIngresada.DataPropertyName = "CantidadIngresada";
            this.DGCCantidadIngresada.HeaderText = "Ingreso";
            this.DGCCantidadIngresada.Name = "DGCCantidadIngresada";
            this.DGCCantidadIngresada.ReadOnly = true;
            // 
            // DGCCantidadEgresada
            // 
            this.DGCCantidadEgresada.DataPropertyName = "CantidadEgresada";
            this.DGCCantidadEgresada.HeaderText = "Egreso";
            this.DGCCantidadEgresada.Name = "DGCCantidadEgresada";
            this.DGCCantidadEgresada.ReadOnly = true;
            // 
            // DGCCantidadExistenciaAnterior
            // 
            this.DGCCantidadExistenciaAnterior.DataPropertyName = "CantidadExistenciaAnterior";
            this.DGCCantidadExistenciaAnterior.HeaderText = "Exist Anterior";
            this.DGCCantidadExistenciaAnterior.Name = "DGCCantidadExistenciaAnterior";
            this.DGCCantidadExistenciaAnterior.ReadOnly = true;
            // 
            // DGCCantidadExistenciaActual
            // 
            this.DGCCantidadExistenciaActual.DataPropertyName = "CantidadExistenciaActual";
            this.DGCCantidadExistenciaActual.HeaderText = "Exist Actual";
            this.DGCCantidadExistenciaActual.Name = "DGCCantidadExistenciaActual";
            this.DGCCantidadExistenciaActual.ReadOnly = true;
            // 
            // DGCCantidadRequerida
            // 
            this.DGCCantidadRequerida.DataPropertyName = "CantidadRequerida";
            this.DGCCantidadRequerida.HeaderText = "Requeridos";
            this.DGCCantidadRequerida.Name = "DGCCantidadRequerida";
            this.DGCCantidadRequerida.ReadOnly = true;
            // 
            // DGCStockMinimo
            // 
            this.DGCStockMinimo.DataPropertyName = "StockMinimo";
            this.DGCStockMinimo.HeaderText = "Stock Min";
            this.DGCStockMinimo.Name = "DGCStockMinimo";
            this.DGCStockMinimo.ReadOnly = true;
            // 
            // DGCPrecioUnitarioCompra
            // 
            this.DGCPrecioUnitarioCompra.DataPropertyName = "PrecioUnitarioCompra";
            this.DGCPrecioUnitarioCompra.HeaderText = "P. Compra";
            this.DGCPrecioUnitarioCompra.Name = "DGCPrecioUnitarioCompra";
            this.DGCPrecioUnitarioCompra.ReadOnly = true;
            // 
            // FInventarioKardex
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(953, 366);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FInventarioKardex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kardex de Productos en Inventario";
            this.Load += new System.EventHandler(this.FInventarioKardex_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoProductos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtGVListadoProductos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadIngresada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadEgresada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadExistenciaAnterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadExistenciaActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadRequerida;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCStockMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPrecioUnitarioCompra;
        private System.Windows.Forms.CheckBox checkFechas;
        private System.Windows.Forms.CheckBox checkProductos;
        private System.Windows.Forms.CheckBox checkAgencias;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rBtnDetallado;
        private System.Windows.Forms.RadioButton rBtnGeneral;
    }
}