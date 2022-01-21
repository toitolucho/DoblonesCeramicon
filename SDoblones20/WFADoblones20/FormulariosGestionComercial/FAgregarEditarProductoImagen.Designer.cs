namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FAgregarEditarProductoImagen
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
            this.label1 = new System.Windows.Forms.Label();
            this.tBRutaArchivoImagen = new System.Windows.Forms.TextBox();
            this.bBuscarImagen = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.tBNombreImagen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pBImagenProducto = new System.Windows.Forms.PictureBox();
            this.oFDImagen = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pBImagenProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Archivo de imagen del producto";
            // 
            // tBRutaArchivoImagen
            // 
            this.tBRutaArchivoImagen.Location = new System.Drawing.Point(12, 25);
            this.tBRutaArchivoImagen.Name = "tBRutaArchivoImagen";
            this.tBRutaArchivoImagen.Size = new System.Drawing.Size(350, 20);
            this.tBRutaArchivoImagen.TabIndex = 0;
            // 
            // bBuscarImagen
            // 
            this.bBuscarImagen.Location = new System.Drawing.Point(368, 25);
            this.bBuscarImagen.Name = "bBuscarImagen";
            this.bBuscarImagen.Size = new System.Drawing.Size(24, 23);
            this.bBuscarImagen.TabIndex = 1;
            this.bBuscarImagen.Text = "...";
            this.bBuscarImagen.UseVisualStyleBackColor = true;
            this.bBuscarImagen.Click += new System.EventHandler(this.bBuscarImagen_Click);
            // 
            // bAceptar
            // 
            this.bAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bAceptar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.bAceptar.ImageIndex = 3;
            this.bAceptar.Location = new System.Drawing.Point(223, 294);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(80, 30);
            this.bAceptar.TabIndex = 3;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.bCancelar.ImageIndex = 4;
            this.bCancelar.Location = new System.Drawing.Point(309, 294);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(80, 30);
            this.bCancelar.TabIndex = 4;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCancelar.UseVisualStyleBackColor = true;
            // 
            // tBNombreImagen
            // 
            this.tBNombreImagen.Location = new System.Drawing.Point(12, 268);
            this.tBNombreImagen.Name = "tBNombreImagen";
            this.tBNombreImagen.Size = new System.Drawing.Size(377, 20);
            this.tBNombreImagen.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nombre imagen";
            // 
            // pBImagenProducto
            // 
            this.pBImagenProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBImagenProducto.Location = new System.Drawing.Point(12, 54);
            this.pBImagenProducto.Name = "pBImagenProducto";
            this.pBImagenProducto.Size = new System.Drawing.Size(377, 187);
            this.pBImagenProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBImagenProducto.TabIndex = 3;
            this.pBImagenProducto.TabStop = false;
            // 
            // oFDImagen
            // 
            this.oFDImagen.FileName = "openFileDialog1";
            // 
            // FAgregarEditarProductoImagen
            // 
            this.AcceptButton = this.bAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancelar;
            this.ClientSize = new System.Drawing.Size(404, 336);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBNombreImagen);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.pBImagenProducto);
            this.Controls.Add(this.bBuscarImagen);
            this.Controls.Add(this.tBRutaArchivoImagen);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FAgregarEditarProductoImagen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FAgregarEditarImagenProducto";
            ((System.ComponentModel.ISupportInitialize)(this.pBImagenProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBRutaArchivoImagen;
        private System.Windows.Forms.Button bBuscarImagen;
        private System.Windows.Forms.PictureBox pBImagenProducto;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.TextBox tBNombreImagen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog oFDImagen;
    }
}