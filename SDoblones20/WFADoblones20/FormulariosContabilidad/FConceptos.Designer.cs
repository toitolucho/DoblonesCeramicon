namespace WFADoblones20.FormulariosContabilidad
{
    partial class FConceptos
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
            this.btNuevo = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.dgvConceptos = new System.Windows.Forms.DataGridView();
            this.dgvcNumeroConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).BeginInit();
            this.SuspendLayout();
            // 
            // btNuevo
            // 
            this.btNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNuevo.Location = new System.Drawing.Point(24, 13);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(58, 23);
            this.btNuevo.TabIndex = 0;
            this.btNuevo.Text = "Nuevo";
            this.btNuevo.UseVisualStyleBackColor = true;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEliminar.Enabled = false;
            this.btEliminar.Location = new System.Drawing.Point(88, 13);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(58, 23);
            this.btEliminar.TabIndex = 1;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btActualizar
            // 
            this.btActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btActualizar.Enabled = false;
            this.btActualizar.Location = new System.Drawing.Point(152, 13);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(58, 23);
            this.btActualizar.TabIndex = 2;
            this.btActualizar.Text = "Modificar";
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // dgvConceptos
            // 
            this.dgvConceptos.AllowUserToAddRows = false;
            this.dgvConceptos.AllowUserToDeleteRows = false;
            this.dgvConceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConceptos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcNumeroConcepto,
            this.dgvcConcepto});
            this.dgvConceptos.Location = new System.Drawing.Point(2, 42);
            this.dgvConceptos.MultiSelect = false;
            this.dgvConceptos.Name = "dgvConceptos";
            this.dgvConceptos.ReadOnly = true;
            this.dgvConceptos.RowHeadersVisible = false;
            this.dgvConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvConceptos.Size = new System.Drawing.Size(231, 269);
            this.dgvConceptos.TabIndex = 3;
            this.dgvConceptos.SelectionChanged += new System.EventHandler(this.dgvConceptos_SelectionChanged);
            // 
            // dgvcNumeroConcepto
            // 
            this.dgvcNumeroConcepto.DataPropertyName = "NumeroConcepto";
            this.dgvcNumeroConcepto.HeaderText = "NºConcepto";
            this.dgvcNumeroConcepto.Name = "dgvcNumeroConcepto";
            this.dgvcNumeroConcepto.ReadOnly = true;
            this.dgvcNumeroConcepto.Visible = false;
            // 
            // dgvcConcepto
            // 
            this.dgvcConcepto.DataPropertyName = "Concepto";
            this.dgvcConcepto.HeaderText = "Concepto";
            this.dgvcConcepto.Name = "dgvcConcepto";
            this.dgvcConcepto.ReadOnly = true;
            // 
            // FConceptos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 312);
            this.Controls.Add(this.dgvConceptos);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btNuevo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FConceptos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conceptos";
            this.Load += new System.EventHandler(this.FConceptos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btNuevo;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.DataGridView dgvConceptos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumeroConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcConcepto;
    }
}