namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FVentaProductosEntrega
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnEntregaParcial = new System.Windows.Forms.Button();
            this.btnConfirmarEntregaTotal = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.checkEdición = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtGVProductos = new System.Windows.Forms.DataGridView();
            this.DGCEsProductoEspecifico = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGCVendidoComoAgregado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNumeroVenta = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFechaVenta = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadEntregada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadFaltante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPrecioUnitarioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadExistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtGVProductosEspecificos = new OutlookStyleControls.OutlookGrid();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductos)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosEspecificos)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCerrar);
            this.flowLayoutPanel1.Controls.Add(this.btnEntregaParcial);
            this.flowLayoutPanel1.Controls.Add(this.btnConfirmarEntregaTotal);
            this.flowLayoutPanel1.Controls.Add(this.btnReporte);
            this.flowLayoutPanel1.Controls.Add(this.btnConfirmar);
            this.flowLayoutPanel1.Controls.Add(this.checkEdición);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 330);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(849, 46);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(771, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnEntregaParcial
            // 
            this.btnEntregaParcial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntregaParcial.Location = new System.Drawing.Point(633, 3);
            this.btnEntregaParcial.Name = "btnEntregaParcial";
            this.btnEntregaParcial.Size = new System.Drawing.Size(132, 23);
            this.btnEntregaParcial.TabIndex = 1;
            this.btnEntregaParcial.Text = "Confirmación &Parcial";
            this.btnEntregaParcial.UseVisualStyleBackColor = true;
            this.btnEntregaParcial.Click += new System.EventHandler(this.btnEntregaParcial_Click);
            // 
            // btnConfirmarEntregaTotal
            // 
            this.btnConfirmarEntregaTotal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarEntregaTotal.Location = new System.Drawing.Point(462, 3);
            this.btnConfirmarEntregaTotal.Name = "btnConfirmarEntregaTotal";
            this.btnConfirmarEntregaTotal.Size = new System.Drawing.Size(165, 23);
            this.btnConfirmarEntregaTotal.TabIndex = 2;
            this.btnConfirmarEntregaTotal.Text = "Con&firmacion Total";
            this.btnConfirmarEntregaTotal.UseVisualStyleBackColor = true;
            this.btnConfirmarEntregaTotal.Click += new System.EventHandler(this.btnConfirmarEntrega_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte.Location = new System.Drawing.Point(326, 3);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(130, 23);
            this.btnReporte.TabIndex = 3;
            this.btnReporte.Text = "&Reporte de conformidad";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.Location = new System.Drawing.Point(210, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(110, 23);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Confirmar Entrega ";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmarInstitucional_Click);
            // 
            // checkEdición
            // 
            this.checkEdición.AutoSize = true;
            this.checkEdición.Location = new System.Drawing.Point(107, 3);
            this.checkEdición.Name = "checkEdición";
            this.checkEdición.Size = new System.Drawing.Size(97, 17);
            this.checkEdición.TabIndex = 4;
            this.checkEdición.Text = "Activar &Edición";
            this.checkEdición.UseVisualStyleBackColor = true;
            this.checkEdición.CheckedChanged += new System.EventHandler(this.checkEdición_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(849, 330);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtGVProductos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(841, 304);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lista de Productos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtGVProductos
            // 
            this.dtGVProductos.AllowUserToAddRows = false;
            this.dtGVProductos.AllowUserToDeleteRows = false;
            this.dtGVProductos.AllowUserToResizeRows = false;
            this.dtGVProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoProducto,
            this.DGCNombreProducto,
            this.DGCCantidadVenta,
            this.DGCCantidadEntregada,
            this.DGCCantidadFaltante,
            this.DGCPrecioUnitarioVenta,
            this.DGCCantidadExistencia,
            this.DGCEsProductoEspecifico,
            this.DGCVendidoComoAgregado});
            this.dtGVProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVProductos.Location = new System.Drawing.Point(3, 3);
            this.dtGVProductos.Name = "dtGVProductos";
            this.dtGVProductos.RowHeadersVisible = false;
            this.dtGVProductos.Size = new System.Drawing.Size(835, 298);
            this.dtGVProductos.TabIndex = 1;
            this.dtGVProductos.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dtGVProductos_RowValidating);
            this.dtGVProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtGVProductos_CellFormatting);
            this.dtGVProductos.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtGVProductos_CellValidating);
            this.dtGVProductos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtGVProductos_EditingControlShowing);
            // 
            // DGCEsProductoEspecifico
            // 
            this.DGCEsProductoEspecifico.DataPropertyName = "EsProductoEspecifico";
            this.DGCEsProductoEspecifico.HeaderText = "Especifico ?";
            this.DGCEsProductoEspecifico.Name = "DGCEsProductoEspecifico";
            this.DGCEsProductoEspecifico.ReadOnly = true;
            // 
            // DGCVendidoComoAgregado
            // 
            this.DGCVendidoComoAgregado.DataPropertyName = "VendidoComoAgregado";
            this.DGCVendidoComoAgregado.HeaderText = "Agregado";
            this.DGCVendidoComoAgregado.Name = "DGCVendidoComoAgregado";
            this.DGCVendidoComoAgregado.ReadOnly = true;
            this.DGCVendidoComoAgregado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCVendidoComoAgregado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtGVProductosEspecificos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(841, 304);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Productos Específicos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblNumeroVenta,
            this.toolStripStatusLabel2,
            this.lblFechaVenta,
            this.lblEstado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 376);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(849, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(82, 17);
            this.toolStripStatusLabel1.Text = "Nro de Venta :";
            // 
            // lblNumeroVenta
            // 
            this.lblNumeroVenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroVenta.Name = "lblNumeroVenta";
            this.lblNumeroVenta.Size = new System.Drawing.Size(14, 17);
            this.lblNumeroVenta.Text = "2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(130, 17);
            this.toolStripStatusLabel2.Text = "Fecha De culminación :";
            // 
            // lblFechaVenta
            // 
            this.lblFechaVenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaVenta.Name = "lblFechaVenta";
            this.lblFechaVenta.Size = new System.Drawing.Size(73, 17);
            this.lblFechaVenta.Text = "10-12-2009";
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(51, 17);
            this.lblEstado.Text = "Entrega";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoProducto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 104;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreProducto";
            this.dataGridViewTextBoxColumn2.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 104;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CantidadVenta";
            this.dataGridViewTextBoxColumn3.HeaderText = "Vendidos";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 104;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CantidadEntregada";
            this.dataGridViewTextBoxColumn4.HeaderText = "Entregados";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 105;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CantidadFaltante";
            this.dataGridViewTextBoxColumn5.HeaderText = "Faltantes";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 104;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PrecioUnitarioVenta";
            this.dataGridViewTextBoxColumn6.HeaderText = "P. U. Venta";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 104;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CantidadExistencia";
            this.dataGridViewTextBoxColumn7.HeaderText = "Exitencia";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 104;
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
            this.DGCNombreProducto.DataPropertyName = "NombreProducto";
            this.DGCNombreProducto.HeaderText = "Producto";
            this.DGCNombreProducto.Name = "DGCNombreProducto";
            this.DGCNombreProducto.ReadOnly = true;
            // 
            // DGCCantidadVenta
            // 
            this.DGCCantidadVenta.DataPropertyName = "CantidadVenta";
            this.DGCCantidadVenta.HeaderText = "Vendidos";
            this.DGCCantidadVenta.Name = "DGCCantidadVenta";
            this.DGCCantidadVenta.ReadOnly = true;
            // 
            // DGCCantidadEntregada
            // 
            this.DGCCantidadEntregada.DataPropertyName = "CantidadEntregada";
            this.DGCCantidadEntregada.HeaderText = "Entregados";
            this.DGCCantidadEntregada.Name = "DGCCantidadEntregada";
            this.DGCCantidadEntregada.ReadOnly = true;
            // 
            // DGCCantidadFaltante
            // 
            this.DGCCantidadFaltante.DataPropertyName = "CantidadFaltante";
            this.DGCCantidadFaltante.HeaderText = "Faltantes";
            this.DGCCantidadFaltante.Name = "DGCCantidadFaltante";
            this.DGCCantidadFaltante.ReadOnly = true;
            // 
            // DGCPrecioUnitarioVenta
            // 
            this.DGCPrecioUnitarioVenta.DataPropertyName = "PrecioUnitarioVenta";
            this.DGCPrecioUnitarioVenta.HeaderText = "P. U. Venta";
            this.DGCPrecioUnitarioVenta.Name = "DGCPrecioUnitarioVenta";
            this.DGCPrecioUnitarioVenta.ReadOnly = true;
            // 
            // DGCCantidadExistencia
            // 
            this.DGCCantidadExistencia.DataPropertyName = "CantidadExistencia";
            this.DGCCantidadExistencia.HeaderText = "Exitencia";
            this.DGCCantidadExistencia.Name = "DGCCantidadExistencia";
            this.DGCCantidadExistencia.ReadOnly = true;
            // 
            // dtGVProductosEspecificos
            // 
            this.dtGVProductosEspecificos.CollapseIcon = null;
            this.dtGVProductosEspecificos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVProductosEspecificos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVProductosEspecificos.ExpandIcon = null;
            this.dtGVProductosEspecificos.Location = new System.Drawing.Point(3, 3);
            this.dtGVProductosEspecificos.Name = "dtGVProductosEspecificos";
            this.dtGVProductosEspecificos.Size = new System.Drawing.Size(835, 298);
            this.dtGVProductosEspecificos.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "VendidoComoAgregado";
            this.dataGridViewTextBoxColumn8.HeaderText = "Agregado";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 93;
            // 
            // FVentaProductosEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(849, 398);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FVentaProductosEntrega";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venta de Productos en Espera de Entrega";
            this.Load += new System.EventHandler(this.FVentaProductosEntrega_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductos)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosEspecificos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblNumeroVenta;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblFechaVenta;
        private System.Windows.Forms.ToolStripStatusLabel lblEstado;
        private System.Windows.Forms.DataGridView dtGVProductos;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnEntregaParcial;
        private System.Windows.Forms.Button btnConfirmarEntregaTotal;
        private System.Windows.Forms.Button btnReporte;
        private OutlookStyleControls.OutlookGrid dtGVProductosEspecificos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.CheckBox checkEdición;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadEntregada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadFaltante;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPrecioUnitarioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadExistencia;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCEsProductoEspecifico;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCVendidoComoAgregado;
        private System.Windows.Forms.Button btnConfirmar;
    }
}