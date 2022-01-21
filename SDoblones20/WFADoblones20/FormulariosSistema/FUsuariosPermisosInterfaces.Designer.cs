namespace WFADoblones20.FormulariosSistema
{
    partial class FUsuariosPermisosInterfaces
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPagePorGrupos = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGVPermisosPorGrupos = new System.Windows.Forms.DataGridView();
            this.DGCPermitirInsertarG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGCPermitirEditarG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGCPermitirEliminarG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGCPermitirNavegarG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGCPermitirReportesG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPermisosXGrupos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxGruposUsuarios = new System.Windows.Forms.ComboBox();
            this.tabPageParticulares = new System.Windows.Forms.TabPage();
            this.gBoxListadoPermisos = new System.Windows.Forms.GroupBox();
            this.cBoxReportes = new System.Windows.Forms.CheckBox();
            this.cBoxNavegar = new System.Windows.Forms.CheckBox();
            this.cBoxEliminar = new System.Windows.Forms.CheckBox();
            this.cBoxEditar = new System.Windows.Forms.CheckBox();
            this.cBoxInsertar = new System.Windows.Forms.CheckBox();
            this.dtGVPermisosIndividuales = new System.Windows.Forms.DataGridView();
            this.DGCPermitirInsertarI = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGCPermitirEditarI = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGCPermitirEliminarI = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGCPermitirNavegarI = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGCPermitirReportesI = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVCodigoInterfaceG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreInterfaceG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCTextoInterfaceG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoInterfaceI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreInterfaceI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCTextoInterfaceI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPagePorGrupos.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPermisosPorGrupos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPageParticulares.SuspendLayout();
            this.gBoxListadoPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPermisosIndividuales)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPagePorGrupos);
            this.tabControl1.Controls.Add(this.tabPageParticulares);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(860, 462);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPagePorGrupos
            // 
            this.tabPagePorGrupos.Controls.Add(this.groupBox2);
            this.tabPagePorGrupos.Controls.Add(this.groupBox1);
            this.tabPagePorGrupos.Location = new System.Drawing.Point(4, 22);
            this.tabPagePorGrupos.Name = "tabPagePorGrupos";
            this.tabPagePorGrupos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePorGrupos.Size = new System.Drawing.Size(852, 436);
            this.tabPagePorGrupos.TabIndex = 0;
            this.tabPagePorGrupos.Text = "Permisos Por Grupos";
            this.tabPagePorGrupos.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGVPermisosPorGrupos);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(846, 383);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Permisos de Interfacez";
            // 
            // dtGVPermisosPorGrupos
            // 
            this.dtGVPermisosPorGrupos.AllowUserToAddRows = false;
            this.dtGVPermisosPorGrupos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVPermisosPorGrupos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtGVPermisosPorGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVPermisosPorGrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVCodigoInterfaceG,
            this.DGCNombreInterfaceG,
            this.DGCTextoInterfaceG,
            this.DGCPermitirInsertarG,
            this.DGCPermitirEditarG,
            this.DGCPermitirEliminarG,
            this.DGCPermitirNavegarG,
            this.DGCPermitirReportesG});
            this.dtGVPermisosPorGrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVPermisosPorGrupos.Location = new System.Drawing.Point(3, 16);
            this.dtGVPermisosPorGrupos.Name = "dtGVPermisosPorGrupos";
            this.dtGVPermisosPorGrupos.RowHeadersVisible = false;
            this.dtGVPermisosPorGrupos.Size = new System.Drawing.Size(840, 364);
            this.dtGVPermisosPorGrupos.TabIndex = 2;
            // 
            // DGCPermitirInsertarG
            // 
            this.DGCPermitirInsertarG.DataPropertyName = "PermitirInsertar";
            this.DGCPermitirInsertarG.HeaderText = "Inserción";
            this.DGCPermitirInsertarG.Name = "DGCPermitirInsertarG";
            this.DGCPermitirInsertarG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCPermitirInsertarG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DGCPermitirEditarG
            // 
            this.DGCPermitirEditarG.DataPropertyName = "PermitirEditar";
            this.DGCPermitirEditarG.HeaderText = "Edición";
            this.DGCPermitirEditarG.Name = "DGCPermitirEditarG";
            this.DGCPermitirEditarG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCPermitirEditarG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DGCPermitirEliminarG
            // 
            this.DGCPermitirEliminarG.DataPropertyName = "PermitirEliminar";
            this.DGCPermitirEliminarG.HeaderText = "Eliminación";
            this.DGCPermitirEliminarG.Name = "DGCPermitirEliminarG";
            this.DGCPermitirEliminarG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCPermitirEliminarG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DGCPermitirNavegarG
            // 
            this.DGCPermitirNavegarG.DataPropertyName = "PermitirNavegar";
            this.DGCPermitirNavegarG.HeaderText = "Navegación";
            this.DGCPermitirNavegarG.Name = "DGCPermitirNavegarG";
            this.DGCPermitirNavegarG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCPermitirNavegarG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DGCPermitirReportesG
            // 
            this.DGCPermitirReportesG.DataPropertyName = "PermitirReportes";
            this.DGCPermitirReportesG.HeaderText = "Reportes";
            this.DGCPermitirReportesG.Name = "DGCPermitirReportesG";
            this.DGCPermitirReportesG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCPermitirReportesG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPermisosXGrupos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cBoxGruposUsuarios);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(846, 47);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione un grupo Para Ver";
            // 
            // btnPermisosXGrupos
            // 
            this.btnPermisosXGrupos.Location = new System.Drawing.Point(653, 15);
            this.btnPermisosXGrupos.Name = "btnPermisosXGrupos";
            this.btnPermisosXGrupos.Size = new System.Drawing.Size(122, 23);
            this.btnPermisosXGrupos.TabIndex = 2;
            this.btnPermisosXGrupos.Text = "Permiso por &Grupos";
            this.btnPermisosXGrupos.UseVisualStyleBackColor = true;
            this.btnPermisosXGrupos.Click += new System.EventHandler(this.btnPermisosXGrupos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de Groupos de Usuarios";
            // 
            // cBoxGruposUsuarios
            // 
            this.cBoxGruposUsuarios.FormattingEnabled = true;
            this.cBoxGruposUsuarios.Location = new System.Drawing.Point(170, 19);
            this.cBoxGruposUsuarios.Name = "cBoxGruposUsuarios";
            this.cBoxGruposUsuarios.Size = new System.Drawing.Size(218, 21);
            this.cBoxGruposUsuarios.TabIndex = 1;
            // 
            // tabPageParticulares
            // 
            this.tabPageParticulares.Controls.Add(this.gBoxListadoPermisos);
            this.tabPageParticulares.Controls.Add(this.pnlBotones);
            this.tabPageParticulares.Location = new System.Drawing.Point(4, 22);
            this.tabPageParticulares.Name = "tabPageParticulares";
            this.tabPageParticulares.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParticulares.Size = new System.Drawing.Size(852, 436);
            this.tabPageParticulares.TabIndex = 1;
            this.tabPageParticulares.Text = "Permisos Individuales";
            this.tabPageParticulares.UseVisualStyleBackColor = true;
            // 
            // gBoxListadoPermisos
            // 
            this.gBoxListadoPermisos.Controls.Add(this.cBoxReportes);
            this.gBoxListadoPermisos.Controls.Add(this.cBoxNavegar);
            this.gBoxListadoPermisos.Controls.Add(this.cBoxEliminar);
            this.gBoxListadoPermisos.Controls.Add(this.cBoxEditar);
            this.gBoxListadoPermisos.Controls.Add(this.cBoxInsertar);
            this.gBoxListadoPermisos.Controls.Add(this.dtGVPermisosIndividuales);
            this.gBoxListadoPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxListadoPermisos.Location = new System.Drawing.Point(3, 3);
            this.gBoxListadoPermisos.Name = "gBoxListadoPermisos";
            this.gBoxListadoPermisos.Size = new System.Drawing.Size(846, 400);
            this.gBoxListadoPermisos.TabIndex = 1;
            this.gBoxListadoPermisos.TabStop = false;
            this.gBoxListadoPermisos.Text = "Listado de Permisos de Usuario";
            // 
            // cBoxReportes
            // 
            this.cBoxReportes.AutoSize = true;
            this.cBoxReportes.Location = new System.Drawing.Point(807, 19);
            this.cBoxReportes.Name = "cBoxReportes";
            this.cBoxReportes.Size = new System.Drawing.Size(15, 14);
            this.cBoxReportes.TabIndex = 5;
            this.cBoxReportes.UseVisualStyleBackColor = true;
            this.cBoxReportes.CheckedChanged += new System.EventHandler(this.cBoxReportes_CheckedChanged);
            // 
            // cBoxNavegar
            // 
            this.cBoxNavegar.AutoSize = true;
            this.cBoxNavegar.Location = new System.Drawing.Point(715, 19);
            this.cBoxNavegar.Name = "cBoxNavegar";
            this.cBoxNavegar.Size = new System.Drawing.Size(15, 14);
            this.cBoxNavegar.TabIndex = 4;
            this.cBoxNavegar.UseVisualStyleBackColor = true;
            this.cBoxNavegar.CheckedChanged += new System.EventHandler(this.cBoxNavegar_CheckedChanged);
            // 
            // cBoxEliminar
            // 
            this.cBoxEliminar.AutoSize = true;
            this.cBoxEliminar.Location = new System.Drawing.Point(611, 19);
            this.cBoxEliminar.Name = "cBoxEliminar";
            this.cBoxEliminar.Size = new System.Drawing.Size(15, 14);
            this.cBoxEliminar.TabIndex = 3;
            this.cBoxEliminar.UseVisualStyleBackColor = true;
            this.cBoxEliminar.CheckedChanged += new System.EventHandler(this.cBoxEliminar_CheckedChanged);
            // 
            // cBoxEditar
            // 
            this.cBoxEditar.AutoSize = true;
            this.cBoxEditar.Location = new System.Drawing.Point(513, 19);
            this.cBoxEditar.Name = "cBoxEditar";
            this.cBoxEditar.Size = new System.Drawing.Size(15, 14);
            this.cBoxEditar.TabIndex = 2;
            this.cBoxEditar.UseVisualStyleBackColor = true;
            this.cBoxEditar.CheckedChanged += new System.EventHandler(this.cBoxEditar_CheckedChanged);
            // 
            // cBoxInsertar
            // 
            this.cBoxInsertar.AutoSize = true;
            this.cBoxInsertar.Location = new System.Drawing.Point(418, 19);
            this.cBoxInsertar.Name = "cBoxInsertar";
            this.cBoxInsertar.Size = new System.Drawing.Size(15, 14);
            this.cBoxInsertar.TabIndex = 1;
            this.cBoxInsertar.UseVisualStyleBackColor = true;
            this.cBoxInsertar.CheckedChanged += new System.EventHandler(this.cBoxInsertar_CheckedChanged);
            // 
            // dtGVPermisosIndividuales
            // 
            this.dtGVPermisosIndividuales.AllowUserToAddRows = false;
            this.dtGVPermisosIndividuales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVPermisosIndividuales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dtGVPermisosIndividuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVPermisosIndividuales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoInterfaceI,
            this.DGCNombreInterfaceI,
            this.DGCTextoInterfaceI,
            this.DGCPermitirInsertarI,
            this.DGCPermitirEditarI,
            this.DGCPermitirEliminarI,
            this.DGCPermitirNavegarI,
            this.DGCPermitirReportesI});
            this.dtGVPermisosIndividuales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVPermisosIndividuales.Location = new System.Drawing.Point(3, 16);
            this.dtGVPermisosIndividuales.Name = "dtGVPermisosIndividuales";
            this.dtGVPermisosIndividuales.RowHeadersVisible = false;
            this.dtGVPermisosIndividuales.Size = new System.Drawing.Size(840, 381);
            this.dtGVPermisosIndividuales.TabIndex = 0;
            // 
            // DGCPermitirInsertarI
            // 
            this.DGCPermitirInsertarI.DataPropertyName = "PermitirInsertar";
            this.DGCPermitirInsertarI.HeaderText = "Inserción";
            this.DGCPermitirInsertarI.Name = "DGCPermitirInsertarI";
            this.DGCPermitirInsertarI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCPermitirInsertarI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGCPermitirInsertarI.ToolTipText = "Permitir al Usuario Actual Insertar Registros";
            // 
            // DGCPermitirEditarI
            // 
            this.DGCPermitirEditarI.DataPropertyName = "PermitirEditar";
            this.DGCPermitirEditarI.HeaderText = "Edición";
            this.DGCPermitirEditarI.Name = "DGCPermitirEditarI";
            this.DGCPermitirEditarI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCPermitirEditarI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGCPermitirEditarI.ToolTipText = "Permitir al Usuario Actual Editar y Actualizar Registros";
            // 
            // DGCPermitirEliminarI
            // 
            this.DGCPermitirEliminarI.DataPropertyName = "PermitirEliminar";
            this.DGCPermitirEliminarI.HeaderText = "Eliminación";
            this.DGCPermitirEliminarI.Name = "DGCPermitirEliminarI";
            this.DGCPermitirEliminarI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCPermitirEliminarI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGCPermitirEliminarI.ToolTipText = "Permitir al Usuario Actual Eliminar Registros";
            // 
            // DGCPermitirNavegarI
            // 
            this.DGCPermitirNavegarI.DataPropertyName = "PermitirNavegar";
            this.DGCPermitirNavegarI.HeaderText = "Navegación";
            this.DGCPermitirNavegarI.Name = "DGCPermitirNavegarI";
            this.DGCPermitirNavegarI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCPermitirNavegarI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGCPermitirNavegarI.ToolTipText = "Permitir al Usuario Actual la Navegación por los Registros";
            // 
            // DGCPermitirReportesI
            // 
            this.DGCPermitirReportesI.DataPropertyName = "PermitirReportes";
            this.DGCPermitirReportesI.HeaderText = "Reportes";
            this.DGCPermitirReportesI.Name = "DGCPermitirReportesI";
            this.DGCPermitirReportesI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCPermitirReportesI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGCPermitirReportesI.ToolTipText = "Permitir al Usuario Actual ver Reportes de los Registros";
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnAceptar);
            this.pnlBotones.Controls.Add(this.btnModificar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotones.Location = new System.Drawing.Point(3, 403);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(846, 30);
            this.pnlBotones.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(768, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(687, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(606, 3);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoInterface";
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 97;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreInterface";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 96;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TextoInterface";
            this.dataGridViewTextBoxColumn3.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 97;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CodigoInterface";
            this.dataGridViewTextBoxColumn4.HeaderText = "Código";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.ToolTipText = "Código de Interfaz";
            this.dataGridViewTextBoxColumn4.Width = 97;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NombreInterface";
            this.dataGridViewTextBoxColumn5.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.ToolTipText = "Nombre interfaz";
            this.dataGridViewTextBoxColumn5.Width = 96;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TextoInterface ";
            this.dataGridViewTextBoxColumn6.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.ToolTipText = "Descripción de la Interfaz";
            this.dataGridViewTextBoxColumn6.Width = 97;
            // 
            // DGVCodigoInterfaceG
            // 
            this.DGVCodigoInterfaceG.DataPropertyName = "CodigoInterface";
            this.DGVCodigoInterfaceG.HeaderText = "Codigo";
            this.DGVCodigoInterfaceG.Name = "DGVCodigoInterfaceG";
            this.DGVCodigoInterfaceG.ReadOnly = true;
            // 
            // DGCNombreInterfaceG
            // 
            this.DGCNombreInterfaceG.DataPropertyName = "NombreInterface";
            this.DGCNombreInterfaceG.HeaderText = "Nombre";
            this.DGCNombreInterfaceG.Name = "DGCNombreInterfaceG";
            this.DGCNombreInterfaceG.ReadOnly = true;
            // 
            // DGCTextoInterfaceG
            // 
            this.DGCTextoInterfaceG.DataPropertyName = "TextoInterface";
            this.DGCTextoInterfaceG.HeaderText = "Descripción";
            this.DGCTextoInterfaceG.Name = "DGCTextoInterfaceG";
            this.DGCTextoInterfaceG.ReadOnly = true;
            // 
            // DGCCodigoInterfaceI
            // 
            this.DGCCodigoInterfaceI.DataPropertyName = "CodigoInterface";
            this.DGCCodigoInterfaceI.HeaderText = "Código";
            this.DGCCodigoInterfaceI.Name = "DGCCodigoInterfaceI";
            this.DGCCodigoInterfaceI.ReadOnly = true;
            this.DGCCodigoInterfaceI.ToolTipText = "Código de Interfaz";
            // 
            // DGCNombreInterfaceI
            // 
            this.DGCNombreInterfaceI.DataPropertyName = "NombreInterface";
            this.DGCNombreInterfaceI.HeaderText = "Nombre";
            this.DGCNombreInterfaceI.Name = "DGCNombreInterfaceI";
            this.DGCNombreInterfaceI.ReadOnly = true;
            this.DGCNombreInterfaceI.ToolTipText = "Nombre interfaz";
            // 
            // DGCTextoInterfaceI
            // 
            this.DGCTextoInterfaceI.DataPropertyName = "TextoInterface";
            this.DGCTextoInterfaceI.HeaderText = "Descripción";
            this.DGCTextoInterfaceI.Name = "DGCTextoInterfaceI";
            this.DGCTextoInterfaceI.ReadOnly = true;
            this.DGCTextoInterfaceI.ToolTipText = "Descripción de la Interfaz";
            // 
            // FUsuariosPermisosInterfaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 462);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FUsuariosPermisosInterfaces";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permisos del Usuario";
            this.Load += new System.EventHandler(this.FUsuariosPermisosInterfaces_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FUsuariosPermisosInterfaces_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPagePorGrupos.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPermisosPorGrupos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageParticulares.ResumeLayout(false);
            this.gBoxListadoPermisos.ResumeLayout(false);
            this.gBoxListadoPermisos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPermisosIndividuales)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPagePorGrupos;
        private System.Windows.Forms.DataGridView dtGVPermisosPorGrupos;
        private System.Windows.Forms.ComboBox cBoxGruposUsuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageParticulares;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gBoxListadoPermisos;
        private System.Windows.Forms.DataGridView dtGVPermisosIndividuales;
        private System.Windows.Forms.FlowLayoutPanel pnlBotones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVCodigoInterfaceG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreInterfaceG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCTextoInterfaceG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCPermitirInsertarG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCPermitirEditarG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCPermitirEliminarG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCPermitirNavegarG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCPermitirReportesG;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoInterfaceI;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreInterfaceI;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCTextoInterfaceI;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCPermitirInsertarI;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCPermitirEditarI;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCPermitirEliminarI;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCPermitirNavegarI;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCPermitirReportesI;
        private System.Windows.Forms.Button btnPermisosXGrupos;
        private System.Windows.Forms.CheckBox cBoxReportes;
        private System.Windows.Forms.CheckBox cBoxNavegar;
        private System.Windows.Forms.CheckBox cBoxEliminar;
        private System.Windows.Forms.CheckBox cBoxEditar;
        private System.Windows.Forms.CheckBox cBoxInsertar;
    }
}