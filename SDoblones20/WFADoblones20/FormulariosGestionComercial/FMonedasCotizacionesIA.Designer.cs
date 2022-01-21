namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FMonedasCotizacionesIA
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
            this.bCancelar = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.cBMonedaCotizacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dTPFEchaHoraCotizacion = new System.Windows.Forms.DateTimePicker();
            this.cBMoneda = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBCambioOficial = new System.Windows.Forms.TextBox();
            this.tBCambioParalelo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bCancelar
            // 
            this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelar.Location = new System.Drawing.Point(240, 146);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 23);
            this.bCancelar.TabIndex = 6;
            this.bCancelar.Text = "&Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(160, 146);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(75, 23);
            this.bAceptar.TabIndex = 5;
            this.bAceptar.Text = "&Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // cBMonedaCotizacion
            // 
            this.cBMonedaCotizacion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBMonedaCotizacion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBMonedaCotizacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBMonedaCotizacion.FormattingEnabled = true;
            this.cBMonedaCotizacion.Location = new System.Drawing.Point(115, 63);
            this.cBMonedaCotizacion.Name = "cBMonedaCotizacion";
            this.cBMonedaCotizacion.Size = new System.Drawing.Size(200, 21);
            this.cBMonedaCotizacion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Moneda cotización";
            // 
            // dTPFEchaHoraCotizacion
            // 
            this.dTPFEchaHoraCotizacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPFEchaHoraCotizacion.Location = new System.Drawing.Point(115, 38);
            this.dTPFEchaHoraCotizacion.Name = "dTPFEchaHoraCotizacion";
            this.dTPFEchaHoraCotizacion.Size = new System.Drawing.Size(90, 20);
            this.dTPFEchaHoraCotizacion.TabIndex = 1;
            // 
            // cBMoneda
            // 
            this.cBMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBMoneda.Enabled = false;
            this.cBMoneda.FormattingEnabled = true;
            this.cBMoneda.Location = new System.Drawing.Point(115, 12);
            this.cBMoneda.Name = "cBMoneda";
            this.cBMoneda.Size = new System.Drawing.Size(200, 21);
            this.cBMoneda.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Cambio paralelo";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Fecha cotización";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Cambio oficial";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Moneda";
            // 
            // tBCambioOficial
            // 
            this.tBCambioOficial.Location = new System.Drawing.Point(115, 90);
            this.tBCambioOficial.Name = "tBCambioOficial";
            this.tBCambioOficial.Size = new System.Drawing.Size(80, 20);
            this.tBCambioOficial.TabIndex = 3;
            this.tBCambioOficial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBCambioOficial.TextChanged += new System.EventHandler(this.tBCambioOficial_TextChanged);
            this.tBCambioOficial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBCambioOficial_KeyPress);
            // 
            // tBCambioParalelo
            // 
            this.tBCambioParalelo.Location = new System.Drawing.Point(115, 116);
            this.tBCambioParalelo.Name = "tBCambioParalelo";
            this.tBCambioParalelo.Size = new System.Drawing.Size(80, 20);
            this.tBCambioParalelo.TabIndex = 4;
            this.tBCambioParalelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBCambioParalelo.TextChanged += new System.EventHandler(this.tBCambioParalelo_TextChanged);
            this.tBCambioParalelo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBCambioOficial_KeyPress);
            // 
            // FMonedasCotizacionesIA
            // 
            this.AcceptButton = this.bAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancelar;
            this.ClientSize = new System.Drawing.Size(327, 176);
            this.Controls.Add(this.tBCambioParalelo);
            this.Controls.Add(this.tBCambioOficial);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.cBMonedaCotizacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dTPFEchaHoraCotizacion);
            this.Controls.Add(this.cBMoneda);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FMonedasCotizacionesIA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FMonedasCotizacionesIA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.ComboBox cBMonedaCotizacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dTPFEchaHoraCotizacion;
        private System.Windows.Forms.ComboBox cBMoneda;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBCambioOficial;
        private System.Windows.Forms.TextBox tBCambioParalelo;
    }
}