namespace WFADoblones20.FormulariosContabilidad
{
    partial class FAsientosDetalle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNumeroAsiento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDetalleAsiento = new System.Windows.Forms.DataGridView();
            this.dgvcNumeroCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNombreCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.tbGlosa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTotalDebe = new System.Windows.Forms.TextBox();
            this.tbTotalHaber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.chbReporte = new System.Windows.Forms.CheckBox();
            this.mtbFecha = new System.Windows.Forms.MaskedTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.mtbHora = new System.Windows.Forms.MaskedTextBox();
            this.lbEstado = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDiferencia = new System.Windows.Forms.TextBox();
            this.lnklbPlanCuentas = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lbMonto = new System.Windows.Forms.Label();
            this.tbMonto = new System.Windows.Forms.TextBox();
            this.btAnadir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleAsiento)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº de Asiento:";
            // 
            // tbNumeroAsiento
            // 
            this.tbNumeroAsiento.Location = new System.Drawing.Point(93, 12);
            this.tbNumeroAsiento.Name = "tbNumeroAsiento";
            this.tbNumeroAsiento.ReadOnly = true;
            this.tbNumeroAsiento.Size = new System.Drawing.Size(64, 20);
            this.tbNumeroAsiento.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha:";
            // 
            // dgvDetalleAsiento
            // 
            this.dgvDetalleAsiento.AllowUserToResizeColumns = false;
            this.dgvDetalleAsiento.AllowUserToResizeRows = false;
            this.dgvDetalleAsiento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalleAsiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleAsiento.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDetalleAsiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleAsiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcNumeroCuenta,
            this.dgvcNombreCuenta,
            this.dgvcDebe,
            this.dgvcHaber});
            this.dgvDetalleAsiento.Location = new System.Drawing.Point(0, 54);
            this.dgvDetalleAsiento.MultiSelect = false;
            this.dgvDetalleAsiento.Name = "dgvDetalleAsiento";
            this.dgvDetalleAsiento.Size = new System.Drawing.Size(792, 387);
            this.dgvDetalleAsiento.TabIndex = 3;
            this.dgvDetalleAsiento.SizeChanged += new System.EventHandler(this.dgvDetalleAsiento_SizeChanged);
            this.dgvDetalleAsiento.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleAsiento_CellEndEdit);
            this.dgvDetalleAsiento.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetalleAsiento_EditingControlShowing);
            this.dgvDetalleAsiento.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleAsiento_CellEnter);
            // 
            // dgvcNumeroCuenta
            // 
            this.dgvcNumeroCuenta.DataPropertyName = "NumeroCuenta";
            dataGridViewCellStyle1.Format = "1-0-00-00-000";
            this.dgvcNumeroCuenta.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvcNumeroCuenta.HeaderText = "Nº Cuenta";
            this.dgvcNumeroCuenta.MinimumWidth = 75;
            this.dgvcNumeroCuenta.Name = "dgvcNumeroCuenta";
            this.dgvcNumeroCuenta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcNumeroCuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvcNombreCuenta
            // 
            this.dgvcNombreCuenta.DataPropertyName = "NombreCuenta";
            this.dgvcNombreCuenta.HeaderText = "Nombre de la cuenta";
            this.dgvcNombreCuenta.MinimumWidth = 429;
            this.dgvcNombreCuenta.Name = "dgvcNombreCuenta";
            this.dgvcNombreCuenta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcNombreCuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvcDebe
            // 
            this.dgvcDebe.DataPropertyName = "Debe";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0,00";
            this.dgvcDebe.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcDebe.HeaderText = "Debe";
            this.dgvcDebe.MinimumWidth = 100;
            this.dgvcDebe.Name = "dgvcDebe";
            this.dgvcDebe.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgvcHaber
            // 
            this.dgvcHaber.DataPropertyName = "Haber";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0,00";
            this.dgvcHaber.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvcHaber.HeaderText = "Haber";
            this.dgvcHaber.MinimumWidth = 100;
            this.dgvcHaber.Name = "dgvcHaber";
            this.dgvcHaber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 450);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Glosa:";
            // 
            // tbGlosa
            // 
            this.tbGlosa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGlosa.Location = new System.Drawing.Point(55, 447);
            this.tbGlosa.Multiline = true;
            this.tbGlosa.Name = "tbGlosa";
            this.tbGlosa.Size = new System.Drawing.Size(468, 58);
            this.tbGlosa.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(553, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total:";
            // 
            // tbTotalDebe
            // 
            this.tbTotalDebe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotalDebe.Location = new System.Drawing.Point(593, 441);
            this.tbTotalDebe.Name = "tbTotalDebe";
            this.tbTotalDebe.ReadOnly = true;
            this.tbTotalDebe.Size = new System.Drawing.Size(100, 20);
            this.tbTotalDebe.TabIndex = 5;
            this.tbTotalDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbTotalHaber
            // 
            this.tbTotalHaber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotalHaber.Location = new System.Drawing.Point(692, 441);
            this.tbTotalHaber.Name = "tbTotalHaber";
            this.tbTotalHaber.ReadOnly = true;
            this.tbTotalHaber.Size = new System.Drawing.Size(100, 20);
            this.tbTotalHaber.TabIndex = 6;
            this.tbTotalHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Estado:";
            // 
            // btAceptar
            // 
            this.btAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAceptar.Location = new System.Drawing.Point(624, 518);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 9;
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Location = new System.Drawing.Point(705, 518);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 10;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // chbReporte
            // 
            this.chbReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbReporte.AutoSize = true;
            this.chbReporte.Location = new System.Drawing.Point(554, 522);
            this.chbReporte.Name = "chbReporte";
            this.chbReporte.Size = new System.Drawing.Size(64, 17);
            this.chbReporte.TabIndex = 8;
            this.chbReporte.Text = "Reporte";
            this.chbReporte.UseVisualStyleBackColor = true;
            // 
            // mtbFecha
            // 
            this.mtbFecha.Location = new System.Drawing.Point(209, 12);
            this.mtbFecha.Mask = "00/00/0000";
            this.mtbFecha.Name = "mtbFecha";
            this.mtbFecha.PromptChar = '-';
            this.mtbFecha.RejectInputOnFirstFailure = true;
            this.mtbFecha.Size = new System.Drawing.Size(72, 20);
            this.mtbFecha.TabIndex = 1;
            this.mtbFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbFecha.ValidatingType = typeof(System.DateTime);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(251, 17);
            this.toolStripStatusLabel1.Text = "Clic derecho sobre fila para seleccionar cuenta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Hora:";
            // 
            // mtbHora
            // 
            this.mtbHora.Location = new System.Drawing.Point(326, 12);
            this.mtbHora.Mask = "00:00";
            this.mtbHora.Name = "mtbHora";
            this.mtbHora.PromptChar = '-';
            this.mtbHora.RejectInputOnFirstFailure = true;
            this.mtbHora.Size = new System.Drawing.Size(40, 20);
            this.mtbHora.TabIndex = 2;
            this.mtbHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbHora.ValidatingType = typeof(System.DateTime);
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Location = new System.Drawing.Point(61, 38);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(0, 13);
            this.lbEstado.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(529, 470);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Diferencia:";
            // 
            // tbDiferencia
            // 
            this.tbDiferencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDiferencia.Location = new System.Drawing.Point(593, 467);
            this.tbDiferencia.Name = "tbDiferencia";
            this.tbDiferencia.ReadOnly = true;
            this.tbDiferencia.Size = new System.Drawing.Size(100, 20);
            this.tbDiferencia.TabIndex = 7;
            this.tbDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lnklbPlanCuentas
            // 
            this.lnklbPlanCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnklbPlanCuentas.AutoSize = true;
            this.lnklbPlanCuentas.Location = new System.Drawing.Point(630, 9);
            this.lnklbPlanCuentas.Name = "lnklbPlanCuentas";
            this.lnklbPlanCuentas.Size = new System.Drawing.Size(150, 13);
            this.lnklbPlanCuentas.TabIndex = 22;
            this.lnklbPlanCuentas.TabStop = true;
            this.lnklbPlanCuentas.Text = "Administrar el Plan de Cuentas";
            this.lnklbPlanCuentas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbPlanCuentas_LinkClicked);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lbMonto
            // 
            this.lbMonto.AutoSize = true;
            this.lbMonto.Enabled = false;
            this.lbMonto.Location = new System.Drawing.Point(372, 9);
            this.lbMonto.Name = "lbMonto";
            this.lbMonto.Size = new System.Drawing.Size(43, 13);
            this.lbMonto.TabIndex = 24;
            this.lbMonto.Text = "Monto: ";
            this.lbMonto.Visible = false;
            // 
            // tbMonto
            // 
            this.tbMonto.Enabled = false;
            this.tbMonto.Location = new System.Drawing.Point(375, 26);
            this.tbMonto.Name = "tbMonto";
            this.tbMonto.Size = new System.Drawing.Size(100, 20);
            this.tbMonto.TabIndex = 25;
            this.tbMonto.Text = "0";
            this.tbMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMonto.Visible = false;
            this.tbMonto.Leave += new System.EventHandler(this.tbMonto_Leave);
            this.tbMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMonto_KeyPress);
            // 
            // btAnadir
            // 
            this.btAnadir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAnadir.Enabled = false;
            this.btAnadir.Location = new System.Drawing.Point(481, 24);
            this.btAnadir.Name = "btAnadir";
            this.btAnadir.Size = new System.Drawing.Size(25, 23);
            this.btAnadir.TabIndex = 26;
            this.btAnadir.Text = "+";
            this.btAnadir.UseVisualStyleBackColor = true;
            this.btAnadir.Visible = false;
            this.btAnadir.Click += new System.EventHandler(this.btAnadir_Click);
            // 
            // FAsientosDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.tbMonto);
            this.Controls.Add(this.btAnadir);
            this.Controls.Add(this.lnklbPlanCuentas);
            this.Controls.Add(this.lbMonto);
            this.Controls.Add(this.tbDiferencia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mtbHora);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbEstado);
            this.Controls.Add(this.mtbFecha);
            this.Controls.Add(this.chbReporte);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.tbTotalHaber);
            this.Controls.Add(this.tbTotalDebe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbGlosa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDetalleAsiento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNumeroAsiento);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FAsientosDetalle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle del asiento contable";
            this.Load += new System.EventHandler(this.FAsientosComtablesDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleAsiento)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNumeroAsiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDetalleAsiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbGlosa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTotalDebe;
        private System.Windows.Forms.TextBox tbTotalHaber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.CheckBox chbReporte;
        private System.Windows.Forms.MaskedTextBox mtbFecha;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mtbHora;
        private System.Windows.Forms.Label lbEstado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDiferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumeroCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNombreCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcHaber;
        private System.Windows.Forms.LinkLabel lnklbPlanCuentas;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lbMonto;
        private System.Windows.Forms.TextBox tbMonto;
        private System.Windows.Forms.Button btAnadir;
    }
}