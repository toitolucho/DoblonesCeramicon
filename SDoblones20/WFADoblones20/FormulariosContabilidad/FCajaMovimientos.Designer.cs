namespace WFADoblones20
{
    partial class FCajaMovimientos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btCajaSalida = new System.Windows.Forms.Button();
            this.btCajaEntrada = new System.Windows.Forms.Button();
            this.btMostrarCajaMovimiento = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCaja = new System.Windows.Forms.DataGridView();
            this.dgvcNumeroMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCodigoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btIniciarCaja = new System.Windows.Forms.Button();
            this.lbFechaActual = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btImprimirTodo = new System.Windows.Forms.Button();
            this.btnCerrarManejoCaja = new System.Windows.Forms.Button();
            this.btnReporteMovimiento = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(367, 65);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(80, 21);
            this.cbTipo.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Tipo;";
            // 
            // btCajaSalida
            // 
            this.btCajaSalida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCajaSalida.Location = new System.Drawing.Point(145, 63);
            this.btCajaSalida.Name = "btCajaSalida";
            this.btCajaSalida.Size = new System.Drawing.Size(124, 23);
            this.btCajaSalida.TabIndex = 13;
            this.btCajaSalida.Text = "Registrar una salida";
            this.btCajaSalida.UseVisualStyleBackColor = true;
            this.btCajaSalida.Click += new System.EventHandler(this.btCajaSalida_Click_1);
            // 
            // btCajaEntrada
            // 
            this.btCajaEntrada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCajaEntrada.Location = new System.Drawing.Point(12, 63);
            this.btCajaEntrada.Name = "btCajaEntrada";
            this.btCajaEntrada.Size = new System.Drawing.Size(124, 23);
            this.btCajaEntrada.TabIndex = 11;
            this.btCajaEntrada.Text = "Registrar una entrada";
            this.btCajaEntrada.UseVisualStyleBackColor = true;
            this.btCajaEntrada.Click += new System.EventHandler(this.btCajaEntrada_Click_1);
            // 
            // btMostrarCajaMovimiento
            // 
            this.btMostrarCajaMovimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMostrarCajaMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btMostrarCajaMovimiento.Location = new System.Drawing.Point(705, 63);
            this.btMostrarCajaMovimiento.Name = "btMostrarCajaMovimiento";
            this.btMostrarCajaMovimiento.Size = new System.Drawing.Size(75, 23);
            this.btMostrarCajaMovimiento.TabIndex = 16;
            this.btMostrarCajaMovimiento.Text = "Mostrar";
            this.btMostrarCajaMovimiento.UseVisualStyleBackColor = true;
            this.btMostrarCajaMovimiento.Click += new System.EventHandler(this.btMostrarCajaMovimiento_Click_1);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecha.Location = new System.Drawing.Point(499, 64);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fecha:";
            // 
            // dgvCaja
            // 
            this.dgvCaja.AllowUserToAddRows = false;
            this.dgvCaja.AllowUserToDeleteRows = false;
            this.dgvCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCaja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaja.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcNumeroMovimiento,
            this.dgvcCodigoUsuario,
            this.dgvcFechaHora,
            this.dgvcDescripcion,
            this.dgvcTipo,
            this.dgvcImporte,
            this.dgvcSaldo});
            this.dgvCaja.Location = new System.Drawing.Point(4, 92);
            this.dgvCaja.Name = "dgvCaja";
            this.dgvCaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCaja.Size = new System.Drawing.Size(784, 420);
            this.dgvCaja.TabIndex = 18;
            // 
            // dgvcNumeroMovimiento
            // 
            this.dgvcNumeroMovimiento.DataPropertyName = "NumeroMovimiento";
            this.dgvcNumeroMovimiento.HeaderText = "Nº Movimiento";
            this.dgvcNumeroMovimiento.Name = "dgvcNumeroMovimiento";
            this.dgvcNumeroMovimiento.ReadOnly = true;
            // 
            // dgvcCodigoUsuario
            // 
            this.dgvcCodigoUsuario.DataPropertyName = "CodigoUsuario";
            this.dgvcCodigoUsuario.HeaderText = "Codigo Usuario";
            this.dgvcCodigoUsuario.Name = "dgvcCodigoUsuario";
            this.dgvcCodigoUsuario.ReadOnly = true;
            this.dgvcCodigoUsuario.Visible = false;
            // 
            // dgvcFechaHora
            // 
            this.dgvcFechaHora.DataPropertyName = "FechaHora";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dgvcFechaHora.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvcFechaHora.HeaderText = "Fecha/Hora";
            this.dgvcFechaHora.Name = "dgvcFechaHora";
            this.dgvcFechaHora.ReadOnly = true;
            // 
            // dgvcDescripcion
            // 
            this.dgvcDescripcion.DataPropertyName = "Descripcion";
            this.dgvcDescripcion.HeaderText = "Descripción";
            this.dgvcDescripcion.Name = "dgvcDescripcion";
            this.dgvcDescripcion.ReadOnly = true;
            // 
            // dgvcTipo
            // 
            this.dgvcTipo.DataPropertyName = "TipoMovimiento";
            this.dgvcTipo.HeaderText = "Tipo";
            this.dgvcTipo.Name = "dgvcTipo";
            this.dgvcTipo.ReadOnly = true;
            // 
            // dgvcImporte
            // 
            this.dgvcImporte.DataPropertyName = "Importe";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dgvcImporte.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcImporte.HeaderText = "Importe";
            this.dgvcImporte.Name = "dgvcImporte";
            this.dgvcImporte.ReadOnly = true;
            // 
            // dgvcSaldo
            // 
            this.dgvcSaldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.dgvcSaldo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvcSaldo.HeaderText = "Saldo";
            this.dgvcSaldo.Name = "dgvcSaldo";
            this.dgvcSaldo.ReadOnly = true;
            // 
            // btIniciarCaja
            // 
            this.btIniciarCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btIniciarCaja.Location = new System.Drawing.Point(12, 34);
            this.btIniciarCaja.Name = "btIniciarCaja";
            this.btIniciarCaja.Size = new System.Drawing.Size(124, 23);
            this.btIniciarCaja.TabIndex = 10;
            this.btIniciarCaja.Text = "Iniciar manejo de caja";
            this.btIniciarCaja.UseVisualStyleBackColor = true;
            this.btIniciarCaja.Click += new System.EventHandler(this.btIniciarCaja_Click_1);
            // 
            // lbFechaActual
            // 
            this.lbFechaActual.AutoSize = true;
            this.lbFechaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaActual.Location = new System.Drawing.Point(90, 9);
            this.lbFechaActual.Name = "lbFechaActual";
            this.lbFechaActual.Size = new System.Drawing.Size(0, 13);
            this.lbFechaActual.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Fecha actual:";
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.Location = new System.Drawing.Point(713, 518);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 24;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btImprimirTodo
            // 
            this.btImprimirTodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btImprimirTodo.Location = new System.Drawing.Point(4, 518);
            this.btImprimirTodo.Name = "btImprimirTodo";
            this.btImprimirTodo.Size = new System.Drawing.Size(186, 23);
            this.btImprimirTodo.TabIndex = 26;
            this.btImprimirTodo.Text = "Imprimir todos los movimientos";
            this.btImprimirTodo.UseVisualStyleBackColor = true;
            this.btImprimirTodo.Click += new System.EventHandler(this.btImprimirTodo_Click);
            // 
            // btnCerrarManejoCaja
            // 
            this.btnCerrarManejoCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarManejoCaja.Location = new System.Drawing.Point(145, 34);
            this.btnCerrarManejoCaja.Name = "btnCerrarManejoCaja";
            this.btnCerrarManejoCaja.Size = new System.Drawing.Size(124, 23);
            this.btnCerrarManejoCaja.TabIndex = 27;
            this.btnCerrarManejoCaja.Text = "Cerrar manejo de caja";
            this.btnCerrarManejoCaja.UseVisualStyleBackColor = true;
            this.btnCerrarManejoCaja.Click += new System.EventHandler(this.btnCerrarManejoCaja_Click);
            // 
            // btnReporteMovimiento
            // 
            this.btnReporteMovimiento.Location = new System.Drawing.Point(197, 519);
            this.btnReporteMovimiento.Name = "btnReporteMovimiento";
            this.btnReporteMovimiento.Size = new System.Drawing.Size(127, 23);
            this.btnReporteMovimiento.TabIndex = 28;
            this.btnReporteMovimiento.Text = "Informe Movimiento";
            this.btnReporteMovimiento.UseVisualStyleBackColor = true;
            this.btnReporteMovimiento.Click += new System.EventHandler(this.btnReporteMovimiento_Click);
            // 
            // FCajaMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnReporteMovimiento);
            this.Controls.Add(this.btnCerrarManejoCaja);
            this.Controls.Add(this.btImprimirTodo);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbFechaActual);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btCajaSalida);
            this.Controls.Add(this.btCajaEntrada);
            this.Controls.Add(this.btMostrarCajaMovimiento);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCaja);
            this.Controls.Add(this.btIniciarCaja);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FCajaMovimientos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manejo de caja";
            this.Load += new System.EventHandler(this.FCajaManejo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCajaSalida;
        private System.Windows.Forms.Button btCajaEntrada;
        private System.Windows.Forms.Button btMostrarCajaMovimiento;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCaja;
        private System.Windows.Forms.Button btIniciarCaja;
        private System.Windows.Forms.Label lbFechaActual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumeroMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCodigoUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSaldo;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btImprimirTodo;
        private System.Windows.Forms.Button btnCerrarManejoCaja;
        private System.Windows.Forms.Button btnReporteMovimiento;
    }
}