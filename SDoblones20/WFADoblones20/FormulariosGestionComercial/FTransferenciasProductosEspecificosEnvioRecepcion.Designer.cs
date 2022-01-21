namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FTransferenciasProductosEspecificosEnvioRecepcion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTransferenciasProductosEspecificosEnvioRecepcion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.imageProductosEspecificos = new System.Windows.Forms.ImageList(this.components);
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCompletar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dtGVProductosEspecificos = new System.Windows.Forms.DataGridView();
            this.DGCCodigoEspecifico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gBoxDatos = new System.Windows.Forms.GroupBox();
            this.checkForzarSeleccion = new System.Windows.Forms.CheckBox();
            this.btnAnadir = new System.Windows.Forms.Button();
            this.txtCodigoEspecifico = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosEspecificos)).BeginInit();
            this.gBoxDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnConfirmar);
            this.pnlBotones.Controls.Add(this.btnCompletar);
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotones.Location = new System.Drawing.Point(0, 320);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(422, 41);
            this.pnlBotones.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageKey = "Undo.ico";
            this.btnCancelar.ImageList = this.imageProductosEspecificos;
            this.btnCancelar.Location = new System.Drawing.Point(344, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 32);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // imageProductosEspecificos
            // 
            this.imageProductosEspecificos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageProductosEspecificos.ImageStream")));
            this.imageProductosEspecificos.TransparentColor = System.Drawing.Color.Transparent;
            this.imageProductosEspecificos.Images.SetKeyName(0, "Defragmentation.ico");
            this.imageProductosEspecificos.Images.SetKeyName(1, "Rename.ico");
            this.imageProductosEspecificos.Images.SetKeyName(2, "Symbol-Add.ico");
            this.imageProductosEspecificos.Images.SetKeyName(3, "Symbol-Check.ico");
            this.imageProductosEspecificos.Images.SetKeyName(4, "Symbol-Delete.ico");
            this.imageProductosEspecificos.Images.SetKeyName(5, "Symbol-Refresh.ico");
            this.imageProductosEspecificos.Images.SetKeyName(6, "Undo.ico");
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.ImageKey = "Symbol-Check.ico";
            this.btnConfirmar.ImageList = this.imageProductosEspecificos;
            this.btnConfirmar.Location = new System.Drawing.Point(263, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 32);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "&Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCompletar
            // 
            this.btnCompletar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompletar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompletar.ImageKey = "Defragmentation.ico";
            this.btnCompletar.ImageList = this.imageProductosEspecificos;
            this.btnCompletar.Location = new System.Drawing.Point(182, 3);
            this.btnCompletar.Name = "btnCompletar";
            this.btnCompletar.Size = new System.Drawing.Size(75, 32);
            this.btnCompletar.TabIndex = 5;
            this.btnCompletar.Text = "&Generar";
            this.btnCompletar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCompletar.UseVisualStyleBackColor = true;
            this.btnCompletar.Click += new System.EventHandler(this.btnCompletar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.ImageKey = "Symbol-Delete.ico";
            this.btnEliminar.ImageList = this.imageProductosEspecificos;
            this.btnEliminar.Location = new System.Drawing.Point(101, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 32);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dtGVProductosEspecificos
            // 
            this.dtGVProductosEspecificos.AllowUserToAddRows = false;
            this.dtGVProductosEspecificos.AllowUserToResizeRows = false;
            this.dtGVProductosEspecificos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVProductosEspecificos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVProductosEspecificos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVProductosEspecificos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoEspecifico,
            this.DGCSeleccionar});
            this.dtGVProductosEspecificos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVProductosEspecificos.Location = new System.Drawing.Point(0, 62);
            this.dtGVProductosEspecificos.MultiSelect = false;
            this.dtGVProductosEspecificos.Name = "dtGVProductosEspecificos";
            this.dtGVProductosEspecificos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVProductosEspecificos.Size = new System.Drawing.Size(422, 258);
            this.dtGVProductosEspecificos.TabIndex = 2;
            // 
            // DGCCodigoEspecifico
            // 
            this.DGCCodigoEspecifico.DataPropertyName = "CodigoProductoEspecifico";
            this.DGCCodigoEspecifico.HeaderText = "Cod Especifico";
            this.DGCCodigoEspecifico.Name = "DGCCodigoEspecifico";
            this.DGCCodigoEspecifico.ReadOnly = true;
            this.DGCCodigoEspecifico.ToolTipText = "Codigo Especifico del Producto";
            // 
            // DGCSeleccionar
            // 
            this.DGCSeleccionar.DataPropertyName = "Entregado";
            this.DGCSeleccionar.HeaderText = "Recepcionado?";
            this.DGCSeleccionar.Name = "DGCSeleccionar";
            // 
            // gBoxDatos
            // 
            this.gBoxDatos.Controls.Add(this.checkForzarSeleccion);
            this.gBoxDatos.Controls.Add(this.btnAnadir);
            this.gBoxDatos.Controls.Add(this.txtCodigoEspecifico);
            this.gBoxDatos.Controls.Add(this.label1);
            this.gBoxDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxDatos.Location = new System.Drawing.Point(0, 0);
            this.gBoxDatos.Name = "gBoxDatos";
            this.gBoxDatos.Size = new System.Drawing.Size(422, 62);
            this.gBoxDatos.TabIndex = 3;
            this.gBoxDatos.TabStop = false;
            this.gBoxDatos.Text = "Ingrese los Códigos";
            // 
            // checkForzarSeleccion
            // 
            this.checkForzarSeleccion.AutoSize = true;
            this.checkForzarSeleccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkForzarSeleccion.Location = new System.Drawing.Point(317, 42);
            this.checkForzarSeleccion.Name = "checkForzarSeleccion";
            this.checkForzarSeleccion.Size = new System.Drawing.Size(105, 17);
            this.checkForzarSeleccion.TabIndex = 8;
            this.checkForzarSeleccion.Text = "Forzar &Selección";
            this.checkForzarSeleccion.UseVisualStyleBackColor = true;
            this.checkForzarSeleccion.CheckedChanged += new System.EventHandler(this.checkForzarSeleccion_CheckedChanged);
            // 
            // btnAnadir
            // 
            this.btnAnadir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnadir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnadir.ImageKey = "Rename.ico";
            this.btnAnadir.ImageList = this.imageProductosEspecificos;
            this.btnAnadir.Location = new System.Drawing.Point(352, 10);
            this.btnAnadir.Name = "btnAnadir";
            this.btnAnadir.Size = new System.Drawing.Size(64, 32);
            this.btnAnadir.TabIndex = 7;
            this.btnAnadir.Text = "&Agregar";
            this.btnAnadir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnadir.UseVisualStyleBackColor = true;
            this.btnAnadir.Click += new System.EventHandler(this.btnAnadir_Click);
            // 
            // txtCodigoEspecifico
            // 
            this.txtCodigoEspecifico.Location = new System.Drawing.Point(121, 16);
            this.txtCodigoEspecifico.Name = "txtCodigoEspecifico";
            this.txtCodigoEspecifico.Size = new System.Drawing.Size(225, 20);
            this.txtCodigoEspecifico.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código Específico : ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoProductoEspecifico";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cod Especifico";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Codigo Especifico del Producto";
            this.dataGridViewTextBoxColumn1.Width = 190;
            // 
            // FTransferenciasProductosEspecificosEnvioRecepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(422, 361);
            this.Controls.Add(this.dtGVProductosEspecificos);
            this.Controls.Add(this.gBoxDatos);
            this.Controls.Add(this.pnlBotones);
            this.Name = "FTransferenciasProductosEspecificosEnvioRecepcion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Códigos Productos Especificos para Transferencias";
            this.Load += new System.EventHandler(this.FTransferenciasProductosEspecificosEnvioRecepcion_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FTransferenciasProductosEspecificosEnvioRecepcion_FormClosing);
            this.pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosEspecificos)).EndInit();
            this.gBoxDatos.ResumeLayout(false);
            this.gBoxDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlBotones;
        private System.Windows.Forms.DataGridView dtGVProductosEspecificos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList imageProductosEspecificos;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCompletar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox gBoxDatos;
        private System.Windows.Forms.TextBox txtCodigoEspecifico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnadir;
        private System.Windows.Forms.CheckBox checkForzarSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoEspecifico;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}