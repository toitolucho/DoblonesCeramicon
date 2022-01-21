namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FCompraProductosRecepcionInventarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCompraProductosRecepcionInventarios));
            this.gBoxProductosDetalle = new System.Windows.Forms.GroupBox();
            this.dtGVProductos = new System.Windows.Forms.DataGridView();
            this.DGCCodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadRecepcionada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadFaltante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNuevaCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCEsProductoEspecifico = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gBoxProductosEspecificos = new System.Windows.Forms.GroupBox();
            this.dtGVProductosEspecificos = new System.Windows.Forms.DataGridView();
            this.DGCNombreProductoPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoProductoPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoProductoEspecifico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCTiempoGarantiaPE = new WFADoblones20.Utilitarios.DataGridViewNumericUpDownColumn();
            this.DGCFechaHoraVencimientoPE = new WFADoblones20.Utilitarios.DataGridViewCalendarColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConfirmarTodo = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnForzarFinalizacion = new System.Windows.Forms.Button();
            this.btnConfirmarParcialmente = new System.Windows.Forms.Button();
            this.gBoxTipoCalculoInventario = new System.Windows.Forms.GroupBox();
            this.rbtnTablas = new System.Windows.Forms.RadioButton();
            this.rBtnGastosProrrateados = new System.Windows.Forms.RadioButton();
            this.rBtnPersonalizado = new System.Windows.Forms.RadioButton();
            this.checkImprimirReporte = new System.Windows.Forms.CheckBox();
            this.checkExistenGastos = new System.Windows.Forms.CheckBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewNumericUpDownColumn1 = new WFADoblones20.Utilitarios.DataGridViewNumericUpDownColumn();
            this.dataGridViewCalendarColumn1 = new WFADoblones20.Utilitarios.DataGridViewCalendarColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBoxProductosDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductos)).BeginInit();
            this.gBoxProductosEspecificos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosEspecificos)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.gBoxTipoCalculoInventario.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxProductosDetalle
            // 
            this.gBoxProductosDetalle.Controls.Add(this.dtGVProductos);
            this.gBoxProductosDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxProductosDetalle.Location = new System.Drawing.Point(5, 5);
            this.gBoxProductosDetalle.Name = "gBoxProductosDetalle";
            this.gBoxProductosDetalle.Size = new System.Drawing.Size(760, 271);
            this.gBoxProductosDetalle.TabIndex = 0;
            this.gBoxProductosDetalle.TabStop = false;
            this.gBoxProductosDetalle.Text = "Productos a Ser Entregados";
            // 
            // dtGVProductos
            // 
            this.dtGVProductos.AllowUserToAddRows = false;
            this.dtGVProductos.AllowUserToResizeRows = false;
            this.dtGVProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dtGVProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoProducto,
            this.DGCNombreProducto,
            this.DGCCantidadCompra,
            this.DGCCantidadRecepcionada,
            this.DGCCantidadFaltante,
            this.DGCNuevaCantidad,
            this.DGCEsProductoEspecifico});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGVProductos.DefaultCellStyle = dataGridViewCellStyle20;
            this.dtGVProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVProductos.Location = new System.Drawing.Point(3, 16);
            this.dtGVProductos.Name = "dtGVProductos";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dtGVProductos.Size = new System.Drawing.Size(754, 252);
            this.dtGVProductos.TabIndex = 0;
            this.dtGVProductos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVProductos_CellValueChanged);
            this.dtGVProductos.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtGVProductos_CellValidating);
            this.dtGVProductos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtGVProductos_DataError);
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
            // DGCCantidadCompra
            // 
            this.DGCCantidadCompra.DataPropertyName = "CantidadCompra";
            this.DGCCantidadCompra.HeaderText = "Cant. Comprada";
            this.DGCCantidadCompra.Name = "DGCCantidadCompra";
            this.DGCCantidadCompra.ReadOnly = true;
            // 
            // DGCCantidadRecepcionada
            // 
            this.DGCCantidadRecepcionada.DataPropertyName = "CantidadRecepcionada";
            this.DGCCantidadRecepcionada.HeaderText = "Cant. Recepcionada";
            this.DGCCantidadRecepcionada.Name = "DGCCantidadRecepcionada";
            this.DGCCantidadRecepcionada.ReadOnly = true;
            // 
            // DGCCantidadFaltante
            // 
            this.DGCCantidadFaltante.DataPropertyName = "CantidadFaltante";
            this.DGCCantidadFaltante.HeaderText = "Cant. Faltante";
            this.DGCCantidadFaltante.Name = "DGCCantidadFaltante";
            this.DGCCantidadFaltante.ReadOnly = true;
            // 
            // DGCNuevaCantidad
            // 
            this.DGCNuevaCantidad.DataPropertyName = "NuevaCantidad";
            this.DGCNuevaCantidad.HeaderText = "Nueva Cantidad";
            this.DGCNuevaCantidad.Name = "DGCNuevaCantidad";
            // 
            // DGCEsProductoEspecifico
            // 
            this.DGCEsProductoEspecifico.DataPropertyName = "EsProductoEspecifico";
            this.DGCEsProductoEspecifico.HeaderText = "Prod. Especifico";
            this.DGCEsProductoEspecifico.Name = "DGCEsProductoEspecifico";
            this.DGCEsProductoEspecifico.ReadOnly = true;
            // 
            // gBoxProductosEspecificos
            // 
            this.gBoxProductosEspecificos.Controls.Add(this.dtGVProductosEspecificos);
            this.gBoxProductosEspecificos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gBoxProductosEspecificos.Location = new System.Drawing.Point(5, 276);
            this.gBoxProductosEspecificos.Name = "gBoxProductosEspecificos";
            this.gBoxProductosEspecificos.Size = new System.Drawing.Size(760, 208);
            this.gBoxProductosEspecificos.TabIndex = 1;
            this.gBoxProductosEspecificos.TabStop = false;
            this.gBoxProductosEspecificos.Text = "Detalle de Códigos Especificos";
            // 
            // dtGVProductosEspecificos
            // 
            this.dtGVProductosEspecificos.AllowUserToAddRows = false;
            this.dtGVProductosEspecificos.AllowUserToResizeRows = false;
            this.dtGVProductosEspecificos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVProductosEspecificos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dtGVProductosEspecificos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVProductosEspecificos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCNombreProductoPE,
            this.DGCCodigoProductoPE,
            this.DGCCodigoProductoEspecifico,
            this.DGCTiempoGarantiaPE,
            this.DGCFechaHoraVencimientoPE});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGVProductosEspecificos.DefaultCellStyle = dataGridViewCellStyle23;
            this.dtGVProductosEspecificos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVProductosEspecificos.Location = new System.Drawing.Point(3, 16);
            this.dtGVProductosEspecificos.Name = "dtGVProductosEspecificos";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVProductosEspecificos.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dtGVProductosEspecificos.RowHeadersVisible = false;
            this.dtGVProductosEspecificos.Size = new System.Drawing.Size(754, 189);
            this.dtGVProductosEspecificos.TabIndex = 0;
            this.dtGVProductosEspecificos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtGVProductosEspecificos_CellFormatting);
            // 
            // DGCNombreProductoPE
            // 
            this.DGCNombreProductoPE.HeaderText = "Producto";
            this.DGCNombreProductoPE.Name = "DGCNombreProductoPE";
            this.DGCNombreProductoPE.ReadOnly = true;
            this.DGCNombreProductoPE.ToolTipText = "Nombre o Descripción del Producto";
            // 
            // DGCCodigoProductoPE
            // 
            this.DGCCodigoProductoPE.HeaderText = "Código";
            this.DGCCodigoProductoPE.Name = "DGCCodigoProductoPE";
            this.DGCCodigoProductoPE.ReadOnly = true;
            this.DGCCodigoProductoPE.ToolTipText = "Código Identificador del Producto";
            // 
            // DGCCodigoProductoEspecifico
            // 
            this.DGCCodigoProductoEspecifico.HeaderText = "Código Especifico";
            this.DGCCodigoProductoEspecifico.Name = "DGCCodigoProductoEspecifico";
            this.DGCCodigoProductoEspecifico.ReadOnly = true;
            this.DGCCodigoProductoEspecifico.ToolTipText = "Código ünico y Especifico de cada Producto";
            // 
            // DGCTiempoGarantiaPE
            // 
            this.DGCTiempoGarantiaPE.HeaderText = "Tiempo Garantía";
            this.DGCTiempoGarantiaPE.Name = "DGCTiempoGarantiaPE";
            this.DGCTiempoGarantiaPE.ToolTipText = "Tiempo de Garantía en meses";
            // 
            // DGCFechaHoraVencimientoPE
            // 
            this.DGCFechaHoraVencimientoPE.HeaderText = "Fecha Vencimiento";
            this.DGCFechaHoraVencimientoPE.Name = "DGCFechaHoraVencimientoPE";
            this.DGCFechaHoraVencimientoPE.ToolTipText = "Fecha de Vencimiento del Producto";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnConfirmarTodo);
            this.flowLayoutPanel1.Controls.Add(this.btnForzarFinalizacion);
            this.flowLayoutPanel1.Controls.Add(this.btnConfirmarParcialmente);
            this.flowLayoutPanel1.Controls.Add(this.gBoxTipoCalculoInventario);
            this.flowLayoutPanel1.Controls.Add(this.checkImprimirReporte);
            this.flowLayoutPanel1.Controls.Add(this.checkExistenGastos);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 484);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(760, 44);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnConfirmarTodo
            // 
            this.btnConfirmarTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmarTodo.ImageIndex = 3;
            this.btnConfirmarTodo.ImageList = this.imageList1;
            this.btnConfirmarTodo.Location = new System.Drawing.Point(625, 3);
            this.btnConfirmarTodo.Name = "btnConfirmarTodo";
            this.btnConfirmarTodo.Size = new System.Drawing.Size(132, 32);
            this.btnConfirmarTodo.TabIndex = 1;
            this.btnConfirmarTodo.Text = "Confirmación &Total";
            this.btnConfirmarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmarTodo.UseVisualStyleBackColor = true;
            this.btnConfirmarTodo.Click += new System.EventHandler(this.btnConfirmarTodo_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Shopping cart.ico");
            this.imageList1.Images.SetKeyName(1, "Shopping_cart.ico");
            this.imageList1.Images.SetKeyName(2, "001_shoppingcart_empty.ico");
            this.imageList1.Images.SetKeyName(3, "001_shoppingcart_full.ico");
            this.imageList1.Images.SetKeyName(4, "Symbol-Exclamation.ico");
            // 
            // btnForzarFinalizacion
            // 
            this.btnForzarFinalizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnForzarFinalizacion.ImageKey = "Symbol-Exclamation.ico";
            this.btnForzarFinalizacion.ImageList = this.imageList1;
            this.btnForzarFinalizacion.Location = new System.Drawing.Point(495, 3);
            this.btnForzarFinalizacion.Name = "btnForzarFinalizacion";
            this.btnForzarFinalizacion.Size = new System.Drawing.Size(124, 32);
            this.btnForzarFinalizacion.TabIndex = 6;
            this.btnForzarFinalizacion.Text = "Forzar Finalización";
            this.btnForzarFinalizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnForzarFinalizacion.UseVisualStyleBackColor = true;
            this.btnForzarFinalizacion.Click += new System.EventHandler(this.btnConfirmarTodo_Click);
            // 
            // btnConfirmarParcialmente
            // 
            this.btnConfirmarParcialmente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarParcialmente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmarParcialmente.ImageIndex = 2;
            this.btnConfirmarParcialmente.ImageList = this.imageList1;
            this.btnConfirmarParcialmente.Location = new System.Drawing.Point(348, 3);
            this.btnConfirmarParcialmente.Name = "btnConfirmarParcialmente";
            this.btnConfirmarParcialmente.Size = new System.Drawing.Size(141, 32);
            this.btnConfirmarParcialmente.TabIndex = 2;
            this.btnConfirmarParcialmente.Text = "Confirmación &Parcial";
            this.btnConfirmarParcialmente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmarParcialmente.UseVisualStyleBackColor = true;
            this.btnConfirmarParcialmente.Click += new System.EventHandler(this.btnConfirmarTodo_Click);
            // 
            // gBoxTipoCalculoInventario
            // 
            this.gBoxTipoCalculoInventario.Controls.Add(this.rbtnTablas);
            this.gBoxTipoCalculoInventario.Controls.Add(this.rBtnGastosProrrateados);
            this.gBoxTipoCalculoInventario.Controls.Add(this.rBtnPersonalizado);
            this.gBoxTipoCalculoInventario.Location = new System.Drawing.Point(91, 3);
            this.gBoxTipoCalculoInventario.Name = "gBoxTipoCalculoInventario";
            this.gBoxTipoCalculoInventario.Size = new System.Drawing.Size(251, 38);
            this.gBoxTipoCalculoInventario.TabIndex = 3;
            this.gBoxTipoCalculoInventario.TabStop = false;
            this.gBoxTipoCalculoInventario.Text = "Tipo de Calculo de Actualización de Precios";
            // 
            // rbtnTablas
            // 
            this.rbtnTablas.AutoSize = true;
            this.rbtnTablas.Location = new System.Drawing.Point(184, 14);
            this.rbtnTablas.Name = "rbtnTablas";
            this.rbtnTablas.Size = new System.Drawing.Size(57, 17);
            this.rbtnTablas.TabIndex = 2;
            this.rbtnTablas.Text = "&Tablas";
            this.rbtnTablas.UseVisualStyleBackColor = true;
            // 
            // rBtnGastosProrrateados
            // 
            this.rBtnGastosProrrateados.AutoSize = true;
            this.rBtnGastosProrrateados.Checked = true;
            this.rBtnGastosProrrateados.Location = new System.Drawing.Point(9, 14);
            this.rBtnGastosProrrateados.Name = "rBtnGastosProrrateados";
            this.rBtnGastosProrrateados.Size = new System.Drawing.Size(68, 17);
            this.rBtnGastosProrrateados.TabIndex = 1;
            this.rBtnGastosProrrateados.TabStop = true;
            this.rBtnGastosProrrateados.Text = "P&rorrateo";
            this.rBtnGastosProrrateados.UseVisualStyleBackColor = true;
            // 
            // rBtnPersonalizado
            // 
            this.rBtnPersonalizado.AutoSize = true;
            this.rBtnPersonalizado.Location = new System.Drawing.Point(85, 14);
            this.rBtnPersonalizado.Name = "rBtnPersonalizado";
            this.rBtnPersonalizado.Size = new System.Drawing.Size(91, 17);
            this.rBtnPersonalizado.TabIndex = 0;
            this.rBtnPersonalizado.Text = "&Personalizado";
            this.rBtnPersonalizado.UseVisualStyleBackColor = true;
            // 
            // checkImprimirReporte
            // 
            this.checkImprimirReporte.AutoSize = true;
            this.checkImprimirReporte.Checked = true;
            this.checkImprimirReporte.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkImprimirReporte.Location = new System.Drawing.Point(649, 47);
            this.checkImprimirReporte.Name = "checkImprimirReporte";
            this.checkImprimirReporte.Size = new System.Drawing.Size(108, 17);
            this.checkImprimirReporte.TabIndex = 4;
            this.checkImprimirReporte.Text = "Imprimir Reporte?";
            this.checkImprimirReporte.UseVisualStyleBackColor = true;
            // 
            // checkExistenGastos
            // 
            this.checkExistenGastos.AutoSize = true;
            this.checkExistenGastos.Enabled = false;
            this.checkExistenGastos.Location = new System.Drawing.Point(541, 47);
            this.checkExistenGastos.Name = "checkExistenGastos";
            this.checkExistenGastos.Size = new System.Drawing.Size(102, 17);
            this.checkExistenGastos.TabIndex = 5;
            this.checkExistenGastos.Text = "Existen Gastos?";
            this.checkExistenGastos.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Nombre o Descripción del Producto";
            this.dataGridViewTextBoxColumn1.Width = 141;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Código";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.ToolTipText = "Código Identificador del Producto";
            this.dataGridViewTextBoxColumn2.Width = 141;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Código Especifico";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.ToolTipText = "Código ünico y Especifico de cada Producto";
            this.dataGridViewTextBoxColumn3.Width = 142;
            // 
            // dataGridViewNumericUpDownColumn1
            // 
            this.dataGridViewNumericUpDownColumn1.HeaderText = "Tiempo Garantía";
            this.dataGridViewNumericUpDownColumn1.Name = "dataGridViewNumericUpDownColumn1";
            this.dataGridViewNumericUpDownColumn1.ToolTipText = "Tiempo de Garantía en meses";
            this.dataGridViewNumericUpDownColumn1.Width = 141;
            // 
            // dataGridViewCalendarColumn1
            // 
            this.dataGridViewCalendarColumn1.HeaderText = "Fecha Vencimiento";
            this.dataGridViewCalendarColumn1.Name = "dataGridViewCalendarColumn1";
            this.dataGridViewCalendarColumn1.ToolTipText = "Fecha de Vencimiento del Producto";
            this.dataGridViewCalendarColumn1.Width = 141;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CodigoProducto";
            this.dataGridViewTextBoxColumn4.HeaderText = "Código";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.ToolTipText = "Código Identificador del Producto";
            this.dataGridViewTextBoxColumn4.Width = 101;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NombreProducto";
            this.dataGridViewTextBoxColumn5.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.ToolTipText = "Nombre o Descripción del Producto";
            this.dataGridViewTextBoxColumn5.Width = 101;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "CantidadCompra";
            this.dataGridViewTextBoxColumn6.HeaderText = "Cant Comprada";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.ToolTipText = "Cantidad Comprada";
            this.dataGridViewTextBoxColumn6.Width = 101;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CantidadRecepcionada";
            this.dataGridViewTextBoxColumn7.HeaderText = "Cant. Recepcionada";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.ToolTipText = "Cantidad Recepcionada actualmente en Almacenes";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "CantidadFaltante";
            this.dataGridViewTextBoxColumn8.HeaderText = "Cant. Faltante";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.ToolTipText = "Cantidad Faltante para Completar la Compra";
            this.dataGridViewTextBoxColumn8.Width = 101;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NuevaCantidad";
            this.dataGridViewTextBoxColumn9.HeaderText = "Cant Ingreso";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.ToolTipText = "Cantidad Nueva que se Va a Ingresar";
            this.dataGridViewTextBoxColumn9.Width = 101;
            // 
            // FCompraProductosRecepcionInventarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 533);
            this.Controls.Add(this.gBoxProductosDetalle);
            this.Controls.Add(this.gBoxProductosEspecificos);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FCompraProductosRecepcionInventarios";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Recepción de Productos a Almacenes";
            this.Load += new System.EventHandler(this.FCompraProductosRecepcionInventarios_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FCompraProductosRecepcionInventarios_FormClosing);
            this.gBoxProductosDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductos)).EndInit();
            this.gBoxProductosEspecificos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosEspecificos)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.gBoxTipoCalculoInventario.ResumeLayout(false);
            this.gBoxTipoCalculoInventario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxProductosDetalle;
        private System.Windows.Forms.GroupBox gBoxProductosEspecificos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dtGVProductosEspecificos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreProductoPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProductoPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProductoEspecifico;
        private WFADoblones20.Utilitarios.DataGridViewNumericUpDownColumn DGCTiempoGarantiaPE;
        private WFADoblones20.Utilitarios.DataGridViewCalendarColumn DGCFechaHoraVencimientoPE;
        private System.Windows.Forms.Button btnConfirmarTodo;
        private System.Windows.Forms.Button btnConfirmarParcialmente;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private WFADoblones20.Utilitarios.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn1;
        private WFADoblones20.Utilitarios.DataGridViewCalendarColumn dataGridViewCalendarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridView dtGVProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadRecepcionada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadFaltante;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNuevaCantidad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCEsProductoEspecifico;
        private System.Windows.Forms.GroupBox gBoxTipoCalculoInventario;
        private System.Windows.Forms.RadioButton rBtnGastosProrrateados;
        private System.Windows.Forms.RadioButton rBtnPersonalizado;
        private System.Windows.Forms.CheckBox checkImprimirReporte;
        private System.Windows.Forms.CheckBox checkExistenGastos;
        private System.Windows.Forms.RadioButton rbtnTablas;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnForzarFinalizacion;
    }
}