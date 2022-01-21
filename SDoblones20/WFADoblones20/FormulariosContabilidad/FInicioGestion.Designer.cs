namespace WFADoblones20.FormulariosContabilidad
{
    partial class FInicioGestion
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
            this.dgvDetalleAsiento = new System.Windows.Forms.DataGridView();
            this.dgvcNumeroCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNombreCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.tbTotalHaber = new System.Windows.Forms.TextBox();
            this.tbTotalDebe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbGlosa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleAsiento)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetalleAsiento
            // 
            this.dgvDetalleAsiento.AllowUserToAddRows = false;
            this.dgvDetalleAsiento.AllowUserToDeleteRows = false;
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
            this.dgvDetalleAsiento.Location = new System.Drawing.Point(0, -1);
            this.dgvDetalleAsiento.MultiSelect = false;
            this.dgvDetalleAsiento.Name = "dgvDetalleAsiento";
            this.dgvDetalleAsiento.Size = new System.Drawing.Size(792, 453);
            this.dgvDetalleAsiento.TabIndex = 7;
            this.dgvDetalleAsiento.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleAsiento_CellEndEdit);
            // 
            // dgvcNumeroCuenta
            // 
            this.dgvcNumeroCuenta.DataPropertyName = "NumeroCuenta";
            dataGridViewCellStyle1.Format = "1-0-00-00-000";
            this.dgvcNumeroCuenta.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvcNumeroCuenta.HeaderText = "Nº Cuenta";
            this.dgvcNumeroCuenta.MinimumWidth = 120;
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btCancelar);
            this.panel1.Controls.Add(this.btAceptar);
            this.panel1.Location = new System.Drawing.Point(12, 522);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 32);
            this.panel1.TabIndex = 8;
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(686, 3);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAceptar.Location = new System.Drawing.Point(605, 3);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 0;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // tbTotalHaber
            // 
            this.tbTotalHaber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotalHaber.Location = new System.Drawing.Point(692, 458);
            this.tbTotalHaber.Name = "tbTotalHaber";
            this.tbTotalHaber.ReadOnly = true;
            this.tbTotalHaber.Size = new System.Drawing.Size(100, 20);
            this.tbTotalHaber.TabIndex = 12;
            this.tbTotalHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbTotalDebe
            // 
            this.tbTotalDebe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotalDebe.Location = new System.Drawing.Point(593, 458);
            this.tbTotalDebe.Name = "tbTotalDebe";
            this.tbTotalDebe.ReadOnly = true;
            this.tbTotalDebe.Size = new System.Drawing.Size(100, 20);
            this.tbTotalDebe.TabIndex = 11;
            this.tbTotalDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(553, 461);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Total:";
            // 
            // tbGlosa
            // 
            this.tbGlosa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGlosa.Location = new System.Drawing.Point(54, 458);
            this.tbGlosa.Multiline = true;
            this.tbGlosa.Name = "tbGlosa";
            this.tbGlosa.Size = new System.Drawing.Size(492, 58);
            this.tbGlosa.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 461);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Glosa:";
            // 
            // FInicioGestion
            // 
            this.AcceptButton = this.btAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.tbGlosa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTotalHaber);
            this.Controls.Add(this.tbTotalDebe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDetalleAsiento);
            this.Name = "FInicioGestion";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de gestión";
            this.Load += new System.EventHandler(this.FInicioGestion_Load);
            this.SizeChanged += new System.EventHandler(this.FInicioGestion_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleAsiento)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetalleAsiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumeroCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNombreCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcHaber;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.TextBox tbTotalHaber;
        private System.Windows.Forms.TextBox tbTotalDebe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbGlosa;
        private System.Windows.Forms.Label label3;
    }
}