namespace WFADoblones20.FormulariosSistema
{
    partial class FBuscarAgencias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBuscarAgencias));
            this.dGVResultadoBusquedaAgencias = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSAgencias = new System.Windows.Forms.BindingSource(this.components);
            this.sSBuscarAgencias = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bBuscar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tBTextoBusqueda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cBBusquedaExacta = new System.Windows.Forms.CheckBox();
            this.cBBuscarPor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGVResultadoBusquedaAgencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSAgencias)).BeginInit();
            this.sSBuscarAgencias.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGVResultadoBusquedaAgencias
            // 
            this.dGVResultadoBusquedaAgencias.AllowUserToAddRows = false;
            this.dGVResultadoBusquedaAgencias.AllowUserToDeleteRows = false;
            this.dGVResultadoBusquedaAgencias.AllowUserToResizeRows = false;
            this.dGVResultadoBusquedaAgencias.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVResultadoBusquedaAgencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVResultadoBusquedaAgencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVResultadoBusquedaAgencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dGVResultadoBusquedaAgencias.DataSource = this.bSAgencias;
            this.dGVResultadoBusquedaAgencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVResultadoBusquedaAgencias.Location = new System.Drawing.Point(0, 72);
            this.dGVResultadoBusquedaAgencias.MultiSelect = false;
            this.dGVResultadoBusquedaAgencias.Name = "dGVResultadoBusquedaAgencias";
            this.dGVResultadoBusquedaAgencias.ReadOnly = true;
            this.dGVResultadoBusquedaAgencias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dGVResultadoBusquedaAgencias.RowHeadersVisible = false;
            this.dGVResultadoBusquedaAgencias.RowTemplate.ReadOnly = true;
            this.dGVResultadoBusquedaAgencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVResultadoBusquedaAgencias.Size = new System.Drawing.Size(801, 154);
            this.dGVResultadoBusquedaAgencias.TabIndex = 17;
            this.dGVResultadoBusquedaAgencias.VirtualMode = true;
            this.dGVResultadoBusquedaAgencias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVResultadoBusquedaProveedores_CellDoubleClick);
            this.dGVResultadoBusquedaAgencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVResultadoBusquedaProveedores_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NumeroAgencia";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.HeaderText = "Nº Fac.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreAgencia";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre agencia";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DireccionAgencia";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn3.HeaderText = "Dirección";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NITAgencia";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn4.HeaderText = "NIT";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NumeroSiguienteFactura";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn5.HeaderText = "Nº sig. fac.";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "NumeroAutorizacion";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn6.HeaderText = "Nª Aut.";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 250;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DIResponsable";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn7.HeaderText = "Responsable";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // sSBuscarAgencias
            // 
            this.sSBuscarAgencias.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.sSBuscarAgencias.Location = new System.Drawing.Point(0, 226);
            this.sSBuscarAgencias.MinimumSize = new System.Drawing.Size(0, 22);
            this.sSBuscarAgencias.Name = "sSBuscarAgencias";
            this.sSBuscarAgencias.Size = new System.Drawing.Size(801, 22);
            this.sSBuscarAgencias.TabIndex = 16;
            this.sSBuscarAgencias.Text = "statusStrip1";
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
            this.bBuscar.Size = new System.Drawing.Size(69, 30);
            this.bBuscar.TabIndex = 3;
            this.bBuscar.Text = "&Buscar";
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
            "Numero agencia",
            "Nombre agencia",
            "Dirección",
            "NIT agencia"});
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
            // FBuscarAgencias
            // 
            this.AcceptButton = this.bBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 248);
            this.Controls.Add(this.dGVResultadoBusquedaAgencias);
            this.Controls.Add(this.sSBuscarAgencias);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FBuscarAgencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar agencias";
            this.Load += new System.EventHandler(this.FBuscarProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVResultadoBusquedaAgencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSAgencias)).EndInit();
            this.sSBuscarAgencias.ResumeLayout(false);
            this.sSBuscarAgencias.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVResultadoBusquedaAgencias;
        private System.Windows.Forms.StatusStrip sSBuscarAgencias;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bBuscar;
        private System.Windows.Forms.TextBox tBTextoBusqueda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cBBusquedaExacta;
        private System.Windows.Forms.ComboBox cBBuscarPor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bSAgencias;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}