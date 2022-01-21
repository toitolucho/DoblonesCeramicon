namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FProductosEspecificosDevolucion
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
            this.gBoxPatronBusqueda = new System.Windows.Forms.GroupBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.txtBoxPrecioDevolucion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxCodigoProductoEspecifico = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtGVProductosEspecificos = new System.Windows.Forms.DataGridView();
            this.DGCCodigoProductoEspecifico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPrecioUnitarioPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblDatosProducto = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBoxPatronBusqueda.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosEspecificos)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxPatronBusqueda
            // 
            this.gBoxPatronBusqueda.Controls.Add(this.btnSeleccionar);
            this.gBoxPatronBusqueda.Controls.Add(this.txtBoxPrecioDevolucion);
            this.gBoxPatronBusqueda.Controls.Add(this.label2);
            this.gBoxPatronBusqueda.Controls.Add(this.label1);
            this.gBoxPatronBusqueda.Controls.Add(this.txtBoxCodigoProductoEspecifico);
            this.gBoxPatronBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxPatronBusqueda.Location = new System.Drawing.Point(0, 0);
            this.gBoxPatronBusqueda.Name = "gBoxPatronBusqueda";
            this.gBoxPatronBusqueda.Size = new System.Drawing.Size(444, 59);
            this.gBoxPatronBusqueda.TabIndex = 0;
            this.gBoxPatronBusqueda.TabStop = false;
            this.gBoxPatronBusqueda.Text = "Datos de Selección";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(357, 27);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionar.TabIndex = 2;
            this.btnSeleccionar.Text = "&Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // txtBoxPrecioDevolucion
            // 
            this.txtBoxPrecioDevolucion.Location = new System.Drawing.Point(9, 30);
            this.txtBoxPrecioDevolucion.Name = "txtBoxPrecioDevolucion";
            this.txtBoxPrecioDevolucion.Size = new System.Drawing.Size(128, 20);
            this.txtBoxPrecioDevolucion.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Precio Devolución";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cód. Específico";
            // 
            // txtBoxCodigoProductoEspecifico
            // 
            this.txtBoxCodigoProductoEspecifico.Location = new System.Drawing.Point(143, 30);
            this.txtBoxCodigoProductoEspecifico.MaxLength = 30;
            this.txtBoxCodigoProductoEspecifico.Name = "txtBoxCodigoProductoEspecifico";
            this.txtBoxCodigoProductoEspecifico.Size = new System.Drawing.Size(208, 20);
            this.txtBoxCodigoProductoEspecifico.TabIndex = 1;
            this.txtBoxCodigoProductoEspecifico.TextChanged += new System.EventHandler(this.txtBoxCodigoProductoEspecifico_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtGVProductosEspecificos);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(0, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 399);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de Productos Especificos Entregados";
            // 
            // dtGVProductosEspecificos
            // 
            this.dtGVProductosEspecificos.AllowUserToAddRows = false;
            this.dtGVProductosEspecificos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVProductosEspecificos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVProductosEspecificos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVProductosEspecificos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoProductoEspecifico,
            this.DGCPrecioUnitarioPE,
            this.DGVSeleccionar});
            this.dtGVProductosEspecificos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVProductosEspecificos.Location = new System.Drawing.Point(3, 16);
            this.dtGVProductosEspecificos.Name = "dtGVProductosEspecificos";
            this.dtGVProductosEspecificos.RowHeadersVisible = false;
            this.dtGVProductosEspecificos.Size = new System.Drawing.Size(438, 380);
            this.dtGVProductosEspecificos.TabIndex = 0;
            // 
            // DGCCodigoProductoEspecifico
            // 
            this.DGCCodigoProductoEspecifico.DataPropertyName = "CodigoProductoEspecifico";
            this.DGCCodigoProductoEspecifico.HeaderText = "Cód Específico";
            this.DGCCodigoProductoEspecifico.Name = "DGCCodigoProductoEspecifico";
            this.DGCCodigoProductoEspecifico.ReadOnly = true;
            this.DGCCodigoProductoEspecifico.Width = 160;
            // 
            // DGCPrecioUnitarioPE
            // 
            this.DGCPrecioUnitarioPE.DataPropertyName = "PrecioDevolucion";
            this.DGCPrecioUnitarioPE.HeaderText = "Precio Devolucion";
            this.DGCPrecioUnitarioPE.Name = "DGCPrecioUnitarioPE";
            this.DGCPrecioUnitarioPE.Width = 150;
            // 
            // DGVSeleccionar
            // 
            this.DGVSeleccionar.DataPropertyName = "Devolver";
            this.DGVSeleccionar.HeaderText = "Devolver ? ";
            this.DGVSeleccionar.Name = "DGVSeleccionar";
            this.DGVSeleccionar.Width = 120;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btnAceptar);
            this.flowLayoutPanel1.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 448);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(444, 30);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(364, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(283, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblDatosProducto
            // 
            this.lblDatosProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDatosProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosProducto.Location = new System.Drawing.Point(0, 59);
            this.lblDatosProducto.Name = "lblDatosProducto";
            this.lblDatosProducto.Size = new System.Drawing.Size(444, 20);
            this.lblDatosProducto.TabIndex = 5;
            this.lblDatosProducto.Text = "Codigo Producto :  103 , Nombre : Producto unico";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoProductoEspecifico";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cód Específico";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 160;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PrecioDevolucion";
            this.dataGridViewTextBoxColumn2.HeaderText = "Precio Devolucion";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // FProductosEspecificosDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 478);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDatosProducto);
            this.Controls.Add(this.gBoxPatronBusqueda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FProductosEspecificosDevolucion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos Específcos a ser Devueltos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FProductosEspecificosDevolucion_FormClosing);
            this.gBoxPatronBusqueda.ResumeLayout(false);
            this.gBoxPatronBusqueda.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosEspecificos)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxPatronBusqueda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxCodigoProductoEspecifico;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.TextBox txtBoxPrecioDevolucion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtGVProductosEspecificos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblDatosProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProductoEspecifico;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPrecioUnitarioPE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGVSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}