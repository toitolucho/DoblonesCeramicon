namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FServicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FServicios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtBoxDescripcion = new System.Windows.Forms.TextBox();
            this.txtBoxPrecioServicio = new System.Windows.Forms.TextBox();
            this.txtBoxCodigoServicio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxNombreServicio = new System.Windows.Forms.TextBox();
            this.cBoxNombreServicio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bCerrar = new System.Windows.Forms.Button();
            this.imgListbancos = new System.Windows.Forms.ImageList(this.components);
            this.bCancelar = new System.Windows.Forms.Button();
            this.bNuevo = new System.Windows.Forms.Button();
            this.bEditar = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.bEliminar = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtGVServicios = new System.Windows.Forms.DataGridView();
            this.lblCantidadServicios = new System.Windows.Forms.Label();
            this.bindingSourceServicio = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoTipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceServicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(546, 214);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtBoxDescripcion);
            this.tabPage1.Controls.Add(this.txtBoxPrecioServicio);
            this.tabPage1.Controls.Add(this.txtBoxCodigoServicio);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtBoxNombreServicio);
            this.tabPage1.Controls.Add(this.cBoxNombreServicio);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.bCerrar);
            this.tabPage1.Controls.Add(this.bCancelar);
            this.tabPage1.Controls.Add(this.bNuevo);
            this.tabPage1.Controls.Add(this.bEditar);
            this.tabPage1.Controls.Add(this.bAceptar);
            this.tabPage1.Controls.Add(this.bEliminar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(538, 188);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detalle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtBoxDescripcion
            // 
            this.txtBoxDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxDescripcion.Location = new System.Drawing.Point(80, 92);
            this.txtBoxDescripcion.Multiline = true;
            this.txtBoxDescripcion.Name = "txtBoxDescripcion";
            this.txtBoxDescripcion.Size = new System.Drawing.Size(430, 58);
            this.txtBoxDescripcion.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtBoxDescripcion, "Descripción u Observación para el Servicio");
            // 
            // txtBoxPrecioServicio
            // 
            this.txtBoxPrecioServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxPrecioServicio.Location = new System.Drawing.Point(368, 65);
            this.txtBoxPrecioServicio.Name = "txtBoxPrecioServicio";
            this.txtBoxPrecioServicio.Size = new System.Drawing.Size(142, 20);
            this.txtBoxPrecioServicio.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtBoxPrecioServicio, "Precio Unitario del Servicio");
            // 
            // txtBoxCodigoServicio
            // 
            this.txtBoxCodigoServicio.Location = new System.Drawing.Point(80, 13);
            this.txtBoxCodigoServicio.Name = "txtBoxCodigoServicio";
            this.txtBoxCodigoServicio.ReadOnly = true;
            this.txtBoxCodigoServicio.Size = new System.Drawing.Size(115, 20);
            this.txtBoxCodigoServicio.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtBoxCodigoServicio, "Código Identificador del Servicio");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Descripcion";
            // 
            // txtBoxNombreServicio
            // 
            this.txtBoxNombreServicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxNombreServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBoxNombreServicio.Location = new System.Drawing.Point(80, 39);
            this.txtBoxNombreServicio.Name = "txtBoxNombreServicio";
            this.txtBoxNombreServicio.Size = new System.Drawing.Size(430, 20);
            this.txtBoxNombreServicio.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtBoxNombreServicio, "Nombre del Servicio");
            // 
            // cBoxNombreServicio
            // 
            this.cBoxNombreServicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxNombreServicio.FormattingEnabled = true;
            this.cBoxNombreServicio.Location = new System.Drawing.Point(80, 65);
            this.cBoxNombreServicio.Name = "cBoxNombreServicio";
            this.cBoxNombreServicio.Size = new System.Drawing.Size(235, 21);
            this.cBoxNombreServicio.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cBoxNombreServicio, "Tipo de Servicio");
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Precio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Codigo";
            // 
            // bCerrar
            // 
            this.bCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCerrar.ImageIndex = 8;
            this.bCerrar.ImageList = this.imgListbancos;
            this.bCerrar.Location = new System.Drawing.Point(467, 156);
            this.bCerrar.Name = "bCerrar";
            this.bCerrar.Size = new System.Drawing.Size(65, 29);
            this.bCerrar.TabIndex = 10;
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
            this.bCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCancelar.ImageIndex = 0;
            this.bCancelar.ImageList = this.imgListbancos;
            this.bCancelar.Location = new System.Drawing.Point(395, 156);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(70, 29);
            this.bCancelar.TabIndex = 9;
            this.bCancelar.Text = "&Cancelar";
            this.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bNuevo
            // 
            this.bNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bNuevo.ImageIndex = 4;
            this.bNuevo.ImageList = this.imgListbancos;
            this.bNuevo.Location = new System.Drawing.Point(117, 156);
            this.bNuevo.Name = "bNuevo";
            this.bNuevo.Size = new System.Drawing.Size(65, 29);
            this.bNuevo.TabIndex = 5;
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
            this.bEditar.Location = new System.Drawing.Point(184, 156);
            this.bEditar.Name = "bEditar";
            this.bEditar.Size = new System.Drawing.Size(65, 29);
            this.bEditar.TabIndex = 6;
            this.bEditar.Text = "&Editar";
            this.bEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bEditar.UseVisualStyleBackColor = true;
            this.bEditar.Click += new System.EventHandler(this.bEditar_Click);
            // 
            // bAceptar
            // 
            this.bAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAceptar.ImageIndex = 3;
            this.bAceptar.ImageList = this.imgListbancos;
            this.bAceptar.Location = new System.Drawing.Point(323, 156);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(70, 29);
            this.bAceptar.TabIndex = 8;
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
            this.bEliminar.Location = new System.Drawing.Point(251, 156);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(70, 29);
            this.bEliminar.TabIndex = 7;
            this.bEliminar.Text = "E&liminar";
            this.bEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bEliminar.UseVisualStyleBackColor = true;
            this.bEliminar.Click += new System.EventHandler(this.bEliminar_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtGVServicios);
            this.tabPage2.Controls.Add(this.lblCantidadServicios);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(538, 188);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lista";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtGVServicios
            // 
            this.dtGVServicios.AllowUserToAddRows = false;
            this.dtGVServicios.AllowUserToResizeRows = false;
            this.dtGVServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVServicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoServicio,
            this.DGCNombreServicio,
            this.DGCCodigoTipoServicio,
            this.DGCPrecioUnitario,
            this.DGCDescripcion});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGVServicios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVServicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVServicios.Location = new System.Drawing.Point(3, 3);
            this.dtGVServicios.MultiSelect = false;
            this.dtGVServicios.Name = "dtGVServicios";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVServicios.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtGVServicios.RowHeadersVisible = false;
            this.dtGVServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVServicios.Size = new System.Drawing.Size(532, 169);
            this.dtGVServicios.TabIndex = 0;
            this.dtGVServicios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVServicios_CellDoubleClick);
            // 
            // lblCantidadServicios
            // 
            this.lblCantidadServicios.AutoSize = true;
            this.lblCantidadServicios.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCantidadServicios.Location = new System.Drawing.Point(3, 172);
            this.lblCantidadServicios.Name = "lblCantidadServicios";
            this.lblCantidadServicios.Size = new System.Drawing.Size(35, 13);
            this.lblCantidadServicios.TabIndex = 1;
            this.lblCantidadServicios.Text = "label6";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoServicio";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cod";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreServicio";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CodigoTipoServicio";
            this.dataGridViewTextBoxColumn3.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 151;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PrecioUnitario";
            this.dataGridViewTextBoxColumn4.HeaderText = "Precio";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 152;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn5.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 151;
            // 
            // DGCCodigoServicio
            // 
            this.DGCCodigoServicio.DataPropertyName = "CodigoServicio";
            this.DGCCodigoServicio.HeaderText = "Cod";
            this.DGCCodigoServicio.Name = "DGCCodigoServicio";
            this.DGCCodigoServicio.Visible = false;
            // 
            // DGCNombreServicio
            // 
            this.DGCNombreServicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DGCNombreServicio.DataPropertyName = "NombreServicio";
            this.DGCNombreServicio.HeaderText = "Nombre";
            this.DGCNombreServicio.Name = "DGCNombreServicio";
            this.DGCNombreServicio.Width = 75;
            // 
            // DGCCodigoTipoServicio
            // 
            this.DGCCodigoTipoServicio.DataPropertyName = "CodigoTipoServicio";
            this.DGCCodigoTipoServicio.HeaderText = "Tipo";
            this.DGCCodigoTipoServicio.Name = "DGCCodigoTipoServicio";
            // 
            // DGCPrecioUnitario
            // 
            this.DGCPrecioUnitario.DataPropertyName = "PrecioUnitario";
            this.DGCPrecioUnitario.HeaderText = "Precio";
            this.DGCPrecioUnitario.Name = "DGCPrecioUnitario";
            // 
            // DGCDescripcion
            // 
            this.DGCDescripcion.DataPropertyName = "Descripcion";
            this.DGCDescripcion.HeaderText = "Descripcion";
            this.DGCDescripcion.Name = "DGCDescripcion";
            // 
            // FServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 214);
            this.Controls.Add(this.tabControl1);
            this.Name = "FServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servicios";
            this.Load += new System.EventHandler(this.FServicios_Load);
            this.Shown += new System.EventHandler(this.FServicios_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FServicios_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceServicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bCerrar;
        private System.Windows.Forms.ImageList imgListbancos;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bNuevo;
        private System.Windows.Forms.Button bEditar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.TextBox txtBoxNombreServicio;
        private System.Windows.Forms.ComboBox cBoxNombreServicio;
        private System.Windows.Forms.TextBox txtBoxDescripcion;
        private System.Windows.Forms.TextBox txtBoxPrecioServicio;
        private System.Windows.Forms.TextBox txtBoxCodigoServicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtGVServicios;
        private System.Windows.Forms.Label lblCantidadServicios;
        private System.Windows.Forms.BindingSource bindingSourceServicio;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoTipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDescripcion;
    }
}