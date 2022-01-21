namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FAgregarEditarProductoComponente
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
            this.cBProductoComponente = new System.Windows.Forms.ComboBox();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tBCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cBProductoComponente
            // 
            this.cBProductoComponente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBProductoComponente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBProductoComponente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBProductoComponente.FormattingEnabled = true;
            this.cBProductoComponente.Location = new System.Drawing.Point(82, 12);
            this.cBProductoComponente.Name = "cBProductoComponente";
            this.cBProductoComponente.Size = new System.Drawing.Size(400, 21);
            this.cBProductoComponente.TabIndex = 0;
            // 
            // bCancelar
            // 
            this.bCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCancelar.ImageKey = "Undo.ico";
            this.bCancelar.Location = new System.Drawing.Point(409, 65);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(73, 29);
            this.bCancelar.TabIndex = 3;
            this.bCancelar.Text = "&Cancelar";
            this.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCancelar.UseVisualStyleBackColor = true;
            // 
            // bAceptar
            // 
            this.bAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAceptar.ImageKey = "Save.ico";
            this.bAceptar.Location = new System.Drawing.Point(327, 65);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(75, 29);
            this.bAceptar.TabIndex = 2;
            this.bAceptar.Text = "&Aceptar";
            this.bAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Componente";
            // 
            // tBCantidad
            // 
            this.tBCantidad.Location = new System.Drawing.Point(82, 39);
            this.tBCantidad.Name = "tBCantidad";
            this.tBCantidad.Size = new System.Drawing.Size(100, 20);
            this.tBCantidad.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Cantidad";
            // 
            // FAgregarEditarProductoComponente
            // 
            this.AcceptButton = this.bAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancelar;
            this.ClientSize = new System.Drawing.Size(493, 103);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBCantidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.cBProductoComponente);
            this.Name = "FAgregarEditarProductoComponente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FAgregarEditarProductoComponente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBProductoComponente;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBCantidad;
        private System.Windows.Forms.Label label2;
    }
}