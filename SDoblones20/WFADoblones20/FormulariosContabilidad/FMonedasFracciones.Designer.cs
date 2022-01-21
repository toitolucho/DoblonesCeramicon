namespace WFADoblones20.FormulariosContabilidad
{
    partial class FMonedasFracciones
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbMonedas = new System.Windows.Forms.ComboBox();
            this.dgvMonedasFracciones = new System.Windows.Forms.DataGridView();
            this.dgvcCodigoMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCodigoMonedaFraccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btNueva = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btModificar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonedasFracciones)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Moneda:";
            // 
            // cbMonedas
            // 
            this.cbMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonedas.FormattingEnabled = true;
            this.cbMonedas.Location = new System.Drawing.Point(12, 28);
            this.cbMonedas.Name = "cbMonedas";
            this.cbMonedas.Size = new System.Drawing.Size(121, 21);
            this.cbMonedas.TabIndex = 0;
            this.cbMonedas.SelectedIndexChanged += new System.EventHandler(this.cbMonedas_SelectedIndexChanged);
            // 
            // dgvMonedasFracciones
            // 
            this.dgvMonedasFracciones.AllowUserToAddRows = false;
            this.dgvMonedasFracciones.AllowUserToDeleteRows = false;
            this.dgvMonedasFracciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonedasFracciones.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvMonedasFracciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonedasFracciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcCodigoMoneda,
            this.dgvcCodigoMonedaFraccion,
            this.dgvcValor});
            this.dgvMonedasFracciones.Location = new System.Drawing.Point(139, 28);
            this.dgvMonedasFracciones.Name = "dgvMonedasFracciones";
            this.dgvMonedasFracciones.ReadOnly = true;
            this.dgvMonedasFracciones.RowHeadersVisible = false;
            this.dgvMonedasFracciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMonedasFracciones.ShowEditingIcon = false;
            this.dgvMonedasFracciones.Size = new System.Drawing.Size(143, 150);
            this.dgvMonedasFracciones.TabIndex = 1;
            this.dgvMonedasFracciones.DoubleClick += new System.EventHandler(this.dgvMonedasFracciones_DoubleClick);
            // 
            // dgvcCodigoMoneda
            // 
            this.dgvcCodigoMoneda.DataPropertyName = "CodigoMoneda";
            this.dgvcCodigoMoneda.HeaderText = "CodMoneda";
            this.dgvcCodigoMoneda.Name = "dgvcCodigoMoneda";
            this.dgvcCodigoMoneda.ReadOnly = true;
            this.dgvcCodigoMoneda.Visible = false;
            // 
            // dgvcCodigoMonedaFraccion
            // 
            this.dgvcCodigoMonedaFraccion.DataPropertyName = "CodigoMonedaFraccion";
            this.dgvcCodigoMonedaFraccion.HeaderText = "CodMonedaFraccion";
            this.dgvcCodigoMonedaFraccion.Name = "dgvcCodigoMonedaFraccion";
            this.dgvcCodigoMonedaFraccion.ReadOnly = true;
            this.dgvcCodigoMonedaFraccion.Visible = false;
            // 
            // dgvcValor
            // 
            this.dgvcValor.DataPropertyName = "Valor";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.dgvcValor.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvcValor.HeaderText = "Valor";
            this.dgvcValor.Name = "dgvcValor";
            this.dgvcValor.ReadOnly = true;
            // 
            // btNueva
            // 
            this.btNueva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNueva.Location = new System.Drawing.Point(28, 184);
            this.btNueva.Name = "btNueva";
            this.btNueva.Size = new System.Drawing.Size(75, 23);
            this.btNueva.TabIndex = 2;
            this.btNueva.Text = "Nueva";
            this.btNueva.UseVisualStyleBackColor = true;
            this.btNueva.Click += new System.EventHandler(this.btNueva_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEliminar.Location = new System.Drawing.Point(109, 184);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(75, 23);
            this.btEliminar.TabIndex = 3;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btModificar
            // 
            this.btModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModificar.Location = new System.Drawing.Point(190, 184);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(75, 23);
            this.btModificar.TabIndex = 4;
            this.btModificar.Text = "Modificar";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btCancelar);
            this.panel1.Location = new System.Drawing.Point(12, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 35);
            this.panel1.TabIndex = 6;
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(186, 4);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 0;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fraccionamiento:";
            // 
            // FMonedasFracciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(292, 260);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btModificar);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btNueva);
            this.Controls.Add(this.dgvMonedasFracciones);
            this.Controls.Add(this.cbMonedas);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FMonedasFracciones";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monedas fracciones";
            this.Load += new System.EventHandler(this.FMonedasFracciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonedasFracciones)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMonedas;
        private System.Windows.Forms.DataGridView dgvMonedasFracciones;
        private System.Windows.Forms.Button btNueva;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCodigoMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCodigoMonedaFraccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcValor;
    }
}