namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FTransferenciaProductosRecepcionEnvioPE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTransferenciaProductosRecepcionEnvioPE));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBoxCodEspecifico = new System.Windows.Forms.TextBox();
            this.btnIngresarSeleccionar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblCodEspecifico = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkSeleccionarTodo = new System.Windows.Forms.CheckBox();
            this.dtGVProductosEspecificos = new System.Windows.Forms.DataGridView();
            this.DGCCodigoProductoEspecifico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDatosProductos = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCantidad = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCantidadSeleccionada = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosEspecificos)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBoxCodEspecifico);
            this.groupBox1.Controls.Add(this.btnIngresarSeleccionar);
            this.groupBox1.Controls.Add(this.lblCodEspecifico);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selección de Códigos";
            // 
            // txtBoxCodEspecifico
            // 
            this.txtBoxCodEspecifico.Location = new System.Drawing.Point(133, 14);
            this.txtBoxCodEspecifico.MaxLength = 30;
            this.txtBoxCodEspecifico.Name = "txtBoxCodEspecifico";
            this.txtBoxCodEspecifico.Size = new System.Drawing.Size(201, 20);
            this.txtBoxCodEspecifico.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtBoxCodEspecifico, "Introduzca el Código Especifico que desea Seleccionar (Utilize su Lector de códig" +
                    "o de Barras)");
            this.txtBoxCodEspecifico.TextChanged += new System.EventHandler(this.txtBoxCodEspecifico_TextChanged);
            // 
            // btnIngresarSeleccionar
            // 
            this.btnIngresarSeleccionar.FlatAppearance.BorderSize = 0;
            this.btnIngresarSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresarSeleccionar.ImageIndex = 1;
            this.btnIngresarSeleccionar.ImageList = this.imageList1;
            this.btnIngresarSeleccionar.Location = new System.Drawing.Point(331, 10);
            this.btnIngresarSeleccionar.Name = "btnIngresarSeleccionar";
            this.btnIngresarSeleccionar.Size = new System.Drawing.Size(92, 29);
            this.btnIngresarSeleccionar.TabIndex = 1;
            this.btnIngresarSeleccionar.Text = "&Seleccionar";
            this.btnIngresarSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnIngresarSeleccionar, "Presione el Botón para Seleccionar el Código Introducido");
            this.btnIngresarSeleccionar.UseVisualStyleBackColor = true;
            this.btnIngresarSeleccionar.Click += new System.EventHandler(this.btnIngresarSeleccionar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Thumbs_down.ico");
            this.imageList1.Images.SetKeyName(1, "Symbol-Add.ico");
            this.imageList1.Images.SetKeyName(2, "Symbol-Check.ico");
            // 
            // lblCodEspecifico
            // 
            this.lblCodEspecifico.AutoSize = true;
            this.lblCodEspecifico.Location = new System.Drawing.Point(12, 18);
            this.lblCodEspecifico.Name = "lblCodEspecifico";
            this.lblCodEspecifico.Size = new System.Drawing.Size(115, 13);
            this.lblCodEspecifico.TabIndex = 0;
            this.lblCodEspecifico.Text = "Intr. el Cód. Específico";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkSeleccionarTodo);
            this.groupBox2.Controls.Add(this.dtGVProductosEspecificos);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(434, 311);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle de Códigos Específicos";
            // 
            // checkSeleccionarTodo
            // 
            this.checkSeleccionarTodo.AutoSize = true;
            this.checkSeleccionarTodo.Location = new System.Drawing.Point(394, 23);
            this.checkSeleccionarTodo.Name = "checkSeleccionarTodo";
            this.checkSeleccionarTodo.Size = new System.Drawing.Size(15, 14);
            this.checkSeleccionarTodo.TabIndex = 1;
            this.checkSeleccionarTodo.UseVisualStyleBackColor = true;
            this.checkSeleccionarTodo.CheckedChanged += new System.EventHandler(this.checkSeleccionarTodo_CheckedChanged);
            // 
            // dtGVProductosEspecificos
            // 
            this.dtGVProductosEspecificos.AllowUserToAddRows = false;
            this.dtGVProductosEspecificos.AllowUserToResizeRows = false;
            this.dtGVProductosEspecificos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVProductosEspecificos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.DGCCodigoProductoEspecifico,
            this.DGCSeleccionar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGVProductosEspecificos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVProductosEspecificos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVProductosEspecificos.Location = new System.Drawing.Point(5, 18);
            this.dtGVProductosEspecificos.MultiSelect = false;
            this.dtGVProductosEspecificos.Name = "dtGVProductosEspecificos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVProductosEspecificos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtGVProductosEspecificos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVProductosEspecificos.Size = new System.Drawing.Size(424, 288);
            this.dtGVProductosEspecificos.TabIndex = 0;
            this.dtGVProductosEspecificos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVProductosEspecificos_CellValueChanged);
            // 
            // DGCCodigoProductoEspecifico
            // 
            this.DGCCodigoProductoEspecifico.DataPropertyName = "CodigoProductoEspecifico";
            this.DGCCodigoProductoEspecifico.HeaderText = "Código Específico";
            this.DGCCodigoProductoEspecifico.Name = "DGCCodigoProductoEspecifico";
            this.DGCCodigoProductoEspecifico.ReadOnly = true;
            this.DGCCodigoProductoEspecifico.ToolTipText = "Código Específico del Producto";
            // 
            // DGCSeleccionar
            // 
            this.DGCSeleccionar.DataPropertyName = "Seleccionar";
            this.DGCSeleccionar.HeaderText = "Seleccionar";
            this.DGCSeleccionar.Name = "DGCSeleccionar";
            this.DGCSeleccionar.ToolTipText = "Seleccionar para su Recepción o Envío del Producto en Inventario";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblDatosProductos,
            this.toolStripStatusLabel2,
            this.lblCantidad});
            this.statusStrip1.Location = new System.Drawing.Point(0, 394);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(434, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel1.Text = "Producto : ";
            // 
            // lblDatosProductos
            // 
            this.lblDatosProductos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosProductos.Name = "lblDatosProductos";
            this.lblDatosProductos.Size = new System.Drawing.Size(13, 17);
            this.lblDatosProductos.Text = "..";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(61, 17);
            this.toolStripStatusLabel2.Text = "  Cantidad";
            // 
            // lblCantidad
            // 
            this.lblCantidad.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(14, 17);
            this.lblCantidad.Text = "0";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAceptar);
            this.flowLayoutPanel1.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel1.Controls.Add(this.lblCantidadSeleccionada);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 357);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(434, 37);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.ImageIndex = 2;
            this.btnAceptar.ImageList = this.imageList1;
            this.btnAceptar.Location = new System.Drawing.Point(356, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 29);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(271, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 29);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblCantidadSeleccionada
            // 
            this.lblCantidadSeleccionada.AutoSize = true;
            this.lblCantidadSeleccionada.Location = new System.Drawing.Point(133, 0);
            this.lblCantidadSeleccionada.Name = "lblCantidadSeleccionada";
            this.lblCantidadSeleccionada.Size = new System.Drawing.Size(132, 13);
            this.lblCantidadSeleccionada.TabIndex = 2;
            this.lblCantidadSeleccionada.Text = "Cantidad Seleccionada : 0";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoProductoEspecifico";
            this.dataGridViewTextBoxColumn1.HeaderText = "Código Específico";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Código Específico del Producto";
            this.dataGridViewTextBoxColumn1.Width = 242;
            // 
            // FTransferenciaProductosRecepcionEnvioPE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 416);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FTransferenciaProductosRecepcionEnvioPE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de Envio y Recepción de Productos Especificos";
            this.Load += new System.EventHandler(this.FTransferenciaProductosRecepcionEnvioPE_Load);
            this.Shown += new System.EventHandler(this.FTransferenciaProductosRecepcionEnvioPE_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FTransferenciaProductosRecepcionEnvioPE_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosEspecificos)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView dtGVProductosEspecificos;
        private System.Windows.Forms.ToolStripStatusLabel lblDatosProductos;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblCantidad;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtBoxCodEspecifico;
        private System.Windows.Forms.Button btnIngresarSeleccionar;
        private System.Windows.Forms.Label lblCodEspecifico;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox checkSeleccionarTodo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblCantidadSeleccionada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProductoEspecifico;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCSeleccionar;
    }
}