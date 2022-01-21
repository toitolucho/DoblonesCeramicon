namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FVentasProductosSeleccionPE
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FVentasProductosSeleccionPE));
            this.gBoxDatosEntrada = new System.Windows.Forms.GroupBox();
            this.gBoxDetalleCodigosEspecificos = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxCodigoEspcifico = new System.Windows.Forms.TextBox();
            this.lblDatosProductos = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSeleccionarAleatorio = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dtGVProductosEspecificos = new System.Windows.Forms.DataGridView();
            this.DGCCodigoProductoEspecifico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.checkSeleccionarTodo = new System.Windows.Forms.CheckBox();
            this.imageProductosEspecificos = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gBoxDatosEntrada.SuspendLayout();
            this.gBoxDetalleCodigosEspecificos.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosEspecificos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxDatosEntrada
            // 
            this.gBoxDatosEntrada.Controls.Add(this.checkSeleccionarTodo);
            this.gBoxDatosEntrada.Controls.Add(this.btnAgregar);
            this.gBoxDatosEntrada.Controls.Add(this.lblDatosProductos);
            this.gBoxDatosEntrada.Controls.Add(this.txtBoxCodigoEspcifico);
            this.gBoxDatosEntrada.Controls.Add(this.label1);
            this.gBoxDatosEntrada.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxDatosEntrada.Location = new System.Drawing.Point(0, 0);
            this.gBoxDatosEntrada.Name = "gBoxDatosEntrada";
            this.gBoxDatosEntrada.Size = new System.Drawing.Size(431, 62);
            this.gBoxDatosEntrada.TabIndex = 0;
            this.gBoxDatosEntrada.TabStop = false;
            this.gBoxDatosEntrada.Text = "Ingrese el Código";
            // 
            // gBoxDetalleCodigosEspecificos
            // 
            this.gBoxDetalleCodigosEspecificos.Controls.Add(this.dtGVProductosEspecificos);
            this.gBoxDetalleCodigosEspecificos.Controls.Add(this.lblCantidad);
            this.gBoxDetalleCodigosEspecificos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxDetalleCodigosEspecificos.Location = new System.Drawing.Point(0, 62);
            this.gBoxDetalleCodigosEspecificos.Name = "gBoxDetalleCodigosEspecificos";
            this.gBoxDetalleCodigosEspecificos.Size = new System.Drawing.Size(431, 249);
            this.gBoxDetalleCodigosEspecificos.TabIndex = 1;
            this.gBoxDetalleCodigosEspecificos.TabStop = false;
            this.gBoxDetalleCodigosEspecificos.Text = "Listado de Códigos Disponibles";
            this.gBoxDetalleCodigosEspecificos.Enter += new System.EventHandler(this.gBoxDetalleCodigosEspecificos_Enter);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel1.Controls.Add(this.btnSeleccionarAleatorio);
            this.flowLayoutPanel1.Controls.Add(this.btnAceptar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 311);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(431, 39);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo Especifico :";
            // 
            // txtBoxCodigoEspcifico
            // 
            this.txtBoxCodigoEspcifico.Location = new System.Drawing.Point(118, 20);
            this.txtBoxCodigoEspcifico.Name = "txtBoxCodigoEspcifico";
            this.txtBoxCodigoEspcifico.Size = new System.Drawing.Size(226, 20);
            this.txtBoxCodigoEspcifico.TabIndex = 1;
            // 
            // lblDatosProductos
            // 
            this.lblDatosProductos.AutoSize = true;
            this.lblDatosProductos.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosProductos.Location = new System.Drawing.Point(6, 44);
            this.lblDatosProductos.Name = "lblDatosProductos";
            this.lblDatosProductos.Size = new System.Drawing.Size(86, 12);
            this.lblDatosProductos.TabIndex = 2;
            this.lblDatosProductos.Text = "Datos Productos";
            // 
            // btnAgregar
            // 
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.ImageKey = "Rename.ico";
            this.btnAgregar.ImageList = this.imageProductosEspecificos;
            this.btnAgregar.Location = new System.Drawing.Point(350, 15);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 29);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(3, 233);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(233, 13);
            this.lblCantidad.TabIndex = 0;
            this.lblCantidad.Text = "Cant a Entrega 0, Cant. Seleccionada 0";
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.ImageKey = "Symbol-Check.ico";
            this.btnAceptar.ImageList = this.imageProductosEspecificos;
            this.btnAceptar.Location = new System.Drawing.Point(178, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 29);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnSeleccionarAleatorio
            // 
            this.btnSeleccionarAleatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarAleatorio.ImageKey = "Defragmentation.ico";
            this.btnSeleccionarAleatorio.ImageList = this.imageProductosEspecificos;
            this.btnSeleccionarAleatorio.Location = new System.Drawing.Point(259, 3);
            this.btnSeleccionarAleatorio.Name = "btnSeleccionarAleatorio";
            this.btnSeleccionarAleatorio.Size = new System.Drawing.Size(88, 29);
            this.btnSeleccionarAleatorio.TabIndex = 1;
            this.btnSeleccionarAleatorio.Text = "&Seleccionar";
            this.btnSeleccionarAleatorio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionarAleatorio.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageKey = "Undo.ico";
            this.btnCancelar.ImageList = this.imageProductosEspecificos;
            this.btnCancelar.Location = new System.Drawing.Point(353, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 29);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // dtGVProductosEspecificos
            // 
            this.dtGVProductosEspecificos.AllowUserToAddRows = false;
            this.dtGVProductosEspecificos.AllowUserToDeleteRows = false;
            this.dtGVProductosEspecificos.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVProductosEspecificos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVProductosEspecificos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVProductosEspecificos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoProductoEspecifico,
            this.DGCSeleccionar});
            this.dtGVProductosEspecificos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVProductosEspecificos.Location = new System.Drawing.Point(3, 16);
            this.dtGVProductosEspecificos.MultiSelect = false;
            this.dtGVProductosEspecificos.Name = "dtGVProductosEspecificos";
            this.dtGVProductosEspecificos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVProductosEspecificos.Size = new System.Drawing.Size(425, 217);
            this.dtGVProductosEspecificos.TabIndex = 1;
            // 
            // DGCCodigoProductoEspecifico
            // 
            this.DGCCodigoProductoEspecifico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCCodigoProductoEspecifico.DataPropertyName = "CodigoProductoEspecifico";
            this.DGCCodigoProductoEspecifico.HeaderText = "Cod Específico";
            this.DGCCodigoProductoEspecifico.Name = "DGCCodigoProductoEspecifico";
            this.DGCCodigoProductoEspecifico.ReadOnly = true;
            this.DGCCodigoProductoEspecifico.ToolTipText = "Número Serial o Codigo Unico del Producto";
            // 
            // DGCSeleccionar
            // 
            this.DGCSeleccionar.DataPropertyName = "Seleccionar";
            this.DGCSeleccionar.HeaderText = "Seleccionar?";
            this.DGCSeleccionar.Name = "DGCSeleccionar";
            this.DGCSeleccionar.ToolTipText = "Seleccionar el Código";
            // 
            // checkSeleccionarTodo
            // 
            this.checkSeleccionarTodo.AutoSize = true;
            this.checkSeleccionarTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkSeleccionarTodo.Location = new System.Drawing.Point(326, 44);
            this.checkSeleccionarTodo.Name = "checkSeleccionarTodo";
            this.checkSeleccionarTodo.Size = new System.Drawing.Size(105, 17);
            this.checkSeleccionarTodo.TabIndex = 9;
            this.checkSeleccionarTodo.Text = "Forzar &Selección";
            this.checkSeleccionarTodo.UseVisualStyleBackColor = true;
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FVentasProductosSeleccionPE
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(431, 350);
            this.Controls.Add(this.gBoxDetalleCodigosEspecificos);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gBoxDatosEntrada);
            this.Name = "FVentasProductosSeleccionPE";
            this.Text = "Seleccione los Codigos Especificos";
            this.Load += new System.EventHandler(this.FVentasProductosSeleccionPE_Load);
            this.gBoxDatosEntrada.ResumeLayout(false);
            this.gBoxDatosEntrada.PerformLayout();
            this.gBoxDetalleCodigosEspecificos.ResumeLayout(false);
            this.gBoxDetalleCodigosEspecificos.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosEspecificos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxDatosEntrada;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblDatosProductos;
        private System.Windows.Forms.TextBox txtBoxCodigoEspcifico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gBoxDetalleCodigosEspecificos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSeleccionarAleatorio;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dtGVProductosEspecificos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProductoEspecifico;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCSeleccionar;
        private System.Windows.Forms.CheckBox checkSeleccionarTodo;
        private System.Windows.Forms.ImageList imageProductosEspecificos;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}