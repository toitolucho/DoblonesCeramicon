namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FInventarioMercaderiaEnTransito
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gBoxListadoArticulos = new System.Windows.Forms.GroupBox();
            this.gBoxOpcionesInforme = new System.Windows.Forms.GroupBox();
            this.dtGVProductos = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.rbtnListadoGeneral = new System.Windows.Forms.RadioButton();
            this.rBtnListadoProveedores = new System.Windows.Forms.RadioButton();
            this.rBtnListadoProductos = new System.Windows.Forms.RadioButton();
            this.DGCCodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadSolicitada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadRecepcionada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadEnTransito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCantidadExistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBoxListadoArticulos.SuspendLayout();
            this.gBoxOpcionesInforme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxListadoArticulos
            // 
            this.gBoxListadoArticulos.Controls.Add(this.dtGVProductos);
            this.gBoxListadoArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxListadoArticulos.Location = new System.Drawing.Point(7, 7);
            this.gBoxListadoArticulos.Name = "gBoxListadoArticulos";
            this.gBoxListadoArticulos.Size = new System.Drawing.Size(758, 386);
            this.gBoxListadoArticulos.TabIndex = 0;
            this.gBoxListadoArticulos.TabStop = false;
            this.gBoxListadoArticulos.Text = "Listado de Articulos";
            // 
            // gBoxOpcionesInforme
            // 
            this.gBoxOpcionesInforme.Controls.Add(this.rBtnListadoProductos);
            this.gBoxOpcionesInforme.Controls.Add(this.rBtnListadoProveedores);
            this.gBoxOpcionesInforme.Controls.Add(this.rbtnListadoGeneral);
            this.gBoxOpcionesInforme.Controls.Add(this.btnCancelar);
            this.gBoxOpcionesInforme.Controls.Add(this.btnAceptar);
            this.gBoxOpcionesInforme.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gBoxOpcionesInforme.Location = new System.Drawing.Point(7, 393);
            this.gBoxOpcionesInforme.Name = "gBoxOpcionesInforme";
            this.gBoxOpcionesInforme.Size = new System.Drawing.Size(758, 53);
            this.gBoxOpcionesInforme.TabIndex = 1;
            this.gBoxOpcionesInforme.TabStop = false;
            this.gBoxOpcionesInforme.Text = "Opciones de Informe";
            // 
            // dtGVProductos
            // 
            this.dtGVProductos.AllowUserToAddRows = false;
            this.dtGVProductos.AllowUserToDeleteRows = false;
            this.dtGVProductos.AllowUserToResizeRows = false;
            this.dtGVProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtGVProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoProducto,
            this.DGCNombreProducto,
            this.DGCNombreUnidad,
            this.DGCCantidadSolicitada,
            this.DGCCantidadRecepcionada,
            this.DGCCantidadEnTransito,
            this.DGCCantidadExistencia});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGVProductos.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtGVProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVProductos.Location = new System.Drawing.Point(3, 16);
            this.dtGVProductos.Name = "dtGVProductos";
            this.dtGVProductos.ReadOnly = true;
            this.dtGVProductos.RowHeadersVisible = false;
            this.dtGVProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVProductos.Size = new System.Drawing.Size(752, 367);
            this.dtGVProductos.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(555, 20);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(116, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Visutalizar Informe";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(677, 20);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // rbtnListadoGeneral
            // 
            this.rbtnListadoGeneral.AutoSize = true;
            this.rbtnListadoGeneral.Checked = true;
            this.rbtnListadoGeneral.Location = new System.Drawing.Point(6, 23);
            this.rbtnListadoGeneral.Name = "rbtnListadoGeneral";
            this.rbtnListadoGeneral.Size = new System.Drawing.Size(99, 17);
            this.rbtnListadoGeneral.TabIndex = 2;
            this.rbtnListadoGeneral.TabStop = true;
            this.rbtnListadoGeneral.Text = "Listado General";
            this.rbtnListadoGeneral.UseVisualStyleBackColor = true;
            // 
            // rBtnListadoProveedores
            // 
            this.rBtnListadoProveedores.AutoSize = true;
            this.rBtnListadoProveedores.Location = new System.Drawing.Point(135, 23);
            this.rBtnListadoProveedores.Name = "rBtnListadoProveedores";
            this.rBtnListadoProveedores.Size = new System.Drawing.Size(141, 17);
            this.rBtnListadoProveedores.TabIndex = 3;
            this.rBtnListadoProveedores.Text = "Listado Por Proveedores";
            this.rBtnListadoProveedores.UseVisualStyleBackColor = true;
            // 
            // rBtnListadoProductos
            // 
            this.rBtnListadoProductos.AutoSize = true;
            this.rBtnListadoProductos.Location = new System.Drawing.Point(306, 23);
            this.rBtnListadoProductos.Name = "rBtnListadoProductos";
            this.rBtnListadoProductos.Size = new System.Drawing.Size(129, 17);
            this.rBtnListadoProductos.TabIndex = 4;
            this.rBtnListadoProductos.Text = "Listado Por Productos";
            this.rBtnListadoProductos.UseVisualStyleBackColor = true;
            // 
            // DGCCodigoProducto
            // 
            this.DGCCodigoProducto.DataPropertyName = "CodigoProducto";
            this.DGCCodigoProducto.HeaderText = "Código";
            this.DGCCodigoProducto.Name = "DGCCodigoProducto";
            this.DGCCodigoProducto.ReadOnly = true;
            this.DGCCodigoProducto.ToolTipText = "Código Identificador del Artículo";
            // 
            // DGCNombreProducto
            // 
            this.DGCNombreProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCNombreProducto.DataPropertyName = "NombreProducto";
            this.DGCNombreProducto.HeaderText = "Producto";
            this.DGCNombreProducto.Name = "DGCNombreProducto";
            this.DGCNombreProducto.ReadOnly = true;
            // 
            // DGCNombreUnidad
            // 
            this.DGCNombreUnidad.DataPropertyName = "NombreUnidad";
            this.DGCNombreUnidad.HeaderText = "Unidad";
            this.DGCNombreUnidad.Name = "DGCNombreUnidad";
            this.DGCNombreUnidad.ReadOnly = true;
            // 
            // DGCCantidadSolicitada
            // 
            this.DGCCantidadSolicitada.DataPropertyName = "CantidadSolicitada";
            this.DGCCantidadSolicitada.HeaderText = "Solicitados";
            this.DGCCantidadSolicitada.Name = "DGCCantidadSolicitada";
            this.DGCCantidadSolicitada.ReadOnly = true;
            this.DGCCantidadSolicitada.ToolTipText = "Cantidad Solicitada por Ordenes de Compra";
            // 
            // DGCCantidadRecepcionada
            // 
            this.DGCCantidadRecepcionada.DataPropertyName = "CantidadRecepcionada";
            this.DGCCantidadRecepcionada.HeaderText = "Recepcionados";
            this.DGCCantidadRecepcionada.Name = "DGCCantidadRecepcionada";
            this.DGCCantidadRecepcionada.ReadOnly = true;
            this.DGCCantidadRecepcionada.ToolTipText = "Cantidad Recepcionada Parcialmente";
            // 
            // DGCCantidadEnTransito
            // 
            this.DGCCantidadEnTransito.DataPropertyName = "CantidadEnTransito";
            this.DGCCantidadEnTransito.HeaderText = "En Transito";
            this.DGCCantidadEnTransito.Name = "DGCCantidadEnTransito";
            this.DGCCantidadEnTransito.ReadOnly = true;
            this.DGCCantidadEnTransito.ToolTipText = "Cantidad de Mercaderia en Transito";
            // 
            // DGCCantidadExistencia
            // 
            this.DGCCantidadExistencia.DataPropertyName = "CantidadExistencia";
            this.DGCCantidadExistencia.HeaderText = "Existencia";
            this.DGCCantidadExistencia.Name = "DGCCantidadExistencia";
            this.DGCCantidadExistencia.ReadOnly = true;
            this.DGCCantidadExistencia.ToolTipText = "Existencia Actual en Inventarios";
            // 
            // FInventarioMercaderiaEnTransito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(772, 453);
            this.Controls.Add(this.gBoxListadoArticulos);
            this.Controls.Add(this.gBoxOpcionesInforme);
            this.Name = "FInventarioMercaderiaEnTransito";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario de Mercaderia en Transito";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FInventarioMercaderiaEnTransito_Load);
            this.gBoxListadoArticulos.ResumeLayout(false);
            this.gBoxOpcionesInforme.ResumeLayout(false);
            this.gBoxOpcionesInforme.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxListadoArticulos;
        private System.Windows.Forms.GroupBox gBoxOpcionesInforme;
        private System.Windows.Forms.DataGridView dtGVProductos;
        private System.Windows.Forms.RadioButton rBtnListadoProductos;
        private System.Windows.Forms.RadioButton rBtnListadoProveedores;
        private System.Windows.Forms.RadioButton rbtnListadoGeneral;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadSolicitada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadRecepcionada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadEnTransito;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCantidadExistencia;
    }
}