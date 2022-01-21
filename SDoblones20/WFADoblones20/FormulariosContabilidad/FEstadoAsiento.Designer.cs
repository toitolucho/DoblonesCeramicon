namespace WFADoblones20.FormulariosContabilidad
{
    partial class FEstadoAsiento
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
            this.rbConfirmado = new System.Windows.Forms.RadioButton();
            this.rbPendiente = new System.Windows.Forms.RadioButton();
            this.btAceptar = new System.Windows.Forms.Button();
            this.brCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbPendiente);
            this.groupBox1.Controls.Add(this.rbConfirmado);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Guardar el asiento como:";
            // 
            // rbConfirmado
            // 
            this.rbConfirmado.AutoSize = true;
            this.rbConfirmado.Checked = true;
            this.rbConfirmado.Location = new System.Drawing.Point(56, 19);
            this.rbConfirmado.Name = "rbConfirmado";
            this.rbConfirmado.Size = new System.Drawing.Size(78, 17);
            this.rbConfirmado.TabIndex = 0;
            this.rbConfirmado.TabStop = true;
            this.rbConfirmado.Text = "Confirmado";
            this.rbConfirmado.UseVisualStyleBackColor = true;
            // 
            // rbPendiente
            // 
            this.rbPendiente.AutoSize = true;
            this.rbPendiente.Location = new System.Drawing.Point(56, 42);
            this.rbPendiente.Name = "rbPendiente";
            this.rbPendiente.Size = new System.Drawing.Size(73, 17);
            this.rbPendiente.TabIndex = 1;
            this.rbPendiente.Text = "Pendiente";
            this.rbPendiente.UseVisualStyleBackColor = true;
            // 
            // btAceptar
            // 
            this.btAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAceptar.Location = new System.Drawing.Point(46, 87);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 1;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // brCancelar
            // 
            this.brCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.brCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.brCancelar.Location = new System.Drawing.Point(127, 87);
            this.brCancelar.Name = "brCancelar";
            this.brCancelar.Size = new System.Drawing.Size(75, 23);
            this.brCancelar.TabIndex = 2;
            this.brCancelar.Text = "Cancelar";
            this.brCancelar.UseVisualStyleBackColor = true;
            this.brCancelar.Click += new System.EventHandler(this.brCancelar_Click);
            // 
            // FEstadoAsiento
            // 
            this.AcceptButton = this.btAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.brCancelar;
            this.ClientSize = new System.Drawing.Size(214, 116);
            this.Controls.Add(this.brCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FEstadoAsiento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar estado";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPendiente;
        private System.Windows.Forms.RadioButton rbConfirmado;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button brCancelar;
    }
}