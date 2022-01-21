namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FMonedasCotizaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMonedasCotizaciones));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bCerrar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bEliminar = new System.Windows.Forms.Button();
            this.bEditar = new System.Windows.Forms.Button();
            this.bNuevo = new System.Windows.Forms.Button();
            this.cBMoneda = new System.Windows.Forms.ComboBox();
            this.dTPFechaCotizacionInicio = new System.Windows.Forms.DateTimePicker();
            this.dTPFechaCotizacionFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bMostrar = new System.Windows.Forms.Button();
            this.bSCotizacionesMonedas = new System.Windows.Forms.BindingSource(this.components);
            this.dGVCotizacionesMonedas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.cBMonedaCotizacion = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bSCotizacionesMonedas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCotizacionesMonedas)).BeginInit();
            this.SuspendLayout();
            // 
            // bCerrar
            // 
            this.bCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCerrar.ImageIndex = 3;
            this.bCerrar.ImageList = this.imageList1;
            this.bCerrar.Location = new System.Drawing.Point(409, 447);
            this.bCerrar.Name = "bCerrar";
            this.bCerrar.Size = new System.Drawing.Size(75, 30);
            this.bCerrar.TabIndex = 11;
            this.bCerrar.Text = "Cerrar";
            this.bCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCerrar.UseVisualStyleBackColor = true;
            this.bCerrar.Click += new System.EventHandler(this.bCerrar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Find.ico");
            this.imageList1.Images.SetKeyName(1, "Save.ico");
            this.imageList1.Images.SetKeyName(2, "Symbol-Add.ico");
            this.imageList1.Images.SetKeyName(3, "Symbol-Delete.ico");
            this.imageList1.Images.SetKeyName(4, "Edit.ico");
            this.imageList1.Images.SetKeyName(5, "Redo.ico");
            // 
            // bEliminar
            // 
            this.bEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEliminar.ImageIndex = 3;
            this.bEliminar.ImageList = this.imageList1;
            this.bEliminar.Location = new System.Drawing.Point(172, 447);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(75, 30);
            this.bEliminar.TabIndex = 8;
            this.bEliminar.Text = "E&liminar";
            this.bEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bEliminar.UseVisualStyleBackColor = true;
            this.bEliminar.Click += new System.EventHandler(this.bEliminar_Click);
            // 
            // bEditar
            // 
            this.bEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEditar.ImageIndex = 4;
            this.bEditar.ImageList = this.imageList1;
            this.bEditar.Location = new System.Drawing.Point(92, 447);
            this.bEditar.Name = "bEditar";
            this.bEditar.Size = new System.Drawing.Size(75, 30);
            this.bEditar.TabIndex = 7;
            this.bEditar.Text = "&Editar";
            this.bEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bEditar.UseVisualStyleBackColor = true;
            this.bEditar.Click += new System.EventHandler(this.bEditar_Click);
            // 
            // bNuevo
            // 
            this.bNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bNuevo.ImageIndex = 2;
            this.bNuevo.ImageList = this.imageList1;
            this.bNuevo.Location = new System.Drawing.Point(11, 447);
            this.bNuevo.Name = "bNuevo";
            this.bNuevo.Size = new System.Drawing.Size(75, 30);
            this.bNuevo.TabIndex = 6;
            this.bNuevo.Text = "&Nuevo";
            this.bNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bNuevo.UseVisualStyleBackColor = true;
            this.bNuevo.Click += new System.EventHandler(this.bNuevo_Click);
            // 
            // cBMoneda
            // 
            this.cBMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBMoneda.FormattingEnabled = true;
            this.cBMoneda.Location = new System.Drawing.Point(59, 12);
            this.cBMoneda.Name = "cBMoneda";
            this.cBMoneda.Size = new System.Drawing.Size(150, 21);
            this.cBMoneda.TabIndex = 0;
            // 
            // dTPFechaCotizacionInicio
            // 
            this.dTPFechaCotizacionInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPFechaCotizacionInicio.Location = new System.Drawing.Point(59, 42);
            this.dTPFechaCotizacionInicio.Name = "dTPFechaCotizacionInicio";
            this.dTPFechaCotizacionInicio.Size = new System.Drawing.Size(100, 20);
            this.dTPFechaCotizacionInicio.TabIndex = 2;
            // 
            // dTPFechaCotizacionFin
            // 
            this.dTPFechaCotizacionFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPFechaCotizacionFin.Location = new System.Drawing.Point(206, 42);
            this.dTPFechaCotizacionFin.Name = "dTPFechaCotizacionFin";
            this.dTPFechaCotizacionFin.Size = new System.Drawing.Size(100, 20);
            this.dTPFechaCotizacionFin.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Hasta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Moneda";
            // 
            // bMostrar
            // 
            this.bMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bMostrar.ImageIndex = 5;
            this.bMostrar.ImageList = this.imageList1;
            this.bMostrar.Location = new System.Drawing.Point(409, 39);
            this.bMostrar.Name = "bMostrar";
            this.bMostrar.Size = new System.Drawing.Size(75, 30);
            this.bMostrar.TabIndex = 4;
            this.bMostrar.Text = "&Mostrar";
            this.bMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bMostrar.UseVisualStyleBackColor = true;
            this.bMostrar.Click += new System.EventHandler(this.bMostrar_Click);
            // 
            // dGVCotizacionesMonedas
            // 
            this.dGVCotizacionesMonedas.AllowUserToAddRows = false;
            this.dGVCotizacionesMonedas.AllowUserToDeleteRows = false;
            this.dGVCotizacionesMonedas.AllowUserToResizeRows = false;
            this.dGVCotizacionesMonedas.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVCotizacionesMonedas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVCotizacionesMonedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVCotizacionesMonedas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dGVCotizacionesMonedas.DataSource = this.bSCotizacionesMonedas;
            this.dGVCotizacionesMonedas.Location = new System.Drawing.Point(12, 75);
            this.dGVCotizacionesMonedas.MultiSelect = false;
            this.dGVCotizacionesMonedas.Name = "dGVCotizacionesMonedas";
            this.dGVCotizacionesMonedas.ReadOnly = true;
            this.dGVCotizacionesMonedas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dGVCotizacionesMonedas.RowHeadersVisible = false;
            this.dGVCotizacionesMonedas.RowTemplate.ReadOnly = true;
            this.dGVCotizacionesMonedas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVCotizacionesMonedas.Size = new System.Drawing.Size(472, 366);
            this.dGVCotizacionesMonedas.TabIndex = 5;
            this.dGVCotizacionesMonedas.VirtualMode = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "FechaHoraCotizacion";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Fecha";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "NombreMoneda";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "Moneda";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CambioOficial";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "Oficial";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "CambioParalelo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column4.HeaderText = "Paralelo";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Moneda cotizacion";
            // 
            // cBMonedaCotizacion
            // 
            this.cBMonedaCotizacion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBMonedaCotizacion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBMonedaCotizacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBMonedaCotizacion.FormattingEnabled = true;
            this.cBMonedaCotizacion.Location = new System.Drawing.Point(334, 12);
            this.cBMonedaCotizacion.Name = "cBMonedaCotizacion";
            this.cBMonedaCotizacion.Size = new System.Drawing.Size(150, 21);
            this.cBMonedaCotizacion.TabIndex = 1;
            // 
            // FMonedasCotizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 482);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cBMonedaCotizacion);
            this.Controls.Add(this.dGVCotizacionesMonedas);
            this.Controls.Add(this.bMostrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dTPFechaCotizacionFin);
            this.Controls.Add(this.dTPFechaCotizacionInicio);
            this.Controls.Add(this.cBMoneda);
            this.Controls.Add(this.bCerrar);
            this.Controls.Add(this.bEliminar);
            this.Controls.Add(this.bEditar);
            this.Controls.Add(this.bNuevo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FMonedasCotizaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cotizaciones monedas";
            this.Load += new System.EventHandler(this.FMonedasCotizaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bSCotizacionesMonedas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCotizacionesMonedas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCerrar;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.Button bEditar;
        private System.Windows.Forms.Button bNuevo;
        private System.Windows.Forms.ComboBox cBMoneda;
        private System.Windows.Forms.DateTimePicker dTPFechaCotizacionInicio;
        private System.Windows.Forms.DateTimePicker dTPFechaCotizacionFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bMostrar;
        private System.Windows.Forms.BindingSource bSCotizacionesMonedas;
        private System.Windows.Forms.DataGridView dGVCotizacionesMonedas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBMonedaCotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ImageList imageList1;
    }
}