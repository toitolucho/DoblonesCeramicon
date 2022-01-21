namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FProductosEmpresasLista
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FProductosEmpresasLista));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.btMostrarDetalle = new System.Windows.Forms.Button();
            this.dgvProductosEmpresasLista = new System.Windows.Forms.DataGridView();
            this.dgvcNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCodigoProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btImprimirListaDetalle = new System.Windows.Forms.Button();
            this.lbListaDetalleInfo = new System.Windows.Forms.Label();
            this.btImprimir = new System.Windows.Forms.Button();
            this.dgvProductosEmpresasListaDetalle = new System.Windows.Forms.DataGridView();
            this.dgvcCodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDescripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcPrecioProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscbEmpresas = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtImportar = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosEmpresasLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosEmpresasListaDetalle)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(12, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btLimpiar);
            this.splitContainer1.Panel1.Controls.Add(this.btMostrarDetalle);
            this.splitContainer1.Panel1.Controls.Add(this.dgvProductosEmpresasLista);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btImprimirListaDetalle);
            this.splitContainer1.Panel2.Controls.Add(this.lbListaDetalleInfo);
            this.splitContainer1.Panel2.Controls.Add(this.btImprimir);
            this.splitContainer1.Panel2.Controls.Add(this.dgvProductosEmpresasListaDetalle);
            this.splitContainer1.Size = new System.Drawing.Size(768, 513);
            this.splitContainer1.SplitterDistance = 256;
            this.splitContainer1.TabIndex = 6;
            // 
            // btLimpiar
            // 
            this.btLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLimpiar.Location = new System.Drawing.Point(82, 483);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btLimpiar.TabIndex = 1;
            this.btLimpiar.Text = "Limpiar";
            this.btLimpiar.UseVisualStyleBackColor = true;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // btMostrarDetalle
            // 
            this.btMostrarDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btMostrarDetalle.Location = new System.Drawing.Point(163, 483);
            this.btMostrarDetalle.Name = "btMostrarDetalle";
            this.btMostrarDetalle.Size = new System.Drawing.Size(86, 23);
            this.btMostrarDetalle.TabIndex = 2;
            this.btMostrarDetalle.Text = "Mostrar detalle";
            this.btMostrarDetalle.UseVisualStyleBackColor = true;
            this.btMostrarDetalle.Click += new System.EventHandler(this.btMostrarDetalle_Click);
            // 
            // dgvProductosEmpresasLista
            // 
            this.dgvProductosEmpresasLista.AllowUserToAddRows = false;
            this.dgvProductosEmpresasLista.AllowUserToDeleteRows = false;
            this.dgvProductosEmpresasLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductosEmpresasLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductosEmpresasLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosEmpresasLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcNumero,
            this.dgvcCodigoProveedor,
            this.dgvcDescripcion,
            this.dgvcFecha});
            this.dgvProductosEmpresasLista.Location = new System.Drawing.Point(1, -2);
            this.dgvProductosEmpresasLista.MultiSelect = false;
            this.dgvProductosEmpresasLista.Name = "dgvProductosEmpresasLista";
            this.dgvProductosEmpresasLista.ReadOnly = true;
            this.dgvProductosEmpresasLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductosEmpresasLista.ShowEditingIcon = false;
            this.dgvProductosEmpresasLista.Size = new System.Drawing.Size(251, 479);
            this.dgvProductosEmpresasLista.TabIndex = 0;
            this.dgvProductosEmpresasLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductosEmpresasLista_CellDoubleClick);
            // 
            // dgvcNumero
            // 
            this.dgvcNumero.DataPropertyName = "NumeroLista";
            this.dgvcNumero.HeaderText = "Nº";
            this.dgvcNumero.Name = "dgvcNumero";
            this.dgvcNumero.ReadOnly = true;
            this.dgvcNumero.Visible = false;
            // 
            // dgvcCodigoProveedor
            // 
            this.dgvcCodigoProveedor.DataPropertyName = "CodigoProveedor";
            this.dgvcCodigoProveedor.HeaderText = "Proveedor";
            this.dgvcCodigoProveedor.Name = "dgvcCodigoProveedor";
            this.dgvcCodigoProveedor.ReadOnly = true;
            this.dgvcCodigoProveedor.Visible = false;
            // 
            // dgvcDescripcion
            // 
            this.dgvcDescripcion.DataPropertyName = "Descripcion";
            this.dgvcDescripcion.HeaderText = "Descripción";
            this.dgvcDescripcion.MinimumWidth = 100;
            this.dgvcDescripcion.Name = "dgvcDescripcion";
            this.dgvcDescripcion.ReadOnly = true;
            // 
            // dgvcFecha
            // 
            this.dgvcFecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dgvcFecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvcFecha.HeaderText = "Fecha";
            this.dgvcFecha.MinimumWidth = 32;
            this.dgvcFecha.Name = "dgvcFecha";
            this.dgvcFecha.ReadOnly = true;
            // 
            // btImprimirListaDetalle
            // 
            this.btImprimirListaDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btImprimirListaDetalle.Location = new System.Drawing.Point(345, 483);
            this.btImprimirListaDetalle.Name = "btImprimirListaDetalle";
            this.btImprimirListaDetalle.Size = new System.Drawing.Size(75, 23);
            this.btImprimirListaDetalle.TabIndex = 1;
            this.btImprimirListaDetalle.Text = "Limpiar";
            this.btImprimirListaDetalle.UseVisualStyleBackColor = true;
            this.btImprimirListaDetalle.Click += new System.EventHandler(this.btImprimirListaDetalle_Click);
            // 
            // lbListaDetalleInfo
            // 
            this.lbListaDetalleInfo.AutoSize = true;
            this.lbListaDetalleInfo.Location = new System.Drawing.Point(3, 0);
            this.lbListaDetalleInfo.Name = "lbListaDetalleInfo";
            this.lbListaDetalleInfo.Size = new System.Drawing.Size(62, 13);
            this.lbListaDetalleInfo.TabIndex = 2;
            this.lbListaDetalleInfo.Text = "Información";
            // 
            // btImprimir
            // 
            this.btImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btImprimir.Location = new System.Drawing.Point(426, 483);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(75, 23);
            this.btImprimir.TabIndex = 2;
            this.btImprimir.Text = "Imprimir";
            this.btImprimir.UseVisualStyleBackColor = true;
            // 
            // dgvProductosEmpresasListaDetalle
            // 
            this.dgvProductosEmpresasListaDetalle.AllowUserToAddRows = false;
            this.dgvProductosEmpresasListaDetalle.AllowUserToDeleteRows = false;
            this.dgvProductosEmpresasListaDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductosEmpresasListaDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductosEmpresasListaDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosEmpresasListaDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcCodigoProducto,
            this.dgvcNombreProducto,
            this.dgvcDescripcionProducto,
            this.dgvcPrecioProducto});
            this.dgvProductosEmpresasListaDetalle.Location = new System.Drawing.Point(2, 16);
            this.dgvProductosEmpresasListaDetalle.Name = "dgvProductosEmpresasListaDetalle";
            this.dgvProductosEmpresasListaDetalle.ReadOnly = true;
            this.dgvProductosEmpresasListaDetalle.ShowEditingIcon = false;
            this.dgvProductosEmpresasListaDetalle.Size = new System.Drawing.Size(499, 461);
            this.dgvProductosEmpresasListaDetalle.TabIndex = 0;
            // 
            // dgvcCodigoProducto
            // 
            this.dgvcCodigoProducto.DataPropertyName = "CodigoProducto";
            this.dgvcCodigoProducto.HeaderText = "Código";
            this.dgvcCodigoProducto.Name = "dgvcCodigoProducto";
            this.dgvcCodigoProducto.ReadOnly = true;
            // 
            // dgvcNombreProducto
            // 
            this.dgvcNombreProducto.DataPropertyName = "NombreProducto";
            this.dgvcNombreProducto.HeaderText = "Nombre";
            this.dgvcNombreProducto.Name = "dgvcNombreProducto";
            this.dgvcNombreProducto.ReadOnly = true;
            // 
            // dgvcDescripcionProducto
            // 
            this.dgvcDescripcionProducto.DataPropertyName = "DescripcionProducto";
            this.dgvcDescripcionProducto.HeaderText = "Descripción";
            this.dgvcDescripcionProducto.Name = "dgvcDescripcionProducto";
            this.dgvcDescripcionProducto.ReadOnly = true;
            // 
            // dgvcPrecioProducto
            // 
            this.dgvcPrecioProducto.DataPropertyName = "PrecioProducto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dgvcPrecioProducto.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcPrecioProducto.HeaderText = "Precio";
            this.dgvcPrecioProducto.Name = "dgvcPrecioProducto";
            this.dgvcPrecioProducto.ReadOnly = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tscbEmpresas,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.tsbtImportar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(64, 22);
            this.toolStripLabel1.Text = "Proveedor:";
            // 
            // tscbEmpresas
            // 
            this.tscbEmpresas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tscbEmpresas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tscbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbEmpresas.Name = "tscbEmpresas";
            this.tscbEmpresas.Size = new System.Drawing.Size(312, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton1.Text = "Mostrar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtImportar
            // 
            this.tsbtImportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtImportar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtImportar.Image")));
            this.tsbtImportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtImportar.Name = "tsbtImportar";
            this.tsbtImportar.Size = new System.Drawing.Size(128, 22);
            this.tsbtImportar.Text = "Importar hoja de Excel";
            this.tsbtImportar.Click += new System.EventHandler(this.tsbtImportar_Click);
            // 
            // FProductosEmpresasLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FProductosEmpresasLista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de productos";
            this.Load += new System.EventHandler(this.FProductosEmpresasLista_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosEmpresasLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosEmpresasListaDetalle)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btMostrarDetalle;
        private System.Windows.Forms.DataGridView dgvProductosEmpresasLista;
        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.DataGridView dgvProductosEmpresasListaDetalle;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tscbEmpresas;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtImportar;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCodigoProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDescripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPrecioProducto;
        private System.Windows.Forms.Label lbListaDetalleInfo;
        private System.Windows.Forms.Button btImprimirListaDetalle;
    }
}