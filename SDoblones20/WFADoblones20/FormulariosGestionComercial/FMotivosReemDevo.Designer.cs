namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FMotivosReemDevo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMotivosReemDevo));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gBoxTipoTransaccion = new System.Windows.Forms.GroupBox();
            this.rBtnDevolucion = new System.Windows.Forms.RadioButton();
            this.rBtnCompra = new System.Windows.Forms.RadioButton();
            this.rBtnVenta = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxEstadoRetornoInventario = new System.Windows.Forms.ComboBox();
            this.tBCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bCerrar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bAceptar = new System.Windows.Forms.Button();
            this.tBNombre = new System.Windows.Forms.TextBox();
            this.bEliminar = new System.Windows.Forms.Button();
            this.bNuevo = new System.Windows.Forms.Button();
            this.bEditar = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dGVGrilla = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCTipoTransaccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSOrigen = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgListbancos = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gBoxTipoTransaccion.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVGrilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSOrigen)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(382, 245);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gBoxTipoTransaccion);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cboxEstadoRetornoInventario);
            this.tabPage1.Controls.Add(this.tBCodigo);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.bCerrar);
            this.tabPage1.Controls.Add(this.bCancelar);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.bAceptar);
            this.tabPage1.Controls.Add(this.tBNombre);
            this.tabPage1.Controls.Add(this.bEliminar);
            this.tabPage1.Controls.Add(this.bNuevo);
            this.tabPage1.Controls.Add(this.bEditar);
            this.tabPage1.ImageIndex = 11;
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(374, 214);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detalle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gBoxTipoTransaccion
            // 
            this.gBoxTipoTransaccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxTipoTransaccion.Controls.Add(this.rBtnDevolucion);
            this.gBoxTipoTransaccion.Controls.Add(this.rBtnCompra);
            this.gBoxTipoTransaccion.Controls.Add(this.rBtnVenta);
            this.gBoxTipoTransaccion.Location = new System.Drawing.Point(7, 74);
            this.gBoxTipoTransaccion.Name = "gBoxTipoTransaccion";
            this.gBoxTipoTransaccion.Size = new System.Drawing.Size(361, 45);
            this.gBoxTipoTransaccion.TabIndex = 12;
            this.gBoxTipoTransaccion.TabStop = false;
            this.gBoxTipoTransaccion.Text = "Tipo Transacción";
            // 
            // rBtnDevolucion
            // 
            this.rBtnDevolucion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnDevolucion.AutoSize = true;
            this.rBtnDevolucion.Location = new System.Drawing.Point(258, 19);
            this.rBtnDevolucion.Name = "rBtnDevolucion";
            this.rBtnDevolucion.Size = new System.Drawing.Size(79, 17);
            this.rBtnDevolucion.TabIndex = 2;
            this.rBtnDevolucion.TabStop = true;
            this.rBtnDevolucion.Text = "&Devolucion";
            this.rBtnDevolucion.UseVisualStyleBackColor = true;
            // 
            // rBtnCompra
            // 
            this.rBtnCompra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnCompra.AutoSize = true;
            this.rBtnCompra.Location = new System.Drawing.Point(152, 19);
            this.rBtnCompra.Name = "rBtnCompra";
            this.rBtnCompra.Size = new System.Drawing.Size(61, 17);
            this.rBtnCompra.TabIndex = 1;
            this.rBtnCompra.TabStop = true;
            this.rBtnCompra.Text = "&Compra";
            this.rBtnCompra.UseVisualStyleBackColor = true;
            // 
            // rBtnVenta
            // 
            this.rBtnVenta.AutoSize = true;
            this.rBtnVenta.Location = new System.Drawing.Point(25, 19);
            this.rBtnVenta.Name = "rBtnVenta";
            this.rBtnVenta.Size = new System.Drawing.Size(53, 17);
            this.rBtnVenta.TabIndex = 0;
            this.rBtnVenta.TabStop = true;
            this.rBtnVenta.Text = "&Venta";
            this.rBtnVenta.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Estado Retorno Inventario";
            // 
            // cboxEstadoRetornoInventario
            // 
            this.cboxEstadoRetornoInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxEstadoRetornoInventario.FormattingEnabled = true;
            this.cboxEstadoRetornoInventario.Location = new System.Drawing.Point(146, 125);
            this.cboxEstadoRetornoInventario.Name = "cboxEstadoRetornoInventario";
            this.cboxEstadoRetornoInventario.Size = new System.Drawing.Size(222, 21);
            this.cboxEstadoRetornoInventario.TabIndex = 10;
            // 
            // tBCodigo
            // 
            this.tBCodigo.Enabled = false;
            this.tBCodigo.Location = new System.Drawing.Point(85, 7);
            this.tBCodigo.Name = "tBCodigo";
            this.tBCodigo.Size = new System.Drawing.Size(80, 20);
            this.tBCodigo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Codigo Motivo";
            // 
            // bCerrar
            // 
            this.bCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCerrar.ImageIndex = 8;
            this.bCerrar.ImageList = this.imgListbancos;
            this.bCerrar.Location = new System.Drawing.Point(314, 184);
            this.bCerrar.Name = "bCerrar";
            this.bCerrar.Size = new System.Drawing.Size(52, 29);
            this.bCerrar.TabIndex = 7;
            this.bCerrar.Text = "Cerrar";
            this.bCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCerrar.UseVisualStyleBackColor = true;
            this.bCerrar.Click += new System.EventHandler(this.bCerrar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCancelar.ImageIndex = 0;
            this.bCancelar.ImageList = this.imgListbancos;
            this.bCancelar.Location = new System.Drawing.Point(294, 152);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(74, 29);
            this.bCancelar.TabIndex = 6;
            this.bCancelar.Text = "&Cancelar";
            this.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Motivo Reembolso ó Devolución";
            // 
            // bAceptar
            // 
            this.bAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAceptar.ImageIndex = 3;
            this.bAceptar.ImageList = this.imgListbancos;
            this.bAceptar.Location = new System.Drawing.Point(219, 152);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(69, 29);
            this.bAceptar.TabIndex = 5;
            this.bAceptar.Text = "&Aceptar";
            this.bAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // tBNombre
            // 
            this.tBNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tBNombre.Location = new System.Drawing.Point(7, 52);
            this.tBNombre.Name = "tBNombre";
            this.tBNombre.Size = new System.Drawing.Size(362, 20);
            this.tBNombre.TabIndex = 1;
            // 
            // bEliminar
            // 
            this.bEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEliminar.ImageIndex = 6;
            this.bEliminar.ImageList = this.imgListbancos;
            this.bEliminar.Location = new System.Drawing.Point(143, 152);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(70, 29);
            this.bEliminar.TabIndex = 4;
            this.bEliminar.Text = "E&liminar";
            this.bEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bEliminar.UseVisualStyleBackColor = true;
            this.bEliminar.Click += new System.EventHandler(this.bEliminar_Click);
            // 
            // bNuevo
            // 
            this.bNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bNuevo.ImageIndex = 4;
            this.bNuevo.ImageList = this.imgListbancos;
            this.bNuevo.Location = new System.Drawing.Point(7, 152);
            this.bNuevo.Name = "bNuevo";
            this.bNuevo.Size = new System.Drawing.Size(65, 29);
            this.bNuevo.TabIndex = 2;
            this.bNuevo.Text = "&Nuevo";
            this.bNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bNuevo.UseVisualStyleBackColor = true;
            this.bNuevo.Click += new System.EventHandler(this.bNuevo_Click);
            // 
            // bEditar
            // 
            this.bEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEditar.ImageIndex = 1;
            this.bEditar.ImageList = this.imgListbancos;
            this.bEditar.Location = new System.Drawing.Point(78, 152);
            this.bEditar.Name = "bEditar";
            this.bEditar.Size = new System.Drawing.Size(59, 29);
            this.bEditar.TabIndex = 3;
            this.bEditar.Text = "&Editar";
            this.bEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bEditar.UseVisualStyleBackColor = true;
            this.bEditar.Click += new System.EventHandler(this.bEditar_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dGVGrilla);
            this.tabPage2.ImageIndex = 9;
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(374, 214);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lista";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dGVGrilla
            // 
            this.dGVGrilla.AllowUserToAddRows = false;
            this.dGVGrilla.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVGrilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVGrilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.DGCTipoTransaccion});
            this.dGVGrilla.DataSource = this.bSOrigen;
            this.dGVGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVGrilla.Location = new System.Drawing.Point(3, 3);
            this.dGVGrilla.Name = "dGVGrilla";
            this.dGVGrilla.RowHeadersVisible = false;
            this.dGVGrilla.Size = new System.Drawing.Size(368, 208);
            this.dGVGrilla.TabIndex = 34;
            this.dGVGrilla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVGrilla_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CodigoMotivoReemDevo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "NombreMotivoReemDevo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "Motivo Reembolso ó Devolución";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // DGCTipoTransaccion
            // 
            this.DGCTipoTransaccion.DataPropertyName = "TipoTransaccion";
            this.DGCTipoTransaccion.HeaderText = "Operación";
            this.DGCTipoTransaccion.Name = "DGCTipoTransaccion";
            this.DGCTipoTransaccion.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoMotivoReemDevo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreMotivoReemDevo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.HeaderText = "Motivo Reembolso ó Devolución";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TipoTransaccion";
            this.dataGridViewTextBoxColumn3.HeaderText = "Operación";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
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
            // FMotivosReemDevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCerrar;
            this.ClientSize = new System.Drawing.Size(382, 245);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FMotivosReemDevo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Motivos reembolso devoluciones";
            this.Load += new System.EventHandler(this.FMotivosReemDevo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gBoxTipoTransaccion.ResumeLayout(false);
            this.gBoxTipoTransaccion.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVGrilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSOrigen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tBCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bCerrar;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.TextBox tBNombre;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.Button bNuevo;
        private System.Windows.Forms.Button bEditar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dGVGrilla;
        private System.Windows.Forms.BindingSource bSOrigen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxEstadoRetornoInventario;
        private System.Windows.Forms.GroupBox gBoxTipoTransaccion;
        private System.Windows.Forms.RadioButton rBtnVenta;
        private System.Windows.Forms.RadioButton rBtnDevolucion;
        private System.Windows.Forms.RadioButton rBtnCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCTipoTransaccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ImageList imgListbancos;
    }
}