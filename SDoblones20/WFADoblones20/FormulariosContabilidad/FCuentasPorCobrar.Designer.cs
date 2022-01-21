namespace WFADoblones20.FormulariosContabilidad
{
    partial class FCuentasPorCobrar
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btBuscar = new System.Windows.Forms.Button();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btPagar = new System.Windows.Forms.Button();
            this.btVer = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btModificar = new System.Windows.Forms.Button();
            this.btNuevo = new System.Windows.Forms.Button();
            this.dgvCuentasPorPagar = new System.Windows.Forms.DataGridView();
            this.dgvcSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvcNumeroCuentaPorCobrar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNumeroConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNumeroAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNombreAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCodigoProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCodigoMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcFechaLim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCodigoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNumeroAsiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btAsiento = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasPorPagar)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 420);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(724, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btBuscar
            // 
            this.btBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btBuscar.Location = new System.Drawing.Point(639, 46);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 23);
            this.btBuscar.TabIndex = 12;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Items.AddRange(new object[] {
            "Cancelado",
            "Pendiente",
            "Todos"});
            this.cbEstado.Location = new System.Drawing.Point(533, 48);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(100, 21);
            this.cbEstado.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(484, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Estado:";
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha2.Location = new System.Drawing.Point(387, 48);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(90, 20);
            this.dtpFecha2.TabIndex = 10;
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha1.Location = new System.Drawing.Point(291, 48);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(90, 20);
            this.dtpFecha1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "En fechas:";
            // 
            // tbBuscar
            // 
            this.tbBuscar.Location = new System.Drawing.Point(61, 48);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(160, 20);
            this.tbBuscar.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Buscar:";
            // 
            // btPagar
            // 
            this.btPagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPagar.Location = new System.Drawing.Point(336, 19);
            this.btPagar.Name = "btPagar";
            this.btPagar.Size = new System.Drawing.Size(90, 23);
            this.btPagar.TabIndex = 4;
            this.btPagar.Text = "Registrar cobro";
            this.btPagar.UseVisualStyleBackColor = true;
            this.btPagar.Click += new System.EventHandler(this.btPagar_Click);
            // 
            // btVer
            // 
            this.btVer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btVer.Location = new System.Drawing.Point(255, 19);
            this.btVer.Name = "btVer";
            this.btVer.Size = new System.Drawing.Size(75, 23);
            this.btVer.TabIndex = 3;
            this.btVer.Text = "Ver cobros";
            this.btVer.UseVisualStyleBackColor = true;
            this.btVer.Click += new System.EventHandler(this.btVer_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEliminar.Location = new System.Drawing.Point(93, 19);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(75, 23);
            this.btEliminar.TabIndex = 1;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btModificar
            // 
            this.btModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModificar.Location = new System.Drawing.Point(174, 19);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(75, 23);
            this.btModificar.TabIndex = 2;
            this.btModificar.Text = "Modificar";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // btNuevo
            // 
            this.btNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNuevo.Location = new System.Drawing.Point(12, 19);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(75, 23);
            this.btNuevo.TabIndex = 0;
            this.btNuevo.Text = "Nuevo";
            this.btNuevo.UseVisualStyleBackColor = true;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // dgvCuentasPorPagar
            // 
            this.dgvCuentasPorPagar.AllowUserToAddRows = false;
            this.dgvCuentasPorPagar.AllowUserToDeleteRows = false;
            this.dgvCuentasPorPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCuentasPorPagar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCuentasPorPagar.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCuentasPorPagar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentasPorPagar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcSeleccionar,
            this.dgvcNumeroCuentaPorCobrar,
            this.dgvcNumeroConcepto,
            this.dgvcConcepto,
            this.dgvcNumeroAgencia,
            this.dgvcNombreAgencia,
            this.dgvcFechaHora,
            this.dgvcCodigoProveedor,
            this.dgvcProveedor,
            this.dgvcCodigoMoneda,
            this.dgvcMoneda,
            this.dgvcMonto,
            this.dgvcFechaLim,
            this.dgvcEstado,
            this.dgvcObservaciones,
            this.dgvcCodigoUsuario,
            this.dgvcNumeroAsiento});
            this.dgvCuentasPorPagar.Location = new System.Drawing.Point(0, 101);
            this.dgvCuentasPorPagar.MultiSelect = false;
            this.dgvCuentasPorPagar.Name = "dgvCuentasPorPagar";
            this.dgvCuentasPorPagar.RowHeadersVisible = false;
            this.dgvCuentasPorPagar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuentasPorPagar.Size = new System.Drawing.Size(724, 316);
            this.dgvCuentasPorPagar.TabIndex = 13;
            this.dgvCuentasPorPagar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvCuentasPorPagar_MouseDoubleClick);
            this.dgvCuentasPorPagar.SelectionChanged += new System.EventHandler(this.dgvCuentasPorPagar_SelectionChanged);
            // 
            // dgvcSeleccionar
            // 
            this.dgvcSeleccionar.HeaderText = "Registrar asiento contable";
            this.dgvcSeleccionar.Name = "dgvcSeleccionar";
            this.dgvcSeleccionar.Visible = false;
            // 
            // dgvcNumeroCuentaPorCobrar
            // 
            this.dgvcNumeroCuentaPorCobrar.DataPropertyName = "NumeroCuentaPorCobrar";
            this.dgvcNumeroCuentaPorCobrar.HeaderText = "NºCuentaPorCobrar";
            this.dgvcNumeroCuentaPorCobrar.Name = "dgvcNumeroCuentaPorCobrar";
            this.dgvcNumeroCuentaPorCobrar.ReadOnly = true;
            this.dgvcNumeroCuentaPorCobrar.Visible = false;
            // 
            // dgvcNumeroConcepto
            // 
            this.dgvcNumeroConcepto.DataPropertyName = "NumeroConcepto";
            this.dgvcNumeroConcepto.HeaderText = "NºConcepto";
            this.dgvcNumeroConcepto.Name = "dgvcNumeroConcepto";
            this.dgvcNumeroConcepto.ReadOnly = true;
            this.dgvcNumeroConcepto.Visible = false;
            // 
            // dgvcConcepto
            // 
            this.dgvcConcepto.DataPropertyName = "Concepto";
            this.dgvcConcepto.HeaderText = "Concepto";
            this.dgvcConcepto.Name = "dgvcConcepto";
            this.dgvcConcepto.ReadOnly = true;
            // 
            // dgvcNumeroAgencia
            // 
            this.dgvcNumeroAgencia.DataPropertyName = "NumeroAgencia";
            this.dgvcNumeroAgencia.HeaderText = "NºAgencia";
            this.dgvcNumeroAgencia.Name = "dgvcNumeroAgencia";
            this.dgvcNumeroAgencia.ReadOnly = true;
            this.dgvcNumeroAgencia.Visible = false;
            // 
            // dgvcNombreAgencia
            // 
            this.dgvcNombreAgencia.DataPropertyName = "Nombre Agencia";
            this.dgvcNombreAgencia.HeaderText = "Nombre Agencia";
            this.dgvcNombreAgencia.Name = "dgvcNombreAgencia";
            this.dgvcNombreAgencia.ReadOnly = true;
            // 
            // dgvcFechaHora
            // 
            this.dgvcFechaHora.DataPropertyName = "Fecha/Hora de Registro";
            this.dgvcFechaHora.HeaderText = "Fecha";
            this.dgvcFechaHora.Name = "dgvcFechaHora";
            this.dgvcFechaHora.ReadOnly = true;
            // 
            // dgvcCodigoProveedor
            // 
            this.dgvcCodigoProveedor.DataPropertyName = "CodigoProveedor";
            this.dgvcCodigoProveedor.HeaderText = "CodigoProveedor";
            this.dgvcCodigoProveedor.Name = "dgvcCodigoProveedor";
            this.dgvcCodigoProveedor.ReadOnly = true;
            this.dgvcCodigoProveedor.Visible = false;
            // 
            // dgvcProveedor
            // 
            this.dgvcProveedor.DataPropertyName = "Proveedor";
            this.dgvcProveedor.HeaderText = "Cliente/Proveedor";
            this.dgvcProveedor.Name = "dgvcProveedor";
            this.dgvcProveedor.ReadOnly = true;
            // 
            // dgvcCodigoMoneda
            // 
            this.dgvcCodigoMoneda.DataPropertyName = "CodigoMoneda";
            this.dgvcCodigoMoneda.HeaderText = "CodigoMoneda";
            this.dgvcCodigoMoneda.Name = "dgvcCodigoMoneda";
            this.dgvcCodigoMoneda.ReadOnly = true;
            this.dgvcCodigoMoneda.Visible = false;
            // 
            // dgvcMoneda
            // 
            this.dgvcMoneda.DataPropertyName = "Moneda";
            this.dgvcMoneda.HeaderText = "Moneda";
            this.dgvcMoneda.Name = "dgvcMoneda";
            this.dgvcMoneda.ReadOnly = true;
            // 
            // dgvcMonto
            // 
            this.dgvcMonto.DataPropertyName = "Monto";
            this.dgvcMonto.HeaderText = "Monto";
            this.dgvcMonto.Name = "dgvcMonto";
            this.dgvcMonto.ReadOnly = true;
            // 
            // dgvcFechaLim
            // 
            this.dgvcFechaLim.DataPropertyName = "Fecha Límite";
            this.dgvcFechaLim.HeaderText = "Fecha límite";
            this.dgvcFechaLim.Name = "dgvcFechaLim";
            this.dgvcFechaLim.ReadOnly = true;
            // 
            // dgvcEstado
            // 
            this.dgvcEstado.DataPropertyName = "Estado";
            this.dgvcEstado.HeaderText = "Estado";
            this.dgvcEstado.Name = "dgvcEstado";
            this.dgvcEstado.ReadOnly = true;
            // 
            // dgvcObservaciones
            // 
            this.dgvcObservaciones.DataPropertyName = "Observaciones";
            this.dgvcObservaciones.HeaderText = "Observaciones";
            this.dgvcObservaciones.Name = "dgvcObservaciones";
            this.dgvcObservaciones.ReadOnly = true;
            // 
            // dgvcCodigoUsuario
            // 
            this.dgvcCodigoUsuario.DataPropertyName = "CodigoUsuario";
            this.dgvcCodigoUsuario.HeaderText = "CodUsuario";
            this.dgvcCodigoUsuario.Name = "dgvcCodigoUsuario";
            this.dgvcCodigoUsuario.ReadOnly = true;
            this.dgvcCodigoUsuario.Visible = false;
            // 
            // dgvcNumeroAsiento
            // 
            this.dgvcNumeroAsiento.DataPropertyName = "NumeroAsiento";
            this.dgvcNumeroAsiento.HeaderText = "NumeroAsiento";
            this.dgvcNumeroAsiento.Name = "dgvcNumeroAsiento";
            this.dgvcNumeroAsiento.Visible = false;
            // 
            // btAsiento
            // 
            this.btAsiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAsiento.Location = new System.Drawing.Point(432, 19);
            this.btAsiento.Name = "btAsiento";
            this.btAsiento.Size = new System.Drawing.Size(75, 23);
            this.btAsiento.TabIndex = 5;
            this.btAsiento.Text = "Seleccionar";
            this.btAsiento.UseVisualStyleBackColor = true;
            this.btAsiento.Visible = false;
            this.btAsiento.Click += new System.EventHandler(this.btAsiento_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Enabled = false;
            this.btCancelar.Location = new System.Drawing.Point(513, 19);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 6;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Visible = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // cbProveedor
            // 
            this.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProveedor.FormattingEnabled = true;
            this.cbProveedor.Location = new System.Drawing.Point(61, 74);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(160, 21);
            this.cbProveedor.TabIndex = 28;
            this.cbProveedor.SelectedIndexChanged += new System.EventHandler(this.cbProveedor_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 26);
            this.label4.TabIndex = 29;
            this.label4.Text = "Cliente/\r\nProveedor";
            // 
            // btImprimir
            // 
            this.btImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btImprimir.Location = new System.Drawing.Point(639, 19);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(75, 23);
            this.btImprimir.TabIndex = 30;
            this.btImprimir.Text = "Imprimir";
            this.btImprimir.UseVisualStyleBackColor = true;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // FCuentasPorCobrar
            // 
            this.AcceptButton = this.btBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 442);
            this.Controls.Add(this.btImprimir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbProveedor);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAsiento);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFecha2);
            this.Controls.Add(this.dtpFecha1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btPagar);
            this.Controls.Add(this.btVer);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btModificar);
            this.Controls.Add(this.btNuevo);
            this.Controls.Add(this.dgvCuentasPorPagar);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FCuentasPorCobrar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas por cobrar";
            this.Load += new System.EventHandler(this.FCuentasPorCobrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasPorPagar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btPagar;
        private System.Windows.Forms.Button btVer;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.Button btNuevo;
        private System.Windows.Forms.DataGridView dgvCuentasPorPagar;
        private System.Windows.Forms.Button btAsiento;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.ComboBox cbProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumeroCuentaPorCobrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumeroConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumeroAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNombreAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCodigoProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCodigoMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcFechaLim;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcObservaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCodigoUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumeroAsiento;
        private System.Windows.Forms.Button btImprimir;
    }
}