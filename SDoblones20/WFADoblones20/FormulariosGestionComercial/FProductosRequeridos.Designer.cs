namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FProductosRequeridos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtGVProductosRequeridos = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCTotalEntregado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCTotalVendido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCExistenciaActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadRequerida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPrecioUnitarioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosRequeridos)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtGVProductosRequeridos);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(781, 374);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Productos Requeridos";
            // 
            // dtGVProductosRequeridos
            // 
            this.dtGVProductosRequeridos.AllowUserToAddRows = false;
            this.dtGVProductosRequeridos.AllowUserToDeleteRows = false;
            this.dtGVProductosRequeridos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVProductosRequeridos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVProductosRequeridos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVProductosRequeridos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoProducto,
            this.DGCNombreProducto,
            this.DGCTotalEntregado,
            this.DGCTotalVendido,
            this.DGCExistenciaActual,
            this.DGCCantidadRequerida,
            this.DGCPrecioUnitarioCompra});
            this.dtGVProductosRequeridos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVProductosRequeridos.Location = new System.Drawing.Point(5, 18);
            this.dtGVProductosRequeridos.Name = "dtGVProductosRequeridos";
            this.dtGVProductosRequeridos.ReadOnly = true;
            this.dtGVProductosRequeridos.RowHeadersVisible = false;
            this.dtGVProductosRequeridos.Size = new System.Drawing.Size(771, 351);
            this.dtGVProductosRequeridos.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAceptar);
            this.flowLayoutPanel1.Controls.Add(this.btnReporte);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 377);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(781, 53);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(703, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 34);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "&Cerrar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(622, 3);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(75, 34);
            this.btnReporte.TabIndex = 1;
            this.btnReporte.Text = "&Reportes";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 110;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 109;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Cant Entregada";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Cant Vendida";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 110;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Existencia Actual";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 110;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Requeridos";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 109;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "P U Comrpa";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 110;
            // 
            // DGCCodigoProducto
            // 
            this.DGCCodigoProducto.DataPropertyName = "CodigoProducto";
            this.DGCCodigoProducto.HeaderText = "Código";
            this.DGCCodigoProducto.Name = "DGCCodigoProducto";
            this.DGCCodigoProducto.ReadOnly = true;
            // 
            // DGCNombreProducto
            // 
            this.DGCNombreProducto.DataPropertyName = "NombreProducto";
            this.DGCNombreProducto.HeaderText = "Producto";
            this.DGCNombreProducto.Name = "DGCNombreProducto";
            this.DGCNombreProducto.ReadOnly = true;
            // 
            // DGCTotalEntregado
            // 
            this.DGCTotalEntregado.DataPropertyName = "TotalEntregado";
            this.DGCTotalEntregado.HeaderText = "Cant Entregada";
            this.DGCTotalEntregado.Name = "DGCTotalEntregado";
            this.DGCTotalEntregado.ReadOnly = true;
            // 
            // DGCTotalVendido
            // 
            this.DGCTotalVendido.DataPropertyName = "TotalVendido";
            this.DGCTotalVendido.HeaderText = "Cant Vendida";
            this.DGCTotalVendido.Name = "DGCTotalVendido";
            this.DGCTotalVendido.ReadOnly = true;
            // 
            // DGCExistenciaActual
            // 
            this.DGCExistenciaActual.DataPropertyName = "ExistenciaActual";
            this.DGCExistenciaActual.HeaderText = "Existencia Actual";
            this.DGCExistenciaActual.Name = "DGCExistenciaActual";
            this.DGCExistenciaActual.ReadOnly = true;
            // 
            // DGCCantidadRequerida
            // 
            this.DGCCantidadRequerida.DataPropertyName = "CantidadRequerida";
            this.DGCCantidadRequerida.HeaderText = "Requeridos";
            this.DGCCantidadRequerida.Name = "DGCCantidadRequerida";
            this.DGCCantidadRequerida.ReadOnly = true;
            // 
            // DGCPrecioUnitarioCompra
            // 
            this.DGCPrecioUnitarioCompra.DataPropertyName = "PrecioUnitarioCompra";
            this.DGCPrecioUnitarioCompra.HeaderText = "P U Comrpa";
            this.DGCPrecioUnitarioCompra.Name = "DGCPrecioUnitarioCompra";
            this.DGCPrecioUnitarioCompra.ReadOnly = true;
            // 
            // FProductosRequeridos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 433);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FProductosRequeridos";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos Requeridos";
            this.Load += new System.EventHandler(this.FProductosRequeridos_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductosRequeridos)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtGVProductosRequeridos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCTotalEntregado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCTotalVendido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCExistenciaActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadRequerida;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPrecioUnitarioCompra;
    }
}