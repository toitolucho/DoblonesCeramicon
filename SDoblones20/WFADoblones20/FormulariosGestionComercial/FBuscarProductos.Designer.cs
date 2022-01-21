namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FBuscarProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBuscarProductos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bSProductos = new System.Windows.Forms.BindingSource(this.components);
            this.sSBuscarProductos = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bBuscar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tBTextoBusqueda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cBBusquedaExacta = new System.Windows.Forms.CheckBox();
            this.cBBuscarPor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dGVResultadoBusquedaProductos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bSProductos)).BeginInit();
            this.sSBuscarProductos.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVResultadoBusquedaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // sSBuscarProductos
            // 
            this.sSBuscarProductos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.sSBuscarProductos.Location = new System.Drawing.Point(0, 226);
            this.sSBuscarProductos.MinimumSize = new System.Drawing.Size(0, 22);
            this.sSBuscarProductos.Name = "sSBuscarProductos";
            this.sSBuscarProductos.Size = new System.Drawing.Size(801, 22);
            this.sSBuscarProductos.TabIndex = 16;
            this.sSBuscarProductos.Text = "statusStrip1";
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
            // 
            // bBuscar
            // 
            this.bBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bBuscar.ImageIndex = 0;
            this.bBuscar.ImageList = this.imageList1;
            this.bBuscar.Location = new System.Drawing.Point(385, 38);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(72, 30);
            this.bBuscar.TabIndex = 3;
            this.bBuscar.Text = "Buscar";
            this.bBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bBuscar.UseVisualStyleBackColor = true;
            this.bBuscar.Click += new System.EventHandler(this.bBuscar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "search.ico");
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
            "Código producto",
            "Código fabrica",
            "Nombre producto",
            "Nombre producto 1",
            "Nombre producto 2"});
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
            // dGVResultadoBusquedaProductos
            // 
            this.dGVResultadoBusquedaProductos.AllowUserToAddRows = false;
            this.dGVResultadoBusquedaProductos.AllowUserToDeleteRows = false;
            this.dGVResultadoBusquedaProductos.AllowUserToResizeRows = false;
            this.dGVResultadoBusquedaProductos.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVResultadoBusquedaProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVResultadoBusquedaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVResultadoBusquedaProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dGVResultadoBusquedaProductos.DataSource = this.bSProductos;
            this.dGVResultadoBusquedaProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVResultadoBusquedaProductos.Location = new System.Drawing.Point(0, 72);
            this.dGVResultadoBusquedaProductos.MultiSelect = false;
            this.dGVResultadoBusquedaProductos.Name = "dGVResultadoBusquedaProductos";
            this.dGVResultadoBusquedaProductos.ReadOnly = true;
            this.dGVResultadoBusquedaProductos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dGVResultadoBusquedaProductos.RowHeadersVisible = false;
            this.dGVResultadoBusquedaProductos.RowTemplate.ReadOnly = true;
            this.dGVResultadoBusquedaProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVResultadoBusquedaProductos.Size = new System.Drawing.Size(801, 154);
            this.dGVResultadoBusquedaProductos.TabIndex = 17;
            this.dGVResultadoBusquedaProductos.VirtualMode = true;
            this.dGVResultadoBusquedaProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVResultadoBusquedaProductos_CellDoubleClick);
            this.dGVResultadoBusquedaProductos.DoubleClick += new System.EventHandler(this.dGVResultadoBusquedaProductos_DoubleClick);
            this.dGVResultadoBusquedaProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVResultadoBusquedaProductos_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CodigoProducto";
            this.Column1.HeaderText = "Cod. Prod.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CodigoProductoFabricante";
            this.Column2.HeaderText = "Cod. Fabrica";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NombreProducto";
            this.Column3.HeaderText = "Nombre producto";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "NombreProducto1";
            this.Column4.HeaderText = "Nombre producto 1";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 250;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "NombreProducto2";
            this.Column5.HeaderText = "Nombre producto 2";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 250;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Descripcion";
            this.Column6.HeaderText = "Descripcion";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // FBuscarProductos
            // 
            this.AcceptButton = this.bBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 248);
            this.Controls.Add(this.dGVResultadoBusquedaProductos);
            this.Controls.Add(this.sSBuscarProductos);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FBuscarProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar productos";
            this.Load += new System.EventHandler(this.FBuscarProductos_Load);
            this.Shown += new System.EventHandler(this.FBuscarProductos_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FBuscarProductos_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.bSProductos)).EndInit();
            this.sSBuscarProductos.ResumeLayout(false);
            this.sSBuscarProductos.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVResultadoBusquedaProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVResultadoBusquedaProductos;
        private System.Windows.Forms.BindingSource bSProductos;
        private System.Windows.Forms.StatusStrip sSBuscarProductos;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bBuscar;
        private System.Windows.Forms.TextBox tBTextoBusqueda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cBBusquedaExacta;
        private System.Windows.Forms.ComboBox cBBuscarPor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ImageList imageList1;
    }
}