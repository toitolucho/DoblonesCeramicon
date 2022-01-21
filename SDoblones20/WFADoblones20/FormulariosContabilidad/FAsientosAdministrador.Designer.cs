namespace WFADoblones20.FormulariosContabilidad
{
    partial class FAsientosAdministrador
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
            this.tslbHint = new System.Windows.Forms.ToolStripStatusLabel();
            this.btNuevo = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btModificar = new System.Windows.Forms.Button();
            this.btVer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDel = new System.Windows.Forms.DateTimePicker();
            this.chbAl = new System.Windows.Forms.CheckBox();
            this.dtpAl = new System.Windows.Forms.DateTimePicker();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.dgvAsientos = new System.Windows.Forms.DataGridView();
            this.dgvcNumAsiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcGlosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btActualizar = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbHint});
            this.statusStrip1.Location = new System.Drawing.Point(0, 420);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(744, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslbHint
            // 
            this.tslbHint.Name = "tslbHint";
            this.tslbHint.Size = new System.Drawing.Size(83, 17);
            this.tslbHint.Text = "Administrador";
            // 
            // btNuevo
            // 
            this.btNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNuevo.Location = new System.Drawing.Point(13, 13);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(75, 23);
            this.btNuevo.TabIndex = 0;
            this.btNuevo.Text = "Nuevo";
            this.btNuevo.UseVisualStyleBackColor = true;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            this.btNuevo.Enter += new System.EventHandler(this.btNuevo_Enter);
            // 
            // btEliminar
            // 
            this.btEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEliminar.Location = new System.Drawing.Point(94, 13);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(75, 23);
            this.btEliminar.TabIndex = 1;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Enter += new System.EventHandler(this.btEliminar_Enter);
            // 
            // btModificar
            // 
            this.btModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModificar.Location = new System.Drawing.Point(175, 13);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(75, 23);
            this.btModificar.TabIndex = 2;
            this.btModificar.Text = "Modificar";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            this.btModificar.Enter += new System.EventHandler(this.btModificar_Enter);
            // 
            // btVer
            // 
            this.btVer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btVer.Location = new System.Drawing.Point(256, 13);
            this.btVer.Name = "btVer";
            this.btVer.Size = new System.Drawing.Size(75, 23);
            this.btVer.TabIndex = 3;
            this.btVer.Text = "Ver";
            this.btVer.UseVisualStyleBackColor = true;
            this.btVer.Click += new System.EventHandler(this.btVer_Click);
            this.btVer.Enter += new System.EventHandler(this.btVer_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Buscar:";
            // 
            // tbBuscar
            // 
            this.tbBuscar.Location = new System.Drawing.Point(62, 44);
            this.tbBuscar.MaxLength = 32;
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(120, 20);
            this.tbBuscar.TabIndex = 4;
            this.tbBuscar.Enter += new System.EventHandler(this.tbBuscar_Enter);
            // 
            // btBuscar
            // 
            this.btBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btBuscar.Location = new System.Drawing.Point(573, 42);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 23);
            this.btBuscar.TabIndex = 9;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            this.btBuscar.Enter += new System.EventHandler(this.btBuscar_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "De fecha:";
            // 
            // dtpDel
            // 
            this.dtpDel.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDel.Location = new System.Drawing.Point(249, 44);
            this.dtpDel.Name = "dtpDel";
            this.dtpDel.Size = new System.Drawing.Size(81, 20);
            this.dtpDel.TabIndex = 5;
            // 
            // chbAl
            // 
            this.chbAl.AutoSize = true;
            this.chbAl.Location = new System.Drawing.Point(336, 46);
            this.chbAl.Name = "chbAl";
            this.chbAl.Size = new System.Drawing.Size(38, 17);
            this.chbAl.TabIndex = 6;
            this.chbAl.Text = "Al:";
            this.chbAl.UseVisualStyleBackColor = true;
            this.chbAl.CheckedChanged += new System.EventHandler(this.chbAl_CheckedChanged);
            // 
            // dtpAl
            // 
            this.dtpAl.Enabled = false;
            this.dtpAl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAl.Location = new System.Drawing.Point(380, 44);
            this.dtpAl.Name = "dtpAl";
            this.dtpAl.Size = new System.Drawing.Size(81, 20);
            this.dtpAl.TabIndex = 7;
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Items.AddRange(new object[] {
            "Confirmado",
            "Pendiente",
            "Todos"});
            this.cbEstado.Location = new System.Drawing.Point(467, 44);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(100, 21);
            this.cbEstado.TabIndex = 8;
            this.cbEstado.Enter += new System.EventHandler(this.cbEstado_Enter);
            // 
            // dgvAsientos
            // 
            this.dgvAsientos.AllowUserToAddRows = false;
            this.dgvAsientos.AllowUserToDeleteRows = false;
            this.dgvAsientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAsientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsientos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAsientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcNumAsiento,
            this.dgvcFecha,
            this.dgvcHora,
            this.dgvcGlosa,
            this.dgvcEstado});
            this.dgvAsientos.Location = new System.Drawing.Point(0, 70);
            this.dgvAsientos.MultiSelect = false;
            this.dgvAsientos.Name = "dgvAsientos";
            this.dgvAsientos.ReadOnly = true;
            this.dgvAsientos.RowHeadersVisible = false;
            this.dgvAsientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsientos.Size = new System.Drawing.Size(744, 347);
            this.dgvAsientos.TabIndex = 11;
            this.dgvAsientos.Enter += new System.EventHandler(this.dgvAsientos_Enter);
            this.dgvAsientos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvAsientos_MouseDoubleClick);
            this.dgvAsientos.SelectionChanged += new System.EventHandler(this.dgvAsientos_SelectionChanged);
            // 
            // dgvcNumAsiento
            // 
            this.dgvcNumAsiento.DataPropertyName = "NumeroAsiento";
            this.dgvcNumAsiento.FillWeight = 48F;
            this.dgvcNumAsiento.HeaderText = "Nº Asiento";
            this.dgvcNumAsiento.Name = "dgvcNumAsiento";
            this.dgvcNumAsiento.ReadOnly = true;
            // 
            // dgvcFecha
            // 
            this.dgvcFecha.DataPropertyName = "Fecha";
            this.dgvcFecha.FillWeight = 48F;
            this.dgvcFecha.HeaderText = "Fecha";
            this.dgvcFecha.Name = "dgvcFecha";
            this.dgvcFecha.ReadOnly = true;
            // 
            // dgvcHora
            // 
            this.dgvcHora.DataPropertyName = "Hora";
            this.dgvcHora.FillWeight = 48F;
            this.dgvcHora.HeaderText = "Hora";
            this.dgvcHora.Name = "dgvcHora";
            this.dgvcHora.ReadOnly = true;
            // 
            // dgvcGlosa
            // 
            this.dgvcGlosa.DataPropertyName = "Glosa";
            this.dgvcGlosa.FillWeight = 84.08372F;
            this.dgvcGlosa.HeaderText = "Glosa";
            this.dgvcGlosa.Name = "dgvcGlosa";
            this.dgvcGlosa.ReadOnly = true;
            // 
            // dgvcEstado
            // 
            this.dgvcEstado.DataPropertyName = "Estado";
            this.dgvcEstado.FillWeight = 48F;
            this.dgvcEstado.HeaderText = "Estado";
            this.dgvcEstado.Name = "dgvcEstado";
            this.dgvcEstado.ReadOnly = true;
            // 
            // btActualizar
            // 
            this.btActualizar.Location = new System.Drawing.Point(654, 42);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(75, 23);
            this.btActualizar.TabIndex = 10;
            this.btActualizar.Text = "Actualizar";
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // FAsientosAdministrador
            // 
            this.AcceptButton = this.btBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 442);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.dgvAsientos);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.dtpAl);
            this.Controls.Add(this.chbAl);
            this.Controls.Add(this.dtpDel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.tbBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btVer);
            this.Controls.Add(this.btModificar);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btNuevo);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FAsientosAdministrador";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador de asientos contables";
            this.Load += new System.EventHandler(this.FAsientosAdministrador_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btNuevo;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.Button btVer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBuscar;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDel;
        private System.Windows.Forms.CheckBox chbAl;
        private System.Windows.Forms.DateTimePicker dtpAl;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.ToolStripStatusLabel tslbHint;
        private System.Windows.Forms.DataGridView dgvAsientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumAsiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcGlosa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcEstado;
        private System.Windows.Forms.Button btActualizar;
    }
}