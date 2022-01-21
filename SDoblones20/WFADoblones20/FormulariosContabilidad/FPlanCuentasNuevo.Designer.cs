namespace WFADoblones20.FormulariosContabilidad
{
    partial class FPlanCuentasNuevo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPlanCuentasNuevo));
            this.label1 = new System.Windows.Forms.Label();
            this.cbNumeroCuentaPadre = new System.Windows.Forms.ComboBox();
            this.cbNombreCuentaPadre = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNombreCuenta = new System.Windows.Forms.TextBox();
            this.chbSelCtaPadre = new System.Windows.Forms.CheckBox();
            this.pbOk = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNumCta5 = new System.Windows.Forms.TextBox();
            this.tbNumCta4 = new System.Windows.Forms.TextBox();
            this.tbNumCta3 = new System.Windows.Forms.TextBox();
            this.tbNumCta2 = new System.Windows.Forms.TextBox();
            this.tbNumCta1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº cuenta:";
            // 
            // cbNumeroCuentaPadre
            // 
            this.cbNumeroCuentaPadre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbNumeroCuentaPadre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNumeroCuentaPadre.Location = new System.Drawing.Point(110, 23);
            this.cbNumeroCuentaPadre.Name = "cbNumeroCuentaPadre";
            this.cbNumeroCuentaPadre.Size = new System.Drawing.Size(128, 21);
            this.cbNumeroCuentaPadre.TabIndex = 1;
            this.cbNumeroCuentaPadre.SelectedIndexChanged += new System.EventHandler(this.cbNumeroCuentaPadre_SelectedIndexChanged);
            this.cbNumeroCuentaPadre.Leave += new System.EventHandler(this.cbNumeroCuentaPadre_Leave);
            this.cbNumeroCuentaPadre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbNumeroCuentaPadre_KeyUp);
            // 
            // cbNombreCuentaPadre
            // 
            this.cbNombreCuentaPadre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbNombreCuentaPadre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNombreCuentaPadre.FormattingEnabled = true;
            this.cbNombreCuentaPadre.Location = new System.Drawing.Point(110, 50);
            this.cbNombreCuentaPadre.Name = "cbNombreCuentaPadre";
            this.cbNombreCuentaPadre.Size = new System.Drawing.Size(290, 21);
            this.cbNombreCuentaPadre.TabIndex = 2;
            this.cbNombreCuentaPadre.Leave += new System.EventHandler(this.cbNombreCuentaPadre_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Descripción:";
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(110, 143);
            this.tbDescripcion.MaxLength = 250;
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(290, 58);
            this.tbDescripcion.TabIndex = 9;
            // 
            // btAceptar
            // 
            this.btAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAceptar.Location = new System.Drawing.Point(246, 207);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 10;
            this.btAceptar.Text = "Registrar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(327, 207);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 11;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nombre:";
            // 
            // tbNombreCuenta
            // 
            this.tbNombreCuenta.Location = new System.Drawing.Point(110, 117);
            this.tbNombreCuenta.MaxLength = 250;
            this.tbNombreCuenta.Name = "tbNombreCuenta";
            this.tbNombreCuenta.Size = new System.Drawing.Size(290, 20);
            this.tbNombreCuenta.TabIndex = 8;
            // 
            // chbSelCtaPadre
            // 
            this.chbSelCtaPadre.AutoSize = true;
            this.chbSelCtaPadre.Checked = true;
            this.chbSelCtaPadre.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSelCtaPadre.Enabled = false;
            this.chbSelCtaPadre.Location = new System.Drawing.Point(14, 25);
            this.chbSelCtaPadre.Name = "chbSelCtaPadre";
            this.chbSelCtaPadre.Size = new System.Drawing.Size(90, 17);
            this.chbSelCtaPadre.TabIndex = 0;
            this.chbSelCtaPadre.Text = "Cuenta padre";
            this.chbSelCtaPadre.UseVisualStyleBackColor = true;
            this.chbSelCtaPadre.CheckedChanged += new System.EventHandler(this.chbSelCtaPadre_CheckedChanged);
            // 
            // pbOk
            // 
            this.pbOk.Image = ((System.Drawing.Image)(resources.GetObject("pbOk.Image")));
            this.pbOk.Location = new System.Drawing.Point(344, 79);
            this.pbOk.Name = "pbOk";
            this.pbOk.Size = new System.Drawing.Size(39, 32);
            this.pbOk.TabIndex = 31;
            this.pbOk.TabStop = false;
            this.pbOk.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "-";
            // 
            // tbNumCta5
            // 
            this.tbNumCta5.Location = new System.Drawing.Point(310, 91);
            this.tbNumCta5.MaxLength = 3;
            this.tbNumCta5.Name = "tbNumCta5";
            this.tbNumCta5.ReadOnly = true;
            this.tbNumCta5.Size = new System.Drawing.Size(28, 20);
            this.tbNumCta5.TabIndex = 7;
            this.tbNumCta5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNumCta5.Leave += new System.EventHandler(this.tbNumCta5_Leave);
            this.tbNumCta5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNumCta5_KeyUp);
            this.tbNumCta5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumCta5_KeyPress);
            // 
            // tbNumCta4
            // 
            this.tbNumCta4.Location = new System.Drawing.Point(260, 91);
            this.tbNumCta4.MaxLength = 2;
            this.tbNumCta4.Name = "tbNumCta4";
            this.tbNumCta4.ReadOnly = true;
            this.tbNumCta4.Size = new System.Drawing.Size(28, 20);
            this.tbNumCta4.TabIndex = 6;
            this.tbNumCta4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNumCta4.Leave += new System.EventHandler(this.tbNumCta4_Leave);
            this.tbNumCta4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNumCta4_KeyUp);
            this.tbNumCta4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumCta4_KeyPress);
            // 
            // tbNumCta3
            // 
            this.tbNumCta3.Location = new System.Drawing.Point(210, 91);
            this.tbNumCta3.MaxLength = 2;
            this.tbNumCta3.Name = "tbNumCta3";
            this.tbNumCta3.ReadOnly = true;
            this.tbNumCta3.Size = new System.Drawing.Size(28, 20);
            this.tbNumCta3.TabIndex = 5;
            this.tbNumCta3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNumCta3.Leave += new System.EventHandler(this.tbNumCta3_Leave);
            this.tbNumCta3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNumCta3_KeyUp);
            this.tbNumCta3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumCta3_KeyPress);
            // 
            // tbNumCta2
            // 
            this.tbNumCta2.Location = new System.Drawing.Point(160, 91);
            this.tbNumCta2.MaxLength = 1;
            this.tbNumCta2.Name = "tbNumCta2";
            this.tbNumCta2.ReadOnly = true;
            this.tbNumCta2.Size = new System.Drawing.Size(28, 20);
            this.tbNumCta2.TabIndex = 4;
            this.tbNumCta2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNumCta2.Leave += new System.EventHandler(this.tbNumCta2_Leave);
            this.tbNumCta2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNumCta2_KeyUp);
            this.tbNumCta2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumCta2_KeyPress);
            // 
            // tbNumCta1
            // 
            this.tbNumCta1.Location = new System.Drawing.Point(110, 91);
            this.tbNumCta1.MaxLength = 1;
            this.tbNumCta1.Name = "tbNumCta1";
            this.tbNumCta1.ReadOnly = true;
            this.tbNumCta1.Size = new System.Drawing.Size(28, 20);
            this.tbNumCta1.TabIndex = 3;
            this.tbNumCta1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNumCta1.Leave += new System.EventHandler(this.tbNumCta1_Leave);
            this.tbNumCta1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNumCta1_KeyUp);
            this.tbNumCta1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumCta1_KeyPress);
            // 
            // FPlanCuentasNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(414, 242);
            this.Controls.Add(this.pbOk);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNumCta5);
            this.Controls.Add(this.tbNumCta4);
            this.Controls.Add(this.tbNumCta3);
            this.Controls.Add(this.tbNumCta2);
            this.Controls.Add(this.tbNumCta1);
            this.Controls.Add(this.chbSelCtaPadre);
            this.Controls.Add(this.tbNombreCuenta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.tbDescripcion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbNombreCuentaPadre);
            this.Controls.Add(this.cbNumeroCuentaPadre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FPlanCuentasNuevo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva cuenta";
            this.Load += new System.EventHandler(this.FPlanCuentasNuevo_Load);
            this.Shown += new System.EventHandler(this.FPlanCuentasNuevo_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbNumeroCuentaPadre;
        private System.Windows.Forms.ComboBox cbNombreCuentaPadre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNombreCuenta;
        private System.Windows.Forms.CheckBox chbSelCtaPadre;
        private System.Windows.Forms.PictureBox pbOk;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNumCta5;
        private System.Windows.Forms.TextBox tbNumCta4;
        private System.Windows.Forms.TextBox tbNumCta3;
        private System.Windows.Forms.TextBox tbNumCta2;
        private System.Windows.Forms.TextBox tbNumCta1;
    }
}