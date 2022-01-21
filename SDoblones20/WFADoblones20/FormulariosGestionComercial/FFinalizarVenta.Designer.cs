namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FFinalizarVenta
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
            this.checkFactura = new System.Windows.Forms.CheckBox();
            this.checkRecibo = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBoxCambio = new System.Windows.Forms.TextBox();
            this.txtMontoCancelado = new System.Windows.Forms.TextBox();
            this.txtBoxMontoTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlTransaccion = new System.Windows.Forms.Panel();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.pnlDocumentos = new System.Windows.Forms.Panel();
            this.txtBoxNombreCliente = new System.Windows.Forms.TextBox();
            this.txtBoxFactura = new System.Windows.Forms.TextBox();
            this.txtBoxNITCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlTransaccion.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.pnlDocumentos.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkFactura);
            this.groupBox1.Controls.Add(this.checkRecibo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Documentos de Venta";
            // 
            // checkFactura
            // 
            this.checkFactura.AutoSize = true;
            this.checkFactura.Location = new System.Drawing.Point(293, 28);
            this.checkFactura.Name = "checkFactura";
            this.checkFactura.Size = new System.Drawing.Size(62, 17);
            this.checkFactura.TabIndex = 0;
            this.checkFactura.Text = "Factura";
            this.checkFactura.UseVisualStyleBackColor = true;
            this.checkFactura.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkRecibo
            // 
            this.checkRecibo.AutoSize = true;
            this.checkRecibo.Location = new System.Drawing.Point(75, 28);
            this.checkRecibo.Name = "checkRecibo";
            this.checkRecibo.Size = new System.Drawing.Size(63, 17);
            this.checkRecibo.TabIndex = 1;
            this.checkRecibo.Text = "Recibo ";
            this.checkRecibo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBoxCambio);
            this.groupBox2.Controls.Add(this.txtMontoCancelado);
            this.groupBox2.Controls.Add(this.txtBoxMontoTotal);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 132);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle de Transacción de Venta";
            // 
            // txtBoxCambio
            // 
            this.txtBoxCambio.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtBoxCambio.Location = new System.Drawing.Point(261, 94);
            this.txtBoxCambio.Name = "txtBoxCambio";
            this.txtBoxCambio.ReadOnly = true;
            this.txtBoxCambio.Size = new System.Drawing.Size(157, 20);
            this.txtBoxCambio.TabIndex = 1;
            // 
            // txtMontoCancelado
            // 
            this.txtMontoCancelado.Location = new System.Drawing.Point(261, 59);
            this.txtMontoCancelado.Name = "txtMontoCancelado";
            this.txtMontoCancelado.Size = new System.Drawing.Size(157, 20);
            this.txtMontoCancelado.TabIndex = 0;
            this.txtMontoCancelado.TextChanged += new System.EventHandler(this.txtMontoCancelado_TextChanged);
            this.txtMontoCancelado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoCancelado_KeyPress);
            // 
            // txtBoxMontoTotal
            // 
            this.txtBoxMontoTotal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtBoxMontoTotal.Location = new System.Drawing.Point(261, 25);
            this.txtBoxMontoTotal.Name = "txtBoxMontoTotal";
            this.txtBoxMontoTotal.ReadOnly = true;
            this.txtBoxMontoTotal.Size = new System.Drawing.Size(157, 20);
            this.txtBoxMontoTotal.TabIndex = 3;
            this.txtBoxMontoTotal.Leave += new System.EventHandler(this.txtBoxMontoTotal_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Monto de Cambio a Devolver";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Monto Cancelado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto Total";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(343, 9);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 0;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(256, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // pnlTransaccion
            // 
            this.pnlTransaccion.Controls.Add(this.groupBox2);
            this.pnlTransaccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTransaccion.Location = new System.Drawing.Point(0, 100);
            this.pnlTransaccion.Name = "pnlTransaccion";
            this.pnlTransaccion.Size = new System.Drawing.Size(430, 132);
            this.pnlTransaccion.TabIndex = 4;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnFinalizar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 289);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(430, 40);
            this.pnlBotones.TabIndex = 5;
            // 
            // pnlDocumentos
            // 
            this.pnlDocumentos.Controls.Add(this.txtBoxNombreCliente);
            this.pnlDocumentos.Controls.Add(this.txtBoxFactura);
            this.pnlDocumentos.Controls.Add(this.txtBoxNITCliente);
            this.pnlDocumentos.Controls.Add(this.label6);
            this.pnlDocumentos.Controls.Add(this.label5);
            this.pnlDocumentos.Controls.Add(this.label4);
            this.pnlDocumentos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDocumentos.Location = new System.Drawing.Point(0, 0);
            this.pnlDocumentos.Name = "pnlDocumentos";
            this.pnlDocumentos.Size = new System.Drawing.Size(430, 100);
            this.pnlDocumentos.TabIndex = 6;
            // 
            // txtBoxNombreCliente
            // 
            this.txtBoxNombreCliente.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtBoxNombreCliente.Location = new System.Drawing.Point(112, 59);
            this.txtBoxNombreCliente.Name = "txtBoxNombreCliente";
            this.txtBoxNombreCliente.ReadOnly = true;
            this.txtBoxNombreCliente.Size = new System.Drawing.Size(306, 20);
            this.txtBoxNombreCliente.TabIndex = 1;
            // 
            // txtBoxFactura
            // 
            this.txtBoxFactura.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtBoxFactura.Location = new System.Drawing.Point(318, 22);
            this.txtBoxFactura.Name = "txtBoxFactura";
            this.txtBoxFactura.ReadOnly = true;
            this.txtBoxFactura.Size = new System.Drawing.Size(100, 20);
            this.txtBoxFactura.TabIndex = 4;
            // 
            // txtBoxNITCliente
            // 
            this.txtBoxNITCliente.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtBoxNITCliente.Location = new System.Drawing.Point(112, 22);
            this.txtBoxNITCliente.Name = "txtBoxNITCliente";
            this.txtBoxNITCliente.ReadOnly = true;
            this.txtBoxNITCliente.Size = new System.Drawing.Size(100, 20);
            this.txtBoxNITCliente.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Numero Factura";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nit Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nombre Cliente :";
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.Controls.Add(this.pnlTransaccion);
            this.pnlCuerpo.Controls.Add(this.pnlDocumentos);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpo.Location = new System.Drawing.Point(0, 57);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(430, 232);
            this.pnlCuerpo.TabIndex = 2;
            // 
            // FFinalizarVenta
            // 
            this.AcceptButton = this.btnFinalizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(430, 329);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FFinalizarVenta";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Finalización de la Venta";
            this.Load += new System.EventHandler(this.FFinalizarVenta_Load);
            this.Shown += new System.EventHandler(this.FFiinalizarVenta_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlTransaccion.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.pnlDocumentos.ResumeLayout(false);
            this.pnlDocumentos.PerformLayout();
            this.pnlCuerpo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxCambio;
        private System.Windows.Forms.TextBox txtMontoCancelado;
        private System.Windows.Forms.TextBox txtBoxMontoTotal;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox checkFactura;
        private System.Windows.Forms.CheckBox checkRecibo;
        private System.Windows.Forms.Panel pnlTransaccion;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Panel pnlDocumentos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.TextBox txtBoxNombreCliente;
        private System.Windows.Forms.TextBox txtBoxFactura;
        private System.Windows.Forms.TextBox txtBoxNITCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}