namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FCompraProductosIngresoEspecificos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCompraProductosIngresoEspecificos));
            this.gBoxDatos = new System.Windows.Forms.GroupBox();
            this.lblCodigoProducto = new System.Windows.Forms.Label();
            this.btnAnadir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.nUDtiempoGarantia = new System.Windows.Forms.NumericUpDown();
            this.txtBoxCodigoProductoEspecifico = new System.Windows.Forms.TextBox();
            this.gBoxProductosEspecificos = new System.Windows.Forms.GroupBox();
            this.dtGVproductosEspecificos = new System.Windows.Forms.DataGridView();
            this.DGCCodigoProductoEspecifico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCTiempoGarantiaPE = new WFADoblones20.Utilitarios.DataGridViewNumericUpDownColumn();
            this.DGCFechaHoraVencimientoPE = new WFADoblones20.Utilitarios.DataGridViewCalendarColumn();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCompletar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewNumericUpDownColumn1 = new WFADoblones20.Utilitarios.DataGridViewNumericUpDownColumn();
            this.dataGridViewCalendarColumn1 = new WFADoblones20.Utilitarios.DataGridViewCalendarColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gBoxDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDtiempoGarantia)).BeginInit();
            this.gBoxProductosEspecificos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVproductosEspecificos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxDatos
            // 
            this.gBoxDatos.Controls.Add(this.lblCodigoProducto);
            this.gBoxDatos.Controls.Add(this.btnAnadir);
            this.gBoxDatos.Controls.Add(this.label3);
            this.gBoxDatos.Controls.Add(this.label2);
            this.gBoxDatos.Controls.Add(this.label1);
            this.gBoxDatos.Controls.Add(this.dateTimePicker1);
            this.gBoxDatos.Controls.Add(this.nUDtiempoGarantia);
            this.gBoxDatos.Controls.Add(this.txtBoxCodigoProductoEspecifico);
            this.gBoxDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxDatos.Location = new System.Drawing.Point(0, 0);
            this.gBoxDatos.Name = "gBoxDatos";
            this.gBoxDatos.Size = new System.Drawing.Size(496, 81);
            this.gBoxDatos.TabIndex = 0;
            this.gBoxDatos.TabStop = false;
            this.gBoxDatos.Text = "Ingresar Datos";
            // 
            // lblCodigoProducto
            // 
            this.lblCodigoProducto.AutoSize = true;
            this.lblCodigoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoProducto.Location = new System.Drawing.Point(12, 59);
            this.lblCodigoProducto.Name = "lblCodigoProducto";
            this.lblCodigoProducto.Size = new System.Drawing.Size(23, 13);
            this.lblCodigoProducto.TabIndex = 7;
            this.lblCodigoProducto.Text = "....";
            // 
            // btnAnadir
            // 
            this.btnAnadir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnadir.ImageKey = "Rename.ico";
            this.btnAnadir.Location = new System.Drawing.Point(419, 30);
            this.btnAnadir.Name = "btnAnadir";
            this.btnAnadir.Size = new System.Drawing.Size(60, 32);
            this.btnAnadir.TabIndex = 6;
            this.btnAnadir.Text = "&Añadir";
            this.btnAnadir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnAnadir, "Añadir el Código Específicos");
            this.btnAnadir.UseVisualStyleBackColor = true;
            this.btnAnadir.Click += new System.EventHandler(this.btnAnadir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha de Vencimiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tiempo Garantía";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Codigo Específico";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(312, 36);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(105, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // nUDtiempoGarantia
            // 
            this.nUDtiempoGarantia.Location = new System.Drawing.Point(215, 36);
            this.nUDtiempoGarantia.Name = "nUDtiempoGarantia";
            this.nUDtiempoGarantia.Size = new System.Drawing.Size(91, 20);
            this.nUDtiempoGarantia.TabIndex = 1;
            // 
            // txtBoxCodigoProductoEspecifico
            // 
            this.txtBoxCodigoProductoEspecifico.Location = new System.Drawing.Point(12, 36);
            this.txtBoxCodigoProductoEspecifico.MaxLength = 30;
            this.txtBoxCodigoProductoEspecifico.Name = "txtBoxCodigoProductoEspecifico";
            this.txtBoxCodigoProductoEspecifico.Size = new System.Drawing.Size(197, 20);
            this.txtBoxCodigoProductoEspecifico.TabIndex = 0;
            this.txtBoxCodigoProductoEspecifico.TextChanged += new System.EventHandler(this.txtBoxCodigoProductoEspecifico_TextChanged);
            this.txtBoxCodigoProductoEspecifico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxCodigoProductoEspecifico_KeyDown);
            // 
            // gBoxProductosEspecificos
            // 
            this.gBoxProductosEspecificos.Controls.Add(this.dtGVproductosEspecificos);
            this.gBoxProductosEspecificos.Controls.Add(this.bindingNavigator1);
            this.gBoxProductosEspecificos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxProductosEspecificos.Location = new System.Drawing.Point(0, 81);
            this.gBoxProductosEspecificos.Name = "gBoxProductosEspecificos";
            this.gBoxProductosEspecificos.Padding = new System.Windows.Forms.Padding(8);
            this.gBoxProductosEspecificos.Size = new System.Drawing.Size(496, 322);
            this.gBoxProductosEspecificos.TabIndex = 1;
            this.gBoxProductosEspecificos.TabStop = false;
            this.gBoxProductosEspecificos.Text = "Detalle de Productos";
            // 
            // dtGVproductosEspecificos
            // 
            this.dtGVproductosEspecificos.AllowUserToAddRows = false;
            this.dtGVproductosEspecificos.AllowUserToResizeRows = false;
            this.dtGVproductosEspecificos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVproductosEspecificos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtGVproductosEspecificos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVproductosEspecificos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVproductosEspecificos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVproductosEspecificos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoProductoEspecifico,
            this.DGCTiempoGarantiaPE,
            this.DGCFechaHoraVencimientoPE});
            this.dtGVproductosEspecificos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVproductosEspecificos.Location = new System.Drawing.Point(8, 46);
            this.dtGVproductosEspecificos.Name = "dtGVproductosEspecificos";
            this.dtGVproductosEspecificos.RowHeadersVisible = false;
            this.dtGVproductosEspecificos.Size = new System.Drawing.Size(480, 268);
            this.dtGVproductosEspecificos.TabIndex = 0;
            this.dtGVproductosEspecificos.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dtGVproductosEspecificos_CellValueNeeded);
            this.dtGVproductosEspecificos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtGVproductosEspecificos_RowsAdded);
            this.dtGVproductosEspecificos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtGVproductosEspecificos_RowsRemoved);
            this.dtGVproductosEspecificos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtGVproductosEspecificos_KeyPress);
            // 
            // DGCCodigoProductoEspecifico
            // 
            this.DGCCodigoProductoEspecifico.DataPropertyName = "CodigoProductoEspecifico";
            this.DGCCodigoProductoEspecifico.HeaderText = "Codigo Especifico";
            this.DGCCodigoProductoEspecifico.Name = "DGCCodigoProductoEspecifico";
            this.DGCCodigoProductoEspecifico.ReadOnly = true;
            this.DGCCodigoProductoEspecifico.ToolTipText = "Código Identificador único del Producto";
            // 
            // DGCTiempoGarantiaPE
            // 
            this.DGCTiempoGarantiaPE.DataPropertyName = "TiempoGarantiaPE";
            this.DGCTiempoGarantiaPE.HeaderText = "Garantía";
            this.DGCTiempoGarantiaPE.Name = "DGCTiempoGarantiaPE";
            this.DGCTiempoGarantiaPE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCTiempoGarantiaPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGCTiempoGarantiaPE.ToolTipText = "Tiempo de Garantía en MESES";
            // 
            // DGCFechaHoraVencimientoPE
            // 
            this.DGCFechaHoraVencimientoPE.DataPropertyName = "FechaHoraVencimientoPE";
            this.DGCFechaHoraVencimientoPE.HeaderText = "Vencimiento ?";
            this.DGCFechaHoraVencimientoPE.Name = "DGCFechaHoraVencimientoPE";
            this.DGCFechaHoraVencimientoPE.ToolTipText = "Fecha de Vencimiento";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(8, 21);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(480, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Eliminar";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel1.Controls.Add(this.btnConfirmar);
            this.flowLayoutPanel1.Controls.Add(this.btnCompletar);
            this.flowLayoutPanel1.Controls.Add(this.btnEliminar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 403);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(496, 41);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageKey = "Undo.ico";
            this.btnCancelar.Location = new System.Drawing.Point(418, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 32);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar los Cambios realizados");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.ImageKey = "Symbol-Check.ico";
            this.btnConfirmar.Location = new System.Drawing.Point(337, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 32);
            this.btnConfirmar.TabIndex = 0;
            this.btnConfirmar.Text = "&Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnConfirmar, "Confirmar la operación Actual");
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCompletar
            // 
            this.btnCompletar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompletar.ImageKey = "Defragmentation.ico";
            this.btnCompletar.Location = new System.Drawing.Point(256, 3);
            this.btnCompletar.Name = "btnCompletar";
            this.btnCompletar.Size = new System.Drawing.Size(75, 32);
            this.btnCompletar.TabIndex = 1;
            this.btnCompletar.Text = "&Generar";
            this.btnCompletar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnCompletar, "Generar Automáticamente los Códigos Específicos");
            this.btnCompletar.UseVisualStyleBackColor = true;
            this.btnCompletar.Click += new System.EventHandler(this.btnCompletar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.ImageKey = "Symbol-Delete.ico";
            this.btnEliminar.Location = new System.Drawing.Point(175, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 32);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnEliminar, "Eliminar el Código Específico");
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoProductoEspecifico";
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo Especifico";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Código Identificador único del Producto";
            this.dataGridViewTextBoxColumn1.Width = 159;
            // 
            // dataGridViewNumericUpDownColumn1
            // 
            this.dataGridViewNumericUpDownColumn1.DataPropertyName = "TiempoGarantiaPE";
            this.dataGridViewNumericUpDownColumn1.HeaderText = "Garantía";
            this.dataGridViewNumericUpDownColumn1.Name = "dataGridViewNumericUpDownColumn1";
            this.dataGridViewNumericUpDownColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNumericUpDownColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewNumericUpDownColumn1.ToolTipText = "Tiempo de Garantía en MESES";
            this.dataGridViewNumericUpDownColumn1.Width = 159;
            // 
            // dataGridViewCalendarColumn1
            // 
            this.dataGridViewCalendarColumn1.DataPropertyName = "FechaHoraVencimientoPE";
            this.dataGridViewCalendarColumn1.HeaderText = "Vencimiento ?";
            this.dataGridViewCalendarColumn1.Name = "dataGridViewCalendarColumn1";
            this.dataGridViewCalendarColumn1.ToolTipText = "Fecha de Vencimiento";
            this.dataGridViewCalendarColumn1.Width = 159;
            // 
            // FCompraProductosIngresoEspecificos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(496, 444);
            this.Controls.Add(this.gBoxProductosEspecificos);
            this.Controls.Add(this.gBoxDatos);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FCompraProductosIngresoEspecificos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos Especificos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FCompraProductosIngresoEspecificos_FormClosing);
            this.Load += new System.EventHandler(this.FCompraProductosIngresoEspecificos_Load);
            this.gBoxDatos.ResumeLayout(false);
            this.gBoxDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDtiempoGarantia)).EndInit();
            this.gBoxProductosEspecificos.ResumeLayout(false);
            this.gBoxProductosEspecificos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVproductosEspecificos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxDatos;
        private System.Windows.Forms.GroupBox gBoxProductosEspecificos;
        private System.Windows.Forms.DataGridView dtGVproductosEspecificos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.NumericUpDown nUDtiempoGarantia;
        private System.Windows.Forms.TextBox txtBoxCodigoProductoEspecifico;
        private System.Windows.Forms.Button btnAnadir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCompletar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProductoEspecifico;
        private WFADoblones20.Utilitarios.DataGridViewNumericUpDownColumn DGCTiempoGarantiaPE;
        private WFADoblones20.Utilitarios.DataGridViewCalendarColumn DGCFechaHoraVencimientoPE;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private WFADoblones20.Utilitarios.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn1;
        private WFADoblones20.Utilitarios.DataGridViewCalendarColumn dataGridViewCalendarColumn1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}