namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FTransferenciasProductosSeleccionFechasEnvios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTransferenciasProductosSeleccionFechasEnvios));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtGVTransferenciasFechasEnvios = new System.Windows.Forms.DataGridView();
            this.DGCFechaHoraEnvioRecepcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.checkSeleccionarTodos = new System.Windows.Forms.CheckBox();
            this.pnlBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVTransferenciasFechasEnvios)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtGVTransferenciasFechasEnvios);
            this.groupBox1.Controls.Add(this.checkSeleccionarTodos);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione un Envio";
            // 
            // dtGVTransferenciasFechasEnvios
            // 
            this.dtGVTransferenciasFechasEnvios.AllowUserToAddRows = false;
            this.dtGVTransferenciasFechasEnvios.AllowUserToResizeRows = false;
            this.dtGVTransferenciasFechasEnvios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVTransferenciasFechasEnvios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVTransferenciasFechasEnvios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVTransferenciasFechasEnvios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCFechaHoraEnvioRecepcion,
            this.DGCSeleccionar});
            this.dtGVTransferenciasFechasEnvios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVTransferenciasFechasEnvios.Location = new System.Drawing.Point(3, 33);
            this.dtGVTransferenciasFechasEnvios.Name = "dtGVTransferenciasFechasEnvios";
            this.dtGVTransferenciasFechasEnvios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVTransferenciasFechasEnvios.Size = new System.Drawing.Size(404, 184);
            this.dtGVTransferenciasFechasEnvios.TabIndex = 0;
            this.dtGVTransferenciasFechasEnvios.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVTransferenciasFechasEnvios_CellValueChanged);
            // 
            // DGCFechaHoraEnvioRecepcion
            // 
            this.DGCFechaHoraEnvioRecepcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCFechaHoraEnvioRecepcion.DataPropertyName = "FechaEnvio";
            this.DGCFechaHoraEnvioRecepcion.HeaderText = "Fecha Envio";
            this.DGCFechaHoraEnvioRecepcion.Name = "DGCFechaHoraEnvioRecepcion";
            this.DGCFechaHoraEnvioRecepcion.ReadOnly = true;
            this.DGCFechaHoraEnvioRecepcion.ToolTipText = "Fecha en la que se Realizó el Envio parcial de una Transferencia";
            // 
            // DGCSeleccionar
            // 
            this.DGCSeleccionar.DataPropertyName = "Seleccionar";
            this.DGCSeleccionar.HeaderText = "Seleccionar?";
            this.DGCSeleccionar.Name = "DGCSeleccionar";
            this.DGCSeleccionar.ToolTipText = "Seleccione un Envio";
            // 
            // checkSeleccionarTodos
            // 
            this.checkSeleccionarTodos.AutoSize = true;
            this.checkSeleccionarTodos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkSeleccionarTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkSeleccionarTodos.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkSeleccionarTodos.Location = new System.Drawing.Point(3, 16);
            this.checkSeleccionarTodos.Name = "checkSeleccionarTodos";
            this.checkSeleccionarTodos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkSeleccionarTodos.Size = new System.Drawing.Size(404, 17);
            this.checkSeleccionarTodos.TabIndex = 1;
            this.checkSeleccionarTodos.Text = "&Recepcionar Todo";
            this.checkSeleccionarTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkSeleccionarTodos.UseVisualStyleBackColor = true;
            this.checkSeleccionarTodos.CheckedChanged += new System.EventHandler(this.checkSeleccionarTodos_CheckedChanged);
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnConfirmar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotones.Location = new System.Drawing.Point(0, 220);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(410, 42);
            this.pnlBotones.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 1;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(332, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 29);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar la Operación Actual");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Symbol-Check.ico");
            this.imageList1.Images.SetKeyName(1, "Undo.ico");
            this.imageList1.Images.SetKeyName(2, "Symbol-Exclamation.ico");
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.ImageKey = "Symbol-Check.ico";
            this.btnConfirmar.ImageList = this.imageList1;
            this.btnConfirmar.Location = new System.Drawing.Point(251, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 29);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "&Aceptar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnConfirmar, "Confirmar la Seleccion");
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FechaHoraEnvioRecepcion";
            this.dataGridViewTextBoxColumn1.HeaderText = "Fecha Envio";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Fecha en la que se Realizó el Envio parcial de una Transferencia";
            // 
            // FTransferenciasProductosSeleccionFechasEnivos
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(410, 262);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlBotones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FTransferenciasProductosSeleccionFechasEnivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de Envios a Recepcionar";
            this.Load += new System.EventHandler(this.FTransferenciasProductosSeleccionFechasEnivos_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FTransferenciasProductosSeleccionFechasEnivos_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVTransferenciasFechasEnvios)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtGVTransferenciasFechasEnvios;
        private System.Windows.Forms.CheckBox checkSeleccionarTodos;
        private System.Windows.Forms.FlowLayoutPanel pnlBotones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCFechaHoraEnvioRecepcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}