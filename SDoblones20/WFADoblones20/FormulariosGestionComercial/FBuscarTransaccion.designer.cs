namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FBuscarTransaccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBuscarTransaccion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblNumeroRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.opcionasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limpiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocultarColumnaNombreProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocultarFechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocultarNumeroTransacciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocultarColumnaNumeroAgenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPnlPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxBuscarPor = new System.Windows.Forms.ComboBox();
            this.checkTextoIdentico = new System.Windows.Forms.CheckBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtBoxTextoBusqueda = new System.Windows.Forms.TextBox();
            this.txtBoxNumeroTransaccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNroTransaccion = new System.Windows.Forms.Label();
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.dtGVTransacciones = new System.Windows.Forms.DataGridView();
            this.bdSourceTransacciones = new System.Windows.Forms.BindingSource(this.components);
            this.bdNavTransacciones = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPnlPrincipal.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.pnlCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVTransacciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceTransacciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavTransacciones)).BeginInit();
            this.bdNavTransacciones.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNumeroRegistros,
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(5, 473);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(706, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblNumeroRegistros
            // 
            this.lblNumeroRegistros.Name = "lblNumeroRegistros";
            this.lblNumeroRegistros.Size = new System.Drawing.Size(178, 17);
            this.lblNumeroRegistros.Text = "Nro de Registros Encontrados : 0";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionasToolStripMenuItem,
            this.ocultarColumnaNombreProductoToolStripMenuItem,
            this.ocultarFechaToolStripMenuItem,
            this.ocultarNumeroTransacciónToolStripMenuItem,
            this.ocultarColumnaNumeroAgenciaToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(96, 20);
            this.toolStripDropDownButton1.Text = "Configuración";
            // 
            // opcionasToolStripMenuItem
            // 
            this.opcionasToolStripMenuItem.CheckOnClick = true;
            this.opcionasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.limpiarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.cerrarToolStripMenuItem});
            this.opcionasToolStripMenuItem.Name = "opcionasToolStripMenuItem";
            this.opcionasToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.opcionasToolStripMenuItem.Text = "Opciones";
            // 
            // limpiarToolStripMenuItem
            // 
            this.limpiarToolStripMenuItem.Name = "limpiarToolStripMenuItem";
            this.limpiarToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.limpiarToolStripMenuItem.Text = "Limpiar";
            this.limpiarToolStripMenuItem.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(111, 6);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // ocultarColumnaNombreProductoToolStripMenuItem
            // 
            this.ocultarColumnaNombreProductoToolStripMenuItem.CheckOnClick = true;
            this.ocultarColumnaNombreProductoToolStripMenuItem.Name = "ocultarColumnaNombreProductoToolStripMenuItem";
            this.ocultarColumnaNombreProductoToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.ocultarColumnaNombreProductoToolStripMenuItem.Text = "Ocultar Columna Nombre Producto";
            this.ocultarColumnaNombreProductoToolStripMenuItem.Click += new System.EventHandler(this.ocultarColumnaNombreProductoToolStripMenuItem_Click);
            // 
            // ocultarFechaToolStripMenuItem
            // 
            this.ocultarFechaToolStripMenuItem.CheckOnClick = true;
            this.ocultarFechaToolStripMenuItem.Name = "ocultarFechaToolStripMenuItem";
            this.ocultarFechaToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.ocultarFechaToolStripMenuItem.Text = "Ocultar Columna Fecha";
            this.ocultarFechaToolStripMenuItem.Click += new System.EventHandler(this.ocultarFechaToolStripMenuItem_Click);
            // 
            // ocultarNumeroTransacciónToolStripMenuItem
            // 
            this.ocultarNumeroTransacciónToolStripMenuItem.CheckOnClick = true;
            this.ocultarNumeroTransacciónToolStripMenuItem.Name = "ocultarNumeroTransacciónToolStripMenuItem";
            this.ocultarNumeroTransacciónToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.ocultarNumeroTransacciónToolStripMenuItem.Text = "Ocultar Numero Coilumna Transacción";
            this.ocultarNumeroTransacciónToolStripMenuItem.Click += new System.EventHandler(this.ocultarNumeroTransacciónToolStripMenuItem_Click);
            // 
            // ocultarColumnaNumeroAgenciaToolStripMenuItem
            // 
            this.ocultarColumnaNumeroAgenciaToolStripMenuItem.CheckOnClick = true;
            this.ocultarColumnaNumeroAgenciaToolStripMenuItem.Name = "ocultarColumnaNumeroAgenciaToolStripMenuItem";
            this.ocultarColumnaNumeroAgenciaToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.ocultarColumnaNumeroAgenciaToolStripMenuItem.Text = "Ocultar Columna Numero Agencia";
            this.ocultarColumnaNumeroAgenciaToolStripMenuItem.Click += new System.EventHandler(this.ocultarColumnaNumeroAgenciaToolStripMenuItem_Click);
            // 
            // tableLayoutPnlPrincipal
            // 
            this.tableLayoutPnlPrincipal.ColumnCount = 1;
            this.tableLayoutPnlPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPnlPrincipal.Controls.Add(this.pnlSuperior, 0, 0);
            this.tableLayoutPnlPrincipal.Controls.Add(this.pnlCentral, 0, 1);
            this.tableLayoutPnlPrincipal.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPnlPrincipal.Location = new System.Drawing.Point(5, 0);
            this.tableLayoutPnlPrincipal.Name = "tableLayoutPnlPrincipal";
            this.tableLayoutPnlPrincipal.RowCount = 3;
            this.tableLayoutPnlPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPnlPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPnlPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPnlPrincipal.Size = new System.Drawing.Size(706, 473);
            this.tableLayoutPnlPrincipal.TabIndex = 1;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.button1);
            this.pnlSuperior.Controls.Add(this.label1);
            this.pnlSuperior.Controls.Add(this.cBoxBuscarPor);
            this.pnlSuperior.Controls.Add(this.checkTextoIdentico);
            this.pnlSuperior.Controls.Add(this.dateTimePicker2);
            this.pnlSuperior.Controls.Add(this.dateTimePicker1);
            this.pnlSuperior.Controls.Add(this.txtBoxTextoBusqueda);
            this.pnlSuperior.Controls.Add(this.txtBoxNumeroTransaccion);
            this.pnlSuperior.Controls.Add(this.label4);
            this.pnlSuperior.Controls.Add(this.label3);
            this.pnlSuperior.Controls.Add(this.label2);
            this.pnlSuperior.Controls.Add(this.lblNroTransaccion);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSuperior.Location = new System.Drawing.Point(3, 3);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(700, 55);
            this.pnlSuperior.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(631, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 25);
            this.button1.TabIndex = 11;
            this.button1.Text = "&Buscar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "search.ico");
            this.imageList1.Images.SetKeyName(1, "Recharger.ico");
            this.imageList1.Images.SetKeyName(2, "delete.ico");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Buscar por";
            // 
            // cBoxBuscarPor
            // 
            this.cBoxBuscarPor.FormattingEnabled = true;
            this.cBoxBuscarPor.Location = new System.Drawing.Point(325, 3);
            this.cBoxBuscarPor.Name = "cBoxBuscarPor";
            this.cBoxBuscarPor.Size = new System.Drawing.Size(162, 21);
            this.cBoxBuscarPor.TabIndex = 9;
            // 
            // checkTextoIdentico
            // 
            this.checkTextoIdentico.AutoSize = true;
            this.checkTextoIdentico.Location = new System.Drawing.Point(506, 3);
            this.checkTextoIdentico.Name = "checkTextoIdentico";
            this.checkTextoIdentico.Size = new System.Drawing.Size(103, 17);
            this.checkTextoIdentico.TabIndex = 8;
            this.checkTextoIdentico.Text = "Texto Idéntico ?";
            this.checkTextoIdentico.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(152, 28);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(98, 20);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(37, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // txtBoxTextoBusqueda
            // 
            this.txtBoxTextoBusqueda.Location = new System.Drawing.Point(349, 28);
            this.txtBoxTextoBusqueda.Name = "txtBoxTextoBusqueda";
            this.txtBoxTextoBusqueda.Size = new System.Drawing.Size(276, 20);
            this.txtBoxTextoBusqueda.TabIndex = 5;
            this.txtBoxTextoBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxTextoBusqueda_KeyDown);
            // 
            // txtBoxNumeroTransaccion
            // 
            this.txtBoxNumeroTransaccion.Location = new System.Drawing.Point(152, 3);
            this.txtBoxNumeroTransaccion.Name = "txtBoxNumeroTransaccion";
            this.txtBoxNumeroTransaccion.Size = new System.Drawing.Size(100, 20);
            this.txtBoxNumeroTransaccion.TabIndex = 4;
            this.txtBoxNumeroTransaccion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxTextoBusqueda_KeyDown);
            this.txtBoxNumeroTransaccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxNumeroTransaccion_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Texto a Buscar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "al";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Del";
            // 
            // lblNroTransaccion
            // 
            this.lblNroTransaccion.AutoSize = true;
            this.lblNroTransaccion.Location = new System.Drawing.Point(12, 6);
            this.lblNroTransaccion.Name = "lblNroTransaccion";
            this.lblNroTransaccion.Size = new System.Drawing.Size(121, 13);
            this.lblNroTransaccion.TabIndex = 0;
            this.lblNroTransaccion.Text = "Numero de Transacción";
            // 
            // pnlCentral
            // 
            this.pnlCentral.Controls.Add(this.dtGVTransacciones);
            this.pnlCentral.Controls.Add(this.bdNavTransacciones);
            this.pnlCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentral.Location = new System.Drawing.Point(3, 64);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Size = new System.Drawing.Size(700, 366);
            this.pnlCentral.TabIndex = 1;
            // 
            // dtGVTransacciones
            // 
            this.dtGVTransacciones.AllowUserToAddRows = false;
            this.dtGVTransacciones.AllowUserToDeleteRows = false;
            this.dtGVTransacciones.AllowUserToResizeRows = false;
            this.dtGVTransacciones.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVTransacciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVTransacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVTransacciones.DataSource = this.bdSourceTransacciones;
            this.dtGVTransacciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVTransacciones.Location = new System.Drawing.Point(0, 25);
            this.dtGVTransacciones.Name = "dtGVTransacciones";
            this.dtGVTransacciones.ReadOnly = true;
            this.dtGVTransacciones.RowHeadersVisible = false;
            this.dtGVTransacciones.Size = new System.Drawing.Size(700, 341);
            this.dtGVTransacciones.TabIndex = 1;
            this.dtGVTransacciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVTransacciones_CellDoubleClick);
            this.dtGVTransacciones.DoubleClick += new System.EventHandler(this.dtGVTransacciones_DoubleClick);
            // 
            // bdNavTransacciones
            // 
            this.bdNavTransacciones.AddNewItem = null;
            this.bdNavTransacciones.BindingSource = this.bdSourceTransacciones;
            this.bdNavTransacciones.CountItem = this.bindingNavigatorCountItem;
            this.bdNavTransacciones.DeleteItem = null;
            this.bdNavTransacciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bdNavTransacciones.Location = new System.Drawing.Point(0, 0);
            this.bdNavTransacciones.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdNavTransacciones.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdNavTransacciones.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdNavTransacciones.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdNavTransacciones.Name = "bdNavTransacciones";
            this.bdNavTransacciones.PositionItem = this.bindingNavigatorPositionItem;
            this.bdNavTransacciones.Size = new System.Drawing.Size(700, 25);
            this.bdNavTransacciones.TabIndex = 0;
            this.bdNavTransacciones.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
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
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btnCerrar);
            this.flowLayoutPanel1.Controls.Add(this.btnLimpiar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 436);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(700, 34);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.ImageIndex = 2;
            this.btnCerrar.ImageList = this.imageList1;
            this.btnCerrar.Location = new System.Drawing.Point(630, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(65, 28);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.ImageIndex = 1;
            this.btnLimpiar.ImageList = this.imageList1;
            this.btnLimpiar.Location = new System.Drawing.Point(559, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(65, 28);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FBuscarTransaccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(716, 495);
            this.Controls.Add(this.tableLayoutPnlPrincipal);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FBuscarTransaccion";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Transacción";
            this.Load += new System.EventHandler(this.FBuscarTransaccion_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPnlPrincipal.ResumeLayout(false);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlCentral.ResumeLayout(false);
            this.pnlCentral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVTransacciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceTransacciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavTransacciones)).EndInit();
            this.bdNavTransacciones.ResumeLayout(false);
            this.bdNavTransacciones.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPnlPrincipal;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBoxBuscarPor;
        private System.Windows.Forms.CheckBox checkTextoIdentico;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtBoxTextoBusqueda;
        private System.Windows.Forms.TextBox txtBoxNumeroTransaccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNroTransaccion;
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.DataGridView dtGVTransacciones;
        private System.Windows.Forms.BindingNavigator bdNavTransacciones;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.BindingSource bdSourceTransacciones;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ToolStripStatusLabel lblNumeroRegistros;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem opcionasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem limpiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ocultarColumnaNombreProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ocultarFechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ocultarNumeroTransacciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ocultarColumnaNumeroAgenciaToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;

    }
}