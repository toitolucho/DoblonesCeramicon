namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FBuscarClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBuscarClientes));
            this.bSClientes = new System.Windows.Forms.BindingSource(this.components);
            this.sSBuscarClientes = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bBuscar = new System.Windows.Forms.Button();
            this.tBTextoBusqueda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cBBusquedaExacta = new System.Windows.Forms.CheckBox();
            this.cBBuscarPor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dGVResultadoBusquedaClientes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bSClientes)).BeginInit();
            this.sSBuscarClientes.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVResultadoBusquedaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // sSBuscarClientes
            // 
            this.sSBuscarClientes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.sSBuscarClientes.Location = new System.Drawing.Point(0, 226);
            this.sSBuscarClientes.MinimumSize = new System.Drawing.Size(0, 22);
            this.sSBuscarClientes.Name = "sSBuscarClientes";
            this.sSBuscarClientes.Size = new System.Drawing.Size(801, 22);
            this.sSBuscarClientes.TabIndex = 16;
            this.sSBuscarClientes.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bBuscar);
            this.panel2.Controls.Add(this.tBTextoBusqueda);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cBBusquedaExacta);
            this.panel2.Controls.Add(this.cBBuscarPor);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(801, 72);
            this.panel2.TabIndex = 15;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // bBuscar
            // 
            this.bBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bBuscar.ImageIndex = 0;
            this.bBuscar.ImageList = this.imageList1;
            this.bBuscar.Location = new System.Drawing.Point(385, 38);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(75, 31);
            this.bBuscar.TabIndex = 3;
            this.bBuscar.Text = "&Buscar";
            this.bBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bBuscar.UseVisualStyleBackColor = true;
            this.bBuscar.Click += new System.EventHandler(this.bBuscar_Click);
            // 
            // tBTextoBusqueda
            // 
            this.tBTextoBusqueda.Location = new System.Drawing.Point(121, 43);
            this.tBTextoBusqueda.Name = "tBTextoBusqueda";
            this.tBTextoBusqueda.Size = new System.Drawing.Size(258, 20);
            this.tBTextoBusqueda.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Texto de busqueda:";
            // 
            // cBBusquedaExacta
            // 
            this.cBBusquedaExacta.AutoSize = true;
            this.cBBusquedaExacta.Location = new System.Drawing.Point(237, 16);
            this.cBBusquedaExacta.Name = "cBBusquedaExacta";
            this.cBBusquedaExacta.Size = new System.Drawing.Size(142, 17);
            this.cBBusquedaExacta.TabIndex = 1;
            this.cBBusquedaExacta.Text = "¿Buscar Texto Identico?";
            this.cBBusquedaExacta.UseVisualStyleBackColor = true;
            // 
            // cBBuscarPor
            // 
            this.cBBuscarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBBuscarPor.FormattingEnabled = true;
            this.cBBuscarPor.Items.AddRange(new object[] {
            "Codigo cliente",
            "Nombre cliente",
            "Nombre representante",
            "NIT Cliente",
            "Teléfono",
            "Parte Nombre cliente"});
            this.cBBuscarPor.Location = new System.Drawing.Point(79, 12);
            this.cBBuscarPor.Name = "cBBuscarPor";
            this.cBBuscarPor.Size = new System.Drawing.Size(152, 21);
            this.cBBuscarPor.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar por:";
            // 
            // dGVResultadoBusquedaClientes
            // 
            this.dGVResultadoBusquedaClientes.AllowUserToAddRows = false;
            this.dGVResultadoBusquedaClientes.AllowUserToDeleteRows = false;
            this.dGVResultadoBusquedaClientes.AllowUserToResizeRows = false;
            this.dGVResultadoBusquedaClientes.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVResultadoBusquedaClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVResultadoBusquedaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVResultadoBusquedaClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dGVResultadoBusquedaClientes.DataSource = this.bSClientes;
            this.dGVResultadoBusquedaClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVResultadoBusquedaClientes.Location = new System.Drawing.Point(0, 72);
            this.dGVResultadoBusquedaClientes.MultiSelect = false;
            this.dGVResultadoBusquedaClientes.Name = "dGVResultadoBusquedaClientes";
            this.dGVResultadoBusquedaClientes.ReadOnly = true;
            this.dGVResultadoBusquedaClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dGVResultadoBusquedaClientes.RowHeadersVisible = false;
            this.dGVResultadoBusquedaClientes.RowTemplate.ReadOnly = true;
            this.dGVResultadoBusquedaClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVResultadoBusquedaClientes.Size = new System.Drawing.Size(801, 154);
            this.dGVResultadoBusquedaClientes.TabIndex = 17;
            this.dGVResultadoBusquedaClientes.VirtualMode = true;
            this.dGVResultadoBusquedaClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVResultadoBusquedaClientes_CellDoubleClick);
            this.dGVResultadoBusquedaClientes.DoubleClick += new System.EventHandler(this.dGVResultadoBusquedaClientes_DoubleClick);
            this.dGVResultadoBusquedaClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVResultadoBusquedaClientes_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CodigoCliente";
            this.Column1.HeaderText = "Cod. Clie.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "NombreCliente";
            this.Column2.HeaderText = "Nombre cliente";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 250;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NombreRepresentante";
            this.Column3.HeaderText = "Nombre representante";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "NITCLiente";
            this.Column4.HeaderText = "NIT";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Telefono";
            this.Column5.HeaderText = "Telefono(s)";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoCliente";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cod. Clie.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreCliente";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre cliente";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NombreRepresentante";
            this.dataGridViewTextBoxColumn3.HeaderText = "Nombre representante";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NITCLiente";
            this.dataGridViewTextBoxColumn4.HeaderText = "NIT";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Telefono";
            this.dataGridViewTextBoxColumn5.HeaderText = "Telefono(s)";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Find.ico");
            // 
            // FBuscarClientes
            // 
            this.AcceptButton = this.bBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 248);
            this.Controls.Add(this.dGVResultadoBusquedaClientes);
            this.Controls.Add(this.sSBuscarClientes);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FBuscarClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar clientes";
            this.Load += new System.EventHandler(this.FBuscarClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bSClientes)).EndInit();
            this.sSBuscarClientes.ResumeLayout(false);
            this.sSBuscarClientes.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVResultadoBusquedaClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sSBuscarClientes;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bBuscar;
        private System.Windows.Forms.TextBox tBTextoBusqueda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cBBusquedaExacta;
        private System.Windows.Forms.ComboBox cBBuscarPor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bSClientes;
        private System.Windows.Forms.DataGridView dGVResultadoBusquedaClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ImageList imageList1;
    }
}