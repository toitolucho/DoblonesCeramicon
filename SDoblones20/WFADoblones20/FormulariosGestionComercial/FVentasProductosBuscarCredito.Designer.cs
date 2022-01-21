namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FVentasProductosBuscarCredito
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FVentasProductosBuscarCredito));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarAvanzada = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtBosCodigoCredito = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cBoxTipoCredito = new System.Windows.Forms.ComboBox();
            this.txtBoxMontoGastadoCredito = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxObservaciones = new System.Windows.Forms.TextBox();
            this.txtInterez = new System.Windows.Forms.TextBox();
            this.txtBoxMontoVenta = new System.Windows.Forms.TextBox();
            this.txtBoxMontoCredito = new System.Windows.Forms.TextBox();
            this.txtBoxPersonaGarante = new System.Windows.Forms.TextBox();
            this.txtPersonasDeudor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtBoxMontoDisponible = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarAvanzada);
            this.groupBox1.Controls.Add(this.txtBosCodigoCredito);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Intr. el Código de Autorización de Crédito";
            // 
            // btnBuscarAvanzada
            // 
            this.btnBuscarAvanzada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarAvanzada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarAvanzada.ImageIndex = 0;
            this.btnBuscarAvanzada.ImageList = this.imageList1;
            this.btnBuscarAvanzada.Location = new System.Drawing.Point(378, 14);
            this.btnBuscarAvanzada.Name = "btnBuscarAvanzada";
            this.btnBuscarAvanzada.Size = new System.Drawing.Size(123, 30);
            this.btnBuscarAvanzada.TabIndex = 2;
            this.btnBuscarAvanzada.Text = "Buscar Avanzado";
            this.btnBuscarAvanzada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarAvanzada.UseVisualStyleBackColor = true;
            this.btnBuscarAvanzada.Click += new System.EventHandler(this.btnBuscarAvanzada_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Find.ico");
            this.imageList1.Images.SetKeyName(1, "Redo.ico");
            this.imageList1.Images.SetKeyName(2, "Symbol-Check.ico");
            this.imageList1.Images.SetKeyName(3, "Undo.ico");
            // 
            // txtBosCodigoCredito
            // 
            this.txtBosCodigoCredito.Location = new System.Drawing.Point(6, 19);
            this.txtBosCodigoCredito.Name = "txtBosCodigoCredito";
            this.txtBosCodigoCredito.Size = new System.Drawing.Size(285, 20);
            this.txtBosCodigoCredito.TabIndex = 1;
            this.txtBosCodigoCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBosCodigoCredito_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.ImageKey = "Redo.ico";
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(297, 14);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 30);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtBoxMontoDisponible);
            this.groupBox2.Controls.Add(this.cBoxTipoCredito);
            this.groupBox2.Controls.Add(this.txtBoxMontoGastadoCredito);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnAceptar);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtBoxObservaciones);
            this.groupBox2.Controls.Add(this.txtInterez);
            this.groupBox2.Controls.Add(this.txtBoxMontoVenta);
            this.groupBox2.Controls.Add(this.txtBoxMontoCredito);
            this.groupBox2.Controls.Add(this.txtBoxPersonaGarante);
            this.groupBox2.Controls.Add(this.txtPersonasDeudor);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(507, 226);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Crédito";
            // 
            // cBoxTipoCredito
            // 
            this.cBoxTipoCredito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBoxTipoCredito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBoxTipoCredito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cBoxTipoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTipoCredito.Enabled = false;
            this.cBoxTipoCredito.FormattingEnabled = true;
            this.cBoxTipoCredito.Location = new System.Drawing.Point(340, 164);
            this.cBoxTipoCredito.Name = "cBoxTipoCredito";
            this.cBoxTipoCredito.Size = new System.Drawing.Size(157, 21);
            this.cBoxTipoCredito.TabIndex = 16;
            // 
            // txtBoxMontoGastadoCredito
            // 
            this.txtBoxMontoGastadoCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMontoGastadoCredito.Location = new System.Drawing.Point(90, 165);
            this.txtBoxMontoGastadoCredito.Name = "txtBoxMontoGastadoCredito";
            this.txtBoxMontoGastadoCredito.ReadOnly = true;
            this.txtBoxMontoGastadoCredito.Size = new System.Drawing.Size(70, 20);
            this.txtBoxMontoGastadoCredito.TabIndex = 15;
            this.txtBoxMontoGastadoCredito.Text = "0.00";
            this.txtBoxMontoGastadoCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Monto Utilizado";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 3;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(417, 194);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 30);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Observaciones";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.ImageIndex = 2;
            this.btnAceptar.ImageList = this.imageList1;
            this.btnAceptar.Location = new System.Drawing.Point(336, 194);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 30);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Taza de Interez";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Monto Venta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Monto Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Garante";
            // 
            // txtBoxObservaciones
            // 
            this.txtBoxObservaciones.Location = new System.Drawing.Point(90, 101);
            this.txtBoxObservaciones.Multiline = true;
            this.txtBoxObservaciones.Name = "txtBoxObservaciones";
            this.txtBoxObservaciones.ReadOnly = true;
            this.txtBoxObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxObservaciones.Size = new System.Drawing.Size(407, 58);
            this.txtBoxObservaciones.TabIndex = 8;
            // 
            // txtInterez
            // 
            this.txtInterez.Location = new System.Drawing.Point(267, 75);
            this.txtInterez.Name = "txtInterez";
            this.txtInterez.ReadOnly = true;
            this.txtInterez.Size = new System.Drawing.Size(49, 20);
            this.txtInterez.TabIndex = 7;
            this.txtInterez.Text = "0";
            this.txtInterez.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxMontoVenta
            // 
            this.txtBoxMontoVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMontoVenta.ForeColor = System.Drawing.Color.Blue;
            this.txtBoxMontoVenta.Location = new System.Drawing.Point(388, 75);
            this.txtBoxMontoVenta.Name = "txtBoxMontoVenta";
            this.txtBoxMontoVenta.ReadOnly = true;
            this.txtBoxMontoVenta.Size = new System.Drawing.Size(109, 20);
            this.txtBoxMontoVenta.TabIndex = 6;
            this.txtBoxMontoVenta.Text = "0.00";
            this.txtBoxMontoVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxMontoCredito
            // 
            this.txtBoxMontoCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMontoCredito.Location = new System.Drawing.Point(90, 75);
            this.txtBoxMontoCredito.Name = "txtBoxMontoCredito";
            this.txtBoxMontoCredito.ReadOnly = true;
            this.txtBoxMontoCredito.Size = new System.Drawing.Size(90, 20);
            this.txtBoxMontoCredito.TabIndex = 5;
            this.txtBoxMontoCredito.Text = "0.00";
            this.txtBoxMontoCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxPersonaGarante
            // 
            this.txtBoxPersonaGarante.Location = new System.Drawing.Point(90, 49);
            this.txtBoxPersonaGarante.Name = "txtBoxPersonaGarante";
            this.txtBoxPersonaGarante.ReadOnly = true;
            this.txtBoxPersonaGarante.Size = new System.Drawing.Size(407, 20);
            this.txtBoxPersonaGarante.TabIndex = 4;
            // 
            // txtPersonasDeudor
            // 
            this.txtPersonasDeudor.Location = new System.Drawing.Point(90, 23);
            this.txtPersonasDeudor.Name = "txtPersonasDeudor";
            this.txtPersonasDeudor.ReadOnly = true;
            this.txtPersonasDeudor.Size = new System.Drawing.Size(407, 20);
            this.txtPersonasDeudor.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Deudor";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(162, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Monto Disponible";
            // 
            // txtBoxMontoDisponible
            // 
            this.txtBoxMontoDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMontoDisponible.ForeColor = System.Drawing.Color.Blue;
            this.txtBoxMontoDisponible.Location = new System.Drawing.Point(257, 165);
            this.txtBoxMontoDisponible.Name = "txtBoxMontoDisponible";
            this.txtBoxMontoDisponible.ReadOnly = true;
            this.txtBoxMontoDisponible.Size = new System.Drawing.Size(77, 20);
            this.txtBoxMontoDisponible.TabIndex = 17;
            this.txtBoxMontoDisponible.Text = "0.00";
            this.txtBoxMontoDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FVentasProductosBuscarCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(507, 275);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FVentasProductosBuscarCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorización de Crédito";
            this.Load += new System.EventHandler(this.FVentasProductosBuscarCredito_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FVentasProductosBuscarCredito_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBuscarAvanzada;
        private System.Windows.Forms.TextBox txtBosCodigoCredito;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtPersonasDeudor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxPersonaGarante;
        private System.Windows.Forms.TextBox txtBoxObservaciones;
        private System.Windows.Forms.TextBox txtInterez;
        private System.Windows.Forms.TextBox txtBoxMontoVenta;
        private System.Windows.Forms.TextBox txtBoxMontoCredito;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtBoxMontoGastadoCredito;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cBoxTipoCredito;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBoxMontoDisponible;
    }
}