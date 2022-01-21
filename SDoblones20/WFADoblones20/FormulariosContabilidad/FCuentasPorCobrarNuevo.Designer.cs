namespace WFADoblones20.FormulariosContabilidad
{
    partial class FCuentasPorCobrarNuevo
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btModificar = new System.Windows.Forms.Button();
            this.btPagar = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btNuevoProveedor = new System.Windows.Forms.Button();
            this.btNuevoConcepto = new System.Windows.Forms.Button();
            this.cbConceptos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chbxEstado = new System.Windows.Forms.CheckBox();
            this.chbAsientos = new System.Windows.Forms.CheckBox();
            this.dtpFechaLim = new System.Windows.Forms.DateTimePicker();
            this.chbxFechaLim = new System.Windows.Forms.CheckBox();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMoneda = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMonto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbProveedores = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvcCodUsuarioPagos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNumCuentaPorPagarPagos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNumeroPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNomUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btEliminar);
            this.groupBox2.Controls.Add(this.btModificar);
            this.groupBox2.Controls.Add(this.btPagar);
            this.groupBox2.Controls.Add(this.dgvDetalle);
            this.groupBox2.Location = new System.Drawing.Point(368, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 319);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle de pagos:";
            // 
            // btEliminar
            // 
            this.btEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEliminar.Location = new System.Drawing.Point(181, 290);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(75, 23);
            this.btEliminar.TabIndex = 3;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btModificar
            // 
            this.btModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btModificar.Location = new System.Drawing.Point(100, 290);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(75, 23);
            this.btModificar.TabIndex = 2;
            this.btModificar.Text = "Modificar";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // btPagar
            // 
            this.btPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPagar.Location = new System.Drawing.Point(6, 290);
            this.btPagar.Name = "btPagar";
            this.btPagar.Size = new System.Drawing.Size(88, 23);
            this.btPagar.TabIndex = 1;
            this.btPagar.Text = "Realizar cobro";
            this.btPagar.UseVisualStyleBackColor = true;
            this.btPagar.Click += new System.EventHandler(this.btPagar_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcCodUsuarioPagos,
            this.dgvcNumCuentaPorPagarPagos,
            this.dgvcNumeroPago,
            this.dgvcMonto,
            this.dgvcFecha,
            this.dgvcNomUsuario,
            this.dgvcPaterno,
            this.dgvcMaterno});
            this.dgvDetalle.Location = new System.Drawing.Point(6, 19);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(262, 265);
            this.dgvDetalle.TabIndex = 0;
            this.dgvDetalle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDetalle_MouseDoubleClick);
            this.dgvDetalle.SelectionChanged += new System.EventHandler(this.dgvDetalle_SelectionChanged);
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(566, 338);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // btAceptar
            // 
            this.btAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAceptar.Location = new System.Drawing.Point(485, 338);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 0;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btNuevoProveedor);
            this.groupBox1.Controls.Add(this.btNuevoConcepto);
            this.groupBox1.Controls.Add(this.cbConceptos);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chbxEstado);
            this.groupBox1.Controls.Add(this.chbAsientos);
            this.groupBox1.Controls.Add(this.dtpFechaLim);
            this.groupBox1.Controls.Add(this.chbxFechaLim);
            this.groupBox1.Controls.Add(this.tbDescripcion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbMoneda);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbMonto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbProveedores);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 319);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos:";
            // 
            // btNuevoProveedor
            // 
            this.btNuevoProveedor.Location = new System.Drawing.Point(310, 48);
            this.btNuevoProveedor.Name = "btNuevoProveedor";
            this.btNuevoProveedor.Size = new System.Drawing.Size(30, 23);
            this.btNuevoProveedor.TabIndex = 3;
            this.btNuevoProveedor.Text = "...";
            this.btNuevoProveedor.UseVisualStyleBackColor = true;
            this.btNuevoProveedor.Click += new System.EventHandler(this.btNuevoProveedor_Click);
            // 
            // btNuevoConcepto
            // 
            this.btNuevoConcepto.Location = new System.Drawing.Point(310, 21);
            this.btNuevoConcepto.Name = "btNuevoConcepto";
            this.btNuevoConcepto.Size = new System.Drawing.Size(30, 23);
            this.btNuevoConcepto.TabIndex = 1;
            this.btNuevoConcepto.Text = "...";
            this.btNuevoConcepto.UseVisualStyleBackColor = true;
            this.btNuevoConcepto.Click += new System.EventHandler(this.btNuevoConcepto_Click);
            // 
            // cbConceptos
            // 
            this.cbConceptos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbConceptos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbConceptos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConceptos.FormattingEnabled = true;
            this.cbConceptos.Location = new System.Drawing.Point(110, 23);
            this.cbConceptos.Name = "cbConceptos";
            this.cbConceptos.Size = new System.Drawing.Size(194, 21);
            this.cbConceptos.Sorted = true;
            this.cbConceptos.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Concepto:";
            // 
            // chbxEstado
            // 
            this.chbxEstado.AutoSize = true;
            this.chbxEstado.Location = new System.Drawing.Point(6, 250);
            this.chbxEstado.Name = "chbxEstado";
            this.chbxEstado.Size = new System.Drawing.Size(77, 17);
            this.chbxEstado.TabIndex = 9;
            this.chbxEstado.Text = "Cancelado";
            this.chbxEstado.UseVisualStyleBackColor = true;
            // 
            // chbAsientos
            // 
            this.chbAsientos.AutoSize = true;
            this.chbAsientos.Enabled = false;
            this.chbAsientos.Location = new System.Drawing.Point(6, 281);
            this.chbAsientos.Name = "chbAsientos";
            this.chbAsientos.Size = new System.Drawing.Size(149, 17);
            this.chbAsientos.TabIndex = 10;
            this.chbAsientos.Text = "Registrar asiento contable";
            this.chbAsientos.UseVisualStyleBackColor = true;
            this.chbAsientos.Visible = false;
            // 
            // dtpFechaLim
            // 
            this.dtpFechaLim.Enabled = false;
            this.dtpFechaLim.Location = new System.Drawing.Point(110, 215);
            this.dtpFechaLim.Name = "dtpFechaLim";
            this.dtpFechaLim.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaLim.TabIndex = 8;
            // 
            // chbxFechaLim
            // 
            this.chbxFechaLim.AutoSize = true;
            this.chbxFechaLim.Location = new System.Drawing.Point(6, 215);
            this.chbxFechaLim.Name = "chbxFechaLim";
            this.chbxFechaLim.Size = new System.Drawing.Size(87, 17);
            this.chbxFechaLim.TabIndex = 7;
            this.chbxFechaLim.Text = "Fecha límite:";
            this.chbxFechaLim.UseVisualStyleBackColor = true;
            this.chbxFechaLim.CheckedChanged += new System.EventHandler(this.chbxFechaLim_CheckedChanged);
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(110, 131);
            this.tbDescripcion.MaxLength = 256;
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(234, 78);
            this.tbDescripcion.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Observaciones:";
            // 
            // cbMoneda
            // 
            this.cbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMoneda.FormattingEnabled = true;
            this.cbMoneda.Location = new System.Drawing.Point(110, 104);
            this.cbMoneda.Name = "cbMoneda";
            this.cbMoneda.Size = new System.Drawing.Size(194, 21);
            this.cbMoneda.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Moneda:";
            // 
            // tbMonto
            // 
            this.tbMonto.Location = new System.Drawing.Point(110, 78);
            this.tbMonto.Name = "tbMonto";
            this.tbMonto.Size = new System.Drawing.Size(100, 20);
            this.tbMonto.TabIndex = 4;
            this.tbMonto.Text = "0";
            this.tbMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMonto.Leave += new System.EventHandler(this.tbMonto_Leave);
            this.tbMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMonto_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Monto:";
            // 
            // cbProveedores
            // 
            this.cbProveedores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbProveedores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProveedores.FormattingEnabled = true;
            this.cbProveedores.Location = new System.Drawing.Point(110, 50);
            this.cbProveedores.Name = "cbProveedores";
            this.cbProveedores.Size = new System.Drawing.Size(194, 21);
            this.cbProveedores.Sorted = true;
            this.cbProveedores.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor:";
            // 
            // dgvcCodUsuarioPagos
            // 
            this.dgvcCodUsuarioPagos.DataPropertyName = "CodigoUsuario";
            this.dgvcCodUsuarioPagos.HeaderText = "Column1";
            this.dgvcCodUsuarioPagos.Name = "dgvcCodUsuarioPagos";
            this.dgvcCodUsuarioPagos.ReadOnly = true;
            this.dgvcCodUsuarioPagos.Visible = false;
            // 
            // dgvcNumCuentaPorPagarPagos
            // 
            this.dgvcNumCuentaPorPagarPagos.DataPropertyName = "NumeroCuentaPorCobrar";
            this.dgvcNumCuentaPorPagarPagos.HeaderText = "Column1";
            this.dgvcNumCuentaPorPagarPagos.Name = "dgvcNumCuentaPorPagarPagos";
            this.dgvcNumCuentaPorPagarPagos.ReadOnly = true;
            this.dgvcNumCuentaPorPagarPagos.Visible = false;
            // 
            // dgvcNumeroPago
            // 
            this.dgvcNumeroPago.DataPropertyName = "NumeroCobro";
            this.dgvcNumeroPago.HeaderText = "Column1";
            this.dgvcNumeroPago.Name = "dgvcNumeroPago";
            this.dgvcNumeroPago.ReadOnly = true;
            this.dgvcNumeroPago.Visible = false;
            // 
            // dgvcMonto
            // 
            this.dgvcMonto.DataPropertyName = "Monto";
            this.dgvcMonto.HeaderText = "Monto";
            this.dgvcMonto.Name = "dgvcMonto";
            this.dgvcMonto.ReadOnly = true;
            this.dgvcMonto.Width = 52;
            // 
            // dgvcFecha
            // 
            this.dgvcFecha.DataPropertyName = "FechaHoraCobro";
            this.dgvcFecha.HeaderText = "Fecha/Hora";
            this.dgvcFecha.Name = "dgvcFecha";
            this.dgvcFecha.ReadOnly = true;
            this.dgvcFecha.Width = 52;
            // 
            // dgvcNomUsuario
            // 
            this.dgvcNomUsuario.DataPropertyName = "Nombres";
            this.dgvcNomUsuario.HeaderText = "Nombres";
            this.dgvcNomUsuario.Name = "dgvcNomUsuario";
            this.dgvcNomUsuario.ReadOnly = true;
            this.dgvcNomUsuario.Width = 51;
            // 
            // dgvcPaterno
            // 
            this.dgvcPaterno.DataPropertyName = "Paterno";
            this.dgvcPaterno.HeaderText = "Apellido Paterno";
            this.dgvcPaterno.Name = "dgvcPaterno";
            this.dgvcPaterno.ReadOnly = true;
            this.dgvcPaterno.Width = 52;
            // 
            // dgvcMaterno
            // 
            this.dgvcMaterno.DataPropertyName = "Materno";
            this.dgvcMaterno.HeaderText = "Apellido Materno";
            this.dgvcMaterno.Name = "dgvcMaterno";
            this.dgvcMaterno.ReadOnly = true;
            this.dgvcMaterno.Width = 52;
            // 
            // FCuentasPorCobrarNuevo
            // 
            this.AcceptButton = this.btAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(654, 372);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FCuentasPorCobrarNuevo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuenta por cobrar";
            this.Load += new System.EventHandler(this.FCuentasPorCobrarNuevo_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.Button btPagar;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbxEstado;
        private System.Windows.Forms.CheckBox chbAsientos;
        private System.Windows.Forms.DateTimePicker dtpFechaLim;
        private System.Windows.Forms.CheckBox chbxFechaLim;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMoneda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMonto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbProveedores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btNuevoProveedor;
        private System.Windows.Forms.Button btNuevoConcepto;
        private System.Windows.Forms.ComboBox cbConceptos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCodUsuarioPagos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumCuentaPorPagarPagos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumeroPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNomUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMaterno;
    }
}