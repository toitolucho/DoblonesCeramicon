namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FGastosTiposTransacciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FGastosTiposTransacciones));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtBoxDescripcionTipoGasto = new System.Windows.Forms.TextBox();
            this.txtBoxNombreTipoGasto = new System.Windows.Forms.TextBox();
            this.txtBoxCodigoTipoGasto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bCerrar = new System.Windows.Forms.Button();
            this.imgListbancos = new System.Windows.Forms.ImageList(this.components);
            this.bCancelar = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.bEliminar = new System.Windows.Forms.Button();
            this.bNuevo = new System.Windows.Forms.Button();
            this.bEditar = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtGVGastosTipos = new System.Windows.Forms.DataGridView();
            this.DGCCodigoGastosTipos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreGasto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDescripcionGasto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdNavGastosTipos = new System.Windows.Forms.BindingNavigator(this.components);
            this.bdSourceGastosTipos = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVGastosTipos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavGastosTipos)).BeginInit();
            this.bdNavGastosTipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceGastosTipos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imgListbancos;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(463, 206);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtBoxDescripcionTipoGasto);
            this.tabPage1.Controls.Add(this.txtBoxNombreTipoGasto);
            this.tabPage1.Controls.Add(this.txtBoxCodigoTipoGasto);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.bCerrar);
            this.tabPage1.Controls.Add(this.bCancelar);
            this.tabPage1.Controls.Add(this.bAceptar);
            this.tabPage1.Controls.Add(this.bEliminar);
            this.tabPage1.Controls.Add(this.bNuevo);
            this.tabPage1.Controls.Add(this.bEditar);
            this.tabPage1.ImageIndex = 11;
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(455, 175);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detalle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtBoxDescripcionTipoGasto
            // 
            this.txtBoxDescripcionTipoGasto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxDescripcionTipoGasto.Location = new System.Drawing.Point(110, 58);
            this.txtBoxDescripcionTipoGasto.Multiline = true;
            this.txtBoxDescripcionTipoGasto.Name = "txtBoxDescripcionTipoGasto";
            this.txtBoxDescripcionTipoGasto.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxDescripcionTipoGasto.Size = new System.Drawing.Size(337, 75);
            this.txtBoxDescripcionTipoGasto.TabIndex = 25;
            // 
            // txtBoxNombreTipoGasto
            // 
            this.txtBoxNombreTipoGasto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxNombreTipoGasto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBoxNombreTipoGasto.Location = new System.Drawing.Point(110, 32);
            this.txtBoxNombreTipoGasto.Name = "txtBoxNombreTipoGasto";
            this.txtBoxNombreTipoGasto.Size = new System.Drawing.Size(337, 20);
            this.txtBoxNombreTipoGasto.TabIndex = 24;
            // 
            // txtBoxCodigoTipoGasto
            // 
            this.txtBoxCodigoTipoGasto.Enabled = false;
            this.txtBoxCodigoTipoGasto.Location = new System.Drawing.Point(110, 6);
            this.txtBoxCodigoTipoGasto.Name = "txtBoxCodigoTipoGasto";
            this.txtBoxCodigoTipoGasto.ReadOnly = true;
            this.txtBoxCodigoTipoGasto.Size = new System.Drawing.Size(129, 20);
            this.txtBoxCodigoTipoGasto.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Descripción Gasto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Nombre Gasto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Código";
            // 
            // bCerrar
            // 
            this.bCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCerrar.ImageIndex = 8;
            this.bCerrar.ImageList = this.imgListbancos;
            this.bCerrar.Location = new System.Drawing.Point(370, 140);
            this.bCerrar.Name = "bCerrar";
            this.bCerrar.Size = new System.Drawing.Size(65, 29);
            this.bCerrar.TabIndex = 19;
            this.bCerrar.Text = "Cerrar";
            this.bCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCerrar.UseVisualStyleBackColor = true;
            this.bCerrar.Click += new System.EventHandler(this.bCerrar_Click);
            // 
            // imgListbancos
            // 
            this.imgListbancos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListbancos.ImageStream")));
            this.imgListbancos.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListbancos.Images.SetKeyName(0, "Undo.ico");
            this.imgListbancos.Images.SetKeyName(1, "Edit.ico");
            this.imgListbancos.Images.SetKeyName(2, "Rename.ico");
            this.imgListbancos.Images.SetKeyName(3, "Save.ico");
            this.imgListbancos.Images.SetKeyName(4, "Symbol-Add.ico");
            this.imgListbancos.Images.SetKeyName(5, "Symbol-Check.ico");
            this.imgListbancos.Images.SetKeyName(6, "Symbol-Delete.ico");
            this.imgListbancos.Images.SetKeyName(7, "Symbol-Refresh.ico");
            this.imgListbancos.Images.SetKeyName(8, "delete.ico");
            this.imgListbancos.Images.SetKeyName(9, "Generic.ico");
            this.imgListbancos.Images.SetKeyName(10, "Notes.ico");
            this.imgListbancos.Images.SetKeyName(11, "card.ico");
            // 
            // bCancelar
            // 
            this.bCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCancelar.ImageIndex = 0;
            this.bCancelar.ImageList = this.imgListbancos;
            this.bCancelar.Location = new System.Drawing.Point(298, 140);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(70, 29);
            this.bCancelar.TabIndex = 18;
            this.bCancelar.Text = "&Cancelar";
            this.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bAceptar
            // 
            this.bAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAceptar.ImageIndex = 3;
            this.bAceptar.ImageList = this.imgListbancos;
            this.bAceptar.Location = new System.Drawing.Point(226, 140);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(70, 29);
            this.bAceptar.TabIndex = 17;
            this.bAceptar.Text = "&Aceptar";
            this.bAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // bEliminar
            // 
            this.bEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEliminar.ImageIndex = 6;
            this.bEliminar.ImageList = this.imgListbancos;
            this.bEliminar.Location = new System.Drawing.Point(154, 140);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(70, 29);
            this.bEliminar.TabIndex = 16;
            this.bEliminar.Text = "E&liminar";
            this.bEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bEliminar.UseVisualStyleBackColor = true;
            this.bEliminar.Click += new System.EventHandler(this.bEliminar_Click);
            // 
            // bNuevo
            // 
            this.bNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bNuevo.ImageIndex = 4;
            this.bNuevo.ImageList = this.imgListbancos;
            this.bNuevo.Location = new System.Drawing.Point(20, 140);
            this.bNuevo.Name = "bNuevo";
            this.bNuevo.Size = new System.Drawing.Size(65, 29);
            this.bNuevo.TabIndex = 14;
            this.bNuevo.Text = "&Nuevo";
            this.bNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bNuevo.UseVisualStyleBackColor = true;
            this.bNuevo.Click += new System.EventHandler(this.bNuevo_Click);
            // 
            // bEditar
            // 
            this.bEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEditar.ImageIndex = 1;
            this.bEditar.ImageList = this.imgListbancos;
            this.bEditar.Location = new System.Drawing.Point(87, 140);
            this.bEditar.Name = "bEditar";
            this.bEditar.Size = new System.Drawing.Size(65, 29);
            this.bEditar.TabIndex = 15;
            this.bEditar.Text = "&Editar";
            this.bEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bEditar.UseVisualStyleBackColor = true;
            this.bEditar.Click += new System.EventHandler(this.bEditar_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtGVGastosTipos);
            this.tabPage2.Controls.Add(this.bdNavGastosTipos);
            this.tabPage2.ImageIndex = 9;
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(455, 175);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Listado";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtGVGastosTipos
            // 
            this.dtGVGastosTipos.AllowUserToAddRows = false;
            this.dtGVGastosTipos.AllowUserToResizeRows = false;
            this.dtGVGastosTipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVGastosTipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVGastosTipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoGastosTipos,
            this.DGCNombreGasto,
            this.DGCDescripcionGasto});
            this.dtGVGastosTipos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVGastosTipos.Location = new System.Drawing.Point(3, 28);
            this.dtGVGastosTipos.MultiSelect = false;
            this.dtGVGastosTipos.Name = "dtGVGastosTipos";
            this.dtGVGastosTipos.RowHeadersVisible = false;
            this.dtGVGastosTipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVGastosTipos.Size = new System.Drawing.Size(449, 144);
            this.dtGVGastosTipos.TabIndex = 0;
            this.dtGVGastosTipos.SelectionChanged += new System.EventHandler(this.dtGVGastosTipos_SelectionChanged);
            // 
            // DGCCodigoGastosTipos
            // 
            this.DGCCodigoGastosTipos.DataPropertyName = "CodigoGastosTipos";
            this.DGCCodigoGastosTipos.HeaderText = "Código";
            this.DGCCodigoGastosTipos.Name = "DGCCodigoGastosTipos";
            this.DGCCodigoGastosTipos.ReadOnly = true;
            this.DGCCodigoGastosTipos.ToolTipText = "Código Identificador del Gasto";
            // 
            // DGCNombreGasto
            // 
            this.DGCNombreGasto.DataPropertyName = "NombreGasto";
            this.DGCNombreGasto.HeaderText = "Nombre";
            this.DGCNombreGasto.Name = "DGCNombreGasto";
            this.DGCNombreGasto.ReadOnly = true;
            this.DGCNombreGasto.ToolTipText = "Nombre";
            // 
            // DGCDescripcionGasto
            // 
            this.DGCDescripcionGasto.DataPropertyName = "DescripcionGasto";
            this.DGCDescripcionGasto.HeaderText = "Descripción";
            this.DGCDescripcionGasto.Name = "DGCDescripcionGasto";
            this.DGCDescripcionGasto.ReadOnly = true;
            // 
            // bdNavGastosTipos
            // 
            this.bdNavGastosTipos.AddNewItem = null;
            this.bdNavGastosTipos.BindingSource = this.bdSourceGastosTipos;
            this.bdNavGastosTipos.CountItem = this.bindingNavigatorCountItem;
            this.bdNavGastosTipos.DeleteItem = null;
            this.bdNavGastosTipos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bdNavGastosTipos.Location = new System.Drawing.Point(3, 3);
            this.bdNavGastosTipos.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdNavGastosTipos.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdNavGastosTipos.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdNavGastosTipos.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdNavGastosTipos.Name = "bdNavGastosTipos";
            this.bdNavGastosTipos.PositionItem = this.bindingNavigatorPositionItem;
            this.bdNavGastosTipos.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bdNavGastosTipos.Size = new System.Drawing.Size(449, 25);
            this.bdNavGastosTipos.TabIndex = 1;
            this.bdNavGastosTipos.Text = "bindingNavigator1";
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoGastosTipos";
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Código Identificador del Gasto";
            this.dataGridViewTextBoxColumn1.Width = 149;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreGasto";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.ToolTipText = "Nombre";
            this.dataGridViewTextBoxColumn2.Width = 148;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DescripcionGasto";
            this.dataGridViewTextBoxColumn3.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 149;
            // 
            // FGastosTiposTransacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCerrar;
            this.ClientSize = new System.Drawing.Size(463, 206);
            this.Controls.Add(this.tabControl1);
            this.Name = "FGastosTiposTransacciones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo de Gastos por Transacciones";
            this.Load += new System.EventHandler(this.FGastosTiposTransacciones_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVGastosTipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavGastosTipos)).EndInit();
            this.bdNavGastosTipos.ResumeLayout(false);
            this.bdNavGastosTipos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceGastosTipos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imgListbancos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bCerrar;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.Button bNuevo;
        private System.Windows.Forms.Button bEditar;
        private System.Windows.Forms.TextBox txtBoxDescripcionTipoGasto;
        private System.Windows.Forms.TextBox txtBoxNombreTipoGasto;
        private System.Windows.Forms.TextBox txtBoxCodigoTipoGasto;
        private System.Windows.Forms.DataGridView dtGVGastosTipos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoGastosTipos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreGasto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDescripcionGasto;
        private System.Windows.Forms.BindingNavigator bdNavGastosTipos;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource bdSourceGastosTipos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}