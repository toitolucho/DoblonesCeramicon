namespace WFADoblones20.FormulariosContabilidad
{
    partial class FAsientosContables
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAsientos = new System.Windows.Forms.DataGridView();
            this.dgvcNumeroAsiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcGlosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbPendiente = new System.Windows.Forms.RadioButton();
            this.rbConfirmado = new System.Windows.Forms.RadioButton();
            this.btMostrar = new System.Windows.Forms.Button();
            this.btNuevo = new System.Windows.Forms.Button();
            this.btModificar = new System.Windows.Forms.Button();
            this.btVer = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.dgvAsientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcNumeroAsiento,
            this.dgvcFecha,
            this.dgvcHora,
            this.dgvcGlosa,
            this.dgvcEstado});
            this.dgvAsientos.Location = new System.Drawing.Point(0, 57);
            this.dgvAsientos.MultiSelect = false;
            this.dgvAsientos.Name = "dgvAsientos";
            this.dgvAsientos.ReadOnly = true;
            this.dgvAsientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsientos.ShowEditingIcon = false;
            this.dgvAsientos.Size = new System.Drawing.Size(792, 484);
            this.dgvAsientos.TabIndex = 7;
            this.dgvAsientos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvAsientos_MouseDoubleClick);
            this.dgvAsientos.SelectionChanged += new System.EventHandler(this.dgvAsientos_SelectionChanged);
            // 
            // dgvcNumeroAsiento
            // 
            this.dgvcNumeroAsiento.DataPropertyName = "NumeroAsiento";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.dgvcNumeroAsiento.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvcNumeroAsiento.FillWeight = 131.9332F;
            this.dgvcNumeroAsiento.HeaderText = "Nº Asiento";
            this.dgvcNumeroAsiento.MinimumWidth = 64;
            this.dgvcNumeroAsiento.Name = "dgvcNumeroAsiento";
            this.dgvcNumeroAsiento.ReadOnly = true;
            // 
            // dgvcFecha
            // 
            this.dgvcFecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.dgvcFecha.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvcFecha.FillWeight = 162.4366F;
            this.dgvcFecha.HeaderText = "Fecha";
            this.dgvcFecha.MinimumWidth = 75;
            this.dgvcFecha.Name = "dgvcFecha";
            this.dgvcFecha.ReadOnly = true;
            // 
            // dgvcHora
            // 
            this.dgvcHora.DataPropertyName = "Hora";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "T";
            dataGridViewCellStyle6.NullValue = null;
            this.dgvcHora.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvcHora.FillWeight = 68.54342F;
            this.dgvcHora.HeaderText = "Hora";
            this.dgvcHora.MinimumWidth = 75;
            this.dgvcHora.Name = "dgvcHora";
            this.dgvcHora.ReadOnly = true;
            // 
            // dgvcGlosa
            // 
            this.dgvcGlosa.DataPropertyName = "Glosa";
            this.dgvcGlosa.FillWeight = 68.54342F;
            this.dgvcGlosa.HeaderText = "Glosa";
            this.dgvcGlosa.MinimumWidth = 460;
            this.dgvcGlosa.Name = "dgvcGlosa";
            this.dgvcGlosa.ReadOnly = true;
            // 
            // dgvcEstado
            // 
            this.dgvcEstado.DataPropertyName = "Estado";
            this.dgvcEstado.FillWeight = 68.54342F;
            this.dgvcEstado.HeaderText = "Estado";
            this.dgvcEstado.MinimumWidth = 75;
            this.dgvcEstado.Name = "dgvcEstado";
            this.dgvcEstado.ReadOnly = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(215, 17);
            this.toolStripStatusLabel1.Text = "Doble clic en la fila para ver o modificar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(12, 25);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(90, 20);
            this.dtpFecha.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTodos);
            this.groupBox1.Controls.Add(this.rbPendiente);
            this.groupBox1.Controls.Add(this.rbConfirmado);
            this.groupBox1.Location = new System.Drawing.Point(108, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 42);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estado:";
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Location = new System.Drawing.Point(166, 19);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(55, 17);
            this.rbTodos.TabIndex = 2;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // rbPendiente
            // 
            this.rbPendiente.AutoSize = true;
            this.rbPendiente.Checked = true;
            this.rbPendiente.Location = new System.Drawing.Point(87, 19);
            this.rbPendiente.Name = "rbPendiente";
            this.rbPendiente.Size = new System.Drawing.Size(73, 17);
            this.rbPendiente.TabIndex = 1;
            this.rbPendiente.TabStop = true;
            this.rbPendiente.Text = "Pendiente";
            this.rbPendiente.UseVisualStyleBackColor = true;
            // 
            // rbConfirmado
            // 
            this.rbConfirmado.AutoSize = true;
            this.rbConfirmado.Location = new System.Drawing.Point(6, 19);
            this.rbConfirmado.Name = "rbConfirmado";
            this.rbConfirmado.Size = new System.Drawing.Size(75, 17);
            this.rbConfirmado.TabIndex = 0;
            this.rbConfirmado.Text = "Confimado";
            this.rbConfirmado.UseVisualStyleBackColor = true;
            // 
            // btMostrar
            // 
            this.btMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btMostrar.Location = new System.Drawing.Point(338, 22);
            this.btMostrar.Name = "btMostrar";
            this.btMostrar.Size = new System.Drawing.Size(75, 23);
            this.btMostrar.TabIndex = 2;
            this.btMostrar.Text = "Mostrar";
            this.btMostrar.UseVisualStyleBackColor = true;
            this.btMostrar.Click += new System.EventHandler(this.btMostrar_Click);
            // 
            // btNuevo
            // 
            this.btNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNuevo.Location = new System.Drawing.Point(419, 22);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(75, 23);
            this.btNuevo.TabIndex = 3;
            this.btNuevo.Text = "Nuevo";
            this.btNuevo.UseVisualStyleBackColor = true;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // btModificar
            // 
            this.btModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModificar.Location = new System.Drawing.Point(500, 22);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(75, 23);
            this.btModificar.TabIndex = 4;
            this.btModificar.Text = "Modificar";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // btVer
            // 
            this.btVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btVer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btVer.Location = new System.Drawing.Point(581, 22);
            this.btVer.Name = "btVer";
            this.btVer.Size = new System.Drawing.Size(75, 23);
            this.btVer.TabIndex = 5;
            this.btVer.Text = "Ver detalle";
            this.btVer.UseVisualStyleBackColor = true;
            this.btVer.Click += new System.EventHandler(this.btVer_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.Location = new System.Drawing.Point(662, 22);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(75, 23);
            this.btEliminar.TabIndex = 6;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // FAsientosContables
            // 
            this.AcceptButton = this.btMostrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btVer);
            this.Controls.Add(this.btModificar);
            this.Controls.Add(this.btNuevo);
            this.Controls.Add(this.btMostrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvAsientos);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FAsientosContables";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asientos contables";
            this.Load += new System.EventHandler(this.FAsientosContables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAsientos;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbPendiente;
        private System.Windows.Forms.RadioButton rbConfirmado;
        private System.Windows.Forms.Button btMostrar;
        private System.Windows.Forms.Button btNuevo;
        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.Button btVer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumeroAsiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcGlosa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcEstado;
        private System.Windows.Forms.Button btEliminar;


    }
}