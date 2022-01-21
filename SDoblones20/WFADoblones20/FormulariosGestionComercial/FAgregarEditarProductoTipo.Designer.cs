namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FAgregarEditarProductoTipo
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
            this.tBDescripcionTipoProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.tBNombreCortoTipoProducto = new System.Windows.Forms.TextBox();
            this.tBNombreTipoProducto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tBDescripcionTipoProducto
            // 
            this.tBDescripcionTipoProducto.Location = new System.Drawing.Point(159, 79);
            this.tBDescripcionTipoProducto.Multiline = true;
            this.tBDescripcionTipoProducto.Name = "tBDescripcionTipoProducto";
            this.tBDescripcionTipoProducto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBDescripcionTipoProducto.Size = new System.Drawing.Size(250, 48);
            this.tBDescripcionTipoProducto.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Descripción tipo producto";
            // 
            // bCancelar
            // 
            this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelar.Location = new System.Drawing.Point(334, 133);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 23);
            this.bCancelar.TabIndex = 8;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bAceptar
            // 
            this.bAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bAceptar.Location = new System.Drawing.Point(253, 133);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(75, 23);
            this.bAceptar.TabIndex = 7;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // tBNombreCortoTipoProducto
            // 
            this.tBNombreCortoTipoProducto.Location = new System.Drawing.Point(159, 52);
            this.tBNombreCortoTipoProducto.Name = "tBNombreCortoTipoProducto";
            this.tBNombreCortoTipoProducto.Size = new System.Drawing.Size(150, 20);
            this.tBNombreCortoTipoProducto.TabIndex = 4;
            // 
            // tBNombreTipoProducto
            // 
            this.tBNombreTipoProducto.Location = new System.Drawing.Point(159, 26);
            this.tBNombreTipoProducto.Name = "tBNombreTipoProducto";
            this.tBNombreTipoProducto.Size = new System.Drawing.Size(250, 20);
            this.tBNombreTipoProducto.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Nombre corto tipo producto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Nombre tipo producto";
            // 
            // FAgregarEditarTipoProducto
            // 
            this.AcceptButton = this.bAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancelar;
            this.ClientSize = new System.Drawing.Size(423, 166);
            this.Controls.Add(this.tBDescripcionTipoProducto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.tBNombreCortoTipoProducto);
            this.Controls.Add(this.tBNombreTipoProducto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FAgregarEditarTipoProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar & editar tipo producto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBDescripcionTipoProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.TextBox tBNombreCortoTipoProducto;
        private System.Windows.Forms.TextBox tBNombreTipoProducto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}