namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FCreditosSiguientePagoAmortizacion
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
            this.lNumeroCredito = new System.Windows.Forms.Label();
            this.tBNumeroCredito = new System.Windows.Forms.TextBox();
            this.tBNumeroCuota = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBCuota = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cBMedioPago = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBNumeroCuentaBancoDeposito = new System.Windows.Forms.TextBox();
            this.lNumeroCuentaDeposito = new System.Windows.Forms.Label();
            this.tBNumeroAgencia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBCodigoUsuario = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bAceptar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.lMoneda = new System.Windows.Forms.Label();
            this.tBCuotaAmortizacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBCuotaInteres = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tBTotalPagado = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tBSaldoAdeudado = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tBTotalAmortizado = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tBFechaProgramadaPago = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tBDIPersonaPago = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBNombreCompletoPersonaPago = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lNumeroCredito
            // 
            this.lNumeroCredito.AutoSize = true;
            this.lNumeroCredito.Location = new System.Drawing.Point(92, 20);
            this.lNumeroCredito.Name = "lNumeroCredito";
            this.lNumeroCredito.Size = new System.Drawing.Size(79, 13);
            this.lNumeroCredito.TabIndex = 0;
            this.lNumeroCredito.Text = "Número crédito";
            this.lNumeroCredito.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tBNumeroCredito
            // 
            this.tBNumeroCredito.Location = new System.Drawing.Point(174, 13);
            this.tBNumeroCredito.Name = "tBNumeroCredito";
            this.tBNumeroCredito.ReadOnly = true;
            this.tBNumeroCredito.Size = new System.Drawing.Size(100, 20);
            this.tBNumeroCredito.TabIndex = 1;
            // 
            // tBNumeroCuota
            // 
            this.tBNumeroCuota.Location = new System.Drawing.Point(174, 37);
            this.tBNumeroCuota.Name = "tBNumeroCuota";
            this.tBNumeroCuota.ReadOnly = true;
            this.tBNumeroCuota.Size = new System.Drawing.Size(50, 20);
            this.tBNumeroCuota.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nº cuota";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tBCuota
            // 
            this.tBCuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBCuota.Location = new System.Drawing.Point(174, 85);
            this.tBCuota.Name = "tBCuota";
            this.tBCuota.Size = new System.Drawing.Size(100, 20);
            this.tBCuota.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Monto pago (cuota)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cBMedioPago
            // 
            this.cBMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBMedioPago.FormattingEnabled = true;
            this.cBMedioPago.Location = new System.Drawing.Point(174, 229);
            this.cBMedioPago.Name = "cBMedioPago";
            this.cBMedioPago.Size = new System.Drawing.Size(144, 21);
            this.cBMedioPago.TabIndex = 0;
            this.cBMedioPago.SelectedIndexChanged += new System.EventHandler(this.cBMedioPago_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Medio pago";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tBNumeroCuentaBancoDeposito
            // 
            this.tBNumeroCuentaBancoDeposito.Location = new System.Drawing.Point(174, 254);
            this.tBNumeroCuentaBancoDeposito.Name = "tBNumeroCuentaBancoDeposito";
            this.tBNumeroCuentaBancoDeposito.Size = new System.Drawing.Size(100, 20);
            this.tBNumeroCuentaBancoDeposito.TabIndex = 1;
            // 
            // lNumeroCuentaDeposito
            // 
            this.lNumeroCuentaDeposito.AutoSize = true;
            this.lNumeroCuentaDeposito.Location = new System.Drawing.Point(84, 261);
            this.lNumeroCuentaDeposito.Name = "lNumeroCuentaDeposito";
            this.lNumeroCuentaDeposito.Size = new System.Drawing.Size(87, 13);
            this.lNumeroCuentaDeposito.TabIndex = 10;
            this.lNumeroCuentaDeposito.Text = "Número deposito";
            this.lNumeroCuentaDeposito.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tBNumeroAgencia
            // 
            this.tBNumeroAgencia.Location = new System.Drawing.Point(174, 326);
            this.tBNumeroAgencia.Name = "tBNumeroAgencia";
            this.tBNumeroAgencia.ReadOnly = true;
            this.tBNumeroAgencia.Size = new System.Drawing.Size(50, 20);
            this.tBNumeroAgencia.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Numero agencia";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tBCodigoUsuario
            // 
            this.tBCodigoUsuario.Location = new System.Drawing.Point(174, 350);
            this.tBCodigoUsuario.Name = "tBCodigoUsuario";
            this.tBCodigoUsuario.ReadOnly = true;
            this.tBCodigoUsuario.Size = new System.Drawing.Size(50, 20);
            this.tBCodigoUsuario.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(95, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "CodigoUsuario";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(174, 383);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(75, 23);
            this.bAceptar.TabIndex = 4;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Location = new System.Drawing.Point(255, 383);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 23);
            this.bCancelar.TabIndex = 5;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // lMoneda
            // 
            this.lMoneda.AutoSize = true;
            this.lMoneda.Location = new System.Drawing.Point(278, 92);
            this.lMoneda.Name = "lMoneda";
            this.lMoneda.Size = new System.Drawing.Size(31, 13);
            this.lMoneda.TabIndex = 20;
            this.lMoneda.Text = "????";
            // 
            // tBCuotaAmortizacion
            // 
            this.tBCuotaAmortizacion.Location = new System.Drawing.Point(174, 109);
            this.tBCuotaAmortizacion.Name = "tBCuotaAmortizacion";
            this.tBCuotaAmortizacion.ReadOnly = true;
            this.tBCuotaAmortizacion.Size = new System.Drawing.Size(100, 20);
            this.tBCuotaAmortizacion.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Amortización";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tBCuotaInteres
            // 
            this.tBCuotaInteres.Location = new System.Drawing.Point(174, 133);
            this.tBCuotaInteres.Name = "tBCuotaInteres";
            this.tBCuotaInteres.ReadOnly = true;
            this.tBCuotaInteres.Size = new System.Drawing.Size(100, 20);
            this.tBCuotaInteres.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(132, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Interes";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tBTotalPagado
            // 
            this.tBTotalPagado.Location = new System.Drawing.Point(174, 205);
            this.tBTotalPagado.Name = "tBTotalPagado";
            this.tBTotalPagado.ReadOnly = true;
            this.tBTotalPagado.Size = new System.Drawing.Size(100, 20);
            this.tBTotalPagado.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(101, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Total pagado";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tBSaldoAdeudado
            // 
            this.tBSaldoAdeudado.Location = new System.Drawing.Point(174, 181);
            this.tBSaldoAdeudado.Name = "tBSaldoAdeudado";
            this.tBSaldoAdeudado.ReadOnly = true;
            this.tBSaldoAdeudado.Size = new System.Drawing.Size(100, 20);
            this.tBSaldoAdeudado.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(86, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Saldo adeudado";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tBTotalAmortizado
            // 
            this.tBTotalAmortizado.Location = new System.Drawing.Point(174, 157);
            this.tBTotalAmortizado.Name = "tBTotalAmortizado";
            this.tBTotalAmortizado.ReadOnly = true;
            this.tBTotalAmortizado.Size = new System.Drawing.Size(100, 20);
            this.tBTotalAmortizado.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(86, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Total amortizado";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tBFechaProgramadaPago
            // 
            this.tBFechaProgramadaPago.Location = new System.Drawing.Point(174, 61);
            this.tBFechaProgramadaPago.Name = "tBFechaProgramadaPago";
            this.tBFechaProgramadaPago.ReadOnly = true;
            this.tBFechaProgramadaPago.Size = new System.Drawing.Size(80, 20);
            this.tBFechaProgramadaPago.TabIndex = 32;
            this.tBFechaProgramadaPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Fecha programada de pago";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tBDIPersonaPago
            // 
            this.tBDIPersonaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBDIPersonaPago.Location = new System.Drawing.Point(174, 278);
            this.tBDIPersonaPago.Name = "tBDIPersonaPago";
            this.tBDIPersonaPago.Size = new System.Drawing.Size(100, 20);
            this.tBDIPersonaPago.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "DI persona pago";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tBNombreCompletoPersonaPago
            // 
            this.tBNombreCompletoPersonaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBNombreCompletoPersonaPago.Location = new System.Drawing.Point(174, 302);
            this.tBNombreCompletoPersonaPago.Name = "tBNombreCompletoPersonaPago";
            this.tBNombreCompletoPersonaPago.Size = new System.Drawing.Size(300, 20);
            this.tBNombreCompletoPersonaPago.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 309);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(158, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Nombre completo persona pago";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FCreditosSiguientePagoAmortizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 416);
            this.Controls.Add(this.tBNombreCompletoPersonaPago);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tBDIPersonaPago);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tBFechaProgramadaPago);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tBTotalPagado);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tBSaldoAdeudado);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tBTotalAmortizado);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tBCuotaInteres);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tBCuotaAmortizacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lMoneda);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.tBCodigoUsuario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tBNumeroAgencia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tBNumeroCuentaBancoDeposito);
            this.Controls.Add(this.lNumeroCuentaDeposito);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cBMedioPago);
            this.Controls.Add(this.tBCuota);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tBNumeroCuota);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBNumeroCredito);
            this.Controls.Add(this.lNumeroCredito);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FCreditosSiguientePagoAmortizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago siguiente amortización";
            this.Load += new System.EventHandler(this.FCreditoPagoAmortizacionNuevo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lNumeroCredito;
        private System.Windows.Forms.TextBox tBNumeroCredito;
        private System.Windows.Forms.TextBox tBNumeroCuota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBCuota;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBMedioPago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBNumeroCuentaBancoDeposito;
        private System.Windows.Forms.Label lNumeroCuentaDeposito;
        private System.Windows.Forms.TextBox tBNumeroAgencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBCodigoUsuario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Label lMoneda;
        private System.Windows.Forms.TextBox tBCuotaAmortizacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBCuotaInteres;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tBTotalPagado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tBSaldoAdeudado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tBTotalAmortizado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tBFechaProgramadaPago;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tBDIPersonaPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBNombreCompletoPersonaPago;
        private System.Windows.Forms.Label label13;
    }
}