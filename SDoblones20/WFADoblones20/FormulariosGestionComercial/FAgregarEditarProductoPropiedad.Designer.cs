namespace WFADoblones20
{
    partial class FAgregarEditarProductoPropiedad
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
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tBValorPropiedad = new System.Windows.Forms.TextBox();
            this.cBPropiedadProducto = new System.Windows.Forms.ComboBox();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Valor";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 58;
            this.label12.Text = "Propiedad";
            // 
            // tBValorPropiedad
            // 
            this.tBValorPropiedad.Location = new System.Drawing.Point(75, 38);
            this.tBValorPropiedad.Multiline = true;
            this.tBValorPropiedad.Name = "tBValorPropiedad";
            this.tBValorPropiedad.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBValorPropiedad.Size = new System.Drawing.Size(342, 77);
            this.tBValorPropiedad.TabIndex = 1;
            // 
            // cBPropiedadProducto
            // 
            this.cBPropiedadProducto.FormattingEnabled = true;
            this.cBPropiedadProducto.Location = new System.Drawing.Point(75, 12);
            this.cBPropiedadProducto.Name = "cBPropiedadProducto";
            this.cBPropiedadProducto.Size = new System.Drawing.Size(342, 21);
            this.cBPropiedadProducto.TabIndex = 0;
            // 
            // bCancelar
            // 
            this.bCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCancelar.ImageKey = "Undo.ico";
            this.bCancelar.Location = new System.Drawing.Point(344, 121);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(73, 29);
            this.bCancelar.TabIndex = 3;
            this.bCancelar.Text = "&Cancelar";
            this.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bAceptar
            // 
            this.bAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAceptar.ImageKey = "Save.ico";
            this.bAceptar.Location = new System.Drawing.Point(262, 121);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(75, 29);
            this.bAceptar.TabIndex = 2;
            this.bAceptar.Text = "&Aceptar";
            this.bAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // FAgregarEditarProductoPropiedad
            // 
            this.AcceptButton = this.bAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancelar;
            this.ClientSize = new System.Drawing.Size(428, 160);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.cBPropiedadProducto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tBValorPropiedad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FAgregarEditarProductoPropiedad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FAgregarEditarProductoPropiedad";
            this.Load += new System.EventHandler(this.FAgregarEditarProductoPropiedad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tBValorPropiedad;
        private System.Windows.Forms.ComboBox cBPropiedadProducto;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
    }
}