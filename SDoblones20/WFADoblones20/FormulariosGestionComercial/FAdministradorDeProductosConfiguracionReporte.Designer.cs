namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FAdministradorDeProductosConfiguracionReporte
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBtntodosLosPrecios = new System.Windows.Forms.RadioButton();
            this.rBtnPreciosConFactura = new System.Windows.Forms.RadioButton();
            this.rBtnPreciosSinFactura = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBtnPreciosSinFactura);
            this.groupBox1.Controls.Add(this.rBtnPreciosConFactura);
            this.groupBox1.Controls.Add(this.rBtntodosLosPrecios);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 36);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipos de Precio";
            // 
            // rBtntodosLosPrecios
            // 
            this.rBtntodosLosPrecios.AutoSize = true;
            this.rBtntodosLosPrecios.Checked = true;
            this.rBtntodosLosPrecios.Location = new System.Drawing.Point(6, 13);
            this.rBtntodosLosPrecios.Name = "rBtntodosLosPrecios";
            this.rBtntodosLosPrecios.Size = new System.Drawing.Size(109, 17);
            this.rBtntodosLosPrecios.TabIndex = 0;
            this.rBtntodosLosPrecios.TabStop = true;
            this.rBtntodosLosPrecios.Text = "Todos los Precios";
            this.rBtntodosLosPrecios.UseVisualStyleBackColor = true;
            // 
            // rBtnPreciosConFactura
            // 
            this.rBtnPreciosConFactura.AutoSize = true;
            this.rBtnPreciosConFactura.Location = new System.Drawing.Point(117, 13);
            this.rBtnPreciosConFactura.Name = "rBtnPreciosConFactura";
            this.rBtnPreciosConFactura.Size = new System.Drawing.Size(120, 17);
            this.rBtnPreciosConFactura.TabIndex = 1;
            this.rBtnPreciosConFactura.Text = "Precios con Factura";
            this.rBtnPreciosConFactura.UseVisualStyleBackColor = true;
            // 
            // rBtnPreciosSinFactura
            // 
            this.rBtnPreciosSinFactura.AutoSize = true;
            this.rBtnPreciosSinFactura.Location = new System.Drawing.Point(243, 13);
            this.rBtnPreciosSinFactura.Name = "rBtnPreciosSinFactura";
            this.rBtnPreciosSinFactura.Size = new System.Drawing.Size(115, 17);
            this.rBtnPreciosSinFactura.TabIndex = 2;
            this.rBtnPreciosSinFactura.Text = "Precios sin Factura";
            this.rBtnPreciosSinFactura.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(309, 54);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.Location = new System.Drawing.Point(228, 54);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // FAdministradorDeProductosConfiguracionReporte
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(393, 81);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FAdministradorDeProductosConfiguracionReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración del Informe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBtnPreciosSinFactura;
        private System.Windows.Forms.RadioButton rBtnPreciosConFactura;
        private System.Windows.Forms.RadioButton rBtntodosLosPrecios;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}