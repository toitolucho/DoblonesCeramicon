namespace WFADoblones20.FormulariosSistema
{
    partial class FSistemasInterfaces
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gBoxAmbitoBusqueda = new System.Windows.Forms.GroupBox();
            this.checkExactamenteIgual = new System.Windows.Forms.CheckBox();
            this.cBoxBuscarPor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtTextoBusqueda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGVListadoInterfaces = new System.Windows.Forms.DataGridView();
            this.DGCCodigoInterface = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCTexto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoTipoInterface = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gBoxAmbitoBusqueda.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoInterfaces)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gBoxAmbitoBusqueda);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(591, 469);
            this.splitContainer1.SplitterDistance = 69;
            this.splitContainer1.TabIndex = 0;
            // 
            // gBoxAmbitoBusqueda
            // 
            this.gBoxAmbitoBusqueda.Controls.Add(this.checkExactamenteIgual);
            this.gBoxAmbitoBusqueda.Controls.Add(this.cBoxBuscarPor);
            this.gBoxAmbitoBusqueda.Controls.Add(this.label2);
            this.gBoxAmbitoBusqueda.Controls.Add(this.btnBuscar);
            this.gBoxAmbitoBusqueda.Controls.Add(this.txtTextoBusqueda);
            this.gBoxAmbitoBusqueda.Controls.Add(this.label1);
            this.gBoxAmbitoBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxAmbitoBusqueda.Location = new System.Drawing.Point(0, 0);
            this.gBoxAmbitoBusqueda.Name = "gBoxAmbitoBusqueda";
            this.gBoxAmbitoBusqueda.Size = new System.Drawing.Size(591, 69);
            this.gBoxAmbitoBusqueda.TabIndex = 0;
            this.gBoxAmbitoBusqueda.TabStop = false;
            this.gBoxAmbitoBusqueda.Text = "Ambito Busqueda :";
            // 
            // checkExactamenteIgual
            // 
            this.checkExactamenteIgual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkExactamenteIgual.AutoSize = true;
            this.checkExactamenteIgual.Location = new System.Drawing.Point(465, 21);
            this.checkExactamenteIgual.Name = "checkExactamenteIgual";
            this.checkExactamenteIgual.Size = new System.Drawing.Size(114, 17);
            this.checkExactamenteIgual.TabIndex = 5;
            this.checkExactamenteIgual.Text = "&Exactamente Igual";
            this.checkExactamenteIgual.UseVisualStyleBackColor = true;
            // 
            // cBoxBuscarPor
            // 
            this.cBoxBuscarPor.FormattingEnabled = true;
            this.cBoxBuscarPor.Items.AddRange(new object[] {
            "CodigoInterface",
            "NombreInterface",
            "TextoInterface",
            "CodigoTipoInterface"});
            this.cBoxBuscarPor.Location = new System.Drawing.Point(78, 17);
            this.cBoxBuscarPor.Name = "cBoxBuscarPor";
            this.cBoxBuscarPor.Size = new System.Drawing.Size(134, 21);
            this.cBoxBuscarPor.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Buscar Por :";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(504, 41);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtTextoBusqueda
            // 
            this.txtTextoBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextoBusqueda.Location = new System.Drawing.Point(78, 44);
            this.txtTextoBusqueda.Name = "txtTextoBusqueda";
            this.txtTextoBusqueda.Size = new System.Drawing.Size(420, 20);
            this.txtTextoBusqueda.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGVListadoInterfaces);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(591, 357);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Interfaces";
            // 
            // dtGVListadoInterfaces
            // 
            this.dtGVListadoInterfaces.AllowUserToAddRows = false;
            this.dtGVListadoInterfaces.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVListadoInterfaces.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtGVListadoInterfaces.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dtGVListadoInterfaces.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVListadoInterfaces.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVListadoInterfaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVListadoInterfaces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoInterface,
            this.Nombre,
            this.DGCTexto,
            this.DGCCodigoTipoInterface});
            this.dtGVListadoInterfaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVListadoInterfaces.Location = new System.Drawing.Point(3, 16);
            this.dtGVListadoInterfaces.Name = "dtGVListadoInterfaces";
            this.dtGVListadoInterfaces.RowHeadersVisible = false;
            this.dtGVListadoInterfaces.Size = new System.Drawing.Size(585, 338);
            this.dtGVListadoInterfaces.TabIndex = 0;
            this.dtGVListadoInterfaces.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVListadoInterfaces_CellDoubleClick);
            // 
            // DGCCodigoInterface
            // 
            this.DGCCodigoInterface.HeaderText = "Codigo";
            this.DGCCodigoInterface.Name = "DGCCodigoInterface";
            this.DGCCodigoInterface.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // DGCTexto
            // 
            this.DGCTexto.HeaderText = "Texto ";
            this.DGCTexto.Name = "DGCTexto";
            this.DGCTexto.ReadOnly = true;
            // 
            // DGCCodigoTipoInterface
            // 
            this.DGCCodigoTipoInterface.HeaderText = "Tipo Interface";
            this.DGCCodigoTipoInterface.Name = "DGCCodigoTipoInterface";
            this.DGCCodigoTipoInterface.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNuevo);
            this.flowLayoutPanel1.Controls.Add(this.btnEditar);
            this.flowLayoutPanel1.Controls.Add(this.btnEliminar);
            this.flowLayoutPanel1.Controls.Add(this.btnReporte);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 357);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(591, 39);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(513, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(432, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(351, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "E&liminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(270, 3);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(75, 23);
            this.btnReporte.TabIndex = 3;
            this.btnReporte.Text = "&Reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 469);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(591, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(72, 17);
            this.toolStripStatusLabel1.Text = "Nro Registros";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel2.Text = "253";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(155, 17);
            this.toolStripStatusLabel3.Text = "Doble click para Editar Registro";
            // 
            // FSistemasInterfaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 491);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FSistemasInterfaces";
            this.Text = "Interfaces Del Sistema";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gBoxAmbitoBusqueda.ResumeLayout(false);
            this.gBoxAmbitoBusqueda.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoInterfaces)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gBoxAmbitoBusqueda;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtTextoBusqueda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtGVListadoInterfaces;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoInterface;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCTexto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoTipoInterface;
        private System.Windows.Forms.ComboBox cBoxBuscarPor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkExactamenteIgual;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    }
}