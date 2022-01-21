namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FCompraProductosSeleccionActualizarPrecios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCompraProductosSeleccionActualizarPrecios));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkSeleccionarTodos = new System.Windows.Forms.CheckBox();
            this.DGVCompraProductosRecepciones = new System.Windows.Forms.DataGridView();
            this.DGCFechaRecepcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.DGVProductosRecepcionados = new System.Windows.Forms.DataGridView();
            this.DGCCodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadRecepcionada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCompraProductosRecepciones)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductosRecepcionados)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkSeleccionarTodos);
            this.groupBox3.Controls.Add(this.DGVCompraProductosRecepciones);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(650, 203);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listado de Recepciones Por Fechas";
            // 
            // checkSeleccionarTodos
            // 
            this.checkSeleccionarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkSeleccionarTodos.AutoSize = true;
            this.checkSeleccionarTodos.Location = new System.Drawing.Point(606, 65);
            this.checkSeleccionarTodos.Name = "checkSeleccionarTodos";
            this.checkSeleccionarTodos.Size = new System.Drawing.Size(15, 14);
            this.checkSeleccionarTodos.TabIndex = 2;
            this.checkSeleccionarTodos.UseVisualStyleBackColor = true;
            this.checkSeleccionarTodos.CheckedChanged += new System.EventHandler(this.checkSeleccionarTodos_CheckedChanged);
            // 
            // DGVCompraProductosRecepciones
            // 
            this.DGVCompraProductosRecepciones.AllowUserToAddRows = false;
            this.DGVCompraProductosRecepciones.AllowUserToResizeRows = false;
            this.DGVCompraProductosRecepciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCompraProductosRecepciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVCompraProductosRecepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCompraProductosRecepciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCFechaRecepcion,
            this.DGCSeleccionar});
            this.DGVCompraProductosRecepciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVCompraProductosRecepciones.Location = new System.Drawing.Point(5, 61);
            this.DGVCompraProductosRecepciones.MultiSelect = false;
            this.DGVCompraProductosRecepciones.Name = "DGVCompraProductosRecepciones";
            this.DGVCompraProductosRecepciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVCompraProductosRecepciones.Size = new System.Drawing.Size(640, 137);
            this.DGVCompraProductosRecepciones.TabIndex = 0;
            // 
            // DGCFechaRecepcion
            // 
            this.DGCFechaRecepcion.DataPropertyName = "FechaRecepcion";
            this.DGCFechaRecepcion.HeaderText = "Fecha Recepcion";
            this.DGCFechaRecepcion.Name = "DGCFechaRecepcion";
            this.DGCFechaRecepcion.ReadOnly = true;
            // 
            // DGCSeleccionar
            // 
            this.DGCSeleccionar.DataPropertyName = "Seleccionar";
            this.DGCSeleccionar.HeaderText = "Selecionar Recepcion";
            this.DGCSeleccionar.Name = "DGCSeleccionar";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(640, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccion que recepciones serán aplicadas a los Gastos que ha realizado hasta est" +
                "e moento para esta Recepción de Compra";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.splitter1);
            this.groupBox4.Controls.Add(this.DGVProductosRecepcionados);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Red;
            this.groupBox4.Location = new System.Drawing.Point(0, 203);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox4.Size = new System.Drawing.Size(650, 154);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Listado de Productos entregados en la Fecha ";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(5, 19);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(640, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // DGVProductosRecepcionados
            // 
            this.DGVProductosRecepcionados.AllowUserToAddRows = false;
            this.DGVProductosRecepcionados.AllowUserToResizeRows = false;
            this.DGVProductosRecepcionados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVProductosRecepcionados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVProductosRecepcionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProductosRecepcionados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoProducto,
            this.DGCNombreProducto,
            this.DGCCantidadRecepcionada});
            this.DGVProductosRecepcionados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVProductosRecepcionados.Location = new System.Drawing.Point(5, 19);
            this.DGVProductosRecepcionados.MultiSelect = false;
            this.DGVProductosRecepcionados.Name = "DGVProductosRecepcionados";
            this.DGVProductosRecepcionados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVProductosRecepcionados.Size = new System.Drawing.Size(640, 130);
            this.DGVProductosRecepcionados.TabIndex = 1;
            // 
            // DGCCodigoProducto
            // 
            this.DGCCodigoProducto.DataPropertyName = "CodigoProducto";
            this.DGCCodigoProducto.HeaderText = "Código";
            this.DGCCodigoProducto.Name = "DGCCodigoProducto";
            this.DGCCodigoProducto.ReadOnly = true;
            // 
            // DGCNombreProducto
            // 
            this.DGCNombreProducto.DataPropertyName = "NombreProducto";
            this.DGCNombreProducto.HeaderText = "Producto";
            this.DGCNombreProducto.Name = "DGCNombreProducto";
            this.DGCNombreProducto.ReadOnly = true;
            // 
            // DGCCantidadRecepcionada
            // 
            this.DGCCantidadRecepcionada.DataPropertyName = "CantidadEntregada";
            this.DGCCantidadRecepcionada.HeaderText = "Cant. Recepcionada";
            this.DGCCantidadRecepcionada.Name = "DGCCantidadRecepcionada";
            this.DGCCantidadRecepcionada.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel1.Controls.Add(this.btnAceptar);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 357);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(650, 47);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageKey = "Undo.ico";
            this.btnCancelar.ImageList = this.imageList2;
            this.btnCancelar.Location = new System.Drawing.Point(566, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 32);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Symbol-Check.ico");
            this.imageList2.Images.SetKeyName(1, "Undo.ico");
            // 
            // btnAceptar
            // 
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.ImageKey = "Symbol-Check.ico";
            this.btnAceptar.ImageList = this.imageList2;
            this.btnAceptar.Location = new System.Drawing.Point(485, 9);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 32);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(379, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Recepción Actual";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Bisque;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.ForeColor = System.Drawing.Color.Bisque;
            this.label3.Location = new System.Drawing.Point(343, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 12);
            this.label3.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FechaRecepcion";
            this.dataGridViewTextBoxColumn1.HeaderText = "Fecha Recepcion";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 242;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CodigoProducto";
            this.dataGridViewTextBoxColumn2.HeaderText = "Código";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 161;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NombreProducto";
            this.dataGridViewTextBoxColumn3.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 161;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CantidadEntregada";
            this.dataGridViewTextBoxColumn4.HeaderText = "Cant. Recepcionada";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 162;
            // 
            // FCompraProductosSeleccionActualizarPrecios
            // 
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(650, 404);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox3);
            this.Name = "FCompraProductosSeleccionActualizarPrecios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione las Recepciones ";
            this.Load += new System.EventHandler(this.FComprProductosSeleccionActualizarPrecios_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FComprProductosSeleccionActualizarPrecios_FormClosing);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCompraProductosRecepciones)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductosRecepcionados)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panel1;
        private System.Windows.Forms.DataGridView DGVCompraProductosRecepciones;
        private System.Windows.Forms.DataGridView DGVProductosRecepcionados;        
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList imageList1;                
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCFechaRecepcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCSeleccionar;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadRecepcionada;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.CheckBox checkSeleccionarTodos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;                       
        
    }
}