namespace WFADoblones20.FormulariosContabilidad
{
    partial class FPagarCuentasPorPagar
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbMoneda = new System.Windows.Forms.Label();
            this.tbMonto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbHaber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDebe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbMontosParciales = new System.Windows.Forms.CheckBox();
            this.btOk = new System.Windows.Forms.Button();
            this.tbMontoDelTotal = new System.Windows.Forms.TextBox();
            this.cbCuentas = new System.Windows.Forms.ComboBox();
            this.dgvConfiguracionDetalle = new System.Windows.Forms.DataGridView();
            this.dgvcNumeroCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNombreCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btNuevaConfiguracion = new System.Windows.Forms.Button();
            this.cbConfiguraciones = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfiguracionDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbMoneda);
            this.groupBox1.Controls.Add(this.tbMonto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 57);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos:";
            // 
            // lbMoneda
            // 
            this.lbMoneda.AutoSize = true;
            this.lbMoneda.Location = new System.Drawing.Point(276, 27);
            this.lbMoneda.Name = "lbMoneda";
            this.lbMoneda.Size = new System.Drawing.Size(46, 13);
            this.lbMoneda.TabIndex = 5;
            this.lbMoneda.Text = "Moneda";
            // 
            // tbMonto
            // 
            this.tbMonto.Location = new System.Drawing.Point(170, 24);
            this.tbMonto.Name = "tbMonto";
            this.tbMonto.Size = new System.Drawing.Size(100, 20);
            this.tbMonto.TabIndex = 0;
            this.tbMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMonto_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Monto:";
            // 
            // btAceptar
            // 
            this.btAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAceptar.Location = new System.Drawing.Point(326, 396);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 0;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(407, 396);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tbHaber);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbDebe);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.chbMontosParciales);
            this.groupBox2.Controls.Add(this.btOk);
            this.groupBox2.Controls.Add(this.tbMontoDelTotal);
            this.groupBox2.Controls.Add(this.cbCuentas);
            this.groupBox2.Controls.Add(this.dgvConfiguracionDetalle);
            this.groupBox2.Controls.Add(this.btNuevaConfiguracion);
            this.groupBox2.Controls.Add(this.cbConfiguraciones);
            this.groupBox2.Location = new System.Drawing.Point(13, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 314);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Asiento contable:";
            // 
            // tbHaber
            // 
            this.tbHaber.Location = new System.Drawing.Point(363, 288);
            this.tbHaber.Name = "tbHaber";
            this.tbHaber.ReadOnly = true;
            this.tbHaber.Size = new System.Drawing.Size(100, 20);
            this.tbHaber.TabIndex = 10;
            this.tbHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Suma Haber:";
            // 
            // tbDebe
            // 
            this.tbDebe.Location = new System.Drawing.Point(257, 288);
            this.tbDebe.Name = "tbDebe";
            this.tbDebe.ReadOnly = true;
            this.tbDebe.Size = new System.Drawing.Size(100, 20);
            this.tbDebe.TabIndex = 8;
            this.tbDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Suma Debe:";
            // 
            // chbMontosParciales
            // 
            this.chbMontosParciales.AutoSize = true;
            this.chbMontosParciales.Location = new System.Drawing.Point(6, 47);
            this.chbMontosParciales.Name = "chbMontosParciales";
            this.chbMontosParciales.Size = new System.Drawing.Size(106, 17);
            this.chbMontosParciales.TabIndex = 2;
            this.chbMontosParciales.Text = "Modificar montos";
            this.chbMontosParciales.UseVisualStyleBackColor = true;
            this.chbMontosParciales.CheckedChanged += new System.EventHandler(this.chbMontosParciales_CheckedChanged);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(416, 62);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(47, 23);
            this.btOk.TabIndex = 5;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // tbMontoDelTotal
            // 
            this.tbMontoDelTotal.Location = new System.Drawing.Point(313, 64);
            this.tbMontoDelTotal.Name = "tbMontoDelTotal";
            this.tbMontoDelTotal.Size = new System.Drawing.Size(96, 20);
            this.tbMontoDelTotal.TabIndex = 4;
            this.tbMontoDelTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMontoDelTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMontoDelTotal_KeyPress);
            // 
            // cbCuentas
            // 
            this.cbCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCuentas.FormattingEnabled = true;
            this.cbCuentas.Location = new System.Drawing.Point(6, 64);
            this.cbCuentas.Name = "cbCuentas";
            this.cbCuentas.Size = new System.Drawing.Size(301, 21);
            this.cbCuentas.TabIndex = 3;
            this.cbCuentas.SelectedIndexChanged += new System.EventHandler(this.cbCuentas_SelectedIndexChanged);
            // 
            // dgvConfiguracionDetalle
            // 
            this.dgvConfiguracionDetalle.AllowUserToAddRows = false;
            this.dgvConfiguracionDetalle.AllowUserToDeleteRows = false;
            this.dgvConfiguracionDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConfiguracionDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvConfiguracionDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfiguracionDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcNumeroCuenta,
            this.dgvcNombreCuenta,
            this.dgvcSaldo,
            this.dgvcDebe,
            this.dgvcHaber});
            this.dgvConfiguracionDetalle.Location = new System.Drawing.Point(7, 91);
            this.dgvConfiguracionDetalle.MultiSelect = false;
            this.dgvConfiguracionDetalle.Name = "dgvConfiguracionDetalle";
            this.dgvConfiguracionDetalle.ReadOnly = true;
            this.dgvConfiguracionDetalle.RowHeadersVisible = false;
            this.dgvConfiguracionDetalle.Size = new System.Drawing.Size(456, 178);
            this.dgvConfiguracionDetalle.TabIndex = 6;
            // 
            // dgvcNumeroCuenta
            // 
            this.dgvcNumeroCuenta.HeaderText = "Nº Cuenta";
            this.dgvcNumeroCuenta.Name = "dgvcNumeroCuenta";
            this.dgvcNumeroCuenta.ReadOnly = true;
            this.dgvcNumeroCuenta.Width = 75;
            // 
            // dgvcNombreCuenta
            // 
            this.dgvcNombreCuenta.HeaderText = "Nombre de cuenta";
            this.dgvcNombreCuenta.Name = "dgvcNombreCuenta";
            this.dgvcNombreCuenta.ReadOnly = true;
            this.dgvcNombreCuenta.Width = 80;
            // 
            // dgvcSaldo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.dgvcSaldo.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvcSaldo.HeaderText = "Saldo en cuenta";
            this.dgvcSaldo.Name = "dgvcSaldo";
            this.dgvcSaldo.ReadOnly = true;
            this.dgvcSaldo.Width = 101;
            // 
            // dgvcDebe
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dgvcDebe.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcDebe.HeaderText = "Debe";
            this.dgvcDebe.Name = "dgvcDebe";
            this.dgvcDebe.ReadOnly = true;
            this.dgvcDebe.Width = 58;
            // 
            // dgvcHaber
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.dgvcHaber.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvcHaber.HeaderText = "Haber";
            this.dgvcHaber.Name = "dgvcHaber";
            this.dgvcHaber.ReadOnly = true;
            this.dgvcHaber.Width = 61;
            // 
            // btNuevaConfiguracion
            // 
            this.btNuevaConfiguracion.Location = new System.Drawing.Point(415, 17);
            this.btNuevaConfiguracion.Name = "btNuevaConfiguracion";
            this.btNuevaConfiguracion.Size = new System.Drawing.Size(48, 23);
            this.btNuevaConfiguracion.TabIndex = 1;
            this.btNuevaConfiguracion.Text = "Nueva";
            this.btNuevaConfiguracion.UseVisualStyleBackColor = true;
            this.btNuevaConfiguracion.Click += new System.EventHandler(this.btNuevaConfiguracion_Click);
            // 
            // cbConfiguraciones
            // 
            this.cbConfiguraciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConfiguraciones.FormattingEnabled = true;
            this.cbConfiguraciones.Location = new System.Drawing.Point(6, 19);
            this.cbConfiguraciones.Name = "cbConfiguraciones";
            this.cbConfiguraciones.Size = new System.Drawing.Size(403, 21);
            this.cbConfiguraciones.TabIndex = 0;
            this.cbConfiguraciones.SelectedIndexChanged += new System.EventHandler(this.cbConfiguraciones_SelectedIndexChanged);
            // 
            // FPagarCuentasPorPagar
            // 
            this.AcceptButton = this.btAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(494, 431);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FPagarCuentasPorPagar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FPagarCuentasPorPagar_FormClosing);
            this.Load += new System.EventHandler(this.FPagarCuentasPorPagar_Load);
            this.Shown += new System.EventHandler(this.FPagarCuentasPorPagar_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfiguracionDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbMoneda;
        private System.Windows.Forms.TextBox tbMonto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.TextBox tbMontoDelTotal;
        private System.Windows.Forms.ComboBox cbCuentas;
        private System.Windows.Forms.DataGridView dgvConfiguracionDetalle;
        private System.Windows.Forms.Button btNuevaConfiguracion;
        private System.Windows.Forms.ComboBox cbConfiguraciones;
        private System.Windows.Forms.CheckBox chbMontosParciales;
        private System.Windows.Forms.TextBox tbHaber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDebe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumeroCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNombreCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcHaber;
    }
}