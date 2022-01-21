namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FFrecuenciasPagos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FFrecuenciasPagos));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tBNumeroDias = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSOrigen = new System.Windows.Forms.BindingSource(this.components);
            this.imgListFrecuencias = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.tabControl1.ImageList = this.imgListFrecuencias;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(373, 195);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tBNumeroDias);
            this.tabPage1.Controls.Add(this.label3);
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
            this.tabPage1.Size = new System.Drawing.Size(365, 164);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detalle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tBNumeroDias
            // 
            this.tBNumeroDias.Location = new System.Drawing.Point(144, 62);
            this.tBNumeroDias.Name = "tBNumeroDias";
            this.tBNumeroDias.Size = new System.Drawing.Size(50, 20);
            this.tBNumeroDias.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Número de dias";
            // 
            // tBCodigo
            // 
            this.tBCodigo.Enabled = false;
            this.tBCodigo.Location = new System.Drawing.Point(144, 6);
            this.tBCodigo.Name = "tBCodigo";
            this.tBCodigo.Size = new System.Drawing.Size(50, 20);
            this.tBCodigo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Codigo frecuencia pago";
            // 
            // bCerrar
            // 
            this.bCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCerrar.ImageIndex = 8;
            this.bCerrar.ImageList = this.imgListFrecuencias;
            this.bCerrar.Location = new System.Drawing.Point(294, 132);
            this.bCerrar.Name = "bCerrar";
            this.bCerrar.Size = new System.Drawing.Size(63, 29);
            this.bCerrar.TabIndex = 8;
            this.bCerrar.Text = "Cerrar";
            this.bCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCerrar.UseVisualStyleBackColor = true;
            this.bCerrar.Click += new System.EventHandler(this.bCerrar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCancelar.ImageIndex = 0;
            this.bCancelar.ImageList = this.imgListFrecuencias;
            this.bCancelar.Location = new System.Drawing.Point(279, 100);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(78, 29);
            this.bCancelar.TabIndex = 7;
            this.bCancelar.Text = "&Cancelar";
            this.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre frecuencia pago";
            // 
            // bAceptar
            // 
            this.bAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAceptar.ImageIndex = 5;
            this.bAceptar.ImageList = this.imgListFrecuencias;
            this.bAceptar.Location = new System.Drawing.Point(207, 100);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(71, 29);
            this.bAceptar.TabIndex = 6;
            this.bAceptar.Text = "&Aceptar";
            this.bAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // tBNombre
            // 
            this.tBNombre.Location = new System.Drawing.Point(144, 33);
            this.tBNombre.Name = "tBNombre";
            this.tBNombre.Size = new System.Drawing.Size(187, 20);
            this.tBNombre.TabIndex = 1;
            // 
            // bEliminar
            // 
            this.bEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEliminar.ImageIndex = 6;
            this.bEliminar.ImageList = this.imgListFrecuencias;
            this.bEliminar.Location = new System.Drawing.Point(136, 100);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(70, 29);
            this.bEliminar.TabIndex = 5;
            this.bEliminar.Text = "E&liminar";
            this.bEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bEliminar.UseVisualStyleBackColor = true;
            this.bEliminar.Click += new System.EventHandler(this.bEliminar_Click);
            // 
            // bNuevo
            // 
            this.bNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bNuevo.ImageKey = "Symbol-Add.ico";
            this.bNuevo.ImageList = this.imgListFrecuencias;
            this.bNuevo.Location = new System.Drawing.Point(8, 100);
            this.bNuevo.Name = "bNuevo";
            this.bNuevo.Size = new System.Drawing.Size(66, 29);
            this.bNuevo.TabIndex = 3;
            this.bNuevo.Text = "&Nuevo";
            this.bNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bNuevo.UseVisualStyleBackColor = true;
            this.bNuevo.Click += new System.EventHandler(this.bNuevo_Click);
            // 
            // bEditar
            // 
            this.bEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEditar.ImageIndex = 1;
            this.bEditar.ImageList = this.imgListFrecuencias;
            this.bEditar.Location = new System.Drawing.Point(75, 100);
            this.bEditar.Name = "bEditar";
            this.bEditar.Size = new System.Drawing.Size(60, 29);
            this.bEditar.TabIndex = 4;
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
            this.tabPage2.Size = new System.Drawing.Size(365, 164);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lista";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dGVGrilla
            // 
            this.dGVGrilla.AllowUserToAddRows = false;
            this.dGVGrilla.AutoGenerateColumns = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVGrilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dGVGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVGrilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dGVGrilla.DataSource = this.bSOrigen;
            this.dGVGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVGrilla.Location = new System.Drawing.Point(3, 3);
            this.dGVGrilla.Name = "dGVGrilla";
            this.dGVGrilla.RowHeadersVisible = false;
            this.dGVGrilla.Size = new System.Drawing.Size(359, 158);
            this.dGVGrilla.TabIndex = 34;
            this.dGVGrilla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVGrilla_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CodigoFrecuenciaPago";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "NombreFrecuenciaPago";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            this.Column2.Width = 195;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NumeroDias";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column3.HeaderText = "Nº Dias";
            this.Column3.Name = "Column3";
            this.Column3.Width = 75;
            // 
            // imgListFrecuencias
            // 
            this.imgListFrecuencias.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListFrecuencias.ImageStream")));
            this.imgListFrecuencias.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListFrecuencias.Images.SetKeyName(0, "Undo.ico");
            this.imgListFrecuencias.Images.SetKeyName(1, "Edit.ico");
            this.imgListFrecuencias.Images.SetKeyName(2, "Rename.ico");
            this.imgListFrecuencias.Images.SetKeyName(3, "Save.ico");
            this.imgListFrecuencias.Images.SetKeyName(4, "Symbol-Add.ico");
            this.imgListFrecuencias.Images.SetKeyName(5, "Symbol-Check.ico");
            this.imgListFrecuencias.Images.SetKeyName(6, "Symbol-Delete.ico");
            this.imgListFrecuencias.Images.SetKeyName(7, "Symbol-Refresh.ico");
            this.imgListFrecuencias.Images.SetKeyName(8, "delete.ico");
            this.imgListFrecuencias.Images.SetKeyName(9, "Generic.ico");
            this.imgListFrecuencias.Images.SetKeyName(10, "Notes.ico");
            this.imgListFrecuencias.Images.SetKeyName(11, "card.ico");
            // 
            // FFrecuenciasPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 195);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FFrecuenciasPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frecuencias pagos";
            this.Load += new System.EventHandler(this.FFrecuenciasPagos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVGrilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSOrigen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tBNumeroDias;
        private System.Windows.Forms.Label label3;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ImageList imgListFrecuencias;
    }
}