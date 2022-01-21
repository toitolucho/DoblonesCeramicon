namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReportesComprasGrupos
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkSeleccionarCredito = new System.Windows.Forms.CheckBox();
            this.rBtnPorCreditos = new System.Windows.Forms.RadioButton();
            this.checkSeleccionarCliente = new System.Windows.Forms.CheckBox();
            this.rBtnPorClientes = new System.Windows.Forms.RadioButton();
            this.checkSeleccionarProducto = new System.Windows.Forms.CheckBox();
            this.rBtnPorProductos = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rBtnPorFecha = new System.Windows.Forms.RadioButton();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.rBtnPorUsuarios = new System.Windows.Forms.RadioButton();
            this.checkSeleccionarUsuarios = new System.Windows.Forms.CheckBox();
            this.txtBoxTopMenosVendidos = new System.Windows.Forms.TextBox();
            this.txtBoxTopMasVendidos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rBtnMenosVendidos = new System.Windows.Forms.RadioButton();
            this.rBtnMasVendidos = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAceptar);
            this.flowLayoutPanel1.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 255);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(394, 36);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(310, 6);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(229, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBoxTopMenosVendidos);
            this.groupBox1.Controls.Add(this.txtBoxTopMasVendidos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rBtnMenosVendidos);
            this.groupBox1.Controls.Add(this.rBtnMasVendidos);
            this.groupBox1.Controls.Add(this.checkSeleccionarCredito);
            this.groupBox1.Controls.Add(this.rBtnPorCreditos);
            this.groupBox1.Controls.Add(this.checkSeleccionarCliente);
            this.groupBox1.Controls.Add(this.rBtnPorClientes);
            this.groupBox1.Controls.Add(this.checkSeleccionarProducto);
            this.groupBox1.Controls.Add(this.rBtnPorProductos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rBtnPorFecha);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.rBtnPorUsuarios);
            this.groupBox1.Controls.Add(this.checkSeleccionarUsuarios);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 255);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione el Tipo de Reporte ";
            // 
            // checkSeleccionarCredito
            // 
            this.checkSeleccionarCredito.AutoSize = true;
            this.checkSeleccionarCredito.Location = new System.Drawing.Point(139, 155);
            this.checkSeleccionarCredito.Name = "checkSeleccionarCredito";
            this.checkSeleccionarCredito.Size = new System.Drawing.Size(127, 17);
            this.checkSeleccionarCredito.TabIndex = 10;
            this.checkSeleccionarCredito.Text = "Seleccionar &Credito ?";
            this.checkSeleccionarCredito.UseVisualStyleBackColor = true;
            // 
            // rBtnPorCreditos
            // 
            this.rBtnPorCreditos.AutoSize = true;
            this.rBtnPorCreditos.Location = new System.Drawing.Point(17, 155);
            this.rBtnPorCreditos.Name = "rBtnPorCreditos";
            this.rBtnPorCreditos.Size = new System.Drawing.Size(82, 17);
            this.rBtnPorCreditos.TabIndex = 9;
            this.rBtnPorCreditos.Text = "Por Créditos";
            this.rBtnPorCreditos.UseVisualStyleBackColor = true;
            // 
            // checkSeleccionarCliente
            // 
            this.checkSeleccionarCliente.AutoSize = true;
            this.checkSeleccionarCliente.Location = new System.Drawing.Point(139, 120);
            this.checkSeleccionarCliente.Name = "checkSeleccionarCliente";
            this.checkSeleccionarCliente.Size = new System.Drawing.Size(126, 17);
            this.checkSeleccionarCliente.TabIndex = 8;
            this.checkSeleccionarCliente.Text = "Seleccionar &Cliente ?";
            this.checkSeleccionarCliente.UseVisualStyleBackColor = true;
            // 
            // rBtnPorClientes
            // 
            this.rBtnPorClientes.AutoSize = true;
            this.rBtnPorClientes.Location = new System.Drawing.Point(17, 120);
            this.rBtnPorClientes.Name = "rBtnPorClientes";
            this.rBtnPorClientes.Size = new System.Drawing.Size(81, 17);
            this.rBtnPorClientes.TabIndex = 7;
            this.rBtnPorClientes.Text = "Por Clientes";
            this.rBtnPorClientes.UseVisualStyleBackColor = true;
            // 
            // checkSeleccionarProducto
            // 
            this.checkSeleccionarProducto.AutoSize = true;
            this.checkSeleccionarProducto.Location = new System.Drawing.Point(139, 88);
            this.checkSeleccionarProducto.Name = "checkSeleccionarProducto";
            this.checkSeleccionarProducto.Size = new System.Drawing.Size(137, 17);
            this.checkSeleccionarProducto.TabIndex = 6;
            this.checkSeleccionarProducto.Text = "Seleccionar &Producto ?";
            this.checkSeleccionarProducto.UseVisualStyleBackColor = true;
            // 
            // rBtnPorProductos
            // 
            this.rBtnPorProductos.AutoSize = true;
            this.rBtnPorProductos.Location = new System.Drawing.Point(17, 88);
            this.rBtnPorProductos.Name = "rBtnPorProductos";
            this.rBtnPorProductos.Size = new System.Drawing.Size(92, 17);
            this.rBtnPorProductos.TabIndex = 5;
            this.rBtnPorProductos.Text = "Por Productos";
            this.rBtnPorProductos.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha Fin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha Inicio";
            // 
            // rBtnPorFecha
            // 
            this.rBtnPorFecha.AutoSize = true;
            this.rBtnPorFecha.Location = new System.Drawing.Point(17, 43);
            this.rBtnPorFecha.Name = "rBtnPorFecha";
            this.rBtnPorFecha.Size = new System.Drawing.Size(82, 17);
            this.rBtnPorFecha.TabIndex = 2;
            this.rBtnPorFecha.Text = "Por Fechas ";
            this.rBtnPorFecha.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(275, 62);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(104, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(105, 62);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // rBtnPorUsuarios
            // 
            this.rBtnPorUsuarios.AutoSize = true;
            this.rBtnPorUsuarios.Checked = true;
            this.rBtnPorUsuarios.Location = new System.Drawing.Point(17, 20);
            this.rBtnPorUsuarios.Name = "rBtnPorUsuarios";
            this.rBtnPorUsuarios.Size = new System.Drawing.Size(85, 17);
            this.rBtnPorUsuarios.TabIndex = 0;
            this.rBtnPorUsuarios.TabStop = true;
            this.rBtnPorUsuarios.Text = "Por Usuarios";
            this.rBtnPorUsuarios.UseVisualStyleBackColor = true;
            // 
            // checkSeleccionarUsuarios
            // 
            this.checkSeleccionarUsuarios.AutoSize = true;
            this.checkSeleccionarUsuarios.Location = new System.Drawing.Point(139, 21);
            this.checkSeleccionarUsuarios.Name = "checkSeleccionarUsuarios";
            this.checkSeleccionarUsuarios.Size = new System.Drawing.Size(130, 17);
            this.checkSeleccionarUsuarios.TabIndex = 1;
            this.checkSeleccionarUsuarios.Text = "Seleccionar &Usuario ?";
            this.checkSeleccionarUsuarios.UseVisualStyleBackColor = true;
            // 
            // txtBoxTopMenosVendidos
            // 
            this.txtBoxTopMenosVendidos.Location = new System.Drawing.Point(174, 218);
            this.txtBoxTopMenosVendidos.Name = "txtBoxTopMenosVendidos";
            this.txtBoxTopMenosVendidos.Size = new System.Drawing.Size(91, 20);
            this.txtBoxTopMenosVendidos.TabIndex = 22;
            this.txtBoxTopMenosVendidos.Text = "10";
            // 
            // txtBoxTopMasVendidos
            // 
            this.txtBoxTopMasVendidos.Location = new System.Drawing.Point(174, 187);
            this.txtBoxTopMasVendidos.Name = "txtBoxTopMasVendidos";
            this.txtBoxTopMasVendidos.Size = new System.Drawing.Size(91, 20);
            this.txtBoxTopMasVendidos.TabIndex = 21;
            this.txtBoxTopMasVendidos.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Top";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Top ";
            // 
            // rBtnMenosVendidos
            // 
            this.rBtnMenosVendidos.AutoSize = true;
            this.rBtnMenosVendidos.Location = new System.Drawing.Point(17, 221);
            this.rBtnMenosVendidos.Name = "rBtnMenosVendidos";
            this.rBtnMenosVendidos.Size = new System.Drawing.Size(104, 17);
            this.rBtnMenosVendidos.TabIndex = 18;
            this.rBtnMenosVendidos.Text = "Menos Vendidos";
            this.rBtnMenosVendidos.UseVisualStyleBackColor = true;
            // 
            // rBtnMasVendidos
            // 
            this.rBtnMasVendidos.AutoSize = true;
            this.rBtnMasVendidos.Location = new System.Drawing.Point(17, 188);
            this.rBtnMasVendidos.Name = "rBtnMasVendidos";
            this.rBtnMasVendidos.Size = new System.Drawing.Size(92, 17);
            this.rBtnMasVendidos.TabIndex = 17;
            this.rBtnMasVendidos.Text = "Mas Vendidos";
            this.rBtnMasVendidos.UseVisualStyleBackColor = true;
            // 
            // FReportesComprasGrupos
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(394, 291);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FReportesComprasGrupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Compras";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkSeleccionarCredito;
        private System.Windows.Forms.RadioButton rBtnPorCreditos;
        private System.Windows.Forms.CheckBox checkSeleccionarCliente;
        private System.Windows.Forms.RadioButton rBtnPorClientes;
        private System.Windows.Forms.CheckBox checkSeleccionarProducto;
        private System.Windows.Forms.RadioButton rBtnPorProductos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rBtnPorFecha;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton rBtnPorUsuarios;
        private System.Windows.Forms.CheckBox checkSeleccionarUsuarios;
        private System.Windows.Forms.TextBox txtBoxTopMenosVendidos;
        private System.Windows.Forms.TextBox txtBoxTopMasVendidos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rBtnMenosVendidos;
        private System.Windows.Forms.RadioButton rBtnMasVendidos;
    }
}