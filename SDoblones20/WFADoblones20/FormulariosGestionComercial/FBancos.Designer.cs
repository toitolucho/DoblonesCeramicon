namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FBancos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBancos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.bSOrigen = new System.Windows.Forms.BindingSource(this.components);
            this.imgListbancos = new System.Windows.Forms.ImageList(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tabControl1.ImageList = this.imgListbancos;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(444, 147);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
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
            this.tabPage1.Size = new System.Drawing.Size(436, 116);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detalle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tBCodigo
            // 
            this.tBCodigo.Enabled = false;
            this.tBCodigo.Location = new System.Drawing.Point(90, 8);
            this.tBCodigo.Name = "tBCodigo";
            this.tBCodigo.Size = new System.Drawing.Size(139, 20);
            this.tBCodigo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Codigo banco";
            // 
            // bCerrar
            // 
            this.bCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCerrar.ImageIndex = 8;
            this.bCerrar.ImageList = this.imgListbancos;
            this.bCerrar.Location = new System.Drawing.Point(360, 74);
            this.bCerrar.Name = "bCerrar";
            this.bCerrar.Size = new System.Drawing.Size(65, 29);
            this.bCerrar.TabIndex = 7;
            this.bCerrar.Text = "Cerrar";
            this.bCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCerrar.UseVisualStyleBackColor = true;
            this.bCerrar.Click += new System.EventHandler(this.bCerrar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCancelar.ImageIndex = 0;
            this.bCancelar.ImageList = this.imgListbancos;
            this.bCancelar.Location = new System.Drawing.Point(288, 74);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(70, 29);
            this.bCancelar.TabIndex = 6;
            this.bCancelar.Text = "&Cancelar";
            this.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre banco";
            // 
            // bAceptar
            // 
            this.bAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAceptar.ImageIndex = 3;
            this.bAceptar.ImageList = this.imgListbancos;
            this.bAceptar.Location = new System.Drawing.Point(216, 74);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(70, 29);
            this.bAceptar.TabIndex = 5;
            this.bAceptar.Text = "&Aceptar";
            this.bAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // tBNombre
            // 
            this.tBNombre.Location = new System.Drawing.Point(90, 35);
            this.tBNombre.Name = "tBNombre";
            this.tBNombre.Size = new System.Drawing.Size(335, 20);
            this.tBNombre.TabIndex = 1;
            // 
            // bEliminar
            // 
            this.bEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEliminar.ImageIndex = 6;
            this.bEliminar.ImageList = this.imgListbancos;
            this.bEliminar.Location = new System.Drawing.Point(144, 74);
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
            this.bNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bNuevo.ImageIndex = 4;
            this.bNuevo.ImageList = this.imgListbancos;
            this.bNuevo.Location = new System.Drawing.Point(10, 74);
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
            this.bEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEditar.ImageIndex = 1;
            this.bEditar.ImageList = this.imgListbancos;
            this.bEditar.Location = new System.Drawing.Point(77, 74);
            this.bEditar.Name = "bEditar";
            this.bEditar.Size = new System.Drawing.Size(65, 29);
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
            this.tabPage2.Size = new System.Drawing.Size(436, 116);
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
            this.Column2});
            this.dGVGrilla.DataSource = this.bSOrigen;
            this.dGVGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVGrilla.Location = new System.Drawing.Point(3, 3);
            this.dGVGrilla.Name = "dGVGrilla";
            this.dGVGrilla.RowHeadersVisible = false;
            this.dGVGrilla.Size = new System.Drawing.Size(430, 110);
            this.dGVGrilla.TabIndex = 34;
            this.dGVGrilla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVGrilla_CellClick);
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoBanco";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreBanco";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 350;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CodigoBanco";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "NombreBanco";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            this.Column2.Width = 350;
            // 
            // FBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 147);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FBancos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bancos";
            this.Load += new System.EventHandler(this.FBancos_Load);
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
        private System.Windows.Forms.ImageList imgListbancos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}