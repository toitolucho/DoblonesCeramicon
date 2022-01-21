namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FTransferenciasProductosListadoCalculoGastos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTransferenciasProductosListadoCalculoGastos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtGVGastos = new System.Windows.Forms.DataGridView();
            this.DGCNombreGasto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCMontoPagoGasto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.checkUtilizarGastosActuales = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMontoTotalGastos = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.dtGVProductos = new System.Windows.Forms.DataGridView();
            this.DGCNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPrecioUnitarioTransferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCTipoCalculoInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCActualizarPrecioVenta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGCPromedio = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGCUltimaRecepcion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGCMontoGastoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBoxProductos = new System.Windows.Forms.GroupBox();
            this.pnlDetallePreciosGastos = new System.Windows.Forms.Panel();
            this.txtBoxMontoRestantePersonalizado = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVGastos)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductos)).BeginInit();
            this.gBoxProductos.SuspendLayout();
            this.pnlDetallePreciosGastos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGVGastos
            // 
            this.dtGVGastos.AllowUserToAddRows = false;
            this.dtGVGastos.AllowUserToResizeRows = false;
            this.dtGVGastos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVGastos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtGVGastos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVGastos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVGastos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCNombreGasto,
            this.DGCMontoPagoGasto});
            this.dtGVGastos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVGastos.Location = new System.Drawing.Point(5, 18);
            this.dtGVGastos.Name = "dtGVGastos";
            this.dtGVGastos.RowHeadersVisible = false;
            this.dtGVGastos.Size = new System.Drawing.Size(895, 206);
            this.dtGVGastos.TabIndex = 0;
            // 
            // DGCNombreGasto
            // 
            this.DGCNombreGasto.DataPropertyName = "NombreGasto";
            this.DGCNombreGasto.HeaderText = "Gastos";
            this.DGCNombreGasto.Name = "DGCNombreGasto";
            this.DGCNombreGasto.ReadOnly = true;
            this.DGCNombreGasto.ToolTipText = "Gastos Realizados para la Recepción de esta Compra";
            // 
            // DGCMontoPagoGasto
            // 
            this.DGCMontoPagoGasto.DataPropertyName = "MontoPagoGasto";
            this.DGCMontoPagoGasto.HeaderText = "Monto Gasto";
            this.DGCMontoPagoGasto.Name = "DGCMontoPagoGasto";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(678, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Monto Total Gasto";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel1.Controls.Add(this.btnAceptar);
            this.flowLayoutPanel1.Controls.Add(this.checkUtilizarGastosActuales);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 564);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(905, 39);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(827, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(746, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // checkUtilizarGastosActuales
            // 
            this.checkUtilizarGastosActuales.AutoSize = true;
            this.checkUtilizarGastosActuales.Checked = true;
            this.checkUtilizarGastosActuales.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkUtilizarGastosActuales.Location = new System.Drawing.Point(443, 3);
            this.checkUtilizarGastosActuales.Name = "checkUtilizarGastosActuales";
            this.checkUtilizarGastosActuales.Size = new System.Drawing.Size(297, 17);
            this.checkUtilizarGastosActuales.TabIndex = 2;
            this.checkUtilizarGastosActuales.Text = "Calcular Precio para Inventario con los Gastos Actuales ?";
            this.checkUtilizarGastosActuales.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(690, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Monto Restante";
            // 
            // txtMontoTotalGastos
            // 
            this.txtMontoTotalGastos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMontoTotalGastos.Location = new System.Drawing.Point(779, 28);
            this.txtMontoTotalGastos.Name = "txtMontoTotalGastos";
            this.txtMontoTotalGastos.Size = new System.Drawing.Size(109, 20);
            this.txtMontoTotalGastos.TabIndex = 1;
            this.txtMontoTotalGastos.Text = "0.00";
            this.txtMontoTotalGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGVGastos);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 335);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(905, 229);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Gastos Realizados en esta Recepción";
            // 
            // lblMensaje
            // 
            this.lblMensaje.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMensaje.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(0, 0);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(905, 50);
            this.lblMensaje.TabIndex = 4;
            this.lblMensaje.Text = resources.GetString("lblMensaje.Text");
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtGVProductos
            // 
            this.dtGVProductos.AllowUserToAddRows = false;
            this.dtGVProductos.AllowUserToResizeRows = false;
            this.dtGVProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtGVProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCNombreProducto,
            this.DGCPrecioUnitarioTransferencia,
            this.DGCTipoCalculoInventario,
            this.DGCActualizarPrecioVenta,
            this.DGCPromedio,
            this.DGCUltimaRecepcion,
            this.DGCMontoGastoProducto});
            this.dtGVProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVProductos.Location = new System.Drawing.Point(5, 18);
            this.dtGVProductos.MultiSelect = false;
            this.dtGVProductos.Name = "dtGVProductos";
            this.dtGVProductos.Size = new System.Drawing.Size(895, 211);
            this.dtGVProductos.TabIndex = 2;
            this.dtGVProductos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVProductos_CellValueChanged);
            // 
            // DGCNombreProducto
            // 
            this.DGCNombreProducto.DataPropertyName = "NombreProducto";
            this.DGCNombreProducto.HeaderText = "Producto";
            this.DGCNombreProducto.Name = "DGCNombreProducto";
            this.DGCNombreProducto.ReadOnly = true;
            this.DGCNombreProducto.ToolTipText = "Nombre o Descripción del Producto";
            // 
            // DGCPrecioUnitarioTransferencia
            // 
            this.DGCPrecioUnitarioTransferencia.DataPropertyName = "PrecioUnitarioTransferencia";
            this.DGCPrecioUnitarioTransferencia.HeaderText = "P.U. Compra";
            this.DGCPrecioUnitarioTransferencia.Name = "DGCPrecioUnitarioTransferencia";
            this.DGCPrecioUnitarioTransferencia.ReadOnly = true;
            this.DGCPrecioUnitarioTransferencia.ToolTipText = "Precio Unitario de Compra";
            // 
            // DGCTipoCalculoInventario
            // 
            this.DGCTipoCalculoInventario.DataPropertyName = "TipoCalculoInventario";
            this.DGCTipoCalculoInventario.HeaderText = "Calculo en Inventarios";
            this.DGCTipoCalculoInventario.Name = "DGCTipoCalculoInventario";
            this.DGCTipoCalculoInventario.ReadOnly = true;
            this.DGCTipoCalculoInventario.ToolTipText = "Tipo de Calculo de Actualizaicón para los Precios en Inventario";
            // 
            // DGCActualizarPrecioVenta
            // 
            this.DGCActualizarPrecioVenta.DataPropertyName = "ActualizarPrecioVenta";
            this.DGCActualizarPrecioVenta.HeaderText = "Actualizar Precios?";
            this.DGCActualizarPrecioVenta.Name = "DGCActualizarPrecioVenta";
            this.DGCActualizarPrecioVenta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCActualizarPrecioVenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGCActualizarPrecioVenta.ToolTipText = "Seleccione esta  opción si Desea Actualizar los Precios en Inventario";
            // 
            // DGCPromedio
            // 
            this.DGCPromedio.DataPropertyName = "Promedio";
            this.DGCPromedio.HeaderText = "Promediar?";
            this.DGCPromedio.Name = "DGCPromedio";
            this.DGCPromedio.ToolTipText = "Desea Promediar con las anteriores Recepciones para esta Compra";
            this.DGCPromedio.Visible = false;
            // 
            // DGCUltimaRecepcion
            // 
            this.DGCUltimaRecepcion.DataPropertyName = "UltimaRecepcion";
            this.DGCUltimaRecepcion.HeaderText = "Ultima Recepción?";
            this.DGCUltimaRecepcion.Name = "DGCUltimaRecepcion";
            this.DGCUltimaRecepcion.ToolTipText = "Utilizar la Ultima Recepción para el calculo de Precios";
            this.DGCUltimaRecepcion.Visible = false;
            // 
            // DGCMontoGastoProducto
            // 
            this.DGCMontoGastoProducto.DataPropertyName = "MontoGastoProducto";
            this.DGCMontoGastoProducto.HeaderText = "Monto Incremento";
            this.DGCMontoGastoProducto.Name = "DGCMontoGastoProducto";
            this.DGCMontoGastoProducto.ToolTipText = "Monto de Incremento al Precio de Compra";
            // 
            // gBoxProductos
            // 
            this.gBoxProductos.Controls.Add(this.dtGVProductos);
            this.gBoxProductos.Controls.Add(this.pnlDetallePreciosGastos);
            this.gBoxProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxProductos.Location = new System.Drawing.Point(0, 50);
            this.gBoxProductos.Name = "gBoxProductos";
            this.gBoxProductos.Padding = new System.Windows.Forms.Padding(5);
            this.gBoxProductos.Size = new System.Drawing.Size(905, 285);
            this.gBoxProductos.TabIndex = 3;
            this.gBoxProductos.TabStop = false;
            this.gBoxProductos.Text = "Listado de Productos Ingresados";
            // 
            // pnlDetallePreciosGastos
            // 
            this.pnlDetallePreciosGastos.Controls.Add(this.label2);
            this.pnlDetallePreciosGastos.Controls.Add(this.label1);
            this.pnlDetallePreciosGastos.Controls.Add(this.txtMontoTotalGastos);
            this.pnlDetallePreciosGastos.Controls.Add(this.txtBoxMontoRestantePersonalizado);
            this.pnlDetallePreciosGastos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetallePreciosGastos.Location = new System.Drawing.Point(5, 229);
            this.pnlDetallePreciosGastos.Name = "pnlDetallePreciosGastos";
            this.pnlDetallePreciosGastos.Size = new System.Drawing.Size(895, 51);
            this.pnlDetallePreciosGastos.TabIndex = 1;
            // 
            // txtBoxMontoRestantePersonalizado
            // 
            this.txtBoxMontoRestantePersonalizado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxMontoRestantePersonalizado.BackColor = System.Drawing.Color.Black;
            this.txtBoxMontoRestantePersonalizado.ForeColor = System.Drawing.Color.GreenYellow;
            this.txtBoxMontoRestantePersonalizado.Location = new System.Drawing.Point(779, 3);
            this.txtBoxMontoRestantePersonalizado.Name = "txtBoxMontoRestantePersonalizado";
            this.txtBoxMontoRestantePersonalizado.Size = new System.Drawing.Size(109, 20);
            this.txtBoxMontoRestantePersonalizado.TabIndex = 0;
            this.txtBoxMontoRestantePersonalizado.Text = "0.00";
            this.txtBoxMontoRestantePersonalizado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NombreProducto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Nombre o Descripción del Producto";
            this.dataGridViewTextBoxColumn1.Width = 188;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CodigoTipoCalculoInventario";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tipo Calculo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.ToolTipText = "Precio Unitario de Compra";
            this.dataGridViewTextBoxColumn2.Width = 188;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NombreGasto";
            this.dataGridViewTextBoxColumn3.HeaderText = "Gasto";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.ToolTipText = "Tipo de Calculo de Actualizaicón para los Precios en Inventario";
            this.dataGridViewTextBoxColumn3.Width = 564;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MontoGastoProducto";
            this.dataGridViewTextBoxColumn4.HeaderText = "Precio Adicional";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ToolTipText = "Precio que se Debe adicionar por los Gastos extras";
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 112;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NombreGasto";
            this.dataGridViewTextBoxColumn5.HeaderText = "Gastos";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.ToolTipText = "Gastos Realizados para la Recepción de esta Compra";
            this.dataGridViewTextBoxColumn5.Width = 787;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MontoPagoGasto";
            this.dataGridViewTextBoxColumn6.HeaderText = "Monto Gasto";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 393;
            // 
            // FTransferenciasProductosListadoCalculoGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(905, 603);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gBoxProductos);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblMensaje);
            this.Name = "FTransferenciasProductosListadoCalculoGastos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Gastos por Transferencia de Productos";
            this.Load += new System.EventHandler(this.FTransferenciasProductosListadoCalculoGastos_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FTransferenciasProductosListadoCalculoGastos_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVGastos)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductos)).EndInit();
            this.gBoxProductos.ResumeLayout(false);
            this.pnlDetallePreciosGastos.ResumeLayout(false);
            this.pnlDetallePreciosGastos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn DGCMontoPagoGasto;
        private System.Windows.Forms.DataGridView dtGVGastos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreGasto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.CheckBox checkUtilizarGastosActuales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMontoTotalGastos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.DataGridView dtGVProductos;
        private System.Windows.Forms.GroupBox gBoxProductos;
        private System.Windows.Forms.Panel pnlDetallePreciosGastos;
        private System.Windows.Forms.TextBox txtBoxMontoRestantePersonalizado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPrecioUnitarioTransferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCTipoCalculoInventario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCActualizarPrecioVenta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCPromedio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCUltimaRecepcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCMontoGastoProducto;
    }
}