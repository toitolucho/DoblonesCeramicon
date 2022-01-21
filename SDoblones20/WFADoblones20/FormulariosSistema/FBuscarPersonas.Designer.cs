namespace WFADoblones20.FormulariosSistema
{
    partial class FBuscarPersonas
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGVResultadoBusquedaPersonas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSPersonas = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sSBuscarPersonas = new System.Windows.Forms.StatusStrip();
            this.bBuscar = new System.Windows.Forms.Button();
            this.tBTextoBusqueda = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cBBusquedaExacta = new System.Windows.Forms.CheckBox();
            this.cBBuscarPor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dGVResultadoBusquedaPersonas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSPersonas)).BeginInit();
            this.sSBuscarPersonas.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DIPersona";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.HeaderText = "D.I.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 60;
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
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreCompleto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre Completo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dGVResultadoBusquedaPersonas
            // 
            this.dGVResultadoBusquedaPersonas.AllowUserToAddRows = false;
            this.dGVResultadoBusquedaPersonas.AllowUserToDeleteRows = false;
            this.dGVResultadoBusquedaPersonas.AllowUserToResizeRows = false;
            this.dGVResultadoBusquedaPersonas.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVResultadoBusquedaPersonas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVResultadoBusquedaPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVResultadoBusquedaPersonas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dGVResultadoBusquedaPersonas.DataSource = this.bSPersonas;
            this.dGVResultadoBusquedaPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVResultadoBusquedaPersonas.Location = new System.Drawing.Point(0, 72);
            this.dGVResultadoBusquedaPersonas.MultiSelect = false;
            this.dGVResultadoBusquedaPersonas.Name = "dGVResultadoBusquedaPersonas";
            this.dGVResultadoBusquedaPersonas.ReadOnly = true;
            this.dGVResultadoBusquedaPersonas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dGVResultadoBusquedaPersonas.RowHeadersVisible = false;
            this.dGVResultadoBusquedaPersonas.RowTemplate.ReadOnly = true;
            this.dGVResultadoBusquedaPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVResultadoBusquedaPersonas.Size = new System.Drawing.Size(582, 300);
            this.dGVResultadoBusquedaPersonas.TabIndex = 14;
            this.dGVResultadoBusquedaPersonas.VirtualMode = true;
            this.dGVResultadoBusquedaPersonas.DoubleClick += new System.EventHandler(this.dGVResultadoBusquedaPersonas_DoubleClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Sexo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn3.HeaderText = "Sexo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 40;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Celular";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn4.HeaderText = "Celular";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Email";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn5.HeaderText = "Email";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn6.HeaderText = "Dirección";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn7.HeaderText = "Telefono(s)";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // sSBuscarPersonas
            // 
            this.sSBuscarPersonas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.sSBuscarPersonas.Location = new System.Drawing.Point(0, 372);
            this.sSBuscarPersonas.MinimumSize = new System.Drawing.Size(0, 22);
            this.sSBuscarPersonas.Name = "sSBuscarPersonas";
            this.sSBuscarPersonas.Size = new System.Drawing.Size(582, 22);
            this.sSBuscarPersonas.TabIndex = 13;
            this.sSBuscarPersonas.Text = "statusStrip1";
            // 
            // bBuscar
            // 
            this.bBuscar.Location = new System.Drawing.Point(385, 41);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(75, 23);
            this.bBuscar.TabIndex = 3;
            this.bBuscar.Text = "Buscar";
            this.bBuscar.UseVisualStyleBackColor = true;
            this.bBuscar.Click += new System.EventHandler(this.bBuscar_Click);
            // 
            // tBTextoBusqueda
            // 
            this.tBTextoBusqueda.Location = new System.Drawing.Point(121, 43);
            this.tBTextoBusqueda.Name = "tBTextoBusqueda";
            this.tBTextoBusqueda.Size = new System.Drawing.Size(258, 20);
            this.tBTextoBusqueda.TabIndex = 2;
            this.tBTextoBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBTextoBusqueda_KeyPress);
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
            this.panel2.Size = new System.Drawing.Size(582, 72);
            this.panel2.TabIndex = 3;
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
            "Documento identificación",
            "Apellido paterno",
            "Apellido materno",
            "Nombre(s)",
            "Parte nombre",
            "Celular",
            "Email",
            "Dirección",
            "Teléfono"});
            this.cBBuscarPor.Location = new System.Drawing.Point(79, 12);
            this.cBBuscarPor.Name = "cBBuscarPor";
            this.cBBuscarPor.Size = new System.Drawing.Size(152, 21);
            this.cBBuscarPor.TabIndex = 0;
            this.cBBuscarPor.SelectedIndexChanged += new System.EventHandler(this.cBBuscarPor_SelectedIndexChanged);
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
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 72);
            this.panel1.TabIndex = 12;
            // 
            // FBuscarPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 394);
            this.Controls.Add(this.dGVResultadoBusquedaPersonas);
            this.Controls.Add(this.sSBuscarPersonas);
            this.Controls.Add(this.panel1);
            this.Name = "FBuscarPersonas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar personas";
            this.Load += new System.EventHandler(this.FBuscarPersonas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVResultadoBusquedaPersonas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSPersonas)).EndInit();
            this.sSBuscarPersonas.ResumeLayout(false);
            this.sSBuscarPersonas.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView dGVResultadoBusquedaPersonas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.BindingSource bSPersonas;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip sSBuscarPersonas;
        private System.Windows.Forms.Button bBuscar;
        private System.Windows.Forms.TextBox tBTextoBusqueda;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cBBusquedaExacta;
        private System.Windows.Forms.ComboBox cBBuscarPor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}