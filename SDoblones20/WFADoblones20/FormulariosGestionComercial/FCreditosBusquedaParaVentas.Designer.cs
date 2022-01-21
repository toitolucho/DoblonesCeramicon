namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FCreditosBusquedaParaVentas
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
            this.gBoxSuperior = new System.Windows.Forms.GroupBox();
            this.gBoxInferior = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.checkExactamenteIgual = new System.Windows.Forms.CheckBox();
            this.txtBoxEncontrados = new System.Windows.Forms.TextBox();
            this.cBoxBuscarPor = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dtGVCreditosEncontrados = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gBoxSuperior.SuspendLayout();
            this.gBoxInferior.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVCreditosEncontrados)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxSuperior
            // 
            this.gBoxSuperior.Controls.Add(this.cBoxBuscarPor);
            this.gBoxSuperior.Controls.Add(this.txtBoxEncontrados);
            this.gBoxSuperior.Controls.Add(this.checkExactamenteIgual);
            this.gBoxSuperior.Controls.Add(this.btnBuscar);
            this.gBoxSuperior.Controls.Add(this.label2);
            this.gBoxSuperior.Controls.Add(this.label1);
            this.gBoxSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxSuperior.Location = new System.Drawing.Point(0, 0);
            this.gBoxSuperior.Name = "gBoxSuperior";
            this.gBoxSuperior.Size = new System.Drawing.Size(568, 79);
            this.gBoxSuperior.TabIndex = 0;
            this.gBoxSuperior.TabStop = false;
            this.gBoxSuperior.Text = "Opciones de Busqueda";
            // 
            // gBoxInferior
            // 
            this.gBoxInferior.Controls.Add(this.dtGVCreditosEncontrados);
            this.gBoxInferior.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxInferior.Location = new System.Drawing.Point(0, 79);
            this.gBoxInferior.Name = "gBoxInferior";
            this.gBoxInferior.Size = new System.Drawing.Size(568, 228);
            this.gBoxInferior.TabIndex = 1;
            this.gBoxInferior.TabStop = false;
            this.gBoxInferior.Text = "Registros Encontrados :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar Por";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Texto a Buscar";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(463, 44);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // checkExactamenteIgual
            // 
            this.checkExactamenteIgual.AutoSize = true;
            this.checkExactamenteIgual.Location = new System.Drawing.Point(424, 20);
            this.checkExactamenteIgual.Name = "checkExactamenteIgual";
            this.checkExactamenteIgual.Size = new System.Drawing.Size(114, 17);
            this.checkExactamenteIgual.TabIndex = 3;
            this.checkExactamenteIgual.Text = "&Exactamente Igual";
            this.checkExactamenteIgual.UseVisualStyleBackColor = true;
            // 
            // txtBoxEncontrados
            // 
            this.txtBoxEncontrados.Location = new System.Drawing.Point(90, 47);
            this.txtBoxEncontrados.Name = "txtBoxEncontrados";
            this.txtBoxEncontrados.Size = new System.Drawing.Size(367, 20);
            this.txtBoxEncontrados.TabIndex = 4;
            // 
            // cBoxBuscarPor
            // 
            this.cBoxBuscarPor.FormattingEnabled = true;
            this.cBoxBuscarPor.Location = new System.Drawing.Point(90, 20);
            this.cBoxBuscarPor.Name = "cBoxBuscarPor";
            this.cBoxBuscarPor.Size = new System.Drawing.Size(151, 21);
            this.cBoxBuscarPor.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAceptar);
            this.flowLayoutPanel1.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 313);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(7);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(568, 49);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // dtGVCreditosEncontrados
            // 
            this.dtGVCreditosEncontrados.AllowUserToAddRows = false;
            this.dtGVCreditosEncontrados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtGVCreditosEncontrados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVCreditosEncontrados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVCreditosEncontrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVCreditosEncontrados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVCreditosEncontrados.Location = new System.Drawing.Point(3, 16);
            this.dtGVCreditosEncontrados.Name = "dtGVCreditosEncontrados";
            this.dtGVCreditosEncontrados.RowHeadersVisible = false;
            this.dtGVCreditosEncontrados.Size = new System.Drawing.Size(562, 209);
            this.dtGVCreditosEncontrados.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(476, 10);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(395, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FCreditosBusquedaParaVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 362);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gBoxInferior);
            this.Controls.Add(this.gBoxSuperior);
            this.Name = "FCreditosBusquedaParaVentas";
            this.Text = "Buscar Creditos Habilitados";
            this.gBoxSuperior.ResumeLayout(false);
            this.gBoxSuperior.PerformLayout();
            this.gBoxInferior.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVCreditosEncontrados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxSuperior;
        private System.Windows.Forms.GroupBox gBoxInferior;
        private System.Windows.Forms.ComboBox cBoxBuscarPor;
        private System.Windows.Forms.TextBox txtBoxEncontrados;
        private System.Windows.Forms.CheckBox checkExactamenteIgual;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtGVCreditosEncontrados;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}